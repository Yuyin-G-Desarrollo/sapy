<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarMotivoIncidenciaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarMotivoIncidenciaForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaCatalogoRamos = New System.Windows.Forms.Label()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpMotivosIncidencia = New System.Windows.Forms.GroupBox()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtNombreMotivoIncidencia = New System.Windows.Forms.TextBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.lblMotivoIncidencia = New System.Windows.Forms.Label()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbRamos.SuspendLayout()
        Me.grpMotivosIncidencia.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoRamos)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(483, 53)
        Me.pnlEncabezado.TabIndex = 70
        '
        'lblListaCatalogoRamos
        '
        Me.lblListaCatalogoRamos.AutoSize = True
        Me.lblListaCatalogoRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoRamos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoRamos.Location = New System.Drawing.Point(197, 19)
        Me.lblListaCatalogoRamos.Name = "lblListaCatalogoRamos"
        Me.lblListaCatalogoRamos.Size = New System.Drawing.Size(212, 20)
        Me.lblListaCatalogoRamos.TabIndex = 46
        Me.lblListaCatalogoRamos.Text = "Tipo Motivo de Incidencia"
        '
        'grbRamos
        '
        Me.grbRamos.BackColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Controls.Add(Me.Label4)
        Me.grbRamos.Controls.Add(Me.btnClose)
        Me.grbRamos.Controls.Add(Me.grpMotivosIncidencia)
        Me.grbRamos.Controls.Add(Me.lblGuardar)
        Me.grbRamos.Controls.Add(Me.lblLimpiar)
        Me.grbRamos.Controls.Add(Me.btnCerrar)
        Me.grbRamos.Controls.Add(Me.btnGuardar)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.ForeColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Location = New System.Drawing.Point(0, 53)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(483, 221)
        Me.grbRamos.TabIndex = 71
        Me.grbRamos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(390, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Cerrar"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnClose.Location = New System.Drawing.Point(391, 156)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 32)
        Me.btnClose.TabIndex = 33
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpMotivosIncidencia
        '
        Me.grpMotivosIncidencia.Controls.Add(Me.cmbCategoria)
        Me.grpMotivosIncidencia.Controls.Add(Me.lblCategoria)
        Me.grpMotivosIncidencia.Controls.Add(Me.txtNombreMotivoIncidencia)
        Me.grpMotivosIncidencia.Controls.Add(Me.rdoSi)
        Me.grpMotivosIncidencia.Controls.Add(Me.lblMotivoIncidencia)
        Me.grpMotivosIncidencia.Controls.Add(Me.rdoNo)
        Me.grpMotivosIncidencia.Controls.Add(Me.lblActivo)
        Me.grpMotivosIncidencia.Location = New System.Drawing.Point(12, 13)
        Me.grpMotivosIncidencia.Name = "grpMotivosIncidencia"
        Me.grpMotivosIncidencia.Size = New System.Drawing.Size(411, 137)
        Me.grpMotivosIncidencia.TabIndex = 29
        Me.grpMotivosIncidencia.TabStop = False
        Me.grpMotivosIncidencia.Text = "Tipo Motivo Incidencia"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(133, 35)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(272, 21)
        Me.cmbCategoria.TabIndex = 30
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCategoria.Location = New System.Drawing.Point(8, 35)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(58, 13)
        Me.lblCategoria.TabIndex = 29
        Me.lblCategoria.Text = "*Categoría"
        '
        'txtNombreMotivoIncidencia
        '
        Me.txtNombreMotivoIncidencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreMotivoIncidencia.Location = New System.Drawing.Point(133, 64)
        Me.txtNombreMotivoIncidencia.MaxLength = 100
        Me.txtNombreMotivoIncidencia.Name = "txtNombreMotivoIncidencia"
        Me.txtNombreMotivoIncidencia.Size = New System.Drawing.Size(272, 20)
        Me.txtNombreMotivoIncidencia.TabIndex = 28
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoSi.Location = New System.Drawing.Point(63, 101)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 3
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'lblMotivoIncidencia
        '
        Me.lblMotivoIncidencia.AutoSize = True
        Me.lblMotivoIncidencia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMotivoIncidencia.Location = New System.Drawing.Point(8, 67)
        Me.lblMotivoIncidencia.Name = "lblMotivoIncidencia"
        Me.lblMotivoIncidencia.Size = New System.Drawing.Size(119, 13)
        Me.lblMotivoIncidencia.TabIndex = 27
        Me.lblMotivoIncidencia.Text = "*Tipo Motivo Incidencia"
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoNo.Location = New System.Drawing.Point(117, 101)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 4
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblActivo.Location = New System.Drawing.Point(8, 103)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(334, 190)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 26
        Me.lblGuardar.Text = "Guardar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(593, 130)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(596, 93)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(336, 156)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(415, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarMotivoIncidenciaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 274)
        Me.Controls.Add(Me.grbRamos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(499, 313)
        Me.Name = "AgregarEditarMotivoIncidenciaForm"
        Me.Text = "Información Motivo Incidencia"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        Me.grpMotivosIncidencia.ResumeLayout(False)
        Me.grpMotivosIncidencia.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaCatalogoRamos As System.Windows.Forms.Label
    Friend WithEvents grbRamos As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreMotivoIncidencia As System.Windows.Forms.TextBox
    Friend WithEvents lblMotivoIncidencia As System.Windows.Forms.Label
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents grpMotivosIncidencia As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
