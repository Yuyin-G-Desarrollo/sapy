Public Class DevolucionCliente_Codigos

    Private deco_devolucionclientecodigoInteger As Integer
    Private deco_codigo As String
    Private deco_tipocodigo As String
    Private deco_productoestiloid As Integer
    Private deco_lote As Integer
    Private deco_añolote As Integer
    Private deco_naveid As Integer
    Private deco_motivodevolucion_statusid As Integer
    Private deco_precio As Double
    Private deco_monto As Double
    Private deco_pedidoid As Integer
    Private deco_partidaid As Integer
    Private deco_documentoid As Integer
    Private deco_remisionid As Integer
    Private deco_añodocumento As Integer
    Private deco_listaprecioid As Integer
    Private deco_listaprecio As String
    Private deco_fechacreacion As DateTime
    Private deco_usuariocreoid As Integer

    Public Property DevolucionclientecodigoInteger As Integer
        Get
            Return deco_devolucionclientecodigoInteger
        End Get
        Set(value As Integer)
            deco_devolucionclientecodigoInteger = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return deco_codigo
        End Get
        Set(value As String)
            deco_codigo = value
        End Set
    End Property

    Public Property Tipocodigo As String
        Get
            Return deco_tipocodigo
        End Get
        Set(value As String)
            deco_tipocodigo = value
        End Set
    End Property

    Public Property Productoestiloid As Integer
        Get
            Return deco_productoestiloid
        End Get
        Set(value As Integer)
            deco_productoestiloid = value
        End Set
    End Property

    Public Property Lote As Integer
        Get
            Return deco_lote
        End Get
        Set(value As Integer)
            deco_lote = value
        End Set
    End Property

    Public Property Añolote As Integer
        Get
            Return deco_añolote
        End Get
        Set(value As Integer)
            deco_añolote = value
        End Set
    End Property

    Public Property Naveid As Integer
        Get
            Return deco_naveid
        End Get
        Set(value As Integer)
            deco_naveid = value
        End Set
    End Property

    Public Property Motivodevolucion_statusid As Integer
        Get
            Return deco_motivodevolucion_statusid
        End Get
        Set(value As Integer)
            deco_motivodevolucion_statusid = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return deco_precio
        End Get
        Set(value As Double)
            deco_precio = value
        End Set
    End Property

    Public Property Monto As Double
        Get
            Return deco_monto
        End Get
        Set(value As Double)
            deco_monto = value
        End Set
    End Property

    Public Property Pedidoid As Integer
        Get
            Return deco_pedidoid
        End Get
        Set(value As Integer)
            deco_pedidoid = value
        End Set
    End Property

    Public Property Partidaid As Integer
        Get
            Return deco_partidaid
        End Get
        Set(value As Integer)
            deco_partidaid = value
        End Set
    End Property

    Public Property Documentoid As Integer
        Get
            Return deco_documentoid
        End Get
        Set(value As Integer)
            deco_documentoid = value
        End Set
    End Property

    Public Property Remisionid As Integer
        Get
            Return deco_remisionid
        End Get
        Set(value As Integer)
            deco_remisionid = value
        End Set
    End Property

    Public Property Añodocumento As Integer
        Get
            Return deco_añodocumento
        End Get
        Set(value As Integer)
            deco_añodocumento = value
        End Set
    End Property

    Public Property Listaprecioid As Integer
        Get
            Return deco_listaprecioid
        End Get
        Set(value As Integer)
            deco_listaprecioid = value
        End Set
    End Property

    Public Property Listaprecio As String
        Get
            Return deco_listaprecio
        End Get
        Set(value As String)
            deco_listaprecio = value
        End Set
    End Property

    Public Property Fechacreacion As Date
        Get
            Return deco_fechacreacion
        End Get
        Set(value As Date)
            deco_fechacreacion = value
        End Set
    End Property

    Public Property Usuariocreoid As Integer
        Get
            Return deco_usuariocreoid
        End Get
        Set(value As Integer)
            deco_usuariocreoid = value
        End Set
    End Property
End Class
