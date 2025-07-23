Public Class ProveedorNave

    Private activo As String
    Public Property dana_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property

    Private naveid2 As Integer
    Public Property dana_naveid() As Integer
        Get
            Return naveid2
        End Get
        Set(ByVal value As Integer)
            naveid2 = value
        End Set
    End Property


Private proveedorid As integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

    Private naveid As Integer
    Public Property nave_naveid() As Integer
        Get
            Return naveid
        End Get
        Set(ByVal value As Integer)
            naveid = value
        End Set
    End Property

Private usuariocreoid As integer
    Public Property dana_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodifico As integer
    Public Property dana_usuariomodifico() As Integer
        Get
            Return usuariomodifico
        End Get
        Set(ByVal value As Integer)
            usuariomodifico = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property dana_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property dana_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

    







End Class
