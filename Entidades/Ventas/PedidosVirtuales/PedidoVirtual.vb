Public Class PedidoVirtual

    Private Pid As Integer
    Private Ptipoid As Integer
    Private Ptipo As String
    Private Pestatus As String
    Private Pestatusid As Integer
    Private Porden As String
    Private Pcliente As Cliente
    Private Pcantidadpares As Integer
    Private PfechaCreacion As DateTime
    Private PfechaEntregaCliente As DateTime
    Private PfechaEntregaProg As DateTime
    Private PlistaVentas As ListaBase
    Private Pobservaciones As String

    Public Property id() As Integer
        Get
            Return Pid
        End Get
        Set(ByVal value As Integer)
            Pid = value
        End Set
    End Property

    Public Property tipoid() As Int32
        Get
            Return Ptipoid
        End Get
        Set(ByVal value As Int32)
            Ptipoid = value
        End Set
    End Property

    Public Property tipo() As String
        Get
            Return Ptipo
        End Get
        Set(ByVal value As String)
            Ptipo = value
        End Set
    End Property

    Public Property estatusid() As Int32
        Get
            Return Pestatusid
        End Get
        Set(ByVal value As Int32)
            Pestatusid = value
        End Set
    End Property

    Public Property estatus() As String
        Get
            Return Pestatus
        End Get
        Set(ByVal value As String)
            Pestatus = value
        End Set
    End Property

    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Public Property orden() As String
        Get
            Return Porden
        End Get
        Set(ByVal value As String)
            Porden = value
        End Set
    End Property

    Public Property cantidadpares() As Int32
        Get
            Return Pcantidadpares
        End Get
        Set(ByVal value As Int32)
            Pcantidadpares = value
        End Set
    End Property

    Public Property fechaCreacion() As Date
        Get
            Return PfechaCreacion
        End Get
        Set(ByVal value As Date)
            PfechaCreacion = value
        End Set
    End Property

    Public Property FechasolicitadaCliente() As Date
        Get
            Return PfechaEntregaCliente
        End Get
        Set(ByVal value As Date)
            PfechaEntregaCliente = value
        End Set
    End Property

    Public Property fechaEntregaProg() As Date
        Get
            Return PfechaEntregaProg
        End Get
        Set(ByVal value As Date)
            PfechaEntregaProg = value
        End Set
    End Property

    Public Property listaVentas() As ListaBase
        Get
            Return PlistaVentas
        End Get
        Set(ByVal value As ListaBase)
            PlistaVentas = value
        End Set
    End Property

    Public Property observaciones() As String
        Get
            Return Pobservaciones
        End Get
        Set(ByVal value As String)
            Pobservaciones = value
        End Set
    End Property
End Class
