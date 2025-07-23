Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Class FichaTecnicaClienteForm



    'METODOS DE PAGO
    Public Sub poblar_gridCobranzaFormasPago(clienteID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.MetodoPagoBU
        Dim MetodoPago, tipoPago As New DataTable
        Dim vltipoPago As New ValueList

        MetodoPago = objBU.Datos_TablaMetodoPago(clienteID)
        tipoPago = objBU.ListadoMetodoPago()

        For Each fila As DataRow In tipoPago.Rows
            vltipoPago.ValueListItems.Add(fila.Item("mepa_metodopagoid"), fila.Item("mepa_nombre"))
        Next

        grid.DataSource = MetodoPago

        grid.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns(2).ValueList = vltipoPago

        gridCobranzaFormasPagoDiseno(grid)

    End Sub

    Private Sub gridCobranzaFormasPagoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        If AreaOperativa = 3 Then
            grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grid.DisplayLayout.Override.RowSelectorWidth = 30
            grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        End If

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*MÉTODO DE PAGO"
        grid.DisplayLayout.Bands(0).Columns("mpcl_activo").Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        Activar_Inactivar_grids(grid, ModoEdicion_CreditoConbranza)

    End Sub

    Private Sub asignar_grid_gridCobranzaFormasPago(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridCobranzaFormasPago = grid

    End Sub

    Private Sub gridCobranzaFormasPago_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridCobranzaFormasPago.DoubleClickHeader

        If Me.gridCobranzaFormasPago.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridCobranzaFormasPago.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridCobranzaFormasPago.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridCobranzaFormasPago.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridCobranzaFormasPago.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridCobranzaFormasPago.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridCobranzaFormasPago.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridCobranzaFormasPago_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridCobranzaFormasPago.BeforeCellUpdate
        If gridCobranzaFormasPago.ActiveRow.IsDataRow Then
            If e.Cell.Column.ToString = "mepa_nombre" Then
                If gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Value = gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Text Then
                    e.Cancel = True
                Else
                    For Each row As UltraGridRow In gridCobranzaFormasPago.Rows
                        If row.Index <> gridCobranzaFormasPago.ActiveRow.Index Then
                            If row.Cells("mepa_nombre").Text.Trim = gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Text Then
                                e.Cancel = True
                                ''gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Value = "--Seleccione--"
                                Mensajes_Y_Alertas("ADVERTENCIA", "Esta forma de pago ya ha sido dada de alta anteriormente, seleccione otra o presiones 'ESCAPE' para cancelar esta acción.")
                            End If
                        End If
                    Next
                End If
            End If
            If e.Cell.Column.ToString = "mpcl_activo" Then
                If gridCobranzaFormasPago.ActiveRow.Cells(0).Value = 0 Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub gridCobranzaFormasPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridCobranzaFormasPago.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            If IsNothing(gridCobranzaFormasPago.ActiveRow) Then Return

            gridCobranzaFormasPago.ActiveRow.Cells("mpcl_activo").Selected = True
            gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Selected = True

            If ValidarCamposVacios_gridCobranzaFormasPago() Then Return

            gridCobranzaFormasPago.ActiveRow.Cells("mpcl_activo").Activated = True

            gridCobranzaFormasPago.ActiveRow.Update()

            'If IsNothing(gridCobranzaFormasPago.ActiveRow) Then Return

            'Dim NextRowIndex As Integer = gridCobranzaFormasPago.ActiveRow.Index + 1
            'Try
            '    gridCobranzaFormasPago.DisplayLayout.Rows(NextRowIndex).Activated = True
            '    gridCobranzaFormasPago.DisplayLayout.Rows(NextRowIndex).Selected = True
            'Catch ex As Exception
            '    gridCobranzaFormasPago.ActiveRow.Activated = False

            'End Try

        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridCobranzaFormasPago(cboxClienteCliente.SelectedValue, gridCobranzaFormasPago)
            Activar_Inactivar_grids(gridCobranzaFormasPago, ModoEdicion_CreditoConbranza)
        End If

    End Sub

    Private Sub gridCobranzaFormasPago_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridCobranzaFormasPago.BeforeRowDeactivate
        If gridCobranzaFormasPago.ActiveRow.IsDataRow Then
            If gridCobranzaFormasPago.ActiveRow.DataChanged Or gridCobranzaFormasPago.ActiveRow.Cells(0).Value = 0 Then
                If ValidarCamposVacios_gridCobranzaFormasPago() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridCobranzaFormasPago_Leave(sender As Object, e As EventArgs) Handles gridCobranzaFormasPago.Leave
        If Not IsNothing(gridCobranzaFormasPago.ActiveRow) Then
            If gridCobranzaFormasPago.ActiveRow.IsDataRow Then
                If gridCobranzaFormasPago.ActiveRow.DataChanged Or gridCobranzaFormasPago.ActiveRow.Cells(0).Value = 0 Then
                    If ValidarCamposVacios_gridCobranzaFormasPago() = True Then
                        gridCobranzaFormasPago.Focus()
                        Return
                    End If
                End If
            End If
            
        End If
    End Sub

    Private Sub gridCobranzaFormasPago_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridCobranzaFormasPago.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor

        If gridCobranzaFormasPago.ActiveRow.IsDataRow Then
            If gridCobranzaFormasPago.ActiveRow.DataChanged Then
                If gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Value <> "--Selecciona--" Then
                    Agregar_Actualzar_gridCobranzaFormasPago()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Agregar_Actualzar_gridCobranzaFormasPago()
        Dim objBU As New Negocios.MetodoPagoBU
        Dim metodopagoclienteid As Integer
        Dim metodopagoid As Integer
        Dim clienteid As Integer
        Dim activo As Boolean

        Try
            Dim row As UltraGridRow = gridCobranzaFormasPago.ActiveRow
            metodopagoclienteid = CInt(gridCobranzaFormasPago.ActiveRow.Cells(0).Value)
            metodopagoid = row.Cells("mepa_nombre").Column.ValueList.GetValue(gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Text, 0)

            If metodopagoclienteid = 0 Then
                activo = True
            Else
                activo = CBool(row.Cells("mpcl_activo").Text)
            End If

            clienteid = CInt(lblClienteSAYID_Int.Text)

            If Mensajes_Y_Alertas("CONFIRMACION", "¿Desea guardar los cambios realizados?") Then
                If metodopagoclienteid = 0 Then
                    objBU.altaMetodoPagoCliente(metodopagoid, clienteid)
                Else
                    objBU.editarMetodoPagoCliente(metodopagoclienteid, metodopagoid, activo)
                End If
            End If
        Catch ex As Exception
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Erroe: " + ex.Message)
        End Try

        poblar_gridCobranzaFormasPago(cboxClienteCliente.SelectedValue, gridCobranzaFormasPago)
    End Sub

    Private Function ValidarCamposVacios_gridCobranzaFormasPago() As Boolean
        ValidarCamposVacios_gridCobranzaFormasPago = False

        If gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_gridCobranzaFormasPago = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione el método de pago o presione  'ESCAPE' para cancelar esta acción.")
        End If

        For Each row As UltraGridRow In gridCobranzaFormasPago.Rows
            If row.Index <> gridCobranzaFormasPago.ActiveRow.Index Then
                If row.Cells("mepa_nombre").Text.Trim = gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Text Then
                    ValidarCamposVacios_gridCobranzaFormasPago = True
                    ''    gridCobranzaFormasPago.ActiveRow.Cells("mepa_nombre").Value = "--Seleccione--"
                    ''Mensajes_Y_Alertas("ADVERTENCIA", "Esta forma de pago ya ha sido dada de alta anteriormente, seleccione otra o presiones 'ESCAPE' para cancelar esta acción.")
                End If
            End If
        Next

        Return ValidarCamposVacios_gridCobranzaFormasPago
    End Function

    

    'Private Sub gridCobranzaFormasPago_MouseClick(sender As Object, e As MouseEventArgs) Handles gridCobranzaFormasPago.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridCobranzaFormasPago.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridCobranzaFormasPago.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nueva forma de pago")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridCobranzaFormasPago_menuChoice

    '            Dim item2 = cms.Items.Add("Editar forma de pago")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridCobranzaFormasPago_menuChoice

    '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '                cms.Show(Control.MousePosition)
    '            Else
    '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                    cms.Show(Control.MousePosition)
    '                End If
    '            End If

    '        End If
    '    End If

    'End Sub

    'Private Sub gridCobranzaFormasPago_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO DOCUMENTO

    '        Dim grid As DataTable = gridCobranzaFormasPago.DataSource
    '        Dim row As UltraGridRow = gridCobranzaFormasPago.ActiveRow
    '        Dim MetodoPago As UltraGridColumn = gridCobranzaFormasPago.DisplayLayout.Bands(0).Columns(2)

    '        If Not IsNothing(row) Then

    '            grid.Rows.Add(0, 0, MetodoPago)

    '            gridCobranzaFormasPago.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridCobranzaFormasPago.ActiveRow.Activation = Activation.AllowEdit
    '                gridCobranzaFormasPago.ActiveCell.Activation = Activation.AllowEdit
    '                gridCobranzaFormasPago.ActiveCell = gridCobranzaFormasPago.ActiveRow.Cells(2)
    '            Catch ex As Exception

    '            End Try

    '            gridCobranzaFormasPago.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridCobranzaFormasPago.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '        End If

    '    End If

    '    If selection = 2 Then ''EDITAR DOCUMENTO ACTUAL

    '        For Each row In gridCobranzaFormasPago.Selected.Rows
    '            Dim i As Integer = gridCobranzaFormasPago.Rows.Count

    '            gridCobranzaFormasPago.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridCobranzaFormasPago.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridCobranzaFormasPago_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridCobranzaFormasPago.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridCobranzaFormasPago.ActiveCell.Column.Index

    '        If gridCobranzaFormasPago.ActiveRow.DataChanged Then

    '        Else
    '            If gridCobranzaFormasPago.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridCobranzaFormasPago.ActiveCell.Value) Then
    '                    poblar_gridCobranzaFormasPago(cboxClienteCliente.SelectedValue, gridCobranzaFormasPago)
    '                    gridCobranzaFormasPago.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridCobranzaFormasPago_AfterRowActivate(sender As Object, e As EventArgs) Handles gridCobranzaFormasPago.AfterRowActivate
    '    gridCobranzaFormasPago.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridCobranzaFormasPago.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

    'Private Sub gridCobranzaFormasPago_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridCobranzaFormasPago.BeforeRowDeactivate

    '    If gridCobranzaFormasPago.ActiveRow.DataChanged Then

    '        Dim objBU As New Negocios.MetodoPagoBU

    '        Dim metodopagoclienteid As Integer
    '        Dim metodopagoid As Integer
    '        Dim clienteid As Integer
    '        Dim activo As Boolean

    '        Dim row As UltraGridRow = gridCobranzaFormasPago.ActiveRow

    '        metodopagoclienteid = CInt(gridCobranzaFormasPago.ActiveRow.Cells(0).Value)

    '        metodopagoid = row.Cells(2).Column.ValueList.GetValue(gridCobranzaFormasPago.ActiveRow.Cells(2).Text, 0)

    '        If String.IsNullOrWhiteSpace(gridCobranzaFormasPago.ActiveRow.Cells(2).Value.ToString) Then
    '            activo = False
    '        Else
    '            activo = True
    '        End If

    '        clienteid = CInt(lblClienteSAYID_Int.Text)

    '        If metodopagoclienteid = 0 Then
    '            objBU.altaMetodoPagoCliente(metodopagoid, clienteid)
    '        Else
    '            objBU.editarMetodoPagoCliente(metodopagoclienteid, metodopagoid, activo)
    '        End If

    '        poblar_gridCobranzaFormasPago(cboxClienteCliente.SelectedValue, gridCobranzaFormasPago)

    '    Else

    '    End If

    '    gridCobranzaFormasPago.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub


End Class

