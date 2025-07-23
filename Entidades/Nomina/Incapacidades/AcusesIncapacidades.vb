Public Class AcusesIncapacidades
    Private tipo As String
    Public Property PTipo() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property

    Private rutaArchivo As String
    Public Property PRutaArchivo() As String
        Get
            Return rutaArchivo
        End Get
        Set(ByVal value As String)
            rutaArchivo = value
        End Set
    End Property

    Private nombreArchivo As String
    Public Property PNombreArchivo() As String
        Get
            Return nombreArchivo
        End Get
        Set(ByVal value As String)
            nombreArchivo = value
        End Set
    End Property

    Private carpeta As String
    Public Property PCarpetaArchivo() As String
        Get
            Return carpeta
        End Get
        Set(ByVal value As String)
            carpeta = value
        End Set
    End Property

    Private expedienteId As Integer
    Public Property PExpedienteId() As Integer
        Get
            Return expedienteId
        End Get
        Set(ByVal value As Integer)
            expedienteId = value
        End Set
    End Property

End Class
