Public Class ExcepcionesHorarios
	Public nombre As String
	Public Activo As Boolean
	Public horario As Entidades.Horarios
	Public Fecha As Date
	Public ExcepcionesHorarioID As Int32
	Public Tipo As Int32
	Public Property PTipo As Int32
		Get
			Return Tipo
		End Get
		Set(value As Int32)
			Tipo = value

		End Set
	End Property
	Public Property PExcepcionesHorarioID As Int32
		Get
			Return ExcepcionesHorarioID
		End Get
		Set(value As Int32)
			ExcepcionesHorarioID = value
		End Set
	End Property

	Public Property Pnombre As String
		Get
			Return nombre
		End Get
		Set(value As String)
			nombre = value
		End Set
	End Property
	Public Property PActivo As Boolean
		Get
			Return Activo
		End Get
		Set(value As Boolean)
			Activo = value


		End Set
	End Property
	Public Property PHorario As Entidades.Horarios
		Get
			Return horario
		End Get
		Set(value As Entidades.Horarios)

			horario = value

		End Set
	End Property
	Public Property PFecha As Date
		Get
			Return Fecha

		End Get
		Set(value As Date)
			Fecha = value

		End Set
	End Property

	'Function PFecha(p1 As Object) As System.Windows.Forms.SelectionRange
	'	Throw New NotImplementedException
	'End Function

End Class
