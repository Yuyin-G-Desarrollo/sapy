Imports Framework.Negocios

Public Class ListaNavesForm

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasNavesForm
		If altasForm.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If

		'altasForm.MdiParent = Me.MdiParent
		'altasForm.Show()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click



		Dim navesid As Int32 = 0
		For Each fila As DataGridViewRow In grdNaves.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColId") Then
					navesid = CInt(columna.Value)

		Dim editarForm As New EditarNavesForm
		'editarForm.MdiParent = Me.MdiParent
		editarForm.PNavesid = navesid
		If editarForm.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If

		'editarForm.Show()
				End If
			Next
		Next
		'Dim formaEditarNaves As New EditarNavesForm
		'formaEditarNaves.PNavesid = navesid
		'formaEditarNaves.Show()

	End Sub
	'EditarNavesForm.Show()

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbNaves.Height = 38
		grdNaves.Height = 328
		grdNaves.Top = 124

	End Sub

	Public Sub AgregarFila(ByVal nave As Entidades.Naves)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = nave.PNaveId
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
        celda.Value = nave.PNombre.ToUpper
		fila.Cells.Add(celda)


		celda = New DataGridViewCheckBoxCell
		celda.Value = nave.PActivo
		fila.Cells.Add(celda)

		grdNaves.Rows.Add(fila)


	End Sub

	Public Sub llenarTabla()

		grdNaves.Rows.Clear()

		Dim listaNaves As New List(Of Entidades.Naves)
		Dim objBU As New Negocios.NavesBU
		listaNaves = objBU.listaDeNaves(txtNombreNave.Text, rdoSi.Checked)
		For Each objeto As Entidades.Naves In listaNaves
			AgregarFila(objeto)
		Next
	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		'txtNombreNave.Text = ""
		'rdoSi.Checked = True
		grdNaves.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreNave.Text = ""
		rdoSi.Checked = True
		grdNaves.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub ListaNavesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        grdNaves.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'lblListaNaves.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
        'lblUsuarios.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblUsuarios.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


		If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_NAVE", "WRITE") Then
			btnAltas.Visible = True
			lblAltas.Visible = True
		Else
			btnAltas.Visible = False
			lblAltas.Visible = False
		End If
		'prueba.Show()

		If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_NAVE", "UPDATE") Then
			btnEditar.Visible = True
			Editar.Visible = True
		Else
			btnEditar.Visible = False
			Editar.Visible = False
		End If


		If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_NAVE", "USUARIOS") Then
			btnUsuarios.Visible = True
			lblUsuarios.Visible = True
		Else
			btnUsuarios.Visible = False
			lblUsuarios.Visible = False
		End If


		llenarTabla()
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbNaves.Height = 148
		grdNaves.Height = 217
		grdNaves.Top = 235

	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnUsuarios.Click
		Dim listaNausForm As New ListaNavesUsuarioForm
		listaNausForm.MdiParent = Me.MdiParent
		listaNausForm.Show()


		'ListaNavesUsuarioForm.Show()
    End Sub

    Private Sub txtNombreNave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreNave.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreNave.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreNave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreNave.TextChanged

    End Sub

    Private Sub grbNaves_Enter(sender As Object, e As EventArgs) Handles grbNaves.Enter

    End Sub
End Class