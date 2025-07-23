Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools

Public Class ListadoUbicacionAgrupamiento
    Public nave_almacen As String
    Public Con_Sin_Ubicacion, tipo_agrupamiento As Integer
    Public lPar, lAtado, lLote, AnioLote, lLoteCliente, lNave, lPedidoOrigen, lPedido, _
            lCliente, lTienda, lAgente, lOrdenCliente, lApartado, _
            lProducto, lCorrida, lTalla, lBahia, lDescripcionBahia, lColaborador, _
            fechaInicio, fechaTermino, fechaInicioEntregaP, fechaTerminoEntregaP, lFiltroEstatus As String
    Public bY_O, mostrar_todo, buscarContenidoAtado, filtroFechas, filtroFechaEntregaP As Boolean
    'Public bY_O, mostrar_todo, filtroFechas, ResultadoNulo, cargaArchivo, buscarContenidoAtado, filtroFechaEntregaP As Boolean

    Private Sub ListadoUbicacionAgrupamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipo_agrupamiento = 1 Then
            Me.Text = "Producto en Almacén por Pedido SICY"
            lblTitulo.Text = "Producto en Almacén por Pedido SICY"

        ElseIf tipo_agrupamiento = 2 Then
            Me.Text = "Producto en Almacén por Fecha de Entrega de Pedido SICY"
            lblTitulo.Text = "Producto en Almacén por Fecha de Entrega de Pedido SICY"
        Else
            Me.Text = "Producto en Almacén por Pedido SICY"
            lblTitulo.Text = "Producto en Almacén por Pedido SICY"
        End If

        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        GridView1.Columns.Clear()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim dtListado As New DataTable

        Dim nave_almacen_split() As String
        Dim strBY_O As String

        nave_almacen_split = nave_almacen.Split(",")

        If bY_O Then
            strBY_O = " AND "
        Else
            strBY_O = " OR "
        End If

        dtListado = objBU.localizarProductoEnAlmacenPorAgrupamiento(nave_almacen_split(0), nave_almacen_split(1), Con_Sin_Ubicacion, tipo_agrupamiento, _
                                                                    strBY_O, lPar, lLote, lAtado, AnioLote, _
                                                                    lLoteCliente, lNave, lPedidoOrigen, lPedido, lCliente, _
                                                                    lTienda, lAgente, lOrdenCliente, lApartado, lProducto, _
                                                                    lCorrida, lTalla, lBahia, lDescripcionBahia, _
                                                                    lColaborador, lFiltroEstatus, filtroFechas, fechaInicio, fechaTermino, _
                                                                    filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                If dtListado.Rows.Count = 1 Then
                    If dtListado.Columns(0).ColumnName = "Mensaje" Then
                        Me.Cursor = Cursors.Default
                        show_message("Error", "El tráfico de datos en las tablas de ubicaciones no permite consultar en este momento. Por favor vuelva a intentar más tarde.")
                        Me.Close()
                    Else
                        GridControl1.DataSource = dtListado
                        grdListaUbicacionDisenodev()

                        'grdListaUbicacion.DataSource = dtListado
                        'grdListaUbicacionDiseno()

                        lblFechaUltimaActualizacion.Text = Date.Now.ToShortDateString
                        lblHoraUltimaActualizacion.Text = Date.Now.ToShortTimeString
                    End If
                Else
                    GridControl1.DataSource = dtListado
                    grdListaUbicacionDisenodev()

                    'grdListaUbicacion.DataSource = dtListado
                    'grdListaUbicacionDiseno()

                    lblFechaUltimaActualizacion.Text = Date.Now.ToShortDateString
                    lblHoraUltimaActualizacion.Text = Date.Now.ToShortTimeString
                End If
            Else
                GridControl1.DataSource = Nothing
                'grdListaUbicacionDisenodev()

                'grdListaUbicacion.DataSource = Nothing
                'grdListaUbicacion.DataBind()

                Me.Enabled = False
                show_message("Aviso", "La consulta no devolvió ningún resultado")
                Me.Cursor = Cursors.Default
                Me.Close()
            End If
        Else
            GridControl1.DataSource = Nothing
            'grdListaUbicacionDisenodev()

            'grdListaUbicacion.DataSource = Nothing
            'grdListaUbicacion.DataBind()

            Me.Enabled = False
            show_message("Aviso", "La consulta no devolvió ningún resultado")
            Me.Cursor = Cursors.Default
            Me.Close()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub grdListaUbicacionDisenodev()
        GridView1.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        GridView1.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0}")

        ' Create and setup the first summary item.
        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = "Pares"
        item.SummaryType = DevExpress.Data.SummaryItemType.Count
        item.DisplayFormat = "Total: {0}"
        GridView1.GroupSummary.Add(item)

        GridView1.BestFitMaxRowCount = -1
        GridView1.BestFitColumns()

    End Sub
    Private Sub grdListaUbicacionDiseno()
        Try
            grdListaUbicacion.DisplayLayout.Bands(0).Columns("FEntrega").Style = ColumnStyle.Date
            grdListaUbicacion.DisplayLayout.Bands(0).Columns("FEntrega").AllowRowFiltering = DefaultableBoolean.False
            grdListaUbicacion.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
            grdListaUbicacion.DisplayLayout.Bands(0).Columns("Pares").Format = "##,###"

            grdListaUbicacion.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            grdListaUbicacion.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            grdListaUbicacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdListaUbicacion.DisplayLayout.Override.RowSelectorWidth = 35
            grdListaUbicacion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            grdListaUbicacion.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            grdListaUbicacion.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            grdListaUbicacion.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grdListaUbicacion.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            grdListaUbicacion.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            grdListaUbicacion.DisplayLayout.GroupByBox.Hidden = False
            grdListaUbicacion.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

            Dim columnToSummarize As UltraGridColumn = grdListaUbicacion.DisplayLayout.Bands(0).Columns("Pares")
            Dim summary As SummarySettings = grdListaUbicacion.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
            summary.DisplayFormat = "{0:##,##0}"
            summary.Appearance.TextHAlign = HAlign.Right
            grdListaUbicacion.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

            Dim width As Integer
            For Each col As UltraGridColumn In grdListaUbicacion.Rows.Band.Columns
                If Not col.Hidden Then
                    width += col.Width
                End If
            Next

            If width > grdListaUbicacion.Width Then
                grdListaUbicacion.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            Else
                grdListaUbicacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If
        Catch ex As Exception

        End Try
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        cargarDatos()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
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
                'Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                'gridExcelExporter.Export(Me.grdListaUbicacion, .SelectedPath & "\Datos_ListaUbicaciones_" & fecha_hora & ".xlsx")
                GridView1.ExportToXlsx(.SelectedPath & "\Datos_ListaUbicaciones_" & fecha_hora & ".xlsx")
            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()
        End With
    End Sub
End Class