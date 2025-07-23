Public Class CancelacionDocumento

    Private PDocumentoID As Integer
    Public Property DocumentoID() As Integer
        Get
            Return PDocumentoID
        End Get
        Set(ByVal value As Integer)
            PDocumentoID = value
        End Set
    End Property

    Private PUsuarioID As Integer
    Public Property UsuarioID() As Integer
        Get
            Return PUsuarioID
        End Get
        Set(ByVal value As Integer)
            PUsuarioID = value
        End Set
    End Property

    Private PSolicita As String
    Public Property Solicita() As String
        Get
            Return PSolicita
        End Get
        Set(ByVal value As String)
            PSolicita = value
        End Set
    End Property

    Private PMotivoID As Integer
    Public Property MotivoID() As Integer
        Get
            Return PMotivoID
        End Get
        Set(ByVal value As Integer)
            PMotivoID = value
        End Set
    End Property

    Private PObservaciones As String
    Public Property Observaciones() As String
        Get
            Return PObservaciones
        End Get
        Set(ByVal value As String)
            PObservaciones = value
        End Set
    End Property

    Private PSustitucionInmediata As Integer
    Public Property SustitucionInmediata() As Integer
        Get
            Return PSustitucionInmediata
        End Get
        Set(ByVal value As Integer)
            PSustitucionInmediata = value
        End Set
    End Property

    Private PRequiereAutorizacionCliente As Integer
    Public Property RequiereAutorizacionCliente() As Integer
        Get
            Return PRequiereAutorizacionCliente
        End Get
        Set(ByVal value As Integer)
            PRequiereAutorizacionCliente = value
        End Set
    End Property

    Private PNuevoRFCID As Integer
    Public Property NuevoRFCID() As Integer
        Get
            Return PNuevoRFCID
        End Get
        Set(ByVal value As Integer)
            PNuevoRFCID = value
        End Set
    End Property

    Private PUsoCFDIID As String
    Public Property UsoCFDIID() As String
        Get
            Return PUsoCFDIID
        End Get
        Set(ByVal value As String)
            PUsoCFDIID = value
        End Set
    End Property

    Private PProductoAlCancelar As String
    Public Property ProductoAlCancelar() As String
        Get
            Return PProductoAlCancelar
        End Get
        Set(ByVal value As String)
            PProductoAlCancelar = value
        End Set
    End Property


    Private PTipoComprobrante As String
    Public Property TipoComprobrante() As String
        Get
            Return PTipoComprobrante
        End Get
        Set(ByVal value As String)
            PTipoComprobrante = value
        End Set
    End Property


    Private PRemisionID As String
    Public Property RemisionID() As String
        Get
            Return PRemisionID
        End Get
        Set(ByVal value As String)
            PRemisionID = value
        End Set
    End Property

    Private PAño As String
    Public Property Año() As String
        Get
            Return PAño
        End Get
        Set(ByVal value As String)
            PAño = value
        End Set
    End Property

    Private PMotivoCatalogo As String
    Public Property MotivoCatalogo() As String
        Get
            Return PMotivoCatalogo
        End Get
        Set(ByVal value As String)
            PMotivoCatalogo = value
        End Set
    End Property

    Private PMotivoSICYID As Integer
    Public Property MotivoSICYID() As Integer
        Get
            Return PMotivoSICYID
        End Get
        Set(ByVal value As Integer)
            PMotivoSICYID = value
        End Set
    End Property

    Private PUserName As String
    Public Property UserName() As String
        Get
            Return PUserName
        End Get
        Set(ByVal value As String)
            PUserName = value
        End Set
    End Property

End Class
