Public Class Empresas

    Private PEmpresaID As Int32
    Public Property EmpresaID() As Int32
        Get
            Return PEmpresaID
        End Get
        Set(ByVal value As Int32)
            PEmpresaID = value
        End Set
    End Property

    Private PNombre As String
    Public Property Nombre() As String
        Get
            Return PNombre
        End Get
        Set(value As String)
            PNombre = value
        End Set
    End Property

    Private PRFC As String
    Public Property RFC() As String
        Get
            Return PRFC
        End Get
        Set(value As String)
            PRFC = value
        End Set
    End Property

    Private PTasaIVA As Double
    Public Property TasaIVA() As Double
        Get
            Return PTasaIVA
        End Get
        Set(value As Double)
            PTasaIVA = value
        End Set
    End Property

    Private PTasaIVAEncabezado As Double
    Public Property TasaIVAEncabezado() As Double
        Get
            Return PTasaIVAEncabezado
        End Get
        Set(ByVal value As Double)
            PTasaIVAEncabezado = value
        End Set
    End Property

    Private PRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return PRazonSocial
        End Get
        Set(ByVal value As String)
            PRazonSocial = value
        End Set
    End Property

    Private PCalle As String
    Public Property Calle() As String
        Get
            Return PCalle
        End Get
        Set(ByVal value As String)
            PCalle = value
        End Set
    End Property

    Private PNumero As String
    Public Property Numero() As String
        Get
            Return PNumero
        End Get
        Set(ByVal value As String)
            PNumero = value
        End Set
    End Property

    Private PRutaCertificado As String
    Public Property RutaCertificado() As String
        Get
            Return PRutaCertificado
        End Get
        Set(ByVal value As String)
            PRutaCertificado = value
        End Set
    End Property

    Private PRutaKEY As String
    Public Property RutaKEY() As String
        Get
            Return PRutaKEY
        End Get
        Set(ByVal value As String)
            PRutaKEY = value
        End Set
    End Property

    Private PNumeroCertificado As String
    Public Property NumeroCertificado() As String
        Get
            Return PNumeroCertificado
        End Get
        Set(ByVal value As String)
            PNumeroCertificado = value
        End Set
    End Property

    Private PWebService As String
    Public Property WebService() As String
        Get
            Return PWebService
        End Get
        Set(value As String)
            PWebService = value
        End Set
    End Property

    Private PUsuarioWS As String
    Public Property UsuarioWS() As String
        Get
            Return PUsuarioWS
        End Get
        Set(value As String)
            PUsuarioWS = value
        End Set
    End Property

    Private PContraseñaWS As String
    Public Property ContraseñaWS() As String
        Get
            Return PContraseñaWS
        End Get
        Set(value As String)
            PContraseñaWS = value
        End Set
    End Property

    Private PContraseñaCertificado As String
    Public Property ContraseñaCertificado() As String
        Get
            Return PContraseñaCertificado
        End Get
        Set(ByVal value As String)
            PContraseñaCertificado = value
        End Set
    End Property

    Private PCertificadoVigenciaInicio As Date
    Public Property CertificadoVigenciaInicio() As Date
        Get
            Return PCertificadoVigenciaInicio
        End Get
        Set(ByVal value As Date)
            PCertificadoVigenciaInicio = value
        End Set
    End Property

    Private PCertificadovigenciaFin As Date
    Public Property CertificadovigenciaFin() As Date
        Get
            Return PCertificadovigenciaFin
        End Get
        Set(ByVal value As Date)
            PCertificadovigenciaFin = value
        End Set
    End Property

    Private PRutaXML As String
    Public Property RutaXML() As String
        Get
            Return PRutaXML
        End Get
        Set(ByVal value As String)
            PRutaXML = value
        End Set
    End Property

    Private PRutaPDF As String
    Public Property RutaPDF() As String
        Get
            Return PRutaPDF
        End Get
        Set(value As String)
            PRutaPDF = value
        End Set
    End Property

    Private PSerie As String
    Public Property Serie() As String
        Get
            Return PSerie
        End Get
        Set(value As String)
            PSerie = value
        End Set
    End Property

    Private PColonia As String
    Public Property Colonia() As String
        Get
            Return PColonia
        End Get
        Set(value As String)
            PColonia = value
        End Set
    End Property

    Private PRegimen As String
    Public Property Regimen() As String
        Get
            Return PRegimen
        End Get
        Set(ByVal value As String)
            PRegimen = value
        End Set
    End Property

    Private PCP As String
    Public Property CP() As String
        Get
            Return PCP
        End Get
        Set(value As String)
            PCP = value
        End Set
    End Property

    Private PCadenaCertificado As String
    Public Property CadenaCertificado() As String
        Get
            Return PCadenaCertificado
        End Get
        Set(value As String)
            PCadenaCertificado = value
        End Set
    End Property

    Private PCURP As String
    Public Property CURP() As String
        Get
            Return PCURP
        End Get
        Set(value As String)
            PCURP = value
        End Set
    End Property

    Private PClaveRegimen As String
    Public Property ClaveRegimen() As String
        Get
            Return PClaveRegimen
        End Get
        Set(ByVal value As String)
            PClaveRegimen = value
        End Set
    End Property

    Private PIdentificadorPAX As String
    Public Property IdentificadorPAX() As String
        Get
            Return PIdentificadorPAX
        End Get
        Set(value As String)
            PIdentificadorPAX = value
        End Set
    End Property



End Class