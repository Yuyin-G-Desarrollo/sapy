<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResumenProduccionFacturacionXNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenProduccionFacturacionXNaveForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpboxNave = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroNave = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdNave = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnNave = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblNoSemana = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudAnioFin = New System.Windows.Forms.NumericUpDown()
        Me.nudAnioInicio = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaFin = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.grdVReporte = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.idNaveSAY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Nave = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Tipo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Sem = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Año = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ParesRecibidos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PorcentajeFacturado = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ParesFacturados = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Replay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.PrevendidoPorcentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevendidoPares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevendidoFacturar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevendidoDocumentar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CoppelPocentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CoppelPares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CoppelFacturar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CoppelDocumentar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.AndreaPocentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AndreaPares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AndreaFacturar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AndreaDocumentar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.StockPorcentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StockPares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StockFacturar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StockDocumentar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.FacturacionporEmpresa180Gramos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FacturacionporEmpresaFreeLife = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FacturaciónporEmpresaReedition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Facturado = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PocentajeF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NaveIdSAY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpboxNave.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdNave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAnioFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAnioInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Controls.Add(Me.Panel14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(901, 67)
        Me.Panel1.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(348, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 67)
        Me.pnlTitulo.TabIndex = 4
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(86, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(393, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Resumen de Producción y Facturación por Nave"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Controls.Add(Me.lblExportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(534, 67)
        Me.Panel14.TabIndex = 5
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(23, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 100
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 99
        Me.lblExportar.Text = "Exportar"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.grpboxNave)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lblNoSemana)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 98)
        Me.Panel2.TabIndex = 2
        '
        'grpboxNave
        '
        Me.grpboxNave.Controls.Add(Me.btnLimpiarFiltroNave)
        Me.grpboxNave.Controls.Add(Me.Panel7)
        Me.grpboxNave.Controls.Add(Me.btnNave)
        Me.grpboxNave.Location = New System.Drawing.Point(340, 6)
        Me.grpboxNave.Name = "grpboxNave"
        Me.grpboxNave.Size = New System.Drawing.Size(347, 85)
        Me.grpboxNave.TabIndex = 194
        Me.grpboxNave.TabStop = False
        Me.grpboxNave.Text = "Naves"
        '
        'btnLimpiarFiltroNave
        '
        Me.btnLimpiarFiltroNave.Image = CType(resources.GetObject("btnLimpiarFiltroNave.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroNave.Location = New System.Drawing.Point(291, 11)
        Me.btnLimpiarFiltroNave.Name = "btnLimpiarFiltroNave"
        Me.btnLimpiarFiltroNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroNave.TabIndex = 5
        Me.btnLimpiarFiltroNave.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdNave)
        Me.Panel7.Location = New System.Drawing.Point(0, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(347, 46)
        Me.Panel7.TabIndex = 2
        '
        'grdNave
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNave.DisplayLayout.Appearance = Appearance1
        Me.grdNave.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNave.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNave.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNave.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNave.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNave.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNave.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNave.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNave.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdNave.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNave.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNave.Location = New System.Drawing.Point(0, 0)
        Me.grdNave.Name = "grdNave"
        Me.grdNave.Size = New System.Drawing.Size(347, 46)
        Me.grdNave.TabIndex = 6
        '
        'btnNave
        '
        Me.btnNave.Image = CType(resources.GetObject("btnNave.Image"), System.Drawing.Image)
        Me.btnNave.Location = New System.Drawing.Point(319, 11)
        Me.btnNave.Name = "btnNave"
        Me.btnNave.Size = New System.Drawing.Size(22, 22)
        Me.btnNave.TabIndex = 0
        Me.btnNave.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnLimpiar)
        Me.Panel6.Controls.Add(Me.btnMostrar)
        Me.Panel6.Controls.Add(Me.lblLimpiar)
        Me.Panel6.Controls.Add(Me.lblMostrar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(701, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(200, 98)
        Me.Panel6.TabIndex = 193
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(134, 26)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 191
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(72, 26)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 186
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(131, 58)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 192
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(69, 58)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 187
        Me.lblMostrar.Text = "Mostrar"
        '
        'lblNoSemana
        '
        Me.lblNoSemana.AutoSize = True
        Me.lblNoSemana.Location = New System.Drawing.Point(112, 7)
        Me.lblNoSemana.Name = "lblNoSemana"
        Me.lblNoSemana.Size = New System.Drawing.Size(16, 13)
        Me.lblNoSemana.TabIndex = 191
        Me.lblNoSemana.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "Semana Actual:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.nudAnioFin)
        Me.GroupBox1.Controls.Add(Me.nudAnioInicio)
        Me.GroupBox1.Controls.Add(Me.nudSemanaFin)
        Me.GroupBox1.Controls.Add(Me.nudSemanaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 70)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Año:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Año:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "a:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Semana de:"
        '
        'nudAnioFin
        '
        Me.nudAnioFin.Location = New System.Drawing.Point(171, 40)
        Me.nudAnioFin.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAnioFin.Minimum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.nudAnioFin.Name = "nudAnioFin"
        Me.nudAnioFin.Size = New System.Drawing.Size(65, 20)
        Me.nudAnioFin.TabIndex = 3
        Me.nudAnioFin.Value = New Decimal(New Integer() {2020, 0, 0, 0})
        '
        'nudAnioInicio
        '
        Me.nudAnioInicio.Location = New System.Drawing.Point(171, 15)
        Me.nudAnioInicio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAnioInicio.Minimum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.nudAnioInicio.Name = "nudAnioInicio"
        Me.nudAnioInicio.Size = New System.Drawing.Size(65, 20)
        Me.nudAnioInicio.TabIndex = 2
        Me.nudAnioInicio.Value = New Decimal(New Integer() {2020, 0, 0, 0})
        '
        'nudSemanaFin
        '
        Me.nudSemanaFin.Location = New System.Drawing.Point(73, 40)
        Me.nudSemanaFin.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaFin.Name = "nudSemanaFin"
        Me.nudSemanaFin.Size = New System.Drawing.Size(51, 20)
        Me.nudSemanaFin.TabIndex = 1
        Me.nudSemanaFin.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(73, 15)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(51, 20)
        Me.nudSemanaInicio.TabIndex = 0
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 406)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(901, 56)
        Me.Panel3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Controls.Add(Me.lblCerrar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(701, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 56)
        Me.Panel4.TabIndex = 4
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(132, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(131, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 2
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdReporte)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 165)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(901, 241)
        Me.Panel5.TabIndex = 4
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.grdVReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(901, 241)
        Me.grdReporte.TabIndex = 69
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVReporte})
        '
        'grdVReporte
        '
        Me.grdVReporte.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand7, Me.gridBand4, Me.gridBand6, Me.gridBand5})
        Me.grdVReporte.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.idNaveSAY, Me.Nave, Me.Tipo, Me.Sem, Me.Año, Me.ParesRecibidos, Me.PorcentajeFacturado, Me.ParesFacturados, Me.PrevendidoPares, Me.PrevendidoPorcentaje, Me.PrevendidoFacturar, Me.PrevendidoDocumentar, Me.CoppelPares, Me.CoppelPocentaje, Me.CoppelFacturar, Me.CoppelDocumentar, Me.AndreaPares, Me.AndreaPocentaje, Me.AndreaFacturar, Me.AndreaDocumentar, Me.StockPares, Me.StockPorcentaje, Me.StockFacturar, Me.StockDocumentar, Me.FacturacionporEmpresa180Gramos, Me.FacturacionporEmpresaFreeLife, Me.FacturaciónporEmpresaReedition, Me.Facturado, Me.Replay, Me.PocentajeF})
        Me.grdVReporte.GridControl = Me.grdReporte
        Me.grdVReporte.Name = "grdVReporte"
        Me.grdVReporte.OptionsBehavior.Editable = False
        Me.grdVReporte.OptionsCustomization.AllowBandMoving = False
        Me.grdVReporte.OptionsCustomization.AllowColumnMoving = False
        Me.grdVReporte.OptionsCustomization.AllowFilter = False
        Me.grdVReporte.OptionsCustomization.AllowGroup = False
        Me.grdVReporte.OptionsFilter.AllowFilterEditor = False
        Me.grdVReporte.OptionsMenu.EnableColumnMenu = False
        Me.grdVReporte.OptionsSelection.MultiSelect = True
        Me.grdVReporte.OptionsView.ColumnAutoWidth = False
        Me.grdVReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.grdVReporte.OptionsView.ShowDetailButtons = False
        Me.grdVReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdVReporte.OptionsView.ShowFooter = True
        Me.grdVReporte.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Columns.Add(Me.idNaveSAY)
        Me.GridBand1.Columns.Add(Me.Nave)
        Me.GridBand1.Columns.Add(Me.Tipo)
        Me.GridBand1.Columns.Add(Me.Sem)
        Me.GridBand1.Columns.Add(Me.Año)
        Me.GridBand1.Columns.Add(Me.ParesRecibidos)
        Me.GridBand1.Columns.Add(Me.PorcentajeFacturado)
        Me.GridBand1.Columns.Add(Me.ParesFacturados)
        Me.GridBand1.Columns.Add(Me.Replay)
        Me.GridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 675
        '
        'idNaveSAY
        '
        Me.idNaveSAY.AppearanceCell.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.idNaveSAY.AppearanceCell.Options.UseBackColor = True
        Me.idNaveSAY.Caption = "NaveIdSAY"
        Me.idNaveSAY.FieldName = "NaveIdSAY"
        Me.idNaveSAY.Name = "idNaveSAY"
        Me.idNaveSAY.Visible = True
        '
        'Nave
        '
        Me.Nave.AppearanceCell.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Nave.AppearanceCell.Options.UseBackColor = True
        Me.Nave.Caption = "Nave"
        Me.Nave.FieldName = "Nave"
        Me.Nave.Name = "Nave"
        Me.Nave.Visible = True
        '
        'Tipo
        '
        Me.Tipo.AppearanceCell.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Tipo.AppearanceCell.Options.UseBackColor = True
        Me.Tipo.Caption = "Tipo"
        Me.Tipo.FieldName = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Visible = True
        '
        'Sem
        '
        Me.Sem.AppearanceCell.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Sem.AppearanceCell.Options.UseBackColor = True
        Me.Sem.Caption = "Sem"
        Me.Sem.FieldName = "Sem"
        Me.Sem.Name = "Sem"
        Me.Sem.Visible = True
        '
        'Año
        '
        Me.Año.AppearanceCell.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Año.AppearanceCell.Options.UseBackColor = True
        Me.Año.Caption = "Año"
        Me.Año.FieldName = "Año"
        Me.Año.Name = "Año"
        Me.Año.Visible = True
        '
        'ParesRecibidos
        '
        Me.ParesRecibidos.Caption = "Pares Recibidos"
        Me.ParesRecibidos.FieldName = "ParesRecibidos"
        Me.ParesRecibidos.Name = "ParesRecibidos"
        Me.ParesRecibidos.Visible = True
        '
        'PorcentajeFacturado
        '
        Me.PorcentajeFacturado.Caption = "% Facturado"
        Me.PorcentajeFacturado.FieldName = "%-Facturado"
        Me.PorcentajeFacturado.Name = "PorcentajeFacturado"
        Me.PorcentajeFacturado.Visible = True
        '
        'ParesFacturados
        '
        Me.ParesFacturados.Caption = "Pares Facturados"
        Me.ParesFacturados.FieldName = "ParesFacturados"
        Me.ParesFacturados.Name = "ParesFacturados"
        Me.ParesFacturados.Visible = True
        '
        'Replay
        '
        Me.Replay.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Replay.AppearanceCell.Options.UseBackColor = True
        Me.Replay.Caption = "Replay"
        Me.Replay.FieldName = "Replay"
        Me.Replay.Name = "Replay"
        Me.Replay.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Prevendido"
        Me.gridBand2.Columns.Add(Me.PrevendidoPorcentaje)
        Me.gridBand2.Columns.Add(Me.PrevendidoPares)
        Me.gridBand2.Columns.Add(Me.PrevendidoFacturar)
        Me.gridBand2.Columns.Add(Me.PrevendidoDocumentar)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 300
        '
        'PrevendidoPorcentaje
        '
        Me.PrevendidoPorcentaje.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PrevendidoPorcentaje.AppearanceCell.Options.UseBackColor = True
        Me.PrevendidoPorcentaje.Caption = "%"
        Me.PrevendidoPorcentaje.FieldName = "Prevendido-%"
        Me.PrevendidoPorcentaje.Name = "PrevendidoPorcentaje"
        Me.PrevendidoPorcentaje.Visible = True
        '
        'PrevendidoPares
        '
        Me.PrevendidoPares.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PrevendidoPares.AppearanceCell.Options.UseBackColor = True
        Me.PrevendidoPares.Caption = "Pares"
        Me.PrevendidoPares.FieldName = "PrevendidoPares"
        Me.PrevendidoPares.Name = "PrevendidoPares"
        Me.PrevendidoPares.Visible = True
        '
        'PrevendidoFacturar
        '
        Me.PrevendidoFacturar.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PrevendidoFacturar.AppearanceCell.Options.UseBackColor = True
        Me.PrevendidoFacturar.Caption = "Facturar"
        Me.PrevendidoFacturar.FieldName = "Prevendido-Facturar"
        Me.PrevendidoFacturar.Name = "PrevendidoFacturar"
        Me.PrevendidoFacturar.Visible = True
        '
        'PrevendidoDocumentar
        '
        Me.PrevendidoDocumentar.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PrevendidoDocumentar.AppearanceCell.Options.UseBackColor = True
        Me.PrevendidoDocumentar.Caption = "Documentar"
        Me.PrevendidoDocumentar.FieldName = "Prevendido-Documentar"
        Me.PrevendidoDocumentar.Name = "PrevendidoDocumentar"
        Me.PrevendidoDocumentar.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Coppel"
        Me.gridBand3.Columns.Add(Me.CoppelPocentaje)
        Me.gridBand3.Columns.Add(Me.CoppelPares)
        Me.gridBand3.Columns.Add(Me.CoppelFacturar)
        Me.gridBand3.Columns.Add(Me.CoppelDocumentar)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 300
        '
        'CoppelPocentaje
        '
        Me.CoppelPocentaje.Caption = "%"
        Me.CoppelPocentaje.FieldName = "Coppel-%"
        Me.CoppelPocentaje.Name = "CoppelPocentaje"
        Me.CoppelPocentaje.Visible = True
        '
        'CoppelPares
        '
        Me.CoppelPares.Caption = "Pares"
        Me.CoppelPares.FieldName = "Coppel-Pares"
        Me.CoppelPares.Name = "CoppelPares"
        Me.CoppelPares.Visible = True
        '
        'CoppelFacturar
        '
        Me.CoppelFacturar.Caption = "Facturar"
        Me.CoppelFacturar.FieldName = "Coppel-Facturar"
        Me.CoppelFacturar.Name = "CoppelFacturar"
        Me.CoppelFacturar.Visible = True
        '
        'CoppelDocumentar
        '
        Me.CoppelDocumentar.Caption = "Documentar"
        Me.CoppelDocumentar.FieldName = "Coppel-Documentar"
        Me.CoppelDocumentar.Name = "CoppelDocumentar"
        Me.CoppelDocumentar.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "Andrea"
        Me.gridBand7.Columns.Add(Me.AndreaPocentaje)
        Me.gridBand7.Columns.Add(Me.AndreaPares)
        Me.gridBand7.Columns.Add(Me.AndreaFacturar)
        Me.gridBand7.Columns.Add(Me.AndreaDocumentar)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 3
        Me.gridBand7.Width = 300
        '
        'AndreaPocentaje
        '
        Me.AndreaPocentaje.Caption = "%"
        Me.AndreaPocentaje.FieldName = "Andrea-%"
        Me.AndreaPocentaje.Name = "AndreaPocentaje"
        Me.AndreaPocentaje.Visible = True
        '
        'AndreaPares
        '
        Me.AndreaPares.Caption = "Pares"
        Me.AndreaPares.FieldName = "Andrea-Pares"
        Me.AndreaPares.Name = "AndreaPares"
        Me.AndreaPares.Visible = True
        '
        'AndreaFacturar
        '
        Me.AndreaFacturar.Caption = "Facturar"
        Me.AndreaFacturar.FieldName = "Andrea-Facturar"
        Me.AndreaFacturar.Name = "AndreaFacturar"
        Me.AndreaFacturar.Visible = True
        '
        'AndreaDocumentar
        '
        Me.AndreaDocumentar.Caption = "Documentar"
        Me.AndreaDocumentar.FieldName = "Andrea-Documentar"
        Me.AndreaDocumentar.Name = "AndreaDocumentar"
        Me.AndreaDocumentar.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "Stock"
        Me.gridBand4.Columns.Add(Me.StockPorcentaje)
        Me.gridBand4.Columns.Add(Me.StockPares)
        Me.gridBand4.Columns.Add(Me.StockFacturar)
        Me.gridBand4.Columns.Add(Me.StockDocumentar)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 300
        '
        'StockPorcentaje
        '
        Me.StockPorcentaje.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.StockPorcentaje.AppearanceCell.Options.UseBackColor = True
        Me.StockPorcentaje.Caption = "%"
        Me.StockPorcentaje.FieldName = "Stock-%"
        Me.StockPorcentaje.Name = "StockPorcentaje"
        Me.StockPorcentaje.Visible = True
        '
        'StockPares
        '
        Me.StockPares.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.StockPares.AppearanceCell.Options.UseBackColor = True
        Me.StockPares.Caption = "Pares"
        Me.StockPares.FieldName = "Stock-Pares"
        Me.StockPares.Name = "StockPares"
        Me.StockPares.Visible = True
        '
        'StockFacturar
        '
        Me.StockFacturar.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.StockFacturar.AppearanceCell.Options.UseBackColor = True
        Me.StockFacturar.Caption = "Facturar"
        Me.StockFacturar.FieldName = "Stock-Facturar"
        Me.StockFacturar.Name = "StockFacturar"
        Me.StockFacturar.Visible = True
        '
        'StockDocumentar
        '
        Me.StockDocumentar.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.StockDocumentar.AppearanceCell.Options.UseBackColor = True
        Me.StockDocumentar.Caption = "Documentar"
        Me.StockDocumentar.FieldName = "Stock-Documentar"
        Me.StockDocumentar.Name = "StockDocumentar"
        Me.StockDocumentar.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Facturación por Empresa"
        Me.gridBand6.Columns.Add(Me.FacturacionporEmpresa180Gramos)
        Me.gridBand6.Columns.Add(Me.FacturacionporEmpresaFreeLife)
        Me.gridBand6.Columns.Add(Me.FacturaciónporEmpresaReedition)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 5
        Me.gridBand6.Width = 225
        '
        'FacturacionporEmpresa180Gramos
        '
        Me.FacturacionporEmpresa180Gramos.Caption = "180 Gramos"
        Me.FacturacionporEmpresa180Gramos.FieldName = "FacturaciónporEmpresa-180Gramos"
        Me.FacturacionporEmpresa180Gramos.Name = "FacturacionporEmpresa180Gramos"
        Me.FacturacionporEmpresa180Gramos.Visible = True
        '
        'FacturacionporEmpresaFreeLife
        '
        Me.FacturacionporEmpresaFreeLife.Caption = "FreeLife"
        Me.FacturacionporEmpresaFreeLife.FieldName = "FacturaciónporEmpresa-FreeLife"
        Me.FacturacionporEmpresaFreeLife.Name = "FacturacionporEmpresaFreeLife"
        Me.FacturacionporEmpresaFreeLife.Visible = True
        '
        'FacturaciónporEmpresaReedition
        '
        Me.FacturaciónporEmpresaReedition.Caption = "Reedition"
        Me.FacturaciónporEmpresaReedition.FieldName = "FacturaciónporEmpresa-Reedition"
        Me.FacturaciónporEmpresaReedition.Name = "FacturaciónporEmpresaReedition"
        Me.FacturaciónporEmpresaReedition.Visible = True
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "TOTAL"
        Me.gridBand5.Columns.Add(Me.Facturado)
        Me.gridBand5.Columns.Add(Me.PocentajeF)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.Visible = False
        Me.gridBand5.VisibleIndex = -1
        Me.gridBand5.Width = 150
        '
        'Facturado
        '
        Me.Facturado.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Facturado.AppearanceCell.Options.UseBackColor = True
        Me.Facturado.Caption = "Facturado"
        Me.Facturado.FieldName = "Facturado"
        Me.Facturado.Name = "Facturado"
        Me.Facturado.Visible = True
        '
        'PocentajeF
        '
        Me.PocentajeF.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PocentajeF.AppearanceCell.Options.UseBackColor = True
        Me.PocentajeF.Caption = "% F"
        Me.PocentajeF.FieldName = "%F"
        Me.PocentajeF.Name = "PocentajeF"
        Me.PocentajeF.Visible = True
        '
        'NaveIdSAY
        '
        Me.NaveIdSAY.Caption = "NaveIdSAY"
        Me.NaveIdSAY.FieldName = "NaveIdSAY"
        Me.NaveIdSAY.Name = "NaveIdSAY"
        Me.NaveIdSAY.Width = 144
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(485, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 67)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 91
        Me.pbYuyin.TabStop = False
        '
        'ResumenProduccionFacturacionXNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(901, 462)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(909, 489)
        Me.Name = "ResumenProduccionFacturacionXNaveForm"
        Me.Text = "Resumen Producción Facturación X Nave"
        Me.Panel1.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grpboxNave.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdNave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAnioFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAnioInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Panel14 As Windows.Forms.Panel
    Friend WithEvents btnExportarExcel As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents lblNoSemana As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents nudAnioFin As Windows.Forms.NumericUpDown
    Friend WithEvents nudAnioInicio As Windows.Forms.NumericUpDown
    Friend WithEvents nudSemanaFin As Windows.Forms.NumericUpDown
    Friend WithEvents nudSemanaInicio As Windows.Forms.NumericUpDown
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVReporte As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents idNaveSAY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Nave As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Sem As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Año As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesRecibidos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PorcentajeFacturado As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesFacturados As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevendidoPares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevendidoPorcentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevendidoFacturar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevendidoDocumentar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CoppelPares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CoppelPocentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CoppelFacturar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CoppelDocumentar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StockPares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StockPorcentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StockFacturar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StockDocumentar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FacturacionporEmpresa180Gramos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FacturacionporEmpresaFreeLife As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FacturaciónporEmpresaReedition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Facturado As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Replay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PocentajeF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NaveIdSAY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AndreaPares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AndreaPocentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AndreaFacturar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AndreaDocumentar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents grpboxNave As Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroNave As Windows.Forms.Button
    Friend WithEvents Panel7 As Windows.Forms.Panel
    Friend WithEvents grdNave As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnNave As Windows.Forms.Button
    Friend WithEvents Tipo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
