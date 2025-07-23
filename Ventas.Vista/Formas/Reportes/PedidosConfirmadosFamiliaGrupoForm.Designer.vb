<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PedidosConfirmadosFamiliaGrupoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidosConfirmadosFamiliaGrupoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnExportarExcelApartados = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCEDIS = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.grdVReporte = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ClienteId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CLIENTE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PARESPEDIDO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FVO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RVO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AGENTE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CASUALNIÑO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CASUALNIÑA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CASUALDAMA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BOTADAMA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BOTANIÑAJOVENCITA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.SANDALIANIÑO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SANDALIANIÑA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SANDALIADAMA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CABALLERO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SANDALIACABALLERO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ESCOLARNIÑO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ESCOLARNIÑA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ESCOLARDAMA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ESCOLARCABALLERO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TENISCOLEGIAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.SINFAMILIA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CINTURON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlImprimir)
        Me.pnlCabecera.Controls.Add(Me.Panel6)
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(877, 72)
        Me.pnlCabecera.TabIndex = 82
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.Label1)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(64, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(64, 72)
        Me.pnlImprimir.TabIndex = 8
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(15, 14)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(10, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Imprimir"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnExportarExcelApartados)
        Me.Panel6.Controls.Add(Me.lblActualizarDatos)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(64, 72)
        Me.Panel6.TabIndex = 7
        '
        'btnExportarExcelApartados
        '
        Me.btnExportarExcelApartados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelApartados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelApartados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelApartados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelApartados.Location = New System.Drawing.Point(16, 14)
        Me.btnExportarExcelApartados.Name = "btnExportarExcelApartados"
        Me.btnExportarExcelApartados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelApartados.TabIndex = 7
        Me.btnExportarExcelApartados.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(10, 46)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 102
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(529, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(348, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(54, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(226, 72)
        Me.Panel2.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(36, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(184, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Pedidos Confirmados " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Por Familia y Grupo"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(280, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 72)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Panel4)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 72)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(877, 28)
        Me.pnlParametros.TabIndex = 85
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnArriba)
        Me.Panel4.Controls.Add(Me.btnAbajo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(794, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(83, 28)
        Me.Panel4.TabIndex = 0
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(13, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 6
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(39, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 5
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel8)
        Me.pnlFiltros.Controls.Add(Me.Label3)
        Me.pnlFiltros.Controls.Add(Me.cmbCEDIS)
        Me.pnlFiltros.Controls.Add(Me.GroupBox2)
        Me.pnlFiltros.Controls.Add(Me.GroupBox3)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 100)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(877, 181)
        Me.pnlFiltros.TabIndex = 86
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblAceptar)
        Me.Panel8.Controls.Add(Me.btnMostrar)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(753, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(124, 181)
        Me.Panel8.TabIndex = 146
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(51, 52)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 146
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(56, 20)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 4
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "CEDIS"
        '
        'cmbCEDIS
        '
        Me.cmbCEDIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCEDIS.FormattingEnabled = True
        Me.cmbCEDIS.Location = New System.Drawing.Point(78, 141)
        Me.cmbCEDIS.Name = "cmbCEDIS"
        Me.cmbCEDIS.Size = New System.Drawing.Size(213, 21)
        Me.cmbCEDIS.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.GroupBox2.Controls.Add(Me.Panel7)
        Me.GroupBox2.Controls.Add(Me.btnAgregarCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(340, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 159)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(296, 12)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 7
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 40)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(346, 116)
        Me.Panel7.TabIndex = 2
        '
        'grdCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance1
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(346, 116)
        Me.grdCliente.TabIndex = 4
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Image = CType(resources.GetObject("btnAgregarCliente.Image"), System.Drawing.Image)
        Me.btnAgregarCliente.Location = New System.Drawing.Point(324, 12)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarCliente.TabIndex = 3
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpFechaDel)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.dtpFechaAl)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(322, 120)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha Confirmación"
        '
        'dtpFechaDel
        '
        Me.dtpFechaDel.CustomFormat = ""
        Me.dtpFechaDel.Location = New System.Drawing.Point(66, 26)
        Me.dtpFechaDel.Name = "dtpFechaDel"
        Me.dtpFechaDel.Size = New System.Drawing.Size(213, 20)
        Me.dtpFechaDel.TabIndex = 0
        Me.dtpFechaDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(29, 32)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.CustomFormat = ""
        Me.dtpFechaAl.Location = New System.Drawing.Point(66, 67)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(213, 20)
        Me.dtpFechaAl.TabIndex = 1
        Me.dtpFechaAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(36, 73)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 486)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(877, 59)
        Me.pnlPie.TabIndex = 87
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(41, 15)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 127
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(41, 31)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 126
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lblActualizacion)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(529, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(265, 59)
        Me.Panel5.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Ultima actualización:"
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(110, 26)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(16, 13)
        Me.lblActualizacion.TabIndex = 82
        Me.lblActualizacion.Text = "..."
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(794, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(83, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(25, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(24, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 2
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdReporte)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 281)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(877, 205)
        Me.Panel3.TabIndex = 88
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.grdVReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(877, 205)
        Me.grdReporte.TabIndex = 70
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVReporte})
        '
        'grdVReporte
        '
        Me.grdVReporte.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand6, Me.GridBand5, Me.gridBand7, Me.gridBand8})
        Me.grdVReporte.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.ClienteId, Me.CLIENTE, Me.PARESPEDIDO, Me.FVO, Me.RVO, Me.AGENTE, Me.CASUALNIÑO, Me.CASUALNIÑA, Me.CASUALDAMA, Me.BOTADAMA, Me.BOTANIÑAJOVENCITA, Me.SANDALIANIÑO, Me.SANDALIANIÑA, Me.SANDALIADAMA, Me.CABALLERO, Me.ESCOLARNIÑO, Me.ESCOLARNIÑA, Me.ESCOLARDAMA, Me.ESCOLARCABALLERO, Me.SANDALIACABALLERO, Me.TENISCOLEGIAL, Me.SINFAMILIA, Me.CINTURON})
        Me.grdVReporte.GridControl = Me.grdReporte
        Me.grdVReporte.Name = "grdVReporte"
        Me.grdVReporte.OptionsBehavior.Editable = False
        Me.grdVReporte.OptionsCustomization.AllowBandMoving = False
        Me.grdVReporte.OptionsCustomization.AllowColumnMoving = False
        Me.grdVReporte.OptionsCustomization.AllowFilter = False
        Me.grdVReporte.OptionsCustomization.AllowGroup = False
        Me.grdVReporte.OptionsFilter.AllowFilterEditor = False
        Me.grdVReporte.OptionsMenu.EnableColumnMenu = False
        Me.grdVReporte.OptionsSelection.MultiSelect = True
        Me.grdVReporte.OptionsView.ColumnAutoWidth = False
        Me.grdVReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.grdVReporte.OptionsView.ShowDetailButtons = False
        Me.grdVReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdVReporte.OptionsView.ShowFooter = True
        Me.grdVReporte.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Columns.Add(Me.ClienteId)
        Me.GridBand1.Columns.Add(Me.CLIENTE)
        Me.GridBand1.Columns.Add(Me.PARESPEDIDO)
        Me.GridBand1.Columns.Add(Me.FVO)
        Me.GridBand1.Columns.Add(Me.RVO)
        Me.GridBand1.Columns.Add(Me.AGENTE)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 524
        '
        'ClienteId
        '
        Me.ClienteId.Caption = "ClienteId"
        Me.ClienteId.FieldName = "ClienteId"
        Me.ClienteId.Name = "ClienteId"
        '
        'CLIENTE
        '
        Me.CLIENTE.Caption = "CLIENTE"
        Me.CLIENTE.FieldName = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.Visible = True
        Me.CLIENTE.Width = 224
        '
        'PARESPEDIDO
        '
        Me.PARESPEDIDO.Caption = "PARES PEDIDO"
        Me.PARESPEDIDO.FieldName = "PARESPEDIDO"
        Me.PARESPEDIDO.Name = "PARESPEDIDO"
        Me.PARESPEDIDO.Visible = True
        '
        'FVO
        '
        Me.FVO.Caption = "FVO"
        Me.FVO.FieldName = "FVO"
        Me.FVO.Name = "FVO"
        Me.FVO.Visible = True
        '
        'RVO
        '
        Me.RVO.Caption = "RVO"
        Me.RVO.FieldName = "RVO"
        Me.RVO.Name = "RVO"
        Me.RVO.Visible = True
        '
        'AGENTE
        '
        Me.AGENTE.Caption = "AGENTE"
        Me.AGENTE.FieldName = "AGENTE"
        Me.AGENTE.Name = "AGENTE"
        Me.AGENTE.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "CASUAL"
        Me.gridBand2.Columns.Add(Me.CASUALNIÑO)
        Me.gridBand2.Columns.Add(Me.CASUALNIÑA)
        Me.gridBand2.Columns.Add(Me.CASUALDAMA)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 311
        '
        'CASUALNIÑO
        '
        Me.CASUALNIÑO.Caption = "CASUAL NIÑO"
        Me.CASUALNIÑO.FieldName = "CASUAL NIÑO"
        Me.CASUALNIÑO.Name = "CASUALNIÑO"
        Me.CASUALNIÑO.Visible = True
        Me.CASUALNIÑO.Width = 98
        '
        'CASUALNIÑA
        '
        Me.CASUALNIÑA.Caption = "CASUAL NIÑA"
        Me.CASUALNIÑA.FieldName = "CASUAL NIÑA"
        Me.CASUALNIÑA.Name = "CASUALNIÑA"
        Me.CASUALNIÑA.Visible = True
        Me.CASUALNIÑA.Width = 97
        '
        'CASUALDAMA
        '
        Me.CASUALDAMA.Caption = "CASUAL DAMA"
        Me.CASUALDAMA.FieldName = "CASUAL DAMA"
        Me.CASUALDAMA.Name = "CASUALDAMA"
        Me.CASUALDAMA.Visible = True
        Me.CASUALDAMA.Width = 116
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "BOTA DAMA"
        Me.gridBand3.Columns.Add(Me.BOTADAMA)
        Me.gridBand3.Columns.Add(Me.BOTANIÑAJOVENCITA)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 215
        '
        'BOTADAMA
        '
        Me.BOTADAMA.Caption = "BOTA DAMA"
        Me.BOTADAMA.FieldName = "BOTA DAMA"
        Me.BOTADAMA.Name = "BOTADAMA"
        Me.BOTADAMA.Visible = True
        Me.BOTADAMA.Width = 107
        '
        'BOTANIÑAJOVENCITA
        '
        Me.BOTANIÑAJOVENCITA.Caption = "BOTA NIÑA / JOVENCITA"
        Me.BOTANIÑAJOVENCITA.FieldName = "BOTA NIÑA / JOVENCITA"
        Me.BOTANIÑAJOVENCITA.Name = "BOTANIÑAJOVENCITA"
        Me.BOTANIÑAJOVENCITA.Visible = True
        Me.BOTANIÑAJOVENCITA.Width = 108
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "SANDALIA"
        Me.gridBand4.Columns.Add(Me.SANDALIANIÑO)
        Me.gridBand4.Columns.Add(Me.SANDALIANIÑA)
        Me.gridBand4.Columns.Add(Me.SANDALIADAMA)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 225
        '
        'SANDALIANIÑO
        '
        Me.SANDALIANIÑO.Caption = "SANDALIA NIÑO"
        Me.SANDALIANIÑO.FieldName = "SANDALIA NIÑO"
        Me.SANDALIANIÑO.Name = "SANDALIANIÑO"
        Me.SANDALIANIÑO.Visible = True
        '
        'SANDALIANIÑA
        '
        Me.SANDALIANIÑA.Caption = "SANDALIA NIÑA"
        Me.SANDALIANIÑA.FieldName = "SANDALIA NIÑA"
        Me.SANDALIANIÑA.Name = "SANDALIANIÑA"
        Me.SANDALIANIÑA.Visible = True
        '
        'SANDALIADAMA
        '
        Me.SANDALIADAMA.Caption = "SANDALIA DAMA"
        Me.SANDALIADAMA.FieldName = "SANDALIA DAMA"
        Me.SANDALIADAMA.Name = "SANDALIADAMA"
        Me.SANDALIADAMA.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "CABALLERO"
        Me.gridBand6.Columns.Add(Me.CABALLERO)
        Me.gridBand6.Columns.Add(Me.SANDALIACABALLERO)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 4
        Me.gridBand6.Width = 150
        '
        'CABALLERO
        '
        Me.CABALLERO.Caption = "CABALLERO"
        Me.CABALLERO.FieldName = "CABALLERO"
        Me.CABALLERO.Name = "CABALLERO"
        Me.CABALLERO.Visible = True
        '
        'SANDALIACABALLERO
        '
        Me.SANDALIACABALLERO.Caption = "SANDALIA CABALLERO"
        Me.SANDALIACABALLERO.FieldName = "SANDALIA CABALLERO"
        Me.SANDALIACABALLERO.Name = "SANDALIACABALLERO"
        Me.SANDALIACABALLERO.Visible = True
        '
        'GridBand5
        '
        Me.GridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand5.Caption = "ESCOLAR"
        Me.GridBand5.Columns.Add(Me.ESCOLARNIÑO)
        Me.GridBand5.Columns.Add(Me.ESCOLARNIÑA)
        Me.GridBand5.Columns.Add(Me.ESCOLARDAMA)
        Me.GridBand5.Columns.Add(Me.ESCOLARCABALLERO)
        Me.GridBand5.Columns.Add(Me.TENISCOLEGIAL)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 5
        Me.GridBand5.Width = 375
        '
        'ESCOLARNIÑO
        '
        Me.ESCOLARNIÑO.Caption = "ESCOLAR NIÑO"
        Me.ESCOLARNIÑO.FieldName = "ESCOLAR NIÑO"
        Me.ESCOLARNIÑO.Name = "ESCOLARNIÑO"
        Me.ESCOLARNIÑO.Visible = True
        '
        'ESCOLARNIÑA
        '
        Me.ESCOLARNIÑA.Caption = "ESCOLAR NIÑA"
        Me.ESCOLARNIÑA.FieldName = "ESCOLAR NIÑA"
        Me.ESCOLARNIÑA.Name = "ESCOLARNIÑA"
        Me.ESCOLARNIÑA.Visible = True
        '
        'ESCOLARDAMA
        '
        Me.ESCOLARDAMA.Caption = "ESCOLAR DAMA"
        Me.ESCOLARDAMA.FieldName = "ESCOLAR DAMA"
        Me.ESCOLARDAMA.Name = "ESCOLARDAMA"
        Me.ESCOLARDAMA.Visible = True
        '
        'ESCOLARCABALLERO
        '
        Me.ESCOLARCABALLERO.Caption = "ESCOLAR CABALLERO"
        Me.ESCOLARCABALLERO.FieldName = "ESCOLAR CABALLERO"
        Me.ESCOLARCABALLERO.Name = "ESCOLARCABALLERO"
        Me.ESCOLARCABALLERO.Visible = True
        '
        'TENISCOLEGIAL
        '
        Me.TENISCOLEGIAL.Caption = "TENIS COLEGIAL"
        Me.TENISCOLEGIAL.FieldName = "TENIS COLEGIAL"
        Me.TENISCOLEGIAL.Name = "TENISCOLEGIAL"
        Me.TENISCOLEGIAL.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "SIN FAMILIA"
        Me.gridBand7.Columns.Add(Me.SINFAMILIA)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 6
        Me.gridBand7.Width = 75
        '
        'SINFAMILIA
        '
        Me.SINFAMILIA.Caption = "SIN FAMILIA"
        Me.SINFAMILIA.FieldName = "SIN FAMILIA"
        Me.SINFAMILIA.Name = "SINFAMILIA"
        Me.SINFAMILIA.Visible = True
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "CINTURÓN"
        Me.gridBand8.Columns.Add(Me.CINTURON)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 7
        Me.gridBand8.Width = 75
        '
        'CINTURON
        '
        Me.CINTURON.Caption = "CINTURÓN"
        Me.CINTURON.FieldName = "CINTURÓN"
        Me.CINTURON.Name = "CINTURON"
        Me.CINTURON.Visible = True
        '
        'PedidosConfirmadosFamiliaGrupoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 545)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "PedidosConfirmadosFamiliaGrupoForm"
        Me.Text = "Pedidos Confirmados Por Familia y Grupo"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpFechaDel As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaAl As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarCliente As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnExportarExcelApartados As Button
    Friend WithEvents lblActualizarDatos As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCEDIS As ComboBox
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVReporte As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents CASUALDAMA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BOTADAMA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BOTANIÑAJOVENCITA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SANDALIANIÑO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SANDALIANIÑA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SANDALIADAMA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CABALLERO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ESCOLARNIÑO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ESCOLARNIÑA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ESCOLARDAMA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ESCOLARCABALLERO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TENISCOLEGIAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ClienteId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CLIENTE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PARESPEDIDO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FVO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RVO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AGENTE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CASUALNIÑO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CASUALNIÑA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents pnlImprimir As Panel
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SINFAMILIA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CINTURON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents SANDALIACABALLERO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
