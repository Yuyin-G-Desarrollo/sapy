Imports Persistencia
Imports System.Data.SqlClient

Public Class ProtectorFlejeDA

    Public Function ListadoProtectorFleje() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT prfl_protectorflejeid, LTRIM(RTRIM(UPPER(prfl_nombre))) AS prfl_nombre FROM Ventas.ProtectorFleje WHERE prfl_activo = 1 ORDER BY prfl_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
