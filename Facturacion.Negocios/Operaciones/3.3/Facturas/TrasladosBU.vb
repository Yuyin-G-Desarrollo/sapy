Imports System.IO
Imports System.Net
Imports System.Xml
Imports Facturacion.Datos
Imports Framework.Negocios
Imports Stimulsoft.Report
Imports Tools
Imports ToolServicios

Public Class TrasladosBU

    Private ReadOnly objFTP As New TransferenciaFTP
    Private ReadOnly objDA As New TrasladosDA
    Private ReadOnly objUtilerias As New UtileriasFacturasBU
    Private entidadRutas As Entidades.RutasDocumentosFacturacion

    Public Function GenerarPDFFactura(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim objUtilerias As New UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim EmpresaId As Integer = 0
        Dim RutaLogoEmpresa As String = String.Empty
        Dim EntFactura As New Entidades.DatosFactura
        Dim _Aviso As String = String.Empty

        Try

            EmpresaId = ObtenerEmpresaFactura(DocumentoID)
            RutaLogoEmpresa = ObtenerRutaLogoEmpresa(EmpresaId)

            ServicePointManager.SecurityProtocol = 3072
            'Servidor = "http://localhost:7639/"
            llamarServicio.url = Servidor & "Traslados/GeneraPDF?DocumentoID=" & DocumentoID.ToString & "&TipoComprobante=" & TipoComprobante.ToString
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaRest = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)

                'objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                'objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))

                'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente)

                RutaServidorSICY = RutaServidorSICY.Replace("\\192.168.2.156\", "ftp:\\192.168.2.158\")
                RutaServidorSICY = RutaServidorSICY.Replace("\", "/")
                TimbradoBU.ActualizarRutaPDFFactura(DocumentoID, RutaRest, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If

        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try

        Return Resultado

    End Function

    Public Function ObtenerEmpresaFactura(ByVal DocumentoID As Integer) As Integer
        Dim objDa As New Datos.TrasladosDA
        Dim dtinformacion As New DataTable
        Dim EmpresaID As Integer = 0

        dtinformacion = objDa.ObtenerEmpresaFactura(DocumentoID)

        If dtinformacion.Rows.Count > 0 Then
            EmpresaID = dtinformacion.Rows(0).Item("EmpresaID")
        Else
            EmpresaID = 0
        End If

        Return EmpresaID
    End Function

    Public Function ObtenerRutaLogoEmpresa(ByVal EmpresaID As Integer) As String
        Dim objDa As New Datos.TimbradoFacturasDA
        Dim dtinformacion As New DataTable
        Dim RutaLogo As String = String.Empty

        dtinformacion = objDa.ObtenerRutaLogoEmpresa(EmpresaID)

        If dtinformacion.Rows.Count > 0 Then
            RutaLogo = dtinformacion.Rows(0).Item("LogoEmpresa")
        Else
            RutaLogo = String.Empty
        End If

        Return RutaLogo
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

    Public Function ObtenerRutaCompletaPDF(ByVal documentoID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = entidadRutas.RutaServicioRest
        If Directory.Exists(Directorio) = False Then
            Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(documentoID, RFCEmpresa, Folio, Serie, TipoComprobante, "PDF", False)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

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

    Public Function GenerarPDF(documentoID As Integer, TipoComprobante As String) As RespuestaRestArray
        Dim dtFiniquitoFiscal As New DataTable
        Dim dsOrdenTrabajo As New DataSet("dtOrdenTrabajo")
        Dim ReportePDFFactura As New StiReport
        Dim DTInformacionFactura As DataTable
        Dim objReporte As New ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim ObjPDF As New ReportePDFBU
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
        Dim TextoComprpbantePago As String = ""
        Dim Convenio As String = ""
        Dim Referencia As String = ""


        Try

            dtInformacionEmisor = ObjPDF.ConsultarDatosEmisorReportePDF(documentoID, TipoComprobante)
            DTInformacionFactura = ObjPDF.ConsultarDatosEnzabezadoReportePDF(documentoID, TipoComprobante)
            'dtNumeroReferencia = ObjPDF.ObtenerNumeroReferenciaCliente(documentoID, TipoComprobante)

            '_EntidadRutas = ObtenerRutasTimbrado(DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault, 1, "PDF")
            Dim tipoDocumentoId As Integer = objUtilerias.ObtenerTipoComprobanteId(TipoComprobante)
            entidadRutas = objUtilerias.ObtenerDirectorios(DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault, tipoDocumentoId, "PDF")
            EmpresaID = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_empresaid")).FirstOrDefault

            'Asignar el numero de referencia y convenio del cliente
            'If IsNothing(dtNumeroReferencia) = False Then
            '    If dtNumeroReferencia.Rows.Count > 0 Then
            '        TextoComprpbantePago = dtNumeroReferencia.Rows(0).Item(0).ToString
            '        Referencia = dtNumeroReferencia.Rows(0).Item(1).ToString
            '        Convenio = dtNumeroReferencia.Rows(0).Item(2).ToString
            '    End If
            'End If

            'Descarga el Logo de la empresa
            RutaLogo = objUtil.ObtenerLogoEmpresa(EmpresaID)

            'Lista de CFDI Relacionados
            'ListaCFDIRelacionados = ObjPDF.ObtenerCFDIRelacionados(documentoID, TipoComprobante)
            'dtCFDIRelacionados.TableName = "Relacionados"
            'dtCFDIRelacionados.Columns.Add("ClaveRelacion")
            'dtCFDIRelacionados.Columns.Add("TipoRelacion")
            'dtCFDIRelacionados.Columns.Add("CFDIRelacionado")

            'For Each Item As Entidades.CFDIRelacionadosDocumento In ListaCFDIRelacionados
            '    dtCFDIRelacionados.Rows.Add(Item.ClaveCFDI, Item.TipoRelacion, Item.CFDIRelacionado)
            'Next
            '----------------------------------------------------

            dtConceptos = ConceptosDocumento(documentoID, TipoComprobante)
            DSConceptos.Tables.Add(dtConceptos)
            DSConceptos.Tables.Add(dtCFDIRelacionados)
            entReporte = objReporte.LeerReporteporClave("TMB_TRASLADO")

            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '   LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            Dim archivo As String = "C:\PedidosMuestras" + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReportePDFFactura.Load(archivo)
            ReportePDFFactura.Compile()
            ReportePDFFactura.RegData(DSConceptos)


            ReportePDFFactura("Agente") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Agentes").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsuarioImprimio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "UsuarioGenera").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Docenas") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Docenas").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Pares") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TotalPares").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Dim OrdenCompra As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'Dim OrdenTienda As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'ReportePDFFactura("OrdenCompra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'If OrdenCompra = String.Empty Then
            '    ReportePDFFactura("EtiquetaOrden") = ""
            'Else
            '    ReportePDFFactura("EtiquetaOrden") = "Orden"
            'End If

            'If OrdenTienda = String.Empty Then
            '    ReportePDFFactura("EtiquetaTienda") = ""
            'Else
            '    ReportePDFFactura("EtiquetaTienda") = "TDA."
            'End If


            'ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

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
            'ReportePDFFactura("Observaciones") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("Observaciones")).FirstOrDefault


            'Informacion Receptor
            'ReportePDFFactura("Receptor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorCalleNumCol") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Domicilio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsoCFDI") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorRFC") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Informacion del Comprobante
            ReportePDFFactura("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
            ReportePDFFactura("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
            ReportePDFFactura("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
            'ReportePDFFactura("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Dim tipo As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'ReportePDFFactura("TipoFactor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TasaOCuota") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TasaOCuota").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CantidadLetra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "TotalLetra").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Subtotal") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TotalDescuento") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Descuento").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TotalImpuestosTrasladados") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Impuestos" And x.Item("dota_atributo") = "TotalImpuestosTrasladados").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Total") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()



            ReportePDFFactura("TipoDeComprobante") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TipoDeComprobanteTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
            ReportePDFFactura("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
            ReportePDFFactura("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault
            ReportePDFFactura("RFCProveedorDeCertificacion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_rfcclaveproveedorcertificacion")).FirstOrDefault
            ReportePDFFactura("rutaImagen") = Replace(RutaLogo, "/", "\")


            'ReportePDFFactura("TextoPagosBBVA") = TextoComprpbantePago
            'ReportePDFFactura("Convenio") = Convenio
            'ReportePDFFactura("Referencia") = Referencia

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

            RutaPDF = ObtenerRutaCompletaPDF(documentoID, RFCEmpresa, Folio, Serie, TipoComprobante)


            ReportePDFFactura.ExportDocument(StiExportFormat.Pdf, RutaPDF)
            Dim RutaPDFSICY As String = String.Empty

            If RutaPDF <> String.Empty Then

                RutaCliente = entidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
                RutaPDFSICY = entidadRutas.RutaSICY & Path.GetFileName(RutaPDF)

                Rutas(0) = RutaPDF
                Rutas(1) = RutaPDFSICY
                Rutas(2) = RutaCliente
                'objUtil.CrearDirectorio(Path.GetDirectoryName(RutaPDFSICY))
                'File.Copy(RutaPDF, RutaPDFSICY, True)

                'CrearDirectorio(RutaPDFSICY)
                'File.Copy(RutaPDF, RutaPDFSICY, True)

                Dim caca = entidadRutas.RutaSICY.Replace("\\192.168.2.156\", "")
                objFTP.EnviarArchivo(caca.Substring(0, caca.Count - 1), RutaPDF)

                objFTP.DescargarArchivo(caca.Substring(0, caca.Count - 1), entidadRutas.RutaSICY.Substring(0, entidadRutas.RutaSICY.Count - 1), Path.GetFileName(RutaPDF))

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



    Public Function GenerarInformacionTimbrado(folioEmbarque As Integer, Emisor As Integer, Salida As Boolean) As DataTable
        Return objDA.GenerarInformacionTimbrado(folioEmbarque, Emisor, Salida)
    End Function

    Public Function TimbrarFactura(DocumentoID As Integer, EmpresaId As Integer, TipoComprobante As String) As Boolean
        Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New UtileriasFacturasBU
        Dim entFactura As New Entidades.DatosFactura
        Dim _Aviso As String = String.Empty
        Try
            ServicePointManager.SecurityProtocol = 3072
            'Servidor = "http://localhost:7639/"
            llamarServicio.url = Servidor & "Traslados/Timbrado?DocumentoID=" & DocumentoID.ToString & "&EmpresaID=" & EmpresaId & "&TipoComprobante=" & TipoComprobante.Trim() & "&Usuario=" & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True

                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)

                'objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                'objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))

                'objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                RutaServidorSICY = RutaServidorSICY.Replace("\\192.168.2.156\", "ftp:\\192.168.2.158\")
                RutaServidorSICY = RutaServidorSICY.Replace("\", "/")
                TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If
        Catch ex As Exception
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return Resultado
    End Function

    Public Function Timbrado(DocumentoID As Integer, EmpresaID As Integer, TipoComprobante As String, Usuario As Integer) As RespuestaRestArray
        Dim MensajeError As String = String.Empty
        Dim InformacionValida As Boolean = True
        Dim Rutas() As String = {"", "", ""}

        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, True)
            Dim tipoDocumentoId As Integer = objUtilerias.ObtenerTipoComprobanteId(TipoComprobante)
            entidadRutas = objUtilerias.ObtenerDirectorios(objTimbrado._EntEmpresa.EmpresaID, tipoDocumentoId, "XML")

            'Dim rutaXML = "C:\Users\SISTEMAS8\Documents\AutotransporteFederal.xml"
            'objTimbrado.GenerarTimbrado(rutaXML, DocumentoID, TipoComprobante)

            Dim rutaXML = CrearXMLFactura(DocumentoID, TipoComprobante, objTimbrado._EntEmpresa.EmpresaID, objTimbrado.VersionFacturacion.Trim())
            'Dim rutaXML = CrearXMLFactura(DocumentoID, TipoComprobante, EmpresaID, objTimbrado.VersionFacturacion.Trim())
            If rutaXML <> "" Then
                Dim cadenaOriginal = objTimbrado.GenerarCadenaOriginal(rutaXML, DocumentoID, TipoComprobante)
                If cadenaOriginal <> "" Then
                    Dim sello = objTimbrado.GeneraSello(rutaXML, cadenaOriginal, DocumentoID, TipoComprobante)
                    If sello <> "" Then
                        If objTimbrado.AgregarSelloXML(rutaXML, sello) Then
                            If objTimbrado.GenerarTimbrado(rutaXML, DocumentoID, TipoComprobante) Then

                                ActualizarUsuarioTimbro(Usuario, DocumentoID)
                                objTimbrado.ObtenerDatosDelComplemento(DocumentoID, rutaXML, cadenaOriginal, TipoComprobante)
                                Rutas(0) = rutaXML
                                Rutas(1) = entidadRutas.RutaSICY & Path.GetFileName(rutaXML)
                                Rutas(2) = entidadRutas.RutaCliente & Path.GetFileName(rutaXML)

                                'CrearDirectorio(Rutas(1))
                                'File.Copy(Rutas(0), Rutas(1), True)
                                Dim caca = entidadRutas.RutaSICY.Replace("\\192.168.2.156\", "")
                                objFTP.EnviarArchivo(caca.Substring(0, caca.Count - 1), rutaXML)

                                objFTP.DescargarArchivo(caca.Substring(0, caca.Count - 1), entidadRutas.RutaSICY.Substring(0, entidadRutas.RutaSICY.Count - 1), Path.GetFileName(rutaXML))

                                MensajeError = "Exito se ha timbrado del XML."
                                EliminarArchivosTemporales(objTimbrado.RutaArchivosTemp, DocumentoID, TipoComprobante)

                            Else
                                InformacionValida = False
                                MensajeError = "Error al timbrar el XML."
                            End If
                        Else
                            InformacionValida = False
                            MensajeError = "Error al agregar el sello al XML."
                        End If
                    Else
                        InformacionValida = False
                        MensajeError = "No se pudo generar el sello."
                    End If
                Else
                    InformacionValida = False
                    MensajeError = "No se pudo generar la cadena original."
                End If
            Else
                InformacionValida = False
                MensajeError = "No se pudo generar el XML. "
            End If

        Catch ex As Exception
            InformacionValida = False
            MensajeError = ex.Message.ToString() + " Usuario:" + System.Security.Principal.WindowsIdentity.GetCurrent().Name
        End Try

        Dim Respuesta As New RespuestaRestArray With {
            .respuesta = IIf(InformacionValida = False, 0, 1),
            .aviso = MensajeError,
            .mensaje = Rutas
        }
        Return Respuesta

    End Function

    Private Function CrearXMLFactura(DocumentoId As Integer, TipoComprobante As String, EmpresaID As Integer, VersionFacturacion As String) As String
        Dim RutaXML As String = String.Empty
        Dim myXmlTextWriter As XmlTextWriter

        Try
            Dim objDA As New DatosDocumentoDA
            Dim fechaEmision As String = Date.Now.ToString("yyy-MM-dd") & "T" & Date.Now.ToString("hh:mm:ss")

            Dim EmisorNombre As String = ""
            Dim EmisorRFC As String = ""
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
            Dim EmisorRegistroFiscal As String = ""

            'Obtener Información Documento a Timbrar

            Dim dtEmpresa = objDA.getDatosEmpresa(EmpresaID)
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

            Dim dtDocumentoComprobante = objDA.getDatosDocumento(DocumentoId, "Comprobante", TipoComprobante)
            Dim Folio = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Folio").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim LugarExpedicion = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "LugarExpedicion").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim TipoDeComprobante = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "TipoDeComprobante").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim Total = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim Moneda = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim SubTotal = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim Serie = dtDocumentoComprobante.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Serie").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

            RutaXML = ObtenerRutaCompletaXML(DocumentoId, EmisorRFC, Folio, TipoComprobante, Serie)
            myXmlTextWriter = New XmlTextWriter(RutaXML, Text.Encoding.UTF8) With {
                .Formatting = Formatting.Indented
            }
            myXmlTextWriter.WriteStartDocument(False)

            '------------------------ Datos del Comprobante -----------------------------------
            myXmlTextWriter.WriteStartElement("cfdi:Comprobante")
            myXmlTextWriter.WriteAttributeString("xmlns:cartaporte", "http://www.sat.gob.mx/CartaPorte")
            myXmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            myXmlTextWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
            myXmlTextWriter.WriteAttributeString("Version", VersionFacturacion)

            myXmlTextWriter.WriteAttributeString("Serie", Serie)
            myXmlTextWriter.WriteAttributeString("Folio", Folio)
            myXmlTextWriter.WriteAttributeString("Fecha", fechaEmision)

            myXmlTextWriter.WriteAttributeString("Sello", "")
            myXmlTextWriter.WriteAttributeString("NoCertificado", NumeroCertificado)
            myXmlTextWriter.WriteAttributeString("Certificado", CadenaCertificado)

            myXmlTextWriter.WriteAttributeString("SubTotal", SubTotal)
            myXmlTextWriter.WriteAttributeString("Moneda", Moneda)
            myXmlTextWriter.WriteAttributeString("Total", Total)
            myXmlTextWriter.WriteAttributeString("TipoDeComprobante", TipoDeComprobante)
            myXmlTextWriter.WriteAttributeString("LugarExpedicion", LugarExpedicion)

            myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/CartaPorte http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte.xsd")

            '------------------------ Datos del Emisor -----------------------------------
            myXmlTextWriter.WriteStartElement("cfdi:Emisor")
            myXmlTextWriter.WriteAttributeString("RegimenFiscal", EmisorRegistroFiscal)
            myXmlTextWriter.WriteAttributeString("Nombre", EmisorNombre)
            myXmlTextWriter.WriteAttributeString("Rfc", EmisorRFC)
            myXmlTextWriter.WriteEndElement()

            '--------------------------- Datos del Receptor ----------------------------------------
            Dim dtDocumentoReceptor = objDA.getDatosDocumento(DocumentoId, "Receptor", TipoComprobante)
            Dim UsoCFDI = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim NombreReceptor = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()
            Dim RFC = dtDocumentoReceptor.AsEnumerable.Where(Function(x) x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorXML")).FirstOrDefault()

            myXmlTextWriter.WriteStartElement("cfdi:Receptor")
            myXmlTextWriter.WriteAttributeString("Nombre", NombreReceptor)
            myXmlTextWriter.WriteAttributeString("Rfc", RFC.Trim())
            myXmlTextWriter.WriteAttributeString("UsoCFDI", UsoCFDI)
            myXmlTextWriter.WriteEndElement()

            '----------------------- Conceptos --------------------------
            Dim numConceptos = objDA.getDatosDocumentoNumConceptos(DocumentoId, TipoComprobante)
            Dim NumeroConceptos = numConceptos.Rows(0).Item(0)

            myXmlTextWriter.WriteStartElement("cfdi:Conceptos")

            For Fila As Integer = 1 To NumeroConceptos
                Dim dtConceptos = objDA.getDatosDocumentoConcepto(DocumentoId, Fila, "Concepto", TipoComprobante)

                Dim ConceptoImporte = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Importe").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoValorUnitario = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ValorUnitario").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoDescripcion = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Descripcion").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Unidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoClaveUnidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveUnidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoCantidad = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "Cantidad").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoClaveProdServ = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "ClaveProdServ").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()
                Dim ConceptoNoIdentificacion = dtConceptos.AsEnumerable.Where(Function(x) x.Item("dode_atributo") = "NoIdentificacion").Select(Function(y) y.Item("dode_valorXML")).FirstOrDefault()

                myXmlTextWriter.WriteStartElement("cfdi:Concepto")
                myXmlTextWriter.WriteAttributeString("Importe", ConceptoImporte)
                myXmlTextWriter.WriteAttributeString("ValorUnitario", ConceptoValorUnitario)
                myXmlTextWriter.WriteAttributeString("Descripcion", ConceptoDescripcion)
                myXmlTextWriter.WriteAttributeString("Unidad", ConceptoUnidad)
                myXmlTextWriter.WriteAttributeString("ClaveUnidad", ConceptoClaveUnidad)
                myXmlTextWriter.WriteAttributeString("Cantidad", ConceptoCantidad)
                myXmlTextWriter.WriteAttributeString("NoIdentificacion", ConceptoNoIdentificacion)
                myXmlTextWriter.WriteAttributeString("ClaveProdServ", ConceptoClaveProdServ)
                myXmlTextWriter.WriteEndElement()
            Next

            myXmlTextWriter.WriteEndElement()


            myXmlTextWriter.WriteEndElement()
            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

        Catch ex As Exception
            If IsNothing(myXmlTextWriter) = False Then
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
            End If
            RutaXML = ex.Message
        End Try

        Return RutaXML
    End Function


    Public Function CancelarFactura(DocumentoID As Integer, UUID As String, EmpresaId As Integer, TipoComprobante As String, UsuarioID As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New UtileriasFacturasBU
        Dim _Aviso As String = String.Empty

        Try
            ServicePointManager.SecurityProtocol = 3072
            'Servidor = "http://localhost:7639/"
            llamarServicio.url = Servidor & "Traslados/CancelacionTraslado?DocumentoID=" & DocumentoID.ToString & "&UUID=" & UUID.Trim & "&EmpresaID=" & EmpresaId.ToString() & "&TipoComprobante=" & TipoComprobante.Trim() & "&UsuarioID=" & UsuarioID.ToString()
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))

                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return Resultado
    End Function

    Public Function GenerarPDFFacturaCancelada(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New UtileriasFacturasBU
        Dim _Aviso As String = String.Empty

        Try
            llamarServicio.url = Servidor & "Traslados/GeneraPDFTrasladoCancelada?DocumentoID=" & DocumentoID.ToString & "&TipoComprobante=" & TipoComprobante.Trim()
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))


                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                TimbradoBU.ActualizarRutaPDFFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try

        Return Resultado

    End Function

    Public Function TimbradoCancelacion(DocumentoID As Integer, UUID As String, EmpresaID As Integer, TipoComprobante As String, UsuarioID As Integer) As RespuestaRestArray
        Dim ObjDA As New DatosDocumentoDA
        Dim Respuesta As New RespuestaRestArray
        Dim Rutas() As String = {"", "", ""}
        Dim objutil As New UtileriasFacturasBU
        Try
            Dim objTimbrado As New TimbradoBU(EmpresaID, True)
            Dim Folio As String = objTimbrado.ObtenerFolio_UUID(UUID, TipoComprobante)
            Dim Serie As String = "" '.ObtenerSerie_UUID(UUID, TipoComprobante)
            DocumentoID = objTimbrado.ObtenerDocumentoID_UUID(UUID, TipoComprobante)

            Dim tipoDocumentoId As Integer = objUtilerias.ObtenerTipoComprobanteId(TipoComprobante)
            entidadRutas = objUtilerias.ObtenerDirectorios(EmpresaID, tipoDocumentoId, "XML")

            Dim RutaXMLCancelacion As String = ObtenerRutaCompletaCancelacionXML(DocumentoID, objTimbrado._EntEmpresa.EmpresaID, objTimbrado._EntEmpresa.RFC.Trim, Folio, TipoComprobante, Serie)
            Dim ResultadoTimbradoCancelacion As Boolean = objTimbrado.CancelacionFacturaPrueba(UUID, objTimbrado.RFCPrueba, TipoComprobante, RutaXMLCancelacion)

            'ResultadoTimbradoCancelacion = objTimbrado.Cancelacion(UUID, objTimbrado._EntEmpresa.RFC, TipoComprobante, RutaXMLCancelacion)

            'Obtiene los datos del complemento del xml generado de la cancelacion
            Dim entFacturaCancelada As Entidades.FacturaCancelada = objTimbrado.ObtenerDatosDelComplementoCancelado(DocumentoID, RutaXMLCancelacion, TipoComprobante)
            DatosDocumentoDA.ActualizarDatosCancelacion(DocumentoID, TipoComprobante, entFacturaCancelada.FechaCancelacion, entFacturaCancelada.EstatusCancelacionID, entFacturaCancelada.DescripcionEstatusCancelacion)
            Dim RutaServidorSICY As String = entidadRutas.RutaSICY & Path.GetFileName(RutaXMLCancelacion)
            Dim RutaCliente As String = entidadRutas.RutaCliente & Path.GetFileName(RutaXMLCancelacion)

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

                Dim obj As New FacturasDA
                obj.ActualizarInformacionCancelacionFactura(DocumentoID, entFacturaCancelada.FechaCancelacion, UsuarioID, TipoComprobante)
            Else
                Respuesta.respuesta = 0
                Respuesta.aviso = "No se cancelo la factura."
                Respuesta.mensaje = Nothing
                'ActualizarFacturaNoCancelada(DocumentoID, TipoComprobante)
            End If

        Catch ex As Exception
            Dim MensajeError As String = ex.Message.ToString()
            Dim InformacionValida As Boolean = False
            Respuesta.respuesta = 0
            Respuesta.aviso = ex.Message.ToString()
            Respuesta.mensaje = Nothing
            ObjDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", ex.Message.ToString())
        End Try

        Return Respuesta

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
            Dim tipoDocumentoId As Integer = objUtilerias.ObtenerTipoComprobanteId(TipoComprobante)
            entidadRutas = objUtilerias.ObtenerDirectorios(EmpresaID, tipoDocumentoId, "PDF")

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
            entReporte = objReporte.LeerReporteporClave("TMB_TRASLADO_CANCELADO")

            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '   LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            Dim archivo As String = "C:\PedidosMuestras" + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReportePDFFactura.Load(archivo)
            ReportePDFFactura.Compile()
            ReportePDFFactura.RegData(DSConceptos)


            ReportePDFFactura("Agente") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Agentes").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsuarioImprimio") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "UsuarioGenera").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Docenas") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Docenas").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Pares") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TotalPares").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Dim OrdenCompra As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'Dim OrdenTienda As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'ReportePDFFactura("OrdenCompra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "OC").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'If OrdenCompra = String.Empty Then
            '    ReportePDFFactura("EtiquetaOrden") = ""
            'Else
            '    ReportePDFFactura("EtiquetaOrden") = "Orden"
            'End If

            'If OrdenTienda = String.Empty Then
            '    ReportePDFFactura("EtiquetaTienda") = ""
            'Else
            '    ReportePDFFactura("EtiquetaTienda") = "TDA."
            'End If


            'ReportePDFFactura("Tienda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "Tienda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

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
            'ReportePDFFactura("Observaciones") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("Observaciones")).FirstOrDefault


            'Informacion Receptor
            'ReportePDFFactura("Receptor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Nombre").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorCalleNumCol") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Domicilio").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorMunEstadoPais") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "Ciudad").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("UsoCFDI") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "UsoCFDI").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("ReceptorCP") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor-SOLO PDF" And x.Item("dota_atributo") = "CP").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("ReceptorRFC") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Receptor" And x.Item("dota_atributo") = "Rfc").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Informacion del Comprobante
            ReportePDFFactura("noCertificadoSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadosat")).FirstOrDefault
            ReportePDFFactura("noCertificado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_certificadoemisor")).FirstOrDefault
            ReportePDFFactura("Regimen") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "RegimenFiscalTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("FechaTimbrado") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_fechatimbrado")).FirstOrDefault
            'ReportePDFFactura("MetodoPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "MetodoPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("FormaPago") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "FormaPago").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Modeda") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Moneda").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'Dim tipo As String = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()

            'ReportePDFFactura("TipoFactor") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TipoFactor").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TasaOCuota") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Traslado" And x.Item("dota_atributo") = "TasaOCuota").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CantidadLetra") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "TotalLetra").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Subtotal") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "SubTotal").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TotalDescuento") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Descuento").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            'ReportePDFFactura("TotalImpuestosTrasladados") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Impuestos" And x.Item("dota_atributo") = "TotalImpuestosTrasladados").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("Total") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "Comprobante" And x.Item("dota_atributo") = "Total").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()



            ReportePDFFactura("TipoDeComprobante") = dtInformacionEmisor.AsEnumerable().Where(Function(x) x.Item("dota_nodo") = "SOLO PDF" And x.Item("dota_atributo") = "TipoDeComprobanteTexto").Select(Function(y) y.Item("dota_valorPDF")).FirstOrDefault()
            ReportePDFFactura("CadenaOrigComplemento") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_cadenaoriginalcomplemento")).FirstOrDefault
            ReportePDFFactura("Sello") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellocfdi")).FirstOrDefault
            ReportePDFFactura("SelloSAT") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_sellosat")).FirstOrDefault
            ReportePDFFactura("RFCProveedorDeCertificacion") = DTInformacionFactura.AsEnumerable().Select(Function(x) x.Item("doti_rfcclaveproveedorcertificacion")).FirstOrDefault
            ReportePDFFactura("rutaImagen") = Replace(RutaLogo, "/", "\")


            'ReportePDFFactura("TextoPagosBBVA") = TextoComprpbantePago
            'ReportePDFFactura("Convenio") = Convenio
            'ReportePDFFactura("Referencia") = Referencia

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

            RutaPDF = ObtenerRutaCompletaPDFCancelado(documentoID, EmpresaID, RFCEmpresa, Folio, Serie, TipoComprobante)
            ReportePDFFactura.ExportDocument(StiExportFormat.Pdf, RutaPDF)


            RutaCliente = entidadRutas.RutaCliente & Path.GetFileName(RutaPDF)
            RutaSICY = entidadRutas.RutaSICY & Path.GetFileName(RutaPDF)

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



    Public Function ConsultarRutaPDFFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtinformacion As DataTable
        Dim RutaPDF As String = String.Empty

        Try
            dtinformacion = objDA.ConsultarRutaPDFFactura(DocumentoID, "TRASLADO")
            If dtinformacion.Rows.Count > 0 Then
                RutaPDF = dtinformacion.Rows(0).Item(0)
            Else
                RutaPDF = String.Empty
            End If

        Catch ex As Exception
            Throw ex
            RutaPDF = String.Empty
        End Try

        Return RutaPDF
    End Function

    Public Sub InsertarErrorAlTimbrar(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal ClaveError As String, ByVal DescripcionError As String)
        Dim objDA As New Datos.TimbradoFacturasDA
        objDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, ClaveError, DescripcionError)
    End Sub

    Public Function ObtenerRutaCompletaXML(DocumentoId As Integer, RFCEmpresa As String, Folio As String, TipoComprobante As String, Serie As String) As String
        Dim Directorio As String = entidadRutas.RutaServicioRest

        If Directory.Exists(Directorio) = False Then
            Directory.CreateDirectory(Directorio)
        End If

        Dim NombreArchivo As String = getNombreDocumento(DocumentoId, RFCEmpresa, Folio, Serie, TipoComprobante, "XML", False)
        Dim RutaCompleta As String = Directorio & NombreArchivo

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

    Public Function ObtenerRutaCompletaCancelacionXML(ByVal DocumentoID As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal TipoComprobante As String, ByVal Serie As String) As String
        Dim Directorio As String = entidadRutas.RutaServicioRest
        If Directory.Exists(Directorio) = False Then
            Directory.CreateDirectory(Directorio)
        End If

        Dim NombreArchivo As String = getNombreDocumento(DocumentoID, RFCEmpresa, Folio, Serie, TipoComprobante, "XML", True)
        Dim RutaCompleta As String = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

    Public Function ObtenerRutaCompletaPDFCancelado(ByVal idDocumento As Integer, ByVal EmpresaID As Integer, ByVal RFCEmpresa As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String) As String
        Dim RutaCompleta As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty

        Directorio = entidadRutas.RutaServicioRest
        If System.IO.Directory.Exists(Directorio) = False Then
            System.IO.Directory.CreateDirectory(Directorio)
        End If

        NombreArchivo = getNombreDocumento(idDocumento, RFCEmpresa, Folio, Serie, TipoComprobante, "PDF", True)
        RutaCompleta = Directorio & NombreArchivo

        Return RutaCompleta
    End Function

    Private Sub ActualizarUsuarioTimbro(Usuario As Integer, DocumentoID As Integer)
        Try
            objDA.ActualizarUsuarioTimbro(Usuario, DocumentoID)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub InsertarError(folioEmbarqueId As Integer, tipo As String, mensaje As String)
        objDA.InsertarError(folioEmbarqueId, tipo, mensaje)
    End Sub

    Public Sub CrearDirectorio(ByVal Ruta As String)

        Dim DirectorioCliente As String = String.Empty
        Dim FileName As String = String.Empty
        Dim DirectoryName As String = String.Empty
        Try
            DirectorioCliente = Path.GetDirectoryName(Ruta)


            'Dim UserAccount As String = "192.168.2.156\Administrador" 'Specify the user here
            'Dim FolderInfo As New DirectoryInfo(DirectorioCliente)
            'Dim FolderAcl As New DirectorySecurity
            'FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            'FolderAcl.SetAccessRuleProtection(True, False) 'uncomment to remove existing permissions
            'FolderInfo.SetAccessControl(FolderAcl)

            'Dim FolderInfo As New DirectoryInfo(DirectorioCliente)
            'Dim sid = New SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, Nothing)
            'Dim FolderAcl = FolderInfo.GetAccessControl()
            'FolderAcl.AddAccessRule(New FileSystemAccessRule(sid, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            'FolderInfo.SetAccessControl(FolderAcl)

            ' DirectorioCliente &= "\"
            If Directory.Exists(DirectorioCliente) = False Then
                'Directory.CreateDirectory(DirectorioCliente, FolderAcl)
                Directory.CreateDirectory(DirectorioCliente)
            End If

            FileName = Path.GetFileName(Ruta)
            DirectorioCliente &= FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
