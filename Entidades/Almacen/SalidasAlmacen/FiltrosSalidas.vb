Public Class FiltrosSalidas
    Private TipoConsulta As Integer 'Pantalla desde la que se esta generando la consulta: 1- Generación de embarques  2-Consulta de embarques y entregas
    Private Agrupamiento As Integer
    Private SepararTienda As Integer
    Private Status As String
    Private PrimeraFechaDel As String
    Private PrimeraFechaAl As String
    Private SegundaFechaDel As String
    Private SegundaFechaAl As String
    Private Cliente As String
    Private FolioEmbarque As String
    Private PedidoSiCY As String
    Private OrdenTrabajo As String
    Private Mensajeria As String
    Private EsYISTI As Boolean
    Private Corridas As String
    Private Cedis As Integer

    Public Property PEsYISTI As Boolean
        Get
            Return EsYISTI
        End Get
        Set(value As Boolean)
            EsYISTI = value
        End Set
    End Property

    Public Property PTipoConsulta As Integer
        Get
            Return TipoConsulta
        End Get
        Set(value As Integer)
            TipoConsulta = value
        End Set
    End Property

    Public Property PAgrupamiento As Integer
        Get
            Return Agrupamiento
        End Get
        Set(value As Integer)
            Agrupamiento = value
        End Set
    End Property

    Public Property PSepararTienda As Integer
        Get
            Return SepararTienda
        End Get
        Set(value As Integer)
            SepararTienda = value
        End Set
    End Property

    Public Property PStatus As String
        Get
            Return Status
        End Get
        Set(value As String)
            Status = value
        End Set
    End Property

    Public Property PPrimeraFechaDel As String
        Get
            Return PrimeraFechaDel
        End Get
        Set(value As String)
            PrimeraFechaDel = value
        End Set
    End Property

    Public Property PPrimeraFechaAl As String
        Get
            Return PrimeraFechaAl
        End Get
        Set(value As String)
            PrimeraFechaAl = value
        End Set
    End Property

    Public Property PSegundaFechaDel As String
        Get
            Return SegundaFechaDel
        End Get
        Set(value As String)
            SegundaFechaDel = value
        End Set
    End Property

    Public Property PSegundaFechaAl As String
        Get
            Return SegundaFechaAl
        End Get
        Set(value As String)
            SegundaFechaAl = value
        End Set
    End Property

    Public Property PCliente As String
        Get
            Return Cliente
        End Get
        Set(value As String)
            Cliente = value
        End Set
    End Property

    Public Property PFolioEmbarque As String
        Get
            Return FolioEmbarque
        End Get
        Set(value As String)
            FolioEmbarque = value
        End Set
    End Property

    Public Property PPedidoSiCY As String
        Get
            Return PedidoSiCY
        End Get
        Set(value As String)
            PedidoSiCY = value
        End Set
    End Property

    Public Property POrdenTrabajo As String
        Get
            Return OrdenTrabajo
        End Get
        Set(value As String)
            OrdenTrabajo = value
        End Set
    End Property

    Public Property PMensajeria As String
        Get
            Return Mensajeria
        End Get
        Set(value As String)
            Mensajeria = value
        End Set
    End Property

    Public Property PCorridas As String
        Get
            Return Corridas
        End Get
        Set(value As String)
            Corridas = value
        End Set
    End Property

    Public Property PCedis As Integer
        Get
            Return Cedis
        End Get
        Set(value As Integer)
            Cedis = value
        End Set
    End Property

End Class
