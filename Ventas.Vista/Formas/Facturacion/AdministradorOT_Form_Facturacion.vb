Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports DevExpress.XtraGrid
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils

Public Class AdministradorOT_Form_Facturacion

#Region "VARIABLES GLOBALES"

    Dim ListaPedidoSICY As New List(Of String)
    Dim ListaPedidoSAY As New List(Of String)
    Dim ListaFolio As New List(Of String)
    Dim ListaInicial As New List(Of String)
    Dim FilasSeleccionadas As Integer
    Dim UsuarioId As Integer
    Dim ColaboradorId As Integer
    Dim UsuarioNombre As String
    Dim listClientesSeleccionados As New List(Of Integer)
    Dim listOTsSeleccionadasFA As New List(Of Integer)
    Dim ClienteBloqueadoEntrega As String = "NO"
    Dim lstNumerosPedidosSeleccionadosSAY As New List(Of Integer)
    Dim lstNumerosPedidosSeleccionadosSICY As New List(Of Integer)
    Dim ParidadDocumentoExtranjero As String = "1"
    Dim tipoDocumentoContrarioOIgual As Integer
    Dim DocumentoSeleccionadoParaVerOTs As Integer = 0

    Dim listregistrosAdministradorDeOtsPorfacturar As New List(Of String)
    Dim oTSelecionadasACambiar As String = String.Empty

    Dim OtsCoppelPedido As Integer = 0

    Dim OTCoppelSeleccionadas As String = String.Empty

    Dim PedidoSAYSeleccionado As Integer = 0
    Dim PedidoSICYSeleccionado As Integer = 0
    Dim OrdenClienteSeleccionada As String = String.Empty
    Public facturacionAnticipada As Boolean = False '0 = no, 1 = si

#End Region

