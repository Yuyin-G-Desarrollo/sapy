<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlPeriodosNominaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlPeriodosNominaForm))
        Me.grbPeriodos = New System.Windows.Forms.GroupBox()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFEchaFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblControlPeriodos = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.CgrdPeriodos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grbPeriodos.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbPeriodos
        '
        Me.grbPeriodos.Controls.Add(Me.lblBúscar)
        Me.grbPeriodos.Controls.Add(Me.lblLimpiar)
        Me.grbPeriodos.Controls.Add(Me.btnLimpiar)
        Me.grbPeriodos.Controls.Add(Me.btnBuscar)
        Me.grbPeriodos.Controls.Add(Me.btnAbajo)
        Me.grbPeriodos.Controls.Add(Me.btnArriba)
        Me.grbPeriodos.Controls.Add(Me.dtpFinal)
        Me.grbPeriodos.Controls.Add(Me.dtpInicio)
        Me.grbPeriodos.Controls.Add(Me.lblFEchaFinal)
        Me.grbPeriodos.Controls.Add(Me.lblFechaInicio)
        Me.grbPeriodos.Controls.Add(Me.lblNaves)
        Me.grbPeriodos.Controls.Add(Me.cmbNaves)
        Me.grbPeriodos.Location = New System.Drawing.Point(11, 70)
        Me.grbPeriodos.Name = "grbPeriodos"
        Me.grbPeriodos.Size = New System.Drawing.Size(493, 141)
        Me.grbPeriodos.TabIndex = 8
        Me.grbPeriodos.TabStop = False
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(395, 119)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 44
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(445, 119)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 43
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(448, 88)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 42
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(400, 88)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 41
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(460, 14)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 40
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(436, 14)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 39
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'dtpFinal
        '
        Me.dtpFinal.Location = New System.Drawing.Point(98, 112)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(263, 20)
        Me.dtpFinal.TabIndex = 38
        '
        'dtpInicio
        '
        Me.dtpInicio.Location = New System.Drawing.Point(98, 79)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(263, 20)
        Me.dtpInicio.TabIndex = 37
        '
        'lblFEchaFinal
        '
        Me.lblFEchaFinal.AutoSize = True
        Me.lblFEchaFinal.Location = New System.Drawing.Point(24, 113)
        Me.lblFEchaFinal.Name = "lblFEchaFinal"
        Me.lblFEchaFinal.Size = New System.Drawing.Size(62, 13)
        Me.lblFEchaFinal.TabIndex = 36
        Me.lblFEchaFinal.Text = "Fecha Final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(25, 80)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaInicio.TabIndex = 35
        Me.lblFechaInicio.Text = "Fecha Inicial"
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(24, 47)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(33, 13)
        Me.lblNaves.TabIndex = 34
        Me.lblNaves.Text = "Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(98, 45)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(263, 21)
        Me.cmbNaves.TabIndex = 33
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblControlPeriodos)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Location = New System.Drawing.Point(4, 3)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(509, 60)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblControlPeriodos
        '
        Me.lblControlPeriodos.AutoSize = True
        Me.lblControlPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControlPeriodos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblControlPeriodos.Location = New System.Drawing.Point(276, 18)
        Me.lblControlPeriodos.Name = "lblControlPeriodos"
        Me.lblControlPeriodos.Size = New System.Drawing.Size(169, 20)
        Me.lblControlPeriodos.TabIndex = 21
        Me.lblControlPeriodos.Text = "Periodos de Nómina"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(60, 38)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 37
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(60, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 36
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(12, 3)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(13, 38)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 35
        Me.lblAltas.Text = "Altas"
        '
        'CgrdPeriodos
        '
        Me.CgrdPeriodos.BackColor = System.Drawing.Color.Transparent
        Me.CgrdPeriodos.ColumnInfo = resources.GetString("CgrdPeriodos.ColumnInfo")
        Me.CgrdPeriodos.ExtendLastCol = True
        Me.CgrdPeriodos.Location = New System.Drawing.Point(12, 217)
        Me.CgrdPeriodos.Name = "CgrdPeriodos"
        Me.CgrdPeriodos.Rows.Count = 1
        Me.CgrdPeriodos.Rows.DefaultSize = 19
        Me.CgrdPeriodos.Size = New System.Drawing.Size(493, 316)
        Me.CgrdPeriodos.StyleInfo = resources.GetString("CgrdPeriodos.StyleInfo")
        Me.CgrdPeriodos.TabIndex = 9
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(441, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 50
        Me.pcbTitulo.TabStop = False
        '
        'ControlPeriodosNominaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(524, 554)
        Me.Controls.Add(Me.CgrdPeriodos)
        Me.Controls.Add(Me.grbPeriodos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(530, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 576)
        Me.Name = "ControlPeriodosNominaForm"
        Me.Text = "Control Periodos Nomina"
        Me.grbPeriodos.ResumeLayout(False)
        Me.grbPeriodos.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbPeriodos As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
	Friend WithEvents lblFEchaFinal As System.Windows.Forms.Label
	Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents lblControlPeriodos As System.Windows.Forms.Label
    Friend WithEvents CgrdPeriodos As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents pcbTitulo As PictureBox
End Class
