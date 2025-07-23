Public Class NumerosGuia
    Private _Referencia As String
    Private _NumeroGuia As String
    Private _Status As Integer
    Private _Repetida As Integer
    Private _CapturadoA As Integer


    Public Property Referencia As String
        Get
            Return _Referencia
        End Get
        Set(value As String)
            _Referencia = value
        End Set
    End Property

    Public Property NumeroGuia As String
        Get
            Return _NumeroGuia
        End Get
        Set(value As String)
            _NumeroGuia = value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return _Status
        End Get
        Set(value As Integer)
            _Status = value
        End Set
    End Property

    Public Property Repetida As Integer
        Get
            Return _Repetida
        End Get
        Set(value As Integer)
            _Repetida = value
        End Set
    End Property

    Public Property CapturadoA As Integer
        Get
            Return _CapturadoA
        End Get
        Set(value As Integer)
            _CapturadoA = value
        End Set
    End Property
End Class