#Region "CARGA INICIAL"

    Private Sub AdministradorOT_Form_Facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoSesion As New DataTable()
        Dim dtInformacionCliente As New DataTable()
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim confirmar As New Tools.ConfirmarForm
        Dim objBU_Cliente As New Ventas.Negocios.DocumentosDinamicosBU

        Me.WindowState = FormWindowState.Maximized

        Cursor = Cursors.WaitCursor

        ObtenerCEDISUsuario()

        dtResultadoSesion = objBU.recuperarSesionUsuarioFacturando(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoSesion.Rows(0).Item("SesionAnterior") > 0 And dtResultadoSesion.Rows(0).Item("ClienteID") > 0 Then
            confirmar.mensaje = "Ya existe una sesión para este usuario, ¿desea recuperarla?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    If dtResultadoSesion.Rows(0).Item("TipoFacturacion") = 1 Then
                        'Se agrego campo OT
                        dtInformacionCliente = objBU_Cliente.ObtenerDatosClienteFacturacion(dtResultadoSesion.Rows(0).Item("ClienteID"), dtResultadoSesion.Rows(0).Item("OT"))

                        Me.WindowState = FormWindowState.Minimized

                        Dim ventana As New VistaPreviaFacturacion_Form
                        ventana.MdiParent = Me.MdiParent
                        ventana.dtDatosCliente = dtInformacionCliente
                        ventana.porcentajeFacturacionCapturadoUsuario = 0
                        ventana.porcentajeRemisionCapturadoUsuario = 0
                        ventana.tipo_RazonSocial = ""
                        ventana.porcentajePorRazonsocial = ""
                        ventana.ordenesTrabajoSeleccionadas = ""
                        ventana.sesionFacturacionId = dtResultadoSesion.Rows(0).Item("SesionAnterior")
                        ventana.generacionAutomatica = 0
                        ventana.descripcionEspecial = CBool(dtInformacionCliente.Rows(0).Item("DescripcionEspecial"))
                        ventana.recuperacionSesion = True
                        ventana.Show()

                    ElseIf dtResultadoSesion.Rows(0).Item("TipoFacturacion") = 2 Then

                        Me.WindowState = FormWindowState.Minimized

                        Dim ventana As New GeneracionDocumentosManuales_Form
                        ventana.MdiParent = Me.MdiParent
                        ventana.SesionID = dtResultadoSesion.Rows(0).Item("SesionAnterior")
                        ventana.ClienteID = dtResultadoSesion.Rows(0).Item("ClienteID")
                        ventana.Show()

                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            End If
        End If

        UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ColaboradorId = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        UsuarioNombre = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        grdPedidoSAY.DataSource = ListaInicial
        grdPedidoSICY.DataSource = ListaInicial
        grdFolioOT.DataSource = ListaInicial
        grdCliente.DataSource = ListaInicial
        grdTienda.DataSource = ListaInicial

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        PoblarComboStatus()
        cmboxStatus.SelectedIndex = 0

        grdOts.DataSource = ConsultarOTMostrar()
        DiseñoGridOT()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_OT_PorFacturar", "ALM_FACT_CANCELAR_REFACTURACION") Then
            btnCancelarRefacturacion.Visible = True
            lblTextoCancelarRefacturacion.Visible = True
        Else
            btnCancelarRefacturacion.Visible = False
            lblTextoCancelarRefacturacion.Visible = False
        End If

        Cursor = Cursors.Default

        'Carga nueva edición documentos
        'Dim NumeroFilas As Integer

        'NumeroFilas = bgvOts.DataRowCount
        'For index As Integer = 0 To NumeroFilas Step 1
        '    If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Tipo") = "R" Then
        '        bgvOts.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = True
        '    End If
        'Next

    End Sub




#End Region

#Region "FILTROS"

    Private Sub PoblarComboStatus()
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim dtDatosCombo As New DataTable()

        dtDatosCombo = objBU.consultaStatusCombo()

        cmboxStatus.DataSource = dtDatosCombo
        cmboxStatus.ValueMember = "esta_estatusid"
        cmboxStatus.DisplayMember = "esta_nombre"

    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado
    End Function

    Private Function ObtenerFiltroFecha() As Integer
        Dim Resultado As Integer = 0
        ' 1 => Captura, 2 =>Aurizacion, 3 => Preparacion, 4 => Entrega, 5 => Confirmacion
        If chkFecha.Checked = True Then
            If rdoEntrega.Checked = True Then
                Resultado = 1
            ElseIf rdoConfirmacion.Checked = True Then
                Resultado = 2
            ElseIf rdoFacturacion.Checked = True Then
                Resultado = 3
            Else
                Resultado = 0
            End If
        Else
            Resultado = 0
        End If

        Return Resultado
    End Function

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged

        If chkFecha.Checked Then
            rdoEntrega.Enabled = True
            rdoConfirmacion.Enabled = True
            rdoFacturacion.Enabled = True
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
            lblEntregaAl.Enabled = True
            lblEntregaDel.Enabled = True
        Else
            rdoEntrega.Enabled = False
            rdoConfirmacion.Enabled = False
            rdoFacturacion.Enabled = False
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
            lblEntregaAl.Enabled = False
            lblEntregaDel.Enabled = False
        End If

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnAgregarFiltroTienda_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroTienda.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTienda.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTienda.DataSource = listado.listParametros
        With grdTienda
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = ListaPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            ListaPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = ListaPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub txtFolioOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioOT.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioOT.Text) Then Return

            ListaFolio.Add(txtFolioOT.Text)
            grdFolioOT.DataSource = Nothing
            grdFolioOT.DataSource = ListaFolio

            txtFolioOT.Text = String.Empty

        End If
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = ListaInicial
    End Sub

    Private Sub btnLimpiarFiltroTienda_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroTienda.Click
        grdTienda.DataSource = ListaInicial
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdFolioOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioOT.InitializeLayout
        grid_diseño(grdFolioOT)
        grdFolioOT.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio OT"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda / Embarque / CEDIS"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioOT.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "CONSULTA"

    Public Function ConsultarOTMostrar() As DataTable
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim dtResultadoOT As New DataTable

        Dim tipoFecha_Filtro As Integer = 0
        Dim fechaInicio_Filtro As String = ""
        Dim fechaFin_Filtro As String = ""
        Dim pedidoSAY_Filtro As String = ""
        Dim pedidoSICY_Filtro As String = ""
        Dim folioOT_Filtro As String = ""
        Dim cliente_Filtro As String = ""
        Dim tienda_Filtro As String = ""
        Dim statusOT_Filtro As Integer = cmboxStatus.SelectedValue
        Dim mostrarAndrea_Filtro As Integer = 0

        tipoFecha_Filtro = ObtenerFiltroFecha()

        fechaInicio_Filtro = If(chkFecha.Checked, dtpFechaInicio.Value.ToShortDateString, "")
        fechaFin_Filtro = If(chkFecha.Checked, dtpFechaFin.Value.ToShortDateString, "")

        pedidoSAY_Filtro = ObtenerFiltrosGrid(grdPedidoSAY)
        pedidoSICY_Filtro = ObtenerFiltrosGrid(grdPedidoSICY)
        pedidoSICY_Filtro = ObtenerFiltrosGrid(grdPedidoSICY)
        cliente_Filtro = ObtenerFiltrosGrid(grdCliente)
        folioOT_Filtro = ObtenerFiltrosGrid(grdFolioOT)
        tienda_Filtro = ObtenerFiltrosGrid(grdTienda)

        mostrarAndrea_Filtro = If(chkMostrarAndrea.Checked, 1, 0)


        dtResultadoOT = objBU.consultaAdministrador(tipoFecha_Filtro, fechaInicio_Filtro, fechaFin_Filtro, pedidoSAY_Filtro, pedidoSICY_Filtro, folioOT_Filtro, cliente_Filtro, tienda_Filtro, statusOT_Filtro, mostrarAndrea_Filtro, cmbCEDIS.SelectedValue)

        Return dtResultadoOT

    End Function

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dtResultado As New DataTable
        Cursor = Cursors.WaitCursor

        grdOts.DataSource = Nothing
        dtResultado = ConsultarOTMostrar()
        If dtResultado.Rows.Count > 0 Then
            grdOts.DataSource = dtResultado
            DiseñoGridOT()
            DiseñoCamposAgregados()
            btnArriba_Click(sender, e)
        Else
            show_message("Aviso", "No hay datos para mostrar")
        End If
        lblTotalSeleccionados.Text = 0
        Cursor = Cursors.Default
    End Sub

#End Region

