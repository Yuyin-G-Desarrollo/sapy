Imports Tools
Public Class LimpiarParesBahiaForm
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim objbu As New Negocios.BahiaBU
            objbu.LimpiarParesBahia(txtBahia.Text.Trim())
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han Limpiado los pares")
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub

End Class