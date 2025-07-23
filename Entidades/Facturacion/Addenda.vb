Public Class Addenda

    Private PDocumentoID As Integer
    Public Property DocumentoID() As Integer
        Get
            Return PDocumentoID
        End Get
        Set(ByVal value As Integer)
            PDocumentoID = value
        End Set
    End Property

    Private PRemisionID As Integer
    Public Property RemisionID() As Integer
        Get
            Return PRemisionID
        End Get
        Set(ByVal value As Integer)
            PRemisionID = value
        End Set
    End Property

    Private PAñoRemision As Integer
    Public Property AñoRemision() As Integer
        Get
            Return PAñoRemision
        End Get
        Set(ByVal value As Integer)
            PAñoRemision = value
        End Set
    End Property

    Private PFolioFactura As String
    Public Property FolioFactura() As String
        Get
            Return PFolioFactura
        End Get
        Set(ByVal value As String)
            PFolioFactura = value
        End Set
    End Property

    Private PSerieFactura As String
    Public Property SerieFactura() As String
        Get
            Return PSerieFactura
        End Get
        Set(ByVal value As String)
            PSerieFactura = value
        End Set
    End Property

    Private PTipoDocumento As String
    Public Property TipoDocumento() As String
        Get
            Return PTipoDocumento
        End Get
        Set(ByVal value As String)
            PTipoDocumento = value
        End Set
    End Property

    Private PFechaCaptura As Date
    Public Property FechaCaptura() As Date
        Get
            Return PFechaCaptura
        End Get
        Set(ByVal value As Date)
            PFechaCaptura = value
        End Set
    End Property

    Private PParesFacturados As Integer
    Public Property ParesFacturados() As Integer
        Get
            Return PParesFacturados
        End Get
        Set(ByVal value As Integer)
            PParesFacturados = value
        End Set
    End Property

    Private PParesCancelados As Integer
    Public Property ParesCancelados() As Integer
        Get
            Return PParesCancelados
        End Get
        Set(ByVal value As Integer)
            PParesCancelados = value
        End Set
    End Property

    Private PTotalPares As Integer
    Public Property TotalPares() As Integer
        Get
            Return PTotalPares
        End Get
        Set(ByVal value As Integer)
            PTotalPares = value
        End Set
    End Property

    Private PSubTotal As String
    Public Property SubTotal() As String
        Get
            Return PSubTotal
        End Get
        Set(ByVal value As String)
            PSubTotal = value
        End Set
    End Property

    Private PDescuento As String
    Public Property Descuento() As String
        Get
            Return PDescuento
        End Get
        Set(ByVal value As String)
            PDescuento = value
        End Set
    End Property

    Private PTipoIVA As String
    Public Property TipoIVA() As String
        Get
            Return PTipoIVA
        End Get
        Set(ByVal value As String)
            PTipoIVA = value
        End Set
    End Property

    Private PMontoTotal As String
    Public Property MontoTotal() As String
        Get
            Return PMontoTotal
        End Get
        Set(ByVal value As String)
            PMontoTotal = value
        End Set
    End Property

    Private PPorcentajeDescuento As String
    Public Property PorcentajeDescuento() As String
        Get
            Return PPorcentajeDescuento
        End Get
        Set(ByVal value As String)
            PPorcentajeDescuento = value
        End Set
    End Property

    Private PMontoTotalLetra As String
    Public Property MontoTotalLetra() As String
        Get
            Return PMontoTotalLetra
        End Get
        Set(ByVal value As String)
            PMontoTotalLetra = value
        End Set
    End Property

    Private PUsoCFDI As String
    Public Property UsoCFDI() As String
        Get
            Return PUsoCFDI
        End Get
        Set(ByVal value As String)
            PUsoCFDI = value
        End Set
    End Property

    Private POrdenCompra As String
    Public Property OrdenCompra() As String
        Get
            Return POrdenCompra
        End Get
        Set(ByVal value As String)
            POrdenCompra = value
        End Set
    End Property

    Private PCorreoReceptor As String
    Public Property CorreoReceptor() As String
        Get
            Return PCorreoReceptor
        End Get
        Set(ByVal value As String)
            PCorreoReceptor = value
        End Set
    End Property

    Private PCodigoTienda As String
    Public Property CodigoTienda() As String
        Get
            Return PCodigoTienda
        End Get
        Set(ByVal value As String)
            PCodigoTienda = value
        End Set
    End Property

    Private PNumeroCajas As String
    Public Property NumeroCajas() As String
        Get
            Return PNumeroCajas
        End Get
        Set(ByVal value As String)
            PNumeroCajas = value
        End Set
    End Property

    Private PTotalIVA As String
    Public Property TotalIVA() As String
        Get
            Return PTotalIVA
        End Get
        Set(ByVal value As String)
            PTotalIVA = value
        End Set
    End Property


    Private PImporte As String
    Public Property Importe() As String
        Get
            Return PImporte
        End Get
        Set(ByVal value As String)
            PImporte = value
        End Set
    End Property

    Private PClaveProveedor As Integer
    Public Property ClaveProveedor() As Integer
        Get
            Return PClaveProveedor
        End Get
        Set(ByVal value As Integer)
            PClaveProveedor = value
        End Set
    End Property
End Class
