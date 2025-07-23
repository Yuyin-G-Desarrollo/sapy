Imports Tools

Public Class MotivoRechazoForm
    Public cancelado As Boolean = False
    Dim guardar As Boolean = False
    Dim adv As New AdvertenciaForm
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        cancelado = True
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtMotivo.Text.Length > 0 Then
            guardar = True
            Me.Close()
        Else
            adv.mensaje = "Ingrese un motivo."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub MotivoRechazoForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardar = True Then
            cancelado = False
        Else
            cancelado = True
        End If
    End Sub
End Class