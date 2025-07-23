Public Class FiltrosAdministradorSoliciturCancelacion
    Private PtipoFecha As Integer
    Private PfechaInicio As String
    Private PfechaFin As String
    Private PstatusID As String
    Private PfacturaID As String
    Private PfolioFacturaID As String
    Private Pclienteid As String
    Private PemisorID As String
    Private PreceptorID As String
    Private PmotivoInterno As String
    Private PsolicitaInterno As String
    Private PsolicitaExterno As String
    Private PcedisId As String

    Public Property TipoFecha() As Integer
        Get
            Return PtipoFecha
        End Get
        Set(value As Integer)
            PtipoFecha = value
        End Set
    End Property

    Public Property FechaInicio As String
        Get
            Return PfechaInicio
        End Get
        Set(value As String)
            PfechaInicio = value
        End Set
    End Property

    Public Property FechaFin As String
        Get
            Return PfechaFin
        End Get
        Set(value As String)
            PfechaFin = value
        End Set
    End Property

    Public Property StatusID As String
        Get
            Return PstatusID
        End Get
        Set(value As String)
            PstatusID = value
        End Set
    End Property


    Public Property Clienteid As String
        Get
            Return Pclienteid
        End Get
        Set(value As String)
            Pclienteid = value
        End Set
    End Property

    Public Property EmisorID As String
        Get
            Return PemisorID
        End Get
        Set(value As String)
            PemisorID = value
        End Set
    End Property

    Public Property ReceptorID As String
        Get
            Return PreceptorID
        End Get
        Set(value As String)
            PreceptorID = value
        End Set
    End Property

    Public Property MotivoInterno As String
        Get
            Return PmotivoInterno
        End Get
        Set(value As String)
            PmotivoInterno = value
        End Set
    End Property



    Public Property CedisId As String
        Get
            Return PcedisId
        End Get
        Set(value As String)
            PcedisId = value
        End Set
    End Property

    Public Property SolicitaInterno As String
        Get
            Return PsolicitaInterno
        End Get
        Set(value As String)
            PsolicitaInterno = value
        End Set
    End Property

    Public Property SolicitaExterno As String
        Get
            Return PsolicitaExterno
        End Get
        Set(value As String)
            PsolicitaExterno = value
        End Set
    End Property

    Public Property FacturaID As String
        Get
            Return PfacturaID
        End Get
        Set(value As String)
            PfacturaID = value
        End Set
    End Property

    Public Property FolioFacturaID As String
        Get
            Return PfolioFacturaID
        End Get
        Set(value As String)
            PfolioFacturaID = value
        End Set
    End Property
End Class
