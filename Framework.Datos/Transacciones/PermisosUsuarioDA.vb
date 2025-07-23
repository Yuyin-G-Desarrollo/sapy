Imports Entidades
Imports System.Data.SqlClient

''' <summary>
''' Ejecuta las sentencias para la verificacion de permisos
''' </summary>
''' <remarks></remarks>
Public Class PermisosUsuarioDA

	''' <summary>
	''' Genera y ejecuta en persistencia la consulta para obtener los permisos del usuario en sesion
	''' </summary>
	''' <param name="claveModulo">Clave del modulo</param>
	''' <param name="claveAccion">Clave de la acción</param>
	''' <param name="UsuarioID">ID del usuario</param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function ConsultaExcepciones(ByVal UsuarioID As Int32, ByVal ClaveModulo As String, ByVal ClaveAccion As String) As PermisosUsuario
		Try
			Dim Consulta As String = "select peru_accionid, peru_usuarioid, peru_tipopermiso from Framework.PermisosUsuario"
			Consulta += " join Framework.AccionesModulo ON (acmo_accionmoduloid=peru_accionid) "
			Consulta += " join Framework.Modulos ON (modu_moduloid=acmo_moduloid) "
			Consulta += " where peru_usuarioid=" + UsuarioID.ToString
			Consulta += " and acmo_clave LIKE '" + ClaveAccion + "' AND modu_clave LIKE '" + ClaveModulo + "'"
			Consulta += " and acmo_activo='True'"

			Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos()
			Dim DtResultados As DataTable
			Dim ExcepcionPermiso As New PermisosUsuario
			DtResultados = ObjPersistencia.EjecutaConsulta(Consulta)
			For Each row As DataRow In DtResultados.Rows
				Dim accion As New Acciones
				accion.PAccionId = CInt(row(0))
				ExcepcionPermiso.PAccionid = accion
				Dim usuario As New Usuarios
				usuario.PUserUsuarioid = CInt(row(1))
				ExcepcionPermiso.PUsuarioid = usuario
				ExcepcionPermiso.pTipoPermiso = CInt(row(2))
			Next
			Return ExcepcionPermiso
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ConsultaExcepcionLectura(ByVal UsuarioId As Int32, ByVal Moduloid As Int32) As PermisosUsuario
		Try
			Dim Consulta As String = "select peru_accionid, peru_usuarioid, peru_tipopermiso from Framework.PermisosUsuario"
			Consulta += " join Framework.AccionesModulo ON (acmo_accionmoduloid=peru_accionid) "
			Consulta += " join Framework.Modulos ON (modu_moduloid=acmo_moduloid) "
			Consulta += " where peru_usuarioid=" + UsuarioId.ToString
			Consulta += " and acmo_activo='True' and modu_activo='True'"
			Consulta += " and acmo_tipo=1"
			Consulta += " and modu_moduloid=" + Moduloid.ToString

			Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos()
			Dim DtResultados As DataTable
			Dim ExcepcionPermiso As New PermisosUsuario
			DtResultados = ObjPersistencia.EjecutaConsulta(Consulta)
			For Each row As DataRow In DtResultados.Rows
				Dim accion As New Acciones
                accion.PAccionId = CInt(row("peru_accionid"))
				ExcepcionPermiso.PAccionid = accion
				Dim usuario As New Usuarios
                usuario.PUserUsuarioid = CInt(row("peru_usuarioid"))
				ExcepcionPermiso.PUsuarioid = usuario
                ExcepcionPermiso.pTipoPermiso = CInt(row("peru_tipopermiso"))
			Next
			Return ExcepcionPermiso
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	

	'-------------------------------------------------------------------------------------------------------------------------'
	'                           Aqui comienzan consultas y datos para la pantalla de excepciones 
	'                                                   
	'-------------------------------------------------------------------------------------------------------------------------'

	Public Function listaPermisosUsuarios(ByVal ModuloId As Int32, ByVal Usuario As String, ByVal AccionId As Int32, ByVal Tipo As Int32) As DataTable

		Dim operaciones As New Persistencia.OperacionesProcedimientos

		Dim consulta As String = " select * from Framework.PermisosUsuario " +
		 "join Framework.Usuarios as b on (peru_usuarioid=user_usuarioid) " +
		 "join Framework.AccionesModulo on peru_accionid=acmo_accionmoduloid " +
		 "join Framework.Modulos on (acmo_moduloid=modu_moduloid) "
		
		consulta += " where user_username like '%" + Usuario + "%'"



		consulta += " and peru_tipopermiso ='" + Tipo.ToString + "'"

		If (ModuloId > 0) Then
			consulta += " AND acmo_moduloid =" + ModuloId.ToString
		End If

		If (AccionId > 0) Then

			consulta += " AND acmo_accionmoduloid =" + AccionId.ToString
		End If


		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Function ValidaPermisoUsuario(ByVal Usuario As Int32, ByVal AccionId As Int32) As DataTable

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * from Framework.PermisosUsuario "
		consulta += " where peru_usuarioid ='" + Usuario.ToString + "'"
		consulta += " AND peru_accionid =" + AccionId.ToString
		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Sub AltasPermisosUsuarios(ByVal permisosUsuarios As Entidades.PermisosUsuario)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "UsuarioId"
		valores.Value = permisosUsuarios.PUsuarioid.PUserUsuarioid
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "AccionId"
		valores.Value = permisosUsuarios.PAccionid.PAccionId
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "TipoPermiso"
		valores.Value = permisosUsuarios.pTipoPermiso.ToString
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "UsuariocreoId"
		valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaValores.Add(valores)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_PermisosUsuario", listaValores)

	End Sub

	Public Sub EliminarPermisosUsuario(ByVal UsuarioId As Int32, ByVal AccionId As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)


		Dim valores As New SqlParameter
		valores.ParameterName = "UsuarioId"
		valores.Value = UsuarioId
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "AccionId"
		valores.Value = AccionId
		listaValores.Add(valores)


        operaciones.EjecutarSentenciaSP("Framework.SP_Eliminar_PermisosUsuario", listaValores)

	End Sub

    ''' Javier Salazar García, 04/11/2019
    ''' <summary>
	''' Permite replicar los permisos, permisos especiales y naves de un usuario a otro.
	''' </summary>
	''' <param name="UsuarioOrigenId">Clave del Usuario Origen de los permisos</param>
	''' <param name="UsuarioDestinoId">Clave del Usuario Destino de los permisos</param>
	''' <remarks></remarks>

    Public Sub CopiarPermisosPermisosUsuario(ByVal UsuarioOrigenId As Int32, ByVal UsuarioDestinoId As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "idUsuarioOrigen"
        valores.Value = UsuarioOrigenId
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "idUsuarioDestino"
        valores.Value = UsuarioDestinoId
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "idUsuarioCreo"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        operaciones.EjecutarSentenciaSP("Framework.SP_CopiarPermisos_PermisosUsuario", listaValores)
    End Sub

End Class


