Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Net
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Tools
Imports Infragistics.Documents.Excel

'Imports Microsoft.Office.Interop

'Imports Infragistics.Documents.Reports.Report
'Imports Infragistics.Documents.Reports.Report.Section


Public Class ExportarAExcelForm

    Public IdCliente As Integer
    Public NombreCliente As String
    Public IdPais As Integer
    Public IdListaPrecioBase As Integer
    Public IdListaVentasClientePrecio As Integer
    Public Marcas As String
    Public IdMoneda As Integer
    Public IdPaisMoneda As Integer
    Public ListaCompleta_O_Pedidos As Boolean
    Public FechaInicioPedido As String
    Public FechaFinPedido As String
    Public Paridad As Double
    Public agentes As String
    Public idsMarcas As String


    Dim objFTP As New Tools.TransferenciaFTP
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"
    Dim StreamFoto As System.IO.Stream
    Dim imagen As Image
    Dim Folder As String

    Private Sub ExportarAExcelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Me.WindowState = 2
        Me.Cursor = Cursors.WaitCursor
        gboxDescuentos.Width = Me.Width - 480
        request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
        txtNombreCliente.Text = NombreCliente
        RecuperarInformacion_ListaDeCliente()
        RecuperarDescuentosDelCliente()
        RecuperarCatalogo()
        btnGuardar.PerformClick()
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE LA LISTA DE VENTAS DEL CLIENTE Y SU VIGENCIA Y LO ASIGNA A LAS CAJAS DE TEXTO CORRESPONDIENTES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecuperarInformacion_ListaDeCliente()
        Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtInformacion As New DataTable

        dtInformacion = objListaClienteBU.RecuperarInformacion_ListaDeCliente(IdCliente, IdListaVentasClientePrecio)

        For Each row As DataRow In dtInformacion.Rows
            If IsDBNull(row.Item(0)) Then
            Else
                txtTemporada.Text = row.Item(0)
            End If

            txtVigencia.Text = row.Item(1)
        Next
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DESCUENTOS ASIGNADOS AL UN CLIENTE EN ESPECIFICO Y LOS ASIGNA AL GRID 'GRDDESCUENTOS'
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarDescuentosDelCliente()
        Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtGridDescuentos As New DataTable

        dtGridDescuentos = objListaClienteBU.RecuperarDescuentosDelCliente(IdCliente)
        grdDescuentos.DataSource = dtGridDescuentos

        DarFormatoGrid(grdDescuentos)
    End Sub

    Public Sub RecuperarCatalogo()
        Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtGridCatalogo As New DataTable

        dtGridCatalogo = objListaClienteBU.RecuperarCatalogo_De_Productos(IdCliente, IdListaPrecioBase, IdListaVentasClientePrecio, Marcas, IdMoneda, ListaCompleta_O_Pedidos,
                                                                          FechaInicioPedido, FechaFinPedido, Paridad, agentes, Marcas)
        grdCatalogo.DataSource = dtGridCatalogo

        DarFormatoGrid(grdCatalogo)
    End Sub

    Private Sub DarFormatoGrid(ByVal grid As UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next

    End Sub

    Private Sub grdCatalogo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCatalogo.InitializeLayout
        Me.Cursor = Cursors.WaitCursor
        With grdCatalogo
            .DisplayLayout.Bands(0).Columns("FOTO").Style = ColumnStyle.Image
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowAddNew = False

            .DisplayLayout.Override.RowSizing = RowSizing.AutoFree
            .DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True
            .DisplayLayout.Override.DefaultRowHeight = 100

            .DisplayLayout.Bands(0).Columns("FOTO").Width = 100

            For Each row As UltraGridRow In grdCatalogo.Rows
                If (row.Cells("Precio").Value).Contains(".") Then
                    row.Cells("Precio").Value = row.Cells("Precio").Value + "0"
                Else
                    row.Cells("Precio").Value = row.Cells("Precio").Value + ".00"
                End If

            Next
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdCatalogo_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdCatalogo.InitializeRow
        Me.Cursor = Cursors.WaitCursor
        If e.Row.Cells.Exists("FOTO") Then
            e.Row.Cells("FOTO").Appearance.BackColor = Color.White
            Try
                If IsDBNull(e.Row.Cells("FOTO")) = False Then
                    imagen = Nothing

                    If (e.Row.Cells("FOTO").Value.ToString <> Nothing) Then
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("FOTO").Value.ToString)
                        imagen = Image.FromStream(StreamFoto)
                        e.Row.Cells("FOTO").Appearance.ImageBackground = imagen
                    End If
                End If

            Catch ex As Exception
                Try
                    StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("FOTO").Value.ToString)
                    'Console.WriteLine(CStr(StreamFoto.Length))
                    imagen = Image.FromStream(StreamFoto)

                    e.Row.Cells("FOTO").Appearance.ImageBackground = imagen
                Catch exe As Exception

                End Try
            End Try
        End If


        If e.Row.Index = grdCatalogo.Rows.Count - 1 Then
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub grdDescuentos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDescuentos.InitializeLayout
        With grdDescuentos
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowAddNew = False

            .DisplayLayout.Override.RowSizing = RowSizing.AutoFree
            .DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True
        End With

    End Sub

    Public Sub Exportar_Excel(ByVal dgv As UltraGrid)

        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                ' Folder = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + (txtNombreCliente.Text) + (txtTemporada.Text).ToUpper + (txtVigencia.Text).ToUpper + ".xls"

                Dim workbook As New Infragistics.Documents.Excel.Workbook
                Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                worksheet.Columns.Item(0).Width = 1825
                worksheet.Columns.Item(1).Width = 3650
                worksheet.Columns.Item(2).Width = 2920
                worksheet.Columns.Item(3).Width = 9125
                worksheet.Columns.Item(4).Width = 2555
                worksheet.Columns.Item(5).Width = 5840
                worksheet.Columns.Item(6).Width = 5110
                worksheet.Columns.Item(7).Width = 2555
                worksheet.Columns.Item(8).Width = 6205
                worksheet.Columns.Item(9).Width = 5475
                worksheet.Columns.Item(10).Width = 2190
                worksheet.Columns.Item(11).Width = 8030

                worksheet.Rows.Item(0).Cells.Item(5).Value = "LISTA DE PRECIOS PARA CONFIRMACION DE MODELAJE"
                For i As Int16 = 0 To 1 Step 1
                    For j As Int16 = 0 To 11 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.RoyalBlue)
                    Next
                Next

                worksheet.Rows(0).Cells(0).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center

                worksheet.Rows.Item(2).Cells.Item(0).Value = "CLIENTE"
                worksheet.Rows.Item(3).Cells.Item(0).Value = "TEMPORADA"
                worksheet.Rows.Item(4).Cells.Item(0).Value = "VIGENCIA DE COSTOS"
                worksheet.Rows.Item(2).Cells.Item(3).Value = (txtNombreCliente.Text).ToUpper
                worksheet.Rows.Item(3).Cells.Item(3).Value = (txtTemporada.Text).ToUpper
                worksheet.Rows.Item(4).Cells.Item(3).Value = (txtVigencia.Text).ToUpper

                For i As Int16 = 2 To 4 Step 1
                    For j As Int16 = 3 To 3 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next


                For i As Int16 = 2 To 4 Step 1
                    For j As Int16 = 0 To 2 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                    Next
                Next

                worksheet.Rows.Item(3).Cells.Item(11).Value = "Fecha de impresión:"
                worksheet.Rows.Item(4).Cells.Item(11).Value = DateTime.Now

                For i As Int16 = 3 To 4 Step 1
                    For j As Int16 = 11 To 11 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                    Next
                Next


                '____________________________________________________________________________________________________________________
                '---PASAMOS LOS DATOS DEL GRID DESCUENTOS
                '____________________________________________________________________________________________________________________

                'EXPORTAMOS LOS DATOS DE LAS COLUMNAS
                For c As Integer = 0 To grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                    If c > 0 Then
                        worksheet.Rows.Item(2).Cells.Item(c + 7).Value = grdDescuentos.DisplayLayout.Bands(0).Columns(c).Header.Caption
                    Else
                        worksheet.Rows.Item(2).Cells.Item(c + 6).Value = grdDescuentos.DisplayLayout.Bands(0).Columns(c).Header.Caption
                    End If
                Next

                For i As Int16 = 2 To 2 Step 1
                    For j As Int16 = 6 To 9 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        If j = 6 Then
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Right
                        Else
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        End If
                    Next
                Next

                For i = 3 To grdDescuentos.Rows.Count + 2 Step 1
                    For j = 6 To 7 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                    Next
                Next

                For f As Integer = 0 To grdDescuentos.Rows.Count - 1
                    For cc As Integer = 0 To grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                        If cc > 0 Then
                            worksheet.Rows.Item(f + 3).Cells.Item(cc + 7).Value = grdDescuentos.Rows(f).Cells(cc).Value
                        Else
                            worksheet.Rows.Item(f + 3).Cells.Item(cc + 6).Value = grdDescuentos.Rows(f).Cells(cc).Value
                        End If
                    Next
                Next

                For i As Int16 = 3 To (grdDescuentos.Rows.Count) + 2 Step 1
                    For j As Int16 = 8 To 9 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next


                '____________________________________________________________________________________________________________________
                '---PASAMOS LOS DATOS DEL GRID CATALOGO
                '____________________________________________________________________________________________________________________

                Dim inicio As Integer = 0

                'exportamos los caracteres de las columnas 
                For c As Integer = 0 To grdCatalogo.DisplayLayout.Bands(0).Columns.Count - 1
                    If grdDescuentos.Rows.Count < 3 Then
                        inicio = (3 - grdDescuentos.Rows.Count) + grdDescuentos.Rows.Count + 4
                    Else
                        inicio = grdDescuentos.Rows.Count + 1
                    End If
                    worksheet.Rows.Item(inicio).Cells.Item(c).Value = grdCatalogo.DisplayLayout.Bands(0).Columns(c).Header.Caption
                Next

                For i As Int16 = inicio To inicio Step 1
                    For j As Int16 = 0 To 11 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                    Next
                Next

                For r As Integer = (0) To grdCatalogo.Rows.Count - 1
                    worksheet.Rows.Item(r + inicio + 1).Height = 1505
                    For c As Integer = 0 To grdCatalogo.DisplayLayout.Bands(0).Columns.Count - 1

                        If c = 1 Then
                            If IsDBNull(grdCatalogo.Rows(r).Cells(c).Value) = False And grdCatalogo.Rows(r).Cells(c).Appearance.ImageBackground IsNot Nothing Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                                New Infragistics.Documents.Excel.WorksheetImage(grdCatalogo.Rows(r).Cells(c).Appearance.ImageBackground)

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(c)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(c)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                worksheet.Shapes.Add(imageShape)
                            End If
                        Else
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(c).Value = grdCatalogo.Rows(r).Cells(c).Value
                        End If
                    Next
                Next


                For i As Int16 = 0 To grdCatalogo.Rows.Count - 1 Step 1
                    For j As Int16 = 0 To 11 Step 1

                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next

                For r As Integer = (0) To grdCatalogo.Rows.Count - 1
                    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                Next
                workbook.Save(fileName)



                Dim objMensajeExito As New ExitoForm
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                objMensajeExito.ShowDialog()

                Me.Close()
                'Dim appXL As Excel.Application
                'Dim wbXl As Excel.Workbook
                'Dim shXL As Excel.Worksheet
                'Dim raXL As Excel.Range
                'Dim Carpeta As String = ""

                '    Carpeta = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + (txtNombreCliente.Text) + (txtTemporada.Text).ToUpper + (txtVigencia.Text).ToUpper + ".xlsx"

                '    ' Start Excel and get Application object.
                '    appXL = CreateObject("Excel.Application")
                '    appXL.Visible = False
                '    ' Add a new workbook.
                '    wbXl = appXL.Workbooks.Add
                '    shXL = wbXl.ActiveSheet


                '    Dim styleTutulo As Excel.Style = shXL.Application.ActiveWorkbook.Styles.Add("Titulo")
                '    styleTutulo.Font.Bold = True
                '    styleTutulo.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                '    styleTutulo.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                '    styleTutulo.Font.Color = Color.DarkBlue

                '    Dim styleCabeceraColumna As Excel.Style = shXL.Application.ActiveWorkbook.Styles.Add("Cabecera")
                '    styleCabeceraColumna.Font.Bold = True
                '    styleCabeceraColumna.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue)
                '    styleCabeceraColumna.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                '    styleCabeceraColumna.Font.Color = Color.White

                '    shXL.Cells(1, 1).value = "LISTA DE PRECIOS PARA CONFIRMACION DE MODELAJE"
                '    With shXL.Range("A1", "O1")
                '        .Style = styleTutulo
                '    End With

                '    With shXL.Range("A3", "C5")
                '        .Style = styleCabeceraColumna
                '    End With

                '    With shXL.Range("F3", "H3")
                '        .Style = styleCabeceraColumna
                '    End With

                '    With shXL.Range("F4", "F5")
                '        .Style = styleCabeceraColumna
                '    End With
                '    shXL.Cells(3, 1).value = "CLIENTE"
                '    shXL.Cells(4, 1).value = "TEMPORADA"
                '    shXL.Cells(5, 1).value = "VIGENCIA DE COSTOS"

                '    shXL.Cells(3, 4).value = (txtNombreCliente.Text).ToUpper
                '    shXL.Cells(4, 4).value = (txtTemporada.Text).ToUpper
                '    shXL.Cells(5, 4).value = (txtVigencia.Text).ToUpper


                '    ''''PASAMOS LOS DATOS DEL GRID DESCUENTOS

                '    'EXPORTAMOS LOS DATOS DE LAS COLUMNAS
                '    For c As Integer = 0 To grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                '        shXL.Cells(3, c + 6).value = grdCatalogo.DisplayLayout.Bands(0).Columns(c).Header.Caption
                '    Next


                '    'EXPORTAMOS LOS DATOS DE LAS CELDAS 
                '    For c As Integer = 6 To grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                '        shXL.Cells(3, c + 1).value = grdDescuentos.DisplayLayout.Bands(0).Columns(c).Header.Caption
                '        shXL.Cells(3, c + 1).Style = styleCabeceraColumna
                '    Next


                '    For f As Integer = 0 To grdDescuentos.Rows.Count - 1
                '        For cc As Integer = 0 To grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                '            shXL.Cells(f + 4, cc + 6).value = grdDescuentos.Rows(f).Cells(cc).Value
                '        Next
                '    Next

                '    ''''PASAMOS LOS DATOS DEL CATALOGO
                '    Dim inicio As Integer = 0

                '    'exportamos los caracteres de las columnas 
                '    For c As Integer = 0 To grdCatalogo.DisplayLayout.Bands(0).Columns.Count - 1
                '        If grdDescuentos.Rows.Count < 3 Then
                '            inicio = (3 - grdDescuentos.Rows.Count) + grdDescuentos.Rows.Count + 4
                '        Else
                '            inicio = grdDescuentos.Rows.Count + 1
                '        End If

                '        shXL.Cells(inicio, c + 1).value = grdCatalogo.DisplayLayout.Bands(0).Columns(c).Header.Caption
                '    Next

                '    With shXL.Range("A" + inicio.ToString, "k" + inicio.ToString)
                '        .Style = styleCabeceraColumna
                '    End With

                '    For r As Integer = (inicio + 1) To grdCatalogo.Rows.Count - 1
                '        For c As Integer = 0 To grdCatalogo.DisplayLayout.Bands(0).Columns.Count - 1

                '            If c = 0 Then
                '                ''You have to get original bitmap path here
                '                '' shXL.Cells(r + 1, c + 1).SetBackgroundPicture(grdCatalogo.Rows(r).Cells(c).Appearance.ImageBackground)

                '                shXL.Cells(r + 1, c + 1).bac = (grdCatalogo.Rows(r).Cells(c).Appearance.ImageBackground)
                '            Else
                '                shXL.Cells(r + 1, c + 1).value = grdCatalogo.Rows(r).Cells(c).Value
                '            End If
                '        Next
                '    Next
                '    raXL = shXL.Range("a" + inicio.ToString, "o10000")
                '    raXL.EntireColumn.AutoFit()

                '    wbXl.SaveAs(Carpeta)
                '    wbXl = Nothing
                '    shXL = Nothing
                '    raXL = Nothing
                '    appXL.Quit()
                '    appXL = Nothing

                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New ErroresForm
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.mensaje = ex.Message
                objMensajeError.ShowDialog()
            End Try

        End If



    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Exportar_Excel(grdCatalogo)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class