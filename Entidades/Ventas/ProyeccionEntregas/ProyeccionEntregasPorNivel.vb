Public Class ProyeccionEntregasPorNivel

#Region "Filtros"

    Private usuarioConsultaId As Integer
    Private tipoConsulta As Integer
    Private idPedidoSAY As Integer
    Private idPedidoSICY As Integer
    Private idPartida As Integer
    Private lote As Integer
    Private año As Integer
    Private naveSicyID As Integer
    Private atado As String
    Private cedis As Integer

#End Region

#Region "Propiedades"

    Public Property PusuarioConsultaId() As Integer
        Get
            Return usuarioConsultaId
        End Get
        Set(ByVal value As Integer)
            usuarioConsultaId = value
        End Set
    End Property

    Public Property PtipoConsulta() As Integer
        Get
            Return tipoConsulta
        End Get
        Set(ByVal value As Integer)
            tipoConsulta = value
        End Set
    End Property

    Public Property PidPedidoSAY() As Integer
        Get
            Return idPedidoSAY
        End Get
        Set(ByVal value As Integer)
            idPedidoSAY = value
        End Set
    End Property

    Public Property PidPedidoSICY() As Integer
        Get
            Return idPedidoSICY
        End Get
        Set(ByVal value As Integer)
            idPedidoSICY = value
        End Set
    End Property

    Public Property PidPartida() As Integer
        Get
            Return idPartida
        End Get
        Set(ByVal value As Integer)
            idPartida = value
        End Set
    End Property

    Public Property Plote() As Integer
        Get
            Return lote
        End Get
        Set(ByVal value As Integer)
            lote = value
        End Set
    End Property

    Public Property Paño() As Integer
        Get
            Return año
        End Get
        Set(ByVal value As Integer)
            año = value
        End Set
    End Property

    Public Property PnaveSicyID() As Integer
        Get
            Return naveSicyID
        End Get
        Set(ByVal value As Integer)
            naveSicyID = value
        End Set
    End Property

    Public Property Patado() As String
        Get
            Return atado
        End Get
        Set(ByVal value As String)
            atado = value
        End Set
    End Property

    Public Property Pcedis As Integer
        Get
            Return cedis
        End Get
        Set(value As Integer)
            cedis = value
        End Set
    End Property

#End Region


End Class
