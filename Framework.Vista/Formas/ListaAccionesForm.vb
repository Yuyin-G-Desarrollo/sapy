Imports Framework.Negocios
Imports Entidades

Public Class ListaAccionesForm

	Public idModulo As Int32
	Public idTipo As Int32
	Private Sub lblAcciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAcciones.Click

	End Sub

	Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAcciones.CellContentClick

	End Sub

	Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasAccionesForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()
		'AltasAccionesForm.Show()
	End Sub

	Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click


		Dim idAcciones As Int32 = 0
		For Each fila As DataGridViewRow In grdAcciones.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "colId") Then
					idAcciones = CInt(columna.Value)
				End If
			Next
		Next

	
		Dim formaEditarAcciones As New EditarAccionesForm
		formaEditarAcciones.MdiParent = Me.MdiParent
		formaEditarAcciones.idAcciones = idAcciones
		formaEditarAcciones.Show()

		
	End Sub

	Private Sub btnPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermisos.Click
		Dim listaForm As New ListaPermisoForm
		listaForm.MdiParent = Me.MdiParent
		listaForm.Show()
		'ListaPermisoForm.Show()
	End Sub

	Private Sub btnExcepciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcepciones.Click
		Dim altasForm As New ListaExcepcionesForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()

		'ListaExcepcionesForm.Show()
	End Sub

	Private Sub txtNombreDeLaAccion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDeLaAccion.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtNombreDelComponente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

	End Sub

	Private Sub txtNombreDelComponente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub ListaAccionesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'InitCombos()
		'LlenarTabla()
		InitCombos()
		If idModulo > 0 Then
			cmbModulo.SelectedValue = idModulo
		End If
		LlenarTabla()
	End Sub

	' ''Public Sub LlenarTabla()
	' ''	Dim objAccionesBU As New AccionesBU
	' ''	For Each accion As Entidades.Acciones In objAccionesBU.listaAcciones
	' ''		AgregarFila(accion)
	' ''	Next
	' ''End Sub
	Public Sub llenarTabla()
		Dim modulo As Int32 = 0
		Dim Tipo As Int32 = -1
		If cmbModulo.SelectedIndex > 0 Then
			modulo = CInt(cmbModulo.SelectedValue)
		End If
		If cmbTipo.SelectedIndex > 0 Then
			Tipo = CInt(cmbTipo.SelectedValue)
		End If

		Dim listaAcciones As New List(Of Entidades.Acciones)
		Dim objBU As New Negocios.AccionesBU
		listaAcciones = objBU.listaAccionesModulos(txtNombreDeLaAccion.Text, txtClave.Text, modulo, Tipo, rdoActivo.Checked)
		For Each accion As Entidades.Acciones In listaAcciones
			AgregarFila(accion)
		Next
	End Sub

	Public Sub AgregarFila(ByVal accion As Entidades.Acciones)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = accion.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = accion.PClave
		fila.Cells.Add(celda)

		''celda = New DataGridViewTextBoxCell()
		''If IsNothing(accion.PModulo.PModuloid) Then
		''	celda.Value = ""
		''Else
		''	celda.Value = accion.PModulo.PNombre
		''End If
		''fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = accion.PModulo.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = accion.PActivo
		fila.Cells.Add(celda)



		celda = New DataGridViewTextBoxCell

		If accion.PTipo = -1 Then
			celda.Value = ""
		End If
		If accion.PTipo = 1 Then
			celda.Value = "Consultar"
		End If
		If accion.PTipo = 2 Then
			celda.Value = "Altas"
		End If
		If accion.PTipo = 3 Then
			celda.Value = "Editar"
		End If
		If accion.PTipo = 4 Then
			celda.Value = "Eliminar"
		End If
		If accion.PTipo = 0 Then
			celda.Value = "Otro"
		End If
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = accion.PAccionId
		fila.Cells.Add(celda)


		'celda.Value = accion.PActivo





		grdAcciones.Rows.Add(fila)


	End Sub
	Public Sub InitCombos()

		Dim objModulosBU As New Negocios.ModulosBU
		Dim tablaModulos As New DataTable
		tablaModulos = objModulosBU.ListaModulosTodos
		tablaModulos.Rows.InsertAt(tablaModulos.NewRow, 0)
		With cmbModulo
			.DisplayMember = "modu_nombre"
			.ValueMember = "modu_moduloid"
			.DataSource = tablaModulos
		End With

		cmbTipo.Items.Clear()

		Dim dt As DataTable = New DataTable("Tabla")

		dt.Columns.Add("Codigo")
		dt.Columns.Add("Descripcion")

		Dim dr As DataRow

		dr = dt.NewRow()
		dr("Codigo") = ""
		dr("Descripcion") = ""
		dt.Rows.Add(dr)

		dr = dt.NewRow()
		dr("Codigo") = "1"
		dr("Descripcion") = "Consultar"
		dt.Rows.Add(dr)

		dr = dt.NewRow()
		dr("Codigo") = "2"
		dr("Descripcion") = "Altas"
		dt.Rows.Add(dr)

		dr = dt.NewRow()
		dr("Codigo") = "3"
		dr("Descripcion") = "Editar"
		dt.Rows.Add(dr)

		dr = dt.NewRow()
		dr("Codigo") = "4"
		dr("Descripcion") = "Eliminar"
		dt.Rows.Add(dr)

		dr = dt.NewRow()
		dr("Codigo") = "0"
		dr("Descripcion") = "Otro"
		dt.Rows.Add(dr)

		cmbTipo.DataSource = dt
		cmbTipo.ValueMember = "Codigo"
		cmbTipo.DisplayMember = "Descripcion"


		'Dim objTipoBU As New Negocios.AccionesBU
		'Dim tablaTipo As New DataTable
		'tablaTipo = objAccionesBU.listaAccionesActivos
		'tablaTipo.Rows.InsertAt(tablaTipo.NewRow, 0)
		'With cmbTipo
		'	.DisplayMember = "acmo_tipo"
		'	.ValueMember = "acmo_tipo"
		'	.DataSource = tablaTipo
		'End With

	End Sub
	' ''Private Sub AgregarFila(ByVal accion As Acciones)
	' ''	Dim dgvRow As New DataGridViewRow
	' ''	Dim dgvCell As DataGridViewCell

	' ''	'columna Nombre
	' ''	dgvCell = New DataGridViewTextBoxCell()
	' ''	dgvCell.Value = accion.PNombre
	' ''	dgvRow.Cells.Add(dgvCell)


	' ''	'columna clave
	' ''	dgvCell = New DataGridViewTextBoxCell()
	' ''	dgvCell.Value = accion.PClave
	' ''	dgvRow.Cells.Add(dgvCell)

	' ''	'columna modulo
	' ''	dgvCell = New DataGridViewTextBoxCell()
	' ''	If IsNothing(accion.PModulo) Then
	' ''		dgvCell.Value = ""
	' ''	Else
	' ''		dgvCell.Value = accion.PModulo.PNombre
	' ''	End If
	' ''	dgvRow.Cells.Add(dgvCell)


	' ''	'columna activo
	' ''	dgvCell = New DataGridViewCheckBoxCell()
	' ''	dgvCell.Value = accion.PActivo
	' ''	dgvRow.Cells.Add(dgvCell)

	' ''	'columna id
	' ''	dgvCell = New DataGridViewTextBoxCell()
	' ''	dgvCell.Value = accion.PAccionId
	' ''	dgvRow.Cells.Add(dgvCell)

	' ''	grdAcciones.Rows.Add(dgvRow)
	' ''End Sub


	' ''Private Sub InitCombos()
	' ''	'INIT combo Modulo
	' ''	Dim objModulosBU As New ModulosBU
	' ''	Dim tablaModulos As New DataTable
	' ''	tablaModulos = objModulosBU.ListaModulosTodos
	' ''	tablaModulos.Rows.InsertAt(tablaModulos.NewRow, 0)
	' ''	With cmbModulo
	' ''		.DataSource = tablaModulos
	' ''		.DisplayMember = "modu_nombre"
	' ''		.ValueMember = "modu_moduloid"
	' ''	End With


	' ''	cmbTipo.Items.Clear()

	' ''	Dim dt As DataTable = New DataTable("Tabla")

	' ''	dt.Columns.Add("Codigo")
	' ''	dt.Columns.Add("Descripcion")

	' ''	Dim dr As DataRow

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "0"
	' ''	dr("Descripcion") = ""
	' ''	dt.Rows.Add(dr)

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "1"
	' ''	dr("Descripcion") = "Lectura"
	' ''	dt.Rows.Add(dr)

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "2"
	' ''	dr("Descripcion") = "Altas"
	' ''	dt.Rows.Add(dr)

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "3"
	' ''	dr("Descripcion") = "Editar"
	' ''	dt.Rows.Add(dr)

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "4"
	' ''	dr("Descripcion") = "Eliminar"
	' ''	dt.Rows.Add(dr)

	' ''	dr = dt.NewRow()
	' ''	dr("Codigo") = "0"
	' ''	dr("Descripcion") = "Otro"
	' ''	dt.Rows.Add(dr)

	' ''	cmbTipo.DataSource = dt
	' ''	cmbTipo.ValueMember = "Codigo"
	' ''	cmbTipo.DisplayMember = "Descripcion"
	' ''End Sub
	''
	'Public Sub llenarTabla()
	'	Dim departamento As Int32 = 0
	'	If cmbDepartamento.SelectedIndex > 0 Then
	'		departamento = CInt(cmbDepartamento.SelectedValue)
	'	End If

	'	Dim listaPerfiles As New List(Of Entidades.Perfiles)
	'	Dim objBU As New Negocios.PerfilesBU
	'	listaPerfiles = objBU.listaPerfiles(txtNombreDelPerfil.Text, departamento, rdoSi.Checked)
	'	For Each perfil As Entidades.Perfiles In listaPerfiles
	'		AgregarFila(perfil)
	'	Next
	'End Sub

	'Public Sub AgregarFila(ByVal perfil As Entidades.Perfiles)
	'	Dim celda As DataGridViewCell
	'	Dim fila As New DataGridViewRow

	'	celda = New DataGridViewTextBoxCell
	'	celda.Value = perfil.PNombre
	'	fila.Cells.Add(celda)

	'	celda = New DataGridViewTextBoxCell
	'	celda.Value = perfil.PNombreDepartamento
	'	fila.Cells.Add(celda)

	'	celda = New DataGridViewCheckBoxCell
	'	celda.Value = perfil.PActivo
	'	fila.Cells.Add(celda)

	'	celda = New DataGridViewTextBoxCell
	'	celda.Value = perfil.Pperfilid
	'	fila.Cells.Add(celda)

	'	grdPerfiles.Rows.Add(fila)


	'End Sub

	'Public Sub InitCombos()
	'	Dim objDepartamentosBU As New Negocios.DepartamentosBU
	'	Dim tablaDepartamentos As New DataTable
	'	tablaDepartamentos = objDepartamentosBU.listaDepartamentosActivos
	'	tablaDepartamentos.Rows.InsertAt(tablaDepartamentos.NewRow, 0)
	'	With cmbDepartamento
	'		.DisplayMember = "grup_name"
	'		.ValueMember = "grup_grupoid"
	'		.DataSource = tablaDepartamentos
	'	End With

	'End Sub
	''
	Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
		grbListaAcciones.Height = 39
		grdAcciones.Height = 375
		grdAcciones.Top = 126


	End Sub

	Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
		grbListaAcciones.Height = 167
		grdAcciones.Height = 254
		grdAcciones.Top = 248
	End Sub

	Private Sub txtNombreDeLaAccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreDeLaAccion.TextChanged

	End Sub

	Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
		'MessageBox.Show(cmbTipo.SelectedValue.ToString)
		grdAcciones.Rows.Clear()
		llenarTabla()

	End Sub

	Private Sub cmbTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged

	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDeLaAccion.Text = ""
		txtClave.Text = ""
		cmbModulo.SelectedIndex = 0
		cmbTipo.SelectedIndex = 0
		rdoActivo.Checked = True
		grdAcciones.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub txtClave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbModulo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbModulo.KeyPress
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbTipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipo.KeyPress
		e.Handled = True
		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class