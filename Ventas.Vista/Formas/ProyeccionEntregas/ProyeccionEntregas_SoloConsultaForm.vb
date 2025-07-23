Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Public Class ProyeccionEntregas_SoloConsultaForm
    Dim listPlazoPago As New List(Of String)
    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)
    Dim PrimeraConsulta As Integer = 1
    Dim nivelActualTercerGrid As Integer = 0
    Dim gridSeleccionadoClicDerecho As UltraGrid ' 1 = pedido, 2 = partida, 3 = lote, 4 = atado, 5 = par
    Dim listaRenglonesSeleccionados As List(Of Integer) 'LISTA PARA GUARDAR LOS INDEX DE LOS RENGLONES QUE SE MARCARAN O DESMARCARAN CON CLIC DERECHO
    Dim filtros As New Entidades.ProyeccionEntregas
    Dim ModoEdicion As Boolean = True
    Dim CantidadFiltrosSeleccionados As Integer = 0
    Dim TipoPerfil As Integer = 0 '1 => Atencion Clientes,  2 => Jefatura

    Dim PartidasPedidosForm As ProyeccionEntregas_Pedidos_PartidasForm

    Private Sub ProyeccionEntregasForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim confirmar As New Tools.ConfirmarForm

        confirmar.mensaje = "Los datos no guardados se borrarán ¿Desea continuar?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim objBU As New Negocios.ProyeccionEntregasBU
            Dim dtSesiones As New DataTable

            Try
                Cursor = Cursors.WaitCursor

                dtSesiones = objBU.ConsultaSesionActivaPorUsuario_SoloConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                objBU.LimpiarSesionUsuarioCerrarPantalla_SoloConsulta(dtSesiones.Rows(0).Item("SesionActiva").ToString)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub ObtenerFecha()
        Dim FechaActual As Date = Date.Now
        Dim DiaSemana As Integer = FechaActual.DayOfWeek
        Dim FechaInicio As Date
        Dim FechaFin As Date

        If DiaSemana >= 1 Then
            FechaInicio = FechaActual.AddDays((1 - DiaSemana))
        Else
            FechaInicio = FechaActual.AddDays(1)
        End If

        FechaFin = FechaActual.AddDays(6 - DiaSemana)

        dtpFechaEntregaDel.Value = FechaInicio
        dtpFechaEntregaAl.Value = FechaFin
    End Sub

    Private Sub PermisosPerfil()
        Dim DTInformacionUsuario As New DataTable

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY_SOLO_CONSULTA", "VENT_PROYECCION_ATENCIONCLIENTES") Then
            TipoPerfil = 1
            btnFiltroAtnClientes.Enabled = False
            DTInformacionUsuario.Columns.Add("IdColaborador")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nombre")
            DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

            grdAtencionClientes.DataSource = DTInformacionUsuario
            grdAtencionClientes.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdAtencionClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True

        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY_SOLO_CONSULTA", "VENT_PROYECCION_JEFATURA") Then
            TipoPerfil = 2
            btnFiltroAtnClientes.Enabled = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY_SOLO_CONSULTA", "VENT_PROYECCION_AGENTES") Then
            TipoPerfil = 3
            btnFiltroAgentes.Enabled = False

            DTInformacionUsuario.Columns.Add("IdColaborador")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nombre")
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = 10433 Or Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = 10606 Then
                DTInformacionUsuario.Rows.Add(10433, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)
                DTInformacionUsuario.Rows.Add(10606, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)
            Else
                DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)
            End If
            'DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

            CargarAgentesColaboradorInactivos(DTInformacionUsuario)

            grdAgenteVentas.DataSource = DTInformacionUsuario
            grdAgenteVentas.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdAgenteVentas.DisplayLayout.Bands(0).Columns(1).Hidden = True

            GrpbxBloqueo.Visible = False
            'btnLimpiarFiltros.Visible = False
            'lblTExtoLimpiar.Visible = False
            'btnGuardar.Visible = False
            'lblGuardar.Visible = False
            lblAbrPY.Visible = False
            lblTextoProy.Visible = False
            lblAbrPC.Visible = False
            lblTextopart.Visible = False
            lblAbrLC.Visible = False
            lblTextLC.Visible = False
        End If



    End Sub

    ' Autor: Javier Salazar García
    ' Temporal
    ' Agrega los id de colaborador anterior a los colaboradores que se les creó 
    ' un nuevo registro por motivos de cambio de razón social.
    Public Sub CargarAgentesColaboradorInactivos(ByRef DTInformacionUsuario As DataTable)

        Dim colaboradores(5, 1) As Int16
        colaboradores(0, 0) = 8168 'Humberto
        colaboradores(0, 1) = 136  ' Colaborador anterior de Humberto
        colaboradores(1, 0) = 8280 'Leobardo
        colaboradores(1, 1) = 885
        colaboradores(2, 0) = 8285 'Sandra
        colaboradores(2, 1) = 840
        colaboradores(3, 0) = 8670 'Sergio Mondragon
        colaboradores(3, 1) = 377
        colaboradores(4, 0) = 8621 'David Barajas
        colaboradores(4, 1) = 2715
        colaboradores(5, 0) = 8169 'Luis Aldaz
        colaboradores(5, 1) = 6453

        Dim count As Integer = colaboradores.GetLength(0) - 1

        For i As Integer = 0 To count
            If colaboradores(i, 0) = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser Then
                DTInformacionUsuario.Rows.Add(colaboradores(i, 1), 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)
            End If
        Next

    End Sub

    Private Sub ProyeccionEntregasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2

        spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width - 4
        spcPartidasLotes.SplitterDistance = spcPartidasLotes.Height - 4

        Me.gridSumatoria.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False

        lblTextoUltimaDistribucion.Visible = False
        lblFechaUltimaActualizacion.Visible = False

        PermisosPerfil()
        ObtenerFecha()
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)

    End Sub

    Public Sub PonerModoEdicion()

        If ModoEdicion = False Then
            If IsNothing(grdNivelPedido.DataSource) = False Then
                grdNivelPedido.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.NoEdit
            End If
            If IsNothing(grdNivelPartida.DataSource) = False Then
                grdNivelPartida.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.NoEdit
            End If
            If IsNothing(grdNivelLotes.DataSource) = False Then
                grdNivelLotes.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.NoEdit
            End If
            If IsNothing(grdNivelAtados.DataSource) = False Then
                grdNivelAtados.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.NoEdit
            End If
            If IsNothing(grdNivelPares.DataSource) = False Then
                grdNivelPares.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.NoEdit
            End If
        Else
            If IsNothing(grdNivelPedido.DataSource) = False Then
                grdNivelPedido.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.AllowEdit
            End If
            If IsNothing(grdNivelPartida.DataSource) = False Then
                grdNivelPartida.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.AllowEdit
            End If
            If IsNothing(grdNivelLotes.DataSource) = False Then
                grdNivelLotes.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.AllowEdit
            End If
            If IsNothing(grdNivelAtados.DataSource) = False Then
                grdNivelAtados.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.AllowEdit
            End If
            If IsNothing(grdNivelPares.DataSource) = False Then
                grdNivelPares.DisplayLayout.Bands(0).Columns("PY").CellActivation = Activation.AllowEdit
            End If
        End If


    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.ProyeccionEntregasBU
        Dim dtSesiones As New DataTable
        Dim confirmar As New Tools.ConfirmarForm
        Dim sesionAnterior As Integer = 0 '0 = no, 1 = si
        Dim limpiarSesion As Integer = 0 '0 = no, 1 = si

        Dim consultaNivelPedido As New Entidades.ProyeccionEntregasPorNivel
        Dim dtConsultaNivelPedido As New DataTable

        'VERIFICAR SESIONES ANTERIORES ACTIVAS

        '=========================================================================
        '====================BLOQUE QUE SE MODIFICARA=============================
        '=========================================================================
        dtSesiones = objBU.ConsultaSesionActivaPorUsuario_SoloConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtSesiones.Rows.Count > 0 And PrimeraConsulta = 1 Then
            sesionAnterior = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
            confirmar.mensaje = "Ya existe una sesión activa con este usuario, ¿desea recuperar la información de dicha sesión?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                limpiarSesion = 0
            Else
                limpiarSesion = 1
            End If
        Else

            sesionAnterior = 0
            If dtSesiones.Rows.Count() > 0 Then
                sesionAnterior = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
            End If
            limpiarSesion = 1
        End If
        '=========================================================================
        '=========================================================================
        '=========================================================================


        If PrimeraConsulta = 0 Then
            'confirmar.mensaje = "La información no guardada será borrada ¿Desea continuar?"
            'If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            CargarInformacion(sesionAnterior, limpiarSesion)
            FiltrarPedidosCompletos()
            btnArriba_Click(sender, e)
            Cursor = Cursors.Default
            ' Else
            'Return
            'End If
        Else
            Cursor = Cursors.WaitCursor
            CargarInformacion(sesionAnterior, limpiarSesion)
            FiltrarPedidosCompletos()
            btnArriba_Click(sender, e)
            Cursor = Cursors.Default
        End If
        lblTextoUltimaDistribucion.Visible = True
        lblFechaUltimaActualizacion.Visible = True
        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
        lblNumFiltrados.Text = CDbl(grdNivelPedido.Rows.Count().ToString()).ToString("N0")

        'btnGuardar.Enabled = True
    End Sub

    Private Sub ActualizarPantalla()
        Dim objBU As New Negocios.ProyeccionEntregasBU
        Dim dtSesiones As New DataTable
        Dim sesionAnterior As Integer = 0 '0 = no, 1 = si

        Cursor = Cursors.WaitCursor

        dtSesiones = objBU.ConsultaSesionActivaPorUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        sesionAnterior = 0
        If dtSesiones.Rows.Count() > 0 Then
            sesionAnterior = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
        End If

        CargarInformacion(sesionAnterior, 1)
        FiltrarPedidosCompletos()
        'btnGuardar.Enabled = True
        Cursor = Cursors.Default

    End Sub


    Private Sub CargarInformacion(ByVal sesionAnterior As Integer, ByVal limpiarSesion As Integer)
        Dim colaboradorProyectando As Integer = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        Dim usuarioIdProyectando As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim usuarioNombreProyectando As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        Dim objBU As New Negocios.ProyeccionEntregasBU


        grdNivelPedido.DataSource = Nothing
        grdNivelPartida.DataSource = Nothing
        grdNivelLotes.DataSource = Nothing
        grdNivelAtados.DataSource = Nothing
        grdNivelPares.DataSource = Nothing



        'TERMINA VERIFICAR SESIONES ANTERIORES ACTIVAS

        'INICIA GENERACIÓN DE DATOS PARA CONSULTAS

        Try
            If limpiarSesion = 1 Or sesionAnterior = 0 Then
                ObtenerFiltros(filtros)
                If CantidadFiltrosSeleccionados = 1 Then 'SIEMPRE CONSULTARA INFORMACION GENERARADA POR ALMENOS UN FILTRO
                    objBU.GeneracionDatosProyeccionEntregas_SoloConsulta(colaboradorProyectando, usuarioIdProyectando, usuarioNombreProyectando, sesionAnterior, filtros)
                Else
                    show_message("Advertencia", "Debe seleccionar al menos un filtro.")
                    ''objBU.GeneracionDatosProyeccionEntregasSinFiltros(colaboradorProyectando, usuarioIdProyectando, usuarioNombreProyectando, sesionAnterior)
                    'MENSAJE DE ADVERTENCIA PARA INFORMAR QUE SE DEBE TENER UNN FILTRO ACTIVO
                End If
            Else
                objBU.GeneracionDatosProyeccionEntregasCargarSesionAnterior_SoloConsulta(usuarioIdProyectando, usuarioNombreProyectando, sesionAnterior)
            End If
        Catch ex As Exception
            show_message("Error", "Hubo un error al generar los datos para mostrar, intente de nuevo")
            Cursor = Cursors.Default
            Exit Sub
        End Try

        ''TERMINA GENERACIÓN DE DATOS PARA CONSULTAS
        CargarInformacionNiveles(1)

        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4
        nivelActualTercerGrid = 0
        btnNivelSiguiente.Enabled = True
        btnNivelAnterior.Enabled = False
        lblPedidoSAYNivelPartidas.Text = "-"
        lblPedidoSICYNivelPartidas.Text = "-"
        lblOrdenClienteNivelPartidas.Text = "-"
        lblClienteNivelPartidas.Text = "-"

        spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width - 5
        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4


        If PrimeraConsulta = 1 Then
            PrimeraConsulta = 0
        End If

        'TERMINA CONSULTA INICIAL


    End Sub

#Region "FORMATO"



    Private Sub grid_diseño(grid As UltraGrid)
        grid.DisplayLayout.Bands(0).Header.Appearance.FontData.SizeInPoints = 7
        grid.DisplayLayout.Appearance.FontData.SizeInPoints = 7

        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            If grid.Name <> "grdNivelAtados" And grid.Name <> "grdNivelLotes" And grid.Name <> "grdNivelPares" And grid.Name <> "grdNivelPartida" And grid.Name <> "grdNivelPedido" Then
                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If
            .Override.RowAlternateAppearance.BackColor = Color.White
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

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

#Region "FILTROS"

#Region "FILTRO STATUS PEDIDO"
    Private Sub btnFiltroStatusPedidos_Click(sender As Object, e As EventArgs) Handles btnFiltroStatusPedidos.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 11

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusPedido.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusPedido.DataSource = listado.listParametros
        With grdStatusPedido
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
        End With
    End Sub

    Private Sub grdStatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusPedido.InitializeLayout
        grid_diseño(grdStatusPedido)
        grdStatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
    End Sub


    Private Sub grdStatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatusPedido.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "FILTRO CLIENTES"
    Private Sub btnFiltroClientes_Click(sender As Object, e As EventArgs) Handles btnFiltroClientes.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub


    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "FILTRO TIENDAS / EMBARQUES / CEDIS"

    Private Sub btnFiltroTiendas_Click(sender As Object, e As EventArgs) Handles btnFiltroTiendas.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTienda.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTienda.DataSource = listado.listParametros
        With grdTienda
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "tIENDA"
    End Sub


    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO ATN CLIENTES"

    Private Sub btnFiltroAtnClientes_Click(sender As Object, e As EventArgs) Handles btnFiltroAtnClientes.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAtencionClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAtencionClientes.DataSource = listado.listParametros
        With grdAtencionClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Atn Clientes"
        End With
    End Sub

    Private Sub grdAtencionClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtencionClientes.BeforeRowsDeleted

        If TipoPerfil = 1 Then
            e.Cancel = True
        End If
        e.DisplayPromptMsg = False

    End Sub

    Private Sub grdAtencionClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtencionClientes.InitializeLayout
        grid_diseño(grdAtencionClientes)
        grdAtencionClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atn Clientes"
    End Sub


    Private Sub grdAtencionClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAtencionClientes.KeyDown
        If TipoPerfil = 2 Then
            If Not e.KeyCode = Keys.Delete Then Return
            grdAtencionClientes.DeleteSelectedRows(False)
        End If

    End Sub

#End Region

