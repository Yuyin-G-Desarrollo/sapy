Public Class CatalogoRequerimientosEspeciales

    Private IdRequerimiento As Int32
    Private Nombre As String
    Private activo As Boolean
    Private Tipo As String
    Private IdTipo As Int32

    Public Property PIdRequerimiento As Integer
        Get
            Return IdRequerimiento
        End Get
        Set(value As Integer)
            IdRequerimiento = value
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

    Public Property PActivo As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

    Public Property PTipo As String
        Get
            Return Tipo
        End Get
        Set(value As String)
            Tipo = value
        End Set
    End Property

    Public Property PIdTipo As Integer
        Get
            Return IdTipo
        End Get
        Set(value As Integer)
            IdTipo = value
        End Set
    End Property


End Class
