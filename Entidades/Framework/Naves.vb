Public Class Naves
	Private NaveId As Int32
    Private Nombre As String
    Private NaveSICYid As Int32
	Private Activo As Boolean
	

	Public Property PNaveId As Int32
		Get
			Return NaveId
		End Get
		Set(value As Int32)
			NaveId = value
		End Set
	End Property

	Public Property PNombre As String
		Get
			Return Nombre
		End Get
		Set(value As String)
			Nombre = value
		End Set
    End Property

    Public Property PNaveSICYid As Int32
        Get
            Return NaveSICYid
        End Get
        Set(value As Int32)
            NaveSICYid = value
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

End Class
