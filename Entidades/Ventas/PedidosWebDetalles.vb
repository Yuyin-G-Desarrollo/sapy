Public Class PedidosWebDetalles
    Private pedidoIdSAY As String
    Private clienteIdSAY As Int32
    Private partidaId As Int32
    Private articuloRepetido As Boolean
    Private productoEstiloId As String
    Private tallaId As Int32
    Private tipoNumeracion As String
    Private tiendaEmbarqueCEDISId As Int32
    Private cantidad As Int32
    Private precio As Double
    Private fechaProgramacion As Date
    Private fechaProgramacionPropuesta As Date
    Private fechaSolicitadaCliente As Date
    Private pedidoTEC As String
    Private anotacion As String
    Private usuarioCreo As Int32
    Private banderaOperacion As Int32

    Public Property PPedidoIdSAY() As String
        Get
            Return pedidoIdSAY
        End Get
        Set(ByVal value As String)
            pedidoIdSAY = value
        End Set
    End Property


    Public Property PClienteIdSAY() As Int32
        Get
            Return clienteIdSAY
        End Get
        Set(ByVal value As Int32)
            clienteIdSAY = value
        End Set
    End Property

   
    Public Property PPartidaId() As Int32
        Get
            Return partidaId
        End Get
        Set(ByVal value As Int32)
            partidaId = value
        End Set
    End Property


    Public Property PArticuloRepetido() As Boolean
        Get
            Return articuloRepetido
        End Get
        Set(ByVal value As Boolean)
            articuloRepetido = value
        End Set
    End Property

    Public Property PProductoEstiloId() As String
        Get
            Return productoEstiloId
        End Get
        Set(ByVal value As String)
            productoEstiloId = value
        End Set
    End Property


    Public Property PTallaId() As Int32
        Get
            Return tallaId
        End Get
        Set(ByVal value As Int32)
            tallaId = value
        End Set
    End Property

    
    Public Property PTipoNumeracion() As String
        Get
            Return tipoNumeracion
        End Get
        Set(ByVal value As String)
            tipoNumeracion = value
        End Set
    End Property


    Public Property PTiendaEmbarqueCEDISId() As Int32
        Get
            Return tiendaEmbarqueCEDISId
        End Get
        Set(ByVal value As Int32)
            tiendaEmbarqueCEDISId = value
        End Set
    End Property


    Public Property PCantidad() As Int32
        Get
            Return cantidad
        End Get
        Set(ByVal value As Int32)
            cantidad = value
        End Set
    End Property


    Public Property PPrecio() As Double
        Get
            Return precio
        End Get
        Set(ByVal value As Double)
            precio = value
        End Set
    End Property

    
    Public Property PFechaProgramacion() As Date
        Get
            Return fechaProgramacion
        End Get
        Set(ByVal value As Date)
            fechaProgramacion = value
        End Set
    End Property


    Public Property PFechaProgramacionPropuesta() As Date
        Get
            Return fechaProgramacionPropuesta
        End Get
        Set(ByVal value As Date)
            fechaProgramacionPropuesta = value
        End Set
    End Property


    Public Property PFechaSolicitadaCliente() As Date
        Get
            Return fechaSolicitadaCliente
        End Get
        Set(ByVal value As Date)
            fechaSolicitadaCliente = value
        End Set
    End Property


    Public Property PPedidoTEC() As String
        Get
            Return pedidoTEC
        End Get
        Set(ByVal value As String)
            pedidoTEC = value
        End Set
    End Property


    Public Property PAnotacion() As String
        Get
            Return anotacion
        End Get
        Set(ByVal value As String)
            anotacion = value
        End Set
    End Property


    Public Property PusuarioCreo() As Int32
        Get
            Return usuarioCreo
        End Get
        Set(ByVal value As Int32)
            usuarioCreo = value
        End Set
    End Property


    Public Property PbanderaOperacion() As Int32
        Get
            Return banderaOperacion
        End Get
        Set(ByVal value As Int32)
            banderaOperacion = value
        End Set
    End Property

    Private listaPrecioCLienteId As String
    Public Property PListaPrecioCLienteId() As String
        Get
            Return listaPrecioCLienteId
        End Get
        Set(ByVal value As String)
            listaPrecioCLienteId = value
        End Set
    End Property

    Private pedidodetalleid As String
    Public Property PPedidodetalleid() As String
        Get
            Return pedidodetalleid
        End Get
        Set(ByVal value As String)
            pedidodetalleid = value
        End Set
    End Property


End Class
