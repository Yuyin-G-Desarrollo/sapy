Public Class Mensajeria
    Private Consecutivo As Int32
    Private NombreProveedor As String
    Private NombrePoblacion As String
    Private NombreCiudad As String
    Private AbrevEstado As String
    Private AbrevPais As String
    Private NombreUnidad As String
    Private CostoUnidad As Double
    Private Reembarque As String
    Private DiasMinEntregas As Int32
    Private DiasMaxEntregas As Int32
    Private NombreCiudadPoblacion As String
    Private FechaAlta As DateTime
    Private IDCostoMensajeria As Int32
    Private Activo As Boolean
    Private FechaInicioVigencia As DateTime
    Private FechaFinVigencia As DateTime
    Private Usuario As String

    Private IdProveedor As Integer
    Private IdPais As Integer
    Private IdEstado As Integer
    Private IdCiudad As Integer
    Private IdPoblacion As Integer
    Private IdDestinoMensajeria As Integer

    Public Property PIdDestinoMensajeria As Integer
        Get
            Return IdDestinoMensajeria
        End Get
        Set(value As Integer)
            IdDestinoMensajeria = value
        End Set
    End Property


    Public Property PIdProveedor As Integer
        Get
            Return IdProveedor
        End Get
        Set(value As Integer)
            IdProveedor = value
        End Set
    End Property

    Public Property PIdPais As Integer
        Get
            Return IdPais
        End Get
        Set(value As Integer)
            IdPais = value
        End Set
    End Property

    Public Property PIdEstado As Integer
        Get
            Return IdEstado
        End Get
        Set(value As Integer)
            IdEstado = value
        End Set
    End Property

    Public Property PIdCiudad As Integer
        Get
            Return IdCiudad
        End Get
        Set(value As Integer)
            IdCiudad = value
        End Set
    End Property

    Public Property PIdPoblacion As Integer
        Get
            Return IdPoblacion
        End Get
        Set(value As Integer)
            IdPoblacion = value
        End Set
    End Property


    Public Property PFechaFinVigencia As DateTime
        Get
            Return FechaFinVigencia
        End Get
        Set(value As DateTime)
            FechaFinVigencia = value
        End Set
    End Property


    Public Property PFechaInicioVigencia As DateTime
        Get
            Return FechaInicioVigencia
        End Get
        Set(value As DateTime)
            FechaInicioVigencia = value
        End Set
    End Property



    Public Property PConsecutivo As Int32
        Get
            Return Consecutivo
        End Get
        Set(value As Int32)
            Consecutivo = value
        End Set
    End Property

    Public Property PNombreProveedor As String
        Get
            Return NombreProveedor
        End Get
        Set(value As String)
            NombreProveedor = value
        End Set
    End Property

    Public Property PNombrePoblacion As String
        Get
            Return NombrePoblacion
        End Get
        Set(value As String)
            NombrePoblacion = value
        End Set
    End Property
    Public Property PNombreCiudad As String
        Get
            Return NombreCiudad
        End Get
        Set(value As String)
            NombreCiudad = value
        End Set
    End Property
    Public Property PAbrevEstado As String
        Get
            Return AbrevEstado
        End Get
        Set(value As String)
            AbrevEstado = value
        End Set
    End Property
    Public Property PAbrevPais As String
        Get
            Return AbrevPais
        End Get
        Set(value As String)
            AbrevPais = value
        End Set
    End Property
    Public Property PNombreUnidad As String
        Get
            Return NombreUnidad
        End Get
        Set(value As String)
            NombreUnidad = value
        End Set
    End Property

    Public Property PCostoUnidad As Double
        Get
            Return CostoUnidad
        End Get
        Set(value As Double)
            CostoUnidad = value
        End Set
    End Property
    Public Property PReembarque As String
        Get
            Return Reembarque
        End Get
        Set(value As String)
            Reembarque = value
        End Set
    End Property
    Public Property PNombreCiudadPoblacion As String
        Get
            Return NombreCiudadPoblacion
        End Get
        Set(value As String)
            NombreCiudadPoblacion = value
        End Set
    End Property

    Public Property PDiasMinEntregas As Int32
        Get
            Return DiasMinEntregas
        End Get
        Set(value As Int32)
            DiasMinEntregas = value
        End Set
    End Property

    Public Property PDiasMaxEntregas As Int32
        Get
            Return DiasMaxEntregas
        End Get
        Set(value As Int32)
            DiasMaxEntregas = value
        End Set
    End Property

    Public Property PFechaAlta As DateTime
        Get
            Return FechaAlta
        End Get
        Set(value As DateTime)
            FechaAlta = value
        End Set
    End Property

    Public Property PIDCostoMensajeria As Int32
        Get
            Return IDCostoMensajeria
        End Get
        Set(value As Int32)
            IDCostoMensajeria = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property PUsuario As String
        Get
            Return Usuario
        End Get
        Set(value As String)
            Usuario = value
        End Set
    End Property


End Class
