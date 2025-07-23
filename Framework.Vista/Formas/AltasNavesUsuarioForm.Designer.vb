<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasNavesUsuarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasNavesUsuarioForm))
        Me.grbExcepciones = New System.Windows.Forms.GroupBox()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblLAltasNaves = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grbExcepciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbExcepciones
        '
        Me.grbExcepciones.Controls.Add(Me.cmbUsuario)
        Me.grbExcepciones.Controls.Add(Me.lblNaves)
        Me.grbExcepciones.Controls.Add(Me.cmbNaves)
        Me.grbExcepciones.Controls.Add(Me.lblUsuario)
        Me.grbExcepciones.Location = New System.Drawing.Point(4, 55)
        Me.grbExcepciones.Name = "grbExcepciones"
        Me.grbExcepciones.Size = New System.Drawing.Size(409, 138)
        Me.grbExcepciones.TabIndex = 6
        Me.grbExcepciones.TabStop = False
        '
        'cmbUsuario
        '
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(143, 78)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(176, 21)
        Me.cmbUsuario.TabIndex = 33
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(78, 45)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(38, 13)
        Me.lblNaves.TabIndex = 32
        Me.lblNaves.Text = "Naves"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(143, 42)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(176, 21)
        Me.cmbNaves.TabIndex = 1
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(77, 78)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 2
        Me.lblUsuario.Text = "Usuario"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(365, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 44
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(314, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 43
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(320, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 41
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(371, 3)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 42
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblLAltasNaves)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(419, 48)
        Me.pnlEncabezado.TabIndex = 45
        '
        'lblLAltasNaves
        '
        Me.lblLAltasNaves.AutoSize = True
        Me.lblLAltasNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLAltasNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLAltasNaves.Location = New System.Drawing.Point(183, 16)
        Me.lblLAltasNaves.Name = "lblLAltasNaves"
        Me.lblLAltasNaves.Size = New System.Drawing.Size(171, 20)
        Me.lblLAltasNaves.TabIndex = 22
        Me.lblLAltasNaves.Text = "Altas Naves Usuario"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnCncelar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 208)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(419, 59)
        Me.Panel1.TabIndex = 46
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(351, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'AltasNavesUsuarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(419, 267)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.grbExcepciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltasNavesUsuarioForm"
        Me.Text = "Altas Naves Usuario"
        Me.grbExcepciones.ResumeLayout(False)
        Me.grbExcepciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbExcepciones As System.Windows.Forms.GroupBox
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblLAltasNaves As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