#Region "DISEÑO GRIDS"

    Private Sub bgvOts_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvOts.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DiseñoCamposAgregados()
        Dim valorCelda As Integer = 0

        For index As Integer = 0 To bgvOts.DataRowCount
            If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Origen") = valorCelda Then
                bgvOts.SetRowCellValue(index, bgvOts.Columns.ColumnByFieldName("Origen"), "")
            End If
        Next
    End Sub

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

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub

    Private Sub DiseñoGridOT()
        bgvOts.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvOts.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next



        bgvOts.Columns.ColumnByFieldName("Bloqueado").Visible = False
        bgvOts.Columns.ColumnByFieldName("RFC_Id").Visible = False
        bgvOts.Columns.ColumnByFieldName("ST_Id").Visible = False
        bgvOts.Columns.ColumnByFieldName("Cl_Id").Visible = False
        bgvOts.Columns.ColumnByFieldName("FA").Visible = False
        bgvOts.Columns.ColumnByFieldName("Atn. Clientes").Visible = False
        bgvOts.Columns.ColumnByFieldName("F Confirmacion").Visible = False
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").Visible = False
        bgvOts.Columns.ColumnByFieldName("PagosRelacionados").Visible = False
        bgvOts.Columns.ColumnByFieldName("Agente").Visible = False


        If cmboxStatus.SelectedValue <> 125 Then
            bgvOts.Columns.ColumnByFieldName(" ").Visible = False
        Else
            bgvOts.Columns.ColumnByFieldName(" ").Visible = True
        End If

        bgvOts.Columns.ColumnByFieldName("Monto Máx.").Caption = "Máximo X Fact"
        bgvOts.Columns.ColumnByFieldName("Cantidad").Caption = "X Facturar"
        bgvOts.Columns.ColumnByFieldName("pedi_pedidoidorigen").Caption = "Pedido Origen"
        bgvOts.Columns.ColumnByFieldName("pedi_pedidoidorigen").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("OrdenCompra").Caption = "Orden Compra"
        bgvOts.Columns.ColumnByFieldName("OrdenCompra").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("CargoAdicional").Caption = "Cargo Adicional"
        bgvOts.Columns.ColumnByFieldName("CargoAdicional").OptionsColumn.AllowEdit = False

        bgvOts.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvOts.Columns.ColumnByFieldName("Cant Tiendas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvOts.Columns.ColumnByFieldName("%Fact").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvOts.Columns.ColumnByFieldName("%Rem").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvOts.Columns.ColumnByFieldName("F Entrega Cte").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        bgvOts.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvOts.Columns.ColumnByFieldName("Cant Tiendas").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvOts.Columns.ColumnByFieldName("%Fact").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvOts.Columns.ColumnByFieldName("%Rem").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvOts.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Agente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Orden Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Atn. Clientes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Restricción Fact").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Observaciones").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("RFC Pedido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvOts.Columns.ColumnByFieldName("PagosRelacionados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        bgvOts.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        bgvOts.Columns.ColumnByFieldName("Cant Tiendas").DisplayFormat.FormatString = "N0"
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").DisplayFormat.FormatString = "N2"
        bgvOts.Columns.ColumnByFieldName("%Fact").DisplayFormat.FormatString = "N0"
        bgvOts.Columns.ColumnByFieldName("%Rem").DisplayFormat.FormatString = "N0"

        bgvOts.Columns.ColumnByFieldName("ST").OptionsFilter.AllowFilter = False
        bgvOts.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        bgvOts.Columns.ColumnByFieldName(" ").Width = 30
        bgvOts.Columns.ColumnByFieldName("ST").Width = 25
        bgvOts.Columns.ColumnByFieldName("OT").Width = 60
        bgvOts.Columns.ColumnByFieldName("Agente").Width = 50
        bgvOts.Columns.ColumnByFieldName("Cliente").Width = 250
        bgvOts.Columns.ColumnByFieldName("Pedido SAY").Width = 80
        bgvOts.Columns.ColumnByFieldName("Pedido SICY").Width = 80
        bgvOts.Columns.ColumnByFieldName("Orden Cliente").Width = 100
        bgvOts.Columns.ColumnByFieldName("F Entrega Cte").Width = 80
        bgvOts.Columns.ColumnByFieldName("Cantidad").Width = 60
        bgvOts.Columns.ColumnByFieldName("Atn. Clientes").Width = 120
        bgvOts.Columns.ColumnByFieldName("%Fact").Width = 50
        bgvOts.Columns.ColumnByFieldName("%Rem").Width = 50
        bgvOts.Columns.ColumnByFieldName("Restricción Fact").Width = 150
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").Width = 90
        bgvOts.Columns.ColumnByFieldName("Observaciones").Width = 200
        bgvOts.Columns.ColumnByFieldName("Tienda").Width = 250
        bgvOts.Columns.ColumnByFieldName("Cant Tiendas").Width = 90
        bgvOts.Columns.ColumnByFieldName("RFC Pedido").Width = 100
        bgvOts.Columns.ColumnByFieldName("F Confirmacion").Width = 140
        bgvOts.Columns.ColumnByFieldName("PagosRelacionados").Width = 250

        bgvOts.Columns.ColumnByFieldName("ST").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("FA").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Agente").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Pedido SAY").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Pedido SICY").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Orden Cliente").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("F Entrega Cte").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Atn. Clientes").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("%Fact").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("%Rem").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Restricción Fact").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Monto Máx.").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Observaciones").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("Cant Tiendas").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("RFC Pedido").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("F Confirmacion").OptionsColumn.AllowEdit = False
        bgvOts.Columns.ColumnByFieldName("PagosRelacionados").OptionsColumn.AllowEdit = False

        bgvOts.Columns.ColumnByFieldName("F Entrega Cte").DisplayFormat.FormatString = "dd/MM/yyyy"
        bgvOts.Columns.ColumnByFieldName("F Confirmacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        bgvOts.IndicatorWidth = 40

        bgvOts.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(bgvOts.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            bgvOts.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cantidad"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvOts.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub bgvOts_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvOts.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorStatusOT(currentView.GetRowCellValue(e.RowHandle, "ST_Id"))
            End If

            If e.Column.FieldName = "FA" Then
                If e.CellValue = "SI" Then
                    e.Appearance.BackColor = pnlColorFA.BackColor
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub bgvOts_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvOts.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If IsDBNull(bgvOts.GetRowCellValue(e.RowHandle, "Bloqueado")) = False And bgvOts.GetRowCellValue(e.RowHandle, "Bloqueado") = "SI" Then
                e.Appearance.BackColor = pnlClienteBloqueado.BackColor
            End If
        End If
    End Sub

    Private Function ObtenerColorStatusOT(ByVal EstatusID As Integer) As Color
        Dim TipoColor As New Color

        '125:    POR FACTURAR
        '126:    FACTURADO()
        '127:    EN RUTA
        '128:    ENTREGADA()

        If EstatusID = "125" Then
            TipoColor = pnlStatusPorFacturar.BackColor
        ElseIf EstatusID = "126" Then
            TipoColor = pnlStatusFacturada.BackColor
        ElseIf EstatusID = "127" Then
            TipoColor = pnlStatusEnRuta.BackColor
        ElseIf EstatusID = "128" Then
            TipoColor = pnlStatusEntrega.BackColor
        ElseIf EstatusID = "168" Then
            TipoColor = pnlStatusPorRefacturar.BackColor
        End If

        Return TipoColor

    End Function

#End Region

#Region "ACCIÓN DOCUMENTAR"

    Private Sub btnDocumentar_Click(sender As Object, e As EventArgs) Handles btnDocumentar.Click
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim dtResultadoGuardarSesion As New DataTable
        Dim dtResultadoGuardarOTSesion As New DataTable
        Dim OtSeleccionadas As String = String.Empty
        oTSelecionadasACambiar = OtSeleccionadas

        OtSeleccionadas = obtenerOrdenestrabajoSeleccionadas()

        'bgvOts.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False

        If validarOTSeleccionadas(OtSeleccionadas) Then

            If TieneFacturaPendientesPorCancelar() = False Then

                If validarSonTodasFacturasAnticpiadasOTs() Then

                    If ValidarTieneParesRechazados(OtSeleccionadas) = False Then

                        If validarClientesSeleccionados() Then

                            If ValidarClienteContado(listClientesSeleccionados(0), OtSeleccionadas) Then

                                If validarOrdenesTrabajoSeleccionadasAndrea(1) Then

                                    If validarPedidosSeleccionadosCoppel() Then

                                        If OTCoppelSeleccionadas <> "" Then
                                            OtSeleccionadas = OTCoppelSeleccionadas
                                        End If

                                        If ClienteBloqueadoEntrega = "NO" Then

                                            dtResultadoGuardarSesion = objBU.guardarSesionUsuarioFacturando(UsuarioId, ColaboradorId, UsuarioNombre, 1, OtSeleccionadas)

                                            If dtResultadoGuardarSesion.Rows(0).Item("SesionId").ToString() <> "-1" Then
                                                ''''
                                                Dim ventana As New ConfiguracionFacturacion_Form
                                                'Es el llamado de la funcion Actualizadora
                                                If ValidaClienteECOMMERCE() > 0 Then
                                                    ventana.MdiParent = Me.MdiParent
                                                    ventana.SesionID = Integer.Parse(dtResultadoGuardarSesion.Rows(0).Item("SesionId").ToString())
                                                    ventana.ClienteID = listClientesSeleccionados(0)
                                                    ventana.OTrabajo = OtSeleccionadas.ToString()
                                                    ventana.OrdenesTrabajoSeleccionadas = OtSeleccionadas
                                                    ventana.ParidadDocumentoExtranjero = ParidadDocumentoExtranjero
                                                    ventana.facturacionAnticipada = facturacionAnticipada
                                                    Me.WindowState = FormWindowState.Minimized
                                                    ventana.Show()
                                                    Exit Sub
                                                Else
                                                    If todosClientesMenosEcommerce() = 0 Then
                                                        ventana.MdiParent = Me.MdiParent
                                                        ventana.SesionID = Integer.Parse(dtResultadoGuardarSesion.Rows(0).Item("SesionId").ToString())
                                                        ventana.ClienteID = listClientesSeleccionados(0)
                                                        ventana.OTrabajo = OtSeleccionadas.ToString()
                                                        ventana.OrdenesTrabajoSeleccionadas = OtSeleccionadas
                                                        ventana.ParidadDocumentoExtranjero = ParidadDocumentoExtranjero
                                                        ventana.facturacionAnticipada = facturacionAnticipada
                                                        Me.WindowState = FormWindowState.Minimized
                                                        ventana.Show()
                                                    Else
                                                        Dim MensajeAdvertencia As New AdvertenciaForm
                                                        MensajeAdvertencia.mensaje = "Las Ordenes de compra del Cliente E-COMMERCE deben ser iguales para poder documentarse."
                                                        MensajeAdvertencia.Show()
                                                    End If
                                                End If
                                                ''''
                                                'Dim ventana As New ConfiguracionFacturacion_Form

                                            Else
                                                show_message("Advertencia", "Las OT seleccionadas ya están siendo utilizadas en otra sesión de facturación.")
                                            End If
                                        Else
                                            show_message("Advertencia", "No se pueden generar documentos a clientes bloqueados.")
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    Else
                        show_message("Advertencia", "No se pueden generar documentos de OTs con pares rechazados sin cancelar.")
                    End If
                Else
                    show_message("Advertencia", "No se pueden generar documentos de OTs de FACTURACIÓN ANTICIPADA Y OTs de facturación NORMAL.")
                End If
            End If

        End If
    End Sub

#End Region

    Private Function validarDocumentoDinamicoFA() As Boolean
        Dim otsFA As Integer
        For Each row As String In listOTsSeleccionadasFA
            If bgvOts.GetRowCellValue(row, "FA") = "SI" Then
                otsFA += 1
            End If
        Next
        Return otsFA = 0
    End Function

    Private Function ValidaClienteECOMMERCE() As Integer
        Dim esClienteEcommerce As Integer = 0
        Dim validaOtSeleccionada As Integer = 0
        Dim continuaDocumenta As Integer = 0
        Dim primerOrdenCompra As String = String.Empty
        For i As Integer = 0 To bgvOts.RowCount

            If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(i), " ") Then
                If primerOrdenCompra = String.Empty Then
                    primerOrdenCompra = bgvOts.GetRowCellValue(i, "OrdenCompra")
                End If

                validaOtSeleccionada += 1

                If bgvOts.GetRowCellValue(i, "Cliente") = "E-COMMERCE" And bgvOts.GetRowCellValue(i, "OrdenCompra") = primerOrdenCompra Then
                    esClienteEcommerce += 1
                End If

                If primerOrdenCompra Is String.Empty Then
                    'Dim Advertencia As New AdvertenciaForm
                    'Advertencia.mensaje = "OT´s con ordenes de compra vacia, " & vbCrLf & " el proceso no se puede realizar. " & vbCrLf & "favor de capturar una Orden de compra primero."
                    'Advertencia.Show()
                    Return continuaDocumenta
                    Exit Function
                End If
            End If

        Next

        If validaOtSeleccionada = esClienteEcommerce Then
            continuaDocumenta = 1
        End If

        Return continuaDocumenta
    End Function

    Private Function todosClientesMenosEcommerce() As Integer
        Dim todosMenosEcommerce As Integer = 0

        For i As Integer = 0 To bgvOts.RowCount
            If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(i), " ") Then
                If bgvOts.GetRowCellValue(i, "Cliente") <> "E-COMMERCE" Then
                    todosMenosEcommerce = 0
                Else
                    todosMenosEcommerce += 1
                End If
            End If
        Next
        Return todosMenosEcommerce
    End Function


