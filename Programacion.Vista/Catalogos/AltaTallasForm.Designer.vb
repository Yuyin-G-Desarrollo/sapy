<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaTallasForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtTallaInicio = New System.Windows.Forms.NumericUpDown()
        Me.lblTallaInicio = New System.Windows.Forms.Label()
        Me.txtTallaFin = New System.Windows.Forms.NumericUpDown()
        Me.lblTallaFin = New System.Windows.Forms.Label()
        Me.chkEntero = New System.Windows.Forms.CheckBox()
        Me.lblTallaCentral = New System.Windows.Forms.Label()
        Me.txtTallaCentral = New System.Windows.Forms.NumericUpDown()
        Me.cmbTallaPrincipal = New System.Windows.Forms.ComboBox()
        Me.cmbPaises = New System.Windows.Forms.ComboBox()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblTallaPrincipal = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.ckbMedias = New System.Windows.Forms.CheckBox()
        Me.grdTablaAmarre = New System.Windows.Forms.DataGridView()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblCodSicy = New System.Windows.Forms.Label()
        Me.txtCodSicy = New System.Windows.Forms.TextBox()
        Me.lblTotalEtiqueta = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblAmarres = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Activo = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.txtTallaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTallaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTallaCentral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(840, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label2)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(640, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(200, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(53, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Corridas"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(132, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 384)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(840, 54)
        Me.pnlEstado.TabIndex = 0
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(640, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(200, 54)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(149, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 10
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(150, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(92, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 8
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(97, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtTallaInicio
        '
        Me.txtTallaInicio.DecimalPlaces = 1
        Me.txtTallaInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtTallaInicio.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtTallaInicio.Location = New System.Drawing.Point(391, 47)
        Me.txtTallaInicio.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtTallaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtTallaInicio.Name = "txtTallaInicio"
        Me.txtTallaInicio.Size = New System.Drawing.Size(61, 20)
        Me.txtTallaInicio.TabIndex = 1
        Me.txtTallaInicio.ThousandsSeparator = True
        Me.txtTallaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblTallaInicio
        '
        Me.lblTallaInicio.AutoSize = True
        Me.lblTallaInicio.Location = New System.Drawing.Point(320, 55)
        Me.lblTallaInicio.Name = "lblTallaInicio"
        Me.lblTallaInicio.Size = New System.Drawing.Size(65, 13)
        Me.lblTallaInicio.TabIndex = 5
        Me.lblTallaInicio.Text = "* Talla Inicio"
        '
        'txtTallaFin
        '
        Me.txtTallaFin.DecimalPlaces = 1
        Me.txtTallaFin.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtTallaFin.Location = New System.Drawing.Point(391, 79)
        Me.txtTallaFin.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtTallaFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtTallaFin.Name = "txtTallaFin"
        Me.txtTallaFin.Size = New System.Drawing.Size(61, 20)
        Me.txtTallaFin.TabIndex = 2
        Me.txtTallaFin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblTallaFin
        '
        Me.lblTallaFin.AutoSize = True
        Me.lblTallaFin.Location = New System.Drawing.Point(331, 81)
        Me.lblTallaFin.Name = "lblTallaFin"
        Me.lblTallaFin.Size = New System.Drawing.Size(54, 13)
        Me.lblTallaFin.TabIndex = 8
        Me.lblTallaFin.Text = "* Talla Fin"
        '
        'chkEntero
        '
        Me.chkEntero.AutoSize = True
        Me.chkEntero.Location = New System.Drawing.Point(711, 82)
        Me.chkEntero.Name = "chkEntero"
        Me.chkEntero.Size = New System.Drawing.Size(86, 17)
        Me.chkEntero.TabIndex = 8
        Me.chkEntero.Text = "Solo Enteros"
        Me.chkEntero.UseVisualStyleBackColor = True
        '
        'lblTallaCentral
        '
        Me.lblTallaCentral.AutoSize = True
        Me.lblTallaCentral.Location = New System.Drawing.Point(312, 107)
        Me.lblTallaCentral.Name = "lblTallaCentral"
        Me.lblTallaCentral.Size = New System.Drawing.Size(73, 13)
        Me.lblTallaCentral.TabIndex = 10
        Me.lblTallaCentral.Text = "* Talla Central"
        '
        'txtTallaCentral
        '
        Me.txtTallaCentral.DecimalPlaces = 1
        Me.txtTallaCentral.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtTallaCentral.Location = New System.Drawing.Point(391, 108)
        Me.txtTallaCentral.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtTallaCentral.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtTallaCentral.Name = "txtTallaCentral"
        Me.txtTallaCentral.Size = New System.Drawing.Size(61, 20)
        Me.txtTallaCentral.TabIndex = 3
        Me.txtTallaCentral.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbTallaPrincipal
        '
        Me.cmbTallaPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTallaPrincipal.FormattingEnabled = True
        Me.cmbTallaPrincipal.Location = New System.Drawing.Point(331, 13)
        Me.cmbTallaPrincipal.Name = "cmbTallaPrincipal"
        Me.cmbTallaPrincipal.Size = New System.Drawing.Size(173, 21)
        Me.cmbTallaPrincipal.TabIndex = 6
        '
        'cmbPaises
        '
        Me.cmbPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaises.FormattingEnabled = True
        Me.cmbPaises.Location = New System.Drawing.Point(75, 13)
        Me.cmbPaises.Name = "cmbPaises"
        Me.cmbPaises.Size = New System.Drawing.Size(173, 21)
        Me.cmbPaises.TabIndex = 5
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(27, 16)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(36, 13)
        Me.lblPais.TabIndex = 14
        Me.lblPais.Text = "* País"
        '
        'lblTallaPrincipal
        '
        Me.lblTallaPrincipal.AutoSize = True
        Me.lblTallaPrincipal.Location = New System.Drawing.Point(268, 16)
        Me.lblTallaPrincipal.Name = "lblTallaPrincipal"
        Me.lblTallaPrincipal.Size = New System.Drawing.Size(57, 13)
        Me.lblTallaPrincipal.TabIndex = 15
        Me.lblTallaPrincipal.Text = "Talla Base"
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(552, 89)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(43, 13)
        Me.lblGrupo.TabIndex = 16
        Me.lblGrupo.Text = "* Grupo"
        Me.lblGrupo.Visible = False
        '
        'txtGrupo
        '
        Me.txtGrupo.Location = New System.Drawing.Point(602, 82)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(79, 20)
        Me.txtGrupo.TabIndex = 17
        Me.txtGrupo.Visible = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(571, 52)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 10
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(611, 52)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 11
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'ckbMedias
        '
        Me.ckbMedias.AutoSize = True
        Me.ckbMedias.Location = New System.Drawing.Point(711, 105)
        Me.ckbMedias.Name = "ckbMedias"
        Me.ckbMedias.Size = New System.Drawing.Size(105, 17)
        Me.ckbMedias.TabIndex = 9
        Me.ckbMedias.Text = "Registrar Medias"
        Me.ckbMedias.UseVisualStyleBackColor = True
        '
        'grdTablaAmarre
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmarre.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTablaAmarre.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmarre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmarre.Location = New System.Drawing.Point(0, 219)
        Me.grdTablaAmarre.Name = "grdTablaAmarre"
        Me.grdTablaAmarre.RowHeadersWidth = 100
        Me.grdTablaAmarre.Size = New System.Drawing.Size(840, 139)
        Me.grdTablaAmarre.TabIndex = 0
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(6, 54)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 26
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(75, 49)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(176, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'lblCodSicy
        '
        Me.lblCodSicy.AutoSize = True
        Me.lblCodSicy.Location = New System.Drawing.Point(528, 24)
        Me.lblCodSicy.Name = "lblCodSicy"
        Me.lblCodSicy.Size = New System.Drawing.Size(67, 13)
        Me.lblCodSicy.TabIndex = 27
        Me.lblCodSicy.Text = "Código SICY"
        '
        'txtCodSicy
        '
        Me.txtCodSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodSicy.Enabled = False
        Me.txtCodSicy.Location = New System.Drawing.Point(602, 20)
        Me.txtCodSicy.Name = "txtCodSicy"
        Me.txtCodSicy.Size = New System.Drawing.Size(97, 20)
        Me.txtCodSicy.TabIndex = 7
        '
        'lblTotalEtiqueta
        '
        Me.lblTotalEtiqueta.AutoSize = True
        Me.lblTotalEtiqueta.Location = New System.Drawing.Point(740, 366)
        Me.lblTotalEtiqueta.Name = "lblTotalEtiqueta"
        Me.lblTotalEtiqueta.Size = New System.Drawing.Size(60, 13)
        Me.lblTotalEtiqueta.TabIndex = 28
        Me.lblTotalEtiqueta.Text = "Total pares"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalPares.Location = New System.Drawing.Point(807, 366)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 29
        Me.lblTotalPares.Text = "0"
        '
        'lblAmarres
        '
        Me.lblAmarres.AutoSize = True
        Me.lblAmarres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmarres.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAmarres.Location = New System.Drawing.Point(9, 200)
        Me.lblAmarres.Name = "lblAmarres"
        Me.lblAmarres.Size = New System.Drawing.Size(65, 16)
        Me.lblAmarres.TabIndex = 30
        Me.lblAmarres.Text = "Amarres"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Activo)
        Me.GroupBox1.Controls.Add(Me.lblTallaFin)
        Me.GroupBox1.Controls.Add(Me.txtTallaInicio)
        Me.GroupBox1.Controls.Add(Me.txtCodSicy)
        Me.GroupBox1.Controls.Add(Me.txtTallaCentral)
        Me.GroupBox1.Controls.Add(Me.ckbMedias)
        Me.GroupBox1.Controls.Add(Me.lblTallaInicio)
        Me.GroupBox1.Controls.Add(Me.chkEntero)
        Me.GroupBox1.Controls.Add(Me.txtTallaFin)
        Me.GroupBox1.Controls.Add(Me.lblCodSicy)
        Me.GroupBox1.Controls.Add(Me.lblTallaCentral)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.rdoInactivo)
        Me.GroupBox1.Controls.Add(Me.rdoActivo)
        Me.GroupBox1.Controls.Add(Me.lblTallaPrincipal)
        Me.GroupBox1.Controls.Add(Me.lblPais)
        Me.GroupBox1.Controls.Add(Me.cmbPaises)
        Me.GroupBox1.Controls.Add(Me.cmbTallaPrincipal)
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Controls.Add(Me.lblGrupo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(816, 128)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'Activo
        '
        Me.Activo.AutoSize = True
        Me.Activo.Location = New System.Drawing.Point(528, 54)
        Me.Activo.Name = "Activo"
        Me.Activo.Size = New System.Drawing.Size(37, 13)
        Me.Activo.TabIndex = 28
        Me.Activo.Text = "Activo"
        '
        'AltaTallasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(840, 438)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTotalPares)
        Me.Controls.Add(Me.lblAmarres)
        Me.Controls.Add(Me.lblTotalEtiqueta)
        Me.Controls.Add(Me.grdTablaAmarre)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(856, 477)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(856, 477)
        Me.Name = "AltaTallasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corridas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.txtTallaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTallaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTallaCentral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents txtTallaInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTallaInicio As System.Windows.Forms.Label
    Friend WithEvents txtTallaFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblTallaFin As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents chkEntero As System.Windows.Forms.CheckBox
    Friend WithEvents lblTallaCentral As System.Windows.Forms.Label
    Friend WithEvents txtTallaCentral As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbTallaPrincipal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaises As System.Windows.Forms.ComboBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents lblTallaPrincipal As System.Windows.Forms.Label
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents ckbMedias As System.Windows.Forms.CheckBox
    Friend WithEvents grdTablaAmarre As System.Windows.Forms.DataGridView
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSicy As System.Windows.Forms.Label
    Friend WithEvents txtCodSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalEtiqueta As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblAmarres As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Activo As System.Windows.Forms.Label
End Class
