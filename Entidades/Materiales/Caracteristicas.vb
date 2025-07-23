Public Class Caracteristicas

    Private idcaracteristica As Integer
    Public Property cara_idcaracteristica() As Integer
        Get
            Return idcaracteristica
        End Get
        Set(ByVal value As Integer)
            idcaracteristica = value
        End Set
    End Property

    Private idmaterial As Integer
    Public Property cara_idmaterial() As Integer
        Get
            Return idmaterial
        End Get
        Set(ByVal value As Integer)
            idmaterial = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property cara_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property cara_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private descripcion As String
    Public Property cara_descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private activo As Char
    Public Property cara_activo() As Char
        Get
            Return activo
        End Get
        Set(ByVal value As Char)
            activo = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property cara_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property cara_fechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

End Class
