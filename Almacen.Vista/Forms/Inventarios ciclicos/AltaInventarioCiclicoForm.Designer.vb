<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaInventarioCiclicoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaInventarioCiclicoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblCodigosConErrores = New System.Windows.Forms.Label()
        Me.btnCodigosConErrores = New System.Windows.Forms.Button()
        Me.lblCargarArchivo = New System.Windows.Forms.Label()
        Me.btnCargarLectura = New System.Windows.Forms.Button()
        Me.btnUbicarMapa = New System.Windows.Forms.Button()
        Me.lblMapa = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.pnlOpearador = New System.Windows.Forms.Panel()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.pnlFecha = New System.Windows.Forms.Panel()
        Me.dtpFechaEjecucion = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaEjecucion = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.pnlDescripcion = New System.Windows.Forms.Panel()
        Me.rdoAtado = New System.Windows.Forms.RadioButton()
        Me.rdoPar = New System.Windows.Forms.RadioButton()
        Me.lblTipoDeLectura = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblLdescripcion = New System.Windows.Forms.Label()
        Me.lblDescricpcion = New System.Windows.Forms.Label()
        Me.grdCriterioDeFiltros = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.GrdInventariosCiclicos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlCantidadesInventarioFinalizado = New System.Windows.Forms.Panel()
        Me.pnlVerde = New System.Windows.Forms.Panel()
        Me.pnlRojo = New System.Windows.Forms.Panel()
        Me.lblParesInventario = New System.Windows.Forms.Label()
        Me.lblTotalInventario = New System.Windows.Forms.Label()
        Me.lblTotalCorrectos = New System.Windows.Forms.Label()
        Me.lblParesSobrantes = New System.Windows.Forms.Label()
        Me.lblTotalLeidos = New System.Windows.Forms.Label()
        Me.lblParesCorrectos = New System.Windows.Forms.Label()
        Me.lblTotalLectura = New System.Windows.Forms.Label()
        Me.lblTotalFaltantes = New System.Windows.Forms.Label()
        Me.lblTotalSobrantes = New System.Windows.Forms.Label()
        Me.lblParesFaltantes = New System.Windows.Forms.Label()
        Me.pnlEstadoPar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblColorNoEncontrado = New System.Windows.Forms.Label()
        Me.pnlColorNoEncontrado = New System.Windows.Forms.Panel()
        Me.lblColorSobrante = New System.Windows.Forms.Label()
        Me.pnlColorSobrante = New System.Windows.Forms.Panel()
        Me.pnlLocalizado = New System.Windows.Forms.Panel()
        Me.lblLocalizadoComo = New System.Windows.Forms.Label()
        Me.lblColorError = New System.Windows.Forms.Label()
        Me.pnlColorError = New System.Windows.Forms.Panel()
        Me.lblColorAtado = New System.Windows.Forms.Label()
        Me.pnlColorAtado = New System.Windows.Forms.Panel()
        Me.lblColorPar = New System.Windows.Forms.Label()
        Me.pnlColorPar = New System.Windows.Forms.Panel()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.lblErroneos = New System.Windows.Forms.Label()
        Me.lblRecuperados = New System.Windows.Forms.Label()
        Me.lblNombreCodigosErroneos = New System.Windows.Forms.Label()
        Me.lblNombreRegistrosRecuperados = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblNombreCodigosAtados = New System.Windows.Forms.Label()
        Me.lblNombreTotalPares = New System.Windows.Forms.Label()
        Me.lblAtados = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblNombreCodigosPar = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardarInventarioCiclico = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.cmsUbicarMapa = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UbicaciónRealToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UbicacionVIrtualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpParametros.SuspendLayout()
        Me.pnlOpearador.SuspendLayout()
        Me.pnlFecha.SuspendLayout()
        Me.pnlDescripcion.SuspendLayout()
        CType(Me.grdCriterioDeFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.GrdInventariosCiclicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlCantidadesInventarioFinalizado.SuspendLayout()
        Me.pnlEstadoPar.SuspendLayout()
        Me.pnlLocalizado.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.cmsUbicarMapa.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.lblCodigosConErrores)
        Me.pnlCabecera.Controls.Add(Me.btnCodigosConErrores)
        Me.pnlCabecera.Controls.Add(Me.lblCargarArchivo)
        Me.pnlCabecera.Controls.Add(Me.btnCargarLectura)
        Me.pnlCabecera.Controls.Add(Me.btnUbicarMapa)
        Me.pnlCabecera.Controls.Add(Me.lblMapa)
        Me.pnlCabecera.Controls.Add(Me.lblCancelar)
        Me.pnlCabecera.Controls.Add(Me.btnCancelar)
        Me.pnlCabecera.Controls.Add(Me.lblExportar)
        Me.pnlCabecera.Controls.Add(Me.btnExportar)
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1124, 60)
        Me.pnlCabecera.TabIndex = 6
        '
        'lblCodigosConErrores
        '
        Me.lblCodigosConErrores.AutoSize = True
        Me.lblCodigosConErrores.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCodigosConErrores.Location = New System.Drawing.Point(247, 43)
        Me.lblCodigosConErrores.Name = "lblCodigosConErrores"
        Me.lblCodigosConErrores.Size = New System.Drawing.Size(90, 13)
        Me.lblCodigosConErrores.TabIndex = 46
        Me.lblCodigosConErrores.Text = "Códigos con error"
        Me.lblCodigosConErrores.Visible = False
        '
        'btnCodigosConErrores
        '
        Me.btnCodigosConErrores.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCodigosConErrores.BackgroundImage = CType(resources.GetObject("btnCodigosConErrores.BackgroundImage"), System.Drawing.Image)
        Me.btnCodigosConErrores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCodigosConErrores.Image = CType(resources.GetObject("btnCodigosConErrores.Image"), System.Drawing.Image)
        Me.btnCodigosConErrores.Location = New System.Drawing.Point(271, 8)
        Me.btnCodigosConErrores.Name = "btnCodigosConErrores"
        Me.btnCodigosConErrores.Size = New System.Drawing.Size(32, 32)
        Me.btnCodigosConErrores.TabIndex = 5
        Me.btnCodigosConErrores.UseVisualStyleBackColor = False
        Me.btnCodigosConErrores.Visible = False
        '
        'lblCargarArchivo
        '
        Me.lblCargarArchivo.AutoSize = True
        Me.lblCargarArchivo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarArchivo.Location = New System.Drawing.Point(163, 43)
        Me.lblCargarArchivo.Name = "lblCargarArchivo"
        Me.lblCargarArchivo.Size = New System.Drawing.Size(76, 13)
        Me.lblCargarArchivo.TabIndex = 44
        Me.lblCargarArchivo.Text = "Cargar archivo"
        Me.lblCargarArchivo.Visible = False
        '
        'btnCargarLectura
        '
        Me.btnCargarLectura.Image = CType(resources.GetObject("btnCargarLectura.Image"), System.Drawing.Image)
        Me.btnCargarLectura.Location = New System.Drawing.Point(183, 8)
        Me.btnCargarLectura.Name = "btnCargarLectura"
        Me.btnCargarLectura.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarLectura.TabIndex = 4
        Me.btnCargarLectura.UseVisualStyleBackColor = True
        Me.btnCargarLectura.Visible = False
        '
        'btnUbicarMapa
        '
        Me.btnUbicarMapa.Image = Global.Almacen.Vista.My.Resources.Resources.mapa32_321
        Me.btnUbicarMapa.Location = New System.Drawing.Point(100, 8)
        Me.btnUbicarMapa.Name = "btnUbicarMapa"
        Me.btnUbicarMapa.Size = New System.Drawing.Size(32, 32)
        Me.btnUbicarMapa.TabIndex = 2
        Me.btnUbicarMapa.UseVisualStyleBackColor = True
        '
        'lblMapa
        '
        Me.lblMapa.AutoSize = True
        Me.lblMapa.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMapa.Location = New System.Drawing.Point(75, 43)
        Me.lblMapa.Name = "lblMapa"
        Me.lblMapa.Size = New System.Drawing.Size(82, 13)
        Me.lblMapa.TabIndex = 42
        Me.lblMapa.Text = "Ubicar en mapa"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(166, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 40
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(173, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(20, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 38
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(27, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(844, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(43, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(164, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Inventarios Cíclicos"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(1054, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.pnlOpearador)
        Me.grpParametros.Controls.Add(Me.pnlDescripcion)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 38)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1124, 98)
        Me.grpParametros.TabIndex = 67
        Me.grpParametros.TabStop = False
        '
        'pnlOpearador
        '
        Me.pnlOpearador.Controls.Add(Me.cmbOperador)
        Me.pnlOpearador.Controls.Add(Me.pnlFecha)
        Me.pnlOpearador.Controls.Add(Me.lblOperador)
        Me.pnlOpearador.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOpearador.Location = New System.Drawing.Point(746, 16)
        Me.pnlOpearador.Name = "pnlOpearador"
        Me.pnlOpearador.Size = New System.Drawing.Size(375, 79)
        Me.pnlOpearador.TabIndex = 77
        '
        'cmbOperador
        '
        Me.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(71, 8)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(295, 21)
        Me.cmbOperador.TabIndex = 9
        '
        'pnlFecha
        '
        Me.pnlFecha.Controls.Add(Me.dtpFechaEjecucion)
        Me.pnlFecha.Controls.Add(Me.lblFechaEjecucion)
        Me.pnlFecha.Location = New System.Drawing.Point(7, 35)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Size = New System.Drawing.Size(359, 37)
        Me.pnlFecha.TabIndex = 76
        '
        'dtpFechaEjecucion
        '
        Me.dtpFechaEjecucion.Location = New System.Drawing.Point(114, 9)
        Me.dtpFechaEjecucion.Name = "dtpFechaEjecucion"
        Me.dtpFechaEjecucion.Size = New System.Drawing.Size(209, 20)
        Me.dtpFechaEjecucion.TabIndex = 10
        '
        'lblFechaEjecucion
        '
        Me.lblFechaEjecucion.AutoSize = True
        Me.lblFechaEjecucion.Location = New System.Drawing.Point(3, 11)
        Me.lblFechaEjecucion.Name = "lblFechaEjecucion"
        Me.lblFechaEjecucion.Size = New System.Drawing.Size(105, 13)
        Me.lblFechaEjecucion.TabIndex = 75
        Me.lblFechaEjecucion.Text = "*Fecha de ejecución"
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(10, 11)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(55, 13)
        Me.lblOperador.TabIndex = 74
        Me.lblOperador.Text = "*Operador"
        '
        'pnlDescripcion
        '
        Me.pnlDescripcion.Controls.Add(Me.rdoAtado)
        Me.pnlDescripcion.Controls.Add(Me.rdoPar)
        Me.pnlDescripcion.Controls.Add(Me.lblTipoDeLectura)
        Me.pnlDescripcion.Controls.Add(Me.txtDescripcion)
        Me.pnlDescripcion.Controls.Add(Me.lblLdescripcion)
        Me.pnlDescripcion.Controls.Add(Me.lblDescricpcion)
        Me.pnlDescripcion.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescripcion.Location = New System.Drawing.Point(3, 16)
        Me.pnlDescripcion.Name = "pnlDescripcion"
        Me.pnlDescripcion.Size = New System.Drawing.Size(737, 79)
        Me.pnlDescripcion.TabIndex = 75
        '
        'rdoAtado
        '
        Me.rdoAtado.AutoSize = True
        Me.rdoAtado.Location = New System.Drawing.Point(149, 57)
        Me.rdoAtado.Name = "rdoAtado"
        Me.rdoAtado.Size = New System.Drawing.Size(80, 17)
        Me.rdoAtado.TabIndex = 76
        Me.rdoAtado.TabStop = True
        Me.rdoAtado.Text = "Par y Atado"
        Me.rdoAtado.UseVisualStyleBackColor = True
        '
        'rdoPar
        '
        Me.rdoPar.AutoSize = True
        Me.rdoPar.Checked = True
        Me.rdoPar.Location = New System.Drawing.Point(95, 57)
        Me.rdoPar.Name = "rdoPar"
        Me.rdoPar.Size = New System.Drawing.Size(41, 17)
        Me.rdoPar.TabIndex = 75
        Me.rdoPar.TabStop = True
        Me.rdoPar.Text = "Par"
        Me.rdoPar.UseVisualStyleBackColor = True
        '
        'lblTipoDeLectura
        '
        Me.lblTipoDeLectura.AutoSize = True
        Me.lblTipoDeLectura.Location = New System.Drawing.Point(3, 59)
        Me.lblTipoDeLectura.Name = "lblTipoDeLectura"
        Me.lblTipoDeLectura.Size = New System.Drawing.Size(78, 13)
        Me.lblTipoDeLectura.TabIndex = 74
        Me.lblTipoDeLectura.Text = "Tipo de lectura"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(72, 8)
        Me.txtDescripcion.MaxLength = 295
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(661, 48)
        Me.txtDescripcion.TabIndex = 8
        '
        'lblLdescripcion
        '
        Me.lblLdescripcion.AutoSize = True
        Me.lblLdescripcion.Location = New System.Drawing.Point(81, 11)
        Me.lblLdescripcion.MaximumSize = New System.Drawing.Size(445, 75)
        Me.lblLdescripcion.Name = "lblLdescripcion"
        Me.lblLdescripcion.Size = New System.Drawing.Size(16, 13)
        Me.lblLdescripcion.TabIndex = 73
        Me.lblLdescripcion.Text = "..."
        '
        'lblDescricpcion
        '
        Me.lblDescricpcion.AutoSize = True
        Me.lblDescricpcion.Location = New System.Drawing.Point(3, 8)
        Me.lblDescricpcion.Name = "lblDescricpcion"
        Me.lblDescricpcion.Size = New System.Drawing.Size(67, 13)
        Me.lblDescricpcion.TabIndex = 72
        Me.lblDescricpcion.Text = "*Descripción"
        '
        'grdCriterioDeFiltros
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCriterioDeFiltros.DisplayLayout.Appearance = Appearance1
        Me.grdCriterioDeFiltros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCriterioDeFiltros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCriterioDeFiltros.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCriterioDeFiltros.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCriterioDeFiltros.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCriterioDeFiltros.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCriterioDeFiltros.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCriterioDeFiltros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCriterioDeFiltros.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCriterioDeFiltros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCriterioDeFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCriterioDeFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCriterioDeFiltros.Location = New System.Drawing.Point(3, 16)
        Me.grdCriterioDeFiltros.Name = "grdCriterioDeFiltros"
        Me.grdCriterioDeFiltros.Size = New System.Drawing.Size(1118, 139)
        Me.grdCriterioDeFiltros.TabIndex = 11
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.grpParametros)
        Me.pnlParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1124, 294)
        Me.pnlParametros.TabIndex = 66
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.grdCriterioDeFiltros)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(0, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1124, 158)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterios de filtrado"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.Panel13)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(1124, 38)
        Me.pnlMinimizarParametros.TabIndex = 68
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.btnAbajo)
        Me.Panel13.Controls.Add(Me.btnArriba)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(1042, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(82, 38)
        Me.Panel13.TabIndex = 3
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(51, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 7
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(25, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 6
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'GrdInventariosCiclicos
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrdInventariosCiclicos.DisplayLayout.Appearance = Appearance2
        Me.GrdInventariosCiclicos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GrdInventariosCiclicos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.GrdInventariosCiclicos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.GrdInventariosCiclicos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.GrdInventariosCiclicos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.GrdInventariosCiclicos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.GrdInventariosCiclicos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.GrdInventariosCiclicos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GrdInventariosCiclicos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.GrdInventariosCiclicos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.GrdInventariosCiclicos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdInventariosCiclicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdInventariosCiclicos.Location = New System.Drawing.Point(0, 354)
        Me.GrdInventariosCiclicos.Name = "GrdInventariosCiclicos"
        Me.GrdInventariosCiclicos.Size = New System.Drawing.Size(1124, 197)
        Me.GrdInventariosCiclicos.TabIndex = 12
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlCantidadesInventarioFinalizado)
        Me.pnlEstado.Controls.Add(Me.pnlEstadoPar)
        Me.pnlEstado.Controls.Add(Me.pnlLocalizado)
        Me.pnlEstado.Controls.Add(Me.pnlTotales)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 551)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1124, 85)
        Me.pnlEstado.TabIndex = 72
        '
        'pnlCantidadesInventarioFinalizado
        '
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.pnlVerde)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.pnlRojo)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblParesInventario)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalInventario)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalCorrectos)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblParesSobrantes)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalLeidos)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblParesCorrectos)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalLectura)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalFaltantes)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblTotalSobrantes)
        Me.pnlCantidadesInventarioFinalizado.Controls.Add(Me.lblParesFaltantes)
        Me.pnlCantidadesInventarioFinalizado.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCantidadesInventarioFinalizado.Location = New System.Drawing.Point(-462, 0)
        Me.pnlCantidadesInventarioFinalizado.Name = "pnlCantidadesInventarioFinalizado"
        Me.pnlCantidadesInventarioFinalizado.Size = New System.Drawing.Size(717, 85)
        Me.pnlCantidadesInventarioFinalizado.TabIndex = 78
        Me.pnlCantidadesInventarioFinalizado.Visible = False
        '
        'pnlVerde
        '
        Me.pnlVerde.BackColor = System.Drawing.Color.LightSalmon
        Me.pnlVerde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVerde.Location = New System.Drawing.Point(530, 12)
        Me.pnlVerde.Name = "pnlVerde"
        Me.pnlVerde.Size = New System.Drawing.Size(15, 15)
        Me.pnlVerde.TabIndex = 82
        Me.pnlVerde.Visible = False
        '
        'pnlRojo
        '
        Me.pnlRojo.BackColor = System.Drawing.Color.Khaki
        Me.pnlRojo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRojo.Location = New System.Drawing.Point(360, 12)
        Me.pnlRojo.Name = "pnlRojo"
        Me.pnlRojo.Size = New System.Drawing.Size(15, 15)
        Me.pnlRojo.TabIndex = 81
        Me.pnlRojo.Visible = False
        '
        'lblParesInventario
        '
        Me.lblParesInventario.AutoSize = True
        Me.lblParesInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesInventario.ForeColor = System.Drawing.Color.Black
        Me.lblParesInventario.Location = New System.Drawing.Point(19, 12)
        Me.lblParesInventario.Name = "lblParesInventario"
        Me.lblParesInventario.Size = New System.Drawing.Size(71, 15)
        Me.lblParesInventario.TabIndex = 67
        Me.lblParesInventario.Text = "Total pares:"
        Me.lblParesInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalInventario
        '
        Me.lblTotalInventario.AutoSize = True
        Me.lblTotalInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalInventario.ForeColor = System.Drawing.Color.Black
        Me.lblTotalInventario.Location = New System.Drawing.Point(90, 12)
        Me.lblTotalInventario.Name = "lblTotalInventario"
        Me.lblTotalInventario.Size = New System.Drawing.Size(56, 15)
        Me.lblTotalInventario.TabIndex = 65
        Me.lblTotalInventario.Text = "0000000"
        Me.lblTotalInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCorrectos
        '
        Me.lblTotalCorrectos.AutoSize = True
        Me.lblTotalCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCorrectos.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCorrectos.Location = New System.Drawing.Point(281, 12)
        Me.lblTotalCorrectos.Name = "lblTotalCorrectos"
        Me.lblTotalCorrectos.Size = New System.Drawing.Size(56, 15)
        Me.lblTotalCorrectos.TabIndex = 68
        Me.lblTotalCorrectos.Text = "0000000"
        Me.lblTotalCorrectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesSobrantes
        '
        Me.lblParesSobrantes.AutoSize = True
        Me.lblParesSobrantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesSobrantes.ForeColor = System.Drawing.Color.Black
        Me.lblParesSobrantes.Location = New System.Drawing.Point(543, 12)
        Me.lblParesSobrantes.Name = "lblParesSobrantes"
        Me.lblParesSobrantes.Size = New System.Drawing.Size(91, 15)
        Me.lblParesSobrantes.TabIndex = 64
        Me.lblParesSobrantes.Text = "Total sobrantes"
        Me.lblParesSobrantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalLeidos
        '
        Me.lblTotalLeidos.AutoSize = True
        Me.lblTotalLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLeidos.ForeColor = System.Drawing.Color.Black
        Me.lblTotalLeidos.Location = New System.Drawing.Point(635, 49)
        Me.lblTotalLeidos.Name = "lblTotalLeidos"
        Me.lblTotalLeidos.Size = New System.Drawing.Size(64, 16)
        Me.lblTotalLeidos.TabIndex = 66
        Me.lblTotalLeidos.Text = "0000000"
        Me.lblTotalLeidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesCorrectos
        '
        Me.lblParesCorrectos.AutoSize = True
        Me.lblParesCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesCorrectos.ForeColor = System.Drawing.Color.Black
        Me.lblParesCorrectos.Location = New System.Drawing.Point(177, 12)
        Me.lblParesCorrectos.Name = "lblParesCorrectos"
        Me.lblParesCorrectos.Size = New System.Drawing.Size(105, 15)
        Me.lblParesCorrectos.TabIndex = 61
        Me.lblParesCorrectos.Text = "Total encontrados"
        Me.lblParesCorrectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalLectura
        '
        Me.lblTotalLectura.AutoSize = True
        Me.lblTotalLectura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLectura.ForeColor = System.Drawing.Color.Black
        Me.lblTotalLectura.Location = New System.Drawing.Point(533, 49)
        Me.lblTotalLectura.Name = "lblTotalLectura"
        Me.lblTotalLectura.Size = New System.Drawing.Size(95, 16)
        Me.lblTotalLectura.TabIndex = 65
        Me.lblTotalLectura.Text = "Total lectura"
        Me.lblTotalLectura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalFaltantes
        '
        Me.lblTotalFaltantes.AutoSize = True
        Me.lblTotalFaltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFaltantes.ForeColor = System.Drawing.Color.Black
        Me.lblTotalFaltantes.Location = New System.Drawing.Point(455, 12)
        Me.lblTotalFaltantes.Name = "lblTotalFaltantes"
        Me.lblTotalFaltantes.Size = New System.Drawing.Size(56, 15)
        Me.lblTotalFaltantes.TabIndex = 62
        Me.lblTotalFaltantes.Text = "0000000"
        Me.lblTotalFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSobrantes
        '
        Me.lblTotalSobrantes.AutoSize = True
        Me.lblTotalSobrantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSobrantes.ForeColor = System.Drawing.Color.Black
        Me.lblTotalSobrantes.Location = New System.Drawing.Point(637, 12)
        Me.lblTotalSobrantes.Name = "lblTotalSobrantes"
        Me.lblTotalSobrantes.Size = New System.Drawing.Size(56, 15)
        Me.lblTotalSobrantes.TabIndex = 64
        Me.lblTotalSobrantes.Text = "0000000"
        Me.lblTotalSobrantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesFaltantes
        '
        Me.lblParesFaltantes.AutoSize = True
        Me.lblParesFaltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesFaltantes.ForeColor = System.Drawing.Color.Black
        Me.lblParesFaltantes.Location = New System.Drawing.Point(373, 12)
        Me.lblParesFaltantes.Name = "lblParesFaltantes"
        Me.lblParesFaltantes.Size = New System.Drawing.Size(83, 15)
        Me.lblParesFaltantes.TabIndex = 63
        Me.lblParesFaltantes.Text = "Total faltantes"
        Me.lblParesFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEstadoPar
        '
        Me.pnlEstadoPar.Controls.Add(Me.Label1)
        Me.pnlEstadoPar.Controls.Add(Me.lblColorNoEncontrado)
        Me.pnlEstadoPar.Controls.Add(Me.pnlColorNoEncontrado)
        Me.pnlEstadoPar.Controls.Add(Me.lblColorSobrante)
        Me.pnlEstadoPar.Controls.Add(Me.pnlColorSobrante)
        Me.pnlEstadoPar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstadoPar.Location = New System.Drawing.Point(92, 0)
        Me.pnlEstadoPar.Name = "pnlEstadoPar"
        Me.pnlEstadoPar.Size = New System.Drawing.Size(129, 85)
        Me.pnlEstadoPar.TabIndex = 77
        Me.pnlEstadoPar.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Estado final:"
        '
        'lblColorNoEncontrado
        '
        Me.lblColorNoEncontrado.AutoSize = True
        Me.lblColorNoEncontrado.Location = New System.Drawing.Point(29, 46)
        Me.lblColorNoEncontrado.Name = "lblColorNoEncontrado"
        Me.lblColorNoEncontrado.Size = New System.Drawing.Size(78, 13)
        Me.lblColorNoEncontrado.TabIndex = 78
        Me.lblColorNoEncontrado.Text = "No encontrado"
        '
        'pnlColorNoEncontrado
        '
        Me.pnlColorNoEncontrado.BackColor = System.Drawing.Color.Khaki
        Me.pnlColorNoEncontrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorNoEncontrado.Location = New System.Drawing.Point(8, 44)
        Me.pnlColorNoEncontrado.Name = "pnlColorNoEncontrado"
        Me.pnlColorNoEncontrado.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorNoEncontrado.TabIndex = 77
        '
        'lblColorSobrante
        '
        Me.lblColorSobrante.AutoSize = True
        Me.lblColorSobrante.Location = New System.Drawing.Point(29, 26)
        Me.lblColorSobrante.Name = "lblColorSobrante"
        Me.lblColorSobrante.Size = New System.Drawing.Size(50, 13)
        Me.lblColorSobrante.TabIndex = 76
        Me.lblColorSobrante.Text = "Sobrante"
        '
        'pnlColorSobrante
        '
        Me.pnlColorSobrante.BackColor = System.Drawing.Color.LightSalmon
        Me.pnlColorSobrante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorSobrante.Location = New System.Drawing.Point(8, 24)
        Me.pnlColorSobrante.Name = "pnlColorSobrante"
        Me.pnlColorSobrante.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorSobrante.TabIndex = 75
        '
        'pnlLocalizado
        '
        Me.pnlLocalizado.Controls.Add(Me.lblLocalizadoComo)
        Me.pnlLocalizado.Controls.Add(Me.lblColorError)
        Me.pnlLocalizado.Controls.Add(Me.pnlColorError)
        Me.pnlLocalizado.Controls.Add(Me.lblColorAtado)
        Me.pnlLocalizado.Controls.Add(Me.pnlColorAtado)
        Me.pnlLocalizado.Controls.Add(Me.lblColorPar)
        Me.pnlLocalizado.Controls.Add(Me.pnlColorPar)
        Me.pnlLocalizado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLocalizado.Location = New System.Drawing.Point(0, 0)
        Me.pnlLocalizado.Name = "pnlLocalizado"
        Me.pnlLocalizado.Size = New System.Drawing.Size(92, 85)
        Me.pnlLocalizado.TabIndex = 76
        '
        'lblLocalizadoComo
        '
        Me.lblLocalizadoComo.AutoSize = True
        Me.lblLocalizadoComo.Location = New System.Drawing.Point(3, 6)
        Me.lblLocalizadoComo.Name = "lblLocalizadoComo"
        Me.lblLocalizadoComo.Size = New System.Drawing.Size(90, 13)
        Me.lblLocalizadoComo.TabIndex = 80
        Me.lblLocalizadoComo.Text = "Localizado como:"
        '
        'lblColorError
        '
        Me.lblColorError.AutoSize = True
        Me.lblColorError.Location = New System.Drawing.Point(34, 66)
        Me.lblColorError.Name = "lblColorError"
        Me.lblColorError.Size = New System.Drawing.Size(29, 13)
        Me.lblColorError.TabIndex = 79
        Me.lblColorError.Text = "Error"
        '
        'pnlColorError
        '
        Me.pnlColorError.BackColor = System.Drawing.Color.Orange
        Me.pnlColorError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorError.Location = New System.Drawing.Point(13, 64)
        Me.pnlColorError.Name = "pnlColorError"
        Me.pnlColorError.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorError.TabIndex = 78
        '
        'lblColorAtado
        '
        Me.lblColorAtado.AutoSize = True
        Me.lblColorAtado.Location = New System.Drawing.Point(35, 46)
        Me.lblColorAtado.Name = "lblColorAtado"
        Me.lblColorAtado.Size = New System.Drawing.Size(35, 13)
        Me.lblColorAtado.TabIndex = 77
        Me.lblColorAtado.Text = "Atado"
        '
        'pnlColorAtado
        '
        Me.pnlColorAtado.BackColor = System.Drawing.Color.Aquamarine
        Me.pnlColorAtado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorAtado.Location = New System.Drawing.Point(13, 44)
        Me.pnlColorAtado.Name = "pnlColorAtado"
        Me.pnlColorAtado.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorAtado.TabIndex = 76
        '
        'lblColorPar
        '
        Me.lblColorPar.AutoSize = True
        Me.lblColorPar.Location = New System.Drawing.Point(34, 26)
        Me.lblColorPar.Name = "lblColorPar"
        Me.lblColorPar.Size = New System.Drawing.Size(23, 13)
        Me.lblColorPar.TabIndex = 75
        Me.lblColorPar.Text = "Par"
        '
        'pnlColorPar
        '
        Me.pnlColorPar.BackColor = System.Drawing.Color.Khaki
        Me.pnlColorPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorPar.Location = New System.Drawing.Point(13, 24)
        Me.pnlColorPar.Name = "pnlColorPar"
        Me.pnlColorPar.Size = New System.Drawing.Size(15, 15)
        Me.pnlColorPar.TabIndex = 74
        '
        'pnlTotales
        '
        Me.pnlTotales.Controls.Add(Me.lblErroneos)
        Me.pnlTotales.Controls.Add(Me.lblRecuperados)
        Me.pnlTotales.Controls.Add(Me.lblNombreCodigosErroneos)
        Me.pnlTotales.Controls.Add(Me.lblNombreRegistrosRecuperados)
        Me.pnlTotales.Controls.Add(Me.lblTotalPares)
        Me.pnlTotales.Controls.Add(Me.lblNombreCodigosAtados)
        Me.pnlTotales.Controls.Add(Me.lblNombreTotalPares)
        Me.pnlTotales.Controls.Add(Me.lblAtados)
        Me.pnlTotales.Controls.Add(Me.lblPares)
        Me.pnlTotales.Controls.Add(Me.lblNombreCodigosPar)
        Me.pnlTotales.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTotales.Location = New System.Drawing.Point(255, 0)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(717, 85)
        Me.pnlTotales.TabIndex = 38
        '
        'lblErroneos
        '
        Me.lblErroneos.AutoSize = True
        Me.lblErroneos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErroneos.ForeColor = System.Drawing.Color.Black
        Me.lblErroneos.Location = New System.Drawing.Point(629, 14)
        Me.lblErroneos.Name = "lblErroneos"
        Me.lblErroneos.Size = New System.Drawing.Size(49, 13)
        Me.lblErroneos.TabIndex = 65
        Me.lblErroneos.Text = "0000000"
        Me.lblErroneos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecuperados
        '
        Me.lblRecuperados.AutoSize = True
        Me.lblRecuperados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuperados.ForeColor = System.Drawing.Color.Black
        Me.lblRecuperados.Location = New System.Drawing.Point(149, 14)
        Me.lblRecuperados.Name = "lblRecuperados"
        Me.lblRecuperados.Size = New System.Drawing.Size(49, 13)
        Me.lblRecuperados.TabIndex = 68
        Me.lblRecuperados.Text = "0000000"
        Me.lblRecuperados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreCodigosErroneos
        '
        Me.lblNombreCodigosErroneos.AutoSize = True
        Me.lblNombreCodigosErroneos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCodigosErroneos.ForeColor = System.Drawing.Color.Black
        Me.lblNombreCodigosErroneos.Location = New System.Drawing.Point(530, 14)
        Me.lblNombreCodigosErroneos.Name = "lblNombreCodigosErroneos"
        Me.lblNombreCodigosErroneos.Size = New System.Drawing.Size(93, 13)
        Me.lblNombreCodigosErroneos.TabIndex = 64
        Me.lblNombreCodigosErroneos.Text = "Códigos Erróneos:"
        Me.lblNombreCodigosErroneos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreRegistrosRecuperados
        '
        Me.lblNombreRegistrosRecuperados.AutoSize = True
        Me.lblNombreRegistrosRecuperados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreRegistrosRecuperados.ForeColor = System.Drawing.Color.Black
        Me.lblNombreRegistrosRecuperados.Location = New System.Drawing.Point(22, 14)
        Me.lblNombreRegistrosRecuperados.Name = "lblNombreRegistrosRecuperados"
        Me.lblNombreRegistrosRecuperados.Size = New System.Drawing.Size(121, 13)
        Me.lblNombreRegistrosRecuperados.TabIndex = 67
        Me.lblNombreRegistrosRecuperados.Text = "Registros Recuperados:"
        Me.lblNombreRegistrosRecuperados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPares.Location = New System.Drawing.Point(629, 49)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(72, 16)
        Me.lblTotalPares.TabIndex = 66
        Me.lblTotalPares.Text = "00000000"
        Me.lblTotalPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreCodigosAtados
        '
        Me.lblNombreCodigosAtados.AutoSize = True
        Me.lblNombreCodigosAtados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCodigosAtados.ForeColor = System.Drawing.Color.Black
        Me.lblNombreCodigosAtados.Location = New System.Drawing.Point(222, 14)
        Me.lblNombreCodigosAtados.Name = "lblNombreCodigosAtados"
        Me.lblNombreCodigosAtados.Size = New System.Drawing.Size(79, 13)
        Me.lblNombreCodigosAtados.TabIndex = 61
        Me.lblNombreCodigosAtados.Text = "Códigos Atado:"
        Me.lblNombreCodigosAtados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreTotalPares
        '
        Me.lblNombreTotalPares.AutoSize = True
        Me.lblNombreTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblNombreTotalPares.Location = New System.Drawing.Point(530, 49)
        Me.lblNombreTotalPares.Name = "lblNombreTotalPares"
        Me.lblNombreTotalPares.Size = New System.Drawing.Size(93, 16)
        Me.lblNombreTotalPares.TabIndex = 65
        Me.lblNombreTotalPares.Text = "Total Pares:"
        Me.lblNombreTotalPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAtados
        '
        Me.lblAtados.AutoSize = True
        Me.lblAtados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtados.ForeColor = System.Drawing.Color.Black
        Me.lblAtados.Location = New System.Drawing.Point(307, 14)
        Me.lblAtados.Name = "lblAtados"
        Me.lblAtados.Size = New System.Drawing.Size(49, 13)
        Me.lblAtados.TabIndex = 62
        Me.lblAtados.Text = "0000000"
        Me.lblAtados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.ForeColor = System.Drawing.Color.Black
        Me.lblPares.Location = New System.Drawing.Point(453, 14)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(49, 13)
        Me.lblPares.TabIndex = 64
        Me.lblPares.Text = "0000000"
        Me.lblPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombreCodigosPar
        '
        Me.lblNombreCodigosPar.AutoSize = True
        Me.lblNombreCodigosPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCodigosPar.ForeColor = System.Drawing.Color.Black
        Me.lblNombreCodigosPar.Location = New System.Drawing.Point(380, 14)
        Me.lblNombreCodigosPar.Name = "lblNombreCodigosPar"
        Me.lblNombreCodigosPar.Size = New System.Drawing.Size(67, 13)
        Me.lblNombreCodigosPar.TabIndex = 63
        Me.lblNombreCodigosPar.Text = "Códigos Par:"
        Me.lblNombreCodigosPar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardarInventarioCiclico)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(972, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(152, 85)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(22, 54)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 21
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardarInventarioCiclico
        '
        Me.btnGuardarInventarioCiclico.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarInventarioCiclico.Location = New System.Drawing.Point(25, 22)
        Me.btnGuardarInventarioCiclico.Name = "btnGuardarInventarioCiclico"
        Me.btnGuardarInventarioCiclico.Size = New System.Drawing.Size(32, 33)
        Me.btnGuardarInventarioCiclico.TabIndex = 13
        Me.btnGuardarInventarioCiclico.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(93, 54)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(93, 22)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'cmsUbicarMapa
        '
        Me.cmsUbicarMapa.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UbicaciónRealToolStripMenuItem, Me.UbicacionVIrtualToolStripMenuItem})
        Me.cmsUbicarMapa.Name = "cmsUbicarMapa"
        Me.cmsUbicarMapa.Size = New System.Drawing.Size(165, 48)
        '
        'UbicaciónRealToolStripMenuItem
        '
        Me.UbicaciónRealToolStripMenuItem.Name = "UbicaciónRealToolStripMenuItem"
        Me.UbicaciónRealToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UbicaciónRealToolStripMenuItem.Text = "Ubicación Real"
        '
        'UbicacionVIrtualToolStripMenuItem
        '
        Me.UbicacionVIrtualToolStripMenuItem.Name = "UbicacionVIrtualToolStripMenuItem"
        Me.UbicacionVIrtualToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UbicacionVIrtualToolStripMenuItem.Text = "Ubicacion Virtual"
        '
        'AltaInventarioCiclicoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1124, 636)
        Me.Controls.Add(Me.GrdInventariosCiclicos)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaInventarioCiclicoForm"
        Me.Text = "Inventarios Cíclicos"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpParametros.ResumeLayout(False)
        Me.pnlOpearador.ResumeLayout(False)
        Me.pnlOpearador.PerformLayout()
        Me.pnlFecha.ResumeLayout(False)
        Me.pnlFecha.PerformLayout()
        Me.pnlDescripcion.ResumeLayout(False)
        Me.pnlDescripcion.PerformLayout()
        CType(Me.grdCriterioDeFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        CType(Me.GrdInventariosCiclicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlCantidadesInventarioFinalizado.ResumeLayout(False)
        Me.pnlCantidadesInventarioFinalizado.PerformLayout()
        Me.pnlEstadoPar.ResumeLayout(False)
        Me.pnlEstadoPar.PerformLayout()
        Me.pnlLocalizado.ResumeLayout(False)
        Me.pnlLocalizado.PerformLayout()
        Me.pnlTotales.ResumeLayout(False)
        Me.pnlTotales.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.cmsUbicarMapa.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents GrdInventariosCiclicos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlDescripcion As System.Windows.Forms.Panel
    Friend WithEvents lblDescricpcion As System.Windows.Forms.Label
    Friend WithEvents pnlOpearador As System.Windows.Forms.Panel
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents pnlFecha As System.Windows.Forms.Panel
    Friend WithEvents lblFechaEjecucion As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardarInventarioCiclico As System.Windows.Forms.Button
    Friend WithEvents dtpFechaEjecucion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Public WithEvents lblLdescripcion As System.Windows.Forms.Label
    Friend WithEvents grdCriterioDeFiltros As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlTotales As System.Windows.Forms.Panel
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblNombreCodigosAtados As System.Windows.Forms.Label
    Friend WithEvents lblNombreTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblAtados As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblNombreCodigosPar As System.Windows.Forms.Label
    Friend WithEvents lblRecuperados As System.Windows.Forms.Label
    Friend WithEvents lblNombreRegistrosRecuperados As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnUbicarMapa As System.Windows.Forms.Button
    Friend WithEvents lblMapa As System.Windows.Forms.Label
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents lblErroneos As System.Windows.Forms.Label
    Friend WithEvents lblNombreCodigosErroneos As System.Windows.Forms.Label
    Friend WithEvents pnlCantidadesInventarioFinalizado As System.Windows.Forms.Panel
    Friend WithEvents lblParesInventario As System.Windows.Forms.Label
    Friend WithEvents lblTotalInventario As System.Windows.Forms.Label
    Friend WithEvents lblTotalCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblParesSobrantes As System.Windows.Forms.Label
    Friend WithEvents lblTotalLeidos As System.Windows.Forms.Label
    Friend WithEvents lblParesCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblTotalLectura As System.Windows.Forms.Label
    Friend WithEvents lblTotalFaltantes As System.Windows.Forms.Label
    Friend WithEvents lblTotalSobrantes As System.Windows.Forms.Label
    Friend WithEvents lblParesFaltantes As System.Windows.Forms.Label
    Friend WithEvents pnlEstadoPar As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblColorNoEncontrado As System.Windows.Forms.Label
    Friend WithEvents pnlColorNoEncontrado As System.Windows.Forms.Panel
    Friend WithEvents lblColorSobrante As System.Windows.Forms.Label
    Friend WithEvents pnlColorSobrante As System.Windows.Forms.Panel
    Friend WithEvents pnlLocalizado As System.Windows.Forms.Panel
    Friend WithEvents lblLocalizadoComo As System.Windows.Forms.Label
    Friend WithEvents lblColorError As System.Windows.Forms.Label
    Friend WithEvents pnlColorError As System.Windows.Forms.Panel
    Friend WithEvents lblColorAtado As System.Windows.Forms.Label
    Friend WithEvents pnlColorAtado As System.Windows.Forms.Panel
    Friend WithEvents lblColorPar As System.Windows.Forms.Label
    Friend WithEvents pnlColorPar As System.Windows.Forms.Panel
    Friend WithEvents lblCargarArchivo As System.Windows.Forms.Label
    Friend WithEvents btnCargarLectura As System.Windows.Forms.Button
    Friend WithEvents lblCodigosConErrores As System.Windows.Forms.Label
    Friend WithEvents btnCodigosConErrores As System.Windows.Forms.Button
    Friend WithEvents pnlVerde As System.Windows.Forms.Panel
    Friend WithEvents pnlRojo As System.Windows.Forms.Panel
    Friend WithEvents rdoAtado As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPar As System.Windows.Forms.RadioButton
    Friend WithEvents lblTipoDeLectura As System.Windows.Forms.Label
    Friend WithEvents cmsUbicarMapa As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UbicaciónRealToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UbicacionVIrtualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
