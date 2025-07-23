Public Class RetencionISR_SPE
    Private calculoIsrspeid As Integer
    Public Property RISCalculoIsrspeid() As Integer
        Get
            Return calculoIsrspeid
        End Get
        Set(ByVal value As Integer)
            calculoIsrspeid = value
        End Set
    End Property

    Private colaboradorId As Integer
    Public Property RISColaboradorId() As Integer
        Get
            Return colaboradorId
        End Get
        Set(ByVal value As Integer)
            colaboradorId = value
        End Set
    End Property

    Private periodonominafiscalid As Integer
    Public Property RISPeriodonominafiscalid() As Integer
        Get
            Return periodonominafiscalid
        End Get
        Set(ByVal value As Integer)
            periodonominafiscalid = value
        End Set
    End Property

    Private salariosemanalid As Integer
    Public Property RISSalariosemanalid() As Integer
        Get
            Return salariosemanalid
        End Get
        Set(ByVal value As Integer)
            salariosemanalid = value
        End Set
    End Property


    Private tarifamensualsemanalid As Integer
    Public Property RISTarifamensualsemanalid() As Integer
        Get
            Return tarifamensualsemanalid
        End Get
        Set(ByVal value As Integer)
            tarifamensualsemanalid = value
        End Set
    End Property

    Private subsidioempleoid As Integer
    Public Property RISSubsidioempleoid() As Integer
        Get
            Return subsidioempleoid
        End Get
        Set(ByVal value As Integer)
            subsidioempleoid = value
        End Set
    End Property

    Private salariosemanalgravado As Double
    Public Property RISSalariosemanalgravado() As Double
        Get
            Return salariosemanalgravado
        End Get
        Set(ByVal value As Double)
            salariosemanalgravado = value
        End Set
    End Property

    Private limiteinferior As Double
    Public Property RISLimiteinferior() As Double
        Get
            Return limiteinferior
        End Get
        Set(ByVal value As Double)
            limiteinferior = value
        End Set
    End Property

    Private excedentelimiteinferior As Double
    Public Property RISExcedentelimiteinferior() As Double
        Get
            Return excedentelimiteinferior
        End Get
        Set(ByVal value As Double)
            excedentelimiteinferior = value
        End Set
    End Property

    Private tasa As Double
    Public Property RISTasa() As Double
        Get
            Return tasa
        End Get
        Set(ByVal value As Double)
            tasa = value
        End Set
    End Property

    Private impuestomarginal As Double
    Public Property RISImpuestomarginal() As Double
        Get
            Return impuestomarginal
        End Get
        Set(ByVal value As Double)
            impuestomarginal = value
        End Set
    End Property

    Private cuotafija As Double
    Public Property RISCuotafija() As Double
        Get
            Return cuotafija
        End Get
        Set(ByVal value As Double)
            cuotafija = value
        End Set
    End Property

    Private ISRdeterminado As Double
    Public Property RISISRdeterminado() As Double
        Get
            Return ISRdeterminado
        End Get
        Set(ByVal value As Double)
            ISRdeterminado = value
        End Set
    End Property

    Private SPEcalculado As Double
    Public Property RISSPEcalculado() As Double
        Get
            Return SPEcalculado
        End Get
        Set(ByVal value As Double)
            SPEcalculado = value
        End Set
    End Property

    Private SPEpagado As Double
    Public Property RISSPEpagado() As Double
        Get
            Return SPEpagado
        End Get
        Set(ByVal value As Double)
            SPEpagado = value
        End Set
    End Property

    Private ISRretenido As Double
    Public Property RISISRretenido() As Double
        Get
            Return ISRretenido
        End Get
        Set(ByVal value As Double)
            ISRretenido = value
        End Set
    End Property

    Private SPECausado As Double
    Public Property PSPECausado As Double
        Get
            Return SPECausado
        End Get
        Set(value As Double)
            SPECausado = value
        End Set
    End Property
End Class
