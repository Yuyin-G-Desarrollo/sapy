Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class AdministradorPedidosMuestrasForm
    Dim TipoPerfil As Integer = 0 ' 1 => Ventas, 2=> Operaciones
    Dim emptyEditor As RepositoryItem
    Dim mostrarTodos, Editar, Cancelar, Autorizar, EnviarPorAutorizar, ApartarPiezas As Boolean
    Dim fila_seleccionada As Integer = 0
    Dim Pedido_Seleccionado As Integer = 0
    Dim Cliente_Seleccionado As String
    Dim CancelarAutorizada As Boolean
    Dim FechaActual = Date.Now
    Dim clikComienza As Boolean = False

#Region "Metodos"
    Public Sub LlenarGridPedidosMuestras()
        Cursor = Cursors.WaitCursor
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim ListaPedidosMuestras As New List(Of Entidades.PedidosMuestras)
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim seguimiento As Integer = 0
        Dim cedisId As Integer = 0
        If clikComienza = False Then
            If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
                cedisId = 43
            Else
                cedisId = 82
            End If
        Else
            cedisId = cboxNaveCedis.SelectedValue
        End If
        seguimiento = If(rdoSeguimiento.Checked, 1, seguimiento)
        seguimiento = If(rdoFinalizado.Checked, 2, seguimiento)
        seguimiento = If(rdoPorApartar.Checked, 3, seguimiento)
        'ListaPedidosMuestras = PedidosMuestrasNegocios.ListaPedidosMuestras(usuario, mostrarTodos, seguimiento, dtpFechaInicio.Value, dtpFechaFin.Value)
        'grdPedidosMuestras.DataSource = Nothing
        'If grdVpedidosMuestras.RowCount > 0 Then
        grdPedidosMuestras.DataSource = Nothing
        grdVpedidosMuestras.Columns.Clear()
        grdPedidosMuestras.DataSource = PedidosMuestrasNegocios.ListaPedidosMuestras(usuario, mostrarTodos, seguimiento, dtpFechaInicio.Value, dtpFechaFin.Value, cedisId)
        If grdVpedidosMuestras.RowCount > 0 Then
            DiseñoGridPedidosMuestras(grdVpedidosMuestras)
            AplicarReglasFormatoGrid(grdVpedidosMuestras)
        End If
        clikComienza = False
        grdVpedidosMuestras.FocusedRowHandle = fila_seleccionada
        Cursor = Cursors.Default
    End Sub
    Public Sub EnviarDatosPedidosMuestraDetalle()
        Dim entidadPedidosMuestras As New Entidades.PedidosMuestras
        Dim PedidosMuestraDetalles As New PedidosMuestrasDetallesForm
        Try
            entidadPedidosMuestras.Folio = CInt(grdVpedidosMuestras.GetFocusedRowCellValue("Folio"))
            entidadPedidosMuestras.Cliente = grdVpedidosMuestras.GetFocusedRowCellValue("Cliente").ToString
            entidadPedidosMuestras.Agente = grdVpedidosMuestras.GetFocusedRowCellValue("Agente").ToString
            entidadPedidosMuestras.FechaCreacion = CDate(grdVpedidosMuestras.GetFocusedRowCellValue("FechaCreacion"))
            entidadPedidosMuestras.Asunto = grdVpedidosMuestras.GetFocusedRowCellValue("Asunto").ToString
            entidadPedidosMuestras.Temporada = grdVpedidosMuestras.GetFocusedRowCellValue("Temporada").ToString
            entidadPedidosMuestras.fechaEntrega = grdVpedidosMuestras.GetFocusedRowCellValue("fechaEntrega")
            entidadPedidosMuestras.Estatus = grdVpedidosMuestras.GetFocusedRowCellValue("Estatus").ToString
            entidadPedidosMuestras.NombreUsuarioCreo = grdVpedidosMuestras.GetFocusedRowCellValue("NombreUsuarioCreo").ToString
            entidadPedidosMuestras.idAgente = grdVpedidosMuestras.GetFocusedRowCellValue("idAgente")
            entidadPedidosMuestras.idCliente = grdVpedidosMuestras.GetFocusedRowCellValue("idCliente")
            entidadPedidosMuestras.Observaciones = grdVpedidosMuestras.GetFocusedRowCellValue("Observaciones")
            entidadPedidosMuestras.UsuarioCreo = grdVpedidosMuestras.GetFocusedRowCellValue("UsuarioCreo")


            PedidosMuestraDetalles.MdiParent = Me.MdiParent
            PedidosMuestraDetalles.idAsunto = grdVpedidosMuestras.GetFocusedRowCellValue("idAsunto")
            PedidosMuestraDetalles.recibirDatos(entidadPedidosMuestras)
            PedidosMuestraDetalles.Autorizar = Autorizar
            'PedidosMuestraDetalles.Guardar = Editar
            PedidosMuestraDetalles.Show()
            'LlenarGridPedidosMuestras()
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub
    Private Sub PermisosPerfil()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "CONSULTAR_TODO") Then
            mostrarTodos = 1
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "AUTORIZAR") Then
            Autorizar = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "CANCELAR") Then
            Cancelar = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "EDITAR") Then
            Editar = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "APARTAR_PIEZAS") Then
            ApartarPiezas = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "ENVIAR_A_POR_AUTORIZAR") Then
            EnviarPorAutorizar = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "CANCELAR_MUESTRA_AUTORIZADA") Then
            CancelarAutorizada = True
            Editar = True
        End If

        btnEditar.Visible = Editar
        lblEditar.Visible = Editar
        btnConfirmarApartado.Visible = Autorizar
        lblAutorizar.Visible = Autorizar
        btnRechazar.Visible = Cancelar Or CancelarAutorizada
        lblCancelar.Visible = Cancelar Or CancelarAutorizada
        chboxSeleccionarTodo.Visible = Autorizar
        btnPorApartar.Visible = ApartarPiezas
        btnEnviarPorAutorizar.Visible = EnviarPorAutorizar
        lblApartarPiezas.Visible = ApartarPiezas
        lblEnviarPorAutorizar.Visible = EnviarPorAutorizar
    End Sub

    Private Sub AplicarReglasFormatoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        If rdoSeguimiento.Checked Then
            gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Disponible")
            gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Disponible")
            formatConditionRuleExpression.PredefinedName = "Bold Text"
            formatConditionRuleExpression.Expression = "[Disponible] > 0"
            formatConditionRuleExpression.Appearance.BackColor = Color.FromArgb(90, 172, 36)
            gridFormatRule.Rule = formatConditionRuleExpression
            Grid.FormatRules.Add(gridFormatRule)
        End If

        If rdoPorApartar.Checked Then
            gridFormatRule.Column = Grid.Columns.ColumnByFieldName("DisponiblePedido")
            gridFormatRule.ApplyToRow = True
            formatConditionRuleExpression.PredefinedName = "Light Text"
            formatConditionRuleExpression.Expression = "[DisponiblePedido] > 0"
            formatConditionRuleExpression.Appearance.BackColor = Color.FromArgb(248, 203, 173)
            gridFormatRule.Rule = formatConditionRuleExpression
            Grid.FormatRules.Add(gridFormatRule)
        End If
    End Sub


    Private Sub DiseñoGridPedidosMuestras(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.BestFitMaxRowCount = -1
        ' Grid.OptionsView.ColumnAutoWidth = True

        'Grid.IndicatorWidth = 30


        'Grid.OptionsView.EnableAppearanceEvenRow = True
        'Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = False
        Grid.OptionsSelection.EnableAppearanceFocusedRow = False
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        'Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        'Grid.Appearance.EvenRow.BackColor = Color.White
        'Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        If Editar = False Then
            Grid.Columns.ColumnByFieldName("Sel").Visible = False
        End If

        Grid.Columns.ColumnByFieldName("UsuarioCreo").Visible = False
        Grid.Columns.ColumnByFieldName("NombreUsuarioCreo").Visible = False
        Grid.Columns.ColumnByFieldName("Asunto").Visible = False
        Grid.Columns.ColumnByFieldName("idCliente").Visible = False
        Grid.Columns.ColumnByFieldName("idAgente").Visible = False
        Grid.Columns.ColumnByFieldName("idAsunto").Visible = False
        Grid.Columns.ColumnByFieldName("idTemporada").Visible = False
        Grid.Columns.ColumnByFieldName("EstatusId").Visible = False
        Grid.Columns.ColumnByFieldName("Observaciones").Visible = True
        Grid.Columns.ColumnByFieldName("Autorizados").Visible = True


        Grid.Columns.ColumnByFieldName("EnProduccion").Visible = True

        Grid.Columns.ColumnByFieldName("Recibidos").Visible = True

        Grid.Columns.ColumnByFieldName("Enviados").Visible = True

        Grid.Columns.ColumnByFieldName("Confirmados").Visible = True

        If rdoSeguimiento.Checked Then
            Grid.Columns.ColumnByFieldName("DisponibleTotal").Visible = False
            Grid.Columns.ColumnByFieldName("DisponiblePedido").Visible = False
            Grid.Columns.ColumnByFieldName("Disponible").Visible = True
            ' Grid.Columns.ColumnByFieldName("OrdenProduccion").Visible = False
            ' Grid.Columns.ColumnByFieldName("FechaOrden").Visible = False
        End If

        If rdoFinalizado.Checked Then
            Grid.Columns.ColumnByFieldName("DisponibleTotal").Visible = False
            Grid.Columns.ColumnByFieldName("DisponiblePedido").Visible = False
            Grid.Columns.ColumnByFieldName("Disponible").Visible = False
            'Grid.Columns.ColumnByFieldName("OrdenProduccion").Visible = True
            'Grid.Columns.ColumnByFieldName("FechaOrden").Visible = True

        End If

        If rdoPorApartar.Checked Then
            Grid.Columns.ColumnByFieldName("DisponibleTotal").Visible = True

            Grid.Columns.ColumnByFieldName("DisponiblePedido").Visible = True

            Grid.Columns.ColumnByFieldName("Disponible").Visible = False
            Grid.Columns.ColumnByFieldName("FechaEntregaReal").Visible = False
            Grid.Columns.ColumnByFieldName("Autorizados").Visible = False
            Grid.Columns.ColumnByFieldName("EnProduccion").Visible = False
            Grid.Columns.ColumnByFieldName("Recibidos").Visible = False
            Grid.Columns.ColumnByFieldName("Enviados").Visible = False
            Grid.Columns.ColumnByFieldName("Confirmados").Visible = False
            'Grid.Columns.ColumnByFieldName("OrdenProduccion").Visible = False
            'Grid.Columns.ColumnByFieldName("FechaOrden").Visible = False
        End If

        Grid.Columns.ColumnByFieldName("Capturados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Autorizados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Apartados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("EnProduccion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Recibidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Enviados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Disponible").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        Grid.Columns.ColumnByFieldName("Disponible").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Capturados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Autorizados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Apartados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("EnProduccion").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Recibidos").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Enviados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"

        Grid.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EnProduccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Recibidos").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Enviados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Temporada").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Asunto").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Confirmados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Disponible").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("DisponibleTotal").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("DisponiblePedido").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OrdenProduccion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaOrden").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "F Captura"
        Grid.Columns.ColumnByFieldName("fechaEntrega").Caption = "F Entrega"
        Grid.Columns.ColumnByFieldName("EnProduccion").Caption = "En Producción "
        Grid.Columns.ColumnByFieldName("FechaEntregaReal").Caption = "F Envío"
        'Grid.Columns.ColumnByFieldName("FechaOrden").Caption = "F Orden"
        Grid.Columns.ColumnByFieldName("Folio").Caption = "Pedido"
        Grid.Columns.ColumnByFieldName("Recibidos").Caption = "ENAV"
        Grid.Columns.ColumnByFieldName("Capturados").Caption = "CAPT"
        Grid.Columns.ColumnByFieldName("Apartados").Caption = "APART"
        Grid.Columns.ColumnByFieldName("Cancelados").Caption = "CANC"
        Grid.Columns.ColumnByFieldName("Sel").Caption = " "
        Grid.Columns.ColumnByFieldName("Estatus").Caption = "Estatus"
        Grid.Columns.ColumnByFieldName("Observaciones").Caption = "Observaciones"
        Grid.Columns.ColumnByFieldName("Autorizados").Caption = "AUTO"
        Grid.Columns.ColumnByFieldName("Apartados").Caption = "APAR"
        Grid.Columns.ColumnByFieldName("EnProduccion").Caption = "ENPR"
        Grid.Columns.ColumnByFieldName("Confirmados").Caption = "CONF"
        Grid.Columns.ColumnByFieldName("Enviados").Caption = "ECTE"
        Grid.Columns.ColumnByFieldName("Disponible").Caption = "DISP"
        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(Grid.Columns("Disponible").Summary.FirstOrDefault(Function(x) x.FieldName = "Disponible")) = True Then
            Grid.Columns("Disponible").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Disponible", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Disponible"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If
        If IsNothing(Grid.Columns("DisponibleTotal").Summary.FirstOrDefault(Function(x) x.FieldName = "DisponibleTotal")) = True Then
            Grid.Columns("DisponibleTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DisponibleTotal", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DisponibleTotal"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If
        If IsNothing(Grid.Columns("DisponiblePedido").Summary.FirstOrDefault(Function(x) x.FieldName = "DisponiblePedido")) = True Then
            Grid.Columns("DisponiblePedido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DisponiblePedido", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DisponiblePedido"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If

        If IsNothing(Grid.Columns("Capturados").Summary.FirstOrDefault(Function(x) x.FieldName = "Capturados")) = True Then
            Grid.Columns("Capturados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Capturados", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Capturados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If

        If IsNothing(Grid.Columns("Autorizados").Summary.FirstOrDefault(Function(x) x.FieldName = "Autorizados")) = True Then
            Grid.Columns("Autorizados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Autorizados", "{0:N0}")

            Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item3.FieldName = "Autorizados"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item3.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item3)
        End If

        If IsNothing(Grid.Columns("Apartados").Summary.FirstOrDefault(Function(x) x.FieldName = "Apartados")) = True Then
            Grid.Columns("Apartados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Apartados", "{0:N0}")

            Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item4.FieldName = "Apartados"
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item4.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item4)
        End If

        If IsNothing(Grid.Columns("EnProduccion").Summary.FirstOrDefault(Function(x) x.FieldName = "EnProduccion")) = True Then
            Grid.Columns("EnProduccion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "EnProduccion", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "EnProduccion"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item2)

        End If

        If IsNothing(Grid.Columns("Recibidos").Summary.FirstOrDefault(Function(x) x.FieldName = "Recibidos")) = True Then
            Grid.Columns("Recibidos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Recibidos", "{0:N0}")

            Dim item5 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item5.FieldName = "Recibidos"
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item5.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item5)
        End If

        If IsNothing(Grid.Columns("Enviados").Summary.FirstOrDefault(Function(x) x.FieldName = "Enviados")) = True Then
            Grid.Columns("Enviados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Enviados", "{0:N0}")

            Dim item6 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item6.FieldName = "Enviados"
            item6.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item6.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item6)
        End If



        If IsNothing(Grid.Columns("Cancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "Cancelados")) = True Then
            Grid.Columns("Cancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:N0}")

            Dim item7 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item7.FieldName = "Cancelados"
            item7.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item7.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item7)
        End If

        Grid.Columns.ColumnByFieldName("Folio").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Agente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("fechaEntrega").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEntregaReal").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Observaciones").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Capturados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Autorizados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("EnProduccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Recibidos").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Enviados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Temporada").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Asunto").OptionsColumn.AllowEdit = False


        'Grid.BestFitColumns() - Javier Salazar

        Grid.Columns("Temporada").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Agente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Estatus").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Folio").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.Columns.ColumnByFieldName("Sel").Width = 5
        Grid.Columns.ColumnByFieldName("Observaciones").Width = 150
        Grid.Columns.ColumnByFieldName("Estatus").Width = 75
        Grid.Columns.ColumnByFieldName("Folio").Width = 50
        Grid.Columns.ColumnByFieldName("Cliente").Width = 175
        Grid.Columns.ColumnByFieldName("Agente").Width = 200
        Grid.Columns.ColumnByFieldName("FechaCreacion").Width = 75
        Grid.Columns.ColumnByFieldName("fechaEntrega").Width = 75
        Grid.Columns.ColumnByFieldName("FechaEntregaReal").Width = 75
        Grid.Columns.ColumnByFieldName("Apartados").Width = 35


        Grid.Columns.ColumnByFieldName("Capturados").Width = 40
        Grid.Columns.ColumnByFieldName("Autorizados").Width = 40
        Grid.Columns.ColumnByFieldName("EnProduccion").Width = 40
        Grid.Columns.ColumnByFieldName("Recibidos").Width = 40
        Grid.Columns.ColumnByFieldName("Enviados").Width = 40
        Grid.Columns.ColumnByFieldName("Confirmados").Width = 40
        Grid.Columns.ColumnByFieldName("Disponible").Width = 40
        ' Grid.Columns.ColumnByFieldName("OrdenProduccion").Width = 40
        'Grid.Columns.ColumnByFieldName("FechaOrden").Width = 40
        Grid.Columns.ColumnByFieldName("DisponibleTotal").Width = 40
        Grid.Columns.ColumnByFieldName("DisponiblePedido").Width = 40
        Grid.Columns.ColumnByFieldName("Cancelados").Width = 40

        'For Each col As Columns.GridColumn In Grid.Columns
        '    col.Width = col.GetBestWidth
        'Next

    End Sub
    Private Sub ValidaSeleccion()
        Dim mensaje As New AdvertenciaForm
        mensaje.mensaje = "No se encontraron registros seleccionados. Favor de corroborar la seleccion"
        mensaje.ShowDialog()
    End Sub

