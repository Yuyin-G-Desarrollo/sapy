Imports System.Data.SqlClient
Public Class BloqueoDA
    Public Function tabla(ByVal filtros As Entidades.FiltrosBloqueos) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Return operaciones.EjecutarConsultaSP("[Programacion].[SP_Bloqueos_Clientes_ConsultaClientesBloqueados]", New List(Of SqlClient.SqlParameter))

        ''09052019 SCDA Se agregan filtros de consulta
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Activos"
        parametro.Value = filtros.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Inactivos"
        parametro.Value = filtros.PInactivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Bloqueados"
        parametro.Value = filtros.PBloqueados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NoBloqueados"
        parametro.Value = filtros.PNoBloqueados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = filtros.PAnio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NoSemana"
        parametro.Value = filtros.PNoSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClientesId"
        parametro.Value = filtros.PClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AgentesId"
        parametro.Value = filtros.PAgentes
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Programacion.SP_Bloqueos_Clientes_ConsultaClientesBloqueados", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub InsertarSemana()
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DELETE FROM PROGRAMACION.BLOQUEOS where bloq_año =datepart(year,getdate()) and bloq_semana=case when year(getdate()) = 2021 then datepart(week,getdate())-1 else datepart(week,getdate()) end"
        operaciones.EjecutaSentencia(consulta)
        If operaciones.Servidor = obj.Servidor Then
            consulta = "INSERT INTO " +
                               " Programacion.Bloqueos (bloq_idCadena,bloq_año,bloq_semana,bloq_captura,bloq_programacion,bloq_entrega," +
                               "bloq_contado,bloq_motivoid,bloq_fechamodificacion,bloq_usuariomodificaid,bloq_clienteid)" +
                               " SELECT idCadena,datepart(year,getdate()),case when year(getdate()) = 2021 then datepart(week,getdate())-1 else datepart(week,getdate()) end,Captura,Programacion,Entrega,Contado " +
                               " ,idtblMotivo ,getdate(),'" + idUsuario.ToString + "',clie_clienteid" +
                               " FROM [" + obj.NombreDB + "].dbo.Bloqueo INNER JOIN Cliente.Cliente" +
                               " ON idCadena = clie_idsicy WHERE clie_activo = 1"
        Else
            consulta = "INSERT INTO " +
                               " Programacion.Bloqueos (bloq_idCadena,bloq_año,bloq_semana,bloq_captura,bloq_programacion,bloq_entrega," +
                               "bloq_contado,bloq_motivoid,bloq_fechamodificacion,bloq_usuariomodificaid,bloq_clienteid)" +
                               " SELECT idCadena,datepart(year,getdate()),case when year(getdate()) = 2021 then datepart(week,getdate())-1 else datepart(week,getdate()) end,Captura,Programacion,Entrega,Contado " +
                               " ,idtblMotivo ,getdate(),'" + idUsuario.ToString + "',clie_clienteid" +
                               " FROM  [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Bloqueo INNER JOIN Cliente.Cliente" +
                               " ON idCadena = clie_idsicy WHERE clie_activo = 1"
        End If

        operaciones.EjecutaSentencia(consulta)
    End Sub


    Public Sub importarBloqueo()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_ActualizarTablaClientesBloqueoSICY", listaParametros)
    End Sub

    Public Function consultaTablaBloqueo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" &
                " cl.clie_nombregenerico," &
                " bl.Motivo," &
                " bl.Estatus," &
                " bl.FCaptura," &
                " bl.Usuario" &
                " FROM Programacion.bloqueo bl" &
                " JOIN Cliente.Cliente cl	ON bl.IdCadena = cl.clie_idsicy ORDER BY cl.clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function fechaUltimaActualizacionTablaBloqueo() As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dato As String = ""
        cadena = "SELECT opci_fechamodificacion FROM Programacion.Opciones WHERE opci_opciID = 1022"
        Dim dt As New DataTable
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            dato = dt.Rows(0).Item(0).ToString
        End If
        Return dato
    End Function

    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@UsuarioId"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Programacion.SP_Bloqueos_Clientes_Filtros", listaParametros)

        Return dtResultadoConsulta

    End Function

End Class
