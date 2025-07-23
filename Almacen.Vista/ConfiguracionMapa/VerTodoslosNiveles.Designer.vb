<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerTodoslosNiveles
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.opciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DetalleOcupacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.opciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.AutoScroll = True
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1129, 524)
        Me.pnlContenedor.TabIndex = 0
        '
        'opciones
        '
        Me.opciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalleOcupacionToolStripMenuItem})
        Me.opciones.Name = "opciones"
        Me.opciones.Size = New System.Drawing.Size(172, 48)
        '
        'DetalleOcupacionToolStripMenuItem
        '
        Me.DetalleOcupacionToolStripMenuItem.Name = "DetalleOcupacionToolStripMenuItem"
        Me.DetalleOcupacionToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DetalleOcupacionToolStripMenuItem.Text = "Detalle Ocupacion"
        '
        'VerTodoslosNiveles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1129, 524)
        Me.Controls.Add(Me.pnlContenedor)
        Me.HelpButton = True
        Me.Name = "VerTodoslosNiveles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapa del Almacén"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.opciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents opciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DetalleOcupacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
