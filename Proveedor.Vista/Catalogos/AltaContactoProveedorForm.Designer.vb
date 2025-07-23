<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaContactoProveedorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaContactoProveedorForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ptbxFirma = New System.Windows.Forms.PictureBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ptbxFoto = New System.Windows.Forms.PictureBox()
        Me.cmbTipoContado = New System.Windows.Forms.ComboBox()
        Me.lblFirma = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtAMaterno = New System.Windows.Forms.TextBox()
        Me.txtAPaterno = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblTipoContacto = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblAMaterno = New System.Windows.Forms.Label()
        Me.lblAPaterno = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ofdSubirFoto = New System.Windows.Forms.OpenFileDialog()
        Me.ofdFirma = New System.Windows.Forms.OpenFileDialog()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.ptbxFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(582, 60)
        Me.pnlHeader.TabIndex = 8
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(286, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(91, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(119, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta Contacto"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 436)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(582, 60)
        Me.Panel1.TabIndex = 68
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.Label6)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(336, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(137, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(136, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 13
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.ptbxFirma)
        Me.Panel6.Controls.Add(Me.rdoNo)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.rdoSi)
        Me.Panel6.Controls.Add(Me.txtCargo)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.ptbxFoto)
        Me.Panel6.Controls.Add(Me.cmbTipoContado)
        Me.Panel6.Controls.Add(Me.lblFirma)
        Me.Panel6.Controls.Add(Me.txtTelefono)
        Me.Panel6.Controls.Add(Me.lblTelefono)
        Me.Panel6.Controls.Add(Me.txtemail)
        Me.Panel6.Controls.Add(Me.txtAMaterno)
        Me.Panel6.Controls.Add(Me.txtAPaterno)
        Me.Panel6.Controls.Add(Me.txtNombre)
        Me.Panel6.Controls.Add(Me.lblCargo)
        Me.Panel6.Controls.Add(Me.lblTipoContacto)
        Me.Panel6.Controls.Add(Me.lblEmail)
        Me.Panel6.Controls.Add(Me.lblAMaterno)
        Me.Panel6.Controls.Add(Me.lblAPaterno)
        Me.Panel6.Controls.Add(Me.lblNombre)
        Me.Panel6.Controls.Add(Me.txtProveedor)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 60)
        Me.Panel6.MinimumSize = New System.Drawing.Size(491, 330)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(582, 376)
        Me.Panel6.TabIndex = 73
        '
        'ptbxFirma
        '
        Me.ptbxFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ptbxFirma.Location = New System.Drawing.Point(384, 233)
        Me.ptbxFirma.Name = "ptbxFirma"
        Me.ptbxFirma.Size = New System.Drawing.Size(125, 80)
        Me.ptbxFirma.TabIndex = 58
        Me.ptbxFirma.TabStop = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(470, 24)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 6
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(385, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Activo"
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(432, 24)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 5
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'txtCargo
        '
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.Location = New System.Drawing.Point(119, 246)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(193, 20)
        Me.txtCargo.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(434, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Foto"
        '
        'ptbxFoto
        '
        Me.ptbxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ptbxFoto.Location = New System.Drawing.Point(386, 69)
        Me.ptbxFoto.Name = "ptbxFoto"
        Me.ptbxFoto.Size = New System.Drawing.Size(123, 139)
        Me.ptbxFoto.TabIndex = 55
        Me.ptbxFoto.TabStop = False
        '
        'cmbTipoContado
        '
        Me.cmbTipoContado.FormattingEnabled = True
        Me.cmbTipoContado.Items.AddRange(New Object() {"COBRANZA", "VENTAS", "COBRANZA/VENTAS"})
        Me.cmbTipoContado.Location = New System.Drawing.Point(119, 218)
        Me.cmbTipoContado.Name = "cmbTipoContado"
        Me.cmbTipoContado.Size = New System.Drawing.Size(193, 21)
        Me.cmbTipoContado.TabIndex = 7
        '
        'lblFirma
        '
        Me.lblFirma.AutoSize = True
        Me.lblFirma.Location = New System.Drawing.Point(434, 217)
        Me.lblFirma.Name = "lblFirma"
        Me.lblFirma.Size = New System.Drawing.Size(32, 13)
        Me.lblFirma.TabIndex = 50
        Me.lblFirma.Text = "Firma"
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Location = New System.Drawing.Point(119, 273)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(193, 20)
        Me.txtTelefono.TabIndex = 9
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(58, 278)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(53, 13)
        Me.lblTelefono.TabIndex = 47
        Me.lblTelefono.Text = "*Teléfono"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(119, 188)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(193, 20)
        Me.txtemail.TabIndex = 4
        '
        'txtAMaterno
        '
        Me.txtAMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAMaterno.Location = New System.Drawing.Point(119, 160)
        Me.txtAMaterno.Name = "txtAMaterno"
        Me.txtAMaterno.Size = New System.Drawing.Size(149, 20)
        Me.txtAMaterno.TabIndex = 3
        '
        'txtAPaterno
        '
        Me.txtAPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPaterno.Location = New System.Drawing.Point(119, 132)
        Me.txtAPaterno.Name = "txtAPaterno"
        Me.txtAPaterno.Size = New System.Drawing.Size(149, 20)
        Me.txtAPaterno.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(119, 104)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(149, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(72, 251)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(39, 13)
        Me.lblCargo.TabIndex = 40
        Me.lblCargo.Text = "*Cargo"
        '
        'lblTipoContacto
        '
        Me.lblTipoContacto.AutoSize = True
        Me.lblTipoContacto.Location = New System.Drawing.Point(33, 224)
        Me.lblTipoContacto.Name = "lblTipoContacto"
        Me.lblTipoContacto.Size = New System.Drawing.Size(78, 13)
        Me.lblTipoContacto.TabIndex = 39
        Me.lblTipoContacto.Text = "*Tipo Contacto"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(74, 191)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(39, 13)
        Me.lblEmail.TabIndex = 38
        Me.lblEmail.Text = "*E-mail"
        '
        'lblAMaterno
        '
        Me.lblAMaterno.AutoSize = True
        Me.lblAMaterno.Location = New System.Drawing.Point(23, 166)
        Me.lblAMaterno.Name = "lblAMaterno"
        Me.lblAMaterno.Size = New System.Drawing.Size(90, 13)
        Me.lblAMaterno.TabIndex = 37
        Me.lblAMaterno.Text = "*Apellido Materno"
        '
        'lblAPaterno
        '
        Me.lblAPaterno.AutoSize = True
        Me.lblAPaterno.Location = New System.Drawing.Point(25, 138)
        Me.lblAPaterno.Name = "lblAPaterno"
        Me.lblAPaterno.Size = New System.Drawing.Size(88, 13)
        Me.lblAPaterno.TabIndex = 36
        Me.lblAPaterno.Text = "*Apellido Paterno"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(65, 109)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblNombre.TabIndex = 35
        Me.lblNombre.Text = "*Nombre"
        '
        'txtProveedor
        '
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(119, 23)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(193, 20)
        Me.txtProveedor.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Proveedor"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(228, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'AltaContactoProveedorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 496)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(590, 523)
        Me.MinimumSize = New System.Drawing.Size(590, 523)
        Me.Name = "AltaContactoProveedorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Contacto"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.ptbxFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoContado As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirma As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtAMaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtAPaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents lblTipoContacto As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblAMaterno As System.Windows.Forms.Label
    Friend WithEvents lblAPaterno As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents ofdSubirFoto As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ofdFirma As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ptbxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ptbxFirma As System.Windows.Forms.PictureBox
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
