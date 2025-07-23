<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteCoppelForm
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
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dtmFechaFinPrograma = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.dtmFechaInicioPrograma = New System.Windows.Forms.DateTimePicker()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(62, 23)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(217, 20)
        Me.lblEncabezado.TabIndex = 8
        Me.lblEncabezado.Text = "Reporte Etiquetas Coppel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.dtmFechaFinPrograma)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.dtmFechaInicioPrograma)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Controls.Add(Me.lblDepartamento)
        Me.Panel1.Location = New System.Drawing.Point(12, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 226)
        Me.Panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(135, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(138, 169)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 52
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dtmFechaFinPrograma
        '
        Me.dtmFechaFinPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaFinPrograma.Location = New System.Drawing.Point(36, 139)
        Me.dtmFechaFinPrograma.Name = "dtmFechaFinPrograma"
        Me.dtmFechaFinPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaFinPrograma.TabIndex = 51
        Me.dtmFechaFinPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "F. Fin de Programa:"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(36, 28)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(173, 21)
        Me.cmbNave.TabIndex = 48
        '
        'dtmFechaInicioPrograma
        '
        Me.dtmFechaInicioPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicioPrograma.Location = New System.Drawing.Point(36, 83)
        Me.dtmFechaInicioPrograma.Name = "dtmFechaInicioPrograma"
        Me.dtmFechaInicioPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaInicioPrograma.TabIndex = 49
        Me.dtmFechaInicioPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(33, 13)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 46
        Me.lblNave.Text = "Nave:"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(33, 67)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(103, 13)
        Me.lblDepartamento.TabIndex = 47
        Me.lblDepartamento.Text = "Fecha de Programa:"
        '
        'ReporteCoppelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(339, 310)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(355, 349)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(355, 349)
        Me.Name = "ReporteCoppelForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte Coppel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtmFechaFinPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents dtmFechaInicioPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
