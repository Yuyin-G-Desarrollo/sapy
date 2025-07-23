Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Class FichaTecnicaClienteForm


    'RFC CEDIS
    Public Sub poblar_gridClienteRFCCEDIS(personaID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)


        grid.DataSource = Nothing
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None

        Dim objBU As New Negocios.ClientesDatosBU
        Dim clienteRFCCEDIS As New DataTable

        clienteRFCCEDIS = objBU.Datos_ClienteRFCCEDIS(personaID, AreaOperativa)

        grid.DataSource = clienteRFCCEDIS

        gridClienteRFCCEDISDiseno(grid)
        grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    End Sub

    Private Sub gridClienteRFCCEDISDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        If grid.Rows.Count = 0 Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(3).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(7).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "RAMO"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "NOMBRE"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "DIRECCIÓN"
        grid.DisplayLayout.Bands(0).Columns(9).Header.Caption = "STATUS"
        'grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "MENSAJERÍA"
        grid.DisplayLayout.Bands(0).Columns(10).Header.Caption = "TIPO DE FLETE"
        grid.DisplayLayout.Bands(0).Columns(11).Header.Caption = "REEMBARQUE"
        grid.DisplayLayout.Bands(0).Columns(12).Header.Caption = "VALOR A DECLARAR"
        grid.DisplayLayout.Bands(0).Columns(13).Header.Caption = "CONVENIO CLIENTE"
        grid.DisplayLayout.Bands(0).Columns(14).Header.Caption = "SEGURO"
        grid.DisplayLayout.Bands(0).Columns(15).Header.Caption = "PÓLIZA"
        grid.DisplayLayout.Bands(0).Columns(16).Header.Caption = "FORMA DE EMPAQUE"
        grid.DisplayLayout.Bands(0).Columns(17).Header.Caption = "RFC"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub asignar_grid_gridClienteRFCCEDIS(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridClienteRFCCEDIS = grid

    End Sub

    Private Sub gridClienteRFCCEDIS_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridClienteRFCCEDIS.DoubleClickHeader

        If Me.gridClienteRFCCEDIS.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridClienteRFCCEDIS.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    'Private Sub gridClienteRFCCEDIS_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridClienteRFCCEDIS.MouseDoubleClick

    '    If AreaOperativa = 9 Then Return

    '    If gridClienteRFCCEDIS.ActiveRow Is Nothing Then Return

    '    Dim row As UltraGridRow = gridClienteRFCCEDIS.ActiveRow

    '    If row Is Nothing Then Return

    '    Dim personaID As Integer = CInt(row.Cells(0).Value)

    '    If personaID = 0 Then Return

    '    asignaStatusControles(pnlFormCEDIS, False)
    '    recuperar_datos_Panel_CEDIS(personaID)

    '    If Not IsDBNull(row.Cells(7).Value) Then
    '        poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), 0, CInt(row.Cells(7).Value))
    '    Else
    '        poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), CInt(row.Cells(6).Value), 0)
    '    End If

    '    IdCedis = CInt(row.Cells(1).Value)
    '    lblTECPersonaID_Int.Text = CStr(row.Cells(1).Value)

    'End Sub

    Private Sub gridClienteRFCCEDIS_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridClienteRFCCEDIS.ClickCell
        If gridClienteRFCCEDIS.ActiveRow.IsDataRow Then
            If modoEdicion_CEDIS = True Then
                Mensajes_Y_Alertas("ADVERTENCIA", "Guarde o cancele los cambios realizados antes de intentar agregar un nuevo CEDIS.")
                Return
            End If
            'If rbtnClienteStatusInactivo.Checked Then Return

            If AreaOperativa = 9 Then Return

            If gridClienteRFCCEDIS.ActiveRow Is Nothing Then Return

            Dim row As UltraGridRow = gridClienteRFCCEDIS.ActiveRow

            If row Is Nothing Then Return

            Dim personaID As Integer = CInt(row.Cells(0).Value)

            If personaID = 0 Then Return

            asignaStatusControles(pnlFormCEDIS, False)
            recuperar_datos_Panel_CEDIS(personaID)

            If Not IsDBNull(row.Cells(7).Value) Then
                poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), 0, CInt(row.Cells(7).Value))
            Else
                poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), CInt(row.Cells(6).Value), 0)
            End If

            IdCedis = CInt(row.Cells(1).Value)
            lblTECPersonaID_Int.Text = CStr(row.Cells(1).Value)

            'If AreaOperativa <> 10 Then Return

            'Dim mainElement As UIElement
            'Dim element As UIElement
            'Dim screenPoint As Point
            'Dim clientPoint As Point
            'Dim row As UltraGridRow
            'Dim cell As UltraGridCell

            'mainElement = Me.gridClienteRFCCEDIS.DisplayLayout.UIElement
            'screenPoint = Control.MousePosition
            'clientPoint = Me.gridClienteRFCCEDIS.PointToClient(screenPoint)
            'element = mainElement.ElementFromPoint(clientPoint)

            'If element Is Nothing Then Return

            'row = element.GetContext(GetType(UltraGridRow))

            'If Not row Is Nothing Then
            '    cell = element.GetContext(GetType(UltraGridCell))

            '    If Not cell Is Nothing Then

            '        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            '        Dim cms = New ContextMenuStrip
            '        Dim item1 = cms.Items.Add("Nuevo Tienda/Embarque/CEDIS")
            '        item1.Tag = 1
            '        AddHandler item1.Click, AddressOf gridClienteRFCCEDIS_menuChoice

            '        Dim item2 = cms.Items.Add("Editar Tienda/Embarque/CEDIS")
            '        item2.Tag = 2
            '        AddHandler item2.Click, AddressOf gridClienteRFCCEDIS_menuChoice

            '        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
            '            cms.Show(Control.MousePosition)
            '        Else
            '            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
            '                cms.Show(Control.MousePosition)
            '            End If
            '        End If

            '    End If
            'End If
        End If
    End Sub

    'Private Sub gridClienteRFCCEDIS_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)
    '    Dim grid As DataTable = gridClienteRFCCEDIS.DataSource
    '    Dim row As UltraGridRow = gridClienteRFCCEDIS.ActiveRow

    '    If Not IsNothing(row) Then

    '        If selection = 1 Then ''AGREGAR NUEVO Tienda/Embarque/CEDIS

    '            limpiarControles(pnlCEDIS)
    '            asignaStatusControles(pnlCEDIS, True)
    '            lblCEDISPersonaID_Int.Text = 0
    '            cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
    '            cboxCEDISCEDIS.Text = String.Empty
    '            rbtnCedisEstatusActivo.Checked = True
    '            asignaStatusControles(tpgCEDISDomicilio, False)
    '            asignaStatusControles(tpgCEDISEmbarque, False)
    '            asignaStatusControles(tpgCEDISEmpaque, False)

    '            ListaPais(cboxCEDISPais)
    '            ListaEstado(cboxCEDISEstado, cboxCEDISPais.SelectedValue)
    '            ListaTEC_Sicy(cboxCEDISDistribucionSICY, CInt(txtClienteSICYID.Text), 0, True)


    '            btnBuscarCEDIS.Enabled = False
    '            btnEditarCEDISDomicilio.Enabled = False
    '            btnEditarCEDISEmbarque.Enabled = False
    '            btnEditarCEDISEmpaque.Enabled = False

    '        End If

    '        If selection = 2 Then ''EDITAR Tienda/Embarque/CEDIS ACTUAL

    '            lblCEDISPersonaID_Int.Text = CStr(row.Cells(0).Value)
    '            cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
    '            recuperar_datos_Panel_CEDIS(CInt(lblCEDISPersonaID_Int.Text))
    '            asignaStatusControles(pnlFormCEDIS, True)
    '            txtCEDISCiudadSicy.Enabled = False
    '            btnBuscarCEDIS.Enabled = False
    '            cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple

    '        End If
    '    End If



    'End Sub

End Class
