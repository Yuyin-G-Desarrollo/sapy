Imports System.Data.SqlClient
Imports Persistencia

Public Class PerfilesUsuarioDA

	Public Function listaPerfilesUsuario(ByVal Grupo As Int32, ByVal Perfil As Int32, ByVal Usuario As Int32, ByVal nave As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * from framework.perfilesUsuario as a  " +
		 " JOIN Framework.perfiles as b on (a.peus_perfilid=b.perf_perfilid) " +
		 " JOIN Framework.Grupos as c ON (b.perf_grupoid = c.grup_grupoid) " +
		 " JOIN Framework.Usuarios as d ON (a.peus_usuarioid =d.user_usuarioid)" +
		 " join framework.naves as e on (c.grup_naveid =e.nave_naveid) "

		If (nave > 0) Then
			consulta += " AND grup_naveid=" + nave.ToString
		End If

		If (Perfil > 0) Then
			consulta += " AND peus_perfilid=" + Perfil.ToString
		End If

		If (Usuario > 0) Then
			consulta += " AND peus_usuarioid=" + Usuario.ToString
		End If

		If (Grupo > 0) Then
			consulta += " AND perf_grupoid=" + Grupo.ToString
		End If


		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Function listaPerfilesUsuarioAltas(ByVal Perfil As Int32, ByVal usuario As Integer) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "  select peus_perfilid,peus_usuarioid from framework.perfilesUsuario"


		If (Perfil > 0) Then
			consulta += " where peus_perfilid=" + Perfil.ToString
		End If

		If (usuario > 0) Then
			consulta += " AND peus_usuarioid=" + usuario.ToString
		End If

		
		'If (Usuario > 0) Then
		'	consulta += " AND peus_usuarioid=" + Usuario.ToString
		'End If

		'If (Grupo > 0) Then
		'	consulta += " AND perf_grupoid=" + Grupo.ToString
		'End If


		Return operaciones.EjecutaConsulta(consulta)

	End Function
	Public Sub Altas(ByVal peus As Entidades.PerfilesUsuario)
		Dim operaciones As New OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "usuario"
		parametro.Value = peus.PUsuario.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "perfil"
		parametro.Value = peus.PPerfil.Pperfilid
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_Altas_PerfilesUsuario", listaParametros)

	End Sub
	Public Sub eliminar(ByVal usuario As Int32, ByVal perfil As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "usuarios"
		valores.Value = usuario
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "perfil"
		valores.Value = perfil
		listaValores.Add(valores)



		operaciones.EjecutarSentenciaSP("Framework.SP_Eliminar_PerfilesUsuario", listaValores)

	End Sub


End Class
