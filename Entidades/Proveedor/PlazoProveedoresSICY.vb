Public Class PlazoProveedoresSICY

    Private DiasCredito As Integer
    Public Property plpr_DiasCredito() As Integer
        Get
            Return DiasCredito
        End Get
        Set(ByVal value As Integer)
            DiasCredito = value
        End Set
    End Property

    Private IdProveedor As Integer
    Public Property plpr_IdProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

End Class
