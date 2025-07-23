Public Class ZapateriaCompetencia

    Private Pzapateriasid As Integer
    Public Property zapateriasid() As Integer
        Get
            Return Pzapateriasid
        End Get
        Set(ByVal value As Integer)
            Pzapateriasid = value
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

    Private Pclienteyuyin As Boolean
    Public Property clienteyuyin() As Boolean
        Get
            Return Pclienteyuyin
        End Get
        Set(ByVal value As Boolean)
            Pclienteyuyin = value
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
