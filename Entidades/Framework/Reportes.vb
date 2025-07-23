Public Class Reportes

    Private reporteid As Int32
    Private esquema As String
    Private nombre As String
    Private xml As String
    Private activo As Boolean
    Private clavereporte As String
    Public Property Preporteid As Int32
        Get
            Return reporteid

        End Get
        Set(value As Int32)
            reporteid = value

        End Set
    End Property
    Public Property Pesquema As String
        Get
            Return esquema

        End Get
        Set(value As String)
            esquema = value
        End Set
    End Property

    Public Property Pnombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property Pxml As String
        Get
            Return xml
        End Get
        Set(value As String)
            xml = value
        End Set
    End Property


    Public Property Pactivo As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

    Public Property PClavereporte As String
        Get
            Return clavereporte
        End Get
        Set(value As String)
            clavereporte = value
        End Set
    End Property

    Property Pdirecto As Boolean

    Private Solicito As String
    Public Property PSolicito() As String
        Get
            Return Solicito
        End Get
        Set(ByVal value As String)
            Solicito = value
        End Set
    End Property

    Private fechaSolicitud As Date
    Public Property pFechaSolicito() As Date
        Get
            Return fechaSolicitud
        End Get
        Set(ByVal value As Date)
            fechaSolicitud = value
        End Set
    End Property



End Class
