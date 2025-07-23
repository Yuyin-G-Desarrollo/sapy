Public Class CatalogoRutas

    Private RutaId As Int32
    Private NombreRuta As String
    Private Activo As Boolean

    Public Property PRutaId As Integer
        Get
            Return RutaId
        End Get
        Set(value As Integer)
            RutaId = value
        End Set
    End Property

    Public Property PNombreRuta As String
        Get
            Return NombreRuta
        End Get
        Set(value As String)
            NombreRuta = value
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
