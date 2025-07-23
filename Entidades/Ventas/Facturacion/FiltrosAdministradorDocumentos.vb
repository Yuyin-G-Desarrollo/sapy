Public Class FiltrosAdministradorDocumentos

    Private PTipoFecha As Integer

    Public Property TipoFecha() As Integer
        Get
            Return PTipoFecha
        End Get
        Set(ByVal value As Integer)
            PTipoFecha = value
        End Set
    End Property

    Private PFechaInicio As String

    Public Property FechaInicio() As String
        Get
            Return PFechaInicio
        End Get
        Set(ByVal value As String)
            PFechaInicio = value
        End Set
    End Property

    Private PFechaTermino As String

    Public Property FechaTermino() As String
        Get
            Return PFechaTermino
        End Get
        Set(ByVal value As String)
            PFechaTermino = value
        End Set
    End Property

    Private PStatusID As String

    Public Property StatusID() As String
        Get
            Return PStatusID
        End Get
        Set(ByVal value As String)
            PStatusID = value
        End Set
    End Property

    Private PDocumentoId As String

    Public Property DocumentoId() As String
        Get
            Return PDocumentoId
        End Get
        Set(ByVal value As String)
            PDocumentoId = value
        End Set
    End Property

    Private PFacturaId As String

    Public Property FacturaId() As String
        Get
            Return PFacturaId
        End Get
        Set(ByVal value As String)
            PFacturaId = value
        End Set
    End Property

    Private PFolioOT As String

    Public Property FolioOT() As String
        Get
            Return PFolioOT
        End Get
        Set(ByVal value As String)
            PFolioOT = value
        End Set
    End Property

    Private PClienteId As String

    Public Property ClienteId() As String
        Get
            Return PClienteId
        End Get
        Set(ByVal value As String)
            PClienteId = value
        End Set
    End Property

    Private PEmisorId As String

    Public Property EmisorId() As String
        Get
            Return PEmisorId
        End Get
        Set(ByVal value As String)
            PEmisorId = value
        End Set
    End Property

    Private PConsultaContabilidad As Integer
    Public Property ConsultaContabilidad() As Integer
        Get
            Return PConsultaContabilidad
        End Get
        Set(ByVal value As Integer)
            PConsultaContabilidad = value
        End Set
    End Property

    Private PUsuarioConsultaId As Integer
    Public Property UsuarioConsultaId() As Integer
        Get
            Return PUsuarioConsultaId
        End Get
        Set(ByVal value As Integer)
            PUsuarioConsultaId = value
        End Set
    End Property

    Private PMostrarOT As Int16
    Public Property MostrarOT() As Int16
        Get
            Return PMostrarOT
        End Get
        Set(ByVal value As Int16)
            PMostrarOT = value
        End Set
    End Property

    Private PCEDISID As Int16
    Public Property CEDISID() As Int16
        Get
            Return PCEDISID
        End Get
        Set(ByVal value As Int16)
            PCEDISID = value
        End Set
    End Property

End Class
