<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_CapturaGeneral_Tab_Form
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_CapturaGeneral_Tab_Form))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DockAreaPane1 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, New System.Guid("e5b71d93-6a4a-4a5f-a0a9-364e2d06560c"))
        Dim DockableControlPane1 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("15d20d09-b180-4c35-ae0a-5cc968a94ea4"), New System.Guid("00000000-0000-0000-0000-000000000000"), -1, New System.Guid("e5b71d93-6a4a-4a5f-a0a9-364e2d06560c"), -1)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DockAreaPane2 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, New System.Guid("43c2ddeb-a71d-4f46-abaf-23f01f72951d"))
        Dim DockableControlPane2 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("5a1197bb-a904-467f-b181-df3ebd05195c"), New System.Guid("00000000-0000-0000-0000-000000000000"), -1, New System.Guid("43c2ddeb-a71d-4f46-abaf-23f01f72951d"), -1)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlAlmacen = New Infragistics.Win.Misc.UltraPanel()
        Me.pnlFormEtiquetado = New System.Windows.Forms.Panel()
        Me.grpbDiasProcesamiento = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudDiasProcesamiento = New System.Windows.Forms.NumericUpDown()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblBtnCerrar = New System.Windows.Forms.Label()
        Me.lblBtnGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpbArticulos = New System.Windows.Forms.GroupBox()
        Me.txtObservacionFactura = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaModelos = New System.Windows.Forms.Label()
        Me.grpbPaqueteria = New System.Windows.Forms.GroupBox()
        Me.txtNumeroGuia = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaNumGuia = New System.Windows.Forms.Label()
        Me.lblEtiquetaEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaFlete = New System.Windows.Forms.Label()
        Me.cmbFlete = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaCosto = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.MaskedTextBox()
        Me.grpbRecepcion = New System.Windows.Forms.GroupBox()
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaUbicacion = New System.Windows.Forms.Label()
        Me.cmbRecibio = New System.Windows.Forms.ComboBox()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaUnidad = New System.Windows.Forms.Label()
        Me.dtpFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.lblEtiquetaRecibio = New System.Windows.Forms.Label()
        Me.txtCajas = New System.Windows.Forms.MaskedTextBox()
        Me.lblEtiquetaCajas = New System.Windows.Forms.Label()
        Me.lblNumSemana = New System.Windows.Forms.Label()
        Me.lblDtpFechaRecepcion = New System.Windows.Forms.Label()
        Me.lblEtiquetaSemana = New System.Windows.Forms.Label()
        Me.lblEtiquetaCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.MaskedTextBox()
        Me.cmbMotivoInicial = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaMotivoIniDev = New System.Windows.Forms.Label()
        Me.grpbComentarios = New System.Windows.Forms.GroupBox()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.grpbResolucion = New System.Windows.Forms.GroupBox()
        Me.lblEtiquetaProcede = New System.Windows.Forms.Label()
        Me.txtProcedeAutoriza_pnlAlmacen = New System.Windows.Forms.TextBox()
        Me.rdbProcedeAutoriza_pnlAlmacen = New System.Windows.Forms.RadioButton()
        Me.rdbPendiente_pnlAlmacen = New System.Windows.Forms.RadioButton()
        Me.rdbNoProcede_pnlAlmacen = New System.Windows.Forms.RadioButton()
        Me.rdbProcede_pnlAlmacen = New System.Windows.Forms.RadioButton()
        Me.pnlVentasCobranza = New Infragistics.Win.Misc.UltraPanel()
        Me.pnlFormMKT = New System.Windows.Forms.Panel()
        Me.grpbResolucion_pnlVentas = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcedeAutoriza_pnlVentas = New System.Windows.Forms.TextBox()
        Me.rdbProcedeAutoriza_pnlVentas = New System.Windows.Forms.RadioButton()
        Me.rdbPendiente_pnlVentas = New System.Windows.Forms.RadioButton()
        Me.rdbNoProcede_pnlVentas = New System.Windows.Forms.RadioButton()
        Me.rdbProcede_pnlVentas = New System.Windows.Forms.RadioButton()
        Me.grpbCobranza = New System.Windows.Forms.GroupBox()
        Me.lblEtiquetaMontoMasIva = New System.Windows.Forms.Label()
        Me.lblSumatoriaMonto = New System.Windows.Forms.Label()
        Me.lblEtiquetaMontoTotal = New System.Windows.Forms.Label()
        Me.lblMontoTotal = New System.Windows.Forms.Label()
        Me.lblEtiquetaIva = New System.Windows.Forms.Label()
        Me.lblMontoIVA = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblMontoDescuento = New System.Windows.Forms.Label()
        Me.lblEtiquetaMontoDescuento = New System.Windows.Forms.Label()
        Me.btnExportarExcelApartados = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdNotasCredito = New DevExpress.XtraGrid.GridControl()
        Me.bgvNotasCredito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Seleccionar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OTSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Agente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoOT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrdenCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaEntregaProgramacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPreparacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Confirmados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PorConfirmar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cancelados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioModifico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaModificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiasFaltantes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MotivoCancelacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Observaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCitaEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblEtiquetaCantidadAplicada = New System.Windows.Forms.Label()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.lblSolicitudNotaCredito = New System.Windows.Forms.Label()
        Me.lblEtiquetaSolicitaNotaCredito = New System.Windows.Forms.Label()
        Me.lblCantidadAplicada = New System.Windows.Forms.Label()
        Me.lblCantidadPorAplicar = New System.Windows.Forms.Label()
        Me.lblDevolucionSICY = New System.Windows.Forms.Label()
        Me.lblEtiquetaCantidadPorAplicar = New System.Windows.Forms.Label()
        Me.lblEtiquetaDevSICY = New System.Windows.Forms.Label()
        Me.grpbGuardarVentas = New System.Windows.Forms.GroupBox()
        Me.btnGuardar_Ventas = New System.Windows.Forms.Button()
        Me.lblBtnCerrarVentas = New System.Windows.Forms.Label()
        Me.lblBtnGuardarVentas = New System.Windows.Forms.Label()
        Me.btnCerrarVentas = New System.Windows.Forms.Button()
        Me.grpbVentas = New System.Windows.Forms.GroupBox()
        Me.chkSinDocumentos = New System.Windows.Forms.CheckBox()
        Me.cmbResponsable = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaResponsable = New System.Windows.Forms.Label()
        Me.btnAnexarAutorizacion = New System.Windows.Forms.Button()
        Me.btnDocumentosRelacionados = New System.Windows.Forms.Button()
        Me.txtDocumentosRelacionados = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaDoctosRelacionados = New System.Windows.Forms.Label()
        Me.lblEtiqueta15Dias = New System.Windows.Forms.Label()
        Me.lblEtiquetaAnexarAutorizacion = New System.Windows.Forms.Label()
        Me.dtpFechaLimite = New System.Windows.Forms.DateTimePicker()
        Me.rdbAplicaNotaCreditoNO = New System.Windows.Forms.RadioButton()
        Me.rdbAplicaNotaCreditoSI = New System.Windows.Forms.RadioButton()
        Me.lblEtiquetaDTPLimiteAccion = New System.Windows.Forms.Label()
        Me.lblEtiqetaAplicaNotaCredito = New System.Windows.Forms.Label()
        Me.lblEnviadoARevision = New System.Windows.Forms.Label()
        Me.lblEtiquetaEnviadoRevision = New System.Windows.Forms.Label()
        Me.txtIndicaRecepcion = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaIndicaRecepcion = New System.Windows.Forms.Label()
        Me.cmbMotivoVentas = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaMotivoVentas = New System.Windows.Forms.Label()
        Me.lblReqAutorizacion = New System.Windows.Forms.Label()
        Me.lblEtiquetaRequiereAutorizacion = New System.Windows.Forms.Label()
        Me.lblDiasTranscurridos = New System.Windows.Forms.Label()
        Me.lblModificacionVentas = New System.Windows.Forms.Label()
        Me.lblEtiquetaModificacionVentas = New System.Windows.Forms.Label()
        Me.lblEtiquetaDiasTranscurridos = New System.Windows.Forms.Label()
        Me.txtObservaciones_Ventas = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaObservacionesVentas = New System.Windows.Forms.Label()
        Me.cmbDestinoProducto = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaDestinoProd = New System.Windows.Forms.Label()
        Me.txtIdentificadorDocumentos = New System.Windows.Forms.TextBox()
        Me.pnlContenedor = New Infragistics.Win.Misc.UltraPanel()
        Me.pnlFormCliente = New System.Windows.Forms.Panel()
        Me.lblEtiquetaCantidadTotal = New System.Windows.Forms.Label()
        Me.lblCantidadTotal = New System.Windows.Forms.Label()
        Me.lblEtiquetaCmbCliente = New System.Windows.Forms.Label()
        Me.lblEtiquetaFechaRegistro = New System.Windows.Forms.Label()
        Me.lblFechaUsuarioRegistro = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaAtnClientes = New System.Windows.Forms.Label()
        Me.lblAgentes = New System.Windows.Forms.Label()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.lblEtiquetaAgentes = New System.Windows.Forms.Label()
        Me.lblAtnClientes = New System.Windows.Forms.Label()
        Me.lblResolucion = New System.Windows.Forms.Label()
        Me.lblEtiquetaResolucion = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblEtiquetaEstatus = New System.Windows.Forms.Label()
        Me.lblFolioDev = New System.Windows.Forms.Label()
        Me.lblEtiquetaFolioDev = New System.Windows.Forms.Label()
        Me.cmbTipoDevolucion = New System.Windows.Forms.ComboBox()
        Me.lblEtiquetaComboTipoDev = New System.Windows.Forms.Label()
        Me.lblBtnVerAutorizacion = New System.Windows.Forms.Label()
        Me.btnVerAutorizacion = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnSolicitarNotaCredito = New System.Windows.Forms.Button()
        Me.lblBtnNotaCredito = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnSolicitarProcesamientoAlmacen = New System.Windows.Forms.Button()
        Me.lblBtnProcesamientoAlmacen = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnSolicitarRevisionVentas = New System.Windows.Forms.Button()
        Me.lblBtnRevisionVentas = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSolicitarDocumentos = New System.Windows.Forms.Button()
        Me.lblBtnSolicitarDocumentos = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnVerAgregarDetalle = New System.Windows.Forms.Button()
        Me.lblBtnDetalles = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblBntEditar = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.WindowDockingArea7 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.DockableWindow9 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dockManagerDevoluciones = New Infragistics.Win.UltraWinDock.UltraDockManager()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl = New Infragistics.Win.UltraWinDock.AutoHideControl()
        Me.DockableWindow5 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.DockableWindow1 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me.ofdFichaTecnica = New System.Windows.Forms.OpenFileDialog()
        Me.AppStylistRuntime1 = New Infragistics.Win.AppStyling.Runtime.AppStylistRuntime()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.WindowDockingArea12 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.WindowDockingArea15 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlAlmacen.ClientArea.SuspendLayout()
        Me.pnlAlmacen.SuspendLayout()
        Me.pnlFormEtiquetado.SuspendLayout()
        Me.grpbDiasProcesamiento.SuspendLayout()
        CType(Me.nudDiasProcesamiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpbArticulos.SuspendLayout()
        Me.grpbPaqueteria.SuspendLayout()
        Me.grpbRecepcion.SuspendLayout()
        Me.grpbComentarios.SuspendLayout()
        Me.grpbResolucion.SuspendLayout()
        Me.pnlVentasCobranza.ClientArea.SuspendLayout()
        Me.pnlVentasCobranza.SuspendLayout()
        Me.pnlFormMKT.SuspendLayout()
        Me.grpbResolucion_pnlVentas.SuspendLayout()
        Me.grpbCobranza.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdNotasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvNotasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbGuardarVentas.SuspendLayout()
        Me.grpbVentas.SuspendLayout()
        Me.pnlContenedor.ClientArea.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlFormCliente.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dockManagerDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.SuspendLayout()
        Me.DockableWindow5.SuspendLayout()
        Me.DockableWindow1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAlmacen
        '
        Appearance1.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAlmacen.Appearance = Appearance1
        Me.pnlAlmacen.AutoScroll = True
        '
        'pnlAlmacen.ClientArea
        '
        Me.pnlAlmacen.ClientArea.Controls.Add(Me.pnlFormEtiquetado)
        resources.ApplyResources(Me.pnlAlmacen, "pnlAlmacen")
        Me.pnlAlmacen.Name = "pnlAlmacen"
        '
        'pnlFormEtiquetado
        '
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbDiasProcesamiento)
        Me.pnlFormEtiquetado.Controls.Add(Me.lblClasificacion)
        Me.pnlFormEtiquetado.Controls.Add(Me.Label2)
        Me.pnlFormEtiquetado.Controls.Add(Me.GroupBox1)
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbArticulos)
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbPaqueteria)
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbRecepcion)
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbComentarios)
        Me.pnlFormEtiquetado.Controls.Add(Me.grpbResolucion)
        resources.ApplyResources(Me.pnlFormEtiquetado, "pnlFormEtiquetado")
        Me.pnlFormEtiquetado.Name = "pnlFormEtiquetado"
        '
        'grpbDiasProcesamiento
        '
        Me.grpbDiasProcesamiento.Controls.Add(Me.Label4)
        Me.grpbDiasProcesamiento.Controls.Add(Me.Label3)
        Me.grpbDiasProcesamiento.Controls.Add(Me.nudDiasProcesamiento)
        resources.ApplyResources(Me.grpbDiasProcesamiento, "grpbDiasProcesamiento")
        Me.grpbDiasProcesamiento.Name = "grpbDiasProcesamiento"
        Me.grpbDiasProcesamiento.TabStop = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Name = "Label3"
        '
        'nudDiasProcesamiento
        '
        resources.ApplyResources(Me.nudDiasProcesamiento, "nudDiasProcesamiento")
        Me.nudDiasProcesamiento.Maximum = New Decimal(New Integer() {14, 0, 0, 0})
        Me.nudDiasProcesamiento.Name = "nudDiasProcesamiento"
        '
        'lblClasificacion
        '
        resources.ApplyResources(Me.lblClasificacion, "lblClasificacion")
        Me.lblClasificacion.ForeColor = System.Drawing.Color.Black
        Me.lblClasificacion.Name = "lblClasificacion"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.lblBtnCerrar)
        Me.GroupBox1.Controls.Add(Me.lblBtnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'btnGuardar
        '
        resources.ApplyResources(Me.btnGuardar, "btnGuardar")
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblBtnCerrar
        '
        resources.ApplyResources(Me.lblBtnCerrar, "lblBtnCerrar")
        Me.lblBtnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnCerrar.Name = "lblBtnCerrar"
        '
        'lblBtnGuardar
        '
        resources.ApplyResources(Me.lblBtnGuardar, "lblBtnGuardar")
        Me.lblBtnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnGuardar.Name = "lblBtnGuardar"
        '
        'btnCerrar
        '
        resources.ApplyResources(Me.btnCerrar, "btnCerrar")
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grpbArticulos
        '
        Me.grpbArticulos.Controls.Add(Me.txtObservacionFactura)
        Me.grpbArticulos.Controls.Add(Me.lblEtiquetaModelos)
        resources.ApplyResources(Me.grpbArticulos, "grpbArticulos")
        Me.grpbArticulos.Name = "grpbArticulos"
        Me.grpbArticulos.TabStop = False
        '
        'txtObservacionFactura
        '
        resources.ApplyResources(Me.txtObservacionFactura, "txtObservacionFactura")
        Me.txtObservacionFactura.Name = "txtObservacionFactura"
        '
        'lblEtiquetaModelos
        '
        resources.ApplyResources(Me.lblEtiquetaModelos, "lblEtiquetaModelos")
        Me.lblEtiquetaModelos.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaModelos.Name = "lblEtiquetaModelos"
        '
        'grpbPaqueteria
        '
        Me.grpbPaqueteria.Controls.Add(Me.txtNumeroGuia)
        Me.grpbPaqueteria.Controls.Add(Me.lblEtiquetaNumGuia)
        Me.grpbPaqueteria.Controls.Add(Me.lblEtiquetaEmpresa)
        Me.grpbPaqueteria.Controls.Add(Me.cmbEmpresa)
        Me.grpbPaqueteria.Controls.Add(Me.lblEtiquetaFlete)
        Me.grpbPaqueteria.Controls.Add(Me.cmbFlete)
        Me.grpbPaqueteria.Controls.Add(Me.lblEtiquetaCosto)
        Me.grpbPaqueteria.Controls.Add(Me.txtCosto)
        resources.ApplyResources(Me.grpbPaqueteria, "grpbPaqueteria")
        Me.grpbPaqueteria.Name = "grpbPaqueteria"
        Me.grpbPaqueteria.TabStop = False
        '
        'txtNumeroGuia
        '
        Me.txtNumeroGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtNumeroGuia, "txtNumeroGuia")
        Me.txtNumeroGuia.Name = "txtNumeroGuia"
        '
        'lblEtiquetaNumGuia
        '
        resources.ApplyResources(Me.lblEtiquetaNumGuia, "lblEtiquetaNumGuia")
        Me.lblEtiquetaNumGuia.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaNumGuia.Name = "lblEtiquetaNumGuia"
        '
        'lblEtiquetaEmpresa
        '
        resources.ApplyResources(Me.lblEtiquetaEmpresa, "lblEtiquetaEmpresa")
        Me.lblEtiquetaEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaEmpresa.Name = "lblEtiquetaEmpresa"
        '
        'cmbEmpresa
        '
        resources.ApplyResources(Me.cmbEmpresa, "cmbEmpresa")
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Items.AddRange(New Object() {resources.GetString("cmbEmpresa.Items")})
        Me.cmbEmpresa.Name = "cmbEmpresa"
        '
        'lblEtiquetaFlete
        '
        resources.ApplyResources(Me.lblEtiquetaFlete, "lblEtiquetaFlete")
        Me.lblEtiquetaFlete.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaFlete.Name = "lblEtiquetaFlete"
        '
        'cmbFlete
        '
        resources.ApplyResources(Me.cmbFlete, "cmbFlete")
        Me.cmbFlete.FormattingEnabled = True
        Me.cmbFlete.Items.AddRange(New Object() {resources.GetString("cmbFlete.Items")})
        Me.cmbFlete.Name = "cmbFlete"
        '
        'lblEtiquetaCosto
        '
        resources.ApplyResources(Me.lblEtiquetaCosto, "lblEtiquetaCosto")
        Me.lblEtiquetaCosto.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCosto.Name = "lblEtiquetaCosto"
        '
        'txtCosto
        '
        resources.ApplyResources(Me.txtCosto, "txtCosto")
        Me.txtCosto.Name = "txtCosto"
        '
        'grpbRecepcion
        '
        Me.grpbRecepcion.Controls.Add(Me.cmbUbicacion)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaUbicacion)
        Me.grpbRecepcion.Controls.Add(Me.cmbRecibio)
        Me.grpbRecepcion.Controls.Add(Me.cmbUnidad)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaUnidad)
        Me.grpbRecepcion.Controls.Add(Me.dtpFechaRecepcion)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaRecibio)
        Me.grpbRecepcion.Controls.Add(Me.txtCajas)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaCajas)
        Me.grpbRecepcion.Controls.Add(Me.lblNumSemana)
        Me.grpbRecepcion.Controls.Add(Me.lblDtpFechaRecepcion)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaSemana)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaCantidad)
        Me.grpbRecepcion.Controls.Add(Me.txtCantidad)
        Me.grpbRecepcion.Controls.Add(Me.cmbMotivoInicial)
        Me.grpbRecepcion.Controls.Add(Me.lblEtiquetaMotivoIniDev)
        resources.ApplyResources(Me.grpbRecepcion, "grpbRecepcion")
        Me.grpbRecepcion.Name = "grpbRecepcion"
        Me.grpbRecepcion.TabStop = False
        '
        'cmbUbicacion
        '
        resources.ApplyResources(Me.cmbUbicacion, "cmbUbicacion")
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Items.AddRange(New Object() {resources.GetString("cmbUbicacion.Items")})
        Me.cmbUbicacion.Name = "cmbUbicacion"
        '
        'lblEtiquetaUbicacion
        '
        resources.ApplyResources(Me.lblEtiquetaUbicacion, "lblEtiquetaUbicacion")
        Me.lblEtiquetaUbicacion.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaUbicacion.Name = "lblEtiquetaUbicacion"
        '
        'cmbRecibio
        '
        resources.ApplyResources(Me.cmbRecibio, "cmbRecibio")
        Me.cmbRecibio.FormattingEnabled = True
        Me.cmbRecibio.Name = "cmbRecibio"
        '
        'cmbUnidad
        '
        resources.ApplyResources(Me.cmbUnidad, "cmbUnidad")
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Items.AddRange(New Object() {resources.GetString("cmbUnidad.Items")})
        Me.cmbUnidad.Name = "cmbUnidad"
        '
        'lblEtiquetaUnidad
        '
        resources.ApplyResources(Me.lblEtiquetaUnidad, "lblEtiquetaUnidad")
        Me.lblEtiquetaUnidad.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaUnidad.Name = "lblEtiquetaUnidad"
        '
        'dtpFechaRecepcion
        '
        resources.ApplyResources(Me.dtpFechaRecepcion, "dtpFechaRecepcion")
        Me.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        Me.dtpFechaRecepcion.Value = New Date(2018, 12, 20, 8, 57, 0, 0)
        '
        'lblEtiquetaRecibio
        '
        resources.ApplyResources(Me.lblEtiquetaRecibio, "lblEtiquetaRecibio")
        Me.lblEtiquetaRecibio.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaRecibio.Name = "lblEtiquetaRecibio"
        '
        'txtCajas
        '
        resources.ApplyResources(Me.txtCajas, "txtCajas")
        Me.txtCajas.Name = "txtCajas"
        '
        'lblEtiquetaCajas
        '
        resources.ApplyResources(Me.lblEtiquetaCajas, "lblEtiquetaCajas")
        Me.lblEtiquetaCajas.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCajas.Name = "lblEtiquetaCajas"
        '
        'lblNumSemana
        '
        resources.ApplyResources(Me.lblNumSemana, "lblNumSemana")
        Me.lblNumSemana.ForeColor = System.Drawing.Color.Black
        Me.lblNumSemana.Name = "lblNumSemana"
        '
        'lblDtpFechaRecepcion
        '
        resources.ApplyResources(Me.lblDtpFechaRecepcion, "lblDtpFechaRecepcion")
        Me.lblDtpFechaRecepcion.ForeColor = System.Drawing.Color.Black
        Me.lblDtpFechaRecepcion.Name = "lblDtpFechaRecepcion"
        '
        'lblEtiquetaSemana
        '
        resources.ApplyResources(Me.lblEtiquetaSemana, "lblEtiquetaSemana")
        Me.lblEtiquetaSemana.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaSemana.Name = "lblEtiquetaSemana"
        '
        'lblEtiquetaCantidad
        '
        resources.ApplyResources(Me.lblEtiquetaCantidad, "lblEtiquetaCantidad")
        Me.lblEtiquetaCantidad.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCantidad.Name = "lblEtiquetaCantidad"
        '
        'txtCantidad
        '
        resources.ApplyResources(Me.txtCantidad, "txtCantidad")
        Me.txtCantidad.Name = "txtCantidad"
        '
        'cmbMotivoInicial
        '
        resources.ApplyResources(Me.cmbMotivoInicial, "cmbMotivoInicial")
        Me.cmbMotivoInicial.FormattingEnabled = True
        Me.cmbMotivoInicial.Items.AddRange(New Object() {resources.GetString("cmbMotivoInicial.Items")})
        Me.cmbMotivoInicial.Name = "cmbMotivoInicial"
        '
        'lblEtiquetaMotivoIniDev
        '
        resources.ApplyResources(Me.lblEtiquetaMotivoIniDev, "lblEtiquetaMotivoIniDev")
        Me.lblEtiquetaMotivoIniDev.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMotivoIniDev.Name = "lblEtiquetaMotivoIniDev"
        '
        'grpbComentarios
        '
        Me.grpbComentarios.Controls.Add(Me.txtComentarios)
        resources.ApplyResources(Me.grpbComentarios, "grpbComentarios")
        Me.grpbComentarios.Name = "grpbComentarios"
        Me.grpbComentarios.TabStop = False
        '
        'txtComentarios
        '
        Me.txtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtComentarios, "txtComentarios")
        Me.txtComentarios.Name = "txtComentarios"
        '
        'grpbResolucion
        '
        Me.grpbResolucion.Controls.Add(Me.lblEtiquetaProcede)
        Me.grpbResolucion.Controls.Add(Me.txtProcedeAutoriza_pnlAlmacen)
        Me.grpbResolucion.Controls.Add(Me.rdbProcedeAutoriza_pnlAlmacen)
        Me.grpbResolucion.Controls.Add(Me.rdbPendiente_pnlAlmacen)
        Me.grpbResolucion.Controls.Add(Me.rdbNoProcede_pnlAlmacen)
        Me.grpbResolucion.Controls.Add(Me.rdbProcede_pnlAlmacen)
        resources.ApplyResources(Me.grpbResolucion, "grpbResolucion")
        Me.grpbResolucion.Name = "grpbResolucion"
        Me.grpbResolucion.TabStop = False
        '
        'lblEtiquetaProcede
        '
        resources.ApplyResources(Me.lblEtiquetaProcede, "lblEtiquetaProcede")
        Me.lblEtiquetaProcede.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaProcede.Name = "lblEtiquetaProcede"
        '
        'txtProcedeAutoriza_pnlAlmacen
        '
        Me.txtProcedeAutoriza_pnlAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtProcedeAutoriza_pnlAlmacen, "txtProcedeAutoriza_pnlAlmacen")
        Me.txtProcedeAutoriza_pnlAlmacen.Name = "txtProcedeAutoriza_pnlAlmacen"
        '
        'rdbProcedeAutoriza_pnlAlmacen
        '
        resources.ApplyResources(Me.rdbProcedeAutoriza_pnlAlmacen, "rdbProcedeAutoriza_pnlAlmacen")
        Me.rdbProcedeAutoriza_pnlAlmacen.ForeColor = System.Drawing.Color.Blue
        Me.rdbProcedeAutoriza_pnlAlmacen.Name = "rdbProcedeAutoriza_pnlAlmacen"
        Me.rdbProcedeAutoriza_pnlAlmacen.UseVisualStyleBackColor = True
        '
        'rdbPendiente_pnlAlmacen
        '
        resources.ApplyResources(Me.rdbPendiente_pnlAlmacen, "rdbPendiente_pnlAlmacen")
        Me.rdbPendiente_pnlAlmacen.Checked = True
        Me.rdbPendiente_pnlAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdbPendiente_pnlAlmacen.Name = "rdbPendiente_pnlAlmacen"
        Me.rdbPendiente_pnlAlmacen.TabStop = True
        Me.rdbPendiente_pnlAlmacen.UseVisualStyleBackColor = True
        '
        'rdbNoProcede_pnlAlmacen
        '
        resources.ApplyResources(Me.rdbNoProcede_pnlAlmacen, "rdbNoProcede_pnlAlmacen")
        Me.rdbNoProcede_pnlAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdbNoProcede_pnlAlmacen.Name = "rdbNoProcede_pnlAlmacen"
        Me.rdbNoProcede_pnlAlmacen.UseVisualStyleBackColor = True
        '
        'rdbProcede_pnlAlmacen
        '
        resources.ApplyResources(Me.rdbProcede_pnlAlmacen, "rdbProcede_pnlAlmacen")
        Me.rdbProcede_pnlAlmacen.ForeColor = System.Drawing.Color.Green
        Me.rdbProcede_pnlAlmacen.Name = "rdbProcede_pnlAlmacen"
        Me.rdbProcede_pnlAlmacen.UseVisualStyleBackColor = True
        '
        'pnlVentasCobranza
        '
        Appearance2.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlVentasCobranza.Appearance = Appearance2
        Me.pnlVentasCobranza.AutoScroll = True
        '
        'pnlVentasCobranza.ClientArea
        '
        Me.pnlVentasCobranza.ClientArea.Controls.Add(Me.pnlFormMKT)
        resources.ApplyResources(Me.pnlVentasCobranza, "pnlVentasCobranza")
        Me.pnlVentasCobranza.Name = "pnlVentasCobranza"
        '
        'pnlFormMKT
        '
        Me.pnlFormMKT.Controls.Add(Me.grpbResolucion_pnlVentas)
        Me.pnlFormMKT.Controls.Add(Me.grpbCobranza)
        Me.pnlFormMKT.Controls.Add(Me.grpbGuardarVentas)
        Me.pnlFormMKT.Controls.Add(Me.grpbVentas)
        resources.ApplyResources(Me.pnlFormMKT, "pnlFormMKT")
        Me.pnlFormMKT.Name = "pnlFormMKT"
        '
        'grpbResolucion_pnlVentas
        '
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.Label1)
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.txtProcedeAutoriza_pnlVentas)
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.rdbProcedeAutoriza_pnlVentas)
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.rdbPendiente_pnlVentas)
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.rdbNoProcede_pnlVentas)
        Me.grpbResolucion_pnlVentas.Controls.Add(Me.rdbProcede_pnlVentas)
        resources.ApplyResources(Me.grpbResolucion_pnlVentas, "grpbResolucion_pnlVentas")
        Me.grpbResolucion_pnlVentas.Name = "grpbResolucion_pnlVentas"
        Me.grpbResolucion_pnlVentas.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'txtProcedeAutoriza_pnlVentas
        '
        Me.txtProcedeAutoriza_pnlVentas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtProcedeAutoriza_pnlVentas, "txtProcedeAutoriza_pnlVentas")
        Me.txtProcedeAutoriza_pnlVentas.Name = "txtProcedeAutoriza_pnlVentas"
        '
        'rdbProcedeAutoriza_pnlVentas
        '
        resources.ApplyResources(Me.rdbProcedeAutoriza_pnlVentas, "rdbProcedeAutoriza_pnlVentas")
        Me.rdbProcedeAutoriza_pnlVentas.ForeColor = System.Drawing.Color.Blue
        Me.rdbProcedeAutoriza_pnlVentas.Name = "rdbProcedeAutoriza_pnlVentas"
        Me.rdbProcedeAutoriza_pnlVentas.UseVisualStyleBackColor = True
        '
        'rdbPendiente_pnlVentas
        '
        resources.ApplyResources(Me.rdbPendiente_pnlVentas, "rdbPendiente_pnlVentas")
        Me.rdbPendiente_pnlVentas.Checked = True
        Me.rdbPendiente_pnlVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdbPendiente_pnlVentas.Name = "rdbPendiente_pnlVentas"
        Me.rdbPendiente_pnlVentas.TabStop = True
        Me.rdbPendiente_pnlVentas.UseVisualStyleBackColor = True
        '
        'rdbNoProcede_pnlVentas
        '
        resources.ApplyResources(Me.rdbNoProcede_pnlVentas, "rdbNoProcede_pnlVentas")
        Me.rdbNoProcede_pnlVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdbNoProcede_pnlVentas.Name = "rdbNoProcede_pnlVentas"
        Me.rdbNoProcede_pnlVentas.UseVisualStyleBackColor = True
        '
        'rdbProcede_pnlVentas
        '
        resources.ApplyResources(Me.rdbProcede_pnlVentas, "rdbProcede_pnlVentas")
        Me.rdbProcede_pnlVentas.ForeColor = System.Drawing.Color.Green
        Me.rdbProcede_pnlVentas.Name = "rdbProcede_pnlVentas"
        Me.rdbProcede_pnlVentas.UseVisualStyleBackColor = True
        '
        'grpbCobranza
        '
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaMontoMasIva)
        Me.grpbCobranza.Controls.Add(Me.lblSumatoriaMonto)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaMontoTotal)
        Me.grpbCobranza.Controls.Add(Me.lblMontoTotal)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaIva)
        Me.grpbCobranza.Controls.Add(Me.lblMontoIVA)
        Me.grpbCobranza.Controls.Add(Me.lblDescuento)
        Me.grpbCobranza.Controls.Add(Me.lblMontoDescuento)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaMontoDescuento)
        Me.grpbCobranza.Controls.Add(Me.btnExportarExcelApartados)
        Me.grpbCobranza.Controls.Add(Me.Panel8)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaCantidadAplicada)
        Me.grpbCobranza.Controls.Add(Me.lblActualizarDatos)
        Me.grpbCobranza.Controls.Add(Me.lblSolicitudNotaCredito)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaSolicitaNotaCredito)
        Me.grpbCobranza.Controls.Add(Me.lblCantidadAplicada)
        Me.grpbCobranza.Controls.Add(Me.lblCantidadPorAplicar)
        Me.grpbCobranza.Controls.Add(Me.lblDevolucionSICY)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaCantidadPorAplicar)
        Me.grpbCobranza.Controls.Add(Me.lblEtiquetaDevSICY)
        resources.ApplyResources(Me.grpbCobranza, "grpbCobranza")
        Me.grpbCobranza.ForeColor = System.Drawing.Color.Maroon
        Me.grpbCobranza.Name = "grpbCobranza"
        Me.grpbCobranza.TabStop = False
        '
        'lblEtiquetaMontoMasIva
        '
        resources.ApplyResources(Me.lblEtiquetaMontoMasIva, "lblEtiquetaMontoMasIva")
        Me.lblEtiquetaMontoMasIva.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMontoMasIva.Name = "lblEtiquetaMontoMasIva"
        '
        'lblSumatoriaMonto
        '
        resources.ApplyResources(Me.lblSumatoriaMonto, "lblSumatoriaMonto")
        Me.lblSumatoriaMonto.ForeColor = System.Drawing.Color.Black
        Me.lblSumatoriaMonto.Name = "lblSumatoriaMonto"
        '
        'lblEtiquetaMontoTotal
        '
        resources.ApplyResources(Me.lblEtiquetaMontoTotal, "lblEtiquetaMontoTotal")
        Me.lblEtiquetaMontoTotal.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMontoTotal.Name = "lblEtiquetaMontoTotal"
        '
        'lblMontoTotal
        '
        resources.ApplyResources(Me.lblMontoTotal, "lblMontoTotal")
        Me.lblMontoTotal.ForeColor = System.Drawing.Color.Black
        Me.lblMontoTotal.Name = "lblMontoTotal"
        '
        'lblEtiquetaIva
        '
        resources.ApplyResources(Me.lblEtiquetaIva, "lblEtiquetaIva")
        Me.lblEtiquetaIva.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaIva.Name = "lblEtiquetaIva"
        '
        'lblMontoIVA
        '
        resources.ApplyResources(Me.lblMontoIVA, "lblMontoIVA")
        Me.lblMontoIVA.ForeColor = System.Drawing.Color.Black
        Me.lblMontoIVA.Name = "lblMontoIVA"
        '
        'lblDescuento
        '
        resources.ApplyResources(Me.lblDescuento, "lblDescuento")
        Me.lblDescuento.ForeColor = System.Drawing.Color.Black
        Me.lblDescuento.Name = "lblDescuento"
        '
        'lblMontoDescuento
        '
        resources.ApplyResources(Me.lblMontoDescuento, "lblMontoDescuento")
        Me.lblMontoDescuento.ForeColor = System.Drawing.Color.Black
        Me.lblMontoDescuento.Name = "lblMontoDescuento"
        '
        'lblEtiquetaMontoDescuento
        '
        resources.ApplyResources(Me.lblEtiquetaMontoDescuento, "lblEtiquetaMontoDescuento")
        Me.lblEtiquetaMontoDescuento.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMontoDescuento.Name = "lblEtiquetaMontoDescuento"
        '
        'btnExportarExcelApartados
        '
        Me.btnExportarExcelApartados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelApartados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelApartados.Image = Global.Almacen.Vista.My.Resources.Resources.excel_321
        resources.ApplyResources(Me.btnExportarExcelApartados, "btnExportarExcelApartados")
        Me.btnExportarExcelApartados.Name = "btnExportarExcelApartados"
        Me.btnExportarExcelApartados.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdNotasCredito)
        resources.ApplyResources(Me.Panel8, "Panel8")
        Me.Panel8.Name = "Panel8"
        '
        'grdNotasCredito
        '
        resources.ApplyResources(Me.grdNotasCredito, "grdNotasCredito")
        GridLevelNode1.RelationName = "Level1"
        Me.grdNotasCredito.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdNotasCredito.MainView = Me.bgvNotasCredito
        Me.grdNotasCredito.Name = "grdNotasCredito"
        Me.grdNotasCredito.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvNotasCredito, Me.grdDetallesOT, Me.GridView1})
        '
        'bgvNotasCredito
        '
        Me.bgvNotasCredito.GridControl = Me.grdNotasCredito
        Me.bgvNotasCredito.Name = "bgvNotasCredito"
        Me.bgvNotasCredito.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvNotasCredito.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvNotasCredito.OptionsFilter.AllowFilterEditor = False
        Me.bgvNotasCredito.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvNotasCredito.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvNotasCredito.OptionsSelection.MultiSelect = True
        Me.bgvNotasCredito.OptionsView.ColumnAutoWidth = False
        Me.bgvNotasCredito.OptionsView.ShowAutoFilterRow = True
        Me.bgvNotasCredito.OptionsView.ShowFooter = True
        Me.bgvNotasCredito.OptionsView.ShowGroupPanel = False
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdNotasCredito
        Me.grdDetallesOT.Name = "grdDetallesOT"
        Me.grdDetallesOT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDetallesOT.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDetallesOT.OptionsSelection.MultiSelect = True
        Me.grdDetallesOT.OptionsView.ColumnAutoWidth = False
        Me.grdDetallesOT.OptionsView.ShowAutoFilterRow = True
        Me.grdDetallesOT.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdNotasCredito
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Seleccionar
        '
        resources.ApplyResources(Me.Seleccionar, "Seleccionar")
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        '
        'OT
        '
        resources.ApplyResources(Me.OT, "OT")
        Me.OT.FieldName = "OT"
        Me.OT.Name = "OT"
        Me.OT.OptionsColumn.AllowEdit = False
        '
        'OTSICY
        '
        resources.ApplyResources(Me.OTSICY, "OTSICY")
        Me.OTSICY.FieldName = "OTSICY"
        Me.OTSICY.Name = "OTSICY"
        Me.OTSICY.OptionsColumn.AllowEdit = False
        '
        'Cliente
        '
        resources.ApplyResources(Me.Cliente, "Cliente")
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OptionsColumn.AllowEdit = False
        '
        'Agente
        '
        resources.ApplyResources(Me.Agente, "Agente")
        Me.Agente.FieldName = "Agente"
        Me.Agente.Name = "Agente"
        Me.Agente.OptionsColumn.AllowEdit = False
        '
        'STATUS
        '
        resources.ApplyResources(Me.STATUS, "STATUS")
        Me.STATUS.FieldName = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.OptionsColumn.AllowEdit = False
        '
        'TipoOT
        '
        resources.ApplyResources(Me.TipoOT, "TipoOT")
        Me.TipoOT.FieldName = "TipoOT"
        Me.TipoOT.Name = "TipoOT"
        Me.TipoOT.OptionsColumn.AllowEdit = False
        '
        'PedidoSAY
        '
        resources.ApplyResources(Me.PedidoSAY, "PedidoSAY")
        Me.PedidoSAY.FieldName = "PedidoSAY"
        Me.PedidoSAY.Name = "PedidoSAY"
        Me.PedidoSAY.OptionsColumn.AllowEdit = False
        '
        'PedidoSICY
        '
        resources.ApplyResources(Me.PedidoSICY, "PedidoSICY")
        Me.PedidoSICY.FieldName = "PedidoSICY"
        Me.PedidoSICY.Name = "PedidoSICY"
        Me.PedidoSICY.OptionsColumn.AllowEdit = False
        '
        'OrdenCliente
        '
        resources.ApplyResources(Me.OrdenCliente, "OrdenCliente")
        Me.OrdenCliente.FieldName = "OrdenCliente"
        Me.OrdenCliente.Name = "OrdenCliente"
        Me.OrdenCliente.OptionsColumn.AllowEdit = False
        '
        'FechaEntregaProgramacion
        '
        resources.ApplyResources(Me.FechaEntregaProgramacion, "FechaEntregaProgramacion")
        Me.FechaEntregaProgramacion.FieldName = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.Name = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.OptionsColumn.AllowEdit = False
        '
        'FechaPreparacion
        '
        resources.ApplyResources(Me.FechaPreparacion, "FechaPreparacion")
        Me.FechaPreparacion.FieldName = "FechaPreparacion"
        Me.FechaPreparacion.Name = "FechaPreparacion"
        Me.FechaPreparacion.OptionsColumn.AllowEdit = False
        '
        'Cantidad
        '
        resources.ApplyResources(Me.Cantidad, "Cantidad")
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        '
        'Confirmados
        '
        resources.ApplyResources(Me.Confirmados, "Confirmados")
        Me.Confirmados.FieldName = "Confirmados"
        Me.Confirmados.Name = "Confirmados"
        Me.Confirmados.OptionsColumn.AllowEdit = False
        '
        'PorConfirmar
        '
        resources.ApplyResources(Me.PorConfirmar, "PorConfirmar")
        Me.PorConfirmar.FieldName = "PorConfirmar"
        Me.PorConfirmar.Name = "PorConfirmar"
        Me.PorConfirmar.OptionsColumn.AllowEdit = False
        '
        'Cancelados
        '
        resources.ApplyResources(Me.Cancelados, "Cancelados")
        Me.Cancelados.FieldName = "Cancelados"
        Me.Cancelados.Name = "Cancelados"
        Me.Cancelados.OptionsColumn.AllowEdit = False
        '
        'UsuarioCaptura
        '
        resources.ApplyResources(Me.UsuarioCaptura, "UsuarioCaptura")
        Me.UsuarioCaptura.FieldName = "UsuarioCaptura"
        Me.UsuarioCaptura.Name = "UsuarioCaptura"
        Me.UsuarioCaptura.OptionsColumn.AllowEdit = False
        '
        'FechaCaptura
        '
        resources.ApplyResources(Me.FechaCaptura, "FechaCaptura")
        Me.FechaCaptura.FieldName = "FechaCaptura"
        Me.FechaCaptura.Name = "FechaCaptura"
        Me.FechaCaptura.OptionsColumn.AllowEdit = False
        '
        'Cita
        '
        resources.ApplyResources(Me.Cita, "Cita")
        Me.Cita.FieldName = "Cita"
        Me.Cita.Name = "Cita"
        Me.Cita.OptionsColumn.AllowEdit = False
        '
        'UsuarioModifico
        '
        resources.ApplyResources(Me.UsuarioModifico, "UsuarioModifico")
        Me.UsuarioModifico.FieldName = "UsuarioModifico"
        Me.UsuarioModifico.Name = "UsuarioModifico"
        Me.UsuarioModifico.OptionsColumn.AllowEdit = False
        '
        'FechaModificacion
        '
        resources.ApplyResources(Me.FechaModificacion, "FechaModificacion")
        Me.FechaModificacion.FieldName = "FechaModificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.OptionsColumn.AllowEdit = False
        '
        'DiasFaltantes
        '
        resources.ApplyResources(Me.DiasFaltantes, "DiasFaltantes")
        Me.DiasFaltantes.FieldName = "DiasFaltantes"
        Me.DiasFaltantes.Name = "DiasFaltantes"
        Me.DiasFaltantes.OptionsColumn.AllowEdit = False
        '
        'BE
        '
        resources.ApplyResources(Me.BE, "BE")
        Me.BE.FieldName = "BE"
        Me.BE.Name = "BE"
        Me.BE.OptionsColumn.AllowEdit = False
        '
        'MotivoCancelacion
        '
        resources.ApplyResources(Me.MotivoCancelacion, "MotivoCancelacion")
        Me.MotivoCancelacion.FieldName = "MotivoCancelacion"
        Me.MotivoCancelacion.Name = "MotivoCancelacion"
        Me.MotivoCancelacion.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "ClaveCitaEntrega"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'Observaciones
        '
        resources.ApplyResources(Me.Observaciones, "Observaciones")
        Me.Observaciones.FieldName = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        '
        'FechaCitaEntrega
        '
        resources.ApplyResources(Me.FechaCitaEntrega, "FechaCitaEntrega")
        Me.FechaCitaEntrega.FieldName = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Name = "FechaCitaEntrega"
        '
        'HoraCita
        '
        resources.ApplyResources(Me.HoraCita, "HoraCita")
        Me.HoraCita.FieldName = "HoraCita"
        Me.HoraCita.Name = "HoraCita"
        '
        'lblEtiquetaCantidadAplicada
        '
        resources.ApplyResources(Me.lblEtiquetaCantidadAplicada, "lblEtiquetaCantidadAplicada")
        Me.lblEtiquetaCantidadAplicada.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCantidadAplicada.Name = "lblEtiquetaCantidadAplicada"
        '
        'lblActualizarDatos
        '
        resources.ApplyResources(Me.lblActualizarDatos, "lblActualizarDatos")
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        '
        'lblSolicitudNotaCredito
        '
        resources.ApplyResources(Me.lblSolicitudNotaCredito, "lblSolicitudNotaCredito")
        Me.lblSolicitudNotaCredito.ForeColor = System.Drawing.Color.Black
        Me.lblSolicitudNotaCredito.Name = "lblSolicitudNotaCredito"
        '
        'lblEtiquetaSolicitaNotaCredito
        '
        resources.ApplyResources(Me.lblEtiquetaSolicitaNotaCredito, "lblEtiquetaSolicitaNotaCredito")
        Me.lblEtiquetaSolicitaNotaCredito.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaSolicitaNotaCredito.Name = "lblEtiquetaSolicitaNotaCredito"
        '
        'lblCantidadAplicada
        '
        resources.ApplyResources(Me.lblCantidadAplicada, "lblCantidadAplicada")
        Me.lblCantidadAplicada.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadAplicada.Name = "lblCantidadAplicada"
        '
        'lblCantidadPorAplicar
        '
        resources.ApplyResources(Me.lblCantidadPorAplicar, "lblCantidadPorAplicar")
        Me.lblCantidadPorAplicar.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadPorAplicar.Name = "lblCantidadPorAplicar"
        '
        'lblDevolucionSICY
        '
        resources.ApplyResources(Me.lblDevolucionSICY, "lblDevolucionSICY")
        Me.lblDevolucionSICY.ForeColor = System.Drawing.Color.Black
        Me.lblDevolucionSICY.Name = "lblDevolucionSICY"
        '
        'lblEtiquetaCantidadPorAplicar
        '
        resources.ApplyResources(Me.lblEtiquetaCantidadPorAplicar, "lblEtiquetaCantidadPorAplicar")
        Me.lblEtiquetaCantidadPorAplicar.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCantidadPorAplicar.Name = "lblEtiquetaCantidadPorAplicar"
        '
        'lblEtiquetaDevSICY
        '
        resources.ApplyResources(Me.lblEtiquetaDevSICY, "lblEtiquetaDevSICY")
        Me.lblEtiquetaDevSICY.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaDevSICY.Name = "lblEtiquetaDevSICY"
        '
        'grpbGuardarVentas
        '
        Me.grpbGuardarVentas.Controls.Add(Me.btnGuardar_Ventas)
        Me.grpbGuardarVentas.Controls.Add(Me.lblBtnCerrarVentas)
        Me.grpbGuardarVentas.Controls.Add(Me.lblBtnGuardarVentas)
        Me.grpbGuardarVentas.Controls.Add(Me.btnCerrarVentas)
        resources.ApplyResources(Me.grpbGuardarVentas, "grpbGuardarVentas")
        Me.grpbGuardarVentas.Name = "grpbGuardarVentas"
        Me.grpbGuardarVentas.TabStop = False
        '
        'btnGuardar_Ventas
        '
        resources.ApplyResources(Me.btnGuardar_Ventas, "btnGuardar_Ventas")
        Me.btnGuardar_Ventas.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar_Ventas.Name = "btnGuardar_Ventas"
        Me.btnGuardar_Ventas.UseVisualStyleBackColor = True
        '
        'lblBtnCerrarVentas
        '
        resources.ApplyResources(Me.lblBtnCerrarVentas, "lblBtnCerrarVentas")
        Me.lblBtnCerrarVentas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnCerrarVentas.Name = "lblBtnCerrarVentas"
        '
        'lblBtnGuardarVentas
        '
        resources.ApplyResources(Me.lblBtnGuardarVentas, "lblBtnGuardarVentas")
        Me.lblBtnGuardarVentas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnGuardarVentas.Name = "lblBtnGuardarVentas"
        '
        'btnCerrarVentas
        '
        resources.ApplyResources(Me.btnCerrarVentas, "btnCerrarVentas")
        Me.btnCerrarVentas.Name = "btnCerrarVentas"
        Me.btnCerrarVentas.UseVisualStyleBackColor = True
        '
        'grpbVentas
        '
        Me.grpbVentas.Controls.Add(Me.chkSinDocumentos)
        Me.grpbVentas.Controls.Add(Me.cmbResponsable)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaResponsable)
        Me.grpbVentas.Controls.Add(Me.btnAnexarAutorizacion)
        Me.grpbVentas.Controls.Add(Me.btnDocumentosRelacionados)
        Me.grpbVentas.Controls.Add(Me.txtDocumentosRelacionados)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaDoctosRelacionados)
        Me.grpbVentas.Controls.Add(Me.lblEtiqueta15Dias)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaAnexarAutorizacion)
        Me.grpbVentas.Controls.Add(Me.dtpFechaLimite)
        Me.grpbVentas.Controls.Add(Me.rdbAplicaNotaCreditoNO)
        Me.grpbVentas.Controls.Add(Me.rdbAplicaNotaCreditoSI)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaDTPLimiteAccion)
        Me.grpbVentas.Controls.Add(Me.lblEtiqetaAplicaNotaCredito)
        Me.grpbVentas.Controls.Add(Me.lblEnviadoARevision)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaEnviadoRevision)
        Me.grpbVentas.Controls.Add(Me.txtIndicaRecepcion)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaIndicaRecepcion)
        Me.grpbVentas.Controls.Add(Me.cmbMotivoVentas)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaMotivoVentas)
        Me.grpbVentas.Controls.Add(Me.lblReqAutorizacion)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaRequiereAutorizacion)
        Me.grpbVentas.Controls.Add(Me.lblDiasTranscurridos)
        Me.grpbVentas.Controls.Add(Me.lblModificacionVentas)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaModificacionVentas)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaDiasTranscurridos)
        Me.grpbVentas.Controls.Add(Me.txtObservaciones_Ventas)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaObservacionesVentas)
        Me.grpbVentas.Controls.Add(Me.cmbDestinoProducto)
        Me.grpbVentas.Controls.Add(Me.lblEtiquetaDestinoProd)
        Me.grpbVentas.Controls.Add(Me.txtIdentificadorDocumentos)
        resources.ApplyResources(Me.grpbVentas, "grpbVentas")
        Me.grpbVentas.ForeColor = System.Drawing.Color.Purple
        Me.grpbVentas.Name = "grpbVentas"
        Me.grpbVentas.TabStop = False
        '
        'chkSinDocumentos
        '
        resources.ApplyResources(Me.chkSinDocumentos, "chkSinDocumentos")
        Me.chkSinDocumentos.ForeColor = System.Drawing.Color.Black
        Me.chkSinDocumentos.Name = "chkSinDocumentos"
        Me.chkSinDocumentos.UseVisualStyleBackColor = True
        '
        'cmbResponsable
        '
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbResponsable, "cmbResponsable")
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.Items.AddRange(New Object() {resources.GetString("cmbResponsable.Items")})
        Me.cmbResponsable.Name = "cmbResponsable"
        '
        'lblEtiquetaResponsable
        '
        resources.ApplyResources(Me.lblEtiquetaResponsable, "lblEtiquetaResponsable")
        Me.lblEtiquetaResponsable.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaResponsable.Name = "lblEtiquetaResponsable"
        '
        'btnAnexarAutorizacion
        '
        resources.ApplyResources(Me.btnAnexarAutorizacion, "btnAnexarAutorizacion")
        Me.btnAnexarAutorizacion.Image = Global.Almacen.Vista.My.Resources.Resources.agregar_32
        Me.btnAnexarAutorizacion.Name = "btnAnexarAutorizacion"
        Me.btnAnexarAutorizacion.UseVisualStyleBackColor = True
        '
        'btnDocumentosRelacionados
        '
        resources.ApplyResources(Me.btnDocumentosRelacionados, "btnDocumentosRelacionados")
        Me.btnDocumentosRelacionados.Image = Global.Almacen.Vista.My.Resources.Resources.agregar_32
        Me.btnDocumentosRelacionados.Name = "btnDocumentosRelacionados"
        Me.btnDocumentosRelacionados.UseVisualStyleBackColor = True
        '
        'txtDocumentosRelacionados
        '
        Me.txtDocumentosRelacionados.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtDocumentosRelacionados, "txtDocumentosRelacionados")
        Me.txtDocumentosRelacionados.Name = "txtDocumentosRelacionados"
        Me.txtDocumentosRelacionados.ReadOnly = True
        '
        'lblEtiquetaDoctosRelacionados
        '
        resources.ApplyResources(Me.lblEtiquetaDoctosRelacionados, "lblEtiquetaDoctosRelacionados")
        Me.lblEtiquetaDoctosRelacionados.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaDoctosRelacionados.Name = "lblEtiquetaDoctosRelacionados"
        '
        'lblEtiqueta15Dias
        '
        resources.ApplyResources(Me.lblEtiqueta15Dias, "lblEtiqueta15Dias")
        Me.lblEtiqueta15Dias.ForeColor = System.Drawing.Color.DimGray
        Me.lblEtiqueta15Dias.Name = "lblEtiqueta15Dias"
        '
        'lblEtiquetaAnexarAutorizacion
        '
        resources.ApplyResources(Me.lblEtiquetaAnexarAutorizacion, "lblEtiquetaAnexarAutorizacion")
        Me.lblEtiquetaAnexarAutorizacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEtiquetaAnexarAutorizacion.Name = "lblEtiquetaAnexarAutorizacion"
        '
        'dtpFechaLimite
        '
        Me.dtpFechaLimite.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.dtpFechaLimite.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonShadow
        resources.ApplyResources(Me.dtpFechaLimite, "dtpFechaLimite")
        Me.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaLimite.Name = "dtpFechaLimite"
        Me.dtpFechaLimite.Value = New Date(2019, 1, 3, 0, 0, 0, 0)
        '
        'rdbAplicaNotaCreditoNO
        '
        resources.ApplyResources(Me.rdbAplicaNotaCreditoNO, "rdbAplicaNotaCreditoNO")
        Me.rdbAplicaNotaCreditoNO.ForeColor = System.Drawing.Color.Black
        Me.rdbAplicaNotaCreditoNO.Name = "rdbAplicaNotaCreditoNO"
        Me.rdbAplicaNotaCreditoNO.TabStop = True
        Me.rdbAplicaNotaCreditoNO.UseVisualStyleBackColor = True
        '
        'rdbAplicaNotaCreditoSI
        '
        resources.ApplyResources(Me.rdbAplicaNotaCreditoSI, "rdbAplicaNotaCreditoSI")
        Me.rdbAplicaNotaCreditoSI.ForeColor = System.Drawing.Color.Black
        Me.rdbAplicaNotaCreditoSI.Name = "rdbAplicaNotaCreditoSI"
        Me.rdbAplicaNotaCreditoSI.TabStop = True
        Me.rdbAplicaNotaCreditoSI.UseVisualStyleBackColor = True
        '
        'lblEtiquetaDTPLimiteAccion
        '
        resources.ApplyResources(Me.lblEtiquetaDTPLimiteAccion, "lblEtiquetaDTPLimiteAccion")
        Me.lblEtiquetaDTPLimiteAccion.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaDTPLimiteAccion.Name = "lblEtiquetaDTPLimiteAccion"
        '
        'lblEtiqetaAplicaNotaCredito
        '
        resources.ApplyResources(Me.lblEtiqetaAplicaNotaCredito, "lblEtiqetaAplicaNotaCredito")
        Me.lblEtiqetaAplicaNotaCredito.ForeColor = System.Drawing.Color.Black
        Me.lblEtiqetaAplicaNotaCredito.Name = "lblEtiqetaAplicaNotaCredito"
        '
        'lblEnviadoARevision
        '
        resources.ApplyResources(Me.lblEnviadoARevision, "lblEnviadoARevision")
        Me.lblEnviadoARevision.ForeColor = System.Drawing.Color.Black
        Me.lblEnviadoARevision.Name = "lblEnviadoARevision"
        '
        'lblEtiquetaEnviadoRevision
        '
        resources.ApplyResources(Me.lblEtiquetaEnviadoRevision, "lblEtiquetaEnviadoRevision")
        Me.lblEtiquetaEnviadoRevision.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaEnviadoRevision.Name = "lblEtiquetaEnviadoRevision"
        '
        'txtIndicaRecepcion
        '
        Me.txtIndicaRecepcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtIndicaRecepcion, "txtIndicaRecepcion")
        Me.txtIndicaRecepcion.Name = "txtIndicaRecepcion"
        '
        'lblEtiquetaIndicaRecepcion
        '
        resources.ApplyResources(Me.lblEtiquetaIndicaRecepcion, "lblEtiquetaIndicaRecepcion")
        Me.lblEtiquetaIndicaRecepcion.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaIndicaRecepcion.Name = "lblEtiquetaIndicaRecepcion"
        '
        'cmbMotivoVentas
        '
        resources.ApplyResources(Me.cmbMotivoVentas, "cmbMotivoVentas")
        Me.cmbMotivoVentas.FormattingEnabled = True
        Me.cmbMotivoVentas.Items.AddRange(New Object() {resources.GetString("cmbMotivoVentas.Items")})
        Me.cmbMotivoVentas.Name = "cmbMotivoVentas"
        '
        'lblEtiquetaMotivoVentas
        '
        resources.ApplyResources(Me.lblEtiquetaMotivoVentas, "lblEtiquetaMotivoVentas")
        Me.lblEtiquetaMotivoVentas.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMotivoVentas.Name = "lblEtiquetaMotivoVentas"
        '
        'lblReqAutorizacion
        '
        resources.ApplyResources(Me.lblReqAutorizacion, "lblReqAutorizacion")
        Me.lblReqAutorizacion.ForeColor = System.Drawing.Color.Green
        Me.lblReqAutorizacion.Name = "lblReqAutorizacion"
        '
        'lblEtiquetaRequiereAutorizacion
        '
        resources.ApplyResources(Me.lblEtiquetaRequiereAutorizacion, "lblEtiquetaRequiereAutorizacion")
        Me.lblEtiquetaRequiereAutorizacion.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaRequiereAutorizacion.Name = "lblEtiquetaRequiereAutorizacion"
        '
        'lblDiasTranscurridos
        '
        resources.ApplyResources(Me.lblDiasTranscurridos, "lblDiasTranscurridos")
        Me.lblDiasTranscurridos.ForeColor = System.Drawing.Color.Green
        Me.lblDiasTranscurridos.Name = "lblDiasTranscurridos"
        '
        'lblModificacionVentas
        '
        resources.ApplyResources(Me.lblModificacionVentas, "lblModificacionVentas")
        Me.lblModificacionVentas.ForeColor = System.Drawing.Color.Black
        Me.lblModificacionVentas.Name = "lblModificacionVentas"
        '
        'lblEtiquetaModificacionVentas
        '
        resources.ApplyResources(Me.lblEtiquetaModificacionVentas, "lblEtiquetaModificacionVentas")
        Me.lblEtiquetaModificacionVentas.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaModificacionVentas.Name = "lblEtiquetaModificacionVentas"
        '
        'lblEtiquetaDiasTranscurridos
        '
        resources.ApplyResources(Me.lblEtiquetaDiasTranscurridos, "lblEtiquetaDiasTranscurridos")
        Me.lblEtiquetaDiasTranscurridos.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaDiasTranscurridos.Name = "lblEtiquetaDiasTranscurridos"
        '
        'txtObservaciones_Ventas
        '
        Me.txtObservaciones_Ventas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtObservaciones_Ventas, "txtObservaciones_Ventas")
        Me.txtObservaciones_Ventas.Name = "txtObservaciones_Ventas"
        '
        'lblEtiquetaObservacionesVentas
        '
        resources.ApplyResources(Me.lblEtiquetaObservacionesVentas, "lblEtiquetaObservacionesVentas")
        Me.lblEtiquetaObservacionesVentas.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaObservacionesVentas.Name = "lblEtiquetaObservacionesVentas"
        '
        'cmbDestinoProducto
        '
        resources.ApplyResources(Me.cmbDestinoProducto, "cmbDestinoProducto")
        Me.cmbDestinoProducto.FormattingEnabled = True
        Me.cmbDestinoProducto.Items.AddRange(New Object() {resources.GetString("cmbDestinoProducto.Items"), resources.GetString("cmbDestinoProducto.Items1"), resources.GetString("cmbDestinoProducto.Items2"), resources.GetString("cmbDestinoProducto.Items3"), resources.GetString("cmbDestinoProducto.Items4"), resources.GetString("cmbDestinoProducto.Items5")})
        Me.cmbDestinoProducto.Name = "cmbDestinoProducto"
        '
        'lblEtiquetaDestinoProd
        '
        resources.ApplyResources(Me.lblEtiquetaDestinoProd, "lblEtiquetaDestinoProd")
        Me.lblEtiquetaDestinoProd.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaDestinoProd.Name = "lblEtiquetaDestinoProd"
        '
        'txtIdentificadorDocumentos
        '
        resources.ApplyResources(Me.txtIdentificadorDocumentos, "txtIdentificadorDocumentos")
        Me.txtIdentificadorDocumentos.Name = "txtIdentificadorDocumentos"
        '
        'pnlContenedor
        '
        Appearance3.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Appearance = Appearance3
        '
        'pnlContenedor.ClientArea
        '
        Me.pnlContenedor.ClientArea.Controls.Add(Me.pnlFormCliente)
        resources.ApplyResources(Me.pnlContenedor, "pnlContenedor")
        Me.pnlContenedor.Name = "pnlContenedor"
        '
        'pnlFormCliente
        '
        Me.pnlFormCliente.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFormCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaCantidadTotal)
        Me.pnlFormCliente.Controls.Add(Me.lblCantidadTotal)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaCmbCliente)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaFechaRegistro)
        Me.pnlFormCliente.Controls.Add(Me.lblFechaUsuarioRegistro)
        Me.pnlFormCliente.Controls.Add(Me.cmbCliente)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaAtnClientes)
        Me.pnlFormCliente.Controls.Add(Me.lblAgentes)
        Me.pnlFormCliente.Controls.Add(Me.btnAgregarCliente)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaAgentes)
        Me.pnlFormCliente.Controls.Add(Me.lblAtnClientes)
        Me.pnlFormCliente.Controls.Add(Me.lblResolucion)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaResolucion)
        Me.pnlFormCliente.Controls.Add(Me.lblStatus)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaEstatus)
        Me.pnlFormCliente.Controls.Add(Me.lblFolioDev)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaFolioDev)
        Me.pnlFormCliente.Controls.Add(Me.cmbTipoDevolucion)
        Me.pnlFormCliente.Controls.Add(Me.lblEtiquetaComboTipoDev)
        resources.ApplyResources(Me.pnlFormCliente, "pnlFormCliente")
        Me.pnlFormCliente.ForeColor = System.Drawing.Color.Black
        Me.pnlFormCliente.Name = "pnlFormCliente"
        '
        'lblEtiquetaCantidadTotal
        '
        resources.ApplyResources(Me.lblEtiquetaCantidadTotal, "lblEtiquetaCantidadTotal")
        Me.lblEtiquetaCantidadTotal.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCantidadTotal.Name = "lblEtiquetaCantidadTotal"
        '
        'lblCantidadTotal
        '
        resources.ApplyResources(Me.lblCantidadTotal, "lblCantidadTotal")
        Me.lblCantidadTotal.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadTotal.Name = "lblCantidadTotal"
        '
        'lblEtiquetaCmbCliente
        '
        resources.ApplyResources(Me.lblEtiquetaCmbCliente, "lblEtiquetaCmbCliente")
        Me.lblEtiquetaCmbCliente.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCmbCliente.Name = "lblEtiquetaCmbCliente"
        '
        'lblEtiquetaFechaRegistro
        '
        resources.ApplyResources(Me.lblEtiquetaFechaRegistro, "lblEtiquetaFechaRegistro")
        Me.lblEtiquetaFechaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaFechaRegistro.Name = "lblEtiquetaFechaRegistro"
        '
        'lblFechaUsuarioRegistro
        '
        resources.ApplyResources(Me.lblFechaUsuarioRegistro, "lblFechaUsuarioRegistro")
        Me.lblFechaUsuarioRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUsuarioRegistro.Name = "lblFechaUsuarioRegistro"
        '
        'cmbCliente
        '
        resources.ApplyResources(Me.cmbCliente, "cmbCliente")
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Name = "cmbCliente"
        '
        'lblEtiquetaAtnClientes
        '
        resources.ApplyResources(Me.lblEtiquetaAtnClientes, "lblEtiquetaAtnClientes")
        Me.lblEtiquetaAtnClientes.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaAtnClientes.Name = "lblEtiquetaAtnClientes"
        '
        'lblAgentes
        '
        resources.ApplyResources(Me.lblAgentes, "lblAgentes")
        Me.lblAgentes.ForeColor = System.Drawing.Color.Black
        Me.lblAgentes.Name = "lblAgentes"
        '
        'btnAgregarCliente
        '
        resources.ApplyResources(Me.btnAgregarCliente, "btnAgregarCliente")
        Me.btnAgregarCliente.ForeColor = System.Drawing.Color.Purple
        Me.btnAgregarCliente.Image = Global.Almacen.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'lblEtiquetaAgentes
        '
        resources.ApplyResources(Me.lblEtiquetaAgentes, "lblEtiquetaAgentes")
        Me.lblEtiquetaAgentes.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaAgentes.Name = "lblEtiquetaAgentes"
        '
        'lblAtnClientes
        '
        resources.ApplyResources(Me.lblAtnClientes, "lblAtnClientes")
        Me.lblAtnClientes.ForeColor = System.Drawing.Color.Black
        Me.lblAtnClientes.Name = "lblAtnClientes"
        '
        'lblResolucion
        '
        resources.ApplyResources(Me.lblResolucion, "lblResolucion")
        Me.lblResolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblResolucion.Name = "lblResolucion"
        '
        'lblEtiquetaResolucion
        '
        resources.ApplyResources(Me.lblEtiquetaResolucion, "lblEtiquetaResolucion")
        Me.lblEtiquetaResolucion.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaResolucion.Name = "lblEtiquetaResolucion"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblStatus.Name = "lblStatus"
        '
        'lblEtiquetaEstatus
        '
        resources.ApplyResources(Me.lblEtiquetaEstatus, "lblEtiquetaEstatus")
        Me.lblEtiquetaEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaEstatus.Name = "lblEtiquetaEstatus"
        '
        'lblFolioDev
        '
        resources.ApplyResources(Me.lblFolioDev, "lblFolioDev")
        Me.lblFolioDev.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDev.Name = "lblFolioDev"
        '
        'lblEtiquetaFolioDev
        '
        resources.ApplyResources(Me.lblEtiquetaFolioDev, "lblEtiquetaFolioDev")
        Me.lblEtiquetaFolioDev.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaFolioDev.Name = "lblEtiquetaFolioDev"
        '
        'cmbTipoDevolucion
        '
        Me.cmbTipoDevolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbTipoDevolucion, "cmbTipoDevolucion")
        Me.cmbTipoDevolucion.FormattingEnabled = True
        Me.cmbTipoDevolucion.Items.AddRange(New Object() {resources.GetString("cmbTipoDevolucion.Items"), resources.GetString("cmbTipoDevolucion.Items1")})
        Me.cmbTipoDevolucion.Name = "cmbTipoDevolucion"
        '
        'lblEtiquetaComboTipoDev
        '
        resources.ApplyResources(Me.lblEtiquetaComboTipoDev, "lblEtiquetaComboTipoDev")
        Me.lblEtiquetaComboTipoDev.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaComboTipoDev.Name = "lblEtiquetaComboTipoDev"
        '
        'lblBtnVerAutorizacion
        '
        resources.ApplyResources(Me.lblBtnVerAutorizacion, "lblBtnVerAutorizacion")
        Me.lblBtnVerAutorizacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnVerAutorizacion.Name = "lblBtnVerAutorizacion"
        '
        'btnVerAutorizacion
        '
        resources.ApplyResources(Me.btnVerAutorizacion, "btnVerAutorizacion")
        Me.btnVerAutorizacion.Name = "btnVerAutorizacion"
        Me.btnVerAutorizacion.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.PictureBox1)
        Me.pnlCabecera.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        resources.ApplyResources(Me.pnlCabecera, "pnlCabecera")
        Me.pnlCabecera.Name = "pnlCabecera"
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel9)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel7)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel6)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel5)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel4)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel2)
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel1)
        resources.ApplyResources(Me.pnlAccionesCabecera, "pnlAccionesCabecera")
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.btnSolicitarNotaCredito)
        Me.Panel9.Controls.Add(Me.lblBtnNotaCredito)
        resources.ApplyResources(Me.Panel9, "Panel9")
        Me.Panel9.Name = "Panel9"
        '
        'btnSolicitarNotaCredito
        '
        resources.ApplyResources(Me.btnSolicitarNotaCredito, "btnSolicitarNotaCredito")
        Me.btnSolicitarNotaCredito.Name = "btnSolicitarNotaCredito"
        Me.btnSolicitarNotaCredito.UseVisualStyleBackColor = True
        '
        'lblBtnNotaCredito
        '
        resources.ApplyResources(Me.lblBtnNotaCredito, "lblBtnNotaCredito")
        Me.lblBtnNotaCredito.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnNotaCredito.Name = "lblBtnNotaCredito"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnSolicitarProcesamientoAlmacen)
        Me.Panel7.Controls.Add(Me.lblBtnProcesamientoAlmacen)
        resources.ApplyResources(Me.Panel7, "Panel7")
        Me.Panel7.Name = "Panel7"
        '
        'btnSolicitarProcesamientoAlmacen
        '
        resources.ApplyResources(Me.btnSolicitarProcesamientoAlmacen, "btnSolicitarProcesamientoAlmacen")
        Me.btnSolicitarProcesamientoAlmacen.Name = "btnSolicitarProcesamientoAlmacen"
        Me.btnSolicitarProcesamientoAlmacen.UseVisualStyleBackColor = True
        '
        'lblBtnProcesamientoAlmacen
        '
        resources.ApplyResources(Me.lblBtnProcesamientoAlmacen, "lblBtnProcesamientoAlmacen")
        Me.lblBtnProcesamientoAlmacen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnProcesamientoAlmacen.Name = "lblBtnProcesamientoAlmacen"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnVerAutorizacion)
        Me.Panel6.Controls.Add(Me.lblBtnVerAutorizacion)
        resources.ApplyResources(Me.Panel6, "Panel6")
        Me.Panel6.Name = "Panel6"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnSolicitarRevisionVentas)
        Me.Panel5.Controls.Add(Me.lblBtnRevisionVentas)
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.Name = "Panel5"
        '
        'btnSolicitarRevisionVentas
        '
        resources.ApplyResources(Me.btnSolicitarRevisionVentas, "btnSolicitarRevisionVentas")
        Me.btnSolicitarRevisionVentas.Name = "btnSolicitarRevisionVentas"
        Me.btnSolicitarRevisionVentas.UseVisualStyleBackColor = True
        '
        'lblBtnRevisionVentas
        '
        resources.ApplyResources(Me.lblBtnRevisionVentas, "lblBtnRevisionVentas")
        Me.lblBtnRevisionVentas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnRevisionVentas.Name = "lblBtnRevisionVentas"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSolicitarDocumentos)
        Me.Panel4.Controls.Add(Me.lblBtnSolicitarDocumentos)
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'btnSolicitarDocumentos
        '
        resources.ApplyResources(Me.btnSolicitarDocumentos, "btnSolicitarDocumentos")
        Me.btnSolicitarDocumentos.Image = Global.Almacen.Vista.My.Resources.Resources.incidencia
        Me.btnSolicitarDocumentos.Name = "btnSolicitarDocumentos"
        Me.btnSolicitarDocumentos.UseVisualStyleBackColor = True
        '
        'lblBtnSolicitarDocumentos
        '
        resources.ApplyResources(Me.lblBtnSolicitarDocumentos, "lblBtnSolicitarDocumentos")
        Me.lblBtnSolicitarDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnSolicitarDocumentos.Name = "lblBtnSolicitarDocumentos"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnVerAgregarDetalle)
        Me.Panel2.Controls.Add(Me.lblBtnDetalles)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'btnVerAgregarDetalle
        '
        resources.ApplyResources(Me.btnVerAgregarDetalle, "btnVerAgregarDetalle")
        Me.btnVerAgregarDetalle.Name = "btnVerAgregarDetalle"
        Me.btnVerAgregarDetalle.UseVisualStyleBackColor = True
        '
        'lblBtnDetalles
        '
        resources.ApplyResources(Me.lblBtnDetalles, "lblBtnDetalles")
        Me.lblBtnDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnDetalles.Name = "lblBtnDetalles"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.lblBntEditar)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'btnEditar
        '
        resources.ApplyResources(Me.btnEditar, "btnEditar")
        Me.btnEditar.Image = Global.Almacen.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblBntEditar
        '
        resources.ApplyResources(Me.lblBntEditar, "lblBntEditar")
        Me.lblBntEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBntEditar.Name = "lblBntEditar"
        '
        'lblTitulo
        '
        resources.ApplyResources(Me.lblTitulo, "lblTitulo")
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Name = "lblTitulo"
        '
        'WindowDockingArea7
        '
        resources.ApplyResources(Me.WindowDockingArea7, "WindowDockingArea7")
        Me.WindowDockingArea7.Name = "WindowDockingArea7"
        '
        'DockableWindow9
        '
        resources.ApplyResources(Me.DockableWindow9, "DockableWindow9")
        Me.DockableWindow9.Name = "DockableWindow9"
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'dockManagerDevoluciones
        '
        Me.dockManagerDevoluciones.AutoHideDelay = 3600000
        Me.dockManagerDevoluciones.CompressUnpinnedTabs = False
        Me.dockManagerDevoluciones.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.[False]
        Me.dockManagerDevoluciones.DefaultPaneSettings.AllowMinimize = Infragistics.Win.DefaultableBoolean.[True]
        DockAreaPane1.DockedBefore = New System.Guid("43c2ddeb-a71d-4f46-abaf-23f01f72951d")
        DockAreaPane1.Key = "dckAlmacen"
        DockableControlPane1.Control = Me.pnlAlmacen
        DockableControlPane1.FlyoutSize = New System.Drawing.Size(-1, 470)
        DockableControlPane1.Key = "dckAlmacen"
        DockableControlPane1.OriginalControlBounds = New System.Drawing.Rectangle(0, 12, 994, 457)
        DockableControlPane1.Pinned = False
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DockableControlPane1.Settings.TabAppearance = Appearance4
        DockableControlPane1.Size = New System.Drawing.Size(100, 100)
        resources.ApplyResources(DockableControlPane1, "DockableControlPane1")
        DockAreaPane1.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane1})
        DockAreaPane1.Size = New System.Drawing.Size(1241, 356)
        DockableControlPane2.Control = Me.pnlVentasCobranza
        DockableControlPane2.FlyoutSize = New System.Drawing.Size(-1, 471)
        DockableControlPane2.OriginalControlBounds = New System.Drawing.Rectangle(8, 8, 994, 78)
        DockableControlPane2.Pinned = False
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance5.FontData.BoldAsString = resources.GetString("resource.BoldAsString")
        Appearance5.ForeColor = System.Drawing.Color.White
        DockableControlPane2.Settings.TabAppearance = Appearance5
        DockableControlPane2.Size = New System.Drawing.Size(100, 100)
        resources.ApplyResources(DockableControlPane2, "DockableControlPane2")
        DockAreaPane2.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane2})
        DockAreaPane2.Size = New System.Drawing.Size(1073, 355)
        Me.dockManagerDevoluciones.DockAreas.AddRange(New Infragistics.Win.UltraWinDock.DockAreaPane() {DockAreaPane1, DockAreaPane2})
        Me.dockManagerDevoluciones.HostControl = Me
        Me.dockManagerDevoluciones.HotTracking = False
        Me.dockManagerDevoluciones.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer
        Me.dockManagerDevoluciones.ShowCloseButton = False
        Me.dockManagerDevoluciones.UnpinnedTabStyle = Infragistics.Win.UltraWinTabs.TabStyle.Flat
        '
        '_DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl
        '
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.Controls.Add(Me.DockableWindow5)
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.Controls.Add(Me.DockableWindow1)
        resources.ApplyResources(Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl, "_DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl")
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.Name = "_DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl"
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.Owner = Me.dockManagerDevoluciones
        '
        'DockableWindow5
        '
        Me.DockableWindow5.Controls.Add(Me.pnlAlmacen)
        resources.ApplyResources(Me.DockableWindow5, "DockableWindow5")
        Me.DockableWindow5.Name = "DockableWindow5"
        Me.DockableWindow5.Owner = Me.dockManagerDevoluciones
        '
        'DockableWindow1
        '
        Me.DockableWindow1.Controls.Add(Me.pnlVentasCobranza)
        resources.ApplyResources(Me.DockableWindow1, "DockableWindow1")
        Me.DockableWindow1.Name = "DockableWindow1"
        Me.DockableWindow1.Owner = Me.dockManagerDevoluciones
        '
        '_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight
        '
        resources.ApplyResources(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight, "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight")
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight.Name = "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight"
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight.Owner = Me.dockManagerDevoluciones
        '
        '_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom
        '
        resources.ApplyResources(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom, "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom")
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom.Name = "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom"
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom.Owner = Me.dockManagerDevoluciones
        '
        '_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop
        '
        resources.ApplyResources(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop, "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop")
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop.Name = "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop"
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop.Owner = Me.dockManagerDevoluciones
        '
        '_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft
        '
        resources.ApplyResources(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft, "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft")
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft.Name = "_DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft"
        Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft.Owner = Me.dockManagerDevoluciones
        '
        'ofdFichaTecnica
        '
        Me.ofdFichaTecnica.FileName = "Seleccione la imagen"
        '
        'WindowDockingArea12
        '
        resources.ApplyResources(Me.WindowDockingArea12, "WindowDockingArea12")
        Me.WindowDockingArea12.Name = "WindowDockingArea12"
        Me.WindowDockingArea12.Owner = Me.dockManagerDevoluciones
        '
        'WindowDockingArea15
        '
        resources.ApplyResources(Me.WindowDockingArea15, "WindowDockingArea15")
        Me.WindowDockingArea15.Name = "WindowDockingArea15"
        Me.WindowDockingArea15.Owner = Me.dockManagerDevoluciones
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'DevolucionCliente_CapturaGeneral_Tab_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.Controls.Add(Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.WindowDockingArea12)
        Me.Controls.Add(Me.WindowDockingArea15)
        Me.Controls.Add(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop)
        Me.Controls.Add(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom)
        Me.Controls.Add(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft)
        Me.Controls.Add(Me._DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "DevolucionCliente_CapturaGeneral_Tab_Form"
        Me.ShowInTaskbar = False
        Me.pnlAlmacen.ClientArea.ResumeLayout(False)
        Me.pnlAlmacen.ResumeLayout(False)
        Me.pnlFormEtiquetado.ResumeLayout(False)
        Me.pnlFormEtiquetado.PerformLayout()
        Me.grpbDiasProcesamiento.ResumeLayout(False)
        Me.grpbDiasProcesamiento.PerformLayout()
        CType(Me.nudDiasProcesamiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpbArticulos.ResumeLayout(False)
        Me.grpbArticulos.PerformLayout()
        Me.grpbPaqueteria.ResumeLayout(False)
        Me.grpbPaqueteria.PerformLayout()
        Me.grpbRecepcion.ResumeLayout(False)
        Me.grpbRecepcion.PerformLayout()
        Me.grpbComentarios.ResumeLayout(False)
        Me.grpbComentarios.PerformLayout()
        Me.grpbResolucion.ResumeLayout(False)
        Me.grpbResolucion.PerformLayout()
        Me.pnlVentasCobranza.ClientArea.ResumeLayout(False)
        Me.pnlVentasCobranza.ResumeLayout(False)
        Me.pnlFormMKT.ResumeLayout(False)
        Me.grpbResolucion_pnlVentas.ResumeLayout(False)
        Me.grpbResolucion_pnlVentas.PerformLayout()
        Me.grpbCobranza.ResumeLayout(False)
        Me.grpbCobranza.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdNotasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvNotasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbGuardarVentas.ResumeLayout(False)
        Me.grpbGuardarVentas.PerformLayout()
        Me.grpbVentas.ResumeLayout(False)
        Me.grpbVentas.PerformLayout()
        Me.pnlContenedor.ClientArea.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlFormCliente.ResumeLayout(False)
        Me.pnlFormCliente.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dockManagerDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me._DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl.ResumeLayout(False)
        Me.DockableWindow5.ResumeLayout(False)
        Me.DockableWindow1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents pnlVentasCobranza As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents pnlFormCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlAlmacen As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents WindowDockingArea7 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents DockableWindow9 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dockManagerDevoluciones As Infragistics.Win.UltraWinDock.UltraDockManager
    Friend WithEvents _DevolucionCliente_CapturaGeneral_Tab_FormAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
    Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents _DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _DevolucionCliente_CapturaGeneral_Tab_FormUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents WindowDockingArea12 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents WindowDockingArea15 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents pnlFormEtiquetado As System.Windows.Forms.Panel
    Friend WithEvents pnlFormMKT As System.Windows.Forms.Panel
    Friend WithEvents ofdFichaTecnica As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DockableWindow5 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents AppStylistRuntime1 As Infragistics.Win.AppStyling.Runtime.AppStylistRuntime
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSolicitarNotaCredito As Button
    Friend WithEvents lblBtnNotaCredito As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblBntEditar As Label
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnVerAgregarDetalle As Button
    Friend WithEvents lblBtnDetalles As Label
    Friend WithEvents lblBtnProcesamientoAlmacen As Label
    Friend WithEvents btnSolicitarRevisionVentas As Button
    Friend WithEvents btnSolicitarProcesamientoAlmacen As Button
    Friend WithEvents lblBtnRevisionVentas As Label
    Friend WithEvents grpbArticulos As GroupBox
    Friend WithEvents lblEtiquetaModelos As Label
    Friend WithEvents grpbPaqueteria As GroupBox
    Friend WithEvents txtNumeroGuia As TextBox
    Friend WithEvents lblEtiquetaNumGuia As Label
    Friend WithEvents lblEtiquetaEmpresa As Label
    Friend WithEvents cmbEmpresa As ComboBox
    Friend WithEvents lblEtiquetaFlete As Label
    Friend WithEvents cmbFlete As ComboBox
    Friend WithEvents lblEtiquetaCosto As Label
    Friend WithEvents txtCosto As MaskedTextBox
    Friend WithEvents grpbRecepcion As GroupBox
    Friend WithEvents cmbRecibio As ComboBox
    Friend WithEvents cmbUnidad As ComboBox
    Friend WithEvents lblEtiquetaUnidad As Label
    Friend WithEvents dtpFechaRecepcion As DateTimePicker
    Friend WithEvents lblEtiquetaRecibio As Label
    Friend WithEvents txtCajas As MaskedTextBox
    Friend WithEvents lblEtiquetaCajas As Label
    Friend WithEvents lblNumSemana As Label
    Friend WithEvents lblDtpFechaRecepcion As Label
    Friend WithEvents lblEtiquetaSemana As Label
    Friend WithEvents lblEtiquetaCantidad As Label
    Friend WithEvents txtCantidad As MaskedTextBox
    Friend WithEvents cmbMotivoInicial As ComboBox
    Friend WithEvents lblEtiquetaMotivoIniDev As Label
    Friend WithEvents grpbComentarios As GroupBox
    Friend WithEvents txtComentarios As TextBox
    Friend WithEvents grpbResolucion As GroupBox
    Friend WithEvents lblEtiquetaProcede As Label
    Friend WithEvents txtProcedeAutoriza_pnlAlmacen As TextBox
    Friend WithEvents rdbProcedeAutoriza_pnlAlmacen As RadioButton
    Friend WithEvents rdbPendiente_pnlAlmacen As RadioButton
    Friend WithEvents rdbNoProcede_pnlAlmacen As RadioButton
    Friend WithEvents rdbProcede_pnlAlmacen As RadioButton
    Friend WithEvents grpbVentas As GroupBox
    Friend WithEvents lblBtnVerAutorizacion As Label
    Friend WithEvents btnVerAutorizacion As Button
    Friend WithEvents cmbResponsable As ComboBox
    Friend WithEvents lblEtiquetaResponsable As Label
    Friend WithEvents btnAnexarAutorizacion As Button
    Friend WithEvents btnDocumentosRelacionados As Button
    Friend WithEvents txtDocumentosRelacionados As TextBox
    Friend WithEvents lblEtiquetaDoctosRelacionados As Label
    Friend WithEvents lblEtiqueta15Dias As Label
    Friend WithEvents lblEtiquetaAnexarAutorizacion As Label
    Friend WithEvents dtpFechaLimite As DateTimePicker
    Friend WithEvents rdbAplicaNotaCreditoNO As RadioButton
    Friend WithEvents rdbAplicaNotaCreditoSI As RadioButton
    Friend WithEvents lblEtiquetaDTPLimiteAccion As Label
    Friend WithEvents lblEtiqetaAplicaNotaCredito As Label
    Friend WithEvents lblEnviadoARevision As Label
    Friend WithEvents lblEtiquetaEnviadoRevision As Label
    Friend WithEvents txtIndicaRecepcion As TextBox
    Friend WithEvents lblEtiquetaIndicaRecepcion As Label
    Friend WithEvents cmbMotivoVentas As ComboBox
    Friend WithEvents lblEtiquetaMotivoVentas As Label
    Friend WithEvents lblReqAutorizacion As Label
    Friend WithEvents lblEtiquetaRequiereAutorizacion As Label
    Friend WithEvents lblDiasTranscurridos As Label
    Friend WithEvents lblModificacionVentas As Label
    Friend WithEvents lblEtiquetaModificacionVentas As Label
    Friend WithEvents lblEtiquetaDiasTranscurridos As Label
    Friend WithEvents txtObservaciones_Ventas As TextBox
    Friend WithEvents lblEtiquetaObservacionesVentas As Label
    Friend WithEvents cmbDestinoProducto As ComboBox
    Friend WithEvents lblEtiquetaDestinoProd As Label
    Friend WithEvents txtIdentificadorDocumentos As TextBox
    Friend WithEvents lblEtiquetaCmbCliente As Label
    Friend WithEvents lblEtiquetaFechaRegistro As Label
    Friend WithEvents lblFechaUsuarioRegistro As Label
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents lblEtiquetaAtnClientes As Label
    Friend WithEvents lblAgentes As Label
    Friend WithEvents btnAgregarCliente As Button
    Friend WithEvents lblEtiquetaAgentes As Label
    Friend WithEvents lblAtnClientes As Label
    Friend WithEvents lblResolucion As Label
    Friend WithEvents lblEtiquetaResolucion As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblEtiquetaEstatus As Label
    Friend WithEvents lblFolioDev As Label
    Friend WithEvents lblEtiquetaFolioDev As Label
    Friend WithEvents cmbTipoDevolucion As ComboBox
    Friend WithEvents lblEtiquetaComboTipoDev As Label
    Friend WithEvents grpbCobranza As GroupBox
    Friend WithEvents lblEtiquetaCantidadAplicada As Label
    Friend WithEvents lblEtiquetaCantidadPorAplicar As Label
    Friend WithEvents lblCantidadPorAplicar As Label
    Friend WithEvents lblDevolucionSICY As Label
    Friend WithEvents lblCantidadAplicada As Label
    Friend WithEvents lblEtiquetaDevSICY As Label
    Friend WithEvents lblSolicitudNotaCredito As Label
    Friend WithEvents lblEtiquetaSolicitaNotaCredito As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblBtnCerrar As Label
    Friend WithEvents lblBtnGuardar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents grpbGuardarVentas As GroupBox
    Friend WithEvents btnGuardar_Ventas As Button
    Friend WithEvents lblBtnCerrarVentas As Label
    Friend WithEvents lblBtnGuardarVentas As Label
    Friend WithEvents btnCerrarVentas As Button
    Friend WithEvents cmbUbicacion As ComboBox
    Friend WithEvents lblEtiquetaUbicacion As Label
    Friend WithEvents lblEtiquetaCantidadTotal As Label
    Friend WithEvents lblCantidadTotal As Label
    Friend WithEvents chkSinDocumentos As CheckBox
    Friend WithEvents lblBtnSolicitarDocumentos As Label
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpbResolucion_pnlVentas As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcedeAutoriza_pnlVentas As TextBox
    Friend WithEvents rdbProcedeAutoriza_pnlVentas As RadioButton
    Friend WithEvents rdbPendiente_pnlVentas As RadioButton
    Friend WithEvents rdbNoProcede_pnlVentas As RadioButton
    Friend WithEvents rdbProcede_pnlVentas As RadioButton
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnExportarExcelApartados As Button
    Friend WithEvents lblActualizarDatos As Label
    Friend WithEvents grdNotasCredito As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvNotasCredito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OTSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Agente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoOT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrdenCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaEntregaProgramacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPreparacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Confirmados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PorConfirmar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cancelados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioModifico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaModificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiasFaltantes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MotivoCancelacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Observaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCitaEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblClasificacion As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btnSolicitarDocumentos As Button
    Friend WithEvents grpbDiasProcesamiento As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents nudDiasProcesamiento As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents lblEtiquetaIva As Label
    Friend WithEvents lblMontoIVA As Label
    Friend WithEvents lblDescuento As Label
    Friend WithEvents lblMontoDescuento As Label
    Friend WithEvents lblEtiquetaMontoDescuento As Label
    Friend WithEvents lblEtiquetaMontoMasIva As Label
    Friend WithEvents lblSumatoriaMonto As Label
    Friend WithEvents txtObservacionFactura As TextBox
    Friend WithEvents lblEtiquetaMontoTotal As Label
    Friend WithEvents lblMontoTotal As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
