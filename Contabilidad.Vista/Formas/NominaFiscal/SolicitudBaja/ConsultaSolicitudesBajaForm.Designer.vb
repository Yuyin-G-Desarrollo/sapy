<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaSolicitudesBajaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaSolicitudesBajaForm))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlConsultaReporte = New System.Windows.Forms.Panel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.pnlExportarListado = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlImprimirListado = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlCalcularFiniquito = New System.Windows.Forms.Panel()
        Me.btnCalcularFiniquito = New System.Windows.Forms.Button()
        Me.lblCalcularFiniquito = New System.Windows.Forms.Label()
        Me.pnlRechazado = New System.Windows.Forms.Panel()
        Me.btnRechazado = New System.Windows.Forms.Button()
        Me.lblRechazado = New System.Windows.Forms.Label()
        Me.pnlAceptado = New System.Windows.Forms.Panel()
        Me.btnAceptado = New System.Windows.Forms.Button()
        Me.lblAceptado = New System.Windows.Forms.Label()
        Me.pnlDescargarTXT = New System.Windows.Forms.Panel()
        Me.btnDescargartxt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlVerFiniquito = New System.Windows.Forms.Panel()
        Me.btnEditarFiniquito = New System.Windows.Forms.Button()
        Me.lblEditarFiniquito = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdSolicitudesBaja = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbxFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdoPeriodo = New System.Windows.Forms.RadioButton()
        Me.rdoRango = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rdoFechaSolicitud = New System.Windows.Forms.RadioButton()
        Me.rdoFechaBaja = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.dtmRangoFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtmRangoFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFiltroFechas = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblNSS = New System.Windows.Forms.Label()
        Me.lblCURP = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlConsultaReporte.SuspendLayout()
        Me.pnlExportarListado.SuspendLayout()
        Me.pnlImprimirListado.SuspendLayout()
        Me.pnlCalcularFiniquito.SuspendLayout()
        Me.pnlRechazado.SuspendLayout()
        Me.pnlAceptado.SuspendLayout()
        Me.pnlDescargarTXT.SuspendLayout()
        Me.pnlVerFiniquito.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdSolicitudesBaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.grbxFiltros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.pnlConsultaReporte)
        Me.pnlTitulo.Controls.Add(Me.pnlExportarListado)
        Me.pnlTitulo.Controls.Add(Me.pnlImprimirListado)
        Me.pnlTitulo.Controls.Add(Me.pnlCalcularFiniquito)
        Me.pnlTitulo.Controls.Add(Me.pnlRechazado)
        Me.pnlTitulo.Controls.Add(Me.pnlAceptado)
        Me.pnlTitulo.Controls.Add(Me.pnlDescargarTXT)
        Me.pnlTitulo.Controls.Add(Me.pnlVerFiniquito)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1196, 73)
        Me.pnlTitulo.TabIndex = 1
        '
        'pnlConsultaReporte
        '
        Me.pnlConsultaReporte.Controls.Add(Me.btnReporte)
        Me.pnlConsultaReporte.Controls.Add(Me.lblReporte)
        Me.pnlConsultaReporte.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConsultaReporte.Location = New System.Drawing.Point(444, 0)
        Me.pnlConsultaReporte.Name = "pnlConsultaReporte"
        Me.pnlConsultaReporte.Size = New System.Drawing.Size(60, 73)
        Me.pnlConsultaReporte.TabIndex = 68
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporte.Location = New System.Drawing.Point(14, 6)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(31, 32)
        Me.btnReporte.TabIndex = 59
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporte.Location = New System.Drawing.Point(8, 41)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(45, 13)
        Me.lblReporte.TabIndex = 60
        Me.lblReporte.Text = "Reporte"
        '
        'pnlExportarListado
        '
        Me.pnlExportarListado.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportarListado.Controls.Add(Me.lblExportarExcel)
        Me.pnlExportarListado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportarListado.Location = New System.Drawing.Point(390, 0)
        Me.pnlExportarListado.Name = "pnlExportarListado"
        Me.pnlExportarListado.Size = New System.Drawing.Size(54, 73)
        Me.pnlExportarListado.TabIndex = 67
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(12, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(31, 32)
        Me.btnExportarExcel.TabIndex = 40
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(6, 41)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarExcel.TabIndex = 41
        Me.lblExportarExcel.Text = "Exportar"
        '
        'pnlImprimirListado
        '
        Me.pnlImprimirListado.Controls.Add(Me.btnImprimir)
        Me.pnlImprimirListado.Controls.Add(Me.lblImprimir)
        Me.pnlImprimirListado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimirListado.Location = New System.Drawing.Point(336, 0)
        Me.pnlImprimirListado.Name = "pnlImprimirListado"
        Me.pnlImprimirListado.Size = New System.Drawing.Size(54, 73)
        Me.pnlImprimirListado.TabIndex = 66
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(12, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 38
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(7, 41)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 39
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlCalcularFiniquito
        '
        Me.pnlCalcularFiniquito.Controls.Add(Me.btnCalcularFiniquito)
        Me.pnlCalcularFiniquito.Controls.Add(Me.lblCalcularFiniquito)
        Me.pnlCalcularFiniquito.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCalcularFiniquito.Location = New System.Drawing.Point(276, 0)
        Me.pnlCalcularFiniquito.Name = "pnlCalcularFiniquito"
        Me.pnlCalcularFiniquito.Size = New System.Drawing.Size(60, 73)
        Me.pnlCalcularFiniquito.TabIndex = 65
        '
        'btnCalcularFiniquito
        '
        Me.btnCalcularFiniquito.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnCalcularFiniquito.Location = New System.Drawing.Point(14, 6)
        Me.btnCalcularFiniquito.Name = "btnCalcularFiniquito"
        Me.btnCalcularFiniquito.Size = New System.Drawing.Size(31, 32)
        Me.btnCalcularFiniquito.TabIndex = 36
        Me.btnCalcularFiniquito.UseVisualStyleBackColor = True
        '
        'lblCalcularFiniquito
        '
        Me.lblCalcularFiniquito.AutoSize = True
        Me.lblCalcularFiniquito.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCalcularFiniquito.Location = New System.Drawing.Point(6, 41)
        Me.lblCalcularFiniquito.Name = "lblCalcularFiniquito"
        Me.lblCalcularFiniquito.Size = New System.Drawing.Size(48, 26)
        Me.lblCalcularFiniquito.TabIndex = 37
        Me.lblCalcularFiniquito.Text = "Calcular " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Finiquito"
        '
        'pnlRechazado
        '
        Me.pnlRechazado.Controls.Add(Me.btnRechazado)
        Me.pnlRechazado.Controls.Add(Me.lblRechazado)
        Me.pnlRechazado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazado.Location = New System.Drawing.Point(202, 0)
        Me.pnlRechazado.Name = "pnlRechazado"
        Me.pnlRechazado.Size = New System.Drawing.Size(74, 73)
        Me.pnlRechazado.TabIndex = 64
        '
        'btnRechazado
        '
        Me.btnRechazado.Image = Global.Contabilidad.Vista.My.Resources.Resources.borrar_32
        Me.btnRechazado.Location = New System.Drawing.Point(18, 6)
        Me.btnRechazado.Name = "btnRechazado"
        Me.btnRechazado.Size = New System.Drawing.Size(31, 32)
        Me.btnRechazado.TabIndex = 34
        Me.btnRechazado.UseVisualStyleBackColor = True
        '
        'lblRechazado
        '
        Me.lblRechazado.AutoSize = True
        Me.lblRechazado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazado.Location = New System.Drawing.Point(6, 41)
        Me.lblRechazado.Name = "lblRechazado"
        Me.lblRechazado.Size = New System.Drawing.Size(62, 13)
        Me.lblRechazado.TabIndex = 35
        Me.lblRechazado.Text = "Rechazado"
        '
        'pnlAceptado
        '
        Me.pnlAceptado.Controls.Add(Me.btnAceptado)
        Me.pnlAceptado.Controls.Add(Me.lblAceptado)
        Me.pnlAceptado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAceptado.Location = New System.Drawing.Point(142, 0)
        Me.pnlAceptado.Name = "pnlAceptado"
        Me.pnlAceptado.Size = New System.Drawing.Size(60, 73)
        Me.pnlAceptado.TabIndex = 63
        '
        'btnAceptado
        '
        Me.btnAceptado.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptado.Location = New System.Drawing.Point(15, 6)
        Me.btnAceptado.Name = "btnAceptado"
        Me.btnAceptado.Size = New System.Drawing.Size(31, 32)
        Me.btnAceptado.TabIndex = 32
        Me.btnAceptado.UseVisualStyleBackColor = True
        '
        'lblAceptado
        '
        Me.lblAceptado.AutoSize = True
        Me.lblAceptado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptado.Location = New System.Drawing.Point(5, 41)
        Me.lblAceptado.Name = "lblAceptado"
        Me.lblAceptado.Size = New System.Drawing.Size(53, 13)
        Me.lblAceptado.TabIndex = 33
        Me.lblAceptado.Text = "Aceptado"
        '
        'pnlDescargarTXT
        '
        Me.pnlDescargarTXT.Controls.Add(Me.btnDescargartxt)
        Me.pnlDescargarTXT.Controls.Add(Me.Label1)
        Me.pnlDescargarTXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescargarTXT.Location = New System.Drawing.Point(62, 0)
        Me.pnlDescargarTXT.Name = "pnlDescargarTXT"
        Me.pnlDescargarTXT.Size = New System.Drawing.Size(80, 73)
        Me.pnlDescargarTXT.TabIndex = 62
        '
        'btnDescargartxt
        '
        Me.btnDescargartxt.Image = Global.Contabilidad.Vista.My.Resources.Resources.descargarBlanco
        Me.btnDescargartxt.Location = New System.Drawing.Point(24, 6)
        Me.btnDescargartxt.Name = "btnDescargartxt"
        Me.btnDescargartxt.Size = New System.Drawing.Size(31, 32)
        Me.btnDescargartxt.TabIndex = 30
        Me.btnDescargartxt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(6, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Descargar txt"
        '
        'pnlVerFiniquito
        '
        Me.pnlVerFiniquito.Controls.Add(Me.btnEditarFiniquito)
        Me.pnlVerFiniquito.Controls.Add(Me.lblEditarFiniquito)
        Me.pnlVerFiniquito.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerFiniquito.Location = New System.Drawing.Point(0, 0)
        Me.pnlVerFiniquito.Name = "pnlVerFiniquito"
        Me.pnlVerFiniquito.Size = New System.Drawing.Size(62, 73)
        Me.pnlVerFiniquito.TabIndex = 61
        '
        'btnEditarFiniquito
        '
        Me.btnEditarFiniquito.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditarFiniquito.Location = New System.Drawing.Point(14, 6)
        Me.btnEditarFiniquito.Name = "btnEditarFiniquito"
        Me.btnEditarFiniquito.Size = New System.Drawing.Size(31, 32)
        Me.btnEditarFiniquito.TabIndex = 30
        Me.btnEditarFiniquito.UseVisualStyleBackColor = True
        '
        'lblEditarFiniquito
        '
        Me.lblEditarFiniquito.AutoSize = True
        Me.lblEditarFiniquito.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditarFiniquito.Location = New System.Drawing.Point(9, 41)
        Me.lblEditarFiniquito.Name = "lblEditarFiniquito"
        Me.lblEditarFiniquito.Size = New System.Drawing.Size(46, 26)
        Me.lblEditarFiniquito.TabIndex = 31
        Me.lblEditarFiniquito.Text = "Ver " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Finiquito"
        Me.lblEditarFiniquito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(962, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(163, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Solicitudes de Baja"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 430)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1196, 67)
        Me.Panel1.TabIndex = 57
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(1151, 44)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 62
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(1152, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 61
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdSolicitudesBaja)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 73)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1196, 357)
        Me.Panel2.TabIndex = 58
        '
        'grdSolicitudesBaja
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudesBaja.DisplayLayout.Appearance = Appearance1
        Me.grdSolicitudesBaja.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSolicitudesBaja.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdSolicitudesBaja.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSolicitudesBaja.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdSolicitudesBaja.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdSolicitudesBaja.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudesBaja.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdSolicitudesBaja.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSolicitudesBaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitudesBaja.Location = New System.Drawing.Point(0, 163)
        Me.grdSolicitudesBaja.Name = "grdSolicitudesBaja"
        Me.grdSolicitudesBaja.Size = New System.Drawing.Size(1196, 194)
        Me.grdSolicitudesBaja.TabIndex = 114
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.grbxFiltros)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1196, 163)
        Me.Panel3.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Location = New System.Drawing.Point(1128, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(59, 22)
        Me.Panel6.TabIndex = 118
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 119
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(6, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 118
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbxFiltros
        '
        Me.grbxFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbxFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbxFiltros.Controls.Add(Me.Panel5)
        Me.grbxFiltros.Controls.Add(Me.Panel4)
        Me.grbxFiltros.Controls.Add(Me.Label5)
        Me.grbxFiltros.Controls.Add(Me.btnLimpiar)
        Me.grbxFiltros.Controls.Add(Me.lblMostrar)
        Me.grbxFiltros.Controls.Add(Me.btnMostrar)
        Me.grbxFiltros.Controls.Add(Me.cmbPeriodo)
        Me.grbxFiltros.Controls.Add(Me.dtmRangoFechaAl)
        Me.grbxFiltros.Controls.Add(Me.Label4)
        Me.grbxFiltros.Controls.Add(Me.dtmRangoFechaDel)
        Me.grbxFiltros.Controls.Add(Me.Label3)
        Me.grbxFiltros.Controls.Add(Me.chkFiltroFechas)
        Me.grbxFiltros.Controls.Add(Me.Label2)
        Me.grbxFiltros.Controls.Add(Me.cmbEstatus)
        Me.grbxFiltros.Controls.Add(Me.cmbEmpresa)
        Me.grbxFiltros.Controls.Add(Me.cmbNave)
        Me.grbxFiltros.Controls.Add(Me.txtNombre)
        Me.grbxFiltros.Controls.Add(Me.lblRFC)
        Me.grbxFiltros.Controls.Add(Me.lblNSS)
        Me.grbxFiltros.Controls.Add(Me.lblCURP)
        Me.grbxFiltros.Controls.Add(Me.lblNave)
        Me.grbxFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbxFiltros.Name = "grbxFiltros"
        Me.grbxFiltros.Size = New System.Drawing.Size(1190, 152)
        Me.grbxFiltros.TabIndex = 113
        Me.grbxFiltros.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdoPeriodo)
        Me.Panel5.Controls.Add(Me.rdoRango)
        Me.Panel5.Location = New System.Drawing.Point(563, 32)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(77, 58)
        Me.Panel5.TabIndex = 105
        '
        'rdoPeriodo
        '
        Me.rdoPeriodo.AutoSize = True
        Me.rdoPeriodo.Enabled = False
        Me.rdoPeriodo.Location = New System.Drawing.Point(8, 33)
        Me.rdoPeriodo.Name = "rdoPeriodo"
        Me.rdoPeriodo.Size = New System.Drawing.Size(61, 17)
        Me.rdoPeriodo.TabIndex = 86
        Me.rdoPeriodo.TabStop = True
        Me.rdoPeriodo.Text = "Periodo"
        Me.rdoPeriodo.UseVisualStyleBackColor = True
        '
        'rdoRango
        '
        Me.rdoRango.AutoSize = True
        Me.rdoRango.Checked = True
        Me.rdoRango.Enabled = False
        Me.rdoRango.Location = New System.Drawing.Point(8, 9)
        Me.rdoRango.Name = "rdoRango"
        Me.rdoRango.Size = New System.Drawing.Size(57, 17)
        Me.rdoRango.TabIndex = 85
        Me.rdoRango.TabStop = True
        Me.rdoRango.Text = "Rango"
        Me.rdoRango.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rdoFechaSolicitud)
        Me.Panel4.Controls.Add(Me.rdoFechaBaja)
        Me.Panel4.Location = New System.Drawing.Point(702, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 24)
        Me.Panel4.TabIndex = 104
        '
        'rdoFechaSolicitud
        '
        Me.rdoFechaSolicitud.AutoSize = True
        Me.rdoFechaSolicitud.Enabled = False
        Me.rdoFechaSolicitud.Location = New System.Drawing.Point(100, 4)
        Me.rdoFechaSolicitud.Name = "rdoFechaSolicitud"
        Me.rdoFechaSolicitud.Size = New System.Drawing.Size(98, 17)
        Me.rdoFechaSolicitud.TabIndex = 91
        Me.rdoFechaSolicitud.Text = "Fecha Solicitud"
        Me.rdoFechaSolicitud.UseVisualStyleBackColor = True
        '
        'rdoFechaBaja
        '
        Me.rdoFechaBaja.AutoSize = True
        Me.rdoFechaBaja.Checked = True
        Me.rdoFechaBaja.Enabled = False
        Me.rdoFechaBaja.Location = New System.Drawing.Point(15, 4)
        Me.rdoFechaBaja.Name = "rdoFechaBaja"
        Me.rdoFechaBaja.Size = New System.Drawing.Size(79, 17)
        Me.rdoFechaBaja.TabIndex = 90
        Me.rdoFechaBaja.TabStop = True
        Me.rdoFechaBaja.Text = "Fecha Baja"
        Me.rdoFechaBaja.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(1128, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(1131, 83)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 102
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(1077, 118)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 101
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(1083, 83)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 100
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.Enabled = False
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(646, 64)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(421, 21)
        Me.cmbPeriodo.TabIndex = 89
        '
        'dtmRangoFechaAl
        '
        Me.dtmRangoFechaAl.Enabled = False
        Me.dtmRangoFechaAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmRangoFechaAl.Location = New System.Drawing.Point(925, 40)
        Me.dtmRangoFechaAl.Name = "dtmRangoFechaAl"
        Me.dtmRangoFechaAl.Size = New System.Drawing.Size(193, 20)
        Me.dtmRangoFechaAl.TabIndex = 88
        Me.dtmRangoFechaAl.Value = New Date(2016, 8, 27, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(903, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Al"
        '
        'dtmRangoFechaDel
        '
        Me.dtmRangoFechaDel.Enabled = False
        Me.dtmRangoFechaDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmRangoFechaDel.Location = New System.Drawing.Point(703, 40)
        Me.dtmRangoFechaDel.Name = "dtmRangoFechaDel"
        Me.dtmRangoFechaDel.Size = New System.Drawing.Size(193, 20)
        Me.dtmRangoFechaDel.TabIndex = 86
        Me.dtmRangoFechaDel.Value = New Date(2016, 8, 27, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(643, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Fecha del"
        '
        'chkFiltroFechas
        '
        Me.chkFiltroFechas.AutoSize = True
        Me.chkFiltroFechas.Location = New System.Drawing.Point(665, 16)
        Me.chkFiltroFechas.Name = "chkFiltroFechas"
        Me.chkFiltroFechas.Size = New System.Drawing.Size(15, 14)
        Me.chkFiltroFechas.TabIndex = 82
        Me.chkFiltroFechas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFiltroFechas.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(574, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Filtro por Fechas"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(73, 64)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(198, 21)
        Me.cmbEstatus.TabIndex = 80
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(73, 40)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(418, 21)
        Me.cmbEmpresa.TabIndex = 79
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(73, 16)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(418, 21)
        Me.cmbNave.TabIndex = 78
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(73, 89)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(226, 20)
        Me.txtNombre.TabIndex = 10
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Location = New System.Drawing.Point(23, 68)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(45, 13)
        Me.lblRFC.TabIndex = 3
        Me.lblRFC.Text = "Estatus:"
        '
        'lblNSS
        '
        Me.lblNSS.AutoSize = True
        Me.lblNSS.Location = New System.Drawing.Point(23, 93)
        Me.lblNSS.Name = "lblNSS"
        Me.lblNSS.Size = New System.Drawing.Size(44, 13)
        Me.lblNSS.TabIndex = 2
        Me.lblNSS.Text = "Nombre"
        '
        'lblCURP
        '
        Me.lblCURP.AutoSize = True
        Me.lblCURP.Location = New System.Drawing.Point(23, 42)
        Me.lblCURP.Name = "lblCURP"
        Me.lblCURP.Size = New System.Drawing.Size(51, 13)
        Me.lblCURP.TabIndex = 1
        Me.lblCURP.Text = "Empresa:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(23, 19)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave:"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(1124, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 73)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 69
        Me.imgLogo.TabStop = False
        '
        'ConsultaSolicitudesBajaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 497)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitulo)
        Me.MinimumSize = New System.Drawing.Size(949, 518)
        Me.Name = "ConsultaSolicitudesBajaForm"
        Me.Text = "Solicitudes de Baja"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlConsultaReporte.ResumeLayout(False)
        Me.pnlConsultaReporte.PerformLayout()
        Me.pnlExportarListado.ResumeLayout(False)
        Me.pnlExportarListado.PerformLayout()
        Me.pnlImprimirListado.ResumeLayout(False)
        Me.pnlImprimirListado.PerformLayout()
        Me.pnlCalcularFiniquito.ResumeLayout(False)
        Me.pnlCalcularFiniquito.PerformLayout()
        Me.pnlRechazado.ResumeLayout(False)
        Me.pnlRechazado.PerformLayout()
        Me.pnlAceptado.ResumeLayout(False)
        Me.pnlAceptado.PerformLayout()
        Me.pnlDescargarTXT.ResumeLayout(False)
        Me.pnlDescargarTXT.PerformLayout()
        Me.pnlVerFiniquito.ResumeLayout(False)
        Me.pnlVerFiniquito.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdSolicitudesBaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.grbxFiltros.ResumeLayout(False)
        Me.grbxFiltros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnCalcularFiniquito As System.Windows.Forms.Button
    Friend WithEvents lblCalcularFiniquito As System.Windows.Forms.Label
    Friend WithEvents btnRechazado As System.Windows.Forms.Button
    Friend WithEvents lblRechazado As System.Windows.Forms.Label
    Friend WithEvents btnAceptado As System.Windows.Forms.Button
    Friend WithEvents lblAceptado As System.Windows.Forms.Label
    Friend WithEvents btnDescargartxt As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grbxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents rdoPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRango As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rdoFechaSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFechaBaja As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents dtmRangoFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtmRangoFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkFiltroFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblNSS As System.Windows.Forms.Label
    Friend WithEvents lblCURP As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents grdSolicitudesBaja As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlConsultaReporte As System.Windows.Forms.Panel
    Friend WithEvents pnlExportarListado As System.Windows.Forms.Panel
    Friend WithEvents pnlImprimirListado As System.Windows.Forms.Panel
    Friend WithEvents pnlCalcularFiniquito As System.Windows.Forms.Panel
    Friend WithEvents pnlRechazado As System.Windows.Forms.Panel
    Friend WithEvents pnlAceptado As System.Windows.Forms.Panel
    Friend WithEvents pnlDescargarTXT As System.Windows.Forms.Panel
    Friend WithEvents pnlVerFiniquito As System.Windows.Forms.Panel
    Friend WithEvents btnEditarFiniquito As System.Windows.Forms.Button
    Friend WithEvents lblEditarFiniquito As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
