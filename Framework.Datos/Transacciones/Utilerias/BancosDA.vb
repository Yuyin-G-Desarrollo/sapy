Imports System.Data.SqlClient
Imports Persistencia

Public Class BancosDA
	Public Function listaBancosActivos() As DataTable
		Dim objOperaciones As New Persistencia.OperacionesProcedimientos
		Return objOperaciones.EjecutaConsulta("select * from framework.Bancos where banc_activo='True'")
	End Function

	Public Function listaDeBancos() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "select * from Framework.Bancos where banc_activo='True'"
		Return operaciones.EjecutaConsulta(consulta)
	End Function

	Public Function listaBancos(ByVal nombre As String, activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = (" select * from framework.Bancos ")
		consulta += "where banc_nombre like '%" + nombre + "%'"
        consulta += " and banc_activo='" + activo.ToString + "' order by banc_nombre "
		Return operaciones.EjecutaConsulta(consulta)


	End Function

	Public Sub AltasBancos(ByVal banco As Entidades.Bancos)
		Dim operaciones As New OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = banco.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = banco.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_Bancos", listaParametros)

	End Sub


	Public Sub editarBancos(ByVal banco As Entidades.Bancos)
		'a = valor de parametro
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listavalores As New List(Of SqlParameter)


		Dim a As New SqlParameter
		a.ParameterName = "BancosId"
		a.Value = banco.PBancosId
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "nombre"
		a.Value = banco.PNombre
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "activo"
		a.Value = banco.PActivo
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "usuariomodifico"
		a.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listavalores.Add(a)



		operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Bancos", listavalores)

	End Sub
	Public Function buscarBancos(ByVal bancosid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Bancos where banc_bancoid=" + bancosid.ToString)
	End Function
End Class


