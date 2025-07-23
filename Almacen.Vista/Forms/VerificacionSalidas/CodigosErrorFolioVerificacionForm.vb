Imports Tools
Public Class CodigosErrorFolioVerificacionForm

    Public FolioVerificacionID As Integer = 0
    Dim objBU As New Negocios.VerificacionSalidasBU
    Private Sub CodigosErrorFolioVerificacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtResultado As New DataTable

        Try
            dtResultado = objBU.ConsultaCodigoError(FolioVerificacionID)
            grdParesErroneos.DataSource = dtResultado

            DiseñoGrid.DiseñoBaseGrid(viewParesErroneos)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

End Class