Public Class ListaPerfilesUsuarioForm
	Public perfil As Int32
	Public grupo As Int32
	Public usuario As Int32

	Private Sub ListaPerfilesUsuarioForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		InitCombos()
		llenarTabla()

		If perfil > 0 Then
			cmbPerfil.SelectedValue = perfil
		End If

		If grupo > 0 Then
			cmbDepartamento.SelectedValue = grupo
		End If

		If usuario > 0 Then
			cmbUsuario.SelectedValue = usuario
		End If

	End Sub
	Public Sub AgregarFila(ByVal peus As Entidades.PerfilesUsuario)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PDepartamento.DNombre
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PPerfil.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PUsuario.PUserUsername
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PUsuario.PUserUsuarioid
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PPerfil.Pperfilid
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = peus.PNave.PNombre
		fila.Cells.Add(celda)



		
		grdPeus.Rows.Add(fila)


	End Sub

	Public Sub llenarTabla()
		Dim grupo As Int32 = 0
		Dim perfil As Int32 = 0
		Dim usuario As Int32 = 0
		Dim nave As Int32 = 0

		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)

		End If
		If cmbUsuario.SelectedIndex > 0 Then
			usuario = CInt(cmbUsuario.SelectedValue)

		End If
		If cmbPerfil.SelectedIndex > 0 Then
			perfil = CInt(cmbPerfil.SelectedValue)

		End If

		If cmbDepartamento.SelectedIndex > 0 Then
			grupo = CInt(cmbDepartamento.SelectedValue)

		End If

		Dim listaPeus As New List(Of Entidades.PerfilesUsuario)
		Dim objBU As New Negocios.PerfilesUsuarioBU
		listaPeus = objBU.listaPerfilesUsuario(grupo, perfil, usuario, nave)
		For Each objeto As Entidades.PerfilesUsuario In listaPeus
			AgregarFila(objeto)
		Next
	End Sub
	Public Sub InitCombos()

		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

		'Dim objgrupoBU As New Framework.Negocios.DepartamentosBU
		'Dim tabla As New DataTable
		'tabla = objgrupoBU.listaDepartamentosActivos
		'tabla.Rows.InsertAt(tabla.NewRow, 0)
		'With cmbDepartamento
		'	.DisplayMember = "grup_name"
		'	.ValueMember = "grup_grupoid"
		'	.DataSource = tabla
		'End With

		'Dim objPerfBU As New Framework.Negocios.PerfilesBU
		'Dim tablaPerf As New DataTable
		'tablaPerf = objPerfBU.listaPerfilesActivos
		'tablaPerf.Rows.InsertAt(tablaPerf.NewRow, 0)
		'With cmbPerfil
		'	.DisplayMember = "perf_nombre"
		'	.ValueMember = "perf_perfilid"
		'	.DataSource = tablaPerf
		'End With


		Dim objUsuarioBU As New Framework.Negocios.UsuariosBU
		Dim tablaUsuarios As New DataTable
		tablaUsuarios = objUsuarioBU.ListaUsuariosTodos
		tablaUsuarios.Rows.InsertAt(tablaUsuarios.NewRow, 0)
		With cmbUsuario
			.DisplayMember = "user_username"
			.ValueMember = "user_usuarioid"
			.DataSource = tablaUsuarios
		End With


	End Sub

	Private Sub grdPeus_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPeus.CellContentClick

	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdPeus.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click

		cmbDepartamento.SelectedIndex = -1
		cmbNave.SelectedIndex = -1
		cmbPerfil.SelectedIndex = -1
		cmbUsuario.SelectedIndex = -1

		grdPeus.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		AltasPerfilesUsuarioForm.Show()

	End Sub

	Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
		If MessageBox.Show("¿Esta seguro que quiere eliminar la nave para el usuario ?", "Eliminar naves", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


			Dim usuarioid As Int32 = 0
			Dim perfilid As Int32 = 0


			For Each fila As DataGridViewRow In grdPeus.SelectedRows
				For Each columna As DataGridViewCell In fila.Cells
					If (columna.OwningColumn.Name = "ColUsuarioid") Then
						usuarioid = CInt(columna.Value)
					End If

					If (columna.OwningColumn.Name = "ColPerfilid") Then
						perfilid = CInt(columna.Value)
					End If



				Next
			Next

			Dim objperBU As New Negocios.PerfilesUsuarioBU
			objperBU.eliminar(usuarioid, perfilid)




			llenarTabla()
		Else



		End If


	End Sub


	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbPeus.Height = 38
		grdPeus.Height = 328
		grdPeus.Top = 124
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbPeus.Height = 148
		grdPeus.Height = 217
		grdPeus.Top = 235
	End Sub

	Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartamento.KeyPress

		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If


	End Sub

	Private Sub cmbPerfil_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPerfil.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbUsuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuario.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
	End Sub

	Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
		Dim departamento As Int32 = 0
		If cmbDepartamento.SelectedIndex > 0 Then
			departamento = CInt(cmbDepartamento.SelectedValue)
		End If
		cmbPerfil = Tools.Controles.ComboPerfilSegunDepartamento(cmbPerfil, departamento)
	End Sub


End Class