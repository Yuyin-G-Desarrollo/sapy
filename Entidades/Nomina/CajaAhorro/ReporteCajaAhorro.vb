Public Class ReporteCajaAhorro
    Private IdCajaAhorro As Int32
    Private IdColaborador As Int32
    Private Nombre As String
    Private MontoAhorro As Double
    Private SemanasAhorradas As Int32
    Private Periodos As Int32
    Private Ganadas As Int32
    Private Perdidas As Int32
    Private Ahorrado As Double
    Private Interes As Int16
    Private TotalInteres As Double
    Private AhorroMasInteres As Double
    Private Estatus As String

    Private Prestamos As SolicitudPrestamo
    Private PrestamosPago As PagosPrestamo
    Private PrestamosPeriodoNomina As PeriodosNomina

    Private TotalEntregar As Double

    Private MontoAcumuladoCajaAnual As Double
    Private MontoAcumuladoInteresCajaAnual As Double
    Private MontoAcumuladoCajaMASInteres As Double
    Private UsuarioModifico As Int32

    Private Prestamo As Boolean

    Public Property PPrestamo As Boolean
        Get
            Return Prestamo
        End Get
        Set(value As Boolean)
            Prestamo = value
        End Set
    End Property

    Public Property PPrestamosPeriodoNomina As PeriodosNomina
        Get
            Return PrestamosPeriodoNomina
        End Get
        Set(value As PeriodosNomina)
            PrestamosPeriodoNomina = value
        End Set
    End Property

    Public Property PSemanasAhorradas As Int32
        Get
            Return SemanasAhorradas
        End Get
        Set(value As Int32)
            SemanasAhorradas = value
        End Set
    End Property

    Public Property PPrestamos As SolicitudPrestamo
        Get
            Return Prestamos
        End Get
        Set(value As SolicitudPrestamo)
            Prestamos = value
        End Set
    End Property

    Public Property PPrestamosPago As PagosPrestamo
        Get
            Return PrestamosPago
        End Get
        Set(value As PagosPrestamo)
            PrestamosPago = value
        End Set
    End Property


    Public Property PTotalEntregar As Double
        Get
            Return TotalEntregar
        End Get
        Set(value As Double)
            TotalEntregar = value
        End Set
    End Property

    Public Property PMontoAcumuladoCajaAnual As Double
        Get
            Return MontoAcumuladoCajaAnual
        End Get
        Set(value As Double)
            MontoAcumuladoCajaAnual = value
        End Set
    End Property

    Public Property PMontoAcumuladoInteresCajaAnual As Double
        Get
            Return MontoAcumuladoInteresCajaAnual
        End Get
        Set(value As Double)
            MontoAcumuladoInteresCajaAnual = value
        End Set
    End Property

    Public Property PMontoAcumuladoCajaMASInteres As Double
        Get
            Return MontoAcumuladoCajaMASInteres
        End Get
        Set(value As Double)
            MontoAcumuladoCajaMASInteres = value
        End Set
    End Property

    Public Property PUsuarioModifico As Int32
        Get
            Return UsuarioModifico
        End Get
        Set(value As Int32)
            UsuarioModifico = value
        End Set
    End Property
    ''----------------------------------  
    ''----------------------------------
    ''----------------------------------
Public Property pIdCajaAhorro As Int32
    Get
        Return IdCajaAhorro
    End Get
    Set(value As Int32)
        IdCajaAhorro = value
    End Set
End Property


Public Property pIdColaborador As Int32
    Get
        Return IdColaborador
    End Get
    Set(value As Int32)
        IdColaborador = value
    End Set
End Property



Public Property pNombre As String
    Get
        Return Nombre
    End Get
    Set(value As String)
        Nombre = value
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

Public Property pPeriodos As Int32
    Get
        Return Periodos
    End Get
    Set(value As Int32)
        Periodos = value
    End Set
End Property

Public Property pGanadas As Int32
    Get
        Return Ganadas
    End Get
    Set(value As Int32)
        Ganadas = value
    End Set
End Property

Public Property pPerdidas As Int32
    Get
        Return Perdidas
    End Get
    Set(value As Int32)
        Perdidas = value
    End Set
End Property


Public Property pAhorrado As Double
    Get
        Return Ahorrado
    End Get
    Set(value As Double)
        Ahorrado = value
    End Set
End Property

Public Property pInteres As Int16
    Get
        Return Interes
    End Get
    Set(value As Int16)
        Interes = value
    End Set
End Property


Public Property pTotalInteres As Double
    Get
        Return TotalInteres
    End Get
    Set(value As Double)
        TotalInteres = value
    End Set
End Property

Public Property pAhorroMasInteres As Double
    Get
        Return AhorroMasInteres
    End Get
    Set(value As Double)
        AhorroMasInteres = value
    End Set
End Property



Public Property pEstatus As String
    Get
        Return Estatus
    End Get
    Set(value As String)
        Estatus = value
    End Set
End Property




End Class
