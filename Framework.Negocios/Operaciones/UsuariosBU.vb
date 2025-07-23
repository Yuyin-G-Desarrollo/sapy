Imports Framework.Datos
Imports Entidades

Public Class UsuariosBU

	Public Function login(ByVal Usuario As String, ByVal Password As String) As Boolean
		Dim ObjUsuarioDA As New UsuariosDA
		'Convierte la cadena de la contraseña a md5
		Dim ObjString As New UtileriaCadenas
		Dim Resultado As String
		Resultado = ObjString.StringToMd5(Password)
        Dim UsuarioLogin As New Usuarios
        Dim ConfigRutas As New RutasGenerales
        UsuarioLogin = ObjUsuarioDA.CheckLogin(Usuario, Resultado)

		If (Not IsNothing(UsuarioLogin)) And UsuarioLogin.PUserUsuarioid > 0 Then
            SesionUsuario.UsuarioSesion = UsuarioLogin
            Dim objRDA As New RutasConfiguracionBU

            ConfigRutas = objRDA.RutasConfiguracion
            SesionUsuario.ConfigRutas = ConfigRutas
            'registra login en bitacora
            Return True
		Else
			Return False
		End If

    End Function

    Public Function loginObjeto(ByVal Usuario As String, ByVal Password As String) As Usuarios
        Dim ObjUsuarioDA As New UsuariosDA
        'Convierte la cadena de la contraseña a md5
        Dim ObjString As New UtileriaCadenas
        Dim Resultado As String
        Resultado = ObjString.StringToMd5(Password)
        Dim UsuarioLogin As New Usuarios
        UsuarioLogin = ObjUsuarioDA.CheckLogin(Usuario, Resultado)

        Return UsuarioLogin

    End Function


    Public Function listaUsuarios(ByVal nombre As String, ByVal username As String, ByVal email As String, ByVal naveid As Int32, ByVal departamentoid As Int32, ByVal perfilid As Int32, ByVal activo As Boolean) As List(Of Usuarios)
        Dim ObjUsuarioDA As New UsuariosDA
        Dim dt As New DataTable
        Dim objUsuarios As New Usuarios
        Dim lista As New List(Of Usuarios)

        dt = ObjUsuarioDA.listaUsuarios(nombre, username, email, departamentoid, perfilid, naveid, activo)

        For Each row As DataRow In dt.Rows
            objUsuarios = New Usuarios
            objUsuarios.PUserUsuarioid = CInt(row("user_usuarioid"))
            objUsuarios.PUserUsername = CStr(row("user_username"))
            objUsuarios.PUserNombreReal = CStr(row("user_nombrereal"))
            objUsuarios.PUserEmail = CStr(row("user_email"))
            objUsuarios.PUserActive = CBool(row("user_activo"))

            lista.Add(objUsuarios)
        Next

        Return lista
    End Function

    Public Sub guardarUsuario(ByVal usuario As Usuarios)
        Dim ObjString As New UtileriaCadenas
        Dim objDA As New UsuariosDA
        usuario.PUserMd5 = ObjString.StringToMd5(usuario.PUserMd5)
        objDA.GuardarUsuario(usuario)
    End Sub

    Public Sub editarUsuario(ByVal usuario As Usuarios)
        Dim ObjString As New UtileriaCadenas
        Dim objDA As New UsuariosDA
        If (usuario.PUserMd5.Length > 0) Then
            usuario.PUserMd5 = ObjString.StringToMd5(usuario.PUserMd5)
            objDA.EditarUsuario(usuario)
        Else
            objDA.EditarUsuarioSinPassword(usuario)
        End If
    End Sub


    Public Function buscarUsuario(ByVal usuarioid As Int32) As Usuarios
        buscarUsuario = New Usuarios
        Dim objDA As New UsuariosDA
        Dim tabla As New DataTable
        tabla = objDA.BuscarUsuario(usuarioid)
        For Each row As DataRow In tabla.Rows
            buscarUsuario.PUserUsuarioid = CInt(row("user_usuarioid"))
            buscarUsuario.PUserUsername = CStr(row("user_username"))
            buscarUsuario.PUserNombreReal = CStr(row("user_nombrereal"))
            buscarUsuario.PUserActive = CBool(row("user_activo"))
            buscarUsuario.PUserEmail = CStr(row("user_email"))
        Next

        Return buscarUsuario
    End Function

	Public Function ListaUsuariosTodos() As DataTable
		Dim objDA As New UsuariosDA
		Return objDA.ListaTodosUsuarios
    End Function
    Public Function ListarUsuariosSegunPerfil(ByVal perfil As Integer) As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.ListarUsuariosSegunPerfil(perfil)
    End Function
    '' ''::::::::::::::::::::::::::::::::
    Public Function verIdMaxUsuario() As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.verIdMaximoUsuario()
    End Function

    Public Function verRegistrosPerfilUsuario(ByVal usuario As String) As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.verRegistrosPerfilUsuario(usuario)
    End Function

    Public Function verRegistrosNavesUsuario(ByVal usuario As String) As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.verRegistrosNavesUsuario(usuario)
    End Function

    Public Function verDatosUsuarioRegistro(ByVal usuario As String) As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.verDatosUsuarioRegistro(usuario)
    End Function

    Public Sub eliminaRegistrosPerfilUsuario(ByVal usuario As String)
        Dim objDA As New UsuariosDA
        objDA.eliminaRegistrosPerfilUsuario(usuario)
    End Sub

    Public Sub eliminaRegistrosNaveUsuario(ByVal usuario As String)
        Dim objDA As New UsuariosDA
        objDA.eliminaRegistrosNaveUsuario(usuario)
    End Sub

    Public Function contadorExisteUser(ByVal usuario As String) As DataTable
        Dim objDA As New UsuariosDA
        Return objDA.contadorExisteUser(usuario)
    End Function

    Public Sub CambioContraseña(ByVal UsuarioID As Integer, ByVal Pass As String)
        Dim objDA As New UsuariosDA
        objDA.CambioContraseña(UsuarioID, Pass)
    End Sub

    Public Function UsuarioActualizoContraseña(ByVal UsuarioID As Integer) As Boolean
        Dim objDA As New UsuariosDA
        Dim Resultado As Boolean = False
        Dim DtResultado As DataTable

        DtResultado = objDA.UsuarioActualizoContraseña(UsuarioID)

        If DtResultado.Rows.Count > 0 Then

            If CInt(DtResultado.Rows(0).Item(0)) > 0 Then
                Resultado = True
            Else
                Resultado = False
            End If
        Else
            Resultado = False
        End If

        Return Resultado
    End Function


End Class
