<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCuentaGeneralForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarCuentaGeneralForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.btnCuentaBancaria = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboxCuentaBancaria = New System.Windows.Forms.ComboBox()
        Me.btnCuentaContpaq = New System.Windows.Forms.Button()
        Me.btnCuentaSAY = New System.Windows.Forms.Button()
        Me.lblCuentaContpaq = New System.Windows.Forms.Label()
        Me.cboxCuentaContpaq = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboxCuentaSAY = New System.Windows.Forms.ComboBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombreCuenta = New System.Windows.Forms.TextBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.txtNumCuenta = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.cboxEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblTipoPoliza = New System.Windows.Forms.Label()
        Me.cboxTipoPoliza = New System.Windows.Forms.ComboBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
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
        Me.pnlContenedor.TabIndex = 4
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
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(561, 365)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblClave)
        Me.GroupBox1.Controls.Add(Me.txtClave)
        Me.GroupBox1.Controls.Add(Me.btnCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboxCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.btnCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.btnCuentaSAY)
        Me.GroupBox1.Controls.Add(Me.lblCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.cboxCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboxCuentaSAY)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.txtNombreCuenta)
        Me.GroupBox1.Controls.Add(Me.lblCuenta)
        Me.GroupBox1.Controls.Add(Me.txtNumCuenta)
        Me.GroupBox1.Controls.Add(Me.lblRazonSocial)
        Me.GroupBox1.Controls.Add(Me.cboxEmpresa)
        Me.GroupBox1.Controls.Add(Me.lblTipoPoliza)
        Me.GroupBox1.Controls.Add(Me.cboxTipoPoliza)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 345)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(6, 164)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 47
        Me.lblClave.Text = "Clave"
        '
        'txtClave
        '
        Me.txtClave.Enabled = False
        Me.txtClave.Location = New System.Drawing.Point(152, 158)
        Me.txtClave.MaxLength = 250
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(343, 20)
        Me.txtClave.TabIndex = 46
        '
        'btnCuentaBancaria
        '
        Me.btnCuentaBancaria.Enabled = False
        Me.btnCuentaBancaria.Image = CType(resources.GetObject("btnCuentaBancaria.Image"), System.Drawing.Image)
        Me.btnCuentaBancaria.Location = New System.Drawing.Point(499, 267)
        Me.btnCuentaBancaria.Name = "btnCuentaBancaria"
        Me.btnCuentaBancaria.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaBancaria.TabIndex = 45
        Me.btnCuentaBancaria.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 275)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Cuenta Bancaria"
        '
        'cboxCuentaBancaria
        '
        Me.cboxCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxCuentaBancaria.Enabled = False
        Me.cboxCuentaBancaria.FormattingEnabled = True
        Me.cboxCuentaBancaria.Location = New System.Drawing.Point(152, 268)
        Me.cboxCuentaBancaria.Name = "cboxCuentaBancaria"
        Me.cboxCuentaBancaria.Size = New System.Drawing.Size(343, 21)
        Me.cboxCuentaBancaria.TabIndex = 43
        '
        'btnCuentaContpaq
        '
        Me.btnCuentaContpaq.Enabled = False
        Me.btnCuentaContpaq.Image = CType(resources.GetObject("btnCuentaContpaq.Image"), System.Drawing.Image)
        Me.btnCuentaContpaq.Location = New System.Drawing.Point(499, 193)
        Me.btnCuentaContpaq.Name = "btnCuentaContpaq"
        Me.btnCuentaContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaContpaq.TabIndex = 42
        Me.btnCuentaContpaq.UseVisualStyleBackColor = True
        '
        'btnCuentaSAY
        '
        Me.btnCuentaSAY.Enabled = False
        Me.btnCuentaSAY.Image = CType(resources.GetObject("btnCuentaSAY.Image"), System.Drawing.Image)
        Me.btnCuentaSAY.Location = New System.Drawing.Point(499, 230)
        Me.btnCuentaSAY.Name = "btnCuentaSAY"
        Me.btnCuentaSAY.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaSAY.TabIndex = 41
        Me.btnCuentaSAY.UseVisualStyleBackColor = True
        '
        'lblCuentaContpaq
        '
        Me.lblCuentaContpaq.AutoSize = True
        Me.lblCuentaContpaq.Location = New System.Drawing.Point(6, 201)
        Me.lblCuentaContpaq.Name = "lblCuentaContpaq"
        Me.lblCuentaContpaq.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContpaq.TabIndex = 40
        Me.lblCuentaContpaq.Text = "* Cuenta Contpaq"
        '
        'cboxCuentaContpaq
        '
        Me.cboxCuentaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxCuentaContpaq.Enabled = False
        Me.cboxCuentaContpaq.FormattingEnabled = True
        Me.cboxCuentaContpaq.Location = New System.Drawing.Point(152, 194)
        Me.cboxCuentaContpaq.Name = "cboxCuentaContpaq"
        Me.cboxCuentaContpaq.Size = New System.Drawing.Size(343, 21)
        Me.cboxCuentaContpaq.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Cuenta SAY"
        '
        'cboxCuentaSAY
        '
        Me.cboxCuentaSAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxCuentaSAY.Enabled = False
        Me.cboxCuentaSAY.FormattingEnabled = True
        Me.cboxCuentaSAY.Location = New System.Drawing.Point(152, 231)
        Me.cboxCuentaSAY.Name = "cboxCuentaSAY"
        Me.cboxCuentaSAY.Size = New System.Drawing.Size(343, 21)
        Me.cboxCuentaSAY.TabIndex = 37
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(6, 127)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 36
        Me.lblNombre.Text = "* Nombre"
        '
        'txtNombreCuenta
        '
        Me.txtNombreCuenta.Enabled = False
        Me.txtNombreCuenta.Location = New System.Drawing.Point(152, 122)
        Me.txtNombreCuenta.MaxLength = 250
        Me.txtNombreCuenta.Name = "txtNombreCuenta"
        Me.txtNombreCuenta.Size = New System.Drawing.Size(343, 20)
        Me.txtNombreCuenta.TabIndex = 35
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(6, 90)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(48, 13)
        Me.lblCuenta.TabIndex = 34
        Me.lblCuenta.Text = "* Cuenta"
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.Enabled = False
        Me.txtNumCuenta.Location = New System.Drawing.Point(152, 86)
        Me.txtNumCuenta.MaxLength = 11
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.Size = New System.Drawing.Size(151, 20)
        Me.txtNumCuenta.TabIndex = 33
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(6, 53)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 32
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'cboxEmpresa
        '
        Me.cboxEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxEmpresa.Enabled = False
        Me.cboxEmpresa.FormattingEnabled = True
        Me.cboxEmpresa.Location = New System.Drawing.Point(152, 49)
        Me.cboxEmpresa.Name = "cboxEmpresa"
        Me.cboxEmpresa.Size = New System.Drawing.Size(343, 21)
        Me.cboxEmpresa.TabIndex = 31
        '
        'lblTipoPoliza
        '
        Me.lblTipoPoliza.AutoSize = True
        Me.lblTipoPoliza.Location = New System.Drawing.Point(6, 16)
        Me.lblTipoPoliza.Name = "lblTipoPoliza"
        Me.lblTipoPoliza.Size = New System.Drawing.Size(66, 13)
        Me.lblTipoPoliza.TabIndex = 30
        Me.lblTipoPoliza.Text = "* Tipo Poliza"
        '
        'cboxTipoPoliza
        '
        Me.cboxTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxTipoPoliza.FormattingEnabled = True
        Me.cboxTipoPoliza.Location = New System.Drawing.Point(152, 12)
        Me.cboxTipoPoliza.Name = "cboxTipoPoliza"
        Me.cboxTipoPoliza.Size = New System.Drawing.Size(343, 21)
        Me.cboxTipoPoliza.TabIndex = 29
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
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
        Me.btnCancelar.TabIndex = 6
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
        Me.btnAceptar.TabIndex = 5
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
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(251, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(240, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(15, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(189, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Editar Cuenta General"
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
        'EditarCuentaGeneralForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 496)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarCuentaGeneralForm"
        Me.Text = "Editar Cuenta General"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents pnlInformacionAlta As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents btnCuentaBancaria As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboxCuentaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents btnCuentaContpaq As System.Windows.Forms.Button
    Friend WithEvents btnCuentaSAY As System.Windows.Forms.Button
    Friend WithEvents lblCuentaContpaq As System.Windows.Forms.Label
    Friend WithEvents cboxCuentaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboxCuentaSAY As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents txtNumCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents cboxEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoPoliza As System.Windows.Forms.Label
    Friend WithEvents cboxTipoPoliza As System.Windows.Forms.ComboBox
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
End Class
