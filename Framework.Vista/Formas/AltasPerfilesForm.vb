Imports Framework.Negocios

Public Class AltasPerfilesForm

	Private Sub AltasPerfilesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		initCombos()
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()

	End Sub

	Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreDelPerfil.TextChanged

	End Sub

	Private Sub txtNombreDelPerfil_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPerfil.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreDelPerfil.Text <> "" Then

			lblNombreDelPerfil.ForeColor = Color.Black
		Else


			lblNombreDelPerfil.ForeColor = Color.Red
			falla = True

		End If

		If cmbDepartamento.Text <> "" Then

			lblGrupo.ForeColor = Color.Black
		Else


			lblGrupo.ForeColor = Color.Red
			falla = True

		End If


		If falla Then
			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()
			'MsgBox("Falta completar campos")
		Else
			Dim perfil As New Entidades.Perfiles
			perfil.PNombre = txtNombreDelPerfil.Text
			perfil.PActivo = rdoSi.Checked
			If cmbDepartamento.SelectedIndex > 0 Then
				perfil.PDepartamento = CInt(cmbDepartamento.SelectedValue)
			End If
			Dim objPerfilesBU As New PerfilesBU
			objPerfilesBU.guardarPerfil(perfil)
			Me.Close()
			Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Registro guardado"
            mensajeExito.ShowDialog()
			'MsgBox("Transaccion exitosa")
			Me.Close()
		End If
	End Sub

	Public Sub initCombos()
		Dim objDepartamentosBU As New DepartamentosBU
		Dim tablaDepartamentos As New DataTable
		tablaDepartamentos = objDepartamentosBU.listaDepartamentosActivos()
		tablaDepartamentos.Rows.InsertAt(tablaDepartamentos.NewRow, 0)
		With cmbDepartamento
			.DataSource = tablaDepartamentos
			.DisplayMember = "grup_name"
			.ValueMember = "grup_grupoid"
		End With
	End Sub
End Class