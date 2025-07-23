Public Class xml


    Private uuid_ As String
    Public Property uuid() As String
        Get
            Return uuid_
        End Get
        Set(ByVal value As String)
            uuid_ = value
        End Set
    End Property

    Private folio_ As String
    Public Property folio() As String
        Get
            Return folio_
        End Get
        Set(ByVal value As String)
            folio_ = value
        End Set
    End Property

    Private serie_ As String
    Public Property serie() As String
        Get
            Return serie_
        End Get
        Set(ByVal value As String)
            serie_ = value
        End Set
    End Property
    Private total_ As Double
    Public Property total() As Double
        Get
            Return total_
        End Get
        Set(ByVal value As Double)
            total_ = value
        End Set
    End Property

    Private rfcEmisor_ As String
    Public Property rfcEmisor() As String
        Get
            Return rfcEmisor_
        End Get
        Set(ByVal value As String)
            rfcEmisor_ = value
        End Set
    End Property

    Private rfcReceptor_ As String
    Public Property rfcReceptor() As String
        Get
            Return rfcReceptor_
        End Get
        Set(ByVal value As String)
            rfcReceptor_ = value
        End Set
    End Property

    Private subTotal_ As Double
    Public Property subTotal() As Double
        Get
            Return subTotal_
        End Get
        Set(ByVal value As Double)
            subTotal_ = value
        End Set
    End Property

    Private razonSocEmisor_ As String
    Public Property razonSocEmisor() As String
        Get
            Return razonSocEmisor_
        End Get
        Set(ByVal value As String)
            razonSocEmisor_ = value
        End Set
    End Property

    Private razonSocReceptor_ As String
    Public Property razonSocReceptor() As String
        Get
            Return razonSocReceptor_
        End Get
        Set(ByVal value As String)
            razonSocReceptor_ = value
        End Set
    End Property

    Private iva_ As Double
    Public Property iva() As Double
        Get
            Return iva_
        End Get
        Set(ByVal value As Double)
            iva_ = value
        End Set
    End Property

    Private fechaxml_ As Date
    Public Property fechaxml() As Date
        Get
            Return fechaxml_
        End Get
        Set(ByVal value As Date)
            fechaxml_ = value
        End Set
    End Property

    Private errores_ As Integer
    Public Property errores() As Integer
        Get
            Return errores_
        End Get
        Set(ByVal value As Integer)
            errores_ = value
        End Set
    End Property
    Private rutaxml_ As String
    Public Property rutaxml() As String
        Get
            Return rutaxml_
        End Get
        Set(ByVal value As String)
            rutaxml_ = value
        End Set
    End Property

    Private version_ As String
    Public Property version() As String
        Get
            Return version_
        End Get
        Set(ByVal value As String)
            version_ = value
        End Set
    End Property
    Private idEmpresa_ As Integer = 0
    Public Property idEmpresa() As Integer
        Get
            Return idEmpresa_
        End Get
        Set(ByVal value As Integer)
            idEmpresa_ = value
        End Set
    End Property

    Private idProveedor_ As Integer = 0
    Public Property idProveedor() As Integer
        Get
            Return idProveedor_
        End Get
        Set(ByVal value As Integer)
            idProveedor_ = value
        End Set
    End Property

    Private rutapdf_ As String = ""
    Public Property rutapdf() As String
        Get
            Return rutapdf_
        End Get
        Set(ByVal value As String)
            rutapdf_ = value
        End Set
    End Property

    Private estatusValidacion_ As Boolean
    Public Property estatusValidacion() As Boolean
        Get
            Return estatusValidacion_
        End Get
        Set(ByVal value As Boolean)
            estatusValidacion_ = value
        End Set
    End Property

    Private estatusEliminado_ As Boolean
    Public Property estatusEliminado() As Boolean
        Get
            Return estatusEliminado_
        End Get
        Set(ByVal value As Boolean)
            estatusEliminado_ = value
        End Set
    End Property

    Private idNave_ As Integer = 0
    Public Property idNave() As Integer
        Get
            Return idNave_
        End Get
        Set(ByVal value As Integer)
            idNave_ = value
        End Set
    End Property

    Private moneda_ As String = ""
    Public Property moneda() As String
        Get
            Return moneda_
        End Get
        Set(ByVal value As String)
            moneda_ = value
        End Set
    End Property

    Private idComprobantesicy_ As Integer = 0
    Public Property idComprobantesicy() As Integer
        Get
            Return idComprobantesicy_
        End Get
        Set(ByVal value As Integer)
            idComprobantesicy_ = value
        End Set
    End Property

    Private RegimenFiscal_ As String = ""

    Public Property RegimenFiscal() As String
        Get
            Return RegimenFiscal_
        End Get
        Set(ByVal value As String)
            RegimenFiscal_ = value
        End Set
    End Property
End Class
