Public Class Perfiles
	Private Perfilid As Int32
	Private Nombre As String
	Private Departamento As Int32
	Private Activo As Boolean
	Private NombreDepartamento As String

	Public Property Pperfilid As Int32
		Get
			Return Perfilid
		End Get
		Set(value As Int32)
			Perfilid = value
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

	Public Property PDepartamento As Int32
		Get
			Return Departamento
		End Get
		Set(value As Int32)
			Departamento = value
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

	Public Property PNombreDepartamento As String
		Get
			Return NombreDepartamento
		End Get
		Set(value As String)
			NombreDepartamento = value
		End Set
	End Property


End Class
