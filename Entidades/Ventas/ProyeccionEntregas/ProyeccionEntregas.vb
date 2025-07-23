

Public Class ProyeccionEntregas


#Region "Filtros"

    Private fechaEntregaInicio As String
    Private fechaEntregaFin As String
    Private mostrarClientesCita As Integer
    Private mostrarClientesNoCita As Integer
    Private statusPedido As String
    Private plazoPago As String
    Private pedidoSAY As String
    Private pedidoSICY As String
    Private cliente As String
    Private tiendaEmbarqueCedis As String
    Private atnClientes As String
    Private agenteVentas As String
    Private marca As String
    Private coleccion As String
    Private modelo As String
    Private piel As String
    Private color As String
    Private corrida As String

#End Region

#Region "Propiedades"

    Public Property PfechaEntregaInicio() As String
        Get
            Return fechaEntregaInicio
        End Get
        Set(ByVal value As String)
            fechaEntregaInicio = value
        End Set
    End Property

    Public Property PfechaEntregaFin() As String
        Get
            Return fechaEntregaFin
        End Get
        Set(value As String)
            fechaEntregaFin = value
        End Set
    End Property

    Public Property PmostrarClientesCita() As Integer
        Get
            Return mostrarClientesCita
        End Get
        Set(ByVal value As Integer)
            mostrarClientesCita = value
        End Set
    End Property

    Public Property PmostrarClientesNoCita() As Integer
        Get
            Return mostrarClientesNoCita
        End Get
        Set(ByVal value As Integer)
            mostrarClientesNoCita = value
        End Set
    End Property

    Public Property PstatusPedido() As String
        Get
            Return statusPedido
        End Get
        Set(ByVal value As String)
            statusPedido = value
        End Set
    End Property

    Public Property PplazoPago() As String
        Get
            Return plazoPago
        End Get
        Set(ByVal value As String)
            plazoPago = value
        End Set
    End Property

    Public Property PpedidoSAY() As String
        Get
            Return pedidoSAY
        End Get
        Set(ByVal value As String)
            pedidoSAY = value
        End Set
    End Property

    Public Property PpedidoSICY() As String
        Get
            Return pedidoSICY
        End Get
        Set(ByVal value As String)
            pedidoSICY = value
        End Set
    End Property

    Public Property Pcliente() As String
        Get
            Return cliente
        End Get
        Set(ByVal value As String)
            cliente = value
        End Set
    End Property

    Public Property PtiendaEmbarqueCedis() As String
        Get
            Return tiendaEmbarqueCedis
        End Get
        Set(ByVal value As String)
            tiendaEmbarqueCedis = value
        End Set
    End Property

    Public Property PatnClientes() As String
        Get
            Return atnClientes
        End Get
        Set(ByVal value As String)
            atnClientes = value
        End Set
    End Property

    Public Property PagenteVentas() As String
        Get
            Return agenteVentas
        End Get
        Set(ByVal value As String)
            agenteVentas = value
        End Set
    End Property

    Public Property Pmarca() As String
        Get
            Return marca
        End Get
        Set(ByVal value As String)
            marca = value
        End Set
    End Property

    Public Property Pcoleccion() As String
        Get
            Return coleccion
        End Get
        Set(ByVal value As String)
            coleccion = value
        End Set
    End Property

    Public Property Pmodelo() As String
        Get
            Return modelo
        End Get
        Set(ByVal value As String)
            modelo = value
        End Set
    End Property

    Public Property Ppiel() As String
        Get
            Return piel
        End Get
        Set(ByVal value As String)
            piel = value
        End Set
    End Property

    Public Property Pcolor() As String
        Get
            Return color
        End Get
        Set(ByVal value As String)
            color = value
        End Set
    End Property

    Public Property Pcorrida() As String
        Get
            Return corrida
        End Get
        Set(ByVal value As String)
            corrida = value
        End Set
    End Property


#End Region


End Class
