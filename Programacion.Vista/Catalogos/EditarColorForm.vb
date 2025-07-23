Imports Tools

Public Class EditarColorForm

    Public Sub recibirDatosColor(ByVal entidadColor As Entidades.Colores)
        txtCodigo.Text = entidadColor.PColorId
        txtDescripcion.Text = entidadColor.PCDescripcion
        txtCodSicy.Text = entidadColor.PCCodSicy
        If (entidadColor.PCActivo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadColor.PCActivo = False) Then
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Sub guardarCambios()
        Dim ColorNegocio As New Programacion.Negocios.ColoresBU
        Dim entidadColor As New Entidades.Colores
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidadColor.PColorId = txtCodigo.Text
        entidadColor.PCDescripcion = txtDescripcion.Text
        entidadColor.PCCodSicy = txtCodSicy.Text
        If (rdoActivo.Checked = True) Then
            entidadColor.PCActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadColor.PCActivo = False
        End If
        ColorNegocio.editarColor(entidadColor, usuario)
    End Sub

    Public Function ValidaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objColorNe As New Negocios.ColoresBU
        Dim dtModelosColor As New DataTable

        If rdoActivo.Checked = False Then
            dtModelosColor = objColorNe.VerColoresModelosExisten(txtCodigo.Text)
        End If

        If dtModelosColor.Rows.Count > 0 Then
            If dtModelosColor.Rows.Count > 0 Then
                Dim cadena As String = "Modelos: "
                For Each row As DataRow In dtModelosColor.Rows
                    cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
                Next
                MsgBox("El color " + txtDescripcion.Text + " no puede ser inactivado, debido a que existen " + CStr(dtModelosColor.Rows.Count) + " modelos activos registrados con este color." + vbLf + cadena, MsgBoxStyle.Information, "")
                Return False
            End If
        End If

        Return True
    End Function


    Private Sub EditarColorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If validaExistenModelos() = True Then
            If (ValidaVacio() = True) Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarCambios()
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Me.Close()
                Else
                End If

            ElseIf (ValidaVacio() = False) Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
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
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 2) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class