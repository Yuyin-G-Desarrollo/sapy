Public Class Maquinaria

    Private maqiunaid As Integer
    Public Property maq_maquinaid() As Integer
        Get
            Return maqiunaid
        End Get
        Set(ByVal value As Integer)
            maqiunaid = value
        End Set
    End Property

    Private descripcion As String
    Public Property maq_descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private departamentoid As Integer
    Public Property maq_departamentoid() As Integer
        Get
            Return departamentoid
        End Get
        Set(ByVal value As Integer)
            departamentoid = value
        End Set
    End Property

    Private naveid As Integer
    Public Property maq_naveid() As Integer
        Get
            Return naveid
        End Get
        Set(ByVal value As Integer)
            naveid = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property maq_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property maq_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property maq_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private activo As Integer
    Public Property maq_activo() As Integer
        Get
            Return activo
        End Get
        Set(ByVal value As Integer)
            activo = value
        End Set
    End Property


End Class
