Public Class Patron

    Private patronid As Integer
    Public Property PPatronId As Integer
        Get
            Return patronid
        End Get
        Set(value As Integer)
            patronid = value
        End Set
    End Property

    Private nombre As String
    Public Property PNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Private rfc As String
    Public Property PRFC As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
        End Set
    End Property

    Private nopatronal As String
    Public Property PNoPatronal As String
        Get
            Return nopatronal
        End Get
        Set(value As String)
            nopatronal = value
        End Set
    End Property

    Private calle As String
    Public Property PCalle As String
        Get
            Return calle
        End Get
        Set(value As String)
            calle = value
        End Set
    End Property

    Private numero As String
    Public Property PNumero As String
        Get
            Return numero
        End Get
        Set(value As String)
            numero = value
        End Set
    End Property

    Private colonia As String
    Public Property PColonia As String
        Get
            Return colonia
        End Get
        Set(value As String)
            colonia = value
        End Set
    End Property

    Private ciudadid As Integer
    Public Property PCiudadId As Integer
        Get
            Return ciudadid
        End Get
        Set(value As Integer)
            ciudadid = value
        End Set
    End Property

    Private estadoid As Integer
    Public Property PEstadoId As Integer
        Get
            Return estadoid
        End Get
        Set(value As Integer)
            estadoid = value
        End Set
    End Property

    Private cp As String
    Public Property PCP As String
        Get
            Return cp
        End Get
        Set(value As String)
            cp = value
        End Set
    End Property

    Private activo As Boolean
    Public Property PActivo As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

    Private empresaid As Integer
    Public Property PEmpresaId As Integer
        Get
            Return empresaid
        End Get
        Set(value As Integer)
            empresaid = value
        End Set
    End Property

    Private naveid As Integer
    Public Property PNaveId As Integer
        Get
            Return naveid
        End Get
        Set(value As Integer)
            naveid = value
        End Set
    End Property

    Private checador As Boolean
    Public Property PChecador As Boolean
        Get
            Return checador
        End Get
        Set(value As Boolean)
            checador = value
        End Set
    End Property

    Private tipocolaborador As Integer
    Public Property PTipoColaborador As Integer
        Get
            Return tipocolaborador
        End Get
        Set(value As Integer)
            tipocolaborador = value
        End Set
    End Property

    Private tipocontrato As String
    Public Property PTipoContrato As String
        Get
            Return tipocontrato
        End Get
        Set(value As String)
            tipocontrato = value
        End Set
    End Property

    Private riesgopuesto As String
    Public Property PRiesgoPuesto As String
        Get
            Return riesgopuesto
        End Get
        Set(value As String)
            riesgopuesto = value
        End Set
    End Property

    Private cajachica As Integer
    Public Property PCajaChica As Integer
        Get
            Return cajachica
        End Get
        Set(value As Integer)
            cajachica = value
        End Set
    End Property

    Private comisiones As Boolean
    Public Property PComisiones As Boolean
        Get
            Return comisiones
        End Get
        Set(value As Boolean)
            comisiones = value
        End Set
    End Property

    Private descuentoinfonavit As Double
    Public Property PDescuentoInfonavit As Double
        Get
            Return descuentoinfonavit
        End Get
        Set(value As Double)
            descuentoinfonavit = value
        End Set
    End Property

    Private porcentajeasistencia As Double
    Public Property PPorcentajeAsistencia As Double
        Get
            Return porcentajeasistencia
        End Get
        Set(value As Double)
            porcentajeasistencia = value
        End Set
    End Property

    Private porcentajepuntualidad As Double
    Public Property PPorcentajePuntualidad As Double
        Get
            Return porcentajepuntualidad
        End Get
        Set(value As Double)
            porcentajepuntualidad = value
        End Set
    End Property

    Private clavesegurdidadsocial As String
    Public Property PClaveSeguridadSocial As String
        Get
            Return clavesegurdidadsocial
        End Get
        Set(value As String)
            clavesegurdidadsocial = value
        End Set
    End Property

    Private claveretirocesantia As String
    Public Property PClaveRetiroCesantia As String
        Get
            Return claveretirocesantia
        End Get
        Set(value As String)
            claveretirocesantia = value
        End Set
    End Property

    Private claveISR As String
    Public Property PClaveISR As String
        Get
            Return claveISR
        End Get
        Set(value As String)
            claveISR = value
        End Set
    End Property

    Private claveInfonavit As String
    Public Property PClaveInfonavit As String
        Get
            Return claveInfonavit
        End Get
        Set(value As String)
            claveInfonavit = value
        End Set
    End Property

    Private claveSPE As String
    Public Property PClaveSPE As String
        Get
            Return claveSPE
        End Get
        Set(value As String)
            claveSPE = value
        End Set
    End Property

    Private claveISRAguinaldoVacaciones As String
    Public Property PClaveISRAguinaldoVacaciones As String
        Get
            Return claveISRAguinaldoVacaciones
        End Get
        Set(value As String)
            claveISRAguinaldoVacaciones = value
        End Set
    End Property

    Private claveISRAnual As String
    Public Property PClaveISRAnual As String
        Get
            Return claveISRAnual
        End Get
        Set(value As String)
            claveISRAnual = value
        End Set
    End Property

    Private claveSPEAnual As String
    Public Property PClaveSPEAnual As String
        Get
            Return claveSPEAnual
        End Get
        Set(value As String)
            claveSPEAnual = value
        End Set
    End Property

    Private clavePercepcionACargoAnual As String
    Public Property PClavePercepcionACargoAnual As String
        Get
            Return clavePercepcionACargoAnual
        End Get
        Set(value As String)
            clavePercepcionACargoAnual = value
        End Set
    End Property

    Private claveComisiones As String
    Public Property PClaveComisiones As String
        Get
            Return claveComisiones
        End Get
        Set(value As String)
            claveComisiones = value
        End Set
    End Property

    Private agrupado As Boolean
    Public Property PAgrupado As Boolean
        Get
            Return agrupado
        End Get
        Set(value As Boolean)
            agrupado = value
        End Set
    End Property

    Private patrongrupo As Integer
    Public Property PPatronGrupo As Integer
        Get
            Return patrongrupo
        End Get
        Set(value As Integer)
            patrongrupo = value
        End Set
    End Property

End Class
