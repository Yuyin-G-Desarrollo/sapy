Public Class ConfiguracionGeneral

	Private confNotificaErrores As Boolean
	Private confNotificaErroresEmail As String

	Public Property PConfNotificaErrores As Boolean
		Get
			Return confNotificaErrores
		End Get
		Set(value As Boolean)
			confNotificaErrores = value
		End Set
	End Property

	Public Property PConfNotificaErroresEmail As String
		Get
			Return confNotificaErroresEmail
		End Get
		Set(value As String)
			confNotificaErroresEmail = value
		End Set
	End Property

End Class
