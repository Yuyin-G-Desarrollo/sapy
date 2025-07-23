Public Class ListaVentas
    Private idListaVentas As Int32
    Private nombreLV As String
    Private idCapturado As String
    Private porcentaje As Boolean
    Private incremento As Integer

    Public Property PidListaVentas As Int32
        Get
            Return idListaVentas
        End Get
        Set(value As Int32)
            idListaVentas = value
        End Set
    End Property

    Public Property PnombreLV As String
        Get
            Return nombreLV
        End Get
        Set(value As String)
            nombreLV = value
        End Set
    End Property

    Public Property PidCapturado As String
        Get
            Return idCapturado
        End Get
        Set(value As String)
            idCapturado = value
        End Set
    End Property

    Public Property Pporcentaje As Boolean
        Get
            Return porcentaje
        End Get
        Set(value As Boolean)
            porcentaje = value
        End Set
    End Property

    Public Property Pincremento As Int32
        Get
            Return incremento
        End Get
        Set(value As Int32)
            incremento = value
        End Set
    End Property


End Class
