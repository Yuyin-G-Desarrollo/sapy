Public Class Categorias
    Private idCategoria As Int32
    Private nombreCategoria As String
    Private activoCategoria As Boolean

    Public Property PidCategoria As Int32
        Get
            Return idCategoria
        End Get
        Set(value As Int32)
            idCategoria = value
        End Set
    End Property

    Public Property PnombreCategoria As String
        Get
            Return nombreCategoria
        End Get
        Set(value As String)
            nombreCategoria = value
        End Set
    End Property

    Public Property PactivoCategoria As Boolean
        Get
            Return activoCategoria
        End Get
        Set(value As Boolean)
            activoCategoria = value
        End Set
    End Property

End Class
