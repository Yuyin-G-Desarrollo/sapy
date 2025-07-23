<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasPermisosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPermisosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblAltasPermisos = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbPermisos = New System.Windows.Forms.GroupBox()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.lblDepartamento = New System.Windows.Forms.Label()
		Me.cmbPerfil = New System.Windows.Forms.ComboBox()
		Me.lblPerfil = New System.Windows.Forms.Label()
		Me.cmbAccion = New System.Windows.Forms.ComboBox()
		Me.cmbModulo = New System.Windows.Forms.ComboBox()
		Me.lblModulo = New System.Windows.Forms.Label()
		Me.lblAccion = New System.Windows.Forms.Label()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbPermisos.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblAltasPermisos)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(0, 1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(383, 70)
		Me.pnlEncabezado.TabIndex = 3
		'
		'lblAltasPermisos
		'
		Me.lblAltasPermisos.AutoSize = True
		Me.lblAltasPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAltasPermisos.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblAltasPermisos.Location = New System.Drawing.Point(245, 42)
		Me.lblAltasPermisos.Name = "lblAltasPermisos"
		Me.lblAltasPermisos.Size = New System.Drawing.Size(128, 20)
		Me.lblAltasPermisos.TabIndex = 21
		Me.lblAltasPermisos.Text = "Altas Permisos"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(242, 0)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbPermisos
		'
		Me.grbPermisos.Controls.Add(Me.lblNave)
		Me.grbPermisos.Controls.Add(Me.cmbNave)
		Me.grbPermisos.Controls.Add(Me.cmbDepartamento)
		Me.grbPermisos.Controls.Add(Me.lblDepartamento)
		Me.grbPermisos.Controls.Add(Me.cmbPerfil)
		Me.grbPermisos.Controls.Add(Me.lblPerfil)
		Me.grbPermisos.Controls.Add(Me.cmbAccion)
		Me.grbPermisos.Controls.Add(Me.cmbModulo)
		Me.grbPermisos.Controls.Add(Me.lblModulo)
		Me.grbPermisos.Controls.Add(Me.lblAccion)
		Me.grbPermisos.Location = New System.Drawing.Point(16, 77)
		Me.grbPermisos.Name = "grbPermisos"
		Me.grbPermisos.Size = New System.Drawing.Size(363, 205)
		Me.grbPermisos.TabIndex = 10
		Me.grbPermisos.TabStop = False
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(121, 131)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(150, 21)
		Me.cmbDepartamento.TabIndex = 3
		'
		'lblDepartamento
		'
		Me.lblDepartamento.AutoSize = True
		Me.lblDepartamento.Location = New System.Drawing.Point(15, 131)
		Me.lblDepartamento.Name = "lblDepartamento"
		Me.lblDepartamento.Size = New System.Drawing.Size(78, 13)
		Me.lblDepartamento.TabIndex = 20
		Me.lblDepartamento.Text = "*Departamento"
		'
		'cmbPerfil
		'
		Me.cmbPerfil.FormattingEnabled = True
		Me.cmbPerfil.Location = New System.Drawing.Point(121, 167)
		Me.cmbPerfil.Name = "cmbPerfil"
		Me.cmbPerfil.Size = New System.Drawing.Size(150, 21)
		Me.cmbPerfil.TabIndex = 4
		'
		'lblPerfil
		'
		Me.lblPerfil.AutoSize = True
		Me.lblPerfil.Location = New System.Drawing.Point(59, 170)
		Me.lblPerfil.Name = "lblPerfil"
		Me.lblPerfil.Size = New System.Drawing.Size(34, 13)
		Me.lblPerfil.TabIndex = 18
		Me.lblPerfil.Text = "*Perfil"
		'
		'cmbAccion
		'
		Me.cmbAccion.FormattingEnabled = True
		Me.cmbAccion.Location = New System.Drawing.Point(121, 57)
		Me.cmbAccion.Name = "cmbAccion"
		Me.cmbAccion.Size = New System.Drawing.Size(150, 21)
		Me.cmbAccion.TabIndex = 2
		'
		'cmbModulo
		'
		Me.cmbModulo.FormattingEnabled = True
		Me.cmbModulo.Location = New System.Drawing.Point(121, 19)
		Me.cmbModulo.Name = "cmbModulo"
		Me.cmbModulo.Size = New System.Drawing.Size(150, 21)
		Me.cmbModulo.TabIndex = 1
		'
		'lblModulo
		'
		Me.lblModulo.AutoSize = True
		Me.lblModulo.Location = New System.Drawing.Point(47, 19)
		Me.lblModulo.Name = "lblModulo"
		Me.lblModulo.Size = New System.Drawing.Size(46, 13)
		Me.lblModulo.TabIndex = 3
		Me.lblModulo.Text = "*Módulo"
		'
		'lblAccion
		'
		Me.lblAccion.AutoSize = True
		Me.lblAccion.Location = New System.Drawing.Point(49, 60)
		Me.lblAccion.Name = "lblAccion"
		Me.lblAccion.Size = New System.Drawing.Size(44, 13)
		Me.lblAccion.TabIndex = 7
		Me.lblAccion.Text = "*Acción"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(316, 328)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 30
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(240, 328)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 29
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(246, 290)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 5
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(322, 290)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 6
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(60, 99)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(37, 13)
		Me.lblNave.TabIndex = 22
		Me.lblNave.Text = "*Nave"
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(121, 96)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(150, 21)
		Me.cmbNave.TabIndex = 21
		'
		'AltasPermisosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(387, 363)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grbPermisos)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasPermisosForm"
		Me.Text = "Altas Permisos"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbPermisos.ResumeLayout(False)
		Me.grbPermisos.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblAltasPermisos As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbPermisos As System.Windows.Forms.GroupBox
	Friend WithEvents lblModulo As System.Windows.Forms.Label
	Friend WithEvents lblAccion As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
	Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents lblDepartamento As System.Windows.Forms.Label
	Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
	Friend WithEvents lblPerfil As System.Windows.Forms.Label
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
End Class
