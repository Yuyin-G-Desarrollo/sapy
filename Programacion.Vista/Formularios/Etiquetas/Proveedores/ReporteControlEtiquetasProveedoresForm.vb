Imports Infragistics.Documents.Excel
Imports Tools

Public Class ReporteControlEtiquetasProveedoresForm
    Public idproveedor As Integer
    Public fechaDel As Date
    Public fechaAl As Date
    Public nombreProveedor As String

    Private Sub ReporteControlEtiquetasProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objN As New Programacion.Negocios.EtiquetasBU
        Dim tbl As New DataTable

        lblFecha.Text = Date.Now.ToShortDateString()
        lblEnvia.Text = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        lblPrograma.Text = "Del " & fechaDel.ToShortDateString & " Al " & fechaAl.ToShortDateString
        lblProveedor.Text = nombreProveedor

        tbl = objN.ReporteControlEtiquetasProveedoresSuelas(fechaDel, fechaAl, idproveedor)
        If tbl.Rows.Count > 0 Then
            grdReporte.DataSource = tbl
            DisenioGrid()
        End If

    End Sub

    Private Sub DisenioGrid()
        grdVReporte.IndicatorWidth = 40
        grdVReporte.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            col.OptionsColumn.AllowEdit = False
            If col.FieldName = "NAVE" Then
                col.Width = 200
            End If
            If col.FieldName = "CANTIDAD" Then
                col.Width = 112
            End If
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVReporte)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVReporte)

    End Sub

    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString + 1
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'Tools.Excel.ExportarExcel(grdVReporte, "ReporteControlEtiquetasProveedoresForm")

        If grdVReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            If result = Windows.Forms.DialogResult.OK Then
                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    worksheet.Columns.Item(0).Width = 7000
                    worksheet.Columns.Item(1).Width = 9100

                    worksheet.Rows.Item(0).Cells.Item(0).Value = "CONTROL DE ETIQUETAS DE PROVEEDOR DE SUELAS"
                    worksheet.Rows.Item(0).Cells.Item(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

                    worksheet.Rows(0).Cells(2).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center

                    worksheet.Rows.Item(1).Cells.Item(0).Value = "F. ENVIO"
                    worksheet.Rows.Item(2).Cells.Item(0).Value = "QUIEN ENVIA"
                    worksheet.Rows.Item(3).Cells.Item(0).Value = "PROGRAMA"
                    worksheet.Rows.Item(4).Cells.Item(0).Value = "PROVEEDOR"
                    worksheet.Rows.Item(5).Cells.Item(0).Value = "NAVE"
                    worksheet.Rows.Item(5).Cells.Item(1).Value = "CANTIDAD"
                    worksheet.Rows.Item(1).Cells.Item(1).Value = Date.Now.ToShortDateString()
                    worksheet.Rows.Item(2).Cells.Item(1).Value = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
                    worksheet.Rows.Item(3).Cells.Item(1).Value = "Del " & fechaDel.ToShortDateString & " Al " & fechaAl.ToShortDateString
                    worksheet.Rows.Item(4).Cells.Item(1).Value = nombreProveedor

                    worksheet.Rows(0).Cells(2).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center


                    For i As Int16 = 2 To 4 Step 1
                        For j As Int16 = 0 To 0 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    'Pintar de azul encabezados Fecha, Quién, Programa y Proveedor
                    For i As Int16 = 1 To 4 Step 1
                        For j As Int16 = 0 To 0 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.FromArgb(0, 32, 96)), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next
                    'Pintar de azul encabezados de Nave y Cantidad
                    For i As Int16 = 5 To 5 Step 1
                        For j As Int16 = 0 To 1 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.FromArgb(0, 32, 96)), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Next
                    Next

                    worksheet.Rows.Item(5).Cells.Item(3).CellFormat.Font.Italic = ExcelDefaultableBoolean.True
                    Dim inicio As Integer = 5

                    For r As Integer = 0 To grdVReporte.RowCount - 1
                        'worksheet.Rows.Item(r + inicio + 1).Height = 7000 '1145
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(0).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(1).FieldName.ToString())
                    Next

                    For i As Int16 = 0 To grdVReporte.RowCount - 1 Step 1
                        For j As Int16 = 0 To 1 Step 1 '13
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next



                    worksheet.Rows.Item(20).Cells.Item(0).Value = "Firma de Operador"
                    worksheet.Rows.Item(22).Cells.Item(0).Value = "Firma de Recibido"
                    For i As Int16 = 20 To 20 Step 1
                        For j As Int16 = 1 To 1 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next
                    For i As Int16 = 22 To 22 Step 1
                        For j As Int16 = 1 To 1 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    worksheet.Rows.Item(20).Cells.Item(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                    worksheet.Rows.Item(20).Cells.Item(0).CellFormat.Alignment = VerticalCellAlignment.Center
                    worksheet.Rows.Item(22).Cells.Item(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                    worksheet.Rows.Item(22).Cells.Item(0).CellFormat.Alignment = VerticalCellAlignment.Center
                    worksheet.Rows.Item(20).Cells.Item(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    worksheet.Rows.Item(22).Cells.Item(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True


                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.Show()
                    Process.Start(fileName)

                Catch ex As Exception

                End Try
            End If

        End If

    End Sub
End Class