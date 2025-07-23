<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComplementoPagoForm
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
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.btnGenerarPdf = New System.Windows.Forms.Button()
        Me.btnnTimbrarCancelacion = New System.Windows.Forms.Button()
        Me.btnCancelarPDF = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTimbrar
        '
        Me.btnTimbrar.Location = New System.Drawing.Point(26, 30)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(75, 23)
        Me.btnTimbrar.TabIndex = 0
        Me.btnTimbrar.Text = "Timbrar"
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'btnGenerarPdf
        '
        Me.btnGenerarPdf.Location = New System.Drawing.Point(26, 86)
        Me.btnGenerarPdf.Name = "btnGenerarPdf"
        Me.btnGenerarPdf.Size = New System.Drawing.Size(156, 23)
        Me.btnGenerarPdf.TabIndex = 1
        Me.btnGenerarPdf.Text = "Generar PDF"
        Me.btnGenerarPdf.UseVisualStyleBackColor = True
        '
        'btnnTimbrarCancelacion
        '
        Me.btnnTimbrarCancelacion.Location = New System.Drawing.Point(26, 131)
        Me.btnnTimbrarCancelacion.Name = "btnnTimbrarCancelacion"
        Me.btnnTimbrarCancelacion.Size = New System.Drawing.Size(156, 23)
        Me.btnnTimbrarCancelacion.TabIndex = 2
        Me.btnnTimbrarCancelacion.Text = "Cancelar timbre"
        Me.btnnTimbrarCancelacion.UseVisualStyleBackColor = True
        '
        'btnCancelarPDF
        '
        Me.btnCancelarPDF.Location = New System.Drawing.Point(26, 185)
        Me.btnCancelarPDF.Name = "btnCancelarPDF"
        Me.btnCancelarPDF.Size = New System.Drawing.Size(156, 23)
        Me.btnCancelarPDF.TabIndex = 3
        Me.btnCancelarPDF.Text = "Cancelar PDF"
        Me.btnCancelarPDF.UseVisualStyleBackColor = True
        '
        'ComplementoPagoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnCancelarPDF)
        Me.Controls.Add(Me.btnnTimbrarCancelacion)
        Me.Controls.Add(Me.btnGenerarPdf)
        Me.Controls.Add(Me.btnTimbrar)
        Me.Name = "ComplementoPagoForm"
        Me.Text = "ComplementoPagoForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTimbrar As System.Windows.Forms.Button
    Friend WithEvents btnGenerarPdf As System.Windows.Forms.Button
    Friend WithEvents btnnTimbrarCancelacion As System.Windows.Forms.Button
    Friend WithEvents btnCancelarPDF As System.Windows.Forms.Button
End Class
