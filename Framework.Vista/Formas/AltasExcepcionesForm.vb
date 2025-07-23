Imports Framework.Negocios

Public Class AltasExcepcionesForm

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False

		If cmbExcepciones.Text <> "" Then

			lblModulo.ForeColor = Color.Black
		Else


			lblModulo.ForeColor = Color.Red
			falla = True

		End If
		If cmbAccion.Text <> "" Then

			lblAccion.ForeColor = Color.Black
		Else


			lblAccion.ForeColor = Color.Red
			falla = True

		End If
		If cmbDepartamento.Text <> "" Then

			lblDepartamento.ForeColor = Color.Black
		Else


			lblDepartamento.ForeColor = Color.Red
			falla = True

		End If
		If cmbPerfil.Text <> "" Then

			lblPerfil.ForeColor = Color.Black
		Else


			lblPerfil.ForeColor = Color.Red
			falla = True


		End If

		If cmbUsuario.Text <> "" Then
			lblUsuario.ForeColor = Color.Black
		Else
			lblUsuario.ForeColor = Color.Red
			falla = True
		End If
		If falla Then

			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()
			'MsgBox("Falta completar campos")
		Else

			Dim permisos As New Entidades.PermisosUsuario
			Dim accion As New Entidades.Acciones
			Dim departamento As New Entidades.Departamentos
			Dim perfil As New Entidades.Perfiles
			Dim modulo As New Entidades.Modulos
			Dim usuario As New Entidades.Usuarios


			If cmbAccion.SelectedIndex > 0 Then
				accion.PAccionId = CInt(cmbAccion.SelectedValue)




				'celula.PDepartamento.PNave.PNaveId = CInt(cmbNave.SelectedValue)


			End If

			If cmbDepartamento.SelectedIndex > 0 Then
				departamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
				'

			End If

			If cmbPerfil.SelectedIndex > 0 Then
				perfil.Pperfilid = CInt(cmbPerfil.SelectedValue)

			End If

			If cmbUsuario.SelectedIndex > 0 Then
				usuario.PUserUsuarioid = CInt(cmbUsuario.SelectedValue)

			End If
			If cmbExcepciones.SelectedIndex > 0 Then
				modulo.PModuloid = CInt(cmbExcepciones.SelectedValue)
				
			End If




			



			Dim permiso As Int32 = 1
			If rdoAutorizar.Checked Then
				permiso = 1
			Else
				permiso = 2
			End If

			permisos.PUsuarioid = usuario
			permisos.PAccionid = accion
			permisos.pTipoPermiso = permiso

			Dim objpermisosBU As New PermisosUsuarioBU
			Dim mensajeNegocios As String = ""
			mensajeNegocios = objpermisosBU.altasPermisosUsuario(permisos)

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

	Private Sub AltasExcepcionesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		InitCombos()
	End Sub
	Public Sub InitCombos()
		'Carga combo de modulos
		Dim objmoduloBU As New Framework.Negocios.ModulosBU
		Dim tablamodulos As New DataTable
		tablamodulos = objmoduloBU.ListaModulosTodos
		tablamodulos.Rows.InsertAt(tablamodulos.NewRow, 0)
		With cmbExcepciones
			.DisplayMember = "modu_nombre"
			.ValueMember = "modu_moduloid"
			.DataSource = tablamodulos
		End With

		'Carga combo de acciones segun el modulo
		If cmbExcepciones.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbExcepciones.SelectedValue))
		End If


		'Carga combo departamentos
		cmbDepartamento = Nomina.Vista.Controles.ComboDepartamentos(cmbDepartamento)

		'Carga combo perfiles segun el departamento seleccionado
		If cmbDepartamento.SelectedIndex > 0 Then
			cmbPerfil = Controles.ComboPerfilSegunDepartamento(cmbPerfil, CInt(cmbDepartamento.SelectedValue))
		End If

		Dim objUsuariosBU As New Framework.Negocios.UsuariosBU
		Dim tablaUsuarios As New DataTable
		tablaUsuarios = objUsuariosBU.ListaUsuariosTodos
		tablaUsuarios.Rows.InsertAt(tablaUsuarios.NewRow, 0)
		With cmbUsuario
			.DisplayMember = "user_username"
			.ValueMember = "user_usuarioid"
			.DataSource = tablaUsuarios
		End With

	End Sub

	Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
		If cmbDepartamento.SelectedIndex > 0 Then
			cmbPerfil = Controles.ComboPerfilSegunDepartamento(cmbPerfil, CInt(cmbDepartamento.SelectedValue))
		End If
	End Sub

	Private Sub cmbExcepciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbExcepciones.SelectedIndexChanged
		If cmbExcepciones.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbExcepciones.SelectedValue))
		End If
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

	Private Sub cmbUsuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuario.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class