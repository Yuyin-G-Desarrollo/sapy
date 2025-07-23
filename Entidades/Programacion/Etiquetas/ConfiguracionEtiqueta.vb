Public Class ConfiguracionEtiqueta
    Private _EtiquetaId As Integer
    Public Property EtiquetaId() As Integer
        Get
            Return _EtiquetaId
        End Get
        Set(ByVal value As Integer)
            _EtiquetaId = value
        End Set
    End Property

    Private _EtiquetaClave As String
    Public Property EtiquetaClave() As String
        Get
            Return _EtiquetaClave
        End Get
        Set(ByVal value As String)
            _EtiquetaClave = value
        End Set
    End Property

    Private _TipoEtiquetaId As Integer
    Public Property TipoEtiquetaId() As Integer
        Get
            Return _TipoEtiquetaId
        End Get
        Set(ByVal value As Integer)
            _TipoEtiquetaId = value
        End Set
    End Property

    Private _TipoEtiqueta As String
    Public Property TipoEtiqueta() As String
        Get
            Return _TipoEtiqueta
        End Get
        Set(ByVal value As String)
            _TipoEtiqueta = value
        End Set
    End Property

    Private _EtiquetaNombre As String
    Public Property EtiquetaNombre() As String
        Get
            Return _EtiquetaNombre
        End Get
        Set(ByVal value As String)
            _EtiquetaNombre = value
        End Set
    End Property

    Private _EtiquetaDescripcion As String
    Public Property EtiquetaDescripcion() As String
        Get
            Return _EtiquetaDescripcion
        End Get
        Set(ByVal value As String)
            _EtiquetaDescripcion = value
        End Set
    End Property

    Private _CodigoZPL As String
    Public Property CodigoZPL() As String
        Get
            Return _CodigoZPL
        End Get
        Set(ByVal value As String)
            _CodigoZPL = value
        End Set
    End Property

    Private _EtiquetaAncho As String
    Public Property EtiquetaAncho() As String
        Get
            Return _EtiquetaAncho
        End Get
        Set(ByVal value As String)
            _EtiquetaAncho = value
        End Set
    End Property

    Private _EtiquetaAlto As String
    Public Property EtiquetaAlto() As String
        Get
            Return _EtiquetaAlto
        End Get
        Set(ByVal value As String)
            _EtiquetaAlto = value
        End Set
    End Property

    Private _EtiquetaOrientacion As String
    Public Property EtiquetaOrientacion() As String
        Get
            Return _EtiquetaOrientacion
        End Get
        Set(ByVal value As String)
            _EtiquetaOrientacion = value
        End Set
    End Property

    Private _EtiquetaUsuarioCreoId As Integer
    Public Property EtiquetaUsuarioCreoId() As Integer
        Get
            Return _EtiquetaUsuarioCreoId
        End Get
        Set(ByVal value As Integer)
            _EtiquetaUsuarioCreoId = value
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

    Private _ClienteId As Integer
    Public Property ClienteId() As Integer
        Get
            Return _ClienteId
        End Get
        Set(ByVal value As Integer)
            _ClienteId = value
        End Set
    End Property

    Private _EtiquetaYuyin As Boolean
    Public Property EtiquetaYuyin() As Boolean
        Get
            Return _EtiquetaYuyin
        End Get
        Set(ByVal value As Boolean)
            _EtiquetaYuyin = value
        End Set
    End Property

    Private _EtiquetaCodigoZPL300 As String
    Public Property EtiquetaCodigoZPL300() As String
        Get
            Return _EtiquetaCodigoZPL300
        End Get
        Set(ByVal value As String)
            _EtiquetaCodigoZPL300 = value
        End Set
    End Property

    Private _EtiquetaActiva As Boolean
    Public Property EtiquetaActiva() As Boolean
        Get
            Return _EtiquetaActiva
        End Get
        Set(ByVal value As Boolean)
            _EtiquetaActiva = value
        End Set
    End Property

    Private _EtiquetaVistaPrevia As String
    Public Property EtiquetaVistaPrevia() As String
        Get
            Return _EtiquetaVistaPrevia
        End Get
        Set(ByVal value As String)
            _EtiquetaVistaPrevia = value
        End Set
    End Property

    Private _EtiquetaImpresionesAlPaso As Integer
    Public Property EtiquetaImpresionesAlPaso As Integer
        Get
            Return _EtiquetaImpresionesAlPaso
        End Get
        Set(ByVal value As Integer)
            _EtiquetaImpresionesAlPaso = value
        End Set
    End Property

    Private _NombreCliente As String
    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Private _StatusEtiquetaID As Integer
    Public Property StatusEtiquetaID() As Integer
        Get
            Return _StatusEtiquetaID
        End Get
        Set(ByVal value As Integer)
            _StatusEtiquetaID = value
        End Set
    End Property

    Private _RutaLBL As String
    Public Property RutaLBL() As String
        Get
            Return _RutaLBL
        End Get
        Set(ByVal value As String)
            _RutaLBL = value
        End Set
    End Property

    Private _UsuarioModifico As String
    Public Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
        Set(ByVal value As String)
            _UsuarioModifico = value
        End Set
    End Property

    Private _UsuarioCreo As String
    Public Property UsuarioCreo() As String
        Get
            Return _UsuarioCreo
        End Get
        Set(ByVal value As String)
            _UsuarioCreo = value
        End Set
    End Property

    Private _Coleccion As String
    Public Property Coleccion() As String
        Get
            Return _Coleccion
        End Get
        Set(ByVal value As String)
            _Coleccion = value
        End Set
    End Property

    Private _ColeccionID As Integer = 0
    Public Property ColeccionID() As Integer
        Get
            Return _ColeccionID
        End Get
        Set(ByVal value As Integer)
            _ColeccionID = value
        End Set
    End Property

    
End Class
