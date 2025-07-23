Public Class CompraEquipos

    Private compraequi_compraid As Integer

    Public Property CECompraId() As Integer
        Get
            Return compraequi_compraid
        End Get
        Set(ByVal value As Integer)
            compraequi_compraid = value
        End Set
    End Property


    Private compraequi_fechasolicitud As DateTime

    Public Property CEFechaSoli() As DateTime
        Get
            Return compraequi_fechasolicitud
        End Get
        Set(ByVal value As DateTime)
            compraequi_fechasolicitud = value
        End Set
    End Property

    Private compraequi_fechaentrega As DateTime


    Public Property CEFechaEntre() As DateTime
        Get
            Return compraequi_fechaentrega
        End Get
        Set(ByVal value As DateTime)
            compraequi_fechaentrega = value
        End Set
    End Property

    Private compraequi_proveedor As String

    Public Property CEProveedor() As String
        Get
            Return compraequi_proveedor
        End Get
        Set(ByVal value As String)
            compraequi_proveedor = value
        End Set
    End Property

    Private compraequi_descripcionequipo As String

    Public Property CEDescEqui() As String
        Get
            Return compraequi_descripcionequipo
        End Get
        Set(ByVal value As String)
            compraequi_descripcionequipo = value
        End Set
    End Property

    Private compraequi_proyecto As String

    Public Property CEProyecto() As String
        Get
            Return compraequi_proyecto
        End Get
        Set(ByVal value As String)
            compraequi_proyecto = value
        End Set
    End Property

    Private compraequi_nofactura As String

    Public Property CENoFact() As String
        Get
            Return compraequi_nofactura
        End Get
        Set(ByVal value As String)
            compraequi_nofactura = value
        End Set
    End Property

    Private compraequi_cantidad As Integer

    Public Property CECantidad() As Integer
        Get
            Return compraequi_cantidad
        End Get
        Set(ByVal value As Integer)
            compraequi_cantidad = value
        End Set
    End Property

    Private compraequi_moneda As Integer

    Public Property CEMoneda() As Integer
        Get
            Return compraequi_moneda
        End Get
        Set(ByVal value As Integer)
            compraequi_moneda = value
        End Set
    End Property

    Private compraequi_tipocambio As Double

    Public Property CETipoCamb() As Double
        Get
            Return compraequi_tipocambio
        End Get
        Set(ByVal value As Double)
            compraequi_tipocambio = value
        End Set
    End Property

    Private compraequi_costounitario As Double

    Public Property CEcostUni() As Double
        Get
            Return compraequi_costounitario
        End Get
        Set(ByVal value As Double)
            compraequi_costounitario = value
        End Set
    End Property

    Private compraequi_total As Double

    Public Property CETotal() As Double
        Get
            Return compraequi_total
        End Get
        Set(ByVal value As Double)
            compraequi_total = value
        End Set
    End Property

    Private compraequi_naveid As Integer

    Public Property CENaveId() As Integer
        Get
            Return compraequi_naveid
        End Get
        Set(ByVal value As Integer)
            compraequi_naveid = value
        End Set
    End Property

    Private compraequi_categoriaid As Integer

    Public Property CECategoriaId() As Integer
        Get
            Return compraequi_categoriaid
        End Get
        Set(ByVal value As Integer)
            compraequi_categoriaid = value
        End Set
    End Property

    Private compraequi_articuloid As Integer

    Public Property CEArticuloId() As Integer
        Get
            Return compraequi_articuloid
        End Get
        Set(ByVal value As Integer)
            compraequi_articuloid = value
        End Set
    End Property

    Private compraequi_usuariocrea As Integer

    Public Property CEUsuCrea() As Integer
        Get
            Return compraequi_usuariocrea
        End Get
        Set(ByVal value As Integer)
            compraequi_usuariocrea = value
        End Set
    End Property

    Private compraequi_usuariomodifica As Integer

    Public Property CEUsuModi() As Integer
        Get
            Return compraequi_usuariomodifica
        End Get
        Set(ByVal value As Integer)
            compraequi_usuariomodifica = value
        End Set
    End Property

    'Private compraequi_fechacrea As DateTime

    'Public Property CEFechacrea() As DateTime
    '    Get
    '        Return compraequi_fechacrea
    '    End Get
    '    Set(ByVal value As DateTime)
    '        compraequi_fechacrea = value
    '    End Set
    'End Property

    'Private compraequi_fechamodifica As DateTime

    'Public Property CEFechamodif() As DateTime
    '    Get
    '        Return compraequi_fechamodifica
    '    End Get
    '    Set(ByVal value As DateTime)
    '        compraequi_fechamodifica = value
    '    End Set
    'End Property



End Class
