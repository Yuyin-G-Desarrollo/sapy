<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaPeriodoCajaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaPeriodoCajaForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbPeriodoCajaAhorro = New System.Windows.Forms.GroupBox()
        Me.dtpFinalReporte = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicialReporte = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblIdPeriodo = New System.Windows.Forms.Label()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicial = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblNombreNave = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblRegresar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbPeriodoCajaAhorro.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(414, 59)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(27, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(387, 59)
        Me.pnlTitulo.TabIndex = 27
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(317, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(86, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(229, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Periodos de Caja de Ahorro"
        '
        'grbPeriodoCajaAhorro
        '
        Me.grbPeriodoCajaAhorro.BackColor = System.Drawing.Color.Transparent
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.dtpFinalReporte)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.dtpInicialReporte)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.Label2)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.Label1)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblNave)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblIdPeriodo)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblConcepto)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.txtConcepto)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblFechaFinal)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.dtpFechaFinal)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblFechaInicial)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.dtpFechaInicial)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblNombreNave)
        Me.grbPeriodoCajaAhorro.Controls.Add(Me.lblPeriodo)
        Me.grbPeriodoCajaAhorro.Location = New System.Drawing.Point(22, 77)
        Me.grbPeriodoCajaAhorro.Name = "grbPeriodoCajaAhorro"
        Me.grbPeriodoCajaAhorro.Size = New System.Drawing.Size(370, 289)
        Me.grbPeriodoCajaAhorro.TabIndex = 1
        Me.grbPeriodoCajaAhorro.TabStop = False
        '
        'dtpFinalReporte
        '
        Me.dtpFinalReporte.Location = New System.Drawing.Point(159, 164)
        Me.dtpFinalReporte.Name = "dtpFinalReporte"
        Me.dtpFinalReporte.Size = New System.Drawing.Size(151, 20)
        Me.dtpFinalReporte.TabIndex = 18
        '
        'dtpInicialReporte
        '
        Me.dtpInicialReporte.Location = New System.Drawing.Point(159, 134)
        Me.dtpInicialReporte.Name = "dtpInicialReporte"
        Me.dtpInicialReporte.Size = New System.Drawing.Size(151, 20)
        Me.dtpInicialReporte.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(30, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha Final Reporte"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(30, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Fecha Inicial Reporte"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblNave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNave.Location = New System.Drawing.Point(30, 37)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(35, 15)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'lblIdPeriodo
        '
        Me.lblIdPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblIdPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdPeriodo.Location = New System.Drawing.Point(34, 56)
        Me.lblIdPeriodo.Name = "lblIdPeriodo"
        Me.lblIdPeriodo.Size = New System.Drawing.Size(59, 15)
        Me.lblIdPeriodo.TabIndex = 1
        Me.lblIdPeriodo.Visible = False
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblConcepto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblConcepto.Location = New System.Drawing.Point(30, 200)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(50, 15)
        Me.lblConcepto.TabIndex = 8
        Me.lblConcepto.Text = "Periodo"
        '
        'txtConcepto
        '
        Me.txtConcepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtConcepto.Location = New System.Drawing.Point(159, 200)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ReadOnly = True
        Me.txtConcepto.Size = New System.Drawing.Size(194, 67)
        Me.txtConcepto.TabIndex = 9
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblFechaFinal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaFinal.Location = New System.Drawing.Point(30, 102)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(107, 15)
        Me.lblFechaFinal.TabIndex = 6
        Me.lblFechaFinal.Text = "Fecha Final Cierre"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Location = New System.Drawing.Point(159, 101)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(152, 20)
        Me.dtpFechaFinal.TabIndex = 7
        '
        'lblFechaInicial
        '
        Me.lblFechaInicial.AutoSize = True
        Me.lblFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblFechaInicial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaInicial.Location = New System.Drawing.Point(30, 67)
        Me.lblFechaInicial.Name = "lblFechaInicial"
        Me.lblFechaInicial.Size = New System.Drawing.Size(112, 15)
        Me.lblFechaInicial.TabIndex = 4
        Me.lblFechaInicial.Text = "Fecha Inicial Cierre"
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Location = New System.Drawing.Point(159, 67)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(152, 20)
        Me.dtpFechaInicial.TabIndex = 5
        '
        'lblNombreNave
        '
        Me.lblNombreNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNombreNave.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreNave.Location = New System.Drawing.Point(159, 37)
        Me.lblNombreNave.Name = "lblNombreNave"
        Me.lblNombreNave.Size = New System.Drawing.Size(197, 20)
        Me.lblNombreNave.TabIndex = 3
        Me.lblNombreNave.Text = "Nave"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodo.Location = New System.Drawing.Point(34, 56)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo:"
        Me.lblPeriodo.Visible = False
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(151, 7)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 2
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(101, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(95, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 5
        Me.lblGuardar.Text = "Guardar"
        '
        'lblRegresar
        '
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRegresar.Location = New System.Drawing.Point(150, 40)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblRegresar.TabIndex = 4
        Me.lblRegresar.Text = "Cerrar"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 398)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(414, 60)
        Me.pnlEstado.TabIndex = 6
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnRegresar)
        Me.pnlAcciones.Controls.Add(Me.lblRegresar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(214, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(200, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(319, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 25
        Me.pcbTitulo.TabStop = False
        '
        'AltaPeriodoCajaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(414, 458)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grbPeriodoCajaAhorro)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(420, 480)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 480)
        Me.Name = "AltaPeriodoCajaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodos de Caja de Ahorro"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbPeriodoCajaAhorro.ResumeLayout(False)
        Me.grbPeriodoCajaAhorro.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents grbPeriodoCajaAhorro As System.Windows.Forms.GroupBox
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNombreNave As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblRegresar As System.Windows.Forms.Label
    Friend WithEvents lblIdPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents dtpFinalReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicialReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
