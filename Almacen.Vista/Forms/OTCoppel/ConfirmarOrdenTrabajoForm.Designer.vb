<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmarOrdenTrabajoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmarOrdenTrabajoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.lblQuitarPares = New System.Windows.Forms.Label()
        Me.btnQuitarPares = New System.Windows.Forms.Button()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.btnTerminal = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.lblDetener = New System.Windows.Forms.Label()
        Me.lblIniciar = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblNotaCodigoInvalido = New System.Windows.Forms.Label()
        Me.lblCorrectos = New System.Windows.Forms.Label()
        Me.pnlCorrectos = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblExternos = New System.Windows.Forms.Label()
        Me.pnlExternos = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalExternos = New System.Windows.Forms.Label()
        Me.lblTotalCorrectos = New System.Windows.Forms.Label()
        Me.lblPorConfirmar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalConfirmados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblTotalP = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblParInvalido = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTiendaCompleta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblIdPedido = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.lblIdOrden = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.lblMensajeCapturaCodigos = New System.Windows.Forms.Label()
        Me.txtCapturaCodigos = New System.Windows.Forms.TextBox()
        Me.lblCaptura = New System.Windows.Forms.Label()
        Me.lblNombreTienda = New System.Windows.Forms.Label()
        Me.lblTienda = New System.Windows.Forms.Label()
        Me.pnlDetallePares = New System.Windows.Forms.Panel()
        Me.pnlGrids = New System.Windows.Forms.Panel()
        Me.sPCConfirmacionOrdenesTrabajo = New System.Windows.Forms.SplitContainer()
        Me.grdTotalPares = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmar = New System.Windows.Forms.SplitContainer()
        Me.grdParesPorConfirmar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmadosAnteriormente = New System.Windows.Forms.SplitContainer()
        Me.lblParesConfirmadosAnteriormente = New System.Windows.Forms.Label()
        Me.grdParesConfirmadosAnteriormente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlCorrectos.SuspendLayout()
        Me.pnlExternos.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlGrids.SuspendLayout()
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.SuspendLayout()
        CType(Me.grdTotalPares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmar.Panel1.SuspendLayout()
        Me.sPCParesConfirmar.Panel2.SuspendLayout()
        Me.sPCParesConfirmar.SuspendLayout()
        CType(Me.grdParesPorConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.SuspendLayout()
        CType(Me.grdParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitle)
        Me.pnlHeader.Controls.Add(Me.pnlBtn)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1283, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitulo)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(836, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(447, 70)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(363, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Confirmación de Ordenes de Trabajo Coppel"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(377, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 70)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.btnExportar)
        Me.pnlBtn.Controls.Add(Me.lblExportar)
        Me.pnlBtn.Controls.Add(Me.lblQuitarPares)
        Me.pnlBtn.Controls.Add(Me.btnQuitarPares)
        Me.pnlBtn.Controls.Add(Me.lblTerminal)
        Me.pnlBtn.Controls.Add(Me.btnTerminal)
        Me.pnlBtn.Controls.Add(Me.btnIniciar)
        Me.pnlBtn.Controls.Add(Me.btnDetener)
        Me.pnlBtn.Controls.Add(Me.lblDetener)
        Me.pnlBtn.Controls.Add(Me.lblIniciar)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(312, 70)
        Me.pnlBtn.TabIndex = 1
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(190, 11)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(173, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(67, 26)
        Me.lblExportar.TabIndex = 32
        Me.lblExportar.Text = "    Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " confirmados"
        '
        'lblQuitarPares
        '
        Me.lblQuitarPares.AutoSize = True
        Me.lblQuitarPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuitarPares.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQuitarPares.Location = New System.Drawing.Point(245, 46)
        Me.lblQuitarPares.Name = "lblQuitarPares"
        Me.lblQuitarPares.Size = New System.Drawing.Size(65, 13)
        Me.lblQuitarPares.TabIndex = 5
        Me.lblQuitarPares.Text = "Quitar Pares"
        Me.lblQuitarPares.Visible = False
        '
        'btnQuitarPares
        '
        Me.btnQuitarPares.Image = Global.Almacen.Vista.My.Resources.Resources.rechazar_32
        Me.btnQuitarPares.Location = New System.Drawing.Point(259, 11)
        Me.btnQuitarPares.Name = "btnQuitarPares"
        Me.btnQuitarPares.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitarPares.TabIndex = 3
        Me.btnQuitarPares.UseVisualStyleBackColor = True
        Me.btnQuitarPares.Visible = False
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTerminal.Location = New System.Drawing.Point(125, 46)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(47, 13)
        Me.lblTerminal.TabIndex = 2
        Me.lblTerminal.Text = "Terminal"
        '
        'btnTerminal
        '
        Me.btnTerminal.Image = Global.Almacen.Vista.My.Resources.Resources.calculo_32
        Me.btnTerminal.Location = New System.Drawing.Point(132, 11)
        Me.btnTerminal.Name = "btnTerminal"
        Me.btnTerminal.Size = New System.Drawing.Size(32, 32)
        Me.btnTerminal.TabIndex = 3
        Me.btnTerminal.UseVisualStyleBackColor = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Image = CType(resources.GetObject("btnIniciar.Image"), System.Drawing.Image)
        Me.btnIniciar.Location = New System.Drawing.Point(9, 11)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(32, 32)
        Me.btnIniciar.TabIndex = 1
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'btnDetener
        '
        Me.btnDetener.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar321
        Me.btnDetener.Location = New System.Drawing.Point(71, 11)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(32, 32)
        Me.btnDetener.TabIndex = 2
        Me.btnDetener.UseVisualStyleBackColor = True
        '
        'lblDetener
        '
        Me.lblDetener.AutoSize = True
        Me.lblDetener.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetener.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDetener.Location = New System.Drawing.Point(65, 46)
        Me.lblDetener.Name = "lblDetener"
        Me.lblDetener.Size = New System.Drawing.Size(45, 13)
        Me.lblDetener.TabIndex = 2
        Me.lblDetener.Text = "Detener"
        '
        'lblIniciar
        '
        Me.lblIniciar.AutoSize = True
        Me.lblIniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIniciar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblIniciar.Location = New System.Drawing.Point(8, 46)
        Me.lblIniciar.Name = "lblIniciar"
        Me.lblIniciar.Size = New System.Drawing.Size(35, 13)
        Me.lblIniciar.TabIndex = 2
        Me.lblIniciar.Text = "Iniciar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblNotaCodigoInvalido)
        Me.pnlPie.Controls.Add(Me.lblCorrectos)
        Me.pnlPie.Controls.Add(Me.pnlCorrectos)
        Me.pnlPie.Controls.Add(Me.lblExternos)
        Me.pnlPie.Controls.Add(Me.pnlExternos)
        Me.pnlPie.Controls.Add(Me.lblTotalExternos)
        Me.pnlPie.Controls.Add(Me.lblTotalCorrectos)
        Me.pnlPie.Controls.Add(Me.lblPorConfirmar)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.lblTotalConfirmados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.lblTotalPares)
        Me.pnlPie.Controls.Add(Me.lblTotalP)
        Me.pnlPie.Controls.Add(Me.pnlSalir)
        Me.pnlPie.Controls.Add(Me.lblParInvalido)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.lblTiendaCompleta)
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 533)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1283, 61)
        Me.pnlPie.TabIndex = 1
        '
        'lblNotaCodigoInvalido
        '
        Me.lblNotaCodigoInvalido.AutoSize = True
        Me.lblNotaCodigoInvalido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNotaCodigoInvalido.ForeColor = System.Drawing.Color.Black
        Me.lblNotaCodigoInvalido.Location = New System.Drawing.Point(153, 38)
        Me.lblNotaCodigoInvalido.Name = "lblNotaCodigoInvalido"
        Me.lblNotaCodigoInvalido.Size = New System.Drawing.Size(341, 13)
        Me.lblNotaCodigoInvalido.TabIndex = 18
        Me.lblNotaCodigoInvalido.Text = "Código inválido: El código no existe o ya está confirmado en otra orden"
        '
        'lblCorrectos
        '
        Me.lblCorrectos.AutoSize = True
        Me.lblCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectos.Location = New System.Drawing.Point(626, 38)
        Me.lblCorrectos.Name = "lblCorrectos"
        Me.lblCorrectos.Size = New System.Drawing.Size(52, 13)
        Me.lblCorrectos.TabIndex = 17
        Me.lblCorrectos.Text = "Correctos"
        '
        'pnlCorrectos
        '
        Me.pnlCorrectos.BackColor = System.Drawing.Color.Green
        Me.pnlCorrectos.Controls.Add(Me.Label8)
        Me.pnlCorrectos.Location = New System.Drawing.Point(605, 36)
        Me.pnlCorrectos.Name = "pnlCorrectos"
        Me.pnlCorrectos.Size = New System.Drawing.Size(13, 15)
        Me.pnlCorrectos.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "C"
        '
        'lblExternos
        '
        Me.lblExternos.AutoSize = True
        Me.lblExternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExternos.Location = New System.Drawing.Point(626, 11)
        Me.lblExternos.Name = "lblExternos"
        Me.lblExternos.Size = New System.Drawing.Size(48, 13)
        Me.lblExternos.TabIndex = 15
        Me.lblExternos.Text = "Externos"
        '
        'pnlExternos
        '
        Me.pnlExternos.BackColor = System.Drawing.Color.Red
        Me.pnlExternos.Controls.Add(Me.Label7)
        Me.pnlExternos.Location = New System.Drawing.Point(605, 9)
        Me.pnlExternos.Name = "pnlExternos"
        Me.pnlExternos.Size = New System.Drawing.Size(13, 15)
        Me.pnlExternos.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "E"
        '
        'lblTotalExternos
        '
        Me.lblTotalExternos.AutoSize = True
        Me.lblTotalExternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalExternos.ForeColor = System.Drawing.Color.Red
        Me.lblTotalExternos.Location = New System.Drawing.Point(684, 12)
        Me.lblTotalExternos.Name = "lblTotalExternos"
        Me.lblTotalExternos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalExternos.TabIndex = 13
        Me.lblTotalExternos.Text = "0"
        '
        'lblTotalCorrectos
        '
        Me.lblTotalCorrectos.AutoSize = True
        Me.lblTotalCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCorrectos.ForeColor = System.Drawing.Color.Green
        Me.lblTotalCorrectos.Location = New System.Drawing.Point(684, 39)
        Me.lblTotalCorrectos.Name = "lblTotalCorrectos"
        Me.lblTotalCorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalCorrectos.TabIndex = 12
        Me.lblTotalCorrectos.Text = "0"
        '
        'lblPorConfirmar
        '
        Me.lblPorConfirmar.AutoSize = True
        Me.lblPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorConfirmar.ForeColor = System.Drawing.Color.Red
        Me.lblPorConfirmar.Location = New System.Drawing.Point(1085, 44)
        Me.lblPorConfirmar.Name = "lblPorConfirmar"
        Me.lblPorConfirmar.Size = New System.Drawing.Size(14, 13)
        Me.lblPorConfirmar.TabIndex = 11
        Me.lblPorConfirmar.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(885, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Total de pares por confirmar"
        '
        'lblTotalConfirmados
        '
        Me.lblTotalConfirmados.AutoSize = True
        Me.lblTotalConfirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConfirmados.ForeColor = System.Drawing.Color.Green
        Me.lblTotalConfirmados.Location = New System.Drawing.Point(1085, 26)
        Me.lblTotalConfirmados.Name = "lblTotalConfirmados"
        Me.lblTotalConfirmados.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalConfirmados.TabIndex = 9
        Me.lblTotalConfirmados.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(887, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Total de pares confirmados:"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPares.Location = New System.Drawing.Point(1085, 7)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 7
        Me.lblTotalPares.Text = "0"
        '
        'lblTotalP
        '
        Me.lblTotalP.AutoSize = True
        Me.lblTotalP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalP.Location = New System.Drawing.Point(920, 7)
        Me.lblTotalP.Name = "lblTotalP"
        Me.lblTotalP.Size = New System.Drawing.Size(132, 13)
        Me.lblTotalP.TabIndex = 6
        Me.lblTotalP.Text = "Total de pares tienda:"
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.lblGuardar)
        Me.pnlSalir.Controls.Add(Me.btnGuardar)
        Me.pnlSalir.Controls.Add(Me.lblLimpiar)
        Me.pnlSalir.Controls.Add(Me.btnLimpiar)
        Me.pnlSalir.Controls.Add(Me.lblSalir)
        Me.pnlSalir.Controls.Add(Me.btnSalir)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(1115, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(168, 61)
        Me.pnlSalir.TabIndex = 9
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(66, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 35
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(71, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(19, 44)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 5
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(23, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(117, 43)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 1
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(117, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblParInvalido
        '
        Me.lblParInvalido.AutoSize = True
        Me.lblParInvalido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParInvalido.Location = New System.Drawing.Point(44, 38)
        Me.lblParInvalido.Name = "lblParInvalido"
        Me.lblParInvalido.Size = New System.Drawing.Size(63, 13)
        Me.lblParInvalido.TabIndex = 3
        Me.lblParInvalido.Text = "Par Inválido"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Tomato
        Me.Panel2.Location = New System.Drawing.Point(23, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(13, 15)
        Me.Panel2.TabIndex = 2
        '
        'lblTiendaCompleta
        '
        Me.lblTiendaCompleta.AutoSize = True
        Me.lblTiendaCompleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaCompleta.Location = New System.Drawing.Point(44, 11)
        Me.lblTiendaCompleta.Name = "lblTiendaCompleta"
        Me.lblTiendaCompleta.Size = New System.Drawing.Size(95, 13)
        Me.lblTiendaCompleta.TabIndex = 1
        Me.lblTiendaCompleta.Text = "Tienda Incompleta"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Location = New System.Drawing.Point(23, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(13, 15)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblIdPedido)
        Me.Panel3.Controls.Add(Me.lblPedido)
        Me.Panel3.Controls.Add(Me.lblIdOrden)
        Me.Panel3.Controls.Add(Me.lblOrden)
        Me.Panel3.Controls.Add(Me.lblMensajeCapturaCodigos)
        Me.Panel3.Controls.Add(Me.txtCapturaCodigos)
        Me.Panel3.Controls.Add(Me.lblCaptura)
        Me.Panel3.Controls.Add(Me.lblNombreTienda)
        Me.Panel3.Controls.Add(Me.lblTienda)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1283, 44)
        Me.Panel3.TabIndex = 5
        '
        'lblIdPedido
        '
        Me.lblIdPedido.AutoSize = True
        Me.lblIdPedido.Location = New System.Drawing.Point(529, 16)
        Me.lblIdPedido.Name = "lblIdPedido"
        Me.lblIdPedido.Size = New System.Drawing.Size(52, 13)
        Me.lblIdPedido.TabIndex = 9
        Me.lblIdPedido.Text = "Id Pedido"
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedido.Location = New System.Drawing.Point(472, 16)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(50, 13)
        Me.lblPedido.TabIndex = 8
        Me.lblPedido.Text = "Pedido:"
        '
        'lblIdOrden
        '
        Me.lblIdOrden.AutoSize = True
        Me.lblIdOrden.Location = New System.Drawing.Point(307, 16)
        Me.lblIdOrden.Name = "lblIdOrden"
        Me.lblIdOrden.Size = New System.Drawing.Size(48, 13)
        Me.lblIdOrden.TabIndex = 7
        Me.lblIdOrden.Text = "Id Orden"
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(250, 16)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(45, 13)
        Me.lblOrden.TabIndex = 6
        Me.lblOrden.Text = "Orden:"
        '
        'lblMensajeCapturaCodigos
        '
        Me.lblMensajeCapturaCodigos.AutoSize = True
        Me.lblMensajeCapturaCodigos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCapturaCodigos.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeCapturaCodigos.Location = New System.Drawing.Point(1012, 16)
        Me.lblMensajeCapturaCodigos.Name = "lblMensajeCapturaCodigos"
        Me.lblMensajeCapturaCodigos.Size = New System.Drawing.Size(102, 16)
        Me.lblMensajeCapturaCodigos.TabIndex = 5
        Me.lblMensajeCapturaCodigos.Text = "Código inválido"
        Me.lblMensajeCapturaCodigos.Visible = False
        '
        'txtCapturaCodigos
        '
        Me.txtCapturaCodigos.Location = New System.Drawing.Point(812, 13)
        Me.txtCapturaCodigos.Name = "txtCapturaCodigos"
        Me.txtCapturaCodigos.Size = New System.Drawing.Size(172, 20)
        Me.txtCapturaCodigos.TabIndex = 5
        '
        'lblCaptura
        '
        Me.lblCaptura.AutoSize = True
        Me.lblCaptura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptura.Location = New System.Drawing.Point(689, 16)
        Me.lblCaptura.Name = "lblCaptura"
        Me.lblCaptura.Size = New System.Drawing.Size(117, 13)
        Me.lblCaptura.TabIndex = 3
        Me.lblCaptura.Text = "Captura de códigos"
        '
        'lblNombreTienda
        '
        Me.lblNombreTienda.AutoSize = True
        Me.lblNombreTienda.Location = New System.Drawing.Point(69, 16)
        Me.lblNombreTienda.Name = "lblNombreTienda"
        Me.lblNombreTienda.Size = New System.Drawing.Size(80, 13)
        Me.lblNombreTienda.TabIndex = 4
        Me.lblNombreTienda.Text = "Nombre Tienda"
        '
        'lblTienda
        '
        Me.lblTienda.AutoSize = True
        Me.lblTienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTienda.Location = New System.Drawing.Point(12, 16)
        Me.lblTienda.Name = "lblTienda"
        Me.lblTienda.Size = New System.Drawing.Size(50, 13)
        Me.lblTienda.TabIndex = 3
        Me.lblTienda.Text = "Tienda:"
        '
        'pnlDetallePares
        '
        Me.pnlDetallePares.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDetallePares.Location = New System.Drawing.Point(0, 523)
        Me.pnlDetallePares.Name = "pnlDetallePares"
        Me.pnlDetallePares.Size = New System.Drawing.Size(1283, 10)
        Me.pnlDetallePares.TabIndex = 5
        '
        'pnlGrids
        '
        Me.pnlGrids.Controls.Add(Me.sPCConfirmacionOrdenesTrabajo)
        Me.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrids.Location = New System.Drawing.Point(0, 114)
        Me.pnlGrids.Name = "pnlGrids"
        Me.pnlGrids.Size = New System.Drawing.Size(1283, 409)
        Me.pnlGrids.TabIndex = 6
        '
        'sPCConfirmacionOrdenesTrabajo
        '
        Me.sPCConfirmacionOrdenesTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPCConfirmacionOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPCConfirmacionOrdenesTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.sPCConfirmacionOrdenesTrabajo.Name = "sPCConfirmacionOrdenesTrabajo"
        '
        'sPCConfirmacionOrdenesTrabajo.Panel1
        '
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.Controls.Add(Me.grdTotalPares)
        '
        'sPCConfirmacionOrdenesTrabajo.Panel2
        '
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.Controls.Add(Me.sPCParesConfirmar)
        Me.sPCConfirmacionOrdenesTrabajo.Size = New System.Drawing.Size(1283, 409)
        Me.sPCConfirmacionOrdenesTrabajo.SplitterDistance = 560
        Me.sPCConfirmacionOrdenesTrabajo.TabIndex = 0
        '
        'grdTotalPares
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTotalPares.DisplayLayout.Appearance = Appearance1
        Me.grdTotalPares.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTotalPares.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTotalPares.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTotalPares.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTotalPares.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTotalPares.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTotalPares.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdTotalPares.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTotalPares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTotalPares.Location = New System.Drawing.Point(0, 0)
        Me.grdTotalPares.Name = "grdTotalPares"
        Me.grdTotalPares.Size = New System.Drawing.Size(558, 407)
        Me.grdTotalPares.TabIndex = 6
        '
        'sPCParesConfirmar
        '
        Me.sPCParesConfirmar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPCParesConfirmar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPCParesConfirmar.Location = New System.Drawing.Point(0, 0)
        Me.sPCParesConfirmar.Name = "sPCParesConfirmar"
        Me.sPCParesConfirmar.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'sPCParesConfirmar.Panel1
        '
        Me.sPCParesConfirmar.Panel1.Controls.Add(Me.grdParesPorConfirmar)
        Me.sPCParesConfirmar.Panel1MinSize = 0
        '
        'sPCParesConfirmar.Panel2
        '
        Me.sPCParesConfirmar.Panel2.Controls.Add(Me.sPCParesConfirmadosAnteriormente)
        Me.sPCParesConfirmar.Panel2MinSize = 0
        Me.sPCParesConfirmar.Size = New System.Drawing.Size(719, 409)
        Me.sPCParesConfirmar.SplitterDistance = 189
        Me.sPCParesConfirmar.TabIndex = 0
        '
        'grdParesPorConfirmar
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesPorConfirmar.DisplayLayout.Appearance = Appearance3
        Me.grdParesPorConfirmar.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesPorConfirmar.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdParesPorConfirmar.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesPorConfirmar.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesPorConfirmar.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesPorConfirmar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesPorConfirmar.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdParesPorConfirmar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesPorConfirmar.Location = New System.Drawing.Point(0, 0)
        Me.grdParesPorConfirmar.Name = "grdParesPorConfirmar"
        Me.grdParesPorConfirmar.Size = New System.Drawing.Size(717, 187)
        Me.grdParesPorConfirmar.TabIndex = 7
        '
        'sPCParesConfirmadosAnteriormente
        '
        Me.sPCParesConfirmadosAnteriormente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPCParesConfirmadosAnteriormente.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.sPCParesConfirmadosAnteriormente.IsSplitterFixed = True
        Me.sPCParesConfirmadosAnteriormente.Location = New System.Drawing.Point(0, 0)
        Me.sPCParesConfirmadosAnteriormente.Name = "sPCParesConfirmadosAnteriormente"
        Me.sPCParesConfirmadosAnteriormente.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'sPCParesConfirmadosAnteriormente.Panel1
        '
        Me.sPCParesConfirmadosAnteriormente.Panel1.Controls.Add(Me.lblParesConfirmadosAnteriormente)
        Me.sPCParesConfirmadosAnteriormente.Panel1MinSize = 15
        '
        'sPCParesConfirmadosAnteriormente.Panel2
        '
        Me.sPCParesConfirmadosAnteriormente.Panel2.Controls.Add(Me.grdParesConfirmadosAnteriormente)
        Me.sPCParesConfirmadosAnteriormente.Size = New System.Drawing.Size(717, 214)
        Me.sPCParesConfirmadosAnteriormente.SplitterDistance = 25
        Me.sPCParesConfirmadosAnteriormente.SplitterWidth = 1
        Me.sPCParesConfirmadosAnteriormente.TabIndex = 0
        '
        'lblParesConfirmadosAnteriormente
        '
        Me.lblParesConfirmadosAnteriormente.AutoSize = True
        Me.lblParesConfirmadosAnteriormente.Location = New System.Drawing.Point(0, 0)
        Me.lblParesConfirmadosAnteriormente.Name = "lblParesConfirmadosAnteriormente"
        Me.lblParesConfirmadosAnteriormente.Size = New System.Drawing.Size(161, 13)
        Me.lblParesConfirmadosAnteriormente.TabIndex = 1
        Me.lblParesConfirmadosAnteriormente.Text = "Pares confirmados anteriormente"
        '
        'grdParesConfirmadosAnteriormente
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Appearance = Appearance5
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdParesConfirmadosAnteriormente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesConfirmadosAnteriormente.Location = New System.Drawing.Point(0, 0)
        Me.grdParesConfirmadosAnteriormente.Name = "grdParesConfirmadosAnteriormente"
        Me.grdParesConfirmadosAnteriormente.Size = New System.Drawing.Size(717, 188)
        Me.grdParesConfirmadosAnteriormente.TabIndex = 8
        '
        'ConfirmarOrdenTrabajoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1283, 594)
        Me.Controls.Add(Me.pnlGrids)
        Me.Controls.Add(Me.pnlDetallePares)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConfirmarOrdenTrabajoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmación de Órdenes de Trabajo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtn.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlCorrectos.ResumeLayout(False)
        Me.pnlCorrectos.PerformLayout()
        Me.pnlExternos.ResumeLayout(False)
        Me.pnlExternos.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlGrids.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.ResumeLayout(False)
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCConfirmacionOrdenesTrabajo.ResumeLayout(False)
        CType(Me.grdTotalPares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmar.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.ResumeLayout(False)
        CType(Me.grdParesPorConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmadosAnteriormente.Panel1.PerformLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.ResumeLayout(False)
        CType(Me.grdParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblParInvalido As System.Windows.Forms.Label
    Friend WithEvents lblTiendaCompleta As System.Windows.Forms.Label
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents btnTerminal As System.Windows.Forms.Button
    Friend WithEvents lblDetener As System.Windows.Forms.Label
    Friend WithEvents lblIniciar As System.Windows.Forms.Label
    Friend WithEvents btnDetener As System.Windows.Forms.Button
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtCapturaCodigos As System.Windows.Forms.TextBox
    Friend WithEvents lblCaptura As System.Windows.Forms.Label
    Friend WithEvents lblNombreTienda As System.Windows.Forms.Label
    Friend WithEvents lblTienda As System.Windows.Forms.Label
    Friend WithEvents btnQuitarPares As System.Windows.Forms.Button
    Friend WithEvents lblQuitarPares As System.Windows.Forms.Label
    Friend WithEvents pnlDetallePares As System.Windows.Forms.Panel
    Friend WithEvents lblMensajeCapturaCodigos As System.Windows.Forms.Label
    Friend WithEvents lblIdPedido As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents lblIdOrden As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents pnlGrids As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents sPCConfirmacionOrdenesTrabajo As System.Windows.Forms.SplitContainer
    Friend WithEvents sPCParesConfirmar As System.Windows.Forms.SplitContainer
    Friend WithEvents grdParesPorConfirmar As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents sPCParesConfirmadosAnteriormente As System.Windows.Forms.SplitContainer
    Friend WithEvents lblParesConfirmadosAnteriormente As System.Windows.Forms.Label
    Friend WithEvents grdParesConfirmadosAnteriormente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdTotalPares As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalConfirmados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblTotalP As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCorrectos As System.Windows.Forms.Label
    Friend WithEvents pnlCorrectos As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents lblExternos As System.Windows.Forms.Label
    Friend WithEvents pnlExternos As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalExternos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblNotaCodigoInvalido As System.Windows.Forms.Label
End Class
