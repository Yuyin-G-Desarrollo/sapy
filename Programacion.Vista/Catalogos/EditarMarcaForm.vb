Imports Tools

Public Class EditarMarcaForm
    Dim ActivoInactivo As Boolean
    Dim IdMarca As Int32

    ' ''llena los campos del formulario con los datos que seleccionados para modificar
    Public Sub LlenarDatosMarcaModificar(ByVal EntidadMarca As Entidades.Marcas)
        txtCodigo.Text = EntidadMarca.PCodigo.ToString
        txtDescripcion.Text = EntidadMarca.PDescripcion
        txtCodigoSicy.Text = EntidadMarca.PSicyCodigo
        IdMarca = EntidadMarca.PMarcaId
        If (EntidadMarca.PClienteMarca = True) Then
            ckbCliente.Checked = True
        ElseIf (EntidadMarca.PClienteMarca = False) Then
            ckbCliente.Checked = False
        End If

        If (EntidadMarca.PActivo = True) Then
            rdoActivo.Checked = True
            ActivoInactivo = True
        ElseIf (EntidadMarca.PActivo = False) Then
            rdoInactivo.Checked = True
            ActivoInactivo = False
        End If
    End Sub

    ' ''valida que al modificar el estatus de inactivo a activo en un registro, el codigo de este no este siendo usado por un registro activo
    Public Function validarExistente() As Boolean
        Dim MarcaNegocio As New Programacion.Negocios.MarcasBU
        Dim codigoTxt As String = txtCodigo.Text.Trim
        Dim datoRegreso As DataTable
        datoRegreso = New DataTable
        datoRegreso = MarcaNegocio.ValidarRepetidos(codigoTxt)
        If (datoRegreso.Rows.Count >= 1) Then
            Return False
        End If
        Return True
    End Function

    ' ''metodo que depende de la validacion validarExistente para guardar o no los cambios de una modificacion 
    Public Sub GuardarRegistro()
        Dim MarcaEntidad As New Entidades.Marcas
        MarcaEntidad.PMarcaId = IdMarca
        MarcaEntidad.PCodigo = txtCodigo.Text.Trim
        MarcaEntidad.PDescripcion = txtDescripcion.Text.Trim
        MarcaEntidad.PSicyCodigo = txtCodigoSicy.Text.Trim
        MarcaEntidad.PComercializadora = CInt(cmbCEDIS.SelectedValue)
        If (ckbCliente.Checked = True) Then
            MarcaEntidad.PClienteMarca = True
        ElseIf (ckbCliente.Checked = False) Then
            MarcaEntidad.PClienteMarca = False
        End If
        If (rdoActivo.Checked) Then
            MarcaEntidad.PActivo = True
        ElseIf (rdoInactivo.Checked) Then
            MarcaEntidad.PActivo = False
        End If
        Dim UsuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If (validarExistente() = False) Then
            If (ActivoInactivo = True) Then
                Dim EditaDatosMarca As New Programacion.Negocios.MarcasBU
                EditaDatosMarca.EditarMarca(MarcaEntidad, UsuarioModifico)
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se modificó exitosamente."
                mensaje.ShowDialog()
            ElseIf (ActivoInactivo = False) Then
                If (rdoInactivo.Checked = True) Then
                    Dim EditaDatosMarca As New Programacion.Negocios.MarcasBU
                    EditaDatosMarca.EditarMarca(MarcaEntidad, UsuarioModifico)
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro inactivo se modificó exitosamente."
                    mensaje.ShowDialog()
                ElseIf (rdoActivo.Checked = True) Then
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "Este registro no puede ser activado, debido a que existe una marca activa con el mismo código."
                    mensaje.ShowDialog()
                End If
            End If
        Else
            Dim EditaDatosMarca As New Programacion.Negocios.MarcasBU
            EditaDatosMarca.EditarMarca(MarcaEntidad, UsuarioModifico)
            Dim mensaje As New ExitoForm
            mensaje.mensaje = "El registro se modificó exitosamente."
            mensaje.ShowDialog()

        End If
    End Sub

    ' ''metodo que valida campos vacios
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

    Public Function validarModelosMarcaExistencia() As Boolean
        Dim objMarcaN As New Negocios.MarcasBU
        Dim dtDatosMarcaModulos As New DataTable

        If rdoActivo.Checked = False Then
            dtDatosMarcaModulos = objMarcaN.validarInactivarMarca(IdMarca)
        End If

        If dtDatosMarcaModulos.Rows.Count > 0 Then
            MsgBox("La marca " + txtDescripcion.Text + " no puede ser inactivada debido a que existen " + CStr(CInt(dtDatosMarcaModulos.Rows.Count.ToString)).ToString + " modelos activos registrados con esta marca.", MsgBoxStyle.Information, "")
            Return False
        End If

        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarModelosMarcaExistencia() = True Then
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

    Private Sub EditarMarcaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtDescripcion.Focus()
        lblCodigo.ForeColor = Drawing.Color.Black
        lblDescripcion.ForeColor = Drawing.Color.Black
        cmbCEDIS = Utilerias.ComboObtenerCEDIS(cmbCEDIS)
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If

    End Sub

    Private Sub txtCodigoSicy_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoSicy.DoubleClick

    End Sub

    Private Sub txtCodigoSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigoSicy.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodigoSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class