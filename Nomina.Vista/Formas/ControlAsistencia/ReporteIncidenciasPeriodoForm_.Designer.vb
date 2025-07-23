<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteIncidenciasPeriodoForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteIncidenciasPeriodoForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gridReporteIncidencias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.lblInstruccionPanelesEstado = New System.Windows.Forms.Label()
        Me.btnColaborador = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaTermino = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlLimpiar = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnLimpiarProductividad = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlFotter = New System.Windows.Forms.Panel()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.btnCancelarProductividad = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        CType(Me.gridReporteIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlLimpiar.SuspendLayout()
        Me.pnlFotter.SuspendLayout()
        Me.pnl.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gridReporteIncidencias)
        Me.pnlContenedor.Controls.Add(Me.grpParametros)
        Me.pnlContenedor.Controls.Add(Me.pnlFotter)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1190, 575)
        Me.pnlContenedor.TabIndex = 3
        '
        'gridReporteIncidencias
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridReporteIncidencias.DisplayLayout.Appearance = Appearance1
        Me.gridReporteIncidencias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridReporteIncidencias.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporteIncidencias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporteIncidencias.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporteIncidencias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridReporteIncidencias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridReporteIncidencias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridReporteIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridReporteIncidencias.Location = New System.Drawing.Point(0, 180)
        Me.gridReporteIncidencias.Name = "gridReporteIncidencias"
        Me.gridReporteIncidencias.Size = New System.Drawing.Size(1190, 337)
        Me.gridReporteIncidencias.TabIndex = 2
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.lblInstruccionPanelesEstado)
        Me.grpParametros.Controls.Add(Me.btnColaborador)
        Me.grpParametros.Controls.Add(Me.Label1)
        Me.grpParametros.Controls.Add(Me.GroupBox1)
        Me.grpParametros.Controls.Add(Me.pnlLimpiar)
        Me.grpParametros.Controls.Add(Me.cboxNave)
        Me.grpParametros.Controls.Add(Me.lblNave)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 59)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1190, 121)
        Me.grpParametros.TabIndex = 0
        Me.grpParametros.TabStop = False
        '
        'lblInstruccionPanelesEstado
        '
        Me.lblInstruccionPanelesEstado.AutoSize = True
        Me.lblInstruccionPanelesEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruccionPanelesEstado.Location = New System.Drawing.Point(466, 100)
        Me.lblInstruccionPanelesEstado.Name = "lblInstruccionPanelesEstado"
        Me.lblInstruccionPanelesEstado.Size = New System.Drawing.Size(310, 13)
        Me.lblInstruccionPanelesEstado.TabIndex = 61
        Me.lblInstruccionPanelesEstado.Text = "Filtre el rango de fechas antes de seleccionar los colaboradores."
        Me.lblInstruccionPanelesEstado.Visible = False
        '
        'btnColaborador
        '
        Me.btnColaborador.BackgroundImage = CType(resources.GetObject("btnColaborador.BackgroundImage"), System.Drawing.Image)
        Me.btnColaborador.Location = New System.Drawing.Point(724, 30)
        Me.btnColaborador.Name = "btnColaborador"
        Me.btnColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnColaborador.TabIndex = 0
        Me.btnColaborador.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(704, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Seleccionar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colaboradores"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaTermino)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaFinal)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(469, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 77)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'dtpFechaTermino
        '
        Me.dtpFechaTermino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaTermino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTermino.Location = New System.Drawing.Point(84, 51)
        Me.dtpFechaTermino.MaxDate = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaTermino.MinDate = New Date(1991, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaTermino.Name = "dtpFechaTermino"
        Me.dtpFechaTermino.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFechaTermino.RightToLeftLayout = True
        Me.dtpFechaTermino.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaTermino.TabIndex = 23
        Me.dtpFechaTermino.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(9, 29)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(66, 13)
        Me.lblFechaInicio.TabIndex = 20
        Me.lblFechaInicio.Text = "Fecha inicial"
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinal.ForeColor = System.Drawing.Color.Black
        Me.lblFechaFinal.Location = New System.Drawing.Point(9, 55)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
        Me.lblFechaFinal.TabIndex = 21
        Me.lblFechaFinal.Text = "Fecha final"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(84, 25)
        Me.dtpFechaInicio.MaxDate = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaInicio.MinDate = New Date(1991, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFechaInicio.RightToLeftLayout = True
        Me.dtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInicio.TabIndex = 22
        Me.dtpFechaInicio.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        '
        'pnlLimpiar
        '
        Me.pnlLimpiar.Controls.Add(Me.lblMostrar)
        Me.pnlLimpiar.Controls.Add(Me.btnMostrar)
        Me.pnlLimpiar.Controls.Add(Me.btnArriba)
        Me.pnlLimpiar.Controls.Add(Me.btnAbajo)
        Me.pnlLimpiar.Controls.Add(Me.btnLimpiarProductividad)
        Me.pnlLimpiar.Controls.Add(Me.lblLimpiar)
        Me.pnlLimpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlLimpiar.Location = New System.Drawing.Point(1054, 16)
        Me.pnlLimpiar.Name = "pnlLimpiar"
        Me.pnlLimpiar.Size = New System.Drawing.Size(133, 102)
        Me.pnlLimpiar.TabIndex = 60
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(37, 67)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 44
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(41, 33)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 43
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(76, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(102, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnLimpiarProductividad
        '
        Me.btnLimpiarProductividad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiarProductividad.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarProductividad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarProductividad.Location = New System.Drawing.Point(90, 33)
        Me.btnLimpiarProductividad.Name = "btnLimpiarProductividad"
        Me.btnLimpiarProductividad.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarProductividad.TabIndex = 2
        Me.btnLimpiarProductividad.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(86, 68)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'cboxNave
        '
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.Location = New System.Drawing.Point(76, 51)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(370, 21)
        Me.cboxNave.TabIndex = 59
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(26, 54)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 58
        Me.lblNave.Text = "*Nave"
        '
        'pnlFotter
        '
        Me.pnlFotter.BackColor = System.Drawing.Color.White
        Me.pnlFotter.Controls.Add(Me.pnl)
        Me.pnlFotter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFotter.Location = New System.Drawing.Point(0, 517)
        Me.pnlFotter.Name = "pnlFotter"
        Me.pnlFotter.Size = New System.Drawing.Size(1190, 58)
        Me.pnlFotter.TabIndex = 2
        '
        'pnl
        '
        Me.pnl.Controls.Add(Me.btnCancelarProductividad)
        Me.pnl.Controls.Add(Me.lblCancelar)
        Me.pnl.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl.Location = New System.Drawing.Point(1117, 0)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(73, 58)
        Me.pnl.TabIndex = 0
        '
        'btnCancelarProductividad
        '
        Me.btnCancelarProductividad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarProductividad.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarProductividad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarProductividad.Location = New System.Drawing.Point(20, 6)
        Me.btnCancelarProductividad.Name = "btnCancelarProductividad"
        Me.btnCancelarProductividad.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarProductividad.TabIndex = 1
        Me.btnCancelarProductividad.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(19, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1190, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1190, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(76, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 29
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(71, 41)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 30
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = Global.Nomina.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(21, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 27
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(14, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 28
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(788, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(402, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(57, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(275, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reportes -  Control de Asistencia"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(334, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 47
        Me.pcbTitulo.TabStop = False
        '
        'ReporteIncidenciasPeriodoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1190, 575)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReporteIncidenciasPeriodoForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenedor.ResumeLayout(False)
        CType(Me.gridReporteIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpParametros.ResumeLayout(False)
        Me.grpParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlLimpiar.ResumeLayout(False)
        Me.pnlLimpiar.PerformLayout()
        Me.pnlFotter.ResumeLayout(False)
        Me.pnl.ResumeLayout(False)
        Me.pnl.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gridReporteIncidencias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarProductividad As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlFotter As System.Windows.Forms.Panel
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents btnColaborador As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaTermino As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlLimpiar As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarProductividad As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblInstruccionPanelesEstado As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
