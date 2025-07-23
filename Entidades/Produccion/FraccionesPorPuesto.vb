Public Class FraccionesPorPuesto
    Private _fraccionid As Integer
    Private _naveidsay As Integer
    Private _naveidsicy As Integer
    Private _areaid As Integer
    Private _departamentoid As Integer
    Private _puestoid As Integer
    Private _activo As Boolean
    'Private _fechaCreacion As DateTime
    Private _colaboradorCreoid As Integer
    Private _usuariCreoid As Integer
    'Private _fechaModificacion As DateTime
    Private _colaboradorModifico As Integer
    Private _usuarioModifico As Integer
    Private _departamento As String
    Private _idTabla As Integer

    Public Property FraccionId As Integer
        Get
            Return _fraccionid
        End Get
        Set(value As Integer)
            _fraccionid = value
        End Set
    End Property

    Public Property NaveSayid As Integer
        Get
            Return _naveidsay
        End Get
        Set(value As Integer)
            _naveidsay = value
        End Set
    End Property
    Public Property NaveSICYid As Integer
        Get
            Return _naveidsicy
        End Get
        Set(value As Integer)
            _naveidsicy = value
        End Set
    End Property

    Public Property AreaId As Integer
        Get
            Return _areaid
        End Get
        Set(value As Integer)
            _areaid = value
        End Set
    End Property

    Public Property DepartamentoId As Integer
        Get
            Return _departamentoid
        End Get
        Set(value As Integer)
            _departamentoid = value
        End Set
    End Property

    Public Property PuestoId As Integer
        Get
            Return _puestoid
        End Get
        Set(value As Integer)
            _puestoid = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return _activo
        End Get
        Set(value As Boolean)
            _activo = value
        End Set
    End Property

    'Public Property FechaCreacion As DateTime
    '    Get
    '        Return _fechaCreacion
    '    End Get
    '    Set(value As DateTime)
    '        _fechaCreacion = value
    '    End Set
    'End Property

    Public Property ColaboradorCreoId As Integer
        Get
            Return _colaboradorCreoid
        End Get
        Set(value As Integer)
            _colaboradorCreoid = value
        End Set
    End Property

    Public Property UsuarioCreoId As Integer
        Get
            Return _usuariCreoid
        End Get
        Set(value As Integer)
            _usuariCreoid = value
        End Set
    End Property

    'Public Property FechaModificacion As DateTime
    '    Get
    '        Return _fechaModificacion
    '    End Get
    '    Set(value As DateTime)
    '        _fechaModificacion = value
    '    End Set
    'End Property

    Public Property ColaboradorModificoId As Integer
        Get
            Return _colaboradorModifico
        End Get
        Set(value As Integer)
            _colaboradorModifico = value
        End Set
    End Property

    Public Property UsuarioModificoId As Integer
        Get
            Return _usuarioModifico
        End Get
        Set(value As Integer)
            _usuarioModifico = value
        End Set
    End Property

    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = value
        End Set
    End Property


    Public Property idTabla As Integer
        Get
            Return _idTabla
        End Get
        Set(value As Integer)
            _idTabla = value
        End Set
    End Property

End Class
