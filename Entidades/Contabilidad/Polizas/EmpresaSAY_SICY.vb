
Public Class EmpresaSAY_SICY

    Private Pempresaid As Integer
    Public Property empresaid() As Integer
        Get
            Return Pempresaid
        End Get
        Set(ByVal value As Integer)
            Pempresaid = value
        End Set
    End Property

    Private Psayid As Integer
    Public Property sayid() As Integer
        Get
            Return Psayid
        End Get
        Set(ByVal value As Integer)
            Psayid = value
        End Set
    End Property

    Private Pcontribuyentesicyid As Integer
    Public Property contribuyentesicyid() As Integer
        Get
            Return Pcontribuyentesicyid
        End Get
        Set(ByVal value As Integer)
            Pcontribuyentesicyid = value
        End Set
    End Property

    Private Prazonsocial As String
    Public Property razonsocial() As String
        Get
            Return Prazonsocial
        End Get
        Set(ByVal value As String)
            Prazonsocial = value
        End Set
    End Property

    Private Pservidor As String
    Public Property servidor() As String
        Get
            Return Pservidor
        End Get
        Set(ByVal value As String)
            Pservidor = value
        End Set
    End Property

    Private Pdoctoventassicyid As String
    Public Property doctoventassicyid() As String
        Get
            Return Pdoctoventassicyid
        End Get
        Set(ByVal value As String)
            Pdoctoventassicyid = value
        End Set
    End Property

    Private Pempresacontpaq As String
    Public Property empresacontpaq() As String
        Get
            Return Pempresacontpaq
        End Get
        Set(ByVal value As String)
            Pempresacontpaq = value
        End Set
    End Property

End Class
