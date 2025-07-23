
Public Class CatalogoCondicionesCondicion
    Private IdCondicion As Int32
    Private Nombre As String
    Private IdTipoCondicion As Integer
    Private Activo As Boolean

    Public Property PIdCondicion As Integer
        Get
            Return IdCondicion
        End Get
        Set(value As Integer)
            IdCondicion = value
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

    Public Property PIdTipo As Integer
        Get
            Return IdTipoCondicion
        End Get
        Set(value As Integer)
            IdTipoCondicion = value
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
