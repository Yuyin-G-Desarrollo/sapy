<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaProspectaPorMarca
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaProspectaPorMarca))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.grdTotales = New DevExpress.XtraGrid.GridControl()
        Me.bgvTotales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUCMarcas = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudNumSemana = New System.Windows.Forms.NumericUpDown()
        Me.txtStatusProspecta = New System.Windows.Forms.TextBox()
        Me.dtmFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtmFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdProspectaPorMarca = New DevExpress.XtraGrid.GridControl()
        Me.bgvProspectaPorMarca = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        CType(Me.grdTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbUCMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdProspectaPorMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvProspectaPorMarca, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1113, 59)
        Me.pnlHeader.TabIndex = 15
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitulo)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(666, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(447, 59)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(195, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(176, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Prospecta Por Marca"
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
        Me.pnlBtn.Controls.Add(Me.Panel4)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(668, 59)
        Me.pnlBtn.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnExportar)
        Me.Panel4.Controls.Add(Me.lblExportar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(54, 59)
        Me.Panel4.TabIndex = 57
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(11, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 55
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(4, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 56
        Me.lblExportar.Text = "Exportar"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel3)
        Me.pnlFiltros.Controls.Add(Me.pnlTotales)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 59)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1113, 145)
        Me.pnlFiltros.TabIndex = 17
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1113, 24)
        Me.Panel3.TabIndex = 106
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1061, 1)
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
        Me.btnAbajo.Location = New System.Drawing.Point(1087, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 92
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlTotales
        '
        Me.pnlTotales.Controls.Add(Me.grdTotales)
        Me.pnlTotales.Location = New System.Drawing.Point(440, 28)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(663, 106)
        Me.pnlTotales.TabIndex = 18
        '
        'grdTotales
        '
        Me.grdTotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTotales.Location = New System.Drawing.Point(0, 0)
        Me.grdTotales.MainView = Me.bgvTotales
        Me.grdTotales.Name = "grdTotales"
        Me.grdTotales.Size = New System.Drawing.Size(663, 106)
        Me.grdTotales.TabIndex = 0
        Me.grdTotales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvTotales})
        '
        'bgvTotales
        '
        Me.bgvTotales.GridControl = Me.grdTotales
        Me.bgvTotales.Name = "bgvTotales"
        Me.bgvTotales.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvTotales.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvTotales.OptionsView.ShowFooter = True
        Me.bgvTotales.OptionsView.ShowGroupPanel = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbUCMarcas)
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Controls.Add(Me.nudNumSemana)
        Me.GroupBox1.Controls.Add(Me.txtStatusProspecta)
        Me.GroupBox1.Controls.Add(Me.dtmFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtmFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 112)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de la Prospecta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Marcas:"
        '
        'cmbUCMarcas
        '
        Me.cmbUCMarcas.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbUCMarcas.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbUCMarcas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbUCMarcas.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbUCMarcas.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbUCMarcas.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbUCMarcas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista
        Me.cmbUCMarcas.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbUCMarcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCMarcas.Location = New System.Drawing.Point(58, 80)
        Me.cmbUCMarcas.Name = "cmbUCMarcas"
        Me.cmbUCMarcas.Size = New System.Drawing.Size(365, 21)
        Me.cmbUCMarcas.TabIndex = 78
        '
        'nudAño
        '
        Me.nudAño.Enabled = False
        Me.nudAño.Location = New System.Drawing.Point(119, 26)
        Me.nudAño.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2017, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(54, 20)
        Me.nudAño.TabIndex = 77
        Me.nudAño.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'nudNumSemana
        '
        Me.nudNumSemana.Enabled = False
        Me.nudNumSemana.Location = New System.Drawing.Point(58, 26)
        Me.nudNumSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSemana.Name = "nudNumSemana"
        Me.nudNumSemana.Size = New System.Drawing.Size(45, 20)
        Me.nudNumSemana.TabIndex = 77
        Me.nudNumSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtStatusProspecta
        '
        Me.txtStatusProspecta.Enabled = False
        Me.txtStatusProspecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusProspecta.ForeColor = System.Drawing.Color.Black
        Me.txtStatusProspecta.Location = New System.Drawing.Point(58, 54)
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
        Me.dtmFechaFin.Location = New System.Drawing.Point(331, 25)
        Me.dtmFechaFin.Name = "dtmFechaFin"
        Me.dtmFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtmFechaFin.TabIndex = 40
        Me.dtmFechaFin.Value = New Date(2016, 11, 19, 0, 0, 0, 0)
        '
        'dtmFechaInicio
        '
        Me.dtmFechaInicio.Enabled = False
        Me.dtmFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicio.Location = New System.Drawing.Point(217, 25)
        Me.dtmFechaInicio.Name = "dtmFechaInicio"
        Me.dtmFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtmFechaInicio.TabIndex = 39
        Me.dtmFechaInicio.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(187, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Del"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Semana"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(311, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Al"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Status"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlSalir)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 475)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1113, 61)
        Me.pnlPie.TabIndex = 18
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(850, 29)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 127
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(856, 14)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 128
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(7, 29)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 126
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Registros"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.Label4)
        Me.pnlSalir.Controls.Add(Me.btnMostrar)
        Me.pnlSalir.Controls.Add(Me.Label3)
        Me.pnlSalir.Controls.Add(Me.btnCerrar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(1010, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(103, 61)
        Me.pnlSalir.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(11, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 54
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(59, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(61, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 52
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdProspectaPorMarca)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 204)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1113, 271)
        Me.Panel1.TabIndex = 19
        '
        'grdProspectaPorMarca
        '
        Me.grdProspectaPorMarca.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdProspectaPorMarca.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdProspectaPorMarca.Location = New System.Drawing.Point(0, 0)
        Me.grdProspectaPorMarca.MainView = Me.bgvProspectaPorMarca
        Me.grdProspectaPorMarca.Name = "grdProspectaPorMarca"
        Me.grdProspectaPorMarca.Size = New System.Drawing.Size(1113, 271)
        Me.grdProspectaPorMarca.TabIndex = 0
        Me.grdProspectaPorMarca.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvProspectaPorMarca})
        '
        'bgvProspectaPorMarca
        '
        Me.bgvProspectaPorMarca.GridControl = Me.grdProspectaPorMarca
        Me.bgvProspectaPorMarca.Name = "bgvProspectaPorMarca"
        Me.bgvProspectaPorMarca.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvProspectaPorMarca.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvProspectaPorMarca.OptionsView.ShowAutoFilterRow = True
        Me.bgvProspectaPorMarca.OptionsView.ShowFooter = True
        '
        'ConsultaProspectaPorMarca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 536)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConsultaProspectaPorMarca"
        Me.Text = "Consulta Prospecta Por Marca"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlTotales.ResumeLayout(False)
        CType(Me.grdTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbUCMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdProspectaPorMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvProspectaPorMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitle As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents imgLogo As PictureBox
    Friend WithEvents pnlBtn As Panel
    Friend WithEvents lblExportar As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlTotales As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents nudNumSemana As NumericUpDown
    Friend WithEvents txtStatusProspecta As TextBox
    Friend WithEvents dtmFechaFin As DateTimePicker
    Friend WithEvents dtmFechaInicio As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblFechaUltimaActualizacion As Label
    Friend WithEvents lblTextoUltimaDistribucion As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlSalir As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdProspectaPorMarca As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvProspectaPorMarca As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbUCMarcas As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdTotales As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvTotales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnMostrar As Button
End Class
