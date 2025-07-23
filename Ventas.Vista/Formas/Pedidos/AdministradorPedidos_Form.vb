Imports System.Text
Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AdministradorPedidos_Form

#Region "Variables"
    'Iniciales
    Private tamanioPanelFiltro As Integer = 0
    Private lstInicial As List(Of String)
    Private listPedidoSAY As New List(Of String)
    Private listPedidoSICY As New List(Of String)
    Private listadoFiltro As New ListadoParametrosProyeccionEntregasForm
    Private objBU As New Negocios.AdministradorPedidosEscritorioBU
    Private WithEvents repositorioChkSeleccionar As New RepositoryItemCheckEdit
    Private cambioMostrarPartidas As Boolean = False
    ' Fila actual seleccionada
    Private filaSeleccionada As Integer = -1
    Private filasSeleccionadas As New List(Of Integer)
    Private esPrimerLoad As Boolean = True
    Dim PedidoEnPlanFabricacion As String = String.Empty
    Dim leerAsignados As Boolean = False

#End Region

    Private Sub AdministradorPedidos_Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If esPrimerLoad = False Then
            'Mostrar()
        End If
    End Sub

    Private Sub AdministradorPedidos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cedis As Integer

        If cboxNaveAlmacen.Items.Count = 0 Then
            Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)
        End If

        cedis = cboxNaveAlmacen.SelectedValue


        CargarEstatusPorDefecto()
        tamanioPanelFiltro = pnlFiltros.Height
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        rdbCaptura.Checked = True
        ActualizarBusquedaFecha()
        ActualizarConteoyFechaConsulta()
        MostrarFiltros()
        permisos()
        WindowState = FormWindowState.Maximized
    End Sub

#Region "Acciones Filtros"

    Public Sub permisos()
        'PERMISO PARA NO VER EL BOTON DE CANCELAR PEDIDO
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMON_MOD_PEDIDOS", "CANCELAR_PEDIDO") Then
            pnlCancelarPedido.Visible = False
        Else
            pnlCancelarPedido.Visible = True
        End If
        ''  PERMISO PARA VER SOLO LOS PEDIDOS DE SUS CLIENTES
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMON_MOD_PEDIDOS", "ASIGNADOS") Then
            leerAsignados = True
        End If

    End Sub



    Private Sub reiniciarGrid(grdFiltro As UltraGrid)
        grdFiltro.DataSource = lstInicial
    End Sub

    Private Sub abrirSeleccionFiltro(grdFiltro As UltraGrid, tipoBusqueda As Integer)
        listadoFiltro.gridListadoParametros.DataSource = Nothing
        listadoFiltro.tipo_busqueda = tipoBusqueda
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltro.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next


        listadoFiltro.listaParametroID = listaParametroID
        listadoFiltro.ShowDialog(Me)
        If Not listadoFiltro.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listadoFiltro.listParametros.Rows.Count = 0 Then
            grdFiltro.DataSource = Nothing
            Return
        End If

        grdFiltro.DataSource = listadoFiltro.listParametros

        For i = 0 To grdFiltro.DisplayLayout.Bands(0).Columns.Count - 1
            grdFiltro.DisplayLayout.Bands(0).Columns(IIf(i <> 2, i, 0)).Hidden = True
        Next
    End Sub

    Private Sub btnLimpiarFiltroEstatusPedido_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEstatusPedido.Click
        reiniciarGrid(grdEstatusPedido)
    End Sub

    Private Sub btnAgregarFiltroEstatusPedido_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEstatusPedido.Click
        abrirSeleccionFiltro(grdEstatusPedido, 20)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub


    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        reiniciarGrid(grdPedidoSAY)
        listPedidoSAY.Clear()
    End Sub

    Private Sub btnAgregarFiltroFamiliaVentas_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroFamiliaVentas.Click
        abrirSeleccionFiltro(grdFamiliaVentas, 21)
    End Sub


    Private Sub btnLimpiarFiltroFamiliaVentas_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamiliaVentas.Click
        reiniciarGrid(grdFamiliaVentas)
        listPedidoSICY.Clear()
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        reiniciarGrid(grdCliente)
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        abrirSeleccionFiltro(grdCliente, 1)
    End Sub

    Private Sub btnLimpiarFiltroAtencionClientes_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAtencionClientes.Click
        reiniciarGrid(grdAtencionClientes)
    End Sub

    Private Sub btnAgregarFiltroAtencionClientes_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroAtencionClientes.Click
        abrirSeleccionFiltro(grdAtencionClientes, 3)
    End Sub

    Private Sub btnLimpiarFiltroAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgenteVentas.Click
        reiniciarGrid(grdAgenteVentas)
    End Sub

    Private Sub btnAgregarFiltroAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroAgenteVentas.Click
        abrirSeleccionFiltro(grdAgenteVentas, 4)
    End Sub

    Private Sub btnLimpiarFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroModelo.Click
        reiniciarGrid(grdModelo)
    End Sub

    Private Sub btnAgregarFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroModelo.Click
        abrirSeleccionFiltro(grdModelo, 7)
    End Sub

    Private Sub btnLimpiarFiltroColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColor.Click
        reiniciarGrid(grdColor)
    End Sub

    Private Sub btnAgregarFiltroColor_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroColor.Click
        abrirSeleccionFiltro(grdColor, 9)
    End Sub

    Private Sub btnLimpiarFiltroCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCorrida.Click
        reiniciarGrid(grdCorrida)
    End Sub

    Private Sub btnAgregarFiltroCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCorrida.Click
        abrirSeleccionFiltro(grdCorrida, 10)
    End Sub

    Private Sub btnLimpiarFiltroPiel_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPiel.Click
        reiniciarGrid(grdPiel)
    End Sub

    Private Sub btnAgregarFiltroPiel_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroPiel.Click
        abrirSeleccionFiltro(grdPiel, 8)
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        reiniciarGrid(grdMarca)
    End Sub

    Private Sub btnAgregarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroMarca.Click
        abrirSeleccionFiltro(grdMarca, 5)
    End Sub

    Private Sub btnLimpiarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColeccion.Click
        reiniciarGrid(grdColeccion)
    End Sub

    Private Sub btnAgregarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroColeccion.Click
        abrirSeleccionFiltro(grdColeccion, 6)
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub ActualizarBusquedaFecha()
        Dim activo = chkBuscarPorFecha.Checked
        rdbCaptura.Enabled = activo
        rdbEnviadoSICY.Enabled = activo
        rdbEntregaCliente.Enabled = activo
        rdbEntrega.Enabled = activo
        rdbCancelacion.Enabled = activo
        dtpFechaInicio.Enabled = activo
        dtpFechaFin.Enabled = activo
    End Sub

    Private Sub chkBuscarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscarPorFecha.CheckedChanged
        ActualizarBusquedaFecha()
    End Sub

