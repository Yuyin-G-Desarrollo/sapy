Public Class DatosPago
    Private semanaPago_ As Integer = 0
    Public Property semanaPago() As Integer
        Get
            Return semanaPago_
        End Get
        Set(ByVal value As Integer)
            semanaPago_ = value
        End Set
    End Property

    Private añoPago_ As Integer = 0
    Public Property añoPago() As Integer
        Get
            Return añoPago_
        End Get
        Set(ByVal value As Integer)
            añoPago_ = value
        End Set
    End Property
    Private fechaPago_ As Date
    Public Property fechaPago() As Date
        Get
            Return fechaPago_
        End Get
        Set(ByVal value As Date)
            fechaPago_ = value
        End Set
    End Property
    Private semanaCompra_ As Integer = 0
    Public Property semanaCompra() As Integer
        Get
            Return semanaCompra_
        End Get
        Set(ByVal value As Integer)
            semanaCompra_ = value
        End Set
    End Property
    Private añoCompra_ As Integer = 0
    Public Property añoCompra() As Integer
        Get
            Return añoCompra_
        End Get
        Set(ByVal value As Integer)
            añoCompra_ = value
        End Set
    End Property
End Class
