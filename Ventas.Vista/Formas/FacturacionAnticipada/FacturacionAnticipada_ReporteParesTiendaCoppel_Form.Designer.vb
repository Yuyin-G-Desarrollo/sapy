<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacturacionAnticipada_ReporteParesTiendaCoppel_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionAnticipada_ReporteParesTiendaCoppel_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblParesBodegaPuebla = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblParesBodegaTecamac = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblParesBodegaLeon = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblParesPendientes = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblParesDistribuidos = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblParesPedido = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdReportePares = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosReportePares = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdReportePares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosReportePares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezadoExpander.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(872, 65)
        Me.pnlEncabezado.TabIndex = 44
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(418, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlExportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(534, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(58, 65)
        Me.pnlExportar.TabIndex = 106
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(15, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 100
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(8, 35)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 99
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(319, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(164, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(314, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reporte de Pares por Tienda COPPEL"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Panel6)
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.Panel4)
        Me.pnlPie.Controls.Add(Me.Panel3)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 529)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(872, 63)
        Me.pnlPie.TabIndex = 49
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.lblParesBodegaPuebla)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(535, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(107, 63)
        Me.Panel6.TabIndex = 191
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(11, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 29)
        Me.Label10.TabIndex = 183
        Me.Label10.Text = "Bodega Puebla"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesBodegaPuebla
        '
        Me.lblParesBodegaPuebla.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesBodegaPuebla.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesBodegaPuebla.Location = New System.Drawing.Point(11, 36)
        Me.lblParesBodegaPuebla.Name = "lblParesBodegaPuebla"
        Me.lblParesBodegaPuebla.Size = New System.Drawing.Size(86, 22)
        Me.lblParesBodegaPuebla.TabIndex = 184
        Me.lblParesBodegaPuebla.Text = "0"
        Me.lblParesBodegaPuebla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.lblParesBodegaTecamac)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(428, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(107, 63)
        Me.Panel5.TabIndex = 190
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(11, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 28)
        Me.Label8.TabIndex = 183
        Me.Label8.Text = "Bodega Tecamac"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesBodegaTecamac
        '
        Me.lblParesBodegaTecamac.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesBodegaTecamac.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesBodegaTecamac.Location = New System.Drawing.Point(11, 36)
        Me.lblParesBodegaTecamac.Name = "lblParesBodegaTecamac"
        Me.lblParesBodegaTecamac.Size = New System.Drawing.Size(86, 22)
        Me.lblParesBodegaTecamac.TabIndex = 184
        Me.lblParesBodegaTecamac.Text = "0"
        Me.lblParesBodegaTecamac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.lblParesBodegaLeon)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(321, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(107, 63)
        Me.Panel4.TabIndex = 189
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 18)
        Me.Label6.TabIndex = 183
        Me.Label6.Text = "Bodega León"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesBodegaLeon
        '
        Me.lblParesBodegaLeon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesBodegaLeon.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesBodegaLeon.Location = New System.Drawing.Point(11, 36)
        Me.lblParesBodegaLeon.Name = "lblParesBodegaLeon"
        Me.lblParesBodegaLeon.Size = New System.Drawing.Size(86, 22)
        Me.lblParesBodegaLeon.TabIndex = 184
        Me.lblParesBodegaLeon.Text = "0"
        Me.lblParesBodegaLeon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblParesPendientes)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(214, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(107, 63)
        Me.Panel3.TabIndex = 188
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 28)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "Pares Pendientes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesPendientes
        '
        Me.lblParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPendientes.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesPendientes.Location = New System.Drawing.Point(11, 36)
        Me.lblParesPendientes.Name = "lblParesPendientes"
        Me.lblParesPendientes.Size = New System.Drawing.Size(86, 22)
        Me.lblParesPendientes.TabIndex = 184
        Me.lblParesPendientes.Text = "0"
        Me.lblParesPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblParesDistribuidos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(107, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(107, 63)
        Me.Panel2.TabIndex = 187
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 33)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Pares Distribuidos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesDistribuidos
        '
        Me.lblParesDistribuidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesDistribuidos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesDistribuidos.Location = New System.Drawing.Point(11, 36)
        Me.lblParesDistribuidos.Name = "lblParesDistribuidos"
        Me.lblParesDistribuidos.Size = New System.Drawing.Size(86, 22)
        Me.lblParesDistribuidos.TabIndex = 184
        Me.lblParesDistribuidos.Text = "0"
        Me.lblParesDistribuidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblParesPedido)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 63)
        Me.Panel1.TabIndex = 186
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 18)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Pares Pedido"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesPedido
        '
        Me.lblParesPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPedido.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesPedido.Location = New System.Drawing.Point(11, 36)
        Me.lblParesPedido.Name = "lblParesPedido"
        Me.lblParesPedido.Size = New System.Drawing.Size(86, 22)
        Me.lblParesPedido.TabIndex = 184
        Me.lblParesPedido.Text = "0"
        Me.lblParesPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(678, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(194, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(11, 38)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(19, 20)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(148, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(147, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdReportePares
        '
        Me.grdReportePares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReportePares.Location = New System.Drawing.Point(0, 65)
        Me.grdReportePares.MainView = Me.grdDatosReportePares
        Me.grdReportePares.Name = "grdReportePares"
        Me.grdReportePares.Size = New System.Drawing.Size(872, 464)
        Me.grdReportePares.TabIndex = 160
        Me.grdReportePares.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosReportePares})
        '
        'grdDatosReportePares
        '
        Me.grdDatosReportePares.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosReportePares.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosReportePares.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosReportePares.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosReportePares.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosReportePares.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosReportePares.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosReportePares.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosReportePares.GridControl = Me.grdReportePares
        Me.grdDatosReportePares.IndicatorWidth = 30
        Me.grdDatosReportePares.Name = "grdDatosReportePares"
        Me.grdDatosReportePares.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosReportePares.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosReportePares.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosReportePares.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosReportePares.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosReportePares.OptionsView.ColumnAutoWidth = False
        Me.grdDatosReportePares.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosReportePares.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosReportePares.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosReportePares.OptionsView.ShowFooter = True
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.pnlBotonesExpander)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 65)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(872, 25)
        Me.pnlEncabezadoExpander.TabIndex = 161
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(808, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 25)
        Me.pnlBotonesExpander.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(485, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'FacturacionAnticipada_ReporteParesTiendaCoppel_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(872, 592)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.grdReportePares)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacturacionAnticipada_ReporteParesTiendaCoppel_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Pares por Tienda Coppel"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdReportePares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosReportePares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblParesPedido As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdReportePares As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosReportePares As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents lblParesBodegaPuebla As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents lblParesBodegaTecamac As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblParesBodegaLeon As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents lblParesPendientes As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblParesDistribuidos As Label
    Friend WithEvents pnlEncabezadoExpander As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
