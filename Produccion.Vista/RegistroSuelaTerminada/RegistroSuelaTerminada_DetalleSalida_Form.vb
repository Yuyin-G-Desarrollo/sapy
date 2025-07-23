Imports Produccion.Negocios
Imports Tools
Imports Tools.modMensajes

Public Class RegistroSuelaTerminada_DetalleSalida_Form
    Public FoliosID As String
    Private ReadOnly objSalidaLoteSuelaBU As New RegistroSuelaTerminadaBU
    Private UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarInformacion()
    End Sub

    Private Sub ExportarInformacion()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Try
            Tools.MostrarEspere(Me)
            If grvFoliosSalida.DataRowCount > 0 Then
                nombreReporte = Me.Text
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        grvFoliosSalida.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Tools.TerminarEspere(Me)
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub SalidaLoteSuela_DetalleSalida_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ConsultarInformacion()
    End Sub

    Private Sub ConsultarInformacion()
        Try
            Tools.MostrarEspere(Me)
            Dim dtFoliosSalidaSuela = objSalidaLoteSuelaBU.ConsultarDetalles(Folios:=FoliosID)
            Tools.TerminarEspere(Me)
            grdFolioSalida.DataSource = Nothing
            If dtFoliosSalidaSuela.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontró información con los filtros seleccionados.")
                Return
            End If
            grdFolioSalida.DataSource = dtFoliosSalidaSuela
            lblRegistros.Text = Val(dtFoliosSalidaSuela.Rows.Count).ToString("N0")
            lblUltimaDistribucion.Text = Date.Now
            DiseñoGrid.AlternarColorEnFilas(grvFoliosSalida)
            grvFoliosSalida.BestFitColumns()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub grvFoliosSalida_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvFoliosSalida.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class