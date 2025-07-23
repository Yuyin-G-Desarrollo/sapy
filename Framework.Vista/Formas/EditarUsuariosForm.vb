Imports Framework.Negocios
Imports Entidades

Public Class EditarUsuariosForm
    Public usuarioid As Integer
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        e.Handled = True
        If e.KeyChar Like "[A-z]" _
       Or e.KeyChar = Chr(&H8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
        If e.KeyChar Like "[A-z]" _
       Or e.KeyChar = Chr(&H8) _
            Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = False
        End If
    End Sub

    Private Sub AltasUsuariosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		'e.Handled = True
		'If e.KeyChar Like "[A-z]" _
		'    Or IsNumeric(e.KeyChar) _
		'    Or e.KeyChar = Chr(&H8) Then
		'    e.Handled = False
		'End If
		If Char.IsLower(e.KeyChar) Then
			txtPassword.SelectedText = Char.ToUpper(e.KeyChar)


			e.Handled = True
		End If
    End Sub

    Private Sub mtxConfirmarPass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtxConfirmarPass.KeyPress
		'e.Handled = True
		'If e.KeyChar Like "[A-z]" _
		'    Or IsNumeric(e.KeyChar) _
		'    Or e.KeyChar = Chr(&H8) Then
		'    e.Handled = False
		'End If
		If Char.IsLower(e.KeyChar) Then
			mtxConfirmarPass.SelectedText = Char.ToUpper(e.KeyChar)


			e.Handled = True
		End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
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
                mensaje.ShowDialog()
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

    Private Sub txtEmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        e.Handled = True
        If e.KeyChar Like "[A-z]" _
           Or IsNumeric(e.KeyChar) _
           Or e.KeyChar = Chr(&H8) _
           Or e.KeyChar = "@" _
           Or e.KeyChar = "-" _
            Or e.KeyChar = "_" _
            Or e.KeyChar = "." Then
            e.Handled = False
        End If
    End Sub

	Private Sub txtUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsername.TextChanged
		txtUsername.Enabled = False
	End Sub

	Private Sub txtPassword_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPassword.MaskInputRejected

	End Sub
End Class