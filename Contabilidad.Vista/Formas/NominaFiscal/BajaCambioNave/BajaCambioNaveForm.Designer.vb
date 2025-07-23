<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BajaCambioNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BajaCambioNaveForm))
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBajaCambioNave = New System.Windows.Forms.Label()
        Me.pnlBajaCambioNave = New System.Windows.Forms.Panel()
        Me.btnBajaCambioNave = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.grdListado = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BajaPorCambioNaveYPatrónWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlBajaCambioNave.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuAyuda.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(56, 75)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 75)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1031, 136)
        Me.pnlFiltros.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(963, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 118
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 119
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(6, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 118
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Panel11)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblPatron)
        Me.grbFiltros.Controls.Add(Me.cmbNave)
        Me.grbFiltros.Controls.Add(Me.lblNave)
        Me.grbFiltros.Controls.Add(Me.Panel4)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1025, 110)
        Me.grbFiltros.TabIndex = 113
        Me.grbFiltros.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(511, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Asegurado"
        Me.Label1.Visible = False
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdoActivoNo)
        Me.Panel11.Controls.Add(Me.rdoActivoSi)
        Me.Panel11.Enabled = False
        Me.Panel11.Location = New System.Drawing.Point(575, 47)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(106, 23)
        Me.Panel11.TabIndex = 126
        Me.Panel11.Visible = False
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(62, 3)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 1
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 3)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 0
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(64, 82)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(410, 20)
        Me.txtNombre.TabIndex = 125
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(14, 85)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 124
        Me.lblNombre.Text = "Nombre"
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(64, 49)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(410, 21)
        Me.cmbPatron.TabIndex = 123
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.ForeColor = System.Drawing.Color.Black
        Me.lblPatron.Location = New System.Drawing.Point(20, 52)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(38, 13)
        Me.lblPatron.TabIndex = 122
        Me.lblPatron.Text = "Patrón"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(64, 16)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(410, 21)
        Me.cmbNave.TabIndex = 121
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(25, 19)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 120
        Me.lblNave.Text = "Nave"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnBuscar)
        Me.Panel4.Controls.Add(Me.lblLimpiar)
        Me.Panel4.Controls.Add(Me.lblBuscar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(923, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(99, 91)
        Me.Panel4.TabIndex = 119
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(59, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBajaCambioNave
        '
        Me.lblBajaCambioNave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBajaCambioNave.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBajaCambioNave.Location = New System.Drawing.Point(4, 40)
        Me.lblBajaCambioNave.Name = "lblBajaCambioNave"
        Me.lblBajaCambioNave.Size = New System.Drawing.Size(92, 29)
        Me.lblBajaCambioNave.TabIndex = 23
        Me.lblBajaCambioNave.Text = "Baja por Cambio de Nave"
        Me.lblBajaCambioNave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBajaCambioNave
        '
        Me.pnlBajaCambioNave.Controls.Add(Me.btnBajaCambioNave)
        Me.pnlBajaCambioNave.Controls.Add(Me.lblBajaCambioNave)
        Me.pnlBajaCambioNave.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBajaCambioNave.Location = New System.Drawing.Point(0, 0)
        Me.pnlBajaCambioNave.Name = "pnlBajaCambioNave"
        Me.pnlBajaCambioNave.Size = New System.Drawing.Size(97, 69)
        Me.pnlBajaCambioNave.TabIndex = 48
        '
        'btnBajaCambioNave
        '
        Me.btnBajaCambioNave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBajaCambioNave.Image = Global.Contabilidad.Vista.My.Resources.Resources.cancelar_32
        Me.btnBajaCambioNave.Location = New System.Drawing.Point(33, 5)
        Me.btnBajaCambioNave.Name = "btnBajaCambioNave"
        Me.btnBajaCambioNave.Size = New System.Drawing.Size(32, 32)
        Me.btnBajaCambioNave.TabIndex = 22
        Me.btnBajaCambioNave.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAyuda)
        Me.pnlEncabezado.Controls.Add(Me.pnlBajaCambioNave)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1031, 69)
        Me.pnlEncabezado.TabIndex = 15
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.lblAyuda)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(97, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(66, 69)
        Me.pnlAyuda.TabIndex = 127
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(16, 5)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(14, 40)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 8
        Me.lblAyuda.Text = "Ayuda"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(556, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(96, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(310, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Solicitud de Baja por Cambio de Nave"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEstado
        '
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(0, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(16, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 29
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(963, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(68, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(17, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblNota)
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 436)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1031, 60)
        Me.pnlPie.TabIndex = 16
        '
        'lblNota
        '
        Me.lblNota.AutoSize = True
        Me.lblNota.ForeColor = System.Drawing.Color.Red
        Me.lblNota.Location = New System.Drawing.Point(20, 24)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(621, 13)
        Me.lblNota.TabIndex = 25
        Me.lblNota.Text = "NOTA: No se podrá hacer cambio de colaboradores el día en que se cierre nómina ta" &
    "nto en la nave origen como en la de destino."
        Me.lblNota.Visible = False
        '
        'grdListado
        '
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 205)
        Me.grdListado.MainView = Me.GridView1
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1031, 231)
        Me.grdListado.TabIndex = 18
        Me.grdListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.BackColor2 = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.grdListado
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'menuAyuda
        '
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem, Me.BajaPorCambioNaveYPatrónWordToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(287, 48)
        '
        'AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem
        '
        Me.AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem.Name = "AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem"
        Me.AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem.Text = "Ayuda Solicitud de Baja por Cambio de Nave"
        '
        'BajaPorCambioNaveYPatrónWordToolStripMenuItem
        '
        Me.BajaPorCambioNaveYPatrónWordToolStripMenuItem.Name = "BajaPorCambioNaveYPatrónWordToolStripMenuItem"
        Me.BajaPorCambioNaveYPatrónWordToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.BajaPorCambioNaveYPatrónWordToolStripMenuItem.Text = "Baja por Cambio Nave y Patrón Word"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(403, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'BajaCambioNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1031, 496)
        Me.Controls.Add(Me.grdListado)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "BajaCambioNaveForm"
        Me.Text = "Baja por Cambio de Nave"
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlBajaCambioNave.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents lblBuscar As Windows.Forms.Label
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Friend WithEvents lblBajaCambioNave As Windows.Forms.Label
    Friend WithEvents btnBajaCambioNave As Windows.Forms.Button
    Friend WithEvents pnlBajaCambioNave As Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents cmbNave As Windows.Forms.ComboBox
    Friend WithEvents lblNave As Windows.Forms.Label
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents lblNombre As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel11 As Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As Windows.Forms.RadioButton
    Friend WithEvents grdListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents lblAyuda As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents AyudaSolicitudDeBajaPorCambioDeNaveToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BajaPorCambioNaveYPatrónWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
