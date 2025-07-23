Imports System.Windows.Forms

Public Class MotivoRechazoForm
    Public motivo As String = String.Empty

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub

    Private Sub txtMotivo_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If CInt(AscW(e.KeyChar())) = CInt(Keys.Enter) Then
            e.Handled = True
            Aceptar()
        End If
    End Sub

    Private Sub Aceptar()
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If txtMotivo.Text.Trim <> "" Then
            motivo = txtMotivo.Text.Trim
            Me.Close()
        Else
            objMensajeAdv.mensaje = "Debe ingresar motivo"
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub MotivoRechazoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtMotivo.Focus()
    End Sub
End Class