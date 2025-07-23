Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoIvaDA

    Public Function ListaTipoIVA() As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT tiva_tipoivaid, LTRIM(RTRIM ( UPPER(tiva_nombre))) AS tiva_nombre FROM Cobranza.TipoIVA WHERE tiva_activo = 1 ORDER BY tiva_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

End Class
