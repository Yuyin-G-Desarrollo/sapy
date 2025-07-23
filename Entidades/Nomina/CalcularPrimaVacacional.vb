Public Class CalcularPrimaVacacional

    Private Colaborador As Colaborador
    Private ColaboradorReal As ColaboradorReal
    Private nominaReal As CalcularNominaReal
    Private Naves As Naves

    Private PrimaVacacionalDiasXAños As Double
    Private PrimaVacacionalAnio As Integer
    Private PrimaVacacionalMeses As Double
    Private DiasxPagar As Double
    Private PrimaTotalEntregar As Double
    Private PrimaMeses As Double
    Private PrimaSubtotal As Double
    Private PrimaPrimaVacacional As Double
    Private SueldoDiario As Double
    Private PrimaUsuarioCreo As Integer
    Private tipoSueldo As String
    Private Antiguedad As DateTime
    Private PeriodoVacaciones As String

    Public Property PTipoSueldo As String
        Get
            Return tipoSueldo
        End Get
        Set(value As String)
            tipoSueldo = value
        End Set
    End Property

    Public Property PAntiguedad As DateTime
        Get
            Return Antiguedad
        End Get
        Set(ByVal value As DateTime)
            Antiguedad = value
        End Set
    End Property


    Public Property PPrimaUsuarioCreo As Integer
        Get
            Return PrimaUsuarioCreo
        End Get
        Set(ByVal value As Integer)
            PrimaUsuarioCreo = value
        End Set
    End Property


    Public Property PSueldoDiario As Double
        Get
            Return SueldoDiario
        End Get
        Set(ByVal value As Double)
            SueldoDiario = value
        End Set
    End Property

    Public Property PPrimaTotalEntregar As Double
        Get
            Return PrimaTotalEntregar
        End Get
        Set(ByVal value As Double)
            PrimaTotalEntregar = value
        End Set
    End Property

    Public Property PPrimaPrimaVacacional As Double
        Get
            Return PrimaPrimaVacacional
        End Get
        Set(ByVal value As Double)
            PrimaPrimaVacacional = value
        End Set
    End Property

    Public Property PPrimaSubtotal As Double
        Get
            Return PrimaSubtotal
        End Get
        Set(ByVal value As Double)
            PrimaSubtotal = value
        End Set
    End Property

    Public Property PPrimaMeses As Double
        Get
            Return PrimaMeses
        End Get
        Set(ByVal value As Double)
            PrimaMeses = value
        End Set
    End Property

    Public Property PnominaReal As CalcularNominaReal
        Get
            Return nominaReal
        End Get
        Set(ByVal value As CalcularNominaReal)
            nominaReal = value
        End Set
    End Property

    Public Property PPrimaVacacionalDiasXAños As Double
        Get
            Return PrimaVacacionalDiasXAños
        End Get
        Set(ByVal value As Double)
            PrimaVacacionalDiasXAños = value
        End Set
    End Property

    Public Property PDiasxPagar As Double
        Get
            Return DiasxPagar
        End Get
        Set(ByVal value As Double)
            DiasxPagar = value
        End Set
    End Property


    Public Property PPrimaVacacionalMeses As Double
        Get
            Return PrimaVacacionalMeses
        End Get
        Set(ByVal value As Double)
            PrimaVacacionalMeses = value
        End Set
    End Property


    Public Property PPrimaVacacionalAnio As Integer
        Get
            Return PrimaVacacionalAnio
        End Get
        Set(ByVal value As Integer)
            PrimaVacacionalAnio = value
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


    Public Property PColaboradorReal As ColaboradorReal
        Get
            Return ColaboradorReal
        End Get
        Set(ByVal value As ColaboradorReal)
            ColaboradorReal = value
        End Set
    End Property


    Public Property PNaves As Naves
        Get
            Return Naves
        End Get
        Set(ByVal value As Naves)
            Naves = value
        End Set
    End Property


    Public Property PPeriodoVacaciones As String
        Get
            Return PeriodoVacaciones
        End Get
        Set(ByVal value As String)
            PeriodoVacaciones = value
        End Set
    End Property



End Class
