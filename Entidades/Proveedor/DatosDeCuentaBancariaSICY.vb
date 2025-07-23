Public Class DatosDeCuentaBancariaSICY

    Private idProveedor As Integer
    Public Property banc_idProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Private idBanco As Integer
    Public Property banc_idBanco() As Integer
        Get
            Return idBanco
        End Get
        Set(ByVal value As Integer)
            idBanco = value
        End Set
    End Property

    Private cuentabco As String
    Public Property banc_cuentabco() As String
        Get
            Return cuentabco
        End Get
        Set(ByVal value As String)
            cuentabco = value
        End Set
    End Property

    Private cuentahabiente As String
    Public Property banc_cuentahabiente() As String
        Get
            Return cuentahabiente
        End Get
        Set(ByVal value As String)
            cuentahabiente = value
        End Set
    End Property


    Private usualta As String
    Public Property banc_usualta() As String
        Get
            Return usualta
        End Get
        Set(ByVal value As String)
            usualta = value
        End Set
    End Property

    Private fechaalta As Date
    Public Property banc_fechaalta() As Date
        Get
            Return fechaalta
        End Get
        Set(ByVal value As Date)
            fechaalta = value
        End Set
    End Property

    Private fiscal As String
    Public Property banc_fiscal() As String
        Get
            Return fiscal
        End Get
        Set(ByVal value As String)
            fiscal = value
        End Set
    End Property

    Private ClabeInterbancaria As String
    Public Property banc_ClabeInterbancaria() As String
        Get
            Return ClabeInterbancaria
        End Get
        Set(ByVal value As String)
            ClabeInterbancaria = value
        End Set
    End Property

    Private SucursalPlaza As String
    Public Property banc_SucursalPlaza() As String
        Get
            Return SucursalPlaza
        End Get
        Set(ByVal value As String)
            SucursalPlaza = value
        End Set
    End Property

    Private Predet As Integer
    Public Property banc_Predet() As Integer
        Get
            Return Predet
        End Get
        Set(ByVal value As Integer)
            Predet = value
        End Set
    End Property

    Private TelefonoCuenta As String
    Public Property banc_TelefonoCuenta() As String
        Get
            Return TelefonoCuenta
        End Get
        Set(ByVal value As String)
            TelefonoCuenta = value
        End Set
    End Property

    Private Email As String
    Public Property banc_Email() As String
        Get
            Return Email
        End Get
        Set(ByVal value As String)
            Email = value
        End Set
    End Property

    Private usubaja As String
    Public Property banc_usubaja() As String
        Get
            Return usubaja
        End Get
        Set(ByVal value As String)
            usubaja = value
        End Set
    End Property

    Private stCta As String
    Public Property banc_stCta() As String
        Get
            Return stCta
        End Get
        Set(ByVal value As String)
            stCta = value
        End Set
    End Property

    Private tipcta As Integer
    Public Property banc_tipcta() As Integer
        Get
            Return tipcta
        End Get
        Set(ByVal value As Integer)
            tipcta = value
        End Set
    End Property

    Private id As Integer
    Public Property banc_id() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property

End Class
