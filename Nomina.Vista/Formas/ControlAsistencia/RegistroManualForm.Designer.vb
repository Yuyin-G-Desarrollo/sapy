<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroManualForm
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
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.dtpRegistroManual = New System.Windows.Forms.DateTimePicker()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grboxResultado = New System.Windows.Forms.GroupBox()
        Me.rbtnNoRegistro = New System.Windows.Forms.RadioButton()
        Me.rbtnRetardoMayor = New System.Windows.Forms.RadioButton()
        Me.rbtnRetardoMenor = New System.Windows.Forms.RadioButton()
        Me.rbtnNormal = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnComida = New System.Windows.Forms.RadioButton()
        Me.grboxResultado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Location = New System.Drawing.Point(12, 18)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(30, 13)
        Me.lblHora.TabIndex = 0
        Me.lblHora.Text = "Hora"
        '
        'lblNota
        '
        Me.lblNota.AutoSize = True
        Me.lblNota.Location = New System.Drawing.Point(12, 45)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(30, 13)
        Me.lblNota.TabIndex = 2
        Me.lblNota.Text = "Nota"
        '
        'txtNota
        '
        Me.txtNota.AcceptsReturn = True
        Me.txtNota.Location = New System.Drawing.Point(75, 45)
        Me.txtNota.MaxLength = 50
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(162, 87)
        Me.txtNota.TabIndex = 3
        '
        'dtpRegistroManual
        '
        Me.dtpRegistroManual.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpRegistroManual.Location = New System.Drawing.Point(75, 13)
        Me.dtpRegistroManual.Name = "dtpRegistroManual"
        Me.dtpRegistroManual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpRegistroManual.ShowUpDown = True
        Me.dtpRegistroManual.Size = New System.Drawing.Size(162, 20)
        Me.dtpRegistroManual.TabIndex = 1
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblGuardar.Location = New System.Drawing.Point(270, 34)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 25
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar_32
        Me.btnGuardar.Location = New System.Drawing.Point(276, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCancelar.Location = New System.Drawing.Point(321, 34)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 27
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(322, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grboxResultado
        '
        Me.grboxResultado.Controls.Add(Me.rbtnComida)
        Me.grboxResultado.Controls.Add(Me.rbtnNoRegistro)
        Me.grboxResultado.Controls.Add(Me.rbtnRetardoMayor)
        Me.grboxResultado.Controls.Add(Me.rbtnRetardoMenor)
        Me.grboxResultado.Controls.Add(Me.rbtnNormal)
        Me.grboxResultado.Location = New System.Drawing.Point(243, 2)
        Me.grboxResultado.Name = "grboxResultado"
        Me.grboxResultado.Size = New System.Drawing.Size(108, 130)
        Me.grboxResultado.TabIndex = 28
        Me.grboxResultado.TabStop = False
        '
        'rbtnNoRegistro
        '
        Me.rbtnNoRegistro.AutoSize = True
        Me.rbtnNoRegistro.Location = New System.Drawing.Point(7, 86)
        Me.rbtnNoRegistro.Name = "rbtnNoRegistro"
        Me.rbtnNoRegistro.Size = New System.Drawing.Size(81, 17)
        Me.rbtnNoRegistro.TabIndex = 3
        Me.rbtnNoRegistro.TabStop = True
        Me.rbtnNoRegistro.Text = "No Registro"
        Me.rbtnNoRegistro.UseVisualStyleBackColor = True
        '
        'rbtnRetardoMayor
        '
        Me.rbtnRetardoMayor.AutoSize = True
        Me.rbtnRetardoMayor.Location = New System.Drawing.Point(7, 63)
        Me.rbtnRetardoMayor.Name = "rbtnRetardoMayor"
        Me.rbtnRetardoMayor.Size = New System.Drawing.Size(94, 17)
        Me.rbtnRetardoMayor.TabIndex = 2
        Me.rbtnRetardoMayor.TabStop = True
        Me.rbtnRetardoMayor.Text = "Retardo mayor"
        Me.rbtnRetardoMayor.UseVisualStyleBackColor = True
        '
        'rbtnRetardoMenor
        '
        Me.rbtnRetardoMenor.AutoSize = True
        Me.rbtnRetardoMenor.Location = New System.Drawing.Point(7, 40)
        Me.rbtnRetardoMenor.Name = "rbtnRetardoMenor"
        Me.rbtnRetardoMenor.Size = New System.Drawing.Size(95, 17)
        Me.rbtnRetardoMenor.TabIndex = 1
        Me.rbtnRetardoMenor.TabStop = True
        Me.rbtnRetardoMenor.Text = "Retardo menor"
        Me.rbtnRetardoMenor.UseVisualStyleBackColor = True
        '
        'rbtnNormal
        '
        Me.rbtnNormal.AutoSize = True
        Me.rbtnNormal.Location = New System.Drawing.Point(7, 17)
        Me.rbtnNormal.Name = "rbtnNormal"
        Me.rbtnNormal.Size = New System.Drawing.Size(66, 17)
        Me.rbtnNormal.TabIndex = 0
        Me.rbtnNormal.TabStop = True
        Me.rbtnNormal.Text = "A tiempo"
        Me.rbtnNormal.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 147)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 56)
        Me.Panel1.TabIndex = 29
        '
        'rbtnComida
        '
        Me.rbtnComida.AutoSize = True
        Me.rbtnComida.Location = New System.Drawing.Point(7, 109)
        Me.rbtnComida.Name = "rbtnComida"
        Me.rbtnComida.Size = New System.Drawing.Size(60, 17)
        Me.rbtnComida.TabIndex = 4
        Me.rbtnComida.TabStop = True
        Me.rbtnComida.Text = "Comida"
        Me.rbtnComida.UseVisualStyleBackColor = True
        '
        'RegistroManualForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(363, 203)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grboxResultado)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.lblNota)
        Me.Controls.Add(Me.dtpRegistroManual)
        Me.Controls.Add(Me.lblHora)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RegistroManualForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registro manual"
        Me.grboxResultado.ResumeLayout(False)
        Me.grboxResultado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents dtpRegistroManual As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grboxResultado As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnRetardoMayor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnRetardoMenor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnNoRegistro As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnComida As System.Windows.Forms.RadioButton
End Class
