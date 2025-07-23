Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions

Public Class ListaCodigosClientes

    Public IdClienteSAY As Integer
    Public NombreClienteSAy As String
    Public ValidarCodigoAmece As Boolean
    Dim BanderaModoEdicion As Boolean ''TRUE PARA MODOEDICION, FALSE PARA MODO CONSULTA

    Private Sub ListaCodigosClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        'Se descomento línea--------------------------------------------------------------------
        cmbListaPrecios = comboListaPrecioCliente_SegunClienteSAY(cmbListaPrecios, IdClienteSAY)
        '---------------------------------------------------------------------------------------
        txtCliente.Text = NombreClienteSAy
        chkCodigosAmece.Checked = ValidarCodigoAmece



        If ValidarCodigoAmece Then
            pnlEdicion.Visible = False
            btnEliminar.Visible = False
            lblBtnEliminar.Visible = False
            chkSeleccionarTodo_Tallas.Visible = False
            grbActivos.Enabled = False
        Else
            pnlEdicion.Visible = True
            btnEliminar.Visible = True
            lblBtnEliminar.Visible = True
            grbActivos.Enabled = True
        End If
    End Sub




    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If ValidarCamposVacios() = False Then
            Me.Cursor = Cursors.WaitCursor
            RecuperarListaCodigosCliente_o_Amece()
            If BanderaModoEdicion Then
                ActivarEdicion()
            End If
            If rdoActivoNo.Checked = True Then
                btnEliminar.Enabled = False
                lblBtnEliminar.Enabled = False
            Else
                btnEliminar.Enabled = True
                lblBtnEliminar.Enabled = True
            End If
            Me.Cursor = Cursors.Default
        End If

    End Sub


    Private Sub RecuperarListaCodigosCliente_o_Amece()
        Dim objBU As New Negocios.CodigosClienteBU
        Dim dtCodigos As New DataTable
        Dim FiltroVerDe As Integer
        Dim FiltroConCodigo As Integer
        Dim IdListaPrecioCLiente As Integer
        Dim ActivoCodigo As Integer
        If rdoPedidosConfirmadosPorVentas.Checked Then
            FiltroVerDe = 1
        ElseIf rdoListaPrecios.Checked Then
            FiltroVerDe = 2
        ElseIf rdoDeTodos.Checked Then
            FiltroVerDe = 3
        End If

        If rdoConCodigoSI.Checked Then
            FiltroConCodigo = 1
        ElseIf rdoConCodigoNo.Checked Then
            FiltroConCodigo = 2
        ElseIf rdoConCodigosTodos.Checked Then
            FiltroConCodigo = 3
        End If

        If IsDBNull(cmbListaPrecios.SelectedValue) Then
            IdListaPrecioCLiente = 0
        Else
            IdListaPrecioCLiente = cmbListaPrecios.SelectedValue
        End If

        If rdoActivoSi.Checked Then
            ActivoCodigo = 1
        ElseIf rdoActivoNo.Checked Then
            ActivoCodigo = 0
        End If

        dtCodigos = objBU.RecuperarListaCodigos_Cliente_O_Amece(chkCodigosAmece.Checked, FiltroVerDe, FiltroConCodigo, IdClienteSAY, IdListaPrecioCLiente, ActivoCodigo)
        'dtCodigos = objBU.RecuperarListaCodigos_Cliente_O_Amece(chkCodigosAmece.Checked, FiltroVerDe, FiltroConCodigo, IdClienteSAY, IdListaPrecioCLiente)

        If dtCodigos.Rows.Count = 0 Then
            grdCodigosCliente.DataSource = Nothing
            Mensajes_Y_Alertas("ADVERTENCIA", "No se encontro información para mostrar.")
        Else
            grdCodigosCliente.DataSource = dtCodigos
        End If

    End Sub


    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        If rdoListaPrecios.Checked = True Then
            If IsNumeric(cmbListaPrecios.SelectedValue) Then
                If cmbListaPrecios.SelectedValue <= 0 Then
                    ValidarCamposVacios = True
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ha seleccionado el filtro ""Ver productos por Lista de Precios"". Seleccione una lista de precios para poder consultar los códigos de cliente.")
                    lblListaPrecios.ForeColor = Color.Red
                Else
                    lblListaPrecios.ForeColor = Color.Black
                End If
            Else
                ValidarCamposVacios = True
                Mensajes_Y_Alertas("ADVERTENCIA", "Ha seleccionado el filtro ""Ver productos por Lista de Precios"". Seleccione una lista de precios para poder consultar los códigos de cliente.")
                lblListaPrecios.ForeColor = Color.Red
            End If
        End If




        Return ValidarCamposVacios
    End Function




    Private Sub grdCodigosCliente_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCodigosCliente.InitializeLayout
        With grdCodigosCliente


            '.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 50
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.Black

            .DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            For Each columna As UltraGridColumn In grdCodigosCliente.DisplayLayout.Bands(0).Columns
                columna.CellActivation = Activation.NoEdit
            Next

            If chkCodigosAmece.Checked Then
                .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

                .DisplayLayout.Bands(0).Columns("ProductoEstiloId").Hidden = True
                .DisplayLayout.Override.CellAppearance.ForeColor = Color.Black
                .DisplayLayout.Override.CellAppearance.FontData.Bold = DefaultableBoolean.False

            Else
                .DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect

                .DisplayLayout.Bands(0).Columns("IdCodigoCliente").Hidden = True
                .DisplayLayout.Bands(0).Columns("ProductoEstiloId").Hidden = True
                .DisplayLayout.Bands(0).Columns("MarcaIdSAY").Hidden = True

                .DisplayLayout.Bands(0).Columns("Seleccionar").Style = ColumnStyle.CheckBox
                .DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
                .DisplayLayout.Bands(0).Columns("Seleccionar").Width = 50
                .DisplayLayout.Bands(0).Columns("CantEmpaque").CellAppearance.TextHAlign = HAlign.Right
                For Each row As UltraGridRow In grdCodigosCliente.Rows
                    If row.Cells("Código").Text = "" And row.Cells("Código rápido").Text = "" Then
                        row.Cells("Seleccionar").Activation = Activation.Disabled
                    Else
                        row.Cells("Seleccionar").Activation = Activation.AllowEdit
                    End If
                Next
            End If

            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 150




        End With
    End Sub


