Public Class CalculoNominaReal
    Private IdColaborador As Integer
    Private MontoInfonavit As Double
    Private NumSS As String
    Private MontoIMSS As Double
    Private NombreColaborador As String
    Private Departamento As String
    Private Puesto As String
    Private Faltas As Double
    Private Incapacidad As Integer
    'Private SalarioReal As Double 'SalarioSemanal
    Private PuntualidadAsistencia As Double
    Private Gratificaciones As Double
    Private MontoAusentismos As Double
    Private Prestamos As Double
    Private CajaDeAhorro As Double
    Private OtrasDeducciones As Double
    Private TotalEntregar As Double 'Para la consulta
    Private SalarioDiario As Double
    Private SalarioSemanal As Double
    Private TipoSueldo As String
    Private IdAnual As Integer
    Private Cuenta As String
    Private CelulaID As Integer
    Private IdDepartamento As Integer
    Private Sexo As String
    Private MontoISR As Double
    Private OrdenPuesto As Integer
    Private ColaboradorTipo As String
    Private ConceptoGratificaciones As String
    Private GratificacionCumple As Double
    Private IdFiniquito As Integer
    Private InteresPrestamo As Double

    Public Property PIdColaborador As Integer
        Get
            Return IdColaborador
        End Get
        Set(value As Integer)
            IdColaborador = value
        End Set
    End Property

    Public Property PMontoInfonavit As Double
        Get
            Return MontoInfonavit
        End Get
        Set(value As Double)
            MontoInfonavit = value
        End Set
    End Property

    Public Property PNumSS As String
        Get
            Return NumSS
        End Get
        Set(value As String)
            NumSS = value
        End Set
    End Property

    Public Property PMontoIMSS As Double
        Get
            Return MontoIMSS
        End Get
        Set(value As Double)
            MontoIMSS = value
        End Set
    End Property

    Public Property PNombreColaborador As String
        Get
            Return NombreColaborador
        End Get
        Set(value As String)
            NombreColaborador = value
        End Set
    End Property

    Public Property PDepartamento As String
        Get
            Return Departamento
        End Get
        Set(value As String)
            Departamento = value
        End Set
    End Property

    'Departamento As String
    Public Property PPuesto As String
        Get
            Return Puesto
        End Get
        Set(value As String)
            Puesto = value
        End Set
    End Property
    'Puesto As String
    Public Property PFaltas As Double
        Get
            Return Faltas
        End Get
        Set(value As Double)
            Faltas = value
        End Set
    End Property
    'Incapacidad As Integer
    Public Property PIncapacidad As Integer
        Get
            Return Incapacidad
        End Get
        Set(value As Integer)
            Incapacidad = value
        End Set
    End Property
    'Faltas As Double
    'Public Property PSalarioReal As Double
    '    Get
    '        Return SalarioReal
    '    End Get
    '    Set(value As Double)
    '        SalarioReal = value
    '    End Set
    'End Property
    'SalarioReal As Double
    Public Property PPuntualidadAsistencia As Double
        Get
            Return PuntualidadAsistencia
        End Get
        Set(value As Double)
            PuntualidadAsistencia = value
        End Set
    End Property
    'PuntualidadAsistencia As Double
    Public Property PGratificaciones As Double
        Get
            Return Gratificaciones
        End Get
        Set(value As Double)
            Gratificaciones = value
        End Set
    End Property
    'Gratificaciones As Double
    Public Property PMontoAusentismos As Double
        Get
            Return MontoAusentismos
        End Get
        Set(value As Double)
            MontoAusentismos = value
        End Set
    End Property
    'MontoAusentismos As Double
    Public Property PPrestamos As Double
        Get
            Return Prestamos
        End Get
        Set(value As Double)
            Prestamos = value
        End Set
    End Property
    'Prestamos As Double
    Public Property PCajaDeAhorro As Double
        Get
            Return CajaDeAhorro
        End Get
        Set(value As Double)
            CajaDeAhorro = value
        End Set
    End Property
    'CajaDeAhorro As Double
    Public Property POtrasDeducciones As Double
        Get
            Return OtrasDeducciones
        End Get
        Set(value As Double)
            OtrasDeducciones = value
        End Set
    End Property
    'OtrasDeducciones As Double
    Public Property Ptotalentregar As Double
        Get
            Return TotalEntregar
        End Get
        Set(value As Double)
            TotalEntregar = value
        End Set
    End Property
    'Totalentregar as double
    Public Property PSalarioDiario As Double
        Get
            Return SalarioDiario
        End Get
        Set(value As Double)
            SalarioDiario = value
        End Set
    End Property
    'SalarioDiario As Double
    Public Property PSalarioSemanal As Double
        Get
            Return SalarioSemanal
        End Get
        Set(value As Double)
            SalarioSemanal = value
        End Set
    End Property
    'SalarioSemanal As Double
    Public Property PTipoSueldo As String
        Get
            Return TipoSueldo
        End Get
        Set(value As String)
            TipoSueldo = value
        End Set
    End Property
    'TipoSueldo As String
    Public Property PIdAnual As Integer
        Get
            Return IdAnual
        End Get
        Set(value As Integer)
            IdAnual = value
        End Set
    End Property
    'IdAnual As Integer
    Public Property PCuenta As String
        Get
            Return Cuenta
        End Get
        Set(value As String)
            Cuenta = value
        End Set
    End Property
    'Cuenta As String
    Public Property PCelulaID As Integer
        Get
            Return CelulaID
        End Get
        Set(value As Integer)
            CelulaID = value
        End Set
    End Property
    'CelulaID As Integer
    Public Property PIdDepartamento As Integer
        Get
            Return IdDepartamento
        End Get
        Set(value As Integer)
            IdDepartamento = value
        End Set
    End Property
    'IdDepartamento As Integer
    Public Property PSexo As String
        Get
            Return Sexo
        End Get
        Set(value As String)
            Sexo = value
        End Set
    End Property
    'Sexo As String
    Public Property PMontoISR As Double
        Get
            Return MontoISR
        End Get
        Set(value As Double)
            MontoISR = value
        End Set
    End Property
    'MontoISR As Double
    Public Property POrdenPuesto As Integer
        Get
            Return OrdenPuesto
        End Get
        Set(value As Integer)
            OrdenPuesto = value
        End Set
    End Property
    'OrdenPuesto As Integer
    Public Property PColaboradorTipo As String
        Get
            Return ColaboradorTipo
        End Get
        Set(value As String)
            ColaboradorTipo = value
        End Set
    End Property
    'ColaboradorTipo As String
    Public Property PConceptoGratificaciones As String
        Get
            Return ConceptoGratificaciones
        End Get
        Set(value As String)
            ConceptoGratificaciones = value
        End Set
    End Property
    'ConceptoGratificaciones As String
    Public Property PGratificacionCumple As Double
        Get
            Return GratificacionCumple
        End Get
        Set(value As Double)
            GratificacionCumple = value
        End Set
    End Property
    'GratificacionCumplea As Double
    Public Property PIdFiniquito As Integer
        Get
            Return IdFiniquito
        End Get
        Set(value As Integer)
            IdFiniquito = value
        End Set
    End Property
    'IdFiniquito As Integer
    Public Property PInteresPrestamo As Double
        Get
            Return InteresPrestamo
        End Get
        Set(value As Double)
            InteresPrestamo = value
        End Set
    End Property

End Class
