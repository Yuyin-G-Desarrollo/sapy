Imports DevExpress.Data.XtraReports.Wizard

Public Class MensajeError
    Public dtInformacion As New DataTable
    Public Titulo As String = ""

    Private Sub ErroresTimbradoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            lblTitulo.Text = Titulo
            grdErroresTimbrado.DataSource = dtInformacion
            lblRegistroR.Text = dtInformacion.Rows.Count
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub VwMotivosError_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) 
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class