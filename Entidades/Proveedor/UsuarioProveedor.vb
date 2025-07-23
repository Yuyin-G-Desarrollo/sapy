Public Class UsuarioProveedor

    Private usuario As String
    Public Property upro_usuario() As String
        Get
            Return usuario
        End Get
        Set(ByVal value As String)
            usuario = value
        End Set
    End Property

    Private id As Integer
    Public Property upro_id() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property

    Private activo As String
    Public Property upro_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property


    Private usuarioproveedorid As Integer
    Public Property upro_usuarioproveedorid() As Integer
        Get
            Return usuarioproveedorid
        End Get
        Set(ByVal value As Integer)
            usuarioproveedorid = value
        End Set
    End Property


    Private nombreUsuario As String
    Public Property dage_nombreUsuario() As String
        Get
            Return nombreUsuario
        End Get
        Set(ByVal value As String)
            nombreUsuario = value
        End Set
    End Property


Private password As String
    Public Property upro_password() As String
        Get
            Return password
        End Get
        Set(ByVal value As String)
            password = value
        End Set
    End Property

Private proveedorid As integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

Private usuariocreoid As integer
    Public Property upro_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodificoid As integer
    Public Property upro_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property upro_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property upro_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

End Class

Namespace Produccion.Entidades
    Public Class SesionUsuario

    End Class
End Namespace
