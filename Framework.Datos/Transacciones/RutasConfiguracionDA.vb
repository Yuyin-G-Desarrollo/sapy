Imports System.Data.SqlClient
Imports Persistencia

Public Class RutasConfiguracionDA
    Public Function RutasConfiguracion() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim dtResultado As New DataTable

        Return operaciones.EjecutaConsulta("[Framework].[SP_obtenerRutasGenerales]")
    End Function

End Class
