Public Class AltasPatronesForm

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombreDelPatron.Text <> "" Then

			lblNombreDelPuesto.ForeColor = Color.Black
		Else


			lblNombreDelPuesto.ForeColor = Color.Red
			falla = True

		End If

		If cmbNave.Text <> "" Then

			lblNave.ForeColor = Color.Black
		Else


			lblNave.ForeColor = Color.Red
			falla = True

		End If


		If falla Then
			MsgBox("Falta completar campos")
		Else

			MsgBox("Transaccion exitosa")
			Me.Close()
		End If
	End Sub


	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

    Private Sub AltasPatronesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class