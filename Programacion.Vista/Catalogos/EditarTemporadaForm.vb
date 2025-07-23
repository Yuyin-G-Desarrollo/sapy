Imports Tools

Public Class EditarTemporadaForm
    Dim IdTemporada As Int32
    Dim activo As Boolean

    Public Sub LlenarDatosTemporada(ByVal entidadTemporada As Entidades.Temporadas)
        IdTemporada = entidadTemporada.pIdTemporada
        activo = entidadTemporada.pActivoTemporada
        txtCodigo.Text = entidadTemporada.pCodigoTemporada
        txtAnio.Text = entidadTemporada.pAnioTemporada
        txtNombre.Text = entidadTemporada.pNombreTemporada
        If (entidadTemporada.pActivoTemporada = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadTemporada.pActivoTemporada = False) Then
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Function validarRepetidos() As Boolean
        Dim objSBU As New Programacion.Negocios.TemporadasBU
        Dim dtContadorRepetidos As DataTable
        Dim contador As Int32 = 0
        Dim codigo As String = txtCodigo.Text
        dtContadorRepetidos = objSBU.validarRepetidos(codigo)
        contador = Convert.ToInt32(dtContadorRepetidos.Rows(0)(0).ToString)
        If (contador >= 1) Then
            If (activo = False) Then
                If (rdoInactivo.Checked = True) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Public Function validaVacio() As Boolean
        If (txtNombre.Text = Nothing) Then
            lblNombre.ForeColor = Drawing.Color.Red
            Return False
        End If
        If (txtAnio.Text = Nothing Or txtAnio.TextLength < 4 Or txtAnio.TextLength > 4) Then
            lblAnio.ForeColor = Drawing.Color.Red
            Return False
        End If
        lblNombre.ForeColor = Drawing.Color.Black
        lblAnio.ForeColor = Drawing.Color.Black
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objTempNE As New Negocios.TemporadasBU
        Dim dtDatosTempModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtDatosTempModelos = objTempNE.ValidarExistenModelos(IdTemporada)
        End If

        If (dtDatosTempModelos.Rows.Count > 0) Then
            MsgBox("La temporada " + txtNombre.Text + " no puede ser inactivada, debido a que existen " + CStr(dtDatosTempModelos.Rows.Count) + " modelos activos registrados con esta temporada.")
            Return False
        End If
        Return True
    End Function

    Public Sub guardarCambios()
        Dim objTBU As New Programacion.Negocios.TemporadasBU
        Dim TemporadaEntidad As New Entidades.Temporadas
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        TemporadaEntidad.pIdTemporada = IdTemporada.ToString
        TemporadaEntidad.pCodigoTemporada = txtCodigo.Text
        TemporadaEntidad.pNombreTemporada = txtNombre.Text
        TemporadaEntidad.pAnioTemporada = txtAnio.Text
        If (rdoActivo.Checked = True) Then
            TemporadaEntidad.pActivoTemporada = True
        ElseIf (rdoInactivo.Checked = True) Then
            TemporadaEntidad.pActivoTemporada = False
        End If
        objTBU.EditarTemporada(TemporadaEntidad, usuario)
    End Sub

    Private Sub EditarTemporadaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNombre.ForeColor = Drawing.Color.Black
        lblAnio.ForeColor = Drawing.Color.Black
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validaExistenModelos() = True Then
            If (validarRepetidos() = True) Then
                If (validaVacio() = True) Then

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
                Else
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "Los campos marcados en rojo deben ser completados correctamente."
                    mensaje.ShowDialog()
                End If
            Else
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "No puede activar este registro debido a que el código se encuentra activo en otra temporada."
                mensaje.ShowDialog()
            End If
        Else
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAnio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnio.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtAnio.Text.Length < 4) Then

            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtAnio.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class