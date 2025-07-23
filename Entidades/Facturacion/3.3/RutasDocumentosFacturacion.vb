Public Class RutasDocumentosFacturacion
    Private _EmpresaId As Integer
    Public Property EmpresaId() As Integer
        Get
            Return _EmpresaId
        End Get
        Set(ByVal value As Integer)
            _EmpresaId = value
        End Set
    End Property

    Private _TipoComprobanteId As Integer
    Public Property TipoComprobanteId() As Integer
        Get
            Return _TipoComprobanteId
        End Get
        Set(ByVal value As Integer)
            _TipoComprobanteId = value
        End Set
    End Property

    Private _TipoDocumento As String
    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As String)
            _TipoDocumento = value
        End Set
    End Property

    Private _RutaServicioRest As String
    Public Property RutaServicioRest() As String
        Get
            Return _RutaServicioRest
        End Get
        Set(ByVal value As String)
            _RutaServicioRest = value
        End Set
    End Property


    Private _RutaCliente As String
    Public Property RutaCliente() As String
        Get
            Return _RutaCliente
        End Get
        Set(ByVal value As String)
            _RutaCliente = value
        End Set
    End Property

    Private _RutaSICY As String
    Public Property RutaSICY() As String
        Get
            Return _RutaSICY
        End Get
        Set(ByVal value As String)
            _RutaSICY = value
        End Set
    End Property

    Private _TipoComprobante As String
    Public Property Tipocomprobante() As String
        Get
            Return _TipoComprobante
        End Get
        Set(ByVal value As String)
            _TipoComprobante = value
        End Set
    End Property

    Private _rutaContabilidad As String
    Public Property RutaContabilidad() As String
        Get
            Return _rutaContabilidad
        End Get
        Set(ByVal value As String)
            _rutaContabilidad = value
        End Set
    End Property
End Class
