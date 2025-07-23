Public Class FacturaComplementoXML
    Dim RFCEmisor As String
    Dim RFCReceptor As String
    Dim Version As String
    Dim Serie As String
    Dim Folio As Integer
    Dim FechaXML As String
    Dim SelloXML As String
    Dim FormaPago As String
    Dim SubtotalXML As Double
    Dim Total As Double
    Dim Pares As Integer
    Dim TipoMoneda As String
    Dim TipoComprobante As String
    Dim MetodoPago As String
    Dim LugarExpedicion As String
    Dim UUID As String
    Dim UsoCFDI As String
    Dim ImporteImpuesto As Double
    Dim FechaTimbrado As Date
    Dim VersionSAT As String
    Dim RFCProvCert As String
    Dim NoCertSAT As String
    Dim SelloSAT As String
    Dim Archivo As String

    Public Property PRFCEmisor As String
        Get
            Return RFCEmisor
        End Get
        Set(value As String)
            RFCEmisor = value
        End Set
    End Property

    Public Property PRFCReceptor As String
        Get
            Return RFCReceptor
        End Get
        Set(value As String)
            RFCReceptor = value
        End Set
    End Property

    Public Property PVersion As String
        Get
            Return Version
        End Get
        Set(value As String)
            Version = value
        End Set
    End Property

    Public Property PSerie As String
        Get
            Return Serie
        End Get
        Set(value As String)
            Serie = value
        End Set
    End Property

    Public Property PFolio As Integer
        Get
            Return Folio
        End Get
        Set(value As Integer)
            Folio = value
        End Set
    End Property

    Public Property PFechaXML As String
        Get
            Return FechaXML
        End Get
        Set(value As String)
            FechaXML = value
        End Set
    End Property

    Public Property PSelloXML As String
        Get
            Return SelloXML
        End Get
        Set(value As String)
            SelloXML = value
        End Set
    End Property

    Public Property PFormaPago As String
        Get
            Return FormaPago
        End Get
        Set(value As String)
            FormaPago = value
        End Set
    End Property

    Public Property PSubtotalXML As Double
        Get
            Return SubtotalXML
        End Get
        Set(value As Double)
            SubtotalXML = value
        End Set
    End Property

    Public Property PTotal As Double
        Get
            Return Total
        End Get
        Set(value As Double)
            Total = value
        End Set
    End Property

    Public Property PPares As Integer
        Get
            Return Pares
        End Get
        Set(value As Integer)
            Pares = value
        End Set
    End Property

    Public Property PTipoMoneda As String
        Get
            Return TipoMoneda
        End Get
        Set(value As String)
            TipoMoneda = value
        End Set
    End Property

    Public Property PTipoComprobante As String
        Get
            Return TipoComprobante
        End Get
        Set(value As String)
            TipoComprobante = value
        End Set
    End Property

    Public Property PMetodoPago As String
        Get
            Return MetodoPago
        End Get
        Set(value As String)
            MetodoPago = value
        End Set
    End Property

    Public Property PLugarExpedicion As String
        Get
            Return LugarExpedicion
        End Get
        Set(value As String)
            LugarExpedicion = value
        End Set
    End Property

    Public Property PUUID As String
        Get
            Return UUID
        End Get
        Set(value As String)
            UUID = value
        End Set
    End Property

    Public Property PUsoCFDI As String
        Get
            Return UsoCFDI
        End Get
        Set(value As String)
            UsoCFDI = value
        End Set
    End Property

    Public Property PImporteImpuesto As Double
        Get
            Return ImporteImpuesto
        End Get
        Set(value As Double)
            ImporteImpuesto = value
        End Set
    End Property

    Public Property PFechaTimbrado As Date
        Get
            Return FechaTimbrado
        End Get
        Set(value As Date)
            FechaTimbrado = value
        End Set
    End Property

    Public Property PVersionSAT As String
        Get
            Return VersionSAT
        End Get
        Set(value As String)
            VersionSAT = value
        End Set
    End Property

    Public Property PRFCProvCert As String
        Get
            Return RFCProvCert
        End Get
        Set(value As String)
            RFCProvCert = value
        End Set
    End Property

    Public Property PNoCertSAT As String
        Get
            Return NoCertSAT
        End Get
        Set(value As String)
            NoCertSAT = value
        End Set
    End Property

    Public Property PSelloSAT As String
        Get
            Return SelloSAT
        End Get
        Set(value As String)
            SelloSAT = value
        End Set
    End Property

    Public Property PArchivo As String
        Get
            Return Archivo
        End Get
        Set(value As String)
            Archivo = value
        End Set
    End Property

End Class
