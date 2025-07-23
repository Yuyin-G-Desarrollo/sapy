Public Class CuentaContable

    Private cuco_cuentacontableid As Integer
    Public Property PIdCuentaContable() As Integer
        Get
            Return cuco_cuentacontableid
        End Get
        Set(value As Integer)
            cuco_cuentacontableid = value
        End Set
    End Property


    Private cuco_constante1 As String
    Public Property PConstante1() As String
        Get
            Return cuco_constante1

        End Get
        Set(ByVal value As String)
            cuco_constante1 = value
        End Set
    End Property


    Private cuco_constante2 As String
    Public Property PConstante2() As String
        Get
            Return cuco_constante2
        End Get
        Set(ByVal value As String)
            cuco_constante2 = value
        End Set
    End Property


    Private cuco_letra As String
    Public Property PLetra As String
        Get
            Return cuco_letra
        End Get
        Set(value As String)
            cuco_letra = value
        End Set
    End Property


    Private cuco_consecutivo As String
    Public Property PConsecutivo As String
        Get
            Return cuco_consecutivo
        End Get
        Set(value As String)
            cuco_consecutivo = value
        End Set
    End Property


    Private cuco_cuentacontablecontpaqid As Integer
    Public Property PIDCuentaContableContpaq As Integer
        Get
            Return cuco_cuentacontablecontpaqid
        End Get
        Set(value As Integer)
            cuco_cuentacontablecontpaqid = value
        End Set
    End Property


    Private cuco_cuentacontablesicyid As Integer
    Public Property PIdCuentaContableSicy As Integer
        Get
            Return cuco_cuentacontablesicyid
        End Get
        Set(value As Integer)
            cuco_cuentacontablesicyid = value
        End Set
    End Property


    Private cuco_proveedorid As Integer
    Public Property PIdProveedor As Integer
        Get
            Return cuco_proveedorid
        End Get
        Set(value As Integer)
            cuco_proveedorid = value
        End Set
    End Property


    Private cuco_cuentacontabletipoid As Integer
    Public Property PIdTipoCuenta As Integer
        Get
            Return cuco_cuentacontabletipoid
        End Get
        Set(value As Integer)
            cuco_cuentacontabletipoid = value
        End Set
    End Property


    Private cuco_empresaid As Integer
    Public Property PIdEmpresa As Integer
        Get
            Return cuco_empresaid
        End Get
        Set(value As Integer)
            cuco_empresaid = value
        End Set
    End Property


    Private cuco_clienteid As Integer
    Public Property PIdCliente As Integer
        Get
            Return cuco_clienteid
        End Get
        Set(value As Integer)
            cuco_clienteid = value
        End Set
    End Property


    Private cuco_status As Boolean
    Public Property PStatus As Boolean
        Get
            Return cuco_status
        End Get
        Set(value As Boolean)
            cuco_status = value
        End Set
    End Property


    Private cuco_descripcion As String
    Public Property PDescripcion As String
        Get
            Return cuco_descripcion
        End Get
        Set(value As String)
            cuco_descripcion = value
        End Set
    End Property

End Class


