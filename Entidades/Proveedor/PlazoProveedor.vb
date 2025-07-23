Public Class PlazoProveedor

    Private plazopago As Integer
    Public Property plpa_plazopago() As Integer
        Get
            Return plazopago
        End Get
        Set(ByVal value As Integer)
            plazopago = value
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

Private usuariocreoid As integer
    Public Property plpr_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodifico As integer
    Public Property plpr_usuariomodifico() As Integer
        Get
            Return usuariomodifico
        End Get
        Set(ByVal value As Integer)
            usuariomodifico = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property plpr_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property plpr_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property







End Class
