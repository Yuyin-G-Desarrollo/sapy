<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSeleccionarFormaDePagoForm
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
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.btnSolicitar = New System.Windows.Forms.Button()
        Me.lblEnviar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(19, 31)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 0
        Me.lblCaja.Text = "Caja"
        Me.lblCaja.Visible = False
        '
        'cmbCaja
        '
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.Location = New System.Drawing.Point(109, 27)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(191, 21)
        Me.cmbCaja.TabIndex = 1
        Me.cmbCaja.Visible = False
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Location = New System.Drawing.Point(19, 63)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaPago.TabIndex = 2
        Me.lblFormaPago.Text = "Forma de Pago"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"", "EFECTIVO", "CHEQUE"})
        Me.cmbFormaPago.Location = New System.Drawing.Point(109, 59)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(190, 21)
        Me.cmbFormaPago.TabIndex = 3
        '
        'btnSolicitar
        '
        Me.btnSolicitar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnSolicitar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSolicitar.Location = New System.Drawing.Point(261, 99)
        Me.btnSolicitar.Name = "btnSolicitar"
        Me.btnSolicitar.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitar.TabIndex = 9
        Me.btnSolicitar.UseVisualStyleBackColor = True
        '
        'lblEnviar
        '
        Me.lblEnviar.AutoSize = True
        Me.lblEnviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEnviar.Location = New System.Drawing.Point(255, 133)
        Me.lblEnviar.Name = "lblEnviar"
        Me.lblEnviar.Size = New System.Drawing.Size(45, 13)
        Me.lblEnviar.TabIndex = 10
        Me.lblEnviar.Text = "Guardar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEnviar)
        Me.GroupBox1.Controls.Add(Me.cmbFormaPago)
        Me.GroupBox1.Controls.Add(Me.btnSolicitar)
        Me.GroupBox1.Controls.Add(Me.lblCaja)
        Me.GroupBox1.Controls.Add(Me.cmbCaja)
        Me.GroupBox1.Controls.Add(Me.lblFormaPago)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(325, 155)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'DialogSeleccionarFormaDePagoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(349, 171)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(365, 210)
        Me.MinimumSize = New System.Drawing.Size(365, 210)
        Me.Name = "DialogSeleccionarFormaDePagoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Información de Pago del Finiquito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents lblFormaPago As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents btnSolicitar As System.Windows.Forms.Button
    Friend WithEvents lblEnviar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
