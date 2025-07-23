Public Class ImpuestoSubsidioEmpleo
	Public impuestoEmpleoID As Integer
	Public LimiteInferior As Double
	Public LimiteSuperior As Double
	Public CuotaFija As Double
	Public Porcentaje As Double
	Public Property PimpuestoEmpleoID As Integer
		Get
			Return impuestoEmpleoID
		End Get
		Set(value As Integer)
			impuestoEmpleoID = value
		End Set
	End Property
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
	Public Property PCuotaFija As Double
		Get
			Return CuotaFija
		End Get
		Set(value As Double)
			CuotaFija = value
		End Set
	End Property
	Public Property PPorcentaje As Double
		Get
			Return Porcentaje
		End Get
		Set(value As Double)
			Porcentaje = value
		End Set
	End Property
End Class
