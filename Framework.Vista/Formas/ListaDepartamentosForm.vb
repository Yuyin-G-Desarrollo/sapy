Imports Framework.Negocios

Public Class ListaDepartamentosForm

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
		'
		Dim altasForm As New AltasDepartamentosForm
        'altasForm.MdiParent = Me.MdiParent
        'altasForm.Show()
        If altasForm.ShowDialog = DialogResult.OK Then
            llenarTabla()
        End If

        'AltasDepartamentosForm.Show()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Dim departamentoid As Int32 = 0
        For Each fila As DataGridViewRow In grdDepartamentos.SelectedRows
            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColId") Then
                    departamentoid = CInt(columna.Value)
                    Dim formaEditarDepartamento As New EditarDepartamentosForm
                    'formaEditarDepartamento.MdiParent = Me.MdiParent
                    formaEditarDepartamento.Ddepartamentoid = departamentoid
                    If formaEditarDepartamento.ShowDialog = Windows.Forms.DialogResult.OK Then
                        llenarTabla()
                    End If
                    'formaEditarDepartamento.Show()

                End If
            Next
        Next

    End Sub

    Private Sub btnPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermisos.Click
		For Each row As DataGridViewRow In grdDepartamentos.SelectedRows
			For Each cell As DataGridViewCell In row.Cells
				If (cell.OwningColumn.Name = "ColId") Then
					Dim perfiles As New ListaPerfilesForm
					perfiles.idDepartamento = CInt(cell.Value)
					perfiles.Show()
				End If
			Next
		Next
	End Sub

	Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
		grbDepartamentos.Height = 38
		grdDepartamentos.Height = 365
		grdDepartamentos.Top = 124

	End Sub

	Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
		grbDepartamentos.Height = 175
		grdDepartamentos.Height = 230
		grdDepartamentos.Top = 260

	End Sub

	Private Sub ListaDepartamentosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        grdDepartamentos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDepartamentos.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDepartamentos.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_GRUP", "WRITE") Then
            btnAltas.Visible = True
            lblAltas.Visible = True
        Else
            btnAltas.Visible = False
            lblAltas.Visible = False
        End If
        'prueba.Show()

		If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_GRUP", "UPDATE") Then
			btnEditar.Visible = True
			Editar.Visible = True
		Else
			btnEditar.Visible = False
			btnEditar.Visible = False
		End If

		If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_GRUP", "PERFILES") Then
			btnPermisos.Visible = True
			lblPerfiles.Visible = True
		Else
			btnPermisos.Visible = False
			lblPerfiles.Visible = False
		End If

		'llenarTabla()

		If cmbAreas.SelectedIndex >= 0 Then
			initComboNave()
		Else
			initCombos()
		End If

        'lblListaDepartamentos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblPerfiles.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'grdDepartamentos.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

    End Sub

    Public Sub AgregarFila(ByVal departamento As Entidades.Departamentos)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = departamento.Ddepartamentoid
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
        celda.Value = departamento.DNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = departamento.PNave.PNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = departamento.DAreas.PNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = departamento.DActivo
		fila.Cells.Add(celda)
        
		grdDepartamentos.Rows.Add(fila)

    End Sub

	Public Sub llenarTabla()
        grdDepartamentos.Rows.Clear()
		Dim Nave As Int32 = 0
		If cmbNaves.SelectedIndex > 0 Then
			Nave = CInt(cmbNaves.SelectedValue)
		End If
		Dim Area As Int32 = 0
		If cmbAreas.SelectedIndex > 0 Then
			Area = CInt(cmbAreas.SelectedValue)
		End If
		Dim listaDepartamentos As New List(Of Entidades.Departamentos)
		Dim objBU As New Negocios.DepartamentosBU
		listaDepartamentos = objBU.listaDepartamentos(txtNombreDelDepartamento.Text, rdoSi.Checked, Nave, Area)
		For Each objeto As Entidades.Departamentos In listaDepartamentos
			AgregarFila(objeto)
		Next
	End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
		grdDepartamentos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDelDepartamento.Text = ""
		rdoSi.Checked = True
		cmbNaves.SelectedIndex = -1
		cmbAreas.SelectedIndex = -1
		grdDepartamentos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub initCombos()
		cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

		'Dim nave As Int32 = 0
		'cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		'If cmbNaves.SelectedIndex > 0 Then
		'	nave = CInt(cmbNaves.SelectedValue)
		'End If
		'cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)

	End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNaves.SelectedIndexChanged
		Dim naves As Int32 = 0
		If cmbNaves.SelectedIndex > 0 Then
			naves = CInt(cmbNaves.SelectedValue)
		End If
		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, naves)
	End Sub

    Private Sub initComboNave()
		'cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		Dim naves As Int32 = 0
		If cmbNaves.SelectedIndex > 0 Then
			naves = CInt(cmbNaves.SelectedValue)
		End If
		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, naves)
	End Sub

	
End Class