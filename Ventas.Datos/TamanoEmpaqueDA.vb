Imports Persistencia
Imports System.Data.SqlClient

Public Class TamanoEmpaqueDA

    Public Function ListadoTamanoEmpaque() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT taem_tamanoempaqueid, LTRIM(RTRIM(UPPER(taem_nombre))) AS taem_nombre FROM Ventas.TamanoEmpaque WHERE taem_activo = 1 ORDER BY taem_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
