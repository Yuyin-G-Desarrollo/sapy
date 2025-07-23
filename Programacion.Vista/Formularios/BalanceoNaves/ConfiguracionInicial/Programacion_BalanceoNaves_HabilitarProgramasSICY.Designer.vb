<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_BalanceoNaves_HabilitarProgramasSICY
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.nudSemanaFinal = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudAñoFin = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAñoFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.btnGuardar)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.btnCerrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(375, 59)
        Me.Panel5.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(281, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Guardar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(287, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 95
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(330, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Cerrar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(331, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 93
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 114)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(375, 59)
        Me.Panel3.TabIndex = 5
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.nudSemanaFinal)
        Me.pnlFiltros.Controls.Add(Me.nudSemanaInicio)
        Me.pnlFiltros.Controls.Add(Me.Label3)
        Me.pnlFiltros.Controls.Add(Me.nudAñoFin)
        Me.pnlFiltros.Controls.Add(Me.Label18)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(375, 173)
        Me.pnlFiltros.TabIndex = 4
        '
        'nudSemanaFinal
        '
        Me.nudSemanaFinal.Location = New System.Drawing.Point(193, 51)
        Me.nudSemanaFinal.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaFinal.Name = "nudSemanaFinal"
        Me.nudSemanaFinal.Size = New System.Drawing.Size(64, 20)
        Me.nudSemanaFinal.TabIndex = 77
        Me.nudSemanaFinal.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(91, 51)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(64, 20)
        Me.nudSemanaInicio.TabIndex = 76
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Semana de:"
        '
        'nudAñoFin
        '
        Me.nudAñoFin.Location = New System.Drawing.Point(265, 51)
        Me.nudAñoFin.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAñoFin.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.nudAñoFin.Name = "nudAñoFin"
        Me.nudAñoFin.Size = New System.Drawing.Size(64, 20)
        Me.nudAñoFin.TabIndex = 73
        Me.nudAñoFin.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(162, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 13)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "a:"
        '
        'Programacion_BalanceoNaves_HabilitarProgramasSICY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 173)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Programacion_BalanceoNaves_HabilitarProgramasSICY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habilitar Programas SICY"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAñoFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents nudSemanaFinal As NumericUpDown
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents nudAñoFin As NumericUpDown
    Friend WithEvents Label18 As Label
End Class
