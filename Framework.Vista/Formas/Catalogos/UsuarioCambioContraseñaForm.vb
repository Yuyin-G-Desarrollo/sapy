Imports Tools
Imports Framework.Negocios
Public Class UsuarioCambioContraseñaForm

    Public UsuarioID As Integer = 0

    Private Sub UsuarioCambioContraseñaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Enabled = False
        txtUsername.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objUsuerBu As New Framework.Negocios.UsuariosBU
        Dim ObjString As New UtileriaCadenas
        Try
            If validarVacios() = True Then
                If verificarContrasena() Then

                    If ValidarDesigualdadUsuarioContraseña() Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La contraseña no puede ser igual al usuario.")
                    Else
                        If ValidarContraseña() Then
                            objUsuerBu.CambioContraseña(UsuarioID, ObjString.StringToMd5(txtContrasena.Text.ToUpper))
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "La contraseña ha sido  modificada.")
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "la contraseña debe tener al menos 8 caracteres.")
                        End If
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Las contraseñas son diferentes.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La contraseña no puede estar vacía.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Function validarVacios() As Boolean

        If txtContrasena.Text.ToUpper = "" Or txtconfirmarContrasena.Text.ToUpper = "" Then
            lblPass.ForeColor = Color.Red
            Return False
        Else
            lblPass.ForeColor = Color.Black
            Return True
        End If


    End Function

    Public Function verificarContrasena() As Boolean
        If (txtContrasena.Text.ToUpper <> Nothing And txtconfirmarContrasena.Text.ToUpper <> Nothing) Then
            If (txtContrasena.Text.ToUpper <> txtconfirmarContrasena.Text.ToUpper) Then
                Return False
            End If
        End If
        Return True
    End Function


    Public Function ValidarContraseña() As Boolean

        If txtContrasena.Text.Length >= 8 And txtconfirmarContrasena.Text.Length >= 8 Then
            Return True
        End If

        Return False

    End Function

    Public Function ValidarDesigualdadUsuarioContraseña() As Boolean
        If (txtContrasena.Text.ToUpper <> txtUsername.Text.ToUpper) Then
            Return False
        End If
        Return True
    End Function


End Class