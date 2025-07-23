Imports Framework.Negocios

Public Class ListaAreasForm
	Public grupo As Int32
	Public nave As Int32


	Private Sub ListaAreasForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        grdArea.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdArea.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdArea.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_AREA", "WRITE") Then
            btnAltas.Visible = True
            lblAltas.Visible = True
        Else
            btnAltas.Visible = False
            lblAltas.Visible = False
        End If
		'prueba.Show()

		If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_AREA", "UPDATE") Then
			btnEditar.Visible = True
			Editar.Visible = True
		Else
			btnEditar.Visible = False
			Editar.Visible = False
		End If




		'llenarTabla()
		InitCombos()

		If nave > 0 Then
			cmbNave.SelectedValue = nave
		End If
		'If grupo > 0 Then
		'	cmbDepartamento.SelectedValue = grupo
		'End If
        'lblListaAreas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'grdArea.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)



	End Sub
	Public Sub llenarTabla()

		grdArea.Rows.Clear()

		Dim naves As Int32 = 0
		Dim grupo As Int32 = 0



		If cmbNave.SelectedIndex > 0 Then
			naves = CInt(cmbNave.SelectedValue)

		End If
		'If cmbDepartamento.SelectedIndex > 0 Then
		'	grupo = CInt(cmbDepartamento.SelectedValue)

		'End If


		Dim ListaAreas As New List(Of Entidades.Areas)
		Dim objBu As New Negocios.AreasBU
		ListaAreas = objBu.listaAreas(txtNombre.Text, naves, btnSi.Checked)

		For Each area As Entidades.Areas In ListaAreas

			AgregarFila(area)


		Next
	End Sub
	Public Sub AgregarFila(ByVal area As Entidades.Areas)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow


		celda = New DataGridViewTextBoxCell
        celda.Value = area.PNombre.ToUpper
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
        celda.Value = area.Nave.PNombre.ToUpper
		fila.Cells.Add(celda)

		'celda = New DataGridViewTextBoxCell
		'celda.Value = area.PDepartamento.DNombre
		'fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = area.PActivo
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = area.PAreaid
		fila.Cells.Add(celda)

		grdArea.Rows.Add(fila)


	End Sub
	Public Sub InitCombos()

		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


	End Sub

	Private Sub txtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombre.TextChanged

	End Sub

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
	End Sub

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasAreasForm
		'altasForm.MdiParent = Me.MdiParent
		'altasForm.Show()
		If altasForm.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If
	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdArea.Rows.Clear()

		grdArea.Rows.Clear()
		If (txtNombre.Text.Length > 0 Or cmbNave.SelectedIndex > 0) Then
			llenarTabla()
		End If
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombre.Text = ""
		'cmbDepartamento.SelectedIndex = 0
		cmbNave.SelectedIndex = 0
		btnSi.Checked = True
		grdArea.Rows.Clear()
		'llenarTabla()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim areaid As Int32 = 0
		For Each fila As DataGridViewRow In grdArea.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColArea") Then
					areaid = CInt(columna.Value)

		Dim formaEditar As New EditarAreaForm
		'formaEditar.MdiParent = Me.MdiParent

		formaEditar.Pareaid = areaid
		If formaEditar.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If
		'formaEditar.Show()
				End If
			Next
		Next
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbArea.Height = 38
		grdArea.Height = 328
		grdArea.Top = 124
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbArea.Height = 185
		grdArea.Height = 200
		grdArea.Top = 260

	End Sub

	Private Sub cmbNave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtNombre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown

	End Sub

	Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
        End If
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombre.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
	End Sub

	Private Sub pnlEncabezado_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlEncabezado.Paint

	End Sub

	Private Sub grdArea_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArea.CellContentClick

	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)



	End Sub

	Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)

	End Sub
End Class