<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comprobantesFiscalesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(comprobantesFiscalesForm))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBotonesAlto = New System.Windows.Forms.Panel()
        Me.gboxClienteProveedor = New System.Windows.Forms.GroupBox()
        Me.btnClienteProveedor = New System.Windows.Forms.Button()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.grdClienteProveedor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxConsultar = New Infragistics.Win.Misc.UltraGroupBox()
        Me.rdoComprobantesYPolizas = New System.Windows.Forms.RadioButton()
        Me.rdoSoloComprobantes = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolioPoliza = New System.Windows.Forms.Label()
        Me.rdoFolioAproximado = New System.Windows.Forms.RadioButton()
        Me.rdoFolioExacto = New System.Windows.Forms.RadioButton()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.gboxLugar = New Infragistics.Win.Misc.UltraGroupBox()
        Me.rdoSinContabilizar = New System.Windows.Forms.RadioButton()
        Me.rdoDentrodePoliza = New System.Windows.Forms.RadioButton()
        Me.cmbTipoPoliza = New System.Windows.Forms.ComboBox()
        Me.lblTipoPoliza = New System.Windows.Forms.Label()
        Me.gboxFechas = New Infragistics.Win.Misc.UltraGroupBox()
        Me.pnlFiltrosFecha = New System.Windows.Forms.Panel()
        Me.rdoFechaPoliza = New System.Windows.Forms.RadioButton()
        Me.rdoFechaComprobante = New System.Windows.Forms.RadioButton()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.dtpDe = New System.Windows.Forms.DateTimePicker()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbTIpoComprobante = New System.Windows.Forms.ComboBox()
        Me.pnlBotonesVisibles = New System.Windows.Forms.Panel()
        Me.pnlBotonesPanelAccion = New System.Windows.Forms.Panel()
        Me.lbllimpiar = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblRelacionarXML = New System.Windows.Forms.Label()
        Me.lblRelacionarPDF = New System.Windows.Forms.Label()
        Me.btnRelacionarPDF = New System.Windows.Forms.Button()
        Me.btnRelacionarXml = New System.Windows.Forms.Button()
        Me.btnAbrirXML = New System.Windows.Forms.Button()
        Me.lblCopiarA = New System.Windows.Forms.Label()
        Me.btnCopiarA = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblPDF = New System.Windows.Forms.Label()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.lblVerXml = New System.Windows.Forms.Label()
        Me.pnlImg = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.gboxCodigoColores = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPDFAgregado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAgregado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSinXML = New System.Windows.Forms.Label()
        Me.lblSinXMLTexto = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.grdComprobantesFiscales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ofdComprobantesFiscales = New System.Windows.Forms.OpenFileDialog()
        Me.pnlBotonesAlto.SuspendLayout()
        Me.gboxClienteProveedor.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.grdClienteProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gboxConsultar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxConsultar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gboxLugar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxLugar.SuspendLayout()
        CType(Me.gboxFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFechas.SuspendLayout()
        Me.pnlFiltrosFecha.SuspendLayout()
        Me.pnlBotonesVisibles.SuspendLayout()
        Me.pnlBotonesPanelAccion.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlImg.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.gboxCodigoColores.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBotonesAlto
        '
        Me.pnlBotonesAlto.Controls.Add(Me.gboxClienteProveedor)
        Me.pnlBotonesAlto.Controls.Add(Me.gboxConsultar)
        Me.pnlBotonesAlto.Controls.Add(Me.Panel1)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbNaves)
        Me.pnlBotonesAlto.Controls.Add(Me.gboxLugar)
        Me.pnlBotonesAlto.Controls.Add(Me.gboxFechas)
        Me.pnlBotonesAlto.Controls.Add(Me.lblNave)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbTIpoComprobante)
        Me.pnlBotonesAlto.Controls.Add(Me.pnlBotonesVisibles)
        Me.pnlBotonesAlto.Controls.Add(Me.lblEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.lblTipoComprobante)
        Me.pnlBotonesAlto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBotonesAlto.Location = New System.Drawing.Point(0, 60)
        Me.pnlBotonesAlto.Name = "pnlBotonesAlto"
        Me.pnlBotonesAlto.Size = New System.Drawing.Size(1020, 204)
        Me.pnlBotonesAlto.TabIndex = 21
        '
        'gboxClienteProveedor
        '
        Me.gboxClienteProveedor.Controls.Add(Me.btnClienteProveedor)
        Me.gboxClienteProveedor.Controls.Add(Me.Panel17)
        Me.gboxClienteProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxClienteProveedor.Location = New System.Drawing.Point(15, 98)
        Me.gboxClienteProveedor.Name = "gboxClienteProveedor"
        Me.gboxClienteProveedor.Size = New System.Drawing.Size(385, 103)
        Me.gboxClienteProveedor.TabIndex = 38
        Me.gboxClienteProveedor.TabStop = False
        Me.gboxClienteProveedor.Text = "Proveedores"
        '
        'btnClienteProveedor
        '
        Me.btnClienteProveedor.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnClienteProveedor.Location = New System.Drawing.Point(357, 8)
        Me.btnClienteProveedor.Name = "btnClienteProveedor"
        Me.btnClienteProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnClienteProveedor.TabIndex = 4
        Me.btnClienteProveedor.UseVisualStyleBackColor = True
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.grdClienteProveedor)
        Me.Panel17.Location = New System.Drawing.Point(5, 31)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(374, 69)
        Me.Panel17.TabIndex = 2
        '
        'grdClienteProveedor
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClienteProveedor.DisplayLayout.Appearance = Appearance1
        Me.grdClienteProveedor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClienteProveedor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClienteProveedor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClienteProveedor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClienteProveedor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClienteProveedor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClienteProveedor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClienteProveedor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClienteProveedor.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClienteProveedor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClienteProveedor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClienteProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClienteProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdClienteProveedor.Location = New System.Drawing.Point(0, 0)
        Me.grdClienteProveedor.Name = "grdClienteProveedor"
        Me.grdClienteProveedor.Size = New System.Drawing.Size(374, 69)
        Me.grdClienteProveedor.TabIndex = 17
        '
        'gboxConsultar
        '
        Me.gboxConsultar.Controls.Add(Me.rdoComprobantesYPolizas)
        Me.gboxConsultar.Controls.Add(Me.rdoSoloComprobantes)
        Me.gboxConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxConsultar.Location = New System.Drawing.Point(671, 28)
        Me.gboxConsultar.Name = "gboxConsultar"
        Me.gboxConsultar.Size = New System.Drawing.Size(262, 61)
        Me.gboxConsultar.TabIndex = 37
        Me.gboxConsultar.Text = "Consultar"
        '
        'rdoComprobantesYPolizas
        '
        Me.rdoComprobantesYPolizas.AutoSize = True
        Me.rdoComprobantesYPolizas.Checked = True
        Me.rdoComprobantesYPolizas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoComprobantesYPolizas.Location = New System.Drawing.Point(8, 17)
        Me.rdoComprobantesYPolizas.Name = "rdoComprobantesYPolizas"
        Me.rdoComprobantesYPolizas.Size = New System.Drawing.Size(137, 17)
        Me.rdoComprobantesYPolizas.TabIndex = 14
        Me.rdoComprobantesYPolizas.TabStop = True
        Me.rdoComprobantesYPolizas.Text = "Comprobantes y Pólizas"
        Me.rdoComprobantesYPolizas.UseVisualStyleBackColor = True
        '
        'rdoSoloComprobantes
        '
        Me.rdoSoloComprobantes.AutoSize = True
        Me.rdoSoloComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSoloComprobantes.Location = New System.Drawing.Point(8, 37)
        Me.rdoSoloComprobantes.Name = "rdoSoloComprobantes"
        Me.rdoSoloComprobantes.Size = New System.Drawing.Size(117, 17)
        Me.rdoSoloComprobantes.TabIndex = 13
        Me.rdoSoloComprobantes.Text = "Solo Comprobantes"
        Me.rdoSoloComprobantes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtFolio)
        Me.Panel1.Controls.Add(Me.lblFolioPoliza)
        Me.Panel1.Controls.Add(Me.rdoFolioAproximado)
        Me.Panel1.Controls.Add(Me.rdoFolioExacto)
        Me.Panel1.Location = New System.Drawing.Point(406, 145)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 56)
        Me.Panel1.TabIndex = 31
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(35, 23)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(214, 20)
        Me.txtFolio.TabIndex = 17
        '
        'lblFolioPoliza
        '
        Me.lblFolioPoliza.AutoSize = True
        Me.lblFolioPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioPoliza.Location = New System.Drawing.Point(6, 26)
        Me.lblFolioPoliza.Name = "lblFolioPoliza"
        Me.lblFolioPoliza.Size = New System.Drawing.Size(32, 13)
        Me.lblFolioPoliza.TabIndex = 25
        Me.lblFolioPoliza.Text = "Folio:"
        '
        'rdoFolioAproximado
        '
        Me.rdoFolioAproximado.AutoSize = True
        Me.rdoFolioAproximado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFolioAproximado.Location = New System.Drawing.Point(148, 2)
        Me.rdoFolioAproximado.Name = "rdoFolioAproximado"
        Me.rdoFolioAproximado.Size = New System.Drawing.Size(105, 17)
        Me.rdoFolioAproximado.TabIndex = 15
        Me.rdoFolioAproximado.Text = "Folio Aproximado"
        Me.rdoFolioAproximado.UseVisualStyleBackColor = True
        '
        'rdoFolioExacto
        '
        Me.rdoFolioExacto.AutoSize = True
        Me.rdoFolioExacto.Checked = True
        Me.rdoFolioExacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFolioExacto.Location = New System.Drawing.Point(38, 1)
        Me.rdoFolioExacto.Name = "rdoFolioExacto"
        Me.rdoFolioExacto.Size = New System.Drawing.Size(83, 17)
        Me.rdoFolioExacto.TabIndex = 14
        Me.rdoFolioExacto.TabStop = True
        Me.rdoFolioExacto.Text = "Folio Exacto"
        Me.rdoFolioExacto.UseVisualStyleBackColor = True
        '
        'cmbNaves
        '
        Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(754, 168)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(173, 21)
        Me.cmbNaves.TabIndex = 37
        '
        'gboxLugar
        '
        Me.gboxLugar.Controls.Add(Me.rdoSinContabilizar)
        Me.gboxLugar.Controls.Add(Me.rdoDentrodePoliza)
        Me.gboxLugar.Controls.Add(Me.cmbTipoPoliza)
        Me.gboxLugar.Controls.Add(Me.lblTipoPoliza)
        Me.gboxLugar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxLugar.Location = New System.Drawing.Point(671, 95)
        Me.gboxLugar.Name = "gboxLugar"
        Me.gboxLugar.Size = New System.Drawing.Size(262, 68)
        Me.gboxLugar.TabIndex = 36
        Me.gboxLugar.Text = "Ubicación del Comprobante"
        '
        'rdoSinContabilizar
        '
        Me.rdoSinContabilizar.AutoSize = True
        Me.rdoSinContabilizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSinContabilizar.Location = New System.Drawing.Point(117, 19)
        Me.rdoSinContabilizar.Name = "rdoSinContabilizar"
        Me.rdoSinContabilizar.Size = New System.Drawing.Size(97, 17)
        Me.rdoSinContabilizar.TabIndex = 25
        Me.rdoSinContabilizar.Text = "Sin Contabilizar"
        Me.rdoSinContabilizar.UseVisualStyleBackColor = True
        '
        'rdoDentrodePoliza
        '
        Me.rdoDentrodePoliza.AutoSize = True
        Me.rdoDentrodePoliza.Checked = True
        Me.rdoDentrodePoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoDentrodePoliza.Location = New System.Drawing.Point(8, 19)
        Me.rdoDentrodePoliza.Name = "rdoDentrodePoliza"
        Me.rdoDentrodePoliza.Size = New System.Drawing.Size(103, 17)
        Me.rdoDentrodePoliza.TabIndex = 24
        Me.rdoDentrodePoliza.TabStop = True
        Me.rdoDentrodePoliza.Text = "Dentro de Póliza"
        Me.rdoDentrodePoliza.UseVisualStyleBackColor = True
        '
        'cmbTipoPoliza
        '
        Me.cmbTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPoliza.FormattingEnabled = True
        Me.cmbTipoPoliza.Location = New System.Drawing.Point(83, 39)
        Me.cmbTipoPoliza.Name = "cmbTipoPoliza"
        Me.cmbTipoPoliza.Size = New System.Drawing.Size(173, 21)
        Me.cmbTipoPoliza.TabIndex = 26
        '
        'lblTipoPoliza
        '
        Me.lblTipoPoliza.AutoSize = True
        Me.lblTipoPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPoliza.Location = New System.Drawing.Point(5, 42)
        Me.lblTipoPoliza.Name = "lblTipoPoliza"
        Me.lblTipoPoliza.Size = New System.Drawing.Size(80, 13)
        Me.lblTipoPoliza.TabIndex = 27
        Me.lblTipoPoliza.Text = "*Tipo de póliza:"
        '
        'gboxFechas
        '
        Me.gboxFechas.Controls.Add(Me.pnlFiltrosFecha)
        Me.gboxFechas.Controls.Add(Me.lblDe)
        Me.gboxFechas.Controls.Add(Me.lblAl)
        Me.gboxFechas.Controls.Add(Me.dtpDe)
        Me.gboxFechas.Controls.Add(Me.dtpAl)
        Me.gboxFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxFechas.Location = New System.Drawing.Point(406, 28)
        Me.gboxFechas.Name = "gboxFechas"
        Me.gboxFechas.Size = New System.Drawing.Size(259, 114)
        Me.gboxFechas.TabIndex = 35
        Me.gboxFechas.Text = "Fechas"
        '
        'pnlFiltrosFecha
        '
        Me.pnlFiltrosFecha.Controls.Add(Me.rdoFechaPoliza)
        Me.pnlFiltrosFecha.Controls.Add(Me.rdoFechaComprobante)
        Me.pnlFiltrosFecha.Location = New System.Drawing.Point(11, 14)
        Me.pnlFiltrosFecha.Name = "pnlFiltrosFecha"
        Me.pnlFiltrosFecha.Size = New System.Drawing.Size(240, 42)
        Me.pnlFiltrosFecha.TabIndex = 29
        '
        'rdoFechaPoliza
        '
        Me.rdoFechaPoliza.AutoSize = True
        Me.rdoFechaPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFechaPoliza.Location = New System.Drawing.Point(3, 23)
        Me.rdoFechaPoliza.Name = "rdoFechaPoliza"
        Me.rdoFechaPoliza.Size = New System.Drawing.Size(86, 17)
        Me.rdoFechaPoliza.TabIndex = 11
        Me.rdoFechaPoliza.Text = "Fecha Póliza"
        Me.rdoFechaPoliza.UseVisualStyleBackColor = True
        '
        'rdoFechaComprobante
        '
        Me.rdoFechaComprobante.AutoSize = True
        Me.rdoFechaComprobante.Checked = True
        Me.rdoFechaComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFechaComprobante.Location = New System.Drawing.Point(3, 3)
        Me.rdoFechaComprobante.Name = "rdoFechaComprobante"
        Me.rdoFechaComprobante.Size = New System.Drawing.Size(121, 17)
        Me.rdoFechaComprobante.TabIndex = 10
        Me.rdoFechaComprobante.TabStop = True
        Me.rdoFechaComprobante.Text = "Fecha Comprobante"
        Me.rdoFechaComprobante.UseVisualStyleBackColor = True
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDe.Location = New System.Drawing.Point(6, 61)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(26, 13)
        Me.lblDe.TabIndex = 11
        Me.lblDe.Text = "Del:"
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAl.Location = New System.Drawing.Point(6, 89)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 12
        Me.lblAl.Text = "Al:"
        '
        'dtpDe
        '
        Me.dtpDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDe.Location = New System.Drawing.Point(35, 58)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(215, 20)
        Me.dtpDe.TabIndex = 12
        '
        'dtpAl
        '
        Me.dtpAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAl.Location = New System.Drawing.Point(35, 86)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(215, 20)
        Me.dtpAl.TabIndex = 13
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(676, 171)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 34
        Me.lblNave.Text = "Nave"
        '
        'cmbTIpoComprobante
        '
        Me.cmbTIpoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIpoComprobante.FormattingEnabled = True
        Me.cmbTIpoComprobante.Location = New System.Drawing.Point(126, 41)
        Me.cmbTIpoComprobante.Name = "cmbTIpoComprobante"
        Me.cmbTIpoComprobante.Size = New System.Drawing.Size(273, 21)
        Me.cmbTIpoComprobante.TabIndex = 5
        '
        'pnlBotonesVisibles
        '
        Me.pnlBotonesVisibles.Controls.Add(Me.pnlBotonesPanelAccion)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnArriba)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesVisibles.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesVisibles.Location = New System.Drawing.Point(933, 0)
        Me.pnlBotonesVisibles.Name = "pnlBotonesVisibles"
        Me.pnlBotonesVisibles.Size = New System.Drawing.Size(87, 204)
        Me.pnlBotonesVisibles.TabIndex = 18
        '
        'pnlBotonesPanelAccion
        '
        Me.pnlBotonesPanelAccion.Controls.Add(Me.lbllimpiar)
        Me.pnlBotonesPanelAccion.Controls.Add(Me.btnlimpiar)
        Me.pnlBotonesPanelAccion.Controls.Add(Me.lblMostrar)
        Me.pnlBotonesPanelAccion.Controls.Add(Me.btnMostrar)
        Me.pnlBotonesPanelAccion.Location = New System.Drawing.Point(2, 135)
        Me.pnlBotonesPanelAccion.Name = "pnlBotonesPanelAccion"
        Me.pnlBotonesPanelAccion.Size = New System.Drawing.Size(87, 64)
        Me.pnlBotonesPanelAccion.TabIndex = 24
        '
        'lbllimpiar
        '
        Me.lbllimpiar.AutoSize = True
        Me.lbllimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbllimpiar.Location = New System.Drawing.Point(46, 44)
        Me.lbllimpiar.Name = "lbllimpiar"
        Me.lbllimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lbllimpiar.TabIndex = 27
        Me.lbllimpiar.Text = "Limpiar"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnlimpiar.Location = New System.Drawing.Point(49, 9)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(31, 32)
        Me.btnlimpiar.TabIndex = 19
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(1, 44)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 24
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(5, 9)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(31, 32)
        Me.btnMostrar.TabIndex = 18
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(30, 4)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 20
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(56, 4)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 21
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(12, 76)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(55, 13)
        Me.lblEmpresa.TabIndex = 7
        Me.lblEmpresa.Text = "*Empresa:"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.Enabled = False
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(126, 73)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(273, 21)
        Me.cmbEmpresa.TabIndex = 6
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.Location = New System.Drawing.Point(12, 44)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(116, 13)
        Me.lblTipoComprobante.TabIndex = 27
        Me.lblTipoComprobante.Text = "*Tipo de Comprobante:"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblRelacionarXML)
        Me.pnlHeader.Controls.Add(Me.lblRelacionarPDF)
        Me.pnlHeader.Controls.Add(Me.btnRelacionarPDF)
        Me.pnlHeader.Controls.Add(Me.btnRelacionarXml)
        Me.pnlHeader.Controls.Add(Me.btnAbrirXML)
        Me.pnlHeader.Controls.Add(Me.lblCopiarA)
        Me.pnlHeader.Controls.Add(Me.btnCopiarA)
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportarExcel)
        Me.pnlHeader.Controls.Add(Me.lblPDF)
        Me.pnlHeader.Controls.Add(Me.btnPDF)
        Me.pnlHeader.Controls.Add(Me.lblVerXml)
        Me.pnlHeader.Controls.Add(Me.pnlImg)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 60)
        Me.pnlHeader.TabIndex = 22
        '
        'lblRelacionarXML
        '
        Me.lblRelacionarXML.AutoSize = True
        Me.lblRelacionarXML.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRelacionarXML.Location = New System.Drawing.Point(252, 42)
        Me.lblRelacionarXML.Name = "lblRelacionarXML"
        Me.lblRelacionarXML.Size = New System.Drawing.Size(83, 13)
        Me.lblRelacionarXML.TabIndex = 60
        Me.lblRelacionarXML.Text = "Relacionar XML"
        '
        'lblRelacionarPDF
        '
        Me.lblRelacionarPDF.AutoSize = True
        Me.lblRelacionarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRelacionarPDF.Location = New System.Drawing.Point(341, 42)
        Me.lblRelacionarPDF.Name = "lblRelacionarPDF"
        Me.lblRelacionarPDF.Size = New System.Drawing.Size(82, 13)
        Me.lblRelacionarPDF.TabIndex = 59
        Me.lblRelacionarPDF.Text = "Relacionar PDF"
        '
        'btnRelacionarPDF
        '
        Me.btnRelacionarPDF.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_pdf
        Me.btnRelacionarPDF.Location = New System.Drawing.Point(363, 6)
        Me.btnRelacionarPDF.Name = "btnRelacionarPDF"
        Me.btnRelacionarPDF.Size = New System.Drawing.Size(35, 35)
        Me.btnRelacionarPDF.TabIndex = 58
        Me.btnRelacionarPDF.UseVisualStyleBackColor = True
        '
        'btnRelacionarXml
        '
        Me.btnRelacionarXml.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_xml_32
        Me.btnRelacionarXml.Location = New System.Drawing.Point(275, 6)
        Me.btnRelacionarXml.Name = "btnRelacionarXml"
        Me.btnRelacionarXml.Size = New System.Drawing.Size(35, 35)
        Me.btnRelacionarXml.TabIndex = 57
        Me.btnRelacionarXml.UseVisualStyleBackColor = True
        '
        'btnAbrirXML
        '
        Me.btnAbrirXML.Image = Global.Contabilidad.Vista.My.Resources.Resources.xml_32
        Me.btnAbrirXML.Location = New System.Drawing.Point(19, 6)
        Me.btnAbrirXML.Name = "btnAbrirXML"
        Me.btnAbrirXML.Size = New System.Drawing.Size(35, 35)
        Me.btnAbrirXML.TabIndex = 1
        Me.btnAbrirXML.UseVisualStyleBackColor = True
        '
        'lblCopiarA
        '
        Me.lblCopiarA.AutoSize = True
        Me.lblCopiarA.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarA.Location = New System.Drawing.Point(200, 42)
        Me.lblCopiarA.Name = "lblCopiarA"
        Me.lblCopiarA.Size = New System.Drawing.Size(46, 13)
        Me.lblCopiarA.TabIndex = 56
        Me.lblCopiarA.Text = "Copiar a"
        '
        'btnCopiarA
        '
        Me.btnCopiarA.Image = Global.Contabilidad.Vista.My.Resources.Resources.copiar_32
        Me.btnCopiarA.Location = New System.Drawing.Point(205, 6)
        Me.btnCopiarA.Name = "btnCopiarA"
        Me.btnCopiarA.Size = New System.Drawing.Size(35, 35)
        Me.btnCopiarA.TabIndex = 4
        Me.btnCopiarA.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(119, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(75, 13)
        Me.lblExportar.TabIndex = 54
        Me.lblExportar.Text = "Exportar Excel"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(142, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(35, 35)
        Me.btnExportarExcel.TabIndex = 3
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblPDF
        '
        Me.lblPDF.AutoSize = True
        Me.lblPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPDF.Location = New System.Drawing.Point(66, 42)
        Me.lblPDF.Name = "lblPDF"
        Me.lblPDF.Size = New System.Drawing.Size(47, 13)
        Me.lblPDF.TabIndex = 50
        Me.lblPDF.Text = "Ver PDF"
        '
        'btnPDF
        '
        Me.btnPDF.Image = Global.Contabilidad.Vista.My.Resources.Resources.pdf_32
        Me.btnPDF.Location = New System.Drawing.Point(71, 6)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(35, 35)
        Me.btnPDF.TabIndex = 2
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'lblVerXml
        '
        Me.lblVerXml.AutoSize = True
        Me.lblVerXml.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerXml.Location = New System.Drawing.Point(12, 42)
        Me.lblVerXml.Name = "lblVerXml"
        Me.lblVerXml.Size = New System.Drawing.Size(48, 13)
        Me.lblVerXml.TabIndex = 48
        Me.lblVerXml.Text = "Ver XML"
        '
        'pnlImg
        '
        Me.pnlImg.Controls.Add(Me.PictureBox1)
        Me.pnlImg.Controls.Add(Me.lblTitulo)
        Me.pnlImg.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlImg.Location = New System.Drawing.Point(740, 0)
        Me.pnlImg.Name = "pnlImg"
        Me.pnlImg.Size = New System.Drawing.Size(280, 60)
        Me.pnlImg.TabIndex = 46
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(212, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(197, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Comprobantes Fiscales"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.gboxCodigoColores)
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 465)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 60)
        Me.pnlEstado.TabIndex = 20
        '
        'gboxCodigoColores
        '
        Me.gboxCodigoColores.Controls.Add(Me.Label5)
        Me.gboxCodigoColores.Controls.Add(Me.lblPDFAgregado)
        Me.gboxCodigoColores.Controls.Add(Me.Label3)
        Me.gboxCodigoColores.Controls.Add(Me.lblAgregado)
        Me.gboxCodigoColores.Controls.Add(Me.Label1)
        Me.gboxCodigoColores.Controls.Add(Me.Label2)
        Me.gboxCodigoColores.Controls.Add(Me.lblSinXML)
        Me.gboxCodigoColores.Controls.Add(Me.lblSinXMLTexto)
        Me.gboxCodigoColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxCodigoColores.Location = New System.Drawing.Point(12, 3)
        Me.gboxCodigoColores.Name = "gboxCodigoColores"
        Me.gboxCodigoColores.Size = New System.Drawing.Size(217, 54)
        Me.gboxCodigoColores.TabIndex = 43
        Me.gboxCodigoColores.TabStop = False
        Me.gboxCodigoColores.Text = "Código de Colores"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.LightGreen
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.ForeColor = System.Drawing.Color.LightGreen
        Me.Label5.Location = New System.Drawing.Point(101, 35)
        Me.Label5.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "___"
        '
        'lblPDFAgregado
        '
        Me.lblPDFAgregado.AutoSize = True
        Me.lblPDFAgregado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDFAgregado.ForeColor = System.Drawing.Color.Black
        Me.lblPDFAgregado.Location = New System.Drawing.Point(118, 36)
        Me.lblPDFAgregado.Name = "lblPDFAgregado"
        Me.lblPDFAgregado.Size = New System.Drawing.Size(77, 13)
        Me.lblPDFAgregado.TabIndex = 35
        Me.lblPDFAgregado.Text = "PDF Agregado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LimeGreen
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label3.Location = New System.Drawing.Point(101, 16)
        Me.Label3.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "___"
        '
        'lblAgregado
        '
        Me.lblAgregado.AutoSize = True
        Me.lblAgregado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregado.ForeColor = System.Drawing.Color.Black
        Me.lblAgregado.Location = New System.Drawing.Point(118, 17)
        Me.lblAgregado.Name = "lblAgregado"
        Me.lblAgregado.Size = New System.Drawing.Size(78, 13)
        Me.lblAgregado.TabIndex = 33
        Me.lblAgregado.Text = "XML Agregado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Khaki
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.Khaki
        Me.Label1.Location = New System.Drawing.Point(7, 34)
        Me.Label1.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "___"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Sin PDF"
        '
        'lblSinXML
        '
        Me.lblSinXML.AutoSize = True
        Me.lblSinXML.BackColor = System.Drawing.Color.Salmon
        Me.lblSinXML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSinXML.ForeColor = System.Drawing.Color.Salmon
        Me.lblSinXML.Location = New System.Drawing.Point(7, 16)
        Me.lblSinXML.MaximumSize = New System.Drawing.Size(15, 15)
        Me.lblSinXML.Name = "lblSinXML"
        Me.lblSinXML.Size = New System.Drawing.Size(15, 15)
        Me.lblSinXML.TabIndex = 30
        Me.lblSinXML.Text = "___"
        '
        'lblSinXMLTexto
        '
        Me.lblSinXMLTexto.AutoSize = True
        Me.lblSinXMLTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSinXMLTexto.ForeColor = System.Drawing.Color.Black
        Me.lblSinXMLTexto.Location = New System.Drawing.Point(24, 17)
        Me.lblSinXMLTexto.Name = "lblSinXMLTexto"
        Me.lblSinXMLTexto.Size = New System.Drawing.Size(47, 13)
        Me.lblSinXMLTexto.TabIndex = 29
        Me.lblSinXMLTexto.Text = "Sin XML"
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.lblSalir)
        Me.pnlBotones.Controls.Add(Me.btnsalir)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(832, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(188, 60)
        Me.pnlBotones.TabIndex = 7
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(138, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 9
        Me.lblSalir.Text = "Salir"
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnsalir.Location = New System.Drawing.Point(134, 5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(34, 35)
        Me.btnsalir.TabIndex = 23
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'grdComprobantesFiscales
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantesFiscales.DisplayLayout.Appearance = Appearance3
        Me.grdComprobantesFiscales.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows
        Me.grdComprobantesFiscales.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup
        Me.grdComprobantesFiscales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantesFiscales.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdComprobantesFiscales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdComprobantesFiscales.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.grdComprobantesFiscales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComprobantesFiscales.Location = New System.Drawing.Point(0, 264)
        Me.grdComprobantesFiscales.Name = "grdComprobantesFiscales"
        Me.grdComprobantesFiscales.Size = New System.Drawing.Size(1020, 201)
        Me.grdComprobantesFiscales.TabIndex = 23
        '
        'comprobantesFiscalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1020, 525)
        Me.Controls.Add(Me.grdComprobantesFiscales)
        Me.Controls.Add(Me.pnlBotonesAlto)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.Name = "comprobantesFiscalesForm"
        Me.Text = "Comprobantes Fiscales"
        Me.pnlBotonesAlto.ResumeLayout(False)
        Me.pnlBotonesAlto.PerformLayout()
        Me.gboxClienteProveedor.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        CType(Me.grdClienteProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gboxConsultar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxConsultar.ResumeLayout(False)
        Me.gboxConsultar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gboxLugar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxLugar.ResumeLayout(False)
        Me.gboxLugar.PerformLayout()
        CType(Me.gboxFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFechas.ResumeLayout(False)
        Me.gboxFechas.PerformLayout()
        Me.pnlFiltrosFecha.ResumeLayout(False)
        Me.pnlFiltrosFecha.PerformLayout()
        Me.pnlBotonesVisibles.ResumeLayout(False)
        Me.pnlBotonesPanelAccion.ResumeLayout(False)
        Me.pnlBotonesPanelAccion.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlImg.ResumeLayout(False)
        Me.pnlImg.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.gboxCodigoColores.ResumeLayout(False)
        Me.gboxCodigoColores.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBotonesAlto As System.Windows.Forms.Panel
    Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlBotonesVisibles As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlImg As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblFolioPoliza As System.Windows.Forms.Label
    Friend WithEvents lblCopiarA As System.Windows.Forms.Label
    Friend WithEvents btnCopiarA As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblPDF As System.Windows.Forms.Label
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents lblVerXml As System.Windows.Forms.Label
    Friend WithEvents btnAbrirXML As System.Windows.Forms.Button
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents cmbTIpoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFiltrosFecha As System.Windows.Forms.Panel
    Friend WithEvents rdoFechaPoliza As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFechaComprobante As System.Windows.Forms.RadioButton
    Friend WithEvents gboxCodigoColores As System.Windows.Forms.GroupBox
    Friend WithEvents lblSinXML As System.Windows.Forms.Label
    Friend WithEvents lblSinXMLTexto As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesPanelAccion As System.Windows.Forms.Panel
    Friend WithEvents lbllimpiar As System.Windows.Forms.Label
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents gboxLugar As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoFolioAproximado As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFolioExacto As System.Windows.Forms.RadioButton
    Friend WithEvents gboxFechas As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents gboxConsultar As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents rdoComprobantesYPolizas As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSoloComprobantes As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSinContabilizar As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDentrodePoliza As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTipoPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoPoliza As System.Windows.Forms.Label
    Friend WithEvents grdComprobantesFiscales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblRelacionarXML As System.Windows.Forms.Label
    Friend WithEvents lblRelacionarPDF As System.Windows.Forms.Label
    Friend WithEvents btnRelacionarPDF As System.Windows.Forms.Button
    Friend WithEvents btnRelacionarXml As System.Windows.Forms.Button
    Friend WithEvents ofdComprobantesFiscales As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPDFAgregado As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAgregado As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents gboxClienteProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents grdClienteProveedor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnClienteProveedor As System.Windows.Forms.Button
End Class
