Public Class DetallesDeSalida
    Private pedido As String
    Private nombreTienda As String
    Private fechaEntrega As String
    Private fechaSalida As String
    Private idotCoppel As String

    Public Property pPedido() As String
        Get
            Return pedido
        End Get
        Set(ByVal value As String)
            pedido = value
        End Set
    End Property


    Public Property pNombreTienda() As String
        Get
            Return nombreTienda
        End Get
        Set(ByVal value As String)
            nombreTienda = value
        End Set
    End Property

    Public Property pFechaEntrega() As String
        Get
            Return fechaEntrega
        End Get
        Set(ByVal value As String)
            fechaEntrega = value
        End Set
    End Property

    Public Property pFechaSalida() As String
        Get
            Return fechaSalida
        End Get
        Set(ByVal value As String)
            fechaSalida = value
        End Set
    End Property

    Public Property pIdotCoppel() As String
        Get
            Return idotCoppel
        End Get
        Set(ByVal value As String)
            idotCoppel = value
        End Set
    End Property



End Class
