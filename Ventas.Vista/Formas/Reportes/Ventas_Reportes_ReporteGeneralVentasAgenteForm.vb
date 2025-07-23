Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report
Imports System.Threading

Public Class Ventas_Reportes_ReporteGeneralVentasAgenteForm

    Dim lstInicialFamilia As New List(Of String)
    Dim vFiltroFechaInicio As String = String.Empty
    Dim vFiltroFechaFin As String = String.Empty
    Dim vFiltroAgente As Integer = 0
    Dim vFiltroFamiliaId As String = String.Empty
    Dim dtResultadoConsulta As New DataTable
    Dim dtAgentes As New DataTable
    Dim vNombreArchivoExporta As String = String.Empty

    Private grdAgenteVentas As New DataTable

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 160
    End Sub

    Private Sub Ventas_Reportes_ReporteGeneralVentasAgenteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        grdFamilias.DataSource = lstInicialFamilia
        dtpFechaDe.MinDate = "01/01/2018"
        dtpFechaA.MaxDate = "31/12/" + dtpFechaDe.Value.Year.ToString()

        CargaComboAgente()
        cmbTipoReporte.SelectedIndex = 0

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_CONSVTAS_REPORTEGENERALVENTAS", "REPORTE_GENERAL_AGENTE") Then
            AvanceDeCumplimientoDeProyecciónDeVentasPorAgenteToolStripMenuItem.Visible = False
        End If


    End Sub

