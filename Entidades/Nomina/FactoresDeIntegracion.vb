Public Class FactoresDeIntegracion
	Public FactorIntegracionId As Int32
	Public AñosDeServicio As Integer
	Public DiasDeVacaciones As Integer
	Public FactorPrimaVacacional As Double
	Public FactorAguinaldo As Double
	Public FactorIntegracion As Double
	Public Property PFactorIntegracionId As Int32
		Get
			Return FactorIntegracionId
		End Get
		Set(value As Int32)
			FactorIntegracionId = value
		End Set
	End Property
	Public Property PAñosDeServicio As Integer
		Get
			Return AñosDeServicio
		End Get
		Set(value As Integer)
			AñosDeServicio = value
		End Set
	End Property

	Public Property PDiasDeVacaciones As Integer
		Get
			Return DiasDeVacaciones
		End Get
		Set(value As Integer)
			DiasDeVacaciones = value
		End Set
	End Property
	Public Property PFactorPrimaVacacional As Double
		Get
			Return FactorPrimaVacacional
		End Get
		Set(value As Double)
			FactorPrimaVacacional = value
		End Set
	End Property
	Public Property PFactorAguinaldo As Double
		Get
			Return FactorAguinaldo
		End Get
		Set(value As Double)
			FactorAguinaldo = value
		End Set
	End Property
	Public Property PFactorIntegracion As Double
		Get
			Return FactorIntegracion
		End Get
		Set(value As Double)
			FactorIntegracion = value
		End Set
	End Property
End Class
