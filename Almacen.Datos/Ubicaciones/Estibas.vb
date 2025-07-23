Public Class Estibas
    Private pesti_estibaid As String
    Private pesti_bahiaid As String
    Private pesti_numeroestiba As Int32
    Private pesti_activo As Boolean
    Private pesti_usuariocreoid As Int32
    Private pesti_usuariomodificaid As Int32
    Private pesti_fechacreacion As Date
    Private pesti_fechamodificacion As Date

    Public Property esti_estibaid As String
        Get
            Return pesti_estibaid
        End Get
        Set(value As String)
            pesti_estibaid = value
        End Set
    End Property

    Public Property esti_bahiaid As String
        Get
            Return pesti_bahiaid
        End Get
        Set(value As String)
            pesti_bahiaid = value
        End Set
    End Property

    Public Property esti_numeroestiba As Int32
        Get
            Return pesti_numeroestiba
        End Get
        Set(value As Int32)
            pesti_numeroestiba = value
        End Set
    End Property
    Public Property esti_activo As Boolean
        Get
            Return pesti_activo
        End Get
        Set(value As Boolean)
            pesti_activo = value
        End Set
    End Property
    Public Property esti_usuariocreoid As Int32
        Get
            Return pesti_usuariocreoid
        End Get
        Set(value As Int32)
            pesti_usuariocreoid = value
        End Set
    End Property
    Public Property esti_usuariomodificaid As Int32
        Get
            Return pesti_usuariomodificaid
        End Get
        Set(value As Int32)
            pesti_usuariomodificaid = value
        End Set
    End Property
    Public Property esti_fechacreacion As Date
        Get
            Return pesti_fechacreacion
        End Get
        Set(value As Date)
            pesti_fechacreacion = value
        End Set
    End Property
    Public Property esti_fechamodificacion As Date
        Get
            Return pesti_fechamodificacion
        End Get
        Set(value As Date)
            pesti_fechamodificacion = value
        End Set
    End Property

End Class
