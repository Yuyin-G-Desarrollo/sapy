Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Stimulsoft.Report

Public Class AdministracionApartadosForm

    Dim listInicial As New List(Of String)
    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)
    Dim listFolioApartado As New List(Of String)
    Dim renglonArrastrable As Integer = 0
    Dim ordenamientoParaModificarPrioridades As Boolean = True
    Dim contadorCambioFechaPreparacionApartado As Integer = 0
    Dim indiceRenglonApartadoSeleccionado As Integer
    Dim perfilId As Integer = 0
    Public ventanaAbierta As String = String.Empty
    Dim cancelarSoloActivo As Boolean = False

    'Dim listCliente As New List(Of String)
    'Dim listTienda As New List(Of String)
    'Dim listOrdenesTrabajo As New List(Of String)

    'Dim listOperador As New List(Of String)
    'Dim listColeccion As New List(Of String)
    'Dim listModelo As New List(Of String)
    'Dim listPiel As New List(Of String)
    'Dim listColor As New List(Of String)
    'Dim listCorrida As New List(Of String)
    'Dim listMarca As New List(Of String)


    Private Sub AdministracionApartadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoPerfil As New DataTable

        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        'chboxSeleccionarTodo.Visible = False
        Me.WindowState = 2

        listInicial = New List(Of String)
        listPedidoSAY = New List(Of String)
        listPedidoSICY = New List(Of String)
        listFolioApartado = New List(Of String)
        'listCliente = New List(Of String)
        'listTienda = New List(Of String)
        'listOrdenesTrabajo = New List(Of String)

        'listOperador = New List(Of String)
        'listColeccion = New List(Of String)
        'listModelo = New List(Of String)
        'listPiel = New List(Of String)
        'listColor = New List(Of String)
        'listCorrida = New List(Of String)
        'listMarca = New List(Of String)

        grdPedidoSAY.DataSource = listInicial
        grdPedidoSICY.DataSource = listInicial
        grdFolioApartado.DataSource = listInicial

        'grdCliente.DataSource = listCliente
        'grdTienda.DataSource = listTienda
        'grdOperador.DataSource = listOperador
        'grdColeccion.DataSource = listColeccion
        'grdModelo.DataSource = listModelo
        'grdPiel.DataSource = listPiel
        'grdColor.DataSource = listColor
        'grdCorrida.DataSource = listCorrida
        'grdMarca.DataSource = listMarca

        grdCliente.DataSource = listInicial
        grdTienda.DataSource = listInicial
        grdOperador.DataSource = listInicial
        grdColeccion.DataSource = listInicial
        grdModelo.DataSource = listInicial
        grdPiel.DataSource = listInicial
        grdColor.DataSource = listInicial
        grdCorrida.DataSource = listInicial
        grdMarca.DataSource = listInicial

        Tools.Utilerias.ComboObtenerCEDISUsuario(cboCedis)

        dtpFechaEntregaDel.Value = Date.Now
        dtpFechaEntregaAl.Value = Date.Now

        dtpFechaEntregaAl.MinDate = dtpFechaEntregaAl.Value

        Dim objBU As New Negocios.ApartadosBU()
        Dim Tabla_ListadoParametros As DataTable
        Tabla_ListadoParametros = objBU.ListadoParametroApartados(14)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbStatusApartados.DataSource = Tabla_ListadoParametros
        cmbStatusApartados.DisplayMember = "Status"
        cmbStatusApartados.ValueMember = "ID"

        cmbStatusApartados.SelectedIndex = 1

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") Then
            btnConfirmarApartado.Enabled = True
            lblTextoConfirmarApartado.Enabled = True
            btnImprimirApartado.Enabled = True
            lblTextoImprimirApartado.Enabled = True
            btnInventarioDisponible.Enabled = True
            lblTextoInventarioDisponible.Enabled = True
            btnEtiquetas.Enabled = True
            lblEtiquetas.Enabled = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_OPERADOR") Then
            btnConfirmarApartado.Enabled = True
            lblTextoConfirmarApartado.Enabled = True
            btnImprimirApartado.Enabled = True
            lblTextoImprimirApartado.Enabled = True
            btnEtiquetas.Enabled = True
            lblEtiquetas.Enabled = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            btnImprimirApartado.Enabled = True
            lblTextoImprimirApartado.Enabled = True
            btnAsignarPrioridad.Enabled = True
            lblTextoAsignarPrioridad.Enabled = True
            btnMarcarUrgente.Enabled = True
            lblTextoMarcarUrgente.Enabled = True
            btnCancelarApartados.Enabled = True
            lblTextoCancelarApartado.Enabled = True
            btnInventarioDisponible.Enabled = True
            lblTextoInventarioDisponible.Enabled = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_PPCP") Then
            btnCancelarApartados.Enabled = True
            lblTextoCancelarApartado.Enabled = True
            btnInventarioDisponible.Enabled = True
            lblTextoInventarioDisponible.Enabled = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_PPCP_GENERAL") Then
            btnInventarioDisponible.Enabled = True
            lblTextoInventarioDisponible.Enabled = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS_CANC_SOLO_ACTIVOS") Then
            btnCancelarApartados.Enabled = True
            lblTextoCancelarApartado.Enabled = True
            cancelarSoloActivo = True
        End If

        dtResultadoPerfil = objBU.consultaPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilId = dtResultadoPerfil.Rows(0).Item("perfilId")
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        pnlParametros.Height = 24
        chboxSeleccionarTodo.Visible = True
        chboxSeleccionarTodo.Checked = False

        gridApartados.DataSource = Nothing

        Dim objBU As New Negocios.ApartadosBU()
        Dim filtrosAdministracionApartados As New Entidades.FiltrosAdministradorApartados()

        Dim tabla_apartados As New DataTable
        Dim lPedidoSAY As String = String.Empty
        Dim lPedidoSICY As String = String.Empty
        Dim lFolioApartado As String = String.Empty
        Dim lCliente As String = String.Empty
        Dim lTiendaEmbarqueCEDIS As String = String.Empty
        Dim lMarca As String = String.Empty
        Dim lOperador As String = String.Empty
        Dim lColeccion As String = String.Empty
        Dim lModelo As String = String.Empty
        Dim lPiel As String = String.Empty
        Dim lColor As String = String.Empty
        Dim lCorrida As String = String.Empty

        filtrosAdministracionApartados.PTipoFecha = If(rdbFechaCaptura.Checked, 1, If(rdbFechaPreparacion.Checked, 2, If(rdbFechaSolicitada.Checked, 3, If(rdbFechaConfirmacion.Checked, 4, 0))))
        filtrosAdministracionApartados.PFechaDel = dtpFechaEntregaDel.Value.ToShortDateString()
        filtrosAdministracionApartados.PFechaAl = dtpFechaEntregaAl.Value.ToShortDateString()
        filtrosAdministracionApartados.PEstatusApartado = If(cmbStatusApartados.SelectedIndex > 0, cmbStatusApartados.SelectedValue, 0)
        filtrosAdministracionApartados.POrigenApartado = If(cmbOrigenApartado.SelectedIndex > 0, cmbOrigenApartado.Text, "")
        filtrosAdministracionApartados.PImpreso = If(chkImpreso.Checked, 1, 0)
        filtrosAdministracionApartados.PUrgente = If(chkUrgente.Checked, 1, 0)
        filtrosAdministracionApartados.PDetallado = If(chkDetallada.Checked, 1, 0)
        filtrosAdministracionApartados.PPorTallas = If(chkVerTallas.Checked, 1, 0)
        filtrosAdministracionApartados.PVerUbicaciones = If(chkVerUbicaciones.Checked, 1, 0)

        filtrosAdministracionApartados.PCedis = cboCedis.SelectedValue

        For Each row As UltraGridRow In grdPedidoSAY.Rows
            If row.Index = 0 Then
                lPedidoSAY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lPedidoSAY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PPedidoSay = lPedidoSAY

        For Each row As UltraGridRow In grdPedidoSICY.Rows
            If row.Index = 0 Then
                lPedidoSICY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lPedidoSICY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PPedidoSICY = lPedidoSICY

        For Each row As UltraGridRow In grdFolioApartado.Rows
            If row.Index = 0 Then
                lFolioApartado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lFolioApartado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PFolioApartado = lFolioApartado

        For Each row As UltraGridRow In grdCliente.Rows
            If row.Index = 0 Then
                lCliente += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lCliente += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PCliente = lCliente

        For Each row As UltraGridRow In grdTienda.Rows
            If row.Index = 0 Then
                lTiendaEmbarqueCEDIS += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lTiendaEmbarqueCEDIS += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        If perfilId = 74 Then
            If lCliente = "" And lTiendaEmbarqueCEDIS = "" Then
                show_message("Advertencia", "Debe seleccionar al menos un cliente o una tienda")
                pnlParametros.Height = 323
                Cursor = Cursors.Default
                Return
            End If
        End If

        filtrosAdministracionApartados.PTiendaEmbarqueCEDIS = lTiendaEmbarqueCEDIS

        For Each row As UltraGridRow In grdMarca.Rows
            If row.Index = 0 Then
                lMarca += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lMarca += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PMarca = lMarca

        For Each row As UltraGridRow In grdOperador.Rows
            If row.Index = 0 Then
                lOperador += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lOperador += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.POperador = lOperador

        For Each row As UltraGridRow In grdColeccion.Rows
            If row.Index = 0 Then
                lColeccion += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lColeccion += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PColeccion = lColeccion

        For Each row As UltraGridRow In grdModelo.Rows
            If row.Index = 0 Then
                lModelo += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lModelo += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PModelo = lModelo

        For Each row As UltraGridRow In grdPiel.Rows
            If row.Index = 0 Then
                lPiel += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lPiel += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PPiel = lPiel

        For Each row As UltraGridRow In grdColor.Rows
            If row.Index = 0 Then
                lColor += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lColor += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PColor = lColor

        For Each row As UltraGridRow In grdCorrida.Rows
            If row.Index = 0 Then
                lCorrida += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lCorrida += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        filtrosAdministracionApartados.PCorrida = lCorrida

        tabla_apartados = objBU.consultaAdministradorApartados(filtrosAdministracionApartados)

        If chkVerTallas.Checked Then
            Dim ApartadosTallas As String = String.Empty

            For Each renglon As DataRow In tabla_apartados.Rows
                If ApartadosTallas <> "" Then
                    ApartadosTallas += ","
                End If
                ApartadosTallas += renglon.Item("FolioApartado").ToString()
            Next
            filtrosAdministracionApartados.PFolioApartado = ApartadosTallas
            tabla_apartados = objBU.consultaAdministradorApartadosConTallas(filtrosAdministracionApartados)
        End If

        If tabla_apartados.Rows.Count > 0 Then
            gridApartados.DataSource = tabla_apartados
            gridApartadosDiseño(gridApartados)
        Else
            show_message("Aviso", "No hay datos para mostrar")
        End If

        lblTextoUltimaActualizacion.Visible = True
        lblFechaUltimaActualización.Visible = True
        lblFechaUltimaActualización.Text = Date.Now.ToString()

        cargaApartadosCanceladosDia(1)

        Cursor = Cursors.Default

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 323
        'chboxSeleccionarTodo.Visible = False
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 24
        chboxSeleccionarTodo.Visible = True
    End Sub

    Private Sub btnConfirmarApartado_Click(sender As Object, e As EventArgs) Handles btnConfirmarApartado.Click
        Dim ventana As New ConfirmarApartado()
        ventanaAbierta = "Confirmacion"
        'Dim totalApartadosSeleccionados As Integer = 0
        'Dim cliente As String = String.Empty
        'Dim folioApartado As Integer = 0
        'Dim pedidoSAY As Integer = 0
        'Dim pedidoSICY As Integer = 0
        'Dim ordenCliente As String = String.Empty
        'Dim fechaSolicitada As String = String.Empty
        'Dim fechaPreparacion As String = String.Empty
        'Dim entregaInmediata As Integer = 0

        'For Each renglon As UltraGridRow In gridApartados.Rows
        '    If CBool(renglon.Cells("seleccionar").Value) Then
        '        cliente = renglon.Cells("Cliente").Value.ToString()
        '        folioApartado = renglon.Cells("FolioApartado").Value.ToString()
        '        pedidoSAY = renglon.Cells("PedidoSAY").Value.ToString()
        '        pedidoSICY = renglon.Cells("PedidoSICY").Value.ToString()
        '        ordenCliente = renglon.Cells("OrdenCliente").Value.ToString()
        '        fechaSolicitada = renglon.Cells("FSolicitada").Text.ToString()
        '        fechaPreparacion = renglon.Cells("FPreparacion").Text.ToString()
        '        entregaInmediata = If(renglon.Cells("entregaInmediata").Value, 1, 0)
        '        totalApartadosSeleccionados += 1
        '    End If
        'Next

        'ventana.totalApartadosSeleccionados = totalApartadosSeleccionados

        'If totalApartadosSeleccionados = 1 Then
        '    ventana.cliente = cliente
        '    ventana.folioApartado = folioApartado
        '    ventana.pedidoSAY = pedidoSAY
        '    ventana.pedidoSICY = pedidoSICY
        '    ventana.ordenCliente = ordenCliente
        '    ventana.fechaSolicitada = fechaSolicitada
        '    ventana.fechaPreparacion = fechaPreparacion
        '    ventana.entregaInmediata = entregaInmediata
        'End If

        ventana.MdiParent = Me.MdiParent
        ventana.verDetalles = False
        ventana.Show()
    End Sub

    Private Sub btnVerDetallesApartados_Click(sender As Object, e As EventArgs) Handles btnVerDetallesApartados.Click
        Dim ventana As New ConfirmarApartado()
        Dim totalApartadosSeleccionados As Integer = 0
        Dim cliente As String = String.Empty
        Dim folioApartado As String = String.Empty
        Dim pedidoSAY As Integer = 0
        Dim pedidoSICY As Integer = 0
        Dim ordenCliente As String = String.Empty
        Dim fechaSolicitada As String = String.Empty
        Dim fechaPreparacion As String = String.Empty
        Dim entregaInmediata As Integer = 0
        Dim apartadosClientesBloqueados As Integer = 0
        Dim clienteBloqueado As Boolean = False
        Dim apartadoSICY As Integer = 0
        Dim statusApartado As String = String.Empty
        Dim tipoBloqueoCliente As String = String.Empty
        Dim lstfoliosSeleccionados As New List(Of String)

        ventanaAbierta = "Detalles"

        For Each renglon As UltraGridRow In gridApartados.Rows
            If CBool(renglon.Cells("seleccionar").Value) Then
                cliente = renglon.Cells("Cliente").Value.ToString()
                If lstfoliosSeleccionados.Contains(renglon.Cells("FolioApartado").Value.ToString()) = False Then
                    If folioApartado <> "" Then
                        folioApartado += ","
                    End If
                    folioApartado += renglon.Cells("FolioApartado").Value.ToString()
                    lstfoliosSeleccionados.Add(renglon.Cells("FolioApartado").Value.ToString())
                    totalApartadosSeleccionados += 1
                End If
                pedidoSAY = renglon.Cells("PedidoSAY").Value.ToString()
                pedidoSICY = renglon.Cells("PedidoSICY").Value.ToString()
                ordenCliente = renglon.Cells("OrdenCliente").Value.ToString()
                fechaSolicitada = renglon.Cells("FSolicitada").Text.ToString()
                fechaPreparacion = renglon.Cells("FPreparacion").Text.ToString()
                entregaInmediata = If(renglon.Cells("entregaInmediata").Value, 1, 0)
                If renglon.Cells("BLOQUEADOAPARTADO").Value = "S" Then
                    apartadosClientesBloqueados += 1
                    clienteBloqueado = True
                End If
                apartadoSICY = renglon.Cells("ApartadoSICY").Value
                statusApartado = renglon.Cells("EstatusNombre").Value.ToString()

                tipoBloqueoCliente = renglon.Cells("BLOQUEADOAPARTADOTIPO").Value.ToString()

            End If
        Next

        If totalApartadosSeleccionados = 0 Then
            show_message("Advertencia", "Debe seleccionar al menos un apartado para ver los detalles")
            Exit Sub
        End If

        ventana.totalApartadosSeleccionados = totalApartadosSeleccionados
        ventana.folioApartado = folioApartado
        ventana.totalApartadosClientesBloqueados = apartadosClientesBloqueados

        If totalApartadosSeleccionados = 1 Then
            ventana.cliente = cliente
            ventana.pedidoSAY = pedidoSAY
            ventana.pedidoSICY = pedidoSICY
            ventana.ordenCliente = ordenCliente
            ventana.fechaSolicitada = fechaSolicitada
            ventana.fechaPreparacion = fechaPreparacion
            ventana.entregaInmediata = entregaInmediata
            ventana.apartadoSICY = apartadoSICY
            ventana.statusApartado = statusApartado
            ventana.clienteBloqueado = clienteBloqueado
            ventana.tipoBloqueoCliente = tipoBloqueoCliente
        End If

        ventana.verDetalles = True
        ventana.VentanaAdministrador = Me
        ventana.MdiParent = Me.MdiParent
        Me.WindowState = 1
        ventana.Show()
    End Sub

    Private Sub btnCancelarApartados_Click(sender As Object, e As EventArgs) Handles btnCancelarApartados.Click
        Dim dtApartadosSeleccionados As New DataTable
        Dim contador As Integer = 0
        Dim renglonTabla As New Object
        Dim totalApartadosNoCancelables As Integer = 0
        Dim totalApartadosOrigenVentas As Integer = 0
        Dim totalApartadosOrigenPPCP As Integer = 0
        Dim tipoRestriccionCancelacionPorPerfil As String = String.Empty
        Dim apartadosCancelarValidacionOT As String = String.Empty
        Dim dtApartadosEnOTNoCancelables As New DataTable
        Dim objBU As New Negocios.ApartadosBU
        Dim dtApartadosConParesEntregados As New DataTable
        Dim partidasCancelarValidacionEntregados As String = String.Empty
        Dim listFilasEliminar As New List(Of DataRow)

        Cursor = Cursors.WaitCursor

        ventanaAbierta = "Cancelacion"

        dtApartadosSeleccionados.Columns.Add("Apartado")

        If chkDetallada.Checked Then
            dtApartadosSeleccionados.Columns.Add("Producto")
        End If
        dtApartadosSeleccionados.Columns.Add("Partida")
        dtApartadosSeleccionados.Columns.Add("ApartadoDetalle")
        dtApartadosSeleccionados.Columns.Add("Pedido")
        dtApartadosSeleccionados.Columns.Add("OrdenCliente")
        dtApartadosSeleccionados.Columns.Add("Cantidad", Type.GetType("System.Int32"))
        dtApartadosSeleccionados.Columns.Add("Status")
        dtApartadosSeleccionados.Columns.Add("Motivo")
        dtApartadosSeleccionados.Columns.Add("Observaciones")
        dtApartadosSeleccionados.Columns.Add("Cliente")

        For Each renglon As UltraGridRow In gridApartados.Rows
            If CBool(renglon.Cells("seleccionar").Value) Then
                If cancelarSoloActivo Then
                    If renglon.Cells("EstatusNombre").Value = "ACTIVO" Then
                        dtApartadosSeleccionados.Rows.Add(renglonTabla)
                        dtApartadosSeleccionados.Rows(contador).Item("Apartado") = renglon.Cells("FolioApartado").Value
                        If apartadosCancelarValidacionOT <> "" Then
                            apartadosCancelarValidacionOT += ","
                        End If
                        apartadosCancelarValidacionOT += renglon.Cells("FolioApartado").Value.ToString

                        If chkDetallada.Checked Then
                            dtApartadosSeleccionados.Rows(contador).Item("Producto") = renglon.Cells("Producto").Value
                            dtApartadosSeleccionados.Rows(contador).Item("ApartadoDetalle") = renglon.Cells("ApartadoDetalle").Value
                            dtApartadosSeleccionados.Rows(contador).Item("Partida") = renglon.Cells("PartidaApartado").Value
                            If partidasCancelarValidacionEntregados <> "" Then
                                partidasCancelarValidacionEntregados += ","
                            End If
                            partidasCancelarValidacionEntregados += renglon.Cells("PartidaApartado").Value.ToString
                        End If

                        dtApartadosSeleccionados.Rows(contador).Item("Pedido") = renglon.Cells("PedidoSAY").Value
                        dtApartadosSeleccionados.Rows(contador).Item("OrdenCliente") = renglon.Cells("OrdenCliente").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Cantidad") = renglon.Cells("Cantidad").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Status") = renglon.Cells("EstatusNombre").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Motivo") = ""
                        dtApartadosSeleccionados.Rows(contador).Item("Observaciones") = ""
                        dtApartadosSeleccionados.Rows(contador).Item("Cliente") = renglon.Cells("Cliente").Value

                        If renglon.Cells("Origen").Value = "VENTAS" Then
                            totalApartadosOrigenVentas += 1
                        ElseIf renglon.Cells("Origen").Value = "PPCP" Then
                            totalApartadosOrigenPPCP += 1
                        End If

                        contador += 1
                    Else
                        totalApartadosNoCancelables += 1
                    End If
                Else
                    If renglon.Cells("EstatusNombre").Value <> "CANCELADO" And renglon.Cells("EstatusNombre").Value <> "EN EJECUCIÓN" And renglon.Cells("EstatusNombre").Value <> "CONFIRMACIÓN INCOMPLETA" Then
                        dtApartadosSeleccionados.Rows.Add(renglonTabla)
                        dtApartadosSeleccionados.Rows(contador).Item("Apartado") = renglon.Cells("FolioApartado").Value
                        If apartadosCancelarValidacionOT <> "" Then
                            apartadosCancelarValidacionOT += ","
                        End If
                        apartadosCancelarValidacionOT += renglon.Cells("FolioApartado").Value.ToString

                        If chkDetallada.Checked Then
                            dtApartadosSeleccionados.Rows(contador).Item("Producto") = renglon.Cells("Producto").Value
                            dtApartadosSeleccionados.Rows(contador).Item("ApartadoDetalle") = renglon.Cells("ApartadoDetalle").Value
                            dtApartadosSeleccionados.Rows(contador).Item("Partida") = renglon.Cells("PartidaApartado").Value
                            If partidasCancelarValidacionEntregados <> "" Then
                                partidasCancelarValidacionEntregados += ","
                            End If
                            partidasCancelarValidacionEntregados += renglon.Cells("PartidaApartado").Value.ToString
                        End If

                        dtApartadosSeleccionados.Rows(contador).Item("Pedido") = renglon.Cells("PedidoSAY").Value
                        dtApartadosSeleccionados.Rows(contador).Item("OrdenCliente") = renglon.Cells("OrdenCliente").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Cantidad") = renglon.Cells("Cantidad").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Status") = renglon.Cells("EstatusNombre").Value
                        dtApartadosSeleccionados.Rows(contador).Item("Motivo") = ""
                        dtApartadosSeleccionados.Rows(contador).Item("Observaciones") = ""
                        dtApartadosSeleccionados.Rows(contador).Item("Cliente") = renglon.Cells("Cliente").Value

                        If renglon.Cells("Origen").Value = "VENTAS" Then
                            totalApartadosOrigenVentas += 1
                        ElseIf renglon.Cells("Origen").Value = "PPCP" Then
                            totalApartadosOrigenPPCP += 1
                        End If

                        contador += 1
                    Else
                        totalApartadosNoCancelables += 1
                        'contador += 1
                    End If
                End If

            End If
        Next

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_PPCP") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            tipoRestriccionCancelacionPorPerfil = ""
        Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_PPCP") Then
                If totalApartadosOrigenVentas > 0 Then
                    If chkDetallada.Checked Then
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse partidas de apartados con origen en PPCP."
                    Else
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse apartados con origen en PPCP."
                    End If
                End If
            End If


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
                If totalApartadosOrigenPPCP > 0 Then
                    If chkDetallada.Checked Then
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse partidas de apartados con origen en VENTAS."
                    Else
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse apartados con origen en VENTAS."
                    End If
                End If
            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS_CANC_SOLO_ACTIVOS") Then
                If totalApartadosOrigenPPCP > 0 Then
                    If chkDetallada.Checked Then
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse partidas de apartados con origen en VENTAS."
                    Else
                        tipoRestriccionCancelacionPorPerfil = "Solamente pueden cancelarse apartados con origen en VENTAS."
                    End If
                End If
            End If

        End If

        If tipoRestriccionCancelacionPorPerfil = "" Then
            If contador > 0 Or totalApartadosNoCancelables > 0 Then
                If totalApartadosNoCancelables = 0 Then

                    'AGREGADO 18/07/2017 LMEP - VALIDACIÓN NO CANCELAR APARTADOS EN OT
                    If chkDetallada.Checked = False Then
                        dtApartadosEnOTNoCancelables = objBU.validaApartadosPorCancelarEnOT(apartadosCancelarValidacionOT)
                        'dtApartadosEnOTNoCancelables = objBU.obtenerPartidaApartadoEnOrdenTrabajo(apartadosCancelarValidacionOT, partidasCancelarValidacionEntregados)
                    Else
                        dtApartadosEnOTNoCancelables = objBU.obtenerPartidaApartadoEnOrdenTrabajo(apartadosCancelarValidacionOT, partidasCancelarValidacionEntregados)
                    End If

                    If chkDetallada.Checked = False Then
                        dtApartadosConParesEntregados = objBU.obtenerParesEntregadosPorApartado(apartadosCancelarValidacionOT)
                    Else
                        'dtApartadosConParesEntregados = objBU.obtenerParesEntregadosPorPartida(apartadosCancelarValidacionOT, partidasCancelarValidacionEntregados)
                    End If


                    If dtApartadosEnOTNoCancelables.Rows.Count = 0 Then
                        'If dtApartadosConParesEntregados.Rows.Count > 0 Then
                        '    Dim ventanaEntregados As New ApartadosEnOT_NoCancelables()
                        '    ventanaEntregados.StartPosition = FormStartPosition.CenterScreen
                        '    ventanaEntregados.lblMensaje.Text = "Los pares entregados no pueden cancelarse."
                        '    ventanaEntregados.dtApartadosEnOT = dtApartadosConParesEntregados
                        '    ventanaEntregados.ShowDialog()

                        '    For Each row As DataRow In dtApartadosConParesEntregados.Rows
                        '        If row.Item("Pares") + row.Item("Cancelados") = row.Item("Entregados") Then
                        '            For Each rowAp As DataRow In dtApartadosSeleccionados.Rows
                        '                If chkDetallada.Checked = False Then
                        '                    If rowAp.Item("Apartado") = row.Item("Apartado") Then
                        '                        listFilasEliminar.Add(rowAp)
                        '                    End If
                        '                Else
                        '                    If rowAp.Item("Apartado") = row.Item("Apartado") And rowAp.Item("Partida") = row.Item("Partida") Then
                        '                        listFilasEliminar.Add(rowAp)
                        '                    End If
                        '                End If
                        '            Next
                        '        End If
                        '    Next

                        '    For Each row As DataRow In listFilasEliminar
                        '        dtApartadosSeleccionados.Rows.Remove(row)
                        '    Next

                        'End If
                        If dtApartadosSeleccionados.Rows.Count > 0 Then
                            Dim ventana As New CancelacionApartados()
                            ventana.StartPosition = FormStartPosition.CenterScreen
                            ventana.MdiParent = Me.MdiParent
                            ventana.detallada = If(chkDetallada.Checked, 1, 0)
                            ventana.dtDatosApartadosPartidasCancelar = dtApartadosSeleccionados
                            Me.WindowState = 1
                            ventana.Show()
                        End If

                    Else

                        Dim ventana As New ApartadosEnOT_NoCancelables()
                        ventana.StartPosition = FormStartPosition.CenterScreen
                        ventana.dtApartadosEnOT = dtApartadosEnOTNoCancelables
                        ventana.validarCheckDetallada = True
                        ventana.ShowDialog()

                    End If

                Else
                    If chkDetallada.Checked Then
                        show_message("Advertencia", "Solamente pueden cancelarse las partidas ""ACTIVAS"",""CONFIRMADAS"" Y ""PARCIALMENTE CONFIRMADAS"" ")
                    Else
                        If cancelarSoloActivo Then
                            show_message("Advertencia", "Solo puede cancelar apartados  'ACTIVOS'")
                        Else
                            show_message("Advertencia", "Solamente pueden cancelarse apartados ""ACTIVOS"",""CONFIRMADOS"" Y ""PARCIALMENTE CONFIRMADOS"" ")
                        End If
                    End If
                End If
            Else
                If chkDetallada.Checked Then
                    show_message("Advertencia", "Debe seleccionar al menos una partida a cancelar")
                Else
                    show_message("Advertencia", "Debe seleccionar al menos un apartado a cancelar")
                End If
            End If
        Else
            show_message("Advertencia", tipoRestriccionCancelacionPorPerfil + " Verifique por favor")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
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

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdFolioApartado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioApartado.InitializeLayout
        grid_diseño(grdFolioApartado)
        grdFolioApartado.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Apartado"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda/Embarque/CEDIS"
    End Sub

    Private Sub grdOperador_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOperador.InitializeLayout
        grid_diseño(grdOperador)
        grdOperador.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Operador"
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdPiel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPiel.InitializeLayout
        grid_diseño(grdPiel)
        grdPiel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel"
    End Sub

    Private Sub grdColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColor.InitializeLayout
        grid_diseño(grdColor)
        grdColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Color"
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub


    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub txtFolioApartado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioApartado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioApartado.Text) Then Return

            listFolioApartado.Add(txtFolioApartado.Text)
            grdFolioApartado.DataSource = Nothing
            grdFolioApartado.DataSource = listFolioApartado

            txtFolioApartado.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioApartado_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioApartado.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioApartado.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub



    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

    Private Sub grdOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOperador.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdOperador.DeleteSelectedRows(False)
    End Sub


    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPiel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPiel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPiel.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 2
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

    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 5
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

    Private Sub btnOperador_Click(sender As Object, e As EventArgs) Handles btnOperador.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdOperador.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdOperador.DataSource = listado.listParametros
        With grdOperador
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operador"
        End With
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click

        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 11
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        With grdModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelo"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub btnPiel_Click(sender As Object, e As EventArgs) Handles btnPiel.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 12
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdPiel.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdPiel.DataSource = listado.listParametros
        With grdPiel
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Piel"
        End With
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 13
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColor.DataSource = listado.listParametros
        With grdColor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Color"
        End With
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        If dtpFechaEntregaAl.Value < dtpFechaEntregaDel.Value Then
            dtpFechaEntregaAl.Value = dtpFechaEntregaDel.Value
        End If
        dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
    End Sub

    Private Sub chkVerTallas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTallas.CheckedChanged
        If chkVerTallas.Checked = True Then
            chkDetallada.Checked = True
        Else
            'chkDetallada.Checked = False
        End If
    End Sub

    Private Sub chkDetallada_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetallada.CheckedChanged
        If chkDetallada.Checked = False Then
            chkVerTallas.Checked = False
            chkVerUbicaciones.Checked = False
        End If
    End Sub

    Private Sub gridApartadosDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            grid.AllowDrop = True
        End If
        asignaFormato_Columna(grid)
        grid.DisplayLayout.Bands(0).Columns("entregaInmediata").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("E").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ApartadoSICY").Hidden = False
        If chkImpreso.Checked Then
            grid.DisplayLayout.Bands(0).Columns("Impreso").Hidden = True
        End If
        If chkUrgente.Checked Then
            grid.DisplayLayout.Bands(0).Columns("Urgente").Hidden = True
        End If

        grid.DisplayLayout.Bands(0).Columns("EstatusNombre").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("RequiereEtiqueta").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("EtiquetaSolicitada").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Priorizado").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("EntregaTipo").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ConFechaPreparacion").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOAPARTADOTIPO").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("MarcadoPrioridad").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("apar_partidacompleta").Hidden = True


        grid.DisplayLayout.Bands(0).Columns("ClienteID").Hidden = True



        If chkDetallada.Checked Then
            ' grid.DisplayLayout.Bands(0).Columns("apad_partidacompleta").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PartidaApartado").Header.Caption = "PartidaAp"
            grid.DisplayLayout.Bands(0).Columns("ApartadoDetalle").Hidden = True
        End If

        grid.DisplayLayout.Bands(0).Columns("seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("seleccionar").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("seleccionar").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("seleccionar").AllowRowFiltering = DefaultableBoolean.False

        grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.Caption = ""

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") = False And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") = False And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_OPERADOR") = False Then
        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Hidden = True
        'End If


        grid.DisplayLayout.Bands(0).Columns("Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        grid.DisplayLayout.Bands(0).Columns("Entrega").Header.Caption = "E"

        '  grid.DisplayLayout.Bands(0).Columns("MarcadoPrioridad").Header.Caption = "MP"
        'grid.DisplayLayout.Bands(0).Columns("MarcadoPrioridad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ' grid.DisplayLayout.Bands(0).Columns("MarcadoPrioridad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        If chkImpreso.Checked Then
            grid.DisplayLayout.Bands(0).Columns("I").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        If chkUrgente.Checked Then
            grid.DisplayLayout.Bands(0).Columns("U").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("EE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Status").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Status").Header.Caption = "ST"

        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOAPARTADO").Header.Caption = "B"

        grid.DisplayLayout.Bands(0).Columns("Prioridad").Header.Caption = "Prioridad"
        grid.DisplayLayout.Bands(0).Columns("Prioridad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prioridad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prioridad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("FolioApartado").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("FolioApartado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FolioApartado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "PedidoSAY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").Header.Caption = "PedidoSICY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").Header.Caption = "OrdenCte"
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("OrdenCliente").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FSolicitada").Header.Caption = "FSolicitada"
        grid.DisplayLayout.Bands(0).Columns("FSolicitada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FSolicitada").Format = "dd/MM/yyyy"
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            grid.DisplayLayout.Bands(0).Columns("FPreparacion").Header.Caption = "*FPreparación"
        Else
            grid.DisplayLayout.Bands(0).Columns("FPreparacion").Header.Caption = "FPreparación"
        End If
        grid.DisplayLayout.Bands(0).Columns("FPreparacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FPreparacion").Format = "dd/MM/yyyy"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Header.Caption = "Cantidad"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Confirmados"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PorConfirmar").Header.Caption = "PorConfirmar"
        grid.DisplayLayout.Bands(0).Columns("PorConfirmar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PorConfirmar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PorConfirmar").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cancelados").Header.Caption = "Cancelados"
        grid.DisplayLayout.Bands(0).Columns("Cancelados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cancelados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cancelados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Capturo").Header.Caption = "Capturó"
        grid.DisplayLayout.Bands(0).Columns("FCaptura").Header.Caption = "FCaptura"
        grid.DisplayLayout.Bands(0).Columns("FCaptura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FCaptura").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("Asignado").Header.Caption = "Asignado"
        grid.DisplayLayout.Bands(0).Columns("Confirmo").Header.Caption = "Confirmó"
        grid.DisplayLayout.Bands(0).Columns("FConfirmacion").Header.Caption = "FConfirmación"
        grid.DisplayLayout.Bands(0).Columns("FConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FConfirmacion").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("ConfirmoI").Header.Caption = "ConfirmóI"
        grid.DisplayLayout.Bands(0).Columns("ConfirmoI").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FConfIncom").Header.Caption = "FConfIncom"
        grid.DisplayLayout.Bands(0).Columns("FConfIncom").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FConfIncom").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("ObsConfIncom").Header.Caption = "Observación ConfIncom"
        grid.DisplayLayout.Bands(0).Columns("ObsConfIncom").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            grid.DisplayLayout.Bands(0).Columns("Observaciones").Header.Caption = "*Observaciones"
            grid.DisplayLayout.Bands(0).Columns("Observaciones").CharacterCasing = CharacterCasing.Upper
        Else
            grid.DisplayLayout.Bands(0).Columns("Observaciones").Header.Caption = "Observaciones"
        End If
        grid.DisplayLayout.Bands(0).Columns("Origen").Header.Caption = "Origen"
        grid.DisplayLayout.Bands(0).Columns("Cancelo").Header.Caption = "Canceló"
        grid.DisplayLayout.Bands(0).Columns("FCancelacion").Header.Caption = "FCancelación"
        grid.DisplayLayout.Bands(0).Columns("FCancelacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FCancelacion").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("MotivoCancelacion").Header.Caption = "Motivo Cancelación"

        If chkDetallada.Checked And cmbStatusApartados.SelectedIndex > 0 Then
            If cmbStatusApartados.SelectedValue <> 45 Then
                grid.DisplayLayout.Bands(0).Columns("Ubicación").Hidden = True
            End If
        End If
        grid.DisplayLayout.Bands(0).Columns("partidacompleta").Header.Caption = "PC"


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        grid.DisplayLayout.Bands(0).Columns("seleccionar").Width = 20
        grid.DisplayLayout.Bands(0).Columns("Entrega").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Status").Width = 25
        If chkImpreso.Checked Then
            grid.DisplayLayout.Bands(0).Columns("I").Width = 20
        End If
        If chkUrgente.Checked Then
            grid.DisplayLayout.Bands(0).Columns("U").Width = 20
        End If
        grid.DisplayLayout.Bands(0).Columns("EE").Width = 25
        grid.DisplayLayout.Bands(0).Columns("BLOQUEADOAPARTADO").Width = 25


        Dim summary1, summary2, summary3, summary4 As SummarySettings
        'Dim summary5 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cantidad"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Confirmados"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares por Confirmar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PorConfirmar"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Cancelados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cancelados"))
        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cantidad"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        'summary5.DisplayFormat = "{0:#,##0}"
        'summary5.Appearance.TextHAlign = HAlign.Right



        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            grid.DisplayLayout.Bands(0).Columns("FPreparacion").Style = ColumnStyle.DateWithoutDropDown
            grid.DisplayLayout.Bands(0).Columns("FPreparacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            grid.DisplayLayout.Bands(0).Columns("Observaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS_CANC_SOLO_ACTIVOS") Then
            cancelarSoloActivo = True
        End If
        Me.Close()
    End Sub

    Dim bandera As Integer = 0


    Private Sub gridApartados_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridApartados.InitializeRow
        If IsNothing(gridApartados.DataSource) = False Then

            If e.Row.Cells.Count > 0 Then
                If e.Row.Cells("EntregaTipo").Value = "3" Then
                    'e.Row.Cells("Entrega").Appearance.ForeColor = pnlAlMenos1DiaEntrega.BackColor
                    e.Row.Cells("Entrega").Appearance.BackColor = pnlAlMenos1DiaEntrega.BackColor
                ElseIf e.Row.Cells("EntregaTipo").Value = "4" Then
                    'e.Row.Cells("Entrega").Appearance.ForeColor = pnlEntregaVencida.BackColor
                    e.Row.Cells("Entrega").Appearance.BackColor = pnlEntregaVencida.BackColor
                ElseIf e.Row.Cells("EntregaTipo").Value = "2" Then
                    'e.Row.Cells("Entrega").Appearance.ForeColor = pnlEntregaVenceHoy.BackColor
                    e.Row.Cells("Entrega").Appearance.BackColor = pnlEntregaVenceHoy.BackColor
                ElseIf e.Row.Cells("EntregaTipo").Value = "1" Then
                    'e.Row.Cells("Entrega").Appearance.ForeColor = pnlEntregaInmediata.BackColor
                    e.Row.Cells("Entrega").Appearance.BackColor = pnlEntregaInmediata.BackColor
                    'e.Row.Cells("Entrega").Appearance.ForeColor = Color.White
                End If

                If e.Row.Cells("EstatusNombre").Value = "CANCELADO" Or e.Row.Cells("EstatusNombre").Value = "CONFIRMADO" Or e.Row.Cells("EstatusNombre").Value = "CONFIRMACIÓN INCOMPLETA" Then
                    e.Row.Cells("Entrega").Value = ""
                    e.Row.Cells("Entrega").Appearance.BackColor = Nothing
                End If

                If chkImpreso.Checked Then
                    If e.Row.Cells("Impreso").Value = "1" Then
                        e.Row.Cells("I").Value = "S"
                        'e.Row.Cells("I").Appearance.ForeColor = pnlImpreso.BackColor
                        e.Row.Cells("I").Appearance.BackColor = pnlImpreso.BackColor
                    End If
                End If

                If chkUrgente.Checked Then
                    If e.Row.Cells("Urgente").Value = "1" Then
                        e.Row.Cells("U").Value = "S"
                        'e.Row.Cells("U").Appearance.ForeColor = pnlUrgente.BackColor
                        e.Row.Cells("U").Appearance.BackColor = pnlUrgente.BackColor
                    End If
                End If

                If e.Row.Cells("MarcadoPrioridad").Value = "1" Then
                    e.Row.Cells("Prioridad").Appearance.BackColor = pnlPriorida1.BackColor
                End If

                If e.Row.Cells("EstatusNombre").Value = "ACTIVO" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusActivo.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusActivo.BackColor
                    e.Row.Cells("Status").Value = "ACT"
                ElseIf e.Row.Cells("EstatusNombre").Value = "CANCELADO" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusCancelado.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusCancelado.BackColor
                    e.Row.Cells("Status").Value = "CAN"
                ElseIf e.Row.Cells("EstatusNombre").Value = "CONFIRMADO" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusConfirmado.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusConfirmado.BackColor
                    e.Row.Cells("Status").Value = "CON"
                ElseIf e.Row.Cells("EstatusNombre").Value = "EN EJECUCIÓN" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusEnEjecucion.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusEnEjecucion.BackColor
                    e.Row.Cells("Status").Value = "EJE"
                ElseIf e.Row.Cells("EstatusNombre").Value = "PARCIALMENTE CONFIRMADO" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusParcialmenteConfirmado.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusParcialmenteConfirmado.BackColor
                    e.Row.Cells("Status").Value = "PAC"
                ElseIf e.Row.Cells("EstatusNombre").Value = "CONFIRMACIÓN INCOMPLETA" Then
                    e.Row.Cells("Status").Appearance.ForeColor = pnlEstatusConfirmacionIncompleta.BackColor
                    e.Row.Cells("Status").Appearance.BackColor = pnlEstatusConfirmacionIncompleta.BackColor
                    e.Row.Cells("Status").Value = "CONI"
                End If

                If e.Row.Cells("RequiereEtiqueta").Value = "1" Then
                    If e.Row.Cells("EtiquetaSolicitada").Value = "1" Then
                        e.Row.Cells("EE").Value = "S"
                        e.Row.Cells("EE").Appearance.BackColor = pnlEtiquetaSolicitada.BackColor
                    ElseIf e.Row.Cells("EtiquetaSolicitada").Value = "0" Then
                        e.Row.Cells("EE").Value = "N"
                        e.Row.Cells("EE").Appearance.BackColor = pnlEtiquetaNoSolicitada.BackColor
                    End If
                End If

                If e.Row.Cells("BLOQUEADOAPARTADOTIPO").Value <> "" Then
                    e.Row.Cells("BLOQUEADOAPARTADO").Appearance.BackColor = pnlClienteBloqueado.BackColor
                    e.Row.Cells("BLOQUEADOAPARTADO").Value = "S"
                    e.Row.Cells("Cliente").Appearance.ForeColor = Color.Red
                End If

                If e.Row.Cells("FPreparacion").Value = "01/01/1900" Or IsDate(e.Row.Cells("FPreparacion").Value) = False Then
                    'e.Row.Cells("FPreparacion").Appearance.BackColor = Color.White
                    'e.Row.Cells("FPreparacion").Appearance.ForeColor = Color.White
                    'e.Row.Cells("FPreparacion").Value = "01/01/0001"
                Else
                    e.Row.Cells("FPreparacion").Appearance.BackColor = Nothing
                    e.Row.Cells("FPreparacion").Appearance.ForeColor = Nothing
                End If

                If chkDetallada.Checked And chkVerUbicaciones.Checked Then
                    If e.Row.Cells("EstatusNombre").Value <> "ACTIVO" Then
                        e.Row.Cells("Ubicación").Value = ""
                    End If
                End If

            End If
        End If


    End Sub

    Private Sub gridApartados_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridApartados.SelectionDrag
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            Dim contador As Integer = 0
            Dim prioridadAnterior As Integer = 0
            ordenamientoParaModificarPrioridades = True
            Dim prioridadesMalOrdenadas As Integer = 0

            For Each renglon As UltraGridRow In gridApartados.Rows
                If Integer.Parse(renglon.Cells("Prioridad").Value.ToString()) > 0 Then
                    If contador = 0 Then
                        prioridadAnterior = Integer.Parse(renglon.Cells("Prioridad").Value.ToString())
                    End If
                    contador += 1
                    If Integer.Parse(renglon.Cells("Prioridad").Value.ToString()) <> contador Then
                        'If Integer.Parse(renglon.Cells("Prioridad").Value.ToString()) < prioridadAnterior Then
                        'ordenamientoParaModificarPrioridades = False
                        prioridadesMalOrdenadas += 1
                    End If
                End If

                If renglon.Selected Then
                    If Integer.Parse(renglon.Cells("Prioridad").Value.ToString()) > 0 And renglon.Cells("BLOQUEADOAPARTADO").Value.ToString() <> "S" Then
                        renglonArrastrable = 1
                    Else
                        renglonArrastrable = 0
                    End If
                End If
            Next

            If prioridadesMalOrdenadas > 0 Then
                ordenamientoParaModificarPrioridades = False
            End If

            If renglonArrastrable = 1 Then
                If chkDetallada.Checked = False And chkVerTallas.Checked = False Then
                    If ordenamientoParaModificarPrioridades Then
                        gridApartados.DoDragDrop(gridApartados.Selected.Rows, DragDropEffects.Move)
                    Else
                        show_message("AdvertenciaGrande", "Todos los apartados con prioridad deben estar visibles en pantalla y la lista debe estar ordenada por prioridad para poder hacer el reordenamiento")
                    End If
                Else
                    show_message("Advertencia", "Debe desmarcar las opciones ""Mostrar detalles del apartado"" y ""Ver tallas"" para realizar esta acción ")
                End If
            End If
        End If
    End Sub


    Private Sub gridApartados_DragOver(sender As Object, e As DragEventArgs) Handles gridApartados.DragOver
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            If renglonArrastrable = 1 Then
                e.Effect = DragDropEffects.Move
                Dim grid As UltraGrid = TryCast(sender, UltraGrid)
                Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

                If pointInGridCoords.Y < 20 Then
                    'Scroll up
                    Me.gridApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
                ElseIf pointInGridCoords.Y > grid.Height - 20 Then
                    'Scroll down
                    Me.gridApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
                End If
            End If
        End If
    End Sub

    Private Sub gridApartados_DragDrop(sender As Object, e As DragEventArgs) Handles gridApartados.DragDrop
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            If renglonArrastrable = 1 Then
                Try
                    Dim confirmacion As New confirmarFormGrande
                    Dim dropIndex As Integer

                    confirmacion.mensaje = "¿Está seguro que desea cambiar las prioridades de los apartados? (Este proceso puede hacer que varios apartados cambien de prioridad y una vez guardado no puede revertirse)"

                    'Get the position on the grid where the dragged row(s) are to be dropped. 
                    'get the grid coordinates of the row (the drop zone) 
                    Dim uieOver As UIElement = gridApartados.DisplayLayout.UIElement.ElementFromPoint(gridApartados.PointToClient(New Point(e.X, e.Y)))

                    'get the row that is the drop zone/or where the dragged row is to be dropped 
                    Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

                    If ugrOver IsNot Nothing Then
                        dropIndex = ugrOver.Index    'index/position of drop zone in grid 

                        'get the dragged row(s)which are to be dragged to another position in the grid 
                        Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
                        'get the count of selected rows and drop each starting at the dropIndex 
                        For Each aRow As UltraGridRow In SelRows
                            'move the selected row(s) to the drop zone 
                            If dropIndex >= 0 And dropIndex <> aRow.Index Then
                                If ordenamientoParaModificarPrioridades Then
                                    If aRow.Cells("Urgente").Value Then
                                        If gridApartados.Rows(dropIndex).Cells("Urgente").Value Then
                                            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                                                gridApartados.Rows.Move(aRow, dropIndex)
                                                reasignarPrioridades(sender, e)
                                            End If
                                        Else
                                            show_message("Advertencia", "Los apartados urgentes solo pueden cambiar de prioridad con otros apartados urgentes")
                                        End If
                                    Else
                                        If Integer.Parse(gridApartados.Rows(dropIndex).Cells("Prioridad").Value.ToString()) > 0 And gridApartados.Rows(dropIndex).Cells("Urgente").Value = False Then
                                            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                                                gridApartados.Rows.Move(aRow, dropIndex)
                                                reasignarPrioridades(sender, e)
                                            End If
                                        Else
                                            show_message("Advertencia", "Los apartados priorizados solo pueden cambiar de prioridad con otros apartados priorizados que no sean urgentes")
                                        End If
                                    End If
                                Else
                                    show_message("AdvertenciaGrande", "Todos los apartados con prioridad deben estar visibles en pantalla y la lista debe estar ordenada por prioridad para poder hacer el reordenamiento")

                                End If
                            End If
                        Next

                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub btnAsignarPrioridad_Click(sender As Object, e As EventArgs) Handles btnAsignarPrioridad.Click
        Dim ObjBu As New Negocios.ApartadosBU
        Dim dtResultadoPriorizacion As New DataTable
        Dim confirmacion As New ConfirmarForm
        Dim contador As Integer = 0
        Dim idApartadosSeleccionados As String = String.Empty
        Dim mensajeConfirmacion As String = String.Empty

        If chkDetallada.Checked Or chkVerTallas.Checked Then
            show_message("Advertencia", "Debe desmarcar las opciones ""Mostrar detalles del apartado"" y ""Ver tallas"" para realizar esta acción ")
        Else

            For Each renglon As UltraGridRow In gridApartados.Rows
                If CBool(renglon.Cells("seleccionar").Value) Then
                    If renglon.Cells("EstatusNombre").Value.ToString() = "ACTIVO" Then
                        If renglon.Cells("BLOQUEADOAPARTADO").Value <> "S" Then
                            If renglon.Cells("Prioridad").Value = 0 Then
                                If idApartadosSeleccionados <> "" Then
                                    idApartadosSeleccionados += ","
                                End If
                                idApartadosSeleccionados += renglon.Cells("FolioApartado").Value.ToString()
                                contador += 1
                            Else
                                show_message("Advertencia", "No puede priorizar apartados con prioridad asignada, para modificar prioridades arrastre los renglones de apartados a modificar hacia arriba en la lista")
                                Exit Sub
                            End If
                        Else
                            show_message("Advertencia", "Uno de los apartados seleccionados pertenece a un cliente bloqueado, para priorizar, desmarque todos los apartados de clientes bloqueados y vuelva a intentar")
                            Exit Sub
                        End If
                    Else
                        show_message("Advertencia", "Solo pueden priorizarse los apartados en status ""ACTIVO""")
                        Exit Sub
                    End If
                End If
            Next
            If contador = 1 Then
                mensajeConfirmacion = "¿Está seguro que desea priorizar el apartado seleccionado?"
            ElseIf contador > 1 Then
                mensajeConfirmacion = "¿Está seguro que desea priorizar los " + contador.ToString() + " apartados seleccionados?"
            End If

            If idApartadosSeleccionados <> "" Then

                confirmacion.mensaje = mensajeConfirmacion
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtResultadoPriorizacion = ObjBu.priorizarApartadosPrimeraVez(idApartadosSeleccionados)
                End If
                If dtResultadoPriorizacion.Rows.Count > 0 Then
                    If dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados") > 1 Then
                        show_message(dtResultadoPriorizacion.Rows(0).Item("tipoResultado"), "Se priorizaron " + dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados").ToString() + " apartados, recuerde verificar la fecha de preparación de los mismos")
                    Else
                        show_message(dtResultadoPriorizacion.Rows(0).Item("tipoResultado"), "Se priorizó " + dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados").ToString() + " apartado, recuerde verificar la fecha de preparación del mismo")
                    End If
                    btnAceptar_Click(sender, e)
                End If
            Else
                show_message("Advertencia", "Debe seleccionar al menos un apartado para priorizar")
            End If

        End If
    End Sub

    Private Sub btnMarcarUrgente_Click(sender As Object, e As EventArgs) Handles btnMarcarUrgente.Click
        Dim ObjBu As New Negocios.ApartadosBU
        Dim dtResultadoPriorizacion As New DataTable
        Dim contador As Integer = 0
        Dim idApartadosSeleccionados As String = String.Empty
        Dim mensajeConfirmacion As String = String.Empty
        Dim confirmacion As New confirmarFormGrande

        If chkDetallada.Checked Or chkVerTallas.Checked Then
            show_message("Advertencia", "Debe desmarcar las opciones ""Mostrar detalles del apartado"" y ""Ver tallas"" para realizar esta acción ")
        Else

            For Each renglon As UltraGridRow In gridApartados.Rows
                If CBool(renglon.Cells("seleccionar").Value) Then
                    If renglon.Cells("EstatusNombre").Value.ToString() = "ACTIVO" Then
                        If renglon.Cells("BLOQUEADOAPARTADO").Value <> "S" Then
                            If gridApartados.DisplayLayout.Bands(0).Columns.Exists("Urgente") Then
                                If renglon.Cells("Urgente").Value = False Then
                                    If idApartadosSeleccionados <> "" Then
                                        idApartadosSeleccionados += ","
                                    End If
                                    idApartadosSeleccionados += renglon.Cells("FolioApartado").Value.ToString()
                                    contador += 1
                                Else
                                    show_message("Advertencia", "Uno de los apartados seleccionados ya está marcado como urgente, para cambiarlo de prioridad debe arrastrar el renglón dentro de la lista")
                                    Exit Sub
                                End If
                            Else
                                show_message("Advertencia", "La opción ""Urgente"" debe estar activa para realizar esta acción.")
                                Exit Sub
                            End If

                        Else
                            show_message("Advertencia", "Uno de los apartados seleccionados pertenece a un cliente bloqueado, para marcar urgencias, desmarque todos los apartados de clientes bloqueados y vuelva a intentar")
                            Exit Sub
                        End If
                    Else
                        show_message("Advertencia", "Solo pueden marcarse como urgentes los apartados en status ""ACTIVO""")
                        Exit Sub
                    End If
                End If
            Next
            If contador = 1 Then
                mensajeConfirmacion = "¿Está seguro que desea marcar el apartado seleccionado como urgente? (Este proceso puede hacer que varios apartados cambien de prioridad y una vez guardado no puede revertirse)"
            ElseIf contador > 1 Then
                mensajeConfirmacion = "¿Está seguro que desea marcar los " + contador.ToString() + " apartados seleccionados como urgentes? (Este proceso puede hacer que varios apartados cambien de prioridad y una vez guardado no puede revertirse)"
            End If

            If idApartadosSeleccionados <> "" Then

                confirmacion.mensaje = mensajeConfirmacion
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtResultadoPriorizacion = ObjBu.priorizarApartadosUrgencias(idApartadosSeleccionados)
                End If
                If dtResultadoPriorizacion.Rows.Count > 0 Then
                    If dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados") > 1 Then
                        show_message(dtResultadoPriorizacion.Rows(0).Item("tipoResultado"), "Se marcaron " + dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados").ToString() + " apartados como urgentes, recuerde verificar la fecha de preparación de los mismos")
                    Else
                        show_message(dtResultadoPriorizacion.Rows(0).Item("tipoResultado"), "Se marcó " + dtResultadoPriorizacion.Rows(0).Item("apartadosPriorizados").ToString() + " apartado como urgente, recuerde verificar la fecha de preparación del mismo")
                    End If
                    btnAceptar_Click(sender, e)
                End If
            Else
                show_message("Advertencia", "Debe seleccionar al menos un apartado para marcar como urgente")
            End If

        End If

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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

    Public Sub reasignarPrioridades(ByVal sender As Object, ByVal e As EventArgs)
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoPriorizacion As DataTable
        Dim idsApartados As String = String.Empty
        Dim contador As Integer

        contador = 0

        For Each renglon As UltraGridRow In gridApartados.Rows
            If Integer.Parse(renglon.Cells("Prioridad").Value.ToString()) > 0 Then
                If idsApartados <> "" Then
                    idsApartados += ","
                End If
                idsApartados += renglon.Cells("FolioApartado").Value.ToString()
                contador += 1
            End If
        Next

        dtResultadoPriorizacion = objBu.priorizarNuevamenteApartados(idsApartados)

        show_message(dtResultadoPriorizacion.Rows(0).Item("tipoResultado"), dtResultadoPriorizacion.Rows(0).Item("mensajeResultado").ToString())
        btnAceptar_Click(sender, e)

    End Sub


    Private Sub gridApartados_CellListSelect(sender As Object, e As CellEventArgs) Handles gridApartados.CellListSelect
        'Dim ObjBu = New Negocios.ApartadosBU
        'Dim confirmacion As New Tools.ConfirmarForm
        'Dim dtResultado As New DataTable
        'contadorCambioFechaPreparacionApartado += 1
        'e.Cell.Value = e.Cell.Text
        'If e.Cell.Value = "01/01/1900" Then
        '    e.Cell.Appearance.BackColor = Color.White
        '    e.Cell.Appearance.ForeColor = Color.White
        'Else
        '    e.Cell.Appearance.BackColor = Nothing
        '    e.Cell.Appearance.ForeColor = Nothing
        'End If
        'confirmacion.mensaje = "¿Está seguro que desea cambiar la fecha de preparación del apartado #" + gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value.ToString() + " ? (Este cambio no puede ser revertido una vez guardado)"
        'If contadorCambioFechaPreparacionApartado = 4 Then
        '    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        dtResultado = ObjBu.editarDatosApartado(gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value, 1, e.Cell.Value.ToString(), 0)
        '        show_message(dtResultado.Rows(0).Item("tipoResultado").ToString(), dtResultado.Rows(0).Item("mensaje").ToString())
        '    End If
        'End If
        'If contadorCambioFechaPreparacionApartado = 4 Then
        '    contadorCambioFechaPreparacionApartado = 0
        'End If
        'If e.Cell.Value <> "01/01/1900" And e.Cell.Value <> Nothing Then
        'btnAceptar_Click(sender, e)
        'End If

    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = gridApartados
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns("seleccionar").Hidden = True
            End With
            If chkDetallada.Checked Then
                nombreDocumento = "\Apartados_Detalles"
            End If
            If chkVerTallas.Checked Then
                nombreDocumento = "\Apartados_Detalles_Tallas"
            End If
            If chkDetallada.Checked = False And chkVerTallas.Checked = False Then
                nombreDocumento = "\Apartados"
            End If


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        .Columns("seleccionar").Hidden = False
                    End With
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub gridApartados_CellChange(sender As Object, e As CellEventArgs) Handles gridApartados.CellChange
        'Dim ObjBu = New Negocios.ApartadosBU
        'Dim confirmacion As New Tools.ConfirmarForm
        'Dim dtResultado As New DataTable
        'Try
        '    If e.Cell.Column.Header.Caption = "*FPreparación" Then
        '        'e.Cell.Value = e.Cell.Text
        '        If IsDate(e.Cell.Text) And Date.Parse(e.Cell.Text) >= Date.Parse(Date.Now.ToShortDateString()) And Date.Parse(e.Cell.Text) <= Date.Now.AddYears(5) Then
        '            If gridApartados.Rows(e.Cell.Row.Index).Cells("Prioridad").Value > 0 And gridApartados.Rows(e.Cell.Row.Index).Cells("Status").Value = "ACT" Then
        '                If e.Cell.Text = "01/01/1900" Then
        '                    e.Cell.Appearance.BackColor = Color.White
        '                    e.Cell.Appearance.ForeColor = Color.White
        '                Else
        '                    e.Cell.Appearance.BackColor = Nothing
        '                    e.Cell.Appearance.ForeColor = Nothing
        '                End If
        '                confirmacion.mensaje = "¿Está seguro que desea cambiar la fecha de preparación del apartado #" + gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value.ToString() + " ? (Este cambio no puede ser revertido una vez guardado)"
        '                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                    dtResultado = ObjBu.editarDatosApartado(gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value, 1, e.Cell.Text.ToString(), 0, "")
        '                    show_message(dtResultado.Rows(0).Item("tipoResultado").ToString(), dtResultado.Rows(0).Item("mensaje").ToString())
        '                    btnAceptar_Click(sender, e)
        '                End If
        '            Else
        '                show_message("Advertencia", "La fecha no ha sido modificada. Solo se puede modificar la fecha solicitada a los apartados ""ACTIVOS"" y con prioridad asignada")
        '                btnAceptar_Click(sender, e)
        '            End If
        '        Else
        '            'If IsDate(e.Cell.Text) And Date.Parse(e.Cell.Text) <= Date.Now Then
        '            '    show_message("Advertencia", "Debe seleccionar una fecha mayor a la actual")
        '            'End If
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try

        ''If e.Cell.Value <> "01/01/1900" And e.Cell.Value <> Nothing Then
        ''btnAceptar_Click(sender, e)
        ''End If
    End Sub

    Private Sub gridApartados_MouseClick(sender As Object, e As MouseEventArgs) Handles gridApartados.MouseClick
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_OPERADOR") Then

            indiceRenglonApartadoSeleccionado = 0
            If e.Button = Windows.Forms.MouseButtons.Right Then
                cmsOpcionesAlmacen.Items(0).Visible = True
                cmsOpcionesAlmacen.Items(1).Visible = True
                cmsOpcionesAlmacen.Items(2).Visible = True

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_OPERADOR") Then
                    cmsOpcionesAlmacen.Items(1).Visible = False
                    cmsOpcionesAlmacen.Items(2).Visible = False
                End If

                Dim renglonesSeleccionados As Integer = 0
                Dim celdasSeleccionadas As Integer = 0
                For Each renglon As UltraGridRow In gridApartados.Rows
                    If renglon.Selected Then
                        renglonesSeleccionados += 1
                        indiceRenglonApartadoSeleccionado = renglon.Index
                    ElseIf renglon.Activated Then
                        For Each celda As UltraGridCell In renglon.Cells
                            If celda.Selected Then
                                celdasSeleccionadas += 1
                            End If
                        Next
                        If celdasSeleccionadas > 0 Then
                            indiceRenglonApartadoSeleccionado = renglon.Index
                        End If
                    End If
                Next

                'If renglonesSeleccionados = 1 Or celdasSeleccionadas > 0 Then
                '    If gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("RequiereEtiqueta").Value = False Or gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("EtiquetaSolicitada").Value = True Or gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("Status").Value = "CAN" Then
                '        cmsOpcionesAlmacen.Items(0).Visible = False
                '    End If
                '    If gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("Asignado").Value = "" Then
                '        cmsOpcionesAlmacen.Items(2).Visible = False
                '    Else
                '        cmsOpcionesAlmacen.Items(1).Visible = False
                '    End If

                '    If (gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("Urgente").Value <> "1" And gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("Status").Value <> "PAC") Or (gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("BLOQUEADOAPARTADO").Value = "S") Then
                '        cmsOpcionesAlmacen.Items(2).Visible = False
                '        cmsOpcionesAlmacen.Items(1).Visible = False
                '    End If
                If gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("EstatusNombre").Value <> "CANCELADO" Then
                    cmsOpcionesAlmacen.Show(Control.MousePosition)
                End If
                'End If
            End If
        End If
    End Sub

    Private Sub tsmiEtiquetaSolicitada_Click(sender As Object, e As EventArgs) Handles tsmiEtiquetaSolicitada.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ObjBU As New Negocios.ApartadosBU
        Dim dtResultadoActualizacion As DataTable
        Dim confirmacion As New Tools.ConfirmarForm

        confirmacion.mensaje = "¿Está seguro de que las etiquetas especiales han sido solicitadas o impresas? (Una vez marcadas como solicitadas o impresas no podrá revertirse este cambio)"
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            dtResultadoActualizacion = ObjBU.editarDatosApartado(gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("FolioApartado").Value, 4, "", 0, "", UsuarioModifico)
            show_message(dtResultadoActualizacion.Rows(0).Item("tipoResultado"), dtResultadoActualizacion.Rows(0).Item("mensaje").ToString())
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub tsmiDesasignarOperador_Click(sender As Object, e As EventArgs) Handles tsmiDesasignarOperador.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ObjBU As New Negocios.ApartadosBU
        Dim dtResultadoActualizacion As DataTable
        Dim confirmacion As New Tools.ConfirmarForm

        confirmacion.mensaje = "¿Seguro que desea desasignar el operador del apartado seleccionado? (Una vez desasignado no podrá revertirse este cambio)"
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            dtResultadoActualizacion = ObjBU.editarDatosApartado(gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("FolioApartado").Value, 2, "", 0, "", UsuarioModifico)
            show_message(dtResultadoActualizacion.Rows(0).Item("tipoResultado"), dtResultadoActualizacion.Rows(0).Item("mensaje").ToString())
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub tsmiAsignarOperador_Click(sender As Object, e As EventArgs) Handles tsmiAsignarOperador.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim listado As New ListadoParametrosApartadosForm
        Dim ObjBU As New Negocios.ApartadosBU
        Dim dtResultadoActualizacion As DataTable
        Dim confirmacion As New Tools.ConfirmarForm

        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        If listado.listParametros.Rows.Count > 1 Then
            show_message("Advertencia", "Seleccione solo un operador para asignarse a cada apartado")
        Else
            confirmacion.mensaje = "¿Está seguro que desea asignar el apartado #" + gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("FolioApartado").Value.ToString() + " al operador " + listado.listParametros.Rows(0).Item(2).ToString() + "?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtResultadoActualizacion = ObjBU.editarDatosApartado(gridApartados.Rows(indiceRenglonApartadoSeleccionado).Cells("FolioApartado").Value, 3, "", Integer.Parse(listado.listParametros.Rows(0).Item(0).ToString()), "", UsuarioModifico)
                show_message(dtResultadoActualizacion.Rows(0).Item("tipoResultado"), dtResultadoActualizacion.Rows(0).Item("mensaje").ToString())
                btnAceptar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblFechaUltimaActualización.Visible = False
        lblTextoUltimaActualizacion.Visible = False
        txtPedidoSAY.Text = ""
        txtPedidoSICY.Text = ""
        gridApartados.DataSource = Nothing
        grdPedidoSAY.DataSource = listInicial
        grdPedidoSICY.DataSource = listInicial
        grdFolioApartado.DataSource = listInicial
        grdCliente.DataSource = listInicial
        grdTienda.DataSource = listInicial
        grdMarca.DataSource = listInicial
        grdOperador.DataSource = listInicial
        grdColeccion.DataSource = listInicial
        grdModelo.DataSource = listInicial
        grdPiel.DataSource = listInicial
        grdColor.DataSource = listInicial
        grdCorrida.DataSource = listInicial
        chkUrgente.Checked = True
        chkImpreso.Checked = True
        chkVerTallas.Checked = False
        chkDetallada.Checked = False
        rdbFechaCaptura.Checked = True
        dtpFechaEntregaDel.Value = Date.Now
        dtpFechaEntregaAl.Value = Date.Now
        cmbOrigenApartado.SelectedIndex = 1
        cmbOrigenApartado.SelectedIndex = 0
        lblTextoApartadosCanceladosHoy.Visible = False
        lblTotalApartadosCanceladosHoy.Visible = False
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        If gridApartados.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            If chboxSeleccionarTodo.Checked Then
                For Each row As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
                    row.Cells("seleccionar").Value = True
                Next
            Else
                For Each row As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
                    row.Cells("seleccionar").Value = False
                Next
            End If
            Cursor = Cursors.Default
        Else
            chboxSeleccionarTodo.Checked = False
        End If
    End Sub

    Public Sub cargaApartadosCanceladosDia(ByVal tipoConsulta As Integer)
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objBu.consultaApartadosCanceladosDia(tipoConsulta)

        If tipoConsulta = 1 Then
            If dtResultadoConsulta.Rows.Count > 0 Then
                lblTotalApartadosCanceladosHoy.Text = dtResultadoConsulta.Rows(0).Item("TotalApartadosCanceladosDia").ToString()
                lblTextoApartadosCanceladosHoy.Visible = True
                lblTotalApartadosCanceladosHoy.Visible = True
            Else
                lblTextoApartadosCanceladosHoy.Visible = False
                lblTotalApartadosCanceladosHoy.Visible = False
            End If
        End If

    End Sub

    Private Sub btnImprimirApartado_Click(sender As Object, e As EventArgs) Handles btnImprimirApartado.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim apartadosSeleccionados As Integer = 0
        Dim idsApartadosSeleccionados As String = String.Empty
        Dim idApartado As String = String.Empty
        Dim objBu As New Negocios.ApartadosBU

        For Each renglon As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
            If CBool(renglon.Cells("seleccionar").Value) = True Or (renglon.Selected = True) Then
                apartadosSeleccionados += 1
                idApartado = renglon.Cells("FolioApartado").Value
                If idsApartadosSeleccionados = "" Then
                    idsApartadosSeleccionados += idApartado.ToString
                Else
                    idsApartadosSeleccionados += ", " + idApartado.ToString
                End If
            End If
        Next

        If apartadosSeleccionados > 0 Then
            Cursor = Cursors.WaitCursor
            imprimirApartado()
            objBu.editarDatosApartado(idsApartadosSeleccionados, 5, "", 0, "", UsuarioModifico)
            Cursor = Cursors.Default
            btnAceptar_Click(sender, e)
        Else
            show_message("Advertencia", "Debe seleccionar al menos un apartado para imprimir")
        End If

    End Sub

    Public Sub imprimirApartado()
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Dim dsOrdenesApartado As New DataSet("dsOrdenApartado")
        Dim Apartado As New DataTable("Apartado")
        Dim detalleApartado As New DataTable("DetalleApartado")
        Dim Corridas As New DataTable("Corrida")
        'Dim Tiendas As New DataTable("Tienda")
        Dim Tallas As New DataTable("Talla")
        Dim Talla1 As New DataTable("Talla1")
        Dim Talla2 As New DataTable("Talla2")
        Dim Talla3 As New DataTable("Talla3")
        Dim Talla4 As New DataTable("Talla4")
        Dim Talla5 As New DataTable("Talla5")
        Dim Talla6 As New DataTable("Talla6")
        Dim Talla7 As New DataTable("Talla7")
        Dim Talla8 As New DataTable("Talla8")
        Dim Talla9 As New DataTable("Talla9")
        Dim Talla10 As New DataTable("Talla10")
        Dim Talla11 As New DataTable("Talla11")
        Dim Talla12 As New DataTable("Talla12")
        Dim Talla13 As New DataTable("Talla13")
        Dim Talla14 As New DataTable("Talla14")
        Dim Talla15 As New DataTable("Talla15")
        Dim TallaBase As New DataTable("TallaBase")
        Dim obj As New Negocios.ApartadosBU
        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim idApartado As Integer = 0
        Dim apartadosSeleccionados As String = String.Empty

        Dim tallas1 As String = String.Empty
        Dim ApartadosTallas1 As String = String.Empty
        Dim CorridasTallas1 As String = String.Empty
        Dim tallas2 As String = String.Empty
        Dim ApartadosTallas2 As String = String.Empty
        Dim CorridasTallas2 As String = String.Empty
        Dim tallas3 As String = String.Empty
        Dim ApartadosTallas3 As String = String.Empty
        Dim CorridasTallas3 As String = String.Empty
        Dim tallas4 As String = String.Empty
        Dim ApartadosTallas4 As String = String.Empty
        Dim CorridasTallas4 As String = String.Empty
        Dim tallas5 As String = String.Empty
        Dim ApartadosTallas5 As String = String.Empty
        Dim CorridasTallas5 As String = String.Empty
        Dim tallas6 As String = String.Empty
        Dim ApartadosTallas6 As String = String.Empty
        Dim CorridasTallas6 As String = String.Empty
        Dim tallas7 As String = String.Empty
        Dim ApartadosTallas7 As String = String.Empty
        Dim CorridasTallas7 As String = String.Empty
        Dim tallas8 As String = String.Empty
        Dim ApartadosTallas8 As String = String.Empty
        Dim CorridasTallas8 As String = String.Empty
        Dim tallas9 As String = String.Empty
        Dim ApartadosTallas9 As String = String.Empty
        Dim CorridasTallas9 As String = String.Empty
        Dim tallas10 As String = String.Empty
        Dim ApartadosTallas10 As String = String.Empty
        Dim CorridasTallas10 As String = String.Empty
        Dim tallas11 As String = String.Empty
        Dim ApartadosTallas11 As String = String.Empty
        Dim CorridasTallas11 As String = String.Empty
        Dim tallas12 As String = String.Empty
        Dim ApartadosTallas12 As String = String.Empty
        Dim CorridasTallas12 As String = String.Empty
        Dim tallas13 As String = String.Empty
        Dim ApartadosTallas13 As String = String.Empty
        Dim CorridasTallas13 As String = String.Empty
        Dim tallas14 As String = String.Empty
        Dim ApartadosTallas14 As String = String.Empty
        Dim CorridasTallas14 As String = String.Empty
        Dim tallas15 As String = String.Empty
        Dim ApartadosTallas15 As String = String.Empty
        Dim CorridasTallas15 As String = String.Empty

        'With gridApartados
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With

        For Each renglon As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
            If CBool(renglon.Cells("seleccionar").Value) = True Or (renglon.Selected = True) Then
                idApartado = renglon.Cells("FolioApartado").Value
                If apartadosSeleccionados = "" Then
                    apartadosSeleccionados += idApartado.ToString
                Else
                    apartadosSeleccionados += ", " + idApartado.ToString
                End If
            End If
        Next

        detalleApartado = obj.imprimirOrdenApartado(apartadosSeleccionados, 2, False)
        detalleApartado.TableName = "DetalleApartado"
        Apartado = obj.imprimirOrdenApartado(apartadosSeleccionados, 1, False)
        Apartado.TableName = "Apartado"
        Corridas = obj.imprimirOrdenApartado(apartadosSeleccionados, 3, False)
        Corridas.TableName = "Corrida"
        'Tiendas = obj.imprimirOrdenApartado(apartadosSeleccionados, 5)
        'Tiendas.TableName = "Tienda"
        Tallas = obj.imprimirOrdenApartado(apartadosSeleccionados, 4, False)
        Tallas.TableName = "Talla"
        Dim contador = 0
        For Each renglon As DataRow In Tallas.Rows

            If contador <> 0 Then
                tallas1 += ","
                ApartadosTallas1 += ","
                CorridasTallas1 += ","
            End If
            tallas1 += "" + renglon.Item("Talla1") + ""
            ApartadosTallas1 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas1 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas2 += ","
                ApartadosTallas2 += ","
                CorridasTallas2 += ","
            End If
            tallas2 += "" + renglon.Item("Talla2") + ""
            ApartadosTallas2 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas2 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas3 += ","
                ApartadosTallas3 += ","
                CorridasTallas3 += ","
            End If
            tallas3 += "" + renglon.Item("Talla3") + ""
            ApartadosTallas3 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas3 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas4 += ","
                ApartadosTallas4 += ","
                CorridasTallas4 += ","
            End If
            tallas4 += "" + renglon.Item("Talla4") + ""
            ApartadosTallas4 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas4 += "" + renglon.Item("Corrida") + ""



            If contador <> 0 Then
                tallas5 += ","
                ApartadosTallas5 += ","
                CorridasTallas5 += ","
            End If
            tallas5 += "" + renglon.Item("Talla5") + ""
            ApartadosTallas5 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas5 += "" + renglon.Item("Corrida") + ""



            If contador <> 0 Then
                tallas6 += ","
                ApartadosTallas6 += ","
                CorridasTallas6 += ","
            End If
            tallas6 += "" + renglon.Item("Talla6") + ""
            ApartadosTallas6 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas6 += "" + renglon.Item("Corrida") + ""



            If contador <> 0 Then
                tallas7 += ","
                ApartadosTallas7 += ","
                CorridasTallas7 += ","
            End If
            tallas7 += "" + renglon.Item("Talla7") + ""
            ApartadosTallas7 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas7 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas8 += ","
                ApartadosTallas8 += ","
                CorridasTallas8 += ","
            End If
            tallas8 += "" + renglon.Item("Talla8") + ""
            ApartadosTallas8 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas8 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas9 += ","
                ApartadosTallas9 += ","
                CorridasTallas9 += ","
            End If
            tallas9 += "" + renglon.Item("Talla9") + ""
            ApartadosTallas9 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas9 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas10 += ","
                ApartadosTallas10 += ","
                CorridasTallas10 += ","
            End If
            tallas10 += "" + renglon.Item("Talla10") + ""
            ApartadosTallas10 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas10 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas11 += ","
                ApartadosTallas11 += ","
                CorridasTallas11 += ","
            End If
            tallas11 += "" + renglon.Item("Talla11") + ""
            ApartadosTallas11 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas11 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas12 += ","
                ApartadosTallas12 += ","
                CorridasTallas12 += ","
            End If
            tallas12 += "" + renglon.Item("Talla12") + ""
            ApartadosTallas12 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas12 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas13 += ","
                ApartadosTallas13 += ","
                CorridasTallas13 += ","
            End If
            tallas13 += "" + renglon.Item("Talla13") + ""
            ApartadosTallas13 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas13 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas14 += ","
                ApartadosTallas14 += ","
                CorridasTallas14 += ","
            End If
            tallas14 += "" + renglon.Item("Talla14") + ""
            ApartadosTallas14 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas14 += "" + renglon.Item("Corrida") + ""


            If contador <> 0 Then
                tallas15 += ","
                ApartadosTallas15 += ","
                CorridasTallas15 += ","
            End If
            tallas15 += "" + renglon.Item("Talla15") + ""
            ApartadosTallas15 += "" + renglon.Item("NumeroApartado").ToString() + ""
            CorridasTallas15 += "" + renglon.Item("Corrida") + ""

            contador += 1
        Next

        TallaBase = obj.imprimirOrdenApartadoTotalUbicacionTallas(",,,", ",,,", False, ",,,")


        If Replace(tallas1, ",", "") <> "" Then
            Talla1 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas1, tallas1, False, CorridasTallas1)
        Else
            Talla1 = TallaBase.Clone
        End If
        Talla1.TableName = "Talla1"

        If Replace(tallas2, ",", "") <> "" Then
            Talla2 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas2, tallas2, False, CorridasTallas2)
        Else
            Talla2 = TallaBase.Clone
        End If
        Talla2.TableName = "Talla2"

        If Replace(tallas3, ",", "") <> "" Then
            Talla3 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas3, tallas3, False, CorridasTallas3)
        Else
            Talla3 = TallaBase.Clone
        End If
        Talla3.TableName = "Talla3"

        If Replace(tallas4, ",", "") <> "" Then
            Talla4 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas4, tallas4, False, CorridasTallas4)
        Else
            Talla4 = TallaBase.Clone
        End If
        Talla4.TableName = "Talla4"

        If Replace(tallas5, ",", "") <> "" Then
            Talla5 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas5, tallas5, False, CorridasTallas5)
        Else
            Talla5 = TallaBase.Clone
        End If
        Talla5.TableName = "Talla5"

        If Replace(tallas6, ",", "") <> "" Then
            Talla6 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas6, tallas6, False, CorridasTallas6)
        Else
            Talla6 = TallaBase.Clone
        End If
        Talla6.TableName = "Talla6"

        If Replace(tallas7, ",", "") <> "" Then
            Talla7 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas7, tallas7, False, CorridasTallas7)
        Else
            Talla7 = TallaBase.Clone
        End If
        Talla7.TableName = "Talla7"

        If Replace(tallas8, ",", "") <> "" Then
            Talla8 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas8, tallas8, False, CorridasTallas8)
        Else
            Talla8 = TallaBase.Clone
        End If
        Talla8.TableName = "Talla8"

        If Replace(tallas9, ",", "") <> "" Then
            Talla9 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas9, tallas9, False, CorridasTallas9)
        Else
            Talla9 = TallaBase.Clone
        End If
        Talla9.TableName = "Talla9"

        If Replace(tallas10, ",", "") <> "" Then
            Talla10 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas10, tallas10, False, CorridasTallas10)
        Else
            Talla10 = TallaBase.Clone
        End If
        Talla10.TableName = "Talla10"

        If Replace(tallas11, ",", "") <> "" Then
            Talla11 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas11, tallas11, False, CorridasTallas11)
        Else
            Talla11 = TallaBase.Clone
        End If
        Talla11.TableName = "Talla11"

        If Replace(tallas12, ",", "") <> "" Then
            Talla12 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas12, tallas12, False, CorridasTallas12)
        Else
            Talla12 = TallaBase.Clone
        End If
        Talla12.TableName = "Talla12"

        If Replace(tallas13, ",", "") <> "" Then
            Talla13 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas13, tallas13, False, CorridasTallas13)
        Else
            Talla13 = TallaBase.Clone
        End If
        Talla13.TableName = "Talla13"

        If Replace(tallas14, ",", "") <> "" Then
            Talla14 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas14, tallas14, False, CorridasTallas14)
        Else
            Talla14 = TallaBase.Clone
        End If
        Talla14.TableName = "Talla14"

        If Replace(tallas15, ",", "") <> "" Then
            Talla15 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas15, tallas15, False, CorridasTallas15)
        Else
            Talla15 = TallaBase.Clone
        End If
        Talla15.TableName = "Talla15"
        dsOrdenesApartado.Tables.Add(Apartado)
        dsOrdenesApartado.Tables.Add(detalleApartado)
        dsOrdenesApartado.Tables.Add(Corridas)
        'dsOrdenesApartado.Tables.Add(Tiendas)
        dsOrdenesApartado.Tables.Add(Tallas)
        dsOrdenesApartado.Tables.Add(Talla1)
        dsOrdenesApartado.Tables.Add(Talla2)
        dsOrdenesApartado.Tables.Add(Talla3)
        dsOrdenesApartado.Tables.Add(Talla4)
        dsOrdenesApartado.Tables.Add(Talla5)
        dsOrdenesApartado.Tables.Add(Talla6)
        dsOrdenesApartado.Tables.Add(Talla7)
        dsOrdenesApartado.Tables.Add(Talla8)
        dsOrdenesApartado.Tables.Add(Talla9)
        dsOrdenesApartado.Tables.Add(Talla10)
        dsOrdenesApartado.Tables.Add(Talla11)
        dsOrdenesApartado.Tables.Add(Talla12)
        dsOrdenesApartado.Tables.Add(Talla13)
        dsOrdenesApartado.Tables.Add(Talla14)
        dsOrdenesApartado.Tables.Add(Talla15)

        EntidadReporte = objBU.LeerReporteporClave("ALM_APAR_ORDAPARTADO")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport
        reporte.Load(archivo)

        reporte.Compile()
        reporte.Dictionary.Clear()
        reporte.RegData(dsOrdenesApartado)
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

    Private Sub gridApartados_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridApartados.AfterCellUpdate
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ObjBu = New Negocios.ApartadosBU
        Dim confirmacion As New Tools.ConfirmarForm
        Dim dtResultado As New DataTable
        Try
            If e.Cell.Column.Header.Caption = "*Observaciones" Then
                If gridApartados.Rows(e.Cell.Row.Index).Cells("BLOQUEADOAPARTADO").Value <> "S" Then
                    If gridApartados.Rows(e.Cell.Row.Index).Cells("Prioridad").Value > 0 And gridApartados.Rows(e.Cell.Row.Index).Cells("Status").Value = "ACT" Then
                        confirmacion.mensaje = "¿Está seguro que desea cambiar las observaciones de preparación del apartado #" + gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value.ToString() + " ? (Este cambio no puede ser revertido una vez guardado)"
                        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            dtResultado = ObjBu.editarDatosApartado(gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value, 6, "", 0, gridApartados.Rows(e.Cell.Row.Index).Cells("Observaciones").Value.ToString(), UsuarioModifico)
                            show_message(dtResultado.Rows(0).Item("tipoResultado").ToString(), dtResultado.Rows(0).Item("mensaje").ToString())
                            btnAceptar_Click(sender, e)
                        End If
                    Else
                        show_message("Advertencia", "Solo se pueden modificar las observaciones a los apartados ""ACTIVOS"" y con prioridad asignada")
                        btnAceptar_Click(sender, e)
                    End If
                Else
                    show_message("Advertencia", "No es posible modificar las observaciones a los apartados de clientes bloqueados")
                    btnAceptar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            If e.Cell.Column.Header.Caption = "*FPreparación" Then
                'e.Cell.Value = e.Cell.Text
                If gridApartados.Rows(e.Cell.Row.Index).Cells("BLOQUEADOAPARTADO").Value <> "S" Then
                    If IsDate(e.Cell.Text) And Date.Parse(e.Cell.Text) >= Date.Parse(Date.Now.ToShortDateString()) And Date.Parse(e.Cell.Text) <= Date.Now.AddYears(5) Then
                        If gridApartados.Rows(e.Cell.Row.Index).Cells("Prioridad").Value > 0 And gridApartados.Rows(e.Cell.Row.Index).Cells("Status").Value = "ACT" Then
                            If e.Cell.Text = "01/01/1900" Then
                                e.Cell.Appearance.BackColor = Color.White
                                e.Cell.Appearance.ForeColor = Color.White
                            Else
                                e.Cell.Appearance.BackColor = Nothing
                                e.Cell.Appearance.ForeColor = Nothing
                            End If
                            confirmacion.mensaje = "¿Está seguro que desea cambiar la fecha de preparación del apartado # " + gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value.ToString() + " ? (Este cambio no puede ser revertido una vez guardado)"
                            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                                dtResultado = ObjBu.editarDatosApartado(gridApartados.Rows(e.Cell.Row.Index).Cells("FolioApartado").Value, 1, e.Cell.Text.ToString(), 0, "", UsuarioModifico)
                                show_message(dtResultado.Rows(0).Item("tipoResultado").ToString(), dtResultado.Rows(0).Item("mensaje").ToString())
                                btnAceptar_Click(sender, e)
                            End If
                        Else
                            show_message("Advertencia", "Solo se puede modificar la fecha solicitada a los apartados ""ACTIVOS"" y con prioridad asignada")
                            btnAceptar_Click(sender, e)
                        End If
                    Else
                        If IsDate(e.Cell.Text) And Date.Parse(e.Cell.Text) <= Date.Now Then
                            show_message("Advertencia", "Debe capturar una fecha mayor a la actual")
                        End If
                    End If
                Else
                    show_message("Advertencia", "No es posible modificar la fecha solicitada a los apartados de clientes bloqueados")
                    btnAceptar_Click(sender, e)
                End If

            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gridApartados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridApartados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If gridApartados.ActiveRow.Cells("Observaciones").Activated Then
                gridApartados.ActiveRow.Update()
            ElseIf gridApartados.ActiveRow.Cells("FPreparacion").Activated Then
                gridApartados.ActiveRow.Update()
            End If

        End If
    End Sub

    Private Sub AdministracionApartadosForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If ventanaAbierta = "Confirmacion" Or ventanaAbierta = "Cancelacion" Then
            Me.WindowState = 2
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub btnInventarioDisponible_Click(sender As Object, e As EventArgs) Handles btnInventarioDisponible.Click
        Cursor = Cursors.WaitCursor
        Dim inventarioDisponible As New Apartados_InventarioDisponible_Form()

        show_message("Advertencia", "Esta consulta puede tomar varios segundos en desplegarse.")
        Me.WindowState = 0
        inventarioDisponible.MdiParent = Me.MdiParent
        inventarioDisponible.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub chkVerUbicaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerUbicaciones.CheckedChanged
        If chkVerUbicaciones.Checked = True Then
            chkDetallada.Checked = True
        Else
            'chkDetallada.Checked = False
            'chkVerTallas.Checked = False
        End If
    End Sub

    Private Sub btnEtiquetas_Click(sender As Object, e As EventArgs) Handles btnEtiquetas.Click

        Dim form As New ImpresionEtiquetasApartadosForm
        Dim Apartados As String = String.Empty
        Dim ListClienteID As New List(Of Integer)
        Dim ApartadosBATTA As String = String.Empty
        '
        'CONFIRMADO

        If gridApartados.Rows.Count > 0 Then
            Dim FilasSeleccionadas = gridApartados.Rows.Where(Function(x) CBool(x.Cells("seleccionar").Value) = True)

            If FilasSeleccionadas.Count > 0 Then
                If cmbStatusApartados.Text = "CONFIRMADO" Then
                    'Dim DistinctCLientes = gridApartados.Rows.Where(Function(y) CBool(y.Cells("seleccionar").Value) = True).Select(Function(x) x.Cells("ClienteID")).ToList.Distinct

                    For Each Fila As UltraGridRow In FilasSeleccionadas
                        ListClienteID.Add(Fila.Cells("ClienteID").Value)
                    Next


                    If ListClienteID.Distinct.Count = 1 Then

                        For Each Fila As UltraGridRow In FilasSeleccionadas
                            If Fila.Cells("ClienteID").Value.ToString = "ClienteID" Then
                                If ApartadosBATTA = String.Empty Then
                                    ApartadosBATTA = Fila.Cells("FolioApartado").Value.ToString
                                Else
                                    ApartadosBATTA = ApartadosBATTA + "," + Fila.Cells("FolioApartado").Value.ToString
                                End If
                            Else
                                If Apartados = String.Empty Then
                                    Apartados = Fila.Cells("FolioApartado").Value.ToString
                                Else
                                    Apartados = Apartados + "," + Fila.Cells("FolioApartado").Value.ToString
                                End If
                            End If
                        Next

                        Dim Cliente = gridApartados.Rows.Where(Function(y) CBool(y.Cells("seleccionar").Value) = True).Select(Function(x) x.Cells("Cliente")).ToList.Distinct
                        Dim idCliente = gridApartados.Rows.Where(Function(y) CBool(y.Cells("seleccionar").Value) = True).Select(Function(x) x.Cells("ClienteID")).ToList.Distinct
                        Dim strCliente As String = Cliente(0).Value.ToString()
                        Dim ClienteID As Integer = idCliente(0).Value


                        form.CadenaApartados = Apartados
                        form.CadenaApartadosBatta = ApartadosBATTA
                        form.Cliente = strCliente
                        form.idCliente = ClienteID

                        form.ShowDialog()
                    Else
                        show_message("Advertencia", "Se deben seleccionar apartados de un solo cliente.")

                    End If

                Else
                    show_message("Advertencia", "Solo se pueden imprimir las etqiuetas de apartados confirmados.")
                End If
            Else
                show_message("Advertencia", "Debe existir al menos un fila seleccionada.")
            End If
        Else
            show_message("Advertencia", "No existen datos cargados en pantalla.")
        End If
    End Sub

    Private Sub lblActualizarDatos_Click(sender As Object, e As EventArgs) Handles lblActualizarDatos.Click

    End Sub
End Class