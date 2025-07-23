<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form))
        Me.grdArticulos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkBoxTodosPedidos = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFolioDev = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdDocumentos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkBoxTodosDocumentos = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnMostrarPorDocumentos = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDocumentosSeleccionados = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblPedidosSeleccionados = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMostrarPorPedidos = New System.Windows.Forms.Button()
        Me.grdListaPedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblBtnLimipiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtColeccion = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblTxtColeccion = New System.Windows.Forms.Label()
        Me.lblTxtMarca = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMostrarTodo = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdListaPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdArticulos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulos.DisplayLayout.Appearance = Appearance1
        Me.grdArticulos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdArticulos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdArticulos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdArticulos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdArticulos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdArticulos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdArticulos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdArticulos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdArticulos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdArticulos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulos.Location = New System.Drawing.Point(0, 312)
        Me.grdArticulos.Name = "grdArticulos"
        Me.grdArticulos.Size = New System.Drawing.Size(999, 227)
        Me.grdArticulos.TabIndex = 84
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.chkBoxTodosPedidos)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.lblPedidosSeleccionados)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btnMostrarPorPedidos)
        Me.Panel3.Controls.Add(Me.grdListaPedidos)
        Me.Panel3.Controls.Add(Me.chkSeleccionarTodos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(999, 247)
        Me.Panel3.TabIndex = 83
        '
        'chkBoxTodosPedidos
        '
        Me.chkBoxTodosPedidos.AutoSize = True
        Me.chkBoxTodosPedidos.Enabled = False
        Me.chkBoxTodosPedidos.Location = New System.Drawing.Point(18, 158)
        Me.chkBoxTodosPedidos.Name = "chkBoxTodosPedidos"
        Me.chkBoxTodosPedidos.Size = New System.Drawing.Size(110, 17)
        Me.chkBoxTodosPedidos.TabIndex = 226
        Me.chkBoxTodosPedidos.Text = "Seleccionar Todo"
        Me.chkBoxTodosPedidos.UseVisualStyleBackColor = True
        Me.chkBoxTodosPedidos.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.lblFolioDev)
        Me.Panel5.Controls.Add(Me.lblCliente)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(999, 26)
        Me.Panel5.TabIndex = 225
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(28, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 16)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "Folio de Devolución"
        '
        'lblFolioDev
        '
        Me.lblFolioDev.AutoSize = True
        Me.lblFolioDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDev.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDev.Location = New System.Drawing.Point(181, -2)
        Me.lblFolioDev.Name = "lblFolioDev"
        Me.lblFolioDev.Size = New System.Drawing.Size(51, 25)
        Me.lblFolioDev.TabIndex = 197
        Me.lblFolioDev.Text = "589"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(244, 3)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(173, 16)
        Me.lblCliente.TabIndex = 206
        Me.lblCliente.Text = "NOMBRE DEL CLIENTE"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.grdDocumentos)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Location = New System.Drawing.Point(416, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(571, 215)
        Me.Panel2.TabIndex = 222
        '
        'grdDocumentos
        '
        Appearance2.BackColor = System.Drawing.Color.AliceBlue
        Me.grdDocumentos.DisplayLayout.Appearance = Appearance2
        Me.grdDocumentos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDocumentos.Location = New System.Drawing.Point(0, 0)
        Me.grdDocumentos.Name = "grdDocumentos"
        Me.grdDocumentos.Size = New System.Drawing.Size(571, 129)
        Me.grdDocumentos.TabIndex = 211
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chkBoxTodosDocumentos)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.btnMostrarPorDocumentos)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.lblDocumentosSeleccionados)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 129)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(571, 86)
        Me.Panel4.TabIndex = 223
        '
        'chkBoxTodosDocumentos
        '
        Me.chkBoxTodosDocumentos.AutoSize = True
        Me.chkBoxTodosDocumentos.Enabled = False
        Me.chkBoxTodosDocumentos.Location = New System.Drawing.Point(6, 3)
        Me.chkBoxTodosDocumentos.Name = "chkBoxTodosDocumentos"
        Me.chkBoxTodosDocumentos.Size = New System.Drawing.Size(110, 17)
        Me.chkBoxTodosDocumentos.TabIndex = 227
        Me.chkBoxTodosDocumentos.Text = "Seleccionar Todo"
        Me.chkBoxTodosDocumentos.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(395, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 26)
        Me.Label12.TabIndex = 217
        Me.Label12.Text = "Artículos del documento " & Global.Microsoft.VisualBasic.ChrW(10) & "seleccionado"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnMostrarPorDocumentos
        '
        Me.btnMostrarPorDocumentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrarPorDocumentos.Enabled = False
        Me.btnMostrarPorDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrarPorDocumentos.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarPorDocumentos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrarPorDocumentos.Location = New System.Drawing.Point(526, 6)
        Me.btnMostrarPorDocumentos.Name = "btnMostrarPorDocumentos"
        Me.btnMostrarPorDocumentos.Size = New System.Drawing.Size(32, 36)
        Me.btnMostrarPorDocumentos.TabIndex = 215
        Me.btnMostrarPorDocumentos.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(522, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 214
        Me.Label10.Text = "Mostrar"
        '
        'lblDocumentosSeleccionados
        '
        Me.lblDocumentosSeleccionados.AutoSize = True
        Me.lblDocumentosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentosSeleccionados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDocumentosSeleccionados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDocumentosSeleccionados.Location = New System.Drawing.Point(140, 21)
        Me.lblDocumentosSeleccionados.Name = "lblDocumentosSeleccionados"
        Me.lblDocumentosSeleccionados.Size = New System.Drawing.Size(14, 13)
        Me.lblDocumentosSeleccionados.TabIndex = 221
        Me.lblDocumentosSeleccionados.Text = "0"
        Me.lblDocumentosSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(3, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(138, 13)
        Me.Label17.TabIndex = 220
        Me.Label17.Text = "Documentos seleccionados"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPedidosSeleccionados
        '
        Me.lblPedidosSeleccionados.AutoSize = True
        Me.lblPedidosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosSeleccionados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPedidosSeleccionados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPedidosSeleccionados.Location = New System.Drawing.Point(137, 179)
        Me.lblPedidosSeleccionados.Name = "lblPedidosSeleccionados"
        Me.lblPedidosSeleccionados.Size = New System.Drawing.Size(14, 13)
        Me.lblPedidosSeleccionados.TabIndex = 219
        Me.lblPedidosSeleccionados.Text = "0"
        Me.lblPedidosSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblPedidosSeleccionados.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(15, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 13)
        Me.Label13.TabIndex = 218
        Me.Label13.Text = "Pedidos seleccionados"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label13.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(250, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 26)
        Me.Label11.TabIndex = 216
        Me.Label11.Text = "Artículos del pedido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "seleccionado"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label11.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(346, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 212
        Me.Label3.Text = "Mostrar"
        Me.Label3.Visible = False
        '
        'btnMostrarPorPedidos
        '
        Me.btnMostrarPorPedidos.Enabled = False
        Me.btnMostrarPorPedidos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrarPorPedidos.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarPorPedidos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrarPorPedidos.Location = New System.Drawing.Point(351, 158)
        Me.btnMostrarPorPedidos.Name = "btnMostrarPorPedidos"
        Me.btnMostrarPorPedidos.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarPorPedidos.TabIndex = 213
        Me.btnMostrarPorPedidos.UseVisualStyleBackColor = True
        Me.btnMostrarPorPedidos.Visible = False
        '
        'grdListaPedidos
        '
        Me.grdListaPedidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.AliceBlue
        Me.grdListaPedidos.DisplayLayout.Appearance = Appearance3
        Me.grdListaPedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaPedidos.Location = New System.Drawing.Point(18, 26)
        Me.grdListaPedidos.Name = "grdListaPedidos"
        Me.grdListaPedidos.Size = New System.Drawing.Size(365, 127)
        Me.grdListaPedidos.TabIndex = 210
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.AutoSize = True
        Me.chkSeleccionarTodos.Enabled = False
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(10, 223)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodos.TabIndex = 0
        Me.chkSeleccionarTodos.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 539)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(999, 79)
        Me.pnlPie.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(25, 43)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 181
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 24)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Registros"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label4)
        Me.pnlDatosBotones.Controls.Add(Me.Label7)
        Me.pnlDatosBotones.Controls.Add(Me.lblBtnLimipiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.txtColeccion)
        Me.pnlDatosBotones.Controls.Add(Me.txtMarca)
        Me.pnlDatosBotones.Controls.Add(Me.lblTxtColeccion)
        Me.pnlDatosBotones.Controls.Add(Me.lblTxtMarca)
        Me.pnlDatosBotones.Controls.Add(Me.Label1)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrarTodo)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(311, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(688, 79)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 225
        Me.Label4.Text = "Descontinuado Para Venta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(3, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 18)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Modelo / Artículo inactivo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBtnLimipiar
        '
        Me.lblBtnLimipiar.AutoSize = True
        Me.lblBtnLimipiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnLimipiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBtnLimipiar.Location = New System.Drawing.Point(520, 39)
        Me.lblBtnLimipiar.Name = "lblBtnLimipiar"
        Me.lblBtnLimipiar.Size = New System.Drawing.Size(40, 13)
        Me.lblBtnLimipiar.TabIndex = 223
        Me.lblBtnLimipiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_321
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(523, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 224
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtColeccion
        '
        Me.txtColeccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColeccion.Location = New System.Drawing.Point(259, 40)
        Me.txtColeccion.Name = "txtColeccion"
        Me.txtColeccion.Size = New System.Drawing.Size(163, 20)
        Me.txtColeccion.TabIndex = 222
        Me.txtColeccion.Visible = False
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Location = New System.Drawing.Point(259, 13)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(163, 20)
        Me.txtMarca.TabIndex = 221
        Me.txtMarca.Visible = False
        '
        'lblTxtColeccion
        '
        Me.lblTxtColeccion.AutoSize = True
        Me.lblTxtColeccion.Location = New System.Drawing.Point(202, 43)
        Me.lblTxtColeccion.Name = "lblTxtColeccion"
        Me.lblTxtColeccion.Size = New System.Drawing.Size(54, 13)
        Me.lblTxtColeccion.TabIndex = 220
        Me.lblTxtColeccion.Text = "Colección"
        Me.lblTxtColeccion.Visible = False
        '
        'lblTxtMarca
        '
        Me.lblTxtMarca.AutoSize = True
        Me.lblTxtMarca.Location = New System.Drawing.Point(202, 16)
        Me.lblTxtMarca.Name = "lblTxtMarca"
        Me.lblTxtMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblTxtMarca.TabIndex = 219
        Me.lblTxtMarca.Text = "Marca"
        Me.lblTxtMarca.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(449, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 39)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Mostrar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Todos los" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Artículos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'btnMostrarTodo
        '
        Me.btnMostrarTodo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrarTodo.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrarTodo.Location = New System.Drawing.Point(458, 6)
        Me.btnMostrarTodo.Name = "btnMostrarTodo"
        Me.btnMostrarTodo.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarTodo.TabIndex = 217
        Me.btnMostrarTodo.UseVisualStyleBackColor = True
        Me.btnMostrarTodo.Visible = False
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(568, 39)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(63, 13)
        Me.lblAceptar.TabIndex = 7
        Me.lblAceptar.Text = "Seleccionar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(583, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(641, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(640, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(999, 65)
        Me.pnlEncabezado.TabIndex = 81
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(999, 65)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(931, 59)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(554, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(377, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Devolución de Clientes - Seleccionar Artículos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(931, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 618)
        Me.Controls.Add(Me.grdArticulos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form"
        Me.Text = "Devolución de Clientes - Seleccionar Artículos"
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.grdListaPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdArticulos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdDocumentos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdListaPedidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblFolioDev As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chkSeleccionarTodos As CheckBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnMostrarPorDocumentos As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMostrarPorPedidos As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMostrarTodo As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblDocumentosSeleccionados As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblPedidosSeleccionados As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblBtnLimipiar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtColeccion As TextBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents lblTxtColeccion As Label
    Friend WithEvents lblTxtMarca As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkBoxTodosPedidos As CheckBox
    Friend WithEvents chkBoxTodosDocumentos As CheckBox
End Class
