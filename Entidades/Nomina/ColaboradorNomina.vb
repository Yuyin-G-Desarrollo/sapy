Public Class ColaboradorNomina
    Private ColaboradorNominaId As Int32
    Private Colaborador As Colaborador

    Private Salario As Double
    Private SalarioIntegrado As Double
    Private Patron As Patrones
    Private Nss As String
    Private FechaAltaImss As Date
    Private FormaPago As String
    Private Cuenta As String
    Private Afore As String
    Private Infonavit As Boolean
    Private BancoId As Int32
    Private SalarioDiario As Double
    Private InfonavitTipo As Int32
    Private InfonavitMonto As Double
    Private fechaAltaInfonavit As DateTime
    Private MontoISR As Double
    Private asegurado As Boolean
    Private externo As Boolean
    Private CPSAT As String

    Public Property PSalarioIntegrado As Double
        Get
            Return SalarioIntegrado
        End Get
        Set(value As Double)
            SalarioIntegrado = value
        End Set
    End Property

    Public Property PfechaAltaInfonavit As DateTime
        Get
            Return fechaAltaInfonavit
        End Get
        Set(value As DateTime)
            fechaAltaInfonavit = value
        End Set
    End Property


    Public Property PInfonavitMonto As Double
        Get
            Return InfonavitMonto
        End Get
        Set(ByVal value As Double)
            InfonavitMonto = value
        End Set
    End Property

    Public Property PInfonavitTipo As Int32
        Get
            Return InfonavitTipo
        End Get
        Set(ByVal value As Int32)
            InfonavitTipo = value
        End Set
    End Property


    Public Property PSalarioDiario As Double
        Get
            Return SalarioDiario
        End Get
        Set(ByVal value As Double)
            SalarioDiario = value
        End Set
    End Property

    Public Property PBancoID As Int32
        Get
            Return BancoId
        End Get
        Set(ByVal value As Int32)
            BancoId = value
        End Set
    End Property

    Public Property PInfonavit As Boolean
        Get
            Return Infonavit
        End Get
        Set(ByVal value As Boolean)
            Infonavit = value
        End Set
    End Property

    Public Property PAfore As String
        Get
            Return Afore
        End Get
        Set(ByVal value As String)
            Afore = value
        End Set
    End Property

    Public Property PColaboradorNominaId As Int32
        Get
            Return ColaboradorNominaId
        End Get
        Set(ByVal value As Int32)
            ColaboradorNominaId = value
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

    Public Property PSalario As Double
        Get
            Return Salario
        End Get
        Set(ByVal value As Double)
            Salario = value
        End Set
    End Property

    Public Property PPatron As Patrones
        Get
            Return Patron
        End Get
        Set(ByVal value As Patrones)
            Patron = value
        End Set
    End Property

    Public Property PNss As String
        Get
            Return Nss
        End Get
        Set(ByVal value As String)
            Nss = value
        End Set
    End Property

    Public Property PFechaAltaImss As Date
        Get
            Return FechaAltaImss
        End Get
        Set(ByVal value As Date)
            FechaAltaImss = value
        End Set
    End Property

    Public Property PFormaPago As String
        Get
            Return FormaPago
        End Get
        Set(ByVal value As String)
            FormaPago = value
        End Set
    End Property

    Public Property PCuenta As String
        Get
            Return Cuenta
        End Get
        Set(ByVal value As String)
            Cuenta = value
        End Set
    End Property

    Public Property PMontoISR As Double
        Get
            Return MontoISR
        End Get
        Set(ByVal value As Double)
            MontoISR = value
        End Set
    End Property

    Public Property PAsegurado() As Boolean
        Get
            Return asegurado
        End Get
        Set(ByVal value As Boolean)
            asegurado = value
        End Set
    End Property

    Public Property PExterno() As Boolean
        Get
            Return externo
        End Get
        Set(ByVal value As Boolean)
            externo = value
        End Set
    End Property

    Public Property PCPSAT() As String
        Get
            Return CPSAT
        End Get
        Set(ByVal value As String)
            CPSAT = value
        End Set
    End Property



End Class

