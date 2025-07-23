<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaMovtosInfonavitForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaMovtosInfonavitForm))
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbTiposMov = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoAcumulado = New System.Windows.Forms.RadioButton()
        Me.rdoDetallado = New System.Windows.Forms.RadioButton()
        Me.lblPeriodoAl = New System.Windows.Forms.Label()
        Me.lblPeriodoDel = New System.Windows.Forms.Label()
        Me.cmbPeriodoAl = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodoDel = New System.Windows.Forms.ComboBox()
        Me.txtAnio = New System.Windows.Forms.TextBox()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.pnlColCargados = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaReporteMovimientosInfonavitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteMovimientosInfonavitWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdDatos = New DevExpress.XtraGrid.GridControl()
        Me.vwDatos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.menuAyuda.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1020, 143)
        Me.pnlFiltros.TabIndex = 42
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(938, 3)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 23)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.cmbTiposMov)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.lblPeriodoAl)
        Me.grbFiltros.Controls.Add(Me.lblPeriodoDel)
        Me.grbFiltros.Controls.Add(Me.cmbPeriodoAl)
        Me.grbFiltros.Controls.Add(Me.cmbPeriodoDel)
        Me.grbFiltros.Controls.Add(Me.txtAnio)
        Me.grbFiltros.Controls.Add(Me.lblAnio)
        Me.grbFiltros.Controls.Add(Me.pnlColCargados)
        Me.grbFiltros.Controls.Add(Me.btnSeleccionarColaborador)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblPatron)
        Me.grbFiltros.Controls.Add(Me.Panel10)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 23)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1014, 118)
        Me.grbFiltros.TabIndex = 35
        Me.grbFiltros.TabStop = False
        '
        'cmbTiposMov
        '
        Me.cmbTiposMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposMov.ForeColor = System.Drawing.Color.Black
        Me.cmbTiposMov.FormattingEnabled = True
        Me.cmbTiposMov.Location = New System.Drawing.Point(632, 19)
        Me.cmbTiposMov.Name = "cmbTiposMov"
        Me.cmbTiposMov.Size = New System.Drawing.Size(247, 21)
        Me.cmbTiposMov.TabIndex = 166
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(589, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Tipo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoAcumulado)
        Me.GroupBox1.Controls.Add(Me.rdoDetallado)
        Me.GroupBox1.Location = New System.Drawing.Point(592, 46)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(126, 64)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reporte"
        '
        'rdoAcumulado
        '
        Me.rdoAcumulado.AutoSize = True
        Me.rdoAcumulado.Checked = True
        Me.rdoAcumulado.Location = New System.Drawing.Point(23, 18)
        Me.rdoAcumulado.Name = "rdoAcumulado"
        Me.rdoAcumulado.Size = New System.Drawing.Size(78, 17)
        Me.rdoAcumulado.TabIndex = 151
        Me.rdoAcumulado.TabStop = True
        Me.rdoAcumulado.Text = "Acumulado"
        Me.rdoAcumulado.UseVisualStyleBackColor = True
        '
        'rdoDetallado
        '
        Me.rdoDetallado.AutoSize = True
        Me.rdoDetallado.Location = New System.Drawing.Point(23, 41)
        Me.rdoDetallado.Name = "rdoDetallado"
        Me.rdoDetallado.Size = New System.Drawing.Size(70, 17)
        Me.rdoDetallado.TabIndex = 152
        Me.rdoDetallado.Text = "Detallado"
        Me.rdoDetallado.UseVisualStyleBackColor = True
        '
        'lblPeriodoAl
        '
        Me.lblPeriodoAl.AutoSize = True
        Me.lblPeriodoAl.Location = New System.Drawing.Point(11, 78)
        Me.lblPeriodoAl.Name = "lblPeriodoAl"
        Me.lblPeriodoAl.Size = New System.Drawing.Size(55, 13)
        Me.lblPeriodoAl.TabIndex = 164
        Me.lblPeriodoAl.Text = "Periodo Al"
        '
        'lblPeriodoDel
        '
        Me.lblPeriodoDel.AutoSize = True
        Me.lblPeriodoDel.Location = New System.Drawing.Point(11, 50)
        Me.lblPeriodoDel.Name = "lblPeriodoDel"
        Me.lblPeriodoDel.Size = New System.Drawing.Size(62, 13)
        Me.lblPeriodoDel.TabIndex = 163
        Me.lblPeriodoDel.Text = "Periodo Del"
        '
        'cmbPeriodoAl
        '
        Me.cmbPeriodoAl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoAl.FormattingEnabled = True
        Me.cmbPeriodoAl.Location = New System.Drawing.Point(88, 74)
        Me.cmbPeriodoAl.Name = "cmbPeriodoAl"
        Me.cmbPeriodoAl.Size = New System.Drawing.Size(471, 21)
        Me.cmbPeriodoAl.TabIndex = 162
        '
        'cmbPeriodoDel
        '
        Me.cmbPeriodoDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoDel.FormattingEnabled = True
        Me.cmbPeriodoDel.Location = New System.Drawing.Point(88, 46)
        Me.cmbPeriodoDel.Name = "cmbPeriodoDel"
        Me.cmbPeriodoDel.Size = New System.Drawing.Size(471, 21)
        Me.cmbPeriodoDel.TabIndex = 161
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(511, 18)
        Me.txtAnio.MaxLength = 4
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(48, 20)
        Me.txtAnio.TabIndex = 154
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(479, 22)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(33, 13)
        Me.lblAnio.TabIndex = 160
        Me.lblAnio.Text = "Año *"
        '
        'pnlColCargados
        '
        Me.pnlColCargados.BackgroundImage = CType(resources.GetObject("pnlColCargados.BackgroundImage"), System.Drawing.Image)
        Me.pnlColCargados.Location = New System.Drawing.Point(778, 57)
        Me.pnlColCargados.Name = "pnlColCargados"
        Me.pnlColCargados.Size = New System.Drawing.Size(16, 16)
        Me.pnlColCargados.TabIndex = 159
        Me.pnlColCargados.Visible = False
        '
        'btnSeleccionarColaborador
        '
        Me.btnSeleccionarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarColaborador.Image = CType(resources.GetObject("btnSeleccionarColaborador.Image"), System.Drawing.Image)
        Me.btnSeleccionarColaborador.Location = New System.Drawing.Point(740, 50)
        Me.btnSeleccionarColaborador.Name = "btnSeleccionarColaborador"
        Me.btnSeleccionarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarColaborador.TabIndex = 156
        Me.btnSeleccionarColaborador.UseVisualStyleBackColor = True
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(88, 19)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(385, 21)
        Me.cmbPatron.TabIndex = 153
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.ForeColor = System.Drawing.Color.Black
        Me.lblPatron.Location = New System.Drawing.Point(11, 23)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(38, 13)
        Me.lblPatron.TabIndex = 157
        Me.lblPatron.Text = "Patrón"
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnMostrar)
        Me.Panel10.Controls.Add(Me.lblMostrar)
        Me.Panel10.Controls.Add(Me.btnLimpiar)
        Me.Panel10.Location = New System.Drawing.Point(905, 8)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(108, 80)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(57, 53)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(20, 18)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 7
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(14, 53)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 45
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(62, 18)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 8
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 466)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 65)
        Me.pnlEstado.TabIndex = 40
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.pnlCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(691, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(329, 65)
        Me.pnlOperaciones.TabIndex = 37
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(269, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(60, 65)
        Me.pnlCerrar.TabIndex = 104
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(14, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(13, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 21
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAyuda)
        Me.pnlHeader.Controls.Add(Me.pnlExportar)
        Me.pnlHeader.Controls.Add(Me.pnlImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 69)
        Me.pnlHeader.TabIndex = 39
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.Label3)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(138, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(66, 69)
        Me.pnlAyuda.TabIndex = 114
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(16, 7)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(14, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ayuda"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(72, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(66, 69)
        Me.pnlExportar.TabIndex = 107
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(19, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 10
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(13, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 8
        Me.lblExportar.Text = "Exportar"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblImprimir)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(72, 69)
        Me.pnlImprimir.TabIndex = 106
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(21, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(15, 42)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 3
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblEncabezado)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(497, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(523, 69)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(66, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(366, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Reporte de Movimientos de Crédito Infonavit"
        '
        'menuAyuda
        '
        Me.menuAyuda.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaReporteMovimientosInfonavitToolStripMenuItem, Me.ReporteMovimientosInfonavitWordToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(257, 48)
        '
        'AyudaReporteMovimientosInfonavitToolStripMenuItem
        '
        Me.AyudaReporteMovimientosInfonavitToolStripMenuItem.Name = "AyudaReporteMovimientosInfonavitToolStripMenuItem"
        Me.AyudaReporteMovimientosInfonavitToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.AyudaReporteMovimientosInfonavitToolStripMenuItem.Text = "Ayuda Reporte Movimientos Infonavit"
        '
        'ReporteMovimientosInfonavitWordToolStripMenuItem
        '
        Me.ReporteMovimientosInfonavitWordToolStripMenuItem.Name = "ReporteMovimientosInfonavitWordToolStripMenuItem"
        Me.ReporteMovimientosInfonavitWordToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.ReporteMovimientosInfonavitWordToolStripMenuItem.Text = "Reporte Movimientos Infonavit Word"
        '
        'grdDatos
        '
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(0, 212)
        Me.grdDatos.MainView = Me.vwDatos
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1020, 254)
        Me.grdDatos.TabIndex = 43
        Me.grdDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDatos})
        '
        'vwDatos
        '
        Me.vwDatos.ActiveFilterEnabled = False
        Me.vwDatos.GridControl = Me.grdDatos
        Me.vwDatos.Name = "vwDatos"
        Me.vwDatos.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.vwDatos.OptionsCustomization.AllowFilter = False
        Me.vwDatos.OptionsCustomization.AllowGroup = False
        Me.vwDatos.OptionsFilter.AllowFilterEditor = False
        Me.vwDatos.OptionsSelection.MultiSelect = True
        Me.vwDatos.OptionsView.ColumnAutoWidth = False
        Me.vwDatos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwDatos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwDatos.OptionsView.ShowDetailButtons = False
        Me.vwDatos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwDatos.OptionsView.ShowGroupPanel = False
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(451, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ConsultaMovtosInfonavitForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 531)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConsultaMovtosInfonavitForm"
        Me.Text = "Reporte de Movimientos de Crédito Infonavit"
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents pnlCerrar As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblImprimir As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblEncabezado As Windows.Forms.Label
    Friend WithEvents lblPeriodoAl As Windows.Forms.Label
    Friend WithEvents lblPeriodoDel As Windows.Forms.Label
    Friend WithEvents cmbPeriodoAl As Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodoDel As Windows.Forms.ComboBox
    Friend WithEvents txtAnio As Windows.Forms.TextBox
    Friend WithEvents lblAnio As Windows.Forms.Label
    Friend WithEvents pnlColCargados As Windows.Forms.Panel
    Friend WithEvents btnSeleccionarColaborador As Windows.Forms.Button
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rdoAcumulado As Windows.Forms.RadioButton
    Friend WithEvents rdoDetallado As Windows.Forms.RadioButton
    Friend WithEvents cmbTiposMov As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents AyudaReporteMovimientosInfonavitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteMovimientosInfonavitWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwDatos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
