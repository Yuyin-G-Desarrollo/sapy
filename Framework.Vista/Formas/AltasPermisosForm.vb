Imports Framework.Negocios

Public Class AltasPermisosForm

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub lblModulo_Click(sender As System.Object, e As System.EventArgs) Handles lblModulo.Click

	End Sub

	Private Sub AltasPermisosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'lblAltasPermisos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)


        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
		InitCombos()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		'	Dim falla As Boolean = False


		'	If cmbModulo.Text <> "" Then

		'		lblModulo.ForeColor = Color.Black
		'	Else


		'		lblModulo.ForeColor = Color.Red
		'		falla = True

		'	End If


		'	If cmbAccion.Text <> "" Then

		'		lblAccion.ForeColor = Color.Black
		'	Else


		'		lblAccion.ForeColor = Color.Red
		'		falla = True

		'	End If
		'	If cmbDepartamento.Text <> "" Then

		'		lblDepartamento.ForeColor = Color.Black
		'	Else


		'		lblDepartamento.ForeColor = Color.Red
		'		falla = True

		'	End If
		'	If cmbPerfil.Text <> "" Then

		'		lblPerfil.ForeColor = Color.Black
		'	Else


		'		lblPerfil.ForeColor = Color.Red
		'		falla = True

		'	End If

		'	If falla Then
		'		MsgBox("Falta completar campos")
		'	Else
		'		MsgBox("Transaccion exitosa")
		'	End If

		Dim falla As Boolean = False

		If cmbModulo.Text <> "" Then

			lblModulo.ForeColor = Color.Black
		Else


			lblModulo.ForeColor = Color.Red
			falla = True

		End If
		If cmbDepartamento.Text <> "" Then

			lblDepartamento.ForeColor = Color.Black
		Else


			lblDepartamento.ForeColor = Color.Red
			falla = True

		End If
		If cmbAccion.Text <> "" Then

			lblAccion.ForeColor = Color.Black
		Else


			lblAccion.ForeColor = Color.Red
			falla = True

		End If
		If cmbPerfil.Text <> "" Then

			lblPerfil.ForeColor = Color.Black
		Else


			lblPerfil.ForeColor = Color.Red
			falla = True

		End If
		If falla Then

			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()
			'MsgBox("Falta completar campos")
		Else

			Dim permisos As New Entidades.PermisosPerfil
			Dim accion As New Entidades.Acciones
			Dim departamento As New Entidades.Departamentos
			Dim perfil As New Entidades.Perfiles
			Dim modulo As New Entidades.Modulos



			If cmbAccion.SelectedIndex > 0 Then
				accion.PAccionId = CInt(cmbAccion.SelectedValue)

				'celula.PDepartamento.PNave.PNaveId = CInt(cmbNave.SelectedValue)

			End If

			'If cmbDepartamento.SelectedIndex > 0 Then
			'	departamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
			'	'

			'End If

			If cmbPerfil.SelectedIndex > 0 Then
				perfil.Pperfilid = CInt(cmbPerfil.SelectedValue)

			End If
			If cmbModulo.SelectedIndex > 0 Then
				modulo.PModuloid = CInt(cmbModulo.SelectedValue)
				'celula.PDepartamento.Ddepartamentoid = CInt(cmbDepartamentos.SelectedValue)

			End If



			'accion.PModulo = modulo
			'permisos.Pperfilid.PDepartamento = departamento

			




			permisos.Pperfilid = perfil
			permisos.Paccionid = accion
			Dim objpermisosBU As New PermisosPerfilesBU
			Dim mensajeNegocios As String = ""
			mensajeNegocios = objpermisosBU.altasPermisos(permisos)

			If (mensajeNegocios.Length = 0) Then
				Me.Close()
				Dim mensajeExito As New ExitoForm
				mensajeExito.mensaje = "Registro guardado"
                mensajeExito.ShowDialog()
			Else
				Dim mensajeAdvertencias As New AdvertenciaForm
				mensajeAdvertencias.mensaje = mensajeNegocios
                mensajeAdvertencias.ShowDialog()
			End If

			End If
	End Sub


	Private Sub cmbNivelDeAcceso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

	End Sub
	Public Sub InitCombos()
		'Carga combo de modulos
		Dim objmoduloBU As New Framework.Negocios.ModulosBU
		Dim tablamodulos As New DataTable
		tablamodulos = objmoduloBU.ListaModulosTodos
		tablamodulos.Rows.InsertAt(tablamodulos.NewRow, 0)
		With cmbModulo
			.DisplayMember = "modu_nombre"
			.ValueMember = "modu_moduloid"
			.DataSource = tablamodulos
		End With

		'Carga combo de acciones segun el modulo
		If cmbModulo.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbModulo.SelectedValue))
		End If

		Dim nave As Int32 = 0
		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)

		'Carga combo departamentos
		'cmbDepartamento = Nomina.Vista.Controles.ComboDepartamentos(cmbDepartamento)


		'Carga combo perfiles segun el departamento seleccionado
		If cmbDepartamento.SelectedIndex > 0 Then
			cmbPerfil = Controles.ComboPerfilSegunDepartamento(cmbPerfil, CInt(cmbDepartamento.SelectedValue))
		End If



	End Sub



	Private Sub cmbModulo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbModulo.SelectedIndexChanged
		If cmbModulo.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbModulo.SelectedValue))
		End If
	End Sub

	Private Sub cmbPerfil_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbPerfil.SelectedIndexChanged

	End Sub

	Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
		If cmbDepartamento.SelectedIndex > 0 Then
			cmbPerfil = Controles.ComboPerfilSegunDepartamento(cmbPerfil, CInt(cmbDepartamento.SelectedValue))
		End If
	End Sub

	Private Sub cmbModulo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbModulo.KeyPress
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

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
	End Sub
End Class