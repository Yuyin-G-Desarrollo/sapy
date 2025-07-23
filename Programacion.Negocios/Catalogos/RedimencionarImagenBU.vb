Imports Programacion.Datos
Public Class RedimencionarImagenBU

    Public Function ConsultarModelosRedimensionar(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New RedimencionarImagenDA
        Dim dt As New DataTable
        dt = obj.ConsultarModelosRedimensionar(productoEstiloId)
        Return dt
    End Function

    Public Function ActualizarModelos(ByVal productoEstiloId As Integer, ByVal nombreArchivo As String)
        Dim obj As New RedimencionarImagenDA
        Return obj.ActualizarModelos(productoEstiloId, nombreArchivo)
    End Function

End Class
