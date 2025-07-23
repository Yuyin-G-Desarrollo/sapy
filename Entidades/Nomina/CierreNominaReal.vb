Public Class CierreNominaReal
    Private colaboradorId As Integer
    Public Property PcolaboradorId As Integer
        Get
            Return colaboradorId
        End Get
        Set(value As Integer)
            colaboradorId = value
        End Set
    End Property

    Private periodoNomina As Integer
    Public Property PperiodoNomina As Integer
        Get
            Return periodoNomina
        End Get
        Set(value As Integer)
            periodoNomina = value
        End Set
    End Property

    Private salarioDiario As Double
    Public Property PsalarioDiario As Double
        Get
            Return salarioDiario
        End Get
        Set(value As Double)
            salarioDiario = value
        End Set
    End Property

    Private salarioSemanal As Double
    Public Property PsalarioSemanal As Double
        Get
            Return salarioSemanal
        End Get
        Set(value As Double)
            salarioSemanal = value
        End Set
    End Property

    Private puntualidadAsistencia As Double
    Public Property PpuntualidadAsistencia As Double
        Get
            Return puntualidadAsistencia
        End Get
        Set(value As Double)
            puntualidadAsistencia = value
        End Set
    End Property

    Private gratificaciones As Double
    Public Property Pgratificaciones As Double
        Get
            Return gratificaciones
        End Get
        Set(value As Double)
            gratificaciones = value
        End Set
    End Property

    Private gratificacionCumple As Double
    Public Property PgratificacionCumple As Double
        Get
            Return gratificacionCumple
        End Get
        Set(value As Double)
            gratificacionCumple = value
        End Set
    End Property

    Private montoInfonavit As Double
    Public Property PmontoInfonavit As Double
        Get
            Return montoInfonavit
        End Get
        Set(value As Double)
            montoInfonavit = value
        End Set
    End Property

    Private montoIMSS As Double
    Public Property PmontoIMSS As Double
        Get
            Return montoIMSS
        End Get
        Set(value As Double)
            montoIMSS = value
        End Set
    End Property

    Private montoISR As Double
    Public Property PmontoISR As Double
        Get
            Return montoISR
        End Get
        Set(value As Double)
            montoISR = value
        End Set
    End Property

    Private diasLaborados As Double
    Public Property PdiasLaborados As Double
        Get
            Return diasLaborados
        End Get
        Set(value As Double)
            diasLaborados = value
        End Set
    End Property

    Private faltas As Double
    Public Property Pfaltas As Double
        Get
            Return faltas
        End Get
        Set(value As Double)
            faltas = value
        End Set
    End Property

    Private montoAustentismos As Double
    Public Property PmontoAustentismos As Double
        Get
            Return montoAustentismos
        End Get
        Set(value As Double)
            montoAustentismos = value
        End Set
    End Property

    Private incapacidades As Double
    Public Property PIncapacidad As Double
        Get
            Return incapacidades
        End Get
        Set(value As Double)
            incapacidades = value
        End Set
    End Property

    Private pagoPrestamos As Double
    Public Property PpagoPrestamos As Double
        Get
            Return pagoPrestamos
        End Get
        Set(value As Double)
            pagoPrestamos = value
        End Set
    End Property

    Private cajaAhorro As Double
    Public Property PcajaAhorro As Double
        Get
            Return cajaAhorro
        End Get
        Set(value As Double)
            cajaAhorro = value
        End Set
    End Property

    Private otrasDeducciones As Double
    Public Property PotrasDeducciones As Double
        Get
            Return otrasDeducciones
        End Get
        Set(value As Double)
            otrasDeducciones = value
        End Set
    End Property

    Private totalPagado As Double
    Public Property PtotalPagado As Double
        Get
            Return totalPagado
        End Get
        Set(value As Double)
            totalPagado = value
        End Set
    End Property

    Private finiquitoId As Integer
    Public Property PfiniquitoId As Integer
        Get
            Return finiquitoId
        End Get
        Set(value As Integer)
            finiquitoId = value
        End Set
    End Property

    Private tipoPago As String
    Public Property PtipoPago As String
        Get
            Return tipoPago
        End Get
        Set(value As String)
            tipoPago = value
        End Set
    End Property

    Private tipoSueldo As String
    Public Property PtipoSueldo As String
        Get
            Return tipoSueldo
        End Get
        Set(value As String)
            tipoSueldo = value
        End Set
    End Property
End Class
