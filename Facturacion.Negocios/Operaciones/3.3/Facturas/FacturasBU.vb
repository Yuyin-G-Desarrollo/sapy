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



Public Class FacturasBU

    Private _EntidadRutas As Entidades.RutasDocumentosFacturacion


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
        End Try
        Return Resultado
    End Function

    Private Function CrearXMLFactura(ByVal DocumentoId As Integer, ByVal TipoComprobante As String, ByVal EmpresaID As Integer, ByVal EsTimbradoPrueba As Boolean, ByVal RFCPrueba As String, ByVal VersionFacturacion As String) As String
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
        Dim Serie As String = String.Empty
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
            Dim dtDocumentoCfdiRelacionado = objDA.getDatosDocumento(DocumentoId, "CfdirRelacionados", TipoComprobante)

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

                RutaXML = ObtenerRutaCompletaXML(DocumentoId, EmpresaID, EmisorRFC, Folio, TipoComprobante, Serie)
                myXmlTextWriter = New XmlTextWriter(RutaXML, System.Text.Encoding.UTF8)
                myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)

                myXmlTextWriter.WriteStartElement("cfdi:Comprobante")
                myXmlTextWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                myXmlTextWriter.WriteAttributeString("Version", VersionFacturacion)
                myXmlTextWriter.WriteAttributeString("Folio", Folio)
                myXmlTextWriter.WriteAttributeString("Fecha", fechaEmision)
                myXmlTextWriter.WriteAttributeString("Sello", "")
                myXmlTextWriter.WriteAttributeString("FormaPago", FormaPago)
                myXmlTextWriter.WriteAttributeString("NoCertificado", NoCertificado)
                'myXmlTextWriter.WriteAttributeString("CondicionesDePago", "")
                myXmlTextWriter.WriteAttributeString("SubTotal", SubTotal)
                myXmlTextWriter.WriteAttributeString("Serie", Serie)
                myXmlTextWriter.WriteAttributeString("Certificado", Certificado)

                If Descuento <> String.Empty Then
                    If CDbl(Descuento) > 0 Then
                        myXmlTextWriter.WriteAttributeString("Descuento", Descuento)
                    End If

                End If

                myXmlTextWriter.WriteAttributeString("Moneda", Moneda)
                myXmlTextWriter.WriteAttributeString("Total", Total)
                myXmlTextWriter.WriteAttributeString("TipoDeComprobante", TipoDeComprobante)
                myXmlTextWriter.WriteAttributeString("MetodoPago", MetodoPago)
                myXmlTextWriter.WriteAttributeString("LugarExpedicion", LugarExpedicion)
                myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                myXmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

                '----------------Documentos Relacionados
                If IsNothing(dtCFDIRelacionados) = False Then
                    If dtCFDIRelacionados.Rows.Count > 0 Then

                        Dim dtClave = dtCFDIRelacionados.AsEnumerable().Where(Function(y) y.Item("dore_atributo") = "ClaveCFDI").Select(Function(x) x.Item("dore_valorXML")).Distinct()


                        For Each FilaClave As String In dtClave

                            ClaveCFDIRelacionado = FilaClave
                            myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionados")
                            myXmlTextWriter.WriteAttributeString("TipoRelacion", ClaveCFDIRelacionado)

                            Dim dtRenglon = dtCFDIRelacionados.AsEnumerable().Where(Function(x) x.Item("dore_valorXML") = ClaveCFDIRelacionado).Select(Function(y) y.Item("dore_rengloncfdirelacionadoid")).Distinct()
                            Dim UUID As String = String.Empty

                            For Each FilaRenglon As String In dtRenglon
                                UUID = dtCFDIRelacionados.AsEnumerable().Where(Function(x) x.Item("dore_atributo") = "UUID" And x.Item("dore_rengloncfdirelacionadoid") = FilaRenglon).Select(Function(y) y.Item("dore_valorXML")).FirstOrDefault()
                                myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionado")
                                myXmlTextWriter.WriteAttributeString("UUID", UUID)
                                myXmlTextWriter.WriteEndElement()
                            Next
                            myXmlTextWriter.WriteEndElement()

                        Next

                        'ClaveCFDIRelacionado = dtDocumentoCfdiRelacionado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Clave").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                        'myXmlTextWriter.WriteAttributeString("TipoRelacion", ClaveCFDIRelacionado)
                        'For Each FilaCFDI As DataRow In dtCFDIRelacionados.Rows
                        '    myXmlTextWriter.WriteStartElement("cfdi:CfdiRelacionado")
                        '    myXmlTextWriter.WriteAttributeString("UUID", FilaCFDI.Item("dore_valorXML"))
                        '    myXmlTextWriter.WriteEndElement()
                        'Next
                        'myXmlTextWriter.WriteEndElement()


                    End If
                End If


                '------------------------Datos del Emisor-----------------------------------
                myXmlTextWriter.WriteStartElement("cfdi:Emisor")
                'myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                myXmlTextWriter.WriteAttributeString("RegimenFiscal", EmisorRegistroFiscal)
                myXmlTextWriter.WriteAttributeString("Nombre", EmisorNombre)
                myXmlTextWriter.WriteAttributeString("Rfc", EmisorRFC)
                myXmlTextWriter.WriteEndElement()

                '---------------------------Datos del Receptor----------------------------------------
                UsoCFDI = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                NombreReceptor = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
                RFC = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

                myXmlTextWriter.WriteStartElement("cfdi:Receptor")
                myXmlTextWriter.WriteAttributeString("Nombre", NombreReceptor)
                If EsTimbradoPrueba = True Then
                    myXmlTextWriter.WriteAttributeString("Rfc", RFCPrueba.Trim())
                Else
                    myXmlTextWriter.WriteAttributeString("Rfc", RFC.Trim())
                End If

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

                    ConceptoImporte = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Importe").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoValorUnitario = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ValorUnitario").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoDescripcion = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Descripcion").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Unidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoClaveUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveUnidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoCantidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Cantidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    ConceptoClaveProdServ = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveProdServ").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    conceptoDescuento = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Descuento").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()


                    myXmlTextWriter.WriteStartElement("cfdi:Concepto")
                    myXmlTextWriter.WriteAttributeString("Importe", ConceptoImporte)
                    myXmlTextWriter.WriteAttributeString("ValorUnitario", ConceptoValorUnitario)
                    myXmlTextWriter.WriteAttributeString("Descripcion", ConceptoDescripcion)
                    myXmlTextWriter.WriteAttributeString("Unidad", ConceptoUnidad)
                    myXmlTextWriter.WriteAttributeString("ClaveUnidad", ConceptoClaveUnidad)
                    myXmlTextWriter.WriteAttributeString("Cantidad", ConceptoCantidad)
                    myXmlTextWriter.WriteAttributeString("ClaveProdServ", ConceptoClaveProdServ)

                    If CDbl(conceptoDescuento) > 0 Then
                        myXmlTextWriter.WriteAttributeString("Descuento", conceptoDescuento)
                    End If

                    '-------------------Traslados por Concepto------------------------
                    dtTraslado = objDA.getDatosDocumentoConcepto(DocumentoId, Fila, "Traslado", TipoComprobante)
                    TrasladoClaveImpuesto = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveImpuesto").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoImporte = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Importe").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoImpuesto = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Impuesto").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoTasaOCuota = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "TasaOCuota").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoTipoFactor = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "TipoFactor").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                    TrasladoBase = dtTraslado.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Base").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()

                    myXmlTextWriter.WriteStartElement("cfdi:Impuestos")
                    myXmlTextWriter.WriteStartElement("cfdi:Traslados")
                    myXmlTextWriter.WriteStartElement("cfdi:Traslado")
                    myXmlTextWriter.WriteAttributeString("Importe", TrasladoImporte)
                    myXmlTextWriter.WriteAttributeString("TasaOCuota", TrasladoTasaOCuota)
                    myXmlTextWriter.WriteAttributeString("TipoFactor", TrasladoTipoFactor)
                    myXmlTextWriter.WriteAttributeString("Impuesto", TrasladoClaveImpuesto)
                    myXmlTextWriter.WriteAttributeString("Base", TrasladoBase)
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
                TotalTrasladoImpuesto = dtDocumentoReceptorImpTrasladado.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "ClaveImpuesto").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

                myXmlTextWriter.WriteStartElement("cfdi:Impuestos")
                myXmlTextWriter.WriteAttributeString("TotalImpuestosTrasladados", TotalTrasladoImporte)
                myXmlTextWriter.WriteStartElement("cfdi:Traslados")
                myXmlTextWriter.WriteStartElement("cfdi:Traslado")
                myXmlTextWriter.WriteAttributeString("Importe", TotalTrasladoImporte)
                myXmlTextWriter.WriteAttributeString("TasaOCuota", TotalTrasladoTasaOCuota)
                myXmlTextWriter.WriteAttributeString("TipoFactor", TotalTrasladoTipoFactor)
                myXmlTextWriter.WriteAttributeString("Impuesto", TotalTrasladoImpuesto)
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
        Dim Respuesta As New RespuestaRestArray
        Dim Rutas() As String = {"", "", ""}
        Dim RutaXmlServidor As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim objutil As New UtileriasFacturasBU

        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, TimbradoPrueba)
            '_EntidadRutas = ObtenerRutasTimbrado(objTimbrado._EntEmpresa.EmpresaID, 1, "XML")
            Dim tipoDocumentoId As Integer = ObtenerTipoComprobanteId(TipoComprobante)
            _EntidadRutas = ObtenerRutasTimbrado(objTimbrado._EntEmpresa.EmpresaID, tipoDocumentoId, "XML")

            'Tipo de Comprobante
            ' TipoComprobante = ObtenerTipoComprobante(DocumentoID)
            'Validar Totales
            If ValidarTotalesDocumento(DocumentoID, TipoComprobante) = True Then
                If TipoComprobante = String.Empty Then
                    MensajeError = "Los Totales no coinciden"
                    InformacionValida = False
                Else
                    'Clave de comprobante
                    ClaveTipoComprobante = objTimbrado.ObtenerClaveTipoComprobante(TipoComprobante)
                    If ClaveTipoComprobante = String.Empty Then
                        InformacionValida = False
                        MensajeError = "No se encuentra la Clave del tipo de comprobante."
                    Else
                        'Generar XML
                        RutaXML = CrearXMLFactura(DocumentoID, TipoComprobante, objTimbrado._EntEmpresa.EmpresaID, TimbradoPrueba, objTimbrado.RFCPrueba, objTimbrado.VersionFacturacion.Trim())
                        If RutaXML = String.Empty Then
                            InformacionValida = False
                            MensajeError = "No se pudo generar el XML."
                        Else
                            'Generar la Cadena Original 

                            CadenaOriginal = objTimbrado.GenerarCadenaOriginal(RutaXML, DocumentoID, TipoComprobante)
                            'CadenaOriginal = GenerarCadenaOriginal(RutaXML)
                            If CadenaOriginal = String.Empty Then
                                InformacionValida = False
                                MensajeError = "No se pudo generar la cadena original."
                            Else
                                'Generar el Sello
                                Sello = objTimbrado.GeneraSello(RutaXML, CadenaOriginal, DocumentoID, TipoComprobante)
                                'Sello = GeneraSello(RutaXML, CadenaOriginal, DocumentoID, EmpresaID)
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
                                        'If TimbrarXML(RutaXML, ClaveTipoComprobante, usuarioWS, pssWS, DocumentoID, TipoComprobante) = False Then
                                        If objTimbrado.GenerarTimbrado(RutaXML, DocumentoID, TipoComprobante) = False Then
                                            InformacionValida = False
                                            MensajeError = "Error al timbrar el XML."
                                        Else
                                            objTimbrado.ObtenerDatosDelComplemento(DocumentoID, RutaXML, CadenaOriginal, TipoComprobante)
                                            'ObtenerDatosDelComplemento(DocumentoID, RutaXML, "", CadenaOriginal, EmpresaID)
                                            'CopiarArchivoXMLSICY(RutaXML, objTimbrado._EntEmpresa.EmpresaID)
                                            RutaXmlServidor = _EntidadRutas.RutaSICY & Path.GetFileName(RutaXML)
                                            RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaXML)
                                            'RutaXmlServidor = CopiarArchivoXMLSICY(RutaXML, objTimbrado._EntEmpresa.EmpresaID)
                                            'RutaCliente = objDAUtilleria.CopiarArchivoCliente(RutaXML, objTimbrado._EntEmpresa.EmpresaID, "NOTACREDITO", "XML")
                                            MensajeError = "Exito se ha timbrado del XML."
                                            EliminarArchivosTemporales(objTimbrado.RutaArchivosTemp, DocumentoID, TipoComprobante)
                                            Rutas(0) = RutaXML
                                            Rutas(1) = RutaXmlServidor
                                            Rutas(2) = RutaCliente
                                            'objutil.CrearDirectorio(Path.GetDirectoryName(RutaXmlServidor))
                                            'File.Copy(RutaXML, RutaXmlServidor, True)
                                            MensajeError = "Exito se ha timbrado del XML."
                                            EliminarArchivosTemporales(objTimbrado.RutaArchivosTemp, DocumentoID, TipoComprobante)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                InformacionValida = False
                ErrorTotales = True
            End If

            If InformacionValida = False And ErrorTotales = False Then
                ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", MensajeError)
            End If

            Respuesta.respuesta = IIf(InformacionValida = False, 0, 1)
            Respuesta.aviso = MensajeError
            Respuesta.mensaje = Rutas

        Catch ex As Exception
            MensajeError = ex.Message.ToString()
            InformacionValida = False
            Respuesta.respuesta = IIf(InformacionValida = False, 0, 1)
            Respuesta.aviso = MensajeError
            Respuesta.mensaje = Nothing
            ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", ex.Message.ToString())
        End Try

        Return Respuesta

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

    Public Function GenerarPDF(ByVal documentoID As Integer, ByVal TipoComprobante As String) As RespuestaRestArray
        Dim dtFiniquitoFiscal As New DataTable
        Dim dsOrdenTrabajo As New DataSet("dtOrdenTrabajo")
        Dim ReportePDFFactura As New StiReport
        Dim DTInformacionFactura As DataTable
        Dim objReporte As New ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim ObjPDF As New Facturacion.Negocios.ReportePDFBU
        Dim dtInformacionEmisor As DataTable
        Dim dtConceptos As DataTable
        Dim EmpresaID As Integer = 0
        Dim RFCEmpresa As String = String.Empty
        Dim Folio As String = String.Empty
        Dim Serie As String = String.Empty
        Dim RutaPDF As String = String.Empty
        Dim objDA As New DatosDocumentoDA
        Dim dtCFDIRelacionados As New DataTable
        Dim DSConceptos As New DataSet("Conceptos")
        Dim Resultado As Boolean = False
        Dim ListaCFDIRelacionados As New List(Of Entidades.CFDIRelacionadosDocumento)
        Dim Respuesta As New RespuestaRestArray()
        Dim RutaCliente As String = String.Empty
        Dim RutaSICY As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim RutaLogo As String = ""
        Dim objUtil As New UtileriasFacturasBU
        Dim dtNumeroReferencia As DataTable
        Dim TextoComprpbantePago As String = ""
        Dim Convenio As String = ""
        Dim Referencia As String = ""


        Try

            dtInformacionEmisor = ObjPDF.ConsultarDatosEmisorReportePDF(documentoID, TipoComprobante)
            DTInformacionFactura = ObjPDF.ConsultarDatosEnzabezadoReportePDF(documentoID, TipoComprobante)
            dtNumeroReferencia = ObjPDF.ObtenerNumeroReferenciaCliente(documentoID, TipoComprobante)

            '_EntidadRutas = ObtenerRutasTimbrado(DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault, 1, "PDF")
            Dim tipoDocumentoId As Integer = ObtenerTipoComprobanteId(TipoComprobante)
            _EntidadRutas = ObtenerRutasTimbrado(DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault, tipoDocumentoId, "PDF")
            EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault

            'Asignar el numero de referencia y convenio del cliente
            If IsNothing(dtNumeroReferencia) = False Then
                If dtNumeroReferencia.Rows.Count > 0 Then
                    TextoComprpbantePago = dtNumeroReferencia.Rows(0).Item(0).ToString
                    Referencia = dtNumeroReferencia.Rows(0).Item(1).ToString
                    Convenio = dtNumeroReferencia.Rows(0).Item(2).ToString
                End If
            End If

            'Descarga el Logo de la empresa
            RutaLogo = objUtil.ObtenerLogoEmpresa(EmpresaID)

            'Lista de CFDI Relacionados
            ListaCFDIRelacionados = ObjPDF.ObtenerCFDIRelacionados(documentoID, TipoComprobante)
            dtCFDIRelacionados.TableName = "Relacionados"
            dtCFDIRelacionados.Columns.Add("ClaveRelacion")
            dtCFDIRelacionados.Columns.Add("TipoRelacion")
            dtCFDIRelacionados.Columns.Add("CFDIRelacionado")

            For Each Item As Entidades.CFDIRelacionadosDocumento In ListaCFDIRelacionados
                dtCFDIRelacionados.Rows.Add(Item.ClaveCFDI, Item.TipoRelacion, Item.CFDIRelacionado)
            Next
            '----------------------------------------------------

            dtConceptos = ConceptosDocumento(documentoID, TipoComprobante)
            DSConceptos.Tables.Add(dtConceptos)
            DSConceptos.Tables.Add(dtCFDIRelacionados)
            'entReporte = objReporte.LeerReporteporClave("TMB_FACTURA")

            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '   LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            Dim archivo As String = "C:\PedidosMuestras" + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReportePDFFactura.Load(archivo)
            ReportePDFFactura.Compile()
            ReportePDFFactura.RegData(DSConceptos)


            ReportePDFFactura("Agente") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Agentes").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsuarioImprimio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "UsuarioGenera").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Docenas") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Docenas").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Pares") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TotalPares").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            Dim OrdenCompra As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim OrdenTienda As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("OrdenCompra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            If OrdenCompra = String.Empty Then
                ReportePDFFactura("EtiquetaOrden") = ""
            Else
                ReportePDFFactura("EtiquetaOrden") = "Orden"
            End If

            If OrdenTienda = String.Empty Then
                ReportePDFFactura("EtiquetaTienda") = ""
            Else
                ReportePDFFactura("EtiquetaTienda") = "TDA."
            End If


            ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            '            reporteUnaTienda("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
            '----------------------------Emisor-----------------
            ReportePDFFactura("EmisorNombre") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorRFC") = "R.F.C. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            If dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "CURP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault() <> String.Empty Then
                ReportePDFFactura("CURP") = "C.U.R.P. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "CURP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Else
                ReportePDFFactura("CURP") = ""
            End If


            ReportePDFFactura("EmisorCalleNum") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Calle y numero").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorColoniaCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Colonia y CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorTels") = "TELS. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Telefonos").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ComprobanteLugarExpedicion") = "LUGAR DE EXPEDICION:" & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "LugarExpedicion").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Datos Factura
            ReportePDFFactura("serie") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("folio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("fechaExpedicion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("FechaEmision")).FirstOrDefault
            'ReportePDFFactura("fechaExpedicion") = Date.Now.Year.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Day.ToString & " T " & Date.Now.ToString("HH:mm:ss")
            ReportePDFFactura("uuid") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
            ReportePDFFactura("Observaciones") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("Observaciones")).FirstOrDefault


            'Informacion Receptor
            ReportePDFFactura("Receptor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorCalleNumCol") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Domicilio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsoCFDI") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorRFC") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Informacion del Comprobante
            ReportePDFFactura("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
            ReportePDFFactura("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
            ReportePDFFactura("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
            ReportePDFFactura("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Dim tipo As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("TipoFactor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TasaOCuota") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TasaOCuota").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CantidadLetra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "TotalLetra").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Subtotal") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TotalDescuento") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Descuento").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TotalImpuestosTrasladados") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Impuestos" And x.Item("dota_atributo") = "TotalImpuestosTrasladados").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Total") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()



            ReportePDFFactura("TipoDeComprobante") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TipoDeComprobanteTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
            ReportePDFFactura("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
            ReportePDFFactura("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault
            ReportePDFFactura("RFCProveedorDeCertificacion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_rfcclaveproveedorcertificacion")).FirstOrDefault
            ReportePDFFactura("rutaImagen") = Replace(RutaLogo, "/", "\")


            ReportePDFFactura("TextoPagosBBVA") = TextoComprpbantePago
            ReportePDFFactura("Convenio") = Convenio
            ReportePDFFactura("Referencia") = Referencia

            '            ReportePDFFactura("rutaImagen") = "C:\ADMINISTRACION\CONFIGURACIONEMPRESAS\VIOR770525-8Y3\YUYIN.JPG"


            Dim UUID As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
            Dim RFCEmisor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim RFCReceptor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim TotalComprobante As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim SelloDigital As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault

            ReportePDFFactura("CodigoQR") = GenerarQR(UUID.Trim, RFCEmisor.Trim, RFCReceptor.Trim, TotalComprobante.Trim, SelloDigital.Trim)


            ReportePDFFactura.Dictionary.Clear()
            ReportePDFFactura.Dictionary.Synchronize()
            ReportePDFFactura.Render()
            'reporteUnaTienda.SaveDocument("C:\Documentos\factura2.pdf")
            'reporteUnaTienda.Show()


            RFCEmpresa = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Folio = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Serie = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            RutaPDF = ObtenerRutaCompletaPDF(documentoID, EmpresaID, RFCEmpresa, Folio, Serie, TipoComprobante)


            ReportePDFFactura.ExportDocument(StiExportFormat.Pdf, RutaPDF)
            Dim RutaPDFSICY As String = String.Empty

            If RutaPDF <> String.Empty Then

                RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
                RutaPDFSICY = _EntidadRutas.RutaSICY & Path.GetFileName(RutaPDF)

                Rutas(0) = RutaPDF
                Rutas(1) = RutaPDFSICY
                Rutas(2) = RutaCliente
                'objUtil.CrearDirectorio(Path.GetDirectoryName(RutaPDFSICY))
                'File.Copy(RutaPDF, RutaPDFSICY, True)

                'RutaPDFSICY = CopiarArchivoPDFSICY(RutaPDF, EmpresaID)
                'Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(documentoID, RutaPDF, TipoComprobante, RutaPDFSICY)
            End If

            If RutaPDF <> String.Empty Then
                Resultado = True
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se genero correctamente PDF."
                Respuesta.mensaje = Rutas
            Else
                Resultado = False
                Respuesta.respuesta = 2
                Respuesta.aviso = "No se genero correctamente PDF. RUTA PDF" & RutaPDF
                Respuesta.mensaje = Nothing
            End If

        Catch ex As Exception
            Dim MensajeErro As String = ""
            MensajeErro = ex.Message.ToString
            Resultado = False
            Respuesta.respuesta = 2
            Respuesta.aviso = ex.Message.ToString()
            Respuesta.mensaje = Nothing
        End Try

        Return Respuesta
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
            .Columns.Add("Estilo")
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
            ent.Estilo = dtConceptos.AsEnumerable().Where(Function(x) x.Item("dode_renglondocumentoid") = index And x.Item("dode_nodo") = "SOLO PDF" And x.Item("dode_atributo") = "Estilo").Select(Function(y) y.Item("dode_valorPDF")).FirstOrDefault()

            dtConceptosDetalle.Rows.Add(ent.ClaveProductoServicio, ent.Cantidad, ent.ClaveUnidad, ent.Unidad, ent.Descripcion, ent.Estilo, ent.ValorUnitario, ent.ConceptoImporte, ent.Base, ent.Impuesto, ent.TrasladoImporte, ent.Descuento)
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
        'Dim RutaXML As String = "C:\"
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
            Directorio &= Date.Now.ToString("ddMMyyyy") & "\"

            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
        End If

        Return Directorio
    End Function

    Public Function ObtenerRutaCompletaXML(ByVal DocumentoId As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String, ByVal Serie As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = _EntidadRutas.RutaServicioRest

        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(DocumentoId, RFCEmpresa, Folio, Serie, TipoComprobante, "XML", False)
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

    Public Function ObtenerRutaCompletaPDF(ByVal documentoID As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(documentoID, RFCEmpresa, Folio, Serie, TipoComprobante, "PDF", False)
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


    Private Sub CopiarArchivoXMLSICY(ByVal RutaXML As String, ByVal EmpresaID As Integer)
        Dim DirectorioXMLSICY As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New FacturasDA
        Dim FileName As String = String.Empty

        Try
            dtDirectorio = objDA.ObtenerRutaXMLSICY(EmpresaID)

            If dtDirectorio.Rows.Count > 0 Then
                DirectorioXMLSICY = dtDirectorio.Rows(0).Item(0)
                DirectorioXMLSICY &= Date.Now.ToString("MMyyyy") & "\"
                If System.IO.Directory.Exists(DirectorioXMLSICY) = False Then
                    System.IO.Directory.CreateDirectory(DirectorioXMLSICY)
                End If

                FileName = Path.GetFileName(RutaXML)
                DirectorioXMLSICY &= FileName
            End If

            File.Copy(RutaXML, DirectorioXMLSICY, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function CopiarArchivoPDFSICY(ByVal RutaPDF As String, ByVal EmpresaID As Integer) As String
        Dim DirectorioPDFSICY As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New FacturasDA
        Dim FileName As String = String.Empty

        Try
            dtDirectorio = objDA.ObtenerRutaPDFSICY(EmpresaID)

            If dtDirectorio.Rows.Count > 0 Then
                DirectorioPDFSICY = dtDirectorio.Rows(0).Item(0)
                DirectorioPDFSICY &= Date.Now.ToString("MMyyyy") & "\"
                If System.IO.Directory.Exists(DirectorioPDFSICY) = False Then
                    System.IO.Directory.CreateDirectory(DirectorioPDFSICY)
                End If

                FileName = Path.GetFileName(RutaPDF)
                DirectorioPDFSICY &= FileName
            End If

            If File.Exists(DirectorioPDFSICY) = True Then
                File.Delete(DirectorioPDFSICY)
            End If

            File.Copy(RutaPDF, DirectorioPDFSICY, True)
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
        Dim Serie As String = String.Empty
        Dim RutaXMLCancelacion As String = String.Empty
        Dim entFacturaCancelada As New Entidades.FacturaCancelada
        Dim Respuesta As New RespuestaRestArray
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim objutil As New UtileriasFacturasBU
        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, TimbradoPrueba)
            Folio = objTimbrado.ObtenerFolio_UUID(UUID, TipoComprobante)
            Serie = objTimbrado.ObtenerSerie_UUID(UUID, TipoComprobante)
            DocumentoID = objTimbrado.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            '_EntidadRutas = ObtenerRutasTimbrado(EmpresaID, 1, "XML")
            Dim tipoDocumentoId As Integer = ObtenerTipoComprobanteId(TipoComprobante)
            _EntidadRutas = ObtenerRutasTimbrado(EmpresaID, tipoDocumentoId, "XML")
            RutaXMLCancelacion = ObtenerRutaCompletaCancelacionXML(DocumentoID, objTimbrado._EntEmpresa.EmpresaID, objTimbrado._EntEmpresa.RFC.Trim, Folio, TipoComprobante, Serie)
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
                'objutil.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                'File.Copy(RutaXMLCancelacion, RutaServidorSICY, True)
                Respuesta.mensaje = Rutas
                'Si el timbrado de la cancelacion fue exitoso actualizar la informacion de la factura
                ActualizarInformacionCancelacionFactura(DocumentoID, entFacturaCancelada.FechaCancelacion, UsuarioID, TipoComprobante)
            Else
                Respuesta.respuesta = 0
                Respuesta.aviso = "No se cancelo la factura."
                Respuesta.mensaje = Nothing
                ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
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


    Public Function TimbradoCancelacion4_0(ByVal DocumentoID As Integer, ByVal UUID As String, ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TimbradoPrueba As Boolean, ByVal UsuarioID As Integer, ByVal Motivoid As String, ByVal FolioSustitucion As String) As RespuestaRestArray
        Dim MensajeError As String = String.Empty
        Dim TipoError As String = String.Empty
        Dim InformacionValida As Boolean = True
        Dim ObjDA As New DatosDocumentoDA
        Dim ResultadoTimbradoCancelacion As Boolean = True
        Dim FechaCancelacion As String = String.Empty
        Dim UUID_Cancelar As String = String.Empty
        Dim Folio As String = String.Empty
        Dim Serie As String = String.Empty
        Dim RutaXMLCancelacion As String = String.Empty
        Dim entFacturaCancelada As New Entidades.FacturaCancelada
        Dim Respuesta As New RespuestaRestArray
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim Rutas() As String = {"", "", ""}
        Dim objutil As New UtileriasFacturasBU
        Dim Mensaje() As String = {""}

        Dim dtResultadoTimbradoCancelacionSolicitud As New DataTable
        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, TimbradoPrueba)
            Folio = objTimbrado.ObtenerFolio_UUID(UUID, TipoComprobante)
            Serie = objTimbrado.ObtenerSerie_UUID(UUID, TipoComprobante)
            DocumentoID = objTimbrado.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            '_EntidadRutas = ObtenerRutasTimbrado(EmpresaID, 1, "XML")
            Dim tipoDocumentoId As Integer = ObtenerTipoComprobanteId(TipoComprobante)
            _EntidadRutas = ObtenerRutasTimbrado(EmpresaID, tipoDocumentoId, "XML")
            RutaXMLCancelacion = ObtenerRutaCompletaCancelacionXML(DocumentoID, objTimbrado._EntEmpresa.EmpresaID, objTimbrado._EntEmpresa.RFC.Trim, Folio, TipoComprobante, Serie)
            If TimbradoPrueba = True Then
                'ResultadoTimbradoCancelacion = objTimbrado.CancelacionFacturaPrueba(UUID, objTimbrado.RFCPrueba, TipoComprobante, RutaXMLCancelacion)
                dtResultadoTimbradoCancelacionSolicitud = objTimbrado.CancelacionFacturaPruebaSolicitud4_0(UUID, objTimbrado.RFCPrueba, TipoComprobante, RutaXMLCancelacion, Motivoid, FolioSustitucion)
            Else
                ResultadoTimbradoCancelacion = objTimbrado.Cancelacion(UUID, objTimbrado._EntEmpresa.RFC, TipoComprobante, RutaXMLCancelacion)
            End If
            'Obtiene los datos del complemento del xml generado de la cancelacion
            entFacturaCancelada = objTimbrado.ObtenerDatosDelComplementoCancelado(DocumentoID, RutaXMLCancelacion, TipoComprobante)
            Facturacion.Datos.DatosDocumentoDA.ActualizarDatosCancelacion(DocumentoID, TipoComprobante, entFacturaCancelada.FechaCancelacion, entFacturaCancelada.EstatusCancelacionID, entFacturaCancelada.DescripcionEstatusCancelacion)
            RutaServidorSICY = _EntidadRutas.RutaSICY & Path.GetFileName(RutaXMLCancelacion)
            RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaXMLCancelacion)

            ''pruebas Solicitud inicio
            If dtResultadoTimbradoCancelacionSolicitud.Rows(0).Item(0) = 1 Then
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se cancelo correctamente la factura."
                Rutas(0) = RutaXMLCancelacion
                Rutas(1) = RutaServidorSICY
                Rutas(2) = RutaCliente
                'objutil.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                'File.Copy(RutaXMLCancelacion, RutaServidorSICY, True)
                Respuesta.mensaje = Rutas
                'Si el timbrado de la cancelacion fue exitoso actualizar la informacion de la factura
                ActualizarInformacionCancelacionFactura(DocumentoID, entFacturaCancelada.FechaCancelacion, UsuarioID, TipoComprobante)
            Else
                Respuesta.respuesta = 0
                Respuesta.aviso = dtResultadoTimbradoCancelacionSolicitud.Rows(0).Item("Mensaje").ToString
                Mensaje(0) = "No se cancelo la factura."
                Respuesta.mensaje = Mensaje
                ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
            End If


            ''pruebas solicitud fin


            'If ResultadoTimbradoCancelacion = True Then
            '    Respuesta.respuesta = 1
            '    Respuesta.aviso = "Se cancelo correctamente la factura."
            '    Rutas(0) = RutaXMLCancelacion
            '    Rutas(1) = RutaServidorSICY
            '    Rutas(2) = RutaCliente
            '    'objutil.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
            '    'File.Copy(RutaXMLCancelacion, RutaServidorSICY, True)
            '    Respuesta.mensaje = Rutas
            '    'Si el timbrado de la cancelacion fue exitoso actualizar la informacion de la factura
            '    ActualizarInformacionCancelacionFactura(DocumentoID, entFacturaCancelada.FechaCancelacion, UsuarioID, TipoComprobante)
            'Else
            '    Respuesta.respuesta = 0
            '    Respuesta.aviso = "No se cancelo la factura."
            '    Respuesta.mensaje = Nothing
            '    ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
            'End If

        Catch ex As Exception
            MensajeError = ex.Message.ToString()
            InformacionValida = False
            Respuesta.respuesta = 0
            Respuesta.aviso = ex.Message.ToString()
            Respuesta.mensaje = Nothing
            ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", ex.Message.ToString())
            Facturacion.Datos.DatosDocumentoDA.ActualizarDatosCancelacion(DocumentoID, TipoComprobante, DateTime.Now.ToString("dd/MM/yyyy"), 167, ex.Message.ToString)
            ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
        End Try

        Return Respuesta

    End Function

    Public Function ObtenerRutaCompletaCancelacionXML(ByVal DocumentoID As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String, ByVal Serie As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(DocumentoID, RFCEmpresa, Folio, Serie, TipoComprobante, "XML", True)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

    Private Function ObtenerNombreDocumentoXMLCancelado(ByVal RFCEmpresa As String, ByVal Folio As String, ByVal Serie As String) As String
        Dim NombreArchivoXML As String = String.Empty
        NombreArchivoXML = RFCEmpresa.Trim() & "F1FAC" & Serie.Trim & Folio.Trim & "_CANCELACION.xml"
        Return NombreArchivoXML
    End Function


    Public Function GenerarPDFCancelacion(ByVal documentoID As Integer, ByVal TipoComprobante As String) As RespuestaRestArray
        Dim dtFiniquitoFiscal As New DataTable
        Dim dsOrdenTrabajo As New DataSet("dtOrdenTrabajo")
        Dim ReportePDFFactura As New StiReport
        Dim DTInformacionFactura As DataTable
        Dim objReporte As New ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim ObjPDF As New Facturacion.Negocios.ReportePDFBU
        Dim dtInformacionEmisor As DataTable
        Dim dtConceptos As DataTable
        Dim EmpresaID As Integer = 0
        Dim RFCEmpresa As String = String.Empty
        Dim Folio As String = String.Empty
        Dim Serie As String = String.Empty
        Dim RutaPDF As String = String.Empty
        Dim objDA As New DatosDocumentoDA
        Dim dtCFDIRelacionados As New DataTable
        Dim DSConceptos As New DataSet("Conceptos")
        Dim Resultado As Boolean = False
        Dim ListaCFDIRelacionados As New List(Of Entidades.CFDIRelacionadosDocumento)
        Dim Respuesta As New RespuestaRestArray()
        Dim Rutas() As String = {"", "", ""}
        Dim RutaCliente As String = String.Empty
        Dim RutaSICY As String = String.Empty
        Dim RutaLogo As String = ""
        Dim objUtil As New UtileriasFacturasBU


        Try

            dtInformacionEmisor = ObjPDF.ConsultarDatosEmisorReportePDF(documentoID, TipoComprobante)
            DTInformacionFactura = ObjPDF.ConsultarDatosEnzabezadoReportePDF(documentoID, TipoComprobante)
            EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault

            '_EntidadRutas = ObtenerRutasTimbrado(EmpresaID, 1, "PDF")
            Dim tipoDocumentoId As Integer = ObtenerTipoComprobanteId(TipoComprobante)
            _EntidadRutas = ObtenerRutasTimbrado(EmpresaID, tipoDocumentoId, "PDF")
            'Descarga el Logo de la empresa
            RutaLogo = objUtil.ObtenerLogoEmpresa(EmpresaID)

            'Lista de CFDI Relacionados
            ListaCFDIRelacionados = ObjPDF.ObtenerCFDIRelacionados(documentoID, TipoComprobante)
            dtCFDIRelacionados.TableName = "Relacionados"
            dtCFDIRelacionados.Columns.Add("ClaveRelacion")
            dtCFDIRelacionados.Columns.Add("TipoRelacion")
            dtCFDIRelacionados.Columns.Add("CFDIRelacionado")

            For Each Item As Entidades.CFDIRelacionadosDocumento In ListaCFDIRelacionados
                dtCFDIRelacionados.Rows.Add(Item.ClaveCFDI, Item.TipoRelacion, Item.CFDIRelacionado)
            Next
            '----------------------------------------------------

            Dim docenas As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Docenas").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()



            dtConceptos = ConceptosDocumento(documentoID, TipoComprobante)
            DSConceptos.Tables.Add(dtConceptos)
            DSConceptos.Tables.Add(dtCFDIRelacionados)
            ' entReporte = objReporte.LeerReporteporClave("TMB_FACTURA_CANCELADA")

            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '   LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            Dim archivo As String = "C:\PedidosMuestras" + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReportePDFFactura.Load(archivo)
            ReportePDFFactura.Compile()
            ReportePDFFactura.RegData(DSConceptos)

            '            reporteUnaTienda("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)

            ReportePDFFactura("Agente") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Agentes").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsuarioImprimio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "UsuarioGenera").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Docenas") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Docenas").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Pares") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TotalPares").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            Dim OrdenCompra As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim OrdenTienda As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("OrdenCompra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            If OrdenCompra = String.Empty Then
                ReportePDFFactura("EtiquetaOrden") = ""
            Else
                ReportePDFFactura("EtiquetaOrden") = "Orden"
            End If

            If OrdenTienda = String.Empty Then
                ReportePDFFactura("EtiquetaTienda") = ""
            Else
                ReportePDFFactura("EtiquetaTienda") = "TDA."
            End If


            ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()


            '----------------------------Emisor-----------------
            ReportePDFFactura("EmisorNombre") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorRFC") = "R.F.C. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CURP") = "C.U.R.P. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "CURP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorCalleNum") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Calle y numero").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorColoniaCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Colonia y CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorTels") = "TELS. " & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Telefonos").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("EmisorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ComprobanteLugarExpedicion") = "LUGAR DE EXPEDICION:" & dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "LugarExpedicion").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Datos Factura
            ReportePDFFactura("serie") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("folio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'reporteUnaTienda("fechaExpedicion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
            ReportePDFFactura("fechaExpedicion") = Date.Now.Year.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Day.ToString & " T " & Date.Now.ToString("HH:mm:ss")
            ReportePDFFactura("uuid") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault

            'Informacion Receptor
            ReportePDFFactura("Receptor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorCalleNumCol") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Domicilio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsoCFDI") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorRFC") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Informacion del Comprobante
            ReportePDFFactura("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
            ReportePDFFactura("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
            ReportePDFFactura("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
            ReportePDFFactura("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()


            'Datos Cancelacion
            ReportePDFFactura("FechaCancelacion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechacancelacion")).FirstOrDefault
            Dim DescripcionEstatusCancelacion As String = String.Empty
            DescripcionEstatusCancelacion = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_estatuscancelacionid")).FirstOrDefault
            DescripcionEstatusCancelacion &= "-" & DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_descripcionestatuscancelacion")).FirstOrDefault
            ReportePDFFactura("EstatusCancelacion") = DescripcionEstatusCancelacion


            'Dim tipo As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("TipoFactor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TasaOCuota") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TasaOCuota").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CantidadLetra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "TotalLetra").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Subtotal") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TotalDescuento") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Descuento").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("TotalImpuestosTrasladados") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Impuestos" And x.Item("dota_atributo") = "TotalImpuestosTrasladados").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Total") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            ReportePDFFactura("TipoDeComprobante") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TipoDeComprobanteTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
            ReportePDFFactura("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
            ReportePDFFactura("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault
            ReportePDFFactura("rutaImagen") = Replace(RutaLogo, "/", "\")

            Dim UUID As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_uuid")).FirstOrDefault
            Dim RFCEmisor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim RFCReceptor As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Dim TotalComprobante As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim SelloDigital As String = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault

            ReportePDFFactura("CodigoQR") = GenerarQR(UUID.Trim, RFCEmisor.Trim, RFCReceptor.Trim, TotalComprobante.Trim, SelloDigital.Trim)


            ReportePDFFactura.Dictionary.Clear()
            ReportePDFFactura.Dictionary.Synchronize()
            ReportePDFFactura.Render()
            'reporteUnaTienda.SaveDocument("C:\Documentos\factura2.pdf")
            'reporteUnaTienda.Show()


            RFCEmpresa = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Emisor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Folio = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            Serie = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            RutaPDF = ObtenerRutaCompletaPDFCancelado(documentoID, EmpresaID, RFCEmpresa, Folio, Serie, TipoComprobante)
            ReportePDFFactura.ExportDocument(StiExportFormat.Pdf, RutaPDF)


            RutaCliente = _EntidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
            RutaSICY = _EntidadRutas.RutaSICY & Path.GetFileName(RutaPDF)

            'If RutaPDF <> String.Empty Then
            '    RutaPDFSICY = CopiarArchivoPDFSICY(RutaPDF, EmpresaID)
            '    Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(documentoID, RutaPDF, TipoComprobante, RutaPDFSICY)
            'End If

            If RutaPDF <> String.Empty Then
                Resultado = True
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se genero correctamente PDF."
                Rutas(0) = RutaPDF
                Rutas(1) = RutaSICY
                Rutas(2) = RutaCliente
                'objUtil.CrearDirectorio(Path.GetDirectoryName(RutaSICY))
                'File.Copy(RutaPDF, RutaSICY, True)
                Respuesta.mensaje = Rutas
            Else
                Resultado = False
                Respuesta.respuesta = 0
                Respuesta.aviso = "No se genero correctamente PDF. RUTA PDF" & RutaPDF
                Respuesta.mensaje = Nothing
            End If

        Catch ex As Exception
            Dim MensajeErro As String = ""
            MensajeErro = ex.Message.ToString
            Resultado = False
            Respuesta.respuesta = 2
            Respuesta.aviso = ex.Message.ToString()
            Respuesta.mensaje = Nothing
        End Try

        Return Respuesta
    End Function


    Public Function ObtenerRutaCompletaPDFCancelado(ByVal idDocumento As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = _EntidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(idDocumento, RFCEmpresa, Folio, Serie, TipoComprobante, "PDF", True)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function


    Public Sub ActualizarInformacionCancelacionFactura(ByVal DocumentoID As Integer, ByVal FechaCancelacion As String, ByVal UsuarioCanceloID As Integer, ByVal TipoComprobante As String)
        Dim objDA As New FacturasDA
        objDA.ActualizarInformacionCancelacionFactura(DocumentoID, FechaCancelacion, UsuarioCanceloID, TipoComprobante)

    End Sub

    Public Sub ActualizarFacturaNoCancelada(ByVal DocumentoID As Integer, ByVal TipoComprobante As String)
        Dim objDA As New FacturasDA
        objDA.ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
    End Sub

    Private Function ObtenerRutasTimbrado(ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String) As Entidades.RutasDocumentosFacturacion
        Dim objUtilerias As New UtileriasFacturasBU
        Dim Ent As Entidades.RutasDocumentosFacturacion
        Ent = objUtilerias.ObtenerDirectorios(EmpresaID, TipoComprobante, TipoDocumento)
        Return Ent
    End Function

    Private Function ObtenerTipoComprobanteId(ByVal TipoComprobante As String) As Integer
        Try
            Dim objUtilerias As New UtileriasFacturasBU
            Return objUtilerias.ObtenerTipoComprobanteId(TipoComprobante)
        Catch es As Exception
            Return 1
        End Try
    End Function

    Public Sub cancelarfac(ByVal UUID As String)
        'Dim ws As New mx.com.paxfacturacion.wwwCanc.wcfCancelaASMX
        'Dim strXML As String = ""
        'Dim strXMLTimbrado As String = ""
        'Dim ListaUUID(0) As String
        'Dim ruta As String = String.Empty
        'Dim DirectorioCancelacion As String = String.Empty

        'ruta = "c:/fACTURAS/CANCELADO.XML"
        'ListaUUID(0) = UUID

        'ws.Timeout = 600000
        ''strXMLTimbrado = ws.fnCancelarXML(ListaUUID, RFCEmisor, 0, UsuarioWS, pssWS)
        'strXMLTimbrado = ws.fnCancelarXML(ListaUUID, "MOR140710KH3", 0, "Calzado.Orion", "woDCiMO7wrPDg8KuwonDq8O7xIMFVcK4woXCukMOaMKAw5DvvpERHe+/lu+/qu+9gO+9l+++me++lO+/kO+/qA==")

        ''If File.Exists(RutaXMLCancelacion) = False Then
        ''    File.Create(RutaXMLCancelacion)
        ''End If
        'DirectorioCancelacion = Path.GetDirectoryName(ruta)

        'If Directory.Exists(DirectorioCancelacion) = False Then
        '    Directory.CreateDirectory(DirectorioCancelacion)
        'End If

        'File.WriteAllText(ruta, strXMLTimbrado)

    End Sub


    Public Function EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal lstArchivosAdjuntos As List(Of System.Net.Mail.Attachment)) As Entidades.DatosCorreo
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim mDescripError As String = String.Empty
        Dim SeEnvioCorreo As Boolean = False
        Dim entCorreo As New Entidades.DatosCorreo

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        'smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl

            Dim listaDestinos() As String = Split(_To, ";")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        For Each adjunto As System.Net.Mail.Attachment In lstArchivosAdjuntos
                            _Message.Attachments.Add(adjunto)
                        Next
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()
                        ' .. si no hubo error
                        If Err.Number = 0 Then
                            SeEnvioCorreo = True
                            mDescripError = mDescripError & "Exito al enviar el correo"
                        ElseIf Err.Number = -2147220973 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->nombre del Servidor incorrecto o número de puerto incorrecto"
                        ElseIf Err.Number = -2147220974 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El transporte perdió la conexión al servidor"
                        ElseIf Err.Number = -2147220975 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->Error en el nombre de usuario, o en el password"
                        ElseIf Err.Number = -2147220977 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El servidor rechazó una o más direcciones de destinatarios"
                        ElseIf Err.Number = -2147220980 Then
                            mDescripError = mDescripError & "<->Se requiere al menos un destinatario, pero no se encontró ninguno"
                            SeEnvioCorreo = False
                        Else
                            mDescripError = mDescripError & "<->Error : " & Err.Number & vbNewLine & Err.Description
                            SeEnvioCorreo = False
                        End If

                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()

                    Finally
                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)
        Else
            'EnviarCorreoFacturasHtmlVariosArchivosAdjuntos = "No existe configuracion de smtp para " + From
            SeEnvioCorreo = False
            entCorreo.CorreoEnviado = SeEnvioCorreo
            entCorreo.Asunto = Asunto
            entCorreo.Destinatarios = _To
            entCorreo.From = From
            entCorreo.Mensaje = Mensaje
            entCorreo.DescripcionStatusCorreo = mDescripError
        End If

        Return entCorreo
    End Function

    Public Function enviarCorreoFacturacionCliente(ByVal IdDocumento As Integer) As RespuestaRestArray
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty

        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        'Dim objBU As New ventas. VistaPreviaDocumentosBU
        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim StatusCorreo As Boolean = False
        Dim Respuesta As New RespuestaRestArray()


        Try
            dtResultadoDatosCorreos = consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            dtDatosDocumento = consultaDatosDocumentoEnvioFactura(IdDocumento)


            folioFactura = dtDatosDocumento.Rows(0).Item("FolioFactura")
            nombreCliente = dtDatosDocumento.Rows(0).Item("NombreCliente")
            rutaArchivoPDF = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaPDF")), "", dtDatosDocumento.Rows(0).Item("RutaPDF"))
            rutaArchivoXML = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaXML")), "", dtDatosDocumento.Rows(0).Item("RutaXML"))
            correoCliente = dtDatosDocumento.Rows(0).Item("CorreoReceptor")

            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()

            'rutaArchivoPDF = "\\192.168.2.2\bin\TASFE\MafraMCV0902263W7\FACTURAS33\PDF\112017\MCV0902263W7F1FAC42781.pdf"
            'archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
            'lstArchivoAdjuntos.Add(archivoAdjunto)

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If correoCliente <> String.Empty Then
                If destinatarios <> String.Empty Then
                    destinatarios = destinatarios & "," & correoCliente
                Else
                    destinatarios = correoCliente
                End If
            End If

            asuntoCorreo = "FACTURA " + folioFactura + " CLIENTE " + nombreCliente + ""
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en facturación, ya sea por Razón Social, Domicilio Fiscal, Forma de Pago, Importe máximo de facturación etc. se realizará UNICAMENTE dentro de los primeros 7 días posteriores a la expedición de la factura; pasando este lapso de días no se harán cambios. </li>" +
                            "<li> En caso de errores en el domicilio fiscal solo verá reflejados los cambios en el archivo PDF, ya que de acuerdo a disposición del SAT en el archivo XML estos campos ya no existen. </li>" +
                            "<li> No se podrá hacer cancelaciones de facturas que ya hayan sido pagadas. </li>" +
                            "<li> No procederá la cancelación de un CFDI que se haya facturado conforme a los datos proporcionados por usted al momento de hacer su pedido. </li>" +
                            "<li> De acuerdo a lo establecido en la guía del llenado de los comprobantes fiscales del ""Anexo 20 SAT"" cuando la clave de uso registrada en el CFDI es incorrecta no será motivo de cancelación ni afectará para deducción o acreditamiento. Sin embargo, se recomienda que en el momento que se percaten del error soliciten su corrección para la siguiente facturación.</li>" +
                            "<li> No procederá hacer cancelaciones de cambios en la Clave del producto ya que está es asignada por la empresa que emite el CFDI, por lo tanto es nuestra responsabilidad que este indicada correctamente.</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

            If entCorreo.CorreoEnviado = True Then
                CorreoEnviado = "S"
                StatusCorreo = True
            Else
                CorreoEnviado = "N"
                StatusCorreo = False
            End If
            'Obtiene los datos de la factura
            'entDatosFactura = objTimbrado.ConsultarInformacionDocumentoFactura(IdDocumento)

            'Actualizar Status Correo Enviado SAY
            ActualizarStatusCorreoEnviadoSAY(IdDocumento, entCorreo.CorreoEnviado)

            'Insettar los datos de envio en el SICY
            If rutaArchivoPDF <> String.Empty Then
                InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, "SISTEMA", asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "PDF", False)
            End If

            If rutaArchivoXML <> String.Empty Then
                InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, "SISTEMA", asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "XML", False)
            End If


            If entCorreo.CorreoEnviado = True Then
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se envio correctamente el archivo."
                Respuesta.mensaje = Nothing
            Else
                Respuesta.respuesta = 2
                Respuesta.aviso = "No se envio correctamente el archivo."
                Respuesta.mensaje = Nothing
            End If


        Catch ex As Exception
            StatusCorreo = False
            Respuesta.respuesta = 2
            Respuesta.aviso = "No se envio correctamente el archivo."
            Respuesta.mensaje = Nothing
        End Try

        Return Respuesta

    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New FacturasDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function consultaDatosDocumentoEnvioFactura(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New FacturasDA
        Return objDA.consultaDatosDocumentoEnvioFactura(DocumentoId)
    End Function

    Public Sub InsertarDatosCorreoEnviadoSICY(ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoEnvio As String, ByVal RemisionId As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean)
        Dim objDA As New FacturasDA
        objDA.InsertarDatosCorreoEnviadoSICY(EnviadoA, Enviado, Usuario, Asunto, MotivoNoEnvio, RemisionId, TipoArchivo, Reenviado)
    End Sub

    Public Sub ActualizarStatusCorreoEnviadoSAY(ByVal DocumentoID As Integer, ByVal CorreoEnviado As Boolean)
        Dim objDA As New FacturasDA
        objDA.ActualizarStatusCorreoEnviadoSAY(DocumentoID, CorreoEnviado)
    End Sub

    Public Function InformacionCorreoEnvioFacturacion() As DataTable
        Dim objDA As New FacturasDA
        Dim dtRuta As DataTable
        Try
            dtRuta = objDA.InformacionCorreoEnvioFacturacion()
        Catch ex As Exception
            Throw ex
        End Try

        Return dtRuta
    End Function

    Public Function ReenvioCorreosFacturas(ByVal IdUnico As Integer, ByVal TipoDocumento As String) As RespuestaRestArray
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty

        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        'Dim objBU As New ventas. VistaPreviaDocumentosBU
        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim StatusCorreo As Boolean = False
        Dim Respuesta As New RespuestaRestArray()


        Try
            dtResultadoDatosCorreos = InformacionCorreoEnvioFacturacion()
            dtDatosDocumento = ObtenerInformacionCorreoFacturacion(IdUnico)


            folioFactura = dtDatosDocumento.Rows(0).Item("Serie")
            nombreCliente = dtDatosDocumento.Rows(0).Item("Cliente")
            rutaArchivoXML = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RUTAXML")), "", dtDatosDocumento.Rows(0).Item("RUTAXML"))
            rutaArchivoPDF = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RUTAPDF")), "", dtDatosDocumento.Rows(0).Item("RUTAPDF"))
            destinatarios = dtDatosDocumento.Rows(0).Item("Email")

            remitente = dtResultadoDatosCorreos.Rows(0).Item("EnvioCorreo").ToString()
            'destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()

            'rutaArchivoPDF = "\\192.168.2.2\bin\TASFE\MafraMCV0902263W7\FACTURAS33\PDF\112017\MCV0902263W7F1FAC42781.pdf"
            'archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
            'lstArchivoAdjuntos.Add(archivoAdjunto)

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If TipoDocumento = "NCR" Then
                asuntoCorreo = "NOTA CREDITO " + folioFactura + " CLIENTE " + nombreCliente + ""
            Else
                asuntoCorreo = "NOTA CARGO " + folioFactura + " CLIENTE " + nombreCliente + ""
            End If


            entCorreo = EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

            If entCorreo.CorreoEnviado = True Then
                CorreoEnviado = "S"
                StatusCorreo = True
            Else
                CorreoEnviado = "N"
                StatusCorreo = False
            End If


            'Insettar los datos de envio en el SICY
            If rutaArchivoPDF <> String.Empty Then
                InsertarLogMailDoctosElectronicos(IdUnico, destinatarios, CorreoEnviado, "SISTEMA", asuntoCorreo, entCorreo.DescripcionStatusCorreo, 0, "PDF", False)
            End If

            If rutaArchivoXML <> String.Empty Then
                InsertarLogMailDoctosElectronicos(IdUnico, destinatarios, CorreoEnviado, "SISTEMA", asuntoCorreo, entCorreo.DescripcionStatusCorreo, 0, "XML", False)
            End If


            If entCorreo.CorreoEnviado = True Then
                Respuesta.respuesta = 1
                Respuesta.aviso = "Se envio correctamente el archivo."
                Respuesta.mensaje = Nothing
                ActualizarDoctosElectronicos(IdUnico)

            Else
                Respuesta.respuesta = 2
                Respuesta.aviso = "No se envio correctamente el archivo."
                Respuesta.mensaje = Nothing
            End If


        Catch ex As Exception
            StatusCorreo = False
            Respuesta.respuesta = 2
            Respuesta.aviso = "No se envio correctamente el archivo."
            Respuesta.mensaje = Nothing
        End Try

        Return Respuesta

    End Function

    Public Function ObtenerInformacionCorreoFacturacion(ByRef IdUnico As Integer) As DataTable
        Dim objDA As New FacturasDA
        Dim dtRuta As DataTable
        Try
            dtRuta = objDA.ObtenerInformacionCorreoFacturacion(IdUnico)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtRuta
    End Function

    Public Function ActualizarDoctosElectronicos(ByRef IdUnico As Integer) As DataTable
        Dim objDA As New FacturasDA
        Dim dtRuta As DataTable
        Try
            dtRuta = objDA.ActualizarDoctosElectronicos(IdUnico)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtRuta
    End Function

    Public Function InsertarLogMailDoctosElectronicos(ByRef IdUnico As Integer, ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoenvio As String, ByVal remision As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean) As DataTable
        Dim objDA As New FacturasDA
        Dim dtRuta As DataTable
        Try
            dtRuta = objDA.InsertarLogMailDoctosElectronicos(IdUnico, EnviadoA, Enviado, Usuario, Asunto, MotivoNoenvio, remision, TipoArchivo, Reenviado)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtRuta
    End Function

    'Public Function copiarArchivos(ByVal rutaorigen As String, ByVal rutaDestino As String) As String
    '    Try
    '        File.Copy(rutaorigen, rutaDestino)
    '        Return "Se copio el archivo"
    '    Catch ex As Exception
    '        Return "No copio el archivo" + " " + ex.Message
    '    End Try
    'End Function

    Public Function getNombreDocumento(ByVal DocumentoID As Integer, ByVal RFC As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String, ByVal TipoDocumento As String, ByVal DocumentoCancelado As Boolean) As String
        Dim objDA As New FacturasDA
        Dim dtinformacion As DataTable
        Dim Resultado As String = String.Empty

        Try
            dtinformacion = objDA.getNombreDocumento(DocumentoID, RFC, Folio, Serie, TipoComprobante, TipoDocumento, DocumentoCancelado)
            If dtinformacion.Rows.Count > 0 Then
                Resultado = dtinformacion.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    Public Sub CancelarFacturaProductoTerminadoSICY(ByVal DocumentoID As Integer)
        Dim objDA As New FacturasDA
        Dim Resultado As String = String.Empty

        Try
            objDA.CancelarFacturaProductoTerminadoSICY(DocumentoID)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class
