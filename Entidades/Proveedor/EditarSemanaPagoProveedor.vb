Public Class EditarSemanaPagoProveedor
    Private Docto As String
    Private Factura As String
    Private SemanaActual As Integer
    Private Importe As Double
    Private ProveedorID As Integer
    Private AnioActual As Integer
    Private SemanaCompraActual As Integer


    Public Property PDocto() As String
        Get
            Return Docto
        End Get
        Set(ByVal value As String)
            Docto = value
        End Set
    End Property

    Public Property PFactura() As String
        Get
            Return Factura
        End Get
        Set(ByVal value As String)
            Factura = value
        End Set
    End Property

    Public Property PSemanaActual() As Integer
        Get
            Return SemanaActual
        End Get
        Set(ByVal value As Integer)
            SemanaActual = value
        End Set
    End Property

    Public Property PImporte() As Double
        Get
            Return Importe
        End Get
        Set(ByVal value As Double)
            Importe = value
        End Set
    End Property


    Public Property PProveedorID() As Integer
        Get
            Return ProveedorID
        End Get
        Set(ByVal value As Integer)
            ProveedorID = value
        End Set
    End Property

    Public Property PAnioActual() As Integer
        Get
            Return AnioActual
        End Get
        Set(ByVal value As Integer)
            AnioActual = value
        End Set
    End Property

    Public Property PSemanaCompraActual() As Integer
        Get
            Return SemanaCompraActual
        End Get
        Set(ByVal value As Integer)
            SemanaCompraActual = value
        End Set
    End Property


End Class
