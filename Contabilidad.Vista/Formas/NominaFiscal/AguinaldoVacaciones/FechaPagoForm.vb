Imports System.Windows.Forms

Public Class FechaPagoForm
    Public fecha As Date
    Public cerrado As Boolean = False
    Public aceptado As Boolean = False

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub

    Private Sub dtpFechaCalculo_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles dtpFechaPago.KeyPress
        If CInt(AscW(e.KeyChar())) = CInt(Keys.Enter) Then
            e.Handled = True
            Aceptar()
        End If
    End Sub

    Private Sub Aceptar()
        fecha = dtpFechaPago.Value
        aceptado = True
        Me.Close()
    End Sub

    Private Sub MotivoRechazoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpFechaPago.Focus()
    End Sub

    Private Sub FechaPagoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not aceptado Then
            cerrado = True
        End If
    End Sub
End Class