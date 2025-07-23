<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProspectaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProspectaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnComentarioRevision = New System.Windows.Forms.Button()
        Me.lblAgenda = New System.Windows.Forms.Label()
        Me.btnAgenda = New System.Windows.Forms.Button()
        Me.lblSeguimientoClientes = New System.Windows.Forms.Label()
        Me.btnSeguimientoClientes = New System.Windows.Forms.Button()
        Me.btnSeguimietoPares = New System.Windows.Forms.Button()
        Me.lblSeguimientoPares = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.pnlTodasCot = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlAlgunasCot = New System.Windows.Forms.Panel()
        Me.pnlNingunaCot = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tmsiReproceso = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBloqueados = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiProduccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiApartados = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsTiposResumen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtmFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblAgenteVentas = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grdAtnClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtStatusProspecta = New System.Windows.Forms.TextBox()
        Me.dtmFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.grdFiltroClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnFiltroAgenteVentas = New System.Windows.Forms.Button()
        Me.grdFiltroAgenteVentas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAtnClientes = New System.Windows.Forms.Button()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnActualizarStatus = New System.Windows.Forms.Button()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudNumSemana = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grdResumenDiario = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdNivelPartidaOculto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.grdNivelPartida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblParesConfirmadosAnteriormente = New System.Windows.Forms.Label()
        Me.sPCParesConfirmadosAnteriormente = New System.Windows.Forms.SplitContainer()
        Me.grdNivelPedido = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTextoPedidos = New System.Windows.Forms.Label()
        Me.spcPedidos = New System.Windows.Forms.SplitContainer()
        Me.sPCParesConfirmar = New System.Windows.Forms.SplitContainer()
        Me.grdNivelCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.spcClientes = New System.Windows.Forms.SplitContainer()
        Me.pnlGrids = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdTipoAgenda = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgendaProyecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgendaDeEntregasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridExcelExporter2 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.cmsTipoExportacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmClientesPartidas = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.cmsTiposResumen.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        CType(Me.grdAtnClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFiltroClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdFiltroAgenteVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.grdResumenDiario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdNivelPartidaOculto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        CType(Me.grdNivelPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.SuspendLayout()
        Me.sPCParesConfirmadosAnteriormente.SuspendLayout()
        CType(Me.grdNivelPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spcPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcPedidos.Panel1.SuspendLayout()
        Me.spcPedidos.Panel2.SuspendLayout()
        Me.spcPedidos.SuspendLayout()
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sPCParesConfirmar.Panel1.SuspendLayout()
        Me.sPCParesConfirmar.Panel2.SuspendLayout()
        Me.sPCParesConfirmar.SuspendLayout()
        CType(Me.grdNivelCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spcClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcClientes.Panel1.SuspendLayout()
        Me.spcClientes.Panel2.SuspendLayout()
        Me.spcClientes.SuspendLayout()
        Me.pnlGrids.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.cmdTipoAgenda.SuspendLayout()
        Me.cmsTipoExportacion.SuspendLayout()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1310, 59)
        Me.pnlHeader.TabIndex = 13
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitulo)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(863, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(447, 59)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(292, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(90, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Prospecta"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(377, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.Label28)
        Me.pnlBtn.Controls.Add(Me.btnComentarioRevision)
        Me.pnlBtn.Controls.Add(Me.lblAgenda)
        Me.pnlBtn.Controls.Add(Me.btnAgenda)
        Me.pnlBtn.Controls.Add(Me.lblSeguimientoClientes)
        Me.pnlBtn.Controls.Add(Me.btnSeguimientoClientes)
        Me.pnlBtn.Controls.Add(Me.btnSeguimietoPares)
        Me.pnlBtn.Controls.Add(Me.lblSeguimientoPares)
        Me.pnlBtn.Controls.Add(Me.lblEditar)
        Me.pnlBtn.Controls.Add(Me.btnEditar)
        Me.pnlBtn.Controls.Add(Me.lblExportar)
        Me.pnlBtn.Controls.Add(Me.btnExportar)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(774, 59)
        Me.pnlBtn.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label28.Location = New System.Drawing.Point(236, 34)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(63, 26)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Comentario " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Revisión"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnComentarioRevision
        '
        Me.btnComentarioRevision.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources.editar_3211
        Me.btnComentarioRevision.Location = New System.Drawing.Point(247, 4)
        Me.btnComentarioRevision.Name = "btnComentarioRevision"
        Me.btnComentarioRevision.Size = New System.Drawing.Size(32, 32)
        Me.btnComentarioRevision.TabIndex = 70
        Me.btnComentarioRevision.UseVisualStyleBackColor = True
        '
        'lblAgenda
        '
        Me.lblAgenda.AutoSize = True
        Me.lblAgenda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgenda.Location = New System.Drawing.Point(303, 36)
        Me.lblAgenda.Name = "lblAgenda"
        Me.lblAgenda.Size = New System.Drawing.Size(44, 13)
        Me.lblAgenda.TabIndex = 69
        Me.lblAgenda.Text = "Agenda"
        Me.lblAgenda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAgenda.Visible = False
        '
        'btnAgenda
        '
        Me.btnAgenda.Image = Global.Ventas.Vista.My.Resources.Resources.copiar_horario_32
        Me.btnAgenda.Location = New System.Drawing.Point(310, 6)
        Me.btnAgenda.Name = "btnAgenda"
        Me.btnAgenda.Size = New System.Drawing.Size(32, 32)
        Me.btnAgenda.TabIndex = 68
        Me.btnAgenda.UseVisualStyleBackColor = True
        Me.btnAgenda.Visible = False
        '
        'lblSeguimientoClientes
        '
        Me.lblSeguimientoClientes.AutoSize = True
        Me.lblSeguimientoClientes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSeguimientoClientes.Location = New System.Drawing.Point(169, 33)
        Me.lblSeguimientoClientes.Name = "lblSeguimientoClientes"
        Me.lblSeguimientoClientes.Size = New System.Drawing.Size(65, 26)
        Me.lblSeguimientoClientes.TabIndex = 67
        Me.lblSeguimientoClientes.Text = "Seguimiento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "clientes"
        Me.lblSeguimientoClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSeguimientoClientes
        '
        Me.btnSeguimientoClientes.Image = Global.Ventas.Vista.My.Resources.Resources.colaboradorexpediente_32
        Me.btnSeguimientoClientes.Location = New System.Drawing.Point(180, 4)
        Me.btnSeguimientoClientes.Name = "btnSeguimientoClientes"
        Me.btnSeguimientoClientes.Size = New System.Drawing.Size(32, 32)
        Me.btnSeguimientoClientes.TabIndex = 66
        Me.btnSeguimientoClientes.UseVisualStyleBackColor = True
        '
        'btnSeguimietoPares
        '
        Me.btnSeguimietoPares.Image = CType(resources.GetObject("btnSeguimietoPares.Image"), System.Drawing.Image)
        Me.btnSeguimietoPares.Location = New System.Drawing.Point(123, 4)
        Me.btnSeguimietoPares.Name = "btnSeguimietoPares"
        Me.btnSeguimietoPares.Size = New System.Drawing.Size(32, 32)
        Me.btnSeguimietoPares.TabIndex = 62
        Me.btnSeguimietoPares.UseVisualStyleBackColor = True
        '
        'lblSeguimientoPares
        '
        Me.lblSeguimientoPares.AutoSize = True
        Me.lblSeguimientoPares.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSeguimientoPares.Location = New System.Drawing.Point(109, 33)
        Me.lblSeguimientoPares.Name = "lblSeguimientoPares"
        Me.lblSeguimientoPares.Size = New System.Drawing.Size(65, 26)
        Me.lblSeguimientoPares.TabIndex = 61
        Me.lblSeguimientoPares.Text = "Seguimiento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "pares"
        Me.lblSeguimientoPares.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(16, 37)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 58
        Me.lblEditar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnEditar.Location = New System.Drawing.Point(16, 4)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 57
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(58, 37)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 56
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(63, 4)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 55
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(42, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(66, 13)
        Me.Label43.TabIndex = 83
        Me.Label43.Text = "Prospectado"
        '
        'pnlTodasCot
        '
        Me.pnlTodasCot.BackColor = System.Drawing.Color.Green
        Me.pnlTodasCot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTodasCot.ForeColor = System.Drawing.Color.Black
        Me.pnlTodasCot.Location = New System.Drawing.Point(9, 17)
        Me.pnlTodasCot.Name = "pnlTodasCot"
        Me.pnlTodasCot.Size = New System.Drawing.Size(15, 15)
        Me.pnlTodasCot.TabIndex = 100
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(30, 38)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(90, 13)
        Me.Label23.TabIndex = 99
        Me.Label23.Text = "Algunas Pagadas"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(142, 38)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 98
        Me.Label18.Text = "Sin Cotizaciones"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(142, 19)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 13)
        Me.Label25.TabIndex = 98
        Me.Label25.Text = "Ninguna Pagada"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(235, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(127, 58)
        Me.GroupBox4.TabIndex = 101
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totales"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(16, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "Datos no guardados"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(20, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "Partidas incompletas"
        Me.Label16.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(120, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 101
        '
        'pnlAlgunasCot
        '
        Me.pnlAlgunasCot.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlAlgunasCot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAlgunasCot.ForeColor = System.Drawing.Color.Black
        Me.pnlAlgunasCot.Location = New System.Drawing.Point(9, 36)
        Me.pnlAlgunasCot.Name = "pnlAlgunasCot"
        Me.pnlAlgunasCot.Size = New System.Drawing.Size(15, 15)
        Me.pnlAlgunasCot.TabIndex = 100
        '
        'pnlNingunaCot
        '
        Me.pnlNingunaCot.BackColor = System.Drawing.Color.Red
        Me.pnlNingunaCot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNingunaCot.ForeColor = System.Drawing.Color.Black
        Me.pnlNingunaCot.Location = New System.Drawing.Point(120, 17)
        Me.pnlNingunaCot.Name = "pnlNingunaCot"
        Me.pnlNingunaCot.Size = New System.Drawing.Size(15, 15)
        Me.pnlNingunaCot.TabIndex = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.pnlAlgunasCot)
        Me.GroupBox2.Controls.Add(Me.pnlNingunaCot)
        Me.GroupBox2.Controls.Add(Me.pnlTodasCot)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 58)
        Me.GroupBox2.TabIndex = 100
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cotizaciones"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(30, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "Todas Pagadas"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(16, 16)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(21, 13)
        Me.Label39.TabIndex = 79
        Me.Label39.Text = "PR"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(16, 30)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(21, 13)
        Me.Label40.TabIndex = 80
        Me.Label40.Text = "PC"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(16, 45)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(21, 13)
        Me.Label41.TabIndex = 81
        Me.Label41.Text = "BE"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(148, 16)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(23, 13)
        Me.Label42.TabIndex = 82
        Me.Label42.Text = "P-0"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(42, 30)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(97, 13)
        Me.Label44.TabIndex = 84
        Me.Label44.Text = "Partidas Completas"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(807, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 89
        Me.Label14.Text = "+100%"
        Me.Label14.Visible = False
        '
        'tmsiReproceso
        '
        Me.tmsiReproceso.Name = "tmsiReproceso"
        Me.tmsiReproceso.Size = New System.Drawing.Size(136, 22)
        Me.tmsiReproceso.Text = "Reproceso"
        '
        'tsmiBloqueados
        '
        Me.tsmiBloqueados.Name = "tsmiBloqueados"
        Me.tsmiBloqueados.Size = New System.Drawing.Size(136, 22)
        Me.tsmiBloqueados.Text = "Bloqueados"
        '
        'tsmiProduccion
        '
        Me.tsmiProduccion.Name = "tsmiProduccion"
        Me.tsmiProduccion.Size = New System.Drawing.Size(136, 22)
        Me.tsmiProduccion.Text = "Producción"
        '
        'tsmiApartados
        '
        Me.tsmiApartados.Name = "tsmiApartados"
        Me.tsmiApartados.Size = New System.Drawing.Size(136, 22)
        Me.tsmiApartados.Text = "Apartados"
        '
        'cmsTiposResumen
        '
        Me.cmsTiposResumen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiApartados, Me.tsmiProduccion, Me.tsmiBloqueados, Me.tmsiReproceso})
        Me.cmsTiposResumen.Name = "cmsOpcionesAlmacen"
        Me.cmsTiposResumen.Size = New System.Drawing.Size(137, 92)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(63, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Mostrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(107, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 54
        Me.lblGuardar.Text = "Guardar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(161, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Cerrar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(807, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "100%"
        Me.Label13.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(807, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "0 - 100%"
        Me.Label8.Visible = False
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.Label26)
        Me.pnlSalir.Controls.Add(Me.btnLimpiarFiltros)
        Me.pnlSalir.Controls.Add(Me.Label5)
        Me.pnlSalir.Controls.Add(Me.lblGuardar)
        Me.pnlSalir.Controls.Add(Me.btnMostrar)
        Me.pnlSalir.Controls.Add(Me.Label3)
        Me.pnlSalir.Controls.Add(Me.btnCerrar)
        Me.pnlSalir.Controls.Add(Me.btnGuardar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(1100, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(210, 61)
        Me.pnlSalir.TabIndex = 9
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label26.Location = New System.Drawing.Point(14, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(40, 13)
        Me.Label26.TabIndex = 58
        Me.Label26.Text = "Limpiar"
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiarFiltros.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarFiltros.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(17, 8)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarFiltros.TabIndex = 57
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(66, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 55
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(163, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 52
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(114, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 32)
        Me.btnGuardar.TabIndex = 51
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(178, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "Reproceso"
        '
        'dtmFechaInicio
        '
        Me.dtmFechaInicio.Enabled = False
        Me.dtmFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicio.Location = New System.Drawing.Point(54, 74)
        Me.dtmFechaInicio.Name = "dtmFechaInicio"
        Me.dtmFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtmFechaInicio.TabIndex = 39
        Me.dtmFechaInicio.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(148, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Al"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Del"
        '
        'lblAgenteVentas
        '
        Me.lblAgenteVentas.AutoSize = True
        Me.lblAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgenteVentas.Location = New System.Drawing.Point(367, 16)
        Me.lblAgenteVentas.Name = "lblAgenteVentas"
        Me.lblAgenteVentas.Size = New System.Drawing.Size(92, 13)
        Me.lblAgenteVentas.TabIndex = 95
        Me.lblAgenteVentas.Text = "Agente de Ventas"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(188, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 13)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "Atn a Clientes"
        '
        'grdAtnClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAtnClientes.DisplayLayout.Appearance = Appearance1
        Me.grdAtnClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAtnClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAtnClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAtnClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAtnClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAtnClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAtnClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAtnClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAtnClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdAtnClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAtnClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAtnClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAtnClientes.Location = New System.Drawing.Point(186, 34)
        Me.grdAtnClientes.Name = "grdAtnClientes"
        Me.grdAtnClientes.Size = New System.Drawing.Size(175, 125)
        Me.grdAtnClientes.TabIndex = 92
        '
        'txtStatusProspecta
        '
        Me.txtStatusProspecta.Enabled = False
        Me.txtStatusProspecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusProspecta.ForeColor = System.Drawing.Color.Black
        Me.txtStatusProspecta.Location = New System.Drawing.Point(53, 103)
        Me.txtStatusProspecta.Name = "txtStatusProspecta"
        Me.txtStatusProspecta.Size = New System.Drawing.Size(96, 20)
        Me.txtStatusProspecta.TabIndex = 76
        Me.txtStatusProspecta.Text = "PRÓXIMA"
        '
        'dtmFechaFin
        '
        Me.dtmFechaFin.Enabled = False
        Me.dtmFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaFin.Location = New System.Drawing.Point(168, 74)
        Me.dtmFechaFin.Name = "dtmFechaFin"
        Me.dtmFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtmFechaFin.TabIndex = 40
        Me.dtmFechaFin.Value = New Date(2016, 11, 19, 0, 0, 0, 0)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 13)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Clientes"
        '
        'grdFiltroClientes
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroClientes.DisplayLayout.Appearance = Appearance3
        Me.grdFiltroClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdFiltroClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFiltroClientes.Location = New System.Drawing.Point(6, 33)
        Me.grdFiltroClientes.Name = "grdFiltroClientes"
        Me.grdFiltroClientes.Size = New System.Drawing.Size(175, 125)
        Me.grdFiltroClientes.TabIndex = 86
        '
        'txtSemana
        '
        Me.txtSemana.Enabled = False
        Me.txtSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSemana.Location = New System.Drawing.Point(179, 40)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(94, 20)
        Me.txtSemana.TabIndex = 69
        Me.txtSemana.Text = "47-2016"
        Me.txtSemana.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(847, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Resumen diario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnFiltroAgenteVentas)
        Me.GroupBox3.Controls.Add(Me.lblAgenteVentas)
        Me.GroupBox3.Controls.Add(Me.grdFiltroAgenteVentas)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.grdAtnClientes)
        Me.GroupBox3.Controls.Add(Me.btnAtnClientes)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.grdFiltroClientes)
        Me.GroupBox3.Controls.Add(Me.btnFiltroCliente)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(291, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(550, 165)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtros"
        '
        'btnFiltroAgenteVentas
        '
        Me.btnFiltroAgenteVentas.Image = CType(resources.GetObject("btnFiltroAgenteVentas.Image"), System.Drawing.Image)
        Me.btnFiltroAgenteVentas.Location = New System.Drawing.Point(520, 11)
        Me.btnFiltroAgenteVentas.Name = "btnFiltroAgenteVentas"
        Me.btnFiltroAgenteVentas.Size = New System.Drawing.Size(22, 22)
        Me.btnFiltroAgenteVentas.TabIndex = 96
        Me.btnFiltroAgenteVentas.UseVisualStyleBackColor = True
        '
        'grdFiltroAgenteVentas
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroAgenteVentas.DisplayLayout.Appearance = Appearance5
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroAgenteVentas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFiltroAgenteVentas.Location = New System.Drawing.Point(367, 34)
        Me.grdFiltroAgenteVentas.Name = "grdFiltroAgenteVentas"
        Me.grdFiltroAgenteVentas.Size = New System.Drawing.Size(175, 125)
        Me.grdFiltroAgenteVentas.TabIndex = 94
        '
        'btnAtnClientes
        '
        Me.btnAtnClientes.Image = CType(resources.GetObject("btnAtnClientes.Image"), System.Drawing.Image)
        Me.btnAtnClientes.Location = New System.Drawing.Point(339, 11)
        Me.btnAtnClientes.Name = "btnAtnClientes"
        Me.btnAtnClientes.Size = New System.Drawing.Size(22, 22)
        Me.btnAtnClientes.TabIndex = 91
        Me.btnAtnClientes.UseVisualStyleBackColor = True
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Image = CType(resources.GetObject("btnFiltroCliente.Image"), System.Drawing.Image)
        Me.btnFiltroCliente.Location = New System.Drawing.Point(159, 11)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnFiltroCliente.TabIndex = 85
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnActualizarStatus)
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Controls.Add(Me.nudNumSemana)
        Me.GroupBox1.Controls.Add(Me.txtStatusProspecta)
        Me.GroupBox1.Controls.Add(Me.dtmFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtmFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSemana)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 165)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de la Prospecta"
        '
        'btnActualizarStatus
        '
        Me.btnActualizarStatus.Location = New System.Drawing.Point(162, 100)
        Me.btnActualizarStatus.Name = "btnActualizarStatus"
        Me.btnActualizarStatus.Size = New System.Drawing.Size(105, 23)
        Me.btnActualizarStatus.TabIndex = 78
        Me.btnActualizarStatus.UseVisualStyleBackColor = True
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(119, 41)
        Me.nudAño.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2017, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(54, 20)
        Me.nudAño.TabIndex = 77
        Me.nudAño.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'nudNumSemana
        '
        Me.nudNumSemana.Location = New System.Drawing.Point(58, 41)
        Me.nudNumSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSemana.Name = "nudNumSemana"
        Me.nudNumSemana.Size = New System.Drawing.Size(45, 20)
        Me.nudNumSemana.TabIndex = 77
        Me.nudNumSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Semana"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 106)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Status"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.grdResumenDiario)
        Me.pnlFiltros.Controls.Add(Me.Label1)
        Me.pnlFiltros.Controls.Add(Me.GroupBox3)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Controls.Add(Me.btnArriba)
        Me.pnlFiltros.Controls.Add(Me.btnAbajo)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1310, 193)
        Me.pnlFiltros.TabIndex = 9
        '
        'grdResumenDiario
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenDiario.DisplayLayout.Appearance = Appearance7
        Me.grdResumenDiario.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdResumenDiario.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdResumenDiario.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdResumenDiario.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdResumenDiario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdResumenDiario.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdResumenDiario.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdResumenDiario.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdResumenDiario.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdResumenDiario.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdResumenDiario.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenDiario.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdResumenDiario.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdResumenDiario.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.grdResumenDiario.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdResumenDiario.Location = New System.Drawing.Point(849, 44)
        Me.grdResumenDiario.Name = "grdResumenDiario"
        Me.grdResumenDiario.Size = New System.Drawing.Size(403, 143)
        Me.grdResumenDiario.TabIndex = 109
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1255, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 93
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1281, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 92
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdNivelPartidaOculto)
        Me.Panel2.Location = New System.Drawing.Point(916, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 54)
        Me.Panel2.TabIndex = 103
        '
        'grdNivelPartidaOculto
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPartidaOculto.DisplayLayout.Appearance = Appearance9
        Me.grdNivelPartidaOculto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNivelPartidaOculto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNivelPartidaOculto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdNivelPartidaOculto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdNivelPartidaOculto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNivelPartidaOculto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNivelPartidaOculto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNivelPartidaOculto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPartidaOculto.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdNivelPartidaOculto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNivelPartidaOculto.Location = New System.Drawing.Point(0, 0)
        Me.grdNivelPartidaOculto.Name = "grdNivelPartidaOculto"
        Me.grdNivelPartidaOculto.Size = New System.Drawing.Size(178, 54)
        Me.grdNivelPartidaOculto.TabIndex = 22
        Me.grdNivelPartidaOculto.Visible = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(42, 45)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(98, 13)
        Me.Label45.TabIndex = 85
        Me.Label45.Text = "Bloqueado Entrega"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(178, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Bloqueados"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(176, 16)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(58, 13)
        Me.Label46.TabIndex = 86
        Me.Label46.Text = "Plazo Cero"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(148, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "RP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(148, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "BC"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.Label44)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label45)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label46)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(364, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(358, 58)
        Me.GroupBox5.TabIndex = 102
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Abreviaturas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "OC"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(278, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "Orden Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.GroupBox5)
        Me.pnlPie.Controls.Add(Me.GroupBox4)
        Me.pnlPie.Controls.Add(Me.GroupBox2)
        Me.pnlPie.Controls.Add(Me.Label14)
        Me.pnlPie.Controls.Add(Me.Label13)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.pnlSalir)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 296)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1310, 61)
        Me.pnlPie.TabIndex = 13
        '
        'grdNivelPartida
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPartida.DisplayLayout.Appearance = Appearance11
        Me.grdNivelPartida.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNivelPartida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNivelPartida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdNivelPartida.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdNivelPartida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNivelPartida.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNivelPartida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNivelPartida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPartida.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Me.grdNivelPartida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNivelPartida.Location = New System.Drawing.Point(0, 0)
        Me.grdNivelPartida.Name = "grdNivelPartida"
        Me.grdNivelPartida.Size = New System.Drawing.Size(200, 0)
        Me.grdNivelPartida.TabIndex = 12
        '
        'lblParesConfirmadosAnteriormente
        '
        Me.lblParesConfirmadosAnteriormente.AutoSize = True
        Me.lblParesConfirmadosAnteriormente.Location = New System.Drawing.Point(3, 4)
        Me.lblParesConfirmadosAnteriormente.Name = "lblParesConfirmadosAnteriormente"
        Me.lblParesConfirmadosAnteriormente.Size = New System.Drawing.Size(45, 13)
        Me.lblParesConfirmadosAnteriormente.TabIndex = 1
        Me.lblParesConfirmadosAnteriormente.Text = "Partidas"
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
        Me.sPCParesConfirmadosAnteriormente.Panel1MinSize = 0
        '
        'sPCParesConfirmadosAnteriormente.Panel2
        '
        Me.sPCParesConfirmadosAnteriormente.Panel2.Controls.Add(Me.grdNivelPartida)
        Me.sPCParesConfirmadosAnteriormente.Panel2MinSize = 0
        Me.sPCParesConfirmadosAnteriormente.Size = New System.Drawing.Size(200, 25)
        Me.sPCParesConfirmadosAnteriormente.SplitterDistance = 25
        Me.sPCParesConfirmadosAnteriormente.SplitterWidth = 1
        Me.sPCParesConfirmadosAnteriormente.TabIndex = 0
        '
        'grdNivelPedido
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPedido.DisplayLayout.Appearance = Appearance13
        Me.grdNivelPedido.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNivelPedido.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNivelPedido.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdNivelPedido.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdNivelPedido.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNivelPedido.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNivelPedido.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNivelPedido.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelPedido.DisplayLayout.Override.RowAlternateAppearance = Appearance14
        Me.grdNivelPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNivelPedido.Location = New System.Drawing.Point(0, 0)
        Me.grdNivelPedido.Name = "grdNivelPedido"
        Me.grdNivelPedido.Size = New System.Drawing.Size(200, 236)
        Me.grdNivelPedido.TabIndex = 15
        '
        'lblTextoPedidos
        '
        Me.lblTextoPedidos.AutoSize = True
        Me.lblTextoPedidos.Location = New System.Drawing.Point(3, 4)
        Me.lblTextoPedidos.Name = "lblTextoPedidos"
        Me.lblTextoPedidos.Size = New System.Drawing.Size(45, 13)
        Me.lblTextoPedidos.TabIndex = 13
        Me.lblTextoPedidos.Text = "Pedidos"
        '
        'spcPedidos
        '
        Me.spcPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcPedidos.Location = New System.Drawing.Point(0, 0)
        Me.spcPedidos.Name = "spcPedidos"
        Me.spcPedidos.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcPedidos.Panel1
        '
        Me.spcPedidos.Panel1.Controls.Add(Me.lblTextoPedidos)
        Me.spcPedidos.Panel1MinSize = 20
        '
        'spcPedidos.Panel2
        '
        Me.spcPedidos.Panel2.Controls.Add(Me.grdNivelPedido)
        Me.spcPedidos.Panel2MinSize = 20
        Me.spcPedidos.Size = New System.Drawing.Size(200, 265)
        Me.spcPedidos.SplitterDistance = 25
        Me.spcPedidos.TabIndex = 0
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
        Me.sPCParesConfirmar.Panel1.Controls.Add(Me.spcPedidos)
        Me.sPCParesConfirmar.Panel1MinSize = 0
        '
        'sPCParesConfirmar.Panel2
        '
        Me.sPCParesConfirmar.Panel2.Controls.Add(Me.sPCParesConfirmadosAnteriormente)
        Me.sPCParesConfirmar.Panel2MinSize = 0
        Me.sPCParesConfirmar.Size = New System.Drawing.Size(202, 296)
        Me.sPCParesConfirmar.SplitterDistance = 267
        Me.sPCParesConfirmar.SplitterWidth = 2
        Me.sPCParesConfirmar.TabIndex = 0
        '
        'grdNivelCliente
        '
        Appearance15.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNivelCliente.DisplayLayout.Appearance = Appearance15
        Me.grdNivelCliente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNivelCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdNivelCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdNivelCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNivelCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNivelCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNivelCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdNivelCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNivelCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdNivelCliente.Name = "grdNivelCliente"
        Me.grdNivelCliente.Size = New System.Drawing.Size(1104, 294)
        Me.grdNivelCliente.TabIndex = 12
        '
        'spcClientes
        '
        Me.spcClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spcClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcClientes.Location = New System.Drawing.Point(0, 0)
        Me.spcClientes.Name = "spcClientes"
        '
        'spcClientes.Panel1
        '
        Me.spcClientes.Panel1.Controls.Add(Me.grdNivelCliente)
        Me.spcClientes.Panel1MinSize = 0
        '
        'spcClientes.Panel2
        '
        Me.spcClientes.Panel2.Controls.Add(Me.sPCParesConfirmar)
        Me.spcClientes.Panel2MinSize = 0
        Me.spcClientes.Size = New System.Drawing.Size(1310, 296)
        Me.spcClientes.SplitterDistance = 1106
        Me.spcClientes.SplitterWidth = 2
        Me.spcClientes.TabIndex = 14
        '
        'pnlGrids
        '
        Me.pnlGrids.Controls.Add(Me.Panel1)
        Me.pnlGrids.Controls.Add(Me.pnlFiltros)
        Me.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrids.Location = New System.Drawing.Point(0, 59)
        Me.pnlGrids.Name = "pnlGrids"
        Me.pnlGrids.Size = New System.Drawing.Size(1310, 550)
        Me.pnlGrids.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.spcClientes)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 193)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1310, 357)
        Me.Panel1.TabIndex = 10
        '
        'cmdTipoAgenda
        '
        Me.cmdTipoAgenda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgendaProyecciónToolStripMenuItem, Me.AgendaDeEntregasToolStripMenuItem})
        Me.cmdTipoAgenda.Name = "cmdTipoAgenda"
        Me.cmdTipoAgenda.Size = New System.Drawing.Size(180, 48)
        '
        'AgendaProyecciónToolStripMenuItem
        '
        Me.AgendaProyecciónToolStripMenuItem.Name = "AgendaProyecciónToolStripMenuItem"
        Me.AgendaProyecciónToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AgendaProyecciónToolStripMenuItem.Text = "Agenda Proyección"
        '
        'AgendaDeEntregasToolStripMenuItem
        '
        Me.AgendaDeEntregasToolStripMenuItem.Name = "AgendaDeEntregasToolStripMenuItem"
        Me.AgendaDeEntregasToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AgendaDeEntregasToolStripMenuItem.Text = "Agenda de Entregas"
        '
        'cmsTipoExportacion
        '
        Me.cmsTipoExportacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmClientes, Me.tsmClientesPartidas})
        Me.cmsTipoExportacion.Name = "cmsTipoExportacion"
        Me.cmsTipoExportacion.Size = New System.Drawing.Size(164, 48)
        '
        'tsmClientes
        '
        Me.tsmClientes.Name = "tsmClientes"
        Me.tsmClientes.Size = New System.Drawing.Size(163, 22)
        Me.tsmClientes.Text = "Clientes"
        '
        'tsmClientesPartidas
        '
        Me.tsmClientesPartidas.Name = "tsmClientesPartidas"
        Me.tsmClientesPartidas.Size = New System.Drawing.Size(163, 22)
        Me.tsmClientesPartidas.Text = "Clientes-Pedidos"
        '
        'ProspectaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1310, 609)
        Me.Controls.Add(Me.pnlGrids)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ProspectaForm"
        Me.Text = "Prospecta"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtn.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.cmsTiposResumen.ResumeLayout(False)
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        CType(Me.grdAtnClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFiltroClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdFiltroAgenteVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.grdResumenDiario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdNivelPartidaOculto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        CType(Me.grdNivelPartida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmadosAnteriormente.Panel1.PerformLayout()
        Me.sPCParesConfirmadosAnteriormente.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmadosAnteriormente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmadosAnteriormente.ResumeLayout(False)
        CType(Me.grdNivelPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcPedidos.Panel1.ResumeLayout(False)
        Me.spcPedidos.Panel1.PerformLayout()
        Me.spcPedidos.Panel2.ResumeLayout(False)
        CType(Me.spcPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcPedidos.ResumeLayout(False)
        Me.sPCParesConfirmar.Panel1.ResumeLayout(False)
        Me.sPCParesConfirmar.Panel2.ResumeLayout(False)
        CType(Me.sPCParesConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sPCParesConfirmar.ResumeLayout(False)
        CType(Me.grdNivelCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcClientes.Panel1.ResumeLayout(False)
        Me.spcClientes.Panel2.ResumeLayout(False)
        CType(Me.spcClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcClientes.ResumeLayout(False)
        Me.pnlGrids.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.cmdTipoAgenda.ResumeLayout(False)
        Me.cmsTipoExportacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents btnSeguimietoPares As System.Windows.Forms.Button
    Friend WithEvents lblSeguimientoPares As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents pnlTodasCot As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pnlAlgunasCot As System.Windows.Forms.Panel
    Friend WithEvents pnlNingunaCot As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnFiltroAgenteVentas As System.Windows.Forms.Button
    Friend WithEvents btnAtnClientes As System.Windows.Forms.Button
    Friend WithEvents btnFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents tmsiReproceso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBloqueados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiProduccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiApartados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTiposResumen As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents dtmFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblAgenteVentas As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grdAtnClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtStatusProspecta As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents grdFiltroClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtSemana As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents grdNivelPartida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblParesConfirmadosAnteriormente As System.Windows.Forms.Label
    Friend WithEvents sPCParesConfirmadosAnteriormente As System.Windows.Forms.SplitContainer
    Friend WithEvents grdNivelPedido As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblTextoPedidos As System.Windows.Forms.Label
    Friend WithEvents spcPedidos As System.Windows.Forms.SplitContainer
    Friend WithEvents sPCParesConfirmar As System.Windows.Forms.SplitContainer
    Friend WithEvents grdNivelCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents spcClientes As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlGrids As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents nudNumSemana As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeguimientoClientes As System.Windows.Forms.Label
    Friend WithEvents btnSeguimientoClientes As System.Windows.Forms.Button
    Friend WithEvents cmdTipoAgenda As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgendaProyecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgendaDeEntregasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtmFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnActualizarStatus As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnComentarioRevision As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridExcelExporter2 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents grdFiltroAgenteVentas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblAgenda As System.Windows.Forms.Label
    Friend WithEvents btnAgenda As System.Windows.Forms.Button
    Friend WithEvents grdResumenDiario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdNivelPartidaOculto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmsTipoExportacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmClientesPartidas As System.Windows.Forms.ToolStripMenuItem


End Class
