

Public Class ProspectaBU

    Public Sub GuardarPartidaProspecta(ByVal ProspectaID As Int32, ByVal ClienteSicy As Int32, ByVal clienteSayID As Int32, ByVal PedidoSicyId As Int32, ByVal PartidaId As Int32, ByVal FechaProgramacionPartida As Date, ByVal PEND As Int32, ByVal IALM As Int32, ByVal IPRO As Int32, ByVal AXC As Int32, ByVal UsuarioCreoID As Int32, ByVal CodigoSicy As String, ByVal IdTalla As String)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.GuardarPartidaProspecta(ProspectaID, ClienteSicy, clienteSayID, PedidoSicyId, PartidaId, FechaProgramacionPartida, PEND, IALM, IPRO, AXC, UsuarioCreoID, CodigoSicy, IdTalla)
    End Sub

    Public Sub ActualizarInformacionProspecta(ByVal ProspectaID As Int32, ByVal UsuarioID As Int32)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.ActualizarInformacionProspecta(ProspectaID, UsuarioID)
    End Sub

    Public Sub LimpiarPlaneacionPartida(ByVal ClienteSayID As Integer, ByVal ProspectaID As Integer, ByVal PedidoSicyID As Integer, ByVal Partida As Integer, ByVal UsuarioModificoID As Integer)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.LimpiarPlaneacionPartida(ClienteSayID, ProspectaID, PedidoSicyID, Partida, UsuarioModificoID)
    End Sub

    Public Sub GuardarIncidenciasProspecta(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal Confirma As Boolean, ByVal UsuarioIdConfirma As Integer, ByVal FechaConfirmacion As Date, ByVal MotivoIncidencia As Integer, ByVal Observaciones As String)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.GuardarIncidenciasProspecta(ProspectaID, ClienteSayID, Confirma, UsuarioIdConfirma, FechaConfirmacion, MotivoIncidencia, Observaciones)
    End Sub
    
    Public Function ObtenerProspectaIDGuardada() As Integer
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ObtenerProspectaIDGuardada()
    End Function

    Public Sub EditarPlaneacionProspecta(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal PedidoSicy As Integer, ByVal Partida As Integer, ByVal ParesPlaneacion As Integer, ByVal FechaDistribucionPares As Date, ByVal UsuarioId As Integer, _
                                         ByVal PedidoDetalleID As Int32, ByVal FechaProgramacion As Date, ByVal ParesPEND As Int32, ByVal ParesIALM As Int32, ByVal ParesIPRO As Int32, ByVal ParesAXC As Int32, _
                                         ByVal IdCodigoSicy As String, ByVal IdTalla As String, ByVal ProductoEstiloID As Int32, ByVal MarcaID As Int32, ByVal FamiliaProyeccion As Int32, ByVal IdTienda As Int32, _
                                         ByVal FechaCaptura As Date, ByVal ParesPartida As Int32, ByVal TotalParesPEND As Int32, ByVal TotalParesIALM As Int32, ByVal TotalParesIPRO As Int32, ByVal TotalParesAXC As Int32, _
                                         ByVal ProspectaPEND As Int32, ByVal ProspectaIALM As Int32, ByVal ProspectaIPRO As Int32, ByVal ProspectaAXC As Int32)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.EditarPlaneacionProspecta(ProspectaID, ClienteSayID, PedidoSicy, Partida, ParesPlaneacion, FechaDistribucionPares, UsuarioId, PedidoDetalleID, FechaProgramacion, ParesPEND, ParesIALM, ParesIPRO, ParesAXC, IdCodigoSicy, IdTalla, ProductoEstiloID, MarcaID, FamiliaProyeccion, IdTienda, FechaCaptura, ParesPartida, TotalParesPEND, TotalParesIALM, TotalParesIPRO, TotalParesAXC, ProspectaPEND, ProspectaIALM, ProspectaIPRO, ProspectaAXC)
    End Sub
    'Public Sub EditarProspecta(ByVal ProspectaID As Int32, ByVal NumeroSemana As Int32, ByVal Año As Int32, ByVal FechaInicio As Date, ByVal FechaFin As Date, _
    '                           ByVal FechaProgramacion As Date, ByVal UsuarioCreoID As Int32, ByVal PedidoSicy As Int32, _
    '                           ByVal Partida As Int32, ByVal Plan_Lun As Int32, ByVal Fecha_Lun As Date, _
    '                           ByVal Plan_Mar As Int32, ByVal Fecha_Mar As Date, ByVal Plan_Mier As Int32, ByVal Fecha_Mier As Date, ByVal Plan_Jue As Int32, ByVal Fecha_Jue As Date, _
    '                           ByVal Plan_Vie As Int32, ByVal Fecha_Vie As Date, ByVal Plan_Sab As Int32, ByVal Fecha_Sab As Date)
    '    Dim objInformacionProspecta As New Datos.ProspectaDA
    '    objInformacionProspecta.EditarProspecta(ProspectaID, NumeroSemana, Año, FechaInicio, FechaFin, FechaProgramacion, UsuarioCreoID, _
    '                                            PedidoSicy, Partida, Plan_Lun, Fecha_Lun, Plan_Mar, Fecha_Mar, Plan_Mier, Fecha_Mier, Plan_Jue, Fecha_Jue, _
    '                                           Plan_Vie, Fecha_Vie, Plan_Sab, Fecha_Sab)
    'End Sub

    Public Sub GuardarProspecta(ByVal NumeroSemana As Int32, ByVal Año As Int32, ByVal FechaInicio As Date, ByVal FechaFin As Date, _
                               ByVal FechaProgramacion As Date, ByVal UsuarioCreoID As Int32, ByVal ParesProspecta As Int32, _
                               ByVal ParesProyctados As Int32, ByVal ParesConfirmados As Int32, ByVal ParesEmbarcados As Int32, _
                               ByVal ParesSalida As Int32)

        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.GuardarProspecta(NumeroSemana, Año, FechaInicio, FechaFin, FechaProgramacion, UsuarioCreoID, ParesProspecta, ParesProyctados, _
                                                 ParesConfirmados, ParesEmbarcados, ParesSalida)
    End Sub

    Public Function ComprobarExisteParesTemporal() As Boolean
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ComprobarExisteParesTemporal()
    End Function

    Public Sub LimpiarTemporalPares()
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.LimpiarTemporalPares()
    End Sub


    Public Function ConsultarNumeroDeUsuariosConsulta(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer) As Integer
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ConsultarNumeroDeUsuariosConsulta(UsuarioID, ProspectaId)
    End Function

    Public Function ComprobarProspectaModoEdicion(ByVal ProspectaID As Integer) As Boolean
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ComprobarProspectaModoEdicion(ProspectaID)
    End Function

    Public Sub ActualizarParesDia(ByVal ProspectaID As Integer, ByVal ClienteId As Integer, ByVal Fecha As Date, ByVal CantidadPares As String)
        Dim objInformacionProspecta As New Datos.ProspectaDA
        objInformacionProspecta.ActualizarParesDia(ProspectaID, ClienteId, Fecha, CantidadPares)
    End Sub

    Public Function ActualizarProspecta(ByVal ObjProspecta As Entidades.ProspectaDetalle) As DataTable
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ActualizarProspecta(ObjProspecta)
    End Function

    Public Function ObtenerFechasProximaProspecta() As DataTable
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ObtenerFechasProximaProspecta()
    End Function

    Public Function ObtenerInformacionUsuarioActivo() As DataTable
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ObtenerInformacionUsuarioActivo()
    End Function

    Public Function ObtenerInformacionUsuarioAltaProspecta() As DataTable
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ObtenerInformacionUsuarioAltaProspecta()
    End Function

    'Public Function ObtenerInformacionUsuarioActivo() As D
    '    Dim objInformacionProspecta As New Datos.ProspectaDA
    '    Return objInformacionProspecta.ObtenerInformacionUsuarioActivo()
    'End Function

    Public Function ObtenerTiposEmpaque() As DataTable
        Dim objInformacionProspecta As New Datos.ProspectaDA
        Return objInformacionProspecta.ObtenerTiposEmpaque()
    End Function

    Public Function ValidarExisteProspectaProxima() As Boolean
        Dim objInformacionEvento As New Datos.ProspectaDA
        Return objInformacionEvento.ValidarExisteProspectaProxima()
    End Function

    Public Function CargarInformacionProspecta(ByVal ProspectaID As Integer) As Entidades.ProspectaInformacion
        Dim objInformacionEvento As New Datos.ProspectaDA
        Dim DTInformacionProspecta As New DataTable
        Dim EntidadProspecta As New Entidades.ProspectaInformacion
        DTInformacionProspecta = objInformacionEvento.CargarInformacionProspecta(ProspectaID)

        If DTInformacionProspecta.Rows.Count = 1 Then

            EntidadProspecta.ProspectaID = CInt(DTInformacionProspecta.Rows(0).Item("pros_prospectaid").ToString())
            EntidadProspecta.NumeroSemana = CInt(DTInformacionProspecta.Rows(0).Item("pros_numerosemana").ToString())
            EntidadProspecta.Año = CInt(DTInformacionProspecta.Rows(0).Item("pros_año").ToString())
            EntidadProspecta.FechaInicio = CDate(DTInformacionProspecta.Rows(0).Item("pros_fechainicio").ToString())
            EntidadProspecta.FechaFin = CDate(DTInformacionProspecta.Rows(0).Item("pros_fechafin").ToString())
            EntidadProspecta.UsuarioCreoID = CInt(DTInformacionProspecta.Rows(0).Item("pros_usuariocreoid").ToString())
            EntidadProspecta.FechaCreacion = CDate(DTInformacionProspecta.Rows(0).Item("pros_fechacreacion").ToString())

            If String.IsNullOrEmpty(DTInformacionProspecta.Rows(0).Item("pros_usuariomodificoid").ToString()) = False Then
                EntidadProspecta.UsuarioModifioID = CInt(DTInformacionProspecta.Rows(0).Item("pros_usuariomodificoid").ToString())
            Else
                EntidadProspecta.UsuarioModifioID = Nothing
            End If

            If IsDate(DTInformacionProspecta.Rows(0).Item("pros_fechamodificacion").ToString()) = True Then
                EntidadProspecta.FechaModificacion = CDate(DTInformacionProspecta.Rows(0).Item("pros_fechamodificacion").ToString())
            Else
                EntidadProspecta.FechaModificacion = Nothing
            End If


            If IsDBNull(DTInformacionProspecta.Rows(0).Item("pros_paresprospecta")) = False Then
                EntidadProspecta.ParesProspecta = CInt(DTInformacionProspecta.Rows(0).Item("pros_paresprospecta").ToString())
            End If

            If IsDBNull(DTInformacionProspecta.Rows(0).Item("pros_paresproyectados")) = False Then
                EntidadProspecta.ParesProyectados = CInt(DTInformacionProspecta.Rows(0).Item("pros_paresproyectados").ToString())
            End If

            If IsDBNull(DTInformacionProspecta.Rows(0).Item("pros_paresentregados")) = False Then
                EntidadProspecta.ParesEntregados = CInt(DTInformacionProspecta.Rows(0).Item("pros_paresentregados").ToString())
            End If




            EntidadProspecta.IDEstatusProspecta = CInt(DTInformacionProspecta.Rows(0).Item("pros_estatusid").ToString())

            EntidadProspecta.Activo = CBool(DTInformacionProspecta.Rows(0).Item("pros_activo").ToString())
            EntidadProspecta.NombreUsuarioCreo = CStr(DTInformacionProspecta.Rows(0).Item("UsuarioCreo").ToString())
            EntidadProspecta.NombreUsuarioModifio = CStr(DTInformacionProspecta.Rows(0).Item("UsuarioModifico").ToString())
            EntidadProspecta.EstatusProspecta = CStr(DTInformacionProspecta.Rows(0).Item("StatusProspecta").ToString())

        End If

        Return EntidadProspecta
    End Function

    Public Function ConsultaHistorialProspecta(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NumeroSemana As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaHistorialProspecta(FechaInicio, FechaFin, NumeroSemana)
    End Function

    Public Function ConsultaProspecta(ByVal ProspectaID As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FechaProgramacion As Date, ByVal AtencionClientes As String, ByVal AgenteID As String, ByVal MedirCumplimiento As Boolean) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaProspecta(ProspectaID, FechaInicio, FechaFin, FechaProgramacion, AtencionClientes, AgenteID, MedirCumplimiento)
    End Function

    Public Sub RespaldarPares(ByVal TipoPerfil As Integer, ByVal ClienteSicyID As String, ByVal LstAtencionClientesID As String, ByVal LstAgenteID As String, ByVal UsuarioCreoIDColaboradorID As Integer, ByVal UsuarioID As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts

        'Me.LimpiarParesRespaldo(UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)

        If TipoPerfil = 0 Then
            'Respaldar solo los clientes asociados a la de atencion clientes
            objProspecta.RespaldarPares("", UsuarioCreoIDColaboradorID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)
        ElseIf TipoPerfil = 1 Then
            'Respaldar solo los clientes asociados al agente de ventas
            objProspecta.RespaldarPares("", "", "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)
        ElseIf TipoPerfil = 2 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarPares(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)
        ElseIf TipoPerfil = 3 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarPares(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)
        End If

        'objProspecta.RespaldarPares(ClienteSicyID, LstAtencionClientesID, LstAgenteID, UsuarioCreoID)
    End Sub

    Public Function ConsultaUsuarioAtencionClientes() As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultarColaboradorAtencionClientes()
    End Function

    Public Sub LimpiarParesRespaldo(ByVal UsuarioCreoIDColaborador As Integer, ByVal TipoPerfil As Int32, ByVal UsuarioID As Int32)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.LimpiarParesRespaldo(UsuarioCreoIDColaborador, TipoPerfil, UsuarioID)
    End Sub

    Public Sub CancelarProspecta(ByVal ProspectaID As Integer, ByVal UsuarioModificoID As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.CancelarProspecta(ProspectaID, UsuarioModificoID)
    End Sub


    Public Sub DesbloquearProspectaActivaUsuario(ByVal UsuarioID As Integer, ByVal ColaboradorId As Integer, ByVal ProspectaId As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.DesbloquearProspectaActivaUsuario(UsuarioID, ColaboradorId, ProspectaId)

        'Me.LimpiarParesRespaldo(UsuarioID, 0, 0)
        If ProspectaId = -1 Then
            Me.LimpiarParesRespaldo(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, 0)
        End If


    End Sub

    Public Sub RegistrarActivadadUsuarioProspecta(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer, ByVal EsConsulta As Boolean)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.RegistrarActivadadUsuarioProspecta(UsuarioID, ProspectaId, EsConsulta)

        'objProspecta.LimpiarParesRespaldo("", "", "")
    End Sub

    Public Function ConsultaActividadUsuario(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer) As Boolean
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaActividadUsuario(UsuarioID, ProspectaId)
    End Function

    Public Function ObtenerParesConfirmados(ByVal ProspectaID As Integer, ByVal AtencionClienteID As String, ByVal ClienteSayID As String, ByVal AgenteID As String) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ObtenerParesConfirmados(ProspectaID, AtencionClienteID, ClienteSayID, AgenteID)
    End Function

    Public Function ConsultaPedidosCliente(ByVal ProspectaID As Integer, ByVal ClienteID As String, ByVal FechaProgramacion As Date, ByVal AgenteID As String, ByVal MedirCumplimiento As Boolean) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaPedidosCliente(ProspectaID, ClienteID, FechaProgramacion, AgenteID, MedirCumplimiento)
    End Function

    Public Function ObtenerParesPorTipoEmpaque(ByVal ProspectaID As Integer, ByVal AtencionClienteID As String, ByVal ClienteSayID As String, ByVal AgenteID As String) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ObtenerParesPorTipoEmpaque(ProspectaID, AtencionClienteID, ClienteSayID, AgenteID)
    End Function

    Public Function ConsultaPartidasPedido(ByVal ProspectaID As Integer, ByVal PedidoID As String, ByVal FechaProgramacion As Date, ByVal AgenteID As String, FechaFinProspecta As Date, ByVal MedirCumplimiento As Boolean, ByVal FechaInicioProspecta As Date) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaPartidasPedido(ProspectaID, PedidoID, FechaProgramacion, AgenteID, FechaFinProspecta, MedirCumplimiento, FechaInicioProspecta)
    End Function


    Public Function ObtenerClienteSicyID(ByVal ClienteSayID As Int32) As Int32
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ObtenerClienteSicyID(ClienteSayID)
    End Function

    Public Sub GuardarInformacionCliente(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal ClienteSicyID As Integer, ByVal BL As String, ByVal SinInventario As String, _
                                       ByVal NumeroCotizaciones As Integer, ByVal PagosPend As String, ByVal EstatusBloqueoID As Integer, ByVal ProspectaPEND As Integer, ByVal ProspectaIALM As Integer, _
                                       ByVal ProspectaIPRO As Integer, ByVal ProspectaAXC As Integer, ByVal TotalPEND As Integer, ByVal TotalIALM As Integer, ByVal TotalIPRO As Integer, ByVal TotalAXC As Integer, _
                                       ByVal ProgramacionPEND As Integer, ByVal ProgramacionIALM As Integer, ByVal ProgramacionIPRO As Integer, ByVal ProgramacionAXC As Integer, _
                                       ByVal Confirmacion As Boolean, ByVal UsuarioConfirmo As Integer, ByVal FechaConfirmacion As Date, ByVal MotivoID As Integer, ByVal Observaciones As String, _
                                       ByVal TotalParesProspecta As Integer, ByVal UsuarioCreoID As Integer)

        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.GuardarInformacionCliente(ProspectaID, ClienteSayID, ClienteSicyID, BL, SinInventario, _
                                            NumeroCotizaciones, PagosPend, EstatusBloqueoID, ProspectaPEND, ProspectaIALM, _
                                            ProspectaIPRO, ProspectaAXC, TotalPEND, TotalIALM, TotalIPRO, TotalAXC, _
                                            ProgramacionPEND, ProgramacionIALM, ProgramacionIPRO, ProgramacionAXC, _
                                            Confirmacion, UsuarioConfirmo, FechaConfirmacion, MotivoID, Observaciones, _
                                            TotalParesProspecta, UsuarioCreoID)


    End Sub

    Public Sub EliminarParesProspectadosCliente(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.EliminarParesProspectadosCliente(ProspectaID, ClienteSayID)
    End Sub


    Public Function ObtenerUsuariosEdicionProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ObtenerUsuariosEdicionProspecta(ProspectaID)
    End Function

    Public Sub GuardarParesPendientesPorAgente(ByVal ProspectaID As Integer, ByVal FechaFinProspecta As Date, ByVal FechaProgramacion As Date)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.GuardarParesPendientesPorAgente(ProspectaID, FechaFinProspecta, FechaProgramacion)
    End Sub

    Public Sub ProspectaRespaldarParesMedicion(ByVal ProspectaID As Integer, ByVal FechaConsulta As Date)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.ProspectaRespaldarParesMedicion(ProspectaID, FechaConsulta)
    End Sub

    'INICIA NUEVOS DATOS PROSPECTA

    Public Sub RespaldarDatosProspecta(ByVal TipoPerfil As Integer, ByVal ClienteSicyID As String, ByVal LstAtencionClientesID As String, ByVal LstAgenteID As String, ByVal UsuarioCreoIDColaboradorID As Integer, ByVal UsuarioID As Integer, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Editando As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        '0 => AtnClientes , 1 => AgenteVts, 2 => Jefatura, 3=> AnalistaVts, 4 => AtnClientesExterno, 5 => Almacen

        'Me.LimpiarParesRespaldo(UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID)

        If TipoPerfil = 0 Then
            'Respaldar solo los clientes asociados a la de atencion clientes
            objProspecta.RespaldarDatosProspecta("", UsuarioCreoIDColaboradorID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)
        ElseIf TipoPerfil = 1 Then
            'Respaldar solo los clientes asociados al agente de ventas
            objProspecta.RespaldarDatosProspecta("", "", "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)
        ElseIf TipoPerfil = 2 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarDatosProspecta(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)
        ElseIf TipoPerfil = 3 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarDatosProspecta(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)
        ElseIf TipoPerfil = 4 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarDatosProspecta(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)
        ElseIf TipoPerfil = 5 Then
            'Respaldar todos los clientes
            objProspecta.RespaldarDatosProspecta(ClienteSicyID, LstAtencionClientesID, "", UsuarioCreoIDColaboradorID, TipoPerfil, UsuarioID, FechaInicio, FechaFin, Editando)

        End If

        'objProspecta.RespaldarPares(ClienteSicyID, LstAtencionClientesID, LstAgenteID, UsuarioCreoID)
    End Sub

    Public Function ConsultarDatosProspectaPorNivel(ByVal TipoConsulta As Integer, ByVal FiltroClientes As String, FiltroAtnClientes As String, ByVal FiltroAgenteVentas As String, ByVal Pedidos As String, ByVal ProspectaId As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        If String.IsNullOrEmpty(FiltroAtnClientes) = True Then
            FiltroAtnClientes = ""
        End If
        If String.IsNullOrEmpty(FiltroClientes) = True Then
            FiltroClientes = ""
        End If

        If String.IsNullOrEmpty(FiltroAgenteVentas) = True Then
            FiltroAgenteVentas = ""
        End If


        Return objProspecta.ConsultarDatosProspectaPorNivel(TipoConsulta, FiltroClientes, FiltroAtnClientes, FiltroAgenteVentas, Pedidos, ProspectaId) '1 = NIVEL CLIENTE, 2 = NIVEL PEDIDO, 3 = NIVEL PARTIDA

    End Function

    Public Sub RespaldarDatosProspectaDeSICY(Optional ByVal ProspectaID As Integer = -1, Optional ByVal ColaboradorID As Int32 = -1, Optional ByVal Editando As Boolean = False, Optional ByVal TipoPerfil As Int32 = -1)
        Dim objProspecta As New Ventas.Datos.ProspectaDA

        objProspecta.RespaldarDatosProspectaDeSICY(ProspectaID, ColaboradorID, Editando, TipoPerfil)

    End Sub

    Public Function ConsultaAgendaProyeccion(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaAgendaProyeccion(ProspectaID)
    End Function

    Public Function ConsultaAgendaEntrega(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaAgendaEntrega(ProspectaID)
    End Function

    Public Function ConsultarClientesConCita(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultarClientesConCita(ProspectaID)
    End Function

    Public Function ActualizarEncabezadoProspecta(ByVal ProspectaId As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ActualizarEncabezadoProspecta(ProspectaId)
    End Function

    Public Function ConsultarParesPendientesDeConfirmar(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultarParesPendientesDeConfirmar(ProspectaID)
    End Function

    Public Function ConsultaParesEnProceso(ByVal ProspectaId As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaParesEnProceso(ProspectaId, FechaInicio, FechaFin)
    End Function

    Public Function ConsultaParesEnReProceso(ByVal ProspectaId As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaParesEnReProceso(ProspectaId)
    End Function

    Public Function ConsultaParesBloqueados(ByVal ProspectaId As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaParesBloqueados(ProspectaId)
    End Function

    Public Function AltaProspecta(ByVal NumeroSemana As Integer, ByVal Año As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.AltaProspecta(NumeroSemana, Año, FechaInicio, FechaFin, UsuarioCreoID)
    End Function


    Public Sub GuardarInformacionProspecta(ByVal ProspectaId As Integer, ByVal ClienteSicyId As Integer, ByVal PedidoSicyID As Integer, ByVal PartidaId As Integer, _
                                                  ByVal ParesProcesoJ As Integer, ByVal ParesProcesoV As Integer, ByVal ParesProcesoL As Integer, ByVal ParesProcesoMa As Integer, ByVal ParesProcesoMi As Integer, _
                                                  ByVal ProspectarL As Boolean, ByVal ProspectarMa As Boolean, ByVal ProspectarMi As Boolean, ByVal ProspectarJ As Boolean, ByVal ProspectarV As Boolean, ByVal ProspectarS As Boolean, _
                                                  ByVal ProyectarJ As Integer, ByVal ProyectarV As Integer, ByVal ProyectarL As Integer, ByVal ProyectarMa As Integer, ByVal ProyectarMi As Integer, ByVal UsuarioId As Integer)

        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.GuardarInformacionProspecta(ProspectaId, ClienteSicyId, PedidoSicyID, PartidaId, _
                                                 ParesProcesoJ, ParesProcesoV, ParesProcesoL, ParesProcesoMa, ParesProcesoMi, _
                                                 ProspectarL, ProspectarMa, ProspectarMi, ProspectarJ, ProspectarV, ProspectarS, _
                                                  ProyectarJ, ProyectarV, ProyectarL, ProyectarMa, ProyectarMi, UsuarioId)
    End Sub


    Public Function ActualizarStatusProspecta(ByVal idProspecta As Integer, ByVal siguienteStatus As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ActualizarStatusProspecta(idProspecta, siguienteStatus)
    End Function


    Public Function ConsultaComentarioRevisionProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaComentarioRevisionProspecta(ProspectaID)
    End Function

    Public Function InsertarComentario(ByVal ProspectaID As Integer, ByVal Comentario As String, ByVal UsuarioID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.InsertarComentario(ProspectaID, Comentario, UsuarioID)
    End Function

    Public Function ConsultarEntregasPorDia(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA

        'If ProspectaID <> -1 Then
        '    objProspecta.ActualizarEncabezadoProspecta(ProspectaID)
        'End If

        Return objProspecta.ConsultarEntregasPorDia(ProspectaID)

    End Function

    Public Function ProspectaProxima(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ProspectaProxima(FechaInicio, FechaFin)
    End Function


    Public Function ProspectaVigente(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ProspectaVigente(FechaInicio, FechaFin)
    End Function

    Public Function ActualizarProspectaVigente() As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ActualizarProspectaVigente()
    End Function

    Public Function CerrarProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.CerrarProspecta(ProspectaID)


    End Function

    Public Function ObtenerProspectaVigente() As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ObtenerProspectaVigente()
    End Function

    Public Sub LimpiarTablasPropectaVigente()
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.LimpiarTablasPropectaVigente()
    End Sub

    Public Sub LimpiarTablasProspectaNoGuardada()
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.LimpiarTablasProspectaNoGuardada()
    End Sub


    Public Sub LimpiarUsuarioEditando(ByVal ProspectaId As Integer)
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.LimpiarUsuarioEditando(ProspectaId)
    End Sub

    Public Function ConsultaUsuariosEditando(ByVal ProspectaId As Integer, ByVal UsuarioSesionID As Integer) As Integer
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaUsuariosEditando(ProspectaId, UsuarioSesionID)
    End Function

    Public Function ValidaSemanaProspecta(ByVal NumeroSemana As Integer, ByVal Año As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ValidaSemanaProspecta(NumeroSemana, Año)
    End Function

    Public Sub ActualizarProspectaCerrada()
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        objProspecta.ActualizarProspectaCerrada()
    End Sub

    Public Function ConsultaProspectaAlmacen(ByVal ProspectaId As Integer, ByVal ClienteId As String) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaProspectaAlmacen(ProspectaId, ClienteId)
    End Function

    Public Function ConsultaProspectaAlmacen_PorMarca(ByVal ProspectaId As Integer, ByVal ClienteId As String) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaProspectaAlmacen_PorMarca(ProspectaId, ClienteId)
    End Function

    Public Function ConsultaProspectaAlmacenTotales(ByVal ProspectaId As Integer) As DataTable
        Dim objProspecta As New Ventas.Datos.ProspectaDA
        Return objProspecta.ConsultaProspectaAlmacenTotales(ProspectaId)
    End Function

    Public Function ConsultaMarcas()
        Dim datos As New Datos.ProspectaDA
        Return datos.ConsultaMarcas()
    End Function

    Public Function ConsultaTotalesMarcas(ByVal prospectaID As Integer, ByVal marcas As String)
        Dim datos As New Datos.ProspectaDA
        Return datos.ConsultaTotalesMarcas(prospectaID, marcas)
    End Function
End Class
