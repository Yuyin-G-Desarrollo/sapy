<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasAccionesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasAccionesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblLAltasAcciones = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.cmbTipo = New System.Windows.Forms.ComboBox()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.lblModulo = New System.Windows.Forms.Label()
		Me.txtNombreDeLaAccion = New System.Windows.Forms.TextBox()
		Me.lblNombreDeLaAccion = New System.Windows.Forms.Label()
		Me.grbAltasAcciones = New System.Windows.Forms.GroupBox()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.rdoActivo = New System.Windows.Forms.RadioButton()
		Me.rdoInactivo = New System.Windows.Forms.RadioButton()
		Me.lblClave = New System.Windows.Forms.Label()
		Me.txtClave = New System.Windows.Forms.TextBox()
		Me.cmbModulo = New System.Windows.Forms.ComboBox()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbAltasAcciones.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblLAltasAcciones)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(3, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(400, 70)
		Me.pnlEncabezado.TabIndex = 1
		'
		'lblLAltasAcciones
		'
		Me.lblLAltasAcciones.AutoSize = True
		Me.lblLAltasAcciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLAltasAcciones.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblLAltasAcciones.Location = New System.Drawing.Point(265, 45)
		Me.lblLAltasAcciones.Name = "lblLAltasAcciones"
		Me.lblLAltasAcciones.Size = New System.Drawing.Size(133, 20)
		Me.lblLAltasAcciones.TabIndex = 22
		Me.lblLAltasAcciones.Text = " Altas Acciones"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(268, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'cmbTipo
		'
		Me.cmbTipo.FormattingEnabled = True
		Me.cmbTipo.Items.AddRange(New Object() {"Altas", "Consultar", "Editar", "Eliminar", "Otro"})
		Me.cmbTipo.Location = New System.Drawing.Point(174, 87)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(145, 21)
		Me.cmbTipo.TabIndex = 3
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(125, 87)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(35, 13)
		Me.lblTipo.TabIndex = 12
		Me.lblTipo.Text = "* Tipo"
		'
		'lblModulo
		'
		Me.lblModulo.AutoSize = True
		Me.lblModulo.Location = New System.Drawing.Point(111, 51)
		Me.lblModulo.Name = "lblModulo"
		Me.lblModulo.Size = New System.Drawing.Size(49, 13)
		Me.lblModulo.TabIndex = 10
		Me.lblModulo.Text = "* Modulo"
		'
		'txtNombreDeLaAccion
		'
		Me.txtNombreDeLaAccion.Location = New System.Drawing.Point(174, 19)
		Me.txtNombreDeLaAccion.MaxLength = 50
		Me.txtNombreDeLaAccion.Name = "txtNombreDeLaAccion"
		Me.txtNombreDeLaAccion.Size = New System.Drawing.Size(145, 20)
		Me.txtNombreDeLaAccion.TabIndex = 1
		'
		'lblNombreDeLaAccion
		'
		Me.lblNombreDeLaAccion.AutoSize = True
		Me.lblNombreDeLaAccion.Location = New System.Drawing.Point(41, 19)
		Me.lblNombreDeLaAccion.Name = "lblNombreDeLaAccion"
		Me.lblNombreDeLaAccion.Size = New System.Drawing.Size(112, 13)
		Me.lblNombreDeLaAccion.TabIndex = 8
		Me.lblNombreDeLaAccion.Text = "* Nombre de la accion"
		'
		'grbAltasAcciones
		'
		Me.grbAltasAcciones.Controls.Add(Me.lblActivo)
		Me.grbAltasAcciones.Controls.Add(Me.GroupBox1)
		Me.grbAltasAcciones.Controls.Add(Me.lblClave)
		Me.grbAltasAcciones.Controls.Add(Me.txtClave)
		Me.grbAltasAcciones.Controls.Add(Me.cmbModulo)
		Me.grbAltasAcciones.Controls.Add(Me.lblModulo)
		Me.grbAltasAcciones.Controls.Add(Me.cmbTipo)
		Me.grbAltasAcciones.Controls.Add(Me.lblNombreDeLaAccion)
		Me.grbAltasAcciones.Controls.Add(Me.lblTipo)
		Me.grbAltasAcciones.Controls.Add(Me.txtNombreDeLaAccion)
		Me.grbAltasAcciones.Location = New System.Drawing.Point(12, 79)
		Me.grbAltasAcciones.Name = "grbAltasAcciones"
		Me.grbAltasAcciones.Size = New System.Drawing.Size(376, 191)
		Me.grbAltasAcciones.TabIndex = 14
		Me.grbAltasAcciones.TabStop = False
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(123, 158)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 29
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.rdoActivo)
		Me.GroupBox1.Controls.Add(Me.rdoInactivo)
		Me.GroupBox1.Location = New System.Drawing.Point(175, 147)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(144, 34)
		Me.GroupBox1.TabIndex = 30
		Me.GroupBox1.TabStop = False
		'
		'rdoActivo
		'
		Me.rdoActivo.AutoSize = True
		Me.rdoActivo.Checked = True
		Me.rdoActivo.Location = New System.Drawing.Point(6, 12)
		Me.rdoActivo.Name = "rdoActivo"
		Me.rdoActivo.Size = New System.Drawing.Size(36, 17)
		Me.rdoActivo.TabIndex = 8
		Me.rdoActivo.TabStop = True
		Me.rdoActivo.Text = "Sí"
		Me.rdoActivo.UseVisualStyleBackColor = True
		'
		'rdoInactivo
		'
		Me.rdoInactivo.AutoSize = True
		Me.rdoInactivo.Location = New System.Drawing.Point(95, 11)
		Me.rdoInactivo.Name = "rdoInactivo"
		Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
		Me.rdoInactivo.TabIndex = 9
		Me.rdoInactivo.Text = "No"
		Me.rdoInactivo.UseVisualStyleBackColor = True
		'
		'lblClave
		'
		Me.lblClave.AutoSize = True
		Me.lblClave.Location = New System.Drawing.Point(119, 123)
		Me.lblClave.Name = "lblClave"
		Me.lblClave.Size = New System.Drawing.Size(41, 13)
		Me.lblClave.TabIndex = 15
		Me.lblClave.Text = "* Clave"
		'
		'txtClave
		'
		Me.txtClave.Location = New System.Drawing.Point(174, 123)
		Me.txtClave.MaxLength = 50
		Me.txtClave.Name = "txtClave"
		Me.txtClave.Size = New System.Drawing.Size(145, 20)
		Me.txtClave.TabIndex = 14
		'
		'cmbModulo
		'
		Me.cmbModulo.FormattingEnabled = True
		Me.cmbModulo.Location = New System.Drawing.Point(174, 51)
		Me.cmbModulo.Name = "cmbModulo"
		Me.cmbModulo.Size = New System.Drawing.Size(145, 21)
		Me.cmbModulo.TabIndex = 13
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(337, 328)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 26
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(261, 328)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 25
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(267, 290)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 4
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(343, 290)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 5
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'AltasAccionesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(407, 389)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grbAltasAcciones)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasAccionesForm"
		Me.Text = "Altas Acciones"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbAltasAcciones.ResumeLayout(False)
		Me.grbAltasAcciones.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblLAltasAcciones As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents lblModulo As System.Windows.Forms.Label
	Friend WithEvents txtNombreDeLaAccion As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreDeLaAccion As System.Windows.Forms.Label
	Friend WithEvents grbAltasAcciones As System.Windows.Forms.GroupBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
	Friend WithEvents lblClave As System.Windows.Forms.Label
	Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
End Class
