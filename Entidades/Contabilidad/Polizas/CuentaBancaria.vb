
Public Class CuentaBancaria

    Private Pcuentaid As Integer
    Public Property cuentaid() As Integer
        Get
            Return Pcuentaid
        End Get
        Set(ByVal value As Integer)
            Pcuentaid = value
        End Set
    End Property

    Private Pnumero As String
    Public Property numero() As String
        Get
            Return Pnumero
        End Get
        Set(ByVal value As String)
            Pnumero = value
        End Set
    End Property

    Private Pcuentahabiente As String
    Public Property cuentahabiente() As String
        Get
            Return Pcuentahabiente
        End Get
        Set(ByVal value As String)
            Pcuentahabiente = value
        End Set
    End Property

    Private Pempresaid As EmpresaSAY_SICY
    Public Property empresaid() As EmpresaSAY_SICY
        Get
            Return Pempresaid
        End Get
        Set(ByVal value As EmpresaSAY_SICY)
            Pempresaid = value
        End Set
    End Property

    Private Pcuentasicyid As Integer
    Public Property cuentasicyid() As Integer
        Get
            Return Pcuentasicyid
        End Get
        Set(ByVal value As Integer)
            Pcuentasicyid = value
        End Set
    End Property

    Private Pbancoid As Bancos
    Public Property bancoid() As Bancos
        Get
            Return Pbancoid
        End Get
        Set(ByVal value As Bancos)
            Pbancoid = value
        End Set
    End Property


End Class
