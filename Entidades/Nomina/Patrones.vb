Public Class Patrones
    Private patronBD As String
    Private Servidor As String
	Private patronid As Int32
	Private nombre As String
	Private rfc As String
    Private Npatronal As String
    Private NpatronalNP As String
	Private calle As String
	Private Dnumero As String
	Private colonia As String
	Private ciudadId As Int32
	Private cp As String
	Private activo As Boolean
	Private usuariomodifico As Int32
    Private nombreCiudad As String
    Private comisiones As Boolean
    Private porcentajeComisiones As Double

    Public Property PServidor As String
        Get
            Return Servidor
        End Get
        Set(value As String)
            Servidor = value
        End Set
    End Property

    Public Property PpatronBD As String
        Get
            Return patronBD
        End Get
        Set(value As String)
            patronBD = value
        End Set
    End Property

	Public Property Ppatronid As Int32
		Get
			Return patronid
		End Get
		Set(value As Int32)
			patronid = value
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

	Public Property Prfc As String
		Get
			Return rfc

		End Get
		Set(value As String)
			rfc = value
		End Set
	End Property

	Public Property PNpatronal As String
		Get
			Return Npatronal
		End Get
		Set(value As String)
			Npatronal = value

		End Set
    End Property

    Public Property PNpatronalNP As String
        Get
            Return NpatronalNP
        End Get
        Set(value As String)
            NpatronalNP = value

        End Set
    End Property


	Public Property Pcalle As String
		Get
			Return calle
		End Get
		Set(value As String)
			calle = value
		End Set
	End Property

	Public Property PDnumero As String
		Get
			Return Dnumero
		End Get
		Set(value As String)
			Dnumero = value
		End Set
	End Property
	Public Property Pcolonia As String
		Get
			Return colonia
		End Get
		Set(value As String)
			colonia = value
		End Set
	End Property

	Public Property PciudadId As Int32
		Get
			Return ciudadId
		End Get
		Set(value As Int32)
			ciudadId = value
		End Set
	End Property
	Public Property Pcp As String
		Get
			Return cp
		End Get
		Set(value As String)
			cp = value
		End Set
	End Property
	Public Property Pactivo As Boolean
		Get
			Return activo
		End Get
		Set(value As Boolean)
			activo = value
		End Set
	End Property
	Public Property Pusuariomodifico As Int32
		Get
			Return usuariomodifico
		End Get
		Set(value As Int32)
			usuariomodifico = value
		End Set
	End Property
	Public Property PNombreCiudad As String
		Get
			Return nombreCiudad
		End Get
		Set(value As String)
			NombreCiudad = value
		End Set
	End Property

    Public Property Pcomisiones As Boolean
        Get
            Return comisiones
        End Get
        Set(value As Boolean)
            comisiones = value
        End Set
    End Property

    Public Property PporcentajeComision As Double
        Get
            Return porcentajeComisiones
        End Get
        Set(value As Double)
            porcentajeComisiones = value
        End Set
    End Property

End Class


