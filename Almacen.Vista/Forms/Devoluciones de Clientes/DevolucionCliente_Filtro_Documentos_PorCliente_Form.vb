Imports System.Globalization
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_Filtro_Documentos_PorCliente_Form

    Public idCliente As Int32
    Public listaSeleccionados As DataTable
    Public pedidosSeleccionados As DataTable
    Public idPedidos As String
    Public filtroActual As List(Of String)
    Public listaFiltroDocumentos As New List(Of String)
    Public objBU As New Negocios.DevolucionClientesBU

    Public Sub buscarArticulo()
        Dim objBU As New Negocios.DevolucionClientesBU
        Dim lista As New DataTable
        lista = objBU.ListaArtiulos_ModeloSAY("SAY", txtModeloSAY.Text, idCliente, "")
        If lista.Rows.Count > 0 Then
            Dim newRow As DataRow = lista.NewRow
            lista.Rows.InsertAt(newRow, 0)
            cmbArticulos.DataSource = lista
            cmbArticulos.DisplayMember = "Articulo"
            cmbArticulos.ValueMember = "ProductoEstiloId"
            cmbArticulos.DroppedDown = True
        Else
            cmbArticulos.DataSource = Nothing
            Dim ventana As New Tools.AdvertenciaForm
            ventana.mensaje = "Modelo no encontrado"
            ventana.ShowDialog()
        End If
        txtModeloSAY.Select()
    End Sub

    Private Sub txtModelosSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModeloSAY.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            buscarArticulo()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If CDate(dtpFechaFin.Value) >= CDate(dtpFechaInicio.Value) Then
            Cursor = Cursors.WaitCursor
            gridListadoParametros.DataSource = Nothing
            Dim objBU As New Negocios.DevolucionClientesBU
            Dim tablaDocumentos As New DataTable
            Dim pedidos As String = ""
            Dim articulo As String = ""
            Dim documentos As String = ""
            Dim documentos1 As String = ""

            If bgvPedidos.DataRowCount > 0 Then
                'valida que se hayan seleccionado registros de la tabla principal
                If bgvPedidos.SelectedRowsCount > 0 Then
                    For I = 0 To bgvPedidos.SelectedRowsCount() - 1
                        If (bgvPedidos.GetSelectedRows()(I) >= 0) Then
                            Dim Row As DataRow = CType(bgvPedidos.GetDataRow(bgvPedidos.GetSelectedRows()(I)), DataRow)
                            If pedidos.Length > 0 Then
                                pedidos += ","
                            End If
                            pedidos += Row.Item(1).ToString
                            'pedidos += Row.Cells(1).Value.ToString
                        End If
                    Next
                End If
            End If

            For index As Int16 = 0 To bgvFiltroDocumentos.DataRowCount - 1
                If documentos.Length > 0 Then
                    documentos += ","
                End If
                documentos += bgvFiltroDocumentos.GetRowCellValue(index, "Column")
            Next

            Try
                articulo = cmbArticulos.SelectedValue.ToString
            Catch ex As Exception
                articulo = ""
            End Try
            Dim facturaRemision As String
            If chkFactura.Checked And chkRemision.Checked Then
                facturaRemision = "FR"
            ElseIf chkFactura.Checked Then
                facturaRemision = "F"
            ElseIf chkRemision.Checked Then
                facturaRemision = "R"
            ElseIf bgvPedidos.DataRowCount > 0 Then
                Dim FormularioMensaje As New Tools.AdvertenciaForm
                FormularioMensaje.mensaje = "Seleccione por lo menos un tipo de documento para realizar la búsqueda"
                FormularioMensaje.ShowDialog()
                Exit Sub
            End If

            tablaDocumentos = objBU.ListaDocumentos(documentos, numAnioDocto.Value, facturaRemision, idCliente, CDate(dtpFechaInicio.Value), CDate(dtpFechaFin.Value), txtModeloSAY.Text, articulo, pedidos)

            'gridListadoParametros.DataSource = tablaDocumentos
            grdDocumentos.DataSource = tablaDocumentos
                DiseñoGridDocumentos()

                bgvDocumentos.ClearSelection()

                For index As Integer = 0 To bgvDocumentos.DataRowCount - 1
                    For Each elemento In filtroActual
                        If CStr(bgvDocumentos.GetRowCellValue(index, "DetalleDoctoID")) = elemento Then
                            bgvDocumentos.SelectRow(index)
                        End If
                    Next
                Next

                For Each row As UltraGridRow In gridListadoParametros.Rows
                    For Each elemento In filtroActual
                        If CStr(row.Cells("DoctoSeleccionado").Value) = elemento Then
                            row.Cells(0).Value = True
                        End If
                    Next
                Next

                If bgvDocumentos.DataRowCount > 0 Then
                    chboxMarcarTodo.Enabled = True
                Else
                    chboxMarcarTodo.Enabled = False
                End If
                Cursor = Cursors.Default
            Else
                Dim FormularioMensaje As New Tools.AdvertenciaForm
            FormularioMensaje.mensaje = "La fecha de Fin debe ser mayor o igual a la fecha de inicio"
            FormularioMensaje.ShowDialog()
        End If
    End Sub

    Private Sub DevolucionCliente_Filtro_Documentos_PorCliente_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.MinDate = "01/01/2017"
        dtpFechaInicio.MaxDate = Date.Now
        dtpFechaInicio.Value = Date.Now.AddMonths(-6)

        dtpFechaFin.MinDate = "01/01/2017"
        dtpFechaFin.Value = Date.Now
        dtpFechaFin.MaxDate = Date.Now
        btnAceptar.Enabled = False

        numAnioDocto.Value = Date.Now.Year
        grdPedidos.DataSource = objBU.ListaPedidosFacturados(idPedidos)
        grdFiltroDocumentos.DataSource = New List(Of String)
        DiseñoGridPedidos()
        DiseñoGridFiltroDocumentos()
        chkMarcarTodoPedidos.Checked = True
        Me.WindowState = FormWindowState.Maximized

        bgvDocumentos.ClearSelection()

        For index As Integer = 0 To bgvDocumentos.DataRowCount - 1
            For Each elemento In filtroActual
                If CStr(bgvDocumentos.GetRowCellValue(index, "DetalleDoctoID")) = elemento Then
                    bgvDocumentos.SelectRow(index)
                End If
            Next
        Next

        For Each row As UltraGridRow In gridListadoParametros.Rows
            For Each elemento In filtroActual
                If CStr(row.Cells("DoctoSeleccionado").Value) = elemento Then
                    row.Cells(0).Value = True
                End If
            Next
        Next

        If bgvDocumentos.DataRowCount > 0 Then
            chboxMarcarTodo.Enabled = True
        Else
            chboxMarcarTodo.Enabled = False
        End If
    End Sub

    Public Function validarRepetido(dato As String)
        For Each row As DataRow In listaSeleccionados.Rows
            If dato = row(2).ToString Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If bgvDocumentos.DataRowCount = 0 Then Return

        Dim grid As DataTable = grdDocumentos.DataSource
        listaSeleccionados = grid.Clone

        If bgvDocumentos.DataRowCount > 0 Then
            'valida que se hayan seleccionado registros de la tabla principal
            If bgvDocumentos.SelectedRowsCount > 0 Then
                For I = 0 To bgvDocumentos.SelectedRowsCount() - 1
                    If (bgvDocumentos.GetSelectedRows()(I) >= 0) Then
                        'If validarRepetido(row.Cells(2).Value.ToString) = False Then
                        Dim fila As DataRow = listaSeleccionados.NewRow
                        Dim Row As DataRow = CType(bgvDocumentos.GetDataRow(bgvDocumentos.GetSelectedRows()(I)), DataRow)
                        Dim contador As Integer = 0
                        For Each col As DataColumn In listaSeleccionados.Columns
                            fila(col.Caption) = Row(col.Caption)
                        Next
                        listaSeleccionados.Rows.Add(fila)
                        'End If
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.Format = String.Format("N2")
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Public Sub sumarColumnas(columna As String, formato As String)
        If IsNothing(bgvDocumentos.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvDocumentos.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvDocumentos.GroupSummary.Add(item)
        End If
    End Sub

    Private Sub gridListadoParametros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridListadoParametros.InitializeLayout
        sumarColumnas("TotalDetalles", "{0:N2}")
        sumarColumnas("TotalDocumento", "{0:N2}")
        sumarColumnas("Pares", "{0:N0}")

        asignaFormato_Columna(gridListadoParametros)
        With gridListadoParametros.DisplayLayout
            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            If gridListadoParametros.Rows.Count = 0 Then
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Else
                .AutoFitStyle = AutoFitStyle.None
            End If

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = Scrollbars.Both

            .Bands(0).ColHeaderLines = 2
            .Bands(0).Columns(6).CellActivation = Activation.NoEdit
            .Bands(0).Columns("fcdd_productoestiloid").Hidden = True
            .Bands(0).Columns("FechaDocumento").Header.Caption = "FDocto"
            .Bands(0).Columns("TotalPartida").Header.Caption = "Total" + vbCrLf + "Partida"
            .Bands(0).Columns("TotalDocumento").Header.Caption = "Total" + vbCrLf + "Documento"

            If .Bands(0).Columns.Exists("DoctoSeleccionado") Then
                .Bands(0).Columns("DoctoSeleccionado").Hidden = True
            End If
        End With
        If gridListadoParametros.Rows.Count = 0 Then
            btnAceptar.Enabled = False
            chboxMarcarTodo.Enabled = False
            chboxMarcarTodo.Checked = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            bgvDocumentos.SelectAll()
        Else
            bgvDocumentos.ClearSelection()
        End If

        grdFiltroDocumentos_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub gridListadoParametros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListadoParametros.ClickCell
        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        If gridListadoParametros.ActiveRow.Cells(" ").Value Then
            gridListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoParametros.ActiveRow.Cells(" ").Value = True
        End If


        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub txtFiltroDocumentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroDocumentos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroDocumentos.Text) Then Return
            listaFiltroDocumentos.Add(txtFiltroDocumentos.Text.Trim)
            grdFiltroDocumentos.DataSource = Nothing
            grdFiltroDocumentos.DataSource = listaFiltroDocumentos
            DiseñoGridFiltroDocumentos()
            txtFiltroDocumentos.Text = String.Empty
        End If
    End Sub

    Public Sub DiseñoGridPedidos()
        Try
            bgvPedidos.OptionsView.ColumnAutoWidth = True

            bgvPedidos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            bgvPedidos.OptionsSelection.MultiSelect = True
            bgvPedidos.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False
            bgvPedidos.OptionsSelection.CheckBoxSelectorColumnWidth = 25
            bgvPedidos.OptionsSelection.EnableAppearanceFocusedRow = False

            bgvPedidos.Columns.ColumnByFieldName("PedidoSAY").DisplayFormat.FormatType = FormatType.Numeric
            bgvPedidos.Columns.ColumnByFieldName("PedidoSAY").DisplayFormat.FormatString = "N0"

            bgvPedidos.Columns.ColumnByFieldName("PedidoSICY").DisplayFormat.FormatType = FormatType.Numeric
            bgvPedidos.Columns.ColumnByFieldName("PedidoSICY").DisplayFormat.FormatString = "N0"

            bgvPedidos.Columns.ColumnByFieldName(" ").Visible = False

            bgvPedidos.IndicatorWidth = 40
            bgvPedidos.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Public Sub DiseñoGridFiltroDocumentos()
        Try
            bgvFiltroDocumentos.OptionsView.ColumnAutoWidth = True
            bgvFiltroDocumentos.Columns.ColumnByFieldName("Column").Caption = "Documento"
            bgvFiltroDocumentos.Columns.ColumnByFieldName("Column").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            bgvFiltroDocumentos.Columns.ColumnByFieldName("Column").DisplayFormat.FormatType = FormatType.Numeric
            bgvFiltroDocumentos.Columns.ColumnByFieldName("Column").DisplayFormat.FormatString = "N0"

            bgvFiltroDocumentos.IndicatorWidth = 40
            bgvFiltroDocumentos.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Public Sub DiseñoGridDocumentos()
        Try
            sumarColumnas("TotalPartida", "{0:N2}")
            sumarColumnas("TotalDocumento", "{0:N2}")
            sumarColumnas("Pares", "{0:N0}")

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDocumentos.Columns
                If col.FieldName <> " " And col.FieldName <> "ParesDevolución" Then
                    col.OptionsColumn.AllowEdit = False
                End If
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            Next

            If bgvDocumentos.DataRowCount = 0 Then
                bgvDocumentos.OptionsView.ColumnAutoWidth = True
            Else
                bgvDocumentos.OptionsView.ColumnAutoWidth = False
            End If

            bgvDocumentos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            AddHandler bgvDocumentos.SelectionChanged, AddressOf grdFiltroDocumentos_SelectionChanged
            bgvDocumentos.OptionsSelection.MultiSelect = True
            bgvDocumentos.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False
            bgvDocumentos.OptionsSelection.CheckBoxSelectorColumnWidth = 25
            bgvDocumentos.OptionsSelection.EnableAppearanceFocusedRow = False

            bgvDocumentos.Columns.ColumnByFieldName(" ").Visible = False
            bgvDocumentos.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
            bgvDocumentos.Columns.ColumnByFieldName("DoctoSeleccionado").Visible = False
            bgvDocumentos.Columns.ColumnByFieldName("DetalleDoctoID").Visible = False

            bgvDocumentos.Columns.ColumnByFieldName("TotalPartida").DisplayFormat.FormatType = FormatType.Numeric
            bgvDocumentos.Columns.ColumnByFieldName("TotalPartida").DisplayFormat.FormatString = "N2"
            bgvDocumentos.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatType = FormatType.Numeric
            bgvDocumentos.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatString = "N2"

            bgvDocumentos.Columns.ColumnByFieldName("TotalPartida").Caption = "Total" + vbCrLf + "Partida"
            bgvDocumentos.Columns.ColumnByFieldName("TotalDocumento").Caption = "Total" + vbCrLf + "Documento"

            If bgvDocumentos.DataRowCount = 0 Then
                btnAceptar.Enabled = False
                chboxMarcarTodo.Enabled = False
                chboxMarcarTodo.Checked = False
            Else
                btnAceptar.Enabled = True
                chboxMarcarTodo.Enabled = True
            End If

            bgvDocumentos.IndicatorWidth = 40
            bgvDocumentos.BestFitColumns()
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDocumentos.Columns
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            Next
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Private Sub grdFiltroDocumentos_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim contador As Integer = 0
        For I = 0 To bgvDocumentos.SelectedRowsCount() - 1
            If (bgvDocumentos.GetSelectedRows()(I) >= 0) Then
                contador += 1
            End If
        Next

        If contador = 0 Then
            btnAceptar.Enabled = False
        Else
            btnAceptar.Enabled = True
        End If

        lblNumFiltrados.Text = contador.ToString("N0", CultureInfo.InvariantCulture)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdFiltroDocumentos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdFiltroDocumentos.DataSource = New List(Of String)
    End Sub

    Private Sub bgvPedidos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvPedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chkMarcarTodoPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarTodoPedidos.CheckedChanged
        If chkMarcarTodoPedidos.Checked Then
            bgvPedidos.SelectAll()
        Else
            bgvPedidos.ClearSelection()
        End If

        'gridPedidos_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub bgvPedidos_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles bgvPedidos.RowCellStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvFiltroDocumentos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvFiltroDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvFiltroDocumentos_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles bgvFiltroDocumentos.RowCellStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub grdFiltroDocumentos_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdFiltroDocumentos.ProcessGridKey
        Dim grid = TryCast(sender, GridControl)
        Dim view = TryCast(grid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.KeyData = Keys.Delete Then
            view.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub

    Private Sub bgvDocumentos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvDocumentos_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles bgvDocumentos.RowCellStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvDocumentos_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvDocumentos.ColumnFilterChanged
        bgvDocumentos.ClearSelection()

        For index As Integer = 0 To bgvDocumentos.DataRowCount - 1
            For Each elemento In filtroActual
                If CStr(bgvDocumentos.GetRowCellValue(index, "DoctoSeleccionado")) = elemento Then
                    bgvDocumentos.SelectRow(index)
                End If
            Next
        Next
    End Sub
End Class