#End Region

#Region "Eventos"
    Private Sub AdministradorPedidosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PermisosPerfil()
        rdoSeguimiento.Checked = True
        Dim DiaSemana As Integer = FechaActual.DayOfWeek
        Dim FechaInicio As Date
        Dim FechaFin As Date
        If DiaSemana >= 1 Then
            FechaInicio = FechaActual.AddDays((1 - DiaSemana))
        Else
            FechaInicio = FechaActual.AddDays(1)
        End If
        FechaFin = FechaActual.AddDays(6 - DiaSemana)
        ' dtpFechaInicio.MinDate = CDate("01/07/2017")
        dtpFechaInicio.Value = FechaInicio
        dtpFechaFin.Value = FechaFin
        ' cargaNavesCedis()
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveCedis)
        LlenarGridPedidosMuestras()
    End Sub
    Private Sub rdoSeguimiento_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSeguimiento.CheckedChanged
        If rdoSeguimiento.Checked = True Then
            fila_seleccionada = 0
            ' LlenarGridPedidosMuestras()
            'pnlBuscarFin.Visible = False
            'pnlBuscarSeg.Visible = True
            lblFechaAl.Visible = False
            dtpFechaInicio.Visible = False
            lblFechaDel.Visible = False
            dtpFechaFin.Visible = False
            pnlEtiquetas.Visible = False

            btnEditar.Enabled = True
            btnConfirmarApartado.Enabled = True
            btnRechazar.Enabled = True

            btnEnviarPorAutorizar.Enabled = False
            btnPorApartar.Enabled = False

        End If
    End Sub

    Private Sub rdoFinalizado_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFinalizado.CheckedChanged
        If rdoFinalizado.Checked = True Then
            fila_seleccionada = 0
            'LlenarGridPedidosMuestras()
            'pnlBuscarFin.Visible = True
            lblFechaAl.Visible = True
            dtpFechaInicio.Visible = True
            lblFechaDel.Visible = True
            dtpFechaFin.Visible = True
            pnlEtiquetas.Visible = False

            btnEditar.Enabled = False
            btnConfirmarApartado.Enabled = False
            btnRechazar.Enabled = False
            btnEnviarPorAutorizar.Enabled = False
            btnPorApartar.Enabled = False

        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmarApartado_Click(sender As Object, e As EventArgs) Handles btnConfirmarApartado.Click
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim PedidosConsDisponile As String = ""
        Dim objMensajeQ As New ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVpedidosMuestras.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestras.GetRowCellValue(index, "Sel") Then

                    If CInt(grdVpedidosMuestras.GetRowCellValue(index, "Disponible")) > 0 Then
                        PedidosConsDisponile = PedidosConsDisponile + grdVpedidosMuestras.GetRowCellValue(index, "Folio").ToString + ", "
                    End If

                    ListaInt.Add(CInt(grdVpedidosMuestras.GetRowCellValue(index, "Folio")))
                End If
            Next

            If ListaInt.Count > 0 Then

                If ListaInt.Count > 1 Then
                    If PedidosConsDisponile.Length > 0 Then
                        PedidosConsDisponile = PedidosConsDisponile.Remove(PedidosConsDisponile.Length - 2)
                        show_message("Advertencia", "Existen pedidos con cantidad disponible por apartar dentro de la selección actual (" + PedidosConsDisponile + "). Seleccione por separada los pedido que requiera mandar a POR APARATAR")

                        objMensajeQ.mensaje = "¿Desea autorizar los pedidos seleccionados aún cuando hay piezas disponibles en inventario (Ya no podrá Enviar a Por Apartar)?"
                        If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                            For Each index As Integer In ListaInt
                                PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, True)
                            Next
                            show_message("Exito", "El registro se realizó con éxito.")
                        End If
                    Else
                        objMensajeQ.mensaje = "¿Desea autorizar los pedidos seleccionados?"
                        If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                            For Each index As Integer In ListaInt
                                PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, True)
                            Next
                            show_message("Exito", "El registro se realizó con éxito.")
                        End If
                    End If
                Else
                    If PedidosConsDisponile.Length > 0 Then
                        objMensajeQ.mensaje = "¿Desea verificar la disponibilidad de piezas del pedido en stock antes de AUTORIZAR?"
                        If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                            btnEditar_Click(sender, e)
                        Else
                            For Each index As Integer In ListaInt
                                PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, True)
                            Next
                            show_message("Exito", "El registro se realizó con éxito.")
                        End If
                    Else
                        objMensajeQ.mensaje = "¿Desea autorizar los pedidos seleccionados?"
                        If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                            For Each index As Integer In ListaInt
                                PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, True)
                            Next
                            show_message("Exito", "El registro se realizó con éxito.")
                        End If
                    End If
                End If
                LlenarGridPedidosMuestras()
            Else
                ValidaSeleccion()
            End If
            'LlenarGridPedidosMuestras()
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            LlenarGridPedidosMuestras()
            Cursor = Cursors.Default
        End Try
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
            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVpedidosMuestras.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestras.GetRowCellValue(index, "Sel") Then
                    ListaInt.Add(CInt(grdVpedidosMuestras.GetRowCellValue(index, "Folio")))
                End If
            Next
            If ListaInt.Count > 0 Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each index As Integer In ListaInt
                        PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, False)
                    Next
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    LlenarGridPedidosMuestras()
                Else
                End If
            Else
                ValidaSeleccion()
            End If
            'LlenarGridPedidosMuestras()
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            LlenarGridPedidosMuestras()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        fila_seleccionada = grdVpedidosMuestras.FocusedRowHandle
        EnviarDatosPedidosMuestraDetalle()
        LlenarGridPedidosMuestras()
    End Sub

    Private Sub btnBuscarFin_Click_1(sender As Object, e As EventArgs)
        If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
            mensaje.ShowDialog()
            Return
        End If

        LlenarGridPedidosMuestras()
    End Sub
    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVpedidosMuestras.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestras.GetRowCellValue(index, "Estatus") = "CAPTURADO" Then
                    grdVpedidosMuestras.SetRowCellValue(grdVpedidosMuestras.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Eventos Grid"
    Private Sub grdVpedidosMuestras_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles grdVpedidosMuestras.CustomRowCellEdit
        If rdoSeguimiento.Checked Then
            If Autorizar Or Cancelar Then
                If e.Column.FieldName = "Sel" And (grdVpedidosMuestras.GetRowCellValue(e.RowHandle, "Estatus") <> "CAPTURADO") And (grdVpedidosMuestras.GetRowCellValue(e.RowHandle, "Estatus") <> "POR AUTORIZAR") Then
                    emptyEditor = New RepositoryItem
                    e.RepositoryItem = emptyEditor
                End If
            End If
            If CancelarAutorizada Then
                If e.Column.FieldName = "Sel" And (grdVpedidosMuestras.GetRowCellValue(e.RowHandle, "Estatus") <> "AUTORIZADO") Then
                    emptyEditor = New RepositoryItem
                    e.RepositoryItem = emptyEditor
                End If
            End If

        End If
    End Sub
    Private Sub grdVpedidosMuestras_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVpedidosMuestras.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub
    Private Sub grdPedidosMuestras_DoubleClick(sender As Object, e As EventArgs) Handles grdPedidosMuestras.DoubleClick
        If rdoInventarioPiezasMuestras.Checked = False Then
            btnEditar_Click(sender, e)
        End If
    End Sub
#End Region
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If grdVpedidosMuestras.GroupCount > 0 Then
                        grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\Datos_PedidosMuestras_" + fecha_hora + ".xlsx")
                        'grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\Datos_PedidosMuestras_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente."
                    mensajeExito.ShowDialog()

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_PedidosMuestras_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim EstatusID As Integer = grdVpedidosMuestras.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0

        Try

            If EstatusID = 136 Then
                e.Formatting.BackColor = Color.Azure

            End If

            '    If e.ColumnFieldName = "ColorEstatus" Then
            '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

            '    End If

            '    If TipoPerfil = 2 Then

            '        If chkDetallada.Checked = False Then
            '            If e.ColumnFieldName = "TotalErrores" Then
            '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
            '                If TotalErrores > 0 Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Black
            '                End If
            '            End If
            '        End If



            '        If e.ColumnFieldName = "TotalIncidencias" Then
            '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

            '            If TotalIncidencias > 0 Then
            '                e.Formatting.Font.Color = Color.Red
            '            Else
            '                e.Formatting.Font.Color = Color.Black
            '            End If
            '        End If

            '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If

            '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If


            '    End If

        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
        End Try
        'e.Handled = True
    End Sub

    Private Sub rdoPorApartar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPorApartar.CheckedChanged
        If rdoPorApartar.Checked = True Then
            fila_seleccionada = 0
            'LlenarGridPedidosMuestras()
            'pnlBuscarFin.Visible = True
            lblFechaAl.Visible = False
            dtpFechaInicio.Visible = False
            lblFechaDel.Visible = False
            dtpFechaFin.Visible = False
            pnlEtiquetas.Visible = True

            btnEditar.Enabled = True
            btnConfirmarApartado.Enabled = False
            btnRechazar.Enabled = False

            btnEnviarPorAutorizar.Enabled = True
            btnPorApartar.Enabled = True
        End If
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        Dim idPedido As Integer = CInt(grdVpedidosMuestras.GetFocusedRowCellValue("Folio"))
        If idPedido > 0 Then
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim objPedidosBU As New Negocios.PedidosMuestrasBU
            Dim dtPedido As DataTable
            Dim dtPedidosMuestras As DataTable
            Dim fecha() As String
            Dim fechaE() As String
            EntidadReporte = OBJBU.LeerReporteporClave("PEDIDO_MUESTRAS")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            dtPedido = objPedidosBU.ReportePedidoMuestras(1, idPedido)
            fecha = Split(dtPedido.Rows(0).Item("Fecha_Creacion"), "/")
            fechaE = Split(dtPedido.Rows(0).Item("Fecha_Entrega_Cliente"), "/")
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
            reporte("Pedido") = dtPedido.Rows(0).Item("Folio").ToString
            reporte("Observaciones") = dtPedido.Rows(0).Item("Observaciones").ToString
            reporte("Dia") = fecha(0).ToString
            reporte("Mes") = fecha(1).ToString
            reporte("Año") = fecha(2).ToString
            reporte("diaE") = fechaE(0).ToString
            reporte("MesE") = fechaE(1).ToString
            reporte("AñoE") = fechaE(2).ToString
            reporte("Capturo") = dtPedido.Rows(0).Item("NombreUsuarioCreo").ToString
            reporte("Vendedor") = dtPedido.Rows(0).Item("Agente").ToString
            reporte("Cliente") = dtPedido.Rows(0).Item("Cliente").ToString
            'reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            'reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper

            dtPedidosMuestras = objPedidosBU.ReportePedidoMuestras(2, idPedido, Nothing, chkMostrarPrecio.CheckState)

            reporte.Dictionary.Clear()
            reporte.RegData(dtPedidosMuestras)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        End If
    End Sub

    Private Sub btnPorApartar_Click_1(sender As Object, e As EventArgs) Handles btnPorApartar.Click
        If Pedido_Seleccionado > 0 Then
            Dim AdminMuestrasForm As New AdministradorPedidosMuestrasForm_ApartarPiezas
            AdminMuestrasForm.Pedido = Pedido_Seleccionado
            AdminMuestrasForm.Cliente = Cliente_Seleccionado
            AdminMuestrasForm.ShowDialog()
            fila_seleccionada = 0
            Pedido_Seleccionado = 0
            Cliente_Seleccionado = ""
            LlenarGridPedidosMuestras()
        Else
            show_message("Advertencia", "Seleccione un pedido por apartar")
        End If
    End Sub

    Private Sub btnMotrar_Click(sender As Object, e As EventArgs) Handles btnMotrar.Click
        Dim mensaje As New AdvertenciaForm
        If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
            mensaje.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
            mensaje.ShowDialog()
            Return
        End If
        If cboxNaveCedis.Text = "" Then
            mensaje.mensaje = "Es necesario seleccionar un cedis para realizar la consulta."
            mensaje.ShowDialog()
            Return
        End If
        If rdoFinalizado.Checked = False And rdoSeguimiento.Checked = False And rdoPorApartar.Checked = False And rdoInventarioPiezasMuestras.Checked = False Then
            mensaje.mensaje = "Es necesario seleccionar un filtro de busqueda para realizar la consulta."
            mensaje.ShowDialog()
            Return
        End If
        If rdoInventarioPiezasMuestras.Checked = True And rdoSeguimiento.Checked = False And rdoFinalizado.Checked = False And rdoPorApartar.Checked = False Then
            exportarInventarioPiezas()
            Return
        End If
        clikComienza = True
        LlenarGridPedidosMuestras()
    End Sub
    Private Sub btnexportarpiezas_Click(sender As Object, e As EventArgs) Handles btnexportarpiezas.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        If rdoInventarioPiezasMuestras.Checked = True Then
            If grdVpedidosMuestras.DataRowCount > 0 Then
                Try
                    With fbdUbicacionArchivo

                        .Reset()
                        .Description = " Seleccione una carpeta "
                        .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        .ShowNewFolderButton = True

                        Dim ret As DialogResult = .ShowDialog
                        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                        If ret = Windows.Forms.DialogResult.OK Then
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\Inventario Piezas Muestras_" + fecha_hora + ".xlsx", exportOptions)

                            Dim mensajeExito As New ExitoForm
                            mensajeExito.mensaje = "Los datos se exportaron correctamente."
                            mensajeExito.ShowDialog()

                            .Dispose()

                            Process.Start(fbdUbicacionArchivo.SelectedPath + "\Inventario Piezas Muestras_" + fecha_hora + ".xlsx")
                        End If

                    End With
                Catch ex As Exception
                    Dim mensajeError As New ErroresForm
                    mensajeError.mensaje = ex.Message
                    mensajeError.ShowDialog()
                End Try
            Else
                show_message("Advertencia", "No hay datos para exportar.")
            End If
        Else
            show_message("Advertencia", "Debe consultar el inventario piezas.")
        End If
    End Sub
    Private Sub exportarInventarioPiezas()
        Dim objInventario As New Ventas.Negocios.PedidosMuestrasBU
        Dim dtInventario As New DataTable
        Cursor = Cursors.WaitCursor
        grdPedidosMuestras.DataSource = Nothing
        grdVpedidosMuestras.Columns.Clear()
        dtInventario = objInventario.obtenerInventarioPiezasMuestras
        If dtInventario.Rows.Count > 0 Then
            grdPedidosMuestras.DataSource = dtInventario
            diseñoGridInventarioPiezasMuestras(grdVpedidosMuestras)
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub btnEnviarPorAutorizar_Click_1(sender As Object, e As EventArgs) Handles btnEnviarPorAutorizar.Click
        If Pedido_Seleccionado > 0 Then
            'If CInt(grdVpedidosMuestras.GetRowCellValue(fila_seleccionada, "DisponiblePedido")) = 0 Then
            Dim msg_Conf As New Tools.confirmarFormGrande
            msg_Conf.mensaje = "A enviar este pedido a POR AUTORIZAR ya no podrá realizar más apartados." + vbCrLf + " ¿Desea Continuar?"
            If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objBU As New Negocios.PedidosMuestrasBU
                Try
                    Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    Dim dt As DataTable = objBU.VerificarParesCompletos(Pedido_Seleccionado, 1, usuario)
                    If dt.Rows(0).Item(0) <> "" Then
                        msg_Conf.mensaje = dt.Rows(0).Item(0) + vbLf + "¿ Desea enviar el pedido a POR AUTORIZAR ?"
                        If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                            objBU.VerificarParesCompletos(Pedido_Seleccionado, 2, usuario)
                        Else
                            Return
                        End If
                    End If
                    objBU.EnviarPedidoPorAutorizar(Pedido_Seleccionado)
                    show_message("Exito", "El registro se realizó con éxito.")
                    fila_seleccionada = 0
                    LlenarGridPedidosMuestras()
                Catch ex As Exception
                    show_message("Error", ex.Message)
                End Try
            End If
            'Else
            '    show_message("Advertencia", "El pedido aún cuenta con cantidad disponible por apartar")
            'End If
        Else
            show_message("Advertencia", "Debe seleccionar un pedido.")
        End If
    End Sub

    Private Sub rdoInventarioPiezasMuestras_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInventarioPiezasMuestras.CheckedChanged
        grdVpedidosMuestras.Columns.Clear()
        grdPedidosMuestras.DataSource = Nothing
        lblFechaDel.Visible = False
        lblFechaAl.Visible = False
        dtpFechaInicio.Visible = False
        dtpFechaFin.Visible = False
    End Sub

    Private Sub btnExportarExcelDet_Click(sender As Object, e As EventArgs) Handles btnExportarExcelDet.Click
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim cadena As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If grdVpedidosMuestras.DataRowCount > 0 Then
                NumeroFilas = grdVpedidosMuestras.DataRowCount
                For index As Integer = 0 To NumeroFilas - 1
                    ListaInt.Add(CInt(grdVpedidosMuestras.GetRowCellValue(index, "Folio")))
                Next

                For Each index As Integer In ListaInt
                    cadena += index.ToString + ","
                Next
                cadena = cadena.Remove(cadena.Length - 1, 1)
                Dim objPedidosBU As New Negocios.PedidosMuestrasBU
                Dim dtPedidosMuestras As DataTable
                dtPedidosMuestras = objPedidosBU.ReportePedidoMuestras(3, 0, cadena)
                grdPedidosMuestraDet.DataSource = dtPedidosMuestras
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim exportOptions = New XlsxExportOptionsEx()
                        grdVPedidosMuestraDet.ExportToXlsx(.SelectedPath + "\Datos_MuestrasDetalle_" + fecha_hora + ".xlsx", exportOptions)

                        Dim mensajeExito As New ExitoForm
                        mensajeExito.mensaje = "Los datos se exportaron correctamente."
                        mensajeExito.ShowDialog()
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_MuestrasDetalle_" + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "No se encontraron datos para exportar."
                mensaje.ShowDialog()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
        Finally
            LlenarGridPedidosMuestras()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdVpedidosMuestras_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVpedidosMuestras.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdVpedidosMuestras_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles grdVpedidosMuestras.CellValueChanging
        If e.RowHandle >= 0 Then
            If rdoPorApartar.Checked And e.Column.GetCaption = " " Then
                SeleccionarFolio(If(e.Value, False, True), e.RowHandle)
            End If
        End If
    End Sub
    Private Sub SeleccionarFolio(Valor As Boolean, Fila As Integer)
        grdVpedidosMuestras.SetRowCellValue(fila_seleccionada, "Sel", False)

        Valor = If(Valor, False, True)

        grdVpedidosMuestras.SetRowCellValue(Fila, "Sel", Valor)
        If Valor = True Then
            fila_seleccionada = Fila
            Pedido_Seleccionado = CInt(grdVpedidosMuestras.GetRowCellValue(Fila, "Folio"))
            Cliente_Seleccionado = grdVpedidosMuestras.GetRowCellValue(Fila, "Cliente").ToString
        Else
            Pedido_Seleccionado = 0
            Cliente_Seleccionado = ""
        End If
    End Sub

    'Private Sub grdVpedidosMuestras_RowClick(sender As Object, e As RowClickEventArgs) Handles grdVpedidosMuestras.RowClick
    '    Dim valor As Boolean = grdVpedidosMuestras.GetRowCellValue(e.RowHandle, "Sel")
    '    If rdoPorApartar.Checked Then
    '        SeleccionarFolio(valor, e.RowHandle)
    '    End If
    'End Sub
    Private Sub diseñoGridInventarioPiezasMuestras(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(grdVpedidosMuestras) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVpedidosMuestras.Columns
            If col.FieldName = "Pieza" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 65
            End If
            If col.FieldName = "Año" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Talla" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 30
            End If
            If col.FieldName = "Talla1" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 52
            End If
            If col.FieldName = "Nave Desarrolla" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 65
            End If
            If col.FieldName = "Orden Producción" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Marca SAY" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Modelo SAY" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Marca SICY" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Colección SAY" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Temporada" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Color" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Piel" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Estatus" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Horma" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Familia Proyección" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Unidad Medida" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Descripción" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Modelo SICY" Then
                col.OptionsColumn.AllowEdit = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVpedidosMuestras.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
    End Sub
End Class