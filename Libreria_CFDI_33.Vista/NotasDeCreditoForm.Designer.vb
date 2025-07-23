<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotasDeCreditoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasDeCreditoForm))
        Me.bntTimbrar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtNotaCredito = New System.Windows.Forms.TextBox()
        Me.gpoCancelacionNotaCredito = New System.Windows.Forms.GroupBox()
        Me.lblIdNotaCredito = New System.Windows.Forms.Label()
        Me.lblIdNotaCencalada = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConsulta = New System.Windows.Forms.TextBox()
        Me.chkConsulta = New System.Windows.Forms.CheckBox()
        Me.gpoCancelacionNotaCredito.SuspendLayout()
        Me.SuspendLayout()
        '
        'bntTimbrar
        '
        Me.bntTimbrar.Location = New System.Drawing.Point(57, 39)
        Me.bntTimbrar.Name = "bntTimbrar"
        Me.bntTimbrar.Size = New System.Drawing.Size(75, 23)
        Me.bntTimbrar.TabIndex = 0
        Me.bntTimbrar.Text = "Timbrar"
        Me.bntTimbrar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(57, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generar PDF"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(57, 226)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "prueba"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Cancelacion 3.2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(109, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "CancelacionPDF"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(57, 197)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(109, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "ObtenerUUID"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtNotaCredito
        '
        Me.txtNotaCredito.Location = New System.Drawing.Point(6, 119)
        Me.txtNotaCredito.Name = "txtNotaCredito"
        Me.txtNotaCredito.Size = New System.Drawing.Size(130, 20)
        Me.txtNotaCredito.TabIndex = 6
        '
        'gpoCancelacionNotaCredito
        '
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.chkConsulta)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.Label1)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.lblIdNotaCencalada)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.lblIdNotaCredito)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.Button4)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.txtNotaCredito)
        Me.gpoCancelacionNotaCredito.Controls.Add(Me.Button3)
        Me.gpoCancelacionNotaCredito.Location = New System.Drawing.Point(198, 26)
        Me.gpoCancelacionNotaCredito.Name = "gpoCancelacionNotaCredito"
        Me.gpoCancelacionNotaCredito.Size = New System.Drawing.Size(183, 194)
        Me.gpoCancelacionNotaCredito.TabIndex = 7
        Me.gpoCancelacionNotaCredito.TabStop = False
        Me.gpoCancelacionNotaCredito.Text = "CancelacionNotaCredito"
        '
        'lblIdNotaCredito
        '
        Me.lblIdNotaCredito.AutoSize = True
        Me.lblIdNotaCredito.Location = New System.Drawing.Point(12, 103)
        Me.lblIdNotaCredito.Name = "lblIdNotaCredito"
        Me.lblIdNotaCredito.Size = New System.Drawing.Size(124, 13)
        Me.lblIdNotaCredito.TabIndex = 7
        Me.lblIdNotaCredito.Text = "IdNotaCreditoACancelar:"
        '
        'lblIdNotaCencalada
        '
        Me.lblIdNotaCencalada.AutoSize = True
        Me.lblIdNotaCencalada.Location = New System.Drawing.Point(12, 165)
        Me.lblIdNotaCencalada.Name = "lblIdNotaCencalada"
        Me.lblIdNotaCencalada.Size = New System.Drawing.Size(16, 13)
        Me.lblIdNotaCencalada.TabIndex = 8
        Me.lblIdNotaCencalada.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "IdNotaCredCancelada:"
        '
        'txtConsulta
        '
        Me.txtConsulta.Location = New System.Drawing.Point(404, 26)
        Me.txtConsulta.Multiline = True
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConsulta.Size = New System.Drawing.Size(359, 239)
        Me.txtConsulta.TabIndex = 8
        Me.txtConsulta.Text = resources.GetString("txtConsulta.Text")
        '
        'chkConsulta
        '
        Me.chkConsulta.AutoSize = True
        Me.chkConsulta.Location = New System.Drawing.Point(9, 16)
        Me.chkConsulta.Name = "chkConsulta"
        Me.chkConsulta.Size = New System.Drawing.Size(102, 17)
        Me.chkConsulta.TabIndex = 10
        Me.chkConsulta.Text = "MostrarConsulta"
        Me.chkConsulta.UseVisualStyleBackColor = True
        '
        'NotasDeCreditoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 282)
        Me.Controls.Add(Me.txtConsulta)
        Me.Controls.Add(Me.gpoCancelacionNotaCredito)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bntTimbrar)
        Me.Name = "NotasDeCreditoForm"
        Me.Text = "NotasDeCreditoForm"
        Me.gpoCancelacionNotaCredito.ResumeLayout(False)
        Me.gpoCancelacionNotaCredito.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bntTimbrar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtNotaCredito As TextBox
    Friend WithEvents gpoCancelacionNotaCredito As GroupBox
    Friend WithEvents lblIdNotaCredito As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblIdNotaCencalada As Label
    Friend WithEvents chkConsulta As CheckBox
    Friend WithEvents txtConsulta As TextBox
End Class
