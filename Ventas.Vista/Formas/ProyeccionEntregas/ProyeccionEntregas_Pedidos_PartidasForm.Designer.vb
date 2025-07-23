<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyeccionEntregas_Pedidos_PartidasForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdVPartidasPedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.grdVPartidasPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdVPartidasPedidos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 261)
        Me.Panel1.TabIndex = 0
        '
        'grdVPartidasPedidos
        '
        Me.grdVPartidasPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVPartidasPedidos.Location = New System.Drawing.Point(0, 0)
        Me.grdVPartidasPedidos.Name = "grdVPartidasPedidos"
        Me.grdVPartidasPedidos.Size = New System.Drawing.Size(396, 261)
        Me.grdVPartidasPedidos.TabIndex = 0
        Me.grdVPartidasPedidos.Text = "UltraGrid1"
        '
        'ProyeccionEntregas_Pedidos_PartidasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ProyeccionEntregas_Pedidos_PartidasForm"
        Me.Text = "ProyeccionEntregas_Pedidos_PartidasForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdVPartidasPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdVPartidasPedidos As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
