Public Class PielCliente

    Private idPielCliente_ As Integer
    Public Property idPielCliente() As Integer
        Get
            Return idPielCliente_
        End Get
        Set(ByVal value As Integer)
            idPielCliente_ = value
        End Set
    End Property

    Private idPiel_ As Integer
    Public Property idPiel() As Integer
        Get
            Return idPiel_
        End Get
        Set(ByVal value As Integer)
            idPiel_ = value
        End Set
    End Property

    Private nombrePiel_ As String
    Public Property nombrePiel() As String
        Get
            Return nombrePiel_
        End Get
        Set(ByVal value As String)
            nombrePiel_ = value
        End Set
    End Property

    Private codigoSICYPiel_ As String
    Public Property codigoSICYPiel() As String
        Get
            Return codigoSICYPiel_
        End Get
        Set(ByVal value As String)
            codigoSICYPiel_ = value
        End Set
    End Property

    Private codigoClientePiel_ As String
    Public Property codigoClientePiel() As String
        Get
            Return codigoClientePiel_
        End Get
        Set(ByVal value As String)
            codigoClientePiel_ = value
        End Set
    End Property

    Private nombreClientePiel_ As String
    Public Property nombreClientePiel() As String
        Get
            Return nombreClientePiel_
        End Get
        Set(ByVal value As String)
            nombreClientePiel_ = value
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
