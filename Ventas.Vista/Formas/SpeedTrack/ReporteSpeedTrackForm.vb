Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Documents.Excel
Imports Tools

Public Class ReporteSpeedTrackForm
    Public objInstancia As New Negocios.SpeedTrackBU
    Dim confirmar As New Tools.ConfirmarForm
    Dim FilasSeleccionadas As Integer = 0
    Dim cont As Integer = 0
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim imagen As System.Drawing.Image
    Dim StreamFoto As System.IO.Stream
    Dim Carpeta As String = "Programacion/Modelos/"
    Dim dataTable As DataTable
    Private Sub ConsultarModelosGrid()
        Cursor = Cursors.WaitCursor

        vwModelos.Columns.Clear()
        grdModelos.DataSource = Nothing

        Dim pictureEditor As New RepositoryItemPictureEdit
        grdModelos.RepositoryItems.Add(pictureEditor)

        pnPBar.Visible = True
        lblInfo.Text = "Ejecutando consulta, espere un momento por favor..."
        pBar.Minimum = 0
        pBar.ForeColor = Color.Blue
        System.Windows.Forms.Application.DoEvents()

        Dim dataTable = objInstancia.ConsultarReporteSpeedTrack(dtpFechaInicio.Value, dtpFechaFin.Value)
        Dim ruta As String
        If dataTable.Rows.Count > 0 Then
            dataTable.Columns.Add("FOTO", GetType(Image))
            Dim Total As Integer = dataTable.Rows.Count
            Dim Cont As Integer = 0

            pBar.Maximum = Total

            lblInfo.Text = "Descargando imágenes...."
            System.Windows.Forms.Application.DoEvents()

            For Each row As DataRow In dataTable.Rows
                ruta = IIf(IsDBNull(row.Item("ruta")), "", row.Item("ruta").ToString.Trim())
                If ruta.Length > 0 Then
                    Try
                        imagen = Nothing
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                        imagen = System.Drawing.Image.FromStream(StreamFoto)
                        row.Item("FOTO") = imagen
                    Catch ex As Exception
                        Try
                            imagen = Nothing
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                            imagen = System.Drawing.Image.FromStream(StreamFoto)
                            row.Item("FOTO") = imagen
                        Catch exe As Exception

                        End Try
                    End Try
                Else
                    row.Item("FOTO") = Nothing
                End If
                Cont += 1
                pBar.Value = Cont
            Next
            pnPBar.Visible = False
            pBar.Value = 0
        Else
            Tools.Controles.Mensajes_Y_Alertas("INFORMACION", "No se encontraron datos con los filtros seleccionados.")
            pnPBar.Visible = False
            pBar.Value = 0
        End If
        grdModelos.DataSource = Nothing
        vwModelos.Columns.Clear()
            grdModelos.DataSource = dataTable
            DiseñoGrid.DiseñoBaseGrid(vwModelos)
            vwModelos.IndicatorWidth = 35
            vwModelos.OptionsView.AllowCellMerge = True
            DiseñoGrid.EstiloColumna(vwModelos, "PID", "productoid", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
            'DiseñoGrid.EstiloColumna(vwModelos, "FOTO", "foto", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
            DiseñoGrid.EstiloColumna(vwModelos, "ProductoEstiloId", "ProductoEstiloId", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
            DiseñoGrid.EstiloColumna(vwModelos, "ruta", "ruta", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                If (col.FieldName <> "PID" And col.FieldName <> "COLECCIÓN" And col.FieldName <> "PROCESO" And col.FieldName <> "AUTORIZADOS" And col.FieldName <> "TOTAL" And col.FieldName <> "MODELO" And col.FieldName <> "DISPONIBLES" And col.FieldName <> "COLOR" And col.FieldName <> "PIEL" And col.FieldName <> "ruta" And col.Caption <> "FOTO" And col.FieldName <> "ESTATUS") Then
                    vwModelos.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:n0}"
                    vwModelos.Columns.ColumnByFieldName(col.FieldName).Width = 50


                ElseIf (col.FieldName = "MODELO" Or col.FieldName = "COLECCIÓN" Or col.FieldName = "COLOR" Or col.FieldName = "PIEL" Or col.FieldName = "PROCESO" Or col.FieldName = "AUTORIZADOS" Or col.FieldName = "TOTAL" Or col.FieldName = "DISPONIBLES" Or col.FieldName = "ESTATUS") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    col.Fixed = Columns.FixedStyle.Left
                    DiseñoGrid.EstiloColumna(vwModelos, "ESTATUS", "ESTATUS", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
                    'col.DisplayFormat.FormatString = "{0:n0}"
                ElseIf col.Caption.ToUpper = "FOTO" Then
                    vwModelos.Columns.ColumnByFieldName(col.Caption).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                    col.VisibleIndex = 0
                    col.Fixed = Columns.FixedStyle.Left
                    col.VisibleIndex =0
                End If
            Next
            vwModelos.Columns("FOTO").ColumnEdit = grdModelos.RepositoryItems.Add("PictureEdit")
            lblTotalParesProceso.Text = String.Format("{0:N0}", (dataTable.Rows.Count / 5))



        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default

    End Sub

    Private Sub ReporteSpeedTrackForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        'ConsultarModelosGrid()
    End Sub

    Private Sub vwModelos_CellMerge(ByVal sender As Object,
ByVal e As CellMergeEventArgs) Handles vwModelos.CellMerge

        If (e.Column.FieldName = "DISPONIBLES") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "TOTAL") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "PROCESO") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "AUTORIZADOS") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "MODELO") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "COLECCIÓN") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "PIEL") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.FieldName = "COLOR") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
        If (e.Column.Caption.ToUpper = "FOTO") Then

            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "ruta")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "ruta")
            Dim val3 As String = view.GetRowCellValue(e.RowHandle1, "ProductoEstiloId")
            Dim val4 As String = view.GetRowCellValue(e.RowHandle2, "ProductoEstiloId")

            If (val1 & val3) = (val2 & val4) Then

                e.Merge = True

            End If
            e.Handled = True
        End If
    End Sub
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwModelos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub
    Private Sub viewModelos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwModelos.CustomDrawCell


        Dim estatus As String = vwModelos.GetRowCellValue(e.RowHandle, "ESTATUS")
        Dim autorizados As String = vwModelos.GetRowCellValue(e.RowHandle, "AUTORIZADOS")

        For index2 As Integer = 15 To 29 Step 1
            Dim talla = vwModelos.GetRowCellValue(e.RowHandle, index2)
            Dim tallam = vwModelos.GetRowCellValue(e.RowHandle, index2 & "½")
            If e.Column.FieldName = index2.ToString() Then
                If estatus = "5 % DISPONIBLE" Then
                    e.DisplayText = e.CellValue & "%"
                    If talla = 100 Then
                        e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                        e.Appearance.ForeColor = Color.Green
                        If e.Column.Visible = False Then

                            e.Column.Fixed = Columns.FixedStyle.Left
                        End If
                    ElseIf talla > 0 And talla <= 99 Then
                        e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
                        e.Appearance.ForeColor = Color.Black
                        'vwModelos.SetRowCellValue(e.RowHandle, index2.ToString(), talla & "%")
                    ElseIf talla > 100 Then
                        e.Appearance.BackColor = Color.LightPink
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
                If estatus = "4 X PROG" Then
                    If talla > 0 Then
                        e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                        e.Appearance.ForeColor = Color.Green
                    ElseIf talla <= 0 Then
                        e.Appearance.BackColor = Color.LightPink
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            ElseIf e.Column.FieldName = index2 & "½" Then
                If estatus = "5 % DISPONIBLE" Then
                    e.DisplayText = e.CellValue & "%"
                    If tallam = 100 Then
                        e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                        e.Appearance.ForeColor = Color.Green
                    ElseIf tallam > 0 And tallam <= 99 Then
                        e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
                        e.Appearance.ForeColor = Color.Black

                    ElseIf tallam > 100 Then
                        e.Appearance.BackColor = Color.LightPink
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
                If estatus = "4 X PROG" Then
                    If tallam > 0 Then
                        e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                        e.Appearance.ForeColor = Color.Green
                    ElseIf tallam <= 0 Then
                        e.Appearance.BackColor = Color.LightPink
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            End If
        Next
        If e.Column.FieldName = "AUTORIZADOS" Then
            If CInt(autorizados) >= 0 And autorizados <> Nothing Then

                e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If vwModelos.GroupCount > 0 Then
                        vwModelos.ExportToXlsx(.SelectedPath + "\SpeedTrack_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        vwModelos.ExportToXlsx(.SelectedPath + "\SpeedTrack_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "SpeedTrack_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\SpeedTrack_" + fecha_hora + ".xlsx")

                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        If e.RowHandle >= 0 Then
            If e.AreaType <> DevExpress.Export.SheetAreaType.Header Then

                Dim estatus As String = vwModelos.GetRowCellValue(e.RowHandle, "ESTATUS")
                Dim autorizados As String = vwModelos.GetRowCellValue(e.RowHandle, "AUTORIZADOS")

                For index2 As Integer = 15 To 29 Step 1
                    Dim talla = vwModelos.GetRowCellValue(e.RowHandle, index2)
                    Dim tallam = vwModelos.GetRowCellValue(e.RowHandle, index2 & "½")
                    If e.ColumnFieldName = index2.ToString() Then
                        If estatus = "5 % DISPONIBLE" Then
                            e.Value = talla & "%"
                            If talla = 100 Then
                                e.Formatting.BackColor = Color.FromArgb(216, 228, 188)
                                e.Formatting.Font.Color = Color.Green
                            ElseIf talla > 0 And talla <= 99 Then
                                e.Formatting.BackColor = Color.FromArgb(255, 255, 204)
                                e.Formatting.Font.Color = Color.Black
                                'vwModelos.SetRowCellValue(e.RowHandle, index2.ToString(), talla & "%")
                            ElseIf talla > 100 Then
                                e.Formatting.BackColor = Color.LightPink
                                e.Formatting.Font.Color = Color.Red
                            End If
                        End If
                        If estatus = "4 X PROG" Then
                            If talla > 0 Then
                                e.Formatting.BackColor = Color.FromArgb(216, 228, 188)
                                e.Formatting.Font.Color = Color.Green
                            ElseIf talla <= 0 Then
                                e.Formatting.BackColor = Color.LightPink
                                e.Formatting.Font.Color = Color.Red
                            End If
                        End If
                    ElseIf e.ColumnFieldName = index2 & "½" Then
                        If estatus = "5 % DISPONIBLE" Then
                            e.Value = tallam & "%"
                            If tallam = 100 Then
                                e.Formatting.BackColor = Color.FromArgb(216, 228, 188)
                                e.Formatting.Font.Color = Color.Green
                            ElseIf tallam > 0 And tallam <= 99 Then
                                e.Formatting.BackColor = Color.FromArgb(255, 255, 204)
                                e.Formatting.Font.Color = Color.Black

                            ElseIf tallam > 100 Then
                                e.Formatting.BackColor = Color.LightPink
                                e.Formatting.Font.Color = Color.Red
                            End If
                        End If
                        If estatus = "4 X PROG" Then
                            If tallam > 0 Then
                                e.Formatting.BackColor = Color.FromArgb(216, 228, 188)
                                e.Formatting.Font.Color = Color.Green
                            ElseIf tallam <= 0 Then
                                e.Formatting.BackColor = Color.LightPink
                                e.Formatting.Font.Color = Color.Red
                            End If
                        End If
                    End If
                Next
                If e.ColumnFieldName = "AUTORIZADOS" Then
                    If CInt(autorizados) >= 0 And autorizados <> Nothing Then

                        e.Formatting.BackColor = Color.FromArgb(255, 255, 204)
                        e.Formatting.Font.Color = Color.Black
                    End If
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConsultarModelosGrid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub exportaExcel()
        If vwModelos.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    '____________________________________________________________________________________________________________________
                    '---PASAMOS LOS DATOS DEL GRID CATALOGO
                    '____________________________________________________________________________________________________________________
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    Dim inicio As Integer = 7

                    For Each Colum As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                        worksheet.Rows.Item(inicio).Cells.Item(Colum.AbsoluteIndex).Value = Colum.FieldName.ToString()
                    Next

                    'worksheet.Rows.Item(inicio).Cells.Item(0).Value = vwModelos.Columns(0).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(1).Value = vwModelos.Columns(1).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(2).Value = vwModelos.Columns(4).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(3).Value = vwModelos.Columns(5).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(4).Value = vwModelos.Columns(6).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(5).Value = vwModelos.Columns(7).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(6).Value = vwModelos.Columns(8).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(7).Value = vwModelos.Columns(9).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(8).Value = vwModelos.Columns(10).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(9).Value = vwModelos.Columns(11).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(10).Value = vwModelos.Columns(12).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(11).Value = vwModelos.Columns(13).FieldName.ToString()

                    For i As Int16 = inicio To inicio Step 1
                        For Each Colum As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                            worksheet.Rows(i).Cells(Colum.AbsoluteIndex).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(Colum.AbsoluteIndex).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(Colum.AbsoluteIndex).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(Colum.AbsoluteIndex).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    For r As Integer = (0) To vwModelos.RowCount - 1 'grdCatalogo.Rows.Count - 1

                        worksheet.Rows.Item(r + inicio + 1).Height = 1505
                        For Each Colum As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                            If Colum.AbsoluteIndex > 41 Then
                            Else
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(Colum.AbsoluteIndex).Value = vwModelos.GetRowCellValue(r, Colum.FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value


                            End If
                        Next
                        If Not IsDBNull(vwModelos.GetRowCellValue(r, vwModelos.Columns(1).FieldName.ToString())) Then 'And Not vwModelos.GetRowCellValue(r, vwModelos.Columns(13).FieldName.ToString()) = "" Then
                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
New Infragistics.Documents.Excel.WorksheetImage(vwModelos.GetRowCellValue(r, vwModelos.Columns(42).FieldName.ToString()))

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

                            worksheet.Shapes.Add(imageShape)
                        End If
                    Next


                    For i As Int16 = 0 To vwModelos.RowCount - 1 Step 1
                        For Each Colum As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(Colum.AbsoluteIndex).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    For r As Integer = (0) To vwModelos.RowCount - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1145
                    Next
                    workbook.Save(fileName)

                    Dim mergedRegion1 As WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(0, 1, 0, 3)

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
                End Try

            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        exportaExcel()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged


        dtpFechaFin.MinDate = dtpFechaInicio.Value

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_SPEEDTRACK.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_SPEEDTRACK.pdf")
        Catch ex As Exception

        End Try
    End Sub
End Class