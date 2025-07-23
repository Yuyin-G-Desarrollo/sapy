<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmarApartado
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmarApartado))
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblNotaCodigoInvalido = New System.Windows.Forms.Label()
        Me.lblTotalExternos = New System.Windows.Forms.Label()
        Me.lblTotalCorrectos = New System.Windows.Forms.Label()
        Me.lblPorConfirmar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalConfirmados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblExternos = New System.Windows.Forms.Label()
        Me.pnlExternos = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCorrectos = New System.Windows.Forms.Label()
        Me.pnlCorrectos = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlGrids = New System.Windows.Forms.Panel()
        Me.sPCConfirmacionOrdenesTrabajo = New System.Windows.Forms.SplitContainer()
        Me.grdPartidasConfirmadasyPorConfirmar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmar = New System.Windows.Forms.SplitContainer()
        Me.grdParesConfirmandoActualmente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmadosAnteriormente = New System.Windows.Forms.SplitContainer()
        Me.lblParesConfirmadosAnteriormente = New System.Windows.Forms.Label()
        Me.grdParesConfirmadosAnteriormente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblEstatusApartado = New System.Windows.Forms.Label()
        Me.lblIdPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoTotalApartadosSeleccionados = New System.Windows.Forms.Label()
        Me.lblTotalApartadosSeleccionados = New System.Windows.Forms.Label()
        Me.lblFPreparacion = New System.Windows.Forms.Label()
        Me.lblTextoFPreparacion = New System.Windows.Forms.Label()
        Me.lblEntregaInmediata = New System.Windows.Forms.Label()
        Me.lblOrdenCliente = New System.Windows.Forms.Label()
        Me.lblTextoOrdenCliente = New System.Windows.Forms.Label()
        Me.lblFSolicitada = New System.Windows.Forms.Label()
        Me.lblTextoFSolicitada = New System.Windows.Forms.Label()
        Me.lblIdPedidoSAY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSAY = New System.Windows.Forms.Label()
        Me.lblIdApartadoSICY = New System.Windows.Forms.Label()
        Me.lblIdApartado = New System.Windows.Forms.Label()
        Me.lblTextoApartadoSICY = New System.Windows.Forms.Label()
        Me.lblTextoFolioApartado = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblTextoCliente = New System.Windows.Forms.Label()
        Me.pnlDetallePares = New System.Windows.Forms.Panel()
        Me.lblTotalP = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.lblTextoConsolidar = New System.Windows.Forms.Label()
        Me.btnConsolidar = New System.Windows.Forms.Button()
        Me.btnExportarDetalles = New System.Windows.Forms.Button()
        Me.lblTextoExportarDetalles = New System.Windows.Forms.Label()
        Me.lblTextoImprimirDetalles = New System.Windows.Forms.Label()
        Me.btnImprimirDetalles = New System.Windows.Forms.Button()
        Me.lblTextoVerPares = New System.Windows.Forms.Label()
        Me.lblTextoCancelarConfirmacionActual = New System.Windows.Forms.Label()
        Me.btnVerPares = New System.Windows.Forms.Button()
        Me.btnCancelarConfirmacion = New System.Windows.Forms.Button()
        Me.btnConfirmacionIncompleta = New System.Windows.Forms.Button()
        Me.lblTextoConfirmacionIncompleta = New System.Windows.Forms.Label()
        Me.btnExportarConfirmados = New System.Windows.Forms.Button()
        Me.lblTextoExistenciaDisponible = New System.Windows.Forms.Label()
        Me.lblTextoExportarConfirmados = New System.Windows.Forms.Label()
        Me.btnExistenciaDisponible = New System.Windows.Forms.Button()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.btnTerminal = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblCancelados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlPartidaCancelada = New System.Windows.Forms.Panel()
        Me.lblTotalCodigosInvalidos = New System.Windows.Forms.Label()
        Me.lblTextoCodigosInvalidos = New System.Windows.Forms.Label()
        Me.lblTextoApartadoAnterior = New System.Windows.Forms.Label()
        Me.lblTextoApartadoSiguiente = New System.Windows.Forms.Label()
        Me.btnAnteriorApartado = New System.Windows.Forms.Button()
        Me.btnSiguienteApartado = New System.Windows.Forms.Button()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblParInvalido = New System.Windows.Forms.Label()
        Me.pnlParExcedente = New System.Windows.Forms.Panel()
        Me.lblTiendaCompleta = New System.Windows.Forms.Label()
        Me.pnlColorPartidaIncompleta = New System.Windows.Forms.Panel()
        Me.pnlExternos.SuspendLayout()
        Me.pnlCorrectos.SuspendLayout()
        Me.pnlGrids.SuspendLayout()
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.SuspendLayout()
        CType(Me.grdPartidasConfirmadasyPorConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmar.Panel1.SuspendLayout()
        Me.sPCParesConfirmar.Panel2.SuspendLayout()
        Me.sPCParesConfirmar.SuspendLayout()
        CType(Me.grdParesConfirmandoActualmente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.SuspendLayout()
        CType(Me.grdParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.SuspendLayout()
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
        'lblNotaCodigoInvalido
        '
        Me.lblNotaCodigoInvalido.AutoSize = True
        Me.lblNotaCodigoInvalido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNotaCodigoInvalido.ForeColor = System.Drawing.Color.Black
        Me.lblNotaCodigoInvalido.Location = New System.Drawing.Point(153, 38)
        Me.lblNotaCodigoInvalido.Name = "lblNotaCodigoInvalido"
        Me.lblNotaCodigoInvalido.Size = New System.Drawing.Size(413, 13)
        Me.lblNotaCodigoInvalido.TabIndex = 18
        Me.lblNotaCodigoInvalido.Text = "Par inválido: El código no pertenece al apartado o ya está confirmado en un apart" & _
    "ado."
        Me.lblNotaCodigoInvalido.Visible = False
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
        Me.lblTotalExternos.Visible = False
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
        Me.lblTotalCorrectos.Visible = False
        '
        'lblPorConfirmar
        '
        Me.lblPorConfirmar.AutoSize = True
        Me.lblPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorConfirmar.ForeColor = System.Drawing.Color.Red
        Me.lblPorConfirmar.Location = New System.Drawing.Point(1085, 30)
        Me.lblPorConfirmar.Name = "lblPorConfirmar"
        Me.lblPorConfirmar.Size = New System.Drawing.Size(14, 13)
        Me.lblPorConfirmar.TabIndex = 11
        Me.lblPorConfirmar.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(881, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Total de pares por confirmar:"
        '
        'lblTotalConfirmados
        '
        Me.lblTotalConfirmados.AutoSize = True
        Me.lblTotalConfirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConfirmados.ForeColor = System.Drawing.Color.Green
        Me.lblTotalConfirmados.Location = New System.Drawing.Point(1085, 16)
        Me.lblTotalConfirmados.Name = "lblTotalConfirmados"
        Me.lblTotalConfirmados.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalConfirmados.TabIndex = 9
        Me.lblTotalConfirmados.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(887, 16)
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
        Me.lblTotalPares.Location = New System.Drawing.Point(1085, 3)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 7
        Me.lblTotalPares.Text = "0"
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
        Me.lblExternos.Visible = False
        '
        'pnlExternos
        '
        Me.pnlExternos.BackColor = System.Drawing.Color.Red
        Me.pnlExternos.Controls.Add(Me.Label7)
        Me.pnlExternos.Location = New System.Drawing.Point(605, 9)
        Me.pnlExternos.Name = "pnlExternos"
        Me.pnlExternos.Size = New System.Drawing.Size(13, 15)
        Me.pnlExternos.TabIndex = 14
        Me.pnlExternos.Visible = False
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
        'lblCorrectos
        '
        Me.lblCorrectos.AutoSize = True
        Me.lblCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectos.Location = New System.Drawing.Point(626, 38)
        Me.lblCorrectos.Name = "lblCorrectos"
        Me.lblCorrectos.Size = New System.Drawing.Size(52, 13)
        Me.lblCorrectos.TabIndex = 17
        Me.lblCorrectos.Text = "Correctos"
        Me.lblCorrectos.Visible = False
        '
        'pnlCorrectos
        '
        Me.pnlCorrectos.BackColor = System.Drawing.Color.Green
        Me.pnlCorrectos.Controls.Add(Me.Label8)
        Me.pnlCorrectos.Location = New System.Drawing.Point(605, 36)
        Me.pnlCorrectos.Name = "pnlCorrectos"
        Me.pnlCorrectos.Size = New System.Drawing.Size(13, 15)
        Me.pnlCorrectos.TabIndex = 16
        Me.pnlCorrectos.Visible = False
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
        'pnlGrids
        '
        Me.pnlGrids.Controls.Add(Me.sPCConfirmacionOrdenesTrabajo)
        Me.pnlGrids.Controls.Add(Me.Panel3)
        Me.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrids.Location = New System.Drawing.Point(0, 70)
        Me.pnlGrids.Name = "pnlGrids"
        Me.pnlGrids.Size = New System.Drawing.Size(1283, 453)
        Me.pnlGrids.TabIndex = 11
        '
        'sPCConfirmacionOrdenesTrabajo
        '
        Me.sPCConfirmacionOrdenesTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sPCConfirmacionOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sPCConfirmacionOrdenesTrabajo.Location = New System.Drawing.Point(0, 43)
        Me.sPCConfirmacionOrdenesTrabajo.Name = "sPCConfirmacionOrdenesTrabajo"
        '
        'sPCConfirmacionOrdenesTrabajo.Panel1
        '
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.Controls.Add(Me.grdPartidasConfirmadasyPorConfirmar)
        '
        'sPCConfirmacionOrdenesTrabajo.Panel2
        '
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.Controls.Add(Me.sPCParesConfirmar)
        Me.sPCConfirmacionOrdenesTrabajo.Size = New System.Drawing.Size(1283, 410)
        Me.sPCConfirmacionOrdenesTrabajo.SplitterDistance = 560
        Me.sPCConfirmacionOrdenesTrabajo.TabIndex = 11
        '
        'grdPartidasConfirmadasyPorConfirmar
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Appearance = Appearance1
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPartidasConfirmadasyPorConfirmar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidasConfirmadasyPorConfirmar.Location = New System.Drawing.Point(0, 0)
        Me.grdPartidasConfirmadasyPorConfirmar.Name = "grdPartidasConfirmadasyPorConfirmar"
        Me.grdPartidasConfirmadasyPorConfirmar.Size = New System.Drawing.Size(558, 408)
        Me.grdPartidasConfirmadasyPorConfirmar.TabIndex = 12
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
        Me.sPCParesConfirmar.Panel1.Controls.Add(Me.grdParesConfirmandoActualmente)
        Me.sPCParesConfirmar.Panel1MinSize = 0
        '
        'sPCParesConfirmar.Panel2
        '
        Me.sPCParesConfirmar.Panel2.Controls.Add(Me.sPCParesConfirmadosAnteriormente)
        Me.sPCParesConfirmar.Panel2MinSize = 0
        Me.sPCParesConfirmar.Size = New System.Drawing.Size(719, 410)
        Me.sPCParesConfirmar.SplitterDistance = 188
        Me.sPCParesConfirmar.TabIndex = 0
        '
        'grdParesConfirmandoActualmente
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmandoActualmente.DisplayLayout.Appearance = Appearance3
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmandoActualmente.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdParesConfirmandoActualmente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesConfirmandoActualmente.Location = New System.Drawing.Point(0, 0)
        Me.grdParesConfirmandoActualmente.Name = "grdParesConfirmandoActualmente"
        Me.grdParesConfirmandoActualmente.Size = New System.Drawing.Size(717, 186)
        Me.grdParesConfirmandoActualmente.TabIndex = 12
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
        Me.sPCParesConfirmadosAnteriormente.Size = New System.Drawing.Size(717, 216)
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
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdParesConfirmadosAnteriormente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesConfirmadosAnteriormente.Location = New System.Drawing.Point(0, 0)
        Me.grdParesConfirmadosAnteriormente.Name = "grdParesConfirmadosAnteriormente"
        Me.grdParesConfirmadosAnteriormente.Size = New System.Drawing.Size(717, 190)
        Me.grdParesConfirmadosAnteriormente.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblEstatusApartado)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoTotalApartadosSeleccionados)
        Me.Panel3.Controls.Add(Me.lblTotalApartadosSeleccionados)
        Me.Panel3.Controls.Add(Me.lblFPreparacion)
        Me.Panel3.Controls.Add(Me.lblTextoFPreparacion)
        Me.Panel3.Controls.Add(Me.lblEntregaInmediata)
        Me.Panel3.Controls.Add(Me.lblOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblTextoOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblFSolicitada)
        Me.Panel3.Controls.Add(Me.lblTextoFSolicitada)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblIdApartadoSICY)
        Me.Panel3.Controls.Add(Me.lblIdApartado)
        Me.Panel3.Controls.Add(Me.lblTextoApartadoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoFolioApartado)
        Me.Panel3.Controls.Add(Me.lblNombreCliente)
        Me.Panel3.Controls.Add(Me.lblTextoCliente)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1283, 43)
        Me.Panel3.TabIndex = 9
        '
        'lblEstatusApartado
        '
        Me.lblEstatusApartado.AutoSize = True
        Me.lblEstatusApartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatusApartado.ForeColor = System.Drawing.Color.DarkRed
        Me.lblEstatusApartado.Location = New System.Drawing.Point(1160, 6)
        Me.lblEstatusApartado.Name = "lblEstatusApartado"
        Me.lblEstatusApartado.Size = New System.Drawing.Size(11, 13)
        Me.lblEstatusApartado.TabIndex = 32
        Me.lblEstatusApartado.Text = "-"
        Me.lblEstatusApartado.Visible = False
        '
        'lblIdPedidoSICY
        '
        Me.lblIdPedidoSICY.AutoSize = True
        Me.lblIdPedidoSICY.Location = New System.Drawing.Point(605, 24)
        Me.lblIdPedidoSICY.Name = "lblIdPedidoSICY"
        Me.lblIdPedidoSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdPedidoSICY.TabIndex = 31
        Me.lblIdPedidoSICY.Text = "0"
        Me.lblIdPedidoSICY.Visible = False
        '
        'lblTextoPedidoSICY
        '
        Me.lblTextoPedidoSICY.AutoSize = True
        Me.lblTextoPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSICY.Location = New System.Drawing.Point(526, 24)
        Me.lblTextoPedidoSICY.Name = "lblTextoPedidoSICY"
        Me.lblTextoPedidoSICY.Size = New System.Drawing.Size(82, 13)
        Me.lblTextoPedidoSICY.TabIndex = 30
        Me.lblTextoPedidoSICY.Text = "Pedido SICY:"
        Me.lblTextoPedidoSICY.Visible = False
        '
        'lblTextoTotalApartadosSeleccionados
        '
        Me.lblTextoTotalApartadosSeleccionados.AutoSize = True
        Me.lblTextoTotalApartadosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTotalApartadosSeleccionados.Location = New System.Drawing.Point(44, 20)
        Me.lblTextoTotalApartadosSeleccionados.Name = "lblTextoTotalApartadosSeleccionados"
        Me.lblTextoTotalApartadosSeleccionados.Size = New System.Drawing.Size(207, 13)
        Me.lblTextoTotalApartadosSeleccionados.TabIndex = 29
        Me.lblTextoTotalApartadosSeleccionados.Text = "Total de apartados seleccionados: "
        Me.lblTextoTotalApartadosSeleccionados.Visible = False
        '
        'lblTotalApartadosSeleccionados
        '
        Me.lblTotalApartadosSeleccionados.AutoSize = True
        Me.lblTotalApartadosSeleccionados.Location = New System.Drawing.Point(251, 20)
        Me.lblTotalApartadosSeleccionados.Name = "lblTotalApartadosSeleccionados"
        Me.lblTotalApartadosSeleccionados.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalApartadosSeleccionados.TabIndex = 28
        Me.lblTotalApartadosSeleccionados.Text = "0"
        Me.lblTotalApartadosSeleccionados.Visible = False
        '
        'lblFPreparacion
        '
        Me.lblFPreparacion.AutoSize = True
        Me.lblFPreparacion.Location = New System.Drawing.Point(1058, 24)
        Me.lblFPreparacion.Name = "lblFPreparacion"
        Me.lblFPreparacion.Size = New System.Drawing.Size(10, 13)
        Me.lblFPreparacion.TabIndex = 18
        Me.lblFPreparacion.Text = "-"
        Me.lblFPreparacion.Visible = False
        '
        'lblTextoFPreparacion
        '
        Me.lblTextoFPreparacion.AutoSize = True
        Me.lblTextoFPreparacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFPreparacion.Location = New System.Drawing.Point(958, 24)
        Me.lblTextoFPreparacion.Name = "lblTextoFPreparacion"
        Me.lblTextoFPreparacion.Size = New System.Drawing.Size(94, 13)
        Me.lblTextoFPreparacion.TabIndex = 17
        Me.lblTextoFPreparacion.Text = "F. Preparación:"
        Me.lblTextoFPreparacion.Visible = False
        '
        'lblEntregaInmediata
        '
        Me.lblEntregaInmediata.AutoSize = True
        Me.lblEntregaInmediata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntregaInmediata.ForeColor = System.Drawing.Color.DarkRed
        Me.lblEntregaInmediata.Location = New System.Drawing.Point(1160, 24)
        Me.lblEntregaInmediata.Name = "lblEntregaInmediata"
        Me.lblEntregaInmediata.Size = New System.Drawing.Size(138, 13)
        Me.lblEntregaInmediata.TabIndex = 14
        Me.lblEntregaInmediata.Text = "ENTREGA INMEDIATA"
        Me.lblEntregaInmediata.Visible = False
        '
        'lblOrdenCliente
        '
        Me.lblOrdenCliente.AutoSize = True
        Me.lblOrdenCliente.Location = New System.Drawing.Point(805, 24)
        Me.lblOrdenCliente.Name = "lblOrdenCliente"
        Me.lblOrdenCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblOrdenCliente.TabIndex = 13
        Me.lblOrdenCliente.Text = "-"
        Me.lblOrdenCliente.Visible = False
        '
        'lblTextoOrdenCliente
        '
        Me.lblTextoOrdenCliente.AutoSize = True
        Me.lblTextoOrdenCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOrdenCliente.Location = New System.Drawing.Point(712, 24)
        Me.lblTextoOrdenCliente.Name = "lblTextoOrdenCliente"
        Me.lblTextoOrdenCliente.Size = New System.Drawing.Size(87, 13)
        Me.lblTextoOrdenCliente.TabIndex = 12
        Me.lblTextoOrdenCliente.Text = "Orden cliente:"
        Me.lblTextoOrdenCliente.Visible = False
        '
        'lblFSolicitada
        '
        Me.lblFSolicitada.AutoSize = True
        Me.lblFSolicitada.Location = New System.Drawing.Point(1058, 6)
        Me.lblFSolicitada.Name = "lblFSolicitada"
        Me.lblFSolicitada.Size = New System.Drawing.Size(10, 13)
        Me.lblFSolicitada.TabIndex = 11
        Me.lblFSolicitada.Text = "-"
        Me.lblFSolicitada.Visible = False
        '
        'lblTextoFSolicitada
        '
        Me.lblTextoFSolicitada.AutoSize = True
        Me.lblTextoFSolicitada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFSolicitada.Location = New System.Drawing.Point(958, 6)
        Me.lblTextoFSolicitada.Name = "lblTextoFSolicitada"
        Me.lblTextoFSolicitada.Size = New System.Drawing.Size(82, 13)
        Me.lblTextoFSolicitada.TabIndex = 10
        Me.lblTextoFSolicitada.Text = "F. Solicitada:"
        Me.lblTextoFSolicitada.Visible = False
        '
        'lblIdPedidoSAY
        '
        Me.lblIdPedidoSAY.AutoSize = True
        Me.lblIdPedidoSAY.Location = New System.Drawing.Point(605, 6)
        Me.lblIdPedidoSAY.Name = "lblIdPedidoSAY"
        Me.lblIdPedidoSAY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdPedidoSAY.TabIndex = 9
        Me.lblIdPedidoSAY.Text = "0"
        Me.lblIdPedidoSAY.Visible = False
        '
        'lblTextoPedidoSAY
        '
        Me.lblTextoPedidoSAY.AutoSize = True
        Me.lblTextoPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSAY.Location = New System.Drawing.Point(526, 6)
        Me.lblTextoPedidoSAY.Name = "lblTextoPedidoSAY"
        Me.lblTextoPedidoSAY.Size = New System.Drawing.Size(78, 13)
        Me.lblTextoPedidoSAY.TabIndex = 8
        Me.lblTextoPedidoSAY.Text = "Pedido SAY:"
        Me.lblTextoPedidoSAY.Visible = False
        '
        'lblIdApartadoSICY
        '
        Me.lblIdApartadoSICY.AutoSize = True
        Me.lblIdApartadoSICY.Location = New System.Drawing.Point(442, 24)
        Me.lblIdApartadoSICY.Name = "lblIdApartadoSICY"
        Me.lblIdApartadoSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdApartadoSICY.TabIndex = 7
        Me.lblIdApartadoSICY.Text = "0"
        Me.lblIdApartadoSICY.Visible = False
        '
        'lblIdApartado
        '
        Me.lblIdApartado.AutoSize = True
        Me.lblIdApartado.Location = New System.Drawing.Point(442, 6)
        Me.lblIdApartado.Name = "lblIdApartado"
        Me.lblIdApartado.Size = New System.Drawing.Size(13, 13)
        Me.lblIdApartado.TabIndex = 7
        Me.lblIdApartado.Text = "0"
        Me.lblIdApartado.Visible = False
        '
        'lblTextoApartadoSICY
        '
        Me.lblTextoApartadoSICY.AutoSize = True
        Me.lblTextoApartadoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoApartadoSICY.Location = New System.Drawing.Point(348, 24)
        Me.lblTextoApartadoSICY.Name = "lblTextoApartadoSICY"
        Me.lblTextoApartadoSICY.Size = New System.Drawing.Size(94, 13)
        Me.lblTextoApartadoSICY.TabIndex = 6
        Me.lblTextoApartadoSICY.Text = "Apartado SICY:"
        Me.lblTextoApartadoSICY.Visible = False
        '
        'lblTextoFolioApartado
        '
        Me.lblTextoFolioApartado.AutoSize = True
        Me.lblTextoFolioApartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFolioApartado.Location = New System.Drawing.Point(348, 6)
        Me.lblTextoFolioApartado.Name = "lblTextoFolioApartado"
        Me.lblTextoFolioApartado.Size = New System.Drawing.Size(90, 13)
        Me.lblTextoFolioApartado.TabIndex = 6
        Me.lblTextoFolioApartado.Text = "Apartado SAY:"
        Me.lblTextoFolioApartado.Visible = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(69, 24)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "-"
        Me.lblNombreCliente.Visible = False
        '
        'lblTextoCliente
        '
        Me.lblTextoCliente.AutoSize = True
        Me.lblTextoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCliente.Location = New System.Drawing.Point(12, 24)
        Me.lblTextoCliente.Name = "lblTextoCliente"
        Me.lblTextoCliente.Size = New System.Drawing.Size(50, 13)
        Me.lblTextoCliente.TabIndex = 3
        Me.lblTextoCliente.Text = "Cliente:"
        Me.lblTextoCliente.Visible = False
        '
        'pnlDetallePares
        '
        Me.pnlDetallePares.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDetallePares.Location = New System.Drawing.Point(0, 523)
        Me.pnlDetallePares.Name = "pnlDetallePares"
        Me.pnlDetallePares.Size = New System.Drawing.Size(1283, 10)
        Me.pnlDetallePares.TabIndex = 10
        '
        'lblTotalP
        '
        Me.lblTotalP.AutoSize = True
        Me.lblTotalP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalP.Location = New System.Drawing.Point(905, 3)
        Me.lblTotalP.Name = "lblTotalP"
        Me.lblTotalP.Size = New System.Drawing.Size(147, 13)
        Me.lblTotalP.TabIndex = 6
        Me.lblTotalP.Text = "Total de pares apartado:"
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
        Me.pnlHeader.TabIndex = 7
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
        Me.lblTitulo.Location = New System.Drawing.Point(155, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(227, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Confirmación de Apartados"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(377, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 70)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.lblTextoConsolidar)
        Me.pnlBtn.Controls.Add(Me.btnConsolidar)
        Me.pnlBtn.Controls.Add(Me.btnExportarDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoExportarDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoImprimirDetalles)
        Me.pnlBtn.Controls.Add(Me.btnImprimirDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoVerPares)
        Me.pnlBtn.Controls.Add(Me.lblTextoCancelarConfirmacionActual)
        Me.pnlBtn.Controls.Add(Me.btnVerPares)
        Me.pnlBtn.Controls.Add(Me.btnCancelarConfirmacion)
        Me.pnlBtn.Controls.Add(Me.btnConfirmacionIncompleta)
        Me.pnlBtn.Controls.Add(Me.lblTextoConfirmacionIncompleta)
        Me.pnlBtn.Controls.Add(Me.btnExportarConfirmados)
        Me.pnlBtn.Controls.Add(Me.lblTextoExistenciaDisponible)
        Me.pnlBtn.Controls.Add(Me.lblTextoExportarConfirmados)
        Me.pnlBtn.Controls.Add(Me.btnExistenciaDisponible)
        Me.pnlBtn.Controls.Add(Me.lblTerminal)
        Me.pnlBtn.Controls.Add(Me.btnTerminal)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(774, 70)
        Me.pnlBtn.TabIndex = 1
        '
        'lblTextoConsolidar
        '
        Me.lblTextoConsolidar.AutoSize = True
        Me.lblTextoConsolidar.Enabled = False
        Me.lblTextoConsolidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoConsolidar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoConsolidar.Location = New System.Drawing.Point(11, 40)
        Me.lblTextoConsolidar.Name = "lblTextoConsolidar"
        Me.lblTextoConsolidar.Size = New System.Drawing.Size(56, 13)
        Me.lblTextoConsolidar.TabIndex = 39
        Me.lblTextoConsolidar.Text = "Consolidar"
        '
        'btnConsolidar
        '
        Me.btnConsolidar.Enabled = False
        Me.btnConsolidar.Image = Global.Ventas.Vista.My.Resources.Resources.vincular_24x24
        Me.btnConsolidar.Location = New System.Drawing.Point(22, 8)
        Me.btnConsolidar.Name = "btnConsolidar"
        Me.btnConsolidar.Size = New System.Drawing.Size(32, 32)
        Me.btnConsolidar.TabIndex = 40
        Me.btnConsolidar.UseVisualStyleBackColor = True
        '
        'btnExportarDetalles
        '
        Me.btnExportarDetalles.Enabled = False
        Me.btnExportarDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarDetalles.Location = New System.Drawing.Point(123, 8)
        Me.btnExportarDetalles.Name = "btnExportarDetalles"
        Me.btnExportarDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarDetalles.TabIndex = 37
        Me.btnExportarDetalles.UseVisualStyleBackColor = True
        '
        'lblTextoExportarDetalles
        '
        Me.lblTextoExportarDetalles.AutoSize = True
        Me.lblTextoExportarDetalles.Enabled = False
        Me.lblTextoExportarDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportarDetalles.Location = New System.Drawing.Point(116, 40)
        Me.lblTextoExportarDetalles.Name = "lblTextoExportarDetalles"
        Me.lblTextoExportarDetalles.Size = New System.Drawing.Size(49, 26)
        Me.lblTextoExportarDetalles.TabIndex = 38
        Me.lblTextoExportarDetalles.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalles"
        '
        'lblTextoImprimirDetalles
        '
        Me.lblTextoImprimirDetalles.AutoSize = True
        Me.lblTextoImprimirDetalles.Enabled = False
        Me.lblTextoImprimirDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoImprimirDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoImprimirDetalles.Location = New System.Drawing.Point(68, 40)
        Me.lblTextoImprimirDetalles.Name = "lblTextoImprimirDetalles"
        Me.lblTextoImprimirDetalles.Size = New System.Drawing.Size(42, 26)
        Me.lblTextoImprimirDetalles.TabIndex = 35
        Me.lblTextoImprimirDetalles.Text = "Imprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalle"
        '
        'btnImprimirDetalles
        '
        Me.btnImprimirDetalles.Enabled = False
        Me.btnImprimirDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirDetalles.Location = New System.Drawing.Point(72, 8)
        Me.btnImprimirDetalles.Name = "btnImprimirDetalles"
        Me.btnImprimirDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirDetalles.TabIndex = 36
        Me.btnImprimirDetalles.UseVisualStyleBackColor = True
        '
        'lblTextoVerPares
        '
        Me.lblTextoVerPares.AutoSize = True
        Me.lblTextoVerPares.Enabled = False
        Me.lblTextoVerPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoVerPares.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoVerPares.Location = New System.Drawing.Point(500, 43)
        Me.lblTextoVerPares.Name = "lblTextoVerPares"
        Me.lblTextoVerPares.Size = New System.Drawing.Size(53, 13)
        Me.lblTextoVerPares.TabIndex = 33
        Me.lblTextoVerPares.Text = "Ver Pares"
        '
        'lblTextoCancelarConfirmacionActual
        '
        Me.lblTextoCancelarConfirmacionActual.AutoSize = True
        Me.lblTextoCancelarConfirmacionActual.Enabled = False
        Me.lblTextoCancelarConfirmacionActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCancelarConfirmacionActual.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelarConfirmacionActual.Location = New System.Drawing.Point(226, 43)
        Me.lblTextoCancelarConfirmacionActual.Name = "lblTextoCancelarConfirmacionActual"
        Me.lblTextoCancelarConfirmacionActual.Size = New System.Drawing.Size(49, 13)
        Me.lblTextoCancelarConfirmacionActual.TabIndex = 33
        Me.lblTextoCancelarConfirmacionActual.Text = "Cancelar"
        '
        'btnVerPares
        '
        Me.btnVerPares.Enabled = False
        Me.btnVerPares.Image = CType(resources.GetObject("btnVerPares.Image"), System.Drawing.Image)
        Me.btnVerPares.Location = New System.Drawing.Point(510, 8)
        Me.btnVerPares.Name = "btnVerPares"
        Me.btnVerPares.Size = New System.Drawing.Size(32, 32)
        Me.btnVerPares.TabIndex = 34
        Me.btnVerPares.UseVisualStyleBackColor = True
        '
        'btnCancelarConfirmacion
        '
        Me.btnCancelarConfirmacion.Enabled = False
        Me.btnCancelarConfirmacion.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_321
        Me.btnCancelarConfirmacion.Location = New System.Drawing.Point(233, 8)
        Me.btnCancelarConfirmacion.Name = "btnCancelarConfirmacion"
        Me.btnCancelarConfirmacion.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarConfirmacion.TabIndex = 34
        Me.btnCancelarConfirmacion.UseVisualStyleBackColor = True
        '
        'btnConfirmacionIncompleta
        '
        Me.btnConfirmacionIncompleta.Enabled = False
        Me.btnConfirmacionIncompleta.Image = CType(resources.GetObject("btnConfirmacionIncompleta.Image"), System.Drawing.Image)
        Me.btnConfirmacionIncompleta.Location = New System.Drawing.Point(588, 8)
        Me.btnConfirmacionIncompleta.Name = "btnConfirmacionIncompleta"
        Me.btnConfirmacionIncompleta.Size = New System.Drawing.Size(32, 32)
        Me.btnConfirmacionIncompleta.TabIndex = 4
        Me.btnConfirmacionIncompleta.UseVisualStyleBackColor = True
        '
        'lblTextoConfirmacionIncompleta
        '
        Me.lblTextoConfirmacionIncompleta.AutoSize = True
        Me.lblTextoConfirmacionIncompleta.Enabled = False
        Me.lblTextoConfirmacionIncompleta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoConfirmacionIncompleta.Location = New System.Drawing.Point(572, 43)
        Me.lblTextoConfirmacionIncompleta.Name = "lblTextoConfirmacionIncompleta"
        Me.lblTextoConfirmacionIncompleta.Size = New System.Drawing.Size(71, 26)
        Me.lblTextoConfirmacionIncompleta.TabIndex = 32
        Me.lblTextoConfirmacionIncompleta.Text = "Confirmación " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Incompleta"
        '
        'btnExportarConfirmados
        '
        Me.btnExportarConfirmados.Enabled = False
        Me.btnExportarConfirmados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarConfirmados.Location = New System.Drawing.Point(292, 8)
        Me.btnExportarConfirmados.Name = "btnExportarConfirmados"
        Me.btnExportarConfirmados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarConfirmados.TabIndex = 4
        Me.btnExportarConfirmados.UseVisualStyleBackColor = True
        '
        'lblTextoExistenciaDisponible
        '
        Me.lblTextoExistenciaDisponible.AutoSize = True
        Me.lblTextoExistenciaDisponible.Enabled = False
        Me.lblTextoExistenciaDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoExistenciaDisponible.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExistenciaDisponible.Location = New System.Drawing.Point(424, 43)
        Me.lblTextoExistenciaDisponible.Name = "lblTextoExistenciaDisponible"
        Me.lblTextoExistenciaDisponible.Size = New System.Drawing.Size(56, 26)
        Me.lblTextoExistenciaDisponible.TabIndex = 2
        Me.lblTextoExistenciaDisponible.Text = "Existencia" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disponible"
        '
        'lblTextoExportarConfirmados
        '
        Me.lblTextoExportarConfirmados.AutoSize = True
        Me.lblTextoExportarConfirmados.Enabled = False
        Me.lblTextoExportarConfirmados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportarConfirmados.Location = New System.Drawing.Point(274, 40)
        Me.lblTextoExportarConfirmados.Name = "lblTextoExportarConfirmados"
        Me.lblTextoExportarConfirmados.Size = New System.Drawing.Size(67, 26)
        Me.lblTextoExportarConfirmados.TabIndex = 32
        Me.lblTextoExportarConfirmados.Text = "    Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " confirmados"
        '
        'btnExistenciaDisponible
        '
        Me.btnExistenciaDisponible.Enabled = False
        Me.btnExistenciaDisponible.Image = CType(resources.GetObject("btnExistenciaDisponible.Image"), System.Drawing.Image)
        Me.btnExistenciaDisponible.Location = New System.Drawing.Point(436, 8)
        Me.btnExistenciaDisponible.Name = "btnExistenciaDisponible"
        Me.btnExistenciaDisponible.Size = New System.Drawing.Size(32, 32)
        Me.btnExistenciaDisponible.TabIndex = 3
        Me.btnExistenciaDisponible.UseVisualStyleBackColor = True
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTerminal.Location = New System.Drawing.Point(169, 43)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(47, 13)
        Me.lblTerminal.TabIndex = 2
        Me.lblTerminal.Text = "Terminal"
        '
        'btnTerminal
        '
        Me.btnTerminal.Image = Global.Ventas.Vista.My.Resources.Resources.calculo_32
        Me.btnTerminal.Location = New System.Drawing.Point(176, 8)
        Me.btnTerminal.Name = "btnTerminal"
        Me.btnTerminal.Size = New System.Drawing.Size(32, 32)
        Me.btnTerminal.TabIndex = 3
        Me.btnTerminal.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblCancelados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.pnlPartidaCancelada)
        Me.pnlPie.Controls.Add(Me.lblTotalCodigosInvalidos)
        Me.pnlPie.Controls.Add(Me.lblTextoCodigosInvalidos)
        Me.pnlPie.Controls.Add(Me.lblTextoApartadoAnterior)
        Me.pnlPie.Controls.Add(Me.lblTextoApartadoSiguiente)
        Me.pnlPie.Controls.Add(Me.btnAnteriorApartado)
        Me.pnlPie.Controls.Add(Me.btnSiguienteApartado)
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
        Me.pnlPie.Controls.Add(Me.pnlParExcedente)
        Me.pnlPie.Controls.Add(Me.lblTiendaCompleta)
        Me.pnlPie.Controls.Add(Me.pnlColorPartidaIncompleta)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 533)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1283, 61)
        Me.pnlPie.TabIndex = 8
        '
        'lblCancelados
        '
        Me.lblCancelados.AutoSize = True
        Me.lblCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelados.ForeColor = System.Drawing.Color.RosyBrown
        Me.lblCancelados.Location = New System.Drawing.Point(1085, 44)
        Me.lblCancelados.Name = "lblCancelados"
        Me.lblCancelados.Size = New System.Drawing.Size(14, 13)
        Me.lblCancelados.TabIndex = 41
        Me.lblCancelados.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(890, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Total de pares cancelados:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(177, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Partida Cancelada"
        '
        'pnlPartidaCancelada
        '
        Me.pnlPartidaCancelada.BackColor = System.Drawing.Color.RosyBrown
        Me.pnlPartidaCancelada.Location = New System.Drawing.Point(156, 9)
        Me.pnlPartidaCancelada.Name = "pnlPartidaCancelada"
        Me.pnlPartidaCancelada.Size = New System.Drawing.Size(13, 15)
        Me.pnlPartidaCancelada.TabIndex = 38
        '
        'lblTotalCodigosInvalidos
        '
        Me.lblTotalCodigosInvalidos.AutoSize = True
        Me.lblTotalCodigosInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCodigosInvalidos.ForeColor = System.Drawing.Color.Red
        Me.lblTotalCodigosInvalidos.Location = New System.Drawing.Point(444, 12)
        Me.lblTotalCodigosInvalidos.Name = "lblTotalCodigosInvalidos"
        Me.lblTotalCodigosInvalidos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalCodigosInvalidos.TabIndex = 37
        Me.lblTotalCodigosInvalidos.Text = "0"
        Me.lblTotalCodigosInvalidos.Visible = False
        '
        'lblTextoCodigosInvalidos
        '
        Me.lblTextoCodigosInvalidos.AutoSize = True
        Me.lblTextoCodigosInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCodigosInvalidos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTextoCodigosInvalidos.Location = New System.Drawing.Point(346, 12)
        Me.lblTextoCodigosInvalidos.Name = "lblTextoCodigosInvalidos"
        Me.lblTextoCodigosInvalidos.Size = New System.Drawing.Size(92, 13)
        Me.lblTextoCodigosInvalidos.TabIndex = 36
        Me.lblTextoCodigosInvalidos.Text = "Códigos inválidos:"
        Me.lblTextoCodigosInvalidos.Visible = False
        '
        'lblTextoApartadoAnterior
        '
        Me.lblTextoApartadoAnterior.AutoSize = True
        Me.lblTextoApartadoAnterior.Enabled = False
        Me.lblTextoApartadoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoApartadoAnterior.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoApartadoAnterior.Location = New System.Drawing.Point(700, 43)
        Me.lblTextoApartadoAnterior.Name = "lblTextoApartadoAnterior"
        Me.lblTextoApartadoAnterior.Size = New System.Drawing.Size(43, 13)
        Me.lblTextoApartadoAnterior.TabIndex = 35
        Me.lblTextoApartadoAnterior.Text = "Anterior"
        '
        'lblTextoApartadoSiguiente
        '
        Me.lblTextoApartadoSiguiente.AutoSize = True
        Me.lblTextoApartadoSiguiente.Enabled = False
        Me.lblTextoApartadoSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoApartadoSiguiente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoApartadoSiguiente.Location = New System.Drawing.Point(748, 43)
        Me.lblTextoApartadoSiguiente.Name = "lblTextoApartadoSiguiente"
        Me.lblTextoApartadoSiguiente.Size = New System.Drawing.Size(51, 13)
        Me.lblTextoApartadoSiguiente.TabIndex = 34
        Me.lblTextoApartadoSiguiente.Text = "Siguiente"
        '
        'btnAnteriorApartado
        '
        Me.btnAnteriorApartado.Enabled = False
        Me.btnAnteriorApartado.Image = CType(resources.GetObject("btnAnteriorApartado.Image"), System.Drawing.Image)
        Me.btnAnteriorApartado.Location = New System.Drawing.Point(704, 9)
        Me.btnAnteriorApartado.Name = "btnAnteriorApartado"
        Me.btnAnteriorApartado.Size = New System.Drawing.Size(32, 32)
        Me.btnAnteriorApartado.TabIndex = 20
        Me.btnAnteriorApartado.UseVisualStyleBackColor = True
        '
        'btnSiguienteApartado
        '
        Me.btnSiguienteApartado.Enabled = False
        Me.btnSiguienteApartado.Image = CType(resources.GetObject("btnSiguienteApartado.Image"), System.Drawing.Image)
        Me.btnSiguienteApartado.Location = New System.Drawing.Point(757, 9)
        Me.btnSiguienteApartado.Name = "btnSiguienteApartado"
        Me.btnSiguienteApartado.Size = New System.Drawing.Size(32, 32)
        Me.btnSiguienteApartado.TabIndex = 19
        Me.btnSiguienteApartado.UseVisualStyleBackColor = True
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
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(23, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
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
        Me.lblParInvalido.Size = New System.Drawing.Size(77, 13)
        Me.lblParInvalido.TabIndex = 3
        Me.lblParInvalido.Text = "Par Excedente"
        '
        'pnlParExcedente
        '
        Me.pnlParExcedente.BackColor = System.Drawing.Color.Tomato
        Me.pnlParExcedente.Location = New System.Drawing.Point(23, 36)
        Me.pnlParExcedente.Name = "pnlParExcedente"
        Me.pnlParExcedente.Size = New System.Drawing.Size(13, 15)
        Me.pnlParExcedente.TabIndex = 2
        '
        'lblTiendaCompleta
        '
        Me.lblTiendaCompleta.AutoSize = True
        Me.lblTiendaCompleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaCompleta.Location = New System.Drawing.Point(44, 11)
        Me.lblTiendaCompleta.Name = "lblTiendaCompleta"
        Me.lblTiendaCompleta.Size = New System.Drawing.Size(95, 13)
        Me.lblTiendaCompleta.TabIndex = 1
        Me.lblTiendaCompleta.Text = "Partida Incompleta"
        '
        'pnlColorPartidaIncompleta
        '
        Me.pnlColorPartidaIncompleta.BackColor = System.Drawing.Color.Gold
        Me.pnlColorPartidaIncompleta.Location = New System.Drawing.Point(23, 9)
        Me.pnlColorPartidaIncompleta.Name = "pnlColorPartidaIncompleta"
        Me.pnlColorPartidaIncompleta.Size = New System.Drawing.Size(13, 15)
        Me.pnlColorPartidaIncompleta.TabIndex = 0
        '
        'ConfirmarApartado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 594)
        Me.Controls.Add(Me.pnlGrids)
        Me.Controls.Add(Me.pnlDetallePares)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "ConfirmarApartado"
        Me.Text = "Confirmación de Apartados"
        Me.pnlExternos.ResumeLayout(False)
        Me.pnlExternos.PerformLayout()
        Me.pnlCorrectos.ResumeLayout(False)
        Me.pnlCorrectos.PerformLayout()
        Me.pnlGrids.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.ResumeLayout(False)
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCConfirmacionOrdenesTrabajo.ResumeLayout(False)
        CType(Me.grdPartidasConfirmadasyPorConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmar.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.ResumeLayout(False)
        CType(Me.grdParesConfirmandoActualmente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmadosAnteriormente.Panel1.PerformLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.ResumeLayout(False)
        CType(Me.grdParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtn.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblNotaCodigoInvalido As System.Windows.Forms.Label
    Friend WithEvents lblTotalExternos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalConfirmados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Public WithEvents lblExternos As System.Windows.Forms.Label
    Friend WithEvents pnlExternos As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblCorrectos As System.Windows.Forms.Label
    Friend WithEvents pnlCorrectos As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlGrids As System.Windows.Forms.Panel
    Friend WithEvents pnlDetallePares As System.Windows.Forms.Panel
    Friend WithEvents lblTotalP As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents btnExportarConfirmados As System.Windows.Forms.Button
    Friend WithEvents lblTextoExportarConfirmados As System.Windows.Forms.Label
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents btnTerminal As System.Windows.Forms.Button
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblParInvalido As System.Windows.Forms.Label
    Friend WithEvents lblTiendaCompleta As System.Windows.Forms.Label
    Friend WithEvents sPCConfirmacionOrdenesTrabajo As System.Windows.Forms.SplitContainer
    Friend WithEvents sPCParesConfirmar As System.Windows.Forms.SplitContainer
    Friend WithEvents sPCParesConfirmadosAnteriormente As System.Windows.Forms.SplitContainer
    Friend WithEvents lblParesConfirmadosAnteriormente As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblTextoFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblIdApartado As System.Windows.Forms.Label
    Friend WithEvents lblTextoFolioApartado As System.Windows.Forms.Label
    Friend WithEvents pnlParExcedente As System.Windows.Forms.Panel
    Friend WithEvents pnlColorPartidaIncompleta As System.Windows.Forms.Panel
    Friend WithEvents lblEntregaInmediata As System.Windows.Forms.Label
    Friend WithEvents lblOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoCancelarConfirmacionActual As System.Windows.Forms.Label
    Friend WithEvents btnCancelarConfirmacion As System.Windows.Forms.Button
    Friend WithEvents lblFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoConsolidar As System.Windows.Forms.Label
    Friend WithEvents btnConsolidar As System.Windows.Forms.Button
    Friend WithEvents btnExportarDetalles As System.Windows.Forms.Button
    Friend WithEvents lblTextoExportarDetalles As System.Windows.Forms.Label
    Friend WithEvents lblTextoImprimirDetalles As System.Windows.Forms.Label
    Friend WithEvents btnImprimirDetalles As System.Windows.Forms.Button
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoCliente As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents grdPartidasConfirmadasyPorConfirmar As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdParesConfirmandoActualmente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdParesConfirmadosAnteriormente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblEstatusApartado As System.Windows.Forms.Label
    Friend WithEvents lblIdApartadoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoApartadoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoVerPares As System.Windows.Forms.Label
    Friend WithEvents btnVerPares As System.Windows.Forms.Button
    Friend WithEvents btnConfirmacionIncompleta As System.Windows.Forms.Button
    Friend WithEvents lblTextoConfirmacionIncompleta As System.Windows.Forms.Label
    Friend WithEvents lblTextoExistenciaDisponible As System.Windows.Forms.Label
    Friend WithEvents btnExistenciaDisponible As System.Windows.Forms.Button
    Friend WithEvents btnSiguienteApartado As System.Windows.Forms.Button
    Friend WithEvents btnAnteriorApartado As System.Windows.Forms.Button
    Friend WithEvents lblTextoApartadoAnterior As System.Windows.Forms.Label
    Friend WithEvents lblTextoApartadoSiguiente As System.Windows.Forms.Label
    Friend WithEvents lblTotalCodigosInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblTextoCodigosInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblTextoTotalApartadosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblTotalApartadosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlPartidaCancelada As System.Windows.Forms.Panel
    Friend WithEvents lblCancelados As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
