Public Class Acciones

    Private AccionId As Int32
    Private Modulo As Modulos
    Private Componente As String
    Private Nombre As String
    Private Icono As String
    Private Clave As String
    Private Tipo As Int32
    Private Activo As Boolean

    Public Property PAccionId As Int32
        Get
            Return AccionId
        End Get
        Set(ByVal value As Int32)
            AccionId = value
        End Set
    End Property

    Public Property PModulo As Modulos
        Get
            Return Modulo
        End Get
        Set(ByVal value As Modulos)
            Modulo = value
        End Set
    End Property

    Public Property PComponente As String
        Get
            Return Componente
        End Get
        Set(ByVal value As String)
            Componente = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property PIcono As String
        Get
            Return Icono
        End Get
        Set(ByVal value As String)
            Icono = value
        End Set
    End Property

    Public Property PClave As String
        Get
            Return Clave
        End Get
        Set(ByVal value As String)
            Clave = value
        End Set
    End Property

    Public Property PTipo As Int32
        Get
            Return Tipo
        End Get
        Set(ByVal value As Int32)
            Tipo = value
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

End Class
