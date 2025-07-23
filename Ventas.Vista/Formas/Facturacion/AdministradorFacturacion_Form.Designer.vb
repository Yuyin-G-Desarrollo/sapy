<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministradorFacturacion_Form
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorFacturacion_Form))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlGenerarXMLSap = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnGenerarXMLSap = New System.Windows.Forms.Button()
        Me.pnlSolicitudCancelacion = New System.Windows.Forms.Panel()
        Me.lblSolicitarCancelacion = New System.Windows.Forms.Label()
        Me.btnSolicitarCancelacion = New System.Windows.Forms.Button()
        Me.pnlRefacturar = New System.Windows.Forms.Panel()
        Me.lblRefacturar = New System.Windows.Forms.Label()
        Me.btnRefacturar = New System.Windows.Forms.Button()
        Me.pnlAnexarArchivos = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCargarPDF_XML = New System.Windows.Forms.Button()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExportarReporte = New System.Windows.Forms.Button()
        Me.PnlGenerarAddenda = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGeneraAddenda = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEnvioCorreo = New System.Windows.Forms.Button()
        Me.pnlEnvioCorreo = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnActualizarEstatusCancelacionSAT = New System.Windows.Forms.Button()
        Me.pnlReintentarCancelacionSAT = New System.Windows.Forms.Panel()
        Me.btnReintentarCancelacion = New System.Windows.Forms.Button()
        Me.lblTextoReintentarCancelacion = New System.Windows.Forms.Label()
        Me.pnlCancelar = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTextoCancelar = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblTextoExportar = New System.Windows.Forms.Label()
        Me.pnlTimbrarDocumento = New System.Windows.Forms.Panel()
        Me.btnTimbrarDocumento = New System.Windows.Forms.Button()
        Me.lblTimbrarDocumento = New System.Windows.Forms.Label()
        Me.pnlImprimirPDF = New System.Windows.Forms.Panel()
        Me.btnImprimirPDF = New System.Windows.Forms.Button()
        Me.lblTextoImprimirPDF = New System.Windows.Forms.Label()
        Me.pnlVerDetalles = New System.Windows.Forms.Panel()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.lblTextoVerDetalles = New System.Windows.Forms.Label()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Cita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cancelados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PorConfirmar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Confirmados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPreparacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaEntregaProgramacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrdenCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoOT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Agente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OTSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Seleccionar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UsuarioModifico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaModificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiasFaltantes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MotivoCancelacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EstatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Observaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCitaEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdDocumentos = New DevExpress.XtraGrid.GridControl()
        Me.bgvDocumentos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnPBar = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlColorFA = New System.Windows.Forms.Panel()
        Me.lblInfoSNC = New System.Windows.Forms.Label()
        Me.lblInfoRNC = New System.Windows.Forms.Label()
        Me.lblEstatusCancelacion = New System.Windows.Forms.Label()
        Me.lblCanceladaEsperaAceptacion = New System.Windows.Forms.Label()
        Me.pnlEstatusCancelacion = New System.Windows.Forms.Panel()
        Me.pnlCanceladaEsperaAceptacion = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCorreoNoEnviado = New System.Windows.Forms.Panel()
        Me.lblDiseñoCanceladoFaltaSAT = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlCanceladoFaltaSAT = New System.Windows.Forms.Panel()
        Me.pnlStatusNoTimbrado = New System.Windows.Forms.Panel()
        Me.lblDiseñoCancelado = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkMostrarOT = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroStatus = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroStatus = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdStatus = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmbCEDIS = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAgregarFiltroEmisor = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltroEmisor = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdEmisor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoFechaFacturacion = New System.Windows.Forms.RadioButton()
        Me.rdoFechaCancelacion = New System.Windows.Forms.RadioButton()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFolioOT = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtFiltroFolioOT = New System.Windows.Forms.MaskedTextBox()
        Me.gboxCliente = New System.Windows.Forms.GroupBox()
        Me.btnAgregarFiltroCliente = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxFolioFactura = New System.Windows.Forms.GroupBox()
        Me.txtFiltroFactura = New System.Windows.Forms.TextBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.grdFactura = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxFolioDocto = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdFiltroDocumento = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtFiltroDocumento = New System.Windows.Forms.MaskedTextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmsTipoImpresion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiRegenerarPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReimprimirPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsVerOTs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmVerOts = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.pnlGenerarXMLSap.SuspendLayout()
        Me.pnlSolicitudCancelacion.SuspendLayout()
        Me.pnlRefacturar.SuspendLayout()
        Me.pnlAnexarArchivos.SuspendLayout()
        Me.pnl.SuspendLayout()
        Me.PnlGenerarAddenda.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlEnvioCorreo.SuspendLayout()
        Me.pnlReintentarCancelacionSAT.SuspendLayout()
        Me.pnlCancelar.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTimbrarDocumento.SuspendLayout()
        Me.pnlImprimirPDF.SuspendLayout()
        Me.pnlVerDetalles.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnPBar.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdEmisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFolioOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCliente.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFolioFactura.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFolioDocto.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdFiltroDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.cmsTipoImpresion.SuspendLayout()
        Me.cmsVerOTs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_321
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(51, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1117, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(135, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(48, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(91, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(5, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Mostrar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(90, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(9, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(939, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.pnlGenerarXMLSap)
        Me.pnlVentas.Controls.Add(Me.pnlSolicitudCancelacion)
        Me.pnlVentas.Controls.Add(Me.pnlRefacturar)
        Me.pnlVentas.Controls.Add(Me.pnlAnexarArchivos)
        Me.pnlVentas.Controls.Add(Me.pnl)
        Me.pnlVentas.Controls.Add(Me.PnlGenerarAddenda)
        Me.pnlVentas.Controls.Add(Me.Panel10)
        Me.pnlVentas.Controls.Add(Me.pnlEnvioCorreo)
        Me.pnlVentas.Controls.Add(Me.pnlReintentarCancelacionSAT)
        Me.pnlVentas.Controls.Add(Me.pnlCancelar)
        Me.pnlVentas.Controls.Add(Me.pnlExportar)
        Me.pnlVentas.Controls.Add(Me.pnlTimbrarDocumento)
        Me.pnlVentas.Controls.Add(Me.pnlImprimirPDF)
        Me.pnlVentas.Controls.Add(Me.pnlVerDetalles)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 0)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(936, 65)
        Me.pnlVentas.TabIndex = 108
        '
        'pnlGenerarXMLSap
        '
        Me.pnlGenerarXMLSap.Controls.Add(Me.Label9)
        Me.pnlGenerarXMLSap.Controls.Add(Me.btnGenerarXMLSap)
        Me.pnlGenerarXMLSap.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarXMLSap.Location = New System.Drawing.Point(868, 0)
        Me.pnlGenerarXMLSap.Name = "pnlGenerarXMLSap"
        Me.pnlGenerarXMLSap.Size = New System.Drawing.Size(62, 65)
        Me.pnlGenerarXMLSap.TabIndex = 132
        Me.pnlGenerarXMLSap.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(6, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 26)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = " Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XML SAP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerarXMLSap
        '
        Me.btnGenerarXMLSap.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerarXMLSap.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarXMLSap.Image = Global.Ventas.Vista.My.Resources.Resources.editar_3211
        Me.btnGenerarXMLSap.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarXMLSap.Location = New System.Drawing.Point(16, 3)
        Me.btnGenerarXMLSap.Name = "btnGenerarXMLSap"
        Me.btnGenerarXMLSap.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarXMLSap.TabIndex = 113
        Me.btnGenerarXMLSap.UseVisualStyleBackColor = True
        '
        'pnlSolicitudCancelacion
        '
        Me.pnlSolicitudCancelacion.Controls.Add(Me.lblSolicitarCancelacion)
        Me.pnlSolicitudCancelacion.Controls.Add(Me.btnSolicitarCancelacion)
        Me.pnlSolicitudCancelacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSolicitudCancelacion.Location = New System.Drawing.Point(802, 0)
        Me.pnlSolicitudCancelacion.Name = "pnlSolicitudCancelacion"
        Me.pnlSolicitudCancelacion.Size = New System.Drawing.Size(66, 65)
        Me.pnlSolicitudCancelacion.TabIndex = 133
        Me.pnlSolicitudCancelacion.Visible = False
        '
        'lblSolicitarCancelacion
        '
        Me.lblSolicitarCancelacion.AutoSize = True
        Me.lblSolicitarCancelacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSolicitarCancelacion.Location = New System.Drawing.Point(4, 36)
        Me.lblSolicitarCancelacion.Name = "lblSolicitarCancelacion"
        Me.lblSolicitarCancelacion.Size = New System.Drawing.Size(66, 39)
        Me.lblSolicitarCancelacion.TabIndex = 112
        Me.lblSolicitarCancelacion.Text = "Solicitud" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cancelación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblSolicitarCancelacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSolicitarCancelacion
        '
        Me.btnSolicitarCancelacion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSolicitarCancelacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSolicitarCancelacion.Image = Global.Ventas.Vista.My.Resources.Resources.siguiente
        Me.btnSolicitarCancelacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSolicitarCancelacion.Location = New System.Drawing.Point(20, 4)
        Me.btnSolicitarCancelacion.Name = "btnSolicitarCancelacion"
        Me.btnSolicitarCancelacion.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitarCancelacion.TabIndex = 113
        Me.btnSolicitarCancelacion.UseVisualStyleBackColor = True
        '
        'pnlRefacturar
        '
        Me.pnlRefacturar.Controls.Add(Me.lblRefacturar)
        Me.pnlRefacturar.Controls.Add(Me.btnRefacturar)
        Me.pnlRefacturar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRefacturar.Location = New System.Drawing.Point(741, 0)
        Me.pnlRefacturar.Name = "pnlRefacturar"
        Me.pnlRefacturar.Size = New System.Drawing.Size(61, 65)
        Me.pnlRefacturar.TabIndex = 129
        Me.pnlRefacturar.Visible = False
        '
        'lblRefacturar
        '
        Me.lblRefacturar.AutoSize = True
        Me.lblRefacturar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRefacturar.Location = New System.Drawing.Point(3, 35)
        Me.lblRefacturar.Name = "lblRefacturar"
        Me.lblRefacturar.Size = New System.Drawing.Size(57, 26)
        Me.lblRefacturar.TabIndex = 112
        Me.lblRefacturar.Text = "Enviar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Refacturar"
        Me.lblRefacturar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnRefacturar
        '
        Me.btnRefacturar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRefacturar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRefacturar.Image = CType(resources.GetObject("btnRefacturar.Image"), System.Drawing.Image)
        Me.btnRefacturar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefacturar.Location = New System.Drawing.Point(16, 3)
        Me.btnRefacturar.Name = "btnRefacturar"
        Me.btnRefacturar.Size = New System.Drawing.Size(32, 32)
        Me.btnRefacturar.TabIndex = 113
        Me.btnRefacturar.UseVisualStyleBackColor = True
        '
        'pnlAnexarArchivos
        '
        Me.pnlAnexarArchivos.Controls.Add(Me.Label6)
        Me.pnlAnexarArchivos.Controls.Add(Me.btnCargarPDF_XML)
        Me.pnlAnexarArchivos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAnexarArchivos.Location = New System.Drawing.Point(673, 0)
        Me.pnlAnexarArchivos.Name = "pnlAnexarArchivos"
        Me.pnlAnexarArchivos.Size = New System.Drawing.Size(68, 65)
        Me.pnlAnexarArchivos.TabIndex = 127
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(13, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 26)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Anexar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "archivos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCargarPDF_XML
        '
        Me.btnCargarPDF_XML.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCargarPDF_XML.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCargarPDF_XML.Image = Global.Ventas.Vista.My.Resources.Resources.agregar_pdf
        Me.btnCargarPDF_XML.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCargarPDF_XML.Location = New System.Drawing.Point(20, 3)
        Me.btnCargarPDF_XML.Name = "btnCargarPDF_XML"
        Me.btnCargarPDF_XML.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarPDF_XML.TabIndex = 113
        Me.btnCargarPDF_XML.UseVisualStyleBackColor = True
        '
        'pnl
        '
        Me.pnl.Controls.Add(Me.Label4)
        Me.pnl.Controls.Add(Me.btnExportarReporte)
        Me.pnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl.Location = New System.Drawing.Point(611, 0)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(62, 65)
        Me.pnl.TabIndex = 125
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(15, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 26)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reporte"
        '
        'btnExportarReporte
        '
        Me.btnExportarReporte.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarReporte.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarReporte.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarReporte.Location = New System.Drawing.Point(18, 3)
        Me.btnExportarReporte.Name = "btnExportarReporte"
        Me.btnExportarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarReporte.TabIndex = 113
        Me.btnExportarReporte.UseVisualStyleBackColor = True
        '
        'PnlGenerarAddenda
        '
        Me.PnlGenerarAddenda.Controls.Add(Me.Label3)
        Me.PnlGenerarAddenda.Controls.Add(Me.btnGeneraAddenda)
        Me.PnlGenerarAddenda.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlGenerarAddenda.Location = New System.Drawing.Point(555, 0)
        Me.PnlGenerarAddenda.Name = "PnlGenerarAddenda"
        Me.PnlGenerarAddenda.Size = New System.Drawing.Size(56, 65)
        Me.PnlGenerarAddenda.TabIndex = 124
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 26)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Addenda"
        '
        'btnGeneraAddenda
        '
        Me.btnGeneraAddenda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGeneraAddenda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGeneraAddenda.Image = Global.Ventas.Vista.My.Resources.Resources.nuevo_32
        Me.btnGeneraAddenda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGeneraAddenda.Location = New System.Drawing.Point(14, 3)
        Me.btnGeneraAddenda.Name = "btnGeneraAddenda"
        Me.btnGeneraAddenda.Size = New System.Drawing.Size(32, 32)
        Me.btnGeneraAddenda.TabIndex = 108
        Me.btnGeneraAddenda.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Label2)
        Me.Panel10.Controls.Add(Me.btnEnvioCorreo)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.Location = New System.Drawing.Point(494, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(61, 65)
        Me.Panel10.TabIndex = 123
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(17, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 26)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Enviar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEnvioCorreo
        '
        Me.btnEnvioCorreo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnvioCorreo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnvioCorreo.Image = Global.Ventas.Vista.My.Resources.Resources.Email
        Me.btnEnvioCorreo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnvioCorreo.Location = New System.Drawing.Point(20, 3)
        Me.btnEnvioCorreo.Name = "btnEnvioCorreo"
        Me.btnEnvioCorreo.Size = New System.Drawing.Size(32, 32)
        Me.btnEnvioCorreo.TabIndex = 114
        Me.btnEnvioCorreo.UseVisualStyleBackColor = True
        '
        'pnlEnvioCorreo
        '
        Me.pnlEnvioCorreo.Controls.Add(Me.Label5)
        Me.pnlEnvioCorreo.Controls.Add(Me.btnActualizarEstatusCancelacionSAT)
        Me.pnlEnvioCorreo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnvioCorreo.Location = New System.Drawing.Point(422, 0)
        Me.pnlEnvioCorreo.Name = "pnlEnvioCorreo"
        Me.pnlEnvioCorreo.Size = New System.Drawing.Size(72, 65)
        Me.pnlEnvioCorreo.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(-1, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 26)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "  Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cancelaciones SAT"
        '
        'btnActualizarEstatusCancelacionSAT
        '
        Me.btnActualizarEstatusCancelacionSAT.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizarEstatusCancelacionSAT.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarEstatusCancelacionSAT.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizarEstatusCancelacionSAT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarEstatusCancelacionSAT.Location = New System.Drawing.Point(23, 3)
        Me.btnActualizarEstatusCancelacionSAT.Name = "btnActualizarEstatusCancelacionSAT"
        Me.btnActualizarEstatusCancelacionSAT.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarEstatusCancelacionSAT.TabIndex = 108
        Me.btnActualizarEstatusCancelacionSAT.UseVisualStyleBackColor = True
        '
        'pnlReintentarCancelacionSAT
        '
        Me.pnlReintentarCancelacionSAT.Controls.Add(Me.btnReintentarCancelacion)
        Me.pnlReintentarCancelacionSAT.Controls.Add(Me.lblTextoReintentarCancelacion)
        Me.pnlReintentarCancelacionSAT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlReintentarCancelacionSAT.Location = New System.Drawing.Point(336, 0)
        Me.pnlReintentarCancelacionSAT.Name = "pnlReintentarCancelacionSAT"
        Me.pnlReintentarCancelacionSAT.Size = New System.Drawing.Size(86, 65)
        Me.pnlReintentarCancelacionSAT.TabIndex = 121
        '
        'btnReintentarCancelacion
        '
        Me.btnReintentarCancelacion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReintentarCancelacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReintentarCancelacion.Image = Global.Ventas.Vista.My.Resources.Resources.apagar_32
        Me.btnReintentarCancelacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReintentarCancelacion.Location = New System.Drawing.Point(26, 3)
        Me.btnReintentarCancelacion.Name = "btnReintentarCancelacion"
        Me.btnReintentarCancelacion.Size = New System.Drawing.Size(32, 32)
        Me.btnReintentarCancelacion.TabIndex = 114
        Me.btnReintentarCancelacion.UseVisualStyleBackColor = True
        '
        'lblTextoReintentarCancelacion
        '
        Me.lblTextoReintentarCancelacion.AutoSize = True
        Me.lblTextoReintentarCancelacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoReintentarCancelacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoReintentarCancelacion.Location = New System.Drawing.Point(7, 34)
        Me.lblTextoReintentarCancelacion.Name = "lblTextoReintentarCancelacion"
        Me.lblTextoReintentarCancelacion.Size = New System.Drawing.Size(73, 26)
        Me.lblTextoReintentarCancelacion.TabIndex = 115
        Me.lblTextoReintentarCancelacion.Text = "Reintentar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cancelar SAT"
        Me.lblTextoReintentarCancelacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlCancelar
        '
        Me.pnlCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlCancelar.Controls.Add(Me.lblTextoCancelar)
        Me.pnlCancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCancelar.Location = New System.Drawing.Point(275, 0)
        Me.pnlCancelar.Name = "pnlCancelar"
        Me.pnlCancelar.Size = New System.Drawing.Size(61, 65)
        Me.pnlCancelar.TabIndex = 120
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(14, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 108
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblTextoCancelar
        '
        Me.lblTextoCancelar.AutoSize = True
        Me.lblTextoCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoCancelar.Location = New System.Drawing.Point(6, 35)
        Me.lblTextoCancelar.Name = "lblTextoCancelar"
        Me.lblTextoCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblTextoCancelar.TabIndex = 109
        Me.lblTextoCancelar.Text = "Cancelar"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.lblTextoExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(214, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(61, 65)
        Me.pnlExportar.TabIndex = 119
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(15, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 113
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblTextoExportar
        '
        Me.lblTextoExportar.AutoSize = True
        Me.lblTextoExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportar.Location = New System.Drawing.Point(10, 35)
        Me.lblTextoExportar.Name = "lblTextoExportar"
        Me.lblTextoExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblTextoExportar.TabIndex = 112
        Me.lblTextoExportar.Text = "Exportar"
        '
        'pnlTimbrarDocumento
        '
        Me.pnlTimbrarDocumento.Controls.Add(Me.btnTimbrarDocumento)
        Me.pnlTimbrarDocumento.Controls.Add(Me.lblTimbrarDocumento)
        Me.pnlTimbrarDocumento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTimbrarDocumento.Location = New System.Drawing.Point(141, 0)
        Me.pnlTimbrarDocumento.Name = "pnlTimbrarDocumento"
        Me.pnlTimbrarDocumento.Size = New System.Drawing.Size(73, 65)
        Me.pnlTimbrarDocumento.TabIndex = 118
        '
        'btnTimbrarDocumento
        '
        Me.btnTimbrarDocumento.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnTimbrarDocumento.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnTimbrarDocumento.Image = Global.Ventas.Vista.My.Resources.Resources.nuevo_321
        Me.btnTimbrarDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTimbrarDocumento.Location = New System.Drawing.Point(20, 3)
        Me.btnTimbrarDocumento.Name = "btnTimbrarDocumento"
        Me.btnTimbrarDocumento.Size = New System.Drawing.Size(32, 32)
        Me.btnTimbrarDocumento.TabIndex = 111
        Me.btnTimbrarDocumento.UseVisualStyleBackColor = True
        '
        'lblTimbrarDocumento
        '
        Me.lblTimbrarDocumento.AutoSize = True
        Me.lblTimbrarDocumento.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTimbrarDocumento.Location = New System.Drawing.Point(5, 34)
        Me.lblTimbrarDocumento.Name = "lblTimbrarDocumento"
        Me.lblTimbrarDocumento.Size = New System.Drawing.Size(62, 26)
        Me.lblTimbrarDocumento.TabIndex = 110
        Me.lblTimbrarDocumento.Text = "Timbrar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento"
        Me.lblTimbrarDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlImprimirPDF
        '
        Me.pnlImprimirPDF.Controls.Add(Me.btnImprimirPDF)
        Me.pnlImprimirPDF.Controls.Add(Me.lblTextoImprimirPDF)
        Me.pnlImprimirPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimirPDF.Location = New System.Drawing.Point(68, 0)
        Me.pnlImprimirPDF.Name = "pnlImprimirPDF"
        Me.pnlImprimirPDF.Size = New System.Drawing.Size(73, 65)
        Me.pnlImprimirPDF.TabIndex = 117
        '
        'btnImprimirPDF
        '
        Me.btnImprimirPDF.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirPDF.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirPDF.Location = New System.Drawing.Point(22, 3)
        Me.btnImprimirPDF.Name = "btnImprimirPDF"
        Me.btnImprimirPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirPDF.TabIndex = 106
        Me.btnImprimirPDF.UseVisualStyleBackColor = True
        '
        'lblTextoImprimirPDF
        '
        Me.lblTextoImprimirPDF.AutoSize = True
        Me.lblTextoImprimirPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoImprimirPDF.Location = New System.Drawing.Point(5, 35)
        Me.lblTextoImprimirPDF.Name = "lblTextoImprimirPDF"
        Me.lblTextoImprimirPDF.Size = New System.Drawing.Size(66, 13)
        Me.lblTextoImprimirPDF.TabIndex = 75
        Me.lblTextoImprimirPDF.Text = "Imprimir PDF"
        '
        'pnlVerDetalles
        '
        Me.pnlVerDetalles.Controls.Add(Me.btnVerDetalles)
        Me.pnlVerDetalles.Controls.Add(Me.lblTextoVerDetalles)
        Me.pnlVerDetalles.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerDetalles.Location = New System.Drawing.Point(0, 0)
        Me.pnlVerDetalles.Name = "pnlVerDetalles"
        Me.pnlVerDetalles.Size = New System.Drawing.Size(68, 65)
        Me.pnlVerDetalles.TabIndex = 116
        '
        'btnVerDetalles
        '
        Me.btnVerDetalles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerDetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerDetalles.Location = New System.Drawing.Point(19, 3)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalles.TabIndex = 105
        Me.btnVerDetalles.UseVisualStyleBackColor = True
        '
        'lblTextoVerDetalles
        '
        Me.lblTextoVerDetalles.AutoSize = True
        Me.lblTextoVerDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoVerDetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoVerDetalles.Location = New System.Drawing.Point(5, 35)
        Me.lblTextoVerDetalles.Name = "lblTextoVerDetalles"
        Me.lblTextoVerDetalles.Size = New System.Drawing.Size(62, 13)
        Me.lblTextoVerDetalles.TabIndex = 83
        Me.lblTextoVerDetalles.Text = "Ver detalles"
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(939, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1252, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(916, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(336, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(29, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(236, 18)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Documentos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(253, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Cita
        '
        Me.Cita.Caption = "Cita"
        Me.Cita.FieldName = "Cita"
        Me.Cita.Name = "Cita"
        Me.Cita.OptionsColumn.AllowEdit = False
        Me.Cita.Visible = True
        Me.Cita.VisibleIndex = 18
        Me.Cita.Width = 50
        '
        'FechaCaptura
        '
        Me.FechaCaptura.Caption = "Fecha Captura"
        Me.FechaCaptura.FieldName = "FechaCaptura"
        Me.FechaCaptura.Name = "FechaCaptura"
        Me.FechaCaptura.OptionsColumn.AllowEdit = False
        Me.FechaCaptura.Visible = True
        Me.FechaCaptura.VisibleIndex = 17
        Me.FechaCaptura.Width = 120
        '
        'UsuarioCaptura
        '
        Me.UsuarioCaptura.Caption = "Usuario Captura"
        Me.UsuarioCaptura.FieldName = "UsuarioCaptura"
        Me.UsuarioCaptura.Name = "UsuarioCaptura"
        Me.UsuarioCaptura.OptionsColumn.AllowEdit = False
        Me.UsuarioCaptura.Visible = True
        Me.UsuarioCaptura.VisibleIndex = 16
        Me.UsuarioCaptura.Width = 90
        '
        'Cancelados
        '
        Me.Cancelados.Caption = "Cancelados"
        Me.Cancelados.FieldName = "Cancelados"
        Me.Cancelados.Name = "Cancelados"
        Me.Cancelados.OptionsColumn.AllowEdit = False
        Me.Cancelados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.Cancelados.Visible = True
        Me.Cancelados.VisibleIndex = 15
        Me.Cancelados.Width = 80
        '
        'PorConfirmar
        '
        Me.PorConfirmar.Caption = "Por Confirmar"
        Me.PorConfirmar.FieldName = "PorConfirmar"
        Me.PorConfirmar.Name = "PorConfirmar"
        Me.PorConfirmar.OptionsColumn.AllowEdit = False
        Me.PorConfirmar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.PorConfirmar.Visible = True
        Me.PorConfirmar.VisibleIndex = 14
        Me.PorConfirmar.Width = 90
        '
        'Confirmados
        '
        Me.Confirmados.Caption = "Confirmados"
        Me.Confirmados.FieldName = "Confirmados"
        Me.Confirmados.Name = "Confirmados"
        Me.Confirmados.OptionsColumn.AllowEdit = False
        Me.Confirmados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.Confirmados.Visible = True
        Me.Confirmados.VisibleIndex = 13
        Me.Confirmados.Width = 80
        '
        'Cantidad
        '
        Me.Cantidad.Caption = "Cantidad"
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        Me.Cantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.Cantidad.Visible = True
        Me.Cantidad.VisibleIndex = 12
        Me.Cantidad.Width = 80
        '
        'FechaPreparacion
        '
        Me.FechaPreparacion.Caption = "Fecha Preparación"
        Me.FechaPreparacion.FieldName = "FechaPreparacion"
        Me.FechaPreparacion.Name = "FechaPreparacion"
        Me.FechaPreparacion.OptionsColumn.AllowEdit = False
        Me.FechaPreparacion.Visible = True
        Me.FechaPreparacion.VisibleIndex = 11
        Me.FechaPreparacion.Width = 120
        '
        'FechaEntregaProgramacion
        '
        Me.FechaEntregaProgramacion.Caption = "Fecha Entrega Programación"
        Me.FechaEntregaProgramacion.FieldName = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.Name = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.OptionsColumn.AllowEdit = False
        Me.FechaEntregaProgramacion.Visible = True
        Me.FechaEntregaProgramacion.VisibleIndex = 10
        Me.FechaEntregaProgramacion.Width = 120
        '
        'OrdenCliente
        '
        Me.OrdenCliente.Caption = "Orden Cliente"
        Me.OrdenCliente.FieldName = "OrdenCliente"
        Me.OrdenCliente.Name = "OrdenCliente"
        Me.OrdenCliente.OptionsColumn.AllowEdit = False
        Me.OrdenCliente.Visible = True
        Me.OrdenCliente.VisibleIndex = 9
        Me.OrdenCliente.Width = 90
        '
        'PedidoSICY
        '
        Me.PedidoSICY.Caption = "Pedido SICY"
        Me.PedidoSICY.FieldName = "PedidoSICY"
        Me.PedidoSICY.Name = "PedidoSICY"
        Me.PedidoSICY.OptionsColumn.AllowEdit = False
        Me.PedidoSICY.Visible = True
        Me.PedidoSICY.VisibleIndex = 8
        Me.PedidoSICY.Width = 80
        '
        'PedidoSAY
        '
        Me.PedidoSAY.Caption = "Pedido SAY"
        Me.PedidoSAY.FieldName = "PedidoSAY"
        Me.PedidoSAY.Name = "PedidoSAY"
        Me.PedidoSAY.OptionsColumn.AllowEdit = False
        Me.PedidoSAY.Visible = True
        Me.PedidoSAY.VisibleIndex = 7
        Me.PedidoSAY.Width = 80
        '
        'TipoOT
        '
        Me.TipoOT.Caption = "Tipo OT"
        Me.TipoOT.FieldName = "TipoOT"
        Me.TipoOT.Name = "TipoOT"
        Me.TipoOT.OptionsColumn.AllowEdit = False
        Me.TipoOT.Visible = True
        Me.TipoOT.VisibleIndex = 6
        Me.TipoOT.Width = 70
        '
        'STATUS
        '
        Me.STATUS.Caption = "STATUS"
        Me.STATUS.FieldName = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.OptionsColumn.AllowEdit = False
        Me.STATUS.Visible = True
        Me.STATUS.VisibleIndex = 5
        Me.STATUS.Width = 90
        '
        'Agente
        '
        Me.Agente.Caption = "Agente"
        Me.Agente.FieldName = "Agente"
        Me.Agente.Name = "Agente"
        Me.Agente.OptionsColumn.AllowEdit = False
        Me.Agente.Visible = True
        Me.Agente.VisibleIndex = 4
        Me.Agente.Width = 80
        '
        'Cliente
        '
        Me.Cliente.Caption = "Cliente"
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OptionsColumn.AllowEdit = False
        Me.Cliente.Visible = True
        Me.Cliente.VisibleIndex = 3
        Me.Cliente.Width = 220
        '
        'OTSICY
        '
        Me.OTSICY.Caption = "OTSICY"
        Me.OTSICY.FieldName = "OTSICY"
        Me.OTSICY.Name = "OTSICY"
        Me.OTSICY.OptionsColumn.AllowEdit = False
        Me.OTSICY.Visible = True
        Me.OTSICY.VisibleIndex = 2
        Me.OTSICY.Width = 70
        '
        'OT
        '
        Me.OT.Caption = "OT"
        Me.OT.FieldName = "OT"
        Me.OT.Name = "OT"
        Me.OT.OptionsColumn.AllowEdit = False
        Me.OT.Visible = True
        Me.OT.VisibleIndex = 1
        Me.OT.Width = 70
        '
        'Seleccionar
        '
        Me.Seleccionar.Caption = """"
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.VisibleIndex = 0
        Me.Seleccionar.Width = 35
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdDocumentos
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
        'UsuarioModifico
        '
        Me.UsuarioModifico.Caption = "Usuario Modifico"
        Me.UsuarioModifico.FieldName = "UsuarioModifico"
        Me.UsuarioModifico.Name = "UsuarioModifico"
        Me.UsuarioModifico.OptionsColumn.AllowEdit = False
        Me.UsuarioModifico.Visible = True
        Me.UsuarioModifico.VisibleIndex = 19
        Me.UsuarioModifico.Width = 90
        '
        'FechaModificacion
        '
        Me.FechaModificacion.Caption = "Fecha Modificación"
        Me.FechaModificacion.FieldName = "FechaModificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.OptionsColumn.AllowEdit = False
        Me.FechaModificacion.Visible = True
        Me.FechaModificacion.VisibleIndex = 20
        Me.FechaModificacion.Width = 120
        '
        'DiasFaltantes
        '
        Me.DiasFaltantes.Caption = "Dias Faltantes"
        Me.DiasFaltantes.FieldName = "DiasFaltantes"
        Me.DiasFaltantes.Name = "DiasFaltantes"
        Me.DiasFaltantes.OptionsColumn.AllowEdit = False
        Me.DiasFaltantes.Visible = True
        Me.DiasFaltantes.VisibleIndex = 21
        Me.DiasFaltantes.Width = 90
        '
        'BE
        '
        Me.BE.Caption = "BE"
        Me.BE.FieldName = "BE"
        Me.BE.Name = "BE"
        Me.BE.OptionsColumn.AllowEdit = False
        Me.BE.Visible = True
        Me.BE.VisibleIndex = 22
        Me.BE.Width = 50
        '
        'MotivoCancelacion
        '
        Me.MotivoCancelacion.Caption = "Motivo Cancelación"
        Me.MotivoCancelacion.FieldName = "MotivoCancelacion"
        Me.MotivoCancelacion.Name = "MotivoCancelacion"
        Me.MotivoCancelacion.OptionsColumn.AllowEdit = False
        Me.MotivoCancelacion.Visible = True
        Me.MotivoCancelacion.VisibleIndex = 23
        Me.MotivoCancelacion.Width = 100
        '
        'EstatusID
        '
        Me.EstatusID.Caption = "EstatusID"
        Me.EstatusID.FieldName = "EstatusID"
        Me.EstatusID.Name = "EstatusID"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ClaveCitaEntrega"
        Me.GridColumn2.FieldName = "ClaveCitaEntrega"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 24
        '
        'Observaciones
        '
        Me.Observaciones.Caption = "GridColumn3"
        Me.Observaciones.FieldName = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Visible = True
        Me.Observaciones.VisibleIndex = 25
        '
        'FechaCitaEntrega
        '
        Me.FechaCitaEntrega.Caption = "FechaCitaEntrega"
        Me.FechaCitaEntrega.FieldName = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Name = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Visible = True
        Me.FechaCitaEntrega.VisibleIndex = 26
        '
        'HoraCita
        '
        Me.HoraCita.Caption = "HoraCita"
        Me.HoraCita.FieldName = "HoraCita"
        Me.HoraCita.Name = "HoraCita"
        Me.HoraCita.Visible = True
        Me.HoraCita.VisibleIndex = 27
        '
        'grdDocumentos
        '
        Me.grdDocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdDocumentos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDocumentos.Location = New System.Drawing.Point(0, 0)
        Me.grdDocumentos.MainView = Me.bgvDocumentos
        Me.grdDocumentos.Name = "grdDocumentos"
        Me.grdDocumentos.Size = New System.Drawing.Size(1252, 208)
        Me.grdDocumentos.TabIndex = 1
        Me.grdDocumentos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDocumentos, Me.grdDetallesOT, Me.GridView1})
        '
        'bgvDocumentos
        '
        Me.bgvDocumentos.GridControl = Me.grdDocumentos
        Me.bgvDocumentos.Name = "bgvDocumentos"
        Me.bgvDocumentos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDocumentos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDocumentos.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvDocumentos.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvDocumentos.OptionsSelection.MultiSelect = True
        Me.bgvDocumentos.OptionsView.ColumnAutoWidth = False
        Me.bgvDocumentos.OptionsView.ShowAutoFilterRow = True
        Me.bgvDocumentos.OptionsView.ShowFooter = True
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdDocumentos
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnPBar)
        Me.Panel3.Controls.Add(Me.grdDocumentos)
        Me.Panel3.Controls.Add(Me.grdReporte)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 280)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1252, 208)
        Me.Panel3.TabIndex = 27
        '
        'pnPBar
        '
        Me.pnPBar.BackColor = System.Drawing.SystemColors.Control
        Me.pnPBar.Controls.Add(Me.lblInfo)
        Me.pnPBar.Location = New System.Drawing.Point(12, 6)
        Me.pnPBar.Name = "pnPBar"
        Me.pnPBar.Size = New System.Drawing.Size(602, 91)
        Me.pnPBar.TabIndex = 109
        Me.pnPBar.Visible = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(16, 15)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(43, 16)
        Me.lblInfo.TabIndex = 108
        Me.lblInfo.Text = "lblInfo"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdReporte.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.vwReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(1252, 208)
        Me.grdReporte.TabIndex = 2
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte, Me.GridView3, Me.GridView4})
        Me.grdReporte.Visible = False
        '
        'vwReporte
        '
        Me.vwReporte.GridControl = Me.grdReporte
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.vwReporte.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporte.OptionsSelection.MultiSelect = True
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowFooter = True
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdReporte
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView3.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView4.GridControl = Me.grdReporte
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView4.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = """"
        Me.GridColumn1.FieldName = "Seleccionar"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 35
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "OT"
        Me.GridColumn3.FieldName = "OT"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 70
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "OTSICY"
        Me.GridColumn4.FieldName = "OTSICY"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Cliente"
        Me.GridColumn5.FieldName = "Cliente"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 220
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Agente"
        Me.GridColumn6.FieldName = "Agente"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "STATUS"
        Me.GridColumn7.FieldName = "STATUS"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 90
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tipo OT"
        Me.GridColumn8.FieldName = "TipoOT"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 70
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Pedido SAY"
        Me.GridColumn9.FieldName = "PedidoSAY"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 80
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Pedido SICY"
        Me.GridColumn10.FieldName = "PedidoSICY"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 80
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Orden Cliente"
        Me.GridColumn11.FieldName = "OrdenCliente"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Fecha Entrega Programación"
        Me.GridColumn12.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 120
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Fecha Preparación"
        Me.GridColumn13.FieldName = "FechaPreparacion"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 120
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Cantidad"
        Me.GridColumn14.FieldName = "Cantidad"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 80
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Confirmados"
        Me.GridColumn15.FieldName = "Confirmados"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 13
        Me.GridColumn15.Width = 80
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Por Confirmar"
        Me.GridColumn16.FieldName = "PorConfirmar"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 14
        Me.GridColumn16.Width = 90
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Cancelados"
        Me.GridColumn17.FieldName = "Cancelados"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 15
        Me.GridColumn17.Width = 80
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Usuario Captura"
        Me.GridColumn18.FieldName = "UsuarioCaptura"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 16
        Me.GridColumn18.Width = 90
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Fecha Captura"
        Me.GridColumn19.FieldName = "FechaCaptura"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 17
        Me.GridColumn19.Width = 120
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Cita"
        Me.GridColumn20.FieldName = "Cita"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 18
        Me.GridColumn20.Width = 50
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Usuario Modifico"
        Me.GridColumn21.FieldName = "UsuarioModifico"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 19
        Me.GridColumn21.Width = 90
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Fecha Modificación"
        Me.GridColumn22.FieldName = "FechaModificacion"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 20
        Me.GridColumn22.Width = 120
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Dias Faltantes"
        Me.GridColumn23.FieldName = "DiasFaltantes"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 21
        Me.GridColumn23.Width = 90
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "BE"
        Me.GridColumn24.FieldName = "BE"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 22
        Me.GridColumn24.Width = 50
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Motivo Cancelación"
        Me.GridColumn25.FieldName = "MotivoCancelacion"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 23
        Me.GridColumn25.Width = 100
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "EstatusID"
        Me.GridColumn26.FieldName = "EstatusID"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "ClaveCitaEntrega"
        Me.GridColumn27.FieldName = "ClaveCitaEntrega"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 24
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn3"
        Me.GridColumn28.FieldName = "Observaciones"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 25
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "FechaCitaEntrega"
        Me.GridColumn29.FieldName = "FechaCitaEntrega"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 26
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "HoraCita"
        Me.GridColumn30.FieldName = "HoraCita"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1252, 548)
        Me.Panel1.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.pnlColorFA)
        Me.pnlPie.Controls.Add(Me.lblInfoSNC)
        Me.pnlPie.Controls.Add(Me.lblInfoRNC)
        Me.pnlPie.Controls.Add(Me.lblEstatusCancelacion)
        Me.pnlPie.Controls.Add(Me.lblCanceladaEsperaAceptacion)
        Me.pnlPie.Controls.Add(Me.pnlEstatusCancelacion)
        Me.pnlPie.Controls.Add(Me.pnlCanceladaEsperaAceptacion)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlCorreoNoEnviado)
        Me.pnlPie.Controls.Add(Me.lblDiseñoCanceladoFaltaSAT)
        Me.pnlPie.Controls.Add(Me.Label10)
        Me.pnlPie.Controls.Add(Me.pnlCanceladoFaltaSAT)
        Me.pnlPie.Controls.Add(Me.pnlStatusNoTimbrado)
        Me.pnlPie.Controls.Add(Me.lblDiseñoCancelado)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 488)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1252, 60)
        Me.pnlPie.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(938, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 39)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "CLICK EN EL BOTÓN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """Mostrar"" PARA DESPLEGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LA INFORMACIÓN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(621, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 13)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "FA - Facturación Anticipada"
        '
        'pnlColorFA
        '
        Me.pnlColorFA.BackColor = System.Drawing.Color.ForestGreen
        Me.pnlColorFA.ForeColor = System.Drawing.Color.Black
        Me.pnlColorFA.Location = New System.Drawing.Point(607, 12)
        Me.pnlColorFA.Name = "pnlColorFA"
        Me.pnlColorFA.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorFA.TabIndex = 145
        '
        'lblInfoSNC
        '
        Me.lblInfoSNC.AutoSize = True
        Me.lblInfoSNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoSNC.Location = New System.Drawing.Point(772, 30)
        Me.lblInfoSNC.Name = "lblInfoSNC"
        Me.lblInfoSNC.Size = New System.Drawing.Size(149, 12)
        Me.lblInfoSNC.TabIndex = 144
        Me.lblInfoSNC.Text = "SNC - Saldado con notas de crédito"
        '
        'lblInfoRNC
        '
        Me.lblInfoRNC.AutoSize = True
        Me.lblInfoRNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoRNC.Location = New System.Drawing.Point(772, 16)
        Me.lblInfoRNC.Name = "lblInfoRNC"
        Me.lblInfoRNC.Size = New System.Drawing.Size(167, 12)
        Me.lblInfoRNC.TabIndex = 143
        Me.lblInfoRNC.Text = "RNC - Se refactura con notas de crédito"
        '
        'lblEstatusCancelacion
        '
        Me.lblEstatusCancelacion.AutoSize = True
        Me.lblEstatusCancelacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEstatusCancelacion.Location = New System.Drawing.Point(424, 36)
        Me.lblEstatusCancelacion.Name = "lblEstatusCancelacion"
        Me.lblEstatusCancelacion.Size = New System.Drawing.Size(190, 13)
        Me.lblEstatusCancelacion.TabIndex = 142
        Me.lblEstatusCancelacion.Text = "Cancelación rechazada por el receptor"
        '
        'lblCanceladaEsperaAceptacion
        '
        Me.lblCanceladaEsperaAceptacion.AutoSize = True
        Me.lblCanceladaEsperaAceptacion.ForeColor = System.Drawing.Color.Red
        Me.lblCanceladaEsperaAceptacion.Location = New System.Drawing.Point(424, 12)
        Me.lblCanceladaEsperaAceptacion.Name = "lblCanceladaEsperaAceptacion"
        Me.lblCanceladaEsperaAceptacion.Size = New System.Drawing.Size(156, 13)
        Me.lblCanceladaEsperaAceptacion.TabIndex = 140
        Me.lblCanceladaEsperaAceptacion.Text = "Cancelada (Espera aceptación)"
        '
        'pnlEstatusCancelacion
        '
        Me.pnlEstatusCancelacion.BackColor = System.Drawing.Color.Gray
        Me.pnlEstatusCancelacion.ForeColor = System.Drawing.Color.Black
        Me.pnlEstatusCancelacion.Location = New System.Drawing.Point(410, 36)
        Me.pnlEstatusCancelacion.Name = "pnlEstatusCancelacion"
        Me.pnlEstatusCancelacion.Size = New System.Drawing.Size(12, 13)
        Me.pnlEstatusCancelacion.TabIndex = 141
        '
        'pnlCanceladaEsperaAceptacion
        '
        Me.pnlCanceladaEsperaAceptacion.BackColor = System.Drawing.Color.Coral
        Me.pnlCanceladaEsperaAceptacion.ForeColor = System.Drawing.Color.Black
        Me.pnlCanceladaEsperaAceptacion.Location = New System.Drawing.Point(410, 12)
        Me.pnlCanceladaEsperaAceptacion.Name = "pnlCanceladaEsperaAceptacion"
        Me.pnlCanceladaEsperaAceptacion.Size = New System.Drawing.Size(12, 13)
        Me.pnlCanceladaEsperaAceptacion.TabIndex = 139
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(109, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Correo no enviado (*Facturas)"
        '
        'pnlCorreoNoEnviado
        '
        Me.pnlCorreoNoEnviado.BackColor = System.Drawing.Color.MediumPurple
        Me.pnlCorreoNoEnviado.ForeColor = System.Drawing.Color.Black
        Me.pnlCorreoNoEnviado.Location = New System.Drawing.Point(91, 36)
        Me.pnlCorreoNoEnviado.Name = "pnlCorreoNoEnviado"
        Me.pnlCorreoNoEnviado.Size = New System.Drawing.Size(12, 13)
        Me.pnlCorreoNoEnviado.TabIndex = 138
        '
        'lblDiseñoCanceladoFaltaSAT
        '
        Me.lblDiseñoCanceladoFaltaSAT.AutoSize = True
        Me.lblDiseñoCanceladoFaltaSAT.ForeColor = System.Drawing.Color.Red
        Me.lblDiseñoCanceladoFaltaSAT.Location = New System.Drawing.Point(285, 14)
        Me.lblDiseñoCanceladoFaltaSAT.Name = "lblDiseñoCanceladoFaltaSAT"
        Me.lblDiseñoCanceladoFaltaSAT.Size = New System.Drawing.Size(114, 13)
        Me.lblDiseñoCanceladoFaltaSAT.TabIndex = 135
        Me.lblDiseñoCanceladoFaltaSAT.Text = "Cancelado (Falta SAT)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(109, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 13)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "No timbrado (Regenerar XML)"
        '
        'pnlCanceladoFaltaSAT
        '
        Me.pnlCanceladoFaltaSAT.BackColor = System.Drawing.Color.Yellow
        Me.pnlCanceladoFaltaSAT.ForeColor = System.Drawing.Color.Black
        Me.pnlCanceladoFaltaSAT.Location = New System.Drawing.Point(271, 12)
        Me.pnlCanceladoFaltaSAT.Name = "pnlCanceladoFaltaSAT"
        Me.pnlCanceladoFaltaSAT.Size = New System.Drawing.Size(12, 13)
        Me.pnlCanceladoFaltaSAT.TabIndex = 136
        '
        'pnlStatusNoTimbrado
        '
        Me.pnlStatusNoTimbrado.BackColor = System.Drawing.Color.Red
        Me.pnlStatusNoTimbrado.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusNoTimbrado.Location = New System.Drawing.Point(91, 12)
        Me.pnlStatusNoTimbrado.Name = "pnlStatusNoTimbrado"
        Me.pnlStatusNoTimbrado.Size = New System.Drawing.Size(12, 13)
        Me.pnlStatusNoTimbrado.TabIndex = 136
        '
        'lblDiseñoCancelado
        '
        Me.lblDiseñoCancelado.AutoSize = True
        Me.lblDiseñoCancelado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiseñoCancelado.ForeColor = System.Drawing.Color.Red
        Me.lblDiseñoCancelado.Location = New System.Drawing.Point(285, 36)
        Me.lblDiseñoCancelado.Name = "lblDiseñoCancelado"
        Me.lblDiseñoCancelado.Size = New System.Drawing.Size(120, 13)
        Me.lblDiseñoCancelado.TabIndex = 134
        Me.lblDiseñoCancelado.Text = "Cancelado (SAY y SAT)"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(10, 10)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 118
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(10, 31)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 117
        Me.lblTotalRegistros.Text = "3"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Label11)
        Me.pnlParametros.Controls.Add(Me.chkMostrarOT)
        Me.pnlParametros.Controls.Add(Me.GroupBox4)
        Me.pnlParametros.Controls.Add(Me.cmbCEDIS)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.gboxCliente)
        Me.pnlParametros.Controls.Add(Me.gboxFolioFactura)
        Me.pnlParametros.Controls.Add(Me.gboxFolioDocto)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1252, 215)
        Me.pnlParametros.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "CEDIS"
        '
        'chkMostrarOT
        '
        Me.chkMostrarOT.AutoSize = True
        Me.chkMostrarOT.Location = New System.Drawing.Point(246, 32)
        Me.chkMostrarOT.Name = "chkMostrarOT"
        Me.chkMostrarOT.Size = New System.Drawing.Size(79, 17)
        Me.chkMostrarOT.TabIndex = 136
        Me.chkMostrarOT.Text = "Mostrar OT"
        Me.chkMostrarOT.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnLimpiarFiltroStatus)
        Me.GroupBox4.Controls.Add(Me.btnAgregarFiltroStatus)
        Me.GroupBox4.Controls.Add(Me.Panel8)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 118)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(217, 90)
        Me.GroupBox4.TabIndex = 135
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status"
        '
        'btnLimpiarFiltroStatus
        '
        Me.btnLimpiarFiltroStatus.Image = CType(resources.GetObject("btnLimpiarFiltroStatus.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroStatus.Location = New System.Drawing.Point(166, 10)
        Me.btnLimpiarFiltroStatus.Name = "btnLimpiarFiltroStatus"
        Me.btnLimpiarFiltroStatus.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroStatus.TabIndex = 6
        Me.btnLimpiarFiltroStatus.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroStatus
        '
        Me.btnAgregarFiltroStatus.Image = CType(resources.GetObject("btnAgregarFiltroStatus.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroStatus.Location = New System.Drawing.Point(192, 10)
        Me.btnAgregarFiltroStatus.Name = "btnAgregarFiltroStatus"
        Me.btnAgregarFiltroStatus.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroStatus.TabIndex = 4
        Me.btnAgregarFiltroStatus.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdStatus)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 35)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(211, 52)
        Me.Panel8.TabIndex = 2
        '
        'grdStatus
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStatus.DisplayLayout.Appearance = Appearance1
        Me.grdStatus.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdStatus.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdStatus.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdStatus.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdStatus.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdStatus.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdStatus.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdStatus.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStatus.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdStatus.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdStatus.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStatus.Location = New System.Drawing.Point(0, 0)
        Me.grdStatus.Name = "grdStatus"
        Me.grdStatus.Size = New System.Drawing.Size(211, 52)
        Me.grdStatus.TabIndex = 4
        '
        'cmbCEDIS
        '
        Me.cmbCEDIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEDIS.FormattingEnabled = True
        Me.cmbCEDIS.Location = New System.Drawing.Point(57, 28)
        Me.cmbCEDIS.Name = "cmbCEDIS"
        Me.cmbCEDIS.Size = New System.Drawing.Size(175, 21)
        Me.cmbCEDIS.TabIndex = 143
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAgregarFiltroEmisor)
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroEmisor)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Location = New System.Drawing.Point(750, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(244, 151)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Emisor"
        '
        'btnAgregarFiltroEmisor
        '
        Me.btnAgregarFiltroEmisor.Image = CType(resources.GetObject("btnAgregarFiltroEmisor.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroEmisor.Location = New System.Drawing.Point(217, 12)
        Me.btnAgregarFiltroEmisor.Name = "btnAgregarFiltroEmisor"
        Me.btnAgregarFiltroEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroEmisor.TabIndex = 8
        Me.btnAgregarFiltroEmisor.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltroEmisor
        '
        Me.btnLimpiarFiltroEmisor.Image = CType(resources.GetObject("btnLimpiarFiltroEmisor.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroEmisor.Location = New System.Drawing.Point(189, 12)
        Me.btnLimpiarFiltroEmisor.Name = "btnLimpiarFiltroEmisor"
        Me.btnLimpiarFiltroEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroEmisor.TabIndex = 7
        Me.btnLimpiarFiltroEmisor.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdEmisor)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 50)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(238, 98)
        Me.Panel4.TabIndex = 2
        '
        'grdEmisor
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEmisor.DisplayLayout.Appearance = Appearance3
        Me.grdEmisor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdEmisor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEmisor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEmisor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEmisor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEmisor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdEmisor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEmisor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEmisor.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdEmisor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdEmisor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEmisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEmisor.Location = New System.Drawing.Point(0, 0)
        Me.grdEmisor.Name = "grdEmisor"
        Me.grdEmisor.Size = New System.Drawing.Size(238, 98)
        Me.grdEmisor.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoFechaFacturacion)
        Me.GroupBox3.Controls.Add(Me.rdoFechaCancelacion)
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(217, 68)
        Me.GroupBox3.TabIndex = 129
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        '
        'rdoFechaFacturacion
        '
        Me.rdoFechaFacturacion.AutoSize = True
        Me.rdoFechaFacturacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoFechaFacturacion.Checked = True
        Me.rdoFechaFacturacion.Location = New System.Drawing.Point(14, 20)
        Me.rdoFechaFacturacion.Name = "rdoFechaFacturacion"
        Me.rdoFechaFacturacion.Size = New System.Drawing.Size(81, 17)
        Me.rdoFechaFacturacion.TabIndex = 92
        Me.rdoFechaFacturacion.TabStop = True
        Me.rdoFechaFacturacion.Text = "Facturación"
        Me.rdoFechaFacturacion.UseVisualStyleBackColor = False
        '
        'rdoFechaCancelacion
        '
        Me.rdoFechaCancelacion.AutoSize = True
        Me.rdoFechaCancelacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoFechaCancelacion.Location = New System.Drawing.Point(14, 37)
        Me.rdoFechaCancelacion.Name = "rdoFechaCancelacion"
        Me.rdoFechaCancelacion.Size = New System.Drawing.Size(84, 17)
        Me.rdoFechaCancelacion.TabIndex = 92
        Me.rdoFechaCancelacion.Text = "Cancelación"
        Me.rdoFechaCancelacion.UseVisualStyleBackColor = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(128, 16)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaInicio.TabIndex = 66
        Me.dtpFechaInicio.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(106, 21)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(128, 41)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaFin.TabIndex = 69
        Me.dtpFechaFin.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(106, 43)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.txtFiltroFolioOT)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 151)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Folio OT"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFolioOT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(77, 98)
        Me.Panel2.TabIndex = 2
        '
        'grdFolioOT
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioOT.DisplayLayout.Appearance = Appearance5
        Me.grdFolioOT.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFolioOT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFolioOT.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFolioOT.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFolioOT.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFolioOT.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFolioOT.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFolioOT.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioOT.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdFolioOT.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFolioOT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFolioOT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolioOT.Location = New System.Drawing.Point(0, 0)
        Me.grdFolioOT.Name = "grdFolioOT"
        Me.grdFolioOT.Size = New System.Drawing.Size(77, 98)
        Me.grdFolioOT.TabIndex = 1
        '
        'txtFiltroFolioOT
        '
        Me.txtFiltroFolioOT.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroFolioOT.Mask = "99999999999999999"
        Me.txtFiltroFolioOT.Name = "txtFiltroFolioOT"
        Me.txtFiltroFolioOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFiltroFolioOT.Size = New System.Drawing.Size(71, 20)
        Me.txtFiltroFolioOT.TabIndex = 0
        Me.txtFiltroFolioOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxCliente
        '
        Me.gboxCliente.Controls.Add(Me.btnAgregarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.Panel7)
        Me.gboxCliente.Location = New System.Drawing.Point(500, 54)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(244, 151)
        Me.gboxCliente.TabIndex = 67
        Me.gboxCliente.TabStop = False
        Me.gboxCliente.Text = "Cliente"
        '
        'btnAgregarFiltroCliente
        '
        Me.btnAgregarFiltroCliente.Image = CType(resources.GetObject("btnAgregarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroCliente.Location = New System.Drawing.Point(215, 12)
        Me.btnAgregarFiltroCliente.Name = "btnAgregarFiltroCliente"
        Me.btnAgregarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroCliente.TabIndex = 6
        Me.btnAgregarFiltroCliente.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(187, 12)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 5
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 50)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(238, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdCliente
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance7
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(238, 98)
        Me.grdCliente.TabIndex = 2
        '
        'gboxFolioFactura
        '
        Me.gboxFolioFactura.Controls.Add(Me.txtFiltroFactura)
        Me.gboxFolioFactura.Controls.Add(Me.Panel25)
        Me.gboxFolioFactura.Location = New System.Drawing.Point(325, 54)
        Me.gboxFolioFactura.Name = "gboxFolioFactura"
        Me.gboxFolioFactura.Size = New System.Drawing.Size(83, 151)
        Me.gboxFolioFactura.TabIndex = 55
        Me.gboxFolioFactura.TabStop = False
        Me.gboxFolioFactura.Text = "Factura"
        '
        'txtFiltroFactura
        '
        Me.txtFiltroFactura.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroFactura.MaxLength = 50
        Me.txtFiltroFactura.Name = "txtFiltroFactura"
        Me.txtFiltroFactura.Size = New System.Drawing.Size(71, 20)
        Me.txtFiltroFactura.TabIndex = 3
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.grdFactura)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(3, 50)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(77, 98)
        Me.Panel25.TabIndex = 2
        '
        'grdFactura
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFactura.DisplayLayout.Appearance = Appearance9
        Me.grdFactura.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFactura.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFactura.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFactura.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFactura.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFactura.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFactura.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFactura.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFactura.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdFactura.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFactura.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFactura.Location = New System.Drawing.Point(0, 0)
        Me.grdFactura.Name = "grdFactura"
        Me.grdFactura.Size = New System.Drawing.Size(77, 98)
        Me.grdFactura.TabIndex = 1
        '
        'gboxFolioDocto
        '
        Me.gboxFolioDocto.Controls.Add(Me.Panel5)
        Me.gboxFolioDocto.Controls.Add(Me.txtFiltroDocumento)
        Me.gboxFolioDocto.Location = New System.Drawing.Point(243, 54)
        Me.gboxFolioDocto.Name = "gboxFolioDocto"
        Me.gboxFolioDocto.Size = New System.Drawing.Size(79, 151)
        Me.gboxFolioDocto.TabIndex = 54
        Me.gboxFolioDocto.TabStop = False
        Me.gboxFolioDocto.Text = "Documento"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdFiltroDocumento)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 50)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(73, 98)
        Me.Panel5.TabIndex = 2
        '
        'grdFiltroDocumento
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroDocumento.DisplayLayout.Appearance = Appearance11
        Me.grdFiltroDocumento.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroDocumento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroDocumento.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroDocumento.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroDocumento.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroDocumento.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroDocumento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroDocumento.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroDocumento.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Me.grdFiltroDocumento.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroDocumento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroDocumento.Location = New System.Drawing.Point(0, -13)
        Me.grdFiltroDocumento.Name = "grdFiltroDocumento"
        Me.grdFiltroDocumento.Size = New System.Drawing.Size(73, 111)
        Me.grdFiltroDocumento.TabIndex = 1
        '
        'txtFiltroDocumento
        '
        Me.txtFiltroDocumento.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroDocumento.Mask = "99999999999999999"
        Me.txtFiltroDocumento.Name = "txtFiltroDocumento"
        Me.txtFiltroDocumento.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFiltroDocumento.Size = New System.Drawing.Size(64, 20)
        Me.txtFiltroDocumento.TabIndex = 0
        Me.txtFiltroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1252, 27)
        Me.Panel6.TabIndex = 46
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(15, 6)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 57
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1192, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1218, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'cmsTipoImpresion
        '
        Me.cmsTipoImpresion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiRegenerarPDF, Me.tsmiReimprimirPDF})
        Me.cmsTipoImpresion.Name = "cmsOpcionesAlmacen"
        Me.cmsTipoImpresion.Size = New System.Drawing.Size(134, 48)
        '
        'tsmiRegenerarPDF
        '
        Me.tsmiRegenerarPDF.Name = "tsmiRegenerarPDF"
        Me.tsmiRegenerarPDF.Size = New System.Drawing.Size(133, 22)
        Me.tsmiRegenerarPDF.Text = "Regenerar"
        '
        'tsmiReimprimirPDF
        '
        Me.tsmiReimprimirPDF.Name = "tsmiReimprimirPDF"
        Me.tsmiReimprimirPDF.Size = New System.Drawing.Size(133, 22)
        Me.tsmiReimprimirPDF.Text = "Reimprimir"
        '
        'cmsVerOTs
        '
        Me.cmsVerOTs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmVerOts})
        Me.cmsVerOTs.Name = "cmsOpcionesAlmacen"
        Me.cmsVerOTs.Size = New System.Drawing.Size(112, 26)
        '
        'tsmVerOts
        '
        Me.tsmVerOts.Name = "tsmVerOts"
        Me.tsmVerOts.Size = New System.Drawing.Size(111, 22)
        Me.tsmVerOts.Text = "Ver OTs"
        '
        'AdministradorFacturacion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministradorFacturacion_Form"
        Me.Text = "Administrador de Documentos"
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlGenerarXMLSap.ResumeLayout(False)
        Me.pnlGenerarXMLSap.PerformLayout()
        Me.pnlSolicitudCancelacion.ResumeLayout(False)
        Me.pnlSolicitudCancelacion.PerformLayout()
        Me.pnlRefacturar.ResumeLayout(False)
        Me.pnlRefacturar.PerformLayout()
        Me.pnlAnexarArchivos.ResumeLayout(False)
        Me.pnlAnexarArchivos.PerformLayout()
        Me.pnl.ResumeLayout(False)
        Me.pnl.PerformLayout()
        Me.PnlGenerarAddenda.ResumeLayout(False)
        Me.PnlGenerarAddenda.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlEnvioCorreo.ResumeLayout(False)
        Me.pnlEnvioCorreo.PerformLayout()
        Me.pnlReintentarCancelacionSAT.ResumeLayout(False)
        Me.pnlReintentarCancelacionSAT.PerformLayout()
        Me.pnlCancelar.ResumeLayout(False)
        Me.pnlCancelar.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTimbrarDocumento.ResumeLayout(False)
        Me.pnlTimbrarDocumento.PerformLayout()
        Me.pnlImprimirPDF.ResumeLayout(False)
        Me.pnlImprimirPDF.PerformLayout()
        Me.pnlVerDetalles.ResumeLayout(False)
        Me.pnlVerDetalles.PerformLayout()
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.pnPBar.ResumeLayout(False)
        Me.pnPBar.PerformLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdEmisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFolioOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCliente.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFolioFactura.ResumeLayout(False)
        Me.gboxFolioFactura.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFolioDocto.ResumeLayout(False)
        Me.gboxFolioDocto.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdFiltroDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.cmsTipoImpresion.ResumeLayout(False)
        Me.cmsVerOTs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Cita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cancelados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PorConfirmar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Confirmados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPreparacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaEntregaProgramacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrdenCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoOT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Agente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OTSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UsuarioModifico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaModificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiasFaltantes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MotivoCancelacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EstatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Observaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCitaEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdDocumentos As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDocumentos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As System.Windows.Forms.Label
    Friend WithEvents lblDiseñoCancelado As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusNoTimbrado As System.Windows.Forms.Panel
    Friend WithEvents cmsTipoImpresion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiRegenerarPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReimprimirPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsVerOTs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmVerOts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDiseñoCanceladoFaltaSAT As System.Windows.Forms.Label
    Friend WithEvents pnlCanceladoFaltaSAT As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlCorreoNoEnviado As System.Windows.Forms.Panel
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblCanceladaEsperaAceptacion As Label
    Friend WithEvents pnlCanceladaEsperaAceptacion As Panel
    Friend WithEvents pnPBar As Panel
    Friend WithEvents lblInfo As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnLimpiarFiltroStatus As Button
    Friend WithEvents btnAgregarFiltroStatus As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdStatus As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAgregarFiltroEmisor As Button
    Friend WithEvents btnLimpiarFiltroEmisor As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdEmisor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdoFechaFacturacion As RadioButton
    Friend WithEvents rdoFechaCancelacion As RadioButton
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdFolioOT As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtFiltroFolioOT As MaskedTextBox
    Friend WithEvents gboxCliente As GroupBox
    Friend WithEvents btnAgregarFiltroCliente As Button
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxFolioFactura As GroupBox
    Friend WithEvents txtFiltroFactura As TextBox
    Friend WithEvents Panel25 As Panel
    Friend WithEvents grdFactura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxFolioDocto As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grdFiltroDocumento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtFiltroDocumento As MaskedTextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents lblEstatusCancelacion As Label
    Friend WithEvents pnlEstatusCancelacion As Panel
    Friend WithEvents lblInfoSNC As Label
    Friend WithEvents lblInfoRNC As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlColorFA As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents chkMostrarOT As CheckBox
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbCEDIS As ComboBox
    Friend WithEvents pnlSolicitudCancelacion As Panel
    Friend WithEvents lblSolicitarCancelacion As Label
    Friend WithEvents btnSolicitarCancelacion As Button
    Friend WithEvents pnlVentas As Panel
    Friend WithEvents pnlGenerarXMLSap As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents btnGenerarXMLSap As Button
    Friend WithEvents pnlRefacturar As Panel
    Friend WithEvents lblRefacturar As Label
    Friend WithEvents btnRefacturar As Button
    Friend WithEvents pnlAnexarArchivos As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCargarPDF_XML As Button
    Friend WithEvents pnl As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnExportarReporte As Button
    Friend WithEvents PnlGenerarAddenda As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGeneraAddenda As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnEnvioCorreo As Button
    Friend WithEvents pnlEnvioCorreo As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents btnActualizarEstatusCancelacionSAT As Button
    Friend WithEvents pnlReintentarCancelacionSAT As Panel
    Friend WithEvents btnReintentarCancelacion As Button
    Friend WithEvents lblTextoReintentarCancelacion As Label
    Friend WithEvents pnlCancelar As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblTextoCancelar As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblTextoExportar As Label
    Friend WithEvents pnlTimbrarDocumento As Panel
    Friend WithEvents btnTimbrarDocumento As Button
    Friend WithEvents lblTimbrarDocumento As Label
    Friend WithEvents pnlImprimirPDF As Panel
    Friend WithEvents btnImprimirPDF As Button
    Friend WithEvents lblTextoImprimirPDF As Label
    Friend WithEvents pnlVerDetalles As Panel
    Friend WithEvents btnVerDetalles As Button
    Friend WithEvents lblTextoVerDetalles As Label
End Class
