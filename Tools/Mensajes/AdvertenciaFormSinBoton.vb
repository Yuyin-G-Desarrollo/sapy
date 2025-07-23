Public Class AdvertenciaFormSinBoton
    Public mensaje As String
    Public Tamaño_Letra As Double

    Private Sub AdvertenciaFormSinBoton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje

        If Tamaño_Letra > 0 Then
            lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", Tamaño_Letra)
        End If
    End Sub

End Class