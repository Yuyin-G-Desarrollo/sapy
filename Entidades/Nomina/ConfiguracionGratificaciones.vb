Public Class ConfiguracionGratificaciones
    Private conNaveId As Int32
  

    Private NaveNombre As Entidades.Naves
    Private AutorizaGerente As Boolean
    Private AutorizaDirector As Boolean
    Private ConfiguracionID As Int32
    Private UltimaModificacion As Date
    Private UsuarioModifico As String
    Private ApareceReportes As Boolean

    Public Property PApareceEnReportes As Boolean
        Get
            Return ApareceReportes
        End Get
        Set(ByVal value As Boolean)
            ApareceReportes = value
        End Set
    End Property

    Public Property PUltimaModificacion As Date
        Get
            Return UltimaModificacion
        End Get
        Set(ByVal value As Date)
            UltimaModificacion = value
        End Set
    End Property

    Public Property PUsuarioModifico As String
        Get
            Return UsuarioModifico
        End Get
        Set(ByVal value As String)
            UsuarioModifico = value
        End Set
    End Property

    Public Property PIDconfiguracion As Int32
        Get
            Return ConfiguracionID
        End Get
        Set(ByVal value As Int32)
            ConfiguracionID = value
        End Set
    End Property

    Public Property PAutorizaGerente As Boolean
        Get
            Return AutorizaGerente
        End Get
        Set(ByVal value As Boolean)
            AutorizaGerente = value
        End Set
    End Property

    Public Property PAutorizaDirector As Boolean
        Get
            Return AutorizaDirector
        End Get
        Set(ByVal value As Boolean)
            AutorizaDirector = value
        End Set
    End Property

    Public Property PNaveNombre As Naves
        Get
            Return NaveNombre
        End Get
        Set(ByVal value As Naves)
            NaveNombre = value
        End Set
    End Property

    Public Property PconNaveId As Int32
        Get
            Return conNaveId
        End Get
        Set(ByVal value As Int32)
            conNaveId = value
        End Set
    End Property

    
End Class
