<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PorcentajeInspeccionClienteForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdListadoCliente = New DevExpress.XtraGrid.GridControl()
        Me.viewListadoCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdListadoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewListadoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(632, 59)
        Me.pnlEncabezado.TabIndex = 27
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(632, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(632, 59)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(307, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(248, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Porcentaje Inspeccion Cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 517)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(632, 60)
        Me.pnlPie.TabIndex = 29
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
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(470, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
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
        'grdListadoCliente
        '
        Me.grdListadoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdListadoCliente.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdListadoCliente.Location = New System.Drawing.Point(0, 59)
        Me.grdListadoCliente.MainView = Me.viewListadoCliente
        Me.grdListadoCliente.Name = "grdListadoCliente"
        Me.grdListadoCliente.Size = New System.Drawing.Size(632, 458)
        Me.grdListadoCliente.TabIndex = 31
        Me.grdListadoCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewListadoCliente, Me.GridView1, Me.grdDetallesOT})
        '
        'viewListadoCliente
        '
        Me.viewListadoCliente.GridControl = Me.grdListadoCliente
        Me.viewListadoCliente.Name = "viewListadoCliente"
        Me.viewListadoCliente.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewListadoCliente.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewListadoCliente.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.viewListadoCliente.OptionsPrint.AllowMultilineHeaders = True
        Me.viewListadoCliente.OptionsSelection.MultiSelect = True
        Me.viewListadoCliente.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.viewListadoCliente.OptionsView.ColumnAutoWidth = False
        Me.viewListadoCliente.OptionsView.ShowAutoFilterRow = True
        Me.viewListadoCliente.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdListadoCliente
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
        Me.grdDetallesOT.GridControl = Me.grdListadoCliente
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
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(562, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'PorcentajeInspeccionClienteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 577)
        Me.Controls.Add(Me.grdListadoCliente)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "PorcentajeInspeccionClienteForm"
        Me.Text = "PorcentajeInspeccionClienteForm"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdListadoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewListadoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblClientes As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdListadoCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewListadoCliente As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents imgLogo As PictureBox
End Class
