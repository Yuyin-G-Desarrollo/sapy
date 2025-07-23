<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaListaVentasCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaListaVentasCliente))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlCopiarCliente = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnExportarPDF = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.pnlLigarLista = New System.Windows.Forms.Panel()
        Me.btnCambiarListaOriginal = New System.Windows.Forms.Button()
        Me.lblLigaListaOriginaEtiqueta = New System.Windows.Forms.Label()
        Me.pnlCambiarEstatus = New System.Windows.Forms.Panel()
        Me.btnCambiarEstatus = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCopiarListaVariosClientes = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlBotonesRegistro = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.btnCopiarLista = New System.Windows.Forms.Button()
        Me.lblCopiarLista = New System.Windows.Forms.Label()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblContClientes = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSiLigar = New System.Windows.Forms.CheckBox()
        Me.chkNoLigar = New System.Windows.Forms.CheckBox()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grpDatosLV = New System.Windows.Forms.GroupBox()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.txtFacturaFin = New System.Windows.Forms.TextBox()
        Me.txtFacturaInicio = New System.Windows.Forms.TextBox()
        Me.txtDescuentoFin = New System.Windows.Forms.TextBox()
        Me.txtDescuentoInicio = New System.Windows.Forms.TextBox()
        Me.txtIncrementoPPar = New System.Windows.Forms.TextBox()
        Me.lblFactura = New System.Windows.Forms.Label()
        Me.lblFlete = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblIncrementoXPar = New System.Windows.Forms.Label()
        Me.dttFinVigenciaLV = New System.Windows.Forms.DateTimePicker()
        Me.dttFinVigenciaLB = New System.Windows.Forms.DateTimePicker()
        Me.dttInicioVigenciaLV = New System.Windows.Forms.DateTimePicker()
        Me.dttInicioVigenciaLB = New System.Windows.Forms.DateTimePicker()
        Me.lblFinVigenciaLB = New System.Windows.Forms.Label()
        Me.lblFinVigenciaLV = New System.Windows.Forms.Label()
        Me.lblInicioVigenciaLV = New System.Windows.Forms.Label()
        Me.lblInicioVigenciaLB = New System.Windows.Forms.Label()
        Me.lblListaVentas = New System.Windows.Forms.Label()
        Me.cmbListaVentaClientes = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblListaOriginalCliente = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.cmbListaVentas = New System.Windows.Forms.ComboBox()
        Me.lblEstatusListaPrecios = New System.Windows.Forms.Label()
        Me.cmbEstatusLista = New System.Windows.Forms.ComboBox()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.pnlCopiarCliente.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlLigarLista.SuspendLayout()
        Me.pnlCambiarEstatus.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlBotonesRegistro.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grpDatosLV.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlCopiarCliente)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1284, 60)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlCopiarCliente
        '
        Me.pnlCopiarCliente.Controls.Add(Me.pnlExportar)
        Me.pnlCopiarCliente.Controls.Add(Me.pnlLigarLista)
        Me.pnlCopiarCliente.Controls.Add(Me.pnlCambiarEstatus)
        Me.pnlCopiarCliente.Controls.Add(Me.Panel4)
        Me.pnlCopiarCliente.Controls.Add(Me.pnlBotonesRegistro)
        Me.pnlCopiarCliente.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCopiarCliente.Location = New System.Drawing.Point(0, 0)
        Me.pnlCopiarCliente.Name = "pnlCopiarCliente"
        Me.pnlCopiarCliente.Size = New System.Drawing.Size(455, 60)
        Me.pnlCopiarCliente.TabIndex = 70
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.lblExportarExcel)
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.btnExportarPDF)
        Me.pnlExportar.Controls.Add(Me.lblExportarPDF)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(332, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(109, 60)
        Me.pnlExportar.TabIndex = 72
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(4, 34)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 26)
        Me.lblExportarExcel.TabIndex = 75
        Me.lblExportarExcel.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Excel"
        Me.lblExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(11, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 0
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.Image = Global.Ventas.Vista.My.Resources.Resources.pdf_32
        Me.btnExportarPDF.Location = New System.Drawing.Point(67, 3)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarPDF.TabIndex = 0
        Me.btnExportarPDF.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(60, 34)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(46, 26)
        Me.lblExportarPDF.TabIndex = 75
        Me.lblExportarPDF.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PDF"
        Me.lblExportarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLigarLista
        '
        Me.pnlLigarLista.Controls.Add(Me.btnCambiarListaOriginal)
        Me.pnlLigarLista.Controls.Add(Me.lblLigaListaOriginaEtiqueta)
        Me.pnlLigarLista.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLigarLista.Enabled = False
        Me.pnlLigarLista.Location = New System.Drawing.Point(258, 0)
        Me.pnlLigarLista.Name = "pnlLigarLista"
        Me.pnlLigarLista.Size = New System.Drawing.Size(74, 60)
        Me.pnlLigarLista.TabIndex = 79
        '
        'btnCambiarListaOriginal
        '
        Me.btnCambiarListaOriginal.Enabled = False
        Me.btnCambiarListaOriginal.Image = CType(resources.GetObject("btnCambiarListaOriginal.Image"), System.Drawing.Image)
        Me.btnCambiarListaOriginal.Location = New System.Drawing.Point(20, 3)
        Me.btnCambiarListaOriginal.Name = "btnCambiarListaOriginal"
        Me.btnCambiarListaOriginal.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarListaOriginal.TabIndex = 76
        Me.btnCambiarListaOriginal.UseVisualStyleBackColor = True
        '
        'lblLigaListaOriginaEtiqueta
        '
        Me.lblLigaListaOriginaEtiqueta.AutoSize = True
        Me.lblLigaListaOriginaEtiqueta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLigaListaOriginaEtiqueta.Location = New System.Drawing.Point(2, 34)
        Me.lblLigaListaOriginaEtiqueta.Name = "lblLigaListaOriginaEtiqueta"
        Me.lblLigaListaOriginaEtiqueta.Size = New System.Drawing.Size(68, 26)
        Me.lblLigaListaOriginaEtiqueta.TabIndex = 77
        Me.lblLigaListaOriginaEtiqueta.Text = "Cambiar Liga" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lista Original"
        Me.lblLigaListaOriginaEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCambiarEstatus
        '
        Me.pnlCambiarEstatus.Controls.Add(Me.btnCambiarEstatus)
        Me.pnlCambiarEstatus.Controls.Add(Me.Label4)
        Me.pnlCambiarEstatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCambiarEstatus.Location = New System.Drawing.Point(198, 0)
        Me.pnlCambiarEstatus.Name = "pnlCambiarEstatus"
        Me.pnlCambiarEstatus.Size = New System.Drawing.Size(60, 60)
        Me.pnlCambiarEstatus.TabIndex = 74
        '
        'btnCambiarEstatus
        '
        Me.btnCambiarEstatus.Image = Global.Ventas.Vista.My.Resources.Resources.status
        Me.btnCambiarEstatus.Location = New System.Drawing.Point(13, 3)
        Me.btnCambiarEstatus.Name = "btnCambiarEstatus"
        Me.btnCambiarEstatus.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarEstatus.TabIndex = 76
        Me.btnCambiarEstatus.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(7, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 26)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Cambiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Estatus"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnCopiarListaVariosClientes)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(118, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(80, 60)
        Me.Panel4.TabIndex = 78
        '
        'btnCopiarListaVariosClientes
        '
        Me.btnCopiarListaVariosClientes.Image = Global.Ventas.Vista.My.Resources.Resources.copiarclientes
        Me.btnCopiarListaVariosClientes.Location = New System.Drawing.Point(23, 3)
        Me.btnCopiarListaVariosClientes.Name = "btnCopiarListaVariosClientes"
        Me.btnCopiarListaVariosClientes.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiarListaVariosClientes.TabIndex = 76
        Me.btnCopiarListaVariosClientes.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(1, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 26)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Copiar Lista" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Varios Clientes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBotonesRegistro
        '
        Me.pnlBotonesRegistro.Controls.Add(Me.btnAltas)
        Me.pnlBotonesRegistro.Controls.Add(Me.btnCopiarLista)
        Me.pnlBotonesRegistro.Controls.Add(Me.lblCopiarLista)
        Me.pnlBotonesRegistro.Controls.Add(Me.lblAltas)
        Me.pnlBotonesRegistro.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBotonesRegistro.Location = New System.Drawing.Point(0, 0)
        Me.pnlBotonesRegistro.Name = "pnlBotonesRegistro"
        Me.pnlBotonesRegistro.Size = New System.Drawing.Size(118, 60)
        Me.pnlBotonesRegistro.TabIndex = 71
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(3, 3)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 0
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'btnCopiarLista
        '
        Me.btnCopiarLista.Image = Global.Ventas.Vista.My.Resources.Resources.listacopia
        Me.btnCopiarLista.Location = New System.Drawing.Point(63, 3)
        Me.btnCopiarLista.Name = "btnCopiarLista"
        Me.btnCopiarLista.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiarLista.TabIndex = 0
        Me.btnCopiarLista.UseVisualStyleBackColor = True
        '
        'lblCopiarLista
        '
        Me.lblCopiarLista.AutoSize = True
        Me.lblCopiarLista.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarLista.Location = New System.Drawing.Point(43, 34)
        Me.lblCopiarLista.Name = "lblCopiarLista"
        Me.lblCopiarLista.Size = New System.Drawing.Size(72, 26)
        Me.lblCopiarLista.TabIndex = 75
        Me.lblCopiarLista.Text = "Copiar Lista" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mismo Cliente"
        Me.lblCopiarLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(4, 34)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 75
        Me.lblAltas.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(862, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(422, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(41, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(310, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Consulta - Lista de Precios de Cliente"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(354, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblContClientes)
        Me.pnlEstado.Controls.Add(Me.lblClientes)
        Me.pnlEstado.Controls.Add(Me.Panel2)
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 549)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1284, 60)
        Me.pnlEstado.TabIndex = 7
        '
        'lblContClientes
        '
        Me.lblContClientes.AutoSize = True
        Me.lblContClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContClientes.ForeColor = System.Drawing.Color.Black
        Me.lblContClientes.Location = New System.Drawing.Point(56, 33)
        Me.lblContClientes.Name = "lblContClientes"
        Me.lblContClientes.Size = New System.Drawing.Size(25, 25)
        Me.lblContClientes.TabIndex = 69
        Me.lblContClientes.Text = "0"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(12, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 70
        Me.lblClientes.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(824, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 60)
        Me.Panel2.TabIndex = 68
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(129, 25)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(0, 13)
        Me.lblUltimaActualizacion.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Última Actualización: "
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnMostrar)
        Me.pnlBotones.Controls.Add(Me.lblMostrar)
        Me.pnlBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(1060, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(224, 60)
        Me.pnlBotones.TabIndex = 4
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(43, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 22
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(38, 41)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 21
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(103, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 20
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(99, 41)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 19
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(163, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(162, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance1
        Me.grdClientes.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(0, 190)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(1284, 359)
        Me.grdClientes.TabIndex = 8
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.GroupBox1)
        Me.pnlDatos.Controls.Add(Me.btnFiltroCliente)
        Me.pnlDatos.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.pnlDatos.Controls.Add(Me.cmbEstatus)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Controls.Add(Me.dttFinVigenciaLV)
        Me.pnlDatos.Controls.Add(Me.dttFinVigenciaLB)
        Me.pnlDatos.Controls.Add(Me.dttInicioVigenciaLV)
        Me.pnlDatos.Controls.Add(Me.dttInicioVigenciaLB)
        Me.pnlDatos.Controls.Add(Me.lblFinVigenciaLB)
        Me.pnlDatos.Controls.Add(Me.lblFinVigenciaLV)
        Me.pnlDatos.Controls.Add(Me.lblInicioVigenciaLV)
        Me.pnlDatos.Controls.Add(Me.lblInicioVigenciaLB)
        Me.pnlDatos.Controls.Add(Me.lblListaVentas)
        Me.pnlDatos.Controls.Add(Me.cmbListaVentaClientes)
        Me.pnlDatos.Controls.Add(Me.Label18)
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Controls.Add(Me.lblListaOriginalCliente)
        Me.pnlDatos.Controls.Add(Me.lblEstatus)
        Me.pnlDatos.Controls.Add(Me.cmbListaVentas)
        Me.pnlDatos.Controls.Add(Me.lblEstatusListaPrecios)
        Me.pnlDatos.Controls.Add(Me.cmbEstatusLista)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1284, 130)
        Me.pnlDatos.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSiLigar)
        Me.GroupBox1.Controls.Add(Me.chkNoLigar)
        Me.GroupBox1.Location = New System.Drawing.Point(735, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(110, 74)
        Me.GroupBox1.TabIndex = 95
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ligar a Lista Original (LLO)"
        '
        'chkSiLigar
        '
        Me.chkSiLigar.AutoSize = True
        Me.chkSiLigar.Checked = True
        Me.chkSiLigar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSiLigar.Location = New System.Drawing.Point(14, 40)
        Me.chkSiLigar.Name = "chkSiLigar"
        Me.chkSiLigar.Size = New System.Drawing.Size(35, 17)
        Me.chkSiLigar.TabIndex = 1
        Me.chkSiLigar.Text = "Si"
        Me.chkSiLigar.UseVisualStyleBackColor = True
        '
        'chkNoLigar
        '
        Me.chkNoLigar.AutoSize = True
        Me.chkNoLigar.Checked = True
        Me.chkNoLigar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoLigar.Location = New System.Drawing.Point(61, 40)
        Me.chkNoLigar.Name = "chkNoLigar"
        Me.chkNoLigar.Size = New System.Drawing.Size(40, 17)
        Me.chkNoLigar.TabIndex = 0
        Me.chkNoLigar.Text = "No"
        Me.chkNoLigar.UseVisualStyleBackColor = True
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Image = Global.Ventas.Vista.My.Resources.Resources.buscacliente
        Me.btnFiltroCliente.Location = New System.Drawing.Point(415, 77)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltroCliente.TabIndex = 94
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(4, 112)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 86
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'cmbEstatus
        '
        Me.cmbEstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(530, 88)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(199, 21)
        Me.cmbEstatus.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(489, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Estatus"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grpDatosLV)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(825, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(400, 130)
        Me.Panel3.TabIndex = 83
        '
        'grpDatosLV
        '
        Me.grpDatosLV.Controls.Add(Me.txtIVA)
        Me.grpDatosLV.Controls.Add(Me.txtFlete)
        Me.grpDatosLV.Controls.Add(Me.txtFacturaFin)
        Me.grpDatosLV.Controls.Add(Me.txtFacturaInicio)
        Me.grpDatosLV.Controls.Add(Me.txtDescuentoFin)
        Me.grpDatosLV.Controls.Add(Me.txtDescuentoInicio)
        Me.grpDatosLV.Controls.Add(Me.txtIncrementoPPar)
        Me.grpDatosLV.Controls.Add(Me.lblFactura)
        Me.grpDatosLV.Controls.Add(Me.lblFlete)
        Me.grpDatosLV.Controls.Add(Me.lblIva)
        Me.grpDatosLV.Controls.Add(Me.lblDescuento)
        Me.grpDatosLV.Controls.Add(Me.lblIncrementoXPar)
        Me.grpDatosLV.Enabled = False
        Me.grpDatosLV.Location = New System.Drawing.Point(3, 34)
        Me.grpDatosLV.Name = "grpDatosLV"
        Me.grpDatosLV.Size = New System.Drawing.Size(397, 93)
        Me.grpDatosLV.TabIndex = 82
        Me.grpDatosLV.TabStop = False
        Me.grpDatosLV.Text = "Configuración de la Lista de Ventas"
        '
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(26, 56)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(130, 20)
        Me.txtIVA.TabIndex = 77
        '
        'txtFlete
        '
        Me.txtFlete.Location = New System.Drawing.Point(185, 56)
        Me.txtFlete.Multiline = True
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(209, 34)
        Me.txtFlete.TabIndex = 77
        '
        'txtFacturaFin
        '
        Me.txtFacturaFin.Location = New System.Drawing.Point(338, 21)
        Me.txtFacturaFin.Name = "txtFacturaFin"
        Me.txtFacturaFin.Size = New System.Drawing.Size(46, 20)
        Me.txtFacturaFin.TabIndex = 77
        Me.txtFacturaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFacturaInicio
        '
        Me.txtFacturaInicio.Location = New System.Drawing.Point(280, 21)
        Me.txtFacturaInicio.Name = "txtFacturaInicio"
        Me.txtFacturaInicio.Size = New System.Drawing.Size(46, 20)
        Me.txtFacturaInicio.TabIndex = 77
        Me.txtFacturaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoFin
        '
        Me.txtDescuentoFin.Location = New System.Drawing.Point(185, 21)
        Me.txtDescuentoFin.Name = "txtDescuentoFin"
        Me.txtDescuentoFin.Size = New System.Drawing.Size(46, 20)
        Me.txtDescuentoFin.TabIndex = 77
        Me.txtDescuentoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoInicio
        '
        Me.txtDescuentoInicio.Location = New System.Drawing.Point(127, 21)
        Me.txtDescuentoInicio.Name = "txtDescuentoInicio"
        Me.txtDescuentoInicio.Size = New System.Drawing.Size(46, 20)
        Me.txtDescuentoInicio.TabIndex = 77
        Me.txtDescuentoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIncrementoPPar
        '
        Me.txtIncrementoPPar.Location = New System.Drawing.Point(36, 21)
        Me.txtIncrementoPPar.Name = "txtIncrementoPPar"
        Me.txtIncrementoPPar.Size = New System.Drawing.Size(46, 20)
        Me.txtIncrementoPPar.TabIndex = 77
        Me.txtIncrementoPPar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Location = New System.Drawing.Point(244, 25)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(24, 13)
        Me.lblFactura.TabIndex = 76
        Me.lblFactura.Text = "F %"
        '
        'lblFlete
        '
        Me.lblFlete.AutoSize = True
        Me.lblFlete.Location = New System.Drawing.Point(156, 60)
        Me.lblFlete.Name = "lblFlete"
        Me.lblFlete.Size = New System.Drawing.Size(30, 13)
        Me.lblFlete.TabIndex = 76
        Me.lblFlete.Text = "Flete"
        '
        'lblIva
        '
        Me.lblIva.AutoSize = True
        Me.lblIva.Location = New System.Drawing.Point(3, 60)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(24, 13)
        Me.lblIva.TabIndex = 76
        Me.lblIva.Text = "IVA"
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Location = New System.Drawing.Point(100, 25)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(26, 13)
        Me.lblDescuento.TabIndex = 76
        Me.lblDescuento.Text = "D %"
        '
        'lblIncrementoXPar
        '
        Me.lblIncrementoXPar.AutoSize = True
        Me.lblIncrementoXPar.Location = New System.Drawing.Point(3, 25)
        Me.lblIncrementoXPar.Name = "lblIncrementoXPar"
        Me.lblIncrementoXPar.Size = New System.Drawing.Size(28, 13)
        Me.lblIncrementoXPar.TabIndex = 76
        Me.lblIncrementoXPar.Text = "I x P"
        '
        'dttFinVigenciaLV
        '
        Me.dttFinVigenciaLV.Enabled = False
        Me.dttFinVigenciaLV.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFinVigenciaLV.Location = New System.Drawing.Point(647, 64)
        Me.dttFinVigenciaLV.Name = "dttFinVigenciaLV"
        Me.dttFinVigenciaLV.Size = New System.Drawing.Size(82, 20)
        Me.dttFinVigenciaLV.TabIndex = 81
        '
        'dttFinVigenciaLB
        '
        Me.dttFinVigenciaLB.Enabled = False
        Me.dttFinVigenciaLB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFinVigenciaLB.Location = New System.Drawing.Point(647, 40)
        Me.dttFinVigenciaLB.Name = "dttFinVigenciaLB"
        Me.dttFinVigenciaLB.Size = New System.Drawing.Size(82, 20)
        Me.dttFinVigenciaLB.TabIndex = 80
        '
        'dttInicioVigenciaLV
        '
        Me.dttInicioVigenciaLV.Enabled = False
        Me.dttInicioVigenciaLV.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttInicioVigenciaLV.Location = New System.Drawing.Point(530, 64)
        Me.dttInicioVigenciaLV.Name = "dttInicioVigenciaLV"
        Me.dttInicioVigenciaLV.Size = New System.Drawing.Size(82, 20)
        Me.dttInicioVigenciaLV.TabIndex = 79
        '
        'dttInicioVigenciaLB
        '
        Me.dttInicioVigenciaLB.Enabled = False
        Me.dttInicioVigenciaLB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttInicioVigenciaLB.Location = New System.Drawing.Point(530, 40)
        Me.dttInicioVigenciaLB.Name = "dttInicioVigenciaLB"
        Me.dttInicioVigenciaLB.Size = New System.Drawing.Size(82, 20)
        Me.dttInicioVigenciaLB.TabIndex = 78
        '
        'lblFinVigenciaLB
        '
        Me.lblFinVigenciaLB.AutoSize = True
        Me.lblFinVigenciaLB.Location = New System.Drawing.Point(620, 44)
        Me.lblFinVigenciaLB.Name = "lblFinVigenciaLB"
        Me.lblFinVigenciaLB.Size = New System.Drawing.Size(21, 13)
        Me.lblFinVigenciaLB.TabIndex = 77
        Me.lblFinVigenciaLB.Text = "Fin"
        '
        'lblFinVigenciaLV
        '
        Me.lblFinVigenciaLV.AutoSize = True
        Me.lblFinVigenciaLV.Location = New System.Drawing.Point(620, 68)
        Me.lblFinVigenciaLV.Name = "lblFinVigenciaLV"
        Me.lblFinVigenciaLV.Size = New System.Drawing.Size(21, 13)
        Me.lblFinVigenciaLV.TabIndex = 76
        Me.lblFinVigenciaLV.Text = "Fin"
        '
        'lblInicioVigenciaLV
        '
        Me.lblInicioVigenciaLV.AutoSize = True
        Me.lblInicioVigenciaLV.Location = New System.Drawing.Point(489, 68)
        Me.lblInicioVigenciaLV.Name = "lblInicioVigenciaLV"
        Me.lblInicioVigenciaLV.Size = New System.Drawing.Size(32, 13)
        Me.lblInicioVigenciaLV.TabIndex = 75
        Me.lblInicioVigenciaLV.Text = "Inicio"
        '
        'lblInicioVigenciaLB
        '
        Me.lblInicioVigenciaLB.AutoSize = True
        Me.lblInicioVigenciaLB.Location = New System.Drawing.Point(489, 44)
        Me.lblInicioVigenciaLB.Name = "lblInicioVigenciaLB"
        Me.lblInicioVigenciaLB.Size = New System.Drawing.Size(32, 13)
        Me.lblInicioVigenciaLB.TabIndex = 74
        Me.lblInicioVigenciaLB.Text = "Inicio"
        '
        'lblListaVentas
        '
        Me.lblListaVentas.AutoSize = True
        Me.lblListaVentas.Location = New System.Drawing.Point(4, 68)
        Me.lblListaVentas.Name = "lblListaVentas"
        Me.lblListaVentas.Size = New System.Drawing.Size(80, 13)
        Me.lblListaVentas.TabIndex = 73
        Me.lblListaVentas.Text = "Lista de Ventas"
        '
        'cmbListaVentaClientes
        '
        Me.cmbListaVentaClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbListaVentaClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbListaVentaClientes.FormattingEnabled = True
        Me.cmbListaVentaClientes.Location = New System.Drawing.Point(87, 88)
        Me.cmbListaVentaClientes.Name = "cmbListaVentaClientes"
        Me.cmbListaVentaClientes.Size = New System.Drawing.Size(323, 21)
        Me.cmbListaVentaClientes.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 92)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Cliente"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1225, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(59, 130)
        Me.Panel1.TabIndex = 72
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(31, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 69
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(3, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 68
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblListaOriginalCliente
        '
        Me.lblListaOriginalCliente.AutoSize = True
        Me.lblListaOriginalCliente.Location = New System.Drawing.Point(237, 20)
        Me.lblListaOriginalCliente.Name = "lblListaOriginalCliente"
        Me.lblListaOriginalCliente.Size = New System.Drawing.Size(0, 13)
        Me.lblListaOriginalCliente.TabIndex = 69
        Me.lblListaOriginalCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(412, 44)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(77, 13)
        Me.lblEstatus.TabIndex = 61
        Me.lblEstatus.Text = "AUTORIZADA"
        '
        'cmbListaVentas
        '
        Me.cmbListaVentas.FormattingEnabled = True
        Me.cmbListaVentas.Location = New System.Drawing.Point(87, 64)
        Me.cmbListaVentas.Name = "cmbListaVentas"
        Me.cmbListaVentas.Size = New System.Drawing.Size(323, 21)
        Me.cmbListaVentas.TabIndex = 1
        '
        'lblEstatusListaPrecios
        '
        Me.lblEstatusListaPrecios.AutoSize = True
        Me.lblEstatusListaPrecios.Location = New System.Drawing.Point(4, 44)
        Me.lblEstatusListaPrecios.Name = "lblEstatusListaPrecios"
        Me.lblEstatusListaPrecios.Size = New System.Drawing.Size(63, 13)
        Me.lblEstatusListaPrecios.TabIndex = 7
        Me.lblEstatusListaPrecios.Text = "* Lista Base"
        '
        'cmbEstatusLista
        '
        Me.cmbEstatusLista.FormattingEnabled = True
        Me.cmbEstatusLista.Location = New System.Drawing.Point(87, 40)
        Me.cmbEstatusLista.Name = "cmbEstatusLista"
        Me.cmbEstatusLista.Size = New System.Drawing.Size(323, 21)
        Me.cmbEstatusLista.TabIndex = 6
        '
        'frmConsultaListaVentasCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1284, 609)
        Me.Controls.Add(Me.grdClientes)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmConsultaListaVentasCliente"
        Me.Text = "Consulta - Lista de Precios de Cliente"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlCopiarCliente.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlLigarLista.ResumeLayout(False)
        Me.pnlLigarLista.PerformLayout()
        Me.pnlCambiarEstatus.ResumeLayout(False)
        Me.pnlCambiarEstatus.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlBotonesRegistro.ResumeLayout(False)
        Me.pnlBotonesRegistro.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.grpDatosLV.ResumeLayout(False)
        Me.grpDatosLV.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblListaOriginalCliente As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents cmbListaVentas As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatusLista As System.Windows.Forms.ComboBox
    Friend WithEvents cmbListaVentaClientes As System.Windows.Forms.ComboBox
    Friend WithEvents lblListaVentas As System.Windows.Forms.Label
    Friend WithEvents pnlCopiarCliente As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grpDatosLV As System.Windows.Forms.GroupBox
    Friend WithEvents dttFinVigenciaLV As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttFinVigenciaLB As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttInicioVigenciaLV As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttInicioVigenciaLB As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFinVigenciaLB As System.Windows.Forms.Label
    Friend WithEvents lblFinVigenciaLV As System.Windows.Forms.Label
    Friend WithEvents lblInicioVigenciaLV As System.Windows.Forms.Label
    Friend WithEvents lblInicioVigenciaLB As System.Windows.Forms.Label
    Friend WithEvents lblEstatusListaPrecios As System.Windows.Forms.Label
    Friend WithEvents txtFacturaInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuentoInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtIncrementoPPar As System.Windows.Forms.TextBox
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblIncrementoXPar As System.Windows.Forms.Label
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents lblFlete As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents lblCopiarLista As System.Windows.Forms.Label
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents btnExportarPDF As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnCopiarLista As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents txtFacturaFin As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuentoFin As System.Windows.Forms.TextBox
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents pnlCambiarEstatus As System.Windows.Forms.Panel
    Friend WithEvents btnCambiarEstatus As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnCopiarListaVariosClientes As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesRegistro As System.Windows.Forms.Panel
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents lblContClientes As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents btnFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents pnlLigarLista As System.Windows.Forms.Panel
    Friend WithEvents btnCambiarListaOriginal As System.Windows.Forms.Button
    Friend WithEvents lblLigaListaOriginaEtiqueta As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSiLigar As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoLigar As System.Windows.Forms.CheckBox
End Class
