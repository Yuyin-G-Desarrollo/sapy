Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization

Public Class BusquedaParAtadoForm

    Dim listPares As New List(Of String)
    Dim listAtados As New List(Of String)
    Dim listPedidos As New List(Of String)
    Dim listaPedidoOrigen As New List(Of String)
    Dim listaOrdenCliente As New List(Of String)
    Dim listaLoteCliente As New List(Of String)
    Dim listInicial As New List(Of String)
    Dim listLotes As DataTable
    Dim listApartados As New List(Of String)
    Dim listDevoluciones As New List(Of String)
    Public inventariociclico As Boolean = False

    Dim PrimeraCarga As Boolean = True

    Public Filtros As New Entidades.LocalizacionProducto
    Public mostrar_todo As Boolean

    Private Sub BusquedaParAtadoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0

        dateInicio.Value = Now.Date
        dateInicio.MaxDate = Now.Date
        dateFin.Value = Now.Date
        dateFin.MaxDate = Now.Date
        timeInicio.Value = Now.Date

        listLotes = New DataTable
        listLotes.Columns.Add("Lote")
        listLotes.Columns.Add("AnioLote")
        listLotes.Columns("AnioLote").Caption = "Año"

        listado_naves()
        gridPares.DataSource = listPares
        gridAtados.DataSource = listAtados
        gridPedidos.DataSource = listPedidos
        grdPedidoOrigen.DataSource = listaPedidoOrigen
        grdOrdenCliente.DataSource = listaOrdenCliente
        gridLotes.DataSource = listLotes
        gridApartados.DataSource = listApartados
        gridProductos.DataSource = listInicial
        gridClientes.DataSource = listInicial
        gridAgentes.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridBahias.DataSource = listInicial
        gridNaves.DataSource = listInicial
        gridColaboradores.DataSource = listInicial
        gridDescripciones.DataSource = listInicial
        gridTiendas.DataSource = listInicial
        gridTallas.DataSource = listInicial
        grdLoteCliente.DataSource = listaLoteCliente
        grdPedidoOrigen.DataSource = listaPedidoOrigen
        grdDevolucion.DataSource = listDevoluciones
        llenarComboEstatus()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "ALM_UBICACIONES_BTN_CARGA") Then
            btnUbicacionPorArchivo.Visible = True
            lblBtnCarga.Visible = True
        Else
            btnUbicacionPorArchivo.Visible = False
            lblBtnCarga.Visible = False
        End If
        PrimeraCarga = False
        aplicarPermisos()
    End Sub

    Public Sub aplicarPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "ALM_UBICACIONES_BTN_GENERAR_UBICACION") Then
            pnlGenerarUbicacion.Visible = True
        Else
            pnlGenerarUbicacion.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "ALM_UBICACIONES_BTN_PARES_ATADO") Then
            pnlParesAtado.Visible = True
        Else
            pnlParesAtado.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "ALM_UBICACIONES_BTN_PARES_ATADO") Then
            pnllimpiarPlataforma.Visible = True
        Else
            pnllimpiarPlataforma.Visible = False
        End If
    End Sub

    Public Sub llenarComboEstatus()
        Dim dtDatosComboEsts As New DataTable
        dtDatosComboEsts.Columns.Add("idEstatus")
        dtDatosComboEsts.Columns.Add("Estatus")

        Dim drFilaComboEsts As DataRow
        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "0"
        drFilaComboEsts("Estatus") = ""
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "1"
        drFilaComboEsts("Estatus") = "DISPONIBLE"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "2"
        drFilaComboEsts("Estatus") = "ASIGNADO"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "3"
        drFilaComboEsts("Estatus") = "CALIDAD"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "4"
        drFilaComboEsts("Estatus") = "BLOQUEADO"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "5"
        drFilaComboEsts("Estatus") = "RESERVADO"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        drFilaComboEsts = dtDatosComboEsts.NewRow()
        drFilaComboEsts("idEstatus") = "6"
        drFilaComboEsts("Estatus") = "REPROCESO"
        dtDatosComboEsts.Rows.Add(drFilaComboEsts)

        cmbEstatus.DataSource = dtDatosComboEsts
        cmbEstatus.ValueMember = "idEstatus"
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.SelectedIndex = 0

    End Sub

    Private Sub listado_naves()

        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtInformacionCentroDistribucion As DataTable
        Dim dtNumeroAlmacenes As DataTable

        Try

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "VER_ALM_ASIGNADO") Then
                dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Else
                dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivos()
            End If

            cboxNave.DataSource = dtInformacionCentroDistribucion
            cboxNave.DisplayMember = "Nave"
            cboxNave.ValueMember = "NaveSAYID"

            cboxNave.SelectedIndex = 0

            If cboxNave.SelectedIndex = 0 Then
                dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
                cboxAlmacen.DataSource = dtNumeroAlmacenes
                cboxAlmacen.ValueMember = "NumeroAlmacen"
                cboxAlmacen.DisplayMember = "NumeroAlmacen"
                cboxAlmacen.SelectedIndex = 0
            End If



            'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        Catch ex As Exception

        End Try
        'If cboxNave.SelectedIndex = 1 Then
        '    listado_almacen()
        'End If


        'Dim dtDatosComboNave As New DataTable
        'dtDatosComboNave.Columns.Add("nave_navesicyid")
        'dtDatosComboNave.Columns.Add("nave_nombre")

        'Dim drFilaComboNave As DataRow
        'drFilaComboNave = dtDatosComboNave.NewRow()
        'drFilaComboNave("nave_navesicyid") = "43"
        'drFilaComboNave("nave_nombre") = "COMERCIALIZADORA"
        'dtDatosComboNave.Rows.Add(drFilaComboNave)

        'cboxNave.DataSource = dtDatosComboNave
        'cboxNave.ValueMember = "nave_navesicyid"
        'cboxNave.DisplayMember = "nave_nombre"
        'cboxNave.SelectedIndex = 0


        'If cboxNave.SelectedIndex = 0 Then
        '    Dim dtDatosComboAlmacen As New DataTable
        '    dtDatosComboAlmacen.Columns.Add("bahi_almacen")

        '    Dim drFilaComboAlmacen As DataRow
        '    drFilaComboAlmacen = dtDatosComboAlmacen.NewRow()
        '    drFilaComboAlmacen("bahi_almacen") = "1"
        '    dtDatosComboAlmacen.Rows.Add(drFilaComboAlmacen)

        '    cboxAlmacen.DataSource = dtDatosComboAlmacen
        '    cboxAlmacen.ValueMember = "bahi_almacen"
        '    cboxAlmacen.DisplayMember = "bahi_almacen"
        '    cboxAlmacen.SelectedIndex = 0
        'End If


    End Sub

    Private Sub listado_almacen()

        Try
            Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboxNave_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxNave.SelectionChangeCommitted
        'listado_almacen()
    End Sub

    Private Sub BusquedaParAtadoForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim caracter As Char = e.KeyChar
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub chboxFiltarFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFiltarFecha.CheckedChanged
        If chboxFiltarFecha.Checked Then
            dateInicio.Enabled = True
            timeInicio.Enabled = True
            dateFin.Enabled = True
            timeFin.Enabled = True
        Else
            dateInicio.Enabled = False
            timeInicio.Enabled = False
            dateFin.Enabled = False
            timeFin.Enabled = False
        End If
    End Sub

    Public Function GenerarFiltro_SinComillas(grid As UltraGrid)
        Dim filtro As String = ""
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                filtro += row.Cells(0).Text
            Else
                filtro += "," + row.Cells(0).Text
            End If
        Next
        Return filtro
    End Function

    Public Function GenerarFiltro(grid As UltraGrid)
        Dim filtro As String = ""
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                filtro += "'" + row.Cells(0).Text + "'"
            Else
                filtro += ", '" + row.Cells(0).Text + "'"
            End If
        Next
        Return filtro
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Cursor = Cursors.WaitCursor
        'Dim objBU As New Negocios.AlmacenBU
        'Try
        '    objBU.Actualizar_FechaSalidaNave()
        '    objBU.Actualizar_GeneraUbicaciones()
        '    objBU.Actualizar_ConvertirParesEnAtado()
        'Catch ex As Exception

        'End Try

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            Me.Cursor = Cursors.Default
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        If rbtnY.Checked = True Then
            Filtros.Condicion = "Y"
        Else
            Filtros.Condicion = "O"
        End If
        'IIf(rbtnY.Checked = True, Filtros.Condicion = "Y", "O")

        Dim buscarContenidoAtado As Boolean = rbtnBuscarContenidoAtado.Checked
        Dim Con_Sin_Ubicacion As Integer ''1 = CON UBICACION SOLAMENTE, 2 = SIN UBICACION SOLAMENTE, 3 = TODO EL PRODUCTO CON O SIN UBICACION

        Filtros.FiltroFecha = chboxFiltarFecha.Checked
        Filtros.FiltroFechaEntPedidos = chboxFechaEntrega.Checked

        If rbtnConUbicacion.Checked Then
            Filtros.Ubicacion = "CON UBICACIÓN"
            Con_Sin_Ubicacion = 1
        ElseIf rbtnSinUbicacion.Checked Then
            Filtros.Ubicacion = "SIN UBICACIÓN"
            Con_Sin_Ubicacion = 2
        ElseIf rbtnTodoUbicacion.Checked Then
            Filtros.Ubicacion = "TODOS"
            Con_Sin_Ubicacion = 3
        End If

        If rbtnBuscarAtado.Checked Then
            buscarContenidoAtado = False
        Else
            If rbtnBuscarContenidoAtado.Checked Then
                buscarContenidoAtado = True
            Else
                show_message("Aviso", "Debe seleccionar una opción de filtro de busqueda de Atado/Contenido Atado")
                Me.Cursor = Cursors.Default
                Return
            End If
        End If

        Filtros.NaveID = CStr(cboxNave.SelectedValue)
        Filtros.Almacen = cboxAlmacen.Text

        If chboxMostrarTodo.Checked Then
            mostrar_todo = True
        End If

        ''VERIFICA LOS VALORES DE BUSQUEDA

        Dim form As New ListadoUbicacionParAtado

        ''PARES
        Filtros.CodigosPar = GenerarFiltro(gridPares)

        ''ATADOS
        Filtros.CodigosAtado = GenerarFiltro(gridAtados)

        ''PEDIDOS
        Filtros.PedidosCliente = GenerarFiltro_SinComillas(gridPedidos)

        ''APARTADO
        Filtros.Apartados = GenerarFiltro_SinComillas(gridApartados)

        ''Devoluciones SAY
        Filtros.DevolucionesSAY = GenerarFiltro_SinComillas(grdDevolucion)

        ''LOTES
        Dim lote_f As String = ""
        Dim anioLote_f As String = ""

        For Each row As UltraGridRow In gridLotes.Rows
            If row.Index = 0 Then
                lote_f += row.Cells(0).Text
                If row.Cells(1).Text.ToString.Trim <> "" Then
                    anioLote_f += row.Cells(1).Text
                End If
            Else
                lote_f += ", " + row.Cells(0).Text
                If row.Cells(1).Text.ToString.Trim <> "" Then
                    anioLote_f += ", " + row.Cells(1).Text
                End If
            End If
        Next

        Filtros.Lotes = lote_f
        Filtros.AnioLotes = anioLote_f

        ''PRODUCTOS
        Filtros.Productos = GenerarFiltro(gridProductos)

        ''CLIENTES
        Filtros.Clientes = GenerarFiltro_SinComillas(gridClientes)

        ''AGENTE DE VENTAS
        Filtros.AgenteVtas = GenerarFiltro_SinComillas(gridAgentes)

        ''CORRIDA
        Filtros.Corridas = GenerarFiltro(gridCorridas)

        ''BAHIA
        Filtros.Bahias = GenerarFiltro(gridBahias)

        ''NAVE
        Filtros.Naves = GenerarFiltro_SinComillas(gridNaves)

        ''PEDIDO ORIGEN
        Filtros.PedidosOrigen = GenerarFiltro_SinComillas(grdPedidoOrigen)

        ''ORDEN CLIENTE
        Filtros.OrdenesCliente = GenerarFiltro(grdOrdenCliente)

        ''COLABORADORES
        Filtros.Operador = GenerarFiltro_SinComillas(gridColaboradores)

        ''DESCRIPCION BAHIA
        Filtros.DescripcionBahia = GenerarFiltro(gridDescripciones)

        ''TIENDA
        Filtros.Tiendas = GenerarFiltro(gridTiendas)

        ''TALLA
        Filtros.Tallas = GenerarFiltro(gridTallas)

        ''LOTE CLIENTE
        Filtros.LotesCliente = GenerarFiltro(grdLoteCliente)

        ''ESTATUS
        Filtros.Estatus = cmbEstatus.SelectedValue

        Filtros.FechaInicio = dateInicio.Value.ToShortDateString.ToString + " " + timeInicio.Value.ToLongTimeString
        Filtros.FechaFin = dateFin.Value.ToShortDateString.ToString + " " + timeFin.Value.ToLongTimeString

        Filtros.FechaInicio = DateTime.Parse(Filtros.FechaInicio).ToString("yyyy/dd/MM HH:mm:ss")
        Filtros.FechaFin = DateTime.Parse(Filtros.FechaFin).ToString("yyyy/dd/MM HH:mm:ss")

        Filtros.FechaInicioPedidos = dtpInicioFechaE.Value.ToShortDateString.ToString + " " + "00:00:00"
        Filtros.FechaFinPedidos = dtpFinFechaE.Value.ToShortDateString.ToString + " " + "23:59:00"

        Filtros.FechaInicioPedidos = DateTime.Parse(Filtros.FechaInicioPedidos).ToString("yyyy/dd/MM HH:mm:ss")
        Filtros.FechaFinPedidos = DateTime.Parse(Filtros.FechaFinPedidos).ToString("yyyy/dd/MM HH:mm:ss")

        If String.IsNullOrEmpty(Filtros.CodigosPar) _
            And String.IsNullOrEmpty(Filtros.CodigosAtado) _
            And String.IsNullOrEmpty(Filtros.Productos) _
            And String.IsNullOrEmpty(Filtros.Clientes) _
            And String.IsNullOrEmpty(Filtros.PedidosCliente) _
            And String.IsNullOrEmpty(Filtros.Corridas) _
            And String.IsNullOrEmpty(Filtros.Lotes) _
            And String.IsNullOrEmpty(Filtros.Bahias) _
            And String.IsNullOrEmpty(Filtros.Naves) _
            And String.IsNullOrEmpty(Filtros.Operador) _
            And String.IsNullOrEmpty(Filtros.AgenteVtas) _
            And String.IsNullOrEmpty(Filtros.DescripcionBahia) _
            And String.IsNullOrEmpty(Filtros.Tiendas) _
            And String.IsNullOrEmpty(Filtros.Tallas) _
            And String.IsNullOrEmpty(Filtros.Apartados) _
            And String.IsNullOrEmpty(Filtros.PedidosOrigen) _
            And String.IsNullOrEmpty(Filtros.OrdenesCliente) _
            And String.IsNullOrEmpty(Filtros.LotesCliente) _
            And Filtros.Estatus = "" Then
            'And Not mostrar_todo Then

            If chboxMostrarTodo.Checked Then
                mostrar_todo = True
            Else
                show_message("Aviso", "Debe ingresar algún parámetro de busqueda " + vbCr + "o seleccionar 'Mostrar todo'")
                Me.Cursor = Cursors.Default
                Return
            End If


            'Else
            '    If chboxMostrarTodo.Checked Then
            '        mostrar_todo = True
            '    Else
            '        show_message("Aviso", "Debe ingresar algún parámetro de busqueda " + vbCr + "o seleccionar 'Mostrar todo'")
            '        Return
            '    End If
        End If
        Me.Cursor = Cursors.Default

        ''agregado tipo de reporte 
        If rbtnDetallePares.Checked = True Then
            form.Filtros = Filtros
            Try
                'MsgBox("Va a mostrar pantalla")
                form.Show()
            Catch ex As Exception

            End Try
            If inventariociclico = True Then
                If form.ResultadoNulo = True Then Return
                Me.Close()
            End If
        Else
            Dim formAgrupamiento As New ListadoUbicacionAgrupamiento
            Dim tipo_Agrupamiento As Int16
            Try
                If rbtnPorPedido.Checked Then
                    tipo_Agrupamiento = 1
                Else
                    If rbtnPorFEPedido.Checked Then
                        tipo_Agrupamiento = 2
                    Else
                        tipo_Agrupamiento = 1
                    End If
                End If

                Filtros.DescripcionBahia = ""
                ''DESCRIPCION BAHIA
                For Each row As UltraGridRow In gridDescripciones.Rows
                    If row.Index = 0 Then
                        Filtros.DescripcionBahia += "'" + row.Cells(2).Text + "'"
                    Else
                        Filtros.DescripcionBahia += ", '" + row.Cells(2).Text + "'"
                    End If
                Next
                '                form.lDescripcionBahia = Filtros.DescripcionBahia
                Dim mostrar_todo As Boolean

                Dim bY_O As Boolean = rbtnY.Checked

                formAgrupamiento.nave_almacen = CStr(Filtros.NaveID.ToString + "," + Filtros.Almacen.ToString)
                formAgrupamiento.Con_Sin_Ubicacion = Con_Sin_Ubicacion
                formAgrupamiento.tipo_agrupamiento = tipo_Agrupamiento

                formAgrupamiento.lPar = Filtros.CodigosPar
                formAgrupamiento.lAtado = Filtros.CodigosAtado
                formAgrupamiento.lLote = Filtros.Lotes
                formAgrupamiento.AnioLote = Filtros.AnioLotes
                formAgrupamiento.lLoteCliente = Filtros.LotesCliente
                formAgrupamiento.lNave = Filtros.Naves
                formAgrupamiento.lPedidoOrigen = Filtros.PedidosOrigen
                formAgrupamiento.lPedido = Filtros.PedidosCliente
                formAgrupamiento.lCliente = Filtros.Clientes
                formAgrupamiento.lTienda = Filtros.Tiendas
                formAgrupamiento.lAgente = Filtros.AgenteVtas
                formAgrupamiento.lOrdenCliente = Filtros.OrdenesCliente
                formAgrupamiento.lApartado = Filtros.Apartados
                formAgrupamiento.lProducto = Filtros.Productos
                formAgrupamiento.lCorrida = Filtros.Corridas
                formAgrupamiento.lTalla = Filtros.Tallas
                formAgrupamiento.lBahia = Filtros.Bahias
                formAgrupamiento.lDescripcionBahia = Filtros.DescripcionBahia
                formAgrupamiento.lColaborador = Filtros.Operador

                formAgrupamiento.fechaInicio = Filtros.FechaInicio
                formAgrupamiento.fechaTermino = Filtros.FechaFin
                formAgrupamiento.fechaInicioEntregaP = Filtros.FechaInicioPedidos
                formAgrupamiento.fechaTerminoEntregaP = Filtros.FechaFinPedidos
                If Filtros.Estatus = 0 Then
                    formAgrupamiento.lFiltroEstatus = ""
                Else
                    formAgrupamiento.lFiltroEstatus = Filtros.Estatus
                End If


                formAgrupamiento.bY_O = bY_O
                formAgrupamiento.mostrar_todo = mostrar_todo
                formAgrupamiento.buscarContenidoAtado = buscarContenidoAtado
                formAgrupamiento.filtroFechas = Filtros.FiltroFecha
                formAgrupamiento.filtroFechaEntregaP = Filtros.FiltroFechaEntPedidos

                formAgrupamiento.Show()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarControles(pnlContenedor)
        listPares.Clear()
        listAtados.Clear()
        listPedidos.Clear()
        listaPedidoOrigen.Clear()
        listLotes.Clear()
        listApartados.Clear()
        dateInicio.Value = Now.Date
        dateInicio.MaxDate = Now.Date
        dateFin.Value = Now.Date
        dateFin.MaxDate = Now.Date
        timeInicio.Value = Now.Date
        chboxMostrarTodo.Checked = True
        rbtnY.Checked = True
        rbtnBuscarAtado.Checked = True
        rbtnTodoUbicacion.Checked = True
        rbtnDetallePares.Checked = True
        habilitarTipoBusqueda()
    End Sub

    Private Sub btnUbicacionPorArchivo_Click(sender As Object, e As EventArgs) Handles btnUbicacionPorArchivo.Click
       
        Dim form As New UbicacionProductoArchivoForm
        form.Show(Me)
    End Sub

