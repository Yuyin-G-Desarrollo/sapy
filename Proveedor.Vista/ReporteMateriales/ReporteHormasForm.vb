Imports System.Drawing
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports System.Globalization
Imports Tools
Imports Infragistics.Documents.Excel
Imports System.Net
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class ReporteHormasForm

    Private Sub ReporteHormasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
    End Sub

#Region "Variables globales"

    ReadOnly msgAdvertencia As New AdvertenciaForm
    ReadOnly listInicial As New List(Of String)

#End Region

#Region "Panel Cabecera"

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If vwReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try

                    Dim workbook As New Workbook
                    Dim worksheet As Worksheet = workbook.Worksheets.Add("Datos")

                    worksheet.Columns.Item(0).Width = 3650
                    worksheet.Columns.Item(1).Width = 2000
                    worksheet.Columns.Item(2).Width = 2920
                    worksheet.Columns.Item(3).Width = 7125
                    worksheet.Columns.Item(4).Width = 7125
                    worksheet.Columns.Item(5).Width = 7125
                    worksheet.Columns.Item(6).Width = 3555
                    worksheet.Columns.Item(7).Width = 3555
                    worksheet.Columns.Item(8).Width = 6215
                    worksheet.Columns.Item(9).Width = 3555
                    worksheet.Columns.Item(10).Width = 2555
                    worksheet.Columns.Item(11).Width = 7030
                    worksheet.Columns.Item(12).Width = 3190
                    worksheet.Columns.Item(13).Width = 8030
                    worksheet.Columns.Item(14).Width = 4000
                    worksheet.Columns.Item(15).Width = 4000
                    worksheet.Columns.Item(16).Width = 4000
                    worksheet.Columns.Item(17).Width = 4000
                    worksheet.Columns.Item(18).Width = 4500


                    Dim inicio As Integer = 0

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = vwReporte.Columns(0).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = vwReporte.Columns(1).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = vwReporte.Columns(3).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = vwReporte.Columns(4).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = vwReporte.Columns(5).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = vwReporte.Columns(6).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = vwReporte.Columns(7).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = vwReporte.Columns(8).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(8).Value = vwReporte.Columns(9).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(9).Value = vwReporte.Columns(10).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(10).Value = vwReporte.Columns(11).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(11).Value = vwReporte.Columns(12).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(12).Value = vwReporte.Columns(13).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(13).Value = vwReporte.Columns(14).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(14).Value = "H. Activa"
                    worksheet.Rows.Item(inicio).Cells.Item(15).Value = vwReporte.Columns(18).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(16).Value = vwReporte.Columns(19).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(17).Value = vwReporte.Columns(21).FieldName.ToString()
                    'worksheet.Rows.Item(inicio).Cells.Item(18).Value = vwReporte.Columns(21).FieldName.ToString()

                    If chbFoto.Checked = True Then
                        worksheet.Rows.Item(inicio).Cells.Item(18).Value = vwReporte.Columns(22).FieldName.ToString()
                    End If

                    If chbFoto.Checked = True Then
                        For i As Int16 = inicio To inicio Step 1
                            For j As Int16 = 0 To 18 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            Next
                        Next

                    Else
                        For i As Int16 = inicio To inicio Step 1
                            For j As Int16 = 0 To 17 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            Next
                        Next
                    End If

                    For r As Integer = (0) To vwReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1705 '1505

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(1).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(3).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(4).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(5).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(6).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(7).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(8).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(9).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(10).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(11).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(12).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(13).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(14).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(15).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(15).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(18).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(16).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(19).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(17).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(21).FieldName.ToString())


                        If chbFoto.Checked = True Then

                            If Not IsDBNull(vwReporte.GetRowCellValue(r, vwReporte.Columns(22).FieldName.ToString())) Then 'And Not vwReporte.GetRowCellValue(r, vwReporte.Columns(13).FieldName.ToString()) = "" Then
                                Dim imageShape As WorksheetImage =
                            New WorksheetImage(vwReporte.GetRowCellValue(r, vwReporte.Columns(22).FieldName.ToString()))

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = imageShape.Image.Height * 100 / imageShape.Image.Width
                                Else
                                    Ancho = imageShape.Image.Width * 100 / imageShape.Image.Height
                                End If

                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(18)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(18)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, 100) 'alto

                                worksheet.Shapes.Add(imageShape)
                            End If

                        Else
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(18).Value = ""


                        End If
                    Next

                    If chbFoto.Checked = True Then
                        For i As Int16 = 0 To vwReporte.RowCount - 1 Step 1
                            For j As Int16 = 0 To 18 Step 1

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next

                    Else
                        For i As Int16 = 0 To vwReporte.RowCount - 1 Step 1
                            For j As Int16 = 0 To 17 Step 1

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next
                    End If

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

