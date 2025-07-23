Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.SupportDialogs.FilterUIProvider

Partial Class FichaTecnicaClienteForm


    'CLIENTE RFC
    Public Sub poblar_gridClienteRFC(clienteID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable

        clienteRFC = objBU.Datos_Grid_ClienteRFC(clienteID, AreaOperativa)

        grid.DataSource = clienteRFC

        gridClienteRFCDiseno(grid)

    End Sub

    Private Sub gridClienteRFCDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        If AreaOperativa = 9 Then ''RFC
            grid.DisplayLayout.Bands(0).Columns(13).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(14).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(15).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(16).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(17).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(18).Hidden = True
        ElseIf AreaOperativa = 3 Then ''COBRANZA
            grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(9).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(10).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(11).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(12).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(13).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(14).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(15).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(16).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(17).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(18).Hidden = True
        ElseIf AreaOperativa = 12 Then ''PRECIO
            grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(9).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(10).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(11).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(12).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(13).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(14).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(15).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(18).Hidden = True
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "TIPO RFC"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "NOMBRE"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "RAZÓN SOCIAL"
        grid.DisplayLayout.Bands(0).Columns(6).Header.Caption = "DIRECCIÓN"
        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "RFC"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "CURP"
        grid.DisplayLayout.Bands(0).Columns(9).Header.Caption = "EMAIL"
        grid.DisplayLayout.Bands(0).Columns(10).Header.Caption = "% FACTURAR"
        grid.DisplayLayout.Bands(0).Columns(11).Header.Caption = "RFC A FACT."
        grid.DisplayLayout.Bands(0).Columns(12).Header.Caption = "ACTIVO"
        grid.DisplayLayout.Bands(0).Columns(13).Header.Caption = "PARCIALIDADES"
        grid.DisplayLayout.Bands(0).Columns(14).Header.Caption = "PARCIALIDADES"
        grid.DisplayLayout.Bands(0).Columns(15).Header.Caption = "METODO PAGO"
        grid.DisplayLayout.Bands(0).Columns(16).Header.Caption = "MONEDA"
        grid.DisplayLayout.Bands(0).Columns(17).Header.Caption = "TIPO IVA"
        grid.DisplayLayout.Bands(0).Columns(18).Header.Caption = "TIPO CLIENTE"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

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

    Private Sub asignar_grid_gridClienteRFC(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridClienteRFC = grid

    End Sub

    Private Sub gridClienteRFC_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridClienteRFC.DoubleClickHeader
        Dim ugFilter As New UltraGridFilterUIProvider

        If gridClienteRFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            gridClienteRFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            gridClienteRFC.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            gridClienteRFC.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            gridClienteRFC.DisplayLayout.Override.FilterUIProvider = ugFilter
            gridClienteRFC.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            gridClienteRFC.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
            gridClienteRFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            gridClienteRFC.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            gridClienteRFC.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridClienteRFC_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridClienteRFC.ClickCell
        ''ACCION ANTERIOR AL DAR DOBLE CLICK SOBRE UNA FILA DEL GRID

        Me.Cursor = Cursors.WaitCursor
        If gridClienteRFC.ActiveRow Is Nothing Then Return
        If gridClienteRFC.ActiveRow.IsFilterRow Then Return

        ModoEdicion = False

        Dim row As UltraGridRow = gridClienteRFC.ActiveRow
        If row.IsDataRow = False Then Return
        If row.IsFilterRow = True Then Return
        If row Is Nothing Then Return

        Dim personaID As Integer = CInt(row.Cells(0).Value)

        If personaID = 0 Then Return
        lblContabilidadRFCPersonaID_Int.Text = CStr(personaID)
        If AreaOperativa = 9 Then

            poblar_gridRFCTelefono(personaID)
            poblar_gridRFCEmails(personaID)

            poblar_gridClienteRFCCEDIS(CInt(row.Cells(1).Value), gridRFCEmbarqueCEDIS)
            asignar_grid_gridClienteRFCCEDIS(gridRFCEmbarqueCEDIS)
            recuperar_datos_Panel_RFC(personaID)

            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnRFC_AltaCorreo.Enabled = True
                btnRFC_AltaTelefono.Enabled = True
                ''ACTIVAR LAS FILAS DEL GRID DE CORREOS
                For Each row In gridRFCEmails.Rows
                    Dim i As Integer = gridRFCEmails.Rows.Count
                    gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                    gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                Next

                '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
                For Each row In gridRFCTelefono.Rows
                    Dim i As Integer = gridRFCTelefono.Rows.Count
                    gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                    gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                Next
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnRFC_AltaCorreo.Enabled = True
                    btnRFC_AltaTelefono.Enabled = True
                    ''ACTIVAR LAS FILAS DEL GRID DE CORREOS
                    For Each row In gridRFCEmails.Rows
                        Dim i As Integer = gridRFCEmails.Rows.Count
                        gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                        gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                    Next

                    '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
                    For Each row In gridRFCTelefono.Rows
                        Dim i As Integer = gridRFCTelefono.Rows.Count
                        gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                        gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                    Next
                End If
            End If


        ElseIf AreaOperativa = 3 Then
            recuperar_datos_Panel_Cobranza_Contabilidad(personaID)
            recuperar_datos_Panel_Cobranza_EvalInfoCredito(personaID)
            RecuperarInfo_MetodoFormaPago_NotaCredito(CInt(lblClienteSAYID_Int.Text))
        End If

        ''ACCION ANTERIOR EN LA OPCION DE CLICK DERECHO EN EL GRID
        If Not IsDBNull(row.Cells(0).Value) Then
            'Dim rfc As PanelRFC
            If rbtnRFCTipoRFCRemision.Checked Then
                cboxRFCRFCAFacturar.Enabled = True
            Else
                cboxRFCRFCAFacturar.Enabled = False
            End If

        End If
        ''If Not AreaOperativa = 9 Or Not AreaOperativa = 12 Then Return
        'If rbtnClienteStatusInactivo.Checked Then Return

        'Dim mainElement As UIElement
        'Dim element As UIElement
        'Dim screenPoint As Point
        'Dim clientPoint As Point
        'Dim row As UltraGridRow
        'Dim cell As UltraGridCell

        'mainElement = Me.gridClienteRFC.DisplayLayout.UIElement
        'screenPoint = Control.MousePosition
        'clientPoint = Me.gridClienteRFC.PointToClient(screenPoint)
        'element = mainElement.ElementFromPoint(clientPoint)

        'If element Is Nothing Then Return
        'row = element.GetContext(GetType(UltraGridRow))
        'If Not row Is Nothing Then
        '    cell = element.GetContext(GetType(UltraGridCell))
        '    If AreaOperativa = 9 Then
        '        If Not cell Is Nothing Then
        '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
        '            Dim cms = New ContextMenuStrip
        '            Dim item1 = cms.Items.Add("Nuevo RFC")
        '            item1.Tag = 1
        '            AddHandler item1.Click, AddressOf gridClienteRFC_menuChoice
        '            Dim item2 = cms.Items.Add("Editar RFC")
        '            item2.Tag = 2
        '            AddHandler item2.Click, AddressOf gridClienteRFC_menuChoice
        '            Dim item4 = cms.Items.Add("Vincular Tienda/Embarque/CEDIS")
        '            item4.Tag = 4
        '            AddHandler item4.Click, AddressOf gridClienteRFC_menuChoice
        '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '                cms.Show(Control.MousePosition)
        '            Else
        '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '                    cms.Show(Control.MousePosition)
        '                End If
        '            End If
        '        End If
        '    End If
        '    'If AreaOperativa = 12 Then
        '    If AreaOperativa = 3 Then
        '        If Not cell Is Nothing Then
        '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
        '            Dim cms = New ContextMenuStrip
        '            Dim item3 = cms.Items.Add("Editar RFC")
        '            item3.Tag = 3
        '            AddHandler item3.Click, AddressOf gridClienteRFC_menuChoice
        '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '                cms.Show(Control.MousePosition)
        '            Else
        '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '                    cms.Show(Control.MousePosition)
        '                End If
        '            End If
        '        End If
        '    End If
        'End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCEDITAR") Then
            btnEditarRFC.Enabled = True
        Else
            btnEditarRFC.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCALTAS") Then
            btnRFCAltaRFC.Enabled = True
        Else
            btnRFCAltaRFC.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCVINCULAR") Then
            btnRFCVincularTECs.Enabled = True
        Else
            btnRFCVincularTECs.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "CONTABILIDADEDITAR") Then
            btnEditarCobranzaContabilidad.Enabled = True
        Else
            btnEditarCobranzaContabilidad.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub



    'Private Sub gridClienteRFC_menuChoice(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)
    '    Dim grid As DataTable = gridClienteRFC.DataSource
    '    Dim row As UltraGridRow = gridClienteRFC.ActiveRow

    '    If selection = 1 Then ''AGREGAR NUEVO RFC

    '        limpiarControles(pnlFormRFC)
    '        asignaStatusControles(pnlFormRFC, True)

    '        pnlRFCTipoRFC.Enabled = True
    '        pnlRFCTipoPersona.Enabled = True

    '        If Not pnlRFCTipoRFC.Enabled Then Return

    '        If rbtnRFCTipoRFCRemision.Checked Then
    '            cboxRFCRFCAFacturar.Enabled = True
    '        Else
    '            cboxRFCRFCAFacturar.Enabled = False
    '        End If

    '        rbtnRFCEstatusActivo.Checked = True

    '        ListaRamos(cboxRFCRamo)
    '        'ListaRutas(cboxRFCRuta)
    '        ListaPais(cboxRFCPais)
    '        ListaEstado(cboxRFCEstado, cboxRFCPais.SelectedValue)
    '        ListaClienteRFCFactura(cboxRFCRFCAFacturar, CInt(lblClienteSAYID_Int.Text))
    '        ListaIncoterms(cboxRFCIncoterm)
    '        ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), 0, True)



    '        lblRFCPersonaID_Int.Text = 0

    '    End If

    '    If selection = 2 Then ''EDITAR RFC ACTUAL
    '        'Dim grid As DataTable = gridClienteRFC.DataSource
    '        'Dim row As UltraGridRow = gridClienteRFC.ActiveRow
    '        If Not IsDBNull(row.Cells(0).Value) Then
    '            'Dim rfc As PanelRFC
    '            'rfc.recuperar_datos_Panel_RFC(CInt(row.Cells(0).Value))
    '            recuperar_datos_Panel_RFC(CInt(row.Cells(0).Value))
    '            asignaStatusControles(pnlFormRFC, True)
    '            pnlRFCTipoRFC.Enabled = False
    '            pnlRFCTipoPersona.Enabled = False

    '            If rbtnRFCTipoRFCRemision.Checked Then
    '                cboxRFCRFCAFacturar.Enabled = True
    '            Else
    '                cboxRFCRFCAFacturar.Enabled = False
    '            End If

    '        End If

    '    End If

    '    If selection = 3 Then ''EDITAR RFC ACTUAL
    '        'Dim row As UltraGridRow = gridClienteRFC.ActiveRow
    '        If row Is Nothing Then Return

    '        Dim personaID As Integer = CInt(row.Cells(0).Value)

    '        If personaID = 0 Then Return
    '        lblContabilidadRFCPersonaID_Int.Text = CStr(personaID)

    '        'recuperar_datos_Panel_Cobranza_Precio(personaID)

    '        recuperar_datos_Panel_Cobranza_Contabilidad(personaID)
    '        recuperar_datos_Panel_Cobranza_EvalInfoCredito(personaID)

    '        asignaStatusControles(tpgCobranzaContabilidad, True)
    '        btnEditarCobranzaContabilidad.Enabled = False
    '        btnGuardarCobranzaContabilidad.Enabled = True
    '        btnCancelarCobranzaContabilidad.Enabled = True

    '    End If


    '    If selection = 4 Then ''Vincular Tienda/Embarque/CEDIS ACTUAL

    '        If AreaOperativa <> 9 Then Return

    '        If gridClienteRFC.ActiveRow Is Nothing Then Return

    '        Dim personaID As Integer = CInt(row.Cells(0).Value)

    '        If personaID = 0 Then Return

    '        Dim vinculacion As New VinculacionTEC_RFC_Form
    '        vinculacion.rfcID = CInt(row.Cells(1).Value)
    '        vinculacion.rfc = row.Cells(4).Text + " (" + row.Cells(8).Text + ")"
    '        vinculacion.clienteID = CInt(lblClienteSAYID_Int.Text)
    '        vinculacion.ShowDialog()

    '    End If


    'End Sub

End Class
