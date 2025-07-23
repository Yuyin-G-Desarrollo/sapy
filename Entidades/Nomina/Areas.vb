Public Class Areas
	Public Areaid As Int32
	Public Nombre As String
	Public Activo As Boolean
	Public Nave As Entidades.Naves
	Public Departamento As Entidades.Departamentos

	Public Property PAreaid As Int32
		Get
			Return Areaid

		End Get
		Set(value As Int32)
			Areaid = value

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

	Public Property PNave As Entidades.Naves
		Get
			Return Nave

		End Get
		Set(value As Entidades.Naves)
			Nave = value
		End Set
	End Property
	Public Property PDepartamento As Entidades.Departamentos
		Get
			Return Departamento

		End Get
		Set(value As Entidades.Departamentos)
			Departamento = value
		End Set
	End Property
End Class
