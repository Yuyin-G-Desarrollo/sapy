Public Class DistribucionPedido
    Private pDistribucionPedidoID As Integer
    Public Property DistribucionPedidoID() As Integer
        Get
            Return pDistribucionPedidoID
        End Get
        Set(ByVal value As Integer)
            pDistribucionPedidoID = value
        End Set
    End Property

    Private pCliente As Entidades.Cliente
    Public Property Cliente() As Entidades.Cliente
        Get
            Return pCliente
        End Get
        Set(ByVal value As Entidades.Cliente)
            pCliente = value
        End Set
    End Property

    Private pPedidoSAY As Integer
    Public Property PedidoSAY() As Integer
        Get
            Return pPedidoSAY
        End Get
        Set(ByVal value As Integer)
            pPedidoSAY = value
        End Set
    End Property

    Private pPedidoSICY As Integer
    Public Property PedidoSICY() As Integer
        Get
            Return pPedidoSICY
        End Get
        Set(ByVal value As Integer)
            pPedidoSICY = value
        End Set
    End Property

    Private pParesPedido As Integer
    Public Property ParesPedido() As Integer
        Get
            Return pParesPedido
        End Get
        Set(ByVal value As Integer)
            pParesPedido = value
        End Set
    End Property

    Private pParesArchivo As String
    Public Property ParesArchivo() As String
        Get
            Return pParesArchivo
        End Get
        Set(ByVal value As String)
            pParesArchivo = value
        End Set
    End Property

    Private pOrdenCliente As String
    Public Property OrdenCliente() As String
        Get
            Return pOrdenCliente
        End Get
        Set(ByVal value As String)
            pOrdenCliente = value
        End Set
    End Property

    Private pEstatusArchivo As String
    Public Property EstatusArchivo() As String
        Get
            Return pEstatusArchivo
        End Get
        Set(ByVal value As String)
            pEstatusArchivo = value
        End Set
    End Property

    Private pOrdenTrabajoId As Integer
    Public Property OrdenTrabajoID() As Integer
        Get
            Return pOrdenTrabajoId
        End Get
        Set(ByVal value As Integer)
            pOrdenTrabajoId = value
        End Set
    End Property

End Class
