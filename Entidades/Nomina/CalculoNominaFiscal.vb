Public Class CalculoNominaFiscal
    Private inicioVacaciones1 As DateTime
    Private finVacaciones1 As DateTime

    Private colaborador As Entidades.Colaborador
    Private salarioDiario As Decimal
    Private diasTrabjados As Integer
    Private salarioSemanal As Decimal
    Private salarioMensual As Decimal
    Private premioPuntualidad As Decimal
    Private despensa As Decimal
    Private totalGravado As Decimal

    Private limiteInfeior As Decimal
    Private excedente As Decimal
    Private tasaDeImpuesto As Decimal
    Private impuestoMarginal As Decimal
    Private cuotaFija As Decimal
    Private ISRDeterminado As Decimal
    Private cantidadARetener As Decimal
    Private subsidioEmpleo As Decimal
    Private subsidioPorPagar As Decimal

    Private AniosServicio As Integer
    Private FactorIntegracion As Decimal
    Private SalarioBaseCotizacion As Decimal
    Private SalarioMinimo As Decimal
    Private ExcedenteSalariosMinimos As Decimal
    Private CuotaPorExcedente As Decimal
    Private TotalPorExcedente As Decimal
    Private PrestacionesEnDinero As Decimal
    Private GastosMedicosPensionados As Decimal
    Private InvalidezYVida As Decimal
    Private CesantiaEdadAvanzadaVejez As Decimal
    Private Factor As Decimal
    Private DiasTrabajadosMasAusentismosMenosIncapacidad As Decimal
    Private TotalARetener As Decimal
    Private DiasAnio As Integer

    Private TipoCredito As Integer
    Private DiasBimestre As Integer
    Private SalarioBimestral As Decimal
    Private PorcentajeRetencion As Decimal
    Private FactorDescuento As Decimal

    Private CuotaFijaINFONAVIT As Decimal

    Private RetencionMensual As Decimal
    Private ImporteBimestral As Decimal
    Private SeguroVivienda As Decimal
    Private ImporteBimestralRetener As Decimal
    Private RetencionDiario As Decimal
    Private RentencionSemanal As Decimal

    Public Property PfinVacaciones1 As DateTime
        Get
            Return finVacaciones1
        End Get
        Set(ByVal value As DateTime)
            finVacaciones1 = value
        End Set
    End Property

    Public Property PInicioVacaciones1 As DateTime
        Get
            Return inicioVacaciones1
        End Get
        Set(ByVal value As DateTime)
            inicioVacaciones1 = value
        End Set
    End Property


    Public Property PColaborador() As Entidades.Colaborador
        Get
            Return colaborador
        End Get
        Set(ByVal value As Entidades.Colaborador)
            colaborador = value
        End Set
    End Property

    Public Property PSalarioDiario() As Decimal
        Get
            Return salarioDiario
        End Get
        Set(ByVal value As Decimal)
            salarioDiario = value
        End Set
    End Property




    Public Property PDiasTrabajados() As Integer
        Get
            Return diasTrabjados
        End Get
        Set(ByVal value As Integer)
            diasTrabjados = value
        End Set
    End Property

    Public Property PSalarioSemanal() As Decimal
        Get
            Return salarioSemanal
        End Get
        Set(ByVal value As Decimal)
            salarioSemanal = value
        End Set
    End Property

    Public Property PSalarioMensual() As Decimal
        Get
            Return salarioMensual
        End Get
        Set(ByVal value As Decimal)
            salarioMensual = value
        End Set
    End Property

    Public Property PPremioPuntualidad() As Decimal
        Get
            Return premioPuntualidad
        End Get
        Set(ByVal value As Decimal)
            premioPuntualidad = value
        End Set
    End Property

    Public Property PDespensa() As Decimal
        Get
            Return despensa
        End Get
        Set(ByVal value As Decimal)
            despensa = value
        End Set
    End Property

    Public Property PTotalGravado() As Decimal
        Get
            Return totalGravado
        End Get
        Set(ByVal value As Decimal)
            totalGravado = value
        End Set
    End Property

    Public Property PLimiteInfeior() As Decimal
        Get
            Return limiteInfeior
        End Get
        Set(ByVal value As Decimal)
            limiteInfeior = value
        End Set
    End Property

    Public Property PExcedente() As Decimal
        Get
            Return excedente
        End Get
        Set(ByVal value As Decimal)
            excedente = value
        End Set
    End Property

    Public Property PTasaDeImpuesto() As Decimal
        Get
            Return tasaDeImpuesto
        End Get
        Set(ByVal value As Decimal)
            tasaDeImpuesto = value
        End Set
    End Property

    Public Property PImpuestoMarginal() As Decimal
        Get
            Return impuestoMarginal
        End Get
        Set(ByVal value As Decimal)
            impuestoMarginal = value
        End Set
    End Property

    Public Property PCuotaFija() As Decimal
        Get
            Return cuotaFija
        End Get
        Set(ByVal value As Decimal)
            cuotaFija = value
        End Set
    End Property

    Public Property PISRDeterminado() As Decimal
        Get
            Return ISRDeterminado
        End Get
        Set(ByVal value As Decimal)
            ISRDeterminado = value
        End Set
    End Property

    Public Property PSubsidioEmpleo() As Decimal
        Get
            Return subsidioEmpleo
        End Get
        Set(ByVal value As Decimal)
            subsidioEmpleo = value
        End Set
    End Property

    Public Property PCantidadARetener() As Decimal
        Get
            Return cantidadARetener
        End Get
        Set(ByVal value As Decimal)
            cantidadARetener = value
        End Set
    End Property

    Public Property PSubsidioPorPagar() As Decimal
        Get
            Return subsidioPorPagar
        End Get
        Set(ByVal value As Decimal)
            subsidioPorPagar = value
        End Set
    End Property

    Public Property PAniosServicio() As Integer
        Get
            Return AniosServicio
        End Get
        Set(ByVal value As Integer)
            AniosServicio = value
        End Set
    End Property

    Public Property PFactorIntegracion() As Decimal
        Get
            Return FactorIntegracion
        End Get
        Set(ByVal value As Decimal)
            FactorIntegracion = value
        End Set
    End Property

    Public Property PSalarioBaseCotizacion() As Decimal
        Get
            Return SalarioBaseCotizacion
        End Get
        Set(ByVal value As Decimal)
            SalarioBaseCotizacion = value
        End Set
    End Property

    Public Property PSalarioMinimo() As Decimal
        Get
            Return SalarioMinimo
        End Get
        Set(ByVal value As Decimal)
            SalarioMinimo = value
        End Set
    End Property

    Public Property PExcedentesSalariosMinimos() As Decimal
        Get
            Return ExcedenteSalariosMinimos
        End Get
        Set(ByVal value As Decimal)
            ExcedenteSalariosMinimos = value
        End Set
    End Property

    Public Property PCuotaPorExcedente() As Decimal
        Get
            Return CuotaPorExcedente
        End Get
        Set(ByVal value As Decimal)
            CuotaPorExcedente = value
        End Set
    End Property

    Public Property PTotalPorExcedente() As Decimal
        Get
            Return TotalPorExcedente
        End Get
        Set(ByVal value As Decimal)
            TotalPorExcedente = value
        End Set
    End Property

    Public Property PPrestacionesEnDinero() As Decimal
        Get
            Return PrestacionesEnDinero
        End Get
        Set(ByVal value As Decimal)
            PrestacionesEnDinero = value
        End Set
    End Property

    Public Property PGastosMedicosPensionados() As Decimal
        Get
            Return GastosMedicosPensionados
        End Get
        Set(ByVal value As Decimal)
            GastosMedicosPensionados = value
        End Set
    End Property

    Public Property PInvalidezYVida() As Decimal
        Get
            Return InvalidezYVida
        End Get
        Set(ByVal value As Decimal)
            InvalidezYVida = value
        End Set
    End Property

    Public Property PCesantiaEdadAvanzadaVejez() As Decimal
        Get
            Return CesantiaEdadAvanzadaVejez
        End Get
        Set(ByVal value As Decimal)
            CesantiaEdadAvanzadaVejez = value
        End Set
    End Property

    Public Property PFactor() As Decimal
        Get
            Return Factor
        End Get
        Set(ByVal value As Decimal)
            Factor = value
        End Set
    End Property

    Public Property PDiasTrabajadosMasAusentismosMenosIncapacidad() As Decimal
        Get
            Return DiasTrabajadosMasAusentismosMenosIncapacidad
        End Get
        Set(ByVal value As Decimal)
            DiasTrabajadosMasAusentismosMenosIncapacidad = value
        End Set
    End Property

    Public Property PTotalARetener() As Decimal
        Get
            Return TotalARetener
        End Get
        Set(ByVal value As Decimal)
            TotalARetener = value
        End Set
    End Property

    Public Property PTipoCredito() As Integer
        Get
            Return TipoCredito
        End Get
        Set(ByVal value As Integer)
            TipoCredito = value
        End Set
    End Property

    Public Property PDiasBimestre() As Integer
        Get
            Return diasBimestre
        End Get
        Set(ByVal value As Integer)
            diasBimestre = value
        End Set
    End Property

    Public Property PSalarioBimestral() As Decimal
        Get
            Return SalarioBimestral
        End Get
        Set(ByVal value As Decimal)
            SalarioBimestral = value
        End Set
    End Property

    Public Property PPorcentajeRetencion() As Decimal
        Get
            Return PorcentajeRetencion
        End Get
        Set(ByVal value As Decimal)
            PorcentajeRetencion = value
        End Set
    End Property

    Public Property PFactorDescuento() As Decimal
        Get
            Return FactorDescuento
        End Get
        Set(ByVal value As Decimal)
            FactorDescuento = value
        End Set
    End Property

    Public Property PCuotaFijaINFONAVIT() As Decimal
        Get
            Return CuotaFijaINFONAVIT
        End Get
        Set(ByVal value As Decimal)
            CuotaFijaINFONAVIT = value
        End Set
    End Property

    Public Property PRetencionMensual() As Decimal
        Get
            Return RetencionMensual
        End Get
        Set(ByVal value As Decimal)
            RetencionMensual = value
        End Set
    End Property

    Public Property PImporteBimestral() As Decimal
        Get
            Return ImporteBimestral
        End Get
        Set(ByVal value As Decimal)
            ImporteBimestral = value
        End Set
    End Property

    Public Property PSeguroVivienda() As Decimal
        Get
            Return SeguroVivienda
        End Get
        Set(ByVal value As Decimal)
            SeguroVivienda = value
        End Set
    End Property

    Public Property PImporteBimestralRetener() As Decimal
        Get
            Return ImporteBimestralRetener
        End Get
        Set(ByVal value As Decimal)
            ImporteBimestralRetener = value
        End Set
    End Property

    Public Property PRetencionDiario() As Decimal
        Get
            Return RetencionDiario
        End Get
        Set(ByVal value As Decimal)
            RetencionDiario = value
        End Set
    End Property

    Public Property PRetencionSemanal() As Decimal
        Get
            Return RentencionSemanal
        End Get
        Set(ByVal value As Decimal)
            RentencionSemanal = value
        End Set
    End Property



    Public Property PDiasAnio As Integer
        Get
            Return DiasAnio
        End Get
        Set(ByVal value As Integer)
            DiasAnio = value
        End Set
    End Property


End Class
