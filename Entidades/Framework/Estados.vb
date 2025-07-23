Public Class Estados

    Private Nombre As String
    Private IDPais As Int32
    Private Activo As Boolean
    Private IDDEstado As Int32
    Private Pais As Paises

    Public Property ENombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property EIDPais As Int32
        Get
            Return IDPais
        End Get
        Set(ByVal value As Int32)
            IDPais = value
        End Set

    End Property

    Public Property EActivo As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property


    Public Property EIDDEstado As Int32
        Get
            Return IDDEstado
        End Get
        Set(ByVal value As Int32)
            IDDEstado = value
        End Set
    End Property

    Public Property PPais As Paises
        Get
            Return Pais
        End Get
        Set(ByVal value As Paises)
            Pais = value
        End Set
    End Property


End Class
