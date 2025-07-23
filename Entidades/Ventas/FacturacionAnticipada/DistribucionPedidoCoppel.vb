Public Class DistribucionPedidoCoppel
    Private pDistribucionPedidoID As Integer
    Public Property DistribucionPedidoID() As Integer
        Get
            Return pDistribucionPedidoID
        End Get
        Set(ByVal value As Integer)
            pDistribucionPedidoID = value
        End Set
    End Property

    Private pDistribucionPedidoDetalleID As Integer
    Public Property DistribucionPedidoDetalleID() As Integer
        Get
            Return pDistribucionPedidoDetalleID
        End Get
        Set(ByVal value As Integer)
            pDistribucionPedidoDetalleID = value
        End Set
    End Property

    Private pCodigoRapidoCliente As String
    Public Property CodigoRapidoCliente() As String
        Get
            Return pCodigoRapidoCliente
        End Get
        Set(ByVal value As String)
            pCodigoRapidoCliente = value
        End Set
    End Property

    Private pModelo As String
    Public Property Modelo() As String
        Get
            Return pModelo
        End Get
        Set(ByVal value As String)
            pModelo = value
        End Set
    End Property

    Private pCosto As Single
    Public Property Costo() As Single
        Get
            Return pCosto
        End Get
        Set(ByVal value As Single)
            pCosto = value
        End Set
    End Property

    Private pTalla As Integer
    Public Property Talla() As Integer
        Get
            Return pTalla
        End Get
        Set(ByVal value As Integer)
            pTalla = value
        End Set
    End Property

    Private pDestino As String
    Public Property Destino() As String
        Get
            Return pDestino
        End Get
        Set(ByVal value As String)
            pDestino = value
        End Set
    End Property

    Private pCantidadPedida As Integer
    Public Property CantidadPedida() As Integer
        Get
            Return pCantidadPedida
        End Get
        Set(ByVal value As Integer)
            pCantidadPedida = value
        End Set
    End Property

    Private pCantidadSurtida As Integer
    Public Property CantidadSurtida() As Integer
        Get
            Return pCantidadSurtida
        End Get
        Set(ByVal value As Integer)
            pCantidadSurtida = value
        End Set
    End Property

    Private pUnidades As Integer
    Public Property Unidades() As Integer
        Get
            Return pUnidades
        End Get
        Set(ByVal value As Integer)
            pUnidades = value
        End Set
    End Property

    Private pImporte As Single
    Public ReadOnly Property Importe() As Single
        Get
            pImporte = pCosto * pCantidadSurtida
            Return pImporte
        End Get
    End Property

    Private pIVA As Single
    Public ReadOnly Property IVA() As Single
        Get
            pIVA = pImporte * 0.16F
            Return pIVA
        End Get
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

    Private pTiendaEmbarqueId As Integer
    Public Property TiendaEmbarqueId() As Integer
        Get
            Return pTiendaEmbarqueId
        End Get
        Set(ByVal value As Integer)
            pTiendaEmbarqueId = value
        End Set
    End Property

    Private pNombreTiendaEmbarque As String
    Public Property NombreTiendaEmbarque() As String
        Get
            Return pNombreTiendaEmbarque
        End Get
        Set(ByVal value As String)
            pNombreTiendaEmbarque = value
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
