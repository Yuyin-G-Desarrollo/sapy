<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasNavesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasNavesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblLAltasNaves = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.rdoNo = New System.Windows.Forms.RadioButton()
		Me.rdoSi = New System.Windows.Forms.RadioButton()
		Me.txtNombreNave = New System.Windows.Forms.TextBox()
		Me.lblNombreDeLaNave = New System.Windows.Forms.Label()
		Me.lblActivo = New System.Windows.Forms.Label()
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
		Me.pnlEncabezado.Controls.Add(Me.lblLAltasNaves)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(4, 4)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(412, 70)
		Me.pnlEncabezado.TabIndex = 3
		'
		'lblLAltasNaves
		'
		Me.lblLAltasNaves.AutoSize = True
		Me.lblLAltasNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLAltasNaves.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblLAltasNaves.Location = New System.Drawing.Point(302, 48)
		Me.lblLAltasNaves.Name = "lblLAltasNaves"
		Me.lblLAltasNaves.Size = New System.Drawing.Size(104, 20)
		Me.lblLAltasNaves.TabIndex = 22
		Me.lblLAltasNaves.Text = "Altas Naves"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(279, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Controls.Add(Me.txtNombreNave)
		Me.GroupBox1.Controls.Add(Me.lblNombreDeLaNave)
		Me.GroupBox1.Controls.Add(Me.lblActivo)
		Me.GroupBox1.Location = New System.Drawing.Point(11, 80)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(395, 142)
		Me.GroupBox1.TabIndex = 4
		Me.GroupBox1.TabStop = False
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.rdoNo)
		Me.GroupBox2.Controls.Add(Me.rdoSi)
		Me.GroupBox2.Location = New System.Drawing.Point(147, 52)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(142, 37)
		Me.GroupBox2.TabIndex = 4
		Me.GroupBox2.TabStop = False
		'
		'rdoNo
		'
		Me.rdoNo.AutoSize = True
		Me.rdoNo.Location = New System.Drawing.Point(90, 12)
		Me.rdoNo.Name = "rdoNo"
		Me.rdoNo.Size = New System.Drawing.Size(39, 17)
		Me.rdoNo.TabIndex = 4
		Me.rdoNo.Text = "No"
		Me.rdoNo.UseVisualStyleBackColor = True
		'
		'rdoSi
		'
		Me.rdoSi.AutoSize = True
		Me.rdoSi.Checked = True
		Me.rdoSi.Location = New System.Drawing.Point(9, 12)
		Me.rdoSi.Name = "rdoSi"
		Me.rdoSi.Size = New System.Drawing.Size(36, 17)
		Me.rdoSi.TabIndex = 3
		Me.rdoSi.TabStop = True
		Me.rdoSi.Text = "Sí"
		Me.rdoSi.UseVisualStyleBackColor = True
		'
		'txtNombreNave
		'
		Me.txtNombreNave.Location = New System.Drawing.Point(147, 26)
		Me.txtNombreNave.Name = "txtNombreNave"
		Me.txtNombreNave.Size = New System.Drawing.Size(142, 20)
		Me.txtNombreNave.TabIndex = 1
		'
		'lblNombreDeLaNave
		'
		Me.lblNombreDeLaNave.AutoSize = True
		Me.lblNombreDeLaNave.Location = New System.Drawing.Point(52, 33)
		Me.lblNombreDeLaNave.Name = "lblNombreDeLaNave"
		Me.lblNombreDeLaNave.Size = New System.Drawing.Size(47, 13)
		Me.lblNombreDeLaNave.TabIndex = 7
		Me.lblNombreDeLaNave.Text = "Nombre "
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(52, 69)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 6
		Me.lblActivo.Text = "Activo"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(336, 278)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 34
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(260, 278)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 33
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(266, 240)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 31
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(342, 240)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 32
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'AltasNavesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(418, 335)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasNavesForm"
		Me.Text = "Altas Naves"
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
	Friend WithEvents lblLAltasNaves As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents txtNombreNave As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreDeLaNave As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
End Class
