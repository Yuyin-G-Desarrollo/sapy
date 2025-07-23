Public Class Corridas

    Private IdCorrida As Integer
    Private Corrida As String

    Public Property PIdCorrida As Int32
        Get
            Return IdCorrida
        End Get
        Set(value As Int32)
            IdCorrida = value
        End Set
    End Property

    Public Property PCorrida As String
        Get
            Return Corrida
        End Get
        Set(value As String)
            Corrida = value
        End Set
    End Property

End Class
