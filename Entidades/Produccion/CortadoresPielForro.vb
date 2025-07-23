Public Class CortadoresPielForro

    Private cortadorPielForro As Integer
    Public Property copf_cortadorPielForro() As Integer
        Get
            Return cortadorPielForro
        End Get
        Set(ByVal value As Integer)
            cortadorPielForro = value
        End Set
    End Property

    Private colaboradorid As Integer
    Public Property copf_colaboradorid() As Integer
        Get
            Return colaboradorid
        End Get
        Set(ByVal value As Integer)
            colaboradorid = value
        End Set
    End Property

    Private naveid As Integer
    Public Property copf_naveid() As Integer
        Get
            Return naveid
        End Get
        Set(ByVal value As Integer)
            naveid = value
        End Set
    End Property

    Private tipocortador As Integer
    Public Property copf_tipocortador() As Integer
        Get
            Return tipocortador
        End Get
        Set(ByVal value As Integer)
            tipocortador = value
        End Set
    End Property

    Private estatus As Integer
    Public Property copf_estatus() As Integer
        Get
            Return estatus
        End Get
        Set(ByVal value As Integer)
            estatus = value
        End Set
    End Property

    Private usuariocreo As Integer
    Public Property copf_usuariocreo() As Integer
        Get
            Return usuariocreo
        End Get
        Set(ByVal value As Integer)
            usuariocreo = value
        End Set
    End Property

    Private usuariomodifico As Integer
    Public Property copf_usuariomodifico() As Integer
        Get
            Return usuariomodifico
        End Get
        Set(ByVal value As Integer)
            usuariomodifico = value
        End Set
    End Property



End Class
