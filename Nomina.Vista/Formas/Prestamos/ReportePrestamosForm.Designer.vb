<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportePrestamosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportePrestamosForm))
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.grCajaAhorro = New System.Windows.Forms.GroupBox()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicial = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblRegresar = New System.Windows.Forms.Label()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.grCajaAhorro.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(336, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(125, 55)
        Me.imgLogo.TabIndex = 19
        Me.imgLogo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(294, 58)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(164, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Reporte Prestamos"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(461, 80)
        Me.pnlEncabezado.TabIndex = 1
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImprimir.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblImprimir.Location = New System.Drawing.Point(11, 47)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 21
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.AliceBlue
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources._1377984784_printer
        Me.btnImprimir.Location = New System.Drawing.Point(16, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 20
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'grCajaAhorro
        '
        Me.grCajaAhorro.BackColor = System.Drawing.Color.Transparent
        Me.grCajaAhorro.Controls.Add(Me.lblFechaFinal)
        Me.grCajaAhorro.Controls.Add(Me.dtpFechaFinal)
        Me.grCajaAhorro.Controls.Add(Me.lblFechaInicial)
        Me.grCajaAhorro.Controls.Add(Me.dtpFechaInicial)
        Me.grCajaAhorro.Controls.Add(Me.lblLimpiar)
        Me.grCajaAhorro.Controls.Add(Me.btnLimpiar)
        Me.grCajaAhorro.Controls.Add(Me.cmbNave)
        Me.grCajaAhorro.Controls.Add(Me.Label3)
        Me.grCajaAhorro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grCajaAhorro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grCajaAhorro.Location = New System.Drawing.Point(3, 81)
        Me.grCajaAhorro.Name = "grCajaAhorro"
        Me.grCajaAhorro.Size = New System.Drawing.Size(458, 129)
        Me.grCajaAhorro.TabIndex = 2
        Me.grCajaAhorro.TabStop = False
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblFechaFinal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaFinal.Location = New System.Drawing.Point(25, 89)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(20, 15)
        Me.lblFechaFinal.TabIndex = 37
        Me.lblFechaFinal.Text = "Al:"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Location = New System.Drawing.Point(58, 89)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaFinal.TabIndex = 38
        '
        'lblFechaInicial
        '
        Me.lblFechaInicial.AutoSize = True
        Me.lblFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblFechaInicial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaInicial.Location = New System.Drawing.Point(19, 55)
        Me.lblFechaInicial.Name = "lblFechaInicial"
        Me.lblFechaInicial.Size = New System.Drawing.Size(26, 15)
        Me.lblFechaInicial.TabIndex = 35
        Me.lblFechaInicial.Text = "De:"
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Location = New System.Drawing.Point(58, 54)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(203, 20)
        Me.dtpFechaInicial.TabIndex = 36
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(394, 89)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 15)
        Me.lblLimpiar.TabIndex = 33
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(402, 55)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(58, 16)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(277, 21)
        Me.cmbNave.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label3.Location = New System.Drawing.Point(7, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nave:"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = CType(resources.GetObject("btnRegresar.Image"), System.Drawing.Image)
        Me.btnRegresar.Location = New System.Drawing.Point(411, 225)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 33
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblRegresar
        '
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegresar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegresar.Location = New System.Drawing.Point(402, 260)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(50, 13)
        Me.lblRegresar.TabIndex = 34
        Me.lblRegresar.Text = "Regresar"
        '
        'ReportePrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(461, 284)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.lblRegresar)
        Me.Controls.Add(Me.grCajaAhorro)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReportePrestamosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Prestamos"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grCajaAhorro.ResumeLayout(False)
        Me.grCajaAhorro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents grCajaAhorro As System.Windows.Forms.GroupBox
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblRegresar As System.Windows.Forms.Label
End Class
