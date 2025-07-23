Public Class ClienteRamo

    Private Pramoclienteid As Integer
    Public Property ramoclienteid() As Integer
        Get
            Return Pramoclienteid
        End Get
        Set(ByVal value As Integer)
            Pramoclienteid = value
        End Set
    End Property

    Private Pnumtiendas As Integer
    Public Property numtiendasreal() As Integer
        Get
            Return Pnumtiendas
        End Get
        Set(ByVal value As Integer)
            Pnumtiendas = value
        End Set
    End Property

    Private Pmarcaje As Decimal
    Public Property marcaje() As Decimal
        Get
            Return Pmarcaje
        End Get
        Set(ByVal value As Decimal)
            Pmarcaje = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Pramo As Ramo
    Public Property ramo() As Ramo
        Get
            Return Pramo
        End Get
        Set(ByVal value As Ramo)
            Pramo = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property


End Class
