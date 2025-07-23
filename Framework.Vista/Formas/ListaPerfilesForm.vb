Public Class ListaPerfilesForm
    Public idDepartamento As Integer
	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		AltasPerfilesForm.Show()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		Dim IdPerfil As Int32 = 0
		For Each fila As DataGridViewRow In grdPerfiles.SelectedRows
			For Each columna As DataGridViewCell In fila.Cells
				If (columna.OwningColumn.Name = "id") Then
					IdPerfil = CInt(columna.Value)
				End If
			Next
		Next
		Dim formaEditarPerfil As New EditarPerfilesForm
		formaEditarPerfil.PIdPerfil = IdPerfil
		formaEditarPerfil.Show()
	End Sub

	Private Sub txtNombreDelPerfil_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreDelPerfil.TextChanged

	End Sub

	Private Sub txtNombreDelPerfil_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPerfil.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbListaPerfiles.Height = 35
		grdPerfiles.Height = 288
		grdPerfiles.Top = 121

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbListaPerfiles.Height = 167
		grdPerfiles.Height = 158
		grdPerfiles.Top = 252
	End Sub

	Private Sub btnPermisos_Click(sender As System.Object, e As System.EventArgs) Handles btnPermisos.Click
		'Dim permisos As New ListaPermisoForm
		'permisos.MdiParent = Me.MdiParent
		'permisos.Show()


		ListaPermisoForm.Show()
		''Utilerias.AbrirForma("ListaPermisoForm")

	End Sub

    Private Sub ListaPerfilesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitCombos()
        If idDepartamento > 0 Then
            cmbDepartamento.SelectedValue = idDepartamento
        End If
        llenarTabla()

        'ListaDepartamentosForm.Show()
    End Sub

	Public Sub llenarTabla()
		Dim departamento As Int32 = 0
		If cmbDepartamento.SelectedIndex > 0 Then
			departamento = CInt(cmbDepartamento.SelectedValue)
		End If

		Dim listaPerfiles As New List(Of Entidades.Perfiles)
        Dim objBU As New Negocios.PerfilesBU
		listaPerfiles = objBU.listaPerfiles(txtNombreDelPerfil.Text, departamento, rdoSi.Checked)
		For Each perfil As Entidades.Perfiles In listaPerfiles
			AgregarFila(perfil)
		Next
	End Sub

	Public Sub AgregarFila(ByVal perfil As Entidades.Perfiles)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = perfil.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = perfil.PNombreDepartamento
		fila.Cells.Add(celda)

		celda = New DataGridViewCheckBoxCell
		celda.Value = perfil.PActivo
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = perfil.Pperfilid
		fila.Cells.Add(celda)

		grdPerfiles.Rows.Add(fila)


	End Sub

	Public Sub InitCombos()
		Dim objDepartamentosBU As New Negocios.DepartamentosBU
		Dim tablaDepartamentos As New DataTable
		tablaDepartamentos = objDepartamentosBU.listaDepartamentosActivos
		tablaDepartamentos.Rows.InsertAt(tablaDepartamentos.NewRow, 0)
		With cmbDepartamento
			.DisplayMember = "grup_name"
			.ValueMember = "grup_grupoid"
			.DataSource = tablaDepartamentos
		End With

	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdPerfiles.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		txtNombreDelPerfil.Text = ""
		cmbDepartamento.SelectedIndex = 0
		rdoSi.Checked = True
		grdPerfiles.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		ListaPerfilesUsuarioForm.Show()
	End Sub
End Class