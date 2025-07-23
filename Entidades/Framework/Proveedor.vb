Public Class Proveedor
    Private proveedorid As Int32
    Private nombregenerico As String
    Private razonsocial As String
    Private rfc As String
    Private claveyuyincliente As Int32
    Private usuarioweb As String
    Private contrasenaweb As String
    Private horario As String
    Private personaidproveedor As Int32
    Private clasificacionpersonaid As Int32
    Private comentarios As String
    Private usuariocreoid As Int32
    Private webproveedor As String

    Public Property pwebproveedor As String
        Get
            Return webproveedor
        End Get
        Set(value As String)
            webproveedor = value
        End Set
    End Property

    Public Property pproveedorid As Int32
        Get
            Return proveedorid
        End Get
        Set(value As Int32)
            proveedorid = value
        End Set
    End Property
    Public Property pnombregenerico As String
        Get
            Return nombregenerico
        End Get
        Set(value As String)
            nombregenerico = value
        End Set
    End Property
    Public Property prazonsocial As String
        Get
            Return razonsocial
        End Get
        Set(value As String)
            razonsocial = value
        End Set
    End Property
    Public Property prfc As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
        End Set
    End Property
    Public Property pclaveyuyincliente As Int32
        Get
            Return claveyuyincliente
        End Get
        Set(value As Int32)
            claveyuyincliente = value
        End Set
    End Property
    Public Property pusuarioweb As String
        Get
            Return usuarioweb
        End Get
        Set(value As String)
            usuarioweb = value
        End Set
    End Property
    Public Property pcontrasenaweb As String
        Get
            Return contrasenaweb
        End Get
        Set(value As String)
            contrasenaweb = value
        End Set
    End Property
    Public Property phorario As String
        Get
            Return horario

        End Get
        Set(value As String)
            horario = value
        End Set
    End Property

    Public Property ppersonaidproveedor As Int32
        Get
            Return personaidproveedor
        End Get
        Set(value As Int32)
            personaidproveedor = value
        End Set
    End Property
    Public Property pclasificacionpersonaid As Int32
        Get
            Return clasificacionpersonaid
        End Get
        Set(value As Int32)
            clasificacionpersonaid = value
        End Set
    End Property
    Public Property pcomentarios As String
        Get
            Return comentarios
        End Get
        Set(value As String)
            comentarios = value
        End Set
    End Property
    Public Property pusuariocreoid As Int32
        Get
            Return usuariocreoid
        End Get
        Set(value As Int32)
            usuariocreoid = value
        End Set
    End Property

End Class
