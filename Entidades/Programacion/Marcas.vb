Public Class Marcas
    Private marcaid As Int32
    Private descripcion As String
    Private codigo As String
    Private activo As Boolean
    Private CodigoSicy As String
    Private MarcaCliente As Boolean
    Private Seleccion As Boolean

    Public Property PSeleccion As Boolean
        Get
            Return Seleccion
        End Get
        Set(ByVal value As Boolean)
            Seleccion = value
        End Set
    End Property

    Public Property PMarcaId As Int32
        Get
            Return marcaid
        End Get
        Set(ByVal value As Int32)
            marcaid = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Public Property PCodigo As String
        Get
            Return codigo
        End Get
        Set(ByVal value As String)
            codigo = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Public Property PSicyCodigo As String
        Get
            Return CodigoSicy
        End Get
        Set(ByVal value As String)
            CodigoSicy = value
        End Set
    End Property

    Public Property PClienteMarca As Boolean
        Get
            Return MarcaCliente
        End Get
        Set(ByVal value As Boolean)
            MarcaCliente = value
        End Set
    End Property

    Public Property PComercializadora() As Integer

End Class
