Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports Infragistics.Documents.Excel

Public Class ResumenApartadosPPCP_Form

    Public UltimaDistribucion As String = ""
    Public ApartadosGenerados As Integer = 0 '0 = no generados, 1 = generados
    Public Disponibilidad_Distribucion As Integer = 0 '0 = disponibilidad, 1 = distribucion

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ResumenApartadosPPCP_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBu As New Negocios.ApartadosBU
        If Disponibilidad_Distribucion = 0 Then
            grdResumenGeneral.DataSource = objBu.consultaResumenApartadosGenerados(4, ApartadosGenerados)
            gridResumenGeneralDiseño(grdResumenGeneral)
        Else
            grdResumenGeneral.DataSource = objBu.consultaResumenApartadosGenerados(1, ApartadosGenerados)
            gridResumenGeneralDiseño(grdResumenGeneral)
        End If
        grdResumenNaves.DataSource = objBu.consultaResumenApartadosGenerados(2, ApartadosGenerados)
        gridResumenNaveDiseño(grdResumenNaves)
        grdResumenCliente.DataSource = objBu.consultaResumenApartadosGenerados(3, ApartadosGenerados)
        gridResumenClientesDiseño(grdResumenCliente)
        lblFechaUltimaDistribucion.Text = UltimaDistribucion
    End Sub


    Private Sub gridResumenClientesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("Prs Apart").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").Format = "n0"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 0
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        'grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        'grid.DisplayLayout.Override.SelectTypeCol = SelectType.None

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        grid.DisplayLayout.Bands(0).Summaries.Clear()

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Apart"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

    End Sub

    Private Sub gridResumenGeneralDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("id").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Columna1").Header.Caption = "1"
        grid.DisplayLayout.Bands(0).Columns("Columna1").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna2").Header.Caption = "2"
        grid.DisplayLayout.Bands(0).Columns("Columna2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna2").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Columna2").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Columna3").Header.Caption = "3"
        grid.DisplayLayout.Bands(0).Columns("Columna3").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna4").Header.Caption = "4"
        grid.DisplayLayout.Bands(0).Columns("Columna4").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna4").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Columna4").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Columna5").Header.Caption = "5"
        grid.DisplayLayout.Bands(0).Columns("Columna5").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna6").Header.Caption = "6"
        grid.DisplayLayout.Bands(0).Columns("Columna6").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Columna7").Header.Caption = "7"
        grid.DisplayLayout.Bands(0).Columns("Columna7").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 1
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        ' grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        grid.DisplayLayout.Override.SelectTypeCol = SelectType.None
        grid.DisplayLayout.Bands(0).ColHeadersVisible = False
        grid.DisplayLayout.Bands(0).HeaderVisible = False
        grid.DisplayLayout.Appearance.FontData.SizeInPoints = 8

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        grid.Rows(0).Appearance.BackColor = Color.LightSteelBlue
        grid.Rows(1).Cells("Columna2").Hidden = True
        grid.Rows(2).Appearance.BackColor = Color.LightSteelBlue
        grid.Rows(3).Cells("Columna2").Hidden = True
        grid.Rows(4).Appearance.BackColor = Color.LightSteelBlue
        If grid.Rows.Count < 8 Then
            grid.Rows(5).Cells("Columna2").Hidden = True
        End If
        If grid.Rows.Count >= 8 Then
            grid.Rows(6).Cells("Columna2").Hidden = True
            grid.Rows(7).Cells("Columna2").Hidden = True
            grid.Rows(9).Cells("Columna2").Hidden = True
            grid.Rows(10).Cells("Columna2").Hidden = True
            grid.Rows(12).Cells("Columna2").Hidden = True
            grid.Rows(13).Appearance.BackColor = Color.LightSteelBlue
        End If




    End Sub

    Private Sub gridResumenNaveDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("Id").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Nave").Header.Caption = "Nave"
        grid.DisplayLayout.Bands(0).Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prs Antes").Header.Caption = "Prs Antes"
        grid.DisplayLayout.Bands(0).Columns("Prs Antes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prs Antes").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prs Antes").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").Header.Caption = "Prs Apart"
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prs Apart").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Prs Despues").Header.Caption = "Prs Despues"
        grid.DisplayLayout.Bands(0).Columns("Prs Despues").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prs Despues").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prs Despues").Format = "n0"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grid.DisplayLayout.Override.RowSelectorWidth = 1
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        'grid.DisplayLayout.Override.SelectTypeCol = SelectType.None
        grid.DisplayLayout.Appearance.FontData.SizeInPoints = 8

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        grid.DisplayLayout.Bands(0).Summaries.Clear()


        Dim summary1, summary2, summary3 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Antes", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Antes"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Apart", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Apart"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Despues", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Despues"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right

    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm

        Dim wbResumen As Workbook
        Dim wsResumenGeneral, wsResumenNaves, wsResumenClientes As Worksheet

        grid = grdResumenGeneral
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 And grdResumenNaves.Rows.GetFilteredInNonGroupByRows.Count > 0 And grdResumenCliente.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Resumen_Apartados_Generados"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    wbResumen = New Workbook()
                    wsResumenGeneral = wbResumen.Worksheets.Add("Resumen General")
                    gridExcelExporter.Export(grid, wsResumenGeneral, 1, 1)
                    wsResumenNaves = wbResumen.Worksheets.Add("Resumen Naves")
                    gridExcelExporter.Export(grdResumenNaves, wsResumenNaves, 1, 1)
                    wsResumenClientes = wbResumen.Worksheets.Add("Resumen Clientes")
                    gridExcelExporter.Export(grdResumenCliente, wsResumenClientes, 1, 1)
                    wbResumen.Save(.SelectedPath + nombreDocumento + fecha_hora + ".xls")
                    'gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class