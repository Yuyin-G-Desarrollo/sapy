Public Class ErroresForm
	Public mensaje As String
	Private Sub ErroresForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		lblMensaje.Text = mensaje
	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		Me.Close()
	End Sub
End Class