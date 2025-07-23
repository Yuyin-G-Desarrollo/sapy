Imports Framework.Datos
Imports Entidades

''' <summary>
''' Gestiona permisos sobre excepciones entre acciones y usuarios
''' </summary>
''' <author>
''' Juana Guerrero
''' </author>
''' <fecha>
''' 21/Jun/2013
''' </fecha>
''' <remarks></remarks>
''' 
Public Class PermisosUsuarioBU

	''' <summary>
	''' Función para consultar si el usuario tiene permisos sobre una Acción de un Módulo (Por clave de la accion)
	''' </summary>
	''' <param name="ClaveModulo">Clave del modulo sobre el cual se revisa el permiso</param>
	''' <param name="ClaveAccion">Clave de la accion sobre la cual se revisa el permiso</param>
	''' <returns>True: Si tiene permisos. False: No tiene permisos</returns>
	''' <remarks></remarks>
	''' 
	Public Shared Function ConsultarPermiso(ByVal ClaveModulo As String, ByVal ClaveAccion As String) As Boolean
		Try
			Dim ObjPermisosUsuarioDA As New PermisosUsuarioDA
			Dim ObjPermisosPerfilDA As New PermisosPerfilDA
			Dim ObjPermisosUsuario As New PermisosUsuario
			Dim ObjPermisosPerfil As New PermisosPerfil

			ObjPermisosUsuario = ObjPermisosUsuarioDA.ConsultaExcepciones(SesionUsuario.UsuarioSesion.PUserUsuarioid, ClaveModulo, ClaveAccion)
			ObjPermisosPerfil = ObjPermisosPerfilDA.ConsultaPermiso(SesionUsuario.UsuarioSesion.PUserUsuarioid, ClaveModulo, ClaveAccion)
			
			ConsultarPermiso = PermisosUsuarioBU.TienePermisos(ObjPermisosUsuario, ObjPermisosPerfil)
			Return ConsultarPermiso
		Catch ex As Exception
			Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)).ToString)
		End Try
    End Function

    Public Shared Function ConsultarPermiso(ByVal ClaveModulo As String, ByVal ClaveAccion As String, ByVal usuarioid As Integer) As Boolean
        Try
            Dim ObjPermisosUsuarioDA As New PermisosUsuarioDA
            Dim ObjPermisosPerfilDA As New PermisosPerfilDA
            Dim ObjPermisosUsuario As New PermisosUsuario
            Dim ObjPermisosPerfil As New PermisosPerfil

            ObjPermisosUsuario = ObjPermisosUsuarioDA.ConsultaExcepciones(usuarioid, ClaveModulo, ClaveAccion)
            ObjPermisosPerfil = ObjPermisosPerfilDA.ConsultaPermiso(usuarioid, ClaveModulo, ClaveAccion)

            ConsultarPermiso = PermisosUsuarioBU.TienePermisos(ObjPermisosUsuario, ObjPermisosPerfil)
            Return ConsultarPermiso
        Catch ex As Exception
            Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)).ToString)
        End Try
    End Function

	Public Shared Function ConsultarPermisoLectura(ByVal ModuloId As Int32) As Boolean
		Try
			Dim ObjPermisosUsuarioDA As New PermisosUsuarioDA
			Dim ObjPermisosPerfilDA As New PermisosPerfilDA
			Dim ObjPermisosUsuario As New PermisosUsuario
			Dim ObjPermisosPerfil As New PermisosPerfil

			ObjPermisosUsuario = ObjPermisosUsuarioDA.ConsultaExcepcionLectura(SesionUsuario.UsuarioSesion.PUserUsuarioid, ModuloId)
			ObjPermisosPerfil = ObjPermisosPerfilDA.ConsultaPermisoLectura(SesionUsuario.UsuarioSesion.PUserUsuarioid, ModuloId)

			ConsultarPermisoLectura = PermisosUsuarioBU.TienePermisos(ObjPermisosUsuario, ObjPermisosPerfil)
			Return ConsultarPermisoLectura
		Catch ex As Exception
			Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)).ToString)
		End Try
	End Function

    Public Shared Function ConsultarPermisoLectura(ByVal usuarioid As Int32, ByVal ModuloId As Int32) As Boolean
        Try
            Dim ObjPermisosUsuarioDA As New PermisosUsuarioDA
            Dim ObjPermisosPerfilDA As New PermisosPerfilDA
            Dim ObjPermisosUsuario As New PermisosUsuario
            Dim ObjPermisosPerfil As New PermisosPerfil

            ObjPermisosUsuario = ObjPermisosUsuarioDA.ConsultaExcepcionLectura(usuarioid, ModuloId)
            ObjPermisosPerfil = ObjPermisosPerfilDA.ConsultaPermisoLectura(usuarioid, ModuloId)

            ConsultarPermisoLectura = PermisosUsuarioBU.TienePermisos(ObjPermisosUsuario, ObjPermisosPerfil)
            Return ConsultarPermisoLectura
        Catch ex As Exception
            Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)).ToString)
        End Try
    End Function

	Public Shared Function TienePermisos(ByVal ObjPermisosUsuario As PermisosUsuario, ByVal ObjPermisosPerfil As PermisosPerfil) As Boolean
		Try
			If Not IsNothing(ObjPermisosUsuario) And Not IsNothing(ObjPermisosUsuario.PAccionid) Then
				'Si tiene Excepciones. Verificar si la excepcion es de tipo Autorizar(1) o Denegar (0)
				If ObjPermisosUsuario.pTipoPermiso = 1 Then
					TienePermisos = True
				Else
					TienePermisos = False
				End If
			Else
				'No tiene excepciones. Verificar si tiene permisos por perfil

				If (Not IsNothing(ObjPermisosPerfil)) And Not IsNothing(ObjPermisosPerfil.Paccionid) Then
					TienePermisos = True
				Else
					TienePermisos = False
				End If
			End If
		Catch e As Exception
			TienePermisos = False
		End Try
		Return TienePermisos
	End Function

	Public Function listaPermisosUsuarios(ByVal ModuloId As Int32, ByVal Usuario As String, ByVal AccionId As Int32, ByVal Tipo As Int32) As List(Of Entidades.PermisosUsuario)


		Dim objDA As New Datos.PermisosUsuarioDA
		Dim tabla As New DataTable
		listaPermisosUsuarios = New List(Of Entidades.PermisosUsuario)
		tabla = objDA.listaPermisosUsuarios(ModuloId, Usuario, AccionId, Tipo)
		For Each fila As DataRow In tabla.Rows
			Dim peru As New Entidades.PermisosUsuario
			peru.pTipoPermiso = CInt(fila("peru_tipopermiso"))


			Dim Usuarios As New Usuarios

			Usuarios.PUserUsuarioid = CInt(fila("user_usuarioid"))
			Usuarios.PUserUsername = CStr(fila("user_username"))
			Usuarios.PUserActive = CBool(fila("user_activo"))

			peru.PUsuarioid = Usuarios

			Dim acciones As New Acciones

			acciones.PAccionId = CInt(fila("acmo_accionmoduloid"))
			acciones.PNombre = CStr(fila("acmo_nombre"))

			peru.PAccionid = acciones

			Dim modulos As New Modulos
			modulos.PModuloid = CInt(fila("modu_moduloid"))
			modulos.PNombre = CStr(fila("modu_nombre"))
			modulos.PActivo = CBool(fila("modu_activo"))
			acciones.PModulo = modulos

			peru.PAccionid = acciones



			listaPermisosUsuarios.Add(peru)
		Next



	End Function


	Public Function altasPermisosUsuario(ByVal permiso As Entidades.PermisosUsuario) As String
		altasPermisosUsuario = ""
		Dim objpermisoDA As New PermisosUsuarioDA
		'consulta que evita datos duplicados
		Dim tablaPermisos As New DataTable
		tablaPermisos = objpermisoDA.ValidaPermisoUsuario(permiso.PUsuarioid.PUserUsuarioid, permiso.PAccionid.PAccionId)

		If (tablaPermisos.Rows.Count) <= 0 Then
			objpermisoDA.AltasPermisosUsuarios(permiso)
		Else
			altasPermisosUsuario = "Ya existe el permiso para el usuario"
		End If
		Return altasPermisosUsuario
	End Function

	'Public Sub eliminarPermisoUsuarios(ByVal Modulo As Int32, ByVal Usuario As Int32, ByVal Accion As Int32, ByVal moduloid As Int32)
	Public Sub eliminarPermisoUsuarios(ByVal Usuario As Int32, ByVal Accion As Int32)
		Dim objpermisoDA As New PermisosUsuarioDA
		objpermisoDA.EliminarPermisosUsuario(Usuario, Accion)
	End Sub


	Public Function listaPerfimosActivos() As DataTable
		Dim objDA As New Datos.PermisosPerfilDA
		Return objDA.listaPermisos(0, 0, 0)
	End Function

	Public Function Listapepe(ByVal perfilid As Integer) As DataTable
		Dim objDA As New Datos.PermisosPerfilDA
		Return objDA.listaPermisos(0, perfilid, 0)
	End Function
	Public Function ListapermisosAcciones(ByVal accionesid As Integer) As DataTable
		Dim objDA As New Datos.PermisosPerfilDA
		Return objDA.listaPermisos(0, 0, accionesid)
	End Function

    Public Sub CopiarPermisosPermisosUsuario(ByVal UsuarioOrigenId As Int32, ByVal UsuarioDestinoId As Int32)
        Dim objpermisoDA As New PermisosUsuarioDA
        objpermisoDA.CopiarPermisosPermisosUsuario(UsuarioOrigenId, UsuarioDestinoId)
    End Sub

    Public Function TraerNombreUsuarioPermisosUsuario(ByVal Usuario As String) As String
        Dim objDA As New Datos.PermisosPerfilDA
        Return objDA.TraerUsuario(Usuario)
    End Function

End Class



