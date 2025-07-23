Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoClienteDA

    Public Function ListaTiposCliente() As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT ticl_tipoclienteid, LTRIM(RTRIM ( UPPER(ticl_nombre))) AS ticl_nombre FROM Ventas.TipoCliente WHERE ticl_activo = 1 ORDER BY ticl_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


End Class
