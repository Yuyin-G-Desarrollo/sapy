Imports System.Xml
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports ToolServicios
Imports System.IO

Public Class TimbradoNominaBU
    Const cfdi As String = "http://www.sat.gob.mx/cfd/3"
    Const xsi As String = "http://www.w3.org/2001/XMLSchema-instance"
    Const implocal As String = "http://www.sat.gob.mx/implocal"
    Const schemaLocation As String = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd"
    Const nomina12 As String = "http://www.sat.gob.mx/nomina12"
    Const rutaQR As String = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?"
    Const claveDocumento As String = "RECIBODENOMINA"

    Public strMensaje As String = String.Empty
    Public pruebas As Boolean = False 'True
    Dim empresaId As Integer = 0

    Dim timNominaFiscal As Entidades.TimbreNominaFiscal
    Dim lstCfdiRelacionados As List(Of Entidades.TimbreCfdiRelacionados)
    Dim lstPercepciones As List(Of Entidades.TimbrePercepcion)
    Dim lstDeducciones As List(Of Entidades.TimbreDeduccion)
    Dim lstOtrosPagos As List(Of Entidades.TimbreOtrosPagos)
    Dim lstIncapacidades As List(Of Entidades.TimbreIncapacidad)
    Dim lstHorasExtra As List(Of Entidades.TimbreHorasExtra)
    Dim rutas As Entidades.RutasDocumentosFacturacion

    Dim rutaXml As String = String.Empty
    Dim rutaPdf As String = String.Empty

    Sub New(ByVal bPruebas As Boolean)
        pruebas = bPruebas
    End Sub

    Public Function obtenerInformacion(ByVal timNominaFiscalId As Integer) As Boolean
        Try
            Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
            Dim objUtileriasBU As New UtileriasFacturasBU

            timNominaFiscal = objBU.consultarInformacionRecibo(timNominaFiscalId)
            If Not timNominaFiscal Is Nothing Then
                lstCfdiRelacionados = objBU.consultarInformacionTimbrarCfdiRelacionados(timNominaFiscal.TNFTimbreNominaFiscalId)

                lstPercepciones = objBU.consultarInformacionTimbrarPercepciones(timNominaFiscal.TNFTimbreNominaFiscalId)
                If Not lstPercepciones Is Nothing Then
                    If lstPercepciones.Count = 0 Then
                        strMensaje = "No hay percepciones para el recibo de nómina con id " & timNominaFiscalId
                        Try
                            objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, strMensaje.ToUpper)
                        Catch ex As Exception
                        End Try
                        Return False
                    End If
                Else
                    Try
                        strMensaje = "No hay percepciones para el recibo de nómina con id " & timNominaFiscalId
                        objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, strMensaje.ToUpper)
                    Catch ex As Exception
                    End Try
                    Return False
                End If

                lstDeducciones = objBU.consultarInformacionTimbrarDeducciones(timNominaFiscal.TNFTimbreNominaFiscalId)
                'If Not lstDeducciones Is Nothing Then
                '    If lstDeducciones.Count = 0 Then
                '        strMensaje = "No hay deducciones para el recibo de nómina con id " & timNominaFiscalId
                '        Try
                '            objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, strMensaje.ToUpper)
                '        Catch ex As Exception
                '        End Try
                '        Return False
                '    End If
                'Else
                '    strMensaje = "No hay deducciones para el recibo de nómina con id " & timNominaFiscalId
                '    Try
                '        objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, strMensaje.ToUpper)
                '    Catch ex As Exception
                '    End Try
                '    Return False
                'End If

                lstOtrosPagos = objBU.consultarInformacionTimbrarOtrosPagos(timNominaFiscal.TNFTimbreNominaFiscalId)
                lstIncapacidades = objBU.consultarInformacionTimbrarIncapacidades(timNominaFiscal.TNFTimbreNominaFiscalId)
                lstHorasExtra = objBU.consultarInformacionTimbrarHorasExtra(timNominaFiscal.TNFTimbreNominaFiscalId)

                rutas = objUtileriasBU.ObtenerDirectoriosNomina(obtenerEmpresaId(timNominaFiscal.TNFPatronId), 3, "AMBOS")
                rutaXml = rutas.RutaServicioRest & timNominaFiscal.TNFXml

                Return True
            Else
                strMensaje = "No se encontró el recibo de nómina."
                Return False
            End If
        Catch ex As Exception
            strMensaje = ex.Message
            Return False
        End Try
    End Function

    Private Function obtenerEmpresaId(ByVal patronId As Integer) As Integer
        Try
            Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
            Dim dtDatos As New DataTable

            If pruebas Then
                patronId = 0
            End If
            dtDatos = objBU.consultarDatosEmpresa(patronId)
            Return dtDatos.Rows(0)("EmpresaId")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function timbradoReciboNomina(ByVal timNominaFiscalId As Integer, ByVal usuarioId As Integer) As RespuestaRestArray
        Dim objTimbradoBU As Facturacion.Negocios.TimbradoBU = Nothing
        Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
        Dim resultado As Boolean = False
        Dim Respuesta As New RespuestaRestArray
        Dim RutasTimbrado(6) As String

        Try
            If obtenerInformacion(timNominaFiscalId) Then
                objTimbradoBU = New Facturacion.Negocios.TimbradoBU(obtenerEmpresaId(timNominaFiscal.TNFPatronId), pruebas)
                If generarXML() Then
                    timNominaFiscal.TNFCadenaOriginal = objTimbradoBU.GenerarCadenaOriginal(rutaXml, timNominaFiscalId, claveDocumento)
                    If timNominaFiscal.TNFCadenaOriginal <> "" Then
                        timNominaFiscal.TNFSello = objTimbradoBU.GeneraSello(rutaXml, timNominaFiscal.TNFCadenaOriginal, timNominaFiscal.TNFTimbreNominaFiscalId, claveDocumento)
                        If timNominaFiscal.TNFSello <> "" Then
                            If objTimbradoBU.AgregarSelloXML(rutaXml, timNominaFiscal.TNFSello) Then
                                If objTimbradoBU.GenerarTimbrado(rutaXml, timNominaFiscal.TNFTimbreNominaFiscalId, claveDocumento) Then
                                    timNominaFiscal = actualizarDatosDelComplemento(usuarioId)
                                    If timNominaFiscal.TNFMensajeError <> "EXITO" Then
                                        strMensaje = timNominaFiscal.TNFMensajeError
                                    End If

                                    generarPdf("TIMBRADO")
                                    resultado = True
                                Else
                                    strMensaje = objTimbradoBU.mensaje
                                End If
                            Else
                                strMensaje = "No se pudo agregar el sello al xml."
                            End If
                        Else
                            strMensaje = "No se pudo generar el sello."
                        End If
                    Else
                        strMensaje = "No se pudo generar la cadena original."
                    End If
                End If

                If strMensaje <> "" Then
                    Try
                        objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, strMensaje.ToUpper)
                    Catch ex As Exception

                    End Try
                End If
            End If


        Catch ex As Exception
            strMensaje = ex.Message
        End Try

        If resultado = True Then
            Respuesta.respuesta = 1
            Respuesta.aviso = strMensaje
            RutasTimbrado(0) = rutas.RutaServicioRest
            RutasTimbrado(1) = rutas.RutaSICY
            RutasTimbrado(2) = rutas.RutaCliente
            RutasTimbrado(3) = rutas.RutaContabilidad
            RutasTimbrado(4) = timNominaFiscal.TNFXml
            RutasTimbrado(5) = timNominaFiscal.TNFPdf
            Respuesta.mensaje = RutasTimbrado
        Else
            Respuesta.respuesta = 0
            Respuesta.aviso = strMensaje
            Respuesta.mensaje = Nothing
        End If

        If IsNothing(objTimbradoBU) = False Then
            objTimbradoBU.EliminarArchivosTemporales(objTimbradoBU.RutaArchivosTemp, timNominaFiscalId, claveDocumento)
        End If
        Return Respuesta
    End Function

    Public Function generarXML() As Boolean
        Dim resultado As Boolean = False
        Dim myXmlTextWriter As XmlTextWriter
        Dim iCfdiRelacionados As New Entidades.TimbreCfdiRelacionados
        Dim iPercepciones As New Entidades.TimbrePercepcion
        Dim iDeducciones As New Entidades.TimbreDeduccion
        Dim iOtrosPagos As New Entidades.TimbreOtrosPagos
        Dim iIncapacidades As New Entidades.TimbreIncapacidad
        Dim iHorasExtra As New Entidades.TimbreHorasExtra
        Dim objUtileriasBU As New UtileriasFacturasBU

        Try
            If Not timNominaFiscal Is Nothing Then
                objUtileriasBU.CrearDirectorio(rutaXml)
                myXmlTextWriter = New XmlTextWriter(rutaXml, System.Text.Encoding.UTF8)
                myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)

                If pruebas Then
                    Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
                    Dim dtDatos As New DataTable

                    dtDatos = objBU.consultarDatosEmpresa(0)
                    timNominaFiscal.TNFNoCertificado = dtDatos.Rows(0)("noCertificado")
                    timNominaFiscal.TNFCertificado = dtDatos.Rows(0)("certificado")
                    timNominaFiscal.TNFEmisorRfc = dtDatos.Rows(0)("rfcEmisor")
                    timNominaFiscal.TNFEmisorRegimen = dtDatos.Rows(0)("regimen")
                    'timNominaFiscal.TNFReceptorRfc = dtDatos.Rows(0)("rfcReceptor")
                End If

                'Comprobante
                myXmlTextWriter.WriteStartElement("cfdi:Comprobante")
                myXmlTextWriter.WriteAttributeString("xmlns:cfdi", cfdi)
                myXmlTextWriter.WriteAttributeString("xmlns:xsi", xsi)
                myXmlTextWriter.WriteAttributeString("xmlns:implocal", implocal)
                myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", schemaLocation)
                myXmlTextWriter.WriteAttributeString("xmlns:nomina12", nomina12)
                myXmlTextWriter.WriteAttributeString("Version", timNominaFiscal.TNFVersion)
                myXmlTextWriter.WriteAttributeString("Serie", timNominaFiscal.TNFSerie)
                myXmlTextWriter.WriteAttributeString("Folio", timNominaFiscal.TNFFolio)
                myXmlTextWriter.WriteAttributeString("Fecha", timNominaFiscal.TNFFecha.ToString("yyyy-MM-ddTHH:mm:ss"))
                myXmlTextWriter.WriteAttributeString("Sello", timNominaFiscal.TNFSello)
                myXmlTextWriter.WriteAttributeString("FormaPago", timNominaFiscal.TNFFormaPago)
                myXmlTextWriter.WriteAttributeString("NoCertificado", timNominaFiscal.TNFNoCertificado)
                myXmlTextWriter.WriteAttributeString("Certificado", timNominaFiscal.TNFCertificado)
                myXmlTextWriter.WriteAttributeString("SubTotal", timNominaFiscal.TNFSubTotal.ToString("0.00"))
                If timNominaFiscal.TNFDescuento <> 0 Then
                    myXmlTextWriter.WriteAttributeString("Descuento", timNominaFiscal.TNFDescuento.ToString("0.00"))
                End If
                myXmlTextWriter.WriteAttributeString("Moneda", timNominaFiscal.TNFMoneda)
                myXmlTextWriter.WriteAttributeString("Total", timNominaFiscal.TNFTotal.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("TipoDeComprobante ", timNominaFiscal.TNFTipoDeComprobante)
                myXmlTextWriter.WriteAttributeString("MetodoPago", timNominaFiscal.TNFMetodoDePago)
                myXmlTextWriter.WriteAttributeString("LugarExpedicion", timNominaFiscal.TNFLugarExpedicion)

                'CfdiRelacionados
                If Not lstCfdiRelacionados Is Nothing Then
                    If lstCfdiRelacionados.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionados")
                        myXmlTextWriter.WriteAttributeString("TipoRelacion", lstCfdiRelacionados(0).TCRTipoRelacion)
                        For Each iCfdiRelacionados In lstCfdiRelacionados
                            myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionado")
                            myXmlTextWriter.WriteAttributeString("UUID", iCfdiRelacionados.TCRUuid)
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If

                'Emisor
                myXmlTextWriter.WriteStartElement("cfdi:Emisor")
                myXmlTextWriter.WriteAttributeString("Rfc", timNominaFiscal.TNFEmisorRfc)
                myXmlTextWriter.WriteAttributeString("Nombre", timNominaFiscal.TNFEmisorRazonSocial)
                myXmlTextWriter.WriteAttributeString("RegimenFiscal", timNominaFiscal.TNFEmisorRegimen)
                myXmlTextWriter.WriteEndElement()

                'Receptor
                myXmlTextWriter.WriteStartElement("cfdi:Receptor")
                myXmlTextWriter.WriteAttributeString("Rfc", timNominaFiscal.TNFReceptorRfc)
                myXmlTextWriter.WriteAttributeString("Nombre", timNominaFiscal.TNFReceptorNombre)
                myXmlTextWriter.WriteAttributeString("UsoCFDI", timNominaFiscal.TNFUsoCfdi)
                myXmlTextWriter.WriteEndElement()

                'Concepto
                myXmlTextWriter.WriteStartElement("cfdi:Conceptos")
                myXmlTextWriter.WriteStartElement("cfdi:Concepto")
                myXmlTextWriter.WriteAttributeString("ClaveProdServ", timNominaFiscal.TNFClaveProdServ)
                myXmlTextWriter.WriteAttributeString("Cantidad", timNominaFiscal.TNFCantidad.ToString("0"))
                myXmlTextWriter.WriteAttributeString("ClaveUnidad", timNominaFiscal.TNFUnidad)
                myXmlTextWriter.WriteAttributeString("Descripcion", timNominaFiscal.TNFDescripcion)
                myXmlTextWriter.WriteAttributeString("ValorUnitario", timNominaFiscal.TNFValorUnitario.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("Importe", timNominaFiscal.TNFImporte.ToString("0.00"))
                If timNominaFiscal.TNFDescuento > 0 Then
                    myXmlTextWriter.WriteAttributeString("Descuento", timNominaFiscal.TNFDescuento.ToString("0.00"))
                End If
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()

                'ComplementoNomina
                myXmlTextWriter.WriteStartElement("cfdi:Complemento")
                myXmlTextWriter.WriteStartElement("nomina12:Nomina")
                myXmlTextWriter.WriteAttributeString("Version", timNominaFiscal.TNFVersionNom)
                myXmlTextWriter.WriteAttributeString("TipoNomina", timNominaFiscal.TNFTipoNomina)
                myXmlTextWriter.WriteAttributeString("FechaPago", timNominaFiscal.TNFFechaPago.ToString("yyyy-MM-dd"))
                myXmlTextWriter.WriteAttributeString("FechaInicialPago", timNominaFiscal.TNFFechaInicialPago.ToString("yyyy-MM-dd"))
                myXmlTextWriter.WriteAttributeString("FechaFinalPago", timNominaFiscal.TNFFechaFinalPago.ToString("yyyy-MM-dd"))
                myXmlTextWriter.WriteAttributeString("NumDiasPagados", timNominaFiscal.TNFNumDiasPagados.ToString("0.000"))
                myXmlTextWriter.WriteAttributeString("TotalPercepciones", timNominaFiscal.TNFTotalPercepciones.ToString("0.00"))
                If timNominaFiscal.TNFTotalDeducciones > 0 Then
                    myXmlTextWriter.WriteAttributeString("TotalDeducciones", timNominaFiscal.TNFTotalDeducciones.ToString("0.00"))
                End If
                If timNominaFiscal.TNFTotalOtrosPagos > 0 Then
                    myXmlTextWriter.WriteAttributeString("TotalOtrosPagos", timNominaFiscal.TNFTotalOtrosPagos.ToString("0.00"))
                End If
                'ComplementoNomina/Emisor
                myXmlTextWriter.WriteStartElement("nomina12:Emisor")
                If timNominaFiscal.TNFEmisorRfc.Trim.Length = 13 Then
                    myXmlTextWriter.WriteAttributeString("Curp", timNominaFiscal.TNFEmisorCurp)
                End If
                myXmlTextWriter.WriteAttributeString("RegistroPatronal", timNominaFiscal.TNFRegistroPatronal)
                myXmlTextWriter.WriteEndElement()
                'ComplementoNomina/Receptor
                myXmlTextWriter.WriteStartElement("nomina12:Receptor")
                myXmlTextWriter.WriteAttributeString("Curp", timNominaFiscal.TNFReceptorCurp)
                myXmlTextWriter.WriteAttributeString("NumSeguridadSocial", timNominaFiscal.TNFReceptorNumSeguridadSocial)
                myXmlTextWriter.WriteAttributeString("FechaInicioRelLaboral", timNominaFiscal.TNFReceptorFechaInicioRelLaboral.ToString("yyyy-MM-dd"))
                If timNominaFiscal.TNFReceptorAntiguedad <> "" Then
                    myXmlTextWriter.WriteAttributeString("Antigüedad", timNominaFiscal.TNFReceptorAntiguedad)
                End If
                myXmlTextWriter.WriteAttributeString("TipoContrato", timNominaFiscal.TNFReceptorTipoContrato)
                myXmlTextWriter.WriteAttributeString("TipoJornada", timNominaFiscal.TNFReceptorTipoJornada)
                myXmlTextWriter.WriteAttributeString("TipoRegimen", timNominaFiscal.TNFReceptorTipoRegimen)
                myXmlTextWriter.WriteAttributeString("NumEmpleado", timNominaFiscal.TNFReceptorNumEmpleado)
                myXmlTextWriter.WriteAttributeString("RiesgoPuesto", timNominaFiscal.TNFReceptorRiesgoPuesto)
                myXmlTextWriter.WriteAttributeString("PeriodicidadPago", timNominaFiscal.TNFReceptorPeriodicidadPago)
                myXmlTextWriter.WriteAttributeString("SalarioBaseCotApor", timNominaFiscal.TNFReceptorSalarioBaseCotApor.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("SalarioDiarioIntegrado", timNominaFiscal.TNFReceptorSalarioDiarioIntegrado.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("ClaveEntFed", timNominaFiscal.TNFReceptorClaveEntFed)
                myXmlTextWriter.WriteEndElement()
                'ComplementoNomina/Percepciones
                If Not lstPercepciones Is Nothing Then
                    If lstPercepciones.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("nomina12:Percepciones")
                        myXmlTextWriter.WriteAttributeString("TotalSueldos", timNominaFiscal.TNFTotalSueldos.ToString("0.00"))
                        myXmlTextWriter.WriteAttributeString("TotalGravado", timNominaFiscal.TNFPercepcionesTotalGravado.ToString("0.00"))
                        myXmlTextWriter.WriteAttributeString("TotalExento", timNominaFiscal.TNFPercepcionesTotalExento.ToString("0.00"))
                        For Each iPercepciones In lstPercepciones
                            myXmlTextWriter.WriteStartElement("nomina12:Percepcion")
                            myXmlTextWriter.WriteAttributeString("TipoPercepcion", iPercepciones.TPTipoPercepcion)
                            myXmlTextWriter.WriteAttributeString("Clave", iPercepciones.TPClavePercepcion)
                            myXmlTextWriter.WriteAttributeString("Concepto", iPercepciones.TPConceptoPercepcion)
                            myXmlTextWriter.WriteAttributeString("ImporteGravado", iPercepciones.TPImporteGravadoPercepcion.ToString("0.00"))
                            myXmlTextWriter.WriteAttributeString("ImporteExento", iPercepciones.TPImporteExentoPercepcion.ToString("0.00"))
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If
                'ComplementoNomina/Deducciones
                If Not lstDeducciones Is Nothing Then
                    If lstDeducciones.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("nomina12:Deducciones")
                        If timNominaFiscal.TNFDeduccionesTotalOtras <> 0 Then
                            myXmlTextWriter.WriteAttributeString("TotalOtrasDeducciones", timNominaFiscal.TNFDeduccionesTotalOtras.ToString("0.00"))
                        End If
                        If timNominaFiscal.TNFDeduccionesTotalImpuestosRet <> 0 Then
                            myXmlTextWriter.WriteAttributeString("TotalImpuestosRetenidos", timNominaFiscal.TNFDeduccionesTotalImpuestosRet.ToString("0.00"))
                        End If
                        For Each iDeducciones In lstDeducciones
                            myXmlTextWriter.WriteStartElement("nomina12:Deduccion")
                            myXmlTextWriter.WriteAttributeString("TipoDeduccion", iDeducciones.TDTipoDeduccion)
                            myXmlTextWriter.WriteAttributeString("Clave", iDeducciones.TDClaveDeduccion)
                            myXmlTextWriter.WriteAttributeString("Concepto", iDeducciones.TDConceptoDeduccion)
                            myXmlTextWriter.WriteAttributeString("Importe", iDeducciones.TFImporteDeduccion.ToString("0.00"))
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If
                'ComplementoNomina/OtrosPagos
                If Not lstOtrosPagos Is Nothing Then
                    If lstOtrosPagos.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("nomina12:OtrosPagos")
                        For Each iOtrosPagos In lstOtrosPagos
                            myXmlTextWriter.WriteStartElement("nomina12:OtroPago")
                            myXmlTextWriter.WriteAttributeString("TipoOtroPago", iOtrosPagos.TOPTipoOtrosPagos)
                            myXmlTextWriter.WriteAttributeString("Clave", iOtrosPagos.TOPClaveOtrosPagos)
                            myXmlTextWriter.WriteAttributeString("Concepto", iOtrosPagos.TOPConceptoOtrosPagos)
                            myXmlTextWriter.WriteAttributeString("Importe", iOtrosPagos.TOPImporteOtrosPagos.ToString("0.00"))
                            If (iOtrosPagos.TOPSubsidioCausado >= 0) And (iOtrosPagos.TOPTipoOtrosPagos = "002") Then
                                myXmlTextWriter.WriteStartElement("nomina12:SubsidioAlEmpleo ")
                                myXmlTextWriter.WriteAttributeString("SubsidioCausado", iOtrosPagos.TOPSubsidioCausado.ToString("0.00"))
                                myXmlTextWriter.WriteEndElement()
                            ElseIf (iOtrosPagos.TOPSaldoAFavor > 0) Then
                                myXmlTextWriter.WriteStartElement("nomina12:CompensacionSaldosAFavor ")
                                myXmlTextWriter.WriteAttributeString("SaldoAFavor", iOtrosPagos.TOPSaldoAFavor.ToString("0.00"))
                                myXmlTextWriter.WriteAttributeString("Año", iOtrosPagos.TOPAnio)
                                myXmlTextWriter.WriteAttributeString("RemanenteSalFav", iOtrosPagos.TOPRemanenteSalFav.ToString("0.00"))
                                myXmlTextWriter.WriteEndElement()
                            End If
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If
                'ComplementoNomina/Incapacidades
                If Not lstIncapacidades Is Nothing Then
                    If lstIncapacidades.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("nomina12:Incapacidades")
                        For Each iIncapacidades In lstIncapacidades
                            myXmlTextWriter.WriteStartElement("nomina12:Incapacidad ")
                            myXmlTextWriter.WriteAttributeString("DiasIncapacidad", iIncapacidades.TIDiasIncapacidad)
                            myXmlTextWriter.WriteAttributeString("TipoIncapacidad", iIncapacidades.TITipoIncapacidad)
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If
                'ComplementoNomina/HorasExtra
                If Not lstHorasExtra Is Nothing Then
                    If lstHorasExtra.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("nomina12:HorasExtras")
                        For Each iHorasExtra In lstHorasExtra
                            myXmlTextWriter.WriteStartElement("nomina12:HorasExtra ")
                            myXmlTextWriter.WriteAttributeString("Dias", iHorasExtra.THEDias)
                            myXmlTextWriter.WriteAttributeString("HorasExtra", iHorasExtra.THEHorasExtra)
                            myXmlTextWriter.WriteAttributeString("TipoHoras", iHorasExtra.THETipoHoras)
                            myXmlTextWriter.WriteAttributeString("ImportePagado", iHorasExtra.THEImportePagado.ToString("0.00"))
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If

                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
                resultado = True
            End If
        Catch ex As Exception
            strMensaje = ex.Message
            Try
                myXmlTextWriter.Close()
            Catch exc As Exception

            End Try
        End Try

        Return resultado
    End Function

    Public Function actualizarDatosDelComplemento(ByVal usuarioId As Integer) As Entidades.TimbreNominaFiscal
        Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
        Dim doc As New XmlDocument()
        Dim Factura As XmlNode
        Dim nodo As XmlNode
        Dim TimbreFiscal As XmlNode
        Dim xmlmanager As System.Xml.XmlNamespaceManager
        Dim VersionComplemento As String = String.Empty

        Try
            doc.Load(rutaXml)
            xmlmanager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")

            Factura = doc.SelectSingleNode("cfdi:Comprobante", xmlmanager)
            nodo = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
            TimbreFiscal = nodo.SelectSingleNode("tfd:TimbreFiscalDigital", xmlmanager)

            VersionComplemento = TimbreFiscal.Attributes.GetNamedItem("Version").Value
            timNominaFiscal.TNFUuid = TimbreFiscal.Attributes.GetNamedItem("UUID").Value
            timNominaFiscal.TNFFechaTimbrado = TimbreFiscal.Attributes.GetNamedItem("FechaTimbrado").Value
            timNominaFiscal.TNFSelloSAT = TimbreFiscal.Attributes.GetNamedItem("SelloSAT").Value
            timNominaFiscal.TNFNoCertificadoSAT = TimbreFiscal.Attributes.GetNamedItem("NoCertificadoSAT").Value
            timNominaFiscal.TNFCadenaOriginalComplemento = "||" & VersionComplemento &
                "|" & timNominaFiscal.TNFUuid &
                "|" & timNominaFiscal.TNFFechaTimbrado &
                "|" & timNominaFiscal.TNFSello &
                "|" & timNominaFiscal.TNFNoCertificadoSAT & "||"
            timNominaFiscal.TNFUsuarioTimbroId = usuarioId

            timNominaFiscal.TNFMensajeError = objBU.actualizarInformacionTimbrado(timNominaFiscal)
        Catch ex As Exception
            timNominaFiscal.TNFMensajeError = ex.Message
        End Try

        Return timNominaFiscal
    End Function

    Public Function generarPdf(ByVal opcion As String) As Boolean
        Try
            Dim cantidadLetras As String = String.Empty
            Dim auxcantidadLetra() As String
            Dim rutaPdf As String = String.Empty
            Dim pdfSettings = New StiPdfExportSettings()
            Dim objBuReportes As New Framework.Negocios.ReportesBU
            Dim strReporte As String = String.Empty
            Dim EntidadReporte As New Entidades.Reportes

            Select Case timNominaFiscal.TNFTipo
                Case Is = "NÓMINA"
                    strReporte = "RECIBO_NOMINA_FISCAL"
                Case Is = "FINIQUITO"
                    strReporte = "RECIBO_NOMINA_FISCAL_FINIQUITO"
                Case Is = "AGUINALDO_VACACIONES"
                    strReporte = "RECIBO_NOMINA_FISCAL"
            End Select

            If opcion = "" Or opcion = "''" Then
                If timNominaFiscal.TNFCancelado Then
                    opcion = "CANCELACION"
                Else
                    opcion = "TIMBRADO"
                End If
            End If

            If opcion = "CANCELACION" Then
                strReporte = strReporte & "_CANC"
                If timNominaFiscal.TNFPdfCancelacion = "" Then
                    timNominaFiscal.TNFPdfCancelacion = timNominaFiscal.TNFPdf.Insert(timNominaFiscal.TNFPdf.Length - 4, "_CANCELADO")
                End If
                rutaPdf = rutas.RutaServicioRest & timNominaFiscal.TNFPdfCancelacion
            Else
                rutaPdf = rutas.RutaServicioRest & timNominaFiscal.TNFPdf
            End If

            EntidadReporte = objBuReportes.LeerReporteporClave(strReporte)
            Dim archivoReporte As String = "C:\PlantillasTimbrado\" & EntidadReporte.Pnombre & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivoReporte, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivoReporte)
            reporte.Compile()

            'Panel1:Encabezado
            reporte("NombrePatron") = timNominaFiscal.TNFEmisorRazonSocial.ToUpper
            reporte("RfcEmpresa") = timNominaFiscal.TNFEmisorRfc.ToUpper
            reporte("RegimenFiscal") = timNominaFiscal.TNFEmisorRegimenDescripcion.ToUpper
            reporte("LugarExpedicion") = timNominaFiscal.TNFLugarExpedicion.ToUpper
            reporte("CURP") = timNominaFiscal.TNFEmisorCurp.ToUpper
            reporte("RegistroPatronal") = timNominaFiscal.TNFRegistroPatronal.ToUpper
            reporte("Fecha") = timNominaFiscal.TNFFecha.ToString("dd/MMM/yyyy")
            reporte("Hora") = timNominaFiscal.TNFFecha.ToString("HH:mm:ss")
            reporte("Serie") = timNominaFiscal.TNFSerie.ToUpper
            reporte("Folio") = timNominaFiscal.TNFFolio
            If opcion = "CANCELACION" Then
                reporte("FechaHoraCancelacion") = timNominaFiscal.TNFFechaCancelacion.ToString("yyyy-MM-ddTHH:mm:ss")
            End If

            'Bloque1
            reporte("ClaveColaborador") = timNominaFiscal.TNFReceptorNumEmpleado.ToUpper
            reporte("NombreColaborador") = timNominaFiscal.TNFReceptorNombre.ToUpper
            reporte("RFCColaborador") = timNominaFiscal.TNFReceptorRfc.ToUpper
            reporte("CURPColaborador") = timNominaFiscal.TNFReceptorCurp.ToUpper
            reporte("FechaInicioRelacion") = timNominaFiscal.TNFReceptorFechaInicioRelLaboral.ToString("dd/MMM/yyyy")
            reporte("Jornada") = timNominaFiscal.TNFTipoJornadaPdf.ToUpper
            reporte("NSS") = timNominaFiscal.TNFReceptorNumSeguridadSocial.ToUpper
            reporte("TipoSalario") = timNominaFiscal.TNFSalario.ToUpper
            reporte("TipoContrato") = timNominaFiscal.TNFTipoContratoPdf.ToUpper
            reporte("TipoRegimen") = timNominaFiscal.TNFTipoRegimenPdf.ToUpper
            reporte("PeriodicidadPago") = timNominaFiscal.TNFPeriodicidadPagoPdf.ToUpper
            reporte("UsoCFDI") = timNominaFiscal.TNFUsoCfdiPdf.ToUpper
            reporte("ClaveEntFed") = timNominaFiscal.TNFClaveEntFedPdf.ToUpper
            reporte("Antiguedad") = timNominaFiscal.TNFReceptorAntiguedad.ToUpper

            'Bloque2
            reporte("TipoPeriodo") = timNominaFiscal.TNFTipoNominaPdf.ToUpper
            reporte("RangoPeriodo") = timNominaFiscal.TNFFechaInicialPago.ToString("dd/MMM/yyyy") & " - " & timNominaFiscal.TNFFechaFinalPago.ToString("dd/MMM/yyyy")
            reporte("DiasPago") = timNominaFiscal.TNFNumDiasPagados
            reporte("FechaPago") = timNominaFiscal.TNFFechaPago.ToString("dd/MMM/yyyy")
            'reporte("Puesto") = tmbNominaFiscal.TNFReceptorPuesto
            'reporte("Departamento") = tmbNominaFiscal.TNFReceptorDepartamento
            reporte("SDI") = timNominaFiscal.TNFReceptorSalarioDiarioIntegrado
            reporte("SalarioBaseCot") = timNominaFiscal.TNFReceptorSalarioBaseCotApor

            'Bloque3
            reporte("ClaveProdServ") = timNominaFiscal.TNFClaveProdServ.ToUpper
            reporte("Cantidad") = timNominaFiscal.TNFCantidad
            reporte("Unidad") = timNominaFiscal.TNFUnidad.ToUpper
            reporte("Descripcion") = timNominaFiscal.TNFDescripcion.ToUpper
            reporte("ValorUnitario") = timNominaFiscal.TNFValorUnitario

            'Panel2:Percepciones
            reporte("SumaPercepcionesGravado") = timNominaFiscal.TNFPercepcionesTotalGravado
            reporte("SumaPercepcionesExento") = timNominaFiscal.TNFPercepcionesTotalExento
            reporte("SumaPercepcionesTotal") = timNominaFiscal.TNFTotalPercepciones

            'Panel3:OtrasPercepciones
            reporte("SumaOtrasPercepcionesTotal") = timNominaFiscal.TNFTotalOtrosPagos
            reporte("TotalGravado") = timNominaFiscal.TNFPercepcionesTotalGravado
            reporte("TotalExento") = timNominaFiscal.TNFPercepcionesTotalExento
            reporte("TotalSuma") = timNominaFiscal.TNFTotalPercepciones + timNominaFiscal.TNFTotalOtrosPagos

            'Totales
            reporte("Subtotal") = timNominaFiscal.TNFSubTotal
            reporte("Descuentos") = timNominaFiscal.TNFDescuento - timNominaFiscal.TNFDeduccionesTotalImpuestosRet
            reporte("Retenciones") = timNominaFiscal.TNFDeduccionesTotalImpuestosRet
            reporte("Total") = timNominaFiscal.TNFTotal
            reporte("NetoRecibo") = timNominaFiscal.TNFTotal
            cantidadLetras = EnLetras(timNominaFiscal.TNFTotal).ToUpper
            auxcantidadLetra = Split(cantidadLetras, " CON ")
            If auxcantidadLetra.Length = 1 Then
                cantidadLetras = auxcantidadLetra(0) & " PESOS 00/100 M.N."
            Else
                cantidadLetras = auxcantidadLetra(0) & " PESOS " & auxcantidadLetra(1) & "/100 M.N."
            End If
            reporte("ImporteLetra") = cantidadLetras.ToUpper

            'Bloque4
            reporte("QR") = generaCodigoQR()
            reporte("SerieCertificadoEmisor") = timNominaFiscal.TNFNoCertificado
            reporte("UUID") = timNominaFiscal.TNFUuid
            reporte("SerieCertificadoSAT") = timNominaFiscal.TNFNoCertificadoSAT
            reporte("FechaHoraCertificacion") = timNominaFiscal.TNFFechaTimbrado.ToString("yyyy-MM-ddTHH:mm:ss")
            reporte("FormaPago") = timNominaFiscal.TNFFormaPagoPdf.ToUpper
            reporte("MetodoPago") = timNominaFiscal.TNFMetodoPagoPdf.ToUpper
            reporte("TipoComprobante") = timNominaFiscal.TNFTipoComprobantePdf.ToUpper
            reporte("Moneda") = timNominaFiscal.TNFMoneda.ToUpper

            'Bloque5
            If Not lstCfdiRelacionados Is Nothing Then
                reporte("TipoRelacion") = lstCfdiRelacionados(0).TCRTipoRelacion
                reporte("CfdiRelUUID") = lstCfdiRelacionados(0).TCRUuid
            End If

            'Pie
            reporte("SelloDigital") = timNominaFiscal.TNFSello
            reporte("SelloSAT") = timNominaFiscal.TNFSelloSAT
            reporte("CadenaOriginalComp") = timNominaFiscal.TNFCadenaOriginalComplemento


            '' G R I D   D E   P E R C E P C I O N E S
            Dim Percepciones = New DataTable("DSPercepciones")
            With Percepciones
                .Columns.Add("AgrupadorSAT")
                .Columns.Add("No")
                .Columns.Add("Concepto")
                .Columns.Add("Gravado")
                .Columns.Add("Exento")
                .Columns.Add("Total")
            End With

            If Not lstPercepciones Is Nothing Then
                For i As Integer = 0 To lstPercepciones.Count - 1
                    Percepciones.Rows.Add(
                        lstPercepciones(i).TPTipoPercepcion,
                        lstPercepciones(i).TPClavePercepcion,
                        lstPercepciones(i).TPConceptoPercepcion.ToUpper,
                        lstPercepciones(i).TPImporteGravadoPercepcion,
                        lstPercepciones(i).TPImporteExentoPercepcion,
                        lstPercepciones(i).TPImporteGravadoPercepcion + lstPercepciones(i).TPImporteExentoPercepcion
                    )
                Next
            End If


            '' G R I D   D E   O T R O S   P A G O S
            Dim OtrosPagos = New DataTable("DSOtrasPercepciones")
            With OtrosPagos
                .Columns.Add("AgrupadorSAT")
                .Columns.Add("No")
                .Columns.Add("Concepto")
                .Columns.Add("Gravado")
                .Columns.Add("Exento")
                .Columns.Add("Total")
            End With

            If Not lstOtrosPagos Is Nothing Then
                For i As Integer = 0 To lstOtrosPagos.Count - 1
                    OtrosPagos.Rows.Add(
                        lstOtrosPagos(i).TOPTipoOtrosPagos,
                        lstOtrosPagos(i).TOPClaveOtrosPagos,
                        lstOtrosPagos(i).TOPConceptoOtrosPagos.ToUpper,
                        0.0,
                        lstOtrosPagos(i).TOPImporteOtrosPagos,
                        lstOtrosPagos(i).TOPImporteOtrosPagos
                    )
                Next
            End If


            '' G R I D   D E   D E D U C C I O N E S
            Dim Deducciones = New DataTable("DSDeducciones")
            With Deducciones
                .Columns.Add("AgrupadorSAT")
                .Columns.Add("No")
                .Columns.Add("Concepto")
                .Columns.Add("Total")
            End With

            If Not lstDeducciones Is Nothing Then
                For i As Integer = 0 To lstDeducciones.Count - 1
                    Deducciones.Rows.Add(
                        lstDeducciones(i).TDTipoDeduccion,
                        lstDeducciones(i).TDClaveDeduccion,
                        lstDeducciones(i).TDConceptoDeduccion.ToUpper,
                        lstDeducciones(i).TFImporteDeduccion.ToString("F2")
                    )
                Next
            End If


            '' G R I D   D E   I N C A P A C I D A D E S
            Dim Incapacidades = New DataTable("DSIncapacidades")
            With Incapacidades
                .Columns.Add("dias")
                .Columns.Add("Tipo")
                .Columns.Add("Descuento")
            End With

            If Not lstIncapacidades Is Nothing Then
                For i As Integer = 0 To lstIncapacidades.Count - 1
                    Incapacidades.Rows.Add(
                        lstIncapacidades(i).TIDiasIncapacidad,
                        lstIncapacidades(i).TITipoDescripcion.ToUpper,
                        lstIncapacidades(i).TIDescuento
                    )
                Next
            End If


            Dim ds As New DataSet
            ds.DataSetName = "DSRecibo"
            ds.Tables.Add(Percepciones)
            ds.Tables.Add(OtrosPagos)
            ds.Tables.Add(Deducciones)
            ds.Tables.Add(Incapacidades)
            'reporte.Dictionary.Clear()
            reporte.RegData(ds)

            reporte.Render()
            reporte.ExportDocument(StiExportFormat.Pdf, rutaPdf, pdfSettings)
            reporte.Dispose()

            If opcion = "CANCELACION" Then
                Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
                objBU.actualizarRutaPdfCancelacion(timNominaFiscal.TNFTimbreNominaFiscalId, timNominaFiscal.TNFPdfCancelacion)
            End If

            Return True
        Catch ex As Exception
            strMensaje = ex.Message
            Return False
        End Try
    End Function

    Public Function generaCodigoQR() As String
        Dim codigo As String = String.Empty
        codigo = rutaQR
        codigo &= "&id=" & timNominaFiscal.TNFUuid.Trim
        codigo &= "&re=" & timNominaFiscal.TNFEmisorRfc.Trim
        codigo &= "&rr=" & timNominaFiscal.TNFReceptorRfc.Trim
        codigo &= "&tt=" & timNominaFiscal.TNFTotal
        codigo &= "&fe=" & timNominaFiscal.TNFSello.Substring(timNominaFiscal.TNFSello.Length - 8, 8).Trim
        Return codigo
    End Function

    Public Function EnLetras(numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        expresion = ""
        entero = ""
        deci = ""
        flag = ""

        flag = "N"
        For paso = 1 To Len(numero)
            If Mid(numero, paso, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                If paso = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "millón "
                    Else
                        expresion = expresion & "millones "
                    End If
                End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & "con " & deci ' & "/100"
                Else
                    EnLetras = expresion & "con " & deci ' & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = expresion
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function

    Public Function obtenerInformacionRA(ByVal timNominaFiscalID As Integer) As RespuestaRestArray
        Dim Respuesta As New RespuestaRestArray

        If obtenerInformacion(timNominaFiscalID) Then
            Respuesta.respuesta = 1
        End If
        Respuesta.aviso = strMensaje
        Respuesta.mensaje = Nothing

        Return Respuesta
    End Function

    Public Function generarPdfRA(ByVal timNominaFiscalId As Integer, ByVal opcion As String) As RespuestaRestArray
        Dim Respuesta As New RespuestaRestArray
        Dim RutasTimbrado(5) As String

        If obtenerInformacion(timNominaFiscalId) Then
            If generarPdf(opcion) Then
                Respuesta.respuesta = 1
                Respuesta.aviso = strMensaje
                RutasTimbrado(0) = rutas.RutaServicioRest
                RutasTimbrado(1) = rutas.RutaSICY
                RutasTimbrado(2) = rutas.RutaCliente
                RutasTimbrado(3) = rutas.RutaContabilidad

                If opcion = "" Or opcion = "''" Then
                    If timNominaFiscal.TNFCancelado Then
                        opcion = "CANCELACION"
                    Else
                        opcion = "TIMBRADO"
                    End If
                End If

                If opcion = "CANCELACION" Then
                    RutasTimbrado(4) = timNominaFiscal.TNFPdfCancelacion
                Else
                    RutasTimbrado(4) = timNominaFiscal.TNFPdf
                End If

                Respuesta.mensaje = RutasTimbrado
            Else
                Respuesta.respuesta = 0
                Respuesta.aviso = strMensaje
                Respuesta.mensaje = Nothing
            End If
        Else
            Respuesta.respuesta = 0
            Respuesta.aviso = strMensaje
            Respuesta.mensaje = Nothing
        End If

        Return Respuesta
    End Function

    Public Function cancelarRecibo(ByVal timNominaFiscalId As Integer, ByVal motivo As String, ByVal usuarioCancelo As Integer) As RespuestaRestArray
        Dim objTimbre As Negocios.TimbradoBU
        Dim objBU As New Contabilidad.Negocios.ReciboNominaBU
        Dim xmlCanc As String = String.Empty
        Dim resultado As String = String.Empty
        Dim Respuesta As New RespuestaRestArray
        Dim RutasTimbrado(6) As String
        Dim cancelacion As Boolean

        Try
            If obtenerInformacion(timNominaFiscalId) Then
                objTimbre = New Facturacion.Negocios.TimbradoBU(obtenerEmpresaId(timNominaFiscal.TNFPatronId), pruebas)

                timNominaFiscal.TNFMotivoCancelacion = motivo
                If timNominaFiscal.TNFTimbrado Then
                    xmlCanc = rutas.RutaServicioRest & timNominaFiscal.TNFXml
                    xmlCanc = xmlCanc.Insert(xmlCanc.Length - 4, "_CANCELADO")
                    timNominaFiscal.TNFXmlCancelacion = timNominaFiscal.TNFXml.Insert(timNominaFiscal.TNFXml.Length - 4, "_CANCELADO")

                    If pruebas Then
                        cancelacion = objTimbre.CancelacionFacturaPrueba(timNominaFiscal.TNFUuid, timNominaFiscal.TNFEmisorRfc, claveDocumento, xmlCanc)
                    Else
                        cancelacion = objTimbre.Cancelacion(timNominaFiscal.TNFUuid, timNominaFiscal.TNFEmisorRfc, claveDocumento, xmlCanc)
                    End If

                    If cancelacion Then
                        Dim doc As New XmlDocument()
                        Dim Factura As XmlNode
                        Dim NodoCancelacion As XmlNode

                        Dim FechaCancelacion As String = String.Empty
                        Dim EstatusCancelacionID As String = String.Empty
                        Dim DescripcionEstatusCancelacion As String = String.Empty
                        Dim splitDescripcionEstatusCancelacion() As String

                        doc.Load(xmlCanc)
                        Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
                        xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                        xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
                        Dim Fila As Integer = 0
                        Factura = doc.ChildNodes(0)
                        FechaCancelacion = Factura.Attributes.GetNamedItem("Fecha").Value
                        FechaCancelacion = FechaCancelacion.Replace(" ", "")

                        Dim nodo As XmlNode = Factura.ChildNodes(0)
                        NodoCancelacion = nodo.ChildNodes(0)

                        EstatusCancelacionID = nodo.ChildNodes.Item(1).InnerText ' NodoCancelacion.Attributes.GetNamedItem("UUIDEstatus").Value
                        splitDescripcionEstatusCancelacion = Split(nodo.ChildNodes.Item(2).InnerText, "-") 'Split(NodoCancelacion.Attributes.GetNamedItem("UUIDdescripcion").Value, "-")
                        DescripcionEstatusCancelacion = splitDescripcionEstatusCancelacion(1)

                        nodo = doc.ChildNodes(0).ChildNodes(0)
                        timNominaFiscal.TNFUuidCancelacion = timNominaFiscal.TNFUuid
                        timNominaFiscal.TNFFechaCancelacion = FechaCancelacion
                        timNominaFiscal.TNFPdfCancelacion = timNominaFiscal.TNFPdf.Insert(timNominaFiscal.TNFXml.Length - 4, "_CANCELADO")
                        timNominaFiscal.TNFUsuarioCancelo = usuarioCancelo

                        If objBU.actualizarCancelacionTimbrado(timNominaFiscal) = "EXITO" Then
                            If generarPdf("CANCELACION") Then

                            End If
                            resultado = "EXITO"
                        Else
                            resultado = "Error al actualizar los datos de cancelación"
                        End If
                    Else
                        resultado = objTimbre.mensaje
                    End If
                Else
                    timNominaFiscal.TNFFechaCancelacion = Date.Now
                    resultado = objBU.actualizarCancelacionTimbrado(timNominaFiscal)
                End If
            End If
        Catch ex As Exception
        End Try

        If resultado = "EXITO" Then
            Respuesta.respuesta = 1
            Respuesta.aviso = strMensaje
            RutasTimbrado(0) = rutas.RutaServicioRest
            RutasTimbrado(1) = rutas.RutaSICY
            RutasTimbrado(2) = rutas.RutaCliente
            RutasTimbrado(3) = rutas.RutaContabilidad
            RutasTimbrado(4) = timNominaFiscal.TNFXmlCancelacion
            RutasTimbrado(5) = timNominaFiscal.TNFPdfCancelacion
            Respuesta.mensaje = RutasTimbrado
        Else
            Respuesta.respuesta = 0
            Respuesta.aviso = resultado
            Respuesta.mensaje = Nothing
        End If

        Return Respuesta
    End Function
End Class