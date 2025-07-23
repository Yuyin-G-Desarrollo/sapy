Public Class ColaboradorExpediente

    Private ColaboradorID As Int32
    Private Carpeta As String
    Private NombreArchivo As String
    Private Titulo As String
    Private FechaCreacion As Date
    Private Credencial As Boolean
    Private ArchivoId As Int32

    Public Property PColaboradorID As Int32
        Get
            Return ColaboradorID
        End Get
        Set(ByVal value As Int32)
            ColaboradorID = value
        End Set
    End Property

    Public Property PCarpeta As String
        Get
            Return Carpeta
        End Get
        Set(ByVal value As String)
            Carpeta = value
        End Set
    End Property

    Public Property PNombreArchivo As String
        Get
            Return NombreArchivo
        End Get
        Set(ByVal value As String)
            NombreArchivo = value
        End Set
    End Property

    Public Property Ptitulo As String
        Get
            Return Titulo
        End Get
        Set(ByVal value As String)
            Titulo = value
        End Set
    End Property

    Public Property PFechaCreacion As Date
        Get
            Return FechaCreacion
        End Get
        Set(ByVal value As Date)
            FechaCreacion = value
        End Set
    End Property

    Public Property PCredencial As Boolean
        Get
            Return Credencial
        End Get
        Set(ByVal value As Boolean)
            Credencial = value
        End Set
    End Property

    Public Property PArchivoId As Int32
        Get
            Return ArchivoId
        End Get
        Set(ByVal value As Int32)
            ArchivoId = value
        End Set
    End Property
End Class
