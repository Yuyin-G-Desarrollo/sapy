
Public Class TipoEntrega

    Private Ptipoentregaid As Integer
    Public Property tipoentregaid() As Integer
        Get
            Return Ptipoentregaid
        End Get
        Set(ByVal value As Integer)
            Ptipoentregaid = value
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
