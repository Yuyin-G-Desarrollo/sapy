Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class AntiguedadInventarioForm

    Private Sub AntiguedadInventarioForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        MostrarMensajeAvisoEspera()
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)
        poblar_gridListaInventarioAntiguedad(gridInventarioAntiguedad)
        rdoInventarioStock.Checked = True
    End Sub

    Private Sub MostrarMensajeAvisoEspera()        
        show_message("Advertencia", "Esta consulta puede tomar varios segundos en desplegarse")
    End Sub

    Public Sub poblar_gridListaInventarioAntiguedad(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Me.Cursor = Cursors.WaitCursor
        grid.DataSource = Nothing
        Dim cedis As Integer
        Dim objBU As New Negocios.InventarioBU
        Dim Tabla_ListaInventarioAntiguedad As New DataTable

        cedis = cboxNaveAlmacen.SelectedValue

        Try
            If rdoInventarioPrevendido.Checked = True Then
                MostrarMensajeAvisoEspera()
                Tabla_ListaInventarioAntiguedad = objBU.ListadoInventario_Antiguo_Prevendido(cedis)
            End If
            If rdoInventarioStock.Checked = True Then
                MostrarMensajeAvisoEspera()
                Tabla_ListaInventarioAntiguedad = objBU.ListadoInventarioAntiguedad(cedis)
            End If
            If rdoInventarioPrevendido.Checked = False And rdoInventarioStock.Checked = False Then
                Tabla_ListaInventarioAntiguedad = objBU.ListadoInventarioAntiguedad(cedis)
            End If
            grid.DataSource = Tabla_ListaInventarioAntiguedad
            gridListaUbicacionDiseno(grid)
            lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
            lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString
        Catch ex As Exception
            show_message("Error", ex.ToString)
            Me.Close()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gridListaUbicacionDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        If rdoInventarioPrevendido.Checked = True Then
            grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Cliente").CellAppearance.TextHAlign = HAlign.Left
        End If
        grid.DisplayLayout.Bands(0).Columns("PE_ID").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Marca").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("Colección").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("Temporada").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("ModeloSAY").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Piel").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("Color").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("Corrida").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("Talla").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("FEntrada").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FEntrada").Style = ColumnStyle.DateTime
        grid.DisplayLayout.Bands(0).Columns("Existencia").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("DiasAntig").CellAppearance.TextHAlign = HAlign.Right

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Existencia")
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,###}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            Dim ret As DialogResult = .ShowDialog
            If ret = Windows.Forms.DialogResult.OK Then
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.gridInventarioAntiguedad, .SelectedPath + "\Inventario_Antiguedad_" + fecha_hora + ".xlsx")
                Process.Start(fbdUbicacionArchivo.SelectedPath + "\Inventario_Antiguedad_" + fecha_hora + ".xlsx")
            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub
    
    Private Sub btnActualizarListadoInventario_Click(sender As Object, e As EventArgs) Handles btnActualizarListadoInventario.Click
        MostrarMensajeAvisoEspera()
        poblar_gridListaInventarioAntiguedad(gridInventarioAntiguedad)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        poblar_gridListaInventarioAntiguedad(gridInventarioAntiguedad)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridInventarioAntiguedad.DataSource = Nothing
        poblar_gridListaInventarioAntiguedad(gridInventarioAntiguedad)
        rdoInventarioPrevendido.Checked = False
        rdoInventarioStock.Checked = False
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 26
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 78
    End Sub
End Class