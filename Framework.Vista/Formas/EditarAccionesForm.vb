Imports Framework.Negocios

Public Class EditarAccionesForm
	Public idAcciones As Integer

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

		Dim falla As Boolean = False
		If txtNombreDeLaAccion.Text <> "" Then

			lblNombreDeLaAccion.ForeColor = Color.Black
		Else


			lblNombreDeLaAccion.ForeColor = Color.Red
			falla = True

		End If

		If txtClave.Text <> "" Then

			lblClave.ForeColor = Color.Black
		Else


			lblClave.ForeColor = Color.Red
			falla = True

		End If

		If cmbModulo.Text <> "" Then

			lblModulo.ForeColor = Color.Black
		Else


			lblModulo.ForeColor = Color.Red
			falla = True

		End If
		If cmbTipo.Text <> "" Then

			lblTipo.ForeColor = Color.Black
		Else


			lblTipo.ForeColor = Color.Red
			falla = True

		End If


		If falla Then
			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.MdiParent = Me.MdiParent
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()
			'MsgBox("Falta completar campos")
		Else
			Dim Accion As New Entidades.Acciones
			Dim Modulos As New Entidades.Modulos

			Accion.PNombre = txtNombreDeLaAccion.Text
			Accion.PClave = txtClave.Text
			Accion.PActivo = rdoActivo.Checked


			If cmbModulo.SelectedIndex > 0 Then
				Modulos.PModuloid = CInt(cmbModulo.SelectedValue)
				Accion.PModulo = Modulos
				'Accion.PModulo.PModuloid = CInt(cmbModulo.SelectedValue)
			End If


			If cmbTipo.SelectedIndex > 0 Then
				Accion.PTipo = CInt(cmbTipo.SelectedValue)
			End If
			'
			Accion.PAccionId = idAcciones
			'
			Dim objAccionBU As New AccionesBU
			objAccionBU.EditarAcciones(Accion)
			Me.Close()

			

			Dim mensajeExito As New ExitoForm

			mensajeExito.mensaje = "Registro Guardado"
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.ShowDialog()

			

			'MsgBox("Transaccion exitosa")
			Me.Close()
		End If
	End Sub


	Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)

	End Sub

	Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtNombreDelComponente_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub EditarAccionesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

		InitCombos()
		Dim objACCIONBU As New AccionesBU
		Dim accion As New Entidades.Acciones
		Dim Modulos As New Entidades.Modulos

		'accion = objACCIONBU.listaAcciones(idAcciones)
		accion = objACCIONBU.buscarAccionesModulo(idAcciones)
		txtNombreDeLaAccion.Text = accion.PNombre
		txtClave.Text = accion.PClave


		'If cmbModulo.SelectedIndex > 0 Then

		'End If


		cmbModulo.SelectedValue = accion.PModulo.PModuloid

		'Modulos.PModuloid = CInt(cmbModulo.SelectedValue)
		accion.PModulo.PModuloid = Modulos.PModuloid

		cmbTipo.SelectedValue = accion.PTipo

		If (accion.PActivo) Then
			rdoActivo.Checked = True
		Else
			rdoInactivo.Checked = True
		End If

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
		dr("Codigo") = "-1"
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
		'tablaTipo = objTipoBU.listaAccionesActivos
		'tablaTipo.Rows.InsertAt(tablaTipo.NewRow, 0)
		'With cmbTipo
		'	.DisplayMember = "acmo_tipo"
		'	.ValueMember = "acmo_tipo"
		'	.DataSource = tablaTipo
		'End With

	End Sub

	Private Sub txtNombreDeLaAccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDeLaAccion.KeyPress
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

	Private Sub txtClave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class