Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Class FichaTecnicaClienteForm



    'HORARIOS - COBRANZA CONTRARECIBO / DIAS DE ENTREGA
    Public Sub poblar_gridHorario(clienteID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim diasBU As New Framework.Negocios.DiasBU
        Dim Contrarecibo As New DataTable
        Dim dias As New DataTable
        Dim tipoHorario As New DataTable

        Dim vlDias As New Infragistics.Win.ValueList
        Dim vlTipoHorario As New Infragistics.Win.ValueList

        Contrarecibo = clientesBU.Datos_TablaContrarecibos(clienteID, AreaOperativa)

        dias = diasBU.TablaDias()

        tipoHorario = clientesBU.Datos_TablaTipoHorario(AreaOperativa)

        For Each fila As DataRow In dias.Rows
            vlDias.ValueListItems.Add(fila.Item("dias_diaid"), fila.Item("dias_nombre"))
        Next

        For Each fila As DataRow In tipoHorario.Rows
            vlTipoHorario.ValueListItems.Add(fila.Item("tiho_tipohorarioid"), fila.Item("tiho_nombre"))
        Next

        grid.DataSource = Contrarecibo

        grid.DisplayLayout.Bands(0).Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns(1).ValueList = vlTipoHorario
        grid.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns(3).ValueList = vlDias


        gridHorarioDiseno(grid)

    End Sub

    Private Sub gridHorarioDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "*TIPO HORARIO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*DÍA"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "*HORARIO"
        grid.DisplayLayout.Bands(0).Columns("hocl_activo").Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("hocl_activo").Style = ColumnStyle.CheckBox

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        If AreaOperativa = 3 Then
            grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grid.DisplayLayout.Override.RowSelectorWidth = 30
            grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        ElseIf AreaOperativa = 1 Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
    End Sub

    Private Sub asignar_grid_gridHorario(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        gridHorario = grid
    End Sub

    Private Sub gridHorario_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridHorario.DoubleClickHeader
        If Me.gridHorario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridHorario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridHorario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridHorario.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridHorario.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridHorario.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridHorario.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If
    End Sub

    Private Sub gridHorario_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridHorario.BeforeCellUpdate
        If gridHorario.ActiveRow.IsDataRow Then
            If e.Cell.Column.ToString = "tiho_nombre" Then
                If gridHorario.ActiveRow.Cells("tiho_nombre").Value = gridHorario.ActiveRow.Cells("tiho_nombre").Text Then
                    e.Cancel = True
                End If
            ElseIf e.Cell.Column.ToString = "dias_nombre" Then
                If gridHorario.ActiveRow.Cells("dias_nombre").Value = gridHorario.ActiveRow.Cells("dias_nombre").Text Then
                    e.Cancel = True
                End If
            End If
            If e.Cell.Column.ToString = "hocl_activo" Then
                If gridHorario.ActiveRow.Cells(0).Value = 0 Then
                    e.Cancel = True
                End If
            End If
        End If
        
    End Sub

    Private Sub gridHorario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridHorario.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridHorario.ActiveRow) Then Return

            gridHorario.ActiveRow.Cells("hocl_horario").Activated = True

            If ValidarCamposVacios_GridHorario() Then Return

            Dim NextRowIndex As Integer = gridHorario.ActiveRow.Index + 1
            gridHorario.ActiveRow.Update()

            Try
                gridHorario.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridHorario.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridHorario.DisplayLayout.Rows(gridHorario.Rows.Count - 1).Activated = True
                gridHorario.DisplayLayout.Rows(gridHorario.Rows.Count - 1).Selected = True
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            If AreaOperativa = 1 Then
                poblar_gridHorario(CInt(lblClienteSAYID_Int.Text), gridAlmacenDiasEntrega)
                Activar_Inactivar_grids(gridHorario, ModoEdicion_Almacen)
            Else
                poblar_gridHorario(CInt(lblClienteSAYID_Int.Text), gridCobranzaContrarecibo)
                Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
            End If
        End If
    End Sub

    Private Sub gridHorario_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridHorario.BeforeRowDeactivate
        If gridHorario.ActiveRow.IsDataRow Then
            If gridHorario.ActiveRow.DataChanged Or gridHorario.ActiveRow.Cells(0).Value = 0 Then
                If ValidarCamposVacios_GridHorario() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridHorario_Leave(sender As Object, e As EventArgs) Handles gridHorario.Leave
        If Not IsNothing(gridHorario.ActiveRow) Then
            If gridHorario.ActiveRow.IsDataRow Then
                If gridHorario.ActiveRow.DataChanged Or gridHorario.ActiveRow.Cells(0).Value = 0 Then
                    If ValidarCamposVacios_GridHorario() = True Then
                        gridHorario.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridHorario_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridHorario.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Framework.Negocios.ContactosBU
        If gridHorario.ActiveRow.IsDataRow Then
            If gridHorario.ActiveRow.DataChanged Then
                If gridHorario.ActiveRow.Cells("tiho_nombre").Value <> "--Selecciona--" Or gridHorario.ActiveRow.Cells("dias_nombre").Value <> "--Selecciona--" Then
                    ActualizarAgregar_Horarios_GridHorario()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ValidarCamposVacios_GridHorario() As Boolean
        ValidarCamposVacios_GridHorario = False

        If gridHorario.ActiveRow.Cells("hocl_horario").Text = "" Then
            ValidarCamposVacios_GridHorario = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el horario o presione  'ESCAPE' para cancelar esta acción.")
        ElseIf gridHorario.ActiveRow.Cells("tiho_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_GridHorario = True
            Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el dia o presione  'ESCAPE' para cancelar esta acción.")
        ElseIf gridHorario.ActiveRow.Cells("dias_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_GridHorario = True
            Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el tipo de horario o presione  'ESCAPE' para cancelar esta acción.")
        End If

        Return ValidarCamposVacios_GridHorario
    End Function

    Private Sub ActualizarAgregar_Horarios_GridHorario()
        Dim horario As New Entidades.HorarioContrarecibo
        Dim dia As New Entidades.Dias
        Dim tipoHorario As New Entidades.TipoHorario
        Dim cliente As New Entidades.Cliente
        Dim objBU As New Negocios.ClientesDatosBU
        Dim row As UltraGridRow = gridHorario.ActiveRow

        If Mensajes_Y_Alertas("CONFIRMACION", "¿ Desea guardar los cambios realizados ?") Then
            If IsDBNull(gridHorario.ActiveRow.Cells("hocl_diascontrareciboID").Value) Then
                Exit Sub
            Else
                horario.diascontrareciboid = CInt(gridHorario.ActiveRow.Cells("hocl_diascontrareciboID").Value)
            End If

            dia.diaid = row.Cells("dias_nombre").Column.ValueList.GetValue(gridHorario.ActiveRow.Cells("dias_nombre").Text, 0)
            horario.dias = dia
            tipoHorario.tipohorarioid = row.Cells("tiho_nombre").Column.ValueList.GetValue(gridHorario.ActiveRow.Cells("tiho_nombre").Text, 0)
            horario.tipohorario = tipoHorario
            cliente.clienteid = CInt(gridHorario.ActiveRow.Cells("hocl_clienteid").Value)
            horario.cliente = cliente

            If String.IsNullOrWhiteSpace(gridHorario.ActiveRow.Cells("hocl_horario").Text.ToString) Then
                horario.horario = String.Empty
            Else
                horario.horario = gridHorario.ActiveRow.Cells(5).Text.ToString
            End If

            horario.activo = gridHorario.ActiveRow.Cells("HOCL_ACTIVO").Text.ToString

            If horario.diascontrareciboid = 0 Then
                objBU.AltaHorarioContrarecibo(horario)
            Else
                objBU.EditarHorarioContrarecibo(horario)
            End If

            If AreaOperativa = 1 Then
                poblar_gridHorario(CInt(cboxClienteCliente.SelectedValue), gridAlmacenDiasEntrega)
                Activar_Inactivar_grids(gridHorario, ModoEdicion_Almacen)
            Else
                poblar_gridHorario(CInt(cboxClienteCliente.SelectedValue), gridCobranzaContrarecibo)
                Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
            End If

        End If

    End Sub




    'Private Sub gridHorario_MouseClick(sender As Object, e As MouseEventArgs) Handles gridHorario.MouseClick

    '    'If rbtnClienteStatusInactivo.Checked Then Return

    '    'Dim mainElement As UIElement
    '    'Dim element As UIElement
    '    'Dim screenPoint As Point
    '    'Dim clientPoint As Point
    '    'Dim row As UltraGridRow
    '    'Dim cell As UltraGridCell

    '    'mainElement = Me.gridHorario.DisplayLayout.UIElement
    '    'screenPoint = Control.MousePosition
    '    'clientPoint = Me.gridHorario.PointToClient(screenPoint)
    '    'element = mainElement.ElementFromPoint(clientPoint)

    '    'If element Is Nothing Then Return

    '    'row = element.GetContext(GetType(UltraGridRow))

    '    'If Not row Is Nothing Then
    '    '    cell = element.GetContext(GetType(UltraGridCell))

    '    '    If Not cell Is Nothing Then

    '    '        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '    '        Dim cms = New ContextMenuStrip
    '    '        Dim item1 = cms.Items.Add("Nuevo horario")
    '    '        item1.Tag = 1
    '    '        AddHandler item1.Click, AddressOf gridHorario_menuChoice

    '    '        Dim item2 = cms.Items.Add("Editar horario")
    '    '        item2.Tag = 2
    '    '        AddHandler item2.Click, AddressOf gridHorario_menuChoice

    '    '        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '    '            cms.Show(Control.MousePosition)
    '    '        Else
    '    '            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '    '                cms.Show(Control.MousePosition)
    '    '            End If
    '    '        End If

    '    '    End If
    '    'End If

    'End Sub

    'Private Sub gridHorario_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO HORARIO

    '        Dim grid As DataTable = gridHorario.DataSource
    '        Dim row As UltraGridRow = gridHorario.ActiveRow
    '        Dim dias As UltraGridColumn = gridHorario.DisplayLayout.Bands(0).Columns(3)
    '        Dim tipoHorario As UltraGridColumn = gridHorario.DisplayLayout.Bands(0).Columns(1)

    '        If Not IsNothing(row) Then

    '            grid.Rows.Add(0, tipoHorario, 0, dias, 0, String.Empty, CInt(lblClienteSAYID_Int.Text))

    '            gridHorario.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridHorario.ActiveRow.Activation = Activation.AllowEdit
    '                gridHorario.ActiveCell = gridHorario.ActiveRow.Cells(1)
    '                gridHorario.ActiveCell.Activation = Activation.AllowEdit
    '            Catch ex As Exception

    '            End Try

    '            gridHorario.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridHorario.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '        End If

    '    End If

    '    If selection = 2 Then ''EDITAR HORARIO ACTUAL

    '        For Each row In gridHorario.Selected.Rows
    '            Dim i As Integer = gridHorario.Rows.Count

    '            gridHorario.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridHorario.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridHorario_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridHorario.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridHorario.ActiveCell.Column.Index

    '        If gridHorario.ActiveRow.DataChanged Then

    '        Else
    '            If gridHorario.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridHorario.ActiveCell.Value) Then
    '                    poblar_gridHorario(CInt(cboxClienteCliente.SelectedValue), gridCobranzaContrarecibo)
    '                    gridHorario.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridHorario_AfterRowActivate(sender As Object, e As EventArgs) Handles gridHorario.AfterRowActivate
    '    gridHorario.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridHorario.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

End Class
