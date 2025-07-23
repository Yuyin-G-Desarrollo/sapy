Public Class Incapacidades

#Region "ATRIBUTOS"
    ''TARJETA INCAPACIDAD ID
    Private TarjetaIncapacidadID As Integer
    ''INCIDENCIAS NP
    Private incidenciaDescripcionNP As String
    Private incidenciaIDNP As Integer
    ''COLABORADOR
    Private Colaborador As Entidades.Colaborador

    ''RAMO SEGURO
    Private RamoSeguroID As Integer
    Private RamoSeguroDescripcion As String
    Private RamoDelSeguroNP As String

    ''TIPO RIESGO
    Private TipoRiesgoID As Integer
    Private TipoRiesgoDescripcion As String
    Private TipoRiesgoNP As String

    ''CONTROL INCAPACIDAD
    Private ControlIncapacidadID As Integer
    Private ControlIncapacidadIDNP As Integer
    Private ControlIncapacidadDescripcion As String

    ''SECUELA O CONSECUENCIA
    Private SecuelaID As Integer
    Private SecuelaIDNP As Integer
    Private SecuelaDescripcion As String

    ''TIPO MARTERNIDAD
    Private TipoMaternidadID As Integer
    Private TipoMaternidadDescripcion As String
    Private TIpoMaternidadNP As String

    ''DATOS DE LA INCAPACIDAD
    Private IncapacidadID As Integer
    Private IncapacidadFolio As String
    Private IncapacidadFechaInicio As Date
    Private IncapacidadFechaFin As Date
    Private IncapacidadDiasAutorizados As Integer
    Private IncapacidadDescripcion As String
    Private IncapacidadNominpaq As Boolean
    Private IncapacidadPeriodo As Integer

    ''DATOS USUARIO
    Private UsuarioCreacion As Integer
    Private UsuarioModificacion As Integer

    ''DATOS FECHAS
    Private FechaCreacion As DateTime
    Private FechaModificacion As DateTime

    ''VALIDAR INCAPACIDADES
    Private ValidarIncapacidad As Boolean
#End Region

    'Nominpaq



