Public Class ColaboradorLaboral

    Private ColaboradorLaboralId As Int32
    Private ColaboradorId As Colaborador
    Private DepartamentoId As Departamentos
    Private NaveId As Naves
    Private HorarioId As Horarios
    Private Horario2Id As Horarios
    Private PuestoId As Puestos
    Private CelulaId As Celulas
    Private AreaID As Int32
    Private NIP As Int32
    Private GeneraHorasExtras As Boolean
    Private Checa As Boolean
    Private Reporte As Boolean
    Private GanaIncentivos As Boolean
    Private HuellaExterno As Int32

    Public Property PGanaIncentivos As Boolean
        Get
            Return GanaIncentivos
        End Get
        Set(ByVal value As Boolean)
            GanaIncentivos = value
        End Set
    End Property

    Public Property PCheca As Boolean
        Get
            Return Checa
        End Get
        Set(ByVal value As Boolean)
            Checa = value
        End Set
    End Property

    Public Property PReporte As Boolean
        Get
            Return Reporte
        End Get
        Set(ByVal value As Boolean)
            Reporte = value
        End Set
    End Property

    Public Property PNIP As Int32
        Get
            Return NIP
        End Get
        Set(ByVal value As Int32)
            NIP = value
        End Set
    End Property

    Public Property PGeneraHorasExtras As Boolean
        Get
            Return GeneraHorasExtras
        End Get
        Set(ByVal value As Boolean)
            GeneraHorasExtras = value
        End Set
    End Property

    Public Property PAreaID As Int32
        Get
            Return AreaID
        End Get
        Set(ByVal value As Int32)
            AreaID = value
        End Set
    End Property

    Public Property PColaboradorLaboralId As Int32
        Get
            Return ColaboradorLaboralId
        End Get
        Set(ByVal value As Int32)
            ColaboradorLaboralId = value
        End Set
    End Property
    Public Property PColaboradorId As Colaborador
        Get
            Return ColaboradorId
        End Get
        Set(ByVal value As Colaborador)
            ColaboradorId = value
        End Set
    End Property
    Public Property PDepartamentoId As Departamentos
        Get
            Return DepartamentoId
        End Get
        Set(ByVal value As Departamentos)
            DepartamentoId = value
        End Set
    End Property
    Public Property PNaveId As Naves
        Get
            Return NaveId
        End Get
        Set(ByVal value As Naves)
            NaveId = value
        End Set
    End Property
    Public Property PHorarioId As Horarios
        Get
            Return HorarioId
        End Get
        Set(ByVal value As Horarios)
            HorarioId = value
        End Set
    End Property
    Public Property PHorario2Id As Horarios
        Get
            Return Horario2Id
        End Get
        Set(ByVal value As Horarios)
            Horario2Id = value
        End Set
    End Property
    Public Property PPuestoId As Puestos
        Get
            Return PuestoId
        End Get
        Set(ByVal value As Puestos)
            PuestoId = value
        End Set
    End Property
    Public Property PCelula As Celulas
        Get
            Return CelulaId
        End Get
        Set(ByVal value As Celulas)
            CelulaId = value
        End Set
    End Property

    Private telfono_ As String
    Public Property telefono() As String
        Get
            Return telfono_
        End Get
        Set(ByVal value As String)
            telfono_ = value
        End Set
    End Property

    Private extencion_ As String
    Public Property extencion() As String
        Get
            Return extencion_
        End Get
        Set(ByVal value As String)
            extencion_ = value
        End Set
    End Property

    Private emailLaboral_ As String
    Public Property emailLaboral() As String
        Get
            Return emailLaboral_
        End Get
        Set(ByVal value As String)
            emailLaboral_ = value
        End Set
    End Property

    Private jefeInmediato_ As String
    Public Property jefeInmediato() As String
        Get
            Return jefeInmediato_
        End Get
        Set(ByVal value As String)
            jefeInmediato_ = value
        End Set
    End Property

    Private jefeInmediatoid_ As String
    Public Property jefeInmediatoid() As String
        Get
            Return jefeInmediatoid_
        End Get
        Set(ByVal value As String)
            jefeInmediatoid_ = value
        End Set
    End Property

    Public Property PhuellaExterno() As Integer
        Get
            Return HuellaExterno
        End Get
        Set(ByVal value As Integer)
            HuellaExterno = value
        End Set
    End Property
    Private numLicencia As String
    Public Property PNumLicencia() As String
        Get
            Return numLicencia
        End Get
        Set(ByVal value As String)
            numLicencia = value
        End Set
    End Property
    Private fechaVigencia As Date
    Public Property PFechaVigencia() As Date
        Get
            Return fechaVigencia
        End Get
        Set(ByVal value As Date)
            fechaVigencia = value
        End Set
    End Property
    Private tienelicencia As Boolean
    Public Property PTieneLicencia() As Boolean
        Get
            Return tienelicencia
        End Get
        Set(ByVal value As Boolean)
            tienelicencia = value
        End Set
    End Property
End Class
