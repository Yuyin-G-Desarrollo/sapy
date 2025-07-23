Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports DevExpress.XtraPrinting
Imports System.Net
Imports System.IO
Imports Infragistics.Documents.Excel
Public Class DetallesFolioInspeccionFormvb

    Public FoliosInspeccionId As String = ""
    Public ParesFolio As Integer = 0
    Public ParesIncidencias As Integer = 0
    Public ParesDevueltos As Integer = 0
    Public Nave As String = String.Empty
    Public ParesInspeccionados As Integer = 0
    Public numFolios As Integer = 0
    Dim ObjBU As New Negocios.InspeccionCalidadBU

    Private Sub DetallesFolioInspeccionFormvb_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            lblFolioInspeccion.Text = numFolios.ToString
            lblParesInspeccionados.Text = CDbl(ParesInspeccionados).ToString("N0")
            lblParesIncidencias.Text = CDbl(ParesIncidencias).ToString("N0")
            lblParesDevueltos.Text = CDbl(ParesDevueltos).ToString("N0")

            CargarDetallesFolio()
            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar los detalles.")
        End Try

    End Sub

    Private Sub CargarDetallesFolio()
        Dim DtResultado As New DataTable
        Dim ruta_uno As String = String.Empty
        Dim ruta_dos As String = String.Empty
        Dim image_uno As Image
        Dim image_dos As Image



        Cursor = Cursors.WaitCursor
        Try
            DtResultado = ObjBU.ReporteDetallesFolioInspeccion(FoliosInspeccionId)

            DtResultado.Columns.Add("Foto_uno", GetType(Image))
            DtResultado.Columns.Add("Foto_dos", GetType(Image))


            For Each row As DataRow In DtResultado.Rows
                ruta_uno = IIf(IsDBNull(row.Item("Foto1")), "", row.Item("Foto1").ToString.Trim())
                ruta_dos = IIf(IsDBNull(row.Item("Foto2")), "", row.Item("Foto2").ToString.Trim())


                If ruta_uno.Length > 0 Then
                    Try
                        Dim wc As New WebClient()
                        Dim bytes As Byte() = wc.DownloadData(ruta_uno)
                        Dim ms As New MemoryStream(bytes)
                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                        image_uno = img
                        row.Item("Foto_uno") = image_uno
                    Catch ex As Exception

                    End Try

                Else

                End If

                If ruta_dos.Length > 0 Then
                    Try
                        Dim wc As New WebClient()
                        Dim bytes As Byte() = wc.DownloadData(ruta_dos)
                        Dim ms As New MemoryStream(bytes)
                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                        image_dos = img
                        row.Item("Foto_dos") = image_dos
                    Catch ex As Exception

                    End Try
                Else
                    ' row.Item("Foto") = Nothing
                End If

            Next


            grdInspeccionDetalle.DataSource = DtResultado

            DiseñoGrid.DiseñoBaseGrid(viewInspeccionDetalle)
            viewInspeccionDetalle.IndicatorWidth = 30
            viewInspeccionDetalle.RowHeight = 50

            viewInspeccionDetalle.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Fecha", "Fecha", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "NumeroAtado", "Número Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Par", "Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "MarcaSAY", "Marca SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "ColeccionSAY", "Colección SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Piel", "Piel", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Color", "Color", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Talla", "Corrida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Calce", "Punto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "incidencia", "Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "DescripcionIncidencia", "Descripción Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Departamento", "Departamento", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "clasificacion", "Clasificación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "estatus", "Estatus", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "fechadevolucion", "Fecha Devolución", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "fechaentrega", "Fecha Entrega", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Foto1", "Foto1", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Foto2", "Foto2", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "DevolverAtado", "DevolverAtado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

            lblTotalRegistros.Text = CDbl(DtResultado.Rows.Count).ToString("N0")
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar los datos.")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewInspeccionDetalle_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInspeccionDetalle.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        'ExportarExcel(viewInspeccionDetalle)
        ExportarExcel_v2()
        Cursor = Cursors.Default
    End Sub



    Private Sub ExportarExcel(ByVal ViewGrid As GridView)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                Dim ret As DialogResult = .ShowDialog
                exportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG
                exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True
                exportOptions.BandedLayoutMode = DevExpress.Export.BandedLayoutMode.LinearColumns
                exportOptions.FitToPrintedPageWidth = True
                'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                ViewGrid.ExportToXlsx(.SelectedPath + "\Datos_DetallesFolio_" + numFolios.ToString() + ".xlsx", exportOptions)

                'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                'Dim ret As DialogResult = .ShowDialog
                'Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                'If ret = Windows.Forms.DialogResult.OK Then
                '    If GridView1.GroupCount > 0 Then
                '        ViewGrid.ExportToXlsx(.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx", exportOptions)
                '    Else
                '        ViewGrid.ExportToXlsx(.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx", exportOptions)
                '    End If
                '    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" & fecha_hora.ToString() & ".xlsx")
                '    .Dispose()
                '    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx")
                'End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub viewInspeccionDetalle_RowClick(sender As Object, e As RowClickEventArgs) Handles viewInspeccionDetalle.RowClick
        Dim Form As New VerFotosInspeccionForm
        Dim Foto1 As String = String.Empty
        Dim Foto2 As String = String.Empty
        Dim Incidencia As String = String.Empty
        Dim Departamento As String = String.Empty
        Dim Clasificacion As String = String.Empty
        Dim NumeroAtado As String = String.Empty
        Dim CodigoPar As String = String.Empty
        Dim Modelo As String = String.Empty
        Dim Coleccion As String = String.Empty
        Dim Corrida As String = String.Empty
        Dim Talla As String = String.Empty
        Dim Color As String = String.Empty
        Dim Devuelto As String = String.Empty
        Dim Piel As String = String.Empty
        Dim Lote As String = String.Empty
        Dim Calce As String = String.Empty
        Dim Observaciones As String = String.Empty
        Dim NombreCliente As String = String.Empty
        Dim FechaRevision As String = String.Empty
        Dim ParesREchazados As String = String.Empty
        Dim Rechazo As String = String.Empty
        Dim Operador As String = String.Empty

        Try
            If e.Clicks = 2 Then
                If viewInspeccionDetalle.GroupCount > 0 Then
                    If viewInspeccionDetalle.IsGroupRow(e.RowHandle) = False Then

                        Foto1 = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Foto1").FirstOrDefault()).ToString()
                        Foto2 = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Foto2").FirstOrDefault()).ToString()
                        NombreCliente = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Cliente").FirstOrDefault()).ToString()
                        Clasificacion = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "clasificacion").FirstOrDefault()).ToString()
                        Incidencia = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "DescripcionIncidencia").FirstOrDefault()).ToString()
                        Modelo = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "ModeloSAY").FirstOrDefault()).ToString()
                        Coleccion = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "ColeccionSAY").FirstOrDefault()).ToString()
                        Lote = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Lote").FirstOrDefault()).ToString()
                        Rechazo = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "DevolverAtado").FirstOrDefault()).ToString()
                        FechaRevision = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Fecha").FirstOrDefault()).ToString()
                        ParesREchazados = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Lote").FirstOrDefault()).ToString()
                        Nave = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Nave").FirstOrDefault()).ToString()
                        Operador = viewInspeccionDetalle.GetGroupRowValue(e.RowHandle, viewInspeccionDetalle.Columns.Where(Function(x) x.FieldName = "Operador").FirstOrDefault()).ToString()



                        With Form
                            .Foto1 = Foto1
                            .Foto2 = Foto2
                            .Incidencia = Incidencia
                            .Departamento = Departamento
                            .Clasificacion = Clasificacion
                            .NumeroAtado = NumeroAtado
                            .CodigoPar = CodigoPar
                            .Modelo = Modelo
                            .Coleccion = Coleccion
                            .Corrida = Corrida
                            .Talla = Calce
                            .Color = Color
                            .ParesDevuelto = ParesDevueltos
                            .Lote = Lote
                            .Piel = Piel
                            .Observaciones = Observaciones
                            .Nave = Nave
                            .Cliente = NombreCliente
                            .Rechazo = Rechazo
                            .Operador = Operador
                            .ShowDialog()
                        End With

                    End If

                Else



                    Foto1 = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Foto1").ToString()
                    Foto2 = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Foto2").ToString()
                    NombreCliente = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Cliente").ToString()
                    Clasificacion = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "clasificacion").ToString()
                    Incidencia = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "DescripcionIncidencia").ToString()
                    Modelo = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "ModeloSAY").ToString()
                    Coleccion = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "ColeccionSAY").ToString()
                    Lote = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Lote").ToString()
                    Rechazo = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "DevolverAtado").ToString()
                    FechaRevision = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Fecha").ToString()
                    Nave = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Nave").ToString()
                    Operador = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Operador").ToString()


                    With Form
                        .Foto1 = Foto1
                        .Foto2 = Foto2
                        .Incidencia = Incidencia
                        .Departamento = Departamento
                        .Clasificacion = Clasificacion
                        .NumeroAtado = NumeroAtado
                        .CodigoPar = CodigoPar
                        .Modelo = Modelo
                        .Coleccion = Coleccion
                        .Corrida = Corrida
                        .Talla = Calce
                        .Color = Color
                        .ParesDevuelto = ParesDevueltos
                        .Lote = Lote
                        .Piel = Piel
                        .Observaciones = Observaciones
                        .Nave = Nave
                        .Cliente = NombreCliente
                        .Rechazo = Rechazo
                        .ParesDevuelto = ParesDevueltos
                        .FechaRevision = FechaRevision
                        .Operador = Operador
                        .ShowDialog()
                    End With

                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub viewInspeccionDetalle_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewInspeccionDetalle.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "DevolverAtado" Then
                If e.CellValue = "SI" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "clasificacion" Then
                If e.CellValue = "CRITICO" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "incidencia" Then
                If e.CellValue = "CON INCIDENCIA" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Green
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim DevolverAtado As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "DevolverAtado")
        Dim Clasificacion As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "clasificacion")
        Dim Incidencia As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "incidencia")


        Try


            If e.ColumnFieldName = "DevolverAtado" Then
                If DevolverAtado = "SI" Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "clasificacion" Then
                If Clasificacion = "CRITICO" Then
                    e.Formatting.Font.Color = Color.Red
                End If

            End If

            If e.ColumnFieldName = "incidencia" Then
                If Incidencia = "CON INCIDENCIA" Then
                    e.Formatting.Font.Color = Color.Red
                Else
                    e.Formatting.Font.Color = Color.Green
                End If
            End If

        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub

    Public Sub ExportarExcel_v2()

        If 1 > 0 Then
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

                    worksheet.Columns.Item(0).Width = 3650
                    worksheet.Columns.Item(1).Width = 2000
                    worksheet.Columns.Item(2).Width = 3300
                    worksheet.Columns.Item(3).Width = 2000
                    worksheet.Columns.Item(4).Width = 9500
                    worksheet.Columns.Item(5).Width = 3000
                    worksheet.Columns.Item(6).Width = 5110
                    worksheet.Columns.Item(7).Width = 2555
                    worksheet.Columns.Item(8).Width = 6205
                    worksheet.Columns.Item(9).Width = 5475
                    worksheet.Columns.Item(10).Width = 2190
                    worksheet.Columns.Item(11).Width = 2000 'calce
                    worksheet.Columns.Item(12).Width = 5000
                    worksheet.Columns.Item(13).Width = 6000
                    worksheet.Columns.Item(14).Width = 3650
                    worksheet.Columns.Item(15).Width = 3650
                    worksheet.Columns.Item(16).Width = 3650
                    worksheet.Columns.Item(17).Width = 3650
                    worksheet.Columns.Item(18).Width = 3650
                    worksheet.Columns.Item(19).Width = 7000
                    worksheet.Columns.Item(20).Width = 3650
                    worksheet.Columns.Item(21).Width = 3650
                    worksheet.Columns.Item(22).Width = 3650


                    Dim inicio As Integer = 0

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = viewInspeccionDetalle.Columns(0).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = viewInspeccionDetalle.Columns(1).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = viewInspeccionDetalle.Columns(2).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = viewInspeccionDetalle.Columns(3).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = viewInspeccionDetalle.Columns(4).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = viewInspeccionDetalle.Columns(5).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = viewInspeccionDetalle.Columns(6).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = viewInspeccionDetalle.Columns(7).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(8).Value = viewInspeccionDetalle.Columns(8).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(9).Value = viewInspeccionDetalle.Columns(9).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(10).Value = viewInspeccionDetalle.Columns(10).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(11).Value = viewInspeccionDetalle.Columns(11).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(12).Value = viewInspeccionDetalle.Columns(12).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(13).Value = viewInspeccionDetalle.Columns(13).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(14).Value = viewInspeccionDetalle.Columns(14).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(15).Value = viewInspeccionDetalle.Columns(15).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(16).Value = viewInspeccionDetalle.Columns(16).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(17).Value = viewInspeccionDetalle.Columns(17).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(18).Value = viewInspeccionDetalle.Columns(18).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(19).Value = viewInspeccionDetalle.Columns(19).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(20).Value = viewInspeccionDetalle.Columns(20).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(21).Value = viewInspeccionDetalle.Columns(21).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(22).Value = viewInspeccionDetalle.Columns(22).FieldName.ToString()


                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To 22 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    inicio = 0

                    For r As Integer = (0) To viewInspeccionDetalle.RowCount - 1 'grdCatalogo.Rows.Count - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1505

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(1).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(2).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(3).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(4).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(5).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(6).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(7).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(8).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(9).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(10).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(11).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(12).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(13).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(14).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(15).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(15).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(16).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(16).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(17).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(17).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(18).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(18).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(19).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(19).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(20).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(20).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(21).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(21).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(22).Value = viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(22).FieldName.ToString())


                        If Not IsDBNull(viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(21).FieldName.ToString())) And viewInspeccionDetalle.GetRowCellValue(r, "Foto_uno").ToString <> "" Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then

                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                        New Infragistics.Documents.Excel.WorksheetImage(viewInspeccionDetalle.GetRowCellValue(r, "Foto_uno"))

                            Dim Ancho As Double = imageShape.Image.Width
                            Dim alto As Double = imageShape.Image.Height

                            If imageShape.Image.Width > imageShape.Image.Height Then
                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                            Else
                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                            End If

                            ' The top-left corner of the image should be at the 
                            ' top-left corner of cell A1
                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(20)
                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                            ' The bottom-right corner of the image should be at 
                            ' the bottom-right corner of cell A1
                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(20)
                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                            worksheet.Shapes.Add(imageShape)
                        End If

                        If Not IsDBNull(viewInspeccionDetalle.GetRowCellValue(r, viewInspeccionDetalle.Columns(22).FieldName.ToString())) And viewInspeccionDetalle.GetRowCellValue(r, "Foto_dos").ToString <> "" Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then

                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                        New Infragistics.Documents.Excel.WorksheetImage(viewInspeccionDetalle.GetRowCellValue(r, "Foto_dos"))

                            Dim Ancho As Double = imageShape.Image.Width
                            Dim alto As Double = imageShape.Image.Height

                            If imageShape.Image.Width > imageShape.Image.Height Then
                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                            Else
                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                            End If

                            ' The top-left corner of the image should be at the 
                            ' top-left corner of cell A1
                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(21)
                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                            ' The bottom-right corner of the image should be at 
                            ' the bottom-right corner of cell A1
                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(21)
                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                            worksheet.Shapes.Add(imageShape)
                        End If
                    Next




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
                End Try

            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If
    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs) Handles Panel14.Paint

    End Sub
End Class