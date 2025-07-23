<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaDepartamentosForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtdepartamento = New System.Windows.Forms.TextBox()
        Me.cmbClave_A = New System.Windows.Forms.ComboBox()
        Me.cmbPrimaV = New System.Windows.Forms.ComboBox()
        Me.cmbC_PremioP = New System.Windows.Forms.ComboBox()
        Me.cmbPremio_P = New System.Windows.Forms.ComboBox()
        Me.cmbClaveV = New System.Windows.Forms.ComboBox()
        Me.cmbC_Sueldo = New System.Windows.Forms.ComboBox()
        Me.lblca2 = New System.Windows.Forms.Label()
        Me.lblcpv = New System.Windows.Forms.Label()
        Me.lblca = New System.Windows.Forms.Label()
        Me.lblcpa = New System.Windows.Forms.Label()
        Me.lblcpp = New System.Windows.Forms.Label()
        Me.lblcs = New System.Windows.Forms.Label()
        Me.txtidpatron = New System.Windows.Forms.TextBox()
        Me.lbldepa = New System.Windows.Forms.Label()
        Me.txtPatron = New System.Windows.Forms.TextBox()
        Me.lblNombreDepartamento = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 367)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(517, 71)
        Me.pnlPie.TabIndex = 10
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(400, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(15, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.txtdepartamento)
        Me.GroupBox1.Controls.Add(Me.cmbClave_A)
        Me.GroupBox1.Controls.Add(Me.cmbPrimaV)
        Me.GroupBox1.Controls.Add(Me.cmbC_PremioP)
        Me.GroupBox1.Controls.Add(Me.cmbPremio_P)
        Me.GroupBox1.Controls.Add(Me.cmbClaveV)
        Me.GroupBox1.Controls.Add(Me.cmbC_Sueldo)
        Me.GroupBox1.Controls.Add(Me.lblca2)
        Me.GroupBox1.Controls.Add(Me.lblcpv)
        Me.GroupBox1.Controls.Add(Me.lblca)
        Me.GroupBox1.Controls.Add(Me.lblcpa)
        Me.GroupBox1.Controls.Add(Me.lblcpp)
        Me.GroupBox1.Controls.Add(Me.lblcs)
        Me.GroupBox1.Controls.Add(Me.txtidpatron)
        Me.GroupBox1.Controls.Add(Me.lbldepa)
        Me.GroupBox1.Controls.Add(Me.txtPatron)
        Me.GroupBox1.Controls.Add(Me.lblNombreDepartamento)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 378)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'txtdepartamento
        '
        Me.txtdepartamento.Location = New System.Drawing.Point(166, 59)
        Me.txtdepartamento.MaxLength = 30
        Me.txtdepartamento.Name = "txtdepartamento"
        Me.txtdepartamento.Size = New System.Drawing.Size(204, 20)
        Me.txtdepartamento.TabIndex = 1
        '
        'cmbClave_A
        '
        Me.cmbClave_A.FormattingEnabled = True
        Me.cmbClave_A.Location = New System.Drawing.Point(166, 220)
        Me.cmbClave_A.Name = "cmbClave_A"
        Me.cmbClave_A.Size = New System.Drawing.Size(204, 21)
        Me.cmbClave_A.TabIndex = 7
        '
        'cmbPrimaV
        '
        Me.cmbPrimaV.FormattingEnabled = True
        Me.cmbPrimaV.Location = New System.Drawing.Point(166, 193)
        Me.cmbPrimaV.Name = "cmbPrimaV"
        Me.cmbPrimaV.Size = New System.Drawing.Size(204, 21)
        Me.cmbPrimaV.TabIndex = 6
        '
        'cmbC_PremioP
        '
        Me.cmbC_PremioP.FormattingEnabled = True
        Me.cmbC_PremioP.Location = New System.Drawing.Point(166, 112)
        Me.cmbC_PremioP.Name = "cmbC_PremioP"
        Me.cmbC_PremioP.Size = New System.Drawing.Size(204, 21)
        Me.cmbC_PremioP.TabIndex = 3
        '
        'cmbPremio_P
        '
        Me.cmbPremio_P.FormattingEnabled = True
        Me.cmbPremio_P.Location = New System.Drawing.Point(166, 139)
        Me.cmbPremio_P.Name = "cmbPremio_P"
        Me.cmbPremio_P.Size = New System.Drawing.Size(204, 21)
        Me.cmbPremio_P.TabIndex = 4
        '
        'cmbClaveV
        '
        Me.cmbClaveV.FormattingEnabled = True
        Me.cmbClaveV.Location = New System.Drawing.Point(166, 166)
        Me.cmbClaveV.Name = "cmbClaveV"
        Me.cmbClaveV.Size = New System.Drawing.Size(204, 21)
        Me.cmbClaveV.TabIndex = 5
        '
        'cmbC_Sueldo
        '
        Me.cmbC_Sueldo.FormattingEnabled = True
        Me.cmbC_Sueldo.Location = New System.Drawing.Point(166, 85)
        Me.cmbC_Sueldo.Name = "cmbC_Sueldo"
        Me.cmbC_Sueldo.Size = New System.Drawing.Size(204, 21)
        Me.cmbC_Sueldo.TabIndex = 2
        '
        'lblca2
        '
        Me.lblca2.AutoSize = True
        Me.lblca2.Location = New System.Drawing.Point(64, 223)
        Me.lblca2.Name = "lblca2"
        Me.lblca2.Size = New System.Drawing.Size(91, 13)
        Me.lblca2.TabIndex = 41
        Me.lblca2.Text = "* Clave Aguinaldo"
        '
        'lblcpv
        '
        Me.lblcpv.AutoSize = True
        Me.lblcpv.Location = New System.Drawing.Point(29, 196)
        Me.lblcpv.Name = "lblcpv"
        Me.lblcpv.Size = New System.Drawing.Size(126, 13)
        Me.lblcpv.TabIndex = 39
        Me.lblcpv.Text = "* Clave Prima Vacacional"
        '
        'lblca
        '
        Me.lblca.AutoSize = True
        Me.lblca.Location = New System.Drawing.Point(55, 169)
        Me.lblca.Name = "lblca"
        Me.lblca.Size = New System.Drawing.Size(100, 13)
        Me.lblca.TabIndex = 37
        Me.lblca.Text = "* Clave Vacaciones"
        '
        'lblcpa
        '
        Me.lblcpa.AutoSize = True
        Me.lblcpa.Location = New System.Drawing.Point(32, 142)
        Me.lblcpa.Name = "lblcpa"
        Me.lblcpa.Size = New System.Drawing.Size(123, 13)
        Me.lblcpa.TabIndex = 35
        Me.lblcpa.Text = " Clave Premio Asistencia"
        '
        'lblcpp
        '
        Me.lblcpp.AutoSize = True
        Me.lblcpp.Location = New System.Drawing.Point(27, 115)
        Me.lblcpp.Name = "lblcpp"
        Me.lblcpp.Size = New System.Drawing.Size(128, 13)
        Me.lblcpp.TabIndex = 33
        Me.lblcpp.Text = "Clave Premio Puntualidad"
        '
        'lblcs
        '
        Me.lblcs.AutoSize = True
        Me.lblcs.Location = New System.Drawing.Point(79, 88)
        Me.lblcs.Name = "lblcs"
        Me.lblcs.Size = New System.Drawing.Size(77, 13)
        Me.lblcs.TabIndex = 31
        Me.lblcs.Text = "* Clave Sueldo"
        '
        'txtidpatron
        '
        Me.txtidpatron.Enabled = False
        Me.txtidpatron.Location = New System.Drawing.Point(50, 31)
        Me.txtidpatron.MaxLength = 30
        Me.txtidpatron.Name = "txtidpatron"
        Me.txtidpatron.Size = New System.Drawing.Size(55, 20)
        Me.txtidpatron.TabIndex = 29
        Me.txtidpatron.Visible = False
        '
        'lbldepa
        '
        Me.lbldepa.AutoSize = True
        Me.lbldepa.Location = New System.Drawing.Point(75, 61)
        Me.lbldepa.Name = "lbldepa"
        Me.lbldepa.Size = New System.Drawing.Size(81, 13)
        Me.lbldepa.TabIndex = 28
        Me.lbldepa.Text = "* Departamento"
        '
        'txtPatron
        '
        Me.txtPatron.BackColor = System.Drawing.SystemColors.Control
        Me.txtPatron.Enabled = False
        Me.txtPatron.Location = New System.Drawing.Point(166, 30)
        Me.txtPatron.MaxLength = 30
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(338, 20)
        Me.txtPatron.TabIndex = 1
        '
        'lblNombreDepartamento
        '
        Me.lblNombreDepartamento.AutoSize = True
        Me.lblNombreDepartamento.Location = New System.Drawing.Point(111, 34)
        Me.lblNombreDepartamento.Name = "lblNombreDepartamento"
        Me.lblNombreDepartamento.Size = New System.Drawing.Size(45, 13)
        Me.lblNombreDepartamento.TabIndex = 26
        Me.lblNombreDepartamento.Text = "* Patron"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(517, 60)
        Me.pnlCabecera.TabIndex = 9
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(268, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(179, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(12, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(135, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta Percepción"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(447, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'AltaDepartamentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 438)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaDepartamentosForm"
        Me.Text = "Alta Percepción"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lblca2 As Windows.Forms.Label
    Friend WithEvents lblcpv As Windows.Forms.Label
    Friend WithEvents lblca As Windows.Forms.Label
    Friend WithEvents lblcpa As Windows.Forms.Label
    Friend WithEvents lblcpp As Windows.Forms.Label
    Friend WithEvents lblcs As Windows.Forms.Label
    Public WithEvents txtidpatron As Windows.Forms.TextBox
    Friend WithEvents lbldepa As Windows.Forms.Label
    Public WithEvents txtPatron As Windows.Forms.TextBox
    Friend WithEvents lblNombreDepartamento As Windows.Forms.Label
    Friend WithEvents pnlCabecera As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
    Friend WithEvents cmbC_Sueldo As Windows.Forms.ComboBox
    Public WithEvents txtdepartamento As Windows.Forms.TextBox
    Friend WithEvents cmbClave_A As Windows.Forms.ComboBox
    Friend WithEvents cmbPrimaV As Windows.Forms.ComboBox
    Friend WithEvents cmbC_PremioP As Windows.Forms.ComboBox
    Friend WithEvents cmbPremio_P As Windows.Forms.ComboBox
    Friend WithEvents cmbClaveV As Windows.Forms.ComboBox
End Class
