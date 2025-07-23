Imports Framework.Negocios

Public Class AltasDepartamentosForm

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreDelDepartamento.Text <> "" Then

			lblNombreDepartamento.ForeColor = Color.Black
		Else


			lblNombreDepartamento.ForeColor = Color.Red
			falla = True

		End If

		If falla Then
			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.MdiParent = Me.MdiParent
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.ShowDialog()
			'MsgBox("Falta completar campos")
		Else
			Dim Departamento As New Entidades.Departamentos
			'Dim nave As New Entidades.Naves
			Departamento.DNombre = txtNombreDelDepartamento.Text
			Departamento.DActivo = rdoSi.Checked
			If cmbNaves.SelectedIndex > 0 Then
				Dim nave As New Entidades.Naves
				nave.PNaveId = CInt(cmbNaves.SelectedValue)
				Departamento.PNave = nave

			End If

			If cmbAreas.SelectedIndex > 0 Then
				Dim AREA As New Entidades.Areas
				AREA.PAreaid = CInt(cmbAreas.SelectedValue)
				Departamento.DAreas = AREA

			End If

			'Me.Close()
			Dim objDepartamentosBU As New DepartamentosBU
			objDepartamentosBU.guardarDepartamento(Departamento)

			'Me.Close()
			Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Transaccion exitosa"
			mensajeExito.ShowDialog()

			'MsgBox("Transaccion exitosa")
			Me.Close()
			End If
	End Sub
	Public Sub InitCombos()


		Dim nave As Int32 = 0
		cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbNaves.SelectedIndex > 0 Then
			nave = CInt(cmbNaves.SelectedValue)
		End If
		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)


	End Sub
	Private Sub AltasDepartamentosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

		InitCombos()
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblLAltasDepartamentos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

	End Sub

	Private Sub cmbNaves_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNaves.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNaves.SelectedIndex > 0 Then
			nave = CInt(cmbNaves.SelectedValue)
		End If
		cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)
	End Sub

End Class