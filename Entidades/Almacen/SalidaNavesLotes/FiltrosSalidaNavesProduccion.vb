Public Class FiltrosSalidaNavesProduccion
    Private PUsuario As Entidades.Usuarios
    Private PFechaSalidaNave As Boolean ''''''''''1 SI / 0 NO checkbox
    Private PFechaInicioSalidaNave As Date
    Private PFechaFinSalidaNave As Date
    Private PFechaEntradaCEDIS As Boolean ''''''''''1 SI / 0 NO checkbox
    Private PFechaInicioEntradaCEDIS As Date
    Private PFechaFinEntradaCEDIS As Date
    Private PFechaPrograma As Boolean ''''''''''1 SI / 0 NO checkbox
    Private PFechaInicioPrograma As Date
    Private PFechaFinPrograma As Date
    Private PStatusID As String  'lista
    Private PConUbicacion_SI As Boolean ''''''''''1 SI / 0 NO checkbox
    Private PConUbicacion_NO As Boolean ''''''''''1 SI / 0 NO checkbox
    Private PCEDIS_id As String 'lista
    Private PSinCEDIS As Boolean ''''''''''1 SIN CEDIS / 0 CON CEDIS checkbox
    Private PEntregaMismoDia_SI As Boolean ''''''''''1 si / 0 no checkbox
    Private PEntregaMismoDia_NO As Boolean ''''''''''1 si / 0 no checkbox
    Private PNavesID As String 'lista Nave SICY
    Private PFolioSalidaID As String 'lista
    Private PLoteAño As String 'lista '125'2018158'20184589'2018'
    Private PAtado As String 'lista
    Private PTipoPedido As Integer ''''''''''1 ORIGEN / 2  ACTUAL radiobutton
    Private PTipoCliente As Integer ''''''''''1 ORIGEN / 2  ACTUAL radiobutton
    Private PTipoTienda As Integer ''''''''''1 ORIGEN / 2  ACTUAL radiobutton
    Private PPedidoID As String ''lista Pedido SICY
    Private PClienteID As String ''lista Cliente SICY
    Private PTiendaID As String ''lista Tienda DICY
    Private PProductoEstiloID As String ''SAY ProductoEstiloID '''lista
    Private PCorridaID As String ''SAY TallaID '''lista
    Private PTalla As String ''lista
    Private PCondicion As String ''''''''''1 And / 2  Or

    Private PTipoConsulta As String
    Private PNave As String

    Public Property Usuario As Entidades.Usuarios
        Get
            Return PUsuario
        End Get
        Set(value As Entidades.Usuarios)
            PUsuario = value
        End Set
    End Property

    Public Property FechaSalidaNave As Boolean
        Get
            Return PFechaSalidaNave
        End Get
        Set(value As Boolean)
            PFechaSalidaNave = value
        End Set
    End Property

    Public Property FechaInicioSalidaNave As Date
        Get
            Return PFechaInicioSalidaNave
        End Get
        Set(value As Date)
            PFechaInicioSalidaNave = value
        End Set
    End Property

    Public Property FechaFinSalidaNave As Date
        Get
            Return PFechaFinSalidaNave
        End Get
        Set(value As Date)
            PFechaFinSalidaNave = value
        End Set
    End Property

    Public Property FechaEntradaCEDIS As Boolean
        Get
            Return PFechaEntradaCEDIS
        End Get
        Set(value As Boolean)
            PFechaEntradaCEDIS = value
        End Set
    End Property

    Public Property FechaInicioEntradaCEDIS As Date
        Get
            Return PFechaInicioEntradaCEDIS
        End Get
        Set(value As Date)
            PFechaInicioEntradaCEDIS = value
        End Set
    End Property

    Public Property FechaFinEntradaCEDIS As Date
        Get
            Return PFechaFinEntradaCEDIS
        End Get
        Set(value As Date)
            PFechaFinEntradaCEDIS = value
        End Set
    End Property

    Public Property FechaPrograma As Boolean
        Get
            Return PFechaPrograma
        End Get
        Set(value As Boolean)
            PFechaPrograma = value
        End Set
    End Property

    Public Property FechaInicioPrograma As Date
        Get
            Return PFechaInicioPrograma
        End Get
        Set(value As Date)
            PFechaInicioPrograma = value
        End Set
    End Property

    Public Property FechaFinPrograma As Date
        Get
            Return PFechaFinPrograma
        End Get
        Set(value As Date)
            PFechaFinPrograma = value
        End Set
    End Property

    Public Property StatusID As String
        Get
            Return PStatusID
        End Get
        Set(value As String)
            PStatusID = value
        End Set
    End Property

    Public Property ConUbicacion_SI As Boolean
        Get
            Return PConUbicacion_SI
        End Get
        Set(value As Boolean)
            PConUbicacion_SI = value
        End Set
    End Property

    Public Property ConUbicacion_NO As Boolean
        Get
            Return PConUbicacion_NO
        End Get
        Set(value As Boolean)
            PConUbicacion_NO = value
        End Set
    End Property

    Public Property CEDIS_id As String
        Get
            Return PCEDIS_id
        End Get
        Set(value As String)
            PCEDIS_id = value
        End Set
    End Property

    Public Property SinCEDIS As Boolean
        Get
            Return PSinCEDIS
        End Get
        Set(value As Boolean)
            PSinCEDIS = value
        End Set
    End Property

    Public Property EntregaMismoDia_SI As Boolean
        Get
            Return PEntregaMismoDia_SI
        End Get
        Set(value As Boolean)
            PEntregaMismoDia_SI = value
        End Set
    End Property

    Public Property EntregaMismoDia_NO As Boolean
        Get
            Return PEntregaMismoDia_NO
        End Get
        Set(value As Boolean)
            PEntregaMismoDia_NO = value
        End Set
    End Property

    Public Property NavesID As String
        Get
            Return PNavesID
        End Get
        Set(value As String)
            PNavesID = value
        End Set
    End Property

    Public Property FolioSalidaID As String
        Get
            Return PFolioSalidaID
        End Get
        Set(value As String)
            PFolioSalidaID = value
        End Set
    End Property

    Public Property LoteAño As String
        Get
            Return PLoteAño
        End Get
        Set(value As String)
            PLoteAño = value
        End Set
    End Property

    Public Property Atado As String
        Get
            Return PAtado
        End Get
        Set(value As String)
            PAtado = value
        End Set
    End Property

    Public Property TipoPedido As Integer
        Get
            Return PTipoPedido
        End Get
        Set(value As Integer)
            PTipoPedido = value
        End Set
    End Property

    Public Property TipoCliente As Integer
        Get
            Return PTipoCliente
        End Get
        Set(value As Integer)
            PTipoCliente = value
        End Set
    End Property

    Public Property TipoTienda As Integer
        Get
            Return PTipoTienda
        End Get
        Set(value As Integer)
            PTipoTienda = value
        End Set
    End Property

    Public Property PedidoID As String
        Get
            Return PPedidoID
        End Get
        Set(value As String)
            PPedidoID = value
        End Set
    End Property

    Public Property ClienteID As String
        Get
            Return PClienteID
        End Get
        Set(value As String)
            PClienteID = value
        End Set
    End Property

    Public Property TiendaID As String
        Get
            Return PTiendaID
        End Get
        Set(value As String)
            PTiendaID = value
        End Set
    End Property

    Public Property ProductoEstiloID As String
        Get
            Return PProductoEstiloID
        End Get
        Set(value As String)
            PProductoEstiloID = value
        End Set
    End Property

    Public Property CorridaID As String
        Get
            Return PCorridaID
        End Get
        Set(value As String)
            PCorridaID = value
        End Set
    End Property

    Public Property Talla As String
        Get
            Return PTalla
        End Get
        Set(value As String)
            PTalla = value
        End Set
    End Property

    Public Property Condicion As String
        Get
            Return PCondicion
        End Get
        Set(value As String)
            PCondicion = value
        End Set
    End Property

    Public Property TipoConsulta As String
        Get
            Return PTipoConsulta
        End Get
        Set(value As String)
            PTipoConsulta = value
        End Set
    End Property

    Public Property Nave As String
        Get
            Return PNave
        End Get
        Set(value As String)
            PNave = value
        End Set
    End Property
End Class
