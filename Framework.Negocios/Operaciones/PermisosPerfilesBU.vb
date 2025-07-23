Imports Entidades
Imports Framework.Datos

Public Class PermisosPerfilesBU

	Public Function listaPermisosPerfiles(ByVal perfilid As Int32, ByVal accionid As Int32, ByVal modulo As Int32) As List(Of Entidades.PermisosPerfil)
		Dim objDA As New Datos.PermisosPerfilDA
		Dim tabla As New DataTable
		listaPermisosPerfiles = New List(Of Entidades.PermisosPerfil)
		tabla = objDA.listaPermisos(perfilid, accionid, modulo)
		For Each fila As DataRow In tabla.Rows

			Dim permisos As New Entidades.PermisosPerfil


			Dim perfil As New Perfiles
			perfil.Pperfilid = CInt(fila("pepe_perfilid"))
			perfil.PNombre = CStr(fila("perf_nombre"))
			perfil.PActivo = CBool(fila("perf_activo"))

			permisos.Pperfilid = perfil

			Dim acciones As New Acciones

			acciones.PAccionId = CInt(fila("acmo_accionmoduloid"))
			acciones.PNombre = CStr(fila("acmo_nombre"))


			permisos.Paccionid = acciones

			Dim modulos As New Modulos
			modulos.PModuloid = CInt(fila("modu_moduloid"))
			modulos.PNombre = CStr(fila("modu_nombre"))
			modulos.PActivo = CBool(fila("modu_activo"))
			acciones.PModulo = modulos

			permisos.Paccionid = acciones


			listaPermisosPerfiles.Add(permisos)
		Next
	End Function


	Public Function altasPermisos(ByVal permiso As Entidades.PermisosPerfil) As String
		altasPermisos = ""
		Dim objpermisoDA As New PermisosPerfilDA
		'consulta que evita datos duplicados
		Dim tablaPermisos As New DataTable
		tablaPermisos = objpermisoDA.listaPermisos(permiso.Pperfilid.Pperfilid, permiso.Paccionid.PAccionId, 0)

		If (tablaPermisos.Rows.Count) <= 0 Then
			objpermisoDA.AltasPermisos(permiso)
		Else
			altasPermisos = "Ya existe el permiso para ese perfil"
		End If
		Return altasPermisos
	End Function

	Public Sub eliminarPermisos(ByVal permisos As Int32, ByVal idperfil As Int32, ByVal idmodulo As Int32)
		Dim objpermisoDA As New PermisosPerfilDA
		objpermisoDA.eliminarPermisos(permisos, idperfil, idmodulo)
	End Sub

	Public Function buscarpermiso(ByVal pepeid As Int32) As Entidades.PermisosPerfil
		Dim objpermisosDA As New PermisosPerfilDA
		Dim permisosperfiles As New Entidades.PermisosPerfil
		Dim tablaPermisos As New DataTable
		tablaPermisos = objpermisosDA.buscarpermisos(pepeid)

		For Each fila As DataRow In tablaPermisos.Rows

			Dim permisos As New Entidades.PermisosPerfil


			Dim perfil As New Perfiles
			perfil.Pperfilid = CInt(fila("perf_perfilid"))
			perfil.PNombre = CStr(fila("perf_nombre"))
			perfil.PActivo = CBool(fila("perf_activo"))

			permisos.Pperfilid = perfil



			Dim acciones As New Acciones

			acciones.PAccionId = CInt(fila("acmo_accionid"))
			acciones.PNombre = CStr(fila("acmo_nombre"))
			permisos.Paccionid = acciones

			Dim modulo As New Modulos

			modulo.PModuloid = CInt(fila("modu_moduloid"))
			modulo.PNombre = CStr(fila("modu_nombre"))
			modulo.PActivo = CBool(fila("modu_activo"))



			permisos.Paccionid.PModulo = modulo


		Next

		Return permisosperfiles
	End Function

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


End Class







