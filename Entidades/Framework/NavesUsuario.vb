Public Class NavesUsuario

	Public NavesID As Entidades.Naves
	Public UsuariosID As Entidades.Usuarios
	Public Property PNavesID As Entidades.Naves
		Get
			Return NavesID
		End Get
		Set(value As Entidades.Naves)
			NavesID = value
		End Set
    End Property

	Public Property PUsuariosID As Entidades.Usuarios
		Get
			Return UsuariosID
		End Get
		Set(value As Entidades.Usuarios)
			UsuariosID = value
		End Set
	End Property
End Class
