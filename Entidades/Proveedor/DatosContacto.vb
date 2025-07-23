
Public Class DatosContacto

    Private proveedorid As Integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property


    Private nombre As String
    Public Property daco_nombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property


    Private Paterno As String
    Public Property daco_APaterno() As String
        Get
            Return Paterno
        End Get
        Set(ByVal value As String)
            Paterno = value
        End Set
    End Property


    Private Materno As String
    Public Property daco_AMaterno() As String
        Get
            Return Materno
        End Get
        Set(ByVal value As String)
            Materno = value
        End Set
    End Property

    Private activo As String
    Public Property daco_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property

    Private datoscontactoid As Integer
    Public Property daco_datoscontactoid() As Integer
        Get
            Return datoscontactoid
        End Get
        Set(ByVal value As Integer)
            datoscontactoid = value
        End Set
    End Property

    Private TipoContacto As String
    Public Property daco_TipoContacto() As String
        Get
            Return TipoContacto
        End Get
        Set(ByVal value As String)
            TipoContacto = value
        End Set
    End Property

Private cargo As String
    Public Property daco_cargo() As String
        Get
            Return cargo
        End Get
        Set(ByVal value As String)
            cargo = value
        End Set
    End Property

Private telefono As String
    Public Property daco_telefono() As String
        Get
            Return Telefono
        End Get
        Set(ByVal value As String)
            Telefono = value
        End Set
    End Property

    Private notificaciondepago As String
    Public Property daco_notificaciondepago() As String
        Get
            Return notificaciondepago
        End Get
        Set(ByVal value As String)
            notificaciondepago = value
        End Set
    End Property

Private email As String
    Public Property daco_email() As String
        Get
            Return Email
        End Get
        Set(ByVal value As String)
            Email = value
        End Set
    End Property

Private departamento As String
    Public Property daco_departamento() As String
        Get
            Return departamento
        End Get
        Set(ByVal value As String)
            departamento = value
        End Set
    End Property

    'Private proveedorid As integer
    '    Public Property daco_proveedorid() As Integer
    '        Get
    '            Return proveedorid
    '        End Get
    '        Set(ByVal value As Integer)
    '            proveedorid = value
    '        End Set
    '    End Property

Private usuariocreoid As integer
    Public Property daco_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property daco_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property daco_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property daco_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

    Private foto As String
    Public Property daco_foto() As String
        Get
            Return foto
        End Get
        Set(ByVal value As String)
            foto = value
        End Set
    End Property

    Private Firma As String
    Public Property daco_Firma() As String
        Get
            Return Firma
        End Get
        Set(ByVal value As String)
            Firma = value
        End Set
    End Property

End Class
