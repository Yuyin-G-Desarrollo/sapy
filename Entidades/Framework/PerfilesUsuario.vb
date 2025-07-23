Public Class PerfilesUsuario
	Public Departamento As Entidades.Departamentos
	Public perfil As Entidades.Perfiles
	Public Usuario As Entidades.Usuarios
	Public nave As Entidades.Naves
	Public Property PNave As Entidades.Naves
		Get
			Return nave
		End Get
		Set(value As Entidades.Naves)
			nave = value
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

	Public Property PPerfil As Entidades.Perfiles
		Get
			Return perfil

		End Get
		Set(value As Entidades.Perfiles)
			perfil = value
		End Set
	End Property
	Public Property PUsuario As Entidades.Usuarios
		Get
			Return Usuario
		End Get
		Set(value As Entidades.Usuarios)
			Usuario = value
		End Set
	End Property
End Class
