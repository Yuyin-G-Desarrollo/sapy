Public Class CatalogoMotivoCancelacion

    Private PMotivoCancelacionID As Int32 'SI
    Private PTipoEstatus As String ''NO
    Private PNombre As String ''SI
    Private PDescripcion As String '' SI
    Private PActivo As Boolean  ''SI

    Private PUsuarioCreoID As Int32 'SI
    Private PFechaCreacion As Date 'SI
    Private PUsuarioModificoID As Int32 'SI
    Private PFechaModificacion As Date 'SI

#Region "Propiedades"
    Public Property MotivoCancelacionID As Integer
        Get
            Return PMotivoCancelacionID
        End Get
        Set(value As Integer)
            PMotivoCancelacionID = value
        End Set
    End Property



    Public Property TipoEstatus As String
        Get
            Return PTipoEstatus
        End Get
        Set(value As String)
            PTipoEstatus = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return PNombre
        End Get
        Set(value As String)
            PNombre = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return PDescripcion
        End Get
        Set(value As String)
            PDescripcion = value
        End Set
    End Property

    Public Property UsuarioCreoID As Integer
        Get
            Return PUsuarioCreoID
        End Get
        Set(value As Integer)
            PUsuarioCreoID = value
        End Set
    End Property

    Public Property FechaCreacion As Date
        Get
            Return PFechaCreacion
        End Get
        Set(value As Date)
            PFechaCreacion = value
        End Set
    End Property

    Public Property UsuarioModificoID As Integer
        Get
            Return PUsuarioModificoID
        End Get
        Set(value As Integer)
            PUsuarioModificoID = value
        End Set
    End Property

    Public Property FechaModificacion As Date
        Get
            Return PFechaModificacion
        End Get
        Set(value As Date)
            PFechaModificacion = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return PActivo
        End Get
        Set(value As Boolean)
            PActivo = value
        End Set
    End Property





#End Region
End Class