#Region "Agregar elementos de busqueda"

    Private Sub txtPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPares.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtPares.Text) Then Return

            If IsNumeric(txtPares.Text) Then

                If txtPares.Text.Length >= 10 And txtPares.Text.Length <= 13 Then ''verifica "-" para posible par

                    listPares.Add(txtPares.Text)
                    gridPares.DataSource = Nothing
                    gridPares.DataSource = listPares

                    txtPares.Text = String.Empty

                Else
                    show_message("Aviso", "Código de par inválido")
                End If
            Else
                show_message("Aviso", "Código de par inválido")
            End If

        End If

    End Sub

    Private Sub txtAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtados.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtAtados.Text) Then Return

            If IsNumeric(txtAtados.Text) Then

                If txtAtados.Text.Length >= 10 And txtAtados.Text.Length <= 13 Then ''verifica "-" para posible par

                    listAtados.Add(txtAtados.Text)
                    gridAtados.DataSource = Nothing
                    gridAtados.DataSource = listAtados

                    txtAtados.Text = String.Empty

                Else
                    show_message("Aviso", "Código de atado inválido")
                End If
            Else
                show_message("Aviso", "Código de atado inválido")
            End If

        End If

    End Sub

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedido.Text) Then Return

            listPedidos.Add(txtPedido.Text)
            gridPedidos.DataSource = Nothing
            gridPedidos.DataSource = listPedidos

            txtPedido.Text = String.Empty

        End If

    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text) Then Return

            Dim newRowLote As DataRow
            newRowLote = listLotes.NewRow
            newRowLote.Item(0) = txtLote.Text.Trim
            newRowLote.Item(1) = txtAnioLote.Text.Trim
            listLotes.Rows.Add(newRowLote)
            gridLotes.DataSource = Nothing
            gridLotes.DataSource = listLotes

            txtLote.Text = String.Empty
            txtAnioLote.Text = String.Empty
        End If

    End Sub

    Private Sub txtApartado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApartado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtApartado.Text) Then Return

            listApartados.Add(txtApartado.Text)
            gridApartados.DataSource = Nothing
            gridApartados.DataSource = listApartados

            txtApartado.Text = String.Empty

        End If
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridProductos.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridProductos.DataSource = listado.listParametros
        With gridProductos
            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Productos"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
        End With


    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridClientes.DataSource = listado.listParametros
        With gridClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        End With

    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorridas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorridas.DataSource = listado.listParametros
        With gridCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Corridas"
        End With
    End Sub

    Private Sub btnBahia_Click(sender As Object, e As EventArgs) Handles btnBahia.Click

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 4
        listado.id_parametros = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridBahias.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridBahias.DataSource = listado.listParametros
        With gridBahias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            '.DisplayLayout.Bands(0).Columns(7).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Bahías"
        End With
    End Sub

    'Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click

    '    Dim listado As New ListadoParametroUbicacionForm
    '    listado.tipo_busqueda = 5
    '    Dim listaParametroID As New List(Of String)
    '    For Each row As UltraGridRow In gridNaves.Rows
    '        Dim parametro As String = row.Cells(0).Text
    '        listaParametroID.Add(parametro)
    '    Next
    '    listado.listaParametroID = listaParametroID
    '    listado.ShowDialog(Me)
    '    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
    '    If listado.listParametros.Rows.Count = 0 Then Return
    '    gridNaves.DataSource = listado.listParametros
    '    With gridNaves
    '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(1).Hidden = True

    '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
    '    End With
    'End Sub

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

    Private Sub btnAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnAgenteVentas.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridAgentes.DataSource = listado.listParametros
        With gridAgentes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
        End With

    End Sub

    Private Sub btnDescripcionBahia_Click(sender As Object, e As EventArgs) Handles btnDescripcionBahia.Click

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 8
        listado.id_parametros = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridDescripciones.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        gridDescripciones.DataSource = listado.listParametros
        With gridDescripciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Descripción de Bahías"
        End With

    End Sub

    Private Sub btnTiendas_Click(sender As Object, e As EventArgs) Handles btnTiendas.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 9
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTiendas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTiendas.DataSource = listado.listParametros
        With gridTiendas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tiendas"
        End With

    End Sub

    Private Sub btnTallas_Click(sender As Object, e As EventArgs) Handles btnTallas.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTallas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTallas.DataSource = listado.listParametros
        With gridTallas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Talla"
        End With

    End Sub

