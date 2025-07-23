Public Class ReportesSuelaBU
    Public Function ObtieneConcentradoSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objDa As New Produccion.Datos.ReportesSuelaDA
        Return objDa.ObtenerConcentradoSuela(FechaPrograma, IdNaves, IdUsuario)
    End Function

    Public Function ObtieneDesglosadoSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objDa As New Produccion.Datos.ReportesSuelaDA
        Return objDa.ObtenerDesglosadoSuela(FechaPrograma, IdNaves, IdUsuario)
    End Function

    Public Function ObtieneProduccionSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objDa As New Produccion.Datos.ReportesSuelaDA
        Return objDa.ObtenerProduccionSuela(FechaPrograma, IdNaves, IdUsuario)
    End Function
End Class
