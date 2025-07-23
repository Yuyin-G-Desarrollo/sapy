Public Class ListaColaboradorPorNave

    Private IdColaborador As Integer
    Private ApellidoPaterno As String
    Private ApellidoMaterno As String
    Private Nombre As String

    Public Property PId As Integer
        Get
            Return IdColaborador
        End Get
        Set(value As Integer)
            IdColaborador = value
        End Set
    End Property

    Public Property PAPaterno As String
        Get
            Return ApellidoPaterno
        End Get
        Set(value As String)
            ApellidoPaterno = value
        End Set
    End Property

    Public Property PAMaterno As String
        Get
            Return ApellidoMaterno
        End Get
        Set(value As String)
            ApellidoMaterno = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

End Class
