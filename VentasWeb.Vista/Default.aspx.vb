Imports Framework.Negocios

Public Class _Default
    Inherits Page

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Try
            Dim ObjUsuarioBu As New UsuariosBU
            Dim usuario As New Entidades.Usuarios
            usuario = ObjUsuarioBu.loginObjeto(txtUsuario.Text.ToUpper, txtContrasena.Text.ToUpper)
            If usuario Is Nothing Or usuario.PUserUsername Is Nothing Then
                ' Instanciar formulario advertencia y enviar parametro del error
                lblerror.Text = "Usuario o contraseña incorrectos"
            Else
                'redireccionar a formulario principal
                System.Web.HttpContext.Current.Session("sessionUsuario") = usuario

                Response.Redirect("Pages/principal", True)
            End If
        Catch ex As Exception
            'Dim Mensaje As New ErroresForm
            'Mensaje.mensaje = HistorialBU.GuardaError(Errores.MensajeInterno(ex))
            'Mensaje.Show()
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "Error en login")
        End Try
    End Sub
End Class