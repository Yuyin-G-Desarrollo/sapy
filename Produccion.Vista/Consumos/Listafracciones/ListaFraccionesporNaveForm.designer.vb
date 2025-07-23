<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaFraccionesporNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaFraccionesporNaveForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pblAlta = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblNumRegistros = New System.Windows.Forms.Label()
        Me.lblTextoNumRegistros = New System.Windows.Forms.Label()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.gbColeccion = New System.Windows.Forms.GroupBox()
        Me.btnLimColeccion = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnColeccion = New System.Windows.Forms.Button()
        Me.gbMaterial = New System.Windows.Forms.GroupBox()
        Me.btnLimMarca = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.grdMarca = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.grpNaves = New System.Windows.Forms.GroupBox()
        Me.grdNave = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnlimNave = New System.Windows.Forms.Button()
        Me.btnNave = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimEstatus = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdEstatus = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEstatus = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdfraccionespornave = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezado.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pblAlta.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.gbColeccion.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMaterial.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNaves.SuspendLayout()
        CType(Me.grdNave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdEstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.grdfraccionespornave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1278, 71)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2037
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(1230, 71)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 2029
        Me.lblMostrar.Text = "Mostrar"
        Me.lblMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1072, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(173, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Fracciones por Nave"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1324, 62)
        Me.pnlEncabezado.TabIndex = 2024
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pblAlta)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(809, 55)
        Me.FlowLayoutPanel1.TabIndex = 2020
        '
        'pblAlta
        '
        Me.pblAlta.Controls.Add(Me.btnExportar)
        Me.pblAlta.Controls.Add(Me.lblExportar)
        Me.pblAlta.Location = New System.Drawing.Point(3, 3)
        Me.pblAlta.Name = "pblAlta"
        Me.pblAlta.Size = New System.Drawing.Size(71, 54)
        Me.pblAlta.TabIndex = 0
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(19, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 30)
        Me.btnExportar.TabIndex = 239
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(12, 34)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 240
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1256, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 62)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1271, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblNumRegistros)
        Me.pnlInferior.Controls.Add(Me.lblTextoNumRegistros)
        Me.pnlInferior.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.pnlInferior.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 431)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1324, 56)
        Me.pnlInferior.TabIndex = 2025
        '
        'lblNumRegistros
        '
        Me.lblNumRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblNumRegistros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumRegistros.Location = New System.Drawing.Point(12, 25)
        Me.lblNumRegistros.Name = "lblNumRegistros"
        Me.lblNumRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblNumRegistros.TabIndex = 122
        Me.lblNumRegistros.Text = "0"
        Me.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTextoNumRegistros
        '
        Me.lblTextoNumRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTextoNumRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblTextoNumRegistros.Location = New System.Drawing.Point(12, 6)
        Me.lblTextoNumRegistros.Name = "lblTextoNumRegistros"
        Me.lblTextoNumRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblTextoNumRegistros.TabIndex = 121
        Me.lblTextoNumRegistros.Text = "Registros"
        Me.lblTextoNumRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(1124, 16)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 119
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(1124, 36)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 120
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1271, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbColeccion
        '
        Me.gbColeccion.Controls.Add(Me.btnLimColeccion)
        Me.gbColeccion.Controls.Add(Me.Panel7)
        Me.gbColeccion.Controls.Add(Me.btnColeccion)
        Me.gbColeccion.Location = New System.Drawing.Point(501, 31)
        Me.gbColeccion.Name = "gbColeccion"
        Me.gbColeccion.Size = New System.Drawing.Size(308, 126)
        Me.gbColeccion.TabIndex = 2042
        Me.gbColeccion.TabStop = False
        Me.gbColeccion.Text = "Colección"
        '
        'btnLimColeccion
        '
        Me.btnLimColeccion.Image = CType(resources.GetObject("btnLimColeccion.Image"), System.Drawing.Image)
        Me.btnLimColeccion.Location = New System.Drawing.Point(252, 7)
        Me.btnLimColeccion.Name = "btnLimColeccion"
        Me.btnLimColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimColeccion.TabIndex = 5
        Me.btnLimColeccion.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdColeccion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 31)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(302, 92)
        Me.Panel7.TabIndex = 2
        '
        'grdColeccion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Appearance = Appearance1
        Me.grdColeccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColeccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdColeccion.Name = "grdColeccion"
        Me.grdColeccion.Size = New System.Drawing.Size(302, 92)
        Me.grdColeccion.TabIndex = 6
        '
        'btnColeccion
        '
        Me.btnColeccion.Image = CType(resources.GetObject("btnColeccion.Image"), System.Drawing.Image)
        Me.btnColeccion.Location = New System.Drawing.Point(280, 7)
        Me.btnColeccion.Name = "btnColeccion"
        Me.btnColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnColeccion.TabIndex = 0
        Me.btnColeccion.UseVisualStyleBackColor = True
        '
        'gbMaterial
        '
        Me.gbMaterial.Controls.Add(Me.btnLimMarca)
        Me.gbMaterial.Controls.Add(Me.Panel6)
        Me.gbMaterial.Controls.Add(Me.btnMarca)
        Me.gbMaterial.Location = New System.Drawing.Point(247, 31)
        Me.gbMaterial.Name = "gbMaterial"
        Me.gbMaterial.Size = New System.Drawing.Size(229, 126)
        Me.gbMaterial.TabIndex = 2041
        Me.gbMaterial.TabStop = False
        Me.gbMaterial.Text = "Marca"
        '
        'btnLimMarca
        '
        Me.btnLimMarca.Image = CType(resources.GetObject("btnLimMarca.Image"), System.Drawing.Image)
        Me.btnLimMarca.Location = New System.Drawing.Point(173, 7)
        Me.btnLimMarca.Name = "btnLimMarca"
        Me.btnLimMarca.Size = New System.Drawing.Size(22, 22)
        Me.btnLimMarca.TabIndex = 5
        Me.btnLimMarca.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.grdMarca)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 31)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(223, 92)
        Me.Panel6.TabIndex = 2
        '
        'grdMarca
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Appearance = Appearance3
        Me.grdMarca.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdMarca.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarca.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarca.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarca.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarca.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMarca.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMarca.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdMarca.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMarca.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarca.Location = New System.Drawing.Point(0, 0)
        Me.grdMarca.Name = "grdMarca"
        Me.grdMarca.Size = New System.Drawing.Size(223, 92)
        Me.grdMarca.TabIndex = 6
        '
        'btnMarca
        '
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(201, 7)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(22, 22)
        Me.btnMarca.TabIndex = 0
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'grpNaves
        '
        Me.grpNaves.Controls.Add(Me.grdNave)
        Me.grpNaves.Controls.Add(Me.btnlimNave)
        Me.grpNaves.Controls.Add(Me.btnNave)
        Me.grpNaves.Location = New System.Drawing.Point(19, 31)
        Me.grpNaves.Name = "grpNaves"
        Me.grpNaves.Size = New System.Drawing.Size(212, 123)
        Me.grpNaves.TabIndex = 2044
        Me.grpNaves.TabStop = False
        Me.grpNaves.Text = "Naves"
        '
        'grdNave
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNave.DisplayLayout.Appearance = Appearance5
        Me.grdNave.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNave.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNave.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNave.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNave.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNave.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNave.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNave.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNave.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdNave.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNave.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNave.Location = New System.Drawing.Point(6, 31)
        Me.grdNave.Name = "grdNave"
        Me.grdNave.Size = New System.Drawing.Size(200, 85)
        Me.grdNave.TabIndex = 156
        '
        'btnlimNave
        '
        Me.btnlimNave.Image = CType(resources.GetObject("btnlimNave.Image"), System.Drawing.Image)
        Me.btnlimNave.Location = New System.Drawing.Point(156, 9)
        Me.btnlimNave.Name = "btnlimNave"
        Me.btnlimNave.Size = New System.Drawing.Size(22, 22)
        Me.btnlimNave.TabIndex = 155
        Me.btnlimNave.UseVisualStyleBackColor = True
        '
        'btnNave
        '
        Me.btnNave.Image = CType(resources.GetObject("btnNave.Image"), System.Drawing.Image)
        Me.btnNave.Location = New System.Drawing.Point(184, 9)
        Me.btnNave.Name = "btnNave"
        Me.btnNave.Size = New System.Drawing.Size(22, 22)
        Me.btnNave.TabIndex = 154
        Me.btnNave.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(1233, 36)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(33, 32)
        Me.btnMostrar.TabIndex = 2023
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(1281, 36)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(33, 32)
        Me.btnLimpiar.TabIndex = 2036
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimEstatus)
        Me.GroupBox1.Controls.Add(Me.Panel8)
        Me.GroupBox1.Controls.Add(Me.btnEstatus)
        Me.GroupBox1.Location = New System.Drawing.Point(833, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 126)
        Me.GroupBox1.TabIndex = 2047
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estatus"
        '
        'btnLimEstatus
        '
        Me.btnLimEstatus.Image = CType(resources.GetObject("btnLimEstatus.Image"), System.Drawing.Image)
        Me.btnLimEstatus.Location = New System.Drawing.Point(252, 7)
        Me.btnLimEstatus.Name = "btnLimEstatus"
        Me.btnLimEstatus.Size = New System.Drawing.Size(22, 22)
        Me.btnLimEstatus.TabIndex = 5
        Me.btnLimEstatus.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdEstatus)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 31)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(302, 92)
        Me.Panel8.TabIndex = 2
        '
        'grdEstatus
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEstatus.DisplayLayout.Appearance = Appearance7
        Me.grdEstatus.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdEstatus.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEstatus.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEstatus.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEstatus.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEstatus.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdEstatus.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEstatus.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEstatus.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdEstatus.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdEstatus.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEstatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEstatus.Location = New System.Drawing.Point(0, 0)
        Me.grdEstatus.Name = "grdEstatus"
        Me.grdEstatus.Size = New System.Drawing.Size(302, 92)
        Me.grdEstatus.TabIndex = 6
        '
        'btnEstatus
        '
        Me.btnEstatus.Image = CType(resources.GetObject("btnEstatus.Image"), System.Drawing.Image)
        Me.btnEstatus.Location = New System.Drawing.Point(280, 7)
        Me.btnEstatus.Name = "btnEstatus"
        Me.btnEstatus.Size = New System.Drawing.Size(22, 22)
        Me.btnEstatus.TabIndex = 0
        Me.btnEstatus.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlParametros.Controls.Add(Me.grpNaves)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.gbColeccion)
        Me.pnlParametros.Controls.Add(Me.lblMostrar)
        Me.pnlParametros.Controls.Add(Me.gbMaterial)
        Me.pnlParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlParametros.Controls.Add(Me.Panel12)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 62)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1324, 168)
        Me.pnlParametros.TabIndex = 2050
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.btnArriba)
        Me.Panel12.Controls.Add(Me.btnAbajo)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1202, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(122, 168)
        Me.Panel12.TabIndex = 150
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(63, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 186
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(87, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 187
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grdfraccionespornave
        '
        Me.grdfraccionespornave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdfraccionespornave.Location = New System.Drawing.Point(0, 230)
        Me.grdfraccionespornave.MainView = Me.vwReporte
        Me.grdfraccionespornave.Name = "grdfraccionespornave"
        Me.grdfraccionespornave.Size = New System.Drawing.Size(1324, 201)
        Me.grdfraccionespornave.TabIndex = 2051
        Me.grdfraccionespornave.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte})
        '
        'vwReporte
        '
        Me.vwReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporte.GridControl = Me.grdfraccionespornave
        Me.vwReporte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsBehavior.Editable = False
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporte.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'ListaFraccionesporNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1324, 487)
        Me.Controls.Add(Me.grdfraccionespornave)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlInferior)
        Me.Name = "ListaFraccionesporNaveForm"
        Me.Text = "ListaFraccionesporNaveForm"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pblAlta.ResumeLayout(False)
        Me.pblAlta.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.gbColeccion.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMaterial.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNaves.ResumeLayout(False)
        CType(Me.grdNave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdEstatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.grdfraccionespornave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblLimpiar As Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblSalir As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents pnlInferior As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pblAlta As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents gbColeccion As GroupBox
    Friend WithEvents btnLimColeccion As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnColeccion As Button
    Friend WithEvents gbMaterial As GroupBox
    Friend WithEvents btnLimMarca As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents grdMarca As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnMarca As Button
    Friend WithEvents grpNaves As GroupBox
    Friend WithEvents grdNave As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnlimNave As Button
    Friend WithEvents btnNave As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLimEstatus As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdEstatus As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEstatus As Button
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents grdfraccionespornave As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblNumRegistros As Label
    Friend WithEvents lblTextoNumRegistros As Label
    Friend WithEvents lblTextoUltimaActualizacion As Label
    Friend WithEvents lblFechaUltimaActualización As Label
End Class
