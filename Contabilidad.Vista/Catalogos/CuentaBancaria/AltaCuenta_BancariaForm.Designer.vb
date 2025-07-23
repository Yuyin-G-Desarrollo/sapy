<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCuenta_BancariaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCuenta_BancariaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkFacturas = New System.Windows.Forms.CheckBox()
        Me.chkRemisiones = New System.Windows.Forms.CheckBox()
        Me.chkIncluyeCotizacion = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtClabeInterbancaria = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.cmbNumeroCuentaSICY = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnCuentaContpaq = New System.Windows.Forms.Button()
        Me.cmbCuentaContpaq = New System.Windows.Forms.ComboBox()
        Me.btnBancoContpaq = New System.Windows.Forms.Button()
        Me.lblBancoContpaq = New System.Windows.Forms.Label()
        Me.cmbBancoContpaq = New System.Windows.Forms.ComboBox()
        Me.lblCuentaContpaq = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.lblNumeroCuentaSicy = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.txtCuentahabiente = New System.Windows.Forms.TextBox()
        Me.lblCuentaHabiente = New System.Windows.Forms.Label()
        Me.txtNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.lblNumeroCuenta = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbNumeroCuentaSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlContenido)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(576, 539)
        Me.pnlContenedor.TabIndex = 2
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(576, 479)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox2)
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(576, 414)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.chkIncluyeCotizacion)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 71)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cotizaciones"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkFacturas)
        Me.GroupBox3.Controls.Add(Me.chkRemisiones)
        Me.GroupBox3.Location = New System.Drawing.Point(224, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(281, 47)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Documento"
        '
        'chkFacturas
        '
        Me.chkFacturas.AutoSize = True
        Me.chkFacturas.Location = New System.Drawing.Point(151, 19)
        Me.chkFacturas.Name = "chkFacturas"
        Me.chkFacturas.Size = New System.Drawing.Size(67, 17)
        Me.chkFacturas.TabIndex = 1
        Me.chkFacturas.Text = "Facturas"
        Me.chkFacturas.UseVisualStyleBackColor = True
        '
        'chkRemisiones
        '
        Me.chkRemisiones.AutoSize = True
        Me.chkRemisiones.Location = New System.Drawing.Point(17, 19)
        Me.chkRemisiones.Name = "chkRemisiones"
        Me.chkRemisiones.Size = New System.Drawing.Size(80, 17)
        Me.chkRemisiones.TabIndex = 0
        Me.chkRemisiones.Text = "Remisiones"
        Me.chkRemisiones.UseVisualStyleBackColor = True
        '
        'chkIncluyeCotizacion
        '
        Me.chkIncluyeCotizacion.AutoSize = True
        Me.chkIncluyeCotizacion.Location = New System.Drawing.Point(45, 32)
        Me.chkIncluyeCotizacion.Name = "chkIncluyeCotizacion"
        Me.chkIncluyeCotizacion.Size = New System.Drawing.Size(152, 17)
        Me.chkIncluyeCotizacion.TabIndex = 0
        Me.chkIncluyeCotizacion.Text = "Se incluye en la cotización"
        Me.chkIncluyeCotizacion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtClabeInterbancaria)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblMoneda)
        Me.GroupBox1.Controls.Add(Me.cmbMoneda)
        Me.GroupBox1.Controls.Add(Me.cmbNumeroCuentaSICY)
        Me.GroupBox1.Controls.Add(Me.btnCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.cmbCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.btnBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.lblBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.cmbBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.lblCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.lblBanco)
        Me.GroupBox1.Controls.Add(Me.cmbBanco)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCuentaSicy)
        Me.GroupBox1.Controls.Add(Me.lblRazonSocial)
        Me.GroupBox1.Controls.Add(Me.cmbRazonSocial)
        Me.GroupBox1.Controls.Add(Me.txtCuentahabiente)
        Me.GroupBox1.Controls.Add(Me.lblCuentaHabiente)
        Me.GroupBox1.Controls.Add(Me.txtNumeroCuenta)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCuenta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 284)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtClabeInterbancaria
        '
        Me.txtClabeInterbancaria.Location = New System.Drawing.Point(154, 255)
        Me.txtClabeInterbancaria.MaxLength = 50
        Me.txtClabeInterbancaria.Name = "txtClabeInterbancaria"
        Me.txtClabeInterbancaria.Size = New System.Drawing.Size(394, 20)
        Me.txtClabeInterbancaria.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Clabe interbancaria"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(15, 229)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(53, 13)
        Me.lblMoneda.TabIndex = 55
        Me.lblMoneda.Text = "* Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(154, 225)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(394, 21)
        Me.cmbMoneda.TabIndex = 54
        '
        'cmbNumeroCuentaSICY
        '
        Me.cmbNumeroCuentaSICY.AllowDrop = True
        Me.cmbNumeroCuentaSICY.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbNumeroCuentaSICY.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbNumeroCuentaSICY.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmbNumeroCuentaSICY.Location = New System.Drawing.Point(154, 107)
        Me.cmbNumeroCuentaSICY.Name = "cmbNumeroCuentaSICY"
        Me.cmbNumeroCuentaSICY.Size = New System.Drawing.Size(394, 19)
        Me.cmbNumeroCuentaSICY.TabIndex = 4
        '
        'btnCuentaContpaq
        '
        Me.btnCuentaContpaq.Enabled = False
        Me.btnCuentaContpaq.Image = CType(resources.GetObject("btnCuentaContpaq.Image"), System.Drawing.Image)
        Me.btnCuentaContpaq.Location = New System.Drawing.Point(526, 166)
        Me.btnCuentaContpaq.Name = "btnCuentaContpaq"
        Me.btnCuentaContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaContpaq.TabIndex = 6
        Me.btnCuentaContpaq.UseVisualStyleBackColor = True
        '
        'cmbCuentaContpaq
        '
        Me.cmbCuentaContpaq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbCuentaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaContpaq.Enabled = False
        Me.cmbCuentaContpaq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCuentaContpaq.FormattingEnabled = True
        Me.cmbCuentaContpaq.Location = New System.Drawing.Point(154, 165)
        Me.cmbCuentaContpaq.Name = "cmbCuentaContpaq"
        Me.cmbCuentaContpaq.Size = New System.Drawing.Size(366, 21)
        Me.cmbCuentaContpaq.TabIndex = 7
        '
        'btnBancoContpaq
        '
        Me.btnBancoContpaq.Enabled = False
        Me.btnBancoContpaq.Image = CType(resources.GetObject("btnBancoContpaq.Image"), System.Drawing.Image)
        Me.btnBancoContpaq.Location = New System.Drawing.Point(526, 196)
        Me.btnBancoContpaq.Name = "btnBancoContpaq"
        Me.btnBancoContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnBancoContpaq.TabIndex = 8
        Me.btnBancoContpaq.UseVisualStyleBackColor = True
        '
        'lblBancoContpaq
        '
        Me.lblBancoContpaq.AutoSize = True
        Me.lblBancoContpaq.Location = New System.Drawing.Point(15, 199)
        Me.lblBancoContpaq.Name = "lblBancoContpaq"
        Me.lblBancoContpaq.Size = New System.Drawing.Size(88, 13)
        Me.lblBancoContpaq.TabIndex = 53
        Me.lblBancoContpaq.Text = "* Banco Contpaq"
        '
        'cmbBancoContpaq
        '
        Me.cmbBancoContpaq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbBancoContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancoContpaq.Enabled = False
        Me.cmbBancoContpaq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBancoContpaq.FormattingEnabled = True
        Me.cmbBancoContpaq.Location = New System.Drawing.Point(154, 195)
        Me.cmbBancoContpaq.Name = "cmbBancoContpaq"
        Me.cmbBancoContpaq.Size = New System.Drawing.Size(366, 21)
        Me.cmbBancoContpaq.TabIndex = 8
        '
        'lblCuentaContpaq
        '
        Me.lblCuentaContpaq.AutoSize = True
        Me.lblCuentaContpaq.Location = New System.Drawing.Point(15, 169)
        Me.lblCuentaContpaq.Name = "lblCuentaContpaq"
        Me.lblCuentaContpaq.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContpaq.TabIndex = 49
        Me.lblCuentaContpaq.Text = "* Cuenta Contpaq"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Location = New System.Drawing.Point(15, 139)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(45, 13)
        Me.lblBanco.TabIndex = 36
        Me.lblBanco.Text = "* Banco"
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(154, 135)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(394, 21)
        Me.cmbBanco.TabIndex = 5
        '
        'lblNumeroCuentaSicy
        '
        Me.lblNumeroCuentaSicy.AutoSize = True
        Me.lblNumeroCuentaSicy.Location = New System.Drawing.Point(15, 110)
        Me.lblNumeroCuentaSicy.Name = "lblNumeroCuentaSicy"
        Me.lblNumeroCuentaSicy.Size = New System.Drawing.Size(130, 13)
        Me.lblNumeroCuentaSicy.TabIndex = 32
        Me.lblNumeroCuentaSicy.Text = "* Numero de Cuenta SICY"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(15, 81)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 30
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(154, 77)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(394, 21)
        Me.cmbRazonSocial.TabIndex = 3
        '
        'txtCuentahabiente
        '
        Me.txtCuentahabiente.Location = New System.Drawing.Point(154, 48)
        Me.txtCuentahabiente.MaxLength = 50
        Me.txtCuentahabiente.Name = "txtCuentahabiente"
        Me.txtCuentahabiente.Size = New System.Drawing.Size(394, 20)
        Me.txtCuentahabiente.TabIndex = 2
        '
        'lblCuentaHabiente
        '
        Me.lblCuentaHabiente.AutoSize = True
        Me.lblCuentaHabiente.Location = New System.Drawing.Point(15, 52)
        Me.lblCuentaHabiente.Name = "lblCuentaHabiente"
        Me.lblCuentaHabiente.Size = New System.Drawing.Size(89, 13)
        Me.lblCuentaHabiente.TabIndex = 28
        Me.lblCuentaHabiente.Text = "* Cuentahabiente"
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(154, 19)
        Me.txtNumeroCuenta.MaxLength = 30
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(394, 20)
        Me.txtNumeroCuenta.TabIndex = 1
        '
        'lblNumeroCuenta
        '
        Me.lblNumeroCuenta.AutoSize = True
        Me.lblNumeroCuenta.Location = New System.Drawing.Point(15, 23)
        Me.lblNumeroCuenta.Name = "lblNumeroCuenta"
        Me.lblNumeroCuenta.Size = New System.Drawing.Size(103, 13)
        Me.lblNumeroCuenta.TabIndex = 26
        Me.lblNumeroCuenta.Text = "* Numero de Cuenta"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 414)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(576, 65)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(459, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 65)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(67, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(67, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(13, 44)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(18, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(576, 60)
        Me.pnlCabecera.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(225, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(281, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(272, 36)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(111, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(161, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Cuentas Bancarias"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(506, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaCuenta_BancariaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 539)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaCuenta_BancariaForm"
        Me.Text = "Cuentas Bancarias"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbNumeroCuentaSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents pnlInformacionAlta As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumeroCuentaSicy As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents txtCuentahabiente As System.Windows.Forms.TextBox
    Friend WithEvents lblCuentaHabiente As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroCuenta As System.Windows.Forms.Label
    Friend WithEvents btnBancoContpaq As System.Windows.Forms.Button
    Friend WithEvents lblBancoContpaq As System.Windows.Forms.Label
    Friend WithEvents cmbBancoContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuentaContpaq As System.Windows.Forms.Label
    Friend WithEvents btnCuentaContpaq As System.Windows.Forms.Button
    Friend WithEvents cmbCuentaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNumeroCuentaSICY As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtClabeInterbancaria As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents chkFacturas As Windows.Forms.CheckBox
    Friend WithEvents chkRemisiones As Windows.Forms.CheckBox
    Friend WithEvents chkIncluyeCotizacion As Windows.Forms.CheckBox
End Class
