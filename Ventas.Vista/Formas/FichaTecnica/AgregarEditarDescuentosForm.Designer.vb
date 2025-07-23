<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarDescuentosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarDescuentosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gboxHistorial = New System.Windows.Forms.GroupBox()
        Me.gboxModificacionStatusCliente = New System.Windows.Forms.GroupBox()
        Me.rbtnClienteStatusInactivo = New System.Windows.Forms.RadioButton()
        Me.rbtnClienteStatusActivo = New System.Windows.Forms.RadioButton()
        Me.numDescuentoCantidad = New System.Windows.Forms.NumericUpDown()
        Me.numDias = New System.Windows.Forms.NumericUpDown()
        Me.chboxEncadenado = New System.Windows.Forms.CheckBox()
        Me.chboxPorcentaje = New System.Windows.Forms.CheckBox()
        Me.cboxMotivo = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.cboxLugar = New System.Windows.Forms.ComboBox()
        Me.lblLugar = New System.Windows.Forms.Label()
        Me.pnlClienteBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.gboxHistorial.SuspendLayout()
        Me.gboxModificacionStatusCliente.SuspendLayout()
        CType(Me.numDescuentoCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlClienteBotones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(505, 59)
        Me.pnlEncabezado.TabIndex = 32
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-16, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(521, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(255, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(195, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Descuentos del Cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gboxHistorial
        '
        Me.gboxHistorial.BackColor = System.Drawing.Color.AliceBlue
        Me.gboxHistorial.Controls.Add(Me.gboxModificacionStatusCliente)
        Me.gboxHistorial.Controls.Add(Me.pnlClienteBotones)
        Me.gboxHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gboxHistorial.ForeColor = System.Drawing.Color.Black
        Me.gboxHistorial.Location = New System.Drawing.Point(0, 0)
        Me.gboxHistorial.Name = "gboxHistorial"
        Me.gboxHistorial.Size = New System.Drawing.Size(505, 328)
        Me.gboxHistorial.TabIndex = 31
        Me.gboxHistorial.TabStop = False
        Me.gboxHistorial.Text = "Historial de validaciones"
        '
        'gboxModificacionStatusCliente
        '
        Me.gboxModificacionStatusCliente.Controls.Add(Me.rbtnClienteStatusInactivo)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.rbtnClienteStatusActivo)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.numDescuentoCantidad)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.numDias)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.chboxEncadenado)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.chboxPorcentaje)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.cboxMotivo)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblMotivo)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblDias)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblCantidad)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.cboxLugar)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblLugar)
        Me.gboxModificacionStatusCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gboxModificacionStatusCliente.ForeColor = System.Drawing.Color.Black
        Me.gboxModificacionStatusCliente.Location = New System.Drawing.Point(63, 65)
        Me.gboxModificacionStatusCliente.Name = "gboxModificacionStatusCliente"
        Me.gboxModificacionStatusCliente.Size = New System.Drawing.Size(370, 180)
        Me.gboxModificacionStatusCliente.TabIndex = 31
        Me.gboxModificacionStatusCliente.TabStop = False
        '
        'rbtnClienteStatusInactivo
        '
        Me.rbtnClienteStatusInactivo.AutoSize = True
        Me.rbtnClienteStatusInactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnClienteStatusInactivo.ForeColor = System.Drawing.Color.Black
        Me.rbtnClienteStatusInactivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbtnClienteStatusInactivo.Location = New System.Drawing.Point(148, 146)
        Me.rbtnClienteStatusInactivo.Name = "rbtnClienteStatusInactivo"
        Me.rbtnClienteStatusInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rbtnClienteStatusInactivo.TabIndex = 8
        Me.rbtnClienteStatusInactivo.Text = "Inactivo"
        Me.rbtnClienteStatusInactivo.UseVisualStyleBackColor = True
        '
        'rbtnClienteStatusActivo
        '
        Me.rbtnClienteStatusActivo.AutoSize = True
        Me.rbtnClienteStatusActivo.Checked = True
        Me.rbtnClienteStatusActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnClienteStatusActivo.ForeColor = System.Drawing.Color.Black
        Me.rbtnClienteStatusActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbtnClienteStatusActivo.Location = New System.Drawing.Point(77, 146)
        Me.rbtnClienteStatusActivo.Name = "rbtnClienteStatusActivo"
        Me.rbtnClienteStatusActivo.Size = New System.Drawing.Size(55, 17)
        Me.rbtnClienteStatusActivo.TabIndex = 7
        Me.rbtnClienteStatusActivo.TabStop = True
        Me.rbtnClienteStatusActivo.Text = "Activo"
        Me.rbtnClienteStatusActivo.UseVisualStyleBackColor = True
        '
        'numDescuentoCantidad
        '
        Me.numDescuentoCantidad.DecimalPlaces = 2
        Me.numDescuentoCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDescuentoCantidad.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numDescuentoCantidad.Location = New System.Drawing.Point(77, 79)
        Me.numDescuentoCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numDescuentoCantidad.Name = "numDescuentoCantidad"
        Me.numDescuentoCantidad.Size = New System.Drawing.Size(88, 20)
        Me.numDescuentoCantidad.TabIndex = 3
        Me.numDescuentoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numDescuentoCantidad.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'numDias
        '
        Me.numDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDias.Location = New System.Drawing.Point(77, 111)
        Me.numDias.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numDias.Name = "numDias"
        Me.numDias.Size = New System.Drawing.Size(88, 20)
        Me.numDias.TabIndex = 6
        Me.numDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chboxEncadenado
        '
        Me.chboxEncadenado.AutoSize = True
        Me.chboxEncadenado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chboxEncadenado.Location = New System.Drawing.Point(176, 79)
        Me.chboxEncadenado.Name = "chboxEncadenado"
        Me.chboxEncadenado.Size = New System.Drawing.Size(87, 17)
        Me.chboxEncadenado.TabIndex = 5
        Me.chboxEncadenado.Text = "Encadenado"
        Me.chboxEncadenado.UseVisualStyleBackColor = True
        '
        'chboxPorcentaje
        '
        Me.chboxPorcentaje.Checked = True
        Me.chboxPorcentaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chboxPorcentaje.Location = New System.Drawing.Point(316, 79)
        Me.chboxPorcentaje.Name = "chboxPorcentaje"
        Me.chboxPorcentaje.Size = New System.Drawing.Size(35, 17)
        Me.chboxPorcentaje.TabIndex = 4
        Me.chboxPorcentaje.Text = "%"
        Me.chboxPorcentaje.UseVisualStyleBackColor = True
        '
        'cboxMotivo
        '
        Me.cboxMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxMotivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxMotivo.FormattingEnabled = True
        Me.cboxMotivo.Items.AddRange(New Object() {"CLIENTE", "PROSPECTO"})
        Me.cboxMotivo.Location = New System.Drawing.Point(77, 16)
        Me.cboxMotivo.Name = "cboxMotivo"
        Me.cboxMotivo.Size = New System.Drawing.Size(274, 21)
        Me.cboxMotivo.TabIndex = 1
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.BackColor = System.Drawing.Color.Transparent
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.ForeColor = System.Drawing.Color.Black
        Me.lblMotivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMotivo.Location = New System.Drawing.Point(17, 19)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(43, 13)
        Me.lblMotivo.TabIndex = 13
        Me.lblMotivo.Text = "Motivo*"
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDias.ForeColor = System.Drawing.Color.Black
        Me.lblDias.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDias.Location = New System.Drawing.Point(17, 113)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(32, 13)
        Me.lblDias.TabIndex = 0
        Me.lblDias.Text = "Dias*"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.Black
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.Location = New System.Drawing.Point(17, 81)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(53, 13)
        Me.lblCantidad.TabIndex = 0
        Me.lblCantidad.Text = "Cantidad*"
        '
        'cboxLugar
        '
        Me.cboxLugar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxLugar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxLugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLugar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxLugar.FormattingEnabled = True
        Me.cboxLugar.Location = New System.Drawing.Point(77, 47)
        Me.cboxLugar.Name = "cboxLugar"
        Me.cboxLugar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboxLugar.Size = New System.Drawing.Size(274, 21)
        Me.cboxLugar.TabIndex = 2
        '
        'lblLugar
        '
        Me.lblLugar.AutoSize = True
        Me.lblLugar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLugar.ForeColor = System.Drawing.Color.Black
        Me.lblLugar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLugar.Location = New System.Drawing.Point(17, 50)
        Me.lblLugar.Name = "lblLugar"
        Me.lblLugar.Size = New System.Drawing.Size(38, 13)
        Me.lblLugar.TabIndex = 0
        Me.lblLugar.Text = "Lugar*"
        '
        'pnlClienteBotones
        '
        Me.pnlClienteBotones.BackColor = System.Drawing.Color.White
        Me.pnlClienteBotones.Controls.Add(Me.btnCerrar)
        Me.pnlClienteBotones.Controls.Add(Me.lblCerrar)
        Me.pnlClienteBotones.Controls.Add(Me.btnGuardar)
        Me.pnlClienteBotones.Controls.Add(Me.lblGuardar)
        Me.pnlClienteBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlClienteBotones.Location = New System.Drawing.Point(3, 260)
        Me.pnlClienteBotones.Name = "pnlClienteBotones"
        Me.pnlClienteBotones.Size = New System.Drawing.Size(499, 65)
        Me.pnlClienteBotones.TabIndex = 30
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(423, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 10
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(422, 43)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 5
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(364, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(358, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 6
        Me.lblGuardar.Text = "Guardar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(453, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarDescuentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(505, 328)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.gboxHistorial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AgregarEditarDescuentosForm"
        Me.Text = "Descuentos del Cliente"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.gboxHistorial.ResumeLayout(False)
        Me.gboxModificacionStatusCliente.ResumeLayout(False)
        Me.gboxModificacionStatusCliente.PerformLayout()
        CType(Me.numDescuentoCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlClienteBotones.ResumeLayout(False)
        Me.pnlClienteBotones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents gboxHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents pnlClienteBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents gboxModificacionStatusCliente As System.Windows.Forms.GroupBox
    Friend WithEvents cboxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents cboxLugar As System.Windows.Forms.ComboBox
    Friend WithEvents lblLugar As System.Windows.Forms.Label
    Friend WithEvents chboxEncadenado As System.Windows.Forms.CheckBox
    Friend WithEvents chboxPorcentaje As System.Windows.Forms.CheckBox
    Friend WithEvents numDescuentoCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDias As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbtnClienteStatusInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnClienteStatusActivo As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
