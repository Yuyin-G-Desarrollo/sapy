<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RangoDeFechasConsumosForm
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
        Me.dtpDelDia = New System.Windows.Forms.DateTimePicker()
        Me.dtpAlDia = New System.Windows.Forms.DateTimePicker()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblDelDia = New System.Windows.Forms.Label()
        Me.lblAlDia = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'dtpDelDia
        '
        Me.dtpDelDia.Location = New System.Drawing.Point(80, 42)
        Me.dtpDelDia.Name = "dtpDelDia"
        Me.dtpDelDia.Size = New System.Drawing.Size(200, 20)
        Me.dtpDelDia.TabIndex = 0
        '
        'dtpAlDia
        '
        Me.dtpAlDia.Location = New System.Drawing.Point(80, 88)
        Me.dtpAlDia.Name = "dtpAlDia"
        Me.dtpAlDia.Size = New System.Drawing.Size(200, 20)
        Me.dtpAlDia.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(117, 191)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblDelDia
        '
        Me.lblDelDia.AutoSize = True
        Me.lblDelDia.Location = New System.Drawing.Point(32, 45)
        Me.lblDelDia.Name = "lblDelDia"
        Me.lblDelDia.Size = New System.Drawing.Size(42, 13)
        Me.lblDelDia.TabIndex = 3
        Me.lblDelDia.Text = "Del Dia"
        '
        'lblAlDia
        '
        Me.lblAlDia.AutoSize = True
        Me.lblAlDia.Location = New System.Drawing.Point(32, 92)
        Me.lblAlDia.Name = "lblAlDia"
        Me.lblAlDia.Size = New System.Drawing.Size(35, 13)
        Me.lblAlDia.TabIndex = 4
        Me.lblAlDia.Text = "Al Dia"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(36, 132)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 5
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(80, 132)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(200, 21)
        Me.cmbNave.TabIndex = 6
        '
        'RangoDeFechasConsumosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(313, 246)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.lblNave)
        Me.Controls.Add(Me.lblAlDia)
        Me.Controls.Add(Me.lblDelDia)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dtpAlDia)
        Me.Controls.Add(Me.dtpDelDia)
        Me.Name = "RangoDeFechasConsumosForm"
        Me.Text = "Rango de Fechas Consumos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpDelDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAlDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblDelDia As System.Windows.Forms.Label
    Friend WithEvents lblAlDia As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
End Class
