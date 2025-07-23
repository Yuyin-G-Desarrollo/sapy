Public Class Grupos
    Private GrupoId As Int32
    Private GrupoDescripcion As String
    Private GrupoAvtivo As Boolean

    Public Property PGrupoId As Int32
        Get
            Return GrupoId
        End Get
        Set(ByVal value As Int32)
            GrupoId = value
        End Set
    End Property

    Public Property PGDescripcion As String
        Get
            Return GrupoDescripcion
        End Get
        Set(ByVal value As String)
            GrupoDescripcion = value
        End Set
    End Property

    Public Property PGActivo As Boolean
        Get
            Return GrupoAvtivo
        End Get
        Set(ByVal value As Boolean)
            GrupoAvtivo = value
        End Set
    End Property


End Class
