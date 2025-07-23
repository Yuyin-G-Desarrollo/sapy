Public Class ColorCliente

    Private idColorCliente_ As Integer
    Public Property idColorCliente() As Integer
        Get
            Return idColorCliente_
        End Get
        Set(ByVal value As Integer)
            idColorCliente_ = value
        End Set
    End Property

    Private idColor_ As Integer
    Public Property idColor() As Integer
        Get
            Return idColor_
        End Get
        Set(ByVal value As Integer)
            idColor_ = value
        End Set
    End Property

    Private nombreColor_ As String
    Public Property nombreColor() As String
        Get
            Return nombreColor_
        End Get
        Set(ByVal value As String)
            nombreColor_ = value
        End Set
    End Property

    Private codigoSICYColor_ As String
    Public Property codigoSICYColor() As String
        Get
            Return codigoSICYColor_
        End Get
        Set(ByVal value As String)
            codigoSICYColor_ = value
        End Set
    End Property

    Private codigoClienteColor_ As String
    Public Property codigoClienteColor() As String
        Get
            Return codigoClienteColor_
        End Get
        Set(ByVal value As String)
            codigoClienteColor_ = value
        End Set
    End Property

    Private nombreClienteColor_ As String
    Public Property nombreClienteColor() As String
        Get
            Return nombreClienteColor_
        End Get
        Set(ByVal value As String)
            nombreClienteColor_ = value
        End Set
    End Property

    Private idCliente_ As Integer
    Public Property idCliente() As Integer
        Get
            Return idCliente_
        End Get
        Set(ByVal value As Integer)
            idCliente_ = value
        End Set
    End Property
End Class
