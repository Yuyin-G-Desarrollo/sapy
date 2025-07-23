<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvisoForm
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
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.lblMensaje = New System.Windows.Forms.Label()
		Me.btnAceptar = New System.Windows.Forms.Button()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.Nomina.Vista.My.Resources.Resources.aviso
		Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(405, 219)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'lblMensaje
		'
		Me.lblMensaje.AutoSize = True
		Me.lblMensaje.BackColor = System.Drawing.Color.AliceBlue
		Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMensaje.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblMensaje.Location = New System.Drawing.Point(73, 53)
		Me.lblMensaje.MaximumSize = New System.Drawing.Size(329, 0)
		Me.lblMensaje.Name = "lblMensaje"
		Me.lblMensaje.Size = New System.Drawing.Size(290, 22)
		Me.lblMensaje.TabIndex = 10
		Me.lblMensaje.Text = "Recuerde registrar los usuarios al IMSS"
		Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblMensaje.UseCompatibleTextRendering = True
		'
		'btnAceptar
		'
		Me.btnAceptar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.advertencia
		Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
		Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnAceptar.Location = New System.Drawing.Point(136, 150)
		Me.btnAceptar.Margin = New System.Windows.Forms.Padding(0)
		Me.btnAceptar.Name = "btnAceptar"
		Me.btnAceptar.Size = New System.Drawing.Size(131, 33)
		Me.btnAceptar.TabIndex = 9
		Me.btnAceptar.Text = "Aceptar"
		Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnAceptar.UseVisualStyleBackColor = False
		'
		'AvisoForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(403, 216)
		Me.Controls.Add(Me.lblMensaje)
		Me.Controls.Add(Me.btnAceptar)
		Me.Controls.Add(Me.PictureBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AvisoForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents lblMensaje As System.Windows.Forms.Label
	Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
