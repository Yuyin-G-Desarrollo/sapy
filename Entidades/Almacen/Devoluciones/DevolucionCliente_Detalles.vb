Public Class DevolucionCliente_Detalles
    Private decd_devolucionclientedetalleid As Integer
    Private decd_devolucionclienteid As Integer
    Private decd_productoestiloid As Integer
    Private decd_lote As Integer
    Private decl_aniolote As Integer
    Private decl_naveid As Integer
    Private decd_motivodevolucion_statusid As Integer
    Private decd_cantidad As Integer
    Private decd_unidadid As Integer
    Private decd_precio As Double
    Private decd_monto As Double
    Private decd_pedidoid As Integer
    Private decd_partidaid As Integer
    Private decd_documentoid As Integer
    Private decd_remisionid As Integer
    Private decd_aniodocumento As Integer
    Private decd_listaprecioid As Integer
    Private decd_listaprecio As String
    Private decd_usuariocreoid As Integer
    Private decd_fechacreacion As DateTime
    Private decd_lecturacodigos As Int16

    Public Property Devolucionclientedetalleid As Integer
        Get
            Return decd_devolucionclientedetalleid
        End Get
        Set(value As Integer)
            decd_devolucionclientedetalleid = value
        End Set
    End Property

    Public Property Devolucionclienteid As Integer
        Get
            Return decd_devolucionclienteid
        End Get
        Set(value As Integer)
            decd_devolucionclienteid = value
        End Set
    End Property

    Public Property Productoestiloid As Integer
        Get
            Return decd_productoestiloid
        End Get
        Set(value As Integer)
            decd_productoestiloid = value
        End Set
    End Property

    Public Property Lote As Integer
        Get
            Return decd_lote
        End Get
        Set(value As Integer)
            decd_lote = value
        End Set
    End Property

    Public Property Aniolote As Integer
        Get
            Return decl_aniolote
        End Get
        Set(value As Integer)
            decl_aniolote = value
        End Set
    End Property

    Public Property Naveid As Integer
        Get
            Return decl_naveid
        End Get
        Set(value As Integer)
            decl_naveid = value
        End Set
    End Property

    Public Property Motivodevolucion_statusid As Integer
        Get
            Return decd_motivodevolucion_statusid
        End Get
        Set(value As Integer)
            decd_motivodevolucion_statusid = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return decd_cantidad
        End Get
        Set(value As Integer)
            decd_cantidad = value
        End Set
    End Property

    Public Property Unidadid As Integer
        Get
            Return decd_unidadid
        End Get
        Set(value As Integer)
            decd_unidadid = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return decd_precio
        End Get
        Set(value As Double)
            decd_precio = value
        End Set
    End Property

    Public Property Monto As Double
        Get
            Return decd_monto
        End Get
        Set(value As Double)
            decd_monto = value
        End Set
    End Property

    Public Property Pedidoid As Integer
        Get
            Return decd_pedidoid
        End Get
        Set(value As Integer)
            decd_pedidoid = value
        End Set
    End Property

    Public Property Partidaid As Integer
        Get
            Return decd_partidaid
        End Get
        Set(value As Integer)
            decd_partidaid = value
        End Set
    End Property

    Public Property Documentoid As Integer
        Get
            Return decd_documentoid
        End Get
        Set(value As Integer)
            decd_documentoid = value
        End Set
    End Property

    Public Property Remisionid As Integer
        Get
            Return decd_remisionid
        End Get
        Set(value As Integer)
            decd_remisionid = value
        End Set
    End Property

    Public Property Aniodocumento As Integer
        Get
            Return decd_aniodocumento
        End Get
        Set(value As Integer)
            decd_aniodocumento = value
        End Set
    End Property

    Public Property Listaprecioid As Integer
        Get
            Return decd_listaprecioid
        End Get
        Set(value As Integer)
            decd_listaprecioid = value
        End Set
    End Property

    Public Property Listaprecio As String
        Get
            Return decd_listaprecio
        End Get
        Set(value As String)
            decd_listaprecio = value
        End Set
    End Property

    Public Property Usuariocreoid As Integer
        Get
            Return decd_usuariocreoid
        End Get
        Set(value As Integer)
            decd_usuariocreoid = value
        End Set
    End Property

    Public Property Fechacreacion As Date
        Get
            Return decd_fechacreacion
        End Get
        Set(value As Date)
            decd_fechacreacion = value
        End Set
    End Property

    Public Property Lecturacodigos As Short
        Get
            Return decd_lecturacodigos
        End Get
        Set(value As Short)
            decd_lecturacodigos = value
        End Set
    End Property
End Class
