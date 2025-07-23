Public Class CatalogoRamos

    Private RamoId As Int32
    Private RamoNombre As String
    Private RamoNombreCorto As String
    Private RamoActivo As Boolean

    Public Property PRamoId As Integer
        Get
            Return RamoId
        End Get
        Set(value As Integer)
            RamoId = value
        End Set
    End Property

    Public Property PRamoNombre As String
        Get
            Return RamoNombre
        End Get
        Set(value As String)
            RamoNombre = value
        End Set
    End Property

    Public Property PRamoNombreCorto As String
        Get
            Return RamoNombreCorto
        End Get
        Set(value As String)
            RamoNombreCorto = value
        End Set
    End Property

    Public Property PRamoActivo As Boolean
        Get
            Return RamoActivo
        End Get
        Set(value As Boolean)
            RamoActivo = value
        End Set
    End Property

    Private RamoSicyID As Integer
    Public Property PRamoSicyID() As Integer
        Get
            Return RamoSicyID
        End Get
        Set(ByVal value As Integer)
            RamoSicyID = value
        End Set
    End Property

End Class
