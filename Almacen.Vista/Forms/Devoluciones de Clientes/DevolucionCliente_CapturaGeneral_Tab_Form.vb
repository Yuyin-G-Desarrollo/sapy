Imports Tools
Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTabs
Imports System.Net
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Partial Public Class DevolucionCliente_CapturaGeneral_Tab_Form
    ''' <summary>
    ''' Constantes empleadas para el cambio de estatus de la devolución
    ''' </summary>
    Private Const ESTATUS_ABIERTA As Int16 = 303
    Private Const ESTATUS_EN_REVISION As Int16 = 304
    Private Const ESTATUS_EN_PROCESO As Int16 = 305
    Private Const ESTATUS_RESUELTA_PROCEDE As Int16 = 306
    Private Const ESTATUS_RESUELTA_NO_PROCEDE As Int16 = 307
    Private Const ESTATUS_CANCELADA As Int16 = 308
    Private Const ESTATUS_SOLICITA_DOCUMENTOS As Int16 = 331

    ''' <summary>
    ''' Declaración de variables
    ''' </summary>
    Public tablaPedidosSeleccionados As New DataTable
    Public tablaDocumentosSeleccionados As New DataTable
    Public dtMotivos As New DataTable
    Public estatusId As Int16
    Public vacios As Boolean
    Public objDev As New Entidades.DevolucionCliente
    Public peidoSicy As String = ""
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena
    Public UltimoArchivo As String
    Public guardado As Boolean = False
    Public edicion_almacen As Boolean = False
    Public edicion_ventas As Boolean = False
    Public edicion As Boolean = False
    Public administrador As Boolean = False
    Public NuevaDevolucion As Boolean = True
    Public Usuario As Integer
    Public objPermisos As New Entidades.DevolucionCliente_PermisosPantallas
    Public CEDIS As Integer = 0
    ''' <summary>
    ''' Variables para las ventanas
    ''' </summary>
    Public ventanaError As New Tools.ErroresForm
    Public ventanaExito As New Tools.ExitoForm
    Public ventanaAdvertencias As New Tools.AdvertenciaForm
    Public ventanaConfirmacion As New Tools.ConfirmarForm

    ''' <summary>
    ''' Asigna los valores a los controles de tipo ComboBox de acuerdo a las consultas de base de datos
    ''' Se hace una consulta SELECT a la base de datos devolviendo un DataTable con dos columnas
    ''' </summary>
    ''' <param name="control">ComboBox sobre el que se trabajará</param>
    ''' <param name="listado">Lista a consultar para asignar los valores al combo</param>
    ''' <param name="etiquetaCombo">Columna del Datatable empleada para mostrar las etiquetas en el combo 
    ''' (lo que se verá al desplegar el combobox)</param>
    ''' <param name="valorCombo">Columna del DataTable empleada para los valores del ComboBox 
    ''' (El valor de la etiqueta seleccionada, por ejemplo: la etiqueta puede ser el nombre del estatus pero el valor sería el ID del mismo)</param>
    Public Sub InicializarCombos(control As ComboBox, listado As String, etiquetaCombo As String, valorCombo As String, Optional ByVal CEDIS As Integer = 0)
        Dim objNegocio As New Negocios.DevolucionClientesBU
        Dim lista As New DataTable
        ' Si el parámetro 'LISTADO' es igual a alguno de los valores para el motivo de devolución se hace la consulta correspondiente
        ' En caso contrario se hace la consulta al listado indicado
        If listado = "DEVOLUCION_CLIENTE_MOTIVO_INICIAL" Then
            dtMotivos = objNegocio.ListadoMotivos(listado)
            lista = dtMotivos
        ElseIf listado = "DEVOLUCION_CLIENTE_MOTIVO_VENTAS" Then
            lista = objNegocio.ListadoMotivos(listado)
        Else
            lista = objNegocio.ListaGenerica(listado, CEDIS)
        End If

        ' Si la consulta devuelve uno o más registros se hace la asignación de los valores al combo
        If lista.Rows.Count > 0 Then
            ' Si el combo no es el de unidad de medida, se agrega una fila vacía al principio
            If valorCombo <> "unme_idunidad" Then
                Dim newRow As DataRow = lista.NewRow
                lista.Rows.InsertAt(newRow, 0)
            End If
            ' Se asigna como dataSource del combo el resultado de la consulta
            control.DataSource = lista
            control.DisplayMember = etiquetaCombo
            control.ValueMember = valorCombo
            ' Si el combo es el de unidad de medida por default se selecciona el primer registro
            ' Lo mismo sucede si el combo contiene solo un registro
            If valorCombo = "unme_idunidad" Or control.Items.Count = 1 Then
                control.SelectedIndex = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifica si el usuario cuenta con los permisos de almacén, ventas y cobranza o ambos
    ''' </summary>
    Public Sub Permisos(objPermisos As Entidades.DevolucionCliente_PermisosPantallas)
        If objPermisos.Area = "VENTAS" Then
            If objPermisos.BtnEditar_TodosLosClientes = True Then
                btnEditar.Enabled = objPermisos.BtnEditar_TodosLosClientes
            ElseIf objDev.UsuarioAtnCte = Entidades.SesionUsuario.UsuarioSesion.PUserUsername Then
                btnEditar.Enabled = objPermisos.BtnEditar_formAltaEdicion
            Else
                btnEditar.Enabled = False
            End If
        Else
            btnEditar.Enabled = objPermisos.BtnEditar_formAltaEdicion
        End If

        btnVerAgregarDetalle.Enabled = objPermisos.BtnVerDetalles_formAltaEdicion
        btnSolicitarDocumentos.Enabled = objPermisos.BtnSolicitarDocumentos
        btnSolicitarRevisionVentas.Enabled = objPermisos.BtnSolicitarRevision
        btnSolicitarProcesamientoAlmacen.Enabled = objPermisos.BtnSolicitarProcesamientoAlmacen
        btnSolicitarNotaCredito.Enabled = objPermisos.BtnSolictarNotaCredito

        cmbTipoDevolucion.Enabled = objPermisos.CmbTipoDev
        cmbCliente.Enabled = objPermisos.ControlCliente
        btnAgregarCliente.Enabled = objPermisos.ControlCliente

        'pnlAlmacen.Enabled = objPermisos.PnlAlmacen

        grpbRecepcion.Enabled = objPermisos.PnlAlmacen
        grpbArticulos.Enabled = objPermisos.PnlAlmacen
        grpbPaqueteria.Enabled = objPermisos.PnlAlmacen
        grpbComentarios.Enabled = objPermisos.PnlAlmacen
        grpbResolucion.Enabled = objPermisos.GrpbResolucion_pnlAlmacen
        grpbResolucion_pnlVentas.Enabled = objPermisos.GrpbResolucion_pnlVentas
        btnGuardar.Enabled = objPermisos.BtnGuardar_pnlAlmacen

        If objPermisos.PnlAlmacen = True Then
            cmbUnidad.Enabled = objPermisos.CmbUnidad
            'cmbUbicacion.Enabled = objPermisos.CmbUbicacion
            'btnPedido.Enabled = objPermisos.ControlPedidos
            cmbMotivoInicial.Enabled = objPermisos.CmbMotivo_Almacen
        End If

        'pnlComponentesCobranza.Enabled = objPermisos.PnlCobranza
        'grpObservacionesCobranza.Enabled = objPermisos.PnlCobranza
        grpbVentas.Enabled = objPermisos.PnlVentas

        If objPermisos.PnlVentas = True Then
            btnDocumentosRelacionados.Enabled = objPermisos.ControlDocumentos
            rdbAplicaNotaCreditoSI.Enabled = objPermisos.RdbAplicaNotaCredito
            rdbAplicaNotaCreditoNO.Enabled = objPermisos.RdbAplicaNotaCredito
            btnGuardar_Ventas.Enabled = objPermisos.BtnGuardar_Ventas
            'grpbCobranza.Enabled = objPermisos.PnlCobranza
        End If
        lblMontoTotal.Visible = objPermisos.VerMontos
        lblEtiquetaMontoTotal.Visible = objPermisos.VerMontos

        If objPermisos.Area = "VENTAS" Or objPermisos.Area = "COBRANZA" Then
            dockManagerDevoluciones.DockAreas.Item(1).Pin()
            dockManagerDevoluciones.DockAreas.Item(1).Unpin()
        Else
            dockManagerDevoluciones.DockAreas.Item(0).Pin()
            dockManagerDevoluciones.DockAreas.Item(0).Unpin()
        End If

        If lblClasificacion.Text = "CALIDAD" Then
            cmbMotivoVentas.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Genera los valores del combo de tipo de devoluciones (MAYOREO, MENUDEO, ETC)
    ''' </summary>
    Public Sub comboTipoDev()
        Dim valoresCombo As New List(Of String)
        valoresCombo.Add("MAYOREO")
        valoresCombo.Add("MENUDEO")
        ' En esta sección se agregan los otros tipo de devolución dependiedo de su liberación
        cmbTipoDevolucion.DataSource = valoresCombo
        cmbTipoDevolucion.SelectedItem = 0
    End Sub

    ''' <summary>
    ''' Método que inidica los combos a inicializar y los parámetros del mismo
    ''' </summary>
    Public Sub LlenarCombos()
        InicializarCombos(cmbMotivoInicial, "DEVOLUCION_CLIENTE_MOTIVO_INICIAL", "Motivo", "esta_estatusid")
        InicializarCombos(cmbMotivoVentas, "DEVOLUCION_CLIENTE_MOTIVO_VENTAS", "Motivo", "esta_estatusid")
        InicializarCombos(cmbCliente, "ConsultaClientes", "clie_nombregenerico", "clie_clienteid", CEDIS)
        InicializarCombos(cmbEmpresa, "ListadoEmpresas", "prov_nombregenerico", "prov_proveedorid")
        InicializarCombos(cmbFlete, "ListadoFletes", "tifl_nombre", "tifl_tipofleteid")
        InicializarCombos(cmbRecibio, "ListadoColaboradorRecibe", "Colaborador", "IdColaborador")
        InicializarCombos(cmbUbicacion, "ListadoUbicaciones", "esta_nombre", "esta_estatusid")
        InicializarCombos(cmbDestinoProducto, "ListadoDestinos", "esta_nombre", "esta_estatusid")
        InicializarCombos(cmbResponsable, "ListadoResponsables", "esta_nombre", "esta_estatusid")
        InicializarCombos(cmbUnidad, "ConsultaUnidadMedida", "unme_descripcion", "unme_idunidad")
    End Sub

    Public Sub bloquearDesbloquearBotones(editar As Boolean, verAgregarDetalles As Boolean, solicitarRevisionVentas As Boolean,
                                          solicitarProcesamientoAlmacen As Boolean, solicitarNotaCredito As Boolean, guardar As Boolean, guardarVentas As Boolean)
        btnEditar.Enabled = editar
        btnVerAgregarDetalle.Enabled = verAgregarDetalles
        btnSolicitarRevisionVentas.Enabled = solicitarRevisionVentas
        btnSolicitarProcesamientoAlmacen.Enabled = solicitarProcesamientoAlmacen
        btnSolicitarNotaCredito.Enabled = solicitarNotaCredito
        btnGuardar.Enabled = guardar
        btnGuardar_Ventas.Enabled = guardarVentas
    End Sub

    Public Sub ActualizarAtnCliente_Agente(idCliente As Int32)
        Dim objBU As New Negocios.DevolucionClientesBU
        lblAtnClientes.Text = objBU.GetAtnClientes(idCliente)
        lblAgentes.Text = objBU.ObtenerAgente(idCliente).ToString.Replace(",", "/")
        'btnPedido.Enabled = True
        'btnDocumentosRelacionados.Enabled = True
        btnGuardar.Enabled = True
        'btnVerAgregarDetalle.Enabled = True
    End Sub

    Public Sub LimpiarAtnCliente_Agente()
        lblAgentes.Text = ""
        lblAtnClientes.Text = ""
        'txtPedidoSay.Text = ""
        'txtDocumentosRelacionados.Text = ""
        'btnPedido.Enabled = False
        'btnDocumentosRelacionados.Enabled = False
        btnVerAgregarDetalle.Enabled = False
    End Sub

    Public Function SepararLista(tabla As DataTable, columna As String)
        Dim contenido As String = ""
        If tabla IsNot Nothing And tabla.Rows.Count > 0 Then
            For Each elemento As DataRow In tabla.Rows
                If contenido.Length > 0 Then
                    contenido += ","
                End If
                contenido += elemento(columna).ToString
            Next
        End If

        Return contenido
    End Function

    Public Sub ValidarCamposObligatorios(control As Control, etiqueta As Label)
        If TypeOf (control) Is TextBox Then
            If control.Text.ToString.Length <= 0 Then
                etiqueta.ForeColor = Color.Red
                vacios = True
            Else
                etiqueta.ForeColor = Color.Black
            End If
        ElseIf TypeOf (control) Is ComboBox Then
            Dim combo As ComboBox = control
            If combo.SelectedValue Is Nothing Then
                etiqueta.ForeColor = Color.Red
                vacios = True
            ElseIf combo.SelectedValue.ToString.Length > 0 Or combo.SelectedText.Length > 0 Then
                etiqueta.ForeColor = Color.Black
            Else
                etiqueta.ForeColor = Color.Red
                vacios = True
            End If
        ElseIf TypeOf (control) Is MaskedTextBox Then
            Try
                If CInt(control.Text.ToString) >= 0 Then
                    etiqueta.ForeColor = Color.Black
                End If
            Catch ex As Exception
                etiqueta.ForeColor = Color.Red
                vacios = True
            End Try
        End If

        'MsgBox(CInt(txtCajas.ToString))
    End Sub

    ''' <summary>
    ''' Toma como referencia el objeto con los atributos de la devolución y los valores los coloca en los campos correspondientes
    ''' (Combos, cajas de texto, etiquetas, etc)
    ''' </summary>
    Public Sub ColocarParametros()
        lblFolioDev.Text = objDev.Devolucionclienteid
        lblStatus.Text = objDev.Estatus
        cmbCliente.SelectedValue = objDev.Clienteid
        If objDev.Tipodevolucion = "MAYOREO" Then
            cmbTipoDevolucion.SelectedIndex = 0
        Else
            cmbTipoDevolucion.SelectedIndex = 1
        End If

        lblResolucion.Text = objDev.Resolucion

        For Each control In grpbResolucion.Controls
            If TypeOf (control) Is RadioButton Then
                Dim radio As New RadioButton
                radio = control
                If radio.Text.ToUpper = objDev.Resolucion Then
                    radio.Checked = True
                End If
            End If
        Next

        For Each control In grpbResolucion_pnlVentas.Controls
            If TypeOf (control) Is RadioButton Then
                Dim radio As New RadioButton
                radio = control
                If radio.Text.ToUpper = objDev.Resolucion Then
                    radio.Checked = True
                End If
            End If
        Next

        estatusId = objDev.Statusid
        txtProcedeAutoriza_pnlAlmacen.Text = objDev.Procedeautoriza
        lblFechaUsuarioRegistro.Text = (objDev.Fechacaptura.ToString) + " (" + objDev.Usuariocaptura + ")"
        cmbRecibio.SelectedValue = objDev.Colaboradorid_recibio
        txtCantidad.Text = objDev.Cantidad_inicial
        cmbUnidad.SelectedValue = objDev.Unidadid
        txtCajas.Text = objDev.Cajas
        cmbMotivoInicial.SelectedValue = objDev.Motivoinicialalmacen_statusid
        txtComentarios.Text = objDev.Observaciones_almacen
        cmbEmpresa.SelectedValue = objDev.Paqueteria_proveedorid
        cmbFlete.SelectedValue = objDev.Tipofleteid
        txtCosto.Text = objDev.Costopaqueteria
        txtNumeroGuia.Text = objDev.Numeroguia
        'txtModelos.Text = objDev.Modelos_say
        'txtColores.Text = objDev.Colores_say
        'txtCorridas.Text = objDev.Corridas_say
        cmbUbicacion.SelectedValue = objDev.Almacen_actual_estatusid
        'txtPedidoSay.Text = objDev.PedidosSAY
        txtObservacionFactura.Text = objDev.ObservacionFactura
        txtIndicaRecepcion.Text = objDev.Indicarecepcion
        cmbDestinoProducto.SelectedValue = objDev.Destinoproducto
        cmbResponsable.SelectedValue = objDev.Responsabledevolucion_estatusid
        cmbMotivoVentas.SelectedValue = objDev.Motivoventas_statusid

        If objDev.Aplicanotacredito = 1 Then
            rdbAplicaNotaCreditoSI.Checked = True
        Else
            rdbAplicaNotaCreditoNO.Checked = True
        End If

        If objDev.Resolucion = "PROCEDE" Then
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoSI.Enabled = True
        End If

        'If objDev.SinDocumentos = 0 And objDev.IdentificadorDocumentos.ToString.Length = 0 Then
        '    lblBtnSolicitarDocumentos.Visible = True
        '    lblBtnRevisionVentas.Visible = False
        'Else
        '    If objDev.SinDocumentos = 1 Then
        '        chkSinDocumentos.Checked = True
        '    Else
        '        chkSinDocumentos.Checked = False
        '    End If
        '    lblBtnSolicitarDocumentos.Visible = False
        '    lblBtnRevisionVentas.Visible = True
        'End If

        If objDev.SinDocumentos = 1 Then
            chkSinDocumentos.Checked = True
        Else
            chkSinDocumentos.Checked = False
        End If

        lblEnviadoARevision.Text = objDev.Ventas_fechaEnviadoRevision
        txtObservaciones_Ventas.Text = objDev.Observaciones_ventas
        'txtObservaciones_Cobranza.Text = objDev.Observaciones_cobranza
        dtpFechaRecepcion.Value = objDev.Fecharecepcion
        'MsgBox(DateDiff(DateInterval.Day, dtpFechaRecepcion.Value, DateTime.Now))
        lblDiasTranscurridos.Text = DateDiff(DateInterval.Day, dtpFechaRecepcion.Value, Date.Now)
        lblCantidadAplicada.Text = objDev.Cantidad_aplicado
        lblCantidadPorAplicar.Text = objDev.Cantidad_poraplicar
        txtIdentificadorDocumentos.Text = objDev.IdentificadorDocumentos.ToString
        If txtIdentificadorDocumentos.Text.ToString.Length > 0 Then
            txtDocumentosRelacionados.Text = (New Negocios.DevolucionClientesBU).ConsultarDocumentosSeleccionados_CG(objDev.IdentificadorDocumentos)
        End If
        If Not IsDBNull(objDev.Ventas_fechamodificacion) And objDev.Ventas_fechamodificacion.ToString.Length > 0 Then
            lblModificacionVentas.Text = objDev.Ventas_fechamodificacion.ToString + " (" + objDev.Ventas_usuariomodifica.ToString + ")"
        Else
            lblModificacionVentas.Text = "-"
        End If

        If Not IsDBNull(objDev.Cobranza_fechaMoficacion) And objDev.Cobranza_fechaMoficacion.ToString.Length > 0 And objDev.Cobranza_fechaMoficacion <> "1/1/0001 12:00:00 AM" Then
            'lblModificacionCobranza.Text = objDev.Cobranza_fechaMoficacion.ToString + " (" + objDev.Cobranza_usuarioModifica.ToString + ")"
        Else
            'lblModificacionCobranza.Text = "-"
        End If

        nudDiasProcesamiento.Value = objDev.DiasProcesamiento
        lblDevolucionSICY.Text = objDev.Devolucionsicyid
        lblCantidadTotal.Text = objDev.Cantidadtotal
        lblMontoTotal.Text = "$" + objDev.Total.ToString("N2")
    End Sub

    ''' <summary>
    ''' Dependiendo del estatus en el que se encuentra la devolución, cambia el color de la etiqueta y habilita o inhabilita
    ''' los botones según sea el caso
    ''' </summary>
    Public Sub colorEtiquetaEstatus()
        If lblStatus.Text.ToString = "ABIERTA" Then
            lblStatus.ForeColor = Color.DimGray
        ElseIf lblStatus.Text.ToString = "EN REVISIÓN" Then
            lblStatus.ForeColor = Color.DodgerBlue
            btnGuardar_Ventas.Enabled = True
        ElseIf lblStatus.Text.ToString = "SOLICITA DOCUMENTOS" Then
            lblStatus.ForeColor = Color.Blue
            btnGuardar_Ventas.Enabled = True
        ElseIf lblStatus.Text.ToString = "EN PROCESO" Then
            lblStatus.ForeColor = Color.Purple
            btnGuardar_Ventas.Enabled = False
        ElseIf lblStatus.Text.ToString = "CANCELADA" Then
            lblStatus.ForeColor = Color.Orange
        ElseIf lblStatus.Text.ToString = "RESUELTA PROCEDE" Then
            lblStatus.ForeColor = Color.Green
        ElseIf lblStatus.Text.ToString = "RESUELTA NO PROCEDE" Then
            lblStatus.ForeColor = Color.Red
        ElseIf lblStatus.Text.ToString = "PASAR A EMBARQUES" Then
            lblStatus.ForeColor = Color.Orange
        ElseIf lblStatus.Text.ToString = "RECIBIDO EN EMBARQUES" Then
            lblStatus.ForeColor = Color.SaddleBrown
        End If
    End Sub

    Public Sub ColorEtiquetaResolucion()
        If lblResolucion.Text = "PENDIENTE" Then
            lblResolucion.ForeColor = Color.Orange
        ElseIf lblResolucion.Text = "PROCEDE" Then
            lblResolucion.ForeColor = Color.Green
        ElseIf lblResolucion.Text = "NO PROCEDE" Then
            lblResolucion.ForeColor = Color.Red
        ElseIf lblResolucion.Text = "PROCEDE (AUTORIZADA)" Then
            lblResolucion.ForeColor = Color.Blue
        End If
    End Sub

    Public Sub ConsultarNC_Dev()
        Dim negocios As New Negocios.DevolucionClientesBU
        lblDescuento.Visible = objPermisos.VerMontos
        lblMontoDescuento.Visible = objPermisos.VerMontos
        lblEtiquetaMontoDescuento.Visible = objPermisos.VerMontos
        'lblEtiquetaDescuento.Visible = objPermisos.VerMontos
        lblSumatoriaMonto.Visible = objPermisos.VerMontos
        lblEtiquetaMontoMasIva.Visible = objPermisos.VerMontos
        lblMontoIVA.Visible = objPermisos.VerMontos
        lblEtiquetaIva.Visible = objPermisos.VerMontos

        If objDev.Devolucionsicyid <> 0 Then
            Dim dtNC As DataTable = negocios.ConsultaNC(objDev.Devolucionsicyid)
            grdNotasCredito.DataSource = dtNC
            lblSolicitudNotaCredito.Text = objDev.UsuarioSolicitaNC
            FormatoGrid()
            If dtNC.Rows.Count > 0 Then
                lblCantidadAplicada.Text = dtNC.Rows(0).Item("Aplicada").ToString
                lblCantidadPorAplicar.Text = dtNC.Rows(0).Item("PorAplicar").ToString
            Else
                Dim totales As DataTable = negocios.ConsultarTotalesNotas(objDev.Devolucionsicyid)
                lblCantidadAplicada.Text = 0
                lblCantidadPorAplicar.Text = totales.Rows(0).Item("Total").ToString
            End If
        End If

        Dim dtDescuentos As DataTable = negocios.ConsultaDescuentosCliente(objDev.Clienteid)
        Dim dtTipoIva As DataTable = negocios.ConsultaTipoIvaCliente(objDev.Clienteid)
        Dim cantidadDescuento As Double = 0
        Dim montoDescuento As Double = 0
        Dim montoIVA As Double = 0

        If dtDescuentos.Rows.Count > 0 Then
            cantidadDescuento = dtDescuentos.Rows(0).Item("cantidadDescuento")
            montoDescuento = (objDev.Total * cantidadDescuento) / 100
            lblDescuento.Text = cantidadDescuento.ToString + IIf(dtDescuentos.Rows(0).Item("cantidadDescuento"), "%", "")
            lblMontoDescuento.Text = "$" + montoDescuento.ToString("N2")
        End If

        If dtTipoIva.Rows.Count > 0 Then
            If dtTipoIva.Rows(0).Item("TipoIvaID").ToString.Equals("1") Then
                lblMontoIVA.Text = "$0.00 (" + dtTipoIva.Rows(0).Item("TipoIva").ToString + ")"
            Else
                montoIVA = ((objDev.Total - montoDescuento) * 16) / 100
                lblMontoIVA.Text = "$" + montoIVA.ToString("N2")
            End If
        End If

        lblSumatoriaMonto.Text = "$" + (objDev.Total + montoIVA - montoDescuento).ToString("N2")
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_Tab_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Objeto para enlazar con la clase de negocios
        Dim negocios As New Negocios.DevolucionClientesBU
        Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        ' Los campos de texto para los pedidos y los documentos se configuran como solo lectura
        'txtPedidoSay.ReadOnly = True
        txtDocumentosRelacionados.ReadOnly = True
        'txtPedidoSay.BackColor = Color.White
        txtDocumentosRelacionados.BackColor = Color.White

        ' Los valores de la mayoría de los combos proviene de registros en base de datos, por lo tanto,
        ' se hace la llamda a este método
        LlenarCombos()

        ' Se asigna la fecha actual al DTP FechaRecepción
        dtpFechaRecepcion.Value = Date.Now

        ' La ubicación por default debe ser 'DEVOLUCIONES' (ID 342)
        cmbUbicacion.SelectedValue = 342

        'RecorrerControles(pnlContenedor)
        comboTipoDev()

        ' Con esta condición se valida si se está dando de alta una devolución o se está editando una existente
        If NuevaDevolucion = True Then
            objPermisos = negocios.ValidaPermisosPantallas(0, "ALTA_EDICION", Usuario)
            Permisos(objPermisos)
        Else
            objPermisos = negocios.ValidaPermisosPantallas(objDev.Devolucionclienteid, "ALTA_EDICION", Usuario)
            ColocarParametros()
            colorEtiquetaEstatus()

            If objDev.Rutaautorizacion.ToString.Trim.Length > 0 Then
                btnVerAutorizacion.Enabled = True
            End If
            Permisos(objPermisos)
            'pnlAlmacen.Enabled = False
            grpbRecepcion.Enabled = False
            grpbArticulos.Enabled = False
            grpbPaqueteria.Enabled = False
            grpbComentarios.Enabled = False
            grpbResolucion.Enabled = False
            grpbResolucion_pnlVentas.Enabled = False
            btnGuardar.Enabled = False

            grpbVentas.Enabled = False
            'pnlComponentesCobranza.Enabled = False
            'grpObservacionesCobranza.Enabled = False
            btnGuardar_Ventas.Enabled = False
            'pnlVentasCobranza.Enabled = False
            grpbDiasProcesamiento.Enabled = False
        End If
        ColorEtiquetaResolucion()
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        If cmbCliente.Text.Trim = "" Or cmbCliente.SelectedValue Is Nothing Then
            LimpiarAtnCliente_Agente()
            btnGuardar.Enabled = False
            'bloquearDesbloquearBotones(False, False, False, False, False, False, False, False, False, False)
        Else
            Try
                Dim idClientes As Int32 = cmbCliente.SelectedValue
                ActualizarAtnCliente_Agente(idClientes)
                'bloquearDesbloquearBotones(False, False, False, False, False, False, False, False, False, True)
            Catch ex As Exception
                LimpiarAtnCliente_Agente()
                'bloquearDesbloquearBotones(False, False, False, False, False, False, False, False, False, False)
            End Try
        End If
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs)
        Dim FormularioFiltroPorPedidos As New DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
        FormularioFiltroPorPedidos.lblTitulo.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.lblNombreCliente.Text = cmbCliente.Text
        FormularioFiltroPorPedidos.idCliente = cmbCliente.SelectedValue
        FormularioFiltroPorPedidos.tipoConsulta = 1
        FormularioFiltroPorPedidos.filtroActual = txtIdentificadorDocumentos.Text.Split(",").ToList
        FormularioFiltroPorPedidos.Text = "Pedidos Por Cliente"
        FormularioFiltroPorPedidos.StartPosition = FormStartPosition.CenterScreen
        FormularioFiltroPorPedidos.ShowDialog(Me)
        If Not FormularioFiltroPorPedidos.DialogResult = Windows.Forms.DialogResult.OK Then Return
        tablaPedidosSeleccionados = FormularioFiltroPorPedidos.listaSeleccionados
        'txtPedidoSay.Text = SepararLista(tablaPedidosSeleccionados, "PedidoSAY")
        'txtPedidoSICY.Text = SepararLista(tablaPedidosSeleccionados, "PedidoSICY")
    End Sub

    Private Sub btnVerAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnVerAgregarDetalle.Click
        'Dim ventana As New Tools.AvisoForm
        'ventana.mensaje = "En esta parte se pueden seleccionar los artículos de la devolución, a partir de pedidos, documentos y/o lectura de códigos"
        'ventana.ShowDialog()
        Dim FormDetallesArticulos As New DevolucionCliente_CapturaGeneral_DetallesArticulos
        'FormDetallesArticulos.objDevolucion = objDev
        FormDetallesArticulos.idCliente = cmbCliente.SelectedValue
        FormDetallesArticulos.lblCliente.Text = cmbCliente.Text
        FormDetallesArticulos.documentosSeleccionados = objDev.IdentificadorDocumentos
        FormDetallesArticulos.pedidosSeleccionados = objDev.Pedidos
        FormDetallesArticulos.dtDocumentosSeleccionados = tablaDocumentosSeleccionados
        FormDetallesArticulos.dtPedidosSeleccionados = tablaPedidosSeleccionados
        FormDetallesArticulos.tipoDevolucion = cmbTipoDevolucion.Text
        FormDetallesArticulos.lblFolioDevolucion.Text = lblFolioDev.Text
        FormDetallesArticulos.unidadMedida = cmbUnidad.Text
        FormDetallesArticulos.idUnidadMedida = cmbUnidad.SelectedValue
        FormDetallesArticulos.objDevolucion = objDev
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
            'objDev.MotivoDev = cmbMotivoVentas.Text
            FormDetallesArticulos.tipoMotivo = 1
            FormDetallesArticulos.motivoDevolucion = cmbMotivoInicial.Text
            FormDetallesArticulos.idMotivoDevolucion = cmbMotivoInicial.SelectedValue
        Else
            FormDetallesArticulos.tipoMotivo = 2
            'objDev.MotivoDev = cmbMotivoInicial.Text
        End If
        FormDetallesArticulos.StartPosition = FormStartPosition.CenterScreen
        FormDetallesArticulos.ShowDialog(Me)

        ' Después de cerrar la pantalla de detalles se hace la consulta del monto y la cantidad total de pares
        ' para ser mostrada en las etiquetas correspondientes
        Dim dtCantidades As New DataTable
        dtCantidades = (New Negocios.DevolucionClientesBU).ConsultaMonto_Cantidad(objDev.Devolucionclienteid)

        If dtCantidades.Rows.Count > 0 Then
            ' Se hace la conversión 'CDbl' para dar formato y separación de miles
            lblCantidadTotal.Text = CDbl(dtCantidades.Rows(0).Item(0)).ToString("N0")
            lblMontoTotal.Text = "$" + CDbl(dtCantidades.Rows(0).Item(1)).ToString("N2")
        Else
            lblCantidadTotal.Text = "0"
            lblMontoTotal.Text = "$0.00"
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dtpFechaRecepcion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaRecepcion.ValueChanged
        dtpFechaLimite.Value = (dtpFechaRecepcion.Value).AddDays(15)
        lblNumSemana.Text = DatePart(DateInterval.WeekOfYear, dtpFechaRecepcion.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.System)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        vacios = False
        'ValidarCamposObligatorios(cmbTipoDevolucion, lblEtiquetaTipoDevolucion)
        'ValidarCamposObligatorios(cmbCliente, lblEtiquetaCliente)
        If cmbUbicacion.SelectedValue <> 220 Then
            ValidarCamposObligatorios(cmbEmpresa, lblEtiquetaEmpresa)
            ValidarCamposObligatorios(cmbFlete, lblEtiquetaFlete)
            ValidarCamposObligatorios(txtCosto, lblEtiquetaCosto)
        End If

        ValidarCamposObligatorios(cmbRecibio, lblEtiquetaRecibio)
        ValidarCamposObligatorios(txtCantidad, lblEtiquetaCantidad)
        ValidarCamposObligatorios(cmbUnidad, lblEtiquetaUnidad)
        ValidarCamposObligatorios(txtCajas, lblEtiquetaCajas)
        ValidarCamposObligatorios(cmbMotivoInicial, lblEtiquetaMotivoIniDev)
        If rdbProcedeAutoriza_pnlAlmacen.Checked = True Then
            ValidarCamposObligatorios(txtProcedeAutoriza_pnlAlmacen, lblEtiquetaProcede)
        End If

        If vacios = True Then
            ventanaAdvertencias.mensaje = "Los campos marcados con asterísco (*) son obligatorios"
            ventanaAdvertencias.ShowDialog()
            Return
        End If

        'objDev = New Entidades.DevolucionCliente
        objDev.Tipodevolucion = cmbTipoDevolucion.SelectedValue
        objDev.Clienteid = cmbCliente.SelectedValue
        If NuevaDevolucion = True Then
            objDev.Statusid = 303
        Else
            If rdbNoProcede_pnlAlmacen.Checked = True Then
                objDev.Statusid = ESTATUS_RESUELTA_PROCEDE
            Else
                objDev.Statusid = estatusId
            End If
        End If

        objDev.Resolucion = lblResolucion.Text
        objDev.Procedeautoriza = txtProcedeAutoriza_pnlAlmacen.Text
        objDev.Usuariocapturaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objDev.Fecharecepcion = dtpFechaRecepcion.Value
        objDev.Colaboradorid_recibio = cmbRecibio.SelectedValue
        objDev.Cantidad_inicial = txtCantidad.Text
        objDev.Unidadid = cmbUnidad.SelectedValue
        objDev.Cajas = txtCajas.Text
        objDev.Motivoinicialalmacen_statusid = cmbMotivoInicial.SelectedValue
        objDev.Observaciones_almacen = txtComentarios.Text
        objDev.Paqueteria_proveedorid = IIf(IsDBNull(cmbEmpresa.SelectedValue), 0, cmbEmpresa.SelectedValue)
        objDev.Tipofleteid = IIf(IsDBNull(cmbFlete.SelectedValue), 0, cmbFlete.SelectedValue)
        objDev.Costopaqueteria = IIf(txtCosto.Text.Length > 0, txtCosto.Text, 0)
        objDev.Numeroguia = txtNumeroGuia.Text
        'objDev.Modelos_say = txtModelos.Text
        'objDev.Colores_say = txtColores.Text
        'objDev.Corridas_say = txtCorridas.Text.Replace(".5", "½")
        objDev.Almacen_actual_estatusid = cmbUbicacion.SelectedValue
        objDev.Fechalimiteaccion = Date.Now.AddDays(15)
        objDev.DiasProcesamiento = nudDiasProcesamiento.Value
        'objDev.PedidosSAY = txtPedidoSay.Text
        objDev.ObservacionFactura = txtObservacionFactura.Text
        If tablaPedidosSeleccionados.Rows.Count > 0 Then
            Dim xmlPedidos As XElement = New XElement("Pedidos")
            For Each fila As DataRow In tablaPedidosSeleccionados.Rows
                Dim vNodo As XElement = New XElement("Pedido")
                vNodo.Add(New XAttribute("pedidoSAY", fila("PedidoSAY")))
                vNodo.Add(New XAttribute("pedidoSICY", fila("PedidoSICY")))
                xmlPedidos.Add(vNodo)
            Next
            objDev.Pedidos = xmlPedidos.ToString()
        End If
        Dim negocios As New Negocios.DevolucionClientesBU
        Dim Folio As New DataTable
        If lblFolioDev.Text = "-" Then
            Folio = negocios.RegistrarDevolucionCliente(objDev)
            ventanaExito.mensaje = "Se generó la devolución del cliente " & cmbCliente.Text & " con Folio " & Folio.Rows(0).Item(0).ToString
            ventanaExito.ShowDialog()
            btnVerAgregarDetalle.Enabled = True
            lblFechaUsuarioRegistro.Text = DateTime.Now & " (" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + ")"
            lblFolioDev.Text = Folio.Rows(0).Item(0).ToString
            objDev.Devolucionclienteid = CInt(Folio.Rows(0).Item(0).ToString)
        Else
            objDev.Devolucionclienteid = CInt(lblFolioDev.Text.ToString)
            objDev.Almacen_usuariomodificaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            negocios.ModificarDevolucionCliente(objDev, "ALMACÉN")
            ventanaExito.mensaje = "Se guardaron los cambios correctamente"
            ventanaExito.ShowDialog()
            If rdbNoProcede_pnlAlmacen.Checked = True Then
                lblStatus.Text = "RESUELTA NO PROCEDE"
            End If
        End If
        colorEtiquetaEstatus()
        objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
        Permisos(objPermisos)

        grpbRecepcion.Enabled = False
        grpbArticulos.Enabled = False
        grpbPaqueteria.Enabled = False
        grpbComentarios.Enabled = False
        grpbResolucion.Enabled = False
        btnGuardar.Enabled = False
        grpbDiasProcesamiento.Enabled = False
        'bloquearDesbloquearBotones(True, True, True, False, False, False, False, True, True, True)
    End Sub

    Private Sub btnSolicitarRevisionVentas_Click(sender As Object, e As EventArgs) Handles btnSolicitarRevisionVentas.Click
        Try
            Dim negocios As New Negocios.DevolucionClientesBU

            If lblClasificacion.Text = "CALIDAD" Then
                If objDev.Resolucion <> "PROCEDE" Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Aún no se ha definido una resolución válida para solicitar revisión de ventas")
                    Exit Sub
                End If
            End If

            ventanaConfirmacion.mensaje = "¿Está seguro de solicitar revisión de ventas?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
            negocios.CambiarEstatusDevolucion(CInt(lblFolioDev.Text), ESTATUS_EN_REVISION, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
            ventanaExito.mensaje = "Ventas tiene hasta el " + (dtpFechaRecepcion.Value).AddDays(6).ToShortDateString + " para indicarle el tratamiento de devolución del cliente " + cmbCliente.Text + " con Folio " + lblFolioDev.Text
            ventanaExito.ShowDialog()
            lblStatus.Text = "EN REVISIÓN"
            lblStatus.ForeColor = Color.Blue

            lblEnviadoARevision.Text = DateTime.Now & " (" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + ")"
            colorEtiquetaEstatus()

            objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
            Permisos(objPermisos)

            grpbRecepcion.Enabled = False
            grpbArticulos.Enabled = False
            grpbPaqueteria.Enabled = False
            grpbComentarios.Enabled = False
            grpbResolucion.Enabled = False
            grpbResolucion_pnlVentas.Enabled = False
            btnGuardar.Enabled = False

        Catch ex As Exception
            ventanaError.mensaje = "Ocurrió un error " + ex.Message
            ventanaError.ShowDialog()
        End Try

    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Dim busquedaCliente As New Devolucioncliente_CapturaGeneral_Busqueda_Form
        Dim idCliente As Int32
        'busquedaCliente.StartPosition = FormStartPosition.CenterParent
        busquedaCliente.ShowDialog(Me)
        If Not busquedaCliente.DialogResult = Windows.Forms.DialogResult.OK Then Return
        idCliente = busquedaCliente.rowCliente(1)
        cmbCliente.SelectedValue = idCliente
        ActualizarAtnCliente_Agente(idCliente)
    End Sub

    Private Sub cmbEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedValueChanged
        If cmbEmpresa.Text.ToString.Length > 0 Then
            If cmbEmpresa.Text = "CLIENTE (ENTREGA)" Or cmbEmpresa.Text = "YUYIN (NOSOTROS MISMOS)" Then
                cmbFlete.SelectedValue = "2"
                cmbFlete.Enabled = False
                txtCosto.Text = 0
                txtCosto.ReadOnly = True
            Else
                cmbFlete.SelectedIndex = 0
                cmbFlete.Enabled = True
                txtCosto.ReadOnly = False
            End If
        End If

    End Sub

    Private Sub btnDocumentosRelacionados_Click(sender As Object, e As EventArgs) Handles btnDocumentosRelacionados.Click
        Dim FormularioDocumentos As New DevolucionCliente_Filtro_Documentos_PorCliente_Form
        FormularioDocumentos.lblNombreCliente.Text = cmbCliente.Text
        FormularioDocumentos.idCliente = cmbCliente.SelectedValue
        'FormularioDocumentos.filtroActual = txtDocumentosRelacionados.Text.Split(",").ToList
        FormularioDocumentos.filtroActual = objDev.Documentosdetalles.Split(",").ToList
        'FormularioDocumentos.lblColores.Text = txtColores.Text
        'FormularioDocumentos.lblModelos.Text = txtModelos.Text
        'FormularioDocumentos.lblCorridas.Text = txtCorridas.Text
        FormularioDocumentos.pedidosSeleccionados = tablaPedidosSeleccionados
        'FormularioDocumentos.idPedidos = txtPedidoSay.Text
        FormularioDocumentos.StartPosition = FormStartPosition.CenterScreen
        FormularioDocumentos.ShowDialog(Me)
        If Not FormularioDocumentos.DialogResult = Windows.Forms.DialogResult.OK Then Return
        tablaDocumentosSeleccionados = FormularioDocumentos.listaSeleccionados
        txtDocumentosRelacionados.Text = SepararLista(tablaDocumentosSeleccionados, "DoctoSeleccionado")
        txtIdentificadorDocumentos.Text = SepararLista(tablaDocumentosSeleccionados, "DoctoSAY")
        objDev.Documentosdetalles = SepararLista(tablaDocumentosSeleccionados, "DetalleDoctoID")
        btnGuardar_Ventas.Enabled = True
    End Sub

    Private Sub cmbDestinoProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDestinoProducto.SelectedValueChanged
        If cmbDestinoProducto.Text = "DESTRUCCIÓN" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (BLOQUEADO)" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (DISPONIBLE)" Or cmbDestinoProducto.Text = "ENVIAR A STOCK (ESPECIAL)" Then
            lblReqAutorizacion.Text = "SI"
            lblReqAutorizacion.ForeColor = Color.Tomato
            btnAnexarAutorizacion.Enabled = True
            'btnVerAutorizacion.Enabled = True
        ElseIf cmbDestinoProducto.Text = "ENTREGA (REFACTURAR)" Or cmbDestinoProducto.Text = "RE-ENTREGA (MISMOS DOCUMENTOS)" Then
            lblReqAutorizacion.Text = "NO"
            lblReqAutorizacion.ForeColor = Color.Green
            btnAnexarAutorizacion.Enabled = False
            'btnVerAutorizacion.Enabled = False
        End If
    End Sub

    Private Sub btnCerrarVentas_Click(sender As Object, e As EventArgs) Handles btnCerrarVentas.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Ventas_Click(sender As Object, e As EventArgs) Handles btnGuardar_Ventas.Click
        vacios = False
        Dim abierta As Boolean = False
        Dim negocios As New Negocios.DevolucionClientesBU
        Dim Folio As New DataTable

        ValidarCamposObligatorios(txtIndicaRecepcion, lblEtiquetaIndicaRecepcion)
        ValidarCamposObligatorios(cmbDestinoProducto, lblEtiquetaDestinoProd)
        ValidarCamposObligatorios(cmbResponsable, lblEtiquetaResponsable)
        ValidarCamposObligatorios(cmbMotivoVentas, lblEtiquetaMotivoVentas)

        If objPermisos.PnlVentas = True Then
            'If vacios = True Then
            '    ventanaConfirmacion.mensaje = "Si no guarda toda la información obligatoria, la devolución regresará a estatus ABIERTA, y el área de DEVOLUCIONES se la deberá enviar nuevamente para revisión" + vbCrLf + "¿Desea continuar?"
            '    ventanaConfirmacion.ShowDialog()
            '    If ventanaConfirmacion.DialogResult <> DialogResult.OK Then
            '        Return
            '    End If
            'End If

            'objDev = New Entidades.DevolucionCliente
            objDev.Fecharecepcion = dtpFechaRecepcion.Value
            objDev.Fechalimiteaccion = dtpFechaLimite.Value
            objDev.Dias_transcurridosventas = 10
            objDev.Indicarecepcion = txtIndicaRecepcion.Text
            objDev.Motivoventas_statusid = cmbMotivoVentas.SelectedValue
            objDev.Destinoproducto = cmbDestinoProducto.SelectedValue
            If lblReqAutorizacion.Text = "NO" Then
                objDev.Requiereautorizacion = 0
            Else
                objDev.Requiereautorizacion = 1
            End If
            'objDev.Rutaautorizacion = t
            If rdbAplicaNotaCreditoNO.Checked = True Then
                objDev.Aplicanotacredito = 0
            Else
                objDev.Aplicanotacredito = 1
            End If
            objDev.Responsabledevolucion_estatusid = cmbResponsable.SelectedValue
            objDev.Observaciones_ventas = txtObservaciones_Ventas.Text
            objDev.Ventas_usuariomodificaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objDev.Resolucion = lblResolucion.Text
            If chkSinDocumentos.Checked = True Then
                objDev.SinDocumentos = 1
            ElseIf tablaDocumentosSeleccionados.Rows.Count > 0 Then
                Dim xmlDocumentos As XElement = New XElement("Documentos")
                For Each fila As DataRow In tablaDocumentosSeleccionados.Rows
                    Dim vNodo As XElement = New XElement("Documento")
                    Dim total As Decimal
                    vNodo.Add(New XAttribute("documentoSAYId", fila("DoctoSAY")))
                    vNodo.Add(New XAttribute("remisionID", fila("Documento")))
                    vNodo.Add(New XAttribute("anioDocumento", fila("Año")))
                    vNodo.Add(New XAttribute("foliofactura", fila("FolioFactura")))
                    vNodo.Add(New XAttribute("totaldocumento", fila("TotalDocumento")))
                    vNodo.Add(New XAttribute("saldo", fila("Saldo")))
                    vNodo.Add(New XAttribute("documentodetalleid", fila("DetalleDoctoID")))
                    vNodo.Add(New XAttribute("partida", fila("Partida")))
                    vNodo.Add(New XAttribute("productoestiloid", fila("ProductoEstiloID")))
                    vNodo.Add(New XAttribute("cantidadpares", fila("Pares")))
                    vNodo.Add(New XAttribute("paresdevolucion", fila("ParesDevolución")))
                    vNodo.Add(New XAttribute("tipo", IIf(fila("ParesDevolución") = fila("Pares"), "C", "P")))
                    If fila("Pares") = fila("ParesDevolución") Then
                        total = fila("TotalPartida")
                    Else
                        total = (CDec(fila("TotalPartida")) / CInt(fila("Pares"))) * CInt(fila("ParesDevolución"))
                    End If
                    vNodo.Add(New XAttribute("totalpartida", total))
                    xmlDocumentos.Add(vNodo)
                Next
                objDev.XMLDocumentos = xmlDocumentos.ToString()
                objDev.IdentificadorDocumentos = txtIdentificadorDocumentos.Text
                objDev.SinDocumentos = 0
            End If

            If lblReqAutorizacion.Text = "SI" And objDev.Rutaautorizacion.ToString.Trim.Length = 0 Then
                ventanaAdvertencias.mensaje = "El destino de producto seleccionado requiere anexar una autorización"
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            If chkSinDocumentos.Checked = True And Not String.IsNullOrEmpty(txtDocumentosRelacionados.Text) Then
                ventanaAdvertencias.mensaje = "Hay documentos seleccionados, desmarque la casilla SIN DOCUMENTOS."
                ventanaAdvertencias.ShowDialog()
                Return
            ElseIf chkSinDocumentos.Checked = False And String.IsNullOrEmpty(txtDocumentosRelacionados.Text) Then
                ventanaAdvertencias.mensaje = "Marque la casilla SIN DOCUMENTOS en caso de que no apliquen documentos relacionados."
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            objDev.Devolucionclienteid = lblFolioDev.Text.ToString
            negocios.ModificarDevolucionCliente(objDev, "VENTAS")
            'If vacios = True Then
            '    negocios.CambiarEstatusDevolucion(objDev.Devolucionclienteid, ESTATUS_ABIERTA, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
            '    lblStatus.Text = "ABIERTA"
            '    colorEtiquetaEstatus()
            'End If
            ventanaExito.mensaje = "Se guardaron los cambios correctamente"
            ventanaExito.ShowDialog()

            lblModificacionVentas.Text = DateTime.Now.ToString & " (" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & ")"
        ElseIf objPermisos.PnlCobranza = True Then
            'objDev.Observaciones_cobranza = txtObservaciones_Cobranza.Text
            'objDev.Cantidadtotal = txtCantidad.Text
            If lblDevolucionSICY.Text <> "-" Then
                objDev.Devolucionsicyid = lblDevolucionSICY.Text
            End If
            objDev.Cantidad_aplicado = lblCantidadAplicada.Text
            objDev.Cantidad_poraplicar = lblCantidadPorAplicar.Text
            objDev.Cobranza_usuarioModificaid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            objDev.Devolucionclienteid = lblFolioDev.Text.ToString
            negocios.ModificarDevolucionCliente(objDev, "COBRANZA")
            ventanaExito.mensaje = "Se guardaron los cambios correctamente"
            ventanaExito.ShowDialog()

            'lblModificacionCobranza.Text = DateTime.Now.ToString & " (" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & ")"
        End If

        objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
        Permisos(objPermisos)
        grpbVentas.Enabled = False
        'grpbCobranza.Enabled = False
        grpbResolucion_pnlVentas.Enabled = False
        btnGuardar_Ventas.Enabled = False
    End Sub

    Private Sub VisualizarPDF(ByVal CarpetaOrigen As String, ByVal Archivo As String)
        Dim objFTP As New Tools.TransferenciaFTP
        Dim CarpetaDestino As String

        CarpetaDestino = Path.GetTempPath

        objFTP.DescargarArchivo(CarpetaOrigen, CarpetaDestino, Archivo)

        CarpetaDestino = CarpetaDestino + Archivo
        Process.Start(CarpetaDestino)
    End Sub

    Private Sub btnVerAutorizacion_Click(sender As Object, e As EventArgs) Handles btnVerAutorizacion.Click
        Dim lsArchivos As New List(Of String)
        Dim NombreArchivoPDF As String = objDev.Rutaautorizacion.ToString
        'Dim j As Integer = ContarEtiquetasEspeciales()
        Try
            If NombreArchivoPDF.Length > 0 Then
                Dim objFTP As New Tools.TransferenciaFTP
                Dim CarpetaOrigen As String = ""
                Dim CarpetaDestino As String = Path.GetTempPath
                lsArchivos = NombreArchivoPDF.ToString.Split("/").ToList
                Dim archivo As String = lsArchivos.Last
                'Ventas/FTC/Cliente_379/DevolucionesCLIENTE_379_DEVOLUCION_60402_105129.pdf
                objFTP.DescargarArchivo("Ventas/FTC/Cliente_" + cmbCliente.SelectedValue.ToString + "/Devoluciones", CarpetaDestino, archivo)

                CarpetaDestino = CarpetaDestino + archivo
                Process.Start(CarpetaDestino)
            Else
                Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                ventanaAdvertencia.mensaje = "No hay autorización anexa"
                ventanaAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            Dim ventanaError As New Tools.AdvertenciaForm
            ventanaError.mensaje = "Ocurrió un error, aseguresé de que el archivo exista " + ex.Message
            ventanaError.ShowDialog()
        End Try
    End Sub

    Private Sub btnSolicitarProcesamientoAlmacen_Click(sender As Object, e As EventArgs) Handles btnSolicitarProcesamientoAlmacen.Click
        If objDev.Resolucion = "PROCEDE" Or objDev.Resolucion = "PROCEDE (AUTORIZADA)" Then
            If CInt(lblCantidadTotal.Text) = 0 Then
                ventanaAdvertencias.mensaje = "La devolución aún no tienen detalles capturados. Solicite al departamento de devoluciones la captura de los artículos"
                ventanaAdvertencias.ShowDialog()
                Exit Sub
            End If

            Try
                Dim negocios As New Negocios.DevolucionClientesBU
                ventanaConfirmacion.mensaje = "¿Está seguro de solicitar procesamiento de almacén?"
                ventanaConfirmacion.ShowDialog()
                If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                negocios.CambiarEstatusDevolucion(CInt(lblFolioDev.Text), ESTATUS_EN_PROCESO, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
                colorEtiquetaEstatus()
                lblEnviadoARevision.Text = DateTime.Now & " (" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + ")"

                Dim ventana As New Tools.AvisoForm
                ventana.mensaje = "Almacén tiene 24 horas para concluir la atención de la devolución Folio " & lblFolioDev.Text & " del cliente " & cmbCliente.Text
                ventana.ShowDialog()

                lblStatus.Text = "EN PROCESO"
                lblStatus.ForeColor = Color.Purple

                objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
                Permisos(objPermisos)
            Catch ex As Exception
                ventanaError.mensaje = "Ocurrió un error " + ex.Message
                ventanaError.ShowDialog()
            End Try
        Else
            ventanaAdvertencias.mensaje = "No puede solicitar procesamiento a almacén sobre el folio " + objDev.Devolucionclienteid.ToString + " debido a que el área de Ventas no ha cambiado la resolución de PENDIENTE a PROCEDE o  PROCEDE AUTORIZADA, solicite el cambio de resolución."
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub btnAnexarAutorizacion_Click(sender As Object, e As EventArgs) Handles btnAnexarAutorizacion.Click
        Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
        Dim Carpeta As String = "Ventas/FTC/Cliente_" + cmbCliente.SelectedValue.ToString + "/Devoluciones/"
        Dim objFTP As New Tools.TransferenciaFTP

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf"

        Try
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim viejoNombre As String
                Dim nuevoNombre As String
                Dim OrigenArchivo_Split() As String
                Dim Fecha_Archivo As New DateTime
                Dim archivo As String

                Fecha_Archivo = DateTime.Now

                OrigenArchivo_Split = Split(OpenFileDialog1.FileName, "\")

                If File.Exists("c:\Export_PDF") = False Then
                    Directory.CreateDirectory("c:\Export_PDF")
                End If

                viejoNombre = OpenFileDialog1.FileName
                nuevoNombre = "c:\Export_PDF\"

                archivo = "CLIENTE_" + cmbCliente.SelectedValue.ToString + "_DEVOLUCION_" + lblFolioDev.Text.ToString

                If Fecha_Archivo.Month < 10 Then
                    archivo += "0" + Fecha_Archivo.Month.ToString
                Else
                    archivo += Fecha_Archivo.Month.ToString
                End If

                If Fecha_Archivo.Day < 10 Then
                    archivo += "0" + Fecha_Archivo.Day.ToString
                Else
                    archivo += Fecha_Archivo.Day.ToString
                End If

                If Fecha_Archivo.Hour < 10 Then
                    archivo += "_0" + Fecha_Archivo.Hour.ToString
                Else
                    archivo += "_" + Fecha_Archivo.Hour.ToString
                End If

                If Fecha_Archivo.Minute < 10 Then
                    archivo += "0" + Fecha_Archivo.Minute.ToString
                Else
                    archivo += Fecha_Archivo.Minute.ToString
                End If

                If Fecha_Archivo.Second < 10 Then
                    archivo += "0" + Fecha_Archivo.Second.ToString + ".pdf"
                Else
                    archivo += Fecha_Archivo.Second.ToString + ".pdf"
                End If

                FileCopy(viejoNombre, nuevoNombre.ToString + archivo.ToString)
                objFTP.EnviarArchivo(Carpeta, nuevoNombre.ToString + archivo.ToString)
                UltimoArchivo = nuevoNombre
                'ArchivoPDF_CargadoEnFTP = True
                My.Computer.FileSystem.DeleteFile(nuevoNombre.ToString + archivo.ToString, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)


                'ACTUALIZAMOS LA INFORMACION DE INFOCLIENTE
                Dim objBU As New Negocios.DevolucionClientesBU
                objBU.ActualizarRutaAutorizacion(CInt(lblFolioDev.Text), Carpeta.ToString + "" + archivo.ToString)
                objDev.Rutaautorizacion = Carpeta.ToString + "" + archivo.ToString

                ventanaExito.mensaje = "Archivo subido correctamente"
                ventanaExito.ShowDialog()
            End If

        Catch ex As Exception
            ventanaError.mensaje = "Ocurrio un error inesperado: " + ex.Message
            ventanaError.ShowDialog()
        End Try
    End Sub

    Private Sub chkSinDocumentos_Click(sender As Object, e As EventArgs) Handles chkSinDocumentos.Click
        If chkSinDocumentos.Checked = True Then
            btnDocumentosRelacionados.Enabled = False
        Else
            btnDocumentosRelacionados.Enabled = objPermisos.ControlDocumentos
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        grpbRecepcion.Enabled = objPermisos.PnlAlmacen
        grpbArticulos.Enabled = objPermisos.PnlAlmacen
        grpbPaqueteria.Enabled = objPermisos.PnlAlmacen
        grpbComentarios.Enabled = objPermisos.PnlAlmacen
        grpbResolucion.Enabled = objPermisos.GrpbResolucion_pnlAlmacen
        btnGuardar.Enabled = objPermisos.BtnGuardar_pnlAlmacen

        'pnlComponentesCobranza.Enabled = objPermisos.PnlCobranza
        'grpObservacionesCobranza.Enabled = objPermisos.PnlCobranza
        grpbVentas.Enabled = objPermisos.PnlVentas
        grpbResolucion_pnlVentas.Enabled = objPermisos.GrpbResolucion_pnlVentas
        btnGuardar_Ventas.Enabled = objPermisos.BtnGuardar_Ventas

        cmbMotivoInicial_SelectedValueChanged(Nothing, Nothing)

    End Sub

    Private Sub btnSolicitarNotaCredito_Click(sender As Object, e As EventArgs) Handles btnSolicitarNotaCredito.Click
        If CInt(lblCantidadTotal.Text) = 0 Then
            ventanaAdvertencias.mensaje = "La devolución aún no tienen detalles capturados. Solicite al departamento de devoluciones la captura de los artículos"
            ventanaAdvertencias.ShowDialog()
            Exit Sub
        End If
        If objDev.Resolucion = "PROCEDE" Or objDev.Resolucion = "PROCEDE (AUTORIZADA)" Then
            'If objPermisos.Area = "ALMACÉN" And objDev.Tipodevolucion = "MENUDEO" Then
            '
            'End If

            Dim dtPrecioCero As DataTable = (New Negocios.DevolucionClientesBU).ConsultaDetalles_PrecioCero(objDev.Devolucionclienteid)
            If dtPrecioCero.Rows.Count > 0 Then
                Dim formPrecioCero As New DevolucionCliente_CapturaGeneral_PartidasPrecioCero
                formPrecioCero.dtDetalles = dtPrecioCero
                formPrecioCero.StartPosition = FormStartPosition.CenterParent
                formPrecioCero.ShowDialog()
                Exit Sub
            Else
                ventanaConfirmacion.mensaje = "¿Está seguro de solicitar Nota de Crédito?"
                ventanaConfirmacion.ShowDialog()
                If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                Try
                    Dim negocios As New Negocios.DevolucionClientesBU
                    Dim dtResultado As New DataTable

                    dtResultado = negocios.SolicitarNotaCredito(CInt(lblFolioDev.Text), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    If dtResultado.Rows.Count > 1 Then
                        ventanaError.mensaje = "Ocurrió un error, " + dtResultado.Rows(0).Item(0).ToString
                    Else
                        objDev.Devolucionsicyid = dtResultado.Rows(0).Item(0)
                        lblDevolucionSICY.Text = objDev.Devolucionsicyid.ToString
                        ventanaExito.mensaje = "Se ha solicitado la nota de crédito a cobranza." + vbCrLf + "Folio de devolución SICY: " + objDev.Devolucionsicyid.ToString
                        ventanaExito.ShowDialog()
                        btnSolicitarNotaCredito.Enabled = False
                    End If

                    If objDev.Tipodevolucion <> "MENUDEO" Then
                        negocios.CambiarEstatusDevolucion(CInt(lblFolioDev.Text), ESTATUS_EN_PROCESO, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
                        lblStatus.Text = "EN PROCESO"
                        lblStatus.ForeColor = Color.Purple
                    Else
                        lblStatus.Text = "ESTATUS RESUELTA PROCEDE"
                        lblStatus.ForeColor = Color.Green
                    End If


                    colorEtiquetaEstatus()

                    objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
                    Permisos(objPermisos)

                    rdbAplicaNotaCreditoSI.Checked = True

                Catch ex As Exception
                    ventanaError.mensaje = "Ocurrió un error " + ex.Message
                    ventanaError.ShowDialog()
                End Try
            End If
        Else
            ventanaAdvertencias.mensaje = "No puede solicitar nota de crédito sobre el folio " + objDev.Devolucionclienteid.ToString + " debido a que el área de Devoluciones no la ha cambiado la resolución de PENDIENTE a PROCEDE o  PROCEDE AUTORIZADA, solicite el cambio de resolución."
            ventanaAdvertencias.ShowDialog()
        End If

    End Sub

    Private Sub rdbPendiente_pnlAlmacen_Click(sender As Object, e As EventArgs) Handles rdbPendiente_pnlAlmacen.Click
        If rdbPendiente_pnlAlmacen.Checked = True Then
            txtProcedeAutoriza_pnlAlmacen.Enabled = False
            rdbPendiente_pnlVentas.Checked = True
            lblResolucion.Text = "PENDIENTE"
            lblResolucion.ForeColor = Color.Orange
            rdbAplicaNotaCreditoSI.Enabled = False
            rdbAplicaNotaCreditoNO.Enabled = False
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbProcede_pnlAlmacen_Click(sender As Object, e As EventArgs) Handles rdbProcede_pnlAlmacen.Click
        If rdbProcede_pnlAlmacen.Checked = True Then
            txtProcedeAutoriza_pnlAlmacen.Enabled = False
            lblResolucion.Text = "PROCEDE"
            rdbProcede_pnlVentas.Checked = True
            lblResolucion.ForeColor = Color.Green
            rdbAplicaNotaCreditoSI.Enabled = True
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbNoProcede_pnlAlmacen_Click(sender As Object, e As EventArgs) Handles rdbNoProcede_pnlAlmacen.Click
        If rdbNoProcede_pnlAlmacen.Checked = True Then
            If (objDev.Statusid <> 303 And objDev.Statusid <> 304 And objDev.Statusid <> 331) And objDev.Resolucion <> "NO PROCEDE" Then
                ventanaAdvertencias.mensaje = "No se pueden aplicar las acciones solicitadas. Para realizar el cambio la devolución debe estar en estatus de ABIERTA, SOLICITA DOCUMENTOS o EN REVISIÓN. " + vbCrLf + " Estatus actual: " + objDev.Estatus.ToString
                ventanaAdvertencias.ShowDialog()

                For Each control In grpbResolucion.Controls
                    If TypeOf (control) Is RadioButton Then
                        Dim radio As New RadioButton
                        radio = control
                        If radio.Text.ToUpper = objDev.Resolucion Then
                            radio.Checked = True
                        End If
                    End If
                Next

            Else
                txtProcedeAutoriza_pnlAlmacen.Enabled = False
                lblResolucion.Text = "NO PROCEDE"
                rdbNoProcede_pnlVentas.Checked = True
                lblResolucion.ForeColor = Color.Red
                rdbAplicaNotaCreditoSI.Enabled = False
                rdbAplicaNotaCreditoNO.Enabled = False
                rdbAplicaNotaCreditoNO.Checked = True
            End If
        End If
    End Sub

    Private Sub rdbProcedeAutoriza_pnlAlmacen_Click(sender As Object, e As EventArgs) Handles rdbProcedeAutoriza_pnlAlmacen.Click
        lblEtiquetaProcede.ForeColor = Color.Black

        If rdbProcedeAutoriza_pnlAlmacen.Checked = True Then
            lblResolucion.Text = "PROCEDE (AUTORIZADA)"
            rdbProcedeAutoriza_pnlVentas.Checked = True
            lblResolucion.ForeColor = Color.Blue
            rdbAplicaNotaCreditoSI.Enabled = True
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoNO.Checked = True
            txtProcedeAutoriza_pnlAlmacen.Enabled = True
            'If objDev.Procedeautoriza.ToString.Length > 0 Then
            '    txtProcedeAutoriza.Text = objDev.Procedeautoriza
            'End If
            txtProcedeAutoriza_pnlAlmacen.Enabled = True
            txtProcedeAutoriza_pnlAlmacen.Select()
        Else
            txtProcedeAutoriza_pnlAlmacen.Text = ""
            txtProcedeAutoriza_pnlAlmacen.Enabled = False
        End If
    End Sub

    Private Sub rdbPendiente_pnlVentas_Click(sender As Object, e As EventArgs) Handles rdbPendiente_pnlVentas.Click
        If rdbPendiente_pnlVentas.Checked = True Then
            txtProcedeAutoriza_pnlVentas.Enabled = False
            lblResolucion.Text = "PENDIENTE"
            rdbPendiente_pnlAlmacen.Checked = True
            lblResolucion.ForeColor = Color.Orange
            rdbAplicaNotaCreditoSI.Enabled = False
            rdbAplicaNotaCreditoNO.Enabled = False
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbProcede_pnlVentas_Click(sender As Object, e As EventArgs) Handles rdbProcede_pnlVentas.Click
        If rdbProcede_pnlVentas.Checked = True Then
            txtProcedeAutoriza_pnlVentas.Enabled = False
            lblResolucion.Text = "PROCEDE"
            rdbProcede_pnlAlmacen.Checked = True
            lblResolucion.ForeColor = Color.Green
            rdbAplicaNotaCreditoSI.Enabled = True
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoNO.Checked = True
        End If
    End Sub

    Private Sub rdbNoProcede_pnlVentas_Click(sender As Object, e As EventArgs) Handles rdbNoProcede_pnlVentas.Click
        If rdbNoProcede_pnlVentas.Checked = True Then
            If (objDev.Statusid <> 303 And objDev.Statusid <> 304 And objDev.Statusid <> 331) And objDev.Resolucion <> "NO PROCEDE" Then
                ventanaAdvertencias.mensaje = "No se pueden aplicar las acciones solicitadas. Para realizar el cambio la devolución debe estar en estatus de ABIERTA, SOLICITA DOCUMENTOS o EN REVISIÓN. " + vbCrLf + " Estatus actual: " + objDev.Estatus.ToString
                ventanaAdvertencias.ShowDialog()

                For Each control In grpbResolucion.Controls
                    If TypeOf (control) Is RadioButton Then
                        Dim radio As New RadioButton
                        radio = control
                        If radio.Text.ToUpper = objDev.Resolucion Then
                            radio.Checked = True
                        End If
                    End If
                Next

            Else
                lblResolucion.Text = "NO PROCEDE"
                txtProcedeAutoriza_pnlVentas.Enabled = False
                rdbNoProcede_pnlAlmacen.Checked = True
                lblResolucion.ForeColor = Color.Red
                rdbAplicaNotaCreditoSI.Enabled = False
                rdbAplicaNotaCreditoNO.Enabled = False
                rdbAplicaNotaCreditoNO.Checked = True
            End If
        End If
    End Sub

    Private Sub rdbProcedeAutoriza_pnlVentas_Click(sender As Object, e As EventArgs) Handles rdbProcedeAutoriza_pnlVentas.Click
        lblEtiquetaProcede.ForeColor = Color.Black

        If rdbProcedeAutoriza_pnlVentas.Checked = True Then
            lblResolucion.Text = "PROCEDE (AUTORIZADA)"
            rdbProcedeAutoriza_pnlAlmacen.Checked = True
            lblResolucion.ForeColor = Color.Blue
            rdbAplicaNotaCreditoSI.Enabled = True
            rdbAplicaNotaCreditoNO.Enabled = True
            rdbAplicaNotaCreditoNO.Checked = True
            txtProcedeAutoriza_pnlAlmacen.Enabled = True
            'If objDev.Procedeautoriza.ToString.Length > 0 Then
            '    txtProcedeAutoriza.Text = objDev.Procedeautoriza
            'End If
            txtProcedeAutoriza_pnlVentas.Enabled = True
            txtProcedeAutoriza_pnlVentas.Select()
        Else
            txtProcedeAutoriza_pnlVentas.Text = ""
            txtProcedeAutoriza_pnlVentas.Enabled = False
        End If
    End Sub

    Public Sub FormatoGrid()
        bgvNotasCredito.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvNotasCredito.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            End If
        Next
        'bgvNotasCredito.BestFitColumns()
        bgvNotasCredito.IndicatorWidth = 40
        bgvNotasCredito.OptionsView.ShowAutoFilterRow = False
        bgvNotasCredito.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

        bgvNotasCredito.Columns.ColumnByFieldName("AplicadoDocumento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvNotasCredito.Columns.ColumnByFieldName("TotalNC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvNotasCredito.Columns.ColumnByFieldName("AplicadoDocumento").DisplayFormat.FormatString = "N2"
        bgvNotasCredito.Columns.ColumnByFieldName("TotalNC").DisplayFormat.FormatString = "N2"

        bgvNotasCredito.Columns.ColumnByFieldName("Aplicada").Visible = False
        bgvNotasCredito.Columns.ColumnByFieldName("PorAplicar").Visible = False

        If IsNothing(bgvNotasCredito.Columns("AplicadoDocumento").Summary.FirstOrDefault(Function(x) x.FieldName = "AplicadoDocumento")) = True Then
            bgvNotasCredito.Columns("AplicadoDocumento").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "AplicadoDocumento", "{0:N2}")

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "AplicadoDocumento"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            bgvNotasCredito.GroupSummary.Add(item)
        End If

        If IsNothing(bgvNotasCredito.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            bgvNotasCredito.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N0}"
            bgvNotasCredito.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub bgvNotasCredito_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvNotasCredito.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_Tab_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Cursor = Cursors.WaitCursor
        ConsultarNC_Dev()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        If bgvNotasCredito.DataRowCount > 0 Then
            Dim fbdUbicacion As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try
                nombreReporte = "\NotasDeCredito_Devoluciones_Clientes"
                With fbdUbicacion
                    .Reset()
                    .Description = "Selecciona una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim exportOptions As New DevExpress.XtraPrinting.XlsxExportOptionsEx()
                        exportOptions.ExportType = DevExpress.Export.ExportType.DataAware

                        bgvNotasCredito.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        ventanaExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        ventanaExito.ShowDialog()
                        Process.Start(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If

                End With
            Catch ex As Exception
                ventanaError.mensaje = "Ocurrió un error: " + ex.Message.ToString
                ventanaError.ShowDialog()
            End Try
        Else
            ventanaAdvertencias.mensaje = "No hay datos para exportar"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub bgvNotasCredito_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles bgvNotasCredito.RowStyle
        Dim residuo As Int16 = e.RowHandle Mod 2
        If residuo = 0 Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.LightSteelBlue
        End If

    End Sub

    Private Sub cmbMotivoInicial_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivoInicial.SelectedValueChanged
        If cmbMotivoInicial.SelectedIndex > 0 Then
            For Each row In dtMotivos.Rows
                If row("esta_estatusid").ToString <> "" Then
                    If row("esta_estatusid") = cmbMotivoInicial.SelectedValue Then
                        lblClasificacion.Text = row("TipoMotivo").ToString

                        If lblClasificacion.Text = "CALIDAD" Then
                            grpbDiasProcesamiento.Enabled = objPermisos.PnlAlmacen
                        Else
                            nudDiasProcesamiento.Value = 0
                            grpbDiasProcesamiento.Enabled = False
                        End If

                        Exit Sub
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btnSolicitarDocumentos_Click(sender As Object, e As EventArgs) Handles btnSolicitarDocumentos.Click
        Try
            Dim negocios As New Negocios.DevolucionClientesBU

            ventanaConfirmacion.mensaje = "¿Está seguro de solicitar documentos a ventas?"
            ventanaConfirmacion.ShowDialog()

            If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return

            negocios.CambiarEstatusDevolucion(CInt(lblFolioDev.Text), ESTATUS_SOLICITA_DOCUMENTOS, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
            ventanaExito.mensaje = "Ventas tiene hasta el " + (dtpFechaRecepcion.Value).AddDays(6).ToShortDateString + " para indicarle el tratamiento de devolución del cliente " + cmbCliente.Text + " con Folio " + lblFolioDev.Text
            ventanaExito.ShowDialog()
            lblStatus.Text = "SOLICITA DOCUMENTOS"
            lblStatus.ForeColor = Color.Blue

            lblEnviadoARevision.Text = DateTime.Now & " (" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + ")"
            colorEtiquetaEstatus()

            objPermisos = negocios.ValidaPermisosPantallas(CInt(lblFolioDev.Text.ToString), "ALTA_EDICION", Usuario)
            Permisos(objPermisos)

            grpbRecepcion.Enabled = False
            grpbArticulos.Enabled = False
            grpbPaqueteria.Enabled = False
            grpbComentarios.Enabled = False
            grpbResolucion.Enabled = False
            grpbResolucion_pnlVentas.Enabled = False
            btnGuardar.Enabled = False

        Catch ex As Exception
            ventanaError.mensaje = "Ocurrió un error " + ex.Message
            ventanaError.ShowDialog()
        End Try

    End Sub

    Private Sub cmbTipoDevolucion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDevolucion.SelectedIndexChanged
        If cmbTipoDevolucion.SelectedIndex = 1 Then
            cmbMotivoInicial.SelectedValue = 372
            cmbMotivoInicial.Enabled = False
            grpbDiasProcesamiento.Enabled = False
        Else
            cmbMotivoInicial.SelectedIndex = 0
            cmbMotivoInicial.Enabled = True
            grpbDiasProcesamiento.Enabled = True
        End If
    End Sub

    Private Sub cmbMotivoInicial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotivoInicial.SelectedIndexChanged
        If cmbMotivoInicial.Text = "DETALLE CALIDAD" Then

        End If
    End Sub

    Private Sub cmbUbicacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedValueChanged
        Try
            If cmbUbicacion.SelectedValue = 220 Then
                cmbEmpresa.Enabled = False
                cmbEmpresa.SelectedIndex = 0
                cmbFlete.Enabled = False
                cmbFlete.SelectedIndex = 0
                txtCosto.Enabled = False
                txtCosto.Text = "0"
                txtNumeroGuia.Enabled = False
            Else
                cmbEmpresa.Enabled = True
                cmbFlete.Enabled = True
                txtCosto.Enabled = True
                txtNumeroGuia.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
