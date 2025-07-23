<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarReporteFiniquitoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarReporteFiniquitoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlExportarReporte = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlImprimirReporte = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdoPeriodo = New System.Windows.Forms.RadioButton()
        Me.rdoRango = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoFechaSolicitud = New System.Windows.Forms.RadioButton()
        Me.rdoFechaBaja = New System.Windows.Forms.RadioButton()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblCURP = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.dtmRangoFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtmRangoFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFiltroFechas = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.grdReporteFiniquito = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlExportarReporte.SuspendLayout()
        Me.pnlImprimirReporte.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpbFiltro.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.grdReporteFiniquito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.pnlExportarReporte)
        Me.pnlTitulo.Controls.Add(Me.pnlImprimirReporte)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1317, 69)
        Me.pnlTitulo.TabIndex = 2
        '
        'pnlExportarReporte
        '
        Me.pnlExportarReporte.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportarReporte.Controls.Add(Me.lblExportarExcel)
        Me.pnlExportarReporte.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportarReporte.Location = New System.Drawing.Point(62, 0)
        Me.pnlExportarReporte.Name = "pnlExportarReporte"
        Me.pnlExportarReporte.Size = New System.Drawing.Size(62, 69)
        Me.pnlExportarReporte.TabIndex = 63
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(16, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(31, 32)
        Me.btnExportarExcel.TabIndex = 40
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(9, 42)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarExcel.TabIndex = 41
        Me.lblExportarExcel.Text = "Exportar"
        '
        'pnlImprimirReporte
        '
        Me.pnlImprimirReporte.Controls.Add(Me.btnImprimir)
        Me.pnlImprimirReporte.Controls.Add(Me.lblImprimir)
        Me.pnlImprimirReporte.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimirReporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimirReporte.Name = "pnlImprimirReporte"
        Me.pnlImprimirReporte.Size = New System.Drawing.Size(62, 69)
        Me.pnlImprimirReporte.TabIndex = 62
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(14, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 38
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(11, 42)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 39
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1051, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(182, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Reporte de Finiquitos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 439)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1317, 67)
        Me.Panel1.TabIndex = 58
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(1272, 44)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 62
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(1273, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 61
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'gpbFiltro
        '
        Me.gpbFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbFiltro.Controls.Add(Me.Panel4)
        Me.gpbFiltro.Controls.Add(Me.Panel3)
        Me.gpbFiltro.Controls.Add(Me.Panel2)
        Me.gpbFiltro.Controls.Add(Me.cmbEmpresa)
        Me.gpbFiltro.Controls.Add(Me.lblCURP)
        Me.gpbFiltro.Controls.Add(Me.cmbNave)
        Me.gpbFiltro.Controls.Add(Me.lblNave)
        Me.gpbFiltro.Controls.Add(Me.cmbEstatus)
        Me.gpbFiltro.Controls.Add(Me.cmbPeriodo)
        Me.gpbFiltro.Controls.Add(Me.dtmRangoFechaAl)
        Me.gpbFiltro.Controls.Add(Me.Label4)
        Me.gpbFiltro.Controls.Add(Me.dtmRangoFechaDel)
        Me.gpbFiltro.Controls.Add(Me.Label3)
        Me.gpbFiltro.Controls.Add(Me.chkFiltroFechas)
        Me.gpbFiltro.Controls.Add(Me.Label2)
        Me.gpbFiltro.Controls.Add(Me.Label1)
        Me.gpbFiltro.Controls.Add(Me.txtNombre)
        Me.gpbFiltro.Controls.Add(Me.Label14)
        Me.gpbFiltro.Controls.Add(Me.Panel10)
        Me.gpbFiltro.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 69)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(1317, 148)
        Me.gpbFiltro.TabIndex = 59
        Me.gpbFiltro.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.btnArriba)
        Me.Panel4.Controls.Add(Me.btnAbajo)
        Me.Panel4.Location = New System.Drawing.Point(1249, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(62, 22)
        Me.Panel4.TabIndex = 119
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(7, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 119
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(36, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 120
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdoPeriodo)
        Me.Panel3.Controls.Add(Me.rdoRango)
        Me.Panel3.Location = New System.Drawing.Point(585, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(71, 60)
        Me.Panel3.TabIndex = 116
        '
        'rdoPeriodo
        '
        Me.rdoPeriodo.AutoSize = True
        Me.rdoPeriodo.Enabled = False
        Me.rdoPeriodo.Location = New System.Drawing.Point(5, 34)
        Me.rdoPeriodo.Name = "rdoPeriodo"
        Me.rdoPeriodo.Size = New System.Drawing.Size(61, 17)
        Me.rdoPeriodo.TabIndex = 104
        Me.rdoPeriodo.Text = "Periodo"
        Me.rdoPeriodo.UseVisualStyleBackColor = True
        '
        'rdoRango
        '
        Me.rdoRango.AutoSize = True
        Me.rdoRango.Checked = True
        Me.rdoRango.Enabled = False
        Me.rdoRango.Location = New System.Drawing.Point(5, 10)
        Me.rdoRango.Name = "rdoRango"
        Me.rdoRango.Size = New System.Drawing.Size(57, 17)
        Me.rdoRango.TabIndex = 103
        Me.rdoRango.TabStop = True
        Me.rdoRango.Text = "Rango"
        Me.rdoRango.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoFechaSolicitud)
        Me.Panel2.Controls.Add(Me.rdoFechaBaja)
        Me.Panel2.Location = New System.Drawing.Point(709, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(203, 25)
        Me.Panel2.TabIndex = 115
        '
        'rdoFechaSolicitud
        '
        Me.rdoFechaSolicitud.AutoSize = True
        Me.rdoFechaSolicitud.Enabled = False
        Me.rdoFechaSolicitud.Location = New System.Drawing.Point(91, 5)
        Me.rdoFechaSolicitud.Name = "rdoFechaSolicitud"
        Me.rdoFechaSolicitud.Size = New System.Drawing.Size(98, 17)
        Me.rdoFechaSolicitud.TabIndex = 117
        Me.rdoFechaSolicitud.Text = "Fecha Solicitud"
        Me.rdoFechaSolicitud.UseVisualStyleBackColor = True
        '
        'rdoFechaBaja
        '
        Me.rdoFechaBaja.AutoSize = True
        Me.rdoFechaBaja.Checked = True
        Me.rdoFechaBaja.Enabled = False
        Me.rdoFechaBaja.Location = New System.Drawing.Point(6, 5)
        Me.rdoFechaBaja.Name = "rdoFechaBaja"
        Me.rdoFechaBaja.Size = New System.Drawing.Size(79, 17)
        Me.rdoFechaBaja.TabIndex = 116
        Me.rdoFechaBaja.TabStop = True
        Me.rdoFechaBaja.Text = "Fecha Baja"
        Me.rdoFechaBaja.UseVisualStyleBackColor = True
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(66, 61)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(402, 21)
        Me.cmbEmpresa.TabIndex = 114
        '
        'lblCURP
        '
        Me.lblCURP.AutoSize = True
        Me.lblCURP.Location = New System.Drawing.Point(16, 64)
        Me.lblCURP.Name = "lblCURP"
        Me.lblCURP.Size = New System.Drawing.Size(51, 13)
        Me.lblCURP.TabIndex = 113
        Me.lblCURP.Text = "Empresa:"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(66, 35)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(402, 21)
        Me.cmbNave.TabIndex = 112
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(16, 38)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 111
        Me.lblNave.Text = "Nave:"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(66, 87)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(402, 21)
        Me.cmbEstatus.TabIndex = 110
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.Enabled = False
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(662, 82)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(406, 21)
        Me.cmbPeriodo.TabIndex = 107
        '
        'dtmRangoFechaAl
        '
        Me.dtmRangoFechaAl.Checked = False
        Me.dtmRangoFechaAl.Enabled = False
        Me.dtmRangoFechaAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmRangoFechaAl.Location = New System.Drawing.Point(941, 58)
        Me.dtmRangoFechaAl.Name = "dtmRangoFechaAl"
        Me.dtmRangoFechaAl.Size = New System.Drawing.Size(193, 20)
        Me.dtmRangoFechaAl.TabIndex = 106
        Me.dtmRangoFechaAl.Value = New Date(2016, 8, 27, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(919, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Al"
        '
        'dtmRangoFechaDel
        '
        Me.dtmRangoFechaDel.Checked = False
        Me.dtmRangoFechaDel.Enabled = False
        Me.dtmRangoFechaDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmRangoFechaDel.Location = New System.Drawing.Point(719, 58)
        Me.dtmRangoFechaDel.Name = "dtmRangoFechaDel"
        Me.dtmRangoFechaDel.Size = New System.Drawing.Size(193, 20)
        Me.dtmRangoFechaDel.TabIndex = 104
        Me.dtmRangoFechaDel.Value = New Date(2016, 8, 27, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(659, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Fecha del"
        '
        'chkFiltroFechas
        '
        Me.chkFiltroFechas.AutoSize = True
        Me.chkFiltroFechas.Location = New System.Drawing.Point(681, 34)
        Me.chkFiltroFechas.Name = "chkFiltroFechas"
        Me.chkFiltroFechas.Size = New System.Drawing.Size(15, 14)
        Me.chkFiltroFechas.TabIndex = 100
        Me.chkFiltroFechas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFiltroFechas.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(590, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Filtro por Fechas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Estatus"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(66, 113)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(402, 20)
        Me.txtNombre.TabIndex = 97
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnFiltrarSolicitud)
        Me.Panel10.Controls.Add(Me.lblBuscar)
        Me.Panel10.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(1137, 16)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(112, 129)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(70, 98)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(24, 67)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 4
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(19, 98)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(74, 67)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 5
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1249, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 129)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'grdReporteFiniquito
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReporteFiniquito.DisplayLayout.Appearance = Appearance1
        Me.grdReporteFiniquito.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReporteFiniquito.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdReporteFiniquito.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReporteFiniquito.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdReporteFiniquito.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdReporteFiniquito.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReporteFiniquito.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdReporteFiniquito.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReporteFiniquito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporteFiniquito.Location = New System.Drawing.Point(0, 217)
        Me.grdReporteFiniquito.Name = "grdReporteFiniquito"
        Me.grdReporteFiniquito.Size = New System.Drawing.Size(1317, 222)
        Me.grdReporteFiniquito.TabIndex = 60
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(1245, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 64
        Me.imgLogo.TabStop = False
        '
        'GenerarReporteFiniquitoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 506)
        Me.Controls.Add(Me.grdReporteFiniquito)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitulo)
        Me.MinimumSize = New System.Drawing.Size(1035, 533)
        Me.Name = "GenerarReporteFiniquitoForm"
        Me.Text = "Reporte de Finiquitos"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlExportarReporte.ResumeLayout(False)
        Me.pnlExportarReporte.PerformLayout()
        Me.pnlImprimirReporte.ResumeLayout(False)
        Me.pnlImprimirReporte.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpbFiltro.ResumeLayout(False)
        Me.gpbFiltro.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.grdReporteFiniquito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents grdReporteFiniquito As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents dtmRangoFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtmRangoFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkFiltroFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblCURP As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdoPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRango As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoFechaSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFechaBaja As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlExportarReporte As System.Windows.Forms.Panel
    Friend WithEvents pnlImprimirReporte As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
