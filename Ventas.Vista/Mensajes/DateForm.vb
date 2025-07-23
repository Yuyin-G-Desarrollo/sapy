Public Class DateForm
    Public mensaje As String
    Public Dia As DateTime
    Private Sub DateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dia = dtpFecha.Value
        Me.Close()
    End Sub
End Class