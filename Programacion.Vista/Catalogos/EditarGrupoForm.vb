Imports Tools

Public Class EditarGrupoForm

    Public Sub LlenarDatos(ByVal entidadGrupo As Entidades.Grupos)
        txtCodigo.Text = entidadGrupo.PGrupoId
        txtDescripcion.Text = entidadGrupo.PGDescripcion
        If (entidadGrupo.PGActivo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadGrupo.PGActivo = False) Then
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Sub GuardarCambios()
        Dim grupoNegocios As New Programacion.Negocios.GruposBU
        Dim entidadGrupo As New Entidades.Grupos
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidadGrupo.PGrupoId = txtCodigo.Text
        entidadGrupo.PGDescripcion = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            entidadGrupo.PGActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadGrupo.PGActivo = False
        End If
        grupoNegocios.EditarGrupo(entidadGrupo, usuario)
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objGrupoNE As New Negocios.GruposBU
        Dim dtModelosGrupo As New DataTable

        If rdoActivo.Checked = False Then
            dtModelosGrupo = objGrupoNE.validaExistenModelos(txtCodigo.Text)
        End If

        If dtModelosGrupo.Rows.Count > 0 Then
            MsgBox("El grupo " + txtDescripcion.Text + " no puede ser inactivado, debido a que existen " + CStr(dtModelosGrupo.Rows.Count) + " modelos activos registrados con este grupo.", MsgBoxStyle.Information, "")
            Return False
        End If
        Return True
    End Function

    Private Sub EditarGrupoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validaExistenModelos() = True Then
            If (ValidarVacio() = True) Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    GuardarCambios()
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Me.Close()
                Else
                End If
            ElseIf (ValidarVacio() = False) Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "Los campos marcados en rojo deben ser llenados."
                mensaje.ShowDialog()
            End If
        Else
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 100) Then
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