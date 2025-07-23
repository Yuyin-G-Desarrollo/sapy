<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BloqueosForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BloqueosForm))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.grdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.grpboxagente = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdAgentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgente = New System.Windows.Forms.Button()
        Me.grbOtrosFiltros = New System.Windows.Forms.GroupBox()
        Me.nudNumSemana = New System.Windows.Forms.NumericUpDown()
        Me.nudAnio = New System.Windows.Forms.NumericUpDown()
        Me.chkNoBloqueados = New System.Windows.Forms.CheckBox()
        Me.chkBloqueados = New System.Windows.Forms.CheckBox()
        Me.chkInactivos = New System.Windows.Forms.CheckBox()
        Me.chkActivos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.lblActualiza = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.grpboxagente.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbOtrosFiltros.SuspendLayout()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnGenerar)
        Me.pnlEncabezado.Controls.Add(Me.Label1)
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 59)
        Me.pnlEncabezado.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label3)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(913, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(371, 59)
        Me.pnlTitulo.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(16, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(275, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Consulta de Clientes Bloqueados"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(303, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.Programacion.Vista.My.Resources.Resources.importarsicy
        Me.btnGenerar.Location = New System.Drawing.Point(26, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerar.TabIndex = 30
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "ImportarSICY"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(97, 5)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 24
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(97, 40)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(33, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Excel"
        '
        'grdDatos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Appearance = Appearance1
        Me.grdDatos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(0, 222)
        Me.grdDatos.Margin = New System.Windows.Forms.Padding(0)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1284, 325)
        Me.grdDatos.TabIndex = 6
        '
        'pnlFiltros
        '
        Me.pnlFiltros.AutoSize = True
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 59)
        Me.pnlFiltros.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1284, 163)
        Me.pnlFiltros.TabIndex = 7
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.grpboxagente)
        Me.grbFiltros.Controls.Add(Me.grbOtrosFiltros)
        Me.grbFiltros.Controls.Add(Me.GroupBox2)
        Me.grbFiltros.Location = New System.Drawing.Point(0, 7)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1301, 153)
        Me.grbFiltros.TabIndex = 1
        Me.grbFiltros.TabStop = False
        '
        'grpboxagente
        '
        Me.grpboxagente.Controls.Add(Me.Panel3)
        Me.grpboxagente.Controls.Add(Me.btnAgente)
        Me.grpboxagente.Location = New System.Drawing.Point(614, 10)
        Me.grpboxagente.Name = "grpboxagente"
        Me.grpboxagente.Size = New System.Drawing.Size(238, 140)
        Me.grpboxagente.TabIndex = 70
        Me.grpboxagente.TabStop = False
        Me.grpboxagente.Text = "Agente de ventas"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdAgentes)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(232, 98)
        Me.Panel3.TabIndex = 2
        '
        'grdAgentes
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Appearance = Appearance3
        Me.grdAgentes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAgentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAgentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAgentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdAgentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAgentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgentes.Location = New System.Drawing.Point(0, 0)
        Me.grdAgentes.Name = "grdAgentes"
        Me.grdAgentes.Size = New System.Drawing.Size(232, 98)
        Me.grdAgentes.TabIndex = 4
        '
        'btnAgente
        '
        Me.btnAgente.Image = CType(resources.GetObject("btnAgente.Image"), System.Drawing.Image)
        Me.btnAgente.Location = New System.Drawing.Point(210, 11)
        Me.btnAgente.Name = "btnAgente"
        Me.btnAgente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgente.TabIndex = 0
        Me.btnAgente.UseVisualStyleBackColor = True
        '
        'grbOtrosFiltros
        '
        Me.grbOtrosFiltros.Controls.Add(Me.nudNumSemana)
        Me.grbOtrosFiltros.Controls.Add(Me.nudAnio)
        Me.grbOtrosFiltros.Controls.Add(Me.chkNoBloqueados)
        Me.grbOtrosFiltros.Controls.Add(Me.chkBloqueados)
        Me.grbOtrosFiltros.Controls.Add(Me.chkInactivos)
        Me.grbOtrosFiltros.Controls.Add(Me.chkActivos)
        Me.grbOtrosFiltros.Controls.Add(Me.Label7)
        Me.grbOtrosFiltros.Controls.Add(Me.Label6)
        Me.grbOtrosFiltros.Controls.Add(Me.Label5)
        Me.grbOtrosFiltros.Controls.Add(Me.Label4)
        Me.grbOtrosFiltros.Location = New System.Drawing.Point(4, 10)
        Me.grbOtrosFiltros.Name = "grbOtrosFiltros"
        Me.grbOtrosFiltros.Size = New System.Drawing.Size(298, 140)
        Me.grbOtrosFiltros.TabIndex = 69
        Me.grbOtrosFiltros.TabStop = False
        '
        'nudNumSemana
        '
        Me.nudNumSemana.Location = New System.Drawing.Point(195, 90)
        Me.nudNumSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSemana.Name = "nudNumSemana"
        Me.nudNumSemana.Size = New System.Drawing.Size(55, 20)
        Me.nudNumSemana.TabIndex = 9
        Me.nudNumSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudAnio
        '
        Me.nudAnio.Location = New System.Drawing.Point(70, 90)
        Me.nudAnio.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.nudAnio.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.nudAnio.Name = "nudAnio"
        Me.nudAnio.Size = New System.Drawing.Size(55, 20)
        Me.nudAnio.TabIndex = 8
        Me.nudAnio.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'chkNoBloqueados
        '
        Me.chkNoBloqueados.AutoSize = True
        Me.chkNoBloqueados.Location = New System.Drawing.Point(160, 54)
        Me.chkNoBloqueados.Name = "chkNoBloqueados"
        Me.chkNoBloqueados.Size = New System.Drawing.Size(40, 17)
        Me.chkNoBloqueados.TabIndex = 7
        Me.chkNoBloqueados.Text = "No"
        Me.chkNoBloqueados.UseVisualStyleBackColor = True
        '
        'chkBloqueados
        '
        Me.chkBloqueados.AutoSize = True
        Me.chkBloqueados.Location = New System.Drawing.Point(93, 54)
        Me.chkBloqueados.Name = "chkBloqueados"
        Me.chkBloqueados.Size = New System.Drawing.Size(35, 17)
        Me.chkBloqueados.TabIndex = 6
        Me.chkBloqueados.Text = "Si"
        Me.chkBloqueados.UseVisualStyleBackColor = True
        '
        'chkInactivos
        '
        Me.chkInactivos.AutoSize = True
        Me.chkInactivos.Location = New System.Drawing.Point(160, 21)
        Me.chkInactivos.Name = "chkInactivos"
        Me.chkInactivos.Size = New System.Drawing.Size(69, 17)
        Me.chkInactivos.TabIndex = 5
        Me.chkInactivos.Text = "Inactivos"
        Me.chkInactivos.UseVisualStyleBackColor = True
        '
        'chkActivos
        '
        Me.chkActivos.AutoSize = True
        Me.chkActivos.Location = New System.Drawing.Point(93, 21)
        Me.chkActivos.Name = "chkActivos"
        Me.chkActivos.Size = New System.Drawing.Size(61, 17)
        Me.chkActivos.TabIndex = 4
        Me.chkActivos.Text = "Activos"
        Me.chkActivos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Semana"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Bloqueados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Clientes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.btnCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(308, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 140)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdClientes)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(294, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdClientes
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance5
        Me.grdClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(0, 0)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(294, 98)
        Me.grdClientes.TabIndex = 2
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(273, 11)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Location = New System.Drawing.Point(1213, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 0
        '
        'btnArriba
        '
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(6, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'UltraGridExcelExporter1
        '
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.lblActualiza)
        Me.pnlExtado.Controls.Add(Me.Label9)
        Me.pnlExtado.Controls.Add(Me.Label2)
        Me.pnlExtado.Controls.Add(Me.lbl1)
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 547)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1284, 74)
        Me.pnlExtado.TabIndex = 14
        '
        'lblActualiza
        '
        Me.lblActualiza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActualiza.Location = New System.Drawing.Point(855, 23)
        Me.lblActualiza.Name = "lblActualiza"
        Me.lblActualiza.Size = New System.Drawing.Size(242, 32)
        Me.lblActualiza.TabIndex = 4
        Me.lblActualiza.Text = "Última actualización: 09/05/2019 11:10 a.m."
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(688, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 32)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Cobranza realiza el bloqueo de clientes desde el SICY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(268, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 65)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ID Tipo de Bloqueo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5   NO SE PUEDE LOCALIZAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6   DESCUENTOS IMPROCEDENTES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7   " &
    "EXCEDIÓ SU LÍMITE DE CRÉDITO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8   EXCEDIÓ SU LÍMITE DE CRÉDITO PEDIDOS"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(26, 4)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(194, 65)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "ID Tipo de Bloqueo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1   VENCIMIENTO DE DOCUMENTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2   PLAZO DE PAGO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3   CHEQUES" &
    " DEVUELTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4   SOLO CONTADO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1098, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(186, 74)
        Me.Panel1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(73, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(74, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(123, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(18, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(23, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 2
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(124, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'BloqueosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1284, 621)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlExtado)
        Me.Name = "BloqueosForm"
        Me.Text = "Clientes Bloqueados"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grpboxagente.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbOtrosFiltros.ResumeLayout(False)
        Me.grbOtrosFiltros.PerformLayout()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlExtado.ResumeLayout(False)
        Me.pnlExtado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents grdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents grbFiltros As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCliente As Button
    Friend WithEvents grbOtrosFiltros As GroupBox
    Friend WithEvents chkNoBloqueados As CheckBox
    Friend WithEvents chkBloqueados As CheckBox
    Friend WithEvents chkInactivos As CheckBox
    Friend WithEvents chkActivos As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nudNumSemana As NumericUpDown
    Friend WithEvents nudAnio As NumericUpDown
    Friend WithEvents grpboxagente As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdAgentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgente As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblActualiza As Label
    Friend WithEvents Label9 As Label
End Class
