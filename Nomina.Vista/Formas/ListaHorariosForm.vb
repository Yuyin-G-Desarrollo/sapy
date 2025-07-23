Imports Entidades

Public Class ListaHorariosForm
	Public Naveid As Int32

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasHorariosForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()

		'AltasHorariosForm.Show()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim horariosid As Int32 = 0
		For Each fila As DataGridViewRow In grdHorarios.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColHorarioId") Then
					horariosid = CInt(columna.Value)

				End If
			Next
		Next




		Dim formaEditarHorarios As New EditarHorariosForm
		formaEditarHorarios.MdiParent = Me.MdiParent
		formaEditarHorarios.Dhorariosid = horariosid
		formaEditarHorarios.Show()

		'
	'

	End Sub
	Public Sub AgregarFila(ByVal horario As Entidades.Horarios)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = horario.DHorariosid
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = horario.DNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = horario.PNaves.PNombre
		fila.Cells.Add(celda)


		celda = New DataGridViewCheckBoxCell
		celda.Value = horario.DActivo
		fila.Cells.Add(celda)



		grdHorarios.Rows.Add(fila)


	End Sub

	Public Sub llenarTabla()

		Dim Nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			Nave = CInt(cmbNave.SelectedValue)
		End If

		Dim listaHorarios As New List(Of Entidades.Horarios)
		Dim objBU As New Negocios.HorariosBU
        'listaHorarios = objBU.listaHorarios(txtNombreDeLHorario.Text, Nave, btnSi.Checked)
		For Each objeto As Entidades.Horarios In listaHorarios
			AgregarFila(objeto)
		Next
	End Sub

	Private Sub ListaHorariosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		initCombos()
		If Naveid > 0 Then
			cmbNave.SelectedValue = Naveid
		End If
		llenarTabla()
	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdHorarios.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDeLHorario.Text = ""
		cmbNave.SelectedIndex = -1
		btnSi.Checked = True
		grdHorarios.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbHorarios.Height = 38
		grdHorarios.Height = 328
		grdHorarios.Top = 124

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbHorarios.Height = 154
		grdHorarios.Height = 217
		grdHorarios.Top = 235

	End Sub
	Public Sub initCombos()
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

	Private Sub txtNombreDeLHorario_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreDeLHorario.TextChanged

	End Sub

	Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles lblNave.Click

	End Sub

	Private Sub btnExcepciones_Click(sender As System.Object, e As System.EventArgs) Handles btnExcepciones.Click
		'istaExcepcionesHorariosForm.Show()
        'Dim altasForm As New ListaExcepcionesHorariosForm
        'altasForm.MdiParent = MdiParent
        'altasForm.Show()


	End Sub

	Private Sub grbHorarios_Enter(sender As System.Object, e As System.EventArgs) Handles grbHorarios.Enter

	End Sub
End Class