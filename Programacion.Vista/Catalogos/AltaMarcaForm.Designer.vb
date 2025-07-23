<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaMarcaForm
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
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCodigoSicy = New System.Windows.Forms.Label()
        Me.txtCodigoSicy = New System.Windows.Forms.TextBox()
        Me.ckbCliente = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCEDIS = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(73, 42)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(43, 73)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "* Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(124, 70)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(177, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(124, 35)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(384, 60)
        Me.pnlHeader.TabIndex = 5
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label3)
        Me.pnlTitulo.Controls.Add(Me.pctLogo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(184, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(200, 60)
        Me.pnlTitulo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(62, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Marcas"
        '
        'pctLogo
        '
        Me.pctLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctLogo.Location = New System.Drawing.Point(132, 0)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(68, 60)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 0
        Me.pctLogo.TabStop = False
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
        Me.lblGuardar.Location = New System.Drawing.Point(78, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(124, 207)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 6
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(169, 207)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 7
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.BackColor = System.Drawing.Color.White
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 349)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(384, 62)
        Me.pnlGuardarCancelar.TabIndex = 8
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(184, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
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
        Me.btnGuardar.Location = New System.Drawing.Point(84, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCodigoSicy
        '
        Me.lblCodigoSicy.AutoSize = True
        Me.lblCodigoSicy.Location = New System.Drawing.Point(46, 108)
        Me.lblCodigoSicy.Name = "lblCodigoSicy"
        Me.lblCodigoSicy.Size = New System.Drawing.Size(67, 13)
        Me.lblCodigoSicy.TabIndex = 9
        Me.lblCodigoSicy.Text = "Codigo SICY"
        '
        'txtCodigoSicy
        '
        Me.txtCodigoSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSicy.Enabled = False
        Me.txtCodigoSicy.Location = New System.Drawing.Point(124, 105)
        Me.txtCodigoSicy.Name = "txtCodigoSicy"
        Me.txtCodigoSicy.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoSicy.TabIndex = 10
        '
        'ckbCliente
        '
        Me.ckbCliente.AutoSize = True
        Me.ckbCliente.Location = New System.Drawing.Point(124, 175)
        Me.ckbCliente.Name = "ckbCliente"
        Me.ckbCliente.Size = New System.Drawing.Size(35, 17)
        Me.ckbCliente.TabIndex = 11
        Me.ckbCliente.Text = "Si"
        Me.ckbCliente.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "¿Es cliente?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Activo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCEDIS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ckbCliente)
        Me.GroupBox1.Controls.Add(Me.txtCodigoSicy)
        Me.GroupBox1.Controls.Add(Me.lblCodigoSicy)
        Me.GroupBox1.Controls.Add(Me.rdoInactivo)
        Me.GroupBox1.Controls.Add(Me.rdoActivo)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 240)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbCEDIS
        '
        Me.cmbCEDIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEDIS.FormattingEnabled = True
        Me.cmbCEDIS.Location = New System.Drawing.Point(124, 137)
        Me.cmbCEDIS.Name = "cmbCEDIS"
        Me.cmbCEDIS.Size = New System.Drawing.Size(175, 21)
        Me.cmbCEDIS.TabIndex = 144
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "CEDIS"
        '
        'AltaMarcaForm
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
        Me.Name = "AltaMarcaForm"
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
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents lblCodigoSicy As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSicy As System.Windows.Forms.TextBox
    Friend WithEvents ckbCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCEDIS As ComboBox
End Class
