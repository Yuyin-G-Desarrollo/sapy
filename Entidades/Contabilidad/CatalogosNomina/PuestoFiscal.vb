Public Class PuestoFiscal
    Private _ID_Patron As Integer
    Private _NombrePatron As String
    Private _UsuarioCreo As Integer
    Private _FechaCreo As DateTime
    Private _resp As Integer
    Private _mensaje As String

    Public Property ID_Patron As Integer
        Get
            Return _ID_Patron
        End Get
        Set(value As Integer)
            _ID_Patron = value
        End Set
    End Property

    Public Property NombrePatron As String
        Get
            Return _NombrePatron
        End Get
        Set(value As String)
            _NombrePatron = value
        End Set
    End Property

    Public Property UsuarioCreo As Integer
        Get
            Return _UsuarioCreo
        End Get
        Set(value As Integer)
            _UsuarioCreo = value
        End Set
    End Property

    Public Property FechaCreo As DateTime
        Get
            Return _FechaCreo
        End Get
        Set(value As DateTime)
            _FechaCreo = value
        End Set
    End Property

    Public Property Resp As Integer
        Get
            Return _resp
        End Get
        Set(value As Integer)
            _resp = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property
End Class
