
Public Class FormaPago

    Private Pformapagoid As Integer
    Public Property formapagoid() As Integer
        Get
            Return Pformapagoid
        End Get
        Set(ByVal value As Integer)
            Pformapagoid = value
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

    Private Pparcialidades As Integer
    Public Property parcialidades() As Integer
        Get
            Return Pparcialidades
        End Get
        Set(ByVal value As Integer)
            Pparcialidades = value
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
