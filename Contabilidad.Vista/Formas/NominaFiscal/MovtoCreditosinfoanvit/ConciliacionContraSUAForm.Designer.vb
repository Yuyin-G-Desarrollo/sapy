<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConciliacionContraSUAForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConciliacionContraSUAForm))
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlColaboradoresCargados = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.rdoBimestre = New System.Windows.Forms.RadioButton()
        Me.rdoAcumulado = New System.Windows.Forms.RadioButton()
        Me.lblTipoReporte = New System.Windows.Forms.Label()
        Me.cmbBimestre = New System.Windows.Forms.ComboBox()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlLayout = New System.Windows.Forms.Panel()
        Me.btnLayout = New System.Windows.Forms.Button()
        Me.lblLayout = New System.Windows.Forms.Label()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.btnImportarDatos = New System.Windows.Forms.Button()
        Me.lblCargarDatos = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaActualizacion = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblEnEdicion = New System.Windows.Forms.Label()
        Me.lblColorEdicion = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdDatosConciliacion = New DevExpress.XtraGrid.GridControl()
        Me.bgvConciliacionSUA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaConciliaciónSUAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConciliaciónSUAArchivoWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConciliaciónSUAPropuestaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlLayout.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        CType(Me.grdDatosConciliacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvConciliacionSUA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuAyuda.SuspendLayout()
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
        Me.pnlFiltros.Size = New System.Drawing.Size(1021, 131)
        Me.pnlFiltros.TabIndex = 42
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(942, 3)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 23)
        Me.pnlMinimizarParametros.TabIndex = 45
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
        Me.grbFiltros.Controls.Add(Me.Panel10)
        Me.grbFiltros.Controls.Add(Me.pnlColaboradoresCargados)
        Me.grbFiltros.Controls.Add(Me.btnSeleccionarColaborador)
        Me.grbFiltros.Controls.Add(Me.rdoBimestre)
        Me.grbFiltros.Controls.Add(Me.rdoAcumulado)
        Me.grbFiltros.Controls.Add(Me.lblTipoReporte)
        Me.grbFiltros.Controls.Add(Me.cmbBimestre)
        Me.grbFiltros.Controls.Add(Me.numAnio)
        Me.grbFiltros.Controls.Add(Me.lblMes)
        Me.grbFiltros.Controls.Add(Me.lblAnio)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblPatron)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 20)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1018, 108)
        Me.grbFiltros.TabIndex = 35
        Me.grbFiltros.TabStop = False
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnMostrar)
        Me.Panel10.Controls.Add(Me.lblMostrar)
        Me.Panel10.Controls.Add(Me.btnLimpiar)
        Me.Panel10.Location = New System.Drawing.Point(910, 8)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(108, 80)
        Me.Panel10.TabIndex = 162
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(59, 53)
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
        Me.lblMostrar.Location = New System.Drawing.Point(16, 53)
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
        'pnlColaboradoresCargados
        '
        Me.pnlColaboradoresCargados.BackgroundImage = CType(resources.GetObject("pnlColaboradoresCargados.BackgroundImage"), System.Drawing.Image)
        Me.pnlColaboradoresCargados.Location = New System.Drawing.Point(513, 63)
        Me.pnlColaboradoresCargados.Name = "pnlColaboradoresCargados"
        Me.pnlColaboradoresCargados.Size = New System.Drawing.Size(16, 16)
        Me.pnlColaboradoresCargados.TabIndex = 161
        Me.pnlColaboradoresCargados.Visible = False
        '
        'btnSeleccionarColaborador
        '
        Me.btnSeleccionarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarColaborador.Image = CType(resources.GetObject("btnSeleccionarColaborador.Image"), System.Drawing.Image)
        Me.btnSeleccionarColaborador.Location = New System.Drawing.Point(477, 56)
        Me.btnSeleccionarColaborador.Name = "btnSeleccionarColaborador"
        Me.btnSeleccionarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarColaborador.TabIndex = 160
        Me.btnSeleccionarColaborador.UseVisualStyleBackColor = True
        '
        'rdoBimestre
        '
        Me.rdoBimestre.AutoSize = True
        Me.rdoBimestre.Location = New System.Drawing.Point(613, 25)
        Me.rdoBimestre.Name = "rdoBimestre"
        Me.rdoBimestre.Size = New System.Drawing.Size(65, 17)
        Me.rdoBimestre.TabIndex = 159
        Me.rdoBimestre.TabStop = True
        Me.rdoBimestre.Text = "Bimestre"
        Me.rdoBimestre.UseVisualStyleBackColor = True
        '
        'rdoAcumulado
        '
        Me.rdoAcumulado.AutoSize = True
        Me.rdoAcumulado.Checked = True
        Me.rdoAcumulado.Location = New System.Drawing.Point(529, 25)
        Me.rdoAcumulado.Name = "rdoAcumulado"
        Me.rdoAcumulado.Size = New System.Drawing.Size(78, 17)
        Me.rdoAcumulado.TabIndex = 158
        Me.rdoAcumulado.TabStop = True
        Me.rdoAcumulado.Text = "Acumulado"
        Me.rdoAcumulado.UseVisualStyleBackColor = True
        '
        'lblTipoReporte
        '
        Me.lblTipoReporte.AutoSize = True
        Me.lblTipoReporte.Location = New System.Drawing.Point(474, 27)
        Me.lblTipoReporte.Name = "lblTipoReporte"
        Me.lblTipoReporte.Size = New System.Drawing.Size(49, 13)
        Me.lblTipoReporte.TabIndex = 157
        Me.lblTipoReporte.Text = "Reporte*"
        '
        'cmbBimestre
        '
        Me.cmbBimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBimestre.ForeColor = System.Drawing.Color.Black
        Me.cmbBimestre.FormattingEnabled = True
        Me.cmbBimestre.Location = New System.Drawing.Point(220, 51)
        Me.cmbBimestre.Name = "cmbBimestre"
        Me.cmbBimestre.Size = New System.Drawing.Size(227, 21)
        Me.cmbBimestre.TabIndex = 156
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(62, 51)
        Me.numAnio.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(89, 20)
        Me.numAnio.TabIndex = 155
        Me.numAnio.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(167, 54)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(47, 13)
        Me.lblMes.TabIndex = 149
        Me.lblMes.Text = "Bimestre"
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(23, 54)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(33, 13)
        Me.lblAnio.TabIndex = 148
        Me.lblAnio.Text = "Año *"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(62, 78)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(385, 20)
        Me.txtNombre.TabIndex = 5
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(10, 81)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 96
        Me.lblNombre.Text = "Nombre"
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(62, 24)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(385, 21)
        Me.cmbPatron.TabIndex = 1
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.ForeColor = System.Drawing.Color.Black
        Me.lblPatron.Location = New System.Drawing.Point(12, 27)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(45, 13)
        Me.lblPatron.TabIndex = 25
        Me.lblPatron.Text = "Patrón *"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblEncabezado)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(552, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(469, 69)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(185, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(203, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Conciliación contra SUA"
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
        'pnlLayout
        '
        Me.pnlLayout.Controls.Add(Me.btnLayout)
        Me.pnlLayout.Controls.Add(Me.lblLayout)
        Me.pnlLayout.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLayout.Location = New System.Drawing.Point(138, 0)
        Me.pnlLayout.Name = "pnlLayout"
        Me.pnlLayout.Size = New System.Drawing.Size(66, 69)
        Me.pnlLayout.TabIndex = 108
        '
        'btnLayout
        '
        Me.btnLayout.Image = CType(resources.GetObject("btnLayout.Image"), System.Drawing.Image)
        Me.btnLayout.Location = New System.Drawing.Point(19, 7)
        Me.btnLayout.Name = "btnLayout"
        Me.btnLayout.Size = New System.Drawing.Size(31, 32)
        Me.btnLayout.TabIndex = 10
        Me.btnLayout.UseVisualStyleBackColor = True
        '
        'lblLayout
        '
        Me.lblLayout.AutoSize = True
        Me.lblLayout.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLayout.Location = New System.Drawing.Point(10, 42)
        Me.lblLayout.Name = "lblLayout"
        Me.lblLayout.Size = New System.Drawing.Size(49, 26)
        Me.lblLayout.TabIndex = 8
        Me.lblLayout.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Layout"
        Me.lblLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlImportar
        '
        Me.pnlImportar.Controls.Add(Me.btnImportarDatos)
        Me.pnlImportar.Controls.Add(Me.lblCargarDatos)
        Me.pnlImportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImportar.Location = New System.Drawing.Point(204, 0)
        Me.pnlImportar.Name = "pnlImportar"
        Me.pnlImportar.Size = New System.Drawing.Size(66, 69)
        Me.pnlImportar.TabIndex = 109
        '
        'btnImportarDatos
        '
        Me.btnImportarDatos.Image = CType(resources.GetObject("btnImportarDatos.Image"), System.Drawing.Image)
        Me.btnImportarDatos.Location = New System.Drawing.Point(19, 7)
        Me.btnImportarDatos.Name = "btnImportarDatos"
        Me.btnImportarDatos.Size = New System.Drawing.Size(31, 32)
        Me.btnImportarDatos.TabIndex = 10
        Me.btnImportarDatos.UseVisualStyleBackColor = True
        '
        'lblCargarDatos
        '
        Me.lblCargarDatos.AutoSize = True
        Me.lblCargarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarDatos.Location = New System.Drawing.Point(14, 42)
        Me.lblCargarDatos.Name = "lblCargarDatos"
        Me.lblCargarDatos.Size = New System.Drawing.Size(48, 26)
        Me.lblCargarDatos.TabIndex = 8
        Me.lblCargarDatos.Text = "Importar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Datos"
        Me.lblCargarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.Label1)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(270, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(66, 69)
        Me.pnlAutorizar.TabIndex = 110
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Image = CType(resources.GetObject("btnAutorizar.Image"), System.Drawing.Image)
        Me.btnAutorizar.Location = New System.Drawing.Point(19, 7)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 10
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(7, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Autorizar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAyuda)
        Me.pnlHeader.Controls.Add(Me.pnlAutorizar)
        Me.pnlHeader.Controls.Add(Me.pnlImportar)
        Me.pnlHeader.Controls.Add(Me.pnlLayout)
        Me.pnlHeader.Controls.Add(Me.pnlExportar)
        Me.pnlHeader.Controls.Add(Me.pnlImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1021, 69)
        Me.pnlHeader.TabIndex = 39
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.Label4)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(336, 0)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(14, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ayuda"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblFechaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblEnEdicion)
        Me.pnlPie.Controls.Add(Me.lblColorEdicion)
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 422)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1021, 71)
        Me.pnlPie.TabIndex = 77
        '
        'lblFechaActualizacion
        '
        Me.lblFechaActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaActualizacion.AutoSize = True
        Me.lblFechaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaActualizacion.Location = New System.Drawing.Point(660, 18)
        Me.lblFechaActualizacion.Name = "lblFechaActualizacion"
        Me.lblFechaActualizacion.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaActualizacion.TabIndex = 54
        Me.lblFechaActualizacion.Text = "-"
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(549, 18)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(105, 13)
        Me.lblUltimaActualizacion.TabIndex = 53
        Me.lblUltimaActualizacion.Text = "Ultima Actualización:"
        '
        'lblEnEdicion
        '
        Me.lblEnEdicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnEdicion.AutoSize = True
        Me.lblEnEdicion.ForeColor = System.Drawing.Color.Black
        Me.lblEnEdicion.Location = New System.Drawing.Point(30, 17)
        Me.lblEnEdicion.Name = "lblEnEdicion"
        Me.lblEnEdicion.Size = New System.Drawing.Size(99, 13)
        Me.lblEnEdicion.TabIndex = 41
        Me.lblEnEdicion.Text = "Registro en Edición"
        '
        'lblColorEdicion
        '
        Me.lblColorEdicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColorEdicion.AutoSize = True
        Me.lblColorEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.lblColorEdicion.ForeColor = System.Drawing.Color.White
        Me.lblColorEdicion.Location = New System.Drawing.Point(10, 16)
        Me.lblColorEdicion.MaximumSize = New System.Drawing.Size(15, 15)
        Me.lblColorEdicion.MinimumSize = New System.Drawing.Size(15, 15)
        Me.lblColorEdicion.Name = "lblColorEdicion"
        Me.lblColorEdicion.Size = New System.Drawing.Size(15, 15)
        Me.lblColorEdicion.TabIndex = 40
        Me.lblColorEdicion.UseMnemonic = False
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.pnlGuardar)
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(902, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(119, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.Label2)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGuardar.Location = New System.Drawing.Point(0, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(66, 71)
        Me.pnlGuardar.TabIndex = 115
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(16, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(72, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(72, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdDatosConciliacion
        '
        Me.grdDatosConciliacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosConciliacion.Location = New System.Drawing.Point(0, 200)
        Me.grdDatosConciliacion.MainView = Me.bgvConciliacionSUA
        Me.grdDatosConciliacion.Name = "grdDatosConciliacion"
        Me.grdDatosConciliacion.Size = New System.Drawing.Size(1021, 222)
        Me.grdDatosConciliacion.TabIndex = 78
        Me.grdDatosConciliacion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvConciliacionSUA})
        '
        'bgvConciliacionSUA
        '
        Me.bgvConciliacionSUA.GridControl = Me.grdDatosConciliacion
        Me.bgvConciliacionSUA.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.bgvConciliacionSUA.Name = "bgvConciliacionSUA"
        Me.bgvConciliacionSUA.OptionsCustomization.AllowSort = False
        Me.bgvConciliacionSUA.OptionsView.ShowAutoFilterRow = True
        Me.bgvConciliacionSUA.OptionsView.ShowFooter = True
        Me.bgvConciliacionSUA.OptionsView.ShowGroupPanel = False
        '
        'menuAyuda
        '
        Me.menuAyuda.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaConciliaciónSUAToolStripMenuItem, Me.ConciliaciónSUAArchivoWordToolStripMenuItem, Me.ConciliaciónSUAPropuestaToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(221, 70)
        '
        'AyudaConciliaciónSUAToolStripMenuItem
        '
        Me.AyudaConciliaciónSUAToolStripMenuItem.Name = "AyudaConciliaciónSUAToolStripMenuItem"
        Me.AyudaConciliaciónSUAToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.AyudaConciliaciónSUAToolStripMenuItem.Text = "Ayuda Conciliación SUA"
        '
        'ConciliaciónSUAArchivoWordToolStripMenuItem
        '
        Me.ConciliaciónSUAArchivoWordToolStripMenuItem.Name = "ConciliaciónSUAArchivoWordToolStripMenuItem"
        Me.ConciliaciónSUAArchivoWordToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ConciliaciónSUAArchivoWordToolStripMenuItem.Text = "Conciliación SUA Archivo Word"
        '
        'ConciliaciónSUAPropuestaToolStripMenuItem
        '
        Me.ConciliaciónSUAPropuestaToolStripMenuItem.Name = "ConciliaciónSUAPropuestaToolStripMenuItem"
        Me.ConciliaciónSUAPropuestaToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ConciliaciónSUAPropuestaToolStripMenuItem.Text = "Conciliación SUA Propuesta"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(397, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ConciliacionContraSUAForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 493)
        Me.Controls.Add(Me.grdDatosConciliacion)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConciliacionContraSUAForm"
        Me.Text = "Conciliación Contra SUA"
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlLayout.ResumeLayout(False)
        Me.pnlLayout.PerformLayout()
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        CType(Me.grdDatosConciliacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvConciliacionSUA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents cmbBimestre As Windows.Forms.ComboBox
    Friend WithEvents numAnio As Windows.Forms.NumericUpDown
    Friend WithEvents lblMes As Windows.Forms.Label
    Friend WithEvents lblAnio As Windows.Forms.Label
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents lblNombre As Windows.Forms.Label
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents lblTipoReporte As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblEncabezado As Windows.Forms.Label
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblImprimir As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlLayout As Windows.Forms.Panel
    Friend WithEvents btnLayout As Windows.Forms.Button
    Friend WithEvents lblLayout As Windows.Forms.Label
    Friend WithEvents pnlImportar As Windows.Forms.Panel
    Friend WithEvents btnImportarDatos As Windows.Forms.Button
    Friend WithEvents lblCargarDatos As Windows.Forms.Label
    Friend WithEvents pnlAutorizar As Windows.Forms.Panel
    Friend WithEvents btnAutorizar As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents rdoBimestre As Windows.Forms.RadioButton
    Friend WithEvents rdoAcumulado As Windows.Forms.RadioButton
    Friend WithEvents pnlColaboradoresCargados As Windows.Forms.Panel
    Friend WithEvents btnSeleccionarColaborador As Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents grdDatosConciliacion As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents bgvConciliacionSUA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents pnlGuardar As Windows.Forms.Panel
    Friend WithEvents lblEnEdicion As Windows.Forms.Label
    Friend WithEvents lblColorEdicion As Windows.Forms.Label
    Friend WithEvents AyudaConciliaciónSUAToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConciliaciónSUAArchivoWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConciliaciónSUAPropuestaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblFechaActualizacion As Windows.Forms.Label
    Friend WithEvents lblUltimaActualizacion As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
