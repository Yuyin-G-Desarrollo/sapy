Public Class SubsidioEmpleo
    Private subsidioempleoid As Integer
    Public Property SESubsidioEmpleoId() As Integer
        Get
            Return subsidioempleoid
        End Get
        Set(ByVal value As Integer)
            subsidioempleoid = value
        End Set
    End Property

    Private limiteinferior As Double
    Public Property SELimiteinferior() As Double
        Get
            Return limiteinferior
        End Get
        Set(ByVal value As Double)
            limiteinferior = value
        End Set
    End Property

    Private limitesuperior As Double
    Public Property SELimitesuperior() As Double
        Get
            Return limitesuperior
        End Get
        Set(ByVal value As Double)
            limitesuperior = value
        End Set
    End Property

    Private valorspe As Double
    Public Property SEValorspe() As Double
        Get
            Return valorspe
        End Get
        Set(ByVal value As Double)
            valorspe = value
        End Set
    End Property

    Private tipo As String
    Public Property SETipo() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property

    Private activo As Boolean
    Public Property SEActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property
End Class
