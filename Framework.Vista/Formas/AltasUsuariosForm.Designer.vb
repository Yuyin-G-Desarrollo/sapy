<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasUsuariosForm
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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.picLogo = New System.Windows.Forms.PictureBox()
		Me.grpAltasUsuario = New System.Windows.Forms.GroupBox()
		Me.rdbInactivo = New System.Windows.Forms.RadioButton()
		Me.rdbActivo = New System.Windows.Forms.RadioButton()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtPassword = New System.Windows.Forms.MaskedTextBox()
		Me.mtxConfirmarPass = New System.Windows.Forms.MaskedTextBox()
		Me.lblConfirmaPass = New System.Windows.Forms.Label()
		Me.lblPass = New System.Windows.Forms.Label()
		Me.txtEmail = New System.Windows.Forms.TextBox()
		Me.lblEmail = New System.Windows.Forms.Label()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lblNombre = New System.Windows.Forms.Label()
		Me.txtUsername = New System.Windows.Forms.TextBox()
		Me.lblUsername = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpAltasUsuario.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.White
		Me.Panel1.Controls.Add(Me.lblTitulo)
		Me.Panel1.Controls.Add(Me.picLogo)
		Me.Panel1.Location = New System.Drawing.Point(-1, 1)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(408, 70)
		Me.Panel1.TabIndex = 1
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblTitulo.Location = New System.Drawing.Point(256, 47)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(140, 20)
		Me.lblTitulo.TabIndex = 3
		Me.lblTitulo.Text = "Agregar Usuario"
        '
        'picLogo
        '
        Me.picLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.yuyin
        Me.picLogo.Location = New System.Drawing.Point(283, 1)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(121, 50)
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'grpAltasUsuario
        '
        Me.grpAltasUsuario.Controls.Add(Me.rdbInactivo)
        Me.grpAltasUsuario.Controls.Add(Me.rdbActivo)
        Me.grpAltasUsuario.Controls.Add(Me.Label3)
        Me.grpAltasUsuario.Controls.Add(Me.txtPassword)
        Me.grpAltasUsuario.Controls.Add(Me.mtxConfirmarPass)
        Me.grpAltasUsuario.Controls.Add(Me.lblConfirmaPass)
        Me.grpAltasUsuario.Controls.Add(Me.lblPass)
        Me.grpAltasUsuario.Controls.Add(Me.txtEmail)
        Me.grpAltasUsuario.Controls.Add(Me.lblEmail)
        Me.grpAltasUsuario.Controls.Add(Me.txtNombre)
        Me.grpAltasUsuario.Controls.Add(Me.lblNombre)
        Me.grpAltasUsuario.Controls.Add(Me.txtUsername)
        Me.grpAltasUsuario.Controls.Add(Me.lblUsername)
        Me.grpAltasUsuario.Location = New System.Drawing.Point(12, 89)
        Me.grpAltasUsuario.Name = "grpAltasUsuario"
        Me.grpAltasUsuario.Size = New System.Drawing.Size(377, 283)
        Me.grpAltasUsuario.TabIndex = 2
        Me.grpAltasUsuario.TabStop = False
        '
        'rdbInactivo
        '
        Me.rdbInactivo.AutoSize = True
        Me.rdbInactivo.Location = New System.Drawing.Point(196, 211)
        Me.rdbInactivo.Name = "rdbInactivo"
        Me.rdbInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdbInactivo.TabIndex = 14
        Me.rdbInactivo.Text = "No"
        Me.rdbInactivo.UseVisualStyleBackColor = True
        '
        'rdbActivo
        '
        Me.rdbActivo.AutoSize = True
        Me.rdbActivo.Checked = True
        Me.rdbActivo.Location = New System.Drawing.Point(156, 211)
        Me.rdbActivo.Name = "rdbActivo"
        Me.rdbActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdbActivo.TabIndex = 13
        Me.rdbActivo.TabStop = True
        Me.rdbActivo.Text = "Si"
        Me.rdbActivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "¿Usuario activo?"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(156, 140)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(170, 20)
        Me.txtPassword.TabIndex = 10
        '
        'mtxConfirmarPass
        '
        Me.mtxConfirmarPass.Location = New System.Drawing.Point(156, 176)
        Me.mtxConfirmarPass.Name = "mtxConfirmarPass"
        Me.mtxConfirmarPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.mtxConfirmarPass.Size = New System.Drawing.Size(170, 20)
        Me.mtxConfirmarPass.TabIndex = 11
        '
        'lblConfirmaPass
        '
        Me.lblConfirmaPass.AutoSize = True
        Me.lblConfirmaPass.Location = New System.Drawing.Point(40, 179)
        Me.lblConfirmaPass.Name = "lblConfirmaPass"
        Me.lblConfirmaPass.Size = New System.Drawing.Size(114, 13)
        Me.lblConfirmaPass.TabIndex = 8
        Me.lblConfirmaPass.Text = "* Confirmar contraseña"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(40, 143)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(68, 13)
        Me.lblPass.TabIndex = 6
        Me.lblPass.Text = "* Contraseña"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(156, 104)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(170, 20)
        Me.txtEmail.TabIndex = 5
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(40, 107)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(100, 13)
        Me.lblEmail.TabIndex = 4
        Me.lblEmail.Text = "* Correo electrónico"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(156, 69)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(170, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(40, 72)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "* Nombre"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(156, 34)
        Me.txtUsername.MaxLength = 15
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(170, 20)
        Me.txtUsername.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(40, 37)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(105, 13)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "* Nombre de Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(308, 432)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(234, 432)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(315, 393)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(36, 36)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(238, 393)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(36, 36)
		Me.btnGuardar.TabIndex = 6
		Me.btnGuardar.UseVisualStyleBackColor = False
		'
		'AltasUsuariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(405, 459)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.grpAltasUsuario)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.btnGuardar)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasUsuariosForm"
		Me.Text = "Agregar Usuario"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpAltasUsuario.ResumeLayout(False)
		Me.grpAltasUsuario.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents grpAltasUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblConfirmaPass As System.Windows.Forms.Label
    Friend WithEvents mtxConfirmarPass As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rdbInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
