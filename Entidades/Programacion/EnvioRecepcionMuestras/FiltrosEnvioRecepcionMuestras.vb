Public Class FiltrosEnvioRecepcionMuestras

    Private PMovimientos As String
    Private PFechaMovimiento As String
    Private PDelPedidoOrigen As Boolean
    Private PDelPedidoDelMovimiento As Boolean
    Private PPedidosMOrigen As Boolean
    Private PPedidosMMovimiento As Boolean



    Private PNaveAlmacen As Integer = 0
    Private PNumeroAlmacen As Integer = 0
    Private PFechaUbicacionDel As Date
    Private PHoraUbicacionDel As String
    Private PFechaUbicacionAl As Date
    Private PHoraUbicacionAl As String


    Private PFechaEntregaNaveDel As Date
    Private PFechaEntregaNaveAl As Date
    Private PFechaEntregaClienteDel As Date
    Private PFechaEntregaClienteAl As Date
    Private PFechaEnvioNaveDel As Date
    Private PFechaEnvioNaveAl As Date
    Private PFechaRecepcionComercializadoraDel As Date
    Private PFechaRecepcionComercializadoraAl As Date

    Private PNaveSICYID As String
    Private PBahiaID As String
    Private PCodigosPieza As String
    Private PClientes As String
    Private PEsPedidoActual As Boolean
    Private PPedidoMuestras As String

    Private PStatusAsignada As Boolean
    Private PStatusDisponible As Boolean

    Private PArticulos As String
    Private PCorrida As String
    Private PTallas As String
    Private POperador As String

    Private PTipoUbicacion As Integer = 0 '1=> Con ubicacion, 2=> Sin Ubicacion, 3=> Todo
    Private PTipoOperacion As Integer = 0 ' 1 => Y, 2 => O
    Private PFiltroUbicacion As Boolean

    Private PFiltroentregaNave As Boolean
    Private PFiltroEntregaCliente As Boolean
    Private PFiltroEnvioNave As Boolean
    Private PFiltroRecepcionComercializadora As Boolean
    Private PEsClienteOrigen As Boolean
    Private PEsPedidoOrigen As Boolean

    Public Property NaveAlmacen As Integer
        Get
            Return PNaveAlmacen
        End Get
        Set(value As Integer)
            PNaveAlmacen = value
        End Set
    End Property


    Public Property NumeroAlmacen As Integer
        Get
            Return PNumeroAlmacen
        End Get
        Set(value As Integer)
            PNumeroAlmacen = value
        End Set
    End Property
    Public Property FechaUbicacionDel As Date
        Get
            Return PFechaUbicacionDel
        End Get
        Set(value As Date)
            PFechaUbicacionDel = value
        End Set
    End Property
    Public Property HoraUbicacionDel As String
        Get
            Return PHoraUbicacionDel
        End Get
        Set(value As String)
            PHoraUbicacionDel = value
        End Set
    End Property
    Public Property FechaUbicacionAl As Date
        Get
            Return PFechaUbicacionAl
        End Get
        Set(value As Date)
            PFechaUbicacionAl = value
        End Set
    End Property
    Public Property HoraUbicacionAl As String
        Get
            Return PHoraUbicacionAl
        End Get
        Set(value As String)
            PHoraUbicacionAl = value
        End Set
    End Property
    Public Property FechaEntregaNaveDel As Date
        Get
            Return PFechaEntregaNaveDel
        End Get
        Set(value As Date)
            PFechaEntregaNaveDel = value
        End Set
    End Property
    Public Property FechaEntregaNaveAl As Date
        Get
            Return PFechaEntregaNaveAl
        End Get
        Set(value As Date)
            PFechaEntregaNaveAl = value
        End Set
    End Property
    Public Property FechaEntregaClienteDel As Date
        Get
            Return PFechaEntregaClienteDel
        End Get
        Set(value As Date)
            PFechaEntregaClienteDel = value
        End Set
    End Property
    Public Property FechaEntregaClienteAl As Date
        Get
            Return PFechaEntregaClienteAl
        End Get
        Set(value As Date)
            PFechaEntregaClienteAl = value
        End Set
    End Property
    Public Property FechaEnvioNaveDel As Date
        Get
            Return PFechaEnvioNaveDel
        End Get
        Set(value As Date)
            PFechaEnvioNaveDel = value
        End Set
    End Property
    Public Property FechaEnvioNaveAl As Date
        Get
            Return PFechaEnvioNaveAl
        End Get
        Set(value As Date)
            PFechaEnvioNaveAl = value
        End Set
    End Property
    Public Property FechaRecepcionComercializadoraDel As Date
        Get
            Return PFechaRecepcionComercializadoraDel
        End Get
        Set(value As Date)
            PFechaRecepcionComercializadoraDel = value
        End Set
    End Property
    Public Property FechaRecepcionComercializadoraAl As Date
        Get
            Return PFechaRecepcionComercializadoraAl
        End Get
        Set(value As Date)
            PFechaRecepcionComercializadoraAl = value
        End Set
    End Property
    Public Property NaveSICYID As String
        Get
            Return PNaveSICYID
        End Get
        Set(value As String)
            PNaveSICYID = value
        End Set
    End Property
    Public Property BahiaID As String
        Get
            Return PBahiaID
        End Get
        Set(value As String)
            PBahiaID = value
        End Set
    End Property
    Public Property CodigosPieza As String
        Get
            Return PCodigosPieza
        End Get
        Set(value As String)
            PCodigosPieza = value
        End Set
    End Property

    Public Property Clientes As String
        Get
            Return PClientes
        End Get
        Set(value As String)
            PClientes = value
        End Set
    End Property
    Public Property EsPedidoActual As Boolean
        Get
            Return PEsPedidoActual
        End Get
        Set(value As Boolean)
            PEsPedidoActual = value
        End Set
    End Property
    Public Property PedidoMuestras As String
        Get
            Return PPedidoMuestras
        End Get
        Set(value As String)
            PPedidoMuestras = value
        End Set
    End Property
    Public Property StatusAsignada As Boolean
        Get
            Return PStatusAsignada
        End Get
        Set(value As Boolean)
            PStatusAsignada = value
        End Set
    End Property
    Public Property StatusDisponible As Boolean
        Get
            Return PStatusDisponible
        End Get
        Set(value As Boolean)
            PStatusDisponible = value
        End Set
    End Property
    Public Property Articulos As String
        Get
            Return PArticulos
        End Get
        Set(value As String)
            PArticulos = value
        End Set
    End Property
    Public Property Corrida As String
        Get
            Return PCorrida
        End Get
        Set(value As String)
            PCorrida = value
        End Set
    End Property
    Public Property Tallas As String
        Get
            Return PTallas
        End Get
        Set(value As String)
            PTallas = value
        End Set
    End Property
    Public Property Operador As String
        Get
            Return POperador
        End Get
        Set(value As String)
            POperador = value
        End Set
    End Property
    '1=> Con ubicacion, 2=> Sin Ubicacion, 3=> Todo
    Public Property TipoUbicacion As Integer
        Get
            Return PTipoUbicacion
        End Get
        Set(value As Integer)
            PTipoUbicacion = value
        End Set
    End Property
    ' 1 => Y, 2 => O
    Public Property TipoOperacion As Integer
        Get
            Return PTipoOperacion
        End Get
        Set(value As Integer)
            PTipoOperacion = value
        End Set
    End Property

    Public Property FiltroUbicacion As Boolean
        Get
            Return PFiltroUbicacion
        End Get
        Set(value As Boolean)
            PFiltroUbicacion = value
        End Set
    End Property

    Public Property FiltroentregaNave As Boolean
        Get
            Return PFiltroentregaNave
        End Get
        Set(value As Boolean)
            PFiltroentregaNave = value
        End Set
    End Property

    Public Property FiltroEntregaCliente As Boolean
        Get
            Return PFiltroEntregaCliente
        End Get
        Set(value As Boolean)
            PFiltroEntregaCliente = value
        End Set
    End Property

    Public Property FiltroEnvioNave As Boolean
        Get
            Return PFiltroEnvioNave
        End Get
        Set(value As Boolean)
            PFiltroEnvioNave = value
        End Set
    End Property

    Public Property FiltroRecepcionComercializadora As Boolean
        Get
            Return PFiltroRecepcionComercializadora
        End Get
        Set(value As Boolean)
            PFiltroRecepcionComercializadora = value
        End Set
    End Property

    Public Property EsClienteOrigen As Boolean
        Get
            Return PEsClienteOrigen
        End Get
        Set(value As Boolean)
            PEsClienteOrigen = value
        End Set
    End Property

    Public Property EsPedidoOrigen As Boolean
        Get
            Return PEsPedidoOrigen
        End Get
        Set(value As Boolean)
            PEsPedidoOrigen = value
        End Set
    End Property

    Public Property Movimientos As String
        Get
            Return PMovimientos
        End Get
        Set(value As String)
            PMovimientos = value
        End Set
    End Property
    Public Property FechaMovimiento As String
        Get
            Return PFechaMovimiento
        End Get
        Set(value As String)
            PFechaMovimiento = value
        End Set
    End Property


    Public Property DelPedidoOrigen As Boolean
        Get
            Return PDelPedidoOrigen
        End Get
        Set(value As Boolean)
            PDelPedidoOrigen = value
        End Set
    End Property


    Public Property DelPedidoDelMovimiento As Boolean
        Get
            Return PDelPedidoDelMovimiento
        End Get
        Set(value As Boolean)
            PDelPedidoDelMovimiento = value
        End Set
    End Property

    Public Property PedidosMOrigen As Boolean
        Get
            Return PPedidosMOrigen
        End Get
        Set(value As Boolean)
            PPedidosMOrigen = value
        End Set
    End Property


    Public Property PedidosMMovimiento As Boolean
        Get
            Return PPedidosMMovimiento
        End Get
        Set(value As Boolean)
            PPedidosMMovimiento = value
        End Set
    End Property


End Class
