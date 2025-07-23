<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoTablasSubsidioEmpleoForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoTablasSubsidioEmpleoForm))
        Me.grdTablaSPE = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlDesactivar = New System.Windows.Forms.Panel()
        Me.btndesactivar = New System.Windows.Forms.Button()
        Me.lblDesactivar = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        CType(Me.grdTablaSPE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlDesactivar.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAltas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdTablaSPE
        '
        Me.grdTablaSPE.CausesValidation = False
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaSPE.DisplayLayout.Appearance = Appearance1
        Me.grdTablaSPE.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdTablaSPE.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTablaSPE.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTablaSPE.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTablaSPE.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTablaSPE.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTablaSPE.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTablaSPE.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTablaSPE.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTablaSPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTablaSPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTablaSPE.Location = New System.Drawing.Point(0, 180)
        Me.grdTablaSPE.Name = "grdTablaSPE"
        Me.grdTablaSPE.Size = New System.Drawing.Size(796, 278)
        Me.grdTablaSPE.TabIndex = 78
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(796, 111)
        Me.pnlFiltros.TabIndex = 77
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(728, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 118
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 121
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(6, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 120
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.cmbTipo)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Panel5)
        Me.grbFiltros.Controls.Add(Me.Panel4)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(790, 86)
        Me.grbFiltros.TabIndex = 113
        Me.grbFiltros.TabStop = False
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColor = System.Drawing.Color.Black
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"SEMANAL", "CATORCENAL", "QUINCENAL", "MENSUAL"})
        Me.cmbTipo.Location = New System.Drawing.Point(72, 29)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(169, 21)
        Me.cmbTipo.TabIndex = 153
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Tipo"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdoActivo)
        Me.Panel5.Controls.Add(Me.rdoInactivo)
        Me.Panel5.Location = New System.Drawing.Point(265, 26)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(133, 29)
        Me.Panel5.TabIndex = 151
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(3, 6)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(55, 17)
        Me.rdoActivo.TabIndex = 86
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Activo"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(64, 6)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rdoInactivo.TabIndex = 85
        Me.rdoInactivo.Text = "Inactivo"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnBuscar)
        Me.Panel4.Controls.Add(Me.lblLimpiar)
        Me.Panel4.Controls.Add(Me.lblBuscar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(688, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(99, 67)
        Me.Panel4.TabIndex = 119
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(59, 10)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(56, 42)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 42)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlDesactivar)
        Me.pnlEncabezado.Controls.Add(Me.pnlEditar)
        Me.pnlEncabezado.Controls.Add(Me.pnlAltas)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(796, 69)
        Me.pnlEncabezado.TabIndex = 75
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(196, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(66, 69)
        Me.pnlExportar.TabIndex = 113
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(16, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 10
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(10, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 8
        Me.lblExportar.Text = "Exportar"
        '
        'pnlDesactivar
        '
        Me.pnlDesactivar.Controls.Add(Me.btndesactivar)
        Me.pnlDesactivar.Controls.Add(Me.lblDesactivar)
        Me.pnlDesactivar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDesactivar.Location = New System.Drawing.Point(125, 0)
        Me.pnlDesactivar.Name = "pnlDesactivar"
        Me.pnlDesactivar.Size = New System.Drawing.Size(71, 69)
        Me.pnlDesactivar.TabIndex = 112
        '
        'btndesactivar
        '
        Me.btndesactivar.Image = Global.Contabilidad.Vista.My.Resources.Resources.cancelar_32
        Me.btndesactivar.Location = New System.Drawing.Point(20, 7)
        Me.btndesactivar.Name = "btndesactivar"
        Me.btndesactivar.Size = New System.Drawing.Size(31, 32)
        Me.btndesactivar.TabIndex = 42
        Me.btndesactivar.UseVisualStyleBackColor = True
        '
        'lblDesactivar
        '
        Me.lblDesactivar.AutoSize = True
        Me.lblDesactivar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDesactivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDesactivar.Location = New System.Drawing.Point(6, 42)
        Me.lblDesactivar.Name = "lblDesactivar"
        Me.lblDesactivar.Size = New System.Drawing.Size(58, 13)
        Me.lblDesactivar.TabIndex = 23
        Me.lblDesactivar.Text = "Desactivar"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(66, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(59, 69)
        Me.pnlEditar.TabIndex = 110
        '
        'btnEditar
        '
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(13, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(12, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 23
        Me.lblEditar.Text = "Editar"
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.btnAltas)
        Me.pnlAltas.Controls.Add(Me.lblNuevo)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(66, 69)
        Me.pnlAltas.TabIndex = 109
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(20, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(20, 42)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Altas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(465, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 69)
        Me.Panel1.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(263, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(25, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(220, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Tablas Subsidio al Empleo"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 458)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(796, 60)
        Me.pnlPie.TabIndex = 76
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(728, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(68, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(17, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(16, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 29
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEstado
        '
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1138, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'UltraGridExcelExporter1
        '
        '
        'CatalogoTablasSubsidioEmpleoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 518)
        Me.Controls.Add(Me.grdTablaSPE)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "CatalogoTablasSubsidioEmpleoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tablas Subsidio al Empleo"
        CType(Me.grdTablaSPE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlDesactivar.ResumeLayout(False)
        Me.pnlDesactivar.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAltas.ResumeLayout(False)
        Me.pnlAltas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdTablaSPE As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents rdoActivo As Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As Windows.Forms.RadioButton
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents lblBuscar As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlDesactivar As Windows.Forms.Panel
    Friend WithEvents btndesactivar As Windows.Forms.Button
    Friend WithEvents lblDesactivar As Windows.Forms.Label
    Friend WithEvents pnlEditar As Windows.Forms.Panel
    Friend WithEvents btnEditar As Windows.Forms.Button
    Friend WithEvents lblEditar As Windows.Forms.Label
    Friend WithEvents pnlAltas As Windows.Forms.Panel
    Friend WithEvents btnAltas As Windows.Forms.Button
    Friend WithEvents lblNuevo As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
