Imports DevExpress.XtraEditors.Repository
Imports Programacion.Vista
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports Tools
Public Class PedidosMuestrasDetallesForm
    Dim dtDetallePedidoMuestras As DataTable
    Dim Folio As Integer
    Dim emptyEditor As RepositoryItem
    Dim cerrar As Boolean

    Private _Guardar As Boolean
    Public Property Guardar() As Boolean
        Get
            Return _Guardar
        End Get
        Set(ByVal value As Boolean)
            _Guardar = value
        End Set
    End Property

    Private _Autorizar As Boolean
    Public Property Autorizar() As Boolean
        Get
            Return _Autorizar
        End Get
        Set(ByVal value As Boolean)
            _Autorizar = value
        End Set
    End Property


    'Private _Editar As Boolean
    'Public Property Editar() As String
    '    Get
    '        Return _Editar
    '    End Get
    '    Set(ByVal value As String)
    '        _Editar = value
    '    End Set
    'End Property


    Private _idAsunto As Integer
    Public Property idAsunto() As Integer
        Get
            Return _idAsunto
        End Get
        Set(ByVal value As Integer)
            _idAsunto = value
        End Set
    End Property

    Dim Asunto As String = String.Empty
#Region "Metodos"
    Private Sub ValidaSeleccion()
        Dim mensaje As New AdvertenciaForm
        mensaje.mensaje = "No se encontraron registros seleccionados. Favor de corroborar la seleccion"
        mensaje.ShowDialog()
    End Sub
    Private Sub AplicaAccion(ByVal Accion As Boolean)
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVpedidosMuestrasDetalles.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Sel") Then
                    ListaInt.Add(index)
                End If
            Next
            If ListaInt.Count > 0 Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each index As Integer In ListaInt
                        PedidosMuestrasNegocios.EditarEstatusPedidoMuestraDetalles(grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Folio"),
                                                                                   grdVpedidosMuestrasDetalles.GetRowCellValue(index, "ProductoEstiloId"),
                                                                                   grdVpedidosMuestrasDetalles.GetRowCellValue(index, "UnidadMedidaId"),
                                                                                   grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Talla"),
                                                                                   Accion)
                    Next
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    LlenarGridPedidosMuestrasdetalles()
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
            LlenarGridPedidosMuestrasdetalles()
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub CambiarTallas()
        Dim ventana As New Tools.AdvertenciaForm

        If txtNuevaTalla.Text.ToString.Length > 0 Then
            Dim NumeroFilas As Integer = grdVpedidosMuestrasDetalles.DataRowCount
            Dim PedidosMuestrasNegocios As New Negocios.PedidosMuestrasBU
            Dim corridas As New List(Of String)
            Dim filtro As String = ""
            Dim contador As Integer = 0

            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Sel") Then
                    If grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "ABIERTO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "CAPTURADO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "AUTORIZADO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "EN PRODUCCION" Then

                        Dim corrida As String = (grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Corrida"))
                        corrida = corrida.Replace("½", ".5")
                        corridas = corrida.Split("-").ToList

                        If CDbl(txtNuevaTalla.Text.ToString) < CDbl(corridas(0)) Or CDbl(txtNuevaTalla.Text.ToString) > CDbl(corridas(1)) Then
                            ventana.mensaje = "La nueva talla no está dentro de la corrida"
                            ventana.ShowDialog()
                            Return
                        End If

                        If filtro.Length > 0 Then
                            filtro += ","
                        End If

                        filtro += grdVpedidosMuestrasDetalles.GetRowCellValue(index, "PedidoMuestraDetalleID").ToString
                        contador += 1
                    Else
                        ventana.mensaje = "El cambio de talla solo se puede realizar a registros en estatus de ABIERTO, CAPTURADO, AUTORIZADO o EN PRODUCCION"
                        ventana.ShowDialog()
                        txtNuevaTalla.Select()
                        Return
                    End If
                End If
            Next

            If contador > 0 Then
                Try
                    Dim confirmar As New Tools.ConfirmarForm
                    confirmar.mensaje = "¿Desea cambiar la talla de las partidas seleccionadas?"
                    confirmar.ShowDialog()
                    If Not confirmar.DialogResult = DialogResult.OK Then
                        Return
                    End If
                    PedidosMuestrasNegocios.CambioDeTallaMuestras(filtro, CInt(txtNuevaTalla.Text.ToString))
                    Dim ventanaExito As New Tools.ExitoForm
                    ventanaExito.mensaje = "Se realizó el cambio de talla correctamente"
                    ventanaExito.ShowDialog()
                    txtNuevaTalla.Text = ""
                    Cursor = Cursors.WaitCursor
                    LlenarGridPedidosMuestrasdetalles()
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Dim ventanaError As New Tools.ErroresForm
                    ventanaError.mensaje = "Ocurrió un error " + ex.ToString
                    ventanaError.ShowDialog()
                End Try
            Else
                ventana.mensaje = "Debe seleccionar partidas antes de realizar el cambio"
                ventana.ShowDialog()
            End If
        Else
            ventana.mensaje = "Ingrese la nueva talla"
            ventana.ShowDialog()
            txtNuevaTalla.Select()
        End If
    End Sub

    Private Sub AplicarReglasFormatoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Disponible")
        gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Disponible")
        formatConditionRuleExpression.PredefinedName = "Light Text"
        formatConditionRuleExpression.Expression = "[Disponible] > 0"
        formatConditionRuleExpression.Appearance.BackColor = Color.FromArgb(90, 172, 36)
        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
    End Sub

    Private Sub DiseñoGridPedidosMuestrasDetalles(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.IndicatorWidth = 30
        Dim ci As New CultureInfo("en-us")


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        'If txtEstatus.Text <> "CAPTURADO" Or _Autorizar = False Then
        'Grid.Columns.ColumnByFieldName("Sel").Visible = False
        'End If
        'Grid.OptionsSelection.MultiSelect = True
        'Grid.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Grid.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
        Grid.Columns.ColumnByFieldName("UnidadMedidaId").Visible = False
        Grid.Columns.ColumnByFieldName("PedidoMuestraDetalleID").Visible = False

        'Grid.Columns.ColumnByFieldName("Talla").Visible = False


        Grid.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        Grid.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N0"

        Grid.Columns.ColumnByFieldName("ProductoEstiloId").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UnidadMedidaId").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Coleccion").Width = 80
        Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("PielColor").Width = 120
        Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEntregaCliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEnvío").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Disponible").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OrdenProduccion").OptionsColumn.AllowEdit = False


        Grid.Columns.ColumnByFieldName("FechaCaptura").Caption = "F Captura"
        Grid.Columns.ColumnByFieldName("FechaEntregaCliente").Caption = "F Entrega"
        Grid.Columns.ColumnByFieldName("FechaEnvío").Caption = "F Envío"
        Grid.Columns.ColumnByFieldName("Sel").Caption = " "
        'Grid.Columns.ColumnByFieldName("OrdenProduccion").Caption = "Orden Producción"


        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(Grid.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            Grid.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cantidad"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If

        If IsNothing(Grid.Columns("Disponible").Summary.FirstOrDefault(Function(x) x.FieldName = "Disponible")) = True Then
            Grid.Columns("Disponible").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Disponible", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Disponible"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If


        If IsNothing(Grid.Columns("Precio").Summary.FirstOrDefault(Function(x) x.FieldName = "Precio")) = True Then
            Grid.Columns("Precio").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Precio", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Precio"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item2)
        End If

        Grid.Columns.ColumnByFieldName("Folio").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ProductoEstiloId").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UnidadMedidaId").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Colección").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEntregaCliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEnvío").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False

        Grid.BestFitColumns()

        Grid.Columns("Marca").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Colección").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("PielColor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns("Estatus").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


    End Sub
    Public Sub LlenarGridPedidosMuestrasdetalles()

        Dim accion = 1
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        dtDetallePedidoMuestras = PedidosMuestrasNegocios.ListaPedidosMuestrasDetalles(CInt(txtFolio.Text), accion)
        grdPedidosMuestraDetalles.DataSource = dtDetallePedidoMuestras
        grdVpedidosMuestrasDetalles.OptionsSelection.MultiSelect = True
        If grdVpedidosMuestrasDetalles.RowCount > 0 Then
            DiseñoGridPedidosMuestrasDetalles(grdVpedidosMuestrasDetalles)
            AplicarReglasFormatoGrid(grdVpedidosMuestrasDetalles)
        End If
    End Sub
    Public Sub recibirDatos(ByVal entidadPedidoMuestra As Entidades.PedidosMuestras)
        CargarComboClientes(entidadPedidoMuestra.Cliente)
        CargarComboAgentes(entidadPedidoMuestra.Agente)
        CargarComboTempordas(entidadPedidoMuestra.Temporada)

        'txtCliente.Text = entidadPedidoMuestra.Cliente
        txtAgente.Text = entidadPedidoMuestra.Agente
        txtFechaCaptura.Text = entidadPedidoMuestra.FechaCreacion.ToString("dd/MM/yyyy")
        txtFechaDeEntrega.Text = entidadPedidoMuestra.fechaEntrega
        txtAsunto.Text = entidadPedidoMuestra.Asunto
        txtTemporada.Text = entidadPedidoMuestra.Temporada
        txtFolio.Text = entidadPedidoMuestra.Folio
        txtEstatus.Text = entidadPedidoMuestra.Estatus
        txtCapturadoPor.Text = entidadPedidoMuestra.NombreUsuarioCreo
        txtIdCliente.Text = entidadPedidoMuestra.idCliente
        txtIdAgente.Text = entidadPedidoMuestra.idAgente
        txtObservaciones.Text = entidadPedidoMuestra.Observaciones
        dtpFechaEntrega.Value = IIf(entidadPedidoMuestra.fechaEntrega = "", Date.Now, entidadPedidoMuestra.fechaEntrega)
        Asunto = entidadPedidoMuestra.Asunto

        If (entidadPedidoMuestra.UsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) And (entidadPedidoMuestra.Estatus = "ABIERTO" Or entidadPedidoMuestra.Estatus = "CAPTURADO") Then
            _Guardar = True
        End If
    End Sub

    Private Sub CargarComboClientes(Cliente As String)
        Dim objBU As New Negocios.PedidosMuestrasBU
        Dim dt As DataTable
        Try
            dt = objBU.CargarComboClientes()
            cmbCliente.DataSource = dt
            cmbCliente.DisplayMember = "Cliente"
            cmbCliente.ValueMember = "IdSAY"
            cmbCliente.Text = Cliente

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarComboAgentes(Agente As String)
        Dim objBU As New Negocios.PedidosMuestrasBU
        Dim dt As DataTable
        Try
            dt = objBU.CargarComboAgentes()
            cmbAgente.DataSource = dt
            cmbAgente.DisplayMember = "codr_nombre"
            cmbAgente.ValueMember = "cmfa_colaboradorid_agente"
            cmbAgente.Text = Agente

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub


    Private Sub CargarComboTempordas(Temporada As String)
        Dim objBU As New Negocios.PedidosMuestrasBU
        Dim dt As DataTable
        Try
            dt = objBU.CargarComboTempordas()
            cmbTemporada.DataSource = dt
            cmbTemporada.DisplayMember = "temp_nombre"
            cmbTemporada.ValueMember = "temp_temporadaid"
            cmbTemporada.Text = Temporada

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub


