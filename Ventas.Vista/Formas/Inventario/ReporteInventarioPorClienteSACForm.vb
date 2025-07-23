Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports System.Net
Imports Infragistics.Documents.Excel

Public Class ReporteInventarioPorClienteSACForm

    Dim ruta As String = String.Empty
    Dim image As Image
    Dim StreamFoto As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim Carpeta As String = "Programacion/Modelos/"
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

    Private Sub ReporteInventarioPorClienteSACForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        WindowState = FormWindowState.Maximized
    End Sub

#Region "Variables Globales"
    Private ReadOnly OBJBU As New Negocios.inventarioBU
    Private ReadOnly LST_INICIAL As New List(Of String)
    Private LST_PEDIDO_SAY As New List(Of String)
    Private ESTATUS_PROYECTADO As Boolean
    Private ESTATUS_DISPONIBLE As Boolean
    Private ESTATUS_RESERVADO As Boolean
    Private ESTATUS_TERMINADO As Boolean
    Private ESTATUS_PROGRAMA As Boolean
    Private ESTATUS_PROCESO As Boolean
    Private ESTATUS_REPROCESO As Boolean
#End Region

#Region "Eventos Panel Encabezado"

    Private Sub BtnExportarInventarioProceso_Click(sender As Object, e As EventArgs) Handles btnExportarInventarioProceso.Click
        Cursor = Cursors.WaitCursor

        Select Case cbxTipoReporte.SelectedIndex
            Case 1
                If chkMostrarFotografia.Checked = True Then
                    ExportarImagen()
                Else
                    ExportarExcel("\ReporteInventarioPorClienteDetallado_")
                End If
            Case 2
                ExportarExcel("\ReporteInventarioPorFamilia_")

            Case 3
                If chkMostrarFotografia.Checked = True Then
                    ExportarImagen()
                Else
                    ExportarExcel("\ReporteInventarioPorClienteDetallado_Pedido_")
                End If

            Case 4
                If chkMostrarFotografia.Checked = True Then
                    ExportarImagen()
                Else
                    ExportarExcel("\ReporteInventarioPorClienteDetallado_Pedido_Partida_")
                End If

            Case Else
                ExportarExcel("\ReporteInventarioPorCliente_")

        End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub ExportarImagen()

        If vwClientepares.DataRowCount > 0 Then
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

                    Dim Total As Integer = 0
                    Dim Cont As Integer = 0
                    Dim inicio As Integer = 0

                    pBar.Maximum = Total
                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()





                    For i As Int16 = 0 To vwClientepares.Columns.Count - 1
                        If vwClientepares.Columns(i).FieldName.ToString() <> "Foto" Then
                            worksheet.Rows.Item(0).Cells.Item(i + 1).Value = vwClientepares.Columns(i).FieldName.ToString()
                        Else
                            worksheet.Rows.Item(0).Cells.Item(0).Value = "Foto"
                        End If

                        worksheet.Rows(0).Cells(i).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSkyBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(0).Cells(i).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(0).Cells(i).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(0).Cells(i).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                        If vwClientepares.Columns(i).FieldName.ToString() = "Foto" Then
                            worksheet.Columns.Item(0).Width = 3650  'Foto
                        End If

                        If vwClientepares.Columns(i).FieldName.ToString() = "Cliente" Then
                            worksheet.Columns.Item(i + 1).Width = 9650  'Foto
                        End If

                        If vwClientepares.Columns(i).FieldName.ToString() = "ModeloSAY" Then
                            worksheet.Columns.Item(i + 1).Width = 3650  'Foto
                        End If

                        If vwClientepares.Columns(i).FieldName.ToString() = "ModeloSICY" Then
                            worksheet.Columns.Item(i + 1).Width = 3650  'Foto
                        End If

                        If vwClientepares.Columns(i).FieldName.ToString() = "Articulo" Then
                            worksheet.Columns.Item(i + 1).Width = 14650  'Foto
                        End If




                    Next





                    For r As Integer = 0 To vwClientepares.RowCount - 1 'grdCatalogo.Rows.Count - 1
                        ' worksheet.Rows.Item(r + inicio + 1).Height = 1505 '1145

                        For i As Int16 = 0 To vwClientepares.Columns.Count - 1
                            If vwClientepares.Columns(i).FieldName <> "Foto" Then
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(i + 1).Value = vwClientepares.GetRowCellValue(r, vwClientepares.Columns(i).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Height = 1505
                            End If


                            ' worksheet.Rows.Item(0).Cells.Item(i).Value = vwClientepares.Columns(i).FieldName.ToString()
                        Next



                        If Not IsDBNull(vwClientepares.GetRowCellValue(r, vwClientepares.Columns("Foto").FieldName.ToString())) Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then
                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(vwClientepares.GetRowCellValue(r, vwClientepares.Columns("Foto").FieldName.ToString()))

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

#End Region

#Region "Eventos Panel Parametros"

#Region "Eventos Estatus"

    Private Sub GrdEstatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatus.InitializeLayout
        DiseñoFiltro(grdEstatus)
        grdEstatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    End Sub

    Private Sub GrdEstatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEstatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnEstatus_Click(sender As Object, e As EventArgs) Handles btnEstatus.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 1
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
        End With
    End Sub

    Private Sub BtnLimpiarFiltroEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEstatus.Click
        grdEstatus.DataSource = LST_INICIAL
    End Sub

#End Region

#Region "Eventos Cliente"

    Private Sub GrdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        DiseñoFiltro(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub GrdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 2
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdClientes.DataSource = filtroReporte.LST_PARAMETROS
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Familia"

    Private Sub GrdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        DiseñoFiltro(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub GrdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
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

    Private Sub BtnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilias.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Piel"

    Private Sub GrdPieles_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPieles.InitializeLayout
        DiseñoFiltro(grdPieles)
        grdPieles.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel"
    End Sub

    Private Sub GrdPieles_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdPieles.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnPiel_Click(sender As Object, e As EventArgs) Handles btnPiel.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 4
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdPieles.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdPieles.DataSource = filtroReporte.LST_PARAMETROS
        With grdPieles
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroPiel_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPiel.Click
        grdPieles.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Coleccion"

    Private Sub GrdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        DiseñoFiltro(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Coleccion"
    End Sub

    Private Sub GrdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColecciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
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

    Private Sub BtnLimpiarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColeccion.Click
        grdColecciones.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Color"

    Private Sub GrdColores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColores.InitializeLayout
        DiseñoFiltro(grdColores)
        grdColores.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Color"
    End Sub

    Private Sub GrdColores_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColores.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 6
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdColores.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdColores.DataSource = filtroReporte.LST_PARAMETROS
        With grdColores
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColor.Click
        grdColores.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Modelo"

    Private Sub GrdModelos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelos.InitializeLayout
        DiseñoFiltro(grdModelos)
        grdModelos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub GrdModelos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdModelos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnLimpiarFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroModelo.Click
        grdModelos.DataSource = Nothing
        LST_PEDIDO_SAY.Clear()
    End Sub

    Private Sub TextEdit1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtModelo.Text) Then Return

            LST_PEDIDO_SAY.Add(txtModelo.Text)
            grdModelos.DataSource = Nothing
            grdModelos.DataSource = LST_PEDIDO_SAY

            txtModelo.Text = String.Empty

        End If
    End Sub

#End Region

#Region "Eventos Corrida"

    Private Sub GrdCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorridas.InitializeLayout
        DiseñoFiltro(grdCorridas)
        grdCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub GrdCorridas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCorridas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 7
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdCorridas.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdCorridas.DataSource = filtroReporte.LST_PARAMETROS
        With grdCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCorrida.Click
        grdCorridas.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos Flechas"

    Private Sub BtnCerrarParametros_Click(sender As Object, e As EventArgs) Handles BtnCerrarParametros.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub BtnAbrirParametros_Click(sender As Object, e As EventArgs) Handles BtnAbrirParametros.Click
        pnlParametros.Height = 215
    End Sub

#End Region

#Region "Eventos Tipo Categoria"

    Private Sub CbxTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoReporte.SelectedIndexChanged
        'LST_PEDIDO_SAY.Clear()

        If cbxTipoReporte.SelectedIndex = 2 Then
            rbFamiliaBota.Visible = True
            rbFamiliaEscolar.Visible = True
            rbFamiliaEscolar.Checked = True
            rbFamiliaSandalia.Visible = True
            grpboxTipoReporte.Size = New Size(252, 66)
        Else
            rbFamiliaBota.Visible = False
            rbFamiliaEscolar.Visible = False
            rbFamiliaSandalia.Visible = False
            grpboxTipoReporte.Size = New Size(252, 55)
        End If
    End Sub

#End Region

#End Region

#Region "Eventos Panel Pie"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim totalPares As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            Dim datos As New DataTable

            Dim FiltroEstatus As String = ObtenerFiltrosGrid(grdEstatus)
            Dim FiltroCliente As String = ObtenerFiltrosGrid(grdClientes)
            Dim FiltroFamilia As String = ObtenerFiltrosGrid(grdFamilias)
            Dim FiltroPiel As String = ObtenerFiltrosGrid(grdPieles)
            Dim FiltroColeccion As String = ObtenerFiltrosGrid(grdColecciones)
            Dim FiltroColor As String = ObtenerFiltrosGrid(grdColores)
            Dim FiltroModelo As String = ObtenerFiltrosGrid(grdModelos)
            Dim FiltroCorrida As String = ObtenerFiltrosGrid(grdCorridas)

            pnPBar.Visible = True
            lblInfo.Text = "Ejecutando consulta...."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            System.Windows.Forms.Application.DoEvents()

            Select Case cbxTipoReporte.SelectedIndex
                Case 1
                    datos = OBJBU.ConsultarParesPorClienteDetalles(ESTATUS_PROGRAMA, ESTATUS_PROCESO, ESTATUS_TERMINADO, ESTATUS_DISPONIBLE, ESTATUS_RESERVADO, ESTATUS_PROYECTADO,
                                                                   FiltroCliente, FiltroFamilia, FiltroModelo, FiltroPiel, FiltroColor, FiltroCorrida, ESTATUS_REPROCESO, FiltroColeccion)


                    If chkMostrarFotografia.Checked = True Then
                        MostrarImgen(datos)
                    Else
                        grdClientepares.DataSource = Nothing
                        vwClientepares.Columns.Clear()
                        grdClientepares.DataSource = datos
                        DiseñoGrid.DiseñoBaseGrid(vwClientepares)
                        vwClientepares.IndicatorWidth = 35
                        vwClientepares.RowHeight = 20
                        vwClientepares.Columns("FotoModelo").Visible = False
                    End If


                    For Each col As Columns.GridColumn In vwClientepares.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                        col.OptionsColumn.AllowEdit = False
                        If (col.FieldName <> "Cliente" And col.FieldName <> "ModeloSAY" And col.FieldName <> "ModeloSYCY" And col.FieldName <> "Corrida" And col.FieldName <> "Articulo" And col.FieldName <> "Foto") Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "{0:n0}"
                            col.Width = 50
                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                        End If
                    Next
                    DiseñoGrid.EstiloColumna(vwClientepares, "Cliente", "Cliente", True, Columns.AutoFilterCondition.Contains, False, False, 200, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "ModeloSAY", "Modelo SAY", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "ModeloSICY", "Modelo SYCY", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    If chkMostrarFotografia.Checked = True Then
                        DiseñoGrid.EstiloColumna(vwClientepares, "Foto", "Foto", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    End If

                    DiseñoGrid.EstiloColumna(vwClientepares, "Total Pares", "Total de Pares", True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

                    For index = 0 To datos.Rows.Count - 1
                        totalPares += Integer.Parse(datos.Rows(index)("Total Pares").ToString)
                    Next

                Case 2
                    datos = OBJBU.ConsultarParesClientePorFamilia(ESTATUS_PROGRAMA, ESTATUS_PROCESO, ESTATUS_TERMINADO, ESTATUS_DISPONIBLE, ESTATUS_RESERVADO, ESTATUS_PROYECTADO,
                                                                  FiltroCliente, FiltroFamilia, FiltroModelo, FiltroPiel, FiltroColor, FiltroCorrida,
                                                                  rbFamiliaEscolar.Checked, rbFamiliaBota.Checked, rbFamiliaSandalia.Checked, ESTATUS_REPROCESO, FiltroColeccion)
                    grdClientepares.DataSource = Nothing
                    vwClientepares.Columns.Clear()
                    grdClientepares.DataSource = datos
                    DiseñoGrid.DiseñoBaseGrid(vwClientepares)
                    vwClientepares.IndicatorWidth = 35
                    vwClientepares.OptionsView.ColumnAutoWidth = False
                    Dim familias As DataTable = OBJBU.familias()
                    For Each col As Columns.GridColumn In vwClientepares.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                        col.OptionsColumn.AllowEdit = False
                        If (col.FieldName <> "Cliente") Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "{0:n0}"
                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                        End If
                    Next
                    For index = 0 To familias.Rows.Count - 1
                        DiseñoGrid.EstiloColumna(vwClientepares, familias.Rows(index)("Familia").ToString(), familias.Rows(index)("Familia").ToString(), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                        DiseñoGrid.EstiloColumna(vwClientepares, "Total Pares", "Total de Pares", True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                    Next
                    For index = 0 To datos.Rows.Count - 1
                        totalPares += Integer.Parse(datos.Rows(index)("Total Pares").ToString)
                    Next

                Case 3
                    datos = OBJBU.ConsultarParesPorClienteDetallesPedido(ESTATUS_PROGRAMA, ESTATUS_PROCESO, ESTATUS_TERMINADO, ESTATUS_DISPONIBLE, ESTATUS_RESERVADO, ESTATUS_PROYECTADO,
                                                                         FiltroCliente, FiltroFamilia, FiltroModelo, FiltroPiel, FiltroColor, FiltroCorrida, ESTATUS_REPROCESO, FiltroColeccion)

                    If chkMostrarFotografia.Checked = True Then
                        MostrarImgen(datos)
                    Else
                        grdClientepares.DataSource = Nothing
                        vwClientepares.Columns.Clear()
                        grdClientepares.DataSource = datos
                        DiseñoGrid.DiseñoBaseGrid(vwClientepares)
                        vwClientepares.IndicatorWidth = 35
                        vwClientepares.RowHeight = 20
                        vwClientepares.Columns("FotoModelo").Visible = False
                    End If

                    For Each col As Columns.GridColumn In vwClientepares.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                        col.OptionsColumn.AllowEdit = False
                        If (col.FieldName <> "Cliente" And col.FieldName <> "ModeloSAY" And col.FieldName <> "Corrida" And col.FieldName <> "Articulo" And col.FieldName <> "PedidoSAY" And col.FieldName <> "PedidoSICY" And col.FieldName <> "Foto") Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "{0:n0}"
                            col.Width = 50
                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                        End If
                    Next
                    DiseñoGrid.EstiloColumna(vwClientepares, "Cliente", "Cliente", True, Columns.AutoFilterCondition.Contains, False, False, 200, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "ModeloSAY", "Modelo SAY", True, Columns.AutoFilterCondition.Contains, False, False, 75, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "PedidoSAY", "Pedido SAY", True, Columns.AutoFilterCondition.Contains, False, False, 50, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "PedidoSICY", "Pedido SICY", True, Columns.AutoFilterCondition.Contains, False, False, 50, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "Total Pares", "Total de Pares", True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                    If chkMostrarFotografia.Checked = True Then
                        DiseñoGrid.EstiloColumna(vwClientepares, "Foto", "Foto", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    End If
                    For index = 0 To datos.Rows.Count - 1
                        totalPares += Integer.Parse(datos.Rows(index)("Total Pares").ToString)
                    Next

                Case 4
                    datos = OBJBU.ConsultarParesPorClienteDetallesPedidoPartida(ESTATUS_PROGRAMA, ESTATUS_PROCESO, ESTATUS_TERMINADO, ESTATUS_DISPONIBLE, ESTATUS_RESERVADO, ESTATUS_PROYECTADO,
                                                                                FiltroCliente, FiltroFamilia, FiltroModelo, FiltroPiel, FiltroColor, FiltroCorrida, ESTATUS_REPROCESO, FiltroColeccion)

                    If chkMostrarFotografia.Checked = True Then
                        MostrarImgen(datos)
                    Else
                        grdClientepares.DataSource = Nothing
                        vwClientepares.Columns.Clear()
                        grdClientepares.DataSource = datos
                        DiseñoGrid.DiseñoBaseGrid(vwClientepares)
                        vwClientepares.IndicatorWidth = 35
                        vwClientepares.RowHeight = 20
                        vwClientepares.Columns("FotoModelo").Visible = False
                    End If

                    For Each col As Columns.GridColumn In vwClientepares.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                        col.OptionsColumn.AllowEdit = False
                        If (col.FieldName <> "Cliente" And col.FieldName <> "ModeloSAY" And col.FieldName <> "Corrida" And col.FieldName <> "Articulo" And col.FieldName <> "PedidoSAY" And col.FieldName <> "PedidoSICY" And col.FieldName <> "Partida" And col.FieldName <> "Foto") Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "{0:n0}"
                            col.Width = 50
                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                        End If
                    Next
                    DiseñoGrid.EstiloColumna(vwClientepares, "Cliente", "Cliente", True, Columns.AutoFilterCondition.Contains, False, False, 200, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "Partida", "Partida", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "ModeloSAY", "Modelo SAY", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "PedidoSAY", "Pedido SAY", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "PedidoSICY", "Pedido SICY", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "Estatus", "Estatus", False, Columns.AutoFilterCondition.Contains, False, False, 200, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "Total Pares", "Total de Pares", True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

                    If chkMostrarFotografia.Checked = True Then
                        DiseñoGrid.EstiloColumna(vwClientepares, "Foto", "Foto", True, Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
                    End If
                    For index = 0 To datos.Rows.Count - 1
                        totalPares += Integer.Parse(datos.Rows(index)("Total Pares").ToString)
                    Next

                Case Else
                    datos = OBJBU.ConsultarParesPorCliente(ESTATUS_PROGRAMA, ESTATUS_PROCESO, ESTATUS_TERMINADO, ESTATUS_DISPONIBLE, ESTATUS_RESERVADO, ESTATUS_PROYECTADO,
                                                           FiltroCliente, FiltroFamilia, FiltroModelo, FiltroPiel, FiltroColor, FiltroCorrida, ESTATUS_REPROCESO, FiltroColeccion)
                    grdClientepares.DataSource = Nothing
                    vwClientepares.Columns.Clear()

                    grdClientepares.DataSource = datos
                    DiseñoGrid.DiseñoBaseGrid(vwClientepares)
                    vwClientepares.IndicatorWidth = 35
                    For Each col As Columns.GridColumn In vwClientepares.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                        col.OptionsColumn.AllowEdit = False
                        If (col.FieldName <> "Cliente") Then
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "{0:n0}"
                            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                        End If
                    Next
                    vwClientepares.OptionsView.ColumnAutoWidth = True
                    DiseñoGrid.EstiloColumna(vwClientepares, "Nombre", "Cliente", True, Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                    DiseñoGrid.EstiloColumna(vwClientepares, "Pares", "Total de Pares", True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

                    For index = 0 To datos.Rows.Count - 1
                        totalPares += Integer.Parse(datos.Rows(index)("Pares").ToString)
                    Next

            End Select





            ESTATUS_PROYECTADO = False
            ESTATUS_DISPONIBLE = False
            ESTATUS_RESERVADO = False
            ESTATUS_TERMINADO = False
            ESTATUS_PROGRAMA = False
            ESTATUS_PROCESO = False
            ESTATUS_REPROCESO = False

            lblTotalParesProceso.Text = String.Format("{0:N0}", totalPares)

            If cbxTipoReporte.SelectedIndex = 4 Then
                If Not FiltroCliente.Equals("") And Not FiltroColeccion.Equals("") And Not FiltroColor.Equals("") And Not FiltroCorrida.Equals("") And Not FiltroFamilia.Equals("") And Not FiltroModelo.Equals("") And Not FiltroPiel.Equals("") Then
                    lblTotalParesProceso.Text = String.Format("{0:N0}", totalPares - 12)
                Else
                    lblTotalParesProceso.Text = String.Format("{0:N0}", totalPares)
                End If
            Else
                lblTotalParesProceso.Text = String.Format("{0:N0}", totalPares)
            End If

            'lblTotalParesProceso.Text = datos.Rows.Count

            lblFechaUltimaActualizacion.Text = Date.Now
            Cursor = Cursors.Default

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        Finally
            Me.Cursor = Cursors.Default
            pBar.Value = pBar.Minimum
            pnPBar.Visible = False
            request = Nothing
            StreamFoto = Nothing
            image = Nothing
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Inicializar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Function MostrarImgen(ByVal Datos As DataTable) As DataTable

        If Datos.Rows.Count > 0 Then
            Datos.Columns.Add("Foto", GetType(Image))
            Dim Total As Integer = Datos.Rows.Count
            Dim Cont As Integer = 0

            pBar.Maximum = Total

            lblInfo.Text = "Descargando imágenes...."

            'If chkVerFotografia.Checked Then
            '    lblInfo.Text = "Descargando imágenes...."
            'Else
            '    lblInfo.Text = "Espere un momento por favor..."
            'End If


            System.Windows.Forms.Application.DoEvents()
            Dim imagen As Image
            For Each row As DataRow In Datos.Rows
                ruta = IIf(IsDBNull(row.Item("FotoModelo")), "", row.Item("FotoModelo").ToString.Trim)
                If ruta.Length > 0 Then
                    Try
                        image = Nothing
                        'StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
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



            grdClientepares.DataSource = Nothing
            vwClientepares.Columns.Clear()
            grdClientepares.DataSource = Datos
            DiseñoGrid.DiseñoBaseGrid(vwClientepares)
            vwClientepares.IndicatorWidth = 35

            vwClientepares.Columns("Foto").VisibleIndex = 1
            vwClientepares.ColumnPanelRowHeight = 30
            vwClientepares.RowHeight = 50



            vwClientepares.Columns("FotoModelo").Visible = False
            vwClientepares.RowHeight = 50
            System.Windows.Forms.Application.DoEvents()

            'grdClientepares.DataSource = dtReporte
            'disenioGrig()
            'panelArriba_Click(Nothing, Nothing)
            'System.Windows.Forms.Application.DoEvents()
            'lblTotalRegistros.Text = grdVWConsulta.DataRowCount.ToString("n0")

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros en la consulta.")
            ' lblTotalRegistros.Text = "0"
        End If

        Return Datos

    End Function

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()
        cbxTipoReporte.SelectedIndex = 0
        rbFamiliaEscolar.Checked = True
        rbFamiliaBota.Checked = False
        rbFamiliaSandalia.Checked = False

        grdClientepares.DataSource = Nothing
        vwClientepares.Columns.Clear()

        grdEstatus.DataSource = LST_INICIAL
        grdClientes.DataSource = LST_INICIAL
        grdPieles.DataSource = LST_INICIAL
        grdFamilias.DataSource = LST_INICIAL
        grdColores.DataSource = LST_INICIAL
        grdCorridas.DataSource = LST_INICIAL
        grdModelos.DataSource = LST_INICIAL
        grdColecciones.DataSource = LST_INICIAL

        ESTATUS_PROGRAMA = False
        ESTATUS_PROCESO = False
        ESTATUS_DISPONIBLE = False
        ESTATUS_TERMINADO = False
        ESTATUS_RESERVADO = False
        ESTATUS_PROYECTADO = False
        ESTATUS_REPROCESO = False

        lblTotalParesProceso.Text = "-"
        lblFechaUltimaActualizacion.Text = "-"
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

    Private Sub ExportarExcel(mensaje As String)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        If vwClientepares.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf ExportOptions_CustomizeCell
                    exportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG
                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwClientepares.GroupCount > 0 Then
                            grdClientepares.ExportToXlsx(.SelectedPath + mensaje + fecha_hora + ".xlsx", exportOptions)
                        Else
                            grdClientepares.ExportToXlsx(.SelectedPath + mensaje + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & mensaje & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + mensaje + fecha_hora + ".xlsx")
                    End If
                End With

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos que exportar")
        End If
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        If Not grid.Name.Equals("grdEstatus") Then
            If Not grid.Name.Equals("grdModelos") Then
                For Each row As UltraGridRow In grid.Rows
                    If row.Index = 0 Then
                        Resultado += row.Cells(0).Text
                    Else
                        Resultado += "," + row.Cells(0).Text
                    End If
                Next
            Else
                For Each row As UltraGridRow In grid.Rows
                    If row.Index = 0 Then
                        Resultado += "'" + row.Cells(0).Text + "'"
                    Else
                        Resultado += ",'" + row.Cells(0).Text + "'"
                    End If
                Next
            End If
        Else
            If grid.Rows.Count > 0 Then
                For Each row As UltraGridRow In grid.Rows
                    If row.Cells(0).Value Then
                        Select Case row.Cells(1).Value
                            Case "PROYECTADO"
                                ESTATUS_PROYECTADO = True

                            Case "DISPONIBLE"
                                ESTATUS_DISPONIBLE = True

                            Case "TERMINADO"
                                ESTATUS_TERMINADO = True

                            Case "RESERVADO"
                                ESTATUS_RESERVADO = True

                            Case "PROCESO"
                                ESTATUS_PROCESO = True

                            Case "PROGRAMADO / POR PROGRAMAR"
                                ESTATUS_PROGRAMA = True
                            Case "REPROCESO"
                                ESTATUS_REPROCESO = True

                        End Select
                    End If
                Next
            Else
                ESTATUS_PROYECTADO = True
                ESTATUS_DISPONIBLE = True
                ESTATUS_RESERVADO = True
                ESTATUS_TERMINADO = True
                ESTATUS_PROGRAMA = True
                ESTATUS_PROCESO = True
                ESTATUS_REPROCESO = True
            End If
        End If

        Return Resultado
    End Function

    Private Sub ExportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


    End Sub

    Private Sub VwClientepares_RowStyle(sender As Object, e As RowStyleEventArgs) Handles vwClientepares.RowStyle
        If cbxTipoReporte.SelectedIndex = 4 Then
            Dim view As GridView = DirectCast(sender, GridView)
            If Not vwClientepares.IsValidRowHandle(e.RowHandle) Then
                Return
            End If
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = view.Columns.ColumnByFieldName("Estatus")
            If Not view.GetRowCellValue(e.RowHandle, Col) = Nothing Then
                If view.GetRowCellValue(e.RowHandle, Col).ToString = "DESASIGNACION" Then
                    e.Appearance.BackColor = Color.Red
                    e.HighPriority = True
                    'Else
                    '    e.Appearance.BackColor = DefaultBackColor
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub VwClientepares_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwClientepares.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "Manual de Usuario Ajuste reporte de inventario v1.pdf")
            Process.Start("Descargas\Manuales\Ventas\Manual de Usuario Ajuste reporte de inventario v1.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub vwClientepares_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles vwClientepares.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = vwClientepares.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = vwClientepares.GetRowCellValue(e.RowHandle, "Articulo")
                'MostrarFoto.Coleccion = vwClientepares.GetRowCellValue(e.RowHandle, "Coleccion")
                'MostrarFoto.ModeloSicy = vwClientepares.GetRowCellValue(e.RowHandle, "ModeloSAY")
                'MostrarFoto.ModleoSay = bgvReporte.GetRowCellValue(e.RowHandle, "ModeloSay")
                'MostrarFoto.Talla = bgvReporte.GetRowCellValue(e.RowHandle, "Corrida")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

#End Region

End Class