Public Class RangoSubsidioEmpleo
	Public LimiteInferior As Double
	Public LimiteSuperior As Double
	Public Valor As Double
	Public SubsidioID As Int32

	Public Property PLimiteInferior As Double
		Get
			Return LimiteInferior
		End Get
		Set(value As Double)
			LimiteInferior = value
		End Set
	End Property
	Public Property PLimiteSuperior As Double
		Get
			Return LimiteSuperior
		End Get
		Set(value As Double)
			LimiteSuperior = value
		End Set
	End Property
	Public Property PValor As Double
		Get
			Return Valor
		End Get
		Set(value As Double)
			Valor = value
		End Set
	End Property
	Public Property PSubsidioID As Int32
		Get
			Return SubsidioID
		End Get
		Set(value As Int32)
			SubsidioID = value
		End Set
	End Property


End Class
