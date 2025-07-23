
Public Class DatosCorreo

    Private PDestinatarios As String
    Public Property Destinatarios As String
        Get
            Return PDestinatarios
        End Get
        Set(value As String)
            PDestinatarios = value
        End Set
    End Property

    Private PCorreoEnviado As Boolean
    Public Property CorreoEnviado As Boolean
        Get
            Return PCorreoEnviado
        End Get
        Set(value As Boolean)
            PCorreoEnviado = value
        End Set
    End Property

    Private PFrom As String
    Public Property From As String
        Get
            Return PFrom
        End Get
        Set(value As String)
            PFrom = value
        End Set
    End Property

    Private PAsunto As String
    Public Property Asunto As String
        Get
            Return PAsunto
        End Get
        Set(value As String)
            PAsunto = value
        End Set
    End Property

    Private PMensaje As String
    Public Property Mensaje As String
        Get
            Return PMensaje
        End Get
        Set(value As String)
            PMensaje = value
        End Set
    End Property

    Private PDescripcionStatusCorreo As String
    Public Property DescripcionStatusCorreo As String
        Get
            Return PDescripcionStatusCorreo
        End Get
        Set(value As String)
            PDescripcionStatusCorreo = value
        End Set
    End Property

End Class
