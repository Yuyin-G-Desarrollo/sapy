Public Class ProductosFacturacion
    Private productoId As Integer
    Public Property PProdId() As Integer
        Get
            Return productoId
        End Get
        Set(ByVal value As Integer)
            productoId = value
        End Set
    End Property

    Private descripcion As String
    Public Property PDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private precioPesos As Double
    Public Property PPrecioPesos() As Double
        Get
            Return precioPesos
        End Get
        Set(ByVal value As Double)
            precioPesos = value
        End Set
    End Property

    Private precioDolares As Double
    Public Property PPrecioDolares() As Double
        Get
            Return precioDolares
        End Get
        Set(ByVal value As Double)
            precioDolares = value
        End Set
    End Property

    Private activo As Boolean
    Public Property PActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Private unidadMedidaId As Integer
    Public Property PUnidadMedidaId() As Integer
        Get
            Return unidadMedidaId
        End Get
        Set(ByVal value As Integer)
            unidadMedidaId = value
        End Set
    End Property

    Private sucursalId As Integer
    Public Property PSucursalId() As Integer
        Get
            Return sucursalId
        End Get
        Set(ByVal value As Integer)
            sucursalId = value
        End Set
    End Property

    Private usuarioId As Integer
    Public Property PUsuarioId() As Integer
        Get
            Return usuarioId
        End Get
        Set(ByVal value As Integer)
            usuarioId = value
        End Set
    End Property


End Class
