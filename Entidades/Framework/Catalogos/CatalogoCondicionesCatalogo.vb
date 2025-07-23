Public Class CatalogoCondicionesCatalogo

    Private IdConCatalogo As Integer
    Private Descripcion As String
    Private IdCondicion As Integer
    Private OpcionDefault As Boolean
    Private Activo As Boolean


    Public Property PIdCatalogo As Integer
        Get
            Return IdConCatalogo
        End Get
        Set(value As Integer)
            IdConCatalogo = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PIdCondicion As Integer
        Get
            Return IdCondicion
        End Get
        Set(value As Integer)
            IdCondicion = value
        End Set
    End Property

    Public Property POpcionDefault As Boolean
        Get
            Return OpcionDefault
        End Get
        Set(value As Boolean)
            OpcionDefault = value
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
