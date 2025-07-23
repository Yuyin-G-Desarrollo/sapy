Public Class ConfigColores

	Public Shared Sub cambiarConfiguracion(ByVal encabezado As String, fondo As String, etiquetas As String, grid As String, titulo As String)
		My.Settings.header = encabezado
		My.Settings.fondo = fondo
		My.Settings.grid = grid
		My.Settings.etiquetas = etiquetas
		My.Settings.titulo = titulo
		My.Settings.Save()
	End Sub

End Class
