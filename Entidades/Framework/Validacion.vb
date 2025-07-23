Public Class Validacion

    Private Pvalidacionid As Integer
    Public Property validacionid() As Integer
        Get
            Return Pvalidacionid
        End Get
        Set(ByVal value As Integer)
            Pvalidacionid = value
        End Set
    End Property

    Private Pvalidaciontipo As ValidacionTipo
    Public Property validaciontipo() As ValidacionTipo
        Get
            Return Pvalidaciontipo
        End Get
        Set(ByVal value As ValidacionTipo)
            Pvalidaciontipo = value
        End Set
    End Property

    Private Pcolaborador As Colaborador
    Public Property colaborador() As Colaborador
        Get
            Return Pcolaborador
        End Get
        Set(ByVal value As Colaborador)
            Pcolaborador = value
        End Set
    End Property

    Private Pregistro As Cliente
    Public Property registro() As Cliente
        Get
            Return Pregistro
        End Get
        Set(ByVal value As Cliente)
            Pregistro = value
        End Set
    End Property

    Private Pfechavalidacion As DateTime
    Public Property fechavalidacion() As DateTime
        Get
            Return Pfechavalidacion
        End Get
        Set(ByVal value As DateTime)
            Pfechavalidacion = value
        End Set
    End Property

    Private Pvalidacionestatus As Integer
    Public Property validacionestatus() As Integer
        Get
            Return Pvalidacionestatus
        End Get
        Set(ByVal value As Integer)
            Pvalidacionestatus = value
        End Set
    End Property

    Private Pcomentario As String
    Public Property comentario() As String
        Get
            Return Pcomentario
        End Get
        Set(ByVal value As String)
            Pcomentario = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

End Class