#Region "SELECCIONAR CELDAS"

    Private Sub chkSeleccionarTodo_Tallas_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo_Tallas.CheckedChanged
        If chkCodigosAmece.Checked Then Return
        For Each row As UltraGridRow In grdCodigosCliente.Rows.GetFilteredInNonGroupByRows
            If row.Cells("Código").Text <> "" Or row.Cells("Código rápido").Text <> "" Then
                row.Cells("Seleccionar").Value = chkSeleccionarTodo_Tallas.Checked
            Else
                row.Cells("Seleccionar").Value = False
            End If
        Next

        ContarRegistrosSeleccionados()
    End Sub

    Private Sub ContarRegistrosSeleccionados()
        Dim Seleccionados As Integer = 0
        For Each row As UltraGridRow In grdCodigosCliente.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                Seleccionados += 1
            End If
        Next
        lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
    End Sub

    Private Sub grdCodigosCliente_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCodigosCliente.ClickCell
        Dim seleccionados As Integer = 0
        If IsNothing(grdCodigosCliente.ActiveRow) Then Return
        If IsNothing(grdCodigosCliente.ActiveCell) Then Return

        If e.Cell.IsDataCell = False Then
            Return
        End If

        If grdCodigosCliente.ActiveCell.Column.ToString = "Seleccionar" And (grdCodigosCliente.ActiveRow.Cells("Código").Text <> "" Or grdCodigosCliente.ActiveRow.Cells("Código rápido").Text <> "") Then
            If Not Me.grdCodigosCliente.ActiveRow.IsDataRow Then Return

            If IsNothing(grdCodigosCliente.ActiveRow) Then Return

            If grdCodigosCliente.ActiveRow.Cells("Seleccionar").Value Then

                grdCodigosCliente.ActiveRow.Cells("Seleccionar").Value = False
            Else
                grdCodigosCliente.ActiveRow.Cells("Seleccionar").Value = True
            End If

            For Each row As UltraGridRow In grdCodigosCliente.Rows
                If CBool(row.Cells("Seleccionar").Value) Then
                    seleccionados += 1
                End If
            Next
            lblTotalSeleccionados.Text = Format(seleccionados, "###,###,##0")
        End If
    End Sub

#End Region


