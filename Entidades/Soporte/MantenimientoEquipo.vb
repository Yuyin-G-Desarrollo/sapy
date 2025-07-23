Public Class MantenimientoEquipo

    Private histmant_mantenimientoid As Integer

    Public Property HMmantenimientoId() As Integer
        Get
            Return histmant_mantenimientoid
        End Get
        Set(ByVal value As Integer)
            histmant_mantenimientoid = value
        End Set
    End Property


    Private histmant_equipoid As Integer

    Public Property HMEquipoId() As Integer
        Get
            Return histmant_equipoid
        End Get
        Set(ByVal value As Integer)
            histmant_equipoid = value
        End Set
    End Property


    Private histmant_descripcion As String

    Public Property HMDescripcion() As String
        Get
            Return histmant_descripcion
        End Get
        Set(ByVal value As String)
            histmant_descripcion = value
        End Set
    End Property


    Private histmant_fechamantenimiento As DateTime

    Public Property HMFechaMantenimiento() As DateTime
        Get
            Return histmant_fechamantenimiento
        End Get
        Set(ByVal value As DateTime)
            histmant_fechamantenimiento = value
        End Set
    End Property


    Private histmant_status As String

    Public Property HMStatus() As String
        Get
            Return histmant_status
        End Get
        Set(ByVal value As String)
            histmant_status = value
        End Set
    End Property


    Private softequi_usuariocrea As Integer

    Public Property SEUsuarioCrea() As Integer
        Get
            Return softequi_usuariocrea
        End Get
        Set(ByVal value As Integer)
            softequi_usuariocrea = value
        End Set
    End Property


    Private softequi_usuariomodifica As Integer

    Public Property SEUsuarioModifica() As Integer
        Get
            Return softequi_usuariomodifica
        End Get
        Set(ByVal value As Integer)
            softequi_usuariomodifica = value
        End Set
    End Property
End Class
