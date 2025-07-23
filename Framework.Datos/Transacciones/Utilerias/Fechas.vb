Public Class Fechas

	Public Shared Function now() As DateTime
		Dim dt As New DateTime
		dt = DateTime.Now
		Return dt
	End Function

	Public Shared Function formatearFecha(ByVal dt As DateTime, ByVal formato As String) As String
		If formato.Length <= 0 Then
			formato = "yyyy-MM-dd HH:mm"
		End If
		Return dt.ToString(formato)
	End Function
End Class
