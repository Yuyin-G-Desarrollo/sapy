Public Class EntregaPagosProveedor
    Private IdTabla As Integer
    Private tipo As Integer
    Private UsuarioId As Integer
    Private ProveedorId As Integer
    Private SemanaPago As Integer
    Private AñoPago As Integer
    Private NaveId As Integer
    Private UsuarioNombre As String
    Private SiguienteFolio As String
    Private FormaPago As Integer


    Public Property PIdTabla() As Integer
        Get
            Return IdTabla
        End Get
        Set(ByVal value As Integer)
            IdTabla = value
        End Set
    End Property

    Public Property PTipo() As Integer
        Get
            Return tipo
        End Get
        Set(ByVal value As Integer)
            tipo = value
        End Set
    End Property

    Public Property PUsuarioId() As Integer
        Get
            Return UsuarioId
        End Get
        Set(ByVal value As Integer)
            UsuarioId = value
        End Set
    End Property

    Public Property PProveedorId() As Integer
        Get
            Return ProveedorId
        End Get
        Set(ByVal value As Integer)
            ProveedorId = value
        End Set
    End Property

    Public Property PSemanaPago() As Integer
        Get
            Return SemanaPago
        End Get
        Set(ByVal value As Integer)
            SemanaPago = value
        End Set
    End Property

    Public Property PAñoPago() As Integer
        Get
            Return AñoPago
        End Get
        Set(ByVal value As Integer)
            AñoPago = value
        End Set
    End Property

    Public Property PNaveId() As Integer
        Get
            Return NaveId
        End Get
        Set(ByVal value As Integer)
            NaveId = value
        End Set
    End Property

    Public Property PUsuarioNombre() As String
        Get
            Return UsuarioNombre
        End Get
        Set(ByVal value As String)
            UsuarioNombre = value
        End Set
    End Property


    Public Property PSiguienteFolio() As String
        Get
            Return SiguienteFolio
        End Get
        Set(ByVal value As String)
            SiguienteFolio = value
        End Set
    End Property

    Public Property PFormaPago() As Integer
        Get
            Return FormaPago
        End Get
        Set(ByVal value As Integer)
            FormaPago = value
        End Set
    End Property


End Class
