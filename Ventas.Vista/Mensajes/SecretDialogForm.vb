Public Class SecretDialogForm
    Public mensaje As String = ""
    Private Sub SecretDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
    End Sub
End Class