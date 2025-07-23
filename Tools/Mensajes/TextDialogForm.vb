Public Class TextDialogForm
    Public mensaje As String = ""
    Private Sub TextDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
        Me.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub

    Private Sub txtParam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParam.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.PerformClick()
        End If

    End Sub
End Class