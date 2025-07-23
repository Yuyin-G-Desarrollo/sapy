Imports Framework.Negocios

Public Class AltasNavesForm

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreNave.Text <> "" Then

			lblNombreDeLaNave.ForeColor = Color.Black
		Else


			lblNombreDeLaNave.ForeColor = Color.Red
			falla = True

		End If

		If falla Then

			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.MdiParent = Me.MdiParent
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.ShowDialog()


			'MsgBox("Falta completar campos")
		Else
			Dim nave As New Entidades.Naves

			nave.PNombre = txtNombreNave.Text
			nave.PActivo = rdoSi.Checked

			Dim objNavesBU As New NavesBU

			objNavesBU.guardarNaves(nave)

			Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Transaccion exitosa"
			mensajeExito.ShowDialog()


			'MsgBox("Transaccion exitosa")

			'Me.Close()
		End If
		'Me.Close()
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()

	End Sub

	Private Sub AltasNavesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblLAltasNaves.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

	End Sub
End Class