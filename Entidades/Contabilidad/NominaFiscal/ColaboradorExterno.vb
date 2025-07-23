Public Class ColaboradorExterno
    Private nombre As String
    Public Property PNombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private aPaterno As String
    Public Property PAPaterno() As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Private aMaterno As String
    Public Property PAMaterno() As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Private calle As String
    Public Property PCalle() As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property

    Private colonia As String
    Public Property PColonia() As String
        Get
            Return colonia
        End Get
        Set(ByVal value As String)
            colonia = value
        End Set
    End Property

    Private domicilioNumero As String
    Public Property PDomicilioNumero() As String
        Get
            Return domicilioNumero
        End Get
        Set(ByVal value As String)
            domicilioNumero = value
        End Set
    End Property

    Private curp As String
    Public Property PCurp() As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Private rfc As String
    Public Property PRfc() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private fechaNacimiento As String
    Public Property PFechaNacimiento() As String
        Get
            Return fechaNacimiento
        End Get
        Set(ByVal value As String)
            fechaNacimiento = value
        End Set
    End Property

    Private entreCalles As String
    Public Property PEntreCalles() As String
        Get
            Return entreCalles
        End Get
        Set(ByVal value As String)
            entreCalles = value
        End Set
    End Property

    Private referencia As String
    Public Property PReferencia() As String
        Get
            Return referencia
        End Get
        Set(ByVal value As String)
            referencia = value
        End Set
    End Property

    Private sexo As String
    Public Property PSexo() As String
        Get
            Return sexo
        End Get
        Set(ByVal value As String)
            sexo = value
        End Set
    End Property

    Private cp As String
    Public Property PCP() As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Private idCiudadOrigen As Int32
    Public Property PIdCiudadOrigen() As Int32
        Get
            Return idCiudadOrigen
        End Get
        Set(ByVal value As Int32)
            idCiudadOrigen = value
        End Set
    End Property

    Private idNave As Int32
    Public Property PidNave() As Int32
        Get
            Return idNave
        End Get
        Set(ByVal value As Int32)
            idNave = value
        End Set
    End Property

    Private idPatron As Int32
    Public Property PIdPatron() As Int32
        Get
            Return idPatron
        End Get
        Set(ByVal value As Int32)
            idPatron = value
        End Set
    End Property

    Private idColaborador As String
    Public Property PIdColaborador() As String
        Get
            Return idColaborador
        End Get
        Set(ByVal value As String)
            idColaborador = value
        End Set
    End Property

    Private idPuesto As Int32
    Public Property PIdPuesto() As Int32
        Get
            Return idPuesto
        End Get
        Set(ByVal value As Int32)
            idPuesto = value
        End Set
    End Property

    Private sdi As Double
    Public Property PSDI() As Double
        Get
            Return sdi
        End Get
        Set(ByVal value As Double)
            sdi = value
        End Set
    End Property

    Private idPuestoReal As Int32
    Public Property PIdPuestoReal() As Int32
        Get
            Return idPuestoReal
        End Get
        Set(ByVal value As Int32)
            idPuestoReal = value
        End Set
    End Property

    Private idDeptoFiscal As String
    Public Property PIdDeptoFiscal() As String
        Get
            Return idDeptoFiscal
        End Get
        Set(ByVal value As String)
            idDeptoFiscal = value
        End Set
    End Property

    Private idDeptoReal As String
    Public Property PIdDeptoReal() As String
        Get
            Return idDeptoReal
        End Get
        Set(ByVal value As String)
            idDeptoReal = value
        End Set
    End Property

    Private nss As String
    Public Property PNSS() As String
        Get
            Return nss
        End Get
        Set(ByVal value As String)
            nss = value
        End Set
    End Property

    Private observaciones As String
    Public Property PObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

    Private obra As String
    Public Property PObra() As String
        Get
            Return obra
        End Get
        Set(ByVal value As String)
            obra = value
        End Set
    End Property

    Private ganaComision As Boolean
    Public Property PGanaComision As Boolean
        Get
            Return ganaComision
        End Get
        Set(value As Boolean)
            ganaComision = value
        End Set
    End Property

    Private montoComision As Double
    Public Property PMontoComision As Double
        Get
            Return montoComision
        End Get
        Set(value As Double)
            montoComision = value
        End Set
    End Property

    Private tipoSalario As Integer
    Public Property PTipoSalario As Integer
        Get
            Return tipoSalario
        End Get
        Set(value As Integer)
            tipoSalario = value
        End Set
    End Property

End Class
