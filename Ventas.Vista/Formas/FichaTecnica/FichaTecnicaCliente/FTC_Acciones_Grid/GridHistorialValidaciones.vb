Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Partial Class FichaTecnicaClienteForm


    'RFC CEDIS
    Public Sub poblar_gridHistorialValidaciones(clienteID As Integer, tipoValidacion As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim validacionBU As New Framework.Negocios.ValidacionBU
        Dim historialValidaciones As New DataTable

        historialValidaciones = validacionBU.Datos_TablaValidacion_Cliente(clienteID, tipoValidacion)

        grid.DataSource = historialValidaciones

        gridHistorialValidacionesDiseno(tipoValidacion, grid)

    End Sub

    Private Sub gridHistorialValidacionesDiseno(tipoValidacion As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Header.Caption = "STATUS"
        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "VALIDADOR"
        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "FECHA"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "COMENTARIO"
       

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub asignar_grid_gridHistorialValidaciones(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridHistorialValidaciones = grid

    End Sub

    Private Sub gridHistorialValidaciones_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridHistorialValidaciones.DoubleClickHeader

        If Me.gridHistorialValidaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridHistorialValidaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridHistorialValidaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridHistorialValidaciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridHistorialValidaciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridHistorialValidaciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridHistorialValidaciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridHistorialValidaciones_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridHistorialValidaciones.MouseDoubleClick


        'If gridHistorialValidaciones.ActiveRow Is Nothing Then Return

        'Dim row As UltraGridRow = gridHistorialValidaciones.ActiveRow

        'If row Is Nothing Then Return


        'If CInt(row.Cells(1)) = 1 Then
        '    gboxVentasValidacion.Enabled = False
        '    ListaNombreCoordinadorVentas(0)
        '    cboxVentasValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

        '    dateVentasValidacionFecha.Value = CDate(tabla.Rows(0).Item("clie_validacionfecha_ventas"))

        '    txtVentasValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

        'ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 2 Then

        '    gboxVentasValidacion.Enabled = True
        '    limpiarControles(gboxVentasValidacion)
        '    ListaNombreCoordinadorVentas(usuarioID)
        '    cboxVentasValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))
        '    cboxVentasValidador.Enabled = False
        '    dateVentasValidacionFecha.Value = Now
        '    dateVentasValidacionFecha.Enabled = False

        'End If



    End Sub

    Private Sub gridHistorialValidaciones_MouseClick(sender As Object, e As MouseEventArgs) Handles gridHistorialValidaciones.MouseClick

        If rbtnClienteStatusInactivo.Checked Then Return

        If AreaOperativa <> 10 Then Return

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        mainElement = Me.gridHistorialValidaciones.DisplayLayout.UIElement
        screenPoint = Control.MousePosition
        clientPoint = Me.gridHistorialValidaciones.PointToClient(screenPoint)
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then

                If e.Button <> Windows.Forms.MouseButtons.Right Then Return
                'Dim cms = New ContextMenuStrip
                'Dim item1 = cms.Items.Add("Nuevo Tienda/Embarque/CEDIS")
                'item1.Tag = 1
                'AddHandler item1.Click, AddressOf gridHistorialValidaciones_menuChoice

                'Dim item2 = cms.Items.Add("Editar Tienda/Embarque/CEDIS")
                'item2.Tag = 2
                'AddHandler item2.Click, AddressOf gridHistorialValidaciones_menuChoice

                'cms.Show(Control.MousePosition)

            End If
        End If

    End Sub

    Private Sub gridHistorialValidaciones_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Dim grid As DataTable = gridHistorialValidaciones.DataSource
        Dim row As UltraGridRow = gridHistorialValidaciones.ActiveRow

        If Not IsNothing(row) Then

            If selection = 1 Then ''AGREGAR NUEVO Tienda/Embarque/CEDIS

                limpiarControles(pnlCEDIS)
                asignaStatusControles(pnlCEDIS, True)
                lblCEDISPersonaID_Int.Text = 0
                cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
                cboxCEDISCEDIS.Text = String.Empty
                rbtnCedisEstatusActivo.Checked = True
                asignaStatusControles(tpgCEDISDomicilio, False)
                asignaStatusControles(tpgCEDISEmbarque, False)
                asignaStatusControles(tpgCEDISEmpaque, False)

                ListaPais(cboxCEDISPais)
                ListaEstado(cboxCEDISEstado, cboxCEDISPais.SelectedValue)


                btnBuscarCEDIS.Enabled = False
                btnEditarCEDISDomicilio.Enabled = False
                btnEditarCEDISEmbarque.Enabled = False
                btnEditarCEDISEmpaque.Enabled = False

            End If

            If selection = 2 Then ''EDITAR Tienda/Embarque/CEDIS ACTUAL

                lblCEDISPersonaID_Int.Text = CStr(row.Cells(0).Value)
                cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
                recuperar_datos_Panel_CEDIS(CInt(lblCEDISPersonaID_Int.Text))
                asignaStatusControles(pnlFormCEDIS, True)
                txtCEDISCiudadSicy.Enabled = False
                btnBuscarCEDIS.Enabled = False
                cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple

            End If
        End If



    End Sub

End Class
