<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasMotivosPrestamosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasMotivosPrestamosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblListaMotivosPrestamos = New System.Windows.Forms.Label()
		Me.grbBancos = New System.Windows.Forms.GroupBox()
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.rdoNo = New System.Windows.Forms.RadioButton()
		Me.rdoSi = New System.Windows.Forms.RadioButton()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lblNombreBanco = New System.Windows.Forms.Label()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.pnlEncabezado.SuspendLayout()
		Me.grbBancos.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblListaMotivosPrestamos)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(2, 0)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(497, 67)
		Me.pnlEncabezado.TabIndex = 5
		'
		'lblListaMotivosPrestamos
		'
		Me.lblListaMotivosPrestamos.AutoSize = True
		Me.lblListaMotivosPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaMotivosPrestamos.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblListaMotivosPrestamos.Location = New System.Drawing.Point(287, 43)
		Me.lblListaMotivosPrestamos.Name = "lblListaMotivosPrestamos"
		Me.lblListaMotivosPrestamos.Size = New System.Drawing.Size(206, 20)
		Me.lblListaMotivosPrestamos.TabIndex = 21
		Me.lblListaMotivosPrestamos.Text = "Altas Motivos Prestamos"
		'
		'grbBancos
		'
		Me.grbBancos.Controls.Add(Me.cmbNave)
		Me.grbBancos.Controls.Add(Me.lblNave)
		Me.grbBancos.Controls.Add(Me.GroupBox2)
		Me.grbBancos.Controls.Add(Me.txtNombre)
		Me.grbBancos.Controls.Add(Me.lblNombreBanco)
		Me.grbBancos.Controls.Add(Me.lblActivo)
		Me.grbBancos.Location = New System.Drawing.Point(7, 73)
		Me.grbBancos.Name = "grbBancos"
		Me.grbBancos.Size = New System.Drawing.Size(481, 206)
		Me.grbBancos.TabIndex = 6
		Me.grbBancos.TabStop = False
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(89, 100)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(142, 21)
		Me.cmbNave.TabIndex = 24
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(42, 103)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(33, 13)
		Me.lblNave.TabIndex = 23
		Me.lblNave.Text = "Nave"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.rdoNo)
		Me.GroupBox2.Controls.Add(Me.rdoSi)
		Me.GroupBox2.Location = New System.Drawing.Point(89, 130)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(142, 37)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = False
		'
		'rdoNo
		'
		Me.rdoNo.AutoSize = True
		Me.rdoNo.Location = New System.Drawing.Point(90, 12)
		Me.rdoNo.Name = "rdoNo"
		Me.rdoNo.Size = New System.Drawing.Size(39, 17)
		Me.rdoNo.TabIndex = 7
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
		Me.rdoSi.TabIndex = 6
		Me.rdoSi.TabStop = True
		Me.rdoSi.Text = "Sí"
		Me.rdoSi.UseVisualStyleBackColor = True
		'
		'txtNombre
		'
		Me.txtNombre.Location = New System.Drawing.Point(89, 36)
		Me.txtNombre.MaxLength = 500
		Me.txtNombre.Multiline = True
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(368, 48)
		Me.txtNombre.TabIndex = 4
		'
		'lblNombreBanco
		'
		Me.lblNombreBanco.AutoSize = True
		Me.lblNombreBanco.Location = New System.Drawing.Point(31, 53)
		Me.lblNombreBanco.Name = "lblNombreBanco"
		Me.lblNombreBanco.Size = New System.Drawing.Size(44, 13)
		Me.lblNombreBanco.TabIndex = 1
		Me.lblNombreBanco.Text = "Nombre"
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(38, 146)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 0
		Me.lblActivo.Text = "Activo"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(436, 338)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 34
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(360, 338)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 33
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(366, 300)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 31
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(442, 300)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 32
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(357, 2)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'AltasMotivosPrestamosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(499, 381)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grbBancos)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasMotivosPrestamosForm"
		Me.Text = "Altas Motivos Prestamos"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		Me.grbBancos.ResumeLayout(False)
		Me.grbBancos.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaMotivosPrestamos As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbBancos As System.Windows.Forms.GroupBox
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreBanco As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
End Class
