
Public Class FacturaCancelada

    Private PFechaCancelacion As String
    Public Property FechaCancelacion() As String
        Get
            Return PFechaCancelacion
        End Get
        Set(ByVal value As String)
            PFechaCancelacion = value
        End Set
    End Property

    Private PEstatusCancelacionID As String
    Public Property EstatusCancelacionID() As String
        Get
            Return PEstatusCancelacionID
        End Get
        Set(ByVal value As String)
            PEstatusCancelacionID = value
        End Set
    End Property

    Private PDescripcionEstatusCancelacion As String
    Public Property DescripcionEstatusCancelacion() As String
        Get
            Return PDescripcionEstatusCancelacion
        End Get
        Set(ByVal value As String)
            PDescripcionEstatusCancelacion = value
        End Set
    End Property


    Private PDocumentoID As Integer
    Public Property DocumentoID() As Integer
        Get
            Return PDocumentoID
        End Get
        Set(ByVal value As Integer)
            PDocumentoID = value
        End Set
    End Property

    Private PTipoComprobante As String
    Public Property TipoComprobante() As String
        Get
            Return PTipoComprobante
        End Get
        Set(ByVal value As String)
            PTipoComprobante = value
        End Set
    End Property

    Private PUUID As String
    Public Property UUID() As String
        Get
            Return PUUID
        End Get
        Set(ByVal value As String)
            PUUID = value
        End Set
    End Property

    Private PEmpresaID As String
    Public Property EmpresaID() As String
        Get
            Return PEmpresaID
        End Get
        Set(ByVal value As String)
            PEmpresaID = value
        End Set
    End Property

    Private PUsuarioID As String
    Public Property UsuarioID() As String
        Get
            Return PUsuarioID
        End Get
        Set(ByVal value As String)
            PUsuarioID = value
        End Set
    End Property

    Private PEstatusID As Integer
    Public Property EstatusID() As Integer
        Get
            Return PEstatusID
        End Get
        Set(ByVal value As Integer)
            PEstatusID = value
        End Set
    End Property


End Class
