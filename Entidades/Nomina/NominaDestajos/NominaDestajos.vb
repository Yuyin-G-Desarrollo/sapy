Public Class NominaDestajos

    Private IdProduccionNomina As Integer
    Private IdPeriodoNomina As Integer
    Private NSandalia As Integer
    Private CSandalia As Double
    Private NChoclo As Integer
    Private CChoclo As Double
    Private NBotin As Integer
    Private CBotin As Double
    Private NMediaBota As Integer
    Private CMediaBota As Double
    Private NBotaAlata As Integer
    Private CBotalAlta As Double
    Private ParesEmbarcados As Integer
    Private paresCapturados As Integer
    Private IdCelula As Integer
    Private IdNaveSicy As Integer
    Private IdCelulaSicy As Integer
    Private FechaInicial As Date
    Private fechafinal As Date

    Public Property PIdNave As Integer

    Public Property PIdCelulaSicy As Integer
        Get
            Return IdCelulaSicy
        End Get
        Set(value As Integer)
            IdCelulaSicy = value
        End Set
    End Property

    Public Property PIdNaveSicy As Integer
        Get
            Return IdNaveSicy
        End Get
        Set(value As Integer)
            IdNaveSicy = value
        End Set
    End Property

    Public Property PFechaInicial As Date
        Get
            Return FechaInicial
        End Get
        Set(value As Date)
            FechaInicial = value
        End Set
    End Property

    Public Property PFechaFinal As Date
        Get
            Return fechafinal
        End Get
        Set(value As Date)
            fechafinal = value
        End Set
    End Property


    Public Property PIdProdNom As Int32
        Get
            Return IdProduccionNomina
        End Get
        Set(value As Int32)
            IdProduccionNomina = value
        End Set
    End Property

    Public Property PIdPeriodo As Int32
        Get
            Return IdPeriodoNomina
        End Get
        Set(value As Int32)
            IdPeriodoNomina = value
        End Set
    End Property

    Public Property PNSandalia As Int32
        Get
            Return NSandalia
        End Get
        Set(value As Int32)
            NSandalia = value
        End Set
    End Property

    Public Property PCSandalia As Double
        Get
            Return CSandalia
        End Get
        Set(value As Double)
            CSandalia = value
        End Set
    End Property

    Public Property PNChoclo As Int32
        Get
            Return NChoclo
        End Get
        Set(value As Int32)
            NChoclo = value
        End Set
    End Property

    Public Property PCChoclo As Double
        Get
            Return CChoclo
        End Get
        Set(value As Double)
            CChoclo = value
        End Set
    End Property

    Public Property PNBotin As Int32
        Get
            Return NBotin
        End Get
        Set(value As Int32)
            NBotin = value
        End Set
    End Property

    Public Property PCBotin As Double
        Get
            Return CBotin
        End Get
        Set(value As Double)
            CBotin = value
        End Set
    End Property

    Public Property PNMediaBota As Integer
        Get
            Return NMediaBota
        End Get
        Set(value As Integer)
            NMediaBota = value
        End Set
    End Property

    Public Property PCMediaBota As Double
        Get
            Return CMediaBota
        End Get
        Set(value As Double)
            CMediaBota = value
        End Set
    End Property

    Public Property PNBotaALta As Int32
        Get
            Return NBotaAlata
        End Get
        Set(value As Int32)
            NBotaAlata = value
        End Set
    End Property

    Public Property PCBotalAlta As Double
        Get
            Return CBotalAlta
        End Get
        Set(value As Double)
            CBotalAlta = value
        End Set
    End Property

    Public Property PParesEMbarcados As Integer
        Get
            Return ParesEmbarcados
        End Get
        Set(value As Integer)
            ParesEmbarcados = value
        End Set
    End Property

    Public Property PParesCapturados As Integer
        Get
            Return paresCapturados
        End Get
        Set(value As Integer)
            paresCapturados = value
        End Set
    End Property

    Public Property PIdCelula As Int32
        Get
            Return IdCelula
        End Get
        Set(value As Int32)
            IdCelula = value
        End Set
    End Property

End Class

