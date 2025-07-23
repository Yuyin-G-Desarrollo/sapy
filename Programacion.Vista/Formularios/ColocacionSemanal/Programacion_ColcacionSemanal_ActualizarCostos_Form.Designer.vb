<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_ColcacionSemanal_ActualizarCostos_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_ColcacionSemanal_ActualizarCostos_Form))
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTituloPantalla = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlde1a15dias = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDescontinuado = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlMayora15dias = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlActualizarPPCP = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnLimCorrida = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.grdCorrida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarCorrida = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnLimColeccion = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarColeccion = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chFiltarCorrida = New System.Windows.Forms.CheckBox()
        Me.cmbNaveOrigen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grdActualizarPPCP = New DevExpress.XtraGrid.GridControl()
        Me.vwActualizarPPCP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlVentas.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.pnlActualizarPPCP.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.grdCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.pnlEncabezadoExpander.SuspendLayout()
        CType(Me.grdActualizarPPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwActualizarPPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVentas
        '
        Me.pnlVentas.BackColor = System.Drawing.Color.White
        Me.pnlVentas.Controls.Add(Me.Panel2)
        Me.pnlVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVentas.Location = New System.Drawing.Point(0, 0)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(853, 59)
        Me.pnlVentas.TabIndex = 3
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbYuyin.Location = New System.Drawing.Point(274, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(77, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTituloPantalla
        '
        Me.lblTituloPantalla.AutoSize = True
        Me.lblTituloPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloPantalla.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloPantalla.Location = New System.Drawing.Point(88, 19)
        Me.lblTituloPantalla.Name = "lblTituloPantalla"
        Me.lblTituloPantalla.Size = New System.Drawing.Size(177, 20)
        Me.lblTituloPantalla.TabIndex = 46
        Me.lblTituloPantalla.Text = "Actualización Costos"
        Me.lblTituloPantalla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.GroupBox12)
        Me.pnlPie.Controls.Add(Me.lblCerrar)
        Me.pnlPie.Controls.Add(Me.lblActualizar)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.btnActualizar)
        Me.pnlPie.Controls.Add(Me.btnCerrar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic)
        Me.pnlPie.Location = New System.Drawing.Point(0, 487)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(853, 65)
        Me.pnlPie.TabIndex = 27
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label1)
        Me.GroupBox12.Controls.Add(Me.pnlde1a15dias)
        Me.GroupBox12.Controls.Add(Me.Label5)
        Me.GroupBox12.Controls.Add(Me.pnlDescontinuado)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.pnlMayora15dias)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox12.Location = New System.Drawing.Point(201, 5)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(439, 54)
        Me.GroupBox12.TabIndex = 123
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Status Artículo (ST)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(220, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Vencimiento entre 1 y 15 días"
        '
        'pnlde1a15dias
        '
        Me.pnlde1a15dias.BackColor = System.Drawing.Color.Yellow
        Me.pnlde1a15dias.ForeColor = System.Drawing.Color.Black
        Me.pnlde1a15dias.Location = New System.Drawing.Point(202, 16)
        Me.pnlde1a15dias.Name = "pnlde1a15dias"
        Me.pnlde1a15dias.Size = New System.Drawing.Size(15, 15)
        Me.pnlde1a15dias.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(24, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Descontinuado"
        '
        'pnlDescontinuado
        '
        Me.pnlDescontinuado.BackColor = System.Drawing.Color.OrangeRed
        Me.pnlDescontinuado.ForeColor = System.Drawing.Color.Black
        Me.pnlDescontinuado.Location = New System.Drawing.Point(6, 37)
        Me.pnlDescontinuado.Name = "pnlDescontinuado"
        Me.pnlDescontinuado.Size = New System.Drawing.Size(15, 15)
        Me.pnlDescontinuado.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(22, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Vencimiento mayor a 15 días"
        '
        'pnlMayora15dias
        '
        Me.pnlMayora15dias.BackColor = System.Drawing.Color.Green
        Me.pnlMayora15dias.ForeColor = System.Drawing.Color.Black
        Me.pnlMayora15dias.Location = New System.Drawing.Point(6, 16)
        Me.pnlMayora15dias.Name = "pnlMayora15dias"
        Me.pnlMayora15dias.Size = New System.Drawing.Size(15, 15)
        Me.pnlMayora15dias.TabIndex = 23
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(797, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActualizar.Location = New System.Drawing.Point(745, 42)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(45, 13)
        Me.lblActualizar.TabIndex = 2
        Me.lblActualizar.Text = "Generar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(21, 35)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 119
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 24)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Registros"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnActualizar
        '
        Me.btnActualizar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnActualizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizar.Location = New System.Drawing.Point(748, 7)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 3
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(797, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(29, 104)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(33, 69)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 59
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlActualizarPPCP
        '
        Me.pnlActualizarPPCP.AutoSize = True
        Me.pnlActualizarPPCP.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlActualizarPPCP.Controls.Add(Me.GroupBox1)
        Me.pnlActualizarPPCP.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActualizarPPCP.Location = New System.Drawing.Point(0, 86)
        Me.pnlActualizarPPCP.Name = "pnlActualizarPPCP"
        Me.pnlActualizarPPCP.Size = New System.Drawing.Size(853, 164)
        Me.pnlActualizarPPCP.TabIndex = 66
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.chboxSeleccionarTodo)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.cmbNaveOrigen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(853, 164)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(15, 128)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxSeleccionarTodo.TabIndex = 1
        Me.chboxSeleccionarTodo.Text = "Seleccionar todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(61, 80)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(221, 21)
        Me.cmbMarca.TabIndex = 185
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = "Marca :"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnLimCorrida)
        Me.GroupBox8.Controls.Add(Me.Panel10)
        Me.GroupBox8.Controls.Add(Me.btnAgregarCorrida)
        Me.GroupBox8.Location = New System.Drawing.Point(510, 28)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(186, 117)
        Me.GroupBox8.TabIndex = 183
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Corrida"
        '
        'btnLimCorrida
        '
        Me.btnLimCorrida.Image = CType(resources.GetObject("btnLimCorrida.Image"), System.Drawing.Image)
        Me.btnLimCorrida.Location = New System.Drawing.Point(128, 7)
        Me.btnLimCorrida.Name = "btnLimCorrida"
        Me.btnLimCorrida.Size = New System.Drawing.Size(22, 22)
        Me.btnLimCorrida.TabIndex = 7
        Me.btnLimCorrida.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.grdCorrida)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(3, 31)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(180, 83)
        Me.Panel10.TabIndex = 2
        '
        'grdCorrida
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCorrida.DisplayLayout.Appearance = Appearance1
        Me.grdCorrida.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCorrida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCorrida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCorrida.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCorrida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCorrida.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCorrida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCorrida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCorrida.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCorrida.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCorrida.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCorrida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCorrida.Location = New System.Drawing.Point(0, 0)
        Me.grdCorrida.Name = "grdCorrida"
        Me.grdCorrida.Size = New System.Drawing.Size(180, 83)
        Me.grdCorrida.TabIndex = 6
        '
        'btnAgregarCorrida
        '
        Me.btnAgregarCorrida.Image = CType(resources.GetObject("btnAgregarCorrida.Image"), System.Drawing.Image)
        Me.btnAgregarCorrida.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarCorrida.Name = "btnAgregarCorrida"
        Me.btnAgregarCorrida.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarCorrida.TabIndex = 8
        Me.btnAgregarCorrida.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnLimColeccion)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Controls.Add(Me.btnAgregarColeccion)
        Me.GroupBox5.Location = New System.Drawing.Point(301, 28)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(188, 117)
        Me.GroupBox5.TabIndex = 182
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Colección"
        '
        'btnLimColeccion
        '
        Me.btnLimColeccion.Image = CType(resources.GetObject("btnLimColeccion.Image"), System.Drawing.Image)
        Me.btnLimColeccion.Location = New System.Drawing.Point(128, 7)
        Me.btnLimColeccion.Name = "btnLimColeccion"
        Me.btnLimColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimColeccion.TabIndex = 7
        Me.btnLimColeccion.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdColeccion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 31)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(182, 83)
        Me.Panel7.TabIndex = 2
        '
        'grdColeccion
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Appearance = Appearance3
        Me.grdColeccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColeccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdColeccion.Name = "grdColeccion"
        Me.grdColeccion.Size = New System.Drawing.Size(182, 83)
        Me.grdColeccion.TabIndex = 6
        '
        'btnAgregarColeccion
        '
        Me.btnAgregarColeccion.Image = CType(resources.GetObject("btnAgregarColeccion.Image"), System.Drawing.Image)
        Me.btnAgregarColeccion.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarColeccion.Name = "btnAgregarColeccion"
        Me.btnAgregarColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarColeccion.TabIndex = 8
        Me.btnAgregarColeccion.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(71, 104)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 181
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackgroundImage = CType(resources.GetObject("btnLimpiar.BackgroundImage"), System.Drawing.Image)
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(74, 69)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 180
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.chFiltarCorrida)
        Me.grbFiltros.Location = New System.Drawing.Point(17, 12)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(122, 51)
        Me.grbFiltros.TabIndex = 179
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chFiltarCorrida
        '
        Me.chFiltarCorrida.AutoSize = True
        Me.chFiltarCorrida.Checked = True
        Me.chFiltarCorrida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chFiltarCorrida.Enabled = False
        Me.chFiltarCorrida.Location = New System.Drawing.Point(6, 21)
        Me.chFiltarCorrida.Name = "chFiltarCorrida"
        Me.chFiltarCorrida.Size = New System.Drawing.Size(102, 17)
        Me.chFiltarCorrida.TabIndex = 4
        Me.chFiltarCorrida.Text = "Filtar por Corrida" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chFiltarCorrida.UseVisualStyleBackColor = True
        '
        'cmbNaveOrigen
        '
        Me.cmbNaveOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaveOrigen.FormattingEnabled = True
        Me.cmbNaveOrigen.Location = New System.Drawing.Point(61, 28)
        Me.cmbNaveOrigen.Name = "cmbNaveOrigen"
        Me.cmbNaveOrigen.Size = New System.Drawing.Size(221, 21)
        Me.cmbNaveOrigen.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Nave:"
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.Panel3)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 59)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(853, 27)
        Me.pnlEncabezadoExpander.TabIndex = 174
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbajo.Location = New System.Drawing.Point(165, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 177
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArriba.Location = New System.Drawing.Point(143, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 176
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'grdActualizarPPCP
        '
        Me.grdActualizarPPCP.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdActualizarPPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdActualizarPPCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode2.RelationName = "Level1"
        Me.grdActualizarPPCP.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdActualizarPPCP.Location = New System.Drawing.Point(0, 250)
        Me.grdActualizarPPCP.MainView = Me.vwActualizarPPCP
        Me.grdActualizarPPCP.Name = "grdActualizarPPCP"
        Me.grdActualizarPPCP.Size = New System.Drawing.Size(853, 237)
        Me.grdActualizarPPCP.TabIndex = 31
        Me.grdActualizarPPCP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwActualizarPPCP, Me.GridView3})
        '
        'vwActualizarPPCP
        '
        Me.vwActualizarPPCP.GridControl = Me.grdActualizarPPCP
        Me.vwActualizarPPCP.IndicatorWidth = 30
        Me.vwActualizarPPCP.Name = "vwActualizarPPCP"
        Me.vwActualizarPPCP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwActualizarPPCP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwActualizarPPCP.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwActualizarPPCP.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwActualizarPPCP.OptionsPrint.AllowMultilineHeaders = True
        Me.vwActualizarPPCP.OptionsSelection.MultiSelect = True
        Me.vwActualizarPPCP.OptionsView.ColumnAutoWidth = False
        Me.vwActualizarPPCP.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwActualizarPPCP.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwActualizarPPCP.OptionsView.ShowAutoFilterRow = True
        Me.vwActualizarPPCP.OptionsView.ShowFooter = True
        Me.vwActualizarPPCP.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdActualizarPPCP
        Me.GridView3.Name = "GridView3"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grbFiltros)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.lblLimpiar)
        Me.Panel1.Controls.Add(Me.lblMostrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(702, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(148, 145)
        Me.Panel1.TabIndex = 186
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pbYuyin)
        Me.Panel2.Controls.Add(Me.lblTituloPantalla)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(502, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(351, 59)
        Me.Panel2.TabIndex = 47
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(653, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 27)
        Me.Panel3.TabIndex = 0
        '
        'Programacion_ColcacionSemanal_ActualizarCostos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(853, 552)
        Me.Controls.Add(Me.grdActualizarPPCP)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlActualizarPPCP)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.pnlVentas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1028, 650)
        Me.MinimumSize = New System.Drawing.Size(750, 591)
        Me.Name = "Programacion_ColcacionSemanal_ActualizarCostos_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos Artículos"
        Me.pnlVentas.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.pnlActualizarPPCP.ResumeLayout(False)
        Me.pnlActualizarPPCP.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.grdCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        CType(Me.grdActualizarPPCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwActualizarPPCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlVentas As Panel
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblTituloPantalla As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents lblActualizar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlActualizarPPCP As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grbFiltros As GroupBox
    Friend WithEvents chFiltarCorrida As CheckBox
    Friend WithEvents cmbNaveOrigen As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents grdActualizar As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnLimColeccion As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarColeccion As Button
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents btnLimCorrida As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents grdCorrida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarCorrida As Button
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlde1a15dias As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDescontinuado As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlMayora15dias As Panel
    Friend WithEvents cmbMarca As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents pnlEncabezadoExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents grdActualizarPPCP As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwActualizarPPCP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
