<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_Filtro_Documentos_PorCliente_Form
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
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_Filtro_Documentos_PorCliente_Form))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.grdDocumentos = New DevExpress.XtraGrid.GridControl()
        Me.bgvDocumentos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.gridListadoParametros = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdPedidos = New DevExpress.XtraGrid.GridControl()
        Me.bgvPedidos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkMarcarTodoPedidos = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRemision = New System.Windows.Forms.CheckBox()
        Me.chkFactura = New System.Windows.Forms.CheckBox()
        Me.grdFiltroDocumentos = New DevExpress.XtraGrid.GridControl()
        Me.bgvFiltroDocumentos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.numAnioDocto = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFiltroDocumentos = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCorridas = New System.Windows.Forms.Label()
        Me.lblEtiquetaModelos = New System.Windows.Forms.Label()
        Me.lblModelos = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblColores = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbArticulos = New System.Windows.Forms.ComboBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEtiquetaArticulo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtModeloSAY = New System.Windows.Forms.TextBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEtiquetaModeloSay = New System.Windows.Forms.Label()
        Me.lblEtiquetaColores = New System.Windows.Forms.Label()
        Me.lblEtiquetaCorridas = New System.Windows.Forms.Label()
        Me.chboxMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblNombreRamo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRamos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdFiltroDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvFiltroDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnioDocto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1334, 539)
        Me.pnlContenedor.TabIndex = 4
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.grdDocumentos)
        Me.pnlListaCliente.Controls.Add(Me.gridListadoParametros)
        Me.pnlListaCliente.Controls.Add(Me.grbRamos)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1334, 480)
        Me.pnlListaCliente.TabIndex = 3
        '
        'grdDocumentos
        '
        Me.grdDocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdDocumentos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdDocumentos.Location = New System.Drawing.Point(0, 216)
        Me.grdDocumentos.MainView = Me.bgvDocumentos
        Me.grdDocumentos.Name = "grdDocumentos"
        Me.grdDocumentos.Size = New System.Drawing.Size(1334, 193)
        Me.grdDocumentos.TabIndex = 74
        Me.grdDocumentos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDocumentos, Me.grdDetallesOT, Me.GridView6})
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
        Me.bgvDocumentos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
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
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView6.GridControl = Me.grdDocumentos
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView6.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView6.OptionsSelection.MultiSelect = True
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.ShowAutoFilterRow = True
        Me.GridView6.OptionsView.ShowFooter = True
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
        'gridListadoParametros
        '
        Me.gridListadoParametros.AllowDrop = True
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListadoParametros.DisplayLayout.Appearance = Appearance1
        Me.gridListadoParametros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListadoParametros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListadoParametros.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListadoParametros.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListadoParametros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListadoParametros.Location = New System.Drawing.Point(0, 279)
        Me.gridListadoParametros.Name = "gridListadoParametros"
        Me.gridListadoParametros.Size = New System.Drawing.Size(1334, 130)
        Me.gridListadoParametros.TabIndex = 73
        '
        'grbRamos
        '
        Me.grbRamos.Controls.Add(Me.GroupBox3)
        Me.grbRamos.Controls.Add(Me.GroupBox2)
        Me.grbRamos.Controls.Add(Me.GroupBox1)
        Me.grbRamos.Controls.Add(Me.chboxMarcarTodo)
        Me.grbRamos.Controls.Add(Me.lblNombreCliente)
        Me.grbRamos.Controls.Add(Me.lblNombreRamo)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.Location = New System.Drawing.Point(0, 0)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(1334, 216)
        Me.grbRamos.TabIndex = 69
        Me.grbRamos.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdPedidos)
        Me.GroupBox3.Controls.Add(Me.chkMarcarTodoPedidos)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 160)
        Me.GroupBox3.TabIndex = 223
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pedidos"
        '
        'grdPedidos
        '
        Me.grdPedidos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdPedidos.Location = New System.Drawing.Point(3, 38)
        Me.grdPedidos.MainView = Me.bgvPedidos
        Me.grdPedidos.Name = "grdPedidos"
        Me.grdPedidos.Size = New System.Drawing.Size(301, 119)
        Me.grdPedidos.TabIndex = 214
        Me.grdPedidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvPedidos})
        '
        'bgvPedidos
        '
        Me.bgvPedidos.GridControl = Me.grdPedidos
        Me.bgvPedidos.Name = "bgvPedidos"
        Me.bgvPedidos.OptionsView.ShowGroupPanel = False
        '
        'chkMarcarTodoPedidos
        '
        Me.chkMarcarTodoPedidos.AutoSize = True
        Me.chkMarcarTodoPedidos.Location = New System.Drawing.Point(6, 16)
        Me.chkMarcarTodoPedidos.Name = "chkMarcarTodoPedidos"
        Me.chkMarcarTodoPedidos.Size = New System.Drawing.Size(106, 17)
        Me.chkMarcarTodoPedidos.TabIndex = 213
        Me.chkMarcarTodoPedidos.Text = "Seleccionar todo"
        Me.chkMarcarTodoPedidos.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRemision)
        Me.GroupBox2.Controls.Add(Me.chkFactura)
        Me.GroupBox2.Controls.Add(Me.grdFiltroDocumentos)
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.GroupBox2.Controls.Add(Me.numAnioDocto)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.txtFiltroDocumentos)
        Me.GroupBox2.Location = New System.Drawing.Point(325, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 160)
        Me.GroupBox2.TabIndex = 222
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'chkRemision
        '
        Me.chkRemision.AutoSize = True
        Me.chkRemision.Location = New System.Drawing.Point(119, 40)
        Me.chkRemision.Name = "chkRemision"
        Me.chkRemision.Size = New System.Drawing.Size(69, 17)
        Me.chkRemision.TabIndex = 217
        Me.chkRemision.Text = "Remisión"
        Me.chkRemision.UseVisualStyleBackColor = True
        '
        'chkFactura
        '
        Me.chkFactura.AutoSize = True
        Me.chkFactura.Location = New System.Drawing.Point(9, 40)
        Me.chkFactura.Name = "chkFactura"
        Me.chkFactura.Size = New System.Drawing.Size(62, 17)
        Me.chkFactura.TabIndex = 216
        Me.chkFactura.Text = "Factura"
        Me.chkFactura.UseVisualStyleBackColor = True
        '
        'grdFiltroDocumentos
        '
        Me.grdFiltroDocumentos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdFiltroDocumentos.Location = New System.Drawing.Point(3, 62)
        Me.grdFiltroDocumentos.MainView = Me.bgvFiltroDocumentos
        Me.grdFiltroDocumentos.Name = "grdFiltroDocumentos"
        Me.grdFiltroDocumentos.Size = New System.Drawing.Size(261, 95)
        Me.grdFiltroDocumentos.TabIndex = 215
        Me.grdFiltroDocumentos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvFiltroDocumentos})
        '
        'bgvFiltroDocumentos
        '
        Me.bgvFiltroDocumentos.GridControl = Me.grdFiltroDocumentos
        Me.bgvFiltroDocumentos.Name = "bgvFiltroDocumentos"
        Me.bgvFiltroDocumentos.OptionsBehavior.Editable = False
        Me.bgvFiltroDocumentos.OptionsView.ShowGroupPanel = False
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(239, 10)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 142
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'numAnioDocto
        '
        Me.numAnioDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAnioDocto.Location = New System.Drawing.Point(119, 15)
        Me.numAnioDocto.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.numAnioDocto.Name = "numAnioDocto"
        Me.numAnioDocto.Size = New System.Drawing.Size(46, 20)
        Me.numAnioDocto.TabIndex = 141
        Me.numAnioDocto.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(92, 19)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(26, 13)
        Me.Label33.TabIndex = 140
        Me.Label33.Text = "Año"
        '
        'txtFiltroDocumentos
        '
        Me.txtFiltroDocumentos.Location = New System.Drawing.Point(9, 14)
        Me.txtFiltroDocumentos.Mask = "99999999999999999"
        Me.txtFiltroDocumentos.Name = "txtFiltroDocumentos"
        Me.txtFiltroDocumentos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFiltroDocumentos.Size = New System.Drawing.Size(71, 20)
        Me.txtFiltroDocumentos.TabIndex = 0
        Me.txtFiltroDocumentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCorridas)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaModelos)
        Me.GroupBox1.Controls.Add(Me.lblModelos)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.lblBúscar)
        Me.GroupBox1.Controls.Add(Me.lblColores)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.cmbArticulos)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaArticulo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtModeloSAY)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaModeloSay)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaColores)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaCorridas)
        Me.GroupBox1.Location = New System.Drawing.Point(598, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 160)
        Me.GroupBox1.TabIndex = 222
        Me.GroupBox1.TabStop = False
        '
        'lblCorridas
        '
        Me.lblCorridas.AutoSize = True
        Me.lblCorridas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorridas.ForeColor = System.Drawing.Color.Black
        Me.lblCorridas.Location = New System.Drawing.Point(75, 43)
        Me.lblCorridas.Name = "lblCorridas"
        Me.lblCorridas.Size = New System.Drawing.Size(10, 13)
        Me.lblCorridas.TabIndex = 221
        Me.lblCorridas.Text = "-"
        '
        'lblEtiquetaModelos
        '
        Me.lblEtiquetaModelos.AutoSize = True
        Me.lblEtiquetaModelos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaModelos.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaModelos.Location = New System.Drawing.Point(6, 16)
        Me.lblEtiquetaModelos.Name = "lblEtiquetaModelos"
        Me.lblEtiquetaModelos.Size = New System.Drawing.Size(61, 13)
        Me.lblEtiquetaModelos.TabIndex = 212
        Me.lblEtiquetaModelos.Text = "Modelos (s)"
        '
        'lblModelos
        '
        Me.lblModelos.AutoSize = True
        Me.lblModelos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelos.ForeColor = System.Drawing.Color.Black
        Me.lblModelos.Location = New System.Drawing.Point(75, 16)
        Me.lblModelos.Name = "lblModelos"
        Me.lblModelos.Size = New System.Drawing.Size(10, 13)
        Me.lblModelos.TabIndex = 220
        Me.lblModelos.Text = "-"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(616, 110)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(612, 144)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblColores
        '
        Me.lblColores.AutoSize = True
        Me.lblColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColores.ForeColor = System.Drawing.Color.Black
        Me.lblColores.Location = New System.Drawing.Point(463, 16)
        Me.lblColores.Name = "lblColores"
        Me.lblColores.Size = New System.Drawing.Size(10, 13)
        Me.lblColores.TabIndex = 219
        Me.lblColores.Text = "-"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(8, 68)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(126, 13)
        Me.Label28.TabIndex = 157
        Me.Label28.Text = "Fecha Documento     Del"
        '
        'cmbArticulos
        '
        Me.cmbArticulos.FormattingEnabled = True
        Me.cmbArticulos.Location = New System.Drawing.Point(78, 122)
        Me.cmbArticulos.Name = "cmbArticulos"
        Me.cmbArticulos.Size = New System.Drawing.Size(526, 21)
        Me.cmbArticulos.TabIndex = 218
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(147, 65)
        Me.dtpFechaInicio.MinDate = New Date(2016, 2, 8, 0, 0, 0, 0)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(116, 20)
        Me.dtpFechaInicio.TabIndex = 158
        Me.dtpFechaInicio.Value = New Date(2018, 1, 1, 0, 0, 0, 0)
        '
        'lblEtiquetaArticulo
        '
        Me.lblEtiquetaArticulo.AutoSize = True
        Me.lblEtiquetaArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaArticulo.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaArticulo.Location = New System.Drawing.Point(6, 125)
        Me.lblEtiquetaArticulo.Name = "lblEtiquetaArticulo"
        Me.lblEtiquetaArticulo.Size = New System.Drawing.Size(44, 13)
        Me.lblEtiquetaArticulo.TabIndex = 217
        Me.lblEtiquetaArticulo.Text = "Artículo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(281, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Al"
        '
        'txtModeloSAY
        '
        Me.txtModeloSAY.Location = New System.Drawing.Point(78, 93)
        Me.txtModeloSAY.Name = "txtModeloSAY"
        Me.txtModeloSAY.Size = New System.Drawing.Size(91, 20)
        Me.txtModeloSAY.TabIndex = 216
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.dtpFechaFin.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(315, 65)
        Me.dtpFechaFin.MinDate = New Date(2016, 2, 8, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(116, 20)
        Me.dtpFechaFin.TabIndex = 160
        Me.dtpFechaFin.Value = New Date(2019, 1, 3, 0, 0, 0, 0)
        '
        'lblEtiquetaModeloSay
        '
        Me.lblEtiquetaModeloSay.AutoSize = True
        Me.lblEtiquetaModeloSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaModeloSay.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaModeloSay.Location = New System.Drawing.Point(6, 96)
        Me.lblEtiquetaModeloSay.Name = "lblEtiquetaModeloSay"
        Me.lblEtiquetaModeloSay.Size = New System.Drawing.Size(66, 13)
        Me.lblEtiquetaModeloSay.TabIndex = 215
        Me.lblEtiquetaModeloSay.Text = "Modelo SAY"
        '
        'lblEtiquetaColores
        '
        Me.lblEtiquetaColores.AutoSize = True
        Me.lblEtiquetaColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaColores.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaColores.Location = New System.Drawing.Point(394, 16)
        Me.lblEtiquetaColores.Name = "lblEtiquetaColores"
        Me.lblEtiquetaColores.Size = New System.Drawing.Size(51, 13)
        Me.lblEtiquetaColores.TabIndex = 213
        Me.lblEtiquetaColores.Text = "Color (es)"
        '
        'lblEtiquetaCorridas
        '
        Me.lblEtiquetaCorridas.AutoSize = True
        Me.lblEtiquetaCorridas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaCorridas.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCorridas.Location = New System.Drawing.Point(6, 43)
        Me.lblEtiquetaCorridas.Name = "lblEtiquetaCorridas"
        Me.lblEtiquetaCorridas.Size = New System.Drawing.Size(54, 13)
        Me.lblEtiquetaCorridas.TabIndex = 214
        Me.lblEtiquetaCorridas.Text = "Corrida (s)"
        '
        'chboxMarcarTodo
        '
        Me.chboxMarcarTodo.AutoSize = True
        Me.chboxMarcarTodo.Enabled = False
        Me.chboxMarcarTodo.Location = New System.Drawing.Point(3, 194)
        Me.chboxMarcarTodo.Name = "chboxMarcarTodo"
        Me.chboxMarcarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxMarcarTodo.TabIndex = 0
        Me.chboxMarcarTodo.Text = "Seleccionar todo"
        Me.chboxMarcarTodo.UseVisualStyleBackColor = True
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(71, 12)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(144, 13)
        Me.lblNombreCliente.TabIndex = 37
        Me.lblNombreCliente.Text = "NOMBRE DEL CLIENTE"
        '
        'lblNombreRamo
        '
        Me.lblNombreRamo.AutoSize = True
        Me.lblNombreRamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreRamo.Location = New System.Drawing.Point(4, 12)
        Me.lblNombreRamo.Name = "lblNombreRamo"
        Me.lblNombreRamo.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreRamo.TabIndex = 7
        Me.lblNombreRamo.Text = "CLIENTE:"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblInfo)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 409)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1334, 71)
        Me.pnlPie.TabIndex = 64
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Black
        Me.lblInfo.Location = New System.Drawing.Point(308, 24)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(354, 13)
        Me.lblInfo.TabIndex = 218
        Me.lblInfo.Text = "No podrá eliminar documentos con detalles relacionados en la devolución"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1190, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(95, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(21, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(63, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Seleccionar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(92, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(36, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(24, 42)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1334, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1334, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1334, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1266, 41)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1063, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(203, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Documentos Por Cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1266, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'DevolucionCliente_Filtro_Documentos_PorCliente_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 539)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "DevolucionCliente_Filtro_Documentos_PorCliente_Form"
        Me.Text = "Documentos Por Cliente"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdFiltroDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvFiltroDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnioDocto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlListaCliente As Panel
    Friend WithEvents gridListadoParametros As Infragistics.Win.UltraWinGrid.UltraGrid
    Protected WithEvents grbRamos As GroupBox
    Friend WithEvents chboxMarcarTodo As CheckBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblBúscar As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblNombreRamo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblEtiquetaArticulo As Label
    Friend WithEvents txtModeloSAY As TextBox
    Friend WithEvents lblEtiquetaModeloSay As Label
    Friend WithEvents lblEtiquetaCorridas As Label
    Friend WithEvents lblEtiquetaColores As Label
    Friend WithEvents lblEtiquetaModelos As Label
    Friend WithEvents cmbArticulos As ComboBox
    Friend WithEvents lblCorridas As Label
    Friend WithEvents lblModelos As Label
    Friend WithEvents lblColores As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents numAnioDocto As NumericUpDown
    Friend WithEvents Label33 As Label
    Friend WithEvents txtFiltroDocumentos As MaskedTextBox
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents chkMarcarTodoPedidos As CheckBox
    Friend WithEvents grdPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvPedidos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdFiltroDocumentos As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvFiltroDocumentos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDocumentos As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDocumentos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents chkRemision As CheckBox
    Friend WithEvents chkFactura As CheckBox
End Class
