<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Produccion_Suelas_CargarDatosSuelasEnArticulos_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion_Suelas_CargarDatosSuelasEnArticulos_Form))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnLimpiar2 = New System.Windows.Forms.Button()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.grpParametrosBusqueda = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListaProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gboxMarca = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdMarca = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.gboxColeccion = New System.Windows.Forms.GroupBox()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.grdColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnColeccion = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.UltraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.UltraGridExcelExporter2 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlSalir.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.grpParametrosBusqueda.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gboxMarca.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxColeccion.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.btnCancelar)
        Me.pnlSalir.Controls.Add(Me.lblCancelar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(913, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(233, 60)
        Me.pnlSalir.TabIndex = 12
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(177, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(174, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 11
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(1034, 55)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 38
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(1031, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Mostrar"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(1079, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Limpiar"
        '
        'btnLimpiar2
        '
        Me.btnLimpiar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar2.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar2.Location = New System.Drawing.Point(1082, 55)
        Me.btnLimpiar2.Name = "btnLimpiar2"
        Me.btnLimpiar2.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar2.TabIndex = 40
        Me.btnLimpiar2.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.lblTotalRegistros)
        Me.pnlEstado.Controls.Add(Me.pnlSalir)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 511)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1146, 60)
        Me.pnlEstado.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Registros:"
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(98, 21)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(91, 18)
        Me.lblTotalRegistros.TabIndex = 120
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.grpParametrosBusqueda)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1146, 62)
        Me.pnlHeader.TabIndex = 5
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.Label2)
        Me.pnlOperaciones.Controls.Add(Me.btnExportarExcel)
        Me.pnlOperaciones.Controls.Add(Me.btnEditar)
        Me.pnlOperaciones.Controls.Add(Me.lblEditar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(264, 62)
        Me.pnlOperaciones.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(63, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(66, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 10
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(12, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 3
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(11, 38)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 1
        Me.lblEditar.Text = "Editar"
        '
        'grpParametrosBusqueda
        '
        Me.grpParametrosBusqueda.Controls.Add(Me.pbYuyin)
        Me.grpParametrosBusqueda.Controls.Add(Me.lblTitulo)
        Me.grpParametrosBusqueda.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpParametrosBusqueda.Location = New System.Drawing.Point(946, 0)
        Me.grpParametrosBusqueda.Name = "grpParametrosBusqueda"
        Me.grpParametrosBusqueda.Size = New System.Drawing.Size(200, 62)
        Me.grpParametrosBusqueda.TabIndex = 0
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(132, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 62)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(117, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Carga Suelas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdListaProductos)
        Me.Panel1.Controls.Add(Me.grpParametros)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1146, 449)
        Me.Panel1.TabIndex = 7
        '
        'grdListaProductos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.BorderColor = System.Drawing.Color.DarkGray
        Appearance1.TextVAlignAsString = "Middle"
        Me.grdListaProductos.DisplayLayout.Appearance = Appearance1
        Me.grdListaProductos.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListaProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BorderColor = System.Drawing.Color.AliceBlue
        Me.grdListaProductos.DisplayLayout.Override.HeaderAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance3
        Me.grdListaProductos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaProductos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdListaProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaProductos.Location = New System.Drawing.Point(0, 201)
        Me.grdListaProductos.Name = "grdListaProductos"
        Me.grdListaProductos.Size = New System.Drawing.Size(1146, 248)
        Me.grdListaProductos.TabIndex = 5
        Me.grdListaProductos.Text = "Productos"
        '
        'grpParametros
        '
        Me.grpParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grpParametros.Controls.Add(Me.GroupBox1)
        Me.grpParametros.Controls.Add(Me.Panel6)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 0)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1146, 201)
        Me.grpParametros.TabIndex = 3
        Me.grpParametros.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.gboxMarca)
        Me.GroupBox1.Controls.Add(Me.btnMostrar)
        Me.GroupBox1.Controls.Add(Me.gboxColeccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1134, 150)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        '
        'gboxMarca
        '
        Me.gboxMarca.Controls.Add(Me.Panel2)
        Me.gboxMarca.Controls.Add(Me.btnMarca)
        Me.gboxMarca.Location = New System.Drawing.Point(27, 10)
        Me.gboxMarca.Name = "gboxMarca"
        Me.gboxMarca.Size = New System.Drawing.Size(156, 137)
        Me.gboxMarca.TabIndex = 126
        Me.gboxMarca.TabStop = False
        Me.gboxMarca.Text = "Marca"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdMarca)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 98)
        Me.Panel2.TabIndex = 2
        '
        'grdMarca
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Appearance = Appearance4
        Me.grdMarca.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdMarca.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarca.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarca.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarca.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarca.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMarca.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMarca.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Me.grdMarca.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMarca.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarca.Location = New System.Drawing.Point(0, 0)
        Me.grdMarca.Name = "grdMarca"
        Me.grdMarca.Size = New System.Drawing.Size(150, 98)
        Me.grdMarca.TabIndex = 2
        '
        'btnMarca
        '
        Me.btnMarca.Image = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnMarca.Location = New System.Drawing.Point(132, 11)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(22, 22)
        Me.btnMarca.TabIndex = 0
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'gboxColeccion
        '
        Me.gboxColeccion.Controls.Add(Me.Panel24)
        Me.gboxColeccion.Controls.Add(Me.btnColeccion)
        Me.gboxColeccion.Location = New System.Drawing.Point(201, 10)
        Me.gboxColeccion.Name = "gboxColeccion"
        Me.gboxColeccion.Size = New System.Drawing.Size(355, 137)
        Me.gboxColeccion.TabIndex = 127
        Me.gboxColeccion.TabStop = False
        Me.gboxColeccion.Text = "Colección"
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.grdColeccion)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(3, 36)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(349, 98)
        Me.Panel24.TabIndex = 2
        '
        'grdColeccion
        '
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Appearance = Appearance6
        Me.grdColeccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColeccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance7
        Me.grdColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdColeccion.Name = "grdColeccion"
        Me.grdColeccion.Size = New System.Drawing.Size(349, 98)
        Me.grdColeccion.TabIndex = 2
        '
        'btnColeccion
        '
        Me.btnColeccion.Image = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnColeccion.Location = New System.Drawing.Point(327, 9)
        Me.btnColeccion.Name = "btnColeccion"
        Me.btnColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnColeccion.TabIndex = 0
        Me.btnColeccion.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(3, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1140, 29)
        Me.Panel6.TabIndex = 118
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(12, 6)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 128
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1111, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 59
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1087, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 58
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'Produccion_Suelas_CargarDatosSuelasEnArticulos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 571)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "Produccion_Suelas_CargarDatosSuelasEnArticulos_Form"
        Me.Text = "Artículos"
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.grpParametrosBusqueda.ResumeLayout(False)
        Me.grpParametrosBusqueda.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpParametros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gboxMarca.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxColeccion.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSalir As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpParametros As GroupBox
    Friend WithEvents btnLimpiar2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents grdListaProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpParametrosBusqueda As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents btnEditar As Button
    Friend WithEvents lblEditar As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents gboxColeccion As GroupBox
    Friend WithEvents Panel24 As Panel
    Friend WithEvents grdColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnColeccion As Button
    Friend WithEvents gboxMarca As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdMarca As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnMarca As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents UltraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents UltraGridExcelExporter2 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
