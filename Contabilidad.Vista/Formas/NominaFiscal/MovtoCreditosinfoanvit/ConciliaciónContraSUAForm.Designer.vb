<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConciliaciónContraSUAForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConciliaciónContraSUAForm))
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
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblRegistro = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdDatos = New DevExpress.XtraGrid.GridControl()
        Me.vwDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlLayout.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlFiltros.Size = New System.Drawing.Size(1021, 145)
        Me.pnlFiltros.TabIndex = 42
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(942, 5)
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
        Me.grbFiltros.Controls.Add(Me.pnlArchivoCargado)
        Me.grbFiltros.Controls.Add(Me.btnSeleccionarColaborador)
        Me.grbFiltros.Controls.Add(Me.RadioButton2)
        Me.grbFiltros.Controls.Add(Me.RadioButton1)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.cmbMes)
        Me.grbFiltros.Controls.Add(Me.numAnio)
        Me.grbFiltros.Controls.Add(Me.lblMes)
        Me.grbFiltros.Controls.Add(Me.lblAnio)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.Label14)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblPatron)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 25)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1018, 120)
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
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = CType(resources.GetObject("pnlArchivoCargado.BackgroundImage"), System.Drawing.Image)
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(513, 63)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 161
        Me.pnlArchivoCargado.Visible = False
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
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(613, 25)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton2.TabIndex = 159
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Bimestre"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(529, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton1.TabIndex = 158
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Acumulado"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(474, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Reporte*"
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.Black
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(267, 51)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(180, 21)
        Me.cmbMes.TabIndex = 156
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(62, 51)
        Me.numAnio.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(132, 20)
        Me.numAnio.TabIndex = 155
        Me.numAnio.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(214, 54)
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
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
        Me.pnlTitulo.Controls.Add(Me.lblEncabezado)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
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
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(401, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 69)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
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
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblRegistro)
        Me.pnlPie.Controls.Add(Me.lblTotal)
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 422)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1021, 71)
        Me.pnlPie.TabIndex = 77
        '
        'lblRegistro
        '
        Me.lblRegistro.AutoSize = True
        Me.lblRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblRegistro.Location = New System.Drawing.Point(12, 13)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(79, 16)
        Me.lblRegistro.TabIndex = 120
        Me.lblRegistro.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(12, 34)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(69, 18)
        Me.lblTotal.TabIndex = 119
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.Button1)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(904, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(71, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(74, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdDatos
        '
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(0, 214)
        Me.grdDatos.MainView = Me.vwDatos
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1021, 208)
        Me.grdDatos.TabIndex = 78
        Me.grdDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDatos})
        '
        'vwDatos
        '
        Me.vwDatos.GridControl = Me.grdDatos
        Me.vwDatos.Name = "vwDatos"
        Me.vwDatos.OptionsView.ShowAutoFilterRow = True
        Me.vwDatos.OptionsView.ShowFooter = True
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Button1.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(26, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Guardar"
        '
        'ConciliaciónContraSUAForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 493)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConciliaciónContraSUAForm"
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
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents cmbMes As Windows.Forms.ComboBox
    Friend WithEvents numAnio As Windows.Forms.NumericUpDown
    Friend WithEvents lblMes As Windows.Forms.Label
    Friend WithEvents lblAnio As Windows.Forms.Label
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblEncabezado As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
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
    Friend WithEvents RadioButton2 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As Windows.Forms.RadioButton
    Friend WithEvents pnlArchivoCargado As Windows.Forms.Panel
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
    Friend WithEvents lblRegistro As Windows.Forms.Label
    Friend WithEvents lblTotal As Windows.Forms.Label
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents grdDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