#End Region

#Region "Initialize Layout Grids"
    Private Sub grdEstatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatusPedido.InitializeLayout
        grid_diseño(grdEstatusPedido)
        grdEstatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus Pedido"
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamiliaVentas.InitializeLayout
        grid_diseño(grdFamiliaVentas)
        grdFamiliaVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdAtencionClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtencionClientes.InitializeLayout
        grid_diseño(grdAtencionClientes)
        grdAtencionClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atn. Cliente"
    End Sub

    Private Sub grdAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgenteVentas.InitializeLayout
        grid_diseño(grdAgenteVentas)
        grdAgenteVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente"
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColor.InitializeLayout
        grid_diseño(grdColor)
        grdColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Color"
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdPiel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPiel.InitializeLayout
        grid_diseño(grdPiel)
        grdPiel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel"
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub
#End Region

#Region "Formato Tablas"
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If

        Next
    End Sub

#End Region

#Region "Acciones Botones Arriba Abajo"
    Private Sub OcultarFiltros()
        pnlFiltros.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlFiltros.Height = tamanioPanelFiltro
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub

#End Region

#Region "Eventos"
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub btnCancelarPedido_Click(sender As Object, e As EventArgs) Handles btnCancelarPedido.Click
        If chkMostrarPartidas.Checked Then
            CancelarPorPartidas()
        Else
            CancelarPedidos()
            'AbrirMotivoCancelacionPedido()
        End If

    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        AbriDetalle()
    End Sub

    Private Sub btnVerLotes_Click(sender As Object, e As EventArgs) Handles btnVerLotes.Click
        AbrirConsultaLotes()
    End Sub

    Private Sub btnFoliosCancelados_Click(sender As Object, e As EventArgs) Handles btnFoliosCancelados.Click
        AbrirFoliosCancelados()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        reiniciarGridTodos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub grdDatosPedidos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosPedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chkMostrarPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarPartidas.CheckedChanged
        If Not chkMostrarPartidas.Checked Then
            grpFiltroEstatusPedido.Text = "Estatus Pedido"
        Else
            grpFiltroEstatusPedido.Text = "Estatus Partida"
        End If
        cambioMostrarPartidas = True
    End Sub

    Private Sub grdEstatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamiliaVentas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamiliaVentas.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdAtencionClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAtencionClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAtencionClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub grdAgenteVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAgenteVentas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAgenteVentas.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPiel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPiel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPiel.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdDatosPedidos_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdDatosPedidos.RowCellStyle
        ColorearRegistros(e)
    End Sub

    Private Sub grdDatosPedidos_RowClick(sender As Object, e As RowClickEventArgs) Handles grdDatosPedidos.RowClick
        If e.Clicks = 2 Then
            AbrirDetalleDobleClic()
        End If
    End Sub

    Private Sub MarcarSeleccionado(ByVal sender As Object, ByVal e As EventArgs) Handles repositorioChkSeleccionar.EditValueChanged
        Dim fila = grdDatosPedidos.FocusedRowHandle
        Dim seleccionado As Boolean = grdDatosPedidos.GetRowCellValue(fila, "Seleccionar")

        If seleccionado Then
            filasSeleccionadas.Add(fila)
        Else
            filasSeleccionadas.Remove(fila)
        End If

    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        'Dim checked As Boolean = chkSeleccionarTodo.Checked
        'Dim estatus As String = String.Empty

        ''For index = 0 To grdDatosPedidos.RowCount - 1
        ''    estatus = grdDatosPedidos.GetRowCellValue(index, "estatus").ToString()
        ''    If Not (estatus.Equals("DESCARTADO") Or estatus.Equals("CANCELADO") Or estatus.Equals("ENTREGADO")) Then
        ''        grdDatosPedidos.SetRowCellValue(index, "Seleccionar", checked)
        ''        MarcarSeleccionado(Nothing, Nothing)
        ''    End If

        ''Next

        'For i = 0 To grdDatosPedidos.RowCount - 1
        '    grdDatosPedidos.SetRowCellValue(i, "Seleccionar", chkSeleccionarTodo.Checked)
        'Next
        'Dim checked As Boolean = chkSeleccionarTodo.Checked
        'Dim estatus As String = String.Empty

        ''For index = 0 To grdDatosPedidos.RowCount - 1
        ''    estatus = grdDatosPedidos.GetRowCellValue(index, "estatus").ToString()
        ''    If Not (estatus.Equals("DESCARTADO") Or estatus.Equals("CANCELADO") Or estatus.Equals("ENTREGADO")) Then
        ''        grdDatosPedidos.SetRowCellValue(index, "Seleccionar", checked)
        ''        MarcarSeleccionado(Nothing, Nothing)
        ''    End If

        ''Next

        'For i = 0 To grdDatosPedidos.RowCount - 1
        '    grdDatosPedidos.SetRowCellValue(i, "Seleccionar", chkSeleccionarTodo.Checked)
        'Next

        ' Dim estatus As String = String.Empty
        Dim dtResultado As DataTable

        Dim DVListadoOTs As DataView = CType(grdDatosPedidos.DataSource, DataView)
        dtResultado = DVListadoOTs.Table.Copy()

        Dim lista = dtResultado.AsEnumerable.ToList()

        For Each fila As DataRow In lista
            fila.Item("Seleccionar") = chkSeleccionarTodo.Checked
        Next

        grdPedidos.DataSource = dtResultado
    End Sub
#End Region


