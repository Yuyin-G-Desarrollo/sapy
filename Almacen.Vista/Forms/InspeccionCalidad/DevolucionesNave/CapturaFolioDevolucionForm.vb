Imports Tools

Public Class CapturaFolioDevolucionForm
    Private objbu As New Almacen.Negocios.InspeccionCalidadBU
    Public FolioDevolucion As String = String.Empty
    Private Sub CapturaFolioDevolucionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtFolio.Select()
    End Sub

    Private Sub ValidarFolio(ByVal Folio As String)
        Try
            Cursor = Cursors.WaitCursor

            If txtFolio.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado un Folio.")
            ElseIf IsNumeric(txtFolio.Text) = False Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Folio debe de tener solo números.")
            Else
                If objbu.ValidaFolioDevolucion(Folio) = True Then
                    'Dim ventana As New ReingresoDevolucionForm
                    'ventana.FolioDevolucion = Folio
                    'ventana.MdiParent = Me.MdiParent
                    Me.DialogResult = DialogResult.OK
                    'ventana.Show()
                    FolioDevolucion = Folio
                    Me.Close()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El folio introducido no se existe o se encuentra cerrado.")
                End If

            End If
            txtFolio.Text = String.Empty
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ValidarFolio(txtFolio.Text)
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ValidarFolio(txtFolio.Text)
        End If
    End Sub

    Private Sub CapturaFolioDevolucionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> DialogResult.OK Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

End Class