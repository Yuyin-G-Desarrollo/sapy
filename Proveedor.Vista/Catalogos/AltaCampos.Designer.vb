<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCampos
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCampos))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbGiro = New System.Windows.Forms.ComboBox()
        Me.lblGiro = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdTamano = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdColor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdboInactivo = New System.Windows.Forms.RadioButton()
        Me.rdboActivo = New System.Windows.Forms.RadioButton()
        Me.txtSicy = New System.Windows.Forms.TextBox()
        Me.lblsicy = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblCatego = New System.Windows.Forms.Label()
        Me.gbxDirecto = New System.Windows.Forms.GroupBox()
        Me.rdoIndirecto = New System.Windows.Forms.RadioButton()
        Me.rdoDirecto = New System.Windows.Forms.RadioButton()
        Me.lblTamano = New System.Windows.Forms.Label()
        Me.lblClas = New System.Windows.Forms.Label()
        Me.lblUm = New System.Windows.Forms.Label()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.lblCat = New System.Windows.Forms.Label()
        Me.grdClasificaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTipoMaterial = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.cmbClasificacion = New System.Windows.Forms.ComboBox()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtsku = New System.Windows.Forms.TextBox()
        Me.lblsku = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdTamano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbxDirecto.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.grdClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(408, 60)
        Me.pnlHeader.TabIndex = 65
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(1, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(407, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(241, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(94, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta/Editar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 501)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 60)
        Me.Panel1.TabIndex = 66
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.Label1)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(162, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(166, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(159, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(205, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(204, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbGiro)
        Me.Panel2.Controls.Add(Me.lblGiro)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtSicy)
        Me.Panel2.Controls.Add(Me.lblsicy)
        Me.Panel2.Controls.Add(Me.txtId)
        Me.Panel2.Controls.Add(Me.lblID)
        Me.Panel2.Controls.Add(Me.lblCatego)
        Me.Panel2.Controls.Add(Me.gbxDirecto)
        Me.Panel2.Controls.Add(Me.lblTamano)
        Me.Panel2.Controls.Add(Me.lblClas)
        Me.Panel2.Controls.Add(Me.lblUm)
        Me.Panel2.Controls.Add(Me.pnlGrid)
        Me.Panel2.Controls.Add(Me.lblTipoMaterial)
        Me.Panel2.Controls.Add(Me.lblDescripcion)
        Me.Panel2.Controls.Add(Me.cmbClasificacion)
        Me.Panel2.Controls.Add(Me.lblClasificacion)
        Me.Panel2.Controls.Add(Me.cmbCategoria)
        Me.Panel2.Controls.Add(Me.lblColor)
        Me.Panel2.Controls.Add(Me.lblCategoria)
        Me.Panel2.Controls.Add(Me.txtsku)
        Me.Panel2.Controls.Add(Me.lblsku)
        Me.Panel2.Controls.Add(Me.txtDescripcion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(408, 441)
        Me.Panel2.TabIndex = 67
        '
        'cmbGiro
        '
        Me.cmbGiro.FormattingEnabled = True
        Me.cmbGiro.Location = New System.Drawing.Point(84, 100)
        Me.cmbGiro.Name = "cmbGiro"
        Me.cmbGiro.Size = New System.Drawing.Size(306, 21)
        Me.cmbGiro.TabIndex = 71
        Me.cmbGiro.Visible = False
        '
        'lblGiro
        '
        Me.lblGiro.AutoSize = True
        Me.lblGiro.Location = New System.Drawing.Point(56, 104)
        Me.lblGiro.Name = "lblGiro"
        Me.lblGiro.Size = New System.Drawing.Size(26, 13)
        Me.lblGiro.TabIndex = 70
        Me.lblGiro.Text = "Giro"
        Me.lblGiro.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.grdTamano)
        Me.Panel3.Controls.Add(Me.grdColor)
        Me.Panel3.Location = New System.Drawing.Point(3, 201)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(405, 234)
        Me.Panel3.TabIndex = 69
        Me.Panel3.Visible = False
        '
        'grdTamano
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTamano.DisplayLayout.Appearance = Appearance1
        Me.grdTamano.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTamano.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTamano.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTamano.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTamano.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTamano.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdTamano.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTamano.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdTamano.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdTamano.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTamano.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdTamano.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTamano.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdTamano.Location = New System.Drawing.Point(0, 0)
        Me.grdTamano.Name = "grdTamano"
        Me.grdTamano.Size = New System.Drawing.Size(198, 234)
        Me.grdTamano.TabIndex = 69
        Me.grdTamano.Visible = False
        '
        'grdColor
        '
        Me.grdColor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColor.DisplayLayout.Appearance = Appearance4
        Me.grdColor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColor.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdColor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColor.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdColor.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdColor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColor.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdColor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColor.Location = New System.Drawing.Point(206, 0)
        Me.grdColor.Name = "grdColor"
        Me.grdColor.Size = New System.Drawing.Size(196, 234)
        Me.grdColor.TabIndex = 70
        Me.grdColor.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdboInactivo)
        Me.GroupBox1.Controls.Add(Me.rdboActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(99, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 31)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Activo"
        '
        'rdboInactivo
        '
        Me.rdboInactivo.AutoSize = True
        Me.rdboInactivo.Location = New System.Drawing.Point(55, 11)
        Me.rdboInactivo.Name = "rdboInactivo"
        Me.rdboInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdboInactivo.TabIndex = 22
        Me.rdboInactivo.TabStop = True
        Me.rdboInactivo.Text = "No"
        Me.rdboInactivo.UseVisualStyleBackColor = True
        '
        'rdboActivo
        '
        Me.rdboActivo.AutoSize = True
        Me.rdboActivo.Checked = True
        Me.rdboActivo.Location = New System.Drawing.Point(7, 11)
        Me.rdboActivo.Name = "rdboActivo"
        Me.rdboActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdboActivo.TabIndex = 21
        Me.rdboActivo.TabStop = True
        Me.rdboActivo.Text = "Si"
        Me.rdboActivo.UseVisualStyleBackColor = True
        '
        'txtSicy
        '
        Me.txtSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSicy.Location = New System.Drawing.Point(224, 42)
        Me.txtSicy.MaxLength = 6
        Me.txtSicy.Name = "txtSicy"
        Me.txtSicy.Size = New System.Drawing.Size(49, 20)
        Me.txtSicy.TabIndex = 28
        '
        'lblsicy
        '
        Me.lblsicy.AutoSize = True
        Me.lblsicy.BackColor = System.Drawing.Color.Transparent
        Me.lblsicy.Location = New System.Drawing.Point(177, 46)
        Me.lblsicy.Name = "lblsicy"
        Me.lblsicy.Size = New System.Drawing.Size(45, 13)
        Me.lblsicy.TabIndex = 29
        Me.lblsicy.Text = "ID-SICY"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(86, 42)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(49, 20)
        Me.txtId.TabIndex = 19
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(64, 46)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 25
        Me.lblID.Text = "ID"
        '
        'lblCatego
        '
        Me.lblCatego.AutoSize = True
        Me.lblCatego.Location = New System.Drawing.Point(28, 74)
        Me.lblCatego.Name = "lblCatego"
        Me.lblCatego.Size = New System.Drawing.Size(54, 13)
        Me.lblCatego.TabIndex = 38
        Me.lblCatego.Text = "Categoría"
        Me.lblCatego.Visible = False
        '
        'gbxDirecto
        '
        Me.gbxDirecto.Controls.Add(Me.rdoIndirecto)
        Me.gbxDirecto.Controls.Add(Me.rdoDirecto)
        Me.gbxDirecto.Location = New System.Drawing.Point(205, 5)
        Me.gbxDirecto.Name = "gbxDirecto"
        Me.gbxDirecto.Size = New System.Drawing.Size(139, 31)
        Me.gbxDirecto.TabIndex = 37
        Me.gbxDirecto.TabStop = False
        Me.gbxDirecto.Text = "Directo"
        Me.gbxDirecto.Visible = False
        '
        'rdoIndirecto
        '
        Me.rdoIndirecto.AutoSize = True
        Me.rdoIndirecto.Location = New System.Drawing.Point(68, 11)
        Me.rdoIndirecto.Name = "rdoIndirecto"
        Me.rdoIndirecto.Size = New System.Drawing.Size(66, 17)
        Me.rdoIndirecto.TabIndex = 39
        Me.rdoIndirecto.TabStop = True
        Me.rdoIndirecto.Text = "Indirecto"
        Me.rdoIndirecto.UseVisualStyleBackColor = True
        '
        'rdoDirecto
        '
        Me.rdoDirecto.AutoSize = True
        Me.rdoDirecto.Checked = True
        Me.rdoDirecto.Location = New System.Drawing.Point(9, 11)
        Me.rdoDirecto.Name = "rdoDirecto"
        Me.rdoDirecto.Size = New System.Drawing.Size(59, 17)
        Me.rdoDirecto.TabIndex = 38
        Me.rdoDirecto.TabStop = True
        Me.rdoDirecto.Text = "Directo"
        Me.rdoDirecto.UseVisualStyleBackColor = True
        '
        'lblTamano
        '
        Me.lblTamano.AutoSize = True
        Me.lblTamano.Location = New System.Drawing.Point(36, 74)
        Me.lblTamano.Name = "lblTamano"
        Me.lblTamano.Size = New System.Drawing.Size(46, 13)
        Me.lblTamano.TabIndex = 29
        Me.lblTamano.Text = "Tamaño"
        Me.lblTamano.Visible = False
        '
        'lblClas
        '
        Me.lblClas.AutoSize = True
        Me.lblClas.Location = New System.Drawing.Point(16, 74)
        Me.lblClas.Name = "lblClas"
        Me.lblClas.Size = New System.Drawing.Size(66, 13)
        Me.lblClas.TabIndex = 36
        Me.lblClas.Text = "Clasificación"
        Me.lblClas.Visible = False
        '
        'lblUm
        '
        Me.lblUm.AutoSize = True
        Me.lblUm.Location = New System.Drawing.Point(58, 73)
        Me.lblUm.Name = "lblUm"
        Me.lblUm.Size = New System.Drawing.Size(24, 13)
        Me.lblUm.TabIndex = 28
        Me.lblUm.Text = "UM"
        Me.lblUm.Visible = False
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.lblCat)
        Me.pnlGrid.Controls.Add(Me.grdClasificaciones)
        Me.pnlGrid.Location = New System.Drawing.Point(3, 154)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(404, 281)
        Me.pnlGrid.TabIndex = 34
        Me.pnlGrid.Visible = False
        '
        'lblCat
        '
        Me.lblCat.AutoSize = True
        Me.lblCat.Location = New System.Drawing.Point(18, -26)
        Me.lblCat.Name = "lblCat"
        Me.lblCat.Size = New System.Drawing.Size(54, 13)
        Me.lblCat.TabIndex = 27
        Me.lblCat.Text = "Categoría"
        Me.lblCat.Visible = False
        '
        'grdClasificaciones
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificaciones.DisplayLayout.Appearance = Appearance7
        Me.grdClasificaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificaciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClasificaciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClasificaciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClasificaciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClasificaciones.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdClasificaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificaciones.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.DarkGray
        Me.grdClasificaciones.DisplayLayout.Override.RowAppearance = Appearance9
        Me.grdClasificaciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClasificaciones.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdClasificaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.grdClasificaciones.Name = "grdClasificaciones"
        Me.grdClasificaciones.Size = New System.Drawing.Size(404, 281)
        Me.grdClasificaciones.TabIndex = 68
        '
        'lblTipoMaterial
        '
        Me.lblTipoMaterial.AutoSize = True
        Me.lblTipoMaterial.Location = New System.Drawing.Point(14, 73)
        Me.lblTipoMaterial.Name = "lblTipoMaterial"
        Me.lblTipoMaterial.Size = New System.Drawing.Size(68, 13)
        Me.lblTipoMaterial.TabIndex = 35
        Me.lblTipoMaterial.Text = "Tipo Material"
        Me.lblTipoMaterial.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(19, 74)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 24
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.Visible = False
        '
        'cmbClasificacion
        '
        Me.cmbClasificacion.FormattingEnabled = True
        Me.cmbClasificacion.Location = New System.Drawing.Point(86, 101)
        Me.cmbClasificacion.Name = "cmbClasificacion"
        Me.cmbClasificacion.Size = New System.Drawing.Size(306, 21)
        Me.cmbClasificacion.TabIndex = 33
        '
        'lblClasificacion
        '
        Me.lblClasificacion.AutoSize = True
        Me.lblClasificacion.Location = New System.Drawing.Point(12, 105)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(66, 13)
        Me.lblClasificacion.TabIndex = 32
        Me.lblClasificacion.Text = "Clasificación"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(86, 100)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(306, 21)
        Me.cmbCategoria.TabIndex = 31
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(51, 73)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 25
        Me.lblColor.Text = "Color"
        Me.lblColor.Visible = False
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(26, 108)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoria.TabIndex = 30
        Me.lblCategoria.Text = "Categoria"
        '
        'txtsku
        '
        Me.txtsku.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsku.Location = New System.Drawing.Point(343, 42)
        Me.txtsku.MaxLength = 6
        Me.txtsku.Name = "txtsku"
        Me.txtsku.Size = New System.Drawing.Size(49, 20)
        Me.txtsku.TabIndex = 26
        '
        'lblsku
        '
        Me.lblsku.AutoSize = True
        Me.lblsku.Location = New System.Drawing.Point(311, 45)
        Me.lblsku.Name = "lblsku"
        Me.lblsku.Size = New System.Drawing.Size(29, 13)
        Me.lblsku.TabIndex = 27
        Me.lblsku.Text = "SKU"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(86, 70)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(306, 20)
        Me.txtDescripcion.TabIndex = 20
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(339, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'AltaCampos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(408, 561)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AltaCampos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta/Editar"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdTamano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxDirecto.ResumeLayout(False)
        Me.gbxDirecto.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        CType(Me.grdClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdboInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdboActivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtsku As System.Windows.Forms.TextBox
    Friend WithEvents lblsku As System.Windows.Forms.Label
    Friend WithEvents txtSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblsicy As System.Windows.Forms.Label
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents cmbClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents grdClasificaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblCat As System.Windows.Forms.Label
    Friend WithEvents lblUm As System.Windows.Forms.Label
    Friend WithEvents lblTamano As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lblTipoMaterial As System.Windows.Forms.Label
    Friend WithEvents lblClas As System.Windows.Forms.Label
    Friend WithEvents gbxDirecto As System.Windows.Forms.GroupBox
    Friend WithEvents rdoIndirecto As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDirecto As System.Windows.Forms.RadioButton
    Friend WithEvents lblCatego As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdTamano As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdColor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbGiro As Windows.Forms.ComboBox
    Friend WithEvents lblGiro As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
