Public Class CierreNominaFiscal
    Private nominaFiscalId As Int32
    Public Property PNominaFiscalId() As Int32
        Get
            Return nominaFiscalId
        End Get
        Set(ByVal value As Int32)
            nominaFiscalId = value
        End Set
    End Property

    Private colaboradorId As Int32
    Public Property PColaboradorId() As Int32
        Get
            Return colaboradorId
        End Get
        Set(ByVal value As Int32)
            colaboradorId = value
        End Set
    End Property

    Private patronId As Int32
    Public Property PPatronId() As Int32
        Get
            Return patronId
        End Get
        Set(ByVal value As Int32)
            patronId = value
        End Set
    End Property

    Private salarioSemanalId As Int32
    Public Property PSalarioSemanalId() As Int32
        Get
            Return salarioSemanalId
        End Get
        Set(ByVal value As Int32)
            salarioSemanalId = value
        End Set
    End Property

    Private factorIntegracionId As Int32
    Public Property PFactorIntegracionId() As Int32
        Get
            Return factorIntegracionId
        End Get
        Set(ByVal value As Int32)
            factorIntegracionId = value
        End Set
    End Property

    Private salarioDiario As Double
    Public Property PSalarioDiario() As Double
        Get
            Return salarioDiario
        End Get
        Set(ByVal value As Double)
            salarioDiario = value
        End Set
    End Property

    Private factorIntegracion As Double
    Public Property PFactorIntegracion() As Double
        Get
            Return factorIntegracion
        End Get
        Set(ByVal value As Double)
            factorIntegracion = value
        End Set
    End Property

    Private sdi As Double
    Public Property PSalarioDiarioIntegrado() As Double
        Get
            Return sdi
        End Get
        Set(ByVal value As Double)
            sdi = value
        End Set
    End Property

    Private diasNomina As Double
    Public Property PDiasNomina() As Double
        Get
            Return diasNomina
        End Get
        Set(ByVal value As Double)
            diasNomina = value
        End Set
    End Property

    Private diasPagados As Double
    Public Property PDiasPagados() As Double
        Get
            Return diasPagados
        End Get
        Set(ByVal value As Double)
            diasPagados = value
        End Set
    End Property

    Private salarioSemanal As Double
    Public Property PSalarioSemanal() As Double
        Get
            Return salarioSemanal
        End Get
        Set(ByVal value As Double)
            salarioSemanal = value
        End Set
    End Property

    Private premioAsistencia As Double
    Public Property PPremioAsistencia() As Double
        Get
            Return premioAsistencia
        End Get
        Set(ByVal value As Double)
            premioAsistencia = value
        End Set
    End Property

    Private premioPuntualidad As Double
    Public Property PPremioPuntualidad() As Double
        Get
            Return premioPuntualidad
        End Get
        Set(ByVal value As Double)
            premioPuntualidad = value
        End Set
    End Property

    Private spe As Double
    Public Property PSubsidioEmpleo() As Double
        Get
            Return spe
        End Get
        Set(ByVal value As Double)
            spe = value
        End Set
    End Property

    Private totalPercepciones As Double
    Public Property PTotalPercepciones() As Double
        Get
            Return totalPercepciones
        End Get
        Set(ByVal value As Double)
            totalPercepciones = value
        End Set
    End Property

    Private retencionImss As Double
    Public Property PRetencionImss() As Double
        Get
            Return retencionImss
        End Get
        Set(ByVal value As Double)
            retencionImss = value
        End Set
    End Property

    Private infonavit As Double
    Public Property PInfonavitDiario() As Double
        Get
            Return infonavit
        End Get
        Set(ByVal value As Double)
            infonavit = value
        End Set
    End Property

    Private retencionISR As Double
    Public Property PRetencionISR() As Double
        Get
            Return retencionISR
        End Get
        Set(ByVal value As Double)
            retencionISR = value
        End Set
    End Property

    Private sueldoNeto As Double
    Public Property PSueldoNeto() As Double
        Get
            Return sueldoNeto
        End Get
        Set(ByVal value As Double)
            sueldoNeto = value
        End Set
    End Property

    Private antiguedad As Int32
    Public Property PAntiguedad() As Int32
        Get
            Return antiguedad
        End Get
        Set(ByVal value As Int32)
            antiguedad = value
        End Set
    End Property

    Private totalDeducciones As Double
    Public Property PTotalDeducciones() As Double
        Get
            Return totalDeducciones
        End Get
        Set(ByVal value As Double)
            totalDeducciones = value
        End Set
    End Property

    Private diasAusentismo As Double
    Public Property PDiasAusentismo() As Double
        Get
            Return diasAusentismo
        End Get
        Set(ByVal value As Double)
            diasAusentismo = value
        End Set
    End Property

    Private diasIncapacidad As Double
    Public Property PDiasIncapacidad() As Double
        Get
            Return diasIncapacidad
        End Get
        Set(ByVal value As Double)
            diasIncapacidad = value
        End Set
    End Property

    Private montoInfonavit As Double
    Public Property PMontoInfonavit() As Double
        Get
            Return montoInfonavit
        End Get
        Set(ByVal value As Double)
            montoInfonavit = value
        End Set
    End Property

    Private externo As Boolean
    Public Property PExterno() As Boolean
        Get
            Return externo
        End Get
        Set(ByVal value As Boolean)
            externo = value
        End Set
    End Property

    Private diasTrabajados As Double
    Public Property PDiasTrabajados() As Double
        Get
            Return diasTrabajados
        End Get
        Set(ByVal value As Double)
            diasTrabajados = value
        End Set
    End Property

    Private isrDiario As Double
    Public Property PISRDiario() As Double
        Get
            Return isrDiario
        End Get
        Set(ByVal value As Double)
            isrDiario = value
        End Set
    End Property

    Private imssDiario As Double
    Public Property PIMSSDiario() As Double
        Get
            Return imssDiario
        End Get
        Set(ByVal value As Double)
            imssDiario = value
        End Set
    End Property

    Private speDiario As Double
    Public Property PSPEDiario() As Double
        Get
            Return speDiario
        End Get
        Set(ByVal value As Double)
            speDiario = value
        End Set
    End Property

    Private aforeDiario As Double
    Public Property PAforeDiario() As Double
        Get
            Return aforeDiario
        End Get
        Set(ByVal value As Double)
            aforeDiario = value
        End Set
    End Property

    Private retencionAfore As Double
    Public Property PRetencionAfore() As Double
        Get
            Return retencionAfore
        End Get
        Set(ByVal value As Double)
            retencionAfore = value
        End Set
    End Property

    Private saldoAcumulado As Double
    Public Property PSaldoAcumulado() As Double
        Get
            Return saldoAcumulado
        End Get
        Set(ByVal value As Double)
            saldoAcumulado = value
        End Set
    End Property

    Private saldoAcumuladoid As Double
    Public Property PSaldoAcumuladoID() As Double
        Get
            Return saldoAcumuladoid
        End Get
        Set(ByVal value As Double)
            saldoAcumuladoid = value
        End Set
    End Property

    Private saldoAcumuladoDescontar As Double
    Public Property PSaldoAcumuladoDescontar() As Double
        Get
            Return saldoAcumuladoDescontar
        End Get
        Set(ByVal value As Double)
            saldoAcumuladoDescontar = value
        End Set
    End Property

    Private diasFestivos As Double
    Public Property PDiasFestivos() As Double
        Get
            Return diasFestivos
        End Get
        Set(ByVal value As Double)
            diasFestivos = value
        End Set
    End Property

    Private diasNoAplicaInf As Double
    Public Property PDiasNoAplicaInf() As Double
        Get
            Return diasNoAplicaInf
        End Get
        Set(ByVal value As Double)
            diasNoAplicaInf = value
        End Set
    End Property

    Private diasNoAplicaImss As Double
    Public Property PDiasNoAplicaImss() As Double
        Get
            Return diasNoAplicaImss
        End Get
        Set(ByVal value As Double)
            diasNoAplicaImss = value
        End Set
    End Property

    Private comisiones As Double
    Public Property PComisiones As Double
        Get
            Return comisiones
        End Get
        Set(value As Double)
            comisiones = value
        End Set
    End Property

    Private sdiMixto As Double
    Public Property PSalarioDiarioIntegradoMixto() As Double
        Get
            Return sdiMixto
        End Get
        Set(ByVal value As Double)
            sdiMixto = value
        End Set
    End Property

    Private isrDeterminado As Double
    Public Property PISRDeterminado() As Double
        Get
            Return isrDeterminado
        End Get
        Set(ByVal value As Double)
            isrDeterminado = value
        End Set
    End Property

    Private speCausado As Double
    Public Property PSPECausado() As Double
        Get
            Return speCausado
        End Get
        Set(ByVal value As Double)
            speCausado = value
        End Set
    End Property

    Private tipoPeriodo As Short
    Public Property PTipoPeriodo() As Short
        Get
            Return tipoPeriodo
        End Get
        Set(value As Short)
            tipoPeriodo = value
        End Set
    End Property

End Class