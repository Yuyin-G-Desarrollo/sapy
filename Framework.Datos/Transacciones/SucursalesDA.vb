Imports System.Data.SqlClient

Public Class SucursalesDA

	Public Function ListaSucursales(ByVal numero As String, ByVal nombre As String, ByVal banco As Int32, ByVal ciudad As Int32, ByVal activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select suc.sucu_sucursalId as Id, LTRIM(RTRIM(suc.Sucu_Nombre)) as Sucursal, LTRIM(RTRIM(suc.sucu_numero)) as Número," +
            " suc.sucu_bancoid as IdBanco," +
            " LTRIM(RTRIM(ba.banc_nombre)) as Banco," +
            " suc.sucu_ciudadid as IdCiudad," +
            " LTRIM(RTRIM(ci.city_nombre)) as Ciudad," +
            " ci.city_estadoid as IdEstado, " +
            " suc.sucu_activo as Activo " +
            " from framework.SucursalesBancarias suc" +
            " join framework.Bancos ba on ba.banc_bancoid = suc.sucu_bancoid" +
            " JOIN Framework.Ciudades ci on ci.city_ciudadid = suc.sucu_ciudadid AND  sucu_numero like '%" + numero + "%'" +
            " AND sucu_nombre like '%" + nombre + "%'  "
		If (banco > 0) Then
			consulta += " and sucu_bancoid=" + banco.ToString
		End If
		If (ciudad > 0) Then
			consulta += " and sucu_ciudadid=" + ciudad.ToString

		End If
        consulta += " AND sucu_activo='" + activo.ToString + "' order by Sucursal, banc_nombre, Número "

		Return operaciones.EjecutaConsulta(consulta)
	End Function

	Public Sub AltasSucursales(ByVal sucursal As Entidades.Sucursales)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)

		Dim valores As New SqlParameter
		valores.ParameterName = "numero"
		valores.Value = sucursal.Pnumero
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "nombre"
		valores.Value = sucursal.Pnombre
		listaValores.Add(valores)
		

		valores = New SqlParameter
		valores.ParameterName = "banco"
		valores.Value = sucursal.Pbanco
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "ciudad"
		valores.Value = sucursal.Pciudad
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "activo"
		valores.Value = sucursal.Pactivo
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "usuariocreo"
		valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaValores.Add(valores)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_Sucursales", listaValores)

	End Sub
	Public Sub editarSucursales(ByVal sucursal As Entidades.Sucursales)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "idsucursal"
		parametro.Value = sucursal.Pidsucursales
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "numero"
		parametro.Value = sucursal.Pnumero
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = sucursal.Pnombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "banco"
		parametro.Value = sucursal.Pbanco
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "ciudad"
		parametro.Value = sucursal.Pciudad
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = sucursal.Pactivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		
		operaciones.EjecutarSentenciaSP("Framework.SP_editar_Sucursal", listaParametros)

	End Sub

	Public Function buscarSucursal(ByVal idsucursal As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("select * from Framework.SucursalesBancarias where sucu_sucursalid=" + idsucursal.ToString)

	End Function



End Class


	