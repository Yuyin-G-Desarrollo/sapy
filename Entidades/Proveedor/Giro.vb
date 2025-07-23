Public Class Giro

    Private activo As String
    Public Property girp_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property


    Private descripcion As String
    Public Property girp_descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property girp_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property girp_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As DateTime
    Public Property girp_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As DateTime
    Public Property girp_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

   

End Class
