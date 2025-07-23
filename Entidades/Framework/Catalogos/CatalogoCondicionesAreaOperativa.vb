Public Class CatalogoCondicionesAreaOperativa

    Private IdAreaOperativa As Integer
    Private AreaOperativa As String
    Private Activo As Boolean
    Private Controla As Boolean
    Private IdCondicion As Integer

    Public Property PIdArea As Integer
        Get
            Return IdAreaOperativa
        End Get
        Set(value As Integer)
            IdAreaOperativa = value
        End Set
    End Property

    Public Property PArea As String
        Get
            Return AreaOperativa
        End Get
        Set(value As String)
            AreaOperativa = value
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

    Public Property PControla As Boolean
        Get
            Return Controla
        End Get
        Set(value As Boolean)
            Controla = value
        End Set
    End Property

    Public Property PIdCondicion As Integer
        Get
            Return IdCondicion
        End Get
        Set(value As Integer)
            IdCondicion = value
        End Set
    End Property


End Class
