<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasExcepcionesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasExcepcionesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblAltasExcepciones = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmbPerfil = New System.Windows.Forms.ComboBox()
		Me.lblPerfil = New System.Windows.Forms.Label()
		Me.lblDepartamento = New System.Windows.Forms.Label()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.cmbUsuario = New System.Windows.Forms.ComboBox()
		Me.lblUsuario = New System.Windows.Forms.Label()
		Me.lblModulo = New System.Windows.Forms.Label()
		Me.cmbExcepciones = New System.Windows.Forms.ComboBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.rdoDengar = New System.Windows.Forms.RadioButton()
		Me.rdoAutorizar = New System.Windows.Forms.RadioButton()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.lblAccion = New System.Windows.Forms.Label()
		Me.cmbAccion = New System.Windows.Forms.ComboBox()
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
		Me.pnlEncabezado.Controls.Add(Me.lblAltasExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(2, 4)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(474, 67)
		Me.pnlEncabezado.TabIndex = 4
		'
		'lblAltasExcepciones
		'
		Me.lblAltasExcepciones.AutoSize = True
		Me.lblAltasExcepciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAltasExcepciones.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblAltasExcepciones.Location = New System.Drawing.Point(316, 44)
		Me.lblAltasExcepciones.Name = "lblAltasExcepciones"
		Me.lblAltasExcepciones.Size = New System.Drawing.Size(156, 20)
		Me.lblAltasExcepciones.TabIndex = 21
		Me.lblAltasExcepciones.Text = "Altas Excepciones"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(337, 1)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.cmbPerfil)
		Me.GroupBox1.Controls.Add(Me.lblPerfil)
		Me.GroupBox1.Controls.Add(Me.lblDepartamento)
		Me.GroupBox1.Controls.Add(Me.cmbDepartamento)
		Me.GroupBox1.Controls.Add(Me.cmbUsuario)
		Me.GroupBox1.Controls.Add(Me.lblUsuario)
		Me.GroupBox1.Controls.Add(Me.lblModulo)
		Me.GroupBox1.Controls.Add(Me.cmbExcepciones)
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Controls.Add(Me.lblTipo)
		Me.GroupBox1.Controls.Add(Me.lblAccion)
		Me.GroupBox1.Controls.Add(Me.cmbAccion)
		Me.GroupBox1.Location = New System.Drawing.Point(14, 79)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(451, 226)
		Me.GroupBox1.TabIndex = 5
		Me.GroupBox1.TabStop = False
		'
		'cmbPerfil
		'
		Me.cmbPerfil.FormattingEnabled = True
		Me.cmbPerfil.Location = New System.Drawing.Point(170, 120)
		Me.cmbPerfil.Name = "cmbPerfil"
		Me.cmbPerfil.Size = New System.Drawing.Size(176, 21)
		Me.cmbPerfil.TabIndex = 4
		'
		'lblPerfil
		'
		Me.lblPerfil.AutoSize = True
		Me.lblPerfil.Location = New System.Drawing.Point(119, 120)
		Me.lblPerfil.Name = "lblPerfil"
		Me.lblPerfil.Size = New System.Drawing.Size(30, 13)
		Me.lblPerfil.TabIndex = 47
		Me.lblPerfil.Text = "Perfil"
		'
		'lblDepartamento
		'
		Me.lblDepartamento.AutoSize = True
		Me.lblDepartamento.Location = New System.Drawing.Point(76, 86)
		Me.lblDepartamento.Name = "lblDepartamento"
		Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
		Me.lblDepartamento.TabIndex = 45
		Me.lblDepartamento.Text = "Departamento"
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(169, 86)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(176, 21)
		Me.cmbDepartamento.TabIndex = 3
		'
		'cmbUsuario
		'
		Me.cmbUsuario.FormattingEnabled = True
		Me.cmbUsuario.Location = New System.Drawing.Point(171, 149)
		Me.cmbUsuario.Name = "cmbUsuario"
		Me.cmbUsuario.Size = New System.Drawing.Size(176, 21)
		Me.cmbUsuario.TabIndex = 5
		'
		'lblUsuario
		'
		Me.lblUsuario.AutoSize = True
		Me.lblUsuario.Location = New System.Drawing.Point(106, 149)
		Me.lblUsuario.Name = "lblUsuario"
		Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
		Me.lblUsuario.TabIndex = 43
		Me.lblUsuario.Text = "Usuario"
		'
		'lblModulo
		'
		Me.lblModulo.AutoSize = True
		Me.lblModulo.Location = New System.Drawing.Point(107, 27)
		Me.lblModulo.Name = "lblModulo"
		Me.lblModulo.Size = New System.Drawing.Size(42, 13)
		Me.lblModulo.TabIndex = 40
		Me.lblModulo.Text = "Módulo"
		'
		'cmbExcepciones
		'
		Me.cmbExcepciones.FormattingEnabled = True
		Me.cmbExcepciones.Location = New System.Drawing.Point(170, 24)
		Me.cmbExcepciones.Name = "cmbExcepciones"
		Me.cmbExcepciones.Size = New System.Drawing.Size(176, 21)
		Me.cmbExcepciones.TabIndex = 1
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.rdoDengar)
		Me.GroupBox2.Controls.Add(Me.rdoAutorizar)
		Me.GroupBox2.Location = New System.Drawing.Point(169, 176)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(176, 34)
		Me.GroupBox2.TabIndex = 6
		Me.GroupBox2.TabStop = False
		'
		'rdoDengar
		'
		Me.rdoDengar.AutoSize = True
		Me.rdoDengar.Location = New System.Drawing.Point(96, 11)
		Me.rdoDengar.Name = "rdoDengar"
		Me.rdoDengar.Size = New System.Drawing.Size(69, 17)
		Me.rdoDengar.TabIndex = 8
		Me.rdoDengar.Text = " Denegar"
		Me.rdoDengar.UseVisualStyleBackColor = True
		'
		'rdoAutorizar
		'
		Me.rdoAutorizar.AutoSize = True
		Me.rdoAutorizar.Checked = True
		Me.rdoAutorizar.Location = New System.Drawing.Point(6, 11)
		Me.rdoAutorizar.Name = "rdoAutorizar"
		Me.rdoAutorizar.Size = New System.Drawing.Size(66, 17)
		Me.rdoAutorizar.TabIndex = 7
		Me.rdoAutorizar.TabStop = True
		Me.rdoAutorizar.Text = "Autorizar"
		Me.rdoAutorizar.UseVisualStyleBackColor = True
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(121, 187)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 38
		Me.lblTipo.Text = "Tipo"
		'
		'lblAccion
		'
		Me.lblAccion.AutoSize = True
		Me.lblAccion.Location = New System.Drawing.Point(109, 59)
		Me.lblAccion.Name = "lblAccion"
		Me.lblAccion.Size = New System.Drawing.Size(40, 13)
		Me.lblAccion.TabIndex = 34
		Me.lblAccion.Text = "Acción"
		'
		'cmbAccion
		'
		Me.cmbAccion.FormattingEnabled = True
		Me.cmbAccion.Location = New System.Drawing.Point(170, 59)
		Me.cmbAccion.Name = "cmbAccion"
		Me.cmbAccion.Size = New System.Drawing.Size(176, 21)
		Me.cmbAccion.TabIndex = 2
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(407, 365)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 34
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(331, 365)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 33
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(337, 327)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 9
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(413, 327)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 10
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'AltasExcepcionesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(478, 415)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasExcepcionesForm"
		Me.Text = "AltasExcepcionesForm"
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
	Friend WithEvents lblAltasExcepciones As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
	Friend WithEvents lblPerfil As System.Windows.Forms.Label
	Friend WithEvents lblDepartamento As System.Windows.Forms.Label
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents lblModulo As System.Windows.Forms.Label
	Friend WithEvents cmbExcepciones As System.Windows.Forms.ComboBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoDengar As System.Windows.Forms.RadioButton
	Friend WithEvents rdoAutorizar As System.Windows.Forms.RadioButton
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents lblAccion As System.Windows.Forms.Label
	Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
End Class
