
Public Class ProductoEstilo


    Private PProductoEstiloId As Integer
    Private PPiel As String
    Private PColeccionSAY As String
    Private PMarcaSAY As String
    Private PModeloSICY As String
    Private PModeloSAY As String
    Private PFamilia As String
    Private PDescripcionCompleta As String
    Private PTallaID As Integer
    Private PTalla As String
    Private PColor As String
    Private PPielColor As String
    Private PTemporada As String
    Private PCodigoSICY As String

    Public Property CodigoSICY() As String
        Get
            Return PCodigoSICY
        End Get
        Set(ByVal value As String)
            PCodigoSICY = value
        End Set
    End Property

    Public Property ModeloSICY() As String
        Get
            Return PModeloSICY
        End Get
        Set(ByVal value As String)
            PModeloSICY = value
        End Set
    End Property

    Public Property ProductoEstiloId() As Integer
        Get
            Return PProductoEstiloId
        End Get
        Set(ByVal value As Integer)
            PProductoEstiloId = value
        End Set
    End Property

    Public Property Piel() As String
        Get
            Return PPiel
        End Get
        Set(ByVal value As String)
            PPiel = value
        End Set
    End Property

    Public Property ColeccionSAY() As String
        Get
            Return PColeccionSAY
        End Get
        Set(ByVal value As String)
            PColeccionSAY = value
        End Set
    End Property

    Public Property MarcaSAY() As String
        Get
            Return PMarcaSAY
        End Get
        Set(ByVal value As String)
            PMarcaSAY = value
        End Set
    End Property

    Public Property ModeloSAY() As String
        Get
            Return PModeloSAY
        End Get
        Set(ByVal value As String)
            PModeloSAY = value
        End Set
    End Property

    Public Property Familia() As String
        Get
            Return PFamilia
        End Get
        Set(ByVal value As String)
            PFamilia = value
        End Set
    End Property

    Public Property DescripcionCompleta() As String
        Get
            Return PDescripcionCompleta
        End Get
        Set(ByVal value As String)
            PDescripcionCompleta = value
        End Set
    End Property

    Public Property TallaID() As Integer
        Get
            Return PTallaID
        End Get
        Set(ByVal value As Integer)
            PTallaID = value
        End Set
    End Property

    Public Property Talla() As String
        Get
            Return PTalla
        End Get
        Set(ByVal value As String)
            PTalla = value
        End Set
    End Property

    Public Property Color() As String
        Get
            Return PColor
        End Get
        Set(ByVal value As String)
            PColor = value
        End Set
    End Property

    Public Property PielColor() As String
        Get
            Return PPielColor
        End Get
        Set(ByVal value As String)
            PPielColor = value
        End Set
    End Property

    Public Property Temporada() As String
        Get
            Return PTemporada
        End Get
        Set(ByVal value As String)
            PTemporada = value
        End Set
    End Property

End Class
