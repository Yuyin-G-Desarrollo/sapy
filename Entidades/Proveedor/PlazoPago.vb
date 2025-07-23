Public Class PlazoPago

    Private plazoproveedorid As Integer
    Public Property plpr_plazoproveedorid() As Integer
        Get
            Return plazoproveedorid
        End Get
        Set(ByVal value As Integer)
            plazoproveedorid = value
        End Set
    End Property


    Private plazopagoid As Integer
    Public Property plpa_plazopagoid() As Integer
        Get
            Return plazopagoid
        End Get
        Set(ByVal value As Integer)
            plazopagoid = value
        End Set
    End Property

    Private plazo As String
    Public Property plpa_plazo() As String
        Get
            Return plazo
        End Get
        Set(ByVal value As String)
            plazo = value
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

Private usuariocreoid As integer
    Public Property plpr_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodificoid As integer
    Public Property plpr_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As DateTime
    Public Property plpr_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As DateTime
    Public Property plpr_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property







End Class
