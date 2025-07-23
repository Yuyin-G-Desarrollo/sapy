Public Class ClasificacionColores

    Private idcolor As Integer
    Public Property clco_idcolor() As Integer
        Get
            Return idcolor
        End Get
        Set(ByVal value As Integer)
            idcolor = value
        End Set
    End Property

    Private clasificacioncoloresid As Integer
    Public Property clco_clasificacioncoloresid() As Integer
        Get
            Return clasificacioncoloresid
        End Get
        Set(ByVal value As Integer)
            clasificacioncoloresid = value
        End Set
    End Property

    Private idclasificacion As Integer
    Public Property clco_idclasificacion() As Integer
        Get
            Return idclasificacion
        End Get
        Set(ByVal value As Integer)
            idclasificacion = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property clco_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property clco_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property clco_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As String
    Public Property clco_fechamodificacion() As String
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As String)
            fechamodificacion = value
        End Set
    End Property

    Private estatus As Char
    Public Property clco_estatus() As Char
        Get
            Return estatus
        End Get
        Set(ByVal value As Char)
            estatus = value
        End Set
    End Property

End Class
