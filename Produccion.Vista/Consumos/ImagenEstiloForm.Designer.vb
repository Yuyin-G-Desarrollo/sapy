<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagenEstiloForm
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
        Me.pbxFoto = New System.Windows.Forms.PictureBox()
        CType(Me.pbxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxFoto
        '
        Me.pbxFoto.BackColor = System.Drawing.Color.White
        Me.pbxFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxFoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxFoto.Location = New System.Drawing.Point(0, 0)
        Me.pbxFoto.Name = "pbxFoto"
        Me.pbxFoto.Size = New System.Drawing.Size(588, 489)
        Me.pbxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbxFoto.TabIndex = 0
        Me.pbxFoto.TabStop = False
        '
        'ImagenEstiloForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(588, 489)
        Me.Controls.Add(Me.pbxFoto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ImagenEstiloForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imagen Estilo"
        CType(Me.pbxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbxFoto As System.Windows.Forms.PictureBox
End Class
