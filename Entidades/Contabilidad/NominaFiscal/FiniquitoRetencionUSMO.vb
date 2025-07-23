

Public Class FiniquitoRetencionUSMO


    Private PTarifaMensualID As Integer
    Public Property TarifaMensualID() As Integer
        Get
            Return PTarifaMensualID
        End Get
        Set(ByVal value As Integer)
            PTarifaMensualID = value
        End Set
    End Property

    Private PUltimoSueldoMensualOrdinario As Double
    Public Property UltimoSueldoMensualOrdinario() As Double
        Get
            Return PUltimoSueldoMensualOrdinario
        End Get
        Set(ByVal value As Double)
            PUltimoSueldoMensualOrdinario = value
        End Set
    End Property

    Private PLimiteInferior As Double
    Public Property LimiteInferior() As Double
        Get
            Return PLimiteInferior
        End Get
        Set(ByVal value As Double)
            PLimiteInferior = value
        End Set
    End Property

    Private PExcedenteLimiteInferior As Double
    Public Property ExcedenteLimiteInferior() As Double
        Get
            Return PExcedenteLimiteInferior
        End Get
        Set(ByVal value As Double)
            PExcedenteLimiteInferior = value
        End Set
    End Property


    Private PPorcentajeLimiteInferior As Double
    Public Property PorcentajeLimiteInferior() As Double
        Get
            Return PPorcentajeLimiteInferior
        End Get
        Set(ByVal value As Double)
            PPorcentajeLimiteInferior = value
        End Set
    End Property


    Private PImpuestoMarginal As Double
    Public Property ImpuestoMarginal() As Double
        Get
            Return PImpuestoMarginal
        End Get
        Set(ByVal value As Double)
            PImpuestoMarginal = value
        End Set
    End Property


    Private PCuotaFija As Double
    Public Property CuotaFija() As Double
        Get
            Return PCuotaFija
        End Get
        Set(ByVal value As Double)
            PCuotaFija = value
        End Set
    End Property

    Private PImpuestoDeterminado As Double
    Public Property ImpuestoDeterminado() As Double
        Get
            Return PImpuestoDeterminado
        End Get
        Set(ByVal value As Double)
            PImpuestoDeterminado = value
        End Set
    End Property


    Private PSubsidioEmpleo As Double
    Public Property SubsidioEmpleo() As Double
        Get
            Return PSubsidioEmpleo
        End Get
        Set(ByVal value As Double)
            PSubsidioEmpleo = value
        End Set
    End Property

    Private PRentencionUSMO As Double
    Public Property RentencionUSMO() As Double
        Get
            Return PRentencionUSMO
        End Get
        Set(ByVal value As Double)
            PRentencionUSMO = value
        End Set
    End Property



End Class
