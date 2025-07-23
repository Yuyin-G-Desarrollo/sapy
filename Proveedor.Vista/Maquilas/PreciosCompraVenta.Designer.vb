<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PreciosCompraVenta
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreciosCompraVenta))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlListas = New System.Windows.Forms.Panel()
        Me.grdListaPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.picEstado = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbComercializadora = New System.Windows.Forms.ComboBox()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.btnLimNave = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnNave = New System.Windows.Forms.Button()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListas.SuspendLayout()
        CType(Me.grdListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.gbProveedor.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'GridView3
        '
        Me.GridView3.Name = "GridView3"
        '
        'GridView4
        '
        Me.GridView4.Name = "GridView4"
        '
        'GridView5
        '
        Me.GridView5.Name = "GridView5"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Controls.Add(Me.Button1)
        Me.pnlBotones.Controls.Add(Me.Label4)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(864, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(235, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(191, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(190, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.Button1.Location = New System.Drawing.Point(144, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 70
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(140, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Mostrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 388)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1099, 60)
        Me.pnlPie.TabIndex = 71
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(695, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(404, 65)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(64, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(226, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Precios de Compra y Venta"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.Label18)
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(71, 65)
        Me.pnlExportar.TabIndex = 84
        '
        'btnExportar
        '
        Me.btnExportar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(18, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 82
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label18.Location = New System.Drawing.Point(12, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Exportar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlExportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1099, 65)
        Me.pnlHeader.TabIndex = 72
        '
        'GridView6
        '
        Me.GridView6.Name = "GridView6"
        '
        'GridView7
        '
        Me.GridView7.Name = "GridView7"
        '
        'GridView8
        '
        Me.GridView8.Name = "GridView8"
        '
        'GridView9
        '
        Me.GridView9.Name = "GridView9"
        '
        'pnlListas
        '
        Me.pnlListas.Controls.Add(Me.grdListaPrecios)
        Me.pnlListas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListas.Location = New System.Drawing.Point(0, 232)
        Me.pnlListas.Name = "pnlListas"
        Me.pnlListas.Size = New System.Drawing.Size(1099, 156)
        Me.pnlListas.TabIndex = 74
        '
        'grdListaPrecios
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPrecios.DisplayLayout.Appearance = Appearance1
        Me.grdListaPrecios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaPrecios.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaPrecios.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaPrecios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaPrecios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaPrecios.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListaPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPrecios.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaPrecios.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaPrecios.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaPrecios.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaPrecios.Location = New System.Drawing.Point(0, 0)
        Me.grdListaPrecios.Name = "grdListaPrecios"
        Me.grdListaPrecios.Size = New System.Drawing.Size(1099, 156)
        Me.grdListaPrecios.TabIndex = 70
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(980, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(53, 12)
        Me.lblEstado.TabIndex = 84
        Me.lblEstado.Text = "Enviando..."
        Me.lblEstado.Visible = False
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.BackColor = System.Drawing.Color.White
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(1053, 8)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 34
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.BackColor = System.Drawing.Color.White
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUp.Location = New System.Drawing.Point(1076, 8)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(20, 20)
        Me.btnUp.TabIndex = 35
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'picEstado
        '
        Me.picEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picEstado.BackColor = System.Drawing.Color.Transparent
        Me.picEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEstado.ErrorImage = Nothing
        Me.picEstado.Image = Global.Proveedor.Vista.My.Resources.Resources.loading1
        Me.picEstado.InitialImage = Nothing
        Me.picEstado.Location = New System.Drawing.Point(1032, 12)
        Me.picEstado.Name = "picEstado"
        Me.picEstado.Size = New System.Drawing.Size(15, 16)
        Me.picEstado.TabIndex = 83
        Me.picEstado.TabStop = False
        Me.picEstado.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Comercializadora"
        '
        'cmbComercializadora
        '
        Me.cmbComercializadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComercializadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComercializadora.FormattingEnabled = True
        Me.cmbComercializadora.Location = New System.Drawing.Point(102, 8)
        Me.cmbComercializadora.Name = "cmbComercializadora"
        Me.cmbComercializadora.Size = New System.Drawing.Size(194, 21)
        Me.cmbComercializadora.TabIndex = 86
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.gbProveedor)
        Me.grbParametros.Controls.Add(Me.cmbComercializadora)
        Me.grbParametros.Controls.Add(Me.Label16)
        Me.grbParametros.Controls.Add(Me.picEstado)
        Me.grbParametros.Controls.Add(Me.btnUp)
        Me.grbParametros.Controls.Add(Me.btnDown)
        Me.grbParametros.Controls.Add(Me.lblEstado)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 65)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1099, 167)
        Me.grbParametros.TabIndex = 73
        Me.grbParametros.TabStop = False
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnLimNave)
        Me.gbProveedor.Controls.Add(Me.Panel4)
        Me.gbProveedor.Controls.Add(Me.btnNave)
        Me.gbProveedor.Location = New System.Drawing.Point(15, 46)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(281, 116)
        Me.gbProveedor.TabIndex = 116
        Me.gbProveedor.TabStop = False
        Me.gbProveedor.Text = "Nave"
        '
        'btnLimNave
        '
        Me.btnLimNave.Image = CType(resources.GetObject("btnLimNave.Image"), System.Drawing.Image)
        Me.btnLimNave.Location = New System.Drawing.Point(225, 10)
        Me.btnLimNave.Name = "btnLimNave"
        Me.btnLimNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimNave.TabIndex = 5
        Me.btnLimNave.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdNaves)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 35)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 78)
        Me.Panel4.TabIndex = 2
        '
        'grdNaves
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Appearance = Appearance4
        Me.grdNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Me.grdNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.Size = New System.Drawing.Size(275, 78)
        Me.grdNaves.TabIndex = 6
        '
        'btnNave
        '
        Me.btnNave.Image = CType(resources.GetObject("btnNave.Image"), System.Drawing.Image)
        Me.btnNave.Location = New System.Drawing.Point(253, 10)
        Me.btnNave.Name = "btnNave"
        Me.btnNave.Size = New System.Drawing.Size(22, 22)
        Me.btnNave.TabIndex = 0
        Me.btnNave.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(336, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'PreciosCompraVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 448)
        Me.Controls.Add(Me.pnlListas)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "PreciosCompraVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios de Compra y Venta"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListas.ResumeLayout(False)
        CType(Me.grdListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.gbProveedor.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Public WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlListas As Windows.Forms.Panel
    Friend WithEvents grdListaPrecios As Infragistics.Win.UltraWinGrid.UltraGrid
    Public WithEvents lblEstado As Windows.Forms.Label
    Friend WithEvents btnDown As Windows.Forms.Button
    Friend WithEvents btnUp As Windows.Forms.Button
    Public WithEvents picEstado As Windows.Forms.PictureBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents cmbComercializadora As Windows.Forms.ComboBox
    Friend WithEvents grbParametros As Windows.Forms.GroupBox
    Friend WithEvents gbProveedor As Windows.Forms.GroupBox
    Friend WithEvents btnLimNave As Windows.Forms.Button
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents grdNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnNave As Windows.Forms.Button
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
