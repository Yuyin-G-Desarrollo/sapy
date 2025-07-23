Public Class CatalogoClasificacionesCliente

    Private IdClasificacion As String
    Private Nombre As String
    Private Ranking As Int32
    Private Activo As Boolean

    Public Property PIdClasificacion() As String
        Get
            Return IdClasificacion
        End Get
        Set(value As String)
            IdClasificacion = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property PRanking As Integer
        Get
            Return Ranking
        End Get
        Set(value As Integer)
            Ranking = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property


End Class
