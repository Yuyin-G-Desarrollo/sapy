Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Class FichaTecnicaClienteForm

    Dim editando_politica As Boolean



    'POLITICA
    Public Sub poblar_gridPolitica(editando As Boolean, clientID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        ''gridPolitica.DataSource = Nothing

        Dim objBU As New Framework.Negocios.CondicionesBU
        Dim Politica, Catalogo As New DataTable

        Politica = objBU.Datos_TablaCondicionesClienteArea(editando, clientID, AreaOperativa)

        gridPolitica.DataSource = Politica

        gridPoliticaDiseno(gridPolitica)

        If gridPolitica.Rows.Count > 0 Then
            gridPolitica.Rows(0).Activated = True
        End If

    End Sub

    Private Sub gridPoliticaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(10).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(11).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "TIPO DE POLÍTICA"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "POLÍTICA"
        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "*CATÁLOGO"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "*VALOR"
        grid.DisplayLayout.Bands(0).Columns(9).Header.Caption = "*DESCRIPCIÓN"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        If editando_politica Then
            For Each row In grid.Rows
                If CInt(row.Cells(10).Value) = AreaOperativa And CBool(row.Cells(11).Value) Then
                    row.Activation = Activation.AllowEdit
                Else
                    row.Activation = Activation.NoEdit
                End If
            Next
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
        Else
            For Each row In grid.Rows
                row.Activation = Activation.NoEdit
            Next
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub asignar_grid_gridPolitica(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        gridPolitica = grid
        editando_politica = False
    End Sub

    Private Sub gridPolitica_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridPolitica.DoubleClickHeader

        If Me.gridPolitica.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridPolitica.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridPolitica.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridPolitica.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridPolitica.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridPolitica.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridPolitica.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridPolitica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPolitica.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If editando_politica = True Then
                guardarEdicionPolitica()
                btnAgregarPoliticas_Ventas.Enabled = True
                btnAlmacen_EditarPolitica.Enabled = True
            Else
                Dim NextRowIndex As Integer = gridPolitica.ActiveRow.Index + 1
                Try
                    gridPolitica.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridPolitica.DisplayLayout.Rows(NextRowIndex).Selected = True
                Catch ex As Exception
                    gridPolitica.ActiveRow.Activated = False
                End Try
            End If
            

        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            editando_politica = False
            poblar_gridPolitica(editando_politica, cboxClienteCliente.SelectedValue, gridPolitica)
            gridPolitica.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If
    End Sub

    Private Sub guardarEdicionPolitica()
        editando_politica = False

        If Mensajes_Y_Alertas("CONFIRMACION", "¿Desea guardar los cambios realizados?") Then
            gridPolitica.ActiveRow.Cells(2).Activated = True

            For Each row In gridPolitica.Rows
                Dim PoliticaBU As New Framework.Negocios.CondicionesBU
                Dim condicion As New Entidades.CondicionPersona
                Dim catalogo As New Entidades.CondicionCatalogo

                catalogo.condicioncatalogoid = row.Cells("coca_descripcion").ValueList.GetValue(row.Cells("coca_descripcion").Text, 0)

                If String.IsNullOrWhiteSpace(row.Cells("cope_valor").Text.ToString) Then
                    condicion.valor = String.Empty
                Else
                    condicion.valor = CStr(row.Cells("cope_valor").Text.ToString)
                End If

                If String.IsNullOrWhiteSpace(row.Cells("cope_descripcion").Text.ToString) Then
                    condicion.descripcion = String.Empty
                Else
                    condicion.descripcion = CStr(row.Cells("cope_descripcion").Text.ToString)
                End If

                condicion.condicionpersonaid = CInt(row.Cells("cope_condicionpersonaid").Value)
                condicion.condicioncatalogo = catalogo

                Try
                    PoliticaBU.EditarCondicionPersona(condicion)
                Catch ex As Exception
                    Mensajes_Y_Alertas("ERROR", "ocurrio un error inesperado al tratar de guardar los cambios en las políticas. Error: " + ex.Message)
                End Try

            Next
        End If
        poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
    End Sub

    'Private Sub gridPolitica_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridPolitica.BeforeExitEditMode
    '    'Try
    '    '    Dim cellIndex As Integer = gridPolitica.ActiveCell.Column.Index

    '    '    If gridPolitica.ActiveRow.DataChanged Then

    '    '    Else
    '    '        If gridPolitica.ActiveCell.DataChanged Then
    '    '        Else
    '    '            If String.IsNullOrWhiteSpace(gridPolitica.ActiveCell.Value) Then
    '    '                poblar_gridPolitica(editando_politica, cboxClienteCliente.SelectedValue, gridPolitica)
    '    '                gridPolitica.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    '            End If
    '    '        End If

    '    '    End If
    '    'Catch ex As Exception

    '    'End Try

    'End Sub

    Private Sub gridPolitica_Leave(sender As Object, e As EventArgs) Handles gridPolitica.Leave
        If editando_politica Then
            guardarEdicionPolitica()
        End If
    End Sub

    Private Sub IniciarEdicionPoliticas()
        editando_politica = True 

        poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)

        For Each row In gridPolitica.Rows
            Dim objBU As New Framework.Negocios.CondicionesBU
            Dim Catalogo As New DataTable
            Dim vlCatalogo As New Infragistics.Win.ValueList
            Dim condicion As Integer

            condicion = CInt(row.Cells(4).Value)
            Catalogo = objBU.Datos_TablaCondicionesCatalogoCondicion(condicion, AreaOperativa)

            For Each fila As DataRow In Catalogo.Rows
                vlCatalogo.ValueListItems.Add(fila.Item("coca_condicioncatalogoid"), fila.Item("coca_descripcion"))
                row.Cells(0).Activation = Activation.Disabled
                row.Cells(1).Style = Activation.Disabled
                row.Cells(2).Style = Activation.Disabled
                row.Cells(3).Style = Activation.Disabled
                row.Cells(4).Style = Activation.Disabled
                row.Cells(5).Style = Activation.Disabled
                row.Cells(6).Style = Activation.Disabled
                row.Cells(7).Style = Activation.AllowEdit
                row.Cells(8).Style = Activation.AllowEdit
                row.Cells(9).Style = Activation.AllowEdit
                row.Cells(10).Style = Activation.Disabled
                row.Cells(10).Style = Activation.Disabled
                row.Cells(12).Style = Activation.Disabled
            Next

            row.Cells(7).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            row.Cells(7).ValueList = vlCatalogo
            row.Cells(12).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            row.Cells(12).Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub gridPolitica_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridPolitica.BeforeCellUpdate
        If e.Cell.Column.ToString = "ACTIVO" Then
            e.Cancel = True
        End If
    End Sub
   
    'Private Sub gridPolitica_AfterRowActivate(sender As Object, e As EventArgs) Handles gridPolitica.AfterRowActivate
    '    'gridPolitica.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    'For Each row In gridPolitica.Rows
    '    '    row.Activation = Activation.NoEdit
    '    'Next
    'End Sub

    'Private Sub gridPolitica_MouseClick(sender As Object, e As MouseEventArgs) Handles gridPolitica.MouseClick

    '    'If rbtnClienteStatusInactivo.Checked Then Return

    '    'Dim mainElement As UIElement
    '    'Dim element As UIElement
    '    'Dim screenPoint As Point
    '    'Dim clientPoint As Point
    '    'Dim row As UltraGridRow
    '    'Dim cell As UltraGridCell

    '    'mainElement = Me.gridPolitica.DisplayLayout.UIElement
    '    'screenPoint = Control.MousePosition
    '    'clientPoint = Me.gridPolitica.PointToClient(screenPoint)
    '    'element = mainElement.ElementFromPoint(clientPoint)

    '    'If element Is Nothing Then Return

    '    'row = element.GetContext(GetType(UltraGridRow))

    '    'If Not row Is Nothing Then
    '    '    cell = element.GetContext(GetType(UltraGridCell))

    '    '    If Not cell Is Nothing Then

    '    '        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '    '        Dim cms = New ContextMenuStrip

    '    '        If editando_politica Then
    '    '            Dim item2 = cms.Items.Add("Guardar cambios")
    '    '            item2.Tag = 2
    '    '            AddHandler item2.Click, AddressOf gridPolitica_menuChoice
    '    '        Else
    '    '            Dim item1 = cms.Items.Add("Editar valores por defecto")
    '    '            item1.Tag = 1
    '    '            AddHandler item1.Click, AddressOf gridPolitica_menuChoice
    '    '        End If



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

    'Private Sub gridPolitica_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''EDITAR POLITICA ACTUAL
    '        editando_politica = True
    '        poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)


    '        For Each row In gridPolitica.Rows
    '            Dim objBU As New Framework.Negocios.CondicionesBU
    '            Dim Catalogo As New DataTable
    '            Dim vlCatalogo As New Infragistics.Win.ValueList
    '            Dim condicion As Integer

    '            condicion = CInt(row.Cells(4).Value)
    '            Catalogo = objBU.Datos_TablaCondicionesCatalogoCondicion(condicion, AreaOperativa)

    '            For Each fila As DataRow In Catalogo.Rows
    '                vlCatalogo.ValueListItems.Add(fila.Item("coca_condicioncatalogoid"), fila.Item("coca_descripcion"))
    '            Next

    '            row.Cells(7).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
    '            row.Cells(7).ValueList = vlCatalogo


    '        Next

    '    End If

    '    If selection = 2 Then
    '        editando_politica = False

    '        For Each row In gridPolitica.Rows

    '            'If row.DataChanged Then

    '            Dim PoliticaBU As New Framework.Negocios.CondicionesBU
    '            Dim condicion As New Entidades.CondicionPersona
    '            Dim catalogo As New Entidades.CondicionCatalogo

    '            catalogo.condicioncatalogoid = row.Cells(7).ValueList.GetValue(row.Cells(7).Text, 0)

    '            If String.IsNullOrWhiteSpace(row.Cells(8).Value.ToString) Then
    '                condicion.valor = String.Empty
    '            Else
    '                condicion.valor = CStr(row.Cells(8).Value.ToString)
    '            End If

    '            If String.IsNullOrWhiteSpace(row.Cells(9).Value.ToString) Then
    '                condicion.descripcion = String.Empty
    '            Else
    '                condicion.descripcion = CStr(row.Cells(9).Value.ToString)
    '            End If

    '            condicion.condicionpersonaid = CInt(row.Cells(0).Value)
    '            condicion.condicioncatalogo = catalogo

    '            PoliticaBU.EditarCondicionPersona(condicion)

    '            'End If

    '        Next

    '        poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)

    '    End If

    'End Sub


End Class
