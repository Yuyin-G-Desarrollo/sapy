Public Class InventarioCiclicoBusqueda
    Private Operador As String
    Private Producto As String
    Private ubicacion As String
    Private Corridas As String
    Private Marcas As String
    Private Coleccion As String
    Private pedido As String
    Private Cliente As String
    Private Agente As String
    Private Activo As Boolean
    Private Tienda As String
    Private Estado As String
    Private modelo As String



    Public Property PModelo As String
        Get
            Return modelo
        End Get
        Set(value As String)
            modelo = value
        End Set
    End Property

    Public Property PEstado As String
        Get
            Return Estado
        End Get
        Set(value As String)
            Estado = value
        End Set
    End Property

    Public Property PTienda As String
        Get
            Return Tienda
        End Get
        Set(value As String)
            Tienda = value
        End Set
    End Property
    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property POperador As String
        Get
            Return Operador
        End Get
        Set(value As String)
            Operador = value
        End Set
    End Property
    Public Property PProducto As String
        Get
            Return Producto
        End Get
        Set(value As String)
            Producto = value
        End Set
    End Property
    Public Property PUbicacion As String
        Get
            Return ubicacion
        End Get
        Set(value As String)
            ubicacion = value
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
    Public Property PMarcas As String
        Get
            Return Marcas
        End Get
        Set(value As String)
            Marcas = value
        End Set
    End Property
    Public Property Pcoleccion As String
        Get
            Return Coleccion
        End Get
        Set(value As String)
            Coleccion = value
        End Set
    End Property
    Public Property PPedido As String
        Get
            Return pedido
        End Get
        Set(value As String)
            pedido = value
        End Set
    End Property
    Public Property PCliente As String
        Get
            Return Cliente
        End Get
        Set(value As String)
            Cliente = value
        End Set
    End Property
    Public Property PAgente As String
        Get
            Return Agente
        End Get
        Set(value As String)
            Agente = value
        End Set
    End Property
End Class
