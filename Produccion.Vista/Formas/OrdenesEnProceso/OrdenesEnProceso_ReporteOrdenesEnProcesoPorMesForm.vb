Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools
Imports Tools.modMensajes

Public Class OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm
    Public dtReporte As DataTable
    Private Sub ReporteOrdenesEnProcesoPorMesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdOrdenesEnProceso.DataSource = dtReporte
        EstablecerDiseñoReporte()
    End Sub

    Private Sub EstablecerDiseñoReporte()
        grvOrdenesEnProceso.OptionsView.AllowCellMerge = True
        'Establecemos el diseño predeterminado para las columnas de los mesos y total
        For index = 2 To grvOrdenesEnProceso.Columns.Count - 1
            grvOrdenesEnProceso.Columns(index).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grvOrdenesEnProceso.Columns(index).DisplayFormat.FormatString = "N0"
            grvOrdenesEnProceso.Columns(index).OptionsColumn.AllowEdit = False
            grvOrdenesEnProceso.Columns(index).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
            grvOrdenesEnProceso.Columns(index).Summary.Add(DevExpress.Data.SummaryItemType.Sum, grvOrdenesEnProceso.Columns(index).FieldName, "{0:N0}")
        Next
        grvOrdenesEnProceso.Columns("Coleccion").Caption = "COLECCIÓN"
        grvOrdenesEnProceso.Columns("Coleccion").AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
        grvOrdenesEnProceso.Columns("Coleccion").OptionsColumn.AllowEdit = False
        grvOrdenesEnProceso.Columns("NaveDesarrollo").Caption = "NAVE DESARROLLO"
        grvOrdenesEnProceso.Columns("NaveDesarrollo").AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
        grvOrdenesEnProceso.Columns("NaveDesarrollo").OptionsColumn.AllowEdit = False
        lblRegistros.Text = Val(dtReporte.Rows.Count).ToString("N0")
        lblUltimaDistribucion.Text = Date.Now
        DiseñoGrid.AlternarColorEnFilas(grvOrdenesEnProceso)
        grvOrdenesEnProceso.BestFitColumns()
    End Sub

    Private Sub grvOrdenesEnProceso_CellMerge(ByVal sender As Object, ByVal e As CellMergeEventArgs) Handles grvOrdenesEnProceso.CellMerge
        Dim view1 As GridView = sender
        e.Handled = True
        If e.Column.FieldName = ("NaveDesarrollo") Then
            Dim view = sender
            Dim previousCol As Object
            previousCol = view.Columns(view.Columns.IndexOf(e.Column)).FieldName
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If grvOrdenesEnProceso.DataRowCount > 0 Then
                nombreReporte = Me.Text
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grvOrdenesEnProceso.GroupCount > 0 Then
                            grvOrdenesEnProceso.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            grvOrdenesEnProceso.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub
End Class