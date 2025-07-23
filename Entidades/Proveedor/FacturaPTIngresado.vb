Public Class FacturaPTIngresado
    Private documentoId As Integer
    Public Property PDocumentoId() As Integer
        Get
            Return documentoId
        End Get
        Set(ByVal value As Integer)
            documentoId = value
        End Set
    End Property

    Private version As String
    Public Property PVersion() As String
        Get
            Return version
        End Get
        Set(ByVal value As String)
            version = value
        End Set
    End Property

    Private serie As String
    Public Property PSerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Private folio As Integer
    Public Property PFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property

    Private fecha As Date
    Public Property PFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Private sello As String
    Public Property PSello() As String
        Get
            Return sello
        End Get
        Set(ByVal value As String)
            sello = value
        End Set
    End Property

    Private formaPago As String
    Public Property PFormaPago() As String
        Get
            Return formaPago
        End Get
        Set(ByVal value As String)
            formaPago = value
        End Set
    End Property

    Private subTotal As Double
    Public Property PSubTotal() As Double
        Get
            Return subTotal
        End Get
        Set(ByVal value As Double)
            subTotal = value
        End Set
    End Property

    Private descuento As Double
    Public Property PDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private total As Double
    Public Property PTotal() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private monedaId As Integer
    Public Property PMonedaId() As Integer
        Get
            Return monedaId
        End Get
        Set(ByVal value As Integer)
            monedaId = value
        End Set
    End Property

    Private tipoComprobante As String
    Public Property PTipoComprobante() As String
        Get
            Return tipoComprobante
        End Get
        Set(ByVal value As String)
            tipoComprobante = value
        End Set
    End Property

    Private metodoPago As String
    Public Property PMetodoPago() As String
        Get
            Return metodoPago
        End Get
        Set(ByVal value As String)
            metodoPago = value
        End Set
    End Property

    Private lugarExpedicion As String
    Public Property PLugarExpedicion() As String
        Get
            Return lugarExpedicion
        End Get
        Set(ByVal value As String)
            lugarExpedicion = value
        End Set
    End Property

    Private uuid As String
    Public Property PUuid() As String
        Get
            Return uuid
        End Get
        Set(ByVal value As String)
            uuid = value
        End Set
    End Property

    Private emisorId As Integer
    Public Property PEmisorId() As Integer
        Get
            Return emisorId
        End Get
        Set(ByVal value As Integer)
            emisorId = value
        End Set
    End Property

    Private receptorId As Integer
    Public Property PReceptorId() As Integer
        Get
            Return receptorId
        End Get
        Set(ByVal value As Integer)
            receptorId = value
        End Set
    End Property

    Private usoCfdiId As String
    Public Property PUsoCfdiId() As String
        Get
            Return usoCfdiId
        End Get
        Set(ByVal value As String)
            usoCfdiId = value
        End Set
    End Property

    Private impuesto As String
    Public Property PImpuesto() As String
        Get
            Return impuesto
        End Get
        Set(ByVal value As String)
            impuesto = value
        End Set
    End Property

    Private tipoFactor As String
    Public Property PTipoFactor() As String
        Get
            Return tipoFactor
        End Get
        Set(ByVal value As String)
            tipoFactor = value
        End Set
    End Property

    Private tasaCuota As Double
    Public Property PTasaCuota() As Double
        Get
            Return tasaCuota
        End Get
        Set(ByVal value As Double)
            tasaCuota = value
        End Set
    End Property

    Private importeImpuesto As Double
    Public Property PImporteImpuesto() As Double
        Get
            Return importeImpuesto
        End Get
        Set(ByVal value As Double)
            importeImpuesto = value
        End Set
    End Property

    Private timbrado As Boolean
    Public Property PTimbrado() As Boolean
        Get
            Return timbrado
        End Get
        Set(ByVal value As Boolean)
            timbrado = value
        End Set
    End Property

    Private usuarioTimbroId As Integer
    Public Property PUsuarioTimbroId() As Integer
        Get
            Return usuarioTimbroId
        End Get
        Set(ByVal value As Integer)
            usuarioTimbroId = value
        End Set
    End Property

    Private fechaTimbrado As Date
    Public Property PFecahTimbrado() As Date
        Get
            Return fechaTimbrado
        End Get
        Set(ByVal value As Date)
            fechaTimbrado = value
        End Set
    End Property

    Private versionSat As String
    Public Property PVersionSat() As String
        Get
            Return versionSat
        End Get
        Set(ByVal value As String)
            versionSat = value
        End Set
    End Property

    Private rfcProvCertif As String
    Public Property PRfcProvCertif() As String
        Get
            Return rfcProvCertif
        End Get
        Set(ByVal value As String)
            rfcProvCertif = value
        End Set
    End Property

    Private noCertificadoSAT As String
    Public Property PNoCertificadoSAT() As String
        Get
            Return noCertificadoSAT
        End Get
        Set(ByVal value As String)
            noCertificadoSAT = value
        End Set
    End Property

    Private selloSAT As String
    Public Property PSelloSAT() As String
        Get
            Return selloSAT
        End Get
        Set(ByVal value As String)
            selloSAT = value
        End Set
    End Property

    Private cadenaOriginal As String
    Public Property PCadenaOriginal() As String
        Get
            Return cadenaOriginal
        End Get
        Set(ByVal value As String)
            cadenaOriginal = value
        End Set
    End Property

    Private cadenaOriginalComplemento As String
    Public Property PCadenaOriginalComplemento() As String
        Get
            Return cadenaOriginalComplemento
        End Get
        Set(ByVal value As String)
            cadenaOriginalComplemento = value
        End Set
    End Property

    Private motivoSinTimbrar As String
    Public Property PMotivoSinTimbrar() As String
        Get
            Return motivoSinTimbrar
        End Get
        Set(ByVal value As String)
            motivoSinTimbrar = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property PUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private fechaCreacion As DateTime
    Public Property PFechaCreacion() As DateTime
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            fechaCreacion = value
        End Set
    End Property

    Private rutaXml As String
    Public Property PRutaXml() As String
        Get
            Return rutaXml
        End Get
        Set(ByVal value As String)
            rutaXml = value
        End Set
    End Property

    Private rutaPdf As String
    Public Property PRutaPdf() As String
        Get
            Return rutaPdf
        End Get
        Set(ByVal value As String)
            rutaPdf = value
        End Set
    End Property

    Private cancelado As Boolean
    Public Property PCancelado() As Boolean
        Get
            Return cancelado
        End Get
        Set(ByVal value As Boolean)
            cancelado = value
        End Set
    End Property

    Private motivoCancelacion As String
    Public Property PCancelacion() As String
        Get
            Return motivoCancelacion
        End Get
        Set(ByVal value As String)
            motivoCancelacion = value
        End Set
    End Property

    Private usuarioCanceloId As Integer
    Public Property PUsuarioCanceloId() As Integer
        Get
            Return usuarioCanceloId
        End Get
        Set(ByVal value As Integer)
            usuarioCanceloId = value
        End Set
    End Property

    Private fechaCancelacion As Date
    Public Property PFechaCancelacion() As Date
        Get
            Return fechaCancelacion
        End Get
        Set(ByVal value As Date)
            fechaCancelacion = value
        End Set
    End Property

    Private rutaXmlCancelacion As String
    Public Property PRutaXmlCancelacion() As String
        Get
            Return rutaXmlCancelacion
        End Get
        Set(ByVal value As String)
            rutaXmlCancelacion = value
        End Set
    End Property

    Private rutaPdfCancelacion As String
    Public Property PRutaPdfCancelacion() As String
        Get
            Return rutaPdfCancelacion
        End Get
        Set(ByVal value As String)
            rutaPdfCancelacion = value
        End Set
    End Property
End Class
