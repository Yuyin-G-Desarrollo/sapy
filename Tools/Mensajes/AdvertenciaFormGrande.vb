Public Class AdvertenciaFormGrande
    Public mensaje As String
    Public Tamaño_Letra As Double

    Private Sub AdvertenciaFormGrande_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje

        If Tamaño_Letra > 0 Then
            lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", Tamaño_Letra)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class