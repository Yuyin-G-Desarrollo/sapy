Imports Persistencia
Imports System.Data.SqlClient

Public Class NivelSocioEconomicoDA


    Public Function ListadoNivelSocioEconomico() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT niso_nivelsocioeconomicoid, LTRIM(RTRIM(UPPER(niso_nombre))) AS niso_nombre FROM Ventas.NivelSocioeconomico WHERE niso_activo = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


End Class
