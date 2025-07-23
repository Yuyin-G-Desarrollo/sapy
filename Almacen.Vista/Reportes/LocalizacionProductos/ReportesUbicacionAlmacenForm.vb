Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization
Imports System.Drawing.Printing
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class ReportesUbicacionAlmacenForm
    Dim operadores() As String
    Dim listPares_Atados As New List(Of String)
    Dim listaPedidosApartados As New List(Of String)
    Dim listaApartados As New List(Of String)

    Private Sub ReportesUbicacionAlmacenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicioProductividad.MaxDate = Now.Date
        dtpFechaInicioProductividad.Value = Now.Date
        dtpFechaTerminoProductividad.MaxDate = Now.Date
        dtpFechaTerminoProductividad.Value = Now.Date

        dtpFechaInicioInventarioInicial.MaxDate = Now.Date
        dtpFechaInicioInventarioInicial.Value = Now.Date
        dtpFechaTerminoInventarioInicial.MaxDate = Now.Date
        dtpFechaTerminoInventarioInicial.Value = Now.Date

        dtpFechaInicioOTCoppel.Value = Now.Date
        dtpFechaFinOTCoppel.Value = Now.Date

        dtpFechaInicioApartados.Value = Now.Date
        dtpFechaFinApartados.Value = Now.Date
        llenarComboReportesApartado()
        lblUltimaActualizacionApartados.Visible = False
        lblFechaUAApartados.Visible = False
        lblHoraUAApartados.Visible = False

        listado_naves()
        gridPares_Atados.DataSource = String.Empty
        gridColaboradores.DataSource = String.Empty
        grdColaboradoresOTCoppel.DataSource = String.Empty
        Label7.Visible = False
        lblFechaReporteProductividad.Visible = False
        lblHoraReporteProductividad.Visible = False
        Label8.Visible = False
        lblFechaHistoricoUbicaciones.Visible = False
        lblHoraHistoricoUbicaciones.Visible = False

        lblUltimaActualizacionOTCoppel.Visible = False
        lblFechaReporteOTCoppel.Visible = False
        lblHoraReporteOTCoppel.Visible = False



    End Sub

    Private Sub listado_naves()
        Dim dtDatosComboNave As New DataTable
        Dim objbu As New Almacen.Negocios.AlmacenBU

        dtDatosComboNave = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        cboxNave.DataSource = dtDatosComboNave
        cboxNave.DisplayMember = "Nave"
        cboxNave.ValueMember = "NaveSAYID"

        If cboxNave.SelectedIndex = 0 Then
            Dim dtDatosComboAlmacen As New DataTable
            dtDatosComboAlmacen.Columns.Add("bahi_almacen")

            Dim drFilaComboAlmacen As DataRow
            drFilaComboAlmacen = dtDatosComboAlmacen.NewRow()
            drFilaComboAlmacen("bahi_almacen") = "1"
            dtDatosComboAlmacen.Rows.Add(drFilaComboAlmacen)

            cboxAlmacen.DataSource = dtDatosComboAlmacen
            cboxAlmacen.ValueMember = "bahi_almacen"
            cboxAlmacen.DisplayMember = "bahi_almacen"
            cboxAlmacen.SelectedIndex = 0
        End If


        'Eliminar pestaña de COPPEL para los usuario del CEDIS de Comercializadora
        If dtDatosComboNave.AsEnumerable().Where(Function(x) x.Item("NaveSAYID") = 82).Count() = 0 Then
            tabReportesUbicacion.TabPages.Remove(tabReportesUbicacion.TabPages.Item(3))
        End If 'REEDITION



    End Sub

    Private Sub listado_almacen()

        'Try
        '    Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub cboxNave_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxNave.SelectionChangeCommitted
        listado_almacen()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty

        If tabReportesUbicacion.SelectedTab.Name <> tbpgReporteInventarioInicial.Name Then
            If tabReportesUbicacion.SelectedTab.Name = tbpgReporteProductividad.Name Then
                grid = gridReporteProductividad
                nombreDocumento = "\Reporte_Plataformas_"
            End If
            If tabReportesUbicacion.SelectedTab.Name = tbpgReporteHistorico.Name Then
                grid = gridHistoricoUbicaciones
                nombreDocumento = "\Reporte_Historico_Ubicaciones_"
            End If
            If tabReportesUbicacion.SelectedTab.Name = tbpgOTCoppel.Name Then
                grid = grdReporteOTCoppel
                nombreDocumento = "\Reporte_OTCoppel_" + cboxTipoReporte.SelectedItem.ToString + "_"
            End If
            If tabReportesUbicacion.SelectedTab.Name = tbpgApartados.Name Then
                grid = grdReportesApartados
                nombreDocumento = "\Reporte_Apartados_" + cmbApartadoTipoReporte.Text + "_"
            End If

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

                    show_message("Exito", "Los datos se exportaron correctamente")
                    .Dispose()
                End If

            End With
        Else
            ExportarExcelReporteInventarioInicial()
        End If


    End Sub

    Private Sub ExportarExcelReporteInventarioInicial()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog


        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        gridReporteInventarioInicial.ExportToXlsx(.SelectedPath + "\ReporteInventarioInicial_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        gridReporteInventarioInicial.ExportToXlsx(.SelectedPath + "\ReporteInventarioInicial_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ReporteInventario_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\ReporteInventarioInicial_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try
            Dim concepto As String = viewReporteInventarioInicial.GetRowCellValue(e.RowHandle, "concepto")
            If e.RowHandle >= 0 Then
                If e.AreaType <> DevExpress.Export.SheetAreaType.Header Then
                    If concepto = "INVENTARIO INICIAL SICY" Then
                        e.Formatting.BackColor = Color.LightSteelBlue
                        e.Formatting.Font.Color = Color.Black
                    End If
                    If concepto = "PARES INGRESADOS" Then
                        e.Formatting.BackColor = Color.LightSteelBlue
                        e.Formatting.Font.Color = Color.Black
                    End If
                    If concepto = "SALIDAS DE ALMACÉN" Then
                        e.Formatting.BackColor = Color.LightSteelBlue
                        e.Formatting.Font.Color = Color.Black
                    End If
                    If concepto = "INVENTARIO FINAL SICY" Then
                        e.Formatting.BackColor = Color.LightSteelBlue
                        e.Formatting.Font.Color = Color.Black
                    End If
                    If concepto = "MOVIMIENTOS ALMACÉN" Then
                        e.Formatting.BackColor = Color.LightSteelBlue
                        e.Formatting.Font.Color = Color.Black
                    End If
                End If
            End If


            Cursor = Cursors.Default
            e.Handled = True

        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        If tabReportesUbicacion.SelectedTab.Name = tbpgReporteProductividad.Name Then
            Try
                gridReporteProductividad.PrintPreview()
                gridReporteProductividad.Print()
            Catch exc As Exception
                MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If tabReportesUbicacion.SelectedTab.Name = tbpgReporteHistorico.Name Then
            Try
                gridHistoricoUbicaciones.PrintPreview()
                gridHistoricoUbicaciones.Print()
            Catch exc As Exception
                MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If tabReportesUbicacion.SelectedTab.Name = tbpgReporteInventarioInicial.Name Then
            Try
                gridReporteInventarioInicial.PrintDialog()
                gridReporteInventarioInicial.Print()
            Catch exc As Exception
                MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If tabReportesUbicacion.SelectedTab.Name = tbpgOTCoppel.Name Then
            Try
                grdReporteOTCoppel.PrintPreview()
                grdReporteOTCoppel.Print()
            Catch exc As Exception
                MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If tabReportesUbicacion.SelectedTab.Name = tbpgApartados.Name Then
            Try

                grdReportesApartados.PrintPreview(RowPropertyCategories.All)
                grdReportesApartados.Print(RowPropertyCategories.All)
            Catch exc As Exception
                MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub tabReportesUbicacion_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabReportesUbicacion.Selecting
        Dim tabControl As TabControl = sender
        Dim tabpage As TabPage = tabControl.SelectedTab

        If tabpage.Name.Equals("tbpgReporteHistorico") Then
            If Not gridHistoricoUbicaciones.Rows.Count > 0 Then
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            Else
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            End If
        ElseIf tabpage.Name.Equals("tbpgReporteProductividad") Then
            If Not gridReporteProductividad.Rows.Count > 0 Then
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            Else
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            End If
        ElseIf tabpage.Name.Equals("tbpgReporteInventarioInicial") Then
            'If Not gridReporteInventarioInicial.Rows.Count > 0 Then
            '    btnImprimir.Enabled = False
            '    btnExportar.Enabled = False
            'Else
            '    btnImprimir.Enabled = True
            '    btnExportar.Enabled = True
            'End If
        End If

    End Sub

#Region "REPORTE DE PRODUCTIVIDAD (Plataformas)"

    Private Sub btnColaborador_Click(sender As Object, e As EventArgs) Handles btnColaborador.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridColaboradores.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridColaboradores.DataSource = listado.listParametros
        With gridColaboradores
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operador"
        End With
    End Sub

    Private Sub btnAceptarProductividad_Click(sender As Object, e As EventArgs) Handles btnAceptarProductividad.Click
        Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.AlmacenBU
        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Cursor = Cursors.Default
            Return
        End If

        poblar_gridReporteProductividad(gridReporteProductividad)

        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime
        Dim lColaborador As String = String.Empty

        fecha_inicio = dtpFechaInicioProductividad.Value
        fecha_termino = dtpFechaTerminoProductividad.Value

        Dim platSoP = objBU.ConsultaDePlataformas(fecha_inicio, fecha_termino)
        lblPUCP.Text = platSoP.Rows(0).Item("UBICADAS CON").ToString
        lblPUSP.Text = platSoP.Rows(0).Item("UBICADAS SIN").ToString

        Label7.Visible = True
        lblFechaReporteProductividad.Visible = True
        lblHoraReporteProductividad.Visible = True
        lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
        lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelarProductividad_Click(sender As Object, e As EventArgs) Handles btnCancelarProductividad.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarProductividad_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductividad.Click
        gridReporteProductividad.DataSource = Nothing
        gridColaboradores.DataSource = Nothing
    End Sub

    Private Sub gboxTipoReporteProductividad_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxTipoReporteProductividad.MouseDoubleClick
        If gboxTipoReporteProductividad.Dock = DockStyle.Fill Then
            gboxTipoReporteProductividad.Dock = DockStyle.None
        Else
            gboxTipoReporteProductividad.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub gridColaboradores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridColaboradores.InitializeLayout
        grid_complejo_diseño(gridColaboradores)
        gridColaboradores.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
    End Sub

    Private Sub gridColaboradores_KeyDown(sender As Object, e As KeyEventArgs) Handles gridColaboradores.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridColaboradores.DeleteSelectedRows(False)

    End Sub

    Public Sub poblar_gridReporteProductividad(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing
        Dim nave_almacen As String = String.Empty
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ReporteProductividad As New DataTable
        Dim CEDIS As Integer = cboxNave.SelectedValue
        objBU.ValidarPlataformas()
        Dim nave_almacen_split() As String
        nave_almacen = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        nave_almacen_split = nave_almacen.Split(",")

        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime
        Dim lColaborador As String = String.Empty

        fecha_inicio = dtpFechaInicioProductividad.Value
        fecha_termino = dtpFechaTerminoProductividad.Value

        ''COLABORADORES
        For Each row As UltraGridRow In gridColaboradores.Rows
            If row.Index = 0 Then
                lColaborador += row.Cells("Parámetro").Text
            Else
                lColaborador += ", " + row.Cells("Parámetro").Text
            End If
        Next

        If rbtnProductividadPlataforma.Checked Then
            Tabla_ReporteProductividad = objBU.Almacen_ReporteProductividadPlataforma(fecha_inicio, fecha_termino, lColaborador, CEDIS)
        End If

        grid.DataSource = Tabla_ReporteProductividad

        If Not grid.Rows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If

        gridReporteProductividadDiseno(grid)

    End Sub

    Private Sub gridReporteProductividadDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").Style = ColumnStyle.DateTime
        grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Carga(Hr)").AllowRowFiltering = DefaultableBoolean.False
        ' grid.DisplayLayout.Bands(0).Columns("Inicio").Style = ColumnStyle.DateTime
        'grid.DisplayLayout.Bands(0).Columns("Inicio").GroupByMode = GroupByMode.Text
        ' grid.DisplayLayout.Bands(0).Columns("Inicio").CellAppearance.TextHAlign = HAlign.Right
        ' grid.DisplayLayout.Bands(0).Columns("Inicio").AllowRowFiltering = DefaultableBoolean.False
        ' grid.DisplayLayout.Bands(0).Columns("Fin").Style = ColumnStyle.DateTime
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
        'gridReporteProductividad
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
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        For Each row In grid.Rows
            If row.Cells("Status").Value = 23 Then
                row.Cells("Status").Appearance.BackColor = Color.Green
                row.Cells("Status").Appearance.ForeColor = Color.Green
                row.Cells("Status").Value = "Completado"
            ElseIf row.Cells("Status").Value = 21 Then
                row.Cells("Status").Appearance.BackColor = Color.Yellow
                row.Cells("Status").Appearance.ForeColor = Color.Yellow
                row.Cells("Status").Value = "Por validar"
            ElseIf row.Cells("Status").Value = 22 Then
                row.Cells("Status").Appearance.BackColor = Color.Blue
                row.Cells("Status").Appearance.ForeColor = Color.Blue
                row.Cells("Status").Value = "Validado"
            ElseIf row.Cells("Status").Value = 20 Then
                'Dim objBU As New Negocios.AlmacenBU
                'If objBU.Plataforma_completa_lista_para_validacion(row.Cells("Ocupacion Carrito ID").Value.ToString) Then
                '    objBU.Editar_Status_Plataforma(1, row.Cells("Ocupacion Carrito ID").Value, 21)
                '    row.Cells("Status").Appearance.BackColor = Color.Yellow
                '    row.Cells("Status").Appearance.ForeColor = Color.Yellow
                '    row.Cells("Status").Value = Nothing
                '    row.Cells("Status").Value = "Por validar"
                'Else
                row.Cells("Status").Appearance.BackColor = Color.Red
                row.Cells("Status").Appearance.ForeColor = Color.Red
                row.Cells("Status").Value = "Pendiente"
                'End If
            ElseIf row.Cells("Status").Value = 19 Then
                row.Cells("Status").Appearance.BackColor = Color.Purple
                row.Cells("Status").Appearance.ForeColor = Color.Purple
                row.Cells("Status").Value = "Sin operador"
            ElseIf row.Cells("Status").Value = 24 Then
                row.Cells("Status").Appearance.BackColor = Color.Gray
                row.Cells("Status").Appearance.ForeColor = Color.Gray
                row.Cells("Status").Value = "Inconcluso"
            End If
        Next

        For Each row In grid.Rows
            If row.Cells("Ubicado").Value = "CON PLAT" And (row.Cells("Status").Value = "Completado" Or row.Cells("Status").Value = "Validado") Then
                row.Cells("Ubicado").Appearance.BackColor = Color.Green
                row.Cells("Ubicado").Appearance.ForeColor = Color.Green
            ElseIf row.Cells("Ubicado").Value = "SIN PLAT" And (row.Cells("Status").Value = "Completado" Or row.Cells("Status").Value = "Validado") Then
                row.Cells("Ubicado").Appearance.BackColor = Color.Yellow
                row.Cells("Ubicado").Appearance.ForeColor = Color.Yellow
            Else
                row.Cells("Ubicado").Appearance.BackColor = Color.Red
                row.Cells("Ubicado").Appearance.ForeColor = Color.Red
            End If
        Next




        'Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Min. Descargando")
        Dim summary1, summary2, summary3, summary4, summary5, summary6 As SummarySettings
        'summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Min. Descargando", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Minutos"))
        ' summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Atados Plat", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Atados Plat"))
        ' summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Prs Plat", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Plat"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("AtadosUbicados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("AtadosUbicados"))
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("AtadosDevueltos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("AtadosDevueltos"))
        'summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Prs Desc", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs Desc"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        'summary1.DisplayFormat = "{0:0,0}"
        ' summary1.Appearance.TextHAlign = HAlign.Right
        'summary2.DisplayFormat = "{0:0,0}"
        ' summary2.Appearance.TextHAlign = HAlign.Right
        ' summary3.DisplayFormat = "{0:0,0}"
        'summary3.Appeara 'nce.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:0,0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:0,0}"
        summary5.Appearance.TextHAlign = HAlign.Right
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

    Private Sub gridListaPlataforma_DoubleClick(sender As Object, e As MouseEventArgs) Handles gridReporteProductividad.DoubleClick

        If Not Me.gridReporteProductividad.ActiveRow.IsDataRow Then Return

        If IsNothing(gridReporteProductividad.ActiveRow) Then Return
        Dim row As UltraGridRow = gridReporteProductividad.ActiveRow

        Dim form As New DetallePlataformaForm
        form.ocupacion_carritoid = CInt(row.Cells("Ocupacion Carrito ID").Value)
        form.WindowState = FormWindowState.Maximized
        form.Show()

        'MessageBox.Show(row.Cells("PLATAFORMA").Value.ToString)

    End Sub

    Private Sub gridReporteProductividad_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs)
        If Not gridReporteProductividad.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If
    End Sub

    Private Sub gridReporteProductividad_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs)

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridReporteProductividad_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs)

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

