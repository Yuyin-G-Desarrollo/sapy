Public Class DiasAtrasadosDep

    Private dias_ As Double
    Public Property diasAtrasados() As Double
        Get
            Return dias_
        End Get
        Set(ByVal value As Double)
            dias_ = value
        End Set
    End Property

    Private departamento_ As String
    Public Property departamento() As String
        Get
            Return departamento_
        End Get
        Set(ByVal value As String)
            departamento_ = value
        End Set
    End Property

    Private motivoAtraso_ As String
    Public Property motivoAtraso() As String
        Get
            Return motivoAtraso_
        End Get
        Set(ByVal value As String)
            motivoAtraso_ = value
        End Set
    End Property

End Class
