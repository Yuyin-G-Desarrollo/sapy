Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid



Public Class ListaEntradasaAlmacenFrom
    Public Filtros As New Entidades.EntradasAlmacen

    Public lLotes As String
    Public lAtados As String
    Public lPedidos As String

    Public lProductos As String
    Public lClientes As String
    Public lCorridas As String
    Public lTiendas As String
    Public lTallas As String

    Public lNave As String

    Public fechaInicioEntradas As String
    Public fechaTerminoEntradas As String

    Public fechaInicioProgramas As String
    Public fechaTerminoProgramas As String

    Public bY_O As Boolean
    Public filtroFechaPrograma As Boolean
    Public Ubicacion As Boolean
    Public EsPedidoActual As Boolean
    Public EsClienteActual As Boolean


    Private Sub ListaEntradasaAlmacenFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Me.WindowState = 2

        If Ubicacion = False Then
            btnUbicarMapa.Visible = False
            lblUbicarEnMapa.Visible = False
        End If


        PoblarGridEntradas()



    End Sub

    Private Sub PoblarGridEntradas()
        GridView1.Columns.Clear()

        Me.Cursor = Cursors.WaitCursor

        Dim objEntradasBU As New Negocios.EntradaProductoBU
        Dim dtTablaEntradas As New DataTable

        Try
            'dtTablaEntradas = objEntradasBU.RecuperarListaDeSalidas(Ubicacion, lTallas, lLotes, lAtados, lPedidos, lProductos, lClientes, lCorridas, lTiendas, lNave,
            '                                                    fechaInicioEntradas, fechaTerminoEntradas, fechaInicioProgramas,
            '                                                    fechaTerminoProgramas, bY_O, filtroFechaPrograma, EsPedidoActual, EsClienteActual)

            dtTablaEntradas = objEntradasBU.ConsultaEntradasAlmacen(Filtros)
        Catch ex As Exception
            MsgBox("Ocurrio un error:" + ex.Message, MsgBoxStyle.Critical)
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try

        If dtTablaEntradas.Rows.Count = 0 Then
            Dim formaInformacion As New AvisoForm
            formaInformacion.StartPosition = FormStartPosition.CenterScreen
            formaInformacion.mensaje = "No se encontraron registros."
            formaInformacion.ShowDialog()
            Me.Close()
            Return
        Else
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dtTablaEntradas
            diseno_grdidev()

            'gridListaEntradas.DataSource = Nothing
            'gridListaEntradas.DataSource = dtTablaEntradas
        End If

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        PoblarGridEntradas()
    End Sub
    Private Sub diseno_grdidev()

        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.BestFitMaxRowCount = -1

        'GridView1.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        'AddHandler GridView1.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        'GridView1.Columns.Item("#").VisibleIndex = 0

        If Ubicacion = True Then
            GridView1.Columns("Id_Nave").Visible = False
            GridView1.Columns("ID_ESTIBA").Visible = False
            GridView1.Columns("Bahía ID").Visible = False
            GridView1.Columns("Bloque").Visible = False
            GridView1.Columns("Nivel").Visible = False
            GridView1.Columns("Posicion").Visible = False
            GridView1.Columns("Color").Visible = False

        End If
        'GridView1.Columns.ColumnByFieldName("#").Width = 50
        GridView1.Columns.ColumnByFieldName("Tipo").Width = 40
        GridView1.Columns.ColumnByFieldName("D").Width = 10
        GridView1.Columns.ColumnByFieldName("A").Width = 10
        GridView1.Columns.ColumnByFieldName("C").Width = 10
        GridView1.Columns.ColumnByFieldName("B").Width = 10
        GridView1.Columns.ColumnByFieldName("R").Width = 10
        GridView1.Columns.ColumnByFieldName("P").Width = 10
        GridView1.Columns("Id_Nave").Visible = False
        GridView1.Columns.ColumnByFieldName("Tienda").Width = 450
        GridView1.Columns.ColumnByFieldName("Cliente").Width = 450
        GridView1.Columns.ColumnByFieldName("Cliente Origen").Width = 450
        GridView1.Columns.ColumnByFieldName("Fecha Entrada(Con hr.)").Width = 145
        GridView1.Columns.ColumnByFieldName("Fecha Entrada(Con hr.)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"

        With GridView1
            .Columns("Tipo").Visible = False
            .Columns("Proceso").Visible = False
            .Columns("Fecha Entrada(Con hr.)").Visible = False
            .Columns("Folio Salida").Visible = False
            .Columns("Programa").Visible = False
            .Columns("Marca").Visible = False
            .Columns("Piel").Visible = False
            .Columns("Agte").Visible = False
            .Columns("Fecha Entrega").Visible = False
            .Columns("Cliente Origen").Visible = False
            .Columns("Entrega Cliente").Visible = False
        End With



        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = "Prs"
        item.SummaryType = DevExpress.Data.SummaryItemType.Count
        item.DisplayFormat = "Total: {0}"
        GridView1.GroupSummary.Add(item)

        Dim lAtados As New HashSet(Of String)
        Dim lPares As New HashSet(Of String)
        Dim lErrores As New HashSet(Of String)
        Dim lTotales As New HashSet(Of String)

        For i As Integer = 0 To GridView1.DataRowCount - 1
            If GridView1.GetRowCellValue(i, "Tipo") = "P" Then
                ' Your code here
                lPares.Add(GridView1.GetRowCellValue(i, "Par").ToString())

            ElseIf GridView1.GetRowCellValue(i, "Tipo").ToString() = "A" Then
                lAtados.Add(GridView1.GetRowCellValue(i, "Atado").ToString())
            Else
                GridView1.GetRowCellValue(i, "Tipo").ToString()
                lErrores.Add(GridView1.GetRowCellValue(i, "Par").ToString())
            End If
            lTotales.Add(GridView1.GetRowCellValue(i, "Atado").ToString() + "-" + GridView1.GetRowCellValue(i, "Par").ToString())
        Next i
        For i As Integer = 1 To GridView1.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                GridView1.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                GridView1.OptionsView.EnableAppearanceEvenRow = True
                GridView1.Invalidate()
            End If
        Next


        lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
        lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString

        lblPares.Text = lPares.Count.ToString("n0")
        lblAtados.Text = lAtados.Count.ToString("n0")
        lblErroneos.Text = lErrores.Count.ToString("n0")
        lblTotalPares.Text = lTotales.Count.ToString("n0")

        'If row.Cells("Tipo").Text.Equals("P") Then
        '    row.Cells("Tipo").Appearance.BackColor = Color.Khaki
        '    lPares.Add(row.Cells("Par").Text)
        'ElseIf row.Cells("Tipo").Text.Equals("A") Then
        '    row.Cells("Tipo").Appearance.BackColor = Color.Aquamarine
        '    lAtados.Add(row.Cells("Atado").Text)
        'Else
        '    row.Cells("Tipo").Appearance.BackColor = Color.Orange
        '    lErrores.Add(row.Cells("Par").Text)
        'End If

        'lTotales.Add(row.Cells("Atado").Text + "-" + row.Cells("Par").Text)
        GridView1.IndicatorWidth = 40
    End Sub
    '    Private Sub GridView1_RowStyle(ByVal sender As Object, _
    'ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
    '        Dim View As GridView = sender
    '        If (e.RowHandle >= 0) Then
    '            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("#"))
    '            If category Mod 2 > 0 Then
    '                e.Appearance.BackColor = Color.LightSteelBlue
    '                'e.Appearance.BackColor2 = Color.SeaShell
    '            End If
    '        End If
    '    End Sub
    'Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
    '    If e.IsGetData Then
    '        e.Value = GridView1.GetRowHandle(e.ListSourceRowIndex)
    '        e.Value = e.Value + 1
    '    End If
    'End Sub
    Private Sub gridListaEntradas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridListaEntradas.InitializeLayout

        If gridListaEntradas.Rows.Count = 0 Then Return

        Me.gridListaEntradas.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next



        With gridListaEntradas

            If Ubicacion = True Then
                .DisplayLayout.Bands(0).Columns("Id_Nave").Hidden = True
                .DisplayLayout.Bands(0).Columns("ID_ESTIBA").Hidden = True
                .DisplayLayout.Bands(0).Columns("Bahía ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Bloque").Hidden = True
                .DisplayLayout.Bands(0).Columns("Nivel").Hidden = True
                .DisplayLayout.Bands(0).Columns("Posicion").Hidden = True
                .DisplayLayout.Bands(0).Columns("Color").Hidden = True

            End If

            .DisplayLayout.Bands(0).Columns("Id_Nave").Hidden = True
            .DisplayLayout.Bands(0).Columns("Fecha Entrada(Con hr.)").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Programa").Style = ColumnStyle.Date
            .DisplayLayout.Bands(0).Columns("Fecha Entrega").Style = ColumnStyle.DateTime

            .DisplayLayout.Bands(0).Columns("Par").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Atado").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Fecha Entrada").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Programa").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Marca").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Colección").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Piel").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Color").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Corrida").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Talla").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Tienda").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Cliente").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Agte").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Fecha Entrega").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Orden de Compra").CellAppearance.TextHAlign = HAlign.Left


            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            .DisplayLayout.GroupByBox.Hidden = False
            .DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        End With


        Dim width As Integer
        For Each col As UltraGridColumn In gridListaEntradas.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > gridListaEntradas.Width Then
            gridListaEntradas.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            gridListaEntradas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


        Dim lAtados As New HashSet(Of String)
        Dim lPares As New HashSet(Of String)
        Dim lErrores As New HashSet(Of String)
        Dim lTotales As New HashSet(Of String)

        For Each row As UltraGridRow In gridListaEntradas.Rows

            If row.Cells("Tipo").Text.Equals("P") Then
                row.Cells("Tipo").Appearance.BackColor = Color.Khaki
                lPares.Add(row.Cells("Par").Text)
            ElseIf row.Cells("Tipo").Text.Equals("A") Then
                row.Cells("Tipo").Appearance.BackColor = Color.Aquamarine
                lAtados.Add(row.Cells("Atado").Text)
            Else
                row.Cells("Tipo").Appearance.BackColor = Color.Orange
                lErrores.Add(row.Cells("Par").Text)
            End If

            lTotales.Add(row.Cells("Atado").Text + "-" + row.Cells("Par").Text)

            If CInt(row.Cells("D").Text) > 0 Then
                row.Cells("D").Appearance.BackColor = Color.SeaGreen
            End If
            If CInt(row.Cells("A").Text) > 0 Then
                row.Cells("A").Appearance.BackColor = Color.RoyalBlue
            End If
            If CInt(row.Cells("C").Text) > 0 Then
                row.Cells("C").Appearance.BackColor = Color.SaddleBrown
            End If
            If CInt(row.Cells("B").Text) > 0 Then
                row.Cells("B").Appearance.BackColor = Color.Red
            End If
            If CInt(row.Cells("R").Text) > 0 Then
                row.Cells("R").Appearance.BackColor = Color.Indigo
            End If
            If CInt(row.Cells("P").Text) > 0 Then
                row.Cells("P").Appearance.BackColor = Color.DeepPink
            End If
        Next

        lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
        lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString

        'lblPares.Text = lPares.Count.ToString("n0")
        'lblAtados.Text = lAtados.Count.ToString("n0")
        'lblErroneos.Text = lErrores.Count.ToString("n0")
        'lblTotalPares.Text = lTotales.Count.ToString("n0")


    End Sub

    Private Sub advBandedGridView1_CustomDrawCell(ByVal sender As Object, _
                                                  ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsFilterRow(e.RowHandle) Then
            Return
        End If
        If e.Column.FieldName = "Tipo" Then
            'MessageBox.Show(e.DisplayText.ToString)
            If e.CellValue.ToString() = " " Then
                e.Appearance.BackColor = Color.Orange

            ElseIf e.CellValue.ToString() = "P" Then
                e.Appearance.BackColor = Color.Khaki
            ElseIf e.CellValue.ToString() = "A" Then
                e.Appearance.BackColor = Color.Aquamarine
            End If
            ' e.Column.Width = 10
        ElseIf e.Column.FieldName = "D" Then
            If CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.SeaGreen

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "A" Then
            If CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.RoyalBlue

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "C" Then
            If CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.SaddleBrown

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "B" Then
            If CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.Red

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "R" Then
            If CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.Indigo

            End If
            'e.Column.Width = 10
        ElseIf e.Column.FieldName = "P" Then
            If e.CellValue.ToString() = " " Then

            ElseIf CInt(e.CellValue.ToString()) > 0 Then
                e.Appearance.BackColor = Color.DeepPink
            End If
            'e.Column.Width = 10
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                'gridExcelExporter.Export(Me.gridListaUbicacion, .SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                'GridView1.SelectAll()
                ' xls.CopySelectionToClipboard(.SelectedPath + "\Datos_ListaUbicaciones_exceldev" + fecha_hora + ".xlsx", GridView1)
                ' GridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, .SelectedPath + "\Datos_ListaUbicaciones_dev" + fecha_hora + ".xlsx")
                If GridView1.GroupCount > 0 Then
                    GridControl1.ExportToXlsx(.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                Else
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                    GridControl1.ExportToXlsx(.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx", exportOptions)

                End If
            End If
            Dim FORMA As New ExitoForm
            FORMA.StartPosition = FormStartPosition.CenterScreen
            FORMA.mensaje = "Los datos se exportaron correctamente"
            FORMA.ShowDialog()

            .Dispose()

        End With

    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        If e.ColumnFieldName = "Tipo" Then
            'MessageBox.Show(e.DisplayText.ToString)
            If e.Value.ToString() = " " Then
                e.Formatting.BackColor = Color.Orange

            ElseIf e.Value.ToString() = "P" Then
                e.Formatting.BackColor = Color.Khaki
            ElseIf e.Value.ToString() = "A" Then
                e.Formatting.BackColor = Color.Aquamarine
            End If
            ' e.Column.Width = 10
        ElseIf e.ColumnFieldName = "D" Then
            If e.Value.ToString = "D" Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.SeaGreen

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "A" Then
            If e.Value.ToString = "A" Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.RoyalBlue

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "C" Then
            If e.Value.ToString = "C" Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.SaddleBrown

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "B" Then
            If e.Value.ToString = "B" Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.Red

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "R" Then
            If e.Value.ToString = "R" Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.Indigo

            End If
            'e.Column.Width = 10
        ElseIf e.ColumnFieldName = "P" Then
            If e.Value.ToString = "P" Then

            ElseIf e.Value.ToString() = " " Then

            ElseIf CInt(e.Value.ToString()) > 0 Then
                e.Formatting.BackColor = Color.DeepPink
            End If
            'e.Column.Width = 10
        End If
        e.Handled = True
    End Sub
    Private Sub btnUbicarMapa_Click(sender As Object, e As EventArgs) Handles btnUbicarMapa.Click
        Me.Cursor = Cursors.WaitCursor

        Dim listaBahias As New List(Of String)
        Dim listaBahiasLimpio As New List(Of String)
        Dim listaBahiasBuscar As New List(Of Entidades.Bahia)

        Dim mapa As New VerTodoslosNiveles

        For Each row In gridListaEntradas.Rows.GetFilteredInNonGroupByRows

            If Not row.Cells("Bahía ID").Text.Equals("SIN UBICACIÓN") Then
                If Not row.Cells("Bahía ID").Text.Equals("") Then
                    If Not listaBahias.Contains(row.Cells("Bahía ID").Text) Then
                        listaBahias.Add(row.Cells("Bahía ID").Text)
                        Dim bahia As New Entidades.Bahia
                        bahia.bahiaid = row.Cells("Bahía ID").Text
                        bahia.bahi_bloque = row.Cells("Bloque").Text
                        bahia.bahi_nivel = row.Cells("Nivel").Text
                        bahia.bahi_posicion = row.Cells("Posicion").Text
                        bahia.bahi_color = row.Cells("Color").Text

                        listaBahiasBuscar.Add(bahia)
                    End If
                End If
            End If
        Next

        mapa.BahiasBuscar = listaBahiasBuscar
        mapa.NavesAlmacen = "43,1"
        mapa.externo = True
        mapa.ubicacion_producto = True

        mapa.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class