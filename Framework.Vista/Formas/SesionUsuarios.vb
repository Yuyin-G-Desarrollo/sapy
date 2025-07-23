Imports Entidades
Imports Framework.Negocios

Public Class SesionUsuarios
	Public usuarioid As Integer

	Private Sub MDIUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		'Dim usuario As New Entidades.Usuarios



        'Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'Label2.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Label2.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		'MessageBox.Show(usuarioid.ToString)
		'Buscar Usuario con ese id
		Dim usuario As New Usuarios
		Dim objBU As New Negocios.UsuariosBU
		usuario = objBU.buscarUsuario(usuarioid)

		txtUsername.Text = usuario.PUserUsername
		txtNombre.Text = usuario.PUserNombreReal
		txtEmail.Text = usuario.PUserEmail
		rdbActivo.Checked = usuario.PUserActive

		If (usuario.PUserActive = False) Then
			rdbInactivo.Checked = True
		End If
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim mensaje As New AdvertenciaForm
		Dim mensajeExito As New ExitoForm
		Dim objUsuariosBu As New UsuariosBU
		If validarNulos() = False Then
			mensaje.mensaje = "Existen campos sin completar."
            mensaje.ShowDialog()
		Else
			If Not (txtPassword.Text = mtxConfirmarPass.Text) Then
				mensaje.mensaje = "La contraseña y su confirmación no coinciden."
				lblPass.ForeColor = Color.Maroon
				lblConfirmaPass.ForeColor = Color.Maroon
				mensaje.Show()
			Else
				lblPass.ForeColor = Color.Black
				lblConfirmaPass.ForeColor = Color.Black

				'Llena el objeto usuarios con la información capturada
				Dim usuario As New Entidades.Usuarios
				usuario.PUserUsername = txtUsername.Text
				usuario.PUserNombreReal = txtNombre.Text
				usuario.PUserMd5 = txtPassword.Text
				usuario.PUserEmail = txtEmail.Text
				usuario.PUserActive = rdbActivo.Checked
				usuario.PUserUsuarioid = usuarioid
				Try
					objUsuariosBu.editarUsuario(usuario)
					mensajeExito.mensaje = "Usuario guardado."
					mensajeExito.Show()
					Me.Close()
				Catch ex As Exception
					Dim Fail As New ErroresForm
					Fail.mensaje = HistorialBU.GuardaError(Errores.MensajeInterno(ex))
					Fail.Show()
				End Try

			End If
		End If
	End Sub
	Private Function validarNulos() As Boolean
		validarNulos = True
		If txtUsername.TextLength <= 0 Then
			lblUsername.ForeColor = Color.Maroon
			validarNulos = False
		Else
			lblUsername.ForeColor = Color.Black
		End If
		If txtNombre.TextLength <= 0 Then
			lblNombre.ForeColor = Color.Maroon
			validarNulos = False
		Else
			lblNombre.ForeColor = Color.Black
		End If
		If txtEmail.TextLength <= 0 Then
			lblEmail.ForeColor = Color.Maroon
			validarNulos = False
		Else
			lblEmail.ForeColor = Color.Black
		End If


	End Function

	Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
		Me.Close()

	End Sub

	Private Sub txtUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsername.TextChanged
		txtUsername.Enabled = False
	End Sub

	Private Sub txtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombre.TextChanged
		txtNombre.Enabled = False
	End Sub

	Private Sub txtEmail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmail.TextChanged
		txtEmail.Enabled = False
	End Sub

	Private Sub rdbActivo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbActivo.CheckedChanged
		rdbActivo.Enabled = False
		rdbInactivo.Enabled = False
	End Sub

	Private Sub txtPassword_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPassword.MaskInputRejected

	End Sub

	Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		If Char.IsLower(e.KeyChar) Then
			txtPassword.SelectedText = Char.ToUpper(e.KeyChar)


			e.Handled = True
		End If
	End Sub

	Private Sub mtxConfirmarPass_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles mtxConfirmarPass.KeyPress
		If Char.IsLower(e.KeyChar) Then
			mtxConfirmarPass.SelectedText = Char.ToUpper(e.KeyChar)


			e.Handled = True
		End If
	End Sub
End Class