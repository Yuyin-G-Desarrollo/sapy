Public Class ImpresorasZebra


    Private _idImpresora As Integer
    Public Property idImpresora() As Integer
        Get
            Return _idImpresora
        End Get
        Set(ByVal value As Integer)
            _idImpresora = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _Comando As String
    Public Property Comando() As String
        Get
            Return _Comando
        End Get
        Set(ByVal value As String)
            _Comando = value
        End Set
    End Property

    Private _StImpresion As String
    Public Property StImpresion() As String
        Get
            Return _StImpresion
        End Get
        Set(ByVal value As String)
            _StImpresion = value
        End Set
    End Property

    Private _Resolucion As String
    Public Property Resolucion() As String
        Get
            Return _Resolucion
        End Get
        Set(ByVal value As String)
            _Resolucion = value
        End Set
    End Property

    Private _Abreviatura As String
    Public Property Abreviatura() As String
        Get
            Return _Abreviatura
        End Get
        Set(ByVal value As String)
            _Abreviatura = value
        End Set
    End Property

    Private _UsuarioCreoId As Integer
    Public Property UsuarioCreoId() As Integer
        Get
            Return _UsuarioCreoId
        End Get
        Set(ByVal value As Integer)
            _UsuarioCreoId = value
        End Set
    End Property

    Private _FechaCreacion As DateTime
    Public Property FechaCreacion() As DateTime
        Get
            Return _FechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _FechaCreacion = value
        End Set
    End Property

    Private _UsuarioModificoId As Integer
    Public Property UsuarioModificoId() As Integer
        Get
            Return _UsuarioModificoId
        End Get
        Set(ByVal value As Integer)
            _UsuarioModificoId = value
        End Set
    End Property

    Private _FechaModificacion As DateTime
    Public Property FechaModificacion() As DateTime
        Get
            Return _FechaModificacion
        End Get
        Set(ByVal value As DateTime)
            _FechaModificacion = value
        End Set
    End Property
End Class
