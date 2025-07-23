Public Class OpcionesSimlacionDA

    Public Function consultaClasificaciones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT clas_clasificacioclientenid, RTRIM(LTRIM(clas_nombre)) AS clas_nombre" & _
                 " FROM Cliente.Clasificaciones WHERE clas_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verClientesClasificacionRealYConfigurada(ByVal idSimulacion As Int32, ByVal clasificacion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "Select" & _
        " CAST(0 AS BIT) AS SEL," & _
        " cl.clie_clienteid," & _
        " cl.clie_idsicy," & _
        " cl.clie_nombregenerico," & _
        " cl.clie_clasificacionclienteid, cl.clie_ranking," & _
        " scr.sirc_Clasificacion, scr.sirc_Ranking" & _
        " FROM Cliente.Cliente cl" & _
        " LEFT JOIN Programacion.SimulacionClasificacionRanking scr" & _
        " ON cl.clie_idsicy = scr.sirc_cadenaId " & _
        " AND scr.sirc_simulacionMaestroId = " + idSimulacion.ToString & _
        " WHERE clie_activo = 1" & _
        " AND clie_statuscliente = 'C'" & _
        " AND sirc_Clasificacion <> '" + clasificacion + "'" & _
        " ORDER BY scr.sirc_Clasificacion, scr.sirc_Ranking, cl.clie_clasificacionclienteid, cl.clie_ranking"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaClientesConfigurados(ByVal idSimulacion As Int32, ByVal clasificacion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>                     
                    SELECT
                    scr.sirc_simRankingClasificacionId,
	                cl.clie_clienteid,
	                cl.clie_idsicy,
	                cl.clie_nombregenerico,
	                cl.clie_clasificacionclienteid, cl.clie_ranking,
	                scr.sirc_Clasificacion, scr.sirc_Ranking
                FROM Cliente.Cliente cl
                JOIN Programacion.SimulacionClasificacionRanking scr
	                ON cl.clie_idsicy = scr.sirc_cadenaId 
                WHERE clie_activo = 1
                AND clie_statuscliente = 'C'
                AND scr.sirc_simulacionMaestroId =  <%= idSimulacion.ToString %>
                AND scr.sirc_Clasificacion = '<%= clasificacion.ToString %>'
                ORDER BY scr.sirc_Clasificacion, scr.sirc_Ranking
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub cambiarConfiguracionClasRanking(ByVal idSimulacion As Int32, ByVal idCliente As Int32, ByVal idCadena As Int32,
                                            ByVal Clasificacion As String, ByVal Ranking As Int32,
                                            ByVal ClasificacionReal As String, ByVal RankingReal As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacion"
        parametro.Value = idSimulacion
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idCadena"
        parametro.Value = idCadena
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Ranking"
        parametro.Value = Ranking
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ClasificacionReal"
        parametro.Value = ClasificacionReal
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@RankingReal"
        parametro.Value = RankingReal
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_agregarClienteClasificacion", listaParametros)
    End Sub

    Public Function consultaClasificacionCliente(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT
	sirc_simRankingClasificacionId,	
	sirc_cadenaId,
	sirc_clienteId,
	cl.clie_nombregenerico,
	cl.clie_clasificacionclienteid,
	cl.clie_ranking,
	sirc_Clasificacion,
	sirc_Ranking	
FROM Programacion.SimulacionClasificacionRanking smc
JOIN Cliente.Cliente cl
	ON smc.sirc_clienteId = cl.clie_clienteid
WHERE smc.sirc_simulacionMaestroId = <%= idSimulacion.ToString %>
ORDER BY smc.sirc_Clasificacion, smc.sirc_Ranking, cl.clie_nombregenerico
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
