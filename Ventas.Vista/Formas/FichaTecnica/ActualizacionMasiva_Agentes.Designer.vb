<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizacionMasiva_Agentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActualizacionMasiva_Agentes))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grpBoxFiltros = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grdAgenteAsignado = New DevExpress.XtraGrid.GridControl()
        Me.grdAgenAsign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdFamiliasVenta = New DevExpress.XtraGrid.GridControl()
        Me.grdFamVe = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grdMarcas = New DevExpress.XtraGrid.GridControl()
        Me.grdMarc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gboxAgenteVentas = New System.Windows.Forms.GroupBox()
        Me.grdRutas = New DevExpress.XtraGrid.GridControl()
        Me.grdRut = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCoord = New System.Windows.Forms.Label()
        Me.cbxCoordinador = New System.Windows.Forms.ComboBox()
        Me.rdoAgenteComision = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cboxAgenteComision = New System.Windows.Forms.ComboBox()
        Me.rdoAgenteVentas = New System.Windows.Forms.RadioButton()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.cboxAgenteVentas = New System.Windows.Forms.ComboBox()
        Me.pnlClienteBotones = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblGuardarCliente = New System.Windows.Forms.Label()
        Me.lblCancelarCliente = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNumeroRegistros = New System.Windows.Forms.Label()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.grdLista = New DevExpress.XtraGrid.GridControl()
        Me.grdPr = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grpBoxFiltros.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdAgenteAsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAgenAsign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdFamiliasVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFamVe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMarc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxAgenteVentas.SuspendLayout()
        CType(Me.grdRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlClienteBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.grdLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlFiltros)
        Me.pnlContenedor.Controls.Add(Me.Panel2)
        Me.pnlContenedor.Controls.Add(Me.pnlClienteBotones)
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1248, 514)
        Me.pnlContenedor.TabIndex = 2
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.Controls.Add(Me.grpBoxFiltros)
        Me.pnlFiltros.Location = New System.Drawing.Point(3, 93)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1242, 165)
        Me.pnlFiltros.TabIndex = 119
        '
        'grpBoxFiltros
        '
        Me.grpBoxFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBoxFiltros.Controls.Add(Me.GroupBox4)
        Me.grpBoxFiltros.Controls.Add(Me.GroupBox3)
        Me.grpBoxFiltros.Controls.Add(Me.GroupBox2)
        Me.grpBoxFiltros.Controls.Add(Me.gboxAgenteVentas)
        Me.grpBoxFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBoxFiltros.Location = New System.Drawing.Point(2, 4)
        Me.grpBoxFiltros.Name = "grpBoxFiltros"
        Me.grpBoxFiltros.Size = New System.Drawing.Size(1228, 157)
        Me.grpBoxFiltros.TabIndex = 116
        Me.grpBoxFiltros.TabStop = False
        Me.grpBoxFiltros.Text = "Clientes a Actualizar"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.grdAgenteAsignado)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(905, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 143)
        Me.GroupBox4.TabIndex = 64
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Agente Asignado Actual"
        '
        'grdAgenteAsignado
        '
        Me.grdAgenteAsignado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAgenteAsignado.Location = New System.Drawing.Point(6, 20)
        Me.grdAgenteAsignado.MainView = Me.grdAgenAsign
        Me.grdAgenteAsignado.Name = "grdAgenteAsignado"
        Me.grdAgenteAsignado.Size = New System.Drawing.Size(304, 117)
        Me.grdAgenteAsignado.TabIndex = 0
        Me.grdAgenteAsignado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdAgenAsign})
        '
        'grdAgenAsign
        '
        Me.grdAgenAsign.GridControl = Me.grdAgenteAsignado
        Me.grdAgenAsign.Name = "grdAgenAsign"
        Me.grdAgenAsign.OptionsView.ShowAutoFilterRow = True
        Me.grdAgenAsign.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdAgenAsign.OptionsView.ShowGroupPanel = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdFamiliasVenta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(631, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(268, 143)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Familia de Ventas"
        '
        'grdFamiliasVenta
        '
        Me.grdFamiliasVenta.Location = New System.Drawing.Point(7, 19)
        Me.grdFamiliasVenta.MainView = Me.grdFamVe
        Me.grdFamiliasVenta.Name = "grdFamiliasVenta"
        Me.grdFamiliasVenta.Size = New System.Drawing.Size(255, 118)
        Me.grdFamiliasVenta.TabIndex = 0
        Me.grdFamiliasVenta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdFamVe})
        '
        'grdFamVe
        '
        Me.grdFamVe.GridControl = Me.grdFamiliasVenta
        Me.grdFamVe.Name = "grdFamVe"
        Me.grdFamVe.OptionsCustomization.AllowFilter = False
        Me.grdFamVe.OptionsView.ShowAutoFilterRow = True
        Me.grdFamVe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdFamVe.OptionsView.ShowGroupPanel = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdMarcas)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(336, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(289, 143)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Marcas"
        '
        'grdMarcas
        '
        Me.grdMarcas.Location = New System.Drawing.Point(6, 19)
        Me.grdMarcas.MainView = Me.grdMarc
        Me.grdMarcas.Name = "grdMarcas"
        Me.grdMarcas.Size = New System.Drawing.Size(277, 118)
        Me.grdMarcas.TabIndex = 0
        Me.grdMarcas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdMarc})
        '
        'grdMarc
        '
        Me.grdMarc.GridControl = Me.grdMarcas
        Me.grdMarc.Name = "grdMarc"
        Me.grdMarc.OptionsView.ShowAutoFilterRow = True
        Me.grdMarc.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdMarc.OptionsView.ShowGroupPanel = False
        '
        'gboxAgenteVentas
        '
        Me.gboxAgenteVentas.Controls.Add(Me.grdRutas)
        Me.gboxAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxAgenteVentas.Location = New System.Drawing.Point(7, 14)
        Me.gboxAgenteVentas.Name = "gboxAgenteVentas"
        Me.gboxAgenteVentas.Size = New System.Drawing.Size(323, 143)
        Me.gboxAgenteVentas.TabIndex = 61
        Me.gboxAgenteVentas.TabStop = False
        Me.gboxAgenteVentas.Text = "Rutas"
        '
        'grdRutas
        '
        Me.grdRutas.Location = New System.Drawing.Point(6, 19)
        Me.grdRutas.MainView = Me.grdRut
        Me.grdRutas.Name = "grdRutas"
        Me.grdRutas.Size = New System.Drawing.Size(311, 118)
        Me.grdRutas.TabIndex = 0
        Me.grdRutas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdRut})
        '
        'grdRut
        '
        Me.grdRut.GridControl = Me.grdRutas
        Me.grdRut.Name = "grdRut"
        Me.grdRut.OptionsView.ShowAutoFilterRow = True
        Me.grdRut.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdRut.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCoord)
        Me.Panel2.Controls.Add(Me.cbxCoordinador)
        Me.Panel2.Controls.Add(Me.rdoAgenteComision)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.cboxAgenteComision)
        Me.Panel2.Controls.Add(Me.rdoAgenteVentas)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.cboxAgenteVentas)
        Me.Panel2.Location = New System.Drawing.Point(3, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1242, 28)
        Me.Panel2.TabIndex = 120
        '
        'lblCoord
        '
        Me.lblCoord.AutoSize = True
        Me.lblCoord.Location = New System.Drawing.Point(900, 9)
        Me.lblCoord.Name = "lblCoord"
        Me.lblCoord.Size = New System.Drawing.Size(64, 13)
        Me.lblCoord.TabIndex = 125
        Me.lblCoord.Text = "Coordinador"
        '
        'cbxCoordinador
        '
        Me.cbxCoordinador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbxCoordinador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCoordinador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCoordinador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbxCoordinador.FormattingEnabled = True
        Me.cbxCoordinador.Location = New System.Drawing.Point(968, 5)
        Me.cbxCoordinador.Name = "cbxCoordinador"
        Me.cbxCoordinador.Size = New System.Drawing.Size(210, 21)
        Me.cbxCoordinador.TabIndex = 124
        '
        'rdoAgenteComision
        '
        Me.rdoAgenteComision.AutoSize = True
        Me.rdoAgenteComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAgenteComision.Location = New System.Drawing.Point(460, 5)
        Me.rdoAgenteComision.Name = "rdoAgenteComision"
        Me.rdoAgenteComision.Size = New System.Drawing.Size(119, 17)
        Me.rdoAgenteComision.TabIndex = 121
        Me.rdoAgenteComision.Text = "Agente de Comisión"
        Me.rdoAgenteComision.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1210, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 123
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cboxAgenteComision
        '
        Me.cboxAgenteComision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxAgenteComision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxAgenteComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAgenteComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxAgenteComision.FormattingEnabled = True
        Me.cboxAgenteComision.Location = New System.Drawing.Point(580, 5)
        Me.cboxAgenteComision.Name = "cboxAgenteComision"
        Me.cboxAgenteComision.Size = New System.Drawing.Size(314, 21)
        Me.cboxAgenteComision.TabIndex = 120
        '
        'rdoAgenteVentas
        '
        Me.rdoAgenteVentas.AutoSize = True
        Me.rdoAgenteVentas.Checked = True
        Me.rdoAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAgenteVentas.Location = New System.Drawing.Point(8, 5)
        Me.rdoAgenteVentas.Name = "rdoAgenteVentas"
        Me.rdoAgenteVentas.Size = New System.Drawing.Size(110, 17)
        Me.rdoAgenteVentas.TabIndex = 119
        Me.rdoAgenteVentas.TabStop = True
        Me.rdoAgenteVentas.Text = "Agente de Ventas"
        Me.rdoAgenteVentas.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1184, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 122
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'cboxAgenteVentas
        '
        Me.cboxAgenteVentas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxAgenteVentas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxAgenteVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAgenteVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxAgenteVentas.FormattingEnabled = True
        Me.cboxAgenteVentas.Location = New System.Drawing.Point(124, 4)
        Me.cboxAgenteVentas.Name = "cboxAgenteVentas"
        Me.cboxAgenteVentas.Size = New System.Drawing.Size(314, 21)
        Me.cboxAgenteVentas.TabIndex = 118
        '
        'pnlClienteBotones
        '
        Me.pnlClienteBotones.Controls.Add(Me.Label3)
        Me.pnlClienteBotones.Controls.Add(Me.Panel1)
        Me.pnlClienteBotones.Controls.Add(Me.Label5)
        Me.pnlClienteBotones.Controls.Add(Me.Label1)
        Me.pnlClienteBotones.Controls.Add(Me.lblNumeroRegistros)
        Me.pnlClienteBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlClienteBotones.Location = New System.Drawing.Point(0, 448)
        Me.pnlClienteBotones.Name = "pnlClienteBotones"
        Me.pnlClienteBotones.Size = New System.Drawing.Size(1248, 66)
        Me.pnlClienteBotones.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(607, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(405, 34)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Se muestran los clientes activos que cumplen con todos los criterios de la consul" &
    "ta, en caso de no seleccionar filtros se mostrarán todos los clientes activos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.lblLimpiar)
        Me.Panel1.Controls.Add(Me.lblAceptar)
        Me.Panel1.Controls.Add(Me.lblGuardarCliente)
        Me.Panel1.Controls.Add(Me.lblCancelarCliente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1018, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 66)
        Me.Panel1.TabIndex = 115
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(185, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 48
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(135, 10)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 47
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(89, 10)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 46
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(41, 10)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 45
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(86, 45)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 29
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(38, 45)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 28
        Me.lblAceptar.Text = "Mostrar"
        '
        'lblGuardarCliente
        '
        Me.lblGuardarCliente.AutoSize = True
        Me.lblGuardarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardarCliente.Location = New System.Drawing.Point(132, 45)
        Me.lblGuardarCliente.Name = "lblGuardarCliente"
        Me.lblGuardarCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarCliente.TabIndex = 0
        Me.lblGuardarCliente.Text = "Guardar"
        '
        'lblCancelarCliente
        '
        Me.lblCancelarCliente.AutoSize = True
        Me.lblCancelarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCancelarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelarCliente.Location = New System.Drawing.Point(182, 45)
        Me.lblCancelarCliente.Name = "lblCancelarCliente"
        Me.lblCancelarCliente.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelarCliente.TabIndex = 0
        Me.lblCancelarCliente.Text = "Cerrar"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(30, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumeroRegistros
        '
        Me.lblNumeroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumeroRegistros.Location = New System.Drawing.Point(27, 42)
        Me.lblNumeroRegistros.Name = "lblNumeroRegistros"
        Me.lblNumeroRegistros.Size = New System.Drawing.Size(86, 20)
        Me.lblNumeroRegistros.TabIndex = 113
        Me.lblNumeroRegistros.Text = "0"
        Me.lblNumeroRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlListaCliente.Controls.Add(Me.grdLista)
        Me.pnlListaCliente.Controls.Add(Me.Label2)
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 96)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1245, 346)
        Me.pnlListaCliente.TabIndex = 3
        '
        'grdLista
        '
        Me.grdLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridLevelNode1.RelationName = "Level1"
        Me.grdLista.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdLista.Location = New System.Drawing.Point(10, 164)
        Me.grdLista.LookAndFeel.SkinName = "Office 2016 Colorful"
        Me.grdLista.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.grdLista.MainView = Me.grdPr
        Me.grdLista.Name = "grdLista"
        Me.grdLista.Size = New System.Drawing.Size(1232, 179)
        Me.grdLista.TabIndex = 118
        Me.grdLista.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdPr})
        '
        'grdPr
        '
        Me.grdPr.GridControl = Me.grdLista
        Me.grdPr.Name = "grdPr"
        Me.grdPr.OptionsView.ShowAutoFilterRow = True
        Me.grdPr.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-81, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Actualizar"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1248, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1248, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(8, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 40
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(15, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 39
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblListaPuestos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(798, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(450, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(22, 19)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(354, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Actualización Masiva de Clientes - Agentes"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(967, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(206, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Ficha Técnica de Cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(382, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ActualizacionMasiva_Agentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 514)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "ActualizacionMasiva_Agentes"
        Me.Text = "Actualización Masiva de Clientes - Agentes"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.grpBoxFiltros.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grdAgenteAsignado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAgenAsign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdFamiliasVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFamVe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMarc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxAgenteVentas.ResumeLayout(False)
        CType(Me.grdRutas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlClienteBotones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaCliente.ResumeLayout(False)
        Me.pnlListaCliente.PerformLayout()
        CType(Me.grdLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPr, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlClienteBotones As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardarCliente As System.Windows.Forms.Label
    Friend WithEvents lblCancelarCliente As System.Windows.Forms.Label
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroRegistros As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents grdLista As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdPr As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents grpBoxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grdAgenteAsignado As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdAgenAsign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdFamiliasVenta As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdFamVe As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdMarcas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdMarc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gboxAgenteVentas As System.Windows.Forms.GroupBox
    Friend WithEvents grdRutas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdRut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoAgenteComision As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cboxAgenteComision As System.Windows.Forms.ComboBox
    Friend WithEvents rdoAgenteVentas As System.Windows.Forms.RadioButton
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents cboxAgenteVentas As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoord As Label
    Friend WithEvents cbxCoordinador As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
