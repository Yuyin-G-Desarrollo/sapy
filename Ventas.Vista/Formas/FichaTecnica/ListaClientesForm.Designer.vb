<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaClientesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaClientesForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.gridListaCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.gbox_CEDIS = New System.Windows.Forms.GroupBox()
        Me.cboxNaveAlmacen = New System.Windows.Forms.ComboBox()
        Me.gbox = New System.Windows.Forms.GroupBox()
        Me.rbtnTodo = New System.Windows.Forms.RadioButton()
        Me.rbtnContacto = New System.Windows.Forms.RadioButton()
        Me.rbtnTienda = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.rbtnRFC = New System.Windows.Forms.RadioButton()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.gridListaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.gbox_CEDIS.SuspendLayout()
        Me.gbox.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlParametros)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1194, 609)
        Me.pnlContenedor.TabIndex = 0
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.gridListaCliente)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 137)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1194, 472)
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
        Me.gridListaCliente.Location = New System.Drawing.Point(0, 0)
        Me.gridListaCliente.Name = "gridListaCliente"
        Me.gridListaCliente.Size = New System.Drawing.Size(1194, 472)
        Me.gridListaCliente.TabIndex = 0
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.gbox_CEDIS)
        Me.pnlParametros.Controls.Add(Me.gbox)
        Me.pnlParametros.Controls.Add(Me.txtNombre)
        Me.pnlParametros.Controls.Add(Me.lblNombre)
        Me.pnlParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1194, 78)
        Me.pnlParametros.TabIndex = 0
        '
        'gbox_CEDIS
        '
        Me.gbox_CEDIS.Controls.Add(Me.cboxNaveAlmacen)
        Me.gbox_CEDIS.Location = New System.Drawing.Point(934, 27)
        Me.gbox_CEDIS.Name = "gbox_CEDIS"
        Me.gbox_CEDIS.Size = New System.Drawing.Size(145, 40)
        Me.gbox_CEDIS.TabIndex = 5
        Me.gbox_CEDIS.TabStop = False
        Me.gbox_CEDIS.Text = "CEDIS:"
        '
        'cboxNaveAlmacen
        '
        Me.cboxNaveAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveAlmacen.FormattingEnabled = True
        Me.cboxNaveAlmacen.Location = New System.Drawing.Point(6, 13)
        Me.cboxNaveAlmacen.Name = "cboxNaveAlmacen"
        Me.cboxNaveAlmacen.Size = New System.Drawing.Size(133, 21)
        Me.cboxNaveAlmacen.TabIndex = 0
        '
        'gbox
        '
        Me.gbox.Controls.Add(Me.rbtnTodo)
        Me.gbox.Controls.Add(Me.rbtnContacto)
        Me.gbox.Controls.Add(Me.rbtnTienda)
        Me.gbox.Controls.Add(Me.rbtnCliente)
        Me.gbox.Controls.Add(Me.rbtnRFC)
        Me.gbox.Location = New System.Drawing.Point(441, 27)
        Me.gbox.Name = "gbox"
        Me.gbox.Size = New System.Drawing.Size(487, 40)
        Me.gbox.TabIndex = 1
        Me.gbox.TabStop = False
        Me.gbox.Text = "Buscar en: "
        '
        'rbtnTodo
        '
        Me.rbtnTodo.AutoSize = True
        Me.rbtnTodo.ForeColor = System.Drawing.Color.Black
        Me.rbtnTodo.Location = New System.Drawing.Point(422, 16)
        Me.rbtnTodo.Name = "rbtnTodo"
        Me.rbtnTodo.Size = New System.Drawing.Size(50, 17)
        Me.rbtnTodo.TabIndex = 0
        Me.rbtnTodo.Text = "Todo"
        Me.rbtnTodo.UseVisualStyleBackColor = True
        '
        'rbtnContacto
        '
        Me.rbtnContacto.AutoSize = True
        Me.rbtnContacto.ForeColor = System.Drawing.Color.Black
        Me.rbtnContacto.Location = New System.Drawing.Point(338, 16)
        Me.rbtnContacto.Name = "rbtnContacto"
        Me.rbtnContacto.Size = New System.Drawing.Size(68, 17)
        Me.rbtnContacto.TabIndex = 4
        Me.rbtnContacto.Text = "Contacto"
        Me.rbtnContacto.UseVisualStyleBackColor = True
        '
        'rbtnTienda
        '
        Me.rbtnTienda.AutoSize = True
        Me.rbtnTienda.ForeColor = System.Drawing.Color.Black
        Me.rbtnTienda.Location = New System.Drawing.Point(152, 16)
        Me.rbtnTienda.Name = "rbtnTienda"
        Me.rbtnTienda.Size = New System.Drawing.Size(170, 17)
        Me.rbtnTienda.TabIndex = 3
        Me.rbtnTienda.Text = "Tiendas / Embarques / CEDIS"
        Me.rbtnTienda.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.ForeColor = System.Drawing.Color.Black
        Me.rbtnCliente.Location = New System.Drawing.Point(16, 16)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(57, 17)
        Me.rbtnCliente.TabIndex = 1
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'rbtnRFC
        '
        Me.rbtnRFC.AutoSize = True
        Me.rbtnRFC.ForeColor = System.Drawing.Color.Black
        Me.rbtnRFC.Location = New System.Drawing.Point(89, 16)
        Me.rbtnRFC.Name = "rbtnRFC"
        Me.rbtnRFC.Size = New System.Drawing.Size(46, 17)
        Me.rbtnRFC.TabIndex = 2
        Me.rbtnRFC.Text = "RFC"
        Me.rbtnRFC.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(70, 42)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(352, 20)
        Me.txtNombre.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(18, 45)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 53
        Me.lblNombre.Text = "Nombre"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1085, 0)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(109, 78)
        Me.pnlMinimizarParametros.TabIndex = 2
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(9, 59)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(59, 59)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(62, 27)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 1
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(13, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(79, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 3
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(55, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 2
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1194, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1194, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(70, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(63, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 22
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblListaPuestos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(808, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(386, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(137, 19)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(175, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Consulta de Clientes"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 6)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 0
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 41)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(913, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(206, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Ficha Técnica de Cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(318, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ListaClientesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "ListaClientesForm"
        Me.Text = "Consulta de Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.gridListaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.gbox_CEDIS.ResumeLayout(False)
        Me.gbox.ResumeLayout(False)
        Me.gbox.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
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
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents gridListaCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents gbox As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnContacto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTienda As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnRFC As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTodo As System.Windows.Forms.RadioButton
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents gbox_CEDIS As GroupBox
    Friend WithEvents cboxNaveAlmacen As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
