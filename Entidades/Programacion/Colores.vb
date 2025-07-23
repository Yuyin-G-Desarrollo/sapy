Public Class Colores
    Private colorId As Int32
    Private colorDescripcion As String
    Private colorActivo As Boolean
    Private colorCodSicy As String

    Public Property PColorId As Int32
        Get
            Return colorId
        End Get
        Set(ByVal value As Int32)
            colorId = value
        End Set
    End Property

    Public Property PCDescripcion As String
        Get
            Return colorDescripcion
        End Get
        Set(ByVal value As String)
            colorDescripcion = value
        End Set
    End Property

    Public Property PCActivo As Boolean
        Get
            Return colorActivo
        End Get
        Set(ByVal value As Boolean)
            colorActivo = value
        End Set
    End Property

    Public Property PCCodSicy As String
        Get
            Return colorCodSicy
        End Get
        Set(ByVal value As String)
            colorCodSicy = value
        End Set
    End Property

End Class
