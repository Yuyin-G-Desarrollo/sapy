Imports System.Xml
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Facturacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Tools
Imports ToolServicios
Imports Ventas.Negocios

Public Class ResumenFacturasComplementoPTISAPForm
    Dim objBU As New RegistrarInventarioSAPBU

    'Variables para prueba
    Dim pruebas As Boolean = False
    Dim local As Boolean = False

#Region "Propiedades"


    Private razosocialid As Int32
    Public Property RazonSocialId() As Int32
        Get
            Return razosocialid
        End Get
        Set(ByVal value As Int32)
            razosocialid = value
        End Set
    End Property
    Private fechainiciosap As Date
    Public Property FechaInicio() As Date
        Get
            Return fechainiciosap
        End Get
        Set(ByVal value As Date)
            fechainiciosap = value
        End Set
    End Property
    Private fechafinalsap As Date
    Public Property FechaFinal() As Date
        Get
            Return fechafinalsap
        End Get
        Set(ByVal value As Date)
            fechafinalsap = value
        End Set
    End Property

    Private facturasIds As String
    Public Property FacturasIdSap() As String
        Get
            Return facturasIds
        End Get
        Set(ByVal value As String)
            facturasIds = value
        End Set
    End Property
#End Region

    Private Sub FacturasComplementoPTISAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarResumenComplementos_SAP()
    End Sub

    Private Sub CargarResumenComplementos_SAP()
        Dim cargarResumen As DataTable
        cargarResumen = objBU.ConsultarResumenComplementosSAP(RazonSocialId, FechaInicio, FechaFinal, facturasIds)
        If cargarResumen.Rows.Count > 0 Then
            lblLeyenda.Text = "Se generarán " & cargarResumen.Rows.Count.ToString() & " facturas de complementos de PT SAP." & vbCrLf
            lblLeyenda.Text &= "Este proceso no podrá revertirse ¿Desea continuar?"
            grdListadoFacturasComplementosSAP.DataSource = cargarResumen
            DiseñoGrid(gvwListadoComplementosSAP)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El procedimiento no regreso ningun resultado")
        End If
    End Sub
    Private Sub DiseñoGrid(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(gvwListadoComplementosSAP) '' pone color a las filas del gridview
        gvwListadoComplementosSAP.OptionsBehavior.Editable = False

        Grid.IndicatorWidth = 30
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("receptorId").Visible = False
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("emisorId").Visible = False
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("Num").Visible = False
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("NumRazon").Visible = False
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("Razón Social").Width = 285
        gvwListadoComplementosSAP.Columns.ColumnByFieldName("Receptor").Width = 190
        gvwListadoComplementosSAP.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListadoComplementosSAP.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("ParesF") Or col.FieldName.Contains("Total") Or col.FieldName.Contains("Subtotal") Or col.FieldName.Contains("IVA") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "ParesF")) = True And col.FieldName = "ParesF" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    col.DisplayFormat.FormatString = "N0"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
            End If
        Next
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
    Private Sub gvwListadoComplementosSAP_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles gvwListadoComplementosSAP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        FacturarComplementosPT_SAP()
    End Sub
    Private Sub FacturarComplementosPT_SAP()
        Try
            Dim objMensajeConf As New Tools.ConfirmarForm With {
               .mensaje = "¿Está seguro(a) de facturar? Este proceso no se podrá revertir."
           }
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim dtResultado As New DataTable
                Dim strResultado As String
                Dim errorMsg As String = String.Empty
                Dim timbradas As Boolean = False
                dtResultado = objBU.insertarFacturarComplementosPT_SAP(FechaInicio, FechaFinal, razosocialid, pruebas, facturasIds)
                If Not dtResultado Is Nothing Then
                    If dtResultado.Rows.Count > 0 Then
                        strResultado = dtResultado.Rows(0)("mensaje").ToString()

                        If strResultado.Equals("EXITO") Then
                            For Each row As DataRow In dtResultado.Rows
                                Dim documentoId As Integer = CInt(row("documentoId").ToString())
                                Dim emisorId As Integer = CInt(row("emisorId").ToString())
                                strResultado = objBU.GeneraInformacionTimbrar(documentoId)
                                If strResultado.Equals("EXITO") Then
                                    strResultado = TimbrarFacturasComplementosPT_SAP(documentoId, emisorId)
                                    If strResultado.Equals("EXITO") Then
                                        timbradas = True
                                    Else
                                        errorMsg = errorMsg & "DoctoId: " & documentoId.ToString() & "- Al timbrar." & strResultado & vbCrLf
                                    End If
                                Else
                                    errorMsg = errorMsg & "DoctoId: " & documentoId.ToString() & "- Al generar información para timbrar." & strResultado & vbCrLf
                                End If
                            Next
                            If errorMsg <> "" And timbradas Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Algunas facturas se generaron correctamente. Los siguientes documentos generaron error: " & vbCrLf & errorMsg)
                            ElseIf errorMsg <> "" And Not timbradas Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Errores, errorMsg)
                            Else
                                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Factura(s) generada(s) correctamente")
                            End If
                            Me.Cursor = Cursors.Default
                            Me.Close()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error al insertar información de los documentos." & vbCrLf & strResultado)
                            Me.Cursor = Cursors.Default
                            Me.Close()
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error al generar la información para facturar")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error al generar la información para facturar")
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
    End Sub
    Private Function TimbrarFacturasComplementosPT_SAP(ByVal documentoId As String, ByVal emisorId As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(local, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "FACTURACOMPLEMENTO"

        llamarServicio.url = Servidor & "Facturas/Timbrado" &
                            "?DocumentoID=" & documentoId &
                            "&EmpresaID=" & emisorId &
                            "&TipoComprobante=" & tipoComprbante &
                            "&TimbradoPrueba=" & pruebas.ToString()
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, pruebas)

            ActualizarDatosTimbrado(documentoId, RutaServidorSICY) 'Ok 140520211337
            GenerarCuentaPorPagar(documentoId)
            GenerarPDF(documentoId)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & documentoId.ToString & ")"
            Try
                Dim objBUAdmon As New AdmonDoctosComprasPT_BU
                objBUAdmon.ActualizarMtvoSinTimbrarFacturaPIDocumento(documentoId, resultado)
            Catch ex As Exception
            End Try
        End If

        Return resultado
    End Function

    Private Sub GenerarPDF(ByVal documentoId As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(local, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "FACTURACOMPLEMENTO"

        llamarServicio.url = Servidor & "Facturas/GeneraPDF" &
                            "?DocumentoID=" & documentoId &
                            "&TipoComprobante=" & tipoComprbante
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, local)
        End If
    End Sub

    Private Function ActualizarDatosTimbrado(ByVal idDocumento As Integer, ByVal sXML As String) As String
        Dim resultado As String = String.Empty
        Try
            Dim objBUAdmon As New RegistrarInventarioSAPBU
            Dim Doc As New XmlDocument
            Dim TimbreFiscal As XmlNode
            Dim Factura As XmlNode

            Dim sello As String = String.Empty
            Dim uuid As String = String.Empty
            Dim fechaTimbrado As String = String.Empty
            Dim versionSat As String = String.Empty
            Dim rfcProvCertif As String = String.Empty
            Dim noCertificadoSAT As String = String.Empty
            Dim selloSAT As String = String.Empty
            Dim cadenaOriginal As String = String.Empty
            Dim cadenaOriginalComplemento As String = String.Empty

            Doc.Load(sXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(Doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = Doc.ChildNodes(1)
            sello = Factura.Attributes.GetNamedItem("Sello").Value

            Dim nodo As XmlNode = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
            TimbreFiscal = nodo.ChildNodes(0)
            uuid = TimbreFiscal.Attributes.GetNamedItem("UUID").Value
            fechaTimbrado = TimbreFiscal.Attributes.GetNamedItem("FechaTimbrado").Value
            versionSat = TimbreFiscal.Attributes.GetNamedItem("Version").Value
            rfcProvCertif = TimbreFiscal.Attributes.GetNamedItem("RfcProvCertif").Value
            noCertificadoSAT = TimbreFiscal.Attributes.GetNamedItem("NoCertificadoSAT").Value
            selloSAT = TimbreFiscal.Attributes.GetNamedItem("SelloSAT").Value
            cadenaOriginalComplemento = "||" & versionSat.Trim() & "|" & uuid & "|" & fechaTimbrado & "|" & sello & "|" & noCertificadoSAT & "||"

            resultado = objBUAdmon.ActualizarInfoFacturaComplementosSAP_PT(idDocumento, sello, uuid, fechaTimbrado, versionSat, rfcProvCertif, noCertificadoSAT, selloSAT, cadenaOriginal, cadenaOriginalComplemento)
        Catch ex As Exception
            resultado = ex.Message
        End Try
        Return resultado
    End Function
    Private Function GenerarCuentaPorPagar(ByVal idDocumento As Integer) As String
        Dim resultado As String = String.Empty
        Try
            Dim objBUAdmon As New RegistrarInventarioSAPBU
            Dim idcomprobantesicy As Integer = 0
            Dim dtResultado As New DataTable

            Try
                idcomprobantesicy = objBUAdmon.ObtenerIdComprobanteCFD(idDocumento)
            Catch ex As Exception
            End Try

            dtResultado = objBUAdmon.ObtenerInfoCXPSaldo(idDocumento)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    Dim tipoDoc As Integer
                    Dim idProveedor As Integer
                    Dim numDoc As String
                    Dim fechaDoc As Date
                    Dim fechaVencimiento As Date
                    Dim semanaPago As Integer
                    Dim semanaPagada As Integer
                    Dim subTotal As Double
                    Dim iva As Double
                    Dim total As Double
                    Dim totalDoc As Double
                    Dim moneda As Integer
                    Dim nave As Integer
                    Dim añoSemPago As Integer
                    Dim rfcContribuyente As String
                    Dim rfcProveedor As String
                    Dim giro As String


                    tipoDoc = CInt(dtResultado.Rows(0)("tipoDoc").ToString)
                    idProveedor = CInt(dtResultado.Rows(0)("idProveedor").ToString)
                    numDoc = dtResultado.Rows(0)("numDoc").ToString
                    fechaDoc = CDate(dtResultado.Rows(0)("fechaDoc").ToString)
                    fechaVencimiento = CDate(dtResultado.Rows(0)("fechaVencimiento").ToString)
                    semanaPago = CInt(dtResultado.Rows(0)("semanaPago").ToString)
                    semanaPagada = CInt(dtResultado.Rows(0)("semanaPagada").ToString)
                    subTotal = CDbl(dtResultado.Rows(0)("subTotal").ToString)
                    iva = CDbl(dtResultado.Rows(0)("iva").ToString)
                    total = CDbl(dtResultado.Rows(0)("total").ToString)
                    totalDoc = CDbl(dtResultado.Rows(0)("totalDoc").ToString)
                    moneda = CInt(dtResultado.Rows(0)("moneda").ToString)
                    nave = CInt(dtResultado.Rows(0)("nave").ToString)
                    añoSemPago = CInt(dtResultado.Rows(0)("añoSemPago").ToString)
                    rfcContribuyente = dtResultado.Rows(0)("rfcContribuyente").ToString
                    rfcProveedor = dtResultado.Rows(0)("rfcProveedor").ToString
                    giro = dtResultado.Rows(0)("giro").ToString

                    resultado = objBUAdmon.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
                    If resultado <> "True" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, resultado)
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener la información para generar la cuenta por pagar")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener la información para generar la cuenta por pagar")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
        Return resultado
    End Function

End Class