#End Region

#Region "HISTORICO DE UBICACIONES"

    Private Sub txtPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPares_Atados.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtPares_Atados.Text) Then Return

            If IsNumeric(txtPares_Atados.Text) Then

                If txtPares_Atados.Text.Length >= 10 And txtPares_Atados.Text.Length <= 13 Then ''verifica "-" para posible par

                    listPares_Atados.Add(txtPares_Atados.Text)
                    gridPares_Atados.DataSource = Nothing
                    gridPares_Atados.DataSource = listPares_Atados

                    txtPares_Atados.Text = String.Empty

                Else
                    show_message("Aviso", "Código inválido")
                End If
            Else
                show_message("Aviso", "Código inválido")
            End If

        End If

    End Sub

    Private Sub btnAceptarHistoricoUbicaciones_Click(sender As Object, e As EventArgs) Handles btnAceptarHistoricoUbicaciones.Click
        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Cursor = Cursors.Default
            Return
        End If
        If gridPares_Atados.Rows.Count = 0 Then
            show_message("Aviso", "Debe ingresar al menos un valor de busqueda")
            Cursor = Cursors.Default
            Return
        End If
        poblar_gridReporteUbicacionesHistorico(gridHistoricoUbicaciones)
        Label8.Visible = True
        lblFechaHistoricoUbicaciones.Visible = True
        lblHoraHistoricoUbicaciones.Visible = True
        lblFechaHistoricoUbicaciones.Text = Date.Now.ToShortDateString
        lblHoraHistoricoUbicaciones.Text = Date.Now.ToShortTimeString
    End Sub

    Private Sub btnCancelarHistoricoUbicaciones_Click(sender As Object, e As EventArgs) Handles btnCancelarHistoricoUbicaciones.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarHistoricoUbicaciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarHistoricoUbicaciones.Click
        gridHistoricoUbicaciones.DataSource = Nothing
        gridPares_Atados.DataSource = Nothing
    End Sub

    Private Sub gridPares_Atados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPares_Atados.InitializeLayout
        grid_simple_diseño(gridPares_Atados)
        gridPares_Atados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de Par/Atado"
    End Sub

    Private Sub gridPares_Atados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPares_Atados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPares_Atados.DeleteSelectedRows(False)

    End Sub

    Public Sub poblar_gridReporteUbicacionesHistorico(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing
        Dim nave_almacen As String = String.Empty
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ReporteUbicacionHistorico As New DataTable
        Dim nave_almacen_split() As String
        Dim ListadoCodigos As String = String.Empty
        nave_almacen = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        nave_almacen_split = nave_almacen.Split(",")

        Dim tipo_busqueda As Boolean
        Dim lCodigos As New List(Of String)

        If rbtnPares.Checked Then
            tipo_busqueda = True
        Else
            tipo_busqueda = False
        End If

        ''COLABORADORES
        For Each row As UltraGridRow In gridPares_Atados.Rows

            lCodigos.Add(row.Cells(0).Text)

        Next


        For Each Item As String In lCodigos
            If ListadoCodigos = "" Then
                ListadoCodigos = Item
            Else
                ListadoCodigos = "," & Item
            End If
        Next


        Tabla_ReporteUbicacionHistorico = objBU.Almacen_ReporteHistoricoUbicaciones(tipo_busqueda, ListadoCodigos, nave_almacen_split(0), nave_almacen_split(1))

        grid.DataSource = Tabla_ReporteUbicacionHistorico

        If Not grid.Rows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If

        gridUbicacionesHistoricoDiseno(grid)

    End Sub

    Private Sub gridUbicacionesHistoricoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Bands(0).Columns(11).Style = ColumnStyle.DateTime
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.False


        For Each row As UltraGridRow In grid.Rows

            If row.Cells("P/A").Text.Equals("P") Then
                row.Cells("P/A").Appearance.BackColor = Color.Khaki
            Else
                If row.Cells("P/A").Text.Equals("A") Then
                    row.Cells("P/A").Appearance.BackColor = Color.Aquamarine
                Else
                    row.Cells("P/A").Appearance.BackColor = Color.Orange
                End If
            End If

        Next


    End Sub

    Private Sub gridHistoricoUbicaciones_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles gridHistoricoUbicaciones.AfterRowFilterChanged
        If Not gridHistoricoUbicaciones.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If
    End Sub

    Private Sub gridHistoricoUbicaciones_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles gridHistoricoUbicaciones.BeforePrint

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridHistoricoUbicaciones_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs) Handles gridHistoricoUbicaciones.InitializePrintPreview

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


