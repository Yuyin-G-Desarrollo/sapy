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
			mensajeAdvertencia.Show()

			
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
			mensajeExito.Show()
			'Me.Close()

			txtNombreNave.Text = ""
			rdoSi.Checked = True


		End If
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub
End Class
	