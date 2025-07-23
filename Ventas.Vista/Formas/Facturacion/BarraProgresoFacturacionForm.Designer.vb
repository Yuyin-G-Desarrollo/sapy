<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarraProgresoFacturacionForm
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
        Me.lblDocumentosProcesados = New System.Windows.Forms.Label()
        Me.lblNumeroDeDocumentos = New System.Windows.Forms.Label()
        Me.lblStatusProcesoDocumento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.pgrBarFacturas = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblDocumentosProcesados)
        Me.Panel1.Controls.Add(Me.lblNumeroDeDocumentos)
        Me.Panel1.Controls.Add(Me.lblStatusProcesoDocumento)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblPorcentaje)
        Me.Panel1.Controls.Add(Me.pgrBarFacturas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(789, 178)
        Me.Panel1.TabIndex = 28
        '
        'lblDocumentosProcesados
        '
        Me.lblDocumentosProcesados.AutoSize = True
        Me.lblDocumentosProcesados.Location = New System.Drawing.Point(158, 37)
        Me.lblDocumentosProcesados.Name = "lblDocumentosProcesados"
        Me.lblDocumentosProcesados.Size = New System.Drawing.Size(13, 13)
        Me.lblDocumentosProcesados.TabIndex = 6
        Me.lblDocumentosProcesados.Text = "0"
        '
        'lblNumeroDeDocumentos
        '
        Me.lblNumeroDeDocumentos.AutoSize = True
        Me.lblNumeroDeDocumentos.Location = New System.Drawing.Point(158, 17)
        Me.lblNumeroDeDocumentos.Name = "lblNumeroDeDocumentos"
        Me.lblNumeroDeDocumentos.Size = New System.Drawing.Size(13, 13)
        Me.lblNumeroDeDocumentos.TabIndex = 5
        Me.lblNumeroDeDocumentos.Text = "0"
        '
        'lblStatusProcesoDocumento
        '
        Me.lblStatusProcesoDocumento.AutoSize = True
        Me.lblStatusProcesoDocumento.Location = New System.Drawing.Point(30, 60)
        Me.lblStatusProcesoDocumento.Name = "lblStatusProcesoDocumento"
        Me.lblStatusProcesoDocumento.Size = New System.Drawing.Size(122, 13)
        Me.lblStatusProcesoDocumento.TabIndex = 4
        Me.lblStatusProcesoDocumento.Text = "Número de Documentos"
        Me.lblStatusProcesoDocumento.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Documentos Procesados"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Documentos a generar"
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentaje.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblPorcentaje.Location = New System.Drawing.Point(334, 131)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(54, 20)
        Me.lblPorcentaje.TabIndex = 1
        Me.lblPorcentaje.Text = "100%"
        '
        'pgrBarFacturas
        '
        Me.pgrBarFacturas.Location = New System.Drawing.Point(29, 85)
        Me.pgrBarFacturas.Name = "pgrBarFacturas"
        Me.pgrBarFacturas.Size = New System.Drawing.Size(729, 33)
        Me.pgrBarFacturas.TabIndex = 0
        '
        'BarraProgresoFacturacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 178)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(805, 217)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(805, 217)
        Me.Name = "BarraProgresoFacturacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BARRA DE PROGRESO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDocumentosProcesados As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDeDocumentos As System.Windows.Forms.Label
    Friend WithEvents lblStatusProcesoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents pgrBarFacturas As System.Windows.Forms.ProgressBar
End Class
