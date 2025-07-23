Public Class CodigosErroneos

    Private PFolioSalidaID As Integer
    Private PAtado As String
    Private PCodigoLeido As String
    Private PProceso As String
    Private PDescripcionError As String
    Private PLote As Integer
    Private PAño As Integer
    Private PNaveSICYID As Integer
    Private PUsuarioID As Integer
    Private PUsuario As String
    Private PClienteSICYID As Integer
    Private PFecha As Date

    Public Property Atado As String
        Get
            Return PAtado
        End Get
        Set(value As String)
            PAtado = value
        End Set
    End Property

    Public Property CodigoLeido As String
        Get
            Return PCodigoLeido
        End Get
        Set(value As String)
            PCodigoLeido = value
        End Set
    End Property

    Public Property Proceso As String
        Get
            Return PProceso
        End Get
        Set(value As String)
            PProceso = value
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

    Public Property UsuarioID As Integer
        Get
            Return PUsuarioID
        End Get
        Set(value As Integer)
            PUsuarioID = value
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

    Public Property DescripcionError As String
        Get
            Return PDescripcionError
        End Get
        Set(value As String)
            PDescripcionError = value
        End Set
    End Property

    Public Property FolioSalidaID As Integer
        Get
            Return PFolioSalidaID
        End Get
        Set(value As Integer)
            PFolioSalidaID = value
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
    Public Property ClienteSICYID As Integer
        Get
            Return PClienteSICYID
        End Get
        Set(value As Integer)
            PClienteSICYID = value
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

End Class
