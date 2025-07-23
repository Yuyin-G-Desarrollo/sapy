Public Class Ticket
    Private NoTicket As String
    Private Descripcion As String
    Private CostoPartida As Double
    Private CantidadPares As Int32
    Private Total As Double
    Private PeriodoNomina As Int32
    Private Fecha As Date
    Private IDRegistro As Int32
    Private IDColaborador As Colaborador
    Private MontoTotal As New Double
    Private TotalTickets As New Int32
    Private NombreColaborador As String
    Private Area As Areas
    Private Departamento As Departamentos
    Private Celula As Celulas
    Private nave As Integer
    Private lote As Integer
    Private anio As Integer
    Public Property pNave As Integer
        Get
            Return nave
        End Get
        Set(value As Integer)
            nave = value
        End Set
    End Property
    Public Property pLote As Integer
        Get
            Return lote
        End Get
        Set(value As Integer)
            lote = value
        End Set
    End Property
    Public Property pAnio As Integer
        Get
            Return anio
        End Get
        Set(value As Integer)
            anio = value
        End Set
    End Property
    Public Property PArea As Areas
        Get
            Return Area
        End Get
        Set(ByVal value As Areas)
            Area = value
        End Set
    End Property
    Public Property PDepartamento As Departamentos
        Get
            Return Departamento
        End Get
        Set(ByVal value As Departamentos)
            Departamento = value
        End Set
    End Property
    Public Property PCelula As Celulas
        Get
            Return Celula
        End Get
        Set(ByVal value As Celulas)
            Celula = value
        End Set
    End Property

    Public Property PNombreColaborador As String
        Get
            Return NombreColaborador
        End Get
        Set(ByVal value As String)
            NombreColaborador = value
        End Set
    End Property

    Public Property PIDColaborador As Colaborador
        Get
            Return IDColaborador
        End Get
        Set(ByVal value As Colaborador)
            IDColaborador = value
        End Set
    End Property
    Public Property PMontoTotal As Double
        Get
            Return MontoTotal
        End Get
        Set(ByVal value As Double)
            MontoTotal = value
        End Set
    End Property
    Public Property PTotalTickets As Int32
        Get
            Return TotalTickets
        End Get
        Set(ByVal value As Int32)
            TotalTickets = value
        End Set
    End Property


    Public Property PIDRegistro As Int32
        Get
            Return IDRegistro
        End Get
        Set(ByVal value As Int32)
            IDRegistro = value
        End Set
    End Property
    Public Property PFecha As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property PPeriodoNomina As Int32
        Get
            Return PeriodoNomina
        End Get
        Set(ByVal value As Int32)
            PeriodoNomina = value
        End Set
    End Property

    Public Property PNoTicket As String
        Get
            Return NoTicket
        End Get
        Set(ByVal value As String)
            NoTicket = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PCostoPartida As Double
        Get
            Return CostoPartida
        End Get
        Set(ByVal value As Double)
            CostoPartida = value
        End Set
    End Property

    Public Property PCantidadPares As Int32
        Get
            Return CantidadPares
        End Get
        Set(ByVal value As Int32)
            CantidadPares = value
        End Set
    End Property

    Public Property PTotal As Double
        Get
            Return Total
        End Get
        Set(ByVal value As Double)
            Total = value
        End Set
    End Property

End Class
