Public Class PedidoMuestraDetalle
    'pdetm_pedidoid             INT Not NULL,
    'pdetm_productoestiloid     INT Not NULL,
    'pdetm_unidadmedidaid       INT Not NULL,
    'pdetm_estatusid            INT Not NULL,
    'pdetm_talla                VARCHAR(4) Not NULL,
    'pdetm_cantidad             INT Not NULL,
    'pdetm_costo                FLOAT NULL,
    'pdetm_fechaentregacliente  DATE NULL,
    'pdetm_fechaentregareal     DATE NULL,
    'pdetm_anotacion            VARCHAR(30) NULL,
    'pdetm_fechacancelacion     DATETIME NULL,
    'pdetm_estatuscancelacionid INT NULL,
    'pdetm_motivocancelacion    VARCHAR(250) NULL,
    'pdetm_fechacreacion        DATETIME Not NULL,
    'pdetm_usuariocreoid        INT Not NULL,

    Private _pdetm_pedidoid As Int32
    Private _pdetm_productoestiloid As Int32
    Private _pdetm_unidadmedidaid As Int32
    Private _pdetm_estatusid As Int32
    Private _pdetm_talla As String
    Private _pdetm_cantidad As Int32
    Private _pdetm_costo As Double
    Private _pdetm_fechaentregacliente As DateTime?
    Private _pdetm_fechaentregareal As DateTime?
    Private _pdetm_anotacion As String
    Private _pdetm_fechacancelacion As DateTime?
    Private _pdetm_estatuscancelacionid As Int32
    Private _pdetm_motivocancelacion As String
    Private _pdetm_fechacreacion As DateTime?
    Private _pdetm_usuariocreoid As Int32


    Public Property pdetm_pedidoid As Integer
        Get
            Return _pdetm_pedidoid
        End Get
        Set(value As Integer)
            _pdetm_pedidoid = value
        End Set
    End Property

    Public Property pdetm_productoestiloid As Integer
        Get
            Return _pdetm_productoestiloid
        End Get
        Set(value As Integer)
            _pdetm_productoestiloid = value
        End Set
    End Property

    Public Property pdetm_unidadmedidaid As Integer
        Get
            Return _pdetm_unidadmedidaid
        End Get
        Set(value As Integer)
            _pdetm_unidadmedidaid = value
        End Set
    End Property

    Public Property pdetm_estatusid As Integer
        Get
            Return _pdetm_estatusid
        End Get
        Set(value As Integer)
            _pdetm_estatusid = value
        End Set
    End Property

    Public Property pdetm_talla As String
        Get
            Return _pdetm_talla
        End Get
        Set(value As String)
            _pdetm_talla = value
        End Set
    End Property

    Public Property pdetm_cantidad As Integer
        Get
            Return _pdetm_cantidad
        End Get
        Set(value As Integer)
            _pdetm_cantidad = value
        End Set
    End Property

    Public Property pdetm_costo As Double
        Get
            Return _pdetm_costo
        End Get
        Set(value As Double)
            _pdetm_costo = value
        End Set
    End Property

    Public Property pdetm_fechaentregacliente As Date?
        Get
            Return _pdetm_fechaentregacliente
        End Get
        Set(value As Date?)
            _pdetm_fechaentregacliente = value
        End Set
    End Property

    Public Property pdetm_fechaentregareal As Date?
        Get
            Return _pdetm_fechaentregareal
        End Get
        Set(value As Date?)
            _pdetm_fechaentregareal = value
        End Set
    End Property

    Public Property pdetm_anotacion As String
        Get
            Return _pdetm_anotacion
        End Get
        Set(value As String)
            _pdetm_anotacion = value
        End Set
    End Property

    Public Property pdetm_fechacancelacion As Date?
        Get
            Return _pdetm_fechacancelacion
        End Get
        Set(value As Date?)
            _pdetm_fechacancelacion = value
        End Set
    End Property

    Public Property pdetm_estatuscancelacionid As Integer
        Get
            Return _pdetm_estatuscancelacionid
        End Get
        Set(value As Integer)
            _pdetm_estatuscancelacionid = value
        End Set
    End Property

    Public Property pdetm_motivocancelacion As String
        Get
            Return _pdetm_motivocancelacion
        End Get
        Set(value As String)
            _pdetm_motivocancelacion = value
        End Set
    End Property

    Public Property pdetm_fechacreacion As Date?
        Get
            Return _pdetm_fechacreacion
        End Get
        Set(value As Date?)
            _pdetm_fechacreacion = value
        End Set
    End Property

    Public Property pdetm_usuariocreoid As Integer
        Get
            Return _pdetm_usuariocreoid
        End Get
        Set(value As Integer)
            _pdetm_usuariocreoid = value
        End Set
    End Property

End Class
