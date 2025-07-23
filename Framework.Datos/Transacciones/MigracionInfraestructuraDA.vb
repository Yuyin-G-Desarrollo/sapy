Imports System.Data.SqlClient
Public Class MigracionInfraestructuraDA
    Public Function obtenerAlerta(ByVal ordenPantalla As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ordenPantalla", ordenPantalla)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Work].[dbo].[SP_AlertasMigracionInfraestructura]", listaParametros)
    End Function

End Class
