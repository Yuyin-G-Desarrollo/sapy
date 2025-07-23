Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_Form

    Public var As Date
    Public tablaPedidosSeleccionados As DataTable
    Public tablaDocumentosSeleccionados As DataTable


    ''' <summary>
    ''' Permite llenar dinámicamente elemtos de tipo comboBox con información de base de datos
    ''' </summary>
    ''' <param name="nombreCombo">Nombre del combo (ComboBox1, cmbEstado, etc)</param>
    ''' <param name="tipoCombo">Tipo de combo para la vista: 1.-Motivo de devolución, 2.-Clientes, 3.- Empresa, 4.-Fletes</param>
    ''' <param name="parametroProcedimiento">Parámetro que recibe el procedimeinto almacenado para realizar la búsqueda</param>
    ''' <param name="etiquetaCombo">Nombre del campo de la tabla usado como etiqueta en el combo</param>
    ''' <param name="valorCombo">Nombre del campo de la tabla usado como valor en el combo</param>
    Public Sub InicializarCombos(nombreCombo As String, tipoCombo As Int32, parametroProcedimiento As String,
                                 etiquetaCombo As String, valorCombo As String)

        If Me.Controls.Find(nombreCombo, True).Count = 1 Then
            Dim combo As ComboBox = Me.Controls.Find(nombreCombo, True)(0)
            Dim objNegocio As New Negocios.DevolucionClientesBU
            Dim lista As New DataTable
            If tipoCombo = 1 Then
                lista = objNegocio.ListadoMotivos(parametroProcedimiento)
            ElseIf tipoCombo = 2 Then
                lista = objNegocio.ListaGenerica("ConsultaClientes")
            ElseIf tipoCombo = 3 Then
                lista = objNegocio.ListaGenerica("ListadoEmpresas")
            ElseIf tipoCombo = 4 Then
                lista = objNegocio.ListaGenerica("ListadoFletes")
            ElseIf tipoCombo = 5 Then
                lista = objNegocio.ListadoUnidadesMedida()
            End If

            If lista.Rows.Count > 0 Then
                If valorCombo <> "unme_idunidad" Then
                    Dim newRow As DataRow = lista.NewRow
                    lista.Rows.InsertAt(newRow, 0)
                End If
                combo.DataSource = lista
                combo.DisplayMember = etiquetaCombo
                combo.ValueMember = valorCombo
                If valorCombo = "unme_idunidad" Then
                    combo.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Public Sub LlenarCombos()
        InicializarCombos("cmbMotivoInicial", 1, "DEVOLUCION_CLIENTE_MOTIVO_INICIAL", "Motivo", "esta_estatusid")
        InicializarCombos("cmbMotivoCancelacion", 1, "DEVOLUCION_CLIENTE_MOTIVO_CANCELACION", "Motivo", "esta_estatusid")
        InicializarCombos("cmbMotivoVentas", 1, "DEVOLUCION_CLIENTE_MOTIVO_VENTAS", "Motivo", "esta_estatusid")
        InicializarCombos("cmbCliente", 2, "", "clie_nombregenerico", "clie_clienteid")
        InicializarCombos("cmbEmpresa", 3, "", "prov_nombregenerico", "prov_nombregenerico")
        InicializarCombos("cmbFlete", 4, "", "tifl_nombre", "tifl_nombre")
        InicializarCombos("cmbUnidad", 5, "", "unme_descripcion", "unme_idunidad")
    End Sub

    Public Sub RecorrerControles(contenedor As Control)
        For Each control As Control In contenedor.Controls
            If TypeOf (control) Is GroupBox Then
                RecorrerControles(control)
            ElseIf TypeOf (control) Is ComboBox Then
                Dim comboBox As ComboBox = control
                If comboBox.Items.Count = 1 Then
                    comboBox.SelectedIndex = 0
                End If
            End If
        Next
    End Sub

    Public Sub bloquearDesbloquearBotones(editar As Boolean, verAgregarDetalles As Boolean, solicitarRevisionVentas As Boolean, solicitarProcesamientoAlmacen As Boolean, solicitarNotaCredito As Boolean,
                                          disponerDelProducto As Boolean, entregaEmbarques As Boolean, verBitacora As Boolean, concluirDevolcuion As Boolean, cancelarDevolucion As Boolean, guardar As Boolean)
        btnEditar.Enabled = editar
        btnVerAgregarDetalle.Enabled = verAgregarDetalles
        btnSolicitarRevisionVentas.Enabled = solicitarRevisionVentas
        btnSolicitarProcesamientoAlmacen.Enabled = solicitarProcesamientoAlmacen
        btnSolictarNotaCredito.Enabled = solicitarNotaCredito
        btnDisponerDelProducto.Enabled = disponerDelProducto
        btnEntregarEmbarques.Enabled = entregaEmbarques
        btnVerBitacora.Enabled = verBitacora
        btnConcluirDevolucion.Enabled = concluirDevolcuion
        btnCancelar.Enabled = cancelarDevolucion
        btnGuardar.Enabled = guardar
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPedidoSay.ReadOnly = True
        txtDocumentosRelacionados.ReadOnly = True
        txtPedidoSay.BackColor = Color.White
        txtDocumentosRelacionados.BackColor = Color.White
        LlenarCombos()
        'lblFechaUsuarioRegistro.Text = DateTime.Now & " " & Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        lblStatus.Text = "ABIERTA"
        lblStatus.ForeColor = Color.DarkGray
        dtpFechaRecepcion.Value = Date.Now

        grpbVentas.Enabled = False
        grpbCobranza.Enabled = False
        lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"

        RecorrerControles(pnlDatos)
    End Sub

    Public Sub ActualizarAtnCliente_Agente(idCliente As Int32)
        Dim objBU As New Negocios.DevolucionClientesBU
        lblAtnClientes.Text = objBU.GetAtnClientes(idCliente)
        lblAgentes.Text = objBU.ObtenerAgente(idCliente).ToString.Replace(",", "/")
        btnPedido.Enabled = True
        btnDocumentosRelacionados.Enabled = True
        btnGuardar.Enabled = True
        'btnVerAgregarDetalle.Enabled = True
    End Sub

    Public Sub LimpiarAtnCliente_Agente()
        lblAgentes.Text = ""
        lblAtnClientes.Text = ""
        txtPedidoSay.Text = ""
        txtDocumentosRelacionados.Text = ""
        btnPedido.Enabled = False
        btnDocumentosRelacionados.Enabled = False
        btnVerAgregarDetalle.Enabled = False
    End Sub

    Public Sub SepararLista(cajaTexto As TextBox, tabla As DataTable, index As Int16)
        Dim contenido As String = ""
        If tabla IsNot Nothing And tabla.Rows.Count > 0 Then
            For Each elemento As DataRow In tabla.Rows
                contenido += elemento(index).ToString + ","
            Next
            cajaTexto.Text = contenido.Substring(0, contenido.Length - 1)
        End If
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        Dim busquedaCliente As New Devolucioncliente_CapturaGeneral_Busqueda_Form
        Dim idCliente As Int32
        busquedaCliente.StartPosition = FormStartPosition.CenterScreen
        busquedaCliente.ShowDialog(Me)
        If Not busquedaCliente.DialogResult = Windows.Forms.DialogResult.OK Then Return
        idCliente = busquedaCliente.rowCliente(1)
        cmbCliente.SelectedValue = idCliente
        ActualizarAtnCliente_Agente(idCliente)
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        If cmbCliente.Text.Trim = "" Or cmbCliente.SelectedValue Is Nothing Then
            LimpiarAtnCliente_Agente()
        Else
            Try
                Dim idClientes As Int32 = cmbCliente.SelectedValue
                ActualizarAtnCliente_Agente(idClientes)

            Catch ex As Exception
                LimpiarAtnCliente_Agente()
            End Try
        End If
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        Dim FormularioFiltroPorPedidos As New DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
        FormularioFiltroPorPedidos.lblTitulo.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.lblNombreCliente.Text = cmbCliente.Text
        FormularioFiltroPorPedidos.idCliente = cmbCliente.SelectedValue
        FormularioFiltroPorPedidos.tipoConsulta = 1
        FormularioFiltroPorPedidos.filtroActual = txtPedidoSay.Text.Split(",").ToList
        FormularioFiltroPorPedidos.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.StartPosition = FormStartPosition.CenterScreen
        FormularioFiltroPorPedidos.ShowDialog(Me)
        If Not FormularioFiltroPorPedidos.DialogResult = Windows.Forms.DialogResult.OK Then Return
        tablaPedidosSeleccionados = FormularioFiltroPorPedidos.listaSeleccionados
        SepararLista(txtPedidoSay, tablaPedidosSeleccionados, 1)
    End Sub

    Private Sub btnDocumentosRelacionados_Click(sender As Object, e As EventArgs) Handles btnDocumentosRelacionados.Click
        Dim FormularioDocumentos As New DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
        FormularioDocumentos.lblTitulo.Text = "Documentos Por Clientes"
        FormularioDocumentos.lblNombreCliente.Text = cmbCliente.Text
        FormularioDocumentos.idCliente = cmbCliente.SelectedValue
        FormularioDocumentos.tipoConsulta = 2
        FormularioDocumentos.filtroActual = txtDocumentosRelacionados.Text.Split(",").ToList
        FormularioDocumentos.Text = "Documentos Por Cliente"
        FormularioDocumentos.StartPosition = FormStartPosition.CenterScreen
        FormularioDocumentos.ShowDialog(Me)
        If Not FormularioDocumentos.DialogResult = Windows.Forms.DialogResult.OK Then Return
        tablaDocumentosSeleccionados = FormularioDocumentos.listaSeleccionados
        SepararLista(txtDocumentosRelacionados, tablaDocumentosSeleccionados, 10)
        SepararLista(txtIdentificadorDocumentos, tablaDocumentosSeleccionados, 9)
    End Sub

    Private Sub btnVerAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnVerAgregarDetalle.Click
        Dim ventana As New Tools.AvisoForm
        ventana.mensaje = "En esta parte se pueden seleccionar los artículos de la devolución, a partir de pedidos, documentos y/o lectura de códigos"
        ventana.ShowDialog()
        Dim FormDetallesArticulos As New DevolucionCliente_CapturaGeneral_DetallesArticulos
        FormDetallesArticulos.idCliente = cmbCliente.SelectedValue
        FormDetallesArticulos.lblCliente.Text = cmbCliente.Text
        'FormDetallesArticulos.documentosSeleccionados = tablaDocumentosSeleccionados
        FormDetallesArticulos.pedidosSeleccionados = txtPedidoSay.Text
        FormDetallesArticulos.tipoDevolucion = cmbTipoDevolucion.Text
        FormDetallesArticulos.lblFolioDevolucion.Text = lblFolioDev.Text
        FormDetallesArticulos.unidadMedida = lblUnidadMedida.Text
        Try
            FormDetallesArticulos.cantidad = CInt(txtCantidad.Text)
        Catch ex As Exception
            FormDetallesArticulos.cantidad = 0
        End Try

        Try
            FormDetallesArticulos.cajas = CInt(txtCajas.Text)
        Catch ex As Exception
            FormDetallesArticulos.cajas = 0
        End Try

        If cmbMotivoVentas.Text <> "" And cmbMotivoVentas.Text.Length > 0 Then
            FormDetallesArticulos.tipoMotivo = 1
            FormDetallesArticulos.motivoDevolucion = cmbMotivoVentas.Text
            FormDetallesArticulos.idMotivoDevolucion = cmbMotivoVentas.SelectedValue
        ElseIf cmbMotivoInicial.Text <> "" And cmbMotivoInicial.Text.Length > 0 Then
            FormDetallesArticulos.tipoMotivo = 2
            FormDetallesArticulos.motivoDevolucion = cmbMotivoInicial.Text
            FormDetallesArticulos.idMotivoDevolucion = cmbMotivoInicial.SelectedValue
        End If
        FormDetallesArticulos.StartPosition = FormStartPosition.CenterScreen
        FormDetallesArticulos.ShowDialog(Me)
        'If FormDetallesArticulos.DialogResult = DialogResult.OK Then
        lblCantidadCapturada.Text = "200"
        lblTotalMonto.Text = "29,658"
        'End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dtpFechaRecepcion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaRecepcion.ValueChanged
        dtpFechaLimite.Value = (dtpFechaRecepcion.Value).AddDays(15)
        lblNumSemana.Text = DatePart(DateInterval.WeekOfYear, dtpFechaRecepcion.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.System)
    End Sub

    Private Sub btnAnexarAutorizacion_Click(sender As Object, e As EventArgs) Handles btnAnexarAutorizacion.Click
        Dim ventana As New Tools.AdvertenciaForm
        ventana.mensaje = "Botón para abrir cuadro de diálogo para seleccionar el PDF de la autorización"
        ventana.ShowDialog()
    End Sub

    Private Sub btnVerAutorizacion_Click(sender As Object, e As EventArgs) Handles btnVerAutorizacion.Click
        Dim ventana As New Tools.AdvertenciaForm
        ventana.mensaje = "Botón para abrir cuadro de diálogo para descargar el PDF de la autorización"
        ventana.ShowDialog()
    End Sub

    Private Sub btnBuscarNotasCredito_Cobranza_Click(sender As Object, e As EventArgs) Handles btnBuscarNotasCredito_Cobranza.Click
        Dim ventana As New Tools.AdvertenciaForm
        ventana.mensaje = "Botón para abrir detalles de la nota de crédito generada en SICY relacionada con la devolución del cliente"
        ventana.ShowDialog()
    End Sub

    Private Sub rdbPendiente_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPendiente.CheckedChanged
        If rdbPendiente.Checked = True Then
            lblResolucion.Text = "PENDIENTE"
            lblResolucion.ForeColor = Color.Orange
            rdbAplicaNotaCreditoSI.Enabled = False
            rdbAplicaNotaCreditoNO.Enabled = False
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbProcede_CheckedChanged(sender As Object, e As EventArgs) Handles rdbProcede.CheckedChanged
        If rdbProcede.Checked = True Then
            lblResolucion.Text = "PROCEDE"
            lblResolucion.ForeColor = Color.Green
            rdbAplicaNotaCreditoSI.Enabled = True
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbNoProcede_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoProcede.CheckedChanged
        If rdbNoProcede.Checked = True Then
            lblResolucion.Text = "NO PROCEDE"
            lblResolucion.ForeColor = Color.Red
            rdbAplicaNotaCreditoSI.Enabled = False
            rdbAplicaNotaCreditoNO.Enabled = False
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ventana As New Tools.ExitoForm
        ventana.mensaje = "Se generó la devolución del cliente " & cmbCliente.Text & " con Folio 589"
        ventana.ShowDialog()
        bloquearDesbloquearBotones(True, True, True, False, False, False, False, True, False, True, True)
        lblFechaUsuarioRegistro.Text = DateTime.Now & " (ZALEXIS)"
        lblFolioDev.Text = "589"
        'Dim objDev As New Entidades.DevolucionCliente
        'Dim negocios As New Negocios.DevolucionClientesBU
        'negocios.RegistrarDevolucionCliente(objDev)
    End Sub

    Private Sub btnSolicitarRevisionVentas_Click(sender As Object, e As EventArgs) Handles btnSolicitarRevisionVentas.Click
        Dim ventana As New Tools.ExitoForm
        ventana.mensaje = "Ventas tiene hasta el " + dtpFechaLimite.Value.ToShortDateString + " para indicarle el tratamiento de devolución del cliente " + cmbCliente.Text + " con Folio 589"
        ventana.ShowDialog()
        lblEnviadoARevision.Text = DateTime.Now & " (ZALEXIS)"
        grpbAlmacen.Enabled = False
        grpbVentas.Enabled = True
        grpbCobranza.Enabled = False
        lblUsuarioActual.Text = "Usuario de: JEFATURA DE ATENCIÓN A CLIENTES"
        lblStatus.Text = "EN REVISIÓN"
        lblStatus.ForeColor = Color.Blue
        bloquearDesbloquearBotones(True, True, False, True, True, False, False, True, False, False, True)
    End Sub

    Private Sub btnSolictarNotaCredito_Click(sender As Object, e As EventArgs) Handles btnSolictarNotaCredito.Click
        Dim ventana As New Tools.AdvertenciaFormGrande
        ventana.mensaje = "Ventas solo puede solicitar la nota de crédito cuando los detalles de la devolución ya están capturados. En este momento la devolución se replicará en SICY para que Cobranza la visualice en la pantalla de Notas de Crédito de SICY." & vbCrLf & "La NC no necesariamente se genera a los documentos de la devolución (puede ser que ya no tengan saldo), Cliente o Cobranza determinan a que documento aplicarla"
        ventana.ShowDialog()
        lblSolicitudNotaCredito.Text = DateTime.Now & " (GGUADALUPE)"
        grpbAlmacen.Enabled = False
        grpbVentas.Enabled = False
        If rdbAplicaNotaCreditoSI.Checked = True Then
            grpbCobranza.Enabled = True
        Else
            grpbCobranza.Enabled = False
        End If
        lblUsuarioActual.Text = "Usuario de: COBRANZA / JEFATURA DE ATENCIÓN A CLIENTES"
        bloquearDesbloquearBotones(True, True, False, True, False, False, False, True, False, False, True)

        txtNotasCredito.Text = "NC-7572,NC-45896"
        txtDoctosSeleccionados.Text = "F AA-4159,R 5587-2019"

        lblDevolucionSICY.Text = "14859"
        lblCantidadAplicada.Text = lblCantidadCapturada.Text
        lblCantidadPorAplicar.Text = "0"

        lblStatus.Text = "EN PROCESO"
        lblStatus.ForeColor = Color.Purple
    End Sub

    Private Sub btnSolicitarProcesamientoAlmacen_Click(sender As Object, e As EventArgs) Handles btnSolicitarProcesamientoAlmacen.Click
        Dim ventana As New Tools.AvisoForm
        ventana.mensaje = "Almacén tiene 24 horas para concluir la atención de la devolución Folio 589 del cliente " & cmbCliente.Text
        ventana.ShowDialog()
        lblEnviadoProcesamiento.Text = DateTime.Now & " (GGUADALUPE)"
        lblEnviadoProcesamiento.ForeColor = Color.Black
        grpbAlmacen.Enabled = True
        grpbVentas.Enabled = False
        If rdbAplicaNotaCreditoSI.Checked = True Then
            grpbCobranza.Enabled = True
        Else
            grpbCobranza.Enabled = False
        End If

        bloquearDesbloquearBotones(True, True, False, False, True, True, True, True, False, False, True)

        If cmbDestinoProducto.Text.ToString.Length > 0 Then
            If cmbDestinoProducto.Text = "DESTRUCCIÓN" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (BLOQUEADO)" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (DISPONIBLE)" Then
                btnDisponerDelProducto.Enabled = True
                btnEntregarEmbarques.Enabled = False
            ElseIf cmbDestinoProducto.Text = "ENTREGA (REFACTURAR)" Or cmbDestinoProducto.Text = "RE-ENTREGA (MISMOS DOCUMENTOS)" Then
                btnDisponerDelProducto.Enabled = False
                btnEntregarEmbarques.Enabled = True
            End If
        End If

        lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"

        lblStatus.Text = "EN PROCESO"
        lblStatus.ForeColor = Color.Purple
    End Sub

    Private Sub btnDisponerDelProducto_Click(sender As Object, e As EventArgs) Handles btnDisponerDelProducto.Click
        Dim ventana As New Tools.AvisoForm
        ventana.mensaje = "Este botón abrirá una pantalla desde donde se podrá indicar la destrucción del producto, reingresarlo al almacén, ponerlo en Bloqueado o Disponible (falta definir operación)"
        ventana.ShowDialog()

        lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"

        bloquearDesbloquearBotones(True, True, False, False, False, False, False, True, True, False, True)

        lblStatus.Text = "EN PROCESO"
        lblStatus.ForeColor = Color.Purple
    End Sub

    Private Sub btnEntregarEmbarques_Click(sender As Object, e As EventArgs) Handles btnEntregarEmbarques.Click
        Dim ventana As New Tools.AvisoForm
        ventana.mensaje = "Determinar como se realiza la recepción, si es necesario tenerla en sistema"
        ventana.ShowDialog()

        lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"

        bloquearDesbloquearBotones(True, True, False, False, False, False, False, True, True, False, True)

        lblStatus.Text = "EN PROCESO"
        lblStatus.ForeColor = Color.Purple
    End Sub

    Private Sub btnConcluirDevolucion_Click(sender As Object, e As EventArgs) Handles btnConcluirDevolucion.Click
        Dim ventana As New Tools.ConfirmarForm
        ventana.mensaje = "¿Desea finalizar el proceso de la devolución del cliente " & cmbCliente.Text & " con Folio 589? " & vbCrLf & "Una vez realizada esta acción no se podrá revertir"
        ventana.ShowDialog()
        If ventana.DialogResult = DialogResult.OK Then
            lblConcluyeDevolucion.Text = DateTime.Now & " (ZALEXIS)"
            lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"
            lblDiasTranscurridos.Text = "8"

            If rdbProcede.Checked = True Or rdbNoProcede.Checked = True Then
                bloquearDesbloquearBotones(False, True, False, False, False, False, False, True, False, False, False)

                If rdbProcede.Checked = True Then
                    lblStatus.Text = "RESUELTA PROCEDE"
                    lblStatus.ForeColor = Color.Green
                Else
                    lblStatus.Text = "RESUELTA NO PROCEDE"
                    lblStatus.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim ventana As New Tools.ConfirmarForm
        ventana.mensaje = "¿ Desea cancelar el proceso de la devolución del cliente " & cmbCliente.Text & " con Folio 589 ? " & vbCrLf & "Se calificará como NO PROCEDE, deberá capturar un motivo de cancelación"
        ventana.ShowDialog()
        If ventana.DialogResult = DialogResult.OK Then
            lblConcluyeDevolucion.Text = DateTime.Now & " (ZALEXIS)"
            lblUsuarioActual.Text = "Usuario de: DEVOLUCIONES"
            lblDiasTranscurridos.Text = "8"

            bloquearDesbloquearBotones(False, True, False, False, False, False, False, True, False, False, False)

            lblStatus.Text = "CANCELADA"
            lblStatus.ForeColor = Color.Orange

            grpbCancelacion.Enabled = True
            cmbMotivoCancelacion.SelectedValue = 311
            txtFechaHoraCancelacion.Text = DateTime.Now
            txtUsuarioCancela.Text = "(ZALEXIS)"
            txtObservacionesCancelacion.Text = "LA DEVOLUCIÓN ERA DE CALZADO GIOVANNA"
        End If
    End Sub

    Private Sub btnVerBitacora_Click(sender As Object, e As EventArgs) Handles btnVerBitacora.Click
        Dim ventana As New DevolucionCliente_CapturaGeneral_BitacoraDev_Form
        ventana.StartPosition = FormStartPosition.CenterScreen
        ventana.lblClienteDevolucion.Text = cmbCliente.Text
        ventana.lblFolioDevolución.Text = lblFolioDev.Text
        ventana.ShowDialog()
    End Sub

    Private Sub cmbDestinoProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDestinoProducto.SelectedValueChanged
        'If cmbDestinoProducto.SelectedValue Then
        If cmbDestinoProducto.Text = "DESTRUCCIÓN" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (BLOQUEADO)" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (DISPONIBLE)" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (ESPECIAL)" Then
            lblReqAutorizacion.Text = "SI"
            lblReqAutorizacion.ForeColor = Color.Tomato
            btnAnexarAutorizacion.Enabled = True
            btnVerAutorizacion.Enabled = True
        ElseIf cmbDestinoProducto.Text = "ENTREGA (REFACTURAR)" Or cmbDestinoProducto.Text = "RE-ENTREGA (MISMOS DOCUMENTOS)" Then
            lblReqAutorizacion.Text = "NO"
            lblReqAutorizacion.ForeColor = Color.Green
            btnAnexarAutorizacion.Enabled = False
            btnVerAutorizacion.Enabled = False
        End If
        'End If
    End Sub

    Private Sub cmbUnidad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUnidad.SelectedValueChanged
        lblUnidadMedida.Text = "(" & cmbUnidad.Text & ")"
    End Sub

    Private Sub cmbTipoDevolucion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDevolucion.SelectedIndexChanged

    End Sub
End Class