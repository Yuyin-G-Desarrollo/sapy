Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltaPielesForm

    Public Sub llenarDatosColor()
        grdColores.DataSource = Nothing
        Dim objCol As New Negocios.ColoresBU
        Dim dtDatosColores As DataTable
        dtDatosColores = objCol.VerListaColores("", "", True, "")
        grdColores.DataSource = dtDatosColores

        Me.grdColores.DisplayLayout.Bands(0).Columns.Add("selectTalla", "")
        Dim colckbTalla As UltraGridColumn = grdColores.DisplayLayout.Bands(0).Columns(4)
        colckbTalla.Style = ColumnStyle.CheckBox
        colckbTalla.CellActivation = Activation.AllowEdit

        With grdColores
            .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código"
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Color"
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "SICY"
            .DisplayLayout.Bands(0).Columns(0).Width = 50
            .DisplayLayout.Bands(0).Columns(2).Width = 50
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
            .DisplayLayout.Appearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Appearance.BorderColor = Color.DarkGray
        End With

        For Each row As UltraGridRow In grdColores.Rows
            row.Cells(4).Value = False
        Next
        formatoGrid()
    End Sub



    Public Sub formatoGrid()
        'grdColores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
        grdColores.DisplayLayout.Bands(0).Columns("color_colorid").Width = 30
        grdColores.DisplayLayout.Bands(0).Columns("color_codsicy").Width = 30
        grdColores.DisplayLayout.Bands(0).Columns("selectTalla").Width = 30
        grdColores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub


    Public Sub GenerarCodigo()
        Dim PielNegocios As New Programacion.Negocios.PielesBU
        Dim dtDatoIdMaximo As DataTable = PielNegocios.VerCodMax
        Dim validaExistente As Int32 = Convert.ToInt32(dtDatoIdMaximo.Rows(0)(0).ToString)
        Dim nuevoIdCodigo As Int32 = 0
        If (validaExistente = 0) Then
            txtCodigo.Text = "1"
        Else
            nuevoIdCodigo = Convert.ToInt32(dtDatoIdMaximo.Rows(0)(0).ToString) + 1
            txtCodigo.Text = nuevoIdCodigo.ToString
        End If

        Dim objColeBU As New Negocios.ColeccionBU
        txtCodSicy.Text = objColeBU.EncontrarColeccionSICY(4)(0)(0)
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text = Nothing Or txtNombre.Text = Nothing) Then
            If (txtDescripcion.Text = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            If (txtNombre.Text = Nothing) Then
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

    Public Sub RegistrarPiel()
        Dim entidadPiel As New Entidades.Pieles
        Dim pielNegocio As New Programacion.Negocios.PielesBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim dtDatoIdMaximo As New DataTable
        Dim idPiel As Int32 = 0
        entidadPiel.PPielDescripcion = txtDescripcion.Text.Trim
        entidadPiel.PPNombreCorto = txtNombre.Text.Trim
        entidadPiel.PPielCodigo = txtCodigo.Text.Trim
        entidadPiel.PPCodSicy = txtCodSicy.Text.Trim
        If (rdoActivo.Checked = True) Then
            entidadPiel.PPActivo = True

        ElseIf (rdoInactivo.Checked = True) Then
            entidadPiel.PPActivo = False
        End If
        pielNegocio.RegistrarPiel(entidadPiel, usuario)
        dtDatoIdMaximo = pielNegocio.VerIdPielMax()
        idPiel = dtDatoIdMaximo.Rows(0)(0).ToString

        For Each rowColor As UltraGridRow In grdColores.Rows
            If (rowColor.Cells(4).Value = True) Then
                pielNegocio.registraPielColor(idPiel, rowColor.Cells(0).Value.ToString)
            End If
        Next

    End Sub

    Private Sub AltaPielesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'grdColoresNormal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        llenarDatosColor()
        lblDescripcion.ForeColor = Drawing.Color.Black
        lblNombreCorto.ForeColor = Drawing.Color.Black
        txtDescripcion.Text = String.Empty
        txtNombre.Text = String.Empty
        txtCodSicy.Text = String.Empty
        txtCodSicy.Text = String.Empty
        rdoActivo.Checked = True
        GenerarCodigo()
        'grdColoresNormal.Columns(0).Width = 60
        'grdColoresNormal.Columns(1).Width = 60
        'grdColoresNormal.Columns(3).Width = 60

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistrarPiel()
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
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
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

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 10) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = (".")) Then
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

    Private Sub btnColores_Click(sender As Object, e As EventArgs) Handles btnColores.Click
        Dim objColor As New AltaColoresForm
        objColor.ShowDialog()
        llenarDatosColor()

    End Sub
End Class