Public Class ModificacionSalarioMixto

    Private modificacionSalarioId As Integer
    Public Property MDID() As Integer
        Get
            Return modificacionSalarioId
        End Get
        Set(ByVal value As Integer)
            modificacionSalarioId = value
        End Set
    End Property

    Private colaboradorId As Integer
    Public Property PColaboradorId As Integer
        Get
            Return colaboradorId
        End Get
        Set(value As Integer)
            colaboradorId = value
        End Set
    End Property

    Private nombrecolaborador As String
    Public Property PNombreColaborador As String
        Get
            Return nombrecolaborador
        End Get
        Set(value As String)
            nombrecolaborador = value
        End Set
    End Property

    Private departamento As String
    Public Property PDepartamento As String
        Get
            Return departamento
        End Get
        Set(value As String)
            departamento = value
        End Set
    End Property

    Private puesto As String
    Public Property PPuesto As String
        Get
            Return puesto
        End Get
        Set(value As String)
            puesto = value
        End Set
    End Property

    Private fechaingreso As Date
    Public Property PFechaIngreso As Date
        Get
            Return fechaingreso
        End Get
        Set(value As Date)
            fechaingreso = value
        End Set
    End Property

    Private antiguedad As String
    Public Property PAntiguedad As String
        Get
            Return antiguedad
        End Get
        Set(value As String)
            antiguedad = value
        End Set
    End Property

    Private numss As String
    Public Property PNumSS As String
        Get
            Return numss
        End Get
        Set(value As String)
            numss = value
        End Set
    End Property

    Private bimestre As Integer
    Public Property PBimestre As Integer
        Get
            Return bimestre
        End Get
        Set(value As Integer)
            bimestre = value
        End Set
    End Property

    Private sdifijo As Double
    Public Property PSDIFijo As Double
        Get
            Return sdifijo
        End Get
        Set(value As Double)
            sdifijo = value
        End Set
    End Property

    Private comisiones As Double
    Public Property PComisiones As Double
        Get
            Return comisiones
        End Get
        Set(value As Double)
            comisiones = value
        End Set
    End Property

    Private diaspagados As Double
    Public Property PDiasPagados As Double
        Get
            Return diaspagados
        End Get
        Set(value As Double)
            diaspagados = value
        End Set
    End Property

    Private sdivariable As Double
    Public Property PSDIVariable As Double
        Get
            Return sdivariable
        End Get
        Set(value As Double)
            sdivariable = value
        End Set
    End Property

    Private sdineto As Double
    Public Property PSDINeto As Double
        Get
            Return sdineto
        End Get
        Set(value As Double)
            sdineto = value
        End Set
    End Property

    Private fechamovimiento As Date
    Public Property PFechaMovimiento As Date
        Get
            Return fechamovimiento
        End Get
        Set(value As Date)
            fechamovimiento = value
        End Set
    End Property

    Private imssdiario As Double
    Public Property PIMSSDiario As Double
        Get
            Return imssdiario
        End Get
        Set(value As Double)
            imssdiario = value
        End Set
    End Property

    Private imsssemanal As Double
    Public Property PIMSSSemanal As Double
        Get
            Return imsssemanal
        End Get
        Set(value As Double)
            imsssemanal = value
        End Set
    End Property
End Class
