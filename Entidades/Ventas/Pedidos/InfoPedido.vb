Public Class InfoPedido
    Private _cliente As String = String.Empty
    Private _pedidoSAY As Integer = 0
    Private _pedidoSICY As Integer = 0
    Private _ordenCliente As String = String.Empty
    Private _fechaCaptura As DateTime = DateTime.Now
    Private _fechaEntregaCliente As DateTime = DateTime.Now
    Private _ejecutivo As String = String.Empty
    Private _agente As String = String.Empty

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property PedidoSAY As Integer
        Get
            Return _pedidoSAY
        End Get
        Set(value As Integer)
            _pedidoSAY = value
        End Set
    End Property

    Public Property PedidoSICY As Integer
        Get
            Return _pedidoSICY
        End Get
        Set(value As Integer)
            _pedidoSICY = value
        End Set
    End Property

    Public Property OrdenCliente As String
        Get
            Return _ordenCliente
        End Get
        Set(value As String)
            _ordenCliente = value
        End Set
    End Property

    Public Property FechaCaptura As DateTime
        Get
            Return _fechaCaptura
        End Get
        Set(value As DateTime)
            _fechaCaptura = value
        End Set
    End Property

    Public Property FechaEntregaCliente As DateTime
        Get
            Return _fechaEntregaCliente
        End Get
        Set(value As DateTime)
            _fechaEntregaCliente = value
        End Set
    End Property

    Public Property Ejecutivo As String
        Get
            Return _ejecutivo
        End Get
        Set(value As String)
            _ejecutivo = value
        End Set
    End Property

    Public Property Agente As String
        Get
            Return _agente
        End Get
        Set(value As String)
            _agente = value
        End Set
    End Property
End Class