#Region "FILTROS"
    Private Sub grdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        grid_diseño(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub grdFamilias_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamilias.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilias.DeleteSelectedRows(False)
    End Sub

    Private Sub btnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 21
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamilias.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilias.DataSource = listado.listParametros

        With grdFamilias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
        End With
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

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
                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub


    Private Sub obtenerFiltros()

        vFiltroFamiliaId = Nothing

        vFiltroAgente = If(cmbAgente.SelectedIndex >= 0, cmbAgente.SelectedValue, 0)
        vFiltroFechaInicio = dtpFechaDe.Value
        vFiltroFechaFin = dtpFechaA.Value

        For Each Row As UltraGridRow In grdFamilias.Rows
            If vFiltroFamiliaId <> Nothing Then
                vFiltroFamiliaId += ","
            End If
            vFiltroFamiliaId += Row.Cells("Parametro").Value.ToString()
        Next
    End Sub

    Private Sub btnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilias.DataSource = lstInicialFamilia
    End Sub

#End Region

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = vNombreArchivoExporta
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Advertencia", "No se encontro el archivo")
        End Try
    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim vValor As Integer = 0
        Dim vPed As String
        Dim vProy As String
        Dim vNumDividir As Decimal
        Dim vNumDividir2 As Decimal
        Dim vTotal As Integer

        If e.RowHandle >= 0 Then
            If e.ColumnFieldName.Contains("%CUM") Then
                If IsNumeric(e.Value) Then
                    e.Formatting.BackColor = ObtenerColorCumplimiento(e.Value)
                    e.Formatting.Font.Color = ObtenerColorCumplimientoTexto(e.Value)
                Else
                    vPed = e.ColumnFieldName.Replace("%CUM", "PED")
                    vProy = e.ColumnFieldName.Replace("%CUM", "PROY")
                    vNumDividir = (From x In dtResultadoConsulta.AsEnumerable() Select x.Field(Of Decimal)(vPed)).Sum()
                    vNumDividir2 = (From x In dtResultadoConsulta.AsEnumerable() Select x.Field(Of Decimal)(vProy)).Sum()
                    If vNumDividir = 0 Or vNumDividir2 = 0 Then
                        vTotal = 0
                    Else
                        vTotal = CInt((vNumDividir / vNumDividir2) * 100)
                    End If
                    e.Formatting.BackColor = ObtenerColorCumplimiento(vTotal)
                    e.Formatting.Font.Color = ObtenerColorCumplimientoTexto(vTotal)
                    e.Formatting.FormatString = "N0"
                End If
            End If
            e.Formatting.FormatString = "N0"
        End If

        e.Handled = True
    End Sub


    Private Sub cmbTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoReporte.SelectedIndexChanged

        If cmbTipoReporte.Text <> Nothing Then
            Dim vValorSeleccionado As String = cmbTipoReporte.Text
            If vValorSeleccionado = "CUMPLIMIENTO MENSUAL" Then
                chbMostrarPorRuta.Visible = True
                chbMostrarMensuales.Visible = False
            Else
                chbMostrarPorRuta.Visible = False
                chbMostrarMensuales.Visible = True
            End If
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        obtenerReporte()
        Cursor = Cursors.Default
    End Sub

    Private Sub obtenerReporte()
        Dim vTipo As String = cmbTipoReporte.Text
        Dim vMostrarMensuales As Boolean = chbMostrarMensuales.Checked
        Dim objVentasBU As New Ventas.Negocios.ReporteGeneralVentasAgenteBU
        Dim vSpid As Integer = 0
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()
        vNombreArchivoExporta = String.Empty

        obtenerFiltros()

        Select Case vTipo
            Case "CUATRIMESTRAL"
                If chbMostrarMensuales.Checked = False Then
                    dtResultadoConsulta = objVentasBU.obtenerReporteCuatrimestral(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo
                Else
                    dtResultadoConsulta = objVentasBU.obtenerReporteCuatrimestralMensual(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo + " MENSUAL"
                End If

            Case "RESUMEN POR RUTA"
                If chbMostrarMensuales.Checked = False Then
                    dtResultadoConsulta = objVentasBU.obtenerReporteResumenRuta(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo
                Else
                    dtResultadoConsulta = objVentasBU.obtenerReporteResumenRutaMensual(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo + " MENSUAL"
                End If

            Case "CUMPLIMIENTO MENSUAL"
                If chbMostrarPorRuta.Checked = False Then
                    dtResultadoConsulta = objVentasBU.obtenerReporteCumplimientoMensual(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo
                Else
                    dtResultadoConsulta = objVentasBU.obtenerReporteCumplimientoMensualRuta(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)
                    vNombreArchivoExporta = vTipo + " POR RUTA"
                End If
        End Select

        If dtResultadoConsulta.Rows.Count > 0 Then

            vSpid = Integer.Parse(dtResultadoConsulta.Rows(0).Item("spid").ToString())
            grdReporte.DataSource = Nothing
            diseñoGridCuatrimestral(vSpid)
            grdReporte.DataSource = dtResultadoConsulta
            reporteCuatrimestralTotales()
            btnArriba_Click(Nothing, Nothing)
        Else
            show_message("Advertencia", "No hay datos para mostrar")

        End If

    End Sub

    Private Sub diseñoGridCuatrimestral(ByVal pSpid As Integer)
        Dim objVentasBu As New Ventas.Negocios.ReporteGeneralVentasAgenteBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim lstBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim dtEncabezados As New System.Data.DataTable
        Dim BAND2 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim vNombreColumna As String = String.Empty
        'Dim vNombreBand2 As String = Nothing

        dtEncabezados = objVentasBu.obtenerEncabezadosReporte(pSpid)
        vwReporte.Columns.Clear()
        vwReporte.Bands.Clear()
        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False
        vwReporte.Appearance.HeaderPanel.Options.UseBackColor = True
        vwReporte.OptionsView.AllowCellMerge = True

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("FAMILIA").ToString()) = False Then
                listBandsTextos.Add(row.Item("FAMILIA").ToString())
                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("FAMILIA").ToString()
                'vNombreBand2 = Nothing
                listBands.Add(band)
            End If

            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If row("FAMILIA").ToString() = gridBand.Caption Then

                    BAND2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                    BAND2.Caption = row.Item("PRIMER_NIVEL").ToString().ToUpper
                    Dim vChildren As Boolean = True

                    For Each vChildrenItem In gridBand.Children
                        If vChildrenItem.ToString() = BAND2.Caption Then
                            vChildren = False
                        End If
                    Next

                    If vChildren = True Then
                        gridBand.Children.Add(BAND2)
                    End If

                    'If vNombreBand2 <> BAND2.Caption Then
                    '    gridBand.Children.Add(BAND2)
                    'End If

                    For Each childrenBand In gridBand.Children
                        vwReporte.Columns.AddField(row.Item("TIPO").ToString().ToUpper)
                        If row.Item("TIPO").ToString().ToUpper <> "" Then
                            If row.Item("TIPO").ToString().ToUpper.Contains(childrenBand.Caption) Then
                                vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).OwnerBand = childrenBand
                                vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).Visible = True
                                vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).OptionsColumn.AllowEdit = False
                                If row.Item("TIPO").ToString().ToUpper <> "CIUDAD" And row.Item("TIPO").ToString().ToUpper <> "EDO" And row.Item("TIPO").ToString().ToUpper <> "CLASIF" And row.Item("TIPO").ToString().ToUpper <> "TDAS" Then
                                    vNombreColumna = Split(row.Item("TIPO").ToString().ToUpper, "-")(2)
                                    vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).Caption = vNombreColumna
                                    vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).DisplayFormat.FormatString = "N0"
                                End If
                                If row.Item("TIPO").ToString().ToUpper <> "COLUMNA FIJA-COLUMNA FIJA-RUTA" Then
                                    vwReporte.Columns.ColumnByFieldName(row.Item("TIPO").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            'vNombreBand2 = BAND2.Caption
        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            vwReporte.Bands.Add(gridBand)
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If Col.FieldName = "COLUMNA FIJA-COLUMNA FIJA-RUTA" Then
                Col.Width = 150
            End If
            If Col.FieldName = "COLUMNA FIJA-COLUMNA FIJA-CLIENTE" Then
                Col.Width = 250
            End If
            If Col.FieldName = "F-PN-CIUDAD" Then
                Col.Width = 180
            End If
            If Col.FieldName = "F-PN-EDO" Then
                Col.Width = 45
            End If
            If Col.FieldName = "F-PN-CLASIF" Then
                Col.Width = 50
            End If
            If Col.FieldName = "F-PN-TDAS" Then
                Col.Width = 45
            End If
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwReporte.Bands

            If gridband.Caption = "COLUMNA FIJA" Then
                gridband.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End If

            If gridband.Caption = "COLUMNA FIJA" Or gridband.Caption = "F" Then
                gridband.Caption = ""
            End If

            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                If childrenBand.Caption = "COLUMNA FIJA" Or childrenBand.Caption = "GENERAL" Or childrenBand.Caption = "PN" Then
                    childrenBand.Caption = ""
                End If
            Next
        Next
    End Sub

    Private Sub reporteCuatrimestralTotales()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporte.Columns
            If vColumna.Caption = "PED" Or vColumna.Caption = "PROY" Or vColumna.Caption = "PARTIC" Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If

            If vColumna.Caption.Contains("%CUM") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If
        Next
    End Sub

    Private Sub dtpFechaDe_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDe.ValueChanged
        'dtpFechaA.MaxDate = "31/12/" + dtpFechaDe.Value.Year.ToString()
        'dtpFechaA.MinDate = dtpFechaDe.Value


        If dtpFechaA.MinDate > "31/12/" + dtpFechaDe.Value.Year.ToString() Then
            dtpFechaA.MinDate = dtpFechaDe.Value
            dtpFechaA.MaxDate = "31/12/" + dtpFechaDe.Value.Year.ToString()
        Else
            dtpFechaA.MaxDate = "31/12/" + dtpFechaDe.Value.Year.ToString()
            dtpFechaA.MinDate = dtpFechaDe.Value
        End If
    End Sub

#Region "Diseño"

    Private Sub vwReporte_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles vwReporte.CustomDrawCell
        Cursor = Cursors.WaitCursor
        If e.RowHandle >= 0 Then
            If e.Column.FieldName.Contains("%CUM") Then
                e.Appearance.BackColor = ObtenerColorCumplimiento(e.CellValue)
                e.Appearance.ForeColor = ObtenerColorCumplimientoTexto(e.CellValue)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function ObtenerColorCumplimientoTexto(ByVal pPorcentajeCumplimiento As Integer) As Color
        Dim vColor As Color

        If pPorcentajeCumplimiento < 100 Then
            vColor = Color.Red
        ElseIf pPorcentajeCumplimiento >= 100 And pPorcentajeCumplimiento <= 120 Then
            vColor = Color.Green
        ElseIf pPorcentajeCumplimiento > 120 Then
            vColor = Color.Purple
        End If
        Return vColor
    End Function

    Private Function ObtenerColorCumplimiento(ByVal pPorcentajeCumplimiento As Integer) As Color
        Dim vColor As Color

        If pPorcentajeCumplimiento < 100 Then
            vColor = System.Drawing.Color.FromArgb(255, 199, 206)
        ElseIf pPorcentajeCumplimiento >= 100 And pPorcentajeCumplimiento <= 120 Then
            vColor = System.Drawing.Color.FromArgb(198, 239, 206)
        ElseIf pPorcentajeCumplimiento > 120 Then
            vColor = System.Drawing.Color.FromArgb(204, 153, 255)
        End If
        Return vColor
    End Function

    Private Sub vwReporte_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles vwReporte.CustomDrawFooterCell

        Dim dx As Integer = e.Bounds.Height
        Dim r As Rectangle = e.Bounds
        Dim vColor As Color
        'Create a raised or depressed effect for a cell depending on the band index

        If e.Column.FieldName.Contains("%CUM") Then
            If e.Column.SummaryItem.SummaryValue < 100 Then
                vColor = System.Drawing.Color.FromArgb(255, 199, 206)
            ElseIf e.Column.SummaryItem.SummaryValue >= 100 And e.Column.SummaryItem.SummaryValue <= 120 Then
                vColor = System.Drawing.Color.FromArgb(198, 239, 206)
            ElseIf e.Column.SummaryItem.SummaryValue > 120 Then
                vColor = System.Drawing.Color.FromArgb(204, 153, 255)
            End If

            Dim brush As Brush = e.Cache.GetSolidBrush(vColor)
            '  ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner)

            'Fill the inner region of the cell
            r.Inflate(-1, -1)
            e.Graphics.FillRectangle(brush, r)
            'Draw a summary value
            r.Inflate(-2, 0)
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r)
            'Prevent default drawing of the cell
            e.Handled = True
        End If
    End Sub

