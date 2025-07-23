Public Class Historial
	Private HistHistorialId As Int32
	Private HistUsuarioId As Int32
	Private HistSentencia As String
	Private HistMensaje As String
	Private HistFecha As DateTime

	Public Property PHistHistorialId As Int32
		Get
			Return HistHistorialId
		End Get
		Set(value As Int32)
			HistHistorialId = value
		End Set
	End Property

	Public Property PHistUsuarioId As Int32
		Get
			Return HistUsuarioId
		End Get
		Set(value As Int32)
			HistUsuarioId = value
		End Set
	End Property

	Public Property PHistSentencia As String
		Get
			Return HistSentencia
		End Get
		Set(value As String)
			HistSentencia = value
		End Set
	End Property

	Public Property PHistMensaje As String
		Get
			Return HistMensaje
		End Get
		Set(value As String)
			HistMensaje = value
		End Set
	End Property

	Public Property PHistFecha As DateTime
		Get
			Return HistFecha
		End Get
		Set(value As DateTime)
			HistFecha = value
		End Set
	End Property
End Class
