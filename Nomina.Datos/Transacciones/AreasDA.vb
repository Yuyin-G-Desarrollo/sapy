Imports System.Data.SqlClient

Public Class AreasDA

	
	Public Function ListaAreas(ByVal Nombre As String, ByVal Nave As Int32, ByVal Activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * FROM Nomina.Areas as a JOIN Framework.Naves as  b on (area_naveid = b.nave_naveid)  where area_naveid in(select naus_naveid  from Framework.NavesUsuario where naus_usuarioid=naus_usuarioid) "

		consulta += "And area_nombre like '%" + Nombre + "%'"
		If (Nave > 0) Then
			consulta += " AND area_naveid=" + Nave.ToString
		End If

		consulta += " AND area_activo='" + Activo.ToString + "'"
		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Sub Altas(ByVal area As Entidades.Areas)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = area.PNombre
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = area.PActivo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "NaveId"
		parametro.Value = area.PNave.PNaveId
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_Areas", listaParametros)

	End Sub
	Public Sub editarAreas(ByVal area As Entidades.Areas)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = area.PNombre
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = area.PActivo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "nave"
		parametro.Value = area.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "areaid"
		parametro.Value = area.PAreaid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Areas", listaParametros)

	End Sub


	Public Function buscarAreas(ByVal areasid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * FROM Nomina.Areas as a JOIN Framework.naves as  b on (area_naveid = b.nave_naveid) where area_areaid=" + areasid.ToString)
	End Function

	Public Function listaAreasSegunNave(ByVal idNave As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select area_areaid,UPPER (area_nombre) as area_nombre, area_activo, area_usuariocreoid" +
                                ", area_fechacreacion, area_usuariomodificoid, area_fechamodificacion, area_naveid from" +
                                " Nomina.Areas where area_naveid =" + idNave.ToString + " AND area_activo= 1 order by area_nombre"
		Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
