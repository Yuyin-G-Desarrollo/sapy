<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEdicion_Empresa_SayForm
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
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.gpbCamposEmpresa = New System.Windows.Forms.GroupBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.numTasaIVAEnEncabezado = New System.Windows.Forms.NumericUpDown()
        Me.lblTasaIVAEnEncabezado = New System.Windows.Forms.Label()
        Me.numTasaIva = New System.Windows.Forms.NumericUpDown()
        Me.lblTasaIva = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
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
        Me.gpbCamposEmpresa.SuspendLayout()
        CType(Me.numTasaIVAEnEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTasaIva, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlInformacionAlta.Controls.Add(Me.gpbCamposEmpresa)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 60)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(594, 187)
        Me.pnlInformacionAlta.TabIndex = 8
        '
        'gpbCamposEmpresa
        '
        Me.gpbCamposEmpresa.Controls.Add(Me.chkActivo)
        Me.gpbCamposEmpresa.Controls.Add(Me.txtRFC)
        Me.gpbCamposEmpresa.Controls.Add(Me.txtRazonSocial)
        Me.gpbCamposEmpresa.Controls.Add(Me.lblRFC)
        Me.gpbCamposEmpresa.Controls.Add(Me.numTasaIVAEnEncabezado)
        Me.gpbCamposEmpresa.Controls.Add(Me.lblTasaIVAEnEncabezado)
        Me.gpbCamposEmpresa.Controls.Add(Me.numTasaIva)
        Me.gpbCamposEmpresa.Controls.Add(Me.lblTasaIva)
        Me.gpbCamposEmpresa.Controls.Add(Me.lblRazonSocial)
        Me.gpbCamposEmpresa.Location = New System.Drawing.Point(12, 28)
        Me.gpbCamposEmpresa.Name = "gpbCamposEmpresa"
        Me.gpbCamposEmpresa.Size = New System.Drawing.Size(560, 153)
        Me.gpbCamposEmpresa.TabIndex = 6
        Me.gpbCamposEmpresa.TabStop = False
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Enabled = False
        Me.chkActivo.Location = New System.Drawing.Point(172, 130)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 5
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtRFC
        '
        Me.txtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRFC.Location = New System.Drawing.Point(172, 47)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(368, 20)
        Me.txtRFC.TabIndex = 2
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Location = New System.Drawing.Point(172, 19)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(368, 20)
        Me.txtRazonSocial.TabIndex = 1
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Location = New System.Drawing.Point(15, 50)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(35, 13)
        Me.lblRFC.TabIndex = 38
        Me.lblRFC.Text = "* RFC"
        '
        'numTasaIVAEnEncabezado
        '
        Me.numTasaIVAEnEncabezado.DecimalPlaces = 2
        Me.numTasaIVAEnEncabezado.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numTasaIVAEnEncabezado.Location = New System.Drawing.Point(172, 101)
        Me.numTasaIVAEnEncabezado.Name = "numTasaIVAEnEncabezado"
        Me.numTasaIVAEnEncabezado.Size = New System.Drawing.Size(81, 20)
        Me.numTasaIVAEnEncabezado.TabIndex = 4
        Me.numTasaIVAEnEncabezado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaIVAEnEncabezado
        '
        Me.lblTasaIVAEnEncabezado.AutoSize = True
        Me.lblTasaIVAEnEncabezado.Location = New System.Drawing.Point(15, 103)
        Me.lblTasaIVAEnEncabezado.Name = "lblTasaIVAEnEncabezado"
        Me.lblTasaIVAEnEncabezado.Size = New System.Drawing.Size(144, 13)
        Me.lblTasaIVAEnEncabezado.TabIndex = 34
        Me.lblTasaIVAEnEncabezado.Text = "Tasa de IVA en Encabezado"
        '
        'numTasaIva
        '
        Me.numTasaIva.DecimalPlaces = 2
        Me.numTasaIva.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numTasaIva.Location = New System.Drawing.Point(172, 74)
        Me.numTasaIva.Name = "numTasaIva"
        Me.numTasaIva.Size = New System.Drawing.Size(81, 20)
        Me.numTasaIva.TabIndex = 3
        Me.numTasaIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaIva
        '
        Me.lblTasaIva.AutoSize = True
        Me.lblTasaIva.Location = New System.Drawing.Point(15, 76)
        Me.lblTasaIva.Name = "lblTasaIva"
        Me.lblTasaIva.Size = New System.Drawing.Size(51, 13)
        Me.lblTasaIva.TabIndex = 31
        Me.lblTasaIva.Text = "Tasa IVA"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(15, 22)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 30
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 247)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(594, 65)
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
        Me.pnlBotones.Location = New System.Drawing.Point(477, 0)
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
        Me.btnCerrar.TabIndex = 7
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
        Me.btnGuardar.TabIndex = 6
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
        Me.pnlCabecera.Size = New System.Drawing.Size(594, 60)
        Me.pnlCabecera.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(198, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(326, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 33)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(159, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(158, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta Empresa SAY"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(524, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaEdicion_Empresa_SayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 312)
        Me.Controls.Add(Me.pnlInformacionAlta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 100)
        Me.Name = "AltaEdicion_Empresa_SayForm"
        Me.Text = "Alta Empresa SAY"
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.gpbCamposEmpresa.ResumeLayout(False)
        Me.gpbCamposEmpresa.PerformLayout()
        CType(Me.numTasaIVAEnEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTasaIva, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpbCamposEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTasaIva As System.Windows.Forms.Label
    Friend WithEvents numTasaIVAEnEncabezado As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTasaIVAEnEncabezado As System.Windows.Forms.Label
    Friend WithEvents numTasaIva As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
End Class
