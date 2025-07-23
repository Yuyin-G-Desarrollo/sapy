<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorComplementoRecepcionPagos_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorComplementoRecepcionPagos_Form))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdCFDI = New DevExpress.XtraGrid.GridControl()
        Me.bgvCFDI = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.EstatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Observaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCitaEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlTimbrarCoppel = New System.Windows.Forms.Panel()
        Me.btnTimbraCoppel = New System.Windows.Forms.Button()
        Me.lblTimbrarCoppel = New System.Windows.Forms.Label()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlPdf = New System.Windows.Forms.Panel()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.lblPdf = New System.Windows.Forms.Label()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        Me.lblTextoEnviarCorreo = New System.Windows.Forms.Label()
        Me.btnDescartar = New System.Windows.Forms.Button()
        Me.lblTextoDescartar = New System.Windows.Forms.Label()
        Me.btnCancelarCRP = New System.Windows.Forms.Button()
        Me.lblTextoDescargarArchivos = New System.Windows.Forms.Label()
        Me.lblTextoCancelar = New System.Windows.Forms.Label()
        Me.btnDescargarArchivos = New System.Windows.Forms.Button()
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblTextoExportarExcel = New System.Windows.Forms.Label()
        Me.lblTextoTimbrar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblDiseñoPorTimbrar = New System.Windows.Forms.Label()
        Me.lblDiseñoCancelado = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.chboxVerFacturas = New System.Windows.Forms.CheckBox()
        Me.cmbEstatusCFDI = New System.Windows.Forms.ComboBox()
        Me.cmboxEstatusPago = New System.Windows.Forms.ComboBox()
        Me.cmboxRazonSocial = New System.Windows.Forms.ComboBox()
        Me.gboxFechasGeneracionCRP = New System.Windows.Forms.GroupBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.gboxCliente = New System.Windows.Forms.GroupBox()
        Me.btnAgregarFiltroCliente = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxRFC = New System.Windows.Forms.GroupBox()
        Me.btnAgregarFiltroRFC = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltroRFC = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdRFC = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFolioCFDI = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtFiltroFolioCFDI = New System.Windows.Forms.MaskedTextBox()
        Me.gboxFolioFactura = New System.Windows.Forms.GroupBox()
        Me.txtFiltroFolioFactura = New System.Windows.Forms.TextBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.grdFolioFactura = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CmBoxTipoCrp = New System.Windows.Forms.ComboBox()
        Me.lbltipoRcp = New System.Windows.Forms.Label()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCFDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvCFDI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTimbrarCoppel.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.pnlPdf.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.gboxFechasGeneracionCRP.SuspendLayout()
        Me.gboxCliente.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxRFC.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFolioCFDI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFolioFactura.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.grdFolioFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdCFDI
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
        'grdCFDI
        '
        Me.grdCFDI.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.grdDetallesOT
        GridLevelNode1.RelationName = "Level1"
        Me.grdCFDI.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdCFDI.Location = New System.Drawing.Point(0, 0)
        Me.grdCFDI.MainView = Me.bgvCFDI
        Me.grdCFDI.Name = "grdCFDI"
        Me.grdCFDI.Size = New System.Drawing.Size(1145, 242)
        Me.grdCFDI.TabIndex = 1
        Me.grdCFDI.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvCFDI, Me.GridView1, Me.grdDetallesOT})
        '
        'bgvCFDI
        '
        Me.bgvCFDI.GridControl = Me.grdCFDI
        Me.bgvCFDI.Name = "bgvCFDI"
        Me.bgvCFDI.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvCFDI.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvCFDI.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvCFDI.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvCFDI.OptionsSelection.MultiSelect = True
        Me.bgvCFDI.OptionsView.ColumnAutoWidth = False
        Me.bgvCFDI.OptionsView.ShowAutoFilterRow = True
        Me.bgvCFDI.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdCFDI
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
        Me.Seleccionar.Caption = """"
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.VisibleIndex = 0
        Me.Seleccionar.Width = 35
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
        Me.Observaciones.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value
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
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1145, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(526, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlTimbrarCoppel)
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(533, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlTimbrarCoppel
        '
        Me.pnlTimbrarCoppel.Controls.Add(Me.btnTimbraCoppel)
        Me.pnlTimbrarCoppel.Controls.Add(Me.lblTimbrarCoppel)
        Me.pnlTimbrarCoppel.Location = New System.Drawing.Point(384, 6)
        Me.pnlTimbrarCoppel.Name = "pnlTimbrarCoppel"
        Me.pnlTimbrarCoppel.Size = New System.Drawing.Size(56, 59)
        Me.pnlTimbrarCoppel.TabIndex = 118
        Me.pnlTimbrarCoppel.Visible = False
        '
        'btnTimbraCoppel
        '
        Me.btnTimbraCoppel.BackgroundImage = CType(resources.GetObject("btnTimbraCoppel.BackgroundImage"), System.Drawing.Image)
        Me.btnTimbraCoppel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnTimbraCoppel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnTimbraCoppel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTimbraCoppel.Location = New System.Drawing.Point(10, 1)
        Me.btnTimbraCoppel.Name = "btnTimbraCoppel"
        Me.btnTimbraCoppel.Size = New System.Drawing.Size(32, 32)
        Me.btnTimbraCoppel.TabIndex = 117
        Me.btnTimbraCoppel.UseVisualStyleBackColor = True
        '
        'lblTimbrarCoppel
        '
        Me.lblTimbrarCoppel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTimbrarCoppel.Location = New System.Drawing.Point(6, 32)
        Me.lblTimbrarCoppel.Name = "lblTimbrarCoppel"
        Me.lblTimbrarCoppel.Size = New System.Drawing.Size(48, 26)
        Me.lblTimbrarCoppel.TabIndex = 116
        Me.lblTimbrarCoppel.Text = "Timbrar Coppel"
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.pnlPdf)
        Me.pnlVentas.Controls.Add(Me.btnEnviarCorreo)
        Me.pnlVentas.Controls.Add(Me.lblTextoEnviarCorreo)
        Me.pnlVentas.Controls.Add(Me.btnDescartar)
        Me.pnlVentas.Controls.Add(Me.lblTextoDescartar)
        Me.pnlVentas.Controls.Add(Me.btnCancelarCRP)
        Me.pnlVentas.Controls.Add(Me.lblTextoDescargarArchivos)
        Me.pnlVentas.Controls.Add(Me.lblTextoCancelar)
        Me.pnlVentas.Controls.Add(Me.btnDescargarArchivos)
        Me.pnlVentas.Controls.Add(Me.btnTimbrar)
        Me.pnlVentas.Controls.Add(Me.btnExportarExcel)
        Me.pnlVentas.Controls.Add(Me.lblTextoExportarExcel)
        Me.pnlVentas.Controls.Add(Me.lblTextoTimbrar)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 3)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(532, 62)
        Me.pnlVentas.TabIndex = 108
        '
        'pnlPdf
        '
        Me.pnlPdf.Controls.Add(Me.btnPdf)
        Me.pnlPdf.Controls.Add(Me.lblPdf)
        Me.pnlPdf.Location = New System.Drawing.Point(438, 3)
        Me.pnlPdf.Name = "pnlPdf"
        Me.pnlPdf.Size = New System.Drawing.Size(56, 59)
        Me.pnlPdf.TabIndex = 119
        Me.pnlPdf.Visible = False
        '
        'btnPdf
        '
        Me.btnPdf.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPdf.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPdf.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnPdf.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPdf.Location = New System.Drawing.Point(12, 1)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(32, 32)
        Me.btnPdf.TabIndex = 117
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'lblPdf
        '
        Me.lblPdf.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPdf.Location = New System.Drawing.Point(6, 32)
        Me.lblPdf.Name = "lblPdf"
        Me.lblPdf.Size = New System.Drawing.Size(48, 26)
        Me.lblPdf.TabIndex = 116
        Me.lblPdf.Text = "Generar Pdf"
        Me.lblPdf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviarCorreo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviarCorreo.Image = Global.Ventas.Vista.My.Resources.Resources.Email
        Me.btnEnviarCorreo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(279, 5)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviarCorreo.TabIndex = 115
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'lblTextoEnviarCorreo
        '
        Me.lblTextoEnviarCorreo.AutoSize = True
        Me.lblTextoEnviarCorreo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoEnviarCorreo.Location = New System.Drawing.Point(277, 36)
        Me.lblTextoEnviarCorreo.Name = "lblTextoEnviarCorreo"
        Me.lblTextoEnviarCorreo.Size = New System.Drawing.Size(37, 13)
        Me.lblTextoEnviarCorreo.TabIndex = 114
        Me.lblTextoEnviarCorreo.Text = "Enviar"
        '
        'btnDescartar
        '
        Me.btnDescartar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDescartar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDescartar.Image = Global.Ventas.Vista.My.Resources.Resources.rechazar_32
        Me.btnDescartar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDescartar.Location = New System.Drawing.Point(224, 5)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(32, 32)
        Me.btnDescartar.TabIndex = 113
        Me.btnDescartar.UseVisualStyleBackColor = True
        '
        'lblTextoDescartar
        '
        Me.lblTextoDescartar.AutoSize = True
        Me.lblTextoDescartar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoDescartar.Location = New System.Drawing.Point(214, 36)
        Me.lblTextoDescartar.Name = "lblTextoDescartar"
        Me.lblTextoDescartar.Size = New System.Drawing.Size(53, 13)
        Me.lblTextoDescartar.TabIndex = 112
        Me.lblTextoDescartar.Text = "Descartar"
        '
        'btnCancelarCRP
        '
        Me.btnCancelarCRP.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarCRP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarCRP.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarCRP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarCRP.Location = New System.Drawing.Point(171, 5)
        Me.btnCancelarCRP.Name = "btnCancelarCRP"
        Me.btnCancelarCRP.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarCRP.TabIndex = 111
        Me.btnCancelarCRP.UseVisualStyleBackColor = True
        '
        'lblTextoDescargarArchivos
        '
        Me.lblTextoDescargarArchivos.AutoSize = True
        Me.lblTextoDescargarArchivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoDescargarArchivos.Location = New System.Drawing.Point(104, 35)
        Me.lblTextoDescargarArchivos.Name = "lblTextoDescargarArchivos"
        Me.lblTextoDescargarArchivos.Size = New System.Drawing.Size(56, 26)
        Me.lblTextoDescargarArchivos.TabIndex = 110
        Me.lblTextoDescargarArchivos.Text = "Descargar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTextoDescargarArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoCancelar
        '
        Me.lblTextoCancelar.AutoSize = True
        Me.lblTextoCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoCancelar.Location = New System.Drawing.Point(163, 36)
        Me.lblTextoCancelar.Name = "lblTextoCancelar"
        Me.lblTextoCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblTextoCancelar.TabIndex = 109
        Me.lblTextoCancelar.Text = "Cancelar"
        '
        'btnDescargarArchivos
        '
        Me.btnDescargarArchivos.BackgroundImage = CType(resources.GetObject("btnDescargarArchivos.BackgroundImage"), System.Drawing.Image)
        Me.btnDescargarArchivos.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDescargarArchivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDescargarArchivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDescargarArchivos.Location = New System.Drawing.Point(116, 4)
        Me.btnDescargarArchivos.Name = "btnDescargarArchivos"
        Me.btnDescargarArchivos.Size = New System.Drawing.Size(32, 32)
        Me.btnDescargarArchivos.TabIndex = 108
        Me.btnDescargarArchivos.UseVisualStyleBackColor = True
        '
        'btnTimbrar
        '
        Me.btnTimbrar.BackgroundImage = CType(resources.GetObject("btnTimbrar.BackgroundImage"), System.Drawing.Image)
        Me.btnTimbrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnTimbrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnTimbrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTimbrar.Location = New System.Drawing.Point(65, 5)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(32, 32)
        Me.btnTimbrar.TabIndex = 106
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(19, 5)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 105
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblTextoExportarExcel
        '
        Me.lblTextoExportarExcel.AutoSize = True
        Me.lblTextoExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoExportarExcel.Location = New System.Drawing.Point(12, 36)
        Me.lblTextoExportarExcel.Name = "lblTextoExportarExcel"
        Me.lblTextoExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblTextoExportarExcel.TabIndex = 83
        Me.lblTextoExportarExcel.Text = "Exportar"
        '
        'lblTextoTimbrar
        '
        Me.lblTextoTimbrar.AutoSize = True
        Me.lblTextoTimbrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoTimbrar.Location = New System.Drawing.Point(60, 36)
        Me.lblTextoTimbrar.Name = "lblTextoTimbrar"
        Me.lblTextoTimbrar.Size = New System.Drawing.Size(42, 13)
        Me.lblTextoTimbrar.TabIndex = 75
        Me.lblTextoTimbrar.Text = "Timbrar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(522, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(623, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(20, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(527, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de CFDI de Complemento de Recepción de Pagos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(540, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblDiseñoPorTimbrar
        '
        Me.lblDiseñoPorTimbrar.AutoSize = True
        Me.lblDiseñoPorTimbrar.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblDiseñoPorTimbrar.Location = New System.Drawing.Point(104, 13)
        Me.lblDiseñoPorTimbrar.Name = "lblDiseñoPorTimbrar"
        Me.lblDiseñoPorTimbrar.Size = New System.Drawing.Size(61, 13)
        Me.lblDiseñoPorTimbrar.TabIndex = 135
        Me.lblDiseñoPorTimbrar.Text = "Por Timbrar"
        '
        'lblDiseñoCancelado
        '
        Me.lblDiseñoCancelado.AutoSize = True
        Me.lblDiseñoCancelado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiseñoCancelado.ForeColor = System.Drawing.Color.Red
        Me.lblDiseñoCancelado.Location = New System.Drawing.Point(104, 35)
        Me.lblDiseñoCancelado.Name = "lblDiseñoCancelado"
        Me.lblDiseñoCancelado.Size = New System.Drawing.Size(58, 13)
        Me.lblDiseñoCancelado.TabIndex = 134
        Me.lblDiseñoCancelado.Text = "Cancelado"
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
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.lblDiseñoPorTimbrar)
        Me.pnlPie.Controls.Add(Me.lblDiseñoCancelado)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 488)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1145, 60)
        Me.pnlPie.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(216, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Cliente sin Email"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(198, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 136
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(983, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
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
        Me.Panel1.Size = New System.Drawing.Size(1145, 548)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdCFDI)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 246)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1145, 242)
        Me.Panel3.TabIndex = 27
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Label5)
        Me.pnlParametros.Controls.Add(Me.Label4)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Controls.Add(Me.Panel5)
        Me.pnlParametros.Controls.Add(Me.chboxVerFacturas)
        Me.pnlParametros.Controls.Add(Me.cmbEstatusCFDI)
        Me.pnlParametros.Controls.Add(Me.cmboxEstatusPago)
        Me.pnlParametros.Controls.Add(Me.cmboxRazonSocial)
        Me.pnlParametros.Controls.Add(Me.gboxFechasGeneracionCRP)
        Me.pnlParametros.Controls.Add(Me.gboxCliente)
        Me.pnlParametros.Controls.Add(Me.gboxRFC)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.gboxFolioFactura)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1145, 181)
        Me.pnlParametros.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(682, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Estatus CFDI:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(682, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Estatus Pago:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(682, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Razón Social Emisor:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnLimpiar)
        Me.Panel5.Controls.Add(Me.lblLimpiar)
        Me.Panel5.Controls.Add(Me.btnMostrar)
        Me.Panel5.Controls.Add(Me.lblMostrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1040, 27)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(105, 154)
        Me.Panel5.TabIndex = 140
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(66, 55)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(63, 87)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(16, 55)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(12, 87)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 0
        Me.lblMostrar.Text = "Mostrar"
        '
        'chboxVerFacturas
        '
        Me.chboxVerFacturas.AutoSize = True
        Me.chboxVerFacturas.Location = New System.Drawing.Point(896, 156)
        Me.chboxVerFacturas.Name = "chboxVerFacturas"
        Me.chboxVerFacturas.Size = New System.Drawing.Size(83, 17)
        Me.chboxVerFacturas.TabIndex = 139
        Me.chboxVerFacturas.Text = "Ver facturas"
        Me.chboxVerFacturas.UseVisualStyleBackColor = True
        '
        'cmbEstatusCFDI
        '
        Me.cmbEstatusCFDI.FormattingEnabled = True
        Me.cmbEstatusCFDI.Items.AddRange(New Object() {"", "ACTIVO", "CANCELADO"})
        Me.cmbEstatusCFDI.Location = New System.Drawing.Point(685, 147)
        Me.cmbEstatusCFDI.Name = "cmbEstatusCFDI"
        Me.cmbEstatusCFDI.Size = New System.Drawing.Size(160, 21)
        Me.cmbEstatusCFDI.TabIndex = 138
        '
        'cmboxEstatusPago
        '
        Me.cmboxEstatusPago.FormattingEnabled = True
        Me.cmboxEstatusPago.Items.AddRange(New Object() {"", "POR TIMBRAR", "TIMBRADO"})
        Me.cmboxEstatusPago.Location = New System.Drawing.Point(685, 103)
        Me.cmboxEstatusPago.Name = "cmboxEstatusPago"
        Me.cmboxEstatusPago.Size = New System.Drawing.Size(160, 21)
        Me.cmboxEstatusPago.TabIndex = 137
        '
        'cmboxRazonSocial
        '
        Me.cmboxRazonSocial.FormattingEnabled = True
        Me.cmboxRazonSocial.Location = New System.Drawing.Point(685, 55)
        Me.cmboxRazonSocial.Name = "cmboxRazonSocial"
        Me.cmboxRazonSocial.Size = New System.Drawing.Size(323, 21)
        Me.cmboxRazonSocial.TabIndex = 136
        '
        'gboxFechasGeneracionCRP
        '
        Me.gboxFechasGeneracionCRP.Controls.Add(Me.dtpFechaInicio)
        Me.gboxFechasGeneracionCRP.Controls.Add(Me.lblEntregaDel)
        Me.gboxFechasGeneracionCRP.Controls.Add(Me.dtpFechaFin)
        Me.gboxFechasGeneracionCRP.Controls.Add(Me.lblEntregaAl)
        Me.gboxFechasGeneracionCRP.Location = New System.Drawing.Point(866, 82)
        Me.gboxFechasGeneracionCRP.Name = "gboxFechasGeneracionCRP"
        Me.gboxFechasGeneracionCRP.Size = New System.Drawing.Size(142, 68)
        Me.gboxFechasGeneracionCRP.TabIndex = 135
        Me.gboxFechasGeneracionCRP.TabStop = False
        Me.gboxFechasGeneracionCRP.Text = "Fecha Generación CRP:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(35, 16)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaInicio.TabIndex = 66
        Me.dtpFechaInicio.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(13, 21)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(35, 41)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaFin.TabIndex = 69
        Me.dtpFechaFin.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(13, 43)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'gboxCliente
        '
        Me.gboxCliente.Controls.Add(Me.btnAgregarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.Panel4)
        Me.gboxCliente.Location = New System.Drawing.Point(12, 34)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(244, 137)
        Me.gboxCliente.TabIndex = 134
        Me.gboxCliente.TabStop = False
        Me.gboxCliente.Text = "Cliente"
        '
        'btnAgregarFiltroCliente
        '
        Me.btnAgregarFiltroCliente.Image = CType(resources.GetObject("btnAgregarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroCliente.Location = New System.Drawing.Point(217, 12)
        Me.btnAgregarFiltroCliente.Name = "btnAgregarFiltroCliente"
        Me.btnAgregarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroCliente.TabIndex = 8
        Me.btnAgregarFiltroCliente.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(189, 12)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 7
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdCliente)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(238, 98)
        Me.Panel4.TabIndex = 2
        '
        'grdCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance1
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(238, 98)
        Me.grdCliente.TabIndex = 2
        '
        'gboxRFC
        '
        Me.gboxRFC.Controls.Add(Me.btnAgregarFiltroRFC)
        Me.gboxRFC.Controls.Add(Me.btnLimpiarFiltroRFC)
        Me.gboxRFC.Controls.Add(Me.Panel7)
        Me.gboxRFC.Location = New System.Drawing.Point(260, 34)
        Me.gboxRFC.Name = "gboxRFC"
        Me.gboxRFC.Size = New System.Drawing.Size(244, 137)
        Me.gboxRFC.TabIndex = 67
        Me.gboxRFC.TabStop = False
        Me.gboxRFC.Text = "RFC Receptor"
        '
        'btnAgregarFiltroRFC
        '
        Me.btnAgregarFiltroRFC.Image = CType(resources.GetObject("btnAgregarFiltroRFC.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroRFC.Location = New System.Drawing.Point(215, 12)
        Me.btnAgregarFiltroRFC.Name = "btnAgregarFiltroRFC"
        Me.btnAgregarFiltroRFC.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroRFC.TabIndex = 6
        Me.btnAgregarFiltroRFC.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltroRFC
        '
        Me.btnLimpiarFiltroRFC.Image = CType(resources.GetObject("btnLimpiarFiltroRFC.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroRFC.Location = New System.Drawing.Point(187, 12)
        Me.btnLimpiarFiltroRFC.Name = "btnLimpiarFiltroRFC"
        Me.btnLimpiarFiltroRFC.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroRFC.TabIndex = 5
        Me.btnLimpiarFiltroRFC.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdRFC)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(238, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdRFC
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRFC.DisplayLayout.Appearance = Appearance3
        Me.grdRFC.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRFC.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRFC.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRFC.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRFC.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRFC.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRFC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRFC.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdRFC.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRFC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRFC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdRFC.Location = New System.Drawing.Point(0, 0)
        Me.grdRFC.Name = "grdRFC"
        Me.grdRFC.Size = New System.Drawing.Size(238, 98)
        Me.grdRFC.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.txtFiltroFolioCFDI)
        Me.GroupBox1.Location = New System.Drawing.Point(596, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 137)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Folio CFDI"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFolioCFDI)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(77, 98)
        Me.Panel2.TabIndex = 2
        '
        'grdFolioCFDI
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioCFDI.DisplayLayout.Appearance = Appearance5
        Me.grdFolioCFDI.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFolioCFDI.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFolioCFDI.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFolioCFDI.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFolioCFDI.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFolioCFDI.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFolioCFDI.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFolioCFDI.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioCFDI.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdFolioCFDI.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFolioCFDI.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFolioCFDI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolioCFDI.Location = New System.Drawing.Point(0, 0)
        Me.grdFolioCFDI.Name = "grdFolioCFDI"
        Me.grdFolioCFDI.Size = New System.Drawing.Size(77, 98)
        Me.grdFolioCFDI.TabIndex = 1
        '
        'txtFiltroFolioCFDI
        '
        Me.txtFiltroFolioCFDI.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroFolioCFDI.Mask = "99999999999999999"
        Me.txtFiltroFolioCFDI.Name = "txtFiltroFolioCFDI"
        Me.txtFiltroFolioCFDI.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFiltroFolioCFDI.Size = New System.Drawing.Size(71, 20)
        Me.txtFiltroFolioCFDI.TabIndex = 0
        Me.txtFiltroFolioCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxFolioFactura
        '
        Me.gboxFolioFactura.Controls.Add(Me.txtFiltroFolioFactura)
        Me.gboxFolioFactura.Controls.Add(Me.Panel25)
        Me.gboxFolioFactura.Location = New System.Drawing.Point(507, 34)
        Me.gboxFolioFactura.Name = "gboxFolioFactura"
        Me.gboxFolioFactura.Size = New System.Drawing.Size(83, 137)
        Me.gboxFolioFactura.TabIndex = 55
        Me.gboxFolioFactura.TabStop = False
        Me.gboxFolioFactura.Text = "Folio Factura"
        '
        'txtFiltroFolioFactura
        '
        Me.txtFiltroFolioFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltroFolioFactura.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroFolioFactura.MaxLength = 50
        Me.txtFiltroFolioFactura.Name = "txtFiltroFolioFactura"
        Me.txtFiltroFolioFactura.Size = New System.Drawing.Size(71, 20)
        Me.txtFiltroFolioFactura.TabIndex = 3
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.grdFolioFactura)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(3, 36)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(77, 98)
        Me.Panel25.TabIndex = 2
        '
        'grdFolioFactura
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioFactura.DisplayLayout.Appearance = Appearance7
        Me.grdFolioFactura.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFolioFactura.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFolioFactura.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFolioFactura.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFolioFactura.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFolioFactura.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFolioFactura.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFolioFactura.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioFactura.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdFolioFactura.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFolioFactura.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFolioFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolioFactura.Location = New System.Drawing.Point(0, 0)
        Me.grdFolioFactura.Name = "grdFolioFactura"
        Me.grdFolioFactura.Size = New System.Drawing.Size(77, 98)
        Me.grdFolioFactura.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.CmBoxTipoCrp)
        Me.Panel6.Controls.Add(Me.lbltipoRcp)
        Me.Panel6.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1145, 27)
        Me.Panel6.TabIndex = 46
        '
        'CmBoxTipoCrp
        '
        Me.CmBoxTipoCrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmBoxTipoCrp.FormattingEnabled = True
        Me.CmBoxTipoCrp.Location = New System.Drawing.Point(446, 3)
        Me.CmBoxTipoCrp.Name = "CmBoxTipoCrp"
        Me.CmBoxTipoCrp.Size = New System.Drawing.Size(230, 21)
        Me.CmBoxTipoCrp.TabIndex = 143
        '
        'lbltipoRcp
        '
        Me.lbltipoRcp.AutoSize = True
        Me.lbltipoRcp.Location = New System.Drawing.Point(388, 7)
        Me.lbltipoRcp.Name = "lbltipoRcp"
        Me.lbltipoRcp.Size = New System.Drawing.Size(56, 13)
        Me.lbltipoRcp.TabIndex = 142
        Me.lbltipoRcp.Text = "Tipo CRP:"
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
        Me.btnArriba.Location = New System.Drawing.Point(1085, 3)
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
        Me.btnAbajo.Location = New System.Drawing.Point(1111, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'AdministradorComplementoRecepcionPagos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministradorComplementoRecepcionPagos_Form"
        Me.Text = "Administrador de CFDI de Complemento de Recepción de Pagos"
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCFDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvCFDI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlTimbrarCoppel.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlVentas.PerformLayout()
        Me.pnlPdf.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.gboxFechasGeneracionCRP.ResumeLayout(False)
        Me.gboxFechasGeneracionCRP.PerformLayout()
        Me.gboxCliente.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxRFC.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdRFC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFolioCFDI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFolioFactura.ResumeLayout(False)
        Me.gboxFolioFactura.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.grdFolioFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlVentas As System.Windows.Forms.Panel
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents lblTextoDescartar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarCRP As System.Windows.Forms.Button
    Friend WithEvents lblTextoDescargarArchivos As System.Windows.Forms.Label
    Friend WithEvents lblTextoCancelar As System.Windows.Forms.Label
    Friend WithEvents btnDescargarArchivos As System.Windows.Forms.Button
    Friend WithEvents btnTimbrar As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblTextoExportarExcel As System.Windows.Forms.Label
    Friend WithEvents lblTextoTimbrar As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
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
    Friend WithEvents grdCFDI As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvCFDI As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblDiseñoPorTimbrar As System.Windows.Forms.Label
    Friend WithEvents lblDiseñoCancelado As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents chboxVerFacturas As System.Windows.Forms.CheckBox
    Friend WithEvents cmbEstatusCFDI As System.Windows.Forms.ComboBox
    Friend WithEvents cmboxEstatusPago As System.Windows.Forms.ComboBox
    Friend WithEvents cmboxRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents gboxFechasGeneracionCRP As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaDel As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaAl As System.Windows.Forms.Label
    Friend WithEvents gboxCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdFolioCFDI As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtFiltroFolioCFDI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gboxRFC As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarFiltroRFC As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFiltroRFC As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents grdRFC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxFolioFactura As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltroFolioFactura As System.Windows.Forms.TextBox
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents grdFolioFactura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnEnviarCorreo As Button
    Friend WithEvents lblTextoEnviarCorreo As Label
    Friend WithEvents pnlTimbrarCoppel As System.Windows.Forms.Panel
    Friend WithEvents btnTimbraCoppel As System.Windows.Forms.Button
    Friend WithEvents lblTimbrarCoppel As System.Windows.Forms.Label
    Friend WithEvents pnlPdf As Panel
    Friend WithEvents btnPdf As Button
    Friend WithEvents lblPdf As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CmBoxTipoCrp As ComboBox
    Friend WithEvents lbltipoRcp As Label
End Class
