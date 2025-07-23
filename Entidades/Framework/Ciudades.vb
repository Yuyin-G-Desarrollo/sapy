Public Class Ciudades

    Private Nombre As String
    Private ciudadId As Int32
    Private EstadoNombre As Entidades.Estados
    Private Activo As Boolean
    Private PaisNombre As Entidades.Paises
    Private IDEstado As Entidades.Estados
    Private IDPais As Entidades.Estados

    Public Property CIDPais As Estados
        Get
            Return IDPais
        End Get
        Set(ByVal value As Estados)
            IDPais = value
        End Set
    End Property


    Public Property CIDEstado As Estados
        Get
            Return IDEstado
        End Get
        Set(ByVal value As Estados)
            IDEstado = value
        End Set

    End Property


    Public Property CNombreEstado As Estados
        Get
            Return EstadoNombre

        End Get
        Set(ByVal value As Estados)
            EstadoNombre = value
        End Set
    End Property

    Public Property CNombrePais As Paises
        Get
            Return PaisNombre
        End Get
        Set(ByVal value As Paises)
            PaisNombre = value
        End Set
    End Property

    Public Property CNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property CActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property
    Public Property CciudadId As Int32
        Get
            Return ciudadId
        End Get
        Set(value As Int32)
            ciudadId = value
        End Set
    End Property
End Class
