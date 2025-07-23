Public Class ListaProveedoresForm

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim form As New AltaProveedoresForm()
        form.Show()
    End Sub
End Class