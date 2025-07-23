Imports Framework.Negocios

Public Class ListaPuestosForm
    Public idNave As Entidades.Naves
    Dim Consecutivo As Int32

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasPuestosForm
        'If altasForm.ShowDialog = Windows.Forms.DialogResult.OK Then
        ' llenarTabla()
        'End If
        'altasForm.MdiParent = Me.MdiParent
        altasForm.Show()

	End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim Area, Departamento As String
        Dim puestosid As Int32 = 0
        Dim orden As Int32 = 0
        For Each fila As DataGridViewRow In grdPuestos.SelectedRows

            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColAreas") Then
                    Area = CStr(columna.Value)


                End If
            Next
            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColDepartamento") Then
                    Departamento = CStr(columna.Value)


                End If
            Next

            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "colOrden") Then
                    orden = CInt(columna.Value)
                End If
            Next

            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColPuestoid") Then
                    puestosid = CInt(columna.Value)

                    Dim formaEditarPuesto As New EditarPuestosForm
                    'formaEditarPuesto.MdiParent = Me.MdiParent
                    formaEditarPuesto.Ppuestoid = puestosid
                    formaEditarPuesto.PArea = Area
                    formaEditarPuesto.PDepartamento = Departamento
                    formaEditarPuesto.POrden = orden
                    'If formaEditarPuesto.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'llenarTabla()
                    'End If

                    formaEditarPuesto.Show()
                End If
            Next
        Next
    End Sub

	Private Sub ListaPuestosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_PUES", "WRITE") Then
            btnAltas.Visible = True
			lblAltas.Visible = True
		Else
			btnAltas.Visible = False
			lblAltas.Visible = False
		End If

		If PermisosUsuarioBU.ConsultarPermiso("NOM_CAT_PUES", "UPDATE") Then
			btnEditar.Visible = True
			Editar.Visible = True
		Else
			btnEditar.Visible = False
			Editar.Visible = False
		End If


		InitCombos()
		'llenarTabla()
        'lblListaPuestos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'grdPuestos.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)
        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
        Me.Top = 0
        Me.Left = 0


	End Sub

	Public Sub llenarTabla()
		grdPuestos.Rows.Clear()

		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If

		Dim depto As Int32 = 0
		If cmbDepartamento.SelectedIndex > 0 Then
			depto = CInt(cmbDepartamento.SelectedValue)
		End If

		Dim Area As Int32 = 0
		If cmbAreas.SelectedIndex > 0 Then
			Area = CInt(cmbAreas.SelectedValue)
		End If

		Dim listaPuestos As New List(Of Entidades.Puestos)
		Dim objBU As New Negocios.puestosBU
		listaPuestos = objBU.listaPuestos(txtNombreDelPuesto.Text, nave, depto, rdoSi.Checked, Area)
		For Each puesto As Entidades.Puestos In listaPuestos
			AgregarFila(puesto)
		Next
	End Sub

	Public Sub AgregarFila(ByVal puesto As Entidades.Puestos)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = puesto.Ppuestosid
		fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivo
        fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
        celda.Value = puesto.PNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = puesto.PNave.PNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = puesto.Pareas.PNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
        celda.Value = puesto.PDepartamento.DNombre.ToUpper
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = puesto.PActivo
		fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = puesto.POrden
        fila.Cells.Add(celda)

		grdPuestos.Rows.Add(fila)

        Consecutivo += 1
	End Sub
	Dim puesto As New Entidades.Puestos
	Dim nave As New Entidades.Naves
	Dim grupo As New Entidades.Departamentos
	Public Sub InitCombos()
		'Dim objNavesBU As New Negocios.NavesBU
		'Dim tablaNAVES As New DataTable
		'tablaNAVES = objNavesBU.listaNavesActivas
		'tablaNAVES.Rows.InsertAt(tablaNAVES.NewRow, 0)
		'With cmbNave
		'	.DisplayMember = "nave_nombre"
		'	.ValueMember = "nave_naveid"
		'	.DataSource = tablaNAVES
		'End With
		Dim nave As Int32 = 0
		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)

		End If

		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)


		'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
		'puesto.PNave.PNaveId = nave

		Dim Area As Int32 = 0
		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbAreas.SelectedIndex > 0 Then
			Area = CInt(cmbAreas.SelectedValue)

		End If

		cmbDepartamento = Controles.ComboDepatamentoSegunArea(cmbDepartamento, Area)


        Try
            Dim nave2 As Int32 = 0
            If cmbNave.SelectedIndex > 0 Then
                nave2 = CInt(cmbNave.SelectedValue)
            End If

            cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave2)
        Catch ex As Exception

        End Try




	
	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        grdPuestos.Rows.Clear()
        Consecutivo = 1
		If (txtNombreDelPuesto.Text.Length > 0 Or cmbNave.SelectedIndex > 0 Or cmbDepartamento.SelectedIndex > 0) Then
			llenarTabla()
		End If


	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDelPuesto.Text = ""
		cmbNave.SelectedIndex = 0
		rdoSi.Checked = True
		grdPuestos.Rows.Clear()
		'llenarTabla()
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbPuestos.Height = 45
		grdPuestos.Height = 447
		grdPuestos.Top = 130
        txtNombreDelPuesto.Visible = False
        lblNombreDelPuesto.Visible = False
	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbPuestos.Height = 171
        grdPuestos.Height = 321
        grdPuestos.Top = 253
        txtNombreDelPuesto.Visible = True
        lblNombreDelPuesto.Visible = True

	End Sub

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		'Dim nave As Int32 = 0
		'If cmbNave.SelectedIndex > 0 Then
		'	nave = CInt(cmbNave.SelectedValue)
		'End If
		'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
        End If

        cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)
    End Sub

	Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        
        
    End Sub
        
       

	Private Sub cmbAreas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbAreas.SelectedIndexChanged

       

        Dim Area As Int32 = 0

		If cmbAreas.SelectedIndex > 0 Then
			Area = CInt(cmbAreas.SelectedValue)

		End If

		cmbDepartamento = Controles.ComboDepatamentoSegunArea(cmbDepartamento, Area)

    End Sub

    Private Sub txtNombreDelPuesto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreDelPuesto.KeyDown

    End Sub

    Private Sub txtNombreDelPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPuesto.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreDelPuesto.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreDelPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreDelPuesto.TextChanged

    End Sub

   
    Private Sub lblAreas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAreas.Click

    End Sub
End Class