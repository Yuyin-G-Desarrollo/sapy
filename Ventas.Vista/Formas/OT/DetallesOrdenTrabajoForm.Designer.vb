<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesOrdenTrabajoForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetallesOrdenTrabajoForm))
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
        Me.lblVerDistribucion = New System.Windows.Forms.Label()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.lblCancelarPartidas = New System.Windows.Forms.Label()
        Me.lblGenerarXML = New System.Windows.Forms.Label()
        Me.btnExportarDetalles = New System.Windows.Forms.Button()
        Me.lblTextoExportarDetalles = New System.Windows.Forms.Label()
        Me.lblTextoImprimirDetalles = New System.Windows.Forms.Label()
        Me.btnImprimirDetalles = New System.Windows.Forms.Button()
        Me.lblTextoCancelarConfirmacionActual = New System.Windows.Forms.Label()
        Me.btnCancelarPartidasOT = New System.Windows.Forms.Button()
        Me.btnCancelarConfirmacion = New System.Windows.Forms.Button()
        Me.btnExportarConfirmados = New System.Windows.Forms.Button()
        Me.lblTextoExportarConfirmados = New System.Windows.Forms.Label()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.btnTerminal = New System.Windows.Forms.Button()
        Me.btnGenerarXML = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblCantidadAtadosIncompletos = New System.Windows.Forms.Label()
        Me.lblAtadosIncompletos = New System.Windows.Forms.Label()
        Me.lblCancelados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblColorRechazada = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlPartidaCancelada = New System.Windows.Forms.Panel()
        Me.pnlEntregaVenceHoy = New System.Windows.Forms.Panel()
        Me.lblTotalCodigosInvalidos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblTextoCodigosInvalidos = New System.Windows.Forms.Label()
        Me.lblTextoOTAnterior = New System.Windows.Forms.Label()
        Me.lblTextoOTSiguiente = New System.Windows.Forms.Label()
        Me.btnAnteriorOT = New System.Windows.Forms.Button()
        Me.btnSiguienteOT = New System.Windows.Forms.Button()
        Me.lblNotaCodigoInvalido = New System.Windows.Forms.Label()
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
        Me.pnlParExcedente = New System.Windows.Forms.Panel()
        Me.lblTiendaCompleta = New System.Windows.Forms.Label()
        Me.pnlColorPartidaIncompleta = New System.Windows.Forms.Panel()
        Me.pnlGrids = New System.Windows.Forms.Panel()
        Me.sPCConfirmacionOrdenesTrabajo = New System.Windows.Forms.SplitContainer()
        Me.grdPartidas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmar = New System.Windows.Forms.SplitContainer()
        Me.grdParesAConfirmar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sPCParesConfirmadosAnteriormente = New System.Windows.Forms.SplitContainer()
        Me.lblParesConfirmadosAnteriormente = New System.Windows.Forms.Label()
        Me.grdParesConfirmados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.lblEstatusID = New System.Windows.Forms.Label()
        Me.lblOTSAY = New System.Windows.Forms.Label()
        Me.lblTextoOTSAY = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.lblEstatusApartado = New System.Windows.Forms.Label()
        Me.lblIdPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoTotalApartadosSeleccionados = New System.Windows.Forms.Label()
        Me.lblFPreparacion = New System.Windows.Forms.Label()
        Me.lblTextoFPreparacion = New System.Windows.Forms.Label()
        Me.lblEntregaInmediata = New System.Windows.Forms.Label()
        Me.lblOrdenCliente = New System.Windows.Forms.Label()
        Me.lblTextoOrdenCliente = New System.Windows.Forms.Label()
        Me.lblFSolicitada = New System.Windows.Forms.Label()
        Me.lblTextoFSolicitada = New System.Windows.Forms.Label()
        Me.lblIdPedidoSAY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSAY = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblTextoCliente = New System.Windows.Forms.Label()
        Me.lblOTSICY = New System.Windows.Forms.Label()
        Me.lbltextoOTSICY = New System.Windows.Forms.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.cmsSeleccionarVariasPartidas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.pnlGrids.SuspendLayout()
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.SuspendLayout()
        Me.sPCConfirmacionOrdenesTrabajo.SuspendLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmar.Panel1.SuspendLayout()
        Me.sPCParesConfirmar.Panel2.SuspendLayout()
        Me.sPCParesConfirmar.SuspendLayout()
        CType(Me.grdParesAConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.SuspendLayout()
        CType(Me.grdParesConfirmados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.cmsSeleccionarVariasPartidas.SuspendLayout()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1307, 70)
        Me.pnlHeader.TabIndex = 8
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitulo)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(860, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(447, 70)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(166, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(176, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Confirmación de OTs"
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
        Me.pnlBtn.Controls.Add(Me.lblVerDistribucion)
        Me.pnlBtn.Controls.Add(Me.btnVerDetalle)
        Me.pnlBtn.Controls.Add(Me.lblCancelarPartidas)
        Me.pnlBtn.Controls.Add(Me.lblGenerarXML)
        Me.pnlBtn.Controls.Add(Me.btnExportarDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoExportarDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoImprimirDetalles)
        Me.pnlBtn.Controls.Add(Me.btnImprimirDetalles)
        Me.pnlBtn.Controls.Add(Me.lblTextoCancelarConfirmacionActual)
        Me.pnlBtn.Controls.Add(Me.btnCancelarPartidasOT)
        Me.pnlBtn.Controls.Add(Me.btnCancelarConfirmacion)
        Me.pnlBtn.Controls.Add(Me.btnExportarConfirmados)
        Me.pnlBtn.Controls.Add(Me.lblTextoExportarConfirmados)
        Me.pnlBtn.Controls.Add(Me.lblTerminal)
        Me.pnlBtn.Controls.Add(Me.btnTerminal)
        Me.pnlBtn.Controls.Add(Me.btnGenerarXML)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(774, 70)
        Me.pnlBtn.TabIndex = 1
        '
        'lblVerDistribucion
        '
        Me.lblVerDistribucion.AutoSize = True
        Me.lblVerDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerDistribucion.Location = New System.Drawing.Point(366, 40)
        Me.lblVerDistribucion.Name = "lblVerDistribucion"
        Me.lblVerDistribucion.Size = New System.Drawing.Size(62, 26)
        Me.lblVerDistribucion.TabIndex = 42
        Me.lblVerDistribucion.Text = "Ver" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distribución"
        Me.lblVerDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerDetalle.Location = New System.Drawing.Point(379, 8)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalle.TabIndex = 43
        Me.btnVerDetalle.UseVisualStyleBackColor = True
        '
        'lblCancelarPartidas
        '
        Me.lblCancelarPartidas.AutoSize = True
        Me.lblCancelarPartidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelarPartidas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarPartidas.Location = New System.Drawing.Point(115, 40)
        Me.lblCancelarPartidas.Name = "lblCancelarPartidas"
        Me.lblCancelarPartidas.Size = New System.Drawing.Size(52, 26)
        Me.lblCancelarPartidas.TabIndex = 41
        Me.lblCancelarPartidas.Text = "Cancelar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Partidas"
        Me.lblCancelarPartidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGenerarXML
        '
        Me.lblGenerarXML.AutoSize = True
        Me.lblGenerarXML.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarXML.Location = New System.Drawing.Point(120, 40)
        Me.lblGenerarXML.Name = "lblGenerarXML"
        Me.lblGenerarXML.Size = New System.Drawing.Size(48, 26)
        Me.lblGenerarXML.TabIndex = 40
        Me.lblGenerarXML.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XML"
        Me.lblGenerarXML.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblGenerarXML.Visible = False
        '
        'btnExportarDetalles
        '
        Me.btnExportarDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarDetalles.Location = New System.Drawing.Point(15, 8)
        Me.btnExportarDetalles.Name = "btnExportarDetalles"
        Me.btnExportarDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarDetalles.TabIndex = 37
        Me.btnExportarDetalles.UseVisualStyleBackColor = True
        '
        'lblTextoExportarDetalles
        '
        Me.lblTextoExportarDetalles.AutoSize = True
        Me.lblTextoExportarDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportarDetalles.Location = New System.Drawing.Point(8, 40)
        Me.lblTextoExportarDetalles.Name = "lblTextoExportarDetalles"
        Me.lblTextoExportarDetalles.Size = New System.Drawing.Size(49, 26)
        Me.lblTextoExportarDetalles.TabIndex = 38
        Me.lblTextoExportarDetalles.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalles"
        Me.lblTextoExportarDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoImprimirDetalles
        '
        Me.lblTextoImprimirDetalles.AutoSize = True
        Me.lblTextoImprimirDetalles.Enabled = False
        Me.lblTextoImprimirDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoImprimirDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoImprimirDetalles.Location = New System.Drawing.Point(305, 40)
        Me.lblTextoImprimirDetalles.Name = "lblTextoImprimirDetalles"
        Me.lblTextoImprimirDetalles.Size = New System.Drawing.Size(42, 26)
        Me.lblTextoImprimirDetalles.TabIndex = 35
        Me.lblTextoImprimirDetalles.Text = "Imprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalle"
        Me.lblTextoImprimirDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoImprimirDetalles.Visible = False
        '
        'btnImprimirDetalles
        '
        Me.btnImprimirDetalles.Enabled = False
        Me.btnImprimirDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirDetalles.Location = New System.Drawing.Point(308, 8)
        Me.btnImprimirDetalles.Name = "btnImprimirDetalles"
        Me.btnImprimirDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirDetalles.TabIndex = 36
        Me.btnImprimirDetalles.UseVisualStyleBackColor = True
        Me.btnImprimirDetalles.Visible = False
        '
        'lblTextoCancelarConfirmacionActual
        '
        Me.lblTextoCancelarConfirmacionActual.AutoSize = True
        Me.lblTextoCancelarConfirmacionActual.Enabled = False
        Me.lblTextoCancelarConfirmacionActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCancelarConfirmacionActual.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelarConfirmacionActual.Location = New System.Drawing.Point(224, 40)
        Me.lblTextoCancelarConfirmacionActual.Name = "lblTextoCancelarConfirmacionActual"
        Me.lblTextoCancelarConfirmacionActual.Size = New System.Drawing.Size(66, 26)
        Me.lblTextoCancelarConfirmacionActual.TabIndex = 33
        Me.lblTextoCancelarConfirmacionActual.Text = "Cancelar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Confirnación"
        Me.lblTextoCancelarConfirmacionActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelarPartidasOT
        '
        Me.btnCancelarPartidasOT.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_321
        Me.btnCancelarPartidasOT.Location = New System.Drawing.Point(123, 8)
        Me.btnCancelarPartidasOT.Name = "btnCancelarPartidasOT"
        Me.btnCancelarPartidasOT.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPartidasOT.TabIndex = 34
        Me.btnCancelarPartidasOT.UseVisualStyleBackColor = True
        '
        'btnCancelarConfirmacion
        '
        Me.btnCancelarConfirmacion.Enabled = False
        Me.btnCancelarConfirmacion.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_321
        Me.btnCancelarConfirmacion.Location = New System.Drawing.Point(240, 8)
        Me.btnCancelarConfirmacion.Name = "btnCancelarConfirmacion"
        Me.btnCancelarConfirmacion.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarConfirmacion.TabIndex = 34
        Me.btnCancelarConfirmacion.UseVisualStyleBackColor = True
        '
        'btnExportarConfirmados
        '
        Me.btnExportarConfirmados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarConfirmados.Location = New System.Drawing.Point(66, 8)
        Me.btnExportarConfirmados.Name = "btnExportarConfirmados"
        Me.btnExportarConfirmados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarConfirmados.TabIndex = 4
        Me.btnExportarConfirmados.UseVisualStyleBackColor = True
        '
        'lblTextoExportarConfirmados
        '
        Me.lblTextoExportarConfirmados.AutoSize = True
        Me.lblTextoExportarConfirmados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportarConfirmados.Location = New System.Drawing.Point(48, 40)
        Me.lblTextoExportarConfirmados.Name = "lblTextoExportarConfirmados"
        Me.lblTextoExportarConfirmados.Size = New System.Drawing.Size(61, 26)
        Me.lblTextoExportarConfirmados.TabIndex = 32
        Me.lblTextoExportarConfirmados.Text = "    Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      Pares"
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTerminal.Location = New System.Drawing.Point(174, 40)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(47, 13)
        Me.lblTerminal.TabIndex = 2
        Me.lblTerminal.Text = "Terminal"
        '
        'btnTerminal
        '
        Me.btnTerminal.Image = Global.Ventas.Vista.My.Resources.Resources.calculo_32
        Me.btnTerminal.Location = New System.Drawing.Point(182, 8)
        Me.btnTerminal.Name = "btnTerminal"
        Me.btnTerminal.Size = New System.Drawing.Size(32, 32)
        Me.btnTerminal.TabIndex = 3
        Me.btnTerminal.UseVisualStyleBackColor = True
        '
        'btnGenerarXML
        '
        Me.btnGenerarXML.Image = Global.Ventas.Vista.My.Resources.Resources.nuevo_321
        Me.btnGenerarXML.Location = New System.Drawing.Point(124, 8)
        Me.btnGenerarXML.Name = "btnGenerarXML"
        Me.btnGenerarXML.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarXML.TabIndex = 39
        Me.btnGenerarXML.UseVisualStyleBackColor = True
        Me.btnGenerarXML.Visible = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblCantidadAtadosIncompletos)
        Me.pnlPie.Controls.Add(Me.lblAtadosIncompletos)
        Me.pnlPie.Controls.Add(Me.lblCancelados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Controls.Add(Me.lblColorRechazada)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.pnlPartidaCancelada)
        Me.pnlPie.Controls.Add(Me.pnlEntregaVenceHoy)
        Me.pnlPie.Controls.Add(Me.lblTotalCodigosInvalidos)
        Me.pnlPie.Controls.Add(Me.Label20)
        Me.pnlPie.Controls.Add(Me.lblTextoCodigosInvalidos)
        Me.pnlPie.Controls.Add(Me.lblTextoOTAnterior)
        Me.pnlPie.Controls.Add(Me.lblTextoOTSiguiente)
        Me.pnlPie.Controls.Add(Me.btnAnteriorOT)
        Me.pnlPie.Controls.Add(Me.btnSiguienteOT)
        Me.pnlPie.Controls.Add(Me.lblNotaCodigoInvalido)
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
        Me.pnlPie.Location = New System.Drawing.Point(0, 462)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1307, 61)
        Me.pnlPie.TabIndex = 9
        '
        'lblCantidadAtadosIncompletos
        '
        Me.lblCantidadAtadosIncompletos.AutoSize = True
        Me.lblCantidadAtadosIncompletos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadAtadosIncompletos.ForeColor = System.Drawing.Color.Red
        Me.lblCantidadAtadosIncompletos.Location = New System.Drawing.Point(616, 11)
        Me.lblCantidadAtadosIncompletos.Name = "lblCantidadAtadosIncompletos"
        Me.lblCantidadAtadosIncompletos.Size = New System.Drawing.Size(14, 13)
        Me.lblCantidadAtadosIncompletos.TabIndex = 43
        Me.lblCantidadAtadosIncompletos.Text = "0"
        Me.lblCantidadAtadosIncompletos.Visible = False
        '
        'lblAtadosIncompletos
        '
        Me.lblAtadosIncompletos.AutoSize = True
        Me.lblAtadosIncompletos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosIncompletos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAtadosIncompletos.Location = New System.Drawing.Point(514, 11)
        Me.lblAtadosIncompletos.Name = "lblAtadosIncompletos"
        Me.lblAtadosIncompletos.Size = New System.Drawing.Size(103, 13)
        Me.lblAtadosIncompletos.TabIndex = 42
        Me.lblAtadosIncompletos.Text = "Atados Incompletos:"
        Me.lblAtadosIncompletos.Visible = False
        '
        'lblCancelados
        '
        Me.lblCancelados.AutoSize = True
        Me.lblCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelados.ForeColor = System.Drawing.Color.RosyBrown
        Me.lblCancelados.Location = New System.Drawing.Point(1109, 44)
        Me.lblCancelados.Name = "lblCancelados"
        Me.lblCancelados.Size = New System.Drawing.Size(14, 13)
        Me.lblCancelados.TabIndex = 41
        Me.lblCancelados.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(914, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Total de pares cancelados:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(296, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Partida Rechazada"
        '
        'lblColorRechazada
        '
        Me.lblColorRechazada.BackColor = System.Drawing.Color.SandyBrown
        Me.lblColorRechazada.Location = New System.Drawing.Point(275, 9)
        Me.lblColorRechazada.Name = "lblColorRechazada"
        Me.lblColorRechazada.Size = New System.Drawing.Size(13, 15)
        Me.lblColorRechazada.TabIndex = 38
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
        'pnlEntregaVenceHoy
        '
        Me.pnlEntregaVenceHoy.BackColor = System.Drawing.Color.Thistle
        Me.pnlEntregaVenceHoy.ForeColor = System.Drawing.Color.Black
        Me.pnlEntregaVenceHoy.Location = New System.Drawing.Point(156, 35)
        Me.pnlEntregaVenceHoy.Name = "pnlEntregaVenceHoy"
        Me.pnlEntregaVenceHoy.Size = New System.Drawing.Size(15, 15)
        Me.pnlEntregaVenceHoy.TabIndex = 21
        '
        'lblTotalCodigosInvalidos
        '
        Me.lblTotalCodigosInvalidos.AutoSize = True
        Me.lblTotalCodigosInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCodigosInvalidos.ForeColor = System.Drawing.Color.Red
        Me.lblTotalCodigosInvalidos.Location = New System.Drawing.Point(494, 11)
        Me.lblTotalCodigosInvalidos.Name = "lblTotalCodigosInvalidos"
        Me.lblTotalCodigosInvalidos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalCodigosInvalidos.TabIndex = 37
        Me.lblTotalCodigosInvalidos.Text = "0"
        Me.lblTotalCodigosInvalidos.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(174, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Partida en ejecución"
        '
        'lblTextoCodigosInvalidos
        '
        Me.lblTextoCodigosInvalidos.AutoSize = True
        Me.lblTextoCodigosInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCodigosInvalidos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTextoCodigosInvalidos.Location = New System.Drawing.Point(396, 11)
        Me.lblTextoCodigosInvalidos.Name = "lblTextoCodigosInvalidos"
        Me.lblTextoCodigosInvalidos.Size = New System.Drawing.Size(92, 13)
        Me.lblTextoCodigosInvalidos.TabIndex = 36
        Me.lblTextoCodigosInvalidos.Text = "Códigos inválidos:"
        Me.lblTextoCodigosInvalidos.Visible = False
        '
        'lblTextoOTAnterior
        '
        Me.lblTextoOTAnterior.AutoSize = True
        Me.lblTextoOTAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOTAnterior.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoOTAnterior.Location = New System.Drawing.Point(700, 43)
        Me.lblTextoOTAnterior.Name = "lblTextoOTAnterior"
        Me.lblTextoOTAnterior.Size = New System.Drawing.Size(43, 13)
        Me.lblTextoOTAnterior.TabIndex = 35
        Me.lblTextoOTAnterior.Text = "Anterior"
        '
        'lblTextoOTSiguiente
        '
        Me.lblTextoOTSiguiente.AutoSize = True
        Me.lblTextoOTSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOTSiguiente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoOTSiguiente.Location = New System.Drawing.Point(748, 43)
        Me.lblTextoOTSiguiente.Name = "lblTextoOTSiguiente"
        Me.lblTextoOTSiguiente.Size = New System.Drawing.Size(51, 13)
        Me.lblTextoOTSiguiente.TabIndex = 34
        Me.lblTextoOTSiguiente.Text = "Siguiente"
        '
        'btnAnteriorOT
        '
        Me.btnAnteriorOT.Image = CType(resources.GetObject("btnAnteriorOT.Image"), System.Drawing.Image)
        Me.btnAnteriorOT.Location = New System.Drawing.Point(704, 9)
        Me.btnAnteriorOT.Name = "btnAnteriorOT"
        Me.btnAnteriorOT.Size = New System.Drawing.Size(32, 32)
        Me.btnAnteriorOT.TabIndex = 20
        Me.btnAnteriorOT.UseVisualStyleBackColor = True
        '
        'btnSiguienteOT
        '
        Me.btnSiguienteOT.Image = CType(resources.GetObject("btnSiguienteOT.Image"), System.Drawing.Image)
        Me.btnSiguienteOT.Location = New System.Drawing.Point(757, 9)
        Me.btnSiguienteOT.Name = "btnSiguienteOT"
        Me.btnSiguienteOT.Size = New System.Drawing.Size(32, 32)
        Me.btnSiguienteOT.TabIndex = 19
        Me.btnSiguienteOT.UseVisualStyleBackColor = True
        '
        'lblNotaCodigoInvalido
        '
        Me.lblNotaCodigoInvalido.AutoSize = True
        Me.lblNotaCodigoInvalido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNotaCodigoInvalido.ForeColor = System.Drawing.Color.Black
        Me.lblNotaCodigoInvalido.Location = New System.Drawing.Point(319, 36)
        Me.lblNotaCodigoInvalido.Name = "lblNotaCodigoInvalido"
        Me.lblNotaCodigoInvalido.Size = New System.Drawing.Size(317, 13)
        Me.lblNotaCodigoInvalido.TabIndex = 18
        Me.lblNotaCodigoInvalido.Text = "Par inválido: El código no pertenece ala OT o ya está confirmado."
        Me.lblNotaCodigoInvalido.Visible = False
        '
        'lblPorConfirmar
        '
        Me.lblPorConfirmar.AutoSize = True
        Me.lblPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorConfirmar.ForeColor = System.Drawing.Color.Red
        Me.lblPorConfirmar.Location = New System.Drawing.Point(1109, 30)
        Me.lblPorConfirmar.Name = "lblPorConfirmar"
        Me.lblPorConfirmar.Size = New System.Drawing.Size(14, 13)
        Me.lblPorConfirmar.TabIndex = 11
        Me.lblPorConfirmar.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(905, 30)
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
        Me.lblTotalConfirmados.Location = New System.Drawing.Point(1109, 16)
        Me.lblTotalConfirmados.Name = "lblTotalConfirmados"
        Me.lblTotalConfirmados.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalConfirmados.TabIndex = 9
        Me.lblTotalConfirmados.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(911, 16)
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
        Me.lblTotalPares.Location = New System.Drawing.Point(1109, 3)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 7
        Me.lblTotalPares.Text = "0"
        '
        'lblTotalP
        '
        Me.lblTotalP.AutoSize = True
        Me.lblTotalP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalP.Location = New System.Drawing.Point(977, 2)
        Me.lblTotalP.Name = "lblTotalP"
        Me.lblTotalP.Size = New System.Drawing.Size(93, 13)
        Me.lblTotalP.TabIndex = 6
        Me.lblTotalP.Text = "Total de pares:"
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
        Me.pnlSalir.Location = New System.Drawing.Point(1139, 0)
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
        Me.lblLimpiar.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(23, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
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
        Me.lblParInvalido.Size = New System.Drawing.Size(63, 13)
        Me.lblParInvalido.TabIndex = 3
        Me.lblParInvalido.Text = "Par Erróneo"
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
        'pnlGrids
        '
        Me.pnlGrids.Controls.Add(Me.sPCConfirmacionOrdenesTrabajo)
        Me.pnlGrids.Controls.Add(Me.Panel3)
        Me.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrids.Location = New System.Drawing.Point(0, 70)
        Me.pnlGrids.Name = "pnlGrids"
        Me.pnlGrids.Size = New System.Drawing.Size(1307, 392)
        Me.pnlGrids.TabIndex = 12
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
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.Controls.Add(Me.grdPartidas)
        '
        'sPCConfirmacionOrdenesTrabajo.Panel2
        '
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.Controls.Add(Me.sPCParesConfirmar)
        Me.sPCConfirmacionOrdenesTrabajo.Panel2MinSize = 0
        Me.sPCConfirmacionOrdenesTrabajo.Size = New System.Drawing.Size(1307, 349)
        Me.sPCConfirmacionOrdenesTrabajo.SplitterDistance = 570
        Me.sPCConfirmacionOrdenesTrabajo.TabIndex = 11
        '
        'grdPartidas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidas.DisplayLayout.Appearance = Appearance1
        Me.grdPartidas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPartidas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPartidas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPartidas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPartidas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPartidas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidas.Location = New System.Drawing.Point(0, 0)
        Me.grdPartidas.Name = "grdPartidas"
        Me.grdPartidas.Size = New System.Drawing.Size(568, 347)
        Me.grdPartidas.TabIndex = 12
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
        Me.sPCParesConfirmar.Panel1.Controls.Add(Me.grdParesAConfirmar)
        Me.sPCParesConfirmar.Panel1MinSize = 0
        '
        'sPCParesConfirmar.Panel2
        '
        Me.sPCParesConfirmar.Panel2.Controls.Add(Me.sPCParesConfirmadosAnteriormente)
        Me.sPCParesConfirmar.Panel2MinSize = 0
        Me.sPCParesConfirmar.Size = New System.Drawing.Size(733, 349)
        Me.sPCParesConfirmar.SplitterDistance = 160
        Me.sPCParesConfirmar.TabIndex = 0
        '
        'grdParesAConfirmar
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesAConfirmar.DisplayLayout.Appearance = Appearance3
        Me.grdParesAConfirmar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesAConfirmar.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesAConfirmar.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesAConfirmar.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesAConfirmar.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesAConfirmar.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesAConfirmar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesAConfirmar.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdParesAConfirmar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesAConfirmar.Location = New System.Drawing.Point(0, 0)
        Me.grdParesAConfirmar.Name = "grdParesAConfirmar"
        Me.grdParesAConfirmar.Size = New System.Drawing.Size(731, 158)
        Me.grdParesAConfirmar.TabIndex = 12
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
        Me.sPCParesConfirmadosAnteriormente.Panel2.Controls.Add(Me.grdParesConfirmados)
        Me.sPCParesConfirmadosAnteriormente.Size = New System.Drawing.Size(731, 183)
        Me.sPCParesConfirmadosAnteriormente.SplitterDistance = 25
        Me.sPCParesConfirmadosAnteriormente.SplitterWidth = 1
        Me.sPCParesConfirmadosAnteriormente.TabIndex = 0
        '
        'lblParesConfirmadosAnteriormente
        '
        Me.lblParesConfirmadosAnteriormente.AutoSize = True
        Me.lblParesConfirmadosAnteriormente.Location = New System.Drawing.Point(0, 0)
        Me.lblParesConfirmadosAnteriormente.Name = "lblParesConfirmadosAnteriormente"
        Me.lblParesConfirmadosAnteriormente.Size = New System.Drawing.Size(34, 13)
        Me.lblParesConfirmadosAnteriormente.TabIndex = 1
        Me.lblParesConfirmadosAnteriormente.Text = "Pares"
        '
        'grdParesConfirmados
        '
        Me.grdParesConfirmados.Cursor = System.Windows.Forms.Cursors.Default
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmados.DisplayLayout.Appearance = Appearance5
        Me.grdParesConfirmados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesConfirmados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesConfirmados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesConfirmados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesConfirmados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesConfirmados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesConfirmados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesConfirmados.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdParesConfirmados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesConfirmados.Location = New System.Drawing.Point(0, 0)
        Me.grdParesConfirmados.Name = "grdParesConfirmados"
        Me.grdParesConfirmados.Size = New System.Drawing.Size(731, 157)
        Me.grdParesConfirmados.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel3.Controls.Add(Me.lblEstatusID)
        Me.Panel3.Controls.Add(Me.lblOTSAY)
        Me.Panel3.Controls.Add(Me.lblTextoOTSAY)
        Me.Panel3.Controls.Add(Me.lblTotalSeleccionados)
        Me.Panel3.Controls.Add(Me.lblEstatusApartado)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoTotalApartadosSeleccionados)
        Me.Panel3.Controls.Add(Me.lblFPreparacion)
        Me.Panel3.Controls.Add(Me.lblTextoFPreparacion)
        Me.Panel3.Controls.Add(Me.lblEntregaInmediata)
        Me.Panel3.Controls.Add(Me.lblOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblTextoOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblFSolicitada)
        Me.Panel3.Controls.Add(Me.lblTextoFSolicitada)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblNombreCliente)
        Me.Panel3.Controls.Add(Me.lblTextoCliente)
        Me.Panel3.Controls.Add(Me.lblOTSICY)
        Me.Panel3.Controls.Add(Me.lbltextoOTSICY)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1307, 43)
        Me.Panel3.TabIndex = 9
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(15, 24)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 58
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'lblEstatusID
        '
        Me.lblEstatusID.AutoSize = True
        Me.lblEstatusID.Location = New System.Drawing.Point(881, 27)
        Me.lblEstatusID.Name = "lblEstatusID"
        Me.lblEstatusID.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatusID.TabIndex = 38
        Me.lblEstatusID.Text = "-"
        Me.lblEstatusID.Visible = False
        '
        'lblOTSAY
        '
        Me.lblOTSAY.AutoSize = True
        Me.lblOTSAY.Location = New System.Drawing.Point(455, 23)
        Me.lblOTSAY.Name = "lblOTSAY"
        Me.lblOTSAY.Size = New System.Drawing.Size(13, 13)
        Me.lblOTSAY.TabIndex = 35
        Me.lblOTSAY.Text = "0"
        '
        'lblTextoOTSAY
        '
        Me.lblTextoOTSAY.AutoSize = True
        Me.lblTextoOTSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOTSAY.Location = New System.Drawing.Point(376, 23)
        Me.lblTextoOTSAY.Name = "lblTextoOTSAY"
        Me.lblTextoOTSAY.Size = New System.Drawing.Size(56, 13)
        Me.lblTextoOTSAY.TabIndex = 34
        Me.lblTextoOTSAY.Text = "OT SAY:"
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(174, 11)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(10, 13)
        Me.lblTotalSeleccionados.TabIndex = 33
        Me.lblTotalSeleccionados.Text = "-"
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
        Me.lblIdPedidoSICY.Location = New System.Drawing.Point(611, 24)
        Me.lblIdPedidoSICY.Name = "lblIdPedidoSICY"
        Me.lblIdPedidoSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdPedidoSICY.TabIndex = 31
        Me.lblIdPedidoSICY.Text = "0"
        '
        'lblTextoPedidoSICY
        '
        Me.lblTextoPedidoSICY.AutoSize = True
        Me.lblTextoPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSICY.Location = New System.Drawing.Point(532, 24)
        Me.lblTextoPedidoSICY.Name = "lblTextoPedidoSICY"
        Me.lblTextoPedidoSICY.Size = New System.Drawing.Size(82, 13)
        Me.lblTextoPedidoSICY.TabIndex = 30
        Me.lblTextoPedidoSICY.Text = "Pedido SICY:"
        '
        'lblTextoTotalApartadosSeleccionados
        '
        Me.lblTextoTotalApartadosSeleccionados.AutoSize = True
        Me.lblTextoTotalApartadosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTotalApartadosSeleccionados.Location = New System.Drawing.Point(12, 11)
        Me.lblTextoTotalApartadosSeleccionados.Name = "lblTextoTotalApartadosSeleccionados"
        Me.lblTextoTotalApartadosSeleccionados.Size = New System.Drawing.Size(158, 13)
        Me.lblTextoTotalApartadosSeleccionados.TabIndex = 29
        Me.lblTextoTotalApartadosSeleccionados.Text = "Total OTS seleccionados: "
        '
        'lblFPreparacion
        '
        Me.lblFPreparacion.AutoSize = True
        Me.lblFPreparacion.Location = New System.Drawing.Point(1058, 24)
        Me.lblFPreparacion.Name = "lblFPreparacion"
        Me.lblFPreparacion.Size = New System.Drawing.Size(10, 13)
        Me.lblFPreparacion.TabIndex = 18
        Me.lblFPreparacion.Text = "-"
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
        '
        'lblFSolicitada
        '
        Me.lblFSolicitada.AutoSize = True
        Me.lblFSolicitada.Location = New System.Drawing.Point(1058, 6)
        Me.lblFSolicitada.Name = "lblFSolicitada"
        Me.lblFSolicitada.Size = New System.Drawing.Size(10, 13)
        Me.lblFSolicitada.TabIndex = 11
        Me.lblFSolicitada.Text = "-"
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
        '
        'lblIdPedidoSAY
        '
        Me.lblIdPedidoSAY.AutoSize = True
        Me.lblIdPedidoSAY.Location = New System.Drawing.Point(611, 6)
        Me.lblIdPedidoSAY.Name = "lblIdPedidoSAY"
        Me.lblIdPedidoSAY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdPedidoSAY.TabIndex = 9
        Me.lblIdPedidoSAY.Text = "0"
        '
        'lblTextoPedidoSAY
        '
        Me.lblTextoPedidoSAY.AutoSize = True
        Me.lblTextoPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSAY.Location = New System.Drawing.Point(532, 6)
        Me.lblTextoPedidoSAY.Name = "lblTextoPedidoSAY"
        Me.lblTextoPedidoSAY.Size = New System.Drawing.Size(78, 13)
        Me.lblTextoPedidoSAY.TabIndex = 8
        Me.lblTextoPedidoSAY.Text = "Pedido SAY:"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(69, 10)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "-"
        '
        'lblTextoCliente
        '
        Me.lblTextoCliente.AutoSize = True
        Me.lblTextoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCliente.Location = New System.Drawing.Point(12, 10)
        Me.lblTextoCliente.Name = "lblTextoCliente"
        Me.lblTextoCliente.Size = New System.Drawing.Size(50, 13)
        Me.lblTextoCliente.TabIndex = 3
        Me.lblTextoCliente.Text = "Cliente:"
        '
        'lblOTSICY
        '
        Me.lblOTSICY.AutoSize = True
        Me.lblOTSICY.Location = New System.Drawing.Point(455, 24)
        Me.lblOTSICY.Name = "lblOTSICY"
        Me.lblOTSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblOTSICY.TabIndex = 37
        Me.lblOTSICY.Text = "0"
        Me.lblOTSICY.Visible = False
        '
        'lbltextoOTSICY
        '
        Me.lbltextoOTSICY.AutoSize = True
        Me.lbltextoOTSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltextoOTSICY.Location = New System.Drawing.Point(376, 24)
        Me.lbltextoOTSICY.Name = "lbltextoOTSICY"
        Me.lbltextoOTSICY.Size = New System.Drawing.Size(60, 13)
        Me.lbltextoOTSICY.TabIndex = 36
        Me.lbltextoOTSICY.Text = "OT SICY:"
        Me.lbltextoOTSICY.Visible = False
        '
        'cmsSeleccionarVariasPartidas
        '
        Me.cmsSeleccionarVariasPartidas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarToolStripMenuItem, Me.QuitarSelecciónToolStripMenuItem})
        Me.cmsSeleccionarVariasPartidas.Name = "cmsSeleccionarVariasPartidas"
        Me.cmsSeleccionarVariasPartidas.Size = New System.Drawing.Size(160, 48)
        '
        'SeleccionarToolStripMenuItem
        '
        Me.SeleccionarToolStripMenuItem.Name = "SeleccionarToolStripMenuItem"
        Me.SeleccionarToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SeleccionarToolStripMenuItem.Text = "Seleccionar"
        '
        'QuitarSelecciónToolStripMenuItem
        '
        Me.QuitarSelecciónToolStripMenuItem.Name = "QuitarSelecciónToolStripMenuItem"
        Me.QuitarSelecciónToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.QuitarSelecciónToolStripMenuItem.Text = "Quitar selección"
        '
        'DetallesOrdenTrabajoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1307, 523)
        Me.Controls.Add(Me.pnlGrids)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "DetallesOrdenTrabajoForm"
        Me.Text = "Confirmación de OTs"
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
        Me.pnlGrids.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel1.ResumeLayout(False)
        Me.sPCConfirmacionOrdenesTrabajo.Panel2.ResumeLayout(False)
        CType(Me.sPCConfirmacionOrdenesTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCConfirmacionOrdenesTrabajo.ResumeLayout(False)
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmar.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.ResumeLayout(False)
        CType(Me.grdParesAConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmadosAnteriormente.Panel1.PerformLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.ResumeLayout(False)
        CType(Me.grdParesConfirmados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.cmsSeleccionarVariasPartidas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents btnExportarDetalles As System.Windows.Forms.Button
    Friend WithEvents lblTextoExportarDetalles As System.Windows.Forms.Label
    Friend WithEvents lblTextoImprimirDetalles As System.Windows.Forms.Label
    Friend WithEvents btnImprimirDetalles As System.Windows.Forms.Button
    Friend WithEvents lblTextoCancelarConfirmacionActual As System.Windows.Forms.Label
    Friend WithEvents btnCancelarConfirmacion As System.Windows.Forms.Button
    Friend WithEvents btnExportarConfirmados As System.Windows.Forms.Button
    Friend WithEvents lblTextoExportarConfirmados As System.Windows.Forms.Label
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents btnTerminal As System.Windows.Forms.Button
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblCancelados As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlPartidaCancelada As System.Windows.Forms.Panel
    Friend WithEvents lblTotalCodigosInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblTextoCodigosInvalidos As System.Windows.Forms.Label
    Friend WithEvents lblTextoOTAnterior As System.Windows.Forms.Label
    Friend WithEvents lblTextoOTSiguiente As System.Windows.Forms.Label
    Friend WithEvents btnAnteriorOT As System.Windows.Forms.Button
    Friend WithEvents btnSiguienteOT As System.Windows.Forms.Button
    Friend WithEvents lblNotaCodigoInvalido As System.Windows.Forms.Label
    Friend WithEvents lblPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalConfirmados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblTotalP As System.Windows.Forms.Label
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblParInvalido As System.Windows.Forms.Label
    Friend WithEvents pnlParExcedente As System.Windows.Forms.Panel
    Friend WithEvents lblTiendaCompleta As System.Windows.Forms.Label
    Friend WithEvents pnlColorPartidaIncompleta As System.Windows.Forms.Panel
    Friend WithEvents pnlGrids As System.Windows.Forms.Panel
    Friend WithEvents sPCConfirmacionOrdenesTrabajo As System.Windows.Forms.SplitContainer
    Friend WithEvents grdPartidas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents sPCParesConfirmar As System.Windows.Forms.SplitContainer
    Friend WithEvents grdParesAConfirmar As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents sPCParesConfirmadosAnteriormente As System.Windows.Forms.SplitContainer
    Friend WithEvents lblParesConfirmadosAnteriormente As System.Windows.Forms.Label
    Friend WithEvents grdParesConfirmados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblEstatusApartado As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoTotalApartadosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblEntregaInmediata As System.Windows.Forms.Label
    Friend WithEvents lblOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblTextoFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoCliente As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblOTSICY As System.Windows.Forms.Label
    Friend WithEvents lbltextoOTSICY As System.Windows.Forms.Label
    Friend WithEvents lblOTSAY As System.Windows.Forms.Label
    Friend WithEvents lblTextoOTSAY As System.Windows.Forms.Label
    Friend WithEvents pnlEntregaVenceHoy As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblEstatusID As System.Windows.Forms.Label
    Friend WithEvents lblCantidadAtadosIncompletos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosIncompletos As System.Windows.Forms.Label
    Friend WithEvents btnGenerarXML As System.Windows.Forms.Button
    Friend WithEvents lblGenerarXML As System.Windows.Forms.Label
    Friend WithEvents lblCancelarPartidas As System.Windows.Forms.Label
    Friend WithEvents btnCancelarPartidasOT As System.Windows.Forms.Button
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents cmsSeleccionarVariasPartidas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarSelecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblColorRechazada As System.Windows.Forms.Panel
    Friend WithEvents lblVerDistribucion As Label
    Friend WithEvents btnVerDetalle As Button
End Class
