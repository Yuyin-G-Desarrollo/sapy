<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepositosPorIdentificarForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepositosPorIdentificarForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblCargarDocumentos = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblArticulos = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdDepositosNoIdentificados = New DevExpress.XtraGrid.GridControl()
        Me.wvDepositosNoIdentificados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlOcultaFiltros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.gpbFecha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarRacZocEmisor = New System.Windows.Forms.Button()
        Me.btnAgregarRacSocEmisor = New System.Windows.Forms.Button()
        Me.grdCuentaRazSocial = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdDepositosNoIdentificados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvDepositosNoIdentificados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOcultaFiltros.SuspendLayout()
        Me.gpbFecha.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdCuentaRazSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.Label5)
        Me.pnlBanner.Controls.Add(Me.btnImprimir)
        Me.pnlBanner.Controls.Add(Me.lblCargarDocumentos)
        Me.pnlBanner.Controls.Add(Me.btnExportar)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(1046, 63)
        Me.pnlBanner.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(83, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 184
        Me.Label5.Text = "Imprimir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(87, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblCargarDocumentos
        '
        Me.lblCargarDocumentos.AutoSize = True
        Me.lblCargarDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarDocumentos.Location = New System.Drawing.Point(23, 43)
        Me.lblCargarDocumentos.Name = "lblCargarDocumentos"
        Me.lblCargarDocumentos.Size = New System.Drawing.Size(46, 13)
        Me.lblCargarDocumentos.TabIndex = 111
        Me.lblCargarDocumentos.Text = "Exportar"
        Me.lblCargarDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportar
        '
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Cobranza.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(29, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(724, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(322, 63)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(254, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(32, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(207, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Depósitos por Identificar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblRegistros)
        Me.pnlPie.Controls.Add(Me.lblArticulos)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 518)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1046, 62)
        Me.pnlPie.TabIndex = 75
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(39, 29)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblRegistros.TabIndex = 186
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArticulos
        '
        Me.lblArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulos.ForeColor = System.Drawing.Color.Black
        Me.lblArticulos.Location = New System.Drawing.Point(39, 6)
        Me.lblArticulos.Name = "lblArticulos"
        Me.lblArticulos.Size = New System.Drawing.Size(86, 25)
        Me.lblArticulos.TabIndex = 185
        Me.lblArticulos.Text = "Registros"
        Me.lblArticulos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(907, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(139, 62)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(31, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(28, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 5
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(78, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(78, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdDepositosNoIdentificados
        '
        Me.grdDepositosNoIdentificados.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdDepositosNoIdentificados.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDepositosNoIdentificados.Location = New System.Drawing.Point(0, 248)
        Me.grdDepositosNoIdentificados.MainView = Me.wvDepositosNoIdentificados
        Me.grdDepositosNoIdentificados.Name = "grdDepositosNoIdentificados"
        Me.grdDepositosNoIdentificados.Size = New System.Drawing.Size(1046, 270)
        Me.grdDepositosNoIdentificados.TabIndex = 0
        Me.grdDepositosNoIdentificados.TabStop = False
        Me.grdDepositosNoIdentificados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.wvDepositosNoIdentificados})
        '
        'wvDepositosNoIdentificados
        '
        Me.wvDepositosNoIdentificados.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.wvDepositosNoIdentificados.Appearance.EvenRow.Options.UseBackColor = True
        Me.wvDepositosNoIdentificados.GridControl = Me.grdDepositosNoIdentificados
        Me.wvDepositosNoIdentificados.Name = "wvDepositosNoIdentificados"
        Me.wvDepositosNoIdentificados.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvDepositosNoIdentificados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvDepositosNoIdentificados.OptionsCustomization.AllowColumnMoving = False
        Me.wvDepositosNoIdentificados.OptionsView.ShowAutoFilterRow = True
        Me.wvDepositosNoIdentificados.OptionsView.ShowFooter = True
        Me.wvDepositosNoIdentificados.OptionsView.ShowGroupPanel = False
        '
        'pnlOcultaFiltros
        '
        Me.pnlOcultaFiltros.Controls.Add(Me.btnArriba)
        Me.pnlOcultaFiltros.Controls.Add(Me.btnAbajo)
        Me.pnlOcultaFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOcultaFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlOcultaFiltros.Name = "pnlOcultaFiltros"
        Me.pnlOcultaFiltros.Size = New System.Drawing.Size(1046, 25)
        Me.pnlOcultaFiltros.TabIndex = 20
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(978, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.TabStop = False
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1004, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 0
        Me.btnAbajo.TabStop = False
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(837, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(840, 38)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 6
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'gpbFecha
        '
        Me.gpbFecha.Controls.Add(Me.Label3)
        Me.gpbFecha.Controls.Add(Me.dtpFechaFinal)
        Me.gpbFecha.Controls.Add(Me.Label2)
        Me.gpbFecha.Controls.Add(Me.dtpFechaInicio)
        Me.gpbFecha.Location = New System.Drawing.Point(31, 38)
        Me.gpbFecha.Name = "gpbFecha"
        Me.gpbFecha.Size = New System.Drawing.Size(213, 132)
        Me.gpbFecha.TabIndex = 155
        Me.gpbFecha.TabStop = False
        Me.gpbFecha.Text = " Fechas:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "Fecha Final"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(83, 80)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "Fecha Inicio"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(83, 33)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaInicio.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarRacZocEmisor)
        Me.GroupBox2.Controls.Add(Me.btnAgregarRacSocEmisor)
        Me.GroupBox2.Controls.Add(Me.grdCuentaRazSocial)
        Me.GroupBox2.Location = New System.Drawing.Point(393, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 132)
        Me.GroupBox2.TabIndex = 182
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cuenta Razón Social"
        '
        'btnLimpiarRacZocEmisor
        '
        Me.btnLimpiarRacZocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarRacZocEmisor.Location = New System.Drawing.Point(320, 12)
        Me.btnLimpiarRacZocEmisor.Name = "btnLimpiarRacZocEmisor"
        Me.btnLimpiarRacZocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarRacZocEmisor.TabIndex = 17
        Me.btnLimpiarRacZocEmisor.UseVisualStyleBackColor = True
        '
        'btnAgregarRacSocEmisor
        '
        Me.btnAgregarRacSocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarRacSocEmisor.Location = New System.Drawing.Point(348, 12)
        Me.btnAgregarRacSocEmisor.Name = "btnAgregarRacSocEmisor"
        Me.btnAgregarRacSocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarRacSocEmisor.TabIndex = 18
        Me.btnAgregarRacSocEmisor.UseVisualStyleBackColor = True
        '
        'grdCuentaRazSocial
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCuentaRazSocial.DisplayLayout.Appearance = Appearance1
        Me.grdCuentaRazSocial.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCuentaRazSocial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCuentaRazSocial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCuentaRazSocial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCuentaRazSocial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCuentaRazSocial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCuentaRazSocial.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCuentaRazSocial.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCuentaRazSocial.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCuentaRazSocial.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCuentaRazSocial.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCuentaRazSocial.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdCuentaRazSocial.Location = New System.Drawing.Point(3, 36)
        Me.grdCuentaRazSocial.Name = "grdCuentaRazSocial"
        Me.grdCuentaRazSocial.Size = New System.Drawing.Size(389, 93)
        Me.grdCuentaRazSocial.TabIndex = 16
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.GroupBox2)
        Me.pnlAcciones.Controls.Add(Me.gpbFecha)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.Label4)
        Me.pnlAcciones.Controls.Add(Me.pnlOcultaFiltros)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 63)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1046, 185)
        Me.pnlAcciones.TabIndex = 76
        '
        'DepositosPorIdentificarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1046, 580)
        Me.Controls.Add(Me.grdDepositosNoIdentificados)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlBanner)
        Me.KeyPreview = True
        Me.Name = "DepositosPorIdentificarForm"
        Me.Text = "Depósitos por Identificar"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdDepositosNoIdentificados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvDepositosNoIdentificados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOcultaFiltros.ResumeLayout(False)
        Me.gpbFecha.ResumeLayout(False)
        Me.gpbFecha.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdCuentaRazSocial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents grdDepositosNoIdentificados As DevExpress.XtraGrid.GridControl
    Friend WithEvents wvDepositosNoIdentificados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblCargarDocumentos As Windows.Forms.Label
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblRegistros As Windows.Forms.Label
    Friend WithEvents lblArticulos As Windows.Forms.Label
    Friend WithEvents pnlOcultaFiltros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents gpbFecha As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents grdCuentaRazSocial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarRacZocEmisor As Windows.Forms.Button
    Friend WithEvents btnAgregarRacSocEmisor As Windows.Forms.Button
End Class
