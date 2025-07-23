Public Class DeduccionRealImss

	Public DeduccionImssID As Int32
	Public LimiteSuperior As Double
	Public LimiteInferior As Double
	Public Cantidad As Double
	Public Property PDeduccionImssID As Int32
		Get
			Return DeduccionImssID
		End Get
		Set(value As Int32)
			DeduccionImssID = value
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
	Public Property PLimiteInferior As Double
		Get
			Return LimiteInferior
		End Get
		Set(value As Double)
			LimiteInferior = value
		End Set
	End Property

	Public Property PCantidad As Double
		Get
			Return Cantidad
		End Get
		Set(value As Double)
			Cantidad = value
		End Set
	End Property

End Class
