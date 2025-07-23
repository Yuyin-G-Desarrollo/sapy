<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteEvaluacionCalidadNavesForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReporteAlertas = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlImprimirPDF = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblTextoExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkVistaDireccion = New System.Windows.Forms.CheckBox()
        Me.chkEvaluacionRango = New System.Windows.Forms.CheckBox()
        Me.nudSemanaFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblSemanaActual = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdReporteEvaluacion = New DevExpress.XtraGrid.GridControl()
        Me.vwReporteEvaluacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.NumeroSemana = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ParesRecibidos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ParesInspeccionados = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PorcentajeInspeccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ParesConIncidencia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IncidenciaMayor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IncidenciaMenor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PorcentajeParesConIncidencia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ParesRechazados = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.OtrosRechazos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CORTE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PESPUNTE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.MONTADO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ADORNO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.T1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.T2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.T3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.T4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.T5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.OtrasIncidencias = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LotesPilotoPresentado = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LotesPilotoIncidencia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.QuejasClientes = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.TotalDevoluciones = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TotalDevolucionesAndrea = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Calificacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlImprimirPDF.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.grdReporteEvaluacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporteEvaluacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 65)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.Panel1)
        Me.pnlVentas.Controls.Add(Me.pnlImprimirPDF)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 3)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(732, 62)
        Me.pnlVentas.TabIndex = 108
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReporteAlertas)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(73, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(73, 62)
        Me.Panel1.TabIndex = 118
        '
        'btnReporteAlertas
        '
        Me.btnReporteAlertas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReporteAlertas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReporteAlertas.Image = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporteAlertas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReporteAlertas.Location = New System.Drawing.Point(14, 3)
        Me.btnReporteAlertas.Name = "btnReporteAlertas"
        Me.btnReporteAlertas.Size = New System.Drawing.Size(32, 32)
        Me.btnReporteAlertas.TabIndex = 113
        Me.btnReporteAlertas.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(9, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 26)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "Reporte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Calidad"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlImprimirPDF
        '
        Me.pnlImprimirPDF.Controls.Add(Me.btnExportarExcel)
        Me.pnlImprimirPDF.Controls.Add(Me.lblTextoExportar)
        Me.pnlImprimirPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimirPDF.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimirPDF.Name = "pnlImprimirPDF"
        Me.pnlImprimirPDF.Size = New System.Drawing.Size(73, 62)
        Me.pnlImprimirPDF.TabIndex = 117
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Almacen.Vista.My.Resources.Resources.excel_321
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(14, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 113
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblTextoExportar
        '
        Me.lblTextoExportar.AutoSize = True
        Me.lblTextoExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportar.Location = New System.Drawing.Point(9, 35)
        Me.lblTextoExportar.Name = "lblTextoExportar"
        Me.lblTextoExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblTextoExportar.TabIndex = 112
        Me.lblTextoExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(711, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(120, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(340, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Evaluación de Calidad Semanal de Naves"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(496, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(77, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 492)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1284, 60)
        Me.pnlPie.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Purple
        Me.Label5.Location = New System.Drawing.Point(12, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 15)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Datos modificados"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(832, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(224, 30)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Únicamente se puede editar el numero " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de quejas de la semana actual." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.Label6)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1122, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(65, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(64, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.lblAceptar)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1284, 93)
        Me.pnlParametros.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkVistaDireccion)
        Me.GroupBox1.Controls.Add(Me.chkEvaluacionRango)
        Me.GroupBox1.Controls.Add(Me.nudSemanaFinal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.nudSemanaInicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1212, 56)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'chkVistaDireccion
        '
        Me.chkVistaDireccion.AutoSize = True
        Me.chkVistaDireccion.Location = New System.Drawing.Point(985, 21)
        Me.chkVistaDireccion.Name = "chkVistaDireccion"
        Me.chkVistaDireccion.Size = New System.Drawing.Size(95, 17)
        Me.chkVistaDireccion.TabIndex = 73
        Me.chkVistaDireccion.Text = "Vista dirección"
        Me.chkVistaDireccion.UseVisualStyleBackColor = True
        '
        'chkEvaluacionRango
        '
        Me.chkEvaluacionRango.AutoSize = True
        Me.chkEvaluacionRango.Location = New System.Drawing.Point(779, 21)
        Me.chkEvaluacionRango.Name = "chkEvaluacionRango"
        Me.chkEvaluacionRango.Size = New System.Drawing.Size(197, 17)
        Me.chkEvaluacionRango.TabIndex = 72
        Me.chkEvaluacionRango.Text = "Tomar Top 5 Incidencias por Rango"
        Me.chkEvaluacionRango.UseVisualStyleBackColor = True
        '
        'nudSemanaFinal
        '
        Me.nudSemanaFinal.Location = New System.Drawing.Point(687, 21)
        Me.nudSemanaFinal.Maximum = New Decimal(New Integer() {2018, 0, 0, 0})
        Me.nudSemanaFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaFinal.Name = "nudSemanaFinal"
        Me.nudSemanaFinal.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaFinal.TabIndex = 71
        Me.nudSemanaFinal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(671, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "a:"
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(618, 21)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {2018, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaInicio.TabIndex = 69
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(548, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Semana de:"
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(458, 21)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2018, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(61, 20)
        Me.nudAño.TabIndex = 67
        Me.nudAño.Value = New Decimal(New Integer() {2018, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(423, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Año:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Nave:"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(58, 21)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(334, 21)
        Me.cmbNave.TabIndex = 64
        '
        'lblAceptar
        '
        Me.lblAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(1233, 72)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 56
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1238, 40)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 57
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblSemanaActual)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1284, 27)
        Me.Panel6.TabIndex = 46
        '
        'lblSemanaActual
        '
        Me.lblSemanaActual.AutoSize = True
        Me.lblSemanaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanaActual.Location = New System.Drawing.Point(103, 6)
        Me.lblSemanaActual.Name = "lblSemanaActual"
        Me.lblSemanaActual.Size = New System.Drawing.Size(14, 15)
        Me.lblSemanaActual.TabIndex = 66
        Me.lblSemanaActual.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Semana Actual:"
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Almacen.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(1224, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Almacen.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1250, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'grdReporteEvaluacion
        '
        Me.grdReporteEvaluacion.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdReporteEvaluacion.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdReporteEvaluacion.Location = New System.Drawing.Point(0, 158)
        Me.grdReporteEvaluacion.MainView = Me.vwReporteEvaluacion
        Me.grdReporteEvaluacion.Name = "grdReporteEvaluacion"
        Me.grdReporteEvaluacion.Size = New System.Drawing.Size(1284, 334)
        Me.grdReporteEvaluacion.TabIndex = 29
        Me.grdReporteEvaluacion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporteEvaluacion, Me.GridView3, Me.GridView4})
        '
        'vwReporteEvaluacion
        '
        Me.vwReporteEvaluacion.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.vwReporteEvaluacion.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporteEvaluacion.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporteEvaluacion.Appearance.OddRow.Options.UseBackColor = True
        Me.vwReporteEvaluacion.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand3, Me.gridBand4, Me.gridBand2, Me.gridBand5, Me.gridBand6, Me.gridBand8, Me.gridBand9})
        Me.vwReporteEvaluacion.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.NumeroSemana, Me.ParesRecibidos, Me.ParesInspeccionados, Me.PorcentajeInspeccion, Me.ParesConIncidencia, Me.IncidenciaMayor, Me.IncidenciaMenor, Me.PorcentajeParesConIncidencia, Me.ParesRechazados, Me.OtrosRechazos, Me.CORTE, Me.PESPUNTE, Me.MONTADO, Me.ADORNO, Me.T1, Me.T2, Me.T3, Me.T4, Me.T5, Me.OtrasIncidencias, Me.LotesPilotoPresentado, Me.LotesPilotoIncidencia, Me.QuejasClientes, Me.TotalDevoluciones, Me.TotalDevolucionesAndrea, Me.Calificacion})
        Me.vwReporteEvaluacion.GridControl = Me.grdReporteEvaluacion
        Me.vwReporteEvaluacion.Name = "vwReporteEvaluacion"
        Me.vwReporteEvaluacion.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteEvaluacion.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteEvaluacion.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.vwReporteEvaluacion.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporteEvaluacion.OptionsSelection.MultiSelect = True
        Me.vwReporteEvaluacion.OptionsView.ColumnAutoWidth = False
        Me.vwReporteEvaluacion.OptionsView.ShowAutoFilterRow = True
        Me.vwReporteEvaluacion.OptionsView.ShowFooter = True
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Columns.Add(Me.NumeroSemana)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 0
        Me.gridBand3.Width = 98
        '
        'NumeroSemana
        '
        Me.NumeroSemana.Caption = "No. SEMANA"
        Me.NumeroSemana.FieldName = "NumeroSemana"
        Me.NumeroSemana.Name = "NumeroSemana"
        Me.NumeroSemana.Visible = True
        Me.NumeroSemana.Width = 98
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "DATOS"
        Me.gridBand4.Columns.Add(Me.ParesRecibidos)
        Me.gridBand4.Columns.Add(Me.ParesInspeccionados)
        Me.gridBand4.Columns.Add(Me.PorcentajeInspeccion)
        Me.gridBand4.Columns.Add(Me.ParesConIncidencia)
        Me.gridBand4.Columns.Add(Me.IncidenciaMayor)
        Me.gridBand4.Columns.Add(Me.IncidenciaMenor)
        Me.gridBand4.Columns.Add(Me.PorcentajeParesConIncidencia)
        Me.gridBand4.Columns.Add(Me.ParesRechazados)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 1
        Me.gridBand4.Width = 848
        '
        'ParesRecibidos
        '
        Me.ParesRecibidos.Caption = "PARES RECIBIDOS"
        Me.ParesRecibidos.FieldName = "ParesRecibidos"
        Me.ParesRecibidos.Name = "ParesRecibidos"
        Me.ParesRecibidos.Visible = True
        Me.ParesRecibidos.Width = 82
        '
        'ParesInspeccionados
        '
        Me.ParesInspeccionados.Caption = "PARES INSPECCIONADOS"
        Me.ParesInspeccionados.FieldName = "ParesInspeccionados"
        Me.ParesInspeccionados.Name = "ParesInspeccionados"
        Me.ParesInspeccionados.Visible = True
        Me.ParesInspeccionados.Width = 111
        '
        'PorcentajeInspeccion
        '
        Me.PorcentajeInspeccion.Caption = "% INSPECCIÓN"
        Me.PorcentajeInspeccion.FieldName = "PorcentajeInspeccion"
        Me.PorcentajeInspeccion.Name = "PorcentajeInspeccion"
        Me.PorcentajeInspeccion.Visible = True
        Me.PorcentajeInspeccion.Width = 113
        '
        'ParesConIncidencia
        '
        Me.ParesConIncidencia.Caption = "PRS CON INCIDENCIA"
        Me.ParesConIncidencia.FieldName = "ParesConIncidencia"
        Me.ParesConIncidencia.Name = "ParesConIncidencia"
        Me.ParesConIncidencia.Visible = True
        Me.ParesConIncidencia.Width = 104
        '
        'IncidenciaMayor
        '
        Me.IncidenciaMayor.Caption = "INCIDENCIA MAYOR"
        Me.IncidenciaMayor.FieldName = "IncidenciaMayor"
        Me.IncidenciaMayor.Name = "IncidenciaMayor"
        Me.IncidenciaMayor.Visible = True
        Me.IncidenciaMayor.Width = 88
        '
        'IncidenciaMenor
        '
        Me.IncidenciaMenor.Caption = "INCIDENCIA MENOR"
        Me.IncidenciaMenor.FieldName = "IncidenciaMenor"
        Me.IncidenciaMenor.Name = "IncidenciaMenor"
        Me.IncidenciaMenor.Visible = True
        Me.IncidenciaMenor.Width = 88
        '
        'PorcentajeParesConIncidencia
        '
        Me.PorcentajeParesConIncidencia.Caption = "% PRS CON INCIDENCIA"
        Me.PorcentajeParesConIncidencia.FieldName = "PorcentajeParesConIncidencia"
        Me.PorcentajeParesConIncidencia.Name = "PorcentajeParesConIncidencia"
        Me.PorcentajeParesConIncidencia.Visible = True
        Me.PorcentajeParesConIncidencia.Width = 163
        '
        'ParesRechazados
        '
        Me.ParesRechazados.Caption = "# PRS. RECH."
        Me.ParesRechazados.FieldName = "ParesRechazados"
        Me.ParesRechazados.Name = "ParesRechazados"
        Me.ParesRechazados.Visible = True
        Me.ParesRechazados.Width = 99
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "OTROS RECHAZOS"
        Me.gridBand2.Columns.Add(Me.OtrosRechazos)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 120
        '
        'OtrosRechazos
        '
        Me.OtrosRechazos.Caption = "PRS RECHAZADOS"
        Me.OtrosRechazos.FieldName = "OtrosRechazos"
        Me.OtrosRechazos.Name = "OtrosRechazos"
        Me.OtrosRechazos.Visible = True
        Me.OtrosRechazos.Width = 120
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "INCIDENCIAS DURANTE LA INSPECCIÓN"
        Me.gridBand5.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.gridBand7})
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 3
        Me.gridBand5.Width = 847
        '
        'gridBand1
        '
        Me.gridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand1.Caption = "Defectos por Departamento"
        Me.gridBand1.Columns.Add(Me.CORTE)
        Me.gridBand1.Columns.Add(Me.PESPUNTE)
        Me.gridBand1.Columns.Add(Me.MONTADO)
        Me.gridBand1.Columns.Add(Me.ADORNO)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 382
        '
        'CORTE
        '
        Me.CORTE.Caption = "CORTE"
        Me.CORTE.FieldName = "CORTE"
        Me.CORTE.Name = "CORTE"
        Me.CORTE.Visible = True
        Me.CORTE.Width = 95
        '
        'PESPUNTE
        '
        Me.PESPUNTE.Caption = "PESPUNTE"
        Me.PESPUNTE.FieldName = "PESPUNTE"
        Me.PESPUNTE.Name = "PESPUNTE"
        Me.PESPUNTE.Visible = True
        Me.PESPUNTE.Width = 95
        '
        'MONTADO
        '
        Me.MONTADO.Caption = "MONTADO"
        Me.MONTADO.FieldName = "MONTADO"
        Me.MONTADO.Name = "MONTADO"
        Me.MONTADO.Visible = True
        Me.MONTADO.Width = 95
        '
        'ADORNO
        '
        Me.ADORNO.Caption = "ADORNO"
        Me.ADORNO.FieldName = "ADORNO"
        Me.ADORNO.Name = "ADORNO"
        Me.ADORNO.Visible = True
        Me.ADORNO.Width = 97
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "DEFECTOS POR PROCESO"
        Me.gridBand7.Columns.Add(Me.T1)
        Me.gridBand7.Columns.Add(Me.T2)
        Me.gridBand7.Columns.Add(Me.T3)
        Me.gridBand7.Columns.Add(Me.T4)
        Me.gridBand7.Columns.Add(Me.T5)
        Me.gridBand7.Columns.Add(Me.OtrasIncidencias)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 1
        Me.gridBand7.Width = 465
        '
        'T1
        '
        Me.T1.Caption = "T1"
        Me.T1.FieldName = "T1"
        Me.T1.Name = "T1"
        Me.T1.Visible = True
        '
        'T2
        '
        Me.T2.Caption = "T2"
        Me.T2.FieldName = "T2"
        Me.T2.Name = "T2"
        Me.T2.Visible = True
        '
        'T3
        '
        Me.T3.Caption = "T3"
        Me.T3.FieldName = "T3"
        Me.T3.Name = "T3"
        Me.T3.Visible = True
        '
        'T4
        '
        Me.T4.Caption = "T4"
        Me.T4.FieldName = "T4"
        Me.T4.Name = "T4"
        Me.T4.Visible = True
        '
        'T5
        '
        Me.T5.Caption = "T5"
        Me.T5.FieldName = "T5"
        Me.T5.Name = "T5"
        Me.T5.Visible = True
        '
        'OtrasIncidencias
        '
        Me.OtrasIncidencias.Caption = "OTROS"
        Me.OtrasIncidencias.FieldName = "OtrasIncidencias"
        Me.OtrasIncidencias.Name = "OtrasIncidencias"
        Me.OtrasIncidencias.Visible = True
        Me.OtrasIncidencias.Width = 90
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "LOTES PILOTO"
        Me.gridBand6.Columns.Add(Me.LotesPilotoPresentado)
        Me.gridBand6.Columns.Add(Me.LotesPilotoIncidencia)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 4
        Me.gridBand6.Width = 232
        '
        'LotesPilotoPresentado
        '
        Me.LotesPilotoPresentado.Caption = "LOTES PRESENTADOS"
        Me.LotesPilotoPresentado.FieldName = "LotesPilotoPresentado"
        Me.LotesPilotoPresentado.Name = "LotesPilotoPresentado"
        Me.LotesPilotoPresentado.Visible = True
        Me.LotesPilotoPresentado.Width = 117
        '
        'LotesPilotoIncidencia
        '
        Me.LotesPilotoIncidencia.Caption = "LOTES CON INCIDENCIA"
        Me.LotesPilotoIncidencia.FieldName = "LotesPilotoIncidencia"
        Me.LotesPilotoIncidencia.Name = "LotesPilotoIncidencia"
        Me.LotesPilotoIncidencia.Visible = True
        Me.LotesPilotoIncidencia.Width = 115
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "CLIENTES"
        Me.gridBand8.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand11, Me.gridBand10})
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 5
        Me.gridBand8.Width = 311
        '
        'gridBand11
        '
        Me.gridBand11.Columns.Add(Me.QuejasClientes)
        Me.gridBand11.Name = "gridBand11"
        Me.gridBand11.VisibleIndex = 0
        Me.gridBand11.Width = 82
        '
        'QuejasClientes
        '
        Me.QuejasClientes.Caption = "QUEJAS CLIENTES"
        Me.QuejasClientes.FieldName = "QuejasClientes"
        Me.QuejasClientes.Name = "QuejasClientes"
        Me.QuejasClientes.Visible = True
        Me.QuejasClientes.Width = 82
        '
        'gridBand10
        '
        Me.gridBand10.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand10.Caption = "DEVOLUCIONES"
        Me.gridBand10.Columns.Add(Me.TotalDevoluciones)
        Me.gridBand10.Columns.Add(Me.TotalDevolucionesAndrea)
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.VisibleIndex = 1
        Me.gridBand10.Width = 229
        '
        'TotalDevoluciones
        '
        Me.TotalDevoluciones.Caption = "TOTAL"
        Me.TotalDevoluciones.FieldName = "TotalDevoluciones"
        Me.TotalDevoluciones.Name = "TotalDevoluciones"
        Me.TotalDevoluciones.Visible = True
        Me.TotalDevoluciones.Width = 97
        '
        'TotalDevolucionesAndrea
        '
        Me.TotalDevolucionesAndrea.Caption = "ANDREA"
        Me.TotalDevolucionesAndrea.FieldName = "TotalDevolucionesAndrea"
        Me.TotalDevolucionesAndrea.Name = "TotalDevolucionesAndrea"
        Me.TotalDevolucionesAndrea.Visible = True
        Me.TotalDevolucionesAndrea.Width = 132
        '
        'gridBand9
        '
        Me.gridBand9.Columns.Add(Me.Calificacion)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 6
        Me.gridBand9.Width = 75
        '
        'Calificacion
        '
        Me.Calificacion.Caption = "CALIFICACIÓN"
        Me.Calificacion.FieldName = "Calificacion"
        Me.Calificacion.Name = "Calificacion"
        Me.Calificacion.Visible = True
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdReporteEvaluacion
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView3.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView4.GridControl = Me.grdReporteEvaluacion
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView4.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = """"
        Me.GridColumn1.FieldName = "Seleccionar"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 35
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "OT"
        Me.GridColumn3.FieldName = "OT"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 70
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "OTSICY"
        Me.GridColumn4.FieldName = "OTSICY"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Cliente"
        Me.GridColumn5.FieldName = "Cliente"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 220
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Agente"
        Me.GridColumn6.FieldName = "Agente"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "STATUS"
        Me.GridColumn7.FieldName = "STATUS"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 90
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tipo OT"
        Me.GridColumn8.FieldName = "TipoOT"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 70
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Pedido SAY"
        Me.GridColumn9.FieldName = "PedidoSAY"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 80
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Pedido SICY"
        Me.GridColumn10.FieldName = "PedidoSICY"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 80
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Orden Cliente"
        Me.GridColumn11.FieldName = "OrdenCliente"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Fecha Entrega Programación"
        Me.GridColumn12.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 120
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Fecha Preparación"
        Me.GridColumn13.FieldName = "FechaPreparacion"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 120
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Cantidad"
        Me.GridColumn14.FieldName = "Cantidad"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 80
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Confirmados"
        Me.GridColumn15.FieldName = "Confirmados"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 13
        Me.GridColumn15.Width = 80
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Por Confirmar"
        Me.GridColumn16.FieldName = "PorConfirmar"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 14
        Me.GridColumn16.Width = 90
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Cancelados"
        Me.GridColumn17.FieldName = "Cancelados"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 15
        Me.GridColumn17.Width = 80
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Usuario Captura"
        Me.GridColumn18.FieldName = "UsuarioCaptura"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 16
        Me.GridColumn18.Width = 90
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Fecha Captura"
        Me.GridColumn19.FieldName = "FechaCaptura"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 17
        Me.GridColumn19.Width = 120
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Cita"
        Me.GridColumn20.FieldName = "Cita"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 18
        Me.GridColumn20.Width = 50
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Usuario Modifico"
        Me.GridColumn21.FieldName = "UsuarioModifico"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 19
        Me.GridColumn21.Width = 90
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Fecha Modificación"
        Me.GridColumn22.FieldName = "FechaModificacion"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 20
        Me.GridColumn22.Width = 120
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Dias Faltantes"
        Me.GridColumn23.FieldName = "DiasFaltantes"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 21
        Me.GridColumn23.Width = 90
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "BE"
        Me.GridColumn24.FieldName = "BE"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 22
        Me.GridColumn24.Width = 50
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Motivo Cancelación"
        Me.GridColumn25.FieldName = "MotivoCancelacion"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 23
        Me.GridColumn25.Width = 100
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "EstatusID"
        Me.GridColumn26.FieldName = "EstatusID"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "ClaveCitaEntrega"
        Me.GridColumn27.FieldName = "ClaveCitaEntrega"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 24
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn3"
        Me.GridColumn28.FieldName = "Observaciones"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 25
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "FechaCitaEntrega"
        Me.GridColumn29.FieldName = "FechaCitaEntrega"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 26
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "HoraCita"
        Me.GridColumn30.FieldName = "HoraCita"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 27
        '
        'ReporteEvaluacionCalidadNavesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 552)
        Me.Controls.Add(Me.grdReporteEvaluacion)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ReporteEvaluacionCalidadNavesForm"
        Me.Text = "Evaluación de Calidad Semanal de Naves"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlImprimirPDF.ResumeLayout(False)
        Me.pnlImprimirPDF.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.grdReporteEvaluacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporteEvaluacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlVentas As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblTextoExportar As Label
    Friend WithEvents pnlImprimirPDF As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudSemanaFinal As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblSemanaActual As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents grdReporteEvaluacion As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporteEvaluacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents NumeroSemana As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesRecibidos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesInspeccionados As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PorcentajeInspeccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesConIncidencia As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IncidenciaMayor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IncidenciaMenor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PorcentajeParesConIncidencia As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ParesRechazados As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OtrosRechazos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CORTE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PESPUNTE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents MONTADO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ADORNO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents T1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents T2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents T3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents T4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents T5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OtrasIncidencias As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LotesPilotoPresentado As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LotesPilotoIncidencia As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents QuejasClientes As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TotalDevolucionesAndrea As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TotalDevoluciones As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Calificacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents chkEvaluacionRango As CheckBox
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReporteAlertas As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents chkVistaDireccion As CheckBox
End Class
