Imports Ventas.Datos
Public Class ConsultaParesFacturados_BU
    Public Function ObtenerParesFacturados(fechaInicio As String, fechaFin As String)
        Dim obj As New ConsultaParesFacturados_DA
        Return obj.obtenerParesApartadosFacturados(fechaInicio, fechaFin)
    End Function
End Class
