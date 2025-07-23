<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
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
        Me.grdPrueba = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.grdPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPrueba
        '
        Me.grdPrueba.Location = New System.Drawing.Point(12, 75)
        Me.grdPrueba.Name = "grdPrueba"
        Me.grdPrueba.Size = New System.Drawing.Size(817, 427)
        Me.grdPrueba.TabIndex = 0
        Me.grdPrueba.Text = "UltraGrid1"
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 514)
        Me.Controls.Add(Me.grdPrueba)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        CType(Me.grdPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdPrueba As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
