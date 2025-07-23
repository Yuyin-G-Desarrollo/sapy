Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Entidades
Imports System.Globalization.Calendar


Public Class PedidoVirtualForm

    Public pedido As PedidoVirtual
    Public operacion As String
    Public departamento As Int32
    Public admin As AdministradorPedidosVirtualesForm

    Dim objDA As New Negocios.PedidosVirtualesBU
    Dim listatiposPedidos As New List(Of Entidades.PedidoVirtual)
    Dim pares As Integer
    Dim bandera As Boolean = False
    Dim banderaCliente As Boolean = False
    Dim banderaValidacionCliente As Boolean = False
    Dim banderaValidaFecha As Boolean = False
    Dim tipoPedido As Int32 = 0
    Dim tipoNombrePedido As String = ""
    Dim cliente As Entidades.Cliente
    Dim ListaPrecios As Entidades.ListaBase
    Dim banderaImportar As Boolean = False
    Dim fechaSolicitada As Date
    Dim paresRenglon As Int32


    Private Sub PedidoVirtualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarFormulario(False)
    End Sub

    Private Sub inicializarFormulario(ByVal bandera As Boolean)
        Dim listaclientes As New List(Of Entidades.Cliente)
        Dim estat As String = ""
        listaclientes = objDA.ListaClientes
        If listaclientes.Count > 0 Then
            cmbClientes.DataSource = listaclientes
            cmbClientes.ValueMember = "clienteid"
            cmbClientes.DisplayMember = "nombregenerico"
        End If
        validarPedido(listaclientes)
    End Sub

    Private Sub validarPedido(ByVal listaclientes As List(Of Entidades.Cliente))
        If operacion = "Alta" Then
            bandera = True
            cmbClientes.Enabled = bandera
            dtpFSolicitada.Enabled = bandera
            txtOrdenCliente.Enabled = bandera
            txtObservaciones.Enabled = bandera
            btnCerrar.Enabled = bandera
            btnGuardar.Enabled = bandera
            btnProductos.Enabled = bandera
            btnEliminar.Enabled = bandera
            btnImportar.Enabled = bandera
            grbTipoPedido.Enabled = bandera
            dtpFSolicitada.MinDate = Now.Date
            txtEstatusId.Text = 40
            txtEstatusNombre.Text = "CAPTURADO"
            dtpFProgramacion.Value = Now.Date
            dtpFSolicitada.Value = Now.Date
            fechaSolicitada = Now.Date
            banderaValidacionCliente = True
            tipoPedido = 3
            bandera = False
        Else
            btnExportar.Enabled = True
            btnBitacora.Enabled = True
            btnCerrar.Enabled = True
            txtPedido.Visible = True
            lblPedido.Visible = True
            Dim tablaEncabezado As DataTable, tablaProductos As DataTable
            tablaEncabezado = objDA.ObtenerEncabezado(pedido.id)

            If tablaEncabezado.Rows.Count = 1 Then
                tipoPedido = tablaEncabezado.Rows.Item(0).Item("pevi_pedidosvirtualestipoid")
                pares = tablaEncabezado.Rows.Item(0).Item("pevi_cantidadpares")
                txtEstatusId.Text = tablaEncabezado.Rows.Item(0).Item("pevi_estatusid")
                txtEstatusNombre.Text = tablaEncabezado.Rows.Item(0).Item("esta_nombre")
                pedido.listaVentas.PListaBaseNombre = tablaEncabezado.Rows.Item(0).Item("ListaPrecioCliente")
                pedido.listaVentas.PListaBaseId = tablaEncabezado.Rows.Item(0).Item("pevi_listaventasclienteprecioid")
                pedido.FechasolicitadaCliente = tablaEncabezado.Rows.Item(0).Item("FSolicita")
                pedido.orden = tablaEncabezado.Rows.Item(0).Item("pevi_ordenpedidocliente")
                pedido.observaciones = tablaEncabezado.Rows.Item(0).Item("pevi_observaciones")
                If Not IsDBNull(tablaEncabezado.Rows.Item(0).Item("pevi_fechaentregaprogramacion")) Then
                    pedido.fechaEntregaProg = tablaEncabezado.Rows.Item(0).Item("pevi_fechaentregaprogramacion")
                End If
                pedido.tipoid = tablaEncabezado.Rows.Item(0).Item("pevi_pedidosvirtualestipoid")
            End If

            lblContados.Text = pares.ToString("N0")
            txtPedido.Text = pedido.id

            If tipoPedido = 3 Then
                rbtPedNoConfirmado.Checked = True
                tipoNombrePedido = rbtPedNoConfirmado.Text
            ElseIf tipoPedido = 4 Then
                rbtBorradorCliente.Checked = True
                tipoNombrePedido = rbtBorradorCliente.Text
            ElseIf tipoPedido = 5 Then
                rbtProyeccion.Checked = True
                tipoNombrePedido = rbtProyeccion.Text
            End If

            For Each tipo As Entidades.Cliente In listaclientes
                If tipo.clienteid = pedido.cliente.clienteid Then
                    cmbClientes.SelectedItem = tipo
                    cliente = tipo
                    Exit For
                End If
            Next

            dtpFSolicitada.MinDate = pedido.FechasolicitadaCliente.Date
            dtpFSolicitada.Value = pedido.FechasolicitadaCliente.Date
            fechaSolicitada = pedido.FechasolicitadaCliente
            txtListaPrecio.Text = pedido.listaVentas.PListaBaseNombre
            txtIDListaPrecio.Text = pedido.listaVentas.PListaBaseId
            ListaPrecios = New ListaBase
            ListaPrecios.PListaBaseId = pedido.listaVentas.PListaBaseId
            ListaPrecios.PListaBaseNombre = pedido.listaVentas.PListaBaseNombre
            txtOrdenCliente.Text = pedido.orden
            txtObservaciones.Text = pedido.observaciones

            If pedido.fechaEntregaProg.Date.Year = 1 Then
                dtpFProgramacion.Value = Now.Date
            Else
                dtpFProgramacion.Value = pedido.fechaEntregaProg
            End If

            tablaProductos = objDA.ObtenerDetalleArticulos(pedido.id, pedido.tipoid, pedido.listaVentas.PListaBaseId, CInt(txtEstatusId.Text))

            If tablaProductos.Rows.Count > 0 Then
                Dim ColeccionAnterior As Int32 = 0, contador As Int32 = 0
                Dim EstatusAnterior As String = "", EstatusActual As String = ""

                If tipoPedido = 5 Then
                    For Each row As DataRow In tablaProductos.Rows
                        If CInt(row.Item("IdColeccionSAY").ToString) = ColeccionAnterior Then
                            EstatusActual = row.Item("Estatus")
                            row.Item("Estatus") = EstatusActual.ToString & ", " & EstatusAnterior.ToString
                            row.AcceptChanges()
                            tablaProductos.Rows.Item(contador - 1).Delete()
                        Else
                            ColeccionAnterior = CInt(row.Item("IdColeccionSAY"))
                            EstatusAnterior = row.Item("Estatus")
                        End If
                        contador += 1
                    Next
                End If

                grdProductos.DataSource = tablaProductos
                crearformatoGrid()
            Else
                grdProductos.DataSource = Nothing
            End If

            If operacion = "Editar" Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_PEDVIRTUALES", "PV_PPCP") Then
                    btnProductos.Enabled = False
                    btnEliminar.Enabled = False
                    dtpFProgramacion.Visible = True
                    txtSemanaProgramacion.Visible = True
                    lblFechaProg.Visible = True
                    btnImportar.Enabled = False
                    If CInt(txtEstatusId.Text) = 42 Then
                        dtpFSolicitada.Enabled = True
                        dtpFProgramacion.Enabled = True
                        btnGuardar.Enabled = True
                    End If

                    With grdProductos.DisplayLayout.Bands(0)
                        .Columns("Pares").CellActivation = Activation.NoEdit
                        .Columns("Seleccion").Hidden = True
                    End With
                End If
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_PEDVIRTUALES", "PV_VENTAS") Then
                    If CInt(txtEstatusId.Text) = 42 Then
                        dtpFProgramacion.Enabled = True
                        txtSemanaProgramacion.Enabled = True
                    ElseIf CInt(txtEstatusId.Text) = 40 Then
                        dtpFSolicitada.Enabled = True
                        txtOrdenCliente.Enabled = True
                        txtObservaciones.Enabled = True
                        btnImportar.Enabled = False
                        btnProductos.Enabled = True
                        btnEliminar.Enabled = True
                        With grdProductos.DisplayLayout.Bands(0)
                            .Columns("Pares").CellActivation = Activation.AllowEdit
                            .Columns("Seleccion").Hidden = False
                        End With
                    ElseIf CInt(txtEstatusId.Text) = 41 Then
                        cbxSeleccionar.Enabled = False
                        btnImportar.Enabled = False
                        btnProductos.Enabled = False
                        btnEliminar.Enabled = False
                        dtpFSolicitada.Enabled = True
                        txtOrdenCliente.Enabled = True
                        txtObservaciones.Enabled = True
                    End If
                    btnGuardar.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub cambiarRadio(radio As RadioButton)
        If grdProductos.Rows.Count > 1 Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cambiar el tipo de pedido? (Deberá capturar nuevamente los productos)"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdProductos.DataSource = Nothing
                tipoPedido = radio.Tag
                bandera = False
            Else
                If tipoPedido = 3 Then
                    rbtPedNoConfirmado.Checked = True
                    tipoNombrePedido = rbtPedNoConfirmado.Text
                ElseIf tipoPedido = 4 Then
                    rbtBorradorCliente.Checked = True
                    tipoNombrePedido = rbtBorradorCliente.Text
                ElseIf tipoPedido = 5 Then
                    rbtProyeccion.Checked = True
                    tipoNombrePedido = rbtProyeccion.Text
                End If
            End If
        Else
            tipoPedido = radio.Tag
        End If
    End Sub

    Private Sub CargarListaPrecios()
        If cmbClientes.SelectedIndex > 0 Then
            ListaPrecios = objDA.ListaPreciosCliente(CInt(cmbClientes.SelectedValue.ToString), dtpFSolicitada.Value)
            If ListaPrecios.PListaBaseId = 0 Then
                Dim confirmar As New AdvertenciaForm
                confirmar.mensaje = "No existe Lista de Precios para la fecha seleccionada"
                confirmar.ShowDialog()
                dtpFSolicitada.Value = fechaSolicitada
            Else
                txtIDListaPrecio.Text = ListaPrecios.PListaBaseId
                txtListaPrecio.Text = ListaPrecios.PListaBaseNombre '& ListaPrecios.PVigenciaInicio & " AL " & ListaPrecios.PVigenciaFin & ")"
            End If
        End If
    End Sub

    Private Function validarDatos() As Boolean
        If cmbClientes.SelectedValue = 0 Then
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar un cliente"
            confirmar.ShowDialog()
            validarDatos = False
            Exit Function
        End If

        If txtIDListaPrecio.Text = "" Then
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "El cliente debe tener una lista de precios asignada"
            confirmar.ShowDialog()
            validarDatos = False
            Exit Function
        End If

        If grdProductos.Rows.Count = 0 Then
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "El pedido debe tener minimo una partida"
            confirmar.ShowDialog()
            validarDatos = False
            Exit Function
        End If

        For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
            If row.Hidden = False Then
                If row.Cells("Pares").Value.ToString() = "" Or row.Cells("Pares").Value.ToString = "0" Then
                    Dim confirmar As New AdvertenciaForm
                    confirmar.mensaje = "La cantidad de pares debe ser mayor a 0"
                    confirmar.ShowDialog()
                    validarDatos = False
                    Exit Function
                End If
            End If
        Next

        validarDatos = True
    End Function

    Private Function CrearPartidas() As String
        Dim cadena As String = ""

        If tipoPedido = 3 Then
            For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                cadena = cadena & "#" & row.Cells("IdMarcaSAY").Value & "," & row.Cells("IdColeccionSAY").Value & "," & row.Cells("IdPielSAY").Value & ","
                cadena = cadena & row.Cells("IdColorSAY").Value & "," & row.Cells("IdTallaSAY").Value & "," & row.Cells("ProductoID").Value & ","
                cadena = cadena & row.Cells("ProductoEstiloID").Value & "," & row.Cells("Pares").Value & "," & row.Cells("Partida").Value & ","
            Next
        ElseIf tipoPedido = 4 Then
            For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                cadena = cadena & "#" & row.Cells("IdMarcaSAY").Value & "," & row.Cells("IdColeccionSAY").Value & ",0,0,0,"
                cadena = cadena & row.Cells("ProductoID").Value & ","
                cadena = cadena & "0," & row.Cells("Pares").Value & "," & row.Cells("Partida").Value & ","
            Next
        ElseIf tipoPedido = 5 Then
            For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                cadena = cadena & "#" & row.Cells("IdMarcaSAY").Value & "," & row.Cells("IdColeccionSAY").Value & ",0,0,0,"
                cadena = cadena & "0," & "0," & row.Cells("Pares").Value & "," & row.Cells("Partida").Value & ","
            Next
        End If
        cadena = cadena & "#"
        Return cadena
    End Function

    Private Sub guardarPedido()
        Dim PedidosDetalles As String
        Dim mensaje As String
        If validarDatos() = True Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de guardar el pedido virtual?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                PedidosDetalles = CrearPartidas()
                mensaje = objDA.InsertarPedidoVirtual(tipoPedido, CInt(txtEstatusId.Text), txtOrdenCliente.Text, cliente.clienteid, ListaPrecios.PListaBaseId, pares, txtObservaciones.Text, dtpFSolicitada.Value, SesionUsuario.UsuarioSesion.PUserUsuarioid, PedidosDetalles)
                Dim exito As New ExitoForm
                exito.mensaje = mensaje
                exito.ShowDialog()
                Me.Close()
                admin.Enabled = True
                admin.Consultafiltros()
                admin.WindowState = FormWindowState.Maximized
            End If
        End If
    End Sub

    Private Sub editarPedido()
        Dim PedidosDetalles As String
        Dim mensaje As String
        Dim confirmar As New ConfirmarForm

        If validarDatos() = True Then
            confirmar.mensaje = "¿Está seguro de guardar el pedido virtual?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                PedidosDetalles = CrearPartidas()
                If dtpFProgramacion.Visible = False Then
                    dtpFProgramacion.MinDate = CDate("01/01/1990").Date
                    dtpFProgramacion.Value = CDate("01/01/1990").Date
                    mensaje = objDA.EditarPedidoVirtual(txtOrdenCliente.Text, CInt(txtPedido.Text), CInt(txtIDListaPrecio.Text), pares, txtObservaciones.Text, dtpFSolicitada.Value, SesionUsuario.UsuarioSesion.PUserUsuarioid, dtpFProgramacion.Value, PedidosDetalles)
                Else
                    mensaje = objDA.EditarPedidoVirtual(txtOrdenCliente.Text, CInt(txtPedido.Text), CInt(txtIDListaPrecio.Text), pares, txtObservaciones.Text, dtpFSolicitada.Value, SesionUsuario.UsuarioSesion.PUserUsuarioid, dtpFProgramacion.Value, PedidosDetalles)
                End If

                Dim exito As New ExitoForm
                exito.mensaje = mensaje
                exito.ShowDialog()
                admin.Consultafiltros()
                'Me.Close()
                'admin.Enabled = True
                'admin.WindowState = FormWindowState.Maximized
            End If
        End If
    End Sub

    Private Sub abrirCatalogo()
        Dim confirmar As New AdvertenciaForm
        If cmbClientes.SelectedValue = 0 Then
            confirmar.mensaje = "Debe seleccionar un cliente"
            confirmar.ShowDialog(Me)
            lblCliente.ForeColor = Color.Red
            lblFechaSol.ForeColor = Color.Red
            lblListaPrecios.ForeColor = Color.Red
        ElseIf txtIDListaPrecio.Text.Trim = "0" Then
            confirmar.mensaje = "No existe una Lista de Precios vigente en la fecha solicitada."
            confirmar.ShowDialog(Me)
            lblCliente.ForeColor = Color.Red
            lblFechaSol.ForeColor = Color.Red
            lblListaPrecios.ForeColor = Color.Red
        Else
            Dim ProductosPedidoVirtual As New ConsultaProductosPedidosVirtualesForm

            If rbtPedNoConfirmado.Checked = True Then
                ProductosPedidoVirtual.tipoPedido = rbtPedNoConfirmado.Text
                ProductosPedidoVirtual.idtipoPedido = rbtPedNoConfirmado.Tag
            ElseIf rbtBorradorCliente.Checked = True Then
                ProductosPedidoVirtual.tipoPedido = rbtBorradorCliente.Text
                ProductosPedidoVirtual.idtipoPedido = rbtBorradorCliente.Tag
            ElseIf rbtProyeccion.Checked = True Then
                ProductosPedidoVirtual.tipoPedido = rbtProyeccion.Text
                ProductosPedidoVirtual.idtipoPedido = rbtProyeccion.Tag
            End If

            ProductosPedidoVirtual.cliente = cmbClientes.SelectedItem
            ProductosPedidoVirtual.ListaPrecios = ListaPrecios
            ProductosPedidoVirtual.estatus = txtEstatusId.Text.ToString
            ProductosPedidoVirtual.departamento = departamento
            ProductosPedidoVirtual.tablaProductos = grdProductos.DataSource
            ProductosPedidoVirtual.MdiParent = Me.MdiParent
            Me.Enabled = False
            ProductosPedidoVirtual.EncabezadoPedido = Me
            ProductosPedidoVirtual.Show()
            grdProductos.DataSource = ProductosPedidoVirtual.tablaProductos
        End If
    End Sub

    Public Sub crearformatoGrid()
        Dim ocultar As Boolean = True
        grdProductos.DisplayLayout.Bands(0).Columns("Seleccion").Style = ColumnStyle.CheckBox
        grdProductos.DisplayLayout.Bands(0).Columns("Seleccion").DefaultCellValue = False
        grdProductos.DisplayLayout.Bands(0).Columns("Seleccion").Header.Caption = ""

        grdProductos.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "* Pares"

        If operacion = "Editar" And CInt(txtEstatusId.Text) = 40 Then
            grdProductos.DisplayLayout.Bands(0).Columns("Agente").Hidden = ocultar
            grdProductos.DisplayLayout.Bands(0).Columns("IDdetalle").Hidden = ocultar
        ElseIf operacion = "Editar" And CInt(txtEstatusId.Text) > 40 Then
            grdProductos.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = ocultar
            grdProductos.DisplayLayout.Bands(0).Columns("IDdetalle").Hidden = ocultar
            grdProductos.DisplayLayout.Bands(0).Columns("Pares").CellActivation = Activation.NoEdit
            grdProductos.DisplayLayout.Bands(0).Columns("Agente").Hidden = True
        ElseIf operacion = "Ver" Then
            grdProductos.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = ocultar
            grdProductos.DisplayLayout.Bands(0).Columns("IDdetalle").Hidden = ocultar
            grdProductos.DisplayLayout.Bands(0).Columns("Pares").CellActivation = Activation.NoEdit
            grdProductos.DisplayLayout.Bands(0).Columns("Agente").Hidden = ocultar
        End If

        grdProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        
        With grdProductos.DisplayLayout.Bands(0)
            .Columns("Partida").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Temporada").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Estatus").Header.Caption = "Status"
            .Columns("Partida").CellActivation = Activation.NoEdit
            .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("IdMarcaSAY").Hidden = ocultar
            .Columns("IdColeccionSAY").Hidden = ocultar
            .Columns("Partida").Hidden = ocultar

            If tipoPedido = 4 Then
                .Columns("ProductoID").Hidden = ocultar
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
            ElseIf tipoPedido = 3 Then
                .Columns("Piel").Width = 150
                .Columns("IdPielSAY").Hidden = ocultar
                .Columns("IdColorSAY").Hidden = ocultar
                .Columns("IdTallaSAY").Hidden = ocultar
                .Columns("ProductoID").Hidden = ocultar
                .Columns("ProductoEstiloID").Hidden = ocultar
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Piel").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
            End If
            .Columns("Seleccion").Width = 30
            .Columns("Marca").Width = 80
            .Columns("Coleccion").Width = 100
            .Columns("Temporada").Width = 200
            .Columns("Estatus").Width = 200
            .Columns("Pares").Format = "##,##0"
        End With
        grdProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        bandera = True

    End Sub

    Private Sub SeleccionarRegistros()
        Dim contadorSeleccion As Int32 = 0
        Dim bandera As Boolean

        bandera = cbxSeleccionar.Checked

        For Each rowGR As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
            rowGR.Cells("Seleccion").Value = bandera
            contadorSeleccion += 1
        Next

        If bandera = False Then
            contadorSeleccion = 0
        End If

        lblRegistro.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub seleccionarRegistroTabla(e As CellEventArgs)
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdProductos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = False Then
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If

            If CBool(e.Cell.Text) = True Then
                lblRegistro.Text = CInt(lblRegistro.Text) + 1
            Else
                lblRegistro.Text = CInt(lblRegistro.Text) - 1
            End If
        End If
    End Sub

    Private Sub contarPares(e As BeforeCellUpdateEventArgs)
        If e.Cell.Column.Key = "Pares" Then
            Dim valorAntes As Int32 = 0
            Dim valorDespues As Int32 = 0

            If IsDBNull(e.Cell.Value) Then
                valorAntes = 0
            Else
                valorAntes = CInt(e.Cell.Value)
            End If

            If e.Cell.Text = "" Then
                valorDespues = 0
            Else
                valorDespues = CInt(e.Cell.Text)
            End If

            If valorDespues > 0 And valorAntes > 0 Then
                pares = pares - valorAntes
                pares = pares + valorDespues
            ElseIf valorDespues > 0 And valorAntes = 0 Then
                pares = pares + valorDespues
            ElseIf valorAntes > 0 And valorDespues = 0 Then
                pares = pares - valorAntes
            End If
            paresRenglon = valorDespues
            lblContados.Text = pares.ToString("N0")
        End If
    End Sub

    Private Sub cambiarListaPrecios()
        Dim lPrecio As New Entidades.ListaBase
        Dim bandera As Boolean = False
        Dim articulos As New DataTable
        'Sacar la lista de precios, si la lista es diferente a la actual
        lPrecio = objDA.ListaPreciosCliente(CInt(cmbClientes.SelectedValue.ToString), dtpFSolicitada.Value)
        If lPrecio.PListaBaseId <> ListaPrecios.PListaBaseId Then
            If operacion = "Alta" Then
                'If operacion = "Alta" And banderaValidaFecha = False Then
                'preguntar si realmente se cambia la fecha pues se cambiara la lista y cambiaran los articulos
                Dim confirmar As New ConfirmarForm
                confirmar.mensaje = "Esta seguro de cambiar la fecha solicitada por el cliente? (Al cambiar la fecha cambiara la lista y algunos productos capturados podrian no estar dentro de la nueva lista de precios)"
                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'sacar los productos de la nueva lista
                    articulos = objDA.ObtenerArticulos(lPrecio.PListaBaseId, 0, 0, 0, 0, 1, tipoPedido)
                    'recorrer el grid y compara el articulo 
                    'si el articulo esiste en la nueva lista de precios se deja
                    'si el articulo no existe en la nueva lista quitarlo del grid
                    For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                        'bandera para validar si encuentra el articulo
                        bandera = False
                        If tipoPedido = 3 Then
                            For Each renglon As DataRow In articulos.Rows
                                If row.Cells("IdMarcaSAY").Value = renglon.Item("IdMarcaSAY") And row.Cells("IdColeccionSAY").Value = renglon.Item("IdColeccionSAY") And row.Cells("EstiloProductoId").Value = renglon.Item("EstiloProductoId") And row.Cells("ProductoID").Value = renglon.Item("ProductoID") Then
                                    bandera = True
                                    Exit For
                                Else
                                    bandera = False
                                End If
                            Next
                        ElseIf tipoPedido = 4 Then
                            For Each renglon As DataRow In articulos.Rows
                                If row.Cells("IdMarcaSAY").Value = renglon.Item("IdMarcaSAY") And row.Cells("IdColeccionSAY").Value = renglon.Item("IdColeccionSAY") And row.Cells("ProductoID").Value = renglon.Item("ProductoID") Then
                                    bandera = True
                                    Exit For
                                Else
                                    bandera = False
                                End If
                            Next
                        ElseIf tipoPedido = 5 Then
                            For Each renglon As DataRow In articulos.Rows
                                If row.Cells("IdMarcaSAY").Value = renglon.Item("IdMarcaSAY") And row.Cells("IdColeccionSAY").Value = renglon.Item("IdColeccionSAY") Then
                                    bandera = True
                                    Exit For
                                Else
                                    bandera = False
                                End If
                            Next
                        End If
                        
                        If bandera = False Then
                            pares = pares - CInt(row.Cells("Pares").Value)
                            lblContados.Text = pares
                            row.Delete()
                        End If
                    Next
                Else
                    dtpFSolicitada.Value = fechaSolicitada
                    Exit Sub
                End If
            ElseIf operacion = "Editar" Then
                'sacar los productos de la nueva lista
                articulos = objDA.ObtenerArticulos(lPrecio.PListaBaseId, 0, 0, 0, 0, 1, tipoPedido)
                'recorrer el grid y compara el articulo 
                'si el articulo esiste en la nueva lista de precios se deja
                'si el articulo no existe en la nueva lista mandar mensaje
                For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                    'bandera para validar si encuentra el articulo
                    bandera = False
                    For Each renglon As DataRow In articulos.Rows
                        If row.Cells("IdMarcaSAY").Value = renglon.Item("IdMarcaSAY") And row.Cells("IdColeccionSAY").Value = renglon.Item("IdColeccionSAY") And row.Cells("EstiloProductoId").Value = renglon.Item("EstiloProductoId") And row.Cells("ProductoID").Value = renglon.Item("ProductoID") Then
                            bandera = True
                            Exit For
                        Else
                            bandera = False
                        End If
                    Next
                    If bandera = False Then
                        Dim confirmar As New AvisoForm
                        Dim mensaje As String
                        mensaje = "La fecha solicitada por el cliente no se puede cambiar, los articulos actuales no existen en la nueva lista de precios, "
                        mensaje += "si desea cambiar la fecha solicitada debera eliminar el pedido y capturarlo nuevamente"
                        confirmar.mensaje = mensaje
                        confirmar.ShowDialog()
                        dtpFSolicitada.Value = pedido.FechasolicitadaCliente
                        Exit Sub
                    End If
                Next
            End If

            txtListaPrecio.Text = lPrecio.PListaBaseNombre
            txtIDListaPrecio.Text = lPrecio.PListaBaseId
            ListaPrecios = lPrecio
        End If
    End Sub

    Private Sub validarCambioCliente()
        lblCliente.ForeColor = Color.Black
        lblFechaSol.ForeColor = Color.Black
        lblListaPrecios.ForeColor = Color.Black
        If banderaValidacionCliente And grdProductos.Rows.Count = 0 Then
            cliente = cmbClientes.SelectedItem
            CargarListaPrecios()
        ElseIf banderaValidacionCliente Then
            If grdProductos.Rows.Count > 1 And banderaCliente = False Then
                Dim confirmar As New ConfirmarForm
                confirmar.mensaje = "Esta seguro de cambiar el cliente? (Debera capturar nuevamente el pedido)"
                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    grdProductos.DataSource = Nothing
                    bandera = False
                    cliente = cmbClientes.SelectedItem
                    dtpFSolicitada.Value = Now.Date
                Else
                    banderaCliente = True
                    cmbClientes.SelectedItem = cliente
                    banderaCliente = False
                End If
            Else
                If banderaCliente = False Then
                    cliente = cmbClientes.SelectedItem
                    CargarListaPrecios()
                End If
            End If
        End If
    End Sub

    Private Sub validarCambioFechaSolicitada()
        txtSemana.Text = "S " & DatePart("ww", dtpFSolicitada.Value.Date) & "-" & dtpFSolicitada.Value.Year
        If Not cliente Is Nothing And operacion = "Alta" And grdProductos.Rows.Count = 0 Then
            CargarListaPrecios()
        ElseIf Not cliente Is Nothing And txtIDListaPrecio.Text <> "" Then
            cambiarListaPrecios()
        End If
        fechaSolicitada = dtpFSolicitada.Value.Date
    End Sub

    Private Sub eliminarRegistros()
        If txtEstatusNombre.Text.Contains("CAPTURADO") And CInt(lblContados.Text) > 0 Then
            Dim confirmar As New ConfirmarForm
            Dim num As Int32
            confirmar.mensaje = "Esta seguro de eliminar los articulos seleccionados? (Una vez realizada esta accion no se podra revertir)"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                If operacion = "Alta" Then
                    For Each rowGR As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                        If rowGR.Cells("Seleccion").Value = True Then
                            If pares > 0 Then
                                pares = pares - CInt(rowGR.Cells("Pares").Value)
                            End If
                            rowGR.Delete()
                        End If
                    Next
                ElseIf operacion = "Editar" Then
                    For Each rowGR As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                        If rowGR.Cells("Seleccion").Value = True Then
                            If pares > 0 Then
                                num = CInt(rowGR.Cells("Pares").Value)
                                pares = pares - num
                            End If
                            rowGR.Cells("Pares").Value = "0"
                            rowGR.Hidden = True
                            objDA.EliminarPartidas(SesionUsuario.UsuarioSesion.PUserUsuarioid, CInt(rowGR.Cells("IDdetalle").Text))
                        End If
                    Next
                End If


                Dim dialogo As New ExitoForm
                dialogo.mensaje = "Se eliminaron los articulos con éxito"
                dialogo.ShowDialog()
                cbxSeleccionar.Checked = False
            End If
            lblContados.Text = pares.ToString("N0")
            SeleccionarRegistros()
        End If
        If banderaImportar = True Then
            validarListaPreciosImportacion()
        End If
    End Sub

    Private Sub NavegacionGrid(e As KeyEventArgs)
        If e.KeyCode = 13 Or e.KeyCode = 40 Then
            grdProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            grdProductos.PerformAction(UltraGridAction.BelowCell, False, False)
            e.Handled = True
            grdProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
        ElseIf e.KeyCode = 37 Then
            grdProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            grdProductos.PerformAction(UltraGridAction.PrevCellByTab, False, False)
            e.Handled = True
            grdProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
        ElseIf e.KeyCode = 38 Then
            grdProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            grdProductos.PerformAction(UltraGridAction.AboveCell, False, False)
            e.Handled = True
            grdProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
        ElseIf e.KeyCode = 39 Then
            grdProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            grdProductos.PerformAction(UltraGridAction.NextCellByTab, False, False)
            e.Handled = True
            grdProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
        End If
    End Sub

    Private Sub AbrirBitacora()
        Dim bitacora As New BitacoraPedidoVirtualForm
        bitacora.txtCliente.Text = cliente.nombregenerico
        bitacora.txtIdPedido.Text = txtPedido.Text
        bitacora.txtEstatus.Text = txtEstatusNombre.Text
        bitacora.txtTipoPedido.Text = CInt(txtEstatusId.Text)
        bitacora.MdiParent = Me.MdiParent
        bitacora.EncabezadoPedido = Me
        Me.Enabled = False
        bitacora.Show()
        bitacora.WindowState = FormWindowState.Normal
    End Sub

    Private Sub exportarExcel()
        'Variables locales
        Dim oExcel As Object
        Dim objLibroExcel As Object
        Dim oSheet As Object
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim ret As DialogResult
        Dim fileName As String
        Dim mensajeExito As New ExitoForm

        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            ret = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                fileName = .SelectedPath + "\PedidoVirtual_" + pedido.id.ToString + ".xlsx"

                Try
                    Me.Cursor = Cursors.WaitCursor
                    'Iniciar un nuevo libro en Excel 
                    oExcel = CreateObject("Excel.Application")
                    'Asi creas el Libro de Excel
                    objLibroExcel = oExcel.Workbooks.Add()
                    'Agregar datos a las celdas a la hoja "Resumen" del libro "Resumen 2014" 
                    oSheet = objLibroExcel.Worksheets(1)
                    'Esta celda contendrálos datos del pedido
                    oSheet.Range("A1").Font.Bold = True
                    oSheet.Range("A1").Value = "Pedido"
                    oSheet.Range("B1").Value = pedido.id.ToString
                    oSheet.Range("E1").Font.Bold = True
                    oSheet.Range("E1").Value = "Fecha Solicitada"
                    oSheet.Range("F1").Value = dtpFSolicitada.Value
                    oSheet.Range("A2").Value = "Cliente"
                    oSheet.Range("A2").Font.Bold = True
                    oSheet.Range("B2:D2").Merge()
                    oSheet.Range("B2").Value = cliente.nombregenerico
                    oSheet.Range("E2").Value = "Tipo Pedido"
                    oSheet.Range("E2").Font.Bold = True
                    oSheet.Range("F2:G2").Merge()
                    oSheet.Range("F2").Value = tipoNombrePedido.Substring(0, tipoNombrePedido.IndexOf("(")).ToString
                    oSheet.Range("A3").Value = "Lista de precios"
                    oSheet.Range("A3").Font.Bold = True
                    oSheet.Range("B3:C3").Merge()
                    oSheet.Range("B3").Value = txtListaPrecio.Text
                    oSheet.Range("E3").Value = "Orden"
                    oSheet.Range("E3").Font.Bold = True
                    oSheet.Range("F3").Value = txtOrdenCliente.Text
                    oSheet.Range("A4").Font.Bold = True
                    oSheet.Range("A4").Value = "Fecha Programación"
                    oSheet.Range("B4").Value = dtpFProgramacion.Value
                    oSheet.Range("E4").Font.Bold = True
                    oSheet.Range("E4").Value = "Estatus"
                    oSheet.Range("F4").Value = txtEstatusNombre.Text
                    oSheet.Range("A5").Font.Bold = True
                    oSheet.Range("A5").Value = "Observaciones"
                    oSheet.Range("B5:F6").Merge()
                    oSheet.Range("B5:F6").Value = txtObservaciones.Text

                    'Encabezados de la tabla
                    oSheet.Range("A8").Value = "MARCA"
                    oSheet.Range("B8").Value = "COLECCION"
                    oSheet.Range("C8").Value = "TEMPORADA"
                    oSheet.Range("D8").Value = "ESTATUS"

                    If tipoPedido = 3 Then
                        oSheet.Range("E8").Value = "MODELO SAY"
                        oSheet.Range("F8").Value = "MODELO SICY"
                        oSheet.Range("G8").Value = "PIEL"
                        oSheet.Range("H8").Value = "COLOR"
                        oSheet.Range("I8").Value = "CORRIDA"
                        oSheet.Range("J8").Value = "PARES"
                    ElseIf tipoPedido = 4 Then
                        oSheet.Range("E8").Value = "MODELO SAY"
                        oSheet.Range("F8").Value = "MODELO SICY"
                        oSheet.Range("G8").Value = "PARES"
                    ElseIf tipoPedido = 5 Then
                        oSheet.Range("E8").Value = "PARES"
                    End If

                    oSheet.Range("A8:J8").Font.Bold = True
                    'oSheet.Range("A4:J4").AutoFilter(1, , VisibleDropDown:=True)

                    'Primero verificamos cuantas filas y cuántas columnas tiene DGV
                    Dim renglon As Integer = 9 'empezaremos en el libro de Excel a partir de la celda 5

                    For Each row As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
                        'Estas son las columnas que usaremos y el contador nos ira cargando una a una cada fila
                        If row.Cells(1).Value <> "" Then
                            oSheet.Range("A" + renglon.ToString).Value = row.Cells(1).Value
                            oSheet.Range("B" + renglon.ToString).Value = row.Cells(2).Value
                            oSheet.Range("C" + renglon.ToString).Value = row.Cells(3).Value
                            oSheet.Range("D" + renglon.ToString).Value = row.Cells(4).Value

                            If tipoPedido = 3 Then
                                oSheet.Range("E" + renglon.ToString).Value = row.Cells(5).Value
                                oSheet.Range("F" + renglon.ToString).Value = row.Cells(6).Value
                                oSheet.Range("G" + renglon.ToString).Value = row.Cells(7).Value
                                oSheet.Range("H" + renglon.ToString).Value = row.Cells(8).Value
                                oSheet.Range("I" + renglon.ToString).Value = row.Cells(9).Value
                                oSheet.Range("J" + renglon.ToString).Value = row.Cells(17).Value
                            ElseIf tipoPedido = 4 Then
                                oSheet.Range("E" + renglon.ToString).Value = row.Cells(5).Value
                                oSheet.Range("F" + renglon.ToString).Value = row.Cells(6).Value
                                oSheet.Range("G" + renglon.ToString).Value = row.Cells(10).Value '14
                            ElseIf tipoPedido = 5 Then
                                oSheet.Range("E" + renglon.ToString).Value = row.Cells(7).Value '12
                            End If

                        End If
                        renglon = renglon + 1
                    Next
                    'Ajustar el ancho de las columnas
                    oSheet.Range("A3:J" + renglon.ToString).columns.AutoFit()

                    'Asi Guardas el Libro de Excel
                    objLibroExcel.Application.ActiveWorkbook.SaveAs(fileName)
                    oExcel.Workbooks.Close()
                    objLibroExcel = Nothing
                    Me.Cursor = Cursors.Default

                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()
                    .Dispose()
                    Process.Start(fileName)
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Atención")
                End Try
            End If
        End With
    End Sub

    Private Sub importarPedido()
        Dim confirmar As New AdvertenciaForm
        Dim tablaProductosImportados As New DataTable
        Dim renglon As DataRow
        Dim columnas As String
        Dim Cadena() As String
        Dim i As Int32, partidas As Int32, numColumnas As Int32 = 0
        Dim detallesProd As New DataTable
        pares = 0
        cbxSeleccionar.Checked = False
        SeleccionarRegistros()
        btnGuardar.Enabled = True

        If cmbClientes.SelectedValue = 0 Then
            confirmar.mensaje = "Debe seleccionar un cliente"
            confirmar.ShowDialog()
            Exit Sub
        End If

        If txtIDListaPrecio.Text = "" Then
            confirmar.mensaje = "El cliente debe tener una lista de precios asignada"
            confirmar.ShowDialog()
            Exit Sub
        End If

        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim datosExcel As DataTable


        datosExcel = Tools.Excel.LlenarTablaExcelListaTablas("", "", "")
        If datosExcel.Rows.Count > 0 Then
            partidas = 1
            For Each row As DataRow In datosExcel.Rows
                If CInt(row.Item("Renglon")) = 1 Then
                    If cliente.nombregenerico.Equals(row.Item("C2").ToString) Then
                        If (row.Item("C5").ToString.Contains("Confirmado") And rbtPedNoConfirmado.Checked = True) Then
                            columnas = "Seleccion,Marca,Coleccion,Temporada,Estatus,ModeloSAY,ModeloSICY,Piel,Color,Corrida,IdPielSAY,IdColorSAY,IdTallaSAY,ProductoID,ProductoEstiloID,IdMarcaSAY,IdColeccionSAY,Pares,Partida,listaP"
                            Cadena = columnas.Split(",")
                            i = 0
                            While i < Cadena.Length
                                If Cadena(i).Equals("Pares") Then
                                    tablaProductosImportados.Columns.Add(Cadena(i), Type.GetType("System.Int32"))
                                Else
                                    tablaProductosImportados.Columns.Add(Cadena(i))
                                End If
                                i += 1
                            End While
                            numColumnas = 10
                        ElseIf (row.Item("C5").ToString.Contains("Borrador") And rbtBorradorCliente.Checked = True) Then
                            columnas = "Seleccion,Marca,Coleccion,Temporada,Estatus,ModeloSAY,ModeloSICY,ProductoID,IdMarcaSAY,IdColeccionSAY,Pares,Partida,listaP"
                            Cadena = columnas.Split(",")
                            i = 0
                            While i < Cadena.Length
                                If Cadena(i).Equals("Pares") Then
                                    tablaProductosImportados.Columns.Add(Cadena(i), Type.GetType("System.Int32"))
                                Else
                                    tablaProductosImportados.Columns.Add(Cadena(i))
                                End If
                                i += 1
                            End While
                            numColumnas = 7
                        ElseIf (row.Item("C5").ToString.Contains("Ventas") And rbtProyeccion.Checked = True) Then
                            columnas = "Seleccion,Marca,Coleccion,Temporada,Estatus,IdMarcaSAY,IdColeccionSAY,Pares,Partida,listaP"
                            Cadena = columnas.Split(",")
                            i = 0
                            While i < Cadena.Length
                                If Cadena(i).Equals("Pares") Then
                                    tablaProductosImportados.Columns.Add(Cadena(i), Type.GetType("System.Int32"))
                                Else
                                    tablaProductosImportados.Columns.Add(Cadena(i))
                                End If
                                i += 1
                            End While
                            numColumnas = 5
                        Else
                            confirmar.mensaje = "El tipo de pedido seleccionado no corresponde al del archivo"
                            confirmar.ShowDialog()
                            Exit Sub
                        End If
                    Else
                        confirmar.mensaje = "El cliente seleccionado no corresponde al del archivo"
                        confirmar.ShowDialog()
                        Exit Sub
                    End If
                ElseIf CInt(row.Item("Renglon")) >= 5 And Not IsDBNull(row.Item("C1")) Then
                    renglon = tablaProductosImportados.NewRow()
                    i = 0

                    If tipoPedido = 3 Then
                        detallesProd = objDA.ValidarArticulosImportacion(CInt(txtIDListaPrecio.Text), row.Item("C1"), row.Item("C2"), row.Item("C5"), row.Item("C6"), row.Item("C3"), row.Item("C4"), row.Item("C7"), row.Item("C8"), row.Item("C9"), tipoPedido)
                    ElseIf tipoPedido = 4 Then
                        detallesProd = objDA.ValidarArticulosImportacion(CInt(txtIDListaPrecio.Text), row.Item("C1"), row.Item("C2"), row.Item("C5"), row.Item("C6"), row.Item("C3"), row.Item("C4"), "", "", "", tipoPedido)
                    ElseIf tipoPedido = 5 Then
                        Dim estatusRenglon() As String, renglonExcel As String
                        renglonExcel = row.Item("C4").ToString
                        estatusRenglon = renglonExcel.Split(",")
                        detallesProd = objDA.ValidarArticulosImportacion(CInt(txtIDListaPrecio.Text), row.Item("C1"), row.Item("C2"), "", "", row.Item("C3"), estatusRenglon(0), "", "", "", tipoPedido)
                    End If

                    If detallesProd.Rows.Count = 1 Then
                        While i < detallesProd.Rows.Item(0).ItemArray.Length
                            renglon.Item(i) = detallesProd.Rows.Item(0).Item(i)
                            i += 1
                        End While
                        If tipoPedido = 3 Then
                            If (row.Item("C10").ToString) <> "" Then
                                pares += CInt(row.Item("C10").ToString)
                                renglon.Item(i) = CInt(row.Item("C10").ToString)
                            Else
                                pares += 0
                                renglon.Item(i) = 0
                            End If
                        ElseIf tipoPedido = 4 Then
                            If (row.Item("C7").ToString) <> "" Then
                                pares += CInt(row.Item("C7").ToString)
                                renglon.Item(i) = CInt(row.Item("C7").ToString)
                            Else
                                pares += 0
                                renglon.Item(i) = 0
                            End If
                        ElseIf tipoPedido = 5 Then
                            If (row.Item("C5").ToString) <> "" Then
                                pares += CInt(row.Item("C5").ToString)
                                renglon.Item(i) = CInt(row.Item("C5").ToString)
                            Else
                                pares += 0
                                renglon.Item(i) = 0
                            End If
                        End If

                        renglon.Item(i + 1) = partidas
                        renglon.Item(i + 2) = "SI"
                    Else
                        i = 1
                        renglon.Item(0) = "False"
                        While i < numColumnas
                            renglon.Item(i) = row.Item("C" + i.ToString)
                            i += 1
                        End While

                        If tipoPedido = 3 Then
                            pares += CInt(row.Item("C10").ToString)
                            renglon.Item(i + 7) = row.Item("C10")
                            renglon.Item(i + 8) = partidas
                            renglon.Item(i + 9) = "NO"
                        ElseIf tipoPedido = 4 Then
                            pares += CInt(row.Item("C7").ToString)
                            renglon.Item(i + 3) = row.Item("C7")
                            renglon.Item(i + 4) = partidas
                            renglon.Item(i + 5) = "NO"
                        ElseIf tipoPedido = 5 Then
                            pares += CInt(row.Item("C5").ToString)
                            renglon.Item(i + 2) = row.Item("C5")
                            renglon.Item(i + 3) = partidas
                            renglon.Item(i + 4) = "NO"
                        End If

                    End If
                    partidas += 1
                    tablaProductosImportados.Rows.Add(renglon)
                End If
            Next
            lblContados.Text = pares.ToString("N0")

            grdProductos.DataSource = tablaProductosImportados
            crearformatoGrid()
            banderaImportar = True

            grdProductos.DisplayLayout.Bands(0).Columns("listaP").CellActivation = Activation.NoEdit
            grdProductos.DisplayLayout.Bands(0).Columns("listaP").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            grdProductos.DisplayLayout.Bands(0).Columns("listaP").Width = 70
            validarListaPreciosImportacion()
        End If
    End Sub

    Private Sub validarListaPreciosImportacion()
        Dim articulosNo As Int32 = 0
        For Each rowGR As UltraGridRow In grdProductos.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("listaP").Value = "SI" Then
                rowGR.Cells("listaP").Appearance.ForeColor = Color.Green
                rowGR.Cells("listaP").Appearance.FontData.Bold = DefaultableBoolean.True
            Else
                rowGR.Cells("listaP").Appearance.ForeColor = Color.Red
                rowGR.Cells("listaP").Appearance.FontData.Bold = DefaultableBoolean.True
                articulosNo += 1
            End If
        Next
        If articulosNo = 0 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If pedido Is Nothing Then
            guardarPedido()
        Else
            editarPedido()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        admin.Enabled = True
        admin.Consultafiltros()
        admin.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        abrirCatalogo()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        eliminarRegistros()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        importarPedido()
    End Sub

    Private Sub btnBitacora_Click(sender As Object, e As EventArgs) Handles btnBitacora.Click
        AbrirBitacora()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        validarCambioCliente()
    End Sub

    Private Sub cbxSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSeleccionar.CheckedChanged
        SeleccionarRegistros()
    End Sub

    Private Sub grdProductos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdProductos.BeforeCellUpdate
        contarPares(e)
    End Sub

    Private Sub grdProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdProductos.CellChange
        seleccionarRegistroTabla(e)
    End Sub

    Private Sub grdProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdProductos.InitializeRow
        If bandera = False Then
            crearformatoGrid()
        End If
    End Sub

    Private Sub grdProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProductos.KeyDown
        NavegacionGrid(e)
    End Sub

    Private Sub grdProductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdProductos.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub grdProductos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdProductos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    
    Private Sub dtpFSolicitada_ValueChanged(sender As Object, e As EventArgs) Handles dtpFSolicitada.ValueChanged
        validarCambioFechaSolicitada()
    End Sub

    Private Sub dtpFProgramacion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFProgramacion.ValueChanged
        txtSemanaProgramacion.Text = "S " & DatePart("ww", dtpFProgramacion.Value.Date) & "-" & dtpFProgramacion.Value.Year
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 190
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 27
    End Sub

    Private Sub rbtBorradorCliente_Click(sender As Object, e As EventArgs) Handles rbtBorradorCliente.Click
        cambiarRadio(rbtBorradorCliente)
    End Sub

    Private Sub rbtPedNoConfirmado_Click(sender As Object, e As EventArgs) Handles rbtPedNoConfirmado.Click
        cambiarRadio(rbtPedNoConfirmado)
    End Sub

    Private Sub rbtProyeccion_Click(sender As Object, e As EventArgs) Handles rbtProyeccion.Click
        cambiarRadio(rbtProyeccion)
    End Sub

    Private Sub txtIDListaPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtIDListaPrecio.TextChanged
        Dim valor As String
        valor = txtIDListaPrecio.Text

        If CInt(valor) > 0 Then
            btnProductos.Enabled = True
            btnImportar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnProductos.Enabled = False
            btnImportar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub
End Class