#Region "Diseño Grid"
    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosPedidos)

        If Not chkMostrarPartidas.Checked Then
            DisenioGrid_Pedidos()
        Else
            DisenioGrid_Partidas()
        End If

    End Sub

    Private Sub DisenioGrid_Pedidos()
        grdDatosPedidos.Columns(0).OptionsColumn.AllowEdit = True

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosPedidos.Columns("Seleccionar").Caption = " "
        grdDatosPedidos.Columns("Seleccionar").BestFit()
        grdDatosPedidos.Columns("pedidoId").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosPedidos.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosPedidos.Columns("pedidoSICY").BestFit()
        grdDatosPedidos.Columns("ordenCliente").Caption = "Orden" + vbCrLf + "Cliente"
        grdDatosPedidos.Columns("cliente").Caption = "Cliente"
        grdDatosPedidos.Columns("fechaCaptura").Caption = "F Captura"
        grdDatosPedidos.Columns("fechaEntregaCliente").Caption = "F Entrega" + vbCrLf + " Cliente"
        grdDatosPedidos.Columns("fechaEntregaProgramacion").Caption = "F Entrega" + vbCrLf + "Programación"
        grdDatosPedidos.Columns("fechaSolicitaCliente").Caption = "F Soliciata" + vbCrLf + "Pedido"
        grdDatosPedidos.Columns("pares").Caption = "Pares"
        grdDatosPedidos.Columns("pares").BestFit()
        grdDatosPedidos.Columns("paresCancelados").Caption = "Pares" + vbCrLf + "Cancelados"
        grdDatosPedidos.Columns("paresApartados").Caption = "Pares" + vbCrLf + "Apartados"
        grdDatosPedidos.Columns("paresEntregados").Caption = "Pares" + vbCrLf + "Entregados"
        grdDatosPedidos.Columns("paresPendientes").Caption = "Pares" + vbCrLf + "Pendientes"
        grdDatosPedidos.Columns("estatus").Caption = "Estatus"
        grdDatosPedidos.Columns("ejecutivo").Caption = "Ejecutivo"
        grdDatosPedidos.Columns("agente").Caption = "Agente"
        grdDatosPedidos.Columns("numOt").Caption = "Núm." + vbCrLf + "OT"
        grdDatosPedidos.Columns("numOt").BestFit()
        grdDatosPedidos.Columns("numFacturas").Caption = "Núm. Facturas"
        grdDatosPedidos.Columns("numOtDes").Caption = "Núm. OT Des."

        grdDatosPedidos.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("pares").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresCancelados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresCancelados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresApartados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresApartados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresEntregados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresEntregados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresPendientes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresPendientes").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("numOt").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("numOt").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("numFacturas").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("numFacturas").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("numOtDes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("numOtDes").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosPedidos.Columns("Seleccionar").ColumnEdit = repositorioChkSeleccionar

        grdDatosPedidos.Columns("pedidoId").BestFit()
        grdDatosPedidos.Columns("cliente").Width = 225
        grdDatosPedidos.Columns("pedidoId").BestFit()
        grdDatosPedidos.Columns("pedidoSICY").BestFit()
        grdDatosPedidos.Columns("estatus").Width = 130
    End Sub

    Private Sub DisenioGrid_Partidas()
        grdDatosPedidos.Columns(0).OptionsColumn.AllowEdit = True

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosPedidos.Columns("Seleccionar").Caption = " "
        grdDatosPedidos.Columns("Seleccionar").BestFit()
        grdDatosPedidos.Columns("pedidoId").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosPedidos.Columns("pedidoId").Width = 80
        grdDatosPedidos.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosPedidos.Columns("pedidoSICY").BestFit()
        'grdDatosPedidos.Columns("pedidoSICY").Visible = False
        grdDatosPedidos.Columns("partida").Caption = "Partida"
        grdDatosPedidos.Columns("partida").BestFit()
        grdDatosPedidos.Columns("ordenCliente").Caption = "Orden" + vbCrLf + "Cliente"
        grdDatosPedidos.Columns("ordenCliente").Width = 120
        grdDatosPedidos.Columns("cliente").Caption = "Cliente"
        grdDatosPedidos.Columns("tienda").Caption = "Tienda"
        grdDatosPedidos.Columns("fechaCaptura").Caption = "F Captura"
        grdDatosPedidos.Columns("fechaEntregaCliente").Caption = "F Entrega" + vbCrLf + " Cliente"
        grdDatosPedidos.Columns("fechaEntregaProgramacion").Caption = "F Entrega" + vbCrLf + "Programación"
        grdDatosPedidos.Columns("fechaSolicitaCliente").Caption = "F Soliciada" + vbCrLf + "Pedido"
        grdDatosPedidos.Columns("pares").Caption = "Pares"
        grdDatosPedidos.Columns("pares").BestFit()
        grdDatosPedidos.Columns("paresCancelados").Caption = "Pares" + vbCrLf + "Cancelados"
        grdDatosPedidos.Columns("paresApartados").Caption = "Pares" + vbCrLf + "Apartados"
        grdDatosPedidos.Columns("paresEntregados").Caption = "Pares" + vbCrLf + "Entregados"
        grdDatosPedidos.Columns("paresPendientes").Caption = "Pares" + vbCrLf + "Pendientes"
        grdDatosPedidos.Columns("importe").Caption = "Importe"
        grdDatosPedidos.Columns("total").Caption = "Total"
        grdDatosPedidos.Columns("anotacion").Caption = "Anotación"
        grdDatosPedidos.Columns("articulo").Caption = "Artículo"
        grdDatosPedidos.Columns("paresDesasignacion").Caption = "Pares En" + vbCrLf + "Desasignación"
        grdDatosPedidos.Columns("estatus").Caption = "Estatus" + vbCrLf + "Partida"
        grdDatosPedidos.Columns("estatus").BestFit()
        grdDatosPedidos.Columns("estatusPedido").Caption = "Estatus" + vbCrLf + "Pedido"
        grdDatosPedidos.Columns("estatusPedido").BestFit()

        grdDatosPedidos.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("pares").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresCancelados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresCancelados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresApartados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresApartados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresEntregados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresEntregados").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("paresPendientes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresPendientes").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("importe").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("importe").DisplayFormat.FormatString = "c"
        grdDatosPedidos.Columns("total").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("total").DisplayFormat.FormatString = "c"
        grdDatosPedidos.Columns("paresDesasignacion").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("paresDesasignacion").DisplayFormat.FormatString = "n0"
        grdDatosPedidos.Columns("Precio").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("Precio").DisplayFormat.FormatString = "c"

        CrearSummarAlPiePantalla()

        grdDatosPedidos.Columns("Seleccionar").ColumnEdit = repositorioChkSeleccionar

        grdDatosPedidos.Columns("pedidoId").BestFit()
        grdDatosPedidos.Columns("partida").Width = 55
        grdDatosPedidos.Columns("cliente").Width = 225
        grdDatosPedidos.Columns("pedidoId").BestFit()
        grdDatosPedidos.Columns("tienda").Width = 200
        grdDatosPedidos.Columns("articulo").Width = 400
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grdDatosPedidos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosPedidos.GroupSummary.Clear()

        For index = 0 To grdDatosPedidos.Columns.Count - 1
            If grdDatosPedidos.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grdDatosPedidos.Columns(index).Name.Replace("col", "")

                grdDatosPedidos.Columns(index).Summary.Clear()
                grdDatosPedidos.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grdDatosPedidos.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grdDatosPedidos.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grdDatosPedidos.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub ColorearRegistros(e As RowCellStyleEventArgs)
        Dim filas As Integer = e.RowHandle
        Dim auxEstatus As String = grdDatosPedidos.GetRowCellValue(filas, "estatus")

        If filas >= 0 Then
            If auxEstatus.Equals("DESCARTADO") Or auxEstatus.Equals("CANCELADO") Then
                e.Appearance.ForeColor = lblCancelado.ForeColor
            ElseIf auxEstatus.Equals("ENTREGADO") Or
                auxEstatus.Equals("FACTURADO") Or
                auxEstatus.Equals("EMBARQUE") Or
                auxEstatus.Equals("PROYECTADO") Then

                e.Appearance.BackColor = Color.LightGray
                e.Appearance.ForeColor = Color.Black
            End If

        End If
    End Sub

    Private Sub grdDatosPedidos_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosPedidos.ShowingEditor
        Dim View As GridView = sender
        Dim estatus As String = View.GetRowCellValue(View.FocusedRowHandle, "estatus").ToString()
        'If estatus.Equals("DESCARTADO") Or estatus.Equals("CANCELADO") Or estatus.Equals("ENTREGADO") Then
        '    e.Cancel = True
        '    View.SetRowCellValue(View.FocusedRowHandle, "Seleccionar", False)
        'End If
    End Sub
