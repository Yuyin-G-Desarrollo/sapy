Public Class SolicitudPrestamo

    Private editarAbono As Boolean
    Private editarmonto As Boolean
    Private prestamoid As Integer
    Private colaborador As Colaborador
    Private usuariocreoid As Integer
    Private montoprestamo As Double
    Private interes As Double
    Private motivoprestamoid As Integer
    Private semanas As Integer
    Private solicitudid As Integer
    Private estatus As String
    Private saldo As Double
    Private justificacion As String
    Private abono As Double
    Private TotalInteres As Double
    Private tipointeres As String
    Private gerenteID As Integer
    Private directorID As Integer
    Private fechaDirector As DateTime
    Private fechaGerente As DateTime
    Private fechaModificacion As DateTime
    Private fechaCreacion As DateTime
    Private fechaEntrega As DateTime
    Private cobranzaPrestamos As CobranzaPrestamos
    Private PeriodoNomina As PeriodosNomina
    Private CajaAhorro As CajaAhorro
    Private PagoTotal As Double
    Private FechaFinCaja As DateTime

    Public Property PeditarMonto As Boolean
        Get
            Return editarmonto
        End Get
        Set(value As Boolean)
            editarmonto = value
        End Set
    End Property

    Public Property PeditarAbono As Boolean
        Get
            Return editarAbono
        End Get
        Set(value As Boolean)
            editarAbono = value
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


    Public Property PPeriodoNomina As PeriodosNomina
        Get
            Return PeriodoNomina
        End Get
        Set(ByVal value As PeriodosNomina)
            PeriodoNomina = value
        End Set
    End Property

    Public Property PPagoTotal As Double
        Get
            Return PagoTotal
        End Get
        Set(ByVal value As Double)
            PagoTotal = value

        End Set
    End Property


    Public Property PfechaCreacion As DateTime
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            fechaCreacion = value

        End Set
    End Property
    Public Property PfechaEntrega As DateTime
        Get
            Return fechaEntrega
        End Get
        Set(ByVal value As DateTime)
            fechaEntrega = value

        End Set
    End Property

    Public Property PfechaGerente As DateTime
        Get
            Return fechaGerente
        End Get
        Set(ByVal value As DateTime)
            fechaGerente = value

        End Set
    End Property

    Public Property PfechaDirector As DateTime
        Get
            Return fechaDirector
        End Get
        Set(ByVal value As DateTime)
            fechaDirector = value

        End Set
    End Property

    Public Property Pfechamodificacion As DateTime
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As DateTime)
            fechaModificacion = value

        End Set
    End Property


    Public Property PgerenteId As Integer
        Get
            Return gerenteID
        End Get
        Set(ByVal value As Integer)
            gerenteID = value

        End Set
    End Property


    Public Property PdirectorId As Integer
        Get
            Return directorID
        End Get
        Set(ByVal value As Integer)
            directorID = value

        End Set
    End Property


    Public Property Pprestamoid As Integer
        Get
            Return prestamoid
        End Get
        Set(ByVal value As Integer)
            prestamoid = value
        End Set
    End Property

    Public Property Psolicitudid As Integer
        Get
            Return solicitudid
        End Get
        Set(ByVal value As Integer)
            solicitudid = value
        End Set
    End Property

    Public Property Pcolaborador As Entidades.Colaborador
        Get
            Return colaborador
        End Get
        Set(ByVal value As Entidades.Colaborador)
            colaborador = value
        End Set
    End Property

    Public Property Pusuariocreoid As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property


    Public Property Pmontoprestamo As Double
        Get
            Return montoprestamo
        End Get
        Set(ByVal value As Double)
            montoprestamo = value
        End Set
    End Property

    Public Property Ptotalinteres As Double
        Get
            Return TotalInteres
        End Get
        Set(ByVal value As Double)
            TotalInteres = value
        End Set
    End Property

    Public Property Pinteres As Double
        Get
            Return interes
        End Get
        Set(ByVal value As Double)
            interes = value
        End Set
    End Property

    Public Property Pmotivoprestamoid As Integer
        Get
            Return motivoprestamoid
        End Get
        Set(ByVal value As Integer)
            motivoprestamoid = value
        End Set
    End Property


    Public Property Psemanas As Integer
        Get
            Return semanas
        End Get
        Set(ByVal value As Integer)
            semanas = value
        End Set
    End Property


    Public Property Pestatus As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property

    Public Property Psaldo As Double
        Get
            Return saldo
        End Get
        Set(ByVal value As Double)
            saldo = value
        End Set
    End Property

    Public Property Pjustificacion As String
        Get
            Return justificacion
        End Get
        Set(ByVal value As String)
            justificacion = value
        End Set
    End Property


    Public Property Pabono As Double
        Get
            Return abono
        End Get
        Set(ByVal value As Double)
            abono = value
        End Set
    End Property

    Public Property Ptipointeres As String
        Get
            Return tipointeres
        End Get
        Set(ByVal value As String)
            tipointeres = value
        End Set
    End Property


    Public Property PcobranzaPrestamos As Entidades.CobranzaPrestamos
        Get
            Return cobranzaPrestamos
        End Get
        Set(ByVal value As Entidades.CobranzaPrestamos)
            cobranzaPrestamos = value
        End Set
    End Property

    Public Property PFechaFinCaja As DateTime
        Get
            Return FechaFinCaja
        End Get
        Set(value As DateTime)
            FechaFinCaja = value
        End Set
    End Property

End Class
