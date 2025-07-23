Imports Tools

Public Class SeleccionarHojaExcel


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        If Not cmbHojaExcel.Text = "" Then
            Me.Close()
        Else
            vAdvertenciaForm.Text = "Inventario Ideal"
            vAdvertenciaForm.mensaje = "Seleccione Un archivo valido"
            vAdvertenciaForm.Show()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class