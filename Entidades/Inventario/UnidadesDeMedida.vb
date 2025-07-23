Public Class UnidadesDeMedida
    Private nombreUnidad_ As String
    Public Property nombreUnidad() As String
        Get
            Return nombreUnidad_
        End Get
        Set(ByVal value As String)
            nombreUnidad_ = value
        End Set
    End Property

    Private total_ As Double
    Public Property total() As Double
        Get
            Return total_
        End Get
        Set(ByVal value As Double)
            total_ = value
        End Set
    End Property

End Class
