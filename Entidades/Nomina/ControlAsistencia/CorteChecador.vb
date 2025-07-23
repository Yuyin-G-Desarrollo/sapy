Imports Entidades

Public Class CorteChecador

    Private ccheck_periodo As PeriodosNomina
    Private ccheck_colaborador As Colaborador
    Private ccheck_puntualidad_asistencia As Boolean
    Private ccheck_caja_ahorro As Boolean
    Private ccheck_asistencia As Double
    Private ccheck_retardo_menor As Integer
    Private ccheck_retardo_mayor As Integer
    Private ccheck_inasistencia As Double

    Public Property PPeriodo() As PeriodosNomina
        Get
            Return ccheck_periodo
        End Get
        Set(ByVal value As PeriodosNomina)
            ccheck_periodo = value
        End Set
    End Property

    Public Property PColaborador() As Colaborador
        Get
            Return ccheck_colaborador
        End Get
        Set(ByVal value As Colaborador)
            ccheck_colaborador = value
        End Set
    End Property

    Public Property PPpuntualidad_asistencia() As Boolean
        Get
            Return ccheck_puntualidad_asistencia
        End Get
        Set(ByVal value As Boolean)
            ccheck_puntualidad_asistencia = value
        End Set
    End Property

    Public Property PCaja_Ahorro() As Boolean
        Get
            Return ccheck_caja_ahorro
        End Get
        Set(ByVal value As Boolean)
            ccheck_caja_ahorro = value
        End Set
    End Property

    Public Property PAsistencia() As Double
        Get
            Return ccheck_asistencia
        End Get
        Set(ByVal value As Double)
            ccheck_asistencia = value
        End Set
    End Property

    Public Property PRetardo_menor() As Integer
        Get
            Return ccheck_retardo_menor
        End Get
        Set(ByVal value As Integer)
            ccheck_retardo_menor = value
        End Set
    End Property

    Public Property PRetardo_mayor() As Integer
        Get
            Return ccheck_retardo_mayor
        End Get
        Set(ByVal value As Integer)
            ccheck_retardo_mayor = value
        End Set
    End Property

    Public Property PInasistencia() As Double
        Get
            Return ccheck_inasistencia
        End Get
        Set(ByVal value As Double)
            ccheck_inasistencia = value
        End Set
    End Property

End Class
