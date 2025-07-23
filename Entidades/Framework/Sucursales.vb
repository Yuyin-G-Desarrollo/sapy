Public Class Sucursales
	Private idsucursales As Int32
	Private numero As String
	Private nombre As String
	Private banco As Int32
	Private ciudad As Int32
	Private activo As Boolean

	Public Property Pidsucursales As Int32
		Get
			Return idsucursales
		End Get
		Set(value As Int32)
			idsucursales = value
		End Set
	End Property

	Public Property Pnumero As String
		Get
			Return numero
		End Get
		Set(value As String)
			numero = value
		End Set
	End Property

	Public Property Pnombre As String
		Get
			Return nombre

		End Get
		Set(value As String)
			nombre = value

		End Set
	End Property
	Public Property Pbanco As Int32
		Get
			Return banco

		End Get
		Set(value As Int32)
			banco = value
		End Set
	End Property
	Public Property Pciudad As Int32
		Get
			Return ciudad

		End Get
		Set(value As Int32)
			ciudad = value
		End Set
	End Property
	Public Property Pactivo As Boolean
		Get
			Return activo
		End Get
		Set(value As Boolean)
			activo = value
		End Set
	End Property

End Class
