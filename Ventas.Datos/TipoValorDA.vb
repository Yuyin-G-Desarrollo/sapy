Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoValorDA

    Public Function ListadoTipoValor() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT tiva_tipovalorid, LTRIM(RTRIM(UPPER(tiva_nombre))) AS tiva_nombre FROM Ventas.TipoValor WHERE tiva_activo = 1 ORDER BY tiva_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
