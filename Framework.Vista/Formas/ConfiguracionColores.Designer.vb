<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreferenciasColores
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreferenciasColores))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblEtiquetas = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.ColorDialog = New System.Windows.Forms.ColorDialog()
		Me.grdColores = New System.Windows.Forms.DataGridView()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.lblBuscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdColores, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblEtiquetas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(3, 2)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(578, 83)
		Me.pnlEncabezado.TabIndex = 0
		'
		'btnAltas
		'
		Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
		Me.btnAltas.Location = New System.Drawing.Point(13, 12)
		Me.btnAltas.Name = "btnAltas"
		Me.btnAltas.Size = New System.Drawing.Size(32, 32)
		Me.btnAltas.TabIndex = 31
		Me.btnAltas.UseVisualStyleBackColor = True
		'
		'lblEtiquetas
		'
		Me.lblEtiquetas.AutoSize = True
		Me.lblEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblEtiquetas.Location = New System.Drawing.Point(10, 47)
		Me.lblEtiquetas.Name = "lblEtiquetas"
		Me.lblEtiquetas.Size = New System.Drawing.Size(46, 13)
		Me.lblEtiquetas.TabIndex = 33
		Me.lblEtiquetas.Text = "Etiqueta"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(445, 2)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Location = New System.Drawing.Point(519, 64)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(35, 13)
		Me.lblTitulo.TabIndex = 0
		Me.lblTitulo.Text = "Título"
		'
		'ColorDialog
		'
		Me.ColorDialog.FullOpen = True
		'
		'grdColores
		'
		Me.grdColores.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdColores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdColores.Location = New System.Drawing.Point(12, 209)
		Me.grdColores.Name = "grdColores"
		Me.grdColores.Size = New System.Drawing.Size(558, 221)
		Me.grdColores.TabIndex = 1
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.lblBuscar)
		Me.GroupBox1.Controls.Add(Me.lblLimpiar)
		Me.GroupBox1.Controls.Add(Me.btnLimpiar)
		Me.GroupBox1.Controls.Add(Me.btnBuscar)
		Me.GroupBox1.Location = New System.Drawing.Point(9, 94)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(564, 107)
		Me.GroupBox1.TabIndex = 2
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Búsqueda"
		'
		'lblBuscar
		'
		Me.lblBuscar.AutoSize = True
		Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBuscar.Location = New System.Drawing.Point(440, 67)
		Me.lblBuscar.Name = "lblBuscar"
		Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBuscar.TabIndex = 53
		Me.lblBuscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(490, 67)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 52
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(493, 33)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 51
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(443, 33)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 50
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(505, 485)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 51
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(429, 485)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 50
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(434, 447)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 48
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(512, 447)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 49
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'PreferenciasColores
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(582, 521)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.grdColores)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.Name = "PreferenciasColores"
		Me.Text = "ConfiguracionColores"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdColores, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
	Friend WithEvents lblTitulo As System.Windows.Forms.Label
	Friend WithEvents grdColores As System.Windows.Forms.DataGridView
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblEtiquetas As System.Windows.Forms.Label
	Friend WithEvents lblBuscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
End Class