#End Region
#Region "Eventos"
    Private Sub PedidosMuestrasDetallesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        LlenarGridPedidosMuestrasdetalles()
        Dim dt As DataTable
        Dim objNeg As New Negocios.PedidosMuestrasBU
        dt = objNeg.VerListaAsuntos(1)
        cmbAsunto.DataSource = dt
        cmbAsunto.ValueMember = "asmu_asuntoid"
        cmbAsunto.DisplayMember = "asmu_descripcion"
        'cmbAsunto.SelectedIndex = 10 '_idAsunto - 1
        cmbAsunto.SelectedValue = idAsunto
        Me.ActiveControl = txtBuscarModelo
        If (txtEstatus.Text.ToUpper <> "CAPTURADO" And txtEstatus.Text.ToUpper <> "POR APARTAR") Or _Autorizar = False Then
            btnConfirmarApartadoDetalles.Visible = False
            lblConfirmarApartado.Visible = False
            btnRechazarDetalles.Visible = False
            lblRechazar.Visible = False
            lblModelo.Visible = False
            txtBuscarModelo.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnBuscarModelo.Visible = False
            chboxSeleccionarTodo.Visible = False
            cmbAsunto.Enabled = False
            txtObservaciones.ReadOnly = True
            dtpFechaEntrega.Enabled = False
            btnEnviarPorApartar.Visible = False
            lblEnviarPorApartar.Visible = False
        End If

        If _Guardar = True Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "GUARDAR_ENCABEZADO") Then
            lblEditar.Visible = True
            btnEditar.Visible = True
            grpbCambioTalla.Visible = True
            cmbCliente.Enabled = True
            cmbAgente.Enabled = True
            cmbTemporada.Enabled = True
            cmbAsunto.Enabled = True
            txtFechaDeEntrega.ReadOnly = False
            txtAsunto.ReadOnly = False
            dtpFechaEntrega.Enabled = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMINISTRADOR_PEDIDOS_DE_MUESTRAS", "NO_PERMISO_COPIAR_PEDIDO") Then
            btnCopiarPedido.Visible = False
            lblCopiarPedido.Visible = False
        End If

        If txtEstatus.Text.ToUpper = "POR APARTAR" Then
            btnEnviarPorApartar.Enabled = False
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        cerrar = True
        Me.Close()
    End Sub
    Private Sub btnBuscarModelo_Click(sender As Object, e As EventArgs)
        Try
            lblErrorMessage.Visible = False
            If txtBuscarModelo.Text.Length >= 3 Then
                Dim idAgente, idCliente, idPedido As Integer
                Dim modelo As String
                idAgente = txtIdAgente.Text
                idCliente = txtIdCliente.Text
                modelo = txtBuscarModelo.Text
                idPedido = CInt(txtFolio.Text.Trim)
                Dim ArticulosForm As New ArticulosForm
                ArticulosForm.recibirDatos(idAgente, idCliente, modelo, idPedido)
                ArticulosForm.ShowDialog()
                LlenarGridPedidosMuestrasdetalles()
            Else
                lblErrorMessage.Visible = True
            End If
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub
    Private Sub btnConfirmarApartadoDetalles_Click(sender As Object, e As EventArgs) Handles btnConfirmarApartadoDetalles.Click
        AplicaAccion(True)
    End Sub
    Private Sub btnRechazarDetalles_Click(sender As Object, e As EventArgs) Handles btnRechazarDetalles.Click
        AplicaAccion(False)
    End Sub
    Private Sub PedidosMuestrasDetallesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Not cerrar Then
        '    ' Cancelamos el cierre del formulario
        '    e.Cancel = True
        'End If
    End Sub
