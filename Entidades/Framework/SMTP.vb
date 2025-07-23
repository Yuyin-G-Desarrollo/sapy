Public Class SMTP
    Private smtpId As Integer
    Private user As String
    Private contrasena As String
    Private servidor As String
    Private puerto As String
    Private ssl As Boolean

    Public Property Psmtpid As Integer
        Get
            Return smtpId
        End Get
        Set(ByVal value As Integer)
            smtpId = value
        End Set
    End Property

    Public Property PUser As String
        Get
            Return user
        End Get
        Set(ByVal value As String)
            user = value
        End Set
    End Property

    Public Property PContrasena As String
        Get
            Return contrasena
        End Get
        Set(ByVal value As String)
            contrasena = value
        End Set
    End Property

    Public Property PServidor As String
        Get
            Return servidor
        End Get
        Set(ByVal value As String)
            servidor = value
        End Set
    End Property

    Public Property PPuerto As String
        Get
            Return puerto
        End Get
        Set(ByVal value As String)
            puerto = value
        End Set
    End Property

    Public Property PSsl As Boolean
        Get
            Return ssl
        End Get
        Set(ByVal value As Boolean)
            ssl = value
        End Set
    End Property
End Class
