Public Class PedidosWeb

    Private clienteidSay As Int32
    Private colaborador_vendedorId As Int32
    Private listaPreciosId As Int32
    Private RfcId As Int32
    Private ramoId As Int32
    Private tipoPedidoId As Int32
    Private inicial As Boolean
    Private ordenCliente As String
    Private entregaInmediata As Boolean
    Private fechaProgramacion As DateTime
    Private fechaProgramacionPropuesta As DateTime
    Private fechasolicitadaCliente As DateTime
    Private rutaPedidoScanneado As String
    Private intercom As Int32
    Private observaciones As String
    Private rutaId As Int32
    Private monedaId As Int32
    Private usuarioCreoId As Int32

    Public Property PClienteIdSay() As Int32
        Get
            Return clienteidSay
        End Get
        Set(ByVal value As Int32)
            clienteidSay = value
        End Set
    End Property


    Public Property PColaborador_vendedorId() As Int32
        Get
            Return colaborador_vendedorId
        End Get
        Set(ByVal value As Int32)
            colaborador_vendedorId = value
        End Set
    End Property


    Public Property PListaPreciosId() As Int32
        Get
            Return listaPreciosId
        End Get
        Set(ByVal value As Int32)
            listaPreciosId = value
        End Set
    End Property



    Public Property PRfcId() As Int32
        Get
            Return RfcId
        End Get
        Set(ByVal value As Int32)
            RfcId = value
        End Set
    End Property


    Public Property PRamoId() As Int32
        Get
            Return ramoId
        End Get
        Set(ByVal value As Int32)
            ramoId = value
        End Set
    End Property


    Public Property PTipoPedidoId() As Int32
        Get
            Return tipoPedidoId
        End Get
        Set(ByVal value As Int32)
            tipoPedidoId = value
        End Set
    End Property

    Public Property PIncial() As Boolean
        Get
            Return inicial
        End Get
        Set(ByVal value As Boolean)
            inicial = value
        End Set
    End Property

   
    Public Property POrdenCliente() As String
        Get
            Return ordenCliente
        End Get
        Set(ByVal value As String)
            ordenCliente = value
        End Set
    End Property


    Public Property PEntregaInmediata() As Boolean
        Get
            Return entregaInmediata
        End Get
        Set(ByVal value As Boolean)
            entregaInmediata = value
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

  
    Public Property PFechasolicitadaCliente() As Date
        Get
            Return fechasolicitadaCliente
        End Get
        Set(ByVal value As Date)
            fechasolicitadaCliente = value
        End Set
    End Property


    Public Property PRutaPedidoScanneado() As String
        Get
            Return rutaPedidoScanneado
        End Get
        Set(ByVal value As String)
            rutaPedidoScanneado = value
        End Set
    End Property


    Public Property PIntercom() As Int32
        Get
            Return intercom
        End Get
        Set(ByVal value As Int32)
            intercom = value
        End Set
    End Property


    Public Property PObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

   
    Public Property PRutaId() As Int32
        Get
            Return rutaId
        End Get
        Set(ByVal value As Int32)
            rutaId = value
        End Set
    End Property


    Public Property PMonedaId() As Int32
        Get
            Return monedaId
        End Get
        Set(ByVal value As Int32)
            monedaId = value
        End Set
    End Property


    Public Property PUsuarioCreoId() As Int32
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Int32)
            usuarioCreoId = value
        End Set
    End Property

    Private solicitaClienteFecha As Date
    Public Property PSolicitaClienteFecha() As Date
        Get
            Return solicitaClienteFecha
        End Get
        Set(ByVal value As Date)
            solicitaClienteFecha = value
        End Set
    End Property

    Private claveCfdi As String
    Public Property PClaveCFDI() As String
        Get
            Return claveCfdi
        End Get
        Set(ByVal value As String)
            claveCfdi = value
        End Set
    End Property

End Class
