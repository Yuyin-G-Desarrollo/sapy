Public Class ListaExcepcionesHorariosForm
	Public Horarioid As Int32
	Public fecha As Date
	Public fechaseleccionada As Boolean = False

	Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExeHorarios.CellContentClick

	End Sub

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click

		Dim altasForm As New AltasExcepcionesHorariosForm
		altasForm.MdiParent = MdiParent
		altasForm.Show()


	End Sub

	Private Sub ListaExcepcionesHorariosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		InitCombos()
		If Horarioid > 0 Then
			cmbHorario.SelectedValue = Horarioid
		End If
		llenarTabla()
	End Sub
	Public Sub llenarTabla()

		Dim horario As Int32 = 0
		Dim Autorizar As Int32 = 0

		If cmbHorario.SelectedIndex > 0 Then
			horario = CInt(cmbHorario.SelectedValue)
		End If

		'If horario > 0 Then
		'	cmbHorario.SelectedValue = horario
		'End If


		Dim listaExcepcionesHorarios As New List(Of Entidades.ExcepcionesHorarios)
		Dim objBU As New Negocios.ExcepcionesHorariosBU
		listaExcepcionesHorarios = objBU.ListaExcepcionesHorarios(txtNombre.Text, btnSi.Checked, Horario, dtpFecha.SelectionStart, fechaseleccionada)
		For Each exe As Entidades.ExcepcionesHorarios In listaExcepcionesHorarios
			AgregarFila(exe)
		Next
	End Sub

	Public Sub AgregarFila(ByVal exe As Entidades.ExcepcionesHorarios)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = exe.PExcepcionesHorarioID
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = exe.Pnombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = exe.PFecha
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = exe.PHorario.DNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		If exe.PTipo = 1 Then
			celda.Value = "Entrada"
		Else
			celda.Value = "Salida"
		End If
		'celda.Value = exe.PTipo
		fila.Cells.Add(celda)


		celda = New DataGridViewCheckBoxCell
		celda.Value = exe.PActivo
		fila.Cells.Add(celda)



		grdExeHorarios.Rows.Add(fila)


	End Sub

	Public Sub InitCombos()
		Dim objHorariosBU As New Negocios.HorariosBU
		Dim tablaHorarios As New DataTable
		tablaHorarios = objHorariosBU.listaHorariosActivos
		tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)
		With cmbHorario
			.DisplayMember = "hora_nombre"
			.ValueMember = "hora_horarioid"
			.DataSource = tablaHorarios

		End With

	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdExeHorarios.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub dtpFecha_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles dtpFecha.DateChanged
		fecha = dtpFecha.SelectionStart
		fechaseleccionada = True
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombre.Text = ""
		cmbHorario.SelectedIndex = -1
		btnSi.Checked = True
		grdExeHorarios.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim IdHexc As Int32 = 0
		For Each fila As DataGridViewRow In grdExeHorarios.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "COLID") Then
					IdHexc = CInt(columna.Value)
				End If
			Next
		Next
		Dim formaEditar As New EditarExcepcionesHorariosForm
		formaEditar.MdiParent = Me.MdiParent
		formaEditar.PidHexc = IdHexc
		formaEditar.Show()
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbExeHorarios.Height = 39
		grdExeHorarios.Height = 420
		grdExeHorarios.Top = 120

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click

		grbExeHorarios.Height = 228
		grdExeHorarios.Height = 231
		grdExeHorarios.Top = 311

	End Sub

	Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbHorario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbHorario.KeyPress
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class