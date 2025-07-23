Imports Framework
Imports Framework.Negocios

Public Class ListaPatronesForm
	Public ciudadid As Integer
	''
	Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasPatronesForm
        'If altasForm.ShowDialog = DialogResult.OK Then
        '	llenarTabla()
        'End If
        altasForm.MdiParent = Me.MdiParent
        altasForm.Show()

        'If Not CheckForm(altasForm) Then
        '    Dim formAltas As New AltasPatronesForm
        '    formAltas.ShowDialog()
        'End If

        llenarTabla()
    End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim patronid As Int32 = 0
		For Each fila As DataGridViewRow In grdPatrones.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColPatronId") Then
					patronid = CInt(columna.Value)

                    Dim formaEditarPatron As New EditarPatronesForm
                    formaEditarPatron.MdiParent = Me.MdiParent
                    formaEditarPatron.Ppatronid = patronid

                    'If formaEditarPatron.ShowDialog = DialogResult.OK Then
                    '    llenarTabla()
                    'End If
                    formaEditarPatron.Show()
                End If
			Next
		Next
	End Sub

	Private Sub ListaPatronesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        'lblListaPatrones.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'grdPatrones.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


		'InitCombos()
		'If ciudadid > 0 Then
		'	cmbCiudad.SelectedValue = ciudadid
		'End If

		If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_PATR", "WRITE") Then
			btnAltas.Visible = True
			lblAltas.Visible = True
		Else
			btnAltas.Visible = False
			lblAltas.Visible = False
		End If
		'prueba.Show()

		If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_PATR", "UPDATE") Then
			btnEditar.Visible = True
			Editar.Visible = True
		Else
			btnEditar.Visible = False
			Editar.Visible = False
		End If


		llenarTabla()
        Me.Top = 0
        Me.Left = 0
	End Sub
	Public Sub llenarTabla()

		grdPatrones.Rows.Clear()
		'Dim ciudad As Int32 = 0
		'If cmbCiudad.SelectedIndex > 0 Then
		'	ciudad = CInt(cmbCiudad.SelectedValue)
		'End If

		Dim listaPatrones As New List(Of Entidades.Patrones)
		Dim objBU As New Negocios.PatronesBU
		listaPatrones = objBU.listaPatrones(txtNombreDelPatron.Text, txtNumeroDeRegistro.Text, txtRFC.Text, btnSi.Checked)
		For Each patron As Entidades.Patrones In listaPatrones
			AgregarFila(patron)
		Next
	End Sub
	Public Sub AgregarFila(ByVal patron As Entidades.Patrones)
		Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = grdPatrones.Rows.Count + 1
        fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.Pnombre)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.Prfc)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.PNpatronal)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.Pcalle)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.PDnumero)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = patron.Pcolonia
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.PciudadId)
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = UCase(patron.Pcp)
		fila.Cells.Add(celda)


		celda = New DataGridViewCheckBoxCell
        celda.Value = patron.Pactivo
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = patron.Ppatronid
		fila.Cells.Add(celda)

		grdPatrones.Rows.Add(fila)

	End Sub

	Private Sub grdPatrones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPatrones.CellContentClick

	End Sub

	Private Sub txtNombreDelPatron_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreDelPatron.TextChanged

	End Sub

	Private Sub txtNombreDelPatron_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPatron.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetter(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) _
		Or e.KeyChar = "-" Then

			e.Handled = False
		End If
	End Sub
	''
	Private Sub txtRFC_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
		e.Handled = True

		If Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then



			e.Handled = False
		End If
	End Sub

	Private Sub txtNumeroDeRegistro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDeRegistro.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtCalle_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtNumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If

	End Sub

	Private Sub txtColonia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtCP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        'grbPatrones.Height = 45
        'grdPatrones.Height = 447
        'grdPatrones.Top = 130
        grbPatrones.Height = 45
        grdPatrones.Height = 420
        grdPatrones.Top = 120
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        'grbPatrones.Height = 242
        'grdPatrones.Height = 250
        'grdPatrones.Top = 328
        grbPatrones.Height = 184
        grdPatrones.Height = 281
        grdPatrones.Top = 258
	End Sub

	Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs)

	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdPatrones.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDelPatron.Text = ""
		'cmbCiudad.SelectedIndex = 0
		btnSi.Checked = True
		grdPatrones.Rows.Clear()
		llenarTabla()
	End Sub

    Private Sub pbYuyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function
End Class