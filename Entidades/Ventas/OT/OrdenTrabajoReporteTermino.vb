
Public Class OrdenTrabajoReporteTermino

    Private POrdenCliente As String
    Public Property OrdenCliente() As String
        Get
            Return POrdenCliente
        End Get
        Set(ByVal value As String)
            POrdenCliente = value
        End Set
    End Property

    Private POrdenTrabajoID As String
    Public Property OrdenTrabajoID() As String
        Get
            Return POrdenTrabajoID
        End Get
        Set(ByVal value As String)
            POrdenTrabajoID = value
        End Set
    End Property

    Private POTCodigo As String
    Public Property OTCodigo() As String
        Get
            Return POTCodigo
        End Get
        Set(ByVal value As String)
            POTCodigo = value
        End Set
    End Property

    Private POrdenTrabajoSICYID As Integer
    Public Property OrdenTrabajoSICYID() As Integer
        Get
            Return POrdenTrabajoSICYID
        End Get
        Set(ByVal value As Integer)
            POrdenTrabajoSICYID = value
        End Set
    End Property

    Private PCliente As String
    Public Property Cliente() As String
        Get
            Return PCliente
        End Get
        Set(ByVal value As String)
            PCliente = value
        End Set
    End Property

    Private PAgente As String
    Public Property Agente() As String
        Get
            Return PAgente
        End Get
        Set(ByVal value As String)
            PAgente = value
        End Set
    End Property

    Private PTransporte As String
    Public Property Transporte() As String
        Get
            Return PTransporte
        End Get
        Set(ByVal value As String)
            PTransporte = value
        End Set
    End Property

    Private PEmpaque As String
    Public Property Empaque() As String
        Get
            Return PEmpaque
        End Get
        Set(ByVal value As String)
            PEmpaque = value
        End Set
    End Property

    Private PTotalEnviar As Integer
    Public Property TotalEnviar() As Integer
        Get
            Return PTotalEnviar
        End Get
        Set(ByVal value As Integer)
            PTotalEnviar = value
        End Set
    End Property

    Private PCita As String
    Public Property Cita() As String
        Get
            Return PCita
        End Get
        Set(ByVal value As String)
            PCita = value
        End Set
    End Property

    Private PHoraCita As String
    Public Property HoraCita() As String
        Get
            Return PHoraCita
        End Get
        Set(ByVal value As String)
            PHoraCita = value
        End Set
    End Property

    Private PConfirmacion As String
    Public Property Confirmacion() As String
        Get
            Return PConfirmacion
        End Get
        Set(ByVal value As String)
            PConfirmacion = value
        End Set
    End Property

    Private PObservaciones As String
    Public Property Observaciones() As String
        Get
            Return PObservaciones
        End Get
        Set(ByVal value As String)
            PObservaciones = value
        End Set
    End Property

    Private PTipoEmpaque As String
    Public Property TipoEmpaque() As String
        Get
            Return PTipoEmpaque
        End Get
        Set(ByVal value As String)
            PTipoEmpaque = value
        End Set
    End Property

    Private PFechaEntrega As String
    Public Property FechaEntrega() As String
        Get
            Return PFechaEntrega
        End Get
        Set(ByVal value As String)
            PFechaEntrega = value
        End Set
    End Property

    Private PAtnClientes As String
    Public Property AtnClientes() As String
        Get
            Return PAtnClientes
        End Get
        Set(ByVal value As String)
            PAtnClientes = value
        End Set
    End Property

    Private PFechaCreacion As String
    Public Property FechaCreacion() As String
        Get
            Return PFechaCreacion
        End Get
        Set(ByVal value As String)
            PFechaCreacion = value
        End Set
    End Property

    Private PEntregarPedido As String
    Public Property EntregarPedido() As String
        Get
            Return PEntregarPedido
        End Get
        Set(ByVal value As String)
            PEntregarPedido = value
        End Set
    End Property

    Private PFacturarPor As String
    Public Property FacturarPor() As String
        Get
            Return PFacturarPor
        End Get
        Set(ByVal value As String)
            PFacturarPor = value
        End Set
    End Property

    Private PImporteMaxVta As String
    Public Property ImporteMaxVta() As String
        Get
            Return PImporteMaxVta
        End Get
        Set(ByVal value As String)
            PImporteMaxVta = value
        End Set
    End Property

    Private PPorcentajeFacturacion As String
    Public Property PorcentajeFacturacion() As String
        Get
            Return PPorcentajeFacturacion
        End Get
        Set(ByVal value As String)
            PPorcentajeFacturacion = value
        End Set
    End Property

    Private PNotasVentas As String
    Public Property NotasVentas() As String
        Get
            Return PNotasVentas
        End Get
        Set(ByVal value As String)
            PNotasVentas = value
        End Set
    End Property

    Private PNotasEmpaque As String
    Public Property NotasEmpaque() As String
        Get
            Return PNotasEmpaque
        End Get
        Set(ByVal value As String)
            PNotasEmpaque = value
        End Set
    End Property

    Private PEmbarqueEntregarEn As String
    Public Property EmbarqueEntregarEn() As String
        Get
            Return PEmbarqueEntregarEn
        End Get
        Set(ByVal value As String)
            PEmbarqueEntregarEn = value
        End Set
    End Property

    Private PEmbarqueDireccion As String
    Public Property EmbarqueDireccion() As String
        Get
            Return PEmbarqueDireccion
        End Get
        Set(ByVal value As String)
            PEmbarqueDireccion = value
        End Set
    End Property

    Private PEmbarqueColonia As String
    Public Property EmbarqueColonia() As String
        Get
            Return PEmbarqueColonia
        End Get
        Set(ByVal value As String)
            PEmbarqueColonia = value
        End Set
    End Property

    Private PEmbarqueCiudad As String
    Public Property EmbarqueCiudad() As String
        Get
            Return PEmbarqueCiudad
        End Get
        Set(ByVal value As String)
            PEmbarqueCiudad = value
        End Set
    End Property


    Private PEmbarqueEstado As String
    Public Property EmbarqueEstado() As String
        Get
            Return PEmbarqueEstado
        End Get
        Set(ByVal value As String)
            PEmbarqueEstado = value
        End Set
    End Property

    Private PEmbarqueCP As String
    Public Property EmbarqueCP() As String
        Get
            Return PEmbarqueCP
        End Get
        Set(ByVal value As String)
            PEmbarqueCP = value
        End Set
    End Property

    Private PEmbarqueConvenio As String
    Public Property EmbarqueConvenio() As String
        Get
            Return PEmbarqueConvenio
        End Get
        Set(ByVal value As String)
            PEmbarqueConvenio = value
        End Set
    End Property

    Private PEmbarqueContactoRampa As String
    Public Property EmbarqueContactoRampa() As String
        Get
            Return PEmbarqueContactoRampa
        End Get
        Set(ByVal value As String)
            PEmbarqueContactoRampa = value
        End Set
    End Property

    Private PEmbarqueNotas As String
    Public Property EmbarqueNotas() As String
        Get
            Return PEmbarqueNotas
        End Get
        Set(ByVal value As String)
            PEmbarqueNotas = value
        End Set
    End Property

    Private PUsuarioImprimio As String
    Public Property UsuarioImprimio() As String
        Get
            Return PUsuarioImprimio
        End Get
        Set(ByVal value As String)
            PUsuarioImprimio = value
        End Set
    End Property

    Private PFechaImpresion As String
    Public Property FechaImpresion() As String
        Get
            Return PFechaImpresion
        End Get
        Set(ByVal value As String)
            PFechaImpresion = value
        End Set
    End Property


    Private PUbicacionOT As String
    Public Property UbicacionOT() As String
        Get
            Return PUbicacionOT
        End Get
        Set(ByVal value As String)
            PUbicacionOT = value
        End Set
    End Property

    Private PVenta As String
    Public Property Venta() As String
        Get
            Return PVenta
        End Get
        Set(ByVal value As String)
            PVenta = value
        End Set
    End Property


    Private PDiasEntrega As String
    Public Property DiasEntrega() As String
        Get
            Return PDiasEntrega
        End Get
        Set(ByVal value As String)
            PDiasEntrega = value
        End Set
    End Property

    Private PDomicilioTiendas As List(Of OrdenTrabajoDireccionEntrega)
    Public Property DomicilioTiendas() As List(Of OrdenTrabajoDireccionEntrega)
        Get
            Return PDomicilioTiendas
        End Get
        Set(ByVal value As List(Of OrdenTrabajoDireccionEntrega))
            PDomicilioTiendas = value
        End Set
    End Property

    Sub New()
        DomicilioTiendas = New List(Of OrdenTrabajoDireccionEntrega)
    End Sub

    Private PPedidoSICY As String
    Public Property PedidoSICY() As String
        Get
            Return PPedidoSICY
        End Get
        Set(ByVal value As String)
            PPedidoSICY = value
        End Set
    End Property

    Private PPedidoSAY As String
    Public Property PedidoSAY() As String
        Get
            Return PPedidoSAY
        End Get
        Set(ByVal value As String)
            PPedidoSAY = value
        End Set
    End Property


    Private PTienda As String
    Public Property Tienda() As String
        Get
            Return PTienda
        End Get
        Set(ByVal value As String)
            PTienda = value
        End Set
    End Property

    Private PRFC As String
    Public Property RFC() As String
        Get
            Return PRFC
        End Get
        Set(ByVal value As String)
            PRFC = value
        End Set
    End Property

    Private PObservacionesPedido As String
    Public Property ObservacionesPedido() As String
        Get
            Return PObservacionesPedido
        End Get
        Set(ByVal value As String)
            PObservacionesPedido = value
        End Set
    End Property

    Private PHorariosRecibo As String
    Public Property HorariosRecibo() As String
        Get
            Return PHorariosRecibo
        End Get
        Set(ByVal value As String)
            PHorariosRecibo = value
        End Set
    End Property

    Private PIDEmbarque As String
    Public Property IDEmbarque() As String
        Get
            Return PIDEmbarque
        End Get
        Set(ByVal value As String)
            PIDEmbarque = value
        End Set
    End Property

    Private PIdRazonSocial As String
    Public Property IdRazonSocial() As String
        Get
            Return PIdRazonSocial
        End Get
        Set(ByVal value As String)
            PIdRazonSocial = value
        End Set
    End Property


    Private PRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return PRazonSocial
        End Get
        Set(ByVal value As String)
            PRazonSocial = value
        End Set
    End Property

    Private PNumeroPersonas As String
    Public Property NumeroPersonas() As String
        Get
            Return PNumeroPersonas
        End Get
        Set(ByVal value As String)
            PNumeroPersonas = value
        End Set
    End Property


    Private PIDSAY As String
    Public Property IDSAY() As String
        Get
            Return PIDSAY
        End Get
        Set(ByVal value As String)
            PIDSAY = value
        End Set
    End Property

    Private PRFCSAY As String
    Public Property RFCSAY() As String
        Get
            Return PRFCSAY
        End Get
        Set(ByVal value As String)
            PRFCSAY = value
        End Set
    End Property

    Private PRazonSocialSAY As String
    Public Property RazonSocialSAY() As String
        Get
            Return PRazonSocialSAY
        End Get
        Set(ByVal value As String)
            PRazonSocialSAY = value
        End Set
    End Property

    Private PLlevaCopiaPedido As String
    Public Property LlevaCopiaPedido() As String
        Get
            Return PLlevaCopiaPedido
        End Get
        Set(ByVal value As String)
            PLlevaCopiaPedido = value
        End Set
    End Property

End Class