#Region "FILTRO AGENTES"

    Private Sub btnFiltroAgentes_Click(sender As Object, e As EventArgs) Handles btnFiltroAgentes.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 4
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgenteVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgenteVentas.DataSource = listado.listParametros
        With grdAgenteVentas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente"
        End With
    End Sub

    Private Sub grdAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgenteVentas.InitializeLayout
        grid_diseño(grdAgenteVentas)
        grdAgenteVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente"
    End Sub


    Private Sub grdAgenteVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAgenteVentas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAgenteVentas.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO MARCAS"

    Private Sub btnFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnFiltroMarca.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
        End With
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub


    Private Sub grdMarcas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO COLECCIÓN"

    Private Sub btnFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnFiltroColeccion.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub


    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO MODELO"

    Private Sub btnFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnFiltroModelo.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        With grdModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelo"
        End With
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub


    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO PIEL"

    Private Sub btnFiltroPiel_Click(sender As Object, e As EventArgs) Handles btnFiltroPiel.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 8
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdPiel.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdPiel.DataSource = listado.listParametros
        With grdPiel
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Piel"
        End With
    End Sub

    Private Sub grdPiel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPiel.InitializeLayout
        grid_diseño(grdPiel)
        grdPiel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel"
    End Sub


    Private Sub grdPiel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPiel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPiel.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO COLOR"

    Private Sub btnFiltroColor_Click(sender As Object, e As EventArgs) Handles btnFiltroColor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 9
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColor.DataSource = listado.listParametros
        With grdColor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Color"
        End With
    End Sub

    Private Sub grdColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColor.InitializeLayout
        grid_diseño(grdColor)
        grdColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Color"
    End Sub


    Private Sub grdColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColor.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO CORRIDA"

    Private Sub btnFiltroCorrida_Click(sender As Object, e As EventArgs) Handles btnFiltroCorrida.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub


    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO PLAZO PAGO"

    Private Sub txtPlazoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlazoPago.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPlazoPago.Text) Then Return

            listPlazoPago.Add(txtPlazoPago.Text)
            grdPlazoPago.DataSource = Nothing
            grdPlazoPago.DataSource = listPlazoPago

            txtPlazoPago.Text = String.Empty

        End If
    End Sub

    Private Sub grdPlazoPago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPlazoPago.InitializeLayout
        grid_diseño(grdPlazoPago)
        grdPlazoPago.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Plazo de pago"
    End Sub


    Private Sub grdPlazoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPlazoPago.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPlazoPago.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO PEDIDO SAY"

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub


    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "FILTRO PEDIDO SICY"

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSICY_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdPedidoSICY.BeforeRowsDeleted, grdPedidoSAY.BeforeRowsDeleted, grdCliente.BeforeRowsDeleted, grdTienda.BeforeRowsDeleted, grdPlazoPago.BeforeRowsDeleted, grdMarca.BeforeRowsDeleted, grdColeccion.BeforeRowsDeleted, grdModelo.BeforeRowsDeleted, grdPiel.BeforeRowsDeleted, grdColor.BeforeRowsDeleted, grdCorrida.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgente_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgenteVentas.BeforeRowsDeleted
        If TipoPerfil = 3 Then
            e.Cancel = True
        End If
        e.DisplayPromptMsg = False
    End Sub




    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub


    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

#End Region


    Public Sub ObtenerFiltros(filtros As Entidades.ProyeccionEntregas)
        Dim fechaEntregaInicio As String = ""
        Dim fechaEntregaFin As String = ""
        Dim mostrarClientesCita As Integer = 0
        Dim mostrarClientesNoCita As Integer = 0
        Dim statusPedido As String = ""
        Dim plazoPago As String = ""
        Dim pedidoSAY As String = ""
        Dim pedidoSICY As String = ""
        Dim cliente As String = ""
        Dim tiendaEmbarqueCedis As String = ""
        Dim atnClientes As String = ""
        Dim agenteVentas As String = ""
        Dim marca As String = ""
        Dim coleccion As String = ""
        Dim modelo As String = ""
        Dim piel As String = ""
        Dim color As String = ""
        Dim corrida As String = ""

        CantidadFiltrosSeleccionados = 0

        'INICIA OBTENER FILTROS
        filtros.PfechaEntregaInicio = If(chboxFechasEntrega.Checked = True, dtpFechaEntregaDel.Value.ToShortDateString, "")
        filtros.PfechaEntregaFin = If(chboxFechasEntrega.Checked = True, dtpFechaEntregaAl.Value.ToShortDateString, "")

        fechaEntregaInicio = filtros.PfechaEntregaInicio
        fechaEntregaFin = filtros.PfechaEntregaFin

        filtros.PmostrarClientesCita = If(chboxClientesCita.Checked, 1, 0)
        filtros.PmostrarClientesNoCita = If(chboxClientesNoCita.Checked, 1, 0)

        mostrarClientesCita = filtros.PmostrarClientesCita
        mostrarClientesNoCita = filtros.PmostrarClientesNoCita


        For Each row As UltraGridRow In grdStatusPedido.Rows
            If row.Index = 0 Then
                statusPedido += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                statusPedido += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PstatusPedido = statusPedido

        For Each row As UltraGridRow In grdPlazoPago.Rows
            If row.Index = 0 Then
                plazoPago += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                plazoPago += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PplazoPago = plazoPago

        For Each row As UltraGridRow In grdPedidoSAY.Rows
            If row.Index = 0 Then
                pedidoSAY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                pedidoSAY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PpedidoSAY = pedidoSAY

        For Each row As UltraGridRow In grdPedidoSICY.Rows
            If row.Index = 0 Then
                pedidoSICY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                pedidoSICY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PpedidoSICY = pedidoSICY

        For Each row As UltraGridRow In grdCliente.Rows
            If row.Index = 0 Then
                cliente += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                cliente += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pcliente = cliente

        For Each row As UltraGridRow In grdTienda.Rows
            If row.Index = 0 Then
                tiendaEmbarqueCedis += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                tiendaEmbarqueCedis += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PtiendaEmbarqueCedis = tiendaEmbarqueCedis

        For Each row As UltraGridRow In grdAtencionClientes.Rows
            If row.Index = 0 Then
                atnClientes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                atnClientes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PatnClientes = atnClientes

        For Each row As UltraGridRow In grdAgenteVentas.Rows
            If row.Index = 0 Then
                agenteVentas += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                agenteVentas += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.PagenteVentas = agenteVentas

        For Each row As UltraGridRow In grdMarca.Rows
            If row.Index = 0 Then
                marca += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                marca += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pmarca = marca

        For Each row As UltraGridRow In grdColeccion.Rows
            If row.Index = 0 Then
                coleccion += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                coleccion += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pcoleccion = coleccion

        For Each row As UltraGridRow In grdModelo.Rows
            If row.Index = 0 Then
                modelo += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                modelo += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pmodelo = modelo

        For Each row As UltraGridRow In grdPiel.Rows
            If row.Index = 0 Then
                piel += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                piel += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Ppiel = piel

        For Each row As UltraGridRow In grdColor.Rows
            If row.Index = 0 Then
                color += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                color += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pcolor = color

        For Each row As UltraGridRow In grdCorrida.Rows
            If row.Index = 0 Then
                corrida += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                corrida += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtros.Pcorrida = corrida


        If fechaEntregaInicio <> "" Or fechaEntregaFin <> "" Or (mostrarClientesCita <> mostrarClientesNoCita Or mostrarClientesCita <> 1 Or mostrarClientesNoCita <> 1) Or statusPedido <> "" Or plazoPago <> "" Or pedidoSAY <> "" Or pedidoSICY <> "" Or cliente <> "" Or tiendaEmbarqueCedis <> "" Or atnClientes <> "" Or agenteVentas <> "" Or marca <> "" Or coleccion <> "" Or modelo <> "" Or piel <> "" Or color <> "" Or corrida <> "" Then
            CantidadFiltrosSeleccionados = 1
        End If

        'TERMINA OBTENER FILTROS

    End Sub

#End Region

#Region "OTRAS FUNCIONES"

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
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

