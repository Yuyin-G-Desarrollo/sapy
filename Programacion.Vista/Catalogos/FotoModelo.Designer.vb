<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FotoModelo
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
        Me.pcbFotoMax = New System.Windows.Forms.PictureBox()
        CType(Me.pcbFotoMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcbFotoMax
        '
        Me.pcbFotoMax.BackColor = System.Drawing.Color.White
        Me.pcbFotoMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pcbFotoMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbFotoMax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcbFotoMax.Location = New System.Drawing.Point(0, 0)
        Me.pcbFotoMax.Name = "pcbFotoMax"
        Me.pcbFotoMax.Size = New System.Drawing.Size(589, 487)
        Me.pcbFotoMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbFotoMax.TabIndex = 0
        Me.pcbFotoMax.TabStop = False
        '
        'FotoModelo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(589, 487)
        Me.Controls.Add(Me.pcbFotoMax)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FotoModelo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelo"
        CType(Me.pcbFotoMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcbFotoMax As System.Windows.Forms.PictureBox
End Class
