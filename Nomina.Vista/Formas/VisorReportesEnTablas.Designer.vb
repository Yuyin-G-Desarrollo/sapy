<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorReportesEnTablas
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
        Me.ReporteViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'ReporteViewer
        '
        Me.ReporteViewer.ActiveViewIndex = -1
        Me.ReporteViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReporteViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteViewer.Location = New System.Drawing.Point(0, 0)
        Me.ReporteViewer.Name = "ReporteViewer"
        Me.ReporteViewer.Size = New System.Drawing.Size(990, 645)
        Me.ReporteViewer.TabIndex = 0
        '
        'VisorReportesEnTablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 645)
        Me.Controls.Add(Me.ReporteViewer)
        Me.Name = "VisorReportesEnTablas"
        Me.Text = "VisorReportesEnTablas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
