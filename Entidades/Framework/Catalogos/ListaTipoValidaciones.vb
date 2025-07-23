Public Class ListaTipoValidaciones

    Private IdTipo As Integer
    Private Nombre As String
    Private Tabla As String
    Private CampoTabla As String
    Private CampoTablaStatus As String
    Private Activo As Boolean

    Public Property PId As Integer
        Get
            Return IdTipo
        End Get
        Set(value As Integer)
            IdTipo = value
        End Set
    End Property

    Public Property Pnombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property PTabla As String
        Get
            Return Tabla
        End Get
        Set(value As String)
            Tabla = value
        End Set
    End Property

    Public Property PCampoTabla As String
        Get
            Return CampoTabla
        End Get
        Set(value As String)
            CampoTabla = value
        End Set
    End Property

    Public Property PCampoTablaStatus As String
        Get
            Return CampoTablaStatus
        End Get
        Set(value As String)
            CampoTablaStatus = value
        End Set
    End Property

    Public Property Pactivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property


End Class
