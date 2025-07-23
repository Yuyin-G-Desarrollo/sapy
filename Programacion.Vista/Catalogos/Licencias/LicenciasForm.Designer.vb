<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicenciasForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gpoActivo = New System.Windows.Forms.GroupBox()
        Me.rbtInactivo = New System.Windows.Forms.RadioButton()
        Me.rbtActivo = New System.Windows.Forms.RadioButton()
        Me.txtCodigoSICY = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.ErrorClave = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorLicencia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorCodigoSICY = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpoActivo.SuspendLayout()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorLicencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorCodigoSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(378, 205)
        Me.Panel1.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.gpoActivo)
        Me.GroupBox1.Controls.Add(Me.txtCodigoSICY)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLicencia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtClave)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 169)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Activo:"
        '
        'gpoActivo
        '
        Me.gpoActivo.Controls.Add(Me.rbtInactivo)
        Me.gpoActivo.Controls.Add(Me.rbtActivo)
        Me.gpoActivo.Location = New System.Drawing.Point(119, 104)
        Me.gpoActivo.Name = "gpoActivo"
        Me.gpoActivo.Size = New System.Drawing.Size(149, 46)
        Me.gpoActivo.TabIndex = 6
        Me.gpoActivo.TabStop = False
        '
        'rbtInactivo
        '
        Me.rbtInactivo.AutoSize = True
        Me.rbtInactivo.Location = New System.Drawing.Point(87, 19)
        Me.rbtInactivo.Name = "rbtInactivo"
        Me.rbtInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rbtInactivo.TabIndex = 13
        Me.rbtInactivo.TabStop = True
        Me.rbtInactivo.Text = "No"
        Me.rbtInactivo.UseVisualStyleBackColor = True
        '
        'rbtActivo
        '
        Me.rbtActivo.AutoSize = True
        Me.rbtActivo.Location = New System.Drawing.Point(24, 19)
        Me.rbtActivo.Name = "rbtActivo"
        Me.rbtActivo.Size = New System.Drawing.Size(34, 17)
        Me.rbtActivo.TabIndex = 12
        Me.rbtActivo.TabStop = True
        Me.rbtActivo.Text = "Si"
        Me.rbtActivo.UseVisualStyleBackColor = True
        '
        'txtCodigoSICY
        '
        Me.txtCodigoSICY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSICY.Enabled = False
        Me.txtCodigoSICY.Location = New System.Drawing.Point(119, 78)
        Me.txtCodigoSICY.Name = "txtCodigoSICY"
        Me.txtCodigoSICY.Size = New System.Drawing.Size(69, 20)
        Me.txtCodigoSICY.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Código SICY:"
        '
        'txtLicencia
        '
        Me.txtLicencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicencia.Location = New System.Drawing.Point(119, 52)
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(149, 20)
        Me.txtLicencia.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Licencia:"
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Location = New System.Drawing.Point(119, 26)
        Me.txtClave.MaxLength = 2
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(69, 20)
        Me.txtClave.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Clave Licencia:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(388, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(392, 15)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 9
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.BackColor = System.Drawing.Color.White
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 265)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(378, 62)
        Me.pnlGuardarCancelar.TabIndex = 12
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.Label1)
        Me.pnlBotonera.Controls.Add(Me.btncCerrar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(153, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(225, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(112, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(106, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Guardar"
        '
        'btncCerrar
        '
        Me.btncCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btncCerrar.Location = New System.Drawing.Point(173, 8)
        Me.btncCerrar.Name = "btncCerrar"
        Me.btncCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btncCerrar.TabIndex = 2
        Me.btncCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(172, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(378, 60)
        Me.pnlHeader.TabIndex = 11
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctLogo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(103, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(275, 60)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(76, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(112, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta Licencia"
        '
        'pctLogo
        '
        Me.pctLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctLogo.Location = New System.Drawing.Point(207, 0)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(68, 60)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 0
        Me.pctLogo.TabStop = False
        '
        'ErrorClave
        '
        Me.ErrorClave.ContainerControl = Me
        '
        'ErrorLicencia
        '
        Me.ErrorLicencia.ContainerControl = Me
        '
        'ErrorCodigoSICY
        '
        Me.ErrorCodigoSICY.ContainerControl = Me
        '
        'LicenciasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 327)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LicenciasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Licencias"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpoActivo.ResumeLayout(False)
        Me.gpoActivo.PerformLayout()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorLicencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorCodigoSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pnlGuardarCancelar As Panel
    Friend WithEvents pnlBotonera As Panel
    Friend WithEvents btncCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pctLogo As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents gpoActivo As GroupBox
    Friend WithEvents rbtInactivo As RadioButton
    Friend WithEvents rbtActivo As RadioButton
    Friend WithEvents txtCodigoSICY As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLicencia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtClave As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ErrorClave As ErrorProvider
    Friend WithEvents ErrorLicencia As ErrorProvider
    Friend WithEvents ErrorCodigoSICY As ErrorProvider
End Class
