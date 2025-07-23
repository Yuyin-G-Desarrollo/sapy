Imports Tools

Public Class EditarSubfamiliaForm
    Dim IdFamilia As Int32
    Dim ActivoInactivo As Boolean

    Public Sub LlenarDatosSubfamilia(ByVal EntidadSubfamilia As Entidades.Subfamilias)

        txtCodigo.Text = EntidadSubfamilia.PIdSubfamilia.ToString
        txtDescripcion.Text = EntidadSubfamilia.PDescripcion
        IdFamilia = EntidadSubfamilia.PIdSubfamilia

        If (EntidadSubfamilia.PActivo = True) Then
            rdoActivo.Checked = True
            ActivoInactivo = True
        ElseIf (EntidadSubfamilia.PActivo = False) Then
            rdoInactivo.Checked = True
            ActivoInactivo = False
        End If
    End Sub


    Public Function validarExistente() As Boolean
        Dim objSub As New Programacion.Negocios.SubfamiliasBU
        Dim codigoTxt As String = txtCodigo.Text.Trim
        Dim datoRegreso As DataTable
        datoRegreso = New DataTable
        datoRegreso = objSub.ValidarRepetidos(codigoTxt)
        If (datoRegreso.Rows.Count >= 1) Then
            Return False
        End If
        Return True
    End Function


    Public Sub GuardarRegistro()
        Dim EnSubfamilia As New Entidades.Subfamilias
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EnSubfamilia.PDescripcion = txtDescripcion.Text.Trim
        'EnSubfamilia.PCodigo = txtCodigo.Text.Trim
        EnSubfamilia.PIdSubfamilia = IdFamilia

        If (rdoActivo.Checked) Then
            EnSubfamilia.PActivo = True
        ElseIf (rdoInactivo.Checked) Then
            EnSubfamilia.PActivo = False
        End If

        If (validarExistente() = False) Then
            If (ActivoInactivo = True) Then
                Dim EditaDatosSubFamilia As New Programacion.Negocios.SubfamiliasBU
                EditaDatosSubFamilia.EditarSubfamilia(EnSubfamilia, UsuarioModifico)
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se modificó exitosamente."
                mensaje.ShowDialog()
            ElseIf (ActivoInactivo = False) Then
                If (rdoInactivo.Checked = True) Then
                    Dim EditaDatosSubFamilia As New Programacion.Negocios.SubfamiliasBU
                    EditaDatosSubFamilia.EditarSubfamilia(EnSubfamilia, UsuarioModifico)
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro inactivo se modificó exitosamente."
                    mensaje.ShowDialog()
                ElseIf (rdoActivo.Checked = True) Then
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "Este registro no puede ser activado, debido a que existe una familia activa con el mismo código."
                    mensaje.ShowDialog()
                End If
            End If
        Else
            Dim EditaDatosSubFamilia As New Programacion.Negocios.SubfamiliasBU
            EditaDatosSubFamilia.EditarSubfamilia(EnSubfamilia, UsuarioModifico)
            Dim mensaje As New ExitoForm
            mensaje.mensaje = "El registro se modificó exitosamente."
            mensaje.ShowDialog()

        End If
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtCodigo.Text.Trim = Nothing Or txtDescripcion.Text.Trim = Nothing) Then
            If (txtCodigo.Text.Trim = Nothing) Then
                lblCodigo.ForeColor = Drawing.Color.Red
            Else
                lblCodigo.ForeColor = Drawing.Color.Black
            End If
            If (txtDescripcion.Text.Trim = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            Return False
        End If
        lblCodigo.ForeColor = Drawing.Color.Black
        lblDescripcion.ForeColor = Drawing.Color.Black
        Return True
    End Function

    Public Function validarExistenModelos() As Boolean
        Dim objSubNE As New Negocios.SubfamiliasBU
        Dim dtSubModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtSubModelos = objSubNE.validarInactivarSub(IdFamilia)
        End If

        If dtSubModelos.Rows.Count > 0 Then
            MsgBox("La Subfamilia " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtSubModelos.Rows.Count) + " modelos registrados con esta subfamilia.", MsgBoxStyle.Information, "")
            Return False
        End If

        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarExistenModelos() = True Then
            If (ValidarVacio() = True) Then

                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    GuardarRegistro()
                    Me.Close()
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

    Private Sub EditarSubfamiliaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class