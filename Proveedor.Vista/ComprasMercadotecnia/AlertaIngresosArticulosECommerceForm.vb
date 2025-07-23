Imports DevExpress.XtraGrid.Columns
Imports Proveedores.BU
Imports DevExpress.XtraGrid
Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports Infragistics.Documents.Excel


Public Class AlertaIngresosArticulosECommerceForm

    Dim ruta As String = String.Empty
    Dim image As Image
    Dim StreamFoto As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"
    Private Sub AlertaIngresosArticulosECommerceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaEntregaAl.Value = Date.Now
        dtpFechaEntregaDel.Value = Date.Now

        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Public Sub MostrarArticulos(ByVal FechaInicio As Date, ByVal FechaFin As Date)
        Dim ObjBu As New Proveedores.BU.MercadotecniaBU
        Dim DtDatable As DataTable
        grdArticulosIngresados.DataSource = Nothing
        DtDatable = ObjBu.ConsultaArticulosIngresados(FechaInicio, FechaFin)
        'grdArticulosIngresados.DataSource = DtDatable
        'Tools.DiseñoGrid.DiseñoBaseGrid(grdvwArticulosIngresados)
        Try
            Me.Cursor = Cursors.WaitCursor
            If DtDatable.Rows.Count > 0 Then
                DtDatable.Columns.Add("Foto", GetType(Image))

                Dim Total As Integer = DtDatable.Rows.Count
                Dim Cont As Integer = 0

                'pBar.Maximum = Total
                'lblInfo.Text = "Descargando imágenes...."
                System.Windows.Forms.Application.DoEvents()

                Dim imagen As Image
                For Each row As DataRow In DtDatable.Rows
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
                    ' pBar.Value = Cont
                Next
                System.Windows.Forms.Application.DoEvents()
                grdArticulosIngresados.DataSource = DtDatable

                grdvwArticulosIngresados.Columns("Foto").Visible = True
                grdvwArticulosIngresados.Columns("FotoModelo").Visible = False
                grdvwArticulosIngresados.Columns("ProductoEstiloID").Visible = False
                grdvwArticulosIngresados.ColumnPanelRowHeight = 30
                grdvwArticulosIngresados.RowHeight = 50
                grdvwArticulosIngresados.Columns("Foto").VisibleIndex = 0

                grdvwArticulosIngresados.OptionsView.ColumnAutoWidth = True

                DisenioGrid()
                'lblTotalRegistros.Text = tblReporte.Rows.Count

            Else
                Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se encontraron registros en la consulta.")
                'lblTotalRegistros.Text = "0"
            End If
        Catch ex As Exception
        Finally
            lblNumRegistros.Text = DtDatable.Rows.Count.ToString()
            lblFechaUltimaActualización.Text = Date.Now
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        'mostrar
        MostrarArticulos(dtpFechaEntregaDel.Value.ToShortDateString, dtpFechaEntregaAl.Value.ToShortDateString)
    End Sub

    Private Sub grdvwArticulosIngresados_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles grdvwArticulosIngresados.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = grdvwArticulosIngresados.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = grdvwArticulosIngresados.GetRowCellValue(e.RowHandle, "MarcaSAY")
                MostrarFoto.Coleccion = grdvwArticulosIngresados.GetRowCellValue(e.RowHandle, "ColeccionSAY")
                MostrarFoto.ModeloSicy = grdvwArticulosIngresados.GetRowCellValue(e.RowHandle, "ModeloSAY")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarImagen()
    End Sub

    Private Sub ExportarImagen()

        If grdvwArticulosIngresados.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            Me.Cursor = Cursors.WaitCursor

            If result = Windows.Forms.DialogResult.OK Then

                'pnPBar.Visible = True
                'lblInfo.Text = "Ejecutando consulta...."
                'pBar.Minimum = 0
                'pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")
                    worksheet.DisplayOptions.ShowGridlines = True

                    Dim Total As Integer = 0
                    Dim Cont As Integer = 0
                    Dim inicio As Integer = 0

                    'pBar.Maximum = Total
                    'lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()


                    For i As Int16 = 0 To grdvwArticulosIngresados.Columns.Count - 1
                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() <> "Foto" Then
                            worksheet.Rows.Item(0).Cells.Item(i + 1).Value = grdvwArticulosIngresados.Columns(i).FieldName.ToString()
                        Else
                            worksheet.Rows.Item(0).Cells.Item(0).Value = "Foto"
                        End If

                        worksheet.Rows(0).Cells(i).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSkyBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(0).Cells(i).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(0).Cells(i).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(0).Cells(i).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "Foto" Then
                            worksheet.Columns.Item(0).Width = 3650  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "Cliente" Then
                            worksheet.Columns.Item(i + 1).Width = 9650  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "ModeloSAY" Then
                            worksheet.Columns.Item(i + 1).Width = 3650  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "ModeloSAY" Then
                            worksheet.Columns.Item(i + 1).Width = 3650  'Foto
                        End If
                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "ColeccionSAY" Then
                            worksheet.Columns.Item(i + 1).Width = 3650  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "Articulo" Then
                            worksheet.Columns.Item(i + 1).Width = 14650  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "FEntrada" Then
                            worksheet.Columns.Item(i + 1).Width = 3000  'Foto
                        End If

                        If grdvwArticulosIngresados.Columns(i).FieldName.ToString() = "Piel" Then
                            worksheet.Columns.Item(i + 1).Width = 4500  'Foto
                        End If



                    Next

                    For r As Integer = 0 To grdvwArticulosIngresados.RowCount - 1 'grdCatalogo.Rows.Count - 1
                        ' worksheet.Rows.Item(r + inicio + 1).Height = 1505 '1145

                        For i As Int16 = 0 To grdvwArticulosIngresados.Columns.Count - 1
                            If grdvwArticulosIngresados.Columns(i).FieldName <> "Foto" Then
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(i + 1).Value = grdvwArticulosIngresados.GetRowCellValue(r, grdvwArticulosIngresados.Columns(i).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Height = 1505
                            End If


                            ' worksheet.Rows.Item(0).Cells.Item(i).Value = vwClientepares.Columns(i).FieldName.ToString()
                        Next



                        If Not IsDBNull(grdvwArticulosIngresados.GetRowCellValue(r, grdvwArticulosIngresados.Columns("Foto").FieldName.ToString())) Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then
                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(grdvwArticulosIngresados.GetRowCellValue(r, grdvwArticulosIngresados.Columns("Foto").FieldName.ToString()))

                            Dim Ancho As Double = imageShape.Image.Width
                            Dim alto As Double = imageShape.Image.Height

                            If imageShape.Image.Width > imageShape.Image.Height Then
                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                            Else
                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                            End If

                            ' The top-left corner of the image should be at the 
                            ' top-left corner of cell A1
                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(0)
                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                            ' The bottom-right corner of the image should be at 
                            ' the bottom-right corner of cell A1
                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(0)
                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                            imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                            worksheet.Shapes.Add(imageShape)

                        End If
                        Cont += 1
                        ' pBar.Value = Cont
                    Next


                    System.Windows.Forms.Application.DoEvents()
                    worksheet.Columns.Item(1).Hidden = True
                    worksheet.Columns.Item(9).Hidden = True
                    workbook.Save(fileName)
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Exito, "Los dastos se exportaron correctamente en la ubicacion " + fileName + ".")
                    Process.Start(fileName)

                Catch ex As Exception
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Errores, ex.Message.ToString)
                Finally
                    'pBar.Value = pBar.Minimum
                    'pnPBar.Visible = False
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
    End Sub

    Private Sub grdvwArticulosIngresados_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdvwArticulosIngresados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DisenioGrid()
        grdvwArticulosIngresados.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdvwArticulosIngresados.Columns
            If col.FieldName = "ColeccionSAY" Then
                col.Caption = "ColecciónSAY"
            End If
        Next

        If grdvwArticulosIngresados.GroupSummary.Count() = 0 Then

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdvwArticulosIngresados.Columns
                col.Summary.Remove(col.SummaryItem)

                If col.FieldName.Contains("Pares") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            Next
        End If

    End Sub


End Class