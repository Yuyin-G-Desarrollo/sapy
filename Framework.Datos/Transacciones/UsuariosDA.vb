Imports System.Data.SqlClient
Imports Entidades
Imports Persistencia

Public Class UsuariosDA

	Dim ObjPool As New Pool

	Public Function CheckLogin(ByVal Usuario As String, ByVal Md5 As String) As Usuarios
		Try
			Dim operaciones As New OperacionesProcedimientos
			Dim ParametrosList As New List(Of SqlParameter)

			Dim Param As New SqlParameter
			Param.ParameterName = "username"
			Param.Value = Usuario
			ParametrosList.Add(Param)
            ''
			Dim Param2 As New SqlParameter
			Param2.ParameterName = "password"
			Param2.Value = Md5
			ParametrosList.Add(Param2)

			Dim DT As New DataTable
			DT = operaciones.EjecutarConsultaSP("Framework.SP_login", ParametrosList)
			CheckLogin = New Usuarios
			If DT.Rows.Count > 0 Then
				For Each row As DataRow In DT.Rows
					CheckLogin.PUserUsuarioid = CInt(row(0))
					CheckLogin.PUserUsername = CStr(row(1))
					CheckLogin.PUserEmail = CStr(row(2))
                    CheckLogin.PUserNombreReal = CStr(row(3))
                    If Not IsDBNull(row("user_sicy")) Then
                        CheckLogin.PUsuariosSicy = CStr(row("user_sicy"))
                    End If
                    If Not IsDBNull(row("user_colaboradorid")) Then
                        CheckLogin.PIDColaboradorUser = CInt(row("user_colaboradorid"))
                    End If
                Next
				Return CheckLogin
			Else
				Return New Usuarios
			End If
		Catch ex As SqlClient.SqlException
			Throw ex
		End Try
	End Function

    Public Function listaUsuarios(ByVal nombre As String, ByVal username As String, ByVal email As String, ByVal departamentoid As Int32, ByVal perfilid As Int32, ByVal naveid As Int32, ByVal activo As Boolean) As DataTable
        Try
            Dim operaciones As New OperacionesProcedimientos
            Dim consulta As String = "select user_usuarioid, user_username, user_activo, user_nombrereal, user_email  from Framework.Usuarios"
            consulta += " Where (user_nombrereal like '%" + nombre + "%' OR user_username LIKE '%" + username + "%' OR user_email LIKE '%" + email + "%') AND user_activo='" + activo.ToString + "'"
            If departamentoid > 0 Then
                consulta += " AND user_usuarioid in (select peus_usuarioid from Framework.PerfilesUsuario JOIN Framework.Perfiles on (peus_perfilid=perf_perfilid) where perf_grupoid=" + departamentoid.ToString + ")"
            End If

            If perfilid > 0 Then
                consulta += " AND user_usuarioid in (select peus_usuarioid from Framework.PerfilesUsuario where peus_perfilid=" + perfilid.ToString + ")"
            End If

            If (naveid > 0) Then
                consulta += " AND user_usuarioid in (select naus_usuarioid from Framework.NavesUsuario where naus_naveid=" + naveid.ToString + ")"
            End If
            Return operaciones.EjecutaConsulta(consulta)
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Sub GuardarUsuario(ByVal usuario As Usuarios)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "username"
        Param.Value = usuario.PUserUsername
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "password"
        Param.Value = usuario.PUserMd5
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nombrereal"
        Param.Value = usuario.PUserNombreReal
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "email"
        Param.Value = usuario.PUserEmail
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "activo"
        Param.Value = usuario.PUserActive
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "user"
        Param.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "colaborador"
        If (usuario.PIDColaboradorUser = 0) Then
            Param.Value = "0"
        Else
            Param.Value = usuario.PIDColaboradorUser
        End If
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "codsicy"
        Param.Value = usuario.PUsuariosSicy
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_insertar_usuarios", ParametrosList)
    End Sub

    Public Function BuscarUsuario(ByVal usuarioid As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Usuarios where user_usuarioid=" + usuarioid.ToString)
    End Function

    Public Sub EditarUsuario(ByVal usuario As Usuarios)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "username"
        Param.Value = usuario.PUserUsername
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "password"
        Param.Value = usuario.PUserMd5
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nombrereal"
        Param.Value = usuario.PUserNombreReal
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "email"
        Param.Value = usuario.PUserEmail
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "activo"
        Param.Value = usuario.PUserActive
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "user"
        Param.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "id"
        Param.Value = usuario.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "sicy"
        Param.Value = usuario.PUsuariosSicy
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "colaborador"
        If (usuario.PIDColaboradorUser = 0) Then
            Param.Value = "0"
        Else
            Param.Value = usuario.PIDColaboradorUser
        End If
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_actualizar_usuario", ParametrosList)
    End Sub

    Public Sub EditarUsuarioSinPassword(ByVal usuario As Usuarios)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "username"
        Param.Value = usuario.PUserUsername
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nombrereal"
        Param.Value = usuario.PUserNombreReal
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "email"
        Param.Value = usuario.PUserEmail
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "activo"
        Param.Value = usuario.PUserActive
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "user"
        Param.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "id"
        Param.Value = usuario.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "sicy"
        Param.Value = usuario.PUsuariosSicy
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "colaborador"
        If (usuario.PIDColaboradorUser = 0) Then
            Param.Value = "0"
        Else
            Param.Value = usuario.PIDColaboradorUser
        End If
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_actualizar_usuario_no_pass", ParametrosList)
	End Sub
	Public Function ListaTodosUsuarios() As DataTable
		Dim ObjPersistencia As New OperacionesProcedimientos
		Dim consulta As String = " SELECT * from Framework.Usuarios where user_activo='True'"
		Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ListarUsuariosSegunPerfil(ByVal perfil As Integer) As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = "SELECT p.perf_perfilid, p.perf_nombre, u.user_usuarioid, u.user_username,UPPER ( u.user_nombrereal ) as user_nombrereal " +
                     "FROM Framework.Perfiles p " +
                     "JOIN Framework.PerfilesUsuario pu ON p.perf_perfilid = pu.peus_perfilid " +
                     "JOIN Framework.Usuarios u   ON pu.peus_usuarioid = u.user_usuarioid " +
                     "WHERE p.perf_perfilid = " + perfil.ToString + " AND u.user_activo = 1 ORDER by u.user_nombrereal "
        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function
    ' ''::::::::::::::::::::::::::::::::::::::::
    Public Function verIdMaximoUsuario() As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = "SELECT MAX(user_usuarioid) FROM Framework.Usuarios WHERE user_activo='True'"
        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function verRegistrosPerfilUsuario(ByVal usuario As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select pu.peus_perfilid, pu.peus_usuarioid, pp.perf_nombre, uu.user_nombrereal " +
            " from Framework .PerfilesUsuario as pu inner join Framework .Perfiles as pp on pu.peus_perfilid =pp.perf_perfilid" +
            " inner join Framework .Usuarios as uu on pu.peus_usuarioid =uu.user_usuarioid where pu.peus_usuarioid =" + usuario + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verRegistrosNavesUsuario(ByVal usuario As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select nu.naus_naveid, nu.naus_usuarioid, nn.nave_nombre, uu.user_nombrereal" +
            " from Framework .NavesUsuario  as nu inner join Framework .Naves as nn on nu.naus_naveid =nn.nave_naveid" +
            " inner join Framework .Usuarios as uu on nu.naus_usuarioid =uu.user_usuarioid where nu.naus_usuarioid =" + usuario + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verDatosUsuarioRegistro(ByVal usuario As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select user_usuarioid, user_username, user_md5, user_activo, user_nombrereal, user_email, user_sicy, user_colaboradorid" +
            " from Framework .Usuarios where user_usuarioid =" + usuario + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub eliminaRegistrosPerfilUsuario(ByVal usuario As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "delete from Framework .PerfilesUsuario where peus_usuarioid =" + usuario + ""
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub eliminaRegistrosNaveUsuario(ByVal usuario As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "delete from Framework.NavesUsuario where naus_usuarioid =" + usuario + ""
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function contadorExisteUser(ByVal usuario As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select COUNT(*)TOTAL from Framework.Usuarios where user_username ='" + usuario + "'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub CambioContraseña(ByVal UsuarioID As Integer, ByVal Pass As String)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "@UsuarioID"
        Param.Value = UsuarioID
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@Password"
        Param.Value = Pass
        ParametrosList.Add(Param)


        operaciones.EjecutarSentenciaSP("[Nomina].[SP_Usuarios_CambioContraseña]", ParametrosList)
    End Sub

    Public Function UsuarioActualizoContraseña(ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "@IdUsuario"
        Param.Value = UsuarioID
        ParametrosList.Add(Param)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Usuarios_ConsultaUsuarioActualizoContraseña]", ParametrosList)
    End Function

End Class