#End Region

#Region "REPORTE DE INVENTARIO INICIAL"

    Private Sub btnAceptarInventarioInicial_Click(sender As Object, e As EventArgs) Handles btnAceptarInventarioInicial.Click
        Cursor = Cursors.WaitCursor

        Dim objBU As New Negocios.AlmacenBU
        Try
            objBU.InventarioDiarioSICY_Cierre(cboxNave.SelectedValue)
        Catch ex As Exception

        End Try

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Cursor = Cursors.Default
            Return
        End If
        'poblar_gridReporteInventarioInicial(gridReporteInventarioInicial)
        CargarInventario()
        Label15.Visible = True
        lblFechaInventarioInicial.Visible = True
        lblHoraInventarioInicial.Visible = True
        lblFechaInventarioInicial.Text = Date.Now.ToShortDateString
        lblHoraInventarioInicial.Text = Date.Now.ToShortTimeString
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelarInventarioInicial_Click(sender As Object, e As EventArgs) Handles btnCancelarInventarioInicial.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarInventarioInicial_Click(sender As Object, e As EventArgs) Handles btnLimpiarInventarioInicial.Click
        gridReporteInventarioInicial.DataSource = Nothing
    End Sub

    Public Sub poblar_gridReporteInventarioInicial(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None

        Dim nave_almacen As String = String.Empty
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ReporteInventarioInicial As New DataTable
        Dim nave_almacen_split() As String
        nave_almacen = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        nave_almacen_split = nave_almacen.Split(",")

        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime

        fecha_inicio = dtpFechaInicioInventarioInicial.Value
        fecha_termino = dtpFechaTerminoInventarioInicial.Value

        Dim rango_dias As Integer = DateDiff(DateInterval.Day, fecha_inicio, fecha_termino)

        If Not rango_dias < 0 Then

            Tabla_ReporteInventarioInicial.Columns.Add("Concepto")

            Tabla_ReporteInventarioInicial.Rows.Add("INVENTARIO INICIAL SICY")
            Tabla_ReporteInventarioInicial.Rows.Add("Con Ubicación")
            Tabla_ReporteInventarioInicial.Rows.Add("Sin Ubicación")
            Tabla_ReporteInventarioInicial.Rows.Add("Con Error")
            Tabla_ReporteInventarioInicial.Rows.Add("PARES INGRESADOS")
            Tabla_ReporteInventarioInicial.Rows.Add("PARES ENTREGA NAVE")
            Tabla_ReporteInventarioInicial.Rows.Add("Ubicados")
            Tabla_ReporteInventarioInicial.Rows.Add("No Ubicados")
            Tabla_ReporteInventarioInicial.Rows.Add("PARES OTRAS ENTRADAS")
            Tabla_ReporteInventarioInicial.Rows.Add("Ubicados")
            Tabla_ReporteInventarioInicial.Rows.Add("No Ubicados")
            Tabla_ReporteInventarioInicial.Rows.Add("SALIDAS DE ALMACÉN")
            Tabla_ReporteInventarioInicial.Rows.Add("Ventas / Ruta")
            Tabla_ReporteInventarioInicial.Rows.Add("Otras Salidas")
            ''Tabla_ReporteInventarioInicial.Rows.Add("Con Ubicación")
            ''Tabla_ReporteInventarioInicial.Rows.Add("Sin Ubicación")
            Tabla_ReporteInventarioInicial.Rows.Add("MOVIMIENTOS ALMACÉN")
            Tabla_ReporteInventarioInicial.Rows.Add("INVENTARIO FINAL SICY")
            Tabla_ReporteInventarioInicial.Rows.Add("Con Ubicación")
            Tabla_ReporteInventarioInicial.Rows.Add("Sin Ubicación")
            Tabla_ReporteInventarioInicial.Rows.Add("Con Error")

            For index = 0 To rango_dias
                Tabla_ReporteInventarioInicial.Columns.Add(String.Empty, System.Type.GetType("System.Double"))
                ' ''Tabla_ReporteInventarioInicial.Columns.Add(String.Empty, System.Type.GetType("System.Double"))
            Next

            Tabla_ReporteInventarioInicial.Columns.Add("Total")

        End If
        Dim Tabla_ReporteInventarioInicial_tmp As New DataTable
        Try
            Tabla_ReporteInventarioInicial_tmp = objBU.Almacen_ReporteInventarioInicial(fecha_inicio, fecha_termino, nave_almacen_split(0), nave_almacen_split(1))
        Catch ex As Exception
        End Try

        ' ''rango_dias = (rango_dias * 2) + 2
        rango_dias = (rango_dias) + 2


        ' ''If Not rango_dias < 0 Then
        '' '' Cambio 19/12/2014 Totales en misma olumna que datos
        ' ''    For index = 1 To rango_dias
        ' ''        Tabla_ReporteInventarioInicial.Columns(index).Caption = "Fecha: "
        ' ''        Tabla_ReporteInventarioInicial.Columns(index + 1).Caption = fecha_inicio.ToShortDateString
        ' ''        fecha_inicio = fecha_inicio.AddDays(1)
        ' ''        index += 1
        ' ''    Next
        ' ''End If


        If Not rango_dias < 0 Then

            For index = 1 To rango_dias - 1
                Tabla_ReporteInventarioInicial.Columns(index).Caption = fecha_inicio.ToShortDateString
                fecha_inicio = fecha_inicio.AddDays(1)
            Next

        End If




        For Each row As DataRow In Tabla_ReporteInventarioInicial_tmp.Rows

            For Each column As DataColumn In Tabla_ReporteInventarioInicial.Columns

                Dim fecha_row As Boolean = DateTime.TryParse((row.Item(0).ToString), Date.MinValue)
                Dim fecha_header As Boolean = DateTime.TryParse((column.Caption.ToString), Date.Now)
                If fecha_row And fecha_header Then
                    If CDate(row.Item(0).ToString).ToShortDateString = CDate(column.Caption.ToString).ToShortDateString Then

                        ' ''column.DataType.
                        '' Cambio 19/12/2014 Totales en misma olumna que datos
                        ''Tabla_ReporteInventarioInicial.Rows(0).Item(column.Ordinal - 1) = CDbl(row.Item(1))
                        ''Tabla_ReporteInventarioInicial.Rows(1).Item(column.Ordinal) = CDbl(row.Item(2))
                        ''Tabla_ReporteInventarioInicial.Rows(2).Item(column.Ordinal) = CDbl(row.Item(3))
                        ''Tabla_ReporteInventarioInicial.Rows(3).Item(column.Ordinal) = CDbl(row.Item(4))
                        ''Tabla_ReporteInventarioInicial.Rows(4).Item(column.Ordinal - 1) = CDbl(row.Item(5))
                        ''Tabla_ReporteInventarioInicial.Rows(5).Item(column.Ordinal - 1) = CDbl(row.Item(6))
                        ''Tabla_ReporteInventarioInicial.Rows(6).Item(column.Ordinal) = CDbl(row.Item(7))
                        ''Tabla_ReporteInventarioInicial.Rows(7).Item(column.Ordinal) = CDbl(row.Item(8))
                        ''Tabla_ReporteInventarioInicial.Rows(8).Item(column.Ordinal - 1) = CDbl(row.Item(9))
                        ''Tabla_ReporteInventarioInicial.Rows(9).Item(column.Ordinal) = CDbl(row.Item(10))
                        ''Tabla_ReporteInventarioInicial.Rows(10).Item(column.Ordinal) = CDbl(row.Item(11))
                        ''Tabla_ReporteInventarioInicial.Rows(11).Item(column.Ordinal - 1) = CDbl(row.Item(12))
                        ''Tabla_ReporteInventarioInicial.Rows(12).Item(column.Ordinal - 1) = CDbl(row.Item(13))
                        ''Tabla_ReporteInventarioInicial.Rows(13).Item(column.Ordinal - 1) = CDbl(row.Item(14))
                        ''Tabla_ReporteInventarioInicial.Rows(14).Item(column.Ordinal) = CDbl(row.Item(15))
                        ''Tabla_ReporteInventarioInicial.Rows(15).Item(column.Ordinal) = CDbl(row.Item(16))
                        ''Tabla_ReporteInventarioInicial.Rows(16).Item(column.Ordinal - 1) = CDbl(row.Item(17))
                        ''Tabla_ReporteInventarioInicial.Rows(17).Item(column.Ordinal - 1) = CDbl(row.Item(18))
                        ''Tabla_ReporteInventarioInicial.Rows(18).Item(column.Ordinal) = CDbl(row.Item(19))
                        ''Tabla_ReporteInventarioInicial.Rows(19).Item(column.Ordinal) = CDbl(row.Item(20))
                        ''Tabla_ReporteInventarioInicial.Rows(20).Item(column.Ordinal) = CDbl(row.Item(21))

                        Tabla_ReporteInventarioInicial.Rows(0).Item(column.Ordinal) = CDbl(row.Item(1))
                        Tabla_ReporteInventarioInicial.Rows(1).Item(column.Ordinal) = CDbl(row.Item(2))
                        Tabla_ReporteInventarioInicial.Rows(2).Item(column.Ordinal) = CDbl(row.Item(3))
                        Tabla_ReporteInventarioInicial.Rows(3).Item(column.Ordinal) = CDbl(row.Item(4))
                        Tabla_ReporteInventarioInicial.Rows(4).Item(column.Ordinal) = CDbl(row.Item(5))
                        Tabla_ReporteInventarioInicial.Rows(5).Item(column.Ordinal) = CDbl(row.Item(6))
                        Tabla_ReporteInventarioInicial.Rows(6).Item(column.Ordinal) = CDbl(row.Item(7))
                        Tabla_ReporteInventarioInicial.Rows(7).Item(column.Ordinal) = CDbl(row.Item(8))
                        Tabla_ReporteInventarioInicial.Rows(8).Item(column.Ordinal) = CDbl(row.Item(9))
                        Tabla_ReporteInventarioInicial.Rows(9).Item(column.Ordinal) = CDbl(row.Item(10))
                        Tabla_ReporteInventarioInicial.Rows(10).Item(column.Ordinal) = CDbl(row.Item(11))
                        Tabla_ReporteInventarioInicial.Rows(11).Item(column.Ordinal) = CDbl(row.Item(12))
                        Tabla_ReporteInventarioInicial.Rows(12).Item(column.Ordinal) = CDbl(row.Item(13))
                        Tabla_ReporteInventarioInicial.Rows(13).Item(column.Ordinal) = CDbl(row.Item(14))
                        Tabla_ReporteInventarioInicial.Rows(14).Item(column.Ordinal) = CDbl(row.Item(17))
                        Tabla_ReporteInventarioInicial.Rows(15).Item(column.Ordinal) = CDbl(row.Item(18))
                        Tabla_ReporteInventarioInicial.Rows(16).Item(column.Ordinal) = CDbl(row.Item(19))
                        Tabla_ReporteInventarioInicial.Rows(17).Item(column.Ordinal) = CDbl(row.Item(20))
                        Tabla_ReporteInventarioInicial.Rows(18).Item(column.Ordinal) = CDbl(row.Item(21))
                        'Tabla_ReporteInventarioInicial.Rows(19).Item(column.Ordinal) = CDbl(row.Item(20))
                        'Tabla_ReporteInventarioInicial.Rows(20).Item(column.Ordinal) = CDbl(row.Item(21))

                    End If
                End If

            Next

        Next

        'For Each row As DataRow In Tabla_ReporteInventarioInicial.Rows
        '    Dim promedio As Double
        '    Dim total_col As Integer

        '    For Each col As DataColumn In Tabla_ReporteInventarioInicial.Columns

        '        If col.Ordinal > 0 And col.Ordinal < Tabla_ReporteInventarioInicial.Columns.Count Then

        '            If Not IsDBNull(row.Item(col.Ordinal)) Then
        '                promedio += row.Item(col.Ordinal)
        '                total_col += 1
        '            End If
        '        End If
        '    Next
        '    Dim resultado As Double
        '    resultado = promedio / total_col
        '    row.Item(Tabla_ReporteInventarioInicial.Columns.Count - 1) = resultado.ToString("N2")
        '    promedio = 0
        '    total_col = 0
        'Next




        grid.DataSource = Tabla_ReporteInventarioInicial

        If Not grid.Rows.Count > 0 Then
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else
            btnImprimir.Enabled = True
            btnExportar.Enabled = True
        End If


        gridReporteInventarioInicialDiseno(grid)

        Dim columnas As Int32 = grid.Rows.Band.Columns.Count
        Dim total As Int32 = 0
        grid.Rows.Band.Columns("Total").Format = Format("N0")





        'For Each rowdrg As UltraGridRow In grid.Rows
        '    If rowdrg.Index = 0 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.Appearance.BackColor = Color.LightSteelBlue
        '            rowdrg.Appearance.FontData.Bold = DefaultableBoolean.True
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 1 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 2 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 3 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 4 Then
        '        rowdrg.Appearance.BackColor = Color.LightSteelBlue
        '        rowdrg.Appearance.FontData.Bold = DefaultableBoolean.True
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 5 Then
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 6 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 7 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 8 Then
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 9 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 10 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 11 Then
        '        rowdrg.Appearance.BackColor = Color.LightSteelBlue
        '        rowdrg.Appearance.FontData.Bold = DefaultableBoolean.True
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 12 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 13 Then
        '        rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 14 Then
        '        rowdrg.Appearance.BackColor = Color.LightSteelBlue
        '        rowdrg.Appearance.FontData.Bold = DefaultableBoolean.True
        '        For i As Int32 = 1 To columnas - 2
        '            If rowdrg.Cells(i).Value.ToString.Length > 0 Then
        '                total = total + rowdrg.Cells(i).Value
        '            End If
        '        Next
        '        rowdrg.Cells("Total").Value = CInt(total).ToString("N0")
        '        total = 0

        '    ElseIf rowdrg.Index = 15 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.Appearance.BackColor = Color.LightSteelBlue
        '            rowdrg.Appearance.FontData.Bold = DefaultableBoolean.True
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 16 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 17 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    ElseIf rowdrg.Index = 18 Then
        '        If rowdrg.Cells(columnas - 2).Value.ToString.Length > 0 Then
        '            rowdrg.CellAppearance.TextHAlign = HAlign.Right
        '            rowdrg.Cells("Total").Value = CInt(rowdrg.Cells(columnas - 2).Value).ToString("N0")
        '        End If
        '    End If
        'Next

        grid.Rows.Band.Columns("Total").CellAppearance.FontData.Bold = DefaultableBoolean.True
    End Sub


    Private Sub gridReporteInventarioInicialDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime

        fecha_inicio = dtpFechaInicioInventarioInicial.Value
        fecha_termino = dtpFechaTerminoInventarioInicial.Value

        Dim rango_dias As Integer = DateDiff(DateInterval.Day, fecha_inicio, fecha_termino)
        ' ''rango_dias = (rango_dias * 2) + 2
        rango_dias = (rango_dias) + 2


        '' ''If Not rango_dias < 0 Then
        ' '' '' Cambio 19/12/2014 Totales en misma olumna que datos
        '' ''    For index = 1 To rango_dias
        '' ''        grid.DisplayLayout.Bands(0).Columns(index).Header.Caption = "Fecha: "
        '' ''        grid.DisplayLayout.Bands(0).Columns(index + 1).Header.Caption = fecha_inicio.ToShortDateString
        '' ''        fecha_inicio = fecha_inicio.AddDays(1)
        '' ''        index += 1
        '' ''    Next
        '' ''End If

        If Not rango_dias < 0 Then

            For index = 1 To rango_dias - 1
                grid.DisplayLayout.Bands(0).Columns(index).Header.Caption = fecha_inicio.ToShortDateString
                fecha_inicio = fecha_inicio.AddDays(1)
            Next

        End If

        'grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        'grid.DisplayLayout.Bands(0).Columns(0).Style = ColumnStyle.DateTime
        'grid.DisplayLayout.Bands(0).Columns(0).CellAppearance.TextHAlign = HAlign.Right

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.HeaderClickAction = Nothing
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
        grid.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.False

        grid.DisplayLayout.Bands(0).Columns(0).PerformAutoResize(PerformAutoSizeType.AllRowsInBand)
        'CellAppearance.TextHAlign = HAlign.Right
        '.Format = Format("N0")
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns

            'If col.Index > 0 And col.Index < grid.Rows.Band.Columns.Count Then
            'If col.Index > 0 Then

            '    'col.CellAppearance.TextHAlign = HAlign.Right
            '    'col.Format = Format("##,#")
            'End If

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

    Private Sub gridReporteInventarioInicial_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs)

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridReporteInventarioInicial_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs)

        e.PrintDocument.DefaultPageSettings.Landscape = True
        e.PrintLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        ''e.PrintPreviewSettings.Zoom = 100
        'e.PrintLayout.Override.RowAlternateAppearance.BackColor = Color.White
        e.PrintDocument.DefaultPageSettings.Margins.Left = 0
        e.PrintDocument.DefaultPageSettings.Margins.Right = 0

        With e.PrintLayout

            .Bands(0).Columns(1).Hidden = True
            .Bands(0).Columns(2).Header.Caption = "PAR"
            .Bands(0).Columns(3).Header.Caption = "ATADO"

        End With

    End Sub

