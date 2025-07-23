<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCuenta_BancariaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarCuenta_BancariaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboxCuentaContpaq = New System.Windows.Forms.ComboBox()
        Me.btnBancoContpaq = New System.Windows.Forms.Button()
        Me.lblBancoContpaq = New System.Windows.Forms.Label()
        Me.cboxBancoContpaq = New System.Windows.Forms.ComboBox()
        Me.lblCuentaContpaq = New System.Windows.Forms.Label()
        Me.cboxNumeroCuentaSICY = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboxBanco = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboxRazonSocial = New System.Windows.Forms.ComboBox()
        Me.txtCuentahabiente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.lblNombreDepartamento = New System.Windows.Forms.Label()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(571, 479)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(571, 419)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(571, 348)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboxCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.btnBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.lblBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.cboxBancoContpaq)
        Me.GroupBox1.Controls.Add(Me.lblCuentaContpaq)
        Me.GroupBox1.Controls.Add(Me.cboxNumeroCuentaSICY)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboxBanco)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboxRazonSocial)
        Me.GroupBox1.Controls.Add(Me.txtCuentahabiente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNumeroCuenta)
        Me.GroupBox1.Controls.Add(Me.lblNombreDepartamento)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 291)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'cboxCuentaContpaq
        '
        Me.cboxCuentaContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxCuentaContpaq.FormattingEnabled = True
        Me.cboxCuentaContpaq.Location = New System.Drawing.Point(152, 193)
        Me.cboxCuentaContpaq.Name = "cboxCuentaContpaq"
        Me.cboxCuentaContpaq.Size = New System.Drawing.Size(356, 21)
        Me.cboxCuentaContpaq.TabIndex = 60
        '
        'btnBancoContpaq
        '
        Me.btnBancoContpaq.Image = CType(resources.GetObject("btnBancoContpaq.Image"), System.Drawing.Image)
        Me.btnBancoContpaq.Location = New System.Drawing.Point(486, 230)
        Me.btnBancoContpaq.Name = "btnBancoContpaq"
        Me.btnBancoContpaq.Size = New System.Drawing.Size(22, 22)
        Me.btnBancoContpaq.TabIndex = 59
        Me.btnBancoContpaq.UseVisualStyleBackColor = True
        '
        'lblBancoContpaq
        '
        Me.lblBancoContpaq.AutoSize = True
        Me.lblBancoContpaq.Location = New System.Drawing.Point(14, 234)
        Me.lblBancoContpaq.Name = "lblBancoContpaq"
        Me.lblBancoContpaq.Size = New System.Drawing.Size(88, 13)
        Me.lblBancoContpaq.TabIndex = 58
        Me.lblBancoContpaq.Text = "* Banco Contpaq"
        '
        'cboxBancoContpaq
        '
        Me.cboxBancoContpaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxBancoContpaq.FormattingEnabled = True
        Me.cboxBancoContpaq.Location = New System.Drawing.Point(152, 230)
        Me.cboxBancoContpaq.Name = "cboxBancoContpaq"
        Me.cboxBancoContpaq.Size = New System.Drawing.Size(327, 21)
        Me.cboxBancoContpaq.TabIndex = 57
        '
        'lblCuentaContpaq
        '
        Me.lblCuentaContpaq.AutoSize = True
        Me.lblCuentaContpaq.Location = New System.Drawing.Point(14, 197)
        Me.lblCuentaContpaq.Name = "lblCuentaContpaq"
        Me.lblCuentaContpaq.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContpaq.TabIndex = 56
        Me.lblCuentaContpaq.Text = "* Cuenta Contpaq"
        '
        'cboxNumeroCuentaSICY
        '
        Me.cboxNumeroCuentaSICY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNumeroCuentaSICY.FormattingEnabled = True
        Me.cboxNumeroCuentaSICY.Location = New System.Drawing.Point(152, 135)
        Me.cboxNumeroCuentaSICY.Name = "cboxNumeroCuentaSICY"
        Me.cboxNumeroCuentaSICY.Size = New System.Drawing.Size(355, 21)
        Me.cboxNumeroCuentaSICY.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "* Banco"
        '
        'cboxBanco
        '
        Me.cboxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxBanco.FormattingEnabled = True
        Me.cboxBanco.Location = New System.Drawing.Point(152, 164)
        Me.cboxBanco.Name = "cboxBanco"
        Me.cboxBanco.Size = New System.Drawing.Size(355, 21)
        Me.cboxBanco.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "* Numero de Cuenta SICY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "* Razón Social"
        '
        'cboxRazonSocial
        '
        Me.cboxRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxRazonSocial.FormattingEnabled = True
        Me.cboxRazonSocial.Location = New System.Drawing.Point(152, 106)
        Me.cboxRazonSocial.Name = "cboxRazonSocial"
        Me.cboxRazonSocial.Size = New System.Drawing.Size(355, 21)
        Me.cboxRazonSocial.TabIndex = 29
        '
        'txtCuentahabiente
        '
        Me.txtCuentahabiente.Location = New System.Drawing.Point(17, 74)
        Me.txtCuentahabiente.MaxLength = 30
        Me.txtCuentahabiente.Name = "txtCuentahabiente"
        Me.txtCuentahabiente.Size = New System.Drawing.Size(490, 20)
        Me.txtCuentahabiente.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "* Cuentahabiente"
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(152, 12)
        Me.txtNumeroCuenta.MaxLength = 30
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(355, 20)
        Me.txtNumeroCuenta.TabIndex = 4
        '
        'lblNombreDepartamento
        '
        Me.lblNombreDepartamento.AutoSize = True
        Me.lblNombreDepartamento.Location = New System.Drawing.Point(14, 16)
        Me.lblNombreDepartamento.Name = "lblNombreDepartamento"
        Me.lblNombreDepartamento.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreDepartamento.TabIndex = 26
        Me.lblNombreDepartamento.Text = "* Numero de Cuenta"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 348)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(571, 71)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(454, 0)
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
        Me.pnlCabecera.Size = New System.Drawing.Size(571, 60)
        Me.pnlCabecera.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(277, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(224, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(25, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(196, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Editar Cuenta Bancaria"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(501, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'EditarCuenta_BancariaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 479)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarCuenta_BancariaForm"
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
    Friend WithEvents cboxNumeroCuentaSICY As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboxRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuentahabiente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreDepartamento As System.Windows.Forms.Label
    Friend WithEvents cboxCuentaContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents btnBancoContpaq As System.Windows.Forms.Button
    Friend WithEvents lblBancoContpaq As System.Windows.Forms.Label
    Friend WithEvents cboxBancoContpaq As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuentaContpaq As System.Windows.Forms.Label
End Class
