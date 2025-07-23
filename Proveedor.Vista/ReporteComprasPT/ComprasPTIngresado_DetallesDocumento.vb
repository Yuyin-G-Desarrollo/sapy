Imports System.Drawing
Imports System.Windows.Forms
Imports Tools
Imports Proveedores.BU
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class ComprasPTIngresado_DetallesDocumento
#Region "Propierties"
    Public documentoIds As List(Of Integer) = New List(Of Integer)
    Public receptorRazonSocial As String
    Public receptorRfc As String
    Public fechaIngreso As Date
    Public foloFactura As String
    Public statusDocto As String
    Public emisorRazonSocial As String
    Public emisorRfc As String
    Public esDevolucion As Boolean
    Public saldoFactura As Double
    Public receptorSayId As Integer
    Public emisorSayId As Integer
    Public receptorSicyId As Integer
    Public emisorSicyId As Integer


    Dim objBU As New AdmonDoctosComprasPT_BU
    Dim IdFacturaAplicar As Integer
#End Region

#Region "Methods"
    Private Sub CargarInformacion()
        Me.Cursor = Cursors.WaitCursor
        Try
            If documentoIds.Count > 0 Then
                Dim dtResultado As New DataTable
                grdListado.DataSource = Nothing

                If documentoIds.Count = 1 Then
                    pnlParametros.Visible = True
                    btnAbajo.Visible = True
                    btnArriba.Visible = True

                    lblRazonSocialReceptor.Text = receptorRazonSocial
                    lblRFCReceptor.Text = receptorRfc
                    lblDocumento.Text = documentoIds(0)
                    lblFechaIngreso.Text = fechaIngreso.ToString("dd/MM/yyyy")
                    lblFolioFactura.Text = foloFactura
                    lblStatus.Text = statusDocto
                    lblRazonSocialEmisor.Text = emisorRazonSocial
                    lblRFCEmisor.Text = emisorRfc
                Else
                    pnlParametros.Visible = False
                    btnAbajo.Visible = False
                    btnArriba.Visible = False
                End If

                dtResultado = objBU.ObtenerDetallesDocumentos(String.Join(",", documentoIds).ToString)
                If Not dtResultado Is Nothing Then
                    If dtResultado.Rows.Count > 0 Then
                        grdListado.DataSource = dtResultado
                        DisenioGrid()
                        lblRegistros.Text = dtResultado.Rows.Count
                    Else
                        Show_message("Advertencia", "No se encontraron detalles del documento")
                    End If
                Else
                    Show_message("Advertencia", "No se encontraron detalles del documento")
                End If
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DisenioGrid()
        gvwListado.BestFitColumns()
        gvwListado.OptionsView.ColumnAutoWidth = True
        gvwListado.OptionsView.EnableAppearanceEvenRow = True
        gvwListado.IndicatorWidth = 30
        gvwListado.OptionsView.ShowAutoFilterRow = True
        gvwListado.OptionsView.RowAutoHeight = True

        gvwListado.Columns.ColumnByFieldName("ST").Width = 20
        gvwListado.Columns.ColumnByFieldName("STATUS").Visible = False

        If documentoIds.Count = 1 Then
            gvwListado.Columns.ColumnByFieldName("ST").Visible = False
            gvwListado.Columns.ColumnByFieldName("ID SAY").Visible = False
            gvwListado.Columns.ColumnByFieldName("EMISOR").Visible = False
            gvwListado.Columns.ColumnByFieldName("RECEPTOR").Visible = False
            gvwListado.Columns.ColumnByFieldName("FINGRESO").Visible = False
            gvwListado.Columns.ColumnByFieldName("FFACTURA").Visible = False
        End If

        If Not esDevolucion Then
            gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").Visible = False
            gvwListado.Columns.ColumnByFieldName("PARES DEVOLVER").Visible = False
        End If

        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatString = "N0"
        gvwListado.Columns.ColumnByFieldName("PARES DEVOLVER").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("PARES DEVOLVER").DisplayFormat.FormatString = "N0"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If col.FieldName.Contains("SUBTOTAL") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("TOTAL") Or col.FieldName.Contains("PARES DEVUELTOS") Or col.FieldName.Contains("PARES DEVOLVER") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SUBTOTAL")) = True And col.FieldName = "SUBTOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "TOTAL")) = True And col.FieldName = "TOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "PARES DEVUELTOS")) = True And col.FieldName = "PARES DEVUELTOS" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "PARES DEVOLVER")) = True And col.FieldName = "PARES DEVOLVER" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    col.OptionsColumn.AllowEdit = True
                End If
            End If
        Next
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

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

