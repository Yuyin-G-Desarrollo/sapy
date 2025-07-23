<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReingresoDevolucionForm
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
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblParesPendientes = New System.Windows.Forms.Label()
        Me.lblTotalParesPendientes = New System.Windows.Forms.Label()
        Me.lblParesIngesados = New System.Windows.Forms.Label()
        Me.lblTotalParesIngresados = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GrdParesPendientes = New DevExpress.XtraGrid.GridControl()
        Me.viewParesPendientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdParesIngresados = New DevExpress.XtraGrid.GridControl()
        Me.viewParesIngresados = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFolioDevolucion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEntrego = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRecibio = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLectura = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTratamiento = New System.Windows.Forms.TextBox()
        Me.lblFechaRegreso = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFechaEstimadaRegreso = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        'Me.CachedConcentradoAltasColaboradores1 = New Nomina.Vista.CachedConcentradoAltasColaboradores()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        CType(Me.GrdParesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewParesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdParesIngresados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewParesIngresados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 65)
        Me.pnlEncabezado.TabIndex = 27
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(731, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(253, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(169, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "ReIngreso de Pares"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(477, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(76, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblParesPendientes)
        Me.pnlPie.Controls.Add(Me.lblTotalParesPendientes)
        Me.pnlPie.Controls.Add(Me.lblParesIngesados)
        Me.pnlPie.Controls.Add(Me.lblTotalParesIngresados)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 628)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1284, 60)
        Me.pnlPie.TabIndex = 30
        '
        'lblParesPendientes
        '
        Me.lblParesPendientes.AutoSize = True
        Me.lblParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPendientes.ForeColor = System.Drawing.Color.Black
        Me.lblParesPendientes.Location = New System.Drawing.Point(185, 8)
        Me.lblParesPendientes.Name = "lblParesPendientes"
        Me.lblParesPendientes.Size = New System.Drawing.Size(131, 16)
        Me.lblParesPendientes.TabIndex = 122
        Me.lblParesPendientes.Text = "Pares Pendientes"
        Me.lblParesPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalParesPendientes
        '
        Me.lblTotalParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesPendientes.ForeColor = System.Drawing.Color.Red
        Me.lblTotalParesPendientes.Location = New System.Drawing.Point(214, 29)
        Me.lblTotalParesPendientes.Name = "lblTotalParesPendientes"
        Me.lblTotalParesPendientes.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalParesPendientes.TabIndex = 121
        Me.lblTotalParesPendientes.Text = "0"
        Me.lblTotalParesPendientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblParesIngesados
        '
        Me.lblParesIngesados.AutoSize = True
        Me.lblParesIngesados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesIngesados.ForeColor = System.Drawing.Color.Black
        Me.lblParesIngesados.Location = New System.Drawing.Point(21, 8)
        Me.lblParesIngesados.Name = "lblParesIngesados"
        Me.lblParesIngesados.Size = New System.Drawing.Size(131, 16)
        Me.lblParesIngesados.TabIndex = 120
        Me.lblParesIngesados.Text = "Pares Ingresados"
        Me.lblParesIngesados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalParesIngresados
        '
        Me.lblTotalParesIngresados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesIngresados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalParesIngresados.Location = New System.Drawing.Point(53, 29)
        Me.lblTotalParesIngresados.Name = "lblTotalParesIngresados"
        Me.lblTotalParesIngresados.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalParesIngresados.TabIndex = 119
        Me.lblTotalParesIngresados.Text = "0"
        Me.lblTotalParesIngresados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.Label7)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1122, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(65, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(62, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Guardar"
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
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.txtLectura)
        Me.pnlParametros.Controls.Add(Me.Label5)
        Me.pnlParametros.Controls.Add(Me.Label10)
        Me.pnlParametros.Controls.Add(Me.txtTratamiento)
        Me.pnlParametros.Controls.Add(Me.lblFechaRegreso)
        Me.pnlParametros.Controls.Add(Me.Label13)
        Me.pnlParametros.Controls.Add(Me.lblFechaEstimadaRegreso)
        Me.pnlParametros.Controls.Add(Me.Label11)
        Me.pnlParametros.Controls.Add(Me.Label4)
        Me.pnlParametros.Controls.Add(Me.Label2)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1284, 169)
        Me.pnlParametros.TabIndex = 31
        '
        'GrdParesPendientes
        '
        Me.GrdParesPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GrdParesPendientes.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GrdParesPendientes.Location = New System.Drawing.Point(0, 0)
        Me.GrdParesPendientes.MainView = Me.viewParesPendientes
        Me.GrdParesPendientes.Name = "GrdParesPendientes"
        Me.GrdParesPendientes.Size = New System.Drawing.Size(659, 394)
        Me.GrdParesPendientes.TabIndex = 33
        Me.GrdParesPendientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewParesPendientes, Me.GridView3, Me.GridView4})
        '
        'viewParesPendientes
        '
        Me.viewParesPendientes.GridControl = Me.GrdParesPendientes
        Me.viewParesPendientes.Name = "viewParesPendientes"
        Me.viewParesPendientes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesPendientes.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesPendientes.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.viewParesPendientes.OptionsPrint.AllowMultilineHeaders = True
        Me.viewParesPendientes.OptionsSelection.MultiSelect = True
        Me.viewParesPendientes.OptionsView.ColumnAutoWidth = False
        Me.viewParesPendientes.OptionsView.ShowAutoFilterRow = True
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView3.GridControl = Me.GrdParesPendientes
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
        'GridView4
        '
        Me.GridView4.GridControl = Me.GrdParesPendientes
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFolioDevolucion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbEntrego)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblRecibio)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 114)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'grdParesIngresados
        '
        Me.grdParesIngresados.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        GridLevelNode3.RelationName = "Level2"
        Me.grdParesIngresados.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2, GridLevelNode3})
        Me.grdParesIngresados.Location = New System.Drawing.Point(0, 0)
        Me.grdParesIngresados.MainView = Me.viewParesIngresados
        Me.grdParesIngresados.Name = "grdParesIngresados"
        Me.grdParesIngresados.Size = New System.Drawing.Size(621, 394)
        Me.grdParesIngresados.TabIndex = 32
        Me.grdParesIngresados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewParesIngresados, Me.GridView1, Me.grdDetallesOT})
        '
        'viewParesIngresados
        '
        Me.viewParesIngresados.GridControl = Me.grdParesIngresados
        Me.viewParesIngresados.Name = "viewParesIngresados"
        Me.viewParesIngresados.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesIngresados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesIngresados.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.viewParesIngresados.OptionsPrint.AllowMultilineHeaders = True
        Me.viewParesIngresados.OptionsSelection.MultiSelect = True
        Me.viewParesIngresados.OptionsView.ColumnAutoWidth = False
        Me.viewParesIngresados.OptionsView.ShowAutoFilterRow = True
        Me.viewParesIngresados.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdParesIngresados
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
        Me.grdDetallesOT.GridControl = Me.grdParesIngresados
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio:"
        '
        'lblFolioDevolucion
        '
        Me.lblFolioDevolucion.AutoSize = True
        Me.lblFolioDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDevolucion.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDevolucion.Location = New System.Drawing.Point(138, 19)
        Me.lblFolioDevolucion.Name = "lblFolioDevolucion"
        Me.lblFolioDevolucion.Size = New System.Drawing.Size(23, 15)
        Me.lblFolioDevolucion.TabIndex = 1
        Me.lblFolioDevolucion.Text = "----"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nave:"
        '
        'cmbEntrego
        '
        Me.cmbEntrego.FormattingEnabled = True
        Me.cmbEntrego.Location = New System.Drawing.Point(138, 79)
        Me.cmbEntrego.Name = "cmbEntrego"
        Me.cmbEntrego.Size = New System.Drawing.Size(284, 21)
        Me.cmbEntrego.TabIndex = 24
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(138, 39)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(23, 15)
        Me.lblNave.TabIndex = 3
        Me.lblNave.Text = "----"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(76, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Recibío"
        '
        'lblRecibio
        '
        Me.lblRecibio.AutoSize = True
        Me.lblRecibio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecibio.ForeColor = System.Drawing.Color.Black
        Me.lblRecibio.Location = New System.Drawing.Point(138, 60)
        Me.lblRecibio.Name = "lblRecibio"
        Me.lblRecibio.Size = New System.Drawing.Size(23, 15)
        Me.lblRecibio.TabIndex = 15
        Me.lblRecibio.Text = "----"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(71, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Entrego:"
        '
        'txtLectura
        '
        Me.txtLectura.Location = New System.Drawing.Point(707, 122)
        Me.txtLectura.Name = "txtLectura"
        Me.txtLectura.Size = New System.Drawing.Size(363, 20)
        Me.txtLectura.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(645, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Lectura"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(645, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 15)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Tratamiento"
        '
        'txtTratamiento
        '
        Me.txtTratamiento.Location = New System.Drawing.Point(648, 55)
        Me.txtTratamiento.Multiline = True
        Me.txtTratamiento.Name = "txtTratamiento"
        Me.txtTratamiento.ReadOnly = True
        Me.txtTratamiento.Size = New System.Drawing.Size(422, 61)
        Me.txtTratamiento.TabIndex = 22
        '
        'lblFechaRegreso
        '
        Me.lblFechaRegreso.AutoSize = True
        Me.lblFechaRegreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRegreso.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRegreso.Location = New System.Drawing.Point(1030, 13)
        Me.lblFechaRegreso.Name = "lblFechaRegreso"
        Me.lblFechaRegreso.Size = New System.Drawing.Size(23, 15)
        Me.lblFechaRegreso.TabIndex = 21
        Me.lblFechaRegreso.Text = "----"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(920, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 15)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Fecha Regreso:"
        '
        'lblFechaEstimadaRegreso
        '
        Me.lblFechaEstimadaRegreso.AutoSize = True
        Me.lblFechaEstimadaRegreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEstimadaRegreso.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEstimadaRegreso.Location = New System.Drawing.Point(818, 13)
        Me.lblFechaEstimadaRegreso.Name = "lblFechaEstimadaRegreso"
        Me.lblFechaEstimadaRegreso.Size = New System.Drawing.Size(23, 15)
        Me.lblFechaEstimadaRegreso.TabIndex = 19
        Me.lblFechaEstimadaRegreso.Text = "----"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(645, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 15)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Fecha Estimada Regreso:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(645, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Pares Pendientes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Pares ingresados"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 234)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1284, 394)
        Me.Panel1.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 394)
        Me.Panel2.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdParesIngresados)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GrdParesPendientes)
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 394)
        Me.SplitContainer1.SplitterDistance = 621
        Me.SplitContainer1.TabIndex = 0
        '
        'ReingresoDevolucionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 688)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(1385, 727)
        Me.MinimumSize = New System.Drawing.Size(1278, 726)
        Me.Name = "ReingresoDevolucionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReIngreso de Pares"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.GrdParesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewParesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdParesIngresados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewParesIngresados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents lblNave As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFolioDevolucion As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GrdParesPendientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewParesPendientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdParesIngresados As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewParesIngresados As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEntrego As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTratamiento As TextBox
    Friend WithEvents lblFechaRegreso As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblFechaEstimadaRegreso As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblRecibio As Label
    Friend WithEvents Label6 As Label
    'Friend WithEvents CachedConcentradoAltasColaboradores1 As Nomina.Vista.CachedConcentradoAltasColaboradores
    Friend WithEvents lblParesPendientes As Label
    Friend WithEvents lblTotalParesPendientes As Label
    Friend WithEvents lblParesIngesados As Label
    Friend WithEvents lblTotalParesIngresados As Label
    Friend WithEvents txtLectura As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
