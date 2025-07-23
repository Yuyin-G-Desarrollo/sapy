
Public Class TallasPorDocena

    Dim _Atado1 As New Atado
    Dim _Atado2 As New Atado

    Public Property Atado1 As Atado
        Get
            Return _Atado1
        End Get
        Set(value As Atado)
            _Atado1 = value
        End Set
    End Property

    Public Property Atado2 As Atado
        Get
            Return _Atado2
        End Get
        Set(value As Atado)
            _Atado2 = value
        End Set
    End Property



End Class
