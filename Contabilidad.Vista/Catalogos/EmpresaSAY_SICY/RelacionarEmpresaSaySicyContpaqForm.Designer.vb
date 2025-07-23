<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RelacionarEmpresaSaySicyContpaqForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RelacionarEmpresaSaySicyContpaqForm))
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBaseDeDatos = New System.Windows.Forms.TextBox()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.gpbEmpresaSicy = New System.Windows.Forms.GroupBox()
        Me.btnContribuyente = New System.Windows.Forms.Button()
        Me.cmbUContribuyente = New System.Windows.Forms.ComboBox()
        Me.btnEmpresaDoctosVentas = New System.Windows.Forms.Button()
        Me.lblEmpresaDoctosVentas = New System.Windows.Forms.Label()
        Me.cmbUEmpresaDOctosVentas = New System.Windows.Forms.ComboBox()
        Me.lblContribuyente = New System.Windows.Forms.Label()
        Me.gpbEmpresaSay = New System.Windows.Forms.GroupBox()
        Me.lblAltaEmpresaSay = New System.Windows.Forms.Label()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.btnAltaEmpresaSay = New System.Windows.Forms.Button()
        Me.lblRazonSocialSay = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpbEmpresaSicy.SuspendLayout()
        Me.gpbEmpresaSay.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Controls.Add(Me.gpbEmpresaSicy)
        Me.pnlInformacionAlta.Controls.Add(Me.gpbEmpresaSay)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 60)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(584, 336)
        Me.pnlInformacionAlta.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBaseDeDatos)
        Me.GroupBox1.Controls.Add(Me.txtServidor)
        Me.GroupBox1.Controls.Add(Me.lblDB)
        Me.GroupBox1.Controls.Add(Me.lblServidor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 93)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empresa Contpaq"
        '
        'txtBaseDeDatos
        '
        Me.txtBaseDeDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseDeDatos.Location = New System.Drawing.Point(154, 59)
        Me.txtBaseDeDatos.MaxLength = 100
        Me.txtBaseDeDatos.Name = "txtBaseDeDatos"
        Me.txtBaseDeDatos.Size = New System.Drawing.Size(394, 20)
        Me.txtBaseDeDatos.TabIndex = 8
        '
        'txtServidor
        '
        Me.txtServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServidor.Location = New System.Drawing.Point(154, 29)
        Me.txtServidor.MaxLength = 30
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(394, 20)
        Me.txtServidor.TabIndex = 7
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDB.Location = New System.Drawing.Point(15, 62)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(84, 13)
        Me.lblDB.TabIndex = 53
        Me.lblDB.Text = "* Base de Datos"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServidor.Location = New System.Drawing.Point(15, 32)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(53, 13)
        Me.lblServidor.TabIndex = 49
        Me.lblServidor.Text = "* Servidor"
        '
        'gpbEmpresaSicy
        '
        Me.gpbEmpresaSicy.Controls.Add(Me.btnContribuyente)
        Me.gpbEmpresaSicy.Controls.Add(Me.cmbUContribuyente)
        Me.gpbEmpresaSicy.Controls.Add(Me.btnEmpresaDoctosVentas)
        Me.gpbEmpresaSicy.Controls.Add(Me.lblEmpresaDoctosVentas)
        Me.gpbEmpresaSicy.Controls.Add(Me.cmbUEmpresaDOctosVentas)
        Me.gpbEmpresaSicy.Controls.Add(Me.lblContribuyente)
        Me.gpbEmpresaSicy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbEmpresaSicy.Location = New System.Drawing.Point(12, 122)
        Me.gpbEmpresaSicy.Name = "gpbEmpresaSicy"
        Me.gpbEmpresaSicy.Size = New System.Drawing.Size(560, 93)
        Me.gpbEmpresaSicy.TabIndex = 54
        Me.gpbEmpresaSicy.TabStop = False
        Me.gpbEmpresaSicy.Text = "Empresa SICY"
        '
        'btnContribuyente
        '
        Me.btnContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContribuyente.Image = CType(resources.GetObject("btnContribuyente.Image"), System.Drawing.Image)
        Me.btnContribuyente.Location = New System.Drawing.Point(526, 27)
        Me.btnContribuyente.Name = "btnContribuyente"
        Me.btnContribuyente.Size = New System.Drawing.Size(22, 22)
        Me.btnContribuyente.TabIndex = 4
        Me.btnContribuyente.UseVisualStyleBackColor = True
        '
        'cmbUContribuyente
        '
        Me.cmbUContribuyente.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbUContribuyente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUContribuyente.Enabled = False
        Me.cmbUContribuyente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUContribuyente.FormattingEnabled = True
        Me.cmbUContribuyente.Location = New System.Drawing.Point(154, 29)
        Me.cmbUContribuyente.Name = "cmbUContribuyente"
        Me.cmbUContribuyente.Size = New System.Drawing.Size(366, 21)
        Me.cmbUContribuyente.TabIndex = 3
        '
        'btnEmpresaDoctosVentas
        '
        Me.btnEmpresaDoctosVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpresaDoctosVentas.Image = CType(resources.GetObject("btnEmpresaDoctosVentas.Image"), System.Drawing.Image)
        Me.btnEmpresaDoctosVentas.Location = New System.Drawing.Point(526, 57)
        Me.btnEmpresaDoctosVentas.Name = "btnEmpresaDoctosVentas"
        Me.btnEmpresaDoctosVentas.Size = New System.Drawing.Size(22, 22)
        Me.btnEmpresaDoctosVentas.TabIndex = 6
        Me.btnEmpresaDoctosVentas.UseVisualStyleBackColor = True
        '
        'lblEmpresaDoctosVentas
        '
        Me.lblEmpresaDoctosVentas.AutoSize = True
        Me.lblEmpresaDoctosVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaDoctosVentas.Location = New System.Drawing.Point(15, 62)
        Me.lblEmpresaDoctosVentas.Name = "lblEmpresaDoctosVentas"
        Me.lblEmpresaDoctosVentas.Size = New System.Drawing.Size(134, 13)
        Me.lblEmpresaDoctosVentas.TabIndex = 53
        Me.lblEmpresaDoctosVentas.Text = "* Empresa(Doctos. Ventas)"
        '
        'cmbUEmpresaDOctosVentas
        '
        Me.cmbUEmpresaDOctosVentas.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbUEmpresaDOctosVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUEmpresaDOctosVentas.Enabled = False
        Me.cmbUEmpresaDOctosVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbUEmpresaDOctosVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUEmpresaDOctosVentas.FormattingEnabled = True
        Me.cmbUEmpresaDOctosVentas.Location = New System.Drawing.Point(154, 59)
        Me.cmbUEmpresaDOctosVentas.Name = "cmbUEmpresaDOctosVentas"
        Me.cmbUEmpresaDOctosVentas.Size = New System.Drawing.Size(366, 21)
        Me.cmbUEmpresaDOctosVentas.TabIndex = 5
        '
        'lblContribuyente
        '
        Me.lblContribuyente.AutoSize = True
        Me.lblContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContribuyente.Location = New System.Drawing.Point(15, 32)
        Me.lblContribuyente.Name = "lblContribuyente"
        Me.lblContribuyente.Size = New System.Drawing.Size(79, 13)
        Me.lblContribuyente.TabIndex = 49
        Me.lblContribuyente.Text = "* Contribuyente"
        '
        'gpbEmpresaSay
        '
        Me.gpbEmpresaSay.Controls.Add(Me.lblAltaEmpresaSay)
        Me.gpbEmpresaSay.Controls.Add(Me.cmbRazonSocial)
        Me.gpbEmpresaSay.Controls.Add(Me.btnAltaEmpresaSay)
        Me.gpbEmpresaSay.Controls.Add(Me.lblRazonSocialSay)
        Me.gpbEmpresaSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbEmpresaSay.Location = New System.Drawing.Point(12, 39)
        Me.gpbEmpresaSay.Name = "gpbEmpresaSay"
        Me.gpbEmpresaSay.Size = New System.Drawing.Size(560, 77)
        Me.gpbEmpresaSay.TabIndex = 6
        Me.gpbEmpresaSay.TabStop = False
        Me.gpbEmpresaSay.Text = "Empresa SAY"
        '
        'lblAltaEmpresaSay
        '
        Me.lblAltaEmpresaSay.AutoSize = True
        Me.lblAltaEmpresaSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltaEmpresaSay.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEmpresaSay.Location = New System.Drawing.Point(518, 58)
        Me.lblAltaEmpresaSay.Name = "lblAltaEmpresaSay"
        Me.lblAltaEmpresaSay.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEmpresaSay.TabIndex = 38
        Me.lblAltaEmpresaSay.Text = "Altas"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(154, 25)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(357, 21)
        Me.cmbRazonSocial.TabIndex = 1
        '
        'btnAltaEmpresaSay
        '
        Me.btnAltaEmpresaSay.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAltaEmpresaSay.Location = New System.Drawing.Point(517, 25)
        Me.btnAltaEmpresaSay.Name = "btnAltaEmpresaSay"
        Me.btnAltaEmpresaSay.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaEmpresaSay.TabIndex = 2
        Me.btnAltaEmpresaSay.UseVisualStyleBackColor = True
        '
        'lblRazonSocialSay
        '
        Me.lblRazonSocialSay.AutoSize = True
        Me.lblRazonSocialSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocialSay.Location = New System.Drawing.Point(15, 26)
        Me.lblRazonSocialSay.Name = "lblRazonSocialSay"
        Me.lblRazonSocialSay.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocialSay.TabIndex = 26
        Me.lblRazonSocialSay.Text = "* Razón Social"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 396)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(584, 65)
        Me.pnlPie.TabIndex = 7
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(467, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 65)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(67, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 10
        Me.btnCerrar.UseVisualStyleBackColor = True
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
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(18, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.UseVisualStyleBackColor = True
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
        Me.pnlCabecera.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(143, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(371, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 36)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(44, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(318, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Relación Empresa SAY-SICY-Contpaq"
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
        'RelacionarEmpresaSaySicyContpaqForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.pnlInformacionAlta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RelacionarEmpresaSaySicyContpaqForm"
        Me.Text = "Relación Empresa SAY-SICY-Contpaq"
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbEmpresaSicy.ResumeLayout(False)
        Me.gpbEmpresaSicy.PerformLayout()
        Me.gpbEmpresaSay.ResumeLayout(False)
        Me.gpbEmpresaSay.PerformLayout()
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
    Friend WithEvents pnlInformacionAlta As System.Windows.Forms.Panel
    Friend WithEvents gpbEmpresaSay As System.Windows.Forms.GroupBox
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocialSay As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents gpbEmpresaSicy As System.Windows.Forms.GroupBox
    Friend WithEvents btnContribuyente As System.Windows.Forms.Button
    Friend WithEvents cmbUContribuyente As System.Windows.Forms.ComboBox
    Friend WithEvents btnEmpresaDoctosVentas As System.Windows.Forms.Button
    Friend WithEvents lblEmpresaDoctosVentas As System.Windows.Forms.Label
    Friend WithEvents cmbUEmpresaDOctosVentas As System.Windows.Forms.ComboBox
    Friend WithEvents lblContribuyente As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBaseDeDatos As System.Windows.Forms.TextBox
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents lblServidor As System.Windows.Forms.Label
    Friend WithEvents lblAltaEmpresaSay As System.Windows.Forms.Label
    Friend WithEvents btnAltaEmpresaSay As System.Windows.Forms.Button
End Class
