Public Class NotificacionConTextAreaForm
    Public mensaje As String = ""
    Public texto As String = ""
    Private Sub txtParam_TextChanged(sender As Object, e As EventArgs) Handles txtRazon.TextChanged

    End Sub

    Private Sub NotificacionConTextAreaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRazon.AutoSize = False
        txtRazon.Size = New Size(309, 40)
        lblMensaje.Text = mensaje
        Me.Text = ""
        txtRazon.CharacterCasing = Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Close()
        texto = txtRazon.Text
    End Sub
End Class