#Region "ACCIÓN DOCUMENTOS DINÁMICOS"

    Private Sub btnDocumentoDinamico_Click(sender As Object, e As EventArgs) Handles btnDocumentoDinamico.Click
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim dtResultadoGuardarSesion As New DataTable
        Dim dtResultadoGuardarOTSesion As New DataTable
        Dim OtSeleccionadas As String = String.Empty

        OtSeleccionadas = obtenerOrdenestrabajoSeleccionadas()

        If listClientesSeleccionados.Contains(763) = False And listClientesSeleccionados.Contains(1181) = False Then

            If validarDocumentoDinamicoFA() Then 'If validarSonTodasFacturasAnticpiadasOTs() Then

                If ValidarTieneParesRechazados(OtSeleccionadas) = False Then

                    If validarOTSeleccionadas(OtSeleccionadas) Then

                        If TieneFacturaPendientesPorCancelar() = False Then

                            If validarClientesSeleccionados() Then

                                If ValidarClienteContado(listClientesSeleccionados(0), OtSeleccionadas) Then

                                    If ClienteBloqueadoEntrega = "NO" Then

                                        dtResultadoGuardarSesion = objBU.guardarSesionUsuarioFacturando(UsuarioId, ColaboradorId, UsuarioNombre, 2, OtSeleccionadas)

                                        If dtResultadoGuardarSesion.Rows(0).Item("SesionId").ToString() <> "-1" Then

                                            Dim ventana As New GeneracionDocumentosManuales_Form
                                            ventana.MdiParent = Me.MdiParent
                                            ventana.SesionID = Integer.Parse(dtResultadoGuardarSesion.Rows(0).Item("SesionId").ToString())
                                            ventana.ClienteID = listClientesSeleccionados(0)
                                            ventana.ParidadDocumentoExtranjero = ParidadDocumentoExtranjero
                                            ventana.facturacionAnticipada = facturacionAnticipada
                                            ventana.OTrajajo = OtSeleccionadas
                                            Me.WindowState = FormWindowState.Minimized
                                            ventana.Show()
                                        Else
                                            show_message("Advertencia", "Las OT seleccionadas ya están siendo utilizadas en otra sesión de facturación.")
                                        End If
                                    Else
                                        show_message("Advertencia", "No se pueden generar documentos a clientes bloqueados.")
                                    End If
                                End If
                            End If
                        End If

                    End If

                Else
                    show_message("Advertencia", "No se pueden generar documentos de OTs con pares rechazados sin cancelar.")
                End If
            Else
                show_message("Advertencia", "No se pueden generar documentos de OTs de FACTURACIÓN ANTICIPADA dinámicas.")
            End If
        Else
            show_message("Advertencia", "No se pueden generar documentos dinámicos al cliente Coppel/Coppel Argentina")
        End If

    End Sub

