Imports Framework.Negocios

Public Class AltasBancosForm

	Private Sub AltasBancosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Dim mensajeAdvertencia As New AdvertenciaForm
        'mensajeAdvertencia.mensaje = "Faltan campos por completar"
        'mensajeAdvertencia.Show()
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()

	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreBancos.Text <> "" Then

			lblNombreBancos.ForeColor = Color.Black
		Else


			lblNombreBancos.ForeColor = Color.Red
			falla = True

		End If

		If falla Then

			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.Show()


			'MsgBox("Falta completar campos")
		Else
			Dim banco As New Entidades.Bancos

			banco.PNombre = txtNombreBancos.Text
			banco.PActivo = rdoSi.Checked

			Dim objbancoBU As New BancosBU

			objbancoBU.AltasBancos(banco)
			Me.Close()

			Dim mensajeExito As New ExitoForm
			mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.ShowDialog()


			'MsgBox("Transaccion exitosa")

			'Me.Close()
		End If
		'Me.Close()
	End Sub

	Private Sub txtNombreBancos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreBancos.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class