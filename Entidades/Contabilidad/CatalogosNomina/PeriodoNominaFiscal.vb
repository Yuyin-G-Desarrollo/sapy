Public Class PeriodoNominaFiscal
    Private idperiodo As Integer
    Public Property PIdPeriodo As Integer
        Get
            Return idperiodo
        End Get
        Set(value As Integer)
            idperiodo = value
        End Set
    End Property

    Private idpatron As Integer
    Public Property PIdPatron As Integer
        Get
            Return idpatron
        End Get
        Set(value As Integer)
            idpatron = value
        End Set
    End Property

    Private fechaini As Date
    Public Property PFechaIni As Date
        Get
            Return fechaIni
        End Get
        Set(value As Date)
            fechaIni = value
        End Set
    End Property

    Private fechafin As Date
    Public Property PFechaFin As Date
        Get
            Return fechafin
        End Get
        Set(value As Date)
            fechafin = value
        End Set
    End Property

    Private numsemana As Integer
    Public Property PNumSemana As Integer
        Get
            Return numsemana
        End Get
        Set(value As Integer)
            numsemana = value
        End Set
    End Property

    Private fechapago As Date
    Public Property PFechaPago As Date
        Get
            Return fechapago
        End Get
        Set(value As Date)
            fechapago = value
        End Set
    End Property

    Private retardos As Integer
    Public Property PRetardos As Integer
        Get
            Return retardos
        End Get
        Set(value As Integer)
            retardos = value
        End Set
    End Property

    Private faltas As Integer
    Public Property PFaltas As Integer
        Get
            Return faltas
        End Get
        Set(value As Integer)
            faltas = value
        End Set
    End Property

    Private faltassem As Integer
    Public Property PFAltasSem As Integer
        Get
            Return faltassem
        End Get
        Set(value As Integer)
            faltassem = value
        End Set
    End Property

    Private diasnomina As Integer
    Public Property PDiasNomina As Integer
        Get
            Return diasnomina
        End Get
        Set(value As Integer)
            diasnomina = value
        End Set
    End Property

    Private bimestre As Integer
    Public Property PBimestre As Integer
        Get
            Return bimestre
        End Get
        Set(value As Integer)
            bimestre = value
        End Set
    End Property

End Class
