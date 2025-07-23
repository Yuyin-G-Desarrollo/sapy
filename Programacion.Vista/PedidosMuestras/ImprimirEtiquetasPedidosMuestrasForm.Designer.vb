<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirEtiquetasPedidosMuestrasForm
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
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.cmbImpresion = New System.Windows.Forms.ComboBox()
        Me.chkCaja = New System.Windows.Forms.CheckBox()
        Me.chkSuela = New System.Windows.Forms.CheckBox()
        Me.lblImpresora = New System.Windows.Forms.Label()
        Me.chkColgante = New System.Windows.Forms.CheckBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.groupContenedor.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.cmbImpresion)
        Me.groupContenedor.Controls.Add(Me.chkCaja)
        Me.groupContenedor.Controls.Add(Me.chkSuela)
        Me.groupContenedor.Controls.Add(Me.lblImpresora)
        Me.groupContenedor.Controls.Add(Me.chkColgante)
        Me.groupContenedor.Location = New System.Drawing.Point(5, 91)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(305, 118)
        Me.groupContenedor.TabIndex = 17
        Me.groupContenedor.TabStop = False
        '
        'cmbImpresion
        '
        Me.cmbImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresion.FormattingEnabled = True
        Me.cmbImpresion.Items.AddRange(New Object() {"IMPRESIÓN 200", "IMPRESIÓN 300"})
        Me.cmbImpresion.Location = New System.Drawing.Point(141, 18)
        Me.cmbImpresion.Name = "cmbImpresion"
        Me.cmbImpresion.Size = New System.Drawing.Size(153, 21)
        Me.cmbImpresion.TabIndex = 4
        '
        'chkCaja
        '
        Me.chkCaja.AutoSize = True
        Me.chkCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCaja.Location = New System.Drawing.Point(167, 52)
        Me.chkCaja.Name = "chkCaja"
        Me.chkCaja.Size = New System.Drawing.Size(60, 24)
        Me.chkCaja.TabIndex = 2
        Me.chkCaja.Text = "Caja"
        Me.chkCaja.UseVisualStyleBackColor = True
        '
        'chkSuela
        '
        Me.chkSuela.AutoSize = True
        Me.chkSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuela.Location = New System.Drawing.Point(166, 82)
        Me.chkSuela.Name = "chkSuela"
        Me.chkSuela.Size = New System.Drawing.Size(69, 24)
        Me.chkSuela.TabIndex = 1
        Me.chkSuela.Text = "Suela"
        Me.chkSuela.UseVisualStyleBackColor = True
        '
        'lblImpresora
        '
        Me.lblImpresora.AutoSize = True
        Me.lblImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpresora.Location = New System.Drawing.Point(7, 16)
        Me.lblImpresora.Name = "lblImpresora"
        Me.lblImpresora.Size = New System.Drawing.Size(117, 20)
        Me.lblImpresora.TabIndex = 3
        Me.lblImpresora.Text = "Tipo Impresión:"
        '
        'chkColgante
        '
        Me.chkColgante.AutoSize = True
        Me.chkColgante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColgante.Location = New System.Drawing.Point(41, 51)
        Me.chkColgante.Name = "chkColgante"
        Me.chkColgante.Size = New System.Drawing.Size(92, 24)
        Me.chkColgante.TabIndex = 0
        Me.chkColgante.Text = "Colgante"
        Me.chkColgante.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(348, 60)
        Me.pnlHeader.TabIndex = 15
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(72, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(276, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(39, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(155, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Imprimir Etiquetas"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 215)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(348, 65)
        Me.pnlEstado.TabIndex = 16
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblSalir)
        Me.pnlOperaciones.Controls.Add(Me.lblImprimir)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(199, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(149, 65)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(99, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 5
        Me.lblSalir.Text = "Salir"
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(32, 41)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 4
        Me.lblImprimir.Text = "Imprimir"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(208, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(96, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(35, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ImprimirEtiquetasPedidosMuestrasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(348, 280)
        Me.Controls.Add(Me.groupContenedor)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.MaximumSize = New System.Drawing.Size(364, 319)
        Me.MinimumSize = New System.Drawing.Size(338, 319)
        Me.Name = "ImprimirEtiquetasPedidosMuestrasForm"
        Me.Text = "Imprimir Etiquetas Pedidos Muestras"
        Me.groupContenedor.ResumeLayout(False)
        Me.groupContenedor.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents cmbImpresion As ComboBox
    Friend WithEvents chkCaja As CheckBox
    Friend WithEvents chkSuela As CheckBox
    Friend WithEvents lblImpresora As Label
    Friend WithEvents chkColgante As CheckBox
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents lblSalir As Label
    Friend WithEvents lblImprimir As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
End Class
