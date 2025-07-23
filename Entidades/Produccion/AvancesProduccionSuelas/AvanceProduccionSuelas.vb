Public Class AvanceProduccionSuelas
    Private tipoReporte As Integer
    Private fechaAvanceInicio As Date
    Private fechaAvanceFin As Date
    Private fechaProgramaInicio As Date
    Private fechaProgramaFin As Date
    Private tipoReporteFecha As String
    Private maquinasID As String
    Private suelasID As String
    Private navesID As String
    Private operadoresID As String
    Private folioTarjetas As String

    Public Property AP_TipoReporte As Integer
        Get
            Return tipoReporte
        End Get
        Set(value As Integer)
            tipoReporte = value
        End Set
    End Property

    Public Property AP_FechaAvanceInicio As Date
        Get
            Return fechaAvanceInicio
        End Get
        Set(value As Date)
            fechaAvanceInicio = value
        End Set
    End Property

    Public Property AP_FechaAvanceFin As Date
        Get
            Return fechaAvanceFin
        End Get
        Set(value As Date)
            fechaAvanceFin = value
        End Set
    End Property

    Public Property AP_FechaProgramaInicio As Date
        Get
            Return fechaProgramaInicio
        End Get
        Set(value As Date)
            fechaProgramaInicio = value
        End Set
    End Property

    Public Property AP_FechaProgramaFin As Date
        Get
            Return fechaProgramaFin
        End Get
        Set(value As Date)
            fechaProgramaFin = value
        End Set
    End Property

    Public Property AP_TipoReporteFecha As String
        Get
            Return tipoReporteFecha
        End Get
        Set(value As String)
            tipoReporteFecha = value
        End Set
    End Property

    Public Property AP_MaquinasID As String
        Get
            Return maquinasID
        End Get
        Set(value As String)
            maquinasID = value
        End Set
    End Property

    Public Property AP_SuelasID As String
        Get
            Return suelasID
        End Get
        Set(value As String)
            suelasID = value
        End Set
    End Property

    Public Property AP_NavesID As String
        Get
            Return navesID
        End Get
        Set(value As String)
            navesID = value
        End Set
    End Property

    Public Property AP_OperadoresID As String
        Get
            Return operadoresID
        End Get
        Set(value As String)
            operadoresID = value
        End Set
    End Property

    Public Property AP_FolioTarjetas As String
        Get
            Return folioTarjetas
        End Get
        Set(value As String)
            folioTarjetas = value
        End Set
    End Property
End Class
