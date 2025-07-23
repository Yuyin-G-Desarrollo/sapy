Public Class ListaPrecioProdDetalles
    Private precioId_ As Integer
    Public Property precioId() As Integer
        Get
            Return precioId_
        End Get
        Set(ByVal value As Integer)
            precioId_ = value
        End Set
    End Property

    Private listaid_ As Integer
    Public Property listaId() As Integer
        Get
            Return listaid_
        End Get
        Set(ByVal value As Integer)
            listaid_ = value
        End Set
    End Property

    Private productoId_ As Integer
    Public Property productoId() As Integer
        Get
            Return productoId_
        End Get
        Set(ByVal value As Integer)
            productoId_ = value
        End Set
    End Property
    Private precio_ As Double
    Public Property precio() As Double
        Get
            Return precio_
        End Get
        Set(ByVal value As Double)
            precio_ = value
        End Set
    End Property

    Private usuarioId_ As String
    Public Property usuarioId() As String
        Get
            Return usuarioId_
        End Get
        Set(ByVal value As String)
            usuarioId_ = value
        End Set
    End Property
    Private claveProducto_ As String
    Public tipoprecio As String

    Public Property claveProducto() As String
        Get
            Return claveProducto_
        End Get
        Set(ByVal value As String)
            claveProducto_ = value
        End Set
    End Property

End Class
