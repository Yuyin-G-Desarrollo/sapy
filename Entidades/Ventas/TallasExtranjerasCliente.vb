Public Class TallasExtranjerasCliente

    Private _TallaClienteID As Integer
    Public Property TallaClienteID() As Integer
        Get
            Return _TallaClienteID
        End Get
        Set(ByVal value As Integer)
            _TallaClienteID = value
        End Set
    End Property

    Private _Cliente As Integer
    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Integer)
            _Cliente = value
        End Set
    End Property


    Private _PaisID As Integer
    Public Property Pais() As Integer
        Get
            Return _PaisID
        End Get
        Set(ByVal value As Integer)
            _PaisID = value
        End Set
    End Property

    Private _Activo As Boolean
    Public Property Activo() As Boolean
        Get
            Return _Activo
        End Get
        Set(ByVal value As Boolean)
            _Activo = value
        End Set
    End Property

    Private _UsuarioCreo As Integer
    Public Property UsuarioCreo() As Integer
        Get
            Return _UsuarioCreo
        End Get
        Set(ByVal value As Integer)
            _UsuarioCreo = value
        End Set
    End Property

    Private _UsuarioModifico As Integer
    Public Property UsuarioModifico() As Integer
        Get
            Return _UsuarioModifico
        End Get
        Set(ByVal value As Integer)
            _UsuarioModifico = value
        End Set
    End Property

End Class
