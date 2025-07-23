Public Class CajaAhorro
    Private CajaAhorroId As Int32
    Private Nave As Entidades.Naves
    Private Concepto As String
    Private FechaInicial As Date
    Private FechaFinal As Date
    Private Estado As Char
    Private MontoAhorro As Double
    Private MontoInteres As Double
    Private MontoAhorroTotal As Double
    Private FechaCierre As Date
    Private DescripcionEstado As String

    Public Shared ReadOnly ACTIVA As String = "Activa"
    Public Shared ReadOnly BLOQUEADA As String = "Bloqueada"
    Public Shared ReadOnly CERRADA As String = "Cerrada"


    Public Property pCajaAhorroId As Int32
        Get
            Return CajaAhorroId
        End Get
        Set(value As Int32)
            CajaAhorroId = value
        End Set
    End Property

    Public Property pNave As Entidades.Naves
        Get
            Return Nave
        End Get
        Set(value As Entidades.Naves)
            Nave = value
        End Set
    End Property

    Public Property pConcepto As String
        Get
            Return Concepto
        End Get
        Set(value As String)
            Concepto = value
        End Set
    End Property

    Public Property pFechaInicial As Date
        Get
            Return FechaInicial
        End Get
        Set(value As Date)
            FechaInicial = value
        End Set
    End Property


    Public Property pFechaFinal As Date
        Get
            Return FechaFinal
        End Get
        Set(value As Date)
            FechaFinal = value
        End Set
    End Property


    Public Property pEstado As Char
        Get
            Return estado
        End Get
        Set(value As Char)
            estado = value
        End Set
    End Property

    Public Property pMontoAhorro As Double
        Get
            Return MontoAhorro
        End Get
        Set(value As Double)
            MontoAhorro = value
        End Set
    End Property

    Public Property pMontoInteres As Double
        Get
            Return MontoInteres
        End Get
        Set(value As Double)
            MontoInteres = value
        End Set
    End Property

    Public Property pMontoAhorroTotal As Double
        Get
            Return MontoAhorroTotal
        End Get
        Set(value As Double)
            MontoAhorroTotal = value
        End Set
    End Property


    Public Property pFechaCierre As Date
        Get
            Return FechaCierre
        End Get
        Set(value As Date)
            FechaCierre = value
        End Set
    End Property


    Public Property pDescripcionEstado As String
        Get
            Return DescripcionEstado
        End Get
        Set(value As String)
            DescripcionEstado = value
        End Set
    End Property

    ''agregado nuevas fechas reporte deducciones
    Private fechaInicialDeducciones As Date
    Public Property pFechaInicialDeducciones() As Date
        Get
            Return fechaInicialDeducciones
        End Get
        Set(ByVal value As Date)
            fechaInicialDeducciones = value
        End Set
    End Property

    Private fechaFinalDeducciones As Date
    Public Property PFechaFinalDeducciones() As Date
        Get
            Return fechaFinalDeducciones
        End Get
        Set(ByVal value As Date)
            fechaFinalDeducciones = value
        End Set
    End Property


End Class
