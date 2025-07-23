Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoEmpaqueDA

    Public Function ListadoTipoEmpaque() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT tiem_tipoempaqueid, LTRIM(RTRIM(UPPER(tiem_nombre))) AS tiem_nombre FROM Ventas.TipoEmpaque WHERE tiem_activo = 1 ORDER BY tiem_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
