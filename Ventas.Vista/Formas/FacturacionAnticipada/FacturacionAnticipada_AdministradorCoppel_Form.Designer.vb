<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacturacionAnticipada_AdministradorCoppel_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionAnticipada_AdministradorCoppel_Form))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnVerManual = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlVerOT = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimirReporte = New System.Windows.Forms.Button()
        Me.lblTextoImprimirPDF = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlCancelar = New System.Windows.Forms.Panel()
        Me.btnCancelarDistribucion = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnImportarDistribucion = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grpEstatusEntrega = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpEstatusDistribución = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlEntregaVenceHoy = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlAlMenos1DiaEntrega = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.grpFiltroPedidoSicy = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grpPedidoSICY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSICY = New System.Windows.Forms.MaskedTextBox()
        Me.grpFiltroPedidoSay = New System.Windows.Forms.GroupBox()
        Me.Panel32 = New System.Windows.Forms.Panel()
        Me.grdPedidoSAY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSAY = New System.Windows.Forms.MaskedTextBox()
        Me.grpPedidos = New System.Windows.Forms.GroupBox()
        Me.chkDistribucionPendiente = New System.Windows.Forms.CheckBox()
        Me.chkDistribucionCapturada = New System.Windows.Forms.CheckBox()
        Me.grpFiltroFecha = New System.Windows.Forms.GroupBox()
        Me.chkBuscarPorFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.grdDistribuciones = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosDistribuciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlVerOT.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlCancelar.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grpEstatusEntrega.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpEstatusDistribución.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezadoExpander.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        Me.grpFiltroPedidoSicy.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grpPedidoSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltroPedidoSay.SuspendLayout()
        Me.Panel32.SuspendLayout()
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPedidos.SuspendLayout()
        Me.grpFiltroFecha.SuspendLayout()
        CType(Me.grdDistribuciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosDistribuciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1225, 65)
        Me.pnlEncabezado.TabIndex = 43
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
        Me.Panel14.Controls.Add(Me.Panel7)
        Me.Panel14.Controls.Add(Me.pnlVerOT)
        Me.Panel14.Controls.Add(Me.pnlImprimir)
        Me.Panel14.Controls.Add(Me.pnlExportar)
        Me.Panel14.Controls.Add(Me.pnlCancelar)
        Me.Panel14.Controls.Add(Me.pnlImportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(534, 65)
        Me.Panel14.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label14)
        Me.Panel7.Controls.Add(Me.btnVerManual)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(322, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(65, 65)
        Me.Panel7.TabIndex = 109
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(10, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 109
        Me.Label14.Text = "Manual"
        '
        'btnVerManual
        '
        Me.btnVerManual.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerManual.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerManual.Image = Global.Ventas.Vista.My.Resources.Resources.ayuda
        Me.btnVerManual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerManual.Location = New System.Drawing.Point(15, 3)
        Me.btnVerManual.Name = "btnVerManual"
        Me.btnVerManual.Size = New System.Drawing.Size(32, 32)
        Me.btnVerManual.TabIndex = 108
        Me.btnVerManual.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(20, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 13)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Ver"
        '
        'pnlVerOT
        '
        Me.pnlVerOT.Controls.Add(Me.Label12)
        Me.pnlVerOT.Controls.Add(Me.btnVerDetalle)
        Me.pnlVerOT.Controls.Add(Me.Label13)
        Me.pnlVerOT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerOT.Location = New System.Drawing.Point(257, 0)
        Me.pnlVerOT.Name = "pnlVerOT"
        Me.pnlVerOT.Size = New System.Drawing.Size(65, 65)
        Me.pnlVerOT.TabIndex = 108
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(2, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "Generadas"
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerDetalle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerDetalle.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerDetalle.Location = New System.Drawing.Point(15, 3)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalle.TabIndex = 108
        Me.btnVerDetalle.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(11, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "Ver OT"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.Label2)
        Me.pnlImprimir.Controls.Add(Me.btnImprimirReporte)
        Me.pnlImprimir.Controls.Add(Me.lblTextoImprimirPDF)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(197, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(60, 65)
        Me.pnlImprimir.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Reporte"
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirReporte.Image = CType(resources.GetObject("btnImprimirReporte.Image"), System.Drawing.Image)
        Me.btnImprimirReporte.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirReporte.Location = New System.Drawing.Point(15, 3)
        Me.btnImprimirReporte.Name = "btnImprimirReporte"
        Me.btnImprimirReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirReporte.TabIndex = 108
        Me.btnImprimirReporte.UseVisualStyleBackColor = True
        '
        'lblTextoImprimirPDF
        '
        Me.lblTextoImprimirPDF.AutoSize = True
        Me.lblTextoImprimirPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoImprimirPDF.Location = New System.Drawing.Point(10, 35)
        Me.lblTextoImprimirPDF.Name = "lblTextoImprimirPDF"
        Me.lblTextoImprimirPDF.Size = New System.Drawing.Size(42, 13)
        Me.lblTextoImprimirPDF.TabIndex = 107
        Me.lblTextoImprimirPDF.Text = "Imprimir"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(139, 0)
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
        'pnlCancelar
        '
        Me.pnlCancelar.Controls.Add(Me.btnCancelarDistribucion)
        Me.pnlCancelar.Controls.Add(Me.Label7)
        Me.pnlCancelar.Controls.Add(Me.Label8)
        Me.pnlCancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCancelar.Location = New System.Drawing.Point(79, 0)
        Me.pnlCancelar.Name = "pnlCancelar"
        Me.pnlCancelar.Size = New System.Drawing.Size(60, 65)
        Me.pnlCancelar.TabIndex = 105
        '
        'btnCancelarDistribucion
        '
        Me.btnCancelarDistribucion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarDistribucion.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarDistribucion.Location = New System.Drawing.Point(15, 3)
        Me.btnCancelarDistribucion.Name = "btnCancelarDistribucion"
        Me.btnCancelarDistribucion.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarDistribucion.TabIndex = 105
        Me.btnCancelarDistribucion.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(7, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Cancelar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(0, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "Distribución"
        '
        'pnlImportar
        '
        Me.pnlImportar.Controls.Add(Me.Label6)
        Me.pnlImportar.Controls.Add(Me.btnImportarDistribucion)
        Me.pnlImportar.Controls.Add(Me.Label5)
        Me.pnlImportar.Controls.Add(Me.Label1)
        Me.pnlImportar.Controls.Add(Me.Label3)
        Me.pnlImportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlImportar.Name = "pnlImportar"
        Me.pnlImportar.Size = New System.Drawing.Size(79, 65)
        Me.pnlImportar.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(11, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Distribución"
        '
        'btnImportarDistribucion
        '
        Me.btnImportarDistribucion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImportarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImportarDistribucion.Image = Global.Ventas.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnImportarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarDistribucion.Location = New System.Drawing.Point(29, 3)
        Me.btnImportarDistribucion.Name = "btnImportarDistribucion"
        Me.btnImportarDistribucion.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarDistribucion.TabIndex = 102
        Me.btnImportarDistribucion.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(20, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Importar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(14, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Distribución"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(23, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Importar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(672, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(66, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(423, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Importación de Distribución de Pedidos Por Tiendas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Panel3)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 546)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1225, 63)
        Me.pnlPie.TabIndex = 48
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grpEstatusEntrega)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(266, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(159, 63)
        Me.Panel3.TabIndex = 188
        '
        'grpEstatusEntrega
        '
        Me.grpEstatusEntrega.Controls.Add(Me.Panel4)
        Me.grpEstatusEntrega.Controls.Add(Me.Panel19)
        Me.grpEstatusEntrega.Controls.Add(Me.Label9)
        Me.grpEstatusEntrega.Controls.Add(Me.Label10)
        Me.grpEstatusEntrega.Controls.Add(Me.Label11)
        Me.grpEstatusEntrega.Controls.Add(Me.Panel6)
        Me.grpEstatusEntrega.Location = New System.Drawing.Point(6, 3)
        Me.grpEstatusEntrega.Name = "grpEstatusEntrega"
        Me.grpEstatusEntrega.Size = New System.Drawing.Size(147, 57)
        Me.grpEstatusEntrega.TabIndex = 185
        Me.grpEstatusEntrega.TabStop = False
        Me.grpEstatusEntrega.Text = "Estatus Entrega"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Pink
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(6, 13)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 43
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel19.ForeColor = System.Drawing.Color.Black
        Me.Panel19.Location = New System.Drawing.Point(6, 28)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(15, 15)
        Me.Panel19.TabIndex = 42
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Menor a 1 días"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Mayor a 15 días"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Entre 1 y 15 días"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightGreen
        Me.Panel6.ForeColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(6, 41)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpEstatusDistribución)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(107, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(159, 63)
        Me.Panel2.TabIndex = 187
        '
        'grpEstatusDistribución
        '
        Me.grpEstatusDistribución.Controls.Add(Me.Label16)
        Me.grpEstatusDistribución.Controls.Add(Me.Panel21)
        Me.grpEstatusDistribución.Controls.Add(Me.Label19)
        Me.grpEstatusDistribución.Controls.Add(Me.pnlEntregaVenceHoy)
        Me.grpEstatusDistribución.Controls.Add(Me.Label20)
        Me.grpEstatusDistribución.Controls.Add(Me.pnlAlMenos1DiaEntrega)
        Me.grpEstatusDistribución.Location = New System.Drawing.Point(6, 3)
        Me.grpEstatusDistribución.Name = "grpEstatusDistribución"
        Me.grpEstatusDistribución.Size = New System.Drawing.Size(147, 57)
        Me.grpEstatusDistribución.TabIndex = 185
        Me.grpEstatusDistribución.TabStop = False
        Me.grpEstatusDistribución.Text = "Estatus Distribución"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(24, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Pendiente"
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.OrangeRed
        Me.Panel21.ForeColor = System.Drawing.Color.Black
        Me.Panel21.Location = New System.Drawing.Point(6, 13)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(15, 15)
        Me.Panel21.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(24, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Capturada"
        '
        'pnlEntregaVenceHoy
        '
        Me.pnlEntregaVenceHoy.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlEntregaVenceHoy.ForeColor = System.Drawing.Color.Black
        Me.pnlEntregaVenceHoy.Location = New System.Drawing.Point(6, 28)
        Me.pnlEntregaVenceHoy.Name = "pnlEntregaVenceHoy"
        Me.pnlEntregaVenceHoy.Size = New System.Drawing.Size(15, 15)
        Me.pnlEntregaVenceHoy.TabIndex = 21
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(24, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Parcialmente Capturada"
        '
        'pnlAlMenos1DiaEntrega
        '
        Me.pnlAlMenos1DiaEntrega.BackColor = System.Drawing.Color.Green
        Me.pnlAlMenos1DiaEntrega.ForeColor = System.Drawing.Color.Black
        Me.pnlAlMenos1DiaEntrega.Location = New System.Drawing.Point(6, 41)
        Me.pnlAlMenos1DiaEntrega.Name = "pnlAlMenos1DiaEntrega"
        Me.pnlAlMenos1DiaEntrega.Size = New System.Drawing.Size(15, 15)
        Me.pnlAlMenos1DiaEntrega.TabIndex = 23
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblRegistros)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(107, 63)
        Me.Panel1.TabIndex = 186
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 23)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Registros"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(11, 34)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(939, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(286, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
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
        Me.btnCerrar.Location = New System.Drawing.Point(238, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(186, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Mostrar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(237, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(190, 9)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.pnlBotonesExpander)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 65)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(1225, 25)
        Me.pnlEncabezadoExpander.TabIndex = 157
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1161, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 25)
        Me.pnlBotonesExpander.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 1
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.grpCliente)
        Me.pnlFiltros.Controls.Add(Me.grpFiltroPedidoSicy)
        Me.pnlFiltros.Controls.Add(Me.grpFiltroPedidoSay)
        Me.pnlFiltros.Controls.Add(Me.grpPedidos)
        Me.pnlFiltros.Controls.Add(Me.grpFiltroFecha)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 90)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1225, 137)
        Me.pnlFiltros.TabIndex = 158
        '
        'grpCliente
        '
        Me.grpCliente.Controls.Add(Me.cmbCliente)
        Me.grpCliente.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpCliente.Location = New System.Drawing.Point(515, 0)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(168, 137)
        Me.grpCliente.TabIndex = 156
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = "Cliente"
        '
        'cmbCliente
        '
        Me.cmbCliente.DisplayMember = "nombregenerico"
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(6, 23)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(156, 21)
        Me.cmbCliente.TabIndex = 147
        Me.cmbCliente.ValueMember = "clienteid"
        '
        'grpFiltroPedidoSicy
        '
        Me.grpFiltroPedidoSicy.Controls.Add(Me.Panel5)
        Me.grpFiltroPedidoSicy.Controls.Add(Me.txtPedidoSICY)
        Me.grpFiltroPedidoSicy.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpFiltroPedidoSicy.Location = New System.Drawing.Point(398, 0)
        Me.grpFiltroPedidoSicy.Name = "grpFiltroPedidoSicy"
        Me.grpFiltroPedidoSicy.Size = New System.Drawing.Size(117, 137)
        Me.grpFiltroPedidoSicy.TabIndex = 155
        Me.grpFiltroPedidoSicy.TabStop = False
        Me.grpFiltroPedidoSicy.Text = "Pedido SICY"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grpPedidoSICY)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(111, 98)
        Me.Panel5.TabIndex = 2
        '
        'grpPedidoSICY
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpPedidoSICY.DisplayLayout.Appearance = Appearance1
        Me.grpPedidoSICY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grpPedidoSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grpPedidoSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grpPedidoSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grpPedidoSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grpPedidoSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grpPedidoSICY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grpPedidoSICY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpPedidoSICY.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grpPedidoSICY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grpPedidoSICY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grpPedidoSICY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPedidoSICY.Location = New System.Drawing.Point(0, 0)
        Me.grpPedidoSICY.Name = "grpPedidoSICY"
        Me.grpPedidoSICY.Size = New System.Drawing.Size(111, 98)
        Me.grpPedidoSICY.TabIndex = 1
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(11, 15)
        Me.txtPedidoSICY.Mask = "99999999999999999"
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSICY.Size = New System.Drawing.Size(89, 20)
        Me.txtPedidoSICY.TabIndex = 0
        Me.txtPedidoSICY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpFiltroPedidoSay
        '
        Me.grpFiltroPedidoSay.Controls.Add(Me.Panel32)
        Me.grpFiltroPedidoSay.Controls.Add(Me.txtPedidoSAY)
        Me.grpFiltroPedidoSay.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpFiltroPedidoSay.Location = New System.Drawing.Point(281, 0)
        Me.grpFiltroPedidoSay.Name = "grpFiltroPedidoSay"
        Me.grpFiltroPedidoSay.Size = New System.Drawing.Size(117, 137)
        Me.grpFiltroPedidoSay.TabIndex = 153
        Me.grpFiltroPedidoSay.TabStop = False
        Me.grpFiltroPedidoSay.Text = "Pedido SAY"
        '
        'Panel32
        '
        Me.Panel32.Controls.Add(Me.grdPedidoSAY)
        Me.Panel32.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel32.Location = New System.Drawing.Point(3, 36)
        Me.Panel32.Name = "Panel32"
        Me.Panel32.Size = New System.Drawing.Size(111, 98)
        Me.Panel32.TabIndex = 2
        '
        'grdPedidoSAY
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Appearance = Appearance3
        Me.grdPedidoSAY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPedidoSAY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidoSAY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPedidoSAY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidoSAY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdPedidoSAY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidoSAY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidoSAY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidoSAY.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidoSAY.Name = "grdPedidoSAY"
        Me.grdPedidoSAY.Size = New System.Drawing.Size(111, 98)
        Me.grdPedidoSAY.TabIndex = 1
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(11, 15)
        Me.txtPedidoSAY.Mask = "99999999999999999"
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSAY.Size = New System.Drawing.Size(89, 20)
        Me.txtPedidoSAY.TabIndex = 0
        Me.txtPedidoSAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpPedidos
        '
        Me.grpPedidos.Controls.Add(Me.chkDistribucionPendiente)
        Me.grpPedidos.Controls.Add(Me.chkDistribucionCapturada)
        Me.grpPedidos.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpPedidos.Location = New System.Drawing.Point(139, 0)
        Me.grpPedidos.Name = "grpPedidos"
        Me.grpPedidos.Size = New System.Drawing.Size(142, 137)
        Me.grpPedidos.TabIndex = 149
        Me.grpPedidos.TabStop = False
        Me.grpPedidos.Text = "Pedidos"
        '
        'chkDistribucionPendiente
        '
        Me.chkDistribucionPendiente.AutoSize = True
        Me.chkDistribucionPendiente.Checked = True
        Me.chkDistribucionPendiente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistribucionPendiente.Location = New System.Drawing.Point(5, 26)
        Me.chkDistribucionPendiente.Name = "chkDistribucionPendiente"
        Me.chkDistribucionPendiente.Size = New System.Drawing.Size(131, 17)
        Me.chkDistribucionPendiente.TabIndex = 144
        Me.chkDistribucionPendiente.Text = "Distribución pendiente"
        Me.chkDistribucionPendiente.UseVisualStyleBackColor = True
        '
        'chkDistribucionCapturada
        '
        Me.chkDistribucionCapturada.AutoSize = True
        Me.chkDistribucionCapturada.Checked = True
        Me.chkDistribucionCapturada.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistribucionCapturada.Location = New System.Drawing.Point(5, 57)
        Me.chkDistribucionCapturada.Name = "chkDistribucionCapturada"
        Me.chkDistribucionCapturada.Size = New System.Drawing.Size(132, 17)
        Me.chkDistribucionCapturada.TabIndex = 143
        Me.chkDistribucionCapturada.Text = "Distribución capturada"
        Me.chkDistribucionCapturada.UseVisualStyleBackColor = True
        '
        'grpFiltroFecha
        '
        Me.grpFiltroFecha.Controls.Add(Me.chkBuscarPorFecha)
        Me.grpFiltroFecha.Controls.Add(Me.dtpFechaFin)
        Me.grpFiltroFecha.Controls.Add(Me.lblAl)
        Me.grpFiltroFecha.Controls.Add(Me.dtpFechaInicio)
        Me.grpFiltroFecha.Controls.Add(Me.lblDel)
        Me.grpFiltroFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpFiltroFecha.Location = New System.Drawing.Point(0, 0)
        Me.grpFiltroFecha.Name = "grpFiltroFecha"
        Me.grpFiltroFecha.Size = New System.Drawing.Size(139, 137)
        Me.grpFiltroFecha.TabIndex = 148
        Me.grpFiltroFecha.TabStop = False
        Me.grpFiltroFecha.Text = "Fecha Entrega"
        '
        'chkBuscarPorFecha
        '
        Me.chkBuscarPorFecha.AutoSize = True
        Me.chkBuscarPorFecha.Checked = True
        Me.chkBuscarPorFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBuscarPorFecha.Location = New System.Drawing.Point(14, 26)
        Me.chkBuscarPorFecha.Name = "chkBuscarPorFecha"
        Me.chkBuscarPorFecha.Size = New System.Drawing.Size(107, 17)
        Me.chkBuscarPorFecha.TabIndex = 145
        Me.chkBuscarPorFecha.Text = "Buscar por fecha"
        Me.chkBuscarPorFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(43, 87)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(83, 20)
        Me.dtpFechaFin.TabIndex = 3
        Me.dtpFechaFin.Value = New Date(2020, 1, 20, 9, 55, 14, 0)
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(11, 91)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 2
        Me.lblAl.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(43, 55)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(83, 20)
        Me.dtpFechaInicio.TabIndex = 1
        Me.dtpFechaInicio.Value = New Date(2020, 1, 20, 0, 0, 0, 0)
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Location = New System.Drawing.Point(11, 59)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(26, 13)
        Me.lblDel.TabIndex = 0
        Me.lblDel.Text = "Del:"
        '
        'grdDistribuciones
        '
        Me.grdDistribuciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDistribuciones.Location = New System.Drawing.Point(0, 227)
        Me.grdDistribuciones.MainView = Me.grdDatosDistribuciones
        Me.grdDistribuciones.Name = "grdDistribuciones"
        Me.grdDistribuciones.Size = New System.Drawing.Size(1225, 319)
        Me.grdDistribuciones.TabIndex = 159
        Me.grdDistribuciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosDistribuciones})
        '
        'grdDatosDistribuciones
        '
        Me.grdDatosDistribuciones.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosDistribuciones.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosDistribuciones.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosDistribuciones.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosDistribuciones.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosDistribuciones.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosDistribuciones.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosDistribuciones.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosDistribuciones.GridControl = Me.grdDistribuciones
        Me.grdDatosDistribuciones.IndicatorWidth = 30
        Me.grdDatosDistribuciones.Name = "grdDatosDistribuciones"
        Me.grdDatosDistribuciones.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosDistribuciones.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosDistribuciones.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosDistribuciones.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosDistribuciones.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosDistribuciones.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosDistribuciones.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosDistribuciones.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosDistribuciones.OptionsView.ShowFooter = True
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
        'FacturacionAnticipada_AdministradorCoppel_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 609)
        Me.Controls.Add(Me.grdDistribuciones)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "FacturacionAnticipada_AdministradorCoppel_Form"
        Me.Text = "Importación de Distribución de Pedidos Por Tiendas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.pnlVerOT.ResumeLayout(False)
        Me.pnlVerOT.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlCancelar.ResumeLayout(False)
        Me.pnlCancelar.PerformLayout()
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.grpEstatusEntrega.ResumeLayout(False)
        Me.grpEstatusEntrega.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.grpEstatusDistribución.ResumeLayout(False)
        Me.grpEstatusDistribución.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.grpCliente.ResumeLayout(False)
        Me.grpFiltroPedidoSicy.ResumeLayout(False)
        Me.grpFiltroPedidoSicy.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grpPedidoSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltroPedidoSay.ResumeLayout(False)
        Me.grpFiltroPedidoSay.PerformLayout()
        Me.Panel32.ResumeLayout(False)
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPedidos.ResumeLayout(False)
        Me.grpPedidos.PerformLayout()
        Me.grpFiltroFecha.ResumeLayout(False)
        Me.grpFiltroFecha.PerformLayout()
        CType(Me.grdDistribuciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosDistribuciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnImportarDistribucion As Button
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblRegistros As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pnlEncabezadoExpander As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents grpFiltroPedidoSay As GroupBox
    Friend WithEvents Panel32 As Panel
    Friend WithEvents grdPedidoSAY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedidoSAY As MaskedTextBox
    Friend WithEvents grpPedidos As GroupBox
    Friend WithEvents chkDistribucionPendiente As CheckBox
    Friend WithEvents chkDistribucionCapturada As CheckBox
    Friend WithEvents grpFiltroFecha As GroupBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblAl As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblDel As Label
    Friend WithEvents grdDistribuciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosDistribuciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label2 As Label
    Friend WithEvents btnImprimirReporte As Button
    Friend WithEvents lblTextoImprimirPDF As Label
    Friend WithEvents pnlImprimir As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents pnlImportar As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grpEstatusEntrega As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grpEstatusDistribución As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents pnlEntregaVenceHoy As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents pnlAlMenos1DiaEntrega As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grpCliente As GroupBox
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents grpFiltroPedidoSicy As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grpPedidoSICY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedidoSICY As MaskedTextBox
    Friend WithEvents chkBuscarPorFecha As CheckBox
    Friend WithEvents pnlCancelar As Panel
    Friend WithEvents btnCancelarDistribucion As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlVerOT As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents btnVerDetalle As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents btnVerManual As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
