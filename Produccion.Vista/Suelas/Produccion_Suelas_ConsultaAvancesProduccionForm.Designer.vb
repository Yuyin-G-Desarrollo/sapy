<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Produccion_Suelas_ConsultaAvancesProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion_Suelas_ConsultaAvancesProduccionForm))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxNave = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroNave = New System.Windows.Forms.Button()
        Me.btnMarcas = New System.Windows.Forms.Button()
        Me.grdSuelas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarFiltroSuela = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnLimpiarFiltroMaquina = New System.Windows.Forms.Button()
        Me.grdMaquinas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grpboxagente = New System.Windows.Forms.GroupBox()
        Me.btnMaquinas = New System.Windows.Forms.Button()
        Me.txtMaquina = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bgvReporte = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.grdReporteResumen = New DevExpress.XtraGrid.GridControl()
        Me.vwReporteResumen = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gboxTarjetaProduccion = New System.Windows.Forms.GroupBox()
        Me.txtTarjeta = New System.Windows.Forms.MaskedTextBox()
        Me.btnLimpiarFiltroTarjeta = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdTarjetas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxSuela = New System.Windows.Forms.GroupBox()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.gboxOperador = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroOperador = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdOperadores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbTipoReporte = New System.Windows.Forms.ComboBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.grpbxFiltroFechas = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkFechaPrograma = New System.Windows.Forms.CheckBox()
        Me.chkFechaAvance = New System.Windows.Forms.CheckBox()
        Me.dtpFechaProgramaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaAvanceInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaProgramaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaAvanceFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.Panel8.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxNave.SuspendLayout()
        CType(Me.grdSuelas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.grdMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.grpboxagente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.bgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.grdReporteResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporteResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.gboxTarjetaProduccion.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSuela.SuspendLayout()
        Me.gboxOperador.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdOperadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbxFiltroFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdNaves)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 52)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(182, 116)
        Me.Panel8.TabIndex = 2
        '
        'grdNaves
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Appearance = Appearance1
        Me.grdNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.Size = New System.Drawing.Size(182, 116)
        Me.grdNaves.TabIndex = 3
        '
        'gboxNave
        '
        Me.gboxNave.Controls.Add(Me.btnLimpiarFiltroNave)
        Me.gboxNave.Controls.Add(Me.Panel8)
        Me.gboxNave.Controls.Add(Me.btnMarcas)
        Me.gboxNave.Dock = System.Windows.Forms.DockStyle.Left
        Me.gboxNave.Location = New System.Drawing.Point(432, 0)
        Me.gboxNave.Name = "gboxNave"
        Me.gboxNave.Size = New System.Drawing.Size(188, 171)
        Me.gboxNave.TabIndex = 95
        Me.gboxNave.TabStop = False
        Me.gboxNave.Text = "Nave"
        '
        'btnLimpiarFiltroNave
        '
        Me.btnLimpiarFiltroNave.Image = CType(resources.GetObject("btnLimpiarFiltroNave.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroNave.Location = New System.Drawing.Point(134, 11)
        Me.btnLimpiarFiltroNave.Name = "btnLimpiarFiltroNave"
        Me.btnLimpiarFiltroNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroNave.TabIndex = 3
        Me.btnLimpiarFiltroNave.UseVisualStyleBackColor = True
        '
        'btnMarcas
        '
        Me.btnMarcas.Image = CType(resources.GetObject("btnMarcas.Image"), System.Drawing.Image)
        Me.btnMarcas.Location = New System.Drawing.Point(162, 11)
        Me.btnMarcas.Name = "btnMarcas"
        Me.btnMarcas.Size = New System.Drawing.Size(22, 22)
        Me.btnMarcas.TabIndex = 0
        Me.btnMarcas.UseVisualStyleBackColor = True
        '
        'grdSuelas
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSuelas.DisplayLayout.Appearance = Appearance3
        Me.grdSuelas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdSuelas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdSuelas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdSuelas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdSuelas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSuelas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdSuelas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdSuelas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSuelas.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdSuelas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSuelas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSuelas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSuelas.Location = New System.Drawing.Point(0, 0)
        Me.grdSuelas.Name = "grdSuelas"
        Me.grdSuelas.Size = New System.Drawing.Size(210, 116)
        Me.grdSuelas.TabIndex = 3
        '
        'btnLimpiarFiltroSuela
        '
        Me.btnLimpiarFiltroSuela.Image = CType(resources.GetObject("btnLimpiarFiltroSuela.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroSuela.Location = New System.Drawing.Point(161, 11)
        Me.btnLimpiarFiltroSuela.Name = "btnLimpiarFiltroSuela"
        Me.btnLimpiarFiltroSuela.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroSuela.TabIndex = 4
        Me.btnLimpiarFiltroSuela.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(511, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(707, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(579, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(208, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(297, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Consulta de Avances de Producción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(16, 7)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 53
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(10, 39)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 52
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcel)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(698, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Produccion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(1226, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1286, 59)
        Me.pnlEncabezado.TabIndex = 26
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Produccion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1252, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1286, 27)
        Me.Panel6.TabIndex = 46
        '
        'btnLimpiarFiltroMaquina
        '
        Me.btnLimpiarFiltroMaquina.Image = CType(resources.GetObject("btnLimpiarFiltroMaquina.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroMaquina.Location = New System.Drawing.Point(65, 11)
        Me.btnLimpiarFiltroMaquina.Name = "btnLimpiarFiltroMaquina"
        Me.btnLimpiarFiltroMaquina.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroMaquina.TabIndex = 0
        Me.btnLimpiarFiltroMaquina.UseVisualStyleBackColor = True
        '
        'grdMaquinas
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMaquinas.DisplayLayout.Appearance = Appearance5
        Me.grdMaquinas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdMaquinas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMaquinas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMaquinas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMaquinas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMaquinas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMaquinas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMaquinas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMaquinas.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdMaquinas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMaquinas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMaquinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMaquinas.Location = New System.Drawing.Point(0, 0)
        Me.grdMaquinas.Name = "grdMaquinas"
        Me.grdMaquinas.Size = New System.Drawing.Size(114, 116)
        Me.grdMaquinas.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdMaquinas)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 52)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(114, 116)
        Me.Panel7.TabIndex = 2
        '
        'grpboxagente
        '
        Me.grpboxagente.Controls.Add(Me.btnMaquinas)
        Me.grpboxagente.Controls.Add(Me.txtMaquina)
        Me.grpboxagente.Controls.Add(Me.Panel7)
        Me.grpboxagente.Controls.Add(Me.btnLimpiarFiltroMaquina)
        Me.grpboxagente.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpboxagente.Location = New System.Drawing.Point(620, 0)
        Me.grpboxagente.Name = "grpboxagente"
        Me.grpboxagente.Size = New System.Drawing.Size(120, 171)
        Me.grpboxagente.TabIndex = 67
        Me.grpboxagente.TabStop = False
        Me.grpboxagente.Text = "Máquina"
        '
        'btnMaquinas
        '
        Me.btnMaquinas.Image = CType(resources.GetObject("btnMaquinas.Image"), System.Drawing.Image)
        Me.btnMaquinas.Location = New System.Drawing.Point(93, 11)
        Me.btnMaquinas.Name = "btnMaquinas"
        Me.btnMaquinas.Size = New System.Drawing.Size(22, 22)
        Me.btnMaquinas.TabIndex = 4
        Me.btnMaquinas.UseVisualStyleBackColor = True
        '
        'txtMaquina
        '
        Me.txtMaquina.Location = New System.Drawing.Point(6, 15)
        Me.txtMaquina.Mask = "99999999999999999"
        Me.txtMaquina.Name = "txtMaquina"
        Me.txtMaquina.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMaquina.Size = New System.Drawing.Size(70, 20)
        Me.txtMaquina.TabIndex = 3
        Me.txtMaquina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaquina.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdSuelas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 116)
        Me.Panel1.TabIndex = 2
        '
        'bgvReporte
        '
        Me.bgvReporte.GridControl = Me.grdReporte
        Me.bgvReporte.Name = "bgvReporte"
        Me.bgvReporte.OptionsBehavior.Editable = False
        Me.bgvReporte.OptionsCustomization.AllowColumnMoving = False
        Me.bgvReporte.OptionsCustomization.AllowFilter = False
        Me.bgvReporte.OptionsCustomization.AllowGroup = False
        Me.bgvReporte.OptionsCustomization.AllowSort = False
        Me.bgvReporte.OptionsMenu.EnableColumnMenu = False
        Me.bgvReporte.OptionsSelection.MultiSelect = True
        Me.bgvReporte.OptionsView.ColumnAutoWidth = False
        Me.bgvReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvReporte.OptionsView.ShowDetailButtons = False
        Me.bgvReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvReporte.OptionsView.ShowGroupPanel = False
        Me.bgvReporte.OptionsView.ShowIndicator = False
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(0, 265)
        Me.grdReporte.MainView = Me.bgvReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(1286, 284)
        Me.grdReporte.TabIndex = 29
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvReporte})
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 549)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1286, 60)
        Me.pnlPie.TabIndex = 28
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(875, 18)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 104
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(881, 38)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 105
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1136, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(150, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(107, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(106, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(68, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(1227, 124)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1232, 92)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.grdReporteResumen)
        Me.pnlPrincipal.Controls.Add(Me.grdReporte)
        Me.pnlPrincipal.Controls.Add(Me.pnlPie)
        Me.pnlPrincipal.Controls.Add(Me.pnlParametros)
        Me.pnlPrincipal.Controls.Add(Me.pnlEncabezado)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1286, 609)
        Me.pnlPrincipal.TabIndex = 2
        '
        'grdReporteResumen
        '
        Me.grdReporteResumen.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdReporteResumen.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdReporteResumen.Location = New System.Drawing.Point(0, 265)
        Me.grdReporteResumen.MainView = Me.vwReporteResumen
        Me.grdReporteResumen.Name = "grdReporteResumen"
        Me.grdReporteResumen.Size = New System.Drawing.Size(1286, 284)
        Me.grdReporteResumen.TabIndex = 30
        Me.grdReporteResumen.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporteResumen, Me.GridView1, Me.grdDetallesOT})
        '
        'vwReporteResumen
        '
        Me.vwReporteResumen.GridControl = Me.grdReporteResumen
        Me.vwReporteResumen.Name = "vwReporteResumen"
        Me.vwReporteResumen.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteResumen.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteResumen.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwReporteResumen.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporteResumen.OptionsSelection.MultiSelect = True
        Me.vwReporteResumen.OptionsView.ColumnAutoWidth = False
        Me.vwReporteResumen.OptionsView.ShowAutoFilterRow = True
        Me.vwReporteResumen.OptionsView.ShowFooter = True
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdReporteResumen
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
        Me.grdDetallesOT.GridControl = Me.grdReporteResumen
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
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Panel4)
        Me.pnlParametros.Controls.Add(Me.cmbTipoReporte)
        Me.pnlParametros.Controls.Add(Me.lbl)
        Me.pnlParametros.Controls.Add(Me.lblAceptar)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.grpbxFiltroFechas)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1286, 206)
        Me.pnlParametros.TabIndex = 27
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gboxTarjetaProduccion)
        Me.Panel4.Controls.Add(Me.grpboxagente)
        Me.Panel4.Controls.Add(Me.gboxNave)
        Me.Panel4.Controls.Add(Me.gboxSuela)
        Me.Panel4.Controls.Add(Me.gboxOperador)
        Me.Panel4.Location = New System.Drawing.Point(263, 32)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(949, 171)
        Me.Panel4.TabIndex = 31
        '
        'gboxTarjetaProduccion
        '
        Me.gboxTarjetaProduccion.Controls.Add(Me.txtTarjeta)
        Me.gboxTarjetaProduccion.Controls.Add(Me.btnLimpiarFiltroTarjeta)
        Me.gboxTarjetaProduccion.Controls.Add(Me.Panel3)
        Me.gboxTarjetaProduccion.Dock = System.Windows.Forms.DockStyle.Left
        Me.gboxTarjetaProduccion.Location = New System.Drawing.Point(740, 0)
        Me.gboxTarjetaProduccion.Name = "gboxTarjetaProduccion"
        Me.gboxTarjetaProduccion.Size = New System.Drawing.Size(188, 171)
        Me.gboxTarjetaProduccion.TabIndex = 105
        Me.gboxTarjetaProduccion.TabStop = False
        Me.gboxTarjetaProduccion.Text = "Tarjeta Producción"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Location = New System.Drawing.Point(70, 13)
        Me.txtTarjeta.Mask = "999999999999"
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTarjeta.Size = New System.Drawing.Size(84, 20)
        Me.txtTarjeta.TabIndex = 4
        Me.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTarjeta.ValidatingType = GetType(Integer)
        '
        'btnLimpiarFiltroTarjeta
        '
        Me.btnLimpiarFiltroTarjeta.Image = CType(resources.GetObject("btnLimpiarFiltroTarjeta.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroTarjeta.Location = New System.Drawing.Point(160, 11)
        Me.btnLimpiarFiltroTarjeta.Name = "btnLimpiarFiltroTarjeta"
        Me.btnLimpiarFiltroTarjeta.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroTarjeta.TabIndex = 3
        Me.btnLimpiarFiltroTarjeta.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdTarjetas)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(182, 116)
        Me.Panel3.TabIndex = 2
        '
        'grdTarjetas
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTarjetas.DisplayLayout.Appearance = Appearance7
        Me.grdTarjetas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTarjetas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTarjetas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTarjetas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTarjetas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTarjetas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTarjetas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTarjetas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTarjetas.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdTarjetas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTarjetas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTarjetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTarjetas.Location = New System.Drawing.Point(0, 0)
        Me.grdTarjetas.Name = "grdTarjetas"
        Me.grdTarjetas.Size = New System.Drawing.Size(182, 116)
        Me.grdTarjetas.TabIndex = 3
        '
        'gboxSuela
        '
        Me.gboxSuela.Controls.Add(Me.btnLimpiarFiltroSuela)
        Me.gboxSuela.Controls.Add(Me.Panel1)
        Me.gboxSuela.Controls.Add(Me.btnCliente)
        Me.gboxSuela.Dock = System.Windows.Forms.DockStyle.Left
        Me.gboxSuela.Location = New System.Drawing.Point(216, 0)
        Me.gboxSuela.Name = "gboxSuela"
        Me.gboxSuela.Size = New System.Drawing.Size(216, 171)
        Me.gboxSuela.TabIndex = 102
        Me.gboxSuela.TabStop = False
        Me.gboxSuela.Text = "Suela"
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(189, 11)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'gboxOperador
        '
        Me.gboxOperador.Controls.Add(Me.btnLimpiarFiltroOperador)
        Me.gboxOperador.Controls.Add(Me.Panel2)
        Me.gboxOperador.Controls.Add(Me.Button2)
        Me.gboxOperador.Dock = System.Windows.Forms.DockStyle.Left
        Me.gboxOperador.Location = New System.Drawing.Point(0, 0)
        Me.gboxOperador.Name = "gboxOperador"
        Me.gboxOperador.Size = New System.Drawing.Size(216, 171)
        Me.gboxOperador.TabIndex = 102
        Me.gboxOperador.TabStop = False
        Me.gboxOperador.Text = "Operador"
        '
        'btnLimpiarFiltroOperador
        '
        Me.btnLimpiarFiltroOperador.Image = CType(resources.GetObject("btnLimpiarFiltroOperador.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroOperador.Location = New System.Drawing.Point(160, 11)
        Me.btnLimpiarFiltroOperador.Name = "btnLimpiarFiltroOperador"
        Me.btnLimpiarFiltroOperador.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroOperador.TabIndex = 4
        Me.btnLimpiarFiltroOperador.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdOperadores)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(210, 116)
        Me.Panel2.TabIndex = 2
        '
        'grdOperadores
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOperadores.DisplayLayout.Appearance = Appearance9
        Me.grdOperadores.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdOperadores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdOperadores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOperadores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdOperadores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOperadores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdOperadores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOperadores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOperadores.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdOperadores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOperadores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOperadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOperadores.Location = New System.Drawing.Point(0, 0)
        Me.grdOperadores.Name = "grdOperadores"
        Me.grdOperadores.Size = New System.Drawing.Size(210, 116)
        Me.grdOperadores.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(188, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 0
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmbTipoReporte
        '
        Me.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoReporte.FormattingEnabled = True
        Me.cmbTipoReporte.Items.AddRange(New Object() {"Avance Tarjeta de Producción", "Inventario Produccion Por Nave", "Avance Produccion Por maquina", "Avance Produccion Por Nave", "Avance Produccion Por Operador"})
        Me.cmbTipoReporte.Location = New System.Drawing.Point(76, 36)
        Me.cmbTipoReporte.Name = "cmbTipoReporte"
        Me.cmbTipoReporte.Size = New System.Drawing.Size(181, 21)
        Me.cmbTipoReporte.TabIndex = 104
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(3, 39)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(72, 13)
        Me.lbl.TabIndex = 103
        Me.lbl.Text = "Tipo Reporte:"
        '
        'grpbxFiltroFechas
        '
        Me.grpbxFiltroFechas.Controls.Add(Me.Label6)
        Me.grpbxFiltroFechas.Controls.Add(Me.Label2)
        Me.grpbxFiltroFechas.Controls.Add(Me.chkFechaPrograma)
        Me.grpbxFiltroFechas.Controls.Add(Me.chkFechaAvance)
        Me.grpbxFiltroFechas.Controls.Add(Me.dtpFechaProgramaInicio)
        Me.grpbxFiltroFechas.Controls.Add(Me.dtpFechaAvanceInicio)
        Me.grpbxFiltroFechas.Controls.Add(Me.dtpFechaProgramaFin)
        Me.grpbxFiltroFechas.Controls.Add(Me.Label1)
        Me.grpbxFiltroFechas.Controls.Add(Me.dtpFechaAvanceFin)
        Me.grpbxFiltroFechas.Controls.Add(Me.lblEntregaAl)
        Me.grpbxFiltroFechas.Location = New System.Drawing.Point(6, 68)
        Me.grpbxFiltroFechas.Name = "grpbxFiltroFechas"
        Me.grpbxFiltroFechas.Size = New System.Drawing.Size(251, 125)
        Me.grpbxFiltroFechas.TabIndex = 99
        Me.grpbxFiltroFechas.TabStop = False
        Me.grpbxFiltroFechas.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "De:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "De:"
        '
        'chkFechaPrograma
        '
        Me.chkFechaPrograma.AutoSize = True
        Me.chkFechaPrograma.Checked = True
        Me.chkFechaPrograma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechaPrograma.Location = New System.Drawing.Point(9, 74)
        Me.chkFechaPrograma.Name = "chkFechaPrograma"
        Me.chkFechaPrograma.Size = New System.Drawing.Size(71, 17)
        Me.chkFechaPrograma.TabIndex = 71
        Me.chkFechaPrograma.Text = "Programa"
        Me.chkFechaPrograma.UseVisualStyleBackColor = True
        '
        'chkFechaAvance
        '
        Me.chkFechaAvance.AutoSize = True
        Me.chkFechaAvance.Checked = True
        Me.chkFechaAvance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechaAvance.Location = New System.Drawing.Point(9, 18)
        Me.chkFechaAvance.Name = "chkFechaAvance"
        Me.chkFechaAvance.Size = New System.Drawing.Size(63, 17)
        Me.chkFechaAvance.TabIndex = 71
        Me.chkFechaAvance.Text = "Avance"
        Me.chkFechaAvance.UseVisualStyleBackColor = True
        '
        'dtpFechaProgramaInicio
        '
        Me.dtpFechaProgramaInicio.CustomFormat = ""
        Me.dtpFechaProgramaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramaInicio.Location = New System.Drawing.Point(37, 98)
        Me.dtpFechaProgramaInicio.Name = "dtpFechaProgramaInicio"
        Me.dtpFechaProgramaInicio.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaProgramaInicio.TabIndex = 66
        Me.dtpFechaProgramaInicio.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'dtpFechaAvanceInicio
        '
        Me.dtpFechaAvanceInicio.CustomFormat = ""
        Me.dtpFechaAvanceInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAvanceInicio.Location = New System.Drawing.Point(37, 42)
        Me.dtpFechaAvanceInicio.Name = "dtpFechaAvanceInicio"
        Me.dtpFechaAvanceInicio.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAvanceInicio.TabIndex = 66
        Me.dtpFechaAvanceInicio.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'dtpFechaProgramaFin
        '
        Me.dtpFechaProgramaFin.CustomFormat = ""
        Me.dtpFechaProgramaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramaFin.Location = New System.Drawing.Point(155, 98)
        Me.dtpFechaProgramaFin.Name = "dtpFechaProgramaFin"
        Me.dtpFechaProgramaFin.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaProgramaFin.TabIndex = 69
        Me.dtpFechaProgramaFin.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(129, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "A:"
        '
        'dtpFechaAvanceFin
        '
        Me.dtpFechaAvanceFin.CustomFormat = ""
        Me.dtpFechaAvanceFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAvanceFin.Location = New System.Drawing.Point(155, 42)
        Me.dtpFechaAvanceFin.Name = "dtpFechaAvanceFin"
        Me.dtpFechaAvanceFin.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAvanceFin.TabIndex = 69
        Me.dtpFechaAvanceFin.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(129, 46)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(17, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "A:"
        '
        'Produccion_Suelas_ConsultaAvancesProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1286, 609)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Name = "Produccion_Suelas_ConsultaAvancesProduccionForm"
        Me.Text = "Consulta de Avances de Producción"
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxNave.ResumeLayout(False)
        CType(Me.grdSuelas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.grdMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.grpboxagente.ResumeLayout(False)
        Me.grpboxagente.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.bgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPrincipal.ResumeLayout(False)
        CType(Me.grdReporteResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporteResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.gboxTarjetaProduccion.ResumeLayout(False)
        Me.gboxTarjetaProduccion.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSuela.ResumeLayout(False)
        Me.gboxOperador.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdOperadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbxFiltroFechas.ResumeLayout(False)
        Me.grpbxFiltroFechas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxNave As GroupBox
    Friend WithEvents btnLimpiarFiltroNave As Button
    Friend WithEvents btnMarcas As Button
    Friend WithEvents grdSuelas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarFiltroSuela As Button
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblActualizarDatos As Label
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnLimpiarFiltroMaquina As Button
    Friend WithEvents grdMaquinas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grpboxagente As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents bgvReporte As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblTextoUltimaActualizacion As Label
    Friend WithEvents lblFechaUltimaActualización As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnMostrar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents gboxSuela As GroupBox
    Friend WithEvents btnCliente As Button
    Friend WithEvents grpbxFiltroFechas As GroupBox
    Friend WithEvents dtpFechaAvanceInicio As DateTimePicker
    Friend WithEvents dtpFechaAvanceFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents chkFechaPrograma As CheckBox
    Friend WithEvents chkFechaAvance As CheckBox
    Friend WithEvents dtpFechaProgramaInicio As DateTimePicker
    Friend WithEvents dtpFechaProgramaFin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMaquina As MaskedTextBox
    Friend WithEvents gboxOperador As GroupBox
    Friend WithEvents btnLimpiarFiltroOperador As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdOperadores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grdReporteResumen As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporteResumen As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents lbl As Label
    Friend WithEvents cmbTipoReporte As ComboBox
    Friend WithEvents btnMaquinas As Button
    Friend WithEvents gboxTarjetaProduccion As GroupBox
    Friend WithEvents btnLimpiarFiltroTarjeta As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdTarjetas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtTarjeta As MaskedTextBox
    Friend WithEvents Panel4 As Panel
End Class
