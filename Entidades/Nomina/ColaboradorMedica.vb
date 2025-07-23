Public Class ColaboradorMedica

    Private ColaboradorId As Colaborador
    Private TipoSanguineo As String
    Private TelefonoEmergencias As String
    Private ContactoEmergencias As String
    Private Comentarios As String

    Public Property PColaboradorID As Colaborador
        Get
            Return ColaboradorId
        End Get
        Set(ByVal value As Colaborador)
            ColaboradorId = value
        End Set
    End Property

    Public Property PTipoSanguineo As String
        Get
            Return TipoSanguineo
        End Get
        Set(ByVal value As String)
            TipoSanguineo = value
        End Set
    End Property

    Public Property PTelefonoEmergencias As String
        Get
            Return TelefonoEmergencias
        End Get
        Set(ByVal value As String)
            TelefonoEmergencias = value
        End Set
    End Property

    Public Property PContactoEmergencias As String
        Get
            Return ContactoEmergencias
        End Get
        Set(ByVal value As String)
            ContactoEmergencias = value
        End Set
    End Property

    Public Property PComentarios As String
        Get
            Return Comentarios
        End Get
        Set(ByVal value As String)
            Comentarios = value
        End Set
    End Property
End Class
