Public Class AdvertenciaForm
	Public mensaje As String
	
	Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
		Me.Close()
	End Sub

	Private Sub AdvertenciaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		lblMensaje.Text = mensaje
	End Sub
End Class