<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportePedidosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportePedidosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.lblreporteic = New System.Windows.Forms.Label()
        Me.btnexportarINT = New System.Windows.Forms.Button()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportarExcelApartados = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroColeccion = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdColecciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnColeccion = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroFamilia = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFamilias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnFamilia = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.dtpFechaEntregaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaEntregaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.gboxCorrida = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroMarca = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdMarcas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnMarcas = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroAgente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdAgentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgente = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblAgrupamiento = New System.Windows.Forms.Label()
        Me.cmboxAgrupamiento = New System.Windows.Forms.ComboBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdReportePedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblAcept = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrarFechaEntrega = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdExportarExcel = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.vwReporteExcel = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdModelos = New DevExpress.XtraGrid.GridControl()
        Me.vwModelos = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumRegistros = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmsReportesInteligencia = New System.Windows.Forms.ContextMenuStrip()
        Me.ReportePedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDetalladoFacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.gboxCorrida.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.grdReportePedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdExportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporteExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.cmsReportesInteligencia.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1326, 59)
        Me.pnlEncabezado.TabIndex = 20
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.lblreporteic)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnexportarINT)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnAyuda)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label1)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcelApartados)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'lblreporteic
        '
        Me.lblreporteic.AutoSize = True
        Me.lblreporteic.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblreporteic.Location = New System.Drawing.Point(125, 39)
        Me.lblreporteic.Name = "lblreporteic"
        Me.lblreporteic.Size = New System.Drawing.Size(67, 13)
        Me.lblreporteic.TabIndex = 55
        Me.lblreporteic.Text = "Reporte I. C."
        Me.lblreporteic.Visible = False
        '
        'btnexportarINT
        '
        Me.btnexportarINT.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnexportarINT.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnexportarINT.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnexportarINT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnexportarINT.Location = New System.Drawing.Point(137, 7)
        Me.btnexportarINT.Name = "btnexportarINT"
        Me.btnexportarINT.Size = New System.Drawing.Size(32, 32)
        Me.btnexportarINT.TabIndex = 54
        Me.btnexportarINT.UseVisualStyleBackColor = True
        Me.btnexportarINT.Visible = False
        '
        'btnAyuda
        '
        Me.btnAyuda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAyuda.Image = Global.Ventas.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAyuda.Location = New System.Drawing.Point(72, 7)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 53
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(70, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Ayuda"
        '
        'btnExportarExcelApartados
        '
        Me.btnExportarExcelApartados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelApartados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelApartados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelApartados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelApartados.Location = New System.Drawing.Point(16, 7)
        Me.btnExportarExcelApartados.Name = "btnExportarExcelApartados"
        Me.btnExportarExcelApartados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelApartados.TabIndex = 53
        Me.btnExportarExcelApartados.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(10, 39)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 52
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(747, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(579, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(268, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(237, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reporte General de Pedidos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.GroupBox5)
        Me.pnlParametros.Controls.Add(Me.GroupBox4)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.gboxCorrida)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1326, 219)
        Me.pnlParametros.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimpiarFiltroColeccion)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.btnColeccion)
        Me.GroupBox1.Location = New System.Drawing.Point(621, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 158)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Colecciones"
        '
        'btnLimpiarFiltroColeccion
        '
        Me.btnLimpiarFiltroColeccion.Image = CType(resources.GetObject("btnLimpiarFiltroColeccion.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroColeccion.Location = New System.Drawing.Point(158, 11)
        Me.btnLimpiarFiltroColeccion.Name = "btnLimpiarFiltroColeccion"
        Me.btnLimpiarFiltroColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroColeccion.TabIndex = 106
        Me.btnLimpiarFiltroColeccion.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdColecciones)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(208, 116)
        Me.Panel4.TabIndex = 2
        '
        'grdColecciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Appearance = Appearance1
        Me.grdColecciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColecciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColecciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColecciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColecciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColecciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColecciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColecciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColecciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColecciones.Location = New System.Drawing.Point(0, 0)
        Me.grdColecciones.Name = "grdColecciones"
        Me.grdColecciones.Size = New System.Drawing.Size(208, 116)
        Me.grdColecciones.TabIndex = 3
        '
        'btnColeccion
        '
        Me.btnColeccion.Image = CType(resources.GetObject("btnColeccion.Image"), System.Drawing.Image)
        Me.btnColeccion.Location = New System.Drawing.Point(186, 11)
        Me.btnColeccion.Name = "btnColeccion"
        Me.btnColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnColeccion.TabIndex = 0
        Me.btnColeccion.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnLimpiarFiltroFamilia)
        Me.GroupBox5.Controls.Add(Me.Panel2)
        Me.GroupBox5.Controls.Add(Me.btnFamilia)
        Me.GroupBox5.Location = New System.Drawing.Point(1057, 35)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(205, 158)
        Me.GroupBox5.TabIndex = 103
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Familia"
        '
        'btnLimpiarFiltroFamilia
        '
        Me.btnLimpiarFiltroFamilia.Image = CType(resources.GetObject("btnLimpiarFiltroFamilia.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroFamilia.Location = New System.Drawing.Point(152, 11)
        Me.btnLimpiarFiltroFamilia.Name = "btnLimpiarFiltroFamilia"
        Me.btnLimpiarFiltroFamilia.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroFamilia.TabIndex = 108
        Me.btnLimpiarFiltroFamilia.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFamilias)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(199, 116)
        Me.Panel2.TabIndex = 2
        '
        'grdFamilias
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamilias.DisplayLayout.Appearance = Appearance3
        Me.grdFamilias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFamilias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFamilias.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFamilias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFamilias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFamilias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFamilias.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFamilias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamilias.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdFamilias.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFamilias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFamilias.Location = New System.Drawing.Point(0, 0)
        Me.grdFamilias.Name = "grdFamilias"
        Me.grdFamilias.Size = New System.Drawing.Size(199, 116)
        Me.grdFamilias.TabIndex = 3
        '
        'btnFamilia
        '
        Me.btnFamilia.Image = CType(resources.GetObject("btnFamilia.Image"), System.Drawing.Image)
        Me.btnFamilia.Location = New System.Drawing.Point(180, 11)
        Me.btnFamilia.Name = "btnFamilia"
        Me.btnFamilia.Size = New System.Drawing.Size(22, 22)
        Me.btnFamilia.TabIndex = 0
        Me.btnFamilia.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.btnCliente)
        Me.GroupBox4.Location = New System.Drawing.Point(841, 35)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(210, 158)
        Me.GroupBox4.TabIndex = 102
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(157, 11)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 107
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdClientes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 116)
        Me.Panel1.TabIndex = 2
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
        Me.grdClientes.Size = New System.Drawing.Size(204, 116)
        Me.grdClientes.TabIndex = 3
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(185, 11)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblNotas)
        Me.GroupBox3.Controls.Add(Me.dtpFechaEntregaDel)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.dtpFechaEntregaAl)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(163, 155)
        Me.GroupBox3.TabIndex = 99
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha Solicita  Cliente"
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotas.Location = New System.Drawing.Point(6, 95)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(63, 13)
        Me.lblNotas.TabIndex = 71
        Me.lblNotas.Text = "Facturados:"
        '
        'dtpFechaEntregaDel
        '
        Me.dtpFechaEntregaDel.CustomFormat = ""
        Me.dtpFechaEntregaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntregaDel.Location = New System.Drawing.Point(46, 25)
        Me.dtpFechaEntregaDel.Name = "dtpFechaEntregaDel"
        Me.dtpFechaEntregaDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaEntregaDel.TabIndex = 66
        Me.dtpFechaEntregaDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(19, 29)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaEntregaAl
        '
        Me.dtpFechaEntregaAl.CustomFormat = ""
        Me.dtpFechaEntregaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntregaAl.Location = New System.Drawing.Point(46, 69)
        Me.dtpFechaEntregaAl.Name = "dtpFechaEntregaAl"
        Me.dtpFechaEntregaAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaEntregaAl.TabIndex = 69
        Me.dtpFechaEntregaAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(21, 73)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'gboxCorrida
        '
        Me.gboxCorrida.Controls.Add(Me.btnLimpiarFiltroMarca)
        Me.gboxCorrida.Controls.Add(Me.Panel8)
        Me.gboxCorrida.Controls.Add(Me.btnMarcas)
        Me.gboxCorrida.Location = New System.Drawing.Point(427, 35)
        Me.gboxCorrida.Name = "gboxCorrida"
        Me.gboxCorrida.Size = New System.Drawing.Size(188, 158)
        Me.gboxCorrida.TabIndex = 95
        Me.gboxCorrida.TabStop = False
        Me.gboxCorrida.Text = "Marca"
        '
        'btnLimpiarFiltroMarca
        '
        Me.btnLimpiarFiltroMarca.Image = CType(resources.GetObject("btnLimpiarFiltroMarca.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroMarca.Location = New System.Drawing.Point(134, 11)
        Me.btnLimpiarFiltroMarca.Name = "btnLimpiarFiltroMarca"
        Me.btnLimpiarFiltroMarca.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroMarca.TabIndex = 105
        Me.btnLimpiarFiltroMarca.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdMarcas)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 39)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(182, 116)
        Me.Panel8.TabIndex = 2
        '
        'grdMarcas
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcas.DisplayLayout.Appearance = Appearance7
        Me.grdMarcas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdMarcas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarcas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarcas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarcas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarcas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMarcas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMarcas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcas.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdMarcas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMarcas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarcas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarcas.Location = New System.Drawing.Point(0, 0)
        Me.grdMarcas.Name = "grdMarcas"
        Me.grdMarcas.Size = New System.Drawing.Size(182, 116)
        Me.grdMarcas.TabIndex = 3
        '
        'btnMarcas
        '
        Me.btnMarcas.Image = CType(resources.GetObject("btnMarcas.Image"), System.Drawing.Image)
        Me.btnMarcas.Location = New System.Drawing.Point(162, 11)
        Me.btnMarcas.Name = "btnMarcas"
        Me.btnMarcas.Size = New System.Drawing.Size(22, 22)
        Me.btnMarcas.TabIndex = 0
        Me.btnMarcas.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroAgente)
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.btnAgente)
        Me.GroupBox2.Location = New System.Drawing.Point(190, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 158)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agente"
        '
        'btnLimpiarFiltroAgente
        '
        Me.btnLimpiarFiltroAgente.Image = CType(resources.GetObject("btnLimpiarFiltroAgente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroAgente.Location = New System.Drawing.Point(175, 11)
        Me.btnLimpiarFiltroAgente.Name = "btnLimpiarFiltroAgente"
        Me.btnLimpiarFiltroAgente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroAgente.TabIndex = 104
        Me.btnLimpiarFiltroAgente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdAgentes)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(225, 116)
        Me.Panel7.TabIndex = 2
        '
        'grdAgentes
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Appearance = Appearance9
        Me.grdAgentes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAgentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAgentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAgentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdAgentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAgentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgentes.Location = New System.Drawing.Point(0, 0)
        Me.grdAgentes.Name = "grdAgentes"
        Me.grdAgentes.Size = New System.Drawing.Size(225, 116)
        Me.grdAgentes.TabIndex = 4
        '
        'btnAgente
        '
        Me.btnAgente.Image = CType(resources.GetObject("btnAgente.Image"), System.Drawing.Image)
        Me.btnAgente.Location = New System.Drawing.Point(203, 11)
        Me.btnAgente.Name = "btnAgente"
        Me.btnAgente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgente.TabIndex = 0
        Me.btnAgente.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblAgrupamiento)
        Me.Panel6.Controls.Add(Me.cmboxAgrupamiento)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1326, 27)
        Me.Panel6.TabIndex = 46
        '
        'lblAgrupamiento
        '
        Me.lblAgrupamiento.AutoSize = True
        Me.lblAgrupamiento.Location = New System.Drawing.Point(19, 7)
        Me.lblAgrupamiento.Name = "lblAgrupamiento"
        Me.lblAgrupamiento.Size = New System.Drawing.Size(75, 13)
        Me.lblAgrupamiento.TabIndex = 93
        Me.lblAgrupamiento.Text = "Agrupamiento:"
        '
        'cmboxAgrupamiento
        '
        Me.cmboxAgrupamiento.FormattingEnabled = True
        Me.cmboxAgrupamiento.Items.AddRange(New Object() {"Agente-cliente-marca-familia", "Agente-cliente-marca-familia-colección", "Agente-cliente-marca-familia-colección-modelo-piel-color-corrida", "Agente-cliente-pedido-partida-marca-familia-colección-modelo-piel-color-corrida", "Reporte Ventas Cliente - Artículos - Tallas"})
        Me.cmboxAgrupamiento.Location = New System.Drawing.Point(100, 3)
        Me.cmboxAgrupamiento.Name = "cmboxAgrupamiento"
        Me.cmboxAgrupamiento.Size = New System.Drawing.Size(376, 21)
        Me.cmboxAgrupamiento.TabIndex = 92
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1266, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1292, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'grdReportePedidos
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReportePedidos.DisplayLayout.Appearance = Appearance11
        Me.grdReportePedidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdReportePedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdReportePedidos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdReportePedidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReportePedidos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdReportePedidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdReportePedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReportePedidos.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Me.grdReportePedidos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReportePedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReportePedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReportePedidos.Location = New System.Drawing.Point(0, 0)
        Me.grdReportePedidos.Name = "grdReportePedidos"
        Me.grdReportePedidos.Size = New System.Drawing.Size(1326, 318)
        Me.grdReportePedidos.TabIndex = 3
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(841, 12)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 104
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(841, 32)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 105
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAcept)
        Me.pnlDatosBotones.Controls.Add(Me.Label2)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrarFechaEntrega)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1072, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(254, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblAcept
        '
        Me.lblAcept.AutoSize = True
        Me.lblAcept.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAcept.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAcept.Location = New System.Drawing.Point(35, 46)
        Me.lblAcept.Name = "lblAcept"
        Me.lblAcept.Size = New System.Drawing.Size(71, 13)
        Me.lblAcept.TabIndex = 6
        Me.lblAcept.Text = "(Exclusivo TI)"
        Me.lblAcept.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(152, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mostrar"
        '
        'btnMostrarFechaEntrega
        '
        Me.btnMostrarFechaEntrega.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrarFechaEntrega.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrarFechaEntrega.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrarFechaEntrega.Location = New System.Drawing.Point(157, 7)
        Me.btnMostrarFechaEntrega.Name = "btnMostrarFechaEntrega"
        Me.btnMostrarFechaEntrega.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarFechaEntrega.TabIndex = 5
        Me.btnMostrarFechaEntrega.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(20, 32)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(100, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar Base FProg"
        Me.lblAceptar.Visible = False
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(55, 1)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        Me.btnMostrar.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(207, 7)
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
        Me.lblCerrar.Location = New System.Drawing.Point(206, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdReportePedidos)
        Me.Panel3.Controls.Add(Me.grdExportarExcel)
        Me.Panel3.Controls.Add(Me.grdModelos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 278)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1326, 318)
        Me.Panel3.TabIndex = 24
        '
        'grdExportarExcel
        '
        Me.grdExportarExcel.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdExportarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdExportarExcel.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdExportarExcel.Location = New System.Drawing.Point(0, 0)
        Me.grdExportarExcel.MainView = Me.GridView1
        Me.grdExportarExcel.Name = "grdExportarExcel"
        Me.grdExportarExcel.Size = New System.Drawing.Size(1281, 271)
        Me.grdExportarExcel.TabIndex = 179
        Me.grdExportarExcel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.vwReporteExcel})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdExportarExcel
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'vwReporteExcel
        '
        Me.vwReporteExcel.GridControl = Me.grdExportarExcel
        Me.vwReporteExcel.IndicatorWidth = 30
        Me.vwReporteExcel.Name = "vwReporteExcel"
        Me.vwReporteExcel.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteExcel.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteExcel.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwReporteExcel.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwReporteExcel.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporteExcel.OptionsSelection.MultiSelect = True
        Me.vwReporteExcel.OptionsView.ColumnAutoWidth = False
        Me.vwReporteExcel.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwReporteExcel.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwReporteExcel.OptionsView.ShowAutoFilterRow = True
        Me.vwReporteExcel.OptionsView.ShowFooter = True
        Me.vwReporteExcel.OptionsView.ShowGroupPanel = False
        '
        'grdModelos
        '
        Me.grdModelos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdModelos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdModelos.Location = New System.Drawing.Point(0, 0)
        Me.grdModelos.MainView = Me.vwModelos
        Me.grdModelos.Name = "grdModelos"
        Me.grdModelos.Size = New System.Drawing.Size(1326, 318)
        Me.grdModelos.TabIndex = 55
        Me.grdModelos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwModelos, Me.GridView3, Me.GridView4})
        Me.grdModelos.Visible = False
        '
        'vwModelos
        '
        Me.vwModelos.GridControl = Me.grdModelos
        Me.vwModelos.Name = "vwModelos"
        Me.vwModelos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwModelos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwModelos.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwModelos.OptionsPrint.AllowMultilineHeaders = True
        Me.vwModelos.OptionsSelection.MultiSelect = True
        Me.vwModelos.OptionsView.ColumnAutoWidth = False
        Me.vwModelos.OptionsView.ShowAutoFilterRow = True
        Me.vwModelos.OptionsView.ShowFooter = True
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView3.GridControl = Me.grdModelos
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
        Me.GridView4.GridControl = Me.grdModelos
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
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.lblNumRegistros)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 596)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1326, 60)
        Me.pnlPie.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(273, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(508, 13)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "La cual contempla los ""pares facturados anteriores"" + ""dentro del periodo selecci" &
    "onado"" + ""los adelantos"""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(132, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Total pares facturados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(273, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(369, 13)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "La cual solo contemplará los pares facturados dentro del rango seleccionado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(164, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Pares facturados"
        '
        'lblNumRegistros
        '
        Me.lblNumRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumRegistros.Location = New System.Drawing.Point(29, 33)
        Me.lblNumRegistros.Name = "lblNumRegistros"
        Me.lblNumRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblNumRegistros.TabIndex = 123
        Me.lblNumRegistros.Text = "0"
        Me.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 32)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "Registros"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmsReportesInteligencia
        '
        Me.cmsReportesInteligencia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportePedidosToolStripMenuItem, Me.ReporteVentasToolStripMenuItem, Me.ReporteDevolucionesToolStripMenuItem, Me.ReporteDetalladoFacturaciónToolStripMenuItem})
        Me.cmsReportesInteligencia.Name = "cmsReportesInteligencia"
        Me.cmsReportesInteligencia.Size = New System.Drawing.Size(221, 92)
        '
        'ReportePedidosToolStripMenuItem
        '
        Me.ReportePedidosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem11, Me.ToolStripMenuItem17})
        Me.ReportePedidosToolStripMenuItem.Name = "ReportePedidosToolStripMenuItem"
        Me.ReportePedidosToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ReportePedidosToolStripMenuItem.Text = "Reporte Pedidos"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem8.Text = "2017"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem2.Text = "2018"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem3.Text = "2019"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem4.Text = "2020"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem11.Text = "2021"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem17.Text = "2022"
        '
        'ReporteVentasToolStripMenuItem
        '
        Me.ReporteVentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem12, Me.ToolStripMenuItem18})
        Me.ReporteVentasToolStripMenuItem.Name = "ReporteVentasToolStripMenuItem"
        Me.ReporteVentasToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ReporteVentasToolStripMenuItem.Text = "Reporte Ventas"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem5.Text = "2018"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem6.Text = "2019"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem7.Text = "2020"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem12.Text = "2021"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem18.Text = "2022"
        '
        'ReporteDevolucionesToolStripMenuItem
        '
        Me.ReporteDevolucionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem13, Me.ToolStripMenuItem19})
        Me.ReporteDevolucionesToolStripMenuItem.Name = "ReporteDevolucionesToolStripMenuItem"
        Me.ReporteDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ReporteDevolucionesToolStripMenuItem.Text = "Reporte Devoluciones"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem9.Text = "2019"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem10.Text = "2020"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem13.Text = "2021"
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem19.Text = "2022"
        '
        'ReporteDetalladoFacturaciónToolStripMenuItem
        '
        Me.ReporteDetalladoFacturaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16, Me.ToolStripMenuItem20})
        Me.ReporteDetalladoFacturaciónToolStripMenuItem.Name = "ReporteDetalladoFacturaciónToolStripMenuItem"
        Me.ReporteDetalladoFacturaciónToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ReporteDetalladoFacturaciónToolStripMenuItem.Text = "Reporte Detallado Facturación"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem14.Text = "2019"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem15.Text = "2020"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem16.Text = "2021"
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        Me.ToolStripMenuItem20.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripMenuItem20.Text = "2022"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(509, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'ReportePedidosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1326, 656)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ReportePedidosForm"
        Me.Text = "Reporte general de pedidos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gboxCorrida.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.grdReportePedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdExportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporteExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.cmsReportesInteligencia.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents btnExportarExcelApartados As System.Windows.Forms.Button
    Friend WithEvents lblActualizarDatos As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaEntregaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaDel As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntregaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaAl As System.Windows.Forms.Label
    Friend WithEvents gboxCorrida As System.Windows.Forms.GroupBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents grdMarcas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnMarcas As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents grdAgentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgente As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grdReportePedidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblTextoUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualización As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblNumRegistros As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdFamilias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnFamilia As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents cmboxAgrupamiento As System.Windows.Forms.ComboBox
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdColecciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnColeccion As Button
    Friend WithEvents lblAgrupamiento As Label
    Friend WithEvents btnLimpiarFiltroColeccion As Button
    Friend WithEvents btnLimpiarFiltroFamilia As Button
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents btnLimpiarFiltroMarca As Button
    Friend WithEvents btnLimpiarFiltroAgente As Button
    Friend WithEvents lblNotas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMostrarFechaEntrega As Button
    Friend WithEvents lblAcept As Label
    Friend WithEvents btnexportarINT As Button
    Friend WithEvents cmsReportesInteligencia As ContextMenuStrip
    Friend WithEvents ReportePedidosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ReporteVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents grdModelos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwModelos As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents lblreporteic As Label
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents ReporteDevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents ReporteDetalladoFacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem19 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As ToolStripMenuItem
    Friend WithEvents grdExportarExcel As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporteExcel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents imgLogo As PictureBox
End Class
