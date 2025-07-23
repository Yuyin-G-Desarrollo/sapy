<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaptcha
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
        Me.lblCaptcha = New System.Windows.Forms.Label()
        Me.txtCaptcha = New System.Windows.Forms.TextBox()
        Me.lblMensajePrincipal = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMensajeFacturacion = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCaptcha
        '
        Me.lblCaptcha.AutoSize = True
        Me.lblCaptcha.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptcha.Location = New System.Drawing.Point(166, 97)
        Me.lblCaptcha.Name = "lblCaptcha"
        Me.lblCaptcha.Size = New System.Drawing.Size(120, 31)
        Me.lblCaptcha.TabIndex = 3
        Me.lblCaptcha.Text = "XDC1S5"
        '
        'txtCaptcha
        '
        Me.txtCaptcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCaptcha.Location = New System.Drawing.Point(142, 129)
        Me.txtCaptcha.Name = "txtCaptcha"
        Me.txtCaptcha.Size = New System.Drawing.Size(169, 20)
        Me.txtCaptcha.TabIndex = 4
        '
        'lblMensajePrincipal
        '
        Me.lblMensajePrincipal.AutoSize = True
        Me.lblMensajePrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajePrincipal.Location = New System.Drawing.Point(79, 35)
        Me.lblMensajePrincipal.Name = "lblMensajePrincipal"
        Me.lblMensajePrincipal.Size = New System.Drawing.Size(294, 48)
        Me.lblMensajePrincipal.TabIndex = 5
        Me.lblMensajePrincipal.Text = "PARA CONTINUAR POR FAVOR ESCRIBA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EN EL CAMPO DE TEXTO LOS CARACTERES " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "QUE A CON" & _
    "TINUACIÓN APARECEN "
        Me.lblMensajePrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(317, 128)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(37, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(77, 165)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(37, 29)
        Me.lblMensaje.TabIndex = 7
        Me.lblMensaje.Text = "---"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(126, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(201, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "CONFIRME PRESIONANDO OK"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Tools.My.Resources.Resources.advertencia
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(418, 233)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'lblMensajeFacturacion
        '
        Me.lblMensajeFacturacion.AutoSize = True
        Me.lblMensajeFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeFacturacion.Location = New System.Drawing.Point(79, 35)
        Me.lblMensajeFacturacion.Name = "lblMensajeFacturacion"
        Me.lblMensajeFacturacion.Size = New System.Drawing.Size(307, 64)
        Me.lblMensajeFacturacion.TabIndex = 9
        Me.lblMensajeFacturacion.Text = "Al sustituir el documento en este momento se " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "generará uno nuevo con las mismas " & _
    "partidas del " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "documento cancelado ¿Desea continuar? " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Capture los caracteres m" & _
    "ostrados para confirmar)"
        Me.lblMensajeFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCaptcha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(418, 233)
        Me.Controls.Add(Me.lblMensajeFacturacion)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblMensajePrincipal)
        Me.Controls.Add(Me.txtCaptcha)
        Me.Controls.Add(Me.lblCaptcha)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCaptcha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atención"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCaptcha As System.Windows.Forms.Label
    Friend WithEvents txtCaptcha As System.Windows.Forms.TextBox
    Friend WithEvents lblMensajePrincipal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblMensajeFacturacion As System.Windows.Forms.Label
End Class
