Public Class TarjetaProduccion
    Private IdTarjetaSuela As String
    Private Prioridad As Integer
    Private Maquina As Integer
    Private UsuarioId As Integer

    Public Property PIdTarjetaSuela() As String
        Get
            Return IdTarjetaSuela
        End Get
        Set(ByVal value As String)
            IdTarjetaSuela = value
        End Set
    End Property

    Public Property PPrioridad() As Integer
        Get
            Return Prioridad
        End Get
        Set(ByVal value As Integer)
            Prioridad = value
        End Set
    End Property

    Public Property PMaquina() As Integer
        Get
            Return Maquina
        End Get
        Set(ByVal value As Integer)
            Maquina = value
        End Set
    End Property

    Public Property PUsuarioId() As Integer
        Get
            Return UsuarioId
        End Get
        Set(ByVal value As Integer)
            UsuarioId = value
        End Set
    End Property

End Class
