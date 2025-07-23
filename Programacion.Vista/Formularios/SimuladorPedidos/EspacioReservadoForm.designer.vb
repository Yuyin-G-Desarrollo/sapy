<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EspacioReservadoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EspacioReservadoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCambiarFecha = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.grdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bntBuscaCliente = New System.Windows.Forms.Button()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtPares = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_asignados = New System.Windows.Forms.CheckBox()
        Me.chkSimulados = New System.Windows.Forms.CheckBox()
        Me.chkCancelados = New System.Windows.Forms.CheckBox()
        Me.chkActivos = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.chk_solo_especiales = New System.Windows.Forms.CheckBox()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGuardaEspacio = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbNaves.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtPares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.Label10)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.Label8)
        Me.pnlEncabezado.Controls.Add(Me.btnCambiarFecha)
        Me.pnlEncabezado.Controls.Add(Me.btnCancelar)
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1050, 59)
        Me.pnlEncabezado.TabIndex = 3
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(203, 5)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 34
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(195, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label9)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(777, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(273, 59)
        Me.pnlTitulo.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(23, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 20)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Espacio Reservado"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(205, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(38, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Cambiar Fecha"
        '
        'btnCambiarFecha
        '
        Me.btnCambiarFecha.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnCambiarFecha.Location = New System.Drawing.Point(61, 5)
        Me.btnCambiarFecha.Name = "btnCambiarFecha"
        Me.btnCambiarFecha.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarFecha.TabIndex = 31
        Me.btnCambiarFecha.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(139, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(131, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Cancelar"
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.grdDatos)
        Me.pnlPrincipal.Controls.Add(Me.grbNaves)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 59)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Padding = New System.Windows.Forms.Padding(11, 3, 11, 11)
        Me.pnlPrincipal.Size = New System.Drawing.Size(1050, 483)
        Me.pnlPrincipal.TabIndex = 4
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
        Me.grdDatos.Location = New System.Drawing.Point(11, 147)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1028, 325)
        Me.grdDatos.TabIndex = 1000
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.chkSeleccionar)
        Me.grbNaves.Controls.Add(Me.GroupBox2)
        Me.grbNaves.Controls.Add(Me.GroupBox1)
        Me.grbNaves.Controls.Add(Me.btnAbajo)
        Me.grbNaves.Controls.Add(Me.btnArriba)
        Me.grbNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbNaves.Location = New System.Drawing.Point(11, 3)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(1028, 144)
        Me.grbNaves.TabIndex = 0
        Me.grbNaves.TabStop = False
        '

        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(52, 162)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(115, 17)
        Me.chkSeleccionar.TabIndex = 15
        Me.chkSeleccionar.Text = "Seleccionar Todos"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '

        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(21, 125)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionar.TabIndex = 15
        Me.chkSeleccionar.Text = "Seleccionar todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '

        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bntBuscaCliente)
        Me.GroupBox2.Controls.Add(Me.dtpFechaEntrega)
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Controls.Add(Me.cmbNaves)
        Me.GroupBox2.Controls.Add(Me.lblClientes)
        Me.GroupBox2.Controls.Add(Me.lblNave)
        Me.GroupBox2.Controls.Add(Me.lblFecha)
        Me.GroupBox2.Controls.Add(Me.txtPares)
        Me.GroupBox2.Controls.Add(Me.lblPares)
        Me.GroupBox2.Location = New System.Drawing.Point(473, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(549, 104)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Alta de Espacio Reservado"
        '
        'bntBuscaCliente
        '
        Me.bntBuscaCliente.Image = Global.Programacion.Vista.My.Resources.Resources.buscacliente
        Me.bntBuscaCliente.Location = New System.Drawing.Point(492, 61)
        Me.bntBuscaCliente.Name = "bntBuscaCliente"
        Me.bntBuscaCliente.Size = New System.Drawing.Size(38, 38)
        Me.bntBuscaCliente.TabIndex = 14
        Me.bntBuscaCliente.UseVisualStyleBackColor = True
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(105, 45)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(91, 20)
        Me.dtpFechaEntrega.TabIndex = 11
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(105, 72)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(375, 20)
        Me.txtCliente.TabIndex = 13
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(105, 17)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(375, 21)
        Me.cmbNaves.TabIndex = 10
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Location = New System.Drawing.Point(42, 73)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(39, 13)
        Me.lblClientes.TabIndex = 2
        Me.lblClientes.Text = "Cliente"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNave.Location = New System.Drawing.Point(42, 21)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(42, 47)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha"
        '
        'txtPares
        '
        Me.txtPares.Location = New System.Drawing.Point(401, 45)
        Me.txtPares.MaskInput = "nnn,nnn,nnn"
        Me.txtPares.Name = "txtPares"
        Me.txtPares.Size = New System.Drawing.Size(79, 21)
        Me.txtPares.TabIndex = 12
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Location = New System.Drawing.Point(361, 47)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(34, 13)
        Me.lblPares.TabIndex = 7
        Me.lblPares.Text = "Pares"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_asignados)
        Me.GroupBox1.Controls.Add(Me.chkSimulados)
        Me.GroupBox1.Controls.Add(Me.chkCancelados)
        Me.GroupBox1.Controls.Add(Me.chkActivos)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkFechas)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.chk_solo_especiales)
        Me.GroupBox1.Controls.Add(Me.dtpFinal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 92)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'chk_asignados
        '
        Me.chk_asignados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_asignados.AutoSize = True
        Me.chk_asignados.Location = New System.Drawing.Point(323, 67)
        Me.chk_asignados.Name = "chk_asignados"
        Me.chk_asignados.Size = New System.Drawing.Size(75, 17)
        Me.chk_asignados.TabIndex = 9
        Me.chk_asignados.Text = "Asignados"
        Me.chk_asignados.UseVisualStyleBackColor = True
        '
        'chkSimulados
        '
        Me.chkSimulados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSimulados.AutoSize = True
        Me.chkSimulados.Location = New System.Drawing.Point(244, 67)
        Me.chkSimulados.Name = "chkSimulados"
        Me.chkSimulados.Size = New System.Drawing.Size(74, 17)
        Me.chkSimulados.TabIndex = 8
        Me.chkSimulados.Text = "Simulados"
        Me.chkSimulados.UseVisualStyleBackColor = True
        '
        'chkCancelados
        '
        Me.chkCancelados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCancelados.AutoSize = True
        Me.chkCancelados.Location = New System.Drawing.Point(156, 67)
        Me.chkCancelados.Name = "chkCancelados"
        Me.chkCancelados.Size = New System.Drawing.Size(82, 17)
        Me.chkCancelados.TabIndex = 7
        Me.chkCancelados.Text = "Cancelados"
        Me.chkCancelados.UseVisualStyleBackColor = True
        '
        'chkActivos
        '
        Me.chkActivos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivos.AutoSize = True
        Me.chkActivos.Checked = True
        Me.chkActivos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivos.Location = New System.Drawing.Point(89, 67)
        Me.chkActivos.Name = "chkActivos"
        Me.chkActivos.Size = New System.Drawing.Size(61, 17)
        Me.chkActivos.TabIndex = 6
        Me.chkActivos.Text = "Activos"
        Me.chkActivos.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Ver"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Del"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(43, 17)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(61, 17)
        Me.chkFechas.TabIndex = 1
        Me.chkFechas.Text = "Fechas"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(156, 15)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(89, 20)
        Me.dtpInicio.TabIndex = 1
        '
        'chk_solo_especiales
        '
        Me.chk_solo_especiales.AutoSize = True
        Me.chk_solo_especiales.Checked = True
        Me.chk_solo_especiales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_solo_especiales.Location = New System.Drawing.Point(43, 41)
        Me.chk_solo_especiales.Name = "chk_solo_especiales"
        Me.chk_solo_especiales.Size = New System.Drawing.Size(139, 17)
        Me.chk_solo_especiales.TabIndex = 4
        Me.chk_solo_especiales.Text = "Solo clientes especiales"
        Me.chk_solo_especiales.UseVisualStyleBackColor = True
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(285, 15)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(89, 20)
        Me.dtpFinal.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Al"
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(996, 11)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 11
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(965, 11)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 10
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 542)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1050, 67)
        Me.pnlExtado.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGuardaEspacio)
        Me.Panel1.Controls.Add(Me.lblExportarExcel)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.lblActualizar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(661, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 67)
        Me.Panel1.TabIndex = 0
        '
        'btnGuardaEspacio
        '
        Me.btnGuardaEspacio.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardaEspacio.Location = New System.Drawing.Point(213, 12)
        Me.btnGuardaEspacio.Name = "btnGuardaEspacio"
        Me.btnGuardaEspacio.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardaEspacio.TabIndex = 15
        Me.btnGuardaEspacio.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(208, 45)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(48, 13)
        Me.lblExportarExcel.TabIndex = 27

        Me.lblExportarExcel.Text = "Guardar Espacio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reservado"

        Me.lblExportarExcel.Text = "Guardar "

        Me.lblExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(276, 12)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 16
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(271, 45)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(42, 13)
        Me.lblActualizar.TabIndex = 25
        Me.lblActualizar.Text = "Mostrar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(337, 45)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Button3
        '
        Me.Button3.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.Button3.Location = New System.Drawing.Point(338, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 17
        Me.Button3.UseVisualStyleBackColor = True
        '
        'EspacioReservadoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1050, 609)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EspacioReservadoForm"
        Me.Text = "Espacio Reservado"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbNaves.ResumeLayout(False)
        Me.grbNaves.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtPares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents bntBuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents txtPares As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chk_solo_especiales As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCambiarFecha As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnGuardaEspacio As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_asignados As System.Windows.Forms.CheckBox
    Friend WithEvents chkSimulados As System.Windows.Forms.CheckBox
    Friend WithEvents chkCancelados As System.Windows.Forms.CheckBox
    Friend WithEvents chkActivos As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
End Class
