<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarTallaForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.grdTallas = New System.Windows.Forms.DataGridView()
        Me.chkEnterosGrid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtInicio = New System.Windows.Forms.NumericUpDown()
        Me.txtFin = New System.Windows.Forms.NumericUpDown()
        Me.txtCentral = New System.Windows.Forms.NumericUpDown()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.lblCentral = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cmbTallaPrincipal = New System.Windows.Forms.ComboBox()
        Me.cmbTallaSuperior = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.cmbPaises = New System.Windows.Forms.ComboBox()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckbMedias = New System.Windows.Forms.CheckBox()
        Me.txtCodSicy = New System.Windows.Forms.TextBox()
        Me.lblCodSicy = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.chkEnteros = New System.Windows.Forms.CheckBox()
        Me.pnlBotonActualizar = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.pnlActualizar = New System.Windows.Forms.Panel()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblAmarre = New System.Windows.Forms.Label()
        Me.lblTotalEtiqueta = New System.Windows.Forms.Label()
        Me.grdTablaAmarre = New System.Windows.Forms.DataGridView()
        Me.grdTallaInicial = New System.Windows.Forms.DataGridView()
        Me.toolMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCentral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlBotonActualizar.SuspendLayout()
        Me.pnlActualizar.SuspendLayout()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTallaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(891, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(670, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(221, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(74, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(76, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Corridas"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(153, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 442)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(891, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(749, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(142, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(23, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(85, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 2
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(29, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(86, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(522, 41)
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
        Me.rdoInactivo.Location = New System.Drawing.Point(562, 41)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 11
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'grdTallas
        '
        Me.grdTallas.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdTallas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTallas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkEnterosGrid})
        Me.grdTallas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdTallas.Location = New System.Drawing.Point(0, 164)
        Me.grdTallas.Name = "grdTallas"
        Me.grdTallas.ReadOnly = True
        Me.grdTallas.RowHeadersVisible = False
        Me.grdTallas.RowHeadersWidth = 5
        Me.grdTallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdTallas.Size = New System.Drawing.Size(891, 46)
        Me.grdTallas.TabIndex = 11
        '
        'chkEnterosGrid
        '
        Me.chkEnterosGrid.HeaderText = "Enteros"
        Me.chkEnterosGrid.Name = "chkEnterosGrid"
        Me.chkEnterosGrid.ReadOnly = True
        Me.chkEnterosGrid.Width = 50
        '
        'txtInicio
        '
        Me.txtInicio.DecimalPlaces = 1
        Me.txtInicio.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtInicio.Location = New System.Drawing.Point(120, 16)
        Me.txtInicio.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(61, 20)
        Me.txtInicio.TabIndex = 1
        Me.txtInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtFin
        '
        Me.txtFin.DecimalPlaces = 1
        Me.txtFin.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtFin.Location = New System.Drawing.Point(120, 42)
        Me.txtFin.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(61, 20)
        Me.txtFin.TabIndex = 2
        Me.txtFin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtCentral
        '
        Me.txtCentral.DecimalPlaces = 1
        Me.txtCentral.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtCentral.Location = New System.Drawing.Point(120, 68)
        Me.txtCentral.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtCentral.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCentral.Name = "txtCentral"
        Me.txtCentral.Size = New System.Drawing.Size(61, 20)
        Me.txtCentral.TabIndex = 3
        Me.txtCentral.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Location = New System.Drawing.Point(42, 17)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(65, 13)
        Me.lblInicio.TabIndex = 8
        Me.lblInicio.Text = "* Talla Inicio"
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Location = New System.Drawing.Point(53, 45)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(54, 13)
        Me.lblFin.TabIndex = 9
        Me.lblFin.Text = "* Talla Fin"
        '
        'lblCentral
        '
        Me.lblCentral.AutoSize = True
        Me.lblCentral.Location = New System.Drawing.Point(34, 71)
        Me.lblCentral.Name = "lblCentral"
        Me.lblCentral.Size = New System.Drawing.Size(73, 13)
        Me.lblCentral.TabIndex = 10
        Me.lblCentral.Text = "* Talla Central"
        '
        'txtGrupo
        '
        Me.txtGrupo.Location = New System.Drawing.Point(522, 68)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(120, 20)
        Me.txtGrupo.TabIndex = 11
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(238, 21)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupo.TabIndex = 12
        Me.lblGrupo.Text = "Grupo"
        '
        'cmbTallaPrincipal
        '
        Me.cmbTallaPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTallaPrincipal.FormattingEnabled = True
        Me.cmbTallaPrincipal.Location = New System.Drawing.Point(279, 67)
        Me.cmbTallaPrincipal.Name = "cmbTallaPrincipal"
        Me.cmbTallaPrincipal.Size = New System.Drawing.Size(146, 21)
        Me.cmbTallaPrincipal.TabIndex = 6
        '
        'cmbTallaSuperior
        '
        Me.cmbTallaSuperior.AutoSize = True
        Me.cmbTallaSuperior.Location = New System.Drawing.Point(218, 73)
        Me.cmbTallaSuperior.Name = "cmbTallaSuperior"
        Me.cmbTallaSuperior.Size = New System.Drawing.Size(56, 13)
        Me.cmbTallaSuperior.TabIndex = 16
        Me.cmbTallaSuperior.Text = "Talla base"
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(238, 47)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(36, 13)
        Me.lblPais.TabIndex = 17
        Me.lblPais.Text = "* País"
        '
        'cmbPaises
        '
        Me.cmbPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaises.FormattingEnabled = True
        Me.cmbPaises.Location = New System.Drawing.Point(279, 41)
        Me.cmbPaises.Name = "cmbPaises"
        Me.cmbPaises.Size = New System.Drawing.Size(146, 21)
        Me.cmbPaises.TabIndex = 5
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.GroupBox1)
        Me.pnlDatos.Controls.Add(Me.pnlBotonActualizar)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(891, 104)
        Me.pnlDatos.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ckbMedias)
        Me.GroupBox1.Controls.Add(Me.txtCentral)
        Me.GroupBox1.Controls.Add(Me.lblCentral)
        Me.GroupBox1.Controls.Add(Me.txtCodSicy)
        Me.GroupBox1.Controls.Add(Me.lblCodSicy)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.chkEnteros)
        Me.GroupBox1.Controls.Add(Me.cmbPaises)
        Me.GroupBox1.Controls.Add(Me.rdoActivo)
        Me.GroupBox1.Controls.Add(Me.lblPais)
        Me.GroupBox1.Controls.Add(Me.rdoInactivo)
        Me.GroupBox1.Controls.Add(Me.cmbTallaSuperior)
        Me.GroupBox1.Controls.Add(Me.txtInicio)
        Me.GroupBox1.Controls.Add(Me.cmbTallaPrincipal)
        Me.GroupBox1.Controls.Add(Me.txtFin)
        Me.GroupBox1.Controls.Add(Me.lblInicio)
        Me.GroupBox1.Controls.Add(Me.lblFin)
        Me.GroupBox1.Controls.Add(Me.lblGrupo)
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 98)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(478, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Activo"
        '
        'ckbMedias
        '
        Me.ckbMedias.AutoSize = True
        Me.ckbMedias.Location = New System.Drawing.Point(658, 43)
        Me.ckbMedias.Name = "ckbMedias"
        Me.ckbMedias.Size = New System.Drawing.Size(104, 17)
        Me.ckbMedias.TabIndex = 9
        Me.ckbMedias.Text = "Registrar medias"
        Me.ckbMedias.UseVisualStyleBackColor = True
        '
        'txtCodSicy
        '
        Me.txtCodSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodSicy.Location = New System.Drawing.Point(522, 16)
        Me.txtCodSicy.Name = "txtCodSicy"
        Me.txtCodSicy.Size = New System.Drawing.Size(100, 20)
        Me.txtCodSicy.TabIndex = 7
        '
        'lblCodSicy
        '
        Me.lblCodSicy.AutoSize = True
        Me.lblCodSicy.Location = New System.Drawing.Point(448, 19)
        Me.lblCodSicy.Name = "lblCodSicy"
        Me.lblCodSicy.Size = New System.Drawing.Size(67, 13)
        Me.lblCodSicy.TabIndex = 29
        Me.lblCodSicy.Text = "Código SICY"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(211, 21)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 24
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(279, 14)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(146, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'chkEnteros
        '
        Me.chkEnteros.AutoSize = True
        Me.chkEnteros.Location = New System.Drawing.Point(658, 17)
        Me.chkEnteros.Name = "chkEnteros"
        Me.chkEnteros.Size = New System.Drawing.Size(85, 17)
        Me.chkEnteros.TabIndex = 8
        Me.chkEnteros.Text = "Solo enteros"
        Me.chkEnteros.UseVisualStyleBackColor = True
        '
        'pnlBotonActualizar
        '
        Me.pnlBotonActualizar.Controls.Add(Me.btnActualizar)
        Me.pnlBotonActualizar.Controls.Add(Me.lblActualizar)
        Me.pnlBotonActualizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonActualizar.Location = New System.Drawing.Point(816, 0)
        Me.pnlBotonActualizar.Name = "pnlBotonActualizar"
        Me.pnlBotonActualizar.Size = New System.Drawing.Size(75, 104)
        Me.pnlBotonActualizar.TabIndex = 22
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Programacion.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizar.Location = New System.Drawing.Point(19, 22)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 10
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(11, 57)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(53, 13)
        Me.lblActualizar.TabIndex = 21
        Me.lblActualizar.Text = "Actualizar"
        '
        'pnlActualizar
        '
        Me.pnlActualizar.Controls.Add(Me.lblTotalPares)
        Me.pnlActualizar.Controls.Add(Me.lblAmarre)
        Me.pnlActualizar.Controls.Add(Me.lblTotalEtiqueta)
        Me.pnlActualizar.Controls.Add(Me.grdTablaAmarre)
        Me.pnlActualizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActualizar.Location = New System.Drawing.Point(0, 256)
        Me.pnlActualizar.Name = "pnlActualizar"
        Me.pnlActualizar.Size = New System.Drawing.Size(891, 186)
        Me.pnlActualizar.TabIndex = 22
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalPares.Location = New System.Drawing.Point(862, 24)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 31
        Me.lblTotalPares.Text = "0"
        '
        'lblAmarre
        '
        Me.lblAmarre.AutoSize = True
        Me.lblAmarre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmarre.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAmarre.Location = New System.Drawing.Point(3, 20)
        Me.lblAmarre.Name = "lblAmarre"
        Me.lblAmarre.Size = New System.Drawing.Size(76, 20)
        Me.lblAmarre.TabIndex = 23
        Me.lblAmarre.Text = "Amarres"
        '
        'lblTotalEtiqueta
        '
        Me.lblTotalEtiqueta.AutoSize = True
        Me.lblTotalEtiqueta.Location = New System.Drawing.Point(795, 24)
        Me.lblTotalEtiqueta.Name = "lblTotalEtiqueta"
        Me.lblTotalEtiqueta.Size = New System.Drawing.Size(60, 13)
        Me.lblTotalEtiqueta.TabIndex = 30
        Me.lblTotalEtiqueta.Text = "Total pares"
        '
        'grdTablaAmarre
        '
        Me.grdTablaAmarre.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmarre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTablaAmarre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmarre.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdTablaAmarre.Location = New System.Drawing.Point(0, 38)
        Me.grdTablaAmarre.Name = "grdTablaAmarre"
        Me.grdTablaAmarre.RowHeadersWidth = 100
        Me.grdTablaAmarre.Size = New System.Drawing.Size(891, 148)
        Me.grdTablaAmarre.TabIndex = 13
        '
        'grdTallaInicial
        '
        Me.grdTallaInicial.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdTallaInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTallaInicial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTallaInicial.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdTallaInicial.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdTallaInicial.Enabled = False
        Me.grdTallaInicial.Location = New System.Drawing.Point(0, 210)
        Me.grdTallaInicial.Name = "grdTallaInicial"
        Me.grdTallaInicial.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTallaInicial.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdTallaInicial.RowHeadersVisible = False
        Me.grdTallaInicial.RowHeadersWidth = 5
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTallaInicial.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdTallaInicial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdTallaInicial.Size = New System.Drawing.Size(891, 46)
        Me.grdTallaInicial.TabIndex = 12
        '
        'EditarTallaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(891, 502)
        Me.Controls.Add(Me.pnlActualizar)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grdTallaInicial)
        Me.Controls.Add(Me.grdTallas)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(907, 541)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(907, 541)
        Me.Name = "EditarTallaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corridas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCentral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlBotonActualizar.ResumeLayout(False)
        Me.pnlBotonActualizar.PerformLayout()
        Me.pnlActualizar.ResumeLayout(False)
        Me.pnlActualizar.PerformLayout()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTallaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents grdTallas As System.Windows.Forms.DataGridView
    Friend WithEvents txtFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtCentral As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents lblCentral As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents cmbTallaPrincipal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTallaSuperior As System.Windows.Forms.Label
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents cmbPaises As System.Windows.Forms.ComboBox
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents chkEnterosGrid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkEnteros As System.Windows.Forms.CheckBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents pnlActualizar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonActualizar As System.Windows.Forms.Panel
    Friend WithEvents grdTallaInicial As System.Windows.Forms.DataGridView
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSicy As System.Windows.Forms.Label
    Friend WithEvents grdTablaAmarre As System.Windows.Forms.DataGridView
    Friend WithEvents ckbMedias As System.Windows.Forms.CheckBox
    Friend WithEvents lblAmarre As System.Windows.Forms.Label
    Friend WithEvents toolMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents txtInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblTotalEtiqueta As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
