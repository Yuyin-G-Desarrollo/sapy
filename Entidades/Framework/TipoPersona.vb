
Public Class TipoPersona

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

    Private PRegimenFiscalId As Int32
    Public Property regimenFiscalId() As Int32
        Get
            Return PRegimenFiscalId
        End Get
        Set(ByVal value As Int32)
            PRegimenFiscalId = value
        End Set
    End Property


End Class