#End Region

#Region "Panel Parametros"

#Region "Eventos Nave"

    Private Sub GrdNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNaves.InitializeLayout
        DiseñoFiltro(grdNaves)
        grdNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "NAVE"
    End Sub

    Private Sub BtnAgregarNave_Click(sender As Object, e As EventArgs) Handles btnAgregarNave.Click
        Dim listado As New ListadoNavesForm With {
            .tipo_Nave = 0
        }
        If (rdoInactivoHorma.Checked = True) Then
            listado.activo = 0 ' solo naves Inactivas
        ElseIf (rdoActivoHorma.Checked = True) Then
            listado.activo = 1 ' solo naves Activas
        ElseIf rdoAmbosHorma.Checked = True Then
            listado.activo = 2 ' naves Activas e Inactivas
        End If

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub BtnLimpiarNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarNave.Click
        grdNaves.DataSource = listInicial
    End Sub

    Private Sub GrdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Hormas"

    Private Sub GrdHormas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdHormas.InitializeLayout
        DiseñoFiltro(grdHormas)
        grdHormas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "HORMA"
    End Sub

    Private Sub BtnAgregarHorma_Click(sender As Object, e As EventArgs) Handles btnAgregarHorma.Click
        Dim listado As New listadoHormasForm

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdHormas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdHormas.DataSource = listado.listaParametros
        grid_diseño(grdHormas)
        With grdHormas.DisplayLayout.Bands(0)
            .Columns(2).Header.Caption = "Hormas"
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarHorma_Click(sender As Object, e As EventArgs) Handles btnLimpiarHorma.Click
        grdHormas.DataSource = listInicial
    End Sub

    Private Sub GrdHormas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdHormas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Marca"

    Private Sub GrdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        DiseñoFiltro(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "MARCA"
    End Sub

    Private Sub BtnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 8
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdMarca.DataSource = filtroReporte.LST_PARAMETROS
        With grdMarca
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarMarca.Click
        grdMarca.DataSource = listInicial
    End Sub

    Private Sub GrdMarca_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarca.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Coleccion"

    Private Sub GrdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        DiseñoFiltro(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "COLECCION"
    End Sub

    Private Sub BtnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 5
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdColecciones.DataSource = filtroReporte.LST_PARAMETROS
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub GrdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColecciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Familia Ventas"

    Private Sub GrdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        DiseñoFiltro(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "FAMILIA VENTAS"
    End Sub

    Private Sub BtnAgregarFamilia_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 3
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdFamilias.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdFamilias.DataSource = filtroReporte.LST_PARAMETROS
        With grdFamilias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFamilia.Click
        grdFamilias.DataSource = listInicial
    End Sub

    Private Sub GrdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Temporada"

    Private Sub GrdTemporada_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTemporada.InitializeLayout
        DiseñoFiltro(grdTemporada)
        grdTemporada.DisplayLayout.Bands(0).Columns(0).Header.Caption = "TEMPORADA"
    End Sub

    Private Sub BtnAgregarTemporada_Click(sender As Object, e As EventArgs) Handles btnAgregarTemporada.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 9
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdTemporada.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdTemporada.DataSource = filtroReporte.LST_PARAMETROS
        With grdTemporada
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 15
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdCorrida.DataSource = filtroReporte.LST_PARAMETROS
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnAgregarModeloSicy_Click(sender As Object, e As EventArgs) Handles btnAgregarModeloSicy.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 14
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdModeloSicy.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdModeloSicy.DataSource = filtroReporte.LST_PARAMETROS
        With grdModeloSicy
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarTemporada_Click(sender As Object, e As EventArgs) Handles btnLimpiarTemporada.Click
        grdTemporada.DataSource = listInicial
    End Sub

    Private Sub BtnLimpiarCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarCorrida.Click
        grdCorrida.DataSource = listInicial
    End Sub

    Private Sub GrdModeloSicy_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdModeloSicy.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub GrdCorrida_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCorrida.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnLimpiarModeloSicy_Click(sender As Object, e As EventArgs) Handles btnLimpiarModeloSicy.Click
        grdModeloSicy.DataSource = listInicial
    End Sub

    Private Sub GrdTemporada_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTemporada.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Estatus"

    Private Sub GrdEstatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatus.InitializeLayout
        DiseñoFiltro(grdEstatus)
        grdEstatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "ESTATUS"
    End Sub

    Private Sub BtnAgregarEstatus_Click(sender As Object, e As EventArgs) Handles btnAgregarEstatus.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 10
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdEstatus.DataSource = filtroReporte.LST_PARAMETROS
        With grdEstatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarEstatus.Click
        grdEstatus.DataSource = listInicial
    End Sub

    Private Sub GrdEstatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEstatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Flechas"

    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 25
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 217
    End Sub

#End Region

#End Region

#Region "Panel Acciones"

    Private Sub BtnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        Cursor = Cursors.WaitCursor
        Dim ruta As String = String.Empty
        Dim image As Image
        Dim StreamFoto As IO.Stream
        Dim Cont As Integer = 0
        Dim objFTP As New TransferenciaFTP
        Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
        Dim Carpeta As String = "Programacion/Modelos/"
        Try
            Dim obj As New ReporteMaterialesBU
            Dim navesId As String = Filtro(grdNaves)
            Dim Horma As String = Filtro(grdHormas)
            Dim marca As String = Filtro(grdMarca)
            Dim coleccion As String = Filtro(grdColecciones)
            Dim venta As String = Filtro(grdFamilias)
            Dim temporada As String = Filtro(grdTemporada)
            Dim estatus As String = Filtro(grdEstatus)
            Dim HormaActiva As String = " "
            Dim ArticuloActivoEnNAve As String = String.Empty
            Dim navesDesarrollo As String = Filtro(grdNavesDesarrollo)
            Dim grupoDesarrollo As String = cboGrupoDesarrollo.Text
            Dim ModeloSicy As String = Filtro(grdModeloSicy)
            Dim Corrida As String = Filtro(grdCorrida)

            If rdoActivoModelo.Checked = True Then
                ArticuloActivoEnNAve = "1"
            ElseIf rdoInactivoModelo.Checked = True Then
                ArticuloActivoEnNAve = "0"
            Else
                ArticuloActivoEnNAve = " "
            End If
            If rdoActivoHorma.Checked = True Then
                HormaActiva = "1"
            ElseIf rdoInactivoHorma.Checked = True Then
                HormaActiva = "0"
            Else
                HormaActiva = " "
            End If

            Dim tabla As DataTable = obj.ObtenerHormasActivasInactivas(navesId, HormaActiva, Horma, ArticuloActivoEnNAve, marca, coleccion, venta, temporada, estatus, navesDesarrollo, grupoDesarrollo, ModeloSicy, Corrida)

            If tabla.Rows.Count > 0 Then
                tabla.Columns.Add("Foto", GetType(Image))

                For Each row As DataRow In tabla.Rows
                    ruta = IIf(IsDBNull(row.Item("Imagen")), "", row.Item("Imagen").ToString.Trim())
                    If ruta.Length > 0 Then
                        Try
                            image = Nothing
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                            image = Image.FromStream(StreamFoto)
                            row.Item("Foto") = image
                        Catch ex As Exception
                            Try
                                image = Nothing
                                StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                image = Image.FromStream(StreamFoto)
                                row.Item("Foto") = image
                            Catch exe As Exception

                            End Try
                        End Try
                    Else
                        row.Item("Foto") = Nothing
                    End If
                    Cont += 1
                Next

                grdHormaActivaInactiva.DataSource = tabla
                vwReporte.Columns.ColumnByFieldName("Imagen").Visible = False
                diseñogrid()

                lblUltimaActualizacion.Text = Date.Now.ToString
                lblTotalArticulos.Text = tabla.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                btnArriba.PerformClick()
            Else
                msgAdvertencia.mensaje = "No se encontró información."
                btnLimpiar.PerformClick()
                msgAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Inicializar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()

        grdHormaActivaInactiva.DataSource = Nothing
        vwReporte.Columns.Clear()

        grdNaves.DataSource = listInicial
        grdHormas.DataSource = listInicial
        grdMarca.DataSource = listInicial
        grdFamilias.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        grdTemporada.DataSource = listInicial
        grdEstatus.DataSource = listInicial
        grdModeloSicy.DataSource = listInicial
        grdCorrida.DataSource = listInicial

        chbFoto.Checked = True

        lblTotalArticulos.Text = "-"
        lblUltimaActualizacion.Text = "-"

        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DiseñoFiltro(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

    End Sub

    Private Function Filtro(ByVal grid As UltraGrid) As String
        Dim lista As New List(Of Integer)
        Dim coleccion As String = ""

        For Each row As UltraGridRow In grid.Rows
            If Not grid.Name.Equals(grdColecciones.Name) Then
                If row.Cells(" ").Value Then lista.Add(row.Cells(0).Value)
            Else
                If row.Cells(" ").Value Then
                    coleccion += If(coleccion.Equals(""), "'" + row.Cells(2).Value.ToString + "'", ",'" + row.Cells(2).Value.ToString + "'")
                End If
            End If
        Next

        Return If(Not grid.Name.Equals(grdColecciones.Name), String.Join(",", lista).ToString, coleccion)
    End Function

#End Region


#Region "DISEÑO GRID"

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub diseñogrid()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next

        vwReporte.IndicatorWidth = 50

        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True
        vwReporte.OptionsView.ShowIndicator = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsView.ShowAutoFilterRow = True


        vwReporte.Columns.ColumnByFieldName("Nave").Width = 70
        vwReporte.Columns.ColumnByFieldName("Prioridad").Width = 40
        vwReporte.Columns.ColumnByFieldName("Grupo").Width = 40
        vwReporte.Columns.ColumnByFieldName("Marca").Width = 70
        vwReporte.Columns.ColumnByFieldName("Temporada").Width = 145
        vwReporte.Columns.ColumnByFieldName("Familia").Width = 145
        vwReporte.Columns.ColumnByFieldName("Colección").Width = 160
        vwReporte.Columns.ColumnByFieldName("Modelo SAY").Width = 70
        vwReporte.Columns.ColumnByFieldName("Modelo SICY").Width = 75
        vwReporte.Columns.ColumnByFieldName("Piel").Width = 135
        vwReporte.Columns.ColumnByFieldName("Color").Width = 95
        vwReporte.Columns.ColumnByFieldName("Corrida").Width = 55
        vwReporte.Columns.ColumnByFieldName("Horma").Width = 112
        vwReporte.Columns.ColumnByFieldName("Horma Activa").Width = 63
        vwReporte.Columns.ColumnByFieldName("Estatus Producción").Width = 195
        vwReporte.Columns.ColumnByFieldName("Foto").Width = 112
        vwReporte.Columns.ColumnByFieldName("Nave Desarrollo").Width = 100
        vwReporte.Columns.ColumnByFieldName("Grupo Desarrollo").Width = 100
        vwReporte.Columns.ColumnByFieldName("ST").Width = 35
        vwReporte.Columns.ColumnByFieldName("Fecha Vigencia").Width = 100


        vwReporte.Columns.ColumnByFieldName("Horma Activa").Caption = "H. Activa"
        vwReporte.Columns.ColumnByFieldName("ID").Visible = False
        vwReporte.Columns.ColumnByFieldName("Artículo Activo").Visible = False
        'vwReporte.Columns.ColumnByFieldName("horma_hormaid").Visible = False
        'vwReporte.Columns.ColumnByFieldName("Imagen").Visible = False
        vwReporte.Columns.ColumnByFieldName("Foto").OptionsFilter.AllowFilter = False

        If chbFoto.Checked Then
            vwReporte.Columns.ColumnByFieldName("Foto").Visible = True
        Else
            vwReporte.Columns.ColumnByFieldName("Foto").Visible = False
        End If

        vwReporte.OptionsSelection.EnableAppearanceFocusedCell = False
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True


        With vwReporte.Appearance
            .SelectedRow.Options.UseBackColor = True
            .SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
            .EvenRow.BackColor = Color.White
            .OddRow.BackColor = SystemColors.ActiveCaption
            .FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
            .FocusedRow.ForeColor = Color.White
            .HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        End With
        vwReporte.ClearColumnsFilter()



    End Sub

    Private Function ObtenerColorEstatus(ByVal Estatus As String) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = "VDES" Then
            TipoColor = pnlDescontinuado.BackColor
        ElseIf Estatus = "V1Y15" Then
            TipoColor = pnlde1a15dias.BackColor
        ElseIf Estatus = "V+15" Then
            TipoColor = pnlMayora15dias.BackColor
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor

    End Function

    Private Sub vwReporte_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwReporte.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        If vwReporte.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub


    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If e.Info.IsRowIndicator And e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chbFoto_Click(sender As Object, e As EventArgs) Handles chbFoto.Click
        If vwReporte.RowCount > 0 Then
            If chbFoto.Checked Then
                vwReporte.Columns.ColumnByFieldName("Foto").Visible = True
            Else
                vwReporte.Columns.ColumnByFieldName("Foto").Visible = False

            End If
        End If
    End Sub
#End Region
    Private Sub grdNavesDesarrollo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNavesDesarrollo.InitializeLayout
        DiseñoFiltro(grdNavesDesarrollo)
        grdNavesDesarrollo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "NAVE"
    End Sub
    Private Sub btnAgregarNaveDesarrollo_Click(sender As Object, e As EventArgs) Handles btnAgregarNaveDesarrollo.Click
        Dim listado As New ListadoNavesForm With {
            .tipo_Nave = 0,
            .listaNavesDesarrollo = 1
        }
        If (rdoInactivoHorma.Checked = True) Then
            listado.activo = 0 ' solo naves Inactivas
        ElseIf (rdoActivoHorma.Checked = True) Then
            listado.activo = 1 ' solo naves Activas
        ElseIf rdoAmbosHorma.Checked = True Then
            listado.activo = 2 ' naves Activas e Inactivas
        End If

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNavesDesarrollo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNavesDesarrollo.DataSource = listado.listaParametros
        With grdNavesDesarrollo
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves Desarrollo"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grdNavesDesarrollo_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNavesDesarrollo.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub btnLimpiarNaveDesarrollo_Click(sender As Object, e As EventArgs) Handles btnLimpiarNaveDesarrollo.Click
        grdNavesDesarrollo.DataSource = listInicial
    End Sub

    Private Sub GrdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        DiseñoFiltro(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub GrdModeloSicy_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModeloSicy.InitializeLayout
        DiseñoFiltro(grdModeloSicy)
        grdModeloSicy.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo Sicy"
    End Sub
End Class