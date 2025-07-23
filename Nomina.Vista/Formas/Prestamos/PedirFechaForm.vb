Imports Tools


Public Class PedirFechaForm
    Dim fecha As Date
    Public Property pFecha As Date
        Set(value As Date)
            fecha = value
        End Set
        Get
            Return fecha
        End Get
    End Property


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vConfirmarForm As New ConfirmarForm

        vConfirmarForm.Text = "Prestamos"
        vConfirmarForm.mensaje = "Se cambiará el estado del préstamo a ENTREGADO. El préstamo se comenzará a descontar a partir de la siguiente nómina. ¿Desea continuar?"
        Dim vDialogResult As New DialogResult
        vDialogResult = vConfirmarForm.ShowDialog
        If vDialogResult = Windows.Forms.DialogResult.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            pFecha = dtpNuevaFecha.Value
            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class