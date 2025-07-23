Public Class Pieles
    Private PielId As Int32
    Private PielCodigo As String
    Private PielDescripcion As String
    Private PielNombreCorto As String
    Private PielActivo As Boolean
    Private PielCodSicy As String

    Public Property PPielId As Int32
        Get
            Return PielId
        End Get
        Set(ByVal value As Int32)
            PielId = value
        End Set
    End Property

    Public Property PPielCodigo As String
        Get
            Return PielCodigo
        End Get
        Set(ByVal value As String)
            PielCodigo = value
        End Set
    End Property

    Public Property PPielDescripcion As String
        Get
            Return PielDescripcion
        End Get
        Set(ByVal value As String)
            PielDescripcion = value
        End Set
    End Property

    Public Property PPNombreCorto As String
        Get
            Return PielNombreCorto
        End Get
        Set(ByVal value As String)
            PielNombreCorto = value
        End Set
    End Property

    Public Property PPActivo As Boolean
        Get
            Return PielActivo
        End Get
        Set(ByVal value As Boolean)
            PielActivo = value
        End Set
    End Property

    Public Property PPCodSicy As String
        Get
            Return PielCodSicy
        End Get
        Set(ByVal value As String)
            PielCodSicy = value
        End Set
    End Property


End Class
