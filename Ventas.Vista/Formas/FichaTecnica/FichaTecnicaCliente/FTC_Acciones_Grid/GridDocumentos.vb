Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Class FichaTecnicaClienteForm


    'DOCUMENTOS
    Public Sub poblar_gridDocumentos(claseDocumento As String, clienteID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.VentasPoliticasBU
        Dim Documento, TipoDocumento As New DataTable
        Dim vlTipoDocumento As New ValueList

        Documento = objBU.TablaDocumentosSegunClaseDocumento(claseDocumento, clienteID, AreaOperativa)
        TipoDocumento = objBU.TablaTipoDocumentosSegunClaseDocumento(claseDocumento, AreaOperativa)

        For Each fila As DataRow In TipoDocumento.Rows
            vlTipoDocumento.ValueListItems.Add(fila.Item("tido_tipodocumentoid"), fila.Item("tido_nombre"))
        Next

        grid.DataSource = Documento

        gridDocumentosDiseno(grid)
        grid.DisplayLayout.Bands(0).Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("tido_nombre").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns("tido_nombre").ValueList = vlTipoDocumento
         
    End Sub

    Private Sub gridDocumentosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        If AreaOperativa = 3 Then
            grid.DisplayLayout.Bands(0).Columns(3).Hidden = True
            grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grid.DisplayLayout.Override.RowSelectorWidth = 30
            grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        End If

        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(5).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*DOCUMENTO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*COPIAS"
        grid.DisplayLayout.Bands(0).Columns("ACTIVO").Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        ActivarCeldasGrid(ModoEdicion)
    End Sub

    Private Sub asignar_grid_gridDocumentos(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        gridDocumentos = grid
    End Sub

    Private Sub gridDocumentos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridDocumentos.DoubleClickHeader
        If Me.gridDocumentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridDocumentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridDocumentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridDocumentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridDocumentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridDocumentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridDocumentos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If
    End Sub

    Private Sub gridDocumentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridDocumentos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridDocumentos.ActiveRow) Then Return

            gridDocumentos.ActiveRow.Cells("ACTIVO").Activated = True

            If ValidarCamposvacios_GridDocumento() = True Then
                Return
            End If

            Dim row As UltraGridRow = gridDocumentos.ActiveRow
            Dim Documento_Existente As Boolean = False

            For Each fila As UltraGridRow In gridDocumentos.Rows
                If fila.Index <> gridDocumentos.ActiveRow.Index Then
                    If fila.Cells("tido_nombre").Text = gridDocumentos.ActiveRow.Cells("tido_nombre").Text Then
                        Documento_Existente = True
                    End If
                End If
            Next

            If Documento_Existente = False Then
                Dim NextRowIndex As Integer = gridDocumentos.ActiveRow.Index + 1

                Try
                    If gridDocumentos.ActiveRow.Cells("docl_documentosclienteid").Value = 0 Then
                        gridDocumentos.ActiveRow.Cells("ACTIVO").Value = 0
                        gridDocumentos.ActiveRow.Cells("ACTIVO").Value = 1
                    End If

                    gridDocumentos.ActiveRow.Update()

                    If NextRowIndex <= gridDocumentos.Rows.Count - 1 Then
                        gridDocumentos.DisplayLayout.Rows(NextRowIndex).Selected = True
                    Else
                        gridDocumentos.DisplayLayout.Rows(gridDocumentos.Rows.Count - 1).Selected = True
                    End If
                Catch ex As Exception
                    If Not IsNothing(gridDocumentos.ActiveRow) Then
                        gridDocumentos.ActiveRow.Activated = False
                    End If
                End Try
            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Este tipo de documento ya existe para este cliente.")
            End If
           
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridDocumentos(claseDocumento, cboxClienteCliente.SelectedValue, gridDocumentos)
        End If
    End Sub

    'Private Sub gridDocumentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridDocumentos.KeyPress

    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        If IsNothing(gridDocumentos.ActiveRow) Then Return

    '        Dim NextRowIndex As Integer = gridDocumentos.ActiveRow.Index + 1
    '        Try
    '            gridDocumentos.DisplayLayout.Rows(NextRowIndex).Activated = True
    '            gridDocumentos.DisplayLayout.Rows(NextRowIndex).Selected = True
    '        Catch ex As Exception
    '            gridDocumentos.ActiveRow.Activated = False

    '        End Try

    '    End If

    '    If e.KeyChar = ChrW(Keys.Escape) Then
    '        poblar_gridDocumentos(claseDocumento, cboxClienteCliente.SelectedValue, gridDocumentos)
    '        gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    End If

    'End Sub

    Private Sub gridDocumentos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridDocumentos.BeforeCellUpdate
        If e.Cell.Column.ToString = "TIPO DOCUMENTO" Then
            If gridDocumentos.ActiveRow.Cells("TIPO DOCUMENTO").Value = gridDocumentos.ActiveRow.Cells("TIPO DOCUMENTO").Text Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Function ValidarCamposvacios_GridDocumento() As Boolean
        ValidarCamposvacios_GridDocumento = False

        If String.IsNullOrWhiteSpace(gridDocumentos.ActiveRow.Cells("docl_numerocopias").Value.ToString) Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el número de copias o presione ESCAPE para cancelar esta acción.")
            ValidarCamposvacios_GridDocumento = True
        End If

        If gridDocumentos.ActiveRow.Cells("tido_nombre").Value.ToString = "--Selecciona--" Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el tipo de docto. o presione ESCAPE para cancelar esta acción.")
            ValidarCamposvacios_GridDocumento = True
        End If


        Return ValidarCamposvacios_GridDocumento
    End Function

    Private Sub Agregar_EditarDocumento()
        If gridDocumentos.ActiveRow.DataChanged Then
            Dim Documento_Existente As Boolean = False
            Dim documento As New Entidades.Documento
            Dim tipoDocumento As New Entidades.TipoDocumento
            Dim cliente As New Entidades.Cliente
            Dim objBU As New Negocios.VentasPoliticasBU

            Dim row As UltraGridRow = gridDocumentos.ActiveRow

                documento.documentosclienteid = CInt(gridDocumentos.ActiveRow.Cells("docl_documentosclienteid").Value)
                documento.activo = CBool(gridDocumentos.ActiveRow.Cells("ACTIVO").Text)
                tipoDocumento.tipodocumentoid = row.Cells("tido_nombre").Column.ValueList.GetValue(gridDocumentos.ActiveRow.Cells("tido_nombre").Text, 0)
                If AreaOperativa = 3 Then
                    documento.numerocopias = 0
                Else
                    documento.numerocopias = CInt(gridDocumentos.ActiveRow.Cells("docl_numerocopias").Value)
                End If
                documento.tipodocumento = tipoDocumento
                cliente.clienteid = CInt(gridDocumentos.ActiveRow.Cells("clie_clienteid").Value)

                Try
                If documento.documentosclienteid = 0 Then
                    If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea agregar este documento?") Then
                        objBU.altaDocumentosCliente(documento, cliente)
                    End If
                Else
                    If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea modificar este documento?") Then
                        objBU.editarDocumentosCliente(documento, cliente)
                    End If
                End If
                Catch ex As Exception
                    Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado al tratar de guardar la información del documento. Error:" + ex.Message)
                End Try

                poblar_gridDocumentos(claseDocumento, cboxClienteCliente.SelectedValue, gridDocumentos)
                ActivarCeldasGrid(True)

            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Ya existe este tipo de documento para este cliente")
            End If
    End Sub


    Private Sub gridDocumentos_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridDocumentos.BeforeRowDeactivate
        If gridDocumentos.ActiveRow.IsDataRow Then
            If gridDocumentos.ActiveRow.DataChanged Or gridDocumentos.ActiveRow.Cells("tido_nombre").Text = "--Selecciona--" Then
                If ValidarCamposvacios_GridDocumento() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridDocumentos_Leave(sender As Object, e As EventArgs) Handles gridDocumentos.Leave
        If Not IsNothing(gridDocumentos.ActiveRow) Then
            If gridDocumentos.ActiveRow.IsDataRow Then
                If gridDocumentos.ActiveRow.DataChanged Or gridDocumentos.ActiveRow.Cells("tido_nombre").Text = "--Selecciona--" Then
                    gridDocumentos.ActiveRow.Cells("ACTIVO").Activated = True
                    If ValidarCamposvacios_GridDocumento() = True Then
                        gridDocumentos.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridDocumentos_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridDocumentos.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Framework.Negocios.ContactosBU
        If gridDocumentos.ActiveRow.IsDataRow Then
            If gridDocumentos.ActiveRow.DataChanged Then
                If gridDocumentos.ActiveRow.Cells("tido_nombre").Value <> "--Selecciona--" Then
                    Agregar_EditarDocumento()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gridDocumentos_Enter(sender As Object, e As EventArgs) Handles gridDocumentos.Enter
        Dim objBU As New Negocios.VentasPoliticasBU
        Dim TipoDocumento As New DataTable
        Dim vlTipoDocumento As New ValueList

        TipoDocumento = objBU.TablaTipoDocumentosSegunClaseDocumento(claseDocumento, AreaOperativa)

        For Each fila As DataRow In TipoDocumento.Rows
            vlTipoDocumento.ValueListItems.Add(fila.Item("tido_tipodocumentoid"), fila.Item("tido_nombre"))
        Next

        If Not IsNothing(gridVentasDocumentos.DataSource) Then
            gridVentasDocumentos.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            gridVentasDocumentos.DisplayLayout.Bands(0).Columns(2).ValueList = vlTipoDocumento
        End If
        
    End Sub



    ''Private Sub gridDocumentos_MouseClick(sender As Object, e As MouseEventArgs) Handles gridDocumentos.MouseClick

    ''    If rbtnClienteStatusInactivo.Checked Then Return

    ''    Dim mainElement As UIElement
    ''    Dim element As UIElement
    ''    Dim screenPoint As Point
    ''    Dim clientPoint As Point
    ''    Dim row As UltraGridRow
    ''    Dim cell As UltraGridCell

    ''    mainElement = Me.gridDocumentos.DisplayLayout.UIElement
    ''    screenPoint = Control.MousePosition
    ''    clientPoint = Me.gridDocumentos.PointToClient(screenPoint)
    ''    element = mainElement.ElementFromPoint(clientPoint)

    ''    If element Is Nothing Then Return

    ''    row = element.GetContext(GetType(UltraGridRow))

    ''    If Not row Is Nothing Then
    ''        cell = element.GetContext(GetType(UltraGridCell))

    ''        If Not cell Is Nothing Then

    ''            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    ''            Dim cms = New ContextMenuStrip
    ''            Dim item1 = cms.Items.Add("Nuevo documento")
    ''            item1.Tag = 1
    ''            AddHandler item1.Click, AddressOf gridDocumentos_menuChoice

    ''            Dim item2 = cms.Items.Add("Editar documento")
    ''            item2.Tag = 2
    ''            AddHandler item2.Click, AddressOf gridDocumentos_menuChoice

    ''            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    ''                cms.Show(Control.MousePosition)
    ''            Else
    ''                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    ''                    cms.Show(Control.MousePosition)
    ''                End If
    ''            End If

    ''        End If
    ''    End If

    ''End Sub

    '   Private Sub gridDocumentos_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO DOCUMENTO

    '        Dim grid As DataTable = gridDocumentos.DataSource
    '        Dim tipoDocumento As UltraGridColumn = gridDocumentos.DisplayLayout.Bands(0).Columns(3)

    '        grid.Rows.Add(0, 0, tipoDocumento, 0, CInt(lblClienteSAYID_Int.Text), 0, 0, True)

    '        gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '        'gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Selected = True

    '        Try
    '            gridDocumentos.ActiveRow.Activation = Activation.AllowEdit
    '            If AreaOperativa = 3 Then
    '                'gridDocumentos.ActiveCell = gridContacto.ActiveRow.Cells(2)
    '            Else
    '                gridDocumentos.ActiveCell = gridContacto.ActiveRow.Cells(3)
    '                gridDocumentos.ActiveCell.Selected = True
    '            End If
    '            gridDocumentos.ActiveCell.Activation = Activation.AllowEdit
    '        Catch ex As Exception

    '        End Try

    '        gridDocumentos.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '        gridDocumentos.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '    End If

    '    If selection = 2 Then ''EDITAR DOCUMENTO ACTUAL

    '        For Each row In gridDocumentos.Selected.Rows
    '            Dim i As Integer = gridDocumentos.Rows.Count

    '            gridDocumentos.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridDocumentos_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridDocumentos.BeforeExitEditMode
    '    'Try
    '    '    Dim cellIndex As Integer = gridDocumentos.ActiveCell.Column.Index

    '    '    If gridDocumentos.ActiveRow.DataChanged = False Then
    '    '        If gridDocumentos.ActiveCell.DataChanged = False Then
    '    '            If String.IsNullOrWhiteSpace(gridDocumentos.ActiveCell.Value) Then
    '    '                poblar_gridDocumentos(claseDocumento, cboxClienteCliente.SelectedValue, gridDocumentos)
    '    '                gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    '            End If
    '    '        End If

    '    '    End If
    '    'Catch ex As Exception

    '    'End Try

    'End Sub

    'Private Sub gridDocumentos_AfterRowActivate(sender As Object, e As EventArgs) Handles gridDocumentos.AfterRowActivate
    '    'gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    'For Each row In gridDocumentos.Rows
    '    '    If gridDocumentos.ActiveRow.Cells("docl_documentosclienteid").Value <> 0 Then
    '    '        row.Activation = Activation.NoEdit
    '    '    Else
    '    '        gridDocumentos.ActiveRow.Activation = Activation.AllowEdit
    '    '    End If
    '    'Next
    'End Sub

    '  Private Sub gridDocumentos_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridDocumentos.BeforeRowDeactivate
    '   If gridDocumentos.ActiveRow.IsDataRow Then
    '        If gridDocumentos.ActiveRow.DataChanged Then

    '            Dim documento As New Entidades.Documento
    '            Dim tipoDocumento As New Entidades.TipoDocumento
    '            Dim cliente As New Entidades.Cliente
    '            Dim objBU As New Negocios.VentasPoliticasBU

    '            Dim row As UltraGridRow = gridDocumentos.ActiveRow

    '            documento.documentosclienteid = CInt(gridDocumentos.ActiveRow.Cells(0).Value)

    '            tipoDocumento.tipodocumentoid = row.Cells(2).Column.ValueList.GetValue(gridDocumentos.ActiveRow.Cells(2).Text, 0)

    '            If String.IsNullOrWhiteSpace(gridDocumentos.ActiveRow.Cells(2).Value.ToString) Then
    '                documento.activo = False
    '            Else
    '                documento.activo = True
    '            End If

    '            If AreaOperativa = 3 Then
    '                documento.numerocopias = 0
    '            Else
    '                If String.IsNullOrWhiteSpace(gridDocumentos.ActiveRow.Cells(3).Value.ToString) Then
    '                    e.Cancel = True
    '                Else
    '                    documento.numerocopias = CInt(gridDocumentos.ActiveRow.Cells(3).Value)
    '                End If
    '            End If

    '            documento.tipodocumento = tipoDocumento

    '            cliente.clienteid = CInt(gridDocumentos.ActiveRow.Cells(4).Value)

    '            If documento.documentosclienteid = 0 Then
    '                objBU.altaDocumentosCliente(documento, cliente)
    '            Else
    '                objBU.editarDocumentosCliente(documento, cliente)
    '            End If

    '            poblar_gridDocumentos(claseDocumento, cboxClienteCliente.SelectedValue, gridDocumentos)
    '        End If
    '    End If


    '    'gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    '  End Sub


End Class
