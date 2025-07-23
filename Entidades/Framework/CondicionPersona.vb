Public Class CondicionPersona

    Private Pcondicionpersonaid As Integer
    Public Property condicionpersonaid() As Integer
        Get
            Return Pcondicionpersonaid
        End Get
        Set(ByVal value As Integer)
            Pcondicionpersonaid = value
        End Set
    End Property

    Private Pvalor As String
    Public Property valor() As String
        Get
            Return Pvalor
        End Get
        Set(ByVal value As String)
            Pvalor = value
        End Set
    End Property

    Private Pdescripcion As String
    Public Property descripcion() As String
        Get
            Return Pdescripcion
        End Get
        Set(ByVal value As String)
            Pdescripcion = value
        End Set
    End Property

    Private Pcondicioncatalogo As CondicionCatalogo
    Public Property condicioncatalogo() As CondicionCatalogo
        Get
            Return Pcondicioncatalogo
        End Get
        Set(ByVal value As CondicionCatalogo)
            Pcondicioncatalogo = value
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
