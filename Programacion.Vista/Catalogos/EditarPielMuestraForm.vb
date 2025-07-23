Imports Tools

Public Class EditarPielMuestraForm
    Dim idPielMuestra As Int32

    Public Sub LLenarCampos(ByVal entidadPielMuestra As Entidades.PielesMuestra)
        txtCodigo.Text = entidadPielMuestra.PiMuCodigo
        txtDescripcion.Text = entidadPielMuestra.PiMuDescripcion
        If (entidadPielMuestra.PiMuActivo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadPielMuestra.PiMuActivo = False) Then
            rdoInactivo.Checked = True
        End If
        idPielMuestra = entidadPielMuestra.PiMUId

    End Sub

    Public Sub EditarPielMuestra()
        Dim EntidadPielMuestra As New Entidades.PielesMuestra
        Dim pielMuestraNegocio As New Programacion.Negocios.PielesMuestraBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If (rdoActivo.Checked = True) Then
            EntidadPielMuestra.PiMuActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EntidadPielMuestra.PiMuActivo = False
        End If
        EntidadPielMuestra.PiMuDescripcion = txtDescripcion.Text
        EntidadPielMuestra.PiMUId = idPielMuestra
        pielMuestraNegocio.EditarPielMuestra(EntidadPielMuestra, usuario)
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            Return True
        End If
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objPM As New Negocios.PielesMuestraBU
        Dim dtModelosExistenPM As New DataTable

        If rdoActivo.Checked = False Then
            dtModelosExistenPM = objPM.validaExistenModelos(idPielMuestra)
        End If

        If dtModelosExistenPM.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtModelosExistenPM.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("El corte " + txtDescripcion.Text + " no puede ser inactivado, debido a que existen " + CStr(dtModelosExistenPM.Rows.Count) + " modelos activos registrados con este corte." + vbLf + cadena, MsgBoxStyle.Information, "")
            Return False
        End If
        Return True
    End Function

    Private Sub EditarPielMuestraForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDescripcion.ForeColor = Drawing.Color.Black
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If validaExistenModelos() = True Then
            If (ValidarVacio() = True) Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    EditarPielMuestra()
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Me.Close()
                Else
                End If

            ElseIf (ValidarVacio() = False) Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
                mensaje.ShowDialog()
            End If
        Else
        End If


    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class