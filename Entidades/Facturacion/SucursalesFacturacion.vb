Public Class SucursalesFacturacion
    Private sucursalid As Int32
    Private nombre As String
    Private calle As String
    Private numero As String
    Private colonia As String
    Private cp As String
    Private ciudadid As Int32
    Private logo As String
    Private usuario As Int32
    Private fecha As Date
    Private facturaproductos As Boolean
    Private activo As Boolean
    Private estadoid As Int32


    Public Property SID() As Int32
        Get
            Return sucursalid
        End Get
        Set(ByVal value As Int32)
            sucursalid = value
        End Set
    End Property

    Public Property SNombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property SCalle() As String
        Get
            Return calle
        End Get
        Set(value As String)
            calle = value
        End Set
    End Property

    Public Property SNumero() As String
        Get
            Return numero
        End Get
        Set(value As String)
            numero = value
        End Set
    End Property

    Public Property SColonia() As String
        Get
            Return colonia
        End Get
        Set(value As String)
            colonia = value
        End Set
    End Property

    Public Property SCp() As String
        Get
            Return cp
        End Get
        Set(value As String)
            cp = value
        End Set
    End Property

    Public Property SCiudadid() As Int32
        Get
            Return ciudadid
        End Get
        Set(ByVal value As Int32)
            ciudadid = value
        End Set
    End Property

    Public Property SLogo() As String
        Get
            Return logo
        End Get
        Set(value As String)
            logo = value
        End Set
    End Property

    Public Property SUsuario() As Int32
        Get
            Return usuario
        End Get
        Set(ByVal value As Int32)
            usuario = value
        End Set
    End Property

    Public Property SFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Public Property SFacturaproductos() As Boolean
        Get
            Return facturaproductos
        End Get
        Set(value As Boolean)
            facturaproductos = value
        End Set
    End Property

    Public Property SActivo() As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

    Public Property SEstadoid() As Int32
        Get
            Return estadoid
        End Get
        Set(ByVal value As Int32)
            estadoid = value
        End Set
    End Property

    Private remisiona As Boolean
    Public Property SRemisiona() As Boolean
        Get
            Return remisiona
        End Get
        Set(ByVal value As Boolean)
            remisiona = value
        End Set
    End Property

    Private reporteRemision As Integer
    Public Property SReporteRemision() As Integer
        Get
            Return reporteRemision
        End Get
        Set(ByVal value As Integer)
            reporteRemision = value
        End Set
    End Property

End Class
