<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarAccionesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarAccionesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblLEditarAcciones = New System.Windows.Forms.Label()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.grbAltasAcciones = New System.Windows.Forms.GroupBox()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.rdoActivo = New System.Windows.Forms.RadioButton()
		Me.rdoInactivo = New System.Windows.Forms.RadioButton()
		Me.lblClave = New System.Windows.Forms.Label()
		Me.txtClave = New System.Windows.Forms.TextBox()
		Me.cmbModulo = New System.Windows.Forms.ComboBox()
		Me.lblModulo = New System.Windows.Forms.Label()
		Me.cmbTipo = New System.Windows.Forms.ComboBox()
		Me.lblNombreDeLaAccion = New System.Windows.Forms.Label()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.txtNombreDeLaAccion = New System.Windows.Forms.TextBox()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.pnlEncabezado.SuspendLayout()
		Me.grbAltasAcciones.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblLEditarAcciones)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(3, 4)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(428, 70)
		Me.pnlEncabezado.TabIndex = 2
		'
		'lblLEditarAcciones
		'
		Me.lblLEditarAcciones.AutoSize = True
		Me.lblLEditarAcciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLEditarAcciones.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblLEditarAcciones.Location = New System.Drawing.Point(275, 46)
		Me.lblLEditarAcciones.Name = "lblLEditarAcciones"
		Me.lblLEditarAcciones.Size = New System.Drawing.Size(140, 20)
		Me.lblLEditarAcciones.TabIndex = 22
		Me.lblLEditarAcciones.Text = "Editar Acciones "
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(365, 338)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 30
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(289, 338)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 29
		Me.lblGuardar.Text = "Guardar"
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
		Me.grbAltasAcciones.Location = New System.Drawing.Point(12, 84)
		Me.grbAltasAcciones.Name = "grbAltasAcciones"
		Me.grbAltasAcciones.Size = New System.Drawing.Size(408, 191)
		Me.grbAltasAcciones.TabIndex = 31
		Me.grbAltasAcciones.TabStop = False
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(113, 158)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 29
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.rdoActivo)
		Me.GroupBox1.Controls.Add(Me.rdoInactivo)
		Me.GroupBox1.Location = New System.Drawing.Point(165, 147)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(100, 34)
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
		Me.rdoInactivo.Location = New System.Drawing.Point(56, 11)
		Me.rdoInactivo.Name = "rdoInactivo"
		Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
		Me.rdoInactivo.TabIndex = 9
		Me.rdoInactivo.Text = "No"
		Me.rdoInactivo.UseVisualStyleBackColor = True
		'
		'lblClave
		'
		Me.lblClave.AutoSize = True
		Me.lblClave.Location = New System.Drawing.Point(109, 123)
		Me.lblClave.Name = "lblClave"
		Me.lblClave.Size = New System.Drawing.Size(41, 13)
		Me.lblClave.TabIndex = 15
		Me.lblClave.Text = "* Clave"
		'
		'txtClave
		'
		Me.txtClave.Location = New System.Drawing.Point(164, 123)
		Me.txtClave.MaxLength = 50
		Me.txtClave.Name = "txtClave"
		Me.txtClave.Size = New System.Drawing.Size(100, 20)
		Me.txtClave.TabIndex = 14
		'
		'cmbModulo
		'
		Me.cmbModulo.FormattingEnabled = True
		Me.cmbModulo.Location = New System.Drawing.Point(164, 51)
		Me.cmbModulo.Name = "cmbModulo"
		Me.cmbModulo.Size = New System.Drawing.Size(100, 21)
		Me.cmbModulo.TabIndex = 13
		'
		'lblModulo
		'
		Me.lblModulo.AutoSize = True
		Me.lblModulo.Location = New System.Drawing.Point(101, 51)
		Me.lblModulo.Name = "lblModulo"
		Me.lblModulo.Size = New System.Drawing.Size(49, 13)
		Me.lblModulo.TabIndex = 10
		Me.lblModulo.Text = "* Modulo"
		'
		'cmbTipo
		'
		Me.cmbTipo.FormattingEnabled = True
		Me.cmbTipo.Items.AddRange(New Object() {"Alta", "Consultar", "Editar", "Eliminar", "Otro"})
		Me.cmbTipo.Location = New System.Drawing.Point(164, 87)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(100, 21)
		Me.cmbTipo.TabIndex = 3
		'
		'lblNombreDeLaAccion
		'
		Me.lblNombreDeLaAccion.AutoSize = True
		Me.lblNombreDeLaAccion.Location = New System.Drawing.Point(39, 19)
		Me.lblNombreDeLaAccion.Name = "lblNombreDeLaAccion"
		Me.lblNombreDeLaAccion.Size = New System.Drawing.Size(112, 13)
		Me.lblNombreDeLaAccion.TabIndex = 8
		Me.lblNombreDeLaAccion.Text = "* Nombre de la accion"
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(115, 87)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(35, 13)
		Me.lblTipo.TabIndex = 12
		Me.lblTipo.Text = "* Tipo"
		'
		'txtNombreDeLaAccion
		'
		Me.txtNombreDeLaAccion.Location = New System.Drawing.Point(164, 19)
		Me.txtNombreDeLaAccion.MaxLength = 50
		Me.txtNombreDeLaAccion.Name = "txtNombreDeLaAccion"
		Me.txtNombreDeLaAccion.Size = New System.Drawing.Size(100, 20)
		Me.txtNombreDeLaAccion.TabIndex = 1
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(295, 300)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 4
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(371, 300)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 5
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(287, 4)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'EditarAccionesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(432, 387)
		Me.Controls.Add(Me.grbAltasAcciones)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "EditarAccionesForm"
		Me.Text = "Editar Acciones"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		Me.grbAltasAcciones.ResumeLayout(False)
		Me.grbAltasAcciones.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblLEditarAcciones As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents grbAltasAcciones As System.Windows.Forms.GroupBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
	Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
	Friend WithEvents lblClave As System.Windows.Forms.Label
	Friend WithEvents txtClave As System.Windows.Forms.TextBox
	Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
	Friend WithEvents lblModulo As System.Windows.Forms.Label
	Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents lblNombreDeLaAccion As System.Windows.Forms.Label
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents txtNombreDeLaAccion As System.Windows.Forms.TextBox
End Class