#Region "EditarGrid(Metodos GRID)"

    Private Sub grdCodigosCliente_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdCodigosCliente.AfterCellUpdate

    End Sub

    Private Sub grdCodigosCliente_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdCodigosCliente.BeforeRowDeactivate
        If BanderaModoEdicion = False Then Return

        If grdCodigosCliente.ActiveRow.IsDataRow Then
            If ValidarCamposVaciosEnGrid_CodigoCliente() = True Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub

    Private Function ValidarCamposVaciosEnGrid_CodigoCliente() As Boolean

        ValidarCamposVaciosEnGrid_CodigoCliente = False

        If grdCodigosCliente.ActiveRow.IsDataRow Then
            If grdCodigosCliente.ActiveRow.DataChanged Then
                If grdCodigosCliente.ActiveRow.Cells("Código").Text = "" And grdCodigosCliente.ActiveRow.Cells("Código rápido").Text = "" Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese al menos un 'Código Rapido' o un 'Código' para poder guardar o actualizar el registro.")
                    ValidarCamposVaciosEnGrid_CodigoCliente = True
                End If
            ElseIf grdCodigosCliente.ActiveRow.Cells("Marca").Text <> "" Or grdCodigosCliente.ActiveRow.Cells("Colección").Text <> "" _
                Or grdCodigosCliente.ActiveRow.Cells("Estilo").Text <> "" Or grdCodigosCliente.ActiveRow.Cells("Línea").Text <> "" _
                Or grdCodigosCliente.ActiveRow.Cells("Material").Text <> "" Or grdCodigosCliente.ActiveRow.Cells("Color").Text <> "" _
                Or grdCodigosCliente.ActiveRow.Cells("Talla").Text <> "" Then
                If grdCodigosCliente.ActiveRow.Cells("Código").Text = "" And grdCodigosCliente.ActiveRow.Cells("Código rápido").Text = "" Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese al menos un 'Código Rapido' o un 'Código' para poder guardar o actualizar el registro.")
                    ValidarCamposVaciosEnGrid_CodigoCliente = True
                End If
            End If
        End If

        Return ValidarCamposVaciosEnGrid_CodigoCliente

    End Function

    Private Sub grdCodigosCliente_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdCodigosCliente.BeforeRowUpdate
        If BanderaModoEdicion = False Then Return

        Me.Cursor = Cursors.WaitCursor

        If grdCodigosCliente.ActiveRow.IsDataRow Then
            If grdCodigosCliente.ActiveRow.DataChanged Then
                If grdCodigosCliente.ActiveRow.Cells("Código").Text <> "" Or grdCodigosCliente.ActiveRow.Cells("Código rápido").Text <> "" Then
                    ActualizarAgregarCodigoCliente()
                End If
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ActualizarAgregarCodigoCliente()
        Dim objBU As New Negocios.CodigosClienteBU
        Dim objCodigosCliente As New Entidades.CodigosCliente

        If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea Agregar/Editar este codigo de cliente? (Los códigos editados quedará como activos)") Then

            objCodigosCliente.PClienteId = IdClienteSAY
            objCodigosCliente.PProductoEstiloId = grdCodigosCliente.ActiveRow.Cells("ProductoEstiloId").Value
            objCodigosCliente.PCodigoCliente = grdCodigosCliente.ActiveRow.Cells("Código").Text
            objCodigosCliente.PCodigoRapidoCliente = grdCodigosCliente.ActiveRow.Cells("Código rápido").Text
            objCodigosCliente.PEstiloCliente = grdCodigosCliente.ActiveRow.Cells("Estilo").Text
            objCodigosCliente.PMarcaCliente = grdCodigosCliente.ActiveRow.Cells("Marca").Text
            objCodigosCliente.PColeccionCliente = grdCodigosCliente.ActiveRow.Cells("Colección").Text
            objCodigosCliente.PFamiliaCliente = grdCodigosCliente.ActiveRow.Cells("Familia").Text
            objCodigosCliente.PLineaCliente = grdCodigosCliente.ActiveRow.Cells("Línea").Text
            objCodigosCliente.PMaterialCliente = grdCodigosCliente.ActiveRow.Cells("Material").Text
            objCodigosCliente.PColorCliente = grdCodigosCliente.ActiveRow.Cells("Color").Text
            objCodigosCliente.PTallaCliente = grdCodigosCliente.ActiveRow.Cells("Talla").Text
            objCodigosCliente.PDescripcionCliente = grdCodigosCliente.ActiveRow.Cells("Descripción").Text
            objCodigosCliente.PCantidadEmpacado = grdCodigosCliente.ActiveRow.Cells("CantEmpaque").Text
            objCodigosCliente.PActivo = True


            If IsDBNull(grdCodigosCliente.ActiveRow.Cells("IdCodigoCliente").Value) Then
                'AGREGAMOS UN NUEVO CODIGO DE CLIENTE
                objCodigosCliente.PIdCodigoCliente = 0
                objBU.Agregar_Nuevo_CodigoCliente(objCodigosCliente)
            Else
                'EDITAMOS EL CODIGO DE CLIENTE
                objCodigosCliente.PIdCodigoCliente = grdCodigosCliente.ActiveRow.Cells("IdCodigoCliente").Value
                objBU.Editar_CodigoCliente(objCodigosCliente)
            End If


        End If

        RecuperarListaCodigosCliente_o_Amece()

        If BanderaModoEdicion = True Then
            ActivarEdicion()
        End If
    End Sub

    Private Sub grdCodigosCliente_Leave(sender As Object, e As EventArgs) Handles grdCodigosCliente.Leave
        If BanderaModoEdicion = False Then Return

        If Not IsNothing(grdCodigosCliente.ActiveRow) Then
            If grdCodigosCliente.ActiveRow.IsDataRow Then
                If grdCodigosCliente.ActiveRow.Cells("Código").Text = "" And grdCodigosCliente.ActiveRow.Cells("Código rápido").Text = "" And _
                     (grdCodigosCliente.ActiveRow.Cells("IdCodigoCliente").Text <> "") Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese al menos un 'Código Rapido' o un 'Código' para poder guardar o actualizar el registro.")
                    grdCodigosCliente.Focus()
                    Return
                End If
            End If
        End If

    End Sub

    Private Sub grdCodigosCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdCodigosCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim NextRowIndex As Integer = grdCodigosCliente.ActiveRow.Index + 1
            Try
                grdCodigosCliente.ActiveRow.Update()
                If NextRowIndex <= grdCodigosCliente.Rows.Count - 1 Then
                    grdCodigosCliente.DisplayLayout.Rows(NextRowIndex).Activated = True
                Else
                    grdCodigosCliente.DisplayLayout.Rows(0).Activated = True
                End If
            Catch ex As Exception
                grdCodigosCliente.ActiveRow.Activated = True
            End Try
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            RecuperarListaCodigosCliente_o_Amece()

        ElseIf Char.IsLower(e.KeyChar) Then
            e.Handled = True

            SendKeys.Send(Char.ToUpper(e.KeyChar))
        End If
    End Sub
