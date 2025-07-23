Public Class PermisosPerfil
    Private Perfilid As Perfiles
    Private Accionid As Acciones
	Private Usuariocreoid As Int32
	Private usuarios As Usuarios
	Private Fechacreacion As DateTime
	Public Property Pusuarios As Usuarios
		Get
			Return usuarios

		End Get
		Set(value As Usuarios)
			usuarios = value

		End Set
	End Property
    Public Property Pperfilid As Perfiles
        Get
            Return Perfilid
        End Get
        Set(ByVal value As Perfiles)
            Perfilid = value
        End Set
    End Property

    Public Property Paccionid As Acciones
        Get
            Return Accionid
        End Get
        Set(ByVal value As Acciones)
            Accionid = value
        End Set
    End Property

	Public Property Pusuariocreoid As Int32
		Get
			Return Usuariocreoid
		End Get
		Set(value As Int32)
			Usuariocreoid = value
		End Set
	End Property

	Public Property Pfechacreacion As DateTime
		Get
			Return Fechacreacion
		End Get
		Set(value As DateTime)
			Fechacreacion = value
		End Set
	End Property

End Class
