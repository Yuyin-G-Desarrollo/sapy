Public Class Subfamilias
    Private SIdSuabfamilia As Int32
    Private SDescripcion As String
    Private SCodigo As String
    Private SActivo As Boolean

    Public Property PIdSubfamilia As Int32
        Get
            Return SIdSuabfamilia
        End Get
        Set(ByVal value As Int32)
            SIdSuabfamilia = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return SDescripcion
        End Get
        Set(ByVal value As String)
            SDescripcion = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return SActivo
        End Get
        Set(ByVal value As Boolean)
            SActivo = value
        End Set
    End Property

End Class