#End Region

#Region "Otras acciones"

    'Limpiar todos los controles
    Public Sub limpiarControles(ByVal control As Control)
        If TypeOf control Is TextBox Then
            CType(control, TextBox).Text = String.Empty
        End If
        If TypeOf control Is UltraGrid Then


            If IsNothing(CType(control, UltraGrid).DataSource) Then
                'CType(control, UltraGrid).
            Else
                CType(control, UltraGrid).DataSource = Nothing
            End If

        End If
        If TypeOf control Is MaskedTextBox Then
            CType(control, MaskedTextBox).Text = String.Empty
        End If
        'If TypeOf control Is ComboBox Then
        '    CType(control, ComboBox).SelectedIndex = -1
        'End If
        If TypeOf control Is NumericUpDown Then
            CType(control, NumericUpDown).Value = Decimal.Zero
        End If
        If TypeOf control Is CheckBox Then
            CType(control, CheckBox).Checked = False
        End If
        If TypeOf control Is RadioButton Then
            CType(control, RadioButton).Checked = False
        End If
        If TypeOf control Is DateTimePicker Then
            CType(control, DateTimePicker).Value = DateTimePicker.MinimumDateTime.ToString
        End If
        Dim i As Integer = control.Controls.Count
        For Each ctrl As Control In control.Controls
            limpiarControles(ctrl)
        Next ctrl
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


