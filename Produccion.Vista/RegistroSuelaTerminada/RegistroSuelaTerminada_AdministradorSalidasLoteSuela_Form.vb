Imports Entidades
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools
Imports Tools.modMensajes

Public Class RegistroSuelaTerminada_AdministradorSalidasLoteSuela_Form
    Private ReadOnly objSalidaLoteSuelaBU As New RegistroSuelaTerminadaBU
    Private UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarInformacion()
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        VisualizarDetallesSalida()
    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirFolioSalida()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        InicializarPantalla()
    End Sub
    Private Sub SalidaLoteSuela_AdministradorSalidasLoteSuela_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        InicializarPantalla()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        ConsultarInformacion()
    End Sub

    Private Sub ImprimirFolioSalida()
        Try
            If grvFoliosSalida.RowCount = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos un folio.")
                Return
            End If
            Dim dtSalidaLoteSuela As DataTable = grdFolioSalida.DataSource
            If dtSalidaLoteSuela.AsEnumerable().Where(Function(row) row.Field(Of Boolean)("Seleccionar")).Count <> 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar un folio.")
                Return
            End If
            Dim folioSeleccionado As Integer = dtSalidaLoteSuela.AsEnumerable().Where(Function(row) row.Field(Of Boolean)("Seleccionar")).FirstOrDefault()("Folio")
            Dim estatus As String = dtSalidaLoteSuela.AsEnumerable().Where(Function(row) row.Field(Of Boolean)("Seleccionar")).FirstOrDefault()("Estatus")

            If estatus <> "FINALIZADA" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar un folio en estatus de finalizado.")
                Return
            End If


            Dim OBJBUReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes = OBJBUReporte.LeerReporteporClave("REPORTE_SUELA_TERMINADA")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                            EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport()
            Dim MasterLotesRegistro As New DataSet("dtLotes")
            Dim dtLotesSalida As New DataTable("dtLotes")
            dtLotesSalida = objSalidaLoteSuelaBU.ConsultarDetalles(folioSeleccionado)
            dtLotesSalida.TableName = "dtLotes"
            MasterLotesRegistro.Tables.Add(dtLotesSalida)
            reporte.Load(archivo)
            reporte.Compile()
            reporte.Dictionary.Clear()
            reporte("NombreReporte") = $"SAPY: {EntidadReporte.Pnombre}.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.RegData(MasterLotesRegistro)
            reporte.Dictionary.Synchronize()
            reporte.Show(True)
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub VisualizarDetallesSalida()
        Try
            If grvFoliosSalida.RowCount = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos un folio.")
                Return
            End If
            Dim dtSalidaLoteSuela As DataTable = grdFolioSalida.DataSource

            Dim foliosConcatenados As String = String.Join(",",
                                               dtSalidaLoteSuela.AsEnumerable() _
                                                 .Where(Function(row) row.Field(Of Boolean)("Seleccionar")) _
                                                 .Select(Function(row) row.Field(Of Integer)("Folio")))

            If foliosConcatenados = "" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos un folio.")
                Return
            End If

            AbrirPantallaDetallesFolio(foliosConcatenados)
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub AbrirPantallaDetallesFolio(foliosConcatenados As String)
        Try
            Dim form As New RegistroSuelaTerminada_DetalleSalida_Form
            form.FoliosID = foliosConcatenados
            form.StartPosition = FormStartPosition.CenterScreen
            form.ShowDialog()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
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

    Private Sub InicializarPantalla()
        Try
            ConsultarInformacion()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub


    Private Sub ConsultarInformacion()
        Try
            Tools.MostrarEspere(Me)
            Dim dtFoliosSalidaSuela = objSalidaLoteSuelaBU.Consultar(FechaInicio:=dtpFechaInicio.Value.ToShortDateString, FechaTermino:=dtpFechaFin.Value.ToShortDateString)
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

    Private Sub SalidaLoteSuela_AdministradorSalidasLoteSuela_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InicializarFiltros()
    End Sub

    Private Sub InicializarFiltros()
        Dim fechaIncicio As Date = CDate("01/" + Date.Now.Month.ToString + "/" + Date.Now.Year.ToString)
        Dim fechaFin As Date = Date.Now
        dtpFechaInicio.Value = fechaIncicio
        dtpFechaFin.Value = fechaFin
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub grvFoliosSalida_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvFoliosSalida.CustomDrawCell
        If e.RowHandle < 0 Then
            Return
        End If

        If e.Column.FieldName <> cEstatus.FieldName Then
            Return
        End If


        Select Case e.CellValue
            Case "EN PROCESO"
                e.Appearance.BackColor = pnlEnProceso.BackColor
                e.Appearance.ForeColor = pnlEnProceso.BackColor
            Case "FINALIZADA"
                e.Appearance.BackColor = pnlFinalizado.BackColor
                e.Appearance.ForeColor = pnlFinalizado.BackColor
            Case "DESCARTADA"
                e.Appearance.BackColor = pnlDescartado.BackColor
                e.Appearance.ForeColor = pnlDescartado.BackColor
        End Select
    End Sub

    Private Sub SalidaLoteSuela_AdministradorSalidasLoteSuela_Form_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            ConsultarInformacion()
            e.Handled = True
        End If
    End Sub

    Private Sub grvFoliosSalida_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvFoliosSalida.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub grvFoliosSalida_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles grvFoliosSalida.RowClick
        If e.RowHandle < 0 Then
            Return
        End If

        If e.Clicks <> 2 Then
            Return
        End If
        AbrirPantallaDetallesFolio(grvFoliosSalida.GetFocusedRowCellValue(cFolio))
    End Sub
End Class