<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorPedidosDetalle_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorPedidosDetalle_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlVerLotes = New System.Windows.Forms.Panel()
        Me.lblVerLotesLot = New System.Windows.Forms.Label()
        Me.btnVerLotes = New System.Windows.Forms.Button()
        Me.lblVerLotesVer = New System.Windows.Forms.Label()
        Me.pnlCancelarPedido = New System.Windows.Forms.Panel()
        Me.btnCancelarPartida = New System.Windows.Forms.Button()
        Me.lblCancelarPartidaCan = New System.Windows.Forms.Label()
        Me.lblCancelarPartidaPart = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlEstatusPedido = New System.Windows.Forms.Panel()
        Me.grpEstatusPartida = New System.Windows.Forms.GroupBox()
        Me.lblPedidoCancelable = New System.Windows.Forms.Label()
        Me.pnlColorCancelable = New System.Windows.Forms.Panel()
        Me.lblCancelado = New System.Windows.Forms.Label()
        Me.lblPedidoNoCancelable = New System.Windows.Forms.Label()
        Me.pnlColorNoCancelable = New System.Windows.Forms.Panel()
        Me.pnlConteo = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlInformacion = New System.Windows.Forms.Panel()
        Me.pnlInformacionTallas = New System.Windows.Forms.Panel()
        Me.grdInformacionTallas = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosInformacionTallas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpInformacionPedido = New System.Windows.Forms.GroupBox()
        Me.lblEjectivo = New System.Windows.Forms.Label()
        Me.txtAgente = New System.Windows.Forms.TextBox()
        Me.lblEjecutivo = New System.Windows.Forms.Label()
        Me.txtEjecutivo = New System.Windows.Forms.TextBox()
        Me.lblFEntregaCliente = New System.Windows.Forms.Label()
        Me.txtFEntregaCliente = New System.Windows.Forms.TextBox()
        Me.lblFCaptura = New System.Windows.Forms.Label()
        Me.txtFCaptura = New System.Windows.Forms.TextBox()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.lblOC = New System.Windows.Forms.Label()
        Me.txtPedidoSICY = New System.Windows.Forms.TextBox()
        Me.lblPedidoSICY = New System.Windows.Forms.Label()
        Me.txtPedidoSAY = New System.Windows.Forms.TextBox()
        Me.lblPedidoSAY = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.grdPedidoDetalle = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosPedidoDetalles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlVerLotes.SuspendLayout()
        Me.pnlCancelarPedido.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezadoExpander.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlEstatusPedido.SuspendLayout()
        Me.grpEstatusPartida.SuspendLayout()
        Me.pnlConteo.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlInformacion.SuspendLayout()
        Me.pnlInformacionTallas.SuspendLayout()
        CType(Me.grdInformacionTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosInformacionTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInformacionPedido.SuspendLayout()
        CType(Me.grdPedidoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosPedidoDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1112, 65)
        Me.pnlEncabezado.TabIndex = 45
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlAcciones)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(418, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.pnlVerLotes)
        Me.pnlAcciones.Controls.Add(Me.pnlCancelarPedido)
        Me.pnlAcciones.Controls.Add(Me.pnlExportar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(653, 65)
        Me.pnlAcciones.TabIndex = 3
        '
        'pnlVerLotes
        '
        Me.pnlVerLotes.Controls.Add(Me.lblVerLotesLot)
        Me.pnlVerLotes.Controls.Add(Me.btnVerLotes)
        Me.pnlVerLotes.Controls.Add(Me.lblVerLotesVer)
        Me.pnlVerLotes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerLotes.Location = New System.Drawing.Point(116, 0)
        Me.pnlVerLotes.Name = "pnlVerLotes"
        Me.pnlVerLotes.Size = New System.Drawing.Size(53, 65)
        Me.pnlVerLotes.TabIndex = 108
        '
        'lblVerLotesLot
        '
        Me.lblVerLotesLot.AutoSize = True
        Me.lblVerLotesLot.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerLotesLot.Location = New System.Drawing.Point(9, 47)
        Me.lblVerLotesLot.Name = "lblVerLotesLot"
        Me.lblVerLotesLot.Size = New System.Drawing.Size(33, 13)
        Me.lblVerLotesLot.TabIndex = 109
        Me.lblVerLotesLot.Text = "Lotes"
        '
        'btnVerLotes
        '
        Me.btnVerLotes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerLotes.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerLotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerLotes.Location = New System.Drawing.Point(9, 3)
        Me.btnVerLotes.Name = "btnVerLotes"
        Me.btnVerLotes.Size = New System.Drawing.Size(32, 32)
        Me.btnVerLotes.TabIndex = 108
        Me.btnVerLotes.UseVisualStyleBackColor = True
        '
        'lblVerLotesVer
        '
        Me.lblVerLotesVer.AutoSize = True
        Me.lblVerLotesVer.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerLotesVer.Location = New System.Drawing.Point(14, 35)
        Me.lblVerLotesVer.Name = "lblVerLotesVer"
        Me.lblVerLotesVer.Size = New System.Drawing.Size(23, 13)
        Me.lblVerLotesVer.TabIndex = 107
        Me.lblVerLotesVer.Text = "Ver"
        '
        'pnlCancelarPedido
        '
        Me.pnlCancelarPedido.Controls.Add(Me.btnCancelarPartida)
        Me.pnlCancelarPedido.Controls.Add(Me.lblCancelarPartidaCan)
        Me.pnlCancelarPedido.Controls.Add(Me.lblCancelarPartidaPart)
        Me.pnlCancelarPedido.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCancelarPedido.Location = New System.Drawing.Point(56, 0)
        Me.pnlCancelarPedido.Name = "pnlCancelarPedido"
        Me.pnlCancelarPedido.Size = New System.Drawing.Size(60, 65)
        Me.pnlCancelarPedido.TabIndex = 105
        '
        'btnCancelarPartida
        '
        Me.btnCancelarPartida.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarPartida.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarPartida.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarPartida.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarPartida.Location = New System.Drawing.Point(15, 3)
        Me.btnCancelarPartida.Name = "btnCancelarPartida"
        Me.btnCancelarPartida.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPartida.TabIndex = 105
        Me.btnCancelarPartida.UseVisualStyleBackColor = True
        '
        'lblCancelarPartidaCan
        '
        Me.lblCancelarPartidaCan.AutoSize = True
        Me.lblCancelarPartidaCan.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarPartidaCan.Location = New System.Drawing.Point(7, 34)
        Me.lblCancelarPartidaCan.Name = "lblCancelarPartidaCan"
        Me.lblCancelarPartidaCan.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelarPartidaCan.TabIndex = 104
        Me.lblCancelarPartidaCan.Text = "Cancelar"
        '
        'lblCancelarPartidaPart
        '
        Me.lblCancelarPartidaPart.AutoSize = True
        Me.lblCancelarPartidaPart.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarPartidaPart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelarPartidaPart.Location = New System.Drawing.Point(11, 47)
        Me.lblCancelarPartidaPart.Name = "lblCancelarPartidaPart"
        Me.lblCancelarPartidaPart.Size = New System.Drawing.Size(40, 13)
        Me.lblCancelarPartidaPart.TabIndex = 106
        Me.lblCancelarPartidaPart.Text = "Partida"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(56, 65)
        Me.pnlExportar.TabIndex = 104
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(5, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 105
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(12, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 102
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(742, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(370, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(51, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(245, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Consulta de Pedidos Detalles"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.chkSeleccionarTodo)
        Me.pnlEncabezadoExpander.Controls.Add(Me.pnlBotonesExpander)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 65)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(1112, 25)
        Me.pnlEncabezadoExpander.TabIndex = 159
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(10, 3)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 2
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1044, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(68, 25)
        Me.pnlBotonesExpander.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 1
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlEstatusPedido)
        Me.pnlPie.Controls.Add(Me.pnlConteo)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 432)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1112, 63)
        Me.pnlPie.TabIndex = 160
        '
        'pnlEstatusPedido
        '
        Me.pnlEstatusPedido.Controls.Add(Me.grpEstatusPartida)
        Me.pnlEstatusPedido.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstatusPedido.Location = New System.Drawing.Point(107, 0)
        Me.pnlEstatusPedido.Name = "pnlEstatusPedido"
        Me.pnlEstatusPedido.Size = New System.Drawing.Size(159, 63)
        Me.pnlEstatusPedido.TabIndex = 187
        '
        'grpEstatusPartida
        '
        Me.grpEstatusPartida.Controls.Add(Me.lblPedidoCancelable)
        Me.grpEstatusPartida.Controls.Add(Me.pnlColorCancelable)
        Me.grpEstatusPartida.Controls.Add(Me.lblCancelado)
        Me.grpEstatusPartida.Controls.Add(Me.lblPedidoNoCancelable)
        Me.grpEstatusPartida.Controls.Add(Me.pnlColorNoCancelable)
        Me.grpEstatusPartida.Location = New System.Drawing.Point(6, 3)
        Me.grpEstatusPartida.Name = "grpEstatusPartida"
        Me.grpEstatusPartida.Size = New System.Drawing.Size(147, 57)
        Me.grpEstatusPartida.TabIndex = 185
        Me.grpEstatusPartida.TabStop = False
        Me.grpEstatusPartida.Text = "Estatus Partida"
        '
        'lblPedidoCancelable
        '
        Me.lblPedidoCancelable.AutoSize = True
        Me.lblPedidoCancelable.Location = New System.Drawing.Point(24, 28)
        Me.lblPedidoCancelable.Name = "lblPedidoCancelable"
        Me.lblPedidoCancelable.Size = New System.Drawing.Size(96, 13)
        Me.lblPedidoCancelable.TabIndex = 24
        Me.lblPedidoCancelable.Text = "Pedido Cancelable"
        '
        'pnlColorCancelable
        '
        Me.pnlColorCancelable.BackColor = System.Drawing.Color.White
        Me.pnlColorCancelable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorCancelable.ForeColor = System.Drawing.Color.Black
        Me.pnlColorCancelable.Location = New System.Drawing.Point(6, 26)
        Me.pnlColorCancelable.Name = "pnlColorCancelable"
        Me.pnlColorCancelable.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorCancelable.TabIndex = 25
        '
        'lblCancelado
        '
        Me.lblCancelado.AutoSize = True
        Me.lblCancelado.ForeColor = System.Drawing.Color.Red
        Me.lblCancelado.Location = New System.Drawing.Point(24, 15)
        Me.lblCancelado.Name = "lblCancelado"
        Me.lblCancelado.Size = New System.Drawing.Size(58, 13)
        Me.lblCancelado.TabIndex = 18
        Me.lblCancelado.Text = "Cancelado"
        '
        'lblPedidoNoCancelable
        '
        Me.lblPedidoNoCancelable.AutoSize = True
        Me.lblPedidoNoCancelable.Location = New System.Drawing.Point(24, 41)
        Me.lblPedidoNoCancelable.Name = "lblPedidoNoCancelable"
        Me.lblPedidoNoCancelable.Size = New System.Drawing.Size(113, 13)
        Me.lblPedidoNoCancelable.TabIndex = 22
        Me.lblPedidoNoCancelable.Text = "Pedido No Cancelable"
        '
        'pnlColorNoCancelable
        '
        Me.pnlColorNoCancelable.BackColor = System.Drawing.Color.Silver
        Me.pnlColorNoCancelable.ForeColor = System.Drawing.Color.Black
        Me.pnlColorNoCancelable.Location = New System.Drawing.Point(6, 40)
        Me.pnlColorNoCancelable.Name = "pnlColorNoCancelable"
        Me.pnlColorNoCancelable.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorNoCancelable.TabIndex = 23
        '
        'pnlConteo
        '
        Me.pnlConteo.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlConteo.Controls.Add(Me.lblRegistros)
        Me.pnlConteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlConteo.Name = "pnlConteo"
        Me.pnlConteo.Size = New System.Drawing.Size(107, 63)
        Me.pnlConteo.TabIndex = 186
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(11, 8)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 183
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(11, 34)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(906, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(206, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(159, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(158, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlInformacion
        '
        Me.pnlInformacion.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacion.Controls.Add(Me.pnlInformacionTallas)
        Me.pnlInformacion.Controls.Add(Me.grpInformacionPedido)
        Me.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInformacion.Location = New System.Drawing.Point(0, 90)
        Me.pnlInformacion.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.pnlInformacion.Name = "pnlInformacion"
        Me.pnlInformacion.Size = New System.Drawing.Size(1112, 132)
        Me.pnlInformacion.TabIndex = 161
        '
        'pnlInformacionTallas
        '
        Me.pnlInformacionTallas.Controls.Add(Me.grdInformacionTallas)
        Me.pnlInformacionTallas.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlInformacionTallas.Location = New System.Drawing.Point(536, 0)
        Me.pnlInformacionTallas.Name = "pnlInformacionTallas"
        Me.pnlInformacionTallas.Size = New System.Drawing.Size(576, 132)
        Me.pnlInformacionTallas.TabIndex = 160
        '
        'grdInformacionTallas
        '
        Me.grdInformacionTallas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdInformacionTallas.Location = New System.Drawing.Point(0, 0)
        Me.grdInformacionTallas.MainView = Me.grdDatosInformacionTallas
        Me.grdInformacionTallas.Name = "grdInformacionTallas"
        Me.grdInformacionTallas.Size = New System.Drawing.Size(576, 132)
        Me.grdInformacionTallas.TabIndex = 163
        Me.grdInformacionTallas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosInformacionTallas})
        '
        'grdDatosInformacionTallas
        '
        Me.grdDatosInformacionTallas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosInformacionTallas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosInformacionTallas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosInformacionTallas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosInformacionTallas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosInformacionTallas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosInformacionTallas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosInformacionTallas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosInformacionTallas.GridControl = Me.grdInformacionTallas
        Me.grdDatosInformacionTallas.IndicatorWidth = 30
        Me.grdDatosInformacionTallas.Name = "grdDatosInformacionTallas"
        Me.grdDatosInformacionTallas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosInformacionTallas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosInformacionTallas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosInformacionTallas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosInformacionTallas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosInformacionTallas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosInformacionTallas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosInformacionTallas.OptionsView.ShowFooter = True
        Me.grdDatosInformacionTallas.OptionsView.ShowGroupPanel = False
        Me.grdDatosInformacionTallas.OptionsView.ShowIndicator = False
        '
        'grpInformacionPedido
        '
        Me.grpInformacionPedido.Controls.Add(Me.lblEjectivo)
        Me.grpInformacionPedido.Controls.Add(Me.txtAgente)
        Me.grpInformacionPedido.Controls.Add(Me.lblEjecutivo)
        Me.grpInformacionPedido.Controls.Add(Me.txtEjecutivo)
        Me.grpInformacionPedido.Controls.Add(Me.lblFEntregaCliente)
        Me.grpInformacionPedido.Controls.Add(Me.txtFEntregaCliente)
        Me.grpInformacionPedido.Controls.Add(Me.lblFCaptura)
        Me.grpInformacionPedido.Controls.Add(Me.txtFCaptura)
        Me.grpInformacionPedido.Controls.Add(Me.txtOC)
        Me.grpInformacionPedido.Controls.Add(Me.lblOC)
        Me.grpInformacionPedido.Controls.Add(Me.txtPedidoSICY)
        Me.grpInformacionPedido.Controls.Add(Me.lblPedidoSICY)
        Me.grpInformacionPedido.Controls.Add(Me.txtPedidoSAY)
        Me.grpInformacionPedido.Controls.Add(Me.lblPedidoSAY)
        Me.grpInformacionPedido.Controls.Add(Me.txtCliente)
        Me.grpInformacionPedido.Controls.Add(Me.lblCliente)
        Me.grpInformacionPedido.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpInformacionPedido.Location = New System.Drawing.Point(0, 0)
        Me.grpInformacionPedido.Name = "grpInformacionPedido"
        Me.grpInformacionPedido.Size = New System.Drawing.Size(511, 132)
        Me.grpInformacionPedido.TabIndex = 0
        Me.grpInformacionPedido.TabStop = False
        Me.grpInformacionPedido.Text = "Información Pedido"
        '
        'lblEjectivo
        '
        Me.lblEjectivo.AutoSize = True
        Me.lblEjectivo.Location = New System.Drawing.Point(283, 101)
        Me.lblEjectivo.Name = "lblEjectivo"
        Me.lblEjectivo.Size = New System.Drawing.Size(44, 13)
        Me.lblEjectivo.TabIndex = 16
        Me.lblEjectivo.Text = "Agente:"
        '
        'txtAgente
        '
        Me.txtAgente.Location = New System.Drawing.Point(345, 98)
        Me.txtAgente.Name = "txtAgente"
        Me.txtAgente.Size = New System.Drawing.Size(136, 20)
        Me.txtAgente.TabIndex = 15
        '
        'lblEjecutivo
        '
        Me.lblEjecutivo.AutoSize = True
        Me.lblEjecutivo.Location = New System.Drawing.Point(49, 100)
        Me.lblEjecutivo.Name = "lblEjecutivo"
        Me.lblEjecutivo.Size = New System.Drawing.Size(54, 13)
        Me.lblEjecutivo.TabIndex = 14
        Me.lblEjecutivo.Text = "Ejecutivo:"
        '
        'txtEjecutivo
        '
        Me.txtEjecutivo.Location = New System.Drawing.Point(113, 97)
        Me.txtEjecutivo.Name = "txtEjecutivo"
        Me.txtEjecutivo.Size = New System.Drawing.Size(136, 20)
        Me.txtEjecutivo.TabIndex = 13
        '
        'lblFEntregaCliente
        '
        Me.lblFEntregaCliente.AutoSize = True
        Me.lblFEntregaCliente.Location = New System.Drawing.Point(236, 75)
        Me.lblFEntregaCliente.Name = "lblFEntregaCliente"
        Me.lblFEntregaCliente.Size = New System.Drawing.Size(91, 13)
        Me.lblFEntregaCliente.TabIndex = 12
        Me.lblFEntregaCliente.Text = "F Entrega Cliente:"
        '
        'txtFEntregaCliente
        '
        Me.txtFEntregaCliente.Location = New System.Drawing.Point(345, 71)
        Me.txtFEntregaCliente.Name = "txtFEntregaCliente"
        Me.txtFEntregaCliente.Size = New System.Drawing.Size(136, 20)
        Me.txtFEntregaCliente.TabIndex = 11
        '
        'lblFCaptura
        '
        Me.lblFCaptura.AutoSize = True
        Me.lblFCaptura.Location = New System.Drawing.Point(18, 75)
        Me.lblFCaptura.Name = "lblFCaptura"
        Me.lblFCaptura.Size = New System.Drawing.Size(85, 13)
        Me.lblFCaptura.TabIndex = 10
        Me.lblFCaptura.Text = "F Enviado SICY:"
        Me.lblFCaptura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFCaptura
        '
        Me.txtFCaptura.Location = New System.Drawing.Point(113, 71)
        Me.txtFCaptura.Name = "txtFCaptura"
        Me.txtFCaptura.Size = New System.Drawing.Size(98, 20)
        Me.txtFCaptura.TabIndex = 9
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(409, 45)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(72, 20)
        Me.txtOC.TabIndex = 8
        '
        'lblOC
        '
        Me.lblOC.AutoSize = True
        Me.lblOC.Location = New System.Drawing.Point(372, 49)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(31, 13)
        Me.lblOC.TabIndex = 7
        Me.lblOC.Text = "O.C.:"
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(279, 45)
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.Size = New System.Drawing.Size(72, 20)
        Me.txtPedidoSICY.TabIndex = 6
        '
        'lblPedidoSICY
        '
        Me.lblPedidoSICY.AutoSize = True
        Me.lblPedidoSICY.Location = New System.Drawing.Point(203, 49)
        Me.lblPedidoSICY.Name = "lblPedidoSICY"
        Me.lblPedidoSICY.Size = New System.Drawing.Size(70, 13)
        Me.lblPedidoSICY.TabIndex = 5
        Me.lblPedidoSICY.Text = "Pedido SICY:"
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(113, 45)
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.Size = New System.Drawing.Size(72, 20)
        Me.txtPedidoSAY.TabIndex = 4
        '
        'lblPedidoSAY
        '
        Me.lblPedidoSAY.AutoSize = True
        Me.lblPedidoSAY.Location = New System.Drawing.Point(36, 48)
        Me.lblPedidoSAY.Name = "lblPedidoSAY"
        Me.lblPedidoSAY.Size = New System.Drawing.Size(67, 13)
        Me.lblPedidoSAY.TabIndex = 3
        Me.lblPedidoSAY.Text = "Pedido SAY:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(113, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(368, 20)
        Me.txtCliente.TabIndex = 2
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(61, 23)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 1
        Me.lblCliente.Text = "Cliente:"
        '
        'grdPedidoDetalle
        '
        Me.grdPedidoDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidoDetalle.Location = New System.Drawing.Point(0, 222)
        Me.grdPedidoDetalle.MainView = Me.grdDatosPedidoDetalles
        Me.grdPedidoDetalle.Name = "grdPedidoDetalle"
        Me.grdPedidoDetalle.Size = New System.Drawing.Size(1112, 210)
        Me.grdPedidoDetalle.TabIndex = 163
        Me.grdPedidoDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosPedidoDetalles})
        '
        'grdDatosPedidoDetalles
        '
        Me.grdDatosPedidoDetalles.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosPedidoDetalles.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosPedidoDetalles.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosPedidoDetalles.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosPedidoDetalles.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosPedidoDetalles.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosPedidoDetalles.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosPedidoDetalles.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosPedidoDetalles.GridControl = Me.grdPedidoDetalle
        Me.grdDatosPedidoDetalles.IndicatorWidth = 30
        Me.grdDatosPedidoDetalles.Name = "grdDatosPedidoDetalles"
        Me.grdDatosPedidoDetalles.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosPedidoDetalles.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosPedidoDetalles.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosPedidoDetalles.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosPedidoDetalles.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosPedidoDetalles.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosPedidoDetalles.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosPedidoDetalles.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosPedidoDetalles.OptionsView.ShowFooter = True
        Me.grdDatosPedidoDetalles.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(302, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'AdministradorPedidosDetalle_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 495)
        Me.Controls.Add(Me.grdPedidoDetalle)
        Me.Controls.Add(Me.pnlInformacion)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AdministradorPedidosDetalle_Form"
        Me.Text = "Consulta de Pedidos Detalles"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlVerLotes.ResumeLayout(False)
        Me.pnlVerLotes.PerformLayout()
        Me.pnlCancelarPedido.ResumeLayout(False)
        Me.pnlCancelarPedido.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        Me.pnlEncabezadoExpander.PerformLayout()
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlEstatusPedido.ResumeLayout(False)
        Me.grpEstatusPartida.ResumeLayout(False)
        Me.grpEstatusPartida.PerformLayout()
        Me.pnlConteo.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlInformacion.ResumeLayout(False)
        Me.pnlInformacionTallas.ResumeLayout(False)
        CType(Me.grdInformacionTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosInformacionTallas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInformacionPedido.ResumeLayout(False)
        Me.grpInformacionPedido.PerformLayout()
        CType(Me.grdPedidoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosPedidoDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents pnlVerLotes As Panel
    Friend WithEvents lblVerLotesLot As Label
    Friend WithEvents btnVerLotes As Button
    Friend WithEvents lblVerLotesVer As Label
    Friend WithEvents pnlCancelarPedido As Panel
    Friend WithEvents btnCancelarPartida As Button
    Friend WithEvents lblCancelarPartidaCan As Label
    Friend WithEvents lblCancelarPartidaPart As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents lblExportar As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlEncabezadoExpander As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlEstatusPedido As Panel
    Friend WithEvents grpEstatusPartida As GroupBox
    Friend WithEvents lblPedidoCancelable As Label
    Friend WithEvents pnlColorCancelable As Panel
    Friend WithEvents lblCancelado As Label
    Friend WithEvents lblPedidoNoCancelable As Label
    Friend WithEvents pnlColorNoCancelable As Panel
    Friend WithEvents pnlConteo As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlInformacion As Panel
    Friend WithEvents grpInformacionPedido As GroupBox
    Friend WithEvents pnlInformacionTallas As Panel
    Friend WithEvents txtOC As TextBox
    Friend WithEvents lblOC As Label
    Friend WithEvents txtPedidoSICY As TextBox
    Friend WithEvents lblPedidoSICY As Label
    Friend WithEvents txtPedidoSAY As TextBox
    Friend WithEvents lblPedidoSAY As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblEjectivo As Label
    Friend WithEvents txtAgente As TextBox
    Friend WithEvents lblEjecutivo As Label
    Friend WithEvents txtEjecutivo As TextBox
    Friend WithEvents lblFEntregaCliente As Label
    Friend WithEvents txtFEntregaCliente As TextBox
    Friend WithEvents lblFCaptura As Label
    Friend WithEvents txtFCaptura As TextBox
    Friend WithEvents grdInformacionTallas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosInformacionTallas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents grdPedidoDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosPedidoDetalles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
