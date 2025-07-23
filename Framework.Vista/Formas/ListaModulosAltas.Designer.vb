<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasModulosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasModulosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaModulos = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbSuperior = New System.Windows.Forms.ComboBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.grbActivo = New System.Windows.Forms.GroupBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoN = New System.Windows.Forms.RadioButton()
        Me.txtArchivoDeReporte = New System.Windows.Forms.TextBox()
        Me.lblArchivoDeReporte = New System.Windows.Forms.Label()
        Me.lblIcono = New System.Windows.Forms.Label()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.lblMostarEnMenu = New System.Windows.Forms.Label()
        Me.lblGuardarHistorial = New System.Windows.Forms.Label()
        Me.grbGuardarHistorial = New System.Windows.Forms.GroupBox()
        Me.rdoGuardarHistorial = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.grbMostarEnMenu = New System.Windows.Forms.GroupBox()
        Me.rdoMenu = New System.Windows.Forms.RadioButton()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtNombreDelModulo = New System.Windows.Forms.TextBox()
        Me.lblNombreDelModulo = New System.Windows.Forms.Label()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.lblModuloSuperior = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtIcono = New System.Windows.Forms.TextBox()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grbActivo.SuspendLayout()
        Me.grbGuardarHistorial.SuspendLayout()
        Me.grbMostarEnMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblListaModulos)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Location = New System.Drawing.Point(-3, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(412, 70)
        Me.pnlEncabezado.TabIndex = 0
        '
        'lblListaModulos
        '
        Me.lblListaModulos.AutoSize = True
        Me.lblListaModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaModulos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaModulos.Location = New System.Drawing.Point(263, 45)
        Me.lblListaModulos.Name = "lblListaModulos"
        Me.lblListaModulos.Size = New System.Drawing.Size(145, 20)
        Me.lblListaModulos.TabIndex = 22
        Me.lblListaModulos.Text = "Agregar Módulos"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(280, 3)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 1
        Me.imgLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbSuperior)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Controls.Add(Me.grbActivo)
        Me.GroupBox1.Controls.Add(Me.txtArchivoDeReporte)
        Me.GroupBox1.Controls.Add(Me.lblArchivoDeReporte)
        Me.GroupBox1.Controls.Add(Me.lblIcono)
        Me.GroupBox1.Controls.Add(Me.txtComponente)
        Me.GroupBox1.Controls.Add(Me.lblMostarEnMenu)
        Me.GroupBox1.Controls.Add(Me.lblGuardarHistorial)
        Me.GroupBox1.Controls.Add(Me.grbGuardarHistorial)
        Me.GroupBox1.Controls.Add(Me.grbMostarEnMenu)
        Me.GroupBox1.Controls.Add(Me.lblClave)
        Me.GroupBox1.Controls.Add(Me.txtNombreDelModulo)
        Me.GroupBox1.Controls.Add(Me.lblNombreDelModulo)
        Me.GroupBox1.Controls.Add(Me.lblComponente)
        Me.GroupBox1.Controls.Add(Me.lblModuloSuperior)
        Me.GroupBox1.Controls.Add(Me.txtClave)
        Me.GroupBox1.Controls.Add(Me.txtIcono)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 380)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmbSuperior
        '
        Me.cmbSuperior.FormattingEnabled = True
        Me.cmbSuperior.ItemHeight = 13
        Me.cmbSuperior.Location = New System.Drawing.Point(144, 100)
        Me.cmbSuperior.MaxLength = 50
        Me.cmbSuperior.Name = "cmbSuperior"
        Me.cmbSuperior.Size = New System.Drawing.Size(166, 21)
        Me.cmbSuperior.TabIndex = 3
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(30, 329)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 26
        Me.lblActivo.Text = "Activo"
        '
        'grbActivo
        '
        Me.grbActivo.Controls.Add(Me.rdoActivo)
        Me.grbActivo.Controls.Add(Me.rdoN)
        Me.grbActivo.Location = New System.Drawing.Point(147, 316)
        Me.grbActivo.Name = "grbActivo"
        Me.grbActivo.Size = New System.Drawing.Size(167, 34)
        Me.grbActivo.TabIndex = 13
        Me.grbActivo.TabStop = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(6, 12)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(36, 17)
        Me.rdoActivo.TabIndex = 14
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Sí"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoN
        '
        Me.rdoN.AutoSize = True
        Me.rdoN.Location = New System.Drawing.Point(100, 12)
        Me.rdoN.Name = "rdoN"
        Me.rdoN.Size = New System.Drawing.Size(39, 17)
        Me.rdoN.TabIndex = 15
        Me.rdoN.Text = "No"
        Me.rdoN.UseVisualStyleBackColor = True
        '
        'txtArchivoDeReporte
        '
        Me.txtArchivoDeReporte.Location = New System.Drawing.Point(145, 290)
        Me.txtArchivoDeReporte.MaxLength = 50
        Me.txtArchivoDeReporte.Name = "txtArchivoDeReporte"
        Me.txtArchivoDeReporte.Size = New System.Drawing.Size(166, 20)
        Me.txtArchivoDeReporte.TabIndex = 12
        '
        'lblArchivoDeReporte
        '
        Me.lblArchivoDeReporte.AutoSize = True
        Me.lblArchivoDeReporte.Location = New System.Drawing.Point(30, 290)
        Me.lblArchivoDeReporte.Name = "lblArchivoDeReporte"
        Me.lblArchivoDeReporte.Size = New System.Drawing.Size(94, 13)
        Me.lblArchivoDeReporte.TabIndex = 24
        Me.lblArchivoDeReporte.Text = "Archivo de reporte"
        '
        'lblIcono
        '
        Me.lblIcono.AutoSize = True
        Me.lblIcono.Location = New System.Drawing.Point(30, 254)
        Me.lblIcono.Name = "lblIcono"
        Me.lblIcono.Size = New System.Drawing.Size(34, 13)
        Me.lblIcono.TabIndex = 23
        Me.lblIcono.Text = "Icono"
        '
        'txtComponente
        '
        Me.txtComponente.Location = New System.Drawing.Point(145, 219)
        Me.txtComponente.MaxLength = 50
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(167, 20)
        Me.txtComponente.TabIndex = 10
        '
        'lblMostarEnMenu
        '
        Me.lblMostarEnMenu.AutoSize = True
        Me.lblMostarEnMenu.Location = New System.Drawing.Point(30, 144)
        Me.lblMostarEnMenu.Name = "lblMostarEnMenu"
        Me.lblMostarEnMenu.Size = New System.Drawing.Size(83, 13)
        Me.lblMostarEnMenu.TabIndex = 19
        Me.lblMostarEnMenu.Text = "Mostar en menú"
        '
        'lblGuardarHistorial
        '
        Me.lblGuardarHistorial.AutoSize = True
        Me.lblGuardarHistorial.Location = New System.Drawing.Point(30, 185)
        Me.lblGuardarHistorial.Name = "lblGuardarHistorial"
        Me.lblGuardarHistorial.Size = New System.Drawing.Size(85, 13)
        Me.lblGuardarHistorial.TabIndex = 18
        Me.lblGuardarHistorial.Text = "Guardar Historial"
        '
        'grbGuardarHistorial
        '
        Me.grbGuardarHistorial.Controls.Add(Me.rdoGuardarHistorial)
        Me.grbGuardarHistorial.Controls.Add(Me.rdoInactivo)
        Me.grbGuardarHistorial.Location = New System.Drawing.Point(145, 170)
        Me.grbGuardarHistorial.Name = "grbGuardarHistorial"
        Me.grbGuardarHistorial.Size = New System.Drawing.Size(167, 34)
        Me.grbGuardarHistorial.TabIndex = 7
        Me.grbGuardarHistorial.TabStop = False
        '
        'rdoGuardarHistorial
        '
        Me.rdoGuardarHistorial.AutoSize = True
        Me.rdoGuardarHistorial.Checked = True
        Me.rdoGuardarHistorial.Location = New System.Drawing.Point(6, 12)
        Me.rdoGuardarHistorial.Name = "rdoGuardarHistorial"
        Me.rdoGuardarHistorial.Size = New System.Drawing.Size(36, 17)
        Me.rdoGuardarHistorial.TabIndex = 8
        Me.rdoGuardarHistorial.TabStop = True
        Me.rdoGuardarHistorial.Text = "Sí"
        Me.rdoGuardarHistorial.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(101, 11)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 9
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'grbMostarEnMenu
        '
        Me.grbMostarEnMenu.Controls.Add(Me.rdoMenu)
        Me.grbMostarEnMenu.Controls.Add(Me.rdoNo)
        Me.grbMostarEnMenu.Location = New System.Drawing.Point(144, 130)
        Me.grbMostarEnMenu.Name = "grbMostarEnMenu"
        Me.grbMostarEnMenu.Size = New System.Drawing.Size(166, 34)
        Me.grbMostarEnMenu.TabIndex = 4
        Me.grbMostarEnMenu.TabStop = False
        '
        'rdoMenu
        '
        Me.rdoMenu.AutoSize = True
        Me.rdoMenu.Checked = True
        Me.rdoMenu.Location = New System.Drawing.Point(6, 12)
        Me.rdoMenu.Name = "rdoMenu"
        Me.rdoMenu.Size = New System.Drawing.Size(36, 17)
        Me.rdoMenu.TabIndex = 5
        Me.rdoMenu.TabStop = True
        Me.rdoMenu.Text = "Sí"
        Me.rdoMenu.UseVisualStyleBackColor = True
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(101, 11)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 6
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(30, 62)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(41, 13)
        Me.lblClave.TabIndex = 17
        Me.lblClave.Text = "* Clave"
        '
        'txtNombreDelModulo
        '
        Me.txtNombreDelModulo.Location = New System.Drawing.Point(144, 29)
        Me.txtNombreDelModulo.MaxLength = 50
        Me.txtNombreDelModulo.Name = "txtNombreDelModulo"
        Me.txtNombreDelModulo.Size = New System.Drawing.Size(167, 20)
        Me.txtNombreDelModulo.TabIndex = 1
        '
        'lblNombreDelModulo
        '
        Me.lblNombreDelModulo.AutoSize = True
        Me.lblNombreDelModulo.Location = New System.Drawing.Point(30, 29)
        Me.lblNombreDelModulo.Name = "lblNombreDelModulo"
        Me.lblNombreDelModulo.Size = New System.Drawing.Size(105, 13)
        Me.lblNombreDelModulo.TabIndex = 12
        Me.lblNombreDelModulo.Text = "* Nombre del módulo"
        '
        'lblComponente
        '
        Me.lblComponente.AutoSize = True
        Me.lblComponente.Location = New System.Drawing.Point(30, 219)
        Me.lblComponente.Name = "lblComponente"
        Me.lblComponente.Size = New System.Drawing.Size(67, 13)
        Me.lblComponente.TabIndex = 13
        Me.lblComponente.Text = "Componente"
        '
        'lblModuloSuperior
        '
        Me.lblModuloSuperior.AutoSize = True
        Me.lblModuloSuperior.Location = New System.Drawing.Point(30, 100)
        Me.lblModuloSuperior.Name = "lblModuloSuperior"
        Me.lblModuloSuperior.Size = New System.Drawing.Size(82, 13)
        Me.lblModuloSuperior.TabIndex = 14
        Me.lblModuloSuperior.Text = "Módulo superior"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(144, 62)
        Me.txtClave.MaxLength = 50
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(167, 20)
        Me.txtClave.TabIndex = 2
        '
        'txtIcono
        '
        Me.txtIcono.Location = New System.Drawing.Point(144, 254)
        Me.txtIcono.MaxLength = 50
        Me.txtIcono.Name = "txtIcono"
        Me.txtIcono.Size = New System.Drawing.Size(166, 20)
        Me.txtIcono.TabIndex = 11
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(262, 506)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 21
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(338, 506)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 22
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(268, 468)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.Text = "|"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(344, 468)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 17
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'AltasModulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(410, 543)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltasModulosForm"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbActivo.ResumeLayout(False)
        Me.grbActivo.PerformLayout()
        Me.grbGuardarHistorial.ResumeLayout(False)
        Me.grbGuardarHistorial.PerformLayout()
        Me.grbMostarEnMenu.ResumeLayout(False)
        Me.grbMostarEnMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaModulos As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreDelModulo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreDelModulo As System.Windows.Forms.Label
    Friend WithEvents lblComponente As System.Windows.Forms.Label
    Friend WithEvents lblModuloSuperior As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtIcono As System.Windows.Forms.TextBox
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents grbActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoN As System.Windows.Forms.RadioButton
    Friend WithEvents txtArchivoDeReporte As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivoDeReporte As System.Windows.Forms.Label
    Friend WithEvents lblIcono As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents lblMostarEnMenu As System.Windows.Forms.Label
    Friend WithEvents lblGuardarHistorial As System.Windows.Forms.Label
    Friend WithEvents grbGuardarHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents rdoGuardarHistorial As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents grbMostarEnMenu As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMenu As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents cmbSuperior As System.Windows.Forms.ComboBox
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
End Class
