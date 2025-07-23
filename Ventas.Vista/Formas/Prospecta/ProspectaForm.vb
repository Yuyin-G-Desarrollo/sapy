Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ProspectaForm

    Dim TipoPerfil As Integer = -1 '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno, 5 => Almacen
    Dim IdEstadoProspecta As Int32
    Public ProspectaID As Integer = -1
    Dim FiltroClientes As String
    Dim FiltroAtencionClientes As String
    Dim FiltroAgenteID As String
    Dim listInicial As New List(Of String)
    Dim Edicion As Boolean = False
    Dim SiguienteStatus As Integer = 0
    Dim IdEstatusInicialProspecta As Integer = 0
    Dim CargaCompletaLoad As Boolean = False
    Dim ActualizandoCheckBox As Boolean = False

    Private Sub Prospecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaCompletaLoad = False
        Dim FechaInicio As Date = "01/01/" + nudAño.Value.ToString()
        Dim fecha As Date = DateAdd("ww", nudNumSemana.Value - 1, FechaInicio)
        dtmFechaInicio.Value = fecha


        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        grdFiltroClientes.DataSource = listInicial
        grdAtnClientes.DataSource = listInicial
        grdFiltroAgenteVentas.DataSource = listInicial

        btnActualizarStatus.Visible = False

        If ProspectaID <> -1 Then
            CargarInformacionProspecta()
            IdEstatusInicialProspecta = IdEstadoProspecta
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
            Dim cal As Calendar = DateTimeFormatInfo.CurrentInfo.Calendar
            'cal.GetWeekOfYear("31/12/2017", CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)
            nudAño.Value = DateTime.Now.Year
            nudAño.Minimum = DateTime.Now.Year
            If nudAño.Value = 2017 Then
                nudNumSemana.Value = cal.GetWeekOfYear(DateTime.Now.ToShortDateString, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday)
            Else
                If nudAño.Value = 2021 Then
                    nudNumSemana.Value = cal.GetWeekOfYear(DateTime.Now.ToShortDateString, CalendarWeekRule.FirstDay, DayOfWeek.Monday) - 1
                Else
                    nudNumSemana.Value = cal.GetWeekOfYear(DateTime.Now.ToShortDateString, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                End If
            End If
            If nudAño.Value = 2021 Or nudAño.Value = 2022 Then
                nudNumSemana.Minimum = cal.GetWeekOfYear(Date.Now.ToShortDateString(), CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                nudNumSemana.Maximum = cal.GetWeekOfYear("31/12/" + nudAño.Value.ToString(), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday) - 1
            Else

                nudNumSemana.Minimum = cal.GetWeekOfYear(Date.Now.ToShortDateString(), CalendarWeekRule.FirstDay, DayOfWeek.Monday) + 1
                nudNumSemana.Maximum = cal.GetWeekOfYear("31/12/" + nudAño.Value.ToString(), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)
            End If
        End If

        PermisosPerfil()

        spcClientes.SplitterDistance = spcClientes.Width - 4
        sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4

        spcPedidos.SplitterDistance = 20

        CargaCompletaLoad = True

    End Sub




    Private Sub nudNumSemana_ValueChanged(sender As Object, e As EventArgs) Handles nudNumSemana.ValueChanged
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim FechaInicio As Date = "01/01/" + nudAño.Value.ToString()
        Dim fecha As Date = DateAdd("ww", nudNumSemana.Value - 1, FechaInicio)
        Dim cal As Calendar = DateTimeFormatInfo.CurrentInfo.Calendar
        If cal.GetDayOfWeek(fecha) = 0 Then
            fecha = DateAdd("d", 1, fecha)
        ElseIf cal.GetDayOfWeek(fecha) > 0 Then
            fecha = DateAdd("d", (cal.GetDayOfWeek(fecha) - 1) * -1, fecha)
        End If
        fecha = If(nudAño.Value = 2022 Or nudAño.Value = 2021, DateAdd("d", 7, fecha), fecha)
        dtmFechaInicio.Value = fecha
        dtmFechaFin.Value = DateAdd("d", 5, fecha)

        If ProspectaID = -1 And CargaCompletaLoad = True Then
            objProspecta.LimpiarTablasProspectaNoGuardada()
            grdNivelCliente.DataSource = Nothing
            grdNivelPedido.DataSource = Nothing
            grdNivelPartida.DataSource = Nothing
        End If

    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim FechaInicio As Date = "01/01/" + nudAño.Value.ToString()
        Dim fecha As Date = DateAdd("ww", nudNumSemana.Value - 1, FechaInicio)
        Dim cal As Calendar = DateTimeFormatInfo.CurrentInfo.Calendar
        If cal.GetDayOfWeek(fecha) = 0 Then
            fecha = DateAdd("d", 1, fecha)
        ElseIf cal.GetDayOfWeek(fecha) > 0 Then
            fecha = DateAdd("d", (cal.GetDayOfWeek(fecha) - 1) * -1, fecha)
        End If
        dtmFechaInicio.Value = fecha
        dtmFechaFin.Value = DateAdd("d", 5, fecha)

        If ProspectaID = -1 And CargaCompletaLoad = True Then
            objProspecta.LimpiarTablasProspectaNoGuardada()
            grdNivelCliente.DataSource = Nothing
            grdNivelPedido.DataSource = Nothing
            grdNivelPartida.DataSource = Nothing
        End If
        'If nudAño.Value <> Date.Now.Year Then
        If nudAño.Value <> 2017 Then
            nudNumSemana.Minimum = cal.GetWeekOfYear("01/01/" + nudAño.Value.ToString(), CalendarWeekRule.FirstDay, DayOfWeek.Monday)
            nudNumSemana.Maximum = cal.GetWeekOfYear("31/12/" + nudAño.Value.ToString(), CalendarWeekRule.FirstDay, DayOfWeek.Monday)
        Else

            nudNumSemana.Minimum = cal.GetWeekOfYear(Date.Now.ToShortDateString(), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday) + 1
            nudNumSemana.Maximum = cal.GetWeekOfYear("31/12/" + nudAño.Value.ToString(), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)
        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim ObjProspecta As New Ventas.Negocios.ProspectaBU()
        Dim dtResultadoConsultaNivelCliente As New DataTable()
        Dim dtResultadoValidacionSemana As New DataTable()

        dtResultadoValidacionSemana = ObjProspecta.ValidaSemanaProspecta(nudNumSemana.Value, nudAño.Value)

        If dtResultadoValidacionSemana.Rows(0).Item("Mensaje").ToString = "" Or ProspectaID <> -1 Then
            Cursor = Cursors.WaitCursor
            PermisosPerfil()
            FiltroClientes = ObtenerClientesFiltro()
            FiltroAtencionClientes = ObtenerAtencionClientesFiltro()
            FiltroAgenteID = ObtenerAgentesSeleccinados()




            If ProspectaID = -1 Then
                RespaldarParesSicy()
            Else
                If txtStatusProspecta.Text = "PRÓXIMA" Or txtStatusProspecta.Text = "REVISIÓN" Then
                    ObjProspecta.ProspectaProxima(dtmFechaInicio.Value, dtmFechaFin.Value)
                ElseIf txtStatusProspecta.Text = "VIGENTE" Then
                    ObjProspecta.ProspectaVigente(dtmFechaInicio.Value, dtmFechaFin.Value)
                End If
            End If

            ObjProspecta.RespaldarDatosProspectaDeSICY(ProspectaID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, If(Edicion, 1, 0), TipoPerfil)

            grdNivelCliente.DataSource = Nothing
            grdNivelPedido.DataSource = Nothing
            grdNivelPartida.DataSource = Nothing
            grdNivelPartidaOculto.DataSource = Nothing
            dtResultadoConsultaNivelCliente = ObjProspecta.ConsultarDatosProspectaPorNivel(1, FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, "", ProspectaID)
            grdNivelCliente.DataSource = dtResultadoConsultaNivelCliente
            gridClientesDiseño(grdNivelCliente)


            grdNivelPartidaOculto.DataSource = ObjProspecta.ConsultarDatosProspectaPorNivel(3, FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, "", ProspectaID)
            grdNivelPartidaOculto.DisplayLayout.Bands(0).Columns.Add("ColumnaModificada")
            'grid.DisplayLayout.Bands(0)
            gridPartidasDiseño(grdNivelPartidaOculto)

            spcClientes.SplitterDistance = spcClientes.Width - 4
            sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
            btnArriba_Click(sender, e)

            grdResumenDiario.DataSource = ObjProspecta.ConsultarEntregasPorDia(ProspectaID)
            gridParesDiariosDiseño(grdResumenDiario)

            Cursor = Cursors.Default
        Else
            show_message("Advertencia", dtResultadoValidacionSemana.Rows(0).Item("Mensaje").ToString)
        End If


    End Sub

    Public Sub RespaldarParesSicy()
        '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno, 5 => Almacen

        'FiltroClientes = ObtenerClientesFiltro()
        'FiltroAtencionClientes = ObtenerAtencionClientesFiltro()
        'FiltroAgenteID = ObtenerAgentesSeleccinados()
        Dim FechaInicio As String = dtmFechaInicio.Value.ToShortDateString()
        Dim FechaFin As String = dtmFechaFin.Value.ToShortDateString()

        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        'ObjPRospecta.RespaldarDatosProspecta(TipoPerfil, FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, FechaInicio, FechaFin, If(Edicion, 1, 0))
        ObjPRospecta.RespaldarDatosProspecta(TipoPerfil, "", "", "", Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, FechaInicio, FechaFin, If(Edicion, 1, 0))

    End Sub

    Private Function ObtenerClientesFiltro() As String
        Dim filtro As String = String.Empty
        If grdFiltroClientes.Rows.Count <> 0 Then
            For Each row As UltraGridRow In grdFiltroClientes.Rows
                If row.Index = 0 Then
                    filtro += " " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                Else
                    filtro += ", " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                End If
            Next
        End If
        Return filtro
    End Function

    Private Function ObtenerAtencionClientesFiltro() As String
        Dim filtro As String = String.Empty
        If grdAtnClientes.Rows.Count <> 0 Then
            For Each row As UltraGridRow In grdAtnClientes.Rows
                If row.Index = 0 Then
                    filtro += " " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                Else
                    filtro += ", " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                End If
            Next
        End If
        Return filtro
    End Function

    Private Function ObtenerAgentesSeleccinados() As String
        Dim filtro As String = String.Empty

        If TipoPerfil = 1 Then 'Agente
            filtro = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        Else
            If grdFiltroAgenteVentas.Rows.Count <> 0 Then
                For Each row As UltraGridRow In grdFiltroAgenteVentas.Rows
                    If row.Index = 0 Then
                        filtro += " " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                    Else
                        filtro += ", " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
                    End If
                Next
            End If
        End If


        Return filtro
    End Function

    Private Sub PermisosPerfil()
        Dim DTInformacionUsuario As New DataTable
        btnActualizarStatus.Visible = False
        ''0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno, 5 => Almacen

        'almacen
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ALMACEN") Then
            btnActualizarStatus.Enabled = False
            nudNumSemana.Enabled = False
            nudAño.Enabled = False
            btnEditar.Enabled = False
            lblEditar.Enabled = False
            btnFiltroCliente.Enabled = True
            btnAtnClientes.Enabled = True
            btnFiltroAgenteVentas.Enabled = True
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            btnActualizarStatus.Enabled = False
            btnAtnClientes.Enabled = True
            btnFiltroAgenteVentas.Enabled = True
            btnSeguimietoPares.Enabled = False
            lblSeguimientoPares.Enabled = False
            btnSeguimientoClientes.Enabled = False
            lblSeguimientoClientes.Enabled = False
            btnAgenda.Enabled = False
            lblAgenda.Enabled = False
            TipoPerfil = 5
        End If

        ''Atencion a clientes externo
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTEEXTERNO") Then
            If ProspectaID <> -1 Then
                btnSeguimietoPares.Enabled = True
                lblSeguimientoPares.Enabled = True
                btnSeguimientoClientes.Enabled = True
                lblSeguimientoClientes.Enabled = True
                btnAgenda.Enabled = True
                lblAgenda.Enabled = True
                If IdEstadoProspecta = 87 Then
                    btnEditar.Enabled = True
                    lblEditar.Enabled = True
                ElseIf IdEstadoProspecta = 89 Then
                    btnSeguimietoPares.Enabled = False
                    lblSeguimientoPares.Enabled = False
                    btnSeguimientoClientes.Enabled = False
                    lblSeguimientoClientes.Enabled = False
                    btnAgenda.Enabled = False
                    lblAgenda.Enabled = False
                Else
                    btnEditar.Enabled = False
                    lblEditar.Enabled = False
                End If
            End If
            btnAtnClientes.Enabled = False

            'If Edicion = True Then
            '    btnAtnClientes.Enabled = False
            'Else
            '    btnAtnClientes.Enabled = True
            'End If

            btnFiltroAgenteVentas.Enabled = True
            TipoPerfil = 4
            btnActualizarStatus.Visible = False
        End If

        ''Atencion a clientes interno e externo
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTES") Then
            If ProspectaID <> -1 Then
                btnSeguimietoPares.Enabled = True
                lblSeguimientoPares.Enabled = True
                btnSeguimientoClientes.Enabled = True
                lblSeguimientoClientes.Enabled = True
                btnAgenda.Enabled = True
                lblAgenda.Enabled = True
                If IdEstadoProspecta = 87 Then
                    btnEditar.Enabled = True
                    lblEditar.Enabled = True
                ElseIf IdEstadoProspecta = 89 Then
                    btnSeguimietoPares.Enabled = False
                    lblSeguimientoPares.Enabled = False
                    btnSeguimientoClientes.Enabled = False
                    lblSeguimientoClientes.Enabled = False
                    btnAgenda.Enabled = False
                    lblAgenda.Enabled = False
                Else
                    btnEditar.Enabled = False
                    lblEditar.Enabled = False
                End If
            End If

            If Edicion = True Then
                btnAtnClientes.Enabled = False
            Else
                btnAtnClientes.Enabled = True
            End If

            btnFiltroAgenteVentas.Enabled = True
            TipoPerfil = 0
            btnActualizarStatus.Visible = False
        End If


        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_AGENTEVENTAS") Then
            btnEditar.Enabled = False
            lblEditar.Enabled = False
            btnAtnClientes.Enabled = True
            btnFiltroAgenteVentas.Enabled = False
            TipoPerfil = 1
            btnActualizarStatus.Visible = False
            btnSeguimietoPares.Enabled = False
            lblSeguimientoPares.Enabled = False
            btnSeguimientoClientes.Enabled = False
            lblSeguimientoClientes.Enabled = False
            btnAgenda.Enabled = False
            lblAgenda.Enabled = False
        End If

        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ANALISTAVENTAS") Then
            btnEditar.Enabled = False
            lblEditar.Enabled = False
            TipoPerfil = 3
            btnActualizarStatus.Visible = False

            If IdEstadoProspecta = 89 Then
                btnSeguimietoPares.Enabled = False
                lblSeguimientoPares.Enabled = False
                btnSeguimientoClientes.Enabled = False
                lblSeguimientoClientes.Enabled = False
                btnAgenda.Enabled = False
                lblAgenda.Enabled = False
            Else
                btnSeguimietoPares.Enabled = True
                lblSeguimientoPares.Enabled = True
                btnSeguimientoClientes.Enabled = True
                lblSeguimientoClientes.Enabled = True
                btnAgenda.Enabled = True
                lblAgenda.Enabled = True
            End If
        End If

        'Jefatura Atencion Clientes
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_JEFATURA") Then
            If ProspectaID <> -1 Then
                btnSeguimietoPares.Enabled = True
                lblSeguimientoPares.Enabled = True
                btnSeguimientoClientes.Enabled = True
                lblSeguimientoClientes.Enabled = True
                btnAgenda.Enabled = True
                lblAgenda.Enabled = True
                If IdEstadoProspecta = 87 Or IdEstadoProspecta = 90 Then
                    btnEditar.Enabled = True
                    btnActualizarStatus.Visible = True
                    btnActualizarStatus.Enabled = True
                    lblEditar.Enabled = True
                ElseIf IdEstadoProspecta = 89 Then
                    btnSeguimietoPares.Enabled = False
                    lblSeguimientoPares.Enabled = False
                    btnSeguimientoClientes.Enabled = False
                    lblSeguimientoClientes.Enabled = False
                    btnAgenda.Enabled = False
                    lblAgenda.Enabled = False
                Else
                    btnEditar.Enabled = False
                    lblEditar.Enabled = False
                End If
            Else
                btnEditar.Enabled = True
                lblEditar.Enabled = True
            End If

            btnAtnClientes.Enabled = True
            btnFiltroAgenteVentas.Enabled = True
            TipoPerfil = 2
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_BTN_REVISION") Then
            If IdEstadoProspecta = 87 Or IdEstadoProspecta = 90 Then
                btnActualizarStatus.Visible = True
                btnActualizarStatus.Enabled = True
            Else
                btnActualizarStatus.Visible = False
                btnActualizarStatus.Enabled = False
            End If
        End If





        If TipoPerfil = -1 Then
            btnAtnClientes.Enabled = False
            btnFiltroAgenteVentas.Enabled = False
            btnEditar.Enabled = False
            btnExportar.Enabled = False
            btnSeguimietoPares.Enabled = False
            btnSeguimientoClientes.Enabled = False
            btnAgenda.Enabled = False
            btnFiltroCliente.Enabled = False
            btnMostrar.Enabled = False
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            nudNumSemana.Enabled = False
        End If

        If TipoPerfil = 1 Then
            btnEditar.Enabled = False
            btnFiltroAgenteVentas.Enabled = False
            grdFiltroAgenteVentas.DataSource = Nothing
            DTInformacionUsuario.Columns.Add("IdColaborador")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nombre")
            DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)
            grdFiltroAgenteVentas.DataSource = DTInformacionUsuario
            grdFiltroAgenteVentas.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdFiltroAgenteVentas.DisplayLayout.Bands(0).Columns(1).Hidden = True
        End If

        If TipoPerfil = 0 And Edicion = True Then
            btnEditar.Enabled = True
            btnAtnClientes.Enabled = False
            grdAtnClientes.DataSource = Nothing

            DTInformacionUsuario.Columns.Add("IdColaborador")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nombre")
            DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

            grdAtnClientes.DataSource = DTInformacionUsuario
            grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdAtnClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True

        End If

        If TipoPerfil = 4 Then
            btnEditar.Enabled = True
            btnAtnClientes.Enabled = False
            grdAtnClientes.DataSource = Nothing

            DTInformacionUsuario.Columns.Add("IdColaborador")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nombre")
            DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

            grdAtnClientes.DataSource = DTInformacionUsuario
            grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdAtnClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True

        End If


    End Sub


    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 20

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
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True
        'grdFiltroClientes.DisplayLayout.Bands(0).Columns(2).Hidden = True
        'grdFiltroClientes.DisplayLayout.Bands(0).Columns(3).Hidden = True
        'grdFiltroClientes.DisplayLayout.Bands(0).Columns(4).Hidden = True
        'grdFiltroClientes.DisplayLayout.Bands(0).Columns(5).Hidden = True
        'FiltrarInformacion()
    End Sub

    Private Sub btnAtnClientes_Click(sender As Object, e As EventArgs) Handles btnAtnClientes.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 22

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
    End Sub

    Private Sub btnFiltroAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnFiltroAgenteVentas.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 18

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroAgenteVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroAgenteVentas.DataSource = listado.listParametros
        With grdFiltroAgenteVentas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub


    Private Sub grdFiltroClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroClientes.InitializeLayout
        grid_diseño(grdFiltroClientes)
        grdFiltroClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtnClientes.InitializeLayout
        grid_diseño(grdAtnClientes)
        grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atn. Clientes"
    End Sub

    Private Sub grdFiltroAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroAgenteVentas.InitializeLayout
        grid_diseño(grdFiltroAgenteVentas)
        grdFiltroAgenteVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente"
    End Sub

    Private Sub grdFiltroAgenteVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroAgenteVentas.BeforeRowsDeleted
        If TipoPerfil = 1 Or ((TipoPerfil = 0 Or TipoPerfil = 4) And Edicion = True) Then
            e.Cancel = True
        Else
            e.DisplayPromptMsg = False
        End If
    End Sub

    Private Sub grdAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtnClientes.BeforeRowsDeleted
        If (TipoPerfil = 0 Or TipoPerfil = 4) And Edicion = True Then
            e.Cancel = True
        Else
            If TipoPerfil = 4 Then
                e.Cancel = True
            Else
                e.DisplayPromptMsg = False
            End If

        End If

    End Sub

    Private Sub grdFiltroClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        'Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)




        '    'ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)

        '    'Si la prospecta No se guarda borrar la informacion de las tablas
        '    If ProspectaID = -1 Then
        '        ObjPRospecta.LimpiarTablasProspectaNoGuardada()
        '    Else
        '        If IdEstatusInicialProspecta = 87 Or IdEstatusInicialProspecta = 88 Or IdEstatusInicialProspecta = 90 Then
        '            ObjPRospecta.ActualizarEncabezadoProspecta(ProspectaID)
        '        End If
        '    End If

        '    Me.Cursor = Cursors.Default
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        'End Try

        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Try
            Cursor = Cursors.WaitCursor
            Edicion = True
            'PermisosPerfil()
            'CargarPerfil()        
            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
            gridParesDiariosDiseño(grdResumenDiario)
            btnMostrar_Click(sender, e)

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

