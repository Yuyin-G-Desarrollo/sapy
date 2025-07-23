<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasPerfilesUsuarioForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPerfilesUsuarioForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbPeus = New System.Windows.Forms.GroupBox()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.cmbUsuario = New System.Windows.Forms.ComboBox()
		Me.lblUsuario = New System.Windows.Forms.Label()
		Me.cmbPerfil = New System.Windows.Forms.ComboBox()
		Me.lblDepartamento = New System.Windows.Forms.Label()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.lblPerfil = New System.Windows.Forms.Label()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbPeus.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(3, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(483, 67)
		Me.pnlEncabezado.TabIndex = 3
		'
		'lblAltas
		'
		Me.lblAltas.AutoSize = True
		Me.lblAltas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAltas.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblAltas.Location = New System.Drawing.Point(298, 43)
		Me.lblAltas.Name = "lblAltas"
		Me.lblAltas.Size = New System.Drawing.Size(182, 20)
		Me.lblAltas.TabIndex = 21
		Me.lblAltas.Text = "Altas Perfiles Usuario"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(351, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbPeus
		'
		Me.grbPeus.Controls.Add(Me.lblNave)
		Me.grbPeus.Controls.Add(Me.cmbNave)
		Me.grbPeus.Controls.Add(Me.cmbUsuario)
		Me.grbPeus.Controls.Add(Me.lblUsuario)
		Me.grbPeus.Controls.Add(Me.cmbPerfil)
		Me.grbPeus.Controls.Add(Me.lblDepartamento)
		Me.grbPeus.Controls.Add(Me.cmbDepartamento)
		Me.grbPeus.Controls.Add(Me.lblPerfil)
		Me.grbPeus.Location = New System.Drawing.Point(12, 78)
		Me.grbPeus.Name = "grbPeus"
		Me.grbPeus.Size = New System.Drawing.Size(462, 217)
		Me.grbPeus.TabIndex = 4
		Me.grbPeus.TabStop = False
		Me.grbPeus.Text = "Pérfiles"
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(103, 51)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(37, 13)
		Me.lblNave.TabIndex = 36
		Me.lblNave.Text = "*Nave"
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(153, 43)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(176, 21)
		Me.cmbNave.TabIndex = 35
		'
		'cmbUsuario
		'
		Me.cmbUsuario.FormattingEnabled = True
		Me.cmbUsuario.Location = New System.Drawing.Point(153, 166)
		Me.cmbUsuario.Name = "cmbUsuario"
		Me.cmbUsuario.Size = New System.Drawing.Size(176, 21)
		Me.cmbUsuario.TabIndex = 3
		'
		'lblUsuario
		'
		Me.lblUsuario.AutoSize = True
		Me.lblUsuario.Location = New System.Drawing.Point(96, 169)
		Me.lblUsuario.Name = "lblUsuario"
		Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
		Me.lblUsuario.TabIndex = 34
		Me.lblUsuario.Text = "Usuario"
		'
		'cmbPerfil
		'
		Me.cmbPerfil.FormattingEnabled = True
		Me.cmbPerfil.Location = New System.Drawing.Point(153, 128)
		Me.cmbPerfil.Name = "cmbPerfil"
		Me.cmbPerfil.Size = New System.Drawing.Size(176, 21)
		Me.cmbPerfil.TabIndex = 2
		'
		'lblDepartamento
		'
		Me.lblDepartamento.AutoSize = True
		Me.lblDepartamento.Location = New System.Drawing.Point(67, 87)
		Me.lblDepartamento.Name = "lblDepartamento"
		Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
		Me.lblDepartamento.TabIndex = 32
		Me.lblDepartamento.Text = "Departamento"
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(153, 84)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(176, 21)
		Me.cmbDepartamento.TabIndex = 1
		'
		'lblPerfil
		'
		Me.lblPerfil.AutoSize = True
		Me.lblPerfil.Location = New System.Drawing.Point(110, 128)
		Me.lblPerfil.Name = "lblPerfil"
		Me.lblPerfil.Size = New System.Drawing.Size(30, 13)
		Me.lblPerfil.TabIndex = 10
		Me.lblPerfil.Text = "Pérfil"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(415, 360)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 38
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(339, 360)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 37
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(345, 322)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 4
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(421, 322)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 5
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'AltasPerfilesUsuarioForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(487, 402)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grbPeus)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasPerfilesUsuarioForm"
		Me.Text = "AltasPerfilesUsuarioForm"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbPeus.ResumeLayout(False)
		Me.grbPeus.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbPeus As System.Windows.Forms.GroupBox
	Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
	Friend WithEvents lblDepartamento As System.Windows.Forms.Label
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents lblPerfil As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
End Class
