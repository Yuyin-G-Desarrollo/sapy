Imports Tools

Public Class EditarForroForm
    Dim idForro As Int32

    Public Sub recibirDatos(ByVal entidadForro As Entidades.Forros)
        If (entidadForro.ForroActivo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadForro.ForroActivo = False) Then
            rdoInactivo.Checked = True
        End If
        idForro = entidadForro.ForroId
        txtCodigo.Text = entidadForro.ForroCodigo
        txtDescripcion.Text = entidadForro.ForroDescripcion


    End Sub

    Public Sub EditarForro()
        Dim entidadForro As New Entidades.Forros
        Dim ForroNegocios As New Programacion.Negocios.ForrosBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidadForro.ForroDescripcion = txtDescripcion.Text
        entidadForro.ForroId = idForro
        If (rdoActivo.Checked = True) Then
            entidadForro.ForroActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadForro.ForroActivo = False
        End If

        ForroNegocios.EditarForro(entidadForro, usuario)

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

    Public Function validarExistenModelos() As Boolean
        Dim objForroNE As New Negocios.ForrosBU
        Dim dtForrosModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtForrosModelos = objForroNE.validaExistenModelos(idForro)
        End If

        If dtForrosModelos.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtForrosModelos.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("El forro " + txtDescripcion.Text + " no puede ser inactivado, debido a que existen " + CStr(dtForrosModelos.Rows.Count) + " modelos activos registrados con este forro." + vbLf + cadena, MsgBoxStyle.Information, "")
            Return False
        End If
        Return True
    End Function

    Private Sub EditarForroForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarExistenModelos() = True Then
            If (ValidarVacio() = True) Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    EditarForro()
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