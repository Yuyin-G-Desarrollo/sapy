Imports DevExpress.Export
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class ReporteOrdenesEnProcesoPorMesForm
    Public dtReporte As DataTable
    Private Sub ReporteOrdenesEnProcesoPorMesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        WindowState = FormWindowState.Maximized
        Me.Left = 0
        Me.Top = 0
        grdReporteMes.DataSource = dtReporte
        estiloGridReporte()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub estiloGridReporte()
        Dim meses As Integer = gridVReporteMes.Columns.Count
        'acomoda las columnas del ancho automaticamente

        gridVReporteMes.Columns("año").Visible = False

        For i As Integer = 3 To meses - 1
            gridVReporteMes.Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gridVReporteMes.Columns(i).DisplayFormat.FormatString = "N0"
            gridVReporteMes.Columns(i).OptionsColumn.AllowEdit = False
            gridVReporteMes.Columns(i).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
            gridVReporteMes.BestFitColumns(i)
        Next

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gridVReporteMes.Columns
            If col.FieldName.Contains("navedesarrollo") = False And col.FieldName.Contains("coleccionsay") = False And col.FieldName.Contains("año") = False Then
                col.Caption = col.FieldName.Replace("(SUM)", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
        Next
        With gridVReporteMes
            .Columns("navedesarrollo").OptionsColumn.AllowEdit = False
            .Columns("coleccionsay").OptionsColumn.AllowEdit = False
            .Columns("navedesarrollo").AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
            .Columns("coleccionsay").AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
            .Columns("navedesarrollo").Caption = "Nave Desarrollo"
            .Columns("navedesarrollo").AppearanceCell.BackColor = Color.LightSteelBlue
            .Columns("coleccionsay").Width = 45
            .Columns("coleccionsay").Caption = "Colección SAY"
            .Columns("coleccionsay").AppearanceCell.BackColor = Color.LightSteelBlue

            .Columns("coleccionsay").Width = 280

        End With

        'Agrupamiento por columna
        gridVReporteMes.OptionsView.AllowCellMerge = True
    End Sub

    Private Sub gridVReporte_CellMerge(ByVal sender As Object, ByVal e As CellMergeEventArgs) Handles gridVReporteMes.CellMerge
        Dim view1 As GridView = sender
        e.Handled = True
        'sirve para hacer las divbisiones tomando en cuenta una columna (+1) en este caso toma a la columna de Lote como referencia
        'para todas las demás columnas
        If e.Column.FieldName = ("navedesarrollo") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column)).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        'Ask the user where to save the file to
        Dim SaveFileDialog As New SaveFileDialog()
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
            gridVReporteMes.OptionsPrint.AutoWidth = True
            gridVReporteMes.OptionsPrint.EnableAppearanceEvenRow = True
            gridVReporteMes.OptionsPrint.PrintPreview = True
            'Set the selected file as the filename
            filename = SaveFileDialog.FileName

            Dim exportOptions = New XlsxExportOptionsEx()
            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

            'Export the file via inbuild function
            DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
            gridVReporteMes.ExportToXlsx(filename, exportOptions)

            'If the file exists (i.e. export worked), then open it
            If System.IO.File.Exists(filename) Then
                Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If DialogResult = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start(filename)
                End If
            End If
        End If
    End Sub
End Class