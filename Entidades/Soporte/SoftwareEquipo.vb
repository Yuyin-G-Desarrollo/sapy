Public Class SoftwareEquipo


    Private softequi_softwareid As Integer

    Public Property SESoftwareId() As Integer
        Get
            Return softequi_softwareid
        End Get
        Set(ByVal value As Integer)
            softequi_softwareid = value
        End Set
    End Property


    Private softequi_equipoid As Integer

    Public Property SEEquipoId() As Integer
        Get
            Return softequi_equipoid
        End Get
        Set(ByVal value As Integer)
            softequi_equipoid = value
        End Set
    End Property


    Private softequi_licencia As String

    Public Property SELicencia() As String
        Get
            Return softequi_licencia
        End Get
        Set(ByVal value As String)
            softequi_licencia = value
        End Set
    End Property


    Private softequi_serial As String

    Public Property SESerial() As String
        Get
            Return softequi_serial
        End Get
        Set(ByVal value As String)
            softequi_serial = value
        End Set
    End Property


    Private softequi_descripcion As String

    Public Property SEDescripcion() As String
        Get
            Return softequi_descripcion
        End Get
        Set(ByVal value As String)
            softequi_descripcion = value
        End Set
    End Property


    Private softequi_fechainstalacion As DateTime

    Public Property SEFechaInstalacion() As DateTime
        Get
            Return softequi_fechainstalacion
        End Get
        Set(ByVal value As DateTime)
            softequi_fechainstalacion = value
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
