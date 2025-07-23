Imports Persistencia
Imports System.Data.SqlClient

Public Class UnidadVentaDA

    Public Function ListadoUnidadVenta() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT unve_unidadventaid, LTRIM(RTRIM(UPPER(unve_nombre))) AS unve_nombre FROM Ventas.UnidadVenta WHERE unve_activo = 1 ORDER BY unve_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
