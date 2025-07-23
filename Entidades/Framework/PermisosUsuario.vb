
Public Class PermisosUsuario
    Private Usuarioid As Usuarios
    Private Accionid As Acciones
	Private Tipopermiso As Int32
    Private user As PermisosUsuario
    Public Property Puser As PermisosUsuario
        Get
            Return user
        End Get
        Set(ByVal value As PermisosUsuario)
            user = value
        End Set
    End Property


    Public Property PUsuarioid As Usuarios
        Get
            Return Usuarioid
        End Get
        Set(ByVal value As Usuarios)
            Usuarioid = value
        End Set
    End Property

    Public Property PAccionid As Acciones
        Get
            Return Accionid
        End Get
        Set(ByVal value As Acciones)
            Accionid = value
        End Set
    End Property

	Public Property pTipoPermiso As Int32
		Get
			Return Tipopermiso
		End Get
		Set(value As Int32)
			Tipopermiso = value
		End Set
	End Property
End Class
