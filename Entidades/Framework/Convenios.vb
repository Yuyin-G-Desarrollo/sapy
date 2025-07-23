Public Class Convenios

    Private IdConvenio As Integer
    Private NumeroConvenio As String
    Private fechaSubscripcion As Date
    Private FechaInicio As Date
    Private FechaFin As Date
    Private PersonaNegocia As String
    Private descripcion As String
    Private comentario As String
    Private IdEmpresa As Integer
    Private IdProveedor As Integer
    Private Activo As Boolean

    Public Property PIdConvenio As Int32
        Get
            Return IdConvenio
        End Get
        Set(value As Int32)
            IdConvenio = value
        End Set
    End Property

    Public Property PNumeroConvenio As String
        Get
            Return NumeroConvenio
        End Get
        Set(value As String)
            NumeroConvenio = value
        End Set
    End Property

    Public Property PFechaSub As Date
        Get
            Return fechaSubscripcion
        End Get
        Set(value As Date)
            fechaSubscripcion = value
        End Set
    End Property

    Public Property PFechaInicio As Date
        Get
            Return FechaInicio
        End Get
        Set(value As Date)
            FechaInicio = value
        End Set
    End Property

    Public Property PFechaFin As Date
        Get
            Return FechaFin
        End Get
        Set(value As Date)
            FechaFin = value
        End Set
    End Property

    Public Property PNegociador As String
        Get
            Return PersonaNegocia
        End Get
        Set(value As String)
            PersonaNegocia = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property PComentario As String
        Get
            Return comentario
        End Get
        Set(value As String)
            comentario = value
        End Set
    End Property

    Public Property PIdEmpresa As Int32
        Get
            Return IdEmpresa
        End Get
        Set(value As Int32)
            IdEmpresa = value
        End Set
    End Property

    Public Property PIdProveedor As Int32
        Get
            Return IdProveedor
        End Get
        Set(value As Int32)
            IdProveedor = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property


End Class