#End Region

#Region "InitializeLayout Ultragrid"
    Private Sub gridPares_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPares.InitializeLayout
        grid_simple_diseño(gridPares)
        gridPares.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de Par"
    End Sub

    Private Sub gridAtados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridAtados.InitializeLayout
        grid_simple_diseño(gridAtados)
        gridAtados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de Atado"
    End Sub

    Private Sub gridPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidos.InitializeLayout
        grid_simple_diseño(gridPedidos)
        gridPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub gridLotes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridLotes.InitializeLayout
        grid_simple_diseño(gridLotes)
        gridLotes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lote"
    End Sub

    Private Sub gridApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridApartados.InitializeLayout
        grid_simple_diseño(gridApartados)
        gridApartados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Apartado"
    End Sub

    Private Sub gridProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridProductos.InitializeLayout
        grid_diseño(gridProductos)
        gridProductos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Producto"
    End Sub

    Private Sub gridClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridClientes.InitializeLayout
        grid_diseño(gridClientes)
        gridClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub gridAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridAgentes.InitializeLayout
        grid_diseño(gridAgentes)
        gridAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub gridCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorridas.InitializeLayout
        grid_diseño(gridCorridas)
        gridCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub gridBahias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridBahias.InitializeLayout
        grid_diseño(gridBahias)
        gridBahias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Bahía"
    End Sub

    Private Sub gridNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridNaves.InitializeLayout
        grid_diseño(gridNaves)
        gridNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub

    Private Sub gridColaboradores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridColaboradores.InitializeLayout
        grid_diseño(gridColaboradores)
        gridColaboradores.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
    End Sub

    Private Sub gridDescripciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridDescripciones.InitializeLayout
        grid_diseño(gridDescripciones)
        gridDescripciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Descripción de Bahía"
    End Sub

    Private Sub gridTiendas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTiendas.InitializeLayout
        grid_diseño(gridTiendas)
        gridTiendas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda"
    End Sub

    Private Sub gridTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTallas.InitializeLayout
        grid_diseño(gridTallas)
        gridTallas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Talla"
    End Sub

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

    Private Sub grid_diseño(grid As UltraGrid)
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

        asignaFormato_Columna(grid)

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

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

