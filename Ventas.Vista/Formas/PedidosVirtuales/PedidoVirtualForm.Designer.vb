<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidoVirtualForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidoVirtualForm))
        Me.grdProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.txtEstatusId = New System.Windows.Forms.TextBox()
        Me.txtEstatusNombre = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.txtIDListaPrecio = New System.Windows.Forms.TextBox()
        Me.txtListaPrecio = New System.Windows.Forms.TextBox()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.cbxSeleccionar = New System.Windows.Forms.CheckBox()
        Me.txtOrdenCliente = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.txtSemanaProgramacion = New System.Windows.Forms.TextBox()
        Me.lblListaPrecios = New System.Windows.Forms.Label()
        Me.lblFechaProg = New System.Windows.Forms.Label()
        Me.dtpFProgramacion = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaSol = New System.Windows.Forms.Label()
        Me.dtpFSolicitada = New System.Windows.Forms.DateTimePicker()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.grbTipoPedido = New System.Windows.Forms.GroupBox()
        Me.rbtProyeccion = New System.Windows.Forms.RadioButton()
        Me.rbtBorradorCliente = New System.Windows.Forms.RadioButton()
        Me.rbtPedNoConfirmado = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblRegistro = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblContados = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBitacora = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grbTipoPedido.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdProductos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductos.DisplayLayout.Appearance = Appearance1
        Me.grdProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProductos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Location = New System.Drawing.Point(0, 249)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(1034, 252)
        Me.grdProductos.TabIndex = 65
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlDatos.Controls.Add(Me.txtEstatusId)
        Me.pnlDatos.Controls.Add(Me.txtEstatusNombre)
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Controls.Add(Me.txtIDListaPrecio)
        Me.pnlDatos.Controls.Add(Me.txtListaPrecio)
        Me.pnlDatos.Controls.Add(Me.lblPedido)
        Me.pnlDatos.Controls.Add(Me.txtPedido)
        Me.pnlDatos.Controls.Add(Me.cbxSeleccionar)
        Me.pnlDatos.Controls.Add(Me.txtOrdenCliente)
        Me.pnlDatos.Controls.Add(Me.Label13)
        Me.pnlDatos.Controls.Add(Me.txtObservaciones)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.txtSemana)
        Me.pnlDatos.Controls.Add(Me.txtSemanaProgramacion)
        Me.pnlDatos.Controls.Add(Me.lblListaPrecios)
        Me.pnlDatos.Controls.Add(Me.lblFechaProg)
        Me.pnlDatos.Controls.Add(Me.dtpFProgramacion)
        Me.pnlDatos.Controls.Add(Me.lblFechaSol)
        Me.pnlDatos.Controls.Add(Me.dtpFSolicitada)
        Me.pnlDatos.Controls.Add(Me.cmbClientes)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.lblCliente)
        Me.pnlDatos.Controls.Add(Me.grbTipoPedido)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 67)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1034, 182)
        Me.pnlDatos.TabIndex = 68
        '
        'txtEstatusId
        '
        Me.txtEstatusId.Location = New System.Drawing.Point(913, 152)
        Me.txtEstatusId.Name = "txtEstatusId"
        Me.txtEstatusId.Size = New System.Drawing.Size(48, 20)
        Me.txtEstatusId.TabIndex = 102
        Me.txtEstatusId.Visible = False
        '
        'txtEstatusNombre
        '
        Me.txtEstatusNombre.Enabled = False
        Me.txtEstatusNombre.Location = New System.Drawing.Point(743, 154)
        Me.txtEstatusNombre.Name = "txtEstatusNombre"
        Me.txtEstatusNombre.Size = New System.Drawing.Size(164, 20)
        Me.txtEstatusNombre.TabIndex = 101
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(966, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(68, 182)
        Me.Panel3.TabIndex = 100
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(9, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'txtIDListaPrecio
        '
        Me.txtIDListaPrecio.Enabled = False
        Me.txtIDListaPrecio.Location = New System.Drawing.Point(588, 85)
        Me.txtIDListaPrecio.Name = "txtIDListaPrecio"
        Me.txtIDListaPrecio.Size = New System.Drawing.Size(33, 20)
        Me.txtIDListaPrecio.TabIndex = 99
        Me.txtIDListaPrecio.Visible = False
        '
        'txtListaPrecio
        '
        Me.txtListaPrecio.Enabled = False
        Me.txtListaPrecio.Location = New System.Drawing.Point(142, 90)
        Me.txtListaPrecio.Name = "txtListaPrecio"
        Me.txtListaPrecio.Size = New System.Drawing.Size(479, 20)
        Me.txtListaPrecio.TabIndex = 98
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Location = New System.Drawing.Point(53, 13)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(40, 13)
        Me.lblPedido.TabIndex = 97
        Me.lblPedido.Text = "Pedido"
        Me.lblPedido.Visible = False
        '
        'txtPedido
        '
        Me.txtPedido.Enabled = False
        Me.txtPedido.Location = New System.Drawing.Point(145, 9)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(52, 20)
        Me.txtPedido.TabIndex = 96
        Me.txtPedido.Visible = False
        '
        'cbxSeleccionar
        '
        Me.cbxSeleccionar.AutoSize = True
        Me.cbxSeleccionar.Location = New System.Drawing.Point(17, 157)
        Me.cbxSeleccionar.Name = "cbxSeleccionar"
        Me.cbxSeleccionar.Size = New System.Drawing.Size(106, 17)
        Me.cbxSeleccionar.TabIndex = 93
        Me.cbxSeleccionar.Text = "Seleccionar todo"
        Me.cbxSeleccionar.UseVisualStyleBackColor = True
        '
        'txtOrdenCliente
        '
        Me.txtOrdenCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrdenCliente.Enabled = False
        Me.txtOrdenCliente.Location = New System.Drawing.Point(410, 64)
        Me.txtOrdenCliente.MaxLength = 30
        Me.txtOrdenCliente.Name = "txtOrdenCliente"
        Me.txtOrdenCliente.Size = New System.Drawing.Size(211, 20)
        Me.txtOrdenCliente.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(315, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Orden Cliente"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(143, 116)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(479, 57)
        Me.txtObservaciones.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(51, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Observaciones"
        '
        'txtSemana
        '
        Me.txtSemana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSemana.Enabled = False
        Me.txtSemana.Location = New System.Drawing.Point(250, 64)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(60, 20)
        Me.txtSemana.TabIndex = 83
        '
        'txtSemanaProgramacion
        '
        Me.txtSemanaProgramacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSemanaProgramacion.Enabled = False
        Me.txtSemanaProgramacion.Location = New System.Drawing.Point(846, 125)
        Me.txtSemanaProgramacion.Name = "txtSemanaProgramacion"
        Me.txtSemanaProgramacion.Size = New System.Drawing.Size(66, 20)
        Me.txtSemanaProgramacion.TabIndex = 82
        Me.txtSemanaProgramacion.Visible = False
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.Location = New System.Drawing.Point(50, 89)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 69
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'lblFechaProg
        '
        Me.lblFechaProg.AutoSize = True
        Me.lblFechaProg.ForeColor = System.Drawing.Color.Black
        Me.lblFechaProg.Location = New System.Drawing.Point(657, 129)
        Me.lblFechaProg.Name = "lblFechaProg"
        Me.lblFechaProg.Size = New System.Drawing.Size(81, 13)
        Me.lblFechaProg.TabIndex = 68
        Me.lblFechaProg.Text = "F Programación"
        Me.lblFechaProg.Visible = False
        '
        'dtpFProgramacion
        '
        Me.dtpFProgramacion.CustomFormat = ""
        Me.dtpFProgramacion.Enabled = False
        Me.dtpFProgramacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFProgramacion.Location = New System.Drawing.Point(744, 125)
        Me.dtpFProgramacion.Name = "dtpFProgramacion"
        Me.dtpFProgramacion.Size = New System.Drawing.Size(95, 20)
        Me.dtpFProgramacion.TabIndex = 67
        Me.dtpFProgramacion.Value = New Date(2016, 1, 30, 12, 34, 0, 0)
        Me.dtpFProgramacion.Visible = False
        '
        'lblFechaSol
        '
        Me.lblFechaSol.AutoSize = True
        Me.lblFechaSol.ForeColor = System.Drawing.Color.Black
        Me.lblFechaSol.Location = New System.Drawing.Point(50, 63)
        Me.lblFechaSol.Name = "lblFechaSol"
        Me.lblFechaSol.Size = New System.Drawing.Size(72, 13)
        Me.lblFechaSol.TabIndex = 66
        Me.lblFechaSol.Text = "* F Solicitada "
        '
        'dtpFSolicitada
        '
        Me.dtpFSolicitada.CustomFormat = ""
        Me.dtpFSolicitada.Enabled = False
        Me.dtpFSolicitada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFSolicitada.Location = New System.Drawing.Point(142, 64)
        Me.dtpFSolicitada.Name = "dtpFSolicitada"
        Me.dtpFSolicitada.Size = New System.Drawing.Size(102, 20)
        Me.dtpFSolicitada.TabIndex = 1
        Me.dtpFSolicitada.Value = New Date(2016, 2, 2, 12, 34, 0, 0)
        '
        'cmbClientes
        '
        Me.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientes.Enabled = False
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(143, 37)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(478, 21)
        Me.cmbClientes.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(657, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Status "
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(50, 40)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(46, 13)
        Me.lblCliente.TabIndex = 8
        Me.lblCliente.Text = "* Cliente"
        '
        'grbTipoPedido
        '
        Me.grbTipoPedido.Controls.Add(Me.rbtProyeccion)
        Me.grbTipoPedido.Controls.Add(Me.rbtBorradorCliente)
        Me.grbTipoPedido.Controls.Add(Me.rbtPedNoConfirmado)
        Me.grbTipoPedido.Enabled = False
        Me.grbTipoPedido.Location = New System.Drawing.Point(631, 30)
        Me.grbTipoPedido.Name = "grbTipoPedido"
        Me.grbTipoPedido.Size = New System.Drawing.Size(362, 89)
        Me.grbTipoPedido.TabIndex = 92
        Me.grbTipoPedido.TabStop = False
        Me.grbTipoPedido.Text = "* Tipo de Pedido Virtual"
        '
        'rbtProyeccion
        '
        Me.rbtProyeccion.AutoSize = True
        Me.rbtProyeccion.Location = New System.Drawing.Point(16, 64)
        Me.rbtProyeccion.Name = "rbtProyeccion"
        Me.rbtProyeccion.Size = New System.Drawing.Size(185, 17)
        Me.rbtProyeccion.TabIndex = 2
        Me.rbtProyeccion.Tag = "5"
        Me.rbtProyeccion.Text = "Proyección de Ventas (Colección)"
        Me.rbtProyeccion.UseVisualStyleBackColor = True
        '
        'rbtBorradorCliente
        '
        Me.rbtBorradorCliente.AutoSize = True
        Me.rbtBorradorCliente.Location = New System.Drawing.Point(16, 42)
        Me.rbtBorradorCliente.Name = "rbtBorradorCliente"
        Me.rbtBorradorCliente.Size = New System.Drawing.Size(209, 17)
        Me.rbtBorradorCliente.TabIndex = 1
        Me.rbtBorradorCliente.Tag = "4"
        Me.rbtBorradorCliente.Text = "Borrador de Cliente (Colección-Modelo)"
        Me.rbtBorradorCliente.UseVisualStyleBackColor = True
        '
        'rbtPedNoConfirmado
        '
        Me.rbtPedNoConfirmado.AutoSize = True
        Me.rbtPedNoConfirmado.Checked = True
        Me.rbtPedNoConfirmado.Location = New System.Drawing.Point(16, 20)
        Me.rbtPedNoConfirmado.Name = "rbtPedNoConfirmado"
        Me.rbtPedNoConfirmado.Size = New System.Drawing.Size(308, 17)
        Me.rbtPedNoConfirmado.TabIndex = 0
        Me.rbtPedNoConfirmado.TabStop = True
        Me.rbtPedNoConfirmado.Tag = "3"
        Me.rbtPedNoConfirmado.Text = "Pedido No Confirmado (Colección-Modelo-Piel-Color-Corrida)"
        Me.rbtPedNoConfirmado.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblRegistro)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.lblContados)
        Me.Panel2.Controls.Add(Me.lblRegistros)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 501)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1034, 60)
        Me.Panel2.TabIndex = 67
        '
        'lblRegistro
        '
        Me.lblRegistro.AutoSize = True
        Me.lblRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistro.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistro.Location = New System.Drawing.Point(42, 34)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(25, 25)
        Me.lblRegistro.TabIndex = 13
        Me.lblRegistro.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 18)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "seleccionados"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 18)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Registros"
        '
        'lblContados
        '
        Me.lblContados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblContados.Location = New System.Drawing.Point(620, 30)
        Me.lblContados.Name = "lblContados"
        Me.lblContados.Size = New System.Drawing.Size(169, 25)
        Me.lblContados.TabIndex = 10
        Me.lblContados.Text = "0"
        Me.lblContados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(656, 9)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(93, 18)
        Me.lblRegistros.TabIndex = 9
        Me.lblRegistros.Text = "Total pares"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(808, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(226, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(121, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 6
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(126, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Enabled = False
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(182, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(181, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnEliminar)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.btnProductos)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.btnBitacora)
        Me.pnlHeader.Controls.Add(Me.btnImportar)
        Me.pnlHeader.Controls.Add(Me.lblAltas)
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1034, 67)
        Me.pnlHeader.TabIndex = 66
        '
        'btnEliminar
        '
        Me.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.Ventas.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminar.Location = New System.Drawing.Point(85, 7)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(79, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 26)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = " Eliminar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Artículos"
        '
        'btnProductos
        '
        Me.btnProductos.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnProductos.Enabled = False
        Me.btnProductos.Image = CType(resources.GetObject("btnProductos.Image"), System.Drawing.Image)
        Me.btnProductos.Location = New System.Drawing.Point(23, 7)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(32, 32)
        Me.btnProductos.TabIndex = 0
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(12, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 26)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = " Consultar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Productos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(210, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Bitácora"
        '
        'btnBitacora
        '
        Me.btnBitacora.Enabled = False
        Me.btnBitacora.Image = Global.Ventas.Vista.My.Resources.Resources.historico
        Me.btnBitacora.Location = New System.Drawing.Point(215, 7)
        Me.btnBitacora.Name = "btnBitacora"
        Me.btnBitacora.Size = New System.Drawing.Size(32, 32)
        Me.btnBitacora.TabIndex = 3
        Me.btnBitacora.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnImportar.Enabled = False
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.Location = New System.Drawing.Point(148, 7)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(32, 32)
        Me.btnImportar.TabIndex = 2
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(142, 37)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(45, 13)
        Me.lblAltas.TabIndex = 22
        Me.lblAltas.Text = "Importar"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(284, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 2
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(290, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(636, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 67)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(209, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(121, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Pedido Virtual"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(330, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 67)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'PedidoVirtualForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdProductos)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "PedidoVirtualForm"
        Me.Text = "Pedido Virtual"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.grbTipoPedido.ResumeLayout(False)
        Me.grbTipoPedido.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents lblListaPrecios As System.Windows.Forms.Label
    Friend WithEvents lblFechaProg As System.Windows.Forms.Label
    Friend WithEvents dtpFProgramacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaSol As System.Windows.Forms.Label
    Friend WithEvents dtpFSolicitada As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblContados As System.Windows.Forms.Label
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBitacora As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents txtSemana As System.Windows.Forms.TextBox
    Friend WithEvents txtSemanaProgramacion As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grbTipoPedido As System.Windows.Forms.GroupBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnProductos As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents lblRegistro As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtIDListaPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtListaPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents rbtProyeccion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBorradorCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPedNoConfirmado As System.Windows.Forms.RadioButton
    Friend WithEvents txtEstatusId As System.Windows.Forms.TextBox
    Friend WithEvents txtEstatusNombre As System.Windows.Forms.TextBox
End Class
