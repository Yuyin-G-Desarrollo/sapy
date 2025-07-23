Public Class PedidoMuestraDetalleEstatus
    '   pdetsm_pedidoid         INT Not NULL,
    'pdetsm_productoestiloid INT Not NULL,
    'pdetsm_unidadmedidaid   INT Not NULL,
    'pdetsm_abiertos         INT Not NULL,
    'pdetsm_capturados       INT NULL,
    'pdetsm_autorizados      INT NULL,
    'pdetsm_apartados        INT NULL,
    'pdetsm_recibidos        INT NULL,
    'pdetsm_enviados         INT NULL,
    'pdetsm_enproducion      INT NULL,
    'pdetsm_cancelados       INT NULL,

    Private _pdetsm_pedidoid As Int32?
    Private _pdetsm_productoestiloid As Int32?
    Private _pdetsm_unidadmedidaid As Int32?
    Private _pdetsm_abiertos As Int32?
    Private _pdetsm_capturados As Int32?
    Private _pdetsm_autorizados As Int32?
    Private _pdetsm_apartados As Int32?
    Private _pdetsm_recibidos As Int32?
    Private _pdetsm_enviados As Int32?
    Private _pdetsm_enproducion As Int32?
    Private _pdetsm_cancelados As Int32?

    Public Property pdetsm_pedidoid As Integer?
        Get
            Return _pdetsm_pedidoid
        End Get
        Set(value As Integer?)
            _pdetsm_pedidoid = value
        End Set
    End Property

    Public Property pdetsm_productoestiloid As Integer?
        Get
            Return _pdetsm_productoestiloid
        End Get
        Set(value As Integer?)
            _pdetsm_productoestiloid = value
        End Set
    End Property

    Public Property pdetsm_unidadmedidaid As Integer?
        Get
            Return _pdetsm_unidadmedidaid
        End Get
        Set(value As Integer?)
            _pdetsm_unidadmedidaid = value
        End Set
    End Property

    Public Property pdetsm_capturados As Integer?
        Get
            Return _pdetsm_capturados
        End Get
        Set(value As Integer?)
            _pdetsm_capturados = value
        End Set
    End Property

    Public Property pdetsm_autorizados As Integer?
        Get
            Return _pdetsm_autorizados
        End Get
        Set(value As Integer?)
            _pdetsm_autorizados = value
        End Set
    End Property

    Public Property pdetsm_apartados As Integer?
        Get
            Return _pdetsm_apartados
        End Get
        Set(value As Integer?)
            _pdetsm_apartados = value
        End Set
    End Property

    Public Property pdetsm_recibidos As Integer?
        Get
            Return _pdetsm_recibidos
        End Get
        Set(value As Integer?)
            _pdetsm_recibidos = value
        End Set
    End Property

    Public Property pdetsm_enviados As Integer?
        Get
            Return _pdetsm_enviados
        End Get
        Set(value As Integer?)
            _pdetsm_enviados = value
        End Set
    End Property

    Public Property pdetsm_enproducion As Integer?
        Get
            Return _pdetsm_enproducion
        End Get
        Set(value As Integer?)
            _pdetsm_enproducion = value
        End Set
    End Property

    Public Property pdetsm_cancelados As Integer?
        Get
            Return _pdetsm_cancelados
        End Get
        Set(value As Integer?)
            _pdetsm_cancelados = value
        End Set
    End Property
End Class
