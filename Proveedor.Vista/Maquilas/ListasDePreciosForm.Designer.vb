<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListasDePreciosForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListasDePreciosForm))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.grdListasPreciosCompra = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.cmbComercializadora = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.picEstado = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbColeccion = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkRechazada = New System.Windows.Forms.CheckBox()
        Me.chkVigente = New System.Windows.Forms.CheckBox()
        Me.chkAutorizada = New System.Windows.Forms.CheckBox()
        Me.chkCapturada = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdo2 = New System.Windows.Forms.RadioButton()
        Me.rdo1 = New System.Windows.Forms.RadioButton()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlEnviar = New System.Windows.Forms.Panel()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlRevertir = New System.Windows.Forms.Panel()
        Me.btnRevertir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlRechazar = New System.Windows.Forms.Panel()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlCopiar = New System.Windows.Forms.Panel()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlAlta = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlPrecioPorCapturar = New System.Windows.Forms.Panel()
        Me.pnlAutorizada = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCapturada = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlRechazada = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.tbtPrecios = New System.Windows.Forms.TabControl()
        Me.tbtPrecioCompra = New System.Windows.Forms.TabPage()
        Me.tbtPrecioVenta = New System.Windows.Forms.TabPage()
        Me.grdListasPreciosVenta = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdListaPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListayprecios = New System.Windows.Forms.Panel()
        Me.pnlListas = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        CType(Me.grdListasPreciosCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlEnviar.SuspendLayout()
        Me.pnlRevertir.SuspendLayout()
        Me.pnlRechazar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlCopiar.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAlta.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.tbtPrecios.SuspendLayout()
        Me.tbtPrecioCompra.SuspendLayout()
        Me.tbtPrecioVenta.SuspendLayout()
        CType(Me.grdListasPreciosVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListayprecios.SuspendLayout()
        Me.pnlListas.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdListasPreciosCompra
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasPreciosCompra.DisplayLayout.Appearance = Appearance1
        Me.grdListasPreciosCompra.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListasPreciosCompra.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListasPreciosCompra.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListasPreciosCompra.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListasPreciosCompra.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListasPreciosCompra.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListasPreciosCompra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasPreciosCompra.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListasPreciosCompra.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListasPreciosCompra.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListasPreciosCompra.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListasPreciosCompra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListasPreciosCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListasPreciosCompra.Location = New System.Drawing.Point(3, 3)
        Me.grdListasPreciosCompra.Name = "grdListasPreciosCompra"
        Me.grdListasPreciosCompra.Size = New System.Drawing.Size(1085, 204)
        Me.grdListasPreciosCompra.TabIndex = 67
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.chkSeleccionar)
        Me.grbParametros.Controls.Add(Me.cmbComercializadora)
        Me.grbParametros.Controls.Add(Me.Label16)
        Me.grbParametros.Controls.Add(Me.picEstado)
        Me.grbParametros.Controls.Add(Me.Button1)
        Me.grbParametros.Controls.Add(Me.Label4)
        Me.grbParametros.Controls.Add(Me.cmbColeccion)
        Me.grbParametros.Controls.Add(Me.Label12)
        Me.grbParametros.Controls.Add(Me.cmbMarca)
        Me.grbParametros.Controls.Add(Me.Label11)
        Me.grbParametros.Controls.Add(Me.chkRechazada)
        Me.grbParametros.Controls.Add(Me.chkVigente)
        Me.grbParametros.Controls.Add(Me.chkAutorizada)
        Me.grbParametros.Controls.Add(Me.chkCapturada)
        Me.grbParametros.Controls.Add(Me.Label3)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Controls.Add(Me.rdo2)
        Me.grbParametros.Controls.Add(Me.rdo1)
        Me.grbParametros.Controls.Add(Me.btnUp)
        Me.grbParametros.Controls.Add(Me.btnDown)
        Me.grbParametros.Controls.Add(Me.lblEstado)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 65)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1099, 99)
        Me.grbParametros.TabIndex = 66
        Me.grbParametros.TabStop = False
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(182, 11)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionar.TabIndex = 87
        Me.chkSeleccionar.Text = "Seleccionar Todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        Me.chkSeleccionar.Visible = False
        '
        'cmbComercializadora
        '
        Me.cmbComercializadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComercializadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComercializadora.FormattingEnabled = True
        Me.cmbComercializadora.Location = New System.Drawing.Point(101, 68)
        Me.cmbComercializadora.Name = "cmbComercializadora"
        Me.cmbComercializadora.Size = New System.Drawing.Size(194, 21)
        Me.cmbComercializadora.TabIndex = 86
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Comercializadora"
        '
        'picEstado
        '
        Me.picEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picEstado.BackColor = System.Drawing.Color.Transparent
        Me.picEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEstado.ErrorImage = Nothing
        Me.picEstado.Image = Global.Proveedor.Vista.My.Resources.Resources.loading1
        Me.picEstado.InitialImage = Nothing
        Me.picEstado.Location = New System.Drawing.Point(1032, 12)
        Me.picEstado.Name = "picEstado"
        Me.picEstado.Size = New System.Drawing.Size(15, 16)
        Me.picEstado.TabIndex = 83
        Me.picEstado.TabStop = False
        Me.picEstado.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.Button1.Location = New System.Drawing.Point(1060, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 70
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(1056, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Mostrar"
        '
        'cmbColeccion
        '
        Me.cmbColeccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbColeccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColeccion.Enabled = False
        Me.cmbColeccion.FormattingEnabled = True
        Me.cmbColeccion.Location = New System.Drawing.Point(365, 69)
        Me.cmbColeccion.Name = "cmbColeccion"
        Me.cmbColeccion.Size = New System.Drawing.Size(243, 21)
        Me.cmbColeccion.TabIndex = 82
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(305, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Colección"
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(365, 39)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(243, 21)
        Me.cmbMarca.TabIndex = 80
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(322, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Marca"
        '
        'chkRechazada
        '
        Me.chkRechazada.AutoSize = True
        Me.chkRechazada.Location = New System.Drawing.Point(848, 66)
        Me.chkRechazada.Name = "chkRechazada"
        Me.chkRechazada.Size = New System.Drawing.Size(81, 17)
        Me.chkRechazada.TabIndex = 78
        Me.chkRechazada.Text = "Rechazada"
        Me.chkRechazada.UseVisualStyleBackColor = True
        '
        'chkVigente
        '
        Me.chkVigente.AutoSize = True
        Me.chkVigente.Location = New System.Drawing.Point(934, 66)
        Me.chkVigente.Name = "chkVigente"
        Me.chkVigente.Size = New System.Drawing.Size(62, 17)
        Me.chkVigente.TabIndex = 77
        Me.chkVigente.Text = "Vigente"
        Me.chkVigente.UseVisualStyleBackColor = True
        '
        'chkAutorizada
        '
        Me.chkAutorizada.AutoSize = True
        Me.chkAutorizada.Location = New System.Drawing.Point(766, 66)
        Me.chkAutorizada.Name = "chkAutorizada"
        Me.chkAutorizada.Size = New System.Drawing.Size(76, 17)
        Me.chkAutorizada.TabIndex = 76
        Me.chkAutorizada.Text = "Autorizada"
        Me.chkAutorizada.UseVisualStyleBackColor = True
        '
        'chkCapturada
        '
        Me.chkCapturada.AutoSize = True
        Me.chkCapturada.Location = New System.Drawing.Point(685, 66)
        Me.chkCapturada.Name = "chkCapturada"
        Me.chkCapturada.Size = New System.Drawing.Size(75, 17)
        Me.chkCapturada.TabIndex = 75
        Me.chkCapturada.Text = "Capturada"
        Me.chkCapturada.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(637, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Estatus"
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(52, 39)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(243, 21)
        Me.cmbNave.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Nave"
        '
        'rdo2
        '
        Me.rdo2.AutoSize = True
        Me.rdo2.Location = New System.Drawing.Point(80, 11)
        Me.rdo2.Name = "rdo2"
        Me.rdo2.Size = New System.Drawing.Size(97, 17)
        Me.rdo2.TabIndex = 37
        Me.rdo2.Text = "Listas y precios"
        Me.rdo2.UseVisualStyleBackColor = True
        '
        'rdo1
        '
        Me.rdo1.AutoSize = True
        Me.rdo1.Checked = True
        Me.rdo1.Location = New System.Drawing.Point(12, 11)
        Me.rdo1.Name = "rdo1"
        Me.rdo1.Size = New System.Drawing.Size(52, 17)
        Me.rdo1.TabIndex = 36
        Me.rdo1.TabStop = True
        Me.rdo1.Text = "Listas"
        Me.rdo1.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.BackColor = System.Drawing.Color.White
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUp.Location = New System.Drawing.Point(1076, 8)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(20, 20)
        Me.btnUp.TabIndex = 35
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.BackColor = System.Drawing.Color.White
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(1053, 8)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 34
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(980, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(53, 12)
        Me.lblEstado.TabIndex = 84
        Me.lblEstado.Text = "Enviando..."
        Me.lblEstado.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlExportar)
        Me.pnlHeader.Controls.Add(Me.Button2)
        Me.pnlHeader.Controls.Add(Me.Label17)
        Me.pnlHeader.Controls.Add(Me.pnlEnviar)
        Me.pnlHeader.Controls.Add(Me.pnlRevertir)
        Me.pnlHeader.Controls.Add(Me.pnlRechazar)
        Me.pnlHeader.Controls.Add(Me.pnlAutorizar)
        Me.pnlHeader.Controls.Add(Me.pnlImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlCopiar)
        Me.pnlHeader.Controls.Add(Me.pnlEditar)
        Me.pnlHeader.Controls.Add(Me.pnlAlta)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1099, 65)
        Me.pnlHeader.TabIndex = 65
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.Label18)
        Me.pnlExportar.Location = New System.Drawing.Point(488, 2)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(68, 63)
        Me.pnlExportar.TabIndex = 84
        '
        'btnExportar
        '
        Me.btnExportar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(18, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 82
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label18.Location = New System.Drawing.Point(14, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Exportar"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(576, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 82
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(574, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "Ayuda"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEnviar
        '
        Me.pnlEnviar.Controls.Add(Me.btnEnviar)
        Me.pnlEnviar.Controls.Add(Me.Label5)
        Me.pnlEnviar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnviar.Location = New System.Drawing.Point(418, 0)
        Me.pnlEnviar.Name = "pnlEnviar"
        Me.pnlEnviar.Size = New System.Drawing.Size(68, 65)
        Me.pnlEnviar.TabIndex = 16
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEnviar.Location = New System.Drawing.Point(17, 2)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviar.TabIndex = 8
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(1, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 26)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Enviar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Autorización"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlRevertir
        '
        Me.pnlRevertir.Controls.Add(Me.btnRevertir)
        Me.pnlRevertir.Controls.Add(Me.Label8)
        Me.pnlRevertir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRevertir.Location = New System.Drawing.Point(348, 0)
        Me.pnlRevertir.Name = "pnlRevertir"
        Me.pnlRevertir.Size = New System.Drawing.Size(70, 65)
        Me.pnlRevertir.TabIndex = 15
        '
        'btnRevertir
        '
        Me.btnRevertir.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnRevertir.Image = Global.Proveedor.Vista.My.Resources.Resources.refresh_32
        Me.btnRevertir.Location = New System.Drawing.Point(19, 2)
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(32, 32)
        Me.btnRevertir.TabIndex = 74
        Me.ToolTip1.SetToolTip(Me.btnRevertir, "Selecciona las lista para revertir")
        Me.btnRevertir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(2, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 26)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Revertir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Autorización"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlRechazar
        '
        Me.pnlRechazar.Controls.Add(Me.btnRechazar)
        Me.pnlRechazar.Controls.Add(Me.Label9)
        Me.pnlRechazar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazar.Location = New System.Drawing.Point(290, 0)
        Me.pnlRechazar.Name = "pnlRechazar"
        Me.pnlRechazar.Size = New System.Drawing.Size(58, 65)
        Me.pnlRechazar.TabIndex = 14
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnRechazar.Image = Global.Proveedor.Vista.My.Resources.Resources.rechazar_32
        Me.btnRechazar.Location = New System.Drawing.Point(13, 2)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.btnRechazar, "Selecciona las lista a rechazar")
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(3, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Rechazar"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.Label6)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(232, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(58, 65)
        Me.pnlAutorizar.TabIndex = 13
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.autorizar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(13, 2)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnAutorizar, "Selecciona las lista a autorizar")
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(5, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Autorizar"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.Label14)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(174, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(58, 65)
        Me.pnlImprimir.TabIndex = 12
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(13, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 78
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir las listas de precios seleccionadas")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(8, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Imprimir"
        '
        'pnlCopiar
        '
        Me.pnlCopiar.Controls.Add(Me.btnCopiar)
        Me.pnlCopiar.Controls.Add(Me.Label13)
        Me.pnlCopiar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCopiar.Location = New System.Drawing.Point(116, 0)
        Me.pnlCopiar.Name = "pnlCopiar"
        Me.pnlCopiar.Size = New System.Drawing.Size(58, 65)
        Me.pnlCopiar.TabIndex = 11
        '
        'btnCopiar
        '
        Me.btnCopiar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnCopiar.Image = Global.Proveedor.Vista.My.Resources.Resources.copiar_32
        Me.btnCopiar.Location = New System.Drawing.Point(13, 2)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiar.TabIndex = 72
        Me.ToolTip1.SetToolTip(Me.btnCopiar, "Selecciona la lista a copiar en la tabla")
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(11, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 26)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Copiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lista"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(58, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(58, 65)
        Me.pnlEditar.TabIndex = 10
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(13, 2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 68
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(12, 35)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 66
        Me.lblEditar.Text = "Editar"
        '
        'pnlAlta
        '
        Me.pnlAlta.Controls.Add(Me.btnNuevo)
        Me.pnlAlta.Controls.Add(Me.lblNuevo)
        Me.pnlAlta.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlta.Name = "pnlAlta"
        Me.pnlAlta.Size = New System.Drawing.Size(58, 65)
        Me.pnlAlta.TabIndex = 9
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(13, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 67
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(13, 35)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 65
        Me.lblNuevo.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(692, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(407, 65)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(20, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(312, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Listas de Precios Producto Terminado"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label15)
        Me.pnlPie.Controls.Add(Me.pnlPrecioPorCapturar)
        Me.pnlPie.Controls.Add(Me.pnlAutorizada)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.pnlCapturada)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlRechazada)
        Me.pnlPie.Controls.Add(Me.Label10)
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 400)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1099, 60)
        Me.pnlPie.TabIndex = 64
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(288, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Precios por Capturar"
        '
        'pnlPrecioPorCapturar
        '
        Me.pnlPrecioPorCapturar.BackColor = System.Drawing.Color.Crimson
        Me.pnlPrecioPorCapturar.Location = New System.Drawing.Point(271, 24)
        Me.pnlPrecioPorCapturar.Name = "pnlPrecioPorCapturar"
        Me.pnlPrecioPorCapturar.Size = New System.Drawing.Size(15, 15)
        Me.pnlPrecioPorCapturar.TabIndex = 42
        '
        'pnlAutorizada
        '
        Me.pnlAutorizada.BackColor = System.Drawing.Color.GreenYellow
        Me.pnlAutorizada.Location = New System.Drawing.Point(99, 25)
        Me.pnlAutorizada.Name = "pnlAutorizada"
        Me.pnlAutorizada.Size = New System.Drawing.Size(15, 15)
        Me.pnlAutorizada.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Autorizada"
        '
        'pnlCapturada
        '
        Me.pnlCapturada.BackColor = System.Drawing.Color.Yellow
        Me.pnlCapturada.Location = New System.Drawing.Point(12, 25)
        Me.pnlCapturada.Name = "pnlCapturada"
        Me.pnlCapturada.Size = New System.Drawing.Size(15, 15)
        Me.pnlCapturada.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Capturada"
        '
        'pnlRechazada
        '
        Me.pnlRechazada.BackColor = System.Drawing.Color.Salmon
        Me.pnlRechazada.Location = New System.Drawing.Point(180, 25)
        Me.pnlRechazada.Name = "pnlRechazada"
        Me.pnlRechazada.Size = New System.Drawing.Size(15, 15)
        Me.pnlRechazada.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(196, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Rechazada"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(864, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(235, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'tbtPrecios
        '
        Me.tbtPrecios.Controls.Add(Me.tbtPrecioCompra)
        Me.tbtPrecios.Controls.Add(Me.tbtPrecioVenta)
        Me.tbtPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtPrecios.Location = New System.Drawing.Point(0, 0)
        Me.tbtPrecios.Name = "tbtPrecios"
        Me.tbtPrecios.SelectedIndex = 0
        Me.tbtPrecios.Size = New System.Drawing.Size(1099, 236)
        Me.tbtPrecios.TabIndex = 68
        '
        'tbtPrecioCompra
        '
        Me.tbtPrecioCompra.Controls.Add(Me.grdListasPreciosCompra)
        Me.tbtPrecioCompra.Location = New System.Drawing.Point(4, 22)
        Me.tbtPrecioCompra.Name = "tbtPrecioCompra"
        Me.tbtPrecioCompra.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtPrecioCompra.Size = New System.Drawing.Size(1091, 210)
        Me.tbtPrecioCompra.TabIndex = 0
        Me.tbtPrecioCompra.Text = "Compra"
        Me.tbtPrecioCompra.UseVisualStyleBackColor = True
        '
        'tbtPrecioVenta
        '
        Me.tbtPrecioVenta.Controls.Add(Me.grdListasPreciosVenta)
        Me.tbtPrecioVenta.Location = New System.Drawing.Point(4, 22)
        Me.tbtPrecioVenta.Name = "tbtPrecioVenta"
        Me.tbtPrecioVenta.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtPrecioVenta.Size = New System.Drawing.Size(1091, 198)
        Me.tbtPrecioVenta.TabIndex = 1
        Me.tbtPrecioVenta.Text = "Venta"
        Me.tbtPrecioVenta.UseVisualStyleBackColor = True
        '
        'grdListasPreciosVenta
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasPreciosVenta.DisplayLayout.Appearance = Appearance4
        Me.grdListasPreciosVenta.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListasPreciosVenta.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListasPreciosVenta.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListasPreciosVenta.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListasPreciosVenta.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListasPreciosVenta.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListasPreciosVenta.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasPreciosVenta.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListasPreciosVenta.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdListasPreciosVenta.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListasPreciosVenta.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListasPreciosVenta.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListasPreciosVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListasPreciosVenta.Location = New System.Drawing.Point(3, 3)
        Me.grdListasPreciosVenta.Name = "grdListasPreciosVenta"
        Me.grdListasPreciosVenta.Size = New System.Drawing.Size(1085, 192)
        Me.grdListasPreciosVenta.TabIndex = 68
        '
        'grdListaPrecios
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPrecios.DisplayLayout.Appearance = Appearance7
        Me.grdListaPrecios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaPrecios.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaPrecios.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaPrecios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaPrecios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaPrecios.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListaPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPrecios.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaPrecios.DisplayLayout.Override.RowAppearance = Appearance9
        Me.grdListaPrecios.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaPrecios.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaPrecios.Location = New System.Drawing.Point(0, 0)
        Me.grdListaPrecios.Name = "grdListaPrecios"
        Me.grdListaPrecios.Size = New System.Drawing.Size(1099, 236)
        Me.grdListaPrecios.TabIndex = 70
        '
        'pnlListayprecios
        '
        Me.pnlListayprecios.Controls.Add(Me.tbtPrecios)
        Me.pnlListayprecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListayprecios.Location = New System.Drawing.Point(0, 164)
        Me.pnlListayprecios.Name = "pnlListayprecios"
        Me.pnlListayprecios.Size = New System.Drawing.Size(1099, 236)
        Me.pnlListayprecios.TabIndex = 69
        '
        'pnlListas
        '
        Me.pnlListas.Controls.Add(Me.grdListaPrecios)
        Me.pnlListas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListas.Location = New System.Drawing.Point(0, 164)
        Me.pnlListas.Name = "pnlListas"
        Me.pnlListas.Size = New System.Drawing.Size(1099, 236)
        Me.pnlListas.TabIndex = 70
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(339, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'ListasDePreciosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1099, 460)
        Me.Controls.Add(Me.pnlListas)
        Me.Controls.Add(Me.pnlListayprecios)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.MinimumSize = New System.Drawing.Size(899, 487)
        Me.Name = "ListasDePreciosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listas de Precios Producto Terminado"
        CType(Me.grdListasPreciosCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.picEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlEnviar.ResumeLayout(False)
        Me.pnlEnviar.PerformLayout()
        Me.pnlRevertir.ResumeLayout(False)
        Me.pnlRevertir.PerformLayout()
        Me.pnlRechazar.ResumeLayout(False)
        Me.pnlRechazar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlCopiar.ResumeLayout(False)
        Me.pnlCopiar.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAlta.ResumeLayout(False)
        Me.pnlAlta.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.tbtPrecios.ResumeLayout(False)
        Me.tbtPrecioCompra.ResumeLayout(False)
        Me.tbtPrecioVenta.ResumeLayout(False)
        CType(Me.grdListasPreciosVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListayprecios.ResumeLayout(False)
        Me.pnlListas.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdListasPreciosCompra As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents rdo2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkRechazada As System.Windows.Forms.CheckBox
    Friend WithEvents chkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizada As System.Windows.Forms.CheckBox
    Friend WithEvents chkCapturada As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbColeccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents btnRevertir As System.Windows.Forms.Button
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents picEstado As System.Windows.Forms.PictureBox
    Public WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Public WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents pnlAutorizada As System.Windows.Forms.Panel
    Friend WithEvents pnlCapturada As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlRechazada As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlPrecioPorCapturar As System.Windows.Forms.Panel
    Friend WithEvents pnlCopiar As Windows.Forms.Panel
    Friend WithEvents pnlEditar As Windows.Forms.Panel
    Friend WithEvents pnlAlta As Windows.Forms.Panel
    Friend WithEvents pnlEnviar As Windows.Forms.Panel
    Friend WithEvents pnlRevertir As Windows.Forms.Panel
    Friend WithEvents pnlRechazar As Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As Windows.Forms.Panel
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents cmbComercializadora As Windows.Forms.ComboBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents tbtPrecios As Windows.Forms.TabControl
    Friend WithEvents tbtPrecioCompra As Windows.Forms.TabPage
    Friend WithEvents tbtPrecioVenta As Windows.Forms.TabPage
    Friend WithEvents grdListasPreciosVenta As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdListaPrecios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListayprecios As Windows.Forms.Panel
    Friend WithEvents pnlListas As Windows.Forms.Panel
    Public WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Public WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents chkSeleccionar As Windows.Forms.CheckBox
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
