Public Class TimbreDeduccion
    Private timbreDeduccionId As Integer
    Public Property TDTimbreDeduccionId() As Integer
        Get
            Return timbreDeduccionId
        End Get
        Set(ByVal value As Integer)
            timbreDeduccionId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property TDTimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private tipoDeduccion As String
    Public Property TDTipoDeduccion() As String
        Get
            Return tipoDeduccion
        End Get
        Set(ByVal value As String)
            tipoDeduccion = value
        End Set
    End Property

    Private claveDeduccion As String
    Public Property TDClaveDeduccion() As String
        Get
            Return claveDeduccion
        End Get
        Set(ByVal value As String)
            claveDeduccion = value
        End Set
    End Property

    Private conceptoDeduccion As String
    Public Property TDConceptoDeduccion() As String
        Get
            Return conceptoDeduccion
        End Get
        Set(ByVal value As String)
            conceptoDeduccion = value
        End Set
    End Property

    Private importeDeduccion As Double
    Public Property TFImporteDeduccion() As Double
        Get
            Return importeDeduccion
        End Get
        Set(ByVal value As Double)
            importeDeduccion = value
        End Set
    End Property
End Class
