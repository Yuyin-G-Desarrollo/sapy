<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalidasCoppelForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblDetallesSalida = New System.Windows.Forms.Label()
        Me.btnDetallesSalida = New System.Windows.Forms.Button()
        Me.btnGenerarSalida = New System.Windows.Forms.Button()
        Me.lblGenerarSalida = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.pnlFechas = New System.Windows.Forms.Panel()
        Me.lblFiltroFechas = New System.Windows.Forms.Label()
        Me.chkFiltroFechas = New System.Windows.Forms.CheckBox()
        Me.pnlFiltroFecha = New System.Windows.Forms.Panel()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblFechaE = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.cmbTienda = New System.Windows.Forms.ComboBox()
        Me.lblTienda = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.cmbEstatusSalida = New System.Windows.Forms.ComboBox()
        Me.lblestatus = New System.Windows.Forms.Label()
        Me.pnlMostrar = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.grdSalidas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpParametros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlFechas.SuspendLayout()
        Me.pnlFiltroFecha.SuspendLayout()
        Me.pnlMostrar.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        CType(Me.grdSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblDetallesSalida)
        Me.pnlEncabezado.Controls.Add(Me.btnDetallesSalida)
        Me.pnlEncabezado.Controls.Add(Me.btnGenerarSalida)
        Me.pnlEncabezado.Controls.Add(Me.lblGenerarSalida)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitle)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(853, 64)
        Me.pnlEncabezado.TabIndex = 0
        '
        'lblDetallesSalida
        '
        Me.lblDetallesSalida.AutoSize = True
        Me.lblDetallesSalida.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetallesSalida.Location = New System.Drawing.Point(114, 43)
        Me.lblDetallesSalida.Name = "lblDetallesSalida"
        Me.lblDetallesSalida.Size = New System.Drawing.Size(92, 13)
        Me.lblDetallesSalida.TabIndex = 2
        Me.lblDetallesSalida.Text = "Consultar Detalles"
        '
        'btnDetallesSalida
        '
        Me.btnDetallesSalida.Image = Global.Almacen.Vista.My.Resources.Resources.catalogos_32
        Me.btnDetallesSalida.Location = New System.Drawing.Point(146, 8)
        Me.btnDetallesSalida.Name = "btnDetallesSalida"
        Me.btnDetallesSalida.Size = New System.Drawing.Size(32, 32)
        Me.btnDetallesSalida.TabIndex = 2
        Me.btnDetallesSalida.UseVisualStyleBackColor = True
        '
        'btnGenerarSalida
        '
        Me.btnGenerarSalida.Image = Global.Almacen.Vista.My.Resources.Resources.carritos
        Me.btnGenerarSalida.Location = New System.Drawing.Point(37, 8)
        Me.btnGenerarSalida.Name = "btnGenerarSalida"
        Me.btnGenerarSalida.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarSalida.TabIndex = 2
        Me.btnGenerarSalida.UseVisualStyleBackColor = True
        '
        'lblGenerarSalida
        '
        Me.lblGenerarSalida.AutoSize = True
        Me.lblGenerarSalida.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarSalida.Location = New System.Drawing.Point(17, 43)
        Me.lblGenerarSalida.Name = "lblGenerarSalida"
        Me.lblGenerarSalida.Size = New System.Drawing.Size(77, 13)
        Me.lblGenerarSalida.TabIndex = 2
        Me.lblGenerarSalida.Text = "Generar Salida"
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(636, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(217, 64)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(3, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(129, 20)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Salidas Coppel"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(140, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(77, 64)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlMinimizarParametros.Controls.Add(Me.Panel1)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(0, 64)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(853, 24)
        Me.pnlMinimizarParametros.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(785, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(68, 24)
        Me.Panel1.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = Global.Almacen.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(38, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = Global.Almacen.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(12, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.Panel3)
        Me.grpParametros.Controls.Add(Me.pnlMostrar)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 88)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(853, 126)
        Me.grpParametros.TabIndex = 2
        Me.grpParametros.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.chkSeleccionar)
        Me.Panel3.Controls.Add(Me.pnlFechas)
        Me.Panel3.Controls.Add(Me.pnlFiltroFecha)
        Me.Panel3.Controls.Add(Me.lblFechaE)
        Me.Panel3.Controls.Add(Me.lblFechaEntrega)
        Me.Panel3.Controls.Add(Me.cmbTienda)
        Me.Panel3.Controls.Add(Me.lblTienda)
        Me.Panel3.Controls.Add(Me.txtPedido)
        Me.Panel3.Controls.Add(Me.lblPedido)
        Me.Panel3.Controls.Add(Me.cmbEstatusSalida)
        Me.Panel3.Controls.Add(Me.lblestatus)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(3, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(728, 107)
        Me.Panel3.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Seleccionar todo"
        Me.Label2.Visible = False
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(101, 87)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(15, 14)
        Me.chkSeleccionar.TabIndex = 10
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        Me.chkSeleccionar.Visible = False
        '
        'pnlFechas
        '
        Me.pnlFechas.Controls.Add(Me.lblFiltroFechas)
        Me.pnlFechas.Controls.Add(Me.chkFiltroFechas)
        Me.pnlFechas.Location = New System.Drawing.Point(3, 51)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.Size = New System.Drawing.Size(129, 50)
        Me.pnlFechas.TabIndex = 8
        '
        'lblFiltroFechas
        '
        Me.lblFiltroFechas.AutoSize = True
        Me.lblFiltroFechas.Location = New System.Drawing.Point(6, 5)
        Me.lblFiltroFechas.Name = "lblFiltroFechas"
        Me.lblFiltroFechas.Size = New System.Drawing.Size(82, 26)
        Me.lblFiltroFechas.TabIndex = 7
        Me.lblFiltroFechas.Text = "Filtro por fechas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de salida"
        '
        'chkFiltroFechas
        '
        Me.chkFiltroFechas.AutoSize = True
        Me.chkFiltroFechas.Location = New System.Drawing.Point(98, 11)
        Me.chkFiltroFechas.Name = "chkFiltroFechas"
        Me.chkFiltroFechas.Size = New System.Drawing.Size(15, 14)
        Me.chkFiltroFechas.TabIndex = 6
        Me.chkFiltroFechas.UseVisualStyleBackColor = True
        '
        'pnlFiltroFecha
        '
        Me.pnlFiltroFecha.Controls.Add(Me.dtpFechaInicio)
        Me.pnlFiltroFecha.Controls.Add(Me.dtpFechaFin)
        Me.pnlFiltroFecha.Controls.Add(Me.lblFechaInicio)
        Me.pnlFiltroFecha.Controls.Add(Me.lblFechaFin)
        Me.pnlFiltroFecha.Location = New System.Drawing.Point(138, 51)
        Me.pnlFiltroFecha.Name = "pnlFiltroFecha"
        Me.pnlFiltroFecha.Size = New System.Drawing.Size(586, 53)
        Me.pnlFiltroFecha.TabIndex = 8
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(80, 10)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(201, 20)
        Me.dtpFechaInicio.TabIndex = 1
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Location = New System.Drawing.Point(367, 10)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(201, 20)
        Me.dtpFechaFin.TabIndex = 3
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(8, 12)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaInicio.TabIndex = 0
        Me.lblFechaInicio.Text = "Fecha Inicio:"
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Location = New System.Drawing.Point(304, 12)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(57, 13)
        Me.lblFechaFin.TabIndex = 2
        Me.lblFechaFin.Text = "Fecha Fin:"
        '
        'lblFechaE
        '
        Me.lblFechaE.AutoSize = True
        Me.lblFechaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblFechaE.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblFechaE.Location = New System.Drawing.Point(94, 34)
        Me.lblFechaE.Name = "lblFechaE"
        Me.lblFechaE.Size = New System.Drawing.Size(109, 16)
        Me.lblFechaE.TabIndex = 6
        Me.lblFechaE.Text = "Fecha Entrega"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(11, 37)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(80, 13)
        Me.lblFechaEntrega.TabIndex = 7
        Me.lblFechaEntrega.Text = "Fecha Entrega:"
        '
        'cmbTienda
        '
        Me.cmbTienda.FormattingEnabled = True
        Me.cmbTienda.Location = New System.Drawing.Point(443, 10)
        Me.cmbTienda.Name = "cmbTienda"
        Me.cmbTienda.Size = New System.Drawing.Size(250, 21)
        Me.cmbTienda.TabIndex = 5
        '
        'lblTienda
        '
        Me.lblTienda.AutoSize = True
        Me.lblTienda.Location = New System.Drawing.Point(394, 14)
        Me.lblTienda.Name = "lblTienda"
        Me.lblTienda.Size = New System.Drawing.Size(43, 13)
        Me.lblTienda.TabIndex = 4
        Me.lblTienda.Text = "Tienda:"
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(250, 10)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(138, 20)
        Me.txtPedido.TabIndex = 3
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Location = New System.Drawing.Point(201, 14)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(43, 13)
        Me.lblPedido.TabIndex = 3
        Me.lblPedido.Text = "Pedido:"
        '
        'cmbEstatusSalida
        '
        Me.cmbEstatusSalida.FormattingEnabled = True
        Me.cmbEstatusSalida.Items.AddRange(New Object() {"", "CON SALIDA", "SIN SALIDA"})
        Me.cmbEstatusSalida.Location = New System.Drawing.Point(52, 10)
        Me.cmbEstatusSalida.Name = "cmbEstatusSalida"
        Me.cmbEstatusSalida.Size = New System.Drawing.Size(134, 21)
        Me.cmbEstatusSalida.TabIndex = 3
        '
        'lblestatus
        '
        Me.lblestatus.AutoSize = True
        Me.lblestatus.Location = New System.Drawing.Point(9, 13)
        Me.lblestatus.Name = "lblestatus"
        Me.lblestatus.Size = New System.Drawing.Size(45, 13)
        Me.lblestatus.TabIndex = 3
        Me.lblestatus.Text = "Estatus:"
        '
        'pnlMostrar
        '
        Me.pnlMostrar.Controls.Add(Me.lblLimpiar)
        Me.pnlMostrar.Controls.Add(Me.lblMostrar)
        Me.pnlMostrar.Controls.Add(Me.btnLimpiar)
        Me.pnlMostrar.Controls.Add(Me.btnMostrar)
        Me.pnlMostrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMostrar.Location = New System.Drawing.Point(737, 16)
        Me.pnlMostrar.Name = "pnlMostrar"
        Me.pnlMostrar.Size = New System.Drawing.Size(113, 107)
        Me.pnlMostrar.TabIndex = 0
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(68, 38)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 3
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(10, 38)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 2
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(71, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 1
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(13, 3)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.lblTotalPares)
        Me.pnlPie.Controls.Add(Me.pnlSalir)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 536)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(853, 56)
        Me.pnlPie.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Seleccionados"
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.AutoSize = True
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTotalRegistros.Location = New System.Drawing.Point(36, 36)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalRegistros.TabIndex = 5
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(20, 6)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(60, 13)
        Me.lblTotalPares.TabIndex = 6
        Me.lblTotalPares.Text = "Registros"
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.btnSalir)
        Me.pnlSalir.Controls.Add(Me.lblSalir)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(785, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(68, 56)
        Me.pnlSalir.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(19, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(18, 37)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 0
        Me.lblSalir.Text = "Cerrar"
        '
        'grdSalidas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSalidas.DisplayLayout.Appearance = Appearance1
        Me.grdSalidas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSalidas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdSalidas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSalidas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdSalidas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSalidas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdSalidas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSalidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSalidas.Location = New System.Drawing.Point(0, 214)
        Me.grdSalidas.Name = "grdSalidas"
        Me.grdSalidas.Size = New System.Drawing.Size(853, 322)
        Me.grdSalidas.TabIndex = 4
        '
        'BackgroundWorker1
        '
        '
        'SalidasCoppelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(853, 592)
        Me.Controls.Add(Me.grdSalidas)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.pnlMinimizarParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "SalidasCoppelForm"
        Me.Text = " "
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpParametros.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlFechas.ResumeLayout(False)
        Me.pnlFechas.PerformLayout()
        Me.pnlFiltroFecha.ResumeLayout(False)
        Me.pnlFiltroFecha.PerformLayout()
        Me.pnlMostrar.ResumeLayout(False)
        Me.pnlMostrar.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        CType(Me.grdSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblGenerarSalida As System.Windows.Forms.Label
    Friend WithEvents btnGenerarSalida As System.Windows.Forms.Button
    Friend WithEvents btnDetallesSalida As System.Windows.Forms.Button
    Friend WithEvents lblDetallesSalida As System.Windows.Forms.Label
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMostrar As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbTienda As System.Windows.Forms.ComboBox
    Friend WithEvents lblTienda As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents cmbEstatusSalida As System.Windows.Forms.ComboBox
    Friend WithEvents lblestatus As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents grdSalidas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents lblFechaE As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lblFiltroFechas As System.Windows.Forms.Label
    Friend WithEvents chkFiltroFechas As System.Windows.Forms.CheckBox
    Friend WithEvents pnlFechas As System.Windows.Forms.Panel
    Friend WithEvents pnlFiltroFecha As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
