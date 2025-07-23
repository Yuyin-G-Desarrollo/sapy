<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaPrestamosForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPrestamosForm))
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Seleccion")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblHeader = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnPrestacion = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnPrestamoEspecial = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConsultaAbono = New System.Windows.Forms.Button()
        Me.lblAbonoExtraoridinario = New System.Windows.Forms.Label()
        Me.btnAbonoExtraordinario = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNuevoPrestamo = New System.Windows.Forms.Button()
        Me.lblEditarAbono = New System.Windows.Forms.Label()
        Me.btnEditarAbono = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.lblFechadel = New System.Windows.Forms.Label()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.DtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblestatus = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.chkSaldoTermino = New System.Windows.Forms.CheckBox()
        Me.pnlTipoBusqueda = New System.Windows.Forms.Panel()
        Me.rdbFehcaEntrega = New System.Windows.Forms.RadioButton()
        Me.rdbFechaSolicitud = New System.Windows.Forms.RadioButton()
        Me.pnlPeriodoBusqueda = New System.Windows.Forms.Panel()
        Me.rdbRango = New System.Windows.Forms.RadioButton()
        Me.rdbPeriodo = New System.Windows.Forms.RadioButton()
        Me.cmbPeriodoNomina = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblDirector = New System.Windows.Forms.Label()
        Me.lblGerente = New System.Windows.Forms.Label()
        Me.pnColores = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCancelado = New System.Windows.Forms.Panel()
        Me.pnlEntregadoColaborador = New System.Windows.Forms.Panel()
        Me.pnlRGerente = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlLiquidado = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlCobranza = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.btnAutorizarPrestamo = New System.Windows.Forms.Button()
        Me.lblAutorizarPrestamo = New System.Windows.Forms.Label()
        Me.lblRechazarPrestamo = New System.Windows.Forms.Label()
        Me.btnRechazarPrestamo = New System.Windows.Forms.Button()
        Me.lblDevolverDinero = New System.Windows.Forms.Label()
        Me.btnDevolverDinero = New System.Windows.Forms.Button()
        Me.lblAlertaSinCaja = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCajas = New System.Windows.Forms.ComboBox()
        Me.lblSolicitar = New System.Windows.Forms.Label()
        Me.lblEntregar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnEntregaColaborador = New System.Windows.Forms.Button()
        Me.btnSolicitarFinanzas = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlEntregadoNave = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlSolicitadoFinanzas = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlSolicitado = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAGerente = New System.Windows.Forms.Panel()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.grdDatosPrestamos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuReporte = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConcentradoPréstamosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteAbonosExtraordinariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAyudaReportes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlTipoBusqueda.SuspendLayout()
        Me.pnlPeriodoBusqueda.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnColores.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuReporte.SuspendLayout()
        Me.menuAyudaReportes.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.White
        Me.lblHeader.Controls.Add(Me.Label19)
        Me.lblHeader.Controls.Add(Me.btnAyuda)
        Me.lblHeader.Controls.Add(Me.Label15)
        Me.lblHeader.Controls.Add(Me.btnPrestacion)
        Me.lblHeader.Controls.Add(Me.Label13)
        Me.lblHeader.Controls.Add(Me.btnPrestamoEspecial)
        Me.lblHeader.Controls.Add(Me.btnExportar)
        Me.lblHeader.Controls.Add(Me.lblExportar)
        Me.lblHeader.Controls.Add(Me.Label3)
        Me.lblHeader.Controls.Add(Me.btnConsultaAbono)
        Me.lblHeader.Controls.Add(Me.lblAbonoExtraoridinario)
        Me.lblHeader.Controls.Add(Me.btnAbonoExtraordinario)
        Me.lblHeader.Controls.Add(Me.Label1)
        Me.lblHeader.Controls.Add(Me.btnNuevoPrestamo)
        Me.lblHeader.Controls.Add(Me.lblEditarAbono)
        Me.lblHeader.Controls.Add(Me.btnEditarAbono)
        Me.lblHeader.Controls.Add(Me.lblReporte)
        Me.lblHeader.Controls.Add(Me.pnlTitulo)
        Me.lblHeader.Controls.Add(Me.btnReporte)
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(1251, 67)
        Me.lblHeader.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label19.Location = New System.Drawing.Point(863, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Ayuda"
        '
        'btnAyuda
        '
        Me.btnAyuda.Enabled = False
        Me.btnAyuda.Image = Global.Nomina.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.Location = New System.Drawing.Point(865, 6)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 53
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label15.Location = New System.Drawing.Point(737, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Nueva Prestación"
        '
        'btnPrestacion
        '
        Me.btnPrestacion.Enabled = False
        Me.btnPrestacion.Image = Global.Nomina.Vista.My.Resources.Resources.nomina_321
        Me.btnPrestacion.Location = New System.Drawing.Point(762, 6)
        Me.btnPrestacion.Name = "btnPrestacion"
        Me.btnPrestacion.Size = New System.Drawing.Size(32, 32)
        Me.btnPrestacion.TabIndex = 51
        Me.btnPrestacion.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(615, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Préstamo Especial"
        '
        'btnPrestamoEspecial
        '
        Me.btnPrestamoEspecial.Enabled = False
        Me.btnPrestamoEspecial.Image = Global.Nomina.Vista.My.Resources.Resources.nuevo_32
        Me.btnPrestamoEspecial.Location = New System.Drawing.Point(641, 6)
        Me.btnPrestamoEspecial.Name = "btnPrestamoEspecial"
        Me.btnPrestamoEspecial.Size = New System.Drawing.Size(32, 32)
        Me.btnPrestamoEspecial.TabIndex = 49
        Me.btnPrestamoEspecial.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(539, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 48
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(533, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 47
        Me.lblExportar.Text = "Exportar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(317, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Consultar Abonos"
        '
        'btnConsultaAbono
        '
        Me.btnConsultaAbono.Image = Global.Nomina.Vista.My.Resources.Resources.fichaColaborador_32
        Me.btnConsultaAbono.Location = New System.Drawing.Point(346, 6)
        Me.btnConsultaAbono.Name = "btnConsultaAbono"
        Me.btnConsultaAbono.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultaAbono.TabIndex = 45
        Me.btnConsultaAbono.UseVisualStyleBackColor = True
        '
        'lblAbonoExtraoridinario
        '
        Me.lblAbonoExtraoridinario.AutoSize = True
        Me.lblAbonoExtraoridinario.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAbonoExtraoridinario.Location = New System.Drawing.Point(197, 42)
        Me.lblAbonoExtraoridinario.Name = "lblAbonoExtraoridinario"
        Me.lblAbonoExtraoridinario.Size = New System.Drawing.Size(105, 13)
        Me.lblAbonoExtraoridinario.TabIndex = 44
        Me.lblAbonoExtraoridinario.Text = "Abono Extraordinario"
        '
        'btnAbonoExtraordinario
        '
        Me.btnAbonoExtraordinario.Enabled = False
        Me.btnAbonoExtraordinario.Image = Global.Nomina.Vista.My.Resources.Resources.finanzas_32
        Me.btnAbonoExtraordinario.Location = New System.Drawing.Point(233, 6)
        Me.btnAbonoExtraordinario.Name = "btnAbonoExtraordinario"
        Me.btnAbonoExtraordinario.Size = New System.Drawing.Size(32, 32)
        Me.btnAbonoExtraordinario.TabIndex = 43
        Me.btnAbonoExtraordinario.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(14, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Nuevo Préstamo"
        '
        'btnNuevoPrestamo
        '
        Me.btnNuevoPrestamo.Enabled = False
        Me.btnNuevoPrestamo.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnNuevoPrestamo.Location = New System.Drawing.Point(40, 6)
        Me.btnNuevoPrestamo.Name = "btnNuevoPrestamo"
        Me.btnNuevoPrestamo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevoPrestamo.TabIndex = 41
        Me.btnNuevoPrestamo.UseVisualStyleBackColor = True
        '
        'lblEditarAbono
        '
        Me.lblEditarAbono.AutoSize = True
        Me.lblEditarAbono.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEditarAbono.Location = New System.Drawing.Point(115, 42)
        Me.lblEditarAbono.Name = "lblEditarAbono"
        Me.lblEditarAbono.Size = New System.Drawing.Size(67, 13)
        Me.lblEditarAbono.TabIndex = 40
        Me.lblEditarAbono.Text = "Editar abono"
        '
        'btnEditarAbono
        '
        Me.btnEditarAbono.Enabled = False
        Me.btnEditarAbono.Image = Global.Nomina.Vista.My.Resources.Resources.editar_32
        Me.btnEditarAbono.Location = New System.Drawing.Point(132, 6)
        Me.btnEditarAbono.Name = "btnEditarAbono"
        Me.btnEditarAbono.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarAbono.TabIndex = 39
        Me.btnEditarAbono.UseVisualStyleBackColor = True
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblReporte.Location = New System.Drawing.Point(440, 41)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(42, 13)
        Me.lblReporte.TabIndex = 38
        Me.lblReporte.Text = "Imprimir"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(923, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(328, 67)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(52, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(163, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Lista de Préstamos"
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporte.Location = New System.Drawing.Point(442, 6)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.ForeColor = System.Drawing.Color.Black
        Me.lblAl.Location = New System.Drawing.Point(370, 8)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(16, 13)
        Me.lblAl.TabIndex = 26
        Me.lblAl.Text = "Al"
        '
        'lblFechadel
        '
        Me.lblFechadel.AutoSize = True
        Me.lblFechadel.ForeColor = System.Drawing.Color.Black
        Me.lblFechadel.Location = New System.Drawing.Point(102, 8)
        Me.lblFechadel.Name = "lblFechadel"
        Me.lblFechadel.Size = New System.Drawing.Size(54, 13)
        Me.lblFechadel.TabIndex = 25
        Me.lblFechadel.Text = "Fecha del"
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.Location = New System.Drawing.Point(391, 4)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(190, 20)
        Me.DtpFechaFin.TabIndex = 24
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.ForeColor = System.Drawing.Color.Black
        Me.chkFecha.Location = New System.Drawing.Point(528, 49)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(15, 14)
        Me.chkFecha.TabIndex = 23
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'DtpFechaInicio
        '
        Me.DtpFechaInicio.Location = New System.Drawing.Point(161, 4)
        Me.DtpFechaInicio.Name = "DtpFechaInicio"
        Me.DtpFechaInicio.Size = New System.Drawing.Size(190, 20)
        Me.DtpFechaInicio.TabIndex = 22
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "SOLICITADO CAJA CHICA", "DINERO ENTREGADO A NAVE", "DINERO ENTREGADO AL COLABORADOR", "REGRESADO A FINANZAS", "EN COBRANZA", "LIQUIDADO", "CANCELADO", "RECHAZADO"})
        Me.cmbEstatus.Location = New System.Drawing.Point(106, 74)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(258, 21)
        Me.cmbEstatus.TabIndex = 21
        '
        'lblestatus
        '
        Me.lblestatus.AutoSize = True
        Me.lblestatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblestatus.ForeColor = System.Drawing.Color.Black
        Me.lblestatus.Location = New System.Drawing.Point(39, 78)
        Me.lblestatus.Name = "lblestatus"
        Me.lblestatus.Size = New System.Drawing.Size(42, 13)
        Me.lblestatus.TabIndex = 20
        Me.lblestatus.Text = "Estatus"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(39, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 17
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(106, 46)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(258, 21)
        Me.cmbNave.TabIndex = 14
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.chboxSeleccionarTodo)
        Me.grbParametros.Controls.Add(Me.chkSaldoTermino)
        Me.grbParametros.Controls.Add(Me.pnlTipoBusqueda)
        Me.grbParametros.Controls.Add(Me.pnlPeriodoBusqueda)
        Me.grbParametros.Controls.Add(Me.lblPeriodo)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblDirector)
        Me.grbParametros.Controls.Add(Me.lblGerente)
        Me.grbParametros.Controls.Add(Me.lblestatus)
        Me.grbParametros.Controls.Add(Me.chkFecha)
        Me.grbParametros.Controls.Add(Me.cmbEstatus)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Location = New System.Drawing.Point(0, 67)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1251, 135)
        Me.grbParametros.TabIndex = 53
        Me.grbParametros.TabStop = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(6, 112)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 131
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'chkSaldoTermino
        '
        Me.chkSaldoTermino.AutoSize = True
        Me.chkSaldoTermino.ForeColor = System.Drawing.Color.Black
        Me.chkSaldoTermino.Location = New System.Drawing.Point(107, 109)
        Me.chkSaldoTermino.Name = "chkSaldoTermino"
        Me.chkSaldoTermino.Size = New System.Drawing.Size(105, 17)
        Me.chkSaldoTermino.TabIndex = 78
        Me.chkSaldoTermino.Text = "Saldo al Término"
        Me.chkSaldoTermino.UseVisualStyleBackColor = True
        Me.chkSaldoTermino.Visible = False
        '
        'pnlTipoBusqueda
        '
        Me.pnlTipoBusqueda.Controls.Add(Me.rdbFehcaEntrega)
        Me.pnlTipoBusqueda.Controls.Add(Me.rdbFechaSolicitud)
        Me.pnlTipoBusqueda.Location = New System.Drawing.Point(548, 45)
        Me.pnlTipoBusqueda.Name = "pnlTipoBusqueda"
        Me.pnlTipoBusqueda.Size = New System.Drawing.Size(337, 25)
        Me.pnlTipoBusqueda.TabIndex = 77
        '
        'rdbFehcaEntrega
        '
        Me.rdbFehcaEntrega.AutoSize = True
        Me.rdbFehcaEntrega.Enabled = False
        Me.rdbFehcaEntrega.ForeColor = System.Drawing.Color.Black
        Me.rdbFehcaEntrega.Location = New System.Drawing.Point(142, 4)
        Me.rdbFehcaEntrega.Name = "rdbFehcaEntrega"
        Me.rdbFehcaEntrega.Size = New System.Drawing.Size(110, 17)
        Me.rdbFehcaEntrega.TabIndex = 77
        Me.rdbFehcaEntrega.Text = "Fecha de Entrega"
        Me.rdbFehcaEntrega.UseVisualStyleBackColor = True
        '
        'rdbFechaSolicitud
        '
        Me.rdbFechaSolicitud.AutoSize = True
        Me.rdbFechaSolicitud.Checked = True
        Me.rdbFechaSolicitud.Enabled = False
        Me.rdbFechaSolicitud.ForeColor = System.Drawing.Color.Black
        Me.rdbFechaSolicitud.Location = New System.Drawing.Point(26, 5)
        Me.rdbFechaSolicitud.Name = "rdbFechaSolicitud"
        Me.rdbFechaSolicitud.Size = New System.Drawing.Size(113, 17)
        Me.rdbFechaSolicitud.TabIndex = 76
        Me.rdbFechaSolicitud.TabStop = True
        Me.rdbFechaSolicitud.Text = "Fecha de Solicitud"
        Me.rdbFechaSolicitud.UseVisualStyleBackColor = True
        '
        'pnlPeriodoBusqueda
        '
        Me.pnlPeriodoBusqueda.Controls.Add(Me.rdbRango)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.rdbPeriodo)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.lblFechadel)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.cmbPeriodoNomina)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.DtpFechaInicio)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.lblAl)
        Me.pnlPeriodoBusqueda.Controls.Add(Me.DtpFechaFin)
        Me.pnlPeriodoBusqueda.Enabled = False
        Me.pnlPeriodoBusqueda.Location = New System.Drawing.Point(443, 74)
        Me.pnlPeriodoBusqueda.Name = "pnlPeriodoBusqueda"
        Me.pnlPeriodoBusqueda.Size = New System.Drawing.Size(671, 55)
        Me.pnlPeriodoBusqueda.TabIndex = 76
        '
        'rdbRango
        '
        Me.rdbRango.AutoSize = True
        Me.rdbRango.Checked = True
        Me.rdbRango.ForeColor = System.Drawing.Color.Black
        Me.rdbRango.Location = New System.Drawing.Point(3, 4)
        Me.rdbRango.Name = "rdbRango"
        Me.rdbRango.Size = New System.Drawing.Size(57, 17)
        Me.rdbRango.TabIndex = 74
        Me.rdbRango.TabStop = True
        Me.rdbRango.Text = "Rango"
        Me.rdbRango.UseVisualStyleBackColor = True
        '
        'rdbPeriodo
        '
        Me.rdbPeriodo.AutoSize = True
        Me.rdbPeriodo.ForeColor = System.Drawing.Color.Black
        Me.rdbPeriodo.Location = New System.Drawing.Point(3, 29)
        Me.rdbPeriodo.Name = "rdbPeriodo"
        Me.rdbPeriodo.Size = New System.Drawing.Size(61, 17)
        Me.rdbPeriodo.TabIndex = 75
        Me.rdbPeriodo.Text = "Periodo"
        Me.rdbPeriodo.UseVisualStyleBackColor = True
        '
        'cmbPeriodoNomina
        '
        Me.cmbPeriodoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoNomina.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodoNomina.FormattingEnabled = True
        Me.cmbPeriodoNomina.Location = New System.Drawing.Point(105, 28)
        Me.cmbPeriodoNomina.Name = "cmbPeriodoNomina"
        Me.cmbPeriodoNomina.Size = New System.Drawing.Size(478, 21)
        Me.cmbPeriodoNomina.TabIndex = 72
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPeriodo.Location = New System.Drawing.Point(440, 49)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(82, 13)
        Me.lblPeriodo.TabIndex = 73
        Me.lblPeriodo.Text = "Filtro por fechas"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1144, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(104, 116)
        Me.pnlMinimizarParametros.TabIndex = 54
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(55, 45)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 65
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(53, 80)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 64
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblBuscar.Location = New System.Drawing.Point(1, 80)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 44
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(4, 45)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 43
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(41, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(67, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblDirector
        '
        Me.lblDirector.AutoSize = True
        Me.lblDirector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirector.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDirector.Location = New System.Drawing.Point(1058, 24)
        Me.lblDirector.Name = "lblDirector"
        Me.lblDirector.Size = New System.Drawing.Size(80, 16)
        Me.lblDirector.TabIndex = 15
        Me.lblDirector.Text = "lblDirector"
        Me.lblDirector.Visible = False
        '
        'lblGerente
        '
        Me.lblGerente.AutoSize = True
        Me.lblGerente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGerente.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblGerente.Location = New System.Drawing.Point(972, 24)
        Me.lblGerente.Name = "lblGerente"
        Me.lblGerente.Size = New System.Drawing.Size(80, 16)
        Me.lblGerente.TabIndex = 16
        Me.lblGerente.Text = "lblGerente"
        Me.lblGerente.Visible = False
        '
        'pnColores
        '
        Me.pnColores.BackColor = System.Drawing.Color.White
        Me.pnColores.Controls.Add(Me.Label17)
        Me.pnColores.Controls.Add(Me.Label16)
        Me.pnColores.Controls.Add(Me.Panel3)
        Me.pnColores.Controls.Add(Me.Panel2)
        Me.pnColores.Controls.Add(Me.Label5)
        Me.pnColores.Controls.Add(Me.Panel1)
        Me.pnColores.Controls.Add(Me.pnlCancelado)
        Me.pnColores.Controls.Add(Me.pnlEntregadoColaborador)
        Me.pnColores.Controls.Add(Me.pnlRGerente)
        Me.pnColores.Controls.Add(Me.Label14)
        Me.pnColores.Controls.Add(Me.Label10)
        Me.pnColores.Controls.Add(Me.Label4)
        Me.pnColores.Controls.Add(Me.pnlLiquidado)
        Me.pnColores.Controls.Add(Me.Label11)
        Me.pnColores.Controls.Add(Me.pnlCobranza)
        Me.pnColores.Controls.Add(Me.Label12)
        Me.pnColores.Controls.Add(Me.Panel4)
        Me.pnColores.Controls.Add(Me.pnlEntregadoNave)
        Me.pnColores.Controls.Add(Me.Label8)
        Me.pnColores.Controls.Add(Me.pnlSolicitadoFinanzas)
        Me.pnColores.Controls.Add(Me.Label7)
        Me.pnColores.Controls.Add(Me.pnlSolicitado)
        Me.pnColores.Controls.Add(Me.Label6)
        Me.pnColores.Controls.Add(Me.Label9)
        Me.pnColores.Controls.Add(Me.pnlAGerente)
        Me.pnColores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnColores.Location = New System.Drawing.Point(0, 487)
        Me.pnColores.Name = "pnColores"
        Me.pnColores.Size = New System.Drawing.Size(1251, 69)
        Me.pnColores.TabIndex = 54
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(475, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 13)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Prestación SAY"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(475, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Prestamo Especial"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel3.Location = New System.Drawing.Point(459, 42)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(459, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(310, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Dinero Regresado a Finanzas"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel1.Location = New System.Drawing.Point(292, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(15, 15)
        Me.Panel1.TabIndex = 41
        '
        'pnlCancelado
        '
        Me.pnlCancelado.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.pnlCancelado.Location = New System.Drawing.Point(459, 5)
        Me.pnlCancelado.Name = "pnlCancelado"
        Me.pnlCancelado.Size = New System.Drawing.Size(15, 15)
        Me.pnlCancelado.TabIndex = 39
        '
        'pnlEntregadoColaborador
        '
        Me.pnlEntregadoColaborador.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(13, Byte), Integer))
        Me.pnlEntregadoColaborador.Location = New System.Drawing.Point(106, 43)
        Me.pnlEntregadoColaborador.Name = "pnlEntregadoColaborador"
        Me.pnlEntregadoColaborador.Size = New System.Drawing.Size(15, 15)
        Me.pnlEntregadoColaborador.TabIndex = 33
        '
        'pnlRGerente
        '
        Me.pnlRGerente.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.pnlRGerente.Location = New System.Drawing.Point(19, 43)
        Me.pnlRGerente.Name = "pnlRGerente"
        Me.pnlRGerente.Size = New System.Drawing.Size(15, 15)
        Me.pnlRGerente.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Rechazado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(475, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Cancelado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(124, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Dinero Entregado al Colaborador"
        '
        'pnlLiquidado
        '
        Me.pnlLiquidado.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.pnlLiquidado.Location = New System.Drawing.Point(292, 44)
        Me.pnlLiquidado.Name = "pnlLiquidado"
        Me.pnlLiquidado.Size = New System.Drawing.Size(15, 15)
        Me.pnlLiquidado.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(310, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Liquidado"
        '
        'pnlCobranza
        '
        Me.pnlCobranza.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.pnlCobranza.Location = New System.Drawing.Point(292, 25)
        Me.pnlCobranza.Name = "pnlCobranza"
        Me.pnlCobranza.Size = New System.Drawing.Size(15, 15)
        Me.pnlCobranza.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(310, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "En Cobranza"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.lblTotalSeleccionados)
        Me.Panel4.Controls.Add(Me.btnAutorizarPrestamo)
        Me.Panel4.Controls.Add(Me.lblAutorizarPrestamo)
        Me.Panel4.Controls.Add(Me.lblRechazarPrestamo)
        Me.Panel4.Controls.Add(Me.btnRechazarPrestamo)
        Me.Panel4.Controls.Add(Me.lblDevolverDinero)
        Me.Panel4.Controls.Add(Me.btnDevolverDinero)
        Me.Panel4.Controls.Add(Me.lblAlertaSinCaja)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cmbCajas)
        Me.Panel4.Controls.Add(Me.lblSolicitar)
        Me.Panel4.Controls.Add(Me.lblEntregar)
        Me.Panel4.Controls.Add(Me.lblCerrar)
        Me.Panel4.Controls.Add(Me.btnEntregaColaborador)
        Me.Panel4.Controls.Add(Me.btnSolicitarFinanzas)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(574, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(677, 69)
        Me.Panel4.TabIndex = 34
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 32)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Artículos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(51, 43)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 75
        Me.lblTotalSeleccionados.Text = "0"
        '
        'btnAutorizarPrestamo
        '
        Me.btnAutorizarPrestamo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAutorizarPrestamo.Enabled = False
        Me.btnAutorizarPrestamo.Location = New System.Drawing.Point(522, 9)
        Me.btnAutorizarPrestamo.Name = "btnAutorizarPrestamo"
        Me.btnAutorizarPrestamo.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizarPrestamo.TabIndex = 1
        Me.btnAutorizarPrestamo.UseVisualStyleBackColor = True
        '
        'lblAutorizarPrestamo
        '
        Me.lblAutorizarPrestamo.AutoSize = True
        Me.lblAutorizarPrestamo.Enabled = False
        Me.lblAutorizarPrestamo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizarPrestamo.Location = New System.Drawing.Point(515, 41)
        Me.lblAutorizarPrestamo.Name = "lblAutorizarPrestamo"
        Me.lblAutorizarPrestamo.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizarPrestamo.TabIndex = 3
        Me.lblAutorizarPrestamo.Text = "Autorizar"
        '
        'lblRechazarPrestamo
        '
        Me.lblRechazarPrestamo.AutoSize = True
        Me.lblRechazarPrestamo.Enabled = False
        Me.lblRechazarPrestamo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazarPrestamo.Location = New System.Drawing.Point(565, 41)
        Me.lblRechazarPrestamo.Name = "lblRechazarPrestamo"
        Me.lblRechazarPrestamo.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazarPrestamo.TabIndex = 4
        Me.lblRechazarPrestamo.Text = "Rechazar"
        '
        'btnRechazarPrestamo
        '
        Me.btnRechazarPrestamo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazarPrestamo.Enabled = False
        Me.btnRechazarPrestamo.Location = New System.Drawing.Point(574, 9)
        Me.btnRechazarPrestamo.Name = "btnRechazarPrestamo"
        Me.btnRechazarPrestamo.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazarPrestamo.TabIndex = 2
        Me.btnRechazarPrestamo.UseVisualStyleBackColor = True
        '
        'lblDevolverDinero
        '
        Me.lblDevolverDinero.AutoSize = True
        Me.lblDevolverDinero.Enabled = False
        Me.lblDevolverDinero.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDevolverDinero.Location = New System.Drawing.Point(461, 41)
        Me.lblDevolverDinero.Name = "lblDevolverDinero"
        Me.lblDevolverDinero.Size = New System.Drawing.Size(53, 26)
        Me.lblDevolverDinero.TabIndex = 47
        Me.lblDevolverDinero.Text = "Devolver " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dinero" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblDevolverDinero.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDevolverDinero
        '
        Me.btnDevolverDinero.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.colaboradornomina_32
        Me.btnDevolverDinero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDevolverDinero.Enabled = False
        Me.btnDevolverDinero.Location = New System.Drawing.Point(470, 9)
        Me.btnDevolverDinero.Name = "btnDevolverDinero"
        Me.btnDevolverDinero.Size = New System.Drawing.Size(32, 32)
        Me.btnDevolverDinero.TabIndex = 7
        Me.btnDevolverDinero.UseVisualStyleBackColor = True
        '
        'lblAlertaSinCaja
        '
        Me.lblAlertaSinCaja.AutoSize = True
        Me.lblAlertaSinCaja.ForeColor = System.Drawing.Color.Red
        Me.lblAlertaSinCaja.Location = New System.Drawing.Point(146, 24)
        Me.lblAlertaSinCaja.Name = "lblAlertaSinCaja"
        Me.lblAlertaSinCaja.Size = New System.Drawing.Size(168, 13)
        Me.lblAlertaSinCaja.TabIndex = 46
        Me.lblAlertaSinCaja.Text = "No tiene cajas registradas en SAY"
        Me.lblAlertaSinCaja.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(79, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColor = System.Drawing.Color.Black
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "RECHAZADO", "SOLICITADO A CAJA CHICA", "PAGADO"})
        Me.cmbCajas.Location = New System.Drawing.Point(142, 20)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(211, 21)
        Me.cmbCajas.TabIndex = 45
        '
        'lblSolicitar
        '
        Me.lblSolicitar.AutoSize = True
        Me.lblSolicitar.Enabled = False
        Me.lblSolicitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSolicitar.Location = New System.Drawing.Point(359, 41)
        Me.lblSolicitar.Name = "lblSolicitar"
        Me.lblSolicitar.Size = New System.Drawing.Size(44, 13)
        Me.lblSolicitar.TabIndex = 5
        Me.lblSolicitar.Text = "Solicitar"
        '
        'lblEntregar
        '
        Me.lblEntregar.AutoSize = True
        Me.lblEntregar.Enabled = False
        Me.lblEntregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEntregar.Location = New System.Drawing.Point(412, 41)
        Me.lblEntregar.Name = "lblEntregar"
        Me.lblEntregar.Size = New System.Drawing.Size(47, 13)
        Me.lblEntregar.TabIndex = 7
        Me.lblEntregar.Text = "Entregar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(633, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 6
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnEntregaColaborador
        '
        Me.btnEntregaColaborador.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.autorizar_32
        Me.btnEntregaColaborador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEntregaColaborador.Enabled = False
        Me.btnEntregaColaborador.Location = New System.Drawing.Point(418, 9)
        Me.btnEntregaColaborador.Name = "btnEntregaColaborador"
        Me.btnEntregaColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnEntregaColaborador.TabIndex = 6
        Me.btnEntregaColaborador.UseVisualStyleBackColor = True
        '
        'btnSolicitarFinanzas
        '
        Me.btnSolicitarFinanzas.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.prestamos_32
        Me.btnSolicitarFinanzas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSolicitarFinanzas.Enabled = False
        Me.btnSolicitarFinanzas.Location = New System.Drawing.Point(366, 9)
        Me.btnSolicitarFinanzas.Name = "btnSolicitarFinanzas"
        Me.btnSolicitarFinanzas.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitarFinanzas.TabIndex = 4
        Me.btnSolicitarFinanzas.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(634, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlEntregadoNave
        '
        Me.pnlEntregadoNave.BackColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.pnlEntregadoNave.Location = New System.Drawing.Point(107, 24)
        Me.pnlEntregadoNave.Name = "pnlEntregadoNave"
        Me.pnlEntregadoNave.Size = New System.Drawing.Size(15, 15)
        Me.pnlEntregadoNave.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(125, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Dinero Entregado a Nave"
        '
        'pnlSolicitadoFinanzas
        '
        Me.pnlSolicitadoFinanzas.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.pnlSolicitadoFinanzas.Location = New System.Drawing.Point(107, 5)
        Me.pnlSolicitadoFinanzas.Name = "pnlSolicitadoFinanzas"
        Me.pnlSolicitadoFinanzas.Size = New System.Drawing.Size(15, 15)
        Me.pnlSolicitadoFinanzas.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Solicitado a CajaChica"
        '
        'pnlSolicitado
        '
        Me.pnlSolicitado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.pnlSolicitado.Location = New System.Drawing.Point(19, 5)
        Me.pnlSolicitado.Name = "pnlSolicitado"
        Me.pnlSolicitado.Size = New System.Drawing.Size(15, 15)
        Me.pnlSolicitado.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(37, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Solicitado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(37, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Autorizado"
        '
        'pnlAGerente
        '
        Me.pnlAGerente.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.pnlAGerente.Location = New System.Drawing.Point(19, 24)
        Me.pnlAGerente.Name = "pnlAGerente"
        Me.pnlAGerente.Size = New System.Drawing.Size(15, 15)
        Me.pnlAGerente.TabIndex = 17
        '
        'UltraDataSource1
        '
        UltraDataColumn1.DataType = GetType(Byte)
        UltraDataColumn1.ReadOnly = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1})
        '
        'grdDatosPrestamos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosPrestamos.DisplayLayout.Appearance = Appearance1
        Me.grdDatosPrestamos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdDatosPrestamos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatosPrestamos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row
        Me.grdDatosPrestamos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdDatosPrestamos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDatosPrestamos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatosPrestamos.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdDatosPrestamos.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Me.grdDatosPrestamos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosPrestamos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatosPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosPrestamos.Location = New System.Drawing.Point(0, 202)
        Me.grdDatosPrestamos.Name = "grdDatosPrestamos"
        Me.grdDatosPrestamos.Size = New System.Drawing.Size(1251, 285)
        Me.grdDatosPrestamos.TabIndex = 55
        Me.grdDatosPrestamos.Text = "Prestamos"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "idPrestamo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Colaborador"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.FillWeight = 250.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha solicitud"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 250
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Puesto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn5.HeaderText = "Antiguedad"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn6.HeaderText = "Faltas ultimo mes"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 40
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn7.HeaderText = "Caja de ahorro"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 40
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn8.HeaderText = "Tasa de Interés"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "c2"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn9.HeaderText = "Tipo de Interés"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn10.FillWeight = 60.0!
        Me.DataGridViewTextBoxColumn10.HeaderText = "Abono"
        Me.DataGridViewTextBoxColumn10.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn11.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 105
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn12.HeaderText = "Semanas"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 63
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn13.HeaderText = "Prestamo autorizado"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 50
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn14.HeaderText = "estatus"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 60
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn15.HeaderText = "idColaborador"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 80
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn16.HeaderText = "Fecha aprobacion gerente"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Fecha aprobacion director"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 97
        '
        'DataGridViewTextBoxColumn18
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn18.HeaderText = "FechaModifico"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 112
        '
        'DataGridViewTextBoxColumn19
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn19.HeaderText = "Fecha Aprobación Director"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 112
        '
        'DataGridViewTextBoxColumn20
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn20.HeaderText = "Fecha Modificó"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 96
        '
        'menuReporte
        '
        Me.menuReporte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConcentradoPréstamosToolStripMenuItem, Me.ReporteAbonosExtraordinariosToolStripMenuItem, Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem, Me.ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem})
        Me.menuReporte.Name = "menuReporte"
        Me.menuReporte.Size = New System.Drawing.Size(357, 92)
        '
        'ConcentradoPréstamosToolStripMenuItem
        '
        Me.ConcentradoPréstamosToolStripMenuItem.Name = "ConcentradoPréstamosToolStripMenuItem"
        Me.ConcentradoPréstamosToolStripMenuItem.Size = New System.Drawing.Size(356, 22)
        Me.ConcentradoPréstamosToolStripMenuItem.Text = "Reporte Concentrado Préstamos"
        '
        'ReporteAbonosExtraordinariosToolStripMenuItem
        '
        Me.ReporteAbonosExtraordinariosToolStripMenuItem.Name = "ReporteAbonosExtraordinariosToolStripMenuItem"
        Me.ReporteAbonosExtraordinariosToolStripMenuItem.Size = New System.Drawing.Size(356, 22)
        Me.ReporteAbonosExtraordinariosToolStripMenuItem.Text = "Reporte Abonos Extraordinarios"
        '
        'ReporteConcentradoPréstamosEInteresesToolStripMenuItem
        '
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Name = "ReporteConcentradoPréstamosEInteresesToolStripMenuItem"
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Size = New System.Drawing.Size(356, 22)
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Text = "Reporte Concentrado Préstamos e Intereses"
        '
        'ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem
        '
        Me.ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem.Name = "ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem"
        Me.ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem.Size = New System.Drawing.Size(356, 22)
        Me.ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem.Text = "Reporte Concentrado Préstamos Especiales y Prestaciones"
        '
        'menuAyudaReportes
        '
        Me.menuAyudaReportes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem})
        Me.menuAyudaReportes.Name = "menuAyudaReportes"
        Me.menuAyudaReportes.Size = New System.Drawing.Size(287, 26)
        '
        'AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem
        '
        Me.AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem.Name = "AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem"
        Me.AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem.Text = "Ayuda Préstamos Especiales y Prestaciones "
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(260, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 67)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 26
        Me.pcbTitulo.TabStop = False
        '
        'ListaPrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1251, 556)
        Me.Controls.Add(Me.grdDatosPrestamos)
        Me.Controls.Add(Me.pnColores)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaPrestamosForm"
        Me.Text = "Lista de Préstamos"
        Me.lblHeader.ResumeLayout(False)
        Me.lblHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlTipoBusqueda.ResumeLayout(False)
        Me.pnlTipoBusqueda.PerformLayout()
        Me.pnlPeriodoBusqueda.ResumeLayout(False)
        Me.pnlPeriodoBusqueda.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnColores.ResumeLayout(False)
        Me.pnColores.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuReporte.ResumeLayout(False)
        Me.menuAyudaReportes.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents lblFechadel As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkFecha As System.Windows.Forms.CheckBox
    Friend WithEvents DtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblestatus As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoNomina As System.Windows.Forms.ComboBox
    Friend WithEvents rdbPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRango As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEditarAbono As System.Windows.Forms.Label
    Friend WithEvents btnEditarAbono As System.Windows.Forms.Button
    Friend WithEvents btnNuevoPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblAbonoExtraoridinario As System.Windows.Forms.Label
    Friend WithEvents btnAbonoExtraordinario As System.Windows.Forms.Button
    Friend WithEvents pnColores As System.Windows.Forms.Panel
    Friend WithEvents btnSolicitarFinanzas As System.Windows.Forms.Button
    Friend WithEvents lblSolicitar As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlEntregadoNave As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlSolicitadoFinanzas As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlSolicitado As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlAGerente As System.Windows.Forms.Panel
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents grdDatosPrestamos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlCancelado As System.Windows.Forms.Panel
    Friend WithEvents pnlEntregadoColaborador As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlLiquidado As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlCobranza As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlRGerente As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnAutorizarPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblRechazarPrestamo As System.Windows.Forms.Label
    Friend WithEvents lblAutorizarPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnRechazarPrestamo As System.Windows.Forms.Button
    Friend WithEvents btnEntregaColaborador As System.Windows.Forms.Button
    Friend WithEvents lblEntregar As System.Windows.Forms.Label
    Friend WithEvents pnlPeriodoBusqueda As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnConsultaAbono As System.Windows.Forms.Button
    Friend WithEvents pnlTipoBusqueda As System.Windows.Forms.Panel
    Friend WithEvents rdbFehcaEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFechaSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents chkSaldoTermino As System.Windows.Forms.CheckBox
    Friend WithEvents lblAlertaSinCaja As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents lblGerente As System.Windows.Forms.Label
    Friend WithEvents lblDevolverDinero As System.Windows.Forms.Label
    Friend WithEvents btnDevolverDinero As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label1 As Label
    Friend WithEvents menuReporte As ContextMenuStrip
    Friend WithEvents ConcentradoPréstamosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteAbonosExtraordinariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteConcentradoPréstamosEInteresesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Private WithEvents Label13 As Label
    Friend WithEvents btnPrestamoEspecial As Button
    Private WithEvents Label15 As Label
    Friend WithEvents btnPrestacion As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents lblTotalSeleccionados As Label
    Friend WithEvents ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem As ToolStripMenuItem
    Private WithEvents Label19 As Label
    Friend WithEvents btnAyuda As Button
    Friend WithEvents menuAyudaReportes As ContextMenuStrip
    Friend WithEvents AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pcbTitulo As PictureBox
End Class
