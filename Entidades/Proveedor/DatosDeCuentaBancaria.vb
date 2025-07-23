Public Class DatosDeCuentaBancaria

    Private banco As String
    Public Property dcba_banco() As String
        Get
            Return banco
        End Get
        Set(ByVal value As String)
            banco = value
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

    Private bancoid As Integer
    Public Property dage_bancoid() As Integer
        Get
            Return bancoid
        End Get
        Set(ByVal value As Integer)
            bancoid = value
        End Set
    End Property

Private cuenta As String
    Public Property dcba_cuenta() As String
        Get
            Return cuenta
        End Get
        Set(ByVal value As String)
            cuenta = value
        End Set
    End Property

Private clabe As String
    Public Property dcba_clabe() As String
        Get
            Return clabe
        End Get
        Set(ByVal value As String)
            clabe = value
        End Set
    End Property

Private cuentahabiente As String
    Public Property dcba_cuentahabiente() As String
        Get
            Return cuentahabiente
        End Get
        Set(ByVal value As String)
            cuentahabiente = value
        End Set
    End Property

Private plaza As String
    Public Property dcba_plaza() As String
        Get
            Return plaza
        End Get
        Set(ByVal value As String)
            plaza = value
        End Set
    End Property

Private sucursal As String
    Public Property dcba_sucursal() As String
        Get
            Return sucursal
        End Get
        Set(ByVal value As String)
            sucursal = value
        End Set
    End Property

    Private predeterminada As String
    Public Property dcba_predeterminada() As String
        Get
            Return predeterminada
        End Get
        Set(ByVal value As String)
            predeterminada = value
        End Set
    End Property

    Private activa As String
    Public Property dcba_activa() As String
        Get
            Return activa
        End Get
        Set(ByVal value As String)
            activa = value
        End Set
    End Property

Private fechadealta As datetime
    Public Property dcba_fechadealta() As DateTime
        Get
            Return fechadealta
        End Get
        Set(ByVal value As DateTime)
            fechadealta = value
        End Set
    End Property

Private usuariocreo As String
    Public Property dcba_usuariocreo() As String
        Get
            Return usuariocreo
        End Get
        Set(ByVal value As String)
            usuariocreo = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property dcba_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

Private usuariomodifico As String
    Public Property dcba_usuariomodifico() As String
        Get
            Return usuariomodifico
        End Get
        Set(ByVal value As String)
            usuariomodifico = value
        End Set
    End Property

    'Private proveedorid As integer
    '    Public Property prov_proveedorid() As Integer
    '        Get
    '            Return proveedorid
    '        End Get
    '        Set(ByVal value As Integer)
    '            proveedorid = value
    '        End Set
    '    End Property

Private usuariocreoid As integer
    Public Property dcba_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodificoid As integer
    Public Property dcba_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property dcba_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

    Private tipodecuenta As String
    Public Property dcba_tipodecuenta() As String
        Get
            Return tipodecuenta
        End Get
        Set(ByVal value As String)
            tipodecuenta = value
        End Set
    End Property

    Private rfc As String
    Public Property dcba_rfc() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private datosdecuentabancariaid As Integer
    Public Property dcba_datosdecuentabancariaid() As Integer
        Get
            Return datosdecuentabancariaid
        End Get
        Set(ByVal value As Integer)
            datosdecuentabancariaid = value
        End Set
    End Property


End Class
