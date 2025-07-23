
Public Class Moneda

    Private Pmonedaid As Integer
    Public Property monedaid() As Integer
        Get
            Return Pmonedaid
        End Get
        Set(ByVal value As Integer)
            Pmonedaid = value
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

    Private Pabreviatura As String
    Public Property abreviatura() As String
        Get
            Return Pabreviatura
        End Get
        Set(ByVal value As String)
            Pabreviatura = value
        End Set
    End Property

    Private Psimbolo As String
    Public Property simbolo() As String
        Get
            Return Psimbolo
        End Get
        Set(ByVal value As String)
            Psimbolo = value
        End Set
    End Property

    Private Pposicionsimbolo As String
    Public Property posicionsimbolo() As String
        Get
            Return Pposicionsimbolo
        End Get
        Set(ByVal value As String)
            Pposicionsimbolo = value
        End Set
    End Property

    Private Pnacional As Boolean
    Public Property nacional() As Boolean
        Get
            Return Pnacional
        End Get
        Set(ByVal value As Boolean)
            Pnacional = value
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
