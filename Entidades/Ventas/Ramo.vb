
Public Class Ramo

    Private Pramoid As Integer
    Public Property ramoid() As Integer
        Get
            Return Pramoid
        End Get
        Set(ByVal value As Integer)
            Pramoid = value
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

    Private Pnombrecorto As String
    Public Property nombrecorto() As String
        Get
            Return Pnombrecorto
        End Get
        Set(ByVal value As String)
            Pnombrecorto = value
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
