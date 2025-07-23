Imports Framework

Public Class ListaMotivosPrestamoForm
	Public naveId As Int32

	Private Sub ListaPrestamosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		InitCombos()
		If naveId > 0 Then
			cmbNave.SelectedValue = naveId

		End If
		llenarTabla()
	End Sub
	Public Sub llenarTabla()
		Dim Nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			Nave = CInt(cmbNave.SelectedValue)
		End If

		Dim listaMotivosPrestamos As New List(Of Entidades.MotivosPrestamo)
		Dim objBU As New Negocios.MotivosPrestamoBU
		listaMotivosPrestamos = objBU.listaMotivosPrestamos(txtNombre.Text, Nave, rdoSi.Checked)
		For Each motivo As Entidades.MotivosPrestamo In listaMotivosPrestamos
			AgregarFila(motivo)
		Next
	End Sub

	Public Sub AgregarFila(ByVal motivo As Entidades.MotivosPrestamo)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = motivo.PMotivoPrestamoId
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = motivo.PNombre
		fila.Cells.Add(celda)


		


		celda = New DataGridViewTextBoxCell
		celda.Value = motivo.PNaveId.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = motivo.PActivo
		fila.Cells.Add(celda)

		
		
		grdPrestamos.Rows.Add(fila)


	End Sub

	Public Sub InitCombos()
		Dim objNavesBU As New Framework.Negocios.NavesBU
		Dim tablaNaves As New DataTable
		tablaNaves = objNavesBU.listaNavesActivas
		tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
		With cmbNave
			.DisplayMember = "nave_nombre"
			.ValueMember = "nave_naveid"
			.DataSource = tablaNaves
		End With

	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

		grdPrestamos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombre.Text = ""
		cmbNave.SelectedIndex = -1
		rdoSi.Checked = True
		grdPrestamos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasMotivosPrestamosForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()

	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim IdMotivo As Int32 = 0
		For Each fila As DataGridViewRow In grdPrestamos.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColMotivosPrestamoid") Then
					IdMotivo = CInt(columna.Value)
				End If
			Next
		Next
		Dim formaEditarMotivos As New EditarMotivosPrestamosForm
		formaEditarMotivos.MdiParent = Me.MdiParent
		formaEditarMotivos.PidMOTIVO = IdMotivo
		formaEditarMotivos.Show()
	End Sub

	Private Sub txtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombre.TextChanged

	End Sub

	Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbNave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbBancos.Height = 35
		grdPrestamos.Height = 269
		grdPrestamos.Top = 124
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbBancos.Height = 148
		grdPrestamos.Height = 160
		grdPrestamos.Top = 235
	End Sub
End Class