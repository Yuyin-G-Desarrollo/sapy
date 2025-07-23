Public Class Paises
    Private Nombre As String
    Private IDPais As Int32
    Private Activo As Boolean

    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property PIDPais As Int32
        Get
            Return IDPais
        End Get
        Set(ByVal value As Int32)
            IDPais = value
        End Set
    End Property
    'Declaración


End Class
