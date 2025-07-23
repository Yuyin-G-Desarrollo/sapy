Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.Utils

Public Class DevolucionCliente_CatalogosMotivos_Form

    Dim altasCambios As Boolean
    Dim IdEstatus As Int32
    Dim tipoMotivo As String
    Dim nombreMotivo As String
    Dim descripion As String
    Dim activo As Boolean
    Dim AtaEdicion As Boolean

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim formularioAltasEdicion As New Vista.DevolucionCliente_CatalogosMotivos_AltaEdicion_Form
        formularioAltasEdicion.altaEdicion = True
        formularioAltasEdicion.ShowDialog()
        LlenarListaDevoluciones()
    End Sub

    Public Sub FormatoGrid()
        bgvListaMotivosDev.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvListaMotivosDev.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            End If
        Next
        'bgvNotasCredito.BestFitColumns()
        bgvListaMotivosDev.IndicatorWidth = 40
        bgvListaMotivosDev.Columns.ColumnByFieldName(" ").Width = 20
        bgvListaMotivosDev.Columns.ColumnByFieldName("Activo").Width = 40

        bgvListaMotivosDev.Columns.ColumnByFieldName("esta_estatusid").Visible = False
        bgvListaMotivosDev.Columns.ColumnByFieldName("TipoMotivo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvListaMotivosDev.Columns.ColumnByFieldName("Motivo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvListaMotivosDev.Columns.ColumnByFieldName("Descripción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbDevoluciones.Height = 35
        grbDevoluciones.Top = 126
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbDevoluciones.Height = 145
        grbDevoluciones.Top = 126
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        LlenarListaDevoluciones()
        FormatoGrid()
        lblNumFiltrados.Text = bgvListaMotivosDev.DataRowCount.ToString("N0")
        Cursor = Cursors.Default
    End Sub

    Public Sub LlenarListaDevoluciones()
        grdListaMotivosDev.DataSource = Nothing
        IdEstatus = 0
        tipoMotivo = ""
        nombreMotivo = ""

        Dim objBU As New Negocios.DevolucionClientesBU

        Dim tablaDevoluciones As New DataTable


        If cboTipoMotivo.SelectedValue IsNot Nothing Then
            tipoMotivo = cboTipoMotivo.SelectedValue.ToString
        Else
            tipoMotivo = ""
        End If

        nombreMotivo = txtNombreMotivo.Text
        descripion = txtDescripcion.Text

        If rdoSi.Checked = True Then
            activo = True
        Else
            activo = False
        End If

        tablaDevoluciones = objBU.ListaMotivosDevolucion(activo, tipoMotivo, nombreMotivo, descripion)
        grdListaMotivosDev.DataSource = tablaDevoluciones
    End Sub

    Private Sub gridListaDevoluciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        'With gridListaDevoluciones
        '    .DisplayLayout.Bands(0).Columns(0).Hidden = True
        '    '.DisplayLayout.Bands(0).Columns(1).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        '    '.DisplayLayout.Bands(0).Columns(2).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        '    'If gridListaDevoluciones.Rows.Count > 0 Then
        '    .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        '    .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        '    .DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        '    .DisplayLayout.GroupByBox.Style = GroupByBoxStyle.Compact
        '    .DisplayLayout.GroupByBox.Appearance.BackColor = Color.White
        '    .DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por esa columna"

        '    ' Configure the look of the band labels.
        '    .DisplayLayout.GroupByBox.BandLabelBorderStyle = UIElementBorderStyle.Solid
        '    .DisplayLayout.GroupByBox.BandLabelAppearance.BackColor = Color.DarkBlue
        '    .DisplayLayout.GroupByBox.BandLabelAppearance.ForeColor = Color.LightYellow

        '    ' Configure the way button connectors look
        '    .DisplayLayout.GroupByBox.ButtonConnectorStyle = UIElementBorderStyle.Dotted
        '    .DisplayLayout.GroupByBox.ButtonConnectorColor = Color.Maroon

        '    .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        '    .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        '    .DisplayLayout.Override.RowSelectorWidth = 35
        '    .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        '    .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        '    .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        '    .DisplayLayout.Bands(0).Columns("TipoMotivo").CellActivation = Activation.NoEdit
        '    .DisplayLayout.Bands(0).Columns("Motivo").CellActivation = Activation.NoEdit
        '    .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.NoEdit
        '    .DisplayLayout.Scrollbars = Scrollbars.Automatic
        'End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtDescripcion.Text = ""
        txtNombreMotivo.Text = ""
        cboTipoMotivo.Text = ""
        rdoSi.Checked = True
        grdListaMotivosDev.DataSource = Nothing
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim numFilas As Integer = bgvListaMotivosDev.DataRowCount
        Dim filaSeleccionada As Integer
        Dim numSeleccionados As Int16 = 0

        For index As Integer = 0 To numFilas Step 1
            If numSeleccionados > 1 Then
                Dim ventanaEmergencia As New Tools.AdvertenciaForm
                ventanaEmergencia.mensaje = "Esta operación solo se puede realizar con un registro a la vez"
                ventanaEmergencia.ShowDialog()
                Exit Sub
            End If

            If CBool(bgvListaMotivosDev.GetRowCellValue(index, " ")) = True Then
                numSeleccionados += 1
                filaSeleccionada = index
            End If
        Next

        If numSeleccionados = 0 Then
            Dim ventanaEmergencia As New Tools.AdvertenciaForm
            ventanaEmergencia.mensaje = "Seleccione un registro"
            ventanaEmergencia.ShowDialog()
            Exit Sub
        End If

        Dim formularioAltasEdicion As New DevolucionCliente_CatalogosMotivos_AltaEdicion_Form
        formularioAltasEdicion.altaEdicion = False
        formularioAltasEdicion.estatusid = bgvListaMotivosDev.GetRowCellValue(filaSeleccionada, "esta_estatusid")
        formularioAltasEdicion.tipoMotivo = bgvListaMotivosDev.GetRowCellValue(filaSeleccionada, "TipoMotivo")
        formularioAltasEdicion.nombreMotivo = bgvListaMotivosDev.GetRowCellValue(filaSeleccionada, "Motivo")
        formularioAltasEdicion.descripcion = bgvListaMotivosDev.GetRowCellValue(filaSeleccionada, "Descripción")
        formularioAltasEdicion.activo = IIf(bgvListaMotivosDev.GetRowCellValue(filaSeleccionada, "Activo") = "SI", True, False)
        formularioAltasEdicion.ShowDialog()
        LlenarListaDevoluciones()

    End Sub

    Public Sub InicializarCombo()
        Dim dtMotivos As New DataTable
        Dim columna As New DataColumn
        columna.Caption = "Motivo"
        columna.ColumnName = "Motivo"
        columna.DataType = GetType(String)
        columna.Unique = False
        columna.AllowDBNull = True
        dtMotivos.Columns.Add(columna)

        columna = New DataColumn
        columna.Caption = "Etiqueta"
        columna.ColumnName = "Etiqueta"
        columna.DataType = GetType(String)
        columna.Unique = False
        columna.AllowDBNull = True
        dtMotivos.Columns.Add(columna)

        Dim fila As DataRow = dtMotivos.NewRow
        dtMotivos.Rows.InsertAt(fila, 0)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_INICIAL_CALIDAD"
        fila(1) = "MOTIVO INICIAL CALIDAD"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_INICIAL_MOTIVOSADMINISTRATIVOS"
        fila(1) = "MOTIVO INICIAL (MOTIVOS ADMINISTRATIVOS)"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_VENTAS_CALIDAD"
        fila(1) = "MOTIVO VENTAS CALIDAD"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_VENTAS_MOTIVOSADMINISTRATIVOS"
        fila(1) = "MOTIVO VENTAS (MOTIVOS ADMINISTRATIVOS)"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_CANCELACIÓN"
        fila(1) = "MOTIVO CANCELACIÓN"
        dtMotivos.Rows.Add(fila)

        cboTipoMotivo.DataSource = dtMotivos
        cboTipoMotivo.DisplayMember = "Etiqueta"
        cboTipoMotivo.ValueMember = "Motivo"
    End Sub

    Private Sub DevolucionCliente_CatalogosMotivos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_DCTE_MOTIVOSDEV", "ALTA_EDICION") Then
            pnlBtnAltas.Visible = True
            pnlBtnAltas.Visible = True
            pnlBtnEliminar.Visible = True
        Else
            pnlBtnAltas.Visible = False
            pnlBtnAltas.Visible = False
            pnlBtnEliminar.Visible = False
        End If

        InicializarCombo()
    End Sub

    Private Sub bgvListaMotivosDev_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvListaMotivosDev.RowStyle
        Dim residuo As Int16 = e.RowHandle Mod 2
        If residuo = 0 Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvListaMotivosDev_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvListaMotivosDev.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub bgvListaMotivosDev_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvListaMotivosDev.ColumnFilterChanged
        lblNumFiltrados.Text = bgvListaMotivosDev.DataRowCount.ToString("N0")
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub
End Class