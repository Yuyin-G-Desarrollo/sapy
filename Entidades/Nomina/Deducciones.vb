Public Class Deducciones
    Private SemGanadas As Boolean
    Private Condonacion As Boolean


    Private Colaborador As Colaborador
    Private Departamento As String
    Private Puesto As String
    Private Cobranza As CobranzaPrestamos
    Private DeduccionTipo As Integer
    Private ConceptoDeduccion As String
    Private MontoDeduccion As Double
    Private idCreo As Integer
    Private idModifico As Integer

    Private PagoID As Integer
    Private NumeroSemanas As Integer
    Private Estatus As String
    Private Saldo As Double
    Private SaldoAnterior As Double
    Private abono As Double
    Private FechaCreacion As DateTime
    Private FechaModificacion As DateTime
    Private FechaLiquidacion As DateTime
    Private NumeroPago As Integer

    Private idDeduccion As Integer
    Private TotalDeducciones As Double
    Private NumeroDeducciones As Integer
    Private SemanaNominaID As Integer


    Public Property PCondonacion As Boolean
        Get
            Return Condonacion
        End Get
        Set(ByVal value As Boolean)
            Condonacion = value
        End Set
    End Property

    Public Property PSemGanadas As Boolean
        Get
            Return SemGanadas
        End Get
        Set(ByVal value As Boolean)
            SemGanadas = value
        End Set
    End Property

    Public Property PPagoID As Integer
        Get
            Return PagoID
        End Get
        Set(ByVal value As Integer)
            PagoID = value
        End Set
    End Property

    Public Property PSemanaNominaID As Integer
        Get
            Return SemanaNominaID
        End Get
        Set(ByVal value As Integer)
            SemanaNominaID = value
        End Set
    End Property

    Public Property PNumeroPago As Integer
        Get
            Return NumeroPago
        End Get
        Set(ByVal value As Integer)
            NumeroPago = value
        End Set
    End Property

    Public Property PFechaLiquidacion As DateTime
        Get
            Return FechaLiquidacion
        End Get
        Set(ByVal value As DateTime)
            FechaLiquidacion = value
        End Set
    End Property

    Public Property PFechaCreacion As DateTime
        Get
            Return FechaCreacion
        End Get
        Set(ByVal value As DateTime)
            FechaCreacion = value
        End Set
    End Property

    Public Property PFechaModificacion As DateTime
        Get
            Return FechaModificacion
        End Get
        Set(ByVal value As DateTime)
            FechaModificacion = value
        End Set
    End Property

    Public Property Pabono As Double
        Get
            Return abono
        End Get
        Set(ByVal value As Double)
            abono = value
        End Set
    End Property

    Public Property PSaldo As Double
        Get
            Return Saldo
        End Get
        Set(ByVal value As Double)
            Saldo = value
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

    Public Property PEstatus As String
        Get
            Return Estatus

        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property

    Public Property PnumeroSemanas As Integer
        Get
            Return NumeroSemanas
        End Get
        Set(ByVal value As Integer)
            NumeroSemanas = value
        End Set
    End Property

    Public Property PTotalDeducciones As Double
        Get
            Return TotalDeducciones
        End Get
        Set(ByVal value As Double)
            TotalDeducciones = value
        End Set
    End Property

    Public Property PNumeroDeducciones As Integer
        Get
            Return NumeroDeducciones
        End Get
        Set(ByVal value As Integer)
            NumeroDeducciones = value
        End Set
    End Property

    Public Property PidCreo As Integer
        Get
            Return idCreo
        End Get
        Set(ByVal value As Integer)
            idCreo = value
        End Set
    End Property

    Public Property PidModifico As Integer
        Get
            Return idModifico
        End Get
        Set(ByVal value As Integer)
            idModifico = value
        End Set
    End Property


    Public Property PidDeduccion As Integer
        Get
            Return idDeduccion
        End Get
        Set(ByVal value As Integer)
            idDeduccion = value
        End Set
    End Property

    Public Property PConceptoDeduccion As String
        Get
            Return ConceptoDeduccion

        End Get
        Set(ByVal value As String)
            ConceptoDeduccion = value
        End Set
    End Property

    Public Property PMontoDeduccion As Double
        Get
            Return MontoDeduccion
        End Get
        Set(ByVal value As Double)
            MontoDeduccion = value
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

    Public Property PDepartamento As String
        Get
            Return Departamento
        End Get
        Set(ByVal value As String)
            Departamento = value
        End Set
    End Property

    Public Property PPuesto As String
        Get
            Return Puesto
        End Get
        Set(ByVal value As String)
            Puesto = value
        End Set
    End Property

    Public Property PCobranza As CobranzaPrestamos
        Get
            Return Cobranza
        End Get
        Set(ByVal value As CobranzaPrestamos)
            Cobranza = value
        End Set
    End Property

    Public Property PDeduccionTipo As Integer
        Get
            Return DeduccionTipo
        End Get
        Set(ByVal value As Integer)
            DeduccionTipo = value
        End Set
    End Property

End Class
