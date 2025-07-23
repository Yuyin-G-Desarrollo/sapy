Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoFlejeDA

    Public Function ListadoTipoFleje() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT tifl_tipoflejeid, LTRIM(RTRIM(UPPER(tifl_nombre))) AS tifl_nombre FROM Ventas.TipoFleje WHERE tifl_activo = 1 ORDER BY tifl_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
