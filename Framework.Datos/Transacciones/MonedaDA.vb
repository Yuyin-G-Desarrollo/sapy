Imports Persistencia
Imports System.Data.SqlClient

Public Class MonedaDA

    Public Function ListaMoneda() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT mone_monedaid, LTRIM(RTRIM ( UPPER(mone_nombre))) AS mone_nombre FROM Framework.Moneda WHERE mone_activo = 1 ORDER BY mone_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
