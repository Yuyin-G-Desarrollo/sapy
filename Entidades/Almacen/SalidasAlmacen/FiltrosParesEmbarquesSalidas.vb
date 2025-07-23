Public Class FiltrosParesEmbarquesSalidas

    Private CodigosPar As String
    Private CodigosAtado As String
    Private Lotes As String
    Private AñosLotes As String
    Private Naves As String
    Private Pedidos As String
    Private Clientes As String
    Private Tiendas As String
    Private Productos As String
    Private Corridas As String
    Private Tallas As String
    Private FiltroY_O As String
    Private Cedis As Integer

    Public Property PCodigosPar As String
        Get
            Return CodigosPar
        End Get
        Set(value As String)
            CodigosPar = value
        End Set
    End Property

    Public Property PCodigosAtado As String
        Get
            Return CodigosAtado
        End Get
        Set(value As String)
            CodigosAtado = value
        End Set
    End Property

    Public Property PLotes As String
        Get
            Return Lotes
        End Get
        Set(value As String)
            Lotes = value
        End Set
    End Property

    Public Property PAñosLotes As String
        Get
            Return AñosLotes
        End Get
        Set(value As String)
            AñosLotes = value
        End Set
    End Property

    Public Property PNaves As String
        Get
            Return Naves
        End Get
        Set(value As String)
            Naves = value
        End Set
    End Property

    Public Property PPedidos As String
        Get
            Return Pedidos
        End Get
        Set(value As String)
            Pedidos = value
        End Set
    End Property

    Public Property PClientes As String
        Get
            Return Clientes
        End Get
        Set(value As String)
            Clientes = value
        End Set
    End Property

    Public Property PTiendas As String
        Get
            Return Tiendas
        End Get
        Set(value As String)
            Tiendas = value
        End Set
    End Property

    Public Property PProductos As String
        Get
            Return Productos
        End Get
        Set(value As String)
            Productos = value
        End Set
    End Property

    Public Property PCorridas As String
        Get
            Return Corridas
        End Get
        Set(value As String)
            Corridas = value
        End Set
    End Property

    Public Property PTallas As String
        Get
            Return Tallas
        End Get
        Set(value As String)
            Tallas = value
        End Set
    End Property

    Public Property PFiltroY_O As String
        Get
            Return FiltroY_O
        End Get
        Set(value As String)
            FiltroY_O = value
        End Set
    End Property

    Public Property PCedis As Integer
        Get
            Return Cedis
        End Get
        Set(value As Integer)
            Cedis = value
        End Set
    End Property

End Class
