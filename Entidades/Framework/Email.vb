Public Class Email

    Private Pemailpersonasid As Integer
    Public Property emailpersonasid() As Integer
        Get
            Return Pemailpersonasid
        End Get
        Set(ByVal value As Integer)
            Pemailpersonasid = value
        End Set
    End Property

    Private Pemail As String
    Public Property email() As String
        Get
            Return Pemail
        End Get
        Set(ByVal value As String)
            Pemail = value
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

End Class