#Region "Eventos Grids"

    Private Sub grdNivelCliente_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelCliente.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If Edicion = True Then
            If IsNothing(grdNivelCliente.ActiveRow) = False Then
                If grdNivelCliente.ActiveRow.IsFilterRow = False Then

                    Try
                        Cursor = Cursors.WaitCursor
                        Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value And x.Cells("clie_clienteid").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)
                        For Each Fila As UltraGridRow In Lista
                            Fila.Cells("ColumnaModificada").Value = 0
                            GuardarInformacionProspecta(grdNivelCliente, Fila)
                            Existe = True
                        Next

                        If Existe = True Then
                            ActualizarColorParesProyectados(grdNivelCliente, -1, grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value)
                            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
                            gridParesDiariosDiseño(grdResumenDiario)

                            CargarResumenEntregarPorDia()
                        End If
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try

                End If
            End If
        End If

    End Sub

    Private Sub grdNivelCliente_CellChange(sender As Object, e As CellEventArgs) Handles grdNivelCliente.CellChange
        Dim clientesSeleccionados As String = ""
        Dim dtResultadoConsultaNivelPedido As DataTable
        Dim ObjProspecta As New Negocios.ProspectaBU
        Dim Existe As Boolean = False

        Cursor = Cursors.WaitCursor

        If e.Cell.Column.Header.Caption = "" Then
            Try
                Cursor = Cursors.WaitCursor
                Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value And x.Cells("clie_clienteid").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)
                For Each Fila As UltraGridRow In Lista
                    Fila.Cells("ColumnaModificada").Value = 0
                    GuardarInformacionProspecta(grdNivelCliente, Fila)
                    Existe = True
                Next

                If Existe = True Then
                    ActualizarColorParesProyectados(grdNivelCliente, -1, grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value)
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try



            If e.Cell.Value = False Then
                e.Cell.Value = True
                If spcClientes.SplitterDistance = spcClientes.Width - 4 Then
                    spcClientes.SplitterDistance = spcClientes.Width / 2
                End If
            Else
                e.Cell.Value = False
            End If
            For Each row As UltraGridRow In grdNivelCliente.Rows
                If CBool(row.Cells("Seleccionar").Value) = True Then
                    If clientesSeleccionados = "" Then
                        clientesSeleccionados += row.Cells("ClienteSICY").Value.ToString()
                    Else
                        clientesSeleccionados += "," + row.Cells("ClienteSICY").Value.ToString()
                    End If
                End If
            Next
            grdNivelPedido.DataSource = Nothing
            If clientesSeleccionados <> "" Then
                dtResultadoConsultaNivelPedido = ObjProspecta.ConsultarDatosProspectaPorNivel(2, clientesSeleccionados, FiltroAtencionClientes, FiltroAgenteID, "", ProspectaID)
                grdNivelPedido.DataSource = dtResultadoConsultaNivelPedido
                gridPedidosDiseño(grdNivelPedido)
            Else
                spcClientes.SplitterDistance = spcClientes.Width - 4
                sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
            End If
        End If

        If ActualizandoCheckBox = False Then
            If e.Cell.Column.Key = "Pros_Lu" Or e.Cell.Column.Key = "Pros_Ma" Or e.Cell.Column.Key = "Pros_Mi" Or e.Cell.Column.Key = "Pros_Ju" Or e.Cell.Column.Key = "Pros_Vi" Or e.Cell.Column.Key = "Pros_Sa" Then
                ActualizandoCheckBox = True
                DesmarcarCheckBox(grdNivelCliente, e.Cell.Row, e.Cell)
            End If
            ActualizandoCheckBox = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub grdNivelPedido_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelPedido.BeforeRowDeactivate
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If Edicion = True Then
            If IsNothing(grdNivelPedido.ActiveRow) = False Then
                If grdNivelPedido.ActiveRow.IsFilterRow = False Then
                    Try
                        Cursor = Cursors.WaitCursor
                        Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value And x.Cells("PedidoSICY").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)

                        For Each Fila As UltraGridRow In Lista
                            Fila.Cells("ColumnaModificada").Value = 0
                            GuardarInformacionProspecta(grdNivelPedido, Fila)
                            Existe = True
                        Next

                        If Existe = True Then
                            ActualizarColorParesProyectados(grdNivelPedido, grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value, grdNivelPedido.ActiveRow.Cells("clie_clienteid").Value)
                            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
                            gridParesDiariosDiseño(grdResumenDiario)
                        End If
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub grdNivelPedido_CellChange(sender As Object, e As CellEventArgs) Handles grdNivelPedido.CellChange
        Dim PedidosSeleccionados As String = ""
        Dim dtResultadoConsultaNivelPartida As DataTable
        Dim ObjProspecta As New Negocios.ProspectaBU
        Dim Existe As Boolean = False

        Cursor = Cursors.WaitCursor

        If e.Cell.Column.Header.Caption = "" Then

            Try
                Cursor = Cursors.WaitCursor
                Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value And x.Cells("PedidoSICY").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)
                For Each Fila As UltraGridRow In Lista
                    Fila.Cells("ColumnaModificada").Value = 0
                    GuardarInformacionProspecta(grdNivelPedido, Fila)
                    Existe = True
                Next

                If Existe = True Then
                    ActualizarColorParesProyectados(grdNivelPedido, grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value, grdNivelPedido.ActiveRow.Cells("clie_clienteid").Value)
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try

            If e.Cell.Value = False Then
                e.Cell.Value = True
                If sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4 Then
                    sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height / 2
                End If
            Else
                e.Cell.Value = False
            End If
            For Each row As UltraGridRow In grdNivelPedido.Rows
                If CBool(row.Cells("Seleccionar").Value) = True Then
                    If PedidosSeleccionados = "" Then
                        PedidosSeleccionados += row.Cells("PedidoSICY").Value.ToString()
                    Else
                        PedidosSeleccionados += "," + row.Cells("PedidoSICY").Value.ToString()
                    End If
                End If
            Next
            grdNivelPartida.DataSource = Nothing
            If PedidosSeleccionados <> "" Then
                dtResultadoConsultaNivelPartida = ObjProspecta.ConsultarDatosProspectaPorNivel(3, FiltroClientes, FiltroAtencionClientes, FiltroAgenteID, PedidosSeleccionados, ProspectaID)
                grdNivelPartida.DataSource = dtResultadoConsultaNivelPartida
                gridPartidasDiseño(grdNivelPartida)
            Else
                sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
            End If
        End If

        If ActualizandoCheckBox = False Then
            If e.Cell.Column.Key = "Pros_Lu" Or e.Cell.Column.Key = "Pros_Ma" Or e.Cell.Column.Key = "Pros_Mi" Or e.Cell.Column.Key = "Pros_Ju" Or e.Cell.Column.Key = "Pros_Vi" Or e.Cell.Column.Key = "Pros_Sa" Then
                ActualizandoCheckBox = True
                DesmarcarCheckBox(grdNivelPedido, e.Cell.Row, e.Cell)
            End If
            ActualizandoCheckBox = False

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub grdNivelPartida_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNivelPartida.BeforeRowDeactivate
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        If Edicion = True Then
            If IsNothing(grdNivelPartida.ActiveRow) = False Then
                If grdNivelPartida.ActiveRow.IsFilterRow = False Then
                    Try
                        Cursor = Cursors.WaitCursor
                        Dim FilaPartida As UltraGridRow = grdNivelPartidaOculto.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = grdNivelPartida.ActiveRow.Cells("PedidoSICY").Value And x.Cells("Partida").Value = grdNivelPartida.ActiveRow.Cells("Partida").Value)

                        If IsNothing(FilaPartida) = False Then
                            If FilaPartida.Cells("ColumnaModificada").Value = 1 Then
                                GuardarInformacionProspecta(grdNivelPartida, grdNivelPartida.ActiveRow)
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Ju"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Vi"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Lu"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Ma"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Mi"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Usuario"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Total PR"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("PR"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Fecha"))

                                ActualizarColorParesProyectados(grdNivelPartida, grdNivelPartida.ActiveRow.Cells("PedidoSICY").Value, -1)
                                grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
                                gridParesDiariosDiseño(grdResumenDiario)
                            End If
                            FilaPartida.Cells("ColumnaModificada").Value = 0
                        Else
                            GuardarInformacionProspecta(grdNivelPartida, grdNivelPartida.ActiveRow)
                        End If

                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try


                End If
            End If
        End If

    End Sub

    Public Sub CeldaColorNegro(ByVal celda As UltraGridCell)

        If celda.Column.Key = "Usuario" Or celda.Column.Key = "Fecha" Or celda.Column.Key = "PR" Then
            celda.Appearance.ForeColor = Color.Black
        Else
            If celda.Value <> "0" Then
                celda.Appearance.ForeColor = Color.Black
            End If
        End If

    End Sub

    Public Sub ActualizarColorParesProyectados(ByVal grd As UltraGrid, ByVal PedidoSicyID As Integer, ByVal ClienteID As Integer)

        Dim ClienteID_aux As Integer = -1
        If grd.Name = "grdNivelPartida" Then
            'Actualizar Color en pedido
            Dim ListaPedidos = grdNivelPedido.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = PedidoSicyID)

            For Each Fila As UltraGridRow In ListaPedidos
                CeldaColorNegro(Fila.Cells("Proy_Ju"))
                CeldaColorNegro(Fila.Cells("Proy_Vi"))
                CeldaColorNegro(Fila.Cells("Proy_Lu"))
                CeldaColorNegro(Fila.Cells("Proy_Ma"))
                CeldaColorNegro(Fila.Cells("Proy_Mi"))
                CeldaColorNegro(Fila.Cells("Usuario"))
                CeldaColorNegro(Fila.Cells("Fecha"))
                CeldaColorNegro(Fila.Cells("PartidasProspectadas"))
                CeldaColorNegro(Fila.Cells("Total PR"))
                CeldaColorNegro(Fila.Cells("PR"))


                'Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Black

                ClienteID_aux = Fila.Cells("clie_clienteid").Value
            Next

            Dim ListaClientes = grdNivelCliente.Rows.FirstOrDefault(Function(x) x.Cells("clie_clienteid").Value = ClienteID_aux)

            If IsNothing(ListaClientes) = False Then
                CeldaColorNegro(ListaClientes.Cells("Proy_Ju"))
                CeldaColorNegro(ListaClientes.Cells("Proy_Vi"))
                CeldaColorNegro(ListaClientes.Cells("Proy_Lu"))
                CeldaColorNegro(ListaClientes.Cells("Proy_Ma"))
                CeldaColorNegro(ListaClientes.Cells("Proy_Mi"))

                CeldaColorNegro(ListaClientes.Cells("Usuario"))
                CeldaColorNegro(ListaClientes.Cells("Fecha"))
                CeldaColorNegro(ListaClientes.Cells("PartidasProspectadas"))
                CeldaColorNegro(ListaClientes.Cells("PedidosProspectados"))
                CeldaColorNegro(ListaClientes.Cells("Total PR"))
                CeldaColorNegro(ListaClientes.Cells("PR"))
                'ListaClientes.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                'ListaClientes.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                'ListaClientes.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                'ListaClientes.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                'ListaClientes.Cells("Proy_Mi").Appearance.ForeColor = Color.Black
            End If

        ElseIf grd.Name = "grdNivelPedido" Then

            Dim ListaPartidas = grdNivelPartida.Rows.Where(Function(x) x.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple)

            For Each Fila As UltraGridRow In ListaPartidas

                CeldaColorNegro(Fila.Cells("Proy_Ju"))
                CeldaColorNegro(Fila.Cells("Proy_Vi"))
                CeldaColorNegro(Fila.Cells("Proy_Lu"))
                CeldaColorNegro(Fila.Cells("Proy_Ma"))
                CeldaColorNegro(Fila.Cells("Proy_Mi"))
                CeldaColorNegro(Fila.Cells("Usuario"))
                CeldaColorNegro(Fila.Cells("Fecha"))
                CeldaColorNegro(Fila.Cells("Total PR"))
                CeldaColorNegro(Fila.Cells("PR"))


                'Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                'Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Black
            Next

            Dim ListaClientePedido = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = PedidoSicyID)

            If IsNothing(ListaClientePedido) = False Then
                ClienteID_aux = ListaClientePedido.Cells("clie_clienteid").Value


                CeldaColorNegro(ListaClientePedido.Cells("Proy_Ju"))
                CeldaColorNegro(ListaClientePedido.Cells("Proy_Vi"))
                CeldaColorNegro(ListaClientePedido.Cells("Proy_Lu"))
                CeldaColorNegro(ListaClientePedido.Cells("Proy_Ma"))
                CeldaColorNegro(ListaClientePedido.Cells("Proy_Mi"))
                CeldaColorNegro(ListaClientePedido.Cells("Usuario"))
                CeldaColorNegro(ListaClientePedido.Cells("Fecha"))
                CeldaColorNegro(ListaClientePedido.Cells("PartidasProspectadas"))
                CeldaColorNegro(ListaClientePedido.Cells("Total PR"))
                CeldaColorNegro(ListaClientePedido.Cells("PR"))

                'ListaClientePedido.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                'ListaClientePedido.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                'ListaClientePedido.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                'ListaClientePedido.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                'ListaClientePedido.Cells("Proy_Mi").Appearance.ForeColor = Color.Black


                Dim ListaCliente = grdNivelCliente.Rows.FirstOrDefault(Function(x) x.Cells("clie_clienteid").Value = ClienteID_aux)

                If IsNothing(ListaCliente) = False Then

                    CeldaColorNegro(ListaCliente.Cells("Proy_Ju"))
                    CeldaColorNegro(ListaCliente.Cells("Proy_Vi"))
                    CeldaColorNegro(ListaCliente.Cells("Proy_Lu"))
                    CeldaColorNegro(ListaCliente.Cells("Proy_Ma"))
                    CeldaColorNegro(ListaCliente.Cells("Proy_Mi"))

                    CeldaColorNegro(ListaCliente.Cells("Usuario"))
                    CeldaColorNegro(ListaCliente.Cells("Fecha"))
                    CeldaColorNegro(ListaCliente.Cells("PartidasProspectadas"))
                    CeldaColorNegro(ListaCliente.Cells("PedidosProspectados"))
                    CeldaColorNegro(ListaCliente.Cells("Total PR"))
                    CeldaColorNegro(ListaCliente.Cells("PR"))

                    'ListaCliente.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                    'ListaCliente.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                    'ListaCliente.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                    'ListaCliente.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                    'ListaCliente.Cells("Proy_Mi").Appearance.ForeColor = Color.Black
                End If

            End If

        ElseIf grd.Name = "grdNivelCliente" Then

            Dim ListaCliente = grdNivelCliente.Rows.FirstOrDefault(Function(x) x.Cells("clie_clienteid").Value = ClienteID)

            If IsNothing(ListaCliente) = False Then

                CeldaColorNegro(ListaCliente.Cells("Proy_Ju"))
                CeldaColorNegro(ListaCliente.Cells("Proy_Vi"))
                CeldaColorNegro(ListaCliente.Cells("Proy_Lu"))
                CeldaColorNegro(ListaCliente.Cells("Proy_Ma"))
                CeldaColorNegro(ListaCliente.Cells("Proy_Mi"))
                CeldaColorNegro(ListaCliente.Cells("Usuario"))
                CeldaColorNegro(ListaCliente.Cells("Fecha"))
                CeldaColorNegro(ListaCliente.Cells("PartidasProspectadas"))
                CeldaColorNegro(ListaCliente.Cells("PedidosProspectados"))
                CeldaColorNegro(ListaCliente.Cells("Total PR"))
                CeldaColorNegro(ListaCliente.Cells("PR"))

                'ListaCliente.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                'ListaCliente.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                'ListaCliente.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                'ListaCliente.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                'ListaCliente.Cells("Proy_Mi").Appearance.ForeColor = Color.Black


                Dim ListaPedidos = grdNivelPedido.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = ClienteID And (x.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple))

                If IsNothing(ListaPedidos) = False Then

                    For Each Fila As UltraGridRow In ListaPedidos

                        CeldaColorNegro(Fila.Cells("Proy_Ju"))
                        CeldaColorNegro(Fila.Cells("Proy_Vi"))
                        CeldaColorNegro(Fila.Cells("Proy_Lu"))
                        CeldaColorNegro(Fila.Cells("Proy_Ma"))
                        CeldaColorNegro(Fila.Cells("Proy_Mi"))
                        CeldaColorNegro(Fila.Cells("Usuario"))
                        CeldaColorNegro(Fila.Cells("Fecha"))
                        CeldaColorNegro(Fila.Cells("PartidasProspectadas"))
                        CeldaColorNegro(Fila.Cells("Total PR"))
                        CeldaColorNegro(Fila.Cells("PR"))

                        'Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                        'Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                        'Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                        'Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                        'Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Black

                        Dim ListaPartidas = grdNivelPartida.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = Fila.Cells("PedidoSICY").Value And (x.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple Or x.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple))


                        If IsNothing(ListaPartidas) = False Then

                            For Each FilaPArtida As UltraGridRow In ListaPartidas
                                CeldaColorNegro(FilaPArtida.Cells("Proy_Ju"))
                                CeldaColorNegro(FilaPArtida.Cells("Proy_Vi"))
                                CeldaColorNegro(FilaPArtida.Cells("Proy_Lu"))
                                CeldaColorNegro(FilaPArtida.Cells("Proy_Ma"))
                                CeldaColorNegro(FilaPArtida.Cells("Proy_Mi"))

                                CeldaColorNegro(FilaPArtida.Cells("Usuario"))
                                CeldaColorNegro(FilaPArtida.Cells("Fecha"))
                                CeldaColorNegro(FilaPArtida.Cells("Total PR"))
                                CeldaColorNegro(FilaPArtida.Cells("PR"))


                                'FilaPArtida.Cells("Proy_Ju").Appearance.ForeColor = Color.Black
                                'FilaPArtida.Cells("Proy_Vi").Appearance.ForeColor = Color.Black
                                'FilaPArtida.Cells("Proy_Lu").Appearance.ForeColor = Color.Black
                                'FilaPArtida.Cells("Proy_Ma").Appearance.ForeColor = Color.Black
                                'FilaPArtida.Cells("Proy_Mi").Appearance.ForeColor = Color.Black

                            Next
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub grdNivelPartida_CellChange(sender As Object, e As CellEventArgs) Handles grdNivelPartida.CellChange
        If ActualizandoCheckBox = False Then
            If e.Cell.Column.Key = "Pros_Lu" Or e.Cell.Column.Key = "Pros_Ma" Or e.Cell.Column.Key = "Pros_Mi" Or e.Cell.Column.Key = "Pros_Ju" Or e.Cell.Column.Key = "Pros_Vi" Or e.Cell.Column.Key = "Pros_Sa" Then
                ActualizandoCheckBox = True
                DesmarcarCheckBox(grdNivelPartida, e.Cell.Row, e.Cell)
            End If
            ActualizandoCheckBox = False
        End If
    End Sub

