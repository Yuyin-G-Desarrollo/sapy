Public Class FiniquitoRetencionISR
    Inherits FiniquitoRetencionUSMO


    Private PBaseGravable As Double
    Public Property BaseGravable() As Double
        Get
            Return PBaseGravable
        End Get
        Set(ByVal value As Double)
            PBaseGravable = value
        End Set
    End Property


    Private PBaseImpuesto As Double
    Public Property BaseImpuesto() As Double
        Get
            Return PBaseImpuesto
        End Get
        Set(ByVal value As Double)
            PBaseImpuesto = value
        End Set
    End Property

    Private PImpuestoRetenido As Double
    Public Property ImpuestoRetenido() As Double
        Get
            Return PImpuestoRetenido
        End Get
        Set(ByVal value As Double)
            PImpuestoRetenido = value
        End Set
    End Property


End Class
