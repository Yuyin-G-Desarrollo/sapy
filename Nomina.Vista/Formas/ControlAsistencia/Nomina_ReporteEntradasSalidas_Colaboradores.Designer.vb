<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Nomina_ReporteEntradasSalidas_Colaboradores
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nomina_ReporteEntradasSalidas_Colaboradores))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.lblTotalColaboradoresNumero = New System.Windows.Forms.Label()
        Me.lblTotalColaboradores = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grbFechas = New System.Windows.Forms.GroupBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lbllimpiarMostrar = New System.Windows.Forms.Label()
        Me.grbTipoRegistro = New System.Windows.Forms.GroupBox()
        Me.chboxSalida = New System.Windows.Forms.CheckBox()
        Me.chboxRegresoComida = New System.Windows.Forms.CheckBox()
        Me.chboxSalidaComida = New System.Windows.Forms.CheckBox()
        Me.chboxEntrada = New System.Windows.Forms.CheckBox()
        Me.gboxColaboradores = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdColaboradores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarColaboradores = New System.Windows.Forms.Button()
        Me.btnLimpiarColaboradores = New System.Windows.Forms.Button()
        Me.grdReporteColaboradores = New DevExpress.XtraGrid.GridControl()
        Me.vwReporteColaboradores = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbFechas.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.grbTipoRegistro.SuspendLayout()
        Me.gboxColaboradores.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReporteColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporteColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1367, 67)
        Me.pnlHeader.TabIndex = 72
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(9, 44)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 110
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Nomina.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(16, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 109
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(890, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(477, 67)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(129, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(259, 40)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Reporte de Entradas y Salidas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       de Colaboradores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.lblFechaUltimaActualización)
        Me.Panel2.Controls.Add(Me.lblTotalColaboradoresNumero)
        Me.Panel2.Controls.Add(Me.lblTotalColaboradores)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 541)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1367, 68)
        Me.Panel2.TabIndex = 74
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(818, 36)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 121
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(937, 36)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 122
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'lblTotalColaboradoresNumero
        '
        Me.lblTotalColaboradoresNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalColaboradoresNumero.Location = New System.Drawing.Point(31, 44)
        Me.lblTotalColaboradoresNumero.Name = "lblTotalColaboradoresNumero"
        Me.lblTotalColaboradoresNumero.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalColaboradoresNumero.TabIndex = 120
        Me.lblTotalColaboradoresNumero.Text = "0"
        Me.lblTotalColaboradoresNumero.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalColaboradores
        '
        Me.lblTotalColaboradores.AutoSize = True
        Me.lblTotalColaboradores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalColaboradores.ForeColor = System.Drawing.Color.Black
        Me.lblTotalColaboradores.Location = New System.Drawing.Point(9, 9)
        Me.lblTotalColaboradores.Name = "lblTotalColaboradores"
        Me.lblTotalColaboradores.Size = New System.Drawing.Size(112, 32)
        Me.lblTotalColaboradores.TabIndex = 119
        Me.lblTotalColaboradores.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colaboradores"
        Me.lblTotalColaboradores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(1177, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(190, 68)
        Me.pnlBotones.TabIndex = 6
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(76, 45)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 72
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(133, 45)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(134, 11)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(80, 11)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 71
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.grbFechas)
        Me.grbParametros.Controls.Add(Me.Panel5)
        Me.grbParametros.Controls.Add(Me.grbTipoRegistro)
        Me.grbParametros.Controls.Add(Me.gboxColaboradores)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 67)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1367, 219)
        Me.grbParametros.TabIndex = 75
        Me.grbParametros.TabStop = False
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(22, 31)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 139
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(67, 28)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(195, 21)
        Me.cmbNave.TabIndex = 138
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1302, 7)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 23)
        Me.pnlMinimizarParametros.TabIndex = 137
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
        'grbFechas
        '
        Me.grbFechas.Controls.Add(Me.dtpFechaInicio)
        Me.grbFechas.Controls.Add(Me.lblEntregaDel)
        Me.grbFechas.Controls.Add(Me.dtpFechaFin)
        Me.grbFechas.Controls.Add(Me.lblEntregaAl)
        Me.grbFechas.Location = New System.Drawing.Point(16, 61)
        Me.grbFechas.Name = "grbFechas"
        Me.grbFechas.Size = New System.Drawing.Size(246, 72)
        Me.grbFechas.TabIndex = 135
        Me.grbFechas.TabStop = False
        Me.grbFechas.Text = "Fechas"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(43, 29)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaInicio.TabIndex = 66
        Me.dtpFechaInicio.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(14, 33)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(149, 29)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(78, 20)
        Me.dtpFechaFin.TabIndex = 69
        Me.dtpFechaFin.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(127, 33)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.btnMostrar)
        Me.Panel5.Controls.Add(Me.lbllimpiarMostrar)
        Me.Panel5.Location = New System.Drawing.Point(1304, 73)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(57, 60)
        Me.Panel5.TabIndex = 136
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(13, 5)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 134
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lbllimpiarMostrar
        '
        Me.lbllimpiarMostrar.AutoSize = True
        Me.lbllimpiarMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbllimpiarMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbllimpiarMostrar.Location = New System.Drawing.Point(9, 39)
        Me.lbllimpiarMostrar.Name = "lbllimpiarMostrar"
        Me.lbllimpiarMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lbllimpiarMostrar.TabIndex = 135
        Me.lbllimpiarMostrar.Text = "Mostrar"
        '
        'grbTipoRegistro
        '
        Me.grbTipoRegistro.Controls.Add(Me.chboxSalida)
        Me.grbTipoRegistro.Controls.Add(Me.chboxRegresoComida)
        Me.grbTipoRegistro.Controls.Add(Me.chboxSalidaComida)
        Me.grbTipoRegistro.Controls.Add(Me.chboxEntrada)
        Me.grbTipoRegistro.Location = New System.Drawing.Point(16, 141)
        Me.grbTipoRegistro.Name = "grbTipoRegistro"
        Me.grbTipoRegistro.Size = New System.Drawing.Size(246, 72)
        Me.grbTipoRegistro.TabIndex = 136
        Me.grbTipoRegistro.TabStop = False
        Me.grbTipoRegistro.Text = "Tipo Registro"
        '
        'chboxSalida
        '
        Me.chboxSalida.AutoSize = True
        Me.chboxSalida.Checked = True
        Me.chboxSalida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSalida.Location = New System.Drawing.Point(149, 42)
        Me.chboxSalida.Name = "chboxSalida"
        Me.chboxSalida.Size = New System.Drawing.Size(55, 17)
        Me.chboxSalida.TabIndex = 122
        Me.chboxSalida.Text = "Salida"
        Me.chboxSalida.UseVisualStyleBackColor = True
        '
        'chboxRegresoComida
        '
        Me.chboxRegresoComida.AutoSize = True
        Me.chboxRegresoComida.Checked = True
        Me.chboxRegresoComida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxRegresoComida.Location = New System.Drawing.Point(17, 42)
        Me.chboxRegresoComida.Name = "chboxRegresoComida"
        Me.chboxRegresoComida.Size = New System.Drawing.Size(104, 17)
        Me.chboxRegresoComida.TabIndex = 121
        Me.chboxRegresoComida.Text = "Regreso Comida"
        Me.chboxRegresoComida.UseVisualStyleBackColor = True
        '
        'chboxSalidaComida
        '
        Me.chboxSalidaComida.AutoSize = True
        Me.chboxSalidaComida.Checked = True
        Me.chboxSalidaComida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSalidaComida.Location = New System.Drawing.Point(149, 19)
        Me.chboxSalidaComida.Name = "chboxSalidaComida"
        Me.chboxSalidaComida.Size = New System.Drawing.Size(93, 17)
        Me.chboxSalidaComida.TabIndex = 120
        Me.chboxSalidaComida.Text = "Salida Comida"
        Me.chboxSalidaComida.UseVisualStyleBackColor = True
        '
        'chboxEntrada
        '
        Me.chboxEntrada.AutoSize = True
        Me.chboxEntrada.Checked = True
        Me.chboxEntrada.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxEntrada.Location = New System.Drawing.Point(17, 19)
        Me.chboxEntrada.Name = "chboxEntrada"
        Me.chboxEntrada.Size = New System.Drawing.Size(63, 17)
        Me.chboxEntrada.TabIndex = 119
        Me.chboxEntrada.Text = "Entrada"
        Me.chboxEntrada.UseVisualStyleBackColor = True
        '
        'gboxColaboradores
        '
        Me.gboxColaboradores.Controls.Add(Me.Panel1)
        Me.gboxColaboradores.Controls.Add(Me.btnAgregarColaboradores)
        Me.gboxColaboradores.Controls.Add(Me.btnLimpiarColaboradores)
        Me.gboxColaboradores.Location = New System.Drawing.Point(288, 31)
        Me.gboxColaboradores.Name = "gboxColaboradores"
        Me.gboxColaboradores.Size = New System.Drawing.Size(407, 166)
        Me.gboxColaboradores.TabIndex = 134
        Me.gboxColaboradores.TabStop = False
        Me.gboxColaboradores.Text = "Colaborador"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdColaboradores)
        Me.Panel1.Location = New System.Drawing.Point(0, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 126)
        Me.Panel1.TabIndex = 133
        '
        'grdColaboradores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Appearance = Appearance1
        Me.grdColaboradores.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColaboradores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColaboradores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColaboradores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColaboradores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColaboradores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColaboradores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColaboradores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColaboradores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColaboradores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 0)
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(397, 123)
        Me.grdColaboradores.TabIndex = 5
        '
        'btnAgregarColaboradores
        '
        Me.btnAgregarColaboradores.Image = CType(resources.GetObject("btnAgregarColaboradores.Image"), System.Drawing.Image)
        Me.btnAgregarColaboradores.Location = New System.Drawing.Point(375, 14)
        Me.btnAgregarColaboradores.Name = "btnAgregarColaboradores"
        Me.btnAgregarColaboradores.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarColaboradores.TabIndex = 132
        Me.btnAgregarColaboradores.UseVisualStyleBackColor = True
        '
        'btnLimpiarColaboradores
        '
        Me.btnLimpiarColaboradores.Image = CType(resources.GetObject("btnLimpiarColaboradores.Image"), System.Drawing.Image)
        Me.btnLimpiarColaboradores.Location = New System.Drawing.Point(351, 14)
        Me.btnLimpiarColaboradores.Name = "btnLimpiarColaboradores"
        Me.btnLimpiarColaboradores.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarColaboradores.TabIndex = 131
        Me.btnLimpiarColaboradores.UseVisualStyleBackColor = True
        '
        'grdReporteColaboradores
        '
        Me.grdReporteColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporteColaboradores.Location = New System.Drawing.Point(0, 286)
        Me.grdReporteColaboradores.MainView = Me.vwReporteColaboradores
        Me.grdReporteColaboradores.Name = "grdReporteColaboradores"
        Me.grdReporteColaboradores.Size = New System.Drawing.Size(1367, 255)
        Me.grdReporteColaboradores.TabIndex = 77
        Me.grdReporteColaboradores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporteColaboradores})
        '
        'vwReporteColaboradores
        '
        Me.vwReporteColaboradores.ActiveFilterEnabled = False
        Me.vwReporteColaboradores.GridControl = Me.grdReporteColaboradores
        Me.vwReporteColaboradores.Name = "vwReporteColaboradores"
        Me.vwReporteColaboradores.OptionsBehavior.Editable = False
        Me.vwReporteColaboradores.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.vwReporteColaboradores.OptionsCustomization.AllowFilter = False
        Me.vwReporteColaboradores.OptionsCustomization.AllowGroup = False
        Me.vwReporteColaboradores.OptionsFilter.AllowFilterEditor = False
        Me.vwReporteColaboradores.OptionsSelection.MultiSelect = True
        Me.vwReporteColaboradores.OptionsView.ColumnAutoWidth = False
        Me.vwReporteColaboradores.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwReporteColaboradores.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporteColaboradores.OptionsView.ShowDetailButtons = False
        Me.vwReporteColaboradores.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporteColaboradores.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(409, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Nomina_ReporteEntradasSalidas_Colaboradores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1367, 609)
        Me.Controls.Add(Me.grdReporteColaboradores)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "Nomina_ReporteEntradasSalidas_Colaboradores"
        Me.Text = "Reporte de Entradas y Salidas de Colaboradores"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grbFechas.ResumeLayout(False)
        Me.grbFechas.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.grbTipoRegistro.ResumeLayout(False)
        Me.grbTipoRegistro.PerformLayout()
        Me.gboxColaboradores.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReporteColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporteColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblExportar As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTextoUltimaActualizacion As Label
    Friend WithEvents lblFechaUltimaActualización As Label
    Friend WithEvents lblTotalColaboradoresNumero As Label
    Friend WithEvents lblTotalColaboradores As Label
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents bntSalir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents grbParametros As GroupBox
    Friend WithEvents grdReporteColaboradores As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporteColaboradores As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents grbFechas As GroupBox
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents grbTipoRegistro As GroupBox
    Friend WithEvents chboxSalida As CheckBox
    Friend WithEvents chboxRegresoComida As CheckBox
    Friend WithEvents chboxSalidaComida As CheckBox
    Friend WithEvents chboxEntrada As CheckBox
    Friend WithEvents gboxColaboradores As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdColaboradores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarColaboradores As Button
    Friend WithEvents btnLimpiarColaboradores As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lbllimpiarMostrar As Label
    Friend WithEvents pnlMinimizarParametros As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
