Public Class ListaPatronesForm

	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
		AltasPatronesForm.Show()
	End Sub

	Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
		EditarPatronesForm.Show()
	End Sub

    Private Sub ListaPatronesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class