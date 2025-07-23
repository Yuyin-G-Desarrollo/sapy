<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarIncidencia_Form
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
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDepartamentos = New System.Windows.Forms.ComboBox()
        Me.txtpuesto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.errdepartamento = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.errincidencia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.errdepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errincidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(535, 60)
        Me.pnlCabecera.TabIndex = 7
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(286, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(179, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(19, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(128, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta Incidencia"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(465, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 60)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(535, 276)
        Me.pnlInformacionAlta.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.pnlPie)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 276)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(3, 202)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(529, 71)
        Me.pnlPie.TabIndex = 32
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(412, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(64, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(64, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(10, 48)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(15, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "* Departamento"
        '
        'cmbDepartamentos
        '
        Me.cmbDepartamentos.FormattingEnabled = True
        Me.cmbDepartamentos.Location = New System.Drawing.Point(105, 46)
        Me.cmbDepartamentos.Name = "cmbDepartamentos"
        Me.cmbDepartamentos.Size = New System.Drawing.Size(291, 21)
        Me.cmbDepartamentos.TabIndex = 30
        '
        'txtpuesto
        '
        Me.txtpuesto.Location = New System.Drawing.Point(105, 96)
        Me.txtpuesto.MaxLength = 30
        Me.txtpuesto.Name = "txtpuesto"
        Me.txtpuesto.Size = New System.Drawing.Size(291, 20)
        Me.txtpuesto.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "* Incidencia"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmbDepartamentos)
        Me.GroupBox2.Controls.Add(Me.txtpuesto)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(452, 165)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS DEL REGISTRO"
        '
        'errdepartamento
        '
        Me.errdepartamento.ContainerControl = Me
        '
        'errincidencia
        '
        Me.errincidencia.ContainerControl = Me
        '
        'AgregarIncidencia_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 336)
        Me.Controls.Add(Me.pnlInformacionAlta)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AgregarIncidencia_Form"
        Me.Text = "Alta Incidencia"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.errdepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errincidencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents imgLogo As PictureBox
    Friend WithEvents pnlInformacionAlta As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDepartamentos As ComboBox
    Friend WithEvents txtpuesto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents errdepartamento As ErrorProvider
    Friend WithEvents errincidencia As ErrorProvider
End Class
