<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasMotivosCancelacion_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasMotivosCancelacion_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.grbArea = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtActivoSi = New System.Windows.Forms.RadioButton()
        Me.rbtActivoNo = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbnSi = New System.Windows.Forms.RadioButton()
        Me.rbnNo = New System.Windows.Forms.RadioButton()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbCancelacionSat = New System.Windows.Forms.ComboBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbArea.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblAreas)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(420, 56)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAreas.Location = New System.Drawing.Point(117, 18)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(232, 20)
        Me.lblAreas.TabIndex = 21
        Me.lblAreas.Text = "Alta motivos de cancelación"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(352, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 47
        Me.pbYuyin.TabStop = False
        '
        'grbArea
        '
        Me.grbArea.Controls.Add(Me.GroupBox1)
        Me.grbArea.Controls.Add(Me.Label1)
        Me.grbArea.Controls.Add(Me.lblActivo)
        Me.grbArea.Controls.Add(Me.GroupBox2)
        Me.grbArea.Controls.Add(Me.lblNave)
        Me.grbArea.Controls.Add(Me.cmbCancelacionSat)
        Me.grbArea.Controls.Add(Me.txtMotivo)
        Me.grbArea.Controls.Add(Me.lblMotivo)
        Me.grbArea.Location = New System.Drawing.Point(26, 76)
        Me.grbArea.Name = "grbArea"
        Me.grbArea.Size = New System.Drawing.Size(367, 203)
        Me.grbArea.TabIndex = 9
        Me.grbArea.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtActivoSi)
        Me.GroupBox1.Controls.Add(Me.rbtActivoNo)
        Me.GroupBox1.Location = New System.Drawing.Point(141, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 34)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'rbtActivoSi
        '
        Me.rbtActivoSi.AutoSize = True
        Me.rbtActivoSi.Checked = True
        Me.rbtActivoSi.ForeColor = System.Drawing.Color.Black
        Me.rbtActivoSi.Location = New System.Drawing.Point(31, 11)
        Me.rbtActivoSi.Name = "rbtActivoSi"
        Me.rbtActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rbtActivoSi.TabIndex = 5
        Me.rbtActivoSi.TabStop = True
        Me.rbtActivoSi.Text = "Si"
        Me.rbtActivoSi.UseVisualStyleBackColor = True
        '
        'rbtActivoNo
        '
        Me.rbtActivoNo.AutoSize = True
        Me.rbtActivoNo.ForeColor = System.Drawing.Color.Black
        Me.rbtActivoNo.Location = New System.Drawing.Point(135, 11)
        Me.rbtActivoNo.Name = "rbtActivoNo"
        Me.rbtActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtActivoNo.TabIndex = 6
        Me.rbtActivoNo.Text = "No"
        Me.rbtActivoNo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(94, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Activo"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.Black
        Me.lblActivo.Location = New System.Drawing.Point(47, 76)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(84, 13)
        Me.lblActivo.TabIndex = 41
        Me.lblActivo.Text = "¿ Se relaciona ?"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbnSi)
        Me.GroupBox2.Controls.Add(Me.rbnNo)
        Me.GroupBox2.Location = New System.Drawing.Point(143, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 34)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'rbnSi
        '
        Me.rbnSi.AutoSize = True
        Me.rbnSi.Checked = True
        Me.rbnSi.ForeColor = System.Drawing.Color.Black
        Me.rbnSi.Location = New System.Drawing.Point(31, 11)
        Me.rbnSi.Name = "rbnSi"
        Me.rbnSi.Size = New System.Drawing.Size(34, 17)
        Me.rbnSi.TabIndex = 2
        Me.rbnSi.TabStop = True
        Me.rbnSi.Text = "Si"
        Me.rbnSi.UseVisualStyleBackColor = True
        '
        'rbnNo
        '
        Me.rbnNo.AutoSize = True
        Me.rbnNo.ForeColor = System.Drawing.Color.Black
        Me.rbnNo.Location = New System.Drawing.Point(135, 11)
        Me.rbnNo.Name = "rbnNo"
        Me.rbnNo.Size = New System.Drawing.Size(39, 17)
        Me.rbnNo.TabIndex = 3
        Me.rbnNo.Text = "No"
        Me.rbnNo.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(11, 115)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(125, 13)
        Me.lblNave.TabIndex = 37
        Me.lblNave.Text = "Motivo Cancelación SAT"
        '
        'cmbCancelacionSat
        '
        Me.cmbCancelacionSat.FormattingEnabled = True
        Me.cmbCancelacionSat.Location = New System.Drawing.Point(142, 112)
        Me.cmbCancelacionSat.Name = "cmbCancelacionSat"
        Me.cmbCancelacionSat.Size = New System.Drawing.Size(197, 21)
        Me.cmbCancelacionSat.TabIndex = 4
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(143, 31)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(195, 20)
        Me.txtMotivo.TabIndex = 1
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.ForeColor = System.Drawing.Color.Black
        Me.lblMotivo.Location = New System.Drawing.Point(92, 34)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(39, 13)
        Me.lblMotivo.TabIndex = 34
        Me.lblMotivo.Text = "Motivo"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.btnCncelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 304)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 64)
        Me.Panel1.TabIndex = 40
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(355, 7)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 8
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(305, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 37
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(354, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 38
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(311, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'AltasMotivosCancelacion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(420, 368)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbArea)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltasMotivosCancelacion_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta motivo cancelación"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbArea.ResumeLayout(False)
        Me.grbArea.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblAreas As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents grbArea As GroupBox
    Friend WithEvents lblActivo As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbnSi As RadioButton
    Friend WithEvents rbnNo As RadioButton
    Friend WithEvents lblNave As Label
    Friend WithEvents cmbCancelacionSat As ComboBox
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents lblMotivo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCncelar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbtActivoSi As RadioButton
    Friend WithEvents rbtActivoNo As RadioButton
    Friend WithEvents Label1 As Label
End Class
