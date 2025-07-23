Imports System.Data.SqlClient

Public Class ImpuestoSubsidioEmpleoDA

	Public Function ImpuestoSubsidio() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos

		Dim consulta As String = "SELECT * FROM Nomina.RangosImpuestoSubsidioEmpleo ORDER BY rise_limiteinferior"

		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Sub AltasImpuestoSubsidio(ByVal Impuesto As Entidades.ImpuestoSubsidioEmpleo)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Impuesto.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Impuesto.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "CuotaFija"
		parametro.Value = Impuesto.PCuotaFija
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Porcentaje"
		parametro.Value = Impuesto.PPorcentaje
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_ImpuestoSubsidioEmpleo", listaParametros)

	End Sub
	Public Sub EditarImpuestoSubsidio(ByVal Impuesto As Entidades.ImpuestoSubsidioEmpleo)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Impuesto.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Impuesto.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Cuota"
		parametro.Value = Impuesto.PCuotaFija
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Porcentaje"
		parametro.Value = Impuesto.PPorcentaje
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "ImpuestoID"
		parametro.Value = Impuesto.PimpuestoEmpleoID
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_ImpuestoSubsidioEmpleo", listaParametros)

	End Sub
	Public Sub eliminar(ByVal ImpuestoSubsidio As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "ID"
		valores.Value = ImpuestoSubsidio
		listaValores.Add(valores)


		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_ImpuestoSubsidioEmpleo", listaValores)

	End Sub
End Class
