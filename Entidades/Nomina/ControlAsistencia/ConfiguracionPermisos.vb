Public Class ConfiguracionPermisos

    Private ConfiguracionPermisos_id As Int32
    Private ConfiguracionPermisos_nombre As String
    Private ConfiguracionPermisos_puntualidad_asistencia As Byte
    Private ConfiguracionPermisos_caja_ahorro As Byte
    Private ConfiguracionPermisos_naveid As Int32
    Private ConfiguracionPermisos_usuariocreo As Int32
    Private ConfiguracionPermisos_usuariomodifico As Int32


    Public Property PConfiguracionPermisos_id As Int32
        Get
            Return ConfiguracionPermisos_id
        End Get
        Set(ByVal value As Int32)
            ConfiguracionPermisos_id = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_nombre As String
        Get
            Return ConfiguracionPermisos_nombre
        End Get
        Set(ByVal value As String)
            ConfiguracionPermisos_nombre = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_puntualidad_asistencia As Byte
        Get
            Return ConfiguracionPermisos_puntualidad_asistencia
        End Get
        Set(ByVal value As Byte)
            ConfiguracionPermisos_puntualidad_asistencia = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_caja_ahorro As Byte
        Get
            Return ConfiguracionPermisos_caja_ahorro
        End Get
        Set(ByVal value As Byte)
            ConfiguracionPermisos_caja_ahorro = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_naveid As Int32
        Get
            Return ConfiguracionPermisos_naveid
        End Get
        Set(ByVal value As Int32)
            ConfiguracionPermisos_naveid = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_usuariocreo As Int32
        Get
            Return ConfiguracionPermisos_usuariocreo
        End Get
        Set(ByVal value As Int32)
            ConfiguracionPermisos_usuariocreo = value
        End Set
    End Property

    Public Property PConfiguracionPermisos_usuariomodifico As Int32
        Get
            Return ConfiguracionPermisos_usuariomodifico
        End Get
        Set(ByVal value As Int32)
            ConfiguracionPermisos_usuariomodifico = value
        End Set
    End Property


End Class
