
Public Class Atado

    Dim _Atado As New List(Of Entidades.TallasDevoluciones)


    Public Property Atado As List(Of Entidades.TallasDevoluciones)
        Get
            Return _Atado
        End Get
        Set(value As List(Of Entidades.TallasDevoluciones))
            _Atado = value
        End Set
    End Property

End Class
