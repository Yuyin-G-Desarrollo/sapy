<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesVistaPrevia
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
        Me.crvreporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvreporte
        '
        Me.crvreporte.ActiveViewIndex = -1
        Me.crvreporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvreporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvreporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvreporte.Location = New System.Drawing.Point(0, 0)
        Me.crvreporte.Name = "crvreporte"
        Me.crvreporte.Size = New System.Drawing.Size(580, 534)
        Me.crvreporte.TabIndex = 0
        Me.crvreporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportesVistaPrevia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 534)
        Me.Controls.Add(Me.crvreporte)
        Me.Name = "ReportesVistaPrevia"
        Me.Text = "ReportesVistaPrevia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvreporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
