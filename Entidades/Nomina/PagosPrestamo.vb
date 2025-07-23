Public Class PagosPrestamo

    Private SaldoAnterior As Double
    Private SaldoNuevo As Double
    Private Interes As Double
    Private AbonoCapital As Double
    Private fechaPago As Date
    Private interesPrestamos As Double
    Private tipoAbono As String
    Private intAbonoExtra As Double

    Public Property pInteresPresta As Double
    Public Property pFechaPago As Date
        Get
            Return fechaPago
        End Get
        Set(value As Date)
            fechaPago = value
        End Set
    End Property

    Public Property PSaldoAnterior As Double
        Get
            Return SaldoAnterior
        End Get
        Set(ByVal value As Double)
            SaldoAnterior = value
        End Set
    End Property

    Public Property PSaldoNuevo As Double
        Get
            Return SaldoNuevo
        End Get
        Set(ByVal value As Double)
            SaldoNuevo = value
        End Set
    End Property

    Public Property PInteres As Double
        Get
            Return Interes
        End Get
        Set(ByVal value As Double)
            Interes = value
        End Set
    End Property

    Public Property PAbonoCapital As Double
        Get
            Return AbonoCapital
        End Get
        Set(ByVal value As Double)
            AbonoCapital = value
        End Set
    End Property

    Public Property PTipoAbono As String
        Get
            Return tipoAbono
        End Get
        Set(value As String)
            tipoAbono = value
        End Set
    End Property

    Public Property PIntAbonoExtra As Double
        Get
            Return intAbonoExtra
        End Get
        Set(value As Double)
            intAbonoExtra = value
        End Set
    End Property


End Class