#End Region

    Private Sub vwReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles vwReporte.CustomSummaryCalculate
        Dim vE As DevExpress.Data.CustomSummaryEventArgs = e
        Dim vPed As String
        Dim vProy As String
        Dim vSpid As Integer = 0
        Dim vNumDividir As Decimal = 0
        Dim vNumDividir2 As Decimal = 0
        Dim vTotal As Decimal = 0

        If dtResultadoConsulta.Rows.Count > 0 Then
            If e.Item.FieldName.Contains("%CUM") Then
                vPed = e.Item.FieldName.Replace("%CUM", "PED")
                vProy = e.Item.FieldName.Replace("%CUM", "PROY")
                vNumDividir = (From x In dtResultadoConsulta.AsEnumerable() Select x.Field(Of Decimal)(vPed)).Sum()
                vNumDividir2 = (From x In dtResultadoConsulta.AsEnumerable() Select x.Field(Of Decimal)(vProy)).Sum()

                If vNumDividir = 0 Or vNumDividir2 = 0 Then
                    e.TotalValue = 0
                Else
                    vTotal = ((vNumDividir / vNumDividir2) * 100)
                    e.TotalValue = CInt(vTotal)

                End If
            End If
        End If
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



    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        grdReporte.DataSource = Nothing
        vwReporte.Bands.Clear()
        vwReporte.Columns.Clear()
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()

        grdFamilias.DataSource = lstInicialFamilia

        chbMostrarMensuales.Checked = False
        chbMostrarPorRuta.Checked = False

        btnAbajo_Click(sender, e)

    End Sub

    Private Sub CargaComboAgente()
        Dim objBUCombos As New Negocios.ReporteGeneralVentasAgenteBU

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_CONSVTAS_REPORTEGENERALVENTAS", "REPORTE_GENERAL_AGENTE") Then
            dtAgentes = objBUCombos.obtenerAgentes(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
        Else
            dtAgentes = objBUCombos.obtenerAgentes(Nothing)
        End If

        cmbAgente.DataSource = dtAgentes
        cmbAgente.DisplayMember = "Nombre"
        cmbAgente.ValueMember = "Parametro"
        cmbAgente.SelectedIndex = 0

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_ReporteGeneralVentas_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_ReporteGeneralVentas_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AvanceDeCumplimientoDeProyecciónDeVentasPorAgenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AvanceDeCumplimientoDeProyecciónDeVentasPorAgenteToolStripMenuItem.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 4
        listado.MarcarAgentes = True

        Dim listaParametroID As New List(Of String)
        For Each row In grdAgenteVentas.Rows
            Dim parametro As String = row(0).ToString
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        listado.MarcarRegistrosTodos()

        If Not listado.DialogResult = Windows.Forms.DialogResult.Yes Then

            If listado.listParametros.Rows.Count = 0 Then Return
            grdAgenteVentas = listado.listParametros
            CargarPDF()
        End If
    End Sub

    Private Sub CargarPDF()

        Cursor = Cursors.WaitCursor
        Dim objBU As New Ventas.Negocios.ReporteGeneralVentasAgenteBU
        Dim dsReporteVentas As New DataSet("dsReporteVentas")
        Dim detalleReporte As New DataTable("dtReporteVentas")
        Dim detalleReporteCuatrimestre As New DataTable("dtReporteCuatrimestre")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim agenteVentas As String = String.Empty

        obtenerFiltros()

        For index = 0 To grdAgenteVentas.Rows.Count - 1
            If index = 0 Then
                agenteVentas += " " + Replace(grdAgenteVentas.Rows(index)(0).ToString, ",", "")
            Else
                agenteVentas += ", " + Replace(grdAgenteVentas.Rows(index)(0).ToString, ",", "")
            End If
        Next

        detalleReporte = objBU.obtenerReporteGeneralPDF(vFiltroFechaInicio, vFiltroFechaFin, 0, agenteVentas)
        detalleReporteCuatrimestre = objBU.obtenerCuatrimestre(vFiltroFechaInicio, vFiltroFechaFin)

        detalleReporte.TableName = "dtReporteVentas"
        detalleReporteCuatrimestre.TableName = "dtReporteCuatrimestre"
        dsReporteVentas.Tables.Add(detalleReporte)
        dsReporteVentas.Tables.Add(detalleReporteCuatrimestre)

        EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_GRAL_VTAS_AGTS")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport

        reporte.Load(archivo)
        reporte.Compile()
        reporte("dsReporteVentas") = "dsReporteVentas"
        reporte.Dictionary.Clear()
        reporte("NumSemana") = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        reporte("NbUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        reporte("Año") = dtpFechaDe.Value.Year
        reporte("Fecha") = DateTime.Now.ToString("dd") + " " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(DateTime.Now.Month - 1).ToUpper() + " " + Date.Now.Year.ToString()


        reporte.RegData(dsReporteVentas)
        reporte.Dictionary.Synchronize()
        reporte.Show()

        Cursor = Cursors.Default
    End Sub

    Private Sub SeguimientoDeVentasCuatrimestralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDeVentasCuatrimestralToolStripMenuItem.Click

        Cursor = Cursors.WaitCursor
        Dim objBU As New Ventas.Negocios.ReporteGeneralVentasAgenteBU
        Dim dsEvaluacionNaves As New DataSet("dsReporteVentas")
        Dim detalleEvaluacion As New DataTable("dtReporteVentas")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes

        obtenerFiltros()

        detalleEvaluacion = objBU.obtenerReporteGeneralPDFCuatrimestral(vFiltroAgente, vFiltroFechaInicio, vFiltroFechaFin, vFiltroFamiliaId)

        detalleEvaluacion.TableName = "dtReporteVentas"
        dsEvaluacionNaves.Tables.Add(detalleEvaluacion)


        EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_GRAL_VTAS_AGTS_CTRAL")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport

        reporte.Load(archivo)
        reporte.Compile()
        reporte("dsReporteVentas") = "dsReporteVentas"
        reporte.Dictionary.Clear()
        reporte("NumSemana") = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        reporte("NbUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        reporte("Año") = dtpFechaDe.Value.Year
        reporte("Fecha") = DateTime.Now.ToString("dd") + " " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(DateTime.Now.Month - 1).ToUpper() + " " + Date.Now.Year.ToString()

        reporte("NombreAgente") = cmbAgente.Text

        reporte.RegData(dsEvaluacionNaves)
        reporte.Dictionary.Synchronize()
        reporte.Show()

        Cursor = Cursors.Default

    End Sub

    Private Sub btnImplimirPDF_MouseClick(sender As Object, e As MouseEventArgs) Handles btnImprimirPDF.MouseClick
        cmsReportesPdf.Show(System.Windows.Forms.Control.MousePosition)
    End Sub


End Class