#End Region

#Region "Diseño Grids"

    Private Sub gridClientesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim listColumnasCero As New List(Of String)
        Dim listColumnasNumericas As New List(Of String)
        Dim listTotales As New List(Of SummarySettings)


        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 16 Or n > 31) Then
                If (n > 0) And (n <> 37) And (n <> 38) And (n <> 40) And (n <> 3) And (n <> 5) And (n < 43) Then
                    Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                End If
            Else

                If n > 15 And n < 20 Then
                    If n = 16 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 19 And n < 26 Then
                    If n = 20 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 25 And n < 32 Then
                    If n = 26 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                'If n > 37 And n < 43 Then
                '    If n = 38 Then
                '        Dim NombreColumna As String
                '        NombreColumna = "Proyección"

                '        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    Else
                '        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    End If
                'End If
            End If
        Next


        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            If col.Header.Caption = "Seleccionar" Or col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa" Then
                col.Style = ColumnStyle.CheckBox
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).AllowRowFiltering = DefaultableBoolean.False
                If Edicion = False And (col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa") Then
                    grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            Else
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        Next


        grid.DisplayLayout.Bands(0).Columns("F Cliente").Format = "dd/MM/yyyy"

        grid.DisplayLayout.Bands(0).Columns("F Programación").Format = "dd/MM/yyyy"

        grid.DisplayLayout.Bands(0).Columns("DiasEProg").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CotsP").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CotsN").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoCotizaciones").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ClienteSICY").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("clie_clienteid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ColaboradorEditando").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoPartidasCompletas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("#").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("bloq_prosLu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMa").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosJu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosVi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosSa").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Pedidos").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Partidas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PedidosProspectados").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PartidasProspectadas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Solicitado").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "Solicitado", "Solicitado", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("Solicitado").Format = "###,###,##0"

        grid.DisplayLayout.Bands(0).Columns("TotalInicial").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "TotalInicial", "TotalInicial", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Format = "###,###,##0"
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Header.Caption = "Total Inicial"

        listColumnasNumericas.Add("Cotizaciones")
        listColumnasNumericas.Add("DiasE")
        listColumnasNumericas.Add("Total Atrasado")
        listColumnasNumericas.Add("Total prospecta")
        listColumnasNumericas.Add("Por adelantar")
        listColumnasNumericas.Add("Total")
        listColumnasNumericas.Add("Inventario")
        listColumnasNumericas.Add("BC")
        listColumnasNumericas.Add("RP")
        listColumnasNumericas.Add("Apartado")
        listColumnasNumericas.Add("Proc_Ju")
        listColumnasNumericas.Add("Proc_Vi")
        listColumnasNumericas.Add("Proc_Lu")
        listColumnasNumericas.Add("Proc_Ma")
        listColumnasNumericas.Add("Proc_Mi")
        listColumnasNumericas.Add("Disponible")
        listColumnasNumericas.Add("DisponibleInicial")
        listColumnasNumericas.Add("Proy_Ju")
        listColumnasNumericas.Add("Proy_Vi")
        listColumnasNumericas.Add("Proy_Lu")
        listColumnasNumericas.Add("Proy_Ma")
        listColumnasNumericas.Add("Proy_Mi")
        listColumnasNumericas.Add("Pedidos")
        listColumnasNumericas.Add("Partidas")
        listColumnasNumericas.Add("PedidosProspectados")
        listColumnasNumericas.Add("PartidasProspectadas")
        listColumnasNumericas.Add("Total PR")
        listColumnasNumericas.Add("Inv Proceso")

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If listColumnasNumericas.Contains(col.Header.Caption) Then
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "n0"
                If col.Header.Caption <> "DiasE" Then
                    listTotales.Add(grid.DisplayLayout.Bands(0).Summaries.Add("Total" + col.Header.Caption, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(col.Header.Caption)))
                End If
            End If
        Next



        grid.DisplayLayout.UseFixedHeaders = True
        ''grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        'grid.DisplayLayout.Bands(0).Groups("Seleccionar").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").AllowRowFiltering = DefaultableBoolean.False


        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").Header.Caption = "PC"
        grid.DisplayLayout.Bands(0).Columns("BloqueoEntrega").Header.Caption = "BE"
        grid.DisplayLayout.Bands(0).Columns("Plazo0").Header.Caption = "P-0"
        grid.DisplayLayout.Bands(0).Columns("Cotizaciones").Header.Caption = "COT"
        grid.DisplayLayout.Bands(0).Columns("DiasE").Header.Caption = "Dias E"

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("DisponibleInicial").Header.Caption = "Anterior disponible"

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").Header.Caption = "S"

        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("PedidosProspectados").Header.Caption = "Pedidos PR"
        grid.DisplayLayout.Bands(0).Columns("PartidasProspectadas").Header.Caption = "Partidas PR"

        grid.DisplayLayout.Bands(0).Columns("PR").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("BloqueoEntrega").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Plazo0").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("BC").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("RP").MaxWidth = 50

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").MaxWidth = 25

        grid.DisplayLayout.Bands(0).Columns("Total").MaxWidth = 60

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").MaxWidth = 50

        grid.DisplayLayout.Bands(0).Columns("Cotizaciones").MaxWidth = 35

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Default

        'Dim width As Integer
        'For Each col As UltraGridColumn In grid.Rows.Band.Columns
        '    If col.DataType <> System.Type.GetType("System.Boolean") Then
        '        col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        '        col.CharacterCasing = CharacterCasing.Upper
        '    End If
        '    If Not col.Hidden Then
        '        width += col.Width
        '    End If
        'Next

        listColumnasCero.Add("Total Atrasado")
        listColumnasCero.Add("Total prospecta")
        listColumnasCero.Add("Por adelantar")
        listColumnasCero.Add("Inventario")
        listColumnasCero.Add("BC")
        listColumnasCero.Add("RP")
        listColumnasCero.Add("Apartado")
        listColumnasCero.Add("Proc_Ju")
        listColumnasCero.Add("Proc_Vi")
        listColumnasCero.Add("Proc_Lu")
        listColumnasCero.Add("Proc_Ma")
        listColumnasCero.Add("Proc_Mi")
        listColumnasCero.Add("Proy_Ju")
        listColumnasCero.Add("Proy_Vi")
        listColumnasCero.Add("Proy_Lu")
        listColumnasCero.Add("Proy_Ma")
        listColumnasCero.Add("Proy_Mi")
        listColumnasCero.Add("PedidosProspectados")
        listColumnasCero.Add("PartidasProspectadas")
        listColumnasCero.Add("Inv Proceso")
        Dim UsuarioEditando As String = ""
        For Each Row As UltraGridRow In grid.Rows
            If IsDBNull(Row.Cells("Editando").Value) = True Then
                UsuarioEditando = "-1"
            Else
                UsuarioEditando = Row.Cells("Editando").Value
            End If


            If Row.Cells("Cotizaciones").Value = 0 Then
                Row.Cells("Cotizaciones").Appearance.ForeColor = Color.Transparent
            ElseIf Row.Cells("CotsP").Value = Row.Cells("Cotizaciones").Value Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlTodasCot.BackColor
            ElseIf Row.Cells("CotsP").Value > 0 And Row.Cells("CotsN").Value > 0 Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlAlgunasCot.BackColor
            ElseIf Row.Cells("CotsP").Value = 0 And Row.Cells("Cotizaciones").Value > 0 Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlNingunaCot.BackColor
            End If

            If Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueoEntrega").Value = "S" Or Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PUserUsername And UsuarioEditando <> "-1") Then
                Row.Appearance.BackColor = Color.LightGray
            End If

            If Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueoEntrega").Value = "S" Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PUserUsername And UsuarioEditando <> "-1") Then
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If Row.Cells("bloq_prosLu").Value = 1 Then
                Row.Cells("Pros_Lu").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMa").Value = 1 Then
                Row.Cells("Pros_Ma").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMi").Value = 1 Then
                Row.Cells("Pros_Mi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosJu").Value = 1 Then
                Row.Cells("Pros_Ju").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosVi").Value = 1 Then
                Row.Cells("Pros_Vi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosSa").Value = 1 Then
                Row.Cells("Pros_Sa").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If IsDBNull(Row.Cells("Editando").Value) = False Then
                If Row.Cells("Editando").Value <> "" Then
                    Row.Cells("Editando").Appearance.ForeColor = Color.Red
                End If
            End If

            If Row.Cells("DiasE").Value < 0 Then
                Row.Cells("DiasE").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Total Atrasado").Value > 0 Then
                Row.Cells("Total Atrasado").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Disponible").Value = 0 Then
                Row.Cells("Disponible").Appearance.ForeColor = Color.Red
            End If
            For Each col As String In listColumnasCero
                If Row.Cells(col).Value = 0 Then
                    Row.Cells(col).Appearance.ForeColor = Color.Transparent
                End If
            Next

        Next

        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        For Each tot As SummarySettings In listTotales
            tot.DisplayFormat = "{0:#,##0}"
            tot.Appearance.TextHAlign = HAlign.Right
        Next

    End Sub

    Private Sub gridPedidosDiseño(ByVal grid As UltraGrid)

        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim listColumnasCero As New List(Of String)
        Dim listColumnasNumericas As New List(Of String)
        Dim listTotales As New List(Of SummarySettings)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 51
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 20 Or n > 35) Then
                If (n > 0) And (n < 10 Or n > 11) And (n < 43) And (n <> 3) Then
                    Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                End If
            Else

                If n > 19 And n < 24 Then
                    If n = 20 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 23 And n < 30 Then
                    If n = 24 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 29 And n < 36 Then
                    If n = 30 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                'If n > 35 And n < 41 Then
                '    If n = 36 Then
                '        Dim NombreColumna As String
                '        NombreColumna = "Proyección"

                '        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    Else
                '        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    End If
                'End If
            End If
        Next


        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            If col.Header.Caption = "Seleccionar" Or col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa" Then
                col.Style = ColumnStyle.CheckBox
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).AllowRowFiltering = DefaultableBoolean.False
                If Edicion = False And (col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa") Then
                    grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            Else
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        Next


        grid.DisplayLayout.Bands(0).Columns("F Cliente").Format = "dd/MM/yyyy"

        grid.DisplayLayout.Bands(0).Columns("F Programación").Format = "dd/MM/yyyy"

        grid.DisplayLayout.Bands(0).Columns("DiasEProg").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CotsP").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CotsN").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoCotizaciones").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("clie_clienteid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoEntrega").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Plazo0").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoPartidasCompletas").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("#").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosLu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMa").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosJu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosVi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosSa").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Editando").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Partidas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PartidasProspectadas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Solicitado").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "Solicitado", "Solicitado", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("Solicitado").Format = "###,###,##0"


        grid.DisplayLayout.Bands(0).Columns("TotalInicial").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "TotalInicial", "TotalInicial", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Format = "###,###,##0"
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Header.Caption = "Total Inicial"

        listColumnasNumericas.Add("Cotizaciones")
        listColumnasNumericas.Add("DiasE")
        listColumnasNumericas.Add("Total Atrasado")
        listColumnasNumericas.Add("Total prospecta")
        listColumnasNumericas.Add("Por adelantar")
        listColumnasNumericas.Add("Total")
        listColumnasNumericas.Add("Inventario")
        listColumnasNumericas.Add("BC")
        listColumnasNumericas.Add("RP")
        listColumnasNumericas.Add("Apartado")
        listColumnasNumericas.Add("Proc_Ju")
        listColumnasNumericas.Add("Proc_Vi")
        listColumnasNumericas.Add("Proc_Lu")
        listColumnasNumericas.Add("Proc_Ma")
        listColumnasNumericas.Add("Proc_Mi")
        listColumnasNumericas.Add("Disponible")
        listColumnasNumericas.Add("DisponibleInicial")
        listColumnasNumericas.Add("Proy_Ju")
        listColumnasNumericas.Add("Proy_Vi")
        listColumnasNumericas.Add("Proy_Lu")
        listColumnasNumericas.Add("Proy_Ma")
        listColumnasNumericas.Add("Proy_Mi")
        listColumnasNumericas.Add("Pedidos")
        listColumnasNumericas.Add("Partidas")
        listColumnasNumericas.Add("PedidosProspectados")
        listColumnasNumericas.Add("PartidasProspectadas")
        listColumnasNumericas.Add("Total PR")
        listColumnasNumericas.Add("Inv Proceso")

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If listColumnasNumericas.Contains(col.Header.Caption) Then
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "n0"
                If col.Header.Caption <> "DiasE" Then
                    listTotales.Add(grid.DisplayLayout.Bands(0).Summaries.Add("Total" + col.Header.Caption, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(col.Header.Caption)))
                End If
            End If
        Next

        grid.DisplayLayout.UseFixedHeaders = True
        ''grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        'grid.DisplayLayout.Bands(0).Groups("Seleccionar").Header.Fixed = True
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").AllowRowFiltering = DefaultableBoolean.False


        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").Header.Caption = "PC"
        grid.DisplayLayout.Bands(0).Columns("BloqueadoEntrega").Header.Caption = "BE"
        grid.DisplayLayout.Bands(0).Columns("Plazo0").Header.Caption = "P-0"
        grid.DisplayLayout.Bands(0).Columns("Cotizaciones").Header.Caption = "COT"
        grid.DisplayLayout.Bands(0).Columns("DiasE").Header.Caption = "Dias E"

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("DisponibleInicial").Header.Caption = "Anterior disponible"

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").Header.Caption = "S"

        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("PartidasProspectadas").Header.Caption = "Partidas PR"


        grid.DisplayLayout.Bands(0).Columns("PR").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").MaxWidth = 25
        'grid.DisplayLayout.Bands(0).Columns("BloqueoEntrega").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Plazo0").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("BC").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("RP").MaxWidth = 50

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").MaxWidth = 25

        grid.DisplayLayout.Bands(0).Columns("Total").MaxWidth = 60

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").MaxWidth = 50

        grid.DisplayLayout.Bands(0).Columns("Cotizaciones").MaxWidth = 35

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Default

        listColumnasCero.Add("Total Atrasado")
        listColumnasCero.Add("Total prospecta")
        listColumnasCero.Add("Por adelantar")
        listColumnasCero.Add("Inventario")
        listColumnasCero.Add("BC")
        listColumnasCero.Add("RP")
        listColumnasCero.Add("Apartado")
        listColumnasCero.Add("Proc_Ju")
        listColumnasCero.Add("Proc_Vi")
        listColumnasCero.Add("Proc_Lu")
        listColumnasCero.Add("Proc_Ma")
        listColumnasCero.Add("Proc_Mi")
        listColumnasCero.Add("Proy_Ju")
        listColumnasCero.Add("Proy_Vi")
        listColumnasCero.Add("Proy_Lu")
        listColumnasCero.Add("Proy_Ma")
        listColumnasCero.Add("Proy_Mi")
        listColumnasCero.Add("PartidasProspectadas")
        listColumnasCero.Add("Inv Proceso")
        Dim UsuarioEditando As String = ""
        For Each Row As UltraGridRow In grid.Rows
            If IsDBNull(Row.Cells("Editando").Value) = True Then
                UsuarioEditando = "-1"
            Else
                If Row.Cells("Editando").Value = 0 Then
                    UsuarioEditando = "-1"
                Else
                    UsuarioEditando = Row.Cells("Editando").Value
                End If
            End If

            If Row.Cells("Cotizaciones").Value = 0 Then
                Row.Cells("Cotizaciones").Appearance.ForeColor = Color.Transparent
            ElseIf Row.Cells("CotsP").Value = Row.Cells("Cotizaciones").Value Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlTodasCot.BackColor
            ElseIf Row.Cells("CotsP").Value > 0 And Row.Cells("CotsN").Value > 0 Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlAlgunasCot.BackColor
            ElseIf Row.Cells("CotsP").Value = 0 And Row.Cells("Cotizaciones").Value > 0 Then
                Row.Cells("Cotizaciones").Appearance.BackColor = pnlNingunaCot.BackColor
            End If

            If Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueadoEntrega").Value = 1 Or Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser And UsuarioEditando <> "-1") Then
                Row.Appearance.BackColor = Color.LightGray
            End If

            If Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueadoEntrega").Value = 1 Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser And UsuarioEditando <> "-1") Then
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If


            If Row.Cells("bloq_prosLu").Value = 1 Then
                Row.Cells("Pros_Lu").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMa").Value = 1 Then
                Row.Cells("Pros_Ma").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMi").Value = 1 Then
                Row.Cells("Pros_Mi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosJu").Value = 1 Then
                Row.Cells("Pros_Ju").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosVi").Value = 1 Then
                Row.Cells("Pros_Vi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosSa").Value = 1 Then
                Row.Cells("Pros_Sa").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If


            If Row.Cells("DiasE").Value < 0 Then
                Row.Cells("DiasE").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Total Atrasado").Value > 0 Then
                Row.Cells("Total Atrasado").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Disponible").Value = 0 Then
                Row.Cells("Disponible").Appearance.ForeColor = Color.Red
            End If
            For Each col As String In listColumnasCero
                If Row.Cells(col).Value = 0 Then
                    Row.Cells(col).Appearance.ForeColor = Color.Transparent
                End If
            Next

        Next

        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        For Each tot As SummarySettings In listTotales
            tot.DisplayFormat = "{0:#,##0}"
            tot.Appearance.TextHAlign = HAlign.Right
        Next



    End Sub

    Private Sub gridPartidasDiseño(ByVal grid As UltraGrid)

        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim listColumnasCero As New List(Of String)
        Dim listColumnasNumericas As New List(Of String)
        Dim listTotales As New List(Of SummarySettings)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas


        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            'If tipoDistribucion = 0 Then
            UltimaColumna = 50
            'Else
            '    UltimaColumna = 47
            'End If

            If (n < 18 Or n > 33) Then
                If (n > 2) And (n <> 11) And (n < 41) Then
                    Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                End If
            Else

                If n > 17 And n < 22 Then
                    If n = 18 Then
                        Dim NombreColumna As String
                        NombreColumna = "En existencia"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("En existencia")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 21 And n < 28 Then
                    If n = 22 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario en producción"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario en producción")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                If n > 27 And n < 34 Then
                    If n = 28 Then
                        Dim NombreColumna As String
                        NombreColumna = "Entrega"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Entrega")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                'If n > 34 And n < 40 Then
                '    If n = 35 Then
                '        Dim NombreColumna As String
                '        NombreColumna = "Proyección"

                '        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna)
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    Else
                '        Dim Grupo As UltraGridGroup = rootBand.Groups("Proyección")
                '        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                '    End If
                'End If
            End If
        Next


        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            If col.Header.Caption = "Seleccionar" Or col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa" Then
                col.Style = ColumnStyle.CheckBox
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).AllowRowFiltering = DefaultableBoolean.False
                If Edicion = False And (col.Header.Caption = "Pros_Lu" Or col.Header.Caption = "Pros_Ma" Or col.Header.Caption = "Pros_Mi" Or col.Header.Caption = "Pros_Ju" Or col.Header.Caption = "Pros_Vi" Or col.Header.Caption = "Pros_Sa") Then
                    grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            Else
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        Next


        'grid.DisplayLayout.Bands(0).Columns("F Cliente").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("F Programación").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("F Entrega").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("DiasEProg").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoCotizaciones").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("clie_clienteid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoEntrega").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Plazo0").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("TotalCotizaciones").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoPartidasCompletas").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("#").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosLu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMa").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosMi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosJu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosVi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("bloq_prosSa").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Editando").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("Cliente").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Solicitado").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "Solicitado", "Solicitado", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("Solicitado").Format = "###,###,##0"

        grid.DisplayLayout.Bands(0).Columns("TotalInicial").CellAppearance.TextHAlign = HAlign.Right
        SumarizarColumnaGrid(grid, "TotalInicial", "TotalInicial", SummaryType.Sum)
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Format = "###,###,##0"
        grid.DisplayLayout.Bands(0).Columns("TotalInicial").Header.Caption = "Total Inicial"

        listColumnasNumericas.Add("Cotizaciones")
        listColumnasNumericas.Add("DiasE")
        listColumnasNumericas.Add("Total Atrasado")
        listColumnasNumericas.Add("Total prospecta")
        listColumnasNumericas.Add("Por adelantar")
        listColumnasNumericas.Add("Total")
        listColumnasNumericas.Add("Inventario")
        listColumnasNumericas.Add("BC")
        listColumnasNumericas.Add("RP")
        listColumnasNumericas.Add("Apartado")
        listColumnasNumericas.Add("Proc_Ju")
        listColumnasNumericas.Add("Proc_Vi")
        listColumnasNumericas.Add("Proc_Lu")
        listColumnasNumericas.Add("Proc_Ma")
        listColumnasNumericas.Add("Proc_Mi")
        listColumnasNumericas.Add("Disponible")
        listColumnasNumericas.Add("DisponibleInicial")
        listColumnasNumericas.Add("Proy_Ju")
        listColumnasNumericas.Add("Proy_Vi")
        listColumnasNumericas.Add("Proy_Lu")
        listColumnasNumericas.Add("Proy_Ma")
        listColumnasNumericas.Add("Proy_Mi")
        listColumnasNumericas.Add("Pedidos")
        listColumnasNumericas.Add("Partidas")
        listColumnasNumericas.Add("PedidosProspectados")
        listColumnasNumericas.Add("PartidasProspectadas")
        listColumnasNumericas.Add("Total PR")
        listColumnasNumericas.Add("Inv Proceso")

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If listColumnasNumericas.Contains(col.Header.Caption) Then
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "n0"
                If col.Header.Caption <> "DiasE" Then
                    listTotales.Add(grid.DisplayLayout.Bands(0).Summaries.Add("Total" + col.Header.Caption, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(col.Header.Caption)))
                End If
            End If
        Next

        grid.DisplayLayout.UseFixedHeaders = True
        ''grid.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        'grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        ''grid.DisplayLayout.Bands(0).Groups("Seleccionar").Header.Fixed = True
        'grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        'grid.DisplayLayout.Bands(0).Columns("Seleccionar").AllowRowFiltering = DefaultableBoolean.False


        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").Header.Caption = "PC"
        grid.DisplayLayout.Bands(0).Columns("BloqueadoEntrega").Header.Caption = "BE"
        grid.DisplayLayout.Bands(0).Columns("Plazo0").Header.Caption = "P-0"
        'grid.DisplayLayout.Bands(0).Columns("Cotizaciones").Header.Caption = "COT"
        grid.DisplayLayout.Bands(0).Columns("DiasE").Header.Caption = "Dias E"

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("DisponibleInicial").Header.Caption = "Anterior disponible"

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").Header.Caption = "S"

        grid.DisplayLayout.Bands(0).Columns("Proy_Ju").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("Proy_Vi").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("Proy_Lu").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("Proy_Ma").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("Proy_Mi").Header.Caption = "M"

        grid.DisplayLayout.Bands(0).Columns("Partida").CellAppearance.TextHAlign = HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("Partida").MaxWidth = 40

        grid.DisplayLayout.Bands(0).Columns("PR").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("PartidasCompletas").MaxWidth = 25
        'grid.DisplayLayout.Bands(0).Columns("BloqueoEntrega").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Plazo0").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("BC").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("RP").MaxWidth = 50

        grid.DisplayLayout.Bands(0).Columns("Pros_Lu").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ma").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Mi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Ju").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Vi").MaxWidth = 25
        grid.DisplayLayout.Bands(0).Columns("Pros_Sa").MaxWidth = 25

        grid.DisplayLayout.Bands(0).Columns("Total").MaxWidth = 60

        grid.DisplayLayout.Bands(0).Columns("Proc_Ju").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Vi").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Lu").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Ma").MaxWidth = 50
        grid.DisplayLayout.Bands(0).Columns("Proc_Mi").MaxWidth = 50

        'grid.DisplayLayout.Bands(0).Columns("Cotizaciones").MaxWidth = 35

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Default

        listColumnasCero.Add("Total Atrasado")
        listColumnasCero.Add("Total prospecta")
        listColumnasCero.Add("Por adelantar")
        listColumnasCero.Add("Inventario")
        listColumnasCero.Add("BC")
        listColumnasCero.Add("RP")
        listColumnasCero.Add("Apartado")
        listColumnasCero.Add("Proc_Ju")
        listColumnasCero.Add("Proc_Vi")
        listColumnasCero.Add("Proc_Lu")
        listColumnasCero.Add("Proc_Ma")
        listColumnasCero.Add("Proc_Mi")
        listColumnasCero.Add("Proy_Ju")
        listColumnasCero.Add("Proy_Vi")
        listColumnasCero.Add("Proy_Lu")
        listColumnasCero.Add("Proy_Ma")
        listColumnasCero.Add("Proy_Mi")
        listColumnasCero.Add("Inv Proceso")
        'listColumnasCero.Add("PartidasProspectadas")
        Dim UsuarioEditando As String = ""
        For Each Row As UltraGridRow In grid.Rows
            If IsDBNull(Row.Cells("Editando").Value) = True Then
                UsuarioEditando = "-1"
            Else
                If Row.Cells("Editando").Value = 0 Then
                    UsuarioEditando = "-1"
                Else
                    UsuarioEditando = Row.Cells("Editando").Value
                End If

            End If
            'If Row.Cells("Cotizaciones").Value = 0 Then
            '    Row.Cells("Cotizaciones").Appearance.ForeColor = Color.Transparent
            'ElseIf Row.Cells("CotsP").Value = Row.Cells("Cotizaciones").Value Then
            '    Row.Cells("Cotizaciones").Appearance.BackColor = pnlTodasCot.BackColor
            'ElseIf Row.Cells("CotsP").Value > 0 And Row.Cells("CotsN").Value > 0 Then
            '    Row.Cells("Cotizaciones").Appearance.BackColor = pnlAlgunasCot.BackColor
            'ElseIf Row.Cells("CotsP").Value = 0 And Row.Cells("Cotizaciones").Value > 0 Then
            '    Row.Cells("Cotizaciones").Appearance.BackColor = pnlNingunaCot.BackColor
            'End If
            '
            If Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueadoEntrega").Value = True Or (Row.Cells("PartidasCompletas").Value = True And Row.Cells("Total").Value > Row.Cells("Disponible").Value) Or Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser And UsuarioEditando <> "-1") Then
                Row.Appearance.BackColor = Color.LightGray
            End If

            If Row.Cells("BloqueadoCotizaciones").Value = 1 Or Row.Cells("BloqueadoEntrega").Value = True Or (Row.Cells("PartidasCompletas").Value = True And Row.Cells("Total").Value > Row.Cells("Disponible").Value) Or Row.Cells("Disponible").Value = 0 Or Row.Cells("BloqueadoPartidasCompletas").Value = 1 Or (UsuarioEditando <> Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser And UsuarioEditando <> "-1") Then
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If Row.Cells("bloq_prosLu").Value = 1 Then
                Row.Cells("Pros_Lu").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Lu").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMa").Value = 1 Then
                Row.Cells("Pros_Ma").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ma").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosMi").Value = 1 Then
                Row.Cells("Pros_Mi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Mi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosJu").Value = 1 Then
                Row.Cells("Pros_Ju").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Ju").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosVi").Value = 1 Then
                Row.Cells("Pros_Vi").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Vi").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            If Row.Cells("bloq_prosSa").Value = 1 Then
                Row.Cells("Pros_Sa").Appearance.BackColor = Color.LightGray
                Row.Cells("Pros_Sa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If Row.Cells("DiasE").Value < 0 Then
                Row.Cells("DiasE").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Total Atrasado").Value > 0 Then
                Row.Cells("Total Atrasado").Appearance.ForeColor = Color.Red
            End If
            If Row.Cells("Disponible").Value = 0 Then
                Row.Cells("Disponible").Appearance.ForeColor = Color.Red
            End If
            For Each col As String In listColumnasCero
                If Row.Cells(col).Value = 0 Then
                    Row.Cells(col).Appearance.ForeColor = Color.Transparent
                End If
            Next

        Next

        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        For Each tot As SummarySettings In listTotales
            tot.DisplayFormat = "{0:#,##0}"
            tot.Appearance.TextHAlign = HAlign.Right
        Next



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

    Private Sub gridParesDiariosDiseño(ByVal grid As UltraGrid)

        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            grid.DisplayLayout.Bands(0).Columns(col.Key).CellAppearance.FontData.SizeInPoints = 7
            col.Header.Appearance.FontData.SizeInPoints = 7
        Next

        grid.DisplayLayout.Bands(0).Columns("Concepto").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("EntregarLunes").Header.Caption = "L"
        grid.DisplayLayout.Bands(0).Columns("EntregarMartes").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("EntregarMiercoles").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("EntregarJueves").Header.Caption = "J"
        grid.DisplayLayout.Bands(0).Columns("EntregarViernes").Header.Caption = "V"
        grid.DisplayLayout.Bands(0).Columns("EntregarSabado").Header.Caption = "S"

        grid.DisplayLayout.Bands(0).Columns("Concepto").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarLunes").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarLunes").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarLunes").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarMartes").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarMartes").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarMartes").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarMiercoles").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarMiercoles").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarMiercoles").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarJueves").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarJueves").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarJueves").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarViernes").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarViernes").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarViernes").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntregarSabado").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("EntregarSabado").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("EntregarSabado").CellActivation = Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Total").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total").CellActivation = Activation.NoEdit


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        For Each row As UltraGridRow In grid.Rows
            row.Cells("Concepto").Value = Replace(row.Cells("Concepto").Value, "1 ", "")
            row.Cells("Concepto").Value = Replace(row.Cells("Concepto").Value, "2 ", "")
            row.Cells("Concepto").Value = Replace(row.Cells("Concepto").Value, "3 ", "")
        Next

    End Sub

