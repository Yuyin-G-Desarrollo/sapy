Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Threading.Tasks
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class Apartados_InventarioDisponible_Form
    Private Delegate Sub UpdateDataSourceDelegate()
    Private data As DataTable
    Dim clone As DataTable = Nothing
    Private Sub Apartados_InventarioDisponible_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)
        clone = grdInventarioDisponible.DataSource
        Control.CheckForIllegalCrossThreadCalls = False
        ConsultarDatos.RunWorkerAsync()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            pgrGenerarDatos.Visible = True
            ConsultarDatos.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show("Ya se está ejecutando la tarea")
        End Try


    End Sub

    'Private Sub mostrarInventarioDisponible()
    '    Cursor = Cursors.WaitCursor
    '    Dim objBU As New Negocios.ApartadosBU
    '    Dim tablaResultado As New DataTable

    '    tablaResultado = objBU.consultaInventarioDisponible
    '    grdInventarioDisponible.DataSource = Nothing
    '    grdInventarioDisponible.DataSource = tablaResultado

    '    lblFechaUltimaActualizacion.Text = Date.Now.ToString()
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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

    'Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

    '    For Each col In grid.DisplayLayout.Bands(0).Columns
    '        If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
    '            col.Style = ColumnStyle.Integer
    '            col.CellAppearance.TextHAlign = HAlign.Right
    '        End If

    '        If col.DataType.Name.ToString.Equals("Decimal") Then
    '            col.Style = ColumnStyle.DoublePositive
    '            col.CellAppearance.TextHAlign = HAlign.Right
    '        End If

    '        If col.DataType.Name.ToString.Equals("String") Then
    '            If col.Header.Caption.Equals("TELÉFONO") Then
    '                col.MaskInput = "+## (###) ###-####"
    '                col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
    '                col.CellAppearance.TextHAlign = HAlign.Right
    '            ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
    '                col.MaskInput = "ext: 9999"
    '                col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
    '                col.CellAppearance.TextHAlign = HAlign.Right
    '            Else
    '                col.CellAppearance.TextHAlign = HAlign.Left
    '            End If
    '        End If
    '    Next
    'End Sub

    ''Private Sub btnExportarExcelInventario_Click(sender As Object, e As EventArgs) Handles btnExportarExcelInventario.Click
    '    Cursor = Cursors.WaitCursor
    '    Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
    '    Dim fbdUbicacionArchivo As New FolderBrowserDialog
    '    Dim grid As New UltraGrid
    '    Dim nombreDocumento As String = String.Empty
    '    Dim advertencia As New AdvertenciaForm
    '    grid = grdInventarioDisponible
    '    If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
    '        nombreDocumento = "\Inventario_Disponible_Apartados_"


    '        With fbdUbicacionArchivo

    '            .Reset()
    '            .Description = " Seleccione una carpeta "
    '            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    '            .ShowNewFolderButton = True

    '            Dim ret As DialogResult = .ShowDialog

    '            If ret = Windows.Forms.DialogResult.OK Then

    '                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
    '                gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

    '                Dim mensajeExito As New ExitoForm
    '                Cursor = Cursors.Default
    '                mensajeExito.mensaje = "Los datos se exportaron correctamente"
    '                mensajeExito.ShowDialog()

    '            End If
    '            .Dispose()
    '        End With
    '    Else
    '        Cursor = Cursors.Default
    '        advertencia.mensaje = "No hay datos para exportar "
    '        advertencia.ShowDialog()
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub gridInventarioDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
    '    asignaFormato_Columna(grdInventarioDisponible)
    '    With grid.DisplayLayout
    '        .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
    '        .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
    '        .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '        .Override.RowSelectorWidth = 35
    '        .Override.CellClickAction = CellClickAction.RowSelect
    '        .Override.AllowAddNew = AllowAddNew.No
    '        .Override.AllowUpdate = DefaultableBoolean.False
    '        .Scrollbars = Scrollbars.Both
    '        .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
    '        .Bands(0).ColHeaderLines = 1
    '    End With
    '    grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
    '    grid.DisplayLayout.GroupByBox.Hidden = False
    '    grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


    '    Dim width As Integer
    '    For Each col As UltraGridColumn In grid.Rows.Band.Columns
    '        col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '        If Not col.Hidden Then
    '            width += col.Width
    '        End If
    '    Next

    '    If grid.DisplayLayout.Bands(0).Columns.Exists("PE_ID") Then
    '        grid.DisplayLayout.Bands(0).Columns("PE_ID").Width = 50
    '    End If

    '    Dim summary1, summary2, summary3 As SummarySettings
    '    summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Existencia", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Existencia"))
    '    summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Por Confirmar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PorConfirmar"))
    '    summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Disponibles", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Disponible"))
    '    grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    '    summary1.DisplayFormat = "{0:#,##0}"
    '    summary1.Appearance.TextHAlign = HAlign.Right
    '    summary2.DisplayFormat = "{0:#,##0}"
    '    summary2.Appearance.TextHAlign = HAlign.Right
    '    summary3.DisplayFormat = "{0:#,##0}"
    '    summary3.Appearance.TextHAlign = HAlign.Right
    'End Sub

    'Private Sub grdInventarioDisponible_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
    '    gridInventarioDiseño(grdInventarioDisponible)
    'End Sub

    Private Sub ConsultarDatos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConsultarDatos.DoWork
        CargarInventario()
    End Sub

    Private Sub CargarInventario()
        Dim cedis As Integer
        Dim objBU As New Negocios.ApartadosBU
        pgrGenerarDatos.Show()
        cedis = cboxNaveAlmacen.SelectedValue
        pgrGenerarDatos.Description = "Obteniendo Registros"
        data = objBU.consultaInventarioDisponible(cedis)
        pgrGenerarDatos.Description = "Mostrando datos"
        UpdateGridDataSource()

    End Sub
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInventarioDisponible.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub ConsultarDatos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConsultarDatos.RunWorkerCompleted

        DiseñoGrid.DiseñoBaseGrid(viewInventarioDisponible)
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "Existencia", "Existencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 70, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "ModeloSAY", "Modelo" & vbCrLf & "SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 55, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "PorConfirmar", "Por" & vbCrLf & "Confirmar", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 75, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "Disponible", "Disponible", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 70, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "ModeloSICY", "Modelo" & vbCrLf & "SICY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 55, False, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "Color", "Color", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventarioDisponible, "Piel", "Piel", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 70, False, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

        pgrGenerarDatos.Visible = False
        lblFechaUltimaActualizacion.Text = Date.Now.ToString()
    End Sub

    Private Sub UpdateGridDataSource()
        clone = data.Copy()
        grdInventarioDisponible.BeginInvoke(New MethodInvoker(AddressOf AnonymousMethod1))
        data = clone
    End Sub

    Private Sub AnonymousMethod1()
        grdInventarioDisponible.DataSource = clone
    End Sub

    Private Sub btnExportarExcelInventario_Click(sender As Object, e As EventArgs) Handles btnExportarExcelInventario.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
                'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    grdInventarioDisponible.ExportToXlsx(.SelectedPath + "\ReporteInventarioDispobible_" + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " + "\ReporteInventarioDispobible_" + fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\ReporteInventarioDispobible_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        ConsultarDatos.RunWorkerAsync()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdInventarioDisponible.DataSource = Nothing
        ConsultarDatos.RunWorkerAsync()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 26
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 78
    End Sub
End Class