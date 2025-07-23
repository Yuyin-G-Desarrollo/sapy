Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports Entidades
Imports Tools
Imports ToolServicios
Imports Facturacion.Negocios
Imports System.IO
Imports System.Xml
Imports Proveedores.BU

Public Class ComprasPTIngresado_ResumenFacturasForm
#Region "Properties"
    Dim objBU As New Proveedores.BU.ConsultaComprasPT_BU
    Dim strFecha As String = String.Empty
    Public fechaInicio As Date
    Public fechaFin As Date
    Public navesId As String = String.Empty
    Public marcasId As String = String.Empty
    Public dtResultado As New DataTable
    Public reload As Boolean = False
    Public CEDIS As Integer = 0
#End Region

#Region "Methods"
    Private Sub ValidarDebug()
        grbSistemas.Visible = False

        '#If DEBUG Then
        '        grbSistemas.Visible = True
        '        chkPruebas.Checked = True
        '        chkLocal.Checked = True
        '#End If
        Try
            Dim objBUAdmon As New AdmonDoctosComprasPT_BU
            If objBUAdmon.ConsultarPerfilSistemas() Then
                grbSistemas.Visible = True
                'chkPruebas.Checked = True
                'chkLocal.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub ObtenerResumenFacturacion()
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        Dim dsResultado As New DataSet
    '        dsResultado = objBU.ObtenerResumenFacturacion(fechaInicio, fechaFin, navesId, marcasId)
    '        If Not dsResultado Is Nothing Then
    '            Dim dtResumen As New DataTable
    '            dtResumen = dsResultado.Tables(0)
    '            lblLeyenda.Text = "Se generarán " & dtResumen.Rows(0).Item("Facturable").ToString() & " facturas de compra con los filtros seleccionados." & vbCrLf
    '            If CInt(dtResumen.Rows(0).Item("NoFacturable").ToString()) > 0 Then
    '                lblLeyenda.Text &= dtResumen.Rows(0).Item("NoFacturable").ToString() & " Registros no pueden ser facturados." & vbCrLf
    '            End If
    '            lblLeyenda.Text &= "Este proceso no podrá revertirse ¿Desea continuar?"

    '            grdListado.DataSource = dsResultado.Tables(2)
    '            DisenioGrid()
    '        Else
    '            Show_message("Advertencia", "El procedimiento no regreso ningun resultado")
    '        End If
    '    Catch ex As Exception
    '        Show_message("Error", ex.Message)
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub ObtenerResumenFacturacion()
        Try
            Dim dtResumen As New DataTable
            dtResumen = objBU.ObtenerResumenFacturacion(fechaInicio, fechaFin, navesId, marcasId)
            If Not dtResumen Is Nothing Then
                If dtResumen.Rows.Count > 0 Then
                    lblLeyenda.Text = "Se generarán " & dtResumen.Rows(0).Item("Facturable").ToString() & " facturas de compra con los filtros seleccionados." & vbCrLf
                    If CInt(dtResumen.Rows(0).Item("NoFacturable").ToString()) > 0 Then

                        lblLeyenda.Text &= dtResumen.Rows(0).Item("NoFacturable").ToString() & " Registros no pueden ser facturados." & vbCrLf
                    End If
                    lblLeyenda.Text &= "Este proceso no podrá revertirse ¿Desea continuar?"

                    grdListado.DataSource = dtResumen
                    DisenioGrid()
                Else
                    Show_message("Advertencia", "El procedimiento no regreso ningun resultado")
                    Me.Close()
                End If
            Else
                Show_message("Advertencia", "El procedimiento no regreso ningun resultado")
                Me.Close()
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
    End Sub

    Public Sub Show_message(ByVal tipo As String, ByVal mensaje As String)
        Dim objMensaje As Object

        Select Case tipo
            Case "Advertencia"
                objMensaje = New AdvertenciaForm
            Case "Aviso"
                objMensaje = New AvisoForm
            Case "Error"
                objMensaje = New ErroresForm
            Case "Exito"
                objMensaje = New ExitoForm
            Case "Confirmar"
                objMensaje = New ConfirmarForm
            Case "AdvertenciaGrande"
                objMensaje = New AdvertenciaFormGrande
            Case Else
                objMensaje = New AvisoForm
        End Select

        objMensaje.mensaje = mensaje
        objMensaje.ShowDialog()
    End Sub

    Private Sub DisenioGrid()
        gvwListado.BestFitColumns()
        gvwListado.OptionsView.ColumnAutoWidth = True
        gvwListado.OptionsView.EnableAppearanceEvenRow = True
        gvwListado.OptionsView.ShowAutoFilterRow = True
        gvwListado.OptionsView.RowAutoHeight = True
        gvwListado.IndicatorWidth = 30

        gvwListado.Columns.ColumnByFieldName("ReceptorId").Visible = False
        gvwListado.Columns.ColumnByFieldName("EmisorId").Visible = False

        If gvwListado.Columns.Contains(gvwListado.Columns.ColumnByFieldName("TotalF")) Then
            gvwListado.Columns.ColumnByFieldName("TotalF").Visible = False
        End If

        If gvwListado.Columns.Contains(gvwListado.Columns.ColumnByFieldName("Facturable")) Then
            gvwListado.Columns.ColumnByFieldName("Facturable").Visible = False
        End If

        If gvwListado.Columns.Contains(gvwListado.Columns.ColumnByFieldName("NoFacturable")) Then
            gvwListado.Columns.ColumnByFieldName("NoFacturable").Visible = False
        End If

        gvwListado.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("ParesF") Or col.FieldName.Contains("Total") Or col.FieldName.Contains("Subtotal") Or col.FieldName.Contains("IVA") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "ParesF")) = True And col.FieldName = "ParesF" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next

    End Sub

    Private Sub Facturar()
        Try
            Dim objMensajeConf As New Tools.ConfirmarForm With {
                .mensaje = "¿Está seguro de facturar? Este proceso no se podrá revertir."
            }
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim dtResultado As New DataTable
                Dim strResultado As String
                Dim errorMsg As String = String.Empty
                Dim timbradas As Boolean = False

                dtResultado = objBU.InsertarDocumentoFactura(fechaInicio, fechaFin, navesId, marcasId, chkPruebas.Checked)
                If Not dtResultado Is Nothing Then
                    If dtResultado.Rows.Count > 0 Then
                        strResultado = dtResultado.Rows(0)("mensaje").ToString()

                        If strResultado.Equals("EXITO") Then
                            For Each row As DataRow In dtResultado.Rows
                                Dim documentoId As Integer = CInt(row("documentoId").ToString())
                                Dim emisorId As Integer = CInt(row("emisorId").ToString())

                                strResultado = objBU.GeneraInformacionTimbrar(documentoId)
                                If strResultado.Equals("EXITO") Then
                                    strResultado = TimbrarDocumento(documentoId, emisorId)
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
                                Show_message("Advertencia", "Algunas facturas se generaron correctamente. Los siguientes documentos generaron error: " & vbCrLf & errorMsg)
                            ElseIf errorMsg <> "" And Not timbradas Then
                                Show_message("Error", errorMsg)
                            Else
                                Show_message("Exito", "Factura(s) generada(s) correctamente")
                            End If
                            reload = True
                            Me.Cursor = Cursors.Default
                            Me.Close()
                        Else
                            Show_message("Error", "Error al insertar información de los documentos." & vbCrLf & strResultado)
                            Me.Cursor = Cursors.Default
                            Me.Close()
                        End If
                    Else
                        Show_message("Error", "Error al generar la información para facturar")
                    End If
                Else
                    Show_message("Error", "Error al generar la información para facturar")
                End If
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function TimbrarDocumento(ByVal documentoId As String, ByVal emisorId As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "COMPRAPRODINGRESADO"

        llamarServicio.url = Servidor & "Facturas/Timbrado" &
                            "?DocumentoID=" & documentoId &
                            "&EmpresaID=" & emisorId &
                            "&TipoComprobante=" & tipoComprbante &
                            "&TimbradoPrueba=" & chkPruebas.Checked.ToString()
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, chkLocal.Checked)

            ActualizarDatosTimbrado(documentoId, RutaServidorSICY)
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

    Private Function ActualizarDatosTimbrado(ByVal idDocumento As Integer, ByVal sXML As String) As String
        Dim resultado As String = String.Empty
        Try
            Dim objBUAdmon As New AdmonDoctosComprasPT_BU
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

            resultado = objBUAdmon.ActualizarInfoFacturaPIDocumento(idDocumento, sello, uuid, fechaTimbrado, versionSat, rfcProvCertif, noCertificadoSAT, selloSAT, cadenaOriginal, cadenaOriginalComplemento)
        Catch ex As Exception
            resultado = ex.Message
        End Try
        Return resultado
    End Function

    Private Function GenerarCuentaPorPagar(ByVal idDocumento As Integer) As String
        Dim resultado As String = String.Empty
        Try
            Dim objBUAdmon As New AdmonDoctosComprasPT_BU
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
                    'idcomprobantesicy = CInt(dtResultado.Rows(0)("idcomprobantesicy").ToString)

                    resultado = objBUAdmon.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
                    If resultado <> "True" Then
                        Show_message("Advertencia", resultado)
                    End If
                Else
                    Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
                End If
            Else
                Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
            End If
        Catch ex As Exception
            Show_message("Advertencia", ex.Message)
        End Try
        Return resultado
    End Function

    Private Sub GenerarPDF(ByVal documentoId As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "COMPRAPRODINGRESADO"

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
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, chkLocal.Checked)
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub ResumenFacturasPTIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValidarDebug()
        ObtenerResumenFacturacion()
    End Sub

    Private Sub GvwListado_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles gvwListado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click, lblAceptar.Click
        Facturar()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, lblCancelar.Click
        Dispose()
    End Sub
#End Region
End Class