#End Region


    Private Sub btnSeguimietoPares_Click(sender As Object, e As EventArgs) Handles btnSeguimietoPares.Click
        Dim punto As Point
        punto.X = btnSeguimietoPares.Location.X + btnSeguimietoPares.Width
        punto.Y = btnSeguimietoPares.Location.Y + btnSeguimietoPares.Height
        cmsTiposResumen.Show(punto)
    End Sub

    Private Sub tmsiReproceso_Click(sender As Object, e As EventArgs) Handles tmsiReproceso.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New ResumenProspecta
            ventana.tipoConsulta = 4
            ventana.ProspectaID = ProspectaID
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsmiApartados_Click(sender As Object, e As EventArgs) Handles tsmiApartados.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New ResumenProspecta
            ventana.tipoConsulta = 1
            ventana.ProspectaID = ProspectaID
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsmiBloqueados_Click(sender As Object, e As EventArgs) Handles tsmiBloqueados.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New ResumenProspecta
            ventana.tipoConsulta = 3
            ventana.ProspectaID = ProspectaID
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsmiProduccion_Click(sender As Object, e As EventArgs) Handles tsmiProduccion.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New ResumenProspecta
            ventana.tipoConsulta = 2
            ventana.ProspectaID = ProspectaID
            ventana.FechaInicioProspecta = dtmFechaInicio.Value
            ventana.FechaFinProspecta = dtmFechaFin.Value
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub AgendaEntregasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaDeEntregasToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New AgendaEntregasForm
            ventana.TipoAgenda = 1
            ventana.ProspectaID = ProspectaID
            ventana.FechaInicioProspecta = dtmFechaInicio.Value
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub AgendaProyecciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaProyecciónToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim ventana As New AgendaEntregasForm
            ventana.TipoAgenda = 2
            ventana.ProspectaID = ProspectaID
            ventana.FechaInicioProspecta = dtmFechaInicio.Value
            ventana.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnSeguimientoClientes_Click(sender As Object, e As EventArgs) Handles btnSeguimientoClientes.Click
        Cursor = Cursors.WaitCursor
        Dim ventana As New ClientesCitaForm
        ventana.ProspectaID = ProspectaID
        ventana.Show()
        Cursor = Cursors.Default
    End Sub


    Private Sub btnAgenda_Click(sender As Object, e As EventArgs) Handles btnAgenda.Click
        Dim punto As Point
        punto.X = btnAgenda.Location.X + btnAgenda.Width
        punto.Y = btnAgenda.Location.Y + btnAgenda.Height
        cmdTipoAgenda.Show(punto)
    End Sub



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim DtProspecta As DataTable
        Dim FechaInicio As Date = dtmFechaInicio.Value
        Dim FechaFin As Date = dtmFechaFin.Value
        Dim dtResultadoValidacionSemana As New DataTable

        Try
            dtResultadoValidacionSemana = objProspecta.ValidaSemanaProspecta(nudNumSemana.Value, nudAño.Value)

            If dtResultadoValidacionSemana.Rows(0).Item("Mensaje").ToString = "" Then

                Me.Cursor = Cursors.WaitCursor

                If grdNivelCliente.Rows.Count = 0 Then
                    show_message("Advertencia", "No se puede guardar debido a que no se ha cargado la información.")
                Else
                    If ProspectaID = -1 Then
                        DtProspecta = objProspecta.AltaProspecta(nudNumSemana.Value, nudAño.Value, FechaInicio, FechaFin, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        If DtProspecta.Rows.Count > 0 Then
                            ProspectaID = DtProspecta.Rows(0).Item(0).ToString
                            ' objProspecta.ActualizarEncabezadoProspecta(ProspectaID)
                        End If

                    End If

                    nudNumSemana.Enabled = False
                    nudAño.Enabled = False
                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False
                    btnEditar.Enabled = True

                    btnActualizarStatus.Text = "Revisión"
                    SiguienteStatus = 90
                    btnActualizarStatus.Visible = True

                    show_message("Exito", "Se ha guardado la prospecta correctamente.")
                End If


                Me.Cursor = Cursors.Default

            Else
                show_message("Advertencia", dtResultadoValidacionSemana.Rows(0).Item("Mensaje").ToString)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 24
        spcPedidos.SplitterDistance = 20
        For Each row As UltraGridRow In grdNivelPedido.Rows
            If CBool(row.Cells("Seleccionar").Value) = True Then
                seleccionados += 1
            End If
        Next
        If seleccionados = 0 Then
            sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 193
        spcPedidos.SplitterDistance = 20
        For Each row As UltraGridRow In grdNivelPedido.Rows
            If CBool(row.Cells("Seleccionar").Value) = True Then
                seleccionados += 1
            End If
        Next
        If seleccionados = 0 Then
            sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
        End If
    End Sub

    Private Sub CargarInformacionProspecta()
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim obj As New Entidades.ProspectaInformacion

        obj = objProspecta.CargarInformacionProspecta(ProspectaID)

        If IsNothing(obj) = False Then
            nudAño.Value = obj.Año
            nudNumSemana.Value = obj.NumeroSemana
            dtmFechaInicio.Value = obj.FechaInicio
            dtmFechaFin.Value = obj.FechaFin
            txtStatusProspecta.Text = obj.EstatusProspecta
            IdEstadoProspecta = obj.IDEstatusProspecta
            Select Case IdEstadoProspecta
                Case 87

                    btnActualizarStatus.Text = "Revisión"
                    SiguienteStatus = 90
                    btnActualizarStatus.Visible = True
                    'btnActualizarStatus.Text = "Vigente"
                    'SiguienteStatus = 88

                Case 90
                    btnActualizarStatus.Text = "Vigente"
                    SiguienteStatus = 88
                    btnActualizarStatus.Visible = True
                    '  btnEditar.Enabled = False
                    'Case 88
                    '    btnActualizarStatus.Text = "Cerrada"
                    '    SiguienteStatus = 89
                Case Else
                    btnActualizarStatus.Visible = False
                    SiguienteStatus = 0
            End Select
            nudAño.Enabled = False
            nudNumSemana.Enabled = False

            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(obj.ProspectaID)
            gridParesDiariosDiseño(grdResumenDiario)

        End If


    End Sub

    Public Sub DesmarcarCheckBox(ByVal grd As UltraGrid, ByVal Fila As UltraGridRow, ByVal ColumnaChecada As UltraGridCell)

        If CBool(ColumnaChecada.Text).ToString = "True" Then
            If grd.Name = "grdNivelPartida" Then
                Fila.Cells("Pros_Lu").Value = False
                Fila.Cells("Pros_Ma").Value = False
                Fila.Cells("Pros_Mi").Value = False
                Fila.Cells("Pros_Ju").Value = False
                Fila.Cells("Pros_Vi").Value = False
                Fila.Cells("Pros_Sa").Value = False

                ColumnaChecada.Value = True

                AsignarParesProyectarDia(grd, Fila, ColumnaChecada)

            Else
                Fila.Cells("Pros_Lu").Value = 0
                Fila.Cells("Pros_Ma").Value = 0
                Fila.Cells("Pros_Mi").Value = 0
                Fila.Cells("Pros_Ju").Value = 0
                Fila.Cells("Pros_Vi").Value = 0
                Fila.Cells("Pros_Sa").Value = 0

                ColumnaChecada.Value = 1
                AsignarParesProyectarDia(grd, Fila, ColumnaChecada)
            End If




            If grd.Name = "grdNivelCliente" Then
                'If IsNothing(grdPedidos) = False Then
                '    Dim Listas1 = grdPedidos.Rows.Where(Function(x) x.Cells("ClienteID2").Value = Fila.Cells("ClienteID").Value)                    
                'End If
                ActualizarCheckBoxPartidasGrid(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                ActualizarCheckBoxPartidasGridOculto(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                ActualizarCheckBoxPedidoGrid(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                AsignarParesProyectarDiaNivelCliente(Fila, "clie_clienteid", grd.Name)
            ElseIf grd.Name = "grdNivelPedido" Then
                Dim Listas = grdNivelPedido.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = Fila.Cells("PedidoSICY").Value)
                ActualizarCheckBoxPartidasxPedidoGrid(Fila.Cells("PedidoSICY").Value, ColumnaChecada)
                ActualizarCheckBoxPartidasxPedidoGridOculto(Fila.Cells("PedidoSICY").Value, ColumnaChecada)
                ActualizarCheckBoxCliente(Fila.Cells("clie_clienteid").Value)
                AsignarParesProyectarDiaNivelCliente(Fila, "clie_clienteid", grd.Name)
                AsignarParesProyectarDiaNivelPedido(Fila, "PedidoSICY")
            ElseIf grd.Name = "grdNivelPartida" Then
                ActualizarCheckBoxPartidasGridOcultoNivelPartida(Fila.Cells("PedidoSICY").Value, Fila.Cells("Partida").Value, ColumnaChecada)
                ActualizarCheckBoxPedido(Fila.Cells("PedidoSICY").Value)
                ActualizarCheckBoxCliente(Fila.Cells("clie_clienteid").Value)

                Dim FilaPartida As UltraGridRow = grdNivelPartidaOculto.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = Fila.Cells("PedidoSICY").Value And x.Cells("Partida").Value = Fila.Cells("Partida").Value)



                If IsNothing(FilaPartida) = False Then
                    FilaPartida.Cells("ColumnaModificada").Value = 1
                End If

            End If

        ElseIf CBool(ColumnaChecada.Text).ToString = "False" Then
            ColumnaChecada.Value = 0
            If grd.Name = "grdNivelCliente" Then
                ActualizarCheckBoxPartidasGrid(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                ActualizarCheckBoxPartidasGridOculto(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                ActualizarCheckBoxPedidoGrid(Fila.Cells("clie_clienteid").Value, ColumnaChecada)
                AsignarParesProyectarDiaNivelCliente(Fila, "clie_clienteid", grd.Name)
                'If IsNothing(grdNivelPedido) = False And grdNivelPedido.Rows.Count > 0 Then
                '    AsignarParesProyectarDiaNivelPedido(Fila, "clie_clienteid")
                'End If
            ElseIf grd.Name = "grdNivelPedido" Then
                ActualizarCheckBoxPartidasxPedidoGrid(Fila.Cells("PedidoSICY").Value, ColumnaChecada)
                ActualizarCheckBoxPartidasxPedidoGridOculto(Fila.Cells("PedidoSICY").Value, ColumnaChecada)
                ActualizarCheckBoxCliente(Fila.Cells("clie_clienteid").Value)
                AsignarParesProyectarDiaNivelCliente(Fila, "clie_clienteid", grd.Name)
                AsignarParesProyectarDiaNivelPedido(Fila, "PedidoSICY")
            ElseIf grd.Name = "grdNivelPartida" Then
                ActualizarCheckBoxPartidasGridOcultoNivelPartida(Fila.Cells("PedidoSICY").Value, Fila.Cells("Partida").Value, ColumnaChecada)
                AsignarParesProyectarDia(grd, Fila, ColumnaChecada)
                ActualizarCheckBoxPedido(Fila.Cells("PedidoSICY").Value)
                ActualizarCheckBoxCliente(Fila.Cells("clie_clienteid").Value)
                Dim FilaPartida As UltraGridRow = grdNivelPartidaOculto.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = Fila.Cells("PedidoSICY").Value And x.Cells("Partida").Value = Fila.Cells("Partida").Value)

                If IsNothing(FilaPartida) = False Then
                    FilaPartida.Cells("ColumnaModificada").Value = 1
                End If
            End If


        End If

    End Sub

    Public Sub ActualizarCheckBoxPedido(ByVal PedidoID As Integer)
        Dim ListaColumnasMarcadas As New List(Of String)

        Dim Lista = grdNivelPartida.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = PedidoID)

        For Each Fila As UltraGridRow In Lista

            If Fila.Cells("PedidoSICY").Value = PedidoID Then

                If CBool(Fila.Cells("Pros_Lu").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Lu") = False Then
                        ListaColumnasMarcadas.Add("Pros_Lu")
                    End If
                End If

                If CBool(Fila.Cells("Pros_Ma").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Ma") = False Then
                        ListaColumnasMarcadas.Add("Pros_Ma")
                    End If
                End If

                If CBool(Fila.Cells("Pros_Mi").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Mi") = False Then
                        ListaColumnasMarcadas.Add("Pros_Mi")
                    End If
                End If

                If CBool(Fila.Cells("Pros_Ju").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Ju") = False Then
                        ListaColumnasMarcadas.Add("Pros_Ju")
                    End If
                End If

                If CBool(Fila.Cells("Pros_Vi").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Vi") = False Then
                        ListaColumnasMarcadas.Add("Pros_Vi")
                    End If
                End If

                If CBool(Fila.Cells("Pros_Sa").Value) = True Then
                    If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Sa") = False Then
                        ListaColumnasMarcadas.Add("Pros_Sa")
                    End If
                End If
            End If
        Next




        If ListaColumnasMarcadas.Count > 0 Then
            Dim FilaPedido As UltraGridRow = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = PedidoID)
            If IsNothing(FilaPedido) = False Then
                FilaPedido.Cells("Pros_Lu").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Lu"))
                FilaPedido.Cells("Pros_Ma").Value = 0
                ' AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Ma"))
                FilaPedido.Cells("Pros_Mi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Mi"))
                FilaPedido.Cells("Pros_Ju").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Ju"))
                FilaPedido.Cells("Pros_Vi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Vi"))
                FilaPedido.Cells("Pros_Sa").Value = 0
                ' AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Sa"))
                For Each NombreColumna As String In ListaColumnasMarcadas
                    FilaPedido.Cells(NombreColumna).Value = 1
                    'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells(NombreColumna))
                Next

                AsignarParesProyectarDiaNivelCliente(FilaPedido, "PedidoSICY", "grdNivelPedido")
            End If
        Else
            Dim FilaPedido As UltraGridRow = grdNivelPedido.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = PedidoID)
            If IsNothing(FilaPedido) = False Then
                FilaPedido.Cells("Pros_Lu").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Lu"))
                FilaPedido.Cells("Pros_Ma").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Ma"))
                FilaPedido.Cells("Pros_Mi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Mi"))
                FilaPedido.Cells("Pros_Ju").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Ju"))
                FilaPedido.Cells("Pros_Vi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Vi"))
                FilaPedido.Cells("Pros_Sa").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelPedido, FilaPedido, FilaPedido.Cells("Pros_Sa"))

                AsignarParesProyectarDiaNivelCliente(FilaPedido, "PedidoSICY", "grdNivelPedido")
            End If
        End If

    End Sub


    Public Sub ActualizarCheckBoxCliente(ByVal ClienteID As Integer)
        Dim ListaColumnasMarcadas As New List(Of String)


        Dim Lista = grdNivelPedido.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = ClienteID)

        For Each Fila As UltraGridRow In Lista

            If Fila.Cells("Pros_Lu").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Lu") = False Then
                    ListaColumnasMarcadas.Add("Pros_Lu")
                End If
            End If

            If Fila.Cells("Pros_Ma").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Ma") = False Then
                    ListaColumnasMarcadas.Add("Pros_Ma")
                End If
            End If

            If Fila.Cells("Pros_Mi").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Mi") = False Then
                    ListaColumnasMarcadas.Add("Pros_Mi")
                End If
            End If

            If Fila.Cells("Pros_Ju").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Ju") = False Then
                    ListaColumnasMarcadas.Add("Pros_Ju")
                End If
            End If

            If Fila.Cells("Pros_Vi").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Vi") = False Then
                    ListaColumnasMarcadas.Add("Pros_Vi")
                End If
            End If

            If Fila.Cells("Pros_Sa").Value = 1 Then
                If ListaColumnasMarcadas.Exists(Function(x) x = "Pros_Sa") = False Then
                    ListaColumnasMarcadas.Add("Pros_Sa")
                End If
            End If

        Next





        If ListaColumnasMarcadas.Count > 0 Then
            Dim FilaCliente As UltraGridRow = grdNivelCliente.Rows.FirstOrDefault(Function(x) x.Cells("clie_clienteid").Value = ClienteID)
            If IsNothing(FilaCliente) = False Then
                FilaCliente.Cells("Pros_Lu").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Lu"))
                FilaCliente.Cells("Pros_Ma").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Ma"))
                FilaCliente.Cells("Pros_Mi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Mi"))
                FilaCliente.Cells("Pros_Ju").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Ju"))
                FilaCliente.Cells("Pros_Vi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Vi"))
                FilaCliente.Cells("Pros_Sa").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Sa"))
                For Each NombreColumna As String In ListaColumnasMarcadas
                    FilaCliente.Cells(NombreColumna).Value = 1
                    'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells(NombreColumna))
                Next
                AsignarParesProyectarDiaNivelCliente(FilaCliente, "clie_clienteid", "grdNivelCliente")
            End If
        Else
            Dim FilaCliente As UltraGridRow = grdNivelCliente.Rows.FirstOrDefault(Function(x) x.Cells("clie_clienteid").Value = ClienteID)
            If IsNothing(FilaCliente) = False Then
                FilaCliente.Cells("Pros_Lu").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Lu"))
                FilaCliente.Cells("Pros_Ma").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Ma"))
                FilaCliente.Cells("Pros_Mi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Mi"))
                FilaCliente.Cells("Pros_Ju").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Ju"))
                FilaCliente.Cells("Pros_Vi").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Vi"))
                FilaCliente.Cells("Pros_Sa").Value = 0
                'AsignarParesProyectarDiaNivelesSuperiores(grdNivelCliente, FilaCliente, FilaCliente.Cells("Pros_Sa"))
                AsignarParesProyectarDiaNivelCliente(FilaCliente, "clie_clienteid", "grdNivelCliente")
            End If
        End If

    End Sub

    Public Sub ActualizarCheckBoxPedidoGrid(ByVal ClienteSayID As Integer, ByVal ColumnaChecada As UltraGridCell)
        If IsNothing(grdNivelPedido) = False Then
            If grdNivelPedido.Rows.Count > 0 Then

                Dim Lista = grdNivelPedido.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = ClienteSayID)

                For Each FilaPedido As UltraGridRow In Lista


                    If FilaPedido.Cells("Disponible").Value > 0 And FilaPedido.Appearance.BackColor <> Color.LightGray Then

                        If CBool(ColumnaChecada.Value) = True Then
                            FilaPedido.Cells("Pros_Lu").Value = 0
                            FilaPedido.Cells("Pros_Ma").Value = 0
                            FilaPedido.Cells("Pros_Mi").Value = 0
                            FilaPedido.Cells("Pros_Ju").Value = 0
                            FilaPedido.Cells("Pros_Vi").Value = 0
                            FilaPedido.Cells("Pros_Sa").Value = 0
                            If CBool(ColumnaChecada.Value) = True Then
                                If FilaPedido.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                    FilaPedido.Cells(ColumnaChecada.Column.Key).Value = 1
                                End If
                            Else
                                FilaPedido.Cells(ColumnaChecada.Column.Key).Value = 0
                            End If
                        Else
                            FilaPedido.Cells(ColumnaChecada.Column.Key).Value = 0
                        End If

                    End If

                    ' AsignarParesProyectarDia(grdNivelPedido, FilaPedido, ColumnaChecada)

                    AsignarParesProyectarDiaNivelPedido(FilaPedido, "PedidoSICY")

                Next
            End If
        End If

    End Sub


    Public Sub ActualizarCheckBoxPartidasGrid(ByVal ClienteSayID As Integer, ByVal ColumnaChecada As UltraGridCell)

        If IsNothing(grdNivelPartida) = False Then
            If grdNivelPartida.Rows.Count > 0 Then



                Dim Lista = grdNivelPartida.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = ClienteSayID)

                For Each FilaPartida As UltraGridRow In Lista

                    If FilaPartida.Cells("Disponible").Value > 0 And FilaPartida.Appearance.BackColor <> Color.LightGray Then

                        If CBool(ColumnaChecada.Value) = True Then
                            FilaPartida.Cells("Pros_Lu").Value = False
                            FilaPartida.Cells("Pros_Ma").Value = False
                            FilaPartida.Cells("Pros_Mi").Value = False
                            FilaPartida.Cells("Pros_Ju").Value = False
                            FilaPartida.Cells("Pros_Vi").Value = False
                            FilaPartida.Cells("Pros_Sa").Value = False
                            If CBool(ColumnaChecada.Value) = True Then
                                If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        Else
                            FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                        End If

                    End If


                    AsignarParesProyectarDia(grdNivelPartida, FilaPartida, ColumnaChecada)
                Next
            End If
        End If
    End Sub

    Public Sub ActualizarCheckBoxPartidasGridOculto(ByVal ClienteSayID As Integer, ByVal ColumnaChecada As UltraGridCell)

        If IsNothing(grdNivelPartidaOculto) = False Then
            If grdNivelPartidaOculto.Rows.Count > 0 Then

                Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = ClienteSayID)

                For Each FilaPartida As UltraGridRow In Lista

                    If FilaPartida.Cells("Disponible").Value > 0 And FilaPartida.Appearance.BackColor <> Color.LightGray Then

                        If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("ColumnaModificada").Value = 1
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                FilaPartida.Cells("ColumnaModificada").Value = 1

                                'If FilaPartida.Cells(ColumnaChecada.Column.Key).Value <> False Then
                                '    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                '    FilaPartida.Cells("ColumnaModificada").Value = 1
                                'End If
                            End If
                        Else
                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False

                            End If
                        End If



                    End If
                    AsignarParesProyectarDia(grdNivelPartidaOculto, FilaPartida, ColumnaChecada)
                Next
            End If
        End If
    End Sub


    Public Sub ActualizarCheckBoxPartidasxPedidoGrid(ByVal PedidoSicyID As Integer, ByVal ColumnaChecada As UltraGridCell)

        If IsNothing(grdNivelPartida) = False Then
            If grdNivelPartida.Rows.Count > 0 Then

                Dim Lista = grdNivelPartida.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = PedidoSicyID)

                For Each FilaPartida As UltraGridRow In Lista



                    If FilaPartida.Cells("Disponible").Value > 0 And FilaPartida.Appearance.BackColor <> Color.LightGray Then

                        If CBool(ColumnaChecada.Value) = True Then
                            FilaPartida.Cells("Pros_Lu").Value = False
                            FilaPartida.Cells("Pros_Ma").Value = False
                            FilaPartida.Cells("Pros_Mi").Value = False
                            FilaPartida.Cells("Pros_Ju").Value = False
                            FilaPartida.Cells("Pros_Vi").Value = False
                            FilaPartida.Cells("Pros_Sa").Value = False
                            If CBool(ColumnaChecada.Value) = True Then
                                If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        Else
                            FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                        End If

                    End If
                    AsignarParesProyectarDia(grdNivelPartida, FilaPartida, ColumnaChecada)

                Next

            End If
        End If
    End Sub

    Public Sub ActualizarCheckBoxPartidasxPedidoGridOculto(ByVal PedidoSicyID As Integer, ByVal ColumnaChecada As UltraGridCell)

        If IsNothing(grdNivelPartidaOculto) = False Then
            If grdNivelPartidaOculto.Rows.Count > 0 Then

                Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = PedidoSicyID)

                For Each FilaPartida As UltraGridRow In Lista

                    If FilaPartida.Cells("Disponible").Value > 0 And FilaPartida.Appearance.BackColor <> Color.LightGray Then

                        If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("ColumnaModificada").Value = 1
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                FilaPartida.Cells("ColumnaModificada").Value = 1

                                'If FilaPartida.Cells(ColumnaChecada.Column.Key).Value <> False Then
                                '    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                '    FilaPartida.Cells("ColumnaModificada").Value = 1
                                'End If
                                'FilaPartida.Cells("ColumnaModificada").Value = 1
                                'FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        Else
                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        End If


                    End If
                    AsignarParesProyectarDia(grdNivelPartidaOculto, FilaPartida, ColumnaChecada)


                Next

            End If
        End If
    End Sub


    Public Sub ActualizarCheckBoxPartidasGridOcultoNivelPartida(ByVal PedidoSICY As Integer, ByVal Partida As Integer, ByVal ColumnaChecada As UltraGridCell)

        If IsNothing(grdNivelPartidaOculto) = False Then
            If grdNivelPartidaOculto.Rows.Count > 0 Then

                Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = PedidoSICY And x.Cells("Partida").Value = Partida)

                For Each FilaPartida As UltraGridRow In Lista

                    If FilaPartida.Cells("Disponible").Value > 0 And FilaPartida.Appearance.BackColor <> Color.LightGray Then

                        If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("ColumnaModificada").Value = 1
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else
                                FilaPartida.Cells("ColumnaModificada").Value = 1
                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False

                                'If FilaPartida.Cells(ColumnaChecada.Column.Key).Value <> False Then
                                '    FilaPartida.Cells("ColumnaModificada").Value = 1
                                '    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                'End If
                                ' FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        Else

                            If CBool(ColumnaChecada.Value) = True Then
                                FilaPartida.Cells("Pros_Lu").Value = False
                                FilaPartida.Cells("Pros_Ma").Value = False
                                FilaPartida.Cells("Pros_Mi").Value = False
                                FilaPartida.Cells("Pros_Ju").Value = False
                                FilaPartida.Cells("Pros_Vi").Value = False
                                FilaPartida.Cells("Pros_Sa").Value = False
                                If CBool(ColumnaChecada.Value) = True Then
                                    If FilaPartida.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                                        FilaPartida.Cells(ColumnaChecada.Column.Key).Value = True
                                    End If
                                Else
                                    FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                                End If
                            Else

                                FilaPartida.Cells(ColumnaChecada.Column.Key).Value = False
                            End If
                        End If



                    End If
                    AsignarParesProyectarDia(grdNivelPartidaOculto, FilaPartida, ColumnaChecada)
                Next
            End If
        End If
    End Sub


    Public Sub AsignarParesProyectarDia(ByVal grd As UltraGrid, ByVal Fila As UltraGridRow, ByVal ColumnaChecada As UltraGridCell)
        If Fila.Appearance.BackColor <> Color.LightGray Then
            If CBool(Fila.Cells("Pros_Lu").Value) = False Then
                Fila.Cells("Proy_Ju").Value = 0
                Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Transparent
            End If
            If CBool(Fila.Cells("Pros_Ma").Value) = False Then
                Fila.Cells("Proy_Vi").Value = 0
                Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Transparent
            End If
            If CBool(Fila.Cells("Pros_Mi").Value) = False Then
                Fila.Cells("Proy_Lu").Value = 0
                Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Transparent
            End If
            If CBool(Fila.Cells("Pros_Ju").Value) = False Then
                Fila.Cells("Proy_Ma").Value = 0
                Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Transparent
            End If
            If CBool(Fila.Cells("Pros_Vi").Value) = False And CBool(Fila.Cells("Pros_Sa").Value) = False Then
                Fila.Cells("Proy_Mi").Value = 0
                Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Transparent
            End If

            If Fila.Cells(ColumnaChecada.Column.Key).Appearance.BackColor <> Color.LightGray Then
                If CBool(ColumnaChecada.Value) = True Then
                    Select Case ColumnaChecada.Column.Key
                        Case "Pros_Lu"
                            Fila.Cells("Proy_Ju").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Ju").Value
                            Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple
                        Case "Pros_Ma"
                            Fila.Cells("Proy_Vi").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                            Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple
                        Case "Pros_Mi"
                            Fila.Cells("Proy_Lu").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                            Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple
                        Case "Pros_Ju"
                            Fila.Cells("Proy_Ma").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Ma").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                            Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple
                        Case "Pros_Vi", "Pros_Sa"
                            Fila.Cells("Proy_Mi").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Mi").Value + Fila.Cells("Proc_Ma").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                            Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple
                    End Select
                End If
            End If
            Fila.Cells("Total PR").Value = Fila.Cells("Proy_Ju").Value + Fila.Cells("Proy_Vi").Value + Fila.Cells("Proy_Lu").Value + Fila.Cells("Proy_Ma").Value + Fila.Cells("Proy_Mi").Value

            If Fila.Cells("Total PR").Value > 0 Then
                Fila.Cells("Total PR").Appearance.ForeColor = Color.Purple
                Fila.Cells("Usuario").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                Fila.Cells("Usuario").Appearance.ForeColor = Color.Purple
                Fila.Cells("Fecha").Value = DateTime.Now.ToShortDateString()
                Fila.Cells("Fecha").Appearance.ForeColor = Color.Purple
                Fila.Cells("PR").Value = "S"
                Fila.Cells("PR").Appearance.ForeColor = Color.Purple
            Else
                Fila.Cells("Total PR").Appearance.ForeColor = Color.Black
                Fila.Cells("Usuario").Value = ""
                Fila.Cells("Fecha").Value = ""
                Fila.Cells("Fecha").Appearance.ForeColor = Color.Transparent
                Fila.Cells("PR").Value = "N"
                Fila.Cells("PR").Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub


    Public Sub AsignarParesProyectarDiaNivelesSuperiores(ByVal grd As UltraGrid, ByVal Fila As UltraGridRow, ByVal ColumnaChecada As UltraGridCell)
        If Fila.Appearance.BackColor <> Color.LightGray Then
            If Fila.Cells("Pros_Lu").Value = 0 Then
                Fila.Cells("Proy_Ju").Value = 0
                Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Transparent
            End If
            If Fila.Cells("Pros_Ma").Value = 0 Then
                Fila.Cells("Proy_Vi").Value = 0
                Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Transparent
            End If
            If Fila.Cells("Pros_Mi").Value = 0 Then
                Fila.Cells("Proy_Lu").Value = 0
                Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Transparent
            End If
            If Fila.Cells("Pros_Ju").Value = 0 Then
                Fila.Cells("Proy_Ma").Value = 0
                Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Transparent
            End If
            If Fila.Cells("Pros_Vi").Value = 0 And Fila.Cells("Pros_Sa").Value = 0 Then
                Fila.Cells("Proy_Mi").Value = 0
                Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Transparent
            End If

            If CBool(ColumnaChecada.Value) = True Then
                Select Case ColumnaChecada.Column.Key
                    Case "Pros_Lu"
                        Fila.Cells("Proy_Ju").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Ju").Value
                        Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple
                    Case "Pros_Ma"
                        Fila.Cells("Proy_Vi").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                        Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple
                    Case "Pros_Mi"
                        Fila.Cells("Proy_Lu").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                        Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple
                    Case "Pros_Ju"
                        Fila.Cells("Proy_Ma").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Ma").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                        Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple
                    Case "Pros_Vi", "Pros_Sa"
                        Fila.Cells("Proy_Mi").Value = Fila.Cells("Inventario").Value + Fila.Cells("Apartado").Value + Fila.Cells("Proc_Mi").Value + Fila.Cells("Proc_Ma").Value + Fila.Cells("Proc_Lu").Value + Fila.Cells("Proc_Vi").Value + Fila.Cells("Proc_Ju").Value
                        Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple
                End Select

                Fila.Cells("Total PR").Value = Fila.Cells("Proy_Ju").Value + Fila.Cells("Proy_Vi").Value + Fila.Cells("Proy_Lu").Value + Fila.Cells("Proy_Ma").Value + Fila.Cells("Proy_Mi").Value

                If Fila.Cells("Total PR").Value > 0 Then
                    Fila.Cells("Total PR").Appearance.ForeColor = Color.Purple
                    Fila.Cells("Usuario").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    Fila.Cells("Usuario").Appearance.ForeColor = Color.Purple
                    Fila.Cells("Fecha").Value = DateTime.Now.ToShortDateString()
                    Fila.Cells("Fecha").Appearance.ForeColor = Color.Purple
                    Fila.Cells("PR").Value = "S"
                    Fila.Cells("PR").Appearance.ForeColor = Color.Purple
                Else
                    Fila.Cells("Total PR").Appearance.ForeColor = Color.Black
                    Fila.Cells("Usuario").Value = ""
                    Fila.Cells("Fecha").Value = ""
                    Fila.Cells("Fecha").Appearance.ForeColor = Color.Transparent
                    Fila.Cells("PR").Value = "N"
                    Fila.Cells("PR").Appearance.ForeColor = Color.Black
                End If
            End If
        End If
    End Sub

    Public Sub AsignarParesProyectarDiaNivelCliente(ByVal Fila As UltraGridRow, ByVal Campo As String, ByVal nombreGrid As String)
        Dim totalParesLu, totalParesMa, totalParesMi, totalParesJu, totalParesVi, totalParesSa As Integer
        Dim totalPartidasProspectadas As Integer = 0
        Dim grid As UltraGrid
        Dim listPedidos As New List(Of Integer)
        totalParesLu = 0
        totalParesMa = 0
        totalParesMi = 0
        totalParesJu = 0
        totalParesVi = 0
        totalParesSa = 0
        grid = grdNivelPartidaOculto


        'If grdNivelPartida.Rows.Count > 0 Then
        '    grid = grdNivelPartida
        'End If

        Fila.Cells("Proy_Ju").Value = 0
        Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Vi").Value = 0
        Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Lu").Value = 0
        Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Ma").Value = 0
        Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Mi").Value = 0
        Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Transparent


        If IsNothing(grid) = False Then
            If grid.Rows.Count > 0 Then
                Dim Lista = grid.Rows.Where(Function(x) x.Cells(Campo).Value = Fila.Cells(Campo).Value)
                For Each row As UltraGridRow In Lista
                    totalParesJu += row.Cells("Proy_Ju").Value
                    totalParesVi += row.Cells("Proy_Vi").Value
                    totalParesLu += row.Cells("Proy_Lu").Value
                    totalParesMa += row.Cells("Proy_Ma").Value
                    totalParesMi += row.Cells("Proy_Mi").Value

                    If row.Cells("Proy_Ju").Value > 0 Or row.Cells("Proy_Vi").Value > 0 Or row.Cells("Proy_Lu").Value > 0 Or row.Cells("Proy_Ma").Value > 0 Or row.Cells("Proy_Mi").Value > 0 Then
                        totalPartidasProspectadas += 1
                        If listPedidos.Contains(row.Cells("PedidoSICY").Value) = False Then
                            listPedidos.Add(row.Cells("PedidoSICY").Value)
                        End If
                    End If

                Next
            End If
        End If
        Fila.Cells("Proy_Ju").Value = totalParesJu
        Fila.Cells("Proy_Vi").Value = totalParesVi
        Fila.Cells("Proy_Lu").Value = totalParesLu
        Fila.Cells("Proy_Ma").Value = totalParesMa
        Fila.Cells("Proy_Mi").Value = totalParesMi

        Fila.Cells("Total PR").Value = totalParesJu + totalParesVi + totalParesLu + totalParesMa + totalParesMi

        Fila.Cells("PartidasProspectadas").Value = totalPartidasProspectadas

        If nombreGrid = "grdNivelCliente" Then
            Fila.Cells("PedidosProspectados").Value = listPedidos.Count()

            If listPedidos.Count() > 0 Then
                Fila.Cells("PedidosProspectados").Appearance.ForeColor = Color.Purple
            Else
                Fila.Cells("PedidosProspectados").Appearance.ForeColor = Color.Transparent
            End If
        End If

        If totalPartidasProspectadas > 0 Then
            Fila.Cells("PartidasProspectadas").Appearance.ForeColor = Color.Purple
        Else
            Fila.Cells("PartidasProspectadas").Appearance.ForeColor = Color.Transparent
        End If

        If Fila.Cells("Total PR").Value > 0 Then
            Fila.Cells("Total PR").Appearance.ForeColor = Color.Purple
            Fila.Cells("Usuario").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            Fila.Cells("Usuario").Appearance.ForeColor = Color.Purple
            Fila.Cells("Fecha").Value = DateTime.Now.ToShortDateString()
            Fila.Cells("Fecha").Appearance.ForeColor = Color.Purple
            Fila.Cells("PR").Value = "S"
            Fila.Cells("PR").Appearance.ForeColor = Color.Purple
        Else
            Fila.Cells("Total PR").Appearance.ForeColor = Color.Black
            Fila.Cells("Usuario").Value = ""
            Fila.Cells("Fecha").Value = ""
            Fila.Cells("Fecha").Appearance.ForeColor = Color.Transparent
            Fila.Cells("PR").Value = "N"
            Fila.Cells("PR").Appearance.ForeColor = Color.Black
        End If

        If totalParesJu > 0 Then
            Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple
        End If
        If totalParesVi > 0 Then
            Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple
        End If
        If totalParesLu > 0 Then
            Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple
        End If
        If totalParesMa > 0 Then
            Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple
        End If
        If totalParesMi > 0 Then
            Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple
        End If
    End Sub

    Public Sub AsignarParesProyectarDiaNivelPedido(ByVal Fila As UltraGridRow, ByVal Campo As String)
        Dim totalParesLu, totalParesMa, totalParesMi, totalParesJu, totalParesVi, totalParesSa As Integer
        Dim totalPartidasProspectadas As Integer = 0
        Dim grid As UltraGrid
        totalParesLu = 0
        totalParesMa = 0
        totalParesMi = 0
        totalParesJu = 0
        totalParesVi = 0
        totalParesSa = 0
        grid = grdNivelPartidaOculto

        'If grdNivelPartida.Rows.Count > 0 Then
        '    grid = grdNivelPartida
        'End If

        Fila.Cells("Proy_Ju").Value = 0
        Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Vi").Value = 0
        Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Lu").Value = 0
        Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Ma").Value = 0
        Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Transparent
        Fila.Cells("Proy_Mi").Value = 0
        Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Transparent

        If IsNothing(grid) = False Then
            If grid.Rows.Count > 0 Then
                Dim Lista = grid.Rows.Where(Function(x) x.Cells(Campo).Value = Fila.Cells(Campo).Value)
                For Each row As UltraGridRow In Lista
                    totalParesJu += row.Cells("Proy_Ju").Value
                    totalParesVi += row.Cells("Proy_Vi").Value
                    totalParesLu += row.Cells("Proy_Lu").Value
                    totalParesMa += row.Cells("Proy_Ma").Value
                    totalParesMi += row.Cells("Proy_Mi").Value

                    If row.Cells("Proy_Ju").Value > 0 Or row.Cells("Proy_Vi").Value > 0 Or row.Cells("Proy_Lu").Value > 0 Or row.Cells("Proy_Ma").Value > 0 Or row.Cells("Proy_Mi").Value > 0 Then
                        totalPartidasProspectadas += 1
                    End If

                Next
            End If
        End If
        Fila.Cells("Proy_Ju").Value = totalParesJu
        Fila.Cells("Proy_Vi").Value = totalParesVi
        Fila.Cells("Proy_Lu").Value = totalParesLu
        Fila.Cells("Proy_Ma").Value = totalParesMa
        Fila.Cells("Proy_Mi").Value = totalParesMi

        Fila.Cells("Total PR").Value = totalParesJu + totalParesVi + totalParesLu + totalParesMa + totalParesMi

        Fila.Cells("PartidasProspectadas").Value = totalPartidasProspectadas
        If totalPartidasProspectadas > 0 Then
            Fila.Cells("PartidasProspectadas").Appearance.ForeColor = Color.Purple
        Else
            Fila.Cells("PartidasProspectadas").Appearance.ForeColor = Color.Transparent
        End If

        If Fila.Cells("Total PR").Value > 0 Then
            Fila.Cells("Total PR").Appearance.ForeColor = Color.Purple
            Fila.Cells("Usuario").Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            Fila.Cells("Usuario").Appearance.ForeColor = Color.Purple
            Fila.Cells("Fecha").Value = DateTime.Now.ToShortDateString()
            Fila.Cells("Fecha").Appearance.ForeColor = Color.Purple
            Fila.Cells("PR").Value = "S"
            Fila.Cells("PR").Appearance.ForeColor = Color.Purple
        Else
            Fila.Cells("Total PR").Appearance.ForeColor = Color.Black
            Fila.Cells("Usuario").Value = ""
            Fila.Cells("Fecha").Value = ""
            Fila.Cells("Fecha").Appearance.ForeColor = Color.Transparent
            Fila.Cells("PR").Value = "N"
            Fila.Cells("PR").Appearance.ForeColor = Color.Black
        End If

        If totalParesJu > 0 Then
            Fila.Cells("Proy_Ju").Appearance.ForeColor = Color.Purple
        End If
        If totalParesVi > 0 Then
            Fila.Cells("Proy_Vi").Appearance.ForeColor = Color.Purple
        End If
        If totalParesLu > 0 Then
            Fila.Cells("Proy_Lu").Appearance.ForeColor = Color.Purple
        End If
        If totalParesMa > 0 Then
            Fila.Cells("Proy_Ma").Appearance.ForeColor = Color.Purple
        End If
        If totalParesMi > 0 Then
            Fila.Cells("Proy_Mi").Appearance.ForeColor = Color.Purple
        End If
    End Sub

    Private Sub ProspectaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()

        Try
            Me.Cursor = Cursors.WaitCursor
            ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, ProspectaID)
            'ObjPRospecta.DesbloquearProspectaActivaUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, ProspectaID)

            'Si la prospecta No se guarda borrar la informacion de las tablas
            If ProspectaID = -1 Then
                ObjPRospecta.LimpiarTablasProspectaNoGuardada()
            Else
                If IdEstatusInicialProspecta = 87 Or IdEstatusInicialProspecta = 88 Or IdEstatusInicialProspecta = 90 Then
                    ObjPRospecta.ActualizarEncabezadoProspecta(ProspectaID)
                End If

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub



    Public Sub GuardarInformacionProspecta(ByVal grd As UltraGrid, ByVal Fila As UltraGridRow)
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim ClienteSicyId As Integer = -1
        Dim PedidoSicyId As Integer = -1
        Dim Partida As Integer = -1
        Dim ProcesoJ As Integer = 0
        Dim ProcesoV As Integer = 0
        Dim ProcesoMa As Integer = 0
        Dim ProcesoMi As Integer = 0
        Dim ProcesoL As Integer = 0
        Dim ProspectarL As Boolean = False
        Dim ProspectarMa As Boolean = False
        Dim ProspectarMi As Boolean = False
        Dim ProspectarJ As Boolean = False
        Dim ProspectarV As Boolean = False
        Dim ProspectarS As Boolean = False
        Dim ProyectarJ As Integer = 0
        Dim ProyectarV As Integer = 0
        Dim ProyectarL As Integer = 0
        Dim ProyectarMa As Integer = 0
        Dim ProyectarMi As Integer = 0


        'If grd.Name = "grdNivelCliente" Then
        '    ClienteSicyId = Fila.Cells("ClienteSICY").Value
        'ElseIf grd.Name = "grdNivelPedido" Then
        '    Partida = Fila.Cells("Partida").Value
        '    PedidoSicyId = Fila.Cells("PedidoSICY").Value
        'ElseIf grd.Name = "grdNivelPartida" Then
        '    Partida = Fila.Cells("Partida").Value
        '    PedidoSicyId = Fila.Cells("PedidoSICY").Value
        'End If

        Partida = Fila.Cells("Partida").Value
        PedidoSicyId = Fila.Cells("PedidoSICY").Value

        ProcesoJ = Fila.Cells("Proc_Ju").Value
        ProcesoV = Fila.Cells("Proc_Vi").Value
        ProcesoMa = Fila.Cells("Proc_Ma").Value
        ProcesoMi = Fila.Cells("Proc_Mi").Value
        ProcesoL = Fila.Cells("Proc_Lu").Value

        ProspectarL = Fila.Cells("Pros_Lu").Value
        ProspectarMa = Fila.Cells("Pros_Ma").Value
        ProspectarMi = Fila.Cells("Pros_Mi").Value
        ProspectarJ = Fila.Cells("Pros_Ju").Value
        ProspectarV = Fila.Cells("Pros_Vi").Value
        ProspectarS = Fila.Cells("Pros_Sa").Value

        ProyectarJ = Fila.Cells("Proy_Ju").Value
        ProyectarV = Fila.Cells("Proy_Vi").Value
        ProyectarL = Fila.Cells("Proy_Lu").Value
        ProyectarMa = Fila.Cells("Proy_Ma").Value
        ProyectarMi = Fila.Cells("Proy_Mi").Value

        objProspecta.GuardarInformacionProspecta(ProspectaID, ClienteSicyId, PedidoSicyId, Partida, ProcesoJ, ProcesoV, ProcesoL, ProcesoMa, ProcesoMi,
                                                ProspectarL, ProspectarMa, ProspectarMi, ProspectarJ, ProspectarV, ProspectarS,
                                             ProyectarJ, ProyectarV, ProyectarL, ProyectarMa, ProyectarMi, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
        'gridParesDiariosDiseño(grdResumenDiario)

    End Sub


    Private Sub grdNivelPartida_LostFocus(sender As Object, e As EventArgs) Handles grdNivelPartida.LostFocus
        Dim objprospecta As New Ventas.Negocios.ProspectaBU
        If Edicion = True Then
            If IsNothing(grdNivelPartida.ActiveRow) = False Then
                If grdNivelPartida.ActiveRow.IsFilterRow = False Then
                    Try
                        Cursor = Cursors.WaitCursor
                        Dim FilaPartida As UltraGridRow = grdNivelPartidaOculto.Rows.FirstOrDefault(Function(x) x.Cells("PedidoSICY").Value = grdNivelPartida.ActiveRow.Cells("PedidoSICY").Value And x.Cells("Partida").Value = grdNivelPartida.ActiveRow.Cells("Partida").Value)

                        If IsNothing(FilaPartida) = False Then
                            If FilaPartida.Cells("ColumnaModificada").Value = 1 Then

                                GuardarInformacionProspecta(grdNivelPartida, grdNivelPartida.ActiveRow)

                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Ju"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Vi"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Lu"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Ma"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Proy_Mi"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Usuario"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Total PR"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("PR"))
                                CeldaColorNegro(grdNivelPartida.ActiveRow.Cells("Fecha"))

                                ActualizarColorParesProyectados(grdNivelPartida, grdNivelPartida.ActiveRow.Cells("PedidoSICY").Value, -1)

                                grdResumenDiario.DataSource = objprospecta.ConsultarEntregasPorDia(ProspectaID)
                                gridParesDiariosDiseño(grdResumenDiario)
                            End If
                            FilaPartida.Cells("ColumnaModificada").Value = 0
                        Else
                            GuardarInformacionProspecta(grdNivelPartida, grdNivelPartida.ActiveRow)
                        End If
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try
                End If

            End If
        End If

    End Sub

    Private Sub grdNivelPedido_LostFocus(sender As Object, e As EventArgs) Handles grdNivelPedido.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        If Edicion = True Then
            If IsNothing(grdNivelPedido.ActiveRow) = False Then
                If grdNivelPedido.ActiveRow.IsFilterRow = False Then

                    Try
                        Cursor = Cursors.WaitCursor
                        Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("PedidoSICY").Value = grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value And x.Cells("PedidoSICY").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)
                        For Each Fila As UltraGridRow In Lista
                            Fila.Cells("ColumnaModificada").Value = 0
                            GuardarInformacionProspecta(grdNivelPedido, Fila)
                            Existe = True
                        Next

                        If Existe = True Then
                            ActualizarColorParesProyectados(grdNivelPedido, grdNivelPedido.ActiveRow.Cells("PedidoSICY").Value, grdNivelPedido.ActiveRow.Cells("clie_clienteid").Value)
                            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
                            gridParesDiariosDiseño(grdResumenDiario)
                        End If
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try
                End If
            End If
        End If
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

    Private Sub grdNivelCliente_LostFocus(sender As Object, e As EventArgs) Handles grdNivelCliente.LostFocus
        Dim Existe As Boolean = False
        Dim objProspecta As New Ventas.Negocios.ProspectaBU

        If Edicion = True Then
            If IsNothing(grdNivelCliente.ActiveRow) = False Then
                If grdNivelCliente.ActiveRow.IsFilterRow = False Then
                    Try
                        Cursor = Cursors.WaitCursor

                        Dim Lista = grdNivelPartidaOculto.Rows.Where(Function(x) x.Cells("clie_clienteid").Value = grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value And x.Cells("clie_clienteid").Row.Appearance.BackColor <> Color.LightGray And x.Cells("ColumnaModificada").Value = 1)
                        For Each Fila As UltraGridRow In Lista
                            Fila.Cells("ColumnaModificada").Value = 0
                            GuardarInformacionProspecta(grdNivelCliente, Fila)
                            Existe = True
                        Next

                        If Existe = True Then
                            ActualizarColorParesProyectados(grdNivelCliente, -1, grdNivelCliente.ActiveRow.Cells("clie_clienteid").Value)
                            grdResumenDiario.DataSource = objProspecta.ConsultarEntregasPorDia(ProspectaID)
                            gridParesDiariosDiseño(grdResumenDiario)
                        End If
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub btnActualizarStatus_Click(sender As Object, e As EventArgs) Handles btnActualizarStatus.Click
        Dim objBu As New Negocios.ProspectaBU
        Dim confirmacion As New ConfirmarForm
        Dim mensajeAdvertencia As New AdvertenciaForm
        Dim CountUsuarioEditando As Integer = 0
        Try
            confirmacion.mensaje = "¿Desea cambiar el status de la prospecta? Este proceso no podrá revertirse"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                CountUsuarioEditando = objBu.ConsultaUsuariosEditando(ProspectaID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                If CountUsuarioEditando = 0 Then


                    If SiguienteStatus = 88 Then
                        CerrarProspecta()
                    End If

                    objBu.ActualizarStatusProspecta(ProspectaID, SiguienteStatus)
                    CargarInformacionProspecta()

                    If IdEstadoProspecta = 88 Then
                        objBu.ActualizarProspectaVigente()
                        btnActualizarStatus.Visible = False
                        btnEditar.Enabled = False
                        QuitarModoEdicion()
                        Edicion = False
                        objBu.LimpiarUsuarioEditando(ProspectaID)
                        'ElseIf IdEstadoProspecta = 90 Then
                        '    btnEditar.Enabled = True

                    End If
                Else
                    show_message("Advertencia", "No se puede actualizar el status de la prospecta debido a que hay usuarios editando.")
                End If

            End If
        Catch ex As Exception
            mensajeAdvertencia.mensaje = "Error al guardar, por favor intente de nuevo."
            mensajeAdvertencia.ShowDialog()
        End Try
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        ' Tipo Perfil 0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno, 5 => Almacen
        If TipoPerfil = 2 Or TipoPerfil = 3 Or TipoPerfil = 5 Then
            grdFiltroClientes.DataSource = Nothing
            grdAtnClientes.DataSource = Nothing
            grdFiltroAgenteVentas.DataSource = Nothing
        ElseIf TipoPerfil = 0 Or TipoPerfil = 4 Then
            grdFiltroClientes.DataSource = Nothing
            grdFiltroAgenteVentas.DataSource = Nothing
        ElseIf TipoPerfil = 1 Then
            grdFiltroClientes.DataSource = Nothing
            grdAtnClientes.DataSource = Nothing
        End If

        Dim Lista = grdNivelCliente.Rows.Where(Function(x) CBool(x.Cells("Seleccionar").Value) = True)

        For Each row As UltraGridRow In Lista
            row.Cells("Seleccionar").Value = False
        Next

        spcClientes.SplitterDistance = spcClientes.Width - 4
        sPCParesConfirmar.SplitterDistance = sPCParesConfirmar.Height - 4
    End Sub

    Private Sub btnComentarioRevision_Click(sender As Object, e As EventArgs) Handles btnComentarioRevision.Click
        Dim Form As New ProspectaNotasRevisionForm
        If ProspectaID = -1 Then
            show_message("Advertencia", "La prospecta todavia no se ha guardado.")
        Else
            Form.ProspectaID = ProspectaID

            Form.EstatusProspecta = txtStatusProspecta.Text.Trim
            Form.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim punto As Point
        punto.X = btnExportar.Location.X + btnExportar.Width
        punto.Y = btnExportar.Location.Y + btnExportar.Height + (btnExportar.Height / 1.3)
        cmsTipoExportacion.Show(punto)
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
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub



    Public Function CerrarProspecta() As Boolean
        Dim ObjProspecta As New Ventas.Negocios.ProspectaBU()
        Dim DTProspectaVigente As DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            DTProspectaVigente = ObjProspecta.ObtenerProspectaVigente()
            If DTProspectaVigente.Rows.Count > 0 Then
                'ObjProspecta.ProspectaVigente(DTProspectaVigente.Rows(0).Item("pros_fechainicio").ToString, DTProspectaVigente.Rows(0).Item("pros_fechafin").ToString)
                'ObjProspecta.RespaldarDatosProspectaDeSICY(DTProspectaVigente.Rows(0).Item("pros_prospectaid").ToString, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, -1)
                ObjProspecta.CerrarProspecta(DTProspectaVigente.Rows(0).Item("pros_prospectaid").ToString)
                ObjProspecta.LimpiarTablasPropectaVigente()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Try
            Me.Cursor = Cursors.WaitCursor
            objProspecta.ActualizarProspectaCerrada()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try


        'CerrarProspecta()
        'QuitarModoEdicion()
        'Edicion = False
    End Sub



    Public Sub CargarResumenEntregarPorDia()

        Dim Lunes As Integer = 0
        Dim Martes As Integer = 0
        Dim Miercoles As Integer = 0
        Dim Jueves As Integer = 0
        Dim Viernes As Integer = 0

        If IsNothing(grdNivelCliente) = False Then
            If grdNivelCliente.Rows.Count > 0 Then

                Lunes = grdNivelCliente.Rows.Where(Function(x) x.Cells("Proy_Ju").Value > 0).Sum(Function(y) y.Cells("Proy_Ju").Value)
            End If
        End If
    End Sub



    Public Sub QuitarModoEdicion()

        If IsNothing(grdNivelCliente) = False Then
            If grdNivelCliente.Rows.Count > 0 Then
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Lu").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Ma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Mi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Ju").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Vi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelCliente.DisplayLayout.Bands(0).Columns("Pros_Sa").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        End If

        If IsNothing(grdNivelPedido) = False Then
            If grdNivelPedido.Rows.Count > 0 Then
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Lu").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Ma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Mi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Ju").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Vi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPedido.DisplayLayout.Bands(0).Columns("Pros_Sa").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        End If

        If IsNothing(grdNivelPartida) = False Then
            If grdNivelPartida.Rows.Count > 0 Then
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Lu").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Ma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Mi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Ju").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Vi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grdNivelPartida.DisplayLayout.Bands(0).Columns("Pros_Sa").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        End If

        For Each Fila As UltraGridRow In grdNivelCliente.Rows
            Fila.Cells("Editando").Value = ""
        Next


    End Sub


    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub



    Private Sub tsmClientes_Click(sender As Object, e As EventArgs) Handles tsmClientes.Click
        exportarExcel(grdNivelCliente)
    End Sub

    Private Sub tsmClientesPartidas_Click(sender As Object, e As EventArgs) Handles tsmClientesPartidas.Click
        If grdNivelCliente.Rows.Count > 0 Then
            Dim clientesMostrados As String = ""
            Dim dtResultadoConsultaNivelPedido As New DataTable
            Dim ObjProspecta As New Negocios.ProspectaBU
            Dim listaSeleccionados = grdNivelCliente.Rows.Where(Function(x) CBool(x.Cells("Seleccionar").Value) = True)
            If listaSeleccionados.Count = 0 Then
                For Each row As UltraGridRow In grdNivelCliente.Rows.GetFilteredInNonGroupByRows
                    If clientesMostrados = "" Then
                        clientesMostrados += row.Cells("ClienteSICY").Value.ToString()
                    Else
                        clientesMostrados += "," + row.Cells("ClienteSICY").Value.ToString()
                    End If
                Next
                grdNivelPedido.DataSource = Nothing
                If clientesMostrados <> "" Then
                    dtResultadoConsultaNivelPedido = ObjProspecta.ConsultarDatosProspectaPorNivel(2, clientesMostrados, FiltroAtencionClientes, FiltroAgenteID, "", ProspectaID)
                    grdNivelPedido.DataSource = dtResultadoConsultaNivelPedido
                    gridPedidosDiseño(grdNivelPedido)
                End If
            End If

            grdNivelCliente.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True
            grdNivelPedido.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True
            exportarExcelCliente_Pedido(grdNivelCliente, grdNivelPedido)
            grdNivelCliente.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = False
            grdNivelPedido.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = False
            If listaSeleccionados.Count = 0 Then
                grdNivelPedido.DataSource = Nothing
            End If
        Else
            show_message("Advertencia", "No hay información para exportar a excel.")
            Return
        End If

    End Sub

    Public Sub exportarExcelCliente_Pedido(ByVal grdClientes As UltraGrid, ByVal grdPedidos As UltraGrid)
        Dim sfd As New SaveFileDialog
        Dim extensionArchivo As String()

        If IsNothing(grdClientes) = False Then
            If grdClientes.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
                Return
            End If
        End If


        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim LibroExportar As New Infragistics.Documents.Excel.Workbook
        extensionArchivo = fileName.Split(".")
        If extensionArchivo(1).ToString() = "xlsx" Then
            LibroExportar.SetCurrentFormat(Infragistics.Documents.Excel.WorkbookFormat.Excel2007)
        ElseIf extensionArchivo(1).ToString() = "xls" Then
            LibroExportar.SetCurrentFormat(Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
        ElseIf extensionArchivo(1).ToString() = "xlsm" Then
            LibroExportar.SetCurrentFormat(Infragistics.Documents.Excel.WorkbookFormat.Excel2007MacroEnabled)
        End If
        Dim HojaClientes = LibroExportar.Worksheets.Add("Clientes")
        Dim HojaPedidos = LibroExportar.Worksheets.Add("Pedidos")
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grdClientes, HojaClientes)
                UltraGridExcelExporter1.Export(grdPedidos, HojaPedidos)
                LibroExportar.Save(fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

End Class