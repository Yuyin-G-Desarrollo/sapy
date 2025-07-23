<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosAjusteSPEMensualForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatosAjusteSPEMensualForm))
        Me.grdDatos = New DevExpress.XtraGrid.GridControl()
        Me.vwDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblEnEdicion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.btnImportarDatos = New System.Windows.Forms.Button()
        Me.lblCargarDatos = New System.Windows.Forms.Label()
        Me.pnlLayout = New System.Windows.Forms.Panel()
        Me.btnLayout = New System.Windows.Forms.Button()
        Me.lblLayout = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaDatosAjusteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosAjusteArchivoWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosAjustePropuestaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlLayout.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.menuAyuda.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(0, 193)
        Me.grdDatos.MainView = Me.vwDatos
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1020, 282)
        Me.grdDatos.TabIndex = 37
        Me.grdDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDatos})
        '
        'vwDatos
        '
        Me.vwDatos.GridControl = Me.grdDatos
        Me.vwDatos.Name = "vwDatos"
        Me.vwDatos.OptionsView.ShowAutoFilterRow = True
        Me.vwDatos.OptionsView.ShowFooter = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblEnEdicion)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 475)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 65)
        Me.pnlEstado.TabIndex = 36
        '
        'lblEnEdicion
        '
        Me.lblEnEdicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnEdicion.AutoSize = True
        Me.lblEnEdicion.ForeColor = System.Drawing.Color.Black
        Me.lblEnEdicion.Location = New System.Drawing.Point(27, 16)
        Me.lblEnEdicion.Name = "lblEnEdicion"
        Me.lblEnEdicion.Size = New System.Drawing.Size(99, 13)
        Me.lblEnEdicion.TabIndex = 39
        Me.lblEnEdicion.Text = "Registro en Edición"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 38
        Me.Label2.UseMnemonic = False
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.pnlGuardar)
        Me.pnlOperaciones.Controls.Add(Me.pnlCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(740, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(280, 65)
        Me.pnlOperaciones.TabIndex = 37
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(160, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(60, 65)
        Me.pnlGuardar.TabIndex = 105
        Me.pnlGuardar.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(14, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(8, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 21
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(220, 0)
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
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.cmbMes)
        Me.grbFiltros.Controls.Add(Me.numAnio)
        Me.grbFiltros.Controls.Add(Me.lblMes)
        Me.grbFiltros.Controls.Add(Me.lblAnio)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.Label14)
        Me.grbFiltros.Controls.Add(Me.Panel10)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblPatron)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 23)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1014, 95)
        Me.grbFiltros.TabIndex = 35
        Me.grbFiltros.TabStop = False
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ForeColor = System.Drawing.Color.Black
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(520, 55)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(111, 21)
        Me.cmbMes.TabIndex = 156
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(520, 24)
        Me.numAnio.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(111, 20)
        Me.numAnio.TabIndex = 155
        Me.numAnio.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(478, 55)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(27, 13)
        Me.lblMes.TabIndex = 149
        Me.lblMes.Text = "Mes"
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(479, 26)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(26, 13)
        Me.lblAnio.TabIndex = 148
        Me.lblAnio.Text = "Año"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(62, 59)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(385, 20)
        Me.txtNombre.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
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
        Me.lblPatron.Location = New System.Drawing.Point(13, 28)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(38, 13)
        Me.lblPatron.TabIndex = 25
        Me.lblPatron.Text = "Patrón"
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
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 69)
        Me.pnlHeader.TabIndex = 34
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.Label3)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(336, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(66, 69)
        Me.pnlAyuda.TabIndex = 113
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
        Me.pnlTitulo.Location = New System.Drawing.Point(622, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 69)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(66, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(225, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Datos Ajuste SPE Mensual"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1020, 124)
        Me.pnlFiltros.TabIndex = 38
        '
        'menuAyuda
        '
        Me.menuAyuda.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaDatosAjusteToolStripMenuItem, Me.DatosAjusteArchivoWordToolStripMenuItem, Me.DatosAjustePropuestaToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(205, 70)
        '
        'AyudaDatosAjusteToolStripMenuItem
        '
        Me.AyudaDatosAjusteToolStripMenuItem.Name = "AyudaDatosAjusteToolStripMenuItem"
        Me.AyudaDatosAjusteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AyudaDatosAjusteToolStripMenuItem.Text = "Ayuda Datos Ajuste"
        '
        'DatosAjusteArchivoWordToolStripMenuItem
        '
        Me.DatosAjusteArchivoWordToolStripMenuItem.Name = "DatosAjusteArchivoWordToolStripMenuItem"
        Me.DatosAjusteArchivoWordToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DatosAjusteArchivoWordToolStripMenuItem.Text = "Datos Ajuste Archivo Word"
        '
        'DatosAjustePropuestaToolStripMenuItem
        '
        Me.DatosAjustePropuestaToolStripMenuItem.Name = "DatosAjustePropuestaToolStripMenuItem"
        Me.DatosAjustePropuestaToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DatosAjustePropuestaToolStripMenuItem.Text = "Datos Ajuste Propuesta"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(326, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'DatosAjusteSPEMensualForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 540)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MinimumSize = New System.Drawing.Size(1024, 567)
        Me.Name = "DatosAjusteSPEMensualForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlLayout.ResumeLayout(False)
        Me.pnlLayout.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents pnlGuardar As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents pnlCerrar As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents lblMes As Windows.Forms.Label
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As Windows.Forms.Panel
    Friend WithEvents btnAutorizar As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlImportar As Windows.Forms.Panel
    Friend WithEvents btnImportarDatos As Windows.Forms.Button
    Friend WithEvents lblCargarDatos As Windows.Forms.Label
    Friend WithEvents pnlLayout As Windows.Forms.Panel
    Friend WithEvents btnLayout As Windows.Forms.Button
    Friend WithEvents lblLayout As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblImprimir As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblEncabezado As Windows.Forms.Label
    Friend WithEvents lblAnio As Windows.Forms.Label
    Friend WithEvents numAnio As Windows.Forms.NumericUpDown
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents cmbMes As Windows.Forms.ComboBox
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents lblEnEdicion As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents AyudaDatosAjusteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatosAjusteArchivoWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatosAjustePropuestaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
