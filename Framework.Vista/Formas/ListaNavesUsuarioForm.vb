Public Class ListaNavesUsuarioForm
	Public NAVEID As Int32
	Public Property PNAVEID As Int32
		Get
			Return NAVEID
		End Get
		Set(value As Int32)
			NAVEID = value
		End Set
	End Property

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasNavesUsuarioForm
		'altasForm.MdiParent = Me.MdiParent
		'altasForm.Show()
		If altasForm.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If



	End Sub

	Private Sub ListaNavesUsuarioForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'lblNavesUser.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblEliminar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		InitCombos()
		llenarTabla()
		If NAVEID > 0 Then
			cmbNaves.SelectedValue = NAVEID
		End If

	End Sub
	Public Sub llenarTabla()

		grdNaus.Rows.Clear()

		Dim naves As Int32 = 0



		If cmbNaves.SelectedIndex > 0 Then
			naves = CInt(cmbNaves.SelectedValue)

		End If





		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Dim ListaNavesUsuarios As New List(Of Entidades.NavesUsuario)
		Dim objBu As New Negocios.NavesUsuarioBU
		ListaNavesUsuarios = objBu.listaNaves(naves, txtUsuario.Text)
		For Each navesUsuario As Entidades.NavesUsuario In ListaNavesUsuarios

			AgregarFila(navesUsuario)


		Next
	End Sub
	Public Sub AgregarFila(ByVal navesusuarios As Entidades.NavesUsuario)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow


		celda = New DataGridViewTextBoxCell
		celda.Value = navesusuarios.PUsuariosID.PUserUsername
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = navesusuarios.PUsuariosID.PUserUsuarioid
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = navesusuarios.NavesID.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = navesusuarios.NavesID.PNaveId
		fila.Cells.Add(celda)




		grdNaus.Rows.Add(fila)


	End Sub
	Public Sub InitCombos()

		Dim objNavesBU As New Framework.Negocios.NavesBU
		Dim tablaNaves As New DataTable
		tablaNaves = objNavesBU.listaNavesActivas
		tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
		With cmbNaves
			.DisplayMember = "nave_nombre"
			.ValueMember = "nave_naveid"
			.DataSource = tablaNaves
		End With


	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtUsuario.Text = ""
		cmbNaves.SelectedIndex = -1
		
		grdNaus.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdNaus.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
		If MessageBox.Show("¿Esta seguro que quiere eliminar la nave para el usuario ?", "Eliminar naves", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


			Dim usuarioid As Int32 = 0
			Dim naveid As Int32 = 0
			

			For Each fila As DataGridViewRow In grdNaus.SelectedRows
				For Each columna As DataGridViewCell In fila.Cells
					If (columna.OwningColumn.Name = "ColUsuarioid") Then
						usuarioid = CInt(columna.Value)
					End If

					If (columna.OwningColumn.Name = "ColNaveid") Then
						naveid = CInt(columna.Value)
					End If

					

				Next
			Next

			Dim objpermisoBU As New Negocios.NavesUsuarioBU
			objpermisoBU.eliminarNaus(usuarioid, naveid)




			llenarTabla()
		Else



		End If


	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grdNaus.Height = 38
		grdNaus.Height = 328
		grdNaus.Top = 124
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbNaus.Height = 148
		grdNaus.Height = 217
		grdNaus.Top = 235
	End Sub
End Class