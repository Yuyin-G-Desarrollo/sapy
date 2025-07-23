Public Class SalidaDePares
    Private paresdeSalida As DataTable
    Public Property pParesdeSalida() As DataTable
        Get
            Return paresdeSalida
        End Get
        Set(ByVal value As DataTable)
            paresdeSalida = value
        End Set
    End Property
    Private idOTCoppel As Int32
    Public Property pidOTCoppel() As Int32
        Get
            Return idOTCoppel
        End Get
        Set(ByVal value As Int32)
            idOTCoppel = value
        End Set
    End Property

End Class
