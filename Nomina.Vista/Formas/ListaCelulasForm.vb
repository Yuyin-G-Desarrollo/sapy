Imports Entidades
Imports Framework

Public Class ListaCelulasForm
	Private departamentosid As Int32
	Private naveid As Int32
	Public Property Pnaveid As Int32
		Get
			Return naveid

		End Get
		Set(value As Int32)
			naveid = value

		End Set
	End Property

	Public Property Pdepartamentosid As Int32
		Get
			Return departamentosid
		End Get
		Set(value As Int32)
			departamentosid = value

		End Set
	End Property

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasCelulasForm
		'altasForm.MdiParent = Me.MdiParent
		'altasForm.Show()
		If altasForm.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If
		'AltasCelulasForm.Show()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		'EditarCelulasForm.Show()
		Dim celulaid As Int32 = 0
		For Each fila As DataGridViewRow In grdCelulas.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "ColId") Then
					celulaid = CInt(columna.Value)

		
		Dim formaEditarcelula As New EditarCelulasForm
		'formaEditarcelula.MdiParent = Me.MdiParent
		formaEditarcelula.Pcelulaid = celulaid
		If formaEditarcelula.ShowDialog = DialogResult.OK Then
			llenarTabla()
		End If
					'formaEditarcelula.Show()
				End If
			Next
		Next
	End Sub

	Private Sub ListaCelulasForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        grdCelulas.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCelulas.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCelulas.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCelulas.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'lblCelulas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'grdCelulas.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


		InitCombos()

		If departamentosid > 0 Then
			cmbDepartamento.SelectedValue = departamentosid
		End If

		If naveid > 0 Then
			cmbNave.SelectedValue = naveid
		End If
		
		'llenarTabla()
	End Sub
	Public Sub llenarTabla()
		grdCelulas.Rows.Clear()

		Dim departamento As Int32 = 0
		Dim nave As Int32 = 0

		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)

		End If

		If cmbDepartamento.SelectedIndex > 0 Then
			departamento = CInt(cmbDepartamento.SelectedValue)
		End If


		Dim listacelulas As New List(Of Entidades.Celulas)
		Dim objBU As New Negocios.CelulasBU
		listacelulas = objBU.listaCelulas(txtnombre.Text, nave, departamento, btnSi.Checked)
		For Each celula As Entidades.Celulas In listacelulas

			AgregarFila(celula)
		Next
	End Sub

	Public Sub AgregarFila(ByVal celula As Entidades.Celulas)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = celula.PcelulaID
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = celula.PNombre.ToUpper
		fila.Cells.Add(celda)

		'celda = New DataGridViewTextBoxCell
		'celda.Value = celula.PDepartamento.PNave
		'fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = celula.PDepartamento.PNave.PNombre.ToUpper

		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = celula.PDepartamento.DNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = celula.Pactivo
		fila.Cells.Add(celda)



		grdCelulas.Rows.Add(fila)


	End Sub

	Public Sub InitCombos()

		Dim nave As Int32 = 0
		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)

		'cmbDepartamento = Controles.ComboDepartamentosSegunNavesUsuario(cmbDepartamento)

		'Dim objdeptoBU As New Framework.Negocios.DepartamentosBU
		'Dim tabladepto As New DataTable
		'tabladepto = objdeptoBU.listaDepartamentosActivos
		'tabladepto.Rows.InsertAt(tabladepto.NewRow, 0)
		'With cmbDepartamento
		'	.DisplayMember = "grup_name"
		'	.ValueMember = "grup_grupoid"
		'	.DataSource = tabladepto
		'End With

		'cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
	End Sub
	
	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdCelulas.Rows.Clear()

		grdCelulas.Rows.Clear()
		If (txtnombre.Text.Length > 0 Or cmbNave.SelectedIndex > 0 Or cmbDepartamento.SelectedIndex > 0) Then
			llenarTabla()
		End If



	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtnombre.Text = ""
		cmbDepartamento.SelectedIndex = 0
		cmbNave.SelectedIndex = 0
		btnSi.Checked = True
		grdCelulas.Rows.Clear()
		'llenarTabla()
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbCelulas.Height = 157

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbCelulas.Height = 45

	End Sub

	Private Sub txtnombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnombre.TextChanged

	End Sub

	Private Sub txtnombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
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

	Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartamento.KeyPress
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

	Private Sub grdCelulas_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCelulas.CellContentClick

	End Sub
End Class