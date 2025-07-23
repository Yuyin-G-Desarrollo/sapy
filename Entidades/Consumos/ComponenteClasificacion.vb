Public Class ComponenteClasificacion

    Private idComponenteClasificacion As Integer
    Public Property cocl_idcomponenteclasificacion() As Integer
        Get
            Return idComponenteClasificacion
        End Get
        Set(ByVal value As Integer)
            idComponenteClasificacion = value
        End Set
    End Property

    Private idcomponente As Integer
    Public Property cocl_idcomponente() As Integer
        Get
            Return idcomponente
        End Get
        Set(ByVal value As Integer)
            idcomponente = value
        End Set
    End Property

    Private idclasificacion As Integer
    Public Property cocl_idclasificacion() As Integer
        Get
            Return idclasificacion
        End Get
        Set(ByVal value As Integer)
            idclasificacion = value
        End Set
    End Property

    Private usuariocreo As Integer
    Public Property cocl_usuariocreo() As Integer
        Get
            Return usuariocreo
        End Get
        Set(ByVal value As Integer)
            usuariocreo = value
        End Set
    End Property

    Private usuariomodifico As Integer
    Public Property cocl_usuariomodifico() As Integer
        Get
            Return usuariomodifico
        End Get
        Set(ByVal value As Integer)
            usuariomodifico = value
        End Set
    End Property

    Private activo As Integer
    Public Property cocl_activo() As Integer
        Get
            Return activo
        End Get
        Set(ByVal value As Integer)
            activo = value
        End Set
    End Property


End Class
