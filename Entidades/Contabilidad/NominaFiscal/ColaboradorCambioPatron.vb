Public Class ColaboradorCambioPatron
    Private colaboradorId As Integer
    Private patronOrigenId As Integer
    Private patronDestinoId As Integer
    Private naveOrigenId As Integer
    Private naveDestinoId As Integer
    Private tieneInfonavit As Boolean
    Private fechaBaja As Date
    Private fechaAlta As Date
    Private sdiAlta As Double
    Private deptoFiscal As Integer
    Private puestoFiscal As Integer

    Public Property PColaboradorId As Integer
        Get
            Return colaboradorId
        End Get
        Set(value As Integer)
            colaboradorId = value
        End Set
    End Property

    Public Property PPatronOrigenId As Integer
        Get
            Return patronOrigenId
        End Get
        Set(value As Integer)
            patronOrigenId = value
        End Set
    End Property

    Public Property PPatronDestinoid As Integer
        Get
            Return patronDestinoId
        End Get
        Set(value As Integer)
            patronDestinoId = value
        End Set
    End Property

    Public Property PNaveOrigenId As Integer
        Get
            Return naveOrigenId
        End Get
        Set(value As Integer)
            naveOrigenId = value
        End Set
    End Property

    Public Property PNaveDestinoId As Integer
        Get
            Return naveDestinoId
        End Get
        Set(value As Integer)
            naveDestinoId = value
        End Set
    End Property

    Public Property PTieneInfonavit As Boolean
        Get
            Return tieneInfonavit
        End Get
        Set(value As Boolean)
            tieneInfonavit = value
        End Set
    End Property

    Public Property PFechaBaja As Date
        Get
            Return fechaBaja
        End Get
        Set(value As Date)
            fechaBaja = value
        End Set
    End Property

    Public Property PFechaAlta As Date
        Get
            Return fechaAlta
        End Get
        Set(value As Date)
            fechaAlta = value
        End Set
    End Property

    Public Property PSDIAlta As Double
        Get
            Return sdiAlta
        End Get
        Set(value As Double)
            sdiAlta = value
        End Set
    End Property

    Public Property PDeptoFiscal As Integer
        Get
            Return deptoFiscal
        End Get
        Set(value As Integer)
            deptoFiscal = value
        End Set
    End Property

    Public Property PPuestoFiscal As Integer
        Get
            Return puestoFiscal
        End Get
        Set(value As Integer)
            puestoFiscal = value
        End Set
    End Property

End Class
