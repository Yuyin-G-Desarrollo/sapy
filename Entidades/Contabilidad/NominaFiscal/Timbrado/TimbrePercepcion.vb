Public Class TimbrePercepcion
    Private timbrePercepcionId As Integer
    Public Property TPTimbrePercepcionId() As Integer
        Get
            Return timbrePercepcionId
        End Get
        Set(ByVal value As Integer)
            timbrePercepcionId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property TPTimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private tipoPercepcion As String
    Public Property TPTipoPercepcion() As String
        Get
            Return tipoPercepcion
        End Get
        Set(ByVal value As String)
            tipoPercepcion = value
        End Set
    End Property

    Private clavePercepcion As String
    Public Property TPClavePercepcion() As String
        Get
            Return clavePercepcion
        End Get
        Set(ByVal value As String)
            clavePercepcion = value
        End Set
    End Property

    Private conceptoPercepcion As String
    Public Property TPConceptoPercepcion() As String
        Get
            Return conceptoPercepcion
        End Get
        Set(ByVal value As String)
            conceptoPercepcion = value
        End Set
    End Property

    Private importeGravadoPercepcion As Double
    Public Property TPImporteGravadoPercepcion() As Double
        Get
            Return importeGravadoPercepcion
        End Get
        Set(ByVal value As Double)
            importeGravadoPercepcion = value
        End Set
    End Property

    Private importeExentoPercepcion As Double
    Public Property TPImporteExentoPercepcion() As Double
        Get
            Return importeExentoPercepcion
        End Get
        Set(ByVal value As Double)
            importeExentoPercepcion = value
        End Set
    End Property
End Class
