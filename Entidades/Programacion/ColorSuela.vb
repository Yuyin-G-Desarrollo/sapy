Public Class ColorSuela

    Private colorSuelaId As String
    Private nombreColor As String
    Private activo As String
    Property PColorSuelaId As String
        Get
            Return colorSuelaId
        End Get
        Set(ByVal value As String)
            colorSuelaId = value
        End Set
    End Property

    Public Property PNombreColor() As String
        Get
            Return nombreColor
        End Get
        Set(ByVal value As String)
            nombreColor = value
        End Set
    End Property

    Public Property PActivo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property


End Class
