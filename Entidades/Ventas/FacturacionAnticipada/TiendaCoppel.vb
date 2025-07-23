Public Class TiendaCoppel

    Private _id As Integer
    Private _nombre As String
    Private _cliente As String
    Private _tipo As String
    Private _activo As Boolean
    Private _vinculado As Boolean
    Private _bodega As String
    Private _bodegaId As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return _activo
        End Get
        Set(value As Boolean)
            _activo = value
        End Set
    End Property

    Public Property Vinculado As Boolean
        Get
            Return _vinculado
        End Get
        Set(value As Boolean)
            _vinculado = value
        End Set
    End Property

    Public Property Bodega As String
        Get
            Return _bodega
        End Get
        Set(value As String)
            _bodega = value
        End Set
    End Property

    Public Property BodegaId As Integer
        Get
            Return _bodegaId
        End Get
        Set(value As Integer)
            _bodegaId = value
        End Set
    End Property
End Class
