Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ApartadosEnOT_NoCancelables

    Public dtApartadosEnOT As New DataTable
    Public validarCheckDetallada As Boolean = False

    Private Sub ApartadosEnOT_NoCancelables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdApartadosEnOT.DataSource = dtApartadosEnOT
        gridListadoParametrosDiseno(grdApartadosEnOT)
        'If validarCheckDetallada = True Then
        lblExportar.Visible = True
            btnExportarExcel.Visible = True
            Me.Size = New System.Drawing.Size(661, 390)
            btnAceptar.Left = (Me.Width - btnAceptar.Width) / 2
        'End If
    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        asignaFormato_Columna(grid)

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        If grid.DisplayLayout.Bands(0).Columns.Count > 5 Then
            grid.DisplayLayout.Bands(0).Columns(5).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            grid.DisplayLayout.Bands(0).Columns(7).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            For Each row As UltraGridRow In grdApartadosEnOT.Rows
                If row.Cells("StatusOT").Value = "FACTURADO" Or row.Cells("StatusOT").Value = "ENTREGADA" Or row.Cells("StatusOT").Value = "CANCELADA" Or row.Cells("StatusOT").Value = "EN RUTA" Or row.Cells("StatusOT").Value = "POR FACTURAR" Then
                    row.Cells("StatusOT").Appearance.ForeColor = Color.Red
                Else
                    row.Cells("StatusOT").Appearance.ForeColor = Color.Green
                End If
            Next
        End If

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdApartadosEnOT
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Apartados_En_OT_NoCancelables"
        End If

        With fbdUbicacionArchivo
            .Reset()
            .Description = "Seleccione una carpeta"
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                Dim mensajeExito As New ExitoForm
                Cursor = Cursors.Default
                mensajeExito.mensaje = "Los datos se exportaron correctamente"
                mensajeExito.ShowDialog()

            End If
            .Dispose()
        End With
        Cursor = Cursors.Default
    End Sub
End Class