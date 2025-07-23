Imports Persistencia
Imports System.Data.SqlClient

Public Class ConfiguracionAsistenciaDA

    Public Function listaConfiguracionAsistencia(ByVal naveID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.ConfiguracionAsistencia " &
                                "WHERE ConfiguracionAsistencia.confasis_naveid = " + naveID.ToString + " " &
                                "ORDER BY confasis_resultado"


        Return opereciones.EjecutaConsulta(consulta)

    End Function


    Public Function listaConfiguracionesUsuarioNave(ByVal IDUsuario As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Framework.Naves " &
                                "LEFT JOIN ControlAsistencia.ConfiguracionAsistencia AS ca ON ca.confasis_naveid = nave_naveid " &
                                "WHERE nave_naveid in " &
                                "(Select naus_naveid " &
                                "FROM Framework.NavesUsuario " &
                                "JOIN Framework.Naves ON nave_naveid=naus_naveid "

        If IDUsuario > 0 Then
            consulta += "WHERE naus_usuarioid = " + IDUsuario.ToString + ") AND nave_activo='True'"
        End If

        Return opereciones.EjecutaConsulta(consulta)

    End Function

    Public Sub guardarConfiguracionAsistencia(ByVal configuracionAsistencia As Entidades.ConfiguracionAsistencia)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@configuracionAsistenciaID AS INT,
        '@rango AS INT,
        '@porcentaje AS FLOAT,
        '@naveid AS INT,
        '@resultado AS INT,
        '@usuariocreo AS INT
        '@usuarioModifico AS INT

        Dim parametro As New SqlParameter
        parametro.ParameterName = "configuracionAsistenciaID"
        parametro.Value = configuracionAsistencia.PConfiguracionAsistenciaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rango"
        parametro.Value = configuracionAsistencia.PRango
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porcentaje"
        parametro.Value = configuracionAsistencia.PPorcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = configuracionAsistencia.PNaves.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "resultado"
        parametro.Value = configuracionAsistencia.PResultadoCheck
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_altas_configuracion_asistencia", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


End Class
