Public Class Suelas

    Private IdSuela As String
    Private CodigoSuela As String
    Private DescripcionSuela As String
    Private ActivoSuela As String

    Property PIdSuela As String
        Get
            Return IdSuela
        End Get
        Set(ByVal value As String)
            IdSuela = value
        End Set
    End Property

    Property PCodigoSuela As String
        Get
            Return CodigoSuela
        End Get
        Set(ByVal value As String)
            CodigoSuela = value
        End Set
    End Property

    Property PDescriopcionSuela As String
        Get
            Return DescripcionSuela
        End Get
        Set(ByVal value As String)
            DescripcionSuela = value
        End Set
    End Property

    Public Property PActivoSuela As String
        Get
            Return ActivoSuela
        End Get
        Set(ByVal value As String)
            ActivoSuela = value
        End Set
    End Property


End Class
