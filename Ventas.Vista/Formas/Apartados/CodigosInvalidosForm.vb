Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CodigosInvalidosForm

    Public ListaCodigosInvalidos As New List(Of String)
    Public numApartado As Integer

    Private Sub CodigosInvalidosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaCodigosInvalidos.Sort()
        grdCodigosInvalidos.DataSource = ListaCodigosInvalidos
        gridCodigosDiseño(grdCodigosInvalidos)
    End Sub

    Private Sub gridCodigosDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns("Value").Header.Caption = "Código - Razón"
        grid.DisplayLayout.Bands(0).Columns("Value").CharacterCasing = CharacterCasing.Upper


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdCodigosInvalidos
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

            nombreDocumento = "\Pares_InvalidosConfirmacion_Apartado_" + numApartado.ToString() + "_"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
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
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class