#End Region

#Region "OTRAS ACCIONES"

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 184
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        chboxSeleccionarTodo.Checked = False
        cmboxStatus.SelectedIndex = 0
        chkFecha.Checked = False
        grdPedidoSAY.DataSource = Nothing
        grdPedidoSICY.DataSource = Nothing
        grdFolioOT.DataSource = Nothing
        grdCliente.DataSource = Nothing
        grdTienda.DataSource = Nothing
        grdOts.DataSource = Nothing

    End Sub

    Private Sub cmboxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxStatus.SelectedIndexChanged
        If cmboxStatus.SelectedValue.ToString() <> "125" Then
            chkFecha.Checked = True
            chkFecha.Enabled = False
            chboxSeleccionarTodo.Checked = False
            chboxSeleccionarTodo.Enabled = False
            chkMostrarAndrea.Checked = False
            chkMostrarAndrea.Enabled = False
        ElseIf cmboxStatus.SelectedValue.ToString() = "125" Then
            chkFecha.Enabled = True
            chkFecha.Checked = False
            chboxSeleccionarTodo.Enabled = True
            chkMostrarAndrea.Enabled = True
        End If
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim objBu As New Negocios.AdministradorOTFacturacionBU
        Dim OtSeleccionadas As String = String.Empty
        Dim resultadoRechazo As New DataTable
        Dim confirmacion As New ConfirmarForm

        OtSeleccionadas = obtenerOrdenestrabajoSeleccionadas()

        Try

            If validarOrdenesTrabajoSeleccionadasAndrea(2) Then
                If validarOTSeleccionadas(OtSeleccionadas) Then

                    If listClientesSeleccionados.Contains(816) Then

                        Dim VentanaRechazoAndrea As New RechazoAndrea_Form
                        VentanaRechazoAndrea.MdiParent = Me.MdiParent
                        VentanaRechazoAndrea.OrdenTrabajoId = OtSeleccionadas
                        VentanaRechazoAndrea.PedidoSAYId = PedidoSAYSeleccionado
                        VentanaRechazoAndrea.PedidoSICYId = PedidoSICYSeleccionado
                        VentanaRechazoAndrea.OrdenClienteSeleccion = OrdenClienteSeleccionada
                        VentanaRechazoAndrea.CantidadOTSeleccionadas = FilasSeleccionadas
                        VentanaRechazoAndrea.Show()
                        Me.WindowState = FormWindowState.Minimized

                    Else

                        confirmacion.mensaje = "¿Desea rechazar las " + FilasSeleccionadas.ToString() + " OT seleccionadas?"
                        If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                            resultadoRechazo = objBu.rechazarOT(OtSeleccionadas)
                            show_message(resultadoRechazo.Rows(0).Item("Resultado").ToString, resultadoRechazo.Rows(0).Item("ResultadoTexto").ToString)

                        End If

                    End If

                End If
            End If

        Catch ex As Exception

            show_message("Error", "Ocurrio un error al rechazar las " + FilasSeleccionadas.ToString() + " OT seleccionadas. Por favor intente de nuevo")

        End Try

        FilasSeleccionadas = 0

    End Sub

    Private Function obtenerOrdenestrabajoSeleccionadas() As String
        Dim ordenesSeleccionadas As String = String.Empty
        Dim NumeroFilas As Integer
        Dim valorCampoSeleccionado As String = String.Empty
        FilasSeleccionadas = 0
        listClientesSeleccionados = New List(Of Integer)
        listOTsSeleccionadasFA = New List(Of Integer)
        lstNumerosPedidosSeleccionadosSAY = New List(Of Integer)
        lstNumerosPedidosSeleccionadosSICY = New List(Of Integer)
        PedidoSAYSeleccionado = 0
        PedidoSICYSeleccionado = 0
        OrdenClienteSeleccionada = ""

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = bgvOts.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1

                    If listClientesSeleccionados.Contains(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Cl_Id")) = False Then
                        listClientesSeleccionados.Add(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Cl_Id"))
                    End If

                    If listOTsSeleccionadasFA.Contains(bgvOts.GetDataSourceRowIndex(index)) = False Then
                        listOTsSeleccionadasFA.Add(bgvOts.GetDataSourceRowIndex(index))
                    End If

                    ''Tomar el tipo de documento
                    'If listregistrosAdministradorDeOtsPorfacturar.Contains(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Tipo")) = False Then
                    '    listregistrosAdministradorDeOtsPorfacturar.Add(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Tipo"))
                    'End If

                    'For Each row In listregistrosAdministradorDeOtsPorfacturar
                    '    valorCampoSeleccionado = row
                    'Next

                    'If valorCampoSeleccionado = "F" Then
                    '    tipoDocumentoContrarioOIgual = 1
                    'Else
                    '    tipoDocumentoContrarioOIgual = 0
                    'End If

                    If lstNumerosPedidosSeleccionadosSAY.Contains(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SAY")) = False Then
                        lstNumerosPedidosSeleccionadosSAY.Add(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SAY"))
                        lstNumerosPedidosSeleccionadosSICY.Add(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SICY"))
                    End If

                    ClienteBloqueadoEntrega = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Bloqueado").ToString()

                    If ordenesSeleccionadas = String.Empty Then
                        ordenesSeleccionadas = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT").ToString()
                    Else
                        ordenesSeleccionadas = ordenesSeleccionadas & "," & bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT").ToString()
                    End If

                    PedidoSAYSeleccionado = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SAY")
                    PedidoSICYSeleccionado = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SICY")
                    OrdenClienteSeleccionada = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Orden Cliente")
                End If
            Next



        Catch

            show_message("Error", "Ocurrio un error al seleccionar las OT. Por favor intente de nuevo")

        End Try

        Cursor = Cursors.Default

        Return ordenesSeleccionadas

    End Function

    Private Function validarClientesSeleccionados() As Boolean

        Dim validacion As Boolean = False

        If listClientesSeleccionados.Count > 1 Then

            show_message("Advertencia", "Solo se pueden documentar OT de un cliente a la vez.")

            validacion = False

        Else

            validacion = True

        End If

        Return validacion

    End Function

    Private Function validarOTSeleccionadas(OtSeleccionadas) As Boolean

        Dim validacion As Boolean = False

        If OtSeleccionadas = "" Then

            show_message("Advertencia", "No hay OT seleccionadas.")

            validacion = False

        Else

            validacion = True

        End If

        Return validacion

    End Function

    Private Function validarPedidosSeleccionadosCoppel() As Boolean

        Dim validacion As Boolean = False
        Dim NumeroFilas As Integer = 0
        Dim OtsPedido As Integer = 0
        Dim OtsPedidoSeleccionadas As Integer = 0
        Dim PedidoSAY As Integer = 0
        Dim PedidoSICY As Integer = 0
        OTCoppelSeleccionadas = String.Empty
        Dim Confirmacion As New Tools.confirmarFormGrande

        If listClientesSeleccionados.Contains(763) Then

            If lstNumerosPedidosSeleccionadosSAY.Count > 1 Then

                show_message("Advertencia", "No es posible documentar " + lstNumerosPedidosSeleccionadosSAY.Count.ToString() + " pedidos diferentes del cliente Coppel al mismo tiempo, seleccione OT que pertenezcan a un solo pedido.")
                If chboxSeleccionarTodo.Checked = True Then
                    chboxSeleccionarTodo.Checked = False
                Else
                    chboxSeleccionarTodo.Checked = True
                    chboxSeleccionarTodo.Checked = False
                End If
                validacion = False

            Else

                For Each pedido As Integer In lstNumerosPedidosSeleccionadosSAY
                    PedidoSAY = pedido
                Next

                For Each pedido As Integer In lstNumerosPedidosSeleccionadosSICY
                    PedidoSICY = pedido
                Next

                NumeroFilas = bgvOts.DataRowCount
                For index As Integer = 0 To NumeroFilas Step 1

                    If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "Pedido SAY") = PedidoSAY Then
                        OtsPedido += 1
                        If OTCoppelSeleccionadas <> "" Then
                            OTCoppelSeleccionadas += ","
                        End If
                        OTCoppelSeleccionadas += bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT").ToString()
                        If CBool(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ")) = True Then
                            OtsPedidoSeleccionadas += 1
                        End If
                    End If

                Next

                If OtsPedidoSeleccionadas <> OtsPedido Then

                    Confirmacion.mensaje = "Para generar los documentos de las OT del cliente Coppel seleccionadas (Pedido SAY " + PedidoSAY.ToString() + " / SICY " + PedidoSICY.ToString() + ") es necesario documentar todo el pedido al mismo tiempo ¿Desea generar los documentos de las " + OtsPedido.ToString() + " OT del pedido?"
                    If Confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        validacion = True

                    Else

                        OTCoppelSeleccionadas = ""
                        validacion = False

                    End If

                Else

                    validacion = True

                End If


                'validacion = True

            End If

        Else

            validacion = True

        End If

        Return validacion

    End Function

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvOts.DataRowCount
            lblTotalSeleccionados.Text = "0"

            For index As Integer = 0 To NumeroFilas Step 1
                bgvOts.SetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
                If index > 0 Then
                    If chboxSeleccionarTodo.Checked = True Then
                        lblTotalSeleccionados.Text = (CInt(Replace(lblTotalSeleccionados.Text, ",", "")) + 1).ToString("n0")
                    Else
                        lblTotalSeleccionados.Text = If(CInt(Replace(lblTotalSeleccionados.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalSeleccionados.Text, ",", "")) - 1, 0).ToString("n0")
                    End If
                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub bgvOts_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles bgvOts.CellValueChanging
        If e.Column.FieldName = " " Then
            If CBool(e.Value) = True Then
                lblTotalSeleccionados.Text = (CInt(Replace(lblTotalSeleccionados.Text, ",", "")) + 1).ToString()
            Else
                lblTotalSeleccionados.Text = If(CInt(Replace(lblTotalSeleccionados.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalSeleccionados.Text, ",", "")) - 1, 0).ToString()
            End If
        End If
    End Sub

    Private Function validarOrdenesTrabajoSeleccionadasAndrea(ByVal tipoValidacion As Integer) As Boolean 'tipo 1 documentar, tipo 2 rechazar

        Dim validacion As Boolean = False

        If listClientesSeleccionados.Contains(816) Then

            If tipoValidacion = 1 Then

                show_message("Advertencia", "Solo se pueden generar documentos dinámicos al cliente Andrea.")

                validacion = False

            ElseIf tipoValidacion = 2 And listClientesSeleccionados.Count > 1 Then

                show_message("Advertencia", "Las OT de Andrea deben rechazarse por separado de las de otros clientes.")

                validacion = False

            Else

                validacion = True

            End If


        Else

            validacion = True

        End If

        Return validacion

    End Function

    Public Function ValidarClienteContado(ByVal ClienteId As Integer, ByVal OrdenesTrabajo As String)

        Dim validacion As Boolean = False
        Dim ObjBu As New Ventas.Negocios.AdministradorOTFacturacionBU
        Dim dtResultadoValidacion As New DataTable
        ParidadDocumentoExtranjero = "1"

        dtResultadoValidacion = ObjBu.ValidacionClientesContado(ClienteId, OrdenesTrabajo)

        If dtResultadoValidacion.Rows.Count = 0 Then
            validacion = True
        Else
            If dtResultadoValidacion.Rows(0).Item("resultadoValidacion").ToString = "Es Extranjero" Then
                Dim DocumentosExtranjeros As New DocumentosExtranjeros_Paridad_Form
                DocumentosExtranjeros.ObtenerInfomracionCliente(ClienteId)
                If DocumentosExtranjeros.entCliente.TipoIVA <> 2 Then
                    show_message("Advertencia", "El cliente debe de contar con tipo MÁS IVA. Contacte al área de Contabilidad.")
                    validacion = False
                Else
                    DocumentosExtranjeros.OrdenesTrabajo = OrdenesTrabajo
                    DocumentosExtranjeros.ShowDialog()
                    ParidadDocumentoExtranjero = DocumentosExtranjeros.paridad
                    If DocumentosExtranjeros.Avanzar Then
                        validacion = True
                    Else
                        validacion = False
                    End If
                End If
            Else
                show_message("Advertencia", dtResultadoValidacion.Rows(0).Item("resultadoValidacion"))
            End If
        End If

        Return validacion

    End Function


#End Region

#Region "EXPORTAR EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvOts.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                bgvOts.Columns.ColumnByFieldName(" ").Visible = False
                nombreReporte = "\OrdenesTrabajoPorFacturar_"
                'nombreReporteParaExportacion = "PEDIDOS RUTA"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvOts.GroupCount > 0 Then
                            bgvOts.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdOts.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        'objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, If(chkFecha.Checked, dtpFechaInicio.Value.ToShortDateString(), ""), If(chkFecha.Checked, dtpFechaFin.Value.ToShortDateString(), ""))

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If


        bgvOts.Columns.ColumnByFieldName(" ").Visible = True

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try

            If e.ColumnFieldName = "ST" And e.RowHandle > 0 Then
                e.Formatting.BackColor = ObtenerColorStatusOT(bgvOts.GetRowCellValue(e.RowHandle, "ST_Id"))
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

#End Region

    Private Function validarSonTodasFacturasAnticpiadasOTs() As Boolean
        Dim NumeroFilas = bgvOts.DataRowCount
        Dim otsFacturacionAnticipadas As Integer
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ")) = True Then
                If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "FA") = "SI" Then
                    otsFacturacionAnticipadas += 1
                End If
            End If
        Next

        If otsFacturacionAnticipadas > 0 Then
            If otsFacturacionAnticipadas = CInt(lblTotalSeleccionados.Text) Then
                facturacionAnticipada = True
                Return True
            Else
                facturacionAnticipada = False
                Return False
            End If
        Else
            facturacionAnticipada = False
            Return True
        End If

    End Function

    Private Function ValidarTieneParesRechazados(ByVal OTs As String) As Boolean
        Dim ObjBu As New Ventas.Negocios.AdministradorOTFacturacionBU
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False

        dtResultado = ObjBu.ParesRechazadosOTs(OTs)
        If dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0).Item(0) > 0 Then
                Resultado = True
            Else
                Resultado = False
            End If
        Else
            Resultado = False
        End If

        Return Resultado
    End Function


    Private Sub btnCancelarRefacturacion_Click(sender As Object, e As EventArgs) Handles btnCancelarRefacturacion.Click
        Dim OtSeleccionada = seleccionarPartidaCancelarRefacturacion()

        If OtSeleccionada = -1 Then

            show_message("Advertencia", "Solo se puede cancelar una refacturación a la vez")

        ElseIf OtSeleccionada = 0 Then

            show_message("Aviso", "No hay OT en status ""POR REFACTURAR"" seleccionadas.")

        ElseIf OtSeleccionada > 0 Then

            Dim ventanaCancelarRefacturacion As New CancelarRefacturacion_Form
            ventanaCancelarRefacturacion.OTCancelarRefacturación = OtSeleccionada
            ventanaCancelarRefacturacion.Show()

        End If

    End Sub

    Private Function seleccionarPartidaCancelarRefacturacion() As Integer

        Dim OtSeleccionada As Integer = 0
        Dim NumeroFilas As Integer = 0
        Dim NumeroOTSeleccionadas As Integer = 0

        NumeroFilas = bgvOts.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ")) = True And bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "ST_Id") = 168 Then

                OtSeleccionada = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT")
                NumeroOTSeleccionadas += 1

            End If
        Next

        If NumeroOTSeleccionadas > 1 Then
            OtSeleccionada = -1
        End If

        Return OtSeleccionada

    End Function

    ''' <summary>
    ''' Valida si la OT tiene facturas pendientes de cancelar
    ''' </summary>
    ''' <returns></returns>
    Private Function TieneFacturaPendientesPorCancelar() As Boolean
        Dim NumeroFilas As Integer
        Dim OTSeleccionada As Integer = 0
        Dim ObjBU As New Negocios.AdministradorOTFacturacionBU
        Dim Resultado As Boolean = True
        Dim HayFacturasPendientesPorCancelar As Boolean = False
        Dim OTsPendientesCancelarFactura As String = String.Empty


        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = bgvOts.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    OTSeleccionada = bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT").ToString()
                    Resultado = ObjBU.TieneFacturasPendientesCancelar(OTSeleccionada)
                    If Resultado = True Then
                        HayFacturasPendientesPorCancelar = True
                        If OTsPendientesCancelarFactura = String.Empty Then
                            OTsPendientesCancelarFactura = OTSeleccionada.ToString
                        Else
                            OTsPendientesCancelarFactura = OTsPendientesCancelarFactura & "," & OTSeleccionada.ToString
                        End If
                    End If
                End If
            Next

            If HayFacturasPendientesPorCancelar = True Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen facturas pendientes de cancelar de las OTs: " & OTSeleccionada.ToString)
            End If


            Return HayFacturasPendientesPorCancelar


        Catch

            show_message("Error", "Ocurrio un error al seleccionar las OT. Por favor intente de nuevo")
            Return True
        End Try

        Cursor = Cursors.Default



    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub grdOts_MouseClick(sender As Object, e As MouseEventArgs) Handles grdOts.MouseClick
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_OT_PorFacturar", "SAC_CAMBIAR_TIPO_DOCT") Then
            Dim AltaCita As New AltaCitaEntregaForm
            Dim TextoTieneCita As String = String.Empty
            Dim FilasSeleccionadas As Integer = 0

            Try
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Cursor = Cursors.WaitCursor
                    ' Add the selected rows to the list.
                    Dim I As Integer
                    Dim posicionPivot As Integer
                    Dim NumeroFilas As Integer
                    For I = 0 To bgvOts.RowCount - 1

                        If bgvOts.IsRowSelected(bgvOts.GetVisibleRowHandle(I)) = True Then
                            FilasSeleccionadas += 1
                            posicionPivot = I
                            DocumentoSeleccionadoParaVerOTs = (bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(I), "OT"))
                            If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(posicionPivot), "Tipo") = "R" Then
                                CMS_CambiarDoc.Show(MousePosition)
                                Cursor = Cursors.Default
                            End If
                        End If
                    Next

                End If
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub FToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FToolStripMenuItem.Click
        Dim documento As String = "F"
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim confirmar As New Tools.ConfirmarForm
        Dim numeroFIlas As Integer = bgvOts.DataRowCount
        tipoDocumentoContrarioOIgual = 1
        For index As Integer = 0 To numeroFIlas Step 1
            If bgvOts.GetRowCellValue(bgvOts.GetVisibleRowHandle(index), "OT") = DocumentoSeleccionadoParaVerOTs.ToString() Then
                confirmar.mensaje = "¿Está seguro de realizar el cambio? El proceso no se podra revertir"
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    bgvOts.SetRowCellValue(index, bgvOts.Columns.ColumnByFieldName("Tipo"), documento)
                    bgvOts.RefreshData()
                    objBU.cambiarTipoDocumento(tipoDocumentoContrarioOIgual, DocumentoSeleccionadoParaVerOTs)
                End If
            End If
        Next
    End Sub


    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

    End Sub

End Class