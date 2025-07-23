<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarDepartamentosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarDepartamentosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblListaDepartamentos = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.txtNombreDelDepartamento = New System.Windows.Forms.TextBox()
        Me.lblNombreDepartamento = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(384, 60)
        Me.pnlEncabezado.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblListaDepartamentos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(135, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 60)
        Me.Panel1.TabIndex = 38
        '
        'lblListaDepartamentos
        '
        Me.lblListaDepartamentos.AutoSize = True
        Me.lblListaDepartamentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaDepartamentos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaDepartamentos.Location = New System.Drawing.Point(43, 24)
        Me.lblListaDepartamentos.Name = "lblListaDepartamentos"
        Me.lblListaDepartamentos.Size = New System.Drawing.Size(133, 20)
        Me.lblListaDepartamentos.TabIndex = 21
        Me.lblListaDepartamentos.Text = "Departamentos"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.imgLogo.Location = New System.Drawing.Point(314, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 37
        Me.imgLogo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAreas)
        Me.GroupBox1.Controls.Add(Me.cmbAreas)
        Me.GroupBox1.Controls.Add(Me.lblNaves)
        Me.GroupBox1.Controls.Add(Me.cmbNaves)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtNombreDelDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblNombreDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 230)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Location = New System.Drawing.Point(52, 125)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(41, 13)
        Me.lblAreas.TabIndex = 42
        Me.lblAreas.Text = "* Áreas"
        '
        'cmbAreas
        '
        Me.cmbAreas.FormattingEnabled = True
        Me.cmbAreas.Location = New System.Drawing.Point(104, 123)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(178, 21)
        Me.cmbAreas.TabIndex = 41
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(52, 82)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(40, 13)
        Me.lblNaves.TabIndex = 40
        Me.lblNaves.Text = "* Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(104, 80)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(178, 21)
        Me.cmbNaves.TabIndex = 39
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoNo)
        Me.GroupBox2.Controls.Add(Me.rdoSi)
        Me.GroupBox2.Location = New System.Drawing.Point(104, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 37)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(109, 12)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 4
        Me.rdoNo.TabStop = True
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Location = New System.Drawing.Point(18, 12)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 3
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'txtNombreDelDepartamento
        '
        Me.txtNombreDelDepartamento.Location = New System.Drawing.Point(104, 42)
        Me.txtNombreDelDepartamento.Name = "txtNombreDelDepartamento"
        Me.txtNombreDelDepartamento.Size = New System.Drawing.Size(178, 20)
        Me.txtNombreDelDepartamento.TabIndex = 1
        '
        'lblNombreDepartamento
        '
        Me.lblNombreDepartamento.AutoSize = True
        Me.lblNombreDepartamento.Location = New System.Drawing.Point(51, 45)
        Me.lblNombreDepartamento.Name = "lblNombreDepartamento"
        Me.lblNombreDepartamento.Size = New System.Drawing.Size(51, 13)
        Me.lblNombreDepartamento.TabIndex = 7
        Me.lblNombreDepartamento.Text = "* Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(51, 165)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(44, 13)
        Me.lblActivo.TabIndex = 6
        Me.lblActivo.Text = "* Activo"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(322, 382)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 34
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(259, 382)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 33
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(265, 344)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(323, 344)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 6
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'EditarDepartamentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(384, 416)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarDepartamentosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Departamentos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents txtNombreDelDepartamento As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreDepartamento As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents lblAreas As System.Windows.Forms.Label
    Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblListaDepartamentos As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
End Class
