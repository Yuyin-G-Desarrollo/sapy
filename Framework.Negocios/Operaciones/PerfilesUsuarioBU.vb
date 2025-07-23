Imports Framework.Datos

Public Class PerfilesUsuarioBU
	Public Function listaPerfilesUsuario(ByVal perfil As Int32, ByVal grupo As Int32, ByVal usuario As Int32, ByVal nave As Int32) As List(Of Entidades.PerfilesUsuario)
		Dim objDA As New Datos.PerfilesUsuarioDA
		Dim tabla As New DataTable
		listaPerfilesUsuario = New List(Of Entidades.PerfilesUsuario)
		tabla = objDA.listaPerfilesUsuario(perfil, grupo, usuario, nave)
		For Each fila As DataRow In tabla.Rows
			Dim peus As New Entidades.PerfilesUsuario

			Dim usuarios As New Entidades.Usuarios

			usuarios.PUserUsuarioid = CInt(fila("user_usuarioid"))
			usuarios.PUserUsername = CStr(fila("user_username"))


			peus.PUsuario = usuarios

			Dim perfiles As New Entidades.Perfiles

			perfiles.Pperfilid = CInt(fila("perf_perfilid"))
			perfiles.PNombre = CStr(fila("perf_nombre"))


			peus.PPerfil = perfiles
			'
			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			peus.PNave = naves
			'

			Dim grupos As New Entidades.Departamentos

			grupos.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupos.DNombre = CStr(fila("grup_name"))

			peus.PDepartamento = grupos

			listaPerfilesUsuario.Add(peus)
		Next
	End Function
	Public Function listaPerfilesUsuarioAltas(ByVal perfil As Int32, ByVal grupo As Int32, ByVal usuario As Int32) As List(Of Entidades.PerfilesUsuario)
		Dim objDA As New Datos.PerfilesUsuarioDA
		Dim tabla As New DataTable
		listaPerfilesUsuarioAltas = New List(Of Entidades.PerfilesUsuario)
		tabla = objDA.listaPerfilesUsuarioAltas(perfil, usuario)
		For Each fila As DataRow In tabla.Rows
			Dim peus As New Entidades.PerfilesUsuario

			Dim usuarios As New Entidades.Usuarios

			usuarios.PUserUsuarioid = CInt(fila("user_usuarioid"))
			usuarios.PUserUsername = CStr(fila("user_username"))


			peus.PUsuario = usuarios

			Dim perfiles As New Entidades.Perfiles

			perfiles.Pperfilid = CInt(fila("perf_perfilid"))
			perfiles.PNombre = CStr(fila("perf_nombre"))


			peus.PPerfil = perfiles

			

			Dim grupos As New Entidades.Departamentos

			grupos.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupos.DNombre = CStr(fila("grup_name"))

			peus.PDepartamento = grupos

			listaPerfilesUsuarioAltas.Add(peus)
		Next
	End Function
	Public Function Altas(ByVal peus As Entidades.PerfilesUsuario) As String
		'Public Sub Altas(ByVal peus As Entidades.PerfilesUsuario)
		'Dim objBu As New PerfilesUsuarioDA
		'objBu.Altas(peus)

		Altas = ""
		Dim objpeusDA As New PerfilesUsuarioDA
		'consulta que evita datos duplicados
		Dim tablapeus As New DataTable
		tablapeus = objpeusDA.listaPerfilesUsuarioAltas(peus.PPerfil.Pperfilid, peus.PUsuario.PUserUsuarioid)

		If (tablapeus.Rows.Count) = 0 Then
			objpeusDA.Altas(peus)
			'objpeusDA.Altas(peus)
		Else
			Altas = ("Ya existe el usuario para ese perfil")
		End If

		Return Altas
		'End Sub
		' '' '' ''Public Sub guardar(ByVal peus As Entidades.PerfilesUsuario)
		' '' '' ''	Dim objDA As New PerfilesUsuarioDA
		' '' '' ''	objDA.Altas(peus)
	End Function

	Public Sub eliminar(ByVal usuario As Int32, ByVal perfil As Int32)
		Dim objpeusDA As New PerfilesUsuarioDA
		objpeusDA.eliminar(usuario, perfil)
	End Sub
End Class
