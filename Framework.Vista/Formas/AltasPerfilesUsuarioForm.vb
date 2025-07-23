Public Class AltasPerfilesUsuarioForm

	Private Sub AltasPerfilesUsuarioForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		InitCombos()
	End Sub
	Public Sub InitCombos()

		'Dim nave As Int32 = 0


		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		'If cmbNave.SelectedIndex > 0 Then
		'	nave = CInt(cmbNave.SelectedValue)
		'End If
		'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)


		'Dim departamento As Int32 = 0

		''cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)

		'If cmbDepartamento.SelectedIndex > 0 Then
		'	departamento = CInt(cmbDepartamento.SelectedValue)
		'End If
		'cmbPerfil = Tools.Controles.ComboPerfilSegunDepartamento(cmbPerfil, departamento)
		


		'Dim objgrupoBU As New Framework.Negocios.DepartamentosBU
		'Dim tabla As New DataTable
		'tabla = objgrupoBU.listaDepartamentosActivos
		'tabla.Rows.InsertAt(tabla.NewRow, 0)
		'With cmbDepartamento
		'	.DisplayMember = "grup_name"
		'	.ValueMember = "grup_grupoid"
		'	.DataSource = tabla
		'End With

		'Dim objPerfBU As New Framework.Negocios.PerfilesBU
		'Dim tablaPerf As New DataTable
		'tablaPerf = objPerfBU.listaPerfilesActivos
		'tablaPerf.Rows.InsertAt(tablaPerf.NewRow, 0)
		'With cmbPerfil
		'	.DisplayMember = "perf_nombre"
		'	.ValueMember = "perf_perfilid"
		'	.DataSource = tablaPerf
		'End With


		Dim objUsuarioBU As New Framework.Negocios.UsuariosBU
		Dim tablaUsuarios As New DataTable
		tablaUsuarios = objUsuarioBU.ListaUsuariosTodos
		tablaUsuarios.Rows.InsertAt(tablaUsuarios.NewRow, 0)
		With cmbUsuario
			.DisplayMember = "user_username"
			.ValueMember = "user_usuarioid"
			.DataSource = tablaUsuarios
		End With


	End Sub
	

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False


		'If cmbDepartamento.Text <> "" Then

		'	lblDepartamento.ForeColor = Color.Black
		'Else


		'lblDepartamento.ForeColor = Color.Red
		'falla = True

		'End If
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
			mensajeAdvertencia.MdiParent = Me.MdiParent

			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()
			'MsgBox("Falta completar campos")
		Else
			Dim peus As New Entidades.PerfilesUsuario
			Dim perfil As New Entidades.Perfiles
			Dim usuarios As New Entidades.Usuarios
			'Dim grupo As New Entidades.Departamentos


			'If cmbDepartamento.SelectedIndex > 0 Then
			'	grupo.Ddepartamentoid = cmbDepartamento.SelectedIndex

			'	peus.PDepartamento = grupo

			'End If

			If cmbPerfil.SelectedIndex > 0 Then
				perfil.Pperfilid = CInt(cmbPerfil.SelectedValue)

				peus.PPerfil = perfil

			End If

			If cmbUsuario.SelectedIndex > 0 Then
				usuarios.PUserUsuarioid = CInt(cmbUsuario.SelectedValue)

                peus.PUsuario = usuarios

			End If

			Dim objBu As New Negocios.PerfilesUsuarioBU
			Dim mensajeNegocios As String = ""

			mensajeNegocios = objBu.Altas(peus)

			If (mensajeNegocios.Length = 0) Then
				Me.Close()



				Dim mensajeExito As New ExitoForm
                'mensajeExito.MdiParent = Me.MdiParent
				mensajeExito.mensaje = "Transaccion exitosa"
                mensajeExito.ShowDialog()

			Else
				Dim mensajeAdvertencias As New AdvertenciaForm
				mensajeAdvertencias.mensaje = mensajeNegocios
				mensajeAdvertencias.Show()
			End If

			'MsgBox("Transaccion exitosa")
			Me.Close()
		End If

	End Sub

	'Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartamento.KeyPress
	'	e.Handled = True

	'	If Char.IsControl(e.KeyChar) Then

	'		e.Handled = False
	'	End If
	'End Sub

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

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
	End Sub

	Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
		Dim departamento As Int32 = 0
		If cmbDepartamento.SelectedIndex > 0 Then
			departamento = CInt(cmbDepartamento.SelectedValue)
		End If
		cmbPerfil = Tools.Controles.ComboPerfilSegunDepartamento(cmbPerfil, departamento)
	End Sub

End Class