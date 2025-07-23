Public Class ApartadoPorGenerar_PPCP

    Private PedidoId As Integer
    Public Property PPedidoId As Integer
        Get
            Return PedidoId
        End Get
        Set(ByVal value As Integer)
            PedidoId = value
        End Set
    End Property

    Private IdDetallePedidoSAY As String
    Public Property PIdDetallePedidoSAY As String
        Get
            Return IdDetallePedidoSAY
        End Get
        Set(ByVal value As String)
            IdDetallePedidoSAY = value
        End Set
    End Property

    Private FechaPreparacionPedido As String
    Public Property PFechaPreparacionPedido As String
        Get
            Return FechaPreparacionPedido
        End Get
        Set(ByVal value As String)
            FechaPreparacionPedido = value
        End Set
    End Property

    Private IdCliente As Integer
    Public Property PIdCliente As Integer
        Get
            Return IdCliente
        End Get
        Set(ByVal value As Integer)
            IdCliente = value
        End Set
    End Property

    Private UsuarioCapturaId As Integer
    Public Property PUsuarioCapturaId As Integer
        Get
            Return UsuarioCapturaId
        End Get
        Set(ByVal value As Integer)
            UsuarioCapturaId = value
        End Set
    End Property

    Private ObservacionApartado As String
    Public Property PObservacionApartado As String
        Get
            Return ObservacionApartado
        End Get
        Set(ByVal value As String)
            ObservacionApartado = value
        End Set
    End Property

    Private OrigenApartado As String
    Public Property POrigenApartado As String
        Get
            Return OrigenApartado
        End Get
        Set(ByVal value As String)
            OrigenApartado = value
        End Set
    End Property

    Private NaveSAYId As String
    Public Property PNaveSAYId As String
        Get
            Return NaveSAYId
        End Get
        Set(ByVal value As String)
            NaveSAYId = value
        End Set
    End Property

    Private ProgramaId As String
    Public Property PProgramaId As String
        Get
            Return ProgramaId
        End Get
        Set(ByVal value As String)
            ProgramaId = value
        End Set
    End Property

    Private ConDisponibilidad As Integer
    Public Property PConDisponibilidad As Integer
        Get
            Return ConDisponibilidad
        End Get
        Set(ByVal value As Integer)
            ConDisponibilidad = value
        End Set
    End Property

    Private ConDistribucion As Integer
    Public Property PConDistribucion As Integer
        Get
            Return ConDistribucion
        End Get
        Set(ByVal value As Integer)
            ConDistribucion = value
        End Set
    End Property

    Public Property PNapartados As String

End Class
