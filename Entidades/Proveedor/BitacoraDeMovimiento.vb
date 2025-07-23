Public Class BitacoraDeMovimiento

    Private fecha As DateTime
    Public Property bimo_fecha() As DateTime
        Get
            Return fecha
        End Get
        Set(ByVal value As DateTime)
            fecha = value
        End Set
    End Property

Private usuario As string
    Public Property bimo_usuario() As String
        Get
            Return usuario
        End Get
        Set(ByVal value As String)
            usuario = value
        End Set
    End Property

Private campo As String
    Public Property bimo_campo() As String
        Get
            Return campo
        End Get
        Set(ByVal value As String)
            campo = value
        End Set
    End Property

Private datoanterior As String
    Public Property bimo_datoanterior() As String
        Get
            Return datoanterior
        End Get
        Set(ByVal value As String)
            datoanterior = value
        End Set
    End Property

Private datonuevo As String
    Public Property bimo_datonuevo() As String
        Get
            Return datonuevo
        End Get
        Set(ByVal value As String)
            datonuevo = value
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
    Public Property bimo_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodificoid As integer
    Public Property bimo_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property bimo_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property bimo_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property












End Class