#Region "GET-SET"
    ''TARJETA INCAPACIDAD ID
    Public Property PTarjetaIncapacidadID As Integer
        Get
            Return TarjetaIncapacidadID
        End Get
        Set(value As Integer)
            TarjetaIncapacidadID = value
        End Set
    End Property

    ''TIPO INCIDENCIAS NP
    Public Property PIncidenciaDescripcionNP As String
        Get
            Return incidenciaDescripcionNP
        End Get
        Set(value As String)
            incidenciaDescripcionNP = value
        End Set
    End Property

    Public Property PIncidenciaIDNP As Integer
        Get
            Return incidenciaIDNP
        End Get
        Set(value As Integer)
            incidenciaIDNP = value
        End Set
    End Property

    ''COLABORADOR
    Public Property PColaborador As Entidades.Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Entidades.Colaborador)
            Colaborador = value
        End Set
    End Property

    ''RAMO SEGURO
    Public Property PRamoSeguroID As Integer
        Get
            Return RamoSeguroID
        End Get
        Set(value As Integer)
            RamoSeguroID = value
        End Set
    End Property

    Public Property PRamoSeguroDescripcion As String
        Get
            Return RamoSeguroDescripcion
        End Get
        Set(value As String)
            RamoSeguroDescripcion = value
        End Set
    End Property

    Public Property PRamoDelSeguroNP As String
        Get
            Return RamoDelSeguroNP
        End Get
        Set(value As String)
            RamoDelSeguroNP = value
        End Set
    End Property


    ''TIPO RIESGO
    Public Property PTipoRiesgoID As Integer
        Get
            Return TipoRiesgoID
        End Get
        Set(value As Integer)
            TipoRiesgoID = value
        End Set
    End Property

    Public Property PTipoRiesgoDescripcion As String
        Get
            Return TipoRiesgoDescripcion
        End Get
        Set(value As String)
            TipoRiesgoDescripcion = value
        End Set
    End Property

    Public Property PTipoRiesgoNP As String
        Get
            Return TipoRiesgoNP
        End Get
        Set(value As String)
            TipoRiesgoNP = value
        End Set
    End Property



    ''CONTROL INCAPACIDAD
    Public Property PControlIncapacidadIDNP As Integer
        Get
            Return ControlIncapacidadIDNP
        End Get
        Set(value As Integer)
            ControlIncapacidadIDNP = value
        End Set
    End Property

    Public Property PControlIncapacidadID As Integer
        Get
            Return ControlIncapacidadID
        End Get
        Set(value As Integer)
            ControlIncapacidadID = value
        End Set
    End Property

    Public Property PControlIncapacidadDescripcion As String
        Get
            Return ControlIncapacidadDescripcion
        End Get
        Set(value As String)
            ControlIncapacidadDescripcion = value
        End Set
    End Property

    ''SECUELA O CONSECUENCIA
    Public Property PSecuelaID As Integer
        Get
            Return SecuelaID
        End Get
        Set(value As Integer)
            SecuelaID = value
        End Set
    End Property

    Public Property PSecuelaIDNP As Integer
        Get
            Return SecuelaIDNP
        End Get
        Set(value As Integer)
            SecuelaIDNP = value
        End Set
    End Property

    Public Property PSecuelaDescripcion As String
        Get
            Return SecuelaDescripcion
        End Get
        Set(value As String)
            SecuelaDescripcion = value
        End Set
    End Property

    ''TIPO MATERNIDAD
    Public Property PTipoMaternidadID As Integer
        Get
            Return TipoMaternidadID
        End Get
        Set(value As Integer)
            TipoMaternidadID = value
        End Set
    End Property

    Public Property PTipoMaternidadDescripcion As String
        Get
            Return TipoMaternidadDescripcion
        End Get
        Set(value As String)
            TipoMaternidadDescripcion = value
        End Set
    End Property

    Public Property PTipoMaternidadNP As String
        Get
            Return TIpoMaternidadNP
        End Get
        Set(value As String)
            TIpoMaternidadNP = value
        End Set
    End Property
    ''DATOS DE LA INCAPACIDAD
    Public Property PIncapacidadID As Integer
        Get
            Return IncapacidadID
        End Get
        Set(value As Integer)
            IncapacidadID = value
        End Set
    End Property

    Public Property PIncapacidadFolio As String
        Get
            Return IncapacidadFolio
        End Get
        Set(value As String)
            IncapacidadFolio = value
        End Set
    End Property

    Public Property PIncapacidadFechaInicio As Date
        Get
            Return IncapacidadFechaInicio
        End Get
        Set(value As Date)
            IncapacidadFechaInicio = value
        End Set
    End Property

    Public Property PIncapacidadFechaFin As Date
        Get
            Return IncapacidadFechaFin
        End Get
        Set(value As Date)
            IncapacidadFechaFin = value
        End Set
    End Property

    Public Property PIncapacidadDiasAutorizados As Integer
        Get
            Return IncapacidadDiasAutorizados
        End Get
        Set(value As Integer)
            IncapacidadDiasAutorizados = value
        End Set
    End Property

    Public Property PIncapacidadDescripcion As String
        Get
            Return IncapacidadDescripcion
        End Get
        Set(value As String)
            IncapacidadDescripcion = value
        End Set
    End Property

    Public Property PIncapacidadNominpaq As Boolean
        Get
            Return IncapacidadNominpaq
        End Get
        Set(value As Boolean)
            IncapacidadNominpaq = value
        End Set
    End Property

    Public Property PIncapacidadPeriodo As Integer
        Get
            Return IncapacidadPeriodo
        End Get
        Set(value As Integer)
            IncapacidadPeriodo = value
        End Set
    End Property


    ''DATOS USUARIO
    Public Property PUsuarioCreacion As Integer
        Get
            Return UsuarioCreacion
        End Get
        Set(value As Integer)
            UsuarioCreacion = value
        End Set
    End Property

    Public Property PUsuarioModificacion As Integer
        Get
            Return UsuarioModificacion
        End Get
        Set(value As Integer)
            UsuarioModificacion = value
        End Set
    End Property

    ''DATOS FECHAS
    Public Property PFechaCreacion As DateTime
        Get
            Return FechaCreacion
        End Get
        Set(value As DateTime)
            FechaCreacion = value
        End Set
    End Property

    Public Property PFechaModificacion As DateTime
        Get
            Return FechaModificacion
        End Get
        Set(value As DateTime)
            FechaModificacion = value
        End Set
    End Property

    ''Validar incapacidad
    Public Property PValidarIncapacidad As Boolean
        Get
            Return ValidarIncapacidad
        End Get
        Set(value As Boolean)
            ValidarIncapacidad = value
        End Set
    End Property

#End Region

    Private aceptadoRiesgoTrabajdo As Boolean
    Public Property PAceptadoRT() As Boolean
        Get
            Return aceptadoRiesgoTrabajdo
        End Get
        Set(ByVal value As Boolean)
            aceptadoRiesgoTrabajdo = value
        End Set
    End Property

    Private incapacidadAnteriorId As Int32
    Public Property PIncapacidadAnteirorId() As Int32
        Get
            Return incapacidadAnteriorId
        End Get
        Set(ByVal value As Int32)
            incapacidadAnteriorId = value
        End Set
    End Property

    Private cartaIncapacidad As Boolean
    Public Property PCartaIncapacidad() As Boolean
        Get
            Return cartaIncapacidad
        End Get
        Set(ByVal value As Boolean)
            cartaIncapacidad = value
        End Set
    End Property

    Private formatost7 As Boolean
    Public Property PFormatost7() As Boolean
        Get
            Return formatost7
        End Get
        Set(ByVal value As Boolean)
            formatost7 = value
        End Set
    End Property

    Private formatost2 As Boolean
    Public Property PFormatoSt2() As Boolean
        Get
            Return formatost2
        End Get
        Set(ByVal value As Boolean)
            formatost2 = value
        End Set
    End Property

    Private estatusId As Int32
    Public Property PEstatusId() As Int32
        Get
            Return estatusId
        End Get
        Set(ByVal value As Int32)
            estatusId = value
        End Set
    End Property

    Private validaModificacion As Boolean
    Public Property PValidaModificacion() As Boolean
        Get
            Return validaModificacion
        End Get
        Set(ByVal value As Boolean)
            validaModificacion = value
        End Set
    End Property

    Private validaInicial As Boolean
    Public Property PValidaInicial() As Boolean
        Get
            Return validaInicial
        End Get
        Set(ByVal value As Boolean)
            validaInicial = value
        End Set
    End Property


End Class
