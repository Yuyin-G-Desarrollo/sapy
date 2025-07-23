<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarAreaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarAreaForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.grbArea = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbArea.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblAreas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(394, 60)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAreas.Location = New System.Drawing.Point(257, 21)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(56, 20)
        Me.lblAreas.TabIndex = 21
        Me.lblAreas.Text = "Áreas"
        '
        'grbArea
        '
        Me.grbArea.Controls.Add(Me.lblActivo)
        Me.grbArea.Controls.Add(Me.GroupBox2)
        Me.grbArea.Controls.Add(Me.lblNave)
        Me.grbArea.Controls.Add(Me.cmbNave)
        Me.grbArea.Controls.Add(Me.txtNombre)
        Me.grbArea.Controls.Add(Me.lblNombre)
        Me.grbArea.Location = New System.Drawing.Point(22, 81)
        Me.grbArea.Name = "grbArea"
        Me.grbArea.Size = New System.Drawing.Size(340, 240)
        Me.grbArea.TabIndex = 9
        Me.grbArea.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(51, 135)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 41
        Me.lblActivo.Text = "Activo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSi)
        Me.GroupBox2.Controls.Add(Me.btnNo)
        Me.GroupBox2.Location = New System.Drawing.Point(107, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 34)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'btnSi
        '
        Me.btnSi.AutoSize = True
        Me.btnSi.Checked = True
        Me.btnSi.Location = New System.Drawing.Point(19, 11)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(36, 17)
        Me.btnSi.TabIndex = 5
        Me.btnSi.TabStop = True
        Me.btnSi.Text = "Sí"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(126, 11)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 6
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(51, 87)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 37
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(107, 84)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(187, 21)
        Me.cmbNave.TabIndex = 36
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(107, 43)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(187, 20)
        Me.txtNombre.TabIndex = 35
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(51, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 34
        Me.lblNombre.Text = "Nombre"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(323, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 42
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(276, 37)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 41
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(281, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 39
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(330, 3)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 40
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnCncelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 371)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 57)
        Me.Panel1.TabIndex = 43
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(326, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 49
        Me.pcbTitulo.TabStop = False
        '
        'EditarAreaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 428)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbArea)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarAreaForm"
        Me.Text = "Áreas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbArea.ResumeLayout(False)
        Me.grbArea.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblAreas As System.Windows.Forms.Label
    Friend WithEvents grbArea As System.Windows.Forms.GroupBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents lblNombre As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
