<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Proveedor_AdministradorFacturasdeCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Proveedor_AdministradorFacturasdeCompra))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlBitacora = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlEnviarCorreo = New System.Windows.Forms.Panel()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancelarFacturas = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlGenerarPreLoteo = New System.Windows.Forms.Panel()
        Me.btnEnviaFacturas = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblSemanaActual = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.chSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarProveedor = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.grdProveedor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarProveedor = New System.Windows.Forms.Button()
        Me.chFechaPrograma = New System.Windows.Forms.CheckBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.chReporteSemanal = New System.Windows.Forms.CheckBox()
        Me.grpReporte = New System.Windows.Forms.GroupBox()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.gbFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlConteo = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdFacturas = New DevExpress.XtraGrid.GridControl()
        Me.vwFacturas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmsReportes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComprasPorDíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasPorSemanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetallesPorProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasDirectoEIndirectosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.pnlBitacora.SuspendLayout()
        Me.pnlEnviarCorreo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlGenerarPreLoteo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.grdProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.grpReporte.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFecha.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlConteo.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsReportes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.UltraPanel1)
        Me.Panel1.Controls.Add(Me.pnlBitacora)
        Me.Panel1.Controls.Add(Me.pnlEnviarCorreo)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pnlGenerarPreLoteo)
        Me.Panel1.Controls.Add(Me.pctTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 76)
        Me.Panel1.TabIndex = 166
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblTitulo)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraPanel1.Location = New System.Drawing.Point(741, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(367, 76)
        Me.UltraPanel1.TabIndex = 177
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(39, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(322, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Facturas de Compras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBitacora
        '
        Me.pnlBitacora.Controls.Add(Me.btnExportar)
        Me.pnlBitacora.Controls.Add(Me.Label6)
        Me.pnlBitacora.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBitacora.Location = New System.Drawing.Point(289, 0)
        Me.pnlBitacora.Name = "pnlBitacora"
        Me.pnlBitacora.Size = New System.Drawing.Size(94, 76)
        Me.pnlBitacora.TabIndex = 176
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(27, 12)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(20, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Exportar"
        '
        'pnlEnviarCorreo
        '
        Me.pnlEnviarCorreo.Controls.Add(Me.btnReportes)
        Me.pnlEnviarCorreo.Controls.Add(Me.Label2)
        Me.pnlEnviarCorreo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnviarCorreo.Location = New System.Drawing.Point(195, 0)
        Me.pnlEnviarCorreo.Name = "pnlEnviarCorreo"
        Me.pnlEnviarCorreo.Size = New System.Drawing.Size(94, 76)
        Me.pnlEnviarCorreo.TabIndex = 175
        '
        'btnReportes
        '
        Me.btnReportes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReportes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReportes.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnReportes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReportes.Location = New System.Drawing.Point(30, 12)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(32, 32)
        Me.btnReportes.TabIndex = 5
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(18, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = " Reportes"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancelarFacturas)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(101, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(94, 76)
        Me.Panel2.TabIndex = 174
        '
        'btnCancelarFacturas
        '
        Me.btnCancelarFacturas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarFacturas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarFacturas.Image = Global.Produccion.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarFacturas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarFacturas.Location = New System.Drawing.Point(33, 12)
        Me.btnCancelarFacturas.Name = "btnCancelarFacturas"
        Me.btnCancelarFacturas.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarFacturas.TabIndex = 6
        Me.btnCancelarFacturas.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(29, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 26)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Cancelar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Facturas"
        '
        'pnlGenerarPreLoteo
        '
        Me.pnlGenerarPreLoteo.Controls.Add(Me.btnEnviaFacturas)
        Me.pnlGenerarPreLoteo.Controls.Add(Me.Label9)
        Me.pnlGenerarPreLoteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarPreLoteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlGenerarPreLoteo.Name = "pnlGenerarPreLoteo"
        Me.pnlGenerarPreLoteo.Size = New System.Drawing.Size(101, 76)
        Me.pnlGenerarPreLoteo.TabIndex = 173
        '
        'btnEnviaFacturas
        '
        Me.btnEnviaFacturas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviaFacturas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviaFacturas.Image = Global.Produccion.Vista.My.Resources.Resources.copiar_32
        Me.btnEnviaFacturas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviaFacturas.Location = New System.Drawing.Point(33, 12)
        Me.btnEnviaFacturas.Name = "btnEnviaFacturas"
        Me.btnEnviaFacturas.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviaFacturas.TabIndex = 6
        Me.btnEnviaFacturas.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(29, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 26)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = " Enviar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Facturas"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(1108, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 76)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 90
        Me.pctTitulo.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.lblSemanaActual)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.pnlBotonesExpander)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 76)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1176, 27)
        Me.Panel6.TabIndex = 174
        '
        'lblSemanaActual
        '
        Me.lblSemanaActual.AutoSize = True
        Me.lblSemanaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanaActual.Location = New System.Drawing.Point(100, 6)
        Me.lblSemanaActual.Name = "lblSemanaActual"
        Me.lblSemanaActual.Size = New System.Drawing.Size(0, 15)
        Me.lblSemanaActual.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Semana Actual:"
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1108, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(68, 27)
        Me.pnlBotonesExpander.TabIndex = 1
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Produccion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Produccion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.chSeleccionarTodo)
        Me.pnlFiltros.Controls.Add(Me.GroupBox10)
        Me.pnlFiltros.Controls.Add(Me.chFechaPrograma)
        Me.pnlFiltros.Controls.Add(Me.UltraGroupBox3)
        Me.pnlFiltros.Controls.Add(Me.chReporteSemanal)
        Me.pnlFiltros.Controls.Add(Me.grpReporte)
        Me.pnlFiltros.Controls.Add(Me.gbFecha)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 103)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1176, 188)
        Me.pnlFiltros.TabIndex = 175
        '
        'chSeleccionarTodo
        '
        Me.chSeleccionarTodo.AutoSize = True
        Me.chSeleccionarTodo.Location = New System.Drawing.Point(13, 164)
        Me.chSeleccionarTodo.Name = "chSeleccionarTodo"
        Me.chSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chSeleccionarTodo.TabIndex = 2047
        Me.chSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.btnLimpiarProveedor)
        Me.GroupBox10.Controls.Add(Me.Panel12)
        Me.GroupBox10.Controls.Add(Me.btnAgregarProveedor)
        Me.GroupBox10.Location = New System.Drawing.Point(447, 14)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(292, 143)
        Me.GroupBox10.TabIndex = 2046
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Proveedor"
        '
        'btnLimpiarProveedor
        '
        Me.btnLimpiarProveedor.Image = CType(resources.GetObject("btnLimpiarProveedor.Image"), System.Drawing.Image)
        Me.btnLimpiarProveedor.Location = New System.Drawing.Point(232, 11)
        Me.btnLimpiarProveedor.Name = "btnLimpiarProveedor"
        Me.btnLimpiarProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarProveedor.TabIndex = 7
        Me.btnLimpiarProveedor.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.grdProveedor)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(3, 39)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(286, 101)
        Me.Panel12.TabIndex = 2
        '
        'grdProveedor
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedor.DisplayLayout.Appearance = Appearance1
        Me.grdProveedor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdProveedor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProveedor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProveedor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProveedor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProveedor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdProveedor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProveedor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedor.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProveedor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProveedor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProveedor.Location = New System.Drawing.Point(0, 0)
        Me.grdProveedor.Name = "grdProveedor"
        Me.grdProveedor.Size = New System.Drawing.Size(286, 101)
        Me.grdProveedor.TabIndex = 6
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = CType(resources.GetObject("btnAgregarProveedor.Image"), System.Drawing.Image)
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(258, 11)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarProveedor.TabIndex = 8
        Me.btnAgregarProveedor.UseVisualStyleBackColor = True
        '
        'chFechaPrograma
        '
        Me.chFechaPrograma.AutoSize = True
        Me.chFechaPrograma.Location = New System.Drawing.Point(13, 68)
        Me.chFechaPrograma.Name = "chFechaPrograma"
        Me.chFechaPrograma.Size = New System.Drawing.Size(104, 17)
        Me.chFechaPrograma.TabIndex = 2045
        Me.chFechaPrograma.Text = "Fecha Programa"
        Me.chFechaPrograma.UseVisualStyleBackColor = True
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.cmbNave)
        Me.UltraGroupBox3.Controls.Add(Me.lblNave)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 14)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(417, 44)
        Me.UltraGroupBox3.TabIndex = 2044
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(55, 13)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(279, 21)
        Me.cmbNave.TabIndex = 126
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 16)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 127
        Me.lblNave.Text = "*Nave"
        '
        'chReporteSemanal
        '
        Me.chReporteSemanal.AutoSize = True
        Me.chReporteSemanal.Location = New System.Drawing.Point(229, 68)
        Me.chReporteSemanal.Name = "chReporteSemanal"
        Me.chReporteSemanal.Size = New System.Drawing.Size(104, 17)
        Me.chReporteSemanal.TabIndex = 2043
        Me.chReporteSemanal.Text = "Semana Compra"
        Me.chReporteSemanal.UseVisualStyleBackColor = True
        '
        'grpReporte
        '
        Me.grpReporte.Controls.Add(Me.nudAño)
        Me.grpReporte.Controls.Add(Me.nudSemanaInicio)
        Me.grpReporte.Enabled = False
        Me.grpReporte.Location = New System.Drawing.Point(229, 80)
        Me.grpReporte.Name = "grpReporte"
        Me.grpReporte.Size = New System.Drawing.Size(200, 78)
        Me.grpReporte.TabIndex = 2042
        Me.grpReporte.TabStop = False
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(93, 28)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(61, 20)
        Me.nudAño.TabIndex = 2032
        Me.nudAño.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(37, 28)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaInicio.TabIndex = 2034
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gbFecha
        '
        Me.gbFecha.Controls.Add(Me.dtpFechaFin)
        Me.gbFecha.Controls.Add(Me.Label1)
        Me.gbFecha.Controls.Add(Me.Label5)
        Me.gbFecha.Controls.Add(Me.dtpFechaInicio)
        Me.gbFecha.Enabled = False
        Me.gbFecha.Location = New System.Drawing.Point(11, 80)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(200, 78)
        Me.gbFecha.TabIndex = 2041
        Me.gbFecha.TabStop = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(56, 45)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaFin.TabIndex = 108
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Del:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(56, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaInicio.TabIndex = 107
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlConteo)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 522)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1176, 63)
        Me.pnlPie.TabIndex = 176
        '
        'pnlConteo
        '
        Me.pnlConteo.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlConteo.Controls.Add(Me.lblRegistros)
        Me.pnlConteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlConteo.Name = "pnlConteo"
        Me.pnlConteo.Size = New System.Drawing.Size(107, 63)
        Me.pnlConteo.TabIndex = 190
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(9, 8)
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
        Me.lblRegistros.Location = New System.Drawing.Point(3, 33)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label4)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(856, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(216, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(220, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 161
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(158, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(163, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 11
        Me.btnMostrar.UseVisualStyleBackColor = True
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
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(275, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 12
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
        'grdFacturas
        '
        Me.grdFacturas.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdFacturas.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdFacturas.Location = New System.Drawing.Point(0, 291)
        Me.grdFacturas.MainView = Me.vwFacturas
        Me.grdFacturas.Name = "grdFacturas"
        Me.grdFacturas.Size = New System.Drawing.Size(1176, 231)
        Me.grdFacturas.TabIndex = 177
        Me.grdFacturas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwFacturas, Me.GridView3})
        '
        'vwFacturas
        '
        Me.vwFacturas.GridControl = Me.grdFacturas
        Me.vwFacturas.IndicatorWidth = 30
        Me.vwFacturas.Name = "vwFacturas"
        Me.vwFacturas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwFacturas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwFacturas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwFacturas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwFacturas.OptionsPrint.AllowMultilineHeaders = True
        Me.vwFacturas.OptionsSelection.MultiSelect = True
        Me.vwFacturas.OptionsView.ColumnAutoWidth = False
        Me.vwFacturas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwFacturas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwFacturas.OptionsView.ShowAutoFilterRow = True
        Me.vwFacturas.OptionsView.ShowFooter = True
        Me.vwFacturas.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdFacturas
        Me.GridView3.Name = "GridView3"
        '
        'cmsReportes
        '
        Me.cmsReportes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComprasPorDíaToolStripMenuItem, Me.ComprasPorSemanaToolStripMenuItem, Me.DetallesPorProveedorToolStripMenuItem, Me.ComprasDirectoEIndirectosToolStripMenuItem})
        Me.cmsReportes.Name = "cmsReportes"
        Me.cmsReportes.Size = New System.Drawing.Size(214, 92)
        '
        'ComprasPorDíaToolStripMenuItem
        '
        Me.ComprasPorDíaToolStripMenuItem.Name = "ComprasPorDíaToolStripMenuItem"
        Me.ComprasPorDíaToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ComprasPorDíaToolStripMenuItem.Text = "Compras por Día"
        '
        'ComprasPorSemanaToolStripMenuItem
        '
        Me.ComprasPorSemanaToolStripMenuItem.Name = "ComprasPorSemanaToolStripMenuItem"
        Me.ComprasPorSemanaToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ComprasPorSemanaToolStripMenuItem.Text = "Compras por Semana"
        '
        'DetallesPorProveedorToolStripMenuItem
        '
        Me.DetallesPorProveedorToolStripMenuItem.Name = "DetallesPorProveedorToolStripMenuItem"
        Me.DetallesPorProveedorToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.DetallesPorProveedorToolStripMenuItem.Text = "Detalles por Proveedor"
        '
        'ComprasDirectoEIndirectosToolStripMenuItem
        '
        Me.ComprasDirectoEIndirectosToolStripMenuItem.Name = "ComprasDirectoEIndirectosToolStripMenuItem"
        Me.ComprasDirectoEIndirectosToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ComprasDirectoEIndirectosToolStripMenuItem.Text = "Compras Directo e Indirectos"
        '
        'Proveedor_AdministradorFacturasdeCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 585)
        Me.Controls.Add(Me.grdFacturas)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Proveedor_AdministradorFacturasdeCompra"
        Me.Text = "Administrador de Facturas de Compra"
        Me.Panel1.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        Me.pnlBitacora.ResumeLayout(False)
        Me.pnlBitacora.PerformLayout()
        Me.pnlEnviarCorreo.ResumeLayout(False)
        Me.pnlEnviarCorreo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlGenerarPreLoteo.ResumeLayout(False)
        Me.pnlGenerarPreLoteo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.grdProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.grpReporte.ResumeLayout(False)
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlConteo.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsReportes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pctTitulo As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlGenerarPreLoteo As Panel
    Friend WithEvents btnEnviaFacturas As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancelarFacturas As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlEnviarCorreo As Panel
    Friend WithEvents btnReportes As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlBitacora As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblSemanaActual As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdFacturas As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFacturas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chFechaPrograma As CheckBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents chReporteSemanal As CheckBox
    Friend WithEvents grpReporte As GroupBox
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents gbFecha As GroupBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents btnLimpiarProveedor As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents grdProveedor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarProveedor As Button
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents chSeleccionarTodo As CheckBox
    Friend WithEvents cmsReportes As ContextMenuStrip
    Friend WithEvents ComprasPorDíaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasPorSemanaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetallesPorProveedorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasDirectoEIndirectosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlConteo As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
End Class
