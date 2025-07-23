Public Class Bancos

	Private BancosId As Int32
	Private Nombre As String
	Private Activo As Boolean

	Public Property PBancosId As Int32
		Get
			Return BancosId
		End Get
		Set(value As Int32)
			BancosId = value
		End Set
	End Property

	Public Property PNombre As String
		Get
			Return Nombre
		End Get
		Set(value As String)
			Nombre = value
		End Set
	End Property

	Public Property PActivo As Boolean
		Get
			Return Activo
		End Get
		Set(value As Boolean)
			Activo = value
		End Set
	End Property

End Class
