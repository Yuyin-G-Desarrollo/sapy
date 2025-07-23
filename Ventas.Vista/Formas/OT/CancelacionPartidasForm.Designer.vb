<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionPartidasForm
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
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPedidoCompleto = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblNoFacturado = New System.Windows.Forms.Label()
        Me.pnlEntregaVencida = New System.Windows.Forms.Panel()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.chkboxSeleccionar = New System.Windows.Forms.CheckBox()
        Me.lblTextoRFC = New System.Windows.Forms.Label()
        Me.lblTextoCaptura = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblCaptura = New System.Windows.Forms.Label()
        Me.lblTextoMarca = New System.Windows.Forms.Label()
        Me.lblTextoObservaciones = New System.Windows.Forms.Label()
        Me.lblObsrvaciones = New System.Windows.Forms.Label()
        Me.lblMarcas = New System.Windows.Forms.Label()
        Me.lblTextoOrden = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.lblTextoAgente = New System.Windows.Forms.Label()
        Me.lblTextoEntregaCliente = New System.Windows.Forms.Label()
        Me.lblEntregaCliente = New System.Windows.Forms.Label()
        Me.lblAgente = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSICY = New System.Windows.Forms.Label()
        Me.lblPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoCliente = New System.Windows.Forms.Label()
        Me.lblTextoEstatus = New System.Windows.Forms.Label()
        Me.lblTextoFechaEntrega = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSAY = New System.Windows.Forms.Label()
        Me.lblPedidoSAY = New System.Windows.Forms.Label()
        Me.grdPartidas = New DevExpress.XtraGrid.GridControl()
        Me.ViewPartidas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Seleccionar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OTSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Agente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoOT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrdenCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaEntregaProgramacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPreparacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Confirmados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PorConfirmar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cancelados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioModifico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaModificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiasFaltantes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MotivoCancelacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EstatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Observaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCitaEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1241, 65)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label3)
        Me.Panel14.Controls.Add(Me.btnExportar)
        Me.Panel14.Controls.Add(Me.Label1)
        Me.Panel14.Controls.Add(Me.btnPedidoCompleto)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 65)
        Me.Panel14.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(77, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(82, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cancelar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPedidoCompleto
        '
        Me.btnPedidoCompleto.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPedidoCompleto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnPedidoCompleto.Image = Global.Ventas.Vista.My.Resources.Resources.borrar_32
        Me.btnPedidoCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPedidoCompleto.Location = New System.Drawing.Point(16, 10)
        Me.btnPedidoCompleto.Name = "btnPedidoCompleto"
        Me.btnPedidoCompleto.Size = New System.Drawing.Size(32, 32)
        Me.btnPedidoCompleto.TabIndex = 2
        Me.btnPedidoCompleto.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(662, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(579, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(276, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(203, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Cancelación de Partidas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(511, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblNoFacturado)
        Me.pnlPie.Controls.Add(Me.pnlEntregaVencida)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 438)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1241, 60)
        Me.pnlPie.TabIndex = 27
        '
        'lblNoFacturado
        '
        Me.lblNoFacturado.AutoSize = True
        Me.lblNoFacturado.Location = New System.Drawing.Point(125, 29)
        Me.lblNoFacturado.Name = "lblNoFacturado"
        Me.lblNoFacturado.Size = New System.Drawing.Size(206, 13)
        Me.lblNoFacturado.TabIndex = 121
        Me.lblNoFacturado.Text = "La partida no se puede cancelar completa"
        '
        'pnlEntregaVencida
        '
        Me.pnlEntregaVencida.BackColor = System.Drawing.Color.LightGray
        Me.pnlEntregaVencida.ForeColor = System.Drawing.Color.Black
        Me.pnlEntregaVencida.Location = New System.Drawing.Point(109, 27)
        Me.pnlEntregaVencida.Name = "pnlEntregaVencida"
        Me.pnlEntregaVencida.Size = New System.Drawing.Size(15, 15)
        Me.pnlEntregaVencida.TabIndex = 122
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(10, 10)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 118
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(10, 31)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalSeleccionados.TabIndex = 117
        Me.lblTotalSeleccionados.Text = "0"
        Me.lblTotalSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1098, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(143, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(60, 10)
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
        Me.lblCerrar.Location = New System.Drawing.Point(59, 44)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.chkboxSeleccionar)
        Me.pnlParametros.Controls.Add(Me.lblTextoRFC)
        Me.pnlParametros.Controls.Add(Me.lblTextoCaptura)
        Me.pnlParametros.Controls.Add(Me.lblRFC)
        Me.pnlParametros.Controls.Add(Me.lblCaptura)
        Me.pnlParametros.Controls.Add(Me.lblTextoMarca)
        Me.pnlParametros.Controls.Add(Me.lblTextoObservaciones)
        Me.pnlParametros.Controls.Add(Me.lblObsrvaciones)
        Me.pnlParametros.Controls.Add(Me.lblMarcas)
        Me.pnlParametros.Controls.Add(Me.lblTextoOrden)
        Me.pnlParametros.Controls.Add(Me.lblOrden)
        Me.pnlParametros.Controls.Add(Me.lblTextoAgente)
        Me.pnlParametros.Controls.Add(Me.lblTextoEntregaCliente)
        Me.pnlParametros.Controls.Add(Me.lblEntregaCliente)
        Me.pnlParametros.Controls.Add(Me.lblAgente)
        Me.pnlParametros.Controls.Add(Me.lblTextoPedidoSICY)
        Me.pnlParametros.Controls.Add(Me.lblPedidoSICY)
        Me.pnlParametros.Controls.Add(Me.lblTextoCliente)
        Me.pnlParametros.Controls.Add(Me.lblTextoEstatus)
        Me.pnlParametros.Controls.Add(Me.lblTextoFechaEntrega)
        Me.pnlParametros.Controls.Add(Me.lblFechaEntrega)
        Me.pnlParametros.Controls.Add(Me.lblEstatus)
        Me.pnlParametros.Controls.Add(Me.lblCliente)
        Me.pnlParametros.Controls.Add(Me.lblTextoPedidoSAY)
        Me.pnlParametros.Controls.Add(Me.lblPedidoSAY)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1241, 129)
        Me.pnlParametros.TabIndex = 28
        '
        'chkboxSeleccionar
        '
        Me.chkboxSeleccionar.AutoSize = True
        Me.chkboxSeleccionar.Location = New System.Drawing.Point(13, 105)
        Me.chkboxSeleccionar.Name = "chkboxSeleccionar"
        Me.chkboxSeleccionar.Size = New System.Drawing.Size(82, 17)
        Me.chkboxSeleccionar.TabIndex = 27
        Me.chkboxSeleccionar.Text = "Seleccionar"
        Me.chkboxSeleccionar.UseVisualStyleBackColor = True
        '
        'lblTextoRFC
        '
        Me.lblTextoRFC.AutoSize = True
        Me.lblTextoRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoRFC.Location = New System.Drawing.Point(809, 42)
        Me.lblTextoRFC.Name = "lblTextoRFC"
        Me.lblTextoRFC.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoRFC.TabIndex = 26
        Me.lblTextoRFC.Text = "----"
        '
        'lblTextoCaptura
        '
        Me.lblTextoCaptura.AutoSize = True
        Me.lblTextoCaptura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCaptura.Location = New System.Drawing.Point(809, 24)
        Me.lblTextoCaptura.Name = "lblTextoCaptura"
        Me.lblTextoCaptura.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoCaptura.TabIndex = 25
        Me.lblTextoCaptura.Text = "----"
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.Location = New System.Drawing.Point(773, 42)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(35, 13)
        Me.lblRFC.TabIndex = 24
        Me.lblRFC.Text = "RFC:"
        '
        'lblCaptura
        '
        Me.lblCaptura.AutoSize = True
        Me.lblCaptura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptura.Location = New System.Drawing.Point(753, 24)
        Me.lblCaptura.Name = "lblCaptura"
        Me.lblCaptura.Size = New System.Drawing.Size(55, 13)
        Me.lblCaptura.TabIndex = 23
        Me.lblCaptura.Text = "Captura:"
        '
        'lblTextoMarca
        '
        Me.lblTextoMarca.AutoSize = True
        Me.lblTextoMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoMarca.Location = New System.Drawing.Point(639, 42)
        Me.lblTextoMarca.Name = "lblTextoMarca"
        Me.lblTextoMarca.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoMarca.TabIndex = 15
        Me.lblTextoMarca.Text = "----"
        '
        'lblTextoObservaciones
        '
        Me.lblTextoObservaciones.AutoSize = True
        Me.lblTextoObservaciones.Location = New System.Drawing.Point(639, 78)
        Me.lblTextoObservaciones.Name = "lblTextoObservaciones"
        Me.lblTextoObservaciones.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoObservaciones.TabIndex = 18
        Me.lblTextoObservaciones.Text = "----"
        '
        'lblObsrvaciones
        '
        Me.lblObsrvaciones.AutoSize = True
        Me.lblObsrvaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObsrvaciones.Location = New System.Drawing.Point(543, 78)
        Me.lblObsrvaciones.Name = "lblObsrvaciones"
        Me.lblObsrvaciones.Size = New System.Drawing.Size(95, 13)
        Me.lblObsrvaciones.TabIndex = 19
        Me.lblObsrvaciones.Text = "Observaciones:"
        '
        'lblMarcas
        '
        Me.lblMarcas.AutoSize = True
        Me.lblMarcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcas.Location = New System.Drawing.Point(586, 42)
        Me.lblMarcas.Name = "lblMarcas"
        Me.lblMarcas.Size = New System.Drawing.Size(52, 13)
        Me.lblMarcas.TabIndex = 22
        Me.lblMarcas.Text = "Marcas:"
        '
        'lblTextoOrden
        '
        Me.lblTextoOrden.AutoSize = True
        Me.lblTextoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOrden.Location = New System.Drawing.Point(639, 24)
        Me.lblTextoOrden.Name = "lblTextoOrden"
        Me.lblTextoOrden.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoOrden.TabIndex = 14
        Me.lblTextoOrden.Text = "----"
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(547, 24)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(88, 13)
        Me.lblOrden.TabIndex = 13
        Me.lblOrden.Text = "Orden Cliente:"
        '
        'lblTextoAgente
        '
        Me.lblTextoAgente.AutoSize = True
        Me.lblTextoAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoAgente.Location = New System.Drawing.Point(394, 60)
        Me.lblTextoAgente.Name = "lblTextoAgente"
        Me.lblTextoAgente.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoAgente.TabIndex = 5
        Me.lblTextoAgente.Text = "----"
        '
        'lblTextoEntregaCliente
        '
        Me.lblTextoEntregaCliente.AutoSize = True
        Me.lblTextoEntregaCliente.Location = New System.Drawing.Point(394, 78)
        Me.lblTextoEntregaCliente.Name = "lblTextoEntregaCliente"
        Me.lblTextoEntregaCliente.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoEntregaCliente.TabIndex = 7
        Me.lblTextoEntregaCliente.Text = "----"
        '
        'lblEntregaCliente
        '
        Me.lblEntregaCliente.AutoSize = True
        Me.lblEntregaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntregaCliente.Location = New System.Drawing.Point(293, 78)
        Me.lblEntregaCliente.Name = "lblEntregaCliente"
        Me.lblEntregaCliente.Size = New System.Drawing.Size(98, 13)
        Me.lblEntregaCliente.TabIndex = 10
        Me.lblEntregaCliente.Text = "Entrega Cliente:"
        '
        'lblAgente
        '
        Me.lblAgente.AutoSize = True
        Me.lblAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgente.Location = New System.Drawing.Point(337, 60)
        Me.lblAgente.Name = "lblAgente"
        Me.lblAgente.Size = New System.Drawing.Size(51, 13)
        Me.lblAgente.TabIndex = 12
        Me.lblAgente.Text = "Agente:"
        '
        'lblTextoPedidoSICY
        '
        Me.lblTextoPedidoSICY.AutoSize = True
        Me.lblTextoPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSICY.Location = New System.Drawing.Point(394, 24)
        Me.lblTextoPedidoSICY.Name = "lblTextoPedidoSICY"
        Me.lblTextoPedidoSICY.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoPedidoSICY.TabIndex = 4
        Me.lblTextoPedidoSICY.Text = "----"
        '
        'lblPedidoSICY
        '
        Me.lblPedidoSICY.AutoSize = True
        Me.lblPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSICY.Location = New System.Drawing.Point(309, 24)
        Me.lblPedidoSICY.Name = "lblPedidoSICY"
        Me.lblPedidoSICY.Size = New System.Drawing.Size(82, 13)
        Me.lblPedidoSICY.TabIndex = 3
        Me.lblPedidoSICY.Text = "Pedido SICY:"
        '
        'lblTextoCliente
        '
        Me.lblTextoCliente.AutoSize = True
        Me.lblTextoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCliente.Location = New System.Drawing.Point(105, 42)
        Me.lblTextoCliente.Name = "lblTextoCliente"
        Me.lblTextoCliente.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoCliente.TabIndex = 2
        Me.lblTextoCliente.Text = "----"
        '
        'lblTextoEstatus
        '
        Me.lblTextoEstatus.AutoSize = True
        Me.lblTextoEstatus.Location = New System.Drawing.Point(105, 60)
        Me.lblTextoEstatus.Name = "lblTextoEstatus"
        Me.lblTextoEstatus.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoEstatus.TabIndex = 2
        Me.lblTextoEstatus.Text = "----"
        '
        'lblTextoFechaEntrega
        '
        Me.lblTextoFechaEntrega.AutoSize = True
        Me.lblTextoFechaEntrega.Location = New System.Drawing.Point(147, 78)
        Me.lblTextoFechaEntrega.Name = "lblTextoFechaEntrega"
        Me.lblTextoFechaEntrega.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoFechaEntrega.TabIndex = 2
        Me.lblTextoFechaEntrega.Text = "----"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEntrega.Location = New System.Drawing.Point(9, 77)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(136, 13)
        Me.lblFechaEntrega.TabIndex = 2
        Me.lblFechaEntrega.Text = "Entrega Programación:"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.Location = New System.Drawing.Point(50, 60)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(53, 13)
        Me.lblEstatus.TabIndex = 2
        Me.lblEstatus.Text = "Estatus:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(53, 42)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(50, 13)
        Me.lblCliente.TabIndex = 2
        Me.lblCliente.Text = "Cliente:"
        '
        'lblTextoPedidoSAY
        '
        Me.lblTextoPedidoSAY.AutoSize = True
        Me.lblTextoPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSAY.Location = New System.Drawing.Point(105, 24)
        Me.lblTextoPedidoSAY.Name = "lblTextoPedidoSAY"
        Me.lblTextoPedidoSAY.Size = New System.Drawing.Size(19, 13)
        Me.lblTextoPedidoSAY.TabIndex = 1
        Me.lblTextoPedidoSAY.Text = "----"
        '
        'lblPedidoSAY
        '
        Me.lblPedidoSAY.AutoSize = True
        Me.lblPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSAY.Location = New System.Drawing.Point(25, 24)
        Me.lblPedidoSAY.Name = "lblPedidoSAY"
        Me.lblPedidoSAY.Size = New System.Drawing.Size(78, 13)
        Me.lblPedidoSAY.TabIndex = 0
        Me.lblPedidoSAY.Text = "Pedido SAY:"
        '
        'grdPartidas
        '
        Me.grdPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdPartidas.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdPartidas.Location = New System.Drawing.Point(0, 194)
        Me.grdPartidas.MainView = Me.ViewPartidas
        Me.grdPartidas.Name = "grdPartidas"
        Me.grdPartidas.Size = New System.Drawing.Size(1241, 244)
        Me.grdPartidas.TabIndex = 29
        Me.grdPartidas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ViewPartidas, Me.GridView1, Me.grdDetallesOT})
        '
        'ViewPartidas
        '
        Me.ViewPartidas.GridControl = Me.grdPartidas
        Me.ViewPartidas.Name = "ViewPartidas"
        Me.ViewPartidas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ViewPartidas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ViewPartidas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.ViewPartidas.OptionsPrint.AllowMultilineHeaders = True
        Me.ViewPartidas.OptionsSelection.MultiSelect = True
        Me.ViewPartidas.OptionsView.ColumnAutoWidth = False
        Me.ViewPartidas.OptionsView.ShowAutoFilterRow = True
        Me.ViewPartidas.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdPartidas
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Seleccionar
        '
        Me.Seleccionar.Caption = """"
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.VisibleIndex = 0
        Me.Seleccionar.Width = 35
        '
        'OT
        '
        Me.OT.Caption = "OT"
        Me.OT.FieldName = "OT"
        Me.OT.Name = "OT"
        Me.OT.OptionsColumn.AllowEdit = False
        Me.OT.Visible = True
        Me.OT.VisibleIndex = 1
        Me.OT.Width = 70
        '
        'OTSICY
        '
        Me.OTSICY.Caption = "OTSICY"
        Me.OTSICY.FieldName = "OTSICY"
        Me.OTSICY.Name = "OTSICY"
        Me.OTSICY.OptionsColumn.AllowEdit = False
        Me.OTSICY.Visible = True
        Me.OTSICY.VisibleIndex = 2
        Me.OTSICY.Width = 70
        '
        'Cliente
        '
        Me.Cliente.Caption = "Cliente"
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OptionsColumn.AllowEdit = False
        Me.Cliente.Visible = True
        Me.Cliente.VisibleIndex = 3
        Me.Cliente.Width = 220
        '
        'Agente
        '
        Me.Agente.Caption = "Agente"
        Me.Agente.FieldName = "Agente"
        Me.Agente.Name = "Agente"
        Me.Agente.OptionsColumn.AllowEdit = False
        Me.Agente.Visible = True
        Me.Agente.VisibleIndex = 4
        Me.Agente.Width = 80
        '
        'STATUS
        '
        Me.STATUS.Caption = "STATUS"
        Me.STATUS.FieldName = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.OptionsColumn.AllowEdit = False
        Me.STATUS.Visible = True
        Me.STATUS.VisibleIndex = 5
        Me.STATUS.Width = 90
        '
        'TipoOT
        '
        Me.TipoOT.Caption = "Tipo OT"
        Me.TipoOT.FieldName = "TipoOT"
        Me.TipoOT.Name = "TipoOT"
        Me.TipoOT.OptionsColumn.AllowEdit = False
        Me.TipoOT.Visible = True
        Me.TipoOT.VisibleIndex = 6
        Me.TipoOT.Width = 70
        '
        'PedidoSAY
        '
        Me.PedidoSAY.Caption = "Pedido SAY"
        Me.PedidoSAY.FieldName = "PedidoSAY"
        Me.PedidoSAY.Name = "PedidoSAY"
        Me.PedidoSAY.OptionsColumn.AllowEdit = False
        Me.PedidoSAY.Visible = True
        Me.PedidoSAY.VisibleIndex = 7
        Me.PedidoSAY.Width = 80
        '
        'PedidoSICY
        '
        Me.PedidoSICY.Caption = "Pedido SICY"
        Me.PedidoSICY.FieldName = "PedidoSICY"
        Me.PedidoSICY.Name = "PedidoSICY"
        Me.PedidoSICY.OptionsColumn.AllowEdit = False
        Me.PedidoSICY.Visible = True
        Me.PedidoSICY.VisibleIndex = 8
        Me.PedidoSICY.Width = 80
        '
        'OrdenCliente
        '
        Me.OrdenCliente.Caption = "Orden Cliente"
        Me.OrdenCliente.FieldName = "OrdenCliente"
        Me.OrdenCliente.Name = "OrdenCliente"
        Me.OrdenCliente.OptionsColumn.AllowEdit = False
        Me.OrdenCliente.Visible = True
        Me.OrdenCliente.VisibleIndex = 9
        Me.OrdenCliente.Width = 90
        '
        'FechaEntregaProgramacion
        '
        Me.FechaEntregaProgramacion.Caption = "Fecha Entrega Programación"
        Me.FechaEntregaProgramacion.FieldName = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.Name = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.OptionsColumn.AllowEdit = False
        Me.FechaEntregaProgramacion.Visible = True
        Me.FechaEntregaProgramacion.VisibleIndex = 10
        Me.FechaEntregaProgramacion.Width = 120
        '
        'FechaPreparacion
        '
        Me.FechaPreparacion.Caption = "Fecha Preparación"
        Me.FechaPreparacion.FieldName = "FechaPreparacion"
        Me.FechaPreparacion.Name = "FechaPreparacion"
        Me.FechaPreparacion.OptionsColumn.AllowEdit = False
        Me.FechaPreparacion.Visible = True
        Me.FechaPreparacion.VisibleIndex = 11
        Me.FechaPreparacion.Width = 120
        '
        'Cantidad
        '
        Me.Cantidad.Caption = "Cantidad"
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        Me.Cantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.Cantidad.Visible = True
        Me.Cantidad.VisibleIndex = 12
        Me.Cantidad.Width = 80
        '
        'Confirmados
        '
        Me.Confirmados.Caption = "Confirmados"
        Me.Confirmados.FieldName = "Confirmados"
        Me.Confirmados.Name = "Confirmados"
        Me.Confirmados.OptionsColumn.AllowEdit = False
        Me.Confirmados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.Confirmados.Visible = True
        Me.Confirmados.VisibleIndex = 13
        Me.Confirmados.Width = 80
        '
        'PorConfirmar
        '
        Me.PorConfirmar.Caption = "Por Confirmar"
        Me.PorConfirmar.FieldName = "PorConfirmar"
        Me.PorConfirmar.Name = "PorConfirmar"
        Me.PorConfirmar.OptionsColumn.AllowEdit = False
        Me.PorConfirmar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.PorConfirmar.Visible = True
        Me.PorConfirmar.VisibleIndex = 14
        Me.PorConfirmar.Width = 90
        '
        'Cancelados
        '
        Me.Cancelados.Caption = "Cancelados"
        Me.Cancelados.FieldName = "Cancelados"
        Me.Cancelados.Name = "Cancelados"
        Me.Cancelados.OptionsColumn.AllowEdit = False
        Me.Cancelados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.Cancelados.Visible = True
        Me.Cancelados.VisibleIndex = 15
        Me.Cancelados.Width = 80
        '
        'UsuarioCaptura
        '
        Me.UsuarioCaptura.Caption = "Usuario Captura"
        Me.UsuarioCaptura.FieldName = "UsuarioCaptura"
        Me.UsuarioCaptura.Name = "UsuarioCaptura"
        Me.UsuarioCaptura.OptionsColumn.AllowEdit = False
        Me.UsuarioCaptura.Visible = True
        Me.UsuarioCaptura.VisibleIndex = 16
        Me.UsuarioCaptura.Width = 90
        '
        'FechaCaptura
        '
        Me.FechaCaptura.Caption = "Fecha Captura"
        Me.FechaCaptura.FieldName = "FechaCaptura"
        Me.FechaCaptura.Name = "FechaCaptura"
        Me.FechaCaptura.OptionsColumn.AllowEdit = False
        Me.FechaCaptura.Visible = True
        Me.FechaCaptura.VisibleIndex = 17
        Me.FechaCaptura.Width = 120
        '
        'Cita
        '
        Me.Cita.Caption = "Cita"
        Me.Cita.FieldName = "Cita"
        Me.Cita.Name = "Cita"
        Me.Cita.OptionsColumn.AllowEdit = False
        Me.Cita.Visible = True
        Me.Cita.VisibleIndex = 18
        Me.Cita.Width = 50
        '
        'UsuarioModifico
        '
        Me.UsuarioModifico.Caption = "Usuario Modifico"
        Me.UsuarioModifico.FieldName = "UsuarioModifico"
        Me.UsuarioModifico.Name = "UsuarioModifico"
        Me.UsuarioModifico.OptionsColumn.AllowEdit = False
        Me.UsuarioModifico.Visible = True
        Me.UsuarioModifico.VisibleIndex = 19
        Me.UsuarioModifico.Width = 90
        '
        'FechaModificacion
        '
        Me.FechaModificacion.Caption = "Fecha Modificación"
        Me.FechaModificacion.FieldName = "FechaModificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.OptionsColumn.AllowEdit = False
        Me.FechaModificacion.Visible = True
        Me.FechaModificacion.VisibleIndex = 20
        Me.FechaModificacion.Width = 120
        '
        'DiasFaltantes
        '
        Me.DiasFaltantes.Caption = "Dias Faltantes"
        Me.DiasFaltantes.FieldName = "DiasFaltantes"
        Me.DiasFaltantes.Name = "DiasFaltantes"
        Me.DiasFaltantes.OptionsColumn.AllowEdit = False
        Me.DiasFaltantes.Visible = True
        Me.DiasFaltantes.VisibleIndex = 21
        Me.DiasFaltantes.Width = 90
        '
        'BE
        '
        Me.BE.Caption = "BE"
        Me.BE.FieldName = "BE"
        Me.BE.Name = "BE"
        Me.BE.OptionsColumn.AllowEdit = False
        Me.BE.Visible = True
        Me.BE.VisibleIndex = 22
        Me.BE.Width = 50
        '
        'MotivoCancelacion
        '
        Me.MotivoCancelacion.Caption = "Motivo Cancelación"
        Me.MotivoCancelacion.FieldName = "MotivoCancelacion"
        Me.MotivoCancelacion.Name = "MotivoCancelacion"
        Me.MotivoCancelacion.OptionsColumn.AllowEdit = False
        Me.MotivoCancelacion.Visible = True
        Me.MotivoCancelacion.VisibleIndex = 23
        Me.MotivoCancelacion.Width = 100
        '
        'EstatusID
        '
        Me.EstatusID.Caption = "EstatusID"
        Me.EstatusID.FieldName = "EstatusID"
        Me.EstatusID.Name = "EstatusID"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ClaveCitaEntrega"
        Me.GridColumn2.FieldName = "ClaveCitaEntrega"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 24
        '
        'Observaciones
        '
        Me.Observaciones.Caption = "GridColumn3"
        Me.Observaciones.FieldName = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Visible = True
        Me.Observaciones.VisibleIndex = 25
        '
        'FechaCitaEntrega
        '
        Me.FechaCitaEntrega.Caption = "FechaCitaEntrega"
        Me.FechaCitaEntrega.FieldName = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Name = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Visible = True
        Me.FechaCitaEntrega.VisibleIndex = 26
        '
        'HoraCita
        '
        Me.HoraCita.Caption = "HoraCita"
        Me.HoraCita.FieldName = "HoraCita"
        Me.HoraCita.Name = "HoraCita"
        Me.HoraCita.Visible = True
        Me.HoraCita.VisibleIndex = 27
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdPartidas
        Me.grdDetallesOT.Name = "grdDetallesOT"
        Me.grdDetallesOT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDetallesOT.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDetallesOT.OptionsSelection.MultiSelect = True
        Me.grdDetallesOT.OptionsView.ColumnAutoWidth = False
        Me.grdDetallesOT.OptionsView.ShowAutoFilterRow = True
        Me.grdDetallesOT.OptionsView.ShowFooter = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1028, 92)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'CancelacionPartidasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 498)
        Me.Controls.Add(Me.grdPartidas)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "CancelacionPartidasForm"
        Me.Text = "Cancelación de Partidas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPedidoCompleto As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents lblTextoAgente As System.Windows.Forms.Label
    Friend WithEvents lblTextoEntregaCliente As System.Windows.Forms.Label
    Friend WithEvents lblEntregaCliente As System.Windows.Forms.Label
    Friend WithEvents lblAgente As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoEstatus As System.Windows.Forms.Label
    Friend WithEvents lblTextoFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblTextoMarca As System.Windows.Forms.Label
    Friend WithEvents lblTextoObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblObsrvaciones As System.Windows.Forms.Label
    Friend WithEvents lblMarcas As System.Windows.Forms.Label
    Friend WithEvents lblTextoOrden As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents lblTextoRFC As System.Windows.Forms.Label
    Friend WithEvents lblTextoCaptura As System.Windows.Forms.Label
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblCaptura As System.Windows.Forms.Label
    Friend WithEvents grdPartidas As DevExpress.XtraGrid.GridControl
    Friend WithEvents ViewPartidas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OTSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Agente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoOT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrdenCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaEntregaProgramacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPreparacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Confirmados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PorConfirmar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cancelados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioModifico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaModificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiasFaltantes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MotivoCancelacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EstatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Observaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCitaEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblNoFacturado As System.Windows.Forms.Label
    Friend WithEvents pnlEntregaVencida As System.Windows.Forms.Panel
    Friend WithEvents chkboxSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
