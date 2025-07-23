Imports System.Data.SqlClient

Public Class DeduccionRealImssDA
	Public Function DeduccionRealIMSS() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos


		Dim consulta As String = "Select * from nomina.DeduccionRealImss  ORDER BY drim_limiteinferior "


		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Sub AltasDeduccionIMSS(ByVal Deduccion As Entidades.DeduccionRealImss)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Deduccion.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Deduccion.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Cantidad"
		parametro.Value = Deduccion.PCantidad
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_DeduccionRealImss", listaParametros)

	End Sub
	Public Sub EditarDeduccionIMSS(ByVal Deduccion As Entidades.DeduccionRealImss)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "LimiteSuperior"
		parametro.Value = Deduccion.LimiteSuperior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "LimiteInferior"
		parametro.Value = Deduccion.LimiteInferior
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Monto"
		parametro.Value = Deduccion.PCantidad
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "ImssId"
		parametro.Value = Deduccion.PDeduccionImssID
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_DeduccionRealImss", listaParametros)

	End Sub
	Public Sub eliminar(ByVal IMSS As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "ID"
		valores.Value = IMSS
		listaValores.Add(valores)


		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_DeduccionRealImss", listaValores)

	End Sub
End Class
