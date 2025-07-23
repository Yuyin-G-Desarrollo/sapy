Public Class Horarios

    Private Naves As Entidades.Naves

    Private Horariosid As Integer
    Private Nombre As String
    Private Activo As Boolean
    Private retardo As Integer

    Public Property PNaves As Entidades.Naves
        Get
            Return Naves
        End Get
        Set(ByVal value As Entidades.Naves)
            Naves = value

        End Set
    End Property

    Public Property DHorariosid As Integer
        Get
            Return Horariosid
        End Get
        Set(ByVal value As Integer)
            Horariosid = value
        End Set
    End Property

    Public Property DNombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property DActivo As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property DRetardo As Integer
        Set(ByVal value As Integer)
            retardo = value
        End Set
        Get
            Return retardo
        End Get
    End Property

End Class



