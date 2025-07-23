<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPuestosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPuestosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEditarPuestos = New System.Windows.Forms.Label()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblNombreDelPuesto = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtNombreDelPuesto = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblEditarPuestos)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(394, 54)
        Me.pnlEncabezado.TabIndex = 4
        '
        'lblEditarPuestos
        '
        Me.lblEditarPuestos.AutoSize = True
        Me.lblEditarPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEditarPuestos.Location = New System.Drawing.Point(239, 17)
        Me.lblEditarPuestos.Name = "lblEditarPuestos"
        Me.lblEditarPuestos.Size = New System.Drawing.Size(74, 20)
        Me.lblEditarPuestos.TabIndex = 21
        Me.lblEditarPuestos.Text = "Puestos"
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 366)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(394, 62)
        Me.pnlGuardarCancelar.TabIndex = 45
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnCncelar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(194, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(84, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 43
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(146, 9)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 44
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(146, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 40
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(78, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 39
        Me.lblGuardar.Text = "Guardar"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(15, 235)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(149, 233)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 36
        Me.btnNo.TabStop = True
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Location = New System.Drawing.Point(95, 233)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 35
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtOrden)
        Me.GroupBox1.Controls.Add(Me.lblOrden)
        Me.GroupBox1.Controls.Add(Me.lblAreas)
        Me.GroupBox1.Controls.Add(Me.cmbAreas)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Controls.Add(Me.cmbDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblNombreDelPuesto)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.txtNombreDelPuesto)
        Me.GroupBox1.Controls.Add(Me.rdoSi)
        Me.GroupBox1.Controls.Add(Me.btnNo)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 266)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(95, 204)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(229, 20)
        Me.txtOrden.TabIndex = 57
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Location = New System.Drawing.Point(16, 207)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 56
        Me.lblOrden.Text = "Orden"
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Location = New System.Drawing.Point(16, 140)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(29, 13)
        Me.lblAreas.TabIndex = 55
        Me.lblAreas.Text = "Área"
        '
        'cmbAreas
        '
        Me.cmbAreas.FormattingEnabled = True
        Me.cmbAreas.Location = New System.Drawing.Point(96, 137)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(229, 21)
        Me.cmbAreas.TabIndex = 54
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 173)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(78, 13)
        Me.lblDepartamento.TabIndex = 53
        Me.lblDepartamento.Text = "*Departamento"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(96, 170)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(229, 21)
        Me.cmbDepartamento.TabIndex = 52
        '
        'lblNombreDelPuesto
        '
        Me.lblNombreDelPuesto.AutoSize = True
        Me.lblNombreDelPuesto.Location = New System.Drawing.Point(16, 25)
        Me.lblNombreDelPuesto.Name = "lblNombreDelPuesto"
        Me.lblNombreDelPuesto.Size = New System.Drawing.Size(48, 13)
        Me.lblNombreDelPuesto.TabIndex = 51
        Me.lblNombreDelPuesto.Text = "*Nombre"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(16, 107)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 50
        Me.lblNave.Text = "*Nave"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(96, 104)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(229, 21)
        Me.cmbNave.TabIndex = 49
        '
        'txtNombreDelPuesto
        '
        Me.txtNombreDelPuesto.Location = New System.Drawing.Point(95, 25)
        Me.txtNombreDelPuesto.MaxLength = 50
        Me.txtNombreDelPuesto.Multiline = True
        Me.txtNombreDelPuesto.Name = "txtNombreDelPuesto"
        Me.txtNombreDelPuesto.Size = New System.Drawing.Size(229, 67)
        Me.txtNombreDelPuesto.TabIndex = 48
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(326, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'EditarPuestosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 428)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarPuestosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Puestos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEditarPuestos As System.Windows.Forms.Label
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAreas As System.Windows.Forms.Label
    Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreDelPuesto As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreDelPuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
