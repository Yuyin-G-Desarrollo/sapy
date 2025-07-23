Public Class CobranzaPrestamos
    Private numPago As Integer
    Private semanaNomina As Integer
    Private semanaNominaId As Integer

    Private PeriodoNominaCajaAhorro As String
    Private PeriodoNominaAsistencia As String
    Private PeriodoNominaNomina As String
    Private PeriodoNominaPrestamos As String
    Private PeriodoNominaDestajos As String
    Private PeriodoNominaFiscal As String
    Private ConceptoSemana As String
    Private PeriodoNominaDeducciones As String

    Private saldoAnterior As Double
    Private liquidacion As Integer
    Private SolicitudPrestamo As SolicitudPrestamo
    Private Colaborador As Colaborador
    Private FechaInicioNomina As DateTime
    Private FechaFinNomina As DateTime
    Private FechaModificacion As SolicitudPrestamo
    Private pagoID As Integer

    Private TipoAbono As String
    Private Delete As Int32

    Private AbonoCobranza As Double
    Private InteresCobranza As Double

    Private NaveIDSICY As Integer

    Public Property PInteresCobranza As Double
        Get
            Return InteresCobranza
        End Get
        Set(ByVal value As Double)
            InteresCobranza = value
        End Set
    End Property

    Public Property PAbonoCobranza As Double
        Get
            Return AbonoCobranza
        End Get
        Set(ByVal value As Double)
            AbonoCobranza = value
        End Set
    End Property

    Public Property PDelete As Int32
        Get
            Return Delete
        End Get
        Set(ByVal value As Int32)
            Delete = value
        End Set
    End Property

    Public Property PTipoAbono As String
        Get
            Return TipoAbono
        End Get
        Set(ByVal value As String)
            TipoAbono = value
        End Set
    End Property

    Public Property PPeriodoNominaDeducciones As String
        Get
            Return PeriodoNominaDeducciones
        End Get
        Set(ByVal value As String)
            PeriodoNominaDeducciones = value
        End Set
    End Property

    Public Property PConceptoSemana As String
        Get
            Return ConceptoSemana
        End Get
        Set(ByVal value As String)
            ConceptoSemana = value
        End Set
    End Property


    Public Property PPagoId As Integer
        Get
            Return pagoID
        End Get
        Set(ByVal value As Integer)
            pagoID = value
        End Set
    End Property

    Public Property PPeriodoNominaFiscal As String
        Get
            Return PeriodoNominaFiscal
        End Get
        Set(ByVal value As String)
            PeriodoNominaFiscal = value
        End Set
    End Property


    Public Property PPeriodoNominaDestajos As String
        Get
            Return PeriodoNominaDestajos
        End Get
        Set(ByVal value As String)
            PeriodoNominaDestajos = value
        End Set
    End Property

    Public Property PPeriodoNominaPrestamos As String
        Get
            Return PeriodoNominaPrestamos
        End Get
        Set(ByVal value As String)
            PeriodoNominaPrestamos = value
        End Set
    End Property

    Public Property PPeriodoNominaAsistencia As String
        Get
            Return PeriodoNominaAsistencia
        End Get
        Set(ByVal value As String)
            PeriodoNominaAsistencia = value
        End Set
    End Property

    Public Property PPeriodoNominaNomina As String
        Get
            Return PeriodoNominaNomina
        End Get
        Set(ByVal value As String)
            PeriodoNominaNomina = value
        End Set
    End Property

    Public Property PPeriodoNominaCajaAhorro As String
        Get
            Return PeriodoNominaCajaAhorro
        End Get
        Set(ByVal value As String)
            PeriodoNominaCajaAhorro = value
        End Set
    End Property





    Public Property PfechaInicioNomina As DateTime
        Get
            Return FechaInicioNomina
        End Get
        Set(ByVal value As DateTime)
            fechainicionomina = value
        End Set
    End Property

    Public Property PfechaFinNomina As DateTime
        Get
            Return FechaFinNomina
        End Get
        Set(ByVal value As DateTime)
            FechaFinNomina = value
        End Set
    End Property




    Public Property Pcolaborador As Entidades.Colaborador
        Get
            Return Colaborador
        End Get
        Set(ByVal value As Entidades.Colaborador)
            Colaborador = value

        End Set
    End Property

    Public Property PSolicitudPrestamo As Entidades.SolicitudPrestamo
        Get
            Return SolicitudPrestamo
        End Get
        Set(ByVal value As Entidades.SolicitudPrestamo)
            SolicitudPrestamo = value

        End Set
    End Property


    Public Property PfechaModificacion As Entidades.SolicitudPrestamo
        Get
            Return FechaModificacion
        End Get
        Set(ByVal value As Entidades.SolicitudPrestamo)
            FechaModificacion = value

        End Set
    End Property





    Public Property Pliquidacion As Integer
        Get
            Return liquidacion
        End Get
        Set(ByVal value As Integer)
            liquidacion = value

        End Set
    End Property


    Public Property PnumPago As Integer
        Get
            Return numPago
        End Get
        Set(ByVal value As Integer)
            numPago = value

        End Set
    End Property

    Public Property PsaldoAnterior As Double
        Get
            Return saldoAnterior
        End Get
        Set(ByVal value As Double)
            saldoAnterior = value

        End Set
    End Property

    Public Property PsemanaNomina As Integer
        Get
            Return semanaNomina
        End Get
        Set(ByVal value As Integer)
            semanaNomina = value

        End Set
    End Property

    Public Property PsemanaNominaId As Integer
        Get
            Return semanaNominaId
        End Get
        Set(ByVal value As Integer)
            semanaNominaId = value

        End Set
    End Property

    Public Property PNaveIDSICY As Integer
        Get
            Return NaveIDSICY
        End Get
        Set(value As Integer)
            NaveIDSICY = value
        End Set
    End Property

    ''agregado para obtener numero de dias en periodo de nomina
    Private diasSemana As Double
    Public Property PDiasSemana() As Double
        Get
            Return diasSemana
        End Get
        Set(ByVal value As Double)
            diasSemana = value
        End Set
    End Property


End Class


