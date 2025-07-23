Imports Tools

Public Class AvisosPedirHoraForm

    ''' <summary>
    ''' Regresa la hora establecida por el usuario en el formulario
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Hora As String
        Get
            Return ObtenerHora()
        End Get
    End Property


    ''' <summary>
    ''' Construye la hora
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ObtenerHora() As String
        ObtenerHora = IIf(Len(nudHora.Value.ToString) = 1, "0" & nudHora.Value.ToString, nudHora.Value.ToString) & ":"
        ObtenerHora += IIf(Len(nudMinuto.Value.ToString) = 1, "0" & nudMinuto.Value.ToString, nudMinuto.Value.ToString)
    End Function

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim vConfirmarForm As New ConfirmarForm
        vConfirmarForm.Text = "Altas Avisos"
        vConfirmarForm.mensaje = "¿ Está seguro de generar un nuevo aviso a la hora seleccionada ?"
        Dim vDialogResult As New DialogResult
        vDialogResult = vConfirmarForm.ShowDialog
        If vDialogResult = Windows.Forms.DialogResult.OK Then

            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class