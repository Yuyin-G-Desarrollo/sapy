<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarSalariosMinimos_UmasForm
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtmontoUMA = New System.Windows.Forms.MaskedTextBox()
        Me.txtmontosalariominimo = New System.Windows.Forms.MaskedTextBox()
        Me.lblNumeroCuentaSicy = New System.Windows.Forms.Label()
        Me.lblCuentaHabiente = New System.Windows.Forms.Label()
        Me.txtaño = New System.Windows.Forms.TextBox()
        Me.lblNumeroCuenta = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtmontoUMI = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 221)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(424, 62)
        Me.pnlPie.TabIndex = 7
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(307, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 62)
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
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(18, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(424, 283)
        Me.pnlInformacionAlta.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtmontoUMI)
        Me.GroupBox1.Controls.Add(Me.txtmontoUMA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtmontosalariominimo)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCuentaSicy)
        Me.GroupBox1.Controls.Add(Me.lblCuentaHabiente)
        Me.GroupBox1.Controls.Add(Me.txtaño)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCuenta)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 283)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtmontoUMA
        '
        Me.txtmontoUMA.Location = New System.Drawing.Point(198, 150)
        Me.txtmontoUMA.Name = "txtmontoUMA"
        Me.txtmontoUMA.Size = New System.Drawing.Size(100, 20)
        Me.txtmontoUMA.TabIndex = 42
        '
        'txtmontosalariominimo
        '
        Me.txtmontosalariominimo.Location = New System.Drawing.Point(198, 119)
        Me.txtmontosalariominimo.Name = "txtmontosalariominimo"
        Me.txtmontosalariominimo.Size = New System.Drawing.Size(100, 20)
        Me.txtmontosalariominimo.TabIndex = 41
        '
        'lblNumeroCuentaSicy
        '
        Me.lblNumeroCuentaSicy.AutoSize = True
        Me.lblNumeroCuentaSicy.Location = New System.Drawing.Point(121, 153)
        Me.lblNumeroCuentaSicy.Name = "lblNumeroCuentaSicy"
        Me.lblNumeroCuentaSicy.Size = New System.Drawing.Size(71, 13)
        Me.lblNumeroCuentaSicy.TabIndex = 38
        Me.lblNumeroCuentaSicy.Text = "* Monto UMA"
        '
        'lblCuentaHabiente
        '
        Me.lblCuentaHabiente.AutoSize = True
        Me.lblCuentaHabiente.Location = New System.Drawing.Point(62, 122)
        Me.lblCuentaHabiente.Name = "lblCuentaHabiente"
        Me.lblCuentaHabiente.Size = New System.Drawing.Size(130, 13)
        Me.lblCuentaHabiente.TabIndex = 37
        Me.lblCuentaHabiente.Text = "* Monto de Salario Minimo"
        '
        'txtaño
        '
        Me.txtaño.Enabled = False
        Me.txtaño.Location = New System.Drawing.Point(198, 89)
        Me.txtaño.MaxLength = 30
        Me.txtaño.Name = "txtaño"
        Me.txtaño.Size = New System.Drawing.Size(55, 20)
        Me.txtaño.TabIndex = 34
        '
        'lblNumeroCuenta
        '
        Me.lblNumeroCuenta.AutoSize = True
        Me.lblNumeroCuenta.Location = New System.Drawing.Point(159, 92)
        Me.lblNumeroCuenta.Name = "lblNumeroCuenta"
        Me.lblNumeroCuenta.Size = New System.Drawing.Size(33, 13)
        Me.lblNumeroCuenta.TabIndex = 36
        Me.lblNumeroCuenta.Text = "* Año"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(354, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(424, 60)
        Me.pnlCabecera.TabIndex = 6
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(21, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(315, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Catálogo de Salarios Minimos y UMAS"
        '
        'txtmontoUMI
        '
        Me.txtmontoUMI.Location = New System.Drawing.Point(198, 184)
        Me.txtmontoUMI.Name = "txtmontoUMI"
        Me.txtmontoUMI.Size = New System.Drawing.Size(100, 20)
        Me.txtmontoUMI.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "* Monto UMI"
        '
        'EditarSalariosMinimos_UmasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 283)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Controls.Add(Me.pnlInformacionAlta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarSalariosMinimos_UmasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo de Salarios Minimos y UMAS "
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents pnlInformacionAlta As Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lblNumeroCuentaSicy As Windows.Forms.Label
    Friend WithEvents lblCuentaHabiente As Windows.Forms.Label
    Friend WithEvents txtaño As Windows.Forms.TextBox
    Friend WithEvents lblNumeroCuenta As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
    Friend WithEvents pnlCabecera As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents txtmontosalariominimo As Windows.Forms.MaskedTextBox
    Friend WithEvents txtmontoUMA As Windows.Forms.MaskedTextBox
    Friend WithEvents txtmontoUMI As Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