#End Region
#Region "Eventos Grid"
    Private Sub grdVpedidosMuestrasDetalles_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles grdVpedidosMuestrasDetalles.CustomRowCellEdit
        If e.Column.FieldName = "Sel" And grdVpedidosMuestrasDetalles.GetRowCellValue(e.RowHandle, "Estatus") <> "CAPTURADO" And grdVpedidosMuestrasDetalles.GetRowCellValue(e.RowHandle, "Estatus") <> "AUTORIZADO" Then
            emptyEditor = New RepositoryItem
            e.RepositoryItem = emptyEditor
        Else
            chboxSeleccionarTodo.Visible = True
        End If

        'If e.Column.FieldName = "Sel" And grdVpedidosMuestrasDetalles.GetRowCellValue(e.RowHandle, "Estatus") <> "AUTORIZADO" Then
        '    emptyEditor = New RepositoryItem
        '    e.RepositoryItem = emptyEditor
        'Else
        '    chboxSeleccionarTodo.Visible = True
        'End If



    End Sub
    Private Sub grdVpedidosMuestrasDetalles_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVpedidosMuestrasDetalles.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub
#End Region

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim objMensajeQ As New ConfirmarForm
            objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objNeg As New Negocios.PedidosMuestrasBU
                Dim Entidad As New Entidades.PedidosMuestras
                Entidad.Folio = CInt(txtFolio.Text)
                Entidad.idAsunto = cmbAsunto.SelectedValue
                Entidad.fechaEntrega = dtpFechaEntrega.Value
                Entidad.Observaciones = txtObservaciones.Text
                Entidad.idCliente = cmbCliente.SelectedValue
                Entidad.idAgente = cmbAgente.SelectedValue
                Entidad.idAsunto = cmbAsunto.SelectedValue
                Entidad.idTemporada = cmbTemporada.SelectedValue
                Entidad.fechaEntrega = dtpFechaEntrega.Value.ToShortDateString
                objNeg.EditarPedidoMuestras(Entidad)

                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()

            End If
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
        End Try
    End Sub


    Private Function CalcularMuestrasPorApartar() As Integer
        Dim nParesMuestras As Integer = 0
        For i As Integer = 0 To grdVpedidosMuestrasDetalles.RowCount - 1
            If grdVpedidosMuestrasDetalles.GetRowCellValue(i, "UDM").ToString = "PARES" Then
                nParesMuestras = nParesMuestras + 2
            Else
                nParesMuestras = nParesMuestras + 1
            End If
        Next
        Return nParesMuestras
    End Function


    Private Sub btnEnviarPorApartar_Click(sender As Object, e As EventArgs) Handles btnEnviarPorApartar.Click
        Dim objBU As New Negocios.PedidosMuestrasBU
        Dim PiezasDisponiblesPedido As Integer
        Dim PiezasDisponibles As Integer
        Dim Pedido As Integer
        Dim msg_Conf As New ConfirmarForm

        'PiezasDispniblesPedido = CInt(grdVpedidosMuestrasDetalles.Columns("Cantidad").SummaryText)
        PiezasDisponiblesPedido = CalcularMuestrasPorApartar()
        PiezasDisponibles = CInt(grdVpedidosMuestrasDetalles.Columns("Disponible").SummaryText)
        Pedido = CInt(txtFolio.Text)

        msg_Conf.mensaje = "Existen " + PiezasDisponibles.ToString + " piezas disponibles para apartar para el pedido #" + Pedido.ToString + " (Piezas del pedido: " + PiezasDisponiblesPedido.ToString + ")" + vbCrLf + "¿Desea ENVIAR A POR APARTAR?"
        If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                objBU.APartarPedidoMuestra(Pedido)
                show_message("Exito", "El registro se realizó con éxito.")
            Catch ex As Exception
                show_message("Error", ex.Message)
            End Try
        End If


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

    Private Sub grdVpedidosMuestrasDetalles_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVpedidosMuestrasDetalles.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCopiarPedido_Click(sender As Object, e As EventArgs) Handles btnCopiarPedido.Click
        Dim PedidoOrigenID As Integer
        Dim PedidoNuevoID As Integer
        Dim UsuarioCopia As Integer
        Dim objBU As New Negocios.PedidosMuestrasBU
        Dim dt As DataTable
        Dim msg_Conf As New Tools.ConfirmarForm
        msg_Conf.mensaje = "¿Desea copiar el pedido? "
        Try
            If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then

                PedidoOrigenID = txtFolio.Text
                UsuarioCopia = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                dt = objBU.CopiarPedidoMuestra(PedidoOrigenID, UsuarioCopia)

                PedidoNuevoID = CInt(dt.Rows(0).Item(0))

                show_message("Exito", "Se genero un nuevo pedido con el folio " + PedidoNuevoID.ToString + " en estatus ABIERTO")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Sub txtNuevaTalla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevaTalla.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
        'If Not Char.IsDigit(e.KeyChar) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub btnCambioDeTalla_Click(sender As Object, e As EventArgs) Handles btnCambioDeTalla.Click
        CambiarTallas()
    End Sub

    Private Sub txtNuevaTalla_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNuevaTalla.KeyDown
        If e.KeyCode = Keys.Enter Then
            CambiarTallas()
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVpedidosMuestrasDetalles.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "ABIERTO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "CAPTURADO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "AUTORIZADO" Or grdVpedidosMuestrasDetalles.GetRowCellValue(index, "Estatus") = "EN PRODUCCION" Then
                    grdVpedidosMuestrasDetalles.SetRowCellValue(grdVpedidosMuestrasDetalles.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
                End If
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportarExcelDet_Click(sender As Object, e As EventArgs) Handles btnExportarExcelDet.Click
        Dim sfd As New SaveFileDialog
        Dim DVListadoOTs As DataView = CType(grdVpedidosMuestrasDetalles.DataSource, DataView)
        Dim DTResultado As DataTable = DVListadoOTs.Table.Copy()
        UltraGrid1.DataSource = DTResultado

        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGrid1.DisplayLayout.Bands(0).Columns("PedidoMuestraDetalleID").Hidden = True
                UltraGrid1.DisplayLayout.Bands(0).Columns("ProductoEstiloId").Hidden = True
                UltraGrid1.DisplayLayout.Bands(0).Columns("UnidadMedidaId").Hidden = True
                UltraGrid1.DisplayLayout.Bands(0).Columns("PedidoMuestraDetalleID").Hidden = True
                UltraGridExcelExporter1.Export(UltraGrid1, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)

                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If


    End Sub
End Class