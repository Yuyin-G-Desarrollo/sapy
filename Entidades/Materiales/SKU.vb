Public Class SKU
    Private id_ As String
    Public Property id() As String
        Get
            Return id_
        End Get
        Set(ByVal value As String)
            id_ = value
        End Set
    End Property
    Private sku_ As String
    Public Property sku() As String
        Get
            Return sku_
        End Get
        Set(ByVal value As String)
            sku_ = value
        End Set
    End Property


End Class
