Public Class ValidacionCliente

    Private Pvalidacionid As Integer
    Public Property validacionid() As Integer
        Get
            Return Pvalidacionid
        End Get
        Set(ByVal value As Integer)
            Pvalidacionid = value
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

    Private Pfechavalidacion As DateTime
    Public Property fechavalidacion() As DateTime
        Get
            Return Pfechavalidacion
        End Get
        Set(ByVal value As DateTime)
            Pfechavalidacion = value
        End Set
    End Property

    Private Pcomentarios As String
    Public Property comentarios() As String
        Get
            Return Pcomentarios
        End Get
        Set(ByVal value As String)
            Pcomentarios = value
        End Set
    End Property

    Private Ptipovalidacion As TipoValidacion
    Public Property tipovalidacion() As TipoValidacion
        Get
            Return Ptipovalidacion
        End Get
        Set(ByVal value As TipoValidacion)
            Ptipovalidacion = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
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
