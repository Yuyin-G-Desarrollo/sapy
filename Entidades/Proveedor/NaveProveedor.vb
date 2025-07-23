Public Class NaveProveedor

    Private activo As String
    Public Property prna_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property

    Private proveedorid As Integer
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

    Private usuariocreoid As Integer
    Public Property prna_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property prna_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As DateTime
    Public Property prna_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As DateTime
    Public Property prna_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

End Class