#End Region

#Region "Acciones en grid"

    Private Sub gridPares_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPares.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPares.DeleteSelectedRows(False)

    End Sub

    Private Sub gridAtados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridAtados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridAtados.DeleteSelectedRows(False)

    End Sub

    Private Sub gridPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidos.DeleteSelectedRows(False)

    End Sub

    Private Sub gridLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridLotes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridLotes.DeleteSelectedRows(False)

    End Sub

    Private Sub gridApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridApartados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridApartados.DeleteSelectedRows(False)

    End Sub

    Private Sub gridProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridProductos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridProductos.DeleteSelectedRows(False)

    End Sub

    Private Sub gridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridClientes.DeleteSelectedRows(False)

    End Sub

    Private Sub gridAgentes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridAgentes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridAgentes.DeleteSelectedRows(False)

    End Sub

    Private Sub gridCorridas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorridas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorridas.DeleteSelectedRows(False)

    End Sub

    Private Sub gridBahias_KeyDown(sender As Object, e As KeyEventArgs) Handles gridBahias.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridBahias.DeleteSelectedRows(False)

    End Sub

    Private Sub gridNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles gridNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridNaves.DeleteSelectedRows(False)

    End Sub

    Private Sub gridColaboradores_KeyDown(sender As Object, e As KeyEventArgs) Handles gridColaboradores.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridColaboradores.DeleteSelectedRows(False)

    End Sub

    Private Sub gridDescripciones_KeyDown(sender As Object, e As KeyEventArgs) Handles gridDescripciones.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridDescripciones.DeleteSelectedRows(False)

    End Sub

    Private Sub gridTiendas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTiendas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTiendas.DeleteSelectedRows(False)

    End Sub

    Private Sub gridTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTallas.DeleteSelectedRows(False)

    End Sub

