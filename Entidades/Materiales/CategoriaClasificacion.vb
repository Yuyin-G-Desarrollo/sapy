Public Class CategoriaClasificacion

    Private idcategoria As Integer
    Public Property calc_idcategoria() As Integer
        Get
            Return idcategoria
        End Get
        Set(ByVal value As Integer)
            idcategoria = value
        End Set
    End Property

    Private idclasificacion As Integer
    Public Property calc_idclasificacion() As Integer
        Get
            Return idclasificacion
        End Get
        Set(ByVal value As Integer)
            idclasificacion = value
        End Set
    End Property

    Private id As Integer
    Public Property cacl_categoriaclasificacionid() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property calc_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property calc_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As String
    Public Property calc_fechacreacion() As String
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As String)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property calc_fechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

    Private estatus As Char
    Public Property calc_estatus() As Char
        Get
            Return estatus
        End Get
        Set(ByVal value As Char)
            estatus = value
        End Set
    End Property

    Private directo As Char
    Public Property calc_directo() As Char
        Get
            Return directo
        End Get
        Set(ByVal value As Char)
            directo = value
        End Set
    End Property

    Private ultimaclasificacion As Integer
    Public Property calc_ultimaclasificacion() As Integer
        Get
            Return ultimaclasificacion
        End Get
        Set(ByVal value As Integer)
            ultimaclasificacion = value
        End Set
    End Property

End Class
