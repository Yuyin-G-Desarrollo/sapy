<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrodeCuentasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrodeCuentasForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.onlSize = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.rdoETodos = New System.Windows.Forms.RadioButton()
        Me.panelFecha = New System.Windows.Forms.Panel()
        Me.dtpFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoMTodos = New System.Windows.Forms.RadioButton()
        Me.rdoSoloconCuenta = New System.Windows.Forms.RadioButton()
        Me.rdoSinCuneta = New System.Windows.Forms.RadioButton()
        Me.rdoInactivos = New System.Windows.Forms.RadioButton()
        Me.rdoActivos = New System.Windows.Forms.RadioButton()
        Me.lblTipoCta = New System.Windows.Forms.Label()
        Me.cboAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cboTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlColorCambios = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlColorNoExiste = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlColorSiExiste = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdDatos = New DevExpress.XtraGrid.GridControl()
        Me.grdVDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.onlSize.SuspendLayout()
        Me.gboxFiltros.SuspendLayout()
        Me.panelFecha.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblExportar)
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Panel2)
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1183, 60)
        Me.pnlListaPaises.TabIndex = 9
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(13, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 157
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(20, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 156
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(662, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(451, 60)
        Me.Panel2.TabIndex = 12
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(271, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 22
        Me.lblTitulo.Text = "Registro de Cuentas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(1113, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.onlSize)
        Me.pnlFiltros.Controls.Add(Me.gboxFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1183, 146)
        Me.pnlFiltros.TabIndex = 16
        '
        'onlSize
        '
        Me.onlSize.Controls.Add(Me.btnMostrar)
        Me.onlSize.Controls.Add(Me.lblBuscar)
        Me.onlSize.Controls.Add(Me.btnLimpiar)
        Me.onlSize.Controls.Add(Me.lblLimpiar)
        Me.onlSize.Dock = System.Windows.Forms.DockStyle.Right
        Me.onlSize.Location = New System.Drawing.Point(1073, 0)
        Me.onlSize.Name = "onlSize"
        Me.onlSize.Size = New System.Drawing.Size(110, 146)
        Me.onlSize.TabIndex = 24
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(17, 13)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(12, 47)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(66, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(63, 48)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.rdoETodos)
        Me.gboxFiltros.Controls.Add(Me.panelFecha)
        Me.gboxFiltros.Controls.Add(Me.GroupBox1)
        Me.gboxFiltros.Controls.Add(Me.rdoInactivos)
        Me.gboxFiltros.Controls.Add(Me.rdoActivos)
        Me.gboxFiltros.Controls.Add(Me.lblTipoCta)
        Me.gboxFiltros.Controls.Add(Me.cboAlmacen)
        Me.gboxFiltros.Controls.Add(Me.lblAlmacen)
        Me.gboxFiltros.Controls.Add(Me.Label4)
        Me.gboxFiltros.Controls.Add(Me.txtDescripcion)
        Me.gboxFiltros.Controls.Add(Me.cboTipoCuenta)
        Me.gboxFiltros.Controls.Add(Me.Label2)
        Me.gboxFiltros.Controls.Add(Me.cboEmpresa)
        Me.gboxFiltros.Controls.Add(Me.lblRazonSocial)
        Me.gboxFiltros.Location = New System.Drawing.Point(12, 6)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(1055, 131)
        Me.gboxFiltros.TabIndex = 13
        Me.gboxFiltros.TabStop = False
        '
        'rdoETodos
        '
        Me.rdoETodos.AutoSize = True
        Me.rdoETodos.Checked = True
        Me.rdoETodos.Location = New System.Drawing.Point(100, 80)
        Me.rdoETodos.Name = "rdoETodos"
        Me.rdoETodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoETodos.TabIndex = 107
        Me.rdoETodos.TabStop = True
        Me.rdoETodos.Text = "Todos"
        Me.rdoETodos.UseVisualStyleBackColor = True
        '
        'panelFecha
        '
        Me.panelFecha.Controls.Add(Me.dtpFechaDel)
        Me.panelFecha.Controls.Add(Me.dtpFechaAl)
        Me.panelFecha.Controls.Add(Me.Label6)
        Me.panelFecha.Controls.Add(Me.Label7)
        Me.panelFecha.Location = New System.Drawing.Point(720, 12)
        Me.panelFecha.Name = "panelFecha"
        Me.panelFecha.Size = New System.Drawing.Size(266, 77)
        Me.panelFecha.TabIndex = 106
        Me.panelFecha.Visible = False
        '
        'dtpFechaDel
        '
        Me.dtpFechaDel.Location = New System.Drawing.Point(51, 10)
        Me.dtpFechaDel.Name = "dtpFechaDel"
        Me.dtpFechaDel.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaDel.TabIndex = 33
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.Location = New System.Drawing.Point(49, 39)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(202, 20)
        Me.dtpFechaAl.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Del:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(26, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Al:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoMTodos)
        Me.GroupBox1.Controls.Add(Me.rdoSoloconCuenta)
        Me.GroupBox1.Controls.Add(Me.rdoSinCuneta)
        Me.GroupBox1.Location = New System.Drawing.Point(454, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 72)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mostrar"
        '
        'rdoMTodos
        '
        Me.rdoMTodos.AutoSize = True
        Me.rdoMTodos.Checked = True
        Me.rdoMTodos.Location = New System.Drawing.Point(11, 20)
        Me.rdoMTodos.Name = "rdoMTodos"
        Me.rdoMTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoMTodos.TabIndex = 102
        Me.rdoMTodos.TabStop = True
        Me.rdoMTodos.Text = "Todos"
        Me.rdoMTodos.UseVisualStyleBackColor = True
        '
        'rdoSoloconCuenta
        '
        Me.rdoSoloconCuenta.AutoSize = True
        Me.rdoSoloconCuenta.Location = New System.Drawing.Point(11, 46)
        Me.rdoSoloconCuenta.Name = "rdoSoloconCuenta"
        Me.rdoSoloconCuenta.Size = New System.Drawing.Size(104, 17)
        Me.rdoSoloconCuenta.TabIndex = 101
        Me.rdoSoloconCuenta.Text = "Solo con Cuenta"
        Me.rdoSoloconCuenta.UseVisualStyleBackColor = True
        '
        'rdoSinCuneta
        '
        Me.rdoSinCuneta.AutoSize = True
        Me.rdoSinCuneta.Location = New System.Drawing.Point(137, 46)
        Me.rdoSinCuneta.Name = "rdoSinCuneta"
        Me.rdoSinCuneta.Size = New System.Drawing.Size(77, 17)
        Me.rdoSinCuneta.TabIndex = 100
        Me.rdoSinCuneta.Text = "Sin Cuenta"
        Me.rdoSinCuneta.UseVisualStyleBackColor = True
        '
        'rdoInactivos
        '
        Me.rdoInactivos.AutoSize = True
        Me.rdoInactivos.Location = New System.Drawing.Point(245, 80)
        Me.rdoInactivos.Name = "rdoInactivos"
        Me.rdoInactivos.Size = New System.Drawing.Size(68, 17)
        Me.rdoInactivos.TabIndex = 104
        Me.rdoInactivos.Text = "Inactivos"
        Me.rdoInactivos.UseVisualStyleBackColor = True
        '
        'rdoActivos
        '
        Me.rdoActivos.AutoSize = True
        Me.rdoActivos.Location = New System.Drawing.Point(173, 80)
        Me.rdoActivos.Name = "rdoActivos"
        Me.rdoActivos.Size = New System.Drawing.Size(60, 17)
        Me.rdoActivos.TabIndex = 103
        Me.rdoActivos.Text = "Activos"
        Me.rdoActivos.UseVisualStyleBackColor = True
        '
        'lblTipoCta
        '
        Me.lblTipoCta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTipoCta.Location = New System.Drawing.Point(711, 102)
        Me.lblTipoCta.Name = "lblTipoCta"
        Me.lblTipoCta.Size = New System.Drawing.Size(84, 18)
        Me.lblTipoCta.TabIndex = 99
        Me.lblTipoCta.Text = "..."
        Me.lblTipoCta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTipoCta.Visible = False
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.FormattingEnabled = True
        Me.cboAlmacen.Location = New System.Drawing.Point(508, 90)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(186, 21)
        Me.cboAlmacen.TabIndex = 31
        Me.cboAlmacen.Visible = False
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.ForeColor = System.Drawing.Color.Black
        Me.lblAlmacen.Location = New System.Drawing.Point(451, 93)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(51, 13)
        Me.lblAlmacen.TabIndex = 32
        Me.lblAlmacen.Text = "Almacén:"
        Me.lblAlmacen.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Estatus:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(801, 105)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(181, 20)
        Me.txtDescripcion.TabIndex = 28
        Me.txtDescripcion.Visible = False
        '
        'cboTipoCuenta
        '
        Me.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCuenta.FormattingEnabled = True
        Me.cboTipoCuenta.Location = New System.Drawing.Point(100, 51)
        Me.cboTipoCuenta.Name = "cboTipoCuenta"
        Me.cboTipoCuenta.Size = New System.Drawing.Size(319, 21)
        Me.cboTipoCuenta.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tipo Cuenta:"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(100, 21)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(319, 21)
        Me.cboEmpresa.TabIndex = 18
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblRazonSocial.Location = New System.Drawing.Point(31, 24)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(51, 13)
        Me.lblRazonSocial.TabIndex = 20
        Me.lblRazonSocial.Text = "Empresa:"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.pnlColorCambios)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlColorNoExiste)
        Me.pnlPie.Controls.Add(Me.Label10)
        Me.pnlPie.Controls.Add(Me.pnlColorSiExiste)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 427)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1183, 71)
        Me.pnlPie.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(273, 13)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "El registro ha sufrido cambios y se actualizara al guardar."
        '
        'pnlColorCambios
        '
        Me.pnlColorCambios.BackColor = System.Drawing.Color.LightGreen
        Me.pnlColorCambios.ForeColor = System.Drawing.Color.Black
        Me.pnlColorCambios.Location = New System.Drawing.Point(202, 11)
        Me.pnlColorCambios.Name = "pnlColorCambios"
        Me.pnlColorCambios.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorCambios.TabIndex = 173
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "El registro no existe."
        '
        'pnlColorNoExiste
        '
        Me.pnlColorNoExiste.BackColor = System.Drawing.Color.Coral
        Me.pnlColorNoExiste.ForeColor = System.Drawing.Color.Black
        Me.pnlColorNoExiste.Location = New System.Drawing.Point(27, 30)
        Me.pnlColorNoExiste.Name = "pnlColorNoExiste"
        Me.pnlColorNoExiste.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorNoExiste.TabIndex = 171
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "El registro ya existe."
        '
        'pnlColorSiExiste
        '
        Me.pnlColorSiExiste.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlColorSiExiste.ForeColor = System.Drawing.Color.Black
        Me.pnlColorSiExiste.Location = New System.Drawing.Point(28, 11)
        Me.pnlColorSiExiste.Name = "pnlColorSiExiste"
        Me.pnlColorSiExiste.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorSiExiste.TabIndex = 169
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.BackColor = System.Drawing.Color.White
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(998, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(185, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(75, 11)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(70, 45)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(131, 11)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(129, 45)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdDatos
        '
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(0, 206)
        Me.grdDatos.MainView = Me.grdVDatos
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(1183, 221)
        Me.grdDatos.TabIndex = 18
        Me.grdDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVDatos})
        '
        'grdVDatos
        '
        Me.grdVDatos.GridControl = Me.grdDatos
        Me.grdVDatos.Name = "grdVDatos"
        Me.grdVDatos.OptionsView.ShowAutoFilterRow = True
        '
        'RegistrodeCuentasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 498)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "RegistrodeCuentasForm"
        Me.Text = "RegistrodeCuentasForm"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.onlSize.ResumeLayout(False)
        Me.onlSize.PerformLayout()
        Me.gboxFiltros.ResumeLayout(False)
        Me.gboxFiltros.PerformLayout()
        Me.panelFecha.ResumeLayout(False)
        Me.panelFecha.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents onlSize As System.Windows.Forms.Panel
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblTipoCta As System.Windows.Forms.Label
    Friend WithEvents rdoActivos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSoloconCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSinCuneta As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoInactivos As System.Windows.Forms.RadioButton
    Friend WithEvents panelFecha As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents rdoETodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlColorCambios As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlColorNoExiste As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlColorSiExiste As System.Windows.Forms.Panel
End Class
