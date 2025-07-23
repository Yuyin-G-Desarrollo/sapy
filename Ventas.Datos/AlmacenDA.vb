Imports Persistencia
Imports System.Data.SqlClient

Public Class AlmacenDA

    Public Function ListadoAlmacen() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  SELECT alma_almacenid, LTRIM(RTRIM(UPPER(alma_nombre))) AS alma_nombre FROM Ventas.Almacen WHERE alma_activo = 1 ORDER BY alma_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
