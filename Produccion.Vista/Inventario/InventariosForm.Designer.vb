<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventariosForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventariosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pnlMovimientos = New System.Windows.Forms.Panel()
        Me.btnMovimientos = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlReporte = New System.Windows.Forms.Panel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDinero = New System.Windows.Forms.Label()
        Me.lblTotalInv = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarClasificacion = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.grdClasificacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnClasificacion = New System.Windows.Forms.Button()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.grdMateriales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        Me.pnlMovimientos.SuspendLayout()
        Me.pnlReporte.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1323, 63)
        Me.pnlEncabezado.TabIndex = 162
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlDetalle)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMovimientos)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlReporte)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlExportar)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(911, 67)
        Me.FlowLayoutPanel1.TabIndex = 2022
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Controls.Add(Me.btnDetalle)
        Me.pnlDetalle.Controls.Add(Me.lblAlta)
        Me.pnlDetalle.Location = New System.Drawing.Point(3, 3)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(60, 54)
        Me.pnlDetalle.TabIndex = 0
        Me.pnlDetalle.Visible = False
        '
        'btnDetalle
        '
        Me.btnDetalle.Image = Global.Produccion.Vista.My.Resources.Resources.details
        Me.btnDetalle.Location = New System.Drawing.Point(14, 0)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnDetalle.TabIndex = 2
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(9, 28)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(40, 26)
        Me.lblAlta.TabIndex = 65
        Me.lblAlta.Text = "Ver" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalle"
        Me.lblAlta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlMovimientos
        '
        Me.pnlMovimientos.Controls.Add(Me.btnMovimientos)
        Me.pnlMovimientos.Controls.Add(Me.lblEditar)
        Me.pnlMovimientos.Location = New System.Drawing.Point(69, 3)
        Me.pnlMovimientos.Name = "pnlMovimientos"
        Me.pnlMovimientos.Size = New System.Drawing.Size(60, 54)
        Me.pnlMovimientos.TabIndex = 1
        Me.pnlMovimientos.Visible = False
        '
        'btnMovimientos
        '
        Me.btnMovimientos.Image = Global.Produccion.Vista.My.Resources.Resources.copiar_32
        Me.btnMovimientos.Location = New System.Drawing.Point(14, 0)
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Size = New System.Drawing.Size(32, 32)
        Me.btnMovimientos.TabIndex = 3
        Me.btnMovimientos.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(-4, 30)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(66, 26)
        Me.lblEditar.TabIndex = 66
        Me.lblEditar.Text = "Realizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Movimientos"
        Me.lblEditar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlReporte
        '
        Me.pnlReporte.Controls.Add(Me.btnReporte)
        Me.pnlReporte.Controls.Add(Me.lblAutorizar)
        Me.pnlReporte.Location = New System.Drawing.Point(135, 3)
        Me.pnlReporte.Name = "pnlReporte"
        Me.pnlReporte.Size = New System.Drawing.Size(73, 64)
        Me.pnlReporte.TabIndex = 3
        Me.pnlReporte.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.Produccion.Vista.My.Resources.Resources.asignar
        Me.btnReporte.Location = New System.Drawing.Point(20, 0)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 72
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(9, 29)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(56, 26)
        Me.lblAutorizar.TabIndex = 73
        Me.lblAutorizar.Text = "Reporte x" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Proveedor"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExcel)
        Me.pnlExportar.Controls.Add(Me.Label1)
        Me.pnlExportar.Location = New System.Drawing.Point(214, 3)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(73, 54)
        Me.pnlExportar.TabIndex = 2
        Me.pnlExportar.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExcel.Location = New System.Drawing.Point(20, 0)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExcel.TabIndex = 1
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(13, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1151, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(98, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Inventarios"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1255, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.Label4)
        Me.pnlInferior.Controls.Add(Me.lblDinero)
        Me.pnlInferior.Controls.Add(Me.lblTotalInv)
        Me.pnlInferior.Controls.Add(Me.Label2)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 521)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1323, 56)
        Me.pnlInferior.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 2034
        Me.Label4.Text = "Total:"
        '
        'lblDinero
        '
        Me.lblDinero.AutoSize = True
        Me.lblDinero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDinero.Location = New System.Drawing.Point(106, 31)
        Me.lblDinero.Name = "lblDinero"
        Me.lblDinero.Size = New System.Drawing.Size(43, 13)
        Me.lblDinero.TabIndex = 2033
        Me.lblDinero.Text = "$ 00.0"
        '
        'lblTotalInv
        '
        Me.lblTotalInv.AutoSize = True
        Me.lblTotalInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalInv.Location = New System.Drawing.Point(106, 11)
        Me.lblTotalInv.Name = "lblTotalInv"
        Me.lblTotalInv.Size = New System.Drawing.Size(32, 13)
        Me.lblTotalInv.TabIndex = 2032
        Me.lblTotalInv.Text = "0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 2031
        Me.Label2.Text = "Inventario Total:"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1269, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1270, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.GroupBox10)
        Me.grbParametros.Controls.Add(Me.UltraGroupBox1)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 63)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1323, 143)
        Me.grbParametros.TabIndex = 164
        Me.grbParametros.TabStop = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.btnLimpiarClasificacion)
        Me.GroupBox10.Controls.Add(Me.Panel12)
        Me.GroupBox10.Controls.Add(Me.btnClasificacion)
        Me.GroupBox10.Location = New System.Drawing.Point(344, 17)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(197, 110)
        Me.GroupBox10.TabIndex = 2034
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Clasificación"
        '
        'btnLimpiarClasificacion
        '
        Me.btnLimpiarClasificacion.Image = CType(resources.GetObject("btnLimpiarClasificacion.Image"), System.Drawing.Image)
        Me.btnLimpiarClasificacion.Location = New System.Drawing.Point(140, 9)
        Me.btnLimpiarClasificacion.Name = "btnLimpiarClasificacion"
        Me.btnLimpiarClasificacion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarClasificacion.TabIndex = 7
        Me.btnLimpiarClasificacion.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.grdClasificacion)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(3, 34)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(191, 73)
        Me.Panel12.TabIndex = 2
        '
        'grdClasificacion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Appearance = Appearance1
        Me.grdClasificacion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClasificacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClasificacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClasificacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClasificacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClasificacion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClasificacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClasificacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClasificacion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClasificacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClasificacion.Location = New System.Drawing.Point(0, 0)
        Me.grdClasificacion.Name = "grdClasificacion"
        Me.grdClasificacion.Size = New System.Drawing.Size(191, 73)
        Me.grdClasificacion.TabIndex = 6
        '
        'btnClasificacion
        '
        Me.btnClasificacion.Image = CType(resources.GetObject("btnClasificacion.Image"), System.Drawing.Image)
        Me.btnClasificacion.Location = New System.Drawing.Point(166, 9)
        Me.btnClasificacion.Name = "btnClasificacion"
        Me.btnClasificacion.Size = New System.Drawing.Size(22, 22)
        Me.btnClasificacion.TabIndex = 8
        Me.btnClasificacion.UseVisualStyleBackColor = True
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmbNave)
        Me.UltraGroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.UltraGroupBox1.Controls.Add(Me.lblA)
        Me.UltraGroupBox1.Controls.Add(Me.lblNave)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 17)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(296, 110)
        Me.UltraGroupBox1.TabIndex = 88
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(61, 24)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(193, 21)
        Me.cmbNave.TabIndex = 4
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(61, 62)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(193, 20)
        Me.dtpFechaInicio.TabIndex = 87
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(14, 68)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(41, 13)
        Me.lblA.TabIndex = 86
        Me.lblA.Text = "*Fecha"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(14, 27)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 69
        Me.lblNave.Text = "*Nave"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.Label3)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label5)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnMostrar)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1218, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(102, 124)
        Me.pnlMinimizarParametros.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(60, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(62, 1)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 181
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(12, 1)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 165
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'grdMateriales
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMateriales.DisplayLayout.Appearance = Appearance3
        Me.grdMateriales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMateriales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMateriales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMateriales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMateriales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMateriales.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdMateriales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMateriales.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.DarkGray
        Me.grdMateriales.DisplayLayout.Override.RowAppearance = Appearance5
        Me.grdMateriales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMateriales.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdMateriales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMateriales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMateriales.Location = New System.Drawing.Point(0, 206)
        Me.grdMateriales.Name = "grdMateriales"
        Me.grdMateriales.Size = New System.Drawing.Size(1323, 315)
        Me.grdMateriales.TabIndex = 165
        '
        'InventariosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 577)
        Me.Controls.Add(Me.grdMateriales)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "InventariosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.pnlMovimientos.ResumeLayout(False)
        Me.pnlMovimientos.PerformLayout()
        Me.pnlReporte.ResumeLayout(False)
        Me.pnlReporte.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblTotalInv As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents btnDetalle As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents pnlMovimientos As System.Windows.Forms.Panel
    Friend WithEvents btnMovimientos As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents pnlReporte As System.Windows.Forms.Panel
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDinero As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents grdMateriales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents btnLimpiarClasificacion As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents grdClasificacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnClasificacion As Button
End Class
