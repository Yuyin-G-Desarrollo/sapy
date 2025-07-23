<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPatronesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPatronesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEditarPatrones = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNombreDelPuesto = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreDelPatron = New System.Windows.Forms.TextBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblEditarPatrones)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Location = New System.Drawing.Point(1, 4)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(462, 67)
        Me.pnlEncabezado.TabIndex = 5
        '
        'lblEditarPatrones
        '
        Me.lblEditarPatrones.AutoSize = True
        Me.lblEditarPatrones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPatrones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEditarPatrones.Location = New System.Drawing.Point(327, 43)
        Me.lblEditarPatrones.Name = "lblEditarPatrones"
        Me.lblEditarPatrones.Size = New System.Drawing.Size(134, 20)
        Me.lblEditarPatrones.TabIndex = 21
        Me.lblEditarPatrones.Text = "Editar Patrones"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(328, 4)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNombreDelPuesto)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Controls.Add(Me.txtNombreDelPatron)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 187)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'lblNombreDelPuesto
        '
        Me.lblNombreDelPuesto.AutoSize = True
        Me.lblNombreDelPuesto.Location = New System.Drawing.Point(28, 26)
        Me.lblNombreDelPuesto.Name = "lblNombreDelPuesto"
        Me.lblNombreDelPuesto.Size = New System.Drawing.Size(101, 13)
        Me.lblNombreDelPuesto.TabIndex = 7
        Me.lblNombreDelPuesto.Text = "*Nombre del  patron"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(28, 66)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 6
        Me.lblNave.Text = "*Nave"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSi)
        Me.GroupBox2.Controls.Add(Me.btnNo)
        Me.GroupBox2.Location = New System.Drawing.Point(172, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 38)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btnSi
        '
        Me.btnSi.AutoSize = True
        Me.btnSi.Location = New System.Drawing.Point(7, 14)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(36, 17)
        Me.btnSi.TabIndex = 4
        Me.btnSi.TabStop = True
        Me.btnSi.Text = "Sí"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(88, 14)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 5
        Me.btnNo.TabStop = True
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(172, 66)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(146, 21)
        Me.cmbNave.TabIndex = 2
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(26, 110)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'txtNombreDelPatron
        '
        Me.txtNombreDelPatron.Location = New System.Drawing.Point(172, 26)
        Me.txtNombreDelPatron.MaxLength = 50
        Me.txtNombreDelPatron.Name = "txtNombreDelPatron"
        Me.txtNombreDelPatron.Size = New System.Drawing.Size(146, 20)
        Me.txtNombreDelPatron.TabIndex = 1
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(389, 324)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 43
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(313, 324)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 42
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(319, 286)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 40
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(395, 286)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 41
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'EditarPatronesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(465, 364)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarPatronesForm"
        Me.Text = "EditarPatronesForm"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblEditarPatrones As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents lblNombreDelPuesto As System.Windows.Forms.Label
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents txtNombreDelPatron As System.Windows.Forms.TextBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
End Class
