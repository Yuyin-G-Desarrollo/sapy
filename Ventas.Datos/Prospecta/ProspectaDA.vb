Imports System.Data.SqlClient

Public Class ProspectaDA


    Public Sub GuardarPartidaProspecta(ByVal ProspectaID As Int32, ByVal ClienteSicy As Int32, ByVal clienteSayID As Int32, ByVal PedidoSicyId As Int32, ByVal PartidaId As Int32, ByVal FechaProgramacionPartida As Date, ByVal PEND As Int32, ByVal IALM As Int32, ByVal IPRO As Int32, ByVal AXC As Int32, ByVal UsuarioCreoID As Int32, ByVal CodigoSicy As String, ByVal IdTalla As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSicy"
        parametro.Value = ClienteSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteSayID"
        parametro.Value = clienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSicyId"
        parametro.Value = PedidoSicyId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PartidaId"
        parametro.Value = PartidaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacionPartida"
        parametro.Value = FechaProgramacionPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PEND"
        parametro.Value = PEND
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IALM"
        parametro.Value = IALM
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IPRO"
        parametro.Value = IPRO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AXC"
        parametro.Value = AXC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoSicy"
        parametro.Value = CodigoSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdTalla"
        parametro.Value = IdTalla
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Insertar_Registro_Partida]", listaParametros)


    End Sub

    ''' <summary>
    ''' Actualiza el  numero de pares prospectados y el usuario quien modifico la informacion de la prospecta
    ''' </summary>
    ''' <param name="ProspectaID"></param>
    ''' <param name="UsuarioID"></param>  
    ''' <remarks></remarks>
    Public Sub ActualizarInformacionProspecta(ByVal ProspectaID As Int32, ByVal UsuarioID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Actualizar_Informacion_Prospecta]", listaParametros)

    End Sub

    Public Sub GuardarIncidenciasProspecta(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal Confirma As Boolean, ByVal UsuarioIdConfirma As Integer, ByVal FechaConfirmacion As Date, ByVal MotivoIncidencia As Integer, ByVal Observaciones As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSayID"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Confirma"
        parametro.Value = Confirma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDConfirma"
        If UsuarioIdConfirma = -1 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = UsuarioIdConfirma
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        If FechaConfirmacion = FechaNula Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FechaConfirmacion
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoIncidencia"
        parametro.Value = MotivoIncidencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Observaciones
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar_Incidencias]", listaParametros)

    End Sub

    Public Function ObtenerClienteSicyID(ByVal ClienteSayID As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim ClienteSicyID As Integer = 0

        consulta += "Select clie_idsicy "
        consulta += "from Cliente.Cliente "
        consulta += "where clie_clienteid =" + ClienteSayID.ToString() + " "

        ClienteSicyID = operaciones.EjecutaConsultaEscalar(consulta)
        Return ClienteSicyID
    End Function

    Public Sub LimpiarPlaneacionPartida(ByVal ClienteSayID As Integer, ByVal ProspectaID As Integer, ByVal PedidoSicyID As Integer, ByVal Partida As Integer, ByVal UsuarioModificoID As Integer)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ClienteSayID"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSicy"
        parametro.Value = PedidoSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioModificoID
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Limpiar_Planeacion_Cliente]", listaParametros)


    End Sub


    Public Function ObtenerProspectaIDGuardada() As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim ProspectaID As Integer = 0
        consulta += "SELECT MAX(pros_prospectaid) "
        consulta += "FROM Ventas.Prospecta "
        ProspectaID = operaciones.EjecutaConsultaEscalar(consulta)
        Return ProspectaID
    End Function

    Public Sub EditarPlaneacionProspecta(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal PedidoSicy As Integer, ByVal Partida As Integer, ByVal ParesPlaneacion As Integer, ByVal FechaDistribucionPares As Date, ByVal UsuarioId As Integer, _
                                         ByVal PedidoDetalleID As Int32, ByVal FechaProgramacion As Date, ByVal ParesPEND As Int32, ByVal ParesIALM As Int32, ByVal ParesIPRO As Int32, ByVal ParesAXC As Int32, _
                                         ByVal IdCodigoSicy As String, ByVal IdTalla As String, ByVal ProductoEstiloID As Int32, ByVal MarcaID As Int32, ByVal FamiliaProyeccion As Int32, ByVal IdTienda As Int32, _
                                         ByVal FechaCaptura As Date, ByVal ParesPartida As Int32, ByVal TotalParesPEND As Int32, ByVal TotalParesIALM As Int32, ByVal TotalParesIPRO As Int32, ByVal TotalParesAXC As Int32, _
                                         ByVal ProspectaPEND As Int32, ByVal ProspectaIALM As Int32, ByVal ProspectaIPRO As Int32, ByVal ProspectaAXC As Int32)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim FechaNula As Date = Nothing
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSayID"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSicy"
        parametro.Value = PedidoSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesPlaneacion"
        parametro.Value = ParesPlaneacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDistribucionPares"
        parametro.Value = FechaDistribucionPares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pedidodetalleid"
        parametro.Value = PedidoDetalleID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        If FechaProgramacion = FechaNula Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FechaProgramacion
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "paresPEND"
        parametro.Value = ParesPEND
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresIALM"
        parametro.Value = ParesIALM
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresIPRO"
        parametro.Value = ParesIPRO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresAXC"
        parametro.Value = ParesAXC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idcodigosicy"
        If IsNothing(IdCodigoSicy) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = IdCodigoSicy
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idtalla"
        If IsNothing(IdTalla) = True Then
            parametro.Value = IdTalla
        Else
            parametro.Value = IdTalla
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prosuctoestilo"
        If IsNothing(ProductoEstiloID) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProductoEstiloID
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marcaid"
        If IsNothing(MarcaID) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = MarcaID
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "familiaproyeccion"
        If IsNothing(FamiliaProyeccion) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FamiliaProyeccion
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idtienda"
        If IsNothing(IdTienda) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = IdTienda
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechacaptura"

        If FechaCaptura = FechaNula Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FechaCaptura
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "parespartidasicy"
        parametro.Value = ParesPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesPEND"
        parametro.Value = TotalParesPEND
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesIALM"
        parametro.Value = TotalParesIALM
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesIPRO"
        parametro.Value = TotalParesIPRO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesAXC"
        parametro.Value = TotalParesAXC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaPEND"
        parametro.Value = ProspectaPEND
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaIALM"
        parametro.Value = ProspectaIALM
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaIPRO"
        parametro.Value = ProspectaIPRO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaAXC"
        parametro.Value = ProspectaAXC
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Editar_Planeacion]", listaParametros)


    End Sub

    Public Sub GuardarProspecta(ByVal NumeroSemana As Int32, ByVal Año As Int32, ByVal FechaInicio As Date, ByVal FechaFin As Date, _
                                ByVal FechaProgramacion As Date, ByVal UsuarioCreoID As Int32, ByVal ParesProspecta As Int32, _
                                ByVal ParesProyctados As Int32, ByVal ParesConfirmados As Int32, ByVal ParesEmbarcados As Int32, _
                                ByVal ParesSalida As Int32)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "NumeroSemana"
        parametro.Value = NumeroSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = FechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProspecta"
        parametro.Value = ParesProspecta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectados"
        parametro.Value = ParesProyctados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesConfirmados"
        parametro.Value = ParesConfirmados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesEmbarcados"
        parametro.Value = ParesEmbarcados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesSalida"
        parametro.Value = ParesSalida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusProspecta"
        parametro.Value = 87
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar]", listaParametros)

    End Sub

    Public Function ComprobarExisteParesTemporal() As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "  "
        Dim Resultado As Integer = 0
        Dim ExistenParesTemporal As Boolean = False
        consulta += "SELECT COUNT(*) FROM Ventas.Prospecta_ExistenciaTemporal"
        Resultado = operaciones.EjecutaConsultaEscalar(consulta)

        If Resultado = 0 Then
            ExistenParesTemporal = False
        Else
            ExistenParesTemporal = True
        End If

        Return ExistenParesTemporal
    End Function

    Public Sub LimpiarTemporalPares()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Limpiar_Pares]", listaParametros)

    End Sub

    Public Function ActualizarProspecta(ByVal ObjProspecta As Entidades.ProspectaDetalle) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaId"
        parametro.Value = ObjProspecta.ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ObjProspecta.ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IncidenciaId"
        parametro.Value = ObjProspecta.MotivoIncidenciaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = ObjProspecta.Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Confirma"
        parametro.Value = ObjProspecta.Confirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_EditarProspecta]", listaParametros)


    End Function

    Public Sub ActualizarParesDia(ByVal ProspectaID As Integer, ByVal ClienteId As Integer, ByVal Fecha As Date, ByVal CantidadPares As String)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaId"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Fecha"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantidadPares"
        parametro.Value = CantidadPares
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_EditarProspectaDia]", listaParametros)
    End Sub

    Public Function ObtenerParesConfirmados(ByVal ProspectaID As Integer, ByVal AtencionClienteID As String, ByVal ClienteSayID As String, ByVal AgenteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaId"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtencionCliente"
        parametro.Value = AtencionClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteID"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ParesConfirmados]", listaParametros)
    End Function

    Public Function ObtenerParesPorTipoEmpaque(ByVal ProspectaID As Integer, ByVal AtencionClienteID As String, ByVal ClienteSayID As String, ByVal AgenteID As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaId"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtencionCliente"
        parametro.Value = AtencionClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteID"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ParesXTipoEmpaque]", listaParametros)
    End Function


    Public Function ObtenerFechasProximaProspecta() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaFechaProximaProspecta]", listaParametros)
    End Function

    Public Function ObtenerInformacionUsuarioActivo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT top 1 usr.user_username as UserName, act.actv_fechainicioactividad as FActividad  "
        consulta += "from Ventas.Prospecta_ActividadUsuario act inner join Framework.Usuarios usr  "
        consulta += "on act.actv_usuarioactividadid = usr.user_usuarioid "
        consulta += "where act.actv_proceso ='AltaProspectaForm' "

        'consulta += "SELECT AU.actv_actividadid AS ActividadID,AU.actv_pchost AS PCHOST,AU.actv_proceso AS Proceso, "
        'consulta += "AU.actv_fechainicioactividad As FechaInicioActividad,AU.actv_fechafinactividad As FechaFinActividad,  "
        'consulta += "Au.actv_pantalla AS Pantalla,FU.user_username AS UserName "
        'consulta += "FROM Ventas.Prospecta_ActividadUsuario AU INNER JOIN Framework.Usuarios FU "
        'consulta += "ON  AU.actv_usuarioactividadid = FU.user_usuarioid "
        'consulta += "order  BY AU.actv_actividadid  DESC "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerInformacionUsuarioAltaProspecta() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT top 1 usr.user_username as UserName, act.actv_fechainicioactividad as FActividad  "
        consulta += "from Ventas.Prospecta_ActividadUsuario act inner join Framework.Usuarios usr  "
        consulta += "on act.actv_usuarioactividadid = usr.user_usuarioid "
        consulta += "where act.actv_pantalla ='AltaProspectaForm' "

        'consulta += "SELECT AU.actv_actividadid AS ActividadID,AU.actv_pchost AS PCHOST,AU.actv_proceso AS Proceso, "
        'consulta += "AU.actv_fechainicioactividad As FechaInicioActividad,AU.actv_fechafinactividad As FechaFinActividad,  "
        'consulta += "Au.actv_pantalla AS Pantalla,FU.user_username AS UserName "
        'consulta += "FROM Ventas.Prospecta_ActividadUsuario AU INNER JOIN Framework.Usuarios FU "
        'consulta += "ON  AU.actv_usuarioactividadid = FU.user_usuarioid "
        'consulta += "order  BY AU.actv_actividadid  DESC "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerTiposEmpaque() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta += "SELECT tiem_tipoempaqueid as TipoEmpaqueID, tiem_nombre as Nombre,'0' AS Total "
        consulta += "FROM Ventas.TipoEmpaque "
        consulta += "ORDER BY tiem_nombre ASC "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub RespaldarPares(ByVal ClienteSicyID As String, ByVal LstAtencionClientesID As String, ByVal LstAgenteID As String, ByVal UsuarioCreoIDColaborador As Integer, ByVal TipoPerfil As Int32, ByVal UsuarioID As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteSicyID"
        parametro.Value = ClienteSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnCtes_SAYID"
        parametro.Value = LstAtencionClientesID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agente_SAYID"
        parametro.Value = LstAgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario_SAYID"
        If UsuarioCreoIDColaborador = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = UsuarioCreoIDColaborador
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDUSR"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)


        'objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares]", listaParametros)        
        'objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_Omar_29Sep2016]", listaParametros)
        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_AVV_14Oct2016v2]", listaParametros)
        'objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_AVV_14Oct2016]", listaParametros)        


    End Sub


    Public Sub LimpiarParesRespaldo(ByVal UsuarioCreoIDColaborador As Integer, ByVal TipoPerfil As Int32, ByVal UsuarioID As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "Usuario_SAYID"
        parametro.Value = UsuarioCreoIDColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDUSR"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Limpiar_Pares_Respaldo]", listaParametros)

    End Sub


    Public Function ValidarExisteProspectaProxima() As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        Dim Resultado As Integer = 0
        Dim ExisteProsectaProxima As Boolean = False

        '87 Estatus de proxima
        consulta = "SELECT COUNT(*) "
        consulta += "FROM Ventas.Prospecta_ "
        consulta += "WHERE pros_estatusid IN ( 87,90) "
        Resultado = operaciones.EjecutaConsultaEscalar(consulta)

        If Resultado = 0 Then
            ExisteProsectaProxima = False
        Else
            ExisteProsectaProxima = True
        End If

        Return ExisteProsectaProxima
    End Function


    Public Function ComprobarProspectaModoEdicion(ByVal ProspectaID As Integer) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        Dim Resultado As Integer = 0
        Dim ExisteProsectaProxima As Boolean = False

        consulta += "SELECT COUNT(*) "
        consulta += "FROM Ventas.Prospecta "
        consulta += "WHERE pros_prospectaid ='" + ProspectaID.ToString() + "' "
        consulta += "AND pros_bloqueado =1 "

        Resultado = operaciones.EjecutaConsultaEscalar(consulta)

        If Resultado = 0 Then
            ExisteProsectaProxima = False
        Else
            ExisteProsectaProxima = True
        End If

        Return ExisteProsectaProxima
    End Function

    Public Function CargarInformacionProspecta(ByVal ProspectaID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Informacion_Prospecta]", listaParametros)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "  "

        'consulta = "SELECT PIN.pros_prospectaid as  prin_prospectaid, "
        'consulta += "PIN.pros_numerosemana as prin_numerosemana, "
        'consulta += "PIN.pros_año as  prin_año,  "
        'consulta += "PIN.pros_fechainicio as prin_fechainicio, "
        'consulta += "PIN.pros_fechafin as prin_fechafin, "
        'consulta += "PIN.pros_usuariocreoid as  prin_usuariocreoId, "
        'consulta += "PIN.pros_fechacreacion as  prin_fechacreacion,  "
        'consulta += "PIN.pros_fechafin as  prin_fechaprogramacion,  "
        'consulta += "PIN.pros_usuariomodificoid as  prin_usuariomodificoId, "
        'consulta += "PIN.pros_fechamodificacion as prin_fechamodificacion, "
        'consulta += "ISNULL( PIN.pros_paresprospecta,0) as prin_paresprospecta , "
        'consulta += "isnull (PIN.pros_paresproyectados,0) as prin_paresproyectados, "
        'consulta += "ISNULL( PIN.pros_paresconfirmadosordentrabajo,0) as prin_paresconfirmadosordentrabajo,  "
        'consulta += "ISNULL( PIN.pros_paresembarcados,0) as prin_paresembarcados, "
        'consulta += "ISNULL( PIN.pros_paressalida,0) as prin_paressalida, "
        'consulta += "PIN.pros_estatusid as prin_estatusprospecta,	 "
        'consulta += "pin.pros_bloqueado as  	prin_estatusbloqueo,  "
        'consulta += "PIN.pros_activo AS  prin_activo,COL.user_username as UsuarioCreo, COLM.user_username as UsuarioModifico , "
        'consulta += "ST.esta_nombre AS EstatusProspecta "
        'consulta += "from Ventas.Prospecta PIN left join Framework.Usuarios COL ON  "
        'consulta += "PIN.pros_usuariocreoid = COL.user_usuarioid left JOIN  "
        'consulta += "Framework.Usuarios COLM on PIN.pros_usuariomodificoid =COLM.user_usuarioid  "
        'consulta += "INNER JOIN Framework.Estatus st ON PIN.pros_estatusid = ST.esta_estatusid "
        'consulta += "where PIN.pros_prospectaid = '" + ProspectaID.ToString() + "' "

        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub CancelarProspecta(ByVal ProspectaID As Integer, ByVal UsuarioModificoID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificoID"
        parametro.Value = UsuarioModificoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Cancelar_Prospecta]", listaParametros)
    End Sub



    Public Sub DesbloquearProspectaActivaUsuario(ByVal UsuarioID As Integer, ByVal ColaboradorID As Integer, ByVal ProspectaId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colabodorid"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Liberar_ActividadUsuario]", listaParametros)

    End Sub

    Public Sub RegistrarActivadadUsuarioProspecta(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer, ByVal EsConsulta As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prospestaId"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsConsulta"
        parametro.Value = EsConsulta
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Registra_ActividadUsuario]", listaParametros)

    End Sub

    Public Function ConsultaActividadUsuario(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer) As Boolean
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim Resultado As Integer = 0
        Dim dtResultado As DataTable
        Dim ExisteActividadUsuario As Boolean = False
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prospestaId"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)
        dtResultado = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ActividadUsuario]", listaParametros)

        Resultado = CInt(dtResultado.Rows(0).Item(0).ToString())

        If Resultado = 1 Then
            ExisteActividadUsuario = True
        Else
            ExisteActividadUsuario = False
        End If
        Return ExisteActividadUsuario

    End Function



    Public Function ConsultarNumeroDeUsuariosConsulta(ByVal UsuarioID As Integer, ByVal ProspectaId As Integer) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim Resultado As Integer = 0
        Dim dtResultado As DataTable
        Dim ExisteActividadUsuario As Int32 = 0
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prospestaId"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)
        dtResultado = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ActividadUsuario]", listaParametros)

        Resultado = CInt(dtResultado.Rows(0).Item(0).ToString())

        If Resultado > 0 Then
            ExisteActividadUsuario = Resultado
        Else
            ExisteActividadUsuario = 0
        End If
        Return ExisteActividadUsuario

    End Function

    Public Function ConsultarColaboradorAtencionClientes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim consulta As String = String.Empty
        consulta += "SELECT IdColaborador, Nombre "
        consulta += "FROM vColaboradores "
        consulta += "WHERE IdPuesto = 274 "
        consulta += "ORDER  BY Nombre ASC "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaHistorialProspecta(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NumeroSemna"
        parametro.Value = NumeroSemana
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_PROSPECTA_CONSULTA_HISTORIAL]", listaParametros)
    End Function

    Public Function ConsultaProspecta(ByVal ProspectaID As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FechaProgramacion As Date, ByVal AtencionClientes As String, ByVal AgenteID As String, ByVal MedirCumplimiento As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = FechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtencionClienteID"
        parametro.Value = AtencionClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteID"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MedirCumplimiento"
        parametro.Value = MedirCumplimiento
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_3]", listaParametros)


    End Function

    Public Function ConsultaPedidosCliente(ByVal ProspectaID As Integer, ByVal ClienteID As String, ByVal FechaProgramacion As Date, ByVal AgenteID As String, ByVal MedirCumplimiento As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = FechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteID"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MedirCumplimiento"
        parametro.Value = MedirCumplimiento
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pedido_3]", listaParametros)
    End Function

    Public Function ConsultaPartidasPedido(ByVal ProspectaID As Integer, ByVal PedidoID As String, ByVal FechaProgramacion As Date, ByVal AgenteID As String, ByVal FechaFinProspecta As Date, ByVal MedirCumplimiento As Boolean, ByVal FechaInicioProspecta As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoID"
        parametro.Value = PedidoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = FechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteID"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinProspecta"
        parametro.Value = FechaFinProspecta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MedirCumplimiento"
        parametro.Value = MedirCumplimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicioProspecta"
        parametro.Value = FechaInicioProspecta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Partida_4]", listaParametros)
    End Function

    Public Sub GuardarInformacionCliente(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer, ByVal ClienteSicyID As Integer, ByVal BL As String, ByVal SinInventario As String, _
                                         ByVal NumeroCotizaciones As Integer, ByVal PagosPend As String, ByVal EstatusBloqueoID As Integer, ByVal ProspectaPEND As Integer, ByVal ProspectaIALM As Integer, _
                                         ByVal ProspectaIPRO As Integer, ByVal ProspectaAXC As Integer, ByVal TotalPEND As Integer, ByVal TotalIALM As Integer, ByVal TotalIPRO As Integer, ByVal TotalAXC As Integer, _
                                         ByVal ProgramacionPEND As Integer, ByVal ProgramacionIALM As Integer, ByVal ProgramacionIPRO As Integer, ByVal ProgramacionAXC As Integer, _
                                         ByVal Confirmacion As Boolean, ByVal UsuarioConfirmo As Integer, ByVal FechaConfirmacion As Date, ByVal MotivoID As Integer, ByVal Observaciones As String, _
                                         ByVal TotalParesProspecta As Integer, ByVal UsuarioCreoID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim FechaNula As Date = Nothing



        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSayID"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSicyID"
        parametro.Value = ClienteSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "BL"
        parametro.Value = BL
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SinInventario"
        If IsNothing(SinInventario) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = SinInventario
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NumeroCotizaciones"
        If IsNothing(NumeroCotizaciones) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = NumeroCotizaciones
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PagosPendientes"
        If IsNothing(PagosPend) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = PagosPend
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusBloqueoID"
        If IsNothing(EstatusBloqueoID) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = EstatusBloqueoID
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaPEND"
        If IsDBNull(ProspectaPEND) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProspectaPEND
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaIALM"
        If IsDBNull(ProspectaIALM) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProspectaIALM
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaIPRO"
        If IsDBNull(ProspectaIPRO) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProspectaIPRO
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaAXC"
        If IsDBNull(ProspectaAXC) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProspectaAXC
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalPEND"
        If IsDBNull(TotalPEND) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TotalPEND
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalIALM"
        If IsDBNull(TotalIALM) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TotalIALM
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalIPRO"
        If IsDBNull(TotalIPRO) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TotalIPRO
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalAXC"
        If IsDBNull(TotalAXC) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TotalAXC
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramacionPEND"
        If IsDBNull(ProgramacionPEND) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProgramacionPEND
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramacionIALM"
        If IsDBNull(ProgramacionIALM) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProgramacionIALM
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramacionIPRO"
        If IsDBNull(ProgramacionIPRO) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProgramacionIPRO
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramacionAXC"
        If IsDBNull(ProgramacionAXC) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = ProgramacionAXC
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConfirmacionEntrega"
        If IsDBNull(Confirmacion) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Confirmacion
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioConfirmo"
        If IsDBNull(UsuarioConfirmo) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = UsuarioConfirmo
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        If FechaConfirmacion = FechaNula Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FechaConfirmacion
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoID"
        If IsDBNull(MotivoID) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = MotivoID
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        If IsDBNull(Observaciones) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Observaciones
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesProspecta"
        If IsDBNull(TotalParesProspecta) = True Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TotalParesProspecta
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar_Cliente]", listaParametros)

    End Sub



    Public Sub EliminarParesProspectadosCliente(ByVal ProspectaID As Integer, ByVal ClienteSayID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteSayID"
        parametro.Value = ClienteSayID
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Eliminar_Planeacion_Cliente]", listaParametros)
    End Sub


    Public Function ObtenerUsuariosEdicionProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Usuarios_Edicion]", listaParametros)
    End Function


    Public Sub GuardarParesPendientesPorAgente(ByVal ProspectaID As Integer, ByVal FechaFinProspecta As Date, ByVal FechaProgramacion As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinProspecta"
        parametro.Value = FechaFinProspecta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = FechaProgramacion
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar_ParesPorAgente]", listaParametros)


    End Sub

    Public Sub ProspectaRespaldarParesMedicion(ByVal ProspectaID As Integer, ByVal FechaConsulta As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaConsulta"
        parametro.Value = FechaConsulta
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_GuardarMedicionTemporal]", listaParametros)

    End Sub


    '[Ventas].[SP_Prospecta_GuardarMedicionTemporal]	


    Public Sub RespaldarDatosProspecta(ByVal ClienteSicyID As String, ByVal LstAtencionClientesID As String, ByVal LstAgenteID As String, ByVal UsuarioCreoIDColaborador As Integer, ByVal TipoPerfil As Int32, ByVal UsuarioID As Int32, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Editando As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteSicyID"
        parametro.Value = ClienteSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnCtes_SAYID"
        parametro.Value = LstAtencionClientesID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agente_SAYID"
        parametro.Value = LstAgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario_SAYID"
        If UsuarioCreoIDColaborador = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = UsuarioCreoIDColaborador
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioIDUSR"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Editando"
        parametro.Value = Editando
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_LM]", listaParametros)


    End Sub

    Public Function ConsultarDatosProspectaPorNivel(ByVal TipoConsulta As Integer, ByVal FiltroClientes As String, FiltroAtnClientes As String, ByVal FiltroAgenteVentas As String, ByVal Pedidos As String, ByVal ProspectaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "TipoConsulta"
        parametro.Value = TipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = FiltroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = FiltroAtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = FiltroAgenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Pedidos"
        parametro.Value = Pedidos
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ProspectaId"
        parametro.Value = If(ProspectaId = -1, 0, ProspectaId)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultasTresNiveles]", listaParametros)


    End Function

    Public Sub RespaldarDatosProspectaDeSICY(Optional ByVal ProspectaID As Integer = -1, Optional ByVal ColaboradorID As Int32 = -1, Optional ByVal Editando As Boolean = False, Optional ByVal TipoPerfil As Int32 = -1)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Editando"
        parametro.Value = Editando
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_RespaldarDatosInicialesDeSICY]", listaParametros)

    End Sub

    Public Function ConsultaAgendaProyeccion(ByVal ProspectaID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAgendaProyeccion]", listaParametros)

    End Function


    Public Function ConsultaAgendaEntrega(ByVal ProspectaID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAgendaEntrega]", listaParametros)

    End Function


    Public Function ConsultarClientesConCita(ByVal ProspectaID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaClientesConCita]", listaParametros)

    End Function


    Public Function ActualizarEncabezadoProspecta(ByVal ProspectaId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Actualizar_Informacion_Prospecta]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Actualizar_Informacion_Encabezado]", listaParametros)

    End Function


    Public Function ConsultarParesPendientesDeConfirmar(ByVal ProspectaId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaApartadosPorConfirmar]", listaParametros)

    End Function

    Public Function ConsultaParesEnProceso(ByVal ProspectaId As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Fecha_Inicio_Prospecta"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Fecha_Fin_Prospecta"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ParesEnProceso]", listaParametros)

    End Function

    Public Function ConsultaParesEnReProceso(ByVal ProspectaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ParesReproceso]", listaParametros)

    End Function


    Public Function ConsultaParesBloqueados(ByVal ProspectaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_ParesBloqueados]", listaParametros)

    End Function


    Public Function AltaProspecta(ByVal NumeroSemana As Integer, ByVal Año As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "NumeroSemana"
        parametro.Value = NumeroSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar]", listaParametros)

    End Function



    Public Sub GuardarInformacionProspecta(ByVal ProspectaId As Integer, ByVal ClienteSicyId As Integer, ByVal PedidoSicyID As Integer, ByVal PartidaId As Integer, _
                                                  ByVal ParesProcesoJ As Integer, ByVal ParesProcesoV As Integer, ByVal ParesProcesoL As Integer, ByVal ParesProcesoMa As Integer, ByVal ParesProcesoMi As Integer, _
                                                  ByVal ProspectarL As Boolean, ByVal ProspectarMa As Boolean, ByVal ProspectarMi As Boolean, ByVal ProspectarJ As Boolean, ByVal ProspectarV As Boolean, ByVal ProspectarS As Boolean, _
                                                  ByVal ProyectarJ As Integer, ByVal ProyectarV As Integer, ByVal ProyectarL As Integer, ByVal ProyectarMa As Integer, ByVal ProyectarMi As Integer, ByVal UsuarioId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "ProspectaID"
        parametro.Value = If(ProspectaId = -1, 0, ProspectaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteSicyId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSicyID"
        parametro.Value = PedidoSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = PartidaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProcesoJ"
        parametro.Value = ParesProcesoJ
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProcesoV"
        parametro.Value = ParesProcesoV
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProcesoL"
        parametro.Value = ParesProcesoL
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProcesoMa"
        parametro.Value = ParesProcesoMa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProcesoMi"
        parametro.Value = ParesProcesoMi
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_L"
        parametro.Value = ProspectarL
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_Ma"
        parametro.Value = ProspectarMa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_Mi"
        parametro.Value = ProspectarMi
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_J"
        parametro.Value = ProspectarJ
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_v"
        parametro.Value = ProspectarV
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prospectar_Sa"
        parametro.Value = ProspectarS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectar_Ju"
        parametro.Value = ProyectarJ
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectar_Vi"
        parametro.Value = ProyectarV
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectar_Lu"
        parametro.Value = ProyectarL
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectar_Ma"
        parametro.Value = ProyectarMa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectar_Mi"
        parametro.Value = ProyectarMi
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioProspectoId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_GuardarInformacion]", listaParametros)


    End Sub




    Public Function ActualizarStatusProspecta(ByVal idProspecta As Integer, ByVal siguienteStatus As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idProspecta"
        parametro.Value = idProspecta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "statusNuevoProspecta"
        parametro.Value = siguienteStatus
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Actualizar_StatusProspecta]", listaParametros)

    End Function


    Public Function ConsultaComentarioRevisionProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim Comentario As String = String.Empty

        consulta = "SELECT isnull( p.pros_comentario,'') as Comentario,  "
        consulta += "p.pros_usuariocomentarioid as UsuarioComentario, "
        consulta += "usr.user_username as Usuario,   "
        consulta += "p.pros_fechacomentario as FechaComentario "
        consulta += "FROM Ventas.Prospecta_ p INNER JOIN Framework.Usuarios usr on p.pros_usuariocomentarioid= usr.user_usuarioid "
        consulta += "WHERE p.pros_prospectaid=" + ProspectaID.ToString() + " "

        Return objPersistencia.EjecutaConsulta(consulta)

    End Function


    Public Function InsertarComentario(ByVal ProspectaID As Integer, ByVal Comentario As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaId"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Comentario"
        parametro.Value = Comentario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoid"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Guardar_Comentarios_Revision]", listaParametros)

    End Function


    Public Function ConsultarEntregasPorDia(ByVal ProspectaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaId"
        parametro.Value = If(ProspectaID = -1, 0, ProspectaID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultasTotalEntregarPorDia]", listaParametros)

    End Function

    Public Function ProspectaProxima(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Editando"
        parametro.Value = 0
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_ProspectaProxima]", listaParametros)

    End Function

    Public Function ProspectaVigente(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Editando"
        parametro.Value = 0
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Pares_ProspectaVigente]", listaParametros)

    End Function

    Public Function ActualizarProspectaVigente() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ActualizarVigenteProspecta]", listaParametros)

    End Function

    Public Function CerrarProspecta(ByVal ProspectaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Cerrar]", listaParametros)
    End Function

    Public Function ObtenerProspectaVigente() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaProspectaVigente]", listaParametros)
    End Function

    Public Sub LimpiarTablasPropectaVigente()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ActualizarCerradaProspecta]", listaParametros)

    End Sub


    Public Sub LimpiarTablasProspectaNoGuardada()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Limpiar_Tablas]", listaParametros)
    End Sub

    Public Function ValidaSemanaProspecta(ByVal NumeroSemana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Semana"
        parametro.Value = NumeroSemana
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ValidaSemanaProspecta]", listaParametros)

    End Function


    Public Sub LimpiarUsuarioEditando(ByVal ProspectaId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Limpiar_UsuarioEditando]", listaParametros)
    End Sub

    Public Function ConsultaUsuariosEditando(ByVal ProspectaId As Integer, ByVal UsuarioSesionID As Integer) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim DTConsulta As DataTable
        Dim count As Integer = 0
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = ProspectaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioSesionID"
        parametro.Value = UsuarioSesionID
        listaParametros.Add(parametro)

        DTConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_UsuariosEditando]", listaParametros)
        If IsNothing(DTConsulta) = False Then
            count = DTConsulta.Rows(0).Item(0)
        End If

        Return count
    End Function

    Public Sub ActualizarProspectaCerrada()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Actualizar_Pares_ProspectaCerrada]", listaParametros)

    End Sub

    Public Function ConsultaProspectaAlmacen(ByVal ProspectaId As Integer, ByVal ClienteId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaID"
        parametro.Value = If(ProspectaId = -1, 0, ProspectaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAlmacen]", listaParametros)

    End Function

    Public Function ConsultaProspectaAlmacen_PorMarca(ByVal ProspectaId As Integer, ByVal ClienteId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProspectaID"
        parametro.Value = If(ProspectaId = -1, 0, ProspectaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marcas"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAlmacen_PorMarca]", listaParametros)

    End Function

    Public Function ConsultaProspectaAlmacenTotales(ByVal ProspectaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ProspectaId"
        parametro.Value = If(ProspectaId = -1, 0, ProspectaId)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAlmacen_Totales]", listaParametros)

    End Function

    Public Function ConsultaMarcas()
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaMarcas]", New List(Of SqlParameter))
    End Function

    Public Function ConsultaTotalesMarcas(ByVal prospectaID As Integer, ByVal marcas As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ProspectaId",
            .Value = prospectaID
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Marcas",
            .Value = marcas
        })

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_ConsultaAlmacen_PorMarca_Totales]", listaParametros)
    End Function

End Class
