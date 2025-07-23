<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEdicion_TablasSPEForm
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
        Me.txtSubsidio = New System.Windows.Forms.TextBox()
        Me.lblSubsidio = New System.Windows.Forms.Label()
        Me.txtLimiteSuperior = New System.Windows.Forms.TextBox()
        Me.lblLimSuperior = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtLimiteInferior = New System.Windows.Forms.TextBox()
        Me.lblLimInferior = New System.Windows.Forms.Label()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(362, 342)
        Me.pnlContenedor.TabIndex = 6
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(362, 282)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.gpbCampos)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(362, 222)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'gpbCampos
        '
        Me.gpbCampos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbCampos.Controls.Add(Me.txtSubsidio)
        Me.gpbCampos.Controls.Add(Me.lblSubsidio)
        Me.gpbCampos.Controls.Add(Me.txtLimiteSuperior)
        Me.gpbCampos.Controls.Add(Me.lblLimSuperior)
        Me.gpbCampos.Controls.Add(Me.cmbTipo)
        Me.gpbCampos.Controls.Add(Me.lblTipo)
        Me.gpbCampos.Controls.Add(Me.txtLimiteInferior)
        Me.gpbCampos.Controls.Add(Me.lblLimInferior)
        Me.gpbCampos.Location = New System.Drawing.Point(12, 17)
        Me.gpbCampos.Name = "gpbCampos"
        Me.gpbCampos.Size = New System.Drawing.Size(338, 187)
        Me.gpbCampos.TabIndex = 6
        Me.gpbCampos.TabStop = False
        '
        'txtSubsidio
        '
        Me.txtSubsidio.Location = New System.Drawing.Point(147, 128)
        Me.txtSubsidio.MaxLength = 30
        Me.txtSubsidio.Name = "txtSubsidio"
        Me.txtSubsidio.Size = New System.Drawing.Size(144, 20)
        Me.txtSubsidio.TabIndex = 42
        '
        'lblSubsidio
        '
        Me.lblSubsidio.AutoSize = True
        Me.lblSubsidio.Location = New System.Drawing.Point(34, 131)
        Me.lblSubsidio.Name = "lblSubsidio"
        Me.lblSubsidio.Size = New System.Drawing.Size(54, 13)
        Me.lblSubsidio.TabIndex = 43
        Me.lblSubsidio.Text = "* Subsidio"
        '
        'txtLimiteSuperior
        '
        Me.txtLimiteSuperior.Location = New System.Drawing.Point(147, 95)
        Me.txtLimiteSuperior.MaxLength = 30
        Me.txtLimiteSuperior.Name = "txtLimiteSuperior"
        Me.txtLimiteSuperior.Size = New System.Drawing.Size(144, 20)
        Me.txtLimiteSuperior.TabIndex = 40
        '
        'lblLimSuperior
        '
        Me.lblLimSuperior.AutoSize = True
        Me.lblLimSuperior.Location = New System.Drawing.Point(34, 98)
        Me.lblLimSuperior.Name = "lblLimSuperior"
        Me.lblLimSuperior.Size = New System.Drawing.Size(83, 13)
        Me.lblLimSuperior.TabIndex = 41
        Me.lblLimSuperior.Text = "* Límite superior"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"SEMANAL", "CATORCENAL", "QUINCENAL", "MENSUAL"})
        Me.cmbTipo.Location = New System.Drawing.Point(146, 30)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(145, 21)
        Me.cmbTipo.TabIndex = 38
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(33, 33)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(35, 13)
        Me.lblTipo.TabIndex = 39
        Me.lblTipo.Text = "* Tipo"
        '
        'txtLimiteInferior
        '
        Me.txtLimiteInferior.Location = New System.Drawing.Point(146, 63)
        Me.txtLimiteInferior.MaxLength = 30
        Me.txtLimiteInferior.Name = "txtLimiteInferior"
        Me.txtLimiteInferior.Size = New System.Drawing.Size(145, 20)
        Me.txtLimiteInferior.TabIndex = 4
        '
        'lblLimInferior
        '
        Me.lblLimInferior.AutoSize = True
        Me.lblLimInferior.Location = New System.Drawing.Point(33, 63)
        Me.lblLimInferior.Name = "lblLimInferior"
        Me.lblLimInferior.Size = New System.Drawing.Size(77, 13)
        Me.lblLimInferior.TabIndex = 26
        Me.lblLimInferior.Text = "* Límite inferior"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 222)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(362, 60)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(245, 0)
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
        Me.pnlCabecera.Size = New System.Drawing.Size(362, 60)
        Me.pnlCabecera.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-19, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(311, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(4, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 24)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(123, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(179, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta/Edición Subsidio"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(292, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaEdicion_TablasSPEForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 342)
        Me.Controls.Add(Me.pnlContenedor)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(370, 369)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(370, 369)
        Me.Name = "AltaEdicion_TablasSPEForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.gpbCampos.ResumeLayout(False)
        Me.gpbCampos.PerformLayout()
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

    Friend WithEvents pnlContenedor As Windows.Forms.Panel
    Friend WithEvents pnlContenido As Windows.Forms.Panel
    Friend WithEvents pnlInformacionAlta As Windows.Forms.Panel
    Friend WithEvents gpbCampos As Windows.Forms.GroupBox
    Friend WithEvents txtSubsidio As Windows.Forms.TextBox
    Friend WithEvents lblSubsidio As Windows.Forms.Label
    Friend WithEvents txtLimiteSuperior As Windows.Forms.TextBox
    Friend WithEvents lblLimSuperior As Windows.Forms.Label
    Friend WithEvents cmbTipo As Windows.Forms.ComboBox
    Friend WithEvents lblTipo As Windows.Forms.Label
    Friend WithEvents txtLimiteInferior As Windows.Forms.TextBox
    Friend WithEvents lblLimInferior As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents pnlCabecera As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
