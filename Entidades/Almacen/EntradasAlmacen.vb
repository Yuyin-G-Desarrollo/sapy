Public Class EntradasAlmacen
    Private _Filtro As String
    Private _Tallas As String
    Private _Lotes As String
    Private _Atados As String
    Private _Pedidos As String
    Private _Productos As String
    Private _Clientes As String
    Private _Corridas As String
    Private _Tiendas As String
    Private _Nave As String
    Private _fechaInicioEntradas As String
    Private _fechaTerminoEntradas As String
    Private _fechaInicioProgramas As String
    Private _fechaTerminoProgramas As String
    Private _bY_O As Boolean
    Private _filtroFechaPrograma As Boolean
    Private _EsPedidoActual As Boolean
    Private _EsClienteActual As Boolean
    Private _Ubicacion As Boolean
    Private _ComercializadoraId As Integer

    Public Property ComercializadoraId As Integer
        Get
            Return _ComercializadoraId
        End Get
        Set(value As Integer)
            _ComercializadoraId = value
        End Set
    End Property

    Public Property Filtro As String
        Get
            Return _Filtro
        End Get
        Set(value As String)
            _Filtro = value
        End Set
    End Property

    Public Property Tallas As String
        Get
            Return _Tallas
        End Get
        Set(value As String)
            _Tallas = value
        End Set
    End Property

    Public Property Lotes As String
        Get
            Return _Lotes
        End Get
        Set(value As String)
            _Lotes = value
        End Set
    End Property

    Public Property Atados As String
        Get
            Return _Atados
        End Get
        Set(value As String)
            _Atados = value
        End Set
    End Property

    Public Property Pedidos As String
        Get
            Return _Pedidos
        End Get
        Set(value As String)
            _Pedidos = value
        End Set
    End Property

    Public Property Productos As String
        Get
            Return _Productos
        End Get
        Set(value As String)
            _Productos = value
        End Set
    End Property

    Public Property Clientes As String
        Get
            Return _Clientes
        End Get
        Set(value As String)
            _Clientes = value
        End Set
    End Property

    Public Property Corridas As String
        Get
            Return _Corridas
        End Get
        Set(value As String)
            _Corridas = value
        End Set
    End Property

    Public Property Tiendas As String
        Get
            Return _Tiendas
        End Get
        Set(value As String)
            _Tiendas = value
        End Set
    End Property

    Public Property Nave As String
        Get
            Return _Nave
        End Get
        Set(value As String)
            _Nave = value
        End Set
    End Property

    Public Property FechaInicioEntradas As String
        Get
            Return _fechaInicioEntradas
        End Get
        Set(value As String)
            _fechaInicioEntradas = value
        End Set
    End Property

    Public Property FechaTerminoEntradas As String
        Get
            Return _fechaTerminoEntradas
        End Get
        Set(value As String)
            _fechaTerminoEntradas = value
        End Set
    End Property

    Public Property FechaInicioProgramas As String
        Get
            Return _fechaInicioProgramas
        End Get
        Set(value As String)
            _fechaInicioProgramas = value
        End Set
    End Property

    Public Property FechaTerminoProgramas As String
        Get
            Return _fechaTerminoProgramas
        End Get
        Set(value As String)
            _fechaTerminoProgramas = value
        End Set
    End Property

    Public Property BY_O As Boolean
        Get
            Return _bY_O
        End Get
        Set(value As Boolean)
            _bY_O = value
        End Set
    End Property

    Public Property FiltroFechaPrograma As Boolean
        Get
            Return _filtroFechaPrograma
        End Get
        Set(value As Boolean)
            _filtroFechaPrograma = value
        End Set
    End Property

    Public Property EsPedidoActual As Boolean
        Get
            Return _EsPedidoActual
        End Get
        Set(value As Boolean)
            _EsPedidoActual = value
        End Set
    End Property

    Public Property EsClienteActual As Boolean
        Get
            Return _EsClienteActual
        End Get
        Set(value As Boolean)
            _EsClienteActual = value
        End Set
    End Property

    Public Property Ubicacion As Boolean
        Get
            Return _Ubicacion
        End Get
        Set(value As Boolean)
            _Ubicacion = value
        End Set
    End Property
End Class
