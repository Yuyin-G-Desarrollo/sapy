<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarDescripcionFiniquitoForm
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
        Me.txtDescripcionFiniquito = New System.Windows.Forms.TextBox()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDescripcionFiniquito
        '
        Me.txtDescripcionFiniquito.Location = New System.Drawing.Point(2, 2)
        Me.txtDescripcionFiniquito.Multiline = True
        Me.txtDescripcionFiniquito.Name = "txtDescripcionFiniquito"
        Me.txtDescripcionFiniquito.Size = New System.Drawing.Size(312, 119)
        Me.txtDescripcionFiniquito.TabIndex = 0
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(269, 158)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(45, 13)
        Me.lblNuevo.TabIndex = 5
        Me.lblNuevo.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(274, 127)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(31, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'AgregarDescripcionFiniquitoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(317, 175)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblNuevo)
        Me.Controls.Add(Me.txtDescripcionFiniquito)
        Me.Name = "AgregarDescripcionFiniquitoForm"
        Me.Text = "Agregar Anotaciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescripcionFiniquito As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
End Class
