<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarEmpleadoForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscarEmpleadoForm))
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdBuscarEmpleado = New System.Windows.Forms.DataGridView()
        Me.txtBuscarEmpleado = New System.Windows.Forms.TextBox()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDTrabajador = New System.Windows.Forms.TextBox()
        Me.txtPuesto = New System.Windows.Forms.TextBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTipoSalario = New System.Windows.Forms.TextBox()
        Me.txtIdDepartamento = New System.Windows.Forms.TextBox()
        Me.txtNave = New System.Windows.Forms.TextBox()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdBuscarEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnContinuar
        '
        Me.btnContinuar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.nuevo_32
        Me.btnContinuar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnContinuar.Location = New System.Drawing.Point(805, 19)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(32, 32)
        Me.btnContinuar.TabIndex = 4
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(745, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grdBuscarEmpleado
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBuscarEmpleado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBuscarEmpleado.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdBuscarEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBuscarEmpleado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdBuscarEmpleado.Location = New System.Drawing.Point(9, 141)
        Me.grdBuscarEmpleado.Name = "grdBuscarEmpleado"
        Me.grdBuscarEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdBuscarEmpleado.Size = New System.Drawing.Size(863, 278)
        Me.grdBuscarEmpleado.TabIndex = 33
        '
        'txtBuscarEmpleado
        '
        Me.txtBuscarEmpleado.Location = New System.Drawing.Point(156, 46)
        Me.txtBuscarEmpleado.Name = "txtBuscarEmpleado"
        Me.txtBuscarEmpleado.Size = New System.Drawing.Size(336, 20)
        Me.txtBuscarEmpleado.TabIndex = 2
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(6, 49)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(121, 13)
        Me.lblEmpleado.TabIndex = 31
        Me.lblEmpleado.Text = "Nombre del Colaborador"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(498, 19)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(23, 20)
        Me.txtDepartamento.TabIndex = 37
        '
        'txtIDTrabajador
        '
        Me.txtIDTrabajador.Location = New System.Drawing.Point(566, 17)
        Me.txtIDTrabajador.Name = "txtIDTrabajador"
        Me.txtIDTrabajador.Size = New System.Drawing.Size(23, 20)
        Me.txtIDTrabajador.TabIndex = 38
        '
        'txtPuesto
        '
        Me.txtPuesto.Location = New System.Drawing.Point(527, 19)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(23, 20)
        Me.txtPuesto.TabIndex = 39
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(651, 22)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(168, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Buscar Colaborador"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(894, 59)
        Me.pnlListaPaises.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(787, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Seleccionar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(838, 460)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 49
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(840, 425)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 48
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(6, 19)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 50
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(156, 16)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(336, 21)
        Me.cmbNave.TabIndex = 1
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(742, 52)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 52
        Me.lblBuscar.Text = "Mostrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTipoSalario)
        Me.GroupBox1.Controls.Add(Me.txtIdDepartamento)
        Me.GroupBox1.Controls.Add(Me.txtNave)
        Me.GroupBox1.Controls.Add(Me.txtCelula)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.lblBuscar)
        Me.GroupBox1.Controls.Add(Me.txtIDTrabajador)
        Me.GroupBox1.Controls.Add(Me.txtPuesto)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.btnContinuar)
        Me.GroupBox1.Controls.Add(Me.txtDepartamento)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblEmpleado)
        Me.GroupBox1.Controls.Add(Me.txtBuscarEmpleado)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(863, 77)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'txtTipoSalario
        '
        Me.txtTipoSalario.Location = New System.Drawing.Point(553, 56)
        Me.txtTipoSalario.Name = "txtTipoSalario"
        Me.txtTipoSalario.Size = New System.Drawing.Size(35, 20)
        Me.txtTipoSalario.TabIndex = 56
        Me.txtTipoSalario.Visible = False
        '
        'txtIdDepartamento
        '
        Me.txtIdDepartamento.Location = New System.Drawing.Point(502, 50)
        Me.txtIdDepartamento.Name = "txtIdDepartamento"
        Me.txtIdDepartamento.Size = New System.Drawing.Size(25, 20)
        Me.txtIdDepartamento.TabIndex = 55
        Me.txtIdDepartamento.Visible = False
        '
        'txtNave
        '
        Me.txtNave.Location = New System.Drawing.Point(647, 17)
        Me.txtNave.Name = "txtNave"
        Me.txtNave.Size = New System.Drawing.Size(56, 20)
        Me.txtNave.TabIndex = 54
        Me.txtNave.Visible = False
        '
        'txtCelula
        '
        Me.txtCelula.Location = New System.Drawing.Point(595, 18)
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.Size = New System.Drawing.Size(35, 20)
        Me.txtCelula.TabIndex = 53
        Me.txtCelula.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(826, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 30
        Me.pcbTitulo.TabStop = False
        '
        'BuscarEmpleadoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(894, 491)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.grdBuscarEmpleado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(900, 513)
        Me.MinimumSize = New System.Drawing.Size(900, 513)
        Me.Name = "BuscarEmpleadoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Colaborador"
        CType(Me.grdBuscarEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdBuscarEmpleado As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscarEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents txtPuesto As System.Windows.Forms.TextBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents txtNave As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoSalario As System.Windows.Forms.TextBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
