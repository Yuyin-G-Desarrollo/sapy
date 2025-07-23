<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministradorOT_Form_Facturacion
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorOT_Form_Facturacion))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdOts = New DevExpress.XtraGrid.GridControl()
        Me.bgvOts = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlColorFA = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlStatusPorRefacturar = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlStatusEntrega = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlStatusEnRuta = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlStatusPorFacturar = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlStatusFacturada = New System.Windows.Forms.Panel()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.lblNoFacturado = New System.Windows.Forms.Label()
        Me.pnlClienteBloqueado = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCEDIS = New System.Windows.Forms.ComboBox()
        Me.chkMostrarAndrea = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmboxStatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.rdoEntrega = New System.Windows.Forms.RadioButton()
        Me.rdoConfirmacion = New System.Windows.Forms.RadioButton()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.rdoFacturacion = New System.Windows.Forms.RadioButton()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFolioOT = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtFolioOT = New System.Windows.Forms.MaskedTextBox()
        Me.gboxTiendas = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroTienda = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroTienda = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdTienda = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxCliente = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxSICY = New System.Windows.Forms.GroupBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.grdPedidoSICY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSICY = New System.Windows.Forms.MaskedTextBox()
        Me.gboxPedidosSAY = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdPedidoSAY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSAY = New System.Windows.Forms.MaskedTextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.btnCancelarRefacturacion = New System.Windows.Forms.Button()
        Me.lblTextoCancelarRefacturacion = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDocumentoDinamico = New System.Windows.Forms.Button()
        Me.btnDocumentar = New System.Windows.Forms.Button()
        Me.lblTextoAutorizar = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.CMS_CambiarDoc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdOts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvOts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFolioOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxTiendas.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCliente.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSICY.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.grdPedidoSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPedidosSAY.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_CambiarDoc.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1284, 581)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdOts)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 285)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1284, 236)
        Me.Panel3.TabIndex = 27
        '
        'grdOts
        '
        Me.grdOts.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdOts.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdOts.Location = New System.Drawing.Point(0, 0)
        Me.grdOts.MainView = Me.bgvOts
        Me.grdOts.Name = "grdOts"
        Me.grdOts.Size = New System.Drawing.Size(1284, 236)
        Me.grdOts.TabIndex = 1
        Me.grdOts.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvOts, Me.GridView1, Me.grdDetallesOT})
        '
        'bgvOts
        '
        Me.bgvOts.GridControl = Me.grdOts
        Me.bgvOts.Name = "bgvOts"
        Me.bgvOts.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvOts.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvOts.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvOts.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvOts.OptionsSelection.MultiSelect = True
        Me.bgvOts.OptionsView.ColumnAutoWidth = False
        Me.bgvOts.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.bgvOts.OptionsView.ShowAutoFilterRow = True
        Me.bgvOts.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdOts
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
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdOts
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
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.GroupBox2)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.GroupBox12)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlPie.Controls.Add(Me.lblNoFacturado)
        Me.pnlPie.Controls.Add(Me.pnlClienteBloqueado)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 521)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1284, 60)
        Me.pnlPie.TabIndex = 26
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.pnlColorFA)
        Me.GroupBox2.Location = New System.Drawing.Point(725, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(225, 55)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "FA - Facturación Anticipada"
        '
        'pnlColorFA
        '
        Me.pnlColorFA.BackColor = System.Drawing.Color.ForestGreen
        Me.pnlColorFA.ForeColor = System.Drawing.Color.Black
        Me.pnlColorFA.Location = New System.Drawing.Point(21, 28)
        Me.pnlColorFA.Name = "pnlColorFA"
        Me.pnlColorFA.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorFA.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(967, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 26)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Nota: La tienda mostrada es la tienda" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de la primera partida de la OT"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label4)
        Me.GroupBox12.Controls.Add(Me.pnlStatusPorRefacturar)
        Me.GroupBox12.Controls.Add(Me.Label14)
        Me.GroupBox12.Controls.Add(Me.pnlStatusEntrega)
        Me.GroupBox12.Controls.Add(Me.Label10)
        Me.GroupBox12.Controls.Add(Me.pnlStatusEnRuta)
        Me.GroupBox12.Controls.Add(Me.Label9)
        Me.GroupBox12.Controls.Add(Me.pnlStatusPorFacturar)
        Me.GroupBox12.Controls.Add(Me.Label8)
        Me.GroupBox12.Controls.Add(Me.pnlStatusFacturada)
        Me.GroupBox12.Location = New System.Drawing.Point(291, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(432, 55)
        Me.GroupBox12.TabIndex = 121
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Status OT (ST)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Por Refacturar"
        '
        'pnlStatusPorRefacturar
        '
        Me.pnlStatusPorRefacturar.BackColor = System.Drawing.Color.Gold
        Me.pnlStatusPorRefacturar.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusPorRefacturar.Location = New System.Drawing.Point(334, 26)
        Me.pnlStatusPorRefacturar.Name = "pnlStatusPorRefacturar"
        Me.pnlStatusPorRefacturar.Size = New System.Drawing.Size(15, 15)
        Me.pnlStatusPorRefacturar.TabIndex = 45
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(268, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Entregada"
        '
        'pnlStatusEntrega
        '
        Me.pnlStatusEntrega.BackColor = System.Drawing.Color.Brown
        Me.pnlStatusEntrega.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusEntrega.Location = New System.Drawing.Point(250, 26)
        Me.pnlStatusEntrega.Name = "pnlStatusEntrega"
        Me.pnlStatusEntrega.Size = New System.Drawing.Size(15, 15)
        Me.pnlStatusEntrega.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "En Ruta"
        '
        'pnlStatusEnRuta
        '
        Me.pnlStatusEnRuta.BackColor = System.Drawing.Color.Coral
        Me.pnlStatusEnRuta.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusEnRuta.Location = New System.Drawing.Point(173, 26)
        Me.pnlStatusEnRuta.Name = "pnlStatusEnRuta"
        Me.pnlStatusEnRuta.Size = New System.Drawing.Size(15, 15)
        Me.pnlStatusEnRuta.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Por Facturar"
        '
        'pnlStatusPorFacturar
        '
        Me.pnlStatusPorFacturar.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlStatusPorFacturar.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusPorFacturar.Location = New System.Drawing.Point(6, 26)
        Me.pnlStatusPorFacturar.Name = "pnlStatusPorFacturar"
        Me.pnlStatusPorFacturar.Size = New System.Drawing.Size(15, 15)
        Me.pnlStatusPorFacturar.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(111, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Facturada"
        '
        'pnlStatusFacturada
        '
        Me.pnlStatusFacturada.BackColor = System.Drawing.Color.Pink
        Me.pnlStatusFacturada.ForeColor = System.Drawing.Color.Black
        Me.pnlStatusFacturada.Location = New System.Drawing.Point(93, 26)
        Me.pnlStatusFacturada.Name = "pnlStatusFacturada"
        Me.pnlStatusFacturada.Size = New System.Drawing.Size(15, 15)
        Me.pnlStatusFacturada.TabIndex = 37
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(10, 10)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 16)
        Me.lblClientes.TabIndex = 118
        Me.lblClientes.Text = "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(32, 31)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalSeleccionados.TabIndex = 117
        Me.lblTotalSeleccionados.Text = "0"
        Me.lblTotalSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNoFacturado
        '
        Me.lblNoFacturado.AutoSize = True
        Me.lblNoFacturado.Location = New System.Drawing.Point(164, 25)
        Me.lblNoFacturado.Name = "lblNoFacturado"
        Me.lblNoFacturado.Size = New System.Drawing.Size(103, 13)
        Me.lblNoFacturado.TabIndex = 115
        Me.lblNoFacturado.Text = "Clientes Bloqueados"
        '
        'pnlClienteBloqueado
        '
        Me.pnlClienteBloqueado.BackColor = System.Drawing.Color.Salmon
        Me.pnlClienteBloqueado.ForeColor = System.Drawing.Color.Black
        Me.pnlClienteBloqueado.Location = New System.Drawing.Point(148, 23)
        Me.pnlClienteBloqueado.Name = "pnlClienteBloqueado"
        Me.pnlClienteBloqueado.Size = New System.Drawing.Size(15, 15)
        Me.pnlClienteBloqueado.TabIndex = 116
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1122, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(72, 8)
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
        Me.lblLimpiar.Location = New System.Drawing.Point(69, 40)
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
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
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
        Me.lblAceptar.Location = New System.Drawing.Point(18, 40)
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
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(22, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Label6)
        Me.pnlParametros.Controls.Add(Me.cmbCEDIS)
        Me.pnlParametros.Controls.Add(Me.chkMostrarAndrea)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Controls.Add(Me.cmboxStatus)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.gboxTiendas)
        Me.pnlParametros.Controls.Add(Me.gboxCliente)
        Me.pnlParametros.Controls.Add(Me.gboxSICY)
        Me.pnlParametros.Controls.Add(Me.gboxPedidosSAY)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1284, 220)
        Me.pnlParametros.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "CEDIS"
        '
        'cmbCEDIS
        '
        Me.cmbCEDIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEDIS.FormattingEnabled = True
        Me.cmbCEDIS.Location = New System.Drawing.Point(53, 29)
        Me.cmbCEDIS.Name = "cmbCEDIS"
        Me.cmbCEDIS.Size = New System.Drawing.Size(175, 21)
        Me.cmbCEDIS.TabIndex = 141
        '
        'chkMostrarAndrea
        '
        Me.chkMostrarAndrea.AutoSize = True
        Me.chkMostrarAndrea.Location = New System.Drawing.Point(53, 78)
        Me.chkMostrarAndrea.Name = "chkMostrarAndrea"
        Me.chkMostrarAndrea.Size = New System.Drawing.Size(98, 17)
        Me.chkMostrarAndrea.TabIndex = 140
        Me.chkMostrarAndrea.Text = "Mostrar Andrea"
        Me.chkMostrarAndrea.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Status:"
        '
        'cmboxStatus
        '
        Me.cmboxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxStatus.FormattingEnabled = True
        Me.cmboxStatus.Location = New System.Drawing.Point(53, 54)
        Me.cmboxStatus.Name = "cmboxStatus"
        Me.cmboxStatus.Size = New System.Drawing.Size(175, 21)
        Me.cmboxStatus.TabIndex = 132
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkFecha)
        Me.GroupBox3.Controls.Add(Me.rdoEntrega)
        Me.GroupBox3.Controls.Add(Me.rdoConfirmacion)
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.rdoFacturacion)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(217, 93)
        Me.GroupBox3.TabIndex = 129
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Location = New System.Drawing.Point(7, 13)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(56, 17)
        Me.chkFecha.TabIndex = 139
        Me.chkFecha.Text = "Fecha"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'rdoEntrega
        '
        Me.rdoEntrega.AutoSize = True
        Me.rdoEntrega.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoEntrega.Checked = True
        Me.rdoEntrega.Enabled = False
        Me.rdoEntrega.Location = New System.Drawing.Point(19, 32)
        Me.rdoEntrega.Name = "rdoEntrega"
        Me.rdoEntrega.Size = New System.Drawing.Size(81, 17)
        Me.rdoEntrega.TabIndex = 92
        Me.rdoEntrega.TabStop = True
        Me.rdoEntrega.Text = "Entrega Cte"
        Me.rdoEntrega.UseVisualStyleBackColor = False
        '
        'rdoConfirmacion
        '
        Me.rdoConfirmacion.AutoSize = True
        Me.rdoConfirmacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoConfirmacion.Enabled = False
        Me.rdoConfirmacion.Location = New System.Drawing.Point(19, 49)
        Me.rdoConfirmacion.Name = "rdoConfirmacion"
        Me.rdoConfirmacion.Size = New System.Drawing.Size(86, 17)
        Me.rdoConfirmacion.TabIndex = 92
        Me.rdoConfirmacion.Text = "Confirmación"
        Me.rdoConfirmacion.UseVisualStyleBackColor = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(133, 34)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaInicio.TabIndex = 66
        Me.dtpFechaInicio.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.Enabled = False
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(111, 39)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'rdoFacturacion
        '
        Me.rdoFacturacion.AutoSize = True
        Me.rdoFacturacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoFacturacion.Enabled = False
        Me.rdoFacturacion.Location = New System.Drawing.Point(19, 66)
        Me.rdoFacturacion.Name = "rdoFacturacion"
        Me.rdoFacturacion.Size = New System.Drawing.Size(81, 17)
        Me.rdoFacturacion.TabIndex = 90
        Me.rdoFacturacion.Text = "Facturación"
        Me.rdoFacturacion.UseVisualStyleBackColor = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(133, 59)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaFin.TabIndex = 69
        Me.dtpFechaFin.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.Enabled = False
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(111, 61)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.txtFolioOT)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 146)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Folio OT"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFolioOT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(77, 98)
        Me.Panel2.TabIndex = 2
        '
        'grdFolioOT
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioOT.DisplayLayout.Appearance = Appearance1
        Me.grdFolioOT.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFolioOT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFolioOT.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFolioOT.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFolioOT.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFolioOT.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFolioOT.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFolioOT.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFolioOT.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdFolioOT.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFolioOT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFolioOT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolioOT.Location = New System.Drawing.Point(0, 0)
        Me.grdFolioOT.Name = "grdFolioOT"
        Me.grdFolioOT.Size = New System.Drawing.Size(77, 98)
        Me.grdFolioOT.TabIndex = 1
        '
        'txtFolioOT
        '
        Me.txtFolioOT.Location = New System.Drawing.Point(6, 14)
        Me.txtFolioOT.Mask = "99999999999999999"
        Me.txtFolioOT.Name = "txtFolioOT"
        Me.txtFolioOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFolioOT.Size = New System.Drawing.Size(71, 20)
        Me.txtFolioOT.TabIndex = 0
        Me.txtFolioOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxTiendas
        '
        Me.gboxTiendas.Controls.Add(Me.btnLimpiarFiltroTienda)
        Me.gboxTiendas.Controls.Add(Me.btnAgregarFiltroTienda)
        Me.gboxTiendas.Controls.Add(Me.Panel8)
        Me.gboxTiendas.Location = New System.Drawing.Point(750, 37)
        Me.gboxTiendas.Name = "gboxTiendas"
        Me.gboxTiendas.Size = New System.Drawing.Size(200, 146)
        Me.gboxTiendas.TabIndex = 95
        Me.gboxTiendas.TabStop = False
        Me.gboxTiendas.Text = "Tiendas / Embarques / CEDIS"
        '
        'btnLimpiarFiltroTienda
        '
        Me.btnLimpiarFiltroTienda.Image = CType(resources.GetObject("btnLimpiarFiltroTienda.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroTienda.Location = New System.Drawing.Point(146, 12)
        Me.btnLimpiarFiltroTienda.Name = "btnLimpiarFiltroTienda"
        Me.btnLimpiarFiltroTienda.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroTienda.TabIndex = 5
        Me.btnLimpiarFiltroTienda.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroTienda
        '
        Me.btnAgregarFiltroTienda.Image = CType(resources.GetObject("btnAgregarFiltroTienda.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroTienda.Location = New System.Drawing.Point(172, 12)
        Me.btnAgregarFiltroTienda.Name = "btnAgregarFiltroTienda"
        Me.btnAgregarFiltroTienda.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroTienda.TabIndex = 4
        Me.btnAgregarFiltroTienda.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdTienda)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 45)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(194, 98)
        Me.Panel8.TabIndex = 2
        '
        'grdTienda
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTienda.DisplayLayout.Appearance = Appearance3
        Me.grdTienda.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTienda.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTienda.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTienda.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTienda.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTienda.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTienda.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTienda.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTienda.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdTienda.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTienda.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTienda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTienda.Location = New System.Drawing.Point(0, 0)
        Me.grdTienda.Name = "grdTienda"
        Me.grdTienda.Size = New System.Drawing.Size(194, 98)
        Me.grdTienda.TabIndex = 1
        '
        'gboxCliente
        '
        Me.gboxCliente.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.btnAgregarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.Panel7)
        Me.gboxCliente.Location = New System.Drawing.Point(500, 37)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(244, 146)
        Me.gboxCliente.TabIndex = 67
        Me.gboxCliente.TabStop = False
        Me.gboxCliente.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(188, 12)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 4
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroCliente
        '
        Me.btnAgregarFiltroCliente.Image = CType(resources.GetObject("btnAgregarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroCliente.Location = New System.Drawing.Point(213, 12)
        Me.btnAgregarFiltroCliente.Name = "btnAgregarFiltroCliente"
        Me.btnAgregarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroCliente.TabIndex = 3
        Me.btnAgregarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 45)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(238, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdCliente
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance5
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(238, 98)
        Me.grdCliente.TabIndex = 2
        '
        'gboxSICY
        '
        Me.gboxSICY.Controls.Add(Me.Panel25)
        Me.gboxSICY.Controls.Add(Me.txtPedidoSICY)
        Me.gboxSICY.Location = New System.Drawing.Point(325, 37)
        Me.gboxSICY.Name = "gboxSICY"
        Me.gboxSICY.Size = New System.Drawing.Size(83, 149)
        Me.gboxSICY.TabIndex = 55
        Me.gboxSICY.TabStop = False
        Me.gboxSICY.Text = "Pedido SICY"
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.grdPedidoSICY)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(3, 48)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(77, 98)
        Me.Panel25.TabIndex = 2
        '
        'grdPedidoSICY
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSICY.DisplayLayout.Appearance = Appearance7
        Me.grdPedidoSICY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPedidoSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidoSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPedidoSICY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidoSICY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSICY.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdPedidoSICY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidoSICY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidoSICY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidoSICY.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidoSICY.Name = "grdPedidoSICY"
        Me.grdPedidoSICY.Size = New System.Drawing.Size(77, 98)
        Me.grdPedidoSICY.TabIndex = 1
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(6, 14)
        Me.txtPedidoSICY.Mask = "99999999999999999"
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSICY.Size = New System.Drawing.Size(71, 20)
        Me.txtPedidoSICY.TabIndex = 0
        Me.txtPedidoSICY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxPedidosSAY
        '
        Me.gboxPedidosSAY.Controls.Add(Me.Panel5)
        Me.gboxPedidosSAY.Controls.Add(Me.txtPedidoSAY)
        Me.gboxPedidosSAY.Location = New System.Drawing.Point(239, 37)
        Me.gboxPedidosSAY.Name = "gboxPedidosSAY"
        Me.gboxPedidosSAY.Size = New System.Drawing.Size(79, 149)
        Me.gboxPedidosSAY.TabIndex = 54
        Me.gboxPedidosSAY.TabStop = False
        Me.gboxPedidosSAY.Text = "Pedido SAY"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdPedidoSAY)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(73, 98)
        Me.Panel5.TabIndex = 2
        '
        'grdPedidoSAY
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Appearance = Appearance9
        Me.grdPedidoSAY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPedidoSAY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidoSAY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPedidoSAY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidoSAY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdPedidoSAY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidoSAY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidoSAY.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidoSAY.Name = "grdPedidoSAY"
        Me.grdPedidoSAY.Size = New System.Drawing.Size(73, 98)
        Me.grdPedidoSAY.TabIndex = 1
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(6, 14)
        Me.txtPedidoSAY.Mask = "99999999999999999"
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSAY.Size = New System.Drawing.Size(64, 20)
        Me.txtPedidoSAY.TabIndex = 0
        Me.txtPedidoSAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1284, 27)
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
        Me.btnArriba.Location = New System.Drawing.Point(1224, 3)
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
        Me.btnAbajo.Location = New System.Drawing.Point(1250, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.btnCancelarRefacturacion)
        Me.pnlVentas.Controls.Add(Me.lblTextoCancelarRefacturacion)
        Me.pnlVentas.Controls.Add(Me.btnExportarExcel)
        Me.pnlVentas.Controls.Add(Me.Label17)
        Me.pnlVentas.Controls.Add(Me.btnRechazar)
        Me.pnlVentas.Controls.Add(Me.Label2)
        Me.pnlVentas.Controls.Add(Me.btnDocumentoDinamico)
        Me.pnlVentas.Controls.Add(Me.btnDocumentar)
        Me.pnlVentas.Controls.Add(Me.lblTextoAutorizar)
        Me.pnlVentas.Controls.Add(Me.lblExportar)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 3)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(732, 62)
        Me.pnlVentas.TabIndex = 108
        '
        'btnCancelarRefacturacion
        '
        Me.btnCancelarRefacturacion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarRefacturacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarRefacturacion.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarRefacturacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarRefacturacion.Location = New System.Drawing.Point(269, 6)
        Me.btnCancelarRefacturacion.Name = "btnCancelarRefacturacion"
        Me.btnCancelarRefacturacion.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarRefacturacion.TabIndex = 117
        Me.btnCancelarRefacturacion.UseVisualStyleBackColor = True
        '
        'lblTextoCancelarRefacturacion
        '
        Me.lblTextoCancelarRefacturacion.AutoSize = True
        Me.lblTextoCancelarRefacturacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelarRefacturacion.Location = New System.Drawing.Point(249, 38)
        Me.lblTextoCancelarRefacturacion.Name = "lblTextoCancelarRefacturacion"
        Me.lblTextoCancelarRefacturacion.Size = New System.Drawing.Size(74, 26)
        Me.lblTextoCancelarRefacturacion.TabIndex = 116
        Me.lblTextoCancelarRefacturacion.Text = "Cancelar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Refacturación"
        Me.lblTextoCancelarRefacturacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(198, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 115
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(193, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 114
        Me.Label17.Text = "Exportar"
        '
        'btnRechazar
        '
        Me.btnRechazar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRechazar.Image = Global.Ventas.Vista.My.Resources.Resources.rechazar_32
        Me.btnRechazar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRechazar.Location = New System.Drawing.Point(146, 6)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 108
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(136, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Rechazar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDocumentoDinamico
        '
        Me.btnDocumentoDinamico.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDocumentoDinamico.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDocumentoDinamico.Image = Global.Ventas.Vista.My.Resources.Resources.nuevo_321
        Me.btnDocumentoDinamico.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDocumentoDinamico.Location = New System.Drawing.Point(84, 6)
        Me.btnDocumentoDinamico.Name = "btnDocumentoDinamico"
        Me.btnDocumentoDinamico.Size = New System.Drawing.Size(32, 32)
        Me.btnDocumentoDinamico.TabIndex = 106
        Me.btnDocumentoDinamico.UseVisualStyleBackColor = True
        '
        'btnDocumentar
        '
        Me.btnDocumentar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDocumentar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDocumentar.Image = Global.Ventas.Vista.My.Resources.Resources.listaPrecios
        Me.btnDocumentar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDocumentar.Location = New System.Drawing.Point(19, 6)
        Me.btnDocumentar.Name = "btnDocumentar"
        Me.btnDocumentar.Size = New System.Drawing.Size(32, 32)
        Me.btnDocumentar.TabIndex = 105
        Me.btnDocumentar.UseVisualStyleBackColor = True
        '
        'lblTextoAutorizar
        '
        Me.lblTextoAutorizar.AutoSize = True
        Me.lblTextoAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoAutorizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoAutorizar.Location = New System.Drawing.Point(3, 37)
        Me.lblTextoAutorizar.Name = "lblTextoAutorizar"
        Me.lblTextoAutorizar.Size = New System.Drawing.Size(65, 13)
        Me.lblTextoAutorizar.TabIndex = 83
        Me.lblTextoAutorizar.Text = "Documentar"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(69, 37)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(62, 26)
        Me.lblExportar.TabIndex = 75
        Me.lblExportar.Text = "Documento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dinámico"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(711, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(215, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(272, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de OT por facturar"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(490, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'CMS_CambiarDoc
        '
        Me.CMS_CambiarDoc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FToolStripMenuItem})
        Me.CMS_CambiarDoc.Name = "CMS_CambiarDoc"
        Me.CMS_CambiarDoc.Size = New System.Drawing.Size(81, 26)
        '
        'FToolStripMenuItem
        '
        Me.FToolStripMenuItem.Name = "FToolStripMenuItem"
        Me.FToolStripMenuItem.Size = New System.Drawing.Size(80, 22)
        Me.FToolStripMenuItem.Text = "F"
        '
        'AdministradorOT_Form_Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministradorOT_Form_Facturacion"
        Me.Text = "Administrador de OT por facturar"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdOts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvOts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFolioOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxTiendas.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdTienda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCliente.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSICY.ResumeLayout(False)
        Me.gboxSICY.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.grdPedidoSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPedidosSAY.ResumeLayout(False)
        Me.gboxPedidosSAY.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlVentas.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_CambiarDoc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlVentas As System.Windows.Forms.Panel
    Friend WithEvents lblTextoAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents btnDocumentar As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoDinamico As System.Windows.Forms.Button
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFecha As System.Windows.Forms.CheckBox
    Friend WithEvents rdoEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents rdoConfirmacion As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaDel As System.Windows.Forms.Label
    Friend WithEvents rdoFacturacion As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaAl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdFolioOT As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtFolioOT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gboxTiendas As System.Windows.Forms.GroupBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents grdTienda As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxSICY As System.Windows.Forms.GroupBox
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents grdPedidoSICY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedidoSICY As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gboxPedidosSAY As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtPedidoSAY As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmboxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusEntrega As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusEnRuta As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusPorFacturar As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusFacturada As System.Windows.Forms.Panel
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblNoFacturado As System.Windows.Forms.Label
    Friend WithEvents pnlClienteBloqueado As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdOts As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvOts As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents EstatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Observaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCitaEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarFiltroTienda As System.Windows.Forms.Button
    Friend WithEvents btnAgregarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFiltroTienda As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents grdPedidoSAY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkMostrarAndrea As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlStatusPorRefacturar As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarRefacturacion As System.Windows.Forms.Button
    Friend WithEvents lblTextoCancelarRefacturacion As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlColorFA As Panel
    Friend WithEvents CMS_CambiarDoc As ContextMenuStrip
    Friend WithEvents FToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCEDIS As ComboBox
End Class
