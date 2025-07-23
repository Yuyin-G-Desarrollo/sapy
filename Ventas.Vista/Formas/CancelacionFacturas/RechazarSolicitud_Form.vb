Public Class RechazarSolicitud_Form
    Public idSolicitud As Integer

    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeError As New Tools.ErroresForm
    Dim objMensajeExito As New Tools.ExitoForm
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Dim dtResultado As New DataTable
        Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU

        dtResultado = objBU.RechazarSolicitudCancelacion(idSolicitud, txtObservaciones.Text)

        If dtResultado.Rows(0).Item("respuesta").ToString = "Error" Then
            objMensajeError.Text = "Error"
            objMensajeError.mensaje = "Ocurrio un error al guardar, intente de nuevo."
            objMensajeError.ShowDialog()
        Else
            objMensajeExito.Text = "Exito"
            objMensajeExito.mensaje = dtResultado.Rows(0).Item("respuesta").ToString()
            objMensajeExito.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()

    End Sub


    Private Sub RechazarSolicitud_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        txtObservaciones.Text = txtObservaciones.Text.ToUpper
        txtObservaciones.SelectionStart = txtObservaciones.Text.Length
    End Sub

    Private Sub RechazarSolicitud_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F5 Then
            Guardar()
        End If
        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub
End Class