Public Class Celulas
	Private celulaid As Int32
	Private nombre As String
    Private activo As Boolean
    Private NombreD As String
    Private departamento As Departamentos
    Private orden As Int32

    Public Property PNombreD As String
        Get
            Return NombreD
        End Get
        Set(value As String)
            NombreD = value
        End Set
    End Property

	Public Property PCelulaid As Int32
		Get
			Return celulaid
		End Get
		Set(ByVal value As Int32)
			celulaid = value
		End Set
	End Property
	Public Property PNombre As String
		Get
			Return nombre
		End Get
		Set(ByVal value As String)
			nombre = value
		End Set
	End Property
	Public Property PActivo As Boolean
		Get
			Return activo
		End Get
		Set(ByVal value As Boolean)
			activo = value
		End Set
	End Property
	Public Property PDepartamento As Departamentos
		Get
			Return departamento
		End Get
		Set(ByVal value As Departamentos)
			departamento = value
		End Set
    End Property


    Public Property POrden As Int32
        Get
            Return orden
        End Get
        Set(value As Int32)
            orden = value
        End Set
    End Property
End Class
