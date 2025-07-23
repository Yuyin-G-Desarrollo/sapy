<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizacionMasiva_AtnClientesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActualizacionMasiva_AtnClientesForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlClienteBotones = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGuardarCliente = New System.Windows.Forms.Button()
        Me.lblGuardarCliente = New System.Windows.Forms.Label()
        Me.btnCancelarCliente = New System.Windows.Forms.Button()
        Me.lblCancelarCliente = New System.Windows.Forms.Label()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.gridListaCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.rbtnAgenteVentas = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pblY_O = New System.Windows.Forms.Panel()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.chboxMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.rbtnAtnClientes = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboxClienteVendedor = New System.Windows.Forms.ComboBox()
        Me.cboxClienteAtnClientes = New System.Windows.Forms.ComboBox()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlClienteBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.gridListaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pblY_O.SuspendLayout()
        Me.pnlMarcarTodo.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlClienteBotones)
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(983, 566)
        Me.pnlContenedor.TabIndex = 1
        '
        'pnlClienteBotones
        '
        Me.pnlClienteBotones.Controls.Add(Me.Panel1)
        Me.pnlClienteBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlClienteBotones.Location = New System.Drawing.Point(0, 495)
        Me.pnlClienteBotones.Name = "pnlClienteBotones"
        Me.pnlClienteBotones.Size = New System.Drawing.Size(983, 71)
        Me.pnlClienteBotones.TabIndex = 30
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGuardarCliente)
        Me.Panel1.Controls.Add(Me.lblGuardarCliente)
        Me.Panel1.Controls.Add(Me.btnCancelarCliente)
        Me.Panel1.Controls.Add(Me.lblCancelarCliente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(879, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(104, 71)
        Me.Panel1.TabIndex = 115
        '
        'btnGuardarCliente
        '
        Me.btnGuardarCliente.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardarCliente.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardarCliente.Location = New System.Drawing.Point(13, 11)
        Me.btnGuardarCliente.Name = "btnGuardarCliente"
        Me.btnGuardarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarCliente.TabIndex = 3
        Me.btnGuardarCliente.UseVisualStyleBackColor = True
        '
        'lblGuardarCliente
        '
        Me.lblGuardarCliente.AutoSize = True
        Me.lblGuardarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardarCliente.Location = New System.Drawing.Point(7, 46)
        Me.lblGuardarCliente.Name = "lblGuardarCliente"
        Me.lblGuardarCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarCliente.TabIndex = 0
        Me.lblGuardarCliente.Text = "Guardar"
        '
        'btnCancelarCliente
        '
        Me.btnCancelarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarCliente.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarCliente.Location = New System.Drawing.Point(61, 11)
        Me.btnCancelarCliente.Name = "btnCancelarCliente"
        Me.btnCancelarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarCliente.TabIndex = 4
        Me.btnCancelarCliente.UseVisualStyleBackColor = True
        '
        'lblCancelarCliente
        '
        Me.lblCancelarCliente.AutoSize = True
        Me.lblCancelarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCancelarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelarCliente.Location = New System.Drawing.Point(60, 46)
        Me.lblCancelarCliente.Name = "lblCancelarCliente"
        Me.lblCancelarCliente.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelarCliente.TabIndex = 0
        Me.lblCancelarCliente.Text = "Cerrar"
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.gridListaCliente)
        Me.pnlListaCliente.Controls.Add(Me.GroupBox1)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(983, 507)
        Me.pnlListaCliente.TabIndex = 3
        '
        'gridListaCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCliente.DisplayLayout.Appearance = Appearance1
        Me.gridListaCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCliente.Location = New System.Drawing.Point(0, 89)
        Me.gridListaCliente.Name = "gridListaCliente"
        Me.gridListaCliente.Size = New System.Drawing.Size(983, 418)
        Me.gridListaCliente.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlParametros)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(983, 89)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros de actualización"
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.rbtnAgenteVentas)
        Me.pnlParametros.Controls.Add(Me.Label5)
        Me.pnlParametros.Controls.Add(Me.pblY_O)
        Me.pnlParametros.Controls.Add(Me.lblNumFiltrados)
        Me.pnlParametros.Controls.Add(Me.rbtnAtnClientes)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Controls.Add(Me.cboxClienteVendedor)
        Me.pnlParametros.Controls.Add(Me.cboxClienteAtnClientes)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(3, 16)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(977, 65)
        Me.pnlParametros.TabIndex = 1
        '
        'rbtnAgenteVentas
        '
        Me.rbtnAgenteVentas.AutoSize = True
        Me.rbtnAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAgenteVentas.Location = New System.Drawing.Point(402, 38)
        Me.rbtnAgenteVentas.Name = "rbtnAgenteVentas"
        Me.rbtnAgenteVentas.Size = New System.Drawing.Size(110, 17)
        Me.rbtnAgenteVentas.TabIndex = 1
        Me.rbtnAgenteVentas.Text = "Agente de Ventas"
        Me.rbtnAgenteVentas.UseVisualStyleBackColor = True
        Me.rbtnAgenteVentas.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(237, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pblY_O
        '
        Me.pblY_O.Controls.Add(Me.pnlMarcarTodo)
        Me.pblY_O.Dock = System.Windows.Forms.DockStyle.Left
        Me.pblY_O.Location = New System.Drawing.Point(0, 0)
        Me.pblY_O.Name = "pblY_O"
        Me.pblY_O.Size = New System.Drawing.Size(125, 65)
        Me.pblY_O.TabIndex = 51
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Controls.Add(Me.chboxMarcarTodo)
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 17)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(125, 48)
        Me.pnlMarcarTodo.TabIndex = 48
        '
        'chboxMarcarTodo
        '
        Me.chboxMarcarTodo.AutoSize = True
        Me.chboxMarcarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chboxMarcarTodo.Location = New System.Drawing.Point(7, 28)
        Me.chboxMarcarTodo.Name = "chboxMarcarTodo"
        Me.chboxMarcarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxMarcarTodo.TabIndex = 0
        Me.chboxMarcarTodo.Text = "Seleccionar todo"
        Me.chboxMarcarTodo.UseVisualStyleBackColor = True
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(255, 39)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 113
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbtnAtnClientes
        '
        Me.rbtnAtnClientes.AutoSize = True
        Me.rbtnAtnClientes.Checked = True
        Me.rbtnAtnClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAtnClientes.Location = New System.Drawing.Point(402, 8)
        Me.rbtnAtnClientes.Name = "rbtnAtnClientes"
        Me.rbtnAtnClientes.Size = New System.Drawing.Size(92, 17)
        Me.rbtnAtnClientes.TabIndex = 0
        Me.rbtnAtnClientes.TabStop = True
        Me.rbtnAtnClientes.Text = "Atn' a Clientes"
        Me.rbtnAtnClientes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(258, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboxClienteVendedor
        '
        Me.cboxClienteVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxClienteVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxClienteVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxClienteVendedor.Enabled = False
        Me.cboxClienteVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxClienteVendedor.FormattingEnabled = True
        Me.cboxClienteVendedor.Location = New System.Drawing.Point(524, 36)
        Me.cboxClienteVendedor.Name = "cboxClienteVendedor"
        Me.cboxClienteVendedor.Size = New System.Drawing.Size(317, 21)
        Me.cboxClienteVendedor.TabIndex = 50
        Me.cboxClienteVendedor.Visible = False
        '
        'cboxClienteAtnClientes
        '
        Me.cboxClienteAtnClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxClienteAtnClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxClienteAtnClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxClienteAtnClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxClienteAtnClientes.FormattingEnabled = True
        Me.cboxClienteAtnClientes.Location = New System.Drawing.Point(524, 6)
        Me.cboxClienteAtnClientes.Name = "cboxClienteAtnClientes"
        Me.cboxClienteAtnClientes.Size = New System.Drawing.Size(317, 21)
        Me.cboxClienteAtnClientes.TabIndex = 7
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(983, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(983, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'btnExportar
        '
        Me.btnExportar.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExportar.Location = New System.Drawing.Point(16, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 246
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(10, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 245
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblListaPuestos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(514, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(469, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(3, 19)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(386, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Actualización Masiva de Clientes – Atn Clientes"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(702, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(206, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Ficha Técnica de Cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(401, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ActualizacionMasiva_AtnClientesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 566)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ActualizacionMasiva_AtnClientesForm"
        Me.Text = "Actualización Masiva de Clientes – Atn Clientes"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlClienteBotones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.gridListaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pblY_O.ResumeLayout(False)
        Me.pnlMarcarTodo.ResumeLayout(False)
        Me.pnlMarcarTodo.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlClienteBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarCliente As System.Windows.Forms.Button
    Friend WithEvents lblCancelarCliente As System.Windows.Forms.Label
    Friend WithEvents btnGuardarCliente As System.Windows.Forms.Button
    Friend WithEvents lblGuardarCliente As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents rbtnAgenteVentas As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pblY_O As System.Windows.Forms.Panel
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents chboxMarcarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents rbtnAtnClientes As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboxClienteVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents cboxClienteAtnClientes As System.Windows.Forms.ComboBox
    Friend WithEvents gridListaCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