#End Region

#Region "Events"
    Private Sub ComprasPTIngresado_DetallesDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInformacion()
        If esDevolucion Then
            If saldoFactura <= 0 Then
                pnlAplicarDocumento.Visible = True
                lblSaldo.Visible = True
                pnlGuardarDev.Enabled = False
            End If
            pnlGuardarDev.Visible = True

            If emisorSayId = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No fue posible recuperar los datos del emisor para la devolución.")
                Me.Close()
            ElseIf receptorSayId = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No fue posible recuperar los datos del receptor para la devolución.")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click, lblExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If gvwListado.DataRowCount > 0 Then

                nombreReporte = "DocumentosDetallesComprasPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.ToString("yyyyMMdd_Hmmss")

                    If ret = Windows.Forms.DialogResult.OK Then
                        If gvwListado.GroupCount > 0 Then
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub LblStatus_TextChanged(sender As Object, e As EventArgs) Handles lblStatus.TextChanged
        Select Case lblStatus.Text
            Case "POR TIMBRAR"
                lblStatus.ForeColor = Color.Orange
            Case "ACTIVA"
                lblStatus.ForeColor = Color.Green
            Case "CANCELADA"
                lblStatus.ForeColor = Color.Tomato
        End Select
    End Sub

    Private Sub GvwListado_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles gvwListado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub GvwListado_RowCellStyle(sender As Object, e As Views.Grid.RowCellStyleEventArgs) Handles gvwListado.RowCellStyle
        Try
            If gvwListado.RowCount > 0 AndAlso e.RowHandle >= 0 Then
                
                Dim currentView As GridView
                currentView = sender

                If e.Column.FieldName = "ST" Then
                    Dim value As String
                    value = currentView.GetRowCellValue(e.RowHandle, "STATUS").ToString()

                    Select Case value
                        Case "POR TIMBRAR"
                            e.Appearance.BackColor = Color.Orange
                        Case "ACTIVA"
                            e.Appearance.BackColor = Color.Green
                        Case "CANCELADA"
                            e.Appearance.BackColor = Color.Tomato
                    End Select
                End If

                If e.Column.FieldName = "PARES DEVOLVER" Then
                    Dim paresTotal As Integer = 0
                    Dim paresDevueltos As Integer = 0
                    Dim paresDevolver As Integer = 0

                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, "PARES")) Then
                        paresTotal = currentView.GetRowCellValue(e.RowHandle, "PARES")
                    End If

                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, "PARES DEVUELTOS")) Then
                        paresDevueltos = currentView.GetRowCellValue(e.RowHandle, "PARES DEVUELTOS")
                    End If

                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, "PARES DEVOLVER")) Then
                        paresDevolver = currentView.GetRowCellValue(e.RowHandle, "PARES DEVOLVER")
                    End If

                    If paresDevolver + paresDevueltos > paresTotal Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDocumento_Click(sender As Object, e As EventArgs) Handles btnDocumento.Click
        Try
            Dim objForm As New ComprasPTIngresado_FacturasConSaldoForm
            If Not CheckForm(objForm) Then
                objForm.emisorSicyId = emisorSicyId
                objForm.receptorSicyId = receptorSicyId
                objForm.ShowDialog()
                IdFacturaAplicar = objForm.facturaId
                'pnlGuardarDev.Enabled = IdFacturaAplicar <> 0
                If validaParesDevolver() Then
                    If saldoFactura > 0 Then
                        pnlGuardarDev.Enabled = True
                    ElseIf saldoFactura <= 0 AndAlso IdFacturaAplicar <> 0 Then
                        pnlGuardarDev.Enabled = True
                    Else
                        pnlGuardarDev.Enabled = False
                    End If
                Else
                    pnlGuardarDev.Enabled = False
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrió un error al obtener la factura a devolver.")
        End Try
    End Sub

    Private Sub gvwListado_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles gvwListado.CellValueChanged
        If esDevolucion Then
            Try
                Dim paresTotal As Integer = 0
                Dim paresDevueltos As Integer = 0
                Dim paresDevolver As Integer = 0
                Dim blnParesCorrectos As Boolean = True

                If Not IsDBNull(gvwListado.GetRowCellValue(e.RowHandle, "PARES")) And Not IsDBNull(gvwListado.GetRowCellValue(e.RowHandle, "PARES DEVUELTOS")) And Not IsDBNull(gvwListado.GetRowCellValue(e.RowHandle, "PARES DEVOLVER")) Then
                    paresTotal = gvwListado.GetRowCellValue(e.RowHandle, "PARES")
                    paresDevueltos = gvwListado.GetRowCellValue(e.RowHandle, "PARES DEVUELTOS")
                    paresDevolver = gvwListado.GetRowCellValue(e.RowHandle, "PARES DEVOLVER")
                    If paresDevolver + paresDevueltos > paresTotal Then
                        blnParesCorrectos = False
                    End If
                End If

                If blnParesCorrectos Then
                    If validaParesDevolver() Then
                        If saldoFactura > 0 Then
                            pnlGuardarDev.Enabled = True
                        ElseIf saldoFactura <= 0 AndAlso IdFacturaAplicar <> 0 Then
                            pnlGuardarDev.Enabled = True
                        Else
                            pnlGuardarDev.Enabled = False
                        End If
                    Else
                        pnlGuardarDev.Enabled = False
                    End If
                Else
                    pnlGuardarDev.Enabled = False
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Sólo se puede devolver como máximo la cantidad de artículos que indica la factura.")
                End If

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al validar la información: " & ex.Message)
            End Try
        End If
    End Sub

    Private Function validaParesDevolver() As Boolean
        Dim paresTotal As Integer = 0
        Dim paresDevueltos As Integer = 0
        Dim paresDevolver As Integer = 0
        Dim blnParesCorrectos As Boolean = True

        For i As Integer = 0 To gvwListado.RowCount - 1
            If Not IsDBNull(gvwListado.GetRowCellValue(i, "PARES")) And Not IsDBNull(gvwListado.GetRowCellValue(i, "PARES DEVUELTOS")) And Not IsDBNull(gvwListado.GetRowCellValue(i, "PARES DEVOLVER")) Then
                paresTotal = gvwListado.GetRowCellValue(i, "PARES")
                paresDevueltos = gvwListado.GetRowCellValue(i, "PARES DEVUELTOS")
                paresDevolver = gvwListado.GetRowCellValue(i, "PARES DEVOLVER")
                If paresDevolver + paresDevueltos > paresTotal Then
                    blnParesCorrectos = False
                ElseIf paresDevolver < 0 Then
                    blnParesCorrectos = False
                End If
            End If
        Next

        Return blnParesCorrectos
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim vXmlCeldas As XElement = New XElement("Detalles")
        Dim paresDevolver As Integer = 0

        For i As Integer = 0 To gvwListado.RowCount - 1
            If Not IsDBNull(gvwListado.GetRowCellValue(i, "PARES DEVOLVER")) AndAlso CInt(gvwListado.GetRowCellValue(i, "PARES DEVOLVER")) > 0 Then
                Dim vNodo As XElement = New XElement("Detalle")
                vNodo.Add(New XAttribute("ProductoEstiloId", gvwListado.GetRowCellValue(i, "ID ARTICULO")))
                vNodo.Add(New XAttribute("Cantidad", gvwListado.GetRowCellValue(i, "PARES DEVOLVER")))
                vNodo.Add(New XAttribute("Descripcion", gvwListado.GetRowCellValue(i, "DESCRIPCION")))
                vNodo.Add(New XAttribute("PrecioUnitario", gvwListado.GetRowCellValue(i, "PRECIO")))
                vXmlCeldas.Add(vNodo)
                paresDevolver += CInt(gvwListado.GetRowCellValue(i, "PARES DEVOLVER"))
            End If
        Next

        If paresDevolver = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe capturar los pares a devolver.")
        ElseIf Not validaParesDevolver Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de verificar los pares a devolver.")
        Else

            Dim objMensajeConf As New Tools.ConfirmarForm With {
                       .mensaje = "¿Está seguro de guardar la devolución preliminar? Este proceso no se podrá revertir."
                   }
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim objBU As New Proveedores.BU.DevolucionesPreliminares_BU
                    Dim dtResultado As New DataTable
                    dtResultado = objBU.insertarDevolucionPreliminar(vXmlCeldas.ToString(), documentoIds(0), IdFacturaAplicar, emisorSayId, receptorSayId)

                    If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                        If dtResultado.Rows(0).Item("mensaje") = "EXITO" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se guardó correctamente la devolución preliminar.")
                            Me.Close()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al guardar la devolución preliminar: " & dtResultado.Rows(0).Item("mensaje"))
                        End If
                    End If
                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
                End Try
            End If
        End If
    End Sub

#End Region
End Class