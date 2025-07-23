<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_Administrador_BitacoradeMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_Administrador_BitacoradeMovimientos))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblTextoExportar = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimTipoMovimiento = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdTipoMovimiento = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarTipoMovimiento = New System.Windows.Forms.Button()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.btnLimNave = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarNave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoCaptura = New System.Windows.Forms.RadioButton()
        Me.rdoAplicacion = New System.Windows.Forms.RadioButton()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlConteo = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdAdministradorMovimientos = New DevExpress.XtraGrid.GridControl()
        Me.vwAdministradorMovimientos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportar.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlConteo.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdAdministradorMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwAdministradorMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.Panel2)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pnlExportar)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1128, 65)
        Me.pnlTitulo.TabIndex = 170
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnEnviar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(69, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(62, 65)
        Me.Panel2.TabIndex = 166
        '
        'btnEnviar
        '
        Me.btnEnviar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviar.Image = Global.Programacion.Vista.My.Resources.Resources.Enviar
        Me.btnEnviar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviar.Location = New System.Drawing.Point(17, 10)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviar.TabIndex = 115
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(15, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Enviar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pctTitulo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(685, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 65)
        Me.Panel1.TabIndex = 165
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(375, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 65)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 90
        Me.pctTitulo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(61, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(299, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Movimientos PPCP"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.lblTextoExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(69, 65)
        Me.pnlExportar.TabIndex = 120
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(17, 10)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 113
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblTextoExportar
        '
        Me.lblTextoExportar.AutoSize = True
        Me.lblTextoExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportar.Location = New System.Drawing.Point(10, 45)
        Me.lblTextoExportar.Name = "lblTextoExportar"
        Me.lblTextoExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblTextoExportar.TabIndex = 112
        Me.lblTextoExportar.Text = "Exportar"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.pnlBotonesExpander)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 65)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1128, 27)
        Me.Panel6.TabIndex = 171
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1064, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 27)
        Me.pnlBotonesExpander.TabIndex = 1
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.GroupBox2)
        Me.pnlFiltros.Controls.Add(Me.gbProveedor)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 92)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1128, 145)
        Me.pnlFiltros.TabIndex = 172
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimTipoMovimiento)
        Me.GroupBox2.Controls.Add(Me.Panel8)
        Me.GroupBox2.Controls.Add(Me.btnAgregarTipoMovimiento)
        Me.GroupBox2.Location = New System.Drawing.Point(436, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 116)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Movimiento"
        '
        'btnLimTipoMovimiento
        '
        Me.btnLimTipoMovimiento.Image = CType(resources.GetObject("btnLimTipoMovimiento.Image"), System.Drawing.Image)
        Me.btnLimTipoMovimiento.Location = New System.Drawing.Point(173, 7)
        Me.btnLimTipoMovimiento.Name = "btnLimTipoMovimiento"
        Me.btnLimTipoMovimiento.Size = New System.Drawing.Size(22, 22)
        Me.btnLimTipoMovimiento.TabIndex = 10
        Me.btnLimTipoMovimiento.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdTipoMovimiento)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 30)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(223, 83)
        Me.Panel8.TabIndex = 2
        '
        'grdTipoMovimiento
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTipoMovimiento.DisplayLayout.Appearance = Appearance1
        Me.grdTipoMovimiento.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTipoMovimiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTipoMovimiento.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTipoMovimiento.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTipoMovimiento.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTipoMovimiento.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTipoMovimiento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTipoMovimiento.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTipoMovimiento.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdTipoMovimiento.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTipoMovimiento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTipoMovimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTipoMovimiento.Location = New System.Drawing.Point(0, 0)
        Me.grdTipoMovimiento.Name = "grdTipoMovimiento"
        Me.grdTipoMovimiento.Size = New System.Drawing.Size(223, 83)
        Me.grdTipoMovimiento.TabIndex = 6
        '
        'btnAgregarTipoMovimiento
        '
        Me.btnAgregarTipoMovimiento.Image = CType(resources.GetObject("btnAgregarTipoMovimiento.Image"), System.Drawing.Image)
        Me.btnAgregarTipoMovimiento.Location = New System.Drawing.Point(201, 7)
        Me.btnAgregarTipoMovimiento.Name = "btnAgregarTipoMovimiento"
        Me.btnAgregarTipoMovimiento.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarTipoMovimiento.TabIndex = 11
        Me.btnAgregarTipoMovimiento.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnLimNave)
        Me.gbProveedor.Controls.Add(Me.Panel4)
        Me.gbProveedor.Controls.Add(Me.btnAgregarNave)
        Me.gbProveedor.Location = New System.Drawing.Point(188, 15)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(229, 116)
        Me.gbProveedor.TabIndex = 6
        Me.gbProveedor.TabStop = False
        Me.gbProveedor.Text = "Nave Origen"
        '
        'btnLimNave
        '
        Me.btnLimNave.Image = CType(resources.GetObject("btnLimNave.Image"), System.Drawing.Image)
        Me.btnLimNave.Location = New System.Drawing.Point(173, 7)
        Me.btnLimNave.Name = "btnLimNave"
        Me.btnLimNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimNave.TabIndex = 7
        Me.btnLimNave.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdNaves)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(223, 83)
        Me.Panel4.TabIndex = 2
        '
        'grdNaves
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Appearance = Appearance3
        Me.grdNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.Size = New System.Drawing.Size(223, 83)
        Me.grdNaves.TabIndex = 6
        '
        'btnAgregarNave
        '
        Me.btnAgregarNave.Image = CType(resources.GetObject("btnAgregarNave.Image"), System.Drawing.Image)
        Me.btnAgregarNave.Location = New System.Drawing.Point(201, 7)
        Me.btnAgregarNave.Name = "btnAgregarNave"
        Me.btnAgregarNave.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarNave.TabIndex = 8
        Me.btnAgregarNave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoCaptura)
        Me.GroupBox1.Controls.Add(Me.rdoAplicacion)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 115)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'rdoCaptura
        '
        Me.rdoCaptura.AutoSize = True
        Me.rdoCaptura.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoCaptura.Checked = True
        Me.rdoCaptura.Location = New System.Drawing.Point(8, 19)
        Me.rdoCaptura.Name = "rdoCaptura"
        Me.rdoCaptura.Size = New System.Drawing.Size(62, 17)
        Me.rdoCaptura.TabIndex = 2
        Me.rdoCaptura.TabStop = True
        Me.rdoCaptura.Text = "Captura"
        Me.rdoCaptura.UseVisualStyleBackColor = False
        '
        'rdoAplicacion
        '
        Me.rdoAplicacion.AutoSize = True
        Me.rdoAplicacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoAplicacion.Location = New System.Drawing.Point(8, 36)
        Me.rdoAplicacion.Name = "rdoAplicacion"
        Me.rdoAplicacion.Size = New System.Drawing.Size(74, 17)
        Me.rdoAplicacion.TabIndex = 3
        Me.rdoAplicacion.Text = "Aplicación"
        Me.rdoAplicacion.UseVisualStyleBackColor = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(28, 59)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaInicio.TabIndex = 4
        Me.dtpFechaInicio.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(6, 64)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(28, 84)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaFin.TabIndex = 5
        Me.dtpFechaFin.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(6, 86)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(174, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(179, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlConteo)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 438)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1128, 63)
        Me.pnlPie.TabIndex = 173
        '
        'pnlConteo
        '
        Me.pnlConteo.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlConteo.Controls.Add(Me.lblRegistros)
        Me.pnlConteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlConteo.Name = "pnlConteo"
        Me.pnlConteo.Size = New System.Drawing.Size(107, 63)
        Me.pnlConteo.TabIndex = 186
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(11, 8)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 183
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(11, 34)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(808, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(225, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 161
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(227, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(275, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(274, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdAdministradorMovimientos
        '
        Me.grdAdministradorMovimientos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdAdministradorMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAdministradorMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdAdministradorMovimientos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdAdministradorMovimientos.Location = New System.Drawing.Point(0, 237)
        Me.grdAdministradorMovimientos.MainView = Me.vwAdministradorMovimientos
        Me.grdAdministradorMovimientos.Name = "grdAdministradorMovimientos"
        Me.grdAdministradorMovimientos.Size = New System.Drawing.Size(1128, 201)
        Me.grdAdministradorMovimientos.TabIndex = 174
        Me.grdAdministradorMovimientos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwAdministradorMovimientos, Me.GridView3})
        '
        'vwAdministradorMovimientos
        '
        Me.vwAdministradorMovimientos.GridControl = Me.grdAdministradorMovimientos
        Me.vwAdministradorMovimientos.IndicatorWidth = 30
        Me.vwAdministradorMovimientos.Name = "vwAdministradorMovimientos"
        Me.vwAdministradorMovimientos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwAdministradorMovimientos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwAdministradorMovimientos.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwAdministradorMovimientos.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwAdministradorMovimientos.OptionsPrint.AllowMultilineHeaders = True
        Me.vwAdministradorMovimientos.OptionsSelection.MultiSelect = True
        Me.vwAdministradorMovimientos.OptionsView.ColumnAutoWidth = False
        Me.vwAdministradorMovimientos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwAdministradorMovimientos.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwAdministradorMovimientos.OptionsView.ShowAutoFilterRow = True
        Me.vwAdministradorMovimientos.OptionsView.ShowFooter = True
        Me.vwAdministradorMovimientos.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdAdministradorMovimientos
        Me.GridView3.Name = "GridView3"
        '
        'Programacion_Administrador_BitacoradeMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 501)
        Me.Controls.Add(Me.grdAdministradorMovimientos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "Programacion_Administrador_BitacoradeMovimientos"
        Me.Text = "Administrador de Movimientos PPCP"
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlConteo.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdAdministradorMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwAdministradorMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblTextoExportar As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlConteo As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdAdministradorMovimientos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwAdministradorMovimientos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoCaptura As RadioButton
    Friend WithEvents rdoAplicacion As RadioButton
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents gbProveedor As GroupBox
    Friend WithEvents btnLimNave As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarNave As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnLimTipoMovimiento As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdTipoMovimiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarTipoMovimiento As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pctTitulo As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents Panel2 As Panel
End Class