#End Region



    Private Sub chboxFechasEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechasEntrega.CheckedChanged
        If chboxFechasEntrega.Checked = True Then
            dtpFechaEntregaDel.Enabled = True
            dtpFechaEntregaAl.Enabled = True
        Else
            dtpFechaEntregaDel.Enabled = False
            dtpFechaEntregaAl.Enabled = False
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 21
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 313
    End Sub

    Private Sub grdNivelPedido_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelPedido.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPedido.ActiveRow) = False Then
            If grdNivelPedido.ActiveRow.IsFilterRow = False Then
                Try

                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPedido.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(filasActivas, 1)
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If


    End Sub



    Private Sub grdNivelPedido_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNivelPedido.ClickCell

        Try

            If grdNivelPedido.ActiveRow.IsFilterRow = False And e.Cell.Row.Index >= 0 Then
                Cursor = Cursors.WaitCursor
                Dim EsMarcada As Integer = 0
                Dim FilasSeleccionadas = grdNivelPedido.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1 And x.Index <> e.Cell.Row.Index)

                If e.Cell.Column.Key = "Seleccionar" Then
                    lblPedidoSICYNivelPartidas.Text = e.Cell.Row.Cells("Pedido SICY").Value.ToString()
                    lblClienteNivelPartidas.Text = e.Cell.Row.Cells("Cliente").Value.ToString()
                    lblOrdenClienteNivelPartidas.Text = e.Cell.Row.Cells("Orden").Value.ToString()
                    Label51.Text = e.Cell.Row.Cells("Origen").Value.ToString()

                    If CBool(e.Cell.Value) = True Then
                        e.Cell.Value = False
                        grdNivelPartida.DataSource = Nothing
                    Else
                        If e.Cell.Column.Key = "Seleccionar" Then
                            LimpiarGrid(1)
                        End If
                        e.Cell.Value = True


                        Dim filasActivas = grdNivelPedido.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                        If filasActivas.Count > 0 Then
                            GuardarProyeccion(filasActivas, 1)
                        End If

                    End If
                End If

                'Andrea
                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value = "816" And ((e.Cell.Row.Cells("INV").Value + e.Cell.Row.Cells("PRC").Value) = e.Cell.Row.Cells("P Proyectar").Value And e.Cell.Row.Cells("P Proyectar").Value > 0) Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelPedido, 1, False, 1)
                    Else
                        MarcarProyeccion(grdNivelPedido, 1, True, 1)
                    End If
                    ActualizarGrid(1)
                End If

                'LotesCompletos
                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" And (e.Cell.Row.Cells("LC").Value = "SI") And (e.Cell.Row.Appearance.BackColor = Color.MediumSeaGreen Or (e.Cell.Row.Cells("LC").Value = "SI") Or (e.Cell.Row.Appearance.BackColor = Color.Empty And e.Cell.Row.Cells("PC").Value = "NO" And e.Cell.Row.Cells("INV").Value > 0) Or (e.Cell.Row.Cells("PC").Value = "SI" And e.Cell.Row.Cells("totalPartidasCompletas").Value > 0 And e.Cell.Row.Appearance.BackColor = Color.Empty)) Then
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccionLotesCompletos(1, False)
                    Else
                        MarcarProyeccionLotesCompletos(1, True)
                    End If

                End If



                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" And (e.Cell.Row.Cells("LC").Value = "NO") And (e.Cell.Row.Appearance.BackColor = Color.MediumSeaGreen Or (e.Cell.Row.Cells("LC").Value = "SI") Or (e.Cell.Row.Appearance.BackColor = Color.Empty And e.Cell.Row.Cells("PC").Value = "NO" And e.Cell.Row.Cells("INV").Value > 0) Or (e.Cell.Row.Cells("PC").Value = "SI" And e.Cell.Row.Cells("totalPartidasCompletas").Value > 0 And e.Cell.Row.Appearance.BackColor = Color.Empty)) Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelPedido, 1, False, 1)
                    Else
                        MarcarProyeccion(grdNivelPedido, 1, True, 1)
                    End If
                    ActualizarGrid(1)
                End If


                If e.Cell.Column.Key = "Seleccionar" Then


                    For Each fila As UltraGridRow In FilasSeleccionadas
                        fila.Cells("Seleccionar").Value = 0
                    Next


                    If CBool(e.Cell.Text) = True Then
                        If spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width - 5 Then
                            spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width / 2
                            spcPartidasLotes.SplitterDistance = spcPedidos.Height - 4
                            spcPedidos.SplitterDistance = 30
                        End If
                        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4

                        spcPartidasLotes.Width = 500
                        spcPedidos.Width = spcPedidos.Width - 200
                        InicializarPaneles()

                        If IsDBNull(e.Cell.Row.Cells("Pedido SAY").Value) = False Then
                            lblPedidoSAYNivelPartidas.Text = e.Cell.Row.Cells("Pedido SAY").Value.ToString()
                        End If

                        lblPedidoSICYNivelPartidas.Text = e.Cell.Row.Cells("Pedido SICY").Value.ToString()
                        lblClienteNivelPartidas.Text = e.Cell.Row.Cells("Cliente").Value.ToString()
                        lblOrdenClienteNivelPartidas.Text = e.Cell.Row.Cells("Orden").Value.ToString()
                        Label51.Text = e.Cell.Row.Cells("Origen").Value.ToString()

                        CargarInformacionNiveles(2, e.Cell.Row.Cells("Pedido SAY").Value, e.Cell.Row.Cells("Pedido SICY").Value)
                    Else
                        If FilasSeleccionadas.Count() = 0 Then
                            spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width - 5
                        End If
                        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4
                        InicializarPaneles()

                    End If

                End If

                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    'Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click

    '    grdPedidoSAY.DataSource = Nothing
    '    grdPedidoSICY.DataSource = Nothing
    '    grdCliente.DataSource = Nothing
    '    grdTienda.DataSource = Nothing
    '    grdAtencionClientes.DataSource = Nothing
    '    grdAgenteVentas.DataSource = Nothing
    '    grdStatusPedido.DataSource = Nothing
    '    grdPlazoPago.DataSource = Nothing
    '    grdMarca.DataSource = Nothing
    '    grdColeccion.DataSource = Nothing
    '    grdModelo.DataSource = Nothing
    '    grdPiel.DataSource = Nothing
    '    grdColor.DataSource = Nothing
    '    grdCorrida.DataSource = Nothing

    '    grdNivelPedido.DataSource = Nothing
    '    grdNivelPartida.DataSource = Nothing
    '    grdNivelLotes.DataSource = Nothing
    '    grdNivelAtados.DataSource = Nothing
    '    grdNivelPares.DataSource = Nothing

    '    chboxClientesCita.Checked = True
    '    chboxClientesNoCita.Checked = True
    '    chboxFechasEntrega.Checked = False

    '    spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4
    '    nivelActualTercerGrid = 0
    '    btnNivelSiguiente.Enabled = True
    '    btnNivelAnterior.Enabled = False

    '    lblPedidoSAYNivelPartidas.Text = "-"
    '    lblPedidoSICYNivelPartidas.Text = "-"
    '    lblOrdenClienteNivelPartidas.Text = "-"
    '    lblClienteNivelPartidas.Text = "-"

    '    spcPedidosPartidas.SplitterDistance = spcPedidosPartidas.Width - 5
    '    spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4



    'End Sub

    Private Sub grdNivelPartida_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelPartida.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPartida.ActiveRow) = False Then
            If grdNivelPartida.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPartida.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 2)
                    End If

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If

    End Sub


    Private Sub grdNivelPartida_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNivelPartida.ClickCell

        Try
            If grdNivelPartida.ActiveRow.IsFilterRow = False And e.Cell.Row.Index >= 0 Then
                Cursor = Cursors.WaitCursor
                If e.Cell.Column.Key = "Seleccionar" Then
                    If CBool(e.Cell.Value) = True Then
                        e.Cell.Value = False
                    Else
                        If e.Cell.Column.Key = "Seleccionar" Then
                            LimpiarGrid(2)
                        End If
                        e.Cell.Value = True
                        Dim filasActivas = grdNivelPartida.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                        If filasActivas.Count > 0 Then
                            GuardarProyeccion(Nothing, 2)
                        End If
                    End If
                End If

                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" And (e.Cell.Row.Appearance.BackColor = Color.MediumSeaGreen Or (e.Cell.Row.Appearance.BackColor = Color.Empty And e.Cell.Row.Cells("PC").Value = "NO") And e.Cell.Row.Cells("INV").Value > 0) Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelPartida, 2, False, 2)
                    Else
                        MarcarProyeccion(grdNivelPartida, 2, True, 2)
                    End If
                    ActualizarGrid(2)
                End If

                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value = "816" And (e.Cell.Row.Appearance.BackColor = Color.MediumSeaGreen Or (e.Cell.Row.Appearance.BackColor = Color.Empty And e.Cell.Row.Cells("PC").Value = "NO") And e.Cell.Row.Cells("INV").Value + e.Cell.Row.Cells("PRC").Value > 0) Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelPartida, 2, False, 2)
                    Else
                        MarcarProyeccion(grdNivelPartida, 2, True, 2)
                    End If
                    ActualizarGrid(2)
                End If


                If e.Cell.Column.Key = "Seleccionar" Then
                    Dim FilasSeleccionadas = grdNivelPartida.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1 And x.Index <> e.Cell.Row.Index)
                    For Each fila As UltraGridRow In FilasSeleccionadas
                        fila.Cells("Seleccionar").Value = 0
                    Next


                    If CBool(e.Cell.Text) = True Then

                        lblPartidaNivelLotes.Text = e.Cell.Row.Cells("Partida").Value
                        lblLoteNivelAtadosTexto.Visible = False
                        lblLoteNivelAtados.Text = "-"
                        lblLoteNivelAtados.Visible = False

                        lblNaveNivelAtadosTexto.Visible = False
                        lblNaveNivelAtados.Text = "-"
                        lblNaveNivelAtados.Visible = False

                        lblAñoTextoNivelAtados.Visible = False
                        lblAñoNivelAtados.Text = "-"
                        lblAñoNivelAtados.Visible = False

                        lblEstatusLoteTextoNivelAtados.Visible = False
                        lblEstatusLoteNivelAtados.Text = "-"
                        lblEstatusLoteNivelAtados.Visible = False

                        lblDescripcion.Visible = True
                        lblArticuloNivelLote.Text = e.Cell.Row.Cells("Descripción").Value
                        lblArticuloNivelLote.Visible = True


                        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height / 2
                        spcPedidos.SplitterDistance = 30
                        InicializarPaneles()
                        CargarInformacionNiveles(3, e.Cell.Row.Cells("Pedido SAY").Value, e.Cell.Row.Cells("Pedido SICY").Value, 0, e.Cell.Row.Cells("Partida").Value)
                        grdNivelLotes.Focus()

                    Else
                        spcPartidasLotes.SplitterDistance = spcPedidosPartidas.Height - 4
                        spcPedidos.SplitterDistance = 30
                        nivelActualTercerGrid = 0
                        btnNivelSiguiente.Enabled = True
                        btnNivelAnterior.Enabled = False
                    End If
                End If

                Cursor = Cursors.Default
            End If
            gridSumatoria.DataSource = Nothing
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnNivelSiguiente_Click(sender As Object, e As EventArgs) Handles btnNivelSiguiente.Click

        Try
            Cursor = Cursors.WaitCursor

            Select Case nivelActualTercerGrid
                Case 0

                    Dim FilaLote = grdNivelLotes.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1)
                    Dim lotesSeleccionados As New List(Of String)


                    If FilaLote.Count() = 1 Then
                        grdNivelAtados.DataSource = Nothing
                        CargarInformacionNiveles(4, "0", FilaLote(0).Cells("pdpr_pedidosicy").Value, FilaLote(0).Cells("Lote").Value, FilaLote(0).Cells("pdpr_partida").Value, FilaLote(0).Cells("Año").Value, FilaLote(0).Cells("NaveId").Value)
                        grdNivelAtados.Focus()
                        pnlNivelLotes.Visible = False
                        lblTituloNivelLotes.Visible = False
                        nivelActualTercerGrid = 1
                        btnNivelAnterior.Enabled = True

                        lblLoteNivelAtadosTexto.Visible = True
                        lblLoteNivelAtados.Text = FilaLote(0).Cells("Lote").Value.ToString
                        lblLoteNivelAtados.Visible = True

                        lblNaveNivelAtadosTexto.Visible = True
                        lblNaveNivelAtados.Text = FilaLote(0).Cells("Nave").Value.ToString
                        lblNaveNivelAtados.Visible = True
                        'Nave
                        lblAñoTextoNivelAtados.Visible = True
                        lblAñoNivelAtados.Text = FilaLote(0).Cells("Año").Value.ToString
                        lblAñoNivelAtados.Visible = True

                        lblEstatusLoteTextoNivelAtados.Visible = False
                        lblEstatusLoteNivelAtados.Text = "-"
                        lblEstatusLoteNivelAtados.Visible = False



                    Else
                        show_message("Advertencia", "No se ha seleccionado un lote.")
                        nivelActualTercerGrid = 0
                        grdNivelLotes.Focus()

                        lblLoteNivelAtadosTexto.Visible = True
                        lblLoteNivelAtados.Text = "-"
                        lblLoteNivelAtados.Visible = True

                        lblNaveNivelAtadosTexto.Visible = True
                        lblNaveNivelAtados.Text = "-"
                        lblNaveNivelAtados.Visible = False
                        'Nave
                        lblAñoTextoNivelAtados.Visible = True
                        lblAñoNivelAtados.Text = "-"
                        lblAñoNivelAtados.Visible = False

                        lblEstatusLoteTextoNivelAtados.Visible = False
                        lblEstatusLoteNivelAtados.Text = "-"
                        lblEstatusLoteNivelAtados.Visible = False

                    End If

                Case 1

                    Dim FilaAtado = grdNivelAtados.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1)

                    If FilaAtado.Count() = 1 Then
                        grdNivelPares.DataSource = Nothing
                        lblCodigoAtado.Text = FilaAtado(0).Cells("Atado").Value
                        CargarInformacionNiveles(5, "0", FilaAtado(0).Cells("pdpr_pedidosicy").Value, FilaAtado(0).Cells("pdpr_lote").Value, FilaAtado(0).Cells("pdpr_partida").Value, FilaAtado(0).Cells("pdpr_añolote").Value, FilaAtado(0).Cells("pdpr_naveidsicy").Value, FilaAtado(0).Cells("Atado").Value)
                        grdNivelPares.Focus()
                        pnlNivelAtados.Visible = False
                        lblTituloNivelAtados.Visible = False
                        nivelActualTercerGrid = 2
                        btnNivelSiguiente.Enabled = False
                    Else
                        show_message("Advertencia", "No se ha seleccionado un atado.")
                        pnlNivelAtados.Visible = True
                        lblTituloNivelAtados.Visible = True
                        nivelActualTercerGrid = 1
                        btnNivelSiguiente.Enabled = True
                    End If


                    grdNivelPares.Focus()
            End Select
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub



    Private Sub btnNivelAnterior_Click(sender As Object, e As EventArgs) Handles btnNivelAnterior.Click

        Try
            Cursor = Cursors.WaitCursor

            Select Case nivelActualTercerGrid
                Case 2
                    pnlNivelAtados.Visible = True
                    lblTituloNivelAtados.Visible = True
                    nivelActualTercerGrid = 1
                    btnNivelSiguiente.Enabled = True
                    grdNivelAtados.Focus()
                    For Each fila As UltraGridRow In grdNivelAtados.Rows
                        fila.Cells("Seleccionar").Value = False
                    Next

                    gridSumatoria.Visible = True
                    consultarSumatoria("Atados", grdNivelAtados.ActiveRow)

                Case 1
                    pnlNivelLotes.Visible = True
                    lblTituloNivelLotes.Visible = True
                    nivelActualTercerGrid = 0
                    btnNivelAnterior.Enabled = False
                    lblLoteNivelAtadosTexto.Visible = False
                    lblLoteNivelAtados.Visible = False
                    lblAñoNivelAtados.Visible = False
                    lblAñoTextoNivelAtados.Visible = False
                    lblNaveNivelAtadosTexto.Visible = False
                    lblNaveNivelAtados.Visible = False
                    lblEstatusLoteTextoNivelAtados.Visible = False
                    lblEstatusLoteNivelAtados.Visible = False

                    consultarSumatoria("Lotes", grdNivelLotes.ActiveRow)

                    grdNivelLotes.Focus()

                    lblLoteNivelAtadosTexto.Visible = False
                    lblLoteNivelAtados.Text = "-"
                    lblLoteNivelAtados.Visible = False

                    lblNaveNivelAtadosTexto.Visible = False
                    lblNaveNivelAtados.Text = "-"
                    lblNaveNivelAtados.Visible = False

                    lblAñoTextoNivelAtados.Visible = False
                    lblAñoNivelAtados.Text = "-"
                    lblAñoNivelAtados.Visible = False

                    lblEstatusLoteTextoNivelAtados.Visible = False
                    lblEstatusLoteNivelAtados.Text = "-"
                    lblEstatusLoteNivelAtados.Visible = False
                    For Each fila As UltraGridRow In grdNivelLotes.Rows
                        fila.Cells("Seleccionar").Value = False
                    Next
            End Select

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub InicializarPaneles()

        pnlNivelAtados.Visible = True
        lblTituloNivelAtados.Visible = True
        nivelActualTercerGrid = 1
        btnNivelSiguiente.Enabled = True


        pnlNivelLotes.Visible = True
        lblTituloNivelLotes.Visible = True
        nivelActualTercerGrid = 0
        btnNivelAnterior.Enabled = False
        btnNivelSiguiente.Enabled = True
        lblLoteNivelAtadosTexto.Visible = False
        lblLoteNivelAtados.Visible = False
        lblAñoNivelAtados.Visible = False
        lblAñoTextoNivelAtados.Visible = False
        lblNaveNivelAtadosTexto.Visible = False
        lblNaveNivelAtados.Visible = False
        lblEstatusLoteTextoNivelAtados.Visible = False
        lblEstatusLoteNivelAtados.Visible = False


        'grdNivelLotes.Focus()
    End Sub


    Private Sub grdNivelLotes_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelLotes.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelLotes.ActiveRow) = False Then
            If grdNivelLotes.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 3)
                    End If


                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelLotes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNivelLotes.ClickCell

        Try
            If grdNivelLotes.ActiveRow.IsFilterRow = False And e.Cell.Row.Index >= 0 Then
                Cursor = Cursors.WaitCursor
                consultarSumatoria("Lotes", e.Cell.Row)
                If e.Cell.Column.Key = "Seleccionar" Then
                    If CBool(e.Cell.Value) = True Then
                        e.Cell.Value = False
                    Else
                        If e.Cell.Column.Key = "Seleccionar" Then
                            LimpiarGrid(3)
                        End If
                        e.Cell.Value = True

                        Dim filasActivas = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                        If filasActivas.Count > 0 Then
                            GuardarProyeccion(Nothing, 3)
                        End If
                    End If
                End If

                If e.Cell.Column.Key = "PY" And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" And (e.Cell.Row.Appearance.BackColor = Color.MediumSeaGreen Or (e.Cell.Row.Appearance.BackColor = Color.Empty And e.Cell.Row.Cells("PC").Value = "NO") And e.Cell.Row.Cells("INV").Value > 0) Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1

                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelLotes, 3, False, 3)
                    Else
                        MarcarProyeccion(grdNivelLotes, 3, True, 3)
                    End If
                    ActualizarGrid(3)
                End If



                If e.Cell.Column.Key = "Seleccionar" Then
                    Dim FilasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1 And x.Index <> e.Cell.Row.Index)
                    For Each fila As UltraGridRow In FilasSeleccionadas
                        fila.Cells("Seleccionar").Value = 0
                    Next
                End If
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Sub consultarSumatoria(NivelConsuta As String, fila As UltraGridRow)
        Dim dtConsulta As New DataTable
        Dim objBU As New Negocios.ProyeccionEntregasBU

        gridSumatoria.DataSource = Nothing

        Select Case NivelConsuta
            Case "Atados"
                Dim atado As String = fila.Cells("Atado").Value
                dtConsulta = objBU.consultarSumatoriaAtados(atado)
            Case "Lotes"
                Dim Lote As String = fila.Cells("Lote").Value
                Dim Nave As String = fila.Cells("NaveID").Value
                Dim Año As String = fila.Cells("Año").Value
                dtConsulta = objBU.consultarSumatoriaLotes(Lote, Nave, Año)
        End Select

        gridSumatoria.DataSource = dtConsulta
        'grid_diseño(gridSumatoria)

        gridSumatoria.DisplayLayout.Bands(0).Header.Appearance.FontData.SizeInPoints = 7
        gridSumatoria.DisplayLayout.Appearance.FontData.SizeInPoints = 7

        With gridSumatoria.DisplayLayout
            .Bands(0).Header.Appearance.FontData.SizeInPoints = 7
            .Appearance.FontData.SizeInPoints = 7
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.White
            .Override.AllowAddNew = AllowAddNew.No
        End With

    End Sub

    Private Sub grdNivelAtados_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelAtados.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelAtados.ActiveRow) = False Then
            If grdNivelAtados.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 4)
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelAtados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNivelAtados.ClickCell

        Try
            If grdNivelAtados.ActiveRow.IsFilterRow = False And e.Cell.Row.Index >= 0 Then
                Cursor = Cursors.WaitCursor
                consultarSumatoria("Atados", e.Cell.Row)
                If e.Cell.Column.Key = "Seleccionar" Then
                    If CBool(e.Cell.Value) = True Then
                        e.Cell.Value = False
                    Else
                        If e.Cell.Column.Key = "Seleccionar" Then
                            LimpiarGrid(4)
                        End If
                        e.Cell.Value = True
                        Dim filasActivas = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                        If filasActivas.Count > 0 Then
                            GuardarProyeccion(Nothing, 4)
                        End If
                    End If
                End If

                If e.Cell.Column.Key = "PY" And e.Cell.Row.Appearance.BackColor <> Color.LightGray And e.Cell.Row.Cells("INV").Value > 0 And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelAtados, 4, False, 4)
                    Else
                        MarcarProyeccion(grdNivelAtados, 4, True, 4)
                    End If
                    ActualizarGrid(4)
                End If

                If e.Cell.Column.Key = "Seleccionar" Then
                    Dim FilasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Cells("Seleccionar").Value = 1 And x.Index <> e.Cell.Row.Index)
                    For Each fila As UltraGridRow In FilasSeleccionadas
                        fila.Cells("Seleccionar").Value = 0
                    Next
                End If



                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub


    Private Sub CargarInformacionNiveles(ByVal Nivel As Integer, Optional ByVal PedidoSAY As String = "0", Optional ByVal PedidoSICY As String = "0", Optional ByVal Lote As String = "0", Optional ByVal Partida As String = "0", Optional ByVal Año As String = "0", Optional ByVal Nave As String = "0", Optional ByVal Atado As String = "")
        Dim consultaNivelPedido As New Entidades.ProyeccionEntregasPorNivel
        Dim usuarioIdProyectando As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim objBU As New Negocios.ProyeccionEntregasBU
        Dim DtInformacion As New DataTable
        Dim DtInformacion_Partidas As New DataTable
        Dim Grid As New UltraGrid
        Dim dtSesiones As DataTable
        Dim sesionAnterior As Integer = 0
        ' Dim filtros As New Entidades.ProyeccionEntregas
        Dim dtInformacionOcupada As DataTable
        Dim NombreUsuariosOcupando As String = String.Empty

        consultaNivelPedido.PusuarioConsultaId = usuarioIdProyectando
        consultaNivelPedido.PtipoConsulta = Nivel
        consultaNivelPedido.PidPedidoSAY = PedidoSAY
        consultaNivelPedido.PidPedidoSICY = PedidoSICY
        consultaNivelPedido.PidPartida = Partida
        consultaNivelPedido.Plote = Lote
        consultaNivelPedido.Paño = Año
        consultaNivelPedido.PnaveSicyID = Nave
        consultaNivelPedido.Patado = Atado
        consultaNivelPedido.Pcedis = cboxNaveAlmacen.SelectedValue

        Select Case Nivel
            Case 1
                DtInformacion = objBU.ConsultaProyeccionPorNivel_Pedido_SoloConsulta(consultaNivelPedido)
                DtInformacion_Partidas = objBU.ConsultaProyeccionPorNivel_PartidaPedido_SoloConsulta(consultaNivelPedido)
            Case 2
                DtInformacion = objBU.ConsultaProyeccionPorNivel_Partida_SoloConsulta(consultaNivelPedido)
            Case 3
                DtInformacion = objBU.ConsultaProyeccionPorNivel_Lote_SoloConsulta(consultaNivelPedido)
            Case 4
                DtInformacion = objBU.ConsultaProyeccionPorNivel_Atado_SoloConsulta(consultaNivelPedido)
            Case 5
                DtInformacion = objBU.ConsultaProyeccionPorNivel_Pares(consultaNivelPedido)
        End Select

        dtSesiones = objBU.ConsultaSesionActivaPorUsuario_SoloConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'ObtenerFiltros(filtros)

        If dtSesiones.Rows.Count > 0 Then
            sesionAnterior = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
        End If

        If Nivel = 1 Then
            Grid = grdNivelPedido
            If DtInformacion_Partidas.Rows.Count > 0 Then
                PartidasPedidosForm = New ProyeccionEntregas_Pedidos_PartidasForm
                PartidasPedidosForm.grdVPartidasPedidos.DataSource = DtInformacion_Partidas
                GridDiseño(PartidasPedidosForm.grdVPartidasPedidos, 2)
            End If
        ElseIf Nivel = 2 Then
            Grid = grdNivelPartida
        ElseIf Nivel = 3 Then
            Grid = grdNivelLotes
        ElseIf Nivel = 4 Then
            Grid = grdNivelAtados
        ElseIf Nivel = 5 Then
            Grid = grdNivelPares
        End If

        Grid.DataSource = Nothing
        If DtInformacion.Rows.Count > 0 Then
            Grid.DataSource = DtInformacion
            GridDiseño(Grid, Nivel)

            If Nivel = 3 Or Nivel = 4 Or Nivel = 5 Then
                If Grid.Rows.Count > 0 Then
                    Grid.Rows(0).Selected = True
                End If
            End If

            If sesionAnterior > 0 And PrimeraConsulta = 1 Then
                dtInformacionOcupada = objBU.ComprobarDatosOcupados_SoloConsulta(sesionAnterior, filtros)
                'If dtInformacionOcupada.Rows.Count > 0 Then
                '    For Each usuario As DataRow In dtInformacionOcupada.Rows
                '        If NombreUsuariosOcupando = String.Empty Then
                '            NombreUsuariosOcupando += usuario.Item(0).ToString
                '        Else
                '            NombreUsuariosOcupando += "," + usuario.Item(0).ToString
                '        End If

                '    Next
                '    show_message("Advertencia", "Parte de la información esta siendo ocupada por: " + NombreUsuariosOcupando.Trim + ".")

                '    'If CInt(dtInformacionOcupada.Rows(0).Item(0).ToString()) > 0 Then
                '    '    show_message("Advertencia", "Parte de la información esta siendo ocupada por otro usuario.")
                '    'End If


                'End If
            End If

        Else

            If sesionAnterior > 0 And PrimeraConsulta = 1 Then
                dtInformacionOcupada = objBU.ComprobarDatosOcupados_SoloConsulta(sesionAnterior, filtros)
                '    If dtInformacionOcupada.Rows.Count > 0 Then

                '        For Each usuario As DataRow In dtInformacionOcupada.Rows
                '            If NombreUsuariosOcupando = String.Empty Then
                '                NombreUsuariosOcupando += usuario.Item(0).ToString
                '            Else
                '                NombreUsuariosOcupando += "," + usuario.Item(0).ToString
                '            End If

                '        Next
                '        show_message("Advertencia", "Parte de la información esta siendo ocupada por: " + NombreUsuariosOcupando.Trim + ".")

                '        'If CInt(dtInformacionOcupada.Rows(0).Item(0).ToString()) > 0 Then
                '        '    show_message("Advertencia", "La información esta siendo ocupada por otro usuario.")
                '        'Else
                '        '    show_message("Advertencia", "No hay datos para mostrar.")
                '        'End If
                '    Else
                '        show_message("Advertencia", "No hay datos para mostrar.")
                '    End If
                '    objBU.EliminarSesionUsuario(sesionAnterior)
            End If
        End If

        If grdNivelPedido.Rows.Count > 0 Then
            btnSeguimientoPares.Enabled = True
            lblSeguimientoPares.Enabled = True
            btnClientesBlolqueados.Enabled = True
            lblClientesBloqueados.Enabled = True
            'btnGuardar.Enabled = True
            'lblGuardar.Enabled = True
        End If

        PonerModoEdicion()

    End Sub


    Private Sub GridDiseño(ByVal grid As UltraGrid, ByVal Nivel As Integer)
        Dim ListaColumnasSumas As New List(Of String)
        ListaColumnasSumas.Add("Cantidad")
        ListaColumnasSumas.Add("Por Entregar")
        ListaColumnasSumas.Add("Proyectado")
        ListaColumnasSumas.Add("P Proyectar")
        ListaColumnasSumas.Add("A Proyectar")
        ListaColumnasSumas.Add("INV")
        ListaColumnasSumas.Add("FAC")
        ListaColumnasSumas.Add("PRG")
        ListaColumnasSumas.Add("PRO")
        ListaColumnasSumas.Add("PRC")
        ListaColumnasSumas.Add("AP")
        ListaColumnasSumas.Add("BLQ")
        ListaColumnasSumas.Add("RPRC")
        ListaColumnasSumas.Add("COT")
        ListaColumnasSumas.Add("COT P")

        grid_diseño(grid)

        grid.DisplayLayout.Bands(0).Columns("A Proyectar").CellAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Bands(0).Columns("A Proyectar").CellAppearance.FontData.SizeInPoints = 8


        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            If col.Key = "Seleccionar" Or col.Key = "PY" Then
                col.Style = ColumnStyle.CheckBox
                grid.DisplayLayout.Bands(0).Columns(col.Index).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                grid.DisplayLayout.Bands(0).Columns(col.Index).AllowRowFiltering = DefaultableBoolean.False

                grid.DisplayLayout.Bands(0).Columns(col.Key).Width = 30

                If col.Key = "Seleccionar" Then
                    grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
                End If

            Else
                grid.DisplayLayout.Bands(0).Columns(col.Index).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If ListaColumnasSumas.Exists(Function(x) x = col.Key) Then
                grid.DisplayLayout.Bands(0).Columns(col.Key).CellAppearance.TextHAlign = HAlign.Right
                SumarizarColumnaGrid(grid, col.Key, col.Key, SummaryType.Sum)
                grid.DisplayLayout.Bands(0).Columns(col.Key).Format = "n0"
            End If
        Next
        grid.DisplayLayout.Bands(0).Columns("INV").Width = 30
        grid.DisplayLayout.Bands(0).Columns("FAC").Width = 30
        grid.DisplayLayout.Bands(0).Columns("PRG").Width = 30
        grid.DisplayLayout.Bands(0).Columns("PRO").Width = 30
        grid.DisplayLayout.Bands(0).Columns("PRC").Width = 40
        grid.DisplayLayout.Bands(0).Columns("AP").Width = 30
        grid.DisplayLayout.Bands(0).Columns("BLQ").Width = 30
        grid.DisplayLayout.Bands(0).Columns("RPRC").Width = 30
        grid.DisplayLayout.Bands(0).Columns("columnaModificada").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ClienteSAYID").Hidden = True
        If grid.DisplayLayout.Bands(0).Columns.Exists("F Captura") = True Then
            grid.DisplayLayout.Bands(0).Columns("F Captura").Hidden = True
        End If




        If Nivel <> 1 Then
            grid.DisplayLayout.Bands(0).Columns("PC").Hidden = True
        End If

        'If Nivel = 1 Then
        '    grid.DisplayLayout.Bands(0).Columns("Pedido Origen").Hidden = True
        'End If

        grid.DisplayLayout.Bands(0).Columns("PY").Width = 20
        grid.DisplayLayout.Bands(0).Columns("Completo").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("NoProyectable").Hidden = True

        If Nivel = 1 Or Nivel = 2 Or Nivel = 3 Then
            For Each Fila As UltraGridRow In grid.Rows

                If Nivel = 2 Then

                    If IsDBNull(Fila.Cells("EstuvoApartado").Value) = False Then
                        If Fila.Cells("EstuvoApartado").Value = True Then
                            Fila.Cells("AP").Appearance.ForeColor = Color.Red
                            Fila.Cells("AP").Appearance.FontData.Bold = DefaultableBoolean.True
                        End If
                    End If

                    If Fila.Cells("LC").Value = "SI" Then

                        If Fila.Cells("LoteCompleto").Value = "1" Then
                            Fila.Appearance.BackColor = Color.MediumSeaGreen
                        ElseIf Fila.Cells("INV").Value > 0 Then
                            Fila.Appearance.BackColor = Color.Empty
                        Else
                            Fila.Appearance.BackColor = Color.LightGray
                        End If

                        If Fila.Cells.Exists("F Entrega") = True Then
                            If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Entrega").Value) Then
                                Fila.Cells("F Entrega").Appearance.ForeColor = Color.Red
                            End If
                        End If

                        If Fila.Cells.Exists("F Prog") = True Then
                            If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Prog").Value) Then
                                Fila.Cells("F Prog").Appearance.ForeColor = Color.Red
                            End If
                        End If

                        If Fila.Cells.Exists("F Solicitada") = True Then
                            If Not IsDBNull(Fila.Cells("F Solicitada").Value) Then
                                If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Solicitada").Value) Then
                                    Fila.Cells("F Solicitada").Appearance.ForeColor = Color.Red
                                End If
                            End If
                        End If

                    Else
                        If Fila.Cells.Exists("Completo") = True Then
                            If Fila.Cells("Completo").Value = "1" Then
                                Fila.Appearance.BackColor = Color.MediumSeaGreen
                            End If
                        End If


                        'If Fila.Cells.Exists("Pedido Origen") = True Then
                        '    grid.DisplayLayout.Bands(0).Columns("Pedido Origen").Hidden = True
                        'End If

                        If Fila.Cells.Exists("F Entrega") = True Then
                            If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Entrega").Value) Then
                                Fila.Cells("F Entrega").Appearance.ForeColor = Color.Red
                            End If
                        End If

                        If Fila.Cells.Exists("F Prog") = True Then
                            If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Prog").Value) Then
                                Fila.Cells("F Prog").Appearance.ForeColor = Color.Red
                            End If
                        End If

                        If Fila.Cells.Exists("F Solicitada") = True Then
                            If Not IsDBNull(Fila.Cells("F Solicitada").Value) Then
                                If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Solicitada").Value) Then
                                    Fila.Cells("F Solicitada").Appearance.ForeColor = Color.Red
                                End If
                            End If
                        End If

                        If Fila.Cells.Exists("BE") = True Then
                            If Fila.Cells("BE").Value = "SI" Then
                                Fila.Appearance.BackColor = Color.LightGray
                            End If
                        End If

                        If Fila.Cells.Exists("P-0") = True Then

                            If Fila.Cells("P-0").Value = "SI" And Fila.Cells("FaltanCotizaciones").Value = "SI" Then
                                Fila.Appearance.BackColor = Color.LightGray
                            End If

                            If Fila.Cells("P-0").Value = "SI" And Fila.Cells("COT").Value = "0" Then
                                Fila.Appearance.BackColor = Color.LightGray
                            Else
                                If Fila.Cells("P-0").Value = "SI" And Fila.Cells("COT").Value > Fila.Cells("COT P").Value Then
                                    Fila.Appearance.BackColor = Color.LightGray
                                End If
                            End If

                        Else

                            If Fila.Cells.Exists("FaltanCotizaciones") = True Then

                                If Fila.Cells("FaltanCotizaciones").Value = 1 Then
                                    Fila.Appearance.BackColor = Color.LightGray
                                End If

                            End If
                        End If


                        If Fila.Cells.Exists("NoProyectable") = True Then
                            If Fila.Cells("NoProyectable").Value = 1 Then
                                Fila.Appearance.BackColor = Color.LightGray
                            End If

                        End If

                    End If

                Else
                    If Fila.Cells.Exists("Completo") = True Then
                        If Fila.Cells("Completo").Value = "1" Then
                            Fila.Appearance.BackColor = Color.MediumSeaGreen
                        End If
                    End If

                    'If Fila.Cells.Exists("Pedido Origen") = True Then
                    '    grid.DisplayLayout.Bands(0).Columns("Pedido Origen").Hidden = True
                    'End If

                    If Fila.Cells.Exists("F Entrega") = True Then
                        If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Entrega").Value) Then
                            Fila.Cells("F Entrega").Appearance.ForeColor = Color.Red
                        End If
                    End If

                    If Fila.Cells.Exists("F Prog") = True Then
                        If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Prog").Value) Then
                            Fila.Cells("F Prog").Appearance.ForeColor = Color.Red
                        End If
                    End If

                    If Fila.Cells.Exists("F Solicitada") = True Then
                        If Not IsDBNull(Fila.Cells("F Solicitada").Value) Then
                            If Date.Now.ToShortDateString() > CDate(Fila.Cells("F Solicitada").Value) Then
                                Fila.Cells("F Solicitada").Appearance.ForeColor = Color.Red
                            End If
                        End If
                    End If

                    If Fila.Cells.Exists("BE") = True Then
                        If Fila.Cells("BE").Value = "SI" Then
                            Fila.Appearance.BackColor = Color.LightGray
                        End If
                    End If

                    If Fila.Cells.Exists("P-0") = True Then

                        If Fila.Cells("P-0").Value = "SI" And Fila.Cells("FaltanCotizaciones").Value = "SI" Then
                            Fila.Appearance.BackColor = Color.LightGray
                        End If

                        If Fila.Cells("P-0").Value = "SI" And Fila.Cells("COT").Value = "0" Then
                            Fila.Appearance.BackColor = Color.LightGray
                        Else
                            If Fila.Cells("P-0").Value = "SI" And Fila.Cells("COT").Value > Fila.Cells("COT P").Value Then
                                Fila.Appearance.BackColor = Color.LightGray
                            End If
                        End If

                    Else

                        If Fila.Cells.Exists("FaltanCotizaciones") = True Then

                            If Fila.Cells("FaltanCotizaciones").Value = 1 Then
                                Fila.Appearance.BackColor = Color.LightGray
                            End If

                        End If
                    End If


                    If Fila.Cells.Exists("NoProyectable") = True Then
                        If Fila.Cells("NoProyectable").Value = 1 Then
                            Fila.Appearance.BackColor = Color.LightGray
                        End If

                    End If
                End If



            Next
        End If


        If Nivel = 1 Then
            grid.DisplayLayout.Bands(0).Columns("COT P").Width = 35
            grid.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 20
            grid.DisplayLayout.Bands(0).Columns("PC").Width = 30
            grid.DisplayLayout.Bands(0).Columns("Cliente").Width = 170
            grid.DisplayLayout.Bands(0).Columns("BE").Width = 25
            grid.DisplayLayout.Bands(0).Columns("P-0").Width = 25
            grid.DisplayLayout.Bands(0).Columns("COT").Width = 30
            grid.DisplayLayout.Bands(0).Columns("COT P").Width = 50
            grid.DisplayLayout.Bands(0).Columns("NoProyectable").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("FaltanCotizaciones").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("totalPartidasCompletas").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("inventarioPartidasCompletas").Hidden = True
            'grid.DisplayLayout.Bands(0).Columns("Pedido SAY").Width = 60
            'grid.DisplayLayout.Bands(0).Columns("Pedido SICY").Width = 63
            grid.DisplayLayout.Bands(0).Columns("F Entrega").Width = 60
            grid.DisplayLayout.Bands(0).Columns("F Captura").Width = 60
            grid.DisplayLayout.Bands(0).Columns("PC").Width = 20
            grid.DisplayLayout.Bands(0).Columns("Cantidad").Width = 45
            grid.DisplayLayout.Bands(0).Columns("Por Entregar").Width = 60
            grid.DisplayLayout.Bands(0).Columns("Proyectado").Width = 57
            grid.DisplayLayout.Bands(0).Columns("P Proyectar").Width = 55
            grid.DisplayLayout.Bands(0).Columns("INV").Width = 30
            grid.DisplayLayout.Bands(0).Columns("FAC").Width = 30
            grid.DisplayLayout.Bands(0).Columns("PRG").Width = 30
            grid.DisplayLayout.Bands(0).Columns("PRO").Width = 30
            grid.DisplayLayout.Bands(0).Columns("PRC").Width = 40
            grid.DisplayLayout.Bands(0).Columns("AP").Width = 30
            grid.DisplayLayout.Bands(0).Columns("BLQ").Width = 30
            grid.DisplayLayout.Bands(0).Columns("RPRC").Width = 30
            grid.DisplayLayout.Bands(0).Columns("COT P").Width = 35
            grid.DisplayLayout.Bands(0).Columns("LC").Width = 25
            grid.DisplayLayout.Bands(0).Columns("Estatus").Width = 75
            grid.DisplayLayout.Bands(0).Columns("Orden").Width = 90

            grid.DisplayLayout.Bands(0).Columns("F Entrega").Header.Caption = "F EntregaCte"

            If TipoPerfil = 3 Then

                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser <> 10433 And Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser <> 10606 Then
                    grid.DisplayLayout.Bands(0).Columns("PY").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("LC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Por Entregar").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Proyectado").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("A Proyectar").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("FAC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRG").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRO").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("AP").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("BLQ").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("RPRC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Completo").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("NoProyectable").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("FaltanCotizaciones").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("columnaModificada").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("ClienteSAYID").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("totalPartidasCompletas").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("inventarioPartidasCompletas").Hidden = True
                End If


            End If



            ElseIf Nivel = 2 Then
            grid.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 20
            grid.DisplayLayout.Bands(0).Columns("Descripción").Width = 270
            grid.DisplayLayout.Bands(0).Columns("COT").Width = 30
            grid.DisplayLayout.Bands(0).Columns("COT P").Width = 50
            If grid.DisplayLayout.Bands(0).Columns.Exists("Folio Apartado") = True Then
                grid.DisplayLayout.Bands(0).Columns("Folio Apartado").Width = 100
            End If

            grid.DisplayLayout.Bands(0).Columns("NoProyectable").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("FaltanCotizaciones").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Pedido SAY").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Pedido SICY").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Cantidad").Width = 45
            grid.DisplayLayout.Bands(0).Columns("Por Entregar").Width = 60
            grid.DisplayLayout.Bands(0).Columns("Proyectado").Width = 57
            grid.DisplayLayout.Bands(0).Columns("P Proyectar").Width = 55
            grid.DisplayLayout.Bands(0).Columns("F Entrega").Width = 60
            grid.DisplayLayout.Bands(0).Columns("F Captura").Width = 60
            grid.DisplayLayout.Bands(0).Columns("Partida").Width = 35
            grid.DisplayLayout.Bands(0).Columns("LC").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("LoteCliente").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("LoteCompleto").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("COT").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("COT P").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("EstuvoApartado").Hidden = True

            grid.DisplayLayout.Bands(0).Columns("F Entrega").Header.Caption = "F EntregaCte"

            If TipoPerfil = 3 Then

                grid.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True
                grid.DisplayLayout.Bands(0).Columns("PY").Hidden = True
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY_SOLO_CONSULTA", "VENT_PROYECCION_FECHAS") Then
                    grid.DisplayLayout.Bands(0).Columns("F Prog").Hidden = False
                    grid.DisplayLayout.Bands(0).Columns("F Entrega").Hidden = False
                    grid.DisplayLayout.Bands(0).Columns("F Solicitada").Hidden = False
                Else
                    grid.DisplayLayout.Bands(0).Columns("F Prog").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("F Entrega").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("F Solicitada").Hidden = True
                End If

                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser <> 10433 And Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser <> 10606 Then

                    grid.DisplayLayout.Bands(0).Columns("F Captura").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Tipo Numeración").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Por Entregar").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Proyectado").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("A Proyectar").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRG").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRO").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PRC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("BLQ").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("RPRC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("COT").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("COT P").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Pedido SAY").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Pedido SICY").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("Completo").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("NoProyectable").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("FaltanCotizaciones").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("PC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("LC").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("LoteCliente").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("columnaModificada").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("ClienteSAYID").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("LoteCompleto").Hidden = True
                    grid.DisplayLayout.Bands(0).Columns("EstuvoApartado").Hidden = True

                End If

                If grid.DisplayLayout.Bands(0).Columns.Exists("Observaciones") = True Then
                        grid.DisplayLayout.Bands(0).Columns("Observaciones").Hidden = True
                    End If



                End If


            ElseIf Nivel = 3 Then
            grid.DisplayLayout.Bands(0).Columns("pdpr_pedidosicy").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 20
            grid.DisplayLayout.Bands(0).Columns("pdpr_partida").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Lote").Width = 30
            grid.DisplayLayout.Bands(0).Columns("Año").Width = 30
            grid.DisplayLayout.Bands(0).Columns("NaveId").Hidden = True

            Dim FilaActiva = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.IsActiveRow = True)

            If FilaActiva.Appearance.BackColor = Color.LightGray Then
                For Each fila As UltraGridRow In grdNivelLotes.Rows
                    fila.Appearance.BackColor = Color.LightGray
                Next

            End If

        ElseIf Nivel = 4 Then
            grid.DisplayLayout.Bands(0).Columns("pdpr_lote").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_añolote").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_naveidsicy").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_pedidosicy").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_partida").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 20
            grid.DisplayLayout.Bands(0).Columns("Atado").Width = 80
            grid.DisplayLayout.Bands(0).Columns("Cantidad").Width = 50
            grid.DisplayLayout.Bands(0).Columns("Por Entregar").Width = 60
            grid.DisplayLayout.Bands(0).Columns("Proyectado").Width = 57
            grid.DisplayLayout.Bands(0).Columns("P Proyectar").Width = 55


            Dim FilaActiva = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.IsActiveRow = True)

            If FilaActiva.Appearance.BackColor = Color.LightGray Then
                For Each fila As UltraGridRow In grdNivelAtados.Rows
                    fila.Appearance.BackColor = Color.LightGray
                Next

            End If


        ElseIf Nivel = 5 Then
            grid.DisplayLayout.Bands(0).Columns("Atado").Width = 70
            grid.DisplayLayout.Bands(0).Columns("Par").Width = 70
            grid.DisplayLayout.Bands(0).Columns("Talla").Width = 30

            grid.DisplayLayout.Bands(0).Columns("pdpr_pedidosicy").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_partida").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_lote").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_añolote").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_naveidsicy").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("pdpr_codigoatado").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("LC").Hidden = True

            Dim FilaActiva = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.IsActiveRow = True)

            If FilaActiva.Appearance.BackColor = Color.LightGray Then
                For Each fila As UltraGridRow In grdNivelPares.Rows
                    fila.Appearance.BackColor = Color.LightGray
                Next

            End If
        End If


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, True)
        grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        'Centra la columna "Tipo"
        grid.DisplayLayout.Bands(0).Columns(4).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center


    End Sub


    Private Sub LimpiarGrid(ByVal Nivel As Integer)

        If Nivel = 1 Then
            grdNivelPartida.DataSource = Nothing
            grdNivelLotes.DataSource = Nothing
            grdNivelAtados.DataSource = Nothing
            grdNivelPares.DataSource = Nothing
        ElseIf Nivel = 2 Then
            grdNivelLotes.DataSource = Nothing
            grdNivelAtados.DataSource = Nothing
            grdNivelPares.DataSource = Nothing
        ElseIf Nivel = 3 Then
            grdNivelAtados.DataSource = Nothing
            grdNivelPares.DataSource = Nothing
        ElseIf Nivel = 4 Then
            grdNivelPares.DataSource = Nothing
        End If

    End Sub

    Private Sub grdNivelPares_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelPares.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPares.ActiveRow) = False Then
            If grdNivelPares.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPares.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 5)
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelPares_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNivelPares.ClickCell
        Try
            If grdNivelPares.ActiveRow.IsFilterRow = False And e.Cell.Row.Index >= 0 Then
                Cursor = Cursors.WaitCursor
                If e.Cell.Column.Key = "Seleccionar" Then
                    If CBool(e.Cell.Value) = True Then
                        e.Cell.Value = False
                    Else
                        e.Cell.Value = True
                        Dim filasActivas = grdNivelPares.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                        If filasActivas.Count > 0 Then
                            GuardarProyeccion(Nothing, 5)
                        End If
                    End If
                End If


                If e.Cell.Column.Key = "PY" And e.Cell.Row.Appearance.BackColor <> Color.LightGray And e.Cell.Row.Cells("INV").Value > 0 And e.Cell.Row.Cells("ClienteSAYID").Value <> "816" Then
                    e.Cell.Row.Cells("columnaModificada").Value = 1
                    If CBool(e.Cell.Value) = False Then
                        MarcarProyeccion(grdNivelPares, 5, False, 5)
                    Else
                        MarcarProyeccion(grdNivelPares, 5, True, 5)
                    End If
                    ActualizarGrid(5)
                End If
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub grdNivelLotes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdNivelLotes.DoubleClickCell
        Dim FilasMarcadas = grdNivelLotes.Rows.Where(Function(x) x.Cells("Seleccionar").Value = True)
        For Each fila As UltraGridRow In FilasMarcadas
            fila.Cells("Seleccionar").Value = 0
        Next
        Dim FilasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Selected Or x.Activated)
        For Each fila As UltraGridRow In FilasSeleccionadas
            fila.Cells("Seleccionar").Value = 1
        Next
        btnNivelSiguiente_Click(sender, e)
    End Sub

    Private Sub grdNivelLotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdNivelLotes.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            Dim FilasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Cells("Seleccionar").Text = 1)

            For Each fila As UltraGridRow In FilasSeleccionadas
                fila.Cells("Seleccionar").Value = True
            Next
            Dim filasActivas = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
            If filasActivas.Count > 0 Then
                GuardarProyeccion(filasActivas, 3)
            End If
            btnNivelAnterior_Click(sender, e)
        End If
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim FilasMarcadas = grdNivelLotes.Rows.Where(Function(x) x.Cells("Seleccionar").Text = 1)
            For Each fila As UltraGridRow In FilasMarcadas
                fila.Cells("Seleccionar").Value = False
            Next
            Dim FilasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Selected Or x.Activated)
            For Each fila As UltraGridRow In FilasSeleccionadas
                fila.Cells("Seleccionar").Value = True
            Next

            Dim filasActivas = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
            If filasActivas.Count > 0 Then
                GuardarProyeccion(filasActivas, 3)
            End If

            btnNivelSiguiente_Click(sender, e)
        End If
    End Sub

    Private Sub grdNivelAtados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdNivelAtados.DoubleClickCell

        Dim FilasMarcadas = grdNivelAtados.Rows.Where(Function(x) x.Cells("Seleccionar").Value = True)
        For Each fila As UltraGridRow In FilasMarcadas
            fila.Cells("Seleccionar").Value = 0
        Next
        Dim FilasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Selected Or x.Activated)

        For Each fila As UltraGridRow In FilasSeleccionadas
            fila.Cells("Seleccionar").Value = 1
        Next
        btnNivelSiguiente_Click(sender, e)

        gridSumatoria.Visible = False
    End Sub

    Private Sub grdNivelAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdNivelAtados.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            Dim FilasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Cells("Seleccionar").Text = 1)

            For Each fila As UltraGridRow In FilasSeleccionadas
                fila.Cells("Seleccionar").Value = False
            Next
            Dim filasActivas = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
            If filasActivas.Count > 0 Then
                GuardarProyeccion(filasActivas, 4)
            End If

            btnNivelAnterior_Click(sender, e)
        End If
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim FilasMarcadas = grdNivelAtados.Rows.Where(Function(x) x.Cells("Seleccionar").Text = 1)
            For Each fila As UltraGridRow In FilasMarcadas
                fila.Cells("Seleccionar").Value = False
            Next
            Dim FilasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Selected Or x.Activated)

            For Each fila As UltraGridRow In FilasSeleccionadas
                fila.Cells("Seleccionar").Value = True
            Next
            Dim filasActivas = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
            If filasActivas.Count > 0 Then
                GuardarProyeccion(filasActivas, 4)
            End If
            btnNivelSiguiente_Click(sender, e)
        End If
    End Sub

    Private Sub grdNivelPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdNivelPares.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            btnNivelAnterior_Click(sender, e)
        End If
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnNivelSiguiente_Click(sender, e)
        End If
    End Sub

    Private Sub grdNivelPedido_LostFocus(sender As Object, e As EventArgs) Handles grdNivelPedido.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPedido.ActiveRow) = False Then
            If grdNivelPedido.ActiveRow.IsFilterRow = False Then
                Try

                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPedido.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(filasActivas, 1)
                    End If


                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelPedido_MouseClick(sender As Object, e As MouseEventArgs) Handles grdNivelPedido.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listaRenglonesSeleccionados = New List(Of Integer)
            Dim totalRenglonesMarcados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0
            'Dim filasSeleccionadas = grdNivelPedido.Rows.Where(Function(x) x.Selected = True And x.Appearance.BackColor = Color.MediumSeaGreen And CBool(x.Cells("PY").Value) = False)
            Dim filasSeleccionadas = grdNivelPedido.Rows.Where(Function(x) x.Selected = True And (x.Appearance.BackColor = Color.MediumSeaGreen Or (x.Cells("LC").Value = "SI" And (x.Appearance.BackColor = Color.MediumSeaGreen Or x.Appearance.BackColor = Color.Empty)) Or (x.Cells("PC").Value = "SI" And x.Cells("totalPartidasCompletas").Value > 0 And x.Appearance.BackColor = Color.Empty) Or (x.Appearance.BackColor = Color.Empty And x.Cells("PC").Value = "NO" And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816") Or (x.Cells("ClienteSAYID").Value = "816" And (x.Cells("INV").Value + x.Cells("PRC").Value = x.Cells("Por Entregar").Value))))

            For Each Filas As UltraGridRow In filasSeleccionadas
                If CBool(Filas.Cells("PY").Value) = True Then
                    totalRenglonesMarcados += 1
                End If
            Next

            If filasSeleccionadas.Count > 0 Then

                If totalRenglonesMarcados = filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                ElseIf totalRenglonesMarcados = 0 Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf totalRenglonesMarcados > 0 And totalRenglonesMarcados < filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                gridSeleccionadoClicDerecho = grdNivelPedido
                cmsSeleccionMultiple.Show(Control.MousePosition)
            Else
                cmsSeleccionMultiple.Items(0).Visible = False
                cmsSeleccionMultiple.Items(1).Visible = False

            End If



        End If
    End Sub

    Private Sub grdNivelPartida_LostFocus(sender As Object, e As EventArgs) Handles grdNivelPartida.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPartida.ActiveRow) = False Then
            If grdNivelPartida.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPartida.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 2)
                    End If

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelPartida_MouseClick(sender As Object, e As MouseEventArgs) Handles grdNivelPartida.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            listaRenglonesSeleccionados = New List(Of Integer)
            Dim totalRenglonesMarcados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0

            'Dim filasSeleccionadas = grdNivelPartida.Rows.Where(Function(x) x.Selected = True And x.Appearance.BackColor = Color.MediumSeaGreen And CBool(x.Cells("PY").Value) = False)
            Dim filasSeleccionadas = grdNivelPartida.Rows.Where(Function(x) x.Selected = True And (x.Appearance.BackColor = Color.MediumSeaGreen Or (x.Appearance.BackColor = Color.Empty And x.Cells("PC").Value = "NO" And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816")))

            For Each Filas As UltraGridRow In filasSeleccionadas
                If CBool(Filas.Cells("PY").Value) = True Then
                    totalRenglonesMarcados += 1
                End If
            Next

            If filasSeleccionadas.Count > 0 Then
                If totalRenglonesMarcados = filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                ElseIf totalRenglonesMarcados = 0 Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf totalRenglonesMarcados > 0 And totalRenglonesMarcados < filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                gridSeleccionadoClicDerecho = grdNivelPartida
                cmsSeleccionMultiple.Show(Control.MousePosition)
            Else
                cmsSeleccionMultiple.Items(0).Visible = False
                cmsSeleccionMultiple.Items(1).Visible = False
            End If

        End If

    End Sub

    Private Sub grdNivelLotes_LostFocus(sender As Object, e As EventArgs) Handles grdNivelLotes.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelLotes.ActiveRow) = False Then
            If grdNivelLotes.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 3)
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelLotes_MouseClick(sender As Object, e As MouseEventArgs) Handles grdNivelLotes.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listaRenglonesSeleccionados = New List(Of Integer)
            Dim totalRenglonesMarcados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0

            Dim filasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Selected = True And (x.Appearance.BackColor = Color.MediumSeaGreen Or (x.Appearance.BackColor = Color.Empty And x.Cells("PC").Value = "NO" And x.Cells("INV").Value > 0) And x.Cells("ClienteSAYID").Value <> "816"))
            'Dim filasSeleccionadas = grdNivelLotes.Rows.Where(Function(x) x.Selected = True And x.Appearance.BackColor = Color.MediumSeaGreen And CBool(x.Cells("PY").Value) = False)

            For Each Filas As UltraGridRow In filasSeleccionadas
                If CBool(Filas.Cells("PY").Value) = True Then
                    totalRenglonesMarcados += 1
                End If
            Next

            If filasSeleccionadas.Count > 0 Then
                If totalRenglonesMarcados = filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                ElseIf totalRenglonesMarcados = 0 Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf totalRenglonesMarcados > 0 And totalRenglonesMarcados < filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                gridSeleccionadoClicDerecho = grdNivelLotes
                cmsSeleccionMultiple.Show(Control.MousePosition)
            Else
                cmsSeleccionMultiple.Items(0).Visible = False
                cmsSeleccionMultiple.Items(1).Visible = False
            End If


        End If
    End Sub

    Private Sub grdNivelAtados_LostFocus(sender As Object, e As EventArgs) Handles grdNivelAtados.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelAtados.ActiveRow) = False Then
            If grdNivelAtados.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 3)
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelAtados_MouseClick(sender As Object, e As MouseEventArgs) Handles grdNivelAtados.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listaRenglonesSeleccionados = New List(Of Integer)
            Dim totalRenglonesMarcados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0

            'Dim filasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = False)
            Dim filasSeleccionadas = grdNivelAtados.Rows.Where(Function(x) x.Selected = True And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816")

            For Each Filas As UltraGridRow In filasSeleccionadas
                If CBool(Filas.Cells("PY").Value) = True Then
                    totalRenglonesMarcados += 1
                End If
            Next

            If filasSeleccionadas.Count > 0 Then
                If totalRenglonesMarcados = filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                ElseIf totalRenglonesMarcados = 0 Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf totalRenglonesMarcados > 0 And totalRenglonesMarcados < filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                gridSeleccionadoClicDerecho = grdNivelAtados
                cmsSeleccionMultiple.Show(Control.MousePosition)
            Else
                cmsSeleccionMultiple.Items(0).Visible = False
                cmsSeleccionMultiple.Items(1).Visible = False
            End If

        End If

    End Sub

    Private Sub grdNivelPares_LostFocus(sender As Object, e As EventArgs) Handles grdNivelPares.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If IsNothing(grdNivelPares.ActiveRow) = False Then
            If grdNivelPares.ActiveRow.IsFilterRow = False Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim filasActivas = grdNivelPares.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)
                    If filasActivas.Count > 0 Then
                        GuardarProyeccion(Nothing, 5)
                    End If


                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If

        End If
    End Sub

    Private Sub grdNivelPares_MouseClick(sender As Object, e As MouseEventArgs) Handles grdNivelPares.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listaRenglonesSeleccionados = New List(Of Integer)
            Dim totalRenglonesMarcados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0

            'Dim filasSeleccionadas = grdNivelPares.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = False)
            Dim filasSeleccionadas = grdNivelPares.Rows.Where(Function(x) x.Selected = True And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816")

            For Each Filas As UltraGridRow In filasSeleccionadas
                If CBool(Filas.Cells("PY").Value) = True Then
                    totalRenglonesMarcados += 1
                End If
            Next

            If filasSeleccionadas.Count > 0 Then
                If totalRenglonesMarcados = filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                ElseIf totalRenglonesMarcados = 0 Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf totalRenglonesMarcados > 0 And totalRenglonesMarcados < filasSeleccionadas.Count() Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                gridSeleccionadoClicDerecho = grdNivelPares
                cmsSeleccionMultiple.Show(Control.MousePosition)
            Else
                cmsSeleccionMultiple.Items(0).Visible = False
                cmsSeleccionMultiple.Items(1).Visible = False
            End If

        End If

    End Sub


    Private Sub SeleccionarHijos(ByVal Lista As IEnumerable(Of UltraGridRow), ByVal Grid As UltraGrid, ByVal Nivel As Integer, ByVal EstaMarcada As Boolean)


        If Nivel = 1 Then
            For Each Filas As UltraGridRow In Lista
                Dim Seleccion = Grid.Rows.Where(Function(x) x.Cells("Pedido SICY").Value = Filas.Cells("Pedido SICY").Value)
                For Each FilaPartida As UltraGridRow In Seleccion
                    FilaPartida.Selected = True
                Next
            Next
        ElseIf Nivel = 2 Then
            For Each Filas As UltraGridRow In Lista
                Dim Seleccion = Grid.Rows.Where(Function(x) x.Cells("pdpr_pedidosicy").Value = Filas.Cells("Pedido SICY").Value)
                For Each FilaPartida As UltraGridRow In Seleccion
                    FilaPartida.Selected = True
                Next
            Next

        ElseIf Nivel = 3 Then

            For Each Filas As UltraGridRow In Lista
                Dim Seleccion = Grid.Rows.Where(Function(x) x.Cells("pdpr_pedidosicy").Value = Filas.Cells("pdpr_pedidosicy").Value And x.Cells("pdpr_lote").Value = Filas.Cells("Lote").Value And x.Cells("pdpr_partida").Value = Filas.Cells("pdpr_partida").Value)
                For Each FilaPartida As UltraGridRow In Seleccion
                    FilaPartida.Selected = True
                Next
            Next

        ElseIf Nivel = 4 Then

            For Each Filas As UltraGridRow In Lista
                Dim Seleccion = Grid.Rows.Where(Function(x) x.Cells("pdpr_codigoatado").Value = Filas.Cells("Atado").Value)
                For Each FilaPartida As UltraGridRow In Seleccion
                    FilaPartida.Selected = True
                Next
            Next

        End If
    End Sub

    Private Sub MarcarProyeccionLotesCompletos(ByVal Nivel As Integer, ByVal EstaMarcada As Boolean)

        Dim FilasSeleccionadasCompletas As IEnumerable(Of UltraGridRow)
        Dim dtInformacionLotes As New DataTable
        Dim objBU As New Ventas.Negocios.ProyeccionEntregasBU

        Try
            If Nivel = 1 Then
                FilasSeleccionadasCompletas = grdNivelPedido.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = EstaMarcada And x.Cells("LC").Value = "SI" And x.Cells("INV").Value > 0)

                For Each Fila As UltraGridRow In FilasSeleccionadasCompletas
                    If EstaMarcada = False Then
                        dtInformacionLotes = objBU.ProyectarLotesCompletos(Fila.Cells("Pedido SICY").Value, 1)
                    Else
                        dtInformacionLotes = objBU.ProyectarLotesCompletos(Fila.Cells("Pedido SICY").Value, 0)
                    End If

                    If dtInformacionLotes.Rows.Count() > 0 Then

                        If EstaMarcada = False Then
                            Fila.Cells("A Proyectar").Value = dtInformacionLotes.Rows(0).Item("ParesMarcadosPedido")
                            Fila.Cells("PY").Value = True
                        Else
                            Fila.Cells("A Proyectar").Value = 0
                            Fila.Cells("PY").Value = False
                        End If

                        'Partidas
                        Dim ListaPartidas = grdNivelPartida.Rows.Where(Function(X) X.Cells("Pedido SICY").Value = Fila.Cells("Pedido SICY").Value)

                        If ListaPartidas.Count > 0 Then
                            For Each FilaPartidaC As DataRow In dtInformacionLotes.Rows

                                Dim ListaPartidasLotesCompletos = grdNivelPartida.Rows.Where(Function(x) x.Cells("LoteCliente").Value = FilaPartidaC.Item("pdip_numlotecliente").ToString())

                                For Each FilaPartidaLoteCompleto As UltraGridRow In ListaPartidasLotesCompletos
                                    If EstaMarcada = False Then
                                        FilaPartidaLoteCompleto.Cells("A Proyectar").Value = FilaPartidaLoteCompleto.Cells("INV").Value
                                        FilaPartidaLoteCompleto.Cells("PY").Value = True
                                    Else
                                        FilaPartidaLoteCompleto.Cells("A Proyectar").Value = 0
                                        FilaPartidaLoteCompleto.Cells("PY").Value = False
                                    End If
                                Next
                            Next


                            If grdNivelPares.Rows.Count > 0 Then

                                Dim ListaParesCompletos = grdNivelPares.Rows.Where(Function(x) x.Cells("pdpr_pedidosicy").Value = lblPedidoSICYNivelPartidas.Text And x.Cells("pdpr_partida").Value = lblPartidaNivelLotes.Text)

                                For Each Elemento As UltraGridRow In ListaParesCompletos
                                    If EstaMarcada = False Then
                                        Elemento.Cells("A Proyectar").Value = Elemento.Cells("INV").Value
                                        Elemento.Cells("PY").Value = True
                                    Else
                                        Elemento.Cells("PY").Value = False
                                    End If

                                Next
                            End If

                            If grdNivelAtados.Rows.Count > 0 Then
                                Dim ListaParesCompletos = grdNivelAtados.Rows.Where(Function(x) x.Cells("pdpr_pedidosicy").Value = lblPedidoSICYNivelPartidas.Text And x.Cells("pdpr_partida").Value = lblPartidaNivelLotes.Text)

                                For Each Elemento As UltraGridRow In ListaParesCompletos
                                    If EstaMarcada = False Then
                                        Elemento.Cells("A Proyectar").Value = Elemento.Cells("INV").Value
                                        Elemento.Cells("PY").Value = True
                                    Else
                                        Elemento.Cells("PY").Value = False
                                    End If

                                Next
                            End If

                            If grdNivelLotes.Rows.Count > 0 Then
                                Dim ListaParesCompletos = grdNivelLotes.Rows.Where(Function(x) x.Cells("pdpr_pedidosicy").Value = lblPedidoSICYNivelPartidas.Text And x.Cells("pdpr_partida").Value = lblPartidaNivelLotes.Text)

                                For Each Elemento As UltraGridRow In ListaParesCompletos
                                    If EstaMarcada = False Then
                                        Elemento.Cells("A Proyectar").Value = Elemento.Cells("INV").Value
                                        Elemento.Cells("PY").Value = True
                                    Else
                                        Elemento.Cells("PY").Value = False
                                    End If

                                Next
                            End If

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub


    Private Sub MarcarProyeccion(ByVal Grid As UltraGrid, ByVal Nivel As Integer, ByVal EstaMarcada As Boolean, ByVal NivelInicio As Integer)

        '-------Nivel de Inicio es el Nivel en el que se dio clic a la casila de PY

        Dim TieneFilasSel As Boolean = False
        Dim TieneFilasSelInc As Boolean = False
        Dim FilasSeleccionadasInCompletas As IEnumerable(Of UltraGridRow)
        Dim FilasSeleccionadasCompletas As IEnumerable(Of UltraGridRow)

        Try

            If Nivel = 1 Then
                FilasSeleccionadasCompletas = Grid.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = EstaMarcada And x.Cells("LC").Value = "NO" And (x.Appearance.BackColor = Color.MediumSeaGreen Or (x.Cells("PC").Value = "SI" And x.Appearance.BackColor = Color.Empty And x.Cells("totalPartidasCompletas").Value > 0)))
            Else
                FilasSeleccionadasCompletas = Grid.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = EstaMarcada And x.Appearance.BackColor = Color.MediumSeaGreen)
            End If

            'Dim FilasSeleccionadasInCompletas = Grid.Rows.Where(Function(x) x.Selected = True And x.Cells("PC").Value = "NO" And CBool(x.Cells("PY").Value) = EstaMarcada And x.Appearance.BackColor <> Color.LightGray)

            FilasSeleccionadasInCompletas = Grid.Rows.Where(Function(x) x.Selected = True And (x.Cells("PC").Value = "NO" Or x.Cells("ClienteSAYID").Value = "816") And CBool(x.Cells("PY").Value) = EstaMarcada And ((x.Appearance.BackColor = Color.Empty And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816") Or (x.Cells("ClienteSAYID").Value = "816" And (x.Cells("INV").Value + x.Cells("PRC").Value) = x.Cells("Por Entregar").Value)))

            'If Nivel = 1 Then
            '    FilasSeleccionadasInCompletas = Grid.Rows.Where(Function(x) x.Selected = True And (x.Cells("PC").Value = "NO" Or x.Cells("ClienteSAYID").Value = "816") And CBool(x.Cells("PY").Value) = EstaMarcada And ((x.Appearance.BackColor = Color.Empty And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816") Or (x.Cells("ClienteSAYID").Value = "816" And (x.Cells("INV").Value + x.Cells("PRC").Value) = x.Cells("Por Entregar").Value)))
            'Else
            '    FilasSeleccionadasInCompletas = Grid.Rows.Where(Function(x) x.Selected = True And x.Cells("PC").Value = "NO" And CBool(x.Cells("PY").Value) = EstaMarcada And ((x.Appearance.BackColor = Color.Empty And x.Cells("INV").Value > 0 And x.Cells("ClienteSAYID").Value <> "816")))
            'End If


            'Dim FilasSeleccionada = Grid.Rows.Where(Function(x) x.Selected = True And x.Cells("PY").Text = EstaMarcada And x.Cells("INV").Value > "0" And x.Cells("PC").Value = "SI")
            Dim FilasSeleccionadaInc = Grid.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = EstaMarcada And x.Cells("INV").Value > "0" And x.Cells("PC").Value = "NO")
            Dim FilasSeleccionadaconInventario = Grid.Rows.Where(Function(x) x.Selected = True And CBool(x.Cells("PY").Value) = EstaMarcada And ((x.Cells("INV").Value > "0" And x.Cells("ClienteSAYID").Value <> "816") Or (x.Cells("ClienteSAYID").Value = "816" And x.Cells("INV").Value + x.Cells("PRC").Value = x.Cells("Por Entregar").Value)))


            'Del Nivel superior al inferior
            If Nivel = 1 Then
                If IsNothing(grdNivelPartida.DataSource) = False Then
                    SeleccionarHijos(FilasSeleccionadasCompletas, grdNivelPartida, 1, EstaMarcada)
                    SeleccionarHijos(FilasSeleccionadasInCompletas, grdNivelPartida, 1, EstaMarcada)
                    If FilasSeleccionadasCompletas.Count > 0 Or FilasSeleccionadasInCompletas.Count > 0 Then
                        MarcarProyeccion(grdNivelPartida, 2, EstaMarcada, -1)
                    End If
                End If

            ElseIf Nivel = 2 Then
                If IsNothing(grdNivelLotes.DataSource) = False Then
                    SeleccionarHijos(FilasSeleccionadasCompletas, grdNivelLotes, 2, EstaMarcada)
                    SeleccionarHijos(FilasSeleccionadasInCompletas, grdNivelLotes, 2, EstaMarcada)
                    If FilasSeleccionadasCompletas.Count > 0 Or FilasSeleccionadasInCompletas.Count > 0 Then
                        MarcarProyeccion(grdNivelLotes, 3, EstaMarcada, -1)
                    End If
                End If

            ElseIf Nivel = 3 Then
                If IsNothing(grdNivelAtados.DataSource) = False Then
                    SeleccionarHijos(FilasSeleccionadaconInventario, grdNivelAtados, 3, EstaMarcada)
                    'SeleccionarHijos(FilasSeleccionadasInCompletas, grdNivelAtados, 3, EstaMarcada)
                    If FilasSeleccionadasCompletas.Count > 0 Or FilasSeleccionadasInCompletas.Count > 0 Or FilasSeleccionadaconInventario.Count > 0 Then
                        MarcarProyeccion(grdNivelAtados, 4, EstaMarcada, -1)
                    End If
                End If
            ElseIf Nivel = 4 Then
                If IsNothing(grdNivelPares.DataSource) = False Then
                    SeleccionarHijos(FilasSeleccionadaconInventario, grdNivelPares, 4, EstaMarcada)
                    If FilasSeleccionadasCompletas.Count > 0 Or FilasSeleccionadasInCompletas.Count > 0 Or FilasSeleccionadaconInventario.Count > 0 Then
                        MarcarProyeccion(grdNivelPares, 5, EstaMarcada, -1)
                    End If
                End If
            End If

            If Nivel = 1 Or Nivel = 2 Or Nivel = 3 Then
                For Each Filas As UltraGridRow In FilasSeleccionadasCompletas

                    If EstaMarcada = True Then
                        Filas.Cells("PY").Value = False
                    Else
                        Filas.Cells("PY").Value = True
                    End If

                Next

                For Each Filas As UltraGridRow In FilasSeleccionadasInCompletas
                    If EstaMarcada = True Then
                        Filas.Cells("PY").Value = False
                    Else
                        Filas.Cells("PY").Value = True
                    End If
                Next
            Else
                If NivelInicio > 0 Then 'Si se selecciono desde este nivel, solo se pueden marcar las casillas que tengan la validacion de partidas incompletas
                    For Each Fila As UltraGridRow In FilasSeleccionadaconInventario
                        If EstaMarcada = True Then
                            Fila.Cells("PY").Value = False
                        Else
                            Fila.Cells("PY").Value = True
                        End If
                    Next
                Else
                    For Each Fila As UltraGridRow In FilasSeleccionadaconInventario
                        If EstaMarcada = True Then
                            Fila.Cells("PY").Value = False
                        Else
                            Fila.Cells("PY").Value = True
                        End If
                    Next
                End If
            End If

            'MarcarNivelesSuperiores(NivelInicio)

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub MarcarNivelesSuperiores(ByVal Nivel As Integer)

        Try
            'Del Nivel inferior al superior
            If Nivel = 2 Then
                'Mientras este marcada una casilla de PY poner a true la casilla del encabezado
                Dim FilasPartidasSeleccionadas = grdNivelPartida.Rows.Where(Function(x) CBool(x.Cells("PY").Value) = True)
                Dim FilasPedidosSeleccionadasCompletas = grdNivelPedido.Rows.Where(Function(x) x.Cells("Pedido SICY").Value = lblPedidoSICYNivelPartidas.Text.Trim())

                For Each Fila As UltraGridRow In FilasPedidosSeleccionadasCompletas
                    If FilasPartidasSeleccionadas.Count > 0 Then
                        Fila.Cells("PY").Value = True
                    Else
                        Fila.Cells("PY").Value = False
                    End If
                Next

            ElseIf Nivel = 3 Then

                Dim FilasLoteSeleccionadas = grdNivelLotes.Rows.Where(Function(x) CBool(x.Cells("PY").Value) = True)
                Dim FilasPartidaSeleccionadasCompletas = grdNivelPartida.Rows.Where(Function(x) x.Cells("Pedido SICY").Value = lblPedidoSICYNivelPartidas.Text.Trim() And x.Cells("Partida").Value = lblPartidaNivelLotes.Text.Trim())

                For Each Fila As UltraGridRow In FilasPartidaSeleccionadasCompletas
                    If FilasLoteSeleccionadas.Count > 0 Then
                        Fila.Cells("PY").Value = True
                    Else
                        Fila.Cells("PY").Value = False
                    End If
                Next

            ElseIf Nivel = 4 Then
                Dim FilasLoteSeleccionadas = grdNivelAtados.Rows.Where(Function(x) CBool(x.Cells("PY").Value) = True)
                Dim FilasPartidaSeleccionadasCompletas = grdNivelLotes.Rows.Where(Function(x) x.Cells("Lote").Value = lblLoteNivelAtados.Text.Trim() And x.Cells("Año").Value = lblAñoNivelAtados.Text.Trim())

                For Each Fila As UltraGridRow In FilasPartidaSeleccionadasCompletas
                    If FilasLoteSeleccionadas.Count > 0 Then
                        Fila.Cells("PY").Value = True
                    Else
                        Fila.Cells("PY").Value = False
                    End If
                Next

            ElseIf Nivel = 5 Then
                Dim FilasLoteSeleccionadas = grdNivelPares.Rows.Where(Function(x) CBool(x.Cells("PY").Value) = True)
                Dim FilasPartidaSeleccionadasCompletas = grdNivelAtados.Rows.Where(Function(x) x.Cells("Atado").Value = lblCodigoAtado.Text.Trim())

                For Each Fila As UltraGridRow In FilasPartidaSeleccionadasCompletas
                    If FilasLoteSeleccionadas.Count > 0 Then
                        Fila.Cells("PY").Value = True
                    Else
                        Fila.Cells("PY").Value = False
                    End If
                Next

            End If

            If Nivel > 1 Then
                Nivel = Nivel - 1
                MarcarNivelesSuperiores(Nivel)
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub GuardarProyeccion(ByVal Filas As IEnumerable(Of UltraGridRow), ByVal NivelSeleccion As Integer)
        Dim objProyeccionBU As New Ventas.Negocios.ProyeccionEntregasBU
        Dim PedidoSICY As Integer = 0
        Dim Partida As Integer = 0
        Dim Lote As Integer = 0
        Dim AñoLote As Integer = 0
        Dim NaveSicy As Integer = 0
        Dim Atado As String = String.Empty
        Dim Par As String = String.Empty

        If NivelSeleccion = 1 Then
            For Each FilaModificada As UltraGridRow In Filas
                PedidoSICY = FilaModificada.Cells("Pedido SICY").Value

                If CBool(FilaModificada.Cells("PY").Value) = True Then
                    objProyeccionBU.GuardarProyeccion(1, PedidoSICY, "0", "0", "0", "0", "0", "0", "1")
                Else
                    objProyeccionBU.GuardarProyeccion(1, PedidoSICY, "0", "0", "0", "0", "0", "0", "0")
                End If


                FilaModificada.Cells("columnaModificada").Value = 0
            Next

        ElseIf NivelSeleccion = 2 Then
            Dim filaSeleccionada = grdNivelPartida.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each FilaModificada As UltraGridRow In filaSeleccionada
                PedidoSICY = FilaModificada.Cells("Pedido SICY").Value
                Partida = FilaModificada.Cells("Partida").Value
                If CBool(FilaModificada.Cells("PY").Value) = True Then
                    objProyeccionBU.GuardarProyeccion(2, PedidoSICY, Partida, "0", "0", "0", "0", "0", "1")
                Else
                    objProyeccionBU.GuardarProyeccion(2, PedidoSICY, Partida, "0", "0", "0", "0", "0", "0")
                End If

                FilaModificada.Cells("columnaModificada").Value = 0
            Next

        ElseIf NivelSeleccion = 3 Then
            Dim filaSeleccionada = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each FilaModificada As UltraGridRow In filaSeleccionada
                PedidoSICY = FilaModificada.Cells("pdpr_pedidosicy").Value
                Partida = FilaModificada.Cells("pdpr_partida").Value
                Lote = FilaModificada.Cells("Lote").Value
                AñoLote = FilaModificada.Cells("Año").Value
                NaveSicy = FilaModificada.Cells("NaveId").Value

                If CBool(FilaModificada.Cells("PY").Value) = True Then
                    objProyeccionBU.GuardarProyeccion(3, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, "0", "0", "1")
                Else
                    objProyeccionBU.GuardarProyeccion(3, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, "0", "0", "0")
                End If

                FilaModificada.Cells("columnaModificada").Value = 0
            Next

        ElseIf NivelSeleccion = 4 Then
            Dim filaSeleccionada = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each FilaModificada As UltraGridRow In filaSeleccionada
                PedidoSICY = FilaModificada.Cells("pdpr_pedidosicy").Value
                Partida = FilaModificada.Cells("pdpr_partida").Value
                Lote = FilaModificada.Cells("pdpr_lote").Value
                AñoLote = FilaModificada.Cells("pdpr_añolote").Value
                NaveSicy = FilaModificada.Cells("pdpr_naveidsicy").Value
                Atado = FilaModificada.Cells("Atado").Value

                If CBool(FilaModificada.Cells("PY").Value) = True Then
                    objProyeccionBU.GuardarProyeccion(4, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, Atado, "0", "1")
                Else
                    objProyeccionBU.GuardarProyeccion(4, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, Atado, "0", "0")
                End If


                FilaModificada.Cells("columnaModificada").Value = 0
            Next

        ElseIf NivelSeleccion = 5 Then
            Dim filaSeleccionada = grdNivelPares.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each FilaModificada As UltraGridRow In filaSeleccionada
                PedidoSICY = FilaModificada.Cells("pdpr_pedidosicy").Value
                Partida = FilaModificada.Cells("pdpr_partida").Value
                Lote = FilaModificada.Cells("pdpr_lote").Value
                AñoLote = FilaModificada.Cells("pdpr_añolote").Value
                NaveSicy = FilaModificada.Cells("pdpr_naveidsicy").Value
                Atado = FilaModificada.Cells("pdpr_codigoatado").Value
                Par = FilaModificada.Cells("Par").Value

                If CBool(FilaModificada.Cells("PY").Value) = True Then
                    objProyeccionBU.GuardarProyeccion(5, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, Atado, Par, "1")
                Else
                    objProyeccionBU.GuardarProyeccion(5, PedidoSICY, Partida, Lote, AñoLote, NaveSicy, Atado, Par, "0")
                End If

                FilaModificada.Cells("columnaModificada").Value = 0
            Next

        End If

        ' ActualizarGrid(NivelSeleccion)



    End Sub

    Private Sub ActualizarGrid(ByVal Nivel As Integer)

        If Nivel = 1 Then

            Dim filasModificada = grdNivelPedido.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1 And x.Cells("LC").Value = "NO")

            For Each Fila As UltraGridRow In filasModificada
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    ElseIf Fila.Appearance.BackColor = Color.Empty And Fila.Cells("PC").Value = "SI" And Fila.Cells("totalPartidasCompletas").Value > 0 Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("inventarioPartidasCompletas").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If

                    ' Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If

                'Fila.Cells("columnaModificada").Value = 0
            Next
            ActualizarGridHijos(2)
            ActualizarGridHijos(3)
            ActualizarGridHijos(4)
            ActualizarGridHijos(5)

        ElseIf Nivel = 2 Then
            Dim filasModificada = grdNivelPartida.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each Fila As UltraGridRow In filasModificada
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If

                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
                ' Fila.Cells("columnaModificada").Value = 0
            Next

            ActualizarGridHijos(3)
            ActualizarGridHijos(4)
            ActualizarGridHijos(5)



        ElseIf Nivel = 3 Then
            Dim filasModificada = grdNivelLotes.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each Fila As UltraGridRow In filasModificada

                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If

                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
                ' Fila.Cells("columnaModificada").Value = 0
            Next

            ActualizarGridHijos(4)
            ActualizarGridHijos(5)

        ElseIf Nivel = 4 Then

            Dim filasModificada = grdNivelAtados.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each Fila As UltraGridRow In filasModificada
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If
                    '  Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
                'Fila.Cells("columnaModificada").Value = 0
            Next

            ActualizarGridHijos(5)

        ElseIf Nivel = 5 Then

            Dim filasModificada = grdNivelPares.Rows.Where(Function(x) x.Cells("columnaModificada").Value = 1)

            For Each Fila As UltraGridRow In filasModificada
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If
                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
                'Fila.Cells("columnaModificada").Value = 0
            Next
        End If

        ActualizarGridSuperiorHijos(Nivel)

    End Sub

    Private Sub ActualizarGridHijos(ByVal Nivel As Integer)

        If Nivel = 2 Then

            For Each Fila As UltraGridRow In grdNivelPartida.Rows
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If

                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
            Next

        ElseIf Nivel = 3 Then
            For Each Fila As UltraGridRow In grdNivelLotes.Rows
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If
                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If
            Next
        ElseIf Nivel = 4 Then
            For Each Fila As UltraGridRow In grdNivelAtados.Rows
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If
                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If

            Next
        ElseIf Nivel = 5 Then

            For Each Fila As UltraGridRow In grdNivelPares.Rows
                If CBool(Fila.Cells("PY").Value) = True Then
                    If Fila.Cells("ClienteSAYID").Value = "816" Then
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value + Fila.Cells("PRC").Value
                    Else
                        Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    End If
                    'Fila.Cells("A Proyectar").Value = Fila.Cells("INV").Value
                    'Fila.Cells("P Proyectar").Value = 0
                Else
                    Fila.Cells("A Proyectar").Value = 0
                    'Fila.Cells("P Proyectar").Value = 0
                End If

            Next
        End If

    End Sub

    Private Sub ActualizarGridSuperiorHijos(ByVal Nivel As Integer)
        Dim Inventario As Integer = 0
        Dim AProyectar As Integer = 0
        Dim PedidoSICY_aux As Integer = 0
        Dim partida As Integer = 0
        Dim Lote As Integer = 0
        Dim Año As Integer = 0
        Dim Nave As Integer = 0
        Dim Atado As String = String.Empty

        If Nivel = 2 Then
            For Each fila As UltraGridRow In grdNivelPartida.Rows
                Inventario += fila.Cells("INV").Value
                AProyectar += fila.Cells("A ProyectaR").Value
                PedidoSICY_aux = fila.Cells("Pedido SICY").Value
            Next

            Dim FilaPedido = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.Cells("Pedido SICY").Value = PedidoSICY_aux)



            FilaPedido.Cells("INV").Value = Inventario
            FilaPedido.Cells("A ProyectaR").Value = AProyectar

            If Inventario > 0 Then
                If AProyectar = Inventario Then
                    FilaPedido.Cells("PY").Value = True
                Else
                    FilaPedido.Cells("PY").Value = False
                End If
            End If


        ElseIf Nivel = 3 Then

            For Each fila As UltraGridRow In grdNivelLotes.Rows
                Inventario += fila.Cells("INV").Value
                AProyectar += fila.Cells("A ProyectaR").Value
                PedidoSICY_aux = fila.Cells("pdpr_pedidosicy").Value
                partida = fila.Cells("pdpr_partida").Value

            Next

            Dim FilaPedido = grdNivelPartida.Rows.FirstOrDefault(Function(x) x.Cells("Pedido SICY").Value = PedidoSICY_aux And x.Cells("Partida").Value = partida)

            FilaPedido.Cells("INV").Value = Inventario
            FilaPedido.Cells("A ProyectaR").Value = AProyectar

            If Inventario > 0 Then
                If AProyectar = Inventario Then
                    FilaPedido.Cells("PY").Value = True
                Else
                    FilaPedido.Cells("PY").Value = False
                End If
            End If

            ActualizarGridSuperiorHijos(2)


        ElseIf Nivel = 4 Then

            For Each fila As UltraGridRow In grdNivelAtados.Rows
                Inventario += fila.Cells("INV").Value
                AProyectar += fila.Cells("A ProyectaR").Value
                PedidoSICY_aux = fila.Cells("pdpr_pedidosicy").Value
                partida = fila.Cells("pdpr_partida").Value
                Lote = fila.Cells("pdpr_lote").Value
                Año = fila.Cells("pdpr_añolote").Value
                Nave = fila.Cells("pdpr_naveidsicy").Value

            Next

            Dim FilaPedido = grdNivelLotes.Rows.FirstOrDefault(Function(x) x.Cells("pdpr_pedidosicy").Value = PedidoSICY_aux And x.Cells("pdpr_partida").Value = partida And x.Cells("Lote").Value = Lote And x.Cells("Año").Value = Año And x.Cells("NaveId").Value = Nave)

            FilaPedido.Cells("INV").Value = Inventario
            FilaPedido.Cells("A ProyectaR").Value = AProyectar

            If Inventario > 0 Then
                If AProyectar = Inventario Then
                    FilaPedido.Cells("PY").Value = True
                Else
                    FilaPedido.Cells("PY").Value = False
                End If
            End If

            ActualizarGridSuperiorHijos(3)
            ActualizarGridSuperiorHijos(2)

        ElseIf Nivel = 5 Then

            For Each fila As UltraGridRow In grdNivelPares.Rows
                Inventario += fila.Cells("INV").Value
                AProyectar += fila.Cells("A ProyectaR").Value
                PedidoSICY_aux = fila.Cells("pdpr_pedidosicy").Value
                partida = fila.Cells("pdpr_partida").Value
                Lote = fila.Cells("pdpr_lote").Value
                Año = fila.Cells("pdpr_añolote").Value
                Nave = fila.Cells("pdpr_naveidsicy").Value
                Atado = fila.Cells("Atado").Value
            Next

            Dim FilaPedido = grdNivelAtados.Rows.FirstOrDefault(Function(x) x.Cells("Atado").Value = Atado)

            FilaPedido.Cells("INV").Value = Inventario
            FilaPedido.Cells("A ProyectaR").Value = AProyectar

            If Inventario > 0 Then
                If AProyectar = Inventario Then
                    FilaPedido.Cells("PY").Value = True
                Else
                    FilaPedido.Cells("PY").Value = False
                End If
            End If

            ActualizarGridSuperiorHijos(4)
            ActualizarGridSuperiorHijos(3)
            ActualizarGridSuperiorHijos(2)
        End If

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        'Dim objBu As New Ventas.Negocios.ProyeccionEntregasBU
        'Dim dtSesiones As DataTable
        'Dim sesion As Integer = 0
        'Dim dtOtsSeleccionadas As DataTable
        'Dim Ots As Integer = 0
        'Dim confirmar As New Tools.ConfirmarForm

        'grdNivelPedido_BeforeRowDeactivate(Nothing, Nothing)
        'grdNivelPartida_BeforeRowDeactivate(Nothing, Nothing)
        'grdNivelLotes_BeforeRowDeactivate(Nothing, Nothing)
        'grdNivelAtados_BeforeRowDeactivate(Nothing, Nothing)
        'grdNivelPares_BeforeRowDeactivate(Nothing, Nothing)


        'confirmar.mensaje = "¿Esta seguro de generar las Ordenes de Trabajo?"
        'If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Try
        '        btnGuardar.Enabled = False
        '        lblGuardar.Enabled = False

        '        Cursor = Cursors.WaitCursor
        '        'VERIFICAR SESIONES ANTERIORES ACTIVAS
        '        dtSesiones = objBu.ConsultaSesionActivaPorUsuario_SoloConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        '        If dtSesiones.Rows.Count > 0 Then
        '            sesion = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
        '            dtOtsSeleccionadas = objBu.GenerarOrdenesTrabajo(sesion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '            Ots = dtOtsSeleccionadas.Rows(0).Item(0).ToString()


        '            show_message("Exito", "Se han generardo " + Ots.ToString() + " orden (s) de trabajo")
        '            show_message("Aviso", "En caso de requerir otro movimiento dar clic en mostrar.")

        '            'ActualizarPantalla()

        '        End If
        '        Cursor = Cursors.Default
        '    Catch ex As Exception
        '        btnGuardar.Enabled = False
        '        Cursor = Cursors.Default
        '        show_message("Error", ex.Message.ToString())
        '    End Try

        'End If


    End Sub


    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
                Return
            End If
        End If


        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                grd.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True
                grd.DisplayLayout.Bands(0).Columns("PY").Hidden = True
                'grd.DisplayLayout.Bands(0).Columns("columnaModificada").Hidden = True
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                grd.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = False
                grd.DisplayLayout.Bands(0).Columns("PY").Hidden = False
                'grd.DisplayLayout.Bands(0).Columns("columnaModificada").Hidden = False
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If grdNivelPartida.Rows.Count > 0 Then
            Dim punto As Point
            punto.X = btnSeguimientoPares.Location.X + btnSeguimientoPares.Width
            punto.Y = btnSeguimientoPares.Location.Y + btnSeguimientoPares.Height
            cmsExpportar.Show(punto)

        Else
            exportarExcel(grdNivelPedido)
        End If

    End Sub


    Private Sub btnSeguimientoPares_Click(sender As Object, e As EventArgs) Handles btnSeguimientoPares.Click

        Dim punto As Point
        punto.X = btnSeguimientoPares.Location.X + btnSeguimientoPares.Width
        punto.Y = btnSeguimientoPares.Location.Y + btnSeguimientoPares.Height
        cmsTiposResumen.Show(punto)


    End Sub

    Private Sub chkListoParaEnviar_CheckedChanged(sender As Object, e As EventArgs) Handles chkListoParaEnviar.CheckedChanged
        FiltrarPedidosCompletos()
        If grdNivelPedido.Rows.Count > 0 Then
            lblNumFiltrados.Text = CDbl(grdNivelPedido.Rows.VisibleRowCount - 2).ToString("N0")
        Else
            lblNumFiltrados.Text = "0"
        End If

    End Sub


    Private Sub FiltrarPedidosCompletos()

        If chkListoParaEnviar.Checked = True And chkAtrasadoVentas.Checked = True Then

            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen)
            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

            Dim lista2 = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor = Color.MediumSeaGreen And x.Hidden = True)

            For Each fila As UltraGridRow In lista2
                fila.Hidden = False
            Next

        ElseIf chkListoParaEnviar.Checked = True Then
            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen Or x.Cells("F Entrega").Value < Date.Now.ToShortDateString())

            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

        ElseIf chkAtrasadoVentas.Checked = True Then

            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen Or x.Cells("F Entrega").Value >= Date.Now.ToShortDateString())

            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

            Dim lista2 = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor = Color.MediumSeaGreen And x.Cells("F Entrega").Value < Date.Now.ToShortDateString() And x.Hidden = True)

            For Each fila As UltraGridRow In lista2
                fila.Hidden = False
            Next

        Else
            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Hidden = True)
            For Each fila As UltraGridRow In lista
                fila.Hidden = False
            Next

        End If



    End Sub

    Private Sub FiltrarPedidosCompletosAtrasados()

        If chkListoParaEnviar.Checked = True And chkAtrasadoVentas.Checked = True Then

            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen)
            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

            Dim lista2 = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor = Color.MediumSeaGreen And x.Hidden = True)

            For Each fila As UltraGridRow In lista2
                fila.Hidden = False
            Next

        ElseIf chkAtrasadoVentas.Checked = True Then
            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen Or x.Cells("F Entrega").Value >= Date.Now.ToShortDateString())

            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

        ElseIf chkListoParaEnviar.Checked = True Then

            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor <> Color.MediumSeaGreen Or x.Cells("F Entrega").Value < Date.Now.ToShortDateString())

            For Each fila As UltraGridRow In lista
                fila.Hidden = True
            Next

            Dim lista2 = grdNivelPedido.Rows.Where(Function(x) x.Appearance.BackColor = Color.MediumSeaGreen And x.Cells("F Entrega").Value >= Date.Now.ToShortDateString() And x.Hidden = True)

            For Each fila As UltraGridRow In lista2
                fila.Hidden = False
            Next


        Else
            Dim lista = grdNivelPedido.Rows.Where(Function(x) x.Hidden = True)
            For Each fila As UltraGridRow In lista
                fila.Hidden = False
            Next

        End If

    End Sub

    Private Sub tsmiApartados_Click(sender As Object, e As EventArgs) Handles tsmiApartados.Click
        CargarSeguimientoPares(1)
    End Sub

    Private Sub tsmiBloqueados_Click(sender As Object, e As EventArgs) Handles tsmiBloqueados.Click
        CargarSeguimientoPares(3)
    End Sub

    Private Sub tsmiProduccion_Click(sender As Object, e As EventArgs) Handles tsmiProduccion.Click
        CargarSeguimientoPares(2)
    End Sub

    Private Sub tmsiReproceso_Click(sender As Object, e As EventArgs) Handles tmsiReproceso.Click
        CargarSeguimientoPares(4)
    End Sub

    Private Function ObtenerSesionID() As Integer
        Dim SesionId As Integer = 0
        Dim objBU As New Negocios.ProyeccionEntregasBU
        Dim dtSesiones As New DataTable

        dtSesiones = objBU.ConsultaSesionActivaPorUsuario_SoloConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtSesiones.Rows.Count > 0 Then
            SesionId = Integer.Parse(dtSesiones.Rows(0).Item(0).ToString())
        Else
            SesionId = 0
        End If

        Return SesionId

    End Function


    Private Sub CargarSeguimientoPares(ByVal Tipo As Integer)
        Try
            Cursor = Cursors.WaitCursor
            Dim Form As New SeguimientoParesProyeccion_SoloConsultaForm()
            Form.SesionID = ObtenerSesionID()
            Form.tipoConsulta = Tipo
            Form.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnClientesBlolqueados_Click(sender As Object, e As EventArgs) Handles btnClientesBlolqueados.Click
        CargarSeguimientoPares(5)
    End Sub

    Private Sub tmsiPedidos_Click(sender As Object, e As EventArgs) Handles tmsiPedidos.Click
        exportarExcel(grdNivelPedido)
    End Sub

    Private Sub tmsiPartidas_Click(sender As Object, e As EventArgs) Handles tmsiPartidas.Click
        exportarExcel(grdNivelPartida)
    End Sub

    Private Sub chkAtrasadoVentas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAtrasadoVentas.CheckedChanged
        FiltrarPedidosCompletosAtrasados()
        lblNumFiltrados.Text = CDbl(grdNivelPedido.Rows.VisibleRowCount - 2).ToString("N0")
    End Sub



    Private Sub ProgramaciónProgramadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaciónProgramadoToolStripMenuItem.Click
        CargarSeguimientoPares(6)
    End Sub

    Private Sub PartidasDeTodosLosPedidosMostradosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartidasDeTodosLosPedidosMostradosToolStripMenuItem.Click
        exportarExcel(PartidasPedidosForm.grdVPartidasPedidos)
    End Sub
End Class