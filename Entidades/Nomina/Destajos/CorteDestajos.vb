Public Class CorteDestajos
    Private Colaborador As Colaborador
    Private NaveID As Integer
    Private DepartementoID As Integer
    Private CelulaID As Integer
    Private RealCantidad As Double
    Private FechaTicket As DateTime
    Private PeriodoNominaID As Integer
    Private TotalDestajos As Double
    Private ajusteDestajo As Double
    Private usuarioCreo As Integer
    Private fechaCreacion As Date
    Private faltas As Double
    Private totalPagar As Double

    Public Property PTotalPagar As Double
        Get
            Return totalPagar
        End Get
        Set(value As Double)
            totalPagar = value
        End Set
    End Property

    Public Property pFaltas As Double
        Get
            Return faltas
        End Get
        Set(value As Double)
            faltas = value
        End Set
    End Property


    Public Property PusuarioCreo As Integer
        Get
            Return usuarioCreo
        End Get
        Set(value As Integer)
            usuarioCreo = value
        End Set
    End Property

    Public Property PfechaCreacion As Date
        Get
            Return fechaCreacion
        End Get
        Set(value As Date)
            fechaCreacion = value
        End Set
    End Property

    Public Property PajusteDestajo As Double
        Get
            Return ajusteDestajo
        End Get
        Set(value As Double)
            ajusteDestajo = value
        End Set
    End Property

    Public Property PColaborador As Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Colaborador)
            Colaborador = value
        End Set
    End Property

    Public Property PRealCantidad As Double
        Get
            Return RealCantidad
        End Get
        Set(value As Double)
            RealCantidad = value
        End Set
    End Property

    Public Property PFechaTicket As DateTime
        Get
            Return FechaTicket
        End Get
        Set(value As DateTime)
            FechaTicket = value
        End Set
    End Property

    Public Property PPeriodoNominaID As Integer
        Get
            Return PeriodoNominaID
        End Get
        Set(value As Integer)
            PeriodoNominaID = value
        End Set
    End Property

    Public Property PTotalDestajos As Double
        Get
            Return TotalDestajos
        End Get
        Set(value As Double)
            TotalDestajos = value
        End Set
    End Property

End Class
