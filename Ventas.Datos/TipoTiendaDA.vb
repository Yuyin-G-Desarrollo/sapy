Imports Persistencia
Imports System.Data.SqlClient

Public Class TipoTiendaDA


    Public Function ListadoTipoTienda() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT titi_tipotiendaid, LTRIM(RTRIM ( UPPER(titi_nombre))) AS titi_nombre FROM Cliente.TipoTienda WHERE titi_activo = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function
End Class
