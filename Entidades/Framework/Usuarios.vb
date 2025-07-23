Public Class Usuarios

    Private UserUsuarioid As Int32
    Private UserUsername As String
    Private UserMd5 As String
    Private UserEmail As String
    Private UserNombreReal As String
    Private UserUsuarioCreoId As Int32
    Private UserUsuarioModificoId As Int32
    Private UserFechaCreacion As Date
    Private UserFechaModificacion As Date
    Private UserActive As Boolean
    Private UsuarioSicy As String
    Private IDColaboradorUser As Int32

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property PIDColaboradorUser As Int32
        Get
            Return IDColaboradorUser
        End Get
        Set(ByVal value As Int32)
            IDColaboradorUser = value
        End Set
    End Property

    Public Property PUsuariosSicy As String
        Get
            Return UsuarioSicy
        End Get
        Set(ByVal value As String)
            UsuarioSicy = value
        End Set
    End Property

    Public Property PUserActive As Boolean
        Get
            Return UserActive
        End Get
        Set(ByVal value As Boolean)
            UserActive = value
        End Set
    End Property

    Public Property PUserUsuarioid() As Int32
        Get
            Return UserUsuarioid
        End Get
        Set(ByVal Value As Int32)
            UserUsuarioid = Value
        End Set
    End Property

    Public Property PUserUsername() As String
        Get
            Return UserUsername
        End Get
        Set(ByVal value As String)
            UserUsername = value
        End Set
    End Property

    Public Property PUserMd5() As String
        Get
            Return UserMd5
        End Get
        Set(ByVal value As String)
            UserMd5 = value
        End Set
    End Property

    Public Property PUserEmail() As String
        Get
            Return UserEmail
        End Get
        Set(ByVal value As String)
            UserEmail = value
        End Set
    End Property

    Public Property PUserUsuarioCreoId() As Int32
        Get
            Return UserUsuarioCreoId
        End Get
        Set(ByVal value As Int32)
            UserUsuarioCreoId = value
        End Set
    End Property

    Public Property PUserUsuarioModificoId() As Int32
        Get
            Return UserUsuarioModificoId
        End Get
        Set(ByVal value As Int32)

        End Set
    End Property

    Public Property PUserFechaCreacion() As Date
        Get
            Return UserFechaCreacion
        End Get
        Set(ByVal value As Date)
            UserFechaCreacion = value
        End Set
    End Property

    Public Property PUserFechaModificacion() As Date
        Get
            Return UserFechaModificacion
        End Get
        Set(ByVal value As Date)
            UserFechaModificacion = value
        End Set
    End Property

    Public Property PUserNombreReal() As String
        Get
            Return UserNombreReal
        End Get
        Set(ByVal value As String)
            UserNombreReal = value
        End Set
    End Property

End Class
