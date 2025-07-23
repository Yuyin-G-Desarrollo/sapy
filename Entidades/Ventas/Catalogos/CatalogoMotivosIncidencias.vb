
Public Class CatalogoMotivosIncidencias

    Private PMotivoIncidenciaID As Int32
    Private PMotivo As String
    Private PCategoriaID As Int32
    Private PActivo As Boolean
    Private PUsuarioCreoID As Int32
    Private PFechaCreacion As Date
    Private PUsuarioModificoID As Int32
    Private PFechaModificacion As Date

#Region "Propiedades"

    Public Property CategoriaID As Integer
        Get
            Return PCategoriaID
        End Get
        Set(value As Integer)
            PCategoriaID = value
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

    Public Property UsuarioModificoID As Int32
        Get
            Return PUsuarioModificoID
        End Get
        Set(value As Int32)
            PUsuarioModificoID = value
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

    Public Property UsuarioCreoID As Integer
        Get
            Return PUsuarioCreoID
        End Get
        Set(value As Integer)
            PUsuarioCreoID = value
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

    Public Property MotivoIncidenciaID As Integer
        Get
            Return PMotivoIncidenciaID
        End Get
        Set(value As Integer)
            PMotivoIncidenciaID = value
        End Set
    End Property

    Public Property Motivo As String
        Get
            Return PMotivo
        End Get
        Set(value As String)
            PMotivo = value
        End Set
    End Property

#End Region


  
End Class
