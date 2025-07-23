Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_BitacoraDev_Form

    Public objDev As New Entidades.DevolucionCliente

    Private Sub FormatoGrid()
       ' asignaFormato_Columna()
        With grdBitacora.DisplayLayout
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False

        End With
    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna()
        For Each col In grdBitacora.DisplayLayout.Bands(0).Columns
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

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New Tools.AdvertenciaForm
        grid = grdBitacora
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Bitácora_Devoluciones_Cliente_"
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
                Dim mensajeExito As New Tools.ExitoForm
                Cursor = Cursors.Default
                mensajeExito.mensaje = "Los datos se exportaron correctamente"
                mensajeExito.ShowDialog()
                Process.Start(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
            End If
            
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdBitacora_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdBitacora.InitializeLayout
        FormatoGrid()
        grdBitacora.DisplayLayout.Bands(0).Columns("FechaMovimiento").Style = ColumnStyle.DateTime
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_BitacoraDev_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InicializarGrid()
        grdBitacora.DataSource = (New Negocios.DevolucionClientesBU).ConsultaBitacora(objDev.Devolucionclienteid)
        lblFolioDevolución.Text = objDev.Devolucionclienteid
        lblClienteDevolucion.Text = objDev.NombreCliente
    End Sub
End Class