Imports System.Net

Public Class FotoModelo

    Private Sub FotoModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FotoModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class