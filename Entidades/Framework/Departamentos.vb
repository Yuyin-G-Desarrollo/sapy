Public Class Departamentos

	Private Nombre As String
    Private Departamentoid As Int32
    Private DepartamentoIDNP As Integer
    Private Activo As Boolean
	Private Nave As Naves
    Public Areas As Entidades.Areas

    Public Property PDepartamentoIDNP As Integer
        Get
            Return DepartamentoIDNP
        End Get
        Set(value As Integer)
            DepartamentoIDNP = value
        End Set
    End Property

	Public Property DAreas As Entidades.Areas
		Get
			Return Areas

		End Get
		Set(value As Areas)
			Areas = value
		End Set
	End Property
	Public Property DNombre As String
		Get
			Return Nombre
		End Get
		Set(value As String)
			Nombre = value
		End Set
	End Property

	Public Property DActivo As Boolean
		Get
			Return Activo
		End Get
		Set(value As Boolean)
			Activo = value
		End Set
	End Property
	Public Property Ddepartamentoid As Int32
		Get
			Return Departamentoid
		End Get
		Set(value As Int32)
			Departamentoid = value
		End Set
    End Property
    Public Property PNave As Naves
        Get
            Return Nave
        End Get
        Set(ByVal value As Naves)
            Nave = value
        End Set
    End Property
	



End Class
