
Imports Framework.Negocios
Imports Entidades
Imports Nomina.Vista

Public Class LoginForm

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresar.Click
			Try
            Dim ObjUsuarioBu As New UsuariosBU

            If ObjUsuarioBu.login(txtUsername.Text, txtContrasena.Text) = False Then
                ' Instanciar formulario advertencia y enviar parametro del error
                Dim Mensaje As New AdvertenciaForm
                Mensaje.mensaje = "Nombre de Usuario y/o contraseña incorrectos."
                Mensaje.Show()
            Else
                If ObjUsuarioBu.UsuarioActualizoContraseña(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) = True Then
                    'Formulario del say original
                    Dim Main As New MDIParent
                    Main.Show()
                    Me.Hide()
                Else
                    Dim CambioContraseñaForm As New UsuarioCambioContraseñaForm
                    CambioContraseñaForm.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    If CambioContraseñaForm.ShowDialog() = DialogResult.OK Then
                        Dim Main As New MDIParent
                        Main.Show()
                        Me.Hide()
                    Else
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'Dim Mensaje As New ErroresForm
            'Mensaje.mensaje = HistorialBU.GuardaError(Errores.MensajeInterno(ex))
            'Mensaje.Show()
        End Try
    End Sub


    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        txtUsername.Focus()
    End Sub

    Private Sub LoginForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown



    End Sub

    Private Sub txtUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsername.TextChanged
        'If txtUsername.Text = "TESTER" Then
        'Else
        '	'btnIngresar.Visible = False
        '	Button1.Visible = True
        'End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress

        'If txtUsername.Text = "TESTER" Then
        'Else
        '	btnIngresar.Visible = False
        '	Button1.Visible = True
        'End If

        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

        'If Char.IsLower(e.KeyChar) Then

        '	txtUsername.SelectedText = Char.ToUpper(e.KeyChar)



        '	e.Handled = True
        'End If
    End Sub

    Private Sub txtContrasena_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtContrasena.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtContrasena.SelectedText = Char.ToUpper(e.KeyChar)


            e.Handled = True
        End If
    End Sub

    Private Sub btnIngresar_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles btnIngresar.KeyDown

    End Sub


    Private Sub OnKeyDownHandler(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtContrasena.KeyDown
        Try
            If (e.KeyValue = Keys.Enter) Then
                Dim ObjUsuarioBu As New UsuariosBU
                If ObjUsuarioBu.login(txtUsername.Text, txtContrasena.Text) = True Then

                    ''Formulario del validador
                    'Dim Main As New ValidadorCFDIForm
                    'Main.Show()
                    'Me.Hide()


                    If ObjUsuarioBu.UsuarioActualizoContraseña(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) = True Then
                        'Formulario del say original
                        Dim Main As New MDIParent
                        Main.Show()
                        Me.Hide()
                    Else
                        Dim CambioContraseñaForm As New UsuarioCambioContraseñaForm
                        CambioContraseñaForm.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        If CambioContraseñaForm.ShowDialog() = DialogResult.OK Then
                            Dim Main As New MDIParent
                            Main.Show()
                            Me.Hide()
                        Else
                            Me.Close()
                        End If
                    End If


                Else
                    Dim Mensaje As New AdvertenciaForm
                    Mensaje.mensaje = "Nombre de Usuario y/o contraseña incorrectos."
                    Mensaje.Show()


                End If

                'txtUsername.Text = "You Entered: " + txtContrasena.Text
                'btnIngresar.Text = CStr(MDIMain.ShowDialog)
                'Else
                '	If ObjUsuarioBu.login(txtUsername.Text, txtContrasena.Text) = False Then
                '		' Instanciar formulario advertencia y enviar parametro del error
                '		Dim Mensaje As New AdvertenciaForm
                '		Mensaje.mensaje = "Nombre de Usuario y/o contraseña incorrectos."
                '		Mensaje.Show()
                '	Else
                '		Dim Main As New MDIMain
                '		Main.Show()
                '		Me.Hide()

                '	End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            'Dim Mensaje As New ErroresForm
            'Mensaje.mensaje = HistorialBU.GuardaError(Errores.MensajeInterno(ex))
            'Mensaje.Show()

        End Try

    End Sub

	Private Sub txtContrasena_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContrasena.TextChanged

	End Sub

	Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
		ListaCadenaConexionForm.ShowDialog()
	End Sub

    Private Sub btnIngresar_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.VisibleChanged

    End Sub

	Private Sub txtUsername_Leave(sender As System.Object, e As System.EventArgs) Handles txtUsername.Leave
		If txtUsername.Text = "TESTER" Then
			btnTest.Visible = True
		End If
	End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class