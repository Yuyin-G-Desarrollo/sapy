Public Class Finiquitos

    Private Finiquitoid As Int32
    Private ColaboradorId As Colaborador
    Private NombreColaborador As Colaborador
    Private FechaIngreso As ColaboradorReal
    Private MotivoFiniquitoId As MotivosFiniquito
    Private Justificacion As String
    Private FechaBaja As Date
    Private AntiguedadDias As Int32
    Private AntiguedadMeses As Int32
    Private AntiguedadAnios As Int32
    Private SueldoSemana1 As Double
    Private SueldoSemana2 As Double
    Private SueldoSemana3 As Double
    Private SueldoSemana4 As Double
    Private Salario As Double
    Private SalarioDiario As Double
    Private MesesAguinaldo As Double
    Private DiasAguinaldo As Double
    Private TotalAguinaldo As Double
    Private MesesVacaciones As Double
    Private DiasVacaciones As Double
    Private TotalVacaciones As Double
    Private TotalFiniquito As Double
    Private Ahorro As Double
    Private Utilidades As Double
    Private Gratificacion As Double
    Private Subtotal As Double
    Private Prestamo As Double
    Private TotalEntregar As Double
    Private Estado As String
    Private UsuarioCreoID As Int32
    Private FechaAutorizacion As Date
    Private FechaSolicito As Date
    Private UsuarioAutorizo As Int32
    Private VoBo As Int32
    Private VoBoFecha As Date
    Private PrimaVacacional As Double
    Private DiasSegunAntiguedad As Int32
    Private NaveId As Int32
    Private SueldoDiasTrabajados As Double
    Private noRecontratar As Boolean
    Private Extras As Double
    Private UtilidadesAnterior As Double
    Private AnioUtilidades As Int32
    Private AnioUtilidadesAnterior As Int32

    Public Property PSueldoDiasTrabajados As Double
        Get
            Return SueldoDiasTrabajados
        End Get
        Set(ByVal value As Double)
            SueldoDiasTrabajados = value
        End Set
    End Property

    Public Property PNaveID As Int32
        Get
            Return NaveId
        End Get
        Set(ByVal value As Int32)
            NaveId = value
        End Set
    End Property

    Public Property PPrimaVacacional As Double
        Get
            Return PrimaVacacional
        End Get
        Set(ByVal value As Double)
            PrimaVacacional = value
        End Set
    End Property

    Public Property PDiasSegunAntiguedad As Int32
        Get
            Return DiasSegunAntiguedad
        End Get
        Set(ByVal value As Int32)
            DiasSegunAntiguedad = value
        End Set
    End Property



    Public Property PVoBoFecha As Date
        Get
            Return VoBoFecha
        End Get
        Set(ByVal value As Date)
            VoBoFecha = value
        End Set
    End Property

    Public Property PVoBo As Int32
        Get
            Return VoBo
        End Get
        Set(ByVal value As Int32)
            VoBo = value
        End Set
    End Property

    Public Property PUsuarioAutorizo As Int32
        Get
            Return UsuarioAutorizo
        End Get
        Set(ByVal value As Int32)
            UsuarioAutorizo = value
        End Set
    End Property

    Public Property PUsuarioSolicito As Int32
        Get
            Return UsuarioAutorizo
        End Get
        Set(ByVal value As Int32)
            UsuarioAutorizo = value
        End Set
    End Property

    Public Property PFechaSolicitud As Date
        Get
            Return FechaSolicito
        End Get
        Set(ByVal value As Date)
            FechaSolicito = value
        End Set
    End Property

    Public Property PFechaAutorizacion As Date
        Get
            Return FechaAutorizacion
        End Get
        Set(ByVal value As Date)
            FechaAutorizacion = value
        End Set
    End Property


    Private Property PFechaIngreso As ColaboradorReal
        Get
            Return FechaIngreso
        End Get
        Set(ByVal value As ColaboradorReal)
            FechaIngreso = value
        End Set
    End Property

    Private Property PNombreColaborador As Colaborador
        Get
            Return NombreColaborador
        End Get
        Set(ByVal value As Colaborador)
            NombreColaborador = value
        End Set
    End Property

    Public Property PFiniquito As Int32
        Get
            Return Finiquitoid
        End Get
        Set(ByVal value As Int32)
            Finiquitoid = value
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
    Public Property PMotivoFiniquitoId As MotivosFiniquito
        Get
            Return MotivoFiniquitoId
        End Get
        Set(ByVal value As MotivosFiniquito)
            MotivoFiniquitoId = value
        End Set
    End Property

    Public Property PJustificacion As String
        Get
            Return Justificacion
        End Get
        Set(ByVal value As String)
            Justificacion = value
        End Set
    End Property

    Public Property PFechaBaja As Date
        Get
            Return FechaBaja
        End Get
        Set(ByVal value As Date)
            FechaBaja = value
        End Set
    End Property
    Public Property PAntiguedadDias As Int32
        Get
            Return AntiguedadDias
        End Get
        Set(ByVal value As Int32)
            AntiguedadDias = value
        End Set
    End Property

    Public Property PAntiguedadMeses As Int32
        Get
            Return AntiguedadMeses
        End Get
        Set(ByVal value As Int32)
            AntiguedadMeses = value
        End Set
    End Property

    Public Property PAntiguedadAnios As Int32
        Get
            Return AntiguedadAnios
        End Get
        Set(ByVal value As Int32)
            AntiguedadAnios = value
        End Set
    End Property

    Public Property PSemana1 As Double
        Get
            Return SueldoSemana1
        End Get
        Set(ByVal value As Double)
            SueldoSemana1 = value
        End Set
    End Property

    Public Property PSemana2 As Double
        Get
            Return SueldoSemana2
        End Get
        Set(ByVal value As Double)
            SueldoSemana2 = value
        End Set
    End Property

    Public Property PSemana3 As Double
        Get
            Return SueldoSemana3
        End Get
        Set(ByVal value As Double)
            SueldoSemana3 = value
        End Set
    End Property

    Public Property PSemana4 As Double
        Get
            Return SueldoSemana4
        End Get
        Set(ByVal value As Double)
            SueldoSemana4 = value
        End Set
    End Property

    Public Property PSalario As Double
        Get
            Return Salario
        End Get
        Set(ByVal value As Double)
            Salario = value
        End Set
    End Property

    Public Property PSalarioDiario As Double
        Get
            Return SalarioDiario
        End Get
        Set(ByVal value As Double)
            SalarioDiario = value
        End Set
    End Property



    Public Property PMesesAguinaldo As Double
        Get
            Return MesesAguinaldo
        End Get
        Set(ByVal value As Double)
            MesesAguinaldo = value
        End Set
    End Property

    Public Property PDiasAguinaldo As Double
        Get
            Return DiasAguinaldo
        End Get
        Set(ByVal value As Double)
            DiasAguinaldo = value
        End Set
    End Property

    Public Property PTotalAguinaldo As Double
        Get
            Return TotalAguinaldo
        End Get
        Set(ByVal value As Double)
            TotalAguinaldo = value
        End Set
    End Property

    Public Property PMesesVacaciones As Double
        Get
            Return MesesVacaciones
        End Get
        Set(ByVal value As Double)
            MesesVacaciones = value
        End Set
    End Property

    Public Property PDiasVacaciones As Double
        Get
            Return DiasVacaciones
        End Get
        Set(ByVal value As Double)
            DiasVacaciones = value
        End Set
    End Property

    Public Property PTotalVacaciones As Double
        Get
            Return TotalVacaciones
        End Get
        Set(ByVal value As Double)
            TotalVacaciones = value
        End Set
    End Property

    Public Property PTotalFiniquito As Double
        Get
            Return TotalFiniquito
        End Get
        Set(ByVal value As Double)
            TotalFiniquito = value
        End Set
    End Property

    Public Property PAhorro As Double
        Get
            Return Ahorro
        End Get
        Set(ByVal value As Double)
            Ahorro = value
        End Set
    End Property

    Public Property PUtilidades As Double
        Get
            Return Utilidades
        End Get
        Set(ByVal value As Double)
            Utilidades = value
        End Set
    End Property

    Public Property PGratificacion As Double
        Get
            Return Gratificacion
        End Get
        Set(ByVal value As Double)
            Gratificacion = value
        End Set
    End Property

    Public Property PSubtotal As Double
        Get
            Return Subtotal
        End Get
        Set(ByVal value As Double)
            Subtotal = value
        End Set
    End Property

    Public Property PPrestamo As Double
        Get
            Return Prestamo
        End Get
        Set(ByVal value As Double)
            Prestamo = value
        End Set
    End Property

    Public Property PTotalEntregar As Double
        Get
            Return TotalEntregar
        End Get
        Set(ByVal value As Double)
            TotalEntregar = value
        End Set
    End Property

    Public Property PUsuarioCreoId As Int32
        Get
            Return UsuarioCreoID
        End Get
        Set(ByVal value As Int32)
            UsuarioCreoID = value
        End Set
    End Property

    Public Property PEstado As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property

    Public Property PnoRecontratar As Boolean
        Get
            Return noRecontratar
        End Get
        Set(value As Boolean)
            noRecontratar = value
        End Set
    End Property

    Public Property PExtras As Double
        Get
            Return Extras
        End Get
        Set(value As Double)
            Extras = value
        End Set
    End Property

    Public Property PUtilidadesAnterior As Double
        Get
            Return UtilidadesAnterior
        End Get
        Set(value As Double)
            UtilidadesAnterior = value
        End Set
    End Property

    Public Property PAnioUtilidades As Int32
        Get
            Return AnioUtilidades
        End Get
        Set(value As Int32)
            AnioUtilidades = value
        End Set
    End Property

    Public Property PAnioUtilidadesAnterior As Int32
        Get
            Return AnioUtilidadesAnterior
        End Get
        Set(value As Int32)
            AnioUtilidadesAnterior = value
        End Set
    End Property

End Class
