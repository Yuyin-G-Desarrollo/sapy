<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarMarcaForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.txtCodigoSicy = New System.Windows.Forms.TextBox()
        Me.lblCodigoSicy = New System.Windows.Forms.Label()
        Me.ckbCliente = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCEDIS = New System.Windows.Forms.ComboBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(384, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pctLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(217, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(167, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pctLogo
        '
        Me.pctLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctLogo.Location = New System.Drawing.Point(99, 0)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(68, 60)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 0
        Me.pctLogo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(29, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(67, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Marcas"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(146, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(78, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(146, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(84, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(124, 70)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(177, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(39, 73)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "* Descripción"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(69, 42)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 3
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(124, 35)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(124, 201)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 5
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(169, 201)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 6
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 350)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(384, 61)
        Me.pnlGuardarCancelar.TabIndex = 7
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(184, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 61)
        Me.pnlBotonera.TabIndex = 4
        '
        'txtCodigoSicy
        '
        Me.txtCodigoSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSicy.Enabled = False
        Me.txtCodigoSicy.Location = New System.Drawing.Point(124, 105)
        Me.txtCodigoSicy.Name = "txtCodigoSicy"
        Me.txtCodigoSicy.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoSicy.TabIndex = 8
        '
        'lblCodigoSicy
        '
        Me.lblCodigoSicy.AutoSize = True
        Me.lblCodigoSicy.Location = New System.Drawing.Point(46, 108)
        Me.lblCodigoSicy.Name = "lblCodigoSicy"
        Me.lblCodigoSicy.Size = New System.Drawing.Size(67, 13)
        Me.lblCodigoSicy.TabIndex = 9
        Me.lblCodigoSicy.Text = "Código SICY"
        '
        'ckbCliente
        '
        Me.ckbCliente.AutoSize = True
        Me.ckbCliente.Location = New System.Drawing.Point(124, 169)
        Me.ckbCliente.Name = "ckbCliente"
        Me.ckbCliente.Size = New System.Drawing.Size(35, 17)
        Me.ckbCliente.TabIndex = 10
        Me.ckbCliente.Text = "Si"
        Me.ckbCliente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Activo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "¿Es cliente?"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCEDIS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ckbCliente)
        Me.GroupBox1.Controls.Add(Me.lblCodigoSicy)
        Me.GroupBox1.Controls.Add(Me.txtCodigoSicy)
        Me.GroupBox1.Controls.Add(Me.rdoInactivo)
        Me.GroupBox1.Controls.Add(Me.rdoActivo)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 240)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(70, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "CEDIS"
        '
        'cmbCEDIS
        '
        Me.cmbCEDIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEDIS.FormattingEnabled = True
        Me.cmbCEDIS.Location = New System.Drawing.Point(124, 136)
        Me.cmbCEDIS.Name = "cmbCEDIS"
        Me.cmbCEDIS.Size = New System.Drawing.Size(175, 21)
        Me.cmbCEDIS.TabIndex = 146
        '
        'EditarMarcaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(384, 411)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarMarcaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents txtCodigoSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoSicy As System.Windows.Forms.Label
    Friend WithEvents ckbCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCEDIS As ComboBox
End Class
