Imports Tools

Public Class CapturaObservacionesOTForm

    Public OrdenTrabajoID As String = String.Empty
    Dim objBU As New Ventas.Negocios.OrdenTrabajoBU

    Private Sub CapturaObservacionesOTForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Cadena_split As String()
        Dim DTObservaciones As DataTable
        Try
            Cursor = Cursors.WaitCursor
            Cadena_split = Split(OrdenTrabajoID, ",")

            If Cadena_split.Length = 1 Then
                DTObservaciones = objBU.ObtenerObservacionesOT(CInt(OrdenTrabajoID))
                If DTObservaciones.Rows.Count > 0 Then
                    txtObservaciones.Text = DTObservaciones.Rows(0).Item(0).ToString().Trim()
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar las observaciones.")
        End Try

        
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Cursor = Cursors.WaitCursor
            If txtObservaciones.Text.Trim() = String.Empty Then
                show_message("Advertencia", "El campo de observaciones no puede estar vacío.")
            Else
                objBU.CapturaObservacionesOT(OrdenTrabajoID, txtObservaciones.Text.Trim())
                show_message("Exito", "Las observaciones se han guardado.")
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al  guardar.")
        End Try
        
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class