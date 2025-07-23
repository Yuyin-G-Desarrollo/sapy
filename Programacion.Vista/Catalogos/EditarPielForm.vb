Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class EditarPielForm
    Dim idPiel As Int32

    Public Sub LlenarTablaColores()
        Dim objPiel As New Programacion.Negocios.PielesBU
        Dim dtDatosColores As DataTable
        dtDatosColores = objPiel.verColoresSeleccionadosPiel(idPiel.ToString)
        grdColores.DataSource = dtDatosColores

        'grdColoresNormal.Columns(1).HeaderText = "Cod"
        'grdColoresNormal.Columns(2).HeaderText = "Color"
        'grdColoresNormal.Columns(3).HeaderText = "Código Sicy"
        'grdColoresNormal.Columns(4).Visible = False

        Me.grdColores.DisplayLayout.Bands(0).Columns.Add("selectColor", "")
        Dim colckbTalla As UltraGridColumn = grdColores.DisplayLayout.Bands(0).Columns(4)
        colckbTalla.Style = ColumnStyle.CheckBox
        colckbTalla.CellActivation = Activation.AllowEdit

        With grdColores
            .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código"
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Color"
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "SICY"
            .DisplayLayout.Bands(0).Columns(0).Width = 50
            .DisplayLayout.Bands(0).Columns(2).Width = 50
            '-deshabilita escritura en todas las filas del grid
            ''Me.grdColores.DisplayLayout.Bands(0).Override.AllowUpdate = DefaultableBoolean.False
            .DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Appearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Appearance.BorderColor = Color.DarkGray
        End With

        For Each row As UltraGridRow In grdColores.Rows
            row.Cells(4).Value = False
        Next

        Dim contGrid As Int32 = 0
        For Each rowData As DataRow In dtDatosColores.Rows
            If (rowData.Item(3).ToString <> Nothing) Then
                grdColores.Rows(contGrid).Cells(4).Value = True
            End If
            contGrid = contGrid + 1
        Next
        formatoGrid()
    End Sub

    Public Sub formatoGrid()

        'grdColores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)

        grdColores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColores.DisplayLayout.Bands(0).Columns("color_colorid").Width = 30
        grdColores.DisplayLayout.Bands(0).Columns("color_codsicy").Width = 30
        grdColores.DisplayLayout.Bands(0).Columns("selectColor").Width = 30
    End Sub

    Public Sub LLenarCampos(ByVal entidadPiel As Entidades.Pieles)
        If (entidadPiel.PPActivo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadPiel.PPActivo = False) Then
            rdoInactivo.Checked = True
        End If
        idPiel = entidadPiel.PPielId
        txtCodigo.Text = entidadPiel.PPielCodigo
        txtNombreCorto.Text = entidadPiel.PPNombreCorto
        txtDescripcion.Text = entidadPiel.PPielDescripcion
        txtCodSicy.Text = entidadPiel.PPCodSicy

    End Sub

    Public Function validarVacio() As Boolean
        If (txtDescripcion.Text = Nothing Or txtNombreCorto.Text = Nothing) Then
            If (txtDescripcion.Text = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            If (txtNombreCorto.Text = Nothing) Then
                lblNombreCorto.ForeColor = Drawing.Color.Red
            Else
                lblNombreCorto.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            lblNombreCorto.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objPielN As New Negocios.PielesBU
        Dim dtPielesModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtPielesModelos = objPielN.validaExistenModelos(idPiel)
        End If

        If dtPielesModelos.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtPielesModelos.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("La Piel " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtPielesModelos.Rows.Count) + " modelos activos registrados con esta piel." + vbLf + cadena)
            Return False
        End If
        Return True
    End Function


    Public Sub editarPiel()
        Dim PielNegocio As New Programacion.Negocios.PielesBU
        Dim entidadPiel As New Entidades.Pieles
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidadPiel.PPielId = idPiel
        entidadPiel.PPielDescripcion = txtDescripcion.Text
        entidadPiel.PPNombreCorto = txtNombreCorto.Text
        entidadPiel.PPCodSicy = txtCodSicy.Text

        If (rdoActivo.Checked = True) Then
            entidadPiel.PPActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadPiel.PPActivo = False
        End If
        PielNegocio.EditarPiel(entidadPiel, usuario)

        PielNegocio.desacrtivarPielCol(idPiel)

        For Each rowP As UltraGridRow In grdColores.Rows
            If (rowP.Cells(4).Value = True) Then
                PielNegocio.EditarPielColor(idPiel, rowP.Cells(0).Value.ToString)
            End If
        Next
    End Sub

    Private Sub EditarPielForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Me.grdColores.DisplayLayout.Override.AllowRowFiltering = _
        ''   DefaultableBoolean.True
        'Me.grdColores.DisplayLayout.Override.FilterUIType = _
        '    FilterUIType.FilterRow

        lblDescripcion.ForeColor = Drawing.Color.Black
        lblNombreCorto.ForeColor = Drawing.Color.Black
        LlenarTablaColores()
        'grdColoresNormal.Columns(0).Width = 60
        'grdColoresNormal.Columns(1).Width = 60
        'grdColoresNormal.Columns(3).Width = 60
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If validaExistenModelos() = True Then
            If (validarVacio() = True) Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    editarPiel()
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Me.Close()
                Else
                End If
            ElseIf (validarVacio() = False) Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "Los campos marcados en rojo deben ser llenados."
                mensaje.ShowDialog()
            End If
        Else
        End If

    End Sub



    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub txtNombreCorto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreCorto.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreCorto.Text.Length < 10) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreCorto.SelectedText = Char.ToUpper(e.KeyChar)
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

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub
End Class