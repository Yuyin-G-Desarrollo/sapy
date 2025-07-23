<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPeriodoVacacionesForm
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
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblm1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFFN = New System.Windows.Forms.DateTimePicker()
        Me.dtpFIN = New System.Windows.Forms.DateTimePicker()
        Me.dtpFFSS = New System.Windows.Forms.DateTimePicker()
        Me.dtpFISS = New System.Windows.Forms.DateTimePicker()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.txtidpatron = New System.Windows.Forms.TextBox()
        Me.lblN = New System.Windows.Forms.Label()
        Me.lblSS = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.txtPatron = New System.Windows.Forms.TextBox()
        Me.lblNombreDepartamento = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(617, 60)
        Me.pnlCabecera.TabIndex = 11
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(316, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(231, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(7, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(221, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Editar Periodo Vacaciones"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(547, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblm1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpFFN)
        Me.Panel1.Controls.Add(Me.dtpFIN)
        Me.Panel1.Controls.Add(Me.dtpFFSS)
        Me.Panel1.Controls.Add(Me.dtpFISS)
        Me.Panel1.Controls.Add(Me.cmbAnio)
        Me.Panel1.Controls.Add(Me.txtidpatron)
        Me.Panel1.Controls.Add(Me.lblN)
        Me.Panel1.Controls.Add(Me.lblSS)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.txtPatron)
        Me.Panel1.Controls.Add(Me.lblNombreDepartamento)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 293)
        Me.Panel1.TabIndex = 34
        '
        'lblm1
        '
        Me.lblm1.AutoSize = True
        Me.lblm1.Location = New System.Drawing.Point(162, 186)
        Me.lblm1.Name = "lblm1"
        Me.lblm1.Size = New System.Drawing.Size(240, 26)
        Me.lblm1.TabIndex = 44
        Me.lblm1.Text = "Solo se pueden editar las fechas cuyo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "periodo de nomina fiscal no se encuentre " &
    "cerrado"
        Me.lblm1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(268, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "* Al"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(268, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "* Al"
        '
        'dtpFFN
        '
        Me.dtpFFN.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFN.Location = New System.Drawing.Point(302, 140)
        Me.dtpFFN.Name = "dtpFFN"
        Me.dtpFFN.Size = New System.Drawing.Size(121, 20)
        Me.dtpFFN.TabIndex = 41
        '
        'dtpFIN
        '
        Me.dtpFIN.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFIN.Location = New System.Drawing.Point(141, 139)
        Me.dtpFIN.Name = "dtpFIN"
        Me.dtpFIN.Size = New System.Drawing.Size(121, 20)
        Me.dtpFIN.TabIndex = 40
        '
        'dtpFFSS
        '
        Me.dtpFFSS.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFSS.Location = New System.Drawing.Point(302, 104)
        Me.dtpFFSS.Name = "dtpFFSS"
        Me.dtpFFSS.Size = New System.Drawing.Size(121, 20)
        Me.dtpFFSS.TabIndex = 39
        '
        'dtpFISS
        '
        Me.dtpFISS.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFISS.Location = New System.Drawing.Point(141, 104)
        Me.dtpFISS.Name = "dtpFISS"
        Me.dtpFISS.Size = New System.Drawing.Size(121, 20)
        Me.dtpFISS.TabIndex = 38
        '
        'cmbAnio
        '
        Me.cmbAnio.Enabled = False
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(141, 71)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(121, 21)
        Me.cmbAnio.TabIndex = 37
        '
        'txtidpatron
        '
        Me.txtidpatron.Enabled = False
        Me.txtidpatron.Location = New System.Drawing.Point(482, 35)
        Me.txtidpatron.MaxLength = 30
        Me.txtidpatron.Name = "txtidpatron"
        Me.txtidpatron.Size = New System.Drawing.Size(55, 20)
        Me.txtidpatron.TabIndex = 32
        Me.txtidpatron.Visible = False
        '
        'lblN
        '
        Me.lblN.AutoSize = True
        Me.lblN.Location = New System.Drawing.Point(33, 146)
        Me.lblN.Name = "lblN"
        Me.lblN.Size = New System.Drawing.Size(93, 13)
        Me.lblN.TabIndex = 36
        Me.lblN.Text = "* Periodo Navidad"
        '
        'lblSS
        '
        Me.lblSS.AutoSize = True
        Me.lblSS.Location = New System.Drawing.Point(3, 110)
        Me.lblSS.Name = "lblSS"
        Me.lblSS.Size = New System.Drawing.Size(123, 13)
        Me.lblSS.TabIndex = 35
        Me.lblSS.Text = "* Periodo Semana Santa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "* Año"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 229)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(617, 64)
        Me.Panel2.TabIndex = 33
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.pnlGuardar)
        Me.pnlBotones.Controls.Add(Me.pnlCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(417, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(200, 64)
        Me.pnlBotones.TabIndex = 3
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(71, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(66, 64)
        Me.pnlGuardar.TabIndex = 12
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(16, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(11, 44)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCancelar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(137, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(63, 64)
        Me.pnlCerrar.TabIndex = 11
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(12, 9)
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
        Me.lblCancelar.Location = New System.Drawing.Point(12, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'txtPatron
        '
        Me.txtPatron.BackColor = System.Drawing.SystemColors.Control
        Me.txtPatron.Enabled = False
        Me.txtPatron.Location = New System.Drawing.Point(141, 35)
        Me.txtPatron.MaxLength = 30
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(338, 20)
        Me.txtPatron.TabIndex = 30
        '
        'lblNombreDepartamento
        '
        Me.lblNombreDepartamento.AutoSize = True
        Me.lblNombreDepartamento.Location = New System.Drawing.Point(81, 38)
        Me.lblNombreDepartamento.Name = "lblNombreDepartamento"
        Me.lblNombreDepartamento.Size = New System.Drawing.Size(45, 13)
        Me.lblNombreDepartamento.TabIndex = 31
        Me.lblNombreDepartamento.Text = "* Patron"
        '
        'EditarPeriodoVacacionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 353)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarPeriodoVacacionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Periodo Vacaciones"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents dtpFFN As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFIN As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFSS As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFISS As Windows.Forms.DateTimePicker
    Friend WithEvents cmbAnio As Windows.Forms.ComboBox
    Public WithEvents txtidpatron As Windows.Forms.TextBox
    Friend WithEvents lblN As Windows.Forms.Label
    Friend WithEvents lblSS As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents pnlGuardar As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents pnlCerrar As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Public WithEvents txtPatron As Windows.Forms.TextBox
    Friend WithEvents lblNombreDepartamento As Windows.Forms.Label
    Friend WithEvents lblm1 As Windows.Forms.Label
End Class
