Public Class CalcularNominaReal
    Private Colaborador As Colaborador
    Private FechaNac As DateTime
    Private FechaIngreso As DateTime

    Private Prestamos As SolicitudPrestamo
    Private Cobranza As CobranzaPrestamos
    Private Incentivos As SolicitudIncentivos
    Private CajaAhorro As CajaAhorro
    Private checador As CorteChecador
    Private Nave As Naves
    Private DeduccionExtraordinaria As Deducciones
    Private ConfiguracionAsistencia As ConfiguracionAsistencia
    Private IMSS As DeduccionRealImss
    Private HorasExtras As HorasExtras
    Private Percepciones As Percepciones
    Private NominaFiscal As CalculoNominaFiscal

    Private SemanaNominaID As Integer
    Private Puesto As String
    Private Departamento As String
    Private DepartamentoID As Integer
    Private Tiposueldo As String

    Private infornavit As Boolean
    Private infonavit_tipo As Integer
    Private infonavit_monto As Double
    Private diasAnio As Integer
    Private NumeroSS As String

    Private CelulaID As Integer
    Private celulaIDSAY As Integer


    Private RealTipo As String
    Private SalarioReal As Double
    Private SalarioDiario As Double
    Private SalarioSemanal As Double
    Private DiasLaborados As Double

    Private Inasistencias As Double
    Private IncentivoPuntualidad As Double

    Private TotalPercepciones As Double
    Private CajaDeAhorro As Double ''
    Private CajaAhorroValidacion As Integer

    Private TotalDeducciones As Double
    Private TotalEntregar As Double
    Private TotalDestajos As Double

    ''lotes
    Private TotalParesLotes As Integer
    Private costoFraccion As Double
    ''DESTAJOS
    Private DestajosdiasLaborados As Double
    Private DestajosTotalEntregar As Double
    Private DestajosSalarioSemanal As Double
    Private DestajosSalarioDiario As Double

    ''CHECA
    Private Checa As Boolean
    Private GanaIncentivos As Boolean
    Private GanaIncentivosSiempre As Boolean

    ''INCENTIVOS DENTRO DE NOMINA
    Private GratificacionConfiguracion As Boolean
    Private GratificacionCumpleanios As Boolean
    Private GratificacionGerente As Boolean
    Private GratificacionDirector As Boolean
    ''
    Private Estatus As String
    Private MotivoGratificacion As String
    Private MontoGratificacion As Double
    Private IdGratificacion As Integer
    Private DiaAdicional As Boolean

    Private finiquitoid As Int32

    Private Cuenta As String

    Private FactorIntegracion As Double
    Private LimiteInferior As Double
    Private TasaImpuesto As Double
    Private CuotaFija As Double
    Private SubsidioEmpleo As Double
    Private SalarioMinimo As Double
    Private CuotaExedente As Double
    Private PrestacionesDinero As Double
    Private GastosMedicos As Double
    Private invalidezVida As Double
    Private Cesantia As Double

    Private Ausentismos As Double
    Private sexo As String

    Private ordenPuesto As Int32
    Private retencionIMSS As Double
    Private retencionISR As Double

    Public Property PRetencionIMMS As Double
        Get
            Return retencionIMSS
        End Get
        Set(value As Double)
            retencionIMSS = value
        End Set
    End Property

    Public Property PRetencionISR As Double
        Get
            Return retencionISR
        End Get
        Set(value As Double)
            retencionISR = value
        End Set
    End Property

    Public Property POrdenPuesto As Int32
        Get
            Return ordenPuesto
        End Get
        Set(ByVal value As Int32)
            ordenPuesto = value
        End Set
    End Property


    Public Property Psexo As String
        Get
            Return sexo
        End Get
        Set(value As String)
            sexo = value
        End Set
    End Property

    Public Property Pausentismos As Double
        Get
            Return Ausentismos
        End Get
        Set(value As Double)
            Ausentismos = value
        End Set
    End Property

    Public Property PdepartamentoID As Integer
        Get
            Return DepartamentoID
        End Get
        Set(value As Integer)
            DepartamentoID = value
        End Set
    End Property

    Public Property PSemanaNominaID As Integer
        Get
            Return SemanaNominaID
        End Get
        Set(value As Integer)
            SemanaNominaID = value
        End Set
    End Property

    Public Property PCuenta As String
        Get
            Return Cuenta
        End Get
        Set(value As String)
            Cuenta = value
        End Set
    End Property

    Public Property PGratificacionDirector As Boolean
        Get
            Return GratificacionDirector
        End Get
        Set(ByVal value As Boolean)
            GratificacionDirector = value
        End Set
    End Property

    Public Property PGratificacionGerente As Boolean
        Get
            Return GratificacionGerente
        End Get
        Set(ByVal value As Boolean)
            GratificacionGerente = value
        End Set
    End Property

    Public Property PDiaAdicional As Boolean
        Get
            Return DiaAdicional
        End Get
        Set(value As Boolean)
            DiaAdicional = value
        End Set
    End Property


    Public Property PfiniquitoID As Int32
        Get
            Return finiquitoid
        End Get
        Set(ByVal value As Int32)
            finiquitoid = value
        End Set
    End Property

    Public Property PMontoGratificacion As Double
        Get
            Return MontoGratificacion
        End Get
        Set(ByVal value As Double)
            MontoGratificacion = value
        End Set
    End Property

    Public Property PMotivoGratificacion As String
        Get
            Return MotivoGratificacion
        End Get
        Set(ByVal value As String)
            MotivoGratificacion = value
        End Set
    End Property

    Public Property PIdGratificacion As Integer
        Get
            Return IdGratificacion
        End Get
        Set(value As Integer)
            IdGratificacion = value
        End Set
    End Property

    Public Property PEstatus As String
        Get
            Return Estatus
        End Get
        Set(value As String)
            Estatus = value
        End Set
    End Property

    Public Property PGratificacionCumpleanios As Boolean
        Get
            Return GratificacionCumpleanios
        End Get
        Set(ByVal value As Boolean)
            GratificacionCumpleanios = value
        End Set
    End Property

    Public Property PGratificacionConfiguracion As Boolean
        Get
            Return GratificacionConfiguracion
        End Get
        Set(ByVal value As Boolean)
            GratificacionConfiguracion = value
        End Set
    End Property

    Public Property PFechaIngreso As DateTime
        Get
            Return FechaIngreso
        End Get
        Set(ByVal value As DateTime)
            FechaIngreso = value
        End Set
    End Property

    Public Property PFechaNac As DateTime
        Get
            Return FechaNac
        End Get
        Set(ByVal value As DateTime)
            FechaNac = value
        End Set
    End Property

    Public Property PTipoSueldo As String
        Get
            Return Tiposueldo
        End Get
        Set(ByVal value As String)
            Tiposueldo = value
        End Set
    End Property

    Public Property PPuesto As String
        Get
            Return Puesto
        End Get
        Set(ByVal value As String)
            Puesto = value
        End Set
    End Property

    Public Property PDepartamento As String
        Get
            Return Departamento
        End Get
        Set(ByVal value As String)
            Departamento = value
        End Set
    End Property

    Public Property PCheca As Boolean
        Get
            Return Checa
        End Get
        Set(ByVal value As Boolean)
            Checa = value
        End Set
    End Property

    Public Property PGanaIncentivosSiempre As Boolean
        Get
            Return GanaIncentivosSiempre
        End Get
        Set(value As Boolean)
            GanaIncentivosSiempre = value
        End Set
    End Property

    Public Property PGanaIncentivos As Boolean
        Get
            Return GanaIncentivos
        End Get
        Set(value As Boolean)
            GanaIncentivos = value
        End Set
    End Property

    Public Property PCajaAhorroValidacion As Integer
        Get
            Return CajaAhorroValidacion
        End Get
        Set(ByVal value As Integer)
            CajaAhorroValidacion = value
        End Set
    End Property


    Public Property PcostoFraccion As Double
        Get
            Return costoFraccion
        End Get
        Set(ByVal value As Double)
            costoFraccion = value
        End Set
    End Property


    Public Property PTotalParesLotes As Integer
        Get
            Return TotalParesLotes
        End Get
        Set(ByVal value As Integer)
            TotalParesLotes = value
        End Set
    End Property

    Public Property PCelulaID As Integer
        Get
            Return CelulaID
        End Get
        Set(ByVal value As Integer)
            CelulaID = value
        End Set
    End Property

    Public Property PCelulaIDSAY As Integer
        Get
            Return celulaIDSAY
        End Get
        Set(ByVal value As Integer)
            celulaIDSAY = value
        End Set
    End Property

    Public Property PDestajosSalarioDiario As Double
        Get
            Return DestajosSalarioDiario
        End Get
        Set(ByVal value As Double)
            DestajosSalarioDiario = value
        End Set
    End Property

    Public Property PDestajosSalarioSemanal As Double
        Get
            Return DestajosSalarioSemanal
        End Get
        Set(ByVal value As Double)
            DestajosSalarioSemanal = value
        End Set
    End Property

    Public Property PDestajosTotalEntregar As Double
        Get
            Return DestajosTotalEntregar
        End Get
        Set(ByVal value As Double)
            DestajosTotalEntregar = value
        End Set
    End Property

    Public Property PDestajosdiasLaborados As Double
        Get
            Return DestajosdiasLaborados
        End Get
        Set(ByVal value As Double)
            DestajosdiasLaborados = value
        End Set
    End Property

    Public Property PNumeroSS As String
        Get
            Return NumeroSS
        End Get
        Set(ByVal value As String)
            NumeroSS = value
        End Set
    End Property

    Public Property PRealTipo As String
        Get
            Return RealTipo
        End Get
        Set(ByVal value As String)
            RealTipo = value
        End Set
    End Property

    Public Property PTotalDestajos As Double
        Get
            Return TotalDestajos
        End Get
        Set(ByVal value As Double)
            TotalDestajos = value
        End Set
    End Property

    Public Property PDiasAnio As Integer
        Get
            Return diasAnio
        End Get
        Set(ByVal value As Integer)
            diasAnio = value
        End Set
    End Property

    Public Property Pinfonavit_monto As Double
        Get
            Return infonavit_monto
        End Get
        Set(ByVal value As Double)
            infonavit_monto = value
        End Set
    End Property

    Public Property Pinfonavit_tipo As Integer
        Get
            Return infonavit_tipo
        End Get
        Set(ByVal value As Integer)
            infonavit_tipo = value
        End Set
    End Property

    Public Property Pinfornavit As Boolean
        Get
            Return infornavit
        End Get
        Set(ByVal value As Boolean)
            infornavit = value
        End Set
    End Property

    Public Property PNominaFiscal As CalculoNominaFiscal
        Get
            Return NominaFiscal
        End Get
        Set(ByVal value As CalculoNominaFiscal)
            NominaFiscal = value
        End Set
    End Property

    Public Property PDiasLaborados As Double
        Get
            Return DiasLaborados
        End Get
        Set(ByVal value As Double)
            DiasLaborados = value
        End Set
    End Property

    Public Property PPercepciones As Percepciones
        Get
            Return Percepciones
        End Get
        Set(ByVal value As Percepciones)
            Percepciones = value
        End Set
    End Property

    Public Property Pchecador As CorteChecador
        Get
            Return checador
        End Get
        Set(ByVal value As CorteChecador)
            checador = value
        End Set
    End Property

    Public Property PCajaAhorro As CajaAhorro
        Get
            Return CajaAhorro
        End Get
        Set(ByVal value As CajaAhorro)
            CajaAhorro = value
        End Set
    End Property

    Public Property PConfiguracionAsistencia As ConfiguracionAsistencia
        Get
            Return ConfiguracionAsistencia
        End Get
        Set(ByVal value As ConfiguracionAsistencia)
            ConfiguracionAsistencia = value
        End Set
    End Property

    Public Property PIncentivos As SolicitudIncentivos
        Get
            Return Incentivos
        End Get
        Set(ByVal value As SolicitudIncentivos)
            Incentivos = value
        End Set
    End Property

    Public Property PCobranza As CobranzaPrestamos
        Get
            Return Cobranza
        End Get
        Set(ByVal value As CobranzaPrestamos)
            Cobranza = value
        End Set
    End Property

    Public Property PTotalEntregar As Double
        Get
            Return TotalEntregar
        End Get
        Set(ByVal value As Double)
            TotalEntregar = value
        End Set
    End Property

    Public Property PTotalDeducciones As Double
        Get
            Return TotalDeducciones
        End Get
        Set(ByVal value As Double)
            TotalDeducciones = value
        End Set
    End Property

    Public Property PDeduccionExtraordinaria As Deducciones
        Get
            Return DeduccionExtraordinaria
        End Get
        Set(ByVal value As Deducciones)
            DeduccionExtraordinaria = value
        End Set
    End Property

    Public Property PIMSS As DeduccionRealImss
        Get
            Return IMSS
        End Get
        Set(ByVal value As DeduccionRealImss)
            IMSS = value
        End Set
    End Property

    Public Property PPrestamos As SolicitudPrestamo
        Get
            Return Prestamos
        End Get
        Set(ByVal value As SolicitudPrestamo)
            Prestamos = value
        End Set
    End Property

    Public Property PCajaDeAhorro As Double
        Get
            Return CajaDeAhorro
        End Get
        Set(ByVal value As Double)
            CajaDeAhorro = value
        End Set
    End Property

    Public Property PTotalPercepciones As Double
        Get
            Return TotalPercepciones
        End Get
        Set(ByVal value As Double)
            TotalPercepciones = value
        End Set
    End Property

    Public Property PHorasExtras As HorasExtras
        Get
            Return HorasExtras
        End Get
        Set(ByVal value As HorasExtras)
            HorasExtras = value
        End Set
    End Property

    Public Property PIncentivoPuntualidad As Double
        Get
            Return IncentivoPuntualidad
        End Get
        Set(ByVal value As Double)
            IncentivoPuntualidad = value
        End Set
    End Property

    Public Property PInasistencias As Double
        Get
            Return Inasistencias
        End Get
        Set(ByVal value As Double)
            Inasistencias = value
        End Set
    End Property

    Public Property PSalarioDiario As Double
        Get
            Return SalarioDiario
        End Get
        Set(ByVal value As Double)
            SalarioDiario = value
        End Set
    End Property

    Public Property PSalarioSemanal As Double
        Get
            Return SalarioSemanal
        End Get
        Set(ByVal value As Double)
            SalarioSemanal = value
        End Set
    End Property

    Public Property PSalarioReal As Double
        Get
            Return SalarioReal
        End Get
        Set(ByVal value As Double)
            SalarioReal = value
        End Set
    End Property

    Public Property PColaborador As Colaborador
        Get
            Return Colaborador
        End Get
        Set(ByVal value As Colaborador)
            Colaborador = value
        End Set
    End Property

    Public Property PFactorIntegracion As Double
        Get
            Return FactorIntegracion
        End Get
        Set(value As Double)
            FactorIntegracion = value
        End Set
    End Property

    Public Property PLimiteInferior As Double
        Get
            Return LimiteInferior
        End Get
        Set(value As Double)
            LimiteInferior = value
        End Set
    End Property

    Public Property PTasaImpuesto As Double
        Get
            Return TasaImpuesto
        End Get
        Set(value As Double)
            TasaImpuesto = value
        End Set
    End Property

    Public Property PCuotaFija As Double
        Get
            Return CuotaFija
        End Get
        Set(value As Double)
            CuotaFija = value
        End Set
    End Property

    Public Property PSubsidioEmpleo As Double
        Get
            Return SubsidioEmpleo
        End Get
        Set(value As Double)
            SubsidioEmpleo = value
        End Set
    End Property

    Public Property PSalarioMinimo As Double
        Get
            Return SalarioMinimo
        End Get
        Set(value As Double)
            SalarioMinimo = value
        End Set
    End Property

    Public Property PCuotaExedente As Double
        Get
            Return CuotaExedente
        End Get
        Set(value As Double)
            CuotaExedente = value
        End Set
    End Property

    Public Property PPrestacionesDinero As Double
        Get
            Return PrestacionesDinero
        End Get
        Set(value As Double)
            PrestacionesDinero = value
        End Set
    End Property

    Public Property PGastosMedicos As Double
        Get
            Return GastosMedicos
        End Get
        Set(value As Double)
            GastosMedicos = value
        End Set
    End Property

    Public Property PinvalidezVida As Double
        Get
            Return invalidezVida
        End Get
        Set(value As Double)
            invalidezVida = value
        End Set
    End Property

    Public Property PCesantia As Double
        Get
            Return Cesantia
        End Get
        Set(value As Double)
            Cesantia = value
        End Set
    End Property

    Private asegurado As Boolean
    Public Property PAsegurado() As Boolean
        Get
            Return asegurado
        End Get
        Set(ByVal value As Boolean)
            asegurado = value
        End Set
    End Property


    Private fechaInfonavit As Date
    Public Property PFechaInfonavit() As Date
        Get
            Return fechaInfonavit
        End Get
        Set(ByVal value As Date)
            fechaInfonavit = value
        End Set
    End Property
End Class