<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPreciosClienteAlta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPreciosClienteAlta))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoModelo_Sicy = New System.Windows.Forms.RadioButton()
        Me.rdo_ModeloSAY = New System.Windows.Forms.RadioButton()
        Me.lblMostrarModelo = New System.Windows.Forms.Label()
        Me.lblAtn = New System.Windows.Forms.Label()
        Me.txtAtn = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMonedaNombre = New System.Windows.Forms.Label()
        Me.lblFechaFinListaDato = New System.Windows.Forms.Label()
        Me.lblFechaInicioLista_Dato = New System.Windows.Forms.Label()
        Me.lblINCOTERM_DATO = New System.Windows.Forms.Label()
        Me.chkDescuentoAplicado = New System.Windows.Forms.CheckBox()
        Me.lblMoneda_Dato = New System.Windows.Forms.Label()
        Me.lblParidad_Dato = New System.Windows.Forms.Label()
        Me.lblINCOTERM = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.lblParidad = New System.Windows.Forms.Label()
        Me.lblFechaInicioLista = New System.Windows.Forms.Label()
        Me.lblFechaFinLista = New System.Windows.Forms.Label()
        Me.gboxListaVentas = New System.Windows.Forms.GroupBox()
        Me.lblIncrementoXPar_Dato = New System.Windows.Forms.Label()
        Me.lblDescuento_Dato = New System.Windows.Forms.Label()
        Me.lblFactuacion_Dato = New System.Windows.Forms.Label()
        Me.lblIVA_Dato = New System.Windows.Forms.Label()
        Me.lblFlete_Dato = New System.Windows.Forms.Label()
        Me.lblIncrementoXPar = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblFacturacion = New System.Windows.Forms.Label()
        Me.lblIVA = New System.Windows.Forms.Label()
        Me.lblFlete = New System.Windows.Forms.Label()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.grpArticulos = New System.Windows.Forms.GroupBox()
        Me.rdoTodosLosModelos = New System.Windows.Forms.RadioButton()
        Me.rdoModelosPedido = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dttFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dttFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.grpAgente = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.grdAgentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblListaVentaCliente = New System.Windows.Forms.Label()
        Me.cmbListaVentasCliente = New System.Windows.Forms.ComboBox()
        Me.lblListaVenta = New System.Windows.Forms.Label()
        Me.lblMensajeSinListaVentas = New System.Windows.Forms.Label()
        Me.gboxParidad = New System.Windows.Forms.GroupBox()
        Me.lblParidadMonedaValor = New System.Windows.Forms.Label()
        Me.lblParidadFecha = New System.Windows.Forms.Label()
        Me.lblParidadIgual = New System.Windows.Forms.Label()
        Me.lblParidadMoneda = New System.Windows.Forms.Label()
        Me.cmbListaVentas = New System.Windows.Forms.ComboBox()
        Me.lblEstatusListaPrecios = New System.Windows.Forms.Label()
        Me.cmbListaBase = New System.Windows.Forms.ComboBox()
        Me.gboxMoneda = New System.Windows.Forms.GroupBox()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.grpTipodeReporte = New System.Windows.Forms.GroupBox()
        Me.txtClaveSAT = New System.Windows.Forms.TextBox()
        Me.RdoListaClaveSat = New System.Windows.Forms.RadioButton()
        Me.rdoModelaje = New System.Windows.Forms.RadioButton()
        Me.chkFamilias = New System.Windows.Forms.CheckBox()
        Me.cmbRamos = New System.Windows.Forms.ComboBox()
        Me.RdoSimulador = New System.Windows.Forms.RadioButton()
        Me.lblRamos = New System.Windows.Forms.Label()
        Me.rdoListaPrecioSugerida = New System.Windows.Forms.RadioButton()
        Me.rdoListadePrecios = New System.Windows.Forms.RadioButton()
        Me.chkColecciones = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoPrecioPesosActual = New System.Windows.Forms.RadioButton()
        Me.rdoPrecioPorcentajeActual = New System.Windows.Forms.RadioButton()
        Me.numPrecioIncrementoParActual = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Pnl_ExportarPDF = New System.Windows.Forms.Panel()
        Me.btnGenerarReportePDF = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnHistorico = New System.Windows.Forms.Button()
        Me.lblHistorico = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlActualizacionIzq = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.pnlBotonesPie = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnVolverCargarReporte = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.tbtReporteCliente = New System.Windows.Forms.TabPage()
        Me.grdReporte = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbtListasDeClientes = New System.Windows.Forms.TabControl()
        Me.grpDatos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gboxListaVentas.SuspendLayout()
        Me.gboxFiltros.SuspendLayout()
        Me.grpArticulos.SuspendLayout()
        Me.grpAgente.SuspendLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxParidad.SuspendLayout()
        Me.gboxMoneda.SuspendLayout()
        Me.grpTipodeReporte.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numPrecioIncrementoParActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Pnl_ExportarPDF.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlActualizacionIzq.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlBotonesPie.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tbtReporteCliente.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtListasDeClientes.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.btnFiltroCliente)
        Me.grpDatos.Controls.Add(Me.Panel2)
        Me.grpDatos.Controls.Add(Me.lblMostrarModelo)
        Me.grpDatos.Controls.Add(Me.lblAtn)
        Me.grpDatos.Controls.Add(Me.txtAtn)
        Me.grpDatos.Controls.Add(Me.GroupBox3)
        Me.grpDatos.Controls.Add(Me.gboxListaVentas)
        Me.grpDatos.Controls.Add(Me.gboxFiltros)
        Me.grpDatos.Controls.Add(Me.lblListaVentaCliente)
        Me.grpDatos.Controls.Add(Me.cmbListaVentasCliente)
        Me.grpDatos.Controls.Add(Me.lblListaVenta)
        Me.grpDatos.Controls.Add(Me.lblMensajeSinListaVentas)
        Me.grpDatos.Controls.Add(Me.gboxParidad)
        Me.grpDatos.Controls.Add(Me.cmbListaVentas)
        Me.grpDatos.Controls.Add(Me.lblEstatusListaPrecios)
        Me.grpDatos.Controls.Add(Me.cmbListaBase)
        Me.grpDatos.Controls.Add(Me.gboxMoneda)
        Me.grpDatos.Controls.Add(Me.grpTipodeReporte)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.cmbClientes)
        Me.grpDatos.Controls.Add(Me.Panel1)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatos.Location = New System.Drawing.Point(0, 60)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(1236, 256)
        Me.grpDatos.TabIndex = 12
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos de Registro"
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Image = Global.Ventas.Vista.My.Resources.Resources.buscacliente
        Me.btnFiltroCliente.Location = New System.Drawing.Point(447, 13)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltroCliente.TabIndex = 93
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoModelo_Sicy)
        Me.Panel2.Controls.Add(Me.rdo_ModeloSAY)
        Me.Panel2.Location = New System.Drawing.Point(1099, 233)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(128, 19)
        Me.Panel2.TabIndex = 92
        '
        'rdoModelo_Sicy
        '
        Me.rdoModelo_Sicy.AutoSize = True
        Me.rdoModelo_Sicy.Checked = True
        Me.rdoModelo_Sicy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModelo_Sicy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoModelo_Sicy.Location = New System.Drawing.Point(64, 1)
        Me.rdoModelo_Sicy.Name = "rdoModelo_Sicy"
        Me.rdoModelo_Sicy.Size = New System.Drawing.Size(49, 17)
        Me.rdoModelo_Sicy.TabIndex = 35
        Me.rdoModelo_Sicy.TabStop = True
        Me.rdoModelo_Sicy.Text = "SICY"
        Me.rdoModelo_Sicy.UseVisualStyleBackColor = True
        '
        'rdo_ModeloSAY
        '
        Me.rdo_ModeloSAY.AutoSize = True
        Me.rdo_ModeloSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_ModeloSAY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdo_ModeloSAY.Location = New System.Drawing.Point(12, 1)
        Me.rdo_ModeloSAY.Name = "rdo_ModeloSAY"
        Me.rdo_ModeloSAY.Size = New System.Drawing.Size(46, 17)
        Me.rdo_ModeloSAY.TabIndex = 34
        Me.rdo_ModeloSAY.Text = "SAY"
        Me.rdo_ModeloSAY.UseVisualStyleBackColor = True
        '
        'lblMostrarModelo
        '
        Me.lblMostrarModelo.AutoSize = True
        Me.lblMostrarModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarModelo.Location = New System.Drawing.Point(999, 236)
        Me.lblMostrarModelo.Name = "lblMostrarModelo"
        Me.lblMostrarModelo.Size = New System.Drawing.Size(94, 13)
        Me.lblMostrarModelo.TabIndex = 91
        Me.lblMostrarModelo.Text = "Mostrar Modelo"
        '
        'lblAtn
        '
        Me.lblAtn.AutoSize = True
        Me.lblAtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtn.Location = New System.Drawing.Point(448, 235)
        Me.lblAtn.Name = "lblAtn"
        Me.lblAtn.Size = New System.Drawing.Size(133, 13)
        Me.lblAtn.TabIndex = 90
        Me.lblAtn.Text = "At'n (capturar nombre)"
        '
        'txtAtn
        '
        Me.txtAtn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtn.Location = New System.Drawing.Point(581, 232)
        Me.txtAtn.Name = "txtAtn"
        Me.txtAtn.Size = New System.Drawing.Size(394, 20)
        Me.txtAtn.TabIndex = 33
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblMonedaNombre)
        Me.GroupBox3.Controls.Add(Me.lblFechaFinListaDato)
        Me.GroupBox3.Controls.Add(Me.lblFechaInicioLista_Dato)
        Me.GroupBox3.Controls.Add(Me.lblINCOTERM_DATO)
        Me.GroupBox3.Controls.Add(Me.chkDescuentoAplicado)
        Me.GroupBox3.Controls.Add(Me.lblMoneda_Dato)
        Me.GroupBox3.Controls.Add(Me.lblParidad_Dato)
        Me.GroupBox3.Controls.Add(Me.lblINCOTERM)
        Me.GroupBox3.Controls.Add(Me.lblMoneda)
        Me.GroupBox3.Controls.Add(Me.lblParidad)
        Me.GroupBox3.Controls.Add(Me.lblFechaInicioLista)
        Me.GroupBox3.Controls.Add(Me.lblFechaFinLista)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(234, 114)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 136)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lista Precios"
        '
        'lblMonedaNombre
        '
        Me.lblMonedaNombre.AutoSize = True
        Me.lblMonedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaNombre.Location = New System.Drawing.Point(105, 89)
        Me.lblMonedaNombre.Name = "lblMonedaNombre"
        Me.lblMonedaNombre.Size = New System.Drawing.Size(36, 13)
        Me.lblMonedaNombre.TabIndex = 87
        Me.lblMonedaNombre.Text = "Pesos"
        '
        'lblFechaFinListaDato
        '
        Me.lblFechaFinListaDato.AutoSize = True
        Me.lblFechaFinListaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinListaDato.Location = New System.Drawing.Point(65, 36)
        Me.lblFechaFinListaDato.Name = "lblFechaFinListaDato"
        Me.lblFechaFinListaDato.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaFinListaDato.TabIndex = 86
        Me.lblFechaFinListaDato.Text = "01/01/2000"
        '
        'lblFechaInicioLista_Dato
        '
        Me.lblFechaInicioLista_Dato.AutoSize = True
        Me.lblFechaInicioLista_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioLista_Dato.Location = New System.Drawing.Point(65, 18)
        Me.lblFechaInicioLista_Dato.Name = "lblFechaInicioLista_Dato"
        Me.lblFechaInicioLista_Dato.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaInicioLista_Dato.TabIndex = 81
        Me.lblFechaInicioLista_Dato.Text = "01/01/2000"
        '
        'lblINCOTERM_DATO
        '
        Me.lblINCOTERM_DATO.AutoSize = True
        Me.lblINCOTERM_DATO.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblINCOTERM_DATO.Location = New System.Drawing.Point(65, 54)
        Me.lblINCOTERM_DATO.Name = "lblINCOTERM_DATO"
        Me.lblINCOTERM_DATO.Size = New System.Drawing.Size(118, 13)
        Me.lblINCOTERM_DATO.TabIndex = 83
        Me.lblINCOTERM_DATO.Text = "FOB - LIBRE A BORDO"
        '
        'chkDescuentoAplicado
        '
        Me.chkDescuentoAplicado.AutoSize = True
        Me.chkDescuentoAplicado.Enabled = False
        Me.chkDescuentoAplicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDescuentoAplicado.Location = New System.Drawing.Point(9, 102)
        Me.chkDescuentoAplicado.Name = "chkDescuentoAplicado"
        Me.chkDescuentoAplicado.Size = New System.Drawing.Size(151, 30)
        Me.chkDescuentoAplicado.TabIndex = 11
        Me.chkDescuentoAplicado.Text = "¿Calcular Lista de Precios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " con descuento aplicado?"
        Me.chkDescuentoAplicado.UseVisualStyleBackColor = True
        '
        'lblMoneda_Dato
        '
        Me.lblMoneda_Dato.AutoSize = True
        Me.lblMoneda_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda_Dato.Location = New System.Drawing.Point(65, 72)
        Me.lblMoneda_Dato.Name = "lblMoneda_Dato"
        Me.lblMoneda_Dato.Size = New System.Drawing.Size(44, 13)
        Me.lblMoneda_Dato.TabIndex = 84
        Me.lblMoneda_Dato.Text = "DOLAR"
        '
        'lblParidad_Dato
        '
        Me.lblParidad_Dato.AutoSize = True
        Me.lblParidad_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidad_Dato.Location = New System.Drawing.Point(65, 89)
        Me.lblParidad_Dato.Name = "lblParidad_Dato"
        Me.lblParidad_Dato.Size = New System.Drawing.Size(25, 13)
        Me.lblParidad_Dato.TabIndex = 85
        Me.lblParidad_Dato.Text = "100"
        '
        'lblINCOTERM
        '
        Me.lblINCOTERM.AutoSize = True
        Me.lblINCOTERM.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblINCOTERM.Location = New System.Drawing.Point(6, 54)
        Me.lblINCOTERM.Name = "lblINCOTERM"
        Me.lblINCOTERM.Size = New System.Drawing.Size(60, 13)
        Me.lblINCOTERM.TabIndex = 35
        Me.lblINCOTERM.Text = "INCOTERM"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.Location = New System.Drawing.Point(6, 72)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 78
        Me.lblMoneda.Text = "Moneda"
        '
        'lblParidad
        '
        Me.lblParidad.AutoSize = True
        Me.lblParidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidad.Location = New System.Drawing.Point(6, 89)
        Me.lblParidad.Name = "lblParidad"
        Me.lblParidad.Size = New System.Drawing.Size(43, 13)
        Me.lblParidad.TabIndex = 80
        Me.lblParidad.Text = "Paridad"
        '
        'lblFechaInicioLista
        '
        Me.lblFechaInicioLista.AutoSize = True
        Me.lblFechaInicioLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioLista.Location = New System.Drawing.Point(6, 18)
        Me.lblFechaInicioLista.Name = "lblFechaInicioLista"
        Me.lblFechaInicioLista.Size = New System.Drawing.Size(32, 13)
        Me.lblFechaInicioLista.TabIndex = 11
        Me.lblFechaInicioLista.Text = "Inicio"
        '
        'lblFechaFinLista
        '
        Me.lblFechaFinLista.AutoSize = True
        Me.lblFechaFinLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinLista.Location = New System.Drawing.Point(6, 36)
        Me.lblFechaFinLista.Name = "lblFechaFinLista"
        Me.lblFechaFinLista.Size = New System.Drawing.Size(21, 13)
        Me.lblFechaFinLista.TabIndex = 7
        Me.lblFechaFinLista.Text = "Fin"
        '
        'gboxListaVentas
        '
        Me.gboxListaVentas.Controls.Add(Me.lblIncrementoXPar_Dato)
        Me.gboxListaVentas.Controls.Add(Me.lblDescuento_Dato)
        Me.gboxListaVentas.Controls.Add(Me.lblFactuacion_Dato)
        Me.gboxListaVentas.Controls.Add(Me.lblIVA_Dato)
        Me.gboxListaVentas.Controls.Add(Me.lblFlete_Dato)
        Me.gboxListaVentas.Controls.Add(Me.lblIncrementoXPar)
        Me.gboxListaVentas.Controls.Add(Me.lblDescuento)
        Me.gboxListaVentas.Controls.Add(Me.lblFacturacion)
        Me.gboxListaVentas.Controls.Add(Me.lblIVA)
        Me.gboxListaVentas.Controls.Add(Me.lblFlete)
        Me.gboxListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxListaVentas.Location = New System.Drawing.Point(13, 114)
        Me.gboxListaVentas.Name = "gboxListaVentas"
        Me.gboxListaVentas.Size = New System.Drawing.Size(215, 136)
        Me.gboxListaVentas.TabIndex = 9
        Me.gboxListaVentas.TabStop = False
        Me.gboxListaVentas.Text = "Lista Ventas"
        '
        'lblIncrementoXPar_Dato
        '
        Me.lblIncrementoXPar_Dato.AutoSize = True
        Me.lblIncrementoXPar_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrementoXPar_Dato.Location = New System.Drawing.Point(91, 18)
        Me.lblIncrementoXPar_Dato.Name = "lblIncrementoXPar_Dato"
        Me.lblIncrementoXPar_Dato.Size = New System.Drawing.Size(36, 13)
        Me.lblIncrementoXPar_Dato.TabIndex = 81
        Me.lblIncrementoXPar_Dato.Text = "100 %"
        '
        'lblDescuento_Dato
        '
        Me.lblDescuento_Dato.AutoSize = True
        Me.lblDescuento_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento_Dato.Location = New System.Drawing.Point(91, 36)
        Me.lblDescuento_Dato.Name = "lblDescuento_Dato"
        Me.lblDescuento_Dato.Size = New System.Drawing.Size(36, 13)
        Me.lblDescuento_Dato.TabIndex = 82
        Me.lblDescuento_Dato.Text = "100 %"
        '
        'lblFactuacion_Dato
        '
        Me.lblFactuacion_Dato.AutoSize = True
        Me.lblFactuacion_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactuacion_Dato.Location = New System.Drawing.Point(91, 54)
        Me.lblFactuacion_Dato.Name = "lblFactuacion_Dato"
        Me.lblFactuacion_Dato.Size = New System.Drawing.Size(36, 13)
        Me.lblFactuacion_Dato.TabIndex = 83
        Me.lblFactuacion_Dato.Text = "100 %"
        '
        'lblIVA_Dato
        '
        Me.lblIVA_Dato.AutoSize = True
        Me.lblIVA_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA_Dato.Location = New System.Drawing.Point(91, 72)
        Me.lblIVA_Dato.Name = "lblIVA_Dato"
        Me.lblIVA_Dato.Size = New System.Drawing.Size(50, 13)
        Me.lblIVA_Dato.TabIndex = 84
        Me.lblIVA_Dato.Text = "MÁS IVA"
        '
        'lblFlete_Dato
        '
        Me.lblFlete_Dato.AutoSize = True
        Me.lblFlete_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlete_Dato.Location = New System.Drawing.Point(91, 90)
        Me.lblFlete_Dato.Name = "lblFlete_Dato"
        Me.lblFlete_Dato.Size = New System.Drawing.Size(99, 13)
        Me.lblFlete_Dato.TabIndex = 85
        Me.lblFlete_Dato.Text = "CONVENIO YUYIN"
        '
        'lblIncrementoXPar
        '
        Me.lblIncrementoXPar.AutoSize = True
        Me.lblIncrementoXPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrementoXPar.Location = New System.Drawing.Point(6, 18)
        Me.lblIncrementoXPar.Name = "lblIncrementoXPar"
        Me.lblIncrementoXPar.Size = New System.Drawing.Size(24, 13)
        Me.lblIncrementoXPar.TabIndex = 22
        Me.lblIncrementoXPar.Text = "IXP"
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(6, 36)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(59, 13)
        Me.lblDescuento.TabIndex = 34
        Me.lblDescuento.Text = "Descuento"
        '
        'lblFacturacion
        '
        Me.lblFacturacion.AutoSize = True
        Me.lblFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturacion.Location = New System.Drawing.Point(6, 54)
        Me.lblFacturacion.Name = "lblFacturacion"
        Me.lblFacturacion.Size = New System.Drawing.Size(63, 13)
        Me.lblFacturacion.TabIndex = 35
        Me.lblFacturacion.Text = "Facturación"
        '
        'lblIVA
        '
        Me.lblIVA.AutoSize = True
        Me.lblIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA.Location = New System.Drawing.Point(6, 72)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(24, 13)
        Me.lblIVA.TabIndex = 78
        Me.lblIVA.Text = "IVA"
        '
        'lblFlete
        '
        Me.lblFlete.AutoSize = True
        Me.lblFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlete.Location = New System.Drawing.Point(6, 90)
        Me.lblFlete.Name = "lblFlete"
        Me.lblFlete.Size = New System.Drawing.Size(30, 13)
        Me.lblFlete.TabIndex = 80
        Me.lblFlete.Text = "Flete"
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.grpArticulos)
        Me.gboxFiltros.Controls.Add(Me.grpAgente)
        Me.gboxFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxFiltros.Location = New System.Drawing.Point(636, 46)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(593, 141)
        Me.gboxFiltros.TabIndex = 21
        Me.gboxFiltros.TabStop = False
        Me.gboxFiltros.Text = "Filtros"
        '
        'grpArticulos
        '
        Me.grpArticulos.Controls.Add(Me.rdoTodosLosModelos)
        Me.grpArticulos.Controls.Add(Me.rdoModelosPedido)
        Me.grpArticulos.Controls.Add(Me.Label14)
        Me.grpArticulos.Controls.Add(Me.dttFechaFin)
        Me.grpArticulos.Controls.Add(Me.dttFechaInicio)
        Me.grpArticulos.Controls.Add(Me.lblFechaFin)
        Me.grpArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpArticulos.Location = New System.Drawing.Point(6, 13)
        Me.grpArticulos.Name = "grpArticulos"
        Me.grpArticulos.Size = New System.Drawing.Size(167, 119)
        Me.grpArticulos.TabIndex = 22
        Me.grpArticulos.TabStop = False
        Me.grpArticulos.Text = "Artículos"
        '
        'rdoTodosLosModelos
        '
        Me.rdoTodosLosModelos.AutoSize = True
        Me.rdoTodosLosModelos.Checked = True
        Me.rdoTodosLosModelos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoTodosLosModelos.Location = New System.Drawing.Point(10, 14)
        Me.rdoTodosLosModelos.Name = "rdoTodosLosModelos"
        Me.rdoTodosLosModelos.Size = New System.Drawing.Size(94, 17)
        Me.rdoTodosLosModelos.TabIndex = 23
        Me.rdoTodosLosModelos.TabStop = True
        Me.rdoTodosLosModelos.Text = "Lista Completa"
        Me.rdoTodosLosModelos.UseVisualStyleBackColor = True
        '
        'rdoModelosPedido
        '
        Me.rdoModelosPedido.AutoSize = True
        Me.rdoModelosPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModelosPedido.Location = New System.Drawing.Point(10, 33)
        Me.rdoModelosPedido.Name = "rdoModelosPedido"
        Me.rdoModelosPedido.Size = New System.Drawing.Size(63, 17)
        Me.rdoModelosPedido.TabIndex = 24
        Me.rdoModelosPedido.Text = "Pedidos"
        Me.rdoModelosPedido.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(29, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Del :"
        '
        'dttFechaFin
        '
        Me.dttFechaFin.Enabled = False
        Me.dttFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFechaFin.Location = New System.Drawing.Point(59, 80)
        Me.dttFechaFin.Name = "dttFechaFin"
        Me.dttFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.dttFechaFin.TabIndex = 26
        '
        'dttFechaInicio
        '
        Me.dttFechaInicio.Enabled = False
        Me.dttFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFechaInicio.Location = New System.Drawing.Point(59, 52)
        Me.dttFechaInicio.Name = "dttFechaInicio"
        Me.dttFechaInicio.Size = New System.Drawing.Size(95, 20)
        Me.dttFechaInicio.TabIndex = 25
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFin.Location = New System.Drawing.Point(29, 82)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(22, 13)
        Me.lblFechaFin.TabIndex = 48
        Me.lblFechaFin.Text = "Al :"
        '
        'grpAgente
        '
        Me.grpAgente.Controls.Add(Me.chkSeleccionarTodo)
        Me.grpAgente.Controls.Add(Me.grdAgentes)
        Me.grpAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAgente.Location = New System.Drawing.Point(188, 13)
        Me.grpAgente.Name = "grpAgente"
        Me.grpAgente.Size = New System.Drawing.Size(399, 119)
        Me.grpAgente.TabIndex = 27
        Me.grpAgente.TabStop = False
        Me.grpAgente.Text = "Marcas"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(6, 14)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 28
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'grdAgentes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Appearance = Appearance1
        Me.grdAgentes.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows
        Me.grdAgentes.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup
        Me.grdAgentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAgentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdAgentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgentes.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.grdAgentes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdAgentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAgentes.Location = New System.Drawing.Point(3, 31)
        Me.grdAgentes.Name = "grdAgentes"
        Me.grdAgentes.Size = New System.Drawing.Size(393, 85)
        Me.grdAgentes.TabIndex = 29
        '
        'lblListaVentaCliente
        '
        Me.lblListaVentaCliente.AutoSize = True
        Me.lblListaVentaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaVentaCliente.Location = New System.Drawing.Point(10, 93)
        Me.lblListaVentaCliente.Name = "lblListaVentaCliente"
        Me.lblListaVentaCliente.Size = New System.Drawing.Size(82, 13)
        Me.lblListaVentaCliente.TabIndex = 86
        Me.lblListaVentaCliente.Text = "Lista de Precios"
        '
        'cmbListaVentasCliente
        '
        Me.cmbListaVentasCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaVentasCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaVentasCliente.FormattingEnabled = True
        Me.cmbListaVentasCliente.Location = New System.Drawing.Point(98, 90)
        Me.cmbListaVentasCliente.Name = "cmbListaVentasCliente"
        Me.cmbListaVentasCliente.Size = New System.Drawing.Size(347, 21)
        Me.cmbListaVentasCliente.TabIndex = 8
        '
        'lblListaVenta
        '
        Me.lblListaVenta.AutoSize = True
        Me.lblListaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaVenta.Location = New System.Drawing.Point(10, 71)
        Me.lblListaVenta.Name = "lblListaVenta"
        Me.lblListaVenta.Size = New System.Drawing.Size(80, 13)
        Me.lblListaVenta.TabIndex = 84
        Me.lblListaVenta.Text = "Lista de Ventas"
        '
        'lblMensajeSinListaVentas
        '
        Me.lblMensajeSinListaVentas.AutoSize = True
        Me.lblMensajeSinListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeSinListaVentas.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeSinListaVentas.Location = New System.Drawing.Point(485, 27)
        Me.lblMensajeSinListaVentas.Name = "lblMensajeSinListaVentas"
        Me.lblMensajeSinListaVentas.Size = New System.Drawing.Size(229, 13)
        Me.lblMensajeSinListaVentas.TabIndex = 82
        Me.lblMensajeSinListaVentas.Text = "El cliente no tiene asignada una lista de ventas"
        Me.lblMensajeSinListaVentas.Visible = False
        '
        'gboxParidad
        '
        Me.gboxParidad.Controls.Add(Me.lblParidadMonedaValor)
        Me.gboxParidad.Controls.Add(Me.lblParidadFecha)
        Me.gboxParidad.Controls.Add(Me.lblParidadIgual)
        Me.gboxParidad.Controls.Add(Me.lblParidadMoneda)
        Me.gboxParidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxParidad.Location = New System.Drawing.Point(824, 187)
        Me.gboxParidad.Name = "gboxParidad"
        Me.gboxParidad.Size = New System.Drawing.Size(405, 44)
        Me.gboxParidad.TabIndex = 32
        Me.gboxParidad.TabStop = False
        Me.gboxParidad.Text = "Paridad Hoy"
        Me.gboxParidad.Visible = False
        '
        'lblParidadMonedaValor
        '
        Me.lblParidadMonedaValor.AutoSize = True
        Me.lblParidadMonedaValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidadMonedaValor.Location = New System.Drawing.Point(61, 19)
        Me.lblParidadMonedaValor.Name = "lblParidadMonedaValor"
        Me.lblParidadMonedaValor.Size = New System.Drawing.Size(34, 13)
        Me.lblParidadMonedaValor.TabIndex = 38
        Me.lblParidadMonedaValor.Text = "Euros"
        '
        'lblParidadFecha
        '
        Me.lblParidadFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidadFecha.Location = New System.Drawing.Point(259, 19)
        Me.lblParidadFecha.Name = "lblParidadFecha"
        Me.lblParidadFecha.Size = New System.Drawing.Size(140, 13)
        Me.lblParidadFecha.TabIndex = 37
        Me.lblParidadFecha.Text = " 00/00/2000 00:00:00 am"
        Me.lblParidadFecha.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblParidadIgual
        '
        Me.lblParidadIgual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidadIgual.Location = New System.Drawing.Point(139, 19)
        Me.lblParidadIgual.Name = "lblParidadIgual"
        Me.lblParidadIgual.Size = New System.Drawing.Size(114, 13)
        Me.lblParidadIgual.TabIndex = 36
        Me.lblParidadIgual.Text = "1 $$    ="
        Me.lblParidadIgual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblParidadMoneda
        '
        Me.lblParidadMoneda.AutoSize = True
        Me.lblParidadMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParidadMoneda.Location = New System.Drawing.Point(6, 19)
        Me.lblParidadMoneda.Name = "lblParidadMoneda"
        Me.lblParidadMoneda.Size = New System.Drawing.Size(49, 13)
        Me.lblParidadMoneda.TabIndex = 35
        Me.lblParidadMoneda.Text = "Moneda:"
        '
        'cmbListaVentas
        '
        Me.cmbListaVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaVentas.FormattingEnabled = True
        Me.cmbListaVentas.Location = New System.Drawing.Point(98, 68)
        Me.cmbListaVentas.Name = "cmbListaVentas"
        Me.cmbListaVentas.Size = New System.Drawing.Size(347, 21)
        Me.cmbListaVentas.TabIndex = 7
        '
        'lblEstatusListaPrecios
        '
        Me.lblEstatusListaPrecios.AutoSize = True
        Me.lblEstatusListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatusListaPrecios.Location = New System.Drawing.Point(10, 49)
        Me.lblEstatusListaPrecios.Name = "lblEstatusListaPrecios"
        Me.lblEstatusListaPrecios.Size = New System.Drawing.Size(56, 13)
        Me.lblEstatusListaPrecios.TabIndex = 74
        Me.lblEstatusListaPrecios.Text = "Lista Base"
        '
        'cmbListaBase
        '
        Me.cmbListaBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaBase.FormattingEnabled = True
        Me.cmbListaBase.Location = New System.Drawing.Point(98, 46)
        Me.cmbListaBase.Name = "cmbListaBase"
        Me.cmbListaBase.Size = New System.Drawing.Size(347, 21)
        Me.cmbListaBase.TabIndex = 6
        '
        'gboxMoneda
        '
        Me.gboxMoneda.Controls.Add(Me.cmbMoneda)
        Me.gboxMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxMoneda.Location = New System.Drawing.Point(636, 187)
        Me.gboxMoneda.Name = "gboxMoneda"
        Me.gboxMoneda.Size = New System.Drawing.Size(182, 44)
        Me.gboxMoneda.TabIndex = 30
        Me.gboxMoneda.TabStop = False
        Me.gboxMoneda.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(6, 16)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(169, 21)
        Me.cmbMoneda.TabIndex = 31
        '
        'grpTipodeReporte
        '
        Me.grpTipodeReporte.Controls.Add(Me.txtClaveSAT)
        Me.grpTipodeReporte.Controls.Add(Me.RdoListaClaveSat)
        Me.grpTipodeReporte.Controls.Add(Me.rdoModelaje)
        Me.grpTipodeReporte.Controls.Add(Me.chkFamilias)
        Me.grpTipodeReporte.Controls.Add(Me.cmbRamos)
        Me.grpTipodeReporte.Controls.Add(Me.RdoSimulador)
        Me.grpTipodeReporte.Controls.Add(Me.lblRamos)
        Me.grpTipodeReporte.Controls.Add(Me.rdoListaPrecioSugerida)
        Me.grpTipodeReporte.Controls.Add(Me.rdoListadePrecios)
        Me.grpTipodeReporte.Controls.Add(Me.chkColecciones)
        Me.grpTipodeReporte.Controls.Add(Me.GroupBox1)
        Me.grpTipodeReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipodeReporte.Location = New System.Drawing.Point(451, 46)
        Me.grpTipodeReporte.Name = "grpTipodeReporte"
        Me.grpTipodeReporte.Size = New System.Drawing.Size(179, 185)
        Me.grpTipodeReporte.TabIndex = 12
        Me.grpTipodeReporte.TabStop = False
        Me.grpTipodeReporte.Text = "Tipo de Reporte"
        '
        'txtClaveSAT
        '
        Me.txtClaveSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveSAT.Location = New System.Drawing.Point(29, 159)
        Me.txtClaveSAT.Name = "txtClaveSAT"
        Me.txtClaveSAT.Size = New System.Drawing.Size(136, 20)
        Me.txtClaveSAT.TabIndex = 77
        '
        'RdoListaClaveSat
        '
        Me.RdoListaClaveSat.AutoSize = True
        Me.RdoListaClaveSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoListaClaveSat.Location = New System.Drawing.Point(9, 142)
        Me.RdoListaClaveSat.Name = "RdoListaClaveSat"
        Me.RdoListaClaveSat.Size = New System.Drawing.Size(122, 17)
        Me.RdoListaClaveSat.TabIndex = 76
        Me.RdoListaClaveSat.TabStop = True
        Me.RdoListaClaveSat.Text = "Lista con Clave SAT"
        Me.RdoListaClaveSat.UseVisualStyleBackColor = True
        '
        'rdoModelaje
        '
        Me.rdoModelaje.AutoSize = True
        Me.rdoModelaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModelaje.Location = New System.Drawing.Point(9, 55)
        Me.rdoModelaje.Name = "rdoModelaje"
        Me.rdoModelaje.Size = New System.Drawing.Size(147, 17)
        Me.rdoModelaje.TabIndex = 16
        Me.rdoModelaje.TabStop = True
        Me.rdoModelaje.Text = "Confirmación de Modelaje"
        Me.rdoModelaje.UseVisualStyleBackColor = True
        '
        'chkFamilias
        '
        Me.chkFamilias.AutoSize = True
        Me.chkFamilias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFamilias.Location = New System.Drawing.Point(94, 41)
        Me.chkFamilias.Name = "chkFamilias"
        Me.chkFamilias.Size = New System.Drawing.Size(77, 17)
        Me.chkFamilias.TabIndex = 15
        Me.chkFamilias.Text = "Ver Familia"
        Me.chkFamilias.UseVisualStyleBackColor = True
        Me.chkFamilias.Visible = False
        '
        'cmbRamos
        '
        Me.cmbRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRamos.FormattingEnabled = True
        Me.cmbRamos.Location = New System.Drawing.Point(261, 150)
        Me.cmbRamos.Name = "cmbRamos"
        Me.cmbRamos.Size = New System.Drawing.Size(189, 21)
        Me.cmbRamos.TabIndex = 74
        Me.cmbRamos.Visible = False
        '
        'RdoSimulador
        '
        Me.RdoSimulador.AutoSize = True
        Me.RdoSimulador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoSimulador.Location = New System.Drawing.Point(9, 74)
        Me.RdoSimulador.Name = "RdoSimulador"
        Me.RdoSimulador.Size = New System.Drawing.Size(97, 17)
        Me.RdoSimulador.TabIndex = 17
        Me.RdoSimulador.TabStop = True
        Me.RdoSimulador.Text = "Simulador - IXP"
        Me.RdoSimulador.UseVisualStyleBackColor = True
        '
        'lblRamos
        '
        Me.lblRamos.AutoSize = True
        Me.lblRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRamos.Location = New System.Drawing.Point(215, 154)
        Me.lblRamos.Name = "lblRamos"
        Me.lblRamos.Size = New System.Drawing.Size(40, 13)
        Me.lblRamos.TabIndex = 27
        Me.lblRamos.Text = "Ramos"
        Me.lblRamos.Visible = False
        '
        'rdoListaPrecioSugerida
        '
        Me.rdoListaPrecioSugerida.AutoSize = True
        Me.rdoListaPrecioSugerida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoListaPrecioSugerida.Location = New System.Drawing.Point(220, 134)
        Me.rdoListaPrecioSugerida.Name = "rdoListaPrecioSugerida"
        Me.rdoListaPrecioSugerida.Size = New System.Drawing.Size(144, 17)
        Me.rdoListaPrecioSugerida.TabIndex = 4
        Me.rdoListaPrecioSugerida.TabStop = True
        Me.rdoListaPrecioSugerida.Text = "Lista de precios Sugerida"
        Me.rdoListaPrecioSugerida.UseVisualStyleBackColor = True
        Me.rdoListaPrecioSugerida.Visible = False
        '
        'rdoListadePrecios
        '
        Me.rdoListadePrecios.AutoSize = True
        Me.rdoListadePrecios.Checked = True
        Me.rdoListadePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoListadePrecios.Location = New System.Drawing.Point(9, 21)
        Me.rdoListadePrecios.Name = "rdoListadePrecios"
        Me.rdoListadePrecios.Size = New System.Drawing.Size(100, 17)
        Me.rdoListadePrecios.TabIndex = 13
        Me.rdoListadePrecios.TabStop = True
        Me.rdoListadePrecios.Text = "Lista de Precios"
        Me.rdoListadePrecios.UseVisualStyleBackColor = True
        '
        'chkColecciones
        '
        Me.chkColecciones.AutoSize = True
        Me.chkColecciones.Checked = True
        Me.chkColecciones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkColecciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColecciones.Location = New System.Drawing.Point(29, 41)
        Me.chkColecciones.Name = "chkColecciones"
        Me.chkColecciones.Size = New System.Drawing.Size(103, 17)
        Me.chkColecciones.TabIndex = 14
        Me.chkColecciones.Text = "Ver Colecciones"
        Me.chkColecciones.UseVisualStyleBackColor = True
        Me.chkColecciones.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoPrecioPesosActual)
        Me.GroupBox1.Controls.Add(Me.rdoPrecioPorcentajeActual)
        Me.GroupBox1.Controls.Add(Me.numPrecioIncrementoParActual)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 53)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'rdoPrecioPesosActual
        '
        Me.rdoPrecioPesosActual.AutoSize = True
        Me.rdoPrecioPesosActual.Enabled = False
        Me.rdoPrecioPesosActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPrecioPesosActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoPrecioPesosActual.Location = New System.Drawing.Point(7, 31)
        Me.rdoPrecioPesosActual.Name = "rdoPrecioPesosActual"
        Me.rdoPrecioPesosActual.Size = New System.Drawing.Size(76, 17)
        Me.rdoPrecioPesosActual.TabIndex = 19
        Me.rdoPrecioPesosActual.Text = "$ (PESOS)"
        Me.rdoPrecioPesosActual.UseVisualStyleBackColor = True
        '
        'rdoPrecioPorcentajeActual
        '
        Me.rdoPrecioPorcentajeActual.AutoSize = True
        Me.rdoPrecioPorcentajeActual.Checked = True
        Me.rdoPrecioPorcentajeActual.Enabled = False
        Me.rdoPrecioPorcentajeActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPrecioPorcentajeActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoPrecioPorcentajeActual.Location = New System.Drawing.Point(7, 11)
        Me.rdoPrecioPorcentajeActual.Name = "rdoPrecioPorcentajeActual"
        Me.rdoPrecioPorcentajeActual.Size = New System.Drawing.Size(65, 17)
        Me.rdoPrecioPorcentajeActual.TabIndex = 18
        Me.rdoPrecioPorcentajeActual.TabStop = True
        Me.rdoPrecioPorcentajeActual.Text = "% Indice"
        Me.rdoPrecioPorcentajeActual.UseVisualStyleBackColor = True
        '
        'numPrecioIncrementoParActual
        '
        Me.numPrecioIncrementoParActual.DecimalPlaces = 2
        Me.numPrecioIncrementoParActual.Enabled = False
        Me.numPrecioIncrementoParActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrecioIncrementoParActual.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numPrecioIncrementoParActual.Location = New System.Drawing.Point(99, 9)
        Me.numPrecioIncrementoParActual.Name = "numPrecioIncrementoParActual"
        Me.numPrecioIncrementoParActual.Size = New System.Drawing.Size(57, 20)
        Me.numPrecioIncrementoParActual.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Cliente"
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(98, 24)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(347, 21)
        Me.cmbClientes.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1176, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(57, 237)
        Me.Panel1.TabIndex = 83
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 36
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(33, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.Pnl_ExportarPDF)
        Me.pnlAcciones.Controls.Add(Me.lblExportarExcel)
        Me.pnlAcciones.Controls.Add(Me.btnImprimir)
        Me.pnlAcciones.Controls.Add(Me.lblImprimir)
        Me.pnlAcciones.Controls.Add(Me.btnHistorico)
        Me.pnlAcciones.Controls.Add(Me.lblHistorico)
        Me.pnlAcciones.Controls.Add(Me.btnExportarExcel)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(350, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'Pnl_ExportarPDF
        '
        Me.Pnl_ExportarPDF.Controls.Add(Me.btnGenerarReportePDF)
        Me.Pnl_ExportarPDF.Controls.Add(Me.lblExportarPDF)
        Me.Pnl_ExportarPDF.Location = New System.Drawing.Point(216, 1)
        Me.Pnl_ExportarPDF.Name = "Pnl_ExportarPDF"
        Me.Pnl_ExportarPDF.Size = New System.Drawing.Size(97, 56)
        Me.Pnl_ExportarPDF.TabIndex = 4
        '
        'btnGenerarReportePDF
        '
        Me.btnGenerarReportePDF.Image = CType(resources.GetObject("btnGenerarReportePDF.Image"), System.Drawing.Image)
        Me.btnGenerarReportePDF.Location = New System.Drawing.Point(30, 7)
        Me.btnGenerarReportePDF.Name = "btnGenerarReportePDF"
        Me.btnGenerarReportePDF.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReportePDF.TabIndex = 3
        Me.btnGenerarReportePDF.Text = "✓"
        Me.btnGenerarReportePDF.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(14, 38)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(70, 13)
        Me.lblExportarPDF.TabIndex = 27
        Me.lblExportarPDF.Text = "Exportar PDF"
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(79, 39)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(75, 13)
        Me.lblExportarExcel.TabIndex = 28
        Me.lblExportarExcel.Text = "Exportar Excel"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(171, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(168, 39)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 36
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnHistorico
        '
        Me.btnHistorico.Image = CType(resources.GetObject("btnHistorico.Image"), System.Drawing.Image)
        Me.btnHistorico.Location = New System.Drawing.Point(23, 8)
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Size = New System.Drawing.Size(32, 32)
        Me.btnHistorico.TabIndex = 1
        Me.btnHistorico.UseVisualStyleBackColor = True
        '
        'lblHistorico
        '
        Me.lblHistorico.AutoSize = True
        Me.lblHistorico.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblHistorico.Location = New System.Drawing.Point(18, 39)
        Me.lblHistorico.Name = "lblHistorico"
        Me.lblHistorico.Size = New System.Drawing.Size(48, 13)
        Me.lblHistorico.TabIndex = 29
        Me.lblHistorico.Text = "Histórico"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.Location = New System.Drawing.Point(102, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 2
        Me.btnExportarExcel.Text = "✓"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(1176, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlActualizacionIzq)
        Me.pnlPie.Controls.Add(Me.pnlBotonesPie)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 549)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1236, 60)
        Me.pnlPie.TabIndex = 11
        '
        'pnlActualizacionIzq
        '
        Me.pnlActualizacionIzq.Controls.Add(Me.Panel5)
        Me.pnlActualizacionIzq.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlActualizacionIzq.Location = New System.Drawing.Point(698, 0)
        Me.pnlActualizacionIzq.Name = "pnlActualizacionIzq"
        Me.pnlActualizacionIzq.Size = New System.Drawing.Size(325, 60)
        Me.pnlActualizacionIzq.TabIndex = 24
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel5.Location = New System.Drawing.Point(3, 23)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(322, 37)
        Me.Panel5.TabIndex = 25
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(114, 0)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(208, 13)
        Me.lblUltimaActualizacion.TabIndex = 23
        Me.lblUltimaActualizacion.Text = "Última Actualización: __ / __ / __    __ __ "
        '
        'pnlBotonesPie
        '
        Me.pnlBotonesPie.Controls.Add(Me.btnCancelar)
        Me.pnlBotonesPie.Controls.Add(Me.btnVolverCargarReporte)
        Me.pnlBotonesPie.Controls.Add(Me.lblMostrar)
        Me.pnlBotonesPie.Controls.Add(Me.btnLimpiar)
        Me.pnlBotonesPie.Controls.Add(Me.lblCancelar)
        Me.pnlBotonesPie.Controls.Add(Me.lblLimpiar)
        Me.pnlBotonesPie.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesPie.Location = New System.Drawing.Point(1023, 0)
        Me.pnlBotonesPie.Name = "pnlBotonesPie"
        Me.pnlBotonesPie.Size = New System.Drawing.Size(213, 60)
        Me.pnlBotonesPie.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(154, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 41
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnVolverCargarReporte
        '
        Me.btnVolverCargarReporte.Image = CType(resources.GetObject("btnVolverCargarReporte.Image"), System.Drawing.Image)
        Me.btnVolverCargarReporte.Location = New System.Drawing.Point(33, 6)
        Me.btnVolverCargarReporte.Name = "btnVolverCargarReporte"
        Me.btnVolverCargarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnVolverCargarReporte.TabIndex = 39
        Me.btnVolverCargarReporte.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(29, 41)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 30
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(96, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 40
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(155, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(94, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2
        Me.lblLimpiar.Text = "Limpiar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1236, 60)
        Me.pnlHeader.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(747, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 60)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblTitulo)
        Me.Panel3.Location = New System.Drawing.Point(3, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(420, 34)
        Me.Panel3.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(111, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(309, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Reportes - Ventas - Listas de Precios"
        '
        'tbtReporteCliente
        '
        Me.tbtReporteCliente.Controls.Add(Me.grdReporte)
        Me.tbtReporteCliente.Location = New System.Drawing.Point(4, 22)
        Me.tbtReporteCliente.Name = "tbtReporteCliente"
        Me.tbtReporteCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtReporteCliente.Size = New System.Drawing.Size(1228, 207)
        Me.tbtReporteCliente.TabIndex = 2
        Me.tbtReporteCliente.Text = "Lista de Precio de Cliente"
        Me.tbtReporteCliente.UseVisualStyleBackColor = True
        '
        'grdReporte
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReporte.DisplayLayout.Appearance = Appearance3
        Me.grdReporte.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows
        Me.grdReporte.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup
        Me.grdReporte.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReporte.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdReporte.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdReporte.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReporte.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdReporte.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReporte.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdReporte.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReporte.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(3, 3)
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(1222, 201)
        Me.grdReporte.TabIndex = 38
        '
        'tbtListasDeClientes
        '
        Me.tbtListasDeClientes.Controls.Add(Me.tbtReporteCliente)
        Me.tbtListasDeClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtListasDeClientes.Location = New System.Drawing.Point(0, 316)
        Me.tbtListasDeClientes.Name = "tbtListasDeClientes"
        Me.tbtListasDeClientes.SelectedIndex = 0
        Me.tbtListasDeClientes.Size = New System.Drawing.Size(1236, 233)
        Me.tbtListasDeClientes.TabIndex = 29
        '
        'ListaPreciosClienteAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1236, 609)
        Me.Controls.Add(Me.tbtListasDeClientes)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaPreciosClienteAlta"
        Me.Text = "Reportes - Ventas - Listas de Precios"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gboxListaVentas.ResumeLayout(False)
        Me.gboxListaVentas.PerformLayout()
        Me.gboxFiltros.ResumeLayout(False)
        Me.grpArticulos.ResumeLayout(False)
        Me.grpArticulos.PerformLayout()
        Me.grpAgente.ResumeLayout(False)
        Me.grpAgente.PerformLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxParidad.ResumeLayout(False)
        Me.gboxParidad.PerformLayout()
        Me.gboxMoneda.ResumeLayout(False)
        Me.grpTipodeReporte.ResumeLayout(False)
        Me.grpTipodeReporte.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numPrecioIncrementoParActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Pnl_ExportarPDF.ResumeLayout(False)
        Me.Pnl_ExportarPDF.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlActualizacionIzq.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlBotonesPie.ResumeLayout(False)
        Me.pnlBotonesPie.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tbtReporteCliente.ResumeLayout(False)
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtListasDeClientes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents lblIncrementoXPar As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesPie As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblFacturacion As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnGenerarReportePDF As System.Windows.Forms.Button
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnHistorico As System.Windows.Forms.Button
    Friend WithEvents lblHistorico As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblFechaInicioLista As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinLista As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents tbtReporteCliente As System.Windows.Forms.TabPage
    Friend WithEvents grdReporte As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpAgente As System.Windows.Forms.GroupBox
    Friend WithEvents grpArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoTodosLosModelos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoModelosPedido As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dttFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents grpTipodeReporte As System.Windows.Forms.GroupBox
    Friend WithEvents rdoModelaje As System.Windows.Forms.RadioButton
    Friend WithEvents rdoListadePrecios As System.Windows.Forms.RadioButton
    Friend WithEvents chkColecciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkFamilias As System.Windows.Forms.CheckBox
    Friend WithEvents btnVolverCargarReporte As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents tbtListasDeClientes As System.Windows.Forms.TabControl
    Friend WithEvents rdoListaPrecioSugerida As System.Windows.Forms.RadioButton
    Friend WithEvents RdoSimulador As System.Windows.Forms.RadioButton
    Friend WithEvents lblRamos As System.Windows.Forms.Label
    Friend WithEvents gboxMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents grdAgentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents cmbListaVentas As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstatusListaPrecios As System.Windows.Forms.Label
    Friend WithEvents lblFlete As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents gboxParidad As System.Windows.Forms.GroupBox
    Friend WithEvents lblParidadMonedaValor As System.Windows.Forms.Label
    Friend WithEvents lblParidadFecha As System.Windows.Forms.Label
    Friend WithEvents lblParidadIgual As System.Windows.Forms.Label
    Friend WithEvents lblParidadMoneda As System.Windows.Forms.Label
    Friend WithEvents lblMensajeSinListaVentas As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlActualizacionIzq As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents cmbListaBase As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRamos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPrecioPesosActual As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPrecioPorcentajeActual As System.Windows.Forms.RadioButton
    Friend WithEvents numPrecioIncrementoParActual As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblListaVenta As System.Windows.Forms.Label
    Friend WithEvents lblListaVentaCliente As System.Windows.Forms.Label
    Friend WithEvents cmbListaVentasCliente As System.Windows.Forms.ComboBox
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents lblAtn As System.Windows.Forms.Label
    Friend WithEvents txtAtn As System.Windows.Forms.TextBox
    Friend WithEvents chkDescuentoAplicado As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaFinListaDato As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicioLista_Dato As System.Windows.Forms.Label
    Friend WithEvents lblINCOTERM_DATO As System.Windows.Forms.Label
    Friend WithEvents lblMoneda_Dato As System.Windows.Forms.Label
    Friend WithEvents lblParidad_Dato As System.Windows.Forms.Label
    Friend WithEvents lblINCOTERM As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents lblParidad As System.Windows.Forms.Label
    Friend WithEvents gboxListaVentas As System.Windows.Forms.GroupBox
    Friend WithEvents lblIncrementoXPar_Dato As System.Windows.Forms.Label
    Friend WithEvents lblDescuento_Dato As System.Windows.Forms.Label
    Friend WithEvents lblFactuacion_Dato As System.Windows.Forms.Label
    Friend WithEvents lblIVA_Dato As System.Windows.Forms.Label
    Friend WithEvents lblFlete_Dato As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblMonedaNombre As System.Windows.Forms.Label
    Friend WithEvents lblMostrarModelo As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoModelo_Sicy As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_ModeloSAY As System.Windows.Forms.RadioButton
    Friend WithEvents btnFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents txtClaveSAT As System.Windows.Forms.TextBox
    Friend WithEvents RdoListaClaveSat As System.Windows.Forms.RadioButton
    Friend WithEvents Pnl_ExportarPDF As Panel
End Class
