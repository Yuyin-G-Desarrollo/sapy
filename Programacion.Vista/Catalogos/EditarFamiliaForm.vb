Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class EditarFamiliaForm
    Dim IdFamilia As Int32
    Dim ActivoInactivo As String

    Public Sub LlenarDatosFamilia(ByVal EntidadFamilia As Entidades.Familias)
        txtCodigo.Text = EntidadFamilia.PCodigo.ToString
        txtDescripcion.Text = EntidadFamilia.PDescripcion
        IdFamilia = EntidadFamilia.PIdFamilia

        If (EntidadFamilia.PActivo = True) Then
            rdoActivo.Checked = True
            ActivoInactivo = "True"
        ElseIf (EntidadFamilia.PActivo = False) Then
            rdoInactivo.Checked = True
            ActivoInactivo = "False"
        End If
        'llenarTablaTallas()
    End Sub

    Public Function validarExistente() As Boolean
        Dim FamiliaNegocio As New Programacion.Negocios.FamiliasBU
        Dim codigoTxt As String = txtCodigo.Text.Trim
        Dim datoRegreso As DataTable
        datoRegreso = New DataTable
        datoRegreso = FamiliaNegocio.ValidarRepetidos(codigoTxt)
        If (datoRegreso.Rows.Count >= 1) Then
            Return False
        End If
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objFamDa As New Negocios.FamiliasBU
        Dim dtModelosExisten As New DataTable

        If rdoActivo.Checked = False Then
            dtModelosExisten = objFamDa.validaExistenModelos(IdFamilia)
        End If

        If dtModelosExisten.Rows.Count > 0 Then
            MsgBox("La familia " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtModelosExisten.Rows.Count) + " modelos activos registrados con esta familia.", MsgBoxStyle.Information, "")
            Return False
        End If

        Return True
    End Function

    'Public Sub guardarCambiosFamTallas()
    '    Dim EditaDatosFamilia As New Programacion.Negocios.FamiliasBU
    '    EditaDatosFamilia.editarEstatusFamTallas(IdFamilia)

    '    For Each rowsDT As UltraGridRow In grdTallas.Rows
    '        Dim SDF As Boolean = rowsDT.Cells("tallaSeleccionada").Value
    '        If CBool(rowsDT.Cells("tallaSeleccionada").Value) = True Then
    '            If rowsDT.Cells("talla_tallaid").Value.ToString <> "" Then
    '                EditaDatosFamilia.editarFamiliaTallas(IdFamilia, CInt(rowsDT.Cells("talla_tallaid").Value))
    '            End If
    '        End If
    '    Next
    'End Sub

    Public Sub GuardarRegistro()
        Dim EnFamilia As New Entidades.Familias
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EnFamilia.PDescripcion = txtDescripcion.Text.Trim
        EnFamilia.PCodigo = txtCodigo.Text.Trim
        EnFamilia.PIdFamilia = IdFamilia

        If (rdoActivo.Checked) Then
            EnFamilia.PActivo = True
        ElseIf (rdoInactivo.Checked) Then
            EnFamilia.PActivo = False
        End If

        If (validarExistente() = False) Then
            If (ActivoInactivo = "True") Then


                Dim EditaDatosFamilia As New Programacion.Negocios.FamiliasBU
                EditaDatosFamilia.EditarFamilia(EnFamilia, UsuarioModifico)
                'guardarCambiosFamTallas()

                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se modificó exitosamente."
                mensaje.ShowDialog()
            ElseIf (ActivoInactivo = "False") Then
                If (rdoInactivo.Checked = True) Then

                    Dim EditaDatosFamilia As New Programacion.Negocios.FamiliasBU
                    EditaDatosFamilia.EditarFamilia(EnFamilia, UsuarioModifico)
                    'guardarCambiosFamTallas()

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
            Dim EditaDatosFamilia As New Programacion.Negocios.FamiliasBU
            EditaDatosFamilia.EditarFamilia(EnFamilia, UsuarioModifico)
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


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validaExistenModelos() = True Then
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

    'Public Sub llenarTablaTallas()
    '    Dim objFamilia As New Negocios.FamiliasBU
    '    Dim dtDatosTabla As DataTable
    '    dtDatosTabla = objFamilia.seleccionarTallasEnFamilia(IdFamilia)
    '    grdTallas.DataSource = dtDatosTabla

    '    Me.grdTallas.DisplayLayout.Bands(0).Columns.Add("tallaSeleccionada", "Selección")
    '    Dim colckbFr As UltraGridColumn = grdTallas.DisplayLayout.Bands(0).Columns("tallaSeleccionada")
    '    colckbFr.Style = ColumnStyle.CheckBox
    '    colckbFr.CellActivation = Activation.AllowEdit

    '    Dim colEnteros As UltraGridColumn = grdTallas.DisplayLayout.Bands(0).Columns("talla_enteros")
    '    colEnteros.Style = ColumnStyle.CheckBox
    '    colEnteros.CellActivation = Activation.AllowEdit

    '    For Each rowDTT As UltraGridRow In grdTallas.Rows
    '        If rowDTT.Cells("seleccionado").Value = 1 Then
    '            rowDTT.Cells("tallaSeleccionada").Value = True
    '        Else
    '            rowDTT.Cells("tallaSeleccionada").Value = False
    '        End If
    '    Next

    '    With grdTallas.DisplayLayout.Bands(0)
    '        .Columns("talla_tallaid").Hidden = True
    '        .Columns("seleccionado").Hidden = True
    '        .Columns("talla_descripcion").Header.Caption = "Tallas"
    '        .Columns("talla_enteros").Header.Caption = "Solo Enteros"
    '        .Columns("tallaSeleccionada").Header.Caption = "Selección"
    '        .Columns("pais_nombre").Header.Caption = "País"
    '        .Columns("talla_descripcion").CellActivation = Activation.NoEdit
    '        .Columns("talla_enteros").CellActivation = Activation.NoEdit
    '        .Columns("pais_nombre").CellActivation = Activation.NoEdit
    '        .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
    '    End With
    '    grdTallas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    'End Sub


    Private Sub EditarFamiliaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
End Class