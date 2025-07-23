Public Class CatalogoTiposDeTienda

    Private IdTipoTienda As Int32
    Private NombreTipoTienda As String
    Private Activo As Boolean

    Public Property PIdTipoTienda As Integer
        Get
            Return IdTipoTienda
        End Get
        Set(value As Integer)
            IdTipoTienda = value
        End Set
    End Property

    Public Property PNombreTipoTienda As String
        Get
            Return NombreTipoTienda
        End Get
        Set(value As String)
            NombreTipoTienda = value
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
