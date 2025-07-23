Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Threading
Imports Entidades

Public Class AdministradorPedidosVirtualesForm

    Dim pedido As Integer
    Dim objDA As New Negocios.PedidosVirtualesBU
    Dim alerta As Integer
    Dim PedidosAlerta As Integer = 0
    Dim departamento As Integer
    Dim contAlerta As Integer = 0

    Private Sub AdministradorPedidosVirtualesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        inicializarFormulario(False)
        hilo.RunWorkerAsync()
    End Sub

    Private Sub inicializarFormulario(ByVal bandera As Boolean)
        Dim listaclientes As New List(Of Entidades.Cliente)
        Dim listaestatus As New List(Of Entidades.PedidoVirtual)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_PEDVIRTUALES", "PV_VENTAS") Then
            btnAltas.Enabled = True
            btnConfirmar.Enabled = True
            btnPedidoReal.Enabled = True
            btnVincular.Enabled = True
            btnEditar.Enabled = True
            btnCancelarSalida.Enabled = True
            btnExportar.Enabled = True
            btnCerrar.Enabled = True
            btnLimpiar.Enabled = True
            btnMostrar.Enabled = True
            Consultafiltros()
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_PEDVIRTUALES", "PV_PPCP") Then
            btnAutorizar.Enabled = True
            btnEditar.Enabled = True
            btnCancelarSalida.Enabled = True
            btnExportar.Enabled = True
            btnCerrar.Enabled = True
            btnLimpiar.Enabled = True
            btnMostrar.Enabled = True
            Consultafiltros()
        End If
        listaclientes = objDA.ListaClientes
        If listaclientes.Count > 0 Then
            cmbClientes.DataSource = listaclientes
            cmbClientes.ValueMember = "clienteid"
            cmbClientes.DisplayMember = "nombregenerico"
        End If

        listaestatus = objDA.ListaEstatus
        If listaestatus.Count > 0 Then
            cmbEstatus.DataSource = listaestatus
            cmbEstatus.ValueMember = "estatusid"
            cmbEstatus.DisplayMember = "estatus"
        End If

        dtpCapturaAl.Value = Now.Date
        dtpCapturaDel.Value = Now.Date
        dtpProgramacionAl.Value = Now.Date
        dtpProgramacionDel.Value = Now.Date
        dtpSolicitadaAl.Value = Now.Date
        dtpSolicitadaDel.Value = Now.Date
        contAlerta = 1
    End Sub

    Private Sub pintarGrid()
        Dim bandera As Boolean = True
        grdPedidosVirtuales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        With grdPedidosVirtuales.DisplayLayout.Bands(0)

            .Columns("MotivoC").Header.Caption = "Motivo Cancelación"

            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Pedido").CellActivation = Activation.NoEdit
            .Columns("OrdenCliente").CellActivation = Activation.NoEdit
            .Columns("Tipo").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Pares").CellActivation = Activation.NoEdit
            .Columns("FCaptura").CellActivation = Activation.NoEdit
            .Columns("FSolicita").CellActivation = Activation.NoEdit
            .Columns("FProgr").CellActivation = Activation.NoEdit
            .Columns("SemProgr").CellActivation = Activation.NoEdit
            .Columns("FCancelación").CellActivation = Activation.NoEdit
            .Columns("MotivoC").CellActivation = Activation.NoEdit
            .Columns("FModificación").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("Observaciones").CellActivation = Activation.NoEdit

            .Columns("idCliente").Hidden = bandera
            .Columns("idTipo").Hidden = bandera
            .Columns("idEstatus").Hidden = bandera
            .Columns("lista").Hidden = bandera
            .Columns("idlista").Hidden = bandera

            .Columns("Seleccion").Width = 45
            .Columns("Cliente").Width = 300
            .Columns("Pedido").Width = 50
            .Columns("OrdenCliente").Width = 100
            .Columns("Tipo").Width = 180
            .Columns("Estatus").Width = 100
            .Columns("Pares").Width = 50
            .Columns("SemProgr").Width = 70
            .Columns("FCaptura").Width = 150
            .Columns("FModificación").Width = 150
            .Columns("FCancelación").Width = 150
            .Columns("MotivoC").Width = 250
            .Columns("Usuario").Width = 80
            .Columns("Observaciones").Width = 400

            .Columns("Seleccion").Header.Caption = ""
            .Columns("Estatus").Header.Caption = "Status"
            .Columns("FCaptura").Format = "dd/MM/yyyy hh:mm:ss tt"
            .Columns("FModificación").Format = "dd/MM/yyyy hh:mm:ss tt"
            .Columns("FCancelación").Format = "dd/MM/yyyy hh:mm:ss tt"
            .Columns("Pares").Format = "#,###"
            .Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With
        grdPedidosVirtuales.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdPedidosVirtuales.DisplayLayout.GroupByBox.Hidden = False
        grdPedidosVirtuales.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
    End Sub

    Private Sub SeleccionarRegistros()
        Dim contadorSeleccion As Int32 = 0

        For Each rowGR As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
            rowGR.Cells("Seleccion").Value = chkSeleccionar.Checked
            contadorSeleccion += 1
        Next

        If chkSeleccionar.Checked = False Then
            contadorSeleccion = 0
        End If

        lblPedidosContados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub seleccionarRegistroTabla(e As CellEventArgs)
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdPedidosVirtuales.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = False Then
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If

            If CBool(e.Cell.Text) = True Then
                lblPedidosContados.Text = CInt(lblPedidosContados.Text) + 1
            Else
                lblPedidosContados.Text = CInt(lblPedidosContados.Text) - 1
            End If
        End If
    End Sub

    Private Sub editarPedido()
        Dim pedidoVirtual As Entidades.PedidoVirtual
        Dim estatus As Integer

        If CInt(lblPedidosContados.Text) > 1 Then
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Solo se puede editar un pedido a la vez"
            confirmar.ShowDialog()
        ElseIf CInt(lblPedidosContados.Text) = 1 Then
            For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    estatus = CInt(row.Cells("idEstatus").Value)
                    If estatus = 42 And departamento = 43 Then
                        Dim confirmar As New AdvertenciaForm
                        confirmar.mensaje = "El pedido esta Autorizado y no se puede editar"
                        confirmar.ShowDialog()
                        Exit Sub
                    ElseIf estatus = 40 Or estatus = 41 Or estatus = 42 Then
                        Dim Formulario As New PedidoVirtualForm
                        pedidoVirtual = New Entidades.PedidoVirtual
                        Dim cliente As New Entidades.Cliente
                        Dim lista As New Entidades.ListaBase

                        pedidoVirtual.id = CInt(row.Cells("Pedido").Value)
                        cliente.clienteid = row.Cells("idCliente").Value
                        cliente.nombregenerico = row.Cells("Cliente").Value
                        pedidoVirtual.cliente = cliente
                        pedidoVirtual.FechasolicitadaCliente = row.Cells("FSolicita").Value
                        pedidoVirtual.orden = row.Cells("OrdenCliente").Value
                        lista.PListaBaseId = row.Cells("idlista").Value
                        lista.PListaBaseNombre = row.Cells("lista").Value
                        pedidoVirtual.listaVentas = lista
                        pedidoVirtual.tipo = row.Cells("Tipo").Value
                        pedidoVirtual.tipoid = row.Cells("idTipo").Value
                        pedidoVirtual.estatusid = estatus
                        pedidoVirtual.estatus = row.Cells("Estatus").Value
                        pedidoVirtual.observaciones = row.Cells("Observaciones").Value
                        pedidoVirtual.cantidadpares = row.Cells("Pares").Text
                        If Not IsDBNull(row.Cells("FProgr").Value) Then
                            pedidoVirtual.fechaEntregaProg = row.Cells("FProgr").Value
                        End If


                        Formulario.operacion = "Editar"
                        Formulario.pedido = pedidoVirtual
                        Formulario.departamento = departamento
                        Formulario.MdiParent = MdiParent
                        Me.Enabled = False
                        Formulario.admin = Me
                        Formulario.Show()
                        SeleccionarRegistros()
                        Exit For
                    Else
                        Dim confirmar As New AdvertenciaForm
                        confirmar.mensaje = "El estatus del pedido no admite que se edite"
                        confirmar.ShowDialog()
                        SeleccionarRegistros()
                    End If
                End If
            Next
        Else
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar un pedido"
            confirmar.ShowDialog()
        End If
    End Sub

    Private Sub verPedido(e As DoubleClickRowEventArgs)
        Dim pedidoVirtual As Entidades.PedidoVirtual
        Dim Formulario As New PedidoVirtualForm
        Dim cliente As New Entidades.Cliente
        Dim lista As New Entidades.ListaBase


        pedidoVirtual = New Entidades.PedidoVirtual
        pedidoVirtual.id = CInt(e.Row.Cells("Pedido").Value)
        cliente.clienteid = e.Row.Cells("idCliente").Value
        cliente.nombregenerico = e.Row.Cells("Cliente").Value
        pedidoVirtual.cliente = cliente
        pedidoVirtual.FechasolicitadaCliente = e.Row.Cells("FSolicita").Value
        pedidoVirtual.orden = e.Row.Cells("OrdenCliente").Value
        lista.PListaBaseId = e.Row.Cells("idlista").Value
        lista.PListaBaseNombre = e.Row.Cells("lista").Value
        pedidoVirtual.listaVentas = lista
        pedidoVirtual.tipo = e.Row.Cells("Tipo").Value
        pedidoVirtual.tipoid = e.Row.Cells("idTipo").Value
        pedidoVirtual.estatusid = e.Row.Cells("idEstatus").Value
        pedidoVirtual.estatus = e.Row.Cells("Estatus").Value
        pedidoVirtual.observaciones = e.Row.Cells("Observaciones").Value
        pedidoVirtual.cantidadpares = e.Row.Cells("Pares").Value
        If Not IsDBNull(e.Row.Cells("FProgr").Value) Then
            pedidoVirtual.fechaEntregaProg = e.Row.Cells("FProgr").Value
        End If

        Formulario.operacion = "Ver"
        Formulario.pedido = pedidoVirtual
        Formulario.departamento = departamento
        Formulario.MdiParent = MdiParent
        Me.Enabled = False
        Formulario.admin = Me
        Formulario.Show()
    End Sub

    Private Sub exportarExcel()
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                grdPedidosVirtuales.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.grdPedidosVirtuales, .SelectedPath + "\PedidosVirtuales_" + fecha_hora + ".xlsx")
                grdPedidosVirtuales.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = False
            End If
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Los datos se exportaron correctamente"
            mensajeExito.ShowDialog()
            .Dispose()

        End With
    End Sub

    Private Sub altas()
        Dim PedidoVirtual As New PedidoVirtualForm
        PedidoVirtual.operacion = "Alta"
        PedidoVirtual.MinimizeBox = False
        PedidoVirtual.MdiParent = MdiParent
        PedidoVirtual.departamento = departamento
        Me.Enabled = False
        PedidoVirtual.admin = Me
        PedidoVirtual.Show()
    End Sub

    Public Sub Consultafiltros()
        Dim fechaCapturaInicio As Date = Now.Date
        Dim fechaCapturaFin As Date = Now.Date
        Dim fechaSolicitadaInicio As Date = Now.Date
        Dim fechaSolicitadaFin As Date = Now.Date
        Dim fechaProgramacionInicio As Date = Now.Date
        Dim fechaProgramacionFin As Date = Now.Date
        Dim clienteid, estatusid, captura, solicita, programa As Int32
        Dim cliente As Entidades.Cliente
        Dim estatus As Entidades.PedidoVirtual
        Dim tablaAlertas As DataTable
        Dim form As New AvisoForm

        lblPedidosContados.Text = 0
        chkSeleccionar.Checked = False

        If chkCaptura.Checked Then
            fechaCapturaInicio = dtpCapturaDel.Value
            fechaCapturaFin = dtpCapturaAl.Value
            captura = 1
        Else
            captura = 0
        End If

        If chkSolicitadaCliente.Checked Then
            fechaSolicitadaInicio = dtpSolicitadaDel.Value.ToShortDateString
            fechaSolicitadaFin = dtpSolicitadaAl.Value.ToShortDateString
            solicita = 1
        Else
            solicita = 0
        End If

        If chkProgramacioin.Checked Then
            fechaProgramacionInicio = dtpProgramacionDel.Value
            fechaProgramacionFin = dtpProgramacionAl.Value
            programa = 1
        Else
            programa = 0
        End If

        If cmbEstatus.SelectedValue > 0 Then
            estatus = cmbEstatus.SelectedItem
            estatusid = estatus.estatusid
        Else
            estatusid = 0
        End If

        If chkAlerta.Checked Then
            alerta = 1
            estatusid = 0
        Else
            alerta = 0
        End If

        If cmbClientes.SelectedValue > 0 Then
            cliente = cmbClientes.SelectedItem
            clienteid = cliente.clienteid
        Else
            clienteid = 0
        End If

        tablaAlertas = objDA.ListaPedidosVirtuales(fechaCapturaInicio, fechaCapturaFin, fechaSolicitadaInicio, fechaSolicitadaFin, fechaProgramacionInicio, fechaProgramacionFin, alerta, clienteid, estatusid, captura, solicita, programa)
        If tablaAlertas.Rows.Count > 0 Then
            For Each row As DataRow In tablaAlertas.Rows
                If Not IsDBNull(row.Item("FProgr")) Then
                    row.Item("SemProgr") = "S " & DatePart("ww", CDate(row.Item("FProgr"))) & "-" & CDate(row.Item("FProgr")).Year
                End If
            Next
            grdPedidosVirtuales.DataSource = Nothing
            grdPedidosVirtuales.DataSource = tablaAlertas
            pintarGrid()

            'If alerta = 1 Then
            PedidosAlerta = 0
            For Each row As UltraGridRow In grdPedidosVirtuales.Rows
                'compara el estatus, si es autorizado compara las fechas de programacion
                'si la fecha esta en los prox 7 dias, pinta el renglon de rojo
                If row.Cells("idEstatus").Value = 42 Then
                    If Not IsDBNull(row.Cells("FProgr").Value) Then
                        If row.Cells("FProgr").Value >= Now.Date And row.Cells("FProgr").Value <= (Now.AddDays(7).Date) Then
                            row.CellAppearance.ForeColor = Color.Red
                            PedidosAlerta += 1
                        End If
                    Else

                    End If
                End If
            Next
            lblPedidosAlerta.Text = PedidosAlerta
            lblFechaConsulta.Text = "Ultima Actualización: " + Now.ToString
        Else
            If contAlerta > 0 Then
                grdPedidosVirtuales.DataSource = Nothing
                form.mensaje = "No se encontraron resultados con los criterios de búsqueda"
                form.ShowDialog()
            End If
        End If
    End Sub

    Private Sub limpiar()
        grdPedidosVirtuales.DataSource = Nothing
        cmbClientes.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        chkAlerta.Checked = False
        chkCaptura.Checked = False
        chkProgramacioin.Checked = False
        chkSeleccionar.Checked = False
        chkSolicitadaCliente.Checked = False
        lblPedidosContados.Text = "0"
        PedidosAlerta = 0
        lblPedidosAlerta.Text = PedidosAlerta
    End Sub

    Private Sub confirmarPedido()
        Dim pedidoVirtual As Entidades.PedidoVirtual
        Dim estatus As Integer
        Dim pedidos As String = ""
        Dim pedidosNo As String = ""

        If CInt(lblPedidosContados.Text) > 0 Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de confirmar el pedido virtual? (Una vez realizada esta acción no se podrá revertir)"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                    If row.Cells("Seleccion").Value Then
                        estatus = CInt(row.Cells("idEstatus").Value)
                        If estatus = 40 Then
                            pedidoVirtual = New Entidades.PedidoVirtual
                            pedidoVirtual.id = CInt(row.Cells("Pedido").Value)
                            pedidos += pedidoVirtual.id & ","
                            objDA.ConfirmarPedido(pedidoVirtual.id, SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Else
                            pedidosNo += row.Cells("Pedido").Value & ", "
                        End If
                    End If
                Next
                If pedidos <> "" Then
                    Dim exito As New ExitoForm
                    exito.mensaje = "Se confirmaron con éxito los pedidos " & pedidos
                    exito.ShowDialog()
                End If
                If pedidosNo <> "" Then
                    Dim aviso As New AdvertenciaForm
                    aviso.mensaje = "El(Los) pedido(s) " & pedidosNo.Substring(0, pedidosNo.Length - 2) & " no se puede(n) confirmar"
                    aviso.ShowDialog()
                End If
                chkSeleccionar.Checked = False
                SeleccionarRegistros()
                Consultafiltros()
            End If
        Else
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar minimo un pedido"
            confirmar.ShowDialog()
        End If
    End Sub

    Private Sub autorizarPedido()
        Dim pedidoVirtual As Entidades.PedidoVirtual
        Dim estatus As Integer
        Dim pedidos As String = ""
        Dim pedidosNoAut As String = ""

        If CInt(lblPedidosContados.Text) > 0 Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de autorizar el pedido virtual? (Una vez realizada esta acción no se podrá revertir)"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                    If row.Cells("Seleccion").Value Then
                        estatus = CInt(row.Cells("idEstatus").Value)
                        If estatus = 41 Then
                            pedidoVirtual = New Entidades.PedidoVirtual
                            pedidoVirtual.id = CInt(row.Cells("Pedido").Value)
                            pedidos += pedidoVirtual.id & ","
                            objDA.AutorizarPedido(pedidoVirtual.id, SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Else
                            pedidosNoAut += row.Cells("Pedido").Value & ", "
                        End If
                    End If
                Next

                If pedidos <> "" Then
                    Dim exito As New ExitoForm
                    exito.mensaje = "Se autorizaron con éxito los pedidos " & pedidos
                    exito.ShowDialog()
                    Dim sender As New Object, e As New EventArgs
                    btnMostrar_Click(sender, e)
                End If

                If pedidosNoAut <> "" Then
                    Dim aviso As New AdvertenciaForm
                    aviso.mensaje = "El(Los) pedido(s) " & pedidosNoAut.Substring(0, pedidosNoAut.Length - 2) & " no se puede(n) autorizar"
                    aviso.ShowDialog()
                    SeleccionarRegistros()
                End If
            End If
        Else
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar minimo un pedido"
            confirmar.ShowDialog()
        End If
    End Sub

    Private Sub cancelarPedido()
        Dim pedidos As String = ""
        Dim estatus As Integer
        Dim renglon As DataRow
        Dim tabla As New DataTable
        Dim pedidosNoAut As String = ""

        If CInt(lblPedidosContados.Text) > 0 Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cancelar el pedido virtual? (Una vez realizada esta acción no se podrá revertir)"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                tabla.Columns.Add("Pedido")
                tabla.Columns.Add("Cliente")
                tabla.Columns.Add("Orden Cliente")
                tabla.Columns.Add("Tipo Pedido")
                tabla.Columns.Add("Estatus")
                tabla.Columns.Add("Fecha Solicitada") ', Type.GetType("System.date"))
                tabla.Columns.Add("Fecha Programación") ', Type.GetType("System.date"))
                tabla.Columns.Add("Pares", Type.GetType("System.Int32"))
                tabla.Columns.Add("Observaciones")
                tabla.Columns.Add("idCliente")
                tabla.Columns.Add("idlista")
                tabla.Columns.Add("idTipo")
                tabla.Columns.Add("idEstatus")

                For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                    If row.Cells("Seleccion").Value Then
                        estatus = CInt(row.Cells("idEstatus").Value)
                        If estatus = 40 Or estatus = 41 Or estatus = 42 Then
                            renglon = tabla.NewRow()

                            renglon.Item(0) = row.Cells("Pedido").Value
                            renglon.Item(1) = row.Cells("Cliente").Value
                            renglon.Item(2) = row.Cells("OrdenCliente").Value
                            renglon.Item(3) = row.Cells("Tipo").Value
                            renglon.Item(4) = row.Cells("Estatus").Value
                            renglon.Item(5) = row.Cells("FSolicita").Text
                            renglon.Item(6) = row.Cells("FProgr").Text
                            renglon.Item(7) = row.Cells("Pares").Value
                            renglon.Item(8) = row.Cells("Observaciones").Value
                            renglon.Item(9) = row.Cells("idCliente").Value
                            renglon.Item(10) = row.Cells("idlista").Value
                            renglon.Item(11) = row.Cells("idTipo").Value
                            renglon.Item(12) = row.Cells("idEstatus").Value

                            tabla.Rows.Add(renglon)
                        Else
                            pedidosNoAut += row.Cells("Pedido").Value & ", "
                        End If
                    End If
                Next
                If pedidosNoAut <> "" Then
                    Dim aviso As New AdvertenciaForm
                    aviso.mensaje = "El(Los) pedido(s) " & pedidosNoAut.Substring(0, pedidosNoAut.Length - 2) & " no se puede(n) cancelar"
                    aviso.ShowDialog()
                End If
                chkSeleccionar.Checked = False
                SeleccionarRegistros()

                If tabla.Rows.Count > 0 Then
                    Dim formulario As New CancelacionPedidoVirtualForm
                    formulario.tabla = tabla
                    formulario.MdiParent = Me.MdiParent
                    Me.Enabled = False
                    formulario.admin = Me
                    formulario.Show()
                    formulario.WindowState = FormWindowState.Normal
                End If
            End If
        Else
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar minimo un pedido"
            confirmar.ShowDialog()
        End If
    End Sub

    Private Sub convertirPedidoReal()
        Dim estatus, tipoPedido, pedido, lista As Integer
        Dim confirmar As New confirmarFormGrande
        Dim mensaje As String = ""
        Dim aviso As New AdvertenciaFormGrande
        Dim tablaArticulos As New DataTable, agentes As DataTable, pedidoReal As DataTable
        Dim detallesPedido As String = "", pedidosReales As String = ""
        Dim contador As Integer

        If CInt(lblPedidosContados.Text) > 1 Then
            aviso.mensaje = "Solo se puede convertir a pedido real un pedido virtual a la vez"
            aviso.ShowDialog()
        ElseIf CInt(lblPedidosContados.Text) = 1 Then
            For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    estatus = CInt(row.Cells("idEstatus").Value)
                    tipoPedido = CInt(row.Cells("idTipo").Value)
                    If (estatus = 40 Or estatus = 41 Or estatus = 42) And tipoPedido = 3 Then
                        mensaje = "¿Está seguro de convertir el pedido virtual #" & row.Cells("Pedido").Value & " a pedido real?"
                        mensaje += "     (Se generará un pedido en SAY con status ABIERTO, deberá capturar los datos faltantes en el pedido real en SAY WEB."
                        mensaje += " Una vez realizada esta acción no se podrá revertir)"
                        confirmar.mensaje = mensaje
                        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                            pedido = CInt(row.Cells("Pedido").Value)
                            lista = CInt(row.Cells("idlista").Value)
                            tablaArticulos = objDA.ObtenerDetalleArticulos(pedido, tipoPedido, lista, estatus)
                            agentes = objDA.BuscarAgentes(pedido)

                            For Each age As DataRow In agentes.Rows
                                contador = 0
                                detallesPedido = ""
                                For Each renglon As DataRow In tablaArticulos.Rows
                                    If CInt(renglon.Item("Agente").ToString) = CInt(age.Item("Agente").ToString) Then
                                        detallesPedido += renglon.Item("IDdetalle").ToString + ", "
                                        contador += 1
                                    End If
                                Next
                                objDA.convertirPedidoReal(pedido, CInt(age.Item("Agente").ToString), SesionUsuario.UsuarioSesion.PUserUsuarioid, contador, detallesPedido.Substring(0, detallesPedido.Length - 2))
                            Next
                            Dim exito As New ExitoForm
                            pedidosReales = objDA.obtenerPedidosRealesConvertidos(pedido)
                            exito.mensaje = "Se generaron los pedidos #" + pedidosReales.Substring(0, pedidosReales.Length - 1) + " en SAY WEB, de pedido virtual #" + pedido.ToString
                            exito.ShowDialog()
                            Consultafiltros()
                        End If
                    Else
                        aviso.mensaje = "El pedido " & row.Cells("Pedido").Value & " no se puede convertir a pedido real, su estatus debe ser CAPTURADO, CONFIRMADO O AUTORIZADO, y debe ser de tipo PEDIDO NO CONFIRMADO"
                        aviso.ShowDialog()
                    End If
                    Exit Sub
                End If
            Next
        Else
            aviso.mensaje = "Debe seleccionar un pedido"
            aviso.ShowDialog()
        End If
    End Sub

    Private Sub vincularPedidos()
        Dim pedidoVirtual As Entidades.PedidoVirtual
        Dim estatus As Integer
        Dim aviso As New AdvertenciaForm
        Dim cliente As New Entidades.Cliente

        If CInt(lblPedidosContados.Text) > 1 Then
            aviso.mensaje = "Solo se puede vincular un pedido virtual a la vez"
            aviso.ShowDialog()
        ElseIf CInt(lblPedidosContados.Text) = 1 Then
            For Each row As UltraGridRow In grdPedidosVirtuales.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    estatus = CInt(row.Cells("idEstatus").Value)
                    If (estatus <> 43) Then
                        Dim Formulario As New VincularPedidoVirtualconRealForm
                        pedidoVirtual = New Entidades.PedidoVirtual

                        pedidoVirtual.id = CInt(row.Cells("Pedido").Value)
                        cliente.clienteid = row.Cells("idCliente").Value
                        cliente.nombregenerico = row.Cells("Cliente").Value
                        pedidoVirtual.cliente = cliente
                        pedidoVirtual.FechasolicitadaCliente = row.Cells("FSolicita").Value
                        pedidoVirtual.orden = row.Cells("OrdenCliente").Value
                        pedidoVirtual.tipo = row.Cells("Tipo").Value
                        pedidoVirtual.tipoid = row.Cells("idTipo").Value
                        pedidoVirtual.estatusid = estatus
                        pedidoVirtual.estatus = row.Cells("Estatus").Value
                        pedidoVirtual.observaciones = row.Cells("Observaciones").Value
                        pedidoVirtual.cantidadpares = row.Cells("Pares").Value
                        If Not IsDBNull(row.Cells("FProgr").Value) Then
                            pedidoVirtual.fechaEntregaProg = row.Cells("FProgr").Value
                        End If

                        Formulario.pedido = pedidoVirtual
                        Formulario.MdiParent = MdiParent
                        Me.Enabled = False
                        Formulario.admin = Me
                        Formulario.Show()
                        SeleccionarRegistros()
                        Exit For
                    Else
                        aviso.mensaje = "El pedido virtual  " & row.Cells("Pedido").Value & " no se puede vincular a un pedido real porque esta CANCELADO"
                        aviso.ShowDialog()
                    End If
                    Exit Sub
                End If
            Next
        Else
            aviso.mensaje = "Debe seleccionar un pedido"
            aviso.ShowDialog()
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altas()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarPedido()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        confirmarPedido()
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        autorizarPedido()
    End Sub

    Private Sub btnPedidoReal_Click(sender As Object, e As EventArgs) Handles btnPedidoReal.Click
        convertirPedidoReal()
    End Sub

    Private Sub btnVincular_Click(sender As Object, e As EventArgs) Handles btnVincular.Click
        vincularPedidos()
    End Sub

    Private Sub btnCancelarSalida_Click(sender As Object, e As EventArgs) Handles btnCancelarSalida.Click
        cancelarPedido()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Consultafiltros()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        SeleccionarRegistros()
    End Sub

    Private Sub grdPedidosVirtuales_CellChange(sender As Object, e As CellEventArgs) Handles grdPedidosVirtuales.CellChange
        seleccionarRegistroTabla(e)
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 23
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 100
    End Sub

    Private Sub hilo_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hilo.DoWork
        Thread.Sleep(1000)
        Dim msn As String
        Dim mensaje As New AdvertenciaFormGrande
        If PedidosAlerta >= 1 Then
            msn = "Existen pedidos virtuales con Fecha de programación dentro de los próximos 7 días que aún no se vinculan o convierten a un pedido real,"
            msn += " de no cambiar la fecha de programación, los pedidos serán cancelados por el sistema 3 días antes de la fecha."
            mensaje.mensaje = msn
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub grdPedidosVirtuales_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdPedidosVirtuales.DoubleClickRow
        verPedido(e)
    End Sub
End Class