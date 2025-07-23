Public Class ExcepcionesHorariosHoras
	Private Horasid As Int32
	Private Tipo As Int32
	Private Horas As Int32
	Private Minutos As Int32
	Private HorarioId As Int32
	Public Property PHorasid As Int32
		Get
			Return Horasid
		End Get
		Set(value As Int32)
			Horasid = value
		End Set
	End Property

	Public Property PTipo As Int32
		Get
			Return Tipo

		End Get
		Set(value As Int32)
			Tipo = value

		End Set

	End Property

	Public Property PHoras As Int32
		Get
			Return Horas

		End Get
		Set(value As Int32)
			Horas = value

		End Set
	End Property
	Public Property PMinutos As Int32
		Get
			Return Minutos
		End Get
		Set(value As Int32)
			Minutos = value

		End Set
	End Property

	Public Property PHorarioId As Int32
		Get
			Return HorarioId
		End Get
		Set(value As Int32)
			HorarioId = value
		End Set
	End Property

End Class
