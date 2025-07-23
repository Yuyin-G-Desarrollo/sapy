Public Class TimbreOtrosPagos
    Private timbreOtrosPagosId As Integer
    Public Property TOPTimbreOtrosPagosId() As Integer
        Get
            Return timbreOtrosPagosId
        End Get
        Set(ByVal value As Integer)
            timbreOtrosPagosId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property TOPTimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private tipoOtrosPagos As String
    Public Property TOPTipoOtrosPagos() As String
        Get
            Return tipoOtrosPagos
        End Get
        Set(ByVal value As String)
            tipoOtrosPagos = value
        End Set
    End Property

    Private claveOtrosPagos As String
    Public Property TOPClaveOtrosPagos() As String
        Get
            Return claveOtrosPagos
        End Get
        Set(ByVal value As String)
            claveOtrosPagos = value
        End Set
    End Property

    Private conceptoOtrosPagos As String
    Public Property TOPConceptoOtrosPagos() As String
        Get
            Return conceptoOtrosPagos
        End Get
        Set(ByVal value As String)
            conceptoOtrosPagos = value
        End Set
    End Property

    Private importeOtrosPagos As Double
    Public Property TOPImporteOtrosPagos() As Double
        Get
            Return importeOtrosPagos
        End Get
        Set(ByVal value As Double)
            importeOtrosPagos = value
        End Set
    End Property

    Private subsidioCausado As Double
    Public Property TOPSubsidioCausado() As Double
        Get
            Return subsidioCausado
        End Get
        Set(ByVal value As Double)
            subsidioCausado = value
        End Set
    End Property

    Private saldoAFavor As Double
    Public Property TOPSaldoAFavor() As Double
        Get
            Return saldoAFavor
        End Get
        Set(ByVal value As Double)
            saldoAFavor = value
        End Set
    End Property

    Private anio As Int16
    Public Property TOPAnio() As Int16
        Get
            Return anio
        End Get
        Set(ByVal value As Int16)
            anio = value
        End Set
    End Property

    Private remanenteSalFav As Double
    Public Property TOPRemanenteSalFav() As Double
        Get
            Return remanenteSalFav
        End Get
        Set(ByVal value As Double)
            remanenteSalFav = value
        End Set
    End Property
End Class
