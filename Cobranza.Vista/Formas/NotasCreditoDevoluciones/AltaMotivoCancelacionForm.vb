Imports Cobranza.Negocios
Imports Tools

Public Class AltaMotivoCancelacionForm
    Public motivoDescripcion As String
    Public activo As Boolean
    Public motivoId As Integer
    Private Sub AltaMotivoCancelacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If motivoDescripcion <> "" And activo = True Or activo = False Then
            txtMotivo.Text = motivoDescripcion
            If activo = True Then
                rpActivoSi.Checked = True
            Else
                rpActivoNo.Checked = True
            End If
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        registraMotivoCancelacion()
    End Sub
    Private Sub registraMotivoCancelacion()
        Dim objRegistrar As New NotaCreditoDevolucionesBU
        Dim descripcionMotivo As String = String.Empty
        Dim activo As Boolean
        Dim Confirmar As New ConfirmarForm

        If txtMotivo.Text = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario escribir el motivo de cancelación.")
        Else
            If rpActivoSi.Checked = False And rpActivoNo.Checked = False Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario seleccionar el tipo de activo.")
            Else
                descripcionMotivo = txtMotivo.Text
                If rpActivoSi.Checked = True Then
                    activo = True
                End If
                If rpActivoNo.Checked = True Then
                    activo = False
                End If
                Confirmar.mensaje = "¿Desea editar el motivo de cancelación?"
                If Confirmar.ShowDialog() = DialogResult.OK Then
                    objRegistrar.insertaNuevoMotivoCancelacion(descripcionMotivo, activo, motivoId)
                    If motivoId = 0 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Registro Insertado Correctamente.")
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Registro Editado Correctamente.")
                    End If
                    motivoId = 0
                End If
            End If
        End If
    End Sub

    Private Sub btnCerrarMotivos_Click(sender As Object, e As EventArgs) Handles btnCerrarMotivos.Click
        Me.Close()
    End Sub
End Class