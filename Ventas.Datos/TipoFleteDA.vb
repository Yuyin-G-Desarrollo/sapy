Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoFleteDA

    Public Function ListadoTipoFlete() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT  tifl_tipofleteid, LTRIM(RTRIM(UPPER(tifl_nombre))) AS tifl_nombre FROM Ventas.TipoFlete WHERE tifl_activo = 1 ORDER BY tifl_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function




End Class
