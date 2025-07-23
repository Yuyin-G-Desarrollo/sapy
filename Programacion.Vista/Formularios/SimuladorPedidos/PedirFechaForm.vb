Imports Programacion.Negocios
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
        If dtpNuevaFecha.Value.DayOfYear < Now.DayOfYear Then
            vAdvertenciaForm.Text = "Espacio Reservado"
            vAdvertenciaForm.mensaje = "No puede seleccionar una fecha inferior a la fecha actual "
            vAdvertenciaForm.ShowDialog()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            pFecha = dtpNuevaFecha.Value
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class