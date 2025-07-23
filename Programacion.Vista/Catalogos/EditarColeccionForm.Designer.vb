<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarColeccionForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.grdListaMarcasSeleccion = New System.Windows.Forms.DataGridView()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RdbEtiquetaLenguaSI = New System.Windows.Forms.RadioButton()
        Me.rdbEtiquetaLenguaNO = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdbEtiquetaEspecialSI = New System.Windows.Forms.RadioButton()
        Me.rdbEtiquetaEspecialNO = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSicy = New System.Windows.Forms.Label()
        Me.txtSicy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTemporadas = New System.Windows.Forms.ComboBox()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListaMarcasSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1066, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(801, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(265, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(195, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Edición de Colecciones"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(197, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 471)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1066, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(854, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(100, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 10
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(151, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 11
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(106, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(159, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(110, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(401, 20)
        Me.txtNombre.TabIndex = 2
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(35, 20)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 4
        Me.lblNombre.Text = "* Nombre"
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(375, 6)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 6
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(411, 6)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 7
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'grdListaMarcasSeleccion
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaMarcasSeleccion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdListaMarcasSeleccion.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaMarcasSeleccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion})
        Me.grdListaMarcasSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaMarcasSeleccion.Location = New System.Drawing.Point(0, 133)
        Me.grdListaMarcasSeleccion.Name = "grdListaMarcasSeleccion"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdListaMarcasSeleccion.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdListaMarcasSeleccion.Size = New System.Drawing.Size(1066, 338)
        Me.grdListaMarcasSeleccion.TabIndex = 8
        '
        'seleccion
        '
        Me.seleccion.HeaderText = ""
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Width = 55
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.Panel4)
        Me.grpDatos.Controls.Add(Me.Panel3)
        Me.grpDatos.Controls.Add(Me.Panel2)
        Me.grpDatos.Controls.Add(Me.cmbTemporadas)
        Me.grpDatos.Controls.Add(Me.lblAnio)
        Me.grpDatos.Controls.Add(Me.txtNombre)
        Me.grpDatos.Controls.Add(Me.lblNombre)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatos.Location = New System.Drawing.Point(0, 60)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(1066, 73)
        Me.grpDatos.TabIndex = 9
        Me.grpDatos.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RdbEtiquetaLenguaSI)
        Me.Panel4.Controls.Add(Me.rdbEtiquetaLenguaNO)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(550, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(208, 24)
        Me.Panel4.TabIndex = 28
        '
        'RdbEtiquetaLenguaSI
        '
        Me.RdbEtiquetaLenguaSI.AutoSize = True
        Me.RdbEtiquetaLenguaSI.Location = New System.Drawing.Point(110, 5)
        Me.RdbEtiquetaLenguaSI.Name = "RdbEtiquetaLenguaSI"
        Me.RdbEtiquetaLenguaSI.Size = New System.Drawing.Size(34, 17)
        Me.RdbEtiquetaLenguaSI.TabIndex = 21
        Me.RdbEtiquetaLenguaSI.Text = "Si"
        Me.RdbEtiquetaLenguaSI.UseVisualStyleBackColor = True
        '
        'rdbEtiquetaLenguaNO
        '
        Me.rdbEtiquetaLenguaNO.AutoSize = True
        Me.rdbEtiquetaLenguaNO.Location = New System.Drawing.Point(150, 5)
        Me.rdbEtiquetaLenguaNO.Name = "rdbEtiquetaLenguaNO"
        Me.rdbEtiquetaLenguaNO.Size = New System.Drawing.Size(39, 17)
        Me.rdbEtiquetaLenguaNO.TabIndex = 22
        Me.rdbEtiquetaLenguaNO.Text = "No"
        Me.rdbEtiquetaLenguaNO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Etiqueta de Lengua"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.rdbEtiquetaEspecialSI)
        Me.Panel3.Controls.Add(Me.rdbEtiquetaEspecialNO)
        Me.Panel3.Location = New System.Drawing.Point(761, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 24)
        Me.Panel3.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Etiqueta Especial por Coleción"
        '
        'rdbEtiquetaEspecialSI
        '
        Me.rdbEtiquetaEspecialSI.AutoSize = True
        Me.rdbEtiquetaEspecialSI.Location = New System.Drawing.Point(164, 7)
        Me.rdbEtiquetaEspecialSI.Name = "rdbEtiquetaEspecialSI"
        Me.rdbEtiquetaEspecialSI.Size = New System.Drawing.Size(34, 17)
        Me.rdbEtiquetaEspecialSI.TabIndex = 24
        Me.rdbEtiquetaEspecialSI.Text = "Si"
        Me.rdbEtiquetaEspecialSI.UseVisualStyleBackColor = True
        '
        'rdbEtiquetaEspecialNO
        '
        Me.rdbEtiquetaEspecialNO.AutoSize = True
        Me.rdbEtiquetaEspecialNO.Location = New System.Drawing.Point(200, 7)
        Me.rdbEtiquetaEspecialNO.Name = "rdbEtiquetaEspecialNO"
        Me.rdbEtiquetaEspecialNO.Size = New System.Drawing.Size(39, 17)
        Me.rdbEtiquetaEspecialNO.TabIndex = 25
        Me.rdbEtiquetaEspecialNO.Text = "No"
        Me.rdbEtiquetaEspecialNO.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoInactivo)
        Me.Panel2.Controls.Add(Me.lblSicy)
        Me.Panel2.Controls.Add(Me.rdoActivo)
        Me.Panel2.Controls.Add(Me.txtSicy)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(550, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(459, 27)
        Me.Panel2.TabIndex = 10
        '
        'lblSicy
        '
        Me.lblSicy.AutoSize = True
        Me.lblSicy.Location = New System.Drawing.Point(3, 7)
        Me.lblSicy.Name = "lblSicy"
        Me.lblSicy.Size = New System.Drawing.Size(37, 13)
        Me.lblSicy.TabIndex = 17
        Me.lblSicy.Text = "  SICY"
        '
        'txtSicy
        '
        Me.txtSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSicy.Enabled = False
        Me.txtSicy.Location = New System.Drawing.Point(50, 3)
        Me.txtSicy.Name = "txtSicy"
        Me.txtSicy.Size = New System.Drawing.Size(98, 20)
        Me.txtSicy.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(332, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Activo"
        '
        'cmbTemporadas
        '
        Me.cmbTemporadas.FormattingEnabled = True
        Me.cmbTemporadas.Location = New System.Drawing.Point(110, 41)
        Me.cmbTemporadas.Name = "cmbTemporadas"
        Me.cmbTemporadas.Size = New System.Drawing.Size(401, 21)
        Me.cmbTemporadas.TabIndex = 20
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(35, 45)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(68, 13)
        Me.lblAnio.TabIndex = 19
        Me.lblAnio.Text = "* Temporada"
        '
        'EditarColeccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1066, 531)
        Me.Controls.Add(Me.grdListaMarcasSeleccion)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarColeccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edición de Colecciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdListaMarcasSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grdListaMarcasSeleccion As System.Windows.Forms.DataGridView
    Friend WithEvents seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTemporadas As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents txtSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblSicy As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rdbEtiquetaEspecialNO As RadioButton
    Friend WithEvents rdbEtiquetaEspecialSI As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents rdbEtiquetaLenguaNO As RadioButton
    Friend WithEvents RdbEtiquetaLenguaSI As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
End Class
