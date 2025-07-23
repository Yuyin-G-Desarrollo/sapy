<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoFraccionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoFraccionesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.gbxActivo = New System.Windows.Forms.GroupBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.grdFracciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlFracciones = New System.Windows.Forms.Panel()
        Me.pnlActivo = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbInactivo = New System.Windows.Forms.RadioButton()
        Me.rbActivo = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblFraccion = New System.Windows.Forms.Label()
        Me.txtFraccion = New System.Windows.Forms.TextBox()
        Me.gbxPaga = New System.Windows.Forms.GroupBox()
        Me.rdoNoPaga = New System.Windows.Forms.RadioButton()
        Me.rdoSiPaga = New System.Windows.Forms.RadioButton()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.txtTiempo = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblMaquinaria = New System.Windows.Forms.Label()
        Me.cmbMaquinaria = New System.Windows.Forms.ComboBox()
        Me.txtFracciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIDFraccion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxActivo.SuspendLayout()
        CType(Me.grdFracciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFracciones.SuspendLayout()
        Me.pnlActivo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.gbxPaga.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 469)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(692, 54)
        Me.pnlInferior.TabIndex = 2014
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(581, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 102
        Me.lblGuardar.Text = "Guardar"
        Me.lblGuardar.Visible = False
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(643, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(644, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(587, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAlta)
        Me.pnlEncabezado.Controls.Add(Me.Label3)
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.gbxActivo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(692, 64)
        Me.pnlEncabezado.TabIndex = 2013
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(132, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 244
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(126, 44)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 243
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Produccion.Vista.My.Resources.Resources.editar_322
        Me.btnEditar.Location = New System.Drawing.Point(78, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 234
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(22, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 233
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(34, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Alta"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(-250, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 16)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "VENTANA NO FUNCIONAL"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(87, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Editar"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(422, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(199, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Catálogo de Fracciones"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(624, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 64)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'gbxActivo
        '
        Me.gbxActivo.Controls.Add(Me.rdoNo)
        Me.gbxActivo.Controls.Add(Me.rdoSi)
        Me.gbxActivo.Location = New System.Drawing.Point(364, 153)
        Me.gbxActivo.Name = "gbxActivo"
        Me.gbxActivo.Size = New System.Drawing.Size(91, 35)
        Me.gbxActivo.TabIndex = 2022
        Me.gbxActivo.TabStop = False
        Me.gbxActivo.Text = "Activo"
        Me.gbxActivo.Visible = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(46, 14)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 9
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(6, 14)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 8
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'grdFracciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFracciones.DisplayLayout.Appearance = Appearance1
        Me.grdFracciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFracciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFracciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFracciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFracciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFracciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFracciones.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdFracciones.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdFracciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFracciones.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdFracciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFracciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdFracciones.Location = New System.Drawing.Point(0, 70)
        Me.grdFracciones.Name = "grdFracciones"
        Me.grdFracciones.Size = New System.Drawing.Size(692, 335)
        Me.grdFracciones.TabIndex = 2015
        '
        'pnlFracciones
        '
        Me.pnlFracciones.Controls.Add(Me.pnlActivo)
        Me.pnlFracciones.Controls.Add(Me.grdFracciones)
        Me.pnlFracciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFracciones.Location = New System.Drawing.Point(0, 64)
        Me.pnlFracciones.Name = "pnlFracciones"
        Me.pnlFracciones.Size = New System.Drawing.Size(692, 405)
        Me.pnlFracciones.TabIndex = 2016
        '
        'pnlActivo
        '
        Me.pnlActivo.Controls.Add(Me.GroupBox2)
        Me.pnlActivo.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlActivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActivo.Location = New System.Drawing.Point(0, 0)
        Me.pnlActivo.Name = "pnlActivo"
        Me.pnlActivo.Size = New System.Drawing.Size(692, 56)
        Me.pnlActivo.TabIndex = 2016
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbInactivo)
        Me.GroupBox2.Controls.Add(Me.rbActivo)
        Me.GroupBox2.Controls.Add(Me.lblActivo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(540, 46)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(134, 18)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 3
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbInactivo
        '
        Me.rbInactivo.AutoSize = True
        Me.rbInactivo.Location = New System.Drawing.Point(89, 18)
        Me.rbInactivo.Name = "rbInactivo"
        Me.rbInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rbInactivo.TabIndex = 2
        Me.rbInactivo.Text = "No"
        Me.rbInactivo.UseVisualStyleBackColor = True
        '
        'rbActivo
        '
        Me.rbActivo.AutoSize = True
        Me.rbActivo.Checked = True
        Me.rbActivo.Location = New System.Drawing.Point(49, 18)
        Me.rbActivo.Name = "rbActivo"
        Me.rbActivo.Size = New System.Drawing.Size(34, 17)
        Me.rbActivo.TabIndex = 1
        Me.rbActivo.TabStop = True
        Me.rbActivo.Text = "Si"
        Me.rbActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(6, 20)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 0
        Me.lblActivo.Text = "Activo"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.Label6)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label7)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnMostrar)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(566, 0)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(126, 56)
        Me.pnlMinimizarParametros.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(75, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(78, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 181
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(18, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(21, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 165
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(35, 79)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(18, 13)
        Me.lblId.TabIndex = 2024
        Me.lblId.Text = "ID"
        Me.lblId.Visible = False
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(105, 76)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(59, 20)
        Me.txtID.TabIndex = 2023
        Me.txtID.Visible = False
        '
        'lblFraccion
        '
        Me.lblFraccion.AutoSize = True
        Me.lblFraccion.Location = New System.Drawing.Point(35, 107)
        Me.lblFraccion.Name = "lblFraccion"
        Me.lblFraccion.Size = New System.Drawing.Size(48, 13)
        Me.lblFraccion.TabIndex = 2021
        Me.lblFraccion.Text = "Fracción"
        Me.lblFraccion.Visible = False
        '
        'txtFraccion
        '
        Me.txtFraccion.Location = New System.Drawing.Point(105, 104)
        Me.txtFraccion.Name = "txtFraccion"
        Me.txtFraccion.Size = New System.Drawing.Size(227, 20)
        Me.txtFraccion.TabIndex = 2020
        Me.txtFraccion.Visible = False
        '
        'gbxPaga
        '
        Me.gbxPaga.Controls.Add(Me.rdoNoPaga)
        Me.gbxPaga.Controls.Add(Me.rdoSiPaga)
        Me.gbxPaga.Location = New System.Drawing.Point(364, 89)
        Me.gbxPaga.Name = "gbxPaga"
        Me.gbxPaga.Size = New System.Drawing.Size(91, 35)
        Me.gbxPaga.TabIndex = 2023
        Me.gbxPaga.TabStop = False
        Me.gbxPaga.Text = "Paga"
        Me.gbxPaga.Visible = False
        '
        'rdoNoPaga
        '
        Me.rdoNoPaga.AutoSize = True
        Me.rdoNoPaga.Location = New System.Drawing.Point(46, 14)
        Me.rdoNoPaga.Name = "rdoNoPaga"
        Me.rdoNoPaga.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoPaga.TabIndex = 1
        Me.rdoNoPaga.TabStop = True
        Me.rdoNoPaga.Text = "No"
        Me.rdoNoPaga.UseVisualStyleBackColor = True
        '
        'rdoSiPaga
        '
        Me.rdoSiPaga.AutoSize = True
        Me.rdoSiPaga.Location = New System.Drawing.Point(6, 14)
        Me.rdoSiPaga.Name = "rdoSiPaga"
        Me.rdoSiPaga.Size = New System.Drawing.Size(34, 17)
        Me.rdoSiPaga.TabIndex = 0
        Me.rdoSiPaga.TabStop = True
        Me.rdoSiPaga.Text = "Si"
        Me.rdoSiPaga.UseVisualStyleBackColor = True
        '
        'lblTiempo
        '
        Me.lblTiempo.AutoSize = True
        Me.lblTiempo.Location = New System.Drawing.Point(35, 137)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(42, 13)
        Me.lblTiempo.TabIndex = 2026
        Me.lblTiempo.Text = "Tiempo"
        Me.lblTiempo.Visible = False
        '
        'txtTiempo
        '
        Me.txtTiempo.Location = New System.Drawing.Point(105, 134)
        Me.txtTiempo.Name = "txtTiempo"
        Me.txtTiempo.Size = New System.Drawing.Size(81, 20)
        Me.txtTiempo.TabIndex = 3
        Me.txtTiempo.Visible = False
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(208, 137)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 2028
        Me.lblPrecio.Text = "Precio"
        Me.lblPrecio.Visible = False
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(251, 134)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(81, 20)
        Me.txtPrecio.TabIndex = 4
        Me.txtPrecio.Visible = False
        '
        'lblMaquinaria
        '
        Me.lblMaquinaria.AutoSize = True
        Me.lblMaquinaria.Location = New System.Drawing.Point(35, 167)
        Me.lblMaquinaria.Name = "lblMaquinaria"
        Me.lblMaquinaria.Size = New System.Drawing.Size(59, 13)
        Me.lblMaquinaria.TabIndex = 2029
        Me.lblMaquinaria.Text = "Maquinaria"
        Me.lblMaquinaria.Visible = False
        '
        'cmbMaquinaria
        '
        Me.cmbMaquinaria.FormattingEnabled = True
        Me.cmbMaquinaria.Location = New System.Drawing.Point(105, 167)
        Me.cmbMaquinaria.Name = "cmbMaquinaria"
        Me.cmbMaquinaria.Size = New System.Drawing.Size(227, 21)
        Me.cmbMaquinaria.TabIndex = 5
        Me.cmbMaquinaria.Visible = False
        '
        'txtFracciones
        '
        Me.txtFracciones.Location = New System.Drawing.Point(105, 104)
        Me.txtFracciones.Name = "txtFracciones"
        Me.txtFracciones.Size = New System.Drawing.Size(227, 20)
        Me.txtFracciones.TabIndex = 2
        Me.txtFracciones.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2021
        Me.Label1.Text = "Fracción"
        Me.Label1.Visible = False
        '
        'txtIDFraccion
        '
        Me.txtIDFraccion.Enabled = False
        Me.txtIDFraccion.Location = New System.Drawing.Point(105, 76)
        Me.txtIDFraccion.Name = "txtIDFraccion"
        Me.txtIDFraccion.Size = New System.Drawing.Size(59, 20)
        Me.txtIDFraccion.TabIndex = 1
        Me.txtIDFraccion.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 2024
        Me.Label2.Text = "ID"
        Me.Label2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(364, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(91, 35)
        Me.GroupBox1.TabIndex = 2023
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paga"
        Me.GroupBox1.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(46, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.Text = "No"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 14)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(34, 17)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Si"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'CatalogoFraccionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(692, 523)
        Me.Controls.Add(Me.pnlFracciones)
        Me.Controls.Add(Me.cmbMaquinaria)
        Me.Controls.Add(Me.lblMaquinaria)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblTiempo)
        Me.Controls.Add(Me.txtTiempo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbxPaga)
        Me.Controls.Add(Me.txtIDFraccion)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFracciones)
        Me.Controls.Add(Me.lblFraccion)
        Me.Controls.Add(Me.txtFraccion)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(700, 550)
        Me.MinimumSize = New System.Drawing.Size(700, 550)
        Me.Name = "CatalogoFraccionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Fracciones"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxActivo.ResumeLayout(False)
        Me.gbxActivo.PerformLayout()
        CType(Me.grdFracciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFracciones.ResumeLayout(False)
        Me.pnlActivo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.gbxPaga.ResumeLayout(False)
        Me.gbxPaga.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents grdFracciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlFracciones As System.Windows.Forms.Panel
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents gbxActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblFraccion As System.Windows.Forms.Label
    Friend WithEvents txtFraccion As System.Windows.Forms.TextBox
    Friend WithEvents gbxPaga As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoPaga As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSiPaga As System.Windows.Forms.RadioButton
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
    Friend WithEvents txtTiempo As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblMaquinaria As System.Windows.Forms.Label
    Friend WithEvents cmbMaquinaria As System.Windows.Forms.ComboBox
    Friend WithEvents txtFracciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIDFraccion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlActivo As Panel
    Friend WithEvents rbInactivo As RadioButton
    Friend WithEvents rbActivo As RadioButton
    Friend WithEvents lblActivo As Label
    Friend WithEvents pnlMinimizarParametros As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbTodos As RadioButton
End Class
