Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization

Public Class ReporteIncidenciasPeriodoForm


    Dim tablaColaboradorGloblal As New DataTable
    Dim banderaFecha As Boolean = False
    '
    Private Sub ReporteIncidenciasPeriodoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listado_naves()
        dtpFechaInicio.MaxDate = Now.Date
        dtpFechaInicio.Value = Now.Date
        dtpFechaTermino.MaxDate = Now.Date
        dtpFechaTermino.Value = Now.Date
        Me.Left = 0
        Me.Top = 0
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cboxNave.SelectedIndex > 0 Then

            'listado_periodos_asistencia()
            'listado_areas()

        End If

    End Sub


    Private Sub btnColaborador_Click(sender As Object, e As EventArgs) Handles btnColaborador.Click

        '  If cboxNave.SelectedValue < 1 Then Return
        If Not cboxNave.SelectedValue < 1 Then
            If banderaFecha = True Then
                lblFechaInicio.ForeColor = Color.Black

                lblNave.ForeColor = Color.Black
                Dim listado As New ListadoParametrosBusquedaForm
                Dim tablaColaboradores As New DataTable
                listado.tipo_busqueda = 6
                listado.id_parametros = cboxNave.SelectedValue
                Dim listaParametroID As New List(Of String)
                'For Each row As UltraGridRow In gridColaboradores.Rows
                '    Dim parametro As String = row.Cells(0).Text
                '    listaParametroID.Add(parametro)
                'Next
                listado.listaParametroID = listaParametroID
                listado.ShowDialog(Me)
                If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
                If listado.listParametros.Rows.Count = 0 Then
                    show_message("Advertencia", "Tiene que seleccionar los colaboradores que aparecerán en el reporte")
                    Return
                End If


                ''aqui metodo del boton mostrar

                tablaColaboradores = listado.listParametros
                tablaColaboradorGloblal = tablaColaboradores
                poblarGridIncidencias(gridReporteIncidencias, tablaColaboradores)
            Else
                lblFechaInicio.ForeColor = Color.Red
            End If
        Else

            lblNave.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnAceptarProductividad_Click(sender As Object, e As EventArgs)
        'poblar_gridReporteIncidencias(gridReporteIncidencias)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter


        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        grid = gridReporteIncidencias
        nombreDocumento = "\Reporte_Incidencias"

        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Try
            gridReporteIncidencias.PrintPreview()
            gridReporteIncidencias.Print()
        Catch exc As Exception
            MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelarProductividad_Click(sender As Object, e As EventArgs) Handles btnCancelarProductividad.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarProductividad_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductividad.Click
        gridReporteIncidencias.DataSource = Nothing
    End Sub


    Private Sub grid_complejo_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Bands(0).Columns(3).Hidden = True
            .Bands(0).Columns(4).Hidden = True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub



    'Public Sub poblar_gridReporteIncidencias(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

    '    If gridColaboradores.Rows.Count > 0 Then
    '        grid.DataSource = Nothing
    '        Dim nave_almacen As String = String.Empty
    '        Dim objBU As New Negocios.ControlAsistenciaBU
    '        Dim Tabla_ReporteIncidencias As New DataTable

    '        Dim fecha_inicio As DateTime
    '        Dim fecha_termino As DateTime
    '        Dim lColaborador As String = String.Empty

    '        fecha_inicio = dtpFechaInicio.Value
    '        fecha_termino = dtpFechaTermino.Value

    '        ''COLABORADORES
    '        For Each row As UltraGridRow In gridColaboradores.Rows
    '            If row.Index = 0 Then
    '                lColaborador += CStr(row.Cells("Parámetro").Value)
    '            Else
    '                lColaborador += ", " + CStr(row.Cells("Parámetro").Value)
    '            End If
    '        Next

    '        Tabla_ReporteIncidencias = objBU.Resumen_Incidencias(lColaborador, fecha_inicio, fecha_termino)

    '        grid.DataSource = Tabla_ReporteIncidencias

    '        If Not grid.Rows.Count > 0 Then
    '            btnImprimir.Enabled = False
    '            btnExportar.Enabled = False
    '        Else
    '            btnImprimir.Enabled = True
    '            btnExportar.Enabled = True
    '        End If

    '        gridReporteIncidenciasDiseno(grid)

    '    Else
    '        show_message("Advertencia", "Tiene que seleccionar los colaboradores que aparecerán en el reporte")
    '    End If

    'End Sub

    Private Sub gridReporteIncidenciasDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        'grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        'grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").Style = ColumnStyle.DateTime
        'grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").GroupByMode = GroupByMode.Text
        'grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").CellAppearance.TextHAlign = HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Bands(0).Columns("Inicio").Style = ColumnStyle.DateTime
        'grid.DisplayLayout.Bands(0).Columns("Inicio").GroupByMode = GroupByMode.Text
        'grid.DisplayLayout.Bands(0).Columns("Inicio").CellAppearance.TextHAlign = HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Inicio").AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Bands(0).Columns("Fin").Style = ColumnStyle.DateTime
        'grid.DisplayLayout.Bands(0).Columns("Fin").GroupByMode = GroupByMode.Text
        'grid.DisplayLayout.Bands(0).Columns("Fin").CellAppearance.TextHAlign = HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Fin").AllowRowFiltering = DefaultableBoolean.False

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        ''grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grid.DisplayLayout.Override.RowSelectorWidth = 35
        ''grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

        'grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        ''grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        'grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        ''grid.DisplayLayout.Bands(0).Columns("Status").Style = ColumnStyle.
        'gridReporteIncidencias
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        'grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        'grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        'For Each row In grid.Rows
        '    If row.Cells("Status").Value = 23 Then
        '        row.Cells("Status").Appearance.BackColor = Color.Green
        '        row.Cells("Status").Appearance.ForeColor = Color.Green
        '        row.Cells("Status").Value = "Completado"
        '    ElseIf row.Cells("Status").Value = 21 Then
        '        row.Cells("Status").Appearance.BackColor = Color.Yellow
        '        row.Cells("Status").Appearance.ForeColor = Color.Yellow
        '        row.Cells("Status").Value = "Por validar"
        '    ElseIf row.Cells("Status").Value = 22 Then
        '        row.Cells("Status").Appearance.BackColor = Color.Blue
        '        row.Cells("Status").Appearance.ForeColor = Color.Blue
        '        row.Cells("Status").Value = "Validado"
        '    ElseIf row.Cells("Status").Value = 20 Then
        '        'Dim objBU As New Negocios.AlmacenBU
        '        'If objBU.Plataforma_completa_lista_para_validacion(row.Cells("Ocupacion Carrito ID").Value.ToString) Then
        '        '    objBU.Editar_Status_Plataforma(1, row.Cells("Ocupacion Carrito ID").Value, 21)
        '        '    row.Cells("Status").Appearance.BackColor = Color.Yellow
        '        '    row.Cells("Status").Appearance.ForeColor = Color.Yellow
        '        '    row.Cells("Status").Value = Nothing
        '        '    row.Cells("Status").Value = "Por validar"
        '        'Else
        '        row.Cells("Status").Appearance.BackColor = Color.Red
        '        row.Cells("Status").Appearance.ForeColor = Color.Red
        '        row.Cells("Status").Value = "Pendiente"
        '        'End If
        '    ElseIf row.Cells("Status").Value = 19 Then
        '        row.Cells("Status").Appearance.BackColor = Color.Purple
        '        row.Cells("Status").Appearance.ForeColor = Color.Purple
        '        row.Cells("Status").Value = "Sin operador"
        '    ElseIf row.Cells("Status").Value = 24 Then
        '        row.Cells("Status").Appearance.BackColor = Color.Gray
        '        row.Cells("Status").Appearance.ForeColor = Color.Gray
        '        row.Cells("Status").Value = "Inconcluso"
        '    End If
        'Next

        ''Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Min. Descargando")
        'Dim summary1, summary2, summary3, summary4, summary5, summary6 As SummarySettings
        'summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Min. Descargando", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Minutos"))
        'summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Atados Plat", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Atados Plat"))
        'summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Prs Plat", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Plat"))
        'summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Atados Ubic", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Atados Ubic"))
        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Atados Desc", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Atados Desc"))
        'summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Prs Desc", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Desc"))
        'grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        'summary1.DisplayFormat = "{0:0,0}"
        'summary1.Appearance.TextHAlign = HAlign.Right
        'summary2.DisplayFormat = "{0:0,0}"
        'summary2.Appearance.TextHAlign = HAlign.Right
        'summary3.DisplayFormat = "{0:0,0}"
        'summary3.Appearance.TextHAlign = HAlign.Right
        'summary4.DisplayFormat = "{0:0,0}"
        'summary4.Appearance.TextHAlign = HAlign.Right
        'summary5.DisplayFormat = "{0:0,0}"
        'summary5.Appearance.TextHAlign = HAlign.Right
        'summary6.DisplayFormat = "{0:0,0}"
        'summary6.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
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

    Private Sub gridReporteIncidencias_DoubleClick(sender As Object, e As MouseEventArgs) Handles gridReporteIncidencias.DoubleClick

        If Not Me.gridReporteIncidencias.ActiveRow.IsDataRow Then Return

        If IsNothing(gridReporteIncidencias.ActiveRow) Then Return
        Dim row As UltraGridRow = gridReporteIncidencias.ActiveRow

        'Dim form As New DetallePlataformaForm
        'form.ocupacion_carritoid = CInt(row.Cells("Ocupacion Carrito ID").Value)
        'form.Show()

        'MessageBox.Show(row.Cells("PLATAFORMA").Value.ToString)

    End Sub

    Private Sub gridReporteIncidencias_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs)
        If Not gridReporteIncidencias.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If
    End Sub

    Private Sub gridReporteIncidencias_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs)

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridReporteIncidencias_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs)

        e.PrintDocument.DefaultPageSettings.Landscape = True
        e.PrintLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        ''e.PrintPreviewSettings.Zoom = 100
        e.PrintLayout.Override.RowAlternateAppearance.BackColor = Color.White
        e.PrintDocument.DefaultPageSettings.Margins.Left = 0
        e.PrintDocument.DefaultPageSettings.Margins.Right = 0

        With e.PrintLayout

            .Bands(0).Columns(1).Hidden = True
            .Bands(0).Columns(2).Header.Caption = "PAR"
            .Bands(0).Columns(3).Header.Caption = "ATADO"

        End With

    End Sub


    'Asigna el formato de las columnas de ultragrid segun el estandar de diseño
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = Format("N0")

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Double") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = Format("N1")

            End If

            If col.DataType.Name.ToString.Equals("String") Then
                'col.Format = "##,#"
                col.CellAppearance.TextHAlign = HAlign.Left
                'If col.Header.Caption.Equals("Teléfono") Then
                '    col.MaskInput = "+## (###) ###-####"
                '    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                '    col.CellAppearance.TextHAlign = HAlign.Right
                'ElseIf col.Header.Caption.Equals("Extensión") Then
                '    col.MaskInput = "ext: 9999"
                '    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                '    col.CellAppearance.TextHAlign = HAlign.Right
                'Else
                '    col.CellAppearance.TextHAlign = HAlign.Left
                'End If

            End If

        Next

    End Sub
    'Muestra el form de mensaje
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



    Public Sub poblarGridIncidencias(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal tablaColaboradores As DataTable)

        If tablaColaboradores.Rows.Count > 0 Then
            grid.DataSource = Nothing
            Dim nave_almacen As String = String.Empty
            Dim objBU As New Negocios.ControlAsistenciaBU
            Dim Tabla_ReporteIncidencias As New DataTable

            Dim fecha_inicio As DateTime
            Dim fecha_termino As DateTime
            Dim lColaborador As String = String.Empty

            fecha_inicio = dtpFechaInicio.Value
            fecha_termino = dtpFechaTermino.Value

            ''COLABORADORES
            'For Each row As UltraGridRow In gridColaboradores.Rows
            '    If row.Index = 0 Then
            '        lColaborador += CStr(row.Cells("Parámetro").Value)
            '    Else
            '        lColaborador += ", " + CStr(row.Cells("Parámetro").Value)
            '    End If
            'Next

            Me.Cursor = Cursors.WaitCursor
            Dim pos As Integer = 0
            For Each rowDt As DataRow In tablaColaboradores.Rows
                pos = tablaColaboradores.Rows.IndexOf(rowDt)
                If pos = 0 Then
                    lColaborador += rowDt.Item("Parámetro").ToString
                Else
                    lColaborador += ", " + rowDt.Item("Parámetro").ToString
                End If
                ' lColaborador = lColaborador + rowDt.Item("Parámetro").ToString + ","
            Next

            Tabla_ReporteIncidencias = objBU.Resumen_Incidencias(lColaborador, fecha_inicio, fecha_termino)

            grid.DataSource = Tabla_ReporteIncidencias

            If Not grid.Rows.Count > 0 Then
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            Else
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            End If

            gridReporteIncidenciasDiseno(grid)
            Me.Cursor = Cursors.Default
        Else
            show_message("Advertencia", "Tiene que seleccionar los colaboradores que aparecerán en el reporte")
        End If

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 42
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 121
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        poblarGridIncidencias(gridReporteIncidencias, tablaColaboradorGloblal)
    End Sub

    Private Sub dtpFechaInicio_DropDown(sender As Object, e As EventArgs) Handles dtpFechaInicio.DropDown
        banderaFecha = True
    End Sub
End Class