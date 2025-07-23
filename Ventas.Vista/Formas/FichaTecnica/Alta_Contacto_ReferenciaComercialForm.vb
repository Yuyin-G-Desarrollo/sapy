Public Class Alta_Contacto_ReferenciaComercialForm

    Public Cliente_IdPersona As Integer
    Dim permisos As Boolean = False

    Private Sub Alta_Contacto_ReferenciaComercialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaPermisos()
        Tools.Controles.Combo_Cargo_Contacto_Sin_Area_Operativa(cmbCargo, permisos)
    End Sub
    Private Sub ConsultaPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_CONTACTO_COBRANZA") = True Then
            permisos = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub



    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        If txtNombre.Text.Trim = "" Then
            lblNombre.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If cmbCargo.SelectedIndex <= 0 Then
            lblCargo.ForeColor = Color.Red
            ValidarCamposVacios = True
        Else
            lblCargo.ForeColor = Color.Black
        End If

        Return ValidarCamposVacios

    End Function


    Private Sub GuardarContacto()
        Dim objBU As New Framework.Negocios.ContactosBU
        Try
            objBU.AltaContacto_PantallaContacto(txtNombre.Text, cmbCargo.SelectedValue, Cliente_IdPersona)
            Tools.Controles.Mensajes_Y_Alertas("EXITO", "Contacto guardado exitosamente.")
            Me.Close()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
        End Try

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarCamposVacios() = False Then
            GuardarContacto()
        Else
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "Campos Vacíos"
            objAdvertencia.ShowDialog()
            Return
        End If
    End Sub

End Class