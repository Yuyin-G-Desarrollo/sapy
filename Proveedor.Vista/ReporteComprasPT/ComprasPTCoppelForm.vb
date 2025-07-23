Imports System.Windows.Forms
Imports System.Drawing
Imports System.Globalization
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools.modMensajes

Public Class ComprasPTCoppelForm

    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Dim lstPedidos As New List(Of String)

    Private Sub ComprasPTCoppelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        disenioPedidos()
    End Sub
    Private Sub txtPedidos_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPedidos.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidos.Text) Then Return

            lstPedidos.Add(txtPedidos.Text)
            grdPedidos.DataSource = Nothing
            grdPedidos.DataSource = lstPedidos
            grdPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedidos"

            txtPedidos.Text = String.Empty

        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        grdReporte.DataSource = Nothing
        lblNumRegistros.Text = "0"
        Dim rowsGrdPedidos As String = String.Empty
        If grdPedidos.Rows.Count = 0 Then
            msgAdvertencia.mensaje = "Debe capturar al menos un Pedido."
            msgAdvertencia.ShowDialog()

        Else
            Me.Cursor = Cursors.WaitCursor
            Try
                'grid pedido'
                For Each row As UltraGridRow In grdPedidos.Rows
                    If row.Index = 0 Then
                        rowsGrdPedidos += "" + row.Cells(0).Text.Trim + ""
                    Else
                        rowsGrdPedidos += "," + row.Cells(0).Text.Trim + ""
                    End If
                Next

                Dim obj As New Proveedores.BU.ConsultaComprasPT_BU
                Dim tabla As DataTable = obj.ObtenerCompradeProductoIngresadoCoppel(rowsGrdPedidos)
                If tabla.Rows.Count > 0 Then
                    grdReporte.DataSource = tabla
                    DisenioGrid()
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    lblNumRegistros.Text = tabla.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                    pnlParametros.Height = 27
                Else
                    msgAdvertencia.mensaje = "No se encontró información."
                    msgAdvertencia.ShowDialog()

                End If

            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Pares") Or col.FieldName.Contains("Total") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True And col.FieldName = "Pares" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
    End Sub



    Private Sub disenioPedidos()
        grdPedidos.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

        grdPedidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPedidos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdPedidos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPedidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPedidos.DisplayLayout.Override.RowSelectorWidth = 35
        grdPedidos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdPedidos.Rows
            row.Activation = Activation.NoEdit
        Next

        grdPedidos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdPedidos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        'grdPedidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        'grdPedidos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        'grdPedidos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        'grdPedidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        'grdPedidos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdPedidos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti



    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 198
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPedidos.DataSource = Nothing
        grdReporte.DataSource = Nothing
        lstPedidos.Clear()
        lblNumRegistros.Text = "0"
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "ComprasPTCoppel"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
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

    Private Sub grdPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidos.DeleteSelectedRows(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        grdPedidos.DataSource = Nothing
        lstPedidos.Clear()
    End Sub

    Private Sub btnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        grdPedidos.DataSource = Nothing
        lstPedidos.Clear()

    End Sub

End Class