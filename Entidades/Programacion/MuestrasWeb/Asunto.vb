Public Class Asunto

    'asmu_asuntoid
    ', asmu_descripcion
    ', asmu_activo
    ', asmu_usuariocreoid
    ', asmu_usuariomodificoid
    ', asmu_fechacreacion
    ', asmu_fechamodificacion

    Private _asmu_asuntoid As Int32
    Private _asmu_descripcion As String
    Private _asmu_activo As Boolean
    Private _asmu_usuariocreoid As Int32
    Private _asmu_usuariomodificoid As Int32
    Private _asmu_fechacreacion As DateTime?
    Private _asmu_fechamodificacion As DateTime?


    Public Property asmu_asuntoid As Integer
        Get
            Return _asmu_asuntoid
        End Get
        Set(value As Integer)
            _asmu_asuntoid = value
        End Set
    End Property

    Public Property asmu_descripcion As String
        Get
            Return _asmu_descripcion
        End Get
        Set(value As String)
            _asmu_descripcion = value
        End Set
    End Property

    Public Property asmu_activo As Boolean
        Get
            Return _asmu_activo
        End Get
        Set(value As Boolean)
            _asmu_activo = value
        End Set
    End Property

    Public Property asmu_usuariocreoid As Integer
        Get
            Return _asmu_usuariocreoid
        End Get
        Set(value As Integer)
            _asmu_usuariocreoid = value
        End Set
    End Property

    Public Property asmu_usuariomodificoid As Integer
        Get
            Return _asmu_usuariomodificoid
        End Get
        Set(value As Integer)
            _asmu_usuariomodificoid = value
        End Set
    End Property

    Public Property asmu_fechacreacion As Date?
        Get
            Return _asmu_fechacreacion
        End Get
        Set(value As Date?)
            _asmu_fechacreacion = value
        End Set
    End Property

    Public Property asmu_fechamodificacion As Date?
        Get
            Return _asmu_fechamodificacion
        End Get
        Set(value As Date?)
            _asmu_fechamodificacion = value
        End Set
    End Property
End Class
