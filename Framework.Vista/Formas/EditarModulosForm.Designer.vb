<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarModulosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarModulosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblLEditarModulos = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.grbEditarModulos = New System.Windows.Forms.GroupBox()
        Me.cmbModulo = New System.Windows.Forms.ComboBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.grbActivo = New System.Windows.Forms.GroupBox()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.txtArchivoDeReporte = New System.Windows.Forms.TextBox()
        Me.lblArchivoDeReporte = New System.Windows.Forms.Label()
        Me.lblIcono = New System.Windows.Forms.Label()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.lblMostarEnMenu = New System.Windows.Forms.Label()
        Me.lblGuardarHistorial = New System.Windows.Forms.Label()
        Me.grbGuardarHistorial = New System.Windows.Forms.GroupBox()
        Me.rdoHistorialSi = New System.Windows.Forms.RadioButton()
        Me.rdoHistorialNo = New System.Windows.Forms.RadioButton()
        Me.grbMostarEnMenu = New System.Windows.Forms.GroupBox()
        Me.rdoMenuSi = New System.Windows.Forms.RadioButton()
        Me.rdoMenuNo = New System.Windows.Forms.RadioButton()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtNombreDelModulo = New System.Windows.Forms.TextBox()
        Me.lblNombreDelModulo = New System.Windows.Forms.Label()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.lblModuloSuperior = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtIcono = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbEditarModulos.SuspendLayout()
        Me.grbActivo.SuspendLayout()
        Me.grbGuardarHistorial.SuspendLayout()
        Me.grbMostarEnMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblLEditarModulos)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Location = New System.Drawing.Point(1, 1)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(412, 70)
        Me.pnlEncabezado.TabIndex = 1
        '
        'lblLEditarModulos
        '
        Me.lblLEditarModulos.AutoSize = True
        Me.lblLEditarModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLEditarModulos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLEditarModulos.Location = New System.Drawing.Point(275, 45)
        Me.lblLEditarModulos.Name = "lblLEditarModulos"
        Me.lblLEditarModulos.Size = New System.Drawing.Size(129, 20)
        Me.lblLEditarModulos.TabIndex = 22
        Me.lblLEditarModulos.Text = "Editar Módulos"
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
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(345, 496)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 26
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(269, 496)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 25
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(275, 458)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(351, 458)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 17
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'grbEditarModulos
        '
        Me.grbEditarModulos.Controls.Add(Me.cmbModulo)
        Me.grbEditarModulos.Controls.Add(Me.lblActivo)
        Me.grbEditarModulos.Controls.Add(Me.grbActivo)
        Me.grbEditarModulos.Controls.Add(Me.txtArchivoDeReporte)
        Me.grbEditarModulos.Controls.Add(Me.lblArchivoDeReporte)
        Me.grbEditarModulos.Controls.Add(Me.lblIcono)
        Me.grbEditarModulos.Controls.Add(Me.txtComponente)
        Me.grbEditarModulos.Controls.Add(Me.lblMostarEnMenu)
        Me.grbEditarModulos.Controls.Add(Me.lblGuardarHistorial)
        Me.grbEditarModulos.Controls.Add(Me.grbGuardarHistorial)
        Me.grbEditarModulos.Controls.Add(Me.grbMostarEnMenu)
        Me.grbEditarModulos.Controls.Add(Me.lblClave)
        Me.grbEditarModulos.Controls.Add(Me.txtNombreDelModulo)
        Me.grbEditarModulos.Controls.Add(Me.lblNombreDelModulo)
        Me.grbEditarModulos.Controls.Add(Me.lblComponente)
        Me.grbEditarModulos.Controls.Add(Me.lblModuloSuperior)
        Me.grbEditarModulos.Controls.Add(Me.txtClave)
        Me.grbEditarModulos.Controls.Add(Me.txtIcono)
        Me.grbEditarModulos.Location = New System.Drawing.Point(2, 72)
        Me.grbEditarModulos.Name = "grbEditarModulos"
        Me.grbEditarModulos.Size = New System.Drawing.Size(409, 380)
        Me.grbEditarModulos.TabIndex = 27
        Me.grbEditarModulos.TabStop = False
        '
        'cmbModulo
        '
        Me.cmbModulo.FormattingEnabled = True
        Me.cmbModulo.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cmbModulo.Location = New System.Drawing.Point(144, 100)
        Me.cmbModulo.MaxLength = 50
        Me.cmbModulo.Name = "cmbModulo"
        Me.cmbModulo.Size = New System.Drawing.Size(166, 21)
        Me.cmbModulo.TabIndex = 3
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
        Me.grbActivo.Controls.Add(Me.rdoActivoSi)
        Me.grbActivo.Controls.Add(Me.rdoActivoNo)
        Me.grbActivo.Location = New System.Drawing.Point(147, 316)
        Me.grbActivo.Name = "grbActivo"
        Me.grbActivo.Size = New System.Drawing.Size(167, 34)
        Me.grbActivo.TabIndex = 13
        Me.grbActivo.TabStop = False
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(6, 12)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(36, 17)
        Me.rdoActivoSi.TabIndex = 14
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Sí"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(100, 11)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 15
        Me.rdoActivoNo.TabStop = True
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
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
        Me.grbGuardarHistorial.Controls.Add(Me.rdoHistorialSi)
        Me.grbGuardarHistorial.Controls.Add(Me.rdoHistorialNo)
        Me.grbGuardarHistorial.Location = New System.Drawing.Point(145, 170)
        Me.grbGuardarHistorial.Name = "grbGuardarHistorial"
        Me.grbGuardarHistorial.Size = New System.Drawing.Size(167, 34)
        Me.grbGuardarHistorial.TabIndex = 7
        Me.grbGuardarHistorial.TabStop = False
        '
        'rdoHistorialSi
        '
        Me.rdoHistorialSi.AutoSize = True
        Me.rdoHistorialSi.Location = New System.Drawing.Point(6, 12)
        Me.rdoHistorialSi.Name = "rdoHistorialSi"
        Me.rdoHistorialSi.Size = New System.Drawing.Size(36, 17)
        Me.rdoHistorialSi.TabIndex = 8
        Me.rdoHistorialSi.TabStop = True
        Me.rdoHistorialSi.Text = "Sí"
        Me.rdoHistorialSi.UseVisualStyleBackColor = True
        '
        'rdoHistorialNo
        '
        Me.rdoHistorialNo.AutoSize = True
        Me.rdoHistorialNo.Location = New System.Drawing.Point(101, 12)
        Me.rdoHistorialNo.Name = "rdoHistorialNo"
        Me.rdoHistorialNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoHistorialNo.TabIndex = 9
        Me.rdoHistorialNo.TabStop = True
        Me.rdoHistorialNo.Text = "No"
        Me.rdoHistorialNo.UseVisualStyleBackColor = True
        '
        'grbMostarEnMenu
        '
        Me.grbMostarEnMenu.Controls.Add(Me.rdoMenuSi)
        Me.grbMostarEnMenu.Controls.Add(Me.rdoMenuNo)
        Me.grbMostarEnMenu.Location = New System.Drawing.Point(144, 130)
        Me.grbMostarEnMenu.Name = "grbMostarEnMenu"
        Me.grbMostarEnMenu.Size = New System.Drawing.Size(167, 34)
        Me.grbMostarEnMenu.TabIndex = 4
        Me.grbMostarEnMenu.TabStop = False
        '
        'rdoMenuSi
        '
        Me.rdoMenuSi.AutoSize = True
        Me.rdoMenuSi.Location = New System.Drawing.Point(6, 12)
        Me.rdoMenuSi.Name = "rdoMenuSi"
        Me.rdoMenuSi.Size = New System.Drawing.Size(36, 17)
        Me.rdoMenuSi.TabIndex = 5
        Me.rdoMenuSi.TabStop = True
        Me.rdoMenuSi.Text = "Sí"
        Me.rdoMenuSi.UseVisualStyleBackColor = True
        '
        'rdoMenuNo
        '
        Me.rdoMenuNo.AutoSize = True
        Me.rdoMenuNo.Location = New System.Drawing.Point(101, 12)
        Me.rdoMenuNo.Name = "rdoMenuNo"
        Me.rdoMenuNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoMenuNo.TabIndex = 6
        Me.rdoMenuNo.TabStop = True
        Me.rdoMenuNo.Text = "No"
        Me.rdoMenuNo.UseVisualStyleBackColor = True
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
        Me.txtNombreDelModulo.Location = New System.Drawing.Point(143, 29)
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
        'EditarModulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(413, 525)
        Me.Controls.Add(Me.grbEditarModulos)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarModulosForm"
        Me.Text = "EditarModulosForm"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbEditarModulos.ResumeLayout(False)
        Me.grbEditarModulos.PerformLayout()
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
    Friend WithEvents lblLEditarModulos As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents grbEditarModulos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents grbActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtArchivoDeReporte As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivoDeReporte As System.Windows.Forms.Label
    Friend WithEvents lblIcono As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents lblMostarEnMenu As System.Windows.Forms.Label
    Friend WithEvents lblGuardarHistorial As System.Windows.Forms.Label
    Friend WithEvents grbGuardarHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents rdoHistorialSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHistorialNo As System.Windows.Forms.RadioButton
    Friend WithEvents grbMostarEnMenu As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMenuSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMenuNo As System.Windows.Forms.RadioButton
	Friend WithEvents lblClave As System.Windows.Forms.Label
	Friend WithEvents txtNombreDelModulo As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreDelModulo As System.Windows.Forms.Label
	Friend WithEvents lblComponente As System.Windows.Forms.Label
	Friend WithEvents lblModuloSuperior As System.Windows.Forms.Label
	Friend WithEvents txtClave As System.Windows.Forms.TextBox
	Friend WithEvents txtIcono As System.Windows.Forms.TextBox
End Class
