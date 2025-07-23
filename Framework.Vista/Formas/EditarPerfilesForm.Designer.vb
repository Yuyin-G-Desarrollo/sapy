<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPerfilesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPerfilesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblEditarPerfiles = New System.Windows.Forms.Label()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.grbEditarPerfiles = New System.Windows.Forms.GroupBox()
		Me.lblEstado = New System.Windows.Forms.Label()
		Me.grbEstado = New System.Windows.Forms.GroupBox()
		Me.rdoSi = New System.Windows.Forms.RadioButton()
		Me.rdoNo = New System.Windows.Forms.RadioButton()
		Me.lblNombreDelPerfil = New System.Windows.Forms.Label()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.lblGrupo = New System.Windows.Forms.Label()
		Me.txtNombreDelPerfil = New System.Windows.Forms.TextBox()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbEditarPerfiles.SuspendLayout()
		Me.grbEstado.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblEditarPerfiles)
		Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
		Me.pnlEncabezado.Location = New System.Drawing.Point(4, 4)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(522, 67)
		Me.pnlEncabezado.TabIndex = 3
		'
		'lblEditarPerfiles
		'
		Me.lblEditarPerfiles.AutoSize = True
		Me.lblEditarPerfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEditarPerfiles.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblEditarPerfiles.Location = New System.Drawing.Point(401, 43)
		Me.lblEditarPerfiles.Name = "lblEditarPerfiles"
		Me.lblEditarPerfiles.Size = New System.Drawing.Size(122, 20)
		Me.lblEditarPerfiles.TabIndex = 21
		Me.lblEditarPerfiles.Text = "Editar Perfiles"
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(390, 0)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(129, 59)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'grbEditarPerfiles
		'
		Me.grbEditarPerfiles.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
		Me.grbEditarPerfiles.Controls.Add(Me.lblEstado)
		Me.grbEditarPerfiles.Controls.Add(Me.grbEstado)
		Me.grbEditarPerfiles.Controls.Add(Me.lblNombreDelPerfil)
		Me.grbEditarPerfiles.Controls.Add(Me.cmbDepartamento)
		Me.grbEditarPerfiles.Controls.Add(Me.lblGrupo)
		Me.grbEditarPerfiles.Controls.Add(Me.txtNombreDelPerfil)
		Me.grbEditarPerfiles.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.grbEditarPerfiles.Location = New System.Drawing.Point(15, 82)
		Me.grbEditarPerfiles.Name = "grbEditarPerfiles"
		Me.grbEditarPerfiles.Size = New System.Drawing.Size(497, 136)
		Me.grbEditarPerfiles.TabIndex = 16
		Me.grbEditarPerfiles.TabStop = False
		'
		'lblEstado
		'
		Me.lblEstado.AutoSize = True
		Me.lblEstado.Location = New System.Drawing.Point(16, 80)
		Me.lblEstado.Name = "lblEstado"
		Me.lblEstado.Size = New System.Drawing.Size(40, 13)
		Me.lblEstado.TabIndex = 9
		Me.lblEstado.Text = "Estado"
		'
		'grbEstado
		'
		Me.grbEstado.Controls.Add(Me.rdoSi)
		Me.grbEstado.Controls.Add(Me.rdoNo)
		Me.grbEstado.Location = New System.Drawing.Point(120, 68)
		Me.grbEstado.Name = "grbEstado"
		Me.grbEstado.Size = New System.Drawing.Size(100, 34)
		Me.grbEstado.TabIndex = 3
		Me.grbEstado.TabStop = False
		'
		'rdoSi
		'
		Me.rdoSi.AutoSize = True
		Me.rdoSi.Location = New System.Drawing.Point(6, 13)
		Me.rdoSi.Name = "rdoSi"
		Me.rdoSi.Size = New System.Drawing.Size(36, 17)
		Me.rdoSi.TabIndex = 4
		Me.rdoSi.TabStop = True
		Me.rdoSi.Text = "Sí"
		Me.rdoSi.UseVisualStyleBackColor = True
		'
		'rdoNo
		'
		Me.rdoNo.AutoSize = True
		Me.rdoNo.Location = New System.Drawing.Point(56, 12)
		Me.rdoNo.Name = "rdoNo"
		Me.rdoNo.Size = New System.Drawing.Size(39, 17)
		Me.rdoNo.TabIndex = 5
		Me.rdoNo.TabStop = True
		Me.rdoNo.Text = "No"
		Me.rdoNo.UseVisualStyleBackColor = True
		'
		'lblNombreDelPerfil
		'
		Me.lblNombreDelPerfil.AutoSize = True
		Me.lblNombreDelPerfil.Location = New System.Drawing.Point(7, 31)
		Me.lblNombreDelPerfil.Name = "lblNombreDelPerfil"
		Me.lblNombreDelPerfil.Size = New System.Drawing.Size(93, 13)
		Me.lblNombreDelPerfil.TabIndex = 3
		Me.lblNombreDelPerfil.Text = "* Nombre del perfil"
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(356, 28)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
		Me.cmbDepartamento.TabIndex = 2
		'
		'lblGrupo
		'
		Me.lblGrupo.AutoSize = True
		Me.lblGrupo.Location = New System.Drawing.Point(246, 31)
		Me.lblGrupo.Name = "lblGrupo"
		Me.lblGrupo.Size = New System.Drawing.Size(81, 13)
		Me.lblGrupo.TabIndex = 8
		Me.lblGrupo.Text = "* Departamento"
		'
		'txtNombreDelPerfil
		'
		Me.txtNombreDelPerfil.Location = New System.Drawing.Point(119, 31)
		Me.txtNombreDelPerfil.Name = "txtNombreDelPerfil"
		Me.txtNombreDelPerfil.Size = New System.Drawing.Size(100, 20)
		Me.txtNombreDelPerfil.TabIndex = 1
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(444, 277)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 34
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(368, 277)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 33
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(374, 239)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 6
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(450, 239)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 7
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'EditarPerfilesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(528, 317)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grbEditarPerfiles)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "EditarPerfilesForm"
		Me.Text = "EditarPerfilesForm"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbEditarPerfiles.ResumeLayout(False)
		Me.grbEditarPerfiles.PerformLayout()
		Me.grbEstado.ResumeLayout(False)
		Me.grbEstado.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblEditarPerfiles As System.Windows.Forms.Label
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents grbEditarPerfiles As System.Windows.Forms.GroupBox
	Friend WithEvents lblEstado As System.Windows.Forms.Label
	Friend WithEvents grbEstado As System.Windows.Forms.GroupBox
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents lblNombreDelPerfil As System.Windows.Forms.Label
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents lblGrupo As System.Windows.Forms.Label
	Friend WithEvents txtNombreDelPerfil As System.Windows.Forms.TextBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
End Class
