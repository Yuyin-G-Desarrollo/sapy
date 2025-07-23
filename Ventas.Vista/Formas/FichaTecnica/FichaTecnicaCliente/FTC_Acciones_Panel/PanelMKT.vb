Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Public Class FichaTecnicaClienteForm


    Private Sub btnGuardarPanelMKT_Click(sender As Object, e As EventArgs) Handles btnGuardarMKT.Click


        Try
            editar_MKT_Ventas_InfoCliente()
        Catch ex As Exception
            Exit Sub
        End Try

        show_message("Exito", "Información guardada con éxito")

        ModoEdicion_MercaDotecnia = False
        recuperar_datos_Panel_MKT(CInt(lblClienteSAYID_Int.Text))
        CambiarElForeColorControles_Negro(pnlFormMKT)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesMKT)
        CambiarElForeColorControles_DodgerBlue(pnlMKT_ZapateriasCiudad)

        Activar_Inactivar_grids(gridMKTContacto, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTZapaterias, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTTienda, False)
        Activar_Inactivar_grids(gridMKTRamos, False)

        Editando_Mercadotecnia = False
        poblar_gridMKTRamos(CInt(cboxClienteCliente.SelectedValue))
        poblar_gridMKTTienda(CInt(cboxClienteCliente.SelectedValue))
    End Sub

    Private Sub btnEditarMKT_Click(sender As Object, e As EventArgs) Handles btnEditarMKT.Click
        ModoEdicion_MercaDotecnia = True

        asignaStatusControles(pnlFormMKT, True)
        btnGaleriaPanelMKT.Enabled = True

        Activar_Inactivar_grids(gridMKTContacto, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTZapaterias, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
        Activar_Inactivar_grids(gridMKTTienda, False)
        Activar_Inactivar_grids(gridMKTRamos, False)
    End Sub

    Private Sub btnCancelarMKT_Click(sender As Object, e As EventArgs) Handles btnCancelarMKT.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_MercaDotecnia = False

            recuperar_datos_Panel_MKT(CInt(lblClienteSAYID_Int.Text))
            CambiarElForeColorControles_Negro(pnlFormMKT)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesMKT)
            CambiarElForeColorControles_DodgerBlue(pnlMKT_ZapateriasCiudad)

            Activar_Inactivar_grids(gridMKTContacto, ModoEdicion_MercaDotecnia)
            Activar_Inactivar_grids(gridMKTZapaterias, ModoEdicion_MercaDotecnia)
            Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
            Activar_Inactivar_grids(gridMKTTienda, False)
            Activar_Inactivar_grids(gridMKTRamos, False)

            Editando_Mercadotecnia = False
            poblar_gridMKTRamos(CInt(cboxClienteCliente.SelectedValue))
            poblar_gridMKTTienda(CInt(cboxClienteCliente.SelectedValue))
        End If


    End Sub

    Private Sub btnGaleriaPanelMKT_Click(sender As Object, e As EventArgs) Handles btnGaleriaPanelMKT.Click
        Me.Cursor = Cursors.WaitCursor
        Dim galeriaForm As New GaleriaImagenesForm
        galeriaForm.id_carpeta = CInt(lblClienteSAYID_Int.Text)
        galeriaForm.RutaArchivo = "Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text + "/MKT/"
        'galeriaForm.NombreArchivo = lblClienteSAYID_Int.Text + ".jpg"
        galeriaForm.MostrarCarrusel = True
        galeriaForm.AtnClientes = CInt(cboxClienteAtnClientes.SelectedValue)
        galeriaForm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub editar_MKT_Ventas_InfoCliente()

        Dim infoCliente As New Entidades.InformacionClienteVentas
        Dim nivelSocioEconomico As New Entidades.NivelSocioEconomico
        Dim cliente As New Entidades.Cliente
        Dim clienteDatos As New Negocios.ClientesDatosBU

        If Not IsDBNull(cboxMKTNivelSocioEconomico.SelectedValue) Then
            nivelSocioEconomico.nivelsocioeconomicoid = cboxMKTNivelSocioEconomico.SelectedValue
        End If

        cliente.clienteid = cboxClienteCliente.SelectedValue

        infoCliente.nivelsocioeconomico = nivelSocioEconomico
        infoCliente.cliente = cliente

        infoCliente.publicidadcliente = txtMKTPublicidadRegalo.Text

        Try
            clienteDatos.editarVentasInfoCliente(infoCliente, 4)
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
        End Try

    End Sub

    Public Sub recuperar_datos_Panel_MKT(clienteID As Integer)

        limpiarControles(pnlFormMKT)
        asignaStatusControles(pnlFormMKT, False)
        btnGaleriaPanelMKT.Enabled = True

        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        btnEditarMKT.Enabled = False
        '    Else
        '        btnEditarMKT.Enabled = True
        '    End If
        'End If


        If rbtnClienteStatusInactivo.Checked Then
            btnEditarMKT.Enabled = False
        Else
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnEditarMKT.Enabled = True
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarMKT.Enabled = True
                Else
                    btnEditarMKT.Enabled = False
                End If
            End If
        End If


        ''VENTAS INFOCLIENTE

        Dim clienteDatosBU As New Negocios.ClientesDatosBU
        Dim infoClienteVentas As New DataTable
        infoClienteVentas = clienteDatosBU.Datos_TablaVentasInfoCliente(clienteID)

        If infoClienteVentas.Rows.Count > 0 Then

            ListaNivelSocioEconomico(cboxMKTNivelSocioEconomico)
            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_nivelsocioeconomicoid")) Then
                cboxMKTNivelSocioEconomico.Text = String.Empty
            Else
                cboxMKTNivelSocioEconomico.SelectedValue = CInt(infoClienteVentas.Rows(0).Item("ivcl_nivelsocioeconomicoid"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_publicidadcliente")) Then
                txtMKTPublicidadRegalo.Text = String.Empty
            Else
                txtMKTPublicidadRegalo.Text = CStr(infoClienteVentas.Rows(0).Item("ivcl_publicidadcliente"))
            End If

        End If

    End Sub

#Region "MAXIMIZAR_MINIMIZAR GROUPBOX"
    Private Sub gboxMKTContacto_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxMKTContacto.MouseDoubleClick
        If gboxMKTContacto.Dock = DockStyle.Fill Then
            gboxMKTContacto.Dock = DockStyle.None
            gboxMKTTienda.Visible = True
            gboxMKTZapaterias.Visible = True
            gboxMKTMaterialMKT.Visible = True
            gboxMKTRamos.Visible = True
        Else
            gboxMKTContacto.Dock = DockStyle.Fill
            gboxMKTTienda.Visible = False
            gboxMKTZapaterias.Visible = False
            gboxMKTMaterialMKT.Visible = False
            gboxMKTRamos.Visible = False
        End If
    End Sub

    Private Sub gboxMKTTienda_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxMKTTienda.MouseDoubleClick
        If gboxMKTTienda.Dock = DockStyle.Fill Then
            gboxMKTTienda.Dock = DockStyle.None
            gboxMKTContacto.Visible = True
            gboxMKTZapaterias.Visible = True
            gboxMKTMaterialMKT.Visible = True
            gboxMKTRamos.Visible = True
        Else
            gboxMKTTienda.Dock = DockStyle.Fill
            gboxMKTContacto.Visible = False
            gboxMKTZapaterias.Visible = False
            gboxMKTMaterialMKT.Visible = False
            gboxMKTRamos.Visible = False
        End If
    End Sub

    Private Sub gboxMKTZapaterias_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxMKTZapaterias.MouseDoubleClick
        If gboxMKTZapaterias.Dock = DockStyle.Fill Then
            gboxMKTZapaterias.Dock = DockStyle.None
            gboxMKTTienda.Visible = True
            gboxMKTContacto.Visible = True
            gboxMKTMaterialMKT.Visible = True
            gboxMKTRamos.Visible = True
        Else
            gboxMKTZapaterias.Dock = DockStyle.Fill
            gboxMKTTienda.Visible = False
            gboxMKTContacto.Visible = False
            gboxMKTMaterialMKT.Visible = False
            gboxMKTRamos.Visible = False
        End If
    End Sub

    Private Sub gboxMKTMaterialMKT_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxMKTMaterialMKT.MouseDoubleClick
        If gboxMKTMaterialMKT.Dock = DockStyle.Fill Then
            gboxMKTMaterialMKT.Dock = DockStyle.None
            gboxMKTTienda.Visible = True
            gboxMKTContacto.Visible = True
            gboxMKTZapaterias.Visible = True
            gboxMKTRamos.Visible = True
        Else
            gboxMKTMaterialMKT.Dock = DockStyle.Fill
            gboxMKTTienda.Visible = False
            gboxMKTContacto.Visible = False
            gboxMKTZapaterias.Visible = False
            gboxMKTRamos.Visible = False
        End If
    End Sub

    Private Sub gboxMKTRamos_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxMKTRamos.MouseDoubleClick
        If gboxMKTRamos.Dock = DockStyle.Fill Then
            gboxMKTRamos.Dock = DockStyle.None
            gboxMKTTienda.Visible = True
            gboxMKTContacto.Visible = True
            gboxMKTZapaterias.Visible = True
            gboxMKTMaterialMKT.Visible = True
        Else
            gboxMKTRamos.Dock = DockStyle.Fill
            gboxMKTTienda.Visible = False
            gboxMKTContacto.Visible = False
            gboxMKTZapaterias.Visible = False
            gboxMKTMaterialMKT.Visible = False
        End If
    End Sub
#End Region

#Region "GRIDS"

#Region "RAMOS"

    Private Sub btnMKT_EditarRamos_Click(sender As Object, e As EventArgs) Handles btnMKT_EditarRamos.Click
        IniciarEdicion_Ramos()
        btnMKT_EditarRamos.Enabled = False
    End Sub

    Public Sub poblar_gridMKTRamos(clienteID As Integer)
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim ramo As New DataTable

        gridMKTRamos.DataSource = Nothing

        ramo = clientesBU.Datos_TablaRamoCliente(clienteID, AreaOperativa, Editando_Mercadotecnia)
        gridMKTRamos.DataSource = ramo
        gridMKTRamosDiseno(gridMKTRamos)

        If gridMKTRamos.Rows.Count > 0 Then
            gridMKTRamos.Rows(0).Activated = True
        End If
    End Sub

    Private Sub gridMKTRamosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grid.DisplayLayout.Override.RowSelectorWidth = 30
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "RAMO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "# TIENDAS"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*# TIENDAS REAL"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "*MARCAJE"


        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(5).Format = "#.##"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        If Editando_Mercadotecnia Then
            For Each row In grid.Rows
                row.Activation = Activation.AllowEdit
                gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                grid.DisplayLayout.Bands(0).Columns(2).CellClickAction = CellClickAction.CellSelect
                grid.DisplayLayout.Bands(0).Columns(2).CellActivation = Activation.ActivateOnly
                grid.DisplayLayout.Bands(0).Columns(3).CellClickAction = CellClickAction.CellSelect
                grid.DisplayLayout.Bands(0).Columns(3).CellActivation = Activation.ActivateOnly
                grid.DisplayLayout.Bands(0).Columns(4).CellClickAction = CellClickAction.Edit
                grid.DisplayLayout.Bands(0).Columns(5).CellClickAction = CellClickAction.Edit
            Next
        Else
            For Each row In grid.Rows
                row.Activation = Activation.NoEdit
                gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            Next
        End If

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub gridMKTRamos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridMKTRamos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridMKTRamos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridMKTRamos.DoubleClickHeader
        If Me.gridMKTRamos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridMKTRamos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridMKTRamos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridMKTRamos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridMKTRamos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridMKTRamos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridMKTRamos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If
    End Sub

    Private Sub gridMKTRamos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridMKTRamos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Editando_Mercadotecnia = True Then
                GuardarEdicion_Ramos()
            Else
                Dim NextRowIndex As Integer = gridMKTRamos.ActiveRow.Index + 1
                Try
                    gridMKTRamos.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridMKTRamos.DisplayLayout.Rows(NextRowIndex).Selected = True
                Catch ex As Exception
                    gridMKTRamos.ActiveRow.Activated = False
                End Try
            End If
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            Editando_Mercadotecnia = False
            poblar_gridMKTRamos(CInt(cboxClienteCliente.SelectedValue))
            gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If
    End Sub

    Private Sub GuardarEdicion_Ramos()
        Editando_Mercadotecnia = False

        gridMKTRamos.ActiveRow.Update()

        For Each row As UltraGridRow In gridMKTRamos.Rows
            Dim ramo As New Entidades.ClienteRamo
            Dim tipoRamo As New Entidades.Ramo
            Dim cliente As New Entidades.Cliente
            Dim objBU As New Negocios.ClientesDatosBU

            tipoRamo.ramoid = row.Cells(1).Value
            ramo.ramo = tipoRamo
            cliente.clienteid = CInt(row.Cells(0).Value)
            ramo.cliente = cliente
            ramo.numtiendasreal = CInt(row.Cells(4).Value)
            ramo.marcaje = row.Cells(5).Value

            Try
                objBU.EditarRamoCliente(ramo)
            Catch ex As Exception
                Mensajes_Y_Alertas("ERROR", "ocurrio un error inesperado al tratar de guardar los cambios en los ramos. Error: " + ex.Message)
            End Try
        Next

        poblar_gridMKTRamos(CInt(cboxClienteCliente.SelectedValue))
        btnMKT_EditarRamos.Enabled = True
    End Sub

    'Private Sub gridMKTRamos_Leave(sender As Object, e As EventArgs) Handles gridMKTRamos.Leave
    '    If Editando_Mercadotecnia Then
    '        GuardarEdicion_Ramos()
    '    End If
    'End Sub

    Private Sub IniciarEdicion_Ramos()
        Editando_Mercadotecnia = True
        poblar_gridMKTRamos(CInt(lblClienteSAYID_Int.Text))
    End Sub

#End Region

#Region "TIENDAS"
    Private Sub btnMKT_EditarTiendas_Click(sender As Object, e As EventArgs) Handles btnMKT_EditarTiendas.Click
        IniciarEdicion_TipoTienda()
        btnMKT_EditarTiendas.Enabled = False
    End Sub

    Public Sub poblar_gridMKTTienda(clienteID As Integer)
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim tienda As New DataTable

        gridMKTTienda.DataSource = Nothing

        tienda = clientesBU.Datos_TablaTiendaCliente(clienteID, AreaOperativa, Editando_Mercadotecnia)
        gridMKTTienda.DataSource = tienda
        gridMKTTiendaDiseno(gridMKTTienda)

        If gridMKTTienda.Rows.Count > 0 Then
            gridMKTTienda.Rows(0).Activated = True
        End If
    End Sub

    Private Sub gridMKTTiendaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grid.DisplayLayout.Override.RowSelectorWidth = 30
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "TIPO TIENDA"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "# TIENDAS"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*# TIENDAS REAL"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "*MARCAJE"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        If Editando_Mercadotecnia Then
            For Each row In grid.Rows
                row.Activation = Activation.AllowEdit
                gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                grid.DisplayLayout.Bands(0).Columns(2).CellClickAction = CellClickAction.CellSelect
                grid.DisplayLayout.Bands(0).Columns(2).CellActivation = Activation.ActivateOnly
                grid.DisplayLayout.Bands(0).Columns(3).CellClickAction = CellClickAction.CellSelect
                grid.DisplayLayout.Bands(0).Columns(3).CellActivation = Activation.ActivateOnly
                grid.DisplayLayout.Bands(0).Columns(4).CellClickAction = CellClickAction.Edit
                grid.DisplayLayout.Bands(0).Columns(5).CellClickAction = CellClickAction.Edit
            Next
        Else
            For Each row In grid.Rows
                row.Activation = Activation.NoEdit
                gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            Next
        End If

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub gridMKTTienda_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridMKTTienda.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridMKTTienda_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridMKTTienda.DoubleClickHeader
        If Me.gridMKTTienda.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridMKTTienda.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridMKTTienda.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridMKTTienda.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridMKTTienda.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridMKTTienda.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridMKTTienda.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If
    End Sub

    Private Sub gridMKTTienda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridMKTTienda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Editando_Mercadotecnia = True Then
                GuardarEdicion_TipoTienda()
            Else
                Dim NextRowIndex As Integer = gridMKTTienda.ActiveRow.Index + 1
                Try
                    gridMKTTienda.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridMKTTienda.DisplayLayout.Rows(NextRowIndex).Selected = True
                Catch ex As Exception
                    gridMKTTienda.ActiveRow.Activated = False
                End Try
            End If
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            Editando_Mercadotecnia = False
            poblar_gridMKTTienda(CInt(cboxClienteCliente.SelectedValue))
            gridMKTTienda.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If
    End Sub

    Private Sub GuardarEdicion_TipoTienda()
        Editando_Mercadotecnia = False

        gridMKTTienda.ActiveRow.Update()

        For Each row As UltraGridRow In gridMKTTienda.Rows
            Dim tienda As New Entidades.ClienteTienda
            Dim tipoTienda As New Entidades.TipoTienda
            Dim cliente As New Entidades.Cliente
            Dim objBU As New Negocios.ClientesDatosBU

            tipoTienda.tipotiendaid = row.Cells(1).Value
            tienda.tipotienda = tipoTienda
            cliente.clienteid = CInt(row.Cells(0).Value)
            tienda.cliente = cliente

            tienda.numtiendasreal = CInt(row.Cells(4).Value)
            tienda.marcaje = CInt(row.Cells(5).Value)

            Try
                objBU.EditarTiendaCliente(tienda)
            Catch ex As Exception
                Mensajes_Y_Alertas("ERROR", "ocurrio un error inesperado al tratar de guardar los cambios en las tiendas. Error: " + ex.Message)
            End Try
        Next

        poblar_gridMKTTienda(CInt(cboxClienteCliente.SelectedValue))
        btnMKT_EditarTiendas.Enabled = True
    End Sub

    Private Sub gridMKTTienda_Leave(sender As Object, e As EventArgs) Handles gridMKTTienda.Leave
        If Editando_Mercadotecnia Then
            GuardarEdicion_TipoTienda()
        End If
    End Sub

    Private Sub IniciarEdicion_TipoTienda()
        Editando_Mercadotecnia = True
        poblar_gridMKTTienda(CInt(lblClienteSAYID_Int.Text))
    End Sub

#End Region

#Region "MATERIAL MKT"

    Private Sub btnMKT_AltaMaterialMercadotecnia_Click(sender As Object, e As EventArgs) Handles btnMKT_AltaMaterialMercadotecnia.Click

        Dim grid As DataTable = gridMKTMaterialMKT.DataSource
        Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow
  
        LimpiarFiltrosGrid(gridMKTMaterialMKT)
        gridMKTMaterialMKT.Focus()

        grid.Rows.Add(CInt(cboxClienteCliente.SelectedValue), 0, "--Selecciona--", "--Selecciona--", True)

        gridMKTMaterialMKT.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        Try
            gridMKTMaterialMKT.ActiveRow.Activation = Activation.AllowEdit
        Catch ex As Exception
        End Try

        gridMKTMaterialMKT.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridMKTMaterialMKT.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Sub

    Public Sub poblar_gridMKTMaterialMKT(clienteID As Integer)
        gridMKTMaterialMKT.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim materialMKTCliente As New DataTable
        Dim tipoMaterialMKT As New DataTable
        Dim vltipoMaterialMKT As New ValueList

        materialMKTCliente = clientesBU.Datos_TablaMaterialMKTCliente(clienteID, AreaOperativa)
        tipoMaterialMKT = clientesBU.Datos_TablaTipoMaterialMKT()

        For Each fila As DataRow In tipoMaterialMKT.Rows
            vltipoMaterialMKT.ValueListItems.Add(fila.Item("tmme_tipomaterialmercadotecniaid"), fila.Item("tmme_nombre"))
        Next

        gridMKTMaterialMKT.DataSource = materialMKTCliente
        gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(2).ValueList = vltipoMaterialMKT

        gridMKTMaterialMKTDiseno(gridMKTMaterialMKT)

        If ModoEdicion_MercaDotecnia Then
            For Each row In gridMKTMaterialMKT.Rows
                row.Activation = Activation.AllowEdit
                gridMKTMaterialMKT.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns("mame_nombre").CellClickAction = CellClickAction.CellSelect
                gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns("mame_nombre").CellActivation = Activation.ActivateOnly
                gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3).Style = ColumnStyle.FormattedText
            Next
        End If
        gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns("mame_nombre").CellClickAction = CellClickAction.CellSelect

    End Sub

    Private Sub gridMKTMaterialMKTDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True '
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*TIPO MATERIAL"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*MATERIAL"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Activar_Inactivar_grids(grid, ModoEdicion_MercaDotecnia)


    End Sub

    Private Sub gridMKTMaterialMKT_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridMKTMaterialMKT.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridMKTMaterialMKT_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridMKTMaterialMKT.DoubleClickHeader

        If Me.gridMKTMaterialMKT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridMKTMaterialMKT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridMKTMaterialMKT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridMKTMaterialMKT.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridMKTMaterialMKT.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridMKTMaterialMKT.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridMKTMaterialMKT.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridMKTMaterialMKT_AfterCellListCloseUp(sender As Object, e As CellEventArgs) Handles gridMKTMaterialMKT.AfterCellListCloseUp

        If gridMKTMaterialMKT.ActiveCell.Column.ToString = "mame_nombre" Then Return

        Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow
        If IsNothing(row) Then Return

        Dim objBU As New Negocios.ClientesDatosBU
        Dim materialMKT As New DataTable
        Dim vlMaterialMKT As New Infragistics.Win.ValueList
        Dim tipoMaterial As Integer

        If gridMKTMaterialMKT.ActiveRow.Cells(2).Text = "tmme_nombre" Then Return
        tipoMaterial = row.Cells(2).Column.ValueList.GetValue(gridMKTMaterialMKT.ActiveRow.Cells(2).Text, 0)
        materialMKT = objBU.Datos_TablaMaterialMKT(tipoMaterial)

        For Each fila As DataRow In materialMKT.Rows
            vlMaterialMKT.ValueListItems.Add(fila.Item("mame_materialmercadotecniaid"), fila.Item("mame_nombre"))
        Next

        row.Cells(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        row.Cells(3).ValueList = vlMaterialMKT
        gridMKTMaterialMKT.ActiveRow.Cells(3).Value = "--Selecciona--"
    End Sub

    Private Sub gridMKTMaterialMKT_AfterCellActivate(sender As Object, e As EventArgs) Handles gridMKTMaterialMKT.AfterCellActivate
        If gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").IsActiveCell Then
            Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow
            If IsNothing(row) Then Return

            Dim objBU As New Negocios.ClientesDatosBU
            Dim materialMKT As New DataTable
            Dim vlMaterialMKT As New Infragistics.Win.ValueList
            Dim tipoMaterial As Integer

            If gridMKTMaterialMKT.ActiveRow.Cells(2).Text = "--Selecciona--" Then Return
            tipoMaterial = row.Cells(2).Column.ValueList.GetValue(gridMKTMaterialMKT.ActiveRow.Cells(2).Text, 0)
            materialMKT = objBU.Datos_TablaMaterialMKT(tipoMaterial)

            For Each fila As DataRow In materialMKT.Rows
                vlMaterialMKT.ValueListItems.Add(fila.Item("mame_materialmercadotecniaid"), fila.Item("mame_nombre"))
            Next


            gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3).CellClickAction = CellClickAction.Edit
            gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3).CellActivation = Activation.AllowEdit
            'gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            'gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3).ValueList = vlMaterialMKT

            row.Cells(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            row.Cells(3).ValueList = vlMaterialMKT
            row.Cells(3).Activation = Activation.AllowEdit
            gridMKTMaterialMKT.ActiveRow.Cells(3).Value = "--Selecciona--"
        End If

    End Sub

    Private Sub gridMKTMaterialMKT_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridMKTMaterialMKT.BeforeCellUpdate
        If gridMKTMaterialMKT.ActiveRow.IsDataRow Then
            If e.Cell.Column.ToString = "tmme_nombre" Then
                If gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").Value = gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").Text Then
                    e.Cancel = True
                End If
            ElseIf e.Cell.Column.ToString = "mmcl_activo" Then
                If gridMKTMaterialMKT.ActiveRow.Cells(1).Value = 0 Then
                    e.Cancel = True
                End If
            End If

        End If
    End Sub

    Private Sub gridMKTMaterialMKT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridMKTMaterialMKT.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridMKTMaterialMKT.ActiveRow) Then Return
            gridMKTMaterialMKT.ActiveRow.Cells("mmcl_activo").Activated = True

            If ValidarCamposVacios_gridMKTMaterialMKT() Then Return
            If Validar_MaterialMercadotecnia_Existente() Then Return

            Dim NextRowIndex As Integer = gridMKTMaterialMKT.ActiveRow.Index + 1
            gridMKTMaterialMKT.ActiveRow.Update()

            Try
                gridMKTMaterialMKT.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridMKTMaterialMKT.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridMKTMaterialMKT.DisplayLayout.Rows(gridMKTMaterialMKT.Rows.Count - 1).Activated = True
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridMKTMaterialMKT(cboxClienteCliente.SelectedValue)
            Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
        End If
    End Sub

    Private Sub gridMKTMaterialMKT_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridMKTMaterialMKT.BeforeRowDeactivate
        If ModoEdicion_MercaDotecnia = False Then Return
        If gridMKTMaterialMKT.ActiveRow.IsDataRow Then
            If gridMKTMaterialMKT.ActiveRow.DataChanged Or gridMKTMaterialMKT.ActiveRow.Cells(1).Value = 0 _
            Or gridMKTMaterialMKT.ActiveRow.Cells("mame_nombre").Value = "--Selecciona--" Or gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").Value = "--Selecciona--" Then
                If ValidarCamposVacios_gridMKTMaterialMKT() = True Then
                    e.Cancel = True
                    Return
                ElseIf Validar_MaterialMercadotecnia_Existente() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridMKTMaterialMKT_Leave(sender As Object, e As EventArgs) Handles gridMKTMaterialMKT.Leave
        If ModoEdicion_MercaDotecnia = False Then Return
        If Not IsNothing(gridMKTMaterialMKT.ActiveRow) Then
            If gridMKTMaterialMKT.ActiveRow.IsDataRow Then
                If gridMKTMaterialMKT.ActiveRow.IsDataRow And gridMKTMaterialMKT.ActiveRow.DataChanged Or gridMKTMaterialMKT.ActiveRow.Cells(1).Value = 0 _
                Or gridMKTMaterialMKT.ActiveRow.Cells(3).Value = "--Selecciona--" Or gridMKTMaterialMKT.ActiveRow.Cells(2).Value = "--Selecciona--" Then
                    If ValidarCamposVacios_gridMKTMaterialMKT() = True Then
                        gridMKTMaterialMKT.Focus()
                        Return
                    ElseIf Validar_MaterialMercadotecnia_Existente() = True Then
                        gridMKTMaterialMKT.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridMKTMaterialMKT_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridMKTMaterialMKT.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor

        If gridMKTMaterialMKT.ActiveRow.IsDataRow Then
            If gridMKTMaterialMKT.ActiveRow.DataChanged Then
                If gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").Value <> "--Selecciona--" And gridMKTMaterialMKT.ActiveRow.Cells("mame_nombre").Value <> "--Selecciona--" Then
                    If Validar_MaterialMercadotecnia_Existente() = False Then
                        ActualizarAgregar_MaterialesMercadotecnia()
                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function Validar_MaterialMercadotecnia_Existente() As Boolean
        Validar_MaterialMercadotecnia_Existente = False

        Dim rowIndex As Integer = gridMKTMaterialMKT.ActiveRow.Index

        For Each row As UltraGridRow In gridMKTMaterialMKT.Rows
            If row.Index <> rowIndex Then
                If row.Cells("tmme_nombre").Text = gridMKTMaterialMKT.Rows(rowIndex).Cells("tmme_nombre").Text And _
                    row.Cells("mame_nombre").Text = gridMKTMaterialMKT.Rows(rowIndex).Cells("mame_nombre").Text Then
                    Validar_MaterialMercadotecnia_Existente = True

                    Mensajes_Y_Alertas("ADVERTENCIA", "Este material ya esta asignado a este cliente, seleccione otro o presione ESCAPE para cancelar esta accion.")
                    gridMKTMaterialMKT.Rows(rowIndex).Cells("mame_nombre").Value = "--Selecciona--"
                    gridMKTMaterialMKT.Rows(rowIndex).Cells(3).Selected = True

                    Exit For
                End If
            End If
        Next

        Return Validar_MaterialMercadotecnia_Existente
    End Function

    Private Function ValidarCamposVacios_gridMKTMaterialMKT() As Boolean
        ValidarCamposVacios_gridMKTMaterialMKT = False

        If gridMKTMaterialMKT.ActiveRow.Cells("mame_nombre").Text = "--Selecciona--" Then
            ValidarCamposVacios_gridMKTMaterialMKT = True
            Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el material o presione  'ESCAPE' para cancelar esta acción.")
        ElseIf gridMKTMaterialMKT.ActiveRow.Cells("tmme_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_gridMKTMaterialMKT = True
            Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el tipo de material o presione  'ESCAPE' para cancelar esta acción.")
        End If

        Return ValidarCamposVacios_gridMKTMaterialMKT
    End Function

    Private Sub gridMKTMaterialMKT_Enter(sender As Object, e As EventArgs) Handles gridMKTMaterialMKT.Enter
        For Each row As UltraGridRow In gridMKTMaterialMKT.Rows
            If row.Cells(1).Value = 0 Then
                row.Activated = True
                row.Selected = True
                Exit For
            ElseIf IsNumeric(row.Cells(2).Value) Or row.Cells(2).Value = "--Selecciona--" Then
                row.Activated = True
                row.Selected = True
                Exit For
            ElseIf IsNumeric(row.Cells(3).Value) Or row.Cells(3).Value = "--Selecciona--" Then
                row.Activated = True
                row.Selected = True
                Exit For

            End If
        Next
    End Sub

    Private Sub ActualizarAgregar_MaterialesMercadotecnia()
        Dim materialCliente As New Entidades.MaterialMKTCliente
        Dim material As New Entidades.MaterialMKT
        Dim cliente As New Entidades.Cliente
        Dim objBU As New Negocios.ClientesDatosBU
        Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow

        gridMKTMaterialMKT.ActiveRow.Cells("mmcl_activo").Activated = True

        materialCliente.materialmercadotecniaclienteid = CInt(gridMKTMaterialMKT.ActiveRow.Cells(1).Value)

        cliente.clienteid = CInt(gridMKTMaterialMKT.ActiveRow.Cells("mmcl_clienteid").Value)
        materialCliente.cliente = cliente
        If IsNumeric(gridMKTMaterialMKT.ActiveRow.Cells("mame_nombre").Value) Then
            material.materialmercadotecniaid = gridMKTMaterialMKT.ActiveRow.Cells("mame_nombre").Value
        Else
            material.materialmercadotecniaid = 0
        End If

        materialCliente.activo = CBool(gridMKTMaterialMKT.ActiveRow.Cells("mmcl_activo").Text)

        materialCliente.materialmercadotecnia = material

        If materialCliente.materialmercadotecniaclienteid = 0 Then
            objBU.AltaMaterialMKTCliente(materialCliente)
        Else
            objBU.EditarMaterialMKTCliente(materialCliente)
        End If

        poblar_gridMKTMaterialMKT(CInt(cboxClienteCliente.SelectedValue))
        Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
    End Sub



    'Private Sub gridMKTMaterialMKT_MouseClick(sender As Object, e As MouseEventArgs) Handles gridMKTMaterialMKT.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridMKTMaterialMKT.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridMKTMaterialMKT.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nuevo material")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridMKTMaterialMKT_menuChoice

    '            Dim item2 = cms.Items.Add("Editar material")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridMKTMaterialMKT_menuChoice

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

    'Private Sub gridMKTMaterialMKT_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO MATERIAL

    '        Dim grid As DataTable = gridMKTMaterialMKT.DataSource
    '        Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow
    '        Dim tipoMaterial As UltraGridColumn = gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(2)
    '        Dim material As UltraGridColumn = gridMKTMaterialMKT.DisplayLayout.Bands(0).Columns(3)

    '        If Not IsNothing(row) Then

    '            grid.Rows.Add(CInt(cboxClienteCliente.SelectedValue), 0, tipoMaterial, material)

    '            gridMKTMaterialMKT.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridMKTMaterialMKT.ActiveRow.Activation = Activation.AllowEdit
    '                gridMKTMaterialMKT.ActiveCell = gridContacto.ActiveRow.Cells(3)
    '                gridMKTMaterialMKT.ActiveCell.Activation = Activation.AllowEdit
    '            Catch ex As Exception

    '            End Try


    '            gridMKTMaterialMKT.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridMKTMaterialMKT.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '        End If

    '    End If

    '    If selection = 2 Then ''EDITAR MATERIAL

    '        For Each row In gridMKTMaterialMKT.Selected.Rows
    '            Dim i As Integer = gridMKTMaterialMKT.Rows.Count

    '            gridMKTMaterialMKT.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridMKTMaterialMKT.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridMKTMaterialMKT_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridMKTMaterialMKT.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridMKTMaterialMKT.ActiveCell.Column.Index

    '        If gridMKTMaterialMKT.ActiveRow.DataChanged Then

    '        Else
    '            If gridMKTMaterialMKT.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridMKTMaterialMKT.ActiveCell.Value) Then
    '                    poblar_gridMKTMaterialMKT(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    '                    gridMKTMaterialMKT.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridMKTMaterialMKT_AfterRowActivate(sender As Object, e As EventArgs) Handles gridMKTMaterialMKT.AfterRowActivate
    '    gridMKTMaterialMKT.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridMKTMaterialMKT.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

    'Private Sub gridMKTMaterialMKT_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridMKTMaterialMKT.BeforeRowDeactivate

    '    If gridMKTMaterialMKT.ActiveRow.DataChanged Then

    '        Dim materialCliente As New Entidades.MaterialMKTCliente
    '        Dim material As New Entidades.MaterialMKT
    '        Dim cliente As New Entidades.Cliente
    '        Dim objBU As New Negocios.ClientesDatosBU

    '        Dim row As UltraGridRow = gridMKTMaterialMKT.ActiveRow

    '        materialCliente.materialmercadotecniaclienteid = CInt(gridMKTMaterialMKT.ActiveRow.Cells(1).Value)

    '        cliente.clienteid = CInt(gridMKTMaterialMKT.ActiveRow.Cells(0).Value)
    '        materialCliente.cliente = cliente

    '        If String.IsNullOrWhiteSpace(gridMKTMaterialMKT.ActiveRow.Cells(3).Value.ToString) Then
    '            material.materialmercadotecniaid = 0
    '            materialCliente.activo = False
    '        Else
    '            material.materialmercadotecniaid = row.Cells(3).ValueList.GetValue(gridMKTMaterialMKT.ActiveRow.Cells(3).Text, 0)
    '            materialCliente.activo = True
    '        End If

    '        materialCliente.materialmercadotecnia = material

    '        If materialCliente.materialmercadotecniaclienteid = 0 Then
    '            objBU.AltaMaterialMKTCliente(materialCliente)
    '        Else
    '            objBU.EditarMaterialMKTCliente(materialCliente)
    '        End If

    '        poblar_gridMKTMaterialMKT(CInt(cboxClienteCliente.SelectedValue))

    '    Else

    '    End If

    '    gridMKTMaterialMKT.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub

#End Region

#Region "ZAPATERIAS PRINCIPALES"

    'ZAPATERIAS PRINCIPALES 
    Public Sub poblar_gridMKTZapaterias(clienteID As Integer)

        gridMKTZapaterias.DataSource = Nothing

        Dim ClientesBU As New Negocios.ClientesDatosBU
        Dim zapateria As New DataTable
        Dim zapCompetencia As New DataTable

        Dim vlzapCompetencia As New ValueList

        zapateria = ClientesBU.Datos_TablaZapateriaCliente(clienteID, AreaOperativa)
        zapCompetencia = ClientesBU.Datos_TablaZapateriaCompetencia()

        For Each fila As DataRow In zapCompetencia.Rows
            vlzapCompetencia.ValueListItems.Add(fila.Item("zaco_zapateriasid"), fila.Item("zaco_nombre"))
        Next

        gridMKTZapaterias.DataSource = zapateria

        gridMKTZapaterias.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate
        gridMKTZapaterias.DisplayLayout.Bands(0).Columns(3).ValueList = vlzapCompetencia

        gridMKTZapateriasDiseno(gridMKTZapaterias)

    End Sub

    Private Sub gridMKTZapateriasDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True '
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*ZAPATERÍA"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "CLIENTE YUYIN"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        If ModoEdicion_MercaDotecnia Then
            gridMKTZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zaco_clienteyuyin").CellClickAction = CellClickAction.CellSelect
            gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zaco_clienteyuyin").CellActivation = Activation.NoEdit
            gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zacc_activo").CellClickAction = CellClickAction.Edit

            For Each row In gridMKTZapaterias.Rows
                row.Activation = Activation.AllowEdit
            Next
        Else
            For Each row In grid.Rows
                row.Activation = Activation.NoEdit
                gridMKTZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            Next
        End If
        
    End Sub

    Private Sub gridMKTZapaterias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridMKTZapaterias.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridMKTZapaterias_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridMKTZapaterias.DoubleClickHeader

        If Me.gridMKTZapaterias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridMKTZapaterias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridMKTZapaterias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridMKTZapaterias.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridMKTZapaterias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridMKTZapaterias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridMKTZapaterias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridMKTZapaterias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridMKTZapaterias.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            gridMKTZapaterias.ActiveRow.Cells("zaco_clienteyuyin").Activated = True

            If ValidarCamposVacios_Zapaterias() Then Return

            Dim NextRowIndex As Integer = gridMKTZapaterias.ActiveRow.Index + 1
            gridMKTZapaterias.ActiveRow.Update()

            Try
                gridMKTZapaterias.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridMKTZapaterias.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridMKTZapaterias.DisplayLayout.Rows(gridMKTZapaterias.Rows.Count - 1).Activated = True
                gridMKTZapaterias.DisplayLayout.Rows(gridMKTZapaterias.Rows.Count - 1).Selected = True
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridMKTZapaterias(cboxClienteCliente.SelectedValue)
            gridMKTZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridMKTZapaterias_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridMKTZapaterias.BeforeRowDeactivate
        If ModoEdicion_MercaDotecnia = False Then Return
        If gridMKTZapaterias.ActiveRow.IsDataRow Then
            If gridMKTZapaterias.ActiveRow.IsDataRow And gridMKTZapaterias.ActiveRow.DataChanged Or gridMKTZapaterias.ActiveRow.Cells(1).Value = 0 Then
                If ValidarCamposVacios_Zapaterias() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridMKTZapaterias_Leave(sender As Object, e As EventArgs) Handles gridMKTZapaterias.Leave
        If Not IsNothing(gridMKTZapaterias.ActiveRow) Then
            If gridMKTZapaterias.ActiveRow.IsDataRow Then
                If gridMKTZapaterias.ActiveRow.IsDataRow And gridMKTZapaterias.ActiveRow.DataChanged Or gridMKTZapaterias.ActiveRow.Cells(1).Value = 0 Then
                    If ValidarCamposVacios_Zapaterias() = True Then
                        gridMKTZapaterias.Focus()
                        Return
                    End If
                End If
            End If
            
        End If
    End Sub

    Private Sub gridMKTZapaterias_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridMKTZapaterias.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Framework.Negocios.ContactosBU
        If gridMKTZapaterias.ActiveRow.IsDataRow Then
            If gridMKTZapaterias.ActiveRow.DataChanged Then
                If gridMKTZapaterias.ActiveRow.Cells("zaco_nombre").Value <> "--Selecciona--" Then
                    ActualizarAgregar_Zapaterias()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ValidarCamposVacios_Zapaterias() As Boolean
        ValidarCamposVacios_Zapaterias = False

        If gridMKTZapaterias.ActiveRow.Cells("zaco_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_Zapaterias = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione la tienda o presione ESCAPE para cancelar esta acción.")
        End If

        Return ValidarCamposVacios_Zapaterias
    End Function

    Private Sub ActualizarAgregar_Zapaterias()
        Dim zapateriaCliente As New Entidades.ZapateriaCompetenciaCliente
        Dim zapateria As New Entidades.ZapateriaCompetencia
        Dim cliente As New Entidades.Cliente
        Dim objBU As New Negocios.ClientesDatosBU

        Dim row As UltraGridRow = gridMKTZapaterias.ActiveRow

        zapateriaCliente.zapateriascompetenciaclienteid = CInt(gridMKTZapaterias.ActiveRow.Cells("zacc_zapateriascompetenciaclienteid").Value)
        zapateria.zapateriasid = row.Cells("zaco_nombre").Column.ValueList.GetValue(gridMKTZapaterias.ActiveRow.Cells("zaco_nombre").Text, 0)
        cliente.clienteid = CInt(gridMKTZapaterias.ActiveRow.Cells("clie_clienteid").Value)
        zapateriaCliente.activo = CBool(gridMKTZapaterias.ActiveRow.Cells("zacc_activo").Text)
        zapateriaCliente.cliente = cliente
        zapateriaCliente.zapateria = zapateria

        If CInt(gridMKTZapaterias.ActiveRow.Cells("zacc_zapateriascompetenciaclienteid").Value) = 0 Then
            objBU.AltaZapateriaCliente(zapateriaCliente)
        Else
            objBU.EditarZapateriaCliente(zapateriaCliente)
        End If

        poblar_gridMKTZapaterias(CInt(cboxClienteCliente.SelectedValue))
    End Sub

    Private Sub btnMKT_AltaZapateriasCiudad_Click(sender As Object, e As EventArgs) Handles btnMKT_AltaZapateriasCiudad.Click
        Dim grid As DataTable = gridMKTZapaterias.DataSource
        Dim row As UltraGridRow = gridMKTZapaterias.ActiveRow

        gridMKTZapaterias.Focus()

        LimpiarFiltrosGrid(gridMKTZapaterias)

        grid.Rows.Add(CInt(lblClienteSAYID_Int.Text), 0, 0, "--Selecciona--", False, True)

        gridMKTRamos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
        gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zaco_clienteyuyin").CellClickAction = CellClickAction.CellSelect
        gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zaco_clienteyuyin").CellActivation = Activation.NoEdit
        gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zacc_activo").CellActivation = Activation.NoEdit
        gridMKTZapaterias.DisplayLayout.Bands(0).Columns("zaco_nombre").CellClickAction = CellClickAction.CellSelect

        For Each row In gridMKTZapaterias.Rows
            row.Activation = Activation.AllowEdit
        Next

        gridMKTZapaterias.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        gridMKTZapaterias.ActiveRow.Activation = Activation.AllowEdit
        gridMKTZapaterias.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridMKTZapaterias.PerformAction(UltraGridAction.EnterEditMode, False, False)
        gridMKTZapaterias.DisplayLayout.Rows(grid.Rows.Count - 1).Cells(3).Activated = True

    End Sub

    Private Sub btnMKT_CatalogoZapateriasCiudad_Click(sender As Object, e As EventArgs) Handles btnMKT_CatalogoZapateriasCiudad.Click
        Dim objCatalogoZapaterias As New AltaZapateriasForm
        Dim ClientesBU As New Negocios.ClientesDatosBU
        Dim zapCompetencia As New DataTable
        Dim vlzapCompetencia As New ValueList

        objCatalogoZapaterias.StartPosition = FormStartPosition.CenterScreen
        objCatalogoZapaterias.ShowDialog()

        zapCompetencia = ClientesBU.Datos_TablaZapateriaCompetencia()

        For Each fila As DataRow In zapCompetencia.Rows
            vlzapCompetencia.ValueListItems.Add(fila.Item("zaco_zapateriasid"), fila.Item("zaco_nombre"))
        Next
    End Sub

    Private Sub gridMKTZapaterias_Error(sender As Object, e As ErrorEventArgs) Handles gridMKTZapaterias.Error
        If e.ErrorType = ErrorType.Data Then
            e.Cancel = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Este nombre de zapatería no se encuentra en la lista, por favor seleccione una zapatería valida.")
        End If
    End Sub

    Private Sub gridMKTZapaterias_AfterCellListCloseUp(sender As Object, e As CellEventArgs) Handles gridMKTZapaterias.AfterCellListCloseUp
        gridMKTZapaterias.ActiveRow.Cells(5).Activated = True
    End Sub


    'Private Sub gridMKTZapaterias_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)
    '    If selection = 1 Then ''AGREGAR NUEVA ZAPATERIA
    '        Dim grid As DataTable = gridMKTZapaterias.DataSource
    '        Dim row As UltraGridRow = gridMKTZapaterias.ActiveRow
    '        Dim zapCompetencia As UltraGridColumn = gridMKTZapaterias.DisplayLayout.Bands(0).Columns(3)
    '        'Dim requerimiento As UltraGridColumn = gridMKTZapaterias.DisplayLayout.Bands(0).Columns(3)

    '        If Not IsNothing(row) Then
    '            grid.Rows.Add(CInt(lblClienteSAYID_Int.Text), 0, 0, zapCompetencia, False)
    '            gridMKTZapaterias.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridMKTZapaterias.ActiveRow.Activation = Activation.AllowEdit
    '                gridMKTZapaterias.ActiveCell = gridContacto.ActiveRow.Cells(3)
    '                gridMKTZapaterias.ActiveCell.Activation = Activation.AllowEdit
    '            Catch ex As Exception
    '            End Try

    '            gridMKTZapaterias.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridMKTZapaterias.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '        End If
    '    End If

    '    If selection = 2 Then ''EDITAR ZAPATERÍA
    '        For Each row In gridMKTZapaterias.Selected.Rows
    '            Dim i As Integer = gridMKTZapaterias.Rows.Count

    '            gridMKTZapaterias.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridMKTZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
    '        Next
    '    End If
    'End Sub








    'Private Sub gridMKTZapaterias_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridMKTZapaterias.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridMKTZapaterias.ActiveCell.Column.Index

    '        If gridMKTZapaterias.ActiveRow.DataChanged Then
    '        Else
    '            If gridMKTZapaterias.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridMKTZapaterias.ActiveCell.Value) Then
    '                    poblar_gridMKTZapaterias(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    '                    gridMKTZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub









    'Private Sub gridMKTZapaterias_MouseClick(sender As Object, e As MouseEventArgs) Handles gridMKTZapaterias.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridMKTZapaterias.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridMKTZapaterias.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nueva zapatería")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridMKTZapaterias_menuChoice

    '            Dim item2 = cms.Items.Add("Editar zapatería")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridMKTZapaterias_menuChoice

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

#End Region

#End Region



End Class
