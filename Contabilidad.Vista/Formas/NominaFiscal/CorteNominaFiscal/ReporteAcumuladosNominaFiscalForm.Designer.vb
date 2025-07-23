<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteAcumuladosNominaFiscalForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteAcumuladosNominaFiscalForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAutorizarISR = New System.Windows.Forms.Panel()
        Me.btnAutorizarISR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCargar = New System.Windows.Forms.Panel()
        Me.btnImportarDatos = New System.Windows.Forms.Button()
        Me.lblCargarDatos = New System.Windows.Forms.Label()
        Me.pnlLayout = New System.Windows.Forms.Panel()
        Me.btnLayout = New System.Windows.Forms.Button()
        Me.lblLayout = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlCalcular = New System.Windows.Forms.Panel()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.rdoCalculo = New System.Windows.Forms.RadioButton()
        Me.rdoAcumulado = New System.Windows.Forms.RadioButton()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblPeriodoAl = New System.Windows.Forms.Label()
        Me.lblPeriodoDel = New System.Windows.Forms.Label()
        Me.cmbPeriodoAl = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodoDel = New System.Windows.Forms.ComboBox()
        Me.txtAnio = New System.Windows.Forms.TextBox()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrarAcumulado = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.GridAcumuladoSS = New DevExpress.XtraGrid.GridControl()
        Me.grdAcumuladoSS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAutorizarISR.SuspendLayout()
        Me.pnlCargar.SuspendLayout()
        Me.pnlLayout.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlCalcular.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.gpbFiltro.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        CType(Me.GridAcumuladoSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAcumuladoSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAutorizarISR)
        Me.pnlHeader.Controls.Add(Me.pnlCargar)
        Me.pnlHeader.Controls.Add(Me.pnlLayout)
        Me.pnlHeader.Controls.Add(Me.pnlExportar)
        Me.pnlHeader.Controls.Add(Me.pnlImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlCalcular)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 69)
        Me.pnlHeader.TabIndex = 27
        '
        'pnlAutorizarISR
        '
        Me.pnlAutorizarISR.Controls.Add(Me.btnAutorizarISR)
        Me.pnlAutorizarISR.Controls.Add(Me.Label1)
        Me.pnlAutorizarISR.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizarISR.Location = New System.Drawing.Point(336, 0)
        Me.pnlAutorizarISR.Name = "pnlAutorizarISR"
        Me.pnlAutorizarISR.Size = New System.Drawing.Size(66, 69)
        Me.pnlAutorizarISR.TabIndex = 110
        '
        'btnAutorizarISR
        '
        Me.btnAutorizarISR.Image = CType(resources.GetObject("btnAutorizarISR.Image"), System.Drawing.Image)
        Me.btnAutorizarISR.Location = New System.Drawing.Point(19, 7)
        Me.btnAutorizarISR.Name = "btnAutorizarISR"
        Me.btnAutorizarISR.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizarISR.TabIndex = 10
        Me.btnAutorizarISR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(7, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 26)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Autorizar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ISR Anual"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCargar
        '
        Me.pnlCargar.Controls.Add(Me.btnImportarDatos)
        Me.pnlCargar.Controls.Add(Me.lblCargarDatos)
        Me.pnlCargar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCargar.Location = New System.Drawing.Point(270, 0)
        Me.pnlCargar.Name = "pnlCargar"
        Me.pnlCargar.Size = New System.Drawing.Size(66, 69)
        Me.pnlCargar.TabIndex = 109
        '
        'btnImportarDatos
        '
        Me.btnImportarDatos.Image = CType(resources.GetObject("btnImportarDatos.Image"), System.Drawing.Image)
        Me.btnImportarDatos.Location = New System.Drawing.Point(19, 7)
        Me.btnImportarDatos.Name = "btnImportarDatos"
        Me.btnImportarDatos.Size = New System.Drawing.Size(31, 32)
        Me.btnImportarDatos.TabIndex = 10
        Me.btnImportarDatos.UseVisualStyleBackColor = True
        '
        'lblCargarDatos
        '
        Me.lblCargarDatos.AutoSize = True
        Me.lblCargarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarDatos.Location = New System.Drawing.Point(14, 42)
        Me.lblCargarDatos.Name = "lblCargarDatos"
        Me.lblCargarDatos.Size = New System.Drawing.Size(48, 26)
        Me.lblCargarDatos.TabIndex = 8
        Me.lblCargarDatos.Text = "Importar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Datos"
        Me.lblCargarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLayout
        '
        Me.pnlLayout.Controls.Add(Me.btnLayout)
        Me.pnlLayout.Controls.Add(Me.lblLayout)
        Me.pnlLayout.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLayout.Location = New System.Drawing.Point(204, 0)
        Me.pnlLayout.Name = "pnlLayout"
        Me.pnlLayout.Size = New System.Drawing.Size(66, 69)
        Me.pnlLayout.TabIndex = 108
        '
        'btnLayout
        '
        Me.btnLayout.Image = CType(resources.GetObject("btnLayout.Image"), System.Drawing.Image)
        Me.btnLayout.Location = New System.Drawing.Point(19, 7)
        Me.btnLayout.Name = "btnLayout"
        Me.btnLayout.Size = New System.Drawing.Size(31, 32)
        Me.btnLayout.TabIndex = 10
        Me.btnLayout.UseVisualStyleBackColor = True
        '
        'lblLayout
        '
        Me.lblLayout.AutoSize = True
        Me.lblLayout.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLayout.Location = New System.Drawing.Point(10, 42)
        Me.lblLayout.Name = "lblLayout"
        Me.lblLayout.Size = New System.Drawing.Size(49, 26)
        Me.lblLayout.TabIndex = 8
        Me.lblLayout.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Layout"
        Me.lblLayout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(138, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(66, 69)
        Me.pnlExportar.TabIndex = 107
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(19, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 10
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(13, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 8
        Me.lblExportar.Text = "Exportar"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblImprimir)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(66, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(72, 69)
        Me.pnlImprimir.TabIndex = 106
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(21, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(15, 42)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 3
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlCalcular
        '
        Me.pnlCalcular.Controls.Add(Me.btnCalcular)
        Me.pnlCalcular.Controls.Add(Me.Label2)
        Me.pnlCalcular.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCalcular.Enabled = False
        Me.pnlCalcular.Location = New System.Drawing.Point(0, 0)
        Me.pnlCalcular.Name = "pnlCalcular"
        Me.pnlCalcular.Size = New System.Drawing.Size(66, 69)
        Me.pnlCalcular.TabIndex = 10
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Contabilidad.Vista.My.Resources.Resources.calculo_32
        Me.btnCalcular.Location = New System.Drawing.Point(19, 7)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(31, 32)
        Me.btnCalcular.TabIndex = 10
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Calcular"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblEncabezado)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(622, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 69)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(48, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(276, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Acumulado de Sueldos y Salarios"
        '
        'gpbFiltro
        '
        Me.gpbFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbFiltro.Controls.Add(Me.rdoCalculo)
        Me.gpbFiltro.Controls.Add(Me.rdoAcumulado)
        Me.gpbFiltro.Controls.Add(Me.lblReporte)
        Me.gpbFiltro.Controls.Add(Me.lblPeriodoAl)
        Me.gpbFiltro.Controls.Add(Me.lblPeriodoDel)
        Me.gpbFiltro.Controls.Add(Me.cmbPeriodoAl)
        Me.gpbFiltro.Controls.Add(Me.cmbPeriodoDel)
        Me.gpbFiltro.Controls.Add(Me.txtAnio)
        Me.gpbFiltro.Controls.Add(Me.lblAnio)
        Me.gpbFiltro.Controls.Add(Me.pnlArchivoCargado)
        Me.gpbFiltro.Controls.Add(Me.btnSeleccionarColaborador)
        Me.gpbFiltro.Controls.Add(Me.txtNombre)
        Me.gpbFiltro.Controls.Add(Me.Label14)
        Me.gpbFiltro.Controls.Add(Me.Panel10)
        Me.gpbFiltro.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltro.Controls.Add(Me.cmbPatron)
        Me.gpbFiltro.Controls.Add(Me.lblPatron)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 69)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(1020, 131)
        Me.gpbFiltro.TabIndex = 31
        Me.gpbFiltro.TabStop = False
        '
        'rdoCalculo
        '
        Me.rdoCalculo.AutoSize = True
        Me.rdoCalculo.Location = New System.Drawing.Point(716, 46)
        Me.rdoCalculo.Name = "rdoCalculo"
        Me.rdoCalculo.Size = New System.Drawing.Size(60, 17)
        Me.rdoCalculo.TabIndex = 152
        Me.rdoCalculo.Text = "Cálculo"
        Me.rdoCalculo.UseVisualStyleBackColor = True
        '
        'rdoAcumulado
        '
        Me.rdoAcumulado.AutoSize = True
        Me.rdoAcumulado.Checked = True
        Me.rdoAcumulado.Location = New System.Drawing.Point(634, 46)
        Me.rdoAcumulado.Name = "rdoAcumulado"
        Me.rdoAcumulado.Size = New System.Drawing.Size(78, 17)
        Me.rdoAcumulado.TabIndex = 151
        Me.rdoAcumulado.TabStop = True
        Me.rdoAcumulado.Text = "Acumulado"
        Me.rdoAcumulado.UseVisualStyleBackColor = True
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.ForeColor = System.Drawing.Color.Black
        Me.lblReporte.Location = New System.Drawing.Point(577, 48)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(52, 13)
        Me.lblReporte.TabIndex = 150
        Me.lblReporte.Text = "Reporte *"
        '
        'lblPeriodoAl
        '
        Me.lblPeriodoAl.AutoSize = True
        Me.lblPeriodoAl.Location = New System.Drawing.Point(13, 76)
        Me.lblPeriodoAl.Name = "lblPeriodoAl"
        Me.lblPeriodoAl.Size = New System.Drawing.Size(62, 13)
        Me.lblPeriodoAl.TabIndex = 149
        Me.lblPeriodoAl.Text = "Periodo Al *"
        '
        'lblPeriodoDel
        '
        Me.lblPeriodoDel.AutoSize = True
        Me.lblPeriodoDel.Location = New System.Drawing.Point(13, 48)
        Me.lblPeriodoDel.Name = "lblPeriodoDel"
        Me.lblPeriodoDel.Size = New System.Drawing.Size(69, 13)
        Me.lblPeriodoDel.TabIndex = 148
        Me.lblPeriodoDel.Text = "Periodo Del *"
        '
        'cmbPeriodoAl
        '
        Me.cmbPeriodoAl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoAl.FormattingEnabled = True
        Me.cmbPeriodoAl.Location = New System.Drawing.Point(90, 72)
        Me.cmbPeriodoAl.Name = "cmbPeriodoAl"
        Me.cmbPeriodoAl.Size = New System.Drawing.Size(471, 21)
        Me.cmbPeriodoAl.TabIndex = 147
        '
        'cmbPeriodoDel
        '
        Me.cmbPeriodoDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoDel.FormattingEnabled = True
        Me.cmbPeriodoDel.Location = New System.Drawing.Point(90, 44)
        Me.cmbPeriodoDel.Name = "cmbPeriodoDel"
        Me.cmbPeriodoDel.Size = New System.Drawing.Size(471, 21)
        Me.cmbPeriodoDel.TabIndex = 146
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(513, 16)
        Me.txtAnio.MaxLength = 4
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(48, 20)
        Me.txtAnio.TabIndex = 2
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(481, 20)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(33, 13)
        Me.lblAnio.TabIndex = 145
        Me.lblAnio.Text = "Año *"
        '
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = CType(resources.GetObject("pnlArchivoCargado.BackgroundImage"), System.Drawing.Image)
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(412, 102)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 144
        Me.pnlArchivoCargado.Visible = False
        '
        'btnSeleccionarColaborador
        '
        Me.btnSeleccionarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarColaborador.Image = CType(resources.GetObject("btnSeleccionarColaborador.Image"), System.Drawing.Image)
        Me.btnSeleccionarColaborador.Location = New System.Drawing.Point(374, 95)
        Me.btnSeleccionarColaborador.Name = "btnSeleccionarColaborador"
        Me.btnSeleccionarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarColaborador.TabIndex = 6
        Me.btnSeleccionarColaborador.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(90, 101)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(275, 20)
        Me.txtNombre.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnMostrarAcumulado)
        Me.Panel10.Controls.Add(Me.lblBuscar)
        Me.Panel10.Controls.Add(Me.btnLimpiar)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(844, 16)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(108, 112)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(52, 57)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnMostrarAcumulado
        '
        Me.btnMostrarAcumulado.Image = CType(resources.GetObject("btnMostrarAcumulado.Image"), System.Drawing.Image)
        Me.btnMostrarAcumulado.Location = New System.Drawing.Point(14, 22)
        Me.btnMostrarAcumulado.Name = "btnMostrarAcumulado"
        Me.btnMostrarAcumulado.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarAcumulado.TabIndex = 7
        Me.btnMostrarAcumulado.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(9, 57)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(56, 22)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 8
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(952, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 112)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(90, 17)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(385, 21)
        Me.cmbPatron.TabIndex = 1
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.ForeColor = System.Drawing.Color.Black
        Me.lblPatron.Location = New System.Drawing.Point(13, 21)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(45, 13)
        Me.lblPatron.TabIndex = 25
        Me.lblPatron.Text = "Patrón *"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.DataGridView1)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 460)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 65)
        Me.pnlEstado.TabIndex = 32
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(722, 89)
        Me.DataGridView1.TabIndex = 38
        Me.DataGridView1.Visible = False
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.pnlGuardar)
        Me.pnlOperaciones.Controls.Add(Me.pnlCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(740, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(280, 65)
        Me.pnlOperaciones.TabIndex = 37
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(160, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(60, 65)
        Me.pnlGuardar.TabIndex = 105
        Me.pnlGuardar.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(14, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(8, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 21
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(220, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(60, 65)
        Me.pnlCerrar.TabIndex = 104
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(14, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(13, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 21
        Me.lblCerrar.Text = "Cerrar"
        '
        'GridAcumuladoSS
        '
        Me.GridAcumuladoSS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAcumuladoSS.Location = New System.Drawing.Point(0, 200)
        Me.GridAcumuladoSS.MainView = Me.grdAcumuladoSS
        Me.GridAcumuladoSS.Name = "GridAcumuladoSS"
        Me.GridAcumuladoSS.Size = New System.Drawing.Size(1020, 260)
        Me.GridAcumuladoSS.TabIndex = 33
        Me.GridAcumuladoSS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdAcumuladoSS})
        '
        'grdAcumuladoSS
        '
        Me.grdAcumuladoSS.GridControl = Me.GridAcumuladoSS
        Me.grdAcumuladoSS.Name = "grdAcumuladoSS"
        Me.grdAcumuladoSS.OptionsView.ShowAutoFilterRow = True
        Me.grdAcumuladoSS.OptionsView.ShowFooter = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(326, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ReporteAcumuladosNominaFiscalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 525)
        Me.Controls.Add(Me.GridAcumuladoSS)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ReporteAcumuladosNominaFiscalForm"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAutorizarISR.ResumeLayout(False)
        Me.pnlAutorizarISR.PerformLayout()
        Me.pnlCargar.ResumeLayout(False)
        Me.pnlCargar.PerformLayout()
        Me.pnlLayout.ResumeLayout(False)
        Me.pnlLayout.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlCalcular.ResumeLayout(False)
        Me.pnlCalcular.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.gpbFiltro.ResumeLayout(False)
        Me.gpbFiltro.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlEstado.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        CType(Me.GridAcumuladoSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAcumuladoSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnMostrarAcumulado As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbPatron As System.Windows.Forms.ComboBox
    Friend WithEvents lblPatron As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents GridAcumuladoSS As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdAcumuladoSS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSeleccionarColaborador As System.Windows.Forms.Button
    Friend WithEvents pnlArchivoCargado As System.Windows.Forms.Panel
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents txtAnio As System.Windows.Forms.TextBox
    Friend WithEvents pnlCerrar As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoAl As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoDel As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoAl As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodoDel As System.Windows.Forms.ComboBox
    Friend WithEvents rdoCalculo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAcumulado As System.Windows.Forms.RadioButton
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents pnlGuardar As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCalcular As Windows.Forms.Panel
    Friend WithEvents btnCalcular As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents pnlAutorizarISR As Windows.Forms.Panel
    Friend WithEvents btnAutorizarISR As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlCargar As Windows.Forms.Panel
    Friend WithEvents btnImportarDatos As Windows.Forms.Button
    Friend WithEvents lblCargarDatos As Windows.Forms.Label
    Friend WithEvents pnlLayout As Windows.Forms.Panel
    Friend WithEvents btnLayout As Windows.Forms.Button
    Friend WithEvents lblLayout As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblImprimir As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
