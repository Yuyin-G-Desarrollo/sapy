Public Class Telefono

    Private Ptelefonoid As Integer
    Public Property telefonoid() As Integer
        Get
            Return Ptelefonoid
        End Get
        Set(ByVal value As Integer)
            Ptelefonoid = value
        End Set
    End Property

    Private Ptelefono As String
    Public Property telefono() As String
        Get
            Return Ptelefono
        End Get
        Set(ByVal value As String)
            Ptelefono = value
        End Set
    End Property

    Private Pextension As String
    Public Property extension() As String
        Get
            Return Pextension
        End Get
        Set(ByVal value As String)
            Pextension = value
        End Set
    End Property

    Private Ptipotelefono As TipoTelefono
    Public Property tipotelefono() As TipoTelefono
        Get
            Return Ptipotelefono
        End Get
        Set(ByVal value As TipoTelefono)
            Ptipotelefono = value
        End Set
    End Property

    Private Ppersona As Persona
    Public Property persona() As Persona
        Get
            Return Ppersona
        End Get
        Set(ByVal value As Persona)
            Ppersona = value
        End Set
    End Property

    Private Pclasificacionpersona As ClasificacionPersona
    Public Property clasificacionpersona() As ClasificacionPersona
        Get
            Return Pclasificacionpersona
        End Get
        Set(ByVal value As ClasificacionPersona)
            Pclasificacionpersona = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property
    Private Pwhatsaap As Boolean
    Public Property whatsaap() As Boolean
        Get
            Return Pwhatsaap
        End Get
        Set(ByVal value As Boolean)
            Pwhatsaap = value
        End Set
    End Property

End Class
