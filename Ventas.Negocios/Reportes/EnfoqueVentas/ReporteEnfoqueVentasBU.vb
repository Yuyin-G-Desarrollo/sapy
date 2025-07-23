Imports Ventas.Datos


Public Class ReporteEnfoqueVentasBU


    Public Function MostrarModelosEnfoqueVentas() As DataTable
        Dim objDa As New ReporteEnfoqueVentasDA
        Dim DtResultado As New DataTable

        DtResultado = objDa.MostrarModelosEnfoqueVentas()

        Return DtResultado
    End Function

    Public Function GuardarInformacion(ByVal ProductoId As Integer, ByVal ColeccionId As Integer, ByVal Modelo As String, ByVal PielId As Integer, ByVal ColorId As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDa As New ReporteEnfoqueVentasDA
        Dim DtResultado As New DataTable

        DtResultado = objDa.GuardarInformacion(ProductoId, ColeccionId, Modelo, PielId, ColorId, UsuarioId)

        Return DtResultado

    End Function


    Public Sub BorrarInformacion()
        Dim objDa As New ReporteEnfoqueVentasDA
        Dim DtResultado As New DataTable

        objDa.BorrarInformacion()


    End Sub

End Class
