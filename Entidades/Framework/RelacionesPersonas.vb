Public Class RelacionesPersonas

    Private repe_relacionespersonaid As Integer
    Private repe_personaid As Integer
    Private repe_clasificacionpersonaid1 As Integer
    Private repe_persona2 As Integer
    Private repe_clasificacionpersona2 As Integer
    Private repe_activo As Boolean
    Private repe_usuario As Integer
    Private repe_fecha As DateTime

    Public Property PrelacionPersonaId As Integer
        Get
            Return repe_relacionespersonaid
        End Get
        Set(value As Integer)
            repe_relacionespersonaid = value
        End Set
    End Property

    Public Property PPersonaId As Integer
        Get
            Return repe_personaid
        End Get
        Set(value As Integer)
            repe_personaid = value
        End Set
    End Property

    Public Property PCLasificacionPersona1 As Integer
        Get
            Return repe_clasificacionpersonaid1
        End Get
        Set(value As Integer)
            repe_clasificacionpersonaid1 = value
        End Set
    End Property

    Public Property PPersona2_Id As Integer
        Get
            Return repe_persona2
        End Get
        Set(value As Integer)
            repe_persona2 = value
        End Set
    End Property

    Public Property PClasificacionPersona2 As Integer
        Get
            Return repe_clasificacionpersona2
        End Get
        Set(value As Integer)
            repe_clasificacionpersona2 = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return repe_activo
        End Get
        Set(value As Boolean)
            repe_activo = value
        End Set
    End Property

    Public Property PUsuario As Integer
        Get
            Return repe_usuario
        End Get
        Set(value As Integer)
            repe_usuario = value
        End Set
    End Property


End Class
