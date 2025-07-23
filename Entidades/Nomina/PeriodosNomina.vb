Public Class PeriodosNomina
	Public Nave As Entidades.Naves
    Public FechaInicio As Date
    Public FechaFin As Date
    Public PeriodoId As Int32
    Public SemanaNomina As Int32
    Public EstadoPeriodoNomina As String
    Public Concepto As String
    Public Asistencia As String
    Public StCajaAhorro As String
    Public Property pAsistencia As String
        Get
            Return Asistencia
        End Get
        Set(value As String)
            Asistencia = value

        End Set
    End Property
    Public Property pStCajaAhorro As String
        Get
            Return StCajaAhorro
        End Get
        Set(value As String)
            StCajaAhorro = value

        End Set
    End Property


    Public Property PNave As Entidades.Naves
        Get
            Return Nave

        End Get
        Set(value As Entidades.Naves)
            Nave = value

        End Set
    End Property
    Public Property PFechaInicio As Date
        Get
            Return FechaInicio
        End Get
        Set(value As Date)
            FechaInicio = value
        End Set
    End Property
	Public Property PFechaFin As Date
		Get
			Return FechaFin
		End Get
		Set(value As Date)
			FechaFin = value
		End Set
	End Property
	Public Property PPeriodoId As Int32
		Get
			Return periodoId
		End Get
		Set(value As Int32)
			periodoId = value

		End Set
	End Property
	Public Property PsemanaNomina As Int32
		Get
			Return semanaNomina
		End Get
		Set(value As Int32)
			semanaNomina = value

		End Set
	End Property
	Public Property PPeriodoNomina As String
		Get
			Return EstadoPeriodoNomina
		End Get
		Set(value As String)
			EstadoPeriodoNomina = value

		End Set
	End Property
	Public Property PConcepto As String
		Get
			Return Concepto
		End Get
		Set(value As String)
			Concepto = value

		End Set
	End Property
	Public Property PEstadoPeriodoDeNomina As String
		Get
			Return EstadoPeriodoNomina
		End Get
		Set(value As String)
			EstadoPeriodoNomina = value
		End Set
	End Property
End Class
