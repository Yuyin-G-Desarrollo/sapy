Public Class Hormas

    Private idHorma As Int32
    Private Horma As String
    Private ActivoH As String

    Public Property PidHorma As Int32
        Get
            Return idHorma
        End Get
        Set(ByVal value As Int32)
            idHorma = value
        End Set
    End Property

    Public Property PHorma As String
        Get
            Return Horma
        End Get
        Set(ByVal value As String)
            Horma = value
        End Set
    End Property

    Public Property PActivoHorma As String
        Get
            Return ActivoH
        End Get
        Set(ByVal value As String)
            ActivoH = value
        End Set
    End Property

End Class