#End Region

#Region "ACTIVAR_INACTIVAR_EDICIONGRID"
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ActivarEdicion()
    End Sub

    Private Sub ActivarEdicion()
        If IsNothing(grdCodigosCliente.DataSource) Then
            Mensajes_Y_Alertas("ADVERTENCIA", "No hay información para editar en la lista de códigos de cliente.")
        ElseIf grdCodigosCliente.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "No hay información para editar en la lista de códigos de cliente.")
        Else
            BanderaModoEdicion = True
            btnEditar.Enabled = False
            lblEditar.Enabled = False
            btnDetener.Enabled = True
            lblDetenerEdicion.Enabled = True
            chkSeleccionarTodo_Tallas.Checked = False
            chkSeleccionarTodo_Tallas.Enabled = False
            btnEliminar.Enabled = False
            lblBtnEliminar.Enabled = False


            With grdCodigosCliente

                .DisplayLayout.Override.CellClickAction = CellClickAction.Default

                .DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Estilo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Línea").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Código rápido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Código").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Familia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("CantEmpaque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

                .DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .DisplayLayout.Bands(0).Columns("IdCodigoCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("MarcaIdSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("MotivoElimina").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                For Each row As UltraGridRow In grdCodigosCliente.Rows
                    row.Cells("Modelos Yuyin").Appearance.ForeColor = Color.DarkSlateBlue
                    row.Cells("Corrida").Appearance.ForeColor = Color.DarkSlateBlue
                    row.Cells("Modificación").Appearance.ForeColor = Color.DarkSlateBlue
                    row.Cells("Usuario").Appearance.ForeColor = Color.DarkSlateBlue
                    row.Cells("MotivoElimina").Appearance.ForeColor = Color.DarkSlateBlue
                    row.Cells("Marca").Activation = Activation.AllowEdit
                    row.Cells("Colección").Activation = Activation.AllowEdit
                    row.Cells("Estilo").Activation = Activation.AllowEdit
                    row.Cells("Línea").Activation = Activation.AllowEdit
                    row.Cells("Material").Activation = Activation.AllowEdit
                    row.Cells("Color").Activation = Activation.AllowEdit
                    row.Cells("Talla").Activation = Activation.AllowEdit
                    row.Cells("Código rápido").Activation = Activation.AllowEdit
                    row.Cells("Código").Activation = Activation.AllowEdit
                Next
            End With
        End If
    End Sub


    Private Sub Desactivar_Edicion()
        BanderaModoEdicion = False
        chkSeleccionarTodo_Tallas.Enabled = True

        RecuperarListaCodigosCliente_o_Amece()


        btnEditar.Enabled = True
        lblEditar.Enabled = True
        btnDetener.Enabled = False
        lblDetenerEdicion.Enabled = False
        btnEliminar.Enabled = True
        lblBtnEliminar.Enabled = True
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        Desactivar_Edicion()
    End Sub

#End Region

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim objBU As New Negocios.CodigosClienteBU
        Dim MotivoEliminacion As String = String.Empty


        If CInt(lblTotalSeleccionados.Text) > 0 Then
            If Mensajes_Y_Alertas("CONFIRMACION", "¿Está seguro  que desea eliminar los códigos de cliente seleccionados?") Then
                Dim objMotivo As New CodigosCliente_MotivoEliminacionForm
                objMotivo.StartPosition = FormStartPosition.CenterScreen
                objMotivo.ShowDialog()
                MotivoEliminacion = objMotivo.txtMotivo.Text

                Me.Cursor = Cursors.WaitCursor

                For Each row As UltraGridRow In grdCodigosCliente.Rows
                    If row.Cells("Seleccionar").Value = True Then
                        Dim objCodigoCliente As New Entidades.CodigosCliente
                        objCodigoCliente.PIdCodigoCliente = row.Cells("IdCodigoCliente").Value
                        objCodigoCliente.PMotivoEliminacion = MotivoEliminacion

                        objBU.Eliminar_CodigoCliente(objCodigoCliente)
                    End If
                Next

                RecuperarListaCodigosCliente_o_Amece()

                chkSeleccionarTodo_Tallas.Checked = True
                chkSeleccionarTodo_Tallas.Checked = False

                Me.Cursor = Cursors.Default
            End If
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "No hay códigos de cliente para eliminar.")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        LimpiarControles()

    End Sub

    Private Sub cmbListaPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaPrecios.SelectedIndexChanged
        If IsNumeric(cmbListaPrecios.SelectedValue) Then
            Dim dtLPVigencia As New DataTable

            dtLPVigencia = RecuperarVigenciaListaPrecio(cmbListaPrecios.SelectedValue)

            dttInicioVigenciaLVC.Value = dtLPVigencia.Rows(0).Item(0)
            dttFinVigenciaLVC.Value = dtLPVigencia.Rows(0).Item(1)
        End If
    End Sub

    Private Function RecuperarVigenciaListaPrecio(ByVal IdListaPrecioCliente As Integer) As DataTable
        Dim objBU As New Negocios.CodigosAMECEBU

        RecuperarVigenciaListaPrecio = objBU.RecuperarVigenciaListaPrecio(IdListaPrecioCliente)

        Return RecuperarVigenciaListaPrecio
    End Function

    Private Sub LimpiarControles()

        cmbListaPrecios.SelectedIndex = 0
        chkSeleccionarTodo_Tallas.Checked = True
        chkSeleccionarTodo_Tallas.Checked = False
        rdoPedidosConfirmadosPorVentas.Checked = True
        rdoConCodigoSI.Checked = True

        dttInicioVigenciaLVC.Value = Today
        dttFinVigenciaLVC.Value = Today

        grdCodigosCliente.DataSource = Nothing


        If chkCodigosAmece.Checked Then
            pnlEdicion.Visible = False
            btnDetener.Visible = False
            lblDetenerEdicion.Visible = False
        Else
            pnlEdicion.Visible = True
            btnDetener.Visible = True
            lblDetenerEdicion.Visible = True


        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If Not ValidarCodigoAmece Then
            ArmarGridPara_Exportar()
        End If

        ExportarGridAExcel()
    End Sub

    Private Sub ArmarGridPara_Exportar()

        Dim dtTablaExcel As New DataTable


        dtTablaExcel.Columns.Add("ProductoEstiloId_No_Modificar")
        dtTablaExcel.Columns.Add("ModeloYuyin_No_Modificar")
        dtTablaExcel.Columns.Add("Corrida")
        dtTablaExcel.Columns.Add("Marca")
        dtTablaExcel.Columns.Add("Colección")
        dtTablaExcel.Columns.Add("Estilo")
        dtTablaExcel.Columns.Add("Línea")
        dtTablaExcel.Columns.Add("Familia")
        dtTablaExcel.Columns.Add("Material")
        dtTablaExcel.Columns.Add("Color")
        dtTablaExcel.Columns.Add("Talla_No_Modificar")
        dtTablaExcel.Columns.Add("CodigoRapido")
        dtTablaExcel.Columns.Add("Codigo")
        dtTablaExcel.Columns.Add("Descripción")
        dtTablaExcel.Columns.Add("CantEmpaque")


        For Each row As UltraGridRow In grdCodigosCliente.Rows.GetFilteredInNonGroupByRows
            dtTablaExcel.Rows.Add()
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("ProductoEstiloId_No_Modificar") = row.Cells("ProductoEstiloId").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("ModeloYuyin_No_Modificar") = row.Cells("Modelos Yuyin").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Corrida") = row.Cells("Corrida").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Marca") = row.Cells("Marca").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Colección") = row.Cells("Colección").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Estilo") = row.Cells("Estilo").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Línea") = row.Cells("Línea").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Familia") = row.Cells("Familia").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Material") = row.Cells("Material").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Color") = row.Cells("Color").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Talla_No_Modificar") = row.Cells("Talla").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("CodigoRapido") = row.Cells("Código rápido").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Codigo") = row.Cells("Código").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("Descripción") = row.Cells("Descripción").Value
            dtTablaExcel.Rows(dtTablaExcel.Rows.Count - 1).Item("CantEmpaque") = row.Cells("CantEmpaque").Value

        Next

        grdExportar.DataSource = dtTablaExcel



    End Sub

    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor


                If ValidarCodigoAmece Then

                    ultExportGrid.Export(grdCodigosCliente, fileName)



                Else
                    ultExportGrid.Export(grdExportar, fileName)
                End If

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Me.Cursor = Cursors.Default
                Process.Start(fileName)

                grdExportar.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try

        End If

    End Sub

    Private Sub grdExportar_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdExportar.InitializeLayout

        With grdExportar
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 50
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.Black

            .DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns(0).Header.Appearance.BackColor = Color.Gray
            .DisplayLayout.Bands(0).Columns(1).Header.Appearance.BackColor = Color.Gray
            .DisplayLayout.Bands(0).Columns(2).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(3).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(4).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(5).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(6).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(7).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(8).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(9).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(10).Header.Appearance.BackColor = Color.Gray
            .DisplayLayout.Bands(0).Columns(11).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(12).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(13).Header.Appearance.BackColor = Color.AliceBlue
            .DisplayLayout.Bands(0).Columns(14).Header.Appearance.BackColor = Color.AliceBlue




        End With


    End Sub

    Private Sub btnImportarCodigos_Click(sender As Object, e As EventArgs) Handles btnImportarCodigos.Click

        ''''Se debe instalar el driver para poder importar archivos http://www.microsoft.com/es-es/download/details.aspx?id=23734
        Dim valoresMal As Int16 = 0
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim dtExcel As New DataTable

        openFileDialog1.InitialDirectory = "c:\"
        'openFileDialog1.Filter = "Archivos de excel (*.xlsx)|"
        openFileDialog1.Filter = "Archivos de excel (*.xls)|"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then

                    grdExportar.DataSource = Nothing
                    grdExportar.DataSource = GetDataExcel(openFileDialog1.FileName, "Sheet1$")
                    dtExcel = GetDataExcel(openFileDialog1.FileName, "Sheet1$")
                    Dim valor As String = 0

                    If IdClienteSAY = 88 Or IdClienteSAY = 1069 Or IdClienteSAY = 166 Then
                        Dim RegEx_Code As New Regex("[^0-9]", RegexOptions.Compiled)

                        'If dtExcel.Select("(Codigo LIKE '%[^0-9]%' OR LEN(Codigo) <> 12)").Count > 0 Then
                        '    valoresMal += 1
                        'End If

                        For Each row As UltraGridRow In grdExportar.Rows.GetFilteredInNonGroupByRows

                            If row.Cells("Codigo").Text <> "" Then

                                Dim ban As Boolean = RegEx_Code.IsMatch(row.Cells("Codigo").Value.ToString) 'Si es verdadero no es numero
                                If row.Cells("Codigo").Text.Length <> 12 Or ban Then
                                    valoresMal += 1
                                End If
                            Else
                                valoresMal += 1

                            End If

                        Next

                    End If



                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo en disco. Error original: " & Ex.Message)
                Exit Sub
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try

        End If

        Me.Cursor = Cursors.WaitCursor


        If valoresMal > 0 Then
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Error de formato en columna Código, por favor verificar el archivo a importar."
            objMensajeGuardar.ShowDialog()
        Else

            Dim objBU As New Negocios.CodigosClienteBU
            Dim objCodigo As New Entidades.CodigosCliente
            Dim dtCodigosNoActualizados As New DataTable

            For Each row As UltraGridRow In grdExportar.Rows
                objCodigo = New Entidades.CodigosCliente
                If row.Cells("CodigoRapido").Text <> "" Or row.Cells("Codigo").Text <> "" Then

                    objCodigo.PClienteId = IdClienteSAY
                    objCodigo.PProductoEstiloId = row.Cells("ProductoEstiloId_No_Modificar").Text
                    objCodigo.PCodigoCliente = row.Cells("Codigo").Text
                    objCodigo.PCodigoRapidoCliente = row.Cells("CodigoRapido").Text
                    objCodigo.PEstiloCliente = row.Cells("Estilo").Text
                    objCodigo.PMarcaCliente = row.Cells("Marca").Text
                    objCodigo.PColeccionCliente = row.Cells("Colección").Text
                    objCodigo.PFamiliaCliente = row.Cells("Familia").Text
                    objCodigo.PLineaCliente = row.Cells("Línea").Text
                    objCodigo.PMaterialCliente = row.Cells("Material").Text
                    objCodigo.PColorCliente = row.Cells("Color").Text
                    objCodigo.PTallaCliente = row.Cells("Talla_No_Modificar").Text
                    objCodigo.PDescripcionCliente = row.Cells("Descripción").Text
                    objCodigo.PCantidadEmpacado = row.Cells("CantEmpaque").Text


                    Dim CadenaIdCodigoCliente As Integer = objBU.ValidarCodigoClienteExistente(objCodigo)

                    If CadenaIdCodigoCliente = 0 Then
                        ''DAR DE ALTA CODIGO CLIENTE
                        objBU.Agregar_Nuevo_CodigoCliente(objCodigo)

                    Else
                        'EDITAR CODIGO CLIENTE
                        objCodigo.PIdCodigoCliente = CadenaIdCodigoCliente

                        objBU.Editar_CodigoCliente(objCodigo)
                    End If
                Else

                    If dtCodigosNoActualizados.Rows.Count = 0 Then
                        dtCodigosNoActualizados.Columns.Add("ProductoEstiloId")
                        dtCodigosNoActualizados.Columns.Add("Modelo Yuyin")
                        dtCodigosNoActualizados.Columns.Add("Corrida")
                        dtCodigosNoActualizados.Columns.Add("Marca")
                        dtCodigosNoActualizados.Columns.Add("Colección")
                        dtCodigosNoActualizados.Columns.Add("Estilo")
                        dtCodigosNoActualizados.Columns.Add("Línea")
                        dtCodigosNoActualizados.Columns.Add("Familia")
                        dtCodigosNoActualizados.Columns.Add("Material")
                        dtCodigosNoActualizados.Columns.Add("Color")
                        dtCodigosNoActualizados.Columns.Add("Talla")
                        dtCodigosNoActualizados.Columns.Add("Código rápido")
                        dtCodigosNoActualizados.Columns.Add("Código")
                        dtCodigosNoActualizados.Columns.Add("Descripción")
                        dtCodigosNoActualizados.Columns.Add("Cant. Empaque")

                        dtCodigosNoActualizados.Rows.Add(row.Cells("ProductoEstiloId_No_Modificar").Text,
                                                            row.Cells("ModeloYuyin_No_Modificar").Text,
                                                            row.Cells("Corrida").Text,
                                                            row.Cells("Marca").Text,
                                                            row.Cells("Colección").Text,
                                                            row.Cells("Estilo").Text,
                                                            row.Cells("Línea").Text,
                                                            row.Cells("Familia").Text,
                                                            row.Cells("Material").Text,
                                                            row.Cells("Color").Text,
                                                            row.Cells("Talla_No_Modificar").Text,
                                                            row.Cells("CodigoRapido").Text,
                                                            row.Cells("Codigo").Text,
                                                            row.Cells("Descripción").Text,
                                                            row.Cells("CantEmpaque").Text)
                    Else
                        dtCodigosNoActualizados.Rows.Add(row.Cells("ProductoEstiloId_No_Modificar").Text,
                                                            row.Cells("ModeloYuyin_No_Modificar").Text,
                                                            row.Cells("Corrida").Text,
                                                            row.Cells("Marca").Text,
                                                            row.Cells("Colección").Text,
                                                            row.Cells("Estilo").Text,
                                                            row.Cells("Línea").Text,
                                                            row.Cells("Familia").Text,
                                                            row.Cells("Material").Text,
                                                            row.Cells("Color").Text,
                                                            row.Cells("Talla_No_Modificar").Text,
                                                            row.Cells("CodigoRapido").Text,
                                                            row.Cells("Codigo").Text,
                                                            row.Cells("Descripción").Text,
                                                            row.Cells("CantEmpaque").Text)
                    End If


                End If


            Next

            If dtCodigosNoActualizados.Rows.Count > 0 Then
                Dim objCodigosNoImportados As New CodigosCliente_ListaCodigosNoImportadosForm
                objCodigosNoImportados.StartPosition = FormStartPosition.CenterScreen
                objCodigosNoImportados.dtCodigos = dtCodigosNoActualizados
                objCodigosNoImportados.ShowDialog()
            End If

            RecuperarListaCodigosCliente_o_Amece()

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetDataExcel(ByVal fileName As String, ByVal source As String) As DataTable

        Try
            Using cnn As New OleDbConnection( _
                   "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                   "Extended Properties='Excel 12.0 Xml;HDR=Yes';" & _
                   "Data Source=" + fileName)

                Dim sql As String = _
                    String.Format("SELECT * FROM [{0}]", source)

                Dim da As New OleDbDataAdapter(sql, cnn)

                Dim dt As New DataTable()

                da.Fill(dt)

                Return dt

            End Using

        Catch ex As Exception

            Throw

        End Try

    End Function

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 115
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 28
    End Sub

    Private Sub pnlOperaciones_Paint(sender As Object, e As PaintEventArgs) Handles pnlOperaciones.Paint

    End Sub

    Private Sub pnlFiltros_Paint(sender As Object, e As PaintEventArgs) Handles pnlFiltros.Paint

    End Sub

    Private Sub rdoActivoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivoSi.CheckedChanged
        If rdoActivoSi.Checked = True Then
            btnEliminar.Enabled = True
            lblBtnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
            lblBtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub pnlEstado_Paint(sender As Object, e As PaintEventArgs) Handles pnlEstado.Paint

    End Sub

    Private Sub pnlEncabezado_Paint(sender As Object, e As PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub

    Private Sub rdoConCodigoSI_CheckedChanged(sender As Object, e As EventArgs) Handles rdoConCodigoSI.CheckedChanged
        If ValidarCodigoAmece Then
            grbActivos.Enabled = False
        Else
            grbActivos.Enabled = True
        End If
    End Sub

    Private Sub rdoConCodigoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoConCodigoNo.CheckedChanged
        grbActivos.Enabled = False
        rdoActivoSi.Checked = True
    End Sub

    Private Sub rdoActivoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivoNo.CheckedChanged
        If rdoActivoNo.Checked = True Then
            btnEliminar.Enabled = False
            lblBtnEliminar.Enabled = False
        Else
            btnEliminar.Enabled = True
            lblBtnEliminar.Enabled = True
        End If
    End Sub
End Class