Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports Tools
Imports Tools.modMensajes
Imports Tools.Utilerias

Public Class PreciosdeVentaaComercializadorasForm
    Dim idEstatus As Int32
    Dim esListaActual As Boolean

    Dim fechaInicialINICIO As String
    Dim fechaInicialFIN As String
    Dim nombreListaInicial As String
    Dim endEdit As Boolean = True
    Dim exitoMensaje As New ExitoForm


    Private Sub PreciosdeVentaaComercializadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        llenarListasBaseActivas()
        llenarproductos()
    End Sub

    Private Sub llenarproductos()
        Dim objLBA As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosLista As New DataTable

        Dim gridvalido As Boolean = True
        lblConPrecio.Text = "0"
        lblPrecioModificado.Text = "0"
        lblSinPrecio.Text = "0"
        lblTotalSeleccionados.Text = "0"
        Me.Cursor = Cursors.WaitCursor
        grdDatosProductos.DataSource = Nothing
        If CBool(chkModelosConPrecio.Checked) = False And CBool(chkCargarModelosSinPrecio.Checked) = False Then
            gridvalido = False
        End If

        If CBool(chkEstatusActivo.Checked) = False And CBool(chkDescontinuados.Checked) = False Then
            gridvalido = False
        End If

        If gridvalido = True Then
            Dim contArticulosCPrecio As Int32 = 0
            dtDatosLista = objLBA.DatosProductos(chkModelosConPrecio.Checked, chkCargarModelosSinPrecio.Checked, chkEstatusActivo.Checked, chkDescontinuados.Checked)
            If dtDatosLista.Rows.Count > 0 Then
                grdDatosProductos.DataSource = dtDatosLista

                lblTotalArticulos.Text = dtDatosLista.Rows.Count.ToString("N0")

                For Each rowDt As DataRow In dtDatosLista.Rows
                    If rowDt.Item("PrecioVenta") > 0 Then
                        contArticulosCPrecio += 1
                    End If
                Next
                lblArticulosConPrecio.Text = contArticulosCPrecio.ToString("N0")
                formatosGrids()
                endEdit = False
            End If

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub formatosGrids()
        lblConPrecio.Text = "0"
        lblPrecioModificado.Text = "0"
        lblSinPrecio.Text = "0"
        '   With grdDatosProductos.DisplayLayout.Bands(0)
        vwReporte.OptionsView.AllowHtmlDrawHeaders = True
        vwReporte.ColumnPanelRowHeight = 50
        vwReporte.OptionsView.BestFitMaxRowCount = -1
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.BestFitColumns()
        vwReporte.IndicatorWidth = 50
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True
        vwReporte.OptionsSelection.EnableAppearanceFocusedCell = True
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        vwReporte.Appearance.SelectedRow.Options.UseBackColor = True
        vwReporte.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        vwReporte.Appearance.EvenRow.BackColor = Color.White
        vwReporte.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        vwReporte.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        vwReporte.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next


        vwReporte.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo SAY"
        vwReporte.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo SICY"
        vwReporte.Columns.ColumnByFieldName("DescripcionCompleta").Caption = "Descripción"
        vwReporte.Columns.ColumnByFieldName("ProductoEstiloId").Caption = "ProductoEstiloID"
        vwReporte.Columns.ColumnByFieldName("ColeccionSAY").Caption = "Colección"
        vwReporte.Columns.ColumnByFieldName("MarcaSAY").Caption = "Marca"
        vwReporte.Columns.ColumnByFieldName("Piel").Caption = "Piel"
        vwReporte.Columns.ColumnByFieldName("Color").Caption = "Color"
        vwReporte.Columns.ColumnByFieldName("Talla").Caption = "Corrida"
        vwReporte.Columns.ColumnByFieldName("Piel").Caption = "Piel"
        vwReporte.Columns.ColumnByFieldName("Color").Caption = "Color"
        vwReporte.Columns.ColumnByFieldName("FamiliaProyeccion").Caption = "Fam.Ventas"
        vwReporte.Columns.ColumnByFieldName("Status").Caption = "Estatus"
        vwReporte.Columns.ColumnByFieldName("PrecioVenta").Caption = "Precio Venta"
        vwReporte.Columns.ColumnByFieldName("PrecioAnterior").Visible = False
        vwReporte.Columns.ColumnByFieldName("tppe_productoestiloid").Visible = False
        vwReporte.Columns.ColumnByFieldName("DescripcionCompleta").Visible = False
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.Columns.ColumnByFieldName("PrecioVenta").Caption = "*Precio"
        vwReporte.Columns.ColumnByFieldName("PrecioVenta").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("PrecioVenta").DisplayFormat.FormatString = "N2"
        vwReporte.OptionsView.ShowAutoFilterRow = True



        For i As Integer = 0 To vwReporte.RowCount - 1
            If vwReporte.GetRowCellValue(i, "PrecioVenta") = 0 Then
                vwReporte.SetRowCellValue(i, "Estado", "N")
                lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
            ElseIf vwReporte.GetRowCellValue(i, "PrecioVenta") > 0 Then
                vwReporte.SetRowCellValue(i, "Estado", "P")
                lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
            End If
        Next


        'For Each rowgr As UltraGridRow In grdDatosProductos.Rows
        '    If rowgr.Cells("PrecioVenta").Value = 0 Then 'rowgr.Cells("PrecioAnterior").Value = 0 Then
        '        rowgr.Cells("Estado").Appearance.BackColor = Color.Red
        '        rowgr.Cells("Estado").Value = "N"
        '        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

        '    ElseIf rowgr.Cells("PrecioVenta").Value > 0 Then
        '        rowgr.Cells("Estado").Appearance.BackColor = Color.DodgerBlue
        '        rowgr.Cells("Estado").Value = "P"
        '        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
        '    End If

        'Next
        ''For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
        ''    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        ''    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        ''    If col.FieldName.Contains("ParesF") Or col.FieldName.Contains("Total") Or col.FieldName.Contains("Subtotal") Then
        ''        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "ParesF")) = True And col.FieldName = "ParesF" Then
        ''            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
        ''        End If
        ''        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
        ''            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
        ''        End If
        ''        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
        ''            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
        ''        End If
        ''    End If
        ''Next

        'grdDatosProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdDatosProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grdDatosProductos.DisplayLayout.Override.RowSelectorWidth = 35
        'grdDatosProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'grdDatosProductos.Rows(0).Selected = True
    End Sub

    'Private Sub vwreporte_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    '    Throw New NotImplementedException()
    'End Sub

    Private Sub vwReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwReporte.CustomDrawCell
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Estado" Then
                If vwReporte.GetRowCellValue(e.RowHandle, "Estado") = "N" Then
                    e.Appearance.BackColor = Color.Red
                    'ForeColor = Color.Red ' cambio color letra
                End If
                If vwReporte.GetRowCellValue(e.RowHandle, "Estado") = "P" Then
                    e.Appearance.BackColor = Color.DodgerBlue
                End If
            End If
        End If
    End Sub
    Private Sub llenarListasBaseActivas()
        Dim objLBA As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosLista As New DataTable
        dtDatosLista = objLBA.DatosListasBase

        idEstatus = CInt(dtDatosLista.Rows(0)("lpba_estatus").ToString())
        If idEstatus = 2 Then
            esListaActual = True
        Else
            esListaActual = False
        End If
        nombreListaInicial = dtDatosLista.Rows(0)("lpba_nombreLista").ToString
        fechaInicialINICIO = dtDatosLista.Rows(0)("lpba_vigenciainicio").ToString
        fechaInicialFIN = dtDatosLista.Rows(0)("lpba_vigenciafin").ToString
        If idEstatus = 1 Then
            lblEstatus.ForeColor = Color.DarkOrange
            lblEstatus.Text = "ACTIVA"
        ElseIf idEstatus = 2 Then
            lblEstatus.Text = "AUTORIZADA"
        Else
            lblEstatus.Text = "INACTIVA"
            lblEstatus.ForeColor = Color.Red
        End If

        txtNombreLista.Text = dtDatosLista.Rows(0)("lpba_nombreLista").ToString
        txtCodigo.Text = dtDatosLista.Rows(0)("lpba_codigolistabase").ToString
        dttFechaInicio.Value = dtDatosLista.Rows(0)("lpba_vigenciainicio").ToString
        dttFechaFin.Value = dtDatosLista.Rows(0)("lpba_vigenciafin").ToString
        chkModelosConPrecio.Checked = True
        chkCargarModelosSinPrecio.Checked = True
        chkEstatusActivo.Checked = True
        If idEstatus <> 3 Then
            chkCargarModelosSinPrecio.Visible = True
            btnEditar.Enabled = True
            lblEditar.Enabled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkModelosConPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkModelosConPrecio.CheckedChanged
        If btnEditar.Enabled = True Then
            Dim objMAlert As New Tools.AdvertenciaForm
            objMAlert.mensaje = "Recuerde que al cambiar los filtros se "
        End If
        llenarproductos()
    End Sub

    Private Sub chkCargarModelosSinPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkCargarModelosSinPrecio.CheckedChanged
        If btnEditar.Enabled = True Then
            Dim objMAlert As New Tools.AdvertenciaForm
            objMAlert.mensaje = "Recuerde que al cambiar los filtros se "
        End If
        llenarproductos()
    End Sub

    Private Sub chkEstatusActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstatusActivo.CheckedChanged
        If btnEditar.Enabled = True Then
            Dim objMAlert As New Tools.AdvertenciaForm
            objMAlert.mensaje = "Recuerde que al cambiar los filtros se "
        End If
        llenarproductos()
    End Sub

    Private Sub chkDescontinuados_CheckedChanged(sender As Object, e As EventArgs) Handles chkDescontinuados.CheckedChanged
        If btnEditar.Enabled = True Then
            Dim objMAlert As New Tools.AdvertenciaForm
            objMAlert.mensaje = "Recuerde que al cambiar los filtros se "
        End If
        llenarproductos()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        chkCargarModelosSinPrecio.Checked = True
        chkEstatusActivo.Checked = True
        chkCargarModelosSinPrecio.Enabled = False
        chkEstatusActivo.Enabled = False

        btnEditar.Enabled = False
        lblEditar.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        lblGuardar.Enabled = True
        lblCancelar.Enabled = True
        btnCargarPrecioMultiple.Visible = True
        lblCargarPrecios.Visible = True
        txtPrecioMultiple.Visible = True

        chkSeleccionarFiltrados.Enabled = True
        btnCargarPrecioMultiple.Enabled = True
        txtPrecioMultiple.Enabled = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            If col.FieldName.Contains("PrecioVenta") Then  'Or col.FieldName.Contains("Seleccion") Then
                col.OptionsColumn.AllowEdit = True
            End If
        Next
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = vwReporte.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1

                vwReporte.SetRowCellValue(index, "Seleccion", chkSeleccionarFiltrados.Checked)
            Next

            If chkSeleccionarFiltrados.Checked Then
                lblTotalSeleccionados.Text = NumeroFilas.ToString
            Else
                lblTotalSeleccionados.Text = 0
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdDatosProductos_Click(sender As Object, e As EventArgs) Handles grdDatosProductos.Click

        Dim cellNombre As String = vwReporte.FocusedColumn.FieldName
        Dim cellValue As String = vwReporte.GetFocusedDisplayText()
        If cellNombre = "Seleccion" Then
            If cellValue = "Seleccionado" Then
                vwReporte.SetFocusedValue(False)
                lblTotalSeleccionados.Text = lblTotalSeleccionados.Text - 1
            Else
                vwReporte.SetFocusedValue(True)
                lblTotalSeleccionados.Text = lblTotalSeleccionados.Text + 1
            End If
        End If

    End Sub



    'Private Sub grdDatosProductos_DragDrop(sender As Object, e As DragEventArgs) Handles grdDatosProductos.DragDrop
    '    Dim dropIndex As Integer

    '    Dim uieOver As UIElement = grdDatosProductos.DisplayLayout.UIElement.ElementFromPoint(grdDatosProductos.PointToClient(New Point(e.X, e.Y)))
    '    Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

    '    If ugrOver IsNot Nothing Then
    '        dropIndex = ugrOver.Index
    '        Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

    '        For Each aRow As UltraGridRow In SelRows
    '            grdDatosProductos.Rows.Move(aRow, dropIndex)
    '        Next
    '    End If
    'End Sub

    'Private Sub grdDatosProductos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosProductos.AfterCellUpdate
    '    If endEdit = False Then
    '        If (e.Cell.Column.ToString = "PrecioVenta" And e.Cell.Row.Index <> vwReporte.Rows.FilterRow.Index) Then
    '            If e.Cell.Value.ToString = "" Then
    '                e.Cell.Value = 0
    '            ElseIf e.Cell.Value > 9999 Then
    '                e.Cell.Value = 0
    '            End If
    '        End If
    '    End If

    '    If (e.Cell.Column.ToString = "PrecioVenta") Then  'And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index) Then
    '        Dim PrecioAnterior As String = e.Cell.OriginalValue.ToString
    '        Dim contAnt As Int32 = 0
    '        Dim contNuevo As Int32 = 0

    '        If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value <> e.Cell.Value Then
    '            If e.Cell.Value > 0 Then
    '                If PrecioAnterior = "0" Then
    '                    If CInt(lblSinPrecio.Text) > 0 Then
    '                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
    '                    End If
    '                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
    '                ElseIf PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                    lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
    '                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
    '                End If
    '            End If
    '            If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Red
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.True
    '            Else
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Black
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.False
    '            End If
    '        Else
    '            If e.Cell.Value = 0 Then
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
    '                If PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                    lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
    '                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

    '                ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
    '                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

    '                End If
    '                If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Red
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.True
    '                Else
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Black
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.False
    '                End If
    '            ElseIf e.Cell.Value > 0 Then
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.DodgerBlue
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P"
    '                If PrecioAnterior = "0" Then
    '                    If CInt(lblSinPrecio.Text) > 0 Then
    '                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
    '                    End If
    '                    lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
    '                ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
    '                    lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
    '                End If
    '                If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Red
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.True
    '                Else
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Black
    '                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.False
    '                End If
    '            End If
    '        End If
    '        If e.Cell.Value = 0 And grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > 0 Then
    '            grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
    '            grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
    '            If PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
    '                lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
    '            ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
    '                lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
    '                lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
    '            End If
    '            If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Red
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.True
    '            Else
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.ForeColor = Color.Black
    '                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioVenta").Appearance.FontData.Bold = DefaultableBoolean.False
    '            End If
    '        End If
    '    End If
    'End Sub



    'Private Sub grdDatosProductos_DragOver(sender As Object, e As DragEventArgs) Handles grdDatosProductos.DragOver
    '    e.Effect = DragDropEffects.Move
    '    Dim grid As UltraGrid = TryCast(sender, UltraGrid)
    '    Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

    '    If pointInGridCoords.Y < 20 Then
    '        Me.grdDatosProductos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
    '    ElseIf pointInGridCoords.Y > grid.Height - 20 Then
    '        Me.grdDatosProductos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
    '    End If
    'End Sub

    'Private Sub grdDatosProductos_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosProductos.SelectionDrag
    '    grdDatosProductos.DoDragDrop(grdDatosProductos.Selected.Rows, DragDropEffects.Move)
    'End Sub

    'Private Sub grdDatosProductos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdDatosProductos.BeforeCellUpdate

    '    If e.Cell.Row.IsFilterRow = False Then
    '        If e.Cell.Column.Key = "Precio" Then
    '            If e.NewValue.ToString = "" Then
    '                e.Cancel = True
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub grdDatosProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdDatosProductos.CellChange
    '    If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then
    '        Dim contadorSeleccion As Int32 = 0
    '        If CBool(e.Cell.Text) = True Then
    '            lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) + 1
    '        Else
    '            lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) - 1
    '        End If
    '    End If
    'End Sub

    'Private Sub grdDatosProductos_Error(sender As Object, e As ErrorEventArgs) Handles grdDatosProductos.Error
    '    If grdDatosProductos.ActiveRow.Index Mod 2 = 0 Then
    '        grdDatosProductos.ActiveRow.Appearance.BackColor = Color.White
    '    Else
    '        grdDatosProductos.ActiveRow.Appearance.BackColor = Color.LightSteelBlue
    '    End If
    'End Sub

    'Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
    '    For Each rowGr As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
    '        rowGr.Cells("Seleccion").Value = CBool(chkSeleccionarFiltrados.Checked)
    '    Next

    '    Dim contadorSeleccion As Int32 = 0
    '    For Each rowGR As UltraGridRow In grdDatosProductos.Rows
    '        If CBool(rowGR.Cells("Seleccion").Text) = True Then
    '            contadorSeleccion += 1
    '        End If
    '    Next
    '    lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
    'End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Está seguro de guardar cambios?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then

            guardar()
            llenarproductos()
            btnEditar.Enabled = True
            lblEditar.Enabled = True
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            chkCargarModelosSinPrecio.Enabled = True
            chkEstatusActivo.Enabled = True

        Else
            Exit Sub
        End If

    End Sub

    Private Sub guardar()
        Dim objLBA As New Ventas.Negocios.ListaBaseBU
        Try
            Dim seleccionados As Integer = 0

            For index As Integer = 0 To vwReporte.RowCount - 1
                If vwReporte.GetRowCellValue(index, "Seleccion") Then
                    seleccionados += 1
                End If
            Next

            If seleccionados > 0 Then
                For i As Integer = 0 To vwReporte.RowCount - 1
                    If vwReporte.GetRowCellValue(i, "Seleccion") = True Then
                        objLBA.InsertPrecioProductoDetalles(vwReporte.GetRowCellValue(i, "ProductoEstiloId"), vwReporte.GetRowCellValue(i, "PrecioVenta"), vwReporte.GetRowCellValue(i, "tppe_productoestiloid"))
                    End If
                Next
                exitoMensaje.mensaje = "El registro se realizó con éxito."
                exitoMensaje.ShowDialog()
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Seleccione los registros a modificar.")
            End If
        Catch ex As Exception
        End Try
    End Sub


    'Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    '    txtPrecioMultiple.Text = String.Empty
    '    txtPrecioMultiple.Enabled = False
    '    btnCargarPrecioMultiple.Enabled = False
    '    chkSeleccionarFiltrados.Enabled = False
    '    chkCargarModelosSinPrecio.Enabled = True
    '    chkEstatusActivo.Enabled = True
    '    btnEditar.Enabled = True
    '    lblEditar.Enabled = True
    '    btnGuardar.Enabled = False
    '    btnCancelar.Enabled = False
    '    lblGuardar.Enabled = False
    '    lblCancelar.Enabled = False
    '    dttFechaInicio.Enabled = False
    '    dttFechaFin.Enabled = False
    '    txtNombreLista.Enabled = False
    '    If chkModelosConPrecio.Checked = True Then
    '        llenarproductos()
    '    Else
    '        chkModelosConPrecio.Checked = True
    '    End If
    '    Dim colckbPl As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("PrecioVenta")
    '    colckbPl.CellActivation = Activation.NoEdit
    'End Sub

    Private Sub btnCargarPrecioMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarPrecioMultiple.Click
        If txtPrecioMultiple.Text.Length > 0 Then
            If CDec(txtPrecioMultiple.Text) > 0 Then
                Dim contFilasCambio As Int32 = 0
                'For Each rowGR As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
                '    If rowGR.Cells("Seleccion").Value Then
                '        contFilasCambio += 1
                '    End If
                'Next

                For i As Integer = 0 To vwReporte.RowCount - 1
                    If vwReporte.GetRowCellValue(i, "Seleccion") = True Then
                        contFilasCambio += 1
                    End If
                Next

                If contFilasCambio > 0 Then
                    'Dim objCaptcha As New Tools.frmCaptcha
                    'objCaptcha.mensaje = "Registros por actualizar: " + contFilasCambio.ToString

                    'If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'For Each rowLB As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows

                    '    If rowLB.Cells("Seleccion").Value Then
                    '        rowLB.Cells("PrecioVenta").Value = txtPrecioMultiple.Text

                    '    End If
                    'Next

                    For i As Integer = 0 To vwReporte.RowCount - 1
                        If vwReporte.GetRowCellValue(i, "Seleccion") = True Then
                            vwReporte.SetRowCellValue(i, "PrecioVenta", txtPrecioMultiple.Text)
                        End If
                    Next

                    Dim contadorPrecio As Int32 = 0
                    'For Each rowGR As UltraGridRow In grdDatosProductos.Rows
                    '    If rowGR.Cells("PrecioVenta").Value > 0 Then
                    '        contadorPrecio += 1
                    '    End If
                    'Next

                    For i As Integer = 0 To vwReporte.RowCount - 1
                        If vwReporte.GetRowCellValue(i, "PrecioVenta") > 0 Then
                            contadorPrecio += 1
                        End If
                    Next



                    lblArticulosConPrecio.Text = contadorPrecio.ToString("N0")
                    chkSeleccionarFiltrados.Checked = False
                    'For Each rowGr As UltraGridRow In grdDatosProductos.Rows
                    '    rowGr.Cells("Seleccion").Value = False
                    'Next
                    lblTotalSeleccionados.Text = "0"
                    'End If
                Else
                    'MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
                    Utilerias.show_message(TipoMensaje.Advertencia, "Debe seleccionar al menos un registro.")
                End If
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "EL precio debe ser mayor a 0.")
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "EL precio no debe ser vacío.")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "Precios Venta a Comercializadoras"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub
End Class