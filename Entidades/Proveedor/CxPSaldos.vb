Public Class CxPSaldos
    Private TIPODOCTO_ As Integer
    Public Property TIPODOCTO() As Integer
        Get
            Return TIPODOCTO_
        End Get
        Set(ByVal value As Integer)
            TIPODOCTO_ = value
        End Set
    End Property

    Private CVEPROV_ As Integer
    Public Property CVEPROV() As Integer
        Get
            Return CVEPROV_
        End Get
        Set(ByVal value As Integer)
            CVEPROV_ = value
        End Set
    End Property

    Private NUMDOCTO_ As String
    Public Property NUMDOCTO() As String
        Get
            Return NUMDOCTO_
        End Get
        Set(ByVal value As String)
            NUMDOCTO_ = value
        End Set
    End Property

    Private FECDOCTO_ As Date
    Public Property FECDOCTO() As Date
        Get
            Return FECDOCTO_
        End Get
        Set(ByVal value As Date)
            FECDOCTO_ = value
        End Set
    End Property

    Private FECVENTO_ As Date
    Public Property FECVENTO() As Date
        Get
            Return FECVENTO_
        End Get
        Set(ByVal value As Date)
            FECVENTO_ = value
        End Set
    End Property

    Private SEMPAGO_ As Long
    Public Property SEMPAGO() As Long
        Get
            Return SEMPAGO_
        End Get
        Set(ByVal value As Long)
            SEMPAGO_ = value
        End Set
    End Property

    Private SUBTOT_ As Double
    Public Property SUBTOT() As Double
        Get
            Return SUBTOT_
        End Get
        Set(ByVal value As Double)
            SUBTOT_ = value
        End Set
    End Property

    Private IMPIVA_ As Double
    Public Property IMPIVA() As Double
        Get
            Return IMPIVA_
        End Get
        Set(ByVal value As Double)
            IMPIVA_ = value
        End Set
    End Property

    Private IMPDOCTO_ As Double
    Public Property IMPDOCTO() As Double
        Get
            Return IMPDOCTO_
        End Get
        Set(ByVal value As Double)
            IMPDOCTO_ = value
        End Set
    End Property

    Private SDODOCTO_ As Double
    Public Property SDODOCTO() As Double
        Get
            Return SDODOCTO_
        End Get
        Set(ByVal value As Double)
            SDODOCTO_ = value
        End Set
    End Property

    Private NUMRECCOM_ As Integer
    Public Property NUMRECCOM() As Integer
        Get
            Return NUMRECCOM_
        End Get
        Set(ByVal value As Integer)
            NUMRECCOM_ = value
        End Set
    End Property

    Private MONEDA_ As Integer
    Public Property MONEDA() As Integer
        Get
            Return MONEDA_
        End Get
        Set(ByVal value As Integer)
            MONEDA_ = value
        End Set
    End Property

    Private REPOSICION_ As Boolean
    Public Property REPOSICION() As Boolean
        Get
            Return REPOSICION_
        End Get
        Set(ByVal value As Boolean)
            REPOSICION_ = value
        End Set
    End Property

    Private ENVIADO_ As Date
    Public Property ENVIADO() As Date
        Get
            Return ENVIADO_
        End Get
        Set(ByVal value As Date)
            ENVIADO_ = value
        End Set
    End Property

    Private USUENVIO_ As String
    Public Property USUENVIO() As String
        Get
            Return USUENVIO_
        End Get
        Set(ByVal value As String)
            USUENVIO_ = value
        End Set
    End Property

    Private RECIBIDO_ As Date
    Public Property RECIBIDO() As Date
        Get
            Return RECIBIDO_
        End Get
        Set(ByVal value As Date)
            RECIBIDO_ = value
        End Set
    End Property

    Private USURECIBIO_ As String
    Public Property USURECIBIO() As String
        Get
            Return USURECIBIO_
        End Get
        Set(ByVal value As String)
            USURECIBIO_ = value
        End Set
    End Property

    Private NAVE_ As Long
    Public Property NAVE() As Long
        Get
            Return NAVE_
        End Get
        Set(ByVal value As Long)
            NAVE_ = value
        End Set
    End Property

    Private IDTABLA_ As Long
    Public Property IDTABLA() As Long
        Get
            Return IDTABLA_
        End Get
        Set(ByVal value As Long)
            IDTABLA_ = value
        End Set
    End Property

    Private FECAUTORIZO_ As Date
    Public Property FECAUTORIZO() As Date
        Get
            Return FECAUTORIZO_
        End Get
        Set(ByVal value As Date)
            FECAUTORIZO_ = value
        End Set
    End Property

    Private USUAUTORIZO_ As String
    Public Property USUAUTORIZO() As String
        Get
            Return USUAUTORIZO_
        End Get
        Set(ByVal value As String)
            USUAUTORIZO_ = value
        End Set
    End Property

    Private SEMPAGADA_ As Long
    Public Property SEMPAGADA() As Long
        Get
            Return SEMPAGADA_
        End Get
        Set(ByVal value As Long)
            SEMPAGADA_ = value
        End Set
    End Property

    Private FECMODAUTPAG_ As Date
    Public Property FECMODAUTPAG() As Date
        Get
            Return FECMODAUTPAG_
        End Get
        Set(ByVal value As Date)
            FECMODAUTPAG_ = value
        End Set
    End Property

    Private USUMODAUTPAG_ As String
    Public Property USUMODAUTPAG() As String
        Get
            Return USUMODAUTPAG_
        End Get
        Set(ByVal value As String)
            USUMODAUTPAG_ = value
        End Set
    End Property

    Private PAGARDOCTO_ As Boolean
    Public Property PAGARDOCTO() As Boolean
        Get
            Return PAGARDOCTO_
        End Get
        Set(ByVal value As Boolean)
            PAGARDOCTO_ = value
        End Set
    End Property

    Private REFERENCIA_ As String
    Public Property REFERENCIA() As String
        Get
            Return REFERENCIA_
        End Get
        Set(ByVal value As String)
            REFERENCIA_ = value
        End Set
    End Property

    Private AÑOSEMPAGO_ As Integer
    Public Property AÑOSEMPAGO() As Integer
        Get
            Return AÑOSEMPAGO_
        End Get
        Set(ByVal value As Integer)
            AÑOSEMPAGO_ = value
        End Set
    End Property

    Private AÑOSEMPAGADA_ As Integer
    Public Property AÑOSEMPAGADA() As Integer
        Get
            Return AÑOSEMPAGADA_
        End Get
        Set(ByVal value As Integer)
            AÑOSEMPAGADA_ = value
        End Set
    End Property

    Private USUCAPTURA_ As String
    Public Property USUCAPTURA() As String
        Get
            Return USUCAPTURA_
        End Get
        Set(ByVal value As String)
            USUCAPTURA_ = value
        End Set
    End Property

    Private USUMODIFICA_ As String
    Public Property USUMODIFICA() As String
        Get
            Return USUMODIFICA_
        End Get
        Set(ByVal value As String)
            USUMODIFICA_ = value
        End Set
    End Property

    Private FECHACAPTURA_ As Date
    Public Property FECHACAPTURA() As Date
        Get
            Return FECHACAPTURA_
        End Get
        Set(ByVal value As Date)
            FECHACAPTURA_ = value
        End Set
    End Property

    Private CAPTURANAVE_ As Boolean
    Public Property CAPTURANAVE() As Boolean
        Get
            Return CAPTURANAVE_
        End Get
        Set(ByVal value As Boolean)
            CAPTURANAVE_ = value
        End Set
    End Property

    Private PAGARENDOSO_ As Long
    Public Property PAGARENDOSO() As Long
        Get
            Return PAGARENDOSO_
        End Get
        Set(ByVal value As Long)
            PAGARENDOSO_ = value
        End Set
    End Property

    Private IDRAZSOC_ As Long
    Public Property IDRAZSOC() As Long
        Get
            Return IDRAZSOC_
        End Get
        Set(ByVal value As Long)
            IDRAZSOC_ = value
        End Set
    End Property

    Private PAGARCHQINT_ As Long
    Public Property PAGARCHQINT() As Long
        Get
            Return PAGARCHQINT_
        End Get
        Set(ByVal value As Long)
            PAGARCHQINT_ = value
        End Set
    End Property

    Private PREFERENCIAENDOSO_ As Boolean
    Public Property PREFERENCIAENDOSO() As Boolean
        Get
            Return PREFERENCIAENDOSO_
        End Get
        Set(ByVal value As Boolean)
            PREFERENCIAENDOSO_ = value
        End Set
    End Property

    Private IDPAGARE_ As Integer
    Public Property IDPAGARE() As Integer
        Get
            Return IDPAGARE_
        End Get
        Set(ByVal value As Integer)
            IDPAGARE_ = value
        End Set
    End Property

    Private REPROGRAMADO_ As Long
    Public Property REPROGRAMADO() As Long
        Get
            Return REPROGRAMADO_
        End Get
        Set(ByVal value As Long)
            REPROGRAMADO_ = value
        End Set
    End Property

    Private SEMREPROGRAMADO_ As Integer
    Public Property SEMREPROGRAMADO() As Integer
        Get
            Return SEMREPROGRAMADO_
        End Get
        Set(ByVal value As Integer)
            SEMREPROGRAMADO_ = value
        End Set
    End Property

    Private AÑOREPROGRAMADO_ As Integer
    Public Property AÑOREPROGRAMADO() As Integer
        Get
            Return AÑOREPROGRAMADO_
        End Get
        Set(ByVal value As Integer)
            AÑOREPROGRAMADO_ = value
        End Set
    End Property
    Private IdComprobantecfdsOrdenCompra_ As Integer
    Public Property IdComprobantecfdsOrdenCompra() As Integer
        Get
            Return IdComprobantecfdsOrdenCompra_
        End Get
        Set(ByVal value As Integer)
            IdComprobantecfdsOrdenCompra_ = value
        End Set
    End Property
    Private IdComprobante_ As Integer
    Public Property IdComprobante() As Integer
        Get
            Return IdComprobante_
        End Get
        Set(ByVal value As Integer)
            IdComprobante_ = value
        End Set
    End Property

    Private importedescuento_ As Double
    Public Property importedescuento() As Double
        Get
            Return importedescuento_
        End Get
        Set(ByVal value As Double)
            importedescuento_ = value
        End Set
    End Property
    Private RfcEmpresa_ As String
    Public Property RfcEmpresa() As String
        Get
            Return RfcEmpresa_
        End Get
        Set(ByVal value As String)
            RfcEmpresa_ = value
        End Set
    End Property
    Private RfcProveedor_ As String
    Public Property RfcProveedor() As String
        Get
            Return RfcProveedor_
        End Get
        Set(ByVal value As String)
            RfcProveedor_ = value
        End Set
    End Property
End Class
