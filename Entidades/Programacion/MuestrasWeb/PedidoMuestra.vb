Public Class PedidoMuestra
    '  pedim_pedidoid               INT Not NULL,
    'pedim_clienteid              INT NULL,
    'pedim_colaboradorid_vendedor INT NULL,
    'pedim_fechacreacion          DATETIME CONSTRAINT DF_Pedidos_pedim_fechacreacion_2 Default (getdate()) Not NULL,
    'pedim_asuntomuestrasid       INT Not NULL,
    'pedim_temporadaid            INT Not NULL,
    'pedim_fechaentregacliente    DATETIME NULL,
    'pedim_estatusid              INT Not NULL,
    'pedim_usuariocreoid          INT Not NULL,

    Private _pedim_pedidoid As Int32
    Private _pedim_clienteid As Int32
    Private _pedim_colaboradorid_vendedor As Int32
    Private _pedim_fechacreacion As DateTime?
    Private _pedim_asuntomuestrasid As Int32
    Private _pedim_temporadaid As Int32
    Private _pedim_fechaentregacliente As DateTime?
    Private _pedim_estatusid As Int32
    Private _pedim_usuariocreoid As Int32
    Private _pedim_observaciones As String

    Public Property pedim_pedidoid As Integer
        Get
            Return _pedim_pedidoid
        End Get
        Set(value As Integer)
            _pedim_pedidoid = value
        End Set
    End Property

    Public Property pedim_clienteid As Integer
        Get
            Return _pedim_clienteid
        End Get
        Set(value As Integer)
            _pedim_clienteid = value
        End Set
    End Property

    Public Property pedim_colaboradorid_vendedor As Integer
        Get
            Return _pedim_colaboradorid_vendedor
        End Get
        Set(value As Integer)
            _pedim_colaboradorid_vendedor = value
        End Set
    End Property

    Public Property pedim_fechacreacion As Date?
        Get
            Return _pedim_fechacreacion
        End Get
        Set(value As Date?)
            _pedim_fechacreacion = value
        End Set
    End Property

    Public Property pedim_asuntomuestrasid As Integer
        Get
            Return _pedim_asuntomuestrasid
        End Get
        Set(value As Integer)
            _pedim_asuntomuestrasid = value
        End Set
    End Property

    Public Property pedim_temporadaid As Integer
        Get
            Return _pedim_temporadaid
        End Get
        Set(value As Integer)
            _pedim_temporadaid = value
        End Set
    End Property

    Public Property pedim_fechaentregacliente As Date?
        Get
            Return _pedim_fechaentregacliente
        End Get
        Set(value As Date?)
            _pedim_fechaentregacliente = value
        End Set
    End Property

    Public Property pedim_estatusid As Integer
        Get
            Return _pedim_estatusid
        End Get
        Set(value As Integer)
            _pedim_estatusid = value
        End Set
    End Property

    Public Property pedim_usuariocreoid As Integer
        Get
            Return _pedim_usuariocreoid
        End Get
        Set(value As Integer)
            _pedim_usuariocreoid = value
        End Set
    End Property

    Public Property pedim_observaciones As String
        Get
            Return _pedim_observaciones
        End Get
        Set(value As String)
            _pedim_observaciones = value
        End Set
    End Property


End Class
