Public Class CalcularAguinaldos
    Private Colaborador As Colaborador
    Private ColaboradorReal As ColaboradorReal
    Private nominaReal As CalcularNominaReal
    Private Naves As Naves

    Private SalarioXmes As Double
    Private AguinaldoAnio As Integer
    Private AguinaldoMeses As Double
    Private DiasxPagar As Double
    Private tipoSueldo As String

    Private fecha1 As DateTime
    Private fecha2 As DateTime
    Private fecha3 As DateTime
    Private fecha4 As DateTime

    Private diasLaborados As Integer

    Public Property PtipoSueldo As String
        Get
            Return tipoSueldo
        End Get
        Set(value As String)
            tipoSueldo = value
        End Set
    End Property

    Public Property PdiasLaborados As Integer
        Get
            Return diasLaborados
        End Get
        Set(value As Integer)
            diasLaborados = value
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

    Public Property PSalarioXmes As Double
        Get
            Return SalarioXmes
        End Get
        Set(ByVal value As Double)
            SalarioXmes = value
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


    Public Property PAguinaldoMeses As Double
        Get
            Return AguinaldoMeses
        End Get
        Set(ByVal value As Double)
            AguinaldoMeses = value
        End Set
    End Property


    Public Property PAguinaldoAnio As Integer
        Get
            Return AguinaldoAnio
        End Get
        Set(ByVal value As Integer)
            AguinaldoAnio = value
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



End Class
