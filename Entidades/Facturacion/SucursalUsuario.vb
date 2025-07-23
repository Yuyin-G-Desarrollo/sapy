Public Class SucursalUsuario
    Private sucursalusuarioid As Int32
    Private usuarioid As Int32
    Private sucursaldid As Int32
    Private fechacreacion As Date
    Private usuariocreoid As Int32


    Public Property SUId() As Int32
        Get
            Return sucursalusuarioid
        End Get
        Set(ByVal value As Int32)
            sucursalusuarioid = value
        End Set
    End Property

    Public Property SUUsuarioid() As Int32
        Get
            Return usuarioid
        End Get
        Set(ByVal value As Int32)
            usuarioid = value
        End Set
    End Property

    Public Property SUSucursaldid() As Int32
        Get
            Return sucursaldid
        End Get
        Set(ByVal value As Int32)
            sucursaldid = value
        End Set
    End Property

    Public Property SUFechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Public Property SUUsuariocreoid() As Int32
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Int32)
            usuariocreoid = value
        End Set
    End Property
End Class
