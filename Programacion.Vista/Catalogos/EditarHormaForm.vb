Public Class EditarHormaForm
    Public idHorma As Int32
    Public descripcionHorma As String
    Public activoHorma As Boolean

    Public Sub llenarDatos()
        txtCodigo.Text = idHorma.ToString
        txtDescripcion.Text = descripcionHorma
        If (activoHorma = True) Then
            rdoActivo.Checked = True
        Else
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Sub guardarHorma()
        Dim objHormaBU As New Programacion.Negocios.HormasBU
        Dim entHorma As New Entidades.Hormas
        entHorma.PidHorma = txtCodigo.Text
        entHorma.PHorma = txtDescripcion.Text
        entHorma.PActivoHorma = CBool(rdoActivo.Checked)
        objHormaBU.editarHorma(entHorma)
    End Sub

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validaModelosExisten() As Boolean
        Dim objHormaNE As New Negocios.HormasBU
        Dim dtHormaModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtHormaModelos = objHormaNE.validarExistenModelos(idHorma)
        End If

        If dtHormaModelos.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtHormaModelos.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("La horma " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtHormaModelos.Rows.Count) + " modelos activos registrados con esta horma." + vbLf + cadena, MsgBoxStyle.Information, "")
            Return False
        End If
        Return True
    End Function

    Private Sub EditarHormaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarDatos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If validaModelosExisten() = True Then
            If (validaVacio() = True) Then
                Dim objMensajeQ As New Tools.ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarHorma()
                    Dim objExito As New Tools.ExitoForm
                    objExito.mensaje = "El registro se realizó con éxito."
                    objExito.ShowDialog()
                    Me.Close()
                End If
            Else
                Dim objAdvertencia As New Tools.AdvertenciaForm
                objAdvertencia.mensaje = "Los campos marcados en rojo deben ser completados."
                objAdvertencia.ShowDialog()
            End If
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