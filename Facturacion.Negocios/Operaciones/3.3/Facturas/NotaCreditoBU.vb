Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports Facturacion.Datos
Imports System.Xml
Imports System.Globalization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.IO
Imports Stimulsoft.Report
Imports Framework.Negocios
Imports ToolServicios



Public Class NotaCreditoBU

    Private _EntidadRutas As Entidades.RutasDocumentosFacturacion
    Public Property EntidadRutas() As Entidades.RutasDocumentosFacturacion
        Get
            Return _EntidadRutas
        End Get
        Set(ByVal value As Entidades.RutasDocumentosFacturacion)
            _EntidadRutas = value
        End Set
    End Property

    Public Sub New()
        _EntidadRutas = New Entidades.RutasDocumentosFacturacion
    End Sub

    Public Sub New(ByVal EmpresaID As Integer, ByVal TipoComprobante As Integer, ByVal TipoDocumento As String)
        Dim objUtilerias As New UtileriasFacturasBU
        _EntidadRutas = objUtilerias.ObtenerDirectorios(EmpresaID, TipoComprobante, TipoDocumento)
    End Sub

    Public Function Timbrar(ByVal sXML As String, ByVal ClaveTipoComprobante As String, ByVal UsuarioWS As String, ByVal pssWs As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As String
        Dim Resultado As String = String.Empty
        Dim MensajeError As String()
        Dim objDA As New DatosDocumentoDA

        Try
            Dim ws As New mx.com.paxfacturacion.test.wcfRecepcionASMX
            'Cliente.Credentials = New System.Net.NetworkCredential("Hector.GE8308", "Goe.Hector8308")
            Dim Archivo As Stream = File.Open(sXML, FileMode.Open)
            Dim Sr As StreamReader = New StreamReader(Archivo)
            Dim strXML As String = ""
            Dim strXMLTimbrado As String = ""

            strXML = Sr.ReadToEnd()
            'Quita el encabezado
            strXML = Replace(strXML, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?>", "")
            strXML = Replace(Mid(strXML, 1, Len(strXML)), (Chr(13) + Chr(10)), "")
            strXMLTimbrado = ws.fnEnviarXML(strXML, ClaveTipoComprobante, 0, UsuarioWS, pssWs, "3.3")
            Archivo.Close()

            If (strXMLTimbrado.Contains("<cfdi:Comprobante")) = True Then
                'Agrega nuevamente el encabezado
                strXML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?> " & strXMLTimbrado
                File.WriteAllText(sXML, strXML)
                Resultado = "XML Timbrado"
            Else
                Resultado = strXMLTimbrado
                MensajeError = Split(Resultado, "-")
                objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, MensajeError(0).ToString, MensajeError(1).ToString())
            End If

        Catch ex As Exception
            Resultado = "Error"
            Throw ex
        End Try
        Return Resultado
    End Function

    Private Function CrearXML(ByVal DocumentoId As Integer, ByVal TipoComprobante As String, ByVal EmpresaID As Integer, ByVal EsTimbradoPrueba As Boolean, ByVal RFCPrueba As String, ByVal VersionFacturacion As String) As String
        Dim RutaXML As String = String.Empty
        Dim Resultado As Integer = 0
        Dim objDA As New DatosDocumentoDA
        Dim comillas As String = """"
        Dim fechaEmision As String = DateTime.Now.ToString("yyy-MM-dd") & "T" & DateTime.Now.ToString("hh:mm:ss")
        Dim EmisorNombre As String = ""
        Dim EmisorRFC As String = ""
        Dim EmisorRegistroFiscal As String = ""
        Dim RutaKey As String = ""
        Dim WebServices As String = ""
        Dim UsuarioWebServices As String = ""
        Dim ContraseñaWebServices As String = ""
        Dim ContraseñaCertificado As String = ""
        Dim CertificadoVigenciaInicio As String = ""
        Dim RutaXMLCalzado As String = ""
        Dim RutaPDFCalzado As String = ""
        Dim CadenaCertificado As String = ""
        Dim NumeroCertificado As String = ""
        Dim ComDescuento As String = ""
        Dim Resultado2 As String = String.Empty
        Dim result As String = String.Empty
        Dim myXmlTextWriter As XmlTextWriter
        Dim index As Integer = 0

        'Datos del Comprobante
        Dim Folio As String = String.Empty
        Dim Fecha As String = String.Empty
        Dim FormaPago As String = String.Empty
        Dim NoCertificado As String = String.Empty
        Dim CondicionesDePago As String = String.Empty
        Dim SubTotal As String = String.Empty
        Dim Certificado As String = String.Empty
        Dim Moneda As String = String.Empty
        Dim Total As String = String.Empty
        Dim TipoDeComprobante As String = String.Empty
        Dim MetodoPago As String = String.Empty
        Dim LugarExpedicion As String = String.Empty
        Dim Descuento As String = String.Empty

        'Datos Conceptos
        Dim ConceptoImporte As String = String.Empty
        Dim ConceptoValorUnitario As String = String.Empty
        Dim ConceptoDescripcion As String = String.Empty
        Dim ConceptoUnidad As String = String.Empty
        Dim ConceptoClaveUnidad As String = String.Empty
        Dim ConceptoCantidad As String = String.Empty
        Dim ConceptoClaveProdServ As String = String.Empty
        Dim conceptoDescuento As String = String.Empty

        'Traslados conceptos
        Dim dtTraslado As DataTable
        Dim TrasladoClaveImpuesto As String = String.Empty
        Dim TrasladoImporte As String = String.Empty
        Dim TrasladoImpuesto As String = String.Empty
        Dim TrasladoTasaOCuota As String = String.Empty
        Dim TrasladoTipoFactor As String = String.Empty
        Dim TrasladoBase As String = String.Empty

        'Impuestos
        Dim list As New List(Of Double)
        Dim TotalTrasladoImporte As String = String.Empty
        Dim TotalTrasladoTasaOCuota As String = String.Empty
        Dim TotalTrasladoTipoFactor As String = String.Empty
        Dim TotalTrasladoImpuesto As String = String.Empty

        'Datos Receptor
        Dim UsoCFDI As String = String.Empty
        Dim NombreReceptor As String = String.Empty
        Dim RFC As String = String.Empty

        Dim DatosValidos As Boolean = True
        Dim ClaveCFDIRelacionado As String = String.Empty

        Try
            'Obtener Información Documento a Timbrar
            Dim dtEmpresa = objDA.getDatosEmpresa(EmpresaID)
            Dim dtDocumentoComprobante = objDA.getDatosDocumento(DocumentoId, "Comprobante", TipoComprobante)
            Dim dtDocumentoEmisor = objDA.getDatosDocumento(DocumentoId, "Emisor", TipoComprobante)
            Dim dtDocumentoReceptorImpuestosTrasladado = objDA.getDatosDocumento(DocumentoId, "Impuestos", TipoComprobante)
            Dim dtDocumentoReceptor = objDA.getDatosDocumento(DocumentoId, "Receptor", TipoComprobante)
            Dim dtDocumentoReceptorImpTrasladado = objDA.getDatosDocumento(DocumentoId, "Traslado", TipoComprobante)
            Dim dtDocumentoCfdiRelacionado = objDA.getDatosDocumento(DocumentoId, "CfdiRelacionados", TipoComprobante)

            Dim numConceptos = objDA.getDatosDocumentoNumConceptos(DocumentoId, TipoComprobante)
            Dim dtCFDIRelacionados As DataTable = objDA.ObtenerCFDIRelacionadosDocumento(DocumentoId, TipoComprobante)

            'Validar Datos
            If IsNothing(dtEmpresa) = True Then
                DatosValidos = False
            Else
                If dtEmpresa.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(dtDocumentoComprobante) = True Then
                DatosValidos = False
            Else
                If dtDocumentoComprobante.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(dtDocumentoEmisor) = True Then
                DatosValidos = False
            Else
                If dtDocumentoEmisor.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(dtDocumentoReceptorImpuestosTrasladado) = True Then
                DatosValidos = False
            Else
                If dtDocumentoReceptorImpuestosTrasladado.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(dtDocumentoReceptor) = True Then
                DatosValidos = False
            Else
                If dtDocumentoReceptor.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(dtDocumentoReceptorImpTrasladado) = True Then
                DatosValidos = False
            Else
                If dtDocumentoReceptorImpTrasladado.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If IsNothing(numConceptos) = True Then
                DatosValidos = False
            Else
                If numConceptos.Rows.Count = 0 Then
                    DatosValidos = False
                End If
            End If

            If DatosValidos = False Then
                Return ""
            End If

            For Each row As DataRow In dtEmpresa.Rows
                EmisorNombre = row("empr_nombre")
                EmisorRFC = row("empr_rfc")
                RutaKey = row("empr_rutakey")
                WebServices = row("empr_webservice")
                UsuarioWebServices = row("empr_usuariows")
                ContraseñaWebServices = row("empr_contrasenaws")
                ContraseñaCertificado = row("empr_contrasenacertificado")
                CertificadoVigenciaInicio = row("empr_certificadovigenciainicio")
                RutaXMLCalzado = row("empr_rutaxmlcalzado")
                RutaPDFCalzado = row("empr_rutapdfcalzado")
                CadenaCertificado = row("empr_cadenacertificado")
                NumeroCertificado = row("empr_numerocertificado")
                EmisorRegistroFiscal = row("empr_claveRegimen")
            Next

            Try
                RutaXML = ObtenerRutaCompletaXML(EmpresaID, EmisorRFC, dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault(), TipoComprobante)
                myXmlTextWriter = New XmlTextWriter(RutaXML, System.Text.Encoding.UTF8)
                myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)
                Dim Serie As String = String.Empty

                '--------------------------------Comprobante-------------------------------------------------------
                Folio = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Fecha = Date.Now.ToShortDateString 'dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                FormaPago = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                NoCertificado = NumeroCertificado
                'CondicionesDePago = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                SubTotal = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Certificado = CadenaCertificado
                Moneda = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Total = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                TipoDeComprobante = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "TipoDeComprobante").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                MetodoPago = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                LugarExpedicion = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "LugarExpedicion").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Descuento = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Descuento").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Serie = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

                myXmlTextWriter.WriteStartElement("cfdi:Comprobante")
                myXmlTextWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                myXmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                myXmlTextWriter.WriteAttributeString("Version", VersionFacturacion)
                myXmlTextWriter.WriteAttributeString("Serie", Serie)
                myXmlTextWriter.WriteAttributeString("Folio", Folio)
                myXmlTextWriter.WriteAttributeString("Fecha", fechaEmision)
                myXmlTextWriter.WriteAttributeString("FormaPago", FormaPago)
                myXmlTextWriter.WriteAttributeString("SubTotal", SubTotal)
                myXmlTextWriter.WriteAttributeString("Moneda", Moneda)
                myXmlTextWriter.WriteAttributeString("Total", Total)
                myXmlTextWriter.WriteAttributeString("TipoDeComprobante", TipoDeComprobante)
                myXmlTextWriter.WriteAttributeString("MetodoPago", MetodoPago)
                myXmlTextWriter.WriteAttributeString("LugarExpedicion", LugarExpedicion)
                myXmlTextWriter.WriteAttributeString("NoCertificado", NoCertificado)
                myXmlTextWriter.WriteAttributeString("Sello", "")
                myXmlTextWriter.WriteAttributeString("Certificado", Certificado)

                'If Descuento <> String.Empty Then
                '    If CDbl(Descuento) > 0 Then
                '        myXmlTextWriter.WriteAttributeString("Descuento", Descuento)
                '    End If

                'End If

                '----------------Documentos Relacionados
                If IsNothing(dtCFDIRelacionados) = False Then
                    If dtCFDIRelacionados.Rows.Count > 0 Then
                        myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionados")
                        ClaveCFDIRelacionado = dtDocumentoCfdiRelacionado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "TipoRelacion").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                        myXmlTextWriter.WriteAttributeString("TipoRelacion", ClaveCFDIRelacionado)
                        For Each FilaCFDI As DataRow In dtCFDIRelacionados.Rows
                            myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionado")
                            myXmlTextWriter.WriteAttributeString("UUID", FilaCFDI.Item("dore_valorXML"))
                            myXmlTextWriter.WriteEndElement()
                        Next
                        myXmlTextWriter.WriteEndElement()
                    End If
                End If


                '------------------------Datos del Emisor-----------------------------------
                myXmlTextWriter.WriteStartElement("cfdi:Emisor")
                myXmlTextWriter.WriteAttributeString("Rfc", EmisorRFC)
                myXmlTextWriter.WriteAttributeString("Nombre", EmisorNombre)
                myXmlTextWriter.WriteAttributeString("RegimenFiscal", EmisorRegistroFiscal)
                myXmlTextWriter.WriteEndElement()
                '---------------------------Datos del Receptor----------------------------------------
                UsoCFDI = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                NombreReceptor = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                RFC = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

                myXmlTextWriter.WriteStartElement("cfdi:Receptor")
                If EsTimbradoPrueba = True Then
                    myXmlTextWriter.WriteAttributeString("Rfc", RFCPrueba.Trim())
                Else
                    myXmlTextWriter.WriteAttributeString("Rfc", RFC.Trim())
                End If
                myXmlTextWriter.WriteAttributeString("Nombre", NombreReceptor)
                myXmlTextWriter.WriteAttributeString("UsoCFDI", UsoCFDI)
                myXmlTextWriter.WriteEndElement()

                '-----------------------Conceptos--------------------------
                myXmlTextWriter.WriteStartElement("cfdi:Conceptos")
                Dim NumeroConceptos As Integer = 0
                NumeroConceptos = numConceptos.Rows(0).Item(0)

                For Fila As Integer = 1 To NumeroConceptos
                    ConceptoImporte = String.Empty
                    ConceptoValorUnitario = String.Empty
                    ConceptoDescripcion = String.Empty
                    ConceptoUnidad = String.Empty
                    ConceptoClaveUnidad = String.Empty
                    ConceptoCantidad = String.Empty
                    ConceptoClaveProdServ = String.Empty
                    conceptoDescuento = String.Empty

                    Dim txtXmlConDescuento As String = ""
                    Dim dtConceptos = objDA.getDatosDocumentoConcepto(DocumentoId, Fila, "Concepto", TipoComprobante)

                    ConceptoImporte = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ConceptoImporte").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoValorUnitario = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ValorUnitario").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoDescripcion = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Descripcion").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Unidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoClaveUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveUnidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoCantidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Cantidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoClaveProdServ = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveProdServ").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    conceptoDescuento = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Descuento").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()


                    myXmlTextWriter.WriteStartElement("cfdi:Concepto")
                    myXmlTextWriter.WriteAttributeString("ClaveProdServ", ConceptoClaveProdServ)
                    myXmlTextWriter.WriteAttributeString("Cantidad", ConceptoCantidad)
                    myXmlTextWriter.WriteAttributeString("ClaveUnidad", ConceptoClaveUnidad)
                    myXmlTextWriter.WriteAttributeString("Unidad", ConceptoUnidad)
                    myXmlTextWriter.WriteAttributeString("Descripcion", ConceptoDescripcion)
                    myXmlTextWriter.WriteAttributeString("ValorUnitario", ConceptoValorUnitario)
                    myXmlTextWriter.WriteAttributeString("Importe", ConceptoImporte)


                    'If CDbl(conceptoDescuento) > 0 Then
                    '    myXmlTextWriter.WriteAttributeString("Descuento", conceptoDescuento)
                    'End If

                    '-------------------Traslados por Concepto------------------------
                    dtTraslado = objDA.getDatosDocumentoConcepto(DocumentoId, Fila, "Traslados", TipoComprobante)
                    TrasladoClaveImpuesto = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveImpuesto").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoImporte = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "TrasladoImporte").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoImpuesto = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Impuesto").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoTasaOCuota = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "TasaOCuota").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoTipoFactor = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "TipoFactor").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoBase = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Base").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()



                    myXmlTextWriter.WriteStartElement("cfdi:Impuestos")
                    myXmlTextWriter.WriteStartElement("cfdi:Traslados")
                    myXmlTextWriter.WriteStartElement("cfdi:Traslado")
                    myXmlTextWriter.WriteAttributeString("Base", TrasladoBase)
                    myXmlTextWriter.WriteAttributeString("Impuesto", TrasladoImpuesto)
                    myXmlTextWriter.WriteAttributeString("TipoFactor", TrasladoTipoFactor)
                    myXmlTextWriter.WriteAttributeString("TasaOCuota", TrasladoTasaOCuota)
                    myXmlTextWriter.WriteAttributeString("Importe", TrasladoImporte)

                    myXmlTextWriter.WriteEndElement()
                    myXmlTextWriter.WriteEndElement()
                    myXmlTextWriter.WriteEndElement()
                    myXmlTextWriter.WriteEndElement()

                Next



                myXmlTextWriter.WriteEndElement()

                '----------------------------Datos de Impuestos---------------------------------------


                TotalTrasladoImporte = dtDocumentoReceptorImpTrasladado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Importe").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                TotalTrasladoTasaOCuota = dtDocumentoReceptorImpTrasladado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "TasaOCuota").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                TotalTrasladoTipoFactor = dtDocumentoReceptorImpTrasladado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                TotalTrasladoImpuesto = dtDocumentoReceptorImpTrasladado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Impuesto").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()



                myXmlTextWriter.WriteStartElement("cfdi:Impuestos")
                myXmlTextWriter.WriteAttributeString("TotalImpuestosTrasladados", TotalTrasladoImporte)
                myXmlTextWriter.WriteStartElement("cfdi:Traslados")
                myXmlTextWriter.WriteStartElement("cfdi:Traslado")
                myXmlTextWriter.WriteAttributeString("Impuesto", TotalTrasladoImpuesto)
                myXmlTextWriter.WriteAttributeString("TipoFactor", TotalTrasladoTipoFactor)
                myXmlTextWriter.WriteAttributeString("TasaOCuota", TotalTrasladoTasaOCuota)
                myXmlTextWriter.WriteAttributeString("Importe", TotalTrasladoImporte)

                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()




            Catch ex As Exception
                If IsNothing(myXmlTextWriter) = False Then
                    myXmlTextWriter.Flush()
                    myXmlTextWriter.Close()
                End If
                RutaXML = String.Empty

                objDA.InsertarErrorAlTimbrar(DocumentoId, TipoComprobante, "NA", ex.Message.ToString())
            End Try
        Catch ex As Exception
            Console.Write(ex.Message.ToString())
            RutaXML = String.Empty
            objDA.InsertarErrorAlTimbrar(DocumentoId, TipoComprobante, "NA", ex.Message.ToString())
        End Try
        Return RutaXML
    End Function

    Public Function Timbrado(ByVal DocumentoID As Integer, ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TimbradoPrueba As Boolean) As RespuestaRestArray
        Dim RutaXML As String = String.Empty
        Dim CadenaOriginal As String = String.Empty
        Dim Sello As String = String.Empty
        Dim RutaXMLSello As String = String.Empty
        'Dim TipoComprobante As String = String.Empty
        Dim ClaveTipoComprobante As String = String.Empty
        Dim MensajeError As String = String.Empty
        Dim TipoError As String = String.Empty
        Dim InformacionValida As Boolean = True
        Dim SeAgregoSelloXML As Boolean = True
        Dim ErrorTotales As Boolean = False
        Dim ObjDA As New DatosDocumentoDA
        Dim Resultado As Boolean = True
        Dim respuesta As New RespuestaRestArray
        Dim RutaXmlServidor As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim objDAUtilleria As New UtileriasFacturasBU
        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, TimbradoPrueba)
            'Tipo de Comprobante
            'If ValidarTotalesDocumento(DocumentoID, TipoComprobante) = True Then
            If TipoComprobante = String.Empty Then
                MensajeError = "No se encuentra dato en TipoComprobante"
                InformacionValida = False
            Else
                'Clave de comprobante
                ClaveTipoComprobante = objTimbrado.ObtenerClaveTipoComprobante(TipoComprobante)
                If ClaveTipoComprobante = String.Empty Then
                    InformacionValida = False
                    MensajeError = "No se encuentra la Clave del tipo de comprobante."
                Else
                    'Generar XML
                    RutaXML = CrearXML(DocumentoID, TipoComprobante, objTimbrado._EntEmpresa.EmpresaID, TimbradoPrueba, objTimbrado.RFCPrueba, objTimbrado.VersionFacturacion.Trim())
                    If RutaXML = String.Empty Then
                        InformacionValida = False
                        MensajeError = "No se pudo generar el XML."
                    Else
                        'Generar la Cadena Original 
                        CadenaOriginal = objTimbrado.GenerarCadenaOriginal(RutaXML, DocumentoID, TipoComprobante)

                        If CadenaOriginal = String.Empty Then
                            InformacionValida = False
                            MensajeError = "No se pudo generar la cadena original."
                        Else
                            'Generar el Sello
                            Sello = objTimbrado.GeneraSello(RutaXML, CadenaOriginal, DocumentoID, TipoComprobante)
                            If Sello = String.Empty Then
                                InformacionValida = False
                                MensajeError = "No se pudo generar el sello."
                            Else
                                'Agregar el Sello al XML
                                SeAgregoSelloXML = objTimbrado.AgregarSelloXML(RutaXML, Sello)
                                'SeAgregoSelloXML = AgregarSelloXML(RutaXML, Sello, EmpresaID)
                                If SeAgregoSelloXML = False Then
                                    InformacionValida = False
                                    MensajeError = "Error al agregar el sello al XML."
                                Else

                                    'Timbrar el XML
                                    If objTimbrado.GenerarTimbrado(RutaXML, DocumentoID, TipoComprobante) = False Then
                                        InformacionValida = False
                                        MensajeError = "Error al timbrar el XML."
                                    Else
                                        objTimbrado.ObtenerDatosDelComplemento(DocumentoID, RutaXML, CadenaOriginal, TipoComprobante)
                                        RutaXmlServidor = _EntidadRutas.RutaSICY & Path.GetFileName(RutaXML)
                                        RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaXML)
                                        'RutaXmlServidor = CopiarArchivoXMLSICY(RutaXML, objTimbrado._EntEmpresa.EmpresaID)
                                        'RutaCliente = objDAUtilleria.CopiarArchivoCliente(RutaXML, objTimbrado._EntEmpresa.EmpresaID, "NOTACREDITO", "XML")
                                        MensajeError = "Exito se ha timbrado del XML."
                                        EliminarArchivosTemporales(objTimbrado.RutaArchivosTemp, DocumentoID, TipoComprobante)
                                        Rutas(0) = RutaXML
                                        Rutas(1) = RutaXmlServidor
                                        Rutas(2) = RutaCliente
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            'Else
            '    InformacionValida = False
            '    ErrorTotales = True
            'End If

            If InformacionValida = False And ErrorTotales = False Then
                ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
            End If
            respuesta.respuesta = IIf(InformacionValida = False, 0, 1)
            respuesta.aviso = MensajeError
            respuesta.mensaje = Rutas

        Catch ex As Exception
            MensajeError = ex.Message.ToString()
            InformacionValida = False
            ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", ex.Message.ToString())
            respuesta.respuesta = IIf(InformacionValida = False, 0, 1)
            respuesta.aviso = MensajeError
            respuesta.mensaje = Nothing
        End Try
        Return respuesta
    End Function

    Private Function ObtenerClaveTipoComprobante(ByVal TipoComprobante As String) As String
        Dim ClaveDocumento As String = String.Empty
        TipoComprobante = TipoComprobante.ToUpper().Trim()

        Select Case TipoComprobante
            Case "FACTURACALZADO"
                ClaveDocumento = "01"
            Case "NOTACREDITO"
                ClaveDocumento = "02"
            Case "NOTA DE CARGO"
                ClaveDocumento = "03"
            Case "RECIBO DE ARRENDAMIENTO"
                ClaveDocumento = "04"
            Case "CARTA PORTE"
                ClaveDocumento = "05"
            Case "RECIBO DE HONORARIOS"
                ClaveDocumento = "06"
            Case "COMPROBANTE DE PAGO"
                ClaveDocumento = "07"
            Case "RECIBO DE DONATIVOS"
                ClaveDocumento = "09"
            Case "RECIBO DE PAGO"
                ClaveDocumento = "10"
            Case "RECIBO DE NÓMINA"
                ClaveDocumento = "11"
            Case "SECTOR PRIMARIO"
                ClaveDocumento = "12"
            Case "RETENCIONES"
                ClaveDocumento = "13"
            Case Else
                ClaveDocumento = String.Empty

        End Select


        Return ClaveDocumento
    End Function


    Public Function ObtenerTipoComprobante(ByVal idDocumento As Integer) As String
        Dim objDA As New DatosDocumentoDA
        Dim dtinformacion As DataTable
        Dim TipoComprobante As String = String.Empty
        Try
            dtinformacion = objDA.ObtenerTipoComprobante(idDocumento)
            If dtinformacion.Rows.Count > 0 Then
                TipoComprobante = dtinformacion.Rows(0).Item(0)
            End If
            Return TipoComprobante
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ValidarTotalesDocumento(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim ObjDA As New DatosDocumentoDA
        Dim dtInformacion As DataTable
        Dim Resultado As Boolean = True
        Dim TotalDescuento As Double = 0
        Dim TotalDetalleDescuento As Double = 0
        Dim TotalSubtotal As Double = 0
        Dim TotalDetalleSubTotal As Double = 0
        Dim TotalTotal As Double = 0
        Dim TotalDetalleTotal As Double = 0
        Dim TotalIVA As Double = 0
        Dim TotalDetalleIVA As Double = 0
        Dim MensajeError As String = String.Empty


        Try
            dtInformacion = ObjDA.ObtenerTotalesDocumento(DocumentoID, TipoComprobante)
            If dtInformacion.Rows.Count > 0 Then
                TotalDescuento = dtInformacion.Rows(0).Item("EncabezadoDescuento")
                TotalDetalleDescuento = dtInformacion.Rows(0).Item("DetalleDescuento")
                TotalSubtotal = dtInformacion.Rows(0).Item("EncabezadoSubtotal")
                TotalDetalleSubTotal = dtInformacion.Rows(0).Item("DetalleSubTotal")
                TotalTotal = dtInformacion.Rows(0).Item("EncabezadoTotal")
                TotalDetalleTotal = dtInformacion.Rows(0).Item("DetalleTotal")
                TotalIVA = dtInformacion.Rows(0).Item("EncabezadoIVA")
                TotalDetalleIVA = dtInformacion.Rows(0).Item("DetalleIVA")

                If TotalDescuento <> TotalDetalleDescuento Then
                    Resultado = False
                    MensajeError = "El monto total del descuento no coincide con el monto total del detalle."
                    ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
                End If

                If TotalSubtotal <> TotalDetalleSubTotal Then
                    Resultado = False
                    MensajeError = "El monto SubTotal no coincide con el SubTotal del detalle."
                    ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
                End If

                If TotalTotal <> TotalDetalleTotal Then
                    Resultado = False
                    MensajeError = "El monto Total no coincide con el Total del detalle."
                    ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
                End If

                If TotalIVA <> TotalDetalleIVA Then
                    Resultado = False
                    MensajeError = "El monto del IVA no coincide con el Total del IVA del detalle."
                    ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
                End If

            End If

        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try

        Return Resultado

    End Function


    Private Function QuitarFormatoFecha(ByVal Fecha As String) As String
        Dim ResultadoFecha As DateTime
        Dim CadenaSplit As String()
        Dim FechaCompleto As String

        CadenaSplit = Split(Fecha, "T")
        FechaCompleto = Convert.ToDateTime(CadenaSplit(0) + " " + CadenaSplit(1))
        ResultadoFecha = Convert.ToDateTime(FechaCompleto.Replace("p.m.", "PM").Replace("a.m.", "AM"))
        FechaCompleto = ResultadoFecha.ToString("dd-MM-yyyy HH:mm:ss")

        Return FechaCompleto
    End Function

    ''' <summary>
    ''' Obtiene el documento en formato pdf que genera la funcion de timbrado
    ''' </summary>
    ''' <param name="idNotaCredito">Integer id de la nota de credito a timbrar.</param>
    ''' <remarks></remarks>
    Public Function GenerarPDF(ByVal idNotaCredito As Integer) As RespuestaRestArray
        Dim objDA As New DatosDocumentoDA
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dtDatosPdf As DataTable
        Dim Conceptos As New DataSet
        Dim dtConceptos As DataTable
        Dim dtRelacionados As DataTable
        Dim pdfSettings As New StiPdfExportSettings()
        Dim Respuesta As New RespuestaRestArray
        Dim DTInformacionFactura As DataTable
        Dim dtInformacionEmisor As DataTable
        Dim ObjPDF As New Facturacion.Negocios.ReportePDFBU
        Dim documentoID As Integer = idNotaCredito
        Dim TipoComprobante As String = "NOTACREDITO"
        Dim EmpresaID As Integer = 0
        Dim RFCEmpresa As String = String.Empty
        Dim Folio As String = String.Empty
        Dim RutaPDF As String = String.Empty
        Dim RutaPdfServidor As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim objDAUtilleria As New UtileriasFacturasBU
        Try
            If idNotaCredito > 0 Then
                dtInformacionEmisor = ObjPDF.ConsultarDatosEmisorReportePDF(documentoID, TipoComprobante)
                DTInformacionFactura = ObjPDF.ConsultarDatosEnzabezadoReportePDF(documentoID, TipoComprobante)
                'EntidadReporte = OBJBU.LeerReporteporClave("NOTA_DE_CREDITO_PDF")
                'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +  LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                Dim archivo As String = "C:\PlantillasTimbrado" + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                dtDatosPdf = objDA.ReporteDocTimbradoNotaDeCredito(1, idNotaCredito)
                dtConceptos = objDA.ReporteDocTimbradoNotaDeCredito(2, idNotaCredito)
                dtRelacionados = objDA.ReporteDocTimbradoNotaDeCredito(3, idNotaCredito)
                dtConceptos.TableName = "Conceptos"
                dtRelacionados.TableName = "Relacionados"
                Conceptos.Tables.Add(dtConceptos)
                Conceptos.Tables.Add(dtRelacionados)
                Conceptos.DataSetName = "Conceptos"
                'reporte("urlImagenNave") = "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG"
                'objDAUtilleria.ObtenerLogoEmpresa()
                '--------Encabezado
                reporte("serie") = dtDatosPdf.Rows(0).Item("Comprobante-Serie").ToString
                reporte("folio") = CInt(dtDatosPdf.Rows(0).Item("Comprobante-Folio"))
                reporte("fechaExpedicion") = dtDatosPdf.Rows(0).Item("Comprobante-Fecha").ToString
                reporte("uuid") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
                reporte("EmisorNombre") = dtDatosPdf.Rows(0).Item("Emisor-Nombre").ToString
                reporte("EmisorNombre") = dtDatosPdf.Rows(0).Item("Emisor-Nombre").ToString
                reporte("EmisorRFC") = dtDatosPdf.Rows(0).Item("Emisor-Rfc").ToString
                reporte("CURP") = dtDatosPdf.Rows(0).Item("Emisor-CURP").ToString
                reporte("EmisorCalleNum") = dtDatosPdf.Rows(0).Item("Emisor-CalleYnumero").ToString
                reporte("EmisorColoniaCP") = dtDatosPdf.Rows(0).Item("Emisor-ColoniaYCP").ToString
                reporte("EmisorTels") = dtDatosPdf.Rows(0).Item("Emisor-Telefonos").ToString
                reporte("EmisorMunEstadoPais") = dtDatosPdf.Rows(0).Item("Emisor-Ciudad").ToString
                reporte("ComprobanteLugarExpedicion") = dtDatosPdf.Rows(0).Item("Comprobante-LugarExpedicion").ToString

                reporte("Receptor") = dtDatosPdf.Rows(0).Item("Receptor-Nombre").ToString
                reporte("ReceptorCalleNumCol") = dtDatosPdf.Rows(0).Item("Receptor-Domicilio").ToString
                reporte("ReceptorMunEstadoPais") = dtDatosPdf.Rows(0).Item("Receptor-CiudadEstadoPais").ToString
                reporte("UsoCFDI") = dtDatosPdf.Rows(0).Item("Receptor-UsoCFDI").ToString
                reporte("ReceptorCP") = dtDatosPdf.Rows(0).Item("Receptor-CP").ToString
                reporte("ReceptorRFC") = dtDatosPdf.Rows(0).Item("Receptor-Rfc").ToString


                reporte("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
                reporte("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
                reporte("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
                reporte("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()


                'reporte("noCertificadoSAT") = dtDatosPdf.Rows(0).Item("Comprobante-Certificado").ToString
                'reporte("noCertificado") = dtDatosPdf.Rows(0).Item("Comprobante-NoCertificado").ToString
                'reporte("Regimen") = dtDatosPdf.Rows(0).Item("Emisor-RegimenFiscal").ToString
                'reporte("FechaTimbrado") = dtDatosPdf.Rows(0).Item("Comprobante-Fecha").ToString
                'reporte("MetodoPago") = dtDatosPdf.Rows(0).Item("Comprobante-MetodoPago").ToString
                'reporte("FormaPago") = dtDatosPdf.Rows(0).Item("Comprobante-FormaPago").ToString
                'reporte("Modeda") = dtDatosPdf.Rows(0).Item("Comprobante-Moneda").ToString

                '-------Pie de pagina
                reporte("TipoFactor") = dtDatosPdf.Rows(0).Item("Impuestos-TipoFactor").ToString
                reporte("TasaOCuota") = dtDatosPdf.Rows(0).Item("Impuestos-TasaOCuota").ToString
                reporte("TipoDeComprobante") = dtDatosPdf.Rows(0).Item("Comprobante-TipoDeComprobante").ToString
                reporte("CantidadLetra") = dtDatosPdf.Rows(0).Item("Comprobante-CantidadConLetra").ToString
                reporte("Subtotal") = dtDatosPdf.Rows(0).Item("Comprobante-Subtotal").ToString
                reporte("TotalDescuento") = dtDatosPdf.Rows(0).Item("Comprobante-TotalDescuento").ToString
                reporte("TotalImpuestosTrasladados") = dtDatosPdf.Rows(0).Item("Impuestos-TotalImpuestosTrasladados").ToString
                reporte("Total") = dtDatosPdf.Rows(0).Item("Comprobante-Total").ToString



                '--------Complemento
                'reporte("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginal")).FirstOrDefault
                reporte("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
                reporte("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
                reporte("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault

                Dim UUID As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
                Dim RFCEmisor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Dim RFCReceptor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Dim TotalComprobante As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Dim SelloDigital As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault

                reporte("CodigoQR") = GenerarQR(UUID.Trim, RFCEmisor.Trim, RFCReceptor.Trim, TotalComprobante.Trim, SelloDigital.Trim)
                reporte("RFCProveedor") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_rfcclaveproveedorcertificacion")).FirstOrDefault


                EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault
                RFCEmpresa = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Folio = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("rutaImagen") = objDAUtilleria.ObtenerLogoEmpresa(EmpresaID)
                reporte.Dictionary.Clear()
                reporte.RegData(Conceptos)
                reporte.Dictionary.Synchronize()
                'reporte.Show()
                reporte.Render()
                RutaPDF = ObtenerRutaCompletaPDF(EmpresaID, RFCEmpresa, Folio, TipoComprobante)
                reporte.ExportDocument(StiExportFormat.Pdf, RutaPDF)
                reporte.Dispose()
                RutaPdfServidor = _EntidadRutas.RutaSICY & Path.GetFileName(RutaPDF)
                RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(documentoID, RutaPDF, TipoComprobante, RutaPdfServidor)
                Rutas(0) = RutaPDF
                Rutas(1) = RutaPdfServidor
                Rutas(2) = RutaCliente
                Respuesta.respuesta = 1
                Respuesta.aviso = "El documento PDF Se genero correctamente"
                Respuesta.mensaje = Rutas

            End If
        Catch ex As Exception
            Respuesta.respuesta = 0
            Respuesta.aviso = ex.Message.ToString
            Respuesta.mensaje = Nothing
        Finally
            objDA = Nothing
            OBJBU = Nothing
            Conceptos = Nothing
            pdfSettings = Nothing
            dtDatosPdf = Nothing
            dtConceptos = Nothing
            dtRelacionados = Nothing
        End Try
        Return Respuesta

    End Function


    Public Function GenerarPDFCancelacion(ByVal idNotaCredito As Integer) As RespuestaRestArray
        Dim objDA As New DatosDocumentoDA
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dtDatosPdf As DataTable
        Dim Conceptos As New DataSet
        Dim dtConceptos As DataTable
        Dim dtRelacionados As DataTable
        Dim pdfSettings As New StiPdfExportSettings()
        Dim Respuesta As New RespuestaRestArray
        Dim DTInformacionFactura As DataTable
        Dim dtInformacionEmisor As DataTable
        Dim ObjPDF As New Facturacion.Negocios.ReportePDFBU
        Dim documentoID As Integer = idNotaCredito
        Dim TipoComprobante As String = "NOTACREDITO"
        Dim EmpresaID As Integer = 0
        Dim RFCEmpresa As String = String.Empty
        Dim Folio As String = String.Empty
        Dim RutaPDF As String = String.Empty
        Dim RutaPdfServidor As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim objDAUtilleria As New UtileriasFacturasBU
        Try
            If idNotaCredito > 0 Then
                dtInformacionEmisor = ObjPDF.ConsultarDatosEmisorReportePDF(documentoID, TipoComprobante)
                DTInformacionFactura = ObjPDF.ConsultarDatosEnzabezadoReportePDF(documentoID, TipoComprobante)
                EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault

                _EntidadRutas = ObtenerRutasTimbrado(EmpresaID, 2, "PDF")

                'EntidadReporte = OBJBU.LeerReporteporClave("NOTA_DE_CREDITO_PDF_CANCELADA")
                'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +  LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                Dim archivo As String = "C:\PlantillasTimbrado" + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                dtDatosPdf = objDA.ReporteDocTimbradoNotaDeCredito(1, idNotaCredito)
                dtConceptos = objDA.ReporteDocTimbradoNotaDeCredito(2, idNotaCredito)
                dtRelacionados = objDA.ReporteDocTimbradoNotaDeCredito(3, idNotaCredito)
                dtConceptos.TableName = "Conceptos"
                dtRelacionados.TableName = "Relacionados"
                Conceptos.Tables.Add(dtConceptos)
                Conceptos.Tables.Add(dtRelacionados)
                Conceptos.DataSetName = "Conceptos"




                'reporte("urlImagenNave") = "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG"
                '--------Encabezado
                reporte("serie") = dtDatosPdf.Rows(0).Item("Comprobante-Serie").ToString
                reporte("folio") = CInt(dtDatosPdf.Rows(0).Item("Comprobante-Folio"))
                reporte("fechaExpedicion") = dtDatosPdf.Rows(0).Item("Comprobante-Fecha").ToString
                reporte("uuid") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
                reporte("EmisorNombre") = dtDatosPdf.Rows(0).Item("Emisor-Nombre").ToString
                reporte("EmisorNombre") = dtDatosPdf.Rows(0).Item("Emisor-Nombre").ToString
                reporte("EmisorRFC") = dtDatosPdf.Rows(0).Item("Emisor-Rfc").ToString
                reporte("CURP") = dtDatosPdf.Rows(0).Item("Emisor-CURP").ToString
                reporte("EmisorCalleNum") = dtDatosPdf.Rows(0).Item("Emisor-CalleYnumero").ToString
                reporte("EmisorColoniaCP") = dtDatosPdf.Rows(0).Item("Emisor-ColoniaYCP").ToString
                reporte("EmisorTels") = dtDatosPdf.Rows(0).Item("Emisor-Telefonos").ToString
                reporte("EmisorMunEstadoPais") = dtDatosPdf.Rows(0).Item("Emisor-Ciudad").ToString
                reporte("ComprobanteLugarExpedicion") = dtDatosPdf.Rows(0).Item("Comprobante-LugarExpedicion").ToString

                reporte("Receptor") = dtDatosPdf.Rows(0).Item("Receptor-Nombre").ToString
                reporte("ReceptorCalleNumCol") = dtDatosPdf.Rows(0).Item("Receptor-Domicilio").ToString
                reporte("ReceptorMunEstadoPais") = dtDatosPdf.Rows(0).Item("Receptor-CiudadEstadoPais").ToString
                reporte("UsoCFDI") = dtDatosPdf.Rows(0).Item("Receptor-UsoCFDI").ToString
                reporte("ReceptorCP") = dtDatosPdf.Rows(0).Item("Receptor-CP").ToString
                reporte("ReceptorRFC") = dtDatosPdf.Rows(0).Item("Receptor-Rfc").ToString


                reporte("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
                reporte("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
                reporte("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
                reporte("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                reporte("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()


                'Datos Cancelacion
                reporte("FechaCancelacion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechacancelacion")).FirstOrDefault
                Dim DescripcionEstatusCancelacion As String = String.Empty
                DescripcionEstatusCancelacion = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_estatuscancelacionid")).FirstOrDefault
                DescripcionEstatusCancelacion &= "-" & DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_descripcionestatuscancelacion")).FirstOrDefault
                reporte("EstatusCancelacion") = DescripcionEstatusCancelacion


                'reporte("noCertificadoSAT") = dtDatosPdf.Rows(0).Item("Comprobante-Certificado").ToString
                'reporte("noCertificado") = dtDatosPdf.Rows(0).Item("Comprobante-NoCertificado").ToString
                'reporte("Regimen") = dtDatosPdf.Rows(0).Item("Emisor-RegimenFiscal").ToString
                'reporte("FechaTimbrado") = dtDatosPdf.Rows(0).Item("Comprobante-Fecha").ToString
                'reporte("MetodoPago") = dtDatosPdf.Rows(0).Item("Comprobante-MetodoPago").ToString
                'reporte("FormaPago") = dtDatosPdf.Rows(0).Item("Comprobante-FormaPago").ToString
                'reporte("Modeda") = dtDatosPdf.Rows(0).Item("Comprobante-Moneda").ToString

                '-------Pie de pagina
                reporte("TipoFactor") = dtDatosPdf.Rows(0).Item("Impuestos-TipoFactor").ToString
                reporte("TasaOCuota") = dtDatosPdf.Rows(0).Item("Impuestos-TasaOCuota").ToString
                reporte("TipoDeComprobante") = dtDatosPdf.Rows(0).Item("Comprobante-TipoDeComprobante").ToString
                reporte("CantidadLetra") = dtDatosPdf.Rows(0).Item("Comprobante-CantidadConLetra").ToString
                reporte("Subtotal") = dtDatosPdf.Rows(0).Item("Comprobante-Subtotal").ToString
                reporte("TotalDescuento") = dtDatosPdf.Rows(0).Item("Comprobante-TotalDescuento").ToString
                reporte("TotalImpuestosTrasladados") = dtDatosPdf.Rows(0).Item("Impuestos-TotalImpuestosTrasladados").ToString
                reporte("Total") = dtDatosPdf.Rows(0).Item("Comprobante-Total").ToString



                '--------Complemento
                'reporte("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginal")).FirstOrDefault
                reporte("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
                reporte("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
                reporte("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault

                Dim UUID As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
                Dim RFCEmisor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Dim RFCReceptor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Dim TotalComprobante As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                Dim SelloDigital As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault

                reporte("CodigoQR") = GenerarQR(UUID.Trim, RFCEmisor.Trim, RFCReceptor.Trim, TotalComprobante.Trim, SelloDigital.Trim)


                EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault
                RFCEmpresa = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                Folio = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
                RutaPDF = ObtenerRutaCompletaPDFCancelado(EmpresaID, RFCEmpresa, Folio, TipoComprobante)
                reporte("rutaImagen") = objDAUtilleria.ObtenerLogoEmpresa(EmpresaID)


                reporte.Dictionary.Clear()
                reporte.RegData(Conceptos)
                reporte.Dictionary.Synchronize()
                'reporte.Show()
                reporte.Render()
                reporte.ExportDocument(StiExportFormat.Pdf, RutaPDF)
                reporte.Dispose()
                RutaPdfServidor = _EntidadRutas.RutaSICY & Path.GetFileName(RutaPDF)
                RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(documentoID, RutaPDF, TipoComprobante, RutaPdfServidor)
                Rutas(0) = RutaPDF
                Rutas(1) = RutaPdfServidor
                Rutas(2) = RutaCliente
                Respuesta.respuesta = 1
                Respuesta.aviso = "El documento PDF Se genero correctamente"
                Respuesta.mensaje = Rutas

            End If
        Catch ex As Exception
            Respuesta.respuesta = 0
            Respuesta.aviso = ex.Message.ToString
            Respuesta.mensaje = Nothing
        Finally
            objDA = Nothing
            OBJBU = Nothing
            Conceptos = Nothing
            pdfSettings = Nothing
            dtDatosPdf = Nothing
            dtConceptos = Nothing
            dtRelacionados = Nothing
        End Try
        Return Respuesta

    End Function

    Public Function ObtenerRutaCompletaPDFCancelado(ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        'Directorio = ObtenerDirectorioPDFDocumento(EmpresaID, TipoComprobante)
        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If
        NombreArchivo = ObtenerNombreDocumentoPDFCancelado(RFCEmpresa, Folio)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function
    Private Function ObtenerNombreDocumentoPDFCancelado(ByVal RFCEmpresa As String, ByVal Folio As String) As String
        Dim NombreArchivoPDF As String = String.Empty
        NombreArchivoPDF = RFCEmpresa.Trim() & "F1NCR" & Folio.Trim & "_CANCELACION.pdf"
        Return NombreArchivoPDF
    End Function

    Private Function ConceptosDocumento(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As DataTable
        Dim dtConceptosDetalle As DataTable
        Dim dtConceptos As DataTable
        Dim objBU As New ReportePDFBU
        Dim ent As Entidades.ConceptosDocumento
        Dim DtNumeroConceptos As DataTable
        Dim objDA As New DatosDocumentoDA
        Dim NumeroConceptos As Integer = 0

        DtNumeroConceptos = objDA.getDatosDocumentoNumConceptos(DocumentoID, TipoComprobante)
        dtConceptos = objBU.ConsultarConceptosDocumento(DocumentoID, TipoComprobante)

        NumeroConceptos = DtNumeroConceptos.Rows(0).Item(0)

        dtConceptosDetalle = New DataTable("Conceptos")
        With dtConceptosDetalle
            .Columns.Add("ClaveProdServ")
            .Columns.Add("Cantidad")
            .Columns.Add("ClaveUnidad")
            .Columns.Add("Unidad")
            .Columns.Add("Descripcion")
            .Columns.Add("ValorUnitario")
            .Columns.Add("ConceptoImporte")
            .Columns.Add("Base")
            .Columns.Add("Impuesto")
            .Columns.Add("TrasladoImporte")
            .Columns.Add("Descuento")
        End With


        Dim index As Integer = 0
        For Fila = 0 To NumeroConceptos - 1
            ent = New Entidades.ConceptosDocumento
            index = Fila + 1

            ent.Base = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_atributo") = "Base").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.Cantidad = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_atributo") = "Cantidad").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.ClaveProductoServicio = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_atributo") = "ClaveProdServ").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.ClaveUnidad = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_atributo") = "ClaveUnidad").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.ConceptoImporte = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Concepto" And x.Item("dode_atributo") = "Importe").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.Descripcion = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Concepto" And x.Item("dode_atributo") = "Descripcion").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.Impuesto = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Traslado" And x.Item("dode_atributo") = "Impuesto").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.TrasladoImporte = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Traslado" And x.Item("dode_atributo") = "Importe").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.Unidad = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Concepto" And x.Item("dode_atributo") = "Unidad").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.ValorUnitario = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Concepto" And x.Item("dode_atributo") = "ValorUnitario").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()
            ent.Descuento = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "Concepto" And x.Item("dode_atributo") = "Descuento").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()

            dtConceptosDetalle.Rows.Add(ent.ClaveProductoServicio, ent.Cantidad, ent.ClaveUnidad, ent.Unidad, ent.Descripcion, ent.ValorUnitario, ent.ConceptoImporte, ent.Base, ent.Impuesto, ent.TrasladoImporte, ent.Descuento)
        Next

        Return dtConceptosDetalle

    End Function

    Private Function ObtenerNombreTipoComprobante(ByVal TipoComprobante As String) As String
        Dim Resultado As String = String.Empty
        Select Case TipoComprobante
            Case "I"
                Resultado = "INGRESO"
            Case Else
                Resultado = ""
        End Select
        Return Resultado
    End Function

    Private Function GenerarQR(ByVal UUID As String, ByVal RFCEmisor As String, ByVal RFCReceptor As String, ByVal TotalComprobante As String, ByVal SelloDigital As String) As String
        Dim ContenidoQR As String = String.Empty
        Dim URL As String = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?"
        ContenidoQR = URL + "&id=" & UUID.Trim()
        ContenidoQR &= "&re=" & RFCEmisor.Trim
        ContenidoQR &= "&rr=" & RFCReceptor.Trim
        ContenidoQR &= "&tt=" & TotalComprobante.Trim
        ContenidoQR &= "&fe=" & SelloDigital.Substring(SelloDigital.Length - 8, 8).Trim()

        Return ContenidoQR

    End Function

    Private Function ObtenerRutaDocumentoXML(ByVal EmpresaID As Integer, ByVal TipoComprobante As String) As String
        Dim ObjDA As New DatosDocumentoDA
        Dim dtRuta As DataTable
        Dim RutaXML As String = String.Empty

        dtRuta = ObjDA.ObtenerRutaArchivos(EmpresaID, TipoComprobante)

        If dtRuta.Rows.Count > 0 Then
            RutaXML &= dtRuta.Rows(0).Item("RutaXML")
        Else
            RutaXML = String.Empty
        End If

        Return RutaXML

    End Function

    Private Function ObtenerRutaPDF(ByVal EmpresaID As String, ByVal TipoComprobante As String) As String
        Dim ObjDA As New DatosDocumentoDA
        Dim dtRuta As DataTable
        Dim RutaPDF As String = String.Empty

        dtRuta = ObjDA.ObtenerRutaArchivos(EmpresaID, TipoComprobante)

        If dtRuta.Rows.Count > 0 Then
            RutaPDF &= dtRuta.Rows(0).Item("RutaPDF")
        Else
            RutaPDF = String.Empty
        End If

        Return RutaPDF
    End Function

    Public Function ObtenerDirectorioXMLDocumento(ByVal EmpresaID As Integer, ByVal TipoComprobante As String) As String
        Dim Directorio As String = String.Empty
        Dim RutaCompletaArchivo As String = String.Empty
        Dim FormatoFecha As String = String.Empty

        Directorio = ObtenerRutaDocumentoXML(EmpresaID, TipoComprobante)
        'Directorio &= "ADMINISTRACION/CONFIGURACIONEMPRESAS/AAA010101AAA/"

        If Directorio = String.Empty Then
            Return ""
        Else
            Directorio &= Date.Now.ToString("ddMMyyyy") & "/"

            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
        End If

        Return Directorio
    End Function

    Private Function ObtenerNombreDocumentoXML(ByVal RFCEmpresa As String, ByVal Folio As String) As String
        Dim NombreArchivoXML As String = String.Empty
        NombreArchivoXML = RFCEmpresa.Trim() & "F1NCR" & Folio.Trim & ".xml"
        Return NombreArchivoXML
    End Function

    Public Function ObtenerRutaCompletaXML(ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty
        Dim objUtileria As New UtileriasFacturasBU
        'Directorio = ObtenerDirectorioXMLDocumento(EmpresaID, TipoComprobante)
        NombreArchivo = ObtenerNombreDocumentoXML(RFCEmpresa, Folio)
        Directorio = _EntidadRutas.RutaServicioRest
        objUtileria.CrearDirectorio(Directorio)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

    Public Function ObtenerDirectorioPDFDocumento(ByVal EmpresaID As Integer, ByVal TipoComprobante As String) As String
        Dim Directorio As String = String.Empty
        Dim RutaCompletaArchivo As String = String.Empty
        Dim FormatoFecha As String = String.Empty

        Directorio = ObtenerRutaPDF(EmpresaID, TipoComprobante)
        'Directorio &= "ADMINISTRACION/CONFIGURACIONEMPRESAS/AAA010101AAA/"

        If Directorio = String.Empty Then
            Return ""
        Else
            Directorio &= Date.Now.ToString("ddMMyyyy") & "/"

            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
        End If

        Return Directorio
    End Function

    Private Function ObtenerNombreDocumentoPDF(ByVal RFCEmpresa As String, ByVal Folio As String) As String
        Dim NombreArchivoPDF As String = String.Empty
        NombreArchivoPDF = RFCEmpresa.Trim() & "F1NCR" & Folio.Trim & ".pdf"
        Return NombreArchivoPDF
    End Function

    Public Function ObtenerRutaCompletaPDF(ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        'Directorio = ObtenerDirectorioPDFDocumento(EmpresaID, TipoComprobante)
        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If
        NombreArchivo = ObtenerNombreDocumentoPDF(RFCEmpresa, Folio)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

    Private Sub EliminarArchivosTemporales(ByVal DirectorioArchivosTemporales As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String)
        Try
            If File.Exists(DirectorioArchivosTemporales & "ArchivoSello_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "ArchivoSello_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If

            If File.Exists(DirectorioArchivosTemporales & "ArchivoSHA_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "ArchivoSHA_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If

            If File.Exists(DirectorioArchivosTemporales & "CadenaOriginal_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "CadenaOriginal_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function CopiarArchivoXMLSICY(ByVal RutaXML As String, ByVal EmpresaID As Integer) As String
        Dim DirectorioXMLSICY As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New DatosDocumentoDA
        Dim FileName As String = String.Empty
        Try
            dtDirectorio = objDA.ObtenerRutaXMLSICY(EmpresaID)

            If dtDirectorio.Rows.Count > 0 Then
                DirectorioXMLSICY = dtDirectorio.Rows(0).Item(0)
                DirectorioXMLSICY &= Date.Now.ToString("MMyyyy") & "\"
                If System.IO.Directory.Exists(DirectorioXMLSICY) = False Then
                    'System.IO.Directory.CreateDirectory(DirectorioXMLSICY)
                End If

                FileName = Path.GetFileName(RutaXML)
                DirectorioXMLSICY &= FileName
            End If

            'File.Copy(RutaXML, DirectorioXMLSICY)
        Catch ex As Exception
            Throw ex
        End Try
        Return DirectorioXMLSICY
    End Function

    Private Function CopiarArchivoPDFSICY(ByVal RutaPDF As String, ByVal EmpresaID As Integer) As String
        Dim DirectorioPDFSICY As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New DatosDocumentoDA
        Dim FileName As String = String.Empty
        Try
            dtDirectorio = objDA.ObtenerRutaPDFSICY(EmpresaID)

            If dtDirectorio.Rows.Count > 0 Then
                DirectorioPDFSICY = dtDirectorio.Rows(0).Item(0)
                DirectorioPDFSICY &= Date.Now.ToString("MMyyyy") & "\"
                If System.IO.Directory.Exists(DirectorioPDFSICY) = False Then
                    '    System.IO.Directory.CreateDirectory(DirectorioPDFSICY)
                End If

                FileName = Path.GetFileName(RutaPDF)
                DirectorioPDFSICY &= FileName
            End If
            'If File.Exists(DirectorioPDFSICY) = True Then
            '    File.Delete(DirectorioPDFSICY)
            'End If
            'File.Copy(RutaPDF, DirectorioPDFSICY)
            'Shell("C:\CopiarArchivoApp\CopiarArchivo.exe " & RutaPDF & " " & DirectorioPDFSICY, AppWinStyle.MinimizedFocus, True, -1)
        Catch ex As Exception
            DirectorioPDFSICY = String.Empty
            Throw ex
        End Try
        Return DirectorioPDFSICY
    End Function

    Public Function TimbradoCancelacion(ByVal DocumentoID As Integer, ByVal UUID As String, ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TimbradoPrueba As Boolean, ByVal UsuarioID As Integer) As RespuestaRestArray
        Dim MensajeError As String = String.Empty
        Dim TipoError As String = String.Empty
        Dim InformacionValida As Boolean = True
        Dim ObjDA As New DatosDocumentoDA
        Dim ResultadoTimbradoCancelacion As Boolean = True
        Dim FechaCancelacion As String = String.Empty
        Dim UUID_Cancelar As String = String.Empty
        Dim Folio As String = String.Empty
        Dim RutaXMLCancelacion As String = String.Empty
        Dim entFacturaCancelada As New Entidades.FacturaCancelada
        Dim Respuesta As New RespuestaRestArray
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", "", "", "", ""}

        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, TimbradoPrueba)
            Folio = objTimbrado.ObtenerFolio_UUID(UUID, TipoComprobante)
            DocumentoID = objTimbrado.ObtenerDocumentoID_UUID(UUID, TipoComprobante)

            _EntidadRutas = ObtenerRutasTimbrado(EmpresaID, 2, "XML")
            RutaXMLCancelacion = ObtenerRutaCompletaCancelacionXML(objTimbrado._EntEmpresa.EmpresaID, objTimbrado._EntEmpresa.RFC, Folio, TipoComprobante)
            If TimbradoPrueba = True Then
                ResultadoTimbradoCancelacion = objTimbrado.CancelacionFacturaPrueba(UUID, objTimbrado.RFCPrueba, TipoComprobante, RutaXMLCancelacion)
            Else
                ResultadoTimbradoCancelacion = objTimbrado.Cancelacion(UUID, objTimbrado._EntEmpresa.RFC, TipoComprobante, RutaXMLCancelacion)
            End If
            'Obtiene los datos del complemento del xml generado de la cancelacion
            entFacturaCancelada = objTimbrado.ObtenerDatosDelComplementoCancelado(DocumentoID, RutaXMLCancelacion, TipoComprobante)
            Facturacion.Datos.DatosDocumentoDA.ActualizarDatosCancelacion(DocumentoID, TipoComprobante, entFacturaCancelada.FechaCancelacion, entFacturaCancelada.EstatusCancelacionID, entFacturaCancelada.DescripcionEstatusCancelacion)
            RutaServidorSICY = _EntidadRutas.RutaSICY & Path.GetFileName(RutaXMLCancelacion)
            RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaXMLCancelacion)

            If ResultadoTimbradoCancelacion = True Then
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se cancelo correctamente la factura."
                Rutas(0) = RutaXMLCancelacion
                Rutas(1) = RutaServidorSICY
                Rutas(2) = RutaCliente
                Rutas(3) = entFacturaCancelada.FechaCancelacion
                Rutas(4) = entFacturaCancelada.EstatusCancelacionID
                Rutas(5) = entFacturaCancelada.DescripcionEstatusCancelacion
                Respuesta.mensaje = Rutas
                'Si el timbrado de la cancelacion fue exitoso actualizar la informacion de la factura
                'ActualizarInformacionCancelacionFactura(DocumentoID, entFacturaCancelada.FechaCancelacion, UsuarioID)
            Else
                Respuesta.respuesta = 0
                Respuesta.aviso = "No se cancelo la factura."
                Respuesta.mensaje = Nothing
                'ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
            End If

        Catch ex As Exception
            MensajeError = ex.Message.ToString()
            InformacionValida = False
            Respuesta.respuesta = 0
            Respuesta.aviso = ex.Message.ToString()
            Respuesta.mensaje = Nothing
            ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", ex.Message.ToString())
        End Try

        Return Respuesta

    End Function


    Private Function ObtenerRutasTimbrado(ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String) As Entidades.RutasDocumentosFacturacion
        Dim objUtilerias As New UtileriasFacturasBU
        Dim Ent As Entidades.RutasDocumentosFacturacion
        Ent = objUtilerias.ObtenerDirectorios(EmpresaID, TipoComprobante, TipoDocumento)
        Return Ent
    End Function

    Public Function ObtenerRutaCompletaCancelacionXML(ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty
        'Dim objRutaCancelacion As New u

        'Directorio = ObtenerDirectorioXMLDocumento(EmpresaID, TipoComprobante)
        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = ObtenerNombreDocumentoXMLCancelado(RFCEmpresa, Folio)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function
    Private Function ObtenerNombreDocumentoXMLCancelado(ByVal RFCEmpresa As String, ByVal Folio As String) As String
        Dim NombreArchivoXML As String = String.Empty
        NombreArchivoXML = RFCEmpresa.Trim() & "F1NCR" & Folio.Trim & "_CANCELACION.xml"
        Return NombreArchivoXML
    End Function

    'Pendiente: esta funcion actualiza en el say de omar, para NC sera en sicy
    'Public Sub ActualizarInformacionCancelacionFactura(ByVal DocumentoID As Integer, ByVal FechaCancelacion As String, ByVal UsuarioCanceloID As Integer)
    '    Dim objDA As New FacturasDA
    '    objDA.ActualizarInformacionCancelacionFactura(DocumentoID, FechaCancelacion, UsuarioCanceloID)

    'End Sub
End Class
