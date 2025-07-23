Public Class PedidosMuestras

    Private _Sel As Boolean
    Public Property Sel() As Boolean
        Get
            Return _Sel
        End Get
        Set(ByVal value As Boolean)
            _Sel = value
        End Set
    End Property

    Private _Folio As Integer
    Public Property Folio As Integer
        Get
            Return _Folio
        End Get
        Set(ByVal value As Integer)
            _Folio = value
        End Set
    End Property

    Private _Temporada As String
    Public Property Temporada() As String
        Get
            Return _Temporada
        End Get
        Set(ByVal value As String)
            _Temporada = value
        End Set
    End Property

    Private _idCliente As Integer
    Public Property idCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property



    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property


    Private _idAgente As Integer
    Public Property idAgente() As Integer
        Get
            Return _idAgente
        End Get
        Set(ByVal value As Integer)
            _idAgente = value
        End Set
    End Property



    Private _Agente As String
    Public Property Agente() As String
        Get
            Return _Agente
        End Get
        Set(ByVal value As String)
            _Agente = value
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

    Private _NombreUsuarioCreo As String
    Public Property NombreUsuarioCreo() As String
        Get
            Return _NombreUsuarioCreo
        End Get
        Set(ByVal value As String)
            _NombreUsuarioCreo = value
        End Set
    End Property

    Private _FechaCreacion As Date
    Public Property FechaCreacion() As Date
        Get
            Return _FechaCreacion
        End Get
        Set(ByVal value As Date)
            _FechaCreacion = value
        End Set
    End Property


    Private _FechaEntrega As String
    Public Property fechaEntrega As String
        Get
            Return _FechaEntrega
        End Get
        Set(ByVal value As String)
            _FechaEntrega = value
        End Set
    End Property

    Private _FechaEntregaReal As String
    Public Property FechaEntregaReal() As String
        Get
            Return _FechaEntregaReal
        End Get
        Set(ByVal value As String)
            _FechaEntregaReal = value
        End Set
    End Property


    Private _EstatusId As Integer
    Public Property EstatusId() As Integer
        Get
            Return _EstatusId
        End Get
        Set(ByVal value As Integer)
            _EstatusId = value
        End Set
    End Property

    Private _Estatus As String
    Public Property Estatus() As String
        Get
            Return _Estatus
        End Get
        Set(ByVal value As String)
            _Estatus = value
        End Set
    End Property

    Private _Observaciones As String
    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property



    Private _Capturados As Integer
    Public Property Capturados() As Integer
        Get
            Return _Capturados
        End Get
        Set(ByVal value As Integer)
            _Capturados = value
        End Set
    End Property

    Private _Autorizados As Integer
    Public Property Autorizados() As Integer
        Get
            Return _Autorizados
        End Get
        Set(ByVal value As Integer)
            _Autorizados = value
        End Set
    End Property

    Private _Apartados As Integer
    Public Property Apartados() As Integer
        Get
            Return _Apartados
        End Get
        Set(ByVal value As Integer)
            _Apartados = value
        End Set
    End Property

    Private _EnProduccion As Integer
    Public Property EnProduccion() As Integer
        Get
            Return _EnProduccion
        End Get
        Set(ByVal value As Integer)
            _EnProduccion = value
        End Set
    End Property




    Private _Recibidos As Integer
    Public Property Recibidos() As Integer
        Get
            Return _Recibidos
        End Get
        Set(ByVal value As Integer)
            _Recibidos = value
        End Set
    End Property
    Private _Confimardos As Integer
    Public Property Confirmados() As Integer
        Get
            Return _Confimardos
        End Get
        Set(ByVal value As Integer)
            _Confimardos = value
        End Set
    End Property

    Private _Enviados As Integer
    Public Property Enviados() As Integer
        Get
            Return _Enviados
        End Get
        Set(ByVal value As Integer)
            _Enviados = value
        End Set
    End Property


    Private _Cancelados As Integer
    Public Property Cancelados() As Integer
        Get
            Return _Cancelados
        End Get
        Set(ByVal value As Integer)
            _Cancelados = value
        End Set
    End Property





    Private _Asunto As String
    Public Property Asunto() As String
        Get
            Return _Asunto
        End Get
        Set(ByVal value As String)
            _Asunto = value
        End Set
    End Property

    Private _idAsunto As Integer
    Public Property idAsunto() As Integer
        Get
            Return _idAsunto
        End Get
        Set(ByVal value As Integer)
            _idAsunto = value
        End Set
    End Property



    Private _idTemporada As Integer
    Public Property idTemporada() As Integer
        Get
            Return _idTemporada
        End Get
        Set(ByVal value As Integer)
            _idTemporada = value
        End Set
    End Property

    Private _Disponible As Integer
    Public Property Disponible() As Integer
        Get
            Return _Disponible
        End Get
        Set(ByVal value As Integer)
            _Disponible = value
        End Set
    End Property



    Private _DisponibleTotal As Integer
    Public Property DisponibleTotal() As Integer
        Get
            Return _DisponibleTotal
        End Get
        Set(ByVal value As Integer)
            _DisponibleTotal = value
        End Set
    End Property

    Private _DisponiblePedido As Integer
    Public Property DisponiblePedido() As Integer
        Get
            Return _DisponiblePedido
        End Get
        Set(ByVal value As Integer)
            _DisponiblePedido = value
        End Set
    End Property

    Private _OrdenProduccion As Integer
    Public Property OrdenProduccion() As Integer
        Get
            Return _OrdenProduccion
        End Get
        Set(ByVal value As Integer)
            _OrdenProduccion = value
        End Set
    End Property

    Private _FechaOrden As String
    Public Property FechaOrden() As String
        Get
            Return _FechaOrden
        End Get
        Set(ByVal value As String)
            _FechaOrden = value
        End Set
    End Property

End Class
