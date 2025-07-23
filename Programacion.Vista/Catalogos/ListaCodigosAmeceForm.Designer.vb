<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCodigosAmeceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCodigosAmeceForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.gpbConCodigos = New System.Windows.Forms.GroupBox()
        Me.rdoCCAMECE_Si = New System.Windows.Forms.RadioButton()
        Me.rdoCCAMECE_Todos = New System.Windows.Forms.RadioButton()
        Me.rdoCCAMECE_No = New System.Windows.Forms.RadioButton()
        Me.gpbProductos = New System.Windows.Forms.GroupBox()
        Me.rdoVProductos_PedidosConfirmados = New System.Windows.Forms.RadioButton()
        Me.rdoVProductos_Todos = New System.Windows.Forms.RadioButton()
        Me.rdoVProductos_ListaDePrecios = New System.Windows.Forms.RadioButton()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.dtpDel = New System.Windows.Forms.DateTimePicker()
        Me.cmbListaPrecio = New System.Windows.Forms.ComboBox()
        Me.lblFiltroListaPrecios = New System.Windows.Forms.Label()
        Me.lblFiltroCliente = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblEtiquetaUltimoCodigo = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.lblUltimoConcecutivo = New System.Windows.Forms.Label()
        Me.lblCodigoAMECE = New System.Windows.Forms.Label()
        Me.lblRegistrosSeleccionados = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnVolverCargarReporte = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnGenerarCodigos = New System.Windows.Forms.Button()
        Me.lblGenerarCodigos = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.gridCodigosAMECE = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gpbConCodigos.SuspendLayout()
        Me.gpbProductos.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridCodigosAMECE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.chkSeleccionarTodo)
        Me.pnlFiltros.Controls.Add(Me.dtpAl)
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.gpbConCodigos)
        Me.pnlFiltros.Controls.Add(Me.gpbProductos)
        Me.pnlFiltros.Controls.Add(Me.lblDel)
        Me.pnlFiltros.Controls.Add(Me.lblAl)
        Me.pnlFiltros.Controls.Add(Me.dtpDel)
        Me.pnlFiltros.Controls.Add(Me.cmbListaPrecio)
        Me.pnlFiltros.Controls.Add(Me.lblFiltroListaPrecios)
        Me.pnlFiltros.Controls.Add(Me.lblFiltroCliente)
        Me.pnlFiltros.Controls.Add(Me.cmbCliente)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1082, 115)
        Me.pnlFiltros.TabIndex = 82
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(19, 94)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 106
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'dtpAl
        '
        Me.dtpAl.Enabled = False
        Me.dtpAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAl.Location = New System.Drawing.Point(962, 61)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(85, 20)
        Me.dtpAl.TabIndex = 100
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1027, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(55, 115)
        Me.Panel2.TabIndex = 105
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(3, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 86
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(27, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 87
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'gpbConCodigos
        '
        Me.gpbConCodigos.Controls.Add(Me.rdoCCAMECE_Si)
        Me.gpbConCodigos.Controls.Add(Me.rdoCCAMECE_Todos)
        Me.gpbConCodigos.Controls.Add(Me.rdoCCAMECE_No)
        Me.gpbConCodigos.Location = New System.Drawing.Point(221, 27)
        Me.gpbConCodigos.Name = "gpbConCodigos"
        Me.gpbConCodigos.Size = New System.Drawing.Size(126, 63)
        Me.gpbConCodigos.TabIndex = 104
        Me.gpbConCodigos.TabStop = False
        Me.gpbConCodigos.Text = "Con Código AMECE"
        '
        'rdoCCAMECE_Si
        '
        Me.rdoCCAMECE_Si.AutoSize = True
        Me.rdoCCAMECE_Si.Checked = True
        Me.rdoCCAMECE_Si.Location = New System.Drawing.Point(14, 14)
        Me.rdoCCAMECE_Si.Name = "rdoCCAMECE_Si"
        Me.rdoCCAMECE_Si.Size = New System.Drawing.Size(34, 17)
        Me.rdoCCAMECE_Si.TabIndex = 89
        Me.rdoCCAMECE_Si.TabStop = True
        Me.rdoCCAMECE_Si.Text = "Si"
        Me.rdoCCAMECE_Si.UseVisualStyleBackColor = True
        '
        'rdoCCAMECE_Todos
        '
        Me.rdoCCAMECE_Todos.AutoSize = True
        Me.rdoCCAMECE_Todos.Location = New System.Drawing.Point(14, 44)
        Me.rdoCCAMECE_Todos.Name = "rdoCCAMECE_Todos"
        Me.rdoCCAMECE_Todos.Size = New System.Drawing.Size(55, 17)
        Me.rdoCCAMECE_Todos.TabIndex = 95
        Me.rdoCCAMECE_Todos.Text = "Todos"
        Me.rdoCCAMECE_Todos.UseVisualStyleBackColor = True
        '
        'rdoCCAMECE_No
        '
        Me.rdoCCAMECE_No.AutoSize = True
        Me.rdoCCAMECE_No.Location = New System.Drawing.Point(14, 29)
        Me.rdoCCAMECE_No.Name = "rdoCCAMECE_No"
        Me.rdoCCAMECE_No.Size = New System.Drawing.Size(39, 17)
        Me.rdoCCAMECE_No.TabIndex = 88
        Me.rdoCCAMECE_No.Text = "No"
        Me.rdoCCAMECE_No.UseVisualStyleBackColor = False
        '
        'gpbProductos
        '
        Me.gpbProductos.Controls.Add(Me.rdoVProductos_PedidosConfirmados)
        Me.gpbProductos.Controls.Add(Me.rdoVProductos_Todos)
        Me.gpbProductos.Controls.Add(Me.rdoVProductos_ListaDePrecios)
        Me.gpbProductos.Location = New System.Drawing.Point(19, 27)
        Me.gpbProductos.Name = "gpbProductos"
        Me.gpbProductos.Size = New System.Drawing.Size(196, 63)
        Me.gpbProductos.TabIndex = 101
        Me.gpbProductos.TabStop = False
        Me.gpbProductos.Text = "Ver productos de"
        '
        'rdoVProductos_PedidosConfirmados
        '
        Me.rdoVProductos_PedidosConfirmados.AutoSize = True
        Me.rdoVProductos_PedidosConfirmados.Checked = True
        Me.rdoVProductos_PedidosConfirmados.Location = New System.Drawing.Point(14, 14)
        Me.rdoVProductos_PedidosConfirmados.Name = "rdoVProductos_PedidosConfirmados"
        Me.rdoVProductos_PedidosConfirmados.Size = New System.Drawing.Size(178, 17)
        Me.rdoVProductos_PedidosConfirmados.TabIndex = 89
        Me.rdoVProductos_PedidosConfirmados.TabStop = True
        Me.rdoVProductos_PedidosConfirmados.Text = "Pedidos Confirmados por Ventas"
        Me.rdoVProductos_PedidosConfirmados.UseVisualStyleBackColor = True
        '
        'rdoVProductos_Todos
        '
        Me.rdoVProductos_Todos.AutoSize = True
        Me.rdoVProductos_Todos.Location = New System.Drawing.Point(14, 44)
        Me.rdoVProductos_Todos.Name = "rdoVProductos_Todos"
        Me.rdoVProductos_Todos.Size = New System.Drawing.Size(55, 17)
        Me.rdoVProductos_Todos.TabIndex = 95
        Me.rdoVProductos_Todos.Text = "Todos"
        Me.rdoVProductos_Todos.UseVisualStyleBackColor = True
        '
        'rdoVProductos_ListaDePrecios
        '
        Me.rdoVProductos_ListaDePrecios.AutoSize = True
        Me.rdoVProductos_ListaDePrecios.Location = New System.Drawing.Point(14, 29)
        Me.rdoVProductos_ListaDePrecios.Name = "rdoVProductos_ListaDePrecios"
        Me.rdoVProductos_ListaDePrecios.Size = New System.Drawing.Size(100, 17)
        Me.rdoVProductos_ListaDePrecios.TabIndex = 88
        Me.rdoVProductos_ListaDePrecios.Text = "Lista de Precios"
        Me.rdoVProductos_ListaDePrecios.UseVisualStyleBackColor = False
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDel.Location = New System.Drawing.Point(830, 65)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(23, 13)
        Me.lblDel.TabIndex = 97
        Me.lblDel.Text = "Del"
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAl.Location = New System.Drawing.Point(944, 65)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(16, 13)
        Me.lblAl.TabIndex = 98
        Me.lblAl.Text = "Al"
        '
        'dtpDel
        '
        Me.dtpDel.Enabled = False
        Me.dtpDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDel.Location = New System.Drawing.Point(858, 62)
        Me.dtpDel.Name = "dtpDel"
        Me.dtpDel.Size = New System.Drawing.Size(84, 20)
        Me.dtpDel.TabIndex = 99
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio.FormattingEnabled = True
        Me.cmbListaPrecio.Location = New System.Drawing.Point(439, 62)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(376, 21)
        Me.cmbListaPrecio.TabIndex = 94
        '
        'lblFiltroListaPrecios
        '
        Me.lblFiltroListaPrecios.AutoSize = True
        Me.lblFiltroListaPrecios.Location = New System.Drawing.Point(353, 66)
        Me.lblFiltroListaPrecios.Name = "lblFiltroListaPrecios"
        Me.lblFiltroListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblFiltroListaPrecios.TabIndex = 93
        Me.lblFiltroListaPrecios.Text = "Lista de Precios"
        '
        'lblFiltroCliente
        '
        Me.lblFiltroCliente.AutoSize = True
        Me.lblFiltroCliente.Location = New System.Drawing.Point(353, 41)
        Me.lblFiltroCliente.Name = "lblFiltroCliente"
        Me.lblFiltroCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblFiltroCliente.TabIndex = 92
        Me.lblFiltroCliente.Text = "Cliente"
        '
        'cmbCliente
        '
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(439, 37)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(376, 21)
        Me.cmbCliente.TabIndex = 91
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Panel3)
        Me.pnlEstado.Controls.Add(Me.lblRegistrosSeleccionados)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 496)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1082, 60)
        Me.pnlEstado.TabIndex = 81
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblEtiquetaUltimoCodigo)
        Me.Panel3.Controls.Add(Me.lblConsecutivo)
        Me.Panel3.Controls.Add(Me.lblUltimoConcecutivo)
        Me.Panel3.Controls.Add(Me.lblCodigoAMECE)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(633, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(286, 60)
        Me.Panel3.TabIndex = 85
        '
        'lblEtiquetaUltimoCodigo
        '
        Me.lblEtiquetaUltimoCodigo.AutoSize = True
        Me.lblEtiquetaUltimoCodigo.Location = New System.Drawing.Point(10, 14)
        Me.lblEtiquetaUltimoCodigo.Name = "lblEtiquetaUltimoCodigo"
        Me.lblEtiquetaUltimoCodigo.Size = New System.Drawing.Size(162, 13)
        Me.lblEtiquetaUltimoCodigo.TabIndex = 49
        Me.lblEtiquetaUltimoCodigo.Text = "Último código AMECE generado:"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Location = New System.Drawing.Point(178, 35)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(55, 13)
        Me.lblConsecutivo.TabIndex = 52
        Me.lblConsecutivo.Text = "00000000"
        '
        'lblUltimoConcecutivo
        '
        Me.lblUltimoConcecutivo.AutoSize = True
        Me.lblUltimoConcecutivo.Location = New System.Drawing.Point(63, 35)
        Me.lblUltimoConcecutivo.Name = "lblUltimoConcecutivo"
        Me.lblUltimoConcecutivo.Size = New System.Drawing.Size(109, 13)
        Me.lblUltimoConcecutivo.TabIndex = 50
        Me.lblUltimoConcecutivo.Text = "Consecutivo AMECE:"
        '
        'lblCodigoAMECE
        '
        Me.lblCodigoAMECE.AutoSize = True
        Me.lblCodigoAMECE.Location = New System.Drawing.Point(178, 14)
        Me.lblCodigoAMECE.Name = "lblCodigoAMECE"
        Me.lblCodigoAMECE.Size = New System.Drawing.Size(79, 13)
        Me.lblCodigoAMECE.TabIndex = 51
        Me.lblCodigoAMECE.Text = "000000000000"
        '
        'lblRegistrosSeleccionados
        '
        Me.lblRegistrosSeleccionados.AutoSize = True
        Me.lblRegistrosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRegistrosSeleccionados.Location = New System.Drawing.Point(11, 5)
        Me.lblRegistrosSeleccionados.Name = "lblRegistrosSeleccionados"
        Me.lblRegistrosSeleccionados.Size = New System.Drawing.Size(101, 30)
        Me.lblRegistrosSeleccionados.TabIndex = 47
        Me.lblRegistrosSeleccionados.Text = "Registros" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblRegistrosSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(44, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 48
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnLimpiar)
        Me.pnlOperaciones.Controls.Add(Me.lblLimpiar)
        Me.pnlOperaciones.Controls.Add(Me.btnVolverCargarReporte)
        Me.pnlOperaciones.Controls.Add(Me.lblMostrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(919, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(163, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(76, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 43
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(74, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 42
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnVolverCargarReporte
        '
        Me.btnVolverCargarReporte.Image = CType(resources.GetObject("btnVolverCargarReporte.Image"), System.Drawing.Image)
        Me.btnVolverCargarReporte.Location = New System.Drawing.Point(26, 7)
        Me.btnVolverCargarReporte.Name = "btnVolverCargarReporte"
        Me.btnVolverCargarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverCargarReporte.TabIndex = 41
        Me.btnVolverCargarReporte.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(24, 39)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 40
        Me.lblMostrar.Text = "Mostrar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(121, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(121, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Controls.Add(Me.btnGenerarCodigos)
        Me.pnlEncabezado.Controls.Add(Me.lblGenerarCodigos)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1082, 60)
        Me.pnlEncabezado.TabIndex = 80
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(802, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 60)
        Me.Panel1.TabIndex = 55
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(65, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(141, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Códigos AMECE"
        '
        'btnGenerarCodigos
        '
        Me.btnGenerarCodigos.Image = CType(resources.GetObject("btnGenerarCodigos.Image"), System.Drawing.Image)
        Me.btnGenerarCodigos.Location = New System.Drawing.Point(37, 9)
        Me.btnGenerarCodigos.Name = "btnGenerarCodigos"
        Me.btnGenerarCodigos.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarCodigos.TabIndex = 53
        Me.btnGenerarCodigos.UseVisualStyleBackColor = True
        '
        'lblGenerarCodigos
        '
        Me.lblGenerarCodigos.AutoSize = True
        Me.lblGenerarCodigos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarCodigos.Location = New System.Drawing.Point(12, 41)
        Me.lblGenerarCodigos.Name = "lblGenerarCodigos"
        Me.lblGenerarCodigos.Size = New System.Drawing.Size(86, 13)
        Me.lblGenerarCodigos.TabIndex = 54
        Me.lblGenerarCodigos.Text = "Generar Códigos"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(128, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 50
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(134, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 49
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1014, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'gridCodigosAMECE
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridCodigosAMECE.DisplayLayout.Appearance = Appearance1
        Me.gridCodigosAMECE.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridCodigosAMECE.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCodigosAMECE.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridCodigosAMECE.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridCodigosAMECE.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridCodigosAMECE.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridCodigosAMECE.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridCodigosAMECE.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridCodigosAMECE.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridCodigosAMECE.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridCodigosAMECE.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridCodigosAMECE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCodigosAMECE.Location = New System.Drawing.Point(0, 175)
        Me.gridCodigosAMECE.Name = "gridCodigosAMECE"
        Me.gridCodigosAMECE.Size = New System.Drawing.Size(1082, 321)
        Me.gridCodigosAMECE.TabIndex = 84
        '
        'ListaCodigosAmeceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1082, 556)
        Me.Controls.Add(Me.gridCodigosAMECE)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaCodigosAmeceForm"
        Me.Text = "Códigos AMECE"
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.gpbConCodigos.ResumeLayout(False)
        Me.gpbConCodigos.PerformLayout()
        Me.gpbProductos.ResumeLayout(False)
        Me.gpbProductos.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridCodigosAMECE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents gpbConCodigos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoCCAMECE_Si As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCCAMECE_Todos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCCAMECE_No As System.Windows.Forms.RadioButton
    Friend WithEvents gpbProductos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoVProductos_PedidosConfirmados As System.Windows.Forms.RadioButton
    Friend WithEvents rdoVProductos_Todos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoVProductos_ListaDePrecios As System.Windows.Forms.RadioButton
    Friend WithEvents lblDel As System.Windows.Forms.Label
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents dtpDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltroListaPrecios As System.Windows.Forms.Label
    Friend WithEvents lblFiltroCliente As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblRegistrosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnGenerarCodigos As System.Windows.Forms.Button
    Friend WithEvents lblGenerarCodigos As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnVolverCargarReporte As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents gridCodigosAMECE As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblConsecutivo As System.Windows.Forms.Label
    Friend WithEvents lblCodigoAMECE As System.Windows.Forms.Label
    Friend WithEvents lblUltimoConcecutivo As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaUltimoCodigo As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
