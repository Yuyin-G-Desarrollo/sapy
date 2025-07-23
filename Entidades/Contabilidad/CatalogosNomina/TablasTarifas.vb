Public Class TablasTarifas
    Private tarifaid As Integer
    Private tipo As String
    Private limiteinferior As Double
    Private limitesuperior As Double
    Private cuotafija As Double
    Private porcentaje As Double

    Public Property PTarifaId As Integer
        Get
            Return tarifaid
        End Get
        Set(value As Integer)
            tarifaid = value
        End Set
    End Property

    Public Property PTipo As String
        Get
            Return tipo
        End Get
        Set(value As String)
            tipo = value
        End Set
    End Property

    Public Property PLimiteInferior As Double
        Get
            Return limiteinferior
        End Get
        Set(value As Double)
            limiteinferior = value
        End Set
    End Property

    Public Property PLimiteSuperior As Double
        Get
            Return limitesuperior
        End Get
        Set(value As Double)
            limitesuperior = value
        End Set
    End Property

    Public Property PCuotaFija As Double
        Get
            Return cuotafija
        End Get
        Set(value As Double)
            cuotafija = value
        End Set
    End Property

    Public Property PPorcentaje As Double
        Get
            Return porcentaje
        End Get
        Set(value As Double)
            porcentaje = value
        End Set
    End Property

End Class
