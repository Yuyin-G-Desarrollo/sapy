<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEditarCuentaContableForm
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
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.gpbCampos = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.cmbUClienteProveedor = New System.Windows.Forms.ComboBox()
        Me.cmbUCuentaContpaq = New System.Windows.Forms.ComboBox()
        Me.cmbUCuentaSicy = New System.Windows.Forms.ComboBox()
        Me.btnClienteProveedor = New System.Windows.Forms.Button()
        Me.lblClienteProveedor = New System.Windows.Forms.Label()
        Me.btnCuentaSicy = New System.Windows.Forms.Button()
        Me.lblCuentaSicy = New System.Windows.Forms.Label()
        Me.btnCuentaContpaq = New System.Windows.Forms.Button()
        Me.lblCuentaContpaq = New System.Windows.Forms.Label()
        Me.cmbTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.lblTipoCuenta = New System.Windows.Forms.Label()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.txtNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
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
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.gpbCampos.SuspendLayout()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(584, 380)
        Me.pnlContenedor.TabIndex = 4
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(584, 320)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.gpbCampos)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(584, 260)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'gpbCampos
        '
        Me.gpbCampos.Controls.Add(Me.lblActivo)
        Me.gpbCampos.Controls.Add(Me.chkActivo)
        Me.gpbCampos.Controls.Add(Me.cmbUClienteProveedor)
        Me.gpbCampos.Controls.Add(Me.cmbUCuentaContpaq)
        Me.gpbCampos.Controls.Add(Me.cmbUCuentaSicy)
        Me.gpbCampos.Controls.Add(Me.btnClienteProveedor)
        Me.gpbCampos.Controls.Add(Me.lblClienteProveedor)
        Me.gpbCampos.Controls.Add(Me.btnCuentaSicy)
        Me.gpbCampos.Controls.Add(Me.lblCuentaSicy)
        Me.gpbCampos.Controls.Add(Me.btnCuentaContpaq)
        Me.gpbCampos.Controls.Add(Me.lblCuentaContpaq)
        Me.gpbCampos.Controls.Add(Me.cmbTipoCuenta)
        Me.gpbCampos.Controls.Add(Me.lblTipoCuenta)
        Me.gpbCampos.Controls.Add(Me.cmbRazonSocial)
        Me.gpbCampos.Controls.Add(Me.lblRazonSocial)
        Me.gpbCampos.Controls.Add(Me.txtNumeroCuenta)
        Me.gpbCampos.Controls.Add(Me.lblNoCuenta)
        Me.gpbCampos.Location = New System.Drawing.Point(22, 16)
        Me.gpbCampos.Name = "gpbCampos"
        Me.gpbCampos.Size = New System.Drawing.Size(550, 230)
        Me.gpbCampos.TabIndex = 6
        Me.gpbCampos.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.Black
        Me.lblActivo.Location = New System.Drawing.Point(17, 199)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 69
        Me.lblActivo.Text = "Activo"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(130, 198)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 68
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'cmbUClienteProveedor
        '
        Me.cmbUClienteProveedor.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbUClienteProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUClienteProveedor.Enabled = False
        Me.cmbUClienteProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUClienteProveedor.FormattingEnabled = True
        Me.cmbUClienteProveedor.Location = New System.Drawing.Point(130, 168)
        Me.cmbUClienteProveedor.Name = "cmbUClienteProveedor"
        Me.cmbUClienteProveedor.Size = New System.Drawing.Size(373, 21)
        Me.cmbUClienteProveedor.TabIndex = 67
        '
        'cmbUCuentaContpaq
        '
        Me.cmbUCuentaContpaq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbUCuentaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUCuentaContpaq.Enabled = False
        Me.cmbUCuentaContpaq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUCuentaContpaq.FormattingEnabled = True
        Me.cmbUCuentaContpaq.Location = New System.Drawing.Point(130, 109)
        Me.cmbUCuentaContpaq.Name = "cmbUCuentaContpaq"
        Me.cmbUCuentaContpaq.Size = New System.Drawing.Size(373, 21)
        Me.cmbUCuentaContpaq.TabIndex = 65
        '
        'cmbUCuentaSicy
        '
        Me.cmbUCuentaSicy.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbUCuentaSicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUCuentaSicy.Enabled = False
        Me.cmbUCuentaSicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUCuentaSicy.FormattingEnabled = True
        Me.cmbUCuentaSicy.Location = New System.Drawing.Point(130, 139)
        Me.cmbUCuentaSicy.Name = "cmbUCuentaSicy"
        Me.cmbUCuentaSicy.Size = New System.Drawing.Size(373, 21)
        Me.cmbUCuentaSicy.TabIndex = 66
        '
        'btnClienteProveedor
        '
        Me.btnClienteProveedor.Enabled = False
        Me.btnClienteProveedor.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnClienteProveedor.Location = New System.Drawing.Point(509, 166)
        Me.btnClienteProveedor.Name = "btnClienteProveedor"
        Me.btnClienteProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnClienteProveedor.TabIndex = 64
        Me.btnClienteProveedor.UseVisualStyleBackColor = True
        '
        'lblClienteProveedor
        '
        Me.lblClienteProveedor.AutoSize = True
        Me.lblClienteProveedor.ForeColor = System.Drawing.Color.Black
        Me.lblClienteProveedor.Location = New System.Drawing.Point(17, 171)
        Me.lblClienteProveedor.Name = "lblClienteProveedor"
        Me.lblClienteProveedor.Size = New System.Drawing.Size(86, 13)
        Me.lblClienteProveedor.TabIndex = 63
        Me.lblClienteProveedor.Text = "* Cliente_Proove"
        '
        'btnCuentaSicy
        '
        Me.btnCuentaSicy.Enabled = False
        Me.btnCuentaSicy.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnCuentaSicy.Location = New System.Drawing.Point(509, 137)
        Me.btnCuentaSicy.Name = "btnCuentaSicy"
        Me.btnCuentaSicy.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaSicy.TabIndex = 61
        Me.btnCuentaSicy.UseVisualStyleBackColor = True
        '
        'lblCuentaSicy
        '
        Me.lblCuentaSicy.AutoSize = True
        Me.lblCuentaSicy.ForeColor = System.Drawing.Color.Black
        Me.lblCuentaSicy.Location = New System.Drawing.Point(17, 142)
        Me.lblCuentaSicy.Name = "lblCuentaSicy"
        Me.lblCuentaSicy.Size = New System.Drawing.Size(64, 13)
        Me.lblCuentaSicy.TabIndex = 60
        Me.lblCuentaSicy.Text = "Cuenta Sicy"
        '
        'btnCuentaContpaq
        '
        Me.btnCuentaContpaq.Enabled = False
        Me.btnCuentaContpaq.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnCuentaContpaq.Location = New System.Drawing.Point(509, 107)
        Me.btnCuentaContpaq.Name = "btnCuentaContpaq"
        Me.btnCuentaContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnCuentaContpaq.TabIndex = 58
        Me.btnCuentaContpaq.UseVisualStyleBackColor = True
        '
        'lblCuentaContpaq
        '
        Me.lblCuentaContpaq.AutoSize = True
        Me.lblCuentaContpaq.ForeColor = System.Drawing.Color.Black
        Me.lblCuentaContpaq.Location = New System.Drawing.Point(17, 112)
        Me.lblCuentaContpaq.Name = "lblCuentaContpaq"
        Me.lblCuentaContpaq.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContpaq.TabIndex = 57
        Me.lblCuentaContpaq.Text = "* Cuenta Contapq"
        '
        'cmbTipoCuenta
        '
        Me.cmbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCuenta.Enabled = False
        Me.cmbTipoCuenta.FormattingEnabled = True
        Me.cmbTipoCuenta.Location = New System.Drawing.Point(130, 52)
        Me.cmbTipoCuenta.Name = "cmbTipoCuenta"
        Me.cmbTipoCuenta.Size = New System.Drawing.Size(401, 21)
        Me.cmbTipoCuenta.TabIndex = 40
        '
        'lblTipoCuenta
        '
        Me.lblTipoCuenta.AutoSize = True
        Me.lblTipoCuenta.ForeColor = System.Drawing.Color.Black
        Me.lblTipoCuenta.Location = New System.Drawing.Point(17, 55)
        Me.lblTipoCuenta.Name = "lblTipoCuenta"
        Me.lblTipoCuenta.Size = New System.Drawing.Size(72, 13)
        Me.lblTipoCuenta.TabIndex = 41
        Me.lblTipoCuenta.Text = "* Tipo Cuenta"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(130, 22)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(401, 21)
        Me.cmbRazonSocial.TabIndex = 38
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblRazonSocial.Location = New System.Drawing.Point(17, 25)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 39
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Enabled = False
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(130, 81)
        Me.txtNumeroCuenta.MaxLength = 30
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(401, 20)
        Me.txtNumeroCuenta.TabIndex = 4
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Location = New System.Drawing.Point(17, 84)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(103, 13)
        Me.lblNoCuenta.TabIndex = 26
        Me.lblNoCuenta.Text = "* Numero de Cuenta"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 260)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(584, 60)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(467, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 60)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(64, 6)
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
        Me.lblCancelar.Location = New System.Drawing.Point(64, 41)
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
        Me.lblGuardar.Location = New System.Drawing.Point(10, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(15, 6)
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
        Me.pnlCabecera.Size = New System.Drawing.Size(584, 60)
        Me.pnlCabecera.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(203, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(311, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 38)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(39, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(263, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta/Edición Cuentas Contables"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(514, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaEditarCuentaContableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 380)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaEditarCuentaContableForm"
        Me.Text = "Alta/Edición Cuentas Contables"
        Me.pnlContenedor.ResumeLayout(false)
        Me.pnlContenido.ResumeLayout(false)
        Me.pnlInformacionAlta.ResumeLayout(false)
        Me.gpbCampos.ResumeLayout(false)
        Me.gpbCampos.PerformLayout
        Me.pnlPie.ResumeLayout(false)
        Me.pnlBotones.ResumeLayout(false)
        Me.pnlBotones.PerformLayout
        Me.pnlCabecera.ResumeLayout(false)
        Me.pnlTitulo.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.imgLogo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents pnlInformacionAlta As System.Windows.Forms.Panel
    Friend WithEvents gpbCampos As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblNoCuenta As System.Windows.Forms.Label
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
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCuenta As System.Windows.Forms.Label
    Friend WithEvents btnCuentaSicy As System.Windows.Forms.Button
    Friend WithEvents lblCuentaSicy As System.Windows.Forms.Label
    Friend WithEvents btnCuentaContpaq As System.Windows.Forms.Button
    Friend WithEvents lblCuentaContpaq As System.Windows.Forms.Label
    Friend WithEvents btnClienteProveedor As System.Windows.Forms.Button
    Friend WithEvents lblClienteProveedor As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbUClienteProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUCuentaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUCuentaSicy As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
End Class
