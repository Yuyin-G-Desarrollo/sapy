Public Class TelefonoVisitante
    Private telefonoId As Integer
    Public Property TVTelefonoId() As Integer
        Get
            Return telefonoId
        End Get
        Set(ByVal value As Integer)
            telefonoId = value
        End Set
    End Property

    Private visitanteId As Integer
    Public Property TVVisitanteId() As Integer
        Get
            Return visitanteId
        End Get
        Set(ByVal value As Integer)
            visitanteId = value
        End Set
    End Property

    Private telefono As String
    Public Property TVTelefono() As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
        End Set
    End Property

    Private activo As Boolean
    Public Property TVActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property TVUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private usuarioModificoId As Integer
    Public Property TVUsuarioModificoId() As Integer
        Get
            Return usuarioModificoId
        End Get
        Set(ByVal value As Integer)
            usuarioModificoId = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property TVFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property TVFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property
End Class
