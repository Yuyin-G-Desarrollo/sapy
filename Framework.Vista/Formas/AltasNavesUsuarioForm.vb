Imports Framework.Negocios

Public Class AltasNavesUsuarioForm

	Private Sub grbExcepciones_Enter(sender As System.Object, e As System.EventArgs) Handles grbExcepciones.Enter

	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		

		If cmbNaves.Text <> "" Then

			lblNaves.ForeColor = Color.Black
		Else


			lblNaves.ForeColor = Color.Red
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
			mensajeAdvertencia.ShowDialog()
			'MsgBox("Falta completar campos")
		Else
			Dim Naus As New Entidades.NavesUsuario
			Dim naves As New Entidades.Naves
			Dim usuario As New Entidades.Usuarios


			If cmbNaves.SelectedIndex > 0 Then
				naves.PNaveId = CInt(cmbNaves.SelectedValue)

				Naus.PNavesID = naves

			End If

			If cmbUsuario.SelectedIndex > 0 Then
				usuario.PUserUsuarioid = CInt(cmbUsuario.SelectedValue)

				Naus.PUsuariosID = usuario

			End If

			Dim objexeBU As New Negocios.NavesUsuarioBU

			Dim mensajeNegocios As String = ""

			mensajeNegocios = objexeBU.guardar(Naus)

			If (mensajeNegocios.Length = 0) Then

				Me.Close()
				Dim mensajeExito As New ExitoForm
                'mensajeExito.MdiParent = Me.MdiParent
				mensajeExito.mensaje = "Transaccion exitosa"
				mensajeExito.ShowDialog()
			Else
				Dim mensajeAdvertencias As New AdvertenciaForm
				mensajeAdvertencias.mensaje = mensajeNegocios
				mensajeAdvertencias.ShowDialog()
				'MsgBox("Transaccion exitosa")
				Me.Close()
			End If
		End If
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub
	Public Sub InitCombos()

		Dim objNavesBU As New Framework.Negocios.NavesBU
		Dim tablaNaves As New DataTable
		tablaNaves = objNavesBU.listaNavesActivas
		tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
		With cmbNaves
			.DisplayMember = "nave_nombre"
			.ValueMember = "nave_naveid"
			.DataSource = tablaNaves
		End With


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

	Private Sub AltasNavesUsuarioForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblLAltasNaves.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


		InitCombos()
	End Sub

    Private Sub pnlEncabezado_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub
End Class