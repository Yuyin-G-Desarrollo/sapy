<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExistenciasRequeridasenSAPForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExistenciasRequeridasenSAPForm))
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.gboxFolioFactura = New System.Windows.Forms.GroupBox()
        Me.txtFiltroFactura = New System.Windows.Forms.TextBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.grdFactura = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoagregarfacturas = New System.Windows.Forms.RadioButton()
        Me.dtpfechaFin = New System.Windows.Forms.DateTimePicker()
        Me.rdoFecha = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblImportarInventarioSAP = New System.Windows.Forms.Label()
        Me.btnImportarInventario = New System.Windows.Forms.Button()
        Me.lblMostrarTexto = New System.Windows.Forms.Label()
        Me.lblTotalArticulosFaltantesSAP = New System.Windows.Forms.Label()
        Me.lblArticulosFaltantesSAP = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblFacturar = New System.Windows.Forms.Label()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.lblverdetalles = New System.Windows.Forms.Label()
        Me.btndetalles = New System.Windows.Forms.Button()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblcantidadClientesSAP = New System.Windows.Forms.Label()
        Me.lblClientesFaltantesSAP = New System.Windows.Forms.Label()
        Me.lblTotalArticulos = New System.Windows.Forms.Label()
        Me.lblArticulos = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdArticulosCompra = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlParametros.SuspendLayout()
        Me.gboxFolioFactura.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdArticulosCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(72, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaInicio.TabIndex = 149
        Me.dtpFechaInicio.Visible = False
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.gboxFolioFactura)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.Panel5)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1041, 165)
        Me.pnlParametros.TabIndex = 52
        '
        'gboxFolioFactura
        '
        Me.gboxFolioFactura.Controls.Add(Me.txtFiltroFactura)
        Me.gboxFolioFactura.Controls.Add(Me.Panel25)
        Me.gboxFolioFactura.Location = New System.Drawing.Point(562, 8)
        Me.gboxFolioFactura.Name = "gboxFolioFactura"
        Me.gboxFolioFactura.Size = New System.Drawing.Size(97, 151)
        Me.gboxFolioFactura.TabIndex = 153
        Me.gboxFolioFactura.TabStop = False
        Me.gboxFolioFactura.Text = "Factura"
        '
        'txtFiltroFactura
        '
        Me.txtFiltroFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltroFactura.Location = New System.Drawing.Point(6, 14)
        Me.txtFiltroFactura.MaxLength = 50
        Me.txtFiltroFactura.Name = "txtFiltroFactura"
        Me.txtFiltroFactura.Size = New System.Drawing.Size(88, 20)
        Me.txtFiltroFactura.TabIndex = 3
        Me.txtFiltroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.grdFactura)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(3, 50)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(91, 98)
        Me.Panel25.TabIndex = 2
        '
        'grdFactura
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFactura.DisplayLayout.Appearance = Appearance1
        Me.grdFactura.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFactura.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFactura.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFactura.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFactura.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFactura.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFactura.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFactura.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFactura.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdFactura.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFactura.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFactura.Location = New System.Drawing.Point(0, 0)
        Me.grdFactura.Name = "grdFactura"
        Me.grdFactura.Size = New System.Drawing.Size(91, 98)
        Me.grdFactura.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbRazonSocial)
        Me.GroupBox2.Location = New System.Drawing.Point(204, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(338, 51)
        Me.GroupBox2.TabIndex = 152
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Razón Social"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Items.AddRange(New Object() {"", "ACTIVO", "CANCELADO", "CONFIRMADO", "EN EJECUCIÓN", "PARCIALMENTE CONFIRMADO"})
        Me.cmbRazonSocial.Location = New System.Drawing.Point(24, 18)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(293, 21)
        Me.cmbRazonSocial.TabIndex = 147
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoagregarfacturas)
        Me.GroupBox1.Controls.Add(Me.dtpfechaFin)
        Me.GroupBox1.Controls.Add(Me.rdoFecha)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 77)
        Me.GroupBox1.TabIndex = 151
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importar por"
        '
        'rdoagregarfacturas
        '
        Me.rdoagregarfacturas.AutoSize = True
        Me.rdoagregarfacturas.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoagregarfacturas.Location = New System.Drawing.Point(11, 48)
        Me.rdoagregarfacturas.Name = "rdoagregarfacturas"
        Me.rdoagregarfacturas.Size = New System.Drawing.Size(137, 17)
        Me.rdoagregarfacturas.TabIndex = 154
        Me.rdoagregarfacturas.Text = "Factura(s) Individual(es)"
        Me.rdoagregarfacturas.UseVisualStyleBackColor = False
        '
        'dtpfechaFin
        '
        Me.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechaFin.Location = New System.Drawing.Point(72, 48)
        Me.dtpfechaFin.Name = "dtpfechaFin"
        Me.dtpfechaFin.Size = New System.Drawing.Size(98, 20)
        Me.dtpfechaFin.TabIndex = 154
        Me.dtpfechaFin.Visible = False
        '
        'rdoFecha
        '
        Me.rdoFecha.AutoSize = True
        Me.rdoFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoFecha.Location = New System.Drawing.Point(11, 19)
        Me.rdoFecha.Name = "rdoFecha"
        Me.rdoFecha.Size = New System.Drawing.Size(55, 17)
        Me.rdoFecha.TabIndex = 155
        Me.rdoFecha.Text = "Fecha"
        Me.rdoFecha.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblImportarInventarioSAP)
        Me.Panel5.Controls.Add(Me.btnImportarInventario)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(919, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(122, 165)
        Me.Panel5.TabIndex = 150
        '
        'lblImportarInventarioSAP
        '
        Me.lblImportarInventarioSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblImportarInventarioSAP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportarInventarioSAP.Location = New System.Drawing.Point(17, 52)
        Me.lblImportarInventarioSAP.Name = "lblImportarInventarioSAP"
        Me.lblImportarInventarioSAP.Size = New System.Drawing.Size(86, 26)
        Me.lblImportarInventarioSAP.TabIndex = 184
        Me.lblImportarInventarioSAP.Text = "Importar Inventario SAP"
        Me.lblImportarInventarioSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImportarInventario
        '
        Me.btnImportarInventario.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImportarInventario.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImportarInventario.Image = Global.Ventas.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnImportarInventario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarInventario.Location = New System.Drawing.Point(41, 15)
        Me.btnImportarInventario.Name = "btnImportarInventario"
        Me.btnImportarInventario.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarInventario.TabIndex = 102
        Me.btnImportarInventario.UseVisualStyleBackColor = True
        '
        'lblMostrarTexto
        '
        Me.lblMostrarTexto.AutoSize = True
        Me.lblMostrarTexto.Location = New System.Drawing.Point(201, 42)
        Me.lblMostrarTexto.Name = "lblMostrarTexto"
        Me.lblMostrarTexto.Size = New System.Drawing.Size(165, 13)
        Me.lblMostrarTexto.TabIndex = 189
        Me.lblMostrarTexto.Text = "Click en cantidad para ver detalle"
        Me.lblMostrarTexto.Visible = False
        '
        'lblTotalArticulosFaltantesSAP
        '
        Me.lblTotalArticulosFaltantesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalArticulosFaltantesSAP.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalArticulosFaltantesSAP.Location = New System.Drawing.Point(128, 35)
        Me.lblTotalArticulosFaltantesSAP.Name = "lblTotalArticulosFaltantesSAP"
        Me.lblTotalArticulosFaltantesSAP.Size = New System.Drawing.Size(120, 24)
        Me.lblTotalArticulosFaltantesSAP.TabIndex = 187
        Me.lblTotalArticulosFaltantesSAP.Text = "0"
        Me.lblTotalArticulosFaltantesSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTotalArticulosFaltantesSAP.Visible = False
        '
        'lblArticulosFaltantesSAP
        '
        Me.lblArticulosFaltantesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulosFaltantesSAP.ForeColor = System.Drawing.Color.Black
        Me.lblArticulosFaltantesSAP.Location = New System.Drawing.Point(114, 4)
        Me.lblArticulosFaltantesSAP.Name = "lblArticulosFaltantesSAP"
        Me.lblArticulosFaltantesSAP.Size = New System.Drawing.Size(153, 32)
        Me.lblArticulosFaltantesSAP.TabIndex = 186
        Me.lblArticulosFaltantesSAP.Text = "Artículos Faltantes en SAP"
        Me.lblArticulosFaltantesSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblArticulosFaltantesSAP.Visible = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1041, 65)
        Me.pnlEncabezado.TabIndex = 50
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(418, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.lblFacturar)
        Me.Panel14.Controls.Add(Me.btnFacturar)
        Me.Panel14.Controls.Add(Me.lblverdetalles)
        Me.Panel14.Controls.Add(Me.btndetalles)
        Me.Panel14.Controls.Add(Me.lblAyuda)
        Me.Panel14.Controls.Add(Me.btnAyuda)
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Controls.Add(Me.lblExportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(534, 65)
        Me.Panel14.TabIndex = 3
        '
        'lblFacturar
        '
        Me.lblFacturar.AutoSize = True
        Me.lblFacturar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFacturar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFacturar.Location = New System.Drawing.Point(144, 41)
        Me.lblFacturar.Name = "lblFacturar"
        Me.lblFacturar.Size = New System.Drawing.Size(46, 13)
        Me.lblFacturar.TabIndex = 109
        Me.lblFacturar.Text = "Facturar"
        Me.lblFacturar.Visible = False
        '
        'btnFacturar
        '
        Me.btnFacturar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnFacturar.Image = Global.Ventas.Vista.My.Resources.Resources.listaPrecios
        Me.btnFacturar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFacturar.Location = New System.Drawing.Point(150, 9)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(32, 32)
        Me.btnFacturar.TabIndex = 108
        Me.btnFacturar.UseVisualStyleBackColor = True
        Me.btnFacturar.Visible = False
        '
        'lblverdetalles
        '
        Me.lblverdetalles.AutoSize = True
        Me.lblverdetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblverdetalles.Location = New System.Drawing.Point(69, 41)
        Me.lblverdetalles.Name = "lblverdetalles"
        Me.lblverdetalles.Size = New System.Drawing.Size(64, 13)
        Me.lblverdetalles.TabIndex = 107
        Me.lblverdetalles.Text = "Ver Detalles"
        '
        'btndetalles
        '
        Me.btndetalles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btndetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btndetalles.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btndetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btndetalles.Location = New System.Drawing.Point(84, 9)
        Me.btndetalles.Name = "btndetalles"
        Me.btndetalles.Size = New System.Drawing.Size(32, 32)
        Me.btndetalles.TabIndex = 106
        Me.btndetalles.UseVisualStyleBackColor = True
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(209, 41)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 105
        Me.lblAyuda.Text = "Ayuda"
        '
        'btnAyuda
        '
        Me.btnAyuda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAyuda.Image = Global.Ventas.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAyuda.Location = New System.Drawing.Point(211, 9)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 104
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(23, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 100
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 99
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(488, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(215, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(262, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Existencias Requeridas en SAP"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblcantidadClientesSAP)
        Me.pnlPie.Controls.Add(Me.lblClientesFaltantesSAP)
        Me.pnlPie.Controls.Add(Me.lblMostrarTexto)
        Me.pnlPie.Controls.Add(Me.lblTotalArticulosFaltantesSAP)
        Me.pnlPie.Controls.Add(Me.lblArticulosFaltantesSAP)
        Me.pnlPie.Controls.Add(Me.lblTotalArticulos)
        Me.pnlPie.Controls.Add(Me.lblArticulos)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 508)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1041, 60)
        Me.pnlPie.TabIndex = 51
        '
        'lblcantidadClientesSAP
        '
        Me.lblcantidadClientesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcantidadClientesSAP.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblcantidadClientesSAP.Location = New System.Drawing.Point(301, 35)
        Me.lblcantidadClientesSAP.Name = "lblcantidadClientesSAP"
        Me.lblcantidadClientesSAP.Size = New System.Drawing.Size(120, 24)
        Me.lblcantidadClientesSAP.TabIndex = 191
        Me.lblcantidadClientesSAP.Text = "0"
        Me.lblcantidadClientesSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblcantidadClientesSAP.Visible = False
        '
        'lblClientesFaltantesSAP
        '
        Me.lblClientesFaltantesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientesFaltantesSAP.ForeColor = System.Drawing.Color.Black
        Me.lblClientesFaltantesSAP.Location = New System.Drawing.Point(285, 4)
        Me.lblClientesFaltantesSAP.Name = "lblClientesFaltantesSAP"
        Me.lblClientesFaltantesSAP.Size = New System.Drawing.Size(153, 32)
        Me.lblClientesFaltantesSAP.TabIndex = 190
        Me.lblClientesFaltantesSAP.Text = "Clientes Faltantes en SAP"
        Me.lblClientesFaltantesSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblClientesFaltantesSAP.Visible = False
        '
        'lblTotalArticulos
        '
        Me.lblTotalArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalArticulos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalArticulos.Location = New System.Drawing.Point(17, 35)
        Me.lblTotalArticulos.Name = "lblTotalArticulos"
        Me.lblTotalArticulos.Size = New System.Drawing.Size(86, 24)
        Me.lblTotalArticulos.TabIndex = 184
        Me.lblTotalArticulos.Text = "0"
        Me.lblTotalArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArticulos
        '
        Me.lblArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulos.ForeColor = System.Drawing.Color.Black
        Me.lblArticulos.Location = New System.Drawing.Point(15, 4)
        Me.lblArticulos.Name = "lblArticulos"
        Me.lblArticulos.Size = New System.Drawing.Size(86, 32)
        Me.lblArticulos.TabIndex = 183
        Me.lblArticulos.Text = "Total Artículos"
        Me.lblArticulos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.Label31)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(755, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(286, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(10, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "-"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(194, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(16, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(102, 13)
        Me.Label31.TabIndex = 159
        Me.Label31.Text = "Última Actualización"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(191, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(238, 9)
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
        Me.lblCerrar.Location = New System.Drawing.Point(237, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdArticulosCompra
        '
        Me.grdArticulosCompra.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdArticulosCompra.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdArticulosCompra.Location = New System.Drawing.Point(0, 230)
        Me.grdArticulosCompra.MainView = Me.vwReporte
        Me.grdArticulosCompra.Name = "grdArticulosCompra"
        Me.grdArticulosCompra.Size = New System.Drawing.Size(1041, 278)
        Me.grdArticulosCompra.TabIndex = 53
        Me.grdArticulosCompra.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte, Me.grdDetallesOT, Me.GridView1})
        '
        'vwReporte
        '
        Me.vwReporte.GridControl = Me.grdArticulosCompra
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.vwReporte.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowFooter = True
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdArticulosCompra
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
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdArticulosCompra
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
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(485, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'ExistenciasRequeridasenSAPForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 568)
        Me.Controls.Add(Me.grdArticulosCompra)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "ExistenciasRequeridasenSAPForm"
        Me.Text = "Existencias Requeridas en SAP"
        Me.pnlParametros.ResumeLayout(False)
        Me.gboxFolioFactura.ResumeLayout(False)
        Me.gboxFolioFactura.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdArticulosCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents cmbRazonSocial As ComboBox
    Friend WithEvents lblMostrarTexto As Label
    Friend WithEvents lblTotalArticulosFaltantesSAP As Label
    Friend WithEvents lblArticulosFaltantesSAP As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents lblAyuda As Label
    Friend WithEvents btnAyuda As Button
    Friend WithEvents btnImportarInventario As Button
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblTotalArticulos As Label
    Friend WithEvents lblArticulos As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents lblImportarInventarioSAP As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblcantidadClientesSAP As Label
    Friend WithEvents lblClientesFaltantesSAP As Label
    Friend WithEvents lblverdetalles As Label
    Friend WithEvents btndetalles As Button
    Friend WithEvents grdArticulosCompra As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents btnFacturar As Button
    Friend WithEvents lblFacturar As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents gboxFolioFactura As GroupBox
    Friend WithEvents txtFiltroFactura As TextBox
    Friend WithEvents Panel25 As Panel
    Friend WithEvents grdFactura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents rdoagregarfacturas As RadioButton
    Friend WithEvents rdoFecha As RadioButton
    Friend WithEvents dtpfechaFin As DateTimePicker
    Friend WithEvents PictureBox1 As PictureBox
End Class
