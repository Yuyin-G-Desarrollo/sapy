Imports System.Data.SqlClient

Public Class RangoSubsidioEmpleoDA

	Public Function SubsidioEmpleo() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos


		Dim consulta As String = "SELECT * FROM Nomina.RangoSubsidioEmpleo order BY rase_limiteinferior "


		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Sub Insert(ByVal Subsidio As Entidades.RangoSubsidioEmpleo)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Subsidio.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Subsidio.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Valor"
		parametro.Value = Subsidio.PValor
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_SubsidioEmpleo", listaParametros)

	End Sub
	Public Sub Update(ByVal Subsidio As Entidades.RangoSubsidioEmpleo)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Subsidio.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Subsidio.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Valor"
		parametro.Value = Subsidio.PValor
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "SubsidioID"
		parametro.Value = Subsidio.PSubsidioID
		listaParametros.Add(parametro)


		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_SubsidioEmpleo", listaParametros)

	End Sub
	Public Sub Delete(ByVal Subsidio As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)

		Dim valores As New SqlParameter
		valores.ParameterName = "ID"
		valores.Value = Subsidio
		listaValores.Add(valores)


		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_SubsidioEmpleo", listaValores)

	End Sub
End Class
