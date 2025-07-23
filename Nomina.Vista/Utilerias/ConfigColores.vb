Public Class ConfigColores
    Public Shared Sub cambiarConfiguracion(ByVal encabezado As String, ByVal fondo As String, ByVal etiquetas As String, ByVal grid As String, ByVal titulo As String)
        My.Settings.header = encabezado
        My.Settings.fondo = fondo
        My.Settings.grid = grid
        My.Settings.etiquetas = etiquetas
        My.Settings.titulo = titulo
        My.Settings.Save()
    End Sub

    Public Function getGridColor() As String

    End Function
End Class
