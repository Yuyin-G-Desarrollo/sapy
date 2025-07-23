<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCelulasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarCelulasForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAltasCelulas = New System.Windows.Forms.Label()
        Me.grbCelulas = New System.Windows.Forms.GroupBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbCelulas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblAltasCelulas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(394, 60)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblAltasCelulas
        '
        Me.lblAltasCelulas.AutoSize = True
        Me.lblAltasCelulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasCelulas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAltasCelulas.Location = New System.Drawing.Point(248, 18)
        Me.lblAltasCelulas.Name = "lblAltasCelulas"
        Me.lblAltasCelulas.Size = New System.Drawing.Size(68, 20)
        Me.lblAltasCelulas.TabIndex = 48
        Me.lblAltasCelulas.Text = "Células"
        '
        'grbCelulas
        '
        Me.grbCelulas.Controls.Add(Me.txtOrden)
        Me.grbCelulas.Controls.Add(Me.lblOrden)
        Me.grbCelulas.Controls.Add(Me.GroupBox2)
        Me.grbCelulas.Controls.Add(Me.lblActivo)
        Me.grbCelulas.Controls.Add(Me.cmbDepartamento)
        Me.grbCelulas.Controls.Add(Me.lblDepartamento)
        Me.grbCelulas.Controls.Add(Me.cmbNave)
        Me.grbCelulas.Controls.Add(Me.lblNave)
        Me.grbCelulas.Controls.Add(Me.lblNombre)
        Me.grbCelulas.Controls.Add(Me.txtnombre)
        Me.grbCelulas.Location = New System.Drawing.Point(11, 76)
        Me.grbCelulas.Name = "grbCelulas"
        Me.grbCelulas.Size = New System.Drawing.Size(361, 244)
        Me.grbCelulas.TabIndex = 8
        Me.grbCelulas.TabStop = False
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(133, 201)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(175, 20)
        Me.txtOrden.TabIndex = 54
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Location = New System.Drawing.Point(53, 201)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 53
        Me.lblOrden.Text = "Orden"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSi)
        Me.GroupBox2.Controls.Add(Me.btnNo)
        Me.GroupBox2.Location = New System.Drawing.Point(133, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(175, 34)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'btnSi
        '
        Me.btnSi.AutoSize = True
        Me.btnSi.Checked = True
        Me.btnSi.Location = New System.Drawing.Point(27, 11)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(34, 17)
        Me.btnSi.TabIndex = 12
        Me.btnSi.TabStop = True
        Me.btnSi.Text = "Si"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(108, 11)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 13
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(47, 159)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(44, 13)
        Me.lblActivo.TabIndex = 31
        Me.lblActivo.Text = "* Activo"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(134, 114)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(175, 21)
        Me.cmbDepartamento.TabIndex = 5
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(47, 117)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(81, 13)
        Me.lblDepartamento.TabIndex = 4
        Me.lblDepartamento.Text = "* Departamento"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(133, 73)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(175, 21)
        Me.cmbNave.TabIndex = 3
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(47, 76)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(40, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "* Nave"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(47, 32)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "* Nombre"
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(134, 29)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(175, 20)
        Me.txtnombre.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(281, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 50
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(286, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 48
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 365)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 63)
        Me.Panel1.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(332, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Cerrar"
        '
        'Button2
        '
        Me.Button2.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.Button2.Location = New System.Drawing.Point(334, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 45
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(326, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 50
        Me.pcbTitulo.TabStop = False
        '
        'EditarCelulasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 428)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbCelulas)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarCelulasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Células"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbCelulas.ResumeLayout(False)
        Me.grbCelulas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents grbCelulas As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents lblDepartamento As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents lblNombre As System.Windows.Forms.Label
	Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblAltasCelulas As System.Windows.Forms.Label
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
