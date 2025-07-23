Public Class ClasificacionTamanovb

    Private idtamano As Integer
    Public Property clta_idtamano() As Integer
        Get
            Return idtamano
        End Get
        Set(ByVal value As Integer)
            idtamano = value
        End Set
    End Property

    Private clasificaciontamanoid As Integer
    Public Property clta_clasificaciontamanoid() As Integer
        Get
            Return clasificaciontamanoid
        End Get
        Set(ByVal value As Integer)
            clasificaciontamanoid = value
        End Set
    End Property

    Private idclasificacion As Integer
    Public Property clta_idclasificacion() As Integer
        Get
            Return idclasificacion
        End Get
        Set(ByVal value As Integer)
            idclasificacion = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property clta_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property clta_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property clta_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As String
    Public Property clta_fechamodificacion() As String
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As String)
            fechamodificacion = value
        End Set
    End Property

    Private estatus As Char
    Public Property clta_estatus() As Char
        Get
            Return estatus
        End Get
        Set(ByVal value As Char)
            estatus = value
        End Set
    End Property

End Class
