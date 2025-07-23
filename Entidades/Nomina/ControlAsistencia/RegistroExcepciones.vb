Public Class RegistroExcepciones

    Private regexc_id As Integer
    Private regexc_fecha_inicio As Date
    Private regexc_fecha_termino As Date
    Private regexc_hora_inicio As DateTime
    Private regexc_hora_termino As DateTime
    Private regexc_usuario_sol As Usuarios
    Private regexc_usuario_rev As Usuarios
    Private regexc_solicitud_fecha As Date
    Private regexc_revision_fecha As Date
    Private regexc_motivo_nota As String
    Private regexc_puntualidad_asistencia As Boolean
    Private regexc_caja_ahorro As Boolean
    Private regexc_tipo_excepcion As Integer
    Private regexc_motivo As ExcepcionMotivo
    Private regexc_estado_excepcion As Integer
    Private regexc_colaborador As Colaborador
    Private regexc_departamento As Departamentos

    Public Property Pregexc_id() As Integer
        Get
            Return regexc_id
        End Get
        Set(ByVal value As Integer)
            regexc_id = value
        End Set
    End Property

    Public Property Pregexc_fecha_inicio() As Date
        Get
            Return regexc_fecha_inicio
        End Get
        Set(ByVal value As Date)
            regexc_fecha_inicio = value
        End Set
    End Property

    Public Property Pregexc_fecha_termino() As Date
        Get
            Return regexc_fecha_termino
        End Get
        Set(ByVal value As Date)
            regexc_fecha_termino = value
        End Set
    End Property

    Public Property Pregexc_hora_inicio() As DateTime
        Get
            Return regexc_hora_inicio
        End Get
        Set(ByVal value As DateTime)
            regexc_hora_inicio = value
        End Set
    End Property

    Public Property Pregexc_hora_termino() As DateTime
        Get
            Return regexc_hora_termino
        End Get
        Set(ByVal value As DateTime)
            regexc_hora_termino = value
        End Set
    End Property

    Public Property Pregexc_usuario_sol() As Usuarios
        Get
            Return regexc_usuario_sol
        End Get
        Set(ByVal value As Usuarios)
            regexc_usuario_sol = value
        End Set
    End Property

    Public Property Pregexc_usuario_rev() As Usuarios
        Get
            Return regexc_usuario_rev
        End Get
        Set(ByVal value As Usuarios)
            regexc_usuario_rev = value
        End Set
    End Property

    Public Property Pregexc_solicitud_fecha() As Date
        Get
            Return regexc_solicitud_fecha
        End Get
        Set(ByVal value As Date)
            regexc_solicitud_fecha = value
        End Set
    End Property

    Public Property Pregexc_revision_fecha() As Date
        Get
            Return regexc_revision_fecha
        End Get
        Set(ByVal value As Date)
            regexc_revision_fecha = value
        End Set
    End Property

    Public Property Pregexc_motivo_nota() As String
        Get
            Return regexc_motivo_nota
        End Get
        Set(ByVal value As String)
            regexc_motivo_nota = value
        End Set
    End Property

    Public Property Pregexc_puntualidad_asistencia() As Boolean
        Get
            Return regexc_puntualidad_asistencia
        End Get
        Set(ByVal value As Boolean)
            regexc_puntualidad_asistencia = value
        End Set
    End Property

    Public Property Pregexc_caja_ahorro() As Boolean
        Get
            Return regexc_caja_ahorro
        End Get
        Set(ByVal value As Boolean)
            regexc_caja_ahorro = value
        End Set
    End Property

    Public Property Pregexc_tipo_excepcion() As Integer
        Get
            Return regexc_tipo_excepcion
        End Get
        Set(ByVal value As Integer)
            regexc_tipo_excepcion = value
        End Set
    End Property

    Public Property Pregexc_motivo() As ExcepcionMotivo
        Get
            Return regexc_motivo
        End Get
        Set(ByVal value As ExcepcionMotivo)
            regexc_motivo = value
        End Set
    End Property

    Public Property Pregexc_estado_excepcion() As Integer
        Get
            Return regexc_estado_excepcion
        End Get
        Set(ByVal value As Integer)
            regexc_estado_excepcion = value
        End Set
    End Property

    Public Property Pregexc_colaborador() As Colaborador
        Get
            Return regexc_colaborador
        End Get
        Set(ByVal value As Colaborador)
            regexc_colaborador = value
        End Set
    End Property

    Public Property Pregexc_departamento() As Departamentos
        Get
            Return regexc_departamento
        End Get
        Set(ByVal value As Departamentos)
            regexc_departamento = value
        End Set
    End Property

End Class
