Imports Entidades
Imports Framework.Datos

Public Class NavesUsuarioBU
	Public Function listaNaves(ByVal naveid As Int32, ByVal usuarioid As String) As List(Of Entidades.NavesUsuario)
		Dim objDA As New Datos.NavesUsuarioDA
		Dim tabla As New DataTable
		listaNaves = New List(Of Entidades.NavesUsuario)
		tabla = objDA.listaNavesUsuario(naveid, usuarioid)
		For Each fila As DataRow In tabla.Rows

			Dim naus As New Entidades.NavesUsuario


			Dim nave As New Naves
			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			nave.PActivo = CBool(fila("nave_activo"))
            nave.PNaveSICYid = CInt(fila("nave_navesicyid"))

            naus.PNavesID = nave

			Dim Usuario As New Usuarios

			Usuario.PUserUsuarioid = CInt(fila("user_usuarioid"))
			Usuario.PUserUsername = CStr(fila("user_username"))


			naus.PUsuariosID = Usuario



			naus.PNavesID = naus.NavesID


			listaNaves.Add(naus)
		Next
	End Function
	Public Function guardar(ByVal naus As Entidades.NavesUsuario) As String
		'Dim objnausDA As New NavesUsuarioDA
		'objnausDA.guardar(naus)
		''guardar = ""
		''Dim objnausDA As New NavesUsuarioDA
		''Dim tablanaus As New DataTable
		''tablanaus = objnausDA.listaNavesU(naus.PNavesID.PNaveId, naus.PUsuariosID.PUserUsuarioid)

		''If (tablanaus.Rows.Count) <= 0 Then
		''	objnausDA.guardar(naus)
		''Else
		''	guardar = ("Ya existe el permiso para ese perfil")
		''End If

		''Return guardar
	

		guardar = ""
		Dim objnausDA As New NavesUsuarioDA
		'consulta que evita datos duplicados
		Dim tablapeus As New DataTable
		tablapeus = objnausDA.listaNavesUsuarioAltas(naus.NavesID.PNaveId, naus.PUsuariosID.PUserUsuarioid)

		If (tablapeus.Rows.Count) = 0 Then
			objnausDA.guardar(naus)
			'objpeusDA.Altas(peus)
		Else
			guardar = ("El usuario ya tiene asignada la nave")
		End If

		Return guardar
		'End Sub
		' '' '' ''Public Sub guardar(ByVal peus As Entidades.PerfilesUsuario)
		' '' '' ''	Dim objDA As New PerfilesUsuarioDA
		' '' '' ''	objDA.Altas(peus)
	End Function



    Public Sub eliminarNaus(ByVal usuario As Int32, ByVal nave As Int32)
        Dim objnausDA As New NavesUsuarioDA
        objnausDA.eliminarNaus(usuario, nave)
    End Sub


    Public Function listaNaves(ByVal usuarioid As Integer) As List(Of Entidades.NavesUsuario)
        Dim objDA As New Datos.NavesUsuarioDA
        Dim tabla As New DataTable
        listaNaves = New List(Of Entidades.NavesUsuario)
        tabla = objDA.listaNavesUsuario(usuarioid)
        For Each fila As DataRow In tabla.Rows

            Dim naus As New Entidades.NavesUsuario


            Dim nave As New Naves
            nave.PNaveId = CInt(fila("nave_naveid"))
            nave.PNombre = CStr(fila("nave_nombre"))
            nave.PActivo = CBool(fila("nave_activo"))
            nave.PNaveSICYid = CInt(fila("nave_navesicyid"))

            naus.PNavesID = nave

            Dim Usuario As New Usuarios

            Usuario.PUserUsuarioid = CInt(fila("user_usuarioid"))
            Usuario.PUserUsername = CStr(fila("user_username"))


            naus.PUsuariosID = Usuario



            naus.PNavesID = naus.NavesID


            listaNaves.Add(naus)
        Next
    End Function
End Class
