Public Class TarifaMensualSemanal
    Private tarifamensualsemanalid As Integer
    Public Property TMSTarifaId() As Integer
        Get
            Return tarifamensualsemanalid
        End Get
        Set(ByVal value As Integer)
            tarifamensualsemanalid = value
        End Set
    End Property

    Private limiteinferior As Double
    Public Property TMSLimiteinferior() As Double
        Get
            Return limiteinferior
        End Get
        Set(ByVal value As Double)
            limiteinferior = value
        End Set
    End Property

    Private limitesuperior As Double
    Public Property TMSLimitesuperior() As Double
        Get
            Return limitesuperior
        End Get
        Set(ByVal value As Double)
            limitesuperior = value
        End Set
    End Property

    Private cuotafija As Double
    Public Property TMSCuotafija() As Double
        Get
            Return cuotafija
        End Get
        Set(ByVal value As Double)
            cuotafija = value
        End Set
    End Property

    Private porcentajeexcedente As Double
    Public Property TMSPorcentajeexcedente() As Double
        Get
            Return porcentajeexcedente
        End Get
        Set(ByVal value As Double)
            porcentajeexcedente = value
        End Set
    End Property

    Private tipo As String
    Public Property TMSTipo() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property

    Private activo As Boolean
    Public Property TMSActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property
End Class
