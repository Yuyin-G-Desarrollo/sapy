<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCuentaGeneralForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCuentaGeneralForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.gpbDatosCuentaGral = New System.Windows.Forms.GroupBox()
        Me.cmbTipoPolizaContpaq = New System.Windows.Forms.ComboBox()
        Me.cmbCuentaBancaria = New System.Windows.Forms.ComboBox()
        Me.btnTipoPolizaContpaq = New System.Windows.Forms.Button()
        Me.lblTipoPolizaContpaq = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.btnCuentaBancaria = New System.Windows.Forms.Button()
        Me.lblCuentaBancaria = New System.Windows.Forms.Label()
        Me.btnCuentaContpaq = New System.Windows.Forms.Button()
        Me.btnCuentaSAY = New System.Windows.Forms.Button()
        Me.lblCuentaContpaq = New System.Windows.Forms.Label()
        Me.cmbCuentaContpaq = New System.Windows.Forms.ComboBox()
        Me.lblCuentaSAY = New System.Windows.Forms.Label()
        Me.cmbCuentaSAY = New System.Windows.Forms.ComboBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombreCuenta = New System.Windows.Forms.TextBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.txtNumCuenta = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblTipoPoliza = New System.Windows.Forms.Label()
        Me.cmbTipoPoliza = New System.Windows.Forms.ComboBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEncabezadoTextoDerecha = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.gpbDatosCuentaGral.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezadoTextoDerecha.SuspendLayout()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(561, 496)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(561, 436)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.gpbDatosCuentaGral)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(561, 365)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'gpbDatosCuentaGral
        '
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbTipoPolizaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbCuentaBancaria)
        Me.gpbDatosCuentaGral.Controls.Add(Me.btnTipoPolizaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblTipoPolizaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblClave)
        Me.gpbDatosCuentaGral.Controls.Add(Me.txtClave)
        Me.gpbDatosCuentaGral.Controls.Add(Me.btnCuentaBancaria)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblCuentaBancaria)
        Me.gpbDatosCuentaGral.Controls.Add(Me.btnCuentaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.btnCuentaSAY)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblCuentaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbCuentaContpaq)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblCuentaSAY)
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbCuentaSAY)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblNombre)
        Me.gpbDatosCuentaGral.Controls.Add(Me.txtNombreCuenta)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblCuenta)
        Me.gpbDatosCuentaGral.Controls.Add(Me.txtNumCuenta)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblRazonSocial)
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbEmpresa)
        Me.gpbDatosCuentaGral.Controls.Add(Me.lblTipoPoliza)
        Me.gpbDatosCuentaGral.Controls.Add(Me.cmbTipoPoliza)
        Me.gpbDatosCuentaGral.Location = New System.Drawing.Point(15, 6)
        Me.gpbDatosCuentaGral.Name = "gpbDatosCuentaGral"
        Me.gpbDatosCuentaGral.Size = New System.Drawing.Size(534, 322)
        Me.gpbDatosCuentaGral.TabIndex = 7
        Me.gpbDatosCuentaGral.TabStop = False
        '
        'cmbTipoPolizaContpaq
        '
        Me.cmbTipoPolizaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipoPolizaContpaq.Enabled = False
        Me.cmbTipoPolizaContpaq.FormattingEnabled = True
        Me.cmbTipoPolizaContpaq.Location = New System.Drawing.Point(132, 288)
        Me.cmbTipoPolizaContpaq.Name = "cmbTipoPolizaContpaq"
        Me.cmbTipoPolizaContpaq.Size = New System.Drawing.Size(353, 21)
        Me.cmbTipoPolizaContpaq.TabIndex = 0
        '
        'cmbCuentaBancaria
        '
        Me.cmbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCuentaBancaria.Enabled = False
        Me.cmbCuentaBancaria.FormattingEnabled = True
        Me.cmbCuentaBancaria.Location = New System.Drawing.Point(132, 256)
        Me.cmbCuentaBancaria.Name = "cmbCuentaBancaria"
        Me.cmbCuentaBancaria.Size = New System.Drawing.Size(353, 21)
        Me.cmbCuentaBancaria.TabIndex = 0
        '
        'btnTipoPolizaContpaq
        '
        Me.btnTipoPolizaContpaq.Enabled = False
        Me.btnTipoPolizaContpaq.Image = CType(resources.GetObject("btnTipoPolizaContpaq.Image"), System.Drawing.Image)
        Me.btnTipoPolizaContpaq.Location = New System.Drawing.Point(491, 288)
        Me.btnTipoPolizaContpaq.Name = "btnTipoPolizaContpaq"
        Me.btnTipoPolizaContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnTipoPolizaContpaq.TabIndex = 9
        Me.btnTipoPolizaContpaq.UseVisualStyleBackColor = True
        '
        'lblTipoPolizaContpaq
        '
        Me.lblTipoPolizaContpaq.AutoSize = True
        Me.lblTipoPolizaContpaq.Location = New System.Drawing.Point(6, 291)
        Me.lblTipoPolizaContpaq.Name = "lblTipoPolizaContpaq"
        Me.lblTipoPolizaContpaq.Size = New System.Drawing.Size(102, 13)
        Me.lblTipoPolizaContpaq.TabIndex = 49
        Me.lblTipoPolizaContpaq.Text = "Tipo Poliza Contpaq"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(7, 222)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 47
        Me.lblClave.Text = "Clave"
        '
        'txtClave
        '
        Me.txtClave.Enabled = False
        Me.txtClave.Location = New System.Drawing.Point(132, 219)
        Me.txtClave.MaxLength = 250
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(381, 20)
        Me.txtClave.TabIndex = 7
        '
        'btnCuentaBancaria
        '
        Me.btnCuentaBancaria.Enabled = False
        Me.btnCuentaBancaria.Image = CType(resources.GetObject("btnCuentaBancaria.Image"), System.Drawing.Image)
        Me.btnCuentaBancaria.Location = New System.Drawing.Point(491, 256)
        Me.btnCuentaBancaria.Name = "btnCuentaBancaria"
        Me.btnCuentaBancaria.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaBancaria.TabIndex = 8
        Me.btnCuentaBancaria.UseVisualStyleBackColor = True
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(7, 259)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(86, 13)
        Me.lblCuentaBancaria.TabIndex = 44
        Me.lblCuentaBancaria.Text = "Cuenta Bancaria"
        '
        'btnCuentaContpaq
        '
        Me.btnCuentaContpaq.Enabled = False
        Me.btnCuentaContpaq.Image = CType(resources.GetObject("btnCuentaContpaq.Image"), System.Drawing.Image)
        Me.btnCuentaContpaq.Location = New System.Drawing.Point(491, 123)
        Me.btnCuentaContpaq.Name = "btnCuentaContpaq"
        Me.btnCuentaContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaContpaq.TabIndex = 4
        Me.btnCuentaContpaq.UseVisualStyleBackColor = True
        '
        'btnCuentaSAY
        '
        Me.btnCuentaSAY.Enabled = False
        Me.btnCuentaSAY.Image = CType(resources.GetObject("btnCuentaSAY.Image"), System.Drawing.Image)
        Me.btnCuentaSAY.Location = New System.Drawing.Point(491, 92)
        Me.btnCuentaSAY.Name = "btnCuentaSAY"
        Me.btnCuentaSAY.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaSAY.TabIndex = 3
        Me.btnCuentaSAY.UseVisualStyleBackColor = True
        '
        'lblCuentaContpaq
        '
        Me.lblCuentaContpaq.AutoSize = True
        Me.lblCuentaContpaq.Location = New System.Drawing.Point(7, 126)
        Me.lblCuentaContpaq.Name = "lblCuentaContpaq"
        Me.lblCuentaContpaq.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContpaq.TabIndex = 40
        Me.lblCuentaContpaq.Text = "* Cuenta Contpaq"
        '
        'cmbCuentaContpaq
        '
        Me.cmbCuentaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCuentaContpaq.Enabled = False
        Me.cmbCuentaContpaq.FormattingEnabled = True
        Me.cmbCuentaContpaq.Location = New System.Drawing.Point(132, 123)
        Me.cmbCuentaContpaq.Name = "cmbCuentaContpaq"
        Me.cmbCuentaContpaq.Size = New System.Drawing.Size(353, 21)
        Me.cmbCuentaContpaq.TabIndex = 0
        '
        'lblCuentaSAY
        '
        Me.lblCuentaSAY.AutoSize = True
        Me.lblCuentaSAY.Location = New System.Drawing.Point(7, 95)
        Me.lblCuentaSAY.Name = "lblCuentaSAY"
        Me.lblCuentaSAY.Size = New System.Drawing.Size(72, 13)
        Me.lblCuentaSAY.TabIndex = 38
        Me.lblCuentaSAY.Text = "* Cuenta SAY"
        '
        'cmbCuentaSAY
        '
        Me.cmbCuentaSAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCuentaSAY.Enabled = False
        Me.cmbCuentaSAY.FormattingEnabled = True
        Me.cmbCuentaSAY.Location = New System.Drawing.Point(132, 92)
        Me.cmbCuentaSAY.Name = "cmbCuentaSAY"
        Me.cmbCuentaSAY.Size = New System.Drawing.Size(353, 21)
        Me.cmbCuentaSAY.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(7, 194)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 36
        Me.lblNombre.Text = "* Nombre"
        '
        'txtNombreCuenta
        '
        Me.txtNombreCuenta.Enabled = False
        Me.txtNombreCuenta.Location = New System.Drawing.Point(132, 189)
        Me.txtNombreCuenta.MaxLength = 250
        Me.txtNombreCuenta.Name = "txtNombreCuenta"
        Me.txtNombreCuenta.Size = New System.Drawing.Size(381, 20)
        Me.txtNombreCuenta.TabIndex = 6
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(7, 159)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(48, 13)
        Me.lblCuenta.TabIndex = 34
        Me.lblCuenta.Text = "* Cuenta"
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.Enabled = False
        Me.txtNumCuenta.Location = New System.Drawing.Point(132, 156)
        Me.txtNumCuenta.MaxLength = 11
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.Size = New System.Drawing.Size(185, 20)
        Me.txtNumCuenta.TabIndex = 5
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(6, 26)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 32
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(132, 22)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(381, 21)
        Me.cmbEmpresa.TabIndex = 1
        '
        'lblTipoPoliza
        '
        Me.lblTipoPoliza.AutoSize = True
        Me.lblTipoPoliza.Location = New System.Drawing.Point(6, 57)
        Me.lblTipoPoliza.Name = "lblTipoPoliza"
        Me.lblTipoPoliza.Size = New System.Drawing.Size(66, 13)
        Me.lblTipoPoliza.TabIndex = 30
        Me.lblTipoPoliza.Text = "* Tipo Poliza"
        '
        'cmbTipoPoliza
        '
        Me.cmbTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPoliza.FormattingEnabled = True
        Me.cmbTipoPoliza.Location = New System.Drawing.Point(132, 53)
        Me.cmbTipoPoliza.Name = "cmbTipoPoliza"
        Me.cmbTipoPoliza.Size = New System.Drawing.Size(381, 21)
        Me.cmbTipoPoliza.TabIndex = 2
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 365)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(561, 71)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(444, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(64, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(64, 48)
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
        Me.lblGuardar.Location = New System.Drawing.Point(10, 48)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(15, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 10
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
        Me.pnlCabecera.Size = New System.Drawing.Size(561, 60)
        Me.pnlCabecera.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlEncabezadoTextoDerecha)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(190, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(301, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'pnlEncabezadoTextoDerecha
        '
        Me.pnlEncabezadoTextoDerecha.Controls.Add(Me.Panel1)
        Me.pnlEncabezadoTextoDerecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEncabezadoTextoDerecha.Location = New System.Drawing.Point(15, 0)
        Me.pnlEncabezadoTextoDerecha.Name = "pnlEncabezadoTextoDerecha"
        Me.pnlEncabezadoTextoDerecha.Size = New System.Drawing.Size(286, 60)
        Me.pnlEncabezadoTextoDerecha.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(13, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 34)
        Me.Panel1.TabIndex = 23
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(94, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(173, 20)
        Me.lblTitulo.TabIndex = 22
        Me.lblTitulo.Text = "Alta Cuenta General"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(491, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaCuentaGeneralForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 496)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "AltaCuentaGeneralForm"
        Me.Text = "Alta Cuenta General"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.gpbDatosCuentaGral.ResumeLayout(False)
        Me.gpbDatosCuentaGral.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEncabezadoTextoDerecha.ResumeLayout(False)
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
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents gpbDatosCuentaGral As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoPoliza As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuentaContpaq As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuentaSAY As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaSAY As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents txtNumCuenta As System.Windows.Forms.TextBox
    Friend WithEvents btnCuentaContpaq As System.Windows.Forms.Button
    Friend WithEvents btnCuentaSAY As System.Windows.Forms.Button
    Friend WithEvents btnCuentaBancaria As System.Windows.Forms.Button
    Friend WithEvents lblCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents btnTipoPolizaContpaq As System.Windows.Forms.Button
    Friend WithEvents lblTipoPolizaContpaq As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPolizaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCuentaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents pnlEncabezadoTextoDerecha As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
End Class