#End Region


    Private Sub gboxColaborador_Enter(sender As Object, e As EventArgs) Handles gboxColaborador.Enter

    End Sub
    Private Sub gboxDescripcionBahia_Enter(sender As Object, e As EventArgs) Handles gboxDescripcionBahia.Enter

    End Sub
    Private Sub gboxBahia_Enter(sender As Object, e As EventArgs) Handles gboxBahia.Enter

    End Sub
    Private Sub gboxTallas_Enter(sender As Object, e As EventArgs) Handles gboxTallas.Enter

    End Sub
    Private Sub gboxAgenteVentas_Enter(sender As Object, e As EventArgs) Handles gboxAgenteVentas.Enter

    End Sub
    Private Sub gboxPedRefCliente_Enter(sender As Object, e As EventArgs) Handles gboxPedRefCliente.Enter

    End Sub
    Private Sub gboxApartado_Enter(sender As Object, e As EventArgs) Handles gboxApartado.Enter

    End Sub
    Private Sub gboxEztatus_Enter(sender As Object, e As EventArgs) Handles gboxEztatus.Enter

    End Sub
    Private Sub gboxPedidos_Enter(sender As Object, e As EventArgs) Handles gboxPedidos.Enter

    End Sub
    Private Sub gboxPedidoOrigen_Enter(sender As Object, e As EventArgs) Handles gboxPedidoOrigen.Enter

    End Sub
    Private Sub gboxNave_Enter(sender As Object, e As EventArgs) Handles gboxNave.Enter

    End Sub
    Private Sub gboxLoteCliente_Enter(sender As Object, e As EventArgs) Handles gboxLoteCliente.Enter

    End Sub
    Private Sub gboxLote_Enter(sender As Object, e As EventArgs) Handles gboxLote.Enter

    End Sub
    Private Sub gboxAtados_Enter(sender As Object, e As EventArgs) Handles gboxAtados.Enter

    End Sub

    Private Sub txtAnioLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioLote.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text.Trim) Then
                If String.IsNullOrEmpty(txtAnioLote.Text.Trim) Then Return
                MsgBox("Debe Ingresar un Lote")
                txtAnioLote.Text = String.Empty
            Else
                Dim newRowLote As DataRow
                newRowLote = listLotes.NewRow
                newRowLote.Item(0) = txtLote.Text
                newRowLote.Item(1) = txtAnioLote.Text
                listLotes.Rows.Add(newRowLote)
                gridLotes.DataSource = Nothing
                gridLotes.DataSource = listLotes
                txtLote.Text = String.Empty
                txtAnioLote.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub txtPedidoOrigen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoOrigen.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoOrigen.Text) Then Return

            listaPedidoOrigen.Add(txtPedidoOrigen.Text)
            grdPedidoOrigen.DataSource = Nothing
            grdPedidoOrigen.DataSource = listaPedidoOrigen

            txtPedidoOrigen.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoOrigen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoOrigen.InitializeLayout
        grid_diseño(grdPedidoOrigen)
        grdPedidoOrigen.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido Origen"
    End Sub

    Private Sub grdPedidoOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoOrigen.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoOrigen.DeleteSelectedRows(False)
    End Sub

    Private Sub grdOrdenCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOrdenCliente.InitializeLayout
        grid_diseño(grdOrdenCliente)
        grdOrdenCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Orden Cliente"
    End Sub

    Private Sub grdOrdenCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOrdenCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdOrdenCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub txtOrdenCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenCliente.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtOrdenCliente.Text) Then Return
            listaOrdenCliente.Add(txtOrdenCliente.Text)
            grdOrdenCliente.DataSource = Nothing
            grdOrdenCliente.DataSource = listaOrdenCliente
            txtOrdenCliente.Text = String.Empty
        End If
    End Sub

    Private Sub txtLoteCLiente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteCLiente.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLoteCLiente.Text) Then Return
            listaLoteCliente.Add(txtLoteCLiente.Text)
            grdLoteCliente.DataSource = Nothing
            grdLoteCliente.DataSource = listaLoteCliente
            txtLoteCLiente.Text = String.Empty
        End If
    End Sub

    Private Sub grdLoteCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdLoteCliente.InitializeLayout
        grid_diseño(grdLoteCliente)
        grdLoteCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lote Cliente"
    End Sub

    Private Sub grdLoteCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLoteCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdLoteCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridNaves.DataSource = listado.listParametros
        With gridNaves
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        Try
            If cmbEstatus.SelectedValue <> "0" Then
                Dim valorSeleccion As String = cmbEstatus.SelectedValue.ToString
                rbtnBuscarContenidoAtado.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtnBuscarAtado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnBuscarAtado.CheckedChanged
        Try
            If rbtnBuscarAtado.Checked = True Then
                cmbEstatus.SelectedIndex = 0

            End If
        Catch ex As Exception

        End Try
    End Sub

    
 
    Private Sub chboxFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaEntrega.CheckedChanged
        If chboxFechaEntrega.Checked = True Then
            rbtnPorPedido.Enabled = True
            rbtnPorFEPedido.Enabled = True
            dtpInicioFechaE.Enabled = True
            dtpFinFechaE.Enabled = True
        Else
            rbtnDetallePares.Checked = True
            rbtnPorPedido.Enabled = False
            rbtnPorFEPedido.Enabled = False
            dtpInicioFechaE.Enabled = False
            dtpFinFechaE.Enabled = False
        End If
    End Sub

    Private Sub rbtnDetallePares_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDetallePares.CheckedChanged
        habilitarTipoBusqueda()
    End Sub

    Private Sub rbtnPorPedido_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorPedido.CheckedChanged
        habilitarTipoBusqueda()
    End Sub

    Private Sub rbtnPorFEPedido_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorFEPedido.CheckedChanged
        habilitarTipoBusqueda()
    End Sub

    Private Sub habilitarTipoBusqueda()
        If rbtnDetallePares.Checked Then
            rbtnBuscarAtado.Enabled = True
            rbtnBuscarContenidoAtado.Enabled = True
        Else
            rbtnBuscarAtado.Enabled = False
            rbtnBuscarContenidoAtado.Enabled = False
        End If
    End Sub

    Private Sub cboxNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNave.SelectedIndexChanged
        Dim objbu As New Almacen.Negocios.AlmacenBU        
        Dim dtNumeroAlmacenes As DataTable

        If PrimeraCarga = False Then
            cboxAlmacen.DataSource = Nothing

            dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
            cboxAlmacen.DataSource = dtNumeroAlmacenes
            cboxAlmacen.ValueMember = "NumeroAlmacen"
            cboxAlmacen.DisplayMember = "NumeroAlmacen"
            cboxAlmacen.SelectedIndex = 0
        End If
        
    End Sub

    Private Sub txtDevolucionSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDevolucionSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtDevolucionSAY.Text) Then Return

            listDevoluciones.Add(txtDevolucionSAY.Text)
            grdDevolucion.DataSource = Nothing
            grdDevolucion.DataSource = listDevoluciones

            txtDevolucionSAY.Text = String.Empty

        End If
    End Sub

    Private Sub grdDevolucion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDevolucion.InitializeLayout
        grid_diseño(grdDevolucion)
        grdDevolucion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Devolución SAY"
    End Sub

    Private Sub grdDevolucion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDevolucion.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnGenerarUbicacion_Click(sender As Object, e As EventArgs) Handles btnGenerarUbicacion.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim drResultado As Boolean = 0

        drResultado = objBU.GenerarUbicacion()
        If drResultado Then
            show_message("Exito", "Se genero correctamente ubicaciones")
        Else
            show_message("Error", "Ocurrio un error al generar ubicaciones")
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub brnParesAtado_Click(sender As Object, e As EventArgs) Handles brnParesAtado.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim drResultado As Boolean = 0

        drResultado = objBU.ConvertirParesAtado()

        If drResultado Then
            show_message("Exito", "Proceso completado")
        Else
            show_message("Error", "Ocurrio un error al convertir Pares a Atado")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiarPlataforma_Click(sender As Object, e As EventArgs) Handles btnLimpiarPlataforma.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim drResultado As Boolean = 0

        drResultado = objBU.LimpiarPlataforma()
        If drResultado Then
            show_message("Exito", "Proceso completado")
        Else
            show_message("Error", "Ocurrio un error al limpiar la plataforma")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblTitulo_Click(sender As Object, e As EventArgs) Handles lblTitulo.Click

    End Sub
End Class