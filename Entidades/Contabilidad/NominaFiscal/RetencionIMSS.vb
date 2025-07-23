Public Class RetencionImss
    Private retencionImssId As Integer
    Public Property RIRetencionImssId() As Integer
        Get
            Return retencionImssId
        End Get
        Set(ByVal value As Integer)
            retencionImssId = value
        End Set
    End Property

    Private salarioDiario As Double
    Public Property RISalarioDiario() As Double
        Get
            Return salarioDiario
        End Get
        Set(ByVal value As Double)
            salarioDiario = value
        End Set
    End Property

    Private factorIntegracion As Double
    Public Property RIFactorIntegracion() As Double
        Get
            Return factorIntegracion
        End Get
        Set(ByVal value As Double)
            factorIntegracion = value
        End Set
    End Property

    Private salarioDiarioIntegrado As Double
    Public Property RISalarioDiarioIntegrado() As Double
        Get
            Return salarioDiarioIntegrado
        End Get
        Set(ByVal value As Double)
            salarioDiarioIntegrado = value
        End Set
    End Property

    Private factorImss As Double
    Public Property RIFactorImss() As Double
        Get
            Return factorImss
        End Get
        Set(ByVal value As Double)
            factorImss = value
        End Set
    End Property

    Private retencionDiaria As Double
    Public Property RIRetencionDiaria() As Double
        Get
            Return retencionDiaria
        End Get
        Set(ByVal value As Double)
            retencionDiaria = value
        End Set
    End Property

    Private diasPagados As Double
    Public Property RIDiasPagados() As Double
        Get
            Return diasPagados
        End Get
        Set(ByVal value As Double)
            diasPagados = value
        End Set
    End Property

    Private totalRetencion As Double
    Public Property RITotalRetencion() As Double
        Get
            Return totalRetencion
        End Get
        Set(ByVal value As Double)
            totalRetencion = value
        End Set
    End Property

    Private excedeSalarioMinimo As Boolean
    Public Property RIExcedeSalarioMinimo() As Boolean
        Get
            Return excedeSalarioMinimo
        End Get
        Set(ByVal value As Boolean)
            excedeSalarioMinimo = value
        End Set
    End Property

    Private retencionExcedenteSMDF As Double
    Public Property RIRetencionExcedenteSMDF() As Double
        Get
            Return retencionExcedenteSMDF
        End Get
        Set(ByVal value As Double)
            retencionExcedenteSMDF = value
        End Set
    End Property

    Private totalExcedenteSMDF As Double
    Public Property RITotalExcedenteSMDF() As Double
        Get
            Return totalExcedenteSMDF
        End Get
        Set(ByVal value As Double)
            totalExcedenteSMDF = value
        End Set
    End Property

    Private cantidadExcedenteSMDF As Double
    Public Property RICantidadExcedenteSMDF() As Double
        Get
            Return cantidadExcedenteSMDF
        End Get
        Set(ByVal value As Double)
            cantidadExcedenteSMDF = value
        End Set
    End Property

    Private retencionImss As Double
    Public Property RIRetencionImss() As Double
        Get
            Return retencionImss
        End Get
        Set(ByVal value As Double)
            retencionImss = value
        End Set
    End Property

End Class
