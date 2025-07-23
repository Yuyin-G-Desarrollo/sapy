

Public Class FiniquitoFiscal

#Region "Variables"

    Private PInformacionColoaborador As InformacionIDSE_SUA
    Private PUSMO As FiniquitoRetencionUSMO
    Private PISR As FiniquitoRetencionISR
    Private PFinquitoFiscalID As Integer
    Private PColaboradorID As Integer
    Private PPeriodoNomidaID As Integer
    Private PSolicitudBajaID As Integer
    Private PPatronID As Integer
    Private PSalarioMinimo As Double
    Private PFechaBaja As Date
    Private PAntiguedad As String
    Private PDiasEnCurso As Integer = 0
    Private PSMAG As Double = 0
    Private PFechaInicioCurso As Date
    Private PFechaUltimoPagoVacaciones As Date

    Private PDiasVacacionesAño As Double = 0
    Private PAñosLaborando As Double = 0
    Private PDiasVacacionesCorresponden As Double = 0
    Private PTotalVacaciones As Double = 0

    Private PFactorAguinaldo As Double = 0
    Private PMesesLaborandoDelAño As Double = 0
    Private PDiasAguinaldo As Double = 0
    Private PTotalAguinaldo As Double = 0
    Private PDiasAguinaldoCorresponden As Double = 0

    Private PPrimaVacacional As Double = 0
    Private PIndemizacionFiniquito As Double = 0
    Private PTotalAntesImpuestos As Double = 0
    Private PISRRetenido As Double = 0
    Private PNetoRecibir As Double = 0
    Private PTotalGravado As Double = 0

    Private PUsuarioCreoID As Integer = 0
    Private PFechaCreacion As Date
    Private PSubTotalEntregar As Double = 0

    Private PImpuestoRetenerFavor As Double = 0


#End Region

