Public Class DatosFactura

    Private PDocumentoID As Int32
    Public Property DocumentoID() As Int32
        Get
            Return PDocumentoID
        End Get
        Set(ByVal value As Int32)
            PDocumentoID = value
        End Set
    End Property

    Private PRutaXML As String
    Public Property RutaXML() As String
        Get
            Return PRutaXML
        End Get
        Set(ByVal value As String)
            PRutaXML = value
        End Set
    End Property

    Private PRutaPDF As String
    Public Property RutaPDF() As String
        Get
            Return PRutaPDF
        End Get
        Set(ByVal value As String)
            PRutaPDF = value
        End Set
    End Property


    Private PRemisionID As Integer
    Public Property RemisionID() As Integer
        Get
            Return PRemisionID
        End Get
        Set(ByVal value As Integer)
            PRemisionID = value
        End Set
    End Property

    Private PAño As Integer
    Public Property Año() As Integer
        Get
            Return PAño
        End Get
        Set(ByVal value As Integer)
            PAño = value
        End Set
    End Property


    Private PFolioFactura As String
    Public Property FolioFactura() As String
        Get
            Return PFolioFactura
        End Get
        Set(ByVal value As String)
            PFolioFactura = value
        End Set
    End Property

    Private PSerieFactura As String
    Public Property SerieFactura() As String
        Get
            Return PSerieFactura
        End Get
        Set(ByVal value As String)
            PSerieFactura = value
        End Set
    End Property

    Private PUUID As String
    Public Property UUID() As String
        Get
            Return PUUID
        End Get
        Set(ByVal value As String)
            PUUID = value
        End Set
    End Property

    Private PTipoComprobante As String
    Public Property TipoComprobante() As String
        Get
            Return PTipoComprobante
        End Get
        Set(ByVal value As String)
            PTipoComprobante = value
        End Set
    End Property

End Class
