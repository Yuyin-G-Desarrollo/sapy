Public Class HorasExtras
    Private RetardosMenores As Int32
    Private RetardosMayores As Int32
    Private Faltas As Int32
    Private Periodo As Int32
    Private ColaboradorId As Int32
    Private HorasExtrasPeriodo As Double
    Private Monto As Double



    Public Property PMonto As Double
        Get
            Return Monto
        End Get
        Set(ByVal value As Double)
            Monto = value
        End Set
    End Property

    Public Property PHorasExtrasPeriodo As Double
        Get
            Return HorasExtrasPeriodo
        End Get
        Set(ByVal value As Double)
            HorasExtrasPeriodo = value
        End Set
    End Property

    Public Property PColaboradorid As Int32
        Get
            Return ColaboradorId
        End Get
        Set(ByVal value As Int32)
            ColaboradorId = value
        End Set
    End Property


    Public Property PPeriodo As Int32
        Get
            Return Periodo
        End Get
        Set(ByVal value As Int32)
            Periodo = value
        End Set
    End Property

    Public Property PRetardosMenores As Int32
        Get
            Return RetardosMenores

        End Get
        Set(ByVal value As Int32)
            RetardosMenores = value
        End Set
    End Property

    Public Property PRetardosMayores As Int32
        Get
            Return RetardosMayores
        End Get
        Set(ByVal value As Int32)
            RetardosMayores = value
        End Set
    End Property
    Public Property PFaltas As Int32
        Get
            Return Faltas
        End Get
        Set(ByVal value As Int32)
            Faltas = value
        End Set
    End Property
End Class
