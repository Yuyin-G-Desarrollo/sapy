Imports System.Data.SqlClient

Public Class FactoresDeIntegracionDA

	Public Function FactoresDeIntegracion() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos


		Dim consulta As String = "SELECT * FROM Nomina.FactoresIntegracion"


		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Sub WriteFactorIntegracion(ByVal Factor As Entidades.FactoresDeIntegracion)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		
		parametro.ParameterName = "años"
		parametro.Value = Factor.PAñosDeServicio
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "DiasVacaciones"
		parametro.Value = Factor.PDiasDeVacaciones
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "PrimaVacacional"
		parametro.Value = Factor.PFactorPrimaVacacional
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FactorAguinaldo"
		parametro.Value = Factor.PFactorAguinaldo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FactorIntegracion"
		parametro.Value = Factor.PFactorIntegracion
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_FactoIntegracion", listaParametros)

	End Sub
	Public Sub UpdateFactorIntegracion(ByVal Factor As Entidades.FactoresDeIntegracion)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "FactorID"
		parametro.Value = Factor.FactorIntegracionId
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "Años"
		parametro.Value = Factor.AñosDeServicio
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "DiasVacaciones"
		parametro.Value = Factor.DiasDeVacaciones
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "PrimaVacacional"
		parametro.Value = Factor.FactorPrimaVacacional
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FactorAguinaldo"
		parametro.Value = Factor.FactorAguinaldo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FactorIntegracion"
		parametro.Value = Factor.FactorIntegracion
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_FactorIntegracion", listaParametros)

	End Sub
	Public Sub eliminar(ByVal FACTOR As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "ID"
		valores.Value = FACTOR
		listaValores.Add(valores)


		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_FactorIntegracion", listaValores)

	End Sub
End Class
