Imports Tools

Public Class MotivoRechazoForm
    Dim adv As New AdvertenciaForm
    Dim mensaje As New ExitoForm
    Dim confirm As New ConfirmarForm
    Public cancelado As Boolean = False
    Public motivoRechazo As String = ""
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        confirm.mensaje = "¿Quiere cancelar la operación?"
        If confirm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            cancelado = True
            Me.Close()
        Else
            cancelado = False
        End If

    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtRechazo.Text.Length > 0 Then
            motivoRechazo = txtRechazo.Text
            cancelado = False
            Me.Close()
        Else
            adv.mensaje = "Ingrese un motivo."
            adv.ShowDialog()
        End If
    End Sub
End Class