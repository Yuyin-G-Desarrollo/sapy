<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoProveedoresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoProveedoresForm))
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.pnlRGerente = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlLiquidado = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblGuardarTodo = New System.Windows.Forms.Label()
        Me.btnGuardarTodo = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pnl2 = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnl3 = New System.Windows.Forms.Panel()
        Me.btnEditarEncabezado = New System.Windows.Forms.Button()
        Me.lblEditarEncabezado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnl4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.grdListaProveedores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoNoActivo = New System.Windows.Forms.RadioButton()
        Me.txtCat = New System.Windows.Forms.TextBox()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.rdoActivos = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdoNoActivos = New System.Windows.Forms.RadioButton()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnl1.SuspendLayout()
        Me.pnl2.SuspendLayout()
        Me.pnl3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnl4.SuspendLayout()
        CType(Me.grdListaProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox20.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.pnlRGerente)
        Me.pnlInferior.Controls.Add(Me.Label14)
        Me.pnlInferior.Controls.Add(Me.pnlLiquidado)
        Me.pnlInferior.Controls.Add(Me.Label11)
        Me.pnlInferior.Controls.Add(Me.lblGuardarTodo)
        Me.pnlInferior.Controls.Add(Me.btnGuardarTodo)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 472)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1038, 53)
        Me.pnlInferior.TabIndex = 153
        '
        'pnlRGerente
        '
        Me.pnlRGerente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlRGerente.Location = New System.Drawing.Point(15, 30)
        Me.pnlRGerente.Name = "pnlRGerente"
        Me.pnlRGerente.Size = New System.Drawing.Size(15, 15)
        Me.pnlRGerente.TabIndex = 167
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(33, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "Incompleto"
        '
        'pnlLiquidado
        '
        Me.pnlLiquidado.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.pnlLiquidado.Location = New System.Drawing.Point(15, 8)
        Me.pnlLiquidado.Name = "pnlLiquidado"
        Me.pnlLiquidado.Size = New System.Drawing.Size(15, 15)
        Me.pnlLiquidado.TabIndex = 165
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(33, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Completo"
        '
        'lblGuardarTodo
        '
        Me.lblGuardarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardarTodo.AutoSize = True
        Me.lblGuardarTodo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarTodo.Location = New System.Drawing.Point(985, 38)
        Me.lblGuardarTodo.Name = "lblGuardarTodo"
        Me.lblGuardarTodo.Size = New System.Drawing.Size(35, 13)
        Me.lblGuardarTodo.TabIndex = 98
        Me.lblGuardarTodo.Text = "Cerrar"
        '
        'btnGuardarTodo
        '
        Me.btnGuardarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarTodo.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnGuardarTodo.Location = New System.Drawing.Point(985, 3)
        Me.btnGuardarTodo.Name = "btnGuardarTodo"
        Me.btnGuardarTodo.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarTodo.TabIndex = 15
        Me.btnGuardarTodo.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitle)
        Me.pnlEncabezado.Controls.Add(Me.Button3)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1038, 60)
        Me.pnlEncabezado.TabIndex = 152
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnl1)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnl2)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnl3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnl4)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(670, 60)
        Me.FlowLayoutPanel1.TabIndex = 2020
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.btnNuevo)
        Me.pnl1.Controls.Add(Me.lblAlta)
        Me.pnl1.Location = New System.Drawing.Point(3, 3)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(60, 54)
        Me.pnl1.TabIndex = 0
        Me.pnl1.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_32
        Me.btnNuevo.Location = New System.Drawing.Point(13, 0)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 99
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(17, 39)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 100
        Me.lblAlta.Text = "Alta"
        '
        'pnl2
        '
        Me.pnl2.Controls.Add(Me.btnEditar)
        Me.pnl2.Controls.Add(Me.lblEditar)
        Me.pnl2.Location = New System.Drawing.Point(69, 3)
        Me.pnl2.Name = "pnl2"
        Me.pnl2.Size = New System.Drawing.Size(60, 54)
        Me.pnl2.TabIndex = 1
        Me.pnl2.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(14, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 101
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(14, 39)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 102
        Me.lblEditar.Text = "Editar"
        '
        'pnl3
        '
        Me.pnl3.Controls.Add(Me.btnEditarEncabezado)
        Me.pnl3.Controls.Add(Me.lblEditarEncabezado)
        Me.pnl3.Location = New System.Drawing.Point(135, 3)
        Me.pnl3.Name = "pnl3"
        Me.pnl3.Size = New System.Drawing.Size(73, 54)
        Me.pnl3.TabIndex = 2
        Me.pnl3.Visible = False
        '
        'btnEditarEncabezado
        '
        Me.btnEditarEncabezado.Image = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEditarEncabezado.Location = New System.Drawing.Point(14, 0)
        Me.btnEditarEncabezado.Name = "btnEditarEncabezado"
        Me.btnEditarEncabezado.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarEncabezado.TabIndex = 103
        Me.btnEditarEncabezado.UseVisualStyleBackColor = True
        '
        'lblEditarEncabezado
        '
        Me.lblEditarEncabezado.AutoSize = True
        Me.lblEditarEncabezado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditarEncabezado.Location = New System.Drawing.Point(-1, 30)
        Me.lblEditarEncabezado.Name = "lblEditarEncabezado"
        Me.lblEditarEncabezado.Size = New System.Drawing.Size(67, 26)
        Me.lblEditarEncabezado.TabIndex = 104
        Me.lblEditarEncabezado.Text = "Editar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Encabezado"
        Me.lblEditarEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(214, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(60, 54)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(9, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Exportar"
        '
        'Button2
        '
        Me.Button2.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.Button2.Location = New System.Drawing.Point(14, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 105
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnl4
        '
        Me.pnl4.Controls.Add(Me.Label1)
        Me.pnl4.Controls.Add(Me.Button1)
        Me.pnl4.Location = New System.Drawing.Point(280, 3)
        Me.pnl4.Name = "pnl4"
        Me.pnl4.Size = New System.Drawing.Size(108, 54)
        Me.pnl4.TabIndex = 1
        Me.pnl4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(0, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 26)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Activar proveedor " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en nave"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Image = Global.Proveedor.Vista.My.Resources.Resources.naves_32
        Me.Button1.Location = New System.Drawing.Point(24, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 103
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(840, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(109, 20)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "Proveedores"
        '
        'Button3
        '
        Me.Button3.Image = Global.Proveedor.Vista.My.Resources.Resources.naves_32
        Me.Button3.Location = New System.Drawing.Point(679, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 104
        Me.Button3.UseVisualStyleBackColor = True
        '
        'grdListaProveedores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaProveedores.DisplayLayout.Appearance = Appearance1
        Me.grdListaProveedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProveedores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaProveedores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaProveedores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaProveedores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaProveedores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaProveedores.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaProveedores.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaProveedores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaProveedores.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaProveedores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProveedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaProveedores.Location = New System.Drawing.Point(0, 130)
        Me.grdListaProveedores.Name = "grdListaProveedores"
        Me.grdListaProveedores.Size = New System.Drawing.Size(1038, 342)
        Me.grdListaProveedores.TabIndex = 10
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(775, 76)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 20)
        Me.txtId.TabIndex = 158
        Me.txtId.Visible = False
        '
        'GroupBox20
        '
        Me.GroupBox20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox20.Controls.Add(Me.rdoActivo)
        Me.GroupBox20.Controls.Add(Me.rdoNoActivo)
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(863, 64)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(128, 33)
        Me.GroupBox20.TabIndex = 160
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Activo"
        Me.GroupBox20.Visible = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActivo.Location = New System.Drawing.Point(14, 13)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 10
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoNoActivo
        '
        Me.rdoNoActivo.AutoSize = True
        Me.rdoNoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoActivo.Location = New System.Drawing.Point(83, 13)
        Me.rdoNoActivo.Name = "rdoNoActivo"
        Me.rdoNoActivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoActivo.TabIndex = 11
        Me.rdoNoActivo.Text = "No"
        Me.rdoNoActivo.UseVisualStyleBackColor = True
        '
        'txtCat
        '
        Me.txtCat.Enabled = False
        Me.txtCat.Location = New System.Drawing.Point(669, 77)
        Me.txtCat.Name = "txtCat"
        Me.txtCat.Size = New System.Drawing.Size(100, 20)
        Me.txtCat.TabIndex = 161
        Me.txtCat.Visible = False
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.rdoTodos)
        Me.grbParametros.Controls.Add(Me.rdoActivos)
        Me.grbParametros.Controls.Add(Me.Label5)
        Me.grbParametros.Controls.Add(Me.rdoNoActivos)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1038, 70)
        Me.grbParametros.TabIndex = 164
        Me.grbParametros.TabStop = False
        '
        'rdoTodos
        '
        Me.rdoTodos.AutoSize = True
        Me.rdoTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTodos.Location = New System.Drawing.Point(444, 27)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoTodos.TabIndex = 12
        Me.rdoTodos.Text = "Todos"
        Me.rdoTodos.UseVisualStyleBackColor = True
        '
        'rdoActivos
        '
        Me.rdoActivos.AutoSize = True
        Me.rdoActivos.Checked = True
        Me.rdoActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActivos.Location = New System.Drawing.Point(373, 27)
        Me.rdoActivos.Name = "rdoActivos"
        Me.rdoActivos.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivos.TabIndex = 10
        Me.rdoActivos.TabStop = True
        Me.rdoActivos.Text = "Si"
        Me.rdoActivos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(314, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "Activo"
        '
        'rdoNoActivos
        '
        Me.rdoNoActivos.AutoSize = True
        Me.rdoNoActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoActivos.Location = New System.Drawing.Point(408, 27)
        Me.rdoNoActivos.Name = "rdoNoActivos"
        Me.rdoNoActivos.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoActivos.TabIndex = 11
        Me.rdoNoActivos.Text = "No"
        Me.rdoNoActivos.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(63, 26)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(195, 21)
        Me.cmbNave.TabIndex = 168
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(24, 29)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 167
        Me.lblNave.Text = "Nave"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.Label2)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label4)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnMostrar)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(869, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(166, 51)
        Me.pnlMinimizarParametros.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(114, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(116, -1)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 181
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(62, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(66, -1)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 165
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(970, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2021
        Me.PictureBox1.TabStop = False
        '
        'CatalogoProveedoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1038, 525)
        Me.Controls.Add(Me.grdListaProveedores)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.txtCat)
        Me.Controls.Add(Me.GroupBox20)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "CatalogoProveedoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedores"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.pnl2.ResumeLayout(False)
        Me.pnl2.PerformLayout()
        Me.pnl3.ResumeLayout(False)
        Me.pnl3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl4.ResumeLayout(False)
        Me.pnl4.PerformLayout()
        CType(Me.grdListaProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardarTodo As System.Windows.Forms.Label
    Friend WithEvents btnGuardarTodo As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents grdListaProveedores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtCat As System.Windows.Forms.TextBox
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents rdoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoActivos As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnlRGerente As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlLiquidado As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents pnl2 As System.Windows.Forms.Panel
    Friend WithEvents pnl4 As System.Windows.Forms.Panel
    Friend WithEvents pnl3 As System.Windows.Forms.Panel
    Friend WithEvents btnEditarEncabezado As System.Windows.Forms.Button
    Friend WithEvents lblEditarEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
