Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports Proveedores.BU
Imports Tools
Imports Programacion.Vista
Imports DevExpress.XtraPrinting
Imports Infragistics.Documents.Excel
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class ReporteInventarioEComerceForm
    Dim ruta As String = String.Empty
    Dim image As Image
    Dim StreamFoto As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"
    Dim tblReporte As New DataTable

    Private Sub ReporteInventarioEComerceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen
        tblReporte.Clear()
        grdVReporte.Columns.Clear()
        grdReporte.DataSource = Nothing
        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        'pnPBar.Top = (Me.Height - 200) / 2
        cmboxTipoReporte.SelectedIndex = 0
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New MercadotecniaBU
        tblReporte.Clear()
        grdReporte.DataSource = Nothing
        grdReporte.RefreshDataSource()
        grdVReporte.Columns.Clear()

        Try
            pnPBar.Visible = True
            lblInfo.Text = "Ejecutando consulta...."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            System.Windows.Forms.Application.DoEvents()


            If cmboxTipoReporte.SelectedIndex = 0 Then
                tblReporte = obj.ConsultaInventario_ECOMMERCE_EnInventario()
            ElseIf cmboxTipoReporte.SelectedIndex = 1 Then
                tblReporte = obj.ConsultaInventario_ECOMMERCE_EnProceso
            ElseIf cmboxTipoReporte.SelectedIndex = 2 Then
                tblReporte = obj.ConsultaInventario_ECOMMERCE_PorProgramar
            End If






            If tblReporte.Rows.Count > 0 Then
                tblReporte.Columns.Add("Foto", GetType(Image))

                Dim Total As Integer = tblReporte.Rows.Count
                Dim Cont As Integer = 0

                pBar.Maximum = Total
                lblInfo.Text = "Descargando imágenes...."
                System.Windows.Forms.Application.DoEvents()

                Dim imagen As Image
                For Each row As DataRow In tblReporte.Rows
                    ruta = IIf(IsDBNull(row.Item("FotoModelo")), "", row.Item("FotoModelo").ToString.Trim)
                    If ruta.Length > 0 Then
                        Try
                            image = Nothing
                            StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                            imagen = Bitmap.FromStream(StreamFoto)

                            If imagen.Width > 2000 Then
                                image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.2, imagen.Height * 0.2))
                                row.Item("Foto") = image
                            Else
                                image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.4, imagen.Height * 0.4))
                                row.Item("Foto") = image
                            End If


                        Catch ex As Exception
                            Try

                                image = Nothing
                                StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                                imagen = Bitmap.FromStream(StreamFoto)

                                If imagen.Width > 2000 Then
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.3, imagen.Height * 0.3))
                                    row.Item("Foto") = image
                                Else
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.5, imagen.Height * 0.5))
                                    row.Item("Foto") = image
                                End If

                            Catch exe As Exception

                            End Try
                        End Try
                    Else
                        row.Item("Foto") = Nothing
                    End If
                    Cont += 1
                    pBar.Value = Cont
                Next
                System.Windows.Forms.Application.DoEvents()
                grdReporte.DataSource = tblReporte
                DisenioGrid()
                lblTotalRegistros.Text = tblReporte.Rows.Count

            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros en la consulta.")
                lblTotalRegistros.Text = "0"
            End If

            'System.Windows.Forms.Application.DoEvents()
            'grdReporte.DataSource = tblReporte
            'DisenioGrid()

            lblFechaUltimaActualizacion.Text = Date.Now
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pBar.Value = pBar.Minimum
            pnPBar.Visible = False
            request = Nothing
            StreamFoto = Nothing
            image = Nothing
        End Try


    End Sub

    Private Sub DisenioGrid()
        Dim Contador As Int16 = 0
        Dim Foto As Int16 = tblReporte.Columns.IndexOf("Foto")
        Dim value As Object = 1
        grdVReporte.Columns.Clear()

        grdVReporte.IndicatorWidth = 40

        For Each Columna As DataColumn In tblReporte.Columns
            If Contador = 0 Then
                grdVReporte.Columns.AddField((Columna.ColumnName).ToString())
                grdVReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                grdVReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In tblReporte.Columns
            If Contador = Foto Then
                grdVReporte.Columns.AddField((Columna.ColumnName).ToString())
                grdVReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                grdVReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In tblReporte.Columns
            If (TypeOf value Is Integer) Then
                Select Case value
                    Case 1
                        'If Contador = 1 Then
                        '    grdVReporte.Columns.AddField((Columna.ColumnName).ToString())
                        '    grdVReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = False 'False
                        '    grdVReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        'ElseIf Contador > 1 And Contador <> Foto Then
                        '    grdVReporte.Columns.AddField((Columna.ColumnName).ToString())
                        '    grdVReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = False
                        '    grdVReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        'End If
                        If Contador > 0 And Contador <> Foto Then
                            grdVReporte.Columns.AddField((Columna.ColumnName).ToString())
                            grdVReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                            grdVReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        End If

                        Contador += 1
                End Select
            End If
        Next


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            If col.FieldName = "Foto" Then
            End If
            If col.FieldName = "Marca" Then
                Width = 100
            End If
            If col.FieldName = "Colección" Then
                col.Width = 200
            End If
            If col.FieldName = "Modelo" Then
                col.Width = 100
            End If
            If col.FieldName = "Piel" Then
                col.Width = 150
            End If
            If col.FieldName = "Color" Then
                col.Width = 120
            End If
            If col.FieldName = "Corrida" Then
                col.Width = 100
            End If
            If col.FieldName = "Total Pares" Then
                col.Width = 80
            End If
            If col.FieldName = "FotoModelo" Or col.FieldName = "PedidoSAY" Or col.FieldName = "PedidoSICY" Or col.FieldName = "Partida" Or col.FieldName = "Estatus" Then
                col.Visible = False
            End If
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        Next


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            col.OptionsColumn.AllowEdit = False
            If col.FieldName <> "Foto" And
               col.FieldName <> "Marca" And
               col.FieldName <> "Colección" And
               col.FieldName <> "Modelo" And
               col.FieldName <> "Piel" And
               col.FieldName <> "Color" And
               col.FieldName <> "Corrida" And
               col.FieldName <> "Total Pares" Then



                col.Width = 40

                If IsNothing(grdVReporte.Columns(col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = col.FieldName)) = True Then
                    grdVReporte.Columns(col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                End If

            End If

            If col.FieldName = "Total Pares" Then
                If IsNothing(grdVReporte.Columns(col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = col.FieldName)) = True Then
                    grdVReporte.Columns(col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                End If
            End If

        Next


        grdVReporte.Columns("Foto").Visible = True
        grdVReporte.ColumnPanelRowHeight = 30
        grdVReporte.RowHeight = 50


        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVReporte)
            Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVReporte)


        grdVReporte.OptionsView.ColumnAutoWidth = False

    End Sub

    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub grdVReporte_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles grdVReporte.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = grdVReporte.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = grdVReporte.GetRowCellValue(e.RowHandle, "MarcaSAY")
                MostrarFoto.Coleccion = grdVReporte.GetRowCellValue(e.RowHandle, "ColeccionSAY")
                MostrarFoto.ModeloSicy = grdVReporte.GetRowCellValue(e.RowHandle, "ModeloSAY")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click


        'Tools.Excel.ExportarExcel(grdVReporte, "Reporte de Inventario E-Commerce")

        If grdVReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            Me.Cursor = Cursors.WaitCursor

            If result = Windows.Forms.DialogResult.OK Then

                pnPBar.Visible = True
                lblInfo.Text = "Ejecutando consulta...."
                pBar.Minimum = 0
                pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    Dim Total As Integer = tblReporte.Rows.Count
                    Dim Cont As Integer = 0

                    pBar.Maximum = Total
                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()


                    worksheet.Columns.Item(0).Width = 1825  'FotoModelo
                    worksheet.Columns.Item(1).Width = 3650  'Foto
                    worksheet.Columns.Item(2).Width = 5475  'MarcaSAY
                    worksheet.Columns.Item(3).Width = 5840  'ColeccionSAY
                    worksheet.Columns.Item(4).Width = 5000  'ModeloSAY
                    worksheet.Columns.Item(5).Width = 5475  'Piel
                    worksheet.Columns.Item(6).Width = 5475  'Color
                    worksheet.Columns.Item(7).Width = 3000  'Talla

                    For i As Int16 = 8 To 52
                        If i <= 51 Then
                            worksheet.Columns.Item(i).Width = 1500 ' Tallas
                        Else
                            worksheet.Columns.Item(i).Width = 3000 ' TotalPares
                        End If

                    Next

                    Dim inicio As Integer = 1

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = grdVReporte.Columns(0).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = grdVReporte.Columns(1).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = grdVReporte.Columns(2).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = grdVReporte.Columns(3).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = grdVReporte.Columns(4).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = grdVReporte.Columns(5).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = grdVReporte.Columns(6).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = grdVReporte.Columns(7).FieldName.ToString()

                    For i As Int16 = 8 To 52
                        worksheet.Rows.Item(inicio).Cells.Item(i).Value = grdVReporte.Columns(i).FieldName.ToString()
                    Next

                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To grdVReporte.Columns.Count Step 1  '13
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSkyBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    For r As Integer = (0) To grdVReporte.RowCount - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1145

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(0).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(2).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(3).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(4).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(5).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(6).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(7).FieldName.ToString())


                        For i As Int16 = 8 To 52
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = grdVReporte.GetRowCellValue(r, grdVReporte.Columns(i).FieldName.ToString())
                        Next


                        If Not IsDBNull(grdVReporte.GetRowCellValue(r, grdVReporte.Columns(1).FieldName.ToString())) Then
                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                        New Infragistics.Documents.Excel.WorksheetImage(grdVReporte.GetRowCellValue(r, grdVReporte.Columns(1).FieldName.ToString()))

                            Dim Ancho As Double = imageShape.Image.Width
                            Dim alto As Double = imageShape.Image.Height

                            If imageShape.Image.Width > imageShape.Image.Height Then
                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                            Else
                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                            End If

                            ' The top-left corner of the image should be at the 
                            ' top-left corner of cell A1
                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                            ' The bottom-right corner of the image should be at 
                            ' the bottom-right corner of cell A1
                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                            imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                            worksheet.Shapes.Add(imageShape)
                        End If
                        Cont += 1
                        pBar.Value = Cont
                        lblInfo.Text = "Exportando datos..." & Cont.ToString()
                        System.Windows.Forms.Application.DoEvents()

                    Next

                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()

                    For i As Int16 = 0 To grdVReporte.RowCount - 1 Step 1
                        For j As Int16 = 0 To grdVReporte.Columns.Count Step 1 '13

                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next

                    Next

                    worksheet.Columns.Item(0).Hidden = True



                    System.Windows.Forms.Application.DoEvents()


                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)

                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.mensaje = ex.Message
                    objMensajeError.ShowDialog()
                Finally
                    pBar.Value = pBar.Minimum
                    pnPBar.Visible = False
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdReporte_Click(sender As Object, e As EventArgs)

    End Sub
End Class