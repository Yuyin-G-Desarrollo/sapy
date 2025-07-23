Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports System.Globalization
Imports Infragistics.Documents.Excel

Public Class LotesenProcesoform
    Dim idColec As Int32
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub LotesenProcesoform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        accionesInicio()
    End Sub

    Public Sub accionesInicio()
        LlenarGridlotes(idColec)
    End Sub

    Private Sub LlenarGridlotes(ByVal IdColec As Int32)
        Dim objColeBU As New Programacion.Negocios.ColeccionBU
        Dim dtLotesenProceso As New DataTable

        dtLotesenProceso = objColeBU.VerLotesenProceso(IdColec)
        grdAlertaLotesenProceso.DataSource = dtLotesenProceso
        lblRegistros.Text = dtLotesenProceso.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
        lblFechaUltimaActualizacion.Text = Date.Now.ToString

    End Sub

    Friend Sub RecibirIdColeccion(idColeccion As Integer)
        idColec = idColeccion
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwAlertaLotesenProceso.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try

                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Worksheet = workbook.Worksheets.Add("Datos")

                    worksheet.Columns.Item(0).Width = 3650
                    ' worksheet.Columns.Item(1).Width = 1825
                    ' worksheet.Columns.Item(2).Width = 2920
                    ' worksheet.Columns.Item(3).Width = 2920

                    Dim inicio As Integer = 0

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = vwAlertaLotesenProceso.Columns(0).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = vwAlertaLotesenProceso.Columns(1).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = vwAlertaLotesenProceso.Columns(2).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = vwAlertaLotesenProceso.Columns(3).FieldName.ToString()


                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To 3 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    For r As Integer = (0) To vwAlertaLotesenProceso.RowCount - 1 'grdCatalogo.Rows.Count - 1

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = vwAlertaLotesenProceso.GetRowCellValue(r, vwAlertaLotesenProceso.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = vwAlertaLotesenProceso.GetRowCellValue(r, vwAlertaLotesenProceso.Columns(1).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = vwAlertaLotesenProceso.GetRowCellValue(r, vwAlertaLotesenProceso.Columns(2).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = vwAlertaLotesenProceso.GetRowCellValue(r, vwAlertaLotesenProceso.Columns(3).FieldName.ToString())

                    Next

                    For i As Int16 = 0 To vwAlertaLotesenProceso.RowCount - 1 Step 1
                        For j As Int16 = 0 To 3 Step 1

                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente en la ubicación " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)
                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm With {
                        .StartPosition = FormStartPosition.CenterScreen,
                        .mensaje = ex.Message
                    }
                    objMensajeError.ShowDialog()
                End Try

            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If
    End Sub
End Class