<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadisticaVentasPorFamiliaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadisticaVentasPorFamiliaForm))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlConsultaAnualYMarca = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdConsultaAnual = New DevExpress.XtraGrid.GridControl()
        Me.bgvConsultaAnual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdConsultaMarca = New DevExpress.XtraGrid.GridControl()
        Me.bgvConsultaMarca = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chrConsultaAnual = New DevExpress.XtraCharts.ChartControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chrConsultaMarca = New DevExpress.XtraCharts.ChartControl()
        Me.grdReporteEstadisticoFamilias = New DevExpress.XtraGrid.GridControl()
        Me.bgvReporteEstadisticoFamilias = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.grpboxCrecimiento = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumRegistros = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.grpReportesNoEstadisticoFamilia = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaInicioConsultas = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaFinConsultas = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmboxTipoReporte = New System.Windows.Forms.ComboBox()
        Me.grpBoxAgente = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdAgentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarFiltroAgente = New System.Windows.Forms.Button()
        Me.btnAgente = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.grpEstadisticaVentas = New System.Windows.Forms.GroupBox()
        Me.txtAñoComparacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaEntregaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaEntregaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlConsultaAnualYMarca.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdConsultaAnual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvConsultaAnual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grdConsultaMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvConsultaMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.chrConsultaAnual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.chrConsultaMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReporteEstadisticoFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvReporteEstadisticoFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.grpboxCrecimiento.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.grpReportesNoEstadisticoFamilia.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpBoxAgente.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEstadisticaVentas.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.Controls.Add(Me.pnlConsultaAnualYMarca)
        Me.pnlContenedor.Controls.Add(Me.grdReporteEstadisticoFamilias)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Controls.Add(Me.pnlParametros)
        Me.pnlContenedor.Controls.Add(Me.pnlEncabezado)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1276, 609)
        Me.pnlContenedor.TabIndex = 0
        '
        'pnlConsultaAnualYMarca
        '
        Me.pnlConsultaAnualYMarca.Controls.Add(Me.SplitContainer1)
        Me.pnlConsultaAnualYMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConsultaAnualYMarca.Location = New System.Drawing.Point(0, 265)
        Me.pnlConsultaAnualYMarca.Name = "pnlConsultaAnualYMarca"
        Me.pnlConsultaAnualYMarca.Size = New System.Drawing.Size(1276, 284)
        Me.pnlConsultaAnualYMarca.TabIndex = 30
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1276, 284)
        Me.SplitContainer1.SplitterDistance = 622
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer2.Size = New System.Drawing.Size(622, 284)
        Me.SplitContainer2.SplitterDistance = 129
        Me.SplitContainer2.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdConsultaAnual)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(622, 129)
        Me.Panel2.TabIndex = 0
        '
        'grdConsultaAnual
        '
        Me.grdConsultaAnual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaAnual.Location = New System.Drawing.Point(0, 0)
        Me.grdConsultaAnual.MainView = Me.bgvConsultaAnual
        Me.grdConsultaAnual.Name = "grdConsultaAnual"
        Me.grdConsultaAnual.Size = New System.Drawing.Size(622, 129)
        Me.grdConsultaAnual.TabIndex = 30
        Me.grdConsultaAnual.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvConsultaAnual})
        '
        'bgvConsultaAnual
        '
        Me.bgvConsultaAnual.GridControl = Me.grdConsultaAnual
        Me.bgvConsultaAnual.Name = "bgvConsultaAnual"
        Me.bgvConsultaAnual.OptionsBehavior.Editable = False
        Me.bgvConsultaAnual.OptionsCustomization.AllowColumnMoving = False
        Me.bgvConsultaAnual.OptionsCustomization.AllowFilter = False
        Me.bgvConsultaAnual.OptionsCustomization.AllowGroup = False
        Me.bgvConsultaAnual.OptionsCustomization.AllowSort = False
        Me.bgvConsultaAnual.OptionsMenu.EnableColumnMenu = False
        Me.bgvConsultaAnual.OptionsSelection.MultiSelect = True
        Me.bgvConsultaAnual.OptionsView.ColumnAutoWidth = False
        Me.bgvConsultaAnual.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvConsultaAnual.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvConsultaAnual.OptionsView.ShowDetailButtons = False
        Me.bgvConsultaAnual.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvConsultaAnual.OptionsView.ShowGroupPanel = False
        Me.bgvConsultaAnual.OptionsView.ShowIndicator = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdConsultaMarca)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(622, 151)
        Me.Panel3.TabIndex = 1
        '
        'grdConsultaMarca
        '
        Me.grdConsultaMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaMarca.Location = New System.Drawing.Point(0, 0)
        Me.grdConsultaMarca.MainView = Me.bgvConsultaMarca
        Me.grdConsultaMarca.Name = "grdConsultaMarca"
        Me.grdConsultaMarca.Size = New System.Drawing.Size(622, 151)
        Me.grdConsultaMarca.TabIndex = 30
        Me.grdConsultaMarca.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvConsultaMarca})
        '
        'bgvConsultaMarca
        '
        Me.bgvConsultaMarca.GridControl = Me.grdConsultaMarca
        Me.bgvConsultaMarca.Name = "bgvConsultaMarca"
        Me.bgvConsultaMarca.OptionsBehavior.Editable = False
        Me.bgvConsultaMarca.OptionsCustomization.AllowColumnMoving = False
        Me.bgvConsultaMarca.OptionsCustomization.AllowFilter = False
        Me.bgvConsultaMarca.OptionsCustomization.AllowGroup = False
        Me.bgvConsultaMarca.OptionsCustomization.AllowSort = False
        Me.bgvConsultaMarca.OptionsMenu.EnableColumnMenu = False
        Me.bgvConsultaMarca.OptionsSelection.MultiSelect = True
        Me.bgvConsultaMarca.OptionsView.ColumnAutoWidth = False
        Me.bgvConsultaMarca.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvConsultaMarca.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvConsultaMarca.OptionsView.ShowDetailButtons = False
        Me.bgvConsultaMarca.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvConsultaMarca.OptionsView.ShowGroupPanel = False
        Me.bgvConsultaMarca.OptionsView.ShowIndicator = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel5)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer3.Size = New System.Drawing.Size(653, 284)
        Me.SplitContainer3.SplitterDistance = 129
        Me.SplitContainer3.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.chrConsultaAnual)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(653, 129)
        Me.Panel5.TabIndex = 1
        '
        'chrConsultaAnual
        '
        Me.chrConsultaAnual.DataBindings = Nothing
        Me.chrConsultaAnual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrConsultaAnual.Legend.Name = "Default Legend"
        Me.chrConsultaAnual.Location = New System.Drawing.Point(0, 0)
        Me.chrConsultaAnual.Name = "chrConsultaAnual"
        Me.chrConsultaAnual.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.chrConsultaAnual.Size = New System.Drawing.Size(653, 129)
        Me.chrConsultaAnual.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chrConsultaMarca)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(653, 151)
        Me.Panel4.TabIndex = 1
        '
        'chrConsultaMarca
        '
        Me.chrConsultaMarca.DataBindings = Nothing
        Me.chrConsultaMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrConsultaMarca.Legend.Name = "Default Legend"
        Me.chrConsultaMarca.Location = New System.Drawing.Point(0, 0)
        Me.chrConsultaMarca.Name = "chrConsultaMarca"
        Me.chrConsultaMarca.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.chrConsultaMarca.Size = New System.Drawing.Size(653, 151)
        Me.chrConsultaMarca.TabIndex = 1
        '
        'grdReporteEstadisticoFamilias
        '
        Me.grdReporteEstadisticoFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporteEstadisticoFamilias.Location = New System.Drawing.Point(0, 265)
        Me.grdReporteEstadisticoFamilias.MainView = Me.bgvReporteEstadisticoFamilias
        Me.grdReporteEstadisticoFamilias.Name = "grdReporteEstadisticoFamilias"
        Me.grdReporteEstadisticoFamilias.Size = New System.Drawing.Size(1276, 284)
        Me.grdReporteEstadisticoFamilias.TabIndex = 29
        Me.grdReporteEstadisticoFamilias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvReporteEstadisticoFamilias})
        '
        'bgvReporteEstadisticoFamilias
        '
        Me.bgvReporteEstadisticoFamilias.GridControl = Me.grdReporteEstadisticoFamilias
        Me.bgvReporteEstadisticoFamilias.Name = "bgvReporteEstadisticoFamilias"
        Me.bgvReporteEstadisticoFamilias.OptionsBehavior.Editable = False
        Me.bgvReporteEstadisticoFamilias.OptionsCustomization.AllowColumnMoving = False
        Me.bgvReporteEstadisticoFamilias.OptionsCustomization.AllowFilter = False
        Me.bgvReporteEstadisticoFamilias.OptionsCustomization.AllowGroup = False
        Me.bgvReporteEstadisticoFamilias.OptionsCustomization.AllowSort = False
        Me.bgvReporteEstadisticoFamilias.OptionsMenu.EnableColumnMenu = False
        Me.bgvReporteEstadisticoFamilias.OptionsSelection.MultiSelect = True
        Me.bgvReporteEstadisticoFamilias.OptionsView.ColumnAutoWidth = False
        Me.bgvReporteEstadisticoFamilias.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvReporteEstadisticoFamilias.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvReporteEstadisticoFamilias.OptionsView.ShowDetailButtons = False
        Me.bgvReporteEstadisticoFamilias.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvReporteEstadisticoFamilias.OptionsView.ShowGroupPanel = False
        Me.bgvReporteEstadisticoFamilias.OptionsView.ShowIndicator = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.grpboxCrecimiento)
        Me.pnlPie.Controls.Add(Me.lblNumRegistros)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 549)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1276, 60)
        Me.pnlPie.TabIndex = 28
        '
        'grpboxCrecimiento
        '
        Me.grpboxCrecimiento.Controls.Add(Me.Label4)
        Me.grpboxCrecimiento.Controls.Add(Me.Label3)
        Me.grpboxCrecimiento.Location = New System.Drawing.Point(15, 3)
        Me.grpboxCrecimiento.Name = "grpboxCrecimiento"
        Me.grpboxCrecimiento.Size = New System.Drawing.Size(146, 54)
        Me.grpboxCrecimiento.TabIndex = 125
        Me.grpboxCrecimiento.TabStop = False
        Me.grpboxCrecimiento.Text = "% Crecimiento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(39, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "> 0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(39, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "<= 0"
        '
        'lblNumRegistros
        '
        Me.lblNumRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumRegistros.Location = New System.Drawing.Point(196, 33)
        Me.lblNumRegistros.Name = "lblNumRegistros"
        Me.lblNumRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblNumRegistros.TabIndex = 123
        Me.lblNumRegistros.Text = "0"
        Me.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNumRegistros.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(176, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 32)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "Registros"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label9.Visible = False
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(1016, 16)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 104
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(1004, 33)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 105
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1126, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(150, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(62, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(17, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(66, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(22, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
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
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.grpReportesNoEstadisticoFamilia)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.grpBoxAgente)
        Me.pnlParametros.Controls.Add(Me.GroupBox4)
        Me.pnlParametros.Controls.Add(Me.grpEstadisticaVentas)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1276, 206)
        Me.pnlParametros.TabIndex = 27
        '
        'grpReportesNoEstadisticoFamilia
        '
        Me.grpReportesNoEstadisticoFamilia.Controls.Add(Me.Label5)
        Me.grpReportesNoEstadisticoFamilia.Controls.Add(Me.dtpFechaInicioConsultas)
        Me.grpReportesNoEstadisticoFamilia.Controls.Add(Me.Label8)
        Me.grpReportesNoEstadisticoFamilia.Controls.Add(Me.dtpFechaFinConsultas)
        Me.grpReportesNoEstadisticoFamilia.Controls.Add(Me.Label10)
        Me.grpReportesNoEstadisticoFamilia.Location = New System.Drawing.Point(6, 81)
        Me.grpReportesNoEstadisticoFamilia.Name = "grpReportesNoEstadisticoFamilia"
        Me.grpReportesNoEstadisticoFamilia.Size = New System.Drawing.Size(392, 110)
        Me.grpReportesNoEstadisticoFamilia.TabIndex = 105
        Me.grpReportesNoEstadisticoFamilia.TabStop = False
        Me.grpReportesNoEstadisticoFamilia.Text = "Fecha de Facturación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(76, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(233, 13)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "El rango de fechas debe incluir al menos 2 años"
        '
        'dtpFechaInicioConsultas
        '
        Me.dtpFechaInicioConsultas.CustomFormat = ""
        Me.dtpFechaInicioConsultas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioConsultas.Location = New System.Drawing.Point(90, 38)
        Me.dtpFechaInicioConsultas.Name = "dtpFechaInicioConsultas"
        Me.dtpFechaInicioConsultas.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaInicioConsultas.TabIndex = 66
        Me.dtpFechaInicioConsultas.Value = New Date(2017, 8, 2, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(63, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Del"
        '
        'dtpFechaFinConsultas
        '
        Me.dtpFechaFinConsultas.CustomFormat = ""
        Me.dtpFechaFinConsultas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinConsultas.Location = New System.Drawing.Point(227, 38)
        Me.dtpFechaFinConsultas.Name = "dtpFechaFinConsultas"
        Me.dtpFechaFinConsultas.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaFinConsultas.TabIndex = 69
        Me.dtpFechaFinConsultas.Value = New Date(2017, 8, 2, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(202, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Al"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmboxTipoReporte)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 47)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reporte"
        '
        'cmboxTipoReporte
        '
        Me.cmboxTipoReporte.FormattingEnabled = True
        Me.cmboxTipoReporte.Items.AddRange(New Object() {"Estadística de Ventas por Familia", "Preventa (Anual y Por Marca)", "Preventa (Por Familia)"})
        Me.cmboxTipoReporte.Location = New System.Drawing.Point(10, 19)
        Me.cmboxTipoReporte.Name = "cmboxTipoReporte"
        Me.cmboxTipoReporte.Size = New System.Drawing.Size(376, 21)
        Me.cmboxTipoReporte.TabIndex = 92
        '
        'grpBoxAgente
        '
        Me.grpBoxAgente.Controls.Add(Me.Panel7)
        Me.grpBoxAgente.Controls.Add(Me.btnLimpiarFiltroAgente)
        Me.grpBoxAgente.Controls.Add(Me.btnAgente)
        Me.grpBoxAgente.Location = New System.Drawing.Point(871, 35)
        Me.grpBoxAgente.Name = "grpBoxAgente"
        Me.grpBoxAgente.Size = New System.Drawing.Size(238, 156)
        Me.grpBoxAgente.TabIndex = 103
        Me.grpBoxAgente.TabStop = False
        Me.grpBoxAgente.Text = "Agente"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdAgentes)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 37)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(232, 116)
        Me.Panel7.TabIndex = 2
        '
        'grdAgentes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Appearance = Appearance1
        Me.grdAgentes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAgentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAgentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAgentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdAgentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAgentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgentes.Location = New System.Drawing.Point(0, 0)
        Me.grdAgentes.Name = "grdAgentes"
        Me.grdAgentes.Size = New System.Drawing.Size(232, 116)
        Me.grdAgentes.TabIndex = 4
        '
        'btnLimpiarFiltroAgente
        '
        Me.btnLimpiarFiltroAgente.Image = CType(resources.GetObject("btnLimpiarFiltroAgente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroAgente.Location = New System.Drawing.Point(182, 11)
        Me.btnLimpiarFiltroAgente.Name = "btnLimpiarFiltroAgente"
        Me.btnLimpiarFiltroAgente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroAgente.TabIndex = 0
        Me.btnLimpiarFiltroAgente.UseVisualStyleBackColor = True
        '
        'btnAgente
        '
        Me.btnAgente.Image = CType(resources.GetObject("btnAgente.Image"), System.Drawing.Image)
        Me.btnAgente.Location = New System.Drawing.Point(210, 11)
        Me.btnAgente.Name = "btnAgente"
        Me.btnAgente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgente.TabIndex = 0
        Me.btnAgente.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.btnCliente)
        Me.GroupBox4.Location = New System.Drawing.Point(402, 35)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(463, 156)
        Me.GroupBox4.TabIndex = 102
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(407, 11)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 4
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdClientes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 116)
        Me.Panel1.TabIndex = 2
        '
        'grdClientes
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance3
        Me.grdClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(0, 0)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(457, 116)
        Me.grdClientes.TabIndex = 3
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(435, 11)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'grpEstadisticaVentas
        '
        Me.grpEstadisticaVentas.Controls.Add(Me.txtAñoComparacion)
        Me.grpEstadisticaVentas.Controls.Add(Me.Label6)
        Me.grpEstadisticaVentas.Controls.Add(Me.Label2)
        Me.grpEstadisticaVentas.Controls.Add(Me.dtpFechaEntregaDel)
        Me.grpEstadisticaVentas.Controls.Add(Me.lblEntregaDel)
        Me.grpEstadisticaVentas.Controls.Add(Me.dtpFechaEntregaAl)
        Me.grpEstadisticaVentas.Controls.Add(Me.lblEntregaAl)
        Me.grpEstadisticaVentas.Location = New System.Drawing.Point(6, 81)
        Me.grpEstadisticaVentas.Name = "grpEstadisticaVentas"
        Me.grpEstadisticaVentas.Size = New System.Drawing.Size(392, 110)
        Me.grpEstadisticaVentas.TabIndex = 99
        Me.grpEstadisticaVentas.TabStop = False
        Me.grpEstadisticaVentas.Text = "Fecha de Programación de Pedidos"
        '
        'txtAñoComparacion
        '
        Me.txtAñoComparacion.Enabled = False
        Me.txtAñoComparacion.Location = New System.Drawing.Point(179, 77)
        Me.txtAñoComparacion.Name = "txtAñoComparacion"
        Me.txtAñoComparacion.Size = New System.Drawing.Size(100, 20)
        Me.txtAñoComparacion.TabIndex = 107
        Me.txtAñoComparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(64, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 13)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Año de comparación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(277, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Las fechas de inicio y fin deben pertenecer al mismo año."
        '
        'dtpFechaEntregaDel
        '
        Me.dtpFechaEntregaDel.CustomFormat = ""
        Me.dtpFechaEntregaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntregaDel.Location = New System.Drawing.Point(90, 25)
        Me.dtpFechaEntregaDel.Name = "dtpFechaEntregaDel"
        Me.dtpFechaEntregaDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaEntregaDel.TabIndex = 66
        Me.dtpFechaEntregaDel.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(63, 29)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaEntregaAl
        '
        Me.dtpFechaEntregaAl.CustomFormat = ""
        Me.dtpFechaEntregaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntregaAl.Location = New System.Drawing.Point(227, 25)
        Me.dtpFechaEntregaAl.Name = "dtpFechaEntregaAl"
        Me.dtpFechaEntregaAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaEntregaAl.TabIndex = 69
        Me.dtpFechaEntregaAl.Value = New Date(2017, 6, 9, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(202, 29)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1276, 27)
        Me.Panel6.TabIndex = 46
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1216, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1242, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 59)
        Me.pnlEncabezado.TabIndex = 26
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.btnAyuda)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label1)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcel)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(699, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'btnAyuda
        '
        Me.btnAyuda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAyuda.Image = Global.Ventas.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAyuda.Location = New System.Drawing.Point(72, 7)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 53
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(70, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Ayuda"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
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
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(697, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(579, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(239, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(278, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Estadística de Ventas por Familia"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(509, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'EstadisticaVentasPorFamiliaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "EstadisticaVentasPorFamiliaForm"
        Me.Text = "Estadística de Ventas por Familia"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlConsultaAnualYMarca.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdConsultaAnual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvConsultaAnual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdConsultaMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvConsultaMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.chrConsultaAnual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.chrConsultaMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReporteEstadisticoFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvReporteEstadisticoFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.grpboxCrecimiento.ResumeLayout(False)
        Me.grpboxCrecimiento.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.grpReportesNoEstadisticoFamilia.ResumeLayout(False)
        Me.grpReportesNoEstadisticoFamilia.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.grpBoxAgente.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEstadisticaVentas.ResumeLayout(False)
        Me.grpEstadisticaVentas.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblActualizarDatos As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents grpEstadisticaVentas As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntregaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaDel As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntregaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaAl As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents grpboxCrecimiento As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumRegistros As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualización As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdReporteEstadisticoFamilias As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvReporteEstadisticoFamilias As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents txtAñoComparacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpBoxAgente As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents grdAgentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarFiltroAgente As System.Windows.Forms.Button
    Friend WithEvents btnAgente As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmboxTipoReporte As System.Windows.Forms.ComboBox
    Friend WithEvents grpReportesNoEstadisticoFamilia As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaInicioConsultas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinConsultas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlConsultaAnualYMarca As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdConsultaAnual As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvConsultaAnual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents grdConsultaMarca As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvConsultaMarca As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents chrConsultaMarca As DevExpress.XtraCharts.ChartControl
    Friend WithEvents chrConsultaAnual As DevExpress.XtraCharts.ChartControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents imgLogo As PictureBox
End Class
