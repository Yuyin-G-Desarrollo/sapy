Public Class CapturaParValido

    Private PAtado As String
    Private PPar As String
    Private PStatus As String
    Private PFecha As Date
    Private PUsuario As String
    Private PUsuarioID As Integer
    Private PNaveSICYID As Integer
    Private PLote As Integer
    Private PAño As Integer
    Private PClienteSICYID As Integer
    Private PCodigoPorLeer As String
    Private PNombreEstatus As String
    Private PDescripcionCompleta As String
    Private PEtiquetaEspecial As Integer
    Private PCartaInformativa As Integer

    Public Property EtiquetaEspecial As Integer
        Get
            Return PEtiquetaEspecial
        End Get
        Set(value As Integer)
            PEtiquetaEspecial = value
        End Set
    End Property

    Public Property CartaInformativa As Integer
        Get
            Return PCartaInformativa
        End Get
        Set(value As Integer)
            PCartaInformativa = value
        End Set
    End Property

    Public Property Atado As String
        Get
            Return PAtado
        End Get
        Set(value As String)
            PAtado = value
        End Set
    End Property

    Public Property Par As String
        Get
            Return PPar
        End Get
        Set(value As String)
            PPar = value
        End Set
    End Property


    Public Property CodigoPorLeer As String
        Get
            Return PCodigoPorLeer
        End Get
        Set(value As String)
            PCodigoPorLeer = value
        End Set
    End Property
    Public Property DescripcionCompleta As String
        Get
            Return PDescripcionCompleta
        End Get
        Set(value As String)
            PDescripcionCompleta = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return PStatus
        End Get
        Set(value As String)
            PStatus = value
        End Set
    End Property

    Public Property NombreEstatus As String
        Get
            Return PNombreEstatus
        End Get
        Set(value As String)
            PNombreEstatus = value
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return PFecha
        End Get
        Set(value As Date)
            PFecha = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return PUsuario
        End Get
        Set(value As String)
            PUsuario = value
        End Set
    End Property

    Public Property UsuarioID As Integer
        Get
            Return PUsuarioID
        End Get
        Set(value As Integer)
            PUsuarioID = value
        End Set
    End Property

    Public Property NaveSICYID As Integer
        Get
            Return PNaveSICYID
        End Get
        Set(value As Integer)
            PNaveSICYID = value
        End Set
    End Property
    Public Property Lote As Integer
        Get
            Return PLote
        End Get
        Set(value As Integer)
            PLote = value
        End Set
    End Property

    Public Property Año As Integer
        Get
            Return PAño
        End Get
        Set(value As Integer)
            PAño = value
        End Set
    End Property

    Public Property ClienteSICYID As Integer
        Get
            Return PClienteSICYID
        End Get
        Set(value As Integer)
            PClienteSICYID = value
        End Set
    End Property
End Class
