Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Linq
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic

Public Class AltaProspectaForm

    Public ProspectaID As Integer = -1
    Public ModoEdicion As Boolean = False
    Dim MostrarMenuContextual = False
    Dim IdPuestoUsuario As Integer = -1
    Dim TipoPerfil As Integer '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts
    Dim ValorGuardado As Boolean = False

    Dim IdEstadoProspecta As Int32
    Dim UsuarioIdPruebaPerfil As Integer

    Dim dtDatosCliente As New DataTable
    Dim dtDatosPedidos As New DataTable
    Dim dtDatosPartidas As New DataTable

    Dim IndexTabPageActual As Integer = 0
    Dim dtFiltroProspecta As New DataTable
    Dim ListaFiltroAtencionClientes As List(Of String)
    Dim ListaFiltroClientes As List(Of String)
    Dim ListaFiltroAgenteVentas As List(Of String)

    Dim IndexTabActual As Int32 = 0
    Dim FechaProgramacion As Date
    Dim DiasProspecta As List(Of Entidades.ProspectaDias)

    Dim ListaAtados As List(Of Entidades.TipoEmpaque)


    Dim ListaClientesProspectadosCompletos As List(Of Integer)
    Dim ListaPedidosProspectadosCompletos As List(Of Integer)

    Dim ListaIndicesPartidasModificadas As New List(Of Integer)
    Dim ListaIndicesPedidosModificadas As New List(Of Integer)
    Dim ListaIndicesClientesModificadas As New List(Of Integer)

    Dim ListaClientesEnEdicionUsuario As New List(Of Integer)


    Private Sub AltaProspectaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)

    End Sub


    Private Sub AltaProspectaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        DiasProspecta = New List(Of Entidades.ProspectaDias)
        Dim objEntProspecta As Entidades.ProspectaInformacion


        btnGuardar.Enabled = False
        If ProspectaID = -1 Then
            ModoEdicion = True
            IdEstadoProspecta = -1
        Else
            objEntProspecta = ObtenerInformacionProspecta(ProspectaID)
            IdEstadoProspecta = objEntProspecta.IDEstatusProspecta
            ModoEdicion = False
        End If

        CargarInterfaz()

        PonerModoEdicionColumunas()

        ListaAtados = New List(Of Entidades.TipoEmpaque)

        'gridParesPorAtado.Visible = False
        'gridParesProyectar.Visible = False

        PermisosPerfil()
        ' TipoPerfil = 2

        btnCancelarProspecta.Enabled = False
        btnEditar.Enabled = False
        
    End Sub

    Private Sub PermisosPerfil()


        ''0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno

        ''Atencion a clientes externo
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTEEXTERNO") Then
            If ProspectaID <> -1 Then
                If IdEstadoProspecta = 87 Or IdEstadoProspecta = 88 Then
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = True
                    TipoPerfil = 4
                    btnAtnClientes.Enabled = False
                Else
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = False
                    TipoPerfil = 4
                    btnAtnClientes.Enabled = False
                End If
            End If
            TipoPerfil = 4
        End If

        ''Atencion a clientes interno e externo
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTES") Then
            If ProspectaID <> -1 Then
                If IdEstadoProspecta = 87 Or IdEstadoProspecta = 88 Then
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = True
                    TipoPerfil = 0
                    ' btnAtnClientes.Enabled = False
                Else
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = False
                    TipoPerfil = 0
                    'btnAtnClientes.Enabled = False
                End If
            End If
            TipoPerfil = 0
        End If

       

        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_AGENTEVENTAS") Then
            btnCancelarProspecta.Enabled = False
            btnEditar.Enabled = False
            TipoPerfil = 1
            btnFiltroAgenteVentas.Enabled = False
        End If

        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ANALISTAVENTAS") Then
            btnCancelarProspecta.Enabled = False
            btnEditar.Enabled = False
            TipoPerfil = 3
        End If

        'Jefatura Atencion Clientes
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_JEFATURA") Then
            If ProspectaID <> -1 Then
                If IdEstadoProspecta = 87 Or IdEstadoProspecta = 88 Then
                    btnCancelarProspecta.Enabled = True
                    btnEditar.Enabled = True
                    TipoPerfil = 2
                Else
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = False
                    TipoPerfil = 2
                End If


            End If
            TipoPerfil = 2
        End If


        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_EXPSAP_EVENT", "VENT_SAPICA_PPCP", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) Then
        '    btnEditar.Visible = False
        '    btnAltas.Visible = False
        '    lblAltas.Visible = False
        '    lblEditar.Visible = False

        'End If
      

    End Sub


    Private Sub CargarInterfaz()
        Dim objEntProspecta As Entidades.ProspectaInformacion

        ListaFiltroAtencionClientes = New List(Of String)
        ListaFiltroClientes = New List(Of String)
        ListaFiltroAgenteVentas = New List(Of String)

        CargarUsuariosAtencionClientes()
        OcultarControlesAltaConsultaProspecta()
        ObtenerFechasProspecta()
        ObtenerNumeroSemana()
        ObtenerColumnasDinamicas()
        grdAtnClientes.DataSource = ListaFiltroAtencionClientes
        grdFiltroClientes.DataSource = ListaFiltroClientes
        gridFiltroAgenteVentas.DataSource = ListaFiltroAgenteVentas
        gridDiseno(gridPedidos)
        gridDiseno(gridPartidas)
        gridDiseno(gridParesPorAtado)
        gridDiseno(gridListaProspecta)
        gridDiseno(gridParesProyectar)
        CargarEncabezadosGrid()       
        CargarParesConfirmados()
        OcultarColumnas()

        'FechaProgramacion = dtmFechaProgramacion.Value
        If ProspectaID = -1 Then
            ModoEdicion = True
            PonerModoEdicionColumunas()
            'txtUsuarioCreo.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'txtFechaCreacion.Text = Date.Now.ToString()
            txtStatusProspecta.ReadOnly = True
            txtStatusProspecta.Enabled = True
            MostrarEstadoProspecta(87, "PROXIMA")
            btnEditar.Visible = True
            btnCancelarProspecta.Visible = True
            lblEditar.Visible = True
            lblCancelar.Visible = True

            lblCreacion.Visible = False
            txtUsuarioCreo.Visible = False
            txtFechaCreacion.Visible = False

            btnEditar.Enabled = False
            btnCancelarProspecta.Enabled = False
            lblEditar.Enabled = False
            lblCancelar.Enabled = False

            gridParesPorAtado.Visible = False
            gridParesProyectar.Visible = False

        Else
            dtmFechaInicio.Enabled = False
            dtmFechaFin.Enabled = False
            objEntProspecta = ObtenerInformacionProspecta(ProspectaID)
            IdEstadoProspecta = objEntProspecta.IDEstatusProspecta
            LenarParesTotalAtados()

            gridParesPorAtado.Visible = False
            gridParesProyectar.Visible = False
            If objEntProspecta.IDEstatusProspecta = 87 Then 'Proxima
                'btnCancelarProspecta.Enabled = True
                chkProyeccionSemanal.Visible = False
                chkConfirmacionOTSemanal.Visible = False
                chkEmbarcadoSemanal.Visible = False
                chkSalidaSemanal.Visible = False
                chkInfoMedicion.Visible = False
               
            Else
                'btnCancelarProspecta.Enabled = False
                chkProyeccionSemanal.Visible = True
                chkConfirmacionOTSemanal.Visible = True
                chkEmbarcadoSemanal.Visible = True
                chkSalidaSemanal.Visible = True
            End If

            If objEntProspecta.IDEstatusProspecta = 88 Then
                rdoAsertividad.Visible = True
                rdoCumplimiento.Visible = True
                chkInfoMedicion.Visible = True
                gridParesPorAtado.Visible = True
                gridParesProyectar.Visible = True
            End If

            If objEntProspecta.IDEstatusProspecta = 89 Then
                gridParesPorAtado.Visible = True
                gridParesProyectar.Visible = True
            End If

            If objEntProspecta.IDEstatusProspecta = 89 Or objEntProspecta.IDEstatusProspecta = 90 Then 'Cancelada
                btnCancelarProspecta.Enabled = False
                btnEditar.Enabled = False
                btnGuardar.Enabled = False
                txtUsuarioEditando.Visible = False
                txtFechaEdicion.Visible = False
                lblUsuarioEditando.Visible = False
            Else
                ObtenerInformacionUsuarioEdicion()
            End If
        End If

        btnCancelarProspecta.Enabled = False
        btnEditar.Enabled = False
      
    End Sub

    Private Sub ObtenerInformacionUsuarioEdicion()
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        Dim dtInformacionUsuario As DataTable
        dtInformacionUsuario = ObjPRospecta.ObtenerInformacionUsuarioActivo()

        If dtInformacionUsuario.Rows.Count > 0 Then
            txtUsuarioEditando.Text = dtInformacionUsuario.Rows(0).Item("UserName").ToString
            txtFechaEdicion.Text = dtInformacionUsuario.Rows(0).Item("FechaInicioActividad").ToString
        End If
    End Sub

    Private Sub ObtenerFechasProspecta()
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        Dim dtInformacionFechas As DataTable
        Dim EntProspecta As Entidades.ProspectaInformacion
        If ProspectaID = -1 Then
            dtInformacionFechas = ObjPRospecta.ObtenerFechasProximaProspecta()
            If dtInformacionFechas.Rows.Count > 0 Then
                dtmFechaInicio.Value = dtInformacionFechas.Rows(0).Item("FechaInicio").ToString
                dtmFechaFin.Value = dtInformacionFechas.Rows(0).Item("FechaFin").ToString
                dtmFechaProgramacion.Value = dtInformacionFechas.Rows(0).Item("FechaFin").ToString
            End If
        Else
            EntProspecta = ObjPRospecta.CargarInformacionProspecta(ProspectaID)
            dtmFechaInicio.Value = EntProspecta.FechaInicio
            dtmFechaFin.Value = EntProspecta.FechaFin
            dtmFechaProgramacion.Value = dtmFechaFin.Value
        End If

    End Sub

    Private Sub MostrarEstadoProspecta(ByVal EstadoProspectaID As Integer, ByVal Estado As String)

        Select Case EstadoProspectaID
            Case 87
                txtStatusProspecta.ForeColor = Color.Purple
                txtStatusProspecta.Text = Estado
            Case 88
                txtStatusProspecta.ForeColor = Color.Green
                txtStatusProspecta.Text = Estado
            Case 89
                txtStatusProspecta.ForeColor = Color.Blue
                txtStatusProspecta.Text = Estado
            Case 90
                txtStatusProspecta.ForeColor = Color.Red
                txtStatusProspecta.Text = Estado
        End Select

    End Sub

    Public Sub OcultarControlesAltaConsultaProspecta()

        Dim MostrarControles As Boolean = False

        If ProspectaID = -1 Then 'Alta
            MostrarControles = False
        Else
            MostrarControles = True
        End If

        btnEditar.Visible = MostrarControles
        btnCancelarProspecta.Visible = MostrarControles
        lblCancelar.Visible = MostrarControles
        lblEditar.Visible = MostrarControles
        gridParesPorAtado.Visible = MostrarControles
        gridParesProyectar.Visible = MostrarControles

        lblModificacion.Visible = MostrarControles
        lblUsuarioEditando.Visible = MostrarControles
        lblModificacion.Visible = MostrarControles
        txtFechaModificacion.Visible = MostrarControles
        txtFechaEdicion.Visible = MostrarControles
        txtUsuarioEditando.Visible = MostrarControles
        txtUsuarioModifico.Visible = MostrarControles

        chkEmbarcadoSemanal.Visible = MostrarControles
        chkPlaneacionSemanal.Visible = MostrarControles
        chkProyeccionSemanal.Visible = MostrarControles
        chkSalidaSemanal.Visible = MostrarControles
        chkConfirmacionOTSemanal.Visible = MostrarControles
        chkInfoMedicion.Visible = MostrarControles
    End Sub

    Private Function ObtenerInformacionProspecta(ByVal ProspectaID As Integer) As Entidades.ProspectaInformacion
        Dim objInfoProspecta As New Ventas.Negocios.ProspectaBU
        Dim EntInfoProspecta As New Entidades.ProspectaInformacion
        EntInfoProspecta = objInfoProspecta.CargarInformacionProspecta(ProspectaID)

        txtFechaCreacion.Text = EntInfoProspecta.FechaCreacion.ToString()
        txtFechaModificacion.Text = EntInfoProspecta.FechaModificacion.ToString()
        txtUsuarioCreo.Text = EntInfoProspecta.NombreUsuarioCreo.Trim()
        txtUsuarioModifico.Text = EntInfoProspecta.NombreUsuarioModifio.Trim()

        MostrarEstadoProspecta(EntInfoProspecta.IDEstatusProspecta.ToString, EntInfoProspecta.EstatusProspecta)

        Return EntInfoProspecta
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        'Dim ConsultaDetalleProspecta As New ConsultaDetalleProspectaForm
        'ConsultaDetalleProspecta.ShowDialog()
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        Panel6.Height = 24
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Panel6.Height = 193
    End Sub

    Private Sub btnCerrar_Click_1(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)


        Me.Close()
    End Sub

    Private Sub LlenarGridProspectaClientes()
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        Dim FiltroClientes As String = String.Empty
        FiltroClientes = ObtenerAgentesSeleccinados()

        'dtDatosCliente = ObjPRospecta.ConsultaProspecta(ProspectaID, dtmFechaInicio.Value, dtmFechaFin.Value, dtmFechaProgramacion.Value, ObtenerFiltroAtencionClientes, FiltroClientes, rdoCumplimiento.Checked)

        If TipoPerfil = 4 Then
            dtDatosCliente = ObjPRospecta.ConsultaProspecta(ProspectaID, dtmFechaInicio.Value, dtmFechaFin.Value, dtmFechaProgramacion.Value, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, FiltroClientes, rdoCumplimiento.Checked)
        Else
            dtDatosCliente = ObjPRospecta.ConsultaProspecta(ProspectaID, dtmFechaInicio.Value, dtmFechaFin.Value, dtmFechaProgramacion.Value, ObtenerFiltroAtencionClientes, FiltroClientes, rdoCumplimiento.Checked)
        End If

        'dtDatosCliente = ObjPRospecta.ConsultaProspecta(ProspectaID, dtmFechaInicio.Value, dtmFechaFin.Value, dtmFechaProgramacion.Value, ObtenerFiltroAtencionClientes, FiltroClientes, rdoCumplimiento.Checked)
        gridListaProspecta.DataSource = dtDatosCliente
    End Sub

    Private Sub FiltrarPedidosxCliente()
        Dim listaclientes As List(Of Integer)
        listaclientes = ObtenerClientesSeleccinadosGrid()
        For Each fila As UltraGridRow In gridPedidos.Rows
            fila.Hidden = True
            For Each filtroclienteid As Integer In listaclientes
                If fila.Cells("clienteid").Value = filtroclienteid Then
                    fila.Hidden = False
                    Continue For
                End If
            Next
        Next
    End Sub

    Private Sub FiltrarPedidosxClienteSeleccionado()
        Dim listaclientes As List(Of Integer)
        listaclientes = ObtenerClientesSeleccinadosGrid()
        For Each fila As UltraGridRow In gridPedidos.Rows
            fila.Hidden = True
            For Each filtroclienteid As Integer In listaclientes
                If fila.Cells("clienteid").Value = filtroclienteid Then
                    fila.Hidden = False
                    fila.Cells(" ").Value = True
                    Continue For
                End If
            Next
        Next
    End Sub

    Private Sub FiltrarPartidasXPedido()
        Dim listaPedidos As List(Of Integer)
        Dim valor As String
        listaPedidos = ObtenerPedidosSeleccinadosGrid()
        For Each fila As UltraGridRow In gridPartidas.Rows
            fila.Hidden = True
            For Each filtroclienteid As Integer In listaPedidos
                valor = fila.Cells("PSICY").Value

                If fila.Cells("PSICY").Value = filtroclienteid Then
                    fila.Hidden = False
                    Continue For
                End If
            Next
        Next
    End Sub



    Private Sub LlenaGridPedidos(ByVal Recargar As Boolean)
        Dim ClientesID As String = String.Empty
        Dim FiltroAgente As String = String.Empty

        FiltroAgente = ObtenerAgentesSeleccinados()
        ClientesID = ObtenerClientesSeleccinadosGrid(True)

        If ClientesID <> String.Empty Then
            'Comprobar si datos en las tablas temporales si no recargar
            If IsNothing(dtDatosPedidos) = True Then
                Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
                dtDatosPedidos = ObjPRospecta.ConsultaPedidosCliente(ProspectaID, ClientesID, dtmFechaProgramacion.Value, FiltroAgente, rdoCumplimiento.Checked)
                gridPedidos.DataSource = dtDatosPedidos
                FiltrarPedidosxCliente()
            ElseIf dtDatosPedidos.Rows.Count = 0 Then
                Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
                dtDatosPedidos = ObjPRospecta.ConsultaPedidosCliente(ProspectaID, ClientesID, dtmFechaProgramacion.Value, FiltroAgente, rdoCumplimiento.Checked)
                gridPedidos.DataSource = dtDatosPedidos
                FiltrarPedidosxCliente()
            Else
                gridPedidos.DataSource = dtDatosPedidos
                FiltrarPedidosxCliente()
            End If
        Else
            gridPedidos.DataSource = Nothing
            CargarEncabezadoPedidos()
        End If

        gridPedidos.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)

    End Sub

    Private Sub LlenaGridPartidas(ByVal Recargar As Boolean)

        Dim PedidosID As String = String.Empty
        Dim FiltroAgente As String = String.Empty

        FiltroAgente = ObtenerAgentesSeleccinados()
        PedidosID = ObtenerPedidosSeleccinadosGrid(True)

        If PedidosID <> String.Empty Then
            'Comprobar si datos en las tablas temporales si no recargar
            If dtDatosPartidas.Rows.Count = 0 Then
                Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
                dtDatosPartidas = ObjPRospecta.ConsultaPartidasPedido(ProspectaID, PedidosID, dtmFechaProgramacion.Value, FiltroAgente, dtmFechaFin.Value, rdoCumplimiento.Checked, dtmFechaInicio.Value)
                gridPartidas.DataSource = dtDatosPartidas
                FiltrarPartidasXPedido()
            Else
                gridPartidas.DataSource = dtDatosPartidas
                FiltrarPartidasXPedido()
            End If
        Else
            gridPartidas.DataSource = Nothing
            CargarEncabezadoPartidas()
        End If

        gridPartidas.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)

    End Sub

    Private Sub RecargarGridPartidas()
        If IsNothing(gridPartidas.DataSource) = True Then
            Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
            Dim FiltroAgente As String = String.Empty
            FiltroAgente = ObtenerAgentesSeleccinados()

            dtDatosPartidas = ObjPRospecta.ConsultaPartidasPedido(ProspectaID, "", dtmFechaProgramacion.Value, FiltroAgente, dtmFechaFin.Value, rdoCumplimiento.Checked, dtmFechaInicio.Value)
            gridPartidas.DataSource = dtDatosPartidas
        End If
    End Sub


    Private Function ObtenerFiltroAtencionClientes() As String
        Dim filtro As String = ""
        For Each row As UltraGridRow In grdAtnClientes.Rows
            If row.Index = 0 Then
                filtro += " " + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                filtro += ", " + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return filtro
    End Function


    Private Function ObtenerClientesSeleccionadosFiltro() As String
        Dim filtro As String = String.Empty
        Dim ClienteSicyID As Integer = 0
        If grdFiltroClientes.Rows.Count <> 0 Then
            For Each row As UltraGridRow In grdFiltroClientes.Rows
                ClienteSicyID = ObtenerClienteSicyID(row.Cells(0).Text)
                If row.Index = 0 Then
                    filtro += " " + Replace(ClienteSicyID.ToString(), ",", "") + ""
                Else
                    filtro += ", " + Replace(ClienteSicyID.ToString(), ",", "") + ""
                End If
            Next           
        End If

        Return filtro
    End Function

    Private Function ObtenerAtencionClientesFiltro() As String
        Dim filtro As String = String.Empty
        Dim ClienteSicyID As Integer = 0
        If grdAtnClientes.Rows.Count <> 0 Then
            For Each row As UltraGridRow In grdAtnClientes.Rows
                If row.Index = 0 Then
                    filtro += " " + Replace(ClienteSicyID.ToString(), ",", "") + ""
                Else
                    filtro += ", " + Replace(ClienteSicyID.ToString(), ",", "") + ""
                End If
            Next
        End If
        Return filtro
    End Function

    Private Function ObtenerClienteSicyID(ByVal ClienteSayId As Integer) As Integer
        Dim objProspectaBU As New Ventas.Negocios.ProspectaBU
        Return objProspectaBU.ObtenerClienteSicyID(ClienteSayId)
    End Function


    Private Function ObtenerClientesSeleccinadosGrid(ByVal SoloSeleccionados As Boolean) As String
        Dim filtro As String = String.Empty
        For Each row As UltraGridRow In gridListaProspecta.Rows
            If row.IsFilteredOut = False Then
                If SoloSeleccionados = True Then
                    If row.Cells(" ").Value = True And row.Hidden = False Then
                        If filtro = String.Empty Then
                            filtro += " '" + Replace(row.Cells("clienteId").Text, ",", "") + "'"
                        Else
                            filtro += ", '" + Replace(row.Cells("clienteId").Text, ",", "") + "'"
                        End If
                    End If

                Else
                    If filtro = String.Empty Then
                        filtro += " '" + Replace(row.Cells("clienteId").Text, ",", "") + "'"
                    Else
                        filtro += ", '" + Replace(row.Cells("clienteId").Text, ",", "") + "'"
                    End If
                End If
            End If
        Next
        Return filtro
    End Function

    Private Function ObtenerClientesSeleccinadosGrid() As List(Of Integer)
        Dim filtro As List(Of Integer) = New List(Of Integer)
        For Each row As UltraGridRow In gridListaProspecta.Rows
            If row.IsFilteredOut = False Then
                If row.Cells(" ").Value = True And row.Hidden = False Then
                    filtro.Add(CInt(row.Cells("ClienteSicyId").Text))
                End If
            End If
        Next
        Return filtro
    End Function

    Private Function ObtenerAgentesSeleccinados() As String
        Dim filtro As String = String.Empty
        For Each row As UltraGridRow In gridFiltroAgenteVentas.Rows
            If row.IsFilteredOut = False Then
                If row.Cells(" ").Value = True And row.Hidden = False Then
                    If filtro = String.Empty Then
                        filtro += " " + Replace(row.Cells(0).Text, ",", "") + ""
                    Else
                        filtro += ", " + Replace(row.Cells(0).Text, ",", "") + ""
                    End If
                End If
            End If
        Next

        If TipoPerfil = 1 Then 'Agente
            filtro = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        End If


        Return filtro



        'Dim FiltroAgenteID As String = String.Empty
        'For Each row As UltraGridRow In gridFiltroAgenteVentas.Rows
        '    FiltroAgenteID += " " + row.Cells(0).Text + ","
        'Next
        'If gridFiltroAgenteVentas.Rows.Count = 0 Then
        '    FiltroAgenteID = "-1"
        'End If
        'Return FiltroAgenteID
    End Function

    Private Function ObtenerPedidosSeleccinadosGrid(ByVal SoloSeleccionados As Boolean) As String
        Dim filtro As String = String.Empty
        For Each row As UltraGridRow In gridPedidos.Rows
            If row.IsFilteredOut = False Then
                If SoloSeleccionados = True Then
                    If row.Cells(" ").Value = True And row.Hidden = False Then
                        If filtro = String.Empty Then
                            filtro += " '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
                        Else
                            filtro += ", '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
                        End If
                    End If

                Else
                    If filtro = String.Empty Then
                        filtro += " '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
                    Else
                        filtro += ", '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
                    End If
                End If
            End If
        Next
        Return filtro
    End Function

    Private Function ObtenerPedidosSeleccinadosGrid() As List(Of Integer)
        Dim filtro As List(Of Integer) = New List(Of Integer)
        For Each row As UltraGridRow In gridPedidos.Rows
            If row.IsFilteredOut = False Then
                If row.Cells(" ").Value = True And row.Hidden = False Then
                    filtro.Add(CInt(row.Cells("PSICY").Text))
                End If
            End If

        Next
        Return filtro
    End Function


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

                Select Case tabProspecta.SelectedIndex
                    Case 0
                        gridExcelExporter.Export(Me.gridListaProspecta, .SelectedPath + "\Prospecta_" + fecha_hora + ".xlsx")
                    Case 1
                        gridExcelExporter.Export(Me.gridPedidos, .SelectedPath + "\ProspectaPedidos_" + fecha_hora + ".xlsx")
                    Case 2
                        gridExcelExporter.Export(Me.gridPartidas, .SelectedPath + "\ProspectaPartidas_" + fecha_hora + ".xlsx")
                End Select



            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()
        End With
    End Sub



    Public Sub RespaldarParesSicy()
        '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts

        Dim FiltroClientes As String = ObtenerClientesSeleccionadosFiltro()
        Dim FiltroAtencionClientes As String = ObtenerAtencionClientesFiltro()
        Dim FiltroAgenteID As String = ObtenerAgentesSeleccinados()

        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        ObjPRospecta.RespaldarPares(TipoPerfil, FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Try
            
            show_message("Aviso", "La consulta puede tardar varios minutos en desplegarse")
            Cursor = Cursors.WaitCursor
           
            btnMostrar.Enabled = False
            Dim FiltroAgente As String = String.Empty
            Dim objProspecta As New Ventas.Negocios.ProspectaBU

            FiltroAgente = ObtenerAgentesSeleccinados()

            If ProspectaID = -1 Or ModoEdicion = True Then
                btnGuardar.Enabled = True
            End If

            ListaIndicesClientesModificadas.Clear()
            ListaIndicesPartidasModificadas.Clear()
            ListaIndicesPedidosModificadas.Clear()


            If ProspectaID <> -1 Then
                If IdEstadoProspecta <> 89 And IdEstadoProspecta <> 90 Then
                    objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID, True)
                    RespaldarParesSicy()
                End If
            Else
                objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID, True)
                RespaldarParesSicy()
            End If

            If IdEstadoProspecta = 88 Then
                objProspecta.ProspectaRespaldarParesMedicion(ProspectaID, Date.Now)
            End If


            DiasProspecta.Clear()
            ObtenerColumnasDinamicas()
            DiseñarMenuContextual()
            gridListaProspecta.DataSource = Nothing
            gridPedidos.DataSource = Nothing
            gridPartidas.DataSource = Nothing

            CargarEncabezadoGridProspecta()
            EncabezadoGridProspecta(gridListaProspecta)

            CargarEncabezadoPedidos()
            DiseñoEncabezadoPedidos(gridPedidos)

            CargarEncabezadoPartidas()
            DiseñoEnzabezadoPartidas(gridPartidas)



            LlenarGridProspectaClientes()
            PonerModoEdicionColumunas()
            'LenarParesTotalAtados()
            dtDatosPartidas.Rows.Clear()
            dtDatosPedidos.Rows.Clear()

            RecargarGridPartidas()
            'LlenaGridPedidos(True)

            dtDatosPedidos = objProspecta.ConsultaPedidosCliente(ProspectaID, "", dtmFechaProgramacion.Value, FiltroAgente, rdoCumplimiento.Checked)
            gridPedidos.DataSource = dtDatosPedidos

            'gridParesPorAtado.Visible = True
            'CargarParesConfirmados()
            OcultarColumnas()
            CargarListaIncidenciasGrid()

            PonerModoEdicionColumunas()
            btnMostrar.Enabled = True

            SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
            SumarColumnas_IALM_IPRO_AXC(gridPedidos)
            SumarColumnas_IALM_IPRO_AXC(gridPartidas)

            FiltrarInformacion()

         

            If ProspectaID <> -1 Then
                If IdEstadoProspecta = 88 Or IdEstadoProspecta = 89 Then
                    gridParesPorAtado.DataSource = Nothing
                    gridParesProyectar.DataSource = Nothing
                    gridParesPorAtado.DataSource = objProspecta.ObtenerParesPorTipoEmpaque(ProspectaID, ObtenerAtencionClientesFiltro(), ObtenerClientesSeleccionadosFiltro(), ObtenerAgentesSeleccinados())
                    gridParesProyectar.DataSource = objProspecta.ObtenerParesConfirmados(ProspectaID, ObtenerAtencionClientesFiltro(), ObtenerClientesSeleccionadosFiltro(), ObtenerAgentesSeleccinados())
                End If
            End If

            If IdEstadoProspecta = 87 Or IdEstadoProspecta = 88 Then
                ConsultarUsuariosEnEdicionOProspecta()
                btnCancelarProspecta.Enabled = True
                btnEditar.Enabled = True

            End If

            
            OcultarColumnasPestañaCliente()
            OcultarColumnasPestañaProspécta()
            OcultarColumnasPestañaMedicion()
            tabProspecta.SelectedIndex = 0

            If ProspectaID <> -1 Then
                chkPlaneacionSemanal_CheckedChanged(Nothing, Nothing)
                chkProyeccionSemanal_CheckedChanged(Nothing, Nothing)
                chkConfirmacionOTSemanal_CheckedChanged(Nothing, Nothing)
                chkEmbarcadoSemanal_CheckedChanged(Nothing, Nothing)
                chkSalidaSemanal_CheckedChanged(Nothing, Nothing)

            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("En este momento no se puede realizar la consulta, intentar en unos minutos")
            Cursor = Cursors.Default
            dtDatosPartidas.Rows.Clear()
            dtDatosPedidos.Rows.Clear()
            gridListaProspecta.DataSource = Nothing
            CargarEncabezadoGridProspecta()
            EncabezadoGridProspecta(gridListaProspecta)
        End Try

    End Sub

    Public Sub RealizarRespaldoParesSicy()
        'Dim FiltroClientes As String = ObtenerClientesSeleccionadosFiltro()
        'Dim FiltroAtencionClientes As String = ObtenerAtencionClientesFiltro()
        'Dim FiltroAgenteID As String = ObtenerAgentesSeleccinados()

        'Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        'ObjPRospecta.RespaldarPares(FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub CargarListaIncidenciasGrid()
        Dim ListaMensajeria As New List(Of Entidades.Mensajeria)
        Dim TablaTiposMotivosIncidencia As DataTable
        Dim objMotivosIncidencia As New Ventas.Negocios.CatalogoMotivosIncidenciaBU
        Dim vTipoEmbarque, vTipoUnidad As New Infragistics.Win.ValueList
        'Dim texto As New Infragistics.Win.ValueLis

        TablaTiposMotivosIncidencia = objMotivosIncidencia.ListaTiposMotivosIncidencias(True)

        For Each fila As DataRow In TablaTiposMotivosIncidencia.Rows
            vTipoEmbarque.ValueListItems.Add(fila.Item("MotivoId").ToString(), fila.Item("Categoría").ToString() + "/" + fila.Item("Tipo Motivo").ToString())
        Next


        gridListaProspecta.DisplayLayout.Bands(0).Columns("*Incidencia").ValueList = vTipoEmbarque

    End Sub

    Private Sub gridDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim ProspectaNueva As Boolean = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        If grid.Name <> "gridParesPorAtado" Then
            grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        End If
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard


        'grid.DisplayLayout.Override.HeaderAppearance.BorderColor = Color.Purple
        'grid.DisplayLayout.Override.HeaderAppearance.BorderColor2 = Color.Purple

        'grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.TwoColor

        '- Set your UltraGrid’s band RowLayoutStyle property to ColumnLayout;
        ' grid.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        'grid.DisplayLayout.Bands(0).Header.Caption = "Linea 2" + vbNewLine + "Linea 4"
        'grid.DisplayLayout.Bands(0).ColHeaderLines = 2


        'band.Columns(0).Header.Caption = "Line 1" & vbCrLf & "Line 2"

        '' Assuming you have added groups to the band, set first group's header's Caption 
        '' to a multiline text.
        'band.Groups(0).Header.Caption = "Multiline" & vbCrLf & "Group Header"

        '' To accomodate the multiline captions, set the ColHeaderLines and 
        '' GroupHeaderLines to 2.
        'band.ColHeaderLines = 2
        'band.GroupHeaderLines = 2



        'grid.DisplayLayout.Bands(0).Header.Caption.
        'If grid.Name = "gridPedidos" Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        If grid.Name = "grdAtnClientes" Or grid.Name = "gridParesPorAtado" Or grid.Name = "gridParesProyectar" Or grid.Name = "grdFiltroClientes" Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub

    Private Function ObtenerTotalParesAtado(ByVal TipoAtado As Integer) As Integer
        Dim Count As Integer = 0
        Dim TipoEmpaqueCliente As Integer = -1

        For Each Fila As UltraGridRow In gridPartidas.Rows
            If Fila.Cells("PrsProsp").Value = 0 Then
                Continue For
            End If

            For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
                If Fila.Cells("ClientesicyId").Value = FilaCliente.Cells("ClienteSicyID").Value Then
                    TipoEmpaqueCliente = FilaCliente.Cells("TipoEmpaqueID").Value
                    Exit For
                End If

                If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
                    Count += Fila.Cells("PrsProsp").Value
                End If
            Next

            If Fila.Cells("PC").Value = "SI" Then
                If Fila.Cells("actual_prog_PEND").Value = Fila.Cells("PrsProsp").Value Then
                    If IsDBNull(Fila.Cells("TipoEmpaqueID").Value) = False Then
                        If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
                            Count += Fila.Cells("PrsProsp").Value
                        End If
                    End If
                End If
            Else
                If IsDBNull(Fila.Cells("TipoEmpaqueID").Value) = False Then
                    If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
                        Count += Fila.Cells("PrsProsp").Value
                    End If
                End If


            End If

        Next
        Return Count
    End Function

    Private Function ActualizarParesAtadoProspecta() As Integer
        Dim TotalParesAtado As Integer = 0

        'Validar restriccion de partida completa

        'Si tiene restriccion de partida partida cumpleta


        'Comprobar cuantos partidas fueron prospectadas

        'For Each Fila As UltraGridRow In gridListaProspecta.Rows
        '    If IsDBNull(Fila.Cells("TipoEmpaqueID").Value) = False Then
        '        If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
        '            'Count += 

        '        End If
        '    End If
        'Next


        'For Each row As UltraGridRow In gridPartidas.Rows
        '    If CInt(row.Cells("Prs Prosp").Value) <> 0 Then
        '        TotalParesAtado = CInt(row.Cells("Prs Prosp").Value)
        '    End If
        'Next


        Return TotalParesAtado
    End Function







    Private Sub LenarParesTotalAtados()
        'Dim TipoEmpaque As Entidades.TipoEmpaque
        'Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        'gridParesPorAtado.DataSource = ObjPRospecta.ObtenerTiposEmpaque()
        'Dim TipoEmpaqueCliente As Integer = -1
        'For Each Fila As UltraGridRow In gridParesPorAtado.Rows
        '    Fila.Cells("Total").Value = 0
        '    'TipoEmpaque = New Entidades.TipoEmpaque
        '    'TipoEmpaque.tipoempaqueid = Fila.Cells("TipoEmpaqueID").Value
        '    'TipoEmpaque.nombre = "0"
        '    'ListaAtados.Add(TipoEmpaque)

        '    ' Fila.Cells("Total").Value = ObtenerTotalParesAtado(Fila.Cells("TipoEmpaqueID").Value)
        'Next

        'For Each Fila As UltraGridRow In gridPartidas.Rows
        '    For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
        '        If Fila.Cells("ClientesicyId").Value = FilaCliente.Cells("ClienteSicyID").Value Then
        '            TipoEmpaqueCliente = FilaCliente.Cells("TipoEmpaqueID").Value
        '            Exit For
        '        End If

        '        For Each FilaAtado As UltraGridRow In gridParesPorAtado.Rows
        '            If FilaAtado.Cells("TipoEmpaqueID").Value = TipoEmpaqueCliente Then
        '                FilaAtado.Cells("Total").Value = CInt(FilaAtado.Cells("Total").Value) + CInt(Fila.Cells("PrsProsp").Value)
        '                Exit For
        '            End If

        '        Next

        '        'For Each TipoAtado As Entidades.TipoEmpaque In ListaAtados
        '        '    If TipoAtado.tipoempaqueid = TipoEmpaqueCliente Then
        '        '        TipoAtado.nombre = CInt(TipoAtado.nombre) + CInt(Fila.Cells("Prs Prosp").Value)
        '        '        Exit For
        '        '    End If
        '        'Next

        '    Next

        '    'If IsDBNull(Fila.Cells("TipoEmpaqueID").Value) = False Then
        '    '    If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
        '    '        Count += Fila.Cells("Prs Prosp").Value
        '    '    End If
        '    'End If
        'Next


        ''For Each Fila As UltraGridRow In gridPartidas.Rows
        ''    For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
        ''        If Fila.Cells("ClientesicyId").Value = FilaCliente.Cells("ClienteSicyID").Value Then
        ''            TipoEmpaqueCliente = FilaCliente.Cells("TipoEmpaqueID").Value
        ''            Exit For
        ''        End If

        ''        If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
        ''            Count += Fila.Cells("Prs Prosp").Value
        ''        End If
        ''    Next


        ''    If IsDBNull(Fila.Cells("TipoEmpaqueID").Value) = False Then
        ''        If Fila.Cells("TipoEmpaqueID").Value = TipoAtado Then
        ''            Count += Fila.Cells("Prs Prosp").Value
        ''        End If
        ''    End If
        ''Next

        ''Dim dtParesTipoAtado As DataTable = New DataTable()
        ''dtParesTipoAtado.Columns.Add("TipoAtadoID")
        ''dtParesTipoAtado.Columns.Add("TipoAtado")
        ''dtParesTipoAtado.Columns.Add("Total")

        ''Dim TotalParesAtado As Integer = 0
        ''Dim TotalParesCaja As Integer = 0
        ''Dim TotalParesCajaArmar As Integer = 0
        ''Dim TotalParesAtadoArmar As Integer = 0


        ''For Each fila As DataRow In dtDatosProspecta.Rows
        ''    If String.IsNullOrEmpty(fila.Item("TipoEmpaqueId").ToString()) = False Then
        ''        Select Case CInt(fila.Item("TipoEmpaqueId").ToString())
        ''            Case 1
        ''                ' TotalParesCaja += CInt(fila.Item(2).ToString())
        ''            Case 2
        ''                ' TotalParesAtado += CInt(fila.Item(2).ToString())
        ''            Case 3
        ''                ' TotalParesCajaArmar += CInt(fila.Item(2).ToString())
        ''            Case 4
        ''                ' TotalParesAtadoArmar += CInt(fila.Item(2).ToString())
        ''        End Select
        ''    End If
        ''Next

        Dim dtParesTipoAtado As DataTable = New DataTable()
        dtParesTipoAtado.Columns.Add("TipoEmpaqueID")
        dtParesTipoAtado.Columns.Add("Descripción")
        dtParesTipoAtado.Columns.Add("Total")

        

        Dim row As DataRow = dtParesTipoAtado.NewRow()
        row("TipoEmpaqueID") = 2
        row("Descripción") = "ATADO"
        row("Total") = 0
        dtParesTipoAtado.Rows.Add(row)

        row = dtParesTipoAtado.NewRow()
        row("TipoEmpaqueID") = 1
        row("Descripción") = "ATADO ARMAR"
        row("Total") = 0
        dtParesTipoAtado.Rows.Add(row)

        row = dtParesTipoAtado.NewRow()
        row("TipoEmpaqueID") = 1
        row("Descripción") = "CAJA"
        row("Total") = 0
        dtParesTipoAtado.Rows.Add(row)


        row = dtParesTipoAtado.NewRow()
        row("TipoEmpaqueID") = 3
        row("Descripción") = "CAJA ARMAR"
        row("Total") = 0
        dtParesTipoAtado.Rows.Add(row)

            

        gridParesPorAtado.DataSource = dtParesTipoAtado


        ''Dim columnToSummarize As UltraGridColumn = gridParesPorAtado.DisplayLayout.Bands(0).Columns("Total")
        ''Dim summary As SummarySettings = gridParesPorAtado.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        ''summary.DisplayFormat = "{0:###,###,##0}"
        ''summary.Appearance.TextHAlign = HAlign.Right
        ''gridParesPorAtado.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


    End Sub


    Private Sub gridParesPorAtado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridParesPorAtado.InitializeLayout
        Dim FormatoNumero As String = "###,###,##0"
        With gridParesPorAtado
            .DisplayLayout.Bands(0).Columns("TipoEmpaqueID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Descripción").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Total").Format = FormatoNumero
           
            SumarizarColumnaGrid(gridParesPorAtado, "Total", "Sumarizar " + "Total")

        End With
    End Sub


    Private Sub CargarParesConfirmados()
        Dim dtParesProyectados As DataTable = New DataTable()
        dtParesProyectados.Columns.Add("ID")
        dtParesProyectados.Columns.Add("Descripción")
        dtParesProyectados.Columns.Add("Total")

        Dim TotalParesConfirmados As Integer = 0
        Dim TotalParesNoConfirmados As Integer = 0
        Dim TotalParesProyectar As Integer = 0


        'For Each fila As DataRow In dtDatosProspecta.Rows
        '    If String.IsNullOrEmpty(fila.Item("TipoEmpaqueId").ToString()) = False Then
        '        Select Case CInt(fila.Item("TipoEmpaqueId").ToString())
        '            Case 1
        '                ' TotalParesCaja += CInt(fila.Item(2).ToString())
        '            Case 2
        '                ' TotalParesAtado += CInt(fila.Item(2).ToString())
        '            Case 3
        '                ' TotalParesCajaArmar += CInt(fila.Item(2).ToString())
        '            Case 4
        '                ' TotalParesAtadoArmar += CInt(fila.Item(2).ToString())
        '        End Select
        '    End If
        'Next

        Dim row As DataRow = dtParesProyectados.NewRow()
        row("Descripción") = "PRS. CONFIRMADOS"
        row("Total") = 0
        dtParesProyectados.Rows.Add(row)

        row = dtParesProyectados.NewRow()
        row("Descripción") = "PRS. SIN CONFIRMAR"
        row("Total") = 0
        dtParesProyectados.Rows.Add(row)

       

        gridParesProyectar.DataSource = dtParesProyectados

    End Sub

    Private Sub CargarUsuariosAtencionClientes()
        Dim objColaboradorAtencionClientes As New Ventas.Negocios.ProspectaBU
        Dim Tabla_ListadoParametros As DataTable
        Tabla_ListadoParametros = objColaboradorAtencionClientes.ConsultaUsuarioAtencionClientes()
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        ' cmbAtnClientes.DataSource = Tabla_ListadoParametros
        ' cmbAtnClientes.DisplayMember = "Nombre"
        'cmbAtnClientes.ValueMember = "IdColaborador"
    End Sub

    Private Sub ObtenerFechaSemana()

    End Sub

    Private Sub ObtenerNumeroSemana()
        Dim NumeroSemana As Integer = 0
        Dim FormatoNumeroSemana As String = String.Empty
        NumeroSemana = DatePart(DateInterval.WeekOfYear, dtmFechaInicio.Value)
        txtSemana.Text = NumeroSemana.ToString() + "-" + dtmFechaInicio.Value.Year.ToString()
    End Sub



    Private Sub gridParesProyectar_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridParesProyectar.InitializeLayout
        Dim FormatoNumero As String = "###,###,##0"
        With gridParesProyectar
            .DisplayLayout.Bands(0).Columns("ID").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Descripción").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Total").Format = FormatoNumero
            SumarizarColumnaGrid(gridParesProyectar, "Total", "Sumarizar " + "Total")

        End With
    End Sub

    'Private Sub cmbAtnClientes_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim ValorFiltro As Integer = 0
    '    'ValorFiltro = cmbAtnClientes.SelectedValue
    '    If ValorFiltro > 0 Then
    '        dtDatosProspecta.Select("clie_colaboradorid_atnc = 230")
    '    Else
    '    End If
    'End Sub

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

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        asignaFormato_Columna(grid)

    End Sub

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


    Private Sub CargarEncabezadosGrid()
        CargarEncabezadoGridProspecta()
        CargarEncabezadoPedidos()
        CargarEncabezadoPartidas()

        'gridListaProspecta.DisplayLayout.Bands(0).Columns(1).Header.Caption = "Linea 2"

        'Dim elemento = gridListaProspecta.DisplayLayout.Bands(0).Columns(1).Header.GetUIElement()
        'elemento.Rect.X

        'gridListaProspecta.DisplayLayout.Bands(0).Columns(1).Header.ExclusiveColScrollRegion
        'gridListaProspecta.DisplayLayout.Bands(0).ColHeaderLines = 2

        EncabezadoGridProspecta(gridListaProspecta)
        DiseñoEncabezadoPedidos(gridPedidos)
        DiseñoEnzabezadoPartidas(gridPartidas)


        'gridListaProspecta.DisplayLayout.Override.HeaderAppearance.BorderColor = Color.Purple
        'gridListaProspecta.DisplayLayout.Override.HeaderAppearance.BorderColor2 = Color.Purple

        'gridListaProspecta.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        'gridListaProspecta.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        'gridListaProspecta.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

    End Sub


    Private Sub DiseñoEnzabezadoPartidas(ByVal grid As UltraGrid)
        Dim IndicePrimerColumna As Integer
        Dim Cantidad_Grupos As Integer = 0
        Dim Seleccionados As Integer = 0
        Dim TotalAtadosNormalesApartables As Integer = 0
        Dim TotalAtadoPuntoApartables As Integer = 0
        Dim TotalDestalladosApartables As Integer = 0
        Dim TotalNormalesDestallar As Integer = 0
        Dim TotalPuntoDestallar As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim NumeroDiasProspecta As Integer = 0
        Dim DiaPlaneacion As Integer = 0
        Dim DiaProyeccion As Integer = 0
        Dim DiaConfirmacion As Integer = 0
        Dim DiaEmbarque As Integer = 0
        Dim DiaSalida As Integer = 0


        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
        IndicePrimerColumna = 20

        Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna

        NumeroDiasProspecta = DiasProspecta.Count - 1
        DiaPlaneacion = 33
        DiaProyeccion = 33 + NumeroDiasProspecta + 1 + 1
        DiaConfirmacion = DiaProyeccion + NumeroDiasProspecta + 1 + 3
        DiaEmbarque = DiaConfirmacion + NumeroDiasProspecta + 1 + 3
        DiaSalida = DiaEmbarque + NumeroDiasProspecta + 1 + 3


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 18 Or n > 22) And (n < 23 Or n > 27) And (n < 33 Or n > DiaProyeccion - 1) And (n < DiaProyeccion Or n > DiaConfirmacion - 1) And (n < DiaConfirmacion Or n > DiaEmbarque - 1) And (n < DiaEmbarque Or n > DiaSalida - 1) And (n < DiaSalida Or n > (DiaSalida + NumeroDiasProspecta + 4)) And (n < 46 Or (n >= 48 And n < UltimaColumna)) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                If n = 28 Or n = 29 Or n = 30 Or n = 31 Or n = 32 Then
                    grupo.Hidden = True
                End If
            Else
                If n >= 18 And n <= 22 Then
                    If n = 18 Then
                        Dim NombreColumna As String
                        NombreColumna = "FPROGRAMACION"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= 23 And n <= 27 Then
                    If n = 23 Then
                        Dim NombreColumna As String
                        NombreColumna = "ACTUAL FPROGRAMACION"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("ACTUAL FPROGRAMACION")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If



                ElseIf n >= 33 And n <= DiaProyeccion - 1 Then
                    If n = 33 Then
                        Dim NombreColumna As String
                        NombreColumna = "PROSPECTA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROSPECTA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    'If ProspectaID = -1 Then
                    '    Dim Grupo As UltraGridGroup = rootBand.Groups("Planeación")
                    '    Grupo.Hidden = True
                    'End If

                ElseIf n >= DiaProyeccion And n <= DiaConfirmacion - 1 Then
                    If n = DiaProyeccion Then
                        Dim NombreColumna As String
                        NombreColumna = "PROYECCIÓN"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= DiaConfirmacion And n <= DiaEmbarque - 1 Then
                    If n = DiaConfirmacion Then
                        Dim NombreColumna As String
                        NombreColumna = "CONFIRMACIÓN OT"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        Grupo.Hidden = True
                    End If


                ElseIf n >= DiaEmbarque And n <= DiaSalida - 1 Then
                    If n = DiaEmbarque Then
                        Dim NombreColumna As String
                        NombreColumna = "EMBARQUE"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= DiaSalida And n <= (DiaSalida + NumeroDiasProspecta + 4) Then
                    If n = DiaSalida Then
                        Dim NombreColumna As String
                        NombreColumna = "SALIDA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        Grupo.Hidden = True
                    End If

                End If

                IndicePrimerColumna += 1
            End If
        Next

    End Sub

    Private Sub DiseñoEncabezadoPedidos(ByVal grid As UltraGrid)



        Dim IndicePrimerColumna As Integer
        Dim Cantidad_Grupos As Integer = 0
        Dim Seleccionados As Integer = 0
        Dim TotalAtadosNormalesApartables As Integer = 0
        Dim TotalAtadoPuntoApartables As Integer = 0
        Dim TotalDestalladosApartables As Integer = 0
        Dim TotalNormalesDestallar As Integer = 0
        Dim TotalPuntoDestallar As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim NumeroDiasProspecta As Integer = 0
        Dim DiaPlaneacion As Integer = 0
        Dim DiaProyeccion As Integer = 0
        Dim DiaConfirmacion As Integer = 0
        Dim DiaEmbarque As Integer = 0
        Dim DiaSalida As Integer = 0

        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
        IndicePrimerColumna = 20

        Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna

        NumeroDiasProspecta = DiasProspecta.Count - 1
        DiaPlaneacion = 28
        DiaProyeccion = 28 + NumeroDiasProspecta + 1 + 1
        DiaConfirmacion = DiaProyeccion + NumeroDiasProspecta + 1 + 3
        DiaEmbarque = DiaConfirmacion + NumeroDiasProspecta + 1 + 3
        DiaSalida = DiaEmbarque + NumeroDiasProspecta + 1 + 3


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 14 Or n > 18) And (n < 19 Or n > 23) And (n < 28 Or n > DiaProyeccion - 1) And (n < DiaProyeccion Or n > DiaConfirmacion - 1) And (n < DiaConfirmacion Or n > DiaEmbarque - 1) And (n < DiaEmbarque Or n > DiaSalida - 1) And (n < DiaSalida Or n > (DiaSalida + NumeroDiasProspecta + 4)) And (n < 46 Or (n >= 48 And n < UltimaColumna)) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                If n = 24 Or n = 25 Or n = 26 Or n = 27 Then
                    grupo.Hidden = True
                End If

            Else
                If n >= 14 And n <= 18 Then
                    If n = 14 Then
                        Dim NombreColumna As String
                        NombreColumna = "FPROGRAMACION"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        Grupo.Hidden = True
                    End If
                ElseIf n >= 19 And n <= 23 Then
                    If n = 19 Then
                        Dim NombreColumna As String
                        NombreColumna = "ACTUAL FPROGRAMACION"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("ACTUAL FPROGRAMACION")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    'If ProspectaID = -1 Then
                    '    Dim Grupo As UltraGridGroup = rootBand.Groups("Planeación")
                    '    Grupo.Hidden = True
                    'End If

                ElseIf n >= 28 And n <= DiaProyeccion - 1 Then
                    If n = 28 Then
                        Dim NombreColumna As String
                        NombreColumna = "PROSPECTA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROSPECTA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    'If ProspectaID = -1 Then
                    '    Dim Grupo As UltraGridGroup = rootBand.Groups("Planeación")
                    '    Grupo.Hidden = True
                    'End If
                ElseIf n >= DiaProyeccion And n <= DiaConfirmacion - 1 Then
                    If n = DiaProyeccion Then
                        Dim NombreColumna As String
                        NombreColumna = "PROYECCIÓN"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= DiaConfirmacion And n <= DiaEmbarque - 1 Then
                    If n = DiaConfirmacion Then
                        Dim NombreColumna As String
                        NombreColumna = "CONFIRMACIÓN OT"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        Grupo.Hidden = True
                    End If


                ElseIf n >= DiaEmbarque And n <= DiaSalida - 1 Then
                    If n = DiaEmbarque Then
                        Dim NombreColumna As String
                        NombreColumna = "EMBARQUE"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= DiaSalida And n <= (DiaSalida + NumeroDiasProspecta + 4) Then
                    If n = DiaSalida Then
                        Dim NombreColumna As String
                        NombreColumna = "SALIDA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        Grupo.Hidden = True
                    End If

                End If

                IndicePrimerColumna += 1
            End If
        Next
    End Sub


    Private Sub EncabezadoGridProspecta(ByVal grid As UltraGrid)
        Dim IndicePrimerColumna As Integer
        Dim Cantidad_Grupos As Integer = 0
        Dim Seleccionados As Integer = 0
        Dim TotalAtadosNormalesApartables As Integer = 0
        Dim TotalAtadoPuntoApartables As Integer = 0
        Dim TotalDestalladosApartables As Integer = 0
        Dim TotalNormalesDestallar As Integer = 0
        Dim TotalPuntoDestallar As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim NumeroDiasProspecta As Integer = 0
        Dim DiaPlaneacion As Integer = 0
        Dim DiaProyeccion As Integer = 0
        Dim DiaConfirmacion As Integer = 0
        Dim DiaEmbarque As Integer = 0
        Dim DiaSalida As Integer = 0

        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
        IndicePrimerColumna = 20

        Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna


        NumeroDiasProspecta = DiasProspecta.Count - 1

        'Columnas de incio de cada seccion (suma columna siguiente (1) + numero de columnas de los totales)
        DiaPlaneacion = 60
        DiaProyeccion = 60 + NumeroDiasProspecta + 1 + 1
        DiaConfirmacion = DiaProyeccion + NumeroDiasProspecta + 1 + 3
        DiaEmbarque = DiaConfirmacion + NumeroDiasProspecta + 1 + 3
        DiaSalida = DiaEmbarque + NumeroDiasProspecta + 1 + 3

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If


            '0 AgregarColumna(gridListaProspecta, " ", " ", False, True, Nothing, 100)
            '1 AgregarColumna(gridListaProspecta, "Cliente", "Cliente", False, True, Nothing, 300)
            '2 AgregarColumna(gridListaProspecta, "Edita", "Edita", False, True, ColorInfoCliente, 50)
            '3 AgregarColumna(gridListaProspecta, "Edición", "Edición", False, True, ColorInfoCliente, 40)
            '4 AgregarColumna(gridListaProspecta, "PR", "PR", False, True, ColorInfoCliente, 30)
            '5 AgregarColumna(gridListaProspecta, "BL", "BL", False, True, ColorInfoCliente, 30)
            '6 AgregarColumna(gridListaProspecta, "SINV", "Inv", False, True, ColorInfoCliente, 30)
            '7 AgregarColumna(gridListaProspecta, "COTS", "Cots", False, True, ColorInfoCliente, 30, True, , HAlign.Right)
            '8 AgregarColumna(gridListaProspecta, "PAGP", "Pagp", False, True, ColorInfoCliente, 35)
            '9 AgregarColumna(gridListaProspecta, "Bloqueo Entrega", "Bloqueo Entrega", False, True, ColorInfoCliente, 150)
            '10 AgregarColumna(gridListaProspecta, "BL A", "BL A", False, True, ColorInfoCliente, 30)
            '11 AgregarColumna(gridListaProspecta, "S/INV A", "S/Inv", False, True, ColorInfoCliente, 30)
            '12 AgregarColumna(gridListaProspecta, "COTS A", "Cots", False, True, ColorInfoCliente, 30, True)
            '13 AgregarColumna(gridListaProspecta, "PAGP A", "Pagp", False, True, ColorInfoCliente, 35)
            '14 AgregarColumna(gridListaProspecta, "Bloqueo Entrega A", "Bloqueo Entrega", False, True, ColorInfoCliente, 150)
            '15 AgregarColumna(gridListaProspecta, "Ejecutiva", "AtnCtes", False, True, ColorInfoCliente, 70)
            '16 AgregarColumna(gridListaProspecta, "Agente", "Agente", False, True, ColorInfoCliente, 240)
            '17 AgregarColumna(gridListaProspecta, "Empaque", "Empaque", False, True, ColorInfoCliente, 120)
            '18 AgregarColumna(gridListaProspecta, "EtEsp", "EtEsp", False, True, ColorInfoCliente, 40)
            '19 AgregarColumna(gridListaProspecta, "ImPPCP", "ImPPCP", False, True, ColorInfoCliente, 50)
            '20 AgregarColumna(gridListaProspecta, "DE", "DE", False, True, ColorInfoCliente, 30)
            '21 AgregarColumna(gridListaProspecta, "Plazo 0", "Plazo 0", False, True, ColorInfoCliente, 35)
            '22 AgregarColumna(gridListaProspecta, "Cita", "Cita", False, True, ColorInfoCliente, 30)
            '23 AgregarColumna(gridListaProspecta, "DA", "DA", False, True, ColorInfoCliente, 30)
            '24 AgregarColumna(gridListaProspecta, "PC", "PC", False, True, ColorInfoCliente, 30)

            '25 AgregarColumna(gridListaProspecta, "total_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '26 AgregarColumna(gridListaProspecta, "total_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '27 AgregarColumna(gridListaProspecta, "total_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '28 AgregarColumna(gridListaProspecta, "total_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)


            '29 AgregarColumna(gridListaProspecta, "pros_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '30 AgregarColumna(gridListaProspecta, "pros_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '31 AgregarColumna(gridListaProspecta, "pros_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '32 AgregarColumna(gridListaProspecta, "pros_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)

            '33 AgregarColumna(gridListaProspecta, "prog_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '34 AgregarColumna(gridListaProspecta, "prog_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '35 AgregarColumna(gridListaProspecta, "prog_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '36 AgregarColumna(gridListaProspecta, "prog_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '37 AgregarColumna(gridListaProspecta, "prog_suma", "Suma", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, True)

            '38 AgregarColumna(gridListaProspecta, "actual_total_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '39 AgregarColumna(gridListaProspecta, "actual_total_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '40 AgregarColumna(gridListaProspecta, "actual_total_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '41 AgregarColumna(gridListaProspecta, "actual_total_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)

            '42 AgregarColumna(gridListaProspecta, "actual_pros_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '43 AgregarColumna(gridListaProspecta, "actual_pros_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '44 AgregarColumna(gridListaProspecta, "actual_pros_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '45 AgregarColumna(gridListaProspecta, "actual_pros_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)

            '46 AgregarColumna(gridListaProspecta, "actual_prog_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '47 AgregarColumna(gridListaProspecta, "actual_prog_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '48 AgregarColumna(gridListaProspecta, "actual_prog_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '49 AgregarColumna(gridListaProspecta, "actual_prog_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right)
            '50 AgregarColumna(gridListaProspecta, "actual_prog_suma", "Suma", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, True)

            '51 AgregarColumna(gridListaProspecta, "Conf", "Conf", False, True, ColorInfoProspecta, 30, False)
            '52 AgregarColumna(gridListaProspecta, "Confirma", "Confirma", False, True, ColorInfoProspecta, 100)
            '53 AgregarColumna(gridListaProspecta, "FConfirmacion", "FConfirmacion", False, True, ColorInfoProspecta, 100)
            '54 AgregarColumna(gridListaProspecta, "*Incidencia", "*Incidencia", False, True, ColorInfoProspecta, 300, False, ModoEdicion)
            '55 AgregarColumna(gridListaProspecta, "*Observaciones", "*Observaciones", False, True, ColorInfoProspecta, 300, False, ModoEdicion)

            '56 AgregarColumna(gridListaProspecta, "plan_Lun", "Lun", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '57 AgregarColumna(gridListaProspecta, "plan_Mar", "Mar", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '58 AgregarColumna(gridListaProspecta, "plan_Mie", "Mie", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '59 AgregarColumna(gridListaProspecta, "plan_Jue", "Jue", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '60 AgregarColumna(gridListaProspecta, "plan_Vie", "Vie", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '61 AgregarColumna(gridListaProspecta, "plan_Sab", "Sab", False, False, ColorInfoMedicion, 45, True, ModoEdicion)
            '62 AgregarColumna(gridListaProspecta, "Prs Prosp", "Total Prs Prospecta", False, False, ColorInfoMedicion, 90, True)

            '63 AgregarColumna(gridListaProspecta, "proy_Lun", "Lun", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '64 AgregarColumna(gridListaProspecta, "proy_Mar", "Mar", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '65 AgregarColumna(gridListaProspecta, "proy_Mie", "Mie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '66 AgregarColumna(gridListaProspecta, "proy_Jue", "Jue", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '67 AgregarColumna(gridListaProspecta, "proy_Vie", "Vie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '68 AgregarColumna(gridListaProspecta, "proy_Sab", "Sab", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '69 AgregarColumna(gridListaProspecta, "Prs Proy", "Prs Proy", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '70 AgregarColumna(gridListaProspecta, "% Prs Proy", "% Prs Proy", OcultarColumnas, False, ColorInfoMedicion, 80)
            '71 AgregarColumna(gridListaProspecta, "Prs No Proy", "Prs No Proy", OcultarColumnas, False, ColorInfoMedicion, 80, True)


            '68 AgregarColumna(gridListaProspecta, "ConfOT_Lun", "Lun", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '69 AgregarColumna(gridListaProspecta, "ConfOT_Mar", "Mar", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '70 AgregarColumna(gridListaProspecta, "ConfOT_Mie", "Mie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '71 AgregarColumna(gridListaProspecta, "ConfOT_Jue", "Jue", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '72 AgregarColumna(gridListaProspecta, "ConfOT_Vie", "Vie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '73 AgregarColumna(gridListaProspecta, "ConfOT_Sab", "Sab", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '74 AgregarColumna(gridListaProspecta, "Prs ConfOT", "Prs ConfOT", OcultarColumnas, False, ColorInfoMedicion, 80, True)
            '75 AgregarColumna(gridListaProspecta, "% Prs ConfOT", "% Prs ConfOT", OcultarColumnas, False, ColorInfoMedicion, 80)
            '76 AgregarColumna(gridListaProspecta, "Prs No ConfOT", "Prs No ConfOT", OcultarColumnas, False, ColorInfoMedicion, 80, True)

            '77 AgregarColumna(gridListaProspecta, "Emb_Lun", "Lun", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '78 AgregarColumna(gridListaProspecta, "Emb_Mar", "Mar", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '79 AgregarColumna(gridListaProspecta, "Emb_Mie", "Mie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '80 AgregarColumna(gridListaProspecta, "Emb_Jue", "Jue", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '81 AgregarColumna(gridListaProspecta, "Emb_Vie", "Vie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '82 AgregarColumna(gridListaProspecta, "Emb_Sab", "Sab", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '83 AgregarColumna(gridListaProspecta, "Prs Emb", "Prs Emb", OcultarColumnas, False, ColorInfoMedicion, 80, True)
            '84 AgregarColumna(gridListaProspecta, "% Prs Emb", "% Prs Emb", OcultarColumnas, False, ColorInfoMedicion, 80)
            '85 AgregarColumna(gridListaProspecta, "Prs No Emb", "Prs No Emb", OcultarColumnas, False, ColorInfoMedicion, 80, True)


            '86 AgregarColumna(gridListaProspecta, "Sal_Lun", "Lun", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '87 AgregarColumna(gridListaProspecta, "Sal_Mar", "Mar", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '88 AgregarColumna(gridListaProspecta, "Sal_Mie", "Mie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '89 AgregarColumna(gridListaProspecta, "Sal_Jue", "Jue", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '90 AgregarColumna(gridListaProspecta, "Sal_Vie", "Vie", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '91 AgregarColumna(gridListaProspecta, "Sal_Sab", "Sab", OcultarColumnas, False, ColorInfoMedicion, 45, True)
            '92 AgregarColumna(gridListaProspecta, "Prs Sal", "Prs Sal", OcultarColumnas, False, ColorInfoMedicion, 80, True)
            '93 AgregarColumna(gridListaProspecta, "% Prs Sal", "% Prs Sal", OcultarColumnas, False, ColorInfoMedicion, 80)
            '94 AgregarColumna(gridListaProspecta, "Prs No Sal", "Prs No Sal", OcultarColumnas, False, ColorInfoMedicion, 80)



            '95 AgregarColumna(gridListaProspecta, "AtencionClienteID", "AtencionClienteID", True, False, Color.Black)
            '96 AgregarColumna(gridListaProspecta, "TipoEmpaqueID", "TipoEmpaqueID", True, False, Color.Black)
            '97 AgregarColumna(gridListaProspecta, "clienteId", "clienteId", True, False, Color.Black)
            '98 AgregarColumna(gridListaProspecta, "ClienteSicyID", "ClienteSicyID", True, False, Color.Black)
            '99        AgregarColumna(gridListaProspecta, "ClientesayId", "ClientesayId", True, False, Color.Black)
            '100 AgregarColumna(gridListaProspecta, "ProspectaID", "ProspectaID", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "ProspectaClienteID", "ProspectaClienteID", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "AtencionClienteID1", "AtencionClienteID1", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "TipoEmpaqueID1", "TipoEmpaqueID1", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "ClienteSayID1", "ClienteSayID1", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "ClienteSicyID1", "clienteId", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "CantidaPares", "clienteId", True, False, Color.Black)
            'AgregarColumna(gridListaProspecta, "ClienteSayID", "ClienteSayID", True, False, Color.Black)



            If (n <= 28 Or n > 45) And (n < 6 Or n > 10) And (n < 11 Or n > 15) And (n < 26 Or n > 29) And (n < 30 Or n > 33) And (n < 34 Or n > 38) And (n < 39 Or n > 42) And (n < 43 Or n > 46) And (n < 47 Or n > 51) And (n < 52 Or n > 56) And (n < 60 Or n > DiaProyeccion - 1) And (n < DiaProyeccion Or n > (DiaConfirmacion - 1)) And (n < DiaConfirmacion Or n > (DiaEmbarque - 1)) And (n < DiaEmbarque Or n > (DiaSalida - 1)) And (n < DiaSalida Or n > (DiaSalida + NumeroDiasProspecta + 4)) And (n < 46 Or (n >= 48 And n < UltimaColumna)) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                If n = 2 Or n = 3 Then
                    If ProspectaID = -1 Then
                        grupo.Hidden = True
                    End If
                End If
            Else
                If n >= 6 And n <= 10 Then
                    If n = 6 Then
                        Dim NombreColumna As String
                        NombreColumna = "INFO. PROSPECTA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        'Grupo.CellAppearance.BorderColor = Color.Black

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("INFO. PROSPECTA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If



                ElseIf n >= 11 And n <= 15 Then
                    If n = 11 Then
                        Dim NombreColumna As String
                        NombreColumna = "INFO. PROSPECTA ACTUAL"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("INFO. PROSPECTA ACTUAL")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("INFO. PROSPECTA ACTUAL")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= 26 And n <= 29 Then
                    If n = 26 Then
                        Dim NombreColumna As String
                        NombreColumna = "PEND X ENTREGAR"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PEND X ENTREGAR")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PEND X ENTREGAR")
                        Grupo.Hidden = True
                    End If


                ElseIf n >= 30 And n <= 33 Then
                    If n = 30 Then
                        Dim NombreColumna As String
                        NombreColumna = "FPROSPECTA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROSPECTA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROSPECTA")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= 34 And n <= 38 Then
                    If n = 34 Then
                        Dim NombreColumna As String
                        NombreColumna = "FPROGRAMACION"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("FPROGRAMACION")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= 39 And n <= 42 Then
                    If n = 39 Then
                        Dim NombreColumna As String
                        If ProspectaID = -1 Then
                            NombreColumna = "PEND X ENTREGAR "
                        Else
                            NombreColumna = "ACTUAL PEND X ENTREGAR"
                        End If
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup

                        If ProspectaID = -1 Then
                            Grupo = rootBand.Groups("PEND X ENTREGAR ")
                        Else
                            Grupo = rootBand.Groups("ACTUAL PEND X ENTREGAR")
                        End If

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If


                ElseIf n >= 43 And n <= 46 Then
                    If n = 43 Then
                        Dim NombreColumna As String
                        If ProspectaID = -1 Then
                            NombreColumna = "FPROSPECTA "
                        Else
                            NombreColumna = "ACTUAL FPROSPECTA"
                        End If
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup
                        If ProspectaID = -1 Then
                            Grupo = rootBand.Groups("FPROSPECTA ")
                        Else
                            Grupo = rootBand.Groups("ACTUAL FPROSPECTA")
                        End If
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 47 And n <= 51 Then
                    If n = 47 Then
                        Dim NombreColumna As String
                        If ProspectaID = -1 Then
                            NombreColumna = "FPROGRAMACION "
                        Else
                            NombreColumna = "ACTUAL FPROGRAMACION"
                        End If

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup
                        If ProspectaID = -1 Then
                            Grupo = rootBand.Groups("FPROGRAMACION ")
                        Else
                            Grupo = rootBand.Groups("ACTUAL FPROGRAMACION")

                        End If
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 52 And n <= 56 Then
                    If n = 52 Then
                        Dim NombreColumna As String
                        NombreColumna = "CONFIRMACIÓN CLIENTE"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN CLIENTE")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 60 And n <= (DiaProyeccion - 1) Then
                    If n = 60 Then
                        Dim NombreColumna As String
                        NombreColumna = "PROSPECTA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROSPECTA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If


                ElseIf n >= DiaProyeccion And n <= (DiaConfirmacion - 1) Then
                    If n = (DiaProyeccion) Then
                        Dim NombreColumna As String
                        NombreColumna = "PROYECCIÓN"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= (DiaConfirmacion) And n <= (DiaEmbarque - 1) Then
                    If n = (DiaConfirmacion) Then
                        Dim NombreColumna As String
                        NombreColumna = "CONFIRMACIÓN OT"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("CONFIRMACIÓN OT")
                        Grupo.Hidden = True
                    End If

                ElseIf n >= (DiaEmbarque) And n <= (DiaSalida - 1) Then
                    If n = (DiaEmbarque) Then
                        Dim NombreColumna As String
                        NombreColumna = "EMBARQUE"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("EMBARQUE")
                        Grupo.Hidden = True
                    End If
                ElseIf (n >= DiaSalida) And n <= (DiaSalida + NumeroDiasProspecta + 4) Then
                    If n = DiaSalida Then
                        Dim NombreColumna As String
                        NombreColumna = "SALIDA"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                    If ProspectaID = -1 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("SALIDA")
                        Grupo.Hidden = True
                    End If
                End If

                IndicePrimerColumna += 1
            End If
        Next
    End Sub

    Private Function NombreColumnaModificar(ByVal NombreColumna As String) As Boolean
        Dim Existe As Boolean = False
        If NombreColumna = "PrsProsp" Then
            Existe = True
            'ElseIf NombreColumna = "% Prs Proy" Then
            '    Existe = True
            'ElseIf NombreColumna = "Prs No Proy" Then
            '    Existe = True
            'ElseIf NombreColumna = "% Prs ConfOT" Then
            '    Existe = True
            'ElseIf NombreColumna = "Prs No ConfOT" Then
            '    Existe = True
            'ElseIf NombreColumna = "% Prs Emb" Then
            '    Existe = True
            'ElseIf NombreColumna = "Prs No Emb" Then
            '    Existe = True
            'ElseIf NombreColumna = "% Prs Sal" Then
            '    Existe = True
            'ElseIf NombreColumna = "Prs No Sal" Then
            '    Existe = True
        End If
        Return Existe
    End Function



    Private Sub gridListaProspecta_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridListaProspecta.AfterCellUpdate
        Dim Row As UltraGridRow
        Dim TotalParesProsp As Integer = 0
        Dim EsColumnaActualizable As Boolean = False

        If ModoEdicion = True Then
            If e.Cell.Row.IsFilterRow = False Then
                Row = e.Cell.Row
                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    If e.Cell.Column.Key = "plan_" + dia.NombreDia + dia.NumeroDia.ToString() Then
                        EsColumnaActualizable = True
                    End If
                Next


                If EsColumnaActualizable = True Then
                    If Row.Cells("PA").Value = "SI" Then
                        ActualizarDistribuccionParesPlaneacion(e.Cell)
                    Else

                        ActualizarDistribuccionParesPlaneacionCliente(e.Cell)
                    End If
                End If



            End If
        End If
    End Sub



    Private Sub ActualizarDistribuccionParesPlaneacionCliente(ByVal celda As UltraGridCell)
        Try
            Dim TotalParesProsp As Integer = 0
            Dim fila As UltraGridRow = celda.Row
            Dim valorfila As String = ""
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                If IsDBNull(fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value) = False Then
                    TotalParesProsp += fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value
                End If
            Next


            fila.Cells("PrsProsp").Value = TotalParesProsp
            If ValorGuardado = False Then
                fila.Cells("PrsProsp").Appearance.ForeColor = Color.Purple
            End If

        Catch ex As Exception
            Dim valor As String
            valor = 0
        End Try

        'Dim SumaPlaneacion As Integer = 0
        'For Each Dia As Entidades.ProspectaDias In DiasProspecta
        '    If IsDBNull(row.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
        '        SumaPlaneacion += CInt(row.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
        '    End If
        'Next
    End Sub

    Private Sub ActualizarDistribuccionParesPlaneacion(ByVal celda As UltraGridCell)

        Dim SumaPlaneacion As Integer = 0
        Dim SumaPareaProspectaAntesActualizar As Integer = 0
        Dim SumaParesProgramacion As Integer = 0
        Dim PartidaCompleta As String = String.Empty
        Dim EsColumnadePlaneacionProspecta As Boolean = False

        Dim fila As UltraGridRow = celda.Row


        'En cada actulizacion del valor actualizar el total   

        'Son las columnas que se modifican en este evento y para que no se cicle cada vez que se actualizan se realiza un return
        If NombreColumnaModificar(celda.Column.Key.ToString()) = True Then
            Return
        End If

        If celda.Column.Key.ToString() = " " Or celda.Column.Key.ToString() = "actual_prog_suma" Then
            Return
        End If

        If celda.Column.Key.ToString() = "*Observaciones" Then
            celda.Appearance.ForeColor = Color.Purple
        ElseIf celda.Column.Key.ToString() = "*Incidencia" Then
            celda.Appearance.ForeColor = Color.Purple
        ElseIf celda.Column.Key.ToString() = "Conf" Then
            celda.Appearance.ForeColor = Color.Purple
        ElseIf celda.Column.Key.ToString() = "Confirma" Then
            celda.Appearance.ForeColor = Color.Purple
        ElseIf celda.Column.Key.ToString() = "FConfirmacion" Then
            celda.Appearance.ForeColor = Color.Purple
        Else

            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                If celda.Column.Key.ToString() = "plan_" + DIA.NombreDia + DIA.NumeroDia.ToString() Then
                    EsColumnadePlaneacionProspecta = True
                End If
            Next

            Dim vazlordia As Int32

            For Each Dia As Entidades.ProspectaDias In DiasProspecta
                If IsDBNull(fila.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
                    vazlordia = CInt(fila.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
                    SumaPlaneacion += CInt(fila.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)

                End If
            Next

            '  SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(fila.Cells("plan_Mar").Value) + CInt(fila.Cells("plan_Mie").Value) + CInt(fila.Cells("plan_Jue").Value) + CInt(fila.Cells("plan_Vie").Value) + CInt(fila.Cells("plan_Sab").Value)

            If ProspectaID <> -1 Then
                ActualizarParesTotales(celda.Row, SumaPlaneacion)
            End If


            fila.Cells("PrsProsp").Value = SumaPlaneacion
            '"actual_prog_suma"

          

            If EsColumnadePlaneacionProspecta = True Then

                If celda.Column.DataType <> GetType(Boolean) Or IsNothing(celda.Column.ValueList) = False Then
                    Dim EsModoEdicion As Boolean = celda.IsInEditMode

                    If EsModoEdicion = True Then
                        'Si el usuario modifica el valor de la celda
                        If ValorGuardado = False Then
                            If IsNumeric(celda.Column.Editor.CurrentEditText) = True Then

                                If ValidarPartidaCompleta(fila) = True Then
                                    celda.Appearance.ForeColor = Color.Purple
                                Else
                                    celda.Appearance.ForeColor = Color.OrangeRed
                                End If
                                'show_message("Aviso", "Es numero")
                            Else
                                Return
                            End If
                        End If

                    Else
                        'Si se modifica el valor de la celda dentro del codigo
                        If ValorGuardado = False Then 'La prospceta se esta guardando
                            If ValidarPartidaCompleta(fila) = True Then
                                celda.Appearance.ForeColor = Color.Purple
                            Else
                                celda.Appearance.ForeColor = Color.OrangeRed
                            End If

                        End If



                    End If
                End If
               


                If ValorGuardado = False Then
                    If ValidarPartidaCompleta(fila) = True Then
                        fila.Cells("PrsProsp").Appearance.ForeColor = Color.Purple
                    Else
                        If fila.Cells("actual_prog_PEND").Value = fila.Cells("PrsProsp").Value Then
                            fila.Cells("PrsProsp").Appearance.ForeColor = Color.Purple
                        Else
                            fila.Cells("PrsProsp").Appearance.ForeColor = Color.OrangeRed
                        End If
                    End If
                End If

            End If

        End If
    End Sub

    Private Function ValidarPartidaCompleta(ByVal fila As UltraGridRow) As Boolean
        Dim SumaParesProgramacion As Integer = 0
        If fila.IsFilterRow = False Then
            'Dim ialm As Int32 = CInt(fila.Cells("actual_prog_IALM").Value)
            'Dim ipro As Int32 = CInt(fila.Cells("actual_prog_IPRO").Value)
            'Dim axc As Int32 = CInt(fila.Cells("actual_prog_AXC").Value)

            If IsDBNull(fila.Cells("PrsProsp").Value) = True Then
                Return False
            End If

            Dim actual_prog_suma As Integer = CInt(fila.Cells("PrsProsp").Value)


            SumaParesProgramacion = actual_prog_suma
            If fila.Cells("PC").Value = "SI" Then
                If (CInt(fila.Cells("actual_prog_PEND").Value) = SumaParesProgramacion) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If

        Return True
    End Function



    'Private Sub gridListaProspecta_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListaProspecta.AfterRowActivate
    '    gridListaProspecta.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode)
    'End Sub



    Private Sub gridListaProspecta_Click(sender As Object, e As EventArgs)
        'If IsNothing(Me.gridListaProspecta.ActiveRow) = True Then
        '    Return
        'End If

        'If Not Me.gridListaProspecta.ActiveRow.IsDataRow Then Return

        'If IsNothing(gridListaProspecta.ActiveRow) Then Return

        'If gridListaProspecta.ActiveRow.Cells(" ").Value Then

        '    gridListaProspecta.ActiveRow.Cells(" ").Value = False
        'Else
        '    gridListaProspecta.ActiveRow.Cells(" ").Value = True
        'End If
        ''Dim marcados As Integer
        ''For Each row As UltraGridRow In gridListaProspecta.Rows
        ''    If CBool(row.Cells(" ").Value) Then
        ''        marcados += 1
        ''    End If
        ''Next

    End Sub

    Private Sub grdAtnClientes_AfterRowsDeleted(sender As Object, e As EventArgs) Handles grdAtnClientes.AfterRowsDeleted
        'FiltrarInformacion()
    End Sub



    Private Sub grdAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtnClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub grdAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtnClientes.InitializeLayout
        grid_diseño(grdAtnClientes)
        grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atención a clientes"
        'gridAtnClientes.DisplayLayout.Bands(0).Columns(0).Header.VisiblePositionWithinBand
    End Sub


    Private Sub btnAtnClientes_Click(sender As Object, e As EventArgs) Handles btnAtnClientes.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 17

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAtnClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAtnClientes.DataSource = listado.listParametros
        With grdAtnClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Atn. Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

        '        FiltrarInformacion()
    End Sub



    Private Sub btnAyuda_Click(sender As Object, e As EventArgs)
        'Dim AyudaForm As New Ventas.Vista.Prospecta_AyudaForm

        'AyudaForm.ShowDialog()
    End Sub

  



    Private Sub gridListaProspecta_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridListaProspecta.BeforeCellUpdate
        Dim EsCeldaProspecta As Boolean = False
        Dim row As UltraGridRow
        Dim IALM As Integer = 0
        Dim IPRO As Integer = 0
        Dim AXC As Integer = 0
        Dim ParesPendientesPorEntregar As Integer = 0
        Dim TotalParesProsp As Integer = 0
        Dim Eqitueta As String = ""
        Dim TotalParesProgSuma As Integer = 0
        row = e.Cell.Row

        If e.Cell.Column.Key = "Edita" Or e.Cell.Column.Key = "Edición" Or e.Cell.Column.Key = "UsuarioEditaID" Or e.Cell.Column.Key = "% Prs Proy" Or e.Cell.Column.Key = "Prs No Proy" Or e.Cell.Column.Key = "% Prs ConfOT" Or e.Cell.Column.Key = "Prs No ConfOT" Or e.Cell.Column.Key = "% Prs Emb" Or e.Cell.Column.Key = "Prs No Emb" Or e.Cell.Column.Key = "% Prs Sal" Or e.Cell.Column.Key = "Prs No Sal" Then
            Return
        End If

        If e.Cell.Column.Key = "PrsProsp" Or e.Cell.Column.Key = " " Or e.Cell.Column.Key = "Conf" Or e.Cell.Column.Key = "*Incidencia" Or e.Cell.Column.Key = "*Observaciones" Or e.Cell.Column.Key = "FConfirmacion" Or e.Cell.Column.Key = "Confirma" Or e.Cell.Column.Key = "ColumnaModificada" Then
            If ValorGuardado = False Then
                e.Cell.Appearance.ForeColor = Color.Purple
            End If


            Return
        End If

        If ModoEdicion = True Then
            If e.Cell.Row.IsFilterRow = False Then
                row = e.Cell.Row
                If row.Cells("PA").Value = "NO" Then

                    IALM = row.Cells("actual_prog_IALM").Value
                    IPRO = row.Cells("actual_prog_IPRO").Value
                    AXC = row.Cells("actual_prog_AXC").Value

                    TotalParesProgSuma = row.Cells("actual_prog_suma").Value

                    ParesPendientesPorEntregar = IALM + IPRO + AXC

                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value) = False Then
                            TotalParesProsp += row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value
                        End If
                    Next


                    If IsDBNull(e.Cell.Value) = False Then
                        TotalParesProsp += CInt(e.NewValue.ToString()) - CInt(e.Cell.Value)
                    Else
                        TotalParesProsp += CInt(e.NewValue.ToString())
                    End If


                    If TotalParesProsp > ParesPendientesPorEntregar Then

                        show_message("Aviso", "El total de pares a prospectar ha superado la cantidad de pares pendientes ( " + TotalParesProgSuma.ToString() + " pares).")

                        e.Cancel = True
                    Else
                        e.Cell.Appearance.ForeColor = Color.Purple

                    End If
                End If
            End If
        End If




        'If ModoEdicion = True Then
        '    If e.Cell.Row.IsFilterRow = False Then
        '        If e.Cell.Column.Key.ToString() = "plan_Lun" Or e.Cell.Column.Key.ToString() = "plan_Mar" Or e.Cell.Column.Key.ToString() = "plan_Mie" Or e.Cell.Column.Key.ToString() = "plan_Jue" Or e.Cell.Column.Key.ToString() = "plan_Vie" Or e.Cell.Column.Key.ToString() = "plan_Sab" Then
        '            If ValidacionDistribucionPlaneacion(e.Cell, e.NewValue) = False Then
        '                e.Cancel = True
        '            End If
        '        End If
        '    End If
        'End If

    End Sub

    Private Function ValidacionDistribucionPlaneacion(ByVal celda As UltraGridCell, ByVal NuevoValorAntesActualizar As Integer) As Boolean

        'Dim SumaPlaneacion As Integer = 0
        'Dim SumaPareaProspectaAntesActualizar As Integer = 0
        'Dim SumaParesProgramacion As Integer = 0
        'Dim fila As UltraGridRow = celda.Row


        'SumaParesProgramacion = CInt(fila.Cells("actual_prog_IALM").Value) + CInt(fila.Cells("actual_prog_IPRO").Value) + CInt(fila.Cells("actual_prog_AXC").Value)

        'If celda.Column.Key.ToString() = "plan_Lun" Then
        '    SumaPlaneacion = CInt(NuevoValorAntesActualizar) + CInt(fila.Cells("plan_Mar").Value) + CInt(fila.Cells("plan_Mie").Value) + CInt(fila.Cells("plan_Jue").Value) + CInt(fila.Cells("plan_Vie").Value) + CInt(fila.Cells("plan_Sab").Value)
        'ElseIf celda.Column.Key.ToString() = "plan_Mar" Then
        '    SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(NuevoValorAntesActualizar) + CInt(fila.Cells("plan_Mie").Value) + CInt(fila.Cells("plan_Jue").Value) + CInt(fila.Cells("plan_Vie").Value) + CInt(fila.Cells("plan_Sab").Value)
        'ElseIf celda.Column.Key.ToString() = "plan_Mie" Then
        '    SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(fila.Cells("plan_Mar").Value) + CInt(NuevoValorAntesActualizar) + CInt(fila.Cells("plan_Jue").Value) + CInt(fila.Cells("plan_Vie").Value) + CInt(fila.Cells("plan_Sab").Value)
        'ElseIf celda.Column.Key.ToString() = "plan_Jue" Then
        '    SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(fila.Cells("plan_Mar").Value) + CInt(fila.Cells("plan_Mie").Value) + CInt(NuevoValorAntesActualizar) + CInt(fila.Cells("plan_Vie").Value) + CInt(fila.Cells("plan_Sab").Value)
        'ElseIf celda.Column.Key.ToString() = "plan_Vie" Then
        '    SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(fila.Cells("plan_Mar").Value) + CInt(fila.Cells("plan_Mie").Value) + CInt(fila.Cells("plan_Jue").Value) + CInt(NuevoValorAntesActualizar) + CInt(fila.Cells("plan_Sab").Value)
        'ElseIf celda.Column.Key.ToString() = "plan_Sab" Then
        '    SumaPlaneacion = CInt(fila.Cells("plan_Lun").Value) + CInt(fila.Cells("plan_Mar").Value) + CInt(fila.Cells("plan_Mie").Value) + CInt(fila.Cells("plan_Jue").Value) + CInt(fila.Cells("plan_Vie").Value) + CInt(NuevoValorAntesActualizar)
        'End If

        'If SumaParesProgramacion < SumaPlaneacion Then
        '    Return False
        'Else
        '    Return True
        'End If

    End Function



    Private Sub gridListaProspecta_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaProspecta.ClickCell
        'gridListaProspecta.PerformAction(UltraGridAction.EnterEditMode)

        'Es para Cuando se aplice el filtro de  la columna de seleccionar (' ') 
        'If e.Cell.IsFilterRowCell Then
        '    gridListaProspecta.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
        'Else


        'End If
        Dim row As UltraGridRow


        If e.Cell.IsFilterRowCell = False Then
            If e.Cell.Column.Key = " " Then
                If e.Cell.Value Then
                    e.Cell.Value = False
                Else
                    e.Cell.Value = True
                End If
            End If

            If ModoEdicion = True Then
                If e.Cell.Column.Key = "Conf" Then
                    If ProspectaID <> -1 Then
                        If e.Cell.Row.Cells("UsuarioEditaID").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                            If IsNothing(e.Cell.Row.Cells("PrsProsp").Value) = False And IsDBNull(e.Cell.Row.Cells("PrsProsp").Value) = False Then
                                If e.Cell.Row.Cells("PrsProsp").Value <> 0 Then
                                    If e.Cell.Value Then
                                        e.Cell.Value = False
                                        e.Cell.Row.Cells("Confirma").Value = ""
                                        If ProspectaID = -1 Then
                                            e.Cell.Row.Cells("FConfirmacion").Value = Nothing
                                        Else
                                            e.Cell.Row.Cells("FConfirmacion").Value = DBNull.Value
                                        End If
                                    Else
                                        e.Cell.Value = True
                                        ObtenerUsuarioConfirma(e.Cell.Row)
                                    End If
                                    row = e.Cell.Row
                                    row.Cells("ColumnaModificada").Value = True
                                End If
                            End If
                        End If
                    Else
                        If IsNothing(e.Cell.Row.Cells("PrsProsp").Value) = False And IsDBNull(e.Cell.Row.Cells("PrsProsp").Value) = False Then
                            If e.Cell.Row.Cells("PrsProsp").Value <> 0 Then
                                If e.Cell.Value Then
                                    e.Cell.Value = False
                                    e.Cell.Row.Cells("Confirma").Value = ""
                                    If ProspectaID = -1 Then
                                        e.Cell.Row.Cells("FConfirmacion").Value = Nothing
                                    Else
                                        e.Cell.Row.Cells("FConfirmacion").Value = DBNull.Value
                                    End If
                                Else
                                    e.Cell.Value = True
                                    ObtenerUsuarioConfirma(e.Cell.Row)
                                End If
                                row = e.Cell.Row
                                row.Cells("ColumnaModificada").Value = True
                            End If
                        End If
                    End If
                   
                End If

                If e.Cell.Column.Key = "actual_prog_suma" Then
                    If e.Cell.Selected = True Then
                        MostrarMenuContextual = True
                    Else
                        MostrarMenuContextual = False
                    End If

                Else
                    MostrarMenuContextual = False
                End If
            End If




        End If




        'If IsNothing(Me.gridListaProspecta.ActiveRow) = True Then
        '    Return
        'End If

        'If Not Me.gridListaProspecta.ActiveRow.IsDataRow Then Return

        'If IsNothing(gridListaProspecta.ActiveRow) Then Return

        'If gridListaProspecta.ActiveRow.Cells(" ").Value Then

        '    gridListaProspecta.ActiveRow.Cells(" ").Value = False
        'Else
        '    gridListaProspecta.ActiveRow.Cells(" ").Value = True
        'End If
    End Sub


    Private Sub ObtenerUsuarioConfirma(ByVal fila As UltraGridRow)
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim dtInformacionActividadUsuario As DataTable
        dtInformacionActividadUsuario = objProspecta.ObtenerInformacionUsuarioActivo()
        'Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        If ModoEdicion = True Then
            fila.Cells("Confirma").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername 'dtInformacionActividadUsuario.Rows(0).Item("UserName").ToString()
            fila.Cells("FConfirmacion").Value = DateTime.Now.ToString() 'dtInformacionActividadUsuario.Rows(0).Item("FechaInicioActividad").ToString()
        End If

    End Sub

    Private Sub gridListaProspecta_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridListaProspecta.InitializeRow
        If IsNothing(gridListaProspecta.DataSource) = False Then
            If e.Row.Index >= 0 Then
                'If IsDBNull(e.Row.Cells("").Value) = True Then
                '    e.Row.Cells("").Value = 0
                'End If

                ColorIndicadorProspecta(e.Row, "gridListaProspecta")
                ValidarCumplePartidaCompleta(e.Row)

                If e.Row.Cells("PA").Value = "NO" Then
                    e.Row.Appearance.BackColor = Color.LightSalmon
                End If

                CalcularMedicion(e.Row)

                'ObjProspecta.MotivoIncidenciaID = fila.Cells("*Incidencia").Column.ValueList.GetValue(fila.Cells("*Incidencia").Value.ToString, 0)
            End If
        End If
    End Sub

    Private Sub gridPartidas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridPartidas.AfterCellUpdate
        If ModoEdicion = True Then
            If e.Cell.Row.IsFilterRow = False Then
                ActualizarDistribuccionParesPlaneacion(e.Cell)

            End If

        End If
    End Sub

    Private Sub gridPartidas_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridPartidas.BeforeCellUpdate

        'Dim EsCeldaProspecta As Boolean = False
        'Dim row As UltraGridRow
        'Dim IALM As Integer = 0
        'Dim IPRO As Integer = 0
        'Dim AXC As Integer = 0
        'Dim ParesPendientesPorEntregar As Integer = 0
        'Dim TotalParesProsp As Integer = 0
        'Dim Eqitueta As String = ""
        'row = e.Cell.Row

        'If e.Cell.Column.Key = "PrsProsp" Or e.Cell.Column.Key = " " Or e.Cell.Column.Key = "Conf" Or e.Cell.Column.Key = "*Incidencia" Or e.Cell.Column.Key = "*Observaciones" Or e.Cell.Column.Key = "FConfirmacion" Or e.Cell.Column.Key = "Confirma" Then
        '    Return
        'End If

        'If ModoEdicion = True Then
        '    If e.Cell.Row.IsFilterRow = False Then
        '        For Each dia As Entidades.ProspectaDias In DiasProspecta
        '            If IsDBNull(row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value) = False Then
        '                TotalParesProsp += row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value
        '            End If
        '        Next

        '    End If
        'End If



        'If ModoEdicion = True Then
        '    If e.Cell.Row.IsFilterRow = False Then

        '        If e.Cell.Column.Key = "PrsProsp" Or e.Cell.Column.Key = " " Or e.Cell.Column.Key = "Conf" Or e.Cell.Column.Key = "*Incidencia" Or e.Cell.Column.Key = "*Observaciones" Or e.Cell.Column.Key = "FConfirmacion" Or e.Cell.Column.Key = "Confirma" Then
        '            Return
        '        End If

        '        If e.Cell.Column.Key.ToString() = "plan_Lun" Or e.Cell.Column.Key.ToString() = "plan_Mar" Or e.Cell.Column.Key.ToString() = "plan_Mie" Or e.Cell.Column.Key.ToString() = "plan_Jue" Or e.Cell.Column.Key.ToString() = "plan_Vie" Or e.Cell.Column.Key.ToString() = "plan_Sab" Then
        '            If ValidacionDistribucionPlaneacion(e.Cell, e.NewValue) = False Then
        '                e.Cancel = True
        '            End If
        '        End If
        '    End If
        'End If


        '--------------------------------

        'Dim EsCeldaProspecta As Boolean = False
        'Dim row As UltraGridRow
        'Dim IALM As Integer = 0
        'Dim IPRO As Integer = 0
        'Dim AXC As Integer = 0
        'Dim ParesPendientesPorEntregar As Integer = 0
        'Dim TotalParesProsp As Integer = 0
        'Dim Eqitueta As String = ""
        'row = e.Cell.Row


        'If e.Cell.Column.Key = "PrsProsp" Or e.Cell.Column.Key = " " Or e.Cell.Column.Key = "Conf" Or e.Cell.Column.Key = "*Incidencia" Or e.Cell.Column.Key = "*Observaciones" Or e.Cell.Column.Key = "FConfirmacion" Or e.Cell.Column.Key = "Confirma" Then
        '    Return
        'End If



        'If ModoEdicion = True Then
        '    If e.Cell.Row.IsFilterRow = False Then
        '        row = e.Cell.Row
        '        If row.Cells("PA").Value = "NO" Then

        '            IALM = row.Cells("actual_prog_IALM").Value
        '            IPRO = row.Cells("actual_prog_IPRO").Value
        '            AXC = row.Cells("actual_prog_AXC").Value

        '            ParesPendientesPorEntregar = IALM + IPRO + AXC

        '            For Each dia As Entidades.ProspectaDias In DiasProspecta
        '                If IsDBNull(row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value) = False Then
        '                    TotalParesProsp += row.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Value
        '                End If
        '            Next
        '            TotalParesProsp += CInt(e.NewValue.ToString())
        '            If TotalParesProsp > ParesPendientesPorEntregar Then
        '                e.Cancel = True
        '            Else
        '                e.Cell.Appearance.ForeColor = Color.Purple

        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    'If tabProspecta.SelectedTab.Text = "Clientes" Then
    '     DistribuirParesDiaPlaneacion(gridListaProspecta, "Lun")
    ' ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
    '     DistribuirParesDiaPlaneacion(gridPedidos, "Lun")
    ' ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
    '     DistribuirParesDiaPlaneacion(gridPartidas, "Lun")
    ' End If


    Private Sub gridPartidas_Click(sender As Object, e As EventArgs) Handles gridPartidas.Click

        'If e.Cell.IsFilterRowCell = False Then

        'End If
        'If IsNothing(Me.gridPartidas.ActiveRow) = True Then
        '    Return
        'End If

        'If Not Me.gridPartidas.ActiveRow.IsDataRow Then Return

        'If IsNothing(gridPartidas.ActiveRow) Then Return

        'If gridPartidas.ActiveRow.Cells(" ").Value Then

        '    gridPartidas.ActiveRow.Cells(" ").Value = False
        'Else
        '    gridPartidas.ActiveRow.Cells(" ").Value = True
        'End If
        ''Dim marcados As Integer
        ''For Each row As UltraGridRow In gridListaProspecta.Rows
        ''    If CBool(row.Cells(" ").Value) Then
        ''        marcados += 1
        ''    End If
        ''Next
    End Sub

    Private Sub gridPartidas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridPartidas.ClickCell
        Dim fila As UltraGridRow
        fila = e.Cell.Row

        If e.Cell.IsFilterRowCell = False Then
            If IsNothing(Me.gridPartidas.ActiveRow) = True Then
                Return
            End If

            If Not Me.gridPartidas.ActiveRow.IsDataRow Then Return

            If IsNothing(gridPartidas.ActiveRow) Then Return

            If gridPartidas.ActiveRow.Cells(" ").Value Then

                gridPartidas.ActiveRow.Cells(" ").Value = False
            Else
                gridPartidas.ActiveRow.Cells(" ").Value = True
            End If

            If ModoEdicion = True Then
                If fila.Cells("PA").Value = "NO" Then
                    MostrarMenuContextual = False
                Else
                    If e.Cell.Column.Key = "actual_prog_suma" Then
                        If e.Cell.Selected = True Then
                            MostrarMenuContextual = True
                        Else
                            MostrarMenuContextual = False
                        End If
                    Else
                        MostrarMenuContextual = False
                    End If
                End If
            End If
        End If

        


        'Dim marcados As Integer
        'For Each row As UltraGridRow In gridListaProspecta.Rows
        '    If CBool(row.Cells(" ").Value) Then
        '        marcados += 1
        '    End If
        'Next
    End Sub


    Private Sub gridPartidas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridPartidas.InitializeRow
        If IsNothing(gridListaProspecta.DataSource) = False Then
            If e.Row.Index >= 0 Then
                If e.Row.IsFilterRow = False Then
                    ColorIndicadorProspecta(e.Row, "gridPartidas")
                    'ValidarCumplePartidaCompleta(e.Row)
                End If

            End If
        End If
    End Sub

    Private Sub gridPedidos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridPedidos.AfterCellUpdate
        Dim Fila As UltraGridRow
        Dim SumaParesFila As Integer = 0
        Fila = e.Cell.Row

        If ModoEdicion = True Then
            If e.Cell.Row.IsFilterRow = False Then
                ActualizarDistribuccionParesPlaneacion(e.Cell) 'Actualizar columnas de PrsPros

                'For Each Dia As Entidades.ProspectaDias In DiasProspecta
                '    If IsDBNull(Fila.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
                '        SumaParesFila += CInt(Fila.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
                '    End If
                'Next

            End If

        End If
    End Sub

    Private Sub gridPedidos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridPedidos.BeforeCellUpdate
        If ModoEdicion = True Then
            If e.Cell.Row.IsFilterRow = False Then
                If e.Cell.Column.Key.ToString() = "plan_Lun" Or e.Cell.Column.Key.ToString() = "plan_Mar" Or e.Cell.Column.Key.ToString() = "plan_Mie" Or e.Cell.Column.Key.ToString() = "plan_Jue" Or e.Cell.Column.Key.ToString() = "plan_Vie" Or e.Cell.Column.Key.ToString() = "plan_Sab" Then
                    If ValidacionDistribucionPlaneacion(e.Cell, e.NewValue) = False Then
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridPedidos_Click(sender As Object, e As EventArgs) Handles gridPedidos.Click
        'If IsNothing(Me.gridPedidos.ActiveRow) = True Then
        '    Return
        'End If




        'If Not Me.gridPedidos.ActiveRow.IsDataRow Then Return

        'If IsNothing(gridPedidos.ActiveRow) Then Return

        'If gridPedidos.ActiveRow.Cells(" ").Value Then

        '    gridPedidos.ActiveRow.Cells(" ").Value = False
        'Else
        '    gridPedidos.ActiveRow.Cells(" ").Value = True
        'End If
        ''Dim marcados As Integer
        ''For Each row As UltraGridRow In gridListaProspecta.Rows
        ''    If CBool(row.Cells(" ").Value) Then
        ''        marcados += 1
        ''    End If
        ''Next
    End Sub

    Private Sub gridPedidos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridPedidos.ClickCell
        'If e.Cell.IsDataCell = False Then
        '    gridPedidos.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
        '    Return
        'End If
        Dim fila As UltraGridRow
        fila = e.Cell.Row


        If e.Cell.IsFilterRowCell = False Then
            If e.Cell.Column.Key = " " Then
                If e.Cell.Value Then
                    e.Cell.Value = False
                Else
                    e.Cell.Value = True
                End If
            End If

            If ModoEdicion = True Then
                If fila.Cells("PA").Value = "NO" Then
                    MostrarMenuContextual = False
                Else
                    If e.Cell.Column.Key = "actual_prog_suma" Then
                        If e.Cell.Selected = True Then
                            MostrarMenuContextual = True
                        Else
                            MostrarMenuContextual = False
                        End If
                    Else
                        MostrarMenuContextual = False
                    End If
                End If
            End If
        End If

     



        'If IsNothing(Me.gridPedidos.ActiveRow) = True Then
        '    Return
        'End If


        'If Not Me.gridPedidos.ActiveRow.IsDataRow Then Return

        'If IsNothing(gridPedidos.ActiveRow) Then Return

        'If gridPedidos.ActiveRow.Cells(" ").Value Then

        '    gridPedidos.ActiveRow.Cells(" ").Value = False
        'Else
        '    gridPedidos.ActiveRow.Cells(" ").Value = True
        'End If

    End Sub

    Private Sub gridPedidos_ContextMenuChanged(sender As Object, e As EventArgs) Handles gridPedidos.ContextMenuChanged

    End Sub

    Private Sub gridPedidos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridPedidos.DoubleClickHeader

    End Sub

    Private Sub gridPedidos_InitializeLogicalPrintPage(sender As Object, e As CancelableLogicalPrintPageEventArgs) Handles gridPedidos.InitializeLogicalPrintPage

    End Sub


    Private Sub gridPedidos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridPedidos.InitializeRow
        If IsNothing(gridListaProspecta.DataSource) = False Then
            If e.Row.Index >= 0 Then
                If e.Row.IsFilterRow = False Then
                    ColorIndicadorProspecta(e.Row, "gridPedidos")
                    'ValidarCumplePartidaCompleta(e.Row)
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarParesTotales(ByVal fila As UltraGridRow, ByVal TotalParesProspectados As Integer)
        Dim TotalParesProyectados As Integer = 0
        Dim TotalParesConfirmados As Integer = 0
        Dim TotalParesEmbarcados As Integer = 0
        Dim TotalParesSalidas As Integer = 0

        'fila.Cells("% Prs Proy").Value = CDbl(fila.Cells("Prs Proy").Value) / CDbl(TotalParesProspectados)
        'fila.Cells("Prs No Proy").Value = TotalParesProspectados - CInt(fila.Cells("Prs No Proy").Value)

        'fila.Cells("% Prs ConfOT").Value = CDbl(fila.Cells("Prs ConfOT").Value) / CDbl(fila.Cells("Prs Proy").Value)
        'fila.Cells("Prs No ConfOT").Value = CDbl(fila.Cells("Prs Proy").Value) - CInt(fila.Cells("Prs ConfOT").Value)

        'fila.Cells("% Prs Emb").Value = CDbl(fila.Cells("Prs Emb").Value) / CDbl(fila.Cells("Prs ConfOT").Value)
        'fila.Cells("Prs No Emb").Value = CDbl(fila.Cells("Prs ConfOT").Value) - CInt(fila.Cells("Prs Emb").Value)

        'fila.Cells("% Prs Sal").Value = CDbl(fila.Cells("Prs Sal").Value) / CDbl(fila.Cells("Prs Emb").Value)
        'fila.Cells("Prs No Sal").Value = CDbl(fila.Cells("Prs Emb").Value) - CInt(fila.Cells("Prs Sal").Value)

    End Sub

    Private Sub ColorIndicadorProspecta(ByRef Fila As UltraGridRow, ByVal NombreGrid As String)
        Try


            With Fila
                If .Cells("PR").Value = "SI" Then
                    .Cells("PR").Appearance.BackColor = Color.Green
                Else
                    .Cells("PR").Appearance.BackColor = Color.Red
                End If

                If NombreGrid = "gridListaProspecta" Then
                    If .Cells("BL").Value = "SI" Then
                        .Cells("BL").Appearance.BackColor = Color.Red
                    Else
                        .Cells("BL").Appearance.BackColor = Color.Green
                    End If

                    If .Cells("SINV").Value = "NO" Then
                        .Cells("SINV").Appearance.BackColor = Color.Yellow
                    End If

                    'Prospecta Actual
                    If .Cells("BL A").Value = "SI" Then
                        .Cells("BL A").Appearance.BackColor = Color.Red
                    Else
                        .Cells("BL A").Appearance.BackColor = Color.Green
                    End If

                    If .Cells("S/INV A").Value = "NO" Then
                        .Cells("S/INV A").Appearance.BackColor = Color.Yellow
                    End If

                    If .Cells("PAGP A").Value = "SI" Then
                        .Cells("PAGP A").Appearance.BackColor = Color.Red
                    ElseIf .Cells("PAGP A").Value = "NO" Then
                        .Cells("PAGP A").Appearance.BackColor = Color.Green
                    End If



                End If

                If IsDBNull(.Cells("PAGP").Value) = False Then
                    If .Cells("PAGP").Value = "SI" Then
                        .Cells("PAGP").Appearance.BackColor = Color.Red
                    ElseIf .Cells("PAGP").Value = "NO" Then
                        .Cells("PAGP").Appearance.BackColor = Color.Green
                    End If

                    If .Cells("Plazo 0").Value = "SI" Then
                        .Cells("Plazo 0").Appearance.BackColor = Color.Red
                    End If
                End If

                

                If IsDBNull(.Cells("PrsProsp").Value) = False And IsDBNull(.Cells("PrsProy").Value) = False Then
                    If .Cells("PrsProsp").Value = .Cells("PrsProy").Value Then
                        '.Cells("Prs Proy").Appearance.ForeColor = Color.Green
                        .Cells("% Prs Proy").Appearance.ForeColor = Color.Green
                    ElseIf CInt(.Cells("PrsProsp").Value) > CInt(.Cells("PrsProy").Value) Then
                        '.Cells("Prs Proy").Appearance.ForeColor = Color.Purple
                        .Cells("% Prs Proy").Appearance.ForeColor = Color.OrangeRed
                    ElseIf CInt(.Cells("PrsProsp").Value) < CInt(.Cells("PrsProy").Value) Then
                        '.Cells("Prs Proy").Appearance.ForeColor = Color.Red
                        .Cells("% Prs Proy").Appearance.ForeColor = Color.Red
                    End If
                End If


                If IsDBNull(.Cells("PrsProy").Value) = False And IsDBNull(.Cells("PrsConfOT").Value) = False Then
                    If .Cells("PrsProy").Value = .Cells("PrsConfOT").Value Then
                        '.Cells("Prs ConfOT").Appearance.ForeColor = Color.Green
                        .Cells("% Prs ConfOT").Appearance.ForeColor = Color.Green
                    ElseIf .Cells("PrsConfOT").Value > .Cells("PrsConfOT").Value Then
                        '.Cells("Prs ConfOT").Appearance.ForeColor = Color.Red
                        .Cells("% Prs ConfOT").Appearance.ForeColor = Color.OrangeRed
                    ElseIf .Cells("PrsProy").Value < .Cells("PrsConfOT").Value Then
                        .Cells("% Prs ConfOT").Appearance.ForeColor = Color.Red
                    End If
                End If


                If IsDBNull(.Cells("PrsConfOT").Value) = False And IsDBNull(.Cells("PrsEmb").Value) = False Then
                    If .Cells("PrsConfOT").Value = .Cells("PrsEmb").Value Then
                        '.Cells("Prs Emb").Appearance.ForeColor = Color.Green
                        .Cells("% Prs Emb").Appearance.ForeColor = Color.Green
                    ElseIf .Cells("PrsConfOT").Value > .Cells("PrsEmb").Value Then
                        '.Cells("Prs Emb").Appearance.ForeColor = Color.Red
                        .Cells("% Prs Emb").Appearance.ForeColor = Color.OrangeRed
                    ElseIf .Cells("PrsConfOT").Value < .Cells("PrsEmb").Value Then
                        .Cells("% Prs Emb").Appearance.ForeColor = Color.Red
                    End If
                End If


                If IsDBNull(.Cells("PrsEmb").Value) = False And IsDBNull(.Cells("PrsSal").Value) = False Then
                    If .Cells("PrsEmb").Value = .Cells("PrsSal").Value Then
                        '.Cells("Prs Sal").Appearance.ForeColor = Color.Green
                        .Cells("% Prs Sal").Appearance.ForeColor = Color.Green
                    ElseIf .Cells("PrsEmb").Value > .Cells("PrsSal").Value Then
                        '.Cells("Prs Sal").Appearance.ForeColor = Color.Red
                        .Cells("% Prs Sal").Appearance.ForeColor = Color.OrangeRed
                    ElseIf .Cells("PrsEmb").Value < .Cells("PrsSal").Value Then
                        .Cells("% Prs Sal").Appearance.ForeColor = Color.Red
                    End If
                End If



            End With
        Catch ex As Exception
            MsgBox("Error ")
        End Try

    End Sub

    Private Sub btnCancelarProspecta_Click(sender As Object, e As EventArgs) Handles btnCancelarProspecta.Click
        Dim objCancelarProspecta As New Ventas.Negocios.ProspectaBU
        Dim mensaje As String = String.Empty

        Try


            If IdEstadoProspecta = 87 Then
                mensaje = "¿ Está seguro de cancelar la prospecta de la semana " + txtSemana.Text.Trim() + " con  status PRÓXIMA ? (Una vez realizada esta acción no se podrá revertir)"
            ElseIf IdEstadoProspecta = 88 Then
                mensaje = "¿ Está seguro de cancelar la prospecta de la semana " + txtSemana.Text.Trim() + " con status VIGENTE ? (Se guardarán los registros de la medición de la misma hasta el momento. Una vez realizada esta acción no se podrá revertir)"
            End If



            If IdEstadoProspecta = 87 Or IdEstadoProspecta = 88 Then
                If show_message("Confirmar", mensaje) = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    objCancelarProspecta.CancelarProspecta(ProspectaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    show_message("Exito", "Prospecta de la semana " + txtSemana.Text.Trim() + " cancelada con éxito.")
                    btnCancelarProspecta.Enabled = False
                    btnEditar.Enabled = False
                    btnGuardar.Enabled = False
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Aviso", "Ocurrio un error al cancelar la prospecta")
        End Try
    End Sub



    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If

            If Key = "*Observaciones" Then
                .DisplayLayout.Bands(0).Columns(Key).CharacterCasing = CharacterCasing.Upper
                .DisplayLayout.Bands(0).Columns(Key).MaxLength = 190

            End If

            If Key = "FConfirmacion" Then
                '.DisplayLayout.Bands(0).Columns(Key).DataType = GetType(DateTime)

                .DisplayLayout.Bands(0).Columns(Key).Format = "dd/MM/yyyy HH:mm:ss"
            End If



            '.DisplayLayout.Bands(0).Columns(Key).Header.Appearance.TextHAlign =
            ' .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.BorderColor = Color.Red
            ' .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit



            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit

            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit

            End If






            'If ProspectaID = -1 Then
            '    If Edicion = True Then
            '        .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit

            '    Else
            '        .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            '    End If

            'End If



        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If
            
        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub chkInfoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkInfoCliente.CheckedChanged
        OcultarColumnasPestañaCliente()
    End Sub

    Private Sub chkInfoProspecta_CheckedChanged(sender As Object, e As EventArgs) Handles chkInfoProspecta.CheckedChanged
        OcultarColumnasPestañaProspécta()
    End Sub

    Private Sub chkInfoMedicion_CheckedChanged(sender As Object, e As EventArgs) Handles chkInfoMedicion.CheckedChanged
        OcultarColumnasPestañaMedicion()
        chkSalidaSemanal_CheckedChanged(Nothing, Nothing)
        chkEmbarcadoSemanal_CheckedChanged(Nothing, Nothing)
        chkConfirmacionOTSemanal_CheckedChanged(Nothing, Nothing)
        chkProyeccionSemanal_CheckedChanged(Nothing, Nothing)
        chkPlaneacionSemanal_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub btnEditar_Click_1(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim FrmAltaProspecta As New AltaProspectaForm
        Dim dtInformacionUsuarioActivo As DataTable
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        ModoEdicion = True
        objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID, False)
        PonerModoEdicionColumunas()
        ConsultarUsuariosEnEdicionOProspecta()
        show_message("Aviso", "La prospecta se encuentra en modo de edición.")
        btnGuardar.Enabled = True


        'Codigo Anterior
        'Dim objProspecta As New Ventas.Negocios.ProspectaBU
        'Dim dtInformacionActividadUsuario As DataTable
        'ModoEdicion = True
        'If objProspecta.ConsultaActividadUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID) = False Then
        '    objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)
        '    dtInformacionActividadUsuario = objProspecta.ObtenerInformacionUsuarioActivo()
        '    txtUsuarioEditando.Text = dtInformacionActividadUsuario.Rows(0).Item("UserName").ToString()
        '    txtFechaEdicion.Text = dtInformacionActividadUsuario.Rows(0).Item("FechaInicioActividad").ToString()
        '    show_message("Aviso", "La prospecta se encuentra en modo de edición.")
        'Else
        '    'RealizarRespaldoParesSicy()
        '    LlenarGridProspectaClientes()
        '    LenarParesTotalAtados()
        '    gridParesPorAtado.Visible = True
        '    CargarParesConfirmados()
        '    OcultarColumnas()
        '    CargarListaIncidenciasGrid()
        '    dtDatosPartidas.Rows.Clear()
        '    dtDatosPedidos.Rows.Clear()


        '    dtInformacionActividadUsuario = objProspecta.ObtenerInformacionUsuarioActivo()

        '    If objProspecta.ComprobarProspectaModoEdicion(ProspectaID) = True Then
        '        show_message("Aviso", "El usuario " + dtInformacionActividadUsuario.Rows(0).Item("UserName").ToString() + " está editando la prospecta de la semana " + txtSemana.Text.Trim() + " (" + dtInformacionActividadUsuario.Rows(0).Item("FechaInicioActividad").ToString() + "). Espere a que termine de editar e Intente más tarde. De momento podrá ingresar a la prospecta en modo de consulta.")
        '        txtUsuarioEditando.Text = dtInformacionActividadUsuario.Rows(0).Item("UserName").ToString()
        '        txtFechaEdicion.Text = dtInformacionActividadUsuario.Rows(0).Item("FechaInicioActividad").ToString()
        '    Else
        '        show_message("Aviso", "El usuario " + dtInformacionActividadUsuario.Rows(0).Item("UserName").ToString() + " está registrando una prospecta  (" + dtInformacionActividadUsuario.Rows(0).Item("FechaInicioActividad").ToString() + "). Espere a que termine de registrar e Intente más tarde. De momento podrá ingresar a la prospecta en modo de consulta.")
        '    End If
        '    ModoEdicion = False
        'End If


        'PonerModoEdicionColumunas()
    End Sub


    Private Sub PermitirEditarClientesPorPerfil()

        For Each Fila As UltraGridRow In gridListaProspecta.Rows
            'AtencionClienteID
            If Fila.Cells("AtencionClienteID").Value = UsuarioIdPruebaPerfil Then
                Fila.Activation = Activation.AllowEdit
            Else
                Fila.Activation = Activation.NoEdit
            End If

        Next


    End Sub

    Private Sub PonerModoEdicionColumunas()
        Dim objProspectaBU As New Ventas.Negocios.ProspectaBU
        Dim objProspecta As Entidades.ProspectaInformacion

        If ProspectaID <> -1 Then
            objProspecta = objProspectaBU.CargarInformacionProspecta(ProspectaID)
        End If

        If ModoEdicion = True Then
            If ProspectaID <> -1 Then
                If objProspecta.IDEstatusProspecta = 87 Then 'Solo si esta en estado de proxima la prospecta se puede editar

                    gridListaProspecta.DisplayLayout.Bands(0).Columns("*Incidencia").CellActivation = Activation.AllowEdit
                    gridListaProspecta.DisplayLayout.Bands(0).Columns("*Observaciones").CellActivation = Activation.AllowEdit

                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        gridListaProspecta.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.AllowEdit
                    Next

                    'Poner en modo de edicion las columnas de planeacion para los clientes que tengan permitido distribuir pares desde el nivel cliente
                    For Each fila As UltraGridRow In gridListaProspecta.Rows
                        If fila.Cells("PA").Value = "NO" Then
                            For Each dia As Entidades.ProspectaDias In DiasProspecta
                                fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
                            Next
                        Else
                            For Each dia As Entidades.ProspectaDias In DiasProspecta
                                fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                            Next
                        End If
                    Next

                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        gridPedidos.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
                    Next

                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        gridPartidas.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
                    Next

                ElseIf objProspecta.IDEstatusProspecta = 88 Then
                    gridListaProspecta.DisplayLayout.Bands(0).Columns("*Incidencia").CellActivation = Activation.AllowEdit
                    gridListaProspecta.DisplayLayout.Bands(0).Columns("*Observaciones").CellActivation = Activation.AllowEdit

                End If



            Else
                gridListaProspecta.DisplayLayout.Bands(0).Columns("*Incidencia").CellActivation = Activation.AllowEdit
                gridListaProspecta.DisplayLayout.Bands(0).Columns("*Observaciones").CellActivation = Activation.AllowEdit

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    gridListaProspecta.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.AllowEdit
                Next

                For Each fila As UltraGridRow In gridListaProspecta.Rows
                    If fila.Cells("PA").Value = "NO" Then
                        For Each dia As Entidades.ProspectaDias In DiasProspecta
                            fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
                        Next
                    Else
                        For Each dia As Entidades.ProspectaDias In DiasProspecta
                            fila.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                        Next
                    End If
                Next

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    gridPedidos.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
                Next

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    gridPartidas.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
                Next

            End If

        Else

            gridListaProspecta.DisplayLayout.Bands(0).Columns("*Incidencia").CellActivation = Activation.NoEdit
            gridListaProspecta.DisplayLayout.Bands(0).Columns("*Observaciones").CellActivation = Activation.NoEdit

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                gridListaProspecta.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
            Next

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                gridPedidos.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
            Next

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                gridPartidas.DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).CellActivation = Activation.NoEdit
            Next





        End If

    End Sub

    Private Function CargarEncabezadoGridProspecta() As DataTable

        Dim dtEncabezadoProspecta As New DataTable
        Dim dc As New DataColumn
        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        Dim ColorInfoCliente As Color = Drawing.Color.Black
        Dim ColorInfoProspecta As Color = Color.Black
        Dim ColorInfoMedicion As Color = Drawing.Color.Black
        Dim OcultarColumnas As Boolean = False

        If ProspectaID = -1 Then
            ModoEdicion = True
            OcultarColumnas = True
        End If

        AgregarColumna(gridListaProspecta, " ", " ", False, True, Nothing, 100)
        AgregarColumna(gridListaProspecta, "Cliente", "Cliente", False, True, Nothing, 300)
        AgregarColumna(gridListaProspecta, "Edita", "Edita", OcultarColumnas, True, ColorInfoCliente, 90)
        AgregarColumna(gridListaProspecta, "Edición", "Edición", OcultarColumnas, True, ColorInfoCliente, 60)
        AgregarColumna(gridListaProspecta, "PA", "XP", False, True, ColorInfoCliente, 30, , , , , , "Se prospecta por pedido")
        AgregarColumna(gridListaProspecta, "PR", "PR", False, True, ColorInfoCliente, 30, , , , , , "Prospectado")
        AgregarColumna(gridListaProspecta, "BL", "BL", False, True, ColorInfoCliente, 30, , , , , , "Bloqueado")
        AgregarColumna(gridListaProspecta, "SINV", "Inv", False, True, ColorInfoCliente, 30, , , , , , "Tiene inventario")
        AgregarColumna(gridListaProspecta, "COTS", "Cots", False, True, ColorInfoCliente, 30, True, , HAlign.Right, , , "Cantidad de cotizaciones")
        AgregarColumna(gridListaProspecta, "PAGP", "Pagp", False, True, ColorInfoCliente, 35, , , , , , "Tiene cotizaciones pendientes de pago")
        AgregarColumna(gridListaProspecta, "Bloqueo Entrega", "Bloqueo Entrega", False, True, ColorInfoCliente, 150)
        AgregarColumna(gridListaProspecta, "BL A", "BL", False, True, ColorInfoCliente, 30, , , , , , "Bloqueo")
        AgregarColumna(gridListaProspecta, "S/INV A", "Inv", False, True, ColorInfoCliente, 30, , , , , , "Tiene inventario")
        AgregarColumna(gridListaProspecta, "COTS A", "Cots", False, True, ColorInfoCliente, 30, True, , , , , "Cantidad de cotizaciones")
        AgregarColumna(gridListaProspecta, "PAGP A", "Pagp", False, True, ColorInfoCliente, 35, , , , , , "Tiene cotizaciones pendientes de pago")
        AgregarColumna(gridListaProspecta, "Bloqueo Entrega A", "Bloqueo Entrega", False, True, ColorInfoCliente, 150)
        '16
       

        AgregarColumna(gridListaProspecta, "Ejecutiva", "AtnCtes", False, True, ColorInfoCliente, 70)
        AgregarColumna(gridListaProspecta, "Agente", "Agente", False, True, ColorInfoCliente, 240)
        AgregarColumna(gridListaProspecta, "Empaque", "Empaque", False, True, ColorInfoCliente, 120)
        AgregarColumna(gridListaProspecta, "EtEsp", "EtEsp", False, True, ColorInfoCliente, 40, , , , , , "Etiqueta especial")
        AgregarColumna(gridListaProspecta, "ImPPCP", "ImPPCP", False, True, ColorInfoCliente, 50, , , , , , "Imprime PPCP")
        AgregarColumna(gridListaProspecta, "DE", "DE", False, True, ColorInfoCliente, 30, , , , , , "Doceneo especial")
        AgregarColumna(gridListaProspecta, "Plazo 0", "Plazo 0", False, True, ColorInfoCliente, 35)
        AgregarColumna(gridListaProspecta, "Cita", "Cita", False, True, ColorInfoCliente, 30)
        AgregarColumna(gridListaProspecta, "DA", "DA", False, True, ColorInfoCliente, 30, , , , , , "Días de anticipación")
        AgregarColumna(gridListaProspecta, "PC", "PC", False, True, ColorInfoCliente, 30, , , , , , "Partida completa")
        '26
        AgregarColumna(gridListaProspecta, "total_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "total_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacen")
        AgregarColumna(gridListaProspecta, "total_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "total_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        '30

        AgregarColumna(gridListaProspecta, "pros_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "pros_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridListaProspecta, "pros_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "pros_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        '34
        AgregarColumna(gridListaProspecta, "prog_PEND", "PEND", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "prog_IALM", "IALM", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridListaProspecta, "prog_IPRO", "IPRO", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "prog_AXC", "AXC", False, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridListaProspecta, "prog_suma", "SUMA", True, False, ColorInfoProspecta, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")
        '39
        AgregarColumna(gridListaProspecta, "actual_total_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "actual_total_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridListaProspecta, "actual_total_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "actual_total_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        '43

        AgregarColumna(gridListaProspecta, "actual_pros_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "actual_pros_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridListaProspecta, "actual_pros_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "actual_pros_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        '47
        AgregarColumna(gridListaProspecta, "actual_prog_PEND", "PEND", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridListaProspecta, "actual_prog_IALM", "IALM", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridListaProspecta, "actual_prog_IPRO", "IPRO", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridListaProspecta, "actual_prog_AXC", "AXC", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridListaProspecta, "actual_prog_suma", "Suma", OcultarColumnas, False, ColorInfoProspecta, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")
        '52

        AgregarColumna(gridListaProspecta, "Conf", "Conf", False, True, ColorInfoProspecta, 30, False, , , , , "Confirmación de entrega")
        AgregarColumna(gridListaProspecta, "Confirma", "Confirma", False, True, ColorInfoProspecta, 100)
        AgregarColumna(gridListaProspecta, "FConfirmacion", "FConfirmacion", False, True, ColorInfoProspecta, 150)
        AgregarColumna(gridListaProspecta, "*Incidencia", "*Incidencia", False, True, ColorInfoProspecta, 300, False, ModoEdicion)
        AgregarColumna(gridListaProspecta, "*Observaciones", "*Observaciones", False, True, ColorInfoProspecta, 300, False, ModoEdicion)
        '57
        AgregarColumna(gridListaProspecta, "plnclienteid", "plnclienteid", True, True, ColorInfoProspecta, 300, False, ModoEdicion)
        AgregarColumna(gridListaProspecta, "plnclientesicyid", "plnclientesicyid", True, True, ColorInfoProspecta, 300, False, ModoEdicion)
        AgregarColumna(gridListaProspecta, "plnproceso", "plnproceso", True, True, ColorInfoProspecta, 300, False, ModoEdicion)

        '--60
        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridListaProspecta, "plan_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, ColorInfoMedicion, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridListaProspecta, "PrsProsp", "PrsProsp", False, False, ColorInfoMedicion, 90, True, False, HAlign.Right, , , "Pares prospectados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridListaProspecta, "proy_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, ColorInfoMedicion, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridListaProspecta, "PrsProy", "Prs Proy", OcultarColumnas, False, ColorInfoMedicion, 45, True, , HAlign.Right, , , "Pares proyectados")
        AgregarColumna(gridListaProspecta, "% Prs Proy", "% Prs Proy", OcultarColumnas, True, ColorInfoMedicion, 80, , , HAlign.Right, , True)
        AgregarColumna(gridListaProspecta, "Prs No Proy", "Prs No Proy", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares no proyectados")


        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridListaProspecta, "ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, ColorInfoMedicion, 45, True, False, HAlign.Right)
        Next


        AgregarColumna(gridListaProspecta, "PrsConfOT", "Prs ConfOT", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares confirmados")
        AgregarColumna(gridListaProspecta, "% Prs ConfOT", "% Prs ConfOT", OcultarColumnas, True, ColorInfoMedicion, 80, , , HAlign.Right, , True)
        AgregarColumna(gridListaProspecta, "Prs No ConfOT", "Prs No ConfOT", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares no confirmados")


        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridListaProspecta, "Emb_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, ColorInfoMedicion, 45, True, False, HAlign.Right)
        Next


        AgregarColumna(gridListaProspecta, "PrsEmb", "Prs Emb", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares embarcados")
        AgregarColumna(gridListaProspecta, "% Prs Emb", "% Prs Emb", OcultarColumnas, True, ColorInfoMedicion, 80, , , HAlign.Right, , True)
        AgregarColumna(gridListaProspecta, "Prs No Emb", "Prs No Emb", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares no embarcados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridListaProspecta, "Sal_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, ColorInfoMedicion, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridListaProspecta, "PrsSal", "Prs Sal", OcultarColumnas, False, ColorInfoMedicion, 80, True, , HAlign.Right, , , "Pares salida")
        AgregarColumna(gridListaProspecta, "% Prs Sal", "% Prs Sal", OcultarColumnas, True, ColorInfoMedicion, 80, , , HAlign.Right, , True)
        AgregarColumna(gridListaProspecta, "Prs No Sal", "Prs No Sal", OcultarColumnas, False, ColorInfoMedicion, 80, , , HAlign.Right, , , "Pares no salida")



        AgregarColumna(gridListaProspecta, "AtencionClienteID", "AtencionClienteID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "TipoEmpaqueID", "TipoEmpaqueID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "clienteId", "clienteId", False, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ClienteSicyID", "ClienteSicyID", True, False, Color.Black)

        AgregarColumna(gridListaProspecta, "ProspectaID", "ProspectaID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ProspectaClienteID", "ProspectaClienteID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "AtencionClienteID1", "AtencionClienteID1", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "TipoEmpaqueID1", "TipoEmpaqueID1", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ClienteSayID1", "ClienteSayID1", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ClienteSicyID1", "clienteId", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "CantidaPares", "CantidaPares", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ClienteSayID", "ClienteSayID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "BloqueoID", "BloqueoID", True, False, Color.Black)
        AgregarColumna(gridListaProspecta, "ColumnaModificada", "ColumnaModificada", True, False, Color.Black)

        AgregarColumna(gridListaProspecta, "plnclienteidproy", "plnclienteidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnclientesicyidproy", "plnclientesicyidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnprocesoproy", "plnprocesoproy", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPedidoSicyIDproy", "plnPedidoSicyIDproy", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPartidaproy", "plnPartidaproy", True, False, Nothing, 70, True)

        AgregarColumna(gridListaProspecta, "plnclienteidconf", "plnclienteidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnclientesicyidconf", "plnclientesicyidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnprocesoconf", "plnprocesoconf", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPedidoSicyIDconf", "plnPedidoSicyIDconf", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPartidaconf", "plnPartidaconf", True, False, Nothing, 70, True)

        AgregarColumna(gridListaProspecta, "plnclienteidemb", "plnclienteidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnclientesicyidemb", "plnclientesicyidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnprocesoemb", "plnprocesoemb", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPedidoSicyIDemb", "plnPedidoSicyIDemb", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPartidaemb", "plnPartidaemb", True, False, Nothing, 70, True)

        AgregarColumna(gridListaProspecta, "plnclienteidsld", "plnclienteidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnclientesicyidsld", "plnclientesicyidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnprocesosld", "plnprocesosld", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPedidoSicyIDsld", "plnPedidoSicyIDsld", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "plnPartidasld", "plnPartidasld", True, False, Nothing, 70, True)
        AgregarColumna(gridListaProspecta, "UsuarioEditaID", "UsuarioEditaID", True, False, Nothing, 70, True)


        Return dtEncabezadoProspecta

    End Function

    Public Function CargarEncabezadoPedidos() As DataTable
        Dim dtEncabezadoProspecta As New DataTable
        Dim dc As New DataColumn
        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        Dim ColorInfoCliente As Color = Drawing.Color.Purple
        Dim ColorInfoProspecta As Color = Color.Green
        Dim ColorInfoMedicion As Color = Drawing.Color.Brown

        AgregarColumna(gridPedidos, " ", " ", False, True, Nothing, 100)
        AgregarColumna(gridPedidos, "Cliente", "Cliente", False, True, Nothing, 300)
        AgregarColumna(gridPedidos, "PR", "PR", False, True, Nothing, 30, , , , , , "Prospectado")
        AgregarColumna(gridPedidos, "Plazo 0", "Plazo 0", False, True, Nothing, 45)
        AgregarColumna(gridPedidos, "PC", "PC", False, True, Nothing, 30, , , , , , "Partida completa")
        AgregarColumna(gridPedidos, "PSAY", "PSAY", False, True, Nothing, 80, , , HAlign.Right, , , "Pedidos SAY")
        AgregarColumna(gridPedidos, "PSICY", "PSICY", False, True, Nothing, 80, , , HAlign.Right, , , "Pedido SICY")
        AgregarColumna(gridPedidos, "OrdenCte", "OrdenCte", False, True, Nothing, 55, , , HAlign.Right, , , "Orden de cliente")
        AgregarColumna(gridPedidos, "FCaptura", "FCaptura", False, True, Nothing, 70)
        AgregarColumna(gridPedidos, "FProg", "FProg", False, True, Nothing, 70, , , , , , "Fecha de programación")
        AgregarColumna(gridPedidos, "Status", "Status", False, True, Nothing, 80)
        AgregarColumna(gridPedidos, "COTS", "Cots", False, True, Nothing, 45, , HAlign.Right, , , , "Cantidad de cotizaciones")
        AgregarColumna(gridPedidos, "PAGP", "Pagp", False, True, Nothing, 45, , , , , , "Tiene cotizaciones pendientes de pago")

        AgregarColumna(gridPedidos, "PrsPed", "PrsPed", False, False, Nothing, 45, True, , HAlign.Right, , , "Pares del pedido")
        '14
        AgregarColumna(gridPedidos, "prog_PEND", "PEND", True, False, Nothing, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridPedidos, "prog_IALM", "IALM", True, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridPedidos, "prog_IPRO", "IPRO", True, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridPedidos, "prog_AXC", "AXC", True, False, Nothing, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridPedidos, "prog_suma", "SUMA", True, False, Nothing, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")
        '19

        AgregarColumna(gridPedidos, "actual_prog_PEND", "PEND", False, False, Nothing, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridPedidos, "actual_prog_IALM", "IALM", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en almacén")
        AgregarColumna(gridPedidos, "actual_prog_IPRO", "IPRO", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridPedidos, "actual_prog_AXC", "AXC", False, False, Nothing, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridPedidos, "actual_prog_suma", "SUMA", False, False, Nothing, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")

        AgregarColumna(gridPedidos, "plnclienteid", "plnclienteid", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPedidos, "plnclientesicyid", "plnclientesicyid", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPedidos, "plnproceso", "plnproceso", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPedidos, "plnPedidoSicyID", "plnPedidoSicyID", True, False, Nothing, 45, True, , HAlign.Right, True)


        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPedidos, "plan_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Nothing, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPedidos, "PrsProsp", "PrsProsp", False, False, Nothing, 85, True, False, HAlign.Right, , , "Pares prospectados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPedidos, "proy_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Nothing, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPedidos, "PrsProy", "Prs Proy", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares proyectados")
        AgregarColumna(gridPedidos, "% Prs Proy", "% Prs Proy", False, True, Nothing, 80, , , HAlign.Right, , True)
        AgregarColumna(gridPedidos, "Prs No Proy", "Prs No Proy", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares no proyectados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPedidos, "ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Nothing, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPedidos, "PrsConfOT", "Prs ConfOT", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares confirmados")
        AgregarColumna(gridPedidos, "% Prs ConfOT", "% Prs ConfOT", False, True, Nothing, 80, , , HAlign.Right, , True)
        AgregarColumna(gridPedidos, "Prs No ConfOT", "Prs No ConfOT", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares no confirmados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPedidos, "Emb_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Nothing, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPedidos, "PrsEmb", "Prs Emb", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares embarcados")
        AgregarColumna(gridPedidos, "% Prs Emb", "% Prs Emb", False, True, Nothing, 80, , , HAlign.Right, , True)
        AgregarColumna(gridPedidos, "Prs No Emb", "Prs No Emb", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares no embarcados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPedidos, "Sal_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Nothing, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPedidos, "PrsSal", "Prs Sal", False, False, Nothing, 80, True, , HAlign.Right, , , "Pares salida")
        AgregarColumna(gridPedidos, "% Prs Sal", "% Prs Sal", False, True, Nothing, 80, , True, HAlign.Right, , True)
        AgregarColumna(gridPedidos, "Prs No Sal", "Prs No Sal", False, False, Nothing, 80, , , HAlign.Right, , , "Pares no salida")
        AgregarColumna(gridPedidos, "ProspectaPedidoID", "ProspectaPedidoID", True, False, Nothing, 70, , , HAlign.Right)
        AgregarColumna(gridPedidos, "clienteid", "clienteId", True, False, Nothing, 70)
        AgregarColumna(gridPedidos, "AtencionClienteID", "AtencionClienteID", True, False, Nothing, 70)
        AgregarColumna(gridPedidos, "ClientesayId", "Clientesayid", False, False, Nothing, 70)
        AgregarColumna(gridPedidos, "PA", "PA", False, False, Nothing, 70)
        AgregarColumna(gridPedidos, "plnclienteidproy", "plnclienteidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnclientesicyidproy", "plnclientesicyidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnprocesoproy", "plnprocesoproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPedidoSicyIDproy", "plnPedidoSicyIDproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPartidaproy", "plnPartidaproy", True, False, Nothing, 70, True)

        AgregarColumna(gridPedidos, "plnclienteidconf", "plnclienteidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnclientesicyidconf", "plnclientesicyidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnprocesoconf", "plnprocesoconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPedidoSicyIDconf", "plnPedidoSicyIDconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPartidaconf", "plnPartidaconf", True, False, Nothing, 70, True)

        AgregarColumna(gridPedidos, "plnclienteidemb", "plnclienteidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnclientesicyidemb", "plnclientesicyidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnprocesoemb", "plnprocesoemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPedidoSicyIDemb", "plnPedidoSicyIDemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPartidaemb", "plnPartidaemb", True, False, Nothing, 70, True)

        AgregarColumna(gridPedidos, "plnclienteidsld", "plnclienteidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnclientesicyidsld", "plnclientesicyidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnprocesosld", "plnprocesosld", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPedidoSicyIDsld", "plnPedidoSicyIDsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPedidos, "plnPartidasld", "plnPartidasld", True, False, Nothing, 70, True)
        'AgregarColumna(gridPedidos, "ClienteSicyID", "ClienteSicyID", True, False, Nothing, 70, True)
        'AgregarColumna(gridPedidos, "ClienteSayID", "ClienteSayID", True, False, Nothing, 70, True)

        Return dtEncabezadoProspecta
    End Function


    Public Function CargarEncabezadoPartidas() As DataTable
        Dim dtEncabezadoProspecta As New DataTable
        Dim dc As New DataColumn
        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        Dim ColorInfoCliente As Color = Drawing.Color.Purple
        Dim ColorInfoProspecta As Color = Color.Green
        Dim ColorInfoMedicion As Color = Drawing.Color.Brown


        AgregarColumna(gridPartidas, " ", " ", False, True, Nothing, 35)
        AgregarColumna(gridPartidas, "Cliente", "Cliente", False, True, Nothing, 300)
        AgregarColumna(gridPartidas, "PR", "PR", False, True, Nothing, 45, , , , , , "Prospectado")
        AgregarColumna(gridPartidas, "Plazo 0", "Plazo 0", False, True, Nothing, 45)
        AgregarColumna(gridPartidas, "PC", "PC", False, True, Nothing, 45, , , , , , "Partida completa")
        AgregarColumna(gridPartidas, "PSAY", "PSAY", False, True, Nothing, 80, , , HAlign.Right, , , "Pedido SAY")
        AgregarColumna(gridPartidas, "PSICY", "PSICY", False, True, Nothing, 80, , , HAlign.Right, , , "Pedido SICY")
        AgregarColumna(gridPartidas, "OrdenCte", "OrdenCte", False, True, Nothing, 70, , , HAlign.Right, , , "Orden Cliente")
        AgregarColumna(gridPartidas, "FCaptura", "FCaptura", False, True, Nothing, 70)
        AgregarColumna(gridPartidas, "FProg", "FProg", False, True, Nothing, 70, , , , , , "Fecha de programación")
        AgregarColumna(gridPartidas, "COTS", "Cots", False, False, Nothing, 45, , HAlign.Right, , , , "Cantidad de cotizaciones")
        AgregarColumna(gridPartidas, "PAGP", "Pagp", False, True, Nothing, 45, , , , , , "Tiene cotizaciones pendientes de pago")
        AgregarColumna(gridPartidas, "FCorte", "FCorte", False, True, Nothing, 70)
        AgregarColumna(gridPartidas, "#Part", "#Part", False, False, Nothing, 45, , , HAlign.Right, , , "Número de partida")
        AgregarColumna(gridPartidas, "Tienda/Embarque/CEDIS", "Tienda/Embarque/CEDIS", False, True, Nothing, 200)
        AgregarColumna(gridPartidas, "Status", "Status Partida", False, True, Nothing, 100)
        AgregarColumna(gridPartidas, "Artículo", "Artículo", False, True, Nothing, 400)
        AgregarColumna(gridPartidas, "Prs Part", "PrsPart", False, False, Nothing, 45, True, , HAlign.Right, , , "Pares partida")

        AgregarColumna(gridPartidas, "prog_PEND", "PEND", False, False, Nothing, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridPartidas, "prog_IALM", "IALM", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en almacen")
        AgregarColumna(gridPartidas, "prog_IPRO", "IPRO", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridPartidas, "prog_AXC", "AXC", False, False, Nothing, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridPartidas, "prog_suma", "SUMA", True, False, Nothing, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")

        AgregarColumna(gridPartidas, "actual_prog_PEND", "PEND", False, False, Nothing, 45, True, , HAlign.Right, , , "Pares pendientes de entrega")
        AgregarColumna(gridPartidas, "actual_prog_IALM", "IALM", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en almacen")
        AgregarColumna(gridPartidas, "actual_prog_IPRO", "IPRO", False, False, Nothing, 45, True, , HAlign.Right, , , "Inventario en proceso")
        AgregarColumna(gridPartidas, "actual_prog_AXC", "AXC", False, False, Nothing, 45, True, , HAlign.Right, , , "Apartados por confirmar")
        AgregarColumna(gridPartidas, "actual_prog_suma", "SUMA", False, False, Nothing, 45, True, , HAlign.Right, True, , "IALM + IPRO + AXC")

        AgregarColumna(gridPartidas, "plnclienteid", "plnclienteid", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPartidas, "plnclientesicyid", "plnclientesicyid", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPartidas, "plnproceso", "plnproceso", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPartidas, "plnPedidoSicyID", "plnPedidoSicyID", True, False, Nothing, 45, True, , HAlign.Right, True)
        AgregarColumna(gridPartidas, "plnPartida", "plnPartida", True, False, Nothing, 45, True, , HAlign.Right, True)

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPartidas, "plan_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Color.Black, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPartidas, "PrsProsp", "PrsProsp", False, False, Nothing, 85, True, False, HAlign.Right, , , "Pares prospectados")


        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPartidas, "proy_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Color.Black, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPartidas, "PrsProy", "Prs Proy", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares Proyctados")
        AgregarColumna(gridPartidas, "% Prs Proy", "% Prs Proy", False, True, Nothing, 70, , , HAlign.Right, , True)
        AgregarColumna(gridPartidas, "Prs No Proy", "Prs No Proy", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares no proyectados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPartidas, "ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Color.Black, 45, True, False, HAlign.Right)
        Next

        AgregarColumna(gridPartidas, "PrsConfOT", "Prs ConfOT", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares Confirmados")
        AgregarColumna(gridPartidas, "% Prs ConfOT", "% Prs ConfOT", False, True, Nothing, 70, , , HAlign.Right, , True)
        AgregarColumna(gridPartidas, "Prs No ConfOT", "Prs No ConfOT", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares no confirmados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPartidas, "Emb_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Color.Black, 45, True, False, HAlign.Right)
        Next


        AgregarColumna(gridPartidas, "PrsEmb", "Prs Emb", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares embarcados")
        AgregarColumna(gridPartidas, "% Prs Emb", "% Prs Emb", False, True, Nothing, 70, , , HAlign.Right, , True)
        AgregarColumna(gridPartidas, "Prs No Emb", "Prs No Emb", False, False, Nothing, 70, True, , HAlign.Right, , , "Pares no embarcados")

        For Each dia As Entidades.ProspectaDias In DiasProspecta
            AgregarColumna(gridPartidas, "Sal_" + dia.NombreDia + dia.NumeroDia.ToString(), dia.NombreDia + " " + dia.NumeroDia.ToString, False, False, Color.Black, 45, True, False, HAlign.Right)
        Next


        AgregarColumna(gridPartidas, "PrsSal", "Prs Sal", False, False, Nothing, 70, True, , , , , "Pares salida")
        AgregarColumna(gridPartidas, "% Prs Sal", "% Prs Sal", False, True, Nothing, 70, , , , , True)
        AgregarColumna(gridPartidas, "Prs No Sal", "Prs No Sal", False, False, Nothing, 70, True, , , , , "Pares no salida")

        AgregarColumna(gridPartidas, "clienteId", "clienteId", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "ClientesayId", "ClientesayId", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "ClientesicyId", "ClientesicyId", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "FechaCortePartida", "FechaCortePartida", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "AtencionClienteID", "AtencionClienteID", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "IdCodigo", "IdCodigo", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "IdTalla", "IdTalla", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "tiec_tipoempaqueid", "tiec_tipoempaqueid", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "PA", "PA", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "ProductoEstiloID", "ProductoEstiloID", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "MarcaId", "MarcaId", False, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "FamiliaProyeccionID", "FamiliaProyeccionID", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "TiendaIDSicy", "TiendaIDSicy", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "FechacreacionPartida", "FechacreacionPartida", True, False, Nothing, 70, True)

        AgregarColumna(gridPartidas, "plnclienteidproy", "plnclienteidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnclientesicyidproy", "plnclientesicyidproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnprocesoproy", "plnprocesoproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPedidoSicyIDproy", "plnPedidoSicyIDproy", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPartidaproy", "plnPartidaproy", True, False, Nothing, 70, True)

        AgregarColumna(gridPartidas, "plnclienteidconf", "plnclienteidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnclientesicyidconf", "plnclientesicyidconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnprocesoconf", "plnprocesoconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPedidoSicyIDconf", "plnPedidoSicyIDconf", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPartidaconf", "plnPartidaconf", True, False, Nothing, 70, True)

        AgregarColumna(gridPartidas, "plnclienteidemb", "plnclienteidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnclientesicyidemb", "plnclientesicyidemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnprocesoemb", "plnprocesoemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPedidoSicyIDemb", "plnPedidoSicyIDemb", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPartidaemb", "plnPartidaemb", True, False, Nothing, 70, True)

        AgregarColumna(gridPartidas, "plnclienteidsld", "plnclienteidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnclientesicyidsld", "plnclientesicyidsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnprocesosld", "plnprocesosld", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPedidoSicyIDsld", "plnPedidoSicyIDsld", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "plnPartidasld", "plnPartidasld", True, False, Nothing, 70, True)

        AgregarColumna(gridPartidas, "FechaCaptura", "FechaCaptura", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "total_pend", "total_pend", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "total_ialm", "total_ialm", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "total_ipro", "total_ipro", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "total_axc", "total_axc", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "prosp_pend", "prosp_pend", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "prosp_ialm", "prosp_ialm", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "prosp_ipro", "prosp_ipro", True, False, Nothing, 70, True)
        AgregarColumna(gridPartidas, "prosp_axc", "prosp_axc", True, False, Nothing, 70, True)




        Return dtEncabezadoProspecta

    End Function


    Private Sub OcultarColumnas()
        Dim objProspecta As New Entidades.ProspectaInformacion
        Dim EstadoPropectaID As Integer = 0
        Dim Layout As UltraGridLayout
        Dim rootBand As UltraGridBand

        If ProspectaID = -1 Then 'Alta Prospecta

            With gridListaProspecta

                .DisplayLayout.Bands(0).Columns("Edita").Hidden = True
                .DisplayLayout.Bands(0).Columns("Edición").Hidden = True

                .DisplayLayout.Bands(0).Columns("BL A").Hidden = True
                .DisplayLayout.Bands(0).Columns("S/INV A").Hidden = True
                .DisplayLayout.Bands(0).Columns("COTS A").Hidden = True
                .DisplayLayout.Bands(0).Columns("PAGP A").Hidden = True
                .DisplayLayout.Bands(0).Columns("Bloqueo Entrega A").Hidden = True
                .DisplayLayout.Bands(0).Columns("AtencionClienteID").Hidden = True
                .DisplayLayout.Bands(0).Columns("TipoEmpaqueID").Hidden = True
                .DisplayLayout.Bands(0).Columns("clienteId").Hidden = True


                .DisplayLayout.Bands(0).Columns("total_PEND").Hidden = True
                .DisplayLayout.Bands(0).Columns("total_IALM").Hidden = True
                .DisplayLayout.Bands(0).Columns("total_IPRO").Hidden = True
                .DisplayLayout.Bands(0).Columns("total_AXC").Hidden = True

                .DisplayLayout.Bands(0).Columns("pros_PEND").Hidden = True
                .DisplayLayout.Bands(0).Columns("pros_IALM").Hidden = True
                .DisplayLayout.Bands(0).Columns("pros_IPRO").Hidden = True
                .DisplayLayout.Bands(0).Columns("pros_AXC").Hidden = True

                .DisplayLayout.Bands(0).Columns("prog_PEND").Hidden = True
                .DisplayLayout.Bands(0).Columns("prog_IALM").Hidden = True
                .DisplayLayout.Bands(0).Columns("prog_IPRO").Hidden = True
                .DisplayLayout.Bands(0).Columns("prog_AXC").Hidden = True
                .DisplayLayout.Bands(0).Columns("prog_suma").Hidden = True

                .DisplayLayout.Bands(0).Columns("actual_total_PEND").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_total_IALM").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_total_IPRO").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_total_AXC").Hidden = False

                .DisplayLayout.Bands(0).Columns("actual_pros_PEND").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_pros_IALM").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_pros_IPRO").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_pros_AXC").Hidden = False

                .DisplayLayout.Bands(0).Columns("actual_prog_PEND").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_prog_IALM").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_prog_IPRO").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_prog_AXC").Hidden = False
                .DisplayLayout.Bands(0).Columns("actual_prog_suma").Hidden = False


                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsProy").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Proy").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Proy").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs ConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No ConfOT").Hidden = True


                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsEmb").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Emb").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Emb").Hidden = True


                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsSal").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Sal").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Sal").Hidden = True

            End With


            With gridPedidos

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsProy").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Proy").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Proy").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs ConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No ConfOT").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsEmb").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Emb").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Emb").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsSal").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Sal").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Sal").Hidden = True

            End With

            With gridPartidas

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsProy").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Proy").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Proy").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs ConfOT").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No ConfOT").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next

                .DisplayLayout.Bands(0).Columns("PrsEmb").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Emb").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Emb").Hidden = True

                For Each dia As Entidades.ProspectaDias In DiasProspecta
                    .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = True
                Next


                .DisplayLayout.Bands(0).Columns("PrsSal").Hidden = True
                .DisplayLayout.Bands(0).Columns("% Prs Sal").Hidden = True
                .DisplayLayout.Bands(0).Columns("Prs No Sal").Hidden = True


                .DisplayLayout.Bands(0).Columns("prog_PEND").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_IALM").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_IPRO").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_AXC").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_suma").Hidden = True

            End With

        Else

            objProspecta = ObtenerInformacionProspecta(ProspectaID)
            EstadoPropectaID = objProspecta.IDEstatusProspecta

            With gridListaProspecta
                .DisplayLayout.Bands(0).Columns("AtencionClienteID").Hidden = True
                .DisplayLayout.Bands(0).Columns("TipoEmpaqueID").Hidden = True
                .DisplayLayout.Bands(0).Columns("clienteId").Hidden = True

                'For Each dia As Entidades.ProspectaDias In DiasProspecta
                '    .DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = 
                'Next

            End With

            With gridPedidos
                .DisplayLayout.Bands(0).Columns("ProspectaPedidoID").Hidden = True
                .DisplayLayout.Bands(0).Columns("clienteId").Hidden = True
                .DisplayLayout.Bands(0).Columns("AtencionClienteID").Hidden = True
                .DisplayLayout.Bands(0).Columns("plnclienteid").Hidden = True
                .DisplayLayout.Bands(0).Columns("plnclientesicyid").Hidden = True
                .DisplayLayout.Bands(0).Columns("plnproceso").Hidden = True
                .DisplayLayout.Bands(0).Columns("plnPedidoSicyID").Hidden = True

                .DisplayLayout.Bands(0).Columns("prog_PEND").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_IALM").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_IPRO").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_AXC").Hidden = False
                .DisplayLayout.Bands(0).Columns("prog_suma").Hidden = True

            End With

            With gridPartidas
                .DisplayLayout.Bands(0).Columns("clienteId").Hidden = True
                .DisplayLayout.Bands(0).Columns("AtencionClienteID").Hidden = True
            End With

            If EstadoPropectaID = 87 Then

                Layout = gridListaProspecta.DisplayLayout
                rootBand = Layout.Bands(0)

                Dim Grupo As UltraGridGroup = rootBand.Groups("PROYECCIÓN")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("CONFIRMACIÓN OT")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("EMBARQUE")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("SALIDA")
                Grupo.Hidden = True

                Layout = gridPedidos.DisplayLayout
                rootBand = Layout.Bands(0)

                Grupo = rootBand.Groups("PROYECCIÓN")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("CONFIRMACIÓN OT")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("EMBARQUE")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("SALIDA")
                Grupo.Hidden = True


                Layout = gridPartidas.DisplayLayout
                rootBand = Layout.Bands(0)

                Grupo = rootBand.Groups("PROYECCIÓN")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("CONFIRMACIÓN OT")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("EMBARQUE")
                Grupo.Hidden = True

                Grupo = rootBand.Groups("SALIDA")
                Grupo.Hidden = True


            End If


        End If

    End Sub

    Private Sub OcultarColumnasPestañaCliente()

        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        Dim Layout As UltraGridLayout = gridListaProspecta.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim Grupo As UltraGridGroup


        With gridListaProspecta


            .DisplayLayout.Bands(0).Columns("Cliente").Hidden = False
            .DisplayLayout.Bands(0).Columns("PR").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("BL").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("SINV").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("COTS").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("PAGP").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Bloqueo Entrega").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("BL A").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("S/INV A").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("COTS A").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("PAGP A").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Bloqueo Entrega A").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Ejecutiva").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Agente").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Empaque").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("EtEsp").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("ImPPCP").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("DE").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Plazo 0").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("Cita").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("DA").Hidden = Not chkInfoCliente.Checked
            .DisplayLayout.Bands(0).Columns("PC").Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("INFO. PROSPECTA")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("PR")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("AtnCtes")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("Agente")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("Empaque")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("EtEsp")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("ImPPCP")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("DE")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("Plazo 0")
            Grupo.Hidden = Not chkInfoCliente.Checked


            Grupo = rootBand.Groups("Cita")
            Grupo.Hidden = Not chkInfoCliente.Checked


            Grupo = rootBand.Groups("DA")
            Grupo.Hidden = Not chkInfoCliente.Checked

            Grupo = rootBand.Groups("PC")
            Grupo.Hidden = Not chkInfoCliente.Checked


            Grupo = rootBand.Groups("INFO. PROSPECTA ACTUAL")
            Grupo.Hidden = Not chkInfoCliente.Checked

            If ProspectaID = -1 Then
                '-------------chkInfoCliente.Checked               
                .DisplayLayout.Bands(0).Columns("BL A").Hidden = True
                .DisplayLayout.Bands(0).Columns("S/INV A").Hidden = True
                .DisplayLayout.Bands(0).Columns("COTS A").Hidden = True
                .DisplayLayout.Bands(0).Columns("PAGP A").Hidden = True
                .DisplayLayout.Bands(0).Columns("Bloqueo Entrega A").Hidden = True

                Grupo = rootBand.Groups("INFO. PROSPECTA ACTUAL")
                Grupo.Hidden = True
            End If

            '-----------------------------------------------

        End With

    End Sub

    Private Sub OcultarColumnasPestañaProspécta()
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If

        Dim Layout As UltraGridLayout = gridListaProspecta.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim Grupo As UltraGridGroup

        If ProspectaID = -1 Then
            With gridListaProspecta
                'chkInfoProspecta.Checked 
                .DisplayLayout.Bands(0).Columns("total_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("pros_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("prog_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_AXC").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_suma").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("actual_total_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("actual_pros_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_pros_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("actual_prog_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_AXC").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_suma").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("Conf").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("Confirma").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("FConfirmacion").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("*Incidencia").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("*Observaciones").Hidden = Not chkInfoProspecta.Checked
                '-----------------------------------------------

                Grupo = rootBand.Groups("PEND X ENTREGAR ")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("FPROSPECTA ")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("FPROGRAMACION ")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("CONFIRMACIÓN CLIENTE")
                Grupo.Hidden = Not chkInfoProspecta.Checked

            End With
        Else
            With gridListaProspecta

                'chkInfoProspecta.Checked               
                .DisplayLayout.Bands(0).Columns("total_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("total_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("pros_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("pros_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("prog_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_AXC").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("prog_suma").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("actual_total_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_total_AXC").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("actual_pros_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_pros_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_pros_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_pros_AXC").Hidden = Not chkInfoProspecta.Checked


                .DisplayLayout.Bands(0).Columns("actual_prog_PEND").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_IALM").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_IPRO").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_AXC").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("actual_prog_suma").Hidden = Not chkInfoProspecta.Checked

                .DisplayLayout.Bands(0).Columns("Conf").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("Confirma").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("FConfirmacion").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("*Incidencia").Hidden = Not chkInfoProspecta.Checked
                .DisplayLayout.Bands(0).Columns("*Observaciones").Hidden = Not chkInfoProspecta.Checked
                '-----------------------------------------------


                Grupo = rootBand.Groups("PEND X ENTREGAR")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("FPROSPECTA")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("FPROGRAMACION")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("ACTUAL PEND X ENTREGAR")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("ACTUAL FPROSPECTA")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("ACTUAL FPROGRAMACION")
                Grupo.Hidden = Not chkInfoProspecta.Checked

                Grupo = rootBand.Groups("CONFIRMACIÓN CLIENTE")
                Grupo.Hidden = Not chkInfoProspecta.Checked

            End With
        End If

    End Sub



    Private Sub OcultarColumnasPestañaMedicion()
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If

        Dim Layout As UltraGridLayout = gridListaProspecta.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim Grupo As UltraGridGroup


        With gridListaProspecta
            'chkInfoMedicion.Checked

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Not chkInfoMedicion.Checked
            Next
            .DisplayLayout.Bands(0).Columns("PrsProsp").Hidden = Not chkInfoMedicion.Checked

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Not chkInfoMedicion.Checked
            Next

            .DisplayLayout.Bands(0).Columns("PrsProy").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("% Prs Proy").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("Prs No Proy").Hidden = Not chkInfoMedicion.Checked

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Not chkInfoMedicion.Checked
            Next

            .DisplayLayout.Bands(0).Columns("PrsConfOT").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("% Prs ConfOT").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("Prs No ConfOT").Hidden = Not chkInfoMedicion.Checked


            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Not chkInfoMedicion.Checked
            Next

            .DisplayLayout.Bands(0).Columns("PrsEmb").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("% Prs Emb").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("Prs No Emb").Hidden = Not chkInfoMedicion.Checked

            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Not chkInfoMedicion.Checked
            Next

            .DisplayLayout.Bands(0).Columns("PrsSal").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("% Prs Sal").Hidden = Not chkInfoMedicion.Checked
            .DisplayLayout.Bands(0).Columns("Prs No Sal").Hidden = Not chkInfoMedicion.Checked

            Grupo = rootBand.Groups("PROSPECTA")
            Grupo.Hidden = Not chkInfoMedicion.Checked

            If ProspectaID <> -1 Then
                If IdEstadoProspecta <> 87 Then
                    Grupo = rootBand.Groups("PROYECCIÓN")
                    Grupo.Hidden = Not chkInfoMedicion.Checked


                    Grupo = rootBand.Groups("CONFIRMACIÓN OT")
                    Grupo.Hidden = Not chkInfoMedicion.Checked


                    Grupo = rootBand.Groups("EMBARQUE")
                    Grupo.Hidden = Not chkInfoMedicion.Checked


                    Grupo = rootBand.Groups("SALIDA")
                    Grupo.Hidden = Not chkInfoMedicion.Checked
                End If
            End If


        End With

    End Sub
    Private Sub chkPlaneacionSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chkPlaneacionSemanal.CheckedChanged

        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        If chkInfoMedicion.Checked = False Then
            Return
        End If
        Dim Ocultar As Boolean
        Ocultar = chkPlaneacionSemanal.Checked
        With gridListaProspecta
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPedidos
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPartidas
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With
    End Sub

    Private Sub chkProyeccionSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chkProyeccionSemanal.CheckedChanged
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        If chkInfoMedicion.Checked = False Then
            Return
        End If
        Dim Ocultar As Boolean
        Ocultar = chkProyeccionSemanal.Checked
        With gridListaProspecta
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPedidos
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPartidas
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("proy_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

    End Sub



    Private Sub chkConfirmacionOTSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmacionOTSemanal.CheckedChanged
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        If chkInfoMedicion.Checked = False Then
            Return
        End If
        Dim Ocultar As Boolean
        Ocultar = chkConfirmacionOTSemanal.Checked
        With gridListaProspecta
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPedidos
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPartidas
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("ConfOT_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With
    End Sub


    Private Sub chkEmbarcadoSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chkEmbarcadoSemanal.CheckedChanged
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        If chkInfoMedicion.Checked = False Then
            Return
        End If
        Dim Ocultar As Boolean
        Ocultar = chkEmbarcadoSemanal.Checked
        With gridListaProspecta
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPedidos
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next

        End With

        With gridPartidas
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Emb_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next

        End With
    End Sub



    Private Sub chkSalidaSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chkSalidaSemanal.CheckedChanged
        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If
        If chkInfoMedicion.Checked = False Then
            Return
        End If
        Dim Ocultar As Boolean
        Ocultar = chkSalidaSemanal.Checked
        With gridListaProspecta
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPedidos
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With

        With gridPartidas
            For Each dia As Entidades.ProspectaDias In DiasProspecta
                .DisplayLayout.Bands(0).Columns("Sal_" + dia.NombreDia + dia.NumeroDia.ToString()).Hidden = Ocultar
            Next
        End With
    End Sub



    Private Sub tabProspecta_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabProspecta.Selecting
        Cursor = Cursors.WaitCursor
        Dim TabIndexSeleccinado As Int32 = e.TabPageIndex
        Dim ListaSeleccionados As List(Of Integer)
        Dim listaclienteSeleccionados As List(Of Integer)
        Dim listaPedidosSeleccionados As List(Of Integer)
        Dim ActualizarDistribucionPares As Boolean = False


        If TabIndexSeleccinado > IndexTabActual Then
            If TabIndexSeleccinado = 1 Then 'Pedidos
                If IndexTabActual = 0 Then
                    listaclienteSeleccionados = ObtenerClientesSeleccinadosGrid()
                    If listaclienteSeleccionados.Count = 0 Then
                        show_message("Aviso", "No hay clientes Seleccionados")
                        ActualizarDistribucionPares = False
                        tabProspecta.SelectedIndex = IndexTabActual
                    Else
                        ActualizarDistribucionPares = True
                    End If
                End If


            ElseIf TabIndexSeleccinado = 2 Then 'Partidas
                If IndexTabActual = 1 Then
                    listaPedidosSeleccionados = ObtenerPedidosSeleccinadosGrid()
                    If listaPedidosSeleccionados.Count = 0 Then
                        show_message("Aviso", "No hay pedidos Seleccionados")
                        ActualizarDistribucionPares = False
                        tabProspecta.SelectedIndex = IndexTabActual
                    Else
                        ActualizarDistribucionPares = True
                    End If

                Else
                    listaPedidosSeleccionados = ObtenerPedidosSeleccinadosGrid()
                    If listaPedidosSeleccionados.Count = 0 Then
                        show_message("Aviso", "No hay pedidos Seleccionados")
                        ActualizarDistribucionPares = False
                        tabProspecta.SelectedIndex = IndexTabActual
                    Else
                        ActualizarDistribucionPares = True
                    End If
                End If
            End If
        Else
            ActualizarDistribucionPares = True
            IndexTabActual = e.TabPageIndex
        End If



        If ActualizarDistribucionPares = True Then
            If e.TabPage.Text = "Pedidos" Then
                ListaSeleccionados = ObtenerClientesSeleccinadosGrid()
                If ListaSeleccionados.Count > 0 Then
                    LlenaGridPedidos(True)
                    IndexTabActual = e.TabPageIndex
                    RecargarGridPartidas()
                Else
                    show_message("Aviso", "No hay clientes Seleccionados")
                    gridPedidos.DataSource = Nothing
                    CargarEncabezadoPedidos()
                    DiseñoEncabezadoPedidos(gridPedidos)
                    tabProspecta.SelectedIndex = IndexTabActual

                End If
                'CargarEncabezadoPartidas()


            ElseIf e.TabPage.Text = "Partidas" Then

                ListaSeleccionados = ObtenerPedidosSeleccinadosGrid()
                If ListaSeleccionados.Count > 0 Then
                    LlenaGridPartidas(True)
                    IndexTabActual = e.TabPageIndex
                Else
                    show_message("Aviso", "No hay Pedidos Seleccionados")
                    gridPartidas.DataSource = Nothing
                    CargarEncabezadoPartidas()
                    DiseñoEnzabezadoPartidas(gridPartidas)
                    tabProspecta.SelectedIndex = IndexTabActual
                End If
            End If

            If IndexTabActual = TabIndexSeleccinado Then
                'If IsNothing(gridPartidas.DataSource) = False Then
                '    ActualizarCantidadParesPedidoPartida()
                'End If

                'If IsNothing(gridPedidos.DataSource) = False Then
                '    ActualizarCantidadParesProspectaPedido()
                'End If


                OcultarColumnas()

            End If

        End If



        Cursor = Cursors.Default
    End Sub

    Private Sub chkProspectaSi_CheckedChanged(sender As Object, e As EventArgs) Handles chkProspectaSi.CheckedChanged
        FiltrarInformacion()
    End Sub

    Private Sub chkProspectaNo_CheckedChanged(sender As Object, e As EventArgs) Handles chkProspectaNo.CheckedChanged
        FiltrarInformacion()
    End Sub


    Private Sub FiltroProspectaSiNo()

        If gridListaProspecta.Rows.Count <= 0 Then
            Return
        End If

        'If chkProspectaSi.Checked = False Or chkProspectaNo.Checked = False Then
        '    'Cargar Grid
        'End If

        FiltrarDatosProspectadosCliente(gridListaProspecta, chkProspectaSi.Checked, chkProspectaNo.Checked)

        If gridPedidos.Rows.Count > 0 Then
            FiltrarDatosProspectadosCliente(gridPedidos, chkProspectaSi.Checked, chkProspectaNo.Checked)
        End If

        If gridPartidas.Rows.Count > 0 Then
            FiltrarDatosProspectadosCliente(gridPartidas, chkProspectaSi.Checked, chkProspectaNo.Checked)
        End If


    End Sub

    Private Sub FiltrarDatosProspectadosCliente(ByVal grid As UltraGrid, ByVal MostrarSi As Boolean, ByVal MostrarNo As Boolean)
        For Each Fila As UltraGridRow In grid.Rows
            If MostrarSi = False Then
                If Fila.Cells("PR").Value = "SI" Then
                    Fila.Hidden = True
                End If
            Else
                If Fila.Cells("PR").Value = "SI" Then
                    Fila.Hidden = False
                End If
            End If

            If MostrarNo = False Then
                If Fila.Cells("PR").Value = "NO" Then
                    Fila.Hidden = True
                End If
            Else
                If Fila.Cells("PR").Value = "NO" Then
                    Fila.Hidden = False
                End If
            End If
        Next
        grid.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
    End Sub

    Private Sub FiltrarDatosProspectadosCliente(ByVal fila As UltraGridRow, ByVal MostrarSi As Boolean, ByVal MostrarNo As Boolean)
        If MostrarSi = False Then
            If fila.Cells("PR").Value = "SI" Then
                fila.Hidden = True
            End If
        Else
            If fila.Cells("PR").Value = "SI" Then
                fila.Hidden = False
            End If
        End If

        If MostrarNo = False Then
            If fila.Cells("PR").Value = "NO" Then
                fila.Hidden = True
            End If
        Else
            If fila.Cells("PR").Value = "NO" Then
                fila.Hidden = False
            End If
        End If
    End Sub

    Private Sub FiltrarInformacionGrid(ByVal grid As UltraGrid)


        If grid.Rows.Count <= 0 Then
            Return
        End If

        For Each Fila As UltraGridRow In grid.Rows
            Fila.Hidden = False
            FiltrarDatosProspectadosCliente(Fila, chkProspectaSi.Checked, chkProspectaNo.Checked)
            If grdAtnClientes.Rows.Count > 0 Then
                If ExisteFiltroAtencionClientes(Fila.Cells("AtencionClienteID").Value) = False Then
                    Fila.Hidden = True
                End If
            End If

            If grid.Name = "gridListaProspecta" Then
                If TipoPerfil = 4 Then 'Atencion Clientes externo                   
                    If Fila.Cells("AtencionClienteID").Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser Then
                        Fila.Hidden = False
                    Else
                        Fila.Hidden = True
                    End If
                End If
            End If

            If grdFiltroClientes.Rows.Count > 0 Then
                If ExisteFiltroClientes(Fila.Cells("ClienteSayID").Value) = False Then
                    Fila.Hidden = True
                End If
            End If


        Next

        grid.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
    End Sub

    Private Sub FiltrarInformacion()

        FiltrarInformacionGrid(gridListaProspecta)
        FiltrarInformacionGrid(gridPedidos)
        FiltrarInformacionGrid(gridPartidas)



    End Sub

    Private Function ExisteFiltroAtencionClientes(ByVal AtencionClienteID As Integer) As Boolean
        Dim Existe As Boolean = False
        For Each Fila As UltraGridRow In grdAtnClientes.Rows
            If Fila.Cells(0).Text = AtencionClienteID Then
                Return True
            End If
        Next
        Return Existe
    End Function

    Private Function ExisteFiltroClientes(ByVal ClienteID As Integer) As Boolean
        Dim Existe As Boolean = False
        For Each Fila As UltraGridRow In grdFiltroClientes.Rows
            If Fila.Cells(0).Text = ClienteID Then
                Return True
            End If
        Next
        Return Existe
    End Function

    Private Sub ValidarCumplePartidaCompleta(ByVal fila As UltraGridRow)

        'Dim Existe As Boolean = False
        'Dim SumaParesProgramacion As Integer = 0
        'If fila.Cells("PC").Value = "Si" Then
        '    SumaParesProgramacion = fila.Cells("actual_prog_IALM").Value + fila.Cells("actual_prog_AXC").Value
        '    If SumaParesProgramacion <> fila.Cells("actual_prog_PEND").Value Then
        '        fila.Cells(" ").Hidden = True
        '    End If
        'End If
    End Sub


    Private Function ValidarParesPlaneadosCompletos() As Boolean
        Dim ParesPlaneadosCompletos As Boolean = True
        Dim Celda As UltraGridCell

        Dim ListaPEdidosL As New List(Of Integer)
        Dim ListaClientesL As New List(Of Integer)
        Dim countPartidasCompletas As Integer = 0
        Dim ValidarEstadoProspecta As Boolean = False
        Dim objentProspecta As New Entidades.ProspectaInformacion
        Dim ParesNoValidos As Integer = 0

        If ProspectaID <> -1 Then
            objentProspecta = ObtenerInformacionProspecta(ProspectaID)
            If objentProspecta.IDEstatusProspecta = 87 Then
                ValidarEstadoProspecta = True
            Else
                ValidarEstadoProspecta = False
            End If
        Else
            ValidarEstadoProspecta = True
        End If



        If ValidarEstadoProspecta = True Then
            If tabProspecta.SelectedIndex = 0 Then
                For Each fila As UltraGridRow In gridListaProspecta.Rows

                    If fila.Hidden = False Then
                        Celda = fila.Cells("PrsProsp")
                        If Celda.Appearance.ForeColor = Color.Purple Then
                            countPartidasCompletas += 1
                            ListaClientesL.Add(fila.Cells("ClienteSicyID").Value)
                        ElseIf Celda.Appearance.ForeColor = Color.OrangeRed Then
                            ParesNoValidos += 1
                        End If

                        'If (Celda.Appearance.ForeColor = Color.OrangeRed) Then
                        '    If IsDBNull(Celda.Value) = False Then
                        '        If Celda.Value <> 0 Then
                        '            ParesPlaneadosCompletos = False
                        '        End If
                        '    End If
                        'ElseIf Celda.Appearance.ForeColor = Color.Purple Then
                        '    ListaClientesL.Add(fila.Cells("ClienteSicyID").Value)
                        'End If
                    End If
                Next

                If ListaClientesL.Count > 0 Then
                    For Each fila As UltraGridRow In gridPedidos.Rows
                        If ListaClientesL.Exists(Function(x) x = fila.Cells("clienteid").Value) = True Then
                            ListaPEdidosL.Add(fila.Cells("PSICY").Value)
                        End If
                    Next
                End If


            ElseIf tabProspecta.SelectedIndex = 1 Then

                For Each fila As UltraGridRow In gridPedidos.Rows
                    If fila.Hidden = False Then
                        Celda = fila.Cells("PrsProsp")
                        If (Celda.Appearance.ForeColor = Color.Purple) Then
                            ListaPEdidosL.Add(fila.Cells("PSICY").Value)
                            ListaClientesL.Add(fila.Cells("clienteid").Value)
                            countPartidasCompletas += 1
                        End If


                        'If (Celda.Appearance.ForeColor = Color.OrangeRed) Then
                        '    If IsDBNull(Celda.Value) = False Then
                        '        If Celda.Value <> 0 Then
                        '            ParesPlaneadosCompletos = False
                        '        End If
                        '    End If
                        'ElseIf (Celda.Appearance.ForeColor = Color.Purple) Then
                        '    ListaPEdidosL.Add(fila.Cells("PSICY").Value)
                        '    ListaClientesL.Add(fila.Cells("clienteid").Value)
                        'End If
                    End If
                Next

            ElseIf tabProspecta.SelectedIndex = 2 Then
                For Each fila As UltraGridRow In gridPartidas.Rows
                    If fila.Hidden = False Then
                        Celda = fila.Cells("PrsProsp")
                        If (Celda.Appearance.ForeColor = Color.Purple) Then
                            ListaPEdidosL.Add(fila.Cells("PSICY").Value)
                            ListaClientesL.Add(fila.Cells("ClientesicyId").Value)
                            countPartidasCompletas += 1
                        End If

                        'If (Celda.Appearance.ForeColor = Color.OrangeRed) Then
                        '    If IsDBNull(Celda.Value) = False Then
                        '        If Celda.Value <> 0 Then
                        '            ParesPlaneadosCompletos = False
                        '        End If
                        '    End If
                        'ElseIf (Celda.Appearance.ForeColor = Color.Purple) Then
                        '    ListaPEdidosL.Add(fila.Cells("PSICY").Value)
                        '    ListaClientesL.Add(fila.Cells("ClientesicyId").Value)
                        'End If
                    End If
                Next
            End If

            If countPartidasCompletas = 0 Then
                ListaPEdidosL.Clear()
                ListaClientesL.Clear()
            Else
                If IsNothing(ListaPedidosProspectadosCompletos) = False Then
                    ListaPedidosProspectadosCompletos.Clear()
                End If
                If IsNothing(ListaClientesProspectadosCompletos) = False Then
                    ListaClientesProspectadosCompletos.Clear()
                End If


                ListaPedidosProspectadosCompletos = ListaPEdidosL.Distinct().ToList()
                ListaClientesProspectadosCompletos = ListaClientesL.Distinct().ToList()
            End If
        End If

        If ValidarEstadoProspecta = True Then
            If countPartidasCompletas > 0 Then
                Return True
            Else
                If ParesNoValidos > 0 Then
                    Return False
                Else
                    Return True

                End If
                Return False
            End If
        Else
            Return True
        End If

        Return ParesPlaneadosCompletos

    End Function

    Public Sub GuardarCliente(ByVal ProspectaIDLocal As Integer)
        Dim ListaPedidosModificados As New List(Of Integer)
        Dim ListaClientesModificados As New List(Of Integer)

        Dim ListaIndicePedidosEliminar As New List(Of Integer)
        Dim ListaIndicePartidasEliminar As New List(Of Integer)
        Dim ListaIndiceClientesElimnar As New List(Of Integer)

        Dim ClienteSayID As Integer
        Dim ClienteSicyID As Integer
        Dim BL As String
        Dim SinInventario As String
        Dim NumeroCotizaciones As Integer
        Dim PagosPendientes As String
        Dim EstatusBloqueoID As Integer
        Dim ProspectaPEND As Integer
        Dim ProspectaIALM As Integer
        Dim ProspectaIPRO As Integer
        Dim ProspectaAXC As Integer
        Dim TotalPEND As Integer
        Dim TotalIALM As Integer
        Dim TotalIPRO As Integer
        Dim TotalAXC As Integer
        Dim ProgramacionPEND As Integer
        Dim ProgramacionIALM As Integer
        Dim ProgramacionIPRO As Integer
        Dim ProgramacionAXC As Integer
        Dim ConfirmacionEntrega As Boolean
        Dim UsuarioConfirmo As Integer
        Dim FechaConfirmacion As Date
        Dim MotivoID As Integer
        Dim Observaciones As String
        Dim TotalParesProspecta As Integer
        Dim UsuarioCreoID As Integer
        Dim Celda As UltraGridCell
        Dim PA As String
        Dim PR As String
        Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU
        Dim CantidadPares As Integer
        Dim numeropares As Int32 = gridPartidas.Rows.Count
        Dim PEND As Int32
        Dim IALM As Int32
        Dim IPRO As Int32
        Dim AXC As Int32
        Dim IdCodigoSicy As String = String.Empty
        Dim IdTalla As String = String.Empty
        Dim FechaProgramacion As Date
        Dim ClienteSicy As Int32
        Dim val As String = String.Empty
        Dim ProductoEstilo As Integer
        Dim FamiliaProyeccion As Integer
        Dim IdTienda As Integer
        Dim FechaCreacion As Date
        Dim ParesPartida As Integer
        Dim MarcaID As Integer      
        Dim PedidoID As Integer
        Dim Partida As Integer
        Dim CantidadParesPartida As Integer
        Dim FilaCl As UltraGridRow
        Dim FilaPed As UltraGridRow
        Dim FilaPart As UltraGridRow
        Dim _PA As String = String.Empty
        Dim SeProspectaPorCliente As Boolean = False
        Dim DataSetPedidos As DataTable
        Dim DataSetPartidas As DataTable

        DataSetPedidos = gridPedidos.DataSource
        DataSetPartidas = gridPartidas.DataSource

     
        Dim RowsPedidos As DataRow()
        Dim RowsPartidas As DataRow()


        Try
            If ProspectaID = -1 Then
             

                For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows

                    SeProspectaPorCliente = False

                    Celda = FilaCliente.Cells("PrsProsp")
                    PA = FilaCliente.Cells("PA").Value
                    PR = FilaCliente.Cells("PR").Value
                    BL = FilaCliente.Cells("BL").Value
                    SinInventario = FilaCliente.Cells("SINV").Value
                    If IsDBNull(FilaCliente.Cells("COTS").Value) = False Then
                        NumeroCotizaciones = FilaCliente.Cells("COTS").Value
                    Else
                        NumeroCotizaciones = Nothing
                    End If

                    If IsDBNull(FilaCliente.Cells("PAGP").Value) = False Then
                        PagosPendientes = FilaCliente.Cells("PAGP").Value
                    Else
                        PagosPendientes = Nothing
                    End If

                    If IsDBNull(FilaCliente.Cells("BloqueoID").Value) = False Then
                        EstatusBloqueoID = FilaCliente.Cells("BloqueoID").Value
                    Else
                        EstatusBloqueoID = Nothing
                    End If

                    If FilaCliente.Cells("Conf").Value = True Then
                        UsuarioConfirmo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    Else
                        UsuarioConfirmo = -1
                    End If


                    If IsNothing(FilaCliente.Cells("FConfirmacion").Value) = False And IsDBNull(FilaCliente.Cells("FConfirmacion").Value) = False Then
                        FechaConfirmacion = CDate(FilaCliente.Cells("FConfirmacion").Value)
                    Else
                        FechaConfirmacion = Nothing
                    End If


                    If IsNothing(FilaCliente.Cells("*Incidencia").Value) = False Then
                        MotivoID = FilaCliente.Cells("*Incidencia").Column.ValueList.GetValue(FilaCliente.Cells("*Incidencia").Value.ToString, 0)
                    Else
                        MotivoID = -1
                    End If

                    Observaciones = CStr(FilaCliente.Cells("*Observaciones").Value)
                    If String.IsNullOrEmpty(Observaciones) = True Then
                        Observaciones = String.Empty
                    End If

                    ConfirmacionEntrega = FilaCliente.Cells("Conf").Value

                    TotalPEND = FilaCliente.Cells("actual_total_PEND").Value
                    TotalIALM = FilaCliente.Cells("actual_total_IALM").Value
                    TotalIPRO = FilaCliente.Cells("actual_total_IPRO").Value
                    TotalAXC = FilaCliente.Cells("actual_total_AXC").Value

                    ProspectaPEND = FilaCliente.Cells("actual_pros_PEND").Value
                    ProspectaIALM = FilaCliente.Cells("actual_pros_IALM").Value
                    ProspectaIPRO = FilaCliente.Cells("actual_pros_IPRO").Value
                    ProspectaAXC = FilaCliente.Cells("actual_pros_AXC").Value

                    ProgramacionPEND = FilaCliente.Cells("actual_prog_PEND").Value
                    ProgramacionIALM = FilaCliente.Cells("actual_prog_IALM").Value
                    ProgramacionIPRO = FilaCliente.Cells("actual_prog_IPRO").Value
                    ProgramacionAXC = FilaCliente.Cells("actual_prog_AXC").Value

                    FilaCliente.Cells("*Observaciones").Appearance.ForeColor = Color.Black
                    FilaCliente.Cells("*Incidencia").Appearance.ForeColor = Color.Black

                    If FilaCliente.Cells("PA").Value = "SI" Then
                        If Celda.Appearance.ForeColor = Color.Purple Then
                            TotalParesProspecta = Celda.Value
                            FilaCliente.Cells("Confirma").Appearance.ForeColor = Color.Black
                            FilaCliente.Cells("FConfirmacion").Appearance.ForeColor = Color.Black

                            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                            Next

                            FilaCliente.Cells("PrsProsp").Appearance.ForeColor = Color.Black

                            ListaClientesModificados.Add(FilaCliente.Cells("ClienteSayID").Value)



                        Else
                            TotalParesProspecta = 0
                        End If
                    End If

                    If FilaCliente.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
                        If FilaCliente.Cells("PrsProsp").Value <> 0 Then
                            FilaCliente.Cells("PR").Value = "SI"
                            FilaCliente.Cells("PR").Appearance.BackColor = Color.Green
                        Else
                            FilaCliente.Cells("PR").Value = "NO"
                            FilaCliente.Cells("PR").Appearance.BackColor = Color.Red
                        End If
                    End If


                    ClienteSayID = FilaCliente.Cells("ClienteSayID").Value
                    ClienteSicyID = FilaCliente.Cells("ClienteSicyID").Value
                    UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                    ObjprospectaBU.GuardarInformacionCliente(ProspectaIDLocal, ClienteSayID, ClienteSicyID, BL, SinInventario, NumeroCotizaciones, PagosPendientes,
                                                             EstatusBloqueoID, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC, TotalPEND, TotalIALM,
                                                             TotalIPRO, TotalAXC, ProgramacionPEND, ProgramacionIALM, ProgramacionIPRO, ProgramacionAXC, ConfirmacionEntrega,
                                                             UsuarioConfirmo, FechaConfirmacion, MotivoID, Observaciones, TotalParesProspecta, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                    If FilaCliente.Cells("PA").Value = "NO" Then
                        Celda = FilaCliente.Cells("PrsProsp")
                        SeProspectaPorCliente = True
                        If (Celda.Appearance.ForeColor <> Color.Purple) Then
                            Continue For
                        End If

                        ClienteSayID = FilaCliente.Cells("ClienteSayID").Value
                        ' ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaID, -1, -1, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                        'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            If IsDBNull(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                CantidadPares = CInt(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                If CantidadPares <> 0 Then
                                    ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, -1, -1, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1, Nothing, -1, -1, -1, -1, "-1", "-1", -1, -1, -1, -1, Nothing, -1, -1, -1, -1, -1, -1, -1, -1, -1)
                                    FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    Celda.Appearance.ForeColor = Color.Black
                                End If
                            End If
                        Next
                    End If

                    If FilaCliente.Cells("*Incidencia").Appearance.ForeColor = Color.Purple Or FilaCliente.Cells("*Observaciones").Appearance.ForeColor = Color.Purple Then
                        SeProspectaPorCliente = True
                    End If

                    If SeProspectaPorCliente = True Then
                        RowsPartidas = DataSetPartidas.Select("ClienteSayID = " + ClienteSayID.ToString() + "")

                        For Each RowsPart As DataRow In RowsPartidas

                            PedidoID = RowsPart.Item("PSICY").ToString
                            Partida = RowsPart.Item("#Part").ToString



                            ParesPartida = RowsPart.Item("Prs Part").ToString()
                            MarcaID = CInt(RowsPart.Item("MarcaId").ToString)
                            TotalPEND = CInt(RowsPart.Item("total_pend").ToString)
                            TotalIALM = CInt(RowsPart.Item("total_ialm").ToString)
                            TotalIPRO = CInt(RowsPart.Item("total_ipro").ToString)
                            TotalAXC = CInt(RowsPart.Item("total_axc").ToString)
                            ProspectaPEND = CInt(RowsPart.Item("prosp_pend").ToString)
                            ProspectaIALM = CInt(RowsPart.Item("prosp_ialm").ToString)
                            ProspectaIPRO = CInt(RowsPart.Item("prosp_ipro").ToString)
                            ProspectaAXC = CInt(RowsPart.Item("prosp_axc").ToString)
                            FechaProgramacion = RowsPart.Item("FProg").ToString
                            PEND = RowsPart.Item("actual_prog_PEND").ToString
                            IALM = RowsPart.Item("actual_prog_IALM").ToString
                            IPRO = RowsPart.Item("actual_prog_IPRO").ToString
                            AXC = RowsPart.Item("actual_prog_AXC").ToString
                            FechaCreacion = CDate(RowsPart.Item("FCaptura").ToString)
                            ClienteSayID = RowsPart.Item("ClientesayId").ToString
                            ClienteSicy = RowsPart.Item("ClientesicyId").ToString



                            If IsDBNull(RowsPart.Item("ProductoEstiloID").ToString) = False Then
                                ProductoEstilo = CInt(RowsPart.Item("ProductoEstiloID").ToString)
                            Else
                                ProductoEstilo = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("FamiliaProyeccionID").ToString) = False Then
                                FamiliaProyeccion = CInt(RowsPart.Item("FamiliaProyeccionID").ToString)
                            Else
                                FamiliaProyeccion = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("TiendaIDSicy").ToString) = False Then
                                IdTienda = CInt(RowsPart.Item("TiendaIDSicy").ToString)
                            Else
                                IdTienda = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("IdCodigo").ToString) = False Then
                                IdCodigoSicy = RowsPart.Item("IdCodigo").ToString
                            Else
                                IdCodigoSicy = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("IdTalla").ToString) = False Then
                                IdTalla = RowsPart.Item("IdTalla").ToString
                            Else
                                IdTalla = Nothing
                            End If

                            'ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, 0, Date.Now, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)



                        Next


                    End If


                Next

             
            Else

                For Each filacliente As UltraGridRow In gridListaProspecta.Rows
                    SeProspectaPorCliente = False
                    Celda = filacliente.Cells("PrsProsp")
                    ClienteSayID = filacliente.Cells("ClienteSayID").Value
                    _PA = filacliente.Cells("PA").Value
                    If Celda.Appearance.ForeColor = Color.Purple And _PA = "NO" Then
                        ListaIndicesClientesModificadas.Add(filacliente.Index)
                        SeProspectaPorCliente = True
                    End If




                    If filacliente.Cells("ColumnaModificada").Value = True Or filacliente.Cells("*Incidencia").Appearance.ForeColor = Color.Purple Or filacliente.Cells("*Observaciones").Appearance.ForeColor = Color.Purple Then
                        ClienteSayID = filacliente.Cells("ClienteSayID").Value
                        ConfirmacionEntrega = filacliente.Cells("Conf").Value
                        SeProspectaPorCliente = True
                        If ConfirmacionEntrega = True Then
                            UsuarioConfirmo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        Else
                            UsuarioConfirmo = -1
                        End If


                        If IsNothing(filacliente.Cells("FConfirmacion").Value) = False And IsDBNull(filacliente.Cells("FConfirmacion").Value) = False Then
                            FechaConfirmacion = CDate(filacliente.Cells("FConfirmacion").Value)
                        Else
                            FechaConfirmacion = Nothing
                        End If


                        If IsNothing(filacliente.Cells("*Incidencia").Value) = False Then
                            MotivoID = filacliente.Cells("*Incidencia").Column.ValueList.GetValue(filacliente.Cells("*Incidencia").Value.ToString, 0)
                        Else
                            MotivoID = -1
                        End If

                        Observaciones = CStr(filacliente.Cells("*Observaciones").Value)
                        If String.IsNullOrEmpty(Observaciones) = True Then
                            Observaciones = String.Empty
                        End If

                        ObjprospectaBU.GuardarIncidenciasProspecta(ProspectaID, ClienteSayID, ConfirmacionEntrega, UsuarioConfirmo, FechaConfirmacion, MotivoID, Observaciones)

                        filacliente.Cells("FConfirmacion").Appearance.ForeColor = Color.Black
                        filacliente.Cells("*Observaciones").Appearance.ForeColor = Color.Black
                        filacliente.Cells("Confirma").Appearance.ForeColor = Color.Black
                        filacliente.Cells("*Incidencia").Appearance.ForeColor = Color.Black

                     


                    End If

                    If (Celda.Appearance.ForeColor = Color.Black Or Celda.Appearance.ForeColor = Color.Empty) And _PA = "NO" Then
                        SeProspectaPorCliente = False
                    Else
                        If _PA = "SI" Then
                            SeProspectaPorCliente = False
                        End If
                    End If


                    If SeProspectaPorCliente = True Then
                        RowsPartidas = DataSetPartidas.Select("ClienteSayID = " + ClienteSayID.ToString() + "")

                        For Each RowsPart As DataRow In RowsPartidas

                            PedidoID = RowsPart.Item("PSICY").ToString
                            Partida = RowsPart.Item("#Part").ToString



                            ParesPartida = RowsPart.Item("Prs Part").ToString()
                            MarcaID = CInt(RowsPart.Item("MarcaId").ToString)
                            TotalPEND = CInt(RowsPart.Item("total_pend").ToString)
                            TotalIALM = CInt(RowsPart.Item("total_ialm").ToString)
                            TotalIPRO = CInt(RowsPart.Item("total_ipro").ToString)
                            TotalAXC = CInt(RowsPart.Item("total_axc").ToString)
                            ProspectaPEND = CInt(RowsPart.Item("prosp_pend").ToString)
                            ProspectaIALM = CInt(RowsPart.Item("prosp_ialm").ToString)
                            ProspectaIPRO = CInt(RowsPart.Item("prosp_ipro").ToString)
                            ProspectaAXC = CInt(RowsPart.Item("prosp_axc").ToString)
                            FechaProgramacion = RowsPart.Item("FProg").ToString
                            PEND = RowsPart.Item("actual_prog_PEND").ToString
                            IALM = RowsPart.Item("actual_prog_IALM").ToString
                            IPRO = RowsPart.Item("actual_prog_IPRO").ToString
                            AXC = RowsPart.Item("actual_prog_AXC").ToString
                            FechaCreacion = CDate(RowsPart.Item("FCaptura").ToString)
                            ClienteSayID = RowsPart.Item("ClientesayId").ToString
                            ClienteSicy = RowsPart.Item("ClientesicyId").ToString



                            If IsDBNull(RowsPart.Item("ProductoEstiloID").ToString) = False And RowsPart.Item("ProductoEstiloID").ToString <> "" Then
                                ProductoEstilo = CInt(RowsPart.Item("ProductoEstiloID").ToString)
                            Else
                                ProductoEstilo = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("FamiliaProyeccionID").ToString) = False And RowsPart.Item("FamiliaProyeccionID").ToString <> "" Then
                                FamiliaProyeccion = CInt(RowsPart.Item("FamiliaProyeccionID").ToString)
                            Else
                                FamiliaProyeccion = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("TiendaIDSicy").ToString) = False And RowsPart.Item("TiendaIDSicy").ToString <> "" Then
                                IdTienda = CInt(RowsPart.Item("TiendaIDSicy").ToString)
                            Else
                                IdTienda = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("IdCodigo").ToString) = False And RowsPart.Item("IdCodigo").ToString <> "" Then
                                IdCodigoSicy = RowsPart.Item("IdCodigo").ToString
                            Else
                                IdCodigoSicy = Nothing
                            End If

                            If IsDBNull(RowsPart.Item("IdTalla").ToString) = False And RowsPart.Item("IdTalla").ToString <> "" Then
                                IdTalla = RowsPart.Item("IdTalla").ToString
                            Else
                                IdTalla = Nothing
                            End If

                            ' ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, 0, Date.Now, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)



                        Next


                    End If
                   

                Next

                'ListaIndicesClientesModificadas.Clear()
                'ListaIndicesPartidasModificadas.Clear()
                'ListaIndicesPedidosModificadas.Clear()

                For Each indice As Integer In ListaIndicesClientesModificadas
                    FilaCl = gridListaProspecta.Rows(indice)
                    Celda = FilaCl.Cells("PrsProsp")
                    ClienteSayID = FilaCl.Cells("ClienteSayID").Value
                    ClienteSicyID = FilaCl.Cells("ClienteSicyID").Value
                    _PA = FilaCl.Cells("PA").Value

                    If FilaCl.Cells("ColumnaModificada").Value = True Or FilaCl.Cells("Conf").Activation = Activation.AllowEdit Then
                        ClienteSayID = FilaCl.Cells("ClienteSayID").Value
                        ConfirmacionEntrega = FilaCl.Cells("Conf").Value
                        If ConfirmacionEntrega = True Then
                            UsuarioConfirmo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        Else
                            UsuarioConfirmo = -1
                        End If


                        If IsNothing(FilaCl.Cells("FConfirmacion").Value) = False And IsDBNull(FilaCl.Cells("FConfirmacion").Value) = False Then
                            FechaConfirmacion = CDate(FilaCl.Cells("FConfirmacion").Value)
                        Else
                            FechaConfirmacion = Nothing
                        End If


                        If IsNothing(FilaCl.Cells("*Incidencia").Value) = False Then
                            MotivoID = FilaCl.Cells("*Incidencia").Column.ValueList.GetValue(FilaCl.Cells("*Incidencia").Value.ToString, 0)
                        Else
                            MotivoID = -1
                        End If

                        Observaciones = CStr(FilaCl.Cells("*Observaciones").Value)
                        If String.IsNullOrEmpty(Observaciones) = True Then
                            Observaciones = String.Empty
                        End If

                        ObjprospectaBU.GuardarIncidenciasProspecta(ProspectaID, ClienteSayID, ConfirmacionEntrega, UsuarioConfirmo, FechaConfirmacion, MotivoID, Observaciones)

                        FilaCl.Cells("FConfirmacion").Appearance.ForeColor = Color.Black
                        FilaCl.Cells("*Observaciones").Appearance.ForeColor = Color.Black
                        FilaCl.Cells("Confirma").Appearance.ForeColor = Color.Black
                        FilaCl.Cells("*Incidencia").Appearance.ForeColor = Color.Black


                    End If

                    If FilaCl.Cells("PA").Value = "SI" Then
                        If Celda.Appearance.ForeColor = Color.Purple Then
                            TotalParesProspecta = Celda.Value
                            FilaCl.Cells("Confirma").Appearance.ForeColor = Color.Black
                            FilaCl.Cells("FConfirmacion").Appearance.ForeColor = Color.Black

                            ListaIndiceClientesElimnar.Add(FilaCl.Index)

                            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                FilaCl.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                            Next

                            FilaCl.Cells("PrsProsp").Appearance.ForeColor = Color.Black

                            ListaClientesModificados.Add(FilaCl.Cells("ClienteSayID").Value)

                        End If
                    End If


                    If FilaCl.Cells("PA").Value = "NO" Then
                        Celda = FilaCl.Cells("PrsProsp")
                        If (Celda.Appearance.ForeColor <> Color.Purple) Then
                            Continue For
                        End If

                        ClienteSayID = FilaCl.Cells("ClienteSayID").Value
                        ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaID, -1, -1, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                        'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            If IsDBNull(FilaCl.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                CantidadPares = CInt(FilaCl.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                If CantidadPares <> 0 Then
                                    ObjprospectaBU.EditarPlaneacionProspecta(ProspectaID, ClienteSayID, -1, -1, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1, Nothing, -1, -1, -1, -1, "-1", "-1", -1, -1, -1, -1, Nothing, -1, -1, -1, -1, -1, -1, -1, -1, -1)
                                    FilaCl.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    Celda.Appearance.ForeColor = Color.Black
                                End If
                            End If
                        Next
                    Else
                        Celda = FilaCl.Cells("PrsProsp")
                        If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                            If Celda.Value = 0 And Celda.Appearance.ForeColor <> Color.Black Then
                                ObjprospectaBU.EliminarParesProspectadosCliente(ProspectaID, ClienteSayID)
                            End If
                        End If
                    End If

                Next

            End If

            If tabProspecta.SelectedIndex = 0 Then
                If ListaClientesModificados.Count > 0 Then
                    For Each indice As Integer In ListaIndicesPedidosModificadas
                        FilaPed = gridPedidos.Rows(indice)

                        If ListaClientesModificados.Exists(Function(x) x = FilaPed.Cells("ClientesayId").Value) = True Then
                            Celda = FilaPed.Cells("PrsProsp")
                            If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                                ListaPedidosModificados.Add(FilaPed.Cells("PSICY").Value)
                                If Celda.Appearance.ForeColor = Color.Purple Then

                                    ListaIndicePedidosEliminar.Add(indice)
                                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                        FilaPed.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    Next
                                    Celda.Appearance.ForeColor = Color.Black


                                End If
                            End If

                            If FilaPed.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
                                If FilaPed.Cells("PrsProsp").Value <> 0 Then
                                    FilaPed.Cells("PR").Value = "SI"
                                    FilaPed.Cells("PR").Appearance.BackColor = Color.Green
                                Else
                                    FilaPed.Cells("PR").Value = "NO"
                                    FilaPed.Cells("PR").Appearance.BackColor = Color.Red
                                End If
                            End If

                        End If
                    Next

                End If



                If ListaPedidosModificados.Count > 0 Then

                    For Each indice As Integer In ListaIndicesPartidasModificadas
                        FilaPed = gridPartidas.Rows(indice)
                        If ListaPedidosModificados.Exists(Function(x) x = FilaPed.Cells("PSICY").Value) = True Then
                            Celda = FilaPed.Cells("PrsProsp")

                            ParesPartida = CInt(FilaPed.Cells("Prs Part").Value)
                            MarcaID = CInt(FilaPed.Cells("MarcaId").Value)
                            TotalPEND = CInt(FilaPed.Cells("total_pend").Value)
                            TotalIALM = CInt(FilaPed.Cells("total_ialm").Value)
                            TotalIPRO = CInt(FilaPed.Cells("total_ipro").Value)
                            TotalAXC = CInt(FilaPed.Cells("total_axc").Value)
                            ProspectaPEND = CInt(FilaPed.Cells("prosp_pend").Value)
                            ProspectaIALM = CInt(FilaPed.Cells("prosp_ialm").Value)
                            ProspectaIPRO = CInt(FilaPed.Cells("prosp_ipro").Value)
                            ProspectaAXC = CInt(FilaPed.Cells("prosp_axc").Value)
                            FechaProgramacion = FilaPed.Cells("FProg").Value
                            PEND = FilaPed.Cells("actual_prog_PEND").Value
                            IALM = FilaPed.Cells("actual_prog_IALM").Value
                            IPRO = FilaPed.Cells("actual_prog_IPRO").Value
                            AXC = FilaPed.Cells("actual_prog_AXC").Value
                            FechaCreacion = CDate(FilaPed.Cells("FCaptura").Value)
                            ClienteSayID = FilaPed.Cells("ClientesayId").Value
                            ClienteSicy = FilaPed.Cells("ClientesicyId").Value
                            PedidoID = FilaPed.Cells("PSICY").Value
                            Partida = FilaPed.Cells("#Part").Value

                            If IsDBNull(FilaPed.Cells("ProductoEstiloID").Value) = False Then
                                ProductoEstilo = CInt(FilaPed.Cells("ProductoEstiloID").Value)
                            Else
                                ProductoEstilo = Nothing
                            End If

                            If IsDBNull(FilaPed.Cells("FamiliaProyeccionID").Value) = False Then
                                FamiliaProyeccion = CInt(FilaPed.Cells("FamiliaProyeccionID").Value)
                            Else
                                FamiliaProyeccion = Nothing
                            End If

                            If IsDBNull(FilaPed.Cells("TiendaIDSicy").Value) = False Then
                                IdTienda = CInt(FilaPed.Cells("TiendaIDSicy").Value)
                            Else
                                IdTienda = Nothing
                            End If

                            If IsDBNull(FilaPed.Cells("IdCodigo").Value) = False Then
                                IdCodigoSicy = FilaPed.Cells("IdCodigo").Value
                            Else
                                IdCodigoSicy = Nothing
                            End If

                            If IsDBNull(FilaPed.Cells("IdTalla").Value) = False Then
                                IdTalla = FilaPed.Cells("IdTalla").Value
                            Else
                                IdTalla = Nothing
                            End If


                            ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                                If Celda.Appearance.ForeColor = Color.Purple Then
                                    ListaIndicePartidasEliminar.Add(indice)

                                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                        If IsDBNull(FilaPed.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                            CantidadParesPartida = CInt(FilaPed.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                            If CantidadParesPartida <> 0 Then
                                                ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, CantidadParesPartida, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                                                FilaPed.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                                Celda.Appearance.ForeColor = Color.Black
                                            Else
                                                FilaPed.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                            End If
                                        End If
                                    Next
                                End If
                            End If

                            If FilaPed.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
                                If FilaPed.Cells("PrsProsp").Value <> 0 Then
                                    FilaPed.Cells("PR").Value = "SI"
                                    FilaPed.Cells("PR").Appearance.BackColor = Color.Green
                                Else
                                    FilaPed.Cells("PR").Value = "NO"
                                    FilaPed.Cells("PR").Appearance.BackColor = Color.Red
                                End If
                            End If

                        End If
                    Next

                End If

            End If


           

            For Each INDICE As Integer In ListaIndiceClientesElimnar
                If ListaIndicesClientesModificadas.Exists(Function(X) X = INDICE) Then
                    ListaIndicesClientesModificadas.RemoveAt(ListaIndicesClientesModificadas.FindIndex(Function(y) y = INDICE))
                End If
            Next

            For Each INDICE As Integer In ListaIndicePedidosEliminar
                If ListaIndicesPedidosModificadas.Exists(Function(X) X = INDICE) Then
                    ListaIndicesPedidosModificadas.RemoveAt(ListaIndicesPedidosModificadas.FindIndex(Function(y) y = INDICE))
                End If
            Next

            For Each INDICE As Integer In ListaIndicePartidasEliminar
                If ListaIndicesPartidasModificadas.Exists(Function(X) X = INDICE) Then
                    ListaIndicesPartidasModificadas.RemoveAt(ListaIndicesPartidasModificadas.FindIndex(Function(y) y = INDICE))
                End If
            Next




        
        Catch ex As Exception
            Dim error1 As String
            error1 = "valor de error"
        End Try

       


    End Sub

    Public Sub GuardarPedido(ByVal ProspectaIDLocal As Integer)
        Dim ListaPedidosModificados As New List(Of Integer)
        Dim ListaClientesModificados As New List(Of Integer)

        Dim ListaPedidosCompletos As New List(Of Integer)
        Dim ListaClientesCompletos As New List(Of Integer)

        Dim ListaIndicePedidosEliminar As New List(Of Integer)
        Dim ListaIndicePartidasEliminar As New List(Of Integer)
        Dim ListaIndiceClientesElimnar As New List(Of Integer)


        Dim Celda As UltraGridCell
        Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU
        Dim TotalParesPedido As Integer = 0
        Dim TotalParesCliente As Integer = 0


        Dim numeropares As Int32 = gridPartidas.Rows.Count
        Dim PEND As Int32
        Dim IALM As Int32
        Dim IPRO As Int32
        Dim AXC As Int32
        Dim IdCodigoSicy As String = String.Empty
        Dim IdTalla As String = String.Empty
        Dim FechaProgramacion As Date
        Dim ClienteSicy As Int32
        Dim val As String = String.Empty
        Dim ProductoEstilo As Integer
        Dim FamiliaProyeccion As Integer
        Dim IdTienda As Integer
        Dim FechaCreacion As Date
        Dim ParesPartida As Integer
        Dim MarcaID As Integer
        Dim TotalPEND As Integer
        Dim TotalIALM As Integer
        Dim TotalIPRO As Integer
        Dim TotalAXC As Integer
        Dim ProspectaPEND As Integer
        Dim ProspectaIALM As Integer
        Dim ProspectaIPRO As Integer
        Dim ProspectaAXC As Integer        
        Dim ClienteSayID As Integer
        Dim PedidoID As Integer
        Dim Partida As Integer
        Dim CantidadParesPartida As Integer


        For Each FilaPedido As UltraGridRow In gridPedidos.Rows
            Celda = FilaPedido.Cells("PrsProsp")

            If FilaPedido.Hidden = False And Celda.Appearance.ForeColor <> Color.Black Then
                Celda = FilaPedido.Cells("PrsProsp")
                If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                    ListaPedidosModificados.Add(FilaPedido.Cells("PSICY").Value)
                    ListaClientesModificados.Add(FilaPedido.Cells("ClientesayId").Value)
                    If Celda.Appearance.ForeColor = Color.Purple Then
                        ListaPedidosCompletos.Add(FilaPedido.Cells("PSICY").Value)
                        ListaClientesCompletos.Add(FilaPedido.Cells("ClientesayId").Value)
                        ListaIndicePedidosEliminar.Add(FilaPedido.Index)
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            FilaPedido.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        Next
                        Celda.Appearance.ForeColor = Color.Black
                    ElseIf Celda.Appearance.ForeColor = Color.OrangeRed Then

                        If Celda.Value = 0 Then
                            ListaPedidosCompletos.Add(FilaPedido.Cells("PSICY").Value)
                            ListaClientesCompletos.Add(FilaPedido.Cells("ClientesayId").Value)
                            ListaIndicePedidosEliminar.Add(FilaPedido.Index)
                        End If
                        'ListaPedidosCompletos.Add(FilaPedido.Cells("PSICY").Value)
                        'ListaClientesCompletos.Add(FilaPedido.Cells("ClientesayId").Value)
                        'ListaIndicePedidosEliminar.Add(FilaPedido.Index)

                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            FilaPedido.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                        Next
                        Celda.Value = 0
                    End If
                End If
            End If

            If FilaPedido.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaPedido.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then
                If IsDBNull(FilaPedido.Cells("PrsProsp").Value) = False Then
                    If FilaPedido.Cells("PrsProsp").Value <> 0 Then
                        FilaPedido.Cells("PR").Value = "SI"
                        FilaPedido.Cells("PR").Appearance.BackColor = Color.Green
                    Else
                        FilaPedido.Cells("PR").Value = "NO"
                        FilaPedido.Cells("PR").Appearance.BackColor = Color.Red
                    End If
                Else
                    FilaPedido.Cells("PR").Value = "NO"
                    FilaPedido.Cells("PR").Appearance.BackColor = Color.Red
                End If

               
            Else
                FilaPedido.Cells("PR").Value = "NO"
                FilaPedido.Cells("PR").Appearance.BackColor = Color.Red
            End If
        Next

        For Each FilaPartida As UltraGridRow In gridPartidas.Rows

            If ListaPedidosCompletos.Exists(Function(x) x = FilaPartida.Cells("PSICY").Value) = True Then
                Celda = FilaPartida.Cells("PrsProsp")
                ListaIndicePartidasEliminar.Add(FilaPartida.Index)

                ParesPartida = CInt(FilaPartida.Cells("Prs Part").Value)
                MarcaID = CInt(FilaPartida.Cells("MarcaId").Value)
                TotalPEND = CInt(FilaPartida.Cells("total_pend").Value)
                TotalIALM = CInt(FilaPartida.Cells("total_ialm").Value)
                TotalIPRO = CInt(FilaPartida.Cells("total_ipro").Value)
                TotalAXC = CInt(FilaPartida.Cells("total_axc").Value)
                ProspectaPEND = CInt(FilaPartida.Cells("prosp_pend").Value)
                ProspectaIALM = CInt(FilaPartida.Cells("prosp_ialm").Value)
                ProspectaIPRO = CInt(FilaPartida.Cells("prosp_ipro").Value)
                ProspectaAXC = CInt(FilaPartida.Cells("prosp_axc").Value)
                FechaProgramacion = FilaPartida.Cells("FProg").Value
                PEND = FilaPartida.Cells("actual_prog_PEND").Value
                IALM = FilaPartida.Cells("actual_prog_IALM").Value
                IPRO = FilaPartida.Cells("actual_prog_IPRO").Value
                AXC = FilaPartida.Cells("actual_prog_AXC").Value
                FechaCreacion = CDate(FilaPartida.Cells("FCaptura").Value)
                ClienteSayID = FilaPartida.Cells("ClientesayId").Value
                ClienteSicy = FilaPartida.Cells("ClientesicyId").Value
                PedidoID = FilaPartida.Cells("PSICY").Value
                Partida = FilaPartida.Cells("#Part").Value

                If IsDBNull(FilaPartida.Cells("ProductoEstiloID").Value) = False Then
                    ProductoEstilo = CInt(FilaPartida.Cells("ProductoEstiloID").Value)
                Else
                    ProductoEstilo = Nothing
                End If

                If IsDBNull(FilaPartida.Cells("FamiliaProyeccionID").Value) = False Then
                    FamiliaProyeccion = CInt(FilaPartida.Cells("FamiliaProyeccionID").Value)
                Else
                    FamiliaProyeccion = Nothing
                End If

                If IsDBNull(FilaPartida.Cells("TiendaIDSicy").Value) = False Then
                    IdTienda = CInt(FilaPartida.Cells("TiendaIDSicy").Value)
                Else
                    IdTienda = Nothing
                End If

                If IsDBNull(FilaPartida.Cells("IdCodigo").Value) = False Then
                    IdCodigoSicy = FilaPartida.Cells("IdCodigo").Value
                Else
                    IdCodigoSicy = Nothing
                End If

                If IsDBNull(FilaPartida.Cells("IdTalla").Value) = False Then
                    IdTalla = FilaPartida.Cells("IdTalla").Value
                Else
                    IdTalla = Nothing
                End If


                ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                    If Celda.Appearance.ForeColor = Color.Purple Then
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            If IsDBNull(FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                CantidadParesPartida = CInt(FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                If CantidadParesPartida <> 0 Then
                                    ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, CantidadParesPartida, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                                    FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    Celda.Appearance.ForeColor = Color.Black
                                End If
                            End If
                            FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        Next
                        Celda.Appearance.ForeColor = Color.Black
                    ElseIf Celda.Appearance.ForeColor = Color.OrangeRed Then
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                        Next
                        Celda.Value = 0

                    End If
                End If

                If FilaPartida.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaPartida.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then

                    If IsDBNull(FilaPartida.Cells("PrsProsp").Value) = False Then
                        If FilaPartida.Cells("PrsProsp").Value <> 0 Then
                            FilaPartida.Cells("PR").Value = "SI"
                            FilaPartida.Cells("PR").Appearance.BackColor = Color.Green
                        Else
                            FilaPartida.Cells("PR").Value = "NO"
                            FilaPartida.Cells("PR").Appearance.BackColor = Color.Red
                        End If
                    Else
                        FilaPartida.Cells("PR").Value = "NO"
                        FilaPartida.Cells("PR").Appearance.BackColor = Color.Red
                    End If

                 
                Else
                    FilaPartida.Cells("PR").Value = "NO"
                    FilaPartida.Cells("PR").Appearance.BackColor = Color.Red
                End If

            ElseIf ListaPedidosModificados.Exists(Function(x) x = FilaPartida.Cells("PSICY").Value) = True Then
                Celda = FilaPartida.Cells("PrsProsp")

                If Celda.Appearance.ForeColor <> Color.Black And Celda.Appearance.ForeColor <> Color.Empty Then
                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                        FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                        FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.OrangeRed
                    Next
                    Celda.Value = 0
                    Celda.Appearance.ForeColor = Color.OrangeRed
                End If
                

                'ListaPedidosCompletos
                'If ListaPedidosModificados.Exists(Function(x) x = FilaPartida.Cells("PSICY").Value) = True Then
            End If


        Next


        For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
            Celda = FilaCliente.Cells("PrsProsp")
            If ListaClientesModificados.Exists(Function(x) x = FilaCliente.Cells("ClienteSayID").Value) = True Then
                If ListaClientesCompletos.Exists(Function(y) y = FilaCliente.Cells("ClienteSayID").Value) = True Then

                    ListaIndiceClientesElimnar.Add(FilaCliente.Index)

                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                            CantidadParesPartida = CInt(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                            If CantidadParesPartida <> 0 Then
                                FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                Celda.Appearance.ForeColor = Color.Black
                            End If

                        End If
                        FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black

                    Next
                    Celda.Appearance.ForeColor = Color.Black

                    If FilaCliente.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaCliente.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then
                        If IsDBNull(FilaCliente.Cells("PrsProsp").Value) = False Then
                            If FilaCliente.Cells("PrsProsp").Value <> 0 Then
                                FilaCliente.Cells("PR").Value = "SI"
                                FilaCliente.Cells("PR").Appearance.BackColor = Color.Green
                            Else
                                FilaCliente.Cells("PR").Value = "NO"
                                FilaCliente.Cells("PR").Appearance.BackColor = Color.Red
                            End If
                        Else
                            FilaCliente.Cells("PR").Value = "NO"
                            FilaCliente.Cells("PR").Appearance.BackColor = Color.Red
                        End If


                    Else
                        FilaCliente.Cells("PR").Value = "NO"
                        FilaCliente.Cells("PR").Appearance.BackColor = Color.Red
                    End If

                Else
                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                        FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                    Next
                End If

            End If
        Next

        ActualizarCantidadParesPedidoPartidaGuardados(ListaPedidosModificados)
        ActualizarCantidadParesProspectaPedidoGuardados(ListaClientesModificados)


        For Each INDICE As Integer In ListaIndiceClientesElimnar
            If ListaIndicesClientesModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesClientesModificadas.RemoveAt(ListaIndicesClientesModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next

        For Each INDICE As Integer In ListaIndiceClientesElimnar
            If ListaIndicesClientesModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesClientesModificadas.RemoveAt(ListaIndicesClientesModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next

        For Each INDICE As Integer In ListaIndicePedidosEliminar
            If ListaIndicesPedidosModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesPedidosModificadas.RemoveAt(ListaIndicesPedidosModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next

        For Each INDICE As Integer In ListaIndicePartidasEliminar
            If ListaIndicesPartidasModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesPartidasModificadas.RemoveAt(ListaIndicesPartidasModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next


    End Sub


    Public Sub GuardarPartida(ByVal ProspectaIDLocal As Integer)
        Dim ListaPedidosModificados As New List(Of Integer)
        Dim ListaClientesModificados As New List(Of Integer)
        Dim ListaPedidosCompletos As New List(Of Integer)
        Dim ListaPartidasCompletos As New List(Of Integer)
        Dim ListaClientesCompletosCompletos As New List(Of Integer)
        Dim FilaActiva As UltraGridRow

        Dim ListaIndicePedidosEliminar As New List(Of Integer)
        Dim ListaIndicePartidasEliminar As New List(Of Integer)
        Dim ListaIndiceClientesElimnar As New List(Of Integer)

        Dim Celda As UltraGridCell
        Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU

        Dim numeropares As Int32 = gridPartidas.Rows.Count
        Dim PEND As Int32
        Dim IALM As Int32
        Dim IPRO As Int32
        Dim AXC As Int32
        Dim IdCodigoSicy As String = String.Empty
        Dim IdTalla As String = String.Empty
        Dim FechaProgramacion As Date
        Dim ClienteSicy As Int32
        Dim val As String = String.Empty
        Dim ProductoEstilo As Integer
        Dim FamiliaProyeccion As Integer
        Dim IdTienda As Integer
        Dim FechaCreacion As Date
        Dim ParesPartida As Integer
        Dim MarcaID As Integer
        Dim TotalPEND As Integer
        Dim TotalIALM As Integer
        Dim TotalIPRO As Integer
        Dim TotalAXC As Integer
        Dim ProspectaPEND As Integer
        Dim ProspectaIALM As Integer
        Dim ProspectaIPRO As Integer
        Dim ProspectaAXC As Integer
        Dim ClienteSayID As Integer
        Dim PedidoID As Integer
        Dim Partida As Integer
        Dim CantidadParesPartida As Integer

        Dim listaClientesPedidosSinGuardar As New List(Of Integer)


        For Each indice As Integer In ListaIndicesPartidasModificadas
            Celda = gridPartidas.Rows(indice).Cells("PrsProsp")
            FilaActiva = gridPartidas.Rows(indice)
            If gridPartidas.Rows(indice).Hidden = False And (Celda.Appearance.ForeColor <> Color.Black And Celda.Appearance.ForeColor <> Color.Empty) Then

                If ListaPedidosModificados.Exists(Function(x) x = FilaActiva.Cells("PSICY").Value) = False Then
                    ListaPedidosModificados.Add(FilaActiva.Cells("PSICY").Value)
                End If

                If ListaPedidosModificados.Exists(Function(x) x = FilaActiva.Cells("ClienteSayID").Value) = False Then
                    ListaClientesModificados.Add(FilaActiva.Cells("ClienteSayID").Value)
                End If


                Celda = FilaActiva.Cells("PrsProsp")

                ParesPartida = CInt(FilaActiva.Cells("Prs Part").Value)
                MarcaID = CInt(FilaActiva.Cells("MarcaId").Value)
                TotalPEND = CInt(FilaActiva.Cells("total_pend").Value)
                TotalIALM = CInt(FilaActiva.Cells("total_ialm").Value)
                TotalIPRO = CInt(FilaActiva.Cells("total_ipro").Value)
                TotalAXC = CInt(FilaActiva.Cells("total_axc").Value)
                ProspectaPEND = CInt(FilaActiva.Cells("prosp_pend").Value)
                ProspectaIALM = CInt(FilaActiva.Cells("prosp_ialm").Value)
                ProspectaIPRO = CInt(FilaActiva.Cells("prosp_ipro").Value)
                ProspectaAXC = CInt(FilaActiva.Cells("prosp_axc").Value)
                FechaProgramacion = FilaActiva.Cells("FProg").Value
                PEND = FilaActiva.Cells("actual_prog_PEND").Value
                IALM = FilaActiva.Cells("actual_prog_IALM").Value
                IPRO = FilaActiva.Cells("actual_prog_IPRO").Value
                AXC = FilaActiva.Cells("actual_prog_AXC").Value
                FechaCreacion = CDate(FilaActiva.Cells("FCaptura").Value)
                ClienteSayID = FilaActiva.Cells("ClientesayId").Value
                ClienteSicy = FilaActiva.Cells("ClientesicyId").Value
                PedidoID = FilaActiva.Cells("PSICY").Value
                Partida = FilaActiva.Cells("#Part").Value

                If IsDBNull(FilaActiva.Cells("ProductoEstiloID").Value) = False Then
                    ProductoEstilo = CInt(FilaActiva.Cells("ProductoEstiloID").Value)
                Else
                    ProductoEstilo = Nothing
                End If

                If IsDBNull(FilaActiva.Cells("FamiliaProyeccionID").Value) = False Then
                    FamiliaProyeccion = CInt(FilaActiva.Cells("FamiliaProyeccionID").Value)
                Else
                    FamiliaProyeccion = Nothing
                End If

                If IsDBNull(FilaActiva.Cells("TiendaIDSicy").Value) = False Then
                    IdTienda = CInt(FilaActiva.Cells("TiendaIDSicy").Value)
                Else
                    IdTienda = Nothing
                End If

                If IsDBNull(FilaActiva.Cells("IdCodigo").Value) = False Then
                    IdCodigoSicy = FilaActiva.Cells("IdCodigo").Value
                Else
                    IdCodigoSicy = Nothing
                End If

                If IsDBNull(FilaActiva.Cells("IdTalla").Value) = False Then
                    IdTalla = FilaActiva.Cells("IdTalla").Value
                Else
                    IdTalla = Nothing
                End If


                ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
                    If Celda.Appearance.ForeColor = Color.Purple Then
                        ListaPedidosCompletos.Add(PedidoID)
                        ListaClientesCompletosCompletos.Add(ClienteSayID)
                        ListaPartidasCompletos.Add(PedidoID)

                        ListaIndicePartidasEliminar.Add(indice)

                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            If IsDBNull(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                CantidadParesPartida = CInt(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                If CantidadParesPartida <> 0 Then
                                    ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, CantidadParesPartida, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                                    FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    Celda.Appearance.ForeColor = Color.Black
                                End If
                            End If
                            FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        Next

                        If FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then

                            If IsDBNull(FilaActiva.Cells("PrsProsp").Value) = False Then
                                If FilaActiva.Cells("PrsProsp").Value <> 0 Then
                                    FilaActiva.Cells("PR").Value = "SI"
                                    FilaActiva.Cells("PR").Appearance.BackColor = Color.Green
                                Else
                                    FilaActiva.Cells("PR").Value = "NO"
                                    FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                                End If
                            Else
                                FilaActiva.Cells("PR").Value = "NO"
                                FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                            End If

                        Else
                            FilaActiva.Cells("PR").Value = "NO"
                            FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                        End If

                    ElseIf Celda.Appearance.ForeColor = Color.OrangeRed Then
                        If Celda.Value = 0 Then
                            ListaPedidosCompletos.Add(PedidoID)
                            ListaClientesCompletosCompletos.Add(ClienteSayID)
                            ListaIndicePartidasEliminar.Add(indice)
                        End If

                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                        Next
                        Celda.Value = 0
                        Celda.Appearance.ForeColor = Color.OrangeRed
                    End If
                End If
            Else
                listaClientesPedidosSinGuardar.Add(FilaActiva.Cells("ClienteSayID").Value)
            End If
        Next


        For Each indice As Integer In ListaIndicesPedidosModificadas
            Celda = gridPedidos.Rows(indice).Cells("PrsProsp")
            FilaActiva = gridPedidos.Rows(indice)

            If ListaPedidosCompletos.Exists(Function(x) x = FilaActiva.Cells("PSICY").Value) = True Then
                If gridPedidos.Rows(indice).Hidden = False And Celda.Appearance.ForeColor <> Color.Black Then
                    If ListaPedidosModificados.Exists(Function(x) x = FilaActiva.Cells("PSICY").Value) = True Then
                        If ListaPedidosCompletos.Exists(Function(y) y = FilaActiva.Cells("PSICY").Value) = True Then
                            ListaIndicePedidosEliminar.Add(indice)
                            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                If IsDBNull(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                    CantidadParesPartida = CInt(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                    If CantidadParesPartida <> 0 Then
                                        FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                        Celda.Appearance.ForeColor = Color.Black
                                    End If
                                End If
                                FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                Celda.Appearance.ForeColor = Color.Black

                                'If CantidadParesPartida <> 0 Then
                                '    FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                '    Celda.Appearance.ForeColor = Color.Black
                                'End If                           
                            Next
                            'Celda.Appearance.ForeColor = Color.Black

                            If FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then
                                If IsDBNull(FilaActiva.Cells("PrsProsp").Value) = False Then
                                    If FilaActiva.Cells("PrsProsp").Value <> 0 Then
                                        FilaActiva.Cells("PR").Value = "SI"
                                        FilaActiva.Cells("PR").Appearance.BackColor = Color.Green
                                    Else
                                        FilaActiva.Cells("PR").Value = "NO"
                                        FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                                    End If
                                Else
                                    FilaActiva.Cells("PR").Value = "NO"
                                    FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                                End If



                            Else
                                FilaActiva.Cells("PR").Value = "NO"
                                FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                            End If
                        Else
                            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                            Next
                        End If
                    Else
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                        Next
                    End If
                End If
            End If
        Next

        Dim PedidosPendientesGuardar As Boolean = False


        For Each indice As Integer In ListaIndicesClientesModificadas
            Celda = gridListaProspecta.Rows(indice).Cells("PrsProsp")
            FilaActiva = gridListaProspecta.Rows(indice)
            PedidosPendientesGuardar = listaClientesPedidosSinGuardar.Exists(Function(x) x =  FilaActiva.Cells("ClienteSayID").Value)

            If ListaClientesModificados.Exists(Function(x) x = FilaActiva.Cells("ClienteSayID").Value) = True Then

                If ListaClientesCompletosCompletos.Exists(Function(y) y = FilaActiva.Cells("ClienteSayID").Value) = True Then

                    ListaIndiceClientesElimnar.Add(indice)

                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                            CantidadParesPartida = CInt(FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                            If CantidadParesPartida <> 0 Then
                                ' FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                If PedidosPendientesGuardar = False Then
                                    Celda.Appearance.ForeColor = Color.Black
                                End If

                            End If
                        End If

                        If PedidosPendientesGuardar = False Then
                            FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        End If


                    Next
                    If PedidosPendientesGuardar = False Then
                        Celda.Appearance.ForeColor = Color.Black
                    End If


                    If FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Black Or FilaActiva.Cells("PrsProsp").Appearance.ForeColor = Color.Empty Then

                        If IsDBNull(FilaActiva.Cells("PrsProsp").Value) = False Then
                            If FilaActiva.Cells("PrsProsp").Value <> 0 Then
                                FilaActiva.Cells("PR").Value = "SI"
                                FilaActiva.Cells("PR").Appearance.BackColor = Color.Green
                            Else
                                FilaActiva.Cells("PR").Value = "NO"
                                FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                            End If
                        Else
                            FilaActiva.Cells("PR").Value = "NO"
                            FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                        End If

                    Else
                        FilaActiva.Cells("PR").Value = "NO"
                        FilaActiva.Cells("PR").Appearance.BackColor = Color.Red
                    End If
                Else
                    For Each DIA As Entidades.ProspectaDias In DiasProspecta
                        FilaActiva.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
                    Next
                End If

            End If

        Next

      
        ActualizarCantidadParesPedidoPartidaGuardados(ListaPedidosModificados)
        ActualizarCantidadParesProspectaPedidoGuardados(ListaClientesModificados)


        'ListaPedidosCompletos
        'ListaClientesCompletosCompletos

       

        For Each INDICE As Integer In ListaIndiceClientesElimnar
            If ListaIndicesClientesModificadas.Exists(Function(X) X = INDICE) Then
                FilaActiva = gridListaProspecta.Rows(INDICE)
                If listaClientesPedidosSinGuardar.Exists(Function(x) x = FilaActiva.Cells("ClienteSayID").Value) = False Then
                    ListaIndicesClientesModificadas.RemoveAt(ListaIndicesClientesModificadas.FindIndex(Function(y) y = INDICE))
                End If


            End If
        Next

        For Each INDICE As Integer In ListaIndicePedidosEliminar
            If ListaIndicesPedidosModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesPedidosModificadas.RemoveAt(ListaIndicesPedidosModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next

        For Each INDICE As Integer In ListaIndicePartidasEliminar
            If ListaIndicesPartidasModificadas.Exists(Function(X) X = INDICE) Then
                ListaIndicesPartidasModificadas.RemoveAt(ListaIndicesPartidasModificadas.FindIndex(Function(y) y = INDICE))
            End If
        Next

        'ListaIndicesClientesModificadas.Clear()
        'ListaIndicesPartidasModificadas.Clear()
        'ListaIndicesPedidosModificadas.Clear()

        '------------------Anterior

        'For Each FilaPartida As UltraGridRow In gridPartidas.Rows
        '    Celda = FilaPartida.Cells("PrsProsp")

        '    If FilaPartida.Hidden = False And Celda.Appearance.ForeColor <> Color.Black Then

        '        ListaPedidosModificados.Add(FilaPartida.Cells("PSICY").Value)
        '        ListaClientesModificados.Add(FilaPartida.Cells("ClienteSayID").Value)

        '        Celda = FilaPartida.Cells("PrsProsp")

        '        ParesPartida = CInt(FilaPartida.Cells("Prs Part").Value)
        '        MarcaID = CInt(FilaPartida.Cells("MarcaId").Value)
        '        TotalPEND = CInt(FilaPartida.Cells("total_pend").Value)
        '        TotalIALM = CInt(FilaPartida.Cells("total_ialm").Value)
        '        TotalIPRO = CInt(FilaPartida.Cells("total_ipro").Value)
        '        TotalAXC = CInt(FilaPartida.Cells("total_axc").Value)
        '        ProspectaPEND = CInt(FilaPartida.Cells("prosp_pend").Value)
        '        ProspectaIALM = CInt(FilaPartida.Cells("prosp_ialm").Value)
        '        ProspectaIPRO = CInt(FilaPartida.Cells("prosp_ipro").Value)
        '        ProspectaAXC = CInt(FilaPartida.Cells("prosp_axc").Value)
        '        FechaProgramacion = FilaPartida.Cells("FProg").Value
        '        PEND = FilaPartida.Cells("actual_prog_PEND").Value
        '        IALM = FilaPartida.Cells("actual_prog_IALM").Value
        '        IPRO = FilaPartida.Cells("actual_prog_IPRO").Value
        '        AXC = FilaPartida.Cells("actual_prog_AXC").Value
        '        FechaCreacion = CDate(FilaPartida.Cells("FCaptura").Value)
        '        ClienteSayID = FilaPartida.Cells("ClientesayId").Value
        '        ClienteSicy = FilaPartida.Cells("ClientesicyId").Value
        '        PedidoID = FilaPartida.Cells("PSICY").Value
        '        Partida = FilaPartida.Cells("#Part").Value

        '        If IsDBNull(FilaPartida.Cells("ProductoEstiloID").Value) = False Then
        '            ProductoEstilo = CInt(FilaPartida.Cells("ProductoEstiloID").Value)
        '        Else
        '            ProductoEstilo = Nothing
        '        End If

        '        If IsDBNull(FilaPartida.Cells("FamiliaProyeccionID").Value) = False Then
        '            FamiliaProyeccion = CInt(FilaPartida.Cells("FamiliaProyeccionID").Value)
        '        Else
        '            FamiliaProyeccion = Nothing
        '        End If

        '        If IsDBNull(FilaPartida.Cells("TiendaIDSicy").Value) = False Then
        '            IdTienda = CInt(FilaPartida.Cells("TiendaIDSicy").Value)
        '        Else
        '            IdTienda = Nothing
        '        End If

        '        If IsDBNull(FilaPartida.Cells("IdCodigo").Value) = False Then
        '            IdCodigoSicy = FilaPartida.Cells("IdCodigo").Value
        '        Else
        '            IdCodigoSicy = Nothing
        '        End If

        '        If IsDBNull(FilaPartida.Cells("IdTalla").Value) = False Then
        '            IdTalla = FilaPartida.Cells("IdTalla").Value
        '        Else
        '            IdTalla = Nothing
        '        End If


        '        ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, ProspectaIDLocal, PedidoID, Partida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '        If IsNothing(Celda.Value) = False And IsDBNull(Celda.Value) = False Then
        '            If Celda.Appearance.ForeColor = Color.Purple Then
        '                ListaPedidosCompletos.Add(PedidoID)
        '                ListaClientesCompletosCompletos.Add(ClienteSayID)
        '                For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                    If IsDBNull(FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
        '                        CantidadParesPartida = CInt(FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
        '                        If CantidadParesPartida <> 0 Then
        '                            ObjprospectaBU.EditarPlaneacionProspecta(ProspectaIDLocal, ClienteSayID, PedidoID, Partida, CantidadParesPartida, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
        '                            FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '                            Celda.Appearance.ForeColor = Color.Black
        '                        End If
        '                    End If
        '                    FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '                Next

        '                If FilaPartida.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
        '                    If FilaPartida.Cells("PrsProsp").Value <> 0 Then
        '                        FilaPartida.Cells("PR").Value = "SI"
        '                        FilaPartida.Cells("PR").Appearance.BackColor = Color.Green
        '                    Else
        '                        FilaPartida.Cells("PR").Value = "NO"
        '                        FilaPartida.Cells("PR").Appearance.BackColor = Color.Red
        '                    End If
        '                End If

        '            ElseIf Celda.Appearance.ForeColor = Color.OrangeRed Then
        '                For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                    FilaPartida.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
        '                Next
        '                Celda.Value = 0
        '            End If
        '        End If
        '    End If
        'Next


        'For Each FilaPedidos As UltraGridRow In gridPedidos.Rows
        '    Celda = FilaPedidos.Cells("PrsProsp")
        '    If ListaPedidosModificados.Exists(Function(x) x = FilaPedidos.Cells("PSICY").Value) = True Then

        '        If ListaPedidosCompletos.Exists(Function(y) y = FilaPedidos.Cells("PSICY").Value) = True Then
        '            For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                If IsDBNull(FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
        '                    CantidadParesPartida = CInt(FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
        '                    If CantidadParesPartida <> 0 Then
        '                        FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '                        Celda.Appearance.ForeColor = Color.Black
        '                    End If
        '                End If
        '                FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '                Celda.Appearance.ForeColor = Color.Black
        '            Next
        '            Celda.Appearance.ForeColor = Color.Black

        '            If FilaPedidos.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
        '                If FilaPedidos.Cells("PrsProsp").Value <> 0 Then
        '                    FilaPedidos.Cells("PR").Value = "SI"
        '                    FilaPedidos.Cells("PR").Appearance.BackColor = Color.Green
        '                Else
        '                    FilaPedidos.Cells("PR").Value = "NO"
        '                    FilaPedidos.Cells("PR").Appearance.BackColor = Color.Red
        '                End If
        '            End If
        '        Else
        '            For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
        '            Next
        '        End If


        '        'If IsNothing(Celda.Value) = False Then
        '        '    For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '        '        If IsDBNull(FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
        '        '            CantidadParesPartida = CInt(FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
        '        '            If CantidadParesPartida <> 0 Then
        '        '                FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '        '                Celda.Appearance.ForeColor = Color.Black
        '        '            End If
        '        '        End If
        '        '    Next


        '        'End If
        '    Else
        '        'If FilaPedidos.Hidden = False Then
        '        '    If Celda.Appearance.ForeColor = Color.OrangeRed Or Celda.Appearance.ForeColor = Color.Purple Then
        '        '        For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '        '            If IsDBNull(FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
        '        '                FilaPedidos.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
        '        '            End If
        '        '        Next
        '        '    End If
        '        'End If
        '    End If
        'Next

        'For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
        '    Celda = FilaCliente.Cells("PrsProsp")
        '    If ListaClientesModificados.Exists(Function(x) x = FilaCliente.Cells("ClienteSayID").Value) = True Then

        '        If ListaClientesCompletosCompletos.Exists(Function(y) y = FilaCliente.Cells("ClienteSayID").Value) = True Then
        '            For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                If IsDBNull(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
        '                    CantidadParesPartida = CInt(FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
        '                    If CantidadParesPartida <> 0 Then
        '                        FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
        '                        Celda.Appearance.ForeColor = Color.Black
        '                    End If
        '                End If

        '                FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black

        '            Next
        '            Celda.Appearance.ForeColor = Color.Black

        '            If FilaCliente.Cells("PrsProsp").Appearance.ForeColor = Color.Black Then
        '                If FilaCliente.Cells("PrsProsp").Value <> 0 Then
        '                    FilaCliente.Cells("PR").Value = "SI"
        '                    FilaCliente.Cells("PR").Appearance.BackColor = Color.Green
        '                Else
        '                    FilaCliente.Cells("PR").Value = "NO"
        '                    FilaCliente.Cells("PR").Appearance.BackColor = Color.Red
        '                End If
        '            End If
        '        Else
        '            For Each DIA As Entidades.ProspectaDias In DiasProspecta
        '                FilaCliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value = 0
        '            Next
        '        End If

        '    End If
        'Next

        'ActualizarCantidadParesProspectaPedidoGuardados(ListaClientesModificados)
        'ActualizarCantidadParesPedidoPartidaGuardados(ListaPedidosModificados)

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim objREgistraUsuarioProspecta As New Ventas.Negocios.ProspectaBU

            ValorGuardado = True
            btnGuardar.Enabled = False
            Dim ObjProspecta As Entidades.ProspectaDetalle
            Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU
            Dim NumeroSemana As Int32
            Dim ProspectaIDGuardada As Int32 = 0
            Dim objentProspecta As New Entidades.ProspectaInformacion
            Cursor = Cursors.WaitCursor
            Dim Celda As UltraGridCell
            Dim ListaAuxiliarCliente As New List(Of Integer)
            Dim ListaAuxiliarPedido As New List(Of Integer)
            Dim ListaAuxiliarPartida As New List(Of Integer)
            Dim EsProspectaNueva As Boolean = False


            If ProspectaID = -1 Then
                EsProspectaNueva = True
            Else
                EsProspectaNueva = False
            End If

            ListaAuxiliarCliente = ListaIndicesClientesModificadas.Distinct.ToList
            ListaIndicesClientesModificadas.Clear()
            ListaIndicesClientesModificadas = ListaAuxiliarCliente


            ListaAuxiliarPedido = ListaIndicesPartidasModificadas.Distinct.ToList
            ListaIndicesPartidasModificadas.Clear()
            ListaIndicesPartidasModificadas = ListaAuxiliarPedido


            ListaAuxiliarPartida = ListaIndicesPedidosModificadas.Distinct.ToList
            ListaIndicesPedidosModificadas.Clear()
            ListaIndicesPedidosModificadas = ListaAuxiliarPartida



            If ProspectaID = -1 Then
                NumeroSemana = DatePart(DateInterval.WeekOfYear, dtmFechaInicio.Value)
                ObjprospectaBU.GuardarProspecta(NumeroSemana, dtmFechaInicio.Value.Year, dtmFechaInicio.Value.ToShortDateString(), dtmFechaFin.Value.ToShortDateString(), _
                                            dtmFechaProgramacion.Value.ToShortDateString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, 0, 0, 0, 0)
                ProspectaIDGuardada = ObjprospectaBU.ObtenerProspectaIDGuardada()
                GuardarCliente(ProspectaIDGuardada)
            Else
                GuardarCliente(ProspectaID)
            End If


            If tabProspecta.SelectedIndex = 1 Then 'Tab Pedido
                If ProspectaID = -1 Then
                    GuardarPedido(ProspectaIDGuardada)
                Else
                    GuardarPedido(ProspectaID)
                End If
            End If


            If tabProspecta.SelectedIndex = 2 Then
                If ProspectaID = -1 Then
                    GuardarPartida(ProspectaIDGuardada)
                Else
                    GuardarPartida(ProspectaID)
                End If
            End If


            'ListaIndicesClientesModificadas.Clear()
            'ListaIndicesPartidasModificadas.Clear()
            'ListaIndicesPedidosModificadas.Clear()



            If ProspectaID = -1 Then

                ObjprospectaBU.GuardarParesPendientesPorAgente(ProspectaIDGuardada, dtmFechaFin.Value, dtmFechaProgramacion.Value)

            End If

            ValorGuardado = False

            If ProspectaID = -1 Then
                ProspectaID = ProspectaIDGuardada
            End If

            btnGuardar.Enabled = False
            ModoEdicion = True
            PonerModoEdicionColumunas()
            ObjprospectaBU.ActualizarInformacionProspecta(ProspectaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If ModoEdicion = True Then
                btnGuardar.Enabled = True
            End If


            objentProspecta = ObtenerInformacionProspecta(ProspectaID)
            IdEstadoProspecta = objentProspecta.IDEstatusProspecta


            If EsProspectaNueva = True Then
                If IdEstadoProspecta <> 89 And IdEstadoProspecta <> 90 Then
                    objREgistraUsuarioProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID, Not ModoEdicion)
                    ConsultarUsuariosEnEdicionOProspecta()
                End If
                chkPlaneacionSemanal.Visible = True
            End If


            'If ValidarParesPlaneadosCompletos() = True Then
            '    ModoEdicion = False
            '    If ProspectaID = -1 Then 'Crear
            '        If show_message("Confirmar", "¿Desea guardar los cambios realizados en la prospecta de la SEMANA " + txtSemana.Text.Trim() + " ? (Una vez realizada esta acción no se podrá revertir)") = Windows.Forms.DialogResult.OK Then
            '            Cursor = Cursors.WaitCursor
            '            NumeroSemana = DatePart(DateInterval.WeekOfYear, dtmFechaInicio.Value)

            '            ObjprospectaBU.GuardarProspecta(NumeroSemana, dtmFechaInicio.Value.Year, dtmFechaInicio.Value.ToShortDateString(), dtmFechaFin.Value.ToShortDateString(), _
            '                                        dtmFechaProgramacion.Value.ToShortDateString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, 0, 0, 0, 0)
            '            ProspectaIDGuardada = ObjprospectaBU.ObtenerProspectaIDGuardada()
            '            GuardarIncidencias(ProspectaIDGuardada) 'Guarda la informacion de las confimacion y los motivos de incidencia

            '            GuardarPlaneacionProspecta(ProspectaIDGuardada)

            '            'If IsNothing(ListaPedidosProspectadosCompletos) = False And IsNothing(ListaClientesProspectadosCompletos) = False Then
            '            '    If ListaPedidosProspectadosCompletos.Count <> 0 Or ListaClientesProspectadosCompletos.Count <> 0 Then
            '            '        GuardarPlaneacionProspecta(ProspectaIDGuardada)
            '            '    End If
            '            'End If




            '            ObjprospectaBU.ActualizarInformacionProspecta(ProspectaIDGuardada, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            '            show_message("Aviso", "Prospecta guardada con exito")

            '            'ObjprospectaBU.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)
            '            btnGuardar.Enabled = True
            '            PonerModoEdicionColumunas()
            '            LimpiarParesDiaPlaneacion()
            '            CambiarColorDatosGuardados()

            '            'If IsNothing(ListaPedidosProspectadosCompletos) = False And IsNothing(ListaClientesProspectadosCompletos) = False Then
            '            '    If ListaPedidosProspectadosCompletos.Count <> 0 Or ListaClientesProspectadosCompletos.Count <> 0 Then
            '            '        CambiarColorDatosGuardados()
            '            '    End If
            '            'End If

            '            ProspectaID = ProspectaIDGuardada
            '            ModoEdicion = True
            '            btnEditar.Enabled = True
            '            btnCancelarProspecta.Enabled = True
            '            'Me.Close()
            '        Else
            '            ModoEdicion = True
            '            btnGuardar.Enabled = True
            '            PonerModoEdicionColumunas()
            '        End If

            '    Else 'Editar
            '        If show_message("Confirmar", "¿Desea guardar los cambios realizados en la prospecta de la SEMANA " + txtSemana.Text.Trim() + " ? (Una vez realizada esta acción no se podrá revertir)") = Windows.Forms.DialogResult.OK Then
            '            Cursor = Cursors.WaitCursor
            '            GuardarIncidencias(ProspectaID)
            '            objentProspecta = ObtenerInformacionProspecta(ProspectaID)
            '            If objentProspecta.IDEstatusProspecta = 87 Then
            '                If IsNothing(ListaPedidosProspectadosCompletos) = False And IsNothing(ListaClientesProspectadosCompletos) = False Then
            '                    If ListaPedidosProspectadosCompletos.Count <> 0 Or ListaClientesProspectadosCompletos.Count <> 0 Then
            '                        GuardarPlaneacionProspecta(ProspectaIDGuardada)
            '                    End If
            '                End If


            '                LimpiarParesDiaPlaneacion()
            '                If IsNothing(ListaPedidosProspectadosCompletos) = False And IsNothing(ListaClientesProspectadosCompletos) = False Then
            '                    If ListaPedidosProspectadosCompletos.Count <> 0 Or ListaClientesProspectadosCompletos.Count <> 0 Then
            '                        CambiarColorDatosGuardados()
            '                    End If
            '                End If

            '            End If
            '            ObjprospectaBU.ActualizarInformacionProspecta(ProspectaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            '            ModoEdicion = False

            '            show_message("Aviso", "Prospecta guardada con éxito")

            '        End If
            '        btnGuardar.Enabled = True
            '        PonerModoEdicionColumunas()
            '    End If
            'Else
            '    show_message("Aviso", "No se puede guardar debido a que los pares a prospectar no cumplen con el total de los pendientes.")
            '    btnGuardar.Enabled = True
            'End If

            show_message("Aviso", "Prospecta guardada con éxito")

        Catch ex As Exception
            show_message("Aviso", "Ocurrio un error al guardar")
            Cursor = Cursors.Default
            ValorGuardado = False
        End Try
        Cursor = Cursors.Default








    End Sub

    Private Function ValidarPArtidasIncompletas() As Boolean
        Dim CeldaModificada As UltraGridCell
        Dim ExistenPartidasIncompletas As Boolean = False

        For Each fila As UltraGridRow In gridPartidas.Rows

            CeldaModificada = fila.Cells("PrsProsp")
            'si la celda fue modificada (color morado)
            If CeldaModificada.Appearance.ForeColor = Color.OrangeRed Then
                ExistenPartidasIncompletas = True
            End If
            If ExistenPartidasIncompletas = True Then
                Exit For
            End If
        Next

        Return ExistenPartidasIncompletas
    End Function


    Private Sub GuardarIncidencias(ByVal LProspectaID As Integer)
        Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU
        Dim Confirmacion As Boolean = False
        Dim UsuarioConfirma As Integer
        Dim FechaConfirmacion As Date
        Dim MotivoIncidenciaID As Integer
        Dim Observaciones As String = String.Empty
        Dim ClienteSayID As Integer = 0
        Dim CantidadPares As Integer = 0
        Dim CeldaModificada As UltraGridCell


        For Each Fila As UltraGridRow In gridListaProspecta.Rows


            If Fila.Cells("ColumnaModificada").Value = True Or Fila.Cells("Conf").Activation = Activation.AllowEdit Then
                ClienteSayID = Fila.Cells("ClienteSayID").Value
                Confirmacion = Fila.Cells("Conf").Value
                If Confirmacion = True Then
                    UsuarioConfirma = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                Else
                    UsuarioConfirma = -1
                End If


                If IsNothing(Fila.Cells("FConfirmacion").Value) = False And IsDBNull(Fila.Cells("FConfirmacion").Value) = False Then
                    FechaConfirmacion = CDate(Fila.Cells("FConfirmacion").Value)                    
                Else
                    FechaConfirmacion = Nothing
                End If


                If IsNothing(Fila.Cells("*Incidencia").Value) = False Then
                    MotivoIncidenciaID = Fila.Cells("*Incidencia").Column.ValueList.GetValue(Fila.Cells("*Incidencia").Value.ToString, 0)
                Else
                    MotivoIncidenciaID = -1
                End If

                Observaciones = CStr(Fila.Cells("*Observaciones").Value)
                If String.IsNullOrEmpty(Observaciones) = True Then
                    Observaciones = String.Empty
                End If

                ObjprospectaBU.GuardarIncidenciasProspecta(LProspectaID, ClienteSayID, Confirmacion, UsuarioConfirma, FechaConfirmacion, MotivoIncidenciaID, Observaciones)

                Fila.Cells("FConfirmacion").Appearance.ForeColor = Color.Black
                Fila.Cells("*Observaciones").Appearance.ForeColor = Color.Black
                Fila.Cells("Confirma").Appearance.ForeColor = Color.Black
                Fila.Cells("*Incidencia").Appearance.ForeColor = Color.Black


            End If


            If Fila.Cells("PA").Value = "NO" Then
                CeldaModificada = Fila.Cells("PrsProsp")
                If (CeldaModificada.Appearance.ForeColor <> Color.Purple And CeldaModificada.Appearance.ForeColor <> Color.OrangeRed) Then
                    Continue For
                End If

                ClienteSayID = Fila.Cells("ClienteSayID").Value
                ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, LProspectaID, -1, -1, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                    If IsDBNull(Fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                        CantidadPares = CInt(Fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                        If CantidadPares <> 0 Then
                            ObjprospectaBU.EditarPlaneacionProspecta(LProspectaID, ClienteSayID, -1, -1, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1, Nothing, -1, -1, -1, -1, "-1", "-1", -1, -1, -1, -1, Nothing, -1, -1, -1, -1, -1, -1, -1, -1, -1)
                            Fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                            CeldaModificada.Appearance.ForeColor = Color.Black
                        End If
                    End If
                Next
            End If

        Next

    End Sub

    Private Function ObtenerClientesProspectadosPorCliente() As List(Of Integer)
        Dim Lista As New List(Of Integer)

        For Each fila As UltraGridRow In gridListaProspecta.Rows
            If fila.Cells("PA").Value = "NO" Then

                Lista.Add(fila.Cells("ClienteSicyID").Value)

            End If
        Next
        Return Lista
    End Function

    Private Sub GuardarPlaneacionProspecta(ByVal LProspesctaID As Integer)
        Dim ObjprospectaBU As New Ventas.Negocios.ProspectaBU
        Dim NumeroSemana As Int32

        Dim Lunes As Integer = 0
        Dim Martes As Integer = 0
        Dim Miercoles As Integer = 0
        Dim Jueves As Integer = 0
        Dim Viernes As Integer = 0
        Dim Sabado As Integer = 0
        Dim CantidadPares As Integer = 0
        Dim CeldaModificada As UltraGridCell
        Dim PedidoSicyID As Integer = 0
        Dim ClienteSayID As Integer = 0
        Dim NumeroPartida As Integer = 0
        Dim DistribucionDias As String = String.Empty
        Dim DistribucionParesDias As String = String.Empty
        Dim numeropares As Int32 = gridPartidas.Rows.Count
        Dim PEND As Int32
        Dim IALM As Int32
        Dim IPRO As Int32
        Dim AXC As Int32
        Dim IdCodigoSicy As String = String.Empty
        Dim IdTalla As String = String.Empty
        Dim FechaProgramacion As Date
        Dim ClienteSicy As Int32
        Dim val As String = String.Empty
        Dim ProductoEstilo As Integer
        Dim FamiliaProyeccion As Integer
        Dim IdTienda As Integer
        Dim FechaCreacion As Date
        Dim ParesPartida As Integer
        Dim MarcaID As Integer
        Dim TotalPEND As Integer
        Dim TotalIALM As Integer
        Dim TotalIPRO As Integer
        Dim TotalAXC As Integer
        Dim ProspectaPEND As Integer
        Dim ProspectaIALM As Integer
        Dim ProspectaIPRO As Integer
        Dim ProspectaAXC As Integer
        Dim CeldaGuardada As UltraGridCell

        Dim ListaClientesProspectaPorCliente As New List(Of Integer)

        ListaClientesProspectaPorCliente = ObtenerClientesProspectadosPorCliente()


        Try
            NumeroSemana = DatePart(DateInterval.WeekOfYear, dtmFechaInicio.Value)

            For Each fila As UltraGridRow In gridPartidas.Rows
                If ListaClientesProspectaPorCliente.Count > 0 Then
                    ClienteSayID = fila.Cells("ClientesayId").Value
                    ClienteSicy = fila.Cells("ClientesicyId").Value

                    If IsDBNull(fila.Cells("IdCodigo").Value) = False Then
                        IdCodigoSicy = fila.Cells("IdCodigo").Value
                    Else
                        IdCodigoSicy = Nothing
                    End If

                    If IsDBNull(fila.Cells("IdTalla").Value) = False Then
                        IdTalla = fila.Cells("IdTalla").Value
                    Else
                        IdTalla = Nothing
                    End If


                    FechaProgramacion = fila.Cells("FProg").Value
                    PEND = fila.Cells("actual_prog_PEND").Value
                    IALM = fila.Cells("actual_prog_IALM").Value
                    IPRO = fila.Cells("actual_prog_IPRO").Value
                    AXC = fila.Cells("actual_prog_AXC").Value
                    PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                    PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                    NumeroPartida = CInt(fila.Cells("#Part").Value)
                    FechaCreacion = CDate(fila.Cells("FCaptura").Value)

                    If IsDBNull(fila.Cells("ProductoEstiloID").Value) = False Then
                        ProductoEstilo = CInt(fila.Cells("ProductoEstiloID").Value)
                    Else
                        ProductoEstilo = Nothing
                    End If

                    If IsDBNull(fila.Cells("FamiliaProyeccionID").Value) = False Then
                        FamiliaProyeccion = CInt(fila.Cells("FamiliaProyeccionID").Value)
                    Else
                        FamiliaProyeccion = Nothing
                    End If

                    If IsDBNull(fila.Cells("TiendaIDSicy").Value) = False Then
                        IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                    Else
                        IdTienda = Nothing
                    End If


                    ParesPartida = CInt(fila.Cells("Prs Part").Value)
                    MarcaID = CInt(fila.Cells("MarcaId").Value)
                    TotalPEND = CInt(fila.Cells("total_pend").Value)
                    TotalIALM = CInt(fila.Cells("total_ialm").Value)
                    TotalIPRO = CInt(fila.Cells("total_ipro").Value)
                    TotalAXC = CInt(fila.Cells("total_axc").Value)
                    ProspectaPEND = CInt(fila.Cells("prosp_pend").Value)
                    ProspectaIALM = CInt(fila.Cells("prosp_ialm").Value)
                    ProspectaIPRO = CInt(fila.Cells("prosp_ipro").Value)
                    ProspectaAXC = CInt(fila.Cells("prosp_axc").Value)

                    If ListaClientesProspectaPorCliente.Exists(Function(x) x = fila.Cells("ClientesicyId").Value) = True Then
                        ObjprospectaBU.EditarPlaneacionProspecta(LProspesctaID, ClienteSayID, PedidoSicyID, NumeroPartida, -1, Date.Now, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                    End If
                End If


                PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                If ListaPedidosProspectadosCompletos.Exists(Function(x) x = PedidoSicyID) = True Then
                    CeldaModificada = fila.Cells("PrsProsp")
                    If (CeldaModificada.Appearance.ForeColor <> Color.Purple And CeldaModificada.Appearance.ForeColor <> Color.OrangeRed) Then
                        Continue For
                    End If

                    ClienteSayID = fila.Cells("ClientesayId").Value
                    ClienteSicy = fila.Cells("ClientesicyId").Value

                    If IsDBNull(fila.Cells("IdCodigo").Value) = False Then
                        IdCodigoSicy = fila.Cells("IdCodigo").Value
                    Else
                        IdCodigoSicy = Nothing
                    End If

                    If IsDBNull(fila.Cells("IdTalla").Value) = False Then
                        IdTalla = fila.Cells("IdTalla").Value
                    Else
                        IdTalla = Nothing
                    End If

                    'IdCodigoSicy = fila.Cells("IdCodigo").Value
                    'IdTalla = fila.Cells("IdTalla").Value

                    FechaProgramacion = fila.Cells("FProg").Value
                    PEND = fila.Cells("actual_prog_PEND").Value
                    IALM = fila.Cells("actual_prog_IALM").Value
                    IPRO = fila.Cells("actual_prog_IPRO").Value
                    AXC = fila.Cells("actual_prog_AXC").Value

                    PedidoSicyID = CInt(fila.Cells("PSICY").Value)

                    DistribucionDias = String.Empty
                    DistribucionParesDias = String.Empty


                    'si la celda fue modificada (color morado)
                    If CeldaModificada.Appearance.ForeColor = Color.Purple Then

                        PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                        NumeroPartida = CInt(fila.Cells("#Part").Value)
                        FechaCreacion = CDate(fila.Cells("FCaptura").Value)

                        If IsDBNull(fila.Cells("FamiliaProyeccionID").Value) = False Then
                            FamiliaProyeccion = CInt(fila.Cells("FamiliaProyeccionID").Value)
                        Else
                            FamiliaProyeccion = Nothing
                        End If

                        If IsDBNull(fila.Cells("TiendaIDSicy").Value) = False Then
                            IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                        Else
                            IdTienda = Nothing
                        End If

                        'ProductoEstilo = CInt(fila.Cells("ProductoEstiloID").Value)
                        'FamiliaProyeccion = CInt(fila.Cells("FamiliaProyeccionID").Value)
                        If IsDBNull(fila.Cells("TiendaIDSicy").Value) = False Then
                            IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                        Else
                            IdTienda = Nothing
                        End If

                        'IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                        ParesPartida = CInt(fila.Cells("Prs Part").Value)
                        MarcaID = CInt(fila.Cells("MarcaId").Value)
                        TotalPEND = CInt(fila.Cells("total_pend").Value)
                        TotalIALM = CInt(fila.Cells("total_ialm").Value)
                        TotalIPRO = CInt(fila.Cells("total_ipro").Value)
                        TotalAXC = CInt(fila.Cells("total_axc").Value)
                        ProspectaPEND = CInt(fila.Cells("prosp_pend").Value)
                        ProspectaIALM = CInt(fila.Cells("prosp_ialm").Value)
                        ProspectaIPRO = CInt(fila.Cells("prosp_ipro").Value)
                        ProspectaAXC = CInt(fila.Cells("prosp_axc").Value)

                        ''SI LA PARTIDA DEL PEDIDO NO ESTA REGRISTRADA EN LA PROSPECTA SE PROCEDE A REGISTRAR
                        'If ProspectaID <> -1 Then
                        '    ObjprospectaBU.GuardarPartidaProspecta(ProspectaID, ClienteSicy, ClienteSayID, PedidoSicyID, NumeroPartida, FechaProgramacion, PEND, IALM, IPRO, AXC, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IdCodigoSicy, IdTalla)
                        'End If

                        ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, LProspesctaID, PedidoSicyID, NumeroPartida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                        'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            If IsDBNull(fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                CantidadPares = CInt(fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                If CantidadPares <> 0 Then
                                    CeldaModificada.Appearance.ForeColor = Color.Black
                                    CeldaGuardada = fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString())
                                    CeldaGuardada.Appearance.ForeColor = Color.Black
                                    ObjprospectaBU.EditarPlaneacionProspecta(LProspesctaID, ClienteSayID, PedidoSicyID, NumeroPartida, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                                Else
                                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    CeldaModificada.Appearance.ForeColor = Color.Black
                                    'CeldaGuardada.Appearance.ForeColor = Color.Black
                                End If


                            End If
                        Next

                        If IsDBNull(fila.Cells("PrsProsp").Value) = False Then
                            If fila.Cells("PrsProsp").Value <> 0 Then
                                fila.Cells("PR").Value = "SI"
                                fila.Cells("PR").Appearance.BackColor = Color.Green
                            Else
                                fila.Cells("PR").Value = "NO"
                                fila.Cells("PR").Appearance.BackColor = Color.Red
                            End If
                        End If

                    End If

                    If IsDBNull(CeldaModificada.Value) = False Then
                        If (CeldaModificada.Appearance.ForeColor = Color.Purple Or CeldaModificada.Appearance.ForeColor = Color.OrangeRed) And CeldaModificada.Value = 0 Then
                            PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                            NumeroPartida = CInt(fila.Cells("#Part").Value)
                            PedidoSicyID = CInt(fila.Cells("PSICY").Value)
                            NumeroPartida = CInt(fila.Cells("#Part").Value)
                            FechaCreacion = CDate(fila.Cells("FCaptura").Value)

                            If IsDBNull(fila.Cells("FamiliaProyeccionID").Value) = False Then
                                FamiliaProyeccion = CInt(fila.Cells("FamiliaProyeccionID").Value)
                            Else
                                FamiliaProyeccion = Nothing
                            End If

                            If IsDBNull(fila.Cells("TiendaIDSicy").Value) = False Then
                                IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                            Else
                                IdTienda = Nothing
                            End If

                            'ProductoEstilo = CInt(fila.Cells("ProductoEstiloID").Value)
                            'FamiliaProyeccion = CInt(fila.Cells("FamiliaProyeccionID").Value)
                            If IsDBNull(fila.Cells("TiendaIDSicy").Value) = False Then
                                IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                            Else
                                IdTienda = Nothing
                            End If
                            'IdTienda = CInt(fila.Cells("TiendaIDSicy").Value)
                            ParesPartida = CInt(fila.Cells("Prs Part").Value)
                            MarcaID = CInt(fila.Cells("MarcaId").Value)
                            TotalPEND = CInt(fila.Cells("total_pend").Value)
                            TotalIALM = CInt(fila.Cells("total_ialm").Value)
                            TotalIPRO = CInt(fila.Cells("total_ipro").Value)
                            TotalAXC = CInt(fila.Cells("total_axc").Value)
                            ProspectaPEND = CInt(fila.Cells("prosp_pend").Value)
                            ProspectaIALM = CInt(fila.Cells("prosp_ialm").Value)
                            ProspectaIPRO = CInt(fila.Cells("prosp_ipro").Value)
                            ProspectaAXC = CInt(fila.Cells("prosp_axc").Value)


                            ''SI LA PARTIDA DEL PEDIDO NO ESTA REGRISTRADA EN LA PROSPECTA SE PROCEDE A REGISTRAR
                            'If ProspectaID <> -1 Then
                            '    ObjprospectaBU.GuardarPartidaProspecta(ProspectaID, ClienteSicy, ClienteSayID, PedidoSicyID, NumeroPartida, FechaProgramacion, PEND, IALM, IPRO, AXC, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IdCodigoSicy, IdTalla)
                            'End If

                            ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, LProspesctaID, PedidoSicyID, NumeroPartida, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                            'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
                            For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                If IsDBNull(fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
                                    CantidadPares = CInt(fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
                                    If CantidadPares <> 0 Then
                                        CeldaModificada.Appearance.ForeColor = Color.Black
                                        CeldaGuardada = fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString())
                                        CeldaGuardada.Appearance.ForeColor = Color.Black
                                        ObjprospectaBU.EditarPlaneacionProspecta(LProspesctaID, ClienteSayID, PedidoSicyID, NumeroPartida, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0, FechaProgramacion, PEND, IALM, IPRO, AXC, IdCodigoSicy, IdTalla, ProductoEstilo, MarcaID, FamiliaProyeccion, IdTienda, FechaCreacion, ParesPartida, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
                                    Else
                                        fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                        CeldaModificada.Appearance.ForeColor = Color.Black
                                    End If

                                End If
                            Next

                            If fila.Cells("PrsProsp").Appearance.ForeColor = Color.Purple Then
                                If fila.Cells("PrsProsp").Value <> 0 Then
                                    fila.Cells("PR").Value = "SI"
                                    fila.Cells("PR").Appearance.BackColor = Color.Green
                                Else
                                    fila.Cells("PR").Value = "NO"
                                    fila.Cells("PR").Appearance.BackColor = Color.Red
                                End If
                            End If

                        End If
                    End If
                End If



                'fila.Cells("ClientesicyId").Value

                'If  ListaClientesProspectaPorCliente


            Next

            'For Each Filacliente As UltraGridRow In gridListaProspecta.Rows
            '    If Filacliente.Cells("PA").Value = "NO" Then
            '        ClienteSayID = Filacliente.Cells("ClienteSayID").Value
            '        ObjprospectaBU.LimpiarPlaneacionPartida(ClienteSayID, LProspesctaID, -1, -1, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            '        'Actualizar la planeacion de los pares  en la tablas de la prospecta por dia
            '        For Each DIA As Entidades.ProspectaDias In DiasProspecta
            '            If IsDBNull(Filacliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value) = False Then
            '                CantidadPares = CInt(Filacliente.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Value)
            '                ObjprospectaBU.EditarPlaneacionProspecta(LProspesctaID, ClienteSayID, -1, -1, CantidadPares, DIA.Dia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            '            End If
            '        Next
            '    End If


            'Next

        Catch ex As Exception
            Dim Fallo As String
            Fallo = "cadenas vacia"

        End Try

    End Sub

    'Private Function ObtenerPedidosSeleccinadosGrid(ByVal SoloSeleccionados As Boolean) As String
    '    Dim filtro As String = String.Empty
    '    For Each row As UltraGridRow In gridPedidos.Rows
    '        If row.IsFilteredOut = False Then
    '            If SoloSeleccionados = True Then
    '                If row.Cells(" ").Value = True And row.Hidden = False Then
    '                    If filtro = String.Empty Then
    '                        filtro += " '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
    '                    Else
    '                        filtro += ", '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
    '                    End If
    '                End If

    '            Else
    '                If filtro = String.Empty Then
    '                    filtro += " '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
    '                Else
    '                    filtro += ", '" + Replace(row.Cells("ProspectaPedidoID").Text, ",", "") + "'"
    '                End If
    '            End If
    '        End If
    '    Next
    '    Return filtro
    'End Function

    Private Function ObtenerDistribucionParesDia(ByVal Fila As UltraGridRow, ByVal Dia As Integer) As String
        Dim ColumnaPlaneacion As String = "plan_"
        Dim ColumnaProyeccion As String = "proy_"
        Dim ColumnaConfirmacionOT As String = "ConfOT_"
        Dim ColumnaEmbarque As String = "Emb_"
        Dim ColumnaSalida As String = "Sal_"

        Dim ValorPlaneacion As Integer = 0
        Dim ValorProyeccion As Integer = 0
        Dim ValorConfirmacionOT As Integer = 0
        Dim ValorEmbarque As Integer = 0
        Dim ValorSalida As Integer = 0

        Dim NumeroPares As String = String.Empty
        Select Case Dia
            Case 1
                ColumnaConfirmacionOT += "Lun"
                ColumnaEmbarque += "Lun"
                ColumnaProyeccion += "Lun"
                ColumnaSalida += "Lun"
                ColumnaPlaneacion += "Lun"
            Case 2
                ColumnaConfirmacionOT += "Mar"
                ColumnaEmbarque += "Mar"
                ColumnaProyeccion += "Mar"
                ColumnaSalida += "Mar"
                ColumnaPlaneacion += "Mar"

            Case 3
                ColumnaConfirmacionOT += "Mie"
                ColumnaEmbarque += "Mie"
                ColumnaProyeccion += "Mie"
                ColumnaSalida += "Mie"
                ColumnaPlaneacion += "Mie"
            Case 4
                ColumnaConfirmacionOT += "Jue"
                ColumnaEmbarque += "Jue"
                ColumnaProyeccion += "Jue"
                ColumnaSalida += "Jue"
                ColumnaPlaneacion += "Jue"
            Case 5
                ColumnaConfirmacionOT += "Vie"
                ColumnaEmbarque += "Vie"
                ColumnaProyeccion += "Vie"
                ColumnaSalida += "Vie"
                ColumnaPlaneacion += "Vie"

            Case 6
                ColumnaConfirmacionOT += "Sab"
                ColumnaEmbarque += "Sab"
                ColumnaProyeccion += "Sab"
                ColumnaSalida += "Sab"
                ColumnaPlaneacion += "Sab"
        End Select

        If IsNumeric(Fila.Cells(ColumnaPlaneacion).Text) Then
            ValorPlaneacion = Fila.Cells(ColumnaPlaneacion).Text
        End If

        If IsNumeric(Fila.Cells(ColumnaProyeccion).Text) Then
            ValorProyeccion = Fila.Cells(ColumnaProyeccion).Text
        End If

        If IsNumeric(Fila.Cells(ColumnaConfirmacionOT).Text) Then
            ValorConfirmacionOT = Fila.Cells(ColumnaConfirmacionOT).Text
        End If

        If IsNumeric(Fila.Cells(ColumnaEmbarque).Text) Then
            ValorEmbarque = Fila.Cells(ColumnaEmbarque).Text
        End If

        If IsNumeric(Fila.Cells(ColumnaSalida).Text) Then
            ValorSalida = Fila.Cells(ColumnaSalida).Text
        End If
        NumeroPares = ValorPlaneacion.ToString() & "," & ValorProyeccion.ToString() & "," & ValorConfirmacionOT.ToString() & "," & ValorEmbarque.ToString() & "," & ValorSalida.ToString()

        Return NumeroPares
    End Function




    Private Sub gridListaProspecta_MouseClick(sender As Object, e As MouseEventArgs) Handles gridListaProspecta.MouseClick

        Dim objEntProspecta As New Entidades.ProspectaInformacion
        Dim EditarPares As Boolean = False


        If ProspectaID <> -1 Then
            objEntProspecta = ObtenerInformacionProspecta(ProspectaID)
            If objEntProspecta.IDEstatusProspecta = 87 Then
                EditarPares = True
            Else
                EditarPares = False
            End If
        Else
            EditarPares = True
        End If

        If EditarPares = True Then
            If ModoEdicion = True And MostrarMenuContextual = True Then
                If e.Button = Windows.Forms.MouseButtons.Right Then

                    ContextMenuStrip1.Items(0).Visible = True
                    ContextMenuStrip1.Items(1).Visible = True
                    ContextMenuStrip1.Items(2).Visible = True
                    ContextMenuStrip1.Show(Control.MousePosition)
                End If
            End If
        End If

        

    End Sub


    Private Sub Lunes_Click(sender As Object, e As EventArgs) Handles Lunes.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If

        FiltrarPartidasXPedido()
        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Lun")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Lun")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Lun")
        End If

        ' LenarParesTotalAtados()
        Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Marcar la chekbox de aquellas filas que han sido seleccionadas para distribuir los pares
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcarFilasSeleccionadasDistribucionParesCliente()

        Dim MarcarFila As Boolean = False
        For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
            MarcarFila = False
            For Each Celda As UltraGridCell In FilaCliente.Cells
                'If Celda.Selected And (Celda.Column.Key = "actual_prog_IALM" Or Celda.Column.Key = "actual_prog_IPRO" Or Celda.Column.Key = "actual_prog_AXC" Or Celda.Column.Key = "actual_prog_suma") Then
                '    MarcarFila = True
                'End If
                If Celda.Selected And (Celda.Column.Key = "actual_prog_suma") Then
                    MarcarFila = True
                End If
            Next
            If MarcarFila = True Then
                FilaCliente.Cells(" ").Value = True
            Else
                FilaCliente.Cells(" ").Value = False
            End If
        Next
    End Sub

    Private Sub MarcarFilasSeleccionadasDistribucionParesPedido()

        Dim MarcarFila As Boolean = False
        For Each FilaCliente As UltraGridRow In gridPedidos.Rows
            MarcarFila = False
            For Each Celda As UltraGridCell In FilaCliente.Cells
                'If Celda.Selected And (Celda.Column.Key = "actual_prog_IALM" Or Celda.Column.Key = "actual_prog_IPRO" Or Celda.Column.Key = "actual_prog_AXC" Or Celda.Column.Key = "actual_prog_suma") Then
                '    MarcarFila = True
                'End If
                If Celda.Selected And (Celda.Column.Key = "actual_prog_suma") Then
                    MarcarFila = True
                End If
            Next
            If MarcarFila = True Then
                FilaCliente.Cells(" ").Value = True
            Else
                FilaCliente.Cells(" ").Value = False
            End If
        Next
    End Sub

    Private Sub DistribuirParesDiaPlaneacion(ByVal grid As UltraGrid, ByVal Dia As String)
        Dim ListaPedidos As New List(Of Entidades.ProspectaDias)
        Dim ListaClientes As New List(Of Entidades.ProspectaDias)

        Dim ProspectaDia As Entidades.ProspectaDias
        Dim SumaParesPedido As Integer = 0
        Dim SumaFila As Integer = 0
        Dim SumaFilaTotal As Integer = 0
        Dim ProspectaPorPedido As Boolean = False
        Dim FilaSeleccionada As Boolean = False
        Dim valor As String = ""
        For Each fila As UltraGridRow In grid.Rows

            If fila.Hidden = True Then
                Continue For
            End If

            If grid.Name = "gridListaProspecta" Then
                If ProspectaID <> -1 Then
                    valor = fila.Cells("UsuarioEditaID").Value
                    If fila.Cells("UsuarioEditaID").Value <> Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                        Continue For
                    End If
                End If
            End If

            If grid.Name = "gridPedidos" Then
                If ProspectaID <> -1 Then
                    If ListaClientesEnEdicionUsuario.Exists(Function(x) x = fila.Cells("ClientesayId").Value) = False Then
                        Continue For
                    End If
                End If
                'ListaClientesEnEdicionUsuario
            End If

            If grid.Name = "gridPartidas" Then
                If ProspectaID <> -1 Then
                    If ListaClientesEnEdicionUsuario.Exists(Function(x) x = fila.Cells("ClientesayId").Value) = False Then
                        Continue For
                    End If
                End If
            End If




            If grid.Name = "gridPartidas" Then
                FilaSeleccionada = False
                For Each COL As UltraGridCell In fila.Cells
                    If COL.Selected And (COL.Column.Key = "actual_prog_suma") Then
                        SumaFila = CInt(COL.Value)
                        FilaSeleccionada = True
                    End If
                Next

                If FilaSeleccionada = True Then
                    'Poner a 0 antes de asignar el valor

                    ListaIndicesPartidasModificadas.Add(fila.Index)

                  
                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                        fila.Cells("plan_" + Dia).Value = SumaFila
                    Else
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                    End If

                End If



                'If grid.Name = "gridPedidos" Then
                '    ActualizarDistribucionParesPedidoPartida(fila.Cells("PSICY").Value, "plan_" + Dia)
                'End If

                'If grid.Name = "gridListaProspecta" Then
                '    ActualizarDistribucionParesClientePedido(fila.Cells("ClienteSicyID").Value, "plan_" + Dia)

                'End If

            End If



            If grid.Name = "gridPedidos" Then
                FilaSeleccionada = False

                For Each COL As UltraGridCell In fila.Cells
                    If COL.Selected And (COL.Column.Key = "actual_prog_suma") Then
                        SumaFila = CInt(COL.Value)
                        FilaSeleccionada = True
                    End If
                Next

                If FilaSeleccionada = True Then
                    'Poner a 0 antes de asignar el valor
                    ListaIndicesPedidosModificadas.Add(fila.Index)
                   

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)
                        fila.Cells("plan_" + Dia).Value = SumaFila
                    Else
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)
                    End If

                End If
            End If


            If grid.Name = "gridListaProspecta" Then
                FilaSeleccionada = False
                For Each COL As UltraGridCell In fila.Cells
                    If COL.Selected And (COL.Column.Key = "actual_prog_suma") Then
                        SumaFila = CInt(COL.Value)
                        FilaSeleccionada = True

                    End If
                Next

                If FilaSeleccionada = True Then
                    'Poner a 0 antes de asignar el valor

                    ListaIndicesClientesModificadas.Add(fila.Index)
                   
                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then                        
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)
                        fila.Cells("plan_" + Dia).Value = SumaFila
                    Else
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaFila
                        ProspectaDia.NumeroDia = fila.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)
                    End If

                End If


            End If

        Next


        If grid.Name = "gridPartidas" Then

            For Each FilaPedido As UltraGridRow In gridPedidos.Rows
                SumaParesPedido = 0
                If ListaPedidos.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("PSICY").Value) = True Then

                    ListaIndicesPedidosModificadas.Add(FilaPedido.Index)
                    

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then

                        For Each Lista As Entidades.ProspectaDias In ListaPedidos
                            If Lista.NumeroDia = FilaPedido.Cells("PSICY").Value Then
                                SumaParesPedido += Lista.Cantidad
                            End If
                        Next

                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaParesPedido
                        ProspectaDia.NumeroDia = FilaPedido.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)



                        FilaPedido.Cells("plan_" + Dia).Value = SumaParesPedido
                    Else
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaParesPedido
                        ProspectaDia.NumeroDia = FilaPedido.Cells("ClientesayId").Value
                        ListaClientes.Add(ProspectaDia)
                    End If

                End If

            Next



            For Each FilaPedido As UltraGridRow In gridListaProspecta.Rows

                SumaParesPedido = 0
                If ListaClientes.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("ClienteSayID").Value) = True Then

                    ListaIndicesClientesModificadas.Add(FilaPedido.Index)
                   

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                       

                        For Each Lista As Entidades.ProspectaDias In ListaClientes
                            If Lista.NumeroDia = FilaPedido.Cells("ClienteSayID").Value Then
                                SumaParesPedido += Lista.Cantidad
                            End If
                        Next

                        FilaPedido.Cells("plan_" + Dia).Value = SumaParesPedido
                    Else

                    End If

                End If

            Next



        End If


        If grid.Name = "gridPedidos" Then

            For Each FilaPedido As UltraGridRow In gridPartidas.Rows
                SumaParesPedido = 0
                If ListaPedidos.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("PSICY").Value) = True Then

                    ListaIndicesPartidasModificadas.Add(FilaPedido.Index)
                  

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                        FilaPedido.Cells("plan_" + Dia).Value = FilaPedido.Cells("actual_prog_suma").Value
                    End If

                End If

            Next


            For Each FilaPedido As UltraGridRow In gridListaProspecta.Rows

                SumaParesPedido = 0
                If ListaClientes.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("ClienteSayID").Value) = True Then

                    ListaIndicesClientesModificadas.Add(FilaPedido.Index)
                  

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then

                        For Each Lista As Entidades.ProspectaDias In ListaClientes
                            If Lista.NumeroDia = FilaPedido.Cells("ClienteSayID").Value Then
                                SumaParesPedido += Lista.Cantidad
                            End If
                        Next

                        FilaPedido.Cells("plan_" + Dia).Value = SumaParesPedido
                    End If

                End If

            Next

        End If


        If grid.Name = "gridListaProspecta" Then

            For Each FilaPedido As UltraGridRow In gridPedidos.Rows
                SumaParesPedido = 0
                If ListaClientes.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("ClientesayId").Value) = True Then

                    ListaIndicesPedidosModificadas.Add(FilaPedido.Index)
                   

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaParesPedido
                        ProspectaDia.NumeroDia = FilaPedido.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                        FilaPedido.Cells("plan_" + Dia).Value = FilaPedido.Cells("actual_prog_suma").Value
                    Else
                        ProspectaDia = New Entidades.ProspectaDias
                        ProspectaDia.Cantidad = SumaParesPedido
                        ProspectaDia.NumeroDia = FilaPedido.Cells("PSICY").Value
                        ListaPedidos.Add(ProspectaDia)
                    End If

                End If

            Next

            For Each FilaPedido As UltraGridRow In gridPartidas.Rows
                SumaParesPedido = 0
                If ListaPedidos.Exists(Function(x) x.NumeroDia = FilaPedido.Cells("PSICY").Value) = True Then

                    ListaIndicesPartidasModificadas.Add(FilaPedido.Index)
                   

                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
                            If FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
                                FilaPedido.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                            End If
                        End If
                    Next

                    If Dia <> "Limpiar" Then
                        FilaPedido.Cells("plan_" + Dia).Value = FilaPedido.Cells("actual_prog_suma").Value
                    End If

                End If

            Next



        End If


        'Dim SumaFila As Integer = 0
        'Dim SumaFilaTotal As Integer = 0
        'Dim ProspectaPorPedido As Boolean = False

        'Dim FilaSeleccionada As Boolean = False
        'For Each fila As UltraGridRow In grid.Rows

        '    If fila.Hidden = True Then
        '        Continue For
        '    End If

        '    If ComprobarBloqueo(fila) = True Then
        '        Continue For
        '    End If

        '    SumaFila = 0
        '    FilaSeleccionada = False

        '    If fila.Cells("PA").Value = "NO" Then
        '        If grid.Name = "gridListaProspecta" Then

        '            SumaFilaTotal = CInt(fila.Cells("actual_prog_IALM").Value) + CInt(fila.Cells("actual_prog_IPRO").Value) + CInt(fila.Cells("actual_prog_AXC").Value)
        '            For Each COL As UltraGridCell In fila.Cells
        '                If COL.Selected And (COL.Column.Key = "actual_prog_suma") Then

        '                    SumaFila = CInt(COL.Value)

        '                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '                        If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
        '                            If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
        '                                fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
        '                            End If
        '                        Else
        '                            fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
        '                        End If
        '                    Next



        '                    If Dia <> "Limpiar" Then
        '                        fila.Cells("plan_" + Dia).Value = SumaFila
        '                    End If

        '                End If
        '            Next

        '        End If


        '    Else
        '        SumaFilaTotal = CInt(fila.Cells("actual_prog_IALM").Value) + CInt(fila.Cells("actual_prog_IPRO").Value) + CInt(fila.Cells("actual_prog_AXC").Value)
        '        For Each COL As UltraGridCell In fila.Cells
        '            If COL.Selected And (COL.Column.Key = "actual_prog_suma") Then
        '                SumaFila = CInt(COL.Value)
        '                FilaSeleccionada = True

        '            End If
        '        Next

        '        If FilaSeleccionada = True Then

        '            For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '                If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
        '                    If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
        '                        fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
        '                    End If
        '                End If
        '            Next


        '            If Dia <> "Limpiar" Then
        '                fila.Cells("plan_" + Dia).Value = SumaFila
        '            End If

        '            'If grid.Name = "gridPartidas" Then
        '            '    ActualizarDistribucionParesPedidoPartida(fila.Cells("PSICY").Value, "plan_" + Dia)
        '            '    ActualizarDistribucionParesClientePedido(fila.Cells("ClienteSicyID").Value, "plan_" + Dia)
        '            'End If


        '            If grid.Name = "gridPedidos" Then
        '                ActualizarDistribucionParesPedidoPartida(fila.Cells("PSICY").Value, "plan_" + Dia)
        '            End If

        '            If grid.Name = "gridListaProspecta" Then
        '                ActualizarDistribucionParesClientePedido(fila.Cells("ClienteSicyID").Value, "plan_" + Dia)

        '            End If

        '        End If

        '    End If

        'Next

        'If grid.Name = "gridListaProspecta" Then
        '    ActualizarCantidadParesPedidoPartida()
        'End If

        'If grid.Name = "gridPedidos" Then
        '    ActualizarCantidadParesProspectaPedido()
        'End If

    End Sub









    'Private Sub DistribuirParesDiaPlaneacion(ByVal grid As UltraGrid, ByVal Dia As String)
    '    Dim SumaFila As Integer = 0
    '    Dim SumaFilaTotal As Integer = 0
    '    Dim ProspectaPorPedido As Boolean = False

    '    Dim FilaSeleccionada As Boolean = False
    '    For Each fila As UltraGridRow In grid.Rows

    '        If fila.Hidden = True Then
    '            Continue For
    '        End If

    '        If ComprobarBloqueo(fila) = True Then
    '            Continue For
    '        End If

    '        SumaFila = 0
    '        FilaSeleccionada = False

    '        If fila.Cells("PA").Value = "NO" Then

    '            SumaFilaTotal = CInt(fila.Cells("actual_prog_IALM").Value) + CInt(fila.Cells("actual_prog_IPRO").Value) + CInt(fila.Cells("actual_prog_AXC").Value)
    '            For Each COL As UltraGridCell In fila.Cells
    '                If COL.Selected And (COL.Column.Key = "actual_prog_IALM" Or COL.Column.Key = "actual_prog_IPRO" Or COL.Column.Key = "actual_prog_AXC" Or COL.Column.Key = "actual_prog_suma") Then

    '                    If COL.Column.Key = "actual_prog_suma" Then
    '                        SumaFila = CInt(COL.Value)
    '                    Else
    '                        If grid.Name = "gridListaProspecta" Then
    '                            If COL.Column.Key = "actual_prog_IALM" Then
    '                                If chksumaIALMClientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                            If COL.Column.Key = "actual_prog_IPRO" Then
    '                                If chksumaIPROclientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If

    '                            If COL.Column.Key = "actual_prog_AXC" Then
    '                                If chksumaAXCClientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                        End If
    '                    End If

    '                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
    '                        If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
    '                            If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
    '                                fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
    '                            End If
    '                        Else
    '                            fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
    '                        End If
    '                    Next



    '                    If Dia <> "Limpiar" Then
    '                        fila.Cells("plan_" + Dia).Value = SumaFila
    '                    End If

    '                End If
    '            Next
    '        Else
    '            SumaFilaTotal = CInt(fila.Cells("actual_prog_IALM").Value) + CInt(fila.Cells("actual_prog_IPRO").Value) + CInt(fila.Cells("actual_prog_AXC").Value)
    '            For Each COL As UltraGridCell In fila.Cells
    '                If COL.Selected And (COL.Column.Key = "actual_prog_IALM" Or COL.Column.Key = "actual_prog_IPRO" Or COL.Column.Key = "actual_prog_AXC" Or COL.Column.Key = "actual_prog_suma") Then
    '                    If COL.Column.Key = "actual_prog_suma" Then
    '                        SumaFila = CInt(COL.Value)
    '                        FilaSeleccionada = True
    '                    Else
    '                        If grid.Name = "gridListaProspecta" Then
    '                            If COL.Column.Key = "actual_prog_IALM" Then
    '                                If chksumaIALMClientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                            If COL.Column.Key = "actual_prog_IPRO" Then
    '                                If chksumaIPROclientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If

    '                            If COL.Column.Key = "actual_prog_AXC" Then
    '                                If chksumaAXCClientes.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                        End If

    '                        If grid.Name = "gridPedidos" Then
    '                            If COL.Column.Key = "actual_prog_IALM" Then
    '                                If chksumaIALMPedidos.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                            If COL.Column.Key = "actual_prog_IPRO" Then
    '                                If chksumaIPROPedidos.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If

    '                            If COL.Column.Key = "actual_prog_AXC" Then
    '                                If chksumaAXCPedidos.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                        End If

    '                        If grid.Name = "gridPartidas" Then
    '                            If COL.Column.Key = "actual_prog_IALM" Then
    '                                If chksumaIALMPartidas.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                            If COL.Column.Key = "actual_prog_IPRO" Then
    '                                If chksumaIPROPartidas.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If

    '                            If COL.Column.Key = "actual_prog_AXC" Then
    '                                If chksumaAXCPartidas.Checked = True Then
    '                                    SumaFila += CInt(COL.Value)
    '                                    FilaSeleccionada = True
    '                                End If
    '                            End If
    '                        End If
    '                    End If

    '                End If
    '            Next

    '            If FilaSeleccionada = True Then

    '                For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
    '                    If IsDBNull(fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value) = False Then
    '                        If fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value <> 0 Then
    '                            fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
    '                        End If
    '                    End If
    '                Next


    '                If Dia <> "Limpiar" Then
    '                    fila.Cells("plan_" + Dia).Value = SumaFila
    '                End If


    '                If grid.Name = "gridPedidos" Then
    '                    ActualizarDistribucionParesPedidoPartida(fila.Cells("PSICY").Value, "plan_" + Dia)
    '                End If

    '                If grid.Name = "gridListaProspecta" Then
    '                    ActualizarDistribucionParesClientePedido(fila.Cells("ClienteSicyID").Value, "plan_" + Dia)

    '                End If

    '            End If

    '        End If

    '    Next

    '    If grid.Name = "gridListaProspecta" Then
    '        ActualizarCantidadParesPedidoPartida()
    '    End If

    '    If grid.Name = "gridPedidos" Then
    '        ActualizarCantidadParesProspectaPedido()
    '    End If

    'End Sub

    Private Sub Martes_Click(sender As Object, e As EventArgs) Handles Martes.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If


        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Mar")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Mar")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Mar")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Miercoles_Click(sender As Object, e As EventArgs) Handles Miercoles.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If


        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Mie")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Mie")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Mie")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Jueves_Click(sender As Object, e As EventArgs) Handles Jueves.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If


        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Jue")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Jue")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Jue")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Viernes_Click(sender As Object, e As EventArgs) Handles Viernes.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If


        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Vie")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Vie")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Vie")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Sabado_Click(sender As Object, e As EventArgs) Handles Sabado.Click
        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If

        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, "Sab")
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, "Sab")
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, "Sab")
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub gridPedidos_MouseClick(sender As Object, e As MouseEventArgs) Handles gridPedidos.MouseClick
        If ModoEdicion = True And MostrarMenuContextual = True Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip1.Items(0).Visible = True
                ContextMenuStrip1.Items(1).Visible = True
                ContextMenuStrip1.Items(2).Visible = True

                ContextMenuStrip1.Show(Control.MousePosition)
            End If
        End If
        'If ModoEdicion = True And MostrarMenuContextual = True Then
    End Sub


    Private Sub gridPartidas_MouseClick(sender As Object, e As MouseEventArgs) Handles gridPartidas.MouseClick
        If ModoEdicion = True And MostrarMenuContextual = True Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip1.Items(0).Visible = True
                ContextMenuStrip1.Items(1).Visible = True
                ContextMenuStrip1.Items(2).Visible = True
                ContextMenuStrip1.Show(Control.MousePosition)
            End If
        End If

    End Sub


    Private Sub ActualizarCantidadParesPedidoPartidaGuardados(ByVal ListaPedidosCompletos As List(Of Integer))
        Dim SumaFila As Integer = 0
        Dim SumaPedidoLunes As Integer = 0
        Dim SumaPedidoMartes As Integer = 0
        Dim SumaPedidoMiercoles As Integer = 0
        Dim SumaPedidoJueves As Integer = 0
        Dim SumaPedidoViernes As Integer = 0
        Dim SumaPedidoSabado As Integer = 0
        Dim FilaProsp As UltraGridRow
        Dim FilaPart As UltraGridRow

        Dim DataSetPartidas As DataTable
        DataSetPartidas = gridPartidas.DataSource
        Dim RowsPartidas As DataRow()


        For Each indice As Integer In ListaIndicesPedidosModificadas
            FilaProsp = gridPedidos.Rows(indice)

            SumaFila = 0
            SumaPedidoLunes = 0
            SumaPedidoMartes = 0
            SumaPedidoMiercoles = 0
            SumaPedidoJueves = 0
            SumaPedidoViernes = 0
            SumaPedidoSabado = 0

            If ListaPedidosCompletos.Exists(Function(x) x = FilaProsp.Cells("PSICY").Value) = True Then
                'Inbincialicar la cantidad de pares a 0
                For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                    DiasPlaneacion.Cantidad = 0
                Next


                If FilaProsp.IsFilteredOut = True Or FilaProsp.Hidden = True Then
                    Continue For
                End If


                If FilaProsp.IsFilteredOut = True Or FilaProsp.Hidden = True Or FilaProsp.Cells(" ").Value = False Then
                    Continue For
                End If


                RowsPartidas = DataSetPartidas.Select("PSICY = " + FilaProsp.Cells("PSICY").Value.ToString() + "")


                For Each RowsPart As DataRow In RowsPartidas
                    For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If RowsPart.Item("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).ToString <> "" Then
                            DiasPlaneacion.Cantidad += CInt(RowsPart.Item("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).ToString)
                        End If
                    Next
                Next

                  



                    'For Each indicePArtida As Integer In ListaIndicesPartidasModificadas
                    '    FilaPart = gridPartidas.Rows(indicePArtida)
                    '    If FilaProsp.Cells("PSICY").Value = FilaPart.Cells("PSICY").Value Then

                    '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                    '            If IsDBNull(FilaPart.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value) = False Then
                    '                DiasPlaneacion.Cantidad += CInt(FilaPart.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value)
                    '            End If
                    '        Next

                    '    End If

                    'Next

                    'For Each FilaPartida As UltraGridRow In gridPartidas.Rows
                    '    If FilaPartida.Hidden = True Then
                    '        Continue For
                    '    End If

                    '    If FilaProsp.Cells("PSICY").Value = FilaPartida.Cells("PSICY").Value Then
                    '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                    '            If IsDBNull(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value) = False Then
                    '                DiasPlaneacion.Cantidad += CInt(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value)
                    '            End If
                    '        Next

                    '    End If
                    'Next




                    For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        SumaFila += DiasPlaneacion.Cantidad
                    Next

                    'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado


                    For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta

                        If DiasPlaneacion.Cantidad <> 0 Then
                            FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = DiasPlaneacion.Cantidad
                            FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
                        Else
                            If SumaFila <> 0 Then
                                FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = 0
                                FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
                        Else
                            FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = 0
                            FilaProsp.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.AllowEdit
                            End If
                        End If
                    Next
            End If



        Next

        dtDatosPedidos = gridPedidos.DataSource
        dtDatosPartidas = gridPartidas.DataSource

        'For Each FilaPedido As UltraGridRow In gridPedidos.Rows
        '    SumaFila = 0
        '    SumaPedidoLunes = 0
        '    SumaPedidoMartes = 0
        '    SumaPedidoMiercoles = 0
        '    SumaPedidoJueves = 0
        '    SumaPedidoViernes = 0
        '    SumaPedidoSabado = 0

        '    If ListaPedidosCompletos.Exists(Function(x) x = FilaPedido.Cells("PSICY").Value) = True Then
        '        'Inbincialicar la cantidad de pares a 0
        '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '            DiasPlaneacion.Cantidad = 0
        '        Next


        '        If FilaPedido.IsFilteredOut = True Or FilaPedido.Hidden = True Then
        '            Continue For
        '        End If


        '        If FilaPedido.IsFilteredOut = True Or FilaPedido.Hidden = True Or FilaPedido.Cells(" ").Value = False Then
        '            Continue For
        '        End If

        '        For Each FilaPartida As UltraGridRow In gridPartidas.Rows
        '            If FilaPartida.Hidden = True Then
        '                Continue For
        '            End If

        '            If FilaPedido.Cells("PSICY").Value = FilaPartida.Cells("PSICY").Value Then
        '                For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '                    If IsDBNull(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value) = False Then
        '                        DiasPlaneacion.Cantidad += CInt(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value)
        '                    End If
        '                Next

        '            End If
        '        Next

        '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '            SumaFila += DiasPlaneacion.Cantidad
        '        Next

        '        'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado


        '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta

        '            If DiasPlaneacion.Cantidad <> 0 Then
        '                FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = DiasPlaneacion.Cantidad
        '                FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
        '            Else
        '                If SumaFila <> 0 Then
        '                    FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = 0
        '                    FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
        '                Else
        '                    FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.AllowEdit
        '                End If
        '            End If
        '        Next
        '    End If



        'Next

        'dtDatosPedidos = gridPedidos.DataSource
        'dtDatosPartidas = gridPartidas.DataSource
    End Sub


    Private Sub ActualizarCantidadParesPedidoPartida()
        Dim SumaFila As Integer = 0
        Dim SumaPedidoLunes As Integer = 0
        Dim SumaPedidoMartes As Integer = 0
        Dim SumaPedidoMiercoles As Integer = 0
        Dim SumaPedidoJueves As Integer = 0
        Dim SumaPedidoViernes As Integer = 0
        Dim SumaPedidoSabado As Integer = 0

        'If row.IsFilteredOut = False Then
        '    If row.Cells(" ").Value = True And row.Hidden = False Then
        '        filtro.Add(CInt(row.Cells("PSICY").Text))
        '    End If
        'End If



        For Each FilaPedido As UltraGridRow In gridPedidos.Rows
            SumaFila = 0
            SumaPedidoLunes = 0
            SumaPedidoMartes = 0
            SumaPedidoMiercoles = 0
            SumaPedidoJueves = 0
            SumaPedidoViernes = 0
            SumaPedidoSabado = 0
            'Inbincialicar la cantidad de pares a 0
            For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                DiasPlaneacion.Cantidad = 0
            Next


            If FilaPedido.IsFilteredOut = True Or FilaPedido.Hidden = True Then
                Continue For
            End If


            If FilaPedido.IsFilteredOut = True Or FilaPedido.Hidden = True Or FilaPedido.Cells(" ").Value = False Then
                Continue For
            End If

            For Each FilaPartida As UltraGridRow In gridPartidas.Rows
                If FilaPartida.Hidden = True Then
                    Continue For
                End If

                If FilaPedido.Cells("PSICY").Value = FilaPartida.Cells("PSICY").Value Then
                    For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value) = False Then
                            DiasPlaneacion.Cantidad += CInt(FilaPartida.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value)
                        End If
                    Next

                End If
            Next

            For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                SumaFila += DiasPlaneacion.Cantidad
            Next

            'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado


            For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta

                If DiasPlaneacion.Cantidad <> 0 Then
                    FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = DiasPlaneacion.Cantidad
                    FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
                Else
                    If SumaFila <> 0 Then
                        FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Value = 0
                        FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.NoEdit
                    Else
                        FilaPedido.Cells("plan_" + DiasPlaneacion.NombreDia + DiasPlaneacion.NumeroDia.ToString()).Activation = Activation.AllowEdit
                    End If
                End If
            Next

        Next

        dtDatosPedidos = gridPedidos.DataSource
        dtDatosPartidas = gridPartidas.DataSource
    End Sub

    Private Sub ActualizarCantidadParesProspectaPedidoGuardados(ByVal ListaClientes As List(Of Integer))
        Dim SumaFila As Integer = 0
        Dim SumaPedidoLunes As Integer = 0
        Dim SumaPedidoMartes As Integer = 0
        Dim SumaPedidoMiercoles As Integer = 0
        Dim SumaPedidoJueves As Integer = 0
        Dim SumaPedidoViernes As Integer = 0
        Dim SumaPedidoSabado As Integer = 0
        Dim FilaProsp As UltraGridRow
        Dim FilaPEd As UltraGridRow

        Dim FilaPart As UltraGridRow

        Dim DataSetPedidos As DataTable
        DataSetPedidos = gridPedidos.DataSource
        Dim RowsPartidas As DataRow()
     

        For Each indice As Integer In ListaIndicesClientesModificadas
            FilaProsp = gridListaProspecta.Rows(indice)
            SumaFila = 0
            SumaPedidoLunes = 0
            SumaPedidoMartes = 0
            SumaPedidoMiercoles = 0
            SumaPedidoJueves = 0
            SumaPedidoViernes = 0
            SumaPedidoSabado = 0

            If ListaClientes.Exists(Function(x) x = FilaProsp.Cells("ClienteSayID").Value) = True Then
                'Inbincialicar la cantidad de pares a 0
                For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                    DiasPlaneacion.Cantidad = 0
                Next


                If FilaProsp.IsFilteredOut = True Or FilaProsp.Hidden = True Or FilaProsp.Cells(" ").Value = False Then
                    Continue For
                End If

                'For Each indicePEdido As Integer In ListaIndicesPedidosModificadas
                '    FilaPEd = gridPedidos.Rows(indicePEdido)
                '    If ListaClientes.Exists(Function(x) x = FilaPEd.Cells("ClientesayId").Value) = True Then
                '        For Each Dia As Entidades.ProspectaDias In DiasProspecta
                '            If IsDBNull(FilaPEd.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
                '                Dia.Cantidad += CInt(FilaPEd.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
                '            End If
                '        Next
                '    End If
                'Next


                RowsPartidas = DataSetPedidos.Select("ClientesayId = " + FilaProsp.Cells("ClienteSayID").Value.ToString() + "")


                For Each RowsPart As DataRow In RowsPartidas
                    If ListaClientes.Exists(Function(x) x = RowsPart.Item("ClientesayId").ToString()) = True Then
                        For Each Dia As Entidades.ProspectaDias In DiasProspecta
                            If RowsPart.Item("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).ToString() <> "" Then
                                Dia.Cantidad += CInt(RowsPart.Item("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).ToString())
                            End If
                        Next
                    End If
                Next

                'For Each FilaPedido As UltraGridRow In gridPedidos.Rows
                '    If ListaClientes.Exists(Function(x) x = FilaPedido.Cells("ClientesayId").Value) = True Then
                '        For Each Dia As Entidades.ProspectaDias In DiasProspecta
                '            If IsDBNull(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
                '                Dia.Cantidad += CInt(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
                '            End If
                '        Next
                '    End If

                'Next



                'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado
                For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                    SumaFila += DiasPlaneacion.Cantidad
                Next


                For Each Dia As Entidades.ProspectaDias In DiasProspecta
                    If Dia.Cantidad <> 0 Then
                        FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = Dia.Cantidad
                        FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                    Else
                        If SumaFila <> 0 Then
                            FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = 0
                            FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                        Else
                            FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = 0
                            FilaProsp.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
                        End If
                    End If
                Next
            End If


        Next



        '-------------******************************
        'For Each FilaPospecta As UltraGridRow In gridListaProspecta.Rows
        '    SumaFila = 0
        '    SumaPedidoLunes = 0
        '    SumaPedidoMartes = 0
        '    SumaPedidoMiercoles = 0
        '    SumaPedidoJueves = 0
        '    SumaPedidoViernes = 0
        '    SumaPedidoSabado = 0

        '    If ListaClientes.Exists(Function(x) x = FilaPospecta.Cells("ClienteSayID").Value) = True Then
        '        'Inbincialicar la cantidad de pares a 0
        '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '            DiasPlaneacion.Cantidad = 0
        '        Next


        '        If FilaPospecta.IsFilteredOut = True Or FilaPospecta.Hidden = True Or FilaPospecta.Cells(" ").Value = False Then
        '            Continue For
        '        End If

        '        For Each FilaPedido As UltraGridRow In gridPedidos.Rows
        '            If ListaClientes.Exists(Function(x) x = FilaPedido.Cells("clienteid").Value) = True Then
        '                For Each Dia As Entidades.ProspectaDias In DiasProspecta
        '                    If IsDBNull(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
        '                        Dia.Cantidad += CInt(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
        '                    End If
        '                Next
        '            End If                

        '        Next

        '        'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado
        '        For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
        '            SumaFila += DiasPlaneacion.Cantidad
        '        Next


        '        For Each Dia As Entidades.ProspectaDias In DiasProspecta
        '            If Dia.Cantidad <> 0 Then
        '                FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = Dia.Cantidad
        '                FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
        '            Else
        '                If SumaFila <> 0 Then
        '                    FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = 0
        '                    FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
        '                Else
        '                    FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
        '                End If
        '            End If
        '        Next
        '    End If
        'Next




    End Sub


    Private Sub ActualizarCantidadParesProspectaPedido()
        Dim SumaFila As Integer = 0
        Dim SumaPedidoLunes As Integer = 0
        Dim SumaPedidoMartes As Integer = 0
        Dim SumaPedidoMiercoles As Integer = 0
        Dim SumaPedidoJueves As Integer = 0
        Dim SumaPedidoViernes As Integer = 0
        Dim SumaPedidoSabado As Integer = 0


        For Each FilaPospecta As UltraGridRow In gridListaProspecta.Rows
            SumaFila = 0
            SumaPedidoLunes = 0
            SumaPedidoMartes = 0
            SumaPedidoMiercoles = 0
            SumaPedidoJueves = 0
            SumaPedidoViernes = 0
            SumaPedidoSabado = 0

            'Inbincialicar la cantidad de pares a 0
            For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                DiasPlaneacion.Cantidad = 0
            Next


            If FilaPospecta.IsFilteredOut = True Or FilaPospecta.Hidden = True Or FilaPospecta.Cells(" ").Value = False Then
                Continue For
            End If

            For Each FilaPedido As UltraGridRow In gridPedidos.Rows

                If FilaPedido.Hidden = True Then
                    Continue For
                End If

                If (FilaPospecta.Cells("ClienteSicyID").Value = FilaPedido.Cells("clienteid").Value) Then

                    For Each Dia As Entidades.ProspectaDias In DiasProspecta
                        If IsDBNull(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value) = False Then
                            Dia.Cantidad += CInt(FilaPedido.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value)
                        End If
                    Next

                End If

            Next

            'SumaFila = SumaPedidoLunes + SumaPedidoMartes + SumaPedidoMiercoles + SumaPedidoJueves + SumaPedidoViernes + SumaPedidoSabado
            For Each DiasPlaneacion As Entidades.ProspectaDias In DiasProspecta
                SumaFila += DiasPlaneacion.Cantidad
            Next


            For Each Dia As Entidades.ProspectaDias In DiasProspecta
                If Dia.Cantidad <> 0 Then
                    FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = Dia.Cantidad
                    FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                Else
                    If SumaFila <> 0 Then
                        FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Value = 0
                        FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                    Else
                        FilaPospecta.Cells("plan_" + Dia.NombreDia + Dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
                    End If
                End If
            Next


        Next

    End Sub

    Private Function ComprobarBloqueo(ByVal fila As UltraGridRow) As Boolean
        'If fila.Cells("plan_Lun").Activation = Activation.NoEdit Then
        '    Return True
        'Else
        '    Return False
        'End If
        Return False
    End Function


    Private Sub chksumaIALMClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIALMClientes.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        'Actualizar el cambio para los tres niveles
        chksumaIALMPedidos.Checked = chksumaIALMClientes.Checked
        chksumaIALMPartidas.Checked = chksumaIALMClientes.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)

    End Sub

    Private Sub chksumaIPROclientes_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIPROclientes.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        chksumaIPROPartidas.Checked = chksumaIPROclientes.Checked
        chksumaIPROPedidos.Checked = chksumaIPROclientes.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)
    End Sub

    Private Sub chksumaAXCClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaAXCClientes.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        chksumaAXCPartidas.Checked = chksumaAXCClientes.Checked
        chksumaAXCPedidos.Checked = chksumaAXCClientes.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)

    End Sub

    Private Sub SumarColumnas_IALM_IPRO_AXC(ByVal grid As UltraGrid)
        Dim TotalFila As Integer = 0
        Dim FILAS As Integer = grid.Rows.Count

        For Each row As UltraGridRow In grid.Rows
            TotalFila = 0
            If row.Hidden = True Then
                Continue For
            End If

            If grid.Name = "gridListaProspecta" Then

                If chksumaIALMClientes.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IALM").Value)
                End If
                If chksumaIPROclientes.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IPRO").Value)
                End If
                If chksumaAXCClientes.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_AXC").Value)
                End If
                row.Cells("actual_prog_suma").Value = TotalFila

            ElseIf grid.Name = "gridPedidos" Then

                If chksumaIALMPedidos.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IALM").Value)
                End If
                If chksumaIPROPedidos.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IPRO").Value)
                End If
                If chksumaAXCPedidos.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_AXC").Value)
                End If
                row.Cells("actual_prog_suma").Value = TotalFila

            ElseIf grid.Name = "gridPartidas" Then
                If chksumaIALMPartidas.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IALM").Value)
                End If
                If chksumaIPROPartidas.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_IPRO").Value)
                End If
                If chksumaAXCPartidas.Checked = True Then
                    TotalFila += CInt(row.Cells("actual_prog_AXC").Value)
                End If
                row.Cells("actual_prog_suma").Value = TotalFila
            End If
        Next
    End Sub

    'ActualizarDistribucionParesPedidoPartida
    'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
    'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
    'SumarColumnas_IALM_IPRO_AXC(gridPartidas)

    Private Sub chksumaIALMPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIALMPedidos.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)

        chksumaIALMClientes.Checked = chksumaIALMPedidos.Checked
        chksumaIALMPartidas.Checked = chksumaIALMPedidos.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)


    End Sub

    Private Sub chksumaIPROPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIPROPedidos.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        chksumaIPROPartidas.Checked = chksumaIPROPedidos.Checked
        chksumaIPROclientes.Checked = chksumaIPROPedidos.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)
    End Sub

    Private Sub chksumaAXCPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaAXCPedidos.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)

        chksumaAXCClientes.Checked = chksumaAXCPedidos.Checked
        chksumaAXCPartidas.Checked = chksumaAXCPedidos.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)
    End Sub


    Private Sub chksumaIALMPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIALMPartidas.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)

        chksumaIALMClientes.Checked = chksumaIALMPartidas.Checked
        chksumaIALMPedidos.Checked = chksumaIALMPartidas.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        SumarColumnas_IALM_IPRO_AXC(gridPartidas)
        SumarColumnas_IALM_IPRO_AXC(gridPedidos)
    End Sub

    Private Sub chksumaIPROPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaIPROPartidas.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)


        chksumaIPROclientes.Checked = chksumaIPROPartidas.Checked
        chksumaIPROPedidos.Checked = chksumaIPROPartidas.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        SumarColumnas_IALM_IPRO_AXC(gridPartidas)
        SumarColumnas_IALM_IPRO_AXC(gridPedidos)
    End Sub

    Private Sub chksumaAXCPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chksumaAXCPartidas.CheckedChanged
        'SumarColumnas_IALM_IPRO_AXC(gridPartidas)

        chksumaAXCClientes.Checked = chksumaAXCPartidas.Checked
        chksumaAXCPedidos.Checked = chksumaAXCPartidas.Checked

        'SumarColumnas_IALM_IPRO_AXC(gridPedidos)
        'SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)

        SumarColumnas_IALM_IPRO_AXC(gridListaProspecta)
        SumarColumnas_IALM_IPRO_AXC(gridPartidas)
        SumarColumnas_IALM_IPRO_AXC(gridPedidos)

    End Sub

    Private Sub ActualizarDistribucionParesPedidoPartida(ByVal Pedido As Integer, ByVal Dia As String)
        Dim PedidoSicyID As Integer = 0
        Dim SumaPartida As Integer = 0
        Dim NumweoFilas As Int32 = gridPartidas.Rows.Count

        For Each FilaPedidos As UltraGridRow In gridPedidos.Rows
            If FilaPedidos.Hidden = False Then
                PedidoSicyID = CInt(FilaPedidos.Cells("PSICY").Value)
                If PedidoSicyID = Pedido Then
                    For Each FilaPartidas As UltraGridRow In gridPartidas.Rows
                        SumaPartida = 0
                        If PedidoSicyID = CInt(FilaPartidas.Cells("PSICY").Value) Then
                            If FilaPedidos.Cells("actual_prog_suma").Selected Then

                                For Each DiaP As Entidades.ProspectaDias In DiasProspecta
                                    FilaPartidas.Cells("plan_" + DiaP.NombreDia + DiaP.NumeroDia.ToString()).Value = 0
                                Next

                                SumaPartida += CInt(FilaPartidas.Cells("actual_prog_suma").Value)

                                'If chksumaIALMPedidos.Checked = True Then
                                '    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IALM").Value)
                                'End If

                                'If chksumaIPROPedidos.Checked = True Then
                                '    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
                                'End If

                                'If chksumaAXCPedidos.Checked = True Then
                                '    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
                                'End If



                                If Dia <> "plan_Limpiar" Then
                                    FilaPartidas.Cells(Dia).Value = SumaPartida
                                End If



                                'Evaluar los tres casos ialm ,ipro, axc
                            Else
                                If FilaPedidos.Cells("actual_prog_suma").Selected Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_suma").Value)
                                End If

                                'If FilaPedidos.Cells("actual_prog_IPRO").Selected Then
                                '    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
                                'End If

                                'If FilaPedidos.Cells("actual_prog_AXC").Selected Then
                                '    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
                                'End If

                                For Each DiaP As Entidades.ProspectaDias In DiasProspecta
                                    FilaPartidas.Cells("plan_" + DiaP.NombreDia + DiaP.NumeroDia.ToString()).Value = 0
                                Next

                               


                                If Dia <> "plan_Limpiar" Then
                                    FilaPartidas.Cells(Dia).Value = SumaPartida
                                End If


                            End If
                        End If
                    Next
                End If
            End If
        Next





    End Sub


    Private Sub ActualizarDistribucionParesClientePedido(ByVal ClienteSicyID As Integer, ByVal Dia As String)

        Dim ClienteSicy As Integer = 0
        Dim SumaPartida As Integer = 0
        Dim NumweoFilas As Int32 = gridPartidas.Rows.Count
        NumweoFilas = gridPedidos.Rows.Count
        For Each FilaPedidos As UltraGridRow In gridListaProspecta.Rows
            If FilaPedidos.Hidden = False Then
                ClienteSicy = CInt(FilaPedidos.Cells("ClientesicyId").Value)

                If ClienteSicy = ClienteSicyID Then
                    For Each FilaPartidas As UltraGridRow In gridPartidas.Rows
                        SumaPartida = 0

                        If ClienteSicy = CInt(FilaPartidas.Cells("ClientesicyId").Value) Then
                            If FilaPedidos.Cells("actual_prog_suma").Selected Then

                                For Each DiaP As Entidades.ProspectaDias In DiasProspecta
                                    FilaPartidas.Cells("plan_" + DiaP.NombreDia + DiaP.NumeroDia.ToString()).Value = 0
                                Next


                                If chksumaIALMPedidos.Checked = True Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IALM").Value)
                                End If

                                If chksumaIPROPedidos.Checked = True Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
                                End If

                                If chksumaAXCPedidos.Checked = True Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
                                End If



                                If Dia <> "plan_Limpiar" Then
                                    FilaPartidas.Cells(Dia).Value = SumaPartida
                                End If



                                'Evaluar los tres casos ialm ,ipro, axc
                            Else
                                If FilaPedidos.Cells("actual_prog_IALM").Selected Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IALM").Value)
                                End If

                                If FilaPedidos.Cells("actual_prog_IPRO").Selected Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
                                End If

                                If FilaPedidos.Cells("actual_prog_AXC").Selected Then
                                    SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
                                End If

                                For Each DiaP As Entidades.ProspectaDias In DiasProspecta
                                    FilaPartidas.Cells("plan_" + DiaP.NombreDia + DiaP.NumeroDia.ToString()).Value = 0
                                Next


                                'Pone el total de los pares en  un dia determninado
                                If Dia <> "plan_Limpiar" Then
                                    FilaPartidas.Cells(Dia).Value = SumaPartida
                                End If


                            End If
                        End If
                    Next
                End If
            End If
        Next


        'If IsNothing(gridPartidas.DataSource) = False Then
        '    ActualizarCantidadParesPedidoPartida()
        'End If

        'If IsNothing(gridPedidos.DataSource) = False Then
        '    ActualizarCantidadParesProspectaPedido()
        'End If



        'Dim ClienteSicy As Integer = 0
        'Dim SumaPartida As Integer = 0
        'For Each FilaPedidos As UltraGridRow In gridListaProspecta.Rows
        '    If FilaPedidos.Hidden = False Then
        '        ClienteSicy = CInt(FilaPedidos.Cells("ClienteSicyID").Value)
        '        If ClienteSicy = ClienteSicyID Then
        '            For Each FilaPartidas As UltraGridRow In gridPedidos.Rows
        '                SumaPartida = 0
        '                If ClienteSicy = CInt(FilaPartidas.Cells("clienteid").Value) Then
        '                    If FilaPedidos.Cells("actual_prog_suma").Selected Then
        '                        FilaPartidas.Cells("plan_Lun").Value = 0
        '                        FilaPartidas.Cells("plan_Mar").Value = 0
        '                        FilaPartidas.Cells("plan_Mie").Value = 0
        '                        FilaPartidas.Cells("plan_Jue").Value = 0
        '                        FilaPartidas.Cells("plan_Vie").Value = 0
        '                        FilaPartidas.Cells("plan_Sab").Value = 0

        '                        If chksumaIALMPedidos.Checked = True Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IALM").Value)
        '                        End If

        '                        If chksumaIPROPedidos.Checked = True Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
        '                        End If

        '                        If chksumaAXCPedidos.Checked = True Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
        '                        End If

        '                        FilaPartidas.Cells(Dia).Value = SumaPartida


        '                        'Evaluar los tres casos ialm ,ipro, axc
        '                    Else
        '                        If FilaPedidos.Cells("actual_prog_IALM").Selected Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IALM").Value)
        '                        End If

        '                        If FilaPedidos.Cells("actual_prog_IPRO").Selected Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_IPRO").Value)
        '                        End If

        '                        If FilaPedidos.Cells("actual_prog_AXC").Selected Then
        '                            SumaPartida += CInt(FilaPartidas.Cells("actual_prog_AXC").Value)
        '                        End If

        '                        'Poner los demas dias a 0
        '                        FilaPartidas.Cells("plan_Lun").Value = 0
        '                        FilaPartidas.Cells("plan_Mar").Value = 0
        '                        FilaPartidas.Cells("plan_Mie").Value = 0
        '                        FilaPartidas.Cells("plan_Jue").Value = 0
        '                        FilaPartidas.Cells("plan_Vie").Value = 0
        '                        FilaPartidas.Cells("plan_Sab").Value = 0

        '                        'Pone el total de los pares en  un dia determninado
        '                        FilaPartidas.Cells(Dia).Value = SumaPartida


        '                        'AgregarColumna(gridListaProspecta, "Prs Prosp", "Total Prs Prospecta", False, False, ColorInfoMedicion, 90, True)

        '                    End If

        '                    'ActualizarDistribucionParesPedidoPartida(FilaPartidas.Cells("PSICY").Value, Dia)
        '                End If
        '            Next
        '        End If
        '    End If
        'Next
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Este botón abrirá el PDF de guía de interpretación de la información de esta pantalla que elaborará Ventas")
    End Sub


    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 2

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroClientes.DataSource = listado.listParametros
        With grdFiltroClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True
        'grdFiltroClientes.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(3).Hidden = True
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(5).Hidden = True
        'FiltrarInformacion()
    End Sub

    Private Sub grdFiltroClientes_AfterRowsDeleted(sender As Object, e As EventArgs) Handles grdFiltroClientes.AfterRowsDeleted
        'FiltrarInformacion()
    End Sub

    Private Sub grdFiltroClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroClientes.InitializeLayout
        grid_diseño(grdFiltroClientes)
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub dtmFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtmFechaInicio.ValueChanged
        ObtenerNumeroSemana()
    End Sub

    Private Sub chkSeleccionarTodoClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoClientes.CheckedChanged
        SeleccionarTodoGrid(gridListaProspecta, chkSeleccionarTodoClientes.Checked)
    End Sub

    Private Sub SeleccionarTodoGrid(ByVal grid As UltraGrid, ByVal Seleccionar As Boolean)
        For Each Fila As UltraGridRow In grid.Rows
            If Fila.Hidden = False Then
                Fila.Cells(" ").Value = Seleccionar
            End If
        Next
    End Sub

    Private Sub chkSeleccionarTodoPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoPedidos.CheckedChanged
        SeleccionarTodoGrid(gridPedidos, chkSeleccionarTodoPedidos.Checked)
    End Sub

    Private Sub chkSeleccionarTodoPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoPartidas.CheckedChanged
        SeleccionarTodoGrid(gridPartidas, chkSeleccionarTodoPartidas.Checked)
    End Sub


    Private Sub ObtenerColumnasDinamicas()
        Dim FechaInicio As Date = dtmFechaInicio.Value
        Dim FechaFinal As Date = dtmFechaFin.Value
        Dim DiaSemana As Int32 = 0

        'DiasProspecta}
        Dim Dia As Entidades.ProspectaDias
        While FechaInicio <= FechaFinal
            Dia = New Entidades.ProspectaDias
            DiaSemana = FechaInicio.DayOfWeek()
            Dia.Dia = FechaInicio
            Dia.NumeroDia = FechaInicio.Day
            Select Case DiaSemana
                Case 1
                    Dia.NombreDia = "lun"
                Case 2
                    Dia.NombreDia = "mar"
                Case 3
                    Dia.NombreDia = "mie"
                Case 4
                    Dia.NombreDia = "jue"
                Case 5
                    Dia.NombreDia = "vie"
                Case 6
                    Dia.NombreDia = "sab"
                Case 0
                    Dia.NombreDia = "dom"
            End Select
            DiasProspecta.Add(Dia)
            FechaInicio = FechaInicio.AddDays(1)
        End While


        'If ProspectaID = -1 Then

        '    While FechaInicio <= FechaFinal

        '        Dia = New Entidades.ProspectaDias
        '        DiaSemana = FechaInicio.DayOfWeek()
        '        Dia.Dia = FechaInicio
        '        Dia.NumeroDia = FechaInicio.Day

        '        Select Case DiaSemana

        '            Case 1
        '                Dia.NombreDia = "lun"
        '            Case 2
        '                Dia.NombreDia = "mar"
        '            Case 3
        '                Dia.NombreDia = "mie"
        '            Case 4
        '                Dia.NombreDia = "jue"
        '            Case 5
        '                Dia.NombreDia = "vie"
        '            Case 6
        '                Dia.NombreDia = "sab"
        '            Case 0
        '                Dia.NombreDia = "dom"
        '        End Select
        '        DiasProspecta.Add(Dia)

        '        FechaInicio = FechaInicio.AddDays(1)

        '    End While
        'Else

        'End If
    End Sub


    Public Sub DiseñarMenuContextual()
        Dim tooltip As ToolStripItem
        ContextMenuStrip1.Items.Clear()
        tooltip = ContextMenuStrip1.Items.Add("Limpiar")
        AddHandler tooltip.Click, AddressOf DistribuirPAres

        For Each fila As Entidades.ProspectaDias In DiasProspecta
            tooltip = ContextMenuStrip1.Items.Add(fila.NombreDia + " " + fila.NumeroDia.ToString)
            AddHandler tooltip.Click, AddressOf DistribuirPAres
        Next


    End Sub

    Private Sub DistribuirPAres(sender As Object, e As EventArgs)
        Dim tooltip As ToolStripItem
        tooltip = sender

        Cursor = Cursors.WaitCursor
        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If

        FiltrarPartidasXPedido()
        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, Replace(tooltip.Text, " ", ""))
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, Replace(tooltip.Text, " ", ""))
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, Replace(tooltip.Text, " ", ""))
        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub DistribuirPAres(ByVal Limpiar As String)


        Dim TabPage As TabPage
        TabPage = tabProspecta.SelectedTab

        If TabPage.Text = "Clientes" Then
            MarcarFilasSeleccionadasDistribucionParesCliente()
            FiltrarPedidosxClienteSeleccionado()
        End If

        If TabPage.Text = "Pedidos" Then
            MarcarFilasSeleccionadasDistribucionParesPedido()
        End If

        FiltrarPartidasXPedido()
        If tabProspecta.SelectedTab.Text = "Clientes" Then
            DistribuirParesDiaPlaneacion(gridListaProspecta, Replace(Limpiar, " ", ""))
        ElseIf tabProspecta.SelectedTab.Text = "Pedidos" Then
            DistribuirParesDiaPlaneacion(gridPedidos, Replace(Limpiar, " ", ""))
        ElseIf tabProspecta.SelectedTab.Text = "Partidas" Then
            DistribuirParesDiaPlaneacion(gridPartidas, Replace(Limpiar, " ", ""))
        End If



    End Sub



    Private Sub btnFiltroAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnFiltroAgenteVentas.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 18

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFiltroAgenteVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridFiltroAgenteVentas.DataSource = listado.listParametros
        With gridFiltroAgenteVentas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub gridFiltroAgenteVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridFiltroAgenteVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub gridFiltroAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridFiltroAgenteVentas.InitializeLayout
        grid_diseño(gridFiltroAgenteVentas)
        gridFiltroAgenteVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub CambiarColorDatosGuardados()

        Try
            Dim celdaProspecta As UltraGridCell
            Dim PedidoSicy As Integer = 0
            Dim clienteid As Integer = 0
            For Each fila As UltraGridRow In gridListaProspecta.Rows
                clienteid = fila.Cells("ClienteSicyID").Value

                If ListaClientesProspectadosCompletos.Exists(Function(x) x = clienteid) Then
                    celdaProspecta = fila.Cells("PrsProsp")

                    If celdaProspecta.Appearance.ForeColor = Color.Purple Then
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        Next
                        celdaProspecta.Appearance.ForeColor = Color.Black
                    ElseIf celdaProspecta.Appearance.ForeColor = Color.OrangeRed Then
                        If IsDBNull(celdaProspecta.Value) = False Then
                            If celdaProspecta.Value = 0 Then
                                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                Next
                            Else
                                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    celdaProspecta.Appearance.ForeColor = Color.Black
                                Next
                            End If
                        End If
                        celdaProspecta.Appearance.ForeColor = Color.Black
                    End If

                    If IsDBNull(fila.Cells("PrsProsp").Value) = False Then
                        If fila.Cells("PrsProsp").Value <> 0 Then
                            fila.Cells("PR").Value = "SI"
                            fila.Cells("PR").Appearance.BackColor = Color.Green
                        Else
                            fila.Cells("PR").Value = "NO"
                            fila.Cells("PR").Appearance.BackColor = Color.Red
                        End If
                    End If

                End If


                'If fila.Hidden = False Then
                '    celdaProspecta = fila.Cells("PrsProsp")

                '    If celdaProspecta.Appearance.ForeColor = Color.Purple Then
                '        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                '            fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                '        Next
                '    ElseIf celdaProspecta.Appearance.ForeColor = Color.OrangeRed Then
                '        If IsDBNull(celdaProspecta.Value) = False Then
                '            If celdaProspecta.Value = 0 Then
                '                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                '                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                '                Next
                '            Else
                '                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                '                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                '                    celdaProspecta.Appearance.ForeColor = Color.Black
                '                Next
                '            End If
                '        End If
                '    End If
                'End If
            Next

            For Each fila As UltraGridRow In gridPedidos.Rows
                PedidoSicy = fila.Cells("PSICY").Value

                If ListaPedidosProspectadosCompletos.Exists(Function(x) x = PedidoSicy) = True Then
                    celdaProspecta = fila.Cells("PrsProsp")
                    If celdaProspecta.Appearance.ForeColor = Color.Purple Then
                        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                            fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                        Next
                        celdaProspecta.Appearance.ForeColor = Color.Black
                    ElseIf celdaProspecta.Appearance.ForeColor = Color.OrangeRed Then
                        If IsDBNull(celdaProspecta.Value) = False Then
                            If celdaProspecta.Value = 0 Then
                                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                                    celdaProspecta.Appearance.ForeColor = Color.Black
                                Next
                            End If
                        End If
                    End If

                    If IsDBNull(fila.Cells("PrsProsp").Value) = False Then
                        If fila.Cells("PrsProsp").Value <> 0 Then
                            fila.Cells("PR").Value = "SI"
                            fila.Cells("PR").Appearance.BackColor = Color.Green
                        Else
                            fila.Cells("PR").Value = "NO"
                            fila.Cells("PR").Appearance.BackColor = Color.Red
                        End If
                    End If
                End If


                'If fila.Hidden = False Then
                '    celdaProspecta = fila.Cells("PrsProsp")
                '    If celdaProspecta.Appearance.ForeColor = Color.Purple Then
                '        For Each DIA As Entidades.ProspectaDias In DiasProspecta
                '            fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                '        Next
                '    ElseIf celdaProspecta.Appearance.ForeColor = Color.OrangeRed Then
                '        If IsDBNull(celdaProspecta.Value) = False Then
                '            If celdaProspecta.Value = 0 Then
                '                For Each DIA As Entidades.ProspectaDias In DiasProspecta
                '                    fila.Cells("plan_" + DIA.NombreDia + DIA.NumeroDia.ToString()).Appearance.ForeColor = Color.Black
                '                Next
                '            End If
                '        End If
                '    End If
                'End If
            Next

        Catch ex As Exception
            Dim error1 As String
            error1 = "cadena"
        End Try

    End Sub


    Private Sub LimpiarParesDiaPlaneacion()
        Dim SumaFila As Integer = 0
        Dim SumaFilaTotal As Integer = 0
        Dim ProspectaPorPedido As Boolean = False
        Dim CeldaModificada As UltraGridCell
        Dim grid As UltraGrid
        Dim ListaPedidosL As New List(Of Integer)
        Dim ListaClienteIDL As New List(Of Integer)

        Dim CantidadParesNoCumplen As Integer = 0

        If tabProspecta.SelectedIndex = 1 Then
            grid = gridPedidos
        ElseIf tabProspecta.SelectedIndex = 2 Then
            grid = gridPartidas
        Else
            Return
        End If


        Dim FilaSeleccionada As Boolean = False
        For Each fila As UltraGridRow In grid.Rows
            If fila.Hidden = True Then
                Continue For
            End If

            If grid.Name = "gridPedidos" Then
                CeldaModificada = fila.Cells("PrsProsp")
                If fila.Cells("PrsProsp").Appearance.ForeColor = Color.OrangeRed Then
                    CantidadParesNoCumplen += CeldaModificada.Value
                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                    Next
                    fila.Cells("PrsProsp").Value = 0
                    ListaPedidosL.Add(fila.Cells("PSICY").Value)
                    ListaClienteIDL.Add(fila.Cells("clienteid").Value)

                End If

            ElseIf grid.Name = "gridPartidas" Then
                CeldaModificada = fila.Cells("PrsProsp")
                If fila.Cells("PrsProsp").Appearance.ForeColor = Color.OrangeRed Then
                    CantidadParesNoCumplen += CeldaModificada.Value
                    For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                        fila.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                    Next
                    fila.Cells("PrsProsp").Value = 0
                    ListaClienteIDL.Add(fila.Cells("ClientesicyId").Value)
                    ListaPedidosL.Add(fila.Cells("PSICY").Value)
                End If
                If ListaPedidosProspectadosCompletos.Exists(Function(x) x = fila.Cells("PSICY").Value) = True Then
                    If fila.Cells("PrsProsp").Value <> 0 Then
                        fila.Cells("PR").Value = "SI"
                        fila.Cells("PR").Appearance.BackColor = Color.Green
                    Else
                        fila.Cells("PR").Value = "NO"
                        fila.Cells("PR").Appearance.BackColor = Color.Red
                    End If
                End If
             

            Else
                Continue For
            End If

         
        Next

        If grid.Name = "gridPedidos" Then
            For Each filaPartida As UltraGridRow In gridPartidas.Rows
                If ListaPedidosL.Exists(Function(x) x = filaPartida.Cells("PSICY").Value) = True Then
                    If filaPartida.Cells("PrsProsp").Appearance.ForeColor = Color.OrangeRed Then
                        For Each DiaPlaneacion As Entidades.ProspectaDias In DiasProspecta
                            filaPartida.Cells("plan_" + DiaPlaneacion.NombreDia + DiaPlaneacion.NumeroDia.ToString()).Value = 0
                        Next
                        filaPartida.Cells("PrsProsp").Value = 0
                    End If
                End If
            Next
        End If

        If grid.Name <> "gridListaProspecta" Then


            For Each filalciente As UltraGridRow In gridListaProspecta.Rows
                If ListaClienteIDL.Exists(Function(x) x = filalciente.Cells("ClienteSicyID").Value) Then
                    filalciente.Cells("PrsProsp").Value = filalciente.Cells("PrsProsp").Value - CantidadParesNoCumplen
                End If

            Next
        End If




        'ActualizarCantidadParesProspectaPedido()
        'ActualizarCantidadParesPedidoPartida()
        ActualizarCantidadParesPedidoPartida()
        ActualizarCantidadParesProspectaPedido()

       
       

    End Sub


    Private Sub CalcularMedicion(ByRef Fila As UltraGridRow)
        Dim TotalPares As Integer = 0
        Dim ParesCofirmadoas As Integer = 0
        Dim Porcentaje As Double = 0

        If Fila.Cells("PA").Value = "SI" Then
            'Pares Proyectados
            If IsDBNull(Fila.Cells("PrsProsp").Value) = True Then
                TotalPares = 0
            Else
                TotalPares = Fila.Cells("PrsProsp").Value
            End If

            If IsDBNull(Fila.Cells("PrsProy").Value) = True Then
                ParesCofirmadoas = 0
            Else
                ParesCofirmadoas = Fila.Cells("PrsProy").Value
            End If

            Fila.Cells("Prs No Proy").Value = TotalPares - ParesCofirmadoas

            If TotalPares > 0 Then
                Porcentaje = (CDbl(ParesCofirmadoas) / CDbl(TotalPares)) * 100
                Fila.Cells("% Prs Proy").Value = Math.Round(Porcentaje, 0).ToString() + "%"

                If Math.Round(Porcentaje, 0) = 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.Green
                ElseIf Math.Round(Porcentaje, 0) < 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.OrangeRed
                ElseIf Math.Round(Porcentaje, 0) > 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.Red
                End If

            End If
        Else
            'Pares Proyectados
            If IsDBNull(Fila.Cells("PrsProsp").Value) = True Then
                TotalPares = 0
            Else
                TotalPares = Fila.Cells("PrsProsp").Value
            End If

            If IsDBNull(Fila.Cells("PrsProy").Value) = True Then
                ParesCofirmadoas = 0
            Else
                ParesCofirmadoas = Fila.Cells("PrsProy").Value
            End If

            Fila.Cells("Prs No Proy").Value = TotalPares - ParesCofirmadoas

            If TotalPares > 0 Then
                Porcentaje = (CDbl(ParesCofirmadoas) / CDbl(TotalPares)) * 100
                Fila.Cells("% Prs Proy").Value = Math.Round(Porcentaje, 0).ToString() + "%"

                If Math.Round(Porcentaje, 0) = 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.Green
                ElseIf Math.Round(Porcentaje, 0) < 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.OrangeRed
                ElseIf Math.Round(Porcentaje, 0) > 100 Then
                    Fila.Cells("% Prs Proy").Appearance.ForeColor = Color.Red
                End If
            End If
        End If

       

        'Pares Confirmados
        If IsDBNull(Fila.Cells("PrsProy").Value) = True Then
            TotalPares = 0
        Else
            TotalPares = Fila.Cells("PrsProy").Value
        End If

        If IsDBNull(Fila.Cells("PrsConfOT").Value) = True Then
            ParesCofirmadoas = 0
        Else
            ParesCofirmadoas = Fila.Cells("PrsConfOT").Value
        End If

        Fila.Cells("Prs No ConfOT").Value = TotalPares - ParesCofirmadoas


        If TotalPares > 0 Then
            Porcentaje = (CDbl(ParesCofirmadoas) / CDbl(TotalPares)) * 100
            Fila.Cells("% Prs ConfOT").Value = Math.Round(Porcentaje, 0).ToString() + "%"

            If Math.Round(Porcentaje, 0) = 100 Then
                Fila.Cells("% Prs ConfOT").Appearance.ForeColor = Color.Green
            ElseIf Math.Round(Porcentaje, 0) < 100 Then
                Fila.Cells("% Prs ConfOT").Appearance.ForeColor = Color.OrangeRed
            ElseIf Math.Round(Porcentaje, 0) > 100 Then
                Fila.Cells("% Prs ConfOT").Appearance.ForeColor = Color.Red
            End If

        End If


        'Pares Embarcados        
        If IsDBNull(Fila.Cells("PrsConfOT").Value) = True Then
            TotalPares = 0
        Else
            TotalPares = Fila.Cells("PrsConfOT").Value
        End If

        If IsDBNull(Fila.Cells("PrsEmb").Value) = True Then
            ParesCofirmadoas = 0
        Else
            ParesCofirmadoas = Fila.Cells("PrsEmb").Value
        End If

        Fila.Cells("Prs No Emb").Value = TotalPares - ParesCofirmadoas

        If TotalPares > 0 Then
            Porcentaje = (CDbl(ParesCofirmadoas) / CDbl(TotalPares)) * 100
            Fila.Cells("% Prs Emb").Value = Math.Round(Porcentaje, 0).ToString() + "%"

            If Math.Round(Porcentaje, 0) = 100 Then
                Fila.Cells("% Prs Emb").Appearance.ForeColor = Color.Green
            ElseIf Math.Round(Porcentaje, 0) < 100 Then
                Fila.Cells("% Prs Emb").Appearance.ForeColor = Color.OrangeRed
            ElseIf Math.Round(Porcentaje, 0) > 100 Then
                Fila.Cells("% Prs Emb").Appearance.ForeColor = Color.Red
            End If

        End If


        'Pares Salidas        
        If IsDBNull(Fila.Cells("PrsEmb").Value) = True Then
            TotalPares = 0
        Else
            TotalPares = Fila.Cells("PrsEmb").Value
        End If

        If IsDBNull(Fila.Cells("PrsSal").Value) = True Then
            ParesCofirmadoas = 0
        Else
            ParesCofirmadoas = Fila.Cells("PrsSal").Value
        End If

        Fila.Cells("Prs No Sal").Value = TotalPares - ParesCofirmadoas


        If TotalPares > 0 Then
            Porcentaje = (CDbl(ParesCofirmadoas) / CDbl(TotalPares)) * 100
            Fila.Cells("% Prs Sal").Value = Math.Round(Porcentaje, 0).ToString() + "%"

            If Math.Round(Porcentaje, 0) = 100 Then
                Fila.Cells("% Prs Sal").Appearance.ForeColor = Color.Green
            ElseIf Math.Round(Porcentaje, 0) < 100 Then
                Fila.Cells("% Prs Sal").Appearance.ForeColor = Color.OrangeRed
            ElseIf Math.Round(Porcentaje, 0) > 100 Then
                Fila.Cells("% Prs Sal").Appearance.ForeColor = Color.Red
            End If
        End If

       

        
    End Sub




    Private Sub ConsultarUsuariosEnEdicionOProspecta()

        Dim ObjProspectaBu As New Ventas.Negocios.ProspectaBU
        Dim DtUsuariosEditan As DataTable
        Dim objUsuarioEdita As New Entidades.ProspectaInformacionEdicionUsuarios
        Dim ListaUsuariosEditan As New List(Of Entidades.ProspectaInformacionEdicionUsuarios)
        ListaClientesEnEdicionUsuario.Clear()
        DtUsuariosEditan = ObjProspectaBu.ObtenerUsuariosEdicionProspecta(ProspectaID)

        For Each Fila As DataRow In DtUsuariosEditan.Rows
            objUsuarioEdita = New Entidades.ProspectaInformacionEdicionUsuarios
            objUsuarioEdita.ClienteSayID = Fila.Item("ClienteSayID").ToString
            objUsuarioEdita.Hora = Fila.Item("Hora").ToString
            objUsuarioEdita.UserName = Fila.Item("UserName").ToString
            objUsuarioEdita.FechaActividad = Fila.Item("FechaActividad").ToString
            objUsuarioEdita.UsuarioID = Fila.Item("UsuarioID").ToString            
            ListaUsuariosEditan.Add(objUsuarioEdita)
        Next
  
        For Each FilaCliente As UltraGridRow In gridListaProspecta.Rows
            If ListaUsuariosEditan.Exists(Function(x) x.ClienteSayID = FilaCliente.Cells("ClienteSayID").Value) = True Then
                objUsuarioEdita = ListaUsuariosEditan.Find(Function(x) x.ClienteSayID = FilaCliente.Cells("ClienteSayID").Value)
          
                FilaCliente.Cells("UsuarioEditaID").Value = objUsuarioEdita.UsuarioID
                If FilaCliente.Cells("UsuarioEditaID").Value <> Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                    FilaCliente.Appearance.ForeColor = Color.Red
                    FilaCliente.Cells("Edita").Value = objUsuarioEdita.UserName
                    FilaCliente.Cells("Edición").Value = objUsuarioEdita.Hora
                End If

                If ModoEdicion = True Then
                    If FilaCliente.Cells("UsuarioEditaID").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                        FilaCliente.Cells("*Incidencia").Activation = Activation.AllowEdit
                        FilaCliente.Cells("*Observaciones").Activation = Activation.AllowEdit
                        ListaClientesEnEdicionUsuario.Add(FilaCliente.Cells("ClienteSayID").Value)
                        If FilaCliente.Cells("PA").Value = "NO" Then
                            For Each dia As Entidades.ProspectaDias In DiasProspecta
                                FilaCliente.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.AllowEdit
                            Next
                        End If
                    Else
                        FilaCliente.Cells("*Incidencia").Activation = Activation.NoEdit
                        FilaCliente.Cells("*Observaciones").Activation = Activation.NoEdit
                        If FilaCliente.Cells("PA").Value = "SI" Then
                            For Each dia As Entidades.ProspectaDias In DiasProspecta
                                FilaCliente.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                            Next
                        End If
                    End If

                   
                End If
            Else
                If ModoEdicion = True Then
                    FilaCliente.Cells("*Incidencia").Activation = Activation.NoEdit
                    FilaCliente.Cells("*Observaciones").Activation = Activation.NoEdit

                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        FilaCliente.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                    Next
                End If

                If FilaCliente.Cells("PA").Value = "NO" Then
                    For Each dia As Entidades.ProspectaDias In DiasProspecta
                        FilaCliente.Cells("plan_" + dia.NombreDia + dia.NumeroDia.ToString()).Activation = Activation.NoEdit
                    Next
                End If
            End If
        Next



    End Sub



End Class

