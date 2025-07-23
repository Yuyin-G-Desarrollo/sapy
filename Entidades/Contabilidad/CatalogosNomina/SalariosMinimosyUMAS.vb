Public Class SalariosMinimosyUMAS
    Private _MontoSalarioMinimo As String
    Private _MontoUMA As String
    Private _Resp As Integer
    Private _Mensage As String

    Public Property MontoSalarioMinimo As String
        Get
            Return _MontoSalarioMinimo
        End Get
        Set(value As String)
            _MontoSalarioMinimo = value
        End Set
    End Property

    Public Property MontoUMA As String
        Get
            Return _MontoUMA
        End Get
        Set(value As String)
            _MontoUMA = value
        End Set
    End Property

    Public Property Resp As Integer
        Get
            Return _Resp
        End Get
        Set(value As Integer)
            _Resp = value
        End Set
    End Property

    Public Property Mensage As String
        Get
            Return _Mensage
        End Get
        Set(value As String)
            _Mensage = value
        End Set
    End Property
End Class
