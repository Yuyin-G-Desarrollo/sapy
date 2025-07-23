Public Class ExitoFormGrande
    Public mensaje As String
    Private Sub ExitoFormGrande_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class