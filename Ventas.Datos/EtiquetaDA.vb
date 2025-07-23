Imports Persistencia
Imports System.Data.SqlClient

Public Class EtiquetaDA

    Public Function ListadoTipoEtiqueta() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT tiet_tipoetiquetaespecialid, LTRIM(RTRIM(UPPER(tiet_nombre))) AS tiet_nombre FROM Ventas.TipoEtiqueta WHERE tiet_activo = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
