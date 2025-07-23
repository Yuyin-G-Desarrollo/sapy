Public Class AsignacionEquipos


    Private equi_equipoid As Integer

    Public Property EEquipoId() As Integer
        Get
            Return equi_equipoid
        End Get
        Set(ByVal value As Integer)
            equi_equipoid = value
        End Set
    End Property


    Private equi_hardwareid As Integer

    Public Property EHardwareId() As Integer
        Get
            Return equi_hardwareid
        End Get
        Set(ByVal value As Integer)
            equi_hardwareid = value
        End Set
    End Property


    Private equi_serial As String

    Public Property ESerial() As String
        Get
            Return equi_serial
        End Get
        Set(ByVal value As String)
            equi_serial = value
        End Set
    End Property


    Private equi_compraid As Integer

    Public Property ECompraId() As Integer
        Get
            Return equi_compraid
        End Get
        Set(ByVal value As Integer)
            equi_compraid = value
        End Set
    End Property


    Private compraequi_descripcionequipo As String

    Public Property EDescripcionEquipo() As String
        Get
            Return compraequi_descripcionequipo
        End Get
        Set(ByVal value As String)
            compraequi_descripcionequipo = value
        End Set
    End Property


    Private equi_colaboradorid As Integer

    Public Property EColaboradorId() As Integer
        Get
            Return equi_colaboradorid
        End Get
        Set(ByVal value As Integer)
            equi_colaboradorid = value
        End Set
    End Property


    Private equi_nombre As String

    Public Property ENombreColaborador() As String
        Get
            Return equi_nombre
        End Get
        Set(ByVal value As String)
            equi_nombre = value
        End Set
    End Property



    Private equi_naveid As Integer

    Public Property ENaveId() As Integer
        Get
            Return equi_naveid
        End Get
        Set(ByVal value As Integer)
            equi_naveid = value
        End Set
    End Property


    Private equi_ip As String

    Public Property EIp() As String
        Get
            Return equi_ip
        End Get
        Set(ByVal value As String)
            equi_ip = value
        End Set
    End Property


    Private equi_usuariopc As String

    Public Property EUsuarioPC() As String
        Get
            Return equi_usuariopc
        End Get
        Set(ByVal value As String)
            equi_usuariopc = value
        End Set
    End Property


    Private equi_contrasenapc As String

    Public Property EContrasenaPC() As String
        Get
            Return equi_contrasenapc
        End Get
        Set(ByVal value As String)
            equi_contrasenapc = value
        End Set
    End Property


    Private equi_mac As String

    Public Property EMac() As String
        Get
            Return equi_mac
        End Get
        Set(ByVal value As String)
            equi_mac = value
        End Set
    End Property


    Private equi_cuentacorreo As String

    Public Property ECuentaCorreo() As String
        Get
            Return equi_cuentacorreo
        End Get
        Set(ByVal value As String)
            equi_cuentacorreo = value
        End Set
    End Property


    Private equi_contrasenacorreo As String

    Public Property EContrasenaCorreo() As String
        Get
            Return equi_contrasenacorreo
        End Get
        Set(ByVal value As String)
            equi_contrasenacorreo = value
        End Set
    End Property


    Private equi_statusequipo As String

    Public Property EStatusEquipo() As String
        Get
            Return equi_statusequipo
        End Get
        Set(ByVal value As String)
            equi_statusequipo = value
        End Set
    End Property


    Private equi_fechabaja As DateTime

    Public Property EFechaBaja() As DateTime
        Get
            Return equi_fechabaja
        End Get
        Set(ByVal value As DateTime)
            equi_fechabaja = value
        End Set
    End Property


    Private equi_motivobaja As String

    Public Property EMotivoBaja() As String
        Get
            Return equi_motivobaja
        End Get
        Set(ByVal value As String)
            equi_motivobaja = value
        End Set
    End Property


    Private equi_usuariocrea As Integer

    Public Property EUsuarioCrea() As Integer
        Get
            Return equi_usuariocrea
        End Get
        Set(ByVal value As Integer)
            equi_usuariocrea = value
        End Set
    End Property


    Private equi_usuariomodifica As Integer

    Public Property EUsuarioModifica() As Integer
        Get
            Return equi_usuariomodifica
        End Get
        Set(ByVal value As Integer)
            equi_usuariomodifica = value
        End Set
    End Property

End Class
