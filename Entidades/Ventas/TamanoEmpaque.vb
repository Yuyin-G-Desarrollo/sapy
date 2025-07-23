Public Class TamanoEmpaque

    Private Ptamanoempaqueid As Integer
    Public Property tamanoempaqueid() As Integer
        Get
            Return Ptamanoempaqueid
        End Get
        Set(ByVal value As Integer)
            Ptamanoempaqueid = value
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

    Private Pactivo As String
    Public Property activo() As String
        Get
            Return Pactivo
        End Get
        Set(ByVal value As String)
            Pactivo = value
        End Set
    End Property

End Class
