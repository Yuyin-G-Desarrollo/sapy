Imports Entidades
Imports Framework.Negocios

Public Class ListaExcepcionesForm
	Private moduloid As Int32
	Private accionid As Int32
	Public Property Pmodulloid As Int32
		Get
			Return moduloid
		End Get
		Set(value As Int32)
			moduloid = value

		End Set
	End Property

	Public Property Paccionid As Int32
		Get
			Return accionid
		End Get
		Set(value As Int32)
			accionid = value

		End Set
	End Property

	Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

	End Sub

	Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcepciones.CellContentClick

	End Sub

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click

		Dim altasForm As New AltasExcepcionesForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()

		'AltasExcepcionesForm.Show()
	End Sub

	Private Sub ListaExcepcionesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

		InitCombos()

		If moduloid > 0 Then
			cmbExcepciones.SelectedValue = moduloid
		End If

		If accionid > 0 Then
			cmbAccion.SelectedValue = accionid
		End If



		llenarTabla()
	End Sub
	Public Sub llenarTabla()

		grdExcepciones.Rows.Clear()

		Dim modulo As Int32 = 0
		Dim accion As Int32 = 0
		Dim Autorizar As Int32 = 0
		

		If cmbExcepciones.SelectedIndex > 0 Then
			modulo = CInt(cmbExcepciones.SelectedValue)

		End If

		If cmbAccion.SelectedIndex > 0 Then
			accion = CInt(cmbAccion.SelectedValue)
		End If

		If rdoAutorizar.Checked = True Then
			Autorizar = 1
			


		Else
			'autorizar = CInt(rdoDengar.Checked)
			rdoDengar.Checked = False
			Autorizar = 2

		End If
		
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	Dim ListaPermisosUsuario As New List(Of Entidades.PermisosUsuario)
	Dim objBu As New Negocios.PermisosUsuarioBU
		ListaPermisosUsuario = objBu.listaPermisosUsuarios(modulo, txtUsuario.Text, accion, autorizar)
		For Each permisosUsuarios As Entidades.PermisosUsuario In ListaPermisosUsuario

			AgregarFila(permisosUsuarios)


		Next
	End Sub
	Public Sub AgregarFila(ByVal permisosUsuario As Entidades.PermisosUsuario)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow



		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PAccionid.PModulo.PNombre
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PAccionid.PModulo.PModuloid
		fila.Cells.Add(celda)



		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PUsuarioid.PUserUsername
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PUsuarioid.PUserUsuarioid
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PAccionid.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = permisosUsuario.PAccionid.PAccionId
		fila.Cells.Add(celda)



		celda = New DataGridViewTextBoxCell
		If permisosUsuario.pTipoPermiso = 1 Then
			celda.Value = "Autorizar"
		Else
			celda.Value = "Denegar"
		End If
		fila.Cells.Add(celda)








		grdExcepciones.Rows.Add(fila)


	End Sub
	Public Sub InitCombos()


		'Carga combo de acciones segun el modulo
		If cmbExcepciones.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbExcepciones.SelectedValue))
		End If

		'Dim objExcepcionesBU As New Negocios.AccionesBU 
		'Dim tabalaAcciones As New DataTable
		'tabalaAcciones = objExcepcionesBU.listaAccionesActivos
		'tabalaAcciones.Rows.InsertAt(tabalaAcciones.NewRow, 0)
		'With cmbAccion
		'	.DisplayMember = "acmo_nombre"
		'	.ValueMember = "acmo_accionmoduloid"
		'	.DataSource = tabalaAcciones
		'End With

		Dim objmoduloBU As New Framework.Negocios.ModulosBU
		Dim tablamodulos As New DataTable
		tablamodulos = objmoduloBU.ListaModulosTodos
		tablamodulos.Rows.InsertAt(tablamodulos.NewRow, 0)
		With cmbExcepciones
			.DisplayMember = "modu_nombre"
			.ValueMember = "modu_moduloid"
			.DataSource = tablamodulos
		End With


	End Sub

	Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
		If MessageBox.Show("¿Esta seguro que quiere eliminar el permiso?", "Eliminar permisos", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


			Dim usuarioid As Int32 = 0
			Dim accionid As Int32 = 0
			Dim moduloid As Int32 = 0
			Dim tipo As Int32 = 0

			For Each fila As DataGridViewRow In grdExcepciones.SelectedRows
				For Each columna As DataGridViewCell In fila.Cells
					If (columna.OwningColumn.Name = "ColUsuarioid") Then
						usuarioid = CInt(columna.Value)
					End If

					If (columna.OwningColumn.Name = "ColAccionid") Then
						accionid = CInt(columna.Value)
					End If

					'If (columna.OwningColumn.Name = "ColModuloid") Then
					'	moduloid = CInt(columna.Value)
					'End If
					'If (columna.OwningColumn.Name = "ColTipo") Then
					'	tipo = CInt(columna.Value)
					'End If

				Next
			Next

			Dim objpermisoBU As New PermisosUsuarioBU
			objpermisoBU.eliminarPermisoUsuarios(usuarioid, accionid)




			llenarTabla()
		Else



		End If


	End Sub


	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdExcepciones.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub cmbExcepciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbExcepciones.SelectedIndexChanged
		If cmbExcepciones.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbExcepciones.SelectedValue))
		End If
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbExcepciones.Height = 38
		grdExcepciones.Height = 328
		grdExcepciones.Top = 124

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbExcepciones.Height = 180
		grdExcepciones.Height = 190
		grdExcepciones.Top = 260

	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtUsuario.Text = ""
		cmbAccion.SelectedIndex = -1
		cmbExcepciones.SelectedIndex = -1


		rdoAutorizar.Checked = True
		grdExcepciones.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub cmbExcepciones_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbExcepciones.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbAccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAccion.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtUsuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class