#Region "Propiedades"

    Public Property ImpuestoRetenerFavor As Double
        Get
            Return PImpuestoRetenerFavor
        End Get
        Set(ByVal value As Double)
            PImpuestoRetenerFavor = value
        End Set
    End Property

    Public Property SubTotalEntregar As Double
        Get
            Return PSubTotalEntregar
        End Get
        Set(ByVal value As Double)
            PSubTotalEntregar = value
        End Set
    End Property

    Public Property FinquitoFiscalID As Integer
        Get
            Return PFinquitoFiscalID
        End Get
        Set(ByVal value As Integer)
            PFinquitoFiscalID = value
        End Set
    End Property

    Public Property SalarioMinimo As Double
        Get
            Return PSalarioMinimo
        End Get
        Set(ByVal value As Double)
            PSalarioMinimo = value
        End Set
    End Property

    Public Property PatronID As Integer
        Get
            Return PPatronID
        End Get
        Set(ByVal value As Integer)
            PPatronID = value
        End Set
    End Property

    Public Property SolicitudBajaID As Integer
        Get
            Return PSolicitudBajaID
        End Get
        Set(ByVal value As Integer)
            PSolicitudBajaID = value
        End Set
    End Property

    Public Property FechaCreacion As Date
        Get
            Return PFechaCreacion
        End Get
        Set(ByVal value As Date)
            PFechaCreacion = value
        End Set

    End Property


    Public Property UsuarioCreoID As Integer
        Get
            Return PUsuarioCreoID
        End Get
        Set(ByVal value As Integer)
            PUsuarioCreoID = value
        End Set

    End Property

    Public Property DiasAguinaldoCorresponden As Double
        Get
            Return PDiasAguinaldoCorresponden
        End Get
        Set(ByVal value As Double)
            PDiasAguinaldoCorresponden = value
        End Set

    End Property



    Public Property PeriodoNomidaID As Integer
        Get
            Return PPeriodoNomidaID
        End Get
        Set(ByVal value As Integer)
            PPeriodoNomidaID = value
        End Set
    End Property


    Public Property ColaboradorID As Integer
        Get
            Return PColaboradorID
        End Get
        Set(ByVal value As Integer)
            PColaboradorID = value
        End Set
    End Property

    Public Property InformacionColoaborador As InformacionIDSE_SUA
        Get
            Return PInformacionColoaborador
        End Get
        Set(ByVal value As InformacionIDSE_SUA)
            PInformacionColoaborador = value
        End Set
    End Property


    Public Property USMO As FiniquitoRetencionUSMO
        Get
            Return PUSMO
        End Get
        Set(ByVal value As FiniquitoRetencionUSMO)
            PUSMO = value
        End Set
    End Property

    Public Property ISR As FiniquitoRetencionISR
        Get
            Return PISR
        End Get
        Set(ByVal value As FiniquitoRetencionISR)
            PISR = value
        End Set
    End Property

    Public Property FechaBaja As Date
        Get
            Return PFechaBaja
        End Get
        Set(ByVal value As Date)
            PFechaBaja = value
        End Set
    End Property


    Public Property Antiguedad As String
        Get
            Return PAntiguedad
        End Get
        Set(ByVal value As String)
            PAntiguedad = value
        End Set
    End Property

    Public Property DiasEnCurso As Integer
        Get
            Return PDiasEnCurso
        End Get
        Set(ByVal value As Integer)
            PDiasEnCurso = value
        End Set
    End Property

    Public Property SMAG As Double
        Get
            Return PSMAG
        End Get
        Set(ByVal value As Double)
            PSMAG = value
        End Set
    End Property

    Public Property FechaInicioCurso As Date
        Get
            Return PFechaInicioCurso
        End Get
        Set(ByVal value As Date)
            PFechaInicioCurso = value
        End Set
    End Property

    Public Property FechaUltimoPagoVacaciones As Date
        Get
            Return PFechaUltimoPagoVacaciones
        End Get
        Set(ByVal value As Date)
            PFechaUltimoPagoVacaciones = value
        End Set
    End Property

    Public Property DiasVacacionesAño As Double
        Get
            Return PDiasVacacionesAño
        End Get
        Set(ByVal value As Double)
            PDiasVacacionesAño = value
        End Set
    End Property


    Public Property AñosLaborando As Double
        Get
            Return PAñosLaborando
        End Get
        Set(ByVal value As Double)
            PAñosLaborando = value
        End Set
    End Property

    Public Property DiasVacacionesCorresponden As Double
        Get
            Return PDiasVacacionesCorresponden
        End Get
        Set(ByVal value As Double)
            PDiasVacacionesCorresponden = value
        End Set
    End Property

    Public Property TotalVacaciones As Double
        Get
            Return PTotalVacaciones
        End Get
        Set(ByVal value As Double)
            PTotalVacaciones = value
        End Set
    End Property

    Public Property FactorAguinaldo As Double
        Get
            Return PFactorAguinaldo
        End Get
        Set(ByVal value As Double)
            PFactorAguinaldo = value
        End Set
    End Property

    Public Property MesesLaborandoDelAño As Double
        Get
            Return PMesesLaborandoDelAño
        End Get
        Set(ByVal value As Double)
            PMesesLaborandoDelAño = value
        End Set
    End Property

    Public Property DiasAguinaldo As Double
        Get
            Return PDiasAguinaldo
        End Get
        Set(ByVal value As Double)
            PDiasAguinaldo = value
        End Set
    End Property

    Public Property TotalAguinaldo As Double
        Get
            Return PTotalAguinaldo
        End Get
        Set(ByVal value As Double)
            PTotalAguinaldo = value
        End Set
    End Property

    Public Property PrimaVacacional As Double
        Get
            Return PPrimaVacacional
        End Get
        Set(ByVal value As Double)
            PPrimaVacacional = value
        End Set
    End Property

    Public Property IndemizacionFiniquito As Double
        Get
            Return PIndemizacionFiniquito
        End Get
        Set(ByVal value As Double)
            PIndemizacionFiniquito = value
        End Set
    End Property

    Public Property TotalAntesImpuestos As Double
        Get
            Return PTotalAntesImpuestos
        End Get
        Set(ByVal value As Double)
            PTotalAntesImpuestos = value
        End Set
    End Property


    Public Property ISRRetenido As Double
        Get
            Return PISRRetenido
        End Get
        Set(ByVal value As Double)
            PISRRetenido = value
        End Set
    End Property

    Public Property NetoRecibir As Double
        Get
            Return PNetoRecibir
        End Get
        Set(ByVal value As Double)
            PNetoRecibir = value
        End Set
    End Property

    Public Property TotalGravado As Double
        Get
            Return PTotalGravado
        End Get
        Set(ByVal value As Double)
            PTotalGravado = value
        End Set
    End Property

    Private aniosVacaciones As Double
    Public Property PAniosVacaciones() As Double
        Get
            Return aniosVacaciones
        End Get
        Set(ByVal value As Double)
            aniosVacaciones = value
        End Set
    End Property

#End Region

    Sub New()
        PInformacionColoaborador = New InformacionIDSE_SUA
        PUSMO = New FiniquitoRetencionUSMO
        PISR = New FiniquitoRetencionISR
    End Sub


End Class


