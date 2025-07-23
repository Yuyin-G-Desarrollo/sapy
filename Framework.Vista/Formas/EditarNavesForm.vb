Imports Framework.Negocios

Public Class EditarNavesForm
	Public navesid As Integer
	Public Property PNavesid As Integer
		Get
			Return navesid
		End Get
		Set(value As Integer)
			navesid = value
		End Set
	End Property

	Private Sub EditarNavesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblLEditarNaves.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		Dim objNaveBu As New NavesBU
		Dim nave As New Entidades.Naves
		nave = objNaveBu.buscarNaves(navesid)

		txtNombreNave.Text = nave.PNombre


		If (nave.PActivo) Then
			rdoSi.Checked = True
		Else
			rdoNo.Checked = True
		End If


	End Sub

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
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.ShowDialog()

			
			'MsgBox("Falta completar campos")
		Else

			Dim nave As New Entidades.Naves
			nave.PNombre = txtNombreNave.Text
			nave.PActivo = rdoSi.Checked
			nave.PNaveId = navesid

			Dim objNaveBU As New NavesBU
			objNaveBU.editarNaves(nave)

			'MsgBox("Transaccion exitosa")
			Dim mensajeExito As New ExitoForm
			mensajeExito.mensaje = "Transaccion exitosa"
			mensajeExito.ShowDialog()
			'Me.Close()

			txtNombreNave.Text = ""
			rdoSi.Checked = True


		End If
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
    End Sub

    Private Sub txtNombreNave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreNave.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreNave.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreNave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreNave.TextChanged

    End Sub
End Class
	