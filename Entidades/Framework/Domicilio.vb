Public Class Domicilio

    Private Pdomicilioid As Integer
    Public Property domicilioid() As Integer
        Get
            Return Pdomicilioid
        End Get
        Set(ByVal value As Integer)
            Pdomicilioid = value
        End Set
    End Property

    Private Pcalle As String
    Public Property calle() As String
        Get
            Return Pcalle
        End Get
        Set(ByVal value As String)
            Pcalle = value
        End Set
    End Property

    Private Pnuminterior As String
    Public Property numinterior() As String
        Get
            Return Pnuminterior
        End Get
        Set(ByVal value As String)
            Pnuminterior = value
        End Set
    End Property

    Private Pnumexterior As String
    Public Property numexterior() As String
        Get
            Return Pnumexterior
        End Get
        Set(ByVal value As String)
            Pnumexterior = value
        End Set
    End Property

    Private Pcolonia As String
    Public Property colonia() As String
        Get
            Return Pcolonia
        End Get
        Set(ByVal value As String)
            Pcolonia = value
        End Set
    End Property

    Private Pcp As String
    Public Property cp() As String
        Get
            Return Pcp
        End Get
        Set(ByVal value As String)
            Pcp = value
        End Set
    End Property

    Private Pdelegacion As String
    Public Property delegacion() As String
        Get
            Return Pdelegacion
        End Get
        Set(ByVal value As String)
            Pdelegacion = value
        End Set
    End Property

    Private Pciudad As Ciudades
    Public Property ciudad() As Ciudades
        Get
            Return Pciudad
        End Get
        Set(ByVal value As Ciudades)
            Pciudad = value
        End Set
    End Property

    Private Pestado As Estados
    Public Property estado() As Estados
        Get
            Return Pestado
        End Get
        Set(ByVal value As Estados)
            Pestado = value
        End Set
    End Property

    Private Ppais As Paises
    Public Property pais() As Paises
        Get
            Return Ppais
        End Get
        Set(ByVal value As Paises)
            Ppais = value
        End Set
    End Property

    Private Ppoblacion As Poblacion
    Public Property poblacion() As Poblacion
        Get
            Return Ppoblacion
        End Get
        Set(ByVal value As Poblacion)
            Ppoblacion = value
        End Set
    End Property

    Private Ppersonaid As Persona
    Public Property persona() As Persona
        Get
            Return Ppersonaid
        End Get
        Set(ByVal value As Persona)
            Ppersonaid = value
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
