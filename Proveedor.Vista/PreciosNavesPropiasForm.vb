Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports Tools.modMensajes
Imports DevExpress.XtraGrid

Public Class PreciosNavesPropiasForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Private Sub PreciosNavesPropiasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        grdReporte.DataSource = Nothing
        lblNumRegistros.Text = "0"

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Proveedores.BU.ConsultaComprasPT_BU
            Dim tabla As DataTable = obj.PreciosNavesPropias()
            If tabla.Rows.Count > 0 Then
                grdReporte.DataSource = tabla
                DisenioGrid()
                lblFechaUltimaActualización.Text = Date.Now.ToString
                lblNumRegistros.Text = tabla.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                pnlParametros.Height = 27
            Else
                msgAdvertencia.mensaje = "No se encontró información."
                msgAdvertencia.ShowDialog()

            End If

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.IndicatorWidth = 50

        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True
        vwReporte.OptionsView.ShowIndicator = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsView.ShowAutoFilterRow = True

        vwReporte.OptionsSelection.EnableAppearanceFocusedCell = False
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True

        vwReporte.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N2"

        With vwReporte.Appearance
            .SelectedRow.Options.UseBackColor = True
            .SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
            .EvenRow.BackColor = Color.White
            .OddRow.BackColor = SystemColors.ActiveCaption
            .FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
            .FocusedRow.ForeColor = Color.White
            .HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        End With

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "PreciosNavesPropias"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

End Class