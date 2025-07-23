Public Class TextDialogForm
    Public mensaje As String = ""
    Private Sub TextDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
        Me.Text = ""

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub
End Class