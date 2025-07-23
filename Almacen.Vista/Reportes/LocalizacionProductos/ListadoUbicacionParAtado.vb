Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration

Public Class ListadoUbicacionParAtado

    Public nave_almacen As String
    Public tipo_busqueda, Con_Sin_Ubicacion As Integer
    'Public lPar, lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, lCliente,
    '        lTienda, lPedido, lApartado, lDevolucion, lBahia,
    '        lDescripcionBahia, lColaborador, lAgente, lProducto,
    '        lCorrida, lTalla, lLoteCliente, fechaInicio, fechaTermino, lFiltroEstatus, fechaInicioEntregaP, fechaTerminoEntregaP As String
    'Public bY_O, mostrar_todo, filtroFechas, ResultadoNulo, cargaArchivo, buscarContenidoAtado, filtroFechaEntregaP As Boolean
    Public cargaArchivo, ResultadoNulo, buscarContenidoAtado, mostrar_todo As Boolean

    Public Filtros As New Entidades.LocalizacionProducto
    Private Sub ListadoUbicacionParAtado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        pnlResumen.Visible = False

        'poblar_gridListaUbicacion(gridListaUbicacion)
        poblar_gridListaUbicaciondev(GridControl1)

        'Dim pares, erroneos, atados, totalPares As Integer
        'If Not IsNothing(gridListaUbicacion.Rows) Then
        '    For Each row As ultragridrow In gridListaUbicacion.Rows

        '        If Not row.Cells("Par").Text.Equals("   --  ") Then
        '            If row.Cells("P/A").Text.Equals("P") Then
        '                pares += 1
        '            Else
        '                If row.Cells("P/A").Text.Equals("E") Or row.Cells("P/A").Text.Equals("C") Then
        '                    erroneos += 1
        '                End If
        '            End If
        '        End If

        '        If row.Cells("Par").Text.Equals("   --  ") Then
        '            atados += 1
        '        End If

        '        totalPares += CInt(row.Cells("Prs").Value)

        '    Next
        'End If
        'If Not IsNothing(GridControl1.MainView.DataRowCount) Then
        '    For Each row As GridRow In GridControl1.MainView.GetRow(0)


        '        If Not row.RowKey("Par").Text.Equals("   --  ") Then
        '            If row.RowKey("P/A").Text.Equals("P") Then
        '                pares += 1
        '            Else
        '                If row.RowKey("P/A").Text.Equals("E") Or row.RowKey("P/A").Text.Equals("C") Then
        '                    erroneos += 1
        '                End If
        '            End If
        '        End If

        '        If row.RowKey("Par").Text.Equals("   --  ") Then
        '            atados += 1
        '        End If

        '        totalPares += CInt(row.RowKey("Prs").Value)

        '    Next
        'End If

        'lblRecuperados.Text = GridControl1.MainView.RowCount.ToString("N0", CultureInfo.InvariantCulture)
        'lblAtados.Text = atados.ToString("N0", CultureInfo.InvariantCulture)
        'lblPares.Text = pares.ToString("N0", CultureInfo.InvariantCulture)
        'lblErroneos.Text = erroneos.ToString("N0", CultureInfo.InvariantCulture)
        'lblTotalPares.Text = totalPares.ToString("N0", CultureInfo.InvariantCulture)


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_INVENTARIOCICLICO", "VER_BOTON_CICLICO") Then
            btnCiclico.Visible = True
            lblCiclico.Visible = True
        Else
            btnCiclico.Visible = False
            lblCiclico.Visible = False
        End If

        'comentado tarda mucho la consulta
        'DESCOMENTADO POR LUIS MARIO 14/10/2016: RUBEN INFORMA NO SE ESTAN ACTUALIZANDO LOS PARES DE COPPEL CONFIRMADOS
        actualizarContenidoAtadosUbicacionPares()
    End Sub
    Private Sub actualizarContenidoAtadosUbicacionPares()
        Dim objBU As New Negocios.ClientesAlmacenBU
        Try
            objBU.actualizarContenidoAtadosUbicacionPares()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub poblar_gridListaUbicaciondev(grid As DevExpress.XtraGrid.GridControl)
        Me.Cursor = Cursors.WaitCursor

        grid.DataSource = Nothing
        GridView1.Columns.Clear()

        Dim objBU As New Negocios.ClientesAlmacenBU

        Dim actualizacion As Boolean = False
        actualizacion = objBU.Almacen_ActualizaStock()

        Dim Tabla_ListaUbicacion As New DataTable
        'Dim nave_almacen_split() As String
        'nave_almacen_split = nave_almacen.Split(",")

        If Not cargaArchivo Then
            lblParesSAY.Text = objBU.Pares_en_SAY(Filtros.NaveID, Filtros.Almacen).ToString("N0", CultureInfo.InvariantCulture)
            lblParesSicy.Text = objBU.Pares_en_SICY(Filtros.NaveID, Filtros.Almacen).ToString("N0", CultureInfo.InvariantCulture)

        End If

        If Not buscarContenidoAtado Then
            Tabla_ListaUbicacion = objBU.LocalizarProducto(Filtros)
            'If mostrar_todo Then ''REALIZA LA BUSQUEDA UBICACION PAR Y EN UBICACION ATADO
            '    Try
            '        Tabla_ListaUbicacion = objBU.ListadoUbicacion_SinFiltros(Filtros.NaveID, Filtros.Almacen, mostrar_todo,
            '                                                             Filtros.FiltroFecha, Filtros.FechaInicio, Filtros.FechaFin, Con_Sin_Ubicacion,
            '                                                             Filtros.FiltroFechaEntPedidos, Filtros.FechaInicioPedidos, Filtros.FechaFinPedidos)
            '    Catch ex As Exception
            '        show_message("Error", ex.ToString)
            '        Me.Close()
            '    End Try


            'Else
            '    If Not String.IsNullOrEmpty(lPar) _
            '        Or Not String.IsNullOrEmpty(lCliente) _
            '        Or Not String.IsNullOrEmpty(lTienda) _
            '        Or Not String.IsNullOrEmpty(lPedido) _
            '        Or Not String.IsNullOrEmpty(lApartado) _
            '        Or Not String.IsNullOrEmpty(lTalla) Then ''REALIZA LA BUSQUEDA EN UBICACION PAR, UBICACION ATADO Y CONTENIDO ATADO
            '        Try
            '            Tabla_ListaUbicacion = objBU.ListadoUbicacion_Completo(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
            '                                                                   lPar, lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
            '                                                                   lCliente, lTienda, lPedido, lApartado, _
            '                                                                   lBahia, lDescripcionBahia, lColaborador, lAgente, _
            '                                                                   lProducto, lCorrida, lTalla, lLoteCliente, lFiltroEstatus, _
            '                                                                   bY_O, _
            '                                                                   filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, _
            '                                                                   filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)

            '        Catch ex As Exception
            '            show_message("Error", ex.ToString)
            '            Me.Close()
            '        End Try

            '    Else ''REALIZA LA BUSQUEDA UBICACION PAR Y EN UBICACION ATADO INCLUYENDO FILTROS
            '        If cargaArchivo Then ''VERIFICA SI LA BUSQUEDA ES DESDE LA PANTALLA DE CARGA DE ARCHIVOS .DAT
            '            Try
            '                Tabla_ListaUbicacion = objBU.ListadoUbicacion_SinFiltros_CargaArchivo(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
            '                                                             filtroFechas, fechaInicio, fechaTermino, lColaborador)
            '            Catch ex As Exception
            '                show_message("Error", ex.ToString)
            '                Me.Close()
            '            End Try

            '        Else
            '            Try
            '                Tabla_ListaUbicacion = objBU.ListadoUbicacion_UbPar_UbAtado(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
            '                                                                            lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
            '                                                                            lBahia, lDescripcionBahia, lColaborador, _
            '                                                                            lAgente, lProducto, lCorrida, lLoteCliente, lFiltroEstatus, _
            '                                                                            bY_O, _
            '                                                                            filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, _
            '                                                                            filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)

            '            Catch ex As Exception
            '                show_message("Error", ex.ToString)
            '                Me.Close()
            '            End Try

            '        End If


            '    End If
            'End If

        Else
            'Try
            '    Tabla_ListaUbicacion = objBU.ListadoUbicacion_Completo_ContenidoAtado(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
            '                                                              lPar, lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
            '                                                              lCliente, lTienda, lPedido, lApartado, _
            '                                                              lBahia, lDescripcionBahia, lColaborador, lAgente, _
            '                                                              lProducto, lCorrida, lTalla, lLoteCliente, lFiltroEstatus, _
            '                                                              bY_O, _
            '                                                              filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, filtroFechaEntregaP,
            '                                                              fechaInicioEntregaP, fechaTerminoEntregaP)
            'Catch ex As Exception
            '    show_message("Error", ex.ToString)
            '    Me.Close()
            'End Try

        End If

        If Tabla_ListaUbicacion.Rows.Count > 0 Then
            lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
            lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString
            pnlResumen.Visible = True

        Else
            Me.Enabled = False
            show_message("Aviso", "La consulta no devolvió ningún resultado")
            ResultadoNulo = True
            Me.Close()
        End If

        If Tabla_ListaUbicacion.Rows.Count > 0 Then
            If Tabla_ListaUbicacion.Rows.Count = 1 Then
                If Tabla_ListaUbicacion.Columns(0).ColumnName = "Mensaje" Then
                    Me.Cursor = Cursors.Default
                    show_message("Error", "El tráfico de datos en las tablas de ubicaciones no permite consultar en este momento. Por favor vuelva a intentar más tarde.")
                    Me.Close()
                Else

                    'grid.DataSource = Tabla_ListaUbicacion
                    'gridListaUbicacionDiseno(grid)

                    GridControl1.DataSource = Tabla_ListaUbicacion
                    gridListaUbicacionDiseno(GridView1)


                End If
            Else
                'grid.DataSource = Tabla_ListaUbicacion
                'gridListaUbicacionDiseno(grid)

                GridControl1.DataSource = Tabla_ListaUbicacion
                gridListaUbicacionDiseno(GridView1)


            End If

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                If (col.FieldName = "Fecha Ubicación Ant. (Hr)") Then
                    col.Width = "150"
                End If
                If (col.FieldName = "Producto") Then
                    col.Width = "275"
                End If
                If (col.FieldName = "Salida de Nave (hr)") Then
                    col.Width = "150"
                End If
                If (col.FieldName = "Entrada Almacén (hr)") Then
                    col.Width = "150"
                End If
                If (col.FieldName = "Cliente") Then
                    col.Width = "400"
                End If
                If (col.FieldName = "Tienda") Then
                    col.Width = "150"
                End If
            Next

        End If


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = GridView1.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    'Public Sub poblar_gridListaUbicacion(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
    '    Me.Cursor = Cursors.WaitCursor

    '    grid.DataSource = Nothing
    '    GridView1.Columns.Clear()

    '    Dim objBU As New Negocios.ClientesAlmacenBU

    '    Dim actualizacion As Boolean = False
    '    actualizacion = objBU.Almacen_ActualizaStock()

    '    Dim Tabla_ListaUbicacion As New DataTable
    '    Dim nave_almacen_split() As String
    '    nave_almacen_split = nave_almacen.Split(",")

    '    If Not cargaArchivo Then
    '        lblParesSAY.Text = objBU.Pares_en_SAY(nave_almacen_split(0), nave_almacen_split(1)).ToString("N0", CultureInfo.InvariantCulture)
    '        lblParesSicy.Text = objBU.Pares_en_SICY.ToString("N0", CultureInfo.InvariantCulture)

    '    End If

    '    If Not buscarContenidoAtado Then

    '        If mostrar_todo Then ''REALIZA LA BUSQUEDA UBICACION PAR Y EN UBICACION ATADO
    '            Try
    '                Tabla_ListaUbicacion = objBU.ListadoUbicacion_SinFiltros(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
    '                                                                     filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion,
    '                                                                     filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)
    '            Catch ex As Exception
    '                show_message("Error", ex.ToString)
    '                Me.Close()
    '            End Try


    '        Else
    '            If Not String.IsNullOrEmpty(lPar) _
    '                Or Not String.IsNullOrEmpty(lCliente) _
    '                Or Not String.IsNullOrEmpty(lTienda) _
    '                Or Not String.IsNullOrEmpty(lPedido) _
    '                Or Not String.IsNullOrEmpty(lApartado) _
    '                Or Not String.IsNullOrEmpty(lTalla) Then ''REALIZA LA BUSQUEDA EN UBICACION PAR, UBICACION ATADO Y CONTENIDO ATADO
    '                Try
    '                    Tabla_ListaUbicacion = objBU.ListadoUbicacion_Completo(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
    '                                                                           lPar, lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
    '                                                                           lCliente, lTienda, lPedido, lApartado, _
    '                                                                           lBahia, lDescripcionBahia, lColaborador, lAgente, _
    '                                                                           lProducto, lCorrida, lTalla, lLoteCliente, lFiltroEstatus, _
    '                                                                           bY_O, _
    '                                                                           filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, _
    '                                                                           filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)

    '                Catch ex As Exception
    '                    show_message("Error", ex.ToString)
    '                    Me.Close()
    '                End Try

    '            Else ''REALIZA LA BUSQUEDA UBICACION PAR Y EN UBICACION ATADO INCLUYENDO FILTROS
    '                If cargaArchivo Then ''VERIFICA SI LA BUSQUEDA ES DESDE LA PANTALLA DE CARGA DE ARCHIVOS .DAT
    '                    Try
    '                        Tabla_ListaUbicacion = objBU.ListadoUbicacion_SinFiltros_CargaArchivo(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
    '                                                                     filtroFechas, fechaInicio, fechaTermino, lColaborador)
    '                    Catch ex As Exception
    '                        show_message("Error", ex.ToString)
    '                        Me.Close()
    '                    End Try

    '                Else
    '                    Try
    '                        Tabla_ListaUbicacion = objBU.ListadoUbicacion_UbPar_UbAtado(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
    '                                                                                    lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
    '                                                                                    lBahia, lDescripcionBahia, lColaborador, _
    '                                                                                    lAgente, lProducto, lCorrida, lLoteCliente, lFiltroEstatus, _
    '                                                                                    bY_O, _
    '                                                                                    filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, _
    '                                                                                    filtroFechaEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)

    '                    Catch ex As Exception
    '                        show_message("Error", ex.ToString)
    '                        Me.Close()
    '                    End Try

    '                End If


    '            End If
    '        End If

    '    Else
    '        Try
    '            Tabla_ListaUbicacion = objBU.ListadoUbicacion_Completo_ContenidoAtado(nave_almacen_split(0), nave_almacen_split(1), mostrar_todo, _
    '                                                                      lPar, lAtado, lLote, AnioLote, lNave, lPedidoOrigen, lOrdenCliente, _
    '                                                                      lCliente, lTienda, lPedido, lApartado, _
    '                                                                      lBahia, lDescripcionBahia, lColaborador, lAgente, _
    '                                                                      lProducto, lCorrida, lTalla, lLoteCliente, lFiltroEstatus, _
    '                                                                      bY_O, _
    '                                                                      filtroFechas, fechaInicio, fechaTermino, Con_Sin_Ubicacion, filtroFechaEntregaP,
    '                                                                      fechaInicioEntregaP, fechaTerminoEntregaP)
    '        Catch ex As Exception
    '            show_message("Error", ex.ToString)
    '            Me.Close()
    '        End Try

    '    End If

    '    If Tabla_ListaUbicacion.Rows.Count > 0 Then
    '        lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
    '        lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString
    '        pnlResumen.Visible = True

    '    Else
    '        Me.Enabled = False
    '        show_message("Aviso", "La consulta no devolvió ningún resultado")
    '        ResultadoNulo = True
    '        Me.Close()
    '    End If

    '    If Tabla_ListaUbicacion.Rows.Count > 0 Then
    '        If Tabla_ListaUbicacion.Rows.Count = 1 Then
    '            If Tabla_ListaUbicacion.Columns(0).ColumnName = "Mensaje" Then
    '                Me.Cursor = Cursors.Default
    '                show_message("Error", "El tráfico de datos en las tablas de ubicaciones no permite consultar en este momento. Por favor vuelva a intentar más tarde.")
    '                Me.Close()
    '            Else

    '                grid.DataSource = Tabla_ListaUbicacion
    '                'gridListaUbicacionDiseno(grid)

    '                GridControl1.DataSource = Tabla_ListaUbicacion
    '                gridListaUbicacionDiseno(GridView1)


    '            End If
    '        Else
    '            grid.DataSource = Tabla_ListaUbicacion
    '            'gridListaUbicacionDiseno(grid)

    '            GridControl1.DataSource = Tabla_ListaUbicacion
    '            gridListaUbicacionDiseno(GridView1)


    '        End If

    '    End If

    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub advBandedGridView1_CustomDrawCell(ByVal sender As Object, _
                                                  ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsFilterRow(e.RowHandle) Then
            Return
        End If
        If e.Column.FieldName = "P/A" Then
            'MessageBox.Show(e.DisplayText.ToString)
            If e.CellValue.ToString() = " " Then
                e.Appearance.BackColor = Color.Orange

            ElseIf e.CellValue.ToString() = "P" Then
                e.Appearance.BackColor = Color.Khaki
            ElseIf e.CellValue.ToString() = "A" Then
                e.Appearance.BackColor = Color.Aquamarine
            End If
            ' e.Column.Width = 10
        ElseIf e.Column.FieldName = "D" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.SeaGreen

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "A" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.RoyalBlue

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "C" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.SaddleBrown

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "B" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.Red

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "R" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.Indigo

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "P" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.DeepPink
            ElseIf e.CellValue.ToString() = "2" Then
                e.Appearance.BackColor = Color.HotPink

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "V" Then
            If e.CellValue.ToString() = " " Then

            ElseIf e.CellValue.ToString() = "1" Then
                e.Appearance.BackColor = Color.OrangeRed

            End If
            'e.Column.Width = 10
        End If
        'MessageBox.Show(Convert.ToString(e.Column.ColumnType.Name))
        'If Convert.ToString(e.Column.ColumnType.Name) = "DateTime" Then
        '    e.Column.DisplayFormat.FormatString = "M/d/yyyy HH:mm:ss"
        'End If

        'If e.Column.FieldName = "#" Then
        '    If Not e.CellValue Mod 2 > 0 Then
        '        Dim view As GridView = TryCast(sender, GridView)


        '        Dim val1 As String = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.VisibleColumns.Item(0)))

        '    End If
        'End If


        'If e.Column.FieldName = "Par" Then
        '    If Not e.CellValue.ToString = "   --  " Then
        '        If e.Column.Container.Components.Item Then
        '            pares += 1
        '        End If
        '        'Else
        '        '    If grid.RowKey("P/A").Text.Equals("E") Or row.RowKey("P/A").Text.Equals("C") Then
        '        '        erroneos += 1
        '        '    End If
        '    End If
        'End If

        '        If row.RowKey("Par").Text.Equals("   --  ") Then
        '            atados += 1
        '        End If



        'If row.RowKey("Par").Text.Equals("   --  ") Then
        '    atados += 1
        'End If



    End Sub

    Private Sub gridListaUbicacionDiseno(grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pares, erroneos, atados, totalPares As Integer
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.BestFitMaxRowCount = -1

        'GridView1.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        'AddHandler GridView1.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        'GridView1.Columns.Item("#").VisibleIndex = 0

        GridView1.Columns.ColumnByFieldName("Estiba ID").Visible = False
        GridView1.Columns.ColumnByFieldName("Bahía ID").Visible = False
        GridView1.Columns.ColumnByFieldName("Bahía").Visible = False
        GridView1.Columns.ColumnByFieldName("Bloque").Visible = False
        GridView1.Columns.ColumnByFieldName("Nivel").Visible = False
        GridView1.Columns.ColumnByFieldName("Posicion").Visible = False
        GridView1.Columns.ColumnByFieldName("Color").Visible = False
        'GridView1.BestFitColumns()
        'GridView1.Columns.ColumnByFieldName("#").Width = 55
        'GridView1.Columns.ColumnByFieldName("P/A").Width = 40
        'GridView1.Columns.ColumnByFieldName("D").Width = 10
        'GridView1.Columns.ColumnByFieldName("A").Width = 10
        'GridView1.Columns.ColumnByFieldName("C").Width = 10
        'GridView1.Columns.ColumnByFieldName("B").Width = 10
        'GridView1.Columns.ColumnByFieldName("R").Width = 10
        'GridView1.Columns.ColumnByFieldName("P").Width = 10
        'GridView1.Columns.ColumnByFieldName("V").Width = 10
        'GridView1.Columns.ColumnByFieldName("Prs").Width = 60
        GridView1.Columns.ColumnByFieldName("Prs").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

        ''GridView1.Columns.ColumnByFieldName("Tipo").Width = 40
        '--GridView1.Columns.ColumnByFieldName("Num At").Width = 40
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación(hr)").Width = 145
        ''GridView1.Columns.ColumnByFieldName("Fecha Ubicación(hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        'GridView1.Columns.ColumnByFieldName("Producto").Width = 450
        'GridView1.Columns.ColumnByFieldName("Talla").Width = 40

        'GridView1.Columns.Item(24).Width = 50
        'GridView1.Columns.Item(25).Width = 50
        'GridView1.Columns.ColumnByFieldName("Modelo").Width = 55
        'GridView1.Columns.ColumnByFieldName("Pedido").Width = 50
        'GridView1.Columns.ColumnByFieldName("Tienda").Width = 450
        'GridView1.Columns.ColumnByFieldName("Apartado").Width = 50
        'GridView1.Columns.ColumnByFieldName("Cliente").Width = 450
        'GridView1.Columns.ColumnByFieldName("Agte").Width = 45
        'GridView1.Columns.ColumnByFieldName("Lote").Width = 50
        'GridView1.Columns.ColumnByFieldName("Año").Width = 50
        'GridView1.Columns.ColumnByFieldName("OT").Width = 30
        'GridView1.Columns.ColumnByFieldName("Origen").Width = 40
        'GridView1.Columns.ColumnByFieldName("Salida de Nave (hr)").Width = 145
        'GridView1.Columns.ColumnByFieldName("Entrada Almacén (hr)").Width = 145
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación").Width = 90
        'GridView1.Columns.ColumnByFieldName("Salida de Nave").Width = 90
        'GridView1.Columns.ColumnByFieldName("Entrada Almacén").Width = 90
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación Ant. (Hr)").Width = 145
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación Ant.").Width = 145

        'GridView1.Columns.ColumnByFieldName("Salida de Nave (hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        GridView1.Columns.ColumnByFieldName("Entrada Almacén (hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación Ant. (Hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación Ant.").DisplayFormat.FormatString = "M/d/yyyy"
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación").DisplayFormat.FormatString = "M/d/yyyy"
        'GridView1.Columns.ColumnByFieldName("Salida de Nave").DisplayFormat.FormatString = "M/d/yyyy"
        'GridView1.Columns.ColumnByFieldName("Entrada Almacén").DisplayFormat.FormatString = "M/d/yyyy"

        GridView1.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        GridView1.Columns("Prs").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Prs", "{0:N0}")

        ' Make the group footers always visible.

        ' Create and setup the first summary item.
        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = "Prs"
        item.SummaryType = DevExpress.Data.SummaryItemType.Count
        item.DisplayFormat = "Total: {0:N0}"
        GridView1.GroupSummary.Add(item)

        'GridView1.BestFitColumns()

        'Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Prs", "Sum={0}")
        'GridView1.Columns("Prs").Summary.Add(item)

        For i As Integer = 0 To GridView1.DataRowCount - 1
            If Not GridView1.GetRowCellValue(i, "Par") = "  --  " Then
                ' Your code here
                If GridView1.GetRowCellValue(i, "P/A").ToString() = "P" Then
                    pares += 1
                ElseIf GridView1.GetRowCellValue(i, "P/A").ToString() = "E" Or GridView1.GetRowCellValue(i, "P/A").ToString() = "C" Then
                    erroneos += 1
                ElseIf GridView1.GetRowCellValue(i, "P/A").ToString() = "A" Then
                    atados += 1

                End If
            End If

            If GridView1.GetRowCellValue(i, "F. Solicita Cliente") = "01/01/1900" Then
                GridView1.SetRowCellValue(i, "F. Solicita Cliente", "")
            End If

        Next i
       

        'For Each row As GridRow In Me.GridView1.DataSource.table.rows

        '    If row.RowKey("P/A").Text.Equals("P") Then
        '        row.RowKey("P/A").Appearance.BackColor = Color.Khaki
        '    Else
        '        If row.RowKey("P/A").Text.Equals("A") Then
        '            row.RowKey("P/A").Appearance.BackColor = Color.Aquamarine
        '        Else
        '            row.RowKey("P/A").Appearance.BackColor = Color.Orange
        '            If row.RowKey("PROCESO").Text.Equals("EXTERNO (Coppel)") Then
        '                row.RowKey("P/A").Appearance.BackColor = Color.Purple
        '                row.RowKey("P/A").Value = "C"
        '            Else
        '                row.RowKey("P/A").Appearance.BackColor = Color.Orange
        '            End If
        '        End If
        '    End If

        '    If row.RowKey("D").Text.Equals("1") Then
        '        row.RowKey("D").Appearance.BackColor = Color.SeaGreen
        '    End If

        '    If row.RowKey("A").Text.Equals("1") Then
        '        row.RowKey("A").Appearance.BackColor = Color.RoyalBlue
        '    End If

        '    If row.RowKey("C").Text.Equals("1") Then
        '        row.RowKey("C").Appearance.BackColor = Color.SaddleBrown
        '    End If

        '    If row.RowKey("B").Text.Equals("1") Then
        '        row.RowKey("B").Appearance.BackColor = Color.Red
        '    End If

        '    If row.RowKey("R").Text.Equals("1") Then
        '        row.RowKey("R").Appearance.BackColor = Color.Indigo
        '    End If

        '    If row.RowKey("P").Text.Equals("1") Then
        '        row.RowKey("P").Appearance.BackColor = Color.DeepPink
        '    ElseIf row.RowKey("P").Text.Equals("2") Then
        '        row.RowKey("P").Appearance.BackColor = Color.HotPink
        '    End If
        '    If row.RowKey("V").Text.Equals("1") Then
        '        row.RowKey("V").Appearance.BackColor = Color.OrangeRed
        '    End If

        'Next


        'GridView1.OptionsView.ShowAutoFilterRow = True
        totalPares = GridView1.Columns("Prs").SummaryText
        lblRecuperados.Text = GridView1.RowCount.ToString("N0", CultureInfo.InvariantCulture)
        lblAtados.Text = atados.ToString("N0", CultureInfo.InvariantCulture)
        lblPares.Text = pares.ToString("N0", CultureInfo.InvariantCulture)
        lblErroneos.Text = erroneos.ToString("N0", CultureInfo.InvariantCulture)
        lblTotalPares.Text = totalPares.ToString("N0", CultureInfo.InvariantCulture)
        GridView1.IndicatorWidth = 40
    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, _
ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("#"))
            If e.RowHandle Mod 2 > 0 Then
                e.Appearance.BackColor = Color.LightSteelBlue
                'e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

    'Private Sub gridListaUbicacionDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

    '    'asignaFormato_Columna(grid)

    '    grid.DisplayLayout.Bands(0).Columns("Estiba ID").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Bahía ID").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Bahía").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Bloque").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Nivel").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Posicion").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Color").Hidden = True
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").Style = ColumnStyle.DateTime
    '    'grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").AllowRowFiltering = DefaultableBoolean.False
    '    'grid.DisplayLayout.Bands(0).Columns("Fecha").GroupByMode = GroupByMode.Date
    '    'grid.DisplayLayout.Bands(0).ColumnFilters("Fecha").FilterConditions.Clear()
    '    'grid.DisplayLayout.Bands(0).ColumnFilters("Fecha").FilterConditions.Add(FilterComparisionOperator.Custom, grid.DisplayLayout.Rows.FilterRow.Cells("Fecha"))
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").AllowRowFiltering = DefaultableBoolean.False
    '    grid.DisplayLayout.Bands(0).Columns("Par").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Atado").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Prs").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("NumAt").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Talla").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Tienda").CellAppearance.TextHAlign = HAlign.Left
    '    grid.DisplayLayout.Bands(0).Columns("Apartado").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
    '    grid.DisplayLayout.Bands(0).Columns("Salida de Nave (hr)").Style = ColumnStyle.DateTime
    '    grid.DisplayLayout.Bands(0).Columns("Salida de Nave (hr)").AllowRowFiltering = DefaultableBoolean.False
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación").Style = ColumnStyle.Date
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación").GroupByMode = GroupByMode.Date
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación").AllowRowFiltering = DefaultableBoolean.False
    '    grid.DisplayLayout.Bands(0).Columns("Salida de Nave").Style = ColumnStyle.Date
    '    grid.DisplayLayout.Bands(0).Columns("Salida de Nave").GroupByMode = GroupByMode.Date
    '    grid.DisplayLayout.Bands(0).Columns("Salida de Nave").AllowRowFiltering = DefaultableBoolean.False

    '    grid.DisplayLayout.Bands(0).Columns("Entrada Almacén (hr)").Style = ColumnStyle.DateTime
    '    grid.DisplayLayout.Bands(0).Columns("Entrada Almacén (hr)").AllowRowFiltering = DefaultableBoolean.False

    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación Ant. (Hr)").Style = ColumnStyle.DateTime
    '    grid.DisplayLayout.Bands(0).Columns("Fecha Ubicación Ant. (Hr)").AllowRowFiltering = DefaultableBoolean.False

    '    grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
    '    'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
    '    grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '    grid.DisplayLayout.Override.RowSelectorWidth = 35
    '    'grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
    '    grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
    '    grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
    '    grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
    '    'grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
    '    grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    '    grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
    '    grid.DisplayLayout.GroupByBox.Hidden = False
    '    grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

    '    For Each row As UltraGridRow In grid.Rows

    '        If row.Cells("P/A").Text.Equals("P") Then
    '            row.Cells("P/A").Appearance.BackColor = Color.Khaki
    '        Else
    '            If row.Cells("P/A").Text.Equals("A") Then
    '                row.Cells("P/A").Appearance.BackColor = Color.Aquamarine
    '            Else
    '                row.Cells("P/A").Appearance.BackColor = Color.Orange
    '                If row.Cells("PROCESO").Text.Equals("EXTERNO (Coppel)") Then
    '                    row.Cells("P/A").Appearance.BackColor = Color.Purple
    '                    row.Cells("P/A").Value = "C"
    '                Else
    '                    row.Cells("P/A").Appearance.BackColor = Color.Orange
    '                End If
    '            End If
    '        End If

    '        If row.Cells("D").Text.Equals("1") Then
    '            row.Cells("D").Appearance.BackColor = Color.SeaGreen
    '        End If

    '        If row.Cells("A").Text.Equals("1") Then
    '            row.Cells("A").Appearance.BackColor = Color.RoyalBlue
    '        End If

    '        If row.Cells("C").Text.Equals("1") Then
    '            row.Cells("C").Appearance.BackColor = Color.SaddleBrown
    '        End If

    '        If row.Cells("B").Text.Equals("1") Then
    '            row.Cells("B").Appearance.BackColor = Color.Red
    '        End If

    '        If row.Cells("R").Text.Equals("1") Then
    '            row.Cells("R").Appearance.BackColor = Color.Indigo
    '        End If

    '        If row.Cells("P").Text.Equals("1") Then
    '            row.Cells("P").Appearance.BackColor = Color.DeepPink
    '        ElseIf row.Cells("P").Text.Equals("2") Then
    '            row.Cells("P").Appearance.BackColor = Color.HotPink
    '        End If
    '        If row.Cells("V").Text.Equals("1") Then
    '            row.Cells("V").Appearance.BackColor = Color.OrangeRed
    '        End If

    '    Next

    '    Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Prs")
    '    Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
    '    summary.DisplayFormat = "{0}"
    '    summary.Appearance.TextHAlign = HAlign.Right

    '    'Dim colDispSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("D")
    '    'Dim sumDisponible As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("DISPONIBLE", SummaryType.Sum, colDispSum)
    '    'sumDisponible.DisplayFormat = "{0}"
    '    'sumDisponible.Appearance.TextHAlign = HAlign.Right

    '    'Dim colAsignadoSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("A")
    '    'Dim sumAsignado As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("ASIGNADO", SummaryType.Sum, colAsignadoSum)
    '    'sumAsignado.DisplayFormat = "{0}"
    '    'sumAsignado.Appearance.TextHAlign = HAlign.Right

    '    'Dim colCalidadSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("C")
    '    'Dim sumCalidad As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("CALIDAD", SummaryType.Sum, colCalidadSum)
    '    'sumCalidad.DisplayFormat = "{0}"
    '    'sumCalidad.Appearance.TextHAlign = HAlign.Right

    '    'Dim colBloqueadoSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("B")
    '    'Dim sumBloqueado As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("BLOQUEADO", SummaryType.Sum, colBloqueadoSum)
    '    'sumBloqueado.DisplayFormat = "{0}"
    '    'sumBloqueado.Appearance.TextHAlign = HAlign.Right

    '    'Dim colReprocesoSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("R")
    '    'Dim sumReproceso As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("REPROCESO", SummaryType.Sum, colReprocesoSum)
    '    'sumReproceso.DisplayFormat = "{0}"
    '    'sumReproceso.Appearance.TextHAlign = HAlign.Right

    '    'Dim colProyectadoSum As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("P")

    '    'Dim sumProyectado As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("PROYECTADO", SummaryType.Count, colProyectadoSum)
    '    'sumProyectado.DisplayFormat = "{0}"
    '    'sumProyectado.Appearance.TextHAlign = HAlign.Right

    '    grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


    '    Dim width As Integer
    '    For Each col As UltraGridColumn In grid.Rows.Band.Columns
    '        If Not col.Hidden Then
    '            width += col.Width
    '        End If
    '    Next

    '    If width > grid.Width Then
    '        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
    '    Else
    '        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    End If
    '    grid.DisplayLayout.Bands(0).Columns("D").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("A").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("C").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("B").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("P").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("R").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("V").Width = 18
    '    grid.DisplayLayout.Bands(0).Columns("P/A").Width = 20
    '    grid.DisplayLayout.Bands(0).Columns("Prs").Width = 25
    '    grid.DisplayLayout.Bands(0).Columns("Talla").Width = 32
    '    grid.DisplayLayout.Bands(0).Columns("Tipo").Width = 30
    '    grid.DisplayLayout.Bands(0).Columns("Año").Width = 34
    '    grid.DisplayLayout.Bands(0).Columns("Lote").Width = 35

    'End Sub

    'Private Sub asignar_grid_gridListaUbicacion(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

    '    gridListaUbicacion = grid

    'End Sub

    Private Sub btnUbicarMapa_Click(sender As Object, e As EventArgs) Handles btnUbicarMapa.Click
        gridListaUbicacion.DataSource = GridControl1.DataSource
        Me.Cursor = Cursors.WaitCursor

        Dim listaBahias As New List(Of String)
        Dim listaBahiasLimpio As New List(Of String)
        Dim listaBahiasBuscar As New List(Of Entidades.Bahia)

        Dim mapa As New VerTodoslosNiveles

        For Each row In gridListaUbicacion.Rows.GetFilteredInNonGroupByRows

            If Not row.Cells("Bahía ID").Text.Equals("SIN BAHÍA") Then
                If Not listaBahias.Contains(row.Cells("Bahía ID").Text) Then
                    listaBahias.Add(row.Cells("Bahía ID").Text)
                    Dim bahia As New Entidades.Bahia
                    bahia.bahiaid = row.Cells("Bahía ID").Text
                    bahia.bahi_bloque = row.Cells("Bloque").Text
                    bahia.bahi_nivel = row.Cells("Nivel").Text
                    bahia.bahi_posicion = row.Cells("Posicion").Text
                    bahia.bahi_color = row.Cells("Color").Text

                    listaBahiasBuscar.Add(bahia)
                End If
            End If

        Next

        'listaBahiasBuscar = listaBahiasBuscar.Distinct().ToList

        'For Each item In listaBahiasLimpio
        '    Dim bahia As New Entidades.Bahia
        '    bahia.bahiaid = item
        '    listaBahiasBuscar.Add(bahia)
        'Next

        mapa.BahiasBuscar = listaBahiasBuscar
        mapa.NavesAlmacen = nave_almacen
        mapa.externo = True
        mapa.ubicacion_producto = True

        mapa.ShowDialog()
        Me.Cursor = Cursors.Default

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
                'gridExcelExporter.Export(Me.gridListaUbicacion, .SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                'GridView1.SelectAll()
                ' xls.CopySelectionToClipboard(.SelectedPath + "\Datos_ListaUbicaciones_exceldev" + fecha_hora + ".xlsx", GridView1)
                ' GridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, .SelectedPath + "\Datos_ListaUbicaciones_dev" + fecha_hora + ".xlsx")
                If GridView1.GroupCount > 0 Then
                    GridControl1.ExportToXlsx(.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                Else
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                    GridControl1.ExportToXlsx(.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx", exportOptions)
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                End If
            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With

    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If e.ColumnFieldName = "P/A" Then
            If e.Value.ToString() = "" Then
                e.Formatting.BackColor = Color.Orange

            ElseIf e.Value.ToString() = "P" Then
                e.Formatting.BackColor = Color.Khaki
            ElseIf e.Value.ToString() = "A" Then
                e.Formatting.BackColor = Color.Aquamarine
            End If
            ' e.Column.Width = 10
        ElseIf e.ColumnFieldName = "D" Then
            If e.Value.ToString() = " " Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.SeaGreen

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "A" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.RoyalBlue

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "C" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.SaddleBrown

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "B" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.Red

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "R" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.Indigo

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "P" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.DeepPink
            ElseIf e.Value.ToString() = "2" Then
                e.Formatting.BackColor = Color.HotPink

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "V" Then
            If e.Value.ToString() = "" Then

            ElseIf e.Value.ToString() = "1" Then
                e.Formatting.BackColor = Color.OrangeRed

            End If
            'e.Column.Width = 10
        End If
        'MessageBox.Show(Convert.ToString(e.Column.ColumnType.Name))
        'If Convert.ToString(e.Column.ColumnType.Name) = "DateTime" Then
        '    e.Column.DisplayFormat.FormatString = "M/d/yyyy HH:mm:ss"
        'End If
        e.Handled = True
    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click


        Try
            '' Create an XtraPageSettings instance.
            'Dim pageSettings As XtraPageSettings = PrinterSettings.

            '' Specify the paper kind and page orientation.
            'pageSettings.PaperKind = PaperKind.Letter
            'pageSettings.Landscape = True
            GridView1.ShowPrintPreview()
            
            GridView1.Print()
            'gridListaUbicacion.Print()
        Catch exc As Exception

            MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'GridView1.Columns.Clear()
        poblar_gridListaUbicaciondev(GridControl1)
        'Dim d As New Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog(gridListaUbicacion)
        ''d = Infragistics.Win.UltraWinGrid.CustomRowFiltersDialog
        'd.ShowDialog(gridListaUbicacion.DisplayLayout.Bands(0).ColumnFilters("Fecha"), gridListaUbicacion.Rows)

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub gridListaUbicacion_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles gridListaUbicacion.AfterRowFilterChanged

        Dim pares, erroneos, atados, totalPares As Integer

        'Dim col As ColumnFilter = sender

        If gridListaUbicacion.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            pnlAccionesCabecera.Enabled = True
            For Each row In gridListaUbicacion.Rows.GetFilteredInNonGroupByRows
                If Not row.Cells("Par").Text.Equals("   --  ") Then
                    If row.Cells("P/A").Text.Equals("P") Then
                        pares += 1
                    Else
                        If row.Cells("P/A").Text.Equals("E") Or row.Cells("P/A").Text.Equals("C") Then
                            erroneos += 1
                        End If
                    End If
                End If

                If row.Cells("Par").Text.Equals("   --  ") Then
                    atados += 1
                End If

                totalPares += CInt(row.Cells("Prs").Value)

            Next

        Else

            pnlAccionesCabecera.Enabled = False

        End If

        lblRecuperados.Text = gridListaUbicacion.Rows.GetFilteredInNonGroupByRows.Count.ToString("N0", CultureInfo.InvariantCulture)
        lblAtados.Text = atados.ToString("N0", CultureInfo.InvariantCulture)
        lblPares.Text = pares.ToString("N0", CultureInfo.InvariantCulture)
        lblErroneos.Text = erroneos.ToString("N0", CultureInfo.InvariantCulture)
        lblTotalPares.Text = totalPares.ToString("N0", CultureInfo.InvariantCulture)


    End Sub

    Private Sub gridListaUbicacion_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles gridListaUbicacion.BeforePrint

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub



    Private Sub gridListaUbicacion_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs) Handles gridListaUbicacion.InitializePrintPreview

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

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
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

    Private Sub btnCiclico_Click(sender As Object, e As EventArgs) Handles btnCiclico.Click
        Dim mensajeAdvertencia As New AdvertenciaForm
        mensajeAdvertencia.mensaje = "Este proceso puede tardar dependiendo de los pares a dar de alta."
        mensajeAdvertencia.ShowDialog()
        Me.StartPosition = FormStartPosition.CenterScreen
        Dim AltaInventarioCiclico = New AltaInventarioCiclicoForm
        With AltaInventarioCiclico
            .nave_almacen = Filtros.Almacen
            .lPedidos = Filtros.PedidosCliente
            .lPares = Filtros.CodigosPar
            .lAtados = Filtros.CodigosAtado
            .lProductos = Filtros.Productos
            .lClientes = Filtros.Clientes
            .lPedidos = Filtros.PedidosCliente
            .lCorrida = Filtros.Corridas
            .lLote = Filtros.Lotes
            .AnioLote = Filtros.AnioLotes
            .lBahia = Filtros.Bahias
            .lNave = Filtros.Naves
            .lPedidoOrigen = Filtros.PedidosOrigen
            .lColaborador = Filtros.Operador
            .lAgente = Filtros.AgenteVtas
            .IdTienda = Filtros.Tiendas
            .lDescripcionBahia = Filtros.DescripcionBahia
            .fechaInicio = Filtros.FechaInicio
            .fechaTermino = Filtros.FechaFin
            .FechaSi_No = Filtros.FiltroFecha
            .mostrar_todo = mostrar_todo
            .WindowState = FormWindowState.Maximized
            'Dim dtGrid As DataTable = DirectCast(gridListaUbicacion.DataSource, DataTable)
            Dim dtGrid As DataTable = DirectCast(GridControl1.DataSource, DataTable)
            .dtGrid = dtGrid
        End With

        AltaInventarioCiclico.ShowDialog()
        Me.Close()
    End Sub

    Private Sub lblAltas_Click(sender As Object, e As EventArgs) Handles lblAltas.Click

    End Sub

    Private Sub GridView1_PrintInitialize(sender As System.Object, _
            e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) _
            Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        ' Specify margins.
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        pb.PageSettings.TopMargin = 0
        pb.PageSettings.BottomMargin = 0

    End Sub


End Class