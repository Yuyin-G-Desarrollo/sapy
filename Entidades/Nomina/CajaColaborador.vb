Public Class CajaColaborador
	Public IdCajaColaborador As Int32

	Public Estatus As String
	Public MontoAcumulado As Double
	Public MontoAhorro As Double
	Public Salario As Entidades.ColaboradorReal
	Public Colaborador As Entidades.Colaborador
	Public CajaAhorro As Entidades.CajaAhorro
    Public Departamentos As Entidades.Departamentos
    Private Area As Entidades.Areas
    Public Property PAreas As Entidades.Areas
        Get
            Return Area
        End Get
        Set(ByVal value As Entidades.Areas)
            Area = value
        End Set
    End Property
	Public Property PDepartamentos As Entidades.Departamentos
		Get
			Return Departamentos
		End Get
		Set(value As Entidades.Departamentos)
			Departamentos = value
		End Set
	End Property
	Public Property PcajaAhorro As Entidades.CajaAhorro
		Get
			Return CajaAhorro
		End Get
		Set(value As Entidades.CajaAhorro)
			CajaAhorro = value
		End Set
	End Property

	Public Property PColaborador As Entidades.Colaborador
		Get
			Return Colaborador
		End Get
		Set(value As Entidades.Colaborador)
			Colaborador = value
		End Set
	End Property

	Public Property PIdColaborador As Int32
		Get
			Return IdCajaColaborador
		End Get
		Set(value As Int32)
			IdCajaColaborador = value
		End Set
	End Property
	
	
	Public Property PEstatus As String
		Get
			Return Estatus
		End Get
		Set(value As String)
			Estatus = value
		End Set
	End Property
	Public Property PMontoAcumulado As Double
		Get
			Return MontoAcumulado
		End Get
		Set(value As Double)
			MontoAcumulado = value
		End Set
	End Property
	Public Property PMontoAhorro As Double
		Get
			Return MontoAhorro
		End Get
		Set(value As Double)
			MontoAhorro = value
		End Set
	End Property
	Public Property PSalario As Entidades.ColaboradorReal
		Get
			Return Salario
		End Get
		Set(value As Entidades.ColaboradorReal)
			Salario = value
		End Set

	End Property

	Property PDepartamento As Object

    Private montoMaximoAhorrar As Int32
    Public Property PMontoMaximoAhorrar() As Int32
        Get
            Return montoMaximoAhorrar
        End Get
        Set(ByVal value As Int32)
            montoMaximoAhorrar = value
        End Set
    End Property


End Class
