Imports Tools
Public Class CapturaFechaEstimadaRegresoForm

    Public FolioDevolucion As Integer = 0
    Public FechaEstimadaRegtreso As Date
    Public Tratamiento As String = String.Empty
    Private ObjBU As New Negocios.InspeccionCalidadBU

    Private Sub CapturaFechaEstimadaRegresoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            dtmFechaEstimdaRegreso.Value = FechaEstimadaRegtreso
            txtTratamiento.Text = Tratamiento
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtTratamiento.Text <> String.Empty Then
                ObjBU.EditarFolioDevolucion(FolioDevolucion, dtmFechaEstimdaRegreso.Value, txtTratamiento.Text)
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha actualizado la información.")
                Me.Close()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado un tratamiento.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

End Class