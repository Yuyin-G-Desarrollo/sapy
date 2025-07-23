Public Class ColaboradorPeriodoCaja

    Private CajaAhorro As Entidades.CajaAhorro
    Private Periodo As Entidades.PeriodosNomina
    Private Colaborador As Entidades.Colaborador
    Private MontoAhorrado As Double

    Public Property pCajaAhorro As Entidades.CajaAhorro
        Get
            Return CajaAhorro
        End Get
        Set(value As Entidades.CajaAhorro)
            CajaAhorro = value
        End Set
    End Property

    Public Property pPeriodo As Entidades.PeriodosNomina
        Get
            Return Periodo
        End Get
        Set(value As Entidades.PeriodosNomina)
            Periodo = value
        End Set
    End Property

    Public Property pColaborador As Entidades.Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Entidades.Colaborador)
            Colaborador = value
        End Set
    End Property

    Public Property pMontoAhorrado As Double
        Get
            Return MontoAhorrado
        End Get
        Set(value As Double)
            MontoAhorrado = value
        End Set
    End Property

End Class
