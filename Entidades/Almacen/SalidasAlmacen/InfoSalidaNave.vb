Public Class InfoSalidaNave

    Dim PIdSalidaNave As Integer = 0
    Dim PFolioCompleto As Boolean = False
    Dim PNaveSICYID As Integer = 0
    Dim PLotesFolio As New List(Of InformacionLoteSalidaNave)
    Dim PAtados As New List(Of CapturaAtadoValido)
    Dim PPares As New List(Of CapturaParValido)
    Dim PCodigosErroneos As New List(Of CodigosErroneos)
    Dim PConfiguracionNave As New Entidades.ConfiguracionNaveSalida
    Private PTipoProceso As String
    Private PStatusFolioID As Integer
    Private PListaPlataformas As New List(Of PlataformaEntrada)

    Public Property ListaPlataformas() As List(Of PlataformaEntrada)
        Get
            Return PListaPlataformas
        End Get
        Set(ByVal value As List(Of PlataformaEntrada))
            PListaPlataformas = value
        End Set
    End Property


    Public Property StatusFolioID() As Integer
        Get
            Return PStatusFolioID
        End Get
        Set(ByVal value As Integer)
            PStatusFolioID = value
        End Set
    End Property

    Public Property TipoProceso() As String
        Get
            Return PTipoProceso
        End Get
        Set(ByVal value As String)
            PTipoProceso = value
        End Set
    End Property

    Public Property ConfiguracionNave() As Entidades.ConfiguracionNaveSalida
        Get
            Return PConfiguracionNave
        End Get
        Set(ByVal value As Entidades.ConfiguracionNaveSalida)
            PConfiguracionNave = value
        End Set
    End Property

    Public Property CodigosErroneos() As List(Of CodigosErroneos)
        Get
            Return PCodigosErroneos
        End Get
        Set(ByVal value As List(Of CodigosErroneos))
            PCodigosErroneos = value
        End Set
    End Property

    Public Property Pares() As List(Of CapturaParValido)
        Get
            Return PPares
        End Get
        Set(ByVal value As List(Of CapturaParValido))
            PPares = value
        End Set
    End Property

    Public Property Atados() As List(Of CapturaAtadoValido)
        Get
            Return PAtados
        End Get
        Set(ByVal value As List(Of CapturaAtadoValido))
            PAtados = value
        End Set
    End Property

    Public Property IdSalidaNave() As Integer
        Get
            Return PIdSalidaNave
        End Get
        Set(ByVal value As Integer)
            PIdSalidaNave = value
        End Set
    End Property

    Public Property NaveSICYID() As Integer
        Get
            Return PNaveSICYID
        End Get
        Set(ByVal value As Integer)
            PNaveSICYID = value
        End Set
    End Property

    Public Property FolioCompleto() As Boolean
        Get
            Return PFolioCompleto
        End Get
        Set(ByVal value As Boolean)
            PFolioCompleto = value
        End Set
    End Property

    Public Property LotesFolio() As List(Of InformacionLoteSalidaNave)
        Get
            Return PLotesFolio
        End Get
        Set(ByVal value As List(Of InformacionLoteSalidaNave))
            PLotesFolio = value
        End Set
    End Property


End Class