#End Region

#Region "OTRAS ACCIONES DE APOYO"

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

    'Asigna el formato de las columnas de ultragrid segun el estandar de diseño
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                If col.Header.Caption <> "otco_idpedido" Then
                    col.Style = ColumnStyle.Integer
                    col.CellAppearance.TextHAlign = HAlign.Right
                    col.Format = Format("N0")
                End If
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Double") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = Format("N0")

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

    'Da formato a los ultragrid simples
    Private Sub grid_simple_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    'Da formato a los ultragrid complejos
    Private Sub grid_complejo_diseño(grid As UltraGrid)
        With grid.DisplayLayout
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

#End Region

    Private Sub gridListaPlataforma_DoubleClick(sender As Object, e As EventArgs) Handles gridReporteProductividad.DoubleClick

    End Sub

#Region "REPORTES OT COPPEL"

    Private Sub grdColaboradoresOTCoppel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColaboradoresOTCoppel.InitializeLayout
        grid_complejo_diseño(grdColaboradoresOTCoppel)
        grdColaboradoresOTCoppel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
    End Sub

    Private Sub btnColaboradoresOTCoppel_Click(sender As Object, e As EventArgs) Handles btnColaboradoresOTCoppel.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColaboradoresOTCoppel.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColaboradoresOTCoppel.DataSource = listado.listParametros
        With grdColaboradoresOTCoppel
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operador"
        End With
    End Sub

    Private Sub grdColaboradoresOTCoppel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColaboradoresOTCoppel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColaboradoresOTCoppel.DeleteSelectedRows(False)
    End Sub

    Public Sub poblar_gridReporteOTCoppel(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ReporteOTCoppel As New DataTable

        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime
        Dim lColaborador As String = String.Empty

        Dim advertencia As New AdvertenciaForm
        Dim mensajeSinDatos As String = String.Empty

        fecha_inicio = dtpFechaInicioOTCoppel.Value
        fecha_termino = dtpFechaFinOTCoppel.Value

        ''COLABORADORES
        For Each row As UltraGridRow In grdColaboradoresOTCoppel.Rows
            If row.Index = 0 Then
                lColaborador += Replace(row.Cells("Parámetro").Text, ",", "")
            Else
                lColaborador += ", " + Replace(row.Cells("Parámetro").Text, ",", "")
            End If
        Next

        If cboxTipoReporte.SelectedIndex = 0 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelAvancePedido(fecha_inicio, fecha_termino, lColaborador)
            mensajeSinDatos = "Es posible que no haya entregas"
        ElseIf cboxTipoReporte.SelectedIndex = 1 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelIncidenciasPedido(fecha_inicio, fecha_termino)
            mensajeSinDatos = "Es posible que no haya entregas ó incidencias"
        ElseIf cboxTipoReporte.SelectedIndex = 2 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelIncidenciasUsuario(fecha_inicio, fecha_termino, lColaborador)
            mensajeSinDatos = "Es posible que no haya incidencias"
        ElseIf cboxTipoReporte.SelectedIndex = 3 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelIncidenciasUsuarioFecha(fecha_inicio, fecha_termino, lColaborador)
            mensajeSinDatos = "Es posible que no haya incidencias"
        ElseIf cboxTipoReporte.SelectedIndex = 4 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelOTConfirmadasUsuarioFecha(fecha_inicio, fecha_termino, lColaborador)
            mensajeSinDatos = "Es posible que no haya OTs confirmadas"
        ElseIf cboxTipoReporte.SelectedIndex = 5 Then
            Tabla_ReporteOTCoppel = objBU.Almacen_ReporteOTCoppelParesUsuarioFecha(fecha_inicio, fecha_termino, lColaborador)
            mensajeSinDatos = "Es posible que no haya pares confirmados"
        Else
            mensajeSinDatos = "Debe seleccionar un tipo de reporte"
        End If

        If Tabla_ReporteOTCoppel.Rows.Count > 0 Then

            grid.DataSource = Tabla_ReporteOTCoppel

            If Not grid.Rows.Count > 0 Then
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            Else
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            End If

            If cboxTipoReporte.SelectedIndex = 0 Then
                gridReporteOTCoppelDisenoAvancePedido(grid)
            ElseIf cboxTipoReporte.SelectedIndex = 1 Then
                gridReporteOTCoppelDisenoIncidenciasPedido(grid)
            ElseIf cboxTipoReporte.SelectedIndex = 2 Then
                gridReporteOTCoppelDisenoIncidenciasUsuario(grid)
            ElseIf cboxTipoReporte.SelectedIndex >= 3 Or cboxTipoReporte.SelectedIndex <= 5 Then
                gridReporteOTCoppelDisenoUsuarioFecha(grid)
            End If
        Else
            If cboxTipoReporte.SelectedIndex >= 0 Then
                advertencia.mensaje = "La consulta no devolvio resultados. " + mensajeSinDatos + " en el periodo seleccionado"
            Else
                advertencia.mensaje = mensajeSinDatos
            End If

            advertencia.ShowDialog()
        End If



    End Sub

    Private Sub btnMostrarOTCoppel_Click(sender As Object, e As EventArgs) Handles btnMostrarOTCoppel.Click
        Cursor = Cursors.WaitCursor

        poblar_gridReporteOTCoppel(grdReporteOTCoppel)

        If grdReporteOTCoppel.Rows.Count > 0 Then
            lblUltimaActualizacionOTCoppel.Visible = True
            lblFechaReporteOTCoppel.Visible = True
            lblHoraReporteOTCoppel.Visible = True

            lblFechaReporteOTCoppel.Text = Date.Now.ToShortDateString
            lblHoraReporteOTCoppel.Text = Date.Now.ToShortTimeString
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub gridReporteOTCoppelDisenoAvancePedido(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalPares As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").Header.Caption = "ID Pedido"
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").Header.Caption = "Fecha de Entrega"
        grid.DisplayLayout.Bands(0).Columns("OTs").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("OTs").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("OTs").Header.Caption = "OTs"
        grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("OTs_Confirmadas").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("OTs_Confirmadas").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("OTs_Confirmadas").Header.Caption = "OTs Confirmadas"
        grid.DisplayLayout.Bands(0).Columns("Pares_Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares_Confirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Pares_Confirmados").Header.Caption = "Pares Confirmados"
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_pedido").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_pedido").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_pedido").Header.Caption = "% Pedido"
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_global").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_global").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_global").Header.Caption = "% Global"

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

        totalPares = 0
        For Each row As UltraGridRow In grid.Rows
            row.Cells("Porcentaje_pedido").Value = (row.Cells("Pares_Confirmados").Value / row.Cells("Pares").Value) * 100
            totalPares += row.Cells("Pares").Value
        Next

        For Each row As UltraGridRow In grid.Rows
            row.Cells("Porcentaje_global").Value = Double.Parse((row.Cells("Pares_Confirmados").Value / totalPares) * 100)
        Next

        Dim summary1, summary2, summary3, summary4, summary5 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total OTs", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("OTs"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total OTs Confirmadas", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("OTs_Confirmadas"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares_Confirmados"))
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Porcentaje_global"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:#,0.00}"
        summary5.Appearance.TextHAlign = HAlign.Right

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

    Private Sub gridReporteOTCoppelDisenoIncidenciasPedido(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalParesLeidos, totalParesConfirmados As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("otco_idpedido").Header.Caption = "ID Pedido"
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").Header.Caption = "Fecha de Entrega"
        grid.DisplayLayout.Bands(0).Columns("OTs").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("OTs").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("OTs").Header.Caption = "OTs"
        grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("paresLeidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresLeidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("paresLeidos").Header.Caption = "Pares Leidos"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Pares Confirmados"
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").CellAppearance.TextHAlign = HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").GroupByMode = GroupByMode.Text
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").Header.Caption = "Incidencias"
        grid.DisplayLayout.Bands(0).Columns("paresEquivocados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresEquivocados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("paresEquivocados").Header.Caption = "Pares Equivocados"
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesLeidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesLeidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesLeidos").Header.Caption = "% Equivocados / Leidos"
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porc_vsParesConfirmados").Header.Caption = "% Equivocados / Confirmados"
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalLeidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalLeidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalLeidos").Header.Caption = "% Global / Leidos"
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalConfirmados").Header.Caption = "% Global / Confirmados"

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

        totalParesLeidos = 0
        totalParesConfirmados = 0
        For Each row As UltraGridRow In grid.Rows
            If row.Cells("paresLeidos").Value > 0 Then
                row.Cells("Porc_vsParesLeidos").Value = (row.Cells("paresEquivocados").Value / row.Cells("paresLeidos").Value) * 100
            Else
                row.Cells("Porc_vsParesLeidos").Value = 0
            End If
            If row.Cells("Confirmados").Value > 0 Then
                row.Cells("Porc_vsParesConfirmados").Value = (row.Cells("paresEquivocados").Value / row.Cells("Confirmados").Value) * 100
            Else
                row.Cells("Porc_vsParesConfirmados").Value = 0
            End If
            totalParesLeidos += row.Cells("paresLeidos").Value
            totalParesConfirmados += row.Cells("Confirmados").Value
        Next

        For Each row As UltraGridRow In grid.Rows
            row.Cells("Porcentaje_globalLeidos").Value = Double.Parse((row.Cells("paresEquivocados").Value / totalParesLeidos) * 100)
            row.Cells("Porcentaje_globalConfirmados").Value = Double.Parse((row.Cells("paresEquivocados").Value / totalParesConfirmados) * 100)
        Next

        Dim summary1, summary2, summary3, summary4, summary6, summary7, summary8 As SummarySettings
        ' Dim summary5 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total OTs", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("OTs"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Leidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresLeidos"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Confirmados"))
        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Incidencias", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Incidencias"))
        summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Equivocados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresEquivocados"))
        summary7 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global Leidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalLeidos"))
        summary8 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Porcentaje_globalConfirmados"))

        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        'summary5.DisplayFormat = "{0:#,##0}"
        'summary5.Appearance.TextHAlign = HAlign.Right
        summary6.DisplayFormat = "{0:#,##0}"
        summary6.Appearance.TextHAlign = HAlign.Right
        summary7.DisplayFormat = "{0:#,0.00}"
        summary7.Appearance.TextHAlign = HAlign.Right
        summary8.DisplayFormat = "{0:#,0.00}"
        summary8.Appearance.TextHAlign = HAlign.Right

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

    Private Sub gridReporteOTCoppelDisenoIncidenciasUsuario(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalParesConfirmados, totalParesLeidos As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("user_nombrereal").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("user_nombrereal").Header.Caption = "Operador"
        grid.DisplayLayout.Bands(0).Columns("Total_ots").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Total_ots").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total_ots").Header.Caption = "OTs Confirmadas"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Pares Confirmados"
        grid.DisplayLayout.Bands(0).Columns("leidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("leidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("leidos").Header.Caption = "Pares Leidos"
        grid.DisplayLayout.Bands(0).Columns("incorrectos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("incorrectos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("incorrectos").Header.Caption = "Pares Incorrectos"
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsConfirmados").Header.Caption = "% Incorrectos / Confirmados"
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsLeidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsLeidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeVsLeidos").Header.Caption = "% Incorrectos / Leidos"
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsConfirmados").Header.Caption = "% Global / Confirmados"
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsLeidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsLeidos").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsLeidos").Header.Caption = "% Global / Leidos"

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

        totalParesConfirmados = 0
        totalParesLeidos = 0
        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeVsConfirmados").Value = (row.Cells("incorrectos").Value / row.Cells("Confirmados").Value) * 100
            row.Cells("porcentajeVsLeidos").Value = (row.Cells("incorrectos").Value / row.Cells("leidos").Value) * 100
            totalParesConfirmados += row.Cells("Confirmados").Value
            totalParesLeidos += row.Cells("leidos").Value
        Next

        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeGlobalVsConfirmados").Value = Double.Parse((row.Cells("incorrectos").Value / totalParesConfirmados) * 100)
            row.Cells("porcentajeGlobalVsLeidos").Value = Double.Parse((row.Cells("incorrectos").Value / totalParesLeidos) * 100)
        Next

        Dim summary1, summary2, summary3, summary4, summary5, summary6 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total OTs Confirmadas", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Total_ots"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Confirmados"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Leidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("leidos"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Incorrectos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("incorrectos"))
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsConfirmados"))
        summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global Leidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajeGlobalVsLeidos"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:#,0.00}"
        summary5.Appearance.TextHAlign = HAlign.Right
        summary6.DisplayFormat = "{0:#,0.00}"
        summary6.Appearance.TextHAlign = HAlign.Right

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

    Private Sub gridReporteOTCoppelDisenoUsuarioFecha(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalFecha As Int32

        For Each row As UltraGridRow In grid.Rows
            totalFecha = 0
            For Each column In grid.DisplayLayout.Bands(0).Columns
                If IsDBNull(row.Cells(column).Value) Then
                    row.Cells(column).Value = 0
                End If
                If column.Key <> "fecha" And column.Key <> "Total" Then
                    totalFecha += row.Cells(column).Value
                ElseIf column.Key = "Total" Then
                    row.Cells(column).Value = totalFecha
                End If
            Next
        Next


        asignaFormato_Columna(grid)


        grid.DisplayLayout.Bands(0).Columns("fecha").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("fecha").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
        grid.DisplayLayout.Bands(0).Columns("Total").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total").Header.Caption = "Total"

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

        For Each column In grid.DisplayLayout.Bands(0).Columns
            If column.Key <> "fecha" Then
                grid.DisplayLayout.Bands(0).Summaries.Add("Total" + column.Key, SummaryType.Sum, column)
                grid.DisplayLayout.Bands(0).Summaries("Total" + column.Key).DisplayFormat = "{0:#,##0}"
                grid.DisplayLayout.Bands(0).Summaries("Total" + column.Key).Appearance.TextHAlign = HAlign.Right
            End If
        Next

        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

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

    Private Sub cboxTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxTipoReporte.SelectedIndexChanged
        grdReporteOTCoppel.DataSource = Nothing
        lblUltimaActualizacionOTCoppel.Visible = False
        lblFechaReporteOTCoppel.Visible = False
        lblHoraReporteOTCoppel.Visible = False
        If cboxTipoReporte.SelectedIndex = 0 Or cboxTipoReporte.SelectedIndex = 1 Then
            grpboxPeriodo.Text = "Periodo Entrega"
            grpboxOperador.Visible = False
        Else
            If cboxTipoReporte.SelectedIndex = 2 Or cboxTipoReporte.SelectedIndex = 4 Or cboxTipoReporte.SelectedIndex = 5 Then
                grpboxPeriodo.Text = "Periodo Confirmación"
            ElseIf cboxTipoReporte.SelectedIndex = 3 Then
                grpboxPeriodo.Text = "Periodo Incidencia"
            Else
                grpboxPeriodo.Text = "Periodo"
            End If
            grpboxOperador.Visible = True
        End If
    End Sub

    Private Sub btnCerrarOTCoppel_Click(sender As Object, e As EventArgs) Handles btnCerrarOTCoppel.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarOTCoppel_Click(sender As Object, e As EventArgs) Handles btnLimpiarOTCoppel.Click
        grdReporteOTCoppel.DataSource = Nothing
        grdColaboradoresOTCoppel.DataSource = String.Empty
        grid_complejo_diseño(grdColaboradoresOTCoppel)
        grdColaboradoresOTCoppel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
        cboxTipoReporte.SelectedIndex = -1
        dtpFechaInicioOTCoppel.Value = Now.Date
        dtpFechaFinOTCoppel.Value = Now.Date
    End Sub

#End Region


#Region "REPORTES APARTADOS"
    Private Sub btnIzquierda_Click(sender As Object, e As EventArgs) Handles btnIzquierda.Click
        Panel44.Width = 10
    End Sub

    Private Sub btnDerecha_Click(sender As Object, e As EventArgs) Handles btnDerecha.Click
        Panel44.Width = 439
    End Sub

    Public Sub mostraFiltroOperadoresApartados()
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdOperadorApartados.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdOperadorApartados.DataSource = listado.listParametros
        With grdOperadorApartados
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operador"
        End With
    End Sub

    Private Sub btnOperadorApartados_Click(sender As Object, e As EventArgs) Handles btnOperadorApartados.Click
        mostraFiltroOperadoresApartados()
    End Sub

    Private Sub grdOperadorApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOperadorApartados.InitializeLayout
        grid_complejo_diseño(grdOperadorApartados)
        grdOperadorApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
    End Sub

    Private Sub grdOperadorApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOperadorApartados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdOperadorApartados.DeleteSelectedRows(False)
    End Sub


    Public Sub MostrarFiltroClientesApartados()
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 11
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClienteApartados.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClienteApartados.DataSource = listado.listParametros
        With grdClienteApartados
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub


    Private Sub btnClienteApartado_Click(sender As Object, e As EventArgs) Handles btnClienteApartado.Click
        MostrarFiltroClientesApartados()
    End Sub

    Private Sub grdClienteApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClienteApartados.InitializeLayout
        grid_complejo_diseño(grdClienteApartados)
        grdClienteApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdClienteApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles grdClienteApartados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdClienteApartados.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCerrarApartados_Click(sender As Object, e As EventArgs) Handles btnCerrarApartados.Click
        Me.Close()
    End Sub

    Public Sub llenarComboReportesApartado()
        Dim objBu As New Negocios.ClientesAlmacenBU
        Dim dtReportes As New DataTable
        dtReportes = objBu.comboReporteApartadosSegunUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtReportes.Rows.Count > 0 Then
            cmbApartadoTipoReporte.DataSource = dtReportes
            cmbApartadoTipoReporte.ValueMember = "idReporte"
            cmbApartadoTipoReporte.DisplayMember = "reporte"
            If dtReportes.Rows.Count = 2 Then
                cmbApartadoTipoReporte.SelectedIndex = 1
            Else
                cmbApartadoTipoReporte.SelectedIndex = 0
            End If


        End If

    End Sub

    Private Sub cmbApartadoTipoReporte_Click(sender As Object, e As EventArgs) Handles cmbApartadoTipoReporte.Click

    End Sub


    Private Sub txtPedidoApartados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoApartados.KeyPress
        Dim caracteresPermitidos As String = "1234567890,-" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtPedidoApartados.Text) Then Return


            listaPedidosApartados.Add(txtPedidoApartados.Text)
            grdPedidoApartados.DataSource = Nothing
            grdPedidoApartados.DataSource = listaPedidosApartados

            txtPedidoApartados.Text = String.Empty
        Else
            If (Not (caracteresPermitidos.Contains(c))) Then

                'show_message("Aviso", "Código inválido")
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub grdPedidoApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoApartados.InitializeLayout
        grid_simple_diseño(grdPedidoApartados)
        grdPedidoApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub grdPedidoApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoApartados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoApartados.DeleteSelectedRows(False)
    End Sub

    Private Sub txtApartados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApartados.KeyPress
        Dim caracteresPermitidos As String = "1234567890,-" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtApartados.Text) Then Return

            listaApartados.Add(txtApartados.Text)
            grdApartados.DataSource = Nothing
            grdApartados.DataSource = listaApartados

            txtApartados.Text = String.Empty
        Else
            If (Not (caracteresPermitidos.Contains(c))) Then

                'show_message("Aviso", "Código inválido")
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdApartados.InitializeLayout
        grid_simple_diseño(grdApartados)
        grdApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Apartados"
    End Sub

    Private Sub grdApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles grdApartados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdApartados.DeleteSelectedRows(False)
    End Sub

    Private Sub cmbApartadoTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbApartadoTipoReporte.SelectedIndexChanged
        Dim seleccion As Int32 = 0
        If cmbApartadoTipoReporte.SelectedIndex > 0 Then
            seleccion = CInt(cmbApartadoTipoReporte.SelectedValue)
        End If

        If seleccion = 1 Or seleccion = 2 Then
            GroupBox7.Hide()
            GroupBox6.Text = "Periodo Preparación"

        Else
            GroupBox6.Text = "Periodo Confirmación"
            GroupBox7.Show()
        End If

        If seleccion = 1 Then
            Label41.Show()
        Else
            Label41.Hide()
        End If

        If seleccion = 2 Then
            Label41.Hide()
        Else
            Label41.Show()
        End If
    End Sub

    Public Sub poblarGridReportesApartados(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim fecha_inicio As DateTime
        Dim fecha_termino As DateTime
        Dim lColaborador As String = String.Empty
        Dim objBu As New Negocios.ClientesAlmacenBU
        Dim dtReporte As New DataTable
        Dim filtroCliente As String = String.Empty
        Dim filtroAPartados As String = String.Empty
        Dim filtroPedidos As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        Dim mensajeSinDatos As String = String.Empty
        Dim cont As Int32 = 0
        Dim CEDISID As Integer = cboxNave.SelectedValue

        fecha_inicio = dtpFechaInicioApartados.Value
        fecha_termino = dtpFechaFinApartados.Value

        grid.DataSource = Nothing
        ''COLABORADORES
        For Each row As UltraGridRow In grdOperadorApartados.Rows
            If row.Index = 0 Then
                lColaborador += Replace(row.Cells("Parámetro").Text, ",", "")
            Else
                lColaborador += ", " + Replace(row.Cells("Parámetro").Text, ",", "")
            End If
        Next
        For Each row As UltraGridRow In grdClienteApartados.Rows
            If row.Index = 0 Then
                filtroCliente += Replace(row.Cells("Parametro").Text, ",", "")
            Else
                filtroCliente += ", " + Replace(row.Cells("Parametro").Text, ",", "")
            End If
        Next
        For Each row As UltraGridRow In grdPedidoApartados.Rows
            If row.Index = 0 Then
                filtroPedidos += row.Cells(0).Text
            Else
                filtroPedidos += ", " + row.Cells(0).Text
            End If
        Next

        For Each row As UltraGridRow In grdApartados.Rows
            If row.Index = 0 Then
                filtroAPartados += row.Cells(0).Text
            Else
                filtroAPartados += ", " + row.Cells(0).Text
            End If
        Next

        If CInt(cmbApartadoTipoReporte.SelectedValue) = 1 Then
            dtReporte = objBu.reporteAvancePorFechaPreparacion(filtroCliente, filtroPedidos, filtroAPartados, fecha_inicio, fecha_termino, CEDISID)
            mensajeSinDatos = "Es posible que no haya apartados"
        ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 2 Then
            dtReporte = objBu.reporteApartadoPorEstatus(filtroCliente, filtroPedidos, filtroAPartados, fecha_inicio, fecha_termino, CEDISID)
            mensajeSinDatos = "Es posible que no haya apartados"
        ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 3 Then
            dtReporte = objBu.reporteApartados_ConfirmadoPorFechaUsuario(filtroCliente, filtroPedidos, filtroAPartados, lColaborador, fecha_inicio, fecha_termino, CEDISID)
            mensajeSinDatos = "Es posible que no haya apartados confirmados"
        ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 4 Then
            dtReporte = objBu.reportePares_ConfirmadoPorFechaUsuario(filtroCliente, filtroPedidos, filtroAPartados, lColaborador, fecha_inicio, fecha_termino, CEDISID)
            mensajeSinDatos = "Es posible que no haya apartados confirmados"
        Else
            mensajeSinDatos = "Debe seleccionar un tipo de reporte"
        End If

        If dtReporte.Rows.Count > 0 Then
            grid.DataSource = dtReporte

            If Not grid.Rows.Count > 0 Then
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            Else
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            End If

            If CInt(cmbApartadoTipoReporte.SelectedValue) = 1 Then
                disenioGridApartadosAvanceFechaPreparacion(grid)
            ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 2 Then
                disenioGridApartadosReportePorEstatus(grid)
            ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 3 Then
                grid.DataSource = Nothing
                ReDim operadores(dtReporte.Columns.Count - 3)
                For con = 1 To dtReporte.Columns.Count - 2
                    operadores(cont) = dtReporte.Columns(con).ColumnName
                    cont = cont + 1
                Next
                cont = 0
                Dim columna As String = String.Empty
                columna = dtReporte.Rows(0).Item(1).ToString
                For Each rowCero As DataRow In dtReporte.Rows
                    For j = 0 To operadores.Length - 1
                        columna = operadores(j).ToString

                        If rowCero.Item(columna).ToString = "" Then

                            rowCero.Item(operadores(j)) = 0
                        End If
                    Next

                Next
                grid.DataSource = dtReporte
                disenioGridApartadosReporteApartadosConfirmadoFechaUsuario(grid)

            ElseIf CInt(cmbApartadoTipoReporte.SelectedValue) = 4 Then
                grid.DataSource = Nothing
                ReDim operadores(dtReporte.Columns.Count - 3)
                For con = 1 To dtReporte.Columns.Count - 2
                    operadores(cont) = dtReporte.Columns(con).ColumnName
                    cont = cont + 1
                Next
                cont = 0
                Dim columna As String = String.Empty
                columna = dtReporte.Rows(0).Item(1).ToString
                For Each rowCero As DataRow In dtReporte.Rows
                    For j = 0 To operadores.Length - 1
                        columna = operadores(j).ToString

                        If rowCero.Item(columna).ToString = "" Then

                            rowCero.Item(operadores(j)) = 0
                        End If
                    Next

                Next
                grid.DataSource = dtReporte
                disenioGridApartadosReporteConfirmadoFechaUsuario(grid)
            End If
        Else
            If cmbApartadoTipoReporte.SelectedIndex > 0 Then
                advertencia.mensaje = "La consulta no devolvió resultados. " + mensajeSinDatos + " en el periodo seleccionado"
            Else
                advertencia.mensaje = mensajeSinDatos
            End If

            advertencia.ShowDialog()
        End If
    End Sub


    Public Sub disenioGridApartadosAvanceFechaPreparacion(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim totalApartados As Int32
        'Dim totalParesAPartados As Int32
        'Dim totalParesConfimados As Int32
        'Dim totalConfimados As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("apar_fechapreparacion").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("apar_fechapreparacion").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("apar_fechapreparacion").Header.Caption = "Fecha Preparación"
        grid.DisplayLayout.Bands(0).Columns("apartados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("apartados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("apartados").Header.Caption = "Apartados"
        grid.DisplayLayout.Bands(0).Columns("totApartados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("totApartados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("totApartados").Header.Caption = "Pares en apartados"
        grid.DisplayLayout.Bands(0).Columns("apartadosConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("apartadosConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("apartadosConfirmados").Header.Caption = "Apartados confirmados"
        grid.DisplayLayout.Bands(0).Columns("totConfirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("totConfirmados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("totConfirmados").Header.Caption = "Pares confirmados"
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartado").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartado").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartado").Header.Caption = "% Apartado"
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobal").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobal").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeGlobal").Header.Caption = "% Global"

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

        totalApartados = 0
        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeApartado").Value = Math.Round(((row.Cells("totConfirmados").Value * 100) / row.Cells("totApartados").Value), 2)
            row.Cells("porcentajeApartado").Value = row.Cells("porcentajeApartado").Value.ToString + "%"
            totalApartados += row.Cells("totApartados").Value
        Next

        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeGlobal").Value = Math.Round(((row.Cells("totConfirmados").Value * 100) / totalApartados), 2)
            'row.Cells("porcentajeGlobal").Value = row.Cells("porcentajeGlobal").Value + "%"
        Next



        Dim summary1, summary2, summary3, summary4, summary5 As SummarySettings
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global", SummaryType.Custom, New Tools.PersonalizarSummary("porcentajeGlobal"), grid.DisplayLayout.Bands(0).Columns("porcentajeGlobal"), SummaryPosition.UseSummaryPositionColumn, Nothing)
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("apartados"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("totApartados"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Apartados Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("apartadosConfirmados"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("totConfirmados"))
        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total % Global", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajeGlobal"))


        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:#,##0}"
        summary5.Appearance.TextHAlign = HAlign.Right


        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeGlobal").Value = row.Cells("porcentajeGlobal").Value + "%"
        Next

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

    Private Sub btnMostrarApartados_Click(sender As Object, e As EventArgs) Handles btnMostrarApartados.Click
        Cursor = Cursors.WaitCursor

        poblarGridReportesApartados(grdReportesApartados)

        If grdReportesApartados.Rows.Count > 0 Then
            lblUltimaActualizacionApartados.Visible = True
            lblFechaUAApartados.Visible = True
            lblHoraUAApartados.Visible = True

            lblFechaUAApartados.Text = Date.Now.ToShortDateString
            lblHoraUAApartados.Text = Date.Now.ToShortTimeString
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiarAPartados_Click(sender As Object, e As EventArgs) Handles btnLimpiarAPartados.Click
        grdReportesApartados.DataSource = Nothing
        grdOperadorApartados.DataSource = String.Empty
        grid_complejo_diseño(grdOperadorApartados)
        grdOperadorApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"

        grdClienteApartados.DataSource = String.Empty
        grid_complejo_diseño(grdClienteApartados)
        grdClienteApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"

        grdPedidoApartados.DataSource = String.Empty
        grid_complejo_diseño(grdPedidoApartados)
        grdPedidoApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"

        grdApartados.DataSource = String.Empty
        grid_complejo_diseño(grdApartados)
        grdApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Apartados"

        cmbApartadoTipoReporte.SelectedIndex = 0
        dtpFechaInicioApartados.Value = Now.Date
        dtpFechaFinApartados.Value = Now.Date
    End Sub

    Public Sub disenioGridApartadosReportePorEstatus(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim totalApartados As Int32
        Dim totalPares As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("esta_nombre").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("esta_nombre").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("esta_nombre").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("apartados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("apartados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("apartados").Header.Caption = "Apartados"
        grid.DisplayLayout.Bands(0).Columns("pares").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("pares").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("pares").Header.Caption = "Pares Confirmados"
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartados").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajeApartados").Header.Caption = "% Apartado"
        grid.DisplayLayout.Bands(0).Columns("porcentajePares").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("porcentajePares").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("porcentajePares").Header.Caption = "% Pares Confirmados"

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

        totalApartados = 0
        For Each row As UltraGridRow In grid.Rows
            totalApartados += row.Cells("Apartados").Value
            totalPares += row.Cells("pares").Value
        Next

        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeApartados").Value = Math.Round(((row.Cells("apartados").Value * 100) / totalApartados), 2)
            row.Cells("porcentajePares").Value = Math.Round(((row.Cells("pares").Value * 100) / totalPares), 2)
        Next



        Dim summary1, summary2, summary3, summary4 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("apartados"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("pares"))
        'summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajeApartados"))
        'summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajePares"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Apartados", SummaryType.Custom, New Tools.PersonalizarSummary("porcentajeApartados"), grid.DisplayLayout.Bands(0).Columns("porcentajeApartados"), SummaryPosition.UseSummaryPositionColumn, Nothing)
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Pares", SummaryType.Custom, New Tools.PersonalizarSummary("porcentajePares"), grid.DisplayLayout.Bands(0).Columns("porcentajePares"), SummaryPosition.UseSummaryPositionColumn, Nothing)
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right


        For Each row As UltraGridRow In grid.Rows
            row.Cells("porcentajeApartados").Value = row.Cells("porcentajeApartados").Value + "%"
            row.Cells("porcentajePares").Value = row.Cells("porcentajePares").Value + "%"
        Next

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


    Public Sub disenioGridApartadosReporteConfirmadoFechaUsuario(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim totalPares As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").Header.Caption = "Fecha Confirmación"


        For cont = 0 To operadores.Length - 1
            If operadores(cont).ToString <> Nothing Then
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).CellAppearance.TextHAlign = HAlign.Right
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).GroupByMode = GroupByMode.Text
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).Header.Caption = operadores(cont).ToString
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns("total").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("total").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("total").Header.Caption = "Total"

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

        For Each row As UltraGridRow In grid.Rows
            totalPares = 0
            For i = 0 To operadores.Length - 1
                totalPares = totalPares + row.Cells(operadores(i).ToString).Value
            Next
            row.Cells("total").Value = totalPares.ToString("N0")
        Next


        Dim summary1, summary2 As SummarySettings
        'Dim summary3, summary4 As SummarySettings

        For x = 0 To operadores.Length - 1
            summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total" + x.ToString, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(operadores(x).ToString))
            summary1.DisplayFormat = "{0:#,##0}"
            summary1.Appearance.TextHAlign = HAlign.Right
        Next
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("total"))
        'summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("pares"))
        'summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajeApartados"))
        'summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Porcentaje Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("porcentajePares"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        'summary3.DisplayFormat = "{0:#,##0}"
        'summary3.Appearance.TextHAlign = HAlign.Right
        'summary4.DisplayFormat = "{0:#,##0}"
        'summary4.Appearance.TextHAlign = HAlign.Right


        'For Each row As UltraGridRow In grid.Rows
        '    row.Cells("porcentajeApartados").Value = row.Cells("porcentajeApartados").Value + "%"
        '    row.Cells("porcentajePares").Value = row.Cells("porcentajePares").Value + "%"
        'Next

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

    Public Sub disenioGridApartadosReporteApartadosConfirmadoFechaUsuario(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim totalPares As Int32

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").CellAppearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("fechaConfirmacion").Header.Caption = "Fecha Confirmación"


        For cont = 0 To operadores.Length - 1
            If operadores(cont).ToString <> Nothing Then
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).CellAppearance.TextHAlign = HAlign.Right
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).GroupByMode = GroupByMode.Text
                grid.DisplayLayout.Bands(0).Columns(operadores(cont).ToString).Header.Caption = operadores(cont).ToString
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns("total").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("total").GroupByMode = GroupByMode.Text
        grid.DisplayLayout.Bands(0).Columns("total").Header.Caption = "Total"

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

        For Each row As UltraGridRow In grid.Rows
            totalPares = 0
            For i = 0 To operadores.Length - 1
                totalPares = totalPares + row.Cells(operadores(i).ToString).Value
            Next
            row.Cells("total").Value = totalPares
        Next


        Dim summary1, summary2 As SummarySettings

        For x = 0 To operadores.Length - 1
            summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total" + x.ToString, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(operadores(x).ToString))
            summary1.DisplayFormat = "{0:#,##0}"
            summary1.Appearance.TextHAlign = HAlign.Right
        Next
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("total"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right

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



    Private Sub grdReportesApartados_InitializePrint(sender As Object, e As CancelablePrintEventArgs) Handles grdReportesApartados.InitializePrint
        If cmbApartadoTipoReporte.SelectedValue = 3 Or cmbApartadoTipoReporte.SelectedValue = 4 Then

            'e.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = ps
            'e.PrintDocument.PrinterSettings.DefaultPageSettings.Landscape = False
            e.PrintDocument.DefaultPageSettings.Landscape = True

            'Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
            'pb.PageSettings.Landscape = True
        End If
    End Sub



    Private Sub grdReportesApartados_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs) Handles grdReportesApartados.InitializePrintPreview


        If cmbApartadoTipoReporte.SelectedValue = 3 Or cmbApartadoTipoReporte.SelectedValue = 4 Then

            'e.PrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = ps
            'e.PrintDocument.PrinterSettings.DefaultPageSettings.Landscape = False
            e.PrintDocument.DefaultPageSettings.Landscape = True
            e.PrintDocument.DefaultPageSettings.Margins.Left = CInt(Math.Ceiling(e.PrintDocument.DefaultPageSettings.HardMarginX))
            e.PrintDocument.DefaultPageSettings.Margins.Right = CInt(Math.Ceiling(e.PrintDocument.DefaultPageSettings.HardMarginX))
            e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1
            'Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
            'pb.PageSettings.Landscape = True
        Else
            e.PrintDocument.DefaultPageSettings.Margins.Left = CInt(Math.Ceiling(e.PrintDocument.DefaultPageSettings.HardMarginX))
            e.PrintDocument.DefaultPageSettings.Margins.Right = CInt(Math.Ceiling(e.PrintDocument.DefaultPageSettings.HardMarginX))
            e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1
            Dim ps As New PaperSize("A4Portrait", 827, 1169)
            ps.PaperName = PaperKind.A4
        End If

    End Sub

#End Region



    Private Sub CargarInventario()
        Dim ObjBU As New Negocios.ClientesAlmacenBU()
        Dim DatosInventario = ObjBU.ReporteInventario(dtpFechaInicioInventarioInicial.Text, dtpFechaTerminoInventarioInicial.Text, cboxNave.SelectedValue)
        If IsNothing(DatosInventario) Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos.")
            btnImprimir.Enabled = False
            btnExportar.Enabled = False
        Else

            btnImprimir.Enabled = True
            btnExportar.Enabled = True
            viewReporteInventarioInicial.Columns.Clear()
            gridReporteInventarioInicial.DataSource = DatosInventario
            DiseñoGrid.DiseñoBaseGrid(viewReporteInventarioInicial)
            viewReporteInventarioInicial.IndicatorWidth = 35
            viewReporteInventarioInicial.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewReporteInventarioInicial, "id", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewReporteInventarioInicial, "concepto", "Concepto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 180, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewReporteInventarioInicial, "Total", "Total", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewReporteInventarioInicial.Columns
                If col.FieldName <> "concepto" Then
                    viewReporteInventarioInicial.Columns.ColumnByFieldName(col.FieldName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    viewReporteInventarioInicial.Columns.ColumnByFieldName(col.FieldName).DisplayFormat.FormatString = "N0"
                End If


            Next




        End If

    End Sub

    Private Sub viewReporteInventarioInicial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewReporteInventarioInicial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub viewviewReporteInventarioInicial_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewReporteInventarioInicial.CustomDrawCell

        Dim concepto As String = viewReporteInventarioInicial.GetRowCellValue(e.RowHandle, "concepto")

        Cursor = Cursors.WaitCursor
        Try
            If e.RowHandle >= 0 Then
                If concepto <> String.Empty Then

                    If concepto = "INVENTARIO INICIAL SICY" Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                        e.Appearance.ForeColor = Color.Black
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    ElseIf concepto = "PARES INGRESADOS" Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                        e.Appearance.ForeColor = Color.Black
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    ElseIf concepto = "SALIDAS DE ALMACÉN" Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                        e.Appearance.ForeColor = Color.Black
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    ElseIf concepto = "INVENTARIO FINAL SICY" Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                        e.Appearance.ForeColor = Color.Black
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    ElseIf concepto = "MOVIMIENTOS ALMACÉN" Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                        e.Appearance.ForeColor = Color.Black
                        e.Appearance.FontStyleDelta = FontStyle.Bold
                    Else
                        e.Appearance.BackColor = Color.White
                        e.Appearance.ForeColor = Color.Black
                    End If

                    If concepto <> "PARES ENTREGA NAVE" And concepto <> "MOVIMIENTOS ALMACÉN" And concepto <> "PARES OTRAS ENTRADAS" And concepto <> "INVENTARIO FINAL SICY" And concepto <> "SALIDAS DE ALMACÉN" And concepto <> "PARES INGRESADOS" And concepto <> "INVENTARIO INICIAL SICY" Then
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        e.Appearance.ForeColor = Color.Black
                    End If

                End If
                'If e.Column.FieldName <> "concepto" Then
                '                e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'e.Column.DisplayFormat.FormatString = "N0"
                'End If
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dtpFechaInicioProductividad_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicioProductividad.ValueChanged
        dtpFechaTerminoProductividad.MinDate =dtpFechaInicioProductividad .Value 
    End Sub
End Class