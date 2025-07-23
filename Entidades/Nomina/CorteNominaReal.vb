Public Class CorteNominaReal
    Private colaborador As Colaborador
    Private cobranza As CobranzaPrestamos
    Private Nomina As CalcularNominaReal
    Private Deducciones As Deducciones
    Private Percepciones As Percepciones
    Private TotalEntregar As Double
    Private Nave As Naves
    Private Ausentismos As Double
    Private TipoPago As String
    Private TipoSueldo As String
    Private incapacidad As Double


    Public Property pAusentismos As Double
        Get
            Return Ausentismos
        End Get
        Set(value As Double)
            Ausentismos = value
        End Set
    End Property


    Public Property PNave As Naves
        Get
            Return Nave
        End Get
        Set(ByVal value As Naves)
            Nave = value
        End Set
    End Property

    Public Property PPercepciones As Percepciones
        Get
            Return Percepciones
        End Get
        Set(ByVal value As Percepciones)
            Percepciones = value
        End Set
    End Property


    Public Property PDeducciones As Deducciones
        Get
            Return Deducciones
        End Get
        Set(ByVal value As Deducciones)
            Deducciones = value
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


    Public Property Pcolaborador As Colaborador
        Get
            Return colaborador
        End Get
        Set(ByVal value As Colaborador)
            colaborador = value
        End Set
    End Property


    Public Property Pcobranza As CobranzaPrestamos
        Get
            Return cobranza
        End Get
        Set(ByVal value As CobranzaPrestamos)
            cobranza = value
        End Set
    End Property

    Public Property PNomina As CalcularNominaReal
        Get
            Return Nomina
        End Get
        Set(ByVal value As CalcularNominaReal)
            Nomina = value
        End Set
    End Property


    Public Property PTipoPago As String
        Get
            Return TipoPago
        End Get
        Set(ByVal value As String)
            TipoPago = value
        End Set
    End Property

    Public Property PTipoSueldo As String
        Get
            Return TipoSueldo
        End Get
        Set(ByVal value As String)
            TipoSueldo = value
        End Set
    End Property

    Public Property PIncapacidad As Double
        Get
            Return incapacidad
        End Get
        Set(value As Double)
            incapacidad = value
        End Set
    End Property

End Class