#End Region

    '' Aquí se agrupan los métodos de funcionalidad para la pantalla
#Region "Metodos"

    Private Sub CargarEstatusPorDefecto()
        Dim dtResultado As New DataTable
        Dim dtEstatus As New DataTable

        dtResultado = objBU.Administrador_DatosInicialesPermisos

        dtEstatus = dtResultado.Clone

        For index = 0 To dtResultado.Rows.Count - 1
            If dtResultado.Rows(index).Item("filtro").Equals("Estatus") Then
                dtEstatus.Rows.Add(dtResultado.Rows(index).ItemArray)
            End If
        Next

        dtEstatus.Columns("valorTexto").Caption = "Nombre"

        grdEstatusPedido.DataSource = dtEstatus

        For i = 0 To grdEstatusPedido.DisplayLayout.Bands(0).Columns.Count - 1
            grdEstatusPedido.DisplayLayout.Bands(0).Columns(IIf(i <> 2, i, 0)).Hidden = True
        Next
    End Sub

    '' Reinicia todos los filtros de grid y las fechas
    Private Sub reiniciarGridTodos()
        reiniciarGrid(grdEstatusPedido)
        reiniciarGrid(grdPedidoSAY)
        reiniciarGrid(grdFamiliaVentas)
        reiniciarGrid(grdCliente)
        reiniciarGrid(grdAtencionClientes)
        reiniciarGrid(grdAgenteVentas)
        reiniciarGrid(grdModelo)
        reiniciarGrid(grdColor)
        reiniciarGrid(grdCorrida)
        reiniciarGrid(grdPiel)
        reiniciarGrid(grdMarca)
        reiniciarGrid(grdColeccion)

        listPedidoSAY.Clear()
        listPedidoSICY.Clear()

        chkBuscarPorFecha.Checked = False
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        chkMostrarPartidas.Checked = False

        grdPedidos.DataSource = Nothing
    End Sub

    '' Metodo que regresa un objeto con los filtros a consultar
    Private Function RecuperarFiltros() As Entidades.FiltroAdministradorPedido
        Dim objFiltros As New Entidades.FiltroAdministradorPedido
        ' Filtro Fecha
        If chkBuscarPorFecha.Checked Then
            For Each Ctrl As RadioButton In grpFiltroFecha.Controls
                If TypeOf Ctrl Is RadioButton Then
                    If Ctrl.Checked Then
                        objFiltros.TipoFecha = Ctrl.TabIndex
                        Exit For
                    End If
                End If
            Next
        Else
            objFiltros.TipoFecha = 0
        End If

        objFiltros.FechaInicio = dtpFechaInicio.Value
        objFiltros.FechaFin = dtpFechaFin.Value

        objFiltros.MostrarPartidas = chkMostrarPartidas.Checked

        'Estatus Pedido
        objFiltros.EstatusPedido = RecuperarFiltroGrid(grdEstatusPedido)

        'Pedidos
        objFiltros.PedidoSAY = RecuperarFiltroGrid(grdPedidoSAY)

        ' Pedido SICY
        objFiltros.PedidoSICY = RecuperarFiltroGrid(grdFamiliaVentas)

        ' Cliente
        objFiltros.Cliente = RecuperarFiltroGrid(grdCliente)

        ' Atencion Clientes
        objFiltros.AtnCliente = RecuperarFiltroGrid(grdAtencionClientes)

        ' Agente Ventas
        objFiltros.AgenteVentas = RecuperarFiltroGrid(grdAgenteVentas)

        ' Modelo
        objFiltros.Modelo = RecuperarFiltroGrid(grdModelo)

        ' Color
        objFiltros.Color = RecuperarFiltroGrid(grdColor)

        ' Corrida
        objFiltros.Corrida = RecuperarFiltroGrid(grdCorrida)

        ' Piel
        objFiltros.Piel = RecuperarFiltroGrid(grdPiel)

        ' Marca
        objFiltros.Marca = RecuperarFiltroGrid(grdMarca)

        ' Coleccion
        objFiltros.Coleccion = RecuperarFiltroGrid(grdColeccion)

        ' CEDIS
        objFiltros.CEDIS = cboxNaveAlmacen.SelectedValue

        Return objFiltros
    End Function

    Private Function RecuperarFiltroGrid(grid As UltraGrid) As String
        Dim resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                resultado += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                resultado += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return resultado
    End Function

    '' Metodo para ejecutar la consulta
    Private Sub Mostrar()
        Dim dtResultado As New DataTable()
        Dim objFiltro As Entidades.FiltroAdministradorPedido = Nothing
        ' Obtiene los filtros en objFiltros
        objFiltro = RecuperarFiltros()
        LimpiarColumnas()
        esPrimerLoad = False

        Try
            Cursor = Cursors.WaitCursor

            grdPedidos.DataSource = Nothing
            'dtResultado = objBU.ConsultarPedidos(objFiltro)
            dtResultado = objBU.ConsultarPedidos(objFiltro, leerAsignados)

            If dtResultado.Rows.Count > 0 Then
                dtResultado.DefaultView.Sort = "pedidoid DESC"
                grdPedidos.DataSource = dtResultado
                DisenioGrid()
                OcultarFiltros()
                chkSeleccionarTodo.Checked = False
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
            End If

            ActualizarConteoyFechaConsulta()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ActualizarConteoyFechaConsulta()
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "Hubo un error al generar los datos para mostrar, intente de nuevo " + ex.Message)
        End Try
    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosPedidos.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    '' Se limpian las columnas cada que se cambian de la vista normal a las partidas para que no arroje error
    Private Sub LimpiarColumnas()
        If cambioMostrarPartidas Then
            grdDatosPedidos.Columns.Clear()
            cambioMostrarPartidas = False
        End If
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosPedidos.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosPedidos.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosPedidos.OptionsPrint.AutoWidth = False
                            grdDatosPedidos.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_Pedidos_" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosPedidos.ExportToXlsx(FileName)

                            Tools.MostrarMensaje(Tools.Mensajes.Success, "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay datos para exportar")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se pudo exportar los datos: " + ex.Message.ToString())
        End Try
    End Sub

    Private Sub AbriDetalle()
        Dim contadorRegistrosSeleccionados As Integer = 1
        Dim pedidoAnterior As Integer = 0
        Dim fila As Integer = -1

        For index = 0 To grdDatosPedidos.RowCount - 1
            If CBool(grdDatosPedidos.GetRowCellValue(index, "Seleccionar")) Then
                If grdDatosPedidos.GetRowCellValue(index, "pedidoId") <> pedidoAnterior And pedidoAnterior > 0 Then
                    contadorRegistrosSeleccionados += 1
                End If
                pedidoAnterior = grdDatosPedidos.GetRowCellValue(index, "pedidoId")
                fila = index
            End If
        Next

        If contadorRegistrosSeleccionados = 1 Then
            If fila >= 0 Then
                Dim vistaDetalle As New AdministradorPedidosDetalle_Form
                Dim entPedido = CrearObjPedido(fila)
                vistaDetalle.SetEntPedido(entPedido)
                vistaDetalle.MdiParent = MdiParent
                vistaDetalle.Show()

                'Mostrar()

            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se ha reconocido la selección")
            End If

        Else
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "Seleccione sólo un pedido a la vez.")
        End If

    End Sub

    Private Sub AbrirDetalleDobleClic()
        Dim fila As Integer = -1

        If grdDatosPedidos.GetSelectedRows.Count > 0 Then
            fila = grdDatosPedidos.GetSelectedRows(0)
        End If

        If fila >= 0 Then
            Dim vistaDetalle As New AdministradorPedidosDetalle_Form
            Dim entPedido = CrearObjPedido(fila)
            vistaDetalle.SetEntPedido(entPedido)
            vistaDetalle.MdiParent = MdiParent
            vistaDetalle.Show()
        Else
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se ha reconocido la selección")
        End If
    End Sub

    Private Sub AbrirFoliosCancelados()
        Dim vistaFoliosCancelacion As New AdministradorFoliosCancelacion_Form
        vistaFoliosCancelacion.MdiParent = MdiParent
        vistaFoliosCancelacion.Show()
    End Sub

    Private Function CrearObjPedido(fila As Integer) As Entidades.InfoPedido
        Dim pedido As New Entidades.InfoPedido
        Dim dtResultado As New DataTable

        pedido.PedidoSAY = CInt(grdDatosPedidos.GetRowCellValue(fila, "pedidoId").ToString)

        dtResultado = objBU.ConsultarPedidoEncabezado(pedido.PedidoSAY)

        pedido.Cliente = dtResultado.Rows(0).Item("cliente").ToString
        If IsNothing(dtResultado.Rows(0).Item("pedidoSICY")) = True Then
            pedido.PedidoSICY = CInt(dtResultado.Rows(0).Item("pedidoSICY").ToString)
            pedido.FechaCaptura = IIf(IsDBNull(dtResultado.Rows(0).Item("fechaEnviadoSICY").ToString), Nothing, dtResultado.Rows(0).Item("fechaEnviadoSICY").ToString)
        Else
            pedido.PedidoSICY = 0
        End If

        pedido.OrdenCliente = dtResultado.Rows(0).Item("ordenCliente").ToString



        pedido.FechaEntregaCliente = IIf(IsDBNull(dtResultado.Rows(0).Item("fechaEntregaCliente").ToString), Nothing, dtResultado.Rows(0).Item("fechaEntregaCliente").ToString)
        pedido.Ejecutivo = dtResultado.Rows(0).Item("ejecutivo").ToString
        pedido.Agente = IIf(IsDBNull(dtResultado.Rows(0).Item("agente").ToString), "", dtResultado.Rows(0).Item("agente").ToString)

        'pedido.Cliente = grdDatosPedidos.GetRowCellValue(fila, "cliente").ToString
        'pedido.PedidoSAY = CInt(grdDatosPedidos.GetRowCellValue(fila, "pedidoId").ToString)
        'pedido.PedidoSICY = CInt(IIf(IsDBNull(grdDatosPedidos.GetRowCellValue(fila, "pedidoSICY")), 0, grdDatosPedidos.GetRowCellValue(fila, "pedidoSICY").ToString))
        'pedido.OrdenCliente = grdDatosPedidos.GetRowCellValue(fila, "ordenCliente").ToString
        'pedido.FechaCaptura = grdDatosPedidos.GetRowCellValue(fila, "fechaCaptura")
        'pedido.FechaEntregaCliente = IIf(IsDBNull(grdDatosPedidos.GetRowCellValue(fila, "fechaEntregaCliente")), Nothing, grdDatosPedidos.GetRowCellValue(fila, "fechaEntregaCliente").ToString)
        'pedido.Ejecutivo = grdDatosPedidos.GetRowCellValue(fila, "ejecutivo")
        'pedido.Agente = IIf(IsDBNull(grdDatosPedidos.GetRowCellValue(fila, "agente")), "", grdDatosPedidos.GetRowCellValue(fila, "agente"))

        Return pedido
    End Function

    Private Function ValidaPedidoEnPlanFabricacionEstatusEnviadoPPCP(listPedidos As List(Of Integer))
        Dim Resultado As Boolean = False
        Dim dtResultado As New DataTable
        Dim pedidos As String = String.Empty


        For index = 0 To listPedidos.Count - 1
            If index = 0 Then
                pedidos += " " + Replace(listPedidos(index).ToString, ",", "")
            Else
                pedidos += ", " + Replace(listPedidos(index).ToString, ",", "")
            End If
        Next


        dtResultado = objBU.ValidarPedidoEnPlanFabricacion_EstatusEnviadoPPCP(pedidos)

        If dtResultado.Rows.Count > 0 Then

            For Each row As DataRow In dtResultado.Rows
                If row.Item("EstatusPlanFabricacion") = 430 And row.Item("EstatusPlanFabricacion") <> 0 Then

                    If PedidoEnPlanFabricacion <> "" Then
                        PedidoEnPlanFabricacion += ","
                    End If

                    PedidoEnPlanFabricacion += row.Item("PedidoEnPlanFabricacion").ToString

                    Resultado = True
                End If
            Next
        End If

        Return Resultado
    End Function

    Private Sub AbrirMotivoCancelacionPedido()
        Dim vistaMotivoCancelacion As New CancelacionPedidos_Form
        Dim listPedidosSAY As New List(Of Integer)
        Dim listPedidosSAYPreCaptura As New List(Of Integer)
        Dim partidas As New DataTable
        Dim partidasString As String = String.Empty
        Dim pedidoSinPartidas As Integer = 0

        Try
            listPedidosSAY = ObtenerPedidosParaCancelar()
            listPedidosSAYPreCaptura = ObtenerPedidosParaCancelarPreCaptura()

            If listPedidosSAY.Count = 0 And listPedidosSAYPreCaptura.Count = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se seleccionó ningún pedido")
                Return
            End If

            If ValidaPedidoEnPlanFabricacionEstatusEnviadoPPCP(listPedidosSAY) = True Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "Pedido " + PedidoEnPlanFabricacion + " en Plan de Fabricación Enviado a Nave, Comunique a PPCP")
                Exit Sub
            End If


            If listPedidosSAYPreCaptura.Count > 0 Then
                CancelarPedidosPreCaptura(listPedidosSAYPreCaptura)
            End If

            If listPedidosSAY.Count > 0 Then

                objBU.ValidarPartidasEnApartadosDesdePedidos(listPedidosSAY)

                For index = 0 To listPedidosSAY.Count - 1
                    partidas = objBU.ObtenerPartidasDelPedido(listPedidosSAY(index))
                    partidasString = IIf(IsDBNull(partidas.Rows(0).Item("partidas")), "", partidas.Rows(0).Item("partidas"))
                    objBU.ValidarPartidas(listPedidosSAY(index), partidasString)
                Next

                Dim dialogResult As New DialogResult

                vistaMotivoCancelacion.SetPedidosSAY(listPedidosSAY)
                dialogResult = vistaMotivoCancelacion.ShowDialog()

                If dialogResult <> DialogResult.Cancel Then
                    Mostrar()
                End If

            End If

            'Mostrar()
        Catch ex As Exception
            If Not String.IsNullOrEmpty(ex.Message) Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
            End If
        End Try

    End Sub

    Private Sub CancelarPorPartidas()
        Dim pedidoSAY As Integer = 0
        Dim partidas As String = String.Empty
        Dim formCancelacionPedido As New CancelacionPedidos_Form
        Dim ResultadoCancelacion As New CancelacionPedidos_ResultadoForm
        Dim dtResultado As DataTable
        Dim DtPedidos As New DataTable

        Dim pedidosConPartidasACancelar As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

        Try

            Cursor = Cursors.WaitCursor

            DtPedidos.Columns.Add("Pedido")
            DtPedidos.Columns.Add("Partida")
            DtPedidos.Columns.Add("Cancelado", GetType(Boolean))


            Dim DVListadoOTs As DataView = CType(grdDatosPedidos.DataSource, DataView)
            dtResultado = DVListadoOTs.Table.Copy()

            If dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Count = 0 Then
                Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una partida.")
                Cursor = Cursors.Default
                Return
            Else

                Dim PartidasEntregadasCanceladas = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True And (x.Item("estatus") = "ENTREGADO" Or x.Item("estatus") = "CANCELADO" Or x.Item("estatus") = "EN DESASIGNACIÓN")).ToList()

                If PartidasEntregadasCanceladas.Count() > 0 Then
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se puede cancelar partidas canceladas o entregadas.")
                    Cursor = Cursors.Default
                    Return
                Else

                    For Each Fila As String In dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("pedidoid")).Distinct.ToList

                        Dim ListaPartidas = dtResultado.AsEnumerable.Where(Function(x) CBool(x.Item("Seleccionar")) = True And x.Item("pedidoid") = Fila).Select(Function(y) y.Item("partida")).ToList

                        Dim FilaPArtida As DataRow
                        FilaPArtida = DtPedidos.NewRow

                        FilaPArtida.Item("Pedido") = Fila
                        FilaPArtida.Item("Partida") = String.Join(",", ListaPartidas)
                        FilaPArtida.Item("Cancelado") = False

                        DtPedidos.Rows.Add(FilaPArtida)
                    Next

                    formCancelacionPedido.DtPartidasACancelar = DtPedidos
                    formCancelacionPedido.CancelarPorPartidas = True
                    formCancelacionPedido.ShowDialog()


                End If

            End If



            If formCancelacionPedido.DialogResult <> DialogResult.Cancel Then

                Dim ListaPEdidos = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("pedidoid")).Distinct.ToList

                ResultadoCancelacion.PedidoSYAYID = String.Join(",", ListaPEdidos)
                ResultadoCancelacion.ShowDialog()

                Mostrar()
                chkSeleccionarTodo.Checked = False
            End If

            'For i = 0 To grdDatosPedidos.RowCount - 1
            '    If CBool(grdDatosPedidos.GetRowCellValue(i, "Seleccionar")) Then
            '        pedidoSAY = grdDatosPedidos.GetRowCellValue(i, "pedidoId")
            '        partidas = grdDatosPedidos.GetRowCellValue(i, "partida")

            '        If Not pedidosConPartidasACancelar.ContainsKey(pedidoSAY) Then
            '            pedidosConPartidasACancelar.Add(pedidoSAY, "," + partidas)
            '        Else
            '            pedidosConPartidasACancelar(pedidoSAY) += "," + partidas
            '        End If

            '        If pedidosConPartidasACancelar(pedidoSAY).Chars(0).Equals(CChar(",")) Then
            '            pedidosConPartidasACancelar(pedidoSAY) = pedidosConPartidasACancelar(pedidoSAY).Substring(1)
            '        End If
            '    End If
            'Next

            'If pedidosConPartidasACancelar.Count = 0 Then
            '    Throw New Exception("No se ha seleccionado partidas.")
            'End If


            'For index = 0 To pedidosConPartidasACancelar.Count - 1
            '    If pedidosConPartidasACancelar(pedidoSAY).Chars(0).Equals(CChar(",")) Then
            '        pedidosConPartidasACancelar(pedidoSAY) = pedidosConPartidasACancelar(pedidoSAY).Remove(0, 1)
            '    End If
            'Next

            'For Each item As KeyValuePair(Of Integer, String) In pedidosConPartidasACancelar
            '    objBU.ValidarPartidas(item.Key, item.Value)
            'Next

            'Dim dialogResult As New DialogResult

            'formCancelacionPedido.SetPedidosConPartidas(pedidosConPartidasACancelar)
            'dialogResult = formCancelacionPedido.ShowDialog()

            'Cursor = Cursors.Default

            'If dialogResult <> DialogResult.Cancel Then
            '    Mostrar()
            'End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Warning, ex.Message)
        End Try

    End Sub

    Private Function ObtenerPedidosParaCancelar() As List(Of Integer)
        Dim partidasParaCancelar As New List(Of Integer)

        For index = 0 To grdDatosPedidos.RowCount - 1
            If CBool(grdDatosPedidos.GetRowCellValue(index, "Seleccionar")) And
                Not (grdDatosPedidos.GetRowCellValue(index, "estatus").ToString.Equals("PRE-CAPTURA") Or
                grdDatosPedidos.GetRowCellValue(index, "estatus").ToString.Equals("ABIERTO")) Then
                partidasParaCancelar.Add(grdDatosPedidos.GetRowCellValue(index, "pedidoId"))
            End If
        Next

        Return partidasParaCancelar
    End Function

    Private Function ObtenerPedidosParaCancelarPreCaptura() As List(Of Integer)
        Dim partidasParaCancelar As New List(Of Integer)

        For index = 0 To grdDatosPedidos.RowCount - 1
            If CBool(grdDatosPedidos.GetRowCellValue(index, "Seleccionar")) And
                (grdDatosPedidos.GetRowCellValue(index, "estatus").ToString.Equals("PRE-CAPTURA") Or
                 grdDatosPedidos.GetRowCellValue(index, "estatus").ToString.Equals("ABIERTO")) Then
                partidasParaCancelar.Add(grdDatosPedidos.GetRowCellValue(index, "pedidoId"))
            End If
        Next

        Return partidasParaCancelar
    End Function

    Private Sub CancelarPedidosPreCaptura(pedidos As List(Of Integer))
        Dim validado As Boolean = False
        Dim dtResultado As New DataTable
        Dim pedidoACancelarMensaje As New StringBuilder
        Dim confirmarForm As New ConfirmarForm
        Dim resultDialog As New DialogResult
        Dim pedidosCancelados As String = String.Empty
        Dim pedidosNoCancelados As String = String.Empty
        Dim mensajeExito As String = String.Empty

        For index = 0 To pedidos.Count - 1
            pedidoACancelarMensaje.Append(", ")
            pedidoACancelarMensaje.Append(pedidos(index).ToString)

        Next

        pedidoACancelarMensaje = pedidoACancelarMensaje.Remove(0, 1)

        Try
            Cursor = Cursors.WaitCursor
            confirmarForm.mensaje = "¿Cancelar los pedidos: " + pedidoACancelarMensaje.ToString + "?"

            resultDialog = confirmarForm.ShowDialog

            If resultDialog = DialogResult.OK Then
                For i = 0 To pedidos.Count - 1
                    dtResultado = objBU.DescartarPedido(pedidos(i))

                    If dtResultado.Rows.Count > 0 Then
                        If dtResultado.Rows(0).Item(0).ToString.Equals("EXITO") Then
                            pedidosCancelados += "," + pedidos(i).ToString
                        Else
                            pedidosNoCancelados += "," + pedidos(i).ToString
                        End If
                    End If
                Next


                If Not String.IsNullOrEmpty(pedidosCancelados) Then
                    pedidosCancelados = pedidosCancelados.Substring(1)

                    mensajeExito = "Se han cancelado los pedidos: " + pedidosCancelados + "."
                End If

                If Not String.IsNullOrEmpty(pedidosNoCancelados) Then
                    pedidosNoCancelados = pedidosNoCancelados.Substring(1)

                    mensajeExito = "No se pudieron cancelar los pedidos: " + pedidosNoCancelados + "."
                End If

                If Not String.IsNullOrEmpty(mensajeExito) Then
                    Tools.MostrarMensaje(Tools.Mensajes.Success, mensajeExito)
                    Mostrar()
                End If

            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub AbrirConsultaLotes()
        Dim vistaConsultaLotes As New AdministradorPedidosDetalleLotes_Form
        Dim fila As Integer = -1
        Dim pedidoSAY As Integer = 0
        Dim pedidoSICY As Integer = 0
        Dim partidasParaCancelar As New List(Of String)
        Dim dtPartidas As New DataTable
        Dim contadorRegistros As Integer = 1
        Dim dtInformacionLotes As New DataTable
        Dim pedidoAnterior As Integer = 0
        Dim partidas As String = String.Empty

        If Not grdDatosPedidos.Columns("partida") Is Nothing Then


            For i = 0 To grdDatosPedidos.RowCount - 1
                If CBool(grdDatosPedidos.GetRowCellValue(i, "Seleccionar")) Then
                    pedidoSAY = grdDatosPedidos.GetRowCellValue(i, "pedidoId")
                    partidas += "," + grdDatosPedidos.GetRowCellValue(i, "partida").ToString

                    If grdDatosPedidos.GetRowCellValue(i, "pedidoId") <> pedidoAnterior And pedidoAnterior > 0 Then
                        contadorRegistros += 1
                    End If

                    pedidoAnterior = grdDatosPedidos.GetRowCellValue(i, "pedidoId")
                    pedidoSAY = grdDatosPedidos.GetRowCellValue(i, "pedidoId")
                    pedidoSICY = IIf(IsDBNull(grdDatosPedidos.GetRowCellValue(i, "pedidoSICY")), 0, grdDatosPedidos.GetRowCellValue(i, "pedidoSICY"))
                    fila = i

                    If partidas.Chars(0).Equals(CChar(",")) Then
                        partidas = partidas.Substring(1)
                    End If
                End If
            Next

        Else
            For index = 0 To grdDatosPedidos.RowCount - 1
                If CBool(grdDatosPedidos.GetRowCellValue(index, "Seleccionar")) Then
                    If grdDatosPedidos.GetRowCellValue(index, "pedidoId") <> pedidoAnterior And pedidoAnterior > 0 Then
                        contadorRegistros += 1
                    End If
                    pedidoAnterior = grdDatosPedidos.GetRowCellValue(index, "pedidoId")
                    pedidoSAY = grdDatosPedidos.GetRowCellValue(index, "pedidoId")
                    pedidoSICY = IIf(IsDBNull(grdDatosPedidos.GetRowCellValue(index, "pedidoSICY")), 0, grdDatosPedidos.GetRowCellValue(index, "pedidoSICY"))
                    fila = index
                End If
            Next

            dtPartidas = objBU.ObtenerPartidasDelPedido(pedidoSAY)
            partidas = dtPartidas.Rows(0).Item("partidas")
        End If

        If contadorRegistros > 1 Then
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "Seleccione un pedido a la vez")
            Return
        End If

        dtInformacionLotes = objBU.Consultar_InformacionLotes(pedidoSICY, partidas)

        If dtInformacionLotes.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
            Return
        End If

        vistaConsultaLotes.AsignarPedidoSICY(pedidoSICY)
        vistaConsultaLotes.AsignarPartidas(partidas)
        vistaConsultaLotes.ShowDialog()
    End Sub

    Private Sub CancelarPedidos()
        Dim pedidoSAY As Integer = 0
        Dim partidas As String = String.Empty
        Dim formCancelacionPedido As New CancelacionPedidos_Form
        Dim ResultadoCancelacion As New CancelacionPedidos_ResultadoForm
        Dim dtResultado As DataTable
        Dim DtPedidos As New DataTable

        Dim pedidosConPartidasACancelar As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

        Try

            Cursor = Cursors.WaitCursor

            DtPedidos.Columns.Add("Pedido")
            DtPedidos.Columns.Add("Partida")
            DtPedidos.Columns.Add("Cancelado", GetType(Boolean))


            Dim DVListadoOTs As DataView = CType(grdDatosPedidos.DataSource, DataView)
            dtResultado = DVListadoOTs.Table.Copy()

            If dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Count = 0 Then
                Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una partida.")
                Cursor = Cursors.Default
                Return
            Else

                Dim PartidasEntregadasCanceladas = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True And (x.Item("estatus") = "ENTREGADO" Or x.Item("estatus") = "CANCELADO" Or x.Item("estatus") = "EN DESASIGNACIÓN")).ToList()

                If PartidasEntregadasCanceladas.Count() > 0 Then
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se puede cancelar partidas canceladas o entregadas.")
                    Cursor = Cursors.Default
                    Return
                Else

                    For Each Fila As String In dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("pedidoid")).Distinct.ToList


                        Dim FilaPArtida As DataRow
                        FilaPArtida = DtPedidos.NewRow

                        FilaPArtida.Item("Pedido") = Fila
                        FilaPArtida.Item("Partida") = String.Empty
                        FilaPArtida.Item("Cancelado") = False

                        DtPedidos.Rows.Add(FilaPArtida)
                    Next

                    formCancelacionPedido.DtPartidasACancelar = DtPedidos
                    formCancelacionPedido.CancelarPorPartidas = False
                    formCancelacionPedido.ShowDialog()


                End If

            End If



            If formCancelacionPedido.DialogResult <> DialogResult.Cancel Then

                Dim ListaPEdidos = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("pedidoid")).Distinct.ToList

                ResultadoCancelacion.PedidoSYAYID = String.Join(",", ListaPEdidos)
                ResultadoCancelacion.ShowDialog()

                Mostrar()
                chkSeleccionarTodo.Checked = False
            End If


            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Warning, ex.Message)
        End Try

    End Sub


#End Region
End Class