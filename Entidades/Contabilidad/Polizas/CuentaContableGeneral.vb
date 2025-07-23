Public Class CuentaContableGeneral

    Private Pcuentageneralid As Integer
    Public Property cuentageneralid() As Integer
        Get
            Return Pcuentageneralid
        End Get
        Set(ByVal value As Integer)
            Pcuentageneralid = value
        End Set
    End Property

    Private Pempresa As EmpresaSAY_SICY
    Public Property empresa() As EmpresaSAY_SICY
        Get
            Return Pempresa
        End Get
        Set(ByVal value As EmpresaSAY_SICY)
            Pempresa = value
        End Set
    End Property

    Private Pcuenta As String
    Public Property cuenta() As String
        Get
            Return Pcuenta
        End Get
        Set(ByVal value As String)
            Pcuenta = value
        End Set
    End Property

    Private Pcuentacontpaq As Integer
    Public Property cuentacontpaq() As Integer
        Get
            Return Pcuentacontpaq
        End Get
        Set(ByVal value As Integer)
            Pcuentacontpaq = value
        End Set
    End Property

    Private Pcuentasay As Integer
    Public Property cuentasay() As Integer
        Get
            Return Pcuentasay
        End Get
        Set(ByVal value As Integer)
            Pcuentasay = value
        End Set
    End Property

    Private Pnombre As String
    Public Property nombre() As String
        Get
            Return Pnombre
        End Get
        Set(ByVal value As String)
            Pnombre = value
        End Set
    End Property

    Private Ptipopoliza As TipoPoliza
    Public Property tipopoliza() As TipoPoliza
        Get
            Return Ptipopoliza
        End Get
        Set(ByVal value As TipoPoliza)
            Ptipopoliza = value
        End Set
    End Property

    Private Pclave As String
    Public Property clave() As String
        Get
            Return Pclave
        End Get
        Set(ByVal value As String)
            Pclave = value
        End Set
    End Property

    Private Pcuentabancaria As CuentaBancaria
    Public Property cuentabancaria() As CuentaBancaria
        Get
            Return Pcuentabancaria
        End Get
        Set(ByVal value As CuentaBancaria)
            Pcuentabancaria = value
        End Set
    End Property

    Private PtipopolizaContpaq As Integer
    Public Property tipopolizaContpaq() As Integer
        Get
            Return PtipopolizaContpaq
        End Get
        Set(ByVal value As Integer)
            PtipopolizaContpaq = value
        End Set
    End Property


End Class
