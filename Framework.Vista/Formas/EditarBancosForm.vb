Imports Framework.Negocios

Public Class EditarBancosForm
	Public bancosid As Integer
	Public Property PBancosid As Integer
		Get
			Return bancosid
		End Get
		Set(value As Integer)
			bancosid = value
		End Set
	End Property
	Private Sub EditarBancosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		Dim objbancoBu As New BancosBU
		Dim banco As New Entidades.Bancos
		banco = objbancoBu.buscarBancos(bancosid)

		txtNombreBancos.Text = banco.PNombre


		If (banco.PActivo) Then
			rdoSi.Checked = True
		Else
			rdoNo.Checked = True
		End If


	End Sub


	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreBancos.Text <> "" Then

			lblNombreBanco.ForeColor = Color.Black
		Else


			lblNombreBanco.ForeColor = Color.Red
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
			banco.PBancosId = bancosid

			Dim objBancoBU As New BancosBU
			objBancoBU.editarBancos(banco)
			Me.Close()
			'MsgBox("Transaccion exitosa")
			Dim mensajeExito As New ExitoForm
			mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.ShowDialog()
			'Me.Close()

			txtNombreBancos.Text = ""
			rdoSi.Checked = True


		End If
	End Sub


	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
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