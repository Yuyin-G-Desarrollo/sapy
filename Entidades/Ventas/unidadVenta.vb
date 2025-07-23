
Public Class UnidadVenta

    Private Punidadventaid As Integer
    Public Property unidadventaid() As Integer
        Get
            Return Punidadventaid
        End Get
        Set(ByVal value As Integer)
            Punidadventaid = value
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
