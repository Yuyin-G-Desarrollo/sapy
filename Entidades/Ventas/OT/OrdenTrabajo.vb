

Public Class OrdenTrabajo

    Private POrdenTrabajoID As Integer
    Public Property OrdenTrabajoID() As Integer
        Get
            Return POrdenTrabajoID
        End Get
        Set(ByVal value As Integer)
            POrdenTrabajoID = value
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

    Private PClienteSAYID As Integer
    Public Property ClienteSAYID() As Integer
        Get
            Return PClienteSAYID
        End Get
        Set(ByVal value As Integer)
            PClienteSAYID = value
        End Set
    End Property

    Private PPedidoSAYID As Integer
    Public Property PedidoSAYID() As Integer
        Get
            Return PPedidoSAYID
        End Get
        Set(ByVal value As Integer)
            PPedidoSAYID = value
        End Set
    End Property

    Private PPedidoSICYID As Integer
    Public Property PedidoSICYID() As Integer
        Get
            Return PPedidoSICYID
        End Get
        Set(ByVal value As Integer)
            PPedidoSICYID = value
        End Set
    End Property

    Private PParesErroneos As Integer
    Public Property ParesErroneos() As Integer
        Get
            Return PParesErroneos
        End Get
        Set(ByVal value As Integer)
            PParesErroneos = value
        End Set
    End Property

    Private PParesCorregidos As Integer
    Public Property ParesCorregidos() As Integer
        Get
            Return PParesCorregidos
        End Get
        Set(ByVal value As Integer)
            PParesCorregidos = value
        End Set
    End Property


    Private PFechaCaptura As Date
    Public Property FechaCaptura() As Date
        Get
            Return PFechaCaptura
        End Get
        Set(ByVal value As Date)
            PFechaCaptura = value
        End Set
    End Property

    Private PTipoOT As String
    Public Property TipoOT() As String
        Get
            Return PTipoOT
        End Get
        Set(ByVal value As String)
            PTipoOT = value
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


    Private PEstatusID As Integer
    Public Property EstatusID() As Integer
        Get
            Return PEstatusID
        End Get
        Set(ByVal value As Integer)
            PEstatusID = value
        End Set
    End Property

    Private PEstatus As String
    Public Property Estatus() As String
        Get
            Return PEstatus
        End Get
        Set(ByVal value As String)
            PEstatus = value
        End Set
    End Property

    Private PTotalPares As Integer
    Public Property TotalPares() As Integer
        Get
            Return PTotalPares
        End Get
        Set(ByVal value As Integer)
            PTotalPares = value
        End Set
    End Property

    Private PTotalParesConfirmados As Integer
    Public Property TotalParesConfirmados() As Integer
        Get
            Return PTotalParesConfirmados
        End Get
        Set(ByVal value As Integer)
            PTotalParesConfirmados = value
        End Set
    End Property

    Private PTotalParesCancelados As Integer
    Public Property TotalParesCancelados() As Integer
        Get
            Return PTotalParesCancelados
        End Get
        Set(ByVal value As Integer)
            PTotalParesCancelados = value
        End Set
    End Property

    Private PTotalParesPorConfirmar As Integer
    Public Property TotalParesPorConfirmar() As Integer
        Get
            Return PTotalParesPorConfirmar
        End Get
        Set(ByVal value As Integer)
            PTotalParesPorConfirmar = value
        End Set
    End Property
    
    Private PTotalParesIncidencias As Integer
    Public Property TotalParesIncidencias() As Integer
        Get
            Return PTotalParesIncidencias
        End Get
        Set(ByVal value As Integer)
            PTotalParesIncidencias = value
        End Set
    End Property

    Private POrdenCliente As String
    Public Property OrdenCliente() As String
        Get
            Return POrdenCliente
        End Get
        Set(ByVal value As String)
            POrdenCliente = value
        End Set
    End Property

    Private PFechaPreparacion As Date
    Public Property FechaPreparacion() As Date
        Get
            Return PFechaPreparacion
        End Get
        Set(ByVal value As Date)
            PFechaPreparacion = value
        End Set
    End Property

    Private PFacturacionAnticipada As Boolean
    Public Property FacturacionAnticipada() As Boolean
        Get
            Return PFacturacionAnticipada
        End Get
        Set(ByVal value As Boolean)
            PFacturacionAnticipada = value
        End Set
    End